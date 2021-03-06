using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
public partial class nvk_BaoCaoNhapXuatTon : Genaratepage
{
    private profess_Rpt_nhapxuatton bbkn;
    string dkmenu = "tiepnhan";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txtTuNgay.Text = DateTime.Now.ToString("01/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            bindkho();
            this.bindLoaiThuoc(); this.chbLoaiThuoc.SelectedValue = "1";
        }
        LoadMenu();
    }
    private void LoadMenu()
    {
        try
        {
            string dkmenu = Request.QueryString["dkmenu"].ToString();
            PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
        }
        catch (Exception ex)
        {
        }
    }
    private void bindLoaiThuoc()
    {
        DataTable dt = DataAcess.Connect.GetTable("select * from Thuoc_LoaiThuoc");
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(this.chbLoaiThuoc, dt, "LoaithuocID", "TenLoai", "Tất cả các nhóm ");
        }
    }
    private void bindkho()
    {
        string sql = "select * from khothuoc  where nvk_loaikho not in (4) and idkhoa=" + (Request.QueryString["idkhoa"] != null ? Request.QueryString["idkhoa"] : "0") + "";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddlkho, dt, "idkho", "tenkho", "-------------Chọn kho------------");
            ddlkho.SelectedValue = StaticData.MacDinhKhoNhapMuaID;
        }
    }

    protected void btnTim_Click(object sender, EventArgs e)
    {
        this.bbkn = new profess_Rpt_nhapxuatton();
        bbkn.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bbkn_AfterExportToExcel);
        bbkn.FromDate = StaticData.CheckDate(this.txtTuNgay.Text);
        bbkn.ToDate = StaticData.CheckDate(this.txtDenNgay.Text) + " 23:59:59";
        bbkn.StockName = this.ddlkho.SelectedItem.Text;
        //bbkn.StockID = this.ddlkho.SelectedValue.ToString();
        this.bbkn.LoaiThuocID = this.chbLoaiThuoc.SelectedValue.ToString();
        this.bbkn.TenLoaiThuoc = this.chbLoaiThuoc.SelectedItem.Text;
        int idkhoa = StaticData.ParseInt(Request.QueryString["idkhoa"]);
        //if (idkhoa > 0)
        //    bbkn.TenKhoa = "Kho: " + StaticData.GetValue("khothuoc", "idkho", ddlkho.SelectedValue, "tenkho");
        bbkn.ExportToExcel();
    }
    void bbkn_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + bbkn.OutputFileName + "\",'_blank')</script>");
    }
}

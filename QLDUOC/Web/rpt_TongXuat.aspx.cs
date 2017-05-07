using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
public partial class QLDUOC_Web_rpt_TongXuat : System.Web.UI.Page
{
    private profess_Rpt_sosanhNXT bbkn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.txtNam.Text = DateTime.Now.ToString("yyyy");
            bindkho();
            this.bindLoaiThuoc(); this.chbLoaiThuoc.SelectedValue = "1";
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
        DataTable dt = StaticData.dtGetKho(this, false); ;
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddlkho, dt, "idkho", "tenkho", "-------------Chọn kho------------");
            ddlkho.SelectedValue = StaticData.MacDinhKhoNhapMuaID;
        }
    }
    void bbkn_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../../ReportOutput/" + bbkn.OutputFileName + "\",'_blank')</script>");
    }

    protected void btnTim_Click(object sender, EventArgs e)
    {

        this.bbkn = new profess_Rpt_sosanhNXT();
        bbkn.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bbkn_AfterExportToExcel);
        bbkn.Year = this.txtNam.Text;
        bbkn.StockName = this.ddlkho.SelectedItem.Text;
        bbkn.StockID = this.ddlkho.SelectedValue.ToString();
        this.bbkn.LoaiThuocID = this.chbLoaiThuoc.SelectedValue.ToString();
        this.bbkn.TenLoaiThuoc = this.chbLoaiThuoc.SelectedItem.Text;
        bbkn.ExportToExcel();
    }
}

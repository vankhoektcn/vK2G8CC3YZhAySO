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
using CrystalDecisions.CrystalReports.Engine;

public partial class frm_Rpt_BienBanKiemNhap : System.Web.UI.Page
{
    BienBangKiemNhap bbkn = null;

    private string tungay = "";
    private string denngay = "";
    private string idloaiNhap = "";
    private string idThuoc = "";
    private string idKho = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadkhonhap();
            loadloaithuoc();
            
            txtTuNgay.Text = System.DateTime.Now.ToString("01/MM/yyyy");
            txtDenNgay.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        }
    }
    private void loadkhonhap()
    {

        DataTable dt = StaticData.dtGetKho(this, false);
        StaticData.FillCombo(ddl_khonhap, dt, "idkho", "tenkho", "-- Chọn Kho --");
        if (dt.Rows.Count > 0) ddl_khonhap.SelectedIndex = 1;
    }
    private void loadloaithuoc()
    {
        string sql = "select * from thuoc_loaithuoc";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddl_loaithuoc, dt, "LoaiThuocID", "TenLoai", "-- Chọn nhóm  --");
        if (dt.Rows.Count > 0) ddl_loaithuoc.SelectedIndex = 1;
    }
   
    protected void btnTim_Click(object sender, EventArgs e)
    {
        this.bbkn = new BienBangKiemNhap();
        bbkn.TuNgay = StaticData.CheckDate(txtTuNgay.Text);
        bbkn.DenNgay = StaticData.CheckDate(txtDenNgay.Text);
        bbkn.LOAITHUOCID = ddl_loaithuoc.SelectedValue;
        bbkn.IDKHO = ddl_khonhap.SelectedValue;
        bbkn.TenLoaiThuoc = StaticData.GetValue("thuoc_loaithuoc", "loaithuocid", ddl_loaithuoc.SelectedValue, "TenLoai");
        bbkn.ExportToExcel();
        string tenFile = bbkn.OutputFileName;

        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + tenFile + "\",'_blank')</script>");
        tungay = StaticData.CheckDate(txtTuNgay.Text);
        denngay = StaticData.CheckDate(txtDenNgay.Text) + " ";
        idThuoc = ddl_loaithuoc.SelectedValue.ToString();
        idKho = ddl_khonhap.SelectedValue.ToString();
        
    }


   
    
    
}

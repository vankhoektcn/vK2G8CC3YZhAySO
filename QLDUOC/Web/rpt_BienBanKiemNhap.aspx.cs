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

public partial class QLDUOC_Web_rpt_BienBanKiemNhap : System.Web.UI.Page
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
            txtTuNgay.Value = System.DateTime.Now.ToString("01/MM/yyyy");
            txtDenNgay.Value = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    #region bind kho
    private void loadkhonhap()
    {

        string IdKho = Request["IdKho"];
        if (IdKho == null || IdKho == "") IdKho = StaticData.MacDinhKhoNhapMuaID;
        DataTable dt = DataAcess.Connect.GetTable("SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 AND IDKHO=" + IdKho);
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddl_khonhap, dt, "idkho", "tenkho", "----------Chọn kho-----------");
            this.ddl_khonhap.SelectedValue = IdKho;
        }
    }
    #endregion
    #region get ten kho
    private string gettenkho(string idkho)
    {
        DataTable dt = DataAcess.Connect.GetTable("select tenkho from khothuoc where idkho = " + idkho);
        if (dt != null && dt.Rows.Count > 0)
        {
            return dt.Rows[0]["tenkho"].ToString();
        }
        else
        {
            return null;
        }
    }
    #endregion
    #region  bind loaithuoc
    private void loadloaithuoc()
    {

        StaticData.FillCombo(ddl_loaithuoc, Thuoc_Process.Thuoc_LoaiThuoc.dtGetAll(), "loaithuocid", "tenloai");
        string LoaiThuocID = Request["LoaiThuocID"];
        if (LoaiThuocID == null || LoaiThuocID == "") LoaiThuocID = "1";
        ddl_loaithuoc.SelectedValue = LoaiThuocID;
    }
    #endregion
    protected void btnTim_Click(object sender, EventArgs e)
    {
        this.bbkn = new BienBangKiemNhap();
        this.bbkn.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bbkn_AfterExportToExcel);
        bbkn.TuNgay = StaticData.CheckDate(txtTuNgay.Value);
        bbkn.DenNgay = StaticData.CheckDate(txtDenNgay.Value);
        bbkn.LOAITHUOCID = ddl_loaithuoc.SelectedValue;
        bbkn.IDKHO = ddl_khonhap.SelectedValue;
        bbkn.TenLoaiThuoc = StaticData.GetValue("thuoc_loaithuoc", "loaithuocid", ddl_loaithuoc.SelectedValue, "TenLoai");
        bbkn.ExportToExcel();
        string tenFile = bbkn.OutputFileName;
        tungay = StaticData.CheckDate(txtTuNgay.Value);
        denngay = StaticData.CheckDate(txtDenNgay.Value) + " ";
        idThuoc = ddl_loaithuoc.SelectedValue.ToString();
        idKho = ddl_khonhap.SelectedValue.ToString();

    }
    void bbkn_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../../ReportOutput/" + bbkn.OutputFileName + "\",'_blank')</script>");
    }
}

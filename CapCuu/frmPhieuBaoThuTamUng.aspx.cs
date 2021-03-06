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
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;

public partial class frmPhieuBaoThuTamUng : Page
{
    ReportDocument report;
    protected void Page_Load(object sender, EventArgs e)
    {
        string dkMenu = Request.QueryString["dkMenu"];

        ////if (dkMenu == "kb")
        ////{
        ////    PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
        ////}
        ////if (dkMenu == "thuphi")
        ////{
        ////    PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
        ////}
        ////if (dkMenu == "tiepnhan")
        ////{
        ////    PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        ////}
        ////if (dkMenu == "cls")
        ////{
        ////    PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
        ////}
        ////if (dkMenu == "capcuu")
        ////{
        ////    PlaceHolder1.Controls.Add(LoadControl("~/CapCuu/uscmenu.ascx"));
        ////}
        //string iddkk = Request.QueryString["iddkk"].ToString();
        string hdIdTamUng = Request.QueryString["hdIdTamUng"].ToString();
        if (hdIdTamUng == null || hdIdTamUng == "") return;

        string sqlDkk = @"SELECT  NgayTU=convert(varchar,TU.ngayTamung,103),BN.tenbenhnhan,TuoiBN= dbo.kb_GetTuoi(bn.ngaysinh), BN.diachi, BN.dienthoai
, TU.sotien, TU.ngayTamung,SCT.QUYENSO,SCT.SOPHIEUCT ,tenphongkhambenh
,PhongBN= isnull((select tenphong from kb_phong where id in(select top 1 idphongnoitru from benhnhannoitru where idchitietdangkykham=ctdkk.idchitietdangkykham order by ngayvaovien desc) ),'')
";
        sqlDkk+=" FROM tamung TU LEFT JOIN chitietdangkykham ctdkk ON ctdkk.idchitietdangkykham = TU.iddangkykham ";
        sqlDkk += " LEFT JOIN dangkykham dkk ON dkk.iddangkykham  =ctdkk.iddangkykham LEFT JOIN benhnhan BN on BN.idbenhnhan = dkk.idbenhnhan ";
        sqlDkk += @" LEFT JOIN SOCHUNGTU SCT ON TU.SOCTTU=SCT.STT  
--left join banggiadichvu bg on bg.idbanggiadichvu =ctdkk.idbanggiadichvu
left join phongkhambenh pk on TU.idkhoaTU=pk.idphongkhambenh";
        sqlDkk += "  WHERE tu.idtamung = " + StaticData.ParseInt(hdIdTamUng);

        DataTable dtDkk = DataAcess.Connect.GetTable(sqlDkk);
        if (dtDkk == null || dtDkk.Rows.Count == 0) return;

        DateTime NgayThangNam = DateTime.Parse(dtDkk.Rows[0]["ngayTamung"].ToString());

        report = new ReportDocument();
        string TenReport = "rptPhieuBaoTamUngTien";
        report.Load(Server.MapPath("../report/" + TenReport + ".rpt"));

        ((TextObject)report.ReportDefinition.ReportObjects["txtTenBN"]).Text = dtDkk.Rows[0]["tenbenhnhan"].ToString();
        ((TextObject)report.ReportDefinition.ReportObjects["txtTenKhoa"]).Text = dtDkk.Rows[0]["tenphongkhambenh"].ToString(); 
        ((TextObject)report.ReportDefinition.ReportObjects["txtTuoi"]).Text = dtDkk.Rows[0]["TuoiBN"].ToString(); 
        ((TextObject)report.ReportDefinition.ReportObjects["txtNguyenQuan"]).Text = dtDkk.Rows[0]["diachi"].ToString();
        string strTienTe = String.Format("{0:0,000 VNĐ}", double.Parse(dtDkk.Rows[0]["sotien"].ToString()));
        ((TextObject)report.ReportDefinition.ReportObjects["txtTienSo"]).Text = strTienTe;

        string str_SO = new clsDocSo.clsDocSo().ChuyenSo(dtDkk.Rows[0]["sotien"].ToString() != "" ? dtDkk.Rows[0]["sotien"].ToString() : "0");
        ((TextObject)report.ReportDefinition.ReportObjects["txtTienSo"]).Text = strTienTe+" (" + str_SO.ToString() + ")";

        ((TextObject)report.ReportDefinition.ReportObjects["txtDienThoai"]).Text = dtDkk.Rows[0]["dienthoai"].ToString();
        ((TextObject)report.ReportDefinition.ReportObjects["txtPhongBN"]).Text = dtDkk.Rows[0]["PhongBN"].ToString();
        
        ((TextObject)report.ReportDefinition.ReportObjects["txtNgayTamUng"]).Text = dtDkk.Rows[0]["NgayTU"].ToString();
        //((TextObject)report.ReportDefinition.ReportObjects["txtNam"]).Text = NgayThangNam.ToString("yyyy");
        ////((TextObject)report.ReportDefinition.ReportObjects["txtTenNguoiDung"]).Text = SysParameter.UserLogin.FullName(this).ToString();
        //((TextObject)report.ReportDefinition.ReportObjects["txtQuyenSo"]).Text = dtDkk.Rows[0]["QuyenSo"].ToString();
        //((TextObject)report.ReportDefinition.ReportObjects["txtSo"]).Text = dtDkk.Rows[0]["SOPHIEUCT"].ToString();

        this.bienlaitamung.ReportSource = report;
        this.bienlaitamung.DataBind();

    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(report);
    }

    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(report);
    }
    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(form_unload);
    }
    #endregion
}

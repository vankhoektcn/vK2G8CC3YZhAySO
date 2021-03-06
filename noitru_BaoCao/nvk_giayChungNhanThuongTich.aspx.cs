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

public partial class nvk_giayChungNhanThuongTich : System.Web.UI.Page
{
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadMenu();
        if (isXacNhanThongTinChungNhan.Value.Equals("1"))
            LoadGiayChungNhan();
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
    private void LoadGiayChungNhan()
    {
        crystalReport = new ReportDocument();
        string ReportSourceName = "nvk_rptChungNhanThuongTich";
        crystalReport.Load(Server.MapPath("../noitru_BaoCao/Report/" + ReportSourceName + ".rpt"));

        #region GET parameter
        string soCN_nvk = soCN.Value;
        string txtSoVaoVien_nvk = txtSoVaoVien.Value;
        string TenBenhNhan_nvk = TenBenhNhan.Value;
        string txtNgaySinh_nvk = txtNgaySinh.Value;
        string txtGioiTinh_nvk = txtGioiTinh.Value;
        string txtNgheNghiep_nvk = txtNgheNghiep.Value;
        string txtNoiLamViec_nvk = txtNoiLamViec.Value;

        string txtCMND_nvk = txtCMND.Value;
        string txtNgay_noiCM_nvk = txtNgay_noiCM.Value;
        string txtDiaChi_nvk = txtDiaChi.Value;
        string txtVaoVienLuc_nvk = txtVaoVienLuc.Value;
        string txtRaVienLuc_nvk = txtRaVienLuc.Value;
        string lyDoVaoVien_nvk = lyDoVaoVien.Value;

        string chanDoan_nvk = chanDoan.Value;
        string dieuTri_nvk = dieuTri.Value;
        string thuongTichVaovien_nvk = thuongTichVaovien.Value;
        string thuongTichRavien_nvk = thuongTichRavien.Value;
        #endregion

        #region set parameter
        crystalReport.SetParameterValue("@nvk_So", soCN_nvk);
        crystalReport.SetParameterValue("@SoVaoVien", txtSoVaoVien_nvk);
        crystalReport.SetParameterValue("@tenBenhNhan", TenBenhNhan_nvk);
        crystalReport.SetParameterValue("@strNgaySinh", txtNgaySinh_nvk);
        crystalReport.SetParameterValue("@ngheNghiep", txtNgheNghiep_nvk);
        crystalReport.SetParameterValue("@noiLamViec", txtNoiLamViec_nvk);
        crystalReport.SetParameterValue("@cmnd", txtCMND_nvk);
        crystalReport.SetParameterValue("@ngay_NoiCapCM", txtNgay_noiCM_nvk);
        crystalReport.SetParameterValue("@diaChi", txtDiaChi_nvk);
        crystalReport.SetParameterValue("@str_vaoVienLuc", txtVaoVienLuc_nvk);
        crystalReport.SetParameterValue("@str_raVienLuc", txtRaVienLuc_nvk);
        crystalReport.SetParameterValue("@lyDoVaoVien", lyDoVaoVien_nvk);
        crystalReport.SetParameterValue("@chanDoan", chanDoan_nvk);
        crystalReport.SetParameterValue("@dieuTri", dieuTri_nvk);
        crystalReport.SetParameterValue("@thuongTichVaoVien", thuongTichVaovien_nvk);
        crystalReport.SetParameterValue("@thuongTichRaVien", thuongTichRavien_nvk);
        crystalReport.SetParameterValue("@gioiTinh", txtGioiTinh_nvk);
        #endregion

        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
        isXacNhanThongTinChungNhan.Value = "1";
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
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
    protected void btnDongY_ServerClick(object sender, EventArgs e)
    {
        LoadGiayChungNhan();

    }
}

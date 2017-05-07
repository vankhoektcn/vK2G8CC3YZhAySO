using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
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

public partial class KTCN_Khach_Hang_TH : System.Web.UI.Page
{

    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            loadtk();
        }                
    }
    void loadtk()
    {
        string sql = "select taikhoan,tentaikhoan from danhmuctk where taikhoan = '131' or taikhoan='138' or taikhoan='141' order by taikhoan";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(drltkcn, dt, "taikhoan", "taikhoan", "chọn tk công nợ");
    }
    void load()
    {
        string strTK = drltkcn.Text.Trim();
        //string strTK = "131";
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/KTCN_Khach_Hang_TH.rpt"));//file:///E:\PHAN MEM QUAN LY\quanlythuoc\report\toathuocnguoidung.rpt        
        DataTable dts = LoadCongNoKhachHang_TH(strTK);
        crystalReport.SetDataSource(dts);
        crystalReport.SetParameterValue("@tungay", txtNgay.Text);
        crystalReport.SetParameterValue("@denngay", txtDenNgay.Text);
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
        //lay ten, dia chi cong ty
        string sql1 = "select ten_cty,diachi from tieudecty";
        DataTable dtcty = new DataTable();
        dtcty = DataAcess.Connect.GetTable(sql1);
        if (dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();
        }
    }
    private DataTable LoadCongNoKhachHang_TH(string strTK)
    {
        string sql;
        DataTable dtSRC = new DataTable();
        dtSRC = null;
        sql = "exec spCong_No_Khach_Hang_TH  '" + StaticData.CheckDate_kt(txtNgay.Text) + "','" + StaticData.CheckDate_kt(txtDenNgay.Text) + "','" + strTK + "'";
        dtSRC = DataAcess.Connect.GetTable(sql);
        return dtSRC;
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
    protected void btnXem_Click(object sender, EventArgs e)
    {        
        load();
    }
}

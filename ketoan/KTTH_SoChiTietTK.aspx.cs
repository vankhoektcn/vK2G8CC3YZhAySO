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

public partial class KTTH_SoChiTietTK : System.Web.UI.Page
{
    
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
           // load();
        }
        load();
        
    }
    void load()
    {
        string strTK = txtTaiKhoan.Text;
        string no_dk ="";
        string co_dk = "";        
        string ten_tk = "";
        string sqlten_tk="select taikhoan,tentaikhoan from danhmuctk where taikhoan='"+strTK+"'";
        DataTable dtten_tk = DataAcess.Connect.GetTable(sqlten_tk);
        if (dtten_tk != null && dtten_tk.Rows.Count > 0)
            ten_tk = dtten_tk.Rows[0]["tentaikhoan"].ToString();       
        
        //lay so du dau ky
        DataTable dtdk = SoDuDauKy(strTK);
        if (dtdk != null && dtdk.Rows.Count > 0)
        {

            no_dk = dtdk.Rows[0]["du_no0"].ToString();
            co_dk = dtdk.Rows[0]["du_co0"].ToString();
        }
        
        //no_dk == "" ? DBNull.Value : no_dk;
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/KTTH_SoChiTietTaiKhoan.rpt"));//file:///E:\PHAN MEM QUAN LY\quanlythuoc\report\toathuocnguoidung.rpt        
        DataTable dts = LoadSoChiTietTK(strTK);        
        crystalReport.SetDataSource(dts);

        crystalReport.SetParameterValue("@du_no_dk", no_dk == "" ? "0" : no_dk);
        crystalReport.SetParameterValue("@du_co_dk", co_dk == "" ? "0" : co_dk);
        crystalReport.SetParameterValue("@tai_khoan", strTK);
        crystalReport.SetParameterValue("@ten_tk", ten_tk);

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
        //lây tên giám đốc,....      
        DataTable dtten = new DataTable();
        dtten = mdlCommonFunction.thamsotuychon();
        if (dtten.Rows.Count >= 1)
        {
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["quyet_dinh"]).Text = dtten.Rows[1][1].ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[2][1].ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["giam_doc"]).Text = dtten.Rows[3][1].ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["nguoi_lap_phieu"]).Text = dtten.Rows[5][1].ToString();
        }
    }
    private DataTable LoadSoChiTietTK (string strTK)
    {
        string sql ;        
        DataTable dtSRC = new DataTable();
        dtSRC = null;
        sql = "select ma_ct,ngay_lap_ct,tai_khoan,tai_khoan_du,ps_no,ps_co,dien_giai from so_cai ";
        sql += " where (ngay_lap_ct between '"+ StaticData.CheckDate_kt(txtNgay.Text)+ "' and '"+ StaticData.CheckDate_kt(txtDenNgay.Text)+"') and tai_khoan like '"+strTK+"%'";
        dtSRC =  DataAcess.Connect.GetTable(sql);       
        return dtSRC;
    }
    private DataTable SoDuDauKy( string tk)
    {
        DataTable dtts = mdlCommonFunction.thamsotuychon();
        string ngaydaunam = StaticData.CheckDate_kt(dtts.Rows[7][1].ToString());
        string sql = "Exec spSoChiTietTaiKhoan_NKC '"+StaticData.CheckDate_kt(txtNgay.Text)+"','"+StaticData.CheckDate_kt(txtDenNgay.Text)+"','"+ngaydaunam+"','"+tk+"'";
        DataTable dtdk = DataAcess.Connect.GetTable(sql);
        return dtdk;
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

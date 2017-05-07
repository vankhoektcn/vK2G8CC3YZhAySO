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

public partial class KTTH_ChungTuGhiSo : System.Web.UI.Page
{
    
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTaiKhoan.Text = "111";
           // load();
        }
        load();
        
    }
    void load()
    {               
        //no_dk == "" ? DBNull.Value : no_dk;
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/KTTH_ChungTuGhiSo.rpt"));//file:///E:\PHAN MEM QUAN LY\quanlythuoc\report\toathuocnguoidung.rpt        
        DataTable dts = LoadSoChiTietTK();        
        crystalReport.SetDataSource(dts);
        crystalReport.SetParameterValue("@tungay", txtNgay.Text);
        crystalReport.SetParameterValue("@denngay", txtDenNgay.Text);
        crystalReport.SetParameterValue("@taikhoan", txtTaiKhoan.Text);
        crystalReport.SetParameterValue("@taikhoanco", txtTaiKhoanCo.Text);
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
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[2][1].ToString();         
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["nguoi_lap_phieu"]).Text = dtten.Rows[5][1].ToString();
        }
    }
    private DataTable LoadSoChiTietTK ()
    {
        string sql="" ;                               
        if (txtTaiKhoan.Text != "")
        {
            sql = "select ma_ct,ngay_lap_ct,tai_khoan,tai_khoan_du,ps_no,ps_co,dien_giai from so_cai ";
            sql += " where (ngay_lap_ct between '" + StaticData.CheckDate_kt(txtNgay.Text) + "' and '" + StaticData.CheckDate_kt(txtDenNgay.Text) + "') and tai_khoan like '" + txtTaiKhoan.Text + "%'";
            sql += " and ps_no<>0";
            sql += " order by ngay_lap_ct, ma_ct";
        }
        else
            if (txtTaiKhoanCo.Text != "")
            {
                sql = "select ma_ct,ngay_lap_ct,tai_khoan_du=tai_khoan,tai_khoan=tai_khoan_du,ps_no,ps_co,dien_giai from so_cai ";
                sql += " where (ngay_lap_ct between '" + StaticData.CheckDate_kt(txtNgay.Text) + "' and '" + StaticData.CheckDate_kt(txtDenNgay.Text) + "') and tai_khoan like '" + txtTaiKhoanCo.Text + "%'";
                sql += " and ps_co<>0";
                sql += " order by ngay_lap_ct, ma_ct";
            }
            else
            {
                sql = "select ma_ct,ngay_lap_ct,tai_khoan,tai_khoan_du,ps_no,ps_co,dien_giai from so_cai ";
                sql += " where (ngay_lap_ct between '" + StaticData.CheckDate_kt(txtNgay.Text) + "' and '" + StaticData.CheckDate_kt(txtDenNgay.Text) + "') and tai_khoan like '111%'";
                sql += " and ps_no<>0";
                sql += " order by ngay_lap_ct, ma_ct";
            }
        DataTable dtSRC = new DataTable();
        dtSRC =  DataAcess.Connect.GetTable(sql);       
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
        string tkno = "";
        string tkco = "";
        tkno = txtTaiKhoan.Text;
        tkco = txtTaiKhoanCo.Text;
        if (tkno == "" && tkco == "")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn chọn tài khoản!");
            txtTaiKhoan.Text = "111";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "window.location.href('KTTH_ChungTuGhiSo.aspx')", true);
        }
        else
            if (tkno != "" && tkco != "")
            {
                StaticData.MsgBox(this, "Bạn chỉ chọn tài khoản nợ hoặc tài khoản có!");
                txtTaiKhoan.Text = "111";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "window.location.href('KTTH_ChungTuGhiSo.aspx')", true);
            }
            else
                load();
    }
}

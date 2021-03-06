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

public partial class ketoan_KTTH_NhatKyThuTien : System.Web.UI.Page
{
    string strtungay = "", strdenngay = "", sqltktm = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            sqltktm = "select taikhoan from danhmuctk where taikhoan='111' or taikhoan='112'";
            DataTable dt = new DataTable();
            dt = DataAcess.Connect.GetTable(sqltktm);
            StaticData.FillCombo(ddl_tk, dt, "taikhoan", "taikhoan", "Chọn tài khoản");
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
            load();
    }
    void load()
    {
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTH_NhatKyThuTien.rpt"));
        DataTable dt = new DataTable();
        dt = loadsonhatkythutien();
        crystalreport.SetDataSource(dt);
        crystalreport.SetParameterValue("tungay", txtNgay.Text);
        crystalreport.SetParameterValue("denngay", txtDenNgay.Text);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        DataTable dtcty = mdlCommonFunction.congty();
        if (dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();
        }
        //lây tên giám đốc,....      
        DataTable dtten = new DataTable();
        dtten = mdlCommonFunction.thamsotuychon();
        if (dtten.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["quyet_dinh"]).Text = dtten.Rows[1][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[2][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc"]).Text = dtten.Rows[3][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu"]).Text = dtten.Rows[5][1].ToString();
        }
    }
    private DataTable loadsonhatkythutien()
    {
        string taikhoan = "";
        string strsql = "";
        taikhoan = ddl_tk.Text;       
            strsql = "select ma_ct,ngay_lap_ct,dien_giai,tai_khoan,tai_khoan_du,ps_no from so_cai ";
            strsql = strsql + " where ma_ct like 'PT%' and ps_no<>0 and (convert(varchar,ngay_lap_ct,111)>='" + StaticData.CheckDate_kt(txtNgay.Text) + "' and convert(varchar,ngay_lap_ct,111)<='" + StaticData.CheckDate_kt(txtDenNgay.Text) + "')";
            strsql += " and tai_khoan like '"+ddl_tk.Text.Trim()+"%'";
            strsql = strsql + " order by ngay_lap_ct,ma_ct";        
        DataTable dtPT = new DataTable();
        dtPT = DataAcess.Connect.GetTable(strsql);
        return dtPT;
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalreport);
    }
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalreport);
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
        if (ddl_tk.Text.Equals("0"))
        {
            StaticData.MsgBox(this, "Bạn chưa chọn tài khoản!");
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "gygy", "window.location.href('KTTH_NhatKyThuTien.aspx')", true);            
            //Response.Redirect("KTTH_NhatKyThuTien.aspx");
        }
        else
            load();
    }
}

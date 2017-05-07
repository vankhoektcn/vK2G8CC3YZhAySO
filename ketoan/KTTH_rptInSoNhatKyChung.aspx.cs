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
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

public partial class ketoan_KTTH_rptInSoNhatKyChung : System.Web.UI.Page
{
    string strtungay = "", strdenngay = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strtungay = Request.QueryString["tungay"];
        strdenngay = Request.QueryString["denngay"];
        if (!IsPostBack)
        {
            load(strtungay, strdenngay);
        }
        else
            load(strtungay, strdenngay);        
    }   
    void load(string tungay,string denngay)
    {
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTH_SoNhatKyChung.rpt"));
        DataTable dt = new DataTable();
        dt = loadsonhatkychung(tungay, denngay);         
        crystalreport.SetDataSource(dt);
        crystalreport.SetParameterValue("tungay",tungay);
        crystalreport.SetParameterValue("denngay",denngay);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();                
        DataTable dtcty=mdlCommonFunction.congty();
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
    private DataTable loadsonhatkychung(string tungay, string denngay)
    {
        string strsql = "";
        if (tungay != "" && denngay != "")
        {
            strsql = "select ma_ct,ngay_lap_ct,dien_giai,tai_khoan,ps_no,ps_co from so_cai ";
            strsql = strsql + " where convert(varchar,ngay_lap_ct,111)>='" + StaticData.CheckDate_kt(tungay) + "' and convert(varchar,ngay_lap_ct,111)<='" + StaticData.CheckDate_kt(denngay) + "'";
            strsql = strsql + " order by ngay_lap_ct";
        }
        else            
        {
            strsql = "select ma_ct,ngay_lap_ct,dien_giai,tai_khoan,ps_no,ps_co from so_cai ";            
            strsql = strsql + " order by ngay_lap_ct";
        }
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
    
    
}

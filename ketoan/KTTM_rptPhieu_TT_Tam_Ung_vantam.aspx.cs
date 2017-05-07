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

public partial class ketoan_KTTM_rptPhieu_Chi : System.Web.UI.Page
{
    string strsophieu = "", strngaychi = "", strmanv = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strsophieu = Request.QueryString["so_phieu_chi"];
        strngaychi = Request.QueryString["ngay_chi"];
        strmanv = Request.QueryString["ma_nv"];                
        if (!IsPostBack)
        {
            load(strsophieu, strngaychi, strmanv);
        }
        else
            load(strsophieu, strngaychi, strmanv);

    }
    
    void load(string phieu_tt, string ngay_tt,string ma_nv)
    {
        //add ten nhan vien phong ban vao report
        string sql = "";
        string tennv = "";
        string phongban = "";
        sql = "select top(1) tennhacungcap,diachi from  nhacungcap where manhacungcap='" + ma_nv.Trim() + "'";
        DataTable dtnv = new DataTable();
        dtnv = DataAcess.Connect.GetTable(sql);
        if (dtnv.Rows.Count > 0 && dtnv != null)
        {
            tennv = dtnv.Rows[0]["tennhacungcap"].ToString();
            phongban = dtnv.Rows[0]["diachi"].ToString();
        }
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTM_rptPhieu_TT_Tam_Ung.rpt"));
        DataTable dt = new DataTable();
        dt = loadphieu_TT(phieu_tt, ngay_tt, ma_nv);                
        crystalreport.SetDataSource(dt);
        crystalreport.SetParameterValue("so_phieu", phieu_tt);
        crystalreport.SetParameterValue("ngay_tt", ngay_tt);
        crystalreport.SetParameterValue("tennhanvien", tennv);
        crystalreport.SetParameterValue("phongban",phongban);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        
        string sql1 = "select ten_cty,diachi from tieudecty";
        DataTable dtcty = new DataTable();        
        dtcty = DataAcess.Connect.GetTable(sql1);
        if (dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty1"]).Text = dtcty.Rows[0]["ten_cty"].ToString();               
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi1"]).Text = dtcty.Rows[0]["diachi"].ToString();   
        }
        ////lây tên giám đốc,....
        //string sql_lay_ten = "select tham_so,gia_tri from tham_so where tham_so='ho_ten_giam_doc' or tham_so='ho_ten_ke_toan_truong' or tham_so='ho_ten_thu_quy' or tham_so='ho_ten_nguoi_lap_phieu'";
        //DataTable dtten = new DataTable();        
        //dtten = DataAcess.Connect.GetTable(sql_lay_ten);
        //if (dtten.Rows.Count >= 1)
        //{
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[0][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc"]).Text = dtten.Rows[1][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["thu_quy"]).Text = dtten.Rows[2][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu"]).Text = dtten.Rows[3][1].ToString();

        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong1"]).Text = dtten.Rows[0][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc1"]).Text = dtten.Rows[1][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["thu_quy1"]).Text = dtten.Rows[2][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu1"]).Text = dtten.Rows[3][1].ToString();   
        //}
    }
    private DataTable loadphieu_TT(string so_phieu, string ngay_tt,string ma_nv)
    {
        string strsql = "";
        strsql = "exec [sp_rptThanhToanTamUng] '"+so_phieu+"','"+StaticData.CheckDate_kt(ngay_tt)+"','"+ma_nv+"'";
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

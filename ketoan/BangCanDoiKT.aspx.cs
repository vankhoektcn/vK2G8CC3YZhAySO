using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Data.SqlClient;

using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;

public partial class ketoan_BangCanDoiKT : System.Web.UI.Page
{
    #region "Variables"
    //SqlConnection Conn = new SqlConnection();
    //string strSearch = "";

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {           
            txtdateend.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdatestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            load();
        }
    }    
    
    #region Xu ly su kien lay du lieu len report
    DataTable loaddetail()
    {
        DataTable dt = new DataTable();
        string sql1="",sql2="";
        //lấy ngày đầu năm tài chính
        //string sqlndn = "select gia_tri from tham_so where tham_so='ngay_dau_nam_tai_chinh'";
        //DataTable dtndn = new DataTable();
        //dtndn = DataAcess.Connect.GetTable(sqlndn);
        //string ngay_dau_nam = dtndn.Rows[0]["gia_tri"].ToString();
        DataTable dtts = mdlCommonFunction.thamsotuychon();
        string ngay_dau_nam = StaticData.CheckDate_kt(dtts.Rows[7][1].ToString());
        //dtndn.Dispose();
        //--------//---------//----------
        sql1 = "exec spBang_Can_Doi_KT_Theo_Quy'"+ngay_dau_nam+"','" +StaticData.CheckDate_kt(txtdatestart.Text) +"','"+ StaticData.CheckDate(txtdateend.Text) + "'";        
        sql2 = "select chi_tieu,ma_so,thuyet_minh,so_cuoi_nam,so_dau_nam,bold from candoikt";
        //DataAcess.Connect.ExecSQL(sql1);        
        DataAcess.Connect.ExecSQL(sql1);
        dt = DataAcess.Connect.GetTable(sql2);
        //DataTable dt = mdlCommonFunction.LoadDataTable(sql, conn);
        return dt;        
    }
    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        load();
    }   
    void load()
    {        
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/BangCanDoiKeToan.rpt"));
        //crystalReport.SetDatabaseLogon(UID, PSW, "@" + server, database);
        crystalReport.SetDataSource(loaddetail());
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
        DateTime  d =Convert.ToDateTime(StaticData.CheckDate(txtdateend.Text));        
        
        crystalReport.SetParameterValue("ngay", d.ToString("dd"));
        crystalReport.SetParameterValue("thang",d.ToString("MM"));
        crystalReport.SetParameterValue("nam",d.ToString("yyyy"));
        
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
    #endregion 
}


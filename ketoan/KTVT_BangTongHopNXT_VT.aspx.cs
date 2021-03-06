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

public partial class ketoan_KTVT_BangTongHopNXT_Vt : System.Web.UI.Page
{
    #region "Variables"
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        // Page_Init();
        if (!IsPostBack)
        {
            txtdatestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdateend.Text = DateTime.Now.ToString("dd/MM/yyyy");     
        }
        else
        {
            load();
        }
    }   
    #region Xu ly su kien lay du lieu len report
    DataTable loaddetail()
    {        
        string sql = "";                                      
        sql="exec spTong_Hop_NXT_VT '"+""+"','"+""+"','"+txtTaiKhoan.Text+"','"+StaticData.CheckDate(txtdatestart.Text)+"','"+ StaticData.CheckDate(txtdateend.Text)+" 23:59:59','01/01/2011'";        
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;
    }

    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        load();
    }    
    void load()
    {               
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/KTVT_rptTongHopNXT_vt.rpt"));        
        crystalReport.SetDataSource(loaddetail());
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
        crystalReport.SetParameterValue("tu_ngay", txtdatestart.Text);
        crystalReport.SetParameterValue("den_ngay",txtdateend.Text);
        DataTable dts = loaddetail();        
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



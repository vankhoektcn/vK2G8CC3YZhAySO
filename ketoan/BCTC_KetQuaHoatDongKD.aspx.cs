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

public partial class BCTC_KetQuaHoatDongKD : System.Web.UI.Page
{
    #region "Variables"
    SqlConnection Conn = new SqlConnection();
    //string strSearch = "";

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
        DataTable dt = new DataTable();
        string sql1 = "", sql2 = "";       
        //--------//---------//---------
        sql1 = "exec spKTTC_KQHDKD '" + StaticData.CheckDate_kt(txtdatestart.Text)+ "','" + StaticData.CheckDate_kt(txtdateend.Text) + "'";
        sql2 = "select ChiTieu,MaSo,ThuyetMinh,SoThucHien,SoKyTruoc from KQHoatDongKD";      
        DataAcess.Connect.ExecSQL(sql1);
        dt = DataAcess.Connect.GetTable(sql2);       
        return dt;        
    }

    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        load();
    }

    //string UID = "";
    //string PSW = "";
    void load()
    {
        
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/BCTC_KQHDKD.rpt"));
        //crystalReport.SetDatabaseLogon(UID, PSW, "@" + server, database);
        crystalReport.SetDataSource(loaddetail());
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
        crystalReport.SetParameterValue("tu_ngay", txtdatestart.Text);
        crystalReport.SetParameterValue("den_ngay",txtdateend.Text);
        DataTable dts = loaddetail();       
        if (dts != null && dts.Rows.Count > 0)
        {
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
    #endregion
    }
}


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

public partial class ketoan_BCTC_BangCanDoi_TK : System.Web.UI.Page
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
        string sql = "";
        DataTable dtts = mdlCommonFunction.thamsotuychon();
        string ngay_dau_nam = StaticData.CheckDate_kt(dtts.Rows[7][1].ToString());
        sql = "exec spBangCanDoi_TaiKhoan2 '"+ngay_dau_nam+"','" + StaticData.CheckDate_kt(txtdatestart.Text) + "','" + StaticData.CheckDate_kt(txtdateend.Text) + " 23:59:59'";
        //dt = mdlCommonFunction.LoadDataTable(sql, conn);             
        dt = DataAcess.Connect.GetTable(sql);

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
        ////string strAccessConn = DataAcess.Connect.GetConnectionString();
        ////string[] tes = strAccessConn.Split(';');
        ////string[] arrs = tes[1].Split('=');
        ////string[] arrd = tes[0].Split('=');
        ////string[] arrU = tes[2].Split('=');
        ////if (arrU[1].ToString() == "True")
        ////{
        ////    //string UIDs = ConfigurationManager.AppSettings.Get("UID");
        ////    //string PSWs = ConfigurationManager.AppSettings.Get("PSW");
        ////    //UID = data.Decrypt(data.unescape(UIDs));
        ////    //PSW = data.Decrypt(data.unescape(PSWs));
        ////}
        ////else if (tes[3].ToString() != "" || tes[3].ToString() != null)
        ////{
        ////    //string[] arrp = tes[3].Split('=');
        ////    //UID = arrU[1].ToString();
        ////    //PSW = arrp[1].ToString();
        ////}
        ////string server = arrs[1].ToString();
        ////string database = arrd[1].ToString();
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/BangCanDoiTK.rpt"));
        //crystalReport.SetDatabaseLogon(UID, PSW, "@" + server, database);
        crystalReport.SetDataSource(loaddetail());
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
        crystalReport.SetParameterValue("tu_ngay", txtdatestart.Text);
        crystalReport.SetParameterValue("den_ngay",txtdateend.Text);
        DataTable dts = loaddetail();
        double dblDKNo = 0, dblDKCo = 0, dblPSNo = 0, dblPSCo = 0, dblCKNo = 0, dblCKCo = 0;
        if (dts != null && dts.Rows.Count > 0)
        {
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                if (dts.Rows[i]["chi_tiet"].ToString() == "1")
                {
                    dblDKNo += Convert.ToDouble(dts.Rows[i]["du_no0"]);
                    dblDKCo += Convert.ToDouble(dts.Rows[i]["du_co0"]);
                    dblPSNo += Convert.ToDouble(dts.Rows[i]["ps_no"]);
                    dblPSCo += Convert.ToDouble(dts.Rows[i]["ps_co"]);
                    dblCKNo += Convert.ToDouble(dts.Rows[i]["no_ck"]);
                    dblCKCo += Convert.ToDouble(dts.Rows[i]["co_ck"]);
                }
            }
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["du_no0"]).Text = mdlCommonFunction.FormatNumber(dblDKNo, false).ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["du_co0"]).Text = mdlCommonFunction.FormatNumber(dblDKCo, false).ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["ps_no"]).Text = mdlCommonFunction.FormatNumber(dblPSNo, false).ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["ps_co"]).Text = mdlCommonFunction.FormatNumber(dblPSCo, false).ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["no_ck"]).Text = mdlCommonFunction.FormatNumber(dblCKNo, false).ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["co_ck"]).Text = mdlCommonFunction.FormatNumber(dblCKCo, false).ToString();
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
}


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
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using System.Data.SqlClient;

public partial class rptnhanvienungluong : Page
{
    SqlConnection conn = DataAcess.Connect.Conn;
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlthang.SelectedIndex = ddlthang.Items.IndexOf(ddlthang.Items.FindByValue(DateTime.Now.Month.ToString()));
            ddlnam.SelectedIndex = ddlnam.Items.IndexOf(ddlnam.Items.FindByValue(DateTime.Now.Year.ToString()));
            LoadReportInFo();
        }
        else
        {
            LoadReportInFo();
        }        
    }

    string UID = "";
    string PSW = "";
    void LoadReportInFo()
    {
       
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../quanlynhansu/rptnhanvienungluong.rpt"));
       
        crystalReport.SetDataSource(LoadBangUngLuong());
        CRV.ReportSource = crystalReport;
        CRV.DataBind();
        ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtthangnam"]).Text = ddlthang.SelectedValue.ToString() + " / " + ddlnam.SelectedValue.ToString();
    }
    private DataTable LoadBangUngLuong()
    {
        DataTable dtSRC = new DataTable();
        int thang = StaticData.ParseInt(ddlthang.SelectedValue.ToString());
        int nam = StaticData.ParseInt(ddlnam.SelectedValue.ToString());
        try
        {
            SqlDataAdapter adt = new SqlDataAdapter();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            System.Data.SqlClient.SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "danhsachungluong";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
            cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

            cmd.ExecuteNonQuery();
            adt = new SqlDataAdapter(cmd);
            adt.Fill(dtSRC);
        }
        catch (Exception)
        {
        }
        return dtSRC;
    }
    protected void CRV_Unload(object sender, EventArgs e)
    {
        crystalReport.Close();
        crystalReport.Dispose();
        CRV.Dispose();
        GC.Collect();
    }

    protected void form_unload(object sender, EventArgs e)
    {
        crystalReport.Close();
        crystalReport.Dispose();
        crystalReport = null;
        CRV.Dispose();
        CRV = null;
        GC.Collect();
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

    protected void bntxemluong_Click(object sender, EventArgs e)
    {

    }
}

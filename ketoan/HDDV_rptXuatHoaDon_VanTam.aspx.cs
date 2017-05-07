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

public partial class ketoan_HDDV_rptXuatHoaDon :System.Web.UI.Page
{
    string strso_hd = "", strngay_lap_hd = ""; 
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strso_hd = Request.QueryString["so_hoa_don"];
        strngay_lap_hd = Request.QueryString["ngay_lap_hd"];              
        if (!IsPostBack)
        {
            load(strso_hd, strngay_lap_hd);
        }
        else
            load(strso_hd, strngay_lap_hd);
    }
    void load(string sohd, string ngaylaphd)
    {       
        crystalreport = new ReportDocument();                
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/HDDV_rptXuatHoaDon.rpt"));
        DataTable dt = loadhoa_don_dv(sohd, ngaylaphd);            
        crystalreport.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        if (dt.Rows.Count >= 1)
        {
            string str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tong_tien"].ToString());
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = str_so.ToString();
        }         
    }
    private DataTable loadhoa_don_dv(string so_hd, string ngay_lap_hd)
    {
        string strsql = "";
        strsql = "select ngay_lap_hd,ten_kh,ten_nguoi_mua,dia_chi,ma_so_thue,dien_giai,thue_suat,tien,tien_thue,tong_tien ";
        strsql = strsql + " from hoa_don_ban_hang where so_hd='" + so_hd + "' and convert(nchar(10),ngay_lap_hd,103)='" + ngay_lap_hd + "'";        
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

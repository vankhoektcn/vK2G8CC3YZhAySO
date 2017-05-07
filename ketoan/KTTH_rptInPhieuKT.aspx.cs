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

public partial class KTTH_rptInPhieuKT : System.Web.UI.Page
{
    string strsophieu = "", strngaythu = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strsophieu=Request.QueryString["so_phieu_thu"];
        strngaythu = Request.QueryString["ngay_thu"];
        if (!IsPostBack)
        {
            load(strsophieu, strngaythu);
        }
        else
            load(strsophieu, strngaythu);
        
    }
   
    void load(string sphieuthu,string ngaythu)
    {
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTH_rptInPhieuKT.rpt"));
        DataTable dt = new DataTable();
         dt = loadphieu_thu(sphieuthu, ngaythu);
        crystalreport.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        string sqltien = "select sum(ps_no) as tien from phieu_ke_toan a inner join phieu_ke_toan_ct b on a.phieuketoanid=b.phieuketoanid";
        sqltien = sqltien + " where so_phieu='" + sphieuthu + "' and convert(char(10),ngay_lap,103)= '" + ngaythu + "'";
        DataTable dttien = DataAcess.Connect.GetTable(sqltien);
        string str_so = "";
        if (dttien != null && dttien.Rows.Count > 0)
        {
            str_so = new clsDocSo.clsDocSo().ChuyenSo(dttien.Rows[0]["tien"].ToString());
        }
        ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = str_so.ToString() + ".";        
        
        //lay ten, dia chi cong ty
        string sql1 = "select ten_cty,diachi from tieudecty";
        DataTable dtcty = new DataTable();
        dtcty = DataAcess.Connect.GetTable(sql1);
        if (dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();            
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();            
        }
        //lây tên giám đốc,....
        string sql_lay_ten = "select tham_so,gia_tri from tham_so where tham_so='ho_ten_giam_doc' or tham_so='ho_ten_ke_toan_truong' or tham_so='ho_ten_thu_quy' or tham_so='ho_ten_nguoi_lap_phieu'";
        DataTable dtten = new DataTable();
        dtten = DataAcess.Connect.GetTable(sql_lay_ten);
        if (dtten.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[0][1].ToString();            
        }
    }
    private DataTable loadphieu_thu(string sophieuthu, string ngaythu)
    {
        string strsql = "";
        strsql = "select so_phieu,ngay_lap,dien_giai,tai_khoan,ps_no,ps_co ";
        strsql = strsql + " from phieu_ke_toan a inner join phieu_ke_toan_ct b on a.phieuketoanid=b.phieuketoanid ";
        strsql = strsql+" where so_phieu='"+ sophieuthu+ "' and convert(char(10),ngay_lap,103)= '"+ngaythu +"'" ;
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

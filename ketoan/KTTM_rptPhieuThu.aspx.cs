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

public partial class ketoan_KTTM_rptPhieuThu : System.Web.UI.Page
{
    string strsophieu = "", strngaythu = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strsophieu=Request.QueryString["so_phieu_thu"];
        strngaythu = Request.QueryString["ngay_thu"];
        string soctgoc = Request.QueryString["soctgoc"];
        string chungtugoc = Request.QueryString["chungtugoc"];
        if (!IsPostBack)
        {
            load(strsophieu, strngaythu,soctgoc,chungtugoc);
        }
        else
            load(strsophieu, strngaythu,soctgoc,chungtugoc);
        
    }
   
    void load(string sphieuthu,string ngaythu,string soctgoc, string chungtugoc)
    {
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTM_rptphieu_thu.rpt"));
        DSrptPhieuThu ds = new DSrptPhieuThu();
        DataTable dt = ds.Tables["dsrptPhieuThu"];
         dt = loadphieu_thu(sphieuthu, ngaythu);
        crystalreport.SetDataSource(dt);
        crystalreport.SetParameterValue("@soctgoc",soctgoc);
        crystalreport.SetParameterValue("@chungtugoc",chungtugoc);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        string str_so = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            //str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tien"].ToString());
            str_so = mdlCommonFunction.ConvertMoneyToText(dt.Rows[0]["tien"].ToString());
        }
        ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = "(" + str_so.ToString() + ")";
        //((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu1"]).Text = "(" + str_so.ToString() + ")";

        //in ở góc 1 no nhiều co
        string sql = "select so_phieu_thu,tk_co from phieu_thu_ct where (isdelete is null or isdelete=0) and so_phieu_thu='" + sphieuthu + "'";
        DataTable dttkco = new DataTable();        
        dttkco = DataAcess.Connect.GetTable(sql);
        if (dttkco != null && dttkco.Rows.Count > 0)
        {
            int a = dttkco.Rows.Count - 1;
            if (a + 1 >= 1)
            {
                for (int i = 0; i <= a; i++)
                {
                    ((TextObject)crystalreport.ReportDefinition.ReportObjects["tkco" + i]).Text = dttkco.Rows[i]["tk_co"].ToString();
                    //((TextObject)crystalreport.ReportDefinition.ReportObjects["tkco1" + i]).Text = dttkco.Rows[i]["tk_co"].ToString();
                }
            }
        }
        //lay ten, dia chi cong ty
        string sql1 = "select ten_cty,diachi from tieudecty";
        DataTable dtcty = new DataTable();
        dtcty = DataAcess.Connect.GetTable(sql1);
        if (dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty1"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi1"]).Text = dtcty.Rows[0]["diachi"].ToString();
        }
        //lây tên giám đốc,....
        string sql_lay_ten = "select tham_so,gia_tri from tham_so where tham_so='ho_ten_giam_doc' or tham_so='ho_ten_ke_toan_truong' or tham_so='ho_ten_thu_quy' or tham_so='ho_ten_nguoi_lap_phieu'";
        DataTable dtten = new DataTable();
        dtten = DataAcess.Connect.GetTable(sql_lay_ten);
        if (dtten.Rows.Count >= 1)
        {
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[0][1].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc"]).Text = dtten.Rows[1][1].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["thu_quy"]).Text = dtten.Rows[2][1].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu"]).Text = dtten.Rows[3][1].ToString();

            //((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong1"]).Text = dtten.Rows[0][1].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc1"]).Text = dtten.Rows[1][1].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["thu_quy1"]).Text = dtten.Rows[2][1].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu1"]).Text = dtten.Rows[3][1].ToString();
        }
    }
    private DataTable loadphieu_thu(string sophieuthu, string ngaythu)
    {
        string strsql = "";
        strsql = "select so_phieu_thu,tk_no,ngay_thu,nguoi_nop,dien_giai,tien,tenkhachhang,diachi from";
        strsql = strsql + " phieu_thu a left join (select * from (select makhachhang,tenkhachhang,diachi from khachhang union select mabenhnhan,tenbenhnhan,diachi from benhnhan)n where makhachhang is not null) b on a.ma_kh=b.makhachhang";
        strsql = strsql + " where (isdelete is null or isdelete=0) and so_phieu_thu='" + sophieuthu + "' and convert(char(10),ngay_thu,103)= '" + ngaythu + "'";
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

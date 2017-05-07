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
    string strsophieu = "", strngaychi = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strsophieu = Request.QueryString["so_phieu_chi"];
        strngaychi = Request.QueryString["ngay_chi"];
        string soctgoc=Request.QueryString["soctgoc"];
        string chungtugoc = Request.QueryString["chungtugoc"];
        if (!IsPostBack)
        {
            load(strsophieu, strngaychi,soctgoc,chungtugoc);
        }
        else
            load(strsophieu, strngaychi,soctgoc,chungtugoc);

    }
    
    void load(string sphieuchi, string ngaychi,string soctgoc, string chungtugoc)
    {        
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTM_rptPhieu_Chi.rpt"));
        Ds_rptPhieuChi dspc = new Ds_rptPhieuChi();
        DataTable dt = dspc.Tables["rptPhieu_Chi"];
        dt = loadphieu_chi(sphieuchi, ngaychi);
        crystalreport.SetDataSource(dt);
        crystalreport.SetParameterValue("@soctgoc", soctgoc);
        crystalreport.SetParameterValue("@chungtugoc", chungtugoc);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        string str_so = "";
        if (dt.Rows.Count >= 1)
        {
            //string str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tien"].ToString());
            str_so = mdlCommonFunction.ConvertMoneyToText(dt.Rows[0]["tien"].ToString());
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = "(" + str_so.ToString() + ")";
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu1"]).Text = "(" + str_so.ToString() + ")";
        }
        //in ở góc 1 có nhiều nợ
        string sql = "select so_phieu_chi,tk_no from phieu_chi_ct where (isdelete is null or isdelete=0) and so_phieu_chi='" + sphieuchi + "'";
        DataTable dttkno = new DataTable();        
        dttkno = DataAcess.Connect.GetTable(sql);
        int a = dttkno.Rows.Count - 1;    

        if (a+1 >= 1)
        {
            for (int i = 0; i <= a; i++)
            {
                ((TextObject)crystalreport.ReportDefinition.ReportObjects["tkno" + i]).Text = dttkno.Rows[i]["tk_no"].ToString();
                //((TextObject)crystalreport.ReportDefinition.ReportObjects["tkno1" + i]).Text = dttkno.Rows[i]["tk_no"].ToString();
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
            ////((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi1"]).Text = dtcty.Rows[0]["diachi"].ToString();   
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
    private DataTable loadphieu_chi(string sophieuchi, string ngaychi)
    {
        string strsql = "";
        strsql = "select so_phieu_chi,ngay_chi,tk_co,nguoi_giao,dien_giai,tien,tennhacungcap,diachi";
        strsql = strsql + " from phieu_chi a left join nhacungcap b on a.ma_ncc=b.manhacungcap ";
        strsql = strsql + " where (isdelete is null or isdelete=0) and so_phieu_chi='" + sophieuchi + "' and convert(char(10),ngay_chi,103)= '" + ngaychi + "'";
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

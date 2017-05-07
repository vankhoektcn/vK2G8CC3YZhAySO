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

public partial class ketoan_KTVT_rptPhieu_Chi : System.Web.UI.Page
{
    string strsophieu = "", strngaychi = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strsophieu = Request.QueryString["so_phieu_chi"];
        strngaychi = Request.QueryString["ngay_chi"];
        load(strsophieu, strngaychi);

    }
    
    void load(string sphieuchi, string ngaychi)
    {        
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTM_rptPhieu_Chi.rpt"));
        //Ds_rptPhieuChi dspc = new Ds_rptPhieuChi();
        //DataTable dt = dspc.Tables["rptPhieu_Chi"];
        DataTable dt = new DataTable();
        dt = loadphieu_chi(sphieuchi, ngaychi);
        crystalreport.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        if (dt.Rows.Count >= 1)
        {
            string str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tien"].ToString());
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = "(" + str_so.ToString() + ")";
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu1"]).Text = "(" + str_so.ToString() + ")";
        }

        //in ở góc 1 có nhiều nợ
        string sql = "select b.tk_no from phieu_nhap_vt a inner join phieu_nhap_vt_ct b on a.phieu_nhap_id=b.phieu_nhap_id where a.so_phieu='" + sphieuchi + "'";
        DataTable dttkno = new DataTable();
        dttkno = DataAcess.Connect.GetTable(sql);        
        int a = dttkno.Rows.Count - 1;    

        if (a+1 >= 1)
        {
            for (int i = 0; i <= a; i++)
            {
                ((TextObject)crystalreport.ReportDefinition.ReportObjects["tkno" + i]).Text = dttkno.Rows[i]["tk_no"].ToString();
            }
        }
        //lay ten, dia chi cong ty
        string sql1 = "select ten_cty,diachi from tieudecty";
        DataTable dtcty = new DataTable();
        dtcty = DataAcess.Connect.GetTable(sql1);
        if (dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty1"]).Text = dtcty.Rows[0]["ten_cty"].ToString();   
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi1"]).Text = dtcty.Rows[0]["diachi"].ToString();   
        }
        //lây tên giám đốc,....
        string sql_lay_ten = "select tham_so,gia_tri from tham_so where tham_so='ho_ten_giam_doc' or tham_so='ho_ten_ke_toan_truong' or tham_so='ho_ten_thu_quy' or tham_so='ho_ten_nguoi_lap_phieu'";
        DataTable dtten = new DataTable();
        dtten = DataAcess.Connect.GetTable(sql_lay_ten);
        if (dtten.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[0][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc"]).Text = dtten.Rows[1][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["thu_quy"]).Text = dtten.Rows[2][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu"]).Text = dtten.Rows[3][1].ToString();

            ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong1"]).Text = dtten.Rows[0][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc1"]).Text = dtten.Rows[1][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["thu_quy1"]).Text = dtten.Rows[2][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu1"]).Text = dtten.Rows[3][1].ToString();   
        }
    }
    private DataTable loadphieu_chi(string sophieuchi, string ngaychi)
    {
        string strsql = "";
        strsql = "select so_phieu as so_phieu_chi,ngay_nhap as ngay_chi,tk_co,nguoilienhe as nguoi_giao,dien_giai,tong_tien as tien,ten_ncc as tennhacungcap,diachi ";
        strsql = strsql + " from phieu_nhap_vt a inner join phieu_nhap_vt_ct b on a.phieu_nhap_id = b.phieu_nhap_id inner join nhacungcap c on a.ma_ncc=c.manhacungcap ";
        strsql = strsql + " where so_phieu='" + sophieuchi + "' and convert(char(10),ngay_nhap,103)= '" + ngaychi + "'";
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

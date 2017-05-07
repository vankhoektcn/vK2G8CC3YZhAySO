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

public partial class ketoan_KTTH_rptPhieu_tong_hop : System.Web.UI.Page
{
    string strsophieu = "", strngaylap = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strsophieu = Request.QueryString["so_phieu_kt"];
        strngaylap = Request.QueryString["ngay_lap"];        
        if (!IsPostBack)
        {
            load(strsophieu, strngaylap);
        }
        else
            load(strsophieu, strngaylap);

    }
    
    void load(string sphieuchi, string ngaychi)
    {        
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTH_rptPhieuTongHop.rpt"));
        DataTable dt = new DataTable();
        dt = loadphieu_chi(sphieuchi, ngaychi);
        crystalreport.SetDataSource(dt);        
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        if (dt.Rows.Count >= 1)
        {
            Int32 tongtien = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tongtien += Int32.Parse(dt.Rows[i]["ps_no"].ToString());
            }
            string str_so = new clsDocSo.clsDocSo().ChuyenSo(tongtien.ToString());
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = str_so.ToString();            
        }        
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
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc"]).Text = dtten.Rows[1][1].ToString();            
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu"]).Text = dtten.Rows[3][1].ToString();            
        }
    }
    private DataTable loadphieu_chi(string sophieuchi, string ngaychi)
    {
        string strsql = "";
        strsql = "select a.so_phieu,ngay_lap,ten_don_vi=ten_dt,noi_dung=a.dien_giai,ten_doi_tuong=ten_dt,b.dien_giai, ps_no,tk_no,tk_co ";
        strsql += " from phieu_tong_hop a left join phieu_tong_hop_ct b on a.so_phieu=b.so_phieu ";
        strsql += " left join (select * from(select ma_dt=makhachhang,ten_dt=tenkhachhang,diachi from khachhang union select manhacungcap,tennhacungcap,diachi  from nhacungcap)n where ma_dt is not null) c on b.ma_doi_tuong=c.ma_dt ";
        strsql = strsql + " where a.so_phieu='" + sophieuchi + "' and convert(char(10),ngay_lap,111)= '" + StaticData.CheckDate_kt(ngaychi) + "'";
        DataTable dtPT = new DataTable();
        dtPT = DataAcess.Connect.GetTable(strsql);
        return dtPT;
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalreport);
        crystalreport.Close();
        crystalreport.Dispose();
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

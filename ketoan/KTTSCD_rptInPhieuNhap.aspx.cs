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

public partial class KTTSCD_rptInPhieuNhap : System.Web.UI.Page
{
    string strsophieu = "", strngaythu = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strsophieu=Request.QueryString["so_phieu_nhap"];
        strngaythu = Request.QueryString["ngay_nhap"];
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
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTSCD_rptMauInPhieuNhap.rpt"));
        DataTable dt = new DataTable();
         dt = loadphieu_nhap(sphieuthu, ngaythu);
        crystalreport.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        string sqltien = "select sum(tong_tien) as tien from phieu_nhap_vt a inner join phieu_nhap_vt_ct b on a.phieu_nhap_id=b.phieu_nhap_id";
        sqltien = sqltien + " where so_phieu='" + sphieuthu + "' and convert(char(10),ngay_nhap,103)= '" + ngaythu + "'";
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
        string sql_lay_ten = "select tham_so,gia_tri from tham_so where tham_so='so_quet_dinh_ke_toan' or tham_so='ho_ten_ke_toan_truong'";
        DataTable dtten = new DataTable();
        dtten = DataAcess.Connect.GetTable(sql_lay_ten);
        if (dtten.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[1][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["quyet_dinh_kt"]).Text = dtten.Rows[0][1].ToString();  
        }
    }
    private DataTable loadphieu_nhap(string sophieuthu, string ngaythu)
    {
        string strsql = "";
        strsql = @"select ngay_nhap,so_phieu,ten_nguoi_giao,so_hd,ngay_lap_hd,a.tk_co,d.tenkho,ten_ncc=e.tennhacungcap,b.ma_vt,c.ten_vt,b.tk_no,c.dvt,b.so_luong,b.don_gia,thanhtien=ISNULL(b.so_luong,0)*ISNULL(b.don_gia,0)
                from PHIEU_NHAP_VT a left join PHIEU_NHAP_VT_CT b on a.phieu_nhap_id=b.phieu_nhap_id
                left join DM_VAT_TU_KT c on b.ma_vt=c.ma_vt
                left join khothuoc d on a.idkho=d.idkho
                left join nhacungcap e on a.ma_ncc=e.manhacungcap";
        strsql = strsql + " where so_phieu='" + sophieuthu + "' and convert(char(10),ngay_nhap,103)= '" + ngaythu + "'";
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

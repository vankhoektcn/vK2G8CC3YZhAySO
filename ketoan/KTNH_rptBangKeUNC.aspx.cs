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

public partial class ketoan_KTNH_rptBangKeUNC : System.Web.UI.Page
{    
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoUyNhiemChi = Request["SoUyNhiemChi"];
        string MaNCC = Request["MaNCC"];
        if (!IsPostBack)
        {
            load(TuNgay, DenNgay,SoUyNhiemChi,MaNCC);
        }
        else
            load(TuNgay, DenNgay, SoUyNhiemChi, MaNCC);
    }
   
    void load(string tungay,string denngay,string sounc,string mancc)
    {
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTNH_rptBangKeUNC.rpt"));                         
        DataTable dt=new DataTable ();           
        dt = loadphieu_thu(tungay, denngay, sounc, mancc);
        crystalreport.SetDataSource(dt);
        crystalreport.SetParameterValue("tungay", tungay);
        crystalreport.SetParameterValue("denngay", denngay);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        DataTable dtcty = mdlCommonFunction.congty();
        if (dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();
        }
        //lây tên giám đốc,....      
        DataTable dtten = new DataTable();
        dtten = mdlCommonFunction.thamsotuychon();
        if (dtten.Rows.Count >= 1)
        {            
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[2][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc"]).Text = dtten.Rows[3][1].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu"]).Text = dtten.Rows[5][1].ToString();
        }                     
    }

    private DataTable loadphieu_thu(string TuNgay, string DenNgay, string SoUyNhiemChi, string MaNCC)
    {
        string sql = "select a.so_unc,convert(varchar,ngay_lap_unc,103)ngay_lap,ma_ncc=d.manhacungcap,ten_ncc=tennhacungcap,a.dien_giai,tk_co,nganhang,tien=sum(isnull(b.ps_no,0))+sum(isnull(tien_thue,0)) ";
        sql += "  from uy_nhiem_chi a left join uy_nhiem_chi_ct b on a.so_unc=b.so_unc  left join nhacungcap d on b.ma_ncc=d.manhacungcap left join danhmuctknh c  on a.tk_co=c.taikhoankt ";
        sql += "  where 1=1 ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_lap_unc between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        else
            if (!string.IsNullOrEmpty(TuNgay))
            {
                sql += "    and ngay_lap_unc = '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "'  ";
            }
            else
                if (!string.IsNullOrEmpty(DenNgay))
                {
                    sql += "    and ngay_lap_unc = '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
                }
        if (!string.IsNullOrEmpty(SoUyNhiemChi))
            sql += "    and a.so_unc = '" + SoUyNhiemChi + "'";
        if (!string.IsNullOrEmpty(MaNCC))
            sql += " and d.manhacungcap='" + MaNCC + "'";
        sql += " group by a.so_unc,convert(varchar,ngay_lap_unc,103),tk_co,d.manhacungcap,tennhacungcap,nganhang,a.dien_giai";
        sql += " order by ngay_lap,so_unc,d.manhacungcap";
        DataTable table = DataAcess.Connect.GetTable(sql);
        return table;       
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

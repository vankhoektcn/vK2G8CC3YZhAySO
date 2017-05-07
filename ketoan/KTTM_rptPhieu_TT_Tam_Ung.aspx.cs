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
    string strsophieu = "", strngaychi = "", strmanv = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strsophieu = Request.QueryString["so_phieu_chi"];
        strngaychi = Request.QueryString["ngay_chi"];
        strmanv = Request.QueryString["ma_nv"];                
        if (!IsPostBack)
        {
            load(strsophieu, strngaychi, strmanv);
        }
        else
            load(strsophieu, strngaychi, strmanv);

    }
    
    void load(string phieu_tt, string ngay_tt,string ma_nv)
    {
        //add ten nhan vien phong ban vao report
        string sql = "";
        string tennv = "";
        string phongban = "";
        sql = "select top(1) tennhacungcap,nguoilienhe from  nhacungcap where manhacungcap='" + ma_nv.Trim() + "'";
        DataTable dtnv = new DataTable();
        dtnv = DataAcess.Connect.GetTable(sql);
        if (dtnv.Rows.Count > 0 && dtnv != null)
        {
            tennv = dtnv.Rows[0]["nguoilienhe"].ToString();
            phongban = dtnv.Rows[0]["tennhacungcap"].ToString();
        }
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTM_rptPhieu_TT_Tam_Ung.rpt"));
        DataTable dt = new DataTable();
        dt = loadphieu_TT(phieu_tt.Trim(), ngay_tt, ma_nv.Trim());                
        crystalreport.SetDataSource(dt);
        crystalreport.SetParameterValue("so_phieu", phieu_tt);
        crystalreport.SetParameterValue("ngay_tt", ngay_tt);
        crystalreport.SetParameterValue("tennhanvien", tennv);
        crystalreport.SetParameterValue("phongban",phongban);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        
        string sql1 = "select ten_cty,diachi from tieudecty";
        DataTable dtcty = new DataTable();        
        dtcty = DataAcess.Connect.GetTable(sql1);
        if (dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty1"]).Text = dtcty.Rows[0]["ten_cty"].ToString();               
            //((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi1"]).Text = dtcty.Rows[0]["diachi"].ToString();   
        }
        ////lây tên giám đốc,....
        //string sql_lay_ten = "select tham_so,gia_tri from tham_so where tham_so='ho_ten_giam_doc' or tham_so='ho_ten_ke_toan_truong' or tham_so='ho_ten_thu_quy' or tham_so='ho_ten_nguoi_lap_phieu'";
        //DataTable dtten = new DataTable();        
        //dtten = DataAcess.Connect.GetTable(sql_lay_ten);
        //if (dtten.Rows.Count >= 1)
        //{
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[0][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc"]).Text = dtten.Rows[1][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["thu_quy"]).Text = dtten.Rows[2][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu"]).Text = dtten.Rows[3][1].ToString();

        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["kt_truong1"]).Text = dtten.Rows[0][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["giam_doc1"]).Text = dtten.Rows[1][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["thu_quy1"]).Text = dtten.Rows[2][1].ToString();
        //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["nguoi_lap_phieu1"]).Text = dtten.Rows[3][1].ToString();   
        //}
    }
    private DataTable loadphieu_TT(string so_phieu, string ngay_tt,string ma_nv)
    {
        //lay nhung phieu chi da thanh toan
        string dsphieuchi = "";
        string dsphieuchikq = "";      
        string sqltt = " select dsphieuchi from phieu_tt_tam_ung where dsphieuchi is not null and so_phieu_chi='" + so_phieu.Trim() + "'";
        DataTable dttt = new DataTable();
        dttt = DataAcess.Connect.GetTable(sqltt);
        if (dttt != null && dttt.Rows.Count > 0)
        {
            for (int i = 0; i < dttt.Rows.Count; i++)
            {
                if (dttt.Rows[i]["dsphieuchi"].ToString().Trim() != null)
                    dsphieuchi += dttt.Rows[i]["dsphieuchi"].ToString().Trim() + ",";
            }
            dsphieuchi = dsphieuchi.Substring(0, dsphieuchi.Length - 1);
            string[] listphieuchi = dsphieuchi.Split(',');
            if (listphieuchi.Length > 0)
            {
                for (int j = 0; j < listphieuchi.Length; j++)
                {
                    dsphieuchikq += "a.so_phieu_chi='" + listphieuchi[j] + "' or ";
                }
                dsphieuchikq = dsphieuchikq.Substring(0, dsphieuchikq.Length - 4);
            }
        }
        string strsql = "";
        strsql = " select * from(select so_phieu_chi='',ngay_chi='',ma_ncc='',dien_giai=N'1.Số tạm ứng kỳ trước chưa chi hết',tien_ki_truoc=0,tien_chi=0,tk_no='',nhom=N'I. Số tiền tạm ứng' union all select so_phieu_chi='',ngay_chi='',ma_ncc='',dien_giai=N'2.Số tạm ứng kỳ này',tien_ki_truoc=0,tien_chi=0,tk_no='',nhom=N'I. Số tiền tạm ứng' ";
        strsql += " union all select a.so_phieu_chi,convert(varchar(10),ngay_chi,103)ngay_chi,ma_ncc,dien_giai=N'   - Phiếu chi số: '+a.so_phieu_chi+N' ngày '+convert(varchar(10),ngay_chi,103),tien_ki_truoc=0,sum(tien)tien_chi,tk_no,nhom=N'I. Số tiền tạm ứng' from phieu_chi a left join phieu_chi_ct b on a.so_phieu_chi=b.so_phieu_chi ";
        strsql += " where ma_ncc='"+ma_nv+"' and tk_no like '141%' and "+dsphieuchikq+" group by ma_ncc,tk_no,a.dien_giai,a.so_phieu_chi,convert(varchar(10),ngay_chi,103) ";
        strsql += " union all select a.so_phieu_chi,convert(varchar(10),ngay_chi,103)ngay_chi,ma_ncc,dien_giai=N'   '+b.dien_giai,tien_ki_truoc=0,(sum(isnull(ps_no,0))+sum(isnull(tien_thue,0)))tien_tttu,tk_no,nhom=N'II. Số tiền đã chi:' from phieu_tt_tam_ung a left join phieu_tt_tam_ung_ct b on a.so_phieu_chi=b.so_phieu_chi ";
        strsql += " where ma_ncc='"+ma_nv+"' and tk_co like '141%' and convert(varchar,ngay_chi,111)='"+ StaticData.CheckDate_kt(ngay_tt)+"' and a.so_phieu_chi='"+so_phieu+"' group by ma_ncc,b.tk_no,b.dien_giai,a.so_phieu_chi,convert(varchar(10),ngay_chi,103) ";
        strsql += " union all select so_phieu_chi='',ngay_chi='',ma_ncc='',dien_giai=N'1.Số tạm ứng chi không hết(I-II)',tien_ki_truoc=0,tien_chi=(case when dbo.ft_tienchenhlechtttu('"+so_phieu+"')>0 then dbo.ft_tienchenhlechtttu('"+so_phieu+"') else 0 end),tk_no='',nhom=N'III.Chênh lệch'";
        strsql += " union all select so_phieu_chi='',ngay_chi='',ma_ncc='',dien_giai=N'2.Chi quá số tạm ứng(II-I)',tien_ki_truoc=0,tien_chi=(case when dbo.ft_tienchenhlechtttu('"+so_phieu+"')<0 then -dbo.ft_tienchenhlechtttu('"+so_phieu+"') else 0 end),tk_no='',nhom=N'III.Chênh lệch') m ";
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

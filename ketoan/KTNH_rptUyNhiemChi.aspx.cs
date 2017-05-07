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
    string strso_unc = "", strtk_co = "", strma_ncc = "";
    int giatri = 0;
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {        
        strso_unc = Request.QueryString["so_unc"];
        strtk_co = Request.QueryString["tk_co"];
        strma_ncc = Request.QueryString["mancc"];
        giatri = int.Parse(Request.QueryString["giatri"].ToString());
        if (!IsPostBack)
        {
            load(strso_unc, strtk_co,strma_ncc,giatri);
        }
        else
            load(strso_unc, strtk_co,strma_ncc,giatri);
    }
   
    void load(string sounc,string tkco,string mancc,int stt)
    {
        crystalreport = new ReportDocument();
                   
        if (tkco == "11212" || tkco=="11215")
        {            
            crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/rpt_UNCAgriBank2.rpt"));
            doctienraso(sounc, tkco,mancc,stt, 90);
           
        }
        else if (tkco == "11211")
            {                
                crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/rpt_UNCBIDV.rpt"));
                doctienraso(sounc, tkco,mancc,stt, 64);
            }
            else if(tkco=="11214")
            {                
                crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/rpt_UNCVTB.rpt"));
                doctienraso(sounc, tkco,mancc,stt, 50);
            }
            else if (tkco == "11213")
            {
                crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/rpt_UNCVDB.rpt"));
                doctienraso(sounc, tkco,mancc,stt, 65);
            }
            else
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">alert(\"Không có mẫu Ủy nhiệm chi của ngân hàng này. Vui lòng chọn lại!\");</script>"); 
                return;
            }              
            Ds_rptUNC ds = new Ds_rptUNC();
            DataTable dt = ds.Tables["ds_rptUNC"]; 
            dt = loadphieu_thu(sounc, tkco,mancc,stt);
            crystalreport.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = crystalreport;
            CrystalReportViewer1.DataBind();
                      
        //lay ten, dia chi cong ty
            string sql = "select ten_cty,diachi from tieudecty";
            DataTable dtcty = new DataTable();
            dtcty = DataAcess.Connect.GetTable(sql);            
            if (dtcty.Rows.Count >= 1)
            {
                ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();                
            }                
    }
    private void doctienraso(string so_unc,string tk_co,string ma_ncc,int stt,int kitu)
    {
        DataTable dt = new DataTable();
        dt = loadphieu_thu(so_unc,tk_co,ma_ncc,stt);
        string str_so = "";
        string c1 = "";
        string c2 = "";

        if (dt != null && dt.Rows.Count > 0)
        {
            str_so = mdlCommonFunction.ConvertMoneyToText(dt.Rows[0]["tien"].ToString());
            //str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tien"].ToString());
            if (str_so.Length <= kitu)
            {
                ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = str_so.ToString() + ".";
            }
            else
            {
                c1 = str_so.Substring(0, kitu);
                c2 = str_so.Substring(kitu, str_so.Length - c1.Length);
                //StaticData.MsgBox(this,);
                if (c2.Substring(0, 1) != " ")
                {
                    int i = 1;
                    int a = 0;
                    while (c1.Substring(kitu - i, 1) != " ")
                    {
                        a = i;
                        i++;
                    }
                    c1 = c1.Substring(0, c1.Length - a);
                    c2 = str_so.Substring(c1.Length, str_so.Length - c1.Length);                    
                    ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = c1.ToString();
                    if (c2.Length > 0)
                        ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu1"]).Text = c2.ToString() + ".";
                }
                else
                {
                    ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = c1.ToString();
                    if (c2.Length > 0)
                        ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu1"]).Text = c2.ToString() + ".";
                }
            }
        }  
    }
    private DataTable loadphieu_thu(string so_unc, string tk_co,string mancc,int stt)
    {
        string strsql = "";
        strsql = "select so_unc=a.so_unc,ngay_lap_unc,tk_co,tennhacungcap,diachi,sotaikhoanncc=taikhoannganhang,tennganhangncc=nganhang,a.dien_giai,tien=sum(isnull(b.ps_no,0))+sum(isnull(tien_thue,0)),c.sohieutknh,c.tentknh ";
        if (stt == 1)
        {
            strsql += " from uy_nhiem_chi a left join uy_nhiem_chi_ct b on a.so_unc=b.so_unc  left join nhacungcap d on a.ma_ncc=d.manhacungcap left join danhmuctknh c  on a.tk_co=c.taikhoankt";
            strsql += " where  (a.isdelete is null or a.isdelete=0) and b.isdelete is null and a.so_unc='" + so_unc + "' and tk_co='" + tk_co + "'";
        }
        else
        {
            strsql += " from uy_nhiem_chi a left join uy_nhiem_chi_ct b on a.so_unc=b.so_unc  left join nhacungcap d on b.ma_ncc=d.manhacungcap left join danhmuctknh c  on a.tk_co=c.taikhoankt";
            strsql += " where (a.isdelete is null or a.isdelete=0) and b.isdelete is null and a.so_unc='" + so_unc + "' and tk_co='" + tk_co + "' and b.ma_ncc='" + mancc + "'";
        }
        strsql += " group by a.so_unc,ngay_lap_unc,tk_co,tennhacungcap,diachi,taikhoannganhang,nganhang,a.dien_giai,c.sohieutknh,c.tentknh ";        
        DataTable dtPT = new DataTable();
        dtPT = DataAcess.Connect.GetTable(strsql);
        if(stt==1)
            dtPT.Rows[0]["so_unc"] = dtPT.Rows[0]["so_unc"];
        else
            dtPT.Rows[0]["so_unc"] = dtPT.Rows[0]["so_unc"] + "_" + stt.ToString("00");
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

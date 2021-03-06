using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Data.SqlClient;

using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;

public partial class ketoan_BCTC_LuuChuyenTienTe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Page_Init();
        if (!IsPostBack)
        {
            txtdatestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdateend.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdatestart2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdateend2.Text = DateTime.Now.ToString("dd/MM/yyyy");      
        }
        else
        {
            load();
        }
    }
   
    #region Xu ly su kien lay du lieu len report
    DataTable loaddetail()
    {
        xuli();
        DataTable dt = new DataTable();
        string sql = "";
        sql = "select chitieu,maso,thuyetminh,namnay,namtruoc,bold from luuchuyentiente";
        dt = DataAcess.Connect.GetTable(sql);
        return dt;
    }

    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        load();
        //xuli();
    }
    void load()
    {        
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/BCTC_LuuChuyenTienTe.rpt"));
        //crystalReport.SetDatabaseLogon(UID, PSW, "@" + server, database);
        crystalReport.SetDataSource(loaddetail());
        //StaticData.MsgBox(this, txtdatestart2.Text);        
        string ngaythang = txtdatestart2.Text.Trim();
        string nam = ngaythang.Substring(ngaythang.Length - 4, 4);
        crystalReport.SetParameterValue("@nam", nam);
        crystalReport.SetParameterValue("@tungay",txtdatestart2.Text);
        crystalReport.SetParameterValue("@denngay", txtdateend2.Text);
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind(); 
       //lay ten, dia chi cong ty
            string sql1 = "select ten_cty,diachi from tieudecty";
            DataTable dtcty = new DataTable();
            dtcty = DataAcess.Connect.GetTable(sql1);            
            if (dtcty.Rows.Count >= 1)
            {
                ((TextObject)crystalReport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
                ((TextObject)crystalReport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();
            }            
        }
    void xuli()
    {
        string tungay1 = txtdatestart.Text;
        string denngay1 = txtdateend.Text;
        string tungay2 = txtdatestart2.Text;
        string denngay2 = txtdateend2.Text;        
        Decimal tien_ms20 = 0;
        Decimal tien_ms30 = 0;
        Decimal tien_ms40 = 0;
        Decimal tien_ms20_nt = 0;
        Decimal tien_ms30_nt = 0;
        Decimal tien_ms40_nt = 0;
        Decimal tien_ms50 = 0;
        Decimal tien_ms50_nt = 0;
        //Decimal tien_ms60 = 0;
        //Decimal tien_ms60_nt = 0;
        //Decimal tien_ms61 = 0;
        //Decimal tien_ms61_nt = 0;
        Decimal tien_ms70 = 0;
        Decimal tien_ms70_nt = 0;
        string sqldk_namnay = "";
        string sqldk_namtruoc = "";
        //ma so01: tien thu tu ban hang, cung cap dich vu... 
        //luu chuyen tien te nam nay
        string sqlms = "select maso,namnay,namtruoc from luuchuyentiente where maso is not null and maso<>60 and maso<>61 and maso<>70";
        DataTable dtms = new DataTable();
        dtms = DataAcess.Connect.GetTable(sqlms);
        if(dtms!=null && dtms.Rows.Count>0)
            for (int m = 0; m < dtms.Rows.Count; m++)
            {
                string dk_no01 = "";
                string dk_co01 = "";
                string sql_no01 = "select dstk_no,dstk_co from luuchuyentiente where maso='"+ dtms.Rows[m]["maso"].ToString()+"'";
                DataTable dt = new DataTable();
                dt = DataAcess.Connect.GetTable(sql_no01);
                if (dt != null && dt.Rows.Count > 0)
                {                    
                    string a = dt.Rows[0]["dstk_no"].ToString();
                    string[] t = a.Split(',');
                    for (int i = 0; i < t.Length; i++)
                    {
                        dk_no01 += " or tai_khoan like '" + t[i] + "%'";
                    }
                    //bo di chu "and" dau dong
                    dk_no01 = "(" + dk_no01.Substring(3, dk_no01.Length - 3) + ")";
                    //lay danh sach tk co
                    string a2 = dt.Rows[0]["dstk_co"].ToString();
                    string[] t2 = a2.Split(',');
                    for (int j = 0; j < t2.Length; j++)
                    {
                        dk_co01 += " or tai_khoan_du like '" + t2[j] + "%'";
                    }
                    //bo di chu "or" dau dong
                    dk_co01 = "(" + dk_co01.Substring(3, dk_co01.Length - 3) + ")";
                }                                                                           
                //lay doanh thu ki nay
                string sqlms01 = "";
                sqlms01 = "select sum(isnull(ps_no,0))ps_no from so_cai where ";
                if (dk_no01.Length > 0 && dk_co01.Length > 0)
                {
                    sqlms01 += dk_no01 + " and " + dk_co01 +" and ";
                }
                else
                    if (dk_no01.Length > 0)
                    {
                        sqlms01 += dk_no01 + " and ";
                    }
                    else
                        if (dk_co01.Length > 0)
                        {
                            sqlms01 += dk_co01 + " and ";
                        }
                sqldk_namnay = sqlms01 + "(convert(varchar(10),ngay_lap_ct,111) between '" + StaticData.CheckDate_kt(tungay2).ToString() + "' and '" + StaticData.CheckDate_kt(denngay2).ToString() + "')";
                sqldk_namtruoc = sqlms01 + "(convert(varchar(10),ngay_lap_ct,111) between '" + StaticData.CheckDate_kt(tungay1).ToString() + "' and '" + StaticData.CheckDate_kt(denngay1).ToString() + "')";
                //lay tong ps_no theo dieu kien nam nay
                string psno_ms01="";
                DataTable dtms02 = new DataTable();
                dtms02 = DataAcess.Connect.GetTable(sqldk_namnay);
                if (dk_no01.Length > 25 || dk_co01.Length > 25)
                {
                    if (dtms02.Rows[0]["ps_no"].ToString() !="" )
                    {
                        psno_ms01 = dtms02.Rows[0]["ps_no"].ToString();
                    }
                    else
                        psno_ms01 = "0";
                }
                else
                    psno_ms01 = "0";
                //lay tong ps_no theo dieu kien nam truoc
                string psno_namtruoc = "";
                DataTable dtpsno_namtruoc = new DataTable();
                dtpsno_namtruoc = DataAcess.Connect.GetTable(sqldk_namtruoc);
                if (dk_no01.Length > 25 || dk_co01.Length > 25)
                {
                    if (dtpsno_namtruoc.Rows[0]["ps_no"].ToString() != "")
                    {
                        psno_namtruoc = dtpsno_namtruoc.Rows[0]["ps_no"].ToString();
                    }
                    else
                        psno_namtruoc = "0";
                }
                else
                    psno_namtruoc = "0";
               //------------------------------//-------------------------//----------------------------
                //update namnay=psno_ms01; nam truoc=psno_namtruoc
                string sql_up_ms01 = "";
                string sql_up_namtruoc = "";  
                int maso = int.Parse(dtms.Rows[m]["maso"].ToString());
                if (maso == 2 || maso == 3 || maso == 4 || maso == 5 || maso == 7 || maso == 21 || maso == 22 || maso == 23 || maso == 25 || maso == 32 || maso == 34 || maso == 35 || maso == 36)
                {
                    sql_up_ms01 = "update luuchuyentiente set namnay=-" + psno_ms01 + " where maso='" + dtms.Rows[m]["maso"].ToString() + "'";
                    sql_up_namtruoc = "update luuchuyentiente set namtruoc=-" + psno_namtruoc + " where maso='" + dtms.Rows[m]["maso"].ToString() + "'";
                }
                else
                {
                    sql_up_ms01 = "update luuchuyentiente set namnay=" + psno_ms01 + " where maso='" + dtms.Rows[m]["maso"].ToString() + "'";
                    sql_up_namtruoc = "update luuchuyentiente set namtruoc=" + psno_namtruoc + " where maso='" + dtms.Rows[m]["maso"].ToString() + "'";
                }
                DataAcess.Connect.ExecSQL(sql_up_ms01);
                DataAcess.Connect.ExecSQL(sql_up_namtruoc);
                //------------------------------//-------------------------//----------------------------
                //update ms 20:luu chuyen tien thuan tu hoat dong kinh doanh(nam nay)               
                if (maso == 1 || maso == 2 || maso == 3 || maso==4||maso==5|| maso == 6 || maso == 7)
                {                    
                    if (dtms.Rows[m]["namnay"].ToString() != "")
                    {                        
                        tien_ms20 += Decimal.Parse(dtms.Rows[m]["namnay"].ToString());
                    }
                    //tinh tien nam truoc
                    if (dtms.Rows[m]["namtruoc"].ToString() != "")
                    {
                        tien_ms20_nt += Decimal.Parse(dtms.Rows[m]["namtruoc"].ToString());
                    }
                }
                string sql_ms20 = "update luuchuyentiente set namnay=" + tien_ms20 + " where maso='20'";
                DataAcess.Connect.ExecSQL(sql_ms20);                
                string sql_ms20_nt = "update luuchuyentiente set namtruoc=" + tien_ms20_nt + " where maso='20'";
                DataAcess.Connect.ExecSQL(sql_ms20_nt);
                //------------------------------//-------------------------//----------------------------
                //update ms=30 nam nay
                if (maso == 21 || maso == 22 || maso == 23 || maso == 24 || maso == 25 || maso == 26 || maso == 27)
                {
                    if (dtms.Rows[m]["namnay"].ToString() != "")
                    {                       
                        tien_ms30 += Decimal.Parse(dtms.Rows[m]["namnay"].ToString());
                    }
                    //tien nam truoc
                    if (dtms.Rows[m]["namtruoc"].ToString() != "")
                    {
                        tien_ms30_nt += Decimal.Parse(dtms.Rows[m]["namtruoc"].ToString());
                    }
                }
                string sql_ms30 = "update luuchuyentiente set namnay=" + tien_ms30 + " where maso='30'";
                DataAcess.Connect.ExecSQL(sql_ms30);                
                string sql_ms30_nt = "update luuchuyentiente set namtruoc=" + tien_ms30_nt + " where maso='30'";
                DataAcess.Connect.ExecSQL(sql_ms30_nt);
                //------------------------------//-------------------------//----------------------------
                //update ms=40 nam nay 
                if (maso == 31 || maso == 32 || maso == 33 || maso == 34 || maso == 35 || maso == 36)
                {
                    if (dtms.Rows[m]["namnay"].ToString() != "")
                    {
                        tien_ms40 += Decimal.Parse(dtms.Rows[m]["namnay"].ToString());
                    }
                    //tien nam truoc
                    if (dtms.Rows[m]["namtruoc"].ToString() != "")
                    {
                        tien_ms40_nt += Decimal.Parse(dtms.Rows[m]["namtruoc"].ToString());
                    }
                }
                string sql_ms40 = "update luuchuyentiente set namnay=" + tien_ms40 + " where maso='40'";
                DataAcess.Connect.ExecSQL(sql_ms40);                
                string sql_ms40_nt = "update luuchuyentiente set namtruoc=" + tien_ms40_nt + " where maso='40'";
                DataAcess.Connect.ExecSQL(sql_ms40_nt);
                //------------------------------//-------------------------//----------------------------
                //update ms=50
                if (maso == 20 || maso == 30 || maso == 40)
                {
                    if (dtms.Rows[m]["namnay"].ToString() != "")
                    {
                        tien_ms50 += Decimal.Parse(dtms.Rows[m]["namnay"].ToString());
                    }
                    //tien nam truoc
                    if (dtms.Rows[m]["namtruoc"].ToString() != "")
                    {
                        tien_ms50_nt += Decimal.Parse(dtms.Rows[m]["namtruoc"].ToString());                        
                    }
                }
                string sql_ms50 = "update luuchuyentiente set namnay=" + tien_ms50 + " where maso='50'";
                DataAcess.Connect.ExecSQL(sql_ms50);
                string sql_ms50_nt = "update luuchuyentiente set namtruoc=" + tien_ms50_nt + " where maso='50'";
                DataAcess.Connect.ExecSQL(sql_ms50_nt);
                //------------------------------//-------------------------//----------------------------
                //update ms=70
                if (maso == 50 )
                {
                    if (dtms.Rows[m]["namnay"].ToString() != "")
                    {                       
                        tien_ms70 += Decimal.Parse(dtms.Rows[m]["namnay"].ToString());
                    }
                    //tien nam truoc
                    if (dtms.Rows[m]["namtruoc"].ToString() != "")
                    {
                        tien_ms70_nt += Decimal.Parse(dtms.Rows[m]["namtruoc"].ToString());
                    }
                }
                string sql_ms70 = "update luuchuyentiente set namnay=" + tien_ms70 + " where maso='70'";
                DataAcess.Connect.ExecSQL(sql_ms70);
                string sql_ms70_nt = "update luuchuyentiente set namtruoc=" + tien_ms70_nt + " where maso='70'";
                DataAcess.Connect.ExecSQL(sql_ms70_nt);
            }        
    }
    #endregion
}


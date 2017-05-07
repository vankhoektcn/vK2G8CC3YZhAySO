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

public partial class ketoan_HDDV_rptXuatHoaDon :System.Web.UI.Page
{
    string strso_hd = "", strngay_lap_hd = ""; string type = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strso_hd = Request.QueryString["so_hoa_don"];
        strngay_lap_hd = Request.QueryString["ngay_lap_hd"];
        type=Request.QueryString["type"];      
        if (!IsPostBack)
        {
            load(strso_hd, strngay_lap_hd,type);
        }
        else
            load(strso_hd, strngay_lap_hd,type);
    }
    void load(string sohd, string ngaylaphd, string type)
    {       
        crystalreport = new ReportDocument();
        if (type == "khachhang")
        {
            crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/HDDV_rptXuatHoaDon2.rpt"));
            DataTable dt = loadhoa_don_dv_kh(sohd, ngaylaphd);
            int maxdong = 12;
            int sodongdu = maxdong - dt.Rows.Count;
            if (sodongdu > 0)
            {
                for (int i = 0; i < sodongdu; i++)
                {
                    dt.Rows.Add(DBNull.Value);
                }
            }
             Int32 tien_hang = 0, tien_thue = 0, tong_tien = 0;
            int thue_suat = 0;
            tien_hang = Convert.ToInt32(dt.Rows[0]["tien"].ToString());
            tien_thue = Convert.ToInt32(dt.Rows[0]["tien_thue"].ToString());
            tong_tien = Convert.ToInt32(dt.Rows[0]["tong_tien"].ToString());
            thue_suat = Convert.ToInt16(dt.Rows[0]["thue_suat"].ToString());
            
            crystalreport.SetDataSource(dt);
            crystalreport.SetParameterValue("tien_hang", tien_hang);
            crystalreport.SetParameterValue("tien_thue", tien_thue);
            crystalreport.SetParameterValue("tong_tien", tong_tien);
            crystalreport.SetParameterValue("thue_suat", thue_suat);

            CrystalReportViewer1.ReportSource = crystalreport;
            CrystalReportViewer1.DataBind();              
            if (dt.Rows.Count >= 1)
            {
                //string str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tong_tien"].ToString());
                string str_so = mdlCommonFunction.ConvertMoneyToText(dt.Rows[0]["tong_tien"].ToString());
                ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = str_so.ToString();
            }
        }
        else
            if (type == "khac")
            {
                crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/HDDV_rptXuatHoaDon2.rpt"));
                DataTable dt = loadhoa_don_dv_khac(sohd, ngaylaphd);
                //tinh so dong cua ten dich vu tren 33 ki tu               
                int sodong = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ten_hang"].ToString().Length > 33)
                        {
                            sodong += 1;
                        }
                    }
                }           
                int maxdong = 12;
                int sodongdu = maxdong - dt.Rows.Count - sodong;
                //int sodongdu = maxdong - dt.Rows.Count;
                if (sodongdu > 0)
                {
                    for (int i = 0; i < sodongdu; i++)
                    {
                        dt.Rows.Add(DBNull.Value);
                    }
                }
                Int32 tien_hang = 0, tien_thue = 0, tong_tien = 0;
                int thue_suat = 0;
                tien_hang = Convert.ToInt32(dt.Rows[0]["tien"].ToString());
                tien_thue = Convert.ToInt32(dt.Rows[0]["tien_thue"].ToString());
                tong_tien = Convert.ToInt32(dt.Rows[0]["tong_tien"].ToString());
                thue_suat = Convert.ToInt16(dt.Rows[0]["thue_suat"].ToString());

                crystalreport.SetDataSource(dt);
                crystalreport.SetParameterValue("tien_hang", tien_hang);
                crystalreport.SetParameterValue("tien_thue", tien_thue);
                crystalreport.SetParameterValue("tong_tien", tong_tien);
                crystalreport.SetParameterValue("thue_suat", thue_suat);

                CrystalReportViewer1.ReportSource = crystalreport;
                CrystalReportViewer1.DataBind();
                doctienraso(sohd, ngaylaphd,62);
                //if (dt.Rows.Count >= 1)
                //{
                //    //string str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tong_tien"].ToString());
                //    string str_so = mdlCommonFunction.ConvertMoneyToText(dt.Rows[0]["tong_tien"].ToString());
                //    ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = str_so.ToString();
                //}
            }
            else
            {
                crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/HDDV_rptXuatHoaDon.rpt"));
                DataTable dt = loadhoa_don_dv(sohd, ngaylaphd);            
                crystalreport.SetDataSource(dt);
                CrystalReportViewer1.ReportSource = crystalreport;
                CrystalReportViewer1.DataBind();
                if (dt.Rows.Count >= 1)
                {
                    //string str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tong_tien"].ToString());
                    string str_so = mdlCommonFunction.ConvertMoneyToText(dt.Rows[0]["tong_tien"].ToString());
                    ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = str_so.ToString();
                }
            }        
    }
    private void doctienraso(string sohd,string ngaylaphd,int kitu)
    {
        DataTable dt = new DataTable();
        dt = loadhoa_don_dv_khac(sohd, ngaylaphd);
        string str_so = "";
        string c1 = "";
        string c2 = "";

        if (dt != null && dt.Rows.Count > 0)
        {
            //str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tien"].ToString());
            str_so = mdlCommonFunction.ConvertMoneyToText(dt.Rows[0]["tong_tien"].ToString());
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
    private DataTable loadhoa_don_dv(string so_hd, string ngay_lap_hd)
    {
        string strsql = "";
        strsql = "select ngay_lap_hd,ten_kh,ten_nguoi_mua,dia_chi,ma_so_thue,dien_giai,thue_suat,tien,tien_thue,tong_tien ";
        strsql = strsql + " from hoa_don_dv where so_hd='" + so_hd + "' and convert(nchar(10),ngay_lap_hd,103)='" + ngay_lap_hd + "'";        
        DataTable dtPT = new DataTable();
        dtPT = DataAcess.Connect.GetTable(strsql);        
        return dtPT;
    }
    private DataTable loadhoa_don_dv_kh(string so_hd, string ngay_lap_hd)
    {
        string strsql = "";
        strsql = "select ngay_lap_hd,ten_kh,ten_nguoi_mua,dia_chi,ma_so_thue,dien_giai,thue_suat,tien,tien_thue,tong_tien,ten_hang,dvt,so_luong,don_gia,thanh_tien  ";
        strsql += " from hoa_don_dv a inner join hoa_don_dv_ct_kh b on a.so_hd=b.so_hd ";
        strsql += " where a.so_hd='" + so_hd + "' and convert(nchar(10),ngay_lap_hd,103)='" + ngay_lap_hd + "'";       
        DataTable dthdkh = new DataTable();
        dthdkh = DataAcess.Connect.GetTable(strsql);
        return dthdkh;
    }
    private DataTable loadhoa_don_dv_khac(string so_hd, string ngay_lap_hd)
    {
        string strsql = "";
        strsql = "select ngay_lap_hd,ten_kh,ten_nguoi_mua,dia_chi,ma_so_thue,dien_giai,thue_suat,tien,tien_thue,tong_tien,ten_hang=b.ten_dich_vu,dvt='',so_luong='',don_gia='',thanh_tien=b.tien_dv  ";
        strsql += " from hoa_don_dv a inner join hoa_don_dv_ct_khac b on a.so_hd=b.so_hoa_don ";
        strsql += " where a.so_hd='" + so_hd + "' and convert(nchar(10),ngay_lap_hd,111)='" + StaticData.CheckDate_kt(ngay_lap_hd) + "'";
        DataTable dthdkh = new DataTable();
        dthdkh = DataAcess.Connect.GetTable(strsql);
        return dthdkh;
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

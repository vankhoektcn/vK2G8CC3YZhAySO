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

public partial class ketoan_HDDV_rptXuatHoaDonBanHang :System.Web.UI.Page
{
    string strso_hd = "", strngay_lap_hd = "" ,type=""; 
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strso_hd = Request.QueryString["so_hoa_don"];
        strngay_lap_hd = Request.QueryString["ngay_lap_hd"];
        type=Request.QueryString["type"];      
        if (!IsPostBack)
        {
            load(strso_hd, strngay_lap_hd);
        }
        else
            load(strso_hd, strngay_lap_hd);
    }
    void load(string sohd, string ngaylaphd)
    {       
        crystalreport = new ReportDocument();
        if (type == "khachhang")
        {
            crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/HDDV_rptXuatHoaDon2.rpt"));
            DataTable dt = loadhoa_don_dv_kh(sohd, ngaylaphd);
            int maxdong = 10;
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
                string str_so = new clsDocSo.clsDocSo().ChuyenSo(dt.Rows[0]["tong_tien"].ToString());
                ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = str_so.ToString();
            }
        }        
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

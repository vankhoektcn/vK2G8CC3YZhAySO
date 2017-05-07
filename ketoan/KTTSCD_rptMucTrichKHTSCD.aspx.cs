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
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;

public partial class KTTSCD_rptMucTrichKHTSCD : System.Web.UI.Page
{
    
    ReportDocument crystalReport;   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string thang = "";
        string nam = "";
        if (!IsPostBack)
        {
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            thang = StaticData.CheckDate_kt(txtNgay.Text).Substring(5, 2);
            nam = StaticData.CheckDate_kt(txtNgay.Text).Substring(0, 4);
            load(thang, nam);
        }
        else
        {
            thang = StaticData.CheckDate_kt(txtNgay.Text).Substring(5, 2);
            nam = StaticData.CheckDate_kt(txtNgay.Text).Substring(0, 4);
            load(thang, nam);
        }       
    }
    void load(string thang,string nam)
    {       
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/KTTSCD_rptMucTrichKHTSCD.rpt"));//file:///E:\PHAN MEM QUAN LY\quanlythuoc\report\toathuocnguoidung.rpt        
        DataTable dts = LoadDSTSCD(thang,nam);
        crystalReport.SetDataSource(dts);
        crystalReport.SetParameterValue("tungay", txtNgay.Text);
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();

        //lay ten, dia chi cong ty
        string sql1 = "select ten_cty,diachi from tieudecty";
        DataTable dtcty = DataAcess.Connect.GetTable(sql1);
        if (dtcty!=null && dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();
        }
        //lây tên giám đốc,....

        string sql_lay_ten = "select tham_so,gia_tri from tham_so where tham_so='ho_ten_giam_doc' or tham_so='ho_ten_ke_toan_truong' or tham_so='ho_ten_thu_quy' or tham_so='ho_ten_nguoi_lap_phieu'";
        DataTable dtten = new DataTable();
        dtten = DataAcess.Connect.GetTable(sql_lay_ten);
        if (dtten != null && dtten.Rows.Count >= 1)
        {
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["kt_truong"]).Text = dtten.Rows[0][1].ToString();           
        }        
    }
    private DataTable LoadDSTSCD(string thang,string nam)
    {
        string sql = @"select MaTS,ten_vt,loai_vt,tinhtrangtscd=case when isnull(isstatus,0)=1 then N'đang dùng' else N'chưa xác định' end ,NgayKhauHao,NguyenGia, 
        haomonluyke=dbo.ft_haomonluykets(" + thang + "," + nam + @",MaTS),gtcl=NguyenGia-dbo.ft_haomonluykets(" + thang + "," + nam + @",MaTS),
        sothangconlai=SoNamKH- DATEDIFF(MONTH,NgayKhauHao,'"+StaticData.CheckDate_kt(txtNgay.Text)+@"'),khauhaothang=CEILING(NguyenGia/SoNamKH)
        from DanhMucTaiSan a left join DM_VAT_TU_KT b on a.MaTS=b.ma_vt where a.istscd=1";                  
        DataTable dtSRC = DataAcess.Connect.GetTable(sql);
        return dtSRC;
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
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
    protected void btnXem_Click(object sender, EventArgs e)
    {
        string thang1 = StaticData.CheckDate_kt(txtNgay.Text).Substring(5, 2);
        string nam1 = StaticData.CheckDate_kt(txtNgay.Text).Substring(0, 4);
        load(thang1,nam1);
    }
}

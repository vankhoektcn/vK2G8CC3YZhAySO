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

public partial class HDDV_rptDoanhThuTongHop : System.Web.UI.Page
{
    
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            load();
        }
        else
            load();
       
    }
    void load()
    {
        
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/HDDV_rptDoanhThuTongHop.rpt"));//file:///E:\PHAN MEM QUAN LY\quanlythuoc\report\toathuocnguoidung.rpt        
        DataTable dts = LoadSoQuyTM();
        crystalReport.SetDataSource(dts);
        crystalReport.SetParameterValue("tungay", txtNgay.Text);
        crystalReport.SetParameterValue("denngay", txtDenNgay.Text);
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
    private DataTable LoadSoQuyTM()
    {
        string sql = @"select convert(varchar(10),sysdate,103)ngay_thu,noidungthu as ten_doanh_thu,sum(tongtien)thanh_tien from hs_dsdathu a left join benhnhan b on a.mabenhnhan=b.mabenhnhan
        where (sysdate >='" + StaticData.CheckDate_kt(this.txtNgay.Text) + "' and sysdate <='" + StaticData.CheckDate_kt(this.txtDenNgay.Text) + " 23:59:59" + @"') and (isdahuy is null or isdahuy =0)
        group by  noidungthu,convert(varchar(10),sysdate,103) order by convert(varchar(10),sysdate,103), noidungthu";
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
            load();
    }
}

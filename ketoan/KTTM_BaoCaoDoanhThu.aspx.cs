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

public partial class ketoan_KTTM_BaoCaoDoanhThu : System.Web.UI.Page
{
    ReportDocument report;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Load_BaoCaoDoanhThu()
    {

        string tungay = txtTuNgay.Value;
        string denngay = txtDenNgay.Value;
        DataSet ds = new DataSet();
        report = new ReportDocument();
        report.Load(Server.MapPath("../ketoan/report_KeToan/KTTM_BaoCaoDoanhThu1.rpt"));
        string sql = "Select convert(varchar,ngay_thu,103)NgayThu ,MaDoanhThu = ma_doanh_thu,	TenDoanhThu = ten_doanh_thu,ThanhTien = thanh_tien_bn_tra, "+
                     "        TuNgay = '"+tungay+"',DenNgay = '"+denngay+ "'"+ 
                     "	From DoanhThu_Pmbv "+
                     "	Where 1=1 ";
        if(!string.IsNullOrEmpty(tungay)&&!string.IsNullOrEmpty(denngay))
        {
            sql += "  and (convert(varchar,ngay_thu,103) between '" + tungay + "' and '"+denngay+"') ";
        }
        else
            if(!string.IsNullOrEmpty(tungay))
            {
                sql += "  and (convert(varchar,ngay_thu,103) = '" + tungay + "' ) ";
            }
            else
            if (!string.IsNullOrEmpty(denngay))
            {
                sql += "  and (convert(varchar,ngay_thu,103) = '" + denngay + "') ";
            }
    
        DataTable dt = DataAcess.Connect.GetTable(sql);

        dt.TableName = "BaoCaoDoanhThu";
        ds.Tables.Add(dt);
        report.SetDataSource(ds);
          
        CrystalReportViewer1.ReportSource = report;
        this.CrystalReportViewer1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Load_BaoCaoDoanhThu();
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        if (report != null)
        {
            report.Clone();
            report.Dispose();
            CrystalReportViewer1.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
    protected void form_unload(object sender, EventArgs e)
    {
        if (report != null)
        {
            report.Clone();
            report.Dispose();
            report = null;
            CrystalReportViewer1.Dispose();
            CrystalReportViewer1 = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
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

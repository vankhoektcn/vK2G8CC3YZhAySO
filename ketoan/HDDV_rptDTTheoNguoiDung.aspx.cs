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

public partial class HDDV_rptDTTheoNguoiDung : System.Web.UI.Page
{    
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            load();
            load_nguoidung();
        }
        else
        {            
            load();            
        }
    }
    private void load_nguoidung()
    {
//        string sql = @"SELECT DISTINCT idnguoidung= IDNGUOITHU,B.TENNGUOIDUNG
//                        FROM 
//                        (
//                        (
//                        SELECT DISTINCT IDNGUOITHU 
//                        FROM DANGKYKHAM 
//		                        WHERE NGAYDANGKY>='" + StaticData.CheckDate(this.txtNgay.Text) + @"' AND NGAYDANGKY<='" + StaticData.CheckDate(this.txtDenNgay.Text) + @" 23:59:59' AND DATHU=1 AND ISNULL(DAHUY,0)=0
//                        )
//                        UNION
//                        (
//                        SELECT DISTINCT IDNGUOITHU 
//                        FROM 
//	                        KHAMBENHCANLAMSAN 
//		                        WHERE NGAYTHU>='" + StaticData.CheckDate(this.txtNgay.Text) + @"' AND NGAYTHU<='" + StaticData.CheckDate(this.txtDenNgay.Text) + @" 23:59:59' AND DATHU=1 AND ISNULL(DAHUY,0)=0
//                        )                         
//                        ) AS TB
//                         LEFT JOIN NGUOIDUNG B ON TB.IDNGUOITHU=B.IDNGUOIDUNG";
        string sql = "";
        sql = @"select distinct tennguoithu from hs_dsdathu where tennguoithu <> ''  order by tennguoithu";            
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(drlnguoidung, dt, "tennguoithu", "tennguoithu", "chọn người dùng");

    }
    void load()
    {        
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/HDDV_rptDTTheoNguoiDung.rpt"));//file:///E:\PHAN MEM QUAN LY\quanlythuoc\report\toathuocnguoidung.rpt        
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
//        string sql1 = @"select tennguoidung,ten_doanh_thu,sum(thanh_tien_bn_tra) as thanh_tien
//                        from dbo.KB_GetDoanhThu_nguoidung('" + StaticData.CheckDate(this.txtNgay.Text) + @"','" + StaticData.CheckDate(this.txtDenNgay.Text) + @" 23:59:59')"
//                                                          +( this.drlnguoidung.SelectedValue!=null &&this.drlnguoidung.SelectedValue!="" && this.drlnguoidung.SelectedValue!="0"? " WHERE NGUOI_THU="+this.drlnguoidung.SelectedValue :"")
//        +@"                        group by tennguoidung,ten_doanh_thu 
//                          ORDER BY  tennguoidung,ten_doanh_thu " ;
        string sql = "";
        sql = @"select tennguoithu as tennguoidung,noidungthu as ten_doanh_thu,sum(tongtien)thanh_tien from hs_dsdathu
              where (sysdate >='"+StaticData.CheckDate_kt(this.txtNgay.Text)+"' and sysdate <='"+StaticData.CheckDate_kt(this.txtDenNgay.Text)+" 23:59:59"+@"') and (isdahuy is null or isdahuy =0) ";
        if (this.drlnguoidung.SelectedValue.ToString().Trim() != "0")
            sql+=" and tennguoithu=N'"+this.drlnguoidung.SelectedValue.ToString().Trim() +@"'";
        sql+=" group by tennguoithu,noidungthu order by tennguoithu,noidungthu";

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
    protected void btnRefesh_Click(object sender, EventArgs e)
    {
        this.load_nguoidung();
    }
}
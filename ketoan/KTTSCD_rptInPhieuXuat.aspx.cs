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

public partial class KTTSCD_rptInPhieuXuat : System.Web.UI.Page
{
    string strsophieu = "", strngayxuat = "";
    ReportDocument crystalreport;
    protected void Page_Load(object sender, EventArgs e)
    {
        strsophieu=Request.QueryString["so_phieu"];
        strngayxuat = Request.QueryString["ngay_xuat"];
        if (!IsPostBack)
        {
            load(strsophieu, strngayxuat);
        }
        else
            load(strsophieu, strngayxuat);
        
    }
   
    void load(string sphieuthu,string ngayxuat)
    {
        crystalreport = new ReportDocument();
        crystalreport.Load(Server.MapPath("../ketoan/report_ketoan/KTTSCD_rptMauInPhieuXuat.rpt"));
        DataTable dt = new DataTable();
         dt = loadphieu_nhap(sphieuthu, ngayxuat);
        crystalreport.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = crystalreport;
        CrystalReportViewer1.DataBind();
        string sqltien = "select sum(tong_tien) as tien from phieu_xuat_vt a inner join phieu_xuat_vt_ct b on a.phieu_xuat_id=b.phieu_xuat_id";
        sqltien = sqltien + " where so_phieu='" + sphieuthu + "' and convert(char(10),ngay_xuat,103)= '" + ngayxuat + "'";
        DataTable dttien = DataAcess.Connect.GetTable(sqltien);
        string str_so = "";
        if (dttien != null && dttien.Rows.Count > 0)
        {
            str_so = new clsDocSo.clsDocSo().ChuyenSo(dttien.Rows[0]["tien"].ToString());
        }
        ((TextObject)crystalreport.ReportDefinition.ReportObjects["tienbangchu"]).Text = str_so.ToString() + ".";        
        
        //lay ten, dia chi cong ty
        string sql1 = "select ten_cty,diachi from tieudecty";
        DataTable dtcty = new DataTable();
        dtcty = DataAcess.Connect.GetTable(sql1);
        if (dtcty.Rows.Count >= 1)
        {
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["ten_cty"]).Text = dtcty.Rows[0]["ten_cty"].ToString();            
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["dia_chi"]).Text = dtcty.Rows[0]["diachi"].ToString();            
        }
        //lây tên giám đốc,....
        string sql_lay_ten = "select tham_so,gia_tri from tham_so where tham_so='so_quet_dinh_ke_toan' or tham_so='ho_ten_ke_toan_truong'";
        DataTable dtten = new DataTable();
        dtten = DataAcess.Connect.GetTable(sql_lay_ten);
        if (dtten.Rows.Count >= 1)
        {            
            ((TextObject)crystalreport.ReportDefinition.ReportObjects["quyet_dinh_kt"]).Text = dtten.Rows[0][1].ToString();  
        }
    }
    private DataTable loadphieu_nhap(string phieuxuat, string ngayxuat)
    {
        string strsql = "";
        strsql = @"select ngay_xuat,so_phieu,ten_nguoi_nhan,khoanhan=e.tenphongkhambenh,a.dien_giai,tk_no=b.tk_chi_phi,tk_co=b.tk_ccdc,d.tenkho,b.ma_vt,c.ten_vt,c.dvt,b.so_luong,b.don_gia,thanhtien=ISNULL(b.so_luong,0)*ISNULL(b.don_gia,0)
        from PHIEU_XUAT_VT a left join PHIEU_XUAT_VT_CT b on a.phieu_xuat_id=b.phieu_xuat_id left join DM_VAT_TU_KT c on b.ma_vt=c.ma_vt left join khothuoc d on b.idkho=d.idkho left join phongkhambenh e on a.ma_phong=CONVERT(varchar,e.idphongkhambenh)";
        strsql = strsql+" where so_phieu='"+ phieuxuat+ "' and convert(char(10),ngay_xuat,103)= '"+ngayxuat +"'" ;
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

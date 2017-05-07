using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
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

public partial class KTCN_NhaCungCap_CT : System.Web.UI.Page
{    
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            loadtk();
        }
        //load();        
    }
    void loadtk()
    {
        string sql = "select taikhoan,tentaikhoan from danhmuctk where taikhoan = '331' or taikhoan = '338'  order by taikhoan";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(drltaikhoan, dt, "taikhoan", "taikhoan", "chọn tk công nợ");
    }
    void load()
    {
        string strTK = "";
        strTK = drltaikhoan.Text.Trim();
        string strMa_kh = txtMa_kh.Text;//
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../ketoan/report_KeToan/KTCN_NhaCungCap_CT.rpt"));//file:///E:\PHAN MEM QUAN LY\quanlythuoc\report\toathuocnguoidung.rpt                      
        DataTable dts = LoadCongNoKhachHang_CT(strTK.Trim(), strMa_kh.Trim());      
        crystalReport.SetDataSource(dts);

        crystalReport.SetParameterValue("tungay", txtNgay.Text);
        crystalReport.SetParameterValue("denngay",txtDenNgay.Text);

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
        //lấy tài khoản và tên tài khoản
        string sqltk = "";
        if (strTK != "")
        {
            sqltk = "select taikhoan,tentaikhoan from danhmuctk where taikhoan='" + strTK + "'";
            DataTable dttk = new DataTable();            
            dttk = DataAcess.Connect.GetTable(sqltk);
            if (dttk.Rows.Count >= 1)
            {
                ((TextObject)crystalReport.ReportDefinition.ReportObjects["tk"]).Text = dttk.Rows[0]["taikhoan"].ToString();
                ((TextObject)crystalReport.ReportDefinition.ReportObjects["tentaikhoan"]).Text = dttk.Rows[0]["tentaikhoan"].ToString();

            }
        }
        //lay ten khach hang
        string sqlkh = "";
        if (strMa_kh != null)
        {
            sqlkh = "select makhachhang,tenkhachhang from(select makhachhang,tenkhachhang from khachhang union all select manhacungcap, tennhacungcap from nhacungcap union all select mabenhnhan,tenbenhnhan from benhnhan)n where makhachhang ='"+strMa_kh+"'";
            DataTable dtmakh = new DataTable();
            dtmakh = DataAcess.Connect.GetTable(sqlkh);
            if (dtmakh.Rows.Count >= 1)
            {
                ((TextObject)crystalReport.ReportDefinition.ReportObjects["tenkh"]).Text = dtmakh.Rows[0]["tenkhachhang"].ToString();
            }
        }
    }
    private DataTable LoadCongNoKhachHang_CT(string strTK,string ma_kh)
    {
        string sql ;        
        DataTable dtSRC = new DataTable();
        dtSRC = null;
        DataTable dtts = mdlCommonFunction.thamsotuychon();
        string ngay_dau_nam = StaticData.CheckDate_kt(dtts.Rows[7][1].ToString());//chu y cai nay sai tu csdl(phai du dang ngay /thang /nam)
        sql = "exec spCong_No_Khach_Hang_CT '" + ngay_dau_nam + "','" + StaticData.CheckDate_kt(txtNgay.Text) + "','" + StaticData.CheckDate_kt(txtDenNgay.Text) + "','" + strTK + "','" + ma_kh + "'";
        dtSRC = DataAcess.Connect.GetTable(sql);              
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
        if (drltaikhoan.Text.Equals("0") || txtMa_kh.Text.Trim().Equals(""))
        {
            StaticData.MsgBox(this, "Bạn chưa chọn tài khoản hoặc nhà cung cấp!");
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "window.location.href('KTCN_NhaCungCap_CT.aspx')", true);
        }        
        else
        load();
    }
}

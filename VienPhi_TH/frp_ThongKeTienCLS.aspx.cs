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

public partial class frp_ThongKeTienCLS : Genaratepage
{
    // ReportDocument R;
    // string sWhere = "";
    ExportToExcel.Profess_ExportToExcelByCode bctkts = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
        }
        else
        {
            bindKhoa();
            bindCLS();
            txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        string dkMenu = Request.QueryString["dkmenu"];
        PlaceHolder1.Controls.Add(LoadControl("~/" + dkMenu + "/uscmenu.ascx"));

    }


    protected void btnTim_Click(object sender, EventArgs e)
    {
        string tungay = StaticData.CheckDate(txtTuNgay.Text);
        DateTime dTuNgay = DateTime.Parse(tungay);
        string NgayBC_Parameter = StaticData.GetParameter("nvk_NgayBc");
        if (string.IsNullOrEmpty(NgayBC_Parameter))
            NgayBC_Parameter = "2012/07/19";
        if (dTuNgay >= DateTime.Parse(NgayBC_Parameter))
        {
            clsBaoCaoTienCLS_1807 nvk_temp = new clsBaoCaoTienCLS_1807(
              txtTuNgay.Text,
             txtDenNgay.Text,
             ddlPhongKhoa.SelectedValue,
             ddlPhongKhoa.SelectedItem.Text,
             ddPhongSo.SelectedValue,
             ddPhongSo.SelectedItem.Text,
             ddlCLS.SelectedValue,
             ddlCLS.SelectedItem.Text);
            this.bctkts = nvk_temp;
        }
        else
        {
            clsBaoCaoTienCLS temp = new clsBaoCaoTienCLS(
             txtTuNgay.Text,
            txtDenNgay.Text,
            ddlPhongKhoa.SelectedValue,
            ddlPhongKhoa.SelectedItem.Text,
            ddPhongSo.SelectedValue,
            ddPhongSo.SelectedItem.Text,
            ddlCLS.SelectedValue,
            ddlCLS.SelectedItem.Text);
            this.bctkts = temp;
        }
        bctkts.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bctkts_AfterExportToExcel);
        bctkts.ExportToExcel();
    }


    void bctkts_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + bctkts.OutputFileName + "\",'_blank')</script>");
    }
    void bindKhoa()
    {
        string sql = @"select * from phongkhambenh pk 
                        where pk.loaiphong = 0 order by pk.tenphongkhambenh";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPhongKhoa, dt, "idphongkhambenh", "tenphongkhambenh", "__Phòng/khoa__");
        ddlPhongKhoa.SelectedIndex = 0;
    }
    void bindCLS()
    {
        string sql = @"select * from phongkhambenh pk 
                        where pk.loaiphong = 1 order by pk.tenphongkhambenh";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlCLS, dt, "idphongkhambenh", "tenphongkhambenh", "__Phòng/khoa__");
        ddlCLS.SelectedIndex = 0;
    }
  

    
    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
    }
    #endregion


}

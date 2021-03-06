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
public partial class frm_rptPhieuChupXQ : Genaratepage
{
    private string idPH=null;
    ReportDocument R;
    protected void Page_Load(object sender, EventArgs e)
    {
        string dkmenu = "" + "";  if (Request.QueryString["dkmenu"]!=null &&  dkmenu == "")  dkmenu = Request.QueryString["dkmenu"].ToString();
        
        if (dkmenu == "kb")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
            
        }
        if (dkmenu == "thuphi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
           
        }
        if (dkmenu == "tiepnhan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        }
        if (dkmenu == "cls")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
        }
        showReport();
       
    }
    private void showReport()
    {
        DataTable dt;
        R = new ReportDocument();
        R.Load(Server.MapPath("../report/rptPhieuXQuang.rpt"));
        string sql = @"select tenbenhnhan='alo',tuoi='alo',gioitinh='alo',diachi='alo'
        ,soBHYT='alo',khoa='alo',buong='alo',giuong='alo',chandoan='alo',
        yeucauchup='alo',ketquachup='alo',basidieutri='alo',bacsichuyenkhoa='alo',loidan='alo'";
        dt = DataAcess.Connect.GetTable(sql);
        R.SetDataSource(dt);
        R.SetParameterValue("tenbenhvien",StaticData.TenCty);
        R.SetParameterValue("ngay", DateTime.Now.Day.ToString());
        R.SetParameterValue("thang", DateTime.Now.Month.ToString());
        R.SetParameterValue("nam", DateTime.Now.Year.ToString());       
        this.crptView.ReportSource = R;
        this.crptView.DataBind();
    }
    protected void crptView_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);

    }
    #region khoi tao va giai phong bo nho
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
    }    
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

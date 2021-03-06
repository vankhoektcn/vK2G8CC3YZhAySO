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

public partial class BaoCaoTongHopCDHA : Genaratepage
{
    // ReportDocument R;
    // string sWhere = "";
    clsBaoCaoTongHopCDHA bctkts = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
        }
        else
        {
            txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        string dkmenu = "" + "";
        if (Request.QueryString["dkmenu"] != null && dkmenu == "") dkmenu = Request.QueryString["dkmenu"].ToString();
        if (dkmenu == "thuphi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
        }
        if (dkmenu == "tiepnhan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        }
        if (dkmenu == "kb")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
        }
        if (dkmenu == "cls")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
        }

    }


    protected void btnTim_Click(object sender, EventArgs e)
    {
        this.bctkts = new clsBaoCaoTongHopCDHA(
          txtTuNgay.Text,
         txtDenNgay.Text
            );
        bctkts.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bctkts_AfterExportToExcel);
        bctkts.ExportToExcel();
    }


    void bctkts_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + bctkts.OutputFileName + "\",'_blank')</script>");
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

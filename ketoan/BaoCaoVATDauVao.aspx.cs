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

public partial class BaoCaoVATDauVao : System.Web.UI.Page
{    
    BangKeMuaVao BKR = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            ddlTuThang.SelectedIndex = DateTime.Now.Month-1;            
        }        
    }
       
    protected void btnXem_Click(object sender, EventArgs e)
    {
        //load();

        BKR = new BangKeMuaVao(ddlTuThang.SelectedItem.Text, DateTime.Today.Year.ToString());
        BKR.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(BKR_AfterExportToExcel);
        BKR.ExportToExcel();
    }
    private void OpenLink(string LinkName)
    {
        //Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + LinkName + "\",'_blank')</script>");
        Response.Redirect(LinkName);
    }

    void BKR_AfterExportToExcel()
    {
        try
        {
            OpenLink("../ReportOutput/" + BKR.OutputFileName);

        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\" type=\text/javascrip\"> alert('Xuất ra file excel thất bại!') </script>");
        }

    }
}

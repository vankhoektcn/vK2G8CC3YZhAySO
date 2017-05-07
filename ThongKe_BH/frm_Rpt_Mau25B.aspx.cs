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
using System.Text.RegularExpressions;

public partial class frm_Rpt_Mau25B : MKVPage
{
    DSDeNghiThanhToanNgoaiTru_TH bbkn = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    protected void btnLayBaoCao_Click(object sender, EventArgs e)
    {
        this.bbkn = new DSDeNghiThanhToanNgoaiTru_TH();
        bbkn.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bbkn_AfterExportToExcel);
        this.bbkn.FromDate = StaticData.CheckDate(txtTuNgay.Text);
        this.bbkn.ToDate = StaticData.CheckDate(txtDenNgay.Text) + " 23:59:59";
      
        bbkn.ExportToExcel();
    }
    void bbkn_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + bbkn.OutputFileName + "\",'_blank')</script>");
    }
 
    
   
}

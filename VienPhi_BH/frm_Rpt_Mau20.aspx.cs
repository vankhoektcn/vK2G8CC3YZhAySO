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

public partial class frm_Rpt_Mau20 : MKVPage
{
   
    ThongKeTHThuocBHYTNgoaiTru bbkn = null;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        LoadMenu();
    }
    private void LoadMenu()
    {
        try
        {
            string dkmenu = Request.QueryString["dkmenu"].ToString();
            PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnLayBaoCao_Click(object sender, EventArgs e)
    {
        this.bbkn = new ThongKeTHThuocBHYTNgoaiTru();
        this.bbkn.FromDate = StaticData.CheckDate(txtTuNgay.Text);
        this.bbkn.ToDate = StaticData.CheckDate(txtDenNgay.Text) + " 23:59:59";
        this.bbkn.IsNoiTru = (this.chbIsNoiTru.Checked ? "1" : "0");
      
        bbkn.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bbkn_AfterExportToExcel);       
        bbkn.ExportToExcel();
    }
    void bbkn_AfterExportToExcel()
    {
        ScriptManager.RegisterStartupScript(Page,Page.GetType(),"laybactonghopcls","window.open (\"" + "../ReportOutput/" + bbkn.OutputFileName + "\",'_blank');",true);
    }

    
    
}

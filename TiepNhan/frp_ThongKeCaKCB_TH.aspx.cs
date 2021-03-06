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

public partial class frp_ThongKeCaKCB_TH : Genaratepage
{

    BaoCaoKhamBenh tkckb = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "QLBV - Tiếp nhận";
        if (IsPostBack)
        {
        }
        else
        {
            bindKhoa();
            txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        string dkmenu = Request.QueryString["dkmenu"];
        PlaceHolder1.Controls.Add(LoadControl("~/" + dkmenu + "/uscmenu.ascx"));
    }
    

    protected void btnTim_Click(object sender, EventArgs e)
    {

        this.tkckb = new BaoCaoKhamBenh(
          txtTuNgay.Text,
         txtDenNgay.Text,
            ddlPhongKhoa.SelectedValue

            );
        tkckb.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(tkckb_AfterExportToExcel);
        tkckb.ExportToExcel();
    }
    void tkckb_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + tkckb.OutputFileName + "\",'_blank')</script>");

    }
     
    void bindKhoa()
    {
        string sql = @"select * from phongkhambenh pk 
                        where pk.loaiphong <> 1 order by pk.tenphongkhambenh";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPhongKhoa, dt, "idphongkhambenh", "tenphongkhambenh", "__Phòng/khoa__");
        ddlPhongKhoa.SelectedValue = "1";
    }
     
     


}

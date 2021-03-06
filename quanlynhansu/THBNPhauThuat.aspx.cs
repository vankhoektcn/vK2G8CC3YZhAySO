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
using System.Data.SqlClient;
public partial class THBNPhauThuat : Page
{
    clsTHBNPhauThuat THNC = null;
    string tungay = "";
    string denngay = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            BindListPhongBan();
            txttungay.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtdenngay.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
        }
    }

    private void BindListPhongBan()
    {
        string sql = "select * from kb_phong where dichvuKCB=2003";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count >= 0)
        {
            StaticData.FillCombo(ddlPhong, dt, "id", "tenphong", "------Chọn phòng mổ------");
        }

    }

    protected void btnGetDanhSach_Click(object sender, EventArgs e)
    {
        tungay = txttungay.Text;
        denngay =txtdenngay.Text ;
        THNC = new clsTHBNPhauThuat();
        THNC.tungay = tungay;
        THNC.denngay =denngay;
        THNC.phongban = ddlPhong.SelectedValue.ToString();
        THNC.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(THNC_AfterExportToExcel);
        THNC.ExportToExcel();
    }

    void THNC_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" +THNC.OutputFileName + "\",'_blank')</script>");
    }
}

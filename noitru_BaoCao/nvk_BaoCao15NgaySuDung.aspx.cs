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
public partial class nvk_BaoCao15NgaySuDung : Genaratepage
{
    private clsBaCaoSuDung bbkn;
    string dkmenu = "tiepnhan";
    protected void Page_Load(object sender, EventArgs e)
    {

        LoadMenu();
        if (!this.IsPostBack)
        {
            if (DateTime.Now.Day <= 15)
            {
                txtTuNgay.Text = FirstDayOfMonth();
                txtDenNgay.Text = Day15thOfMonth();
            }
            else
            {
                txtTuNgay.Text = Day16thOfMonth();
                txtDenNgay.Text = LastDayOfMonth();
            }
            bindLoaiThuoc();
        }
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

    private string FirstDayOfMonth()
    {
        string Ngay = "";
        string thang = DateTime.Now.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = DateTime.Now.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        Ngay = "01/" + thang + "/" + nam;
        return Ngay;
    }
    private string LastDayOfMonth()
    {
        string Ngay = "";
        string day = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString();
        if (day.Length < 2)
            day = "0" + day;
        string thang = DateTime.Now.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = DateTime.Now.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        Ngay = day + "/" + thang + "/" + nam;
        return Ngay;
    }
    private string Day15thOfMonth()
    {
        string Ngay = "";
        string thang = DateTime.Now.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = DateTime.Now.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        Ngay = "15/" + thang + "/" + nam;
        return Ngay;
    }
    private string Day16thOfMonth()
    {
        string Ngay = "";
        string thang = DateTime.Now.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = DateTime.Now.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        Ngay = "16/" + thang + "/" + nam;
        return Ngay;
    }
    private void bindLoaiThuoc()
    {
        DataTable dt = DataAcess.Connect.GetTable("select * from Thuoc_LoaiThuoc");
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(this.chbLoaiThuoc, dt, "LoaithuocID", "TenLoai", "Tất cả các nhóm ");
        }
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        this.bbkn = new clsBaCaoSuDung();
        string[] temp = txtTuNgay.Text.ToString().Split('/');
        bbkn.ngayBD = temp[0];
        bbkn.thangBD = temp[1];
        bbkn.namBD = temp[2];
        bbkn.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bbkn_AfterExportToExcel);
        //DateTime DayBD = DateTime.Parse(StaticData.CheckDate(this.txtTuNgay.Text));
        //int ngay = DayBD.Day;
        bbkn.tungay = StaticData.CheckDate(this.txtTuNgay.Text);
        bbkn.denngay = StaticData.CheckDate(this.txtDenNgay.Text);
        bbkn.idkhoa = Request.QueryString["idkhoa"];
        bbkn.idloai = chbLoaiThuoc.SelectedValue.ToString();

        bbkn.ExportToExcel();
    }
    void bbkn_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + bbkn.OutputFileName + "\",'_blank')</script>");
    }
    
}


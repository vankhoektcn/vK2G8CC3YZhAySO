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

public partial class rpt_NhapXuatTon2 : System.Web.UI.Page
{
    _rpt_NhapXuatTon2 nhapxuatton = null;
    private string tungay = "";
    private string denngay = "";
    private string idThuoc = "";
    private string idKho = "";
    private string idKho2 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindkho();
            loadloaithuoc();
            txtTuNgay.Value = System.DateTime.Now.ToString("01/MM/yyyy");
            txtDenNgay.Value = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    #region bind kho
    private void bindkho()
    {
        string sqlSelect = "SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0";
        string idnguoidung = SysParameter.UserLogin.UserID(this);
        if (idnguoidung != null && idnguoidung != "" && !SysParameter.UserLogin.IsAdmin(this))
        {
            //sqlSelect += " AND IDKHO IN (SELECT IDKHO FROM KHOTHUOCNGUOIDUNG WHERE IDNGUOIDUNG=" + idnguoidung + ")";
        }

        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddl_khonhap, dt, "idkho", "tenkho", "----------Chọn kho-----------");
            StaticData.FillCombo(ddl_khoxuat, dt, "idkho", "tenkho", "----------Chọn kho-----------");

            this.txtTuNgay.Value = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtDenNgay.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }

        DataTable dtLoaiThuoc = DataAcess.Connect.GetTable("select * from Thuoc_LoaiThuoc");
        if (dtLoaiThuoc != null && dtLoaiThuoc.Rows.Count > 0)
        {
            StaticData.FillCombo(this.ddl_loaithuoc, dtLoaiThuoc, "LoaithuocID", "TenLoai", "Chọn đối tượng");
            string LoaiThuocID = Request["LoaiThuocID"];
            if (LoaiThuocID == null || LoaiThuocID == "") LoaiThuocID = "1";

            ddl_loaithuoc.SelectedValue = LoaiThuocID;
        }
        if (ddl_khoxuat.Items.Count == 2)
            this.ddl_khoxuat.SelectedIndex = 1;
    }
    #endregion
    #region get ten kho
    private string gettenkho(string idkho)
    {
        DataTable dt = DataAcess.Connect.GetTable("select tenkho from khothuoc where idkho = " + idkho);
        if (dt != null && dt.Rows.Count > 0)
        {
            return dt.Rows[0]["tenkho"].ToString();
        }
        else
        {
            return null;
        }
    }
    #endregion
    #region  bind loaithuoc
    private void loadloaithuoc()
    {

        StaticData.FillCombo(ddl_loaithuoc, Thuoc_Process.Thuoc_LoaiThuoc.dtGetAll(), "loaithuocid", "tenloai");
        string LoaiThuocID = Request["LoaiThuocID"];
        if (LoaiThuocID == null || LoaiThuocID == "") LoaiThuocID = "1";
        ddl_loaithuoc.SelectedValue = LoaiThuocID;
    }
    #endregion
    protected void btnTim_Click(object sender, EventArgs e)
    {
        if (this.ddl_khoxuat.SelectedValue == null || this.ddl_khoxuat.SelectedValue == "") return;
        string tungay = this.txtTuNgay.Value;
        if (tungay != "")
            tungay = StaticData.CheckDate(tungay);
        string denngay = this.txtDenNgay.Value;
        if (denngay != "")
            denngay = StaticData.CheckDate(denngay) + " 23:59:59";
        idKho = this.ddl_khoxuat.SelectedValue;
        idKho2 = this.ddl_khonhap.SelectedValue;
        nhapxuatton = new _rpt_NhapXuatTon2();
        nhapxuatton.FromDate = tungay;
        nhapxuatton.ToDate = denngay;
        nhapxuatton.IdKho = idKho;
        nhapxuatton.IdKho2 = idKho2;
        nhapxuatton.TenThuoc = this.txtTenThuoc.Text.Trim();
        nhapxuatton.LoaiThuocId = this.ddl_loaithuoc.SelectedValue;
        DataTable dt = nhapxuatton.getViewTable();
        this.dgr.DataSource = dt;
        this.dgr.DataBind();

    }
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        if (this.ddl_khoxuat.SelectedValue == null || this.ddl_khoxuat.SelectedValue == "") return;
        string tungay = this.txtTuNgay.Value;
        if (tungay != "")
            tungay = StaticData.CheckDate(tungay);
        string denngay = this.txtDenNgay.Value;
        if (denngay != "")
            denngay = StaticData.CheckDate(denngay) + " 23:59:59";
        idKho = this.ddl_khoxuat.SelectedValue;
        idKho2 = this.ddl_khonhap.SelectedValue;
        nhapxuatton = new _rpt_NhapXuatTon2();
        nhapxuatton.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        nhapxuatton.FromDate = tungay;
        nhapxuatton.ToDate = denngay;
        nhapxuatton.IdKho = idKho;
        nhapxuatton.IdKho2 = idKho2;
        nhapxuatton.TenThuoc = this.txtTenThuoc.Text.Trim();
        nhapxuatton.LoaiThuocId = this.ddl_loaithuoc.SelectedValue;
        nhapxuatton.ExportToExcel();
    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../../ReportOutput/" + nhapxuatton.OutputFileName + "\",'_blank')</script>");

    }
}

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
using System.Globalization;
public partial class quanlynhansu_DanhSachNhanVienLamViec : Page
{    
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {           
            SetValueEmpty();
            BindddlPhongBan();         
        }
    }
    #region "U Function"

    private void BindddlPhongBan()
    {
        string strSQL = "select idphongban,maphongban+'_'+tenphongban as tenphongban from phongban where status=1";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlPhongBan, dt, "idphongban", "tenphongban", "--Chọn khóa đào tạo--");
    }
   
    
    private void SetValueEmpty()
    {
        ddlPhongBan.SelectedIndex = 0;
        txtNgayLamViec.Text = DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        string strSearch = "";  
        bindGirdView(strSearch);
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();      
        StaticData.SetFocus(this, "txtNgayLamViec");
    }
    private void BindCTPhieu(DataTable dtSRC)
    {
        if (dtSRC == null) return;
        dgr.DataSource = dtSRC;
        dgr.DataBind();
    }
    #endregion
    #region "Grid Event"
    void bindGirdView(string strSearch)
    {
        if (ddlPhongBan.SelectedValue != "0")
            strSearch += " and nv.idphongban ='" + ddlPhongBan.SelectedValue + "' ";
        if (txtNgayLamViec.Text.Trim() != "")
        {
            try
            {
                //DateTime date = DateTime.ParseExact(txtNgayLamViec.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                strSearch += " and bcc.ngaycong >='" + StaticData.CheckDate(txtNgayLamViec.Text.Trim()) + " 00:00:00' ";
                strSearch += " and bcc.ngaycong <='" + StaticData.CheckDate(txtNgayLamViec.Text.Trim()) + " 23:59:59' ";
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Ngày không hợp lệ. Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtNgayLamViec");
                return;
            }
        }
        string sql = @"select row_number() over(order by nv.tennhanvien)as stt,nv.idnhanvien,bcc.idchamcongtheongay,nv.manhanvien,nv.tennhanvien
        ,convert(varchar,nv.ngaysinh,103)as ngaysinh,case when nv.gioitinh=0 then 'Nam' else N'Nữ' end gioitinh,nv.diachithuongtru,nv.cmnd
        from bangchamcongtheongay bcc
        inner join nhanvien nv on nv.idnhanvien=bcc.idnhanvien and nv.status=1  
        " + strSearch;        
        DataTable tb = DataAcess.Connect.GetTable(sql);
        dgr.DataSource = tb;
        dgr.DataBind();
    }
   
    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
       
    }
   
    #endregion    
    
    //TRUONGNHAT-PC
    //xuat du lieu ra exel
   
    protected void imgInExel_Click(object sender, EventArgs e)
    {
        string filename = "DSNhanVienLamViec";
        string tcty = "BỆNH VIỆN MINH ĐỨC";
        string khoa = "Phòng Nhân Sự";
        string header = "DANH SÁCH NHÂN VIÊN LÀM VIỆC";
        string strNhanSu = "GĐ.Nhân Sự";
        clsExport.exprortToExcelDataGrid(filename, tcty, khoa, header, dgr, strNhanSu);
    }
    protected void ddlKhoaDaoTao_SelectedIndexChanged(object sender, EventArgs e)
    {
         bindGirdView("");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}

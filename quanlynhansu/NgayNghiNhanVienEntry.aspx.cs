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
public partial class NgayNghiNhanVienEntry : Page
{
   static string strSearch;
    SqlConnection conn = DataAcess.Connect.Conn;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListNhanVien();
            BindListNgayNghiNhanVien("");
            StaticData.SetFocus(this, "ddlNhanVien");
        }
    }
    #region "U Function"
    private void BindListNhanVien()
    {
        string strSQL = "SELECT *,Ma_Ten=tennhanvien+'_'+manhanvien FROM nhanvien where status='1' ORDER BY tennhanvien";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlNhanVien, dt, "idnhanvien", "Ma_Ten", "--Chọn Nhân Viên--");
    }
    private void SetValueEditPC(DataTable dtSRC)
    {
        ddlNhanVien.SelectedValue = dtSRC.Rows[0]["idnhanvien"].ToString();
        txtmaphieu.Value = dtSRC.Rows[0]["idngaynghinhanvien"].ToString();
        txtSoTien.Text = dtSRC.Rows[0]["truluong"].ToString();
        txtNgayBatDau.Text = dtSRC.Rows[0]["ngayBD"].ToString();
        txtNgayKetThuc.Text = dtSRC.Rows[0]["ngayKT"].ToString();
        txtLyDo.Text = dtSRC.Rows[0]["lydo"].ToString();
        txtSoNgayNghi.Text = dtSRC.Rows[0]["songaynghi"].ToString();
        StaticData.SetFocus(this, "ddlNhanVien"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int idngaynghinhanvien)
    {
        string strSQL = "SELECT *,convert(nvarchar,ngaybatdau,103) as ngayBD,convert(nvarchar,ngayketthuc,103) as ngayKT FROM ngaynghinhanvien WHERE status='true' and idngaynghinhanvien = " + idngaynghinhanvien;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListNgayNghiNhanVien(string sWhere)
    {
        string strSQL = "SELECT ROW_NUMBER()OVER (ORDER BY nv.idnhanvien) AS STT,P.*,Ma_Ten=nv.tennhanvien+'_'+nv.manhanvien,convert(nvarchar,ngaybatdau,103) as ngayBD,convert(nvarchar,ngayketthuc,103) as ngayKT FROM ngaynghinhanvien p ";
        strSQL += " left join nhanvien nv on p.idnhanvien=nv.idnhanvien";
        strSQL += " WHERE  p.status='1' and nv.status='1' " + sWhere;
       // strSQL += " ORDER BY nv.tennhanvien,p.ngaybatdau";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (ddlNhanVien.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn Nhân viên. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "ddlNhanVien");
            return false;
        }
        if (txtSoNgayNghi.Text != "")
        {
            try
            {
                int.Parse(txtSoNgayNghi.Text.Trim().Replace(",", "").Replace(".", ""));
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Số ngày nghỉ không hợp lệ. Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtSoNgayNghi");
                return false;
            }
        }
        
        if (txtNgayBatDau.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập Ngày bắt đầu. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNgayBatDau");
            return false;
        }
        try
        {
            DateTime date = DateTime.ParseExact(txtNgayBatDau.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Ngày bắt đầu không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNgayBatDau");
            return false;
        }
        if (txtNgayKetThuc.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập Ngày kết thúc. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNgayKetThuc");
            return false;
        }
        try
        {
            DateTime date = DateTime.ParseExact(txtNgayKetThuc.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Ngày kết thúc không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNgayKetThuc");
            return false;
        }
        if (txtSoTien.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập số tiền. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtSoTien");
            return false;
        }
        try
        {
            float.Parse(txtSoTien.Text.Trim().Replace(",", "").Replace(".", ""));
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Số tiền không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtSoTien");
            return false;
        }
        
        return true;
    }
    private void SetValueEmpty()
    {
        ddlNhanVien.SelectedValue = "0";
        txtSoNgayNghi.Text = "";
        txtSoTien.Text = "";
        txtNgayBatDau.Text = "";
        txtNgayKetThuc.Text = "";
        txtLyDo.Text = "";
        strSearch = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            
                //Lấy id 
            string id = StaticData.MaxIdNhanSuTheoTable("ngaynghinhanvien", "idngaynghinhanvien");
            //thêm 
            NhanSu_Process.NgayNghiNhanVien CV = NhanSu_Process.NgayNghiNhanVien.Insert_Object(id, ddlNhanVien.SelectedValue, StaticData.CheckDate(txtNgayBatDau.Text.Trim()), StaticData.CheckDate(txtNgayKetThuc.Text.Trim()), txtSoNgayNghi.Text.Trim(), txtLyDo.Text.Trim(), txtSoTien.Text.Replace(",", "").Replace(",", ""), "1");
            if (CV == null)
            {
                StaticData.MsgBox(this, "Vui lòng thử lại sau !");
                return;
            }
            else
            {
                StaticData.MsgBox(this, "Lưu thành công!.");
                BindListNgayNghiNhanVien("");
                SetValueEmpty();
                StaticData.SetFocus(this, "ddlNhanVien");
            }
            
        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtmaphieu.Value);
            NhanSu_Process.NgayNghiNhanVien CV = new NhanSu_Process.NgayNghiNhanVien();
            CV.idngaynghinhanvien = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(),ddlNhanVien.SelectedValue, StaticData.CheckDate(txtNgayBatDau.Text.Trim()), StaticData.CheckDate(txtNgayKetThuc.Text.Trim()), txtSoNgayNghi.Text.Trim(), txtLyDo.Text.Trim(), txtSoTien.Text.Replace(",", "").Replace(",", ""), "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Đã cập nhật !");
                BindListNgayNghiNhanVien("");
                SetValueEmpty();
                VisibleBtn(true);
            }
            else
                StaticData.MsgBox(this, "Vui lòng thử lại sau !");
            StaticData.SetFocus(this, "ddlNhanVien");

        }
    }
    protected void btnTim_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = "";
        if (ddlNhanVien.SelectedValue != "0")
            strSearch += " and p.idnhanvien ='" + ddlNhanVien.SelectedValue + "' ";
        if (txtSoTien.Text.Trim() != "")
            strSearch += " and p.truluong ='" + txtSoTien.Text.Trim() + "' ";
        if (txtLyDo.Text.Trim() != "")
            strSearch += " and p.lydo ='" + txtLyDo.Text.Trim() + "' ";
        if (txtSoNgayNghi.Text.Trim() != "")
            strSearch += " and p.songaynghi ='" + txtSoNgayNghi.Text.Trim() + "' ";
        if (txtNgayBatDau.Text.Trim() != "")
        {
            try
            {
                DateTime date = DateTime.ParseExact(txtNgayBatDau.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                strSearch += " and p.ngaybatdau >='" + StaticData.CheckDate(txtNgayBatDau.Text.Trim()) + " 00:00:00' ";
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Ngày bắt đầu không hợp lệ. Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtNgayBatDau");
                return;
            }
        }
        if (txtNgayKetThuc.Text.Trim() != "")
        {
            try
            {
                DateTime date = DateTime.ParseExact(txtNgayKetThuc.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                strSearch += " and p.ngayketthuc <='" + StaticData.CheckDate(txtNgayKetThuc.Text.Trim()) + " 23:59:59' ";
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Ngày kết thúc không hợp lệ. Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtNgayKetThuc");
                return;
            }
        }
        //string Search = "SELECT * FROM chucvu  WHERE status='true' "+strSearch;
        BindListNgayNghiNhanVien(strSearch);
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtmaphieu.Value = "";
        VisibleBtn(true);
        StaticData.SetFocus(this, "ddlNhanVien");
    }
    private void BindCTPhieu(DataTable dtSRC)
    {
        if (dtSRC == null) return;
        dgr.DataSource = dtSRC;
        dgr.DataBind();
    }
    #endregion
    #region "Grid Event"
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        int imaphong;

        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        txtmaphieu.Value = imaphong.ToString();
        DataTable dtEdit = LoaDdataEdit(imaphong);
        SetValueEditPC(dtEdit);
        VisibleBtn(false);
        
    }
    public void Dellete(object s, DataGridCommandEventArgs e)
    {
        int imaphong;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string sqlDelete = "delete ngay  where idngaynghinhanvien=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListNgayNghiNhanVien(strSearch);

        }
        else
            StaticData.MsgBox(this, "Có lỗi khi xóa !");
    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            btn = (LinkButton)(e.Item.Cells[0].FindControl("lbtnDel"));
            btn.Attributes.Add("onclick", "return ConfirmDelete();");
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
            }
            else
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
            }
        }
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            
        }
    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BindListNgayNghiNhanVien(strSearch);
    }
    #endregion    
    
    //TRUONGNHAT-PC
    //xuat du lieu ra exel
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void imgInExel_Click(object sender, ImageClickEventArgs e)
    {
        string filename = "DSNhanVien";
        string tcty = "BỆNH VIỆN MINH ĐỨC";
        string khoa = "Phòng Nhân Sự";
        string header = "DANH SÁCH NHÂN VIÊN NGHỈ PHÉP";
        string strNhanSu = "GĐ.Nhân Sự";
        clsExport.exprortToExcelDataGrid(filename, tcty, khoa, header, dgr, strNhanSu);
    }
}

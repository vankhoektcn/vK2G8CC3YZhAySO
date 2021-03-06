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
using System.Globalization;
using System.IO;
using System.Drawing;

public partial class nhanvienentry : Page
{
   string strSearch;
    clsDanhSachNhanVien dsnv = null;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListChucVu();
            BindListPhongKham();
            BindListNhanVien("");
            StaticData.SetFocus(this, "txtMaNhanVien");
            txtNgayVaoLam.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    #region "U Function"
    private void BindListChucVu()
    {
        string strsql = "SELECT * FROM chucvu where status=1";
        DataTable dt = DataAcess.Connect.GetTable(strsql);
        StaticData.FillCombo(ddlchucvu, dt, "idchucvu", "tenchucvu", "--Chọn chức vụ--");
    }

    private void BindListPhongKham()
    {
        string strSQL = "SELECT * FROM phongban  where status=1 ORDER BY tenphongban";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlPhongKham, dt, "idphongban", "tenphongban", "--Chọn phòng ban--");
    }
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtMaNhanVien.Text = dtSRC.Rows[0]["manhanvien"].ToString();
        txtMaNhanVien.ReadOnly = true;
        txtTenNhanVien.Text = dtSRC.Rows[0]["tennhanvien"].ToString();
        txtDienThoai.Text = dtSRC.Rows[0]["dienthoai"].ToString();
        txtDiDong.Text = dtSRC.Rows[0]["didong"].ToString();
        txtDiaChiTamTru.Text = dtSRC.Rows[0]["diachitamtru"].ToString();
        txtDiaChiThuongTru.Text = dtSRC.Rows[0]["diachithuongtru"].ToString();
        txtEmail.Text = dtSRC.Rows[0]["email"].ToString();
        ddlGioiTinh.SelectedIndex = ddlGioiTinh.Items.IndexOf(ddlGioiTinh.Items.FindByValue(dtSRC.Rows[0]["gioitinh"].ToString()));
        ddlHonNhan.SelectedIndex = ddlHonNhan.Items.IndexOf(ddlHonNhan.Items.FindByValue(dtSRC.Rows[0]["tinhtranghonnhan"].ToString()));
        ddlPhongKham.SelectedIndex = ddlPhongKham.Items.IndexOf(ddlPhongKham.Items.FindByValue(dtSRC.Rows[0]["idphongban"].ToString()));
        txtMaNhanVien_edit.Value = dtSRC.Rows[0]["idnhanvien"].ToString();
        txtngaysinh.Text = dtSRC.Rows[0]["sinhnhat"].ToString();
        txtNgayVaoLam.Text = dtSRC.Rows[0]["ngaylam"].ToString();
        ddlchucvu.SelectedIndex = ddlchucvu.Items.IndexOf(ddlchucvu.Items.FindByValue(dtSRC.Rows[0]["idchucvu"].ToString()));

        ddlLoaiNhanVien.SelectedValue = dtSRC.Rows[0]["LoaiNhanVien"].ToString().Trim();
        txtCMND.Text = dtSRC.Rows[0]["cmnd"].ToString();
        txtTrinhDo.Text = dtSRC.Rows[0]["TrinhDo"].ToString();
        txtChuyenmon.Text = dtSRC.Rows[0]["chuyenmon"].ToString();
        txtNoiCapCMND.Text = dtSRC.Rows[0]["noicapCMND"].ToString();
        txtNgayCapCMND.Text = dtSRC.Rows[0]["ngaycapCMND1"].ToString();
        StaticData.SetFocus(this, "txtTenNhanVien"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int imaphong)
    {
        string strSQL = "SELECT nv.*,convert(nvarchar, ngaycapCMND, 103) as ngaycapCMND1, convert(nvarchar, ngaysinh, 103) as sinhnhat,convert(nvarchar, ngayvaolam, 103) as ngaylam FROM nhanvien nv WHERE idnhanvien = " + imaphong;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListNhanVien(string sWhere)
    {
        string strSQL = "SELECT ROW_NUMBER ( ) OVER(ORDER BY pk.tenphongban) AS STT,nv.*, pk.tenphongban, convert(nvarchar, ngaysinh, 103) as sinhnhat,convert(nvarchar, ngayvaolam, 103) as ngaylam, isnull(tenchucvu, N'Bác sĩ') as tenchucvu ";
        strSQL += ",case when tinhtranghonnhan=0 then N'Độc thân' when tinhtranghonnhan=1 then N'Có gia đình' end as honnhan ";
        strSQL += " ,case when gioitinh=0 then N'Nam' when gioitinh=1 then N'Nữ' end as gioitinh1 ,convert(nvarchar, ngaycapCMND, 103) as ngaycapCMND1";
        strSQL += " ,case when loaiNhanVien=0 then N'Thường xuyên' when loaiNhanVien=1 then N'Không thường xuyên' end as LoaiNV";
        strSQL += " FROM nhanvien nv LEFT JOIN phongban pk ON nv.idphongban = pk.idphongban";
        strSQL += " LEFT JOIN chucvu cv ON nv.idchucvu = cv.idchucvu ";
        strSQL += " WHERE nv.status=1 " + sWhere;
        strSQL += " ORDER BY pk.tenphongban";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
        if (dtCTPhieu.Rows.Count > 0)
            lbTongSoNV.Text = "Tìm thấy " + dtCTPhieu.Rows.Count + " Nhân Viên trong danh sách";
        else
            lbTongSoNV.Text = "Không tìm thấy Nhân Viên";
    }
    private bool CheckValid(int isadd)
    {
        
        if (txtTenNhanVien.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập tên nhân viên. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtTenNhanVien");
            return false;
        }
        if (txtngaysinh.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập ngày sinh. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtngaysinh");
            return false;
        }
        try
        {
            DateTime date = DateTime.ParseExact(txtngaysinh.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Ngày sinh không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtngaysinh");
            return false;
        }
        if (ddlGioiTinh.SelectedValue == "" || ddlPhongKham.SelectedValue == "-1")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn giới tính. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "ddlGioiTinh");
            return false;
        }
        if (txtNgayVaoLam.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập ngày nhân viên vào làm. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNgayVaoLam");
            txtNgayVaoLam.Text = DateTime.Now.ToString("dd/MM/yyyy");
            return false;
        }
        try
        {
            DateTime date = DateTime.ParseExact(txtNgayVaoLam.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Ngày vào làm không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNgayVaoLam");
            return false;
        }
        //try
        //{
        //    DateTime date = DateTime.ParseExact(txtNgayCapCMND.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        //}
        //catch (Exception)
        //{
        //    StaticData.MsgBox(this, "Ngày vào cấp CMND không hợp lệ. Vui lòng kiểm tra lại.");
        //    StaticData.SetFocus(this, "txtNgayCapCMND");
        //    return false;
        //}
        if (ddlHonNhan.SelectedValue == "" || ddlHonNhan.SelectedValue == "-1")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn tình trạng hôn nhân. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "ddlHonNhan");
            return false;
        }
        if (txtDiaChiTamTru.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập địa chỉ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtDiaChiTamTru");
            return false;
        }
        if (ddlLoaiNhanVien.SelectedValue == "" || ddlLoaiNhanVien.SelectedValue == "-1")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn loại nhân viên. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "ddlLoaiNhanVien");
            return false;
        }
        if (ddlPhongKham.SelectedValue == "" || ddlPhongKham.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn phòng làm việc của nhân viên. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "ddlPhongKham");
            return false;
        }
        if (ddlchucvu.SelectedValue == "" || ddlchucvu.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn chức vụ nhân viên. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "ddlchucvu");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txtMaNhanVien.Text = "";
        txtTenNhanVien.Text = "";
        txtDienThoai.Text = "";
        txtDiDong.Text = "";
        txtDiaChiTamTru.Text = "";
        txtDiaChiThuongTru.Text = "";
        txtngaysinh.Text = "";
        txtEmail.Text = "";
        txtNgayVaoLam.Text = "";
        ddlPhongKham.SelectedValue = "0";
        ddlchucvu.SelectedValue = "0";
        ddlGioiTinh.SelectedValue = "-1";
        ddlHonNhan.SelectedValue = "-1";

        ddlLoaiNhanVien.SelectedValue = "-1";
        txtTrinhDo.Text = "";
        txtChuyenmon.Text = "";
        txtCMND.Text = "";
        txtNgayCapCMND.Text = "";
        txtNoiCapCMND.Text = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
             string ngayTN = DateTime.Now.ToString("dd/MM/yyyy").Replace("/","");
            txtMaNhanVien.Text= StaticData.CreateIDTheoThuTuTN("NV","nhanvien","manhanvien","idnhanvien",ngayTN);
            if (!StaticData.CheckExist("nhanvien", "manhanvien", txtMaNhanVien.Text.Trim()))
            {
                string maNhanVien = txtMaNhanVien.Text.Trim();
                string tenNhanVien = txtTenNhanVien.Text.Trim();
                string dienThoai = txtDienThoai.Text.Trim();
                string diDong = txtDiDong.Text.Trim();
                string email = txtEmail.Text.Trim();
                string diaChiTamTru = txtDiaChiTamTru.Text.Trim();
                string diaChiThuongTru = txtDiaChiThuongTru.Text.Trim();
                int idchucVu = StaticData.ParseInt(ddlchucvu.SelectedValue);
                string ngaySinh;
                if (txtngaysinh.Text == "")
                    ngaySinh = DBNull.Value.ToString();
                else
                    ngaySinh = StaticData.CheckDate(txtngaysinh.Text);
                string ngayVaoLam;
                if (txtNgayVaoLam.Text == "")
                    ngayVaoLam = DBNull.Value.ToString();
                else
                    ngayVaoLam = StaticData.CheckDate(txtNgayVaoLam.Text);
                string gioiTinh = ddlGioiTinh.SelectedValue;
                string tinhTrangHonNhan = ddlHonNhan.SelectedValue;
                int idPhongBan = StaticData.ParseInt(ddlPhongKham.SelectedValue);
                //
                string LoaiNhanVien=ddlLoaiNhanVien.SelectedValue;
                    string TrinhDo=txtTrinhDo.Text;
                string CMND=txtCMND.Text;
                    string NgayCapCMND=StaticData.CheckDate(txtNgayCapCMND.Text);
                string NoiCapCMND=txtNoiCapCMND.Text;
                string chuyenmon = txtChuyenmon.Text;
                //Lấy id 
                int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idnhanvien),0)+1 as MaxID from nhanvien ").Rows[0][0].ToString());
                //Thêm Nhân Viên
                NhanSu_Process.NhanVien NV = NhanSu_Process.NhanVien.Insert_Object(id.ToString(), maNhanVien, tenNhanVien,
                    ngaySinh, gioiTinh, diaChiTamTru, dienThoai, diDong, diaChiThuongTru, email, tinhTrangHonNhan,
                    ngayVaoLam, idPhongBan.ToString(), idchucVu.ToString(), "1","","",CMND,NgayCapCMND,NoiCapCMND
                    ,"",null,"","","Nơi Sinh",TrinhDo,chuyenmon,LoaiNhanVien
                    );
                if (NV == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin nhân viên. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Thêm Nhân Viên thành công !.");
                    BindListNhanVien("");
                    strSearch = "";
                    SetValueEmpty();
                    StaticData.SetFocus(this, "txtMaNhanVien");
                }
            }
            else
            {
                StaticData.MsgBox(this, "Mã nhân viên này đã tồn tại trong cơ sở dữ liệu rồi. Vui lòng kiểm tra lại.");
                return;
            }
            

        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtMaNhanVien_edit.Value);
            string maNhanVien = txtMaNhanVien.Text.Trim();
            string tenNhanVien = txtTenNhanVien.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();
            string diDong = txtDiDong.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChiTamTru = txtDiaChiTamTru.Text.Trim();
            string diaChiThuongTru = txtDiaChiThuongTru.Text.Trim();
            int idchucVu = StaticData.ParseInt(ddlchucvu.SelectedValue);
            string ngaySinh;
            if (txtngaysinh.Text == "")
                ngaySinh = DBNull.Value.ToString();
            else
                ngaySinh = StaticData.CheckDate(txtngaysinh.Text);
            string ngayVaoLam;
            if (txtNgayVaoLam.Text == "")
                ngayVaoLam = DBNull.Value.ToString();
            else
                ngayVaoLam = StaticData.CheckDate(txtNgayVaoLam.Text);
            string gioiTinh = ddlGioiTinh.SelectedValue;
            string tinhTrangHonNhan = ddlHonNhan.SelectedValue;
            int idPhongBan = StaticData.ParseInt(ddlPhongKham.SelectedValue);
            //
            string LoaiNhanVien = ddlLoaiNhanVien.SelectedValue;
            string TrinhDo = txtTrinhDo.Text;
            string CMND = txtCMND.Text;
            string NgayCapCMND = StaticData.CheckDate(txtNgayCapCMND.Text);
            string NoiCapCMND = txtNoiCapCMND.Text;
            string chuyenmon = txtChuyenmon.Text;
            //Lấy id 
            int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idnhanvien),0)+1 as MaxID from nhanvien ").Rows[0][0].ToString());
            //Thêm Nhân Viên
            NhanSu_Process.NhanVien NV = new NhanSu_Process.NhanVien();
            NV.idnhanvien = imahh.ToString();
            bool kt = NV.Save_Object(id.ToString(), maNhanVien, tenNhanVien,
                  ngaySinh, gioiTinh, diaChiTamTru, dienThoai, diDong, diaChiThuongTru, email, tinhTrangHonNhan,
                  ngayVaoLam, idPhongBan.ToString(), idchucVu.ToString(), "1", "", "", CMND, NgayCapCMND, NoiCapCMND
                  , "", null, "", "", "Nơi Sinh", TrinhDo,chuyenmon, LoaiNhanVien
                  );
              if (kt)
              {
                  StaticData.MsgBox(this, "Cập nhật thông tin nhân viên thành công.");

                  BindListNhanVien(strSearch);
                  SetValueEmpty();
                  VisibleBtn(true);
                  txtMaNhanVien.ReadOnly = false;
                  StaticData.SetFocus(this, "txtMaNhanVien");
              }
            else
                  StaticData.MsgBox(this, "Hệ thống đang bận.Vui lòng thử lại sau.");
        }
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtMaNhanVien.ReadOnly = false;
        VisibleBtn(true);
        
        StaticData.SetFocus(this, "txtMaNhanVien");
    }
    //TRUONGNHAT-PC
    //xuat du lieu ra exel
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void imgInExel_Click(object sender, ImageClickEventArgs e)
    {
        string sWhere = GetChuoiSearch();
        string strSQL = "SELECT  ROW_NUMBER ( ) OVER(ORDER BY pk.tenphongban) AS STT,nv.manhanvien,nv.tennhanvien,nv.TrinhDo,nv.chuyenmon,cv.tenchucvu, ";
        strSQL+=" convert(nvarchar,nv.ngaysinh,103), ";
        strSQL+="case when nv.gioitinh=0 then N'Nam' when nv.gioitinh=1 then N'Nữ' end as gioitinh,nv.diachitamtru,nv.diachithuongtru,nv.cmnd, ";
        strSQL+=" convert(nvarchar, nv.ngaycapCMND, 103) as ngaycapCMND, ";
        strSQL += " nv.noicapCMND,case when nv.tinhtranghonnhan=0 then N'Độc thân' when nv.tinhtranghonnhan=1 then N'Có gia đình' end as honnhan, pk.tenphongban as phongban,'' as tong";
        strSQL += " FROM nhanvien nv LEFT JOIN phongban pk ON nv.idphongban = pk.idphongban";
        strSQL += " LEFT JOIN chucvu cv ON nv.idchucvu = cv.idchucvu ";
        strSQL += " WHERE nv.status=1 " + sWhere;
        strSQL += " ORDER BY pk.tenphongban";

        dsnv = new clsDanhSachNhanVien();
        dsnv.search = strSQL;
        dsnv.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(DSNV_AfterExportToExcel);
        dsnv.ExportToExcel();
    }
    void DSNV_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + dsnv.OutputFileName + "\",'_blank')</script>");
    }
  
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        dgr.CurrentPageIndex = 0;
        strSearch = GetChuoiSearch();
        BindListNhanVien(strSearch);
    }
    private string GetChuoiSearch()
    {
        string skq = "";
        if (txtMaNhanVien.Text != "")
        {
            skq += " AND nv.manhanvien = '" + txtMaNhanVien.Text.Trim() + "' ";
            return skq;
        }
        if (txtTenNhanVien.Text != "")
        {
            skq += " AND nv.tennhanvien LIKE N'%" + txtTenNhanVien.Text.Trim() + "%' ";
        }
        if (txtDienThoai.Text != "")
        {
            skq += " AND nv.dienthoai LIKE '%" + txtDienThoai.Text.Trim() + "%' ";
        }
        if (txtDienThoai.Text != "")
        {
            skq += " AND nv.didong LIKE '%" + txtDiDong.Text.Trim() + "%' ";
        }
        if (txtDiDong.Text != "")
        {
            skq += " AND nv.diachithuongtru LIKE N'%" + txtDiDong.Text.Trim() + "%' ";
        }
        if (txtDiaChiTamTru.Text != "")
        {
            skq += " AND nv.diachitamtru LIKE N'%" + txtDiaChiTamTru.Text.Trim() + "%' ";
        }
        if (txtDiaChiThuongTru.Text != "")
        {
            skq += " AND nv.diachithuongtru LIKE N'%" + txtDiaChiThuongTru.Text.Trim() + "%' ";
        }
        if (ddlGioiTinh.SelectedValue != "-1" && ddlGioiTinh.SelectedValue != "")
        {
            skq += " AND nv.gioitinh = " + ddlGioiTinh.SelectedValue;
        }
        if (ddlHonNhan.SelectedValue != "-1" && ddlHonNhan.SelectedValue != "")
        {
            skq += " AND nv.tinhtranghonnhan = " + ddlHonNhan.SelectedValue;
        }
        if (ddlPhongKham.SelectedValue != "0" && ddlPhongKham.SelectedValue != "")
        {
            skq += " AND nv.idphongban = " + ddlPhongKham.SelectedValue;
        }
        if (ddlchucvu.SelectedValue != "0" && ddlchucvu.SelectedValue != "")
        {
            skq += " AND nv.idchucvu = " + ddlchucvu.SelectedValue;
        }

        if (ddlLoaiNhanVien.SelectedValue != "-1" && ddlLoaiNhanVien.SelectedValue != "")
        {
            skq += " AND nv.LoaiNhanVien = '" + ddlLoaiNhanVien.SelectedValue+"'";
        }
        if (txtTrinhDo.Text != "")
        {
            skq += " AND nv.trinhdo LIKE N'%" + txtTrinhDo.Text.Trim() + "%' ";
        }
        if (txtChuyenmon.Text != "")
        {
            skq += " AND nv.chuyenmon LIKE N'%" + txtChuyenmon.Text.Trim() + "%' ";
        }
        if (txtCMND.Text != "")
        {
            skq += " AND nv.cmnd ='" + txtCMND.Text.Trim() + "' ";
        }
        if (txtNoiCapCMND.Text != "")
        {
            skq += " AND nv.noicapCMND LIKE N'%" + txtNoiCapCMND.Text.Trim() + "%' ";
        }
        if (txtNgayCapCMND.Text != "")
        {
            skq += " AND (convert,nv.ngaycapCMND,103) ='" + txtNgayCapCMND.Text.Trim() + "' ";
        }
        return skq;
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
        txtMaNhanVien_edit.Value = imaphong.ToString();
        DataTable dtEdit = LoaDdataEdit(imaphong);
        SetValueEditPC(dtEdit);
        VisibleBtn(false);
        
    }
    public void DelNhanVien(object s, DataGridCommandEventArgs e)
    {
          int imaphong;
            imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
            string sqlDelete = "delete nhanvien  where idnhanvien=" + imaphong;
            bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
            if (kt)
            {
                StaticData.MsgBox(this, "Đã xóa !");
                BindListNhanVien(strSearch);
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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //e.Item.Cells[8].Text = StaticData.FormatNumber(e.Item.Cells[8].Text, false).ToString();
            }
        }
        
    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BindListNhanVien(strSearch);
    }
    #endregion    
  
    
}

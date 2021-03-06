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
public partial class TienPhuCapEntry : Page
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
            BindListPhuCap();
            BindListTienPhuCap("");
            StaticData.SetFocus(this, "ddlNhanVien");
        }
    }
    #region "U Function"
    private void BindListPhuCap()
    {
        string strSQL = "SELECT * from phucap where status='1' ORDER BY tenphucap";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlPhuCap, dt, "idphucap", "tenphucap", "--Chọn phụ cấp--");
    }
    private void BindListNhanVien()
    {
        string strSQL = "SELECT *,Ma_Ten=tennhanvien+'_'+manhanvien FROM nhanvien where status='1' ORDER BY tennhanvien";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlNhanVien, dt, "idnhanvien", "Ma_Ten", "--Chọn Nhân Viên--");
    }
    private void SetValueEditPC(DataTable dtSRC)
    {
        ddlNhanVien.SelectedValue = dtSRC.Rows[0]["idnhanvien"].ToString();
        ddlPhuCap.SelectedValue = dtSRC.Rows[0]["idphucap"].ToString();
        //txtMaLoaiNgayNghi.Enabled = false;
        txtmaphieu.Value = dtSRC.Rows[0]["idtienphucap"].ToString();
        txtSoTien.Text = dtSRC.Rows[0]["tienphucap"].ToString();
        txtNgay.Text = dtSRC.Rows[0]["ngay"].ToString();
        txtSoLuong.Text = dtSRC.Rows[0]["soluong"].ToString();
        StaticData.SetFocus(this, "ddlNhanVien"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int idphanca)
    {
        string strSQL = "SELECT *,convert(nvarchar,thangnam,103) as ngay FROM tienphucap WHERE status='true' and idtienphucap = " + idphanca;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListTienPhuCap(string sWhere)
    {
        string strSQL = "SELECT P.*,Ma_Ten=nv.tennhanvien+'_'+nv.manhanvien,pc.tenphucap,convert(nvarchar,thangnam,103) as ngay FROM tienphucap p ";
        strSQL += " left join nhanvien nv on p.idnhanvien=nv.idnhanvien";
        strSQL += " left join phucap pc on p.idphucap=pc.idphucap";
        strSQL += " WHERE  p.status='1' and nv.status='1' and pc.status='1'" + sWhere;
        strSQL += " ORDER BY nv.tennhanvien,p.thangnam";
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
        if (ddlPhuCap.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn Phụ cấp. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "ddlPhuCap");
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
            StaticData.MsgBox(this, "Số tiền. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtSoTien");
            return false;
        }
        if (txtSoLuong.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập số lượng. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtSoLuong");
            return false;
        }
        try
        {
            int.Parse(txtSoLuong.Text.Trim().Replace(",", "").Replace(".", ""));
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Số lượng không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtSoLuong");
            return false;
        }
        if (txtNgay.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập Ngày. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNgay");
            return false;
        }
        try
        {
            DateTime date = DateTime.ParseExact(txtNgay.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Ngày không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNgay");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        ddlNhanVien.SelectedValue = "0";
        ddlPhuCap.SelectedValue = "0";
        txtSoTien.Text = "";
        txtNgay.Text = "";
        txtSoLuong.Text = "";
        strSearch = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            
                //Lấy id 
            string id = StaticData.MaxIdNhanSuTheoTable("tienphucap", "idtienphucap");
            //thêm 
            NhanSu_Process.TienPhuCap CV = NhanSu_Process.TienPhuCap.Insert_Object(id, ddlNhanVien.SelectedValue, ddlPhuCap.SelectedValue, StaticData.CheckDate(txtNgay.Text.Trim()), txtSoLuong.Text.Trim(), txtSoTien.Text.Trim(), "1");
            if (CV == null)
            {
                StaticData.MsgBox(this, "Vui lòng thử lại sau !");
                return;
            }
            else
            {
                StaticData.MsgBox(this, "Lưu thành công!.");
                BindListTienPhuCap("");
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
            NhanSu_Process.TienPhuCap CV = new NhanSu_Process.TienPhuCap();
            CV.idtienphucap = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), ddlNhanVien.SelectedValue, ddlPhuCap.SelectedValue, StaticData.CheckDate(txtNgay.Text.Trim()), txtSoLuong.Text.Trim(), txtSoTien.Text.Trim(), "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Đã cập nhật !");
                BindListTienPhuCap("");
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
        if (ddlPhuCap.SelectedValue != "0")
            strSearch += " and p.idphucap ='" + ddlPhuCap.SelectedValue + "' ";
        if (txtSoTien.Text.Trim() != "")
            strSearch += " and p.tienphucap ='" + txtSoTien.Text.Trim() + "' ";
        if (txtSoLuong.Text.Trim() != "")
            strSearch += " and p.soluong ='" + txtSoLuong.Text.Trim() + "' ";
        if (txtNgay.Text.Trim() != "")
        {
            try
            {
                DateTime date = DateTime.ParseExact(txtNgay.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                strSearch += " and p.thangnam >='" + StaticData.CheckDate(txtNgay.Text.Trim()) + " 00:00:00' ";
                strSearch += " and p.thangnam <='" + StaticData.CheckDate(txtNgay.Text.Trim()) + " 23:59:59' ";
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Ngày không hợp lệ. Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtNgay");
                return;
            }
        }
        //string Search = "SELECT * FROM chucvu  WHERE status='true' "+strSearch;
        BindListTienPhuCap(strSearch);
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
        string sqlDelete = "delete tienphucap  where idtienphucap=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListTienPhuCap(strSearch);

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
        BindListTienPhuCap(strSearch);
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
        string header = "DANH SÁCH PHỤ CẤP NHÂN VIÊN";
        string strNhanSu = "GĐ.Nhân Sự";
        clsExport.exprortToExcelDataGrid(filename, tcty, khoa, header, dgr, strNhanSu);
    }
    
}

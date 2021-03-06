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
public partial class PhanCaNhanVien : Page
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
            BindListCaLamViec();
            BindListPhanCa("");

            StaticData.SetFocus(this, "ddlNhanVien");
        }
    }
    #region "U Function"
    private void BindListCaLamViec()
    {
        string strSQL = "SELECT * from calamviec where status='1' ORDER BY tencalamviec";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlCaLamViec, dt, "idcalamviec", "tencalamviec", "--Chọn ca--");
    }
    private void BindListNhanVien()
    {
        string strSQL = "SELECT * FROM nhanvien where status='1' ORDER BY tennhanvien";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlNhanVien, dt, "idnhanvien", "tennhanvien", "--Chọn Nhân Viên--");
    }
    private void SetValueEditPC(DataTable dtSRC)
    {
        ddlNhanVien.SelectedValue = dtSRC.Rows[0]["idnhanvien"].ToString();
        ddlCaLamViec.SelectedValue = dtSRC.Rows[0]["idcalamviec"].ToString();
        //txtMaLoaiNgayNghi.Enabled = false;
        txtmaphieu.Value = dtSRC.Rows[0]["idphanca"].ToString();
        txtThu.Text = dtSRC.Rows[0]["thu"].ToString();
        txtNgay.Text = dtSRC.Rows[0]["ngay"].ToString();
        StaticData.SetFocus(this, "ddlNhanVien"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int idphanca)
    {
        string strSQL = "SELECT *,convert(nvarchar,ngaythangnam,103) as ngay FROM phanca WHERE status='true' and idphanca = " + idphanca;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListPhanCa(string sWhere)
    {
        string strSQL = "SELECT ROW_NUMBER()OVER (ORDER BY nv.idnhanvien) AS STT,P.*,nv.tennhanvien,ca.tencalamviec,convert(nvarchar,ngaythangnam,103) as ngay FROM phanca p ";
        strSQL += " left join nhanvien nv on p.idnhanvien=nv.idnhanvien";
        strSQL += " left join calamviec ca on p.idcalamviec=ca.idcalamviec";
        strSQL += " WHERE  p.status='1' and nv.status='1' and ca.status='1'" + sWhere;
        strSQL += " ORDER BY p.ngaythangnam,ca.tencalamviec";
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
        if (ddlCaLamViec.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn Ca. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "ddlCaLamViec");
            return false;
        }
        if (txtThu.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập thứ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtThu");
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
        ddlCaLamViec.SelectedValue = "0";
        txtThu.Text = "";
        txtNgay.Text = "";
        strSearch = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            
                //Lấy id 
            string id = StaticData.MaxIdNhanSuTheoTable("phanca", "idphanca");
            //thêm 
            NhanSu_Process.PhanCa CV = NhanSu_Process.PhanCa.Insert_Object(id, ddlNhanVien.SelectedValue, StaticData.CheckDate(txtNgay.Text.Trim()), txtThu.Text.Trim(), ddlCaLamViec.SelectedValue, "1");
            if (CV == null)
            {
                StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu Phân ca. Vui lòng thử lại sau.");
                return;
            }
            else
            {
                StaticData.MsgBox(this, "Lưu thành công!.");
                BindListPhanCa("");
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
            NhanSu_Process.PhanCa CV = new NhanSu_Process.PhanCa();
            CV.idphanca = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), ddlNhanVien.SelectedValue, txtNgay.Text.Trim(), txtThu.Text.Trim(), ddlCaLamViec.SelectedValue, "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Đã cập nhật !");
                BindListPhanCa("");
                SetValueEmpty();
                VisibleBtn(true);
            }
            else
                StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
            StaticData.SetFocus(this, "ddlNhanVien");

        }
    }
    protected void btnTim_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = "";
        if (ddlNhanVien.SelectedValue != "0")
            strSearch += " and p.idnhanvien ='" + ddlNhanVien.SelectedValue + "' ";
        if (ddlCaLamViec.SelectedValue != "0")
            strSearch += " and p.idcalamviec ='" + ddlCaLamViec.SelectedValue + "' ";
        if (txtThu.Text.Trim() != "")
            strSearch += " and p.thu like N'%" + txtThu.Text.Trim() + "%' ";
        if (txtNgay.Text.Trim() != "")
        {
            try
            {
                DateTime date = DateTime.ParseExact(txtNgay.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                strSearch += " and p.ngaythangnam >='" + StaticData.CheckDate(txtNgay.Text.Trim()) + " 00:00:00' ";
                strSearch += " and p.ngaythangnam <='" + StaticData.CheckDate(txtNgay.Text.Trim()) + " 23:59:59' ";
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Ngày không hợp lệ. Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtNgay");
                return;
            }
        }
        //string Search = "SELECT * FROM chucvu  WHERE status='true' "+strSearch;
        BindListPhanCa(strSearch);
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
        string sqlDelete = "delete phanca  where idphanca=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListPhanCa(strSearch);

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
        BindListPhanCa(strSearch);
    }
    #endregion    
    
    //TRUONGNHAT-PC
    //xuat du lieu ra exel
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void imgInExel_Click(object sender, ImageClickEventArgs e)
    {
        string filename = "DSPhanCaNhanVien";
        string tcty = "BỆNH VIỆN MINH ĐỨC";
        string khoa = "Phòng Nhân Sự";
        string header = "DANH SÁCH CA LÀM VIỆC NHÂN VIÊN";
        string strNhanSu = "GĐ.Nhân Sự";
        clsExport.exprortToExcelDataGrid(filename, tcty, khoa, header, dgr, strNhanSu);
    }
}

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
public partial class quanlynhansu_DangKyKhoaDaoTao : Page
{    
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListKhoaDaoTao();
            if (Request.QueryString["idkhoadaotao"] != null && Request.QueryString["idkhoadaotao"].ToString() != "")
            {
                ddlKhoaDaoTao.SelectedValue = Request.QueryString["idkhoadaotao"].ToString();
                bindGirdView("");
            }
            StaticData.SetFocus(this, "ddlKhoaDaoTao");
        }
    }
    #region "U Function"

    private void BindListKhoaDaoTao()
    {
        string strSQL = "select idkhoadaotao,mucdichdaotao,diadiem from khoadaotao where status=1";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlKhoaDaoTao, dt, "idkhoadaotao", "mucdichdaotao", "--Chọn khóa đào tạo--");
    }
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtIdChiTietKhoaDaoTao.Value = dtSRC.Rows[0]["IdChiTietKhoaDaoTao"].ToString();
        txtIdNhanVien.Value = dtSRC.Rows[0]["idnhanvien"].ToString();
        txtTenNhanVien.Text = dtSRC.Rows[0]["tennhanvien"].ToString();
        txtNgayDangKy.Text = dtSRC.Rows[0]["ngaydangky"].ToString();
        chck_DaDong.Checked = (dtSRC.Rows[0]["dadong"].ToString().ToUpper() == "TRUE" || dtSRC.Rows[0]["dadong"].ToString().ToUpper() == "1"? true:false);
        txtGhiChu.Text = dtSRC.Rows[0]["ghichu"].ToString();
        StaticData.SetFocus(this, "ddlNhanVien"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int idChiTiet)
    {
        string strSQL = @"select nv.idnhanvien,nv.tennhanvien,nv.manhanvien,ct.idchitietkhoadaotao,convert(varchar,ct.ngaydangky,103)as ngaydangky,ct.ghichu
        ,ct.dadong,ct.idkhoadaotao
        from chitietkhoadaotao ct
        left join nhanvien nv on nv.idnhanvien=ct.idnhanvien where ct.status=1 and ct.idchitietkhoadaotao='" + idChiTiet + "'";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    } 
    
    private bool CheckValid(int isadd)
    {
        if (ddlKhoaDaoTao.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa khóa đào tạo.");
            StaticData.SetFocus(this, "ddlKhoaDaoTao");
            return false;
        }
        if (txtIdNhanVien.Value == "" || txtIdNhanVien.Value == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập nhân viên. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtIdNhanVien");
            return false;
        }       
        try
        {
            DateTime date = DateTime.ParseExact(txtNgayDangKy.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Ngày không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNgayDangKy");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txtIdChiTietKhoaDaoTao.Value = "";
        //ddlKhoaDaoTao.SelectedValue = "0";
        txtIdNhanVien.Value= "";
        txtTenNhanVien.Text = "";
        txtNgayDangKy.Text = "";
        txtGhiChu.Text = "";
        chck_DaDong.Checked = false;
        txtNgayDangKy.Text = DateTime.Now.ToString("dd/MM/yyyy");
    }
  
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            
                //Lấy id 
            string id = StaticData.MaxIdNhanSuTheoTable("chitietkhoadaotao", "idchitietkhoadaotao");
            //thêm 
            NhanSu_Process.ChiTietKhoaDaoTao CV = NhanSu_Process.ChiTietKhoaDaoTao.Insert_Object(id,ddlKhoaDaoTao.SelectedValue,txtIdNhanVien.Value, StaticData.CheckDate(txtNgayDangKy.Text.Trim()),(chck_DaDong.Checked?"1":"0"),"1",txtGhiChu.Text);
            if (CV == null)
            {
                StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu Phân ca. Vui lòng thử lại sau.");
                return;
            }
            else
            {
                StaticData.MsgBox(this, "Lưu thành công!.");
                SetValueEmpty();
                bindGirdView("");
                StaticData.SetFocus(this, "txtTenNhanVien");
            }
            
        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtIdChiTietKhoaDaoTao.Value);
            NhanSu_Process.ChiTietKhoaDaoTao CV = new NhanSu_Process.ChiTietKhoaDaoTao();
            CV.IdChiTietKhoaDaoTao = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), ddlKhoaDaoTao.SelectedValue, txtIdNhanVien.Value, StaticData.CheckDate(txtNgayDangKy.Text.Trim()), (chck_DaDong.Checked ? "1" : "0"), "1", txtGhiChu.Text);
            if (kt)
            {
                StaticData.MsgBox(this, "Đã cập nhật !");
                SetValueEmpty();
                bindGirdView("");
                VisibleBtn(true);
            }
            else
                StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
            StaticData.SetFocus(this, "txtTenNhanVien");

        }
    }
    protected void btnTim_Click(object sender, ImageClickEventArgs e)
    {
        string strSearch = "";        
        if (txtIdNhanVien.Value.Trim() != "")
            strSearch += " and nv.idnhanvien ='" + txtIdNhanVien.Value+ "' ";
        
        //string Search = "SELECT * FROM chucvu  WHERE status='true' "+strSearch;
        bindGirdView(strSearch);
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();        
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
        txtIdChiTietKhoaDaoTao.Value = imaphong.ToString();
        DataTable dtEdit = LoaDdataEdit(imaphong);
        SetValueEditPC(dtEdit);
        VisibleBtn(false);
        
    }
    void bindGirdView(string strSearch)
    {
        if (ddlKhoaDaoTao.SelectedValue != "0")
            strSearch += " and ct.idkhoadaotao ='" + ddlKhoaDaoTao.SelectedValue + "' ";
        if (txtNgayDangKy.Text.Trim() != "")
        {
            try
            {
                DateTime date = DateTime.ParseExact(txtNgayDangKy.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                strSearch += " and ct.NgayDangKy >='" + StaticData.CheckDate(txtNgayDangKy.Text.Trim()) + " 00:00:00' ";
                strSearch += " and ct.NgayDangKy <='" + StaticData.CheckDate(txtNgayDangKy.Text.Trim()) + " 23:59:59' ";
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Ngày không hợp lệ. Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtNgayDangKy");
                return;
            }
        }
        string sql = @"select nv.idnhanvien,nv.tennhanvien,nv.manhanvien
        ,ct.idchitietkhoadaotao,convert(varchar,ct.ngaydangky,103)as ngaydangky,ct.ghichu
        ,ct.dadong,ct.idkhoadaotao,dt.mucdichdaotao,convert(varchar,dt.tungay,103)as tungay
        from chitietkhoadaotao ct
        left join nhanvien nv on nv.idnhanvien=ct.idnhanvien
        left join khoadaotao dt on dt.idkhoadaotao=ct.idkhoadaotao where dt.status=1 and ct.status=1 " + strSearch;        
        DataTable tb = DataAcess.Connect.GetTable(sql);
        dgr.DataSource = tb;
        dgr.DataBind();
    }
    public void Dellete(object s, DataGridCommandEventArgs e)
    {
        int imaphong;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string sqlDelete = "update chitietkhoadaotao set status=0  where idchitietkhoadaotao='" + imaphong+"'";
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            bindGirdView("");

        }
        else
            StaticData.MsgBox(this, "Có lỗi khi xóa !");
    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
       
    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;       
    }
    #endregion    
    
    //TRUONGNHAT-PC
    //xuat du lieu ra exel
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void imgInExel_Click(object sender, ImageClickEventArgs e)
    {
        string filename = "DSDangKyKhoaDaoTao";
        string tcty = "BỆNH VIỆN MINH ĐỨC";
        string khoa = "Phòng Nhân Sự";
        string header = "DANH SÁCH ĐĂNG KÝ KHÓA ĐÀO TẠO";
        string strNhanSu = "GĐ.Nhân Sự";
        clsExport.exprortToExcelDataGrid(filename, tcty, khoa, header, dgr, strNhanSu);
    }
    protected void ddlKhoaDaoTao_SelectedIndexChanged(object sender, EventArgs e)
    {
         bindGirdView("");
    }
}

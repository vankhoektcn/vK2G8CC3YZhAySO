using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Data.SqlClient;
using Process_2608;

public partial class danhmuckhachhang : System.Web.UI.Page 
{
    public void Page_Load(object sender, System.EventArgs e)
    {
        
        if (!IsPostBack)
        {
            loaddskhachhang();
        }
    }

    public void LoadPage()
    {
        
    }
    #region Class khach hang  
    private Process_2608.KhachHang CurrentKhachHang = null;
    #endregion
    private void kho_unload(object sender, System.EventArgs e)
    {
    }
    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(kho_unload);
    }
    #endregion
    #region load danh sách khách hàng
    private void loaddskhachhang()
    {   
        DataTable dt = Process_2608.KhachHang.dtGetAll();
        
        if (dt != null && dt.Rows.Count > 0)
        {
            dgrkhachhang.DataSource = dt;
            dgrkhachhang.DataBind();
        }
    }
    #endregion
    #region Reset all fields
    private void ResetAllField()
    {
        txtmakh.Text = "";
        txttenkhachhang.Text = "";
        txttennguoilienhe.Text = "";
        txtdiachi.Text = "";
        txtdienthoai.Text = "";
        txtmasothue.Text = "";
        txttknh.Text = "";
        txttennh.Text = "";        
    }
    #endregion
    #region datagrid event
    #region chọn khách hàng trên lưới
    protected void EditKhachHang(object source, DataGridCommandEventArgs e)
    {
        string idkhachhang = dgrkhachhang.DataKeys[e.Item.ItemIndex].ToString();
        this.CurrentKhachHang = Process_2608.KhachHang.Create_KhachHang(idkhachhang);        
        ViewKhachHang();
        btnLuu.Visible = false;
        btnSua.Visible = true;
        btnXoa.Visible = true;
    }
    private void ViewKhachHang()
    {
        ///gan cac control = this.currentKho. cac field       
        lblidkhachhang.Text = CurrentKhachHang.IDKhachHang;       
        txtmakh.Text = CurrentKhachHang.makhachhang;        
        txttenkhachhang.Text = CurrentKhachHang.tenkhachhang;
        txttennguoilienhe.Text = CurrentKhachHang.nguoilienhe == "" ? "" : CurrentKhachHang.nguoilienhe;        
        txtdiachi.Text = CurrentKhachHang.diachi == "" ? "" : CurrentKhachHang.diachi;
        txtdienthoai.Text = CurrentKhachHang.dienthoai == "" ? "" : CurrentKhachHang.dienthoai;
        txttennh.Text = CurrentKhachHang.nganhang == "" ? "" : CurrentKhachHang.nganhang;
        txttknh.Text = CurrentKhachHang.taikhoannganhang == "" ? "" : CurrentKhachHang.taikhoannganhang;
        txtmasothue.Text = CurrentKhachHang.masothue == "" ? "" : CurrentKhachHang.masothue;     
               
    }
    #endregion
    protected void dgrKhachHang_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
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
    }

    protected void PageIndexStyleChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgrkhachhang.CurrentPageIndex = e.NewPageIndex;
        loaddskhachhang();           
    }
    #endregion

    #region Thêm mới khách hàng
    private bool kiemtra()
    {
        string sql = "";
        string sql2 = "";
        sql = "select * from khachhang where makhachhang='" + txtmakh.Text.Trim() + "'";
        sql2 = "select * from nhacungcap where manhacungcap='" + txtmakh.Text.Trim() + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        DataTable dt2 = DataAcess.Connect.GetTable(sql2);
        if (dt.Rows.Count >= 1 || dt2.Rows.Count >= 1)
            return true;
        else
            return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        int idkhachhang = AddKhachHang();    
        if (idkhachhang != 0)
        {
            StaticData.MsgBox(this, "Đã thêm mới khách hàng!");
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLuu.Visible = false;
            lblidkhachhang.Text = idkhachhang.ToString();
            loaddskhachhang();        
        }
        else
        {
            StaticData.MsgBox(this, "Lưu thông tin thất bại!");
            txtmakh.Focus();          
        }
    }

    private int AddKhachHang()
    {
        string smakh = txtmakh.Text;
        string stenkh = txttenkhachhang.Text;
        string stennguoilienhe = txttennguoilienhe.Text;
        string sdiachi = txtdiachi.Text;
        string sdienthoai = txtdienthoai.Text;
        string smasothue = txtmasothue.Text;
        string stknh = txttknh.Text;
        string stennh = txttennh.Text;
        int idkhachhang = 0;
        if (kiemtra())
        {
            StaticData.MsgBox(this, "Đã có Mã khách hàng này!");
            idkhachhang = 0;
        }
        else
        {
            Process_2608.KhachHang khachhangtmp = Process_2608.KhachHang.Insert_Object("", smakh, stenkh, sdiachi, sdienthoai, "", "", "", "", stknh, stennh, smasothue, stennguoilienhe);
            if (khachhangtmp != null)
            {
                this.CurrentKhachHang = khachhangtmp;
                idkhachhang = StaticData.ParseInt(CurrentKhachHang.IDKhachHang);               
            }
            else
            {
                idkhachhang = 0;
            }
        }                                                  
        return idkhachhang;        
    }
    #endregion
    #region Sửa thông tin khách hàng
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool OK = EditKhachHang();
        if (OK)
        {
            StaticData.MsgBox(this, "Đã sửa thông tin khách hàng!");
            //btnSua.Visible = false;
            //btnXoa.Visible = false;
            //btnLuu.Visible = true;
            loaddskhachhang();
            //ResetAllField();
        }
        else
        {
            StaticData.MsgBox(this, "Lưu thông tin thất bại!");
            txtmakh.Focus();
        }
    }
    private bool EditKhachHang()
    {
        string idkhachhang = lblidkhachhang.Text;
        this.CurrentKhachHang = new Process_2608.KhachHang();
        this.CurrentKhachHang.IDKhachHang = idkhachhang;        
        return this.CurrentKhachHang.Save_Object("", txtmakh.Text, txttenkhachhang.Text, txtdiachi.Text, txtdienthoai.Text, "", "", "", "", txttknh.Text, txttennh.Text, txtmasothue.Text, txttennguoilienhe.Text);        
    }
    #endregion
    #region Xoá thông tin khách hàng
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        bool OK = DeleteKhachHang();
        if (OK)
        {
            StaticData.MsgBox(this, "Đã xoá thông tin khách hàng!");
            loaddskhachhang();
            ResetAllField();
            btnLuu.Visible = true;
            btnSua.Visible = false;
            btnXoa.Visible = false;
        }
        else 
        {
            StaticData.MsgBox(this, "Lưu thông tin thất bại!");
        }
    }
    private bool DeleteKhachHang()
    {
        string sqlDelete = " DELETE FROM KHACHHANG WHERE  idkhachhang = " + Convert.ToInt16(lblidkhachhang.Text);       
        bool OK = DataAcess.Connect.ExecSQL(sqlDelete);
        return OK;
    }

    #endregion
    #region Tìm nhà cung cấp
    protected void btnTim_Click(object sender, EventArgs e)
    {
        DataTable dtkhachhang = SearchKhachHang();
        if (dtkhachhang != null && dtkhachhang.Rows.Count > 0)
        {
            lblidkhachhang.Text = dtkhachhang.Rows[0]["idkhachhang"].ToString();
            txtmakh.Text = dtkhachhang.Rows[0]["makhachhang"].ToString();
            txttenkhachhang.Text=dtkhachhang.Rows[0]["tenkhachhang"].ToString ();
            txttennguoilienhe.Text = (dtkhachhang.Rows[0]["nguoilienhe"].ToString() == "") ? "" : dtkhachhang.Rows[0]["nguoilienhe"].ToString();
            txtdiachi.Text = (dtkhachhang.Rows[0]["diachi"].ToString() == "") ? "" : dtkhachhang.Rows[0]["diachi"].ToString();
            txttennguoilienhe.Text = (dtkhachhang.Rows[0]["dienthoai"].ToString() == "") ? "" : dtkhachhang.Rows[0]["dienthoai"].ToString();
            txtmasothue.Text = (dtkhachhang.Rows[0]["masothue"].ToString() == "") ? "" : dtkhachhang.Rows[0]["masothue"].ToString();
            txttennh.Text = (dtkhachhang.Rows[0]["nganhang"].ToString() == "") ? "" : dtkhachhang.Rows[0]["nganhang"].ToString();
            txttknh.Text = (dtkhachhang.Rows[0]["taikhoannganhang"].ToString() == "") ? "" : dtkhachhang.Rows[0]["taikhoannganhang"].ToString();
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLuu.Visible = false;
        }
        if (dtkhachhang != null)
        {
            dgrkhachhang.DataSource = dtkhachhang;
            dgrkhachhang.DataBind();         
        }
    }
    private DataTable SearchKhachHang()
    {
        DataTable dtKhachHang = Process_2608.KhachHang.dtSearch("", "", txtmakh.Text, txttenkhachhang.Text, txtdiachi.Text, txtdienthoai.Text, "", "", "", "", txttknh.Text, txttennh.Text, txtmasothue.Text, txttennguoilienhe.Text);
        return dtKhachHang;
    }
    #endregion
}

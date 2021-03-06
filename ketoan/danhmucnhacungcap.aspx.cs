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

public partial class danhmucnhacungcap : System.Web.UI.Page 
{
    public void Page_Load(object sender, System.EventArgs e)
    {
        
        if (!IsPostBack)
        {
            loaddsnhaCC();
        }
    }

    public void LoadPage()
    {
        
    }

    #region Class Nha cung cấp
    private Process.nhacungcap CurrentNhaCC = null;
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
    #region load danh sách nhà cung cấp
    private void loaddsnhaCC()
    {
        DataTable dt = Process.nhacungcap.dtGetAll();
        
        if (dt != null && dt.Rows.Count > 0)
        {
            dgrnhacungcap.DataSource = dt;
            dgrnhacungcap.DataBind();
        }
    }
    #endregion
    #region Reset all fields
    private void ResetAllField()
    {
        txtmancc.Text = "";
        txttennhacungcap.Text = "";
        txttennguoilienhe.Text = "";
        txtdiachi.Text = "";
        txtdienthoai.Text = "";
        txtmasothue.Text = "";
        txttknh.Text = "";
        txttennh.Text = "";        
    }
    #endregion
    #region datagrid event
    #region chọn nhà cung cấp trên lưới
    protected void EditNhaCC(object source, DataGridCommandEventArgs e)
    {
        string idnhacungcap = dgrnhacungcap.DataKeys[e.Item.ItemIndex].ToString();
        this.CurrentNhaCC = Process.nhacungcap.Create_nhacungcap(idnhacungcap);
        ViewNhaCC();
        btnLuu.Visible = false;
        btnSua.Visible = true;
        btnXoa.Visible = true;
    }
    private void ViewNhaCC()
    {
        ///gan cac control = this.currentKho. cac field
        lblidnhacungcap.Text = CurrentNhaCC.nhacungcapid;
        txtmancc.Text = CurrentNhaCC.manhacungcap;
        txttennhacungcap.Text = CurrentNhaCC.tennhacungcap;
        txttennguoilienhe.Text = CurrentNhaCC.nguoilienhe == "" ? "" : CurrentNhaCC.nguoilienhe ;
        txtdiachi.Text = CurrentNhaCC.diachi == "" ? "" : CurrentNhaCC.diachi;
        txtdienthoai.Text = CurrentNhaCC.dienthoai == "" ? "" : CurrentNhaCC.dienthoai;
        //txtmasothue.Text = CurrentNhaCC.masothue == "" ? "" : CurrentNhaCC.masothue;
               
    }
    #endregion
    protected void dgrNhaCC_ItemDataBound(object sender, DataGridItemEventArgs e)
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
        dgrnhacungcap.CurrentPageIndex = e.NewPageIndex;
        loaddsnhaCC();
    }
    #endregion
    #region Thêm mới nhà cung cấp
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        int idnhacungcap = AddNhaCC();
        if (idnhacungcap != 0)
        {
            StaticData.MsgBox(this, "Đã thêm mới nhà cung cấp!");
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLuu.Visible = false;
            lblidnhacungcap.Text = idnhacungcap.ToString();
            loaddsnhaCC();
        }
        else
        {
            StaticData.MsgBox(this, "Lưu thông tin thất bại!");
            txtmancc.Focus();
        }
    }
    private bool kiemtra()
    {
        string sql = "";
        sql = "select * from nhacungcap where manhacungcap='" + txtmancc.Text.Trim() + "'";
        string sql2 = "select * from khachhang where makhachhang='" + txtmancc.Text.Trim() + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        DataTable dt2 = DataAcess.Connect.GetTable(sql2);
        if (dt.Rows.Count >= 1 || dt2.Rows.Count >= 1)
            return true;
        else
            return false;  
    }
    private int AddNhaCC()
    {
        string smaNCC = txtmancc.Text;
        string stenNCC = txttennhacungcap.Text;
        string stennguoilienhe = txttennguoilienhe.Text;
        string sdiachi = txtdiachi.Text;
        string sdienthoai = txtdienthoai.Text;
        string smasothue = txtmasothue.Text;
        string stknh = txttknh.Text;
        string stennh = txttennh.Text;

        int idnhacungcap = 0;
        if (kiemtra())
        {
            StaticData.MsgBox(this, "Đã có Mã Nhà Cung cấp này!");
            idnhacungcap = 0;
        }
        else
        {
            Process.nhacungcap nhaCCtemp = Process.nhacungcap.Insert_Object(smaNCC, stenNCC, stennguoilienhe, sdiachi, sdienthoai, "", "", stknh, stennh, smasothue, "");
            if (nhaCCtemp != null)
            {
                this.CurrentNhaCC = nhaCCtemp;
                idnhacungcap = StaticData.ParseInt(CurrentNhaCC.nhacungcapid);
                string sqlupdate = "update nhacungcap set iskt=1 where nhacungcapid=" + idnhacungcap;
                DataAcess.Connect.ExecSQL(sqlupdate);
            }
            else
            {
                idnhacungcap = 0;
            }
        }                       
        return idnhacungcap;
    }
    #endregion
    #region Sửa thông tin nhà cung cấp
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool OK = EditNhaCC();
        if (OK)
        {
            StaticData.MsgBox(this, "Đã sửa thông tin nhà cung cấp!");
            //btnSua.Visible = false;
            //btnXoa.Visible = false;
            //btnLuu.Visible = true;
            loaddsnhaCC();
            //ResetAllField();
        }
        else
        {
            StaticData.MsgBox(this, "Lưu thông tin thất bại!");
            txtmancc.Focus();
        }
    }
    private bool EditNhaCC()
    {
        string idnhacungcap = lblidnhacungcap.Text;
        this.CurrentNhaCC = new Process.nhacungcap();
        this.CurrentNhaCC.nhacungcapid = idnhacungcap;
        string sqlupdate = "update nhacungcap set iskt=1 where nhacungcapid=" + idnhacungcap;
        DataAcess.Connect.ExecSQL(sqlupdate);
        return this.CurrentNhaCC.Save_Object(txtmancc.Text, txttennhacungcap.Text, txttennguoilienhe.Text, txtdiachi.Text, txtdienthoai.Text, "", "", txttknh.Text, txttennh.Text, txtmasothue.Text, "");                
    }
    #endregion
    #region Xoá thông tin nhà cung cấp
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        bool OK = DeleteNCC();
        if (OK)
        {
            StaticData.MsgBox(this, "Đã xoá thông tin nhà cung cấp!");
            loaddsnhaCC();
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
    private bool DeleteNCC()
    {
        string sqlDelete = " DELETE FROM " + Profess.TBLS.TBL_NAME.nhacungcap.ToString()
         + " WHERE " + Profess.TBLS.tbl_nhacungcap.nhacungcapid.ToString() + "=" + lblidnhacungcap.Text;
        bool OK = DataAcess.Connect.ExecSQL(sqlDelete);
        return OK;
    }
    #endregion

    #region Tìm nhà cung cấp
    protected void btnTim_Click(object sender, EventArgs e)
    {
        DataTable dtNCC = SearchNhaCC();
        if (dtNCC != null && dtNCC.Rows.Count > 0)
        {
            lblidnhacungcap.Text = dtNCC.Rows[0]["nhacungcapid"].ToString();
            txtmancc.Text = dtNCC.Rows[0]["manhacungcap"].ToString();
            txttennhacungcap.Text = dtNCC.Rows[0]["tennhacungcap"].ToString();
            txttennguoilienhe.Text = (dtNCC.Rows[0]["nguoilienhe"].ToString() == "") ? "" : dtNCC.Rows[0]["nguoilienhe"].ToString();
            txtdiachi.Text = (dtNCC.Rows[0]["diachi"].ToString() == "") ? "" : dtNCC.Rows[0]["diachi"].ToString();
            txttennguoilienhe.Text = (dtNCC.Rows[0]["dienthoai"].ToString() == "") ? "" : dtNCC.Rows[0]["dienthoai"].ToString();
            txtmasothue.Text = (dtNCC.Rows[0]["masothue"].ToString() == "") ? "" : dtNCC.Rows[0]["masothue"].ToString();
            txttennh.Text = (dtNCC.Rows[0]["nganhang"].ToString() == "") ? "" : dtNCC.Rows[0]["nganhang"].ToString();
            txttknh.Text = (dtNCC.Rows[0]["taikhoannganhang"].ToString() == "") ? "" : dtNCC.Rows[0]["taikhoannganhang"].ToString();
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLuu.Visible = false;
        }
        if (dtNCC != null)
        {
            dgrnhacungcap.DataSource = dtNCC;
            dgrnhacungcap.DataBind();
        }
    }
    private DataTable SearchNhaCC()
    {
        DataTable dtNCC = Process.nhacungcap.dtSearch("", txtmancc.Text, txttennhacungcap.Text, txttennguoilienhe.Text, txtdiachi.Text, txtdienthoai.Text,"","",txttknh.Text,txttennh.Text,txtmasothue.Text,"");
        return dtNCC;
    }
    #endregion
}

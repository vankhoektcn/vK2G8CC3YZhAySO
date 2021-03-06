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
using KT_Profess;

public partial class DM_Vat_Tu_KT : System.Web.UI.Page 
{
    public void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            loaddsvattu();
        }
        bool quyenthem = StaticData.HavePermision(this.Page, "KeToanDM_KTVT_DM_Vat_Tu_Them");
        bool quyensua = StaticData.HavePermision(this.Page, "KeToanDM_KTVT_DM_Vat_Tu_Sua");
        bool quyenxoa = StaticData.HavePermision(this.Page, "KeToanDM_KTVT_DM_Vat_Tu_Xoa");
        if (quyenthem)
            btnLuu.Enabled = true;
        else
            btnLuu.Enabled = false;
        if (quyensua)
            btnSua.Enabled = true;
        else
            btnSua.Enabled = false;
        if (quyenxoa)
            btnXoa.Enabled = true;
        else
            btnXoa.Enabled = false;
    }
    public void LoadPage()
    {        
    }
    #region Class khach hang     
    private KT_Profess.DM_VAT_TU_KT CurrentDMVT = null;
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

    #region load danh sách vat tu
    private void loaddsvattu()
    {
        //DataTable dt = KT_Profess.DM_VAT_TU_KT.dtGetAll();
        string sql = "select * from dm_vat_tu_kt where istscd=1";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            dgrdmvattu.DataSource = dt;
            dgrdmvattu.DataBind();
        }        
    }
    #endregion
    #region Reset all fields
    private void ResetAllField()
    {
        mavt.Text = "";
        tenvt.Text = "";
        dvt.Text = "";
        nuoc_sx.Text = "";
        nam_sx.Text = "";
        tk_kho.Text = "";
        tk_khauhao.Text = "";
        tk_chiphi.Text = "";
        ghi_chu.Text = "";               
    }
    #endregion
    #region datagrid event
    #region chọn khách hàng trên lưới
    protected void EditDMVatTu(object source, DataGridCommandEventArgs e)
    {     
        string dmvattuid = dgrdmvattu.DataKeys[e.Item.ItemIndex].ToString();
        this.CurrentDMVT = KT_Profess.DM_VAT_TU_KT.Create_DM_VAT_TU_KT(dmvattuid);
        ViewDanhMucVT();
        btnLuu.Visible = false;
        btnSua.Visible = true;
        btnXoa.Visible = true;
    }
    private void ViewDanhMucVT()
    {
        ///gan cac control = this.currentKho. cac field   
        lbldmvattuid.Text = CurrentDMVT.danhmuc_vattu_id;
        mavt.Text = CurrentDMVT.ma_vt;
        tenvt.Text = CurrentDMVT.ten_vt;
        dvt.Text = CurrentDMVT.dvt;
        nuoc_sx.Text = CurrentDMVT.nuoc_sx;
        nam_sx.Text = CurrentDMVT.nam_sx;
        tk_kho.Text = CurrentDMVT.tk_kho;
        tk_khauhao.Text = CurrentDMVT.tk_khau_hao;
        tk_chiphi.Text = CurrentDMVT.tk_chi_phi;        
    }
    #endregion
    protected void dgrDMVatTu_ItemDataBound(object sender, DataGridItemEventArgs e)
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
        dgrdmvattu.CurrentPageIndex = e.NewPageIndex;
        loaddsvattu();       
    }
    #endregion

    #region Thêm mới khách hàng
    private bool kiemtra()
    {
        string sql = "";
        sql = "select * from dm_vat_tu_kt where ma_vt='" + mavt.Text + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count >= 1)
            return true;
        else
            return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        int dmvatuid = AddDanhMucVatTu();
        if (dmvatuid != 0)
        {
            StaticData.MsgBox(this, "Đã thêm mới tài sản!");
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLuu.Visible = false;
            lbldmvattuid.Text=dmvatuid.ToString ();
            loaddsvattu();     
        }
        else
        {
            StaticData.MsgBox(this, "Lưu thông tin thất bại!");
            mavt.Focus();         
        }
    }

    private int AddDanhMucVatTu()
    {
        string smavt = mavt.Text;
        string stenvt = tenvt.Text;
        string sdvt = dvt.Text;
        string snuocsx=nuoc_sx.Text;
        string snamsx=nam_sx.Text;
        string stk_kho = tk_kho.Text;
        string stk_chiphi = tk_chiphi.Text;
        string stk_khauhao = tk_khauhao.Text;
        string sghichu = ghi_chu.Text;
        int dmvatuid = 0;        
        if (kiemtra())
        {
            StaticData.MsgBox(this, "Đã có mã TS này!");
            dmvatuid = 0;
        }
        else
        {           
            KT_Profess.DM_VAT_TU_KT dmvattutmp = KT_Profess.DM_VAT_TU_KT.Insert_Object(smavt, stenvt, sdvt, snuocsx, snamsx, stk_kho, stk_khauhao, stk_chiphi, sghichu);            
            if (dmvattutmp != null)
            {
                this.CurrentDMVT = dmvattutmp;
                dmvatuid = StaticData.ParseInt(CurrentDMVT.danhmuc_vattu_id);
                string sql = " update dm_vat_tu_kt set istscd=1 where ma_vt='" + smavt.Trim() + "'";
                DataAcess.Connect.ExecSQL(sql);
            }
            else
            {
                dmvatuid = 0;
            }
        }
        return dmvatuid;        
    }
    #endregion
    #region Sửa thông tin khách hàng
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool OK = EditDMVatTu();
        if (OK)
        {
            StaticData.MsgBox(this, "Đã sửa thông tin tài sản!");
            loaddsvattu();
            //ResetAllField();
        }
        else
        {
            StaticData.MsgBox(this, "Lưu thông tin thất bại!");
            mavt.Focus();
        }
    }
    private bool EditDMVatTu()
    {
        string dmvattuid = lbldmvattuid.Text;
        this.CurrentDMVT = new KT_Profess.DM_VAT_TU_KT();
        this.CurrentDMVT.danhmuc_vattu_id = dmvattuid;
        // return CurrentDMVT.Save_Object(mavt.Text, tenvt.Text, dvt.Text, nuoc_sx.Text, nam_sx.Text, tk_kho.Text, tk_khauhao.Text, tk_chiphi.Text);        
        string sql = " update dm_vat_tu_kt set istscd=1 where ma_vt='" + mavt.Text.Trim() + "'";
        DataAcess.Connect.ExecSQL(sql);
        return this.CurrentDMVT.Save_Object(mavt.Text, tenvt.Text, dvt.Text, nuoc_sx.Text, nam_sx.Text, tk_kho.Text, tk_khauhao.Text, tk_chiphi.Text,ghi_chu.Text);
    }
    #endregion
    #region Xoá thông tin khách hàng
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        bool OK = DeleteDanhmucvattu();
        if (OK)
        {
            StaticData.MsgBox(this, "Đã xoá thông tin TS/CCDC!");
            loaddsvattu();
            ResetAllField();
            btnLuu.Visible = true;
            btnSua.Visible = false;
            btnXoa.Visible = false;
        }
        else 
        {
            StaticData.MsgBox(this, "Xóa thông tin thất bại!");
        }
    }
    private bool DeleteDanhmucvattu()
    {
        string sqlDelete = " DELETE FROM DM_Vat_tu_kt WHERE  danhmuc_vattu_id = " + Convert.ToInt16(lbldmvattuid.Text);       
        bool OK = DataAcess.Connect.ExecSQL(sqlDelete);
        return OK;
    }

    #endregion
    #region Tìm nhà cung cấp
    protected void btnTim_Click(object sender, EventArgs e)
    {
        DataTable dtdanhmucvattu = SearchDanhMucVatTu();
        if (dtdanhmucvattu!=null && dtdanhmucvattu.Rows.Count>0)
        {
            lbldmvattuid.Text=dtdanhmucvattu.Rows[0]["danhmuc_vattu_id"].ToString ();
            mavt.Text = dtdanhmucvattu.Rows[0]["ma_vt"].ToString();
            tenvt.Text = dtdanhmucvattu.Rows[0]["ten_vt"].ToString();
            dvt.Text = dtdanhmucvattu.Rows[0]["dvt"].ToString();
            nuoc_sx.Text = (dtdanhmucvattu.Rows[0]["nuoc_sx"].ToString() == "") ? "" : dtdanhmucvattu.Rows[0]["nuoc_sx"].ToString();
            nam_sx.Text = (dtdanhmucvattu.Rows[0]["nam_sx"].ToString() == "") ? "" : dtdanhmucvattu.Rows[0]["nam_sx"].ToString();
            tk_kho.Text = (dtdanhmucvattu.Rows[0]["tk_kho"].ToString()=="")?"":dtdanhmucvattu.Rows[0]["tk_kho"].ToString ();
            tk_chiphi.Text = (dtdanhmucvattu.Rows[0]["tk_chi_phi"].ToString() == "") ? "" : dtdanhmucvattu.Rows[0]["tk_chi_phi"].ToString();
            tk_khauhao.Text = (dtdanhmucvattu.Rows[0]["tk_khau_hao"].ToString() == "") ? "" : dtdanhmucvattu.Rows[0]["tk_khau_hao"].ToString();             
        }
        if (dtdanhmucvattu != null)
        {
            dgrdmvattu.DataSource = dtdanhmucvattu;
            dgrdmvattu.DataBind();
        }        
    }
    private DataTable SearchDanhMucVatTu()
    {        
        DataTable dtdmvt = KT_Profess.DM_VAT_TU_KT.dtSearch("", mavt.Text, tenvt.Text, dvt.Text, nuoc_sx.Text, nam_sx.Text, tk_kho.Text, tk_khauhao.Text, tk_chiphi.Text, ghi_chu.Text);
        return dtdmvt;
    }
    #endregion
}

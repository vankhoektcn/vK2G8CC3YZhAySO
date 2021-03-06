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

public partial class danhmuckho : System.Web.UI.Page 
{
    public void Page_Load(object sender, System.EventArgs e)
    {
        
        if (!IsPostBack)
        {
            loadDSKho(); // load danh sách kho
            
        }
    }


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

    #region Class Kho
    private Process.khothuoc CurrentKho = null;
    #endregion

    #region Load Danh sach kho
    private void loadDSKho()
    {
        DataTable dtDSKho = dtdAllKho();
        if (dtDSKho != null && dtDSKho.Rows.Count > 0)
        {
            dgrkho.DataSource = dtDSKho;
            dgrkho.DataBind();
        }
    }
    private DataTable dtdAllKho()
    {        
        return Process.khothuoc.dtGetAll();
    }
    #endregion
    
    //#region Cap nhat kho
    //private bool EditKho()
    //{
    //    //return this.CurrentKho.Save_Object("");
    //    return true;
    //}
    //#endregion
    
    
    #region Thêm kho mới
    protected void btnAddKho_Click(object sender, EventArgs e)
    {
        int idkho = AddKho();
        if (idkho != 0)
        {
            StaticData.MsgBox(this, "Đã thêm mới kho!");
            btnEditKho.Visible = true;
            btnDeleteKho.Visible = true;
            btnAddKho.Visible = false;
        }
        else
        {
            StaticData.MsgBox(this, "Có lỗi trong quá trình thêm mới kho thuốc! vui lòng kiểm tra lại!");
            txtmakho.Focus();
        }
        loadDSKho();
        ResetAllField();
    }

    private int AddKho()
    {
        Process.khothuoc TempKho = Process.khothuoc.Insert_Object(txtmakho.Text, txttenkho.Text, "", "", "");
        int idkho = 0;
        if (TempKho != null)
        {
            this.CurrentKho = TempKho;
            idkho = StaticData.ParseInt(CurrentKho.idkho);
        }
        else 
        {
            idkho = 0;
        }
        return idkho;
    }
    #endregion

    #region Tìm kiếm kho
    protected void btnTimKho_Click(object sender, EventArgs e)
    {
        DataTable dtkho = SearchKho();
        if (dtkho != null && dtkho.Rows.Count > 0)
        {
            txtmakho.Text = dtkho.Rows[0]["makho"].ToString();
            txttenkho.Text = dtkho.Rows[0]["tenkho"].ToString();
            btnAddKho.Visible = false;
            btnEditKho.Visible = true;
            btnDeleteKho.Visible = true;
        }
        else
        {
            StaticData.MsgBox(this, "Không tìm thấy kho này! Vui lòng kiểm tra lại!");
        }
        if (dtkho != null)
        {
            dgrkho.DataSource = dtkho;
            dgrkho.DataBind();
        }
    }

    private DataTable SearchKho()
    {
        DataTable dtKho = Process.khothuoc.dtSearch("", txtmakho.Text, txttenkho.Text, "", "", "");
        return dtKho;
    }
    #endregion

    #region Xoá kho từ lưới
    protected void btnDeleteKho_Click(object sender, EventArgs e)
    {
        bool OK = DeleteKho();
        if (OK)
        {
            StaticData.MsgBox(this, "Đã xoá kho thuốc!");
            loadDSKho();
            btnAddKho.Visible = true;
            btnEditKho.Visible = false;
            btnDeleteKho.Visible = false;
        }
        else
        {
            StaticData.MsgBox(this, "Có lỗi trong quá trình xoá kho thuốc! Vui lòng kiểm tra lại!");
        }
    }
    #region Xoa kho
    private bool DeleteKho()
    {
        string sqlDelete = " DELETE FROM " + Profess.TBLS.TBL_NAME.khothuoc.ToString()
         + " WHERE " + Profess.TBLS.tbl_khothuoc.idkho.ToString() + "=" + lblidkho.Text ;
        bool OK = DataAcess.Connect.ExecSQL(sqlDelete);
        return OK;
    }
    #endregion
    #endregion

    #region chọn kho từ lưới
    protected void EditKho(object source, DataGridCommandEventArgs e)
    {
        string idkho = dgrkho.DataKeys[e.Item.ItemIndex].ToString();

        this.CurrentKho = Process.khothuoc.Create_khothuoc(idkho);
        this.ViewKho();
        lblidkho.Text = idkho;
        btnAddKho.Visible = false;
        btnEditKho.Visible = true;
        btnDeleteKho.Visible = true;
    }
    private void ViewKho()
    {
        ///gan cac control = this.currentKho. cac field
        txtmakho.Text = this.CurrentKho.makho;
        txttenkho.Text = this.CurrentKho.tenkho;
    }
    #endregion
    protected void dgrkho_ItemDataBound(object sender, DataGridItemEventArgs e)
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
        dgrkho.CurrentPageIndex = e.NewPageIndex;
        loadDSKho();
    }

    #region reset fields
    private void ResetAllField()
    {
        txtmakho.Text = "";
        txttenkho.Text = "";
    }
    #endregion

    #region Sửa thông tin kho
    protected void btnEditKho_Click(object sender, EventArgs e)
    {
        bool OK = EditItemKho();
        if (OK == true)
        {
            StaticData.MsgBox(this, "Đã sửa thông tin kho!");
            lblidkho.Text = CurrentKho.idkho;
            //btnAddKho.Visible = true;
            //btnEditKho.Visible = false;
            //btnDeleteKho.Visible = false;
            Response.Write("<script>var a = document.getElementById('btnLamLai'); a.focus();</script>");
        }
        else
        {
            StaticData.MsgBox(this, "Có lỗi trong quá trình sửa thông tin kho!Vui lòng kiểm tra lại!");
            txtmakho.Focus();
        }
        loadDSKho();
        //ResetAllField();
    }
    private bool EditItemKho()
    {
        string idkho = lblidkho.Text;
        this.CurrentKho = new Process.khothuoc();
        this.CurrentKho.idkho = idkho;        
        return this.CurrentKho.Save_Object(txtmakho.Text, txttenkho.Text, "", "", "");
    }
    #endregion
    
}

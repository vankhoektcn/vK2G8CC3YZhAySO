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
public partial class HeSoBaoHiemEntry : Page
{
   static string strSearch;
    SqlConnection conn = DataAcess.Connect.Conn;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListHeSoBaoHiem("");
            StaticData.SetFocus(this, "txtmachucvu");
        }
    }
    #region "U Function"
    
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtTenBaoHiem.Text = dtSRC.Rows[0]["TenBaoHiem"].ToString();
        txtMaBaoHiem.Text = dtSRC.Rows[0]["MaHSBH"].ToString();
        txtMaBaoHiem.Enabled = false;
        txtCtyTra.Text = dtSRC.Rows[0]["CtyTra"].ToString();
        txtNhanVienTra.Text = dtSRC.Rows[0]["NVTra"].ToString();
        txtmaphieu.Value = dtSRC.Rows[0]["IdHeSoBH"].ToString();
        txtGhiChu.Text = dtSRC.Rows[0]["ghichu"].ToString();
        StaticData.SetFocus(this, "TenBaoHiem"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int iidchucvu)
    {
        string strSQL = "SELECT p.* FROM HeSoBaoHiem p WHERE status='true' and IdHeSoBH = " + iidchucvu;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListHeSoBaoHiem(string sWhere)
    {
        string strSQL = "SELECT p.* FROM HeSoBaoHiem p ";
        strSQL += " WHERE  status='true' " + sWhere;
        strSQL += " ORDER BY TenBaoHiem ASC";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (txtTenBaoHiem.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập mã chức vụ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtmachucvu");
            return false;
        }
        if (txtCtyTra.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập tên chức vụ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txttenchucvu");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txtTenBaoHiem.Text = "";
        txtMaBaoHiem.Text = "";
        txtCtyTra.Text = "";
        txtNhanVienTra.Text = "";
        txtGhiChu.Text = "";
        txtTenBaoHiem.Enabled = true;
        strSearch = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //if (CheckValid(0))
        //{
        if (!StaticData.CheckExist("HeSoBaoHiem", "MaHSBH", txtMaBaoHiem.Text))
            {
                //Lấy id 
                int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(IdHeSoBH),0)+1 as MaxID from HeSoBaoHiem ").Rows[0][0].ToString());
                //thêm chức vụ
                NhanSu_Process.HeSoBaoHiem CV = NhanSu_Process.HeSoBaoHiem.Insert_Object(id.ToString(),txtMaBaoHiem.Text.Trim(),txtTenBaoHiem.Text.Trim(),txtCtyTra.Text.Trim(),txtNhanVienTra.Text.Trim(),txtGhiChu.Text,"1");
                if (CV == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin hệ số Bảo Hiểm ! Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Lưu thành công!.");
                    BindListHeSoBaoHiem("");
                    SetValueEmpty();
                    StaticData.SetFocus(this, "txtmachucvu");
                }
            }
            else
            {
                StaticData.MsgBox(this, "Mã Bảo Hiểm này đã tồn tại trong cơ sở dữ liệu rồi. Vui lòng kiểm tra lại.");
                return;
            }
            

        //}
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtmaphieu.Value);
            NhanSu_Process.HeSoBaoHiem CV = new NhanSu_Process.HeSoBaoHiem();
            CV.IdHeSoBH = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), txtMaBaoHiem.Text.Trim(), txtTenBaoHiem.Text.Trim(), txtCtyTra.Text.Trim(), txtNhanVienTra.Text.Trim(), txtGhiChu.Text, "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Cập nhật thông tin chức vụ thành công.");
                BindListHeSoBaoHiem("");
                SetValueEmpty();
                VisibleBtn(true);
            }
            else
                StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
            StaticData.SetFocus(this, "txtmachucvu");

        }
    }
    protected void btnTim_Click(object sender, ImageClickEventArgs e)
    {
         strSearch = "";
        if (txtMaBaoHiem.Text.Trim() != "")
            strSearch = " and MaHSBH='" + txtMaBaoHiem.Text.Trim() + "' ";
        if (txtTenBaoHiem.Text.Trim() != "")
            strSearch += " and TenBaoHiem like N'%" + txtTenBaoHiem.Text.Trim() + "%' ";
        if (txtCtyTra.Text != "")
            strSearch += " and CtyTra="+txtCtyTra.Text.Trim();
        if (txtNhanVienTra.Text != "")
            strSearch += " and NVTra=" + txtNhanVienTra.Text.Trim();
        if (txtGhiChu.Text.Trim() != "")
            strSearch += " and ghichu like N'%" + txtGhiChu.Text.Trim() + "%' ";
        BindListHeSoBaoHiem(strSearch);
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        VisibleBtn(true);
        StaticData.SetFocus(this, "txtmachucvu");
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
    public void DelPhongKham(object s, DataGridCommandEventArgs e)
    {
        int imaphong;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string sqlDelete = "update HeSoBaoHiem set status='0' where IdHeSoBH=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListHeSoBaoHiem(strSearch);

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
        BindListHeSoBaoHiem(strSearch);
    }
    #endregion    
    
}

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
public partial class XepLoaiEntry : Page
{
   static string strSearch;
    SqlConnection conn = DataAcess.Connect.Conn;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListXepLoai("");
            StaticData.SetFocus(this, "txttenxeploai");
        }
    }
    #region "U Function"
    
    private void SetValueEditPC(DataTable dtSRC)
    {
        txttenxeploai.Text = dtSRC.Rows[0]["tenxeploai"].ToString();
        txtmaphieu.Value = dtSRC.Rows[0]["idxeploai"].ToString();
        txtGhiChu.Text = dtSRC.Rows[0]["ghichu"].ToString();
        StaticData.SetFocus(this, "txttenxeploai"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int iidxeploai)
    {
        string strSQL = "SELECT p.* FROM xeploai p WHERE status='true' and idxeploai = " + iidxeploai;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListXepLoai(string sWhere)
    {
        string strSQL = "SELECT p.* FROM xeploai p ";
        strSQL += " WHERE  status='true' " + sWhere;
        strSQL += " ORDER BY tenxeploai ASC";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (txttenxeploai.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập tên xếp loại. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txttenxeploai");
            return false;
        }
        if (txtGhiChu.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập ghi chú. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtGhiChu");
            return false;
        }
        
        return true;
    }
    private void SetValueEmpty()
    {
        txttenxeploai.Text = "";
        txtGhiChu.Text = "";
        strSearch = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            //Lấy id 
                int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idxeploai),0)+1 as MaxID from xeploai ").Rows[0][0].ToString());
                //thêm chức vụ
                NhanSu_Process.XepLoai CV = NhanSu_Process.XepLoai.Insert_Object(id.ToString(), txttenxeploai.Text.Trim(), txtGhiChu.Text.Trim(), "1");
                if (CV == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin xếp loại. Vui lòng thử lại sau.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Lưu thành công!.");
                    BindListXepLoai("");
                    SetValueEmpty();
                    StaticData.SetFocus(this, "txttenxeploai");
                }
            
        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtmaphieu.Value);
            NhanSu_Process.XepLoai CV = new NhanSu_Process.XepLoai();
            CV.idxeploai = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), txttenxeploai.Text.Trim(), txtGhiChu.Text.Trim(), "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Cập nhật thông tin xếp loại thành công.");
                BindListXepLoai("");
                SetValueEmpty();
                VisibleBtn(true);
            }
            else
                StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
            StaticData.SetFocus(this, "txttenxeploai");

        }
    }
    protected void btnTim_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = "";
        if (txttenxeploai.Text.Trim() != "")
            strSearch += " and tenxeploai like N'%" + txttenxeploai.Text.Trim() + "%' ";
        if (txtGhiChu.Text.Trim() != "")
            strSearch += " and ghichu like N'%" + txtGhiChu.Text.Trim() + "%' ";
        //string Search = "SELECT * FROM chucvu  WHERE status='true' "+strSearch;
        BindListXepLoai(strSearch);
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtmaphieu.Value = "";
        VisibleBtn(true);
        StaticData.SetFocus(this, "txttenxeploai");
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
    public void DelXepLoai(object s, DataGridCommandEventArgs e)
    {
        int imaphong;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string sqlDelete = "update xeploai set status='0' where idxeploai=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListXepLoai(strSearch);

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
        BindListXepLoai(strSearch);
    }
    #endregion    
    
}

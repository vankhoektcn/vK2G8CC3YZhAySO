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
public partial class LoaiTangCaEntry : Page
{
   static string strSearch;
    SqlConnection conn = DataAcess.Connect.Conn;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListLoaiTangCa("");
            StaticData.SetFocus(this, "txttenLoaiTangCa");
        }
    }
    #region "U Function"
    
    private void SetValueEditPC(DataTable dtSRC)
    {
        txttenLoaiTangCa.Text = dtSRC.Rows[0]["tenloaitangca"].ToString();
        txtmaphieu.Value = dtSRC.Rows[0]["idloaitangca"].ToString();
        txtHeSoLuong.Text = dtSRC.Rows[0]["hesoluong"].ToString();
        StaticData.SetFocus(this, "txttenLoaiTangCa"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int iidloaitangca)
    {
        string strSQL = "SELECT p.* FROM loaitangca p WHERE status='true' and idloaitangca = " + iidloaitangca;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListLoaiTangCa(string sWhere)
    {
        string strSQL = "SELECT p.* FROM loaitangca p ";
        strSQL += " WHERE  status='true' " + sWhere;
        strSQL += " ORDER BY tenloaitangca ASC";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (txttenLoaiTangCa.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập tên loại tăng ca. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txttenLoaiTangCa");
            return false;
        }
        if (txtHeSoLuong.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập hệ số lương. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtHeSoLuong");
            return false;
        }
        float heso;
        try
        {
            heso= float.Parse(txtHeSoLuong.Text.Trim());
        }
        catch
        {
            StaticData.MsgBox(this, "Hệ số lương không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtHeSoLuong");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txttenLoaiTangCa.Text = "";
        txtHeSoLuong.Text = "";
        strSearch = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            //Lấy id 
                int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idloaitangca),0)+1 as MaxID from loaitangca ").Rows[0][0].ToString());
                //thêm chức vụ
                NhanSu_Process.LoaiTangCa CV = NhanSu_Process.LoaiTangCa.Insert_Object(id.ToString(), txttenLoaiTangCa.Text.Trim(), txtHeSoLuong.Text.Trim(), "1");
                if (CV == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin Loại tăng ca. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Lưu thành công!.");
                    BindListLoaiTangCa("");
                    SetValueEmpty();
                    StaticData.SetFocus(this, "txttenLoaiTangCa");
                }
            
        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtmaphieu.Value);
            NhanSu_Process.LoaiTangCa CV = new NhanSu_Process.LoaiTangCa();
            CV.idloaitangca = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), txttenLoaiTangCa.Text.Trim(), txtHeSoLuong.Text.Trim(), "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Cập nhật thông tin loại tăng ca thành công.");
                BindListLoaiTangCa("");
                SetValueEmpty();
                VisibleBtn(true);
            }
            else
                StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
            StaticData.SetFocus(this, "txttenLoaiTangCa");

        }
    }
    protected void btnTim_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = "";
        if (txttenLoaiTangCa.Text.Trim() != "")
            strSearch += " and tenloaitangca like N'%" + txttenLoaiTangCa.Text.Trim() + "%' ";
        if (txtHeSoLuong.Text.Trim() != "")
            strSearch += " and hesoluong ='" + txtHeSoLuong.Text.Trim() + "' ";
        //string Search = "SELECT * FROM chucvu  WHERE status='true' "+strSearch;
        BindListLoaiTangCa(strSearch);
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtmaphieu.Value = "";
        VisibleBtn(true);
        StaticData.SetFocus(this, "txttenLoaiTangCa");
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
    public void DelLoaiTangCa(object s, DataGridCommandEventArgs e)
    {
        int imaphong;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string sqlDelete = "update loaitangca set status='0' where idloaitangca=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListLoaiTangCa(strSearch);

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
        BindListLoaiTangCa(strSearch);
    }
    #endregion    
    
}

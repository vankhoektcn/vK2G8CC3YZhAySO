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
public partial class LoaiNgayNghiEntry : Page
{
   static string strSearch;
    SqlConnection conn = DataAcess.Connect.Conn;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListLoaiNgayNghi("");
            StaticData.SetFocus(this, "txtMaLoaiNgayNghi");
        }
    }
    #region "U Function"
    
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtMaLoaiNgayNghi.Text = dtSRC.Rows[0]["maloaingaynghi"].ToString();
        txtMaLoaiNgayNghi.Enabled = false;
        txtmaphieu.Value = dtSRC.Rows[0]["idloaingaynghi"].ToString();
        txtMoTa.Text = dtSRC.Rows[0]["mota"].ToString();
        StaticData.SetFocus(this, "txtMaLoaiNgayNghi"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int iidloaingaynghi)
    {
        string strSQL = "SELECT p.* FROM loaingaynghi p WHERE status='true' and idloaingaynghi = " + iidloaingaynghi;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListLoaiNgayNghi(string sWhere)
    {
        string strSQL = "SELECT p.* FROM loaingaynghi p ";
        strSQL += " WHERE  status='true' " + sWhere;
        strSQL += " ORDER BY maloaingaynghi ASC";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (txtMaLoaiNgayNghi.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập mã loại ngày nghỉ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtMaLoaiNgayNghi");
            return false;
        }
        if (txtMoTa.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập mô tả. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtMoTa");
            return false;
        }
        
        return true;
    }
    private void SetValueEmpty()
    {
        txtMaLoaiNgayNghi.Text = "";
        txtMoTa.Text = "";
        strSearch = "";
        txtMaLoaiNgayNghi.Enabled = true;
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            if (!StaticData.CheckExist("loaingaynghi", "maloaingaynghi", txtMaLoaiNgayNghi.Text))
            {
                //Lấy id 
                int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idloaingaynghi),0)+1 as MaxID from loaingaynghi ").Rows[0][0].ToString());
                //thêm chức vụ
                NhanSu_Process.LoaiNgayNghi CV = NhanSu_Process.LoaiNgayNghi.Insert_Object(id.ToString(), txtMaLoaiNgayNghi.Text.Trim(), txtMoTa.Text.Trim(), "1");
                if (CV == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin loại ngày nghỉ. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Lưu thành công!.");
                    BindListLoaiNgayNghi("");
                    SetValueEmpty();
                    StaticData.SetFocus(this, "txtMaLoaiNgayNghi");
                }
            }
            else
            {
                StaticData.MsgBox(this, "Mã loại này đã tồn tại trong cơ sở dữ liệu rồi. Vui lòng chọn mã khác.");
                return;
            }
        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtmaphieu.Value);
            NhanSu_Process.LoaiNgayNghi CV = new NhanSu_Process.LoaiNgayNghi();
            CV.idloaingaynghi = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), txtMaLoaiNgayNghi.Text.Trim(), txtMoTa.Text.Trim(), "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Cập nhật thông tin loại ngày nghỉ thành công.");
                BindListLoaiNgayNghi("");
                SetValueEmpty();
                VisibleBtn(true);
            }
            else
                StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
            StaticData.SetFocus(this, "txtMaLoaiNgayNghi");

        }
    }
    protected void btnTim_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = "";
        if (txtMaLoaiNgayNghi.Text.Trim() != "")
            strSearch += " and maloaingaynghi like N'%" + txtMaLoaiNgayNghi.Text.Trim() + "%' ";
        if (txtMoTa.Text.Trim() != "")
            strSearch += " and mota like N'%" + txtMoTa.Text.Trim() + "%' ";
        //string Search = "SELECT * FROM chucvu  WHERE status='true' "+strSearch;
        BindListLoaiNgayNghi(strSearch);
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtmaphieu.Value = "";
        VisibleBtn(true);
        StaticData.SetFocus(this, "txtMaLoaiNgayNghi");
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
    public void DelLoaiNgayNghi(object s, DataGridCommandEventArgs e)
    {
        int imaphong;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string sqlDelete = "update loaingaynghi set status='0' where idloaingaynghi=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListLoaiNgayNghi(strSearch);

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
        BindListLoaiNgayNghi(strSearch);
    }
    #endregion    
    
}

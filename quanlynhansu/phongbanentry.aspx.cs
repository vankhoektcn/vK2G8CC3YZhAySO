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

public partial class phongbanentry : Page
{
   string strSearch;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListPhongKham("");
            StaticData.SetFocus(this, "txtMaPhongBenh");
        }
    }
    #region "U Function"
    
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtMaPhongKham.Text = dtSRC.Rows[0]["maphongban"].ToString();
        //txtMaPhongKham.ReadOnly = true;
        txtTenPhongKham.Text = dtSRC.Rows[0]["tenphongban"].ToString();
        txtGhiChu.Text = dtSRC.Rows[0]["ghichu"].ToString();
        txtmaphieu.Value = dtSRC.Rows[0]["idphongban"].ToString();
        StaticData.SetFocus(this, "txtTenPhongKham"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int imaphong)
    {
        string strSQL = "SELECT p.* FROM phongban p WHERE idphongban = " + imaphong;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListPhongKham(string sWhere)
    {
        string strSQL = "SELECT p.* FROM phongban p";
        strSQL += " WHERE status='1' " + sWhere;
        strSQL += " ORDER BY idphongban DESC";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (txtMaPhongKham.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập mã phòng khám. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtMaPhongKham");
            return false;
        }
        if (txtTenPhongKham.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập tên phòng khám. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtTenPhongKham");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txtMaPhongKham.Text = "";
        txtTenPhongKham.Text = "";
        txtGhiChu.Text = "";        
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            if (!StaticData.CheckExist("phongban", "maphongban", txtMaPhongKham.Text))
            {
                //Lấy id 
                int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idphongban),0)+1 as MaxID from phongban ").Rows[0][0].ToString());
                //thêm chức vụ
                NhanSu_Process.PhongBan CV = NhanSu_Process.PhongBan.Insert_Object(id.ToString(), txtMaPhongKham.Text.Trim(), txtTenPhongKham.Text.Trim(), txtGhiChu.Text.Trim(), "1");
                if (CV == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin Phòng Ban. Vui lòng thử lại.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Lưu thành công!.");
                    BindListPhongKham("");
                    strSearch = "";
                    SetValueEmpty();
                    StaticData.SetFocus(this, "txtMaPhongKham");
                }
            }
            else
            {
                StaticData.MsgBox(this, "Mã Phòng Ban này đã tồn tại trong cơ sở dữ liệu rồi. Vui lòng chọn mã khác lại.");
                return;
            }
            

        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtmaphieu.Value);
            NhanSu_Process.PhongBan CV = new NhanSu_Process.PhongBan();
            CV.idphongban = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), txtMaPhongKham.Text.Trim(), txtTenPhongKham.Text.Trim(), txtGhiChu.Text, "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Cập nhật thông tin Phòng Ban thành công.");
                BindListPhongKham("");
                SetValueEmpty();
                VisibleBtn(true);
            }
            else
                StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
            StaticData.SetFocus(this, "txtMaPhongKham");

        }
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtMaPhongKham.ReadOnly = false;
        VisibleBtn(true);
        StaticData.SetFocus(this, "txtMaPhongKham");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = GetChuoiSearch();
        BindListPhongKham(strSearch);
    }
    private string GetChuoiSearch()
    {
        string skq = "";
        if (txtMaPhongKham.Text != "")
        {
            skq += " AND p.maphongban LIKE '%" + txtMaPhongKham.Text.Trim() + "%' ";
        }
        if (txtTenPhongKham.Text != "")
        {
            skq += " AND p.tenphongban LIKE '%" + txtTenPhongKham.Text.Trim() + "%' ";
        }
        //if (ddltoathuoc.SelectedValue != "0")
        //{
        //    skq += " AND p.idtoathuoc = " + ddltoathuoc.SelectedValue;
        //}
        if (txtGhiChu.Text != "")
        {
            skq += " AND p.ghichu LIKE N'%" + txtGhiChu.Text.Trim() + "%' ";
        }
        return skq;
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
        if (StaticData.ParseInt(Session["isnhomadmin"]) == 0)
        {

            int imaphong;
            imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
            string deletePB = " update phongban set status='0' where idphongban=" + imaphong;
            bool kt = DataAcess.Connect.ExecSQL(deletePB);
            if (kt)
                BindListPhongKham(strSearch);
            else
                StaticData.MsgBox(this,"Có lỗi khi xóa Phòng Ban !.Vui lòng thử lại sau.");
        }
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
            if (e.Item.Cells[5].Text == "0")
                e.Item.Cells[5].Text = "Phòng khám bình thường";
            else
                e.Item.Cells[5].Text = "Phòng khám cận lâm sàng";
        }
    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BindListPhongKham(strSearch);
    }
    #endregion    
    
}

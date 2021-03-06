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
public partial class LoaiNgayNghiCtyEntry : Page
{
   static string strSearch;
    SqlConnection conn = DataAcess.Connect.Conn;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListLoaiNgayNghi();
            BindListNgayNghiCongTy("");

            StaticData.SetFocus(this, "ddlLoaiNgayNghi");
        }
    }
    #region "U Function"
    private void BindListLoaiNgayNghi()
    {
        string strSQL = "SELECT *,Ma_MoTa= maloaingaynghi+'_'+mota FROM loaingaynghi where status='1' ORDER BY maloaingaynghi";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlLoaiNgayNghi, dt, "idloaingaynghi", "Ma_MoTa", "Chọn loại ngày nghỉ");
    }
    private void SetValueEditPC(DataTable dtSRC)
    {
        ddlLoaiNgayNghi.SelectedValue = dtSRC.Rows[0]["idsua"].ToString();
        //txtMaLoaiNgayNghi.Enabled = false;
        txtmaphieu.Value = dtSRC.Rows[0]["idngaynghicongty"].ToString();
        txtMoTa.Text = dtSRC.Rows[0]["ghichu"].ToString();
        StaticData.SetFocus(this, "ddlLoaiNgayNghi"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int iidloaingaynghi)
    {
        string strSQL = "SELECT *,idsua=p.idloaingaynghi,loaingaynghi=lnn.maloaingaynghi +'_'+lnn.mota FROM ngaynghicongty p left join loaingaynghi lnn on p.idloaingaynghi=lnn.idloaingaynghi WHERE p.status='true' and idngaynghicongty = " + iidloaingaynghi;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListNgayNghiCongTy(string sWhere)
    {
        string strSQL = "SELECT *,loaingaynghi=lnn.maloaingaynghi +'_'+lnn.mota FROM ngaynghicongty p ";
        strSQL += " left join loaingaynghi lnn on p.idloaingaynghi=lnn.idloaingaynghi";
        strSQL += " WHERE  p.status='1' and lnn.status='1' " + sWhere;
        strSQL += " ORDER BY lnn.maloaingaynghi ASC";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (ddlLoaiNgayNghi.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn loại ngày nghỉ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "ddlLoaiNgayNghi");
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
        ddlLoaiNgayNghi.SelectedValue = "0";
        txtMoTa.Text = "";
        strSearch = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            
                //Lấy id 
                int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idngaynghicongty),0)+1 as MaxID from ngaynghicongty ").Rows[0][0].ToString());
                //thêm chức vụ
                NhanSu_Process.NgayNghiCongTy CV = NhanSu_Process.NgayNghiCongTy.Insert_Object(id.ToString(), ddlLoaiNgayNghi.SelectedValue, txtMoTa.Text.Trim(), "1");
                if (CV == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin ngày nghỉ. Vui lòng thử lại sau.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Lưu thành công!.");
                    BindListNgayNghiCongTy("");
                    SetValueEmpty();
                    StaticData.SetFocus(this, "ddlLoaiNgayNghi");
                }
            
        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtmaphieu.Value);
            NhanSu_Process.NgayNghiCongTy CV = new NhanSu_Process.NgayNghiCongTy();
            CV.idngaynghicongty = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), ddlLoaiNgayNghi.SelectedValue, txtMoTa.Text.Trim(), "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Cập nhật thông tin loại ngày nghỉ thành công.");
                BindListNgayNghiCongTy("");
                SetValueEmpty();
                VisibleBtn(true);
            }
            else
                StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
            StaticData.SetFocus(this, "ddlLoaiNgayNghi");

        }
    }
    protected void btnTim_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = "";
        if (ddlLoaiNgayNghi.SelectedValue != "0")
            strSearch += " and p.idloaingaynghi ='" + ddlLoaiNgayNghi.SelectedValue + "' ";
        if (txtMoTa.Text.Trim() != "")
            strSearch += " and ghichu like N'%" + txtMoTa.Text.Trim() + "%' ";
        //string Search = "SELECT * FROM chucvu  WHERE status='true' "+strSearch;
        BindListNgayNghiCongTy(strSearch);
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtmaphieu.Value = "";
        VisibleBtn(true);
        StaticData.SetFocus(this, "ddlLoaiNgayNghi");
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
        string sqlDelete = "update ngaynghicongty set status='0' where idngaynghicongty=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListNgayNghiCongTy(strSearch);

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
        BindListNgayNghiCongTy(strSearch);
    }
    #endregion    
    
}

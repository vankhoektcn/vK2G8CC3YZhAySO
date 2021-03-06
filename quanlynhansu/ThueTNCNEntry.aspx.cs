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
public partial class ThueTNCNEntry : Page
{
   static string strSearch;
    SqlConnection conn = DataAcess.Connect.Conn;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListHeSoThueTNCN("");
            StaticData.SetFocus(this, "txtMaThue");
        }
    }
    #region "U Function"
    
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtLuongtu.Text = dtSRC.Rows[0]["LuongTu"].ToString().Trim();
        txtLuongDen.Text = dtSRC.Rows[0]["LuongDen"].ToString().Trim();
        txtHeso.Text = dtSRC.Rows[0]["HeSo"].ToString();
        txtMaThue.Text = dtSRC.Rows[0]["MaTTNCN"].ToString();
        txtmaphieu.Value = dtSRC.Rows[0]["idThueTNCN"].ToString();
        txtGhiChu.Text = dtSRC.Rows[0]["ghichu"].ToString();
        StaticData.SetFocus(this, "txtMaThue"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int iidchucvu)
    {
        string strSQL = "SELECT p.* FROM Thue_TNCN p WHERE status='true' and idThueTNCN = " + iidchucvu;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListHeSoThueTNCN(string sWhere)
    {
        string strSQL = "SELECT p.* FROM Thue_TNCN p ";
        strSQL += " WHERE  status='true' " + sWhere;
        strSQL += " ORDER BY MaTTNCN ASC";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (txtLuongtu.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập mã chức vụ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtmachucvu");
            return false;
        }
        if (txtHeso.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập tên chức vụ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txttenchucvu");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txtLuongtu.Text = "";
        txtLuongDen.Text = "";
        txtHeso.Text = "";
        txtMaThue.Text = "";
        txtGhiChu.Text = "";
        strSearch = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //if (CheckValid(0))
        //{
        if (!StaticData.CheckExist("Thue_TNCN", "MaTTNCN", txtMaThue.Text))
            {
                //Lấy id 
                int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idThueTNCN),0)+1 as MaxID from Thue_TNCN ").Rows[0][0].ToString());
                //thêm chức vụ
                NhanSu_Process.Thue_TNCN CV = NhanSu_Process.Thue_TNCN.Insert_Object(id.ToString(),txtMaThue.Text.Trim(), txtLuongtu.Text.Trim(), txtLuongDen.Text.Trim(), txtHeso.Text.Trim(), txtGhiChu.Text, "1");
                if (CV == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin hệ số Bảo Hiểm ! Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Lưu thành công!.");
                    BindListHeSoThueTNCN("");
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
            NhanSu_Process.Thue_TNCN CV = new NhanSu_Process.Thue_TNCN();
            CV.idThueTNCN = imahh.ToString();
            bool kt = CV.Save_Object(imahh.ToString(), txtMaThue.Text.Trim(), txtLuongtu.Text.Trim(), txtLuongDen.Text.Trim(), txtHeso.Text.Trim(), txtGhiChu.Text, "1");
            if (kt)
            {
                StaticData.MsgBox(this, "Cập nhật thông tin chức vụ thành công.");
                BindListHeSoThueTNCN("");
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
        if (txtMaThue.Text.Trim() != "")
            strSearch = " and MaTTNCN='" + txtMaThue.Text.Trim() + "' ";
        if (txtLuongtu.Text.Trim() != "")
            strSearch += " and LuongTu >=" + txtLuongtu.Text.Trim() + " ";
        if (txtLuongDen.Text.Trim() != "")
            strSearch += " and LuongDen <=" + txtLuongDen.Text.Trim() + " ";
        if (txtHeso.Text != "")
            strSearch += " and HeSo=" + txtHeso.Text.Trim();
        if (txtGhiChu.Text.Trim() != "")
            strSearch += " and ghichu like N'%" + txtGhiChu.Text.Trim() + "%' ";
        BindListHeSoThueTNCN(strSearch);
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
        string sqlDelete = "update Thue_TNCN set status='0' where idThueTNCN=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListHeSoThueTNCN(strSearch);

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
        BindListHeSoThueTNCN(strSearch);
    }
    #endregion    
    
}

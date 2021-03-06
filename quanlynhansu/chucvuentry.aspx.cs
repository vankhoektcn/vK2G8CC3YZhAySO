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
public partial class chucvuentry : Page
{
   static string strSearch;
    SqlConnection conn = DataAcess.Connect.Conn;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindListChucVu("");
            StaticData.SetFocus(this, "txtmachucvu");
        }
    }
    #region "U Function"
    
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtmachucvu.Text = dtSRC.Rows[0]["machucvu"].ToString();
        //txtmachucvu.Enabled = false;
        txttenchucvu.Text = dtSRC.Rows[0]["tenchucvu"].ToString();
        txtmaphieu.Value = dtSRC.Rows[0]["idchucvu"].ToString();
        txtGhiChu.Text = dtSRC.Rows[0]["ghichu"].ToString();
        if (dtSRC.Rows[0]["chamcong"].ToString() == "True")
            ckbChamCong.Checked = true;
        else
            ckbChamCong.Checked = false;
        StaticData.SetFocus(this, "txttenchucvu"); 
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(int iidchucvu)
    {
        string strSQL = "SELECT p.* FROM chucvu p WHERE status='true' and idchucvu = " + iidchucvu;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private void BindListChucVu(string sWhere)
    {
        string strSQL = "SELECT p.idchucvu,p.machucvu,p.tenchucvu,p.ghichu,p.status,";
        strSQL+=" case when isnull(p.chamcong,1)=1 then N'Có' else N'không' End as ChamCong ";
        strSQL += " ,isnull(convert(bit,(SELECT top 1 isnull(chamcong,0) from chucvu where idchucvu=p.idchucvu )),0) as IsCheck  ";
        strSQL += "FROM chucvu p WHERE  status='true' " + sWhere;
        strSQL += " ORDER BY tenchucvu ASC";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (txtmachucvu.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập mã chức vụ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtmachucvu");
            return false;
        }
        if (txttenchucvu.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập tên chức vụ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txttenchucvu");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txtmachucvu.Text = "";
        txttenchucvu.Text = "";
        txtGhiChu.Text = "";
        txtmachucvu.Enabled = true;
        ckbChamCong.Checked = false;
        strSearch = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            if (!StaticData.CheckExist( "chucvu", "machucvu", txtmachucvu.Text))
            {
                //Lấy id 
                int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idchucvu),0)+1 as MaxID from chucvu ").Rows[0][0].ToString());
                //id++;
                //thêm chức vụ
                NhanSu_Process.ChucVu CV;
                //UPDATE 15_09_2011
                if (ckbChamCong.Checked == true)
                {
                    CV = NhanSu_Process.ChucVu.Insert_Object(id.ToString(), txtmachucvu.Text.Trim(), txttenchucvu.Text.Trim(), txtGhiChu.Text.Trim(), "1", "1");
                }
                else
                {
                    CV = NhanSu_Process.ChucVu.Insert_Object(id.ToString(), txtmachucvu.Text.Trim(), txttenchucvu.Text.Trim(), txtGhiChu.Text.Trim(), "1", "0");
                }
                    if (CV == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin chức vụ. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Lưu thành công!.");
                    BindListChucVu("");
                    SetValueEmpty();
                    StaticData.SetFocus(this, "txtmachucvu");
                }
            }
            else
            {
                StaticData.MsgBox(this, "Mã chức vụ này đã tồn tại trong cơ sở dữ liệu rồi. Vui lòng kiểm tra lại.");
                return;
            }
            

        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtmaphieu.Value);
            NhanSu_Process.ChucVu CV = new NhanSu_Process.ChucVu();
            CV.idchucvu = imahh.ToString();
            bool kt;
            if (ckbChamCong.Checked == true)
            {
                kt = CV.Save_Object(imahh.ToString(), txtmachucvu.Text.Trim(), txttenchucvu.Text.Trim(), txtGhiChu.Text, "1","1");
            }
            else
            {
                kt = CV.Save_Object(imahh.ToString(), txtmachucvu.Text.Trim(), txttenchucvu.Text.Trim(), txtGhiChu.Text, "1","0");

            }
            if (kt)
            {
                StaticData.MsgBox(this, "Cập nhật thông tin chức vụ thành công.");
                BindListChucVu("");
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
        if (txtmachucvu.Text.Trim() != "")
            strSearch = " and machucvu='" + txtmachucvu.Text.Trim() + "' ";
        if (txttenchucvu.Text.Trim() != "")
            strSearch += " and tenchucvu like N'%" + txttenchucvu.Text.Trim() + "%' ";
        if (txtGhiChu.Text.Trim() != "")
            strSearch += " and ghichu like N'%" + txtGhiChu.Text.Trim() + "%' ";
        //string Search = "SELECT * FROM chucvu  WHERE status='true' "+strSearch;
        BindListChucVu(strSearch);
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        VisibleBtn(true);
        StaticData.SetFocus(this, "txtmachucvu");
    }
    
    private string GetChuoiSearch()
    {
        string skq = "";
        
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
        int imaphong;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string sqlDelete = "update chucvu set status='0' where idchucvu=" + imaphong;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListChucVu(strSearch);

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
        BindListChucVu(strSearch);
    }
    #endregion    
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (dgr.Items.Count > 0)
        {
            for (int i = 0; i <= dgr.Items.Count - 1; i++)
            {
                try
                {
                    string idChucVu = ((Label)dgr.Items[i].FindControl("lblIdChucVu")).Text;
                    string isChamCong = "0";
                    if (((CheckBox)dgr.Items[i].FindControl("chkSelect")).Checked == true)
                    {
                        isChamCong = "1";
                    }
                    NhanSu_Process.ChucVu CV = new NhanSu_Process.ChucVu();
                    CV.idchucvu = idChucVu;
                    CV.Update_chamcong(isChamCong);
                }
                catch (Exception)
                {
                    StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
                    return;
                }
            }
            StaticData.MsgBox(this,"Cập nhật thành công !");
        }
    }
}

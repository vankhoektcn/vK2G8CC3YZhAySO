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

public partial class dm_nguoidung : Genaratepage
{
   string strSearch;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
          
           // SetValueEmpty();
            //BindListPhongKham();
          //  BindListBacSi("");
           // StaticData.SetFocus(this, "txtMaBacSi");
            loadddl();
            loaddata();
            
            VisibleBtn(true);
        }
       PlaceHolder1.Controls.Add(LoadControl("~/QuanlyNguoiDung/menu_HeThong.ascx"));
    }
    #region "U Function"

    
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtTenBacSi.Text = dtSRC.Rows[0]["tenbacsi"].ToString();
        txtUserName.Text = dtSRC.Rows[0]["username"].ToString();
        txtPassWord.Text = "********";
        txtDienThoai.Text = dtSRC.Rows[0]["dienthoai"].ToString();
        txtmabacsi_edit.Value = dtSRC.Rows[0]["idbacsi"].ToString();
        txtUserName.Enabled = false;
        txtPassWord.Enabled = false;
        StaticData.SetFocus(this, "txtTenBacSi"); 
    }


    private void VisibleBtn(bool bl)
    {
            btnAdd.Visible = bl;
            btnEdit.Visible = !bl;

    }
    private DataTable LoaDdataEdit(int imaphong)
    {
        string strSQL = "SELECT bs.* FROM bacsi bs WHERE idbacsi = " + imaphong;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }
    void loadddl()
    {
        string sql = "select * from nhomnguoidung where nhomID not in (8,9)";
        DataTable Dt =  DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(DDlnhom, Dt, "nhomID", "tennhom", "--Chọn nhóm người dùng--");
    }
    void loaddata()
    {
        string Sql = "select ND.*,NN.tennhom from nguoidung ND left join nhomnguoidung NN on ND.nhomID=NN.nhomID where isnull( idbacsi,0)=0" ;
        if (this.DDlnhom.SelectedValue != "0")
            Sql += " AND ND.NHOMid=" + DDlnhom.SelectedValue;
        DataTable Dt = DataAcess.Connect.GetTable(Sql);
        GVlistUser.DataSource = Dt;
        GVlistUser.DataBind();
    }
    private void BindListBacSi(string sWhere)
    {
        //string strSQL = "SELECT bs.*, pk.tenphongkhambenh FROM bacsi bs INNER JOIN phongkhambenh pk ON bs.idphongkhambenh = pk.idphongkhambenh";
        //strSQL += " WHERE 1=1 " + sWhere;
        //strSQL += " ORDER BY idbacsi DESC";
        //DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        //dgr.DataSource = dtCTPhieu;
        //dgr.DataBind();
    }
    private bool CheckValid(int isadd)
    {
        if (txtTenBacSi.Text == "")
        {
           StaticData.MsgBox(this, "Bạn chưa nhập tên người dùng. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtTenBacSi");
            return false;
        }
        if (txtUserName.Text == "")
        {
           StaticData.MsgBox(this, "Bạn chưa nhập tên truy cập hệ thống. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtUserName");
            return false;
        }
        if (isadd == 0)
        {
            if (txtPassWord.Text == "")
            {
               StaticData.MsgBox(this, "Bạn chưa nhập mật khẩu truy cập. Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtPassWord");
                return false;
            }
            if (checkthename(txtUserName.Text) == 1)
            {
               StaticData.MsgBox(this, "Tên đăng nhập này đã tồn tại. Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtUserName");
                return false;
            }
            if (checkgroup(txtTenBacSi.Text, StaticData.ParseInt(DDlnhom.SelectedValue.ToString())) == 1)
            {
               StaticData.MsgBox(this, "Đã có tên này trong nhóm " + DDlnhom.SelectedValue.ToString() + ". Vui lòng kiểm tra lại.");
                StaticData.SetFocus(this, "txtTenBacSi");
                return false;
            }
        }
        if (txtDienThoai.Text == "")
        {
           StaticData.MsgBox(this, "Bạn chưa nhập điện thoại của người dùng. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtDienThoai");
            return false;
        }
        if (DDlnhom.SelectedIndex.ToString() == "--Chọn nhóm người dùng--" || DDlnhom.SelectedIndex.ToString() == "0")
        {
           StaticData.MsgBox(this, "Bạn chưa chọn nhóm cho người dùng. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "DDlnhom");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txtTenBacSi.Text = "";
        txtDienThoai.Text = "";
        txtUserName.Text = "";
        txtPassWord.Text = "";
        txtpassold.Text = "";
        DDlnhom.SelectedIndex = -1;
    }
    int checkthename(string tes)
    {
        int a = 0;
        string sql = "select * from nguoidung where username='" + tes + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0 || dt == null)
        {
            a = 1;
        }
        return a;
    }
    int checkgroup(string names,int groups)
    {
        int sdfd = 0;
        string sql = "select nd.* from nguoidung nd where nd.tennguoidung='" + names + "' and nd.nhomID=" + groups;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0 || dt == null)
        {
            sdfd = 1;
        }
        return sdfd;
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        DataTable table = DataAcess.Connect.GetTable("select * from nhanvien where tennhanvien=N'"+txtTenBacSi.Text+"'");
        string idnguoidung = "";
        if (table.Rows.Count > 0)
        {
            idnguoidung = table.Rows[0]["idnhanvien"].ToString();
        }
        if (CheckValid(0))
        {
            Process.nguoidung tempND = Process.nguoidung.Insert_Object(this.txtTenBacSi.Text,
                                                                        this.txtUserName.Text,
                                                                        this.txtPassWord.Text,
                                                                        this.txtDienThoai.Text,
                                                                        "0", 
                                                                        this.DDlnhom.SelectedValue.ToString()
                                                                        , "","",idnguoidung);
              if(tempND==null)
                {
                   StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin người dùng. Vui lòng kiểm tra lại.");
                    return;
                }
                this.DDlnhom.SelectedValue = tempND.nhomID;
                loaddata();
                SetValueEmpty();
                StaticData.SetFocus(this, "txtMaBacSi");
                txtTenBacSi.Focus();
        }
    }
   

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            Process.nguoidung tempND = new Process.nguoidung();
            tempND.idnguoidung = txtmabacsi_edit.Value;
            bool OK = tempND.Save_Object (this.txtTenBacSi.Text,
                                                                        this.txtUserName.Text,
                                                                        this.txtPassWord.Text,
                                                                        this.txtDienThoai.Text,
                                                                        "0",
                                                                        this.DDlnhom.SelectedValue.ToString(),
                                                                          "",tempND.IdClient,tempND.idnguoidung);
            if(!OK)                                                          
            {
               StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin người dùng. Vui lòng kiểm tra lại.");
                return;
            }
           StaticData.MsgBox(this, "Cập nhật thông tin người dùng thành công.");
            loaddata();
            SetValueEmpty();
            VisibleBtn(true);
            StaticData.SetFocus(this, "txtMaBacSi");

        }
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
       // strSearch = "";
        VisibleBtn(true);
        StaticData.SetFocus(this, "txtMaBacSi");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = GetChuoiSearch();
        BindListBacSi(strSearch);
    }
    private string GetChuoiSearch()
    {
        string skq = "";
        if (txtTenBacSi.Text != "")
        {
            skq += " AND bs.tenbacsi LIKE '%" + txtTenBacSi.Text.Trim() + "%' ";
        }
        if (txtDienThoai.Text != "")
        {
            skq += " AND bs.dienthoai LIKE '%" + txtDienThoai.Text.Trim() + "%' ";
        }
        
        return skq;
    }
    private void BindCTPhieu(DataTable dtSRC)
    {
       // if (dtSRC == null) return;
        //dgr.DataSource = dtSRC;
      //  dgr.DataBind();
    }
    #endregion
    #region "Grid Event"
   
    #endregion    
    
    protected void GVlistUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVlistUser.PageIndex = e.NewPageIndex;
        loaddata();
    }
    protected void GVlistUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "edit1")
        {
            string sql = "select * from nguoidung where idnguoidung=" + StaticData.ParseInt(e.CommandArgument.ToString());
            DataTable dt = DataAcess.Connect.GetTable(sql);
            txtDienThoai.Text = dt.Rows[0]["dienthoai"].ToString();
            txtmabacsi_edit.Value = dt.Rows[0]["idnguoidung"].ToString();
            txtpassold.Text = dt.Rows[0]["matkhau"].ToString();
            txtPassWord.Text = "*********";
            txtTenBacSi.Text = dt.Rows[0]["tennguoidung"].ToString();
            txtUserName.Text = dt.Rows[0]["username"].ToString();
            DDlnhom.SelectedIndex = DDlnhom.Items.IndexOf(DDlnhom.Items.FindByValue(dt.Rows[0]["nhomID"].ToString()));
            VisibleBtn(false);
        }
        else if (e.CommandName.ToString() == "delete1")
        {
            DataAcess.Connect.ExecSQL("DELETE FROM NGUOIDUNG WHERE IDNGUOIDUNG=" + e.CommandArgument.ToString()); 
            loaddata();
            SetValueEmpty();
        }
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string TenDangNhap = this.txtUserName.Text;
        string TenNguoiDung = this.txtTenBacSi.Text;
        string NhomNguoiDung = this.DDlnhom.SelectedItem.Value;
        string Sql = "select ND.*,NN.tennhom from nguoidung ND left join nhomnguoidung NN on ND.nhomID=NN.nhomID"
        + " where 1=1";//ND.nhomid<>"+StaticData.IdNhomKhamBenhID;
        if (NhomNguoiDung != null && NhomNguoiDung != "0" && NhomNguoiDung != "" && NhomNguoiDung != "-1")
            Sql += " AND ND.nhomID=" + NhomNguoiDung;
        if (TenDangNhap != "")
            Sql += " and username like N'%"+TenDangNhap+"%'";

        if (TenNguoiDung != "")
            Sql += " and tennguoidung like N'%" + TenNguoiDung + "%'";

        DataTable Dt = DataAcess.Connect.GetTable(Sql);
        GVlistUser.DataSource = Dt;
        GVlistUser.DataBind();

    }
}

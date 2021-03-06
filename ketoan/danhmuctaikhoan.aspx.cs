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
using System.Drawing.Printing;

public partial class danhmuctaikhoan : System.Web.UI.Page
{
    string strSearch = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            LoadDanhSachTK("");
            VisibleBtn(true);
        }
        bool quyenthem = StaticData.HavePermision(this.Page, "KeToanDM_danhmuctaikhoan_Them");
        if (quyenthem)
            btnAdd.Visible = true;
        else
            btnAdd.Visible = false;
    }
    #region "U Function"
    private void LoadDanhSachTK(string sWHERE)
    {
        string strSQL = "SELECT TaiKhoan, TenTaiKhoan, ";
        strSQL += " case when isnull(ChiTiet,'0')='0' then '' else N'TK chi tiết' end as ChiTiet, ";
        strSQL += " TKCapCha, Cap, LoaiTien FROM DanhMucTK ";
        if (sWHERE != "")
            strSQL += sWHERE;
        strSQL += " Order by TaiKhoan ";
        //DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dt;
        dgr.DataBind();
    }
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtTaiKhoan.Text = dtSRC.Rows[0]["TaiKhoan"].ToString();
        //txtTaiKhoan.ReadOnly = true;
        txtCap.Text = dtSRC.Rows[0]["Cap"].ToString();
        chkChiTiet.Checked=(dtSRC.Rows[0]["ChiTiet"].ToString()=="1"?true:false);
        txtTenTaiKhoan.Text = dtSRC.Rows[0]["TenTaiKhoan"].ToString();
        txtCapCha.Text = dtSRC.Rows[0]["TKCapCha"].ToString();
        txtLoaiTien.Text = dtSRC.Rows[0]["LoaiTien"].ToString();
        StaticData.SetFocus(this, "txtTaiKhoan");
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(string strTaiKhoan)
    {
        string strSQL = "SELECT * FROM DanhMucTK ";
        if (strTaiKhoan != "")
            strSQL += "WHERE TaiKhoan like '%" + strTaiKhoan + "%'";
        //DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }


    private bool CheckValid(int isadd)
    {
        if (txtTaiKhoan.Text == "")
        {
            StaticData.MsgBox(this, "Tài khoản không được bỏ trống!");
            StaticData.SetFocus(this, "txtTaiKhoan");
            return false;
        }
        
        //if (chkChiTiet.Checked== false)
        //{
        //    if (txtCapCha.Text == "")
        //    {
        //        StaticData.MsgBox(this, "Bạn chưa nhập tài khoản cấp cha!");
        //        StaticData.SetFocus(this, "txtCapCha");
        //        return false;
        //    }
        //}
        return true;
    }
    private void SetValueEmpty()
    {
        txtCap.Text = "";
        txtTaiKhoan.Text = "";
        txtTenTaiKhoan.Text = "";
        txtLoaiTien.Text = "";
        chkChiTiet.Checked = false;
        txtCapCha.Text = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            string sql1 = "select * from DanhMucTK where TaiKhoan ='"+txtTaiKhoan.Text.Trim()+"'";
            DataTable dt = DataAcess.Connect.GetTable(sql1);
            if (dt != null && dt.Rows.Count > 0)
            {
                StaticData.MsgBox(this, "Tài khoản này đã tồn tại!");
                return;
            }
            else
            {
                string strSQL;
                //1/. cap nhat DanhMucTK
                strSQL = "Insert into DanhMucTK(TaiKhoan, TenTaiKhoan, ChiTiet, TKCapCha, Cap, LoaiTien) ";
                strSQL += " Values ( ";
                strSQL += " '" + txtTaiKhoan.Text + "',";
                strSQL += " N'" + txtTenTaiKhoan.Text + "',";
                strSQL += " '" + (chkChiTiet.Checked == true ? 1 : 0) + "', ";
                strSQL += " '" + txtCapCha.Text + "', ";
                strSQL += " '" + txtCap.Text + "', ";
                strSQL += " '" + txtLoaiTien.Text + "'";
                strSQL += " )";
                try
                {
                    //mdlCommonFunction.Exec(strSQL, conn);
                    DataAcess.Connect.ExecSQL(strSQL);
                    StaticData.MsgBox(this, "Đã thêm mới thành công!");
                    //return 1;
                }
                catch (Exception)
                {
                    //Response.Write(0);                    
                    StaticData.MsgBox(this, "Lỗi thêm mới dữ liệu!");
                    //return 0;
                }
            }                        
            LoadDanhSachTK("");
            strSearch = "";
            SetValueEmpty();
            txtTaiKhoan.Focus();
        }
    }

    public bool kiemtracaptk(string tk)
    {
        bool kq = false;
        int captk =0;
        int capmax = 0;
        string tkc1 = tk.Substring(0, 3);
        string sql = "select taikhoan,cap from danhmuctk where taikhoan like '"+tkc1+"%'";
        string sql2 = "select taikhoan,cap from danhmuctk where taikhoan ='"+tk+"'";        
        DataTable dt2=DataAcess.Connect.GetTable(sql2);
        if (dt2 != null && dt2.Rows.Count > 0)
        {
            captk = int.Parse(dt2.Rows[0]["cap"].ToString());
        }
        DataTable dt = DataAcess.Connect.GetTable(sql);

        try
        {
            for (int i = 0; dt.Rows.Count > i; i++)
            {
                int ss = int.Parse(dt.Rows[i]["cap"].ToString());
                if (ss > captk)
                {
                    capmax = ss;
                    kq = false;
                }
                else
                {
                    capmax = captk;
                    kq = true;
                }

            }
        }
        catch
        { }
        
        return kq;        
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            string sql = "";
            int idtk = 0;
            string tkchon = Session["chontaikhoan"].ToString();
            sql = "select idtaikhoan from danhmuctk where taikhoan='"+tkchon+"'";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                idtk = Int16.Parse(dt.Rows[0]["idtaikhoan"].ToString());
            }

            string strSQL;
            strSQL = "Update DanhMucTK ";
            strSQL += "Set taikhoan='"+txtTaiKhoan.Text+"',";
            strSQL += " TenTaiKhoan = ";            
            strSQL += " N'" + txtTenTaiKhoan.Text + "', Cap = ";
            strSQL += " '" + txtCap.Text + "', ChiTiet = ";
            strSQL += " '" + (chkChiTiet.Checked == true ? 1 : 0) + "', TKCapCha = ";
            strSQL += " '" + txtCapCha.Text + "', LoaiTien = ";
            strSQL += " '" + txtLoaiTien.Text + "'";
            strSQL += " Where idtaikhoan = " + idtk;
            try
            {
                DataAcess.Connect.ExecSQL(strSQL);                
            }
            catch (Exception)
            {
                //Response.Write(0);
                StaticData.MsgBox(this, "Lỗi cập nhật dữ liệu!");
                //return 0;
            }
            

            StaticData.MsgBox(this, "Đã cập nhật thành công!");
            LoadDanhSachTK(strSearch);
            SetValueEmpty();
            VisibleBtn(true);
            txtTaiKhoan.ReadOnly = false;            
            StaticData.SetFocus(this, "txtTaiKhoan");        
        }
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtTaiKhoan.ReadOnly = false;
        VisibleBtn(true);
        StaticData.SetFocus(this, "txtTaiKhoan");        
        LoadDanhSachTK("");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        dgr.CurrentPageIndex = 0;
        strSearch = GetChuoiSearch();
        LoadDanhSachTK(strSearch);
    }
    private string GetChuoiSearch()
    {
        string skq = " WHERE 1=1 ";
        if (txtTaiKhoan.Text != "")
        {
            skq += " AND TaiKhoan like '%" + txtTaiKhoan.Text + "%' ";
        }
        if (txtTenTaiKhoan.Text != "")
        {
            skq += " AND TenTaiKhoan LIKE N'%" + txtTenTaiKhoan.Text.Trim() + "%' ";
        }
        return skq;
    }
    
    #endregion
    #region "Grid Event"
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        string strTaiKhoan;
        strTaiKhoan = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);        
        if (kiemtracaptk(strTaiKhoan))
        {
            Session["chontaikhoan"] = strTaiKhoan;
            DataTable dtEdit = LoaDdataEdit(strTaiKhoan);
            SetValueEditPC(dtEdit);
            VisibleBtn(false);
        }
        else
            StaticData.MsgBox(this, "Chỉ được sửa tài khoản chi tiết!");        
    }
    
    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool quyenthem = StaticData.HavePermision(this.Page, "KeToanDM_danhmuctaikhoan_Them");
            bool quyensua = StaticData.HavePermision(this.Page, "KeToanDM_danhmuctaikhoan_Sua");
            bool quyenxoa = StaticData.HavePermision(this.Page, "KeToanDM_danhmuctaikhoan_Xoa");
            btn = (LinkButton)(e.Item.Cells[0].FindControl("lbtnDel"));
            LinkButton btnsua = (LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"));
            if (quyensua)
                btnsua.Visible = true;
            else
                btnsua.Visible = false;
            if (quyenxoa)
                btn.Visible = true;
            else
                btn.Visible = false;

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
    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        LoadDanhSachTK(strSearch);
    }
    #endregion    
   
   
    protected void DelTaiKhoan(object source, DataGridCommandEventArgs e)
    {
        string strTaiKhoan;
        strTaiKhoan = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);
        string strSQL;
        strSQL = "Delete DanhMucTK ";
        strSQL += " Where TaiKhoan = ";
        strSQL += " '" + strTaiKhoan + "'";
        try
        {
            DataAcess.Connect.ExecSQL(strSQL);
            //mdlCommonFunction.Exec(strSQL, conn);
            //return 1;
        }
        catch (Exception)
        {
            //Response.Write(0);
            StaticData.MsgBox(this,"Lỗi xóa dữ liệu!");            
            //return 0;
        }
        LoadDanhSachTK(strSearch);

    }
}

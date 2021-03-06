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
using System.IO;
using System.Data.SqlClient;

//ThuanNH 10/05/2010
public partial class DanhMucTKNH : System.Web.UI.Page
{
    
    string strSearch = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        bool quyenthem = StaticData.HavePermision(this.Page, "KeToanNH_DanhMucTKNH_Them");
        bool quyensua = StaticData.HavePermision(this.Page, "KeToanNH_DanhMucTKNH_Sua");
        if (quyenthem || quyensua)
        {
            btnAdd.Visible = true;
            
        }
        else
        {
            btnAdd.Visible = false;
            
        }
        if(quyensua)
            btnEdit.Visible = true;
        else
            btnEdit.Visible = false;
    //    Page_Init();
        if (!IsPostBack)
        {
            LoadDanhSachTKNH("");
            //VisibleBtn(true);
        }
    }
    #region "U Function"
    private void LoadDanhSachTKNH(string sWHERE)
    {
        string strSQL = "SELECT * FROM DANHMUCTKNH ";
        if (sWHERE != "")
            strSQL += sWHERE;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);        
        dgr.DataSource = dt;
        dgr.DataBind();
    }
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtSoHieuTKNH.Text = dtSRC.Rows[0]["SoHieuTKNH"].ToString();
        txtSoHieuTKNH.ReadOnly = true;
        txtTaiKhoanKT.Text = dtSRC.Rows[0]["TaiKhoanKT"].ToString();
        txtTenTKNH.Text = dtSRC.Rows[0]["TenTKNH"].ToString();
        StaticData.SetFocus(this, "txtTaiKhoanKT");
    }


    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    private DataTable LoaDdataEdit(string strSoHieuTKNH)
    {
        string strSQL = "SELECT * FROM DANHMUCTKNH ";
        strSQL += " WHERE SoHieuTKNH = '" + strSoHieuTKNH + "'";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);        
        return dt;
    }


    private bool CheckValid(int isadd)
    {
        if (txtSoHieuTKNH.Text == "")
        {
            StaticData.MsgBox(this, "Số hiệu tài khoản NH không được để trống!");
            StaticData.SetFocus(this, "txtSoHieuTKNH");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txtSoHieuTKNH.Text = "";
        txtTaiKhoanKT.Text = "";
        txtTenTKNH.Text = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            string sql = "";
            sql="select * from danhmuctknh where sohieutknh='"+txtSoHieuTKNH.Text.Trim()+"'";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if(dt!=null && dt.Rows.Count<1)            
            {
                string strSQL;
                strSQL = "Insert into DanhMucTKNH(SoHieuTKNH, TenTKNH, TaikhoanKT) ";
                strSQL += " Values ( ";
                strSQL += " '" + txtSoHieuTKNH.Text + "',";
                strSQL += " N'" + txtTenTKNH.Text + "',";
                strSQL += " '" + txtTaiKhoanKT.Text + "'";
                strSQL += " )";
                try
                {                    
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
            else
            {
                StaticData.MsgBox(this, "Số hiệu TKNH đã tồn tại!");
                return;
            }
            LoadDanhSachTKNH("");
            strSearch = "";
            SetValueEmpty();
            txtSoHieuTKNH.Focus();
        }
    }


    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            string strSQL;
            strSQL = "Update DanhMucTKNH ";
            strSQL += " Set TenTKNH = ";
            strSQL += " N'" + txtTenTKNH.Text + "', TaiKhoanKT = ";
            strSQL += " N'" + txtTaiKhoanKT.Text + "'";
            strSQL += " Where SoHieuTKNH = ";
            strSQL += " '" + txtSoHieuTKNH.Text + "'";
            try
            {
                DataAcess.Connect.ExecSQL(strSQL);
                //return 1;
            }
            catch (Exception)
            {
                //Response.Write(0);
                StaticData.MsgBox(this, "Lỗi cập nhật dữ liệu!");
                //return 0;
            }
            StaticData.MsgBox(this, "Đã cập nhật thành công!");
            LoadDanhSachTKNH(strSearch);
            SetValueEmpty();
            VisibleBtn(true);
            txtSoHieuTKNH.ReadOnly = false;
            StaticData.SetFocus(this, "txtSoHieuTKNH");
        }
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtSoHieuTKNH.ReadOnly = false;
        VisibleBtn(true);
        StaticData.SetFocus(this, "txtSoHieuTKNH");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        dgr.CurrentPageIndex = 0;
        strSearch = GetChuoiSearch();
        LoadDanhSachTKNH(strSearch);
    }
    private string GetChuoiSearch()
    {
        string skq = "";
        if (txtSoHieuTKNH.Text != "")
        {
            skq += " AND SoHieuTKNH like '%" + txtSoHieuTKNH.Text + "%' ";
        }
        if (txtTenTKNH.Text != "")
        {
            skq += " AND TenTKNH LIKE '%" + txtTenTKNH.Text.Trim() + "%' ";
        }
        return skq;
    }
    
    #endregion
    #region "Grid Event"
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        string strSoHieuTKNH;

        strSoHieuTKNH = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);
        DataTable dtEdit = LoaDdataEdit(strSoHieuTKNH);
        SetValueEditPC(dtEdit);
        VisibleBtn(false);
        
    }
    public void DeltiepNhanDT(object s, DataGridCommandEventArgs e)
    {
        string strSoHieuTKNH;
        strSoHieuTKNH = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);
        string strSQL;
        strSQL = "Delete DanhMucTKNH ";
        strSQL += " Where SoHieuTKNH = ";
        strSQL += " '" + strSoHieuTKNH + "'";
        try
        {
            DataAcess.Connect.ExecSQL(strSQL);
            //return 1;
        }
        catch (Exception)
        {
            //Response.Write(0);             
            StaticData.MsgBox(this,"Lỗi xóa dữ liệu!");
            //return 0;
        }
        LoadDanhSachTKNH(strSearch);
        
    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        bool quyensua = StaticData.HavePermision(this.Page, "KeToanNH_DanhMucTKNH_Sua");
        bool quyenxoa = StaticData.HavePermision(this.Page, "KeToanNH_DanhMucTKNH_Xoa");
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
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
        LoadDanhSachTKNH(strSearch);
    }
    #endregion    
   
}

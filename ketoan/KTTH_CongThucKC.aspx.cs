using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
public partial class ketoan_KTTH_CongThucKC : System.Web.UI.Page
{
    #region "Variables"    
    string strSearch = "";   

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            BindGrid("");
            LoadThang();
            LoadNam();
            
        }
        txtMaKetChuyen.Text = TaoMaTuDong();
    }
    #region Grid Event

    public void dgr_Sort(System.Object Sender, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        ViewState.Add("sortfield", e.SortExpression);
        if (ViewState["sortdirection"] == null)
        {
            ViewState.Add("sortdirection", "ASC");
        }
        else
        {
            if ((string)ViewState["sortdirection"] == "ASC")
            {
                ViewState["sortdirection"] = "DESC";
            }
            else
            {
                ViewState["sortdirection"] = "ASC";
            }
        }
        BindGrid(strSearch);
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
            //e.Item.Cells[3].Text = Convert.ToDateTime(e.Item.Cells[3].Text).ToString("dd/MM/yyyy");
            //e.Item.Cells[11].Text = mdlCommonFunction.FormatNumber(Convert.ToDouble(e.Item.Cells[11].Text), false).ToString();
        }

    }
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        dgr.EditItemIndex = e.Item.ItemIndex;
        BindGrid("");
    }

    protected void dgr_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        dgr.EditItemIndex = -1;
        BindGrid("");
    }

    protected void dgr_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        CheckBox chonkc = (CheckBox)dgr.Items[e.Item.ItemIndex].FindControl("chon_kc");
        bool chon_kc=false ;
        if (chonkc.Checked)
            chon_kc = true;
        else
            chon_kc = false;

        string TenKC = ((TextBox)dgr.Items[e.Item.ItemIndex].FindControl("txtTenKC")).Text;
        string STT = ((TextBox)dgr.Items[e.Item.ItemIndex].FindControl("txtSTT")).Text;
        string TuTK = ((TextBox)dgr.Items[e.Item.ItemIndex].FindControl("txtTuTaiKhoan")).Text;
        string DenTK = ((TextBox)dgr.Items[e.Item.ItemIndex].FindControl("txtDenTaiKhoan")).Text;
        string CongThuc = ((DropDownList)dgr.Items[e.Item.ItemIndex].FindControl("ddlCongThuc_Datalist")).SelectedValue;        
        //string CongThuc = ((TextBox)dgr.Items[e.Item.ItemIndex].FindControl("ddlCongThuc_Datalist")).Text;
        if (CongThuc != "0")
        {
            string sql = "";
            sql = " Update CongThucKetChuyen set TenKC=N'" + TenKC.Trim() + "', TuTaiKhoan='" + TuTK.Trim() + "'";
            sql += ", DenTaiKhoan='" + DenTK.Trim() + "', CongThuc='" + CongThuc.Trim() + "',status_kc='"+chon_kc+"'";
            sql += " Where MaKC='" + dgr.DataKeys[e.Item.ItemIndex].ToString() + "' and STT=" + STT;
            DataAcess.Connect.ExecSQL(sql);            
            dgr_CancelCommand(source, e);
            BindGrid("");
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Vui lòng chọn công thức kết chuyển.!');</script>");
        }
    }
    public void DelPhieuNhap(object s, DataGridCommandEventArgs e)
    {
    }

    public void BindData(DataTable dtSRC)
    {
        DataView dvSource = dtSRC.DefaultView;
        dvSource.AllowEdit = true;
        dvSource.AllowNew = true;
        dgr.DataSource = dvSource;
        dgr.DataBind();
    }
    public void BindGrid(string sSearch)
    {
        //khai bao server va cac databse
        DataTable tTable = new DataTable();

        if (ViewState["sortfield"] == null)
        {
            string strsql = "Select makc,tenkc,stt,tutaikhoan,dentaikhoan, congthuc ,giatri, ";
            strsql += "(case isnull(status_kc,0) when 0 then convert(bit,0) else convert(bit,1) end)status_kc  From CongThucKetChuyen ";
            strsql += "  order by stt ";
            tTable = DataAcess.Connect.GetTable(strsql);

            if (tTable.Rows.Count > 0)
            {
                for (int i = 0; i < tTable.Rows.Count; i++)
                {
                    DataRow row = tTable.Rows[i];
                    if (row["CongThuc"].ToString() == "1")
                        row["CongThuc"] = "KC Nợ -> Có";
                    else
                        if (row["CongThuc"].ToString() == "2")
                            row["CongThuc"] = "KC Có -> Nợ";
                        else
                            if (row["CongThuc"].ToString() == "3")
                                row["CongThuc"] = "KC Lãi-Lỗ";
                    System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert(" + row["CongThuc"].ToString() + ");</script>");
                }
            }
            
            DataView dvSource = tTable.DefaultView;
            dvSource.AllowEdit = true;
            dvSource.AllowNew = true;

            dgr.DataSource = dvSource;
            dgr.DataBind();
            if (tTable.Rows.Count < 15)
                infospace.InnerHtml = "<p><p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;";
        }
    }

    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BindGrid(strSearch);
    }

    #endregion

    protected void LoadThang()
    {
        for (int i = 1; i <= 12; i++)
        {
            ddlThang.Items.Add(i.ToString("00"));
            if (i == DateTime.Now.Month)
                ddlThang.SelectedValue = i.ToString("00");
        }
    }

    protected void LoadNam()
    {
        int yearCurrent = DateTime.Now.Year;
        for (int i = yearCurrent; i <= (yearCurrent + 5); i++)
        {
            ddlNam.Items.Add(i.ToString("00"));
            if (i == DateTime.Now.Year)
                ddlNam.SelectedValue = i.ToString();
        }
    }

    private void form_unload(object sender, System.EventArgs e)
    {

    }

    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(form_unload);
    }

    #endregion

    protected string TaoMaTuDong()
    {
        string sql = "select top(1) MaKC from CongThucKetChuyen order by  MaKC desc";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        int count = 0;
        if (tb != null && tb.Rows.Count > 0)
        {
            string[] buffer = tb.Rows[0][0].ToString().Split('-');
            count = int.Parse(buffer[1]) + 1;
        }
        else
            count = 1;
        string MaKetChuyen = "KC-00" + count;
        return MaKetChuyen;
    }
    protected string getValueddCongThuc()
    {
        string rs = ddlCongThuc.SelectedValue.ToString();
        return rs;
    }
    //protected int getValueddCongThucDatalist()
    //{
    //    int rs = Int32.Parse(ddlCongThuc.SelectedValue.ToString());
    //    return rs;
    //}

    protected void ResetForm()
    {
        txtMaKetChuyen.Text = TaoMaTuDong();
        txtDenTK.Text = "";
        txtDienGiai.Text = "";
        txtTuTK.Text = "";
        ddlCongThuc.SelectedValue = "0";
    }
    protected bool checkIsKetChuyen(int thang, int nam,string ma_kc)
    {
        string Thang = "";
        if (thang < 0)
            Thang = "0" + thang.ToString();
        else
            Thang = thang.ToString();

        string sql = "select ma_ct from So_Cai where ma_ct = '" + ma_kc + "/" + thang.ToString() + "/" + nam.ToString() + "'";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        if (tb != null && tb.Rows.Count > 0)
        {
            return true;
        }
        else return false;
    }
    protected void DeleteKetChuyen(int thang, int nam,string ma_kc)
    {
        string Thang = "";
        if (thang < 10)
            Thang = "0" + thang;
        else
            Thang = thang.ToString();
        string sql = "delete so_cai where ma_ct = '" + ma_kc + "/" + thang.ToString() + "/" + nam.ToString() + "'";
        int rs = DataAcess.Connect.Exec(sql);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Session["MaPhieu"] = null;
        //Response.Redirect("toathuocentry.aspx");
    }


    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (SysParameter.UserLogin.UserID(this) == null || SysParameter.UserLogin.UserID(this) == "0" || SysParameter.UserLogin.UserID(this) == "")
        {
            Response.Redirect("login.aspx");
        }
        if (e.CommandName == "Delete")
        {
            string STT = ((Label)dgr.Items[e.Item.ItemIndex].FindControl("STT")).Text;
            string sql = "Delete CongThucKetChuyen Where MaKC='" + dgr.DataKeys[e.Item.ItemIndex].ToString() + "' and STT=" + STT;// +data.ParseInt(e.Item.Cells[3].Text);            
            DataAcess.Connect.ExecSQL(sql);
            ResetForm();
            BindGrid("");
        }
        else
        {

        }
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        string CongThuc = getValueddCongThuc();
        if (CongThuc != "0")
        {
            DataTable tTable = new DataTable();
            string sql = "";

            string STT = txtSTT.Text;
            sql = "Delete CongThucKetChuyen Where MaKC='" + txtMaKetChuyen.Text;
            DataAcess.Connect.ExecSQL(sql);
            //Insert 
            sql = "Insert into CongThucKetChuyen(MaKC,TenKC,STT,TuTaiKhoan,DenTaiKhoan,CongThuc,PhuongPhap,GiaTri)";//"sp_XuatHoaDonPK '" + mdlCommonFunction.CheckDate(txtNgay.Text) + "','" + mdlCommonFunction.CheckDate(txtDenNgay.Text) + "'";
            sql += "      Values('" + txtMaKetChuyen.Text + "',N'" + txtDienGiai.Text + "'," + STT.ToString() + ", '" + txtTuTK.Text + "', '" + txtDenTK.Text + "', '" + CongThuc + "','',0)";
            tTable = DataAcess.Connect.GetTable(sql);
            DataView dvSource = tTable.DefaultView;
            dvSource.AllowEdit = true;
            dvSource.AllowNew = true;

            dgr.DataSource = dvSource;
            dgr.DataBind();
            BindGrid("");
            ResetForm();
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Vui lòng chọn công thức kết chuyển.!');</script>");
        }
    }
    List<clsKetChuyen> list = new List<clsKetChuyen>();
    protected void btnKetChuyen_Click(object sender, EventArgs e)
    {
        list = new List<clsKetChuyen>();
        try
        {
            int ThangKC = Int32.Parse(ddlThang.SelectedValue.ToString());
            int NamKC = Int32.Parse(ddlNam.SelectedValue.ToString());
            string sql = "Select * From CongThucKetChuyen where status_kc=1  order by  STT asc";
            DataTable dt = DataAcess.Connect.GetTable(sql);            
           
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool checkKetChuyen = checkIsKetChuyen(ThangKC, NamKC,dt.Rows[i]["MaKC"].ToString());
                    if (checkKetChuyen)
                    {
                        DeleteKetChuyen(ThangKC, NamKC, dt.Rows[i]["MaKC"].ToString());
                    }            
                    clsKetChuyen kc = new clsKetChuyen();
                    //kc.MaKetChuyen = mdlCommonFunction.TaoMaSoTuDong_TheoNgayTuChon(ThangKC, NamKC, "So_Cai", "KCTK", "Ma_CT");
                    kc.MaKetChuyen = dt.Rows[i]["MaKC"].ToString() + "/" + ThangKC.ToString() + "/" + NamKC.ToString();
                    string NgayKC = "01/" + ThangKC.ToString() + "/" + NamKC.ToString();
                    //kc.NgayKetChuyen = DateTime.Parse(mdlCommonFunction.ChangeDateTo_MM_dd(NgayKC));
                    kc.NgayKetChuyen = DateTime.Parse(StaticData.CheckDate_kt(NgayKC));
                    kc.Thang = int.Parse(ddlThang.SelectedValue.ToString());
                    kc.Nam = int.Parse(ddlNam.SelectedValue.ToString());
                    kc.TKNo = dt.Rows[i]["TuTaiKhoan"].ToString();
                    kc.TKCo = dt.Rows[i]["DenTaiKhoan"].ToString();
                    kc.CongThuc = Int32.Parse(dt.Rows[i]["CongThuc"].ToString());
                    kc.DienGiai = dt.Rows[i]["TenKC"].ToString();
                    list.Add(kc);
                }
                LuuKetChuyen();
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Chưa có công thức kết chuyển. Vui lòng cập nhật công thức kết chuyển. Cảm ơn!');</script>");
            }
        }
        catch (Exception ex)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Có lỗi : " + ex.Message.ToString() + "!');</script>");
        }
    }

    protected void LuuKetChuyen()
    {
        int CountItem = list.Count;
        bool rs = false;
        string sql2 = "";
        string tk911 = "";
        string tk421 = "";
        string congthuc = "";
        try
        {
            for (int i = 0; i < CountItem; i++)
            {
                clsKetChuyen kc = list[i];
                tk911 = kc.TKNo.Substring(0, 3);
                tk421 = kc.TKCo.Substring(0, 3);
                congthuc = kc.CongThuc.ToString();
                //if (string.Compare(tk911, "911") < 0)
                if(string.Compare(congthuc,"1")==0)
                {
                    //kết chuyển các tài khoản loại 5,7(tu loai 5,7->loai 9)
                    sql2 = "select distinct tai_khoan from So_Cai where Month(ngay_lap_ct)=" + kc.Thang + " and year(ngay_lap_ct)=" + kc.Nam + " and Tai_Khoan like '" + kc.TKNo + "%'";
                    DataTable dt = DataAcess.Connect.GetTable(sql2);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            string sql = " Exec sp_KetChuyenTaiKhoan " + kc.Thang + "," + kc.Nam + ",'" + dt.Rows[j]["tai_khoan"].ToString() + "','" + kc.TKCo + "'," + kc.CongThuc + ",'" + kc.MaKetChuyen + "','" + kc.NgayKetChuyen + "',N'" + kc.DienGiai + "'";
                            if (DataAcess.Connect.ExecSQL(sql))
                                rs = true;
                            else
                                rs = false;
                        }
                    }
                }                
                    //ket chuyen từ có sang nợ: loại 6,8->9
                     if(string.Compare(congthuc,"2")==0)
                    {
                        sql2 = "select distinct tai_khoan from So_Cai where Month(ngay_lap_ct)=" + kc.Thang + " and year(ngay_lap_ct)=" + kc.Nam + " and Tai_Khoan like '" + kc.TKCo + "%'";
                        DataTable dt = DataAcess.Connect.GetTable(sql2);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                string sql = " Exec sp_KetChuyenTaiKhoan " + kc.Thang + "," + kc.Nam + ",'" + kc.TKNo + "','" + dt.Rows[j]["tai_khoan"].ToString() + "'," + kc.CongThuc + ",'" + kc.MaKetChuyen + "','" + kc.NgayKetChuyen + "',N'" + kc.DienGiai + "'";
                                if (DataAcess.Connect.ExecSQL(sql))
                                    rs = true;
                                else
                                    rs = false;
                            }
                        }
                        
                    }
                //ket chuyen tu 911->421
                    if(string.Compare(congthuc,"3")==0)
                    {
                        sql2 = "select distinct tai_khoan from So_Cai where Month(ngay_lap_ct)=" + kc.Thang + " and year(ngay_lap_ct)=" + kc.Nam + " and Tai_Khoan like '" + kc.TKNo + "%'";
                        DataTable dt = DataAcess.Connect.GetTable(sql2);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                string sql = " Exec sp_KetChuyenTaiKhoan " + kc.Thang + "," + kc.Nam + ",'" + dt.Rows[j]["tai_khoan"].ToString() + "','" + kc.TKCo + "'," + kc.CongThuc + ",'" + kc.MaKetChuyen + "','" + kc.NgayKetChuyen + "',N'" + kc.DienGiai + "'";
                                if (DataAcess.Connect.ExecSQL(sql))
                                    rs = true;
                                else
                                    rs = false;
                            }
                        }
                    }                
            }
            if (rs)
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Kết chuyển tài khoản thành công!');</script>");
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Kết chuyển tài khoản thất bại!');</script>");
            }
            //conn.Close();
        }
        catch (Exception ex)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Có lỗi : " + ex.Message.ToString() + "!');</script>");
        }

    }
    
}

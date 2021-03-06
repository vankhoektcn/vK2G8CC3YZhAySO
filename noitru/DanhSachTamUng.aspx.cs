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
using System.Collections.Generic;
public partial class CapCuu_DanhSachTamUng : Genaratepage
{
    string strSearch;
    string dkmenu = null;
    private string login_IdBacsi = null;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {

            SetValueEmpty();
            this.txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            StaticData.SetFocus(this, "txtMaBenhNhan");
            //bind_ddlthangnam();
            BindListBenhNhan("");
            loadPK();
            noidungkcb();
            loadPhongKham();
        }
               
         dkmenu = Request.QueryString["dkmenu"].ToString();

        if (dkmenu == "kb")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
        }
     
        if (dkmenu == "tiepnhan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        }
        if (dkmenu == "thuphi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
        }
        if (dkmenu == "thongke")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/thongke/uscmenu.ascx"));
        }
        if (dkmenu == "capcuu")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/CapCuu/uscmenu.ascx"));
        }
    }

    
    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }


    #region "U Function"

    private void loadPK()
    {
        string sql = ""
                     + " SELECT * FROM PHONGKHAMBENH " + "\r\n"
                     + " WHERE 1=1 "
                     + " AND LOAIPHONG=0" + "\r\n";
        if (this.login_IdBacsi != null && this.login_IdBacsi != "")
            sql += "AND IDPHONGKHAMBENH IN (SELECT IDPHONGKHAMBENH FROM BACSI_PHONGKHAM WHERE IDBACSI=" + login_IdBacsi + " )" + "\r\n";
        if (Request.QueryString["idkhoa"] != null)
            sql += " and idphongkhambenh= "+Request.QueryString["idkhoa"].ToString()+"";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (Request.QueryString["idkhoa"] != null)
            StaticData.FillCombo(ddlKhoa, dt, "idphongkhambenh", "tenphongkhambenh");
        else
            StaticData.FillCombo(ddlKhoa, dt, "idphongkhambenh", "tenphongkhambenh", "Chọn phòng/khoa");
        ddlKhoa.SelectedIndex = 0;
    }
    public void loadPhongKham()
    {
        string sql = "SELECT Id,TenPhong=ISNULL(MASO +'-','')+ TENPHONG  FROM kb_phong WHERE DichVuKCB=" + ddlNoidung.SelectedValue;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPhong, dt, "id", "tenphong", "-- Chọn Phòng Khám --");
        if (dt.Rows.Count > 0) ddlPhong.SelectedIndex = 0;
    }
    public void noidungkcb()
    {
        string sql = "SELECT IDBANGGIADICHVU,TENDICHVU FROM BANGGIADICHVU WHERE IDPHONGKHAMBENH=" + ddlKhoa.SelectedValue + "";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlNoidung, dt, "idbanggiadichvu", "tendichvu", "-- Chọn nội dung khám --");
        if (dt.Rows.Count > 0) ddlNoidung.SelectedIndex = 0;
    }
   
    private void BindListBenhNhan(string sWhere)
    {
        string ngaybt = "";
        string ngaykt = "";
        ngaybt = StaticData.CheckDate(txtTuNgay.Text.Trim());
        ngaykt = StaticData.CheckDate(txtDenNgay.Text.Trim());
        if (ngaykt != "")
            ngaykt = ngaykt + " 23:59:59";
        DataTable dtCTPhieu = new DataTable();
        if (txtMaBenhNhan.Text.Trim() == "" && txtTenBenhNhan.Text.Trim() == "")
        {
            if (txtTuNgay.Text != "")
            {
                sWhere += "and kb.idchitietdangkykham in(select iddangkykham from tamung where  iddangkykham=kb.idchitietdangkykham and ngaytamung>='" + StaticData.CheckDate(txtTuNgay.Text) + "')";
            }
            if (txtDenNgay.Text != "")
            {
                sWhere += "and kb.idchitietdangkykham in(select iddangkykham from tamung where  iddangkykham=kb.idchitietdangkykham and ngaytamung<='" + StaticData.CheckDate(txtDenNgay.Text) + " 23:58:59:999')";
            }
        }
        //StaticData.MsgBox(this,sWhere);
        string strSQL = @"select bn.*,kb.ngaykham,bs.tenbacsi,tendichvu=bg.tendichvu
    ,tenphongkham=isnull((select top 1 ph.maso+'-'+ph.tenphong from benhnhannoitru nn left join kb_phong ph on ph.id=nn.idphongnoitru where idchitietdangkykham=kb.idchitietdangkykham order by idnoitru desc)
                ,isnull((select top 1 ph.maso+'-'+ph.tenphong from kb_giuongphieuthanhtoan nn  left join kb_giuong gg on gg.giuongid=nn.idgiuongxet left join kb_phong ph on ph.id=gg.idphong where idchitietdangkykham=kb.idchitietdangkykham order by ngayxetgiuong desc),''))
,dkk.ngaydangky
,case when isnull(bn.gioitinh,0)=1 then N'Nữ' else N'Nam' end as Sex
    from benhnhan bn left join khambenh kb on bn.idbenhnhan=kb.idbenhnhan
            left join chitietdangkykham ctdkk on kb.idchitietdangkykham= ctdkk.idchitietdangkykham 
            left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
            left join kb_phong phong on ctdkk.phongid=phong.id
		    left join bacsi bs on bs.idbacsi= kb.idbacsi
            left join dangkykham dkk on dkk.iddangkykham= ctdkk.iddangkykham
    where isnull(idkhambenhgoc,0)=0 and (isnull(kb.hoantat,0)=0 or kb.idphongkhambenh=1)
    and kb.idchitietdangkykham in(select iddangkykham from tamung where iddangkykham=kb.idchitietdangkykham)
" + sWhere +" order by ngaykham desc";

        dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

        if (dtCTPhieu != null)
        {
            dgr.DataSource = dtCTPhieu;
            dgr.DataBind();
        }
    }

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtDienThoai.Text = "";
        txtDiaChi.Text = "";
        ddlGioiTinh.SelectedIndex = 0;
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtMaBenhNhan.ReadOnly = false;
        StaticData.SetFocus(this, "txtMaBenhNhan");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = GetChuoiSearch();
        BindListBenhNhan(strSearch);
    }
    private string GetChuoiSearch()
    {
        
        string skq = "";
        if (txtMaBenhNhan.Text != "")
        {
            skq += "  and bn.mabenhnhan LIKE '%" + txtMaBenhNhan.Text.Trim() + "%' ";
        }
        if (txtTenBenhNhan.Text != "")
        {
            skq += " AND bn.tenbenhnhan LIKE N'%" + txtTenBenhNhan.Text.Trim() + "%' ";
        }
        if (txtDienThoai.Text != "")
        {
            skq += " AND bn.dienthoai LIKE '%" + txtDienThoai.Text.Trim() + "%' ";
        }
        if (txtDiaChi.Text != "")
        {
            skq += " AND bn.diachi LIKE N'%" + txtDiaChi.Text.Trim() + "%' ";
        }
        if (ddlGioiTinh.SelectedValue != "-1")
        {
            skq += " AND bn.gioitinh = " + ddlGioiTinh.SelectedValue;
        }
        if (ddlKhoa.SelectedValue != "0")
        {
            skq += "and kb.idchitietdangkykham in(select iddangkykham from tamung where  iddangkykham=kb.idchitietdangkykham and idkhoaTU=" + ddlKhoa.SelectedValue + ")";
        }
        //if (ddlNoidung.SelectedValue != "0")
        //{
        //    skq += " and bg.idbanggiadichvu="+ddlNoidung.SelectedValue;
        //}
        //if (ddlPhong.SelectedValue != "0")
        //{
        //    skq += " and phong.id="+ddlPhong.SelectedValue;
        //}
        return skq;
    }
    #endregion
    #region "Grid Event"
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        int idbenhnhan;
        idbenhnhan = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        if (e.CommandName == "Edit")
        {
            if (Request.QueryString["idkhoa"] != null)
            { 
               // Response.Write("<script>window.open('../ThuVienPhi/ThuTamUng.aspx?idbenhnhan=" + idbenhnhan + "&idkhoa=" + Request.QueryString["idkhoa"].ToString() + "');</script>");
                string link = "../ThuVienPhi/ThuTamUng.aspx?idbenhnhan=" + idbenhnhan + "&idkhoa=" + Request.QueryString["idkhoa"].ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dfgw", "MoTrangMoi('"+link+"');", true);
            }
            else
            { 
                //Response.Write("<script>window.open('../ThuVienPhi/ThuTamUng.aspx?idbenhnhan=" + idbenhnhan + "');</script>");
                //Response.Redirect("../ThuVienPhi/ThuTamUng.aspx?idbenhnhan=" + idbenhnhan + "");
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dfgw", "MoTrangMoi('../ThuVienPhi/ThuTamUng.aspx?idbenhnhan=" + idbenhnhan + "');", true);
            }
        }
    }
    public void DelBenhNhan(object s, DataGridCommandEventArgs e)
    {
         
    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
          
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
        strSearch = GetChuoiSearch();
        BindListBenhNhan(strSearch);
        stt = e.NewPageIndex * dgr.PageSize + 1;
    }
    #endregion

    protected void InHoaDon(object source, DataGridCommandEventArgs e)
    {

    }
    protected void btlydo_Click(object sender, EventArgs e)
    {
        
    }
    protected void ddlKhoa_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlKhoa.SelectedValue != "0")
        {
            noidungkcb();
        }
    }
    protected void ddlNoidung_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNoidung.SelectedValue != "0")
        {
            loadPhongKham();
        }
    }
}

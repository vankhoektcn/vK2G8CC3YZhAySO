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
public partial class CapCuu_DanhSachBenhNhanNoiTru : Genaratepage
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
        if (dkmenu == "khoangoai")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khoangoai/uscmenu.ascx"));
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
        sql += " and idphongkhambenh=2 ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlKhoa, dt, "idphongkhambenh", "tenphongkhambenh", "Chọn phòng/khoa");
        if(dt.Rows.Count>0)
        ddlKhoa.SelectedIndex = 1;
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
        string sql = "SELECT IDBANGGIADICHVU,TENDICHVU FROM BANGGIADICHVU WHERE IDPHONGKHAMBENH=" + ddlKhoa.SelectedValue + " and idbanggiadichvu<>1790";
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
        string strSQL = @"select top 50 row_number() over(order by tenbenhnhan) as stt
,case when isnull(gioitinh,0)=0 then N'Nam' else N'Nữ' end as Gioi
         ,kb.idbenhnhan,kb.idkhambenh,mabenhnhan,tenbenhnhan,diachi
        ,dienthoai,gioitinh,ngaysinh as namsinh 
        ,iddichvugoc=bg.idbanggiadichvu
        ,tendichvugoc=bg.tendichvu
        ,idphonggoc=phong.id
        ,tenphonggoc=phong.maso +'-'+phong.tenphong
        ,kb.idphongchuyenden
        ,iddichvunoitru=bg1.idbanggiadichvu
        ,tendichvunoitru=bg1.tendichvu
        ,idphongnoitru=phong1.id
        ,tenphongnoitru=phong1.maso +'-'+phong1.tenphong
        ,GiuongNoiTru=g.Giuongcode
        ,tenbacsi=''
        ,ngaykham
        from khambenh kb left join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan
        left join chitietdangkykham ctdkk on kb.idchitietdangkykham= ctdkk.idchitietdangkykham 
        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
        left join kb_phong phong on ctdkk.phongid=phong.id

        left join banggiadichvu bg1 on kb.idDVphongchuyenden=bg1.idbanggiadichvu
        left join kb_phong phong1 on kb.idphongchuyenden=phong1.id
    left join kb_giuong g on kb.idDVphongchuyenden=g.giuongid
        where 1=1 and idkhambenh in(select idkhambenhgoc from dbo.[NVK_DSBNBenhAnNoiTruTheoKhoa_1](" + Request.QueryString["IdKhoa"].ToString() + @") where idkhambenhgoc=kb.idkhambenh )
    " + sWhere + "";
        //if (txtTuNgay.Text != "")
        //{
        //    strSQL += " and kb.ngaykham >='" + StaticData.CheckDate(txtTuNgay.Text) + "'";
        //}
        //if (txtDenNgay.Text != "")
        //{
        //    strSQL += " and kb.ngaykham <='" + StaticData.CheckDate(txtDenNgay.Text) + " 23:58:59:999'";
        //}
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
        //if (ddlKhoa.SelectedValue != "0")
        //{
        //    skq += "and phong1.idphongkhambenh="+ddlKhoa.SelectedValue;
        //}
        if (ddlNoidung.SelectedValue != "0")
        {
            skq += " and bg1.idbanggiadichvu="+ddlNoidung.SelectedValue;
        }
        if (ddlPhong.SelectedValue != "0")
        {
            skq += " and phong1.id="+ddlPhong.SelectedValue;
        }
        //if (txtTuNgay.Text != "")
        //{
        //    skq += " and kb.ngaykham >='"+StaticData.CheckDate(txtTuNgay.Text)+"'";
        //}
        //if (txtDenNgay.Text != "")
        //{
        //    skq += " and kb.ngaykham <='"+StaticData.CheckDate(txtDenNgay.Text)+" 23:58:59:999'";
        //}
        return skq;
    }
    #endregion
    #region "Grid Event"
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        int idkhambenh;
        string idbenhnhan = e.CommandArgument.ToString();
        idkhambenh = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string sql = @"select madichvu,bg.idphongkhambenh--,kb.phongkhamchuyenden
,phongkhamchuyenden = isnull((select top 1 phongkhamchuyenden from khambenh k where  k.idchitietdangkykham=kb.idchitietdangkykham and isnull(k.phongkhamchuyenden,0)<>0)," + Request.QueryString["IdKhoa"].ToString() + @")
from khambenh kb left join banggiadichvu bg on bg.idbanggiadichvu=kb.iddvphongchuyenden
                    where --madichvu is not null and
            isnull(idkhambenhgoc,0)=0 and idkhambenh=" +idkhambenh+"";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count > 0 && dt.Rows[0]["idphongkhambenh"].ToString() == "2" || dt.Rows[0]["phongkhamchuyenden"].ToString() == "2")
            Response.Redirect("../noitru/Benhanngoaikhoa.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
        else if (dt.Rows.Count > 0 && dt.Rows[0]["idphongkhambenh"].ToString() == "4" || dt.Rows[0]["phongkhamchuyenden"].ToString() == "4")
            Response.Redirect("../noitru/Benhannoikhoa.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
        else 
            Response.Redirect("../noitru/Benhannoikhoa.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
        
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

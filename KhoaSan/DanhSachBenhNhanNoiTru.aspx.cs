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
    string madichvu;
    string idkhoa;
    protected void Page_Load(object sender, EventArgs e)
    {
        madichvu = Request.QueryString["madichvu"].ToString();
        idkhoa = Request.QueryString["idkhoa"].ToString();
       
        if (!IsPostBack)
        {

            SetValueEmpty();
            this.txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            StaticData.SetFocus(this, "txtMaBenhNhan");
            //bind_ddlthangnam();
            //BindListBenhNhan("");
            loadPK();
            LoadBenhAn();
            loadPhongKham();
            StaticData.SetFocus(this,"txtMaBenhNhan");
        }
               
         dkmenu = Request.QueryString["dkmenu"].ToString();
         LoadMenu();
     }
     private void LoadMenu()
     {
         try
         {
             string dkmenu = Request.QueryString["dkmenu"].ToString();
             PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
         }
         catch (Exception ex)
         {
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
        sql += " and idphongkhambenh="+idkhoa+@" ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlKhoa, dt, "idphongkhambenh", "tenphongkhambenh");
        if(dt.Rows.Count>0)
        ddlKhoa.SelectedIndex = 1;
    }
    public void loadPhongKham()
    {
        //string sql = "SELECT Id,TenPhong=ISNULL(MASO +'-','')+ TENPHONG  FROM kb_phong WHERE DichVuKCB=" + ddlNoidung.SelectedValue;
        //DataTable dt = DataAcess.Connect.GetTable(sql);
        //StaticData.FillCombo(ddlPhong, dt, "id", "tenphong", "-- Chọn Phòng Khám --");
        //if (dt.Rows.Count > 0) ddlPhong.SelectedIndex = 0;
    }
    public void LoadBenhAn()
    {
        string sql = @"SELECT id=1,tenbenhan=N'Ngoại trú'
            union all
            SELECT id=2,tenbenhan=N'Khoa sản'
            union all
            SELECT id=3,tenbenhan=N'Phụ khoa'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlNoidung, dt, "id", "tenbenhan","----Tất cả----");
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
        string strSQL = @" select row_number() over(order by ngaykham desc) as stt,* from (
select case when isnull(gioitinh,0)=0 then N'Nam' else N'Nữ' end as Gioi
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
       ,tenphongnoitru=isnull((select top 1 ph.maso+'-'+ph.tenphong from benhnhannoitru nn left join kb_phong ph on ph.id=nn.idphongnoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + Request.QueryString["IdKhoa"].ToString() + @" order by idnoitru desc)
                ,isnull((select top 1 ph.maso+'-'+ph.tenphong from kb_giuongphieuthanhtoan nn  left join kb_giuong gg on gg.giuongid=nn.idgiuongxet left join kb_phong ph on ph.id=gg.idphong where idchitietdangkykham=kb.idchitietdangkykham order by ngayxetgiuong desc),''))
        ,GiuongNoiTru=g.Giuongcode
        ,tenbacsi=''
        ,ngaykham,kb.sovaovien
, TenBenhAn=[dbo].[NVK_TenBenhAn](kb.idchitietdangkykham)
        from dbo.[NVK_DSBNBenhAnNoiTruTheoKhoa_1](" + idkhoa + @") nt left join khambenh kb on kb.idkhambenh=nt.idkhambenhgoc
        left join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan
        left join chitietdangkykham ctdkk on kb.idchitietdangkykham= ctdkk.idchitietdangkykham 
        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
        left join kb_phong phong on ctdkk.phongid=phong.id

        left join banggiadichvu bg1 on kb.idDVphongchuyenden=bg1.idbanggiadichvu
        left join kb_phong phong1 on kb.idphongchuyenden=phong1.id
    left join kb_giuong g on kb.idDVphongchuyenden=g.giuongid
        where 1=1 and isnull(kb.idkhambenhgoc,0)=0
--and idkhambenh in(select idkhambenhgoc from dbo.[NVK_DSBNBenhAnNoiTruTheoKhoa_1](" + idkhoa + @") where idkhambenhgoc=kb.idkhambenh )
       
        and kb.hoantat=0 
    
        " + sWhere + "";
        
        if (txtTuNgay.Text != "")
        {
            strSQL += " and ( ( kb.idchitietdangkykham in (select distinct idchitietdangkykham from khambenh where idchitietdangkykham=kb.idchitietdangkykham and ngaykham >='" + StaticData.CheckDate(txtTuNgay.Text) + "'  )";
            if (txtDenNgay.Text != "")
            {
                strSQL += " and kb.idchitietdangkykham in (select distinct idchitietdangkykham from khambenh where idchitietdangkykham=kb.idchitietdangkykham and ngaykham <='" + StaticData.CheckDate(txtDenNgay.Text) + " 23:58:59:999' )";
                //strSQL += " and kb.ngaykham <='" + StaticData.CheckDate(txtDenNgay.Text) + " 23:58:59:999'";
            }
            strSQL += @")
or kb.idchitietdangkykham in
	 (select distinct idchitietdangkykham from khambenh kk where idchitietdangkykham=kb.idchitietdangkykham and ngaykham <='" + StaticData.CheckDate(txtTuNgay.Text) + @"'
		and kk.idchitietdangkykham in (select top 1 idchitietdangkykham from benhnhannoitru where idchitietdangkykham=kk.idchitietdangkykham and idkhoanoitru=" + Request.QueryString["IdKhoa"].ToString() + @" and isdanhap=1 order by ngayvaovien desc)
	 )

)";
        }
        strSQL += @") as abc ";
        if (ddlNoidung.SelectedValue != "0" && ddlNoidung.SelectedValue != "")
            strSQL += @" where  abc.TenBenhAn=N'" + ddlNoidung.SelectedItem.Text + "' ";
        //strSQL += @" order by ngaykham desc";
        dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

        if (dtCTPhieu != null)
        {
            dgr.DataSource = dtCTPhieu;
            dgr.DataBind();
            txtSLBN.Text = dtCTPhieu.Rows.Count.ToString();
            DataView dvtemp = new DataView(dtCTPhieu.Copy());
            dvtemp.RowFilter = "TenBenhAn like '%Ngoại trú%'";
            this.txtSLKBH.Text = dvtemp.Count.ToString();
            dvtemp.RowFilter = "TenBenhAn like '%Khoa sản%'";
            this.txtSLKT.Text = dvtemp.Count.ToString();
            dvtemp.RowFilter = "TenBenhAn like '%Phụ khoa%'";
            this.txtSLKDV.Text = dvtemp.Count.ToString();
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
        if (txtSoVaoVien.Text != "")
        {
            skq += " AND kb.sovaovien LIKE N'%" + txtSoVaoVien.Text.Trim() + "%' ";
        }
        //if (ddlKhoa.SelectedValue != "0")
        //{
        //    skq += "and bg.idphongkhambenh=" + ddlKhoa.SelectedValue;
        //}
        //if (ddlNoidung.SelectedValue != "0")
        //{
        //    skq += " and bg.idbanggiadichvu="+ddlNoidung.SelectedValue;
        //}
        //if (ddlPhong.SelectedValue != "0")
        //{
        //    skq += " and phong.id="+ddlPhong.SelectedValue;
        //}
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
        string sql = @"select madichvu,isPhaThai=isnull((select huongdieutri from khambenh kk where kk.idchitietdangkykham=kb.idchitietdangkykham and huongdieutri=19),0)
            ,kb.idchitietdangkykham
            from khambenh kb 
            left join chitietdangkykham ctdkk on ctdkk.idchitietdangkykham=kb.idchitietdangkykham
            left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
                    where madichvu is not null and idkhambenh=" + idkhambenh + "";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count > 0 && dt.Rows[0]["madichvu"].ToString() == "12" && dt.Rows[0]["isPhaThai"].ToString() != "19")
        //Response.Redirect("../CapCuu/DanhSachPKBNoiTru.aspx?dkmenu=" + this.dkmenu + "&idkhambenh=" + idkhambenh + "&idbenhnhan=" + idbenhnhan);
        //Response.Redirect("../CapCuu/Benhancapcuu.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
            Response.Redirect("../KhoaSan/Benhankhoasan.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
        else if (dt.Rows.Count > 0 && dt.Rows[0]["isPhaThai"].ToString() == "19")
            Response.Redirect("../CapCuu/Benhancapcuu.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
        else if (dt.Rows.Count > 0 && dt.Rows[0]["madichvu"].ToString() == "3018")
            Response.Redirect("../noitru/Benhansosinh.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
        else
        {
            string sqlBA = "select top 1 convert(int,idkhambenh) from khambenh where idchitietdangkykham=" + dt.Rows[0]["idchitietdangkykham"].ToString() + " and idphongkhambenh=4";
            DataTable dtNT= DataAcess.Connect.GetTable(sqlBA);
            if(dtNT != null && dtNT.Rows.Count>0)
                Response.Redirect("../noitru/Benhannoikhoa.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
            else
            Response.Redirect("../KhoaSan/Benhanphukhoa.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
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
            LoadBenhAn();
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

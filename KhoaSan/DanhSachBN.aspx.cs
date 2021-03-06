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
public partial class DanhSachBN : Genaratepage
{
    string strSearch;
    string dkmenu = null;
    private string login_IdBacsi = null;
    string madichvu;
    string idkhoa;
    protected void Page_Load(object sender, EventArgs e)
    {
        //madichvu = Request.QueryString["madichvu"].ToString();
        idkhoa = Request.QueryString["idkhoa"].ToString();
       
        if (!IsPostBack)
        {

            SetValueEmpty();
            //this.txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            StaticData.SetFocus(this, "txtMaBenhNhan");
            //bind_ddlthangnam();
            BindListBenhNhan("");
            loadPK();
            //noidungkcb();
            //loadPhongKham();
            StaticData.SetFocus(this,"txtMaBenhNhan");
            // chiTiet("18554");
            if (Request.QueryString["idkhoa"].ToString() == "25")
            {
                trKhoa.Visible = false;
                ddlKhoa.Visible = false; spChonKhoa.Visible = false;
            }
        }

        LoadMenu();
    }
    private void LoadMenu()
    {
        try
        {
            string dkmenu = Request.QueryString["dkmenu"].ToString();
            PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
        }
        catch(Exception ex)
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
        string sql = "SELECT Id,TenPhong=ISNULL(MASO +'-','')+ TENPHONG  FROM kb_phong WHERE DichVuKCB=" + ddlNoidung.SelectedValue;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPhong, dt, "id", "tenphong", "-- Chọn Phòng Khám --");
        if (dt.Rows.Count > 0) ddlPhong.SelectedIndex = 0;
    }
    public void noidungkcb()
    {
        string sql = "SELECT IDBANGGIADICHVU,TENDICHVU FROM BANGGIADICHVU WHERE IDPHONGKHAMBENH=" + ddlKhoa.SelectedValue + "";//  and madichvu in('"+madichvu+@"')";//and idbanggiadichvu in(632,633)";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlNoidung, dt, "idbanggiadichvu", "tendichvu");
        if (dt.Rows.Count > 0) ddlNoidung.SelectedIndex = 0;
    }   
    private void BindListBenhNhan(string sWhere)
    {
        string ngaybt = "";
        string ngaykt = "";
        DataTable dtCTPhieu = new DataTable();
        string strSQL = @"";
        #region backup
//        strSQL =@"select top 20 row_number() over(order by tenbenhnhan) as stt
//,case when --isnull(kb.isdaravien,0)=0
//     isnull( (
//		select isdaravien from khambenh where idkhambenh in
//		(select top 1 idkhambenh from khambenh where idchitietdangkykham =kb.idchitietdangkykham and  isdaravien=1 order by idkhambenh desc)
//		and idkhambenh not in(select  idkhambenhnhap from benhnhannoitru where idkhoanoitru=" + this.idkhoa + @" and idchitietdangkykham=kb.idchitietdangkykham)
//		) ,0)=0
//then N'Chi tiết' else N'Đã chỉ định' end as TinhTrang
//         ,kb.idbenhnhan,kb.idkhambenh,mabenhnhan,tenbenhnhan,diachi
//        ,dienthoai,gioitinh=dbo.GetGioiTinh(gioitinh),ngaysinh as namsinh 
//        ,iddichvugoc=bg.idbanggiadichvu
//        ,tendichvugoc=bg.tendichvu
//        ,idphonggoc=phong.id
//        ,tenphonggoc=phong.maso +'-'+phong.tenphong
//        ,kb.idphongchuyenden
//        ,iddichvunoitru=bg1.idbanggiadichvu
//        ,tendichvunoitru=bg1.tendichvu
//        ,idphongnoitru=phong1.id
//        ,tenphongnoitru=isnull((select top 1 ph.maso+'-'+ph.tenphong from benhnhannoitru nn left join kb_phong ph on ph.id=nn.idphongnoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + this.idkhoa + @" order by idnoitru desc)
//                ,isnull((select top 1 ph.maso+'-'+ph.tenphong from kb_giuongphieuthanhtoan nn  left join kb_giuong gg on gg.giuongid=nn.idgiuongxet left join kb_phong ph on ph.id=gg.idphong where idchitietdangkykham=kb.idchitietdangkykham order by ngayxetgiuong desc),''))
//        ,tenbacsi=''
//        ,ngaykham,kb.idchitietdangkykham
//        from khambenh kb left join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan
//        left join chitietdangkykham ctdkk on kb.idchitietdangkykham= ctdkk.idchitietdangkykham 
//        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
//        left join kb_phong phong on ctdkk.phongid=phong.id
//
//        left join banggiadichvu bg1 on kb.idDVphongchuyenden=bg1.idbanggiadichvu
//        left join kb_phong phong1 on kb.idphongchuyenden=phong1.id
//        where 1=1 and (isnull(kb.hoantat,0)=0 or kb.idphongkhambenh=1 ) and isnull(idkhambenhgoc,0)=0
//--and  (kb.idphongkhambenh =" + this.idkhoa + @"
//-- or kb.idchitietdangkykham in(select idchitietdangkykham from khambenh where idchitietdangkykham=kb.idchitietdangkykham and huongdieutri in(1,7,8) and phongkhamchuyenden =" + this.idkhoa + @")
//--)
//        and kb.idbenhnhan in (select idbenhnhan from [dbo].[NVK_DSBNNoiTruTheoKhoa_2](kb.idchitietdangkykham," + this.idkhoa + @"))
//--and kb.idchitietdangkykham in (select idchitietdangkykham from benhnhannoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + this.idkhoa + @" and isdanhap=1)
//
//        " +sWhere+" order by ngaykham desc";
#endregion
        strSQL = @"
select top 20 row_number() over(order by tenbenhnhan) as stt
,case when --isnull(kb.isdaravien,0)=0
     isnull( (
		select isdaravien from khambenh where idkhambenh in
		(select top 1 idkhambenh from khambenh where idchitietdangkykham =f.idchitietdangkykham and  isdaravien=1 order by idkhambenh desc)
		and idkhambenh not in(select  idkhambenhnhap from benhnhannoitru where idkhoanoitru=" + this.idkhoa + @" and idchitietdangkykham=f.idchitietdangkykham)
		) ,0)=0
then N'Chi tiết' else N'Đã chỉ định' end as TinhTrang
,f.idbenhnhan,f.idchitietdangkykham,idkhambenh=f.idkhambenhgoc,bn.mabenhnhan,bn.tenbenhnhan,bn.diachi,gioitinh=dbo.GetGioiTinh(gioitinh),ngaysinh as namsinh 
,kb.ngaykham
,tenphongnoitru=
isnull((select top 1 ph.maso+'-'+ph.tenphong from benhnhannoitru nn left join kb_phong ph on ph.id=nn.idphongnoitru where idchitietdangkykham=f.idchitietdangkykham and idkhoanoitru=" + this.idkhoa + @" order by idnoitru desc)
                ,isnull((select top 1 ph.maso+'-'+ph.tenphong from kb_giuongphieuthanhtoan nn  left join kb_giuong gg on gg.giuongid=nn.idgiuongxet left join kb_phong ph on ph.id=gg.idphong where idchitietdangkykham=f.idchitietdangkykham order by ngayxetgiuong desc),''))
        
 from [dbo].[NVK_DSBNNoiTruTheoKhoa_1](" + this.idkhoa + @") f
inner join khambenh kb on kb.idkhambenh=f.idkhambenhgoc 
left join benhnhan bn on bn.idbenhnhan =kb.idbenhnhan
where 1=1 " +sWhere+@" order by kb.ngaykham desc
";
        dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

        if (dtCTPhieu != null)
        {
            dgr.DataSource = dtCTPhieu;
            if (dtCTPhieu.Rows.Count < dgr.PageSize)
                dgr.CurrentPageIndex = 0;
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
        hdIdKhamBenh.Value = "";
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
        return skq;
    }
    #endregion
    #region "Grid Event"
    //public void Edit(object s, DataGridCommandEventArgs e)//EditListPopup
    //{
        protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            string id = e.CommandArgument.ToString();
            //string id = "18554";
            hdIdKhamBenh.Value = dgr.DataKeys[e.Item.ItemIndex].ToString();
            chiTiet(id);
        }
        else if (e.CommandName == "ViewTTBN")
            ViewTTBN(source, e);
        else if (e.CommandName == "ViewMauTH")
        {
            string idchitietdangkykham = e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "window.open(\"../noitru/frm_rpt_BangKeVienPhiTheoKhoa.aspx?idchitietdangkykham=" + idchitietdangkykham + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
        }
    }
    public void ViewTTBN(object s, DataGridCommandEventArgs e)//EditListPopup
    {
            int idphieutt = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
            string idbn = e.CommandArgument.ToString();
            string idchitietdangkykham = "0";
            string sql = "SELECT * FROM Khambenh where idkhambenh=" + idphieutt;
            DataTable dt = DataAcess.Connect.GetTable(sql);
            string ngaykham = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                idbn = dt.Rows[0]["idbenhnhan"].ToString();
                ngaykham = dt.Rows[0]["Ngaykham"].ToString();
                idchitietdangkykham = dt.Rows[0]["idchitietdangkykham"].ToString();
            }
            Page page = HttpContext.Current.Handler as Page;
            //ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"../thuvienphi/frm_rpt_chiphikhambenh.aspx?idphieutt=" + idphieutt + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
            //ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"../khambenh/frm_Rpt_PhieuThanhToan.aspx?Idbenhnhan=" + idbn + "&DateNgayRV=" + ngaykham + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"../noitru/frm_Rpt_BieuMau02.aspx?idchitietdangkykham=" + idchitietdangkykham + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
    }
    public void DelBenhNhan(object s, DataGridCommandEventArgs e)
    {
         
    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn = (LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"));
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
            if (btn.Text == "Đã chỉ định")
                btn.Enabled = false;
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
    private void chiTiet(string id)
    {

        string sqlChiTiet = @"
select * from 
        (select  idbenhnhantoathuoc=null,idkhambenh
		                        ,Lan=N'Chỉ định CLS lần'+str(ROW_NUMBER() OVER (ORDER BY idkhambenh))
		                        ,NgayThang=isnull((select top 1 ngaykham from khambenhcanlamsan where maphieucls= kbcls.maphieucls order by idkhambenhcanlamsan desc),0)
                                , KhoaChiDinh=isnull((select tenphongkhambenh from khambenh kb left join phongkhambenh k on kb.idphongkhambenh=k.idphongkhambenh where kb.idkhambenh=kbcls.idkhambenh ),'')  
                         from khambenhcanlamsan kbcls where idbenhnhan=" + id + @"  group by idkhambenh,maphieucls

                          union all 

                         ( select idbenhnhantoathuoc=kb.idkhambenh,kb.idkhambenh
		                        ,Lan=N'Thuốc lần'+str(ROW_NUMBER() OVER (ORDER BY kb.idkhambenh))
		                        ,NgayThang=kb.ngaykham
                                ,KhoaChiDinh=isnull((select tenphongkhambenh from phongkhambenh k where k.idphongkhambenh=kb.idphongkhambenh ),'')  
                                from chitietbenhnhantoathuoc ct
	                        left join khambenh kb on kb.idkhambenh=ct.idkhambenh
                         where kb.idbenhnhan=" + id+@" group by kb.idkhambenh,kb.ngaykham,kb.idphongkhambenh) 
 )as abc order by KhoaChiDinh,Lan";
            DataTable dt = DataAcess.Connect.GetTable(sqlChiTiet);
            //if (dt != null && dt.Rows.Count > 0)
            //{
                dgrChiTietChild.DataSource = dt;
                dgrChiTietChild.DataBind();
                dgrChiTietChild.Visible = true;
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'block';", true);
                DataTable ttBN = KB_Process.benhnhan.dtSearchByidbenhnhan(id);
                if (ttBN.Rows.Count > 0)
                {
                    lbMaBN.Text = ttBN.Rows[0]["mabenhnhan"].ToString();
                    lbTenBenhNhan.Text = ttBN.Rows[0]["tenbenhnhan"].ToString();
                    lbDiaChi.Text = ttBN.Rows[0]["diachi"].ToString();
                }
            //}
            //else
            //{
            //    StaticData.MsgBox(this, "Bệnh nhân này chưa khám bệnh");
            //}
    }
    protected void dgrChiTietChild_ItemCommand(object s, DataGridCommandEventArgs e)//
    {
        // int iddangkykham = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
        int idkhambenh = StaticData.ParseInt(dgrChiTietChild.DataKeys[e.Item.ItemIndex]);// e.CommandArgument.ToString();
        //StaticData.MsgBox(this,idkhambenh.ToString()); return;
        if (e.CommandName == "EditPhieuKham")
        {
            ////if(Request.QueryString["idkhoa"].ToString()=="15")
            ////    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Sua", "OpenLinkKhamBenhCapCuu('" + this.dkmenu + "','" + idkhambenh + "');", true);
            ////else
            ////    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Sua", "OpenLinkKhamBenhKhoaSan('" + this.dkmenu + "','" + idkhambenh + "');", true);
            string sqlkb = @"select bn.mabenhnhan,kb.idbenhnhan,isnull(kb.idkhambenhgoc,0) as isKhamBenhGoc,iscothuoc=isnull((select top 1 idkhambenh from chitietbenhnhantoathuoc where idkhambenh=kb.idkhambenh),0)
            from khambenh kb left join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan where idkhambenh=" + idkhambenh;
            DataTable dtKB = DataAcess.Connect.GetTable(sqlkb);
            if(dtKB != null && dtKB.Rows.Count>0)
            {
                string link = "../noitru/ChonCLSBenhVien.aspx?load=1&MaBenhNhan="+dtKB.Rows[0]["mabenhnhan"].ToString()+"&dkmenu=Khong&IdKhoa=" + Request.QueryString["idkhoa"].ToString() + "#idkhoachinh=" + idkhambenh + "&idbenhnhan="+dtKB.Rows[0]["idbenhnhan"].ToString()+"&IsTheoDoiCC=0";            
            if (dtKB.Rows[0]["isKhamBenhGoc"].ToString() == "0")
                link = "../KhoaSan/frm_Edit_DSBNdakham.aspx?IdKhamBenh=" + idkhambenh + "&dkmenu=Khong";
            else if (dtKB.Rows[0]["iscothuoc"].ToString() != "0")
                link = "../noitru/ChonThuocBenhVien.aspx?load=1&MaBenhNhan=" + dtKB.Rows[0]["mabenhnhan"].ToString() + "&dkmenu=Khong&IdKhoa=" + Request.QueryString["idkhoa"].ToString() + "#idkhoachinh=" + idkhambenh + "&idbenhnhan=" + dtKB.Rows[0]["idbenhnhan"].ToString() + "&IsTheoDoiCC=0";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Sua", "OpenLinkChiDinh('" + link + "');", true);
            }
            return;
        }
        string idtoathuoc = e.CommandArgument.ToString();
        if (idtoathuoc != "")
        {
            string sqlThuoc = @"select ct.idkhambenh,tenthuoc,ct.soluongke-ct.soluongtra as soluongke
                     from chitietbenhnhantoathuoc ct left join thuoc t on t.idthuoc=ct.idthuoc
                      where ct.idkhambenh=" + idkhambenh;
            DataTable dt = DataAcess.Connect.GetTable(sqlThuoc);
            if (dt != null && dt.Rows.Count > 0)
            {
                dgrToaThuoc.DataSource = dt;
                dgrToaThuoc.DataBind();
                dgrToaThuoc.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divToaThuoc.style.display = 'block';", true);
            }
        }
        else
        {
            string sqlChiTiet = "select kbcls.idkhambenh,dv.tendichvu,soluong,maPhieuCLS from khambenhcanlamsan kbcls "
                                + " left join banggiadichvu dv on dv.idbanggiadichvu=kbcls.idcanlamsan"
                                + " where kbcls.idkhambenh=" + idkhambenh;
            DataTable dt = DataAcess.Connect.GetTable(sqlChiTiet);
            if (dt != null && dt.Rows.Count > 0)
            {
                dgrChiTiet.DataSource = dt;
                dgrChiTiet.DataBind();
                dgrChiTiet.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "light1.style.display = 'block';", true);
            }
            else
            {
                StaticData.MsgBox(this, "Bệnh nhân này không khám bệnh");
            }
        }
        
    }
    protected void btnLuuRaVien_click(object sender, EventArgs e)
    {
        string sqlKBMoi = "select top 1 * from khambenh where idkhambenhgoc="+hdIdKhamBenh.Value +" order by idkhambenh desc ";
        DataTable dtKBMoi = DataAcess.Connect.GetTable(sqlKBMoi);
        if (dtKBMoi.Rows.Count == 0)
        {
            sqlKBMoi = "select top 1 * from khambenh where idkhambenh=" + hdIdKhamBenh.Value + " order by idkhambenh desc ";
            dtKBMoi = DataAcess.Connect.GetTable(sqlKBMoi);
        }
        string update = "update khambenh set isdaravien='1' where idkhambenh='" + dtKBMoi.Rows[0]["idkhambenh"].ToString() + "'";
        bool rs= DataAcess.Connect.ExecSQL(update);
        if (rs)
        {
            StaticData.MsgBox(this, "Đã chỉ định !");
            ImageButton1_Click(null, null);
        }
        else
            StaticData.MsgBox(this, "Lưu không thành công");
    }
}

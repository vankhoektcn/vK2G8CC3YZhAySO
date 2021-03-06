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
public partial class TienGiuongXuatKhoa : Genaratepage
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
            ////this.txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ////this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            StaticData.SetFocus(this, "txtMaBenhNhan");
            //bind_ddlthangnam();
            LoadLoaiKham();
            BindListBenhNhan("");
            loadPK();
            //noidungkcb();
            //loadPhongKham();
            StaticData.SetFocus(this,"txtMaBenhNhan");
            // chiTiet("18554");
        }
               
         dkmenu = Request.QueryString["dkmenu"].ToString();
         if (dkmenu == "khoasan")
         {
             PlaceHolder1.Controls.Add(LoadControl("~/KhoaSan/uscmenu.ascx"));
         }
         else if (dkmenu == "phukhoa")
         {
             PlaceHolder1.Controls.Add(LoadControl("~/PhuKhoa/uscmenu.ascx"));
         }
         if (dkmenu == "tresosinh")
         {
             PlaceHolder1.Controls.Add(LoadControl("~/TreSoSinh/menu_HeThong.ascx"));
         }
         if (dkmenu == "capcuu")
         {
             PlaceHolder1.Controls.Add(LoadControl("~/CapCuu/uscmenu.ascx"));
         }
         if (dkmenu == "khoanoi")
         {
             PlaceHolder1.Controls.Add(LoadControl("~/KhoaNoi/uscmenu.ascx"));
         }
         if (dkmenu == "khoangoai")
         {
             PlaceHolder1.Controls.Add(LoadControl("~/KhoaNgoai/uscmenu.ascx"));
         }
    }

    
    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }


    #region "U Function"
    private void LoadLoaiKham()
    {
        string sqlLK = "select * from KB_LoaiBN";
        DataTable dtLK = DataAcess.Connect.GetTable(sqlLK);
        if (dtLK != null && dtLK.Rows.Count > 0)
            StaticData.FillCombo(ddlLoaiKham, dtLK, "id", "tenloai", "__Chọn loại khám__");
    }
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
        string strSQL = @"select row_number() over(order by ngaykham desc,tenbenhnhan) as stt
,case when --isnull(kb.isdaravien,0)=0
     isnull( (
		select isdaravien from khambenh where idkhambenh in
		(select top 1 idkhambenh from khambenh where idchitietdangkykham =55610 and  isdaravien=1 order by idkhambenh desc)
		and idkhambenh not in(select  idkhambenhnhap from benhnhannoitru where idkhoanoitru="+this.idkhoa+ @" and idchitietdangkykham=55610)
		) ,0)=0
then N'Chi tiết' else N'Đã chỉ định' end as TinhTrang
         ,kb.idbenhnhan,kb.idkhambenh,mabenhnhan,bn.sobhyt,tenbenhnhan,diachi
        ,dienthoai,gioitinh=dbo.GetGioiTinh(gioitinh),ngaysinh as namsinh 
        ,iddichvugoc=bg.idbanggiadichvu
        ,tendichvugoc=bg.tendichvu
        ,idphonggoc=phong.id
        ,tenphonggoc=phong.maso +'-'+isnull(phong.tenphong,'')
        ,kb.idphongchuyenden
        ,iddichvunoitru=bg1.idbanggiadichvu
        ,tendichvunoitru=bg1.tendichvu
        ,idphongnoitru=phong1.id
,tenphongnoitru=isnull((select top 1 ph.maso+'-'+isnull(ph.tenphong,'') from benhnhannoitru nn left join kb_phong ph on ph.id=nn.idphongnoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + this.idkhoa + @" order by idnoitru desc)
                ,isnull((select top 1 ph.maso+'-'+isnull(ph.tenphong,'') from kb_giuongphieuthanhtoan nn  left join kb_giuong gg on gg.giuongid=nn.idgiuongxet left join kb_phong ph on ph.id=gg.idphong where idchitietdangkykham=kb.idchitietdangkykham order by ngayxetgiuong desc),''))
        --,tenphongnoitru=phong1.maso +'-'+phong1.tenphong
        ,tenbacsi=''
        ,ngaykham
--,TienGiuong=isnull((select tongtiengiuong from TienGiuongXuatKhoa where idchitietdangkykham=kb.idchitietdangkykham and idkhoa=" + this.idkhoa+ @"),[dbo]. NVK_TinhTienGiuongTheoGio(kb.idchitietdangkykham))
,TienGiuong=isnull((select sum(thanhtien) from dbo.nvk_tableketquagiuong(kb.idchitietdangkykham)),0)
        from khambenh kb left join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan
        left join chitietdangkykham ctdkk on kb.idchitietdangkykham= ctdkk.idchitietdangkykham 
        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
        left join kb_phong phong on ctdkk.phongid=phong.id

        left join banggiadichvu bg1 on kb.idDVphongchuyenden=bg1.idbanggiadichvu
        left join kb_phong phong1 on kb.idphongchuyenden=phong1.id
        where 1=1 and (isnull(kb.hoantat,0)=0 or kb.idphongkhambenh=1 ) and isnull(idkhambenhgoc,0)=0
--and  (kb.idphongkhambenh =" + this.idkhoa + @"
-- or kb.idchitietdangkykham in(select idchitietdangkykham from khambenh where idchitietdangkykham=kb.idchitietdangkykham and huongdieutri in(1,7,8) and phongkhamchuyenden =" + this.idkhoa + @")
--)
and kb.idchitietdangkykham in (select idchitietdangkykham from benhnhannoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru="+this.idkhoa+@" and isdanhap=1)

        " + sWhere+"";
//        if (txtMaBenhNhan.Text == "" && txtTenBenhNhan.Text == "")
//        {
//            if (txtTuNgay.Text != "")
//            {
//                strSQL += @"and exists 
//                (
//	                select idchitietdangkykham from khambenh where idchitietdangkykham =kb.idchitietdangkykham and ngaykham>='" + StaticData.CheckDate(txtTuNgay.Text) + @" 00:00:00:000' ";
//                if (txtDenNgay.Text != "")
//                {
//                    strSQL += @" and ngaykham<='" + StaticData.CheckDate(txtDenNgay.Text) + @" 23:58:59:999'";
//                }
//            strSQL +=") ";
//            }
//         }
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
        if (ddlLoaiKham.SelectedValue != "0")
        {
            skq += " AND bn.loai = " + ddlLoaiKham.SelectedValue;
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
    }
    public void ViewTTBN(object s, DataGridCommandEventArgs e)//EditListPopup
    {
            int idphieutt = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
            string idbn = e.CommandArgument.ToString();
            string sql = "SELECT * FROM Khambenh where idkhambenh=" + idphieutt;
            DataTable dt = DataAcess.Connect.GetTable(sql);
            string ngaykham = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                idbn = dt.Rows[0]["idbenhnhan"].ToString();
                ngaykham = dt.Rows[0]["Ngaykham"].ToString();
            }
            Page page = HttpContext.Current.Handler as Page;
            //ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"../thuvienphi/frm_rpt_chiphikhambenh.aspx?idphieutt=" + idphieutt + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"../khambenh/frm_Rpt_PhieuThanhToan.aspx?Idbenhnhan=" + idbn + "&DateNgayRV=" + ngaykham + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
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
    public void dgrChiTietChild_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
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
    public void dgrChiTietGiuong_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFCC99\'");//#3090c7
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
        //stt = e.NewPageIndex * dgr.PageSize + 1;
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
        string sqlKBMoi = "select top 1 * from khambenh where idkhambenh='" + hdIdKhamBenh.Value + "'";
        DataTable dtKB = DataAcess.Connect.GetTable(sqlKBMoi);
        string IdCTDKK = dtKB.Rows[0]["idchitietdangkykham"].ToString();
        hdidchitietdangkykham.Value = IdCTDKK;
        string sqlChiTietGiuong = @"select * from (
select *,sogio=convert(float,DATEDIFF(hh,tungay,denngay))
                ,thanhtien=round(convert(float,DATEDIFF(hh,tungay,denngay))*giagiuong/24,2) from 
                (
                select nt.idnoitru,giuong=g.giuongcode+' - '+isnull(p.tenphong,''),nt.Giagiuong,tungay=nt.ngayvaovien
                ,denngay=isnull((select top 1 ngayvaovien from benhnhannoitru where idchitietdangkykham=nt.idchitietdangkykham and ngayvaovien>nt.ngayvaovien order by ngayvaovien),getdate())
                ,tenkhoa=k.tenphongkhambenh
                 from benhnhannoitru nt left join kb_phong p on p.id=idphongnoitru
                left join kb_giuong g on g.giuongid=idgiuong left join phongkhambenh k on k.idphongkhambenh=nt.idkhoanoitru
                where nt.idchitietdangkykham="+IdCTDKK+ @" 
                ) as abc --order by tungay

union all
select *,sogio=convert(float,DATEDIFF(hh,tungay,denngay))
                ,thanhtien=round(convert(float,DATEDIFF(hh,tungay,denngay))*thanhtien/24,2) from 
                (
                select idnoitru=nt.idgiuong,giuong=g.giuongcode+' - '+p.tenphong,nt.thanhtien,tungay=nt.ngayxetgiuong
                ,denngay=isnull((select top 1 ngayvaovien from benhnhannoitru where idchitietdangkykham=nt.idchitietdangkykham and ngayvaovien>nt.ngayxetgiuong order by idnoitru),getdate())
                ,tenkhoa=N'Cấp cứu'
                 from kb_giuongphieuthanhtoan nt
left join kb_giuong g on nt.idgiuongxet=g.giuongid
 left join kb_phong p on p.id=g.idphong

                where nt.idchitietdangkykham=" + IdCTDKK + @" 
 ) as abc
) as cba order by tungay
";
        string sqlChiTiet = @"select distinct *,ngay1=convert(varchar(10),ngay,103)+' '+convert(varchar(5),ngay,108)
,DenNgay1=convert(varchar(10),denngay,103)+' '+convert(varchar(5),denngay,108) from [dbo].[NVK_TableKetQuaGiuong](" + IdCTDKK + ") order by ngay";
            DataTable dt = DataAcess.Connect.GetTable(sqlChiTiet);
            if (dt != null && dt.Rows.Count > 0)
            {
                //dgrChiTietChild.DataSource = dt;
                //dgrChiTietChild.DataBind();
                //dgrChiTietChild.Visible = true;
                DataTable dtGiuong = DataAcess.Connect.GetTable(sqlChiTietGiuong);
                if (dtGiuong != null)
                {
                    dgrChiTietGiuong.DataSource = dtGiuong;
                    dgrChiTietGiuong.DataBind();
                    dgrChiTietGiuong.Visible = true;
                }
                tabletienGiuong(dt);
                #region Load danh sách ngày nhiều giường
                //divNgayNhieuGiuong.InnerHtml = @" ";
                string ListGiuongHtml="";
                string sqlNgayG = @"select distinct convert(varchar(10),ngay,103) as ngay1,ngay from
                            (
                            select  ngay  from NVK_ListNgayTinhGiuong(" +IdCTDKK+@") 
                            ) as abc where isnull((select count(*) from dbo.NVK_ListGiuongBN_Ngay(" + IdCTDKK + @",ngay)),0)>1 order by ngay asc";
//a where sogiuong>2 
//                or(sogiuong=2 and convert(varchar(10),a.ngay,126)<>
//                 isnull((
//                        select top 1 convert(varchar(10),ngayvaovien,126) from (
//                        select top 1 ngayvaovien from benhnhannoitru where idchitietdangkykham="+IdCTDKK+@" order by ngayvaovien
//                        union all 
//                        select top 1 ngayvaovien=ngayxetgiuong from kb_giuongphieuthanhtoan where idchitietdangkykham="+IdCTDKK+@" order by ngayxetgiuong
//                        ) as abc order by ngayvaovien asc
//                    ),0))";
                DataTable dtNgayG = DataAcess.Connect.GetTable(sqlNgayG);
                if (dtNgayG.Rows.Count > 0)
                {
                    for (int i = 0; i < dtNgayG.Rows.Count; i++)
                    {
                        ListGiuongHtml += @"<input type='button' id='ngay_"+(i+1)+"' runat='server' onclick='Ngay_click(this)' value='"+dtNgayG.Rows[i]["ngay1"].ToString()+@"' style='background-color:Blue' />";
                    }
                }
                divNgayNhieuGiuong.InnerHtml = ListGiuongHtml;
                #endregion 
                //DataTable dtTienGiuong = DataAcess.Connect.GetTable(@"select * from tiengiuongxuatkhoa where idkhoa='" + Request.QueryString["idkhoa"].ToString() + @"' and  idchitietdangkykham='" + IdCTDKK + "'");
                float TongTien = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                    TongTien += StaticData.ParseFloat(dt.Rows[i]["thanhtien"]);
                //lbTongTien.Text = StaticData.FormatNumberOption(TongTien, ",", ".", false).ToString();
                //txtTongtien.Value = StaticData.FormatNumberOption(TongTien, ",", ".", false).ToString();
                //if (dtTienGiuong.Rows.Count > 0)
                //{
                //    txtTongtien.Value = StaticData.FormatNumberOption(dtTienGiuong.Rows[0]["tongTienGiuong"], ",", ".", false).ToString();
                //    //lbTongTien.Text = txtTongtien.Value;
                //}
                //else
                //{
                    //txtTongtien.Value = StaticData.FormatNumberOption(TongTien, ",", ".", false).ToString();
                //}
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'block';", true);
                DataTable ttBN = KB_Process.benhnhan.dtSearchByidbenhnhan(id);
                if (ttBN.Rows.Count > 0)
                {
                    lbMaBN.Text = ttBN.Rows[0]["mabenhnhan"].ToString();
                    lbTenBenhNhan.Text = ttBN.Rows[0]["tenbenhnhan"].ToString();
                    lbDiaChi.Text = ttBN.Rows[0]["diachi"].ToString();
                    hdidbenhnhan.Value = ttBN.Rows[0]["idbenhnhan"].ToString();
                    hdloaiBN.Value = ttBN.Rows[0]["loai"].ToString();

                }
            }
            else
            {
                hdidchitietdangkykham.Value = "";
                StaticData.MsgBox(this, "Bệnh nhân này chưa nhập khoa ");
            }
    }
    protected void dgrChiTietGiuong_ItemCommand(object s, DataGridCommandEventArgs e)//
    {

    }
    protected void dgrChiTietChild_ItemCommand(object s, DataGridCommandEventArgs e)//
    {
        #region Bỏ Đi
        //        // int iddangkykham = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
//        int idkhambenh = StaticData.ParseInt(dgrChiTietChild.DataKeys[e.Item.ItemIndex]);// e.CommandArgument.ToString();
//        //StaticData.MsgBox(this,idkhambenh.ToString()); return;
//        if (e.CommandName == "EditPhieuKham")
//        {
//            ////if(Request.QueryString["idkhoa"].ToString()=="15")
//            ////    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Sua", "OpenLinkKhamBenhCapCuu('" + this.dkmenu + "','" + idkhambenh + "');", true);
//            ////else
//            ////    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Sua", "OpenLinkKhamBenhKhoaSan('" + this.dkmenu + "','" + idkhambenh + "');", true);
//            string sqlkb = @"select bn.mabenhnhan,kb.idbenhnhan,isnull(kb.idkhambenhgoc,0) as isKhamBenhGoc,iscothuoc=isnull((select top 1 idkhambenh from chitietbenhnhantoathuoc where idkhambenh=kb.idkhambenh),0)
//            from khambenh kb left join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan where idkhambenh=" + idkhambenh;
//            DataTable dtKB = DataAcess.Connect.GetTable(sqlkb);
//            if(dtKB != null && dtKB.Rows.Count>0)
//            {
//                string link = "../noitru/ChonCLSBenhVien.aspx?load=1&MaBenhNhan="+dtKB.Rows[0]["mabenhnhan"].ToString()+"&dkmenu=Khong&IdKhoa=" + Request.QueryString["idkhoa"].ToString() + "#idkhoachinh=" + idkhambenh + "&idbenhnhan="+dtKB.Rows[0]["idbenhnhan"].ToString()+"&IsTheoDoiCC=0";            
//            if (dtKB.Rows[0]["isKhamBenhGoc"].ToString() == "0")
//                link = "../KhoaSan/frm_Edit_DSBNdakham.aspx?IdKhamBenh=" + idkhambenh + "&dkmenu=Khong";
//            else if (dtKB.Rows[0]["iscothuoc"].ToString() != "0")
//                link = "../noitru/ChonThuocBenhVien.aspx?load=1&MaBenhNhan=" + dtKB.Rows[0]["mabenhnhan"].ToString() + "&dkmenu=Khong&IdKhoa=" + Request.QueryString["idkhoa"].ToString() + "#idkhoachinh=" + idkhambenh + "&idbenhnhan=" + dtKB.Rows[0]["idbenhnhan"].ToString() + "&IsTheoDoiCC=0";
//            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Sua", "OpenLinkChiDinh('" + link + "');", true);
//            }
//            return;
//        }
//        string idtoathuoc = e.CommandArgument.ToString();
//        if (idtoathuoc != "")
//        {
//            string sqlThuoc = @"select ct.idkhambenh,tenthuoc,ct.soluongke
//                     from chitietbenhnhantoathuoc ct left join thuoc t on t.idthuoc=ct.idthuoc
//                      where ct.idkhambenh=" + idkhambenh;
//            DataTable dt = DataAcess.Connect.GetTable(sqlThuoc);
//            if (dt != null && dt.Rows.Count > 0)
//            {
//                dgrToaThuoc.DataSource = dt;
//                dgrToaThuoc.DataBind();
//                dgrToaThuoc.Visible = true;
//                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divToaThuoc.style.display = 'block';", true);
//            }
//        }
//        else
//        {
//            string sqlChiTiet = "select kbcls.idkhambenh,dv.tendichvu,soluong,maPhieuCLS from khambenhcanlamsan kbcls "
//                                + " left join banggiadichvu dv on dv.idbanggiadichvu=kbcls.idcanlamsan"
//                                + " where kbcls.idkhambenh=" + idkhambenh;
//            DataTable dt = DataAcess.Connect.GetTable(sqlChiTiet);
//            if (dt != null && dt.Rows.Count > 0)
//            {
//                dgrChiTiet.DataSource = dt;
//                dgrChiTiet.DataBind();
//                dgrChiTiet.Visible = true;
//                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "light1.style.display = 'block';", true);
//            }
//            else
//            {
//                StaticData.MsgBox(this, "Bệnh nhân này không khám bệnh");
//            }
//        }
#endregion
    }
    protected void btnLuuRaVien_click(object sender, EventArgs e)
    {
#region tạm bỏ  
//        string TongTien = txtTongtien.Value.Replace(",", "");
//        if (TongTien.Equals(""))
//        {
//            StaticData.MsgBox(this, "Chưa nhập tiền giường !"); return;
//        }
//        string sqlKBMoi = "select top 1 * from khambenh where idkhambenh="+hdIdKhamBenh.Value +"";
//        DataTable dtKBMoi = DataAcess.Connect.GetTable(sqlKBMoi);
//        DataTable dtTienGiuong = DataAcess.Connect.GetTable(@"select * from tiengiuongxuatkhoa where idkhoa='" + Request.QueryString["idkhoa"].ToString() + @"' and  idchitietdangkykham='" + dtKBMoi.Rows[0]["idchitietdangkykham"].ToString() + "'");
//        string sqlInsert ="";
//        if (dtTienGiuong.Rows.Count > 0)
//            sqlInsert = @"update TienGiuongXuatKhoa set ngayTinh=getdate(),tongTienGiuong='" + TongTien+ "',idNguoiDung='" + SysParameter.UserLogin.UserID(this) + "' where id='"+dtTienGiuong.Rows[0]["id"].ToString()+"'";
//        else
//            sqlInsert = @"insert into TienGiuongXuatKhoa (ngayTinh,idchitietdangkykham,idkhoa,tongTienGiuong,idNguoiDung)
//            values (getdate(),'" + dtKBMoi.Rows[0]["idchitietdangkykham"].ToString() + "','" + Request.QueryString["idkhoa"].ToString() + "','" + TongTien+ "','" + SysParameter.UserLogin.UserID(this) + "')";
//        bool rs = DataAcess.Connect.ExecSQL(sqlInsert);
//        if (rs)
//        {
//            StaticData.MsgBox(this, "Lưu thành công");
//            ImageButton1_Click(null, null);
//        }
//        else
//            StaticData.MsgBox(this, "Lưu không thành công");
#endregion 
    }

    #region
    protected void Ngay_click(object sender, EventArgs e)
    {
        StaticData.MsgBox(this,"không phải em ! Em xin !");
    }
    
    private void tabletienGiuong(DataTable dt)
    {
        string html = "";
        html += "<table class='jtable' id=\"gridTableGiuong\">";
        html += "<tr>";
        html += "<th>STT</th>";
        //html += "<th></th>";
        html += "<th>Khoa</th>";
        html += "<th>Từ ngày</th>";
        html += "<th>Đến ngày</th>";
        html += "<th>Giường</th>";
        html += "<th>Đơn giá/ngày</th>";
        html += "<th>Số ngày</th>";
        html += "<th>Thành tiền</th>";
        html += "</tr>";
        if (dt.Rows.Count != 0)
        {
            double tongTienTable = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" +(i+1) + "</td>";
                //html += "<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input mkv='true' id='idkhoa' type='hidden' value='" + dt.Rows[i]["idkhoa"] + "' /><input mkv='true' id='mkv_idkhoa' type='text' style='width:80px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["khoa"] + "' class='down_select'/></td>";
                html += "<td>" + dt.Rows[i]["Ngay1"] + "</td>";
                html += "<td>" + dt.Rows[i]["denngay1"] + "</td>";
                html += "<td><input mkv='true' id='idGiuong' type='hidden' value='" + dt.Rows[i]["idgiuong"] + "' /><input mkv='true' id='mkv_idGiuong' type='text' onfocus='chuyenphim(this);idGiuongsearch(this)' value='" + dt.Rows[i]["tengiuong"] + "' class='down_select'/></td>";

                html += "<td><input mkv='true' id='dongia' type='text' style='width:80px;text-align:right' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);thanhtiencls(this);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["tiengiuongnamnhieunhat"], ",", ".", false) + "' /></td>";
                html += "<td><input mkv='true' id='songay' type='text' style='width:50px;text-align:center' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);thanhtiencls(this);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["songay"], ",", ".", false) + "' /></td>";
                html += @"<td>
                    <input mkv='true' id='thanhtien' disabled='disabled' type='text' style='width:80px;text-align:right' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["thanhtien"], ",", ".", false) + @"' />
                    <input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[i]["idnoitrunamnhieunhat"] + @"'/>
                    <input mkv='true' id='idtien_"+(i+3)+"' type='hidden' value='" + dt.Rows[i]["thanhtien"] + @"'/>
                    </td>";
                html += "</tr>";
                tongTienTable += StaticData.ParseFloat(dt.Rows[i]["thanhtien"]);
            }
            html += "<tr>";
            html += "<td colspan='8'>";
            html += @"<div style='text-align:right;width:95%'>
        Tổng tiền : <input type='text' style='text-align:right;color:Red' runat='server' id='txtTongtien' disabled='disabled' value='" + StaticData.FormatNumberOption(tongTienTable, ",", ".", false).ToString() + "'/>";
            html += "<td>";
            html += "</tr>";
        }
//        html += "<tr>";
//        html += "<td>" + (dt.Rows.Count + 1) + "</td>";
//        html += @"<td><a onclick='xoaontablecls(this)'>Xóa</a></td>";
//        html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='' class='down_select'/></td>";
//        html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:70px'/></td>";
//        html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);' /></td>";
//        html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='thanhtiencls(this);'  style='width:70px'/></td>";

//        html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";

//        html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
//        html += @"<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/>
//            <input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' value='0' onblur='thanhtiencls(this);'  style='width:70px'/>
//        </td>";

        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        tableAjax_EditTienGiuong.InnerHtml= html;
    }
    #endregion
}

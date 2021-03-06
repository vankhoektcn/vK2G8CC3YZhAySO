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
public partial class CapCuu_ChiDinhTienGiuongCC : Genaratepage
{
    string strSearch;
    string dkmenu = null;
    private string login_IdBacsi = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "kheoe", "new Epoch('epoch_popup','popup',document.getElementById('txtNgayGiuong'));", true);
        if (!IsPostBack)
        {

            SetValueEmpty();
            //this.txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            StaticData.SetFocus(this, "txtMaBenhNhan");
            //bind_ddlthangnam();
            LoadLoaiKham();
            BindListBenhNhan("");
            if(Request.QueryString["idkhoa"].Equals("15"))
                spHeader.InnerHtml = "XÉT GIƯỜNG CẤP CỨU";
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
    private void LoadLoaiKham()
    {
        string sqlLK = "select * from KB_LoaiBN";
        DataTable dtLK = DataAcess.Connect.GetTable(sqlLK);
        if (dtLK != null && dtLK.Rows.Count > 0)
            StaticData.FillCombo(ddlLoaiKham, dtLK, "id", "tenloai", "__Chọn loại khám__");
    }
    private void BindListBenhNhan(string sWhere)
    {
        string ngaybt = "";
        string ngaykt = "";
        DataTable dtCTPhieu = new DataTable();
        string strSQL = "";
        if (Request.QueryString["idkhoa"].ToString() == "15")
        {
            #region bệnh nhân khám trong khoa cấp cứu
            strSQL = @"select top 20 row_number() over(order by ngaykham desc) as stt
		,kb.idchitietdangkykham,ChucNang=N'Xét giường'
         ,kb.idbenhnhan,mabenhnhan,tenbenhnhan,bn.sobhyt,bn.diachi
        ,bn.dienthoai,dbo.GetGioiTinh(bn.gioitinh) as gioitinh,bn.ngaysinh as namsinh 
        ,iddichvugoc=bg.idbanggiadichvu
        ,tendichvugoc=bg.tendichvu
        ,idphonggoc=phong.id
        ,tenphonggoc=phong.maso +'-'+phong.tenphong
        ,kb.idphongchuyenden
        ,iddichvunoitru=bg1.idbanggiadichvu
        ,tendichvunoitru=bg1.tendichvu
        ,idphongnoitru=phong1.id
        ,tenphongnoitru=phong1.maso +'-'+phong1.tenphong
        ,tenbacsi=bs.tenbacsi
        ,ngaykham
,tenphongnoitru=isnull((select top 1 ph.maso+'-'+ph.tenphong from benhnhannoitru nn left join kb_phong ph on ph.id=nn.idphongnoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + Request.QueryString["idkhoa"].ToString() + @" order by idnoitru desc)
                ,isnull((select top 1 ph.maso+'-'+ph.tenphong from kb_giuongphieuthanhtoan nn  left join kb_giuong gg on gg.giuongid=nn.idgiuongxet left join kb_phong ph on ph.id=gg.idphong where idchitietdangkykham=kb.idchitietdangkykham order by ngayxetgiuong desc),''))
,GiaGiuong=isnull((select top 1 giagiuong from benhnhannoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + Request.QueryString["idkhoa"].ToString() + @" order by idnoitru desc)
                ,(select sum(thanhtien) from kb_giuongphieuthanhtoan where idchitietdangkykham=kb.idchitietdangkykham)
                )   
,tiengiuong =isnull(
(select sum(thanhtien) from kb_giuongphieuthanhtoan where idchitietdangkykham=kb.idchitietdangkykham )
,0)+ isnull((select tongtiengiuong from TienGiuongXuatKhoa where idchitietdangkykham=kb.idchitietdangkykham and idkhoa=" + Request.QueryString["idkhoa"].ToString() + @"),[dbo]. NVK_TinhTienGiuongTheoGio(kb.idchitietdangkykham))
        from khambenh kb left join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan
        left join chitietdangkykham ctdkk on kb.idchitietdangkykham= ctdkk.idchitietdangkykham 
        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
        left join kb_phong phong on ctdkk.phongid=phong.id

        left join banggiadichvu bg1 on kb.idDVphongchuyenden=bg1.idbanggiadichvu
        left join kb_phong phong1 on kb.idphongchuyenden=phong1.id
	 left join bacsi bs on bs.idbacsi=kb.idbacsi
        where 1=1 and isnull(hoantat,0)=0 and isnull(kb.idkhambenhgoc,0)=0
" + sWhere + @"
and(( ( kb.idchitietdangkykham  in
( 0--select idchitietdangkykham from benhnhannoitru where idchitietdangkykham=kb.idchitietdangkykham  and idkhoanoitru=" + Request.QueryString["idkhoa"].ToString() + @" and IsDaNhap=1
)
    or kb.idphongkhambenh=15
)
";
            #endregion
        }
        else
        {
            string dk = "ChucNang=N'Chuyển giường'";
            if (Request.QueryString["idkhoa"].Equals("22"))
                dk = @"case when isnull((select top 1 idgiuong from benhnhannoitru where isnull(idgiuong,0)<>0 and  idchitietdangkykham =kb.idchitietdangkykham and idkhoanoitru=22),0)=0 then N'Xét giường'
                else N'Chuyển giường' end as ChucNang";

            strSQL = @"select top 20 row_number() over(order by ngaykham desc) as stt
		,kb.idchitietdangkykham,
           "+dk+@"
         ,kb.idbenhnhan,mabenhnhan,tenbenhnhan,bn.sobhyt,bn.diachi
        ,bn.dienthoai,dbo.GetGioiTinh(bn.gioitinh) as gioitinh,bn.ngaysinh as namsinh 
,tenphongnoitru=isnull((select top 1 ph.maso+'-'+ph.tenphong from benhnhannoitru nn left join kb_phong ph on ph.id=nn.idphongnoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + Request.QueryString["idkhoa"].ToString() + @" order by idnoitru desc)
                ,isnull((select top 1 ph.maso+'-'+ph.tenphong from kb_giuongphieuthanhtoan nn  left join kb_giuong gg on gg.giuongid=nn.idgiuongxet left join kb_phong ph on ph.id=gg.idphong where idchitietdangkykham=kb.idchitietdangkykham order by ngayxetgiuong desc),''))
        ,GiaGiuong=isnull((select top 1 giagiuong from benhnhannoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + Request.QueryString["idkhoa"].ToString() + @" order by idnoitru desc)
                ,(select sum(thanhtien) from kb_giuongphieuthanhtoan where idchitietdangkykham=kb.idchitietdangkykham)
                )        
            ,tiengiuong =isnull(
(select sum(thanhtien) from kb_giuongphieuthanhtoan where idchitietdangkykham=kb.idchitietdangkykham )
,0)+ isnull((select tongtiengiuong from TienGiuongXuatKhoa where idchitietdangkykham=kb.idchitietdangkykham and idkhoa=" + Request.QueryString["idkhoa"].ToString() + @"),[dbo]. NVK_TinhTienGiuongTheoGio(kb.idchitietdangkykham))
        from khambenh kb left join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan
        where 1=1 and isnull(hoantat,0)=0 and isnull(kb.idkhambenhgoc,0)=0 --and idphongkhambenh=15
        "+sWhere+@"
		--and ( ( kb.idkhambenh in(select idkhambenhgoc from dbo.[NVK_DSBNNoiTruTheoKhoa_1](" + Request.QueryString["idkhoa"].ToString() + @") where idkhambenhgoc=kb.idkhambenh )
    and ((kb.idchitietdangkykham in (select idchitietdangkykham from benhnhannoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + Request.QueryString["idkhoa"].ToString() + @" and isdanhap=1)";

        }
        strSQL += @")) order by ngaykham desc";

        dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

        if (dtCTPhieu != null)
        {
            dgr.DataSource = dtCTPhieu;
            if(dtCTPhieu.Rows.Count<dgr.PageSize)
            dgr.CurrentPageIndex = 0;
            dgr.DataBind();
        }
    }

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";

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
        if (ddlGioiTinh.SelectedValue != "-1")
        {
            skq += " AND bn.gioitinh = " + ddlGioiTinh.SelectedValue;
        }
        if (ddlLoaiKham.SelectedValue != "0")
        {
            skq += " AND bn.loai = " + ddlLoaiKham.SelectedValue;
        }
        #region MyRegion
        //if (txtDienThoai.Text != "")
        //{
        //    skq += " AND bn.dienthoai LIKE '%" + txtDienThoai.Text.Trim() + "%' ";
        //}
        //if (txtDiaChi.Text != "")
        //{
        //    skq += " AND bn.diachi LIKE N'%" + txtDiaChi.Text.Trim() + "%' ";
        //} 
        //if (ddlNoidung.SelectedValue != "0")
        //{
        //    skq += " and bg1.idbanggiadichvu="+ddlNoidung.SelectedValue;
        //}
        //if (ddlPhong.SelectedValue != "0")
        //{
        //    skq += " and phong1.id="+ddlPhong.SelectedValue;
        //}
        #endregion
        return skq;
    }
    #endregion
    #region "Grid Event"
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        DataTable dtBN = DataAcess.Connect.GetTable(@"select case when isnull(gioitinh,0)=0 then N'Nam' else N'Nữ' end as Gioi,*,NgayVaoVien = convert(varchar,ngaytiepnhan,103)+' '+convert(varchar,ngaytiepnhan,108)
from benhnhan where idbenhnhan=" + e.CommandArgument.ToString());
        if (dtBN != null && dtBN.Rows.Count > 0)
        {
            txtTenBNNhap.Text = dtBN.Rows[0]["tenbenhnhan"].ToString();
            txtMaBNNhap.Text = dtBN.Rows[0]["mabenhnhan"].ToString();
            txtGioiTinhNhap.Text = dtBN.Rows[0]["Gioi"].ToString();
            txtNgayVaoVien.Text = dtBN.Rows[0]["NgayVaoVien"].ToString();
            hdIdchitietdangkykham.Value = dgr.DataKeys[e.Item.ItemIndex].ToString();//
            hdIdBenhNhan.Value = e.CommandArgument.ToString();
            hdTenBenhNhan.Value = e.Item.Cells[3].Text;
            hdLoaiBN.Value = dtBN.Rows[0]["loai"].ToString();
            LoadPhongNhap(hdIdchitietdangkykham.Value);
            txtNgayGiuong.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtGioGiuong.Text = DateTime.Now.ToString("HH:mm");
            if (Request.QueryString["idkhoa"].ToString() != "15")
            {
                string sqlGiuongNhap = @"select top 1 * from benhnhannoitru where idkhoanoitru="+Request.QueryString["idkhoa"].ToString()+" and idchitietdangkykham=" + hdIdchitietdangkykham.Value + " order by idnoitru desc";
                DataTable dtG = DataAcess.Connect.GetTable(sqlGiuongNhap);
                if (dtG.Rows.Count > 0)
                {
                    try
                    {
                        ddlPhongNhapVien.SelectedValue = dtG.Rows[0]["idphongnoitru"].ToString();
                    }
                    catch (Exception ex) { }
                    LoadGiuongNhap(ddlPhongNhapVien.SelectedValue);
                    try
                    {
                    ddlGiuongNhapVien.SelectedValue = dtG.Rows[0]["idgiuong"].ToString();
                    }
                    catch (Exception ex) { }
                    txtTienGiuong.Text = dtG.Rows[0]["GiaGiuong"].ToString();
                }
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'block';", true);

            StaticData.SetFocus(this, "txtmachandoan_3");
        }
        else
            StaticData.MsgBox(this, "Vui lòng thử lại sau !");
        //        int idkhambenh;
        //        string idbenhnhan = e.CommandArgument.ToString();
        //        idkhambenh = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        //        string sql = @"select madichvu from khambenh kb left join banggiadichvu bg on bg.idbanggiadichvu=kb.iddvphongchuyenden
        //                    where madichvu is not null and isnull(idkhambenhgoc,0)=0 and idkhambenh="+idkhambenh+"";
        //        DataTable dt = DataAcess.Connect.GetTable(sql);
        //        if (dt.Rows.Count > 0 && dt.Rows[0]["madichvu"].ToString() =="2000")
        //            Response.Redirect("../noitru/Benhannoikhoa_CapCuu.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
        //        else
        //            Response.Redirect("../noitru/Benhanngoaikhoa_CapCuu.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");

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
    public void LoadPhongNhap(string Idchitietdangkykham)
    {
        string sql = @"select p.* from kb_phong p left join banggiadichvu bg on bg.idbanggiadichvu=p.dichvukcb
left join phongkhambenh k on k.idphongkhambenh=bg.idphongkhambenh where k.idphongkhambenh=" + Request.QueryString["idkhoa"].ToString() + " AND id<>61 ";
        if (Request.QueryString["idkhoa"].ToString() != "15")
            sql += "and p.isphongnoitru=1";
        DataTable dtPhongNhap = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPhongNhapVien, dtPhongNhap, "id", "TenPhong", "--Chọn phòng--");        
        if (dtPhongNhap.Rows.Count > 0)
            LoadGiuongNhap(ddlPhongNhapVien.SelectedValue);
    }
    public void LoadGiuongNhap(string idPhongNhap)
    {
        string sql = "";
        sql = @"select giuongid,giuongcode from kb_giuong where idphong=" + idPhongNhap;
        if (Request.QueryString["idkhoa"] != null && Request.QueryString["idkhoa"].ToString() == "15")
        {
            sql = @"select giuongid,giuongcode from kb_giuong where idphong in (select id from kb_phong p inner join banggiadichvu bg on bg.idbanggiadichvu=p.dichvukcb and bg.idphongkhambenh=15)";
            lbPhong.Visible = false; ddlPhongNhapVien.Visible = false;
        }
        DataTable dtGuong = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlGiuongNhapVien, dtGuong, "giuongid", "giuongcode");        
        if (ddlGiuongNhapVien.SelectedValue != "0" && ddlGiuongNhapVien.SelectedValue != "" && hdGiaGiuong.Value =="0")
            LoadTienGiuong(ddlGiuongNhapVien.SelectedValue);
    }
    public void LoadTienGiuong(string idGiuong)
    {
        string sqlG = @"select top 1 giuongcode,giaBH,giaDV,giangoaigio from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid
 where g.giuongid=" + idGiuong + " order by banggiagiuongid desc";
        DataTable dtG = DataAcess.Connect.GetTable(sqlG);
        if (dtG.Rows.Count > 0)
        {
            if (hdLoaiBN.Value == "1")
                txtTienGiuong.Text = StaticData.FormatNumber(dtG.Rows[0]["giaBH"], false).ToString();
            else
                txtTienGiuong.Text = StaticData.FormatNumber(dtG.Rows[0]["giaDV"], false).ToString();
        }
    }
    protected void ddlPhongNhapVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGiuongNhap(ddlPhongNhapVien.SelectedValue);
    }
    protected void ddlGiuongNhapVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadTienGiuong(ddlGiuongNhapVien.SelectedValue);
    }
    protected void btlydo_Click(object sender, EventArgs e)
    {
        string NgayXet = StaticData.CheckDate(txtNgayGiuong.Text.Trim()) + " " + txtGioGiuong.Text.Trim();
        string TienGiuongNhap = txtTienGiuong.Text.Replace(",", "").Trim();
        if (TienGiuongNhap.Equals(""))
        { StaticData.MsgBox(this, "Chưa nhập tiền giường !"); return; }
        if (StaticData.ParseFloat(TienGiuongNhap) == 0)
        {
            //StaticData.MsgBox(this, "Chưa nhập tiền giường !"); return;
            TienGiuongNhap = "0";
        }
        string sqlKB = @"select  top 1 * from khambenh where idchitietdangkykham=" + hdIdchitietdangkykham.Value + " order by idkhambenh desc";
        DataTable dtkb = DataAcess.Connect.GetTable(sqlKB);
        hdIdKhamBenh.Value = dtkb.Rows[0]["idkhambenh"].ToString();
        if (Request.QueryString["idkhoa"].ToString() == "15")
        {
            #region Khoa Cấp Cứu
            string sqlIns = "";
//            string sqlKiemTra = @"select * from kb_giuongphieuthanhtoan where idchitietdangkykham=" + hdIdchitietdangkykham.Value + "  and convert(varchar(10),ngayxetgiuong,103)='" + txtNgayGiuong.Text.Trim()+ "'";
//            DataTable dtTienG = DataAcess.Connect.GetTable(sqlKiemTra);
//            if (dtTienG.Rows.Count > 0) // cập nhật
//            {
//                sqlIns = @"update kb_giuongphieuthanhtoan set IdPTT='" + hdIdKhamBenh.Value + "',DonGia='" + TienGiuongNhap + "',ThanhTien='" + TienGiuongNhap + @"'
//            where idgiuong= " + dtTienG.Rows[0]["idgiuong"] + " ";
//            }
//            else  //thêm mới
//            {
            string isChonTrongNgay = cbTinhTienTrongNgay.Checked == true ? "1" : "0";
                sqlIns = @"insert into kb_giuongphieuthanhtoan (IdPTT,
        TenGiuong,
        SoLuong,
        DonGia,
        ThanhTien,
        idchitietdangkykham,ngayxetgiuong,idgiuongxet
,isChonTrongNgay) 
        values ('" + hdIdKhamBenh.Value + "','" + ddlGiuongNhapVien.SelectedItem.Text + "','1','" + TienGiuongNhap + "','" + TienGiuongNhap + "','" + hdIdchitietdangkykham.Value + "','" + NgayXet + "','" + ddlGiuongNhapVien.SelectedValue + "','" + isChonTrongNgay+ "')";
            //}
            bool kt = DataAcess.Connect.ExecSQL(sqlIns);
            if (kt)
            {
                #region cập nhật trạng thái check tính giường
                if (cbTinhTienTrongNgay.Checked == true)
                {
                    string sqlKiemTra = @"select top 1 IDgiuong from kb_giuongphieuthanhtoan where idchitietdangkykham=" + hdIdchitietdangkykham.Value + "  and convert(varchar(10),ngayxetgiuong,103)='" + txtNgayGiuong.Text.Trim() + "' order by idgiuong desc";
                    DataTable dtTienG = DataAcess.Connect.GetTable(sqlKiemTra);
                    if (dtTienG.Rows.Count > 0)
                    {
                        bool ktTTG = StaticData.NVK_CapNhatTinhTrangGiuong(txtNgayGiuong.Text.Trim(),hdIdchitietdangkykham.Value,"0", dtTienG.Rows[0]["IDgiuong"].ToString());
                    }
                }
                #endregion
                StaticData.MsgBox(this, "Đã xét tiền giường !");
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'none';", true);
                ImageButton1_Click(null, null);
            }
            else
                StaticData.MsgBox(this, "Lỗi !");
        }
            #endregion
        else
        {
            string sqlNoiTru = @"select top 1 *,case when isnull((select top 1 idgiuong from benhnhannoitru where isnull(idgiuong,0)<>0 and  idchitietdangkykham =nt.idchitietdangkykham and idkhoanoitru=nt.idkhoanoitru),0)=0 then N'Xét giường'
            else N'Chuyển giường' end as ChucNang
            from benhnhannoitru nt where idchitietdangkykham=" + hdIdchitietdangkykham.Value + " and idkhoanoitru=" + Request.QueryString["idkhoa"] + @" order by idnoitru desc";
            DataTable dtNoiTru = DataAcess.Connect.GetTable(sqlNoiTru);
            if (dtNoiTru != null && dtNoiTru.Rows.Count > 0)
            {
                string Ngay = StaticData.CheckDate(txtNgayGiuong.Text.Trim()) + " " + txtGioGiuong.Text;
                string sqlInsert = "";
                if (dtNoiTru.Rows[0]["ChucNang"].ToString().Equals("Xét giường"))
                    sqlInsert = @"update benhnhannoitru set NgayVaoVien='"+Ngay+"',IdPhongNoiTru=" + ddlPhongNhapVien.SelectedValue + ", idgiuong='" + ddlGiuongNhapVien.SelectedValue + "',GiaGiuong='" + TienGiuongNhap + "' where idnoitru=" + dtNoiTru.Rows[0]["idnoitru"].ToString() + "";
                else
                    sqlInsert = @"
                    insert into benhnhannoitru (NgayVaoVien,NhapTuKhoa,IdKhoaNoiTru,IdChiTietDangKyKham,IdKhamBenhGoc
                    ,IdBenhNhan,IdPhongNoiTru,IdGiuong,ListIdCD,GiaGiuong
                    ,IsDaNhap,IdKhamBenhNhap)
                    values('"+Ngay+"','"+dtNoiTru.Rows[0]["NhapTuKhoa"].ToString()+"','"+dtNoiTru.Rows[0]["idkhoanoitru"].ToString()+"','"+dtNoiTru.Rows[0]["idchitietdangkykham"].ToString()+"','"+dtNoiTru.Rows[0]["idkhambenhgoc"].ToString()+@"'
                    ,'" + dtNoiTru.Rows[0]["idbenhnhan"].ToString() + "','" + ddlPhongNhapVien.SelectedValue + "','" + ddlGiuongNhapVien.SelectedValue + "','" + dtNoiTru.Rows[0]["ListIdCD"].ToString() + "'," + TienGiuongNhap + @"
                    ," +dtNoiTru.Rows[0]["IsDaNhap"].ToString()+","+dtNoiTru.Rows[0]["IdKhamBenhNhap"].ToString()+@")
                    ";
                bool ktUtg = DataAcess.Connect.ExecSQL(sqlInsert);
                if (ktUtg)
                {
                    #region cập nhật trạng thái check tính giường
                    if (cbTinhTienTrongNgay.Checked == true)
                    {
                        string sqlKiemTra = @"select top 1 idnoitru from benhnhannoitru where idchitietdangkykham=" + hdIdchitietdangkykham.Value + "  and convert(varchar(10),ngayvaovien,103)='" + txtNgayGiuong.Text.Trim() + "'  and idkhoanoitru=" + Request.QueryString["idkhoa"] + @" order by idnoitru desc";
                        DataTable dtTienG = DataAcess.Connect.GetTable(sqlKiemTra);
                        if (dtTienG.Rows.Count > 0)
                        {
                            bool ktTTG = StaticData.NVK_CapNhatTinhTrangGiuong(txtNgayGiuong.Text.Trim(), hdIdchitietdangkykham.Value, dtTienG.Rows[0]["idnoitru"].ToString(), "0");
                        }
                    }
                    #endregion
                    StaticData.MsgBox(this, "Đã xét chuyển giường !");
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'none';", true);
                    ImageButton1_Click(null, null);
                }
                else
                    StaticData.MsgBox(this, "Lỗi !");
            }
            else
            {
                StaticData.MsgBox(this, "Bệnh nhân này chưa nhập khoa. Vui lòng nhập khoa trước !");
            }
        }
    }
}

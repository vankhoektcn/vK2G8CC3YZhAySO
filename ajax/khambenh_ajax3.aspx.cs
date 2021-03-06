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

public partial class khambenh_ajax : System.Web.UI.Page
{
    protected DataProcess s_khambenh()
    {
        DataProcess khambenh = new DataProcess("KHAMBENH");
        khambenh.data("idkhambenh", Request.QueryString["idkhoachinh"]);
        khambenh.data("maphieukham", Request.QueryString["maphieukham"]);
        khambenh.data("ngaykham", Request.QueryString["ngaykham"]);
        khambenh.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        khambenh.data("iddangkykham", Request.QueryString["iddangkykham"]);
        khambenh.data("idbacsi", Request.QueryString["idbacsi"]);
        khambenh.data("trieuchung", Request.QueryString["trieuchung"]);
        khambenh.data("benhsu", Request.QueryString["benhsu"]);
        khambenh.data("chandoanbandau", Request.QueryString["chandoanbandau"]);
        khambenh.data("ketluan", Request.QueryString["ketluan"]);
        khambenh.data("ketluan1", Request.QueryString["ketluan1"]);
        khambenh.data("ketluan2", Request.QueryString["ketluan2"]);
        khambenh.data("huongdieutri", Request.QueryString["huongdieutri"]);
        khambenh.data("phongkhamchuyenden", Request.QueryString["phongkhamchuyenden"]);
        khambenh.data("ghichuhuongdieutri", Request.QueryString["ghichuhuongdieutri"]);
        khambenh.data("chidinhbacsi", Request.QueryString["chidinhbacsi"]);
        khambenh.data("dando", Request.QueryString["dando"]);
        khambenh.data("noidungtaikham", Request.QueryString["noidungtaikham"]);
        khambenh.data("ngayhentaikham", Request.QueryString["ngayhentaikham"]);
        khambenh.data("hoantat", Request.QueryString["hoantat"]);
        khambenh.data("idphongkhambenh", Request.QueryString["idphongkhambenh"]);
        khambenh.data("TienSu", Request.QueryString["TienSu"]);
        khambenh.data("SoPhieuTT", Request.QueryString["SoPhieuTT"]);
        khambenh.data("idPhongChuyenDen", Request.QueryString["idPhongChuyenDen"]);
        khambenh.data("thuChuyenPhong", Request.QueryString["thuChuyenPhong"]);
        khambenh.data("idDVPhongChuyenDen", Request.QueryString["idDVPhongChuyenDen"]);
        khambenh.data("IdChiTietDangKyKham", Request.QueryString["IdChiTietDangKyKham"]);
        khambenh.data("ChanDoanTuyenDuoi", Request.QueryString["ChanDoanTuyenDuoi"]);
        khambenh.data("isNoiTru", "1");
        khambenh.data("idkhambenhgoc", Request.QueryString["idkhambenhgoc"]);
        khambenh.data("IdDieuDuong", Request.QueryString["IdDieuDuong"]);
        khambenh.data("sovaovien", (!string.IsNullOrEmpty(Request.QueryString["sovaovien"]) ? Request.QueryString["sovaovien"] : StaticData.NewSoVaoVien(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())));
        return khambenh;
    }
    protected DataProcess s_chitietbenhnhantoathuoc()
    {
        DataProcess chitietbenhnhantoathuoc = new DataProcess("chitietbenhnhantoathuoc");
        chitietbenhnhantoathuoc.data("idchitietbenhnhantoathuoc", Request.QueryString["idkhoachinh"]);
        chitietbenhnhantoathuoc.data("idbenhnhantoathuoc", Request.QueryString["idbenhnhantoathuoc"]);
        chitietbenhnhantoathuoc.data("idthuoc", Request.QueryString["idthuoc"]);
        chitietbenhnhantoathuoc.data("soluongbanra", Request.QueryString["soluongbanra"]);
        chitietbenhnhantoathuoc.data("dongia", Request.QueryString["dongia"]);
        chitietbenhnhantoathuoc.data("slton", Request.QueryString["slton"]);
        chitietbenhnhantoathuoc.data("moilanuong", Request.QueryString["moilanuong"]);
        chitietbenhnhantoathuoc.data("donvidung", Request.QueryString["donvidung"]);
        chitietbenhnhantoathuoc.data("ghichu", Request.QueryString["ghichu"]);
        chitietbenhnhantoathuoc.data("bacsixoa", Request.QueryString["bacsixoa"]);
        chitietbenhnhantoathuoc.data("quaythuocxoa", Request.QueryString["quaythuocxoa"]);
        chitietbenhnhantoathuoc.data("thoigiandung", Request.QueryString["thoigiandung"]);
        chitietbenhnhantoathuoc.data("tenNgaydung", Request.QueryString["tenNgaydung"]);
        chitietbenhnhantoathuoc.data("thanhtien", Request.QueryString["thanhtien"]);
        chitietbenhnhantoathuoc.data("heso", Request.QueryString["heso"]);
        chitietbenhnhantoathuoc.data("IdThuoc1", Request.QueryString["IdThuoc1"]);
        chitietbenhnhantoathuoc.data("idkhambenh", Request.QueryString["idkhambenh"]);
        chitietbenhnhantoathuoc.data("idkho", Request.QueryString["idkho"]);
        string nvk_doituong = "1";
        string nvk_IsHaoPhi = "0";
        if (Request.QueryString["doituongthuocid"] != null)
            nvk_IsHaoPhi = Request.QueryString["doituongthuocid"].ToString();
        if (nvk_IsHaoPhi.ToLower().Equals("true"))
        {
            nvk_IsHaoPhi = "1";
            nvk_doituong = "3";
        }
        else
        {
            nvk_IsHaoPhi = "0";
        }
        chitietbenhnhantoathuoc.data("IsHaoPhi", nvk_IsHaoPhi);
        chitietbenhnhantoathuoc.data("DoiTuongThuocID", nvk_doituong);
        chitietbenhnhantoathuoc.data("SoLuongTheoDonVi", Request.QueryString["soluongke"]);
        string SoLuongKe = "0";
        if (Request.QueryString["idthuoc"] != null && Request.QueryString["soluongke"] != null)
            SoLuongKe = Request.QueryString["soluongke"];//getSoLuongKe(Request.QueryString["idthuoc"], Request.QueryString["soluongke"]);
        chitietbenhnhantoathuoc.data("soluongke", SoLuongKe);
        if (Request.QueryString["soluongtra"] != null)
        {
            string SoLuongTra = "0";
            if (Request.QueryString["idthuoc"] != null && Request.QueryString["soluongtra"] != null)
                SoLuongTra = Request.QueryString["soluongtra"];//getSoLuongTra(Request.QueryString["idthuoc"], Request.QueryString["soluongtra"]);
            chitietbenhnhantoathuoc.data("soluongtra", SoLuongTra);
        }
        //chitietbenhnhantoathuoc.data("soluongtra", Request.QueryString["soluongtra"]);

        #region nvk isBHYT
        string nvk_isBHYT = "0";
        if (Request.QueryString["IsBHYT_Save"] != null)
            nvk_isBHYT = Request.QueryString["IsBHYT_Save"].ToString();
        if (nvk_isBHYT.ToLower().Equals("true"))
            nvk_isBHYT = "1";
        else
            nvk_isBHYT = "0";
        #endregion
        chitietbenhnhantoathuoc.data("IsBHYT_Save", nvk_isBHYT);
        return chitietbenhnhantoathuoc;
    }
    private string getSoLuongKe(string idthuoc, string SoLuongNhap)
    {
        if (idthuoc == "" || SoLuongNhap == "")
            return "0";
        string SoLuong = SoLuongNhap;
        string sqlThuoc = @"select case when isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then " + SoLuongNhap + @"
                            else convert(float," + SoLuongNhap + @")/convert(float,isnull(SoLuong1donvi,1)) end as SoLuongTraVe
                        from thuoc where idthuoc=" + idthuoc + "";
        DataTable dtSoLuong = DataAcess.Connect.GetTable(sqlThuoc);
        if (dtSoLuong != null && dtSoLuong.Rows.Count > 0)
            SoLuong = dtSoLuong.Rows[0]["SoLuongTraVe"].ToString();
        return SoLuong;
    }
    private string getSoLuongTra(string idthuoc, string SoLuongTra)
    {
        if (idthuoc == "" || SoLuongTra == "")
            return "0";
        string SoLuong = SoLuongTra;
        string sqlThuoc = @"select case when isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then " + SoLuongTra + @"
                            else convert(float," + SoLuongTra + @")/convert(float,isnull(SoLuong1donvi,1)) end as SoLuongTraVe
                        from thuoc where idthuoc=" + idthuoc + "";
        DataTable dtSoLuong = DataAcess.Connect.GetTable(sqlThuoc);
        if (dtSoLuong != null && dtSoLuong.Rows.Count > 0)
            SoLuong = dtSoLuong.Rows[0]["SoLuongTraVe"].ToString();
        return SoLuong;
    }
    protected DataProcess s_khambenhcanlamsan()
    {
        DataProcess khambenhcanlamsan = new DataProcess("khambenhcanlamsan");
        khambenhcanlamsan.data("idkhambenhcanlamsan", Request.QueryString["idkhoachinh"]);
        khambenhcanlamsan.data("idcanlamsan", Request.QueryString["idcanlamsan"]);
        khambenhcanlamsan.data("idkhambenh", Request.QueryString["idkhambenh"]);
        khambenhcanlamsan.data("dongia", Request.QueryString["dongia"]);
        khambenhcanlamsan.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        string loaiBN = StaticData.GetValue("benhnhan", "idbenhnhan", StaticData.ParseInt(Request.QueryString["idbenhnhan"]), "loai");
        string ngaythu = StaticData.GetValue("khambenhcanlamsan", "idkhambenhcanlamsan", StaticData.ParseInt(Request.QueryString["idkhoachinh"]), "ngaythu");
        if (loaiBN == "1" && (ngaythu == "" || ngaythu == "0"))
            khambenhcanlamsan.data("ngaythu", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        khambenhcanlamsan.data("maphieucls", Request.QueryString["maphieucls"]);
        khambenhcanlamsan.data("soluong", Request.QueryString["soluong"]);
        khambenhcanlamsan.data("chietkhau", Request.QueryString["chietkhau"]);
        khambenhcanlamsan.data("thanhtien", Request.QueryString["thanhtien"]);
        khambenhcanlamsan.data("ghichu", Request.QueryString["ghichu"]);
        //khambenhcanlamsan.data("dathu", "0");
        #region nvk isBHYT
        string nvk_isBHYT = "0";
        if (Request.QueryString["IsBHYT_Save"] != null)
            nvk_isBHYT = Request.QueryString["IsBHYT_Save"].ToString();
        if (nvk_isBHYT.ToLower().Equals("true"))
            nvk_isBHYT = "1";
        else
            nvk_isBHYT = "0";
        #endregion
        khambenhcanlamsan.data("IsBHYT_Save", nvk_isBHYT);
        return khambenhcanlamsan;
    }
    protected DataProcess s_benhnhannoitru()
    {
        DataProcess benhnhannoitru = new DataProcess("benhnhannoitru");
        benhnhannoitru.data("IdNoiTru", Request.QueryString["idkhoachinh"]);
        benhnhannoitru.data("IdGiuong", Request.QueryString["IdGiuong"]);
        string IdPhongNoiTru = "0";
        DataTable dtPhong = DataAcess.Connect.GetTable("select idphong from kb_giuong where giuongid=" + Request.QueryString["IdGiuong"]);
        if (dtPhong != null && dtPhong.Rows.Count > 0)
            IdPhongNoiTru = dtPhong.Rows[0]["idphong"].ToString();
        benhnhannoitru.data("IdPhongNoiTru", IdPhongNoiTru);
        benhnhannoitru.data("GiaGiuong", Request.QueryString["dongia"]);
        return benhnhannoitru;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savekhambenh(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTablechitietbenhnhantoathuoc": LuuTablechitietbenhnhantoathuoc(); break;
            case "luuTablekhambenhcanlamsan": LuuTablekhambenhcanlamsan(); break;
            case "loadTablechitietbenhnhantoathuoc": loadTablechitietbenhnhantoathuoc(); break;
            case "loadTablekhambenhcanlamsan": loadTablekhambenhcanlamsan(); break;
            case "xoa": Xoakhambenh(); break;
            case "xoachitietbenhnhantoathuoc": Xoachitietbenhnhantoathuoc(); break;
            case "xoakhambenhcanlamsan": Xoakhambenhcanlamsan(); break;
            case "chandoanbandausearch": chandoanbandausearch(); break;
            case "huongdieutrisearch": huongdieutrisearch(); break;
            case "huongdieutrisearch_KhamcapCuu": huongdieutrisearch_KhamcapCuu(); break;
            case "huongdieutrisearch_KhamKhoaSan": huongdieutrisearch_KhamKhoaSan(); break;
            case "ghichuhuongdieutriSearch": ghichuhuongdieutriSearch(); break;
            case "idthuocsearch": idthuocsearch(); break;
            case "idcanlamsansearch": idcanlamsansearch(); break;
            //case "idbacsisearch": idbacsisearch(); break;
            case "iddieuduongNhapKhoasearch": iddieuduongNhapKhoasearch(); break;

            case "idkhosearch": idkhosearch(); break;
            case "idkhosearch_CapCuu": idkhosearch_CapCuu(); break;
            case "idkhosearch_ChiDinh": idkhosearch_ChiDinh(); break;
            case "loaithuocidsearch": loaithuocidsearch(); break;
            case "doituongthuocidsearch": doituongthuocidsearch(); break;
            case "khoakhambenhSearch": khoakhambenhSearch(); break;
            case "banggiadichvuSearch": banggiadichvuSearch(); break;
            case "phongkhambenhSearch": phongkhambenhSearch(); break;
            case "Loadsauhuongdieutri": Loadsauhuongdieutri(); break;
            case "Setsauhuongdieutri": Setsauhuongdieutri(); break;
            case "SetBacSiChiDinh": SetBacSiChiDinh(); break;
            case "ChonCLS": ChonCLS(); break;
            case "loadTableAjaxDSkhambenh": loadTableAjaxDSkhambenh(); break;
            case "IdDieuDuongsearch": IdDieuDuongsearch(); break;
            case "xuatkho": xuatkho(); break;
            case "loadTablechandoanphoihop": loadTablechandoanphoihop(); break;

            case "idBenhViensearch": idBenhViensearch(); break;
            //case "Luukhambenhmoi": Luukhambenhmoi(); break;
            case "idBenhNhansearch": idBenhNhansearch(); break;
            case "luuTableGiuongNoiTru": luuTableGiuongNoiTru(); break;
            case "idGiuongsearch": idGiuongsearch(); break;
            case "IdKhoaSearch_2509": nvk_IdKhoaSearch_2509(); break;
            // NVK_ function 
            case "getPhongBNMotNgay": NVK_getPhongBNMotNgay(); break;
            case "saveChonGiuongNgay": NVK_saveChonGiuongNgay(); break;
            case "getGiuongMotPhong": NVK_getGiuongMotPhong(); break;
            case "ShowDanhSachGiuongChon": NVK_ShowDanhSachGiuongChon(); break;
            case "idICDCapCuusearchMoTa": NVK_idICDCapCuusearchMoTa(); break;
            case "idICDCapCuusearchMaICD": NVK_idICDCapCuusearchMaICD(); break;
            case "SetChanDoanXacDinh": NVK_SetChanDoanXacDinh(); break;
            case "SetChanDoanPhoiHop": NVK_SetChanDoanPhoiHop(); break;
            case "TimToaThuocTheoIdBenhNhan": NVK_TimToaThuocTheoIdBenhNhan(); break;
            case "ThongnTinBenhNhanUserControl": NVK_ThongnTinBenhNhanUserControl(); break;
            case "loadTableToaThuocCu": NVK_loadTableToaThuocCu(); break;
            case "XoaBenhNhanTrung": NVK_XoaBenhNhanTrung(); break;
            case "idthuocXUATVIENsearch": idthuocXUATVIENsearch(); break;
            case "khotoaxuatviensearch": nvk_khotoaxuatviensearch(); break;
        }
    }

    private void NVK_XoaBenhNhanTrung()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string sqlDel = "delete from khambenh where idbenhnhan =" + idbenhnhan + " ";
        bool ktDel = DataAcess.Connect.ExecSQL(sqlDel);
        if (ktDel)
        {
            sqlDel = "delete from chitietdangkykham where iddangkykham in (select iddangkykham from dangkykham where idbenhnhan=" + idbenhnhan + ")";
            ktDel = DataAcess.Connect.ExecSQL(sqlDel);
            if (ktDel)
            {
                sqlDel = "delete from dangkykham where idbenhnhan=" + idbenhnhan + "";
                ktDel = DataAcess.Connect.ExecSQL(sqlDel);
                if (ktDel)
                {
                    sqlDel = "delete from benhnhan where idbenhnhan=" + idbenhnhan + "";
                    ktDel = DataAcess.Connect.ExecSQL(sqlDel);
                    if (ktDel)
                    {
                        Response.Clear();
                        Response.Write("1");
                        return;
                    }
                }
            }
        }
        Response.Clear();
        Response.Write("0");
        return;
    }
    private void NVK_loadTableToaThuocCu()
    {
        bool isadmin = false;
        if (SysParameter.UserLogin.GroupID(this) == "4")
            isadmin = true;
        DataProcess process = s_chitietbenhnhantoathuoc();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                                ,b.loaithuocid,b.tenloai,a.tenthuoc,k.tenkho
                                ,dt.TenDoiTuong,nvk_IsHaoPhi= isnull(convert(int,ishaophi),0)
,soluongke as SoLuongDonVi--case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongke else isnull(SoLuongTheoDonVi,0) end as SoLuongDonVi
--,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongTra else isnull(t.soluongTra,0)*isnull(SoLuong1donvi,0)  end as TraTheoDonVi
,dvt.TenDVT as DonViCoBan--case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then N'' else N'/'+convert(varchar,SoLuong1donvi)+TenDonVi end as DonViCoBan
,nvk_SLTON=DBO.[NVK_Thuoc_TonKho](t.IDTHUOC,GETDATE(),t.idkho)
,slDaXuat=0
                                ,nvk_loaibn=isnull(
	                                (select top 1 dk.loaikhamid from dangkykham dk 
											                                inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                                  where ct.idchitietdangkykham =kb.idchitietdangkykham
	                                )
                                ,0)
                                ,nvk_isBHYT =  convert(int,isnull(T.IsBHYT_Save,0))
                                , isTrongDM= convert(int,isnull(a.sudungchobh,0))
                                ,nvk_loaikho=isnull(nvk_loaikho,0)
                                ,ISDAYEUCAU1=0
                               from chitietbenhnhantoathuoc T left join khambenh kb on kb.idkhambenh =t.idkhambenh
                                left join thuoc a on a.idthuoc=t.idthuoc
                            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
                            left join khothuoc k on k.idkho = T.idkho
                            left join thuoc_doituongthuoc dt on dt.DoiTuongThuocID = t.DoiTuongThuocID
                            left join thuoc_donvitinh dvt on dvt.id = a.iddvt
          where T.idkhambenh='" + process.getData("idkhambenh") + "'");
        #region newTable
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>Loại</th>");
        html.Append("<th>Hao phí ?</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
        html.Append("<th>DmBh?</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongke") + "</th>");
        //html.Append( "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongtra") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL Tồn") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đã Xuất") + "</th>");
        html.Append("<th>Bhyt?</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
        html.Append("</tr>");
        string disabled_bhyt_i = "disabled='true'";
        if (table != null && table.Rows.Count > 0)
        {
            if (table.Rows[0]["nvk_loaibn"].ToString().Equals("1"))
                disabled_bhyt_i = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str_checkHaoPhi = "";
                if (table.Rows[i]["nvk_IsHaoPhi"].ToString().Equals("1"))//nvk_IsHaoPhi
                    str_checkHaoPhi = "checked";
                string disable_editThuoc = " disabled=disabled ";
                if (StaticData.IsCheck(table.Rows[i]["ISDAYEUCAU1"].ToString()) == false)
                    disable_editThuoc = "";
                html.Append("<tr>");
                html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                html.Append(@"<td>");
                html.Append("<a  onclick='xoaontable(this)'> " + (StaticData.IsCheck(table.Rows[i]["ISDAYEUCAU1"].ToString()) ? "" : hsLibrary.clDictionaryDB.sGetValueLanguage("delete")) + "</a>");
                html.Append("</td>");
                html.Append("<td><input id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='" + table.Rows[i]["tenloai"].ToString() + "' class='down_select'/></td>");
                //html.Append( "<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='" + table.Rows[i]["TenDoiTuong"].ToString() + "' class='down_select'/></td>");
                html.Append("<td><input mkv='true' id='doituongthuocid' type='checkbox' " + str_checkHaoPhi + "  value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "'/></td>");
                html.Append(@"<td><input mkv='true' " + disable_editThuoc + " id='idkho' type='hidden' value='" + table.Rows[i]["idkho"].ToString() + @"'/> 
                        <input mkv='true' id='nvk_loaikho' type='hidden' value='" + table.Rows[i]["nvk_loaikho"].ToString() + @"'/>
                        <input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='" + table.Rows[i]["tenkho"].ToString() + "' class='down_select'/></td>");
                html.Append("<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' " + disable_editThuoc + " id='mkv_idthuoc' style='width:350px' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='" + table.Rows[i]["tenthuoc"].ToString() + "' class='down_select'/></td>");
                html.Append("<td><input id='IsBHYT_DM' disabled='true' " + (table.Rows[i]["isTrongDM"].ToString().Equals("1") ? "checked" : "") + " type='checkbox' /></td>");
                html.Append(@"<td ><input mkv='true' style='width:30px;text-align:right' id='soluongke' type='text' onfocusout='nvk_kiemtratonthuoc(this);chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoLuongDonVi"].ToString() + @"' onblur='TestSo(this,false,false);'/>
<input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value='" + table.Rows[i]["DonViCoBan"].ToString() + @"'/>
            <input id='nvk_soluongton' type='hidden' value='" + table.Rows[i]["nvk_SLTON"] + @"' />
                    </td>");
                //html.Append( "<td><input mkv='true' style='width:20px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TraTheoDonVi"].ToString() + "' onblur='TestSo(this,false,false);ktrasltra(this);'/></td>");
                html.Append("<td><input mkv='true' style='width:50px' id='slton' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["nvk_SLTON"].ToString() + "' onblur='TestSo(this,false,false);'/></td>");
                html.Append("<td><input mkv='true' style='width:50px' id='slDaXuat' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["slDaXuat"].ToString() + "' /></td>");
                html.Append("<td><input mkv='true' id='IsBHYT_Save' " + (table.Rows[i]["isTrongDM"].ToString().Equals("1") ? "" : "disabled='true'") + " type='checkbox' " + (table.Rows[i]["nvk_isBHYT"].ToString().Equals("1") ? "checked" : "") + " /></td>");
                html.Append(@"<td><input mkv='true' style='width:80px' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + @"' /></td>
                    <input mkv='true' id='idkhoachinh' type='hidden' value=''/>
                    <input mkv='true' id='nvk_slKeTruoc' type='hidden' value='" + table.Rows[i]["SoLuongDonVi"].ToString() + "'/>");
                html.Append("</tr>");
            }
        }
        html.Append("<tr>");
        html.Append("<td>" + (table.Rows.Count + 1) + "</td>");
        html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td><input  id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='' class='down_select'/></td>");
        //
        //html.Append( "<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='' class='down_select'/></td>");
        html.Append("<td><input mkv='true' id='doituongthuocid' type='checkbox' value=''/></td>");
        //
        html.Append("<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='' class='down_select'/></td>");
        html.Append(@"<td><input mkv='true' id='idthuoc' type='hidden' value='' /> <input mkv='true' id='nvk_loaikho' type='hidden' value='' />
            <input mkv='true' id='mkv_idthuoc'  style='width:300px'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='' class='down_select'/></td>");
        html.Append("<td><input id='IsBHYT_DM' disabled='true' type='checkbox' /></td>");
        html.Append(@"<td><input mkv='true' style='width:30px;text-align:right'  id='soluongke' type='text' onfocusout='nvk_kiemtratonthuoc(this);chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'>
            <input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value=''/>
            <input id='nvk_soluongton' type='hidden' value='' />
            </td>");
        //html.Append( "<td><input mkv='true' style='width:30px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);ktrasltra(this);' /></td>");
        html.Append("<td><input mkv='true' style='width:50px' id='slton' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>");
        html.Append("<td><input mkv='true' style='width:50px' id='slDaXuat' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
        html.Append("<td><input mkv='true' id='IsBHYT_Save' " + disabled_bhyt_i + " type='checkbox' /></td>");
        html.Append(@"<td><input mkv='true' style='width:80px' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>
                <input mkv='true' id='idkhoachinh' type='hidden' value=''/>
                <input mkv='true' id='nvk_slKeTruoc' type='hidden' value='0'/>");
        html.Append("</tr>");
        html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");
        html.Append(process.Paging("chitietbenhnhantoathuoc"));
        Response.Clear(); Response.Write(html);
        #endregion
        return;
        #region oldTable not use
        html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th></th>");
        html.Append("<th>Đối tượng</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongke") + "</th>");
        //html.Append( "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongtra") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayuong") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("moilanuong") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
        //html.Append( "<th></th>");
        html.Append("</tr>");
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str_checkHaoPhi = "";
                if (table.Rows[i]["nvk_IsHaoPhi"].ToString().Equals("1"))//nvk_IsHaoPhi
                    str_checkHaoPhi = "checked";
                html.Append("<tr>");
                html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                html.Append(@"<td>");
                //if(isadmin)
                html.Append("<a  onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a>");
                html.Append("</td>");
                html.Append("<td><input id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='" + table.Rows[i]["tenloai"].ToString() + "' class='down_select'/></td>");
                //
                html.Append("<td><input mkv='true' id='doituongthuocid' type='checkbox' " + str_checkHaoPhi + "  value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "'/></td>");
                //html.Append("<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='" + table.Rows[i]["TenDoiTuong"].ToString() + "' class='down_select'/></td>");
                //
                html.Append("<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idkho"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='" + table.Rows[i]["tenkho"].ToString() + "' class='down_select'/></td>");
                html.Append("<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idthuoc'  style='width:350px'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='" + table.Rows[i]["tenthuoc"].ToString() + "' class='down_select'/></td>");
                html.Append(@"<td ><input mkv='true' style='width:30px;text-align:right' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoLuongDonVi"].ToString() + @"' onblur='TestSo(this,false,false);'/>
<input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value='" + table.Rows[i]["DonViCoBan"].ToString() + @"'/>
                    </td>");
                //html.Append( "<td><input mkv='true' style='width:20px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TraTheoDonVi"].ToString() + "' onblur='TestSo(this,false,false);ktrasltra(this);'/></td>");
                html.Append("<td><input mkv='true' style='width:20px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "' onblur='TestSo(this,false,false);'/></td>");
                html.Append("<td><input mkv='true' style='width:20px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["moilanuong"].ToString() + "' /></td>");
                html.Append(@"<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + @"' />
                    <input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
                html.Append("</tr>");
            }
        }
        html.Append("<tr>");
        html.Append("<td>" + (table.Rows.Count + 1) + "</td>");
        html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td><input  id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='' class='down_select'/></td>");
        //
        html.Append("<td><input mkv='true' id='doituongthuocid' type='checkbox' value=''/></td>");
        //html.Append("<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='' class='down_select'/></td>");
        //
        html.Append("<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='' class='down_select'/></td>");
        html.Append("<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idthuoc'  style='width:350px'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='' class='down_select'/></td>");
        html.Append(@"<td><input mkv='true' style='width:30px' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'>
            <input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value=''/>
            </td>");
        //html.Append( "<td><input mkv='true' style='width:30px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);ktrasltra(this);' /></td>");
        html.Append("<td><input mkv='true' style='width:50px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>");
        html.Append("<td><input mkv='true' style='width:50px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:100px'/></td>");
        html.Append(@"<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' />
            <input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
        html.Append("</tr>");
        html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");
        html.Append(process.Paging("chitietbenhnhantoathuoc"));
        Response.Clear(); Response.Write(html);
        #endregion
    }
    private void NVK_ThongnTinBenhNhanUserControl()
    {
        string sqlBN = "select mabenhnhan,tenbenhnhan,ngaysinh,gioitinh=dbo.getgioitinh(gioitinh) from benhnhan where idbenhnhan=" + Request.QueryString["idbenhnhan"];
        DataTable dtBN = DataAcess.Connect.GetTable(sqlBN);
        string Info = dtBN.Rows[0]["mabenhnhan"].ToString() + "@@" + dtBN.Rows[0]["tenbenhnhan"].ToString() + "@@" + dtBN.Rows[0]["ngaysinh"].ToString() + "@@" + dtBN.Rows[0]["gioitinh"].ToString();

        Response.Clear();
        Response.Write(Info);
    }
    private void NVK_TimToaThuocTheoIdBenhNhan()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string sqlToaToaThuoc = @"
            select stt=row_number()over (order by ngaykham desc),* from (
            select idkhambenh,ngaykham,ngaychidinh=convert(varchar(10),ngaykham,103) +' '+ convert(varchar(5),ngaykham,108), soluong=isnull((select count(*) from chitietbenhnhantoathuoc where idkhambenh=kb.idkhambenh),0)
            ,ngayDuTru=convert(varchar(10),ngaydutruthuoc,103)
            from khambenh kb where kb.idbenhnhan =" + idbenhnhan + @"
            --and kb.idchitietdangkykham =
            --isnull((select top 1 idchitietdangkykham from chitietdangkykham ct left join dangkykham dk on dk.iddangkykham =ct.iddangkykham
             --where dk.idbenhnhan=" + idbenhnhan + @" order by idchitietdangkykham desc),0)
            --order by ngaykham desc
            ) as abc where soluong>0 --order by ngaychidinh desc";
        DataTable table = DataAcess.Connect.GetTable(sqlToaToaThuoc);
        string html = "";
        if (table.Rows.Count > 0)
        {
            html = "<table class='jtable' id=\"gridTableToaThuocCu\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th></th>";
            html += "<th>Ngày chỉ định</th>";
            html += "<th>Số thuốc + VTYT</th>";
            html += "<th>Dự trù ?</th>";
            html += "</tr>";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr style='cursor:pointer;' >";
                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";//
                html += "<td> <a onclick='SetChonToaThuoc(this.name,this)' name='" + table.Rows[i]["idkhambenh"].ToString() + "'>Chọn</a></td>";
                html += "<td>" + table.Rows[i]["ngaychidinh"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["soluong"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["ngayDuTru"].ToString() + "</td>";
                html += "</tr>";
            }

            html += "</table>";
        }
        Response.Clear();
        Response.Write(html);
    }
    private void NVK_SetChanDoanXacDinh()
    {
        string html = "";
        string idICD = "";
        string MaICD = "";
        string MoTaICD = "";
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        string idctdkk = Request.QueryString["idctdkk"];
        string idkhoa = Request.QueryString["idkhoa"];
        #region theo phiếu khám đã có ( mới nhất tại khoa nếu chua có idkhambenh)
        string sql = "";
        if (!idkhoachinh.Equals("0") && !idkhoachinh.Equals(""))
            sql = @"select top 1 cd.idicd,cd.MaICD,mota=isnull(MoTaCD_edit,cd.Mota) from khambenh kb inner join chandoanicd cd on kb.ketluan=cd.idicd  where kb.idkhambenh ='" + idkhoachinh + "'";
        else
            sql = @"select top 1 cd.idicd,cd.MaICD,mota=isnull(MoTaCD_edit,cd.Mota) from khambenh kb inner join chandoanicd cd on kb.ketluan=cd.idicd  where kb.idchitietdangkykham='" + idctdkk + "' and kb.idphongkhambenh ='" + idkhoa + "' order by kb.idkhambenh desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        #endregion
        if (table != null && table.Rows.Count > 0)
        {
            idICD = table.Rows[0]["idICD"].ToString(); MaICD = table.Rows[0]["MaICD"].ToString();
            MoTaICD = table.Rows[0]["Mota"].ToString();
        }
        else if (idkhoachinh.Equals("0") || idkhoachinh.Equals(""))
        {
            #region theo thông tin nhập khoa
            sql = @"select top 1 cd.idicd,cd.MaICD,mota=isnull(MoTaChanDoan_NK,cd.Mota) from benhnhannoitru nt 
	                    inner join nvk_chanDoanNhapKhoa cdn on cdn.idnoitru= nt.idnoitru
	                    inner join chandoanicd cd on cd.idicd= cdn.idicd  where nt.idchitietdangkykham='" + idctdkk + "' and nt.IdKhoaNoiTru ='" + idkhoa + "' order by nt.idnoitru desc";
            table = DataAcess.Connect.GetTable(sql);
            if (table != null && table.Rows.Count > 0)
            {
                idICD = table.Rows[0]["idICD"].ToString(); MaICD = table.Rows[0]["MaICD"].ToString();
                MoTaICD = table.Rows[0]["Mota"].ToString();
            }
            #endregion
        }
        html += "<input mkv=\"true\" id=\"idbacsi\" value='' type=\"hidden\" /> " + "\r\n"
                + "<input mkv=\"true\" id=\"mkv_idbacsi\" value='' type=\"text\" onfocus=\"chuyenphim(this);idbacsisearch(this);\"" + "\r\n"
                  + "  class=\"down_select_hover\" style=\"width: 90%\" />";
        html = @"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Chẩn đoán :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "\r\n"
            + "<input type =\"hidden\" mkv=\"true\" id = \"idicdxacdinh\"  value = \"" + idICD + "\" style=\"width: 11px\" /> " + "\r\n"
            + "<input  id=\"motaicdxacdinh\" value = \"" + MoTaICD + "\"  class=\"down_select_hover\" type=\"text\" style=\"width:435px\" onfocus = \"loadicd(this,'mota','xd')\"> " + "\r\n"
            + "<input id=\"mkv_idicdxacdinh\" value = \"" + MaICD + "\" class=\"down_select_hover\" type=\"text\" style=\"width:50px\" onfocus=\"loadicd(this,'ma','xd')\" />(theo ICD10)";
        Response.Clear();
        Response.Write(html);
    }
    private void NVK_SetChanDoanPhoiHop()
    {
        string htmlPH = @"<table id='chandoanicd10_1' border='1' style='width:530px' >
				                <tr bgcolor='#0066ff' style='font-weight:bolder;color:White'>
				                    <td style='width:40px'></td>
				                    <td style='width:80px'>
				                        Mã ICD
				                    </td>
				                    <td>
				                        Mô tả
				                    </td>
                                </tr>
				                ";
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        string sql = "select cd.idicd,cd.maicd,mota=isnull(ph.MoTaCD_edit,cd.mota) from chandoanicd cd left join chandoanphoihop ph on ph.idicd=cd.idicd where ph.idkhambenh= " + idkhoachinh + "";
        DataTable dtPh = DataAcess.Connect.GetTable(sql);
        if (dtPh != null && dtPh.Rows.Count > 0)
        {
            for (int i = 0; i < dtPh.Rows.Count; i++)
            {
                string idchandoan = dtPh.Rows[i]["idicd"].ToString();
                string machandoan = dtPh.Rows[i]["maicd"].ToString();
                string tenchandoan = dtPh.Rows[i]["mota"].ToString();
                htmlPH += @"<tr><td style='cursor:pointer'>X</td><td><input type='hidden' id='idchandoanicd10_" + (i + 1) + "' value='" + idchandoan + "' />" + machandoan + "</td><td>" + tenchandoan + "</td></tr>";// onclick='javascript:document.getElementById('chandoanicd10_1').deleteRow(this.parentNode.rowIndex);'
            }
        }
        htmlPH += @"</table>";
        Response.Clear();
        Response.Write(htmlPH);
    }
    private void NVK_idICDCapCuusearchMaICD()
    {
        string MaICD = Request.QueryString["q"].ToString();
        string sqlICD = @"select top 10 idicd,mota,MaICD from chandoanicd
            WHERE MaICD like N'%" + MaICD + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlICD);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void NVK_idICDCapCuusearchMoTa()
    {
        string MoTaICD = Request.QueryString["q"].ToString();
        string sqlICD = @"select top 10 idicd,mota,MaICD from chandoanicd
            WHERE mota like N'%" + MoTaICD + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlICD);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void NVK_ShowDanhSachGiuongChon()
    {
        string list_id_giuong = Request.QueryString["ListIdGiuong"];
        string id_giuong = Request.QueryString["idGiuong"];
        string tinh_trang_check = Request.QueryString["tinhtrangCheck"];
        string ListResultIdG = "";
        string htmlDanhSachGiuong = "Danh sách";
        #region Cập nhật list idgiuong
        if (tinh_trang_check.Equals("0"))
        {
            string[] arrGiuong = list_id_giuong.TrimStart(',').TrimEnd(',').Split(',');
            for (int i = 0; i < arrGiuong.Length; i++)
            {
                if (arrGiuong[i] == id_giuong)
                    continue;
                else
                    ListResultIdG += arrGiuong[i] + ",";
            }
            ListResultIdG = ListResultIdG.TrimEnd(',');
        }
        else
        {
            ListResultIdG = list_id_giuong.TrimStart(',').TrimEnd(',') + "," + id_giuong;
            ListResultIdG = ListResultIdG.TrimStart(',');
        }
        #endregion
        #region htmlDanhSachGiuong được chọn
        if (ListResultIdG == "") ListResultIdG = "0";
        string sqlGiuong = @"select stt=row_number()over(order by tenphong),Giuongid,Giuongcode,tenphong,tengiuong='- '+Giuongcode+' ('+tenphong+')' from kb_giuong g left join kb_phong p on g.idphong=p.id where g.Giuongid in (" + ListResultIdG + ") order by tenphong";
        DataTable dtGiuong = DataAcess.Connect.GetTable(sqlGiuong);
        if (dtGiuong.Rows.Count > 0)
        {
            htmlDanhSachGiuong = NVK_GetTableGiuongBaoCao(dtGiuong);
        }
        else
            htmlDanhSachGiuong = "CHƯA MỘT GIƯỜNG NÀO ĐƯỢC CHỌN !";
        #endregion
        Response.Clear();
        Response.Write(ListResultIdG + "@~@" + htmlDanhSachGiuong);

    }
    private string NVK_GetTableGiuongBaoCao(DataTable dt)
    {
        string html = "";//DANH SÁCH GIƯỜNG ĐÃ CHỌN <br/>
        int SoDong = dt.Rows.Count / 2;
        html += "<table class='jtable' id=\"gridFather\">";
        html += "<tr>";
        #region Cột 1
        html += "<td>";
        html += "<table class='jtable' id=\"gridTableCot1\">";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Tên giường</th>";
        html += "<th>Phòng</th>";
        html += "</tr>";

        for (int i = 0; i < SoDong; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1) + "</td>";
            html += "<td><a onclick='xoaGiuongTable(" + dt.Rows[i]["Giuongid"] + ")'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td>" + dt.Rows[i]["Giuongcode"] + "</td>";
            html += "<td>" + dt.Rows[i]["tenphong"] + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        html += "</td>";
        #endregion
        #region Cột 2
        html += "<td>";
        html += "<table class='jtable' id=\"gridTableCot2\">";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Tên giường</th>";
        html += "<th>Phòng</th>";
        html += "</tr>";

        for (int i = SoDong; i < dt.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1) + "</td>";
            html += "<td><a onclick='xoaGiuongTable(" + dt.Rows[i]["Giuongid"] + ")'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td>" + dt.Rows[i]["Giuongcode"] + "</td>";
            html += "<td>" + dt.Rows[i]["tenphong"] + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        html += "</td>";
        #endregion
        html += "</tr>";
        html += "</table>";
        html += @"<input type='button' value='Mới' id='btnClearCTG'  onclick='ClearDanhSachGiuong();'/>";
        return html;
    }
    private void NVK_getGiuongMotPhong()
    {
        string list_id_giuong = Request.QueryString["ListIdGiuong"];
        string idPhong = Request.QueryString["idphong"];
        string htmlGiuong = "";
        string sql = "select Giuongid,Giuongcode,tenphong from kb_giuong g left join kb_phong p on g.idphong=p.id where g.idphong=" + idPhong;
        DataTable dtGiuongPhong = DataAcess.Connect.GetTable(sql);
        if (dtGiuongPhong != null && dtGiuongPhong.Rows.Count > 0)
        {
            string[] arrGiuong = list_id_giuong.TrimStart(',').TrimEnd(',').Split(',');
            htmlGiuong = "DANH SÁCH GIƯỜNG PHÒNG \"" + dtGiuongPhong.Rows[0]["tenphong"].ToString() + "\":  <br />";
            for (int i = 0; i < dtGiuongPhong.Rows.Count; i++)
            {
                string check = "";
                for (int j = 0; j < arrGiuong.Length; j++)
                {
                    if (arrGiuong[j] == dtGiuongPhong.Rows[i]["giuongid"].ToString())
                    {
                        check = "Checked='true'"; break;
                    }
                }
                htmlGiuong += "<input type='checkbox'  onclick='setCheckGiuong(this)'  name='nhomCheckbox' " + check + " id='" + dtGiuongPhong.Rows[i]["giuongid"] + "' value='" + dtGiuongPhong.Rows[i]["giuongid"] + "'/>" + dtGiuongPhong.Rows[i]["Giuongcode"] + " <br />";
            }
            htmlGiuong += "<br /><input type='button' value='Đóng' id='btndongCTG'  onclick='CloseDivGiuong();'/>";
        }
        Response.Clear();
        Response.Write(htmlGiuong);
        return;
    }
    private void NVK_getPhongBNMotNgay()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idctdkk = Request.QueryString["idctdkk"];
        string idkhoa = Request.QueryString["idkhoa"];
        string ngay = Request.QueryString["ngay"];
        string sql = @"select idnoitru,idgiuong,tengiuong=isnull((select giuongcode+' - '+isnull(tenphong,'')+' - '+isnull(k.tenphongkhambenh,'') from kb_giuong g left join kb_phong p on g.idphong=p.id left join banggiadichvu bg on p.dichvukcb=bg.idbanggiadichvu left join phongkhambenh k on bg.idphongkhambenh=k.idphongkhambenh where g.giuongid=nt.idgiuong),'')
,isnull(convert(int,ischonngaysau),0) as ischon
         from benhnhannoitru nt where idnoitru=
        isnull((select top 1 idnoitru from benhnhannoitru where idchitietdangkykham=" + idctdkk + @"
            and ngayvaovien < dateadd(dd,0,'" + StaticData.CheckDate(ngay) + @"')
        order by ngayvaovien desc
        ),0)
        union all
        select idnoitru,idgiuong,tengiuong=isnull((select giuongcode+' - '+isnull(tenphong,'')+' - '+isnull(k.tenphongkhambenh,'') from kb_giuong g left join kb_phong p on g.idphong=p.id left join banggiadichvu bg on p.dichvukcb=bg.idbanggiadichvu left join phongkhambenh k on bg.idphongkhambenh=k.idphongkhambenh where g.giuongid=nt.idgiuong),'')
,isnull(convert(int,ischontrongngay),0) as ischon
         from benhnhannoitru nt where idchitietdangkykham=" + idctdkk + @" and convert(varchar(10),ngayvaovien,103)='" + ngay + @"'

-- Kết hợp giường bênh cấp cứu 
        union all
        select idnoitru=idgiuong,idgiuong=IDgiuongxet,tengiuong=isnull((select giuongcode+' - '+isnull(tenphong,'')+' - '+isnull(k.tenphongkhambenh,'') from kb_giuong g left join kb_phong p on g.idphong=p.id left join banggiadichvu bg on p.dichvukcb=bg.idbanggiadichvu left join phongkhambenh k on bg.idphongkhambenh=k.idphongkhambenh where g.giuongid=nt.idgiuongxet),'')
,isnull(convert(int,ischonngaysau),0) as ischon
         from kb_giuongphieuthanhtoan nt where IDgiuong=
        isnull((select top 1 IDgiuong from kb_giuongphieuthanhtoan where idchitietdangkykham=" + idctdkk + @"
				and ngayxetgiuong < dateadd(dd,0,'" + StaticData.CheckDate(ngay) + @"')
        order by ngayxetgiuong desc
        ),0)
        union all
        select idnoitru=idgiuong,idgiuong=IDgiuongxet,tengiuong=isnull((select giuongcode+' - '+isnull(tenphong,'')+' - '+isnull(k.tenphongkhambenh,'') from kb_giuong g left join kb_phong p on g.idphong=p.id left join banggiadichvu bg on p.dichvukcb=bg.idbanggiadichvu left join phongkhambenh k on bg.idphongkhambenh=k.idphongkhambenh where g.giuongid=nt.idgiuongxet),'')
,isnull(convert(int,ischontrongngay),0) as ischon
         from kb_giuongphieuthanhtoan nt where idchitietdangkykham=" + idctdkk + @" and convert(varchar(10),ngayxetgiuong,103)='" + ngay + @"'
        ";
        string htmlGiuong = "";
        sql = "select * from dbo.NVK_ListGiuongBN_Ngay(" + idctdkk + ",'" + StaticData.CheckDate(ngay) + "')";
        DataTable dtGiuongNgay = DataAcess.Connect.GetTable(sql);
        if (dtGiuongNgay != null && dtGiuongNgay.Rows.Count > 0)
        {
            htmlGiuong = "CHI TIẾT GIƯỜNG NGÀY " + ngay + ":  <br />";
            for (int i = 0; i < dtGiuongNgay.Rows.Count; i++)
            {
                string check = (dtGiuongNgay.Rows[i]["ischon"].ToString() == "1" ? "Checked" : "");
                htmlGiuong += "" + dtGiuongNgay.Rows[i]["tengiuong"] + "<input type='radio'  name='nhomRadio' " + check + " id='rdGiuong_" + i + "' value='" + dtGiuongNgay.Rows[i]["idnoitru"] + "'/> <br />";
            }
            //htmlGiuong += "Giường ajax 1 <input type='radio'  name='nhomRadio' id='rdGiuong1' value='Giường 1'/>";
            //htmlGiuong += "Giường ajax 2 <input type='radio'  name='nhomRadio' id='rdGiuong2' value='Giường 2'/>";
            //htmlGiuong += "Giường 3 <input type='radio'  name='nhomRadio' id='rdGiuong3' value='Giường 3'/>";
            htmlGiuong += "<br /><input type='button' value='Lưu'  onclick=\"LuuChonGiuong(" + idbenhnhan + "," + idctdkk + "," + idkhoa + ",'" + ngay + "'," + dtGiuongNgay.Rows.Count + ");\"/> <input type='button' value='Đóng' id='btndongCTG'  onclick='CloseDivGiuong();'/>";
        }// style='background-color:white;color:Black'
        Response.Clear();
        Response.Write(htmlGiuong);
        return;
    }
    private void NVK_saveChonGiuongNgay()
    {
        bool value = false;
        string idctdkk = Request.QueryString["idctdkk"];
        string ngay = Request.QueryString["ngay"];
        string idnoitru = Request.QueryString["idnoitru"];
        //string sql = "select a= dbo.NVK_isNgayTinhGiuongCC("+idctdkk+",'"+StaticData.CheckDate(ngay)+"')";
        //DataTable dtIsGiuongCC = DataAcess.Connect.GetTable(sql);
        //if (dtIsGiuongCC.Rows[0]["a"].ToString() != "0")
        DataTable dtBKG = DataAcess.Connect.GetTable("select * from kb_giuongphieuthanhtoan where idchitietdangkykham=" + idctdkk + " and convert(varchar(10),ngayxetgiuong,103)='" + ngay + "' and IDgiuong=" + idnoitru);
        if (dtBKG != null && dtBKG.Rows.Count > 0)
            value = StaticData.NVK_CapNhatTinhTrangGiuong(ngay, idctdkk, "0", idnoitru);
        else
            value = StaticData.NVK_CapNhatTinhTrangGiuong(ngay, idctdkk, idnoitru, "0");
        string htmlTableGiuong = "0";
        if (value)
        {
            //            string sqlChiTiet = @"select distinct *,ngay1=convert(varchar(10),ngay,103)+' '+convert(varchar(5),ngay,108)
            //            ,DenNgay1=convert(varchar(10),denngay,103)+' '+convert(varchar(5),denngay,108) from [dbo].[NVK_TableKetQuaGiuong](" + idctdkk + ") order by ngay";
            //            DataTable dt = DataAcess.Connect.GetTable(sqlChiTiet);
            //            htmlTableGiuong = GetTabletienGiuong(dt);
            htmlTableGiuong = "1";
        }
        Response.Clear();
        Response.Write(htmlTableGiuong);
    }
    private string GetTabletienGiuong(DataTable dt)
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
                html += "<td>" + (i + 1) + "</td>";
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
                    <input mkv='true' id='idtien_" + (i + 3) + "' type='hidden' value='" + dt.Rows[i]["thanhtien"] + @"'/>
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
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        return html;
    }
    private void luuTableGiuongNoiTru()
    {
        try
        {
            string idkhoa = Request.QueryString["idkhoa"];
            string idnoitru = Request.QueryString["idkhoachinh"];
            string idgiuong = Request.QueryString["IdGiuong"];
            string IdPhongNoiTru = "0";
            DataTable dtPhong = DataAcess.Connect.GetTable("select idphong from kb_giuong where giuongid=" + Request.QueryString["IdGiuong"]);
            if (dtPhong != null && dtPhong.Rows.Count > 0)
                IdPhongNoiTru = dtPhong.Rows[0]["idphong"].ToString();
            string GiaGiuong = Request.QueryString["dongia"].Replace(",", "");
            string SoNgay = Request.QueryString["songay"].Replace(",", "");
            if (GiaGiuong == "") GiaGiuong = "0";
            string sqlUpdate = @"update benhnhannoitru set IdGiuong=" + idgiuong + ",IdPhongNoiTru=" + IdPhongNoiTru + ",GiaGiuong=" + GiaGiuong + ",songay=" + SoNgay + " where idnoitru=" + idnoitru + "";
            //string sqlIsKB_PTT = "select * from kb_giuongphieuthanhtoan where IDGiuong=" + idnoitru + "";
            //DataTable dtG_PTT = DataAcess.Connect.GetTable(sqlIsKB_PTT);
            //if(idkhoa.Equals("15") && dtG_PTT != null && dtG_PTT.Rows.Count>0)
            //    sqlUpdate = @"update kb_giuongphieuthanhtoan set idgiuongxet=" + idgiuong + ",ThanhTien=" + GiaGiuong + ",songay=" + SoNgay + " where IDGiuong=" + idnoitru + "";
            bool kt = DataAcess.Connect.ExecSQL(sqlUpdate);
            if (kt)
            {
                Response.Clear(); Response.Write(idnoitru);
                return;
            }
        }
        catch (Exception ex)
        { }
        Response.StatusCode = 500;
    }
    private void xuatkho()
    {
        string idkhambenh = Request.QueryString["idkhoachinh"];
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string iddieuduong = Request.QueryString["iddieuduong"];
        string sqlTinhTrang = @"
                select tinhtrang=
		                case when (  EXISTS (SELECT idchitietbenhnhantoathuoc FROM NVK_Thuoc_ChiTietYCTra_bntt WHERE isnull(isDaTra,0)=1 and idchitietbenhnhantoathuoc in
				                (select idchitietbenhnhantoathuoc from chitietbenhnhantoathuoc where idkhambenh='" + idkhambenh + @"')
			                  ))
				                 then  5 -- đã trả và đã nhận (không được sửa nữa)
		                when (  EXISTS (SELECT idchitietbenhnhantoathuoc FROM NVK_Thuoc_ChiTietYCTra_bntt WHERE isnull(isDaTra,0)=0 and idchitietbenhnhantoathuoc in
				                (select idchitietbenhnhantoathuoc from chitietbenhnhantoathuoc where idkhambenh='" + idkhambenh + @"')
			                  ))
				                 then  4 -- đã yêu cầu và chưa duyệt nhận (không được sửa nữa)
		                when (  EXISTS (SELECT ct.idphieuxuat FROM chitietphieuxuatkho
				                ct inner join phieuxuatkho p on p.idphieuxuat=ct.idphieuxuat and p.idkho=isnull((select top 1 paravalue from kb_parameter where paraname = N'nvk_idKhoDuoc'),4)
		                 WHERE idchitietbenhnhantoathuoc in
				                (select idchitietbenhnhantoathuoc from chitietbenhnhantoathuoc where idkhambenh='" + idkhambenh + @"' )
			                  ))
				                 then  3 -- đã duyệt (không được sửa nữa)
		                when (  EXISTS (SELECT idchitietbenhnhantoathuoc from NVK_Thuoc_ChiTietYCXuat where idchitietbenhnhantoathuoc in
				                (select idchitietbenhnhantoathuoc from chitietbenhnhantoathuoc where idkhambenh='" + idkhambenh + @"')
			                  ))
				                 then  2 -- đã yêu cầu và chưa được duyệt
		                else 1 -- chưa yêu cầu
		                END";
        //DataTable dtTT = DataAcess.Connect.GetTable(sqlTinhTrang);
        //if(dtTT != null && dtTT.Rows.Count>0 && dtTT.Rows[0][0].ToString().Equals("1"))
        XuatKhoTuToaThuoc.XuatKhoTheoToa_1907(idbenhnhan, idkhambenh, iddieuduong);
    }


    private void ChonCLS()
    {
        bool dautien = (Request.QueryString["dautien"] != null ? true : false);
        string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");

        string IdKhambenh = (Request.QueryString["IdKhambenh"] != null ? Request.QueryString["IdKhambenh"].ToString() : "");
        string LoaiBN = (Request.QueryString["LoaiBN"] != null ? Request.QueryString["LoaiBN"].ToString() : "");
        string DonGiaName = "BNPhaiTra";
        string listidcanlamsan = Request.QueryString["listID"];
        string[] arridcls = listidcanlamsan.Split(',');
        //Khoe 2007
        string IdKhoaKhoe = "0";
        string sqlloaicls = "";
        if (Request.QueryString["loai"] != null)
        {
            if (Request.QueryString["loai"] == "cls")
            {
                sqlloaicls += " and  isnull(isdvkt,0)=0";
            }
            else if (Request.QueryString["loai"] == "dichvu")
            {
                sqlloaicls += " and isnull(isdvkt,0)=1";
            }
        }
        if (dautien == true && listidcanlamsan != "" && arridcls.Length > 1 && listidcanlamsan != ",")
            IdKhoaKhoe = DataAcess.Connect.GetTable("select idphongkhambenh from banggiadichvu where idbanggiadichvu=" + arridcls[0]).Rows[0][0].ToString() + sqlloaicls;
        listidcanlamsan = listidcanlamsan.TrimEnd(',');
        string swhere = "";
        int idpkb = StaticData.ParseInt(Request.QueryString["idpkb"]);
        if (IdKhoaKhoe != "0") idpkb = StaticData.ParseInt(IdKhoaKhoe);
        //string tenNhom = Request.QueryString["tN"];
        if (idpkb == 0)
        {

        }
        else
        {
            swhere = " and Bg.idphongkhambenh=" + idpkb + " ";
        }
        string html = "";
        string selectIDDVNhomCLS = "select tenNhom,dbo.[GetIdBanggiaDVByNhomCLS](n.nhomId) as idDV from KB_NhomCLS n where status='true' order by n.tenNhom";
        DataTable arrIDDVNhomCLS = DataAcess.Connect.GetTable(selectIDDVNhomCLS);
        html += "Tên nhóm CLS :";
        if (arrIDDVNhomCLS.Rows.Count != 0 && arrIDDVNhomCLS != null)
        {

            for (int i = 0; i < arrIDDVNhomCLS.Rows.Count; i++)
            {
                html += "<input  type=\"button\" style=\"cusor:pointer\" onclick=\"ChonCLS(this,'" + arrIDDVNhomCLS.Rows[i]["idDV"].ToString() + "',null" + (Request.QueryString["loai"] != null ? ",'" + Request.QueryString["loai"] + "'" : "") + ",'" + LoaiBN + "');\" name=\"rbnSearchNhom\" value=\"" + arrIDDVNhomCLS.Rows[i]["tenNhom"].ToString() + "\"/>";
                html += "&nbsp;";
            }
            html += "<br/>";
        }

        string selectTenPhong = "select tenphongkhambenh,pkb.idphongkhambenh from phongkhambenh pkb where loaiphong=1 " + (Request.QueryString["loai"] == "cls" ? " and dbo.HS_HAVE_CLS(idphongkhambenh)=1" : " and dbo.HS_HAVE_DVKT(idphongkhambenh)=1") + "  order by pkb.idphongkhambenh";
        DataTable arrT = DataAcess.Connect.GetTable(selectTenPhong);
        html += "Tên Khoa/Phòng:";
        for (int i = 0; i < arrT.Rows.Count; i++)
        {

            html += "<input  style=\"width:auto\" type=\"button\" onclick=\"ChonCLS(this,null,'" + arrT.Rows[i]["idphongkhambenh"].ToString() + "'" + (Request.QueryString["loai"] != null ? ",'" + Request.QueryString["loai"] + "'" : "") + ",'" + LoaiBN + "');\" name=\"rbnSearch\" value=\"" + arrT.Rows[i]["tenphongkhambenh"].ToString() + "\"/>";

        }

        //}

        html += "<table class='jtable' border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\">";


        //string sqlSelectTenNhom = ""
        //                            + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh" + "\r\n"
        //                            + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
        //                            + " where  bg.idphongkhambenh= " + idpkb + " AND   loaiphong=1 " + swhere + " " + "\r\n";
        string sqlSelectTenNhom = ""
                                   + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh,isnull(TTUUCapCuu_Nhom,1000) as TTUU" + "\r\n"
                                   + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
                                   + " where  bg.idphongkhambenh= " + idpkb + " AND   loaiphong=1 " + swhere + " " + "\r\n"
                                   + (Request.QueryString["loai"] == "cls" ? " and ISNULL(ISDVKT,0)=0" : " and ISNULL(ISDVKT,0)=1")
       + " --and isnull(TTUUCapCuu_Nhom,1000)<>1000 " + "\r\n"
       + " order by TTUU    " + "\r\n";


        DataTable arrT1 = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" >";
        int mkvclick = 0;
        if (arrT1 != null && arrT1.Rows.Count != 0)
        {
            if (arrT1.Rows.Count >= 4)
            {
                string tenPKB = arrT1.Rows[0]["tenphongkhambenh"].ToString();
                string tenN = "";

                for (int i = 0; i < arrT1.Rows.Count; i++)
                {
                    tenN = tenN + arrT1.Rows[i]["tennhom"].ToString() + ",";
                    string t = arrT1.Rows[i]["tennhom"].ToString();
                    string tNext = "";
                    if (i < arrT1.Rows.Count - 1)
                    {
                        tNext = arrT1.Rows[i + 1]["tennhom"].ToString();
                    }
                    else
                        tNext = arrT1.Rows[i]["tennhom"].ToString();
                    html += "<td align=\"left\" style=\"width:20%\" class=\"ptext\" >";

                    html += "<a style=\"cusor:pointer\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";
                    if (((i + 1) % 4) == 0)
                    {
                        html += "</tr>";
                    }


                }
                tenN = tenN.TrimEnd(',');
                //if (swhere != "")
                //{
                //    html += "<td align=\"left\"  style=\"width:30%\" class=\"ptext\" >";
                //    html += "<a href=\"#\" style=\"color:green\" onclick=\"setAllDV('" + idDVPKB + "','" + tenN + "'," + idpkb + ");\" name=\"rbnSearchAll\" >" + tenPKB + " Tổng hợp" + "</a>";
                //    html += "</td>";
                //}
            }
            else
            {
                string tenPKB = arrT1.Rows[0]["tenphongkhambenh"].ToString();
                string tenN = "";
                for (int i = 0; i < arrT1.Rows.Count; i++)
                {
                    tenN = tenN + arrT1.Rows[i]["tennhom"].ToString() + ",";
                    string t = arrT1.Rows[i]["tennhom"].ToString();
                    string tNext = "";
                    if (i < arrT1.Rows.Count - 1)
                    {
                        tNext = arrT1.Rows[i + 1]["tennhom"].ToString();
                    }
                    else
                        tNext = arrT1.Rows[i]["tennhom"].ToString();
                    html += "<td align=\"left\"  style=\"width:30%\" class=\"ptext\" >";

                    html += "<a style=\"cusor:pointer\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";

                }
                tenN = tenN.TrimEnd(',');
                //if (swhere != "")
                //{
                //    html += "<td align=\"left\"  style=\"width:30%\" class=\"ptext\" >";
                //    html += "<a href=\"#\" style=\"color:green\" onclick=\"setAllDV('" + idDVPKB + "','" + tenN + "'," + idpkb + ");\" name=\"rbnSearchAll\" >" + tenPKB + " Tổng hợp" + "</a>";
                //    html += "</td>";
                //}
            }
        }

        html += "</tr>";



        html += "</table>";


        string idDVCLSByTN = "";

        DataTable arr = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        int mkv = 0;
        foreach (DataRow h in arr.Rows)
        {
            html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" class='jtable'>";
            string t = h["tennhom"].ToString();
            string idBNinSelect = IdBenhNhan != "" ? "," + IdBenhNhan : ",0";
            //string sqlSelectIDDVByTN = ""
            //    + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.GiaBH,A.PhuThuBH,BNPhaiTra=DBO.KB_GETSOTIEN_BNTra(a.idbanggiadichvu" + idBNinSelect + ") " + "\r\n"
            //    + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "'"
            //    + " and a.idphongkhambenh='" + idpkb + "'"
            //    + " order by A.tendichvu" + "\r\n"
            //    + "  " + "\r\n";
            string sqlSelectIDDVByTN = ""
                + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.GiaBH,A.PhuThuBH,BNPhaiTra=" + (LoaiBN == "1" ? "A.BHTRA" : "A.GIADICHVU") + "\r\n"
                + " ,isnull(TTUTCapCuu_DV,1000) as TTUT" + "\r\n"
                + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "'"
                + " and a.idphongkhambenh='" + idpkb + "'"
               + (Request.QueryString["loai"] == "cls" ? " and ISNULL(ISDVKT,0)=0" : " and ISNULL(ISDVKT,0)=1")
                + " --and isnull(TTUTCapCuu_DV,1000)<>1000 " + "\r\n"
            + " order by TTUT, A.tendichvu " + "\r\n"
                + "  " + "\r\n";
            DataTable arrIDDVByTN = DataAcess.Connect.GetTable(sqlSelectIDDVByTN);
            foreach (DataRow idDVByTN in arrIDDVByTN.Rows)
            {
                idDVCLSByTN = idDVCLSByTN + idDVByTN["idbanggiadichvu"].ToString() + ",";
            }
            html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" width=\"100%\">";
            string t1 = Request.QueryString["checkTN"];
            if (Request.QueryString["checkTN"] != null && Request.QueryString["checkTN"] != "")
            {

                int dk = 0;
                string[] arrTenNhom = t1.Split(',');
                for (int i = 0; i < arrTenNhom.Length; i++)
                {
                    string tam = arrTenNhom[i].ToString();
                    if (t == tam)
                    {
                        html += "<th align=\"left\" width='10px'>&nbsp;<input checked id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
                        dk = 1;
                        break;
                    }
                    else
                    {
                        dk = 0;
                    }
                }
                if (dk == 0)
                {
                    html += "<th align=\"left\" width='10px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
                }


            }
            else
            {
                html += "<th align=\"right\" width='10px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
            }
            html += "<th  align=\"left\" width=\"70%\" class=\"ptext\" ><input style=\"width:auto\" type=\"button\" id=\"mkv" + mkv + "\" style=\"font-weight:bold\" value=\"" + t + "\"/></th>";
            html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Đơn giá</th>";
            html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;DmBH?</th>";
            //html += "<td  width=\"10%\" align=\"center\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;forecolor=\"Blue\";\" class=\"ptext\" >&nbsp;Số lượng</td>";
            html += "</tr>";
            mkv++;
            //string sqlSelectTenDV = ""
            //  + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.GiaBH,A.PhuThuBH ,BNPhaiTra=DBO.KB_GETSOTIEN_BNTra(a.idbanggiadichvu," + IdBenhNhan + ")" + "\r\n"
            //  + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "'"
            //  + " and a.idphongkhambenh='" + idpkb + "'"
            //  + " order by A.tendichvu" + "\r\n"
            //  + "  " + "\r\n";
            string sqlSelectTenDV = @"
               select A.idbanggiadichvu,A.tendichvu,isnull(A.giadichvu,0) as giadichvu,isnull(A.GiaBH,0) as GiaBH,isnull(A.PhuThuBH,0)PhuThuBH ,BNPhaiTra=" + (LoaiBN == "1" ? "A.BHTRA" : "A.GIADICHVU") + @"
              ,isnull(TTUTCapCuu_DV,1000) as TTUT
              , isTrongDM= convert(int,isnull(a.IsSuDungChoBH,0))
              from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + @"'
              and a.idphongkhambenh='" + idpkb + "'"
              + (Request.QueryString["loai"] == "cls" ? " and ISNULL(ISDVKT,0)=0" : " and ISNULL(ISDVKT,0)=1") + @"
              --and isnull(TTUTCapCuu_DV,1000)<>1000
               order by TTUT, A.tendichvu ";
            idDVCLSByTN = "";
            DataTable arrTenDV = DataAcess.Connect.GetTable(sqlSelectTenDV);
            {
                if (arrTenDV.Rows.Count != 0)
                {
                    foreach (DataRow tenDV in arrTenDV.Rows)
                    {


                        int dk = 0;
                        html += "<tr width=\"100%\">";
                        string id = tenDV["idbanggiadichvu"].ToString();
                        for (int i = 0; i < arridcls.Length; i++)
                        {
                            string tam = arridcls[i].ToString();
                            if (id == tam)
                            {
                                html += "<td align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" checked  type=\"checkbox\" /></td>";
                                dk = 1;
                                break;
                            }
                            else
                            {
                                dk = 0;
                            }
                        }
                        if (dk == 1)
                        {

                        }
                        else
                        {
                            html += "<td align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" type=\"checkbox\" /></td>";
                        }
                        string nvk_style = "style='color:Blue;font-weight:bold;'";
                        if (tenDV["isTrongDM"].ToString().Equals("1"))
                            nvk_style = "";
                        html += "<td " + nvk_style + " width=\"70%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" align='left'>&nbsp;" + tenDV["tendichvu"] + "</td>";
                        html += "<td " + nvk_style + " width=\"10%\" class=\"ptext\" align = \"left\" style = \"padding-right:20px\">" + StaticData.FormatNumber(tenDV[DonGiaName], false).ToString() + "</td>";
                        html += "<td " + nvk_style + " width=\"10%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" align='left'>&nbsp;" + (tenDV["isTrongDM"].ToString().Equals("1") ? "BH" : "DV") + "</td>";
                        //html += "<td width=\"10%\" align=\"center\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;1</td>";
                        html += "</tr>";
                    }

                }
            }
            html += "</table>";
        }

        Response.Clear();
        Response.Write(html);
    }

    private void Loadsauhuongdieutri()
    {
        string html = "";
        string huongdieutri = Request.QueryString["huongdieutri"];

        if (huongdieutri == "4")
        {

            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("denbv") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='ghichuhuongdieutri' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_ghichuhuongdieutri' type='text' onfocus='chuyenphim(this);ghichuhuongdieutriSearch(this);'" + "\r\n"
    + "                         class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
        }
        else if (huongdieutri == "12" || huongdieutri == "1" || huongdieutri == "18")
        {

            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("khoakhambenh") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='khoakhambenh' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_khoakhambenh' type='text' onfocus='chuyenphim(this);khoakhambenhSearch(this,\"" + huongdieutri + "\");'" + "\r\n"
    + "                         class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("dichvu") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='idDVPhongChuyenDen' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_idDVPhongChuyenDen' type='text' onfocus='chuyenphim(this);banggiadichvuSearch(this);'" + "\r\n"
    + "                         class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("phong") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='idPhongChuyenDen' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_idPhongChuyenDen' type='text' onfocus='chuyenphim(this);phongkhambenhSearch(this);' class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
        }
        else if (huongdieutri == "8")
        {
            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("khoakhambenh") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='phongkhamchuyenden' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_phongkhamchuyenden' type='text' onfocus='chuyenphim(this);khoakhambenhSearch(this,\"" + huongdieutri + "\");'" + "\r\n"
    + "                         class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
        }
        else
        {

        }
        Response.Clear();
        Response.Write(html);
    }


    private void Setsauhuongdieutri()
    {
        string html = "";
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        string idkhambenhgoc = Request.QueryString["idkhambenhgoc"];
        string dk = "";
        if (!string.IsNullOrEmpty(idkhoachinh))
            dk = " KB.IDKHAMBENH='" + idkhoachinh + "'";
        else
            dk = " KB.IDKHAMBENH='" + idkhambenhgoc + "'";
        DataTable table = DataAcess.Connect.GetTable(@"SELECT top 1 
            KB.*,
            P.TENPHONG AS TENPHONG,
            h.tenhuongdieutri as mkv_huongdieutri,
            bv.tenbenhvien as mkv_ghichuhuongdieutri,
            bg.tendichvu as mkv_idDVPhongChuyenDen
        ,pk.idphongkhambenh,pk.tenphongkhambenh
    ,kb.phongkhamchuyenden,tenphongNT= pk1.tenphongkhambenh
            FROM Khambenh kb 
            LEFT JOIN KB_PHONG P ON P.id=KB.idPhongChuyenDen
            left join kb_huongdieutri h on h.huongdieutriid = kb.huongdieutri
            left join benhvien bv on bv.idbenhvien = kb.ghichuhuongdieutri
            left join banggiadichvu bg on bg.idbanggiadichvu = kb.idDVPhongChuyenDen
        left join phongkhambenh pk on pk.idphongkhambenh=bg.idphongkhambenh
    left join phongkhambenh pk1 on pk1.idphongkhambenh=kb.phongkhamchuyenden
            WHERE " + dk);
        if (table.Rows.Count > 0)
        {
            string huongdieutri = table.Rows[0]["huongdieutri"].ToString();
            if (huongdieutri == "4")
            {

                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("denbv") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"ghichuhuongdieutri\" type=\"hidden\" value='" + table.Rows[0]["ghichuhuongdieutri"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_ghichuhuongdieutri\" type=\"text\" onfocus=\"chuyenphim(this);ghichuhuongdieutriSearch(this);\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" value='" + table.Rows[0]["mkv_ghichuhuongdieutri"] + "'/>" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
            }
            else if (huongdieutri == "12" || huongdieutri == "1" || huongdieutri == "18")
            {
                string dk2 = "";
                if (Request.QueryString["huongdieutri"] == "1")
                    dk2 = " and idphongkhambenh <> 15";
                else
                    dk2 = " and idphongkhambenh = 15";
                DataTable tablekhoakhambenh = DataAcess.Connect.GetTable("SELECT * FROM phongkhambenh where loaiphong=0 " + dk2);

                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("khoakhambenh") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"khoakhambenh\" type=\"hidden\" value='" + table.Rows[0]["IDPHONGKHAMBENH"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_khoakhambenh\" type=\"text\" value='" + table.Rows[0]["tenphongkhambenh"] + "' onfocus=\"chuyenphim(this);khoakhambenhSearch(this,'" + huongdieutri + "');\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" />" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("dichvu") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"idDVPhongChuyenDen\" type=\"hidden\" value='" + table.Rows[0]["idDVPhongChuyenDen"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_idDVPhongChuyenDen\" type=\"text\" value='" + table.Rows[0]["mkv_idDVPhongChuyenDen"] + "' onfocus=\"chuyenphim(this);banggiadichvuSearch(this);\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" />" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("phong") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"idPhongChuyenDen\" type=\"hidden\" value='" + table.Rows[0]["idPhongChuyenDen"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_idPhongChuyenDen\" type=\"text\" value='" + table.Rows[0]["TENPHONG"] + "' onfocus=\"chuyenphim(this);phongkhambenhSearch(this);\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" />" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
            }
            else if (huongdieutri == "8")
            {
                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("khoakhambenh") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"phongkhamchuyenden\" type=\"hidden\" value='" + table.Rows[0]["phongkhamchuyenden"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_phongkhamchuyenden\" type=\"text\" value='" + table.Rows[0]["tenphongNT"] + "' onfocus=\"chuyenphim(this);khoakhambenhSearch(this,'" + huongdieutri + "');\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" />" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
            }
            else
            {

            }
        }
        Response.Clear();
        Response.Write(html);
    }
    private void SetBacSiChiDinh()
    {
        string html = "";
        string idbacsi = "";
        string TenBacSi = "";
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        string idctdkk = Request.QueryString["idctdkk"];
        string idkhoa = Request.QueryString["idkhoa"];
        #region theo phiếu khám đã có ( mới nhất tại khoa nếu chua có idkhambenh)
        string sql = "";
        if (!idkhoachinh.Equals("0") && !idkhoachinh.Equals(""))
            sql = @" select top 1 bs.idbacsi,bs.tenbacsi from khambenh kb inner join bacsi bs on kb.idbacsi=bs.idbacsi where kb.idkhambenh='" + idkhoachinh + "' ";
        else
            sql = @" select top 1 bs.idbacsi,bs.tenbacsi from khambenh kb inner join bacsi bs on kb.idbacsi=bs.idbacsi where kb.idchitietdangkykham='" + idctdkk + "' and kb.idphongkhambenh ='" + idkhoa + "' order by kb.idkhambenh desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        #endregion
        if (table != null && table.Rows.Count > 0)
        { idbacsi = table.Rows[0]["idbacsi"].ToString(); TenBacSi = table.Rows[0]["tenbacsi"].ToString(); }
        else if (!idkhoachinh.Equals("0") && !idkhoachinh.Equals(""))// nếu chưa có phiếu khám mới nào tại khoa
        {
            #region theo thông tin nhập khoa
            sql = @"select top 1 bs.idbacsi,bs.tenbacsi from benhnhannoitru nt inner join bacsi bs on nt.idbacsiNhap=bs.idbacsi where nt.idchitietdangkykham='" + idctdkk + "' and nt.IdKhoaNoiTru ='" + idkhoa + "' order by nt.idnoitru desc";
            table = DataAcess.Connect.GetTable(sql);
            if (table != null && table.Rows.Count > 0)
            { idbacsi = table.Rows[0]["idbacsi"].ToString(); TenBacSi = table.Rows[0]["tenbacsi"].ToString(); }
            #endregion
        }
        html += "<input mkv=\"true\" id=\"idbacsi\" value='" + idbacsi + "' type=\"hidden\" /> " + "\r\n"
                + "<input mkv=\"true\" id=\"mkv_idbacsi\" value='" + TenBacSi + "' type=\"text\" onfocus=\"chuyenphim(this);idbacsisearch(this);\"" + "\r\n"
                  + "  class=\"down_select_hover\" style=\"width: 90%\" />";
        Response.Clear();
        Response.Write(html);
    }

    private void Xoakhambenh()
    {
        try
        {
            DataProcess process = s_khambenh();
            bool ok = process.Delete();
            if (ok)
            {
                DataAcess.Connect.Exec("delete from kb_giuongphieuthanhtoan where idptt = " + process.getData("idkhambenh"));
                Response.Clear(); Response.Write(process.getData("idkhambenh"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void chandoanbandausearch()
    {
        string where = "";
        if (Request.QueryString["loaiicd"].ToString() == "maicd")
        {
            where = " maicd like N'%" + Request.QueryString["q"] + "%'";
        }
        else
        {
            where = " mota like N'%" + Request.QueryString["q"] + "%'";
        }
        DataTable table = DataAcess.Connect.GetTable("SELECT top 20 * FROM chandoanicd where " + where);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + " - " + table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void ghichuhuongdieutriSearch()
    {
        string TenBV = Request.QueryString["q"].ToString();
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM benhvien where tenbenhvien like N'%" + TenBV + "%'");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdDieuDuongsearch()
    {
        string TenDieuDuong = Request.QueryString["q"].ToString();
        DataTable table = DataAcess.Connect.GetTable("select * from nguoidung where nhomid = 7 and tennguoidung like N'%" + TenDieuDuong + "%'");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    //    private void idbacsisearch()
    //    {
    //        string TenBS = Request.QueryString["q"].ToString();
    //        string sqlBS = @"SELECT top 10 
    //            A.IDBACSI AS IDBACSI
    //            ,A.TENBACSI AS TENBACSI
    //            FROM BACSI A
    //            WHERE tenbacsi like N'%" + TenBS + "%'";
    //        DataTable table = DataAcess.Connect.GetTable(sqlBS);
    //        string html = "";
    //        if (table != null)
    //        {
    //            if (table.Rows.Count > 0)
    //            {
    //                for (int i = 0; i < table.Rows.Count; i++)
    //                {

    //                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

    //                }
    //            }
    //        }
    //        Response.Clear(); Response.Write(html);
    //    }
    private void iddieuduongNhapKhoasearch()
    {
        string TenDD = Request.QueryString["q"].ToString();
        string sqlDD = @"select top 10  idnhanvien,tennhanvien,idphongban from nhanvien a
                left join chucvu b on a.idchucvu=b.idchucvu where  (machucvu like N'NHS%'or machucvu like N'DD%' or b.idchucvu=42)
                and tennhanvien like N'%" + TenDD + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlDD);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    //
    private void idkhosearch()
    {
        string TenSearch = Request.QueryString["q"];
        string sqlKho = @"select idkho,tenkho from khothuoc where nvk_loaikho not in(4) and tenkho like N'%" + TenSearch + @"%' and idkhoa =
 (select top 1 phongkhamchuyenden from khambenh where
1=1 and isnull(phongkhamchuyenden,0)<>0 and huongdieutri=8 and( idkhambenh='" + Request.QueryString["idkhambenhgoc"] + "' or idkhambenhgoc='" + Request.QueryString["idkhambenhgoc"] + "' or idkhambenh='" + Request.QueryString["idkhoachinh"] + "' or idkhambenhgoc='" + Request.QueryString["idkhoachinh"] + "'))";
        DataTable table = DataAcess.Connect.GetTable(sqlKho);
        if (table == null || table.Rows.Count == 0)
            table = DataAcess.Connect.GetTable("select idkho,tenkho from khothuoc where idkhoa =3");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    private void idkhosearch_CapCuu()
    {
        //string sqlKho = @"select idkho,tenkho from khothuoc where idkhoa = (select top 1 idphongkhambenh from khambenh where idkhambenh='" + Request.QueryString["idkhambenhgoc"] + "'))";
        string TenSearch = Request.QueryString["q"];//and tenkho like N'%"+TenSearch+"%'
        DataTable table = DataAcess.Connect.GetTable("select idkho,tenkho from khothuoc where idkhoa =15 and nvk_loaikho not in (4)-- (select idphongkhambenh from khambenh where idkhambenh='" + Request.QueryString["idkhambenhgoc"] + "')");
        //DataTable table = DataAcess.Connect.GetTable(sqlKho);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    private void idkhosearch_ChiDinh()
    {
        string TenSearch = Request.QueryString["q"];
        string idkho = "2";
        if (Request.QueryString["IdKhoa"] != null)
        {
            idkho = Request.QueryString["IdKhoa"].ToString();
            //if (idkho.Equals("25") || idkho.Equals("46"))// Phòng tán sỏi || Phòng Hóa Trị
            //    idkho = "2";//Khoa ngoại
        }
        string sqlKho = "select idkho,tenkho,nvk_loaikho=isnull(nvk_loaikho,0) from khothuoc where idkhoa =" + idkho + " and nvk_loaikho not in (4) AND ISNT=1";
        if (Request.QueryString["isDuTruThuoc"] != null && Request.QueryString["isDuTruThuoc"].ToString().Equals("1"))
            sqlKho = "select idkho,tenkho,nvk_loaikho=isnull(nvk_loaikho,0) from khothuoc where idkhoa =" + idkho + " and nvk_loaikho in (3) AND ISNT=1";
        DataTable table = DataAcess.Connect.GetTable(sqlKho);// and tenkho like N'%"+TenSearch+"%'
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void nvk_khotoaxuatviensearch()
    {
        string idkhoa = Request.QueryString["IdKhoa"];
        DataTable table = DataAcess.Connect.GetTable("select idkho,tenkho from khothuoc where 1=1 and (NVK_LOAIKHO=3 AND ISNULL(ISNT,0)=0 AND IDKHOA='" + idkhoa + "' )");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void khoakhambenhSearch()
    {
        string dk = "";
        if (Request.QueryString["huongdieutri"] == "1")
            dk = " and idphongkhambenh <> 15";
        else if (Request.QueryString["huongdieutri"] == "18" || Request.QueryString["huongdieutri"] == "13" || Request.QueryString["huongdieutri"] == "12")
            dk = " and idphongkhambenh = 15";
        else
            dk = " and maphongkhambenh in('02','03','04')";
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM phongkhambenh where loaiphong=0 " + dk);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void banggiadichvuSearch()
    {
        string dk = "";
        if (Request.QueryString["huongdieutri"] == "18")
            dk = " and madichvu in ('3000')";
        else if (Request.QueryString["huongdieutri"] == "8" && Request.QueryString["khoakhambenh"] == "2")//Khoa Ngoại
            dk = " and madichvu  in('3002')";
        else if (Request.QueryString["huongdieutri"] == "8" && Request.QueryString["khoakhambenh"] == "3")//Khoa Sản
            dk = " and madichvu  in('3003')";
        else if (Request.QueryString["huongdieutri"] == "8" && Request.QueryString["khoakhambenh"] == "4")//Khoa Nội
            dk = " and madichvu  in('3004')";
        else
            dk = " and madichvu <> '3000' and madichvu <> '3001'";
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM banggiadichvu where idbanggiadichvu <> 1790 and idphongkhambenh='" + Request.QueryString["khoakhambenh"] + "' " + dk + "");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void phongkhambenhSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM kb_phong where dichvukcb='" + Request.QueryString["banggiadichvu"] + "'");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + " - " + table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    private void idBenhNhansearch()
    {
        DataTable table = DataAcess.Connect.GetTable(@"SELECT top 30 idbenhnhan,tenbenhnhan,mabenhnhan,ngaysinh as namsinh,gioitinh=dbo.getgioitinh(loai),loai
,kb_loaibn.tenloai FROM benhnhan bn left join kb_loaibn on bn.loai=kb_loaibn.id  where  tenbenhnhan like N'%" + Request.QueryString["q"] + @"%'
     and idbenhnhan in(select idbenhnhan from khambenh kb where kb.idbenhnhan=bn.idbenhnhan and kb.idkhambenh in (select idkhambenh from chitietbenhnhantoathuoc where idkhambenh=kb.idkhambenh and soluongtra>0) )");
        string html = "";
        // html = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", ""
        //+ "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
        //+ "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
        //+ "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >Tên bệnh nhân</div>"
        //+ "<div style=\"width:25%;height:30px;color:#000;font-weight:bold;float:left\" >Mã BN</div>"
        //+ "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >Năm sinh</div>"
        //+ "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left;\" >Giới tính</div>"
        //+ "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >Loại khám </div>"
        //+ "</div>", "", "", "", "", "", Environment.NewLine);
        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", "<div>"
        + "<div style=\"width:5%;height:30px;float:left\" >" + (i + 1) + "</div>"
        + "<div style=\"width:30%;height:30px;float:left\" >" + h["tenbenhnhan"] + "</div>"
        + "<div style=\"width:25%;height:30px;float:left\" >" + h["mabenhnhan"] + "</div>"
        + "<div style=\"width:15%;height:30px;float:left\" >" + h["namsinh"] + "</div>"
        + "<div style=\"width:10%;height:30px;float:left\" >" + h["gioitinh"] + "</div>"
        + "<div style=\"width:15%;height:30px;float:left\" >" + h["tenloai"] + "</div>"
         + "</div>", h["idbenhnhan"], h["mabenhnhan"], h["tenbenhnhan"], h["gioitinh"], h["loai"], Environment.NewLine);
        }
        Response.Clear(); Response.Write(html);
    }
    private void idcanlamsansearch()
    {
        string sql = "";
        if (Request.QueryString["loai"] != null)
        {
            if (Request.QueryString["loai"] == "cls")
            {
                sql += " and  isnull(isdvkt,0)=0";
            }
            else if (Request.QueryString["loai"] == "dichvu")
            {
                sql += " and isnull(isdvkt,0)=1";
            }
        }
        string idctdkk = Request.QueryString["idctdkk"];
        string sqlDichVu = @"
    SELECT top 20 idbanggiadichvu,tendichvu,giadichvu
        ,nvk_isBHYT = case when  isnull(bg.IsSuDungChoBH,0)=1 and 
                                isnull(
	                                (select top 1 dk.loaikhamid from dangkykham dk 
											                                inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                                  where ct.idchitietdangkykham ='" + idctdkk + @"'
	                                )
                                    ,0)=1 then 1 else 0 end     
                                , isTrongDM= convert(int,isnull(bg.IsSuDungChoBH,0))
    FROM banggiadichvu BG left join phongkhambenh p on p.idphongkhambenh=bg.idphongkhambenh
     where loaiphong=1 " + sql + " and  tendichvu like N'%" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlDichVu);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string nvk_style = "color:Blue;font:bold;";
                    if (table.Rows[i]["isTrongDM"].ToString().Equals("1"))
                        nvk_style = "";
                    html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", "<div>"
            + "<div style=\"" + nvk_style + "width:80%;height:30px;float:left;\" >" + table.Rows[i]["tendichvu"].ToString() + "</div>"
            + "<div style=\"" + nvk_style + "width:20%;height:30px;float:left;text-align:center;\" >" + (table.Rows[i]["isTrongDM"].ToString().Equals("1") ? "BH" : "DV") + "</div>"
             + "</div>", table.Rows[i]["tendichvu"].ToString(), table.Rows[i]["idbanggiadichvu"].ToString(), table.Rows[i]["giadichvu"].ToString(), table.Rows[i]["nvk_isBHYT"].ToString(), table.Rows[i]["isTrongDM"].ToString(), Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loaithuocidsearch()
    {
        string TenSearch = Request.QueryString["q"];
        DataTable table = DataAcess.Connect.GetTable("SELECT top 20 * FROM thuoc_loaithuoc ");//where tenloai like N'%" + TenSearch+ "%'
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void doituongthuocidsearch()
    {
        string TenSearch = Request.QueryString["q"];
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM Thuoc_DoiTuongThuoc");// where tendoituong like N'%" + TenSearch + "%'
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idGiuongsearch()
    {
        string tenGiuong = Request.QueryString["q"];//IdKhoa_G
        string IdKhoa_G = Request.QueryString["IdKhoa_G"];
        string IdKhoa = Request.QueryString["idkhoa"];
        string loaiBN = Request.QueryString["loaiBN"];

        string sqlGiuong = @"
                SELECT TB.*,nvk_giadichvu=GIADV,nvk_giabaohiem=GIABH
                FROM 
                (
                    select a.idPhong,A.GIUONGID,tenphong,tengiuong=GiuongCode+' - '+b.tenphong,GiuongCode ,TENLOAIGIUONG,
                     BANGGIAGIUONGID= (SELECT TOP 1 BANGGIAGIUONGID FROM HS_banggiagiuong a1
						                     inner join hs_loaigiuong b1 on a1.idloaigiuong=b1.idloaigiuong 
						                     inner join hs_banggiagiuong_lan c1 on a1.banggiaid=c1.banggiaid
						                    where b1.idloaigiuong=a.idloaigiuong order  by c1.tungay desc)
                    from kb_giuong A
                    INNER JOIN KB_PHONG B ON A.IDPHONG=B.ID
                    inner join banggiadichvu C ON B.DICHVUKCB=C.IDBANGGIADICHVU
                    INNER JOIN HS_LOAIGIUONG D ON A.IDLOAIGIUONG=D.IDLOAIGIUONG
                    WHERE C.IDPHONGKHAMBENH='" + IdKhoa_G + "' and giuongcode+' - '+tenphong like N'%" + tenGiuong + @"%'
                ) AS TB
                INNER JOIN hs_banggiagiuong TB2 ON TB.BANGGIAGIUONGID=TB2.BANGGIAGIUONGID";

        DataTable table = DataAcess.Connect.GetTable(sqlGiuong);

        string html = "";
        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", "<div style=\"background-color:#cfcfcf\" >"
        + "<div style=\"width:10%;height:30px;float:left\" >" + (i + 1) + "</div>"
        + "<div style=\"width:30%;height:30px;float:left\" >" + h["GiuongCode"] + "</div>"
        + "<div style=\"width:30%;height:30px;float:left\" >" + h["tenphong"] + "</div>"
        + "<div style=\"width:15%;height:30px;float:left\" >" + StaticData.FormatNumberOption(h["nvk_giadichvu"], ",", ".", false) + "</div>"
        + "<div style=\"width:15%;height:30px;float:left\" >" + StaticData.FormatNumberOption(h["nvk_giabaohiem"], ",", ".", false) + "</div>"
         + "</div>", h["GiuongId"], h["idPhong"], h["idPhong"], h["tengiuong"], h["nvk_giadichvu"], h["nvk_giabaohiem"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void nvk_IdKhoaSearch_2509_sss()
    {
        string tenKhoa = Request.QueryString["q"];
        string IdKhoa = Request.QueryString["idkhoa"];
        string loaiBN = Request.QueryString["loaiBN"];

        string sqlKhoa = @"select * from phongkhambenh where loaiphong=0";

        DataTable table = DataAcess.Connect.GetTable(sqlKhoa);

        string html = "";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div style=\"background-color:#cfcfcf;width:400px;\" >"
        + "<div style=\"width:30%;height:30px;float:left\" >" + (i + 1) + "</div>"
        + "<div style=\"width:70%;height:30px;float:left\" >" + h["tenphongkhambenh"] + "</div>"
         + "</div>", h["idphongkhambenh"], h["tenphongkhambenh"], h["maphongkhambenh"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void nvk_IdKhoaSearch_2509()
    {
        string TenSearch = Request.QueryString["q"];
        string sqlKho = @" select idphongkhambenh,tenphongkhambenh from phongkhambenh where loaiphong=0 ";
        DataTable table = DataAcess.Connect.GetTable(sqlKho);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idthuocsearch()
    {
        DataTable dt_Para = DataAcess.Connect.GetTable(
               @"select idLoaiGayNghien= isnull( (select  paraValue from kb_parameter where paraname = N'nvk_idLoaiThuocGayNghien'),5)
	          ,idLoaiHTT= isnull( (select  paraValue from kb_parameter where paraname = N'nvk_idLoaiThuocHuongTamThan'),6)");
        string para_TGN = dt_Para.Rows[0]["idLoaiGayNghien"].ToString();
        string para_THTT = dt_Para.Rows[0]["idLoaiHTT"].ToString();
        string idKho = Request.QueryString["idkho"];
        string nvk_isThuocBV = " and b.isthuocBV=1 ";
        if (idKho == null || idKho == "" || idKho == "0")
        {
            nvk_isThuocBV = " ";
        }
        string loaithuocid = "";
        string nvk_searchType = " and B.tenthuoc like N'" + Request.QueryString["q"] + "%' ";
        if (Request.QueryString["loaithuocid"].ToString() != "")
        {
            string nvk_loaiTh = Request.QueryString["loaithuocid"].ToString();
            loaithuocid = " and B.loaithuocid = " + Request.QueryString["loaithuocid"];
            if (Request.QueryString["IsPhanBietGN_TT"] != null && Request.QueryString["IsPhanBietGN_TT"].ToString() == "1")
            {
                if (nvk_loaiTh.Equals("1"))
                    loaithuocid += " and isnull(isTGN,0)=0 and isnull(isTHTT,0)=0 ";
                else if (nvk_loaiTh.Equals(para_TGN))
                    loaithuocid = " and B.loaithuocid =1 and isnull(isTGN,0)=1";
                else if (nvk_loaiTh.Equals(para_THTT))
                    loaithuocid = " and B.loaithuocid =1 and isnull(isTHTT,0)=1";
            }
            if (!Request.QueryString["loaithuocid"].ToString().Equals("1"))
                nvk_searchType = " and B.tenthuoc like N'%" + Request.QueryString["q"] + "%' ";
        }
        string idkhoa = Request.QueryString["IdKhoa"];
        if (idkhoa != null && idkhoa != "" && idkhoa == "100")
        {
            nvk_searchType += " and isnull(isngoaitru,0)=1";
        }
        string idctdkk = Request.QueryString["idctdkk"];

        string sqlThuoc = @"SELECT top 20 B.idthuoc
                                    ,B.tenthuoc
                                    ,B.sttindm05
                                    ,B.iddvt
                                    ,B.congthuc
                                    ,B.TTHoatChat
                            , cd.tencachdung as duongdung,cd.idcachdung
                                    --,SLTON_luu=DBO.Thuoc_TonKho_new_1910(B.IDTHUOC,GETDATE(),'" + idKho + @"') 
                                    ,SLTON=DBO.[NVK_Thuoc_TonKho](B.IDTHUOC,GETDATE(),'" + idKho + @"')  
                                    ,C.TenDVt, isTrongDM= convert(int,isnull(B.sudungchobh,0))
                                ,c.TenDVT as TrenDonViCoBan
                            ,TenLoaiBH= case when b.sudungchobh=1 then N'BH' else N'DV' end
                            ,ngoaitru= case when b.isngoaitru=1 then N'Ngoại trú' else N'' end
                            ,nvk_isBHYT = case when  isnull(B.sudungchobh,0)=1 and 
                                isnull(
	                                (select top 1 dk.loaikhamid from dangkykham dk 
											                                inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                                  where ct.idchitietdangkykham ='" + idctdkk + @"'
	                                )
                                    ,0)=1 then 1 else 0 end
                                 From     thuoc B 
                            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                            left join thuoc_cachdung cd on cd.idcachdung=b.idcachdung
                            WHERE 1=1 " + nvk_isThuocBV
                                        + nvk_searchType
                                        + loaithuocid + ""
                            + " ORDER BY B.TENTHUOC,B.TTHOATCHAT,B.CONGTHUC";
        DataTable table = DataAcess.Connect.GetTable(sqlThuoc);
        //if (idKho != null && idKho != "" && idKho != "0")
        //{
        //    table.DefaultView.RowFilter = "SLTON>0";
        //    table = table.DefaultView.ToTable();
        //}
        string html = "";
        if (table != null)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {

                DataRow h = table.Rows[i];
                string nvk_style = "color:#ff0000;";
                if (h["TenLoaiBH"].ToString().Equals("DV"))
                    nvk_style = "";
                html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}", "<div>"
            + "<div style=\"" + nvk_style + "width:5%;height:30px;float:left;\" >" + (i + 1) + "</div>"
            + "<div style=\"" + nvk_style + "width:29%;height:30px;float:left;\" >" + h["tenthuoc"] + "</div>"
            + "<div style=\"" + nvk_style + "width:6%;height:30px;float:left\" >" + h["sttindm05"] + "</div>"
            + "<div style=\"" + nvk_style + "width:22%;height:30px;float:left\" >" + h["congthuc"] + "</div>"
            + "<div style=\"" + nvk_style + "width:5%;height:30px;float:left;text-align:center;\" >" + h["TenDVT"] + "</div>"
            + "<div style=\"" + nvk_style + "width:10%;height:30px;float:left;text-align:center;\" >" + h["duongdung"] + "</div>"
            + "<div style=\"" + nvk_style + "width:7%;height:30px;float:left;text-align:center;\" >" + h["SLTON"] + "</div>"
            + "<div style=\"" + nvk_style + "width:6%;height:30px;float:left;text-align:center;\" >" + h["TenLoaiBH"] + "</div>"
            + (idkhoa == "100" ? "<div style=\"" + nvk_style + "width:7%;height:30px;float:left;text-align:center;\" >" + h["ngoaitru"] + "</div>" : "")
             + "</div>", h["idthuoc"], h["congthuc"], h["TrenDonViCoBan"], h["tenthuoc"], h["sttindm05"], h["TenDVT"], h["SLTON"], h["duongdung"]
             , h["iddvt"], h["idcachdung"], h["nvk_isBHYT"], h["isTrongDM"], Environment.NewLine);
            }
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void huongdieutrisearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM kb_huongdieutri where huongdieutriid in (3,4,11,12,13,14,16,17,8,18) order by tenhuongdieutri");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void huongdieutrisearch_KhamcapCuu()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM kb_huongdieutri where huongdieutriid in (3,4,11,12,13,14,16,8,18) order by tenhuongdieutri");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void huongdieutrisearch_KhamKhoaSan()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM kb_huongdieutri where huongdieutriid in (3,4,11,13,14,8) order by tenhuongdieutri ");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoachitietbenhnhantoathuoc()
    {
        try
        {
            #region Xét quyền
            //bool isAdmin = false;
            //DataTable dtAdmin = DataAcess.Connect.GetTable("select * from UserProfile where permid=8 and userid=" + SysParameter.UserLogin.UserID(this));
            //if (dtAdmin.Rows.Count > 0 || SysParameter.UserLogin.GroupID(this) == "4")
            //    isAdmin = true;
            //if (!isAdmin)
            //{ Response.StatusCode = 500; return; }
            #endregion
            DataProcess process = s_chitietbenhnhantoathuoc();

            #region trừ tồn ảo
            DataTable dtKe = DataAcess.Connect.GetTable("select soluongke,idkho,idthuoc from chitietbenhnhantoathuoc where idchitietbenhnhantoathuoc='" + process.getData("idchitietbenhnhantoathuoc") + "'");
            if (dtKe != null && dtKe.Rows.Count > 0)
            {
                string slKe = dtKe.Rows[0]["soluongke"].ToString();
                float soLuongCapNhat = StaticData.ParseFloat(slKe);
                if (soLuongCapNhat > 0)
                {
                    soLuongCapNhat = soLuongCapNhat * (-1);
                    StaticData.nvk_CapNhatTonAoThuoc(dtKe.Rows[0]["idkho"].ToString(), dtKe.Rows[0]["idthuoc"].ToString(), soLuongCapNhat);
                }
            }
            #endregion
            bool ok = process.Delete();
            if (ok)
            {
                ok = StaticData.NVK_XoaXuatKhoTheoCTBNTT(process.getData("idchitietbenhnhantoathuoc"));

                Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void Xoakhambenhcanlamsan()
    {
        try
        {
            #region Xét quyền
            //bool isAdmin = false;
            //DataTable dtAdmin = DataAcess.Connect.GetTable("select * from UserProfile where permid=8 and userid=" + SysParameter.UserLogin.UserID(this));
            //if (dtAdmin.Rows.Count > 0 || SysParameter.UserLogin.GroupID(this) == "4")
            //    isAdmin = true;
            //if (!isAdmin)
            //{ Response.StatusCode = 500; return; }
            #endregion
            DataProcess process = s_khambenhcanlamsan();
            string idKhamBenhCLS = process.getData("idkhambenhcanlamsan");
            string sqlCLS = "select isnull(dathu,0) as TinhTrangDathu,isnull(dahuy,0) as TinhTrangDaHuy,* from khambenhcanlamsan where idkhambenhcanlamsan=" + idKhamBenhCLS;
            DataTable dtCLS = DataAcess.Connect.GetTable(sqlCLS);
            if (dtCLS.Rows[0]["TinhTrangDathu"].ToString() == "1" || dtCLS.Rows[0]["TinhTrangDathu"].ToString() == "True")
                if (dtCLS.Rows[0]["TinhTrangDaHuy"].ToString() == "0" || dtCLS.Rows[0]["TinhTrangDaHuy"].ToString() == "False")
                {
                    string sqlTest = "SELECT 1 FROM HS_DSDATHU WHERE idkhambenhcanlamsan=" + idKhamBenhCLS + " AND ISNULL(ISDAHUY,0)=0";
                    DataTable dtdT = DataAcess.Connect.GetTable(sqlTest);
                    if (dtdT == null || dtdT.Rows.Count > 0)
                    {
                        Response.StatusCode = 500;
                        return;
                    }
                }
            bool ok = process.Delete();
            if (ok)
            {
                StaticData.TinhLaiTien_ByIdKhamBenh(process.getData("idkhambenh"));
                Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void setTimKiem()
    {
        string html = "";
        //        string idkhoachinh = Request.QueryString["idkhoachinh"];
        //        string idkhambenhgoc = Request.QueryString["idkhambenhgoc"];
        //        string dk = "";
        //        if (!string.IsNullOrEmpty(idkhoachinh))
        //            dk = " KB.IDKHAMBENH='" + idkhoachinh + "'";
        //        else
        //            dk = " KB.IDKHAMBENH='" + idkhambenhgoc + "'";
        //        DataTable table = DataAcess.Connect.GetTable(@"SELECT top 1 
        //            KB.*,
        //            BN.IDBENHNHAN AS idbenhnhan,
        //            K.TENPHONGKHAMBENH AS TENKHOA,
        //            P.TENPHONG AS TENPHONG,
        //            BN.TENBENHNHAN AS TENBENHNHAN,
        //    BN.mabenhnhan AS mabenhnhan,
        //            BN.NGAYSINH AS NGAYSINH,
        //            case BN.GIOITINH when 1 then N'Nam' else N'Nữ' end AS GIOITINH,
        //            mkv_ketluan = (select top 1 mota from chandoanicd where idicd=ketluan),
        //            g.tengiuong as mkv_giuong,
        //            g.dongia as giagiuong,
        //            h.tenhuongdieutri as mkv_huongdieutri,
        //            nd.tennguoidung as mkv_IdDieuDuong,
        //            bs.tenbacsi as mkv_idbacsi,
        //            mkv_ChanDoanTuyenDuoi = (select top 1 mota from chandoanicd where idicd=ChanDoanTuyenDuoi),
        //            MACH =(SELECT TOP 1 MACH FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC ),
        //            NHIETDO =(SELECT TOP 1 NHIETDO FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC ),
        //            HUYETAP =(SELECT TOP 1 CONVERT(NVARCHAR(10),HUYETAP1)+'/'+ CONVERT(NVARCHAR(10),HUYETAP2) AS HUYETAP FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC ),
        //            NHIPTHO =(SELECT TOP 1 NHIPTHO FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC ),
        //            CANNANG =(SELECT TOP 1 CANNANG FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC )
        //            FROM BENHNHAN BN 
        //            LEFT JOIN KHAMBENH KB ON KB.IDBENHNHAN=BN.IDBENHNHAN
        //            LEFT JOIN PHONGKHAMBENH K ON K.IDPHONGKHAMBENH=KB.IDPHONGKHAMBENH
        //            LEFT JOIN KB_PHONG P ON P.id=KB.idPhongChuyenDen
        //            left join kb_giuongphieuthanhtoan g on g.idptt=kb.idkhambenh
        //            left join kb_huongdieutri h on h.huongdieutriid = kb.huongdieutri
        //            left join nguoidung nd on nd.idnguoidung = kb.iddieuduong
        //            left join bacsi bs on bs.idbacsi = kb.idbacsi
        //            WHERE " + dk);
        //html += "<root>";
        //if (!string.IsNullOrEmpty(idkhoachinh))
        //    html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
        //html += Environment.NewLine;
        //if (table != null)
        //{
        //    if (table.Rows.Count > 0)
        //    {

        //        for (int y = 0; y < table.Columns.Count; y++)
        //        {
        //            try
        //            {
        //                html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(DataProcess.sGetValidValue(table.Rows[0][y].ToString(), "date")).ToString("dd/MM/yyyy") + "</data>";
        //            }
        //            catch (Exception)
        //            {
        //                html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
        //            }
        //            html += Environment.NewLine;
        //        }
        //    }
        //}


        //html += "</root>";
        Response.Clear();
        Response.Write(html);
    }

    private void Savekhambenh()
    {
        try
        {
            DataProcess process = s_khambenh();
            if (process.getData("huongdieutri") == "8" || process.getData("huongdieutri") == "12" || process.getData("huongdieutri") == "13")
            {
                string idchitietdangkykham = process.getData("idchitietdangkykham");

                DataTable dtSVV = DataAcess.Connect.GetTable("select isnull(sovaovien,0) as SoVV,* from khambenh where idchitietdangkykham =" + idchitietdangkykham);
                bool ChuaCoSoVaoVien = true;
                int Dong = 0;
                for (int i = 0; i < dtSVV.Rows.Count; i++)
                {
                    if (dtSVV.Rows[i]["SoVV"].ToString() != "0" && dtSVV.Rows[i]["SoVV"].ToString() != "")
                    { ChuaCoSoVaoVien = false; Dong = i; }
                }
                string SoVVien = "";
                if (dtSVV.Rows.Count > 0) SoVVien = dtSVV.Rows[Dong]["SoVV"].ToString();
                if (ChuaCoSoVaoVien)
                {
                    string SoVaoVienMoi = StaticData.NewSoVaoVien(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
                    process.data("sovaovien", SoVaoVienMoi);
                    StaticData.CapNhatSoVaoVien_KhamBenh(idchitietdangkykham, SoVaoVienMoi);
                }
                else
                    process.data("sovaovien", SoVVien);
            }
            DataProcess pro = new DataProcess("kb_giuongphieuthanhtoan");
            pro.data("tengiuong", Request.QueryString["mkv_giuong"]);
            pro.data("donvi", "Ngay");
            pro.data("soluong", "1");
            pro.data("dongia", Request.QueryString["giagiuong"]);
            pro.data("thanhtien", Request.QueryString["giagiuong"]);


            DataProcess cdphoihop = new DataProcess("chandoanphoihop");
            cdphoihop.data("idkhambenh", Request.QueryString["idkhoachinh"]);
            cdphoihop.Delete();

            string idcdphoihop = Request.QueryString["idicd"];

            if (process.getData("idkhambenh") != null && process.getData("idkhambenh") != "")
            {
                bool ok = process.Update();
                if (!ok)
                {
                    Response.StatusCode = 500;
                    return;
                }
            }
            else
            {
                process.data("ngaykham", DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("dd/MM/yyyy HH:mm"));
                process.data("maphieukham", StaticData.CreateIDTheoThuTu("PKB", "khambenh", "maphieukham", "idkhambenh"));

                bool ok = process.Insert();
                if (!ok)
                {

                    Response.StatusCode = 500;
                    return;
                }
            }
            if (Request.QueryString["idkhambenhgoc"] == null)
            {
                //string idcdphoihop = Request.QueryString["idicd"];
                //DataProcess cdphoihop = new DataProcess("chandoanphoihop");
                cdphoihop.data("idkhambenh", Request.QueryString["idkhoachinh"]);
                cdphoihop.Delete();
                //luu chuan doan phoi hop
                if (idcdphoihop != null && idcdphoihop != "")
                {
                    string[] arrCDPH = idcdphoihop.Split(',');
                    if (idcdphoihop != "" && idcdphoihop != "0")
                    {
                        for (int i = 0; i < arrCDPH.Length; i++)
                        {
                            cdphoihop.data("id", Request.QueryString["id"]);
                            cdphoihop.data("idkhambenh", Request.QueryString["idkhoachinh"]);
                            cdphoihop.data("idicd", arrCDPH[i]);
                            DataTable dtPH = DataAcess.Connect.GetTable("select maicd from chandoanicd where idicd=" + arrCDPH[i] + "");
                            string MaCDPH = "";
                            if (dtPH != null && dtPH.Rows.Count > 0)
                                MaCDPH = dtPH.Rows[0]["maicd"].ToString();
                            cdphoihop.data("maicd", MaCDPH);
                            cdphoihop.Insert();
                        }
                    }
                }
            }
            pro.data("idptt", process.getData("idkhambenh"));
            if (DataAcess.Connect.GetTable("select idgiuong from kb_giuongphieuthanhtoan where idptt='" + process.getData("idkhambenh") + "'").Rows.Count > 0)
            {
                pro.Update("idptt");
            }
            else
            {
                pro.Insert();
            }
            Response.Clear(); Response.Write(process.getData("idkhambenh"));
            return;
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablechitietbenhnhantoathuoc()
    {
        try
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            if (process.getData("idthuoc").Trim() == "")
            {
                Response.StatusCode = 500;
                return;
            }
            if (process.getData("idchitietbenhnhantoathuoc") != null && process.getData("idchitietbenhnhantoathuoc") != "")
            {
                #region Xét quyền
                //bool isAdmin = false;
                //DataTable dtAdmin = DataAcess.Connect.GetTable("select * from UserProfile where permid=8 and userid=" + SysParameter.UserLogin.UserID(this));
                //if (dtAdmin.Rows.Count > 0 || SysParameter.UserLogin.GroupID(this) == "4")
                //    isAdmin = true;
                //if (!isAdmin)
                //{ return; } 
                #endregion
                #region cập nhật Tồn Ảo
                float slKeTruoc = StaticData.ParseFloat(Request.QueryString["nvk_slKeTruoc"]);
                if (slKeTruoc == 0)
                {
                    string slKe = DataAcess.Connect.GetTable("select isnull((select soluongke from chitietbenhnhantoathuoc where idchitietbenhnhantoathuoc='" + process.getData("idchitietbenhnhantoathuoc") + "'),0)").Rows[0][0].ToString();
                    slKeTruoc = StaticData.ParseFloat(slKe);
                }
                float soLuongCapNhat = StaticData.ParseFloat(process.getData("soluongke")) - slKeTruoc;
                if (soLuongCapNhat != 0)
                    StaticData.nvk_CapNhatTonAoThuoc(process.getData("idkho"), process.getData("idthuoc"), soLuongCapNhat);
                #endregion
                bool ok = process.Update();
                if (ok)
                {
                    //StaticData.TinhLaiTien_ByIdKhamBenh(process.getData("idkhambenh"));
                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    //StaticData.TinhLaiTien_ByIdKhamBenh(process.getData("idkhambenh"));
                    float soLuongCapNhat = StaticData.ParseFloat(process.getData("soluongke"));
                    if (soLuongCapNhat != 0)
                        StaticData.nvk_CapNhatTonAoThuoc(process.getData("idkho"), process.getData("idthuoc"), soLuongCapNhat);
                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablekhambenhcanlamsan()
    {
        try
        {
            DataProcess process = s_khambenhcanlamsan();
            if (process.getData("idcanlamsan") != null && process.getData("idcanlamsan") != "" && process.getData("idcanlamsan") != "0")
            {
                #region kiểm tra đã có cls này trong phiếu khám này và chưa thu chưa
                string nvk_idkhambenh = Request.QueryString["idkhambenh"];
                string sqlExistsCLS = "select idkhambenhcanlamsan from khambenhcanlamsan where idkhambenh ='" + nvk_idkhambenh + "' and idcanlamsan ='" + process.getData("idcanlamsan") + "' and isnull(DATHU,0)=0";
                DataTable dtExistsCLS = DataAcess.Connect.GetTable(sqlExistsCLS);
                if (dtExistsCLS.Rows.Count > 0)
                    process.data("idkhambenhcanlamsan", dtExistsCLS.Rows[0]["idkhambenhcanlamsan"].ToString());
                #endregion
                #region maphieucls 29/01/2013 go on (from KhoaPhauThuat\khambenh_ajax3)
                string sysdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                string idkhambenhcanlamsan = process.getData("idkhambenhcanlamsan");
                if (idkhambenhcanlamsan == null || idkhambenhcanlamsan == "")
                {
                    string ngaythu = process.getData("ngaythu");
                    if (ngaythu == null || ngaythu == "")
                    {
                        ngaythu = sysdate;
                        process.data("ngaythu", sysdate);
                    }
                    string maphieucls = process.getData("maphieucls");
                    if (maphieucls == null || maphieucls == "")
                    {
                        string IdKhamBenh = process.getData("idkhambenh");
                        if (IdKhamBenh != null && IdKhamBenh != "")
                        {
                            string sqlPrev = "SELECT TOP 1 MAPHIEUCLS,IDDANGKYCLS FROM KHAMBENHCANLAMSAN WHERE IDKHAMBENH=" + IdKhamBenh + " AND  DATHU=0 ORDER BY IDKHAMBENHCANLAMSAN DESC";
                            DataTable dtPrev = DataAcess.Connect.GetTable(sqlPrev);
                            if (dtPrev != null && dtPrev.Rows.Count > 0)
                            {
                                maphieucls = dtPrev.Rows[0][0].ToString();
                                string iddangkycls_old = dtPrev.Rows[0][1].ToString(); ;
                                process.data("IDDANGKYCLS", iddangkycls_old);
                            }
                        }
                        if (maphieucls == null || maphieucls == "")
                        {
                            maphieucls = StaticData_HS.MaPhieuCLS_new();
                            string iddangkycls = "";
                            string idbacsi = Request.QueryString["idbacsi"];
                            string idbenhnhan = Request.QueryString["idbenhnhan"];
                            string sqlExecute = "INSERT INTO HS_DANGKYCLS(MAPHIEUCLS,NGAYDK,NGUOIDK,IDBENHNHAN) VALUES('" + maphieucls + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + idbacsi + "','" + idbenhnhan + "')";
                            bool OK_iddangkycls = DataAcess.Connect.ExecSQL(sqlExecute);
                            if (OK_iddangkycls)
                            {
                                sqlExecute = @"SELECT TOP 1 * FROM HS_DANGKYCLS WHERE IDBENHNHAN=" + idbenhnhan + " AND  MAPHIEUCLS='" + maphieucls + "' ORDER BY NGAYDK DESC";
                                DataTable dtcheck = DataAcess.Connect.GetTable(sqlExecute);
                                if (dtcheck != null && dtcheck.Rows.Count > 0)
                                {
                                    iddangkycls = dtcheck.Rows[0]["IDDANGKYCLS"].ToString();
                                    process.data("IDDANGKYCLS", iddangkycls);
                                }
                            }
                        }
                        process.data("maphieucls", maphieucls);
                    }
                }
                #endregion
                if (process.getData("idkhambenhcanlamsan") != null && process.getData("idkhambenhcanlamsan") != "")// || ( dtExistsCLS.Rows.Count > 0))
                {
                    bool ok = process.Update();
                    if (ok)
                    {
                        #region Xóa các dòng cận lâm sàng null
                        string sqlDelete = @"delete from khambenhcanlamsan where idcanlamsan is null and idkhambenh=" + process.getData("idkhambenh") + "";
                        bool ktUD = DataAcess.Connect.ExecSQL(sqlDelete);
                        #endregion

                        //StaticData.TinhLaiTien_ByIdKhamBenh(process.getData("idkhambenh"));

                        Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                        return;
                    }
                }
                else
                {
                    process.data("dathu", "0");
                    #region maphieucls before 29/01/2013
                    //string NgayKham = DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("yyyy/MM/dd HH:mm");
                    //process.data("NgayKham", DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("dd/MM/yyyy HH:mm"));
                    //string sql = "select top 1 maphieucls from khambenhcanlamsan where idkhambenh=" + process.getData("idkhambenh");
                    //DataTable dt = DataAcess.Connect.GetTable(sql);
                    //if (dt == null || dt.Rows.Count == 0)
                    //{
                    //    process.data("maphieucls", StaticData_HS.MaPhieuCLS_new());//(NgayKham, "Tên BN chăm sóc", "Thu phí CLS phiếu chăm sóc", "0"));
                    //}
                    //else
                    //{
                    //    process.data("maphieucls", dt.Rows[0][0].ToString());
                    //}
                    #endregion
                    process.data("NgayKham", DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("dd/MM/yyyy HH:mm"));
                    bool ok = process.Insert();
                    if (ok)
                    {
                        #region Xóa các dòng cận lâm sàng null
                        string sqlDelete = @"delete from khambenhcanlamsan where idcanlamsan is null and idkhambenh=" + process.getData("idkhambenh") + "";
                        bool ktUD = DataAcess.Connect.ExecSQL(sqlDelete);
                        #endregion

                        //StaticData.TinhLaiTien_ByIdKhamBenh(process.getData("idkhambenh"));

                        Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                        return;
                    }
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTablechitietbenhnhantoathuoc()
    {
        bool isadmin = false;
        if (SysParameter.UserLogin.GroupID(this) == "4")
            isadmin = true;
        DataProcess process = s_chitietbenhnhantoathuoc();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        //        DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
        //                                ,b.loaithuocid,b.tenloai,a.tenthuoc,k.tenkho
        //                                ,dt.TenDoiTuong,nvk_IsHaoPhi= isnull(convert(int,ishaophi),0)
        //,soluongke as SoLuongDonVi--case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongke else isnull(SoLuongTheoDonVi,0) end as SoLuongDonVi
        //--,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongTra else isnull(t.soluongTra,0)*isnull(SoLuong1donvi,0)  end as TraTheoDonVi
        //,dvt.TenDVT as DonViCoBan--case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then N'' else N'/'+convert(varchar,SoLuong1donvi)+TenDonVi end as DonViCoBan
        //,tinhtrang=dbo.[nvk_TinhTrangYeuCauMotThuoc_idctbntt](t.idchitietbenhnhantoathuoc)
        //                               from chitietbenhnhantoathuoc T
        //                                left join thuoc a on a.idthuoc=t.idthuoc
        //                            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
        //                            left join khothuoc k on k.idkho = T.idkho
        //                            left join thuoc_doituongthuoc dt on dt.DoiTuongThuocID = t.DoiTuongThuocID
        //                            left join thuoc_donvitinh dvt on dvt.id = a.iddvt
        //          where T.idkhambenh='" + process.getData("idkhambenh") + "' order by t.idchitietbenhnhantoathuoc asc");
        string sql_pr = @"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                                ,b.loaithuocid,b.tenloai,a.tenthuoc,k.tenkho
                                ,dt.TenDoiTuong,nvk_IsHaoPhi= isnull(convert(int,ishaophi),0)
,soluongke as SoLuongDonVi--case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongke else isnull(SoLuongTheoDonVi,0) end as SoLuongDonVi
--,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongTra else isnull(t.soluongTra,0)*isnull(SoLuong1donvi,0)  end as TraTheoDonVi
,dvt.TenDVT as DonViCoBan--case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then N'' else N'/'+convert(varchar,SoLuong1donvi)+TenDonVi end as DonViCoBan
,tinhtrang=dbo.[nvk_TinhTrangYeuCauMotThuoc_idctbntt](t.idchitietbenhnhantoathuoc)
,nvk_SLTON=DBO.[NVK_Thuoc_TonKho](t.IDTHUOC,GETDATE(),t.idkho)
,slDaXuat=[dbo].[nvk_SLTHUCXUAT](t.idchitietbenhnhantoathuoc)
                                ,nvk_loaibn=isnull(
	                                (select top 1 dk.loaikhamid from dangkykham dk 
											                                inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                                  where ct.idchitietdangkykham =kb.idchitietdangkykham
	                                )
                                ,0)
                                ,nvk_isBHYT =  convert(int,isnull(T.IsBHYT_Save,0))
                                , isTrongDM= convert(int,isnull(a.sudungchobh,0))
                                ,nvk_loaikho=isnull(nvk_loaikho,0)
                                ,ISDAYEUCAU= ISNULL(T.ISDAXUATTHEOYC,T.IsDaYeuCau)
                               from chitietbenhnhantoathuoc T
                                left join thuoc a on a.idthuoc=t.idthuoc
                            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
                            left join khothuoc k on k.idkho = T.idkho
                            left join thuoc_doituongthuoc dt on dt.DoiTuongThuocID = t.DoiTuongThuocID
                            left join thuoc_donvitinh dvt on dvt.id = a.iddvt
                            left join khambenh kb on kb.idkhambenh=t.idkhambenh
          where T.idkhambenh='" + process.getData("idkhambenh") + "' order by t.idchitietbenhnhantoathuoc asc";
        DataTable table = DataAcess.Connect.GetTable(sql_pr);
        //string html = "";
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>Loại</th>");
        html.Append("<th>Hao phí ?</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
        html.Append("<th>DmBh?</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongke") + "</th>");
        //html.Append( "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongtra") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL Tồn") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đã Xuất") + "</th>");
        html.Append("<th>Bhyt?</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
        html.Append("</tr>");
        string disabled_bhyt_i = "disabled='true'";
        if (table != null && table.Rows.Count > 0)
        {
            if (table.Rows[0]["nvk_loaibn"].ToString().Equals("1"))
                disabled_bhyt_i = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str_checkHaoPhi = "";
                if (table.Rows[i]["nvk_IsHaoPhi"].ToString().Equals("1"))//nvk_IsHaoPhi
                    str_checkHaoPhi = "checked";
                if (table.Rows[i]["tinhtrang"].ToString().Equals("1"))
                {
                    string disable_editThuoc = " disabled=disabled ";
                    if (StaticData.IsCheck(table.Rows[i]["ISDAYEUCAU"].ToString()) == false)
                        disable_editThuoc = "";
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append(@"<td>");
                    html.Append("<a  onclick='xoaontable(this)'> " + (StaticData.IsCheck(table.Rows[i]["ISDAYEUCAU"].ToString()) ? "" : hsLibrary.clDictionaryDB.sGetValueLanguage("delete")) + "</a>");
                    html.Append("</td>");
                    html.Append("<td><input id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='" + table.Rows[i]["tenloai"].ToString() + "' class='down_select'/></td>");
                    //html.Append( "<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='" + table.Rows[i]["TenDoiTuong"].ToString() + "' class='down_select'/></td>");
                    html.Append("<td><input mkv='true' id='doituongthuocid' type='checkbox' " + str_checkHaoPhi + "  value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "'/></td>");
                    html.Append(@"<td><input mkv='true' " + disable_editThuoc + " id='idkho' type='hidden' value='" + table.Rows[i]["idkho"].ToString() + @"'/> 
                        <input mkv='true' id='nvk_loaikho' type='hidden' value='" + table.Rows[i]["nvk_loaikho"].ToString() + @"'/>
                        <input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='" + table.Rows[i]["tenkho"].ToString() + "' class='down_select'/></td>");
                    html.Append("<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' " + disable_editThuoc + " id='mkv_idthuoc' style='width:350px' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='" + table.Rows[i]["tenthuoc"].ToString() + "' class='down_select'/></td>");
                    html.Append("<td><input id='IsBHYT_DM' disabled='true' " + (table.Rows[i]["isTrongDM"].ToString().Equals("1") ? "checked" : "") + " type='checkbox' /></td>");
                    html.Append(@"<td ><input mkv='true' style='width:30px;text-align:right' id='soluongke' type='text' onfocusout='nvk_kiemtratonthuoc(this);chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoLuongDonVi"].ToString() + @"' onblur='TestSo(this,false,false);'/>
<input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value='" + table.Rows[i]["DonViCoBan"].ToString() + @"'/>
            <input id='nvk_soluongton' type='hidden' value='" + table.Rows[i]["nvk_SLTON"] + @"' />
                    </td>");
                    //html.Append( "<td><input mkv='true' style='width:20px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TraTheoDonVi"].ToString() + "' onblur='TestSo(this,false,false);ktrasltra(this);'/></td>");
                    html.Append("<td><input mkv='true' style='width:50px' id='slton' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["slton"].ToString() + "' onblur='TestSo(this,false,false);'/></td>");
                    html.Append("<td><input mkv='true' style='width:50px' id='slDaXuat' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["slDaXuat"].ToString() + "' /></td>");
                    html.Append("<td><input mkv='true' id='IsBHYT_Save' " + (table.Rows[i]["isTrongDM"].ToString().Equals("1") ? "" : "disabled='true'") + " type='checkbox' " + (table.Rows[i]["nvk_isBHYT"].ToString().Equals("1") ? "checked" : "") + " /></td>");
                    html.Append(@"<td><input mkv='true' style='width:80px' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + @"' /></td>
                    <input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + @"'/>
                    <input mkv='true' id='nvk_slKeTruoc' type='hidden' value='" + table.Rows[i]["SoLuongDonVi"].ToString() + "'/>");
                    html.Append("</tr>");
                }
                else
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td></td>");
                    html.Append("<td>" + table.Rows[i]["tenloai"].ToString() + "</td>");
                    html.Append("<td><input mkv='true' id='doituongthuocid'  disabled='true' type='checkbox' " + str_checkHaoPhi + "  value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "'/></td>");
                    html.Append(@"<td><input mkv='true' id='nvk_loaikho' type='hidden' value='" + table.Rows[i]["nvk_loaikho"].ToString() + @"'/>
                            " + table.Rows[i]["tenkho"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["tenthuoc"].ToString() + "</td>");
                    html.Append("<td><input id='IsBHYT_DM' disabled='true' " + (table.Rows[i]["isTrongDM"].ToString().Equals("1") ? "checked" : "") + " type='checkbox' /></td>");
                    html.Append(@"<td>" + table.Rows[i]["SoLuongDonVi"].ToString() + "  " + table.Rows[i]["DonViCoBan"].ToString() + @"
                        <input id='nvk_soluongton' type='hidden' value='" + table.Rows[i]["nvk_SLTON"] + @"' />                        
                        </td>");
                    html.Append("<td>" + table.Rows[i]["slton"].ToString() + "</td>");
                    string strDaXuat = table.Rows[i]["slDaXuat"].ToString();
                    if (!string.IsNullOrEmpty(strDaXuat) && !strDaXuat.Equals("0"))
                    {
                        string sqlPYC = @"select distinct sophieu from nvk_thuoc_chitietycxuat nvk 
                                    inner join thuoc_chitietphieuycxuat ct on ct.idchitietphieuyc=nvk.idchitietphieuyc
                                    inner join thuoc_phieuycxuat yc on yc.idphieuyc =ct.idphieuyc
                                    where nvk.idchitietbenhnhantoathuoc ='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'";
                        DataTable dtPYC = DataAcess.Connect.GetTable(sqlPYC);
                        if (dtPYC != null && dtPYC.Rows.Count > 0)
                        {
                            strDaXuat += " (";
                            for (int j = 0; j < dtPYC.Rows.Count; j++)
                            {
                                strDaXuat += dtPYC.Rows[j]["SoPhieu"].ToString() + ",";
                            }
                            strDaXuat = strDaXuat.TrimEnd(',');
                            strDaXuat += ")";
                        }
                    }
                    html.Append("<td>" + strDaXuat + "</td>");

                    #region isBHYT?
                    string BHYT_i = "";
                    if (table.Rows[i]["nvk_isBHYT"].ToString().Equals("1"))
                        BHYT_i = "checked";
                    html.Append("<td><input mkv='true' id='IsBHYT_Save' " + (table.Rows[i]["nvk_isBHYT"].ToString().Equals("1") ? "" : "disabled='true'") + " type='checkbox' " + BHYT_i + " /></td>");
                    #endregion
                    html.Append("<td>" + table.Rows[i]["ghichu"].ToString() + "</td>");
                    html.Append("</tr>");
                }
            }
        }
        html.Append("<tr>");
        html.Append("<td>" + (table.Rows.Count + 1) + "</td>");
        html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td><input  id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='' class='down_select'/></td>");
        //
        //html.Append( "<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='' class='down_select'/></td>");
        html.Append("<td><input mkv='true' id='doituongthuocid' type='checkbox' value=''/></td>");
        //
        html.Append("<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='' class='down_select'/></td>");
        html.Append(@"<td><input mkv='true' id='idthuoc' type='hidden' value='' /> <input mkv='true' id='nvk_loaikho' type='hidden' value='' />
            <input mkv='true' id='mkv_idthuoc'  style='width:300px'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='' class='down_select'/></td>");
        html.Append("<td><input id='IsBHYT_DM' disabled='true' type='checkbox' /></td>");
        html.Append(@"<td><input mkv='true' style='width:30px;text-align:right'  id='soluongke' type='text' onfocusout='nvk_kiemtratonthuoc(this);chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'>
            <input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value=''/>
            <input id='nvk_soluongton' type='hidden' value='' />
            </td>");
        //html.Append( "<td><input mkv='true' style='width:30px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);ktrasltra(this);' /></td>");
        html.Append("<td><input mkv='true' style='width:50px' id='slton' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>");
        html.Append("<td><input mkv='true' style='width:50px' id='slDaXuat' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
        html.Append("<td><input mkv='true' id='IsBHYT_Save' " + disabled_bhyt_i + " type='checkbox' /></td>");
        html.Append(@"<td><input mkv='true' style='width:80px' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>
                <input mkv='true' id='idkhoachinh' type='hidden' value=''/>
                <input mkv='true' id='nvk_slKeTruoc' type='hidden' value='0'/>");
        html.Append("</tr>");
        html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");
        html.Append(process.Paging("chitietbenhnhantoathuoc"));
        string sqlDuTru = "select DuTru103=isnull(convert(varchar(10),ngayDuTruThuoc,103),''),NgayKham103=isnull(convert(varchar(10),ngaykham,103) +' '+convert(varchar(5),ngaykham,108) ,'') from khambenh where idkhambenh='" + process.getData("idkhambenh") + "'";
        DataTable dtDT = DataAcess.Connect.GetTable(sqlDuTru);
        string NgayKhamtxt = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        if (dtDT != null && dtDT.Rows.Count > 0)
        {
            NgayKhamtxt = dtDT.Rows[0]["NgayKham103"].ToString().Trim();
            if (!dtDT.Rows[0]["DuTru103"].ToString().Equals(""))
                html.Append("@@1@@" + dtDT.Rows[0]["DuTru103"].ToString().Trim() + "@@" + NgayKhamtxt + "");
            else
                html.Append("@@0@@ @@" + NgayKhamtxt + "");
        }
        else
            html.Append("@@0@@ @@" + NgayKhamtxt + "");
        Response.Clear(); Response.Write(html);
    }
    public void loadTablekhambenhcanlamsan()
    {
        DataProcess process = s_khambenhcanlamsan();
        process.NumberRow = "10000";
        process.Page = Request.QueryString["page"];
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idkhambenhcanlamsan),T.*
                                ,a.tendichvu,a.idbanggiadichvu
                               from khambenhcanlamsan T
                                left join banggiadichvu a on t.idcanlamsan=a.idbanggiadichvu
          where T.idkhambenh=" + (process.getData("idkhambenh") == "" ? "null" : "'" + process.getData("idkhambenh") + "'"));
        string html = "";
        html += tableCLS(table, null, true);
        html += process.Paging("khambenhcanlamsan");
        Response.Clear();
        Response.Write(html);
    }
    public void loadTableAjaxDSkhambenh()
    {
        if (Request.QueryString["idkhambenhgoc"].ToString() != "")
        {
            DataProcess process = new DataProcess("khambenh");
            process.data("idkhambenhgoc", Request.QueryString["idkhambenhgoc"]);
            process.Page = Request.QueryString["page"];
            process.NumberRow = "50";
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idkhambenh),
		    T.IdKhamBenh,
		    Ngaykham,
		    chandoan=T2.Mota,
            dienbien=trieuchung,
            T3.TenGiuong,
            YLenh=DBO.KB_GetYLenh(t.idKhamBenh),
		    T4.TenBacSi,
            DieuDuong=  T5.TenNguoiDung 
	    from khambenh t
	       left join ChanDoanICD T2 on t.KetLuan=t2.IdICD
		    left join KB_GiuongPhieuThanhToan T3 on t.idkhambenh=t3.IdPTT
           left join bacsi t4 on t.idbacsi=t4.idbacsi
		    left join nguoidung t5 on t.iddieuduong=t5.idnguoidung
        where T.idkhambenhgoc='" + process.getData("idkhambenhgoc") + "'");
            string html = "";
            html += process.Paging("DSkhambenh");
            html += "<table class='jtable' id=\"gridTabledskb\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngaykham") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("chandoan") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dienbien") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenGiuong") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("YLenh") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenBacSi") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DieuDuong") + "</th>";
            html += "</tr>";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idkhambenh"].ToString() + "');\">";
                        html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                        if (table.Rows[i]["ngaykham"].ToString() != "")
                        {
                            html += "<td>" + DateTime.Parse(table.Rows[i]["ngaykham"].ToString()).ToString("dd/MM/yyyy HH:mm tt") + "</td>";
                        }
                        else { html += "<td>" + table.Rows[i]["ngaykham"].ToString() + "</td>"; }
                        html += "<td>" + table.Rows[i]["chandoan"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["dienbien"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["TenGiuong"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["YLenh"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["TenBacSi"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["DieuDuong"].ToString() + "</td>";
                        html += "</tr>";
                    }
                }
            }
            html += "</table>";
            html += process.Paging("DSkhambenh");
            Response.Clear(); Response.Write(html);
        }
        else
            Response.StatusCode = 500;
    }
    public void loadTablechandoanphoihop()
    {


        DataProcess process = new DataProcess("chandoanphoihop");
        process.data("idkhambenh", Request.QueryString["idkhambenh"]);
        DataTable table = process.Search(@"select STT=row_number() over (order by T.id),
		    A.mota,a.idicd,a.maicd from chandoanphoihop T
            left join chandoanicd A on A.idicd = T.idicd
            where T.idkhambenh='" + process.getData("idkhambenh") + @"'
            ");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<div style='text-align:right;float:left;width:400px;height:30px'>";
                    html += "<a style='cursor:pointer' onclick='$(this).parent().remove();'>Xoá</a> -- ";
                    html += "<input type='hidden' mkv='true' id='idicd' value='" + table.Rows[i]["idicd"].ToString() + "'/>";
                    html += table.Rows[i]["maicd"].ToString() + " - " + table.Rows[i]["mota"].ToString();
                    html += "</div>";
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private string tableCLS(DataTable dt, string[] arrslvack, bool idkhambenhcls)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTablecls\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idcanlamsan") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("chietkhau") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
        //html.Append( "<th></th>");
        html.Append("</tr>");
        if (dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ck = 0;
                int sl = 1;
                if (arrslvack != null)
                {
                    for (int y = 0; y < arrslvack.Length; y++)
                    {
                        if (arrslvack[y].Split('^')[0].ToString() == dt.Rows[i]["idbanggiadichvu"].ToString() && (int.Parse(arrslvack[y].Split('^')[1].ToString()) > 1 || int.Parse(arrslvack[y].Split('^')[2].ToString()) > 0))
                        {
                            ck = int.Parse(arrslvack[y].Split('^')[2].ToString());
                            sl = int.Parse(arrslvack[y].Split('^')[1].ToString());
                            break;
                        }
                    }
                }
                try
                {
                    ck = int.Parse(dt.Rows[i]["chietkhau"].ToString());
                    sl = int.Parse(dt.Rows[i]["soluong"].ToString());
                }
                catch { }
                int thanhtien = sl * int.Parse(dt.Rows[i]["dongia"].ToString());
                html.Append("<tr>");
                html.Append("<td>" + dt.Rows[i]["stt"] + "</td>");
                html.Append("<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                html.Append("<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idbanggiadichvu"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='" + dt.Rows[i]["tendichvu"] + "' class='down_select' style='width:400px'/></td>");
                html.Append("<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + sl + "' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:30px'/></td>");
                html.Append("<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["dongia"] + "' onblur='TestSo(this,false,false);thanhtiencls(this);' style='width:70px'/></td>");
                html.Append("<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ck + "' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:30px'/></td>");

                html.Append("<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ((thanhtien - (thanhtien * ck) / 100)).ToString() + "' style='width:70px' /></td>");
                html.Append(@"<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' />
                <input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : "") + @"'/>
                </td>");
                //html.Append( "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : "") + "'/></td>");
                html.Append("</tr>");
            }
        }
        html.Append("<tr>");
        html.Append("<td>" + (dt.Rows.Count + 1) + "</td>");
        html.Append("<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='' class='down_select' style='width:400px'/></td>");
        html.Append("<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:30px'/></td>");
        html.Append("<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);' style='width:70px'/></td>");
        html.Append("<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='thanhtiencls(this);'  style='width:30px'/></td>");

        html.Append("<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:70px'/></td>");

        html.Append(@"<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' />
        <input mkv='true' id='idkhoachinh' type='hidden' value=''/>
        </td>");
        //html.Append( "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
        html.Append("</tr>");

        html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");
        return html.ToString();
    }

    ///////////VanKhoe

    public string LoadDanhSachBenhNhanNoiTru(DataTable table)
    {
        string html = "";
        if (table.Rows.Count > 0)
        {
            html = "<table class='jtable' id=\"gridTabledskb\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th>Mã bệnh nhân</th>";
            html += "<th>Tên bệnh nhân</th>";
            html += "<th>Địa chỉ</th>";
            html += "<th>Giới tính</th>";
            html += "<th>Năm sinh</th>";
            html += "<th>Loại khám</th>";
            html += "<th>Ngày nhập viện</th>";
            html += "</tr>";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr style='cursor:pointer;' onclick=\"SetBenhNhanClick('" + table.Rows[i]["MaBenhNhan"].ToString() + "');\">";
                html += "<td>" + (i + 1) + "</td>";//table.Rows[i]["stt"].ToString()

                html += "<td>" + table.Rows[i]["MaBenhNhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["TenBenhNhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["DiaChi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["Gioi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["namsinh"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["LoaiKham"].ToString() + "</td>";
                if (table.Rows[i]["NgayTiepNhan"].ToString() != "")
                {
                    html += "<td>" + DateTime.Parse(table.Rows[i]["NgayTiepNhan"].ToString()).ToString("dd/MM/yyyy HH:mm tt") + "</td>";
                }
                else { html += "<td>" + table.Rows[i]["NgayTiepNhan"].ToString() + "</td>"; }
                html += "</tr>";
            }

            html += "</table>";
        }
        return html;
    }
    public string LoadDanhSachChiDinhNoiTru(DataTable table)
    {
        string html = "<table class='jtable' id=\"TieuDeTableCLS\">";
        html += "<tr>";
        html += "<th>Nội dung chỉ định dịch vụ</th>";
        html += "</tr>";
        html += "</table>";

        html += "<table class='jtable' id=\"gridTabledsCLS\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>Ngày chỉ định</th>";
        html += "<th>Lần chỉ định</th>";
        html += "<th>Mã phiếu chỉ định</th>";
        html += "<th>Khoa chỉ định</th>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr style='cursor:pointer;' onclick=\"SetIdKhamBenhSuaChiDinh('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "');\">";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";//
                    if (table.Rows[i]["ngaykham"].ToString() != "")
                    {
                        html += "<td>" + DateTime.Parse(table.Rows[i]["ngaykham"].ToString()).ToString("dd/MM/yyyy HH:mm tt") + "</td>";
                    }
                    else { html += "<td>" + table.Rows[i]["ngaykham"].ToString() + "</td>"; }
                    html += "<td>" + table.Rows[i]["MaBenhNhan"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["maphieucls"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["khoa"].ToString() + "</td>";
                    html += "</tr>";
                }
            }
        }
        html += "</table>";
        return html;
    }
    public string LoadDanhSachChiDinhThuocNoiTru(DataTable table)
    {
        string html = "<table class='jtable' id=\"TieuDeTableCLS\">";
        html += "<tr>";
        html += "<th>Nội dung chỉ định Thuốc</th>";
        html += "</tr>";
        html += "</table>";

        html += "<table class='jtable' id=\"gridTabledsThuoc\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>Ngày chỉ định</th>";
        html += "<th>Lần chỉ định</th>";
        html += "<th>Khoa chỉ định</th>";
        html += "<th>Bác sĩ chỉ định</th>";
        html += "<th>Dự trù ?</th>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr style='cursor:pointer;' onclick=\"SetIdKhamBenhSuaChiDinh('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "');\">";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";//
                    if (table.Rows[i]["ngaykham"].ToString() != "")
                    {
                        html += "<td>" + DateTime.Parse(table.Rows[i]["ngaykham"].ToString()).ToString("dd/MM/yyyy HH:mm tt") + "</td>";
                    }
                    else { html += "<td>" + table.Rows[i]["ngaykham"].ToString() + "</td>"; }
                    html += "<td>" + table.Rows[i]["MaBenhNhan"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["khoa"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["tenbacsi"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["NgayDuTru103"].ToString() + "</td>";
                    html += "</tr>";
                }
            }
        }
        html += "</table>";
        return html;
    }
    private void idBenhViensearch()
    {
        string sqlBenhVien = @"select idbenhvien,mabenhvien,tenbenhvien from benhvien where tenbenhvien like N'%" + Request.QueryString["q"] + "%' order by tenbenhvien";
        DataTable table = DataAcess.Connect.GetTable(sqlBenhVien);
        if (table == null || table.Rows.Count == 0)
            table = DataAcess.Connect.GetTable("select idbenhvien,mabenhvien,tenbenhvien from benhvien order by tenbenhvien");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Luukhambenhmoi()
    {
        string idicdxacdinh = Request.QueryString["idicdxacdinh"];
        string IdKhamBenh = "0"; bool IsUpdateDaNhap = false; string phongkhamchuyenden = "";
        string IdKhoaKham = Request.QueryString["idkhoa"].ToString();
        string idBenhNhan = Request.QueryString["idbenhnhan"].ToString();
        string IdBacSi = Request.QueryString["idbacsi"].ToString();
        string NgayDuTruThuoc = "null";
        if (Request.QueryString["NgayDuTruThuoc"] != null && !Request.QueryString["NgayDuTruThuoc"].ToString().Trim().Equals(""))
            NgayDuTruThuoc = "'" + StaticData.CheckDate(Request.QueryString["NgayDuTruThuoc"].ToString()) + "'";

        #region Luu Khám bệnh mới nếu LuuMoiKhamBenh=1
        if ((Request.QueryString["LuuMoiKhamBenh"] != null && Request.QueryString["LuuMoiKhamBenh"].ToString() == "1") || (Request.QueryString["IsTheoDoiCC"] != null))//&& Request.QueryString["IsTheoDoiCC"].ToString() == "1"
        {
            string sqlKhamBenh = @"select case when isnull(idkhambenhgoc,0)<>0 then idkhambenhgoc  else idkhambenh end as GociIdkhambenh,kb.*
                     from khambenh kb 
                    where idbenhnhan=" + idBenhNhan + @"
                     order by idkhambenh desc";
            DataTable dtKhamBenhTruoc = DataAcess.Connect.GetTable(sqlKhamBenh);//
            DataProcess processKB = s_khambenh();
            if (dtKhamBenhTruoc != null && dtKhamBenhTruoc.Rows.Count > 0)
            {
                string idchitietdangkykham = dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString();
                string SoVVien = dtKhamBenhTruoc.Rows[0]["sovaovien"].ToString().Trim();
                string InsertKhamBenhMoi = "";
                // Update Khám bệnh cũ
                #region update khambenh cũ
                if (Request.QueryString["LuuMoiKhamBenh"] != null && Request.QueryString["LuuMoiKhamBenh"].ToString() == "0")
                {
                    string idkhambenh = Request.QueryString["idkhambenh"].ToString();
                    string HuongDieuTri = dtKhamBenhTruoc.Rows[0]["huongdieutri"].ToString();
                    string GhiChuHuongDieuTri = dtKhamBenhTruoc.Rows[0]["ghichuhuongdieutri"].ToString();
                    phongkhamchuyenden = dtKhamBenhTruoc.Rows[0]["phongkhamchuyenden"].ToString();
                    string idDVPhongChuyenDen = dtKhamBenhTruoc.Rows[0]["idDVPhongchuyenden"].ToString();
                    string idPhongChuyenDen = dtKhamBenhTruoc.Rows[0]["idphongchuyenden"].ToString();
                    if (Request.QueryString["huongdieutri"] != null)
                    {
                        HuongDieuTri = Request.QueryString["huongdieutri"].ToString();
                        if (HuongDieuTri.Trim() != dtKhamBenhTruoc.Rows[0]["huongdieutri"].ToString().Trim())
                            IsUpdateDaNhap = true;
                        if (HuongDieuTri == "4")
                            GhiChuHuongDieuTri = Request.QueryString["ghichuhuongdieutri"].ToString();
                        else if (HuongDieuTri == "8")
                            phongkhamchuyenden = Request.QueryString["phongkhamchuyenden"].ToString();
                        else if (HuongDieuTri == "12" || HuongDieuTri == "18")
                        {
                            idDVPhongChuyenDen = Request.QueryString["idDVPhongChuyenDen"].ToString();
                            idPhongChuyenDen = Request.QueryString["idPhongChuyenDen"].ToString();
                        }
                    }
                    //  Xử lý Số vào viện
                    #region Số vào viện
                    if (HuongDieuTri == "8" || HuongDieuTri == "12" || HuongDieuTri == "13")
                    {
                        DataTable dtSVV = DataAcess.Connect.GetTable("select isnull(sovaovien,0) as SoVV,* from khambenh where idchitietdangkykham =" + idchitietdangkykham);
                        bool ChuaCoSoVaoVien = true;
                        int Dong = 0;
                        for (int i = 0; i < dtSVV.Rows.Count; i++)
                        {
                            if (dtSVV.Rows[i]["SoVV"].ToString() != "0" && dtSVV.Rows[i]["SoVV"].ToString() != "")
                            { ChuaCoSoVaoVien = false; Dong = i; }
                        }
                        if (dtSVV.Rows.Count > 0) SoVVien = dtSVV.Rows[Dong]["SoVV"].ToString();
                        if (ChuaCoSoVaoVien)
                        {
                            SoVVien = StaticData.NewSoVaoVien(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
                            StaticData.CapNhatSoVaoVien_KhamBenh(idchitietdangkykham, SoVVien);
                        }
                        bool ktXoaBH = DataAcess.Connect.ExecSQL("delete  from kb_benhnhanbhdongtien where convert(varchar(10),ngaytinhbh,103) =convert(varchar(10),getdate(),103) and idbenhnhan=" + idBenhNhan + "");
                    }
                    #endregion
                    string ketluanin = "";
                    if (idicdxacdinh != null) ketluanin = "ketluan='" + idicdxacdinh + "',";
                    string sqlUpdateKB = @"update khambenh set ngayDuTruThuoc=" + NgayDuTruThuoc + ", " + ketluanin + " idbacsi='" + IdBacSi + "',huongdieutri='" + HuongDieuTri + "',phongkhamchuyenden='" + phongkhamchuyenden + @"',
                                ghichuhuongdieutri='" + GhiChuHuongDieuTri + "',idPhongChuyenDen='" + idPhongChuyenDen + "',idDVPhongChuyenDen='" + idDVPhongChuyenDen + "',sovaovien='" + SoVVien + "',idphongkhambenh='" + IdKhoaKham + "' where idkhambenh =" + idkhambenh + "";
                    #region cập nhật chẩn đoán phiếu khám gốc nếu chưa có
                    if (idicdxacdinh != null && idicdxacdinh != "" && idicdxacdinh != "0")
                    {
                        string sqlGoc = "update khambenh set ketluan='" + idicdxacdinh + "' where isnull(ketluan,'')='' and idkhambenh=isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=" + idchitietdangkykham + "),0)";
                        bool ktupKBGoc = DataAcess.Connect.ExecSQL(sqlGoc);
                    }
                    #endregion
                    bool kttt = DataAcess.Connect.ExecSQL(sqlUpdateKB);
                    #region  Cập nhật tình trạng nhập khoa
                    if (kttt && IsUpdateDaNhap)
                    {
                        string sql = "update benhnhannoitru set IsDaNhap=0 where idkhoanoitru=" + phongkhamchuyenden + " and idchitietdangkykham=" + dtKhamBenhTruoc.Rows[0]["idchitietdangkykham"].ToString();
                        bool ktIsDaNhap = DataAcess.Connect.ExecSQL(sql);
                    }
                    #endregion
                    Response.Clear();
                    Response.Write(IdKhamBenh); return;
                }
                #endregion
                ///////
                if (Request.QueryString["IsTheoDoiCC"] != null && Request.QueryString["IsTheoDoiCC"].ToString() == "1")
                {
                    string HuongDieuTri = dtKhamBenhTruoc.Rows[0]["huongdieutri"].ToString();
                    string GhiChuHuongDieuTri = dtKhamBenhTruoc.Rows[0]["ghichuhuongdieutri"].ToString();
                    phongkhamchuyenden = dtKhamBenhTruoc.Rows[0]["phongkhamchuyenden"].ToString();
                    string idDVPhongChuyenDen = dtKhamBenhTruoc.Rows[0]["idDVPhongchuyenden"].ToString();
                    string idPhongChuyenDen = dtKhamBenhTruoc.Rows[0]["idphongchuyenden"].ToString();
                    if (Request.QueryString["huongdieutri"] != null)
                    {
                        HuongDieuTri = Request.QueryString["huongdieutri"].ToString();
                        if (HuongDieuTri.Trim() != dtKhamBenhTruoc.Rows[0]["huongdieutri"].ToString().Trim())
                            IsUpdateDaNhap = true;
                        if (HuongDieuTri == "4")
                            GhiChuHuongDieuTri = Request.QueryString["ghichuhuongdieutri"].ToString();
                        else if (HuongDieuTri == "8")
                            phongkhamchuyenden = Request.QueryString["phongkhamchuyenden"].ToString();
                        else if (HuongDieuTri == "12" || HuongDieuTri == "18")
                        {
                            idDVPhongChuyenDen = Request.QueryString["idDVPhongChuyenDen"].ToString();
                            idPhongChuyenDen = Request.QueryString["idPhongChuyenDen"].ToString();
                        }
                    }
                    //  Xử lý Số vào viện
                    #region Số vào viện
                    if (HuongDieuTri == "8" || HuongDieuTri == "12" || HuongDieuTri == "13")
                    {
                        DataTable dtSVV = DataAcess.Connect.GetTable("select isnull(sovaovien,0) as SoVV,* from khambenh where idchitietdangkykham =" + idchitietdangkykham);
                        bool ChuaCoSoVaoVien = true;
                        int Dong = 0;
                        for (int i = 0; i < dtSVV.Rows.Count; i++)
                        {
                            if (dtSVV.Rows[i]["SoVV"].ToString() != "0" && dtSVV.Rows[i]["SoVV"].ToString() != "")
                            { ChuaCoSoVaoVien = false; Dong = i; }
                        }
                        if (dtSVV.Rows.Count > 0) SoVVien = dtSVV.Rows[Dong]["SoVV"].ToString();
                        if (ChuaCoSoVaoVien)
                        {
                            SoVVien = StaticData.NewSoVaoVien(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
                            StaticData.CapNhatSoVaoVien_KhamBenh(idchitietdangkykham, SoVVien);
                        }
                        bool ktXoaBH = DataAcess.Connect.ExecSQL("delete  from kb_benhnhanbhdongtien where convert(varchar(10),ngaytinhbh,103) =convert(varchar(10),getdate(),103) and idbenhnhan=" + idBenhNhan + "");
                    }
                    #endregion
                    // End xử lý số vào viện
                    InsertKhamBenhMoi = @"insert into khambenh (maphieukham,ngaykham,idbenhnhan,iddangkykham,idbacsi,huongdieutri,phongkhamchuyenden,
                                ghichuhuongdieutri,hoantat,idphongkhambenh,SoPhieuTT,idPhongChuyenDen,thuChuyenPhong,idDVPhongChuyenDen,
                                IdChiTietDangKyKham,isNoiTru,idkhambenhgoc,sovaovien,ketluan,ngayDuTruThuoc,IsDaChuyenKhoa)
                                values('" + StaticData.CreateIDTheoThuTuTN("PKB", "khambenh", "maphieukham", "idkhambenh", DateTime.Now.ToString("ddMMyyyy")) + "',getdate(),'" + dtKhamBenhTruoc.Rows[0]["idbenhnhan"].ToString() + "','" + dtKhamBenhTruoc.Rows[0]["iddangkykham"].ToString() + "','" + IdBacSi + "','" + HuongDieuTri + "','" + phongkhamchuyenden + @"'
                                ,'" + GhiChuHuongDieuTri + "','0','" + IdKhoaKham + "','" + dtKhamBenhTruoc.Rows[0]["SoPhieuTT"].ToString() + "','" + idPhongChuyenDen + "','0','" + idDVPhongChuyenDen + @"'
                                ,'" + dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString() + "','0','" + dtKhamBenhTruoc.Rows[0]["GociIdkhambenh"].ToString() + "','" + SoVVien + "','" + idicdxacdinh + @"'
                                ," + NgayDuTruThuoc + ",2)";//dtKhamBenhTruoc.Rows[0][""].ToString()
                }
                else
                {
                    if (SoVVien.Equals(""))
                    {
                        SoVVien = StaticData.NewSoVaoVien(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
                        StaticData.CapNhatSoVaoVien_KhamBenh(idchitietdangkykham, SoVVien);
                    }
                    InsertKhamBenhMoi = @"insert into khambenh (maphieukham,ngaykham,idbenhnhan,iddangkykham,idbacsi,huongdieutri,phongkhamchuyenden,
                                                ghichuhuongdieutri,hoantat,idphongkhambenh,SoPhieuTT,idPhongChuyenDen,thuChuyenPhong,idDVPhongChuyenDen,
                                                IdChiTietDangKyKham,isNoiTru,idkhambenhgoc,sovaovien,ketluan,ngayDuTruThuoc,IsDaChuyenKhoa)
                                                values('" + StaticData.CreateIDTheoThuTuTN("PKB", "khambenh", "maphieukham", "idkhambenh", DateTime.Now.ToString("ddMMyyyy")) + "',getdate(),'" + dtKhamBenhTruoc.Rows[0]["idbenhnhan"].ToString() + "','" + dtKhamBenhTruoc.Rows[0]["iddangkykham"].ToString() + "'," + IdBacSi + ",'" + dtKhamBenhTruoc.Rows[0]["huongdieutri"].ToString() + "','" + dtKhamBenhTruoc.Rows[0]["phongkhamchuyenden"].ToString() + @"'
                                                ,'" + dtKhamBenhTruoc.Rows[0]["ghichuhuongdieutri"].ToString() + "','0','" + IdKhoaKham + "','" + dtKhamBenhTruoc.Rows[0]["SoPhieuTT"].ToString() + "','" + dtKhamBenhTruoc.Rows[0]["idphongchuyenden"].ToString() + "','0','" + dtKhamBenhTruoc.Rows[0]["idDVPhongchuyenden"].ToString() + @"'
                                                ,'" + dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString() + "','1','" + dtKhamBenhTruoc.Rows[0]["GociIdkhambenh"].ToString() + "','" + SoVVien + "','" + idicdxacdinh + @"'
                                                ," + NgayDuTruThuoc + ",2)";//dtKhamBenhTruoc.Rows[0][""].ToString()
                }
                bool ktInsert = DataAcess.Connect.ExecSQL(InsertKhamBenhMoi);
                if (ktInsert)
                {
                    #region cập nhật chẩn đoán phiếu khám gốc nếu chưa có
                    if (idicdxacdinh != null && idicdxacdinh != "" && idicdxacdinh != "0")
                    {
                        string sqlGoc = "update khambenh set ketluan='" + idicdxacdinh + "' where isnull(ketluan,'')='' and idkhambenh=isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=" + idchitietdangkykham + "),0)";
                        bool ktupKBGoc = DataAcess.Connect.ExecSQL(sqlGoc);
                    }
                    #endregion
                    #region  Cập nhật tình trạng nhập khoa
                    if (ktInsert && IsUpdateDaNhap)
                    {
                        string sql = "update benhnhannoitru set IsDaNhap=0 where idkhoanoitru=" + phongkhamchuyenden + " and idchitietdangkykham=" + dtKhamBenhTruoc.Rows[0]["idchitietdangkykham"].ToString();
                        bool ktIsDaNhap = DataAcess.Connect.ExecSQL(sql);
                    }
                    #endregion
                    DataTable dtId = DataAcess.Connect.GetTable("select top 1 idkhambenh from khambenh where IdChiTietDangKyKham=" + dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString() + @" order by idkhambenh desc");
                    if (dtId.Rows.Count > 0)
                        IdKhamBenh = dtId.Rows[0][0].ToString();
                }
            }
        }
        #endregion
        Response.Clear();
        Response.Write(IdKhamBenh);
    }
    private void idthuocXUATVIENsearch()
    {
        string TypeSearch = Request.QueryString["TypeSearch"];
        string html = "";

        string sValue = Request.QueryString["q"];
        string tenthuoc = null;
        string congthuc = null;
        if (TypeSearch == "1")
            tenthuoc = sValue;
        else
            congthuc = sValue;


        string IdLoaiThuoc = Request.QueryString["loaithuocid"];
        if (IdLoaiThuoc == null || IdLoaiThuoc == "")
            IdLoaiThuoc = "1";
        string loaithuocid = "";
        loaithuocid = " and t.loaithuocid = " + IdLoaiThuoc;
        #region IdKho
        string IdKho = Request.QueryString["idkho"];
        if (IdKho == null || IdKho == "") IdKho = "0";
        #endregion
        string sql = @"SELECT top 20 t.idthuoc,t.tenthuoc
                        ,t.loaithuocid
                        ,dvt.tendvt as donvitinh,t.iddvt
                        ,t.congthuc as congthuc
                        , cd.tencachdung as duongdung,cd.idcachdung
                        ,t.sudungchobh
                        ,t.isthuocbv
                        FROM thuoc t
                        left join thuoc_donvitinh dvt on dvt.id=t.iddvt
                        left join thuoc_cachdung cd on cd.idcachdung=t.idcachdung
                        where 1=1";
        if (tenthuoc != null && tenthuoc != "")
            sql += " and  t.tenthuoc LIKE N'" + tenthuoc + @"%'";

        if (congthuc != null && congthuc != "")
            sql += " and  t.congthuc LIKE N'" + congthuc + @"%'";

        if (IdKho != null && IdKho != "" && IdKho != "0" && IdKho != "-1")
            sql += " AND T.ISTHUOCBV=1";
        if (loaithuocid != null && loaithuocid != "")
            sql += loaithuocid;


        sql += " ORDER BY  isnull(t.sudungchobh,0) desc, isnull( t.isthuocbv,0) desc ,  t.tenthuoc ASC";

        bool IsCheckSLTon = false;
        string loaidk = Request.QueryString["loaidk"];
        DataTable arr = DataAcess.Connect.GetTable(sql);
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                bool IsView = true;
                string number = "0";
                string SLTon_ = "0";
                if (IdKho != null && IdKho != "" && IdKho != "0" && IdKho != "-1")
                {
                    string strTon = "select SLTON= [dbo].NVK_Thuoc_TonKho(" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + "'," + IdKho + ")";
                    strTon += "\r\n, DonGia=" + (loaidk == "1" && StaticData.IsCheck(h["sudungchobh"].ToString()) ? "DBO.zHS_GiaThuocBH(" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + @"')" : "  DBO.Thuoc_TinhGiaXuat2(" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + @"',1,1,1," + IdKho + @")");

                    DataTable tbTon = DataAcess.Connect.GetTable(strTon);
                    try
                    {
                        IsCheckSLTon = true;
                        number = tbTon.Rows[0]["DonGia"].ToString();
                        SLTon_ = tbTon.Rows[0]["SLTON"].ToString();
                        if (SLTon_ == "") SLTon_ = "0";
                        double SLTon = double.Parse(SLTon_);

                    }
                    catch
                    {
                    }
                }
                if (IsView)
                {

                    html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}",
                                          "<div style=\"width:100%;height:30px;" + ((StaticData.IsCheck(h["sudungchobh"].ToString()) == false && loaidk.Trim() == "1") ? "background-color:#CAE3FF;" : "") + "\">"
                                          + "<div style=\"width:21%;float:left;height:30px\" >" + h["tenthuoc"] + "</div>"
                                          + "<div style=\"width:23%;float:left;height:30px\" >" + h["congthuc"] + "</div>"
                                          + "<div style=\"text-align:left;width:12%;float:left;height:30px\" >" + h["duongdung"] + "</div>"
                                          + "<div style=\"text-align:left;width:10%;float:left;height:30px\" >" + h["donvitinh"] + "</div>"
                                          + "<div style=\"text-align:left;width:9%;float:left;height:30px\" >" + number + "</div>"
                                          + "<div style=\"text-align:left;width:4%;float:left;height:30px\" >" + SLTon_ + "</div>"
                                          + "<div style=\"text-align:right;width:7%;float:left;height:30px\" >" + (StaticData.IsCheck(h["sudungchobh"].ToString()) == true ? "BH" : "DV") + "</div>"
                                          + "<div style=\"text-align:right;width:10%;float:left;height:30px\" >" + (StaticData.IsCheck(h["isthuocbv"].ToString()) == true ? "Trong BV" : "Ngoài BV") + "</div>"
                                          + "</div>", h["idthuoc"], h["donvitinh"], h["duongdung"], h["tenthuoc"], number,
                                          SLTon_, h["congthuc"], StaticData.IsCheck(h["sudungchobh"].ToString()), h["iddvt"], h["idcachdung"], IdKho, (IsCheckSLTon && StaticData.IsCheck(h["ISTHUOCBV"].ToString()) ? "1" : "0"), Environment.NewLine);
                    ;
                }

            }
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }

}



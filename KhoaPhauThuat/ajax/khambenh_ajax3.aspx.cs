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
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
public partial class khambenh_ajax : System.Web.UI.Page
{
    protected DataProcess s_khambenh()
    {
        DataProcess KHAMBENH = new DataProcess("KHAMBENH");
        KHAMBENH.data("idkhambenh", Request.QueryString["idkhoachinh"]);
        KHAMBENH.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        KHAMBENH.data("IdKhoa", Request.QueryString["IdKhoa"]);
        KHAMBENH.data("ngaykham", Request.QueryString["ngaykham"]);
        KHAMBENH.data("TGXuatVien", DataProcess.sGetValidDate(Request.QueryString["gioravien"], Request.QueryString["phutravien"], Request.QueryString["TGXuatVien"]));
        KHAMBENH.data("ketluan", Request.QueryString["idchandoan"]);
        KHAMBENH.data("ketluan1", Request.QueryString["ketluan1"]);
        string PhongID = Request.QueryString["PhongID"];
        string disabledCaKipMo = Request.QueryString["disabledCaKipMo"];
        if ((PhongID == null || PhongID == "") && disabledCaKipMo != null && disabledCaKipMo != "")
            PhongID = StaticData.GetParaValueDB("IdPhongHauPhau");
        KHAMBENH.data("PhongID", PhongID);
        KHAMBENH.data("DichVuKCBID", Request.QueryString["DichVuKCBID"]);
        KHAMBENH.data("IdChiTietDangKyKham", Request.QueryString["IdChiTietDangKyKham"]);
        KHAMBENH.data("IdBacSi", Request.QueryString["IdBacSi"]);
        KHAMBENH.data("isNoiTru", Request.QueryString["isNoiTru"]);
        KHAMBENH.data("IdChuyenPK", Request.QueryString["IdChuyenPK"]);
        if (StaticData.EnableChuyenKhoa)
            KHAMBENH.data("idDVPhongChuyenDen", Request.QueryString["idDVPhongChuyenDen"]);
        KHAMBENH.data("IdkhoaChuyen", Request.QueryString["IdkhoaChuyen"]);
        KHAMBENH.data("trieuchung", Request.QueryString["trieuchung"]);
        KHAMBENH.data("benhsu", Request.QueryString["benhsu"]);
        KHAMBENH.data("TienSu", Request.QueryString["tiensu"]);
        KHAMBENH.data("IsXuatVien", Request.QueryString["IsXuatVien"]);
        KHAMBENH.data("ngayhentaikham", Request.QueryString["ngayhentaikham"]);
        KHAMBENH.data("songayratoa", Request.QueryString["songayratoa"]);
        KHAMBENH.data("ischuyenvien", Request.QueryString["ischuyenvien"]);
        KHAMBENH.data("idbenhvienchuyen", Request.QueryString["idbenhvienchuyen"]);
        KHAMBENH.data("IsBSMoiKham", Request.QueryString["IsBSMoiKham"]);
        KHAMBENH.data("giuongid", Request.QueryString["giuongid"]);
        KHAMBENH.data("idphuongphapvocam", Request.QueryString["idphuongphapvocam"]);
        KHAMBENH.data("chandoanbandau", Request.QueryString["chandoanbandau"]);
        KHAMBENH.data("idchandoantuyenduoi", Request.QueryString["idchandoantuyenduoi"]);
        KHAMBENH.data("MoTaCD_edit", Request.QueryString["mkv_mota"]);
        return KHAMBENH;
    }
    protected DataProcess s_chitietbenhnhantoathuoc()
    {
        DataProcess chitietbenhnhantoathuoc = new DataProcess("chitietbenhnhantoathuoc");
        chitietbenhnhantoathuoc.data("idchitietbenhnhantoathuoc", Request.QueryString["idkhoachinh"]);
        chitietbenhnhantoathuoc.data("idbenhnhantoathuoc", Request.QueryString["idbenhnhantoathuoc"]);
        chitietbenhnhantoathuoc.data("idthuoc", Request.QueryString["idthuoc"]);
        chitietbenhnhantoathuoc.data("soluongke", Request.QueryString["soluongke"]);
        chitietbenhnhantoathuoc.data("ghichu", Request.QueryString["ghichu"]);
        chitietbenhnhantoathuoc.data("idkhambenh", Request.QueryString["idkhambenh"]);
        chitietbenhnhantoathuoc.data("idkho", Request.QueryString["idkho"]);
        chitietbenhnhantoathuoc.data("ngayratoa", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
        chitietbenhnhantoathuoc.data("iddvt", Request.QueryString["iddvt"]);
        chitietbenhnhantoathuoc.data("IsHaoPhi", StaticData.IsCheck(Request.QueryString["ishaophi"]) ? "1" : "0");
        chitietbenhnhantoathuoc.data("IsBHYT_Save", StaticData.IsCheck(Request.QueryString["IsBHYT_Save"]) ? "1" : "0");
        chitietbenhnhantoathuoc.data("slton", Request.QueryString["slton"]);
        return chitietbenhnhantoathuoc;
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
        khambenhcanlamsan.data("maphieucls", Request.QueryString["maphieucls"]);
        khambenhcanlamsan.data("iddangkycls", Request.QueryString["iddangkycls"]);
        khambenhcanlamsan.data("IsBHYT_save", Request.QueryString["IsBHYT_save"]);
        return khambenhcanlamsan;
    }
    protected DataProcess s_sinhhieu()
    {
        DataProcess kb_sinhhieu = new DataProcess("sinhhieu");
        kb_sinhhieu.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        kb_sinhhieu.data("ngaydo", Request.QueryString["ngaydo"]);
        kb_sinhhieu.data("mach", Request.QueryString["mach"]);
        kb_sinhhieu.data("nhietdo", Request.QueryString["nhietdo"]);
        kb_sinhhieu.data("huyetap1", Request.QueryString["huyetap1"]);
        kb_sinhhieu.data("huyetap2", Request.QueryString["huyetap2"]);
        kb_sinhhieu.data("nhiptho", Request.QueryString["nhiptho"]);
        kb_sinhhieu.data("chieucao", Request.QueryString["chieucao"]);
        kb_sinhhieu.data("cannang", Request.QueryString["cannang"]);
        kb_sinhhieu.data("BMI", Request.QueryString["BMI"]);
        kb_sinhhieu.data("IdKhamBenh", Request.QueryString["idkhoachinh"]);
        return kb_sinhhieu;
    }
    protected DataProcess s_bacsi_ekip()
    {
        DataProcess kb_bacsi_ekip = new DataProcess("bacsi_ekip");
        kb_bacsi_ekip.data("id", Request.QueryString["idkhoachinh"]);
        kb_bacsi_ekip.data("idkhambenh", Request.QueryString["idkhambenh"]);
        kb_bacsi_ekip.data("idbacsi", Request.QueryString["idnhanvien"]);
        kb_bacsi_ekip.data("idvaitro", Request.QueryString["idvaitro"]);
        return kb_bacsi_ekip;
    }
    protected DataProcess nvk_chanDoanXuatKhoa()
    {
        DataProcess nvk_chanDoanXuatKhoa = new DataProcess("nvk_chanDoanXuatKhoa");
        nvk_chanDoanXuatKhoa.data("idCDXuatKhoa", Request.QueryString["idkhoachinh"]);
        nvk_chanDoanXuatKhoa.data("idxuatkhoa", Request.QueryString["idxuatkhoa"]);
        nvk_chanDoanXuatKhoa.data("idicd", Request.QueryString["idicd"]);
        string MoTaChanDoan_edit = Request.QueryString["mkv_idicdMoTa"];
        nvk_chanDoanXuatKhoa.data("MoTaChanDoan_XK", MoTaChanDoan_edit);
        return nvk_chanDoanXuatKhoa;
    }
    protected DataProcess nvk_benhnhanxuatkhoa()
    {

        #region khai báo tham số hướng diều trị
        string idXuatK = Request.QueryString["idxuatkhoa"];
        string idKBXK = Request.QueryString["idkhambenhxuatkhoa"];
        string NgayXK = Request.QueryString["ngayxuatvien"];
        if (string.IsNullOrEmpty(NgayXK))
            NgayXK = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        else
            NgayXK += " " + Request.QueryString["gioxuatvien"];
        #endregion
        DataProcess benhnhanxuatkhoa = new DataProcess("benhnhanxuatkhoa");
        benhnhanxuatkhoa.data("IdXuatKhoa", idXuatK);
        benhnhanxuatkhoa.data("NgayXuatKhoa", NgayXK);
        benhnhanxuatkhoa.data("IdKhoaXuat", Request.QueryString["idkhoa"]);
        benhnhanxuatkhoa.data("IdChiTietDangKyKham", Request.QueryString["idchitietdangkykham"]);
        benhnhanxuatkhoa.data("IdKhamBenhXK", idKBXK);
        benhnhanxuatkhoa.data("IdBenhNhan", Request.QueryString["idbenhnhan"]);
        benhnhanxuatkhoa.data("IdHuongDieuTri", "17");
        benhnhanxuatkhoa.data("IdKhoaChuyenDen", "0");
        benhnhanxuatkhoa.data("IdPhongChuyenDen", "0");
        benhnhanxuatkhoa.data("IdBVChuyenDen", "0");
        benhnhanxuatkhoa.data("PhuongPhapDT", Request.QueryString["txtPPDT"]);
        benhnhanxuatkhoa.data("LoiDanXuatKhoa", Request.QueryString["txtLoiDan"]);
        benhnhanxuatkhoa.data("ChanDoanXuatKhoa", Request.QueryString["idicd_ravien"]);
        benhnhanxuatkhoa.data("idtinhTrang", Request.QueryString["ddlTTXK"]);
        benhnhanxuatkhoa.data("LyDoXuatKhoa", Request.QueryString["txtLyDoXK"]);
        benhnhanxuatkhoa.data("isCoDieuDuongCV", "0");
        benhnhanxuatkhoa.data("isCoBacSiCV", "0");
        string MoTaCD_edit = Request.QueryString["mkv_mota_ravien"];
        benhnhanxuatkhoa.data("MoTaCD_edit", MoTaCD_edit);
        return benhnhanxuatkhoa;
    }
    protected DataProcess s_chitietbenhnhantoathuoc_XuatVien()
    {
        DataProcess chitietbenhnhantoathuoc = new DataProcess("chitietbenhnhantoathuoc");
        chitietbenhnhantoathuoc.data("idchitietbenhnhantoathuoc", Request.QueryString["idkhoachinh"]);
        chitietbenhnhantoathuoc.data("idbenhnhantoathuoc", Request.QueryString["idbenhnhantoathuoc"]);
        chitietbenhnhantoathuoc.data("idthuoc", Request.QueryString["idthuoc"]);
        chitietbenhnhantoathuoc.data("soluongke", Request.QueryString["soluongke"]);
        chitietbenhnhantoathuoc.data("soluongbanra", Request.QueryString["soluongbanra"]);
        chitietbenhnhantoathuoc.data("dongia", Request.QueryString["dongia"]);
        chitietbenhnhantoathuoc.data("ngayuong", Request.QueryString["ngayuong"]);
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
        chitietbenhnhantoathuoc.data("idkho", Request.QueryString["idkhoxuat"]);
        chitietbenhnhantoathuoc.data("soluongtra", Request.QueryString["soluongtra"]);
        chitietbenhnhantoathuoc.data("IsDaYeuCau", Request.QueryString["IsDaYeuCau"]);
        chitietbenhnhantoathuoc.data("IsDaXuatTra", Request.QueryString["IsDaXuatTra"]);
        chitietbenhnhantoathuoc.data("DoiTuongThuocID", Request.QueryString["DoiTuongThuocID"]);
        chitietbenhnhantoathuoc.data("isdathu", Request.QueryString["isdathu"]);
        chitietbenhnhantoathuoc.data("SoLuongTheoDonVi", Request.QueryString["SoLuongTheoDonVi"]);
        chitietbenhnhantoathuoc.data("cachdung", Request.QueryString["cachdung"]);
        chitietbenhnhantoathuoc.data("isdahuy", Request.QueryString["isdahuy"]);
        chitietbenhnhantoathuoc.data("ngayratoa", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
        chitietbenhnhantoathuoc.data("TienThucthu", Request.QueryString["TienThucthu"]);
        chitietbenhnhantoathuoc.data("idcachdung", Request.QueryString["idcachdung"]);
        chitietbenhnhantoathuoc.data("iddvt", Request.QueryString["iddvt"]);
        chitietbenhnhantoathuoc.data("istuan", Request.QueryString["istuan"]);
        chitietbenhnhantoathuoc.data("isngay", Request.QueryString["isngay"]);
        chitietbenhnhantoathuoc.data("issang", Request.QueryString["issang"]);
        chitietbenhnhantoathuoc.data("istrua", Request.QueryString["istrua"]);
        chitietbenhnhantoathuoc.data("ischieu", Request.QueryString["ischieu"]);
        chitietbenhnhantoathuoc.data("istoi", Request.QueryString["istoi"]);
        chitietbenhnhantoathuoc.data("iddvdung", Request.QueryString["iddvdung"]);
        chitietbenhnhantoathuoc.data("cateid", Request.QueryString["cateid"]);

        return chitietbenhnhantoathuoc;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savekhambenh(); break;
            case "setTimKiem": setTimKiem(); break;
            case "setTimKiem_KhamMoi": setTimKiem_KhamMoi(); break;
            case "setTimKiem_KhamMoiChuyenPhong": setTimKiem_KhamMoiChuyenPhong(); break;
            case "luuTablechitietbenhnhantoathuoc": LuuTablechitietbenhnhantoathuoc(); break;
            case "luuTablekhambenhcanlamsan": LuuTablekhambenhcanlamsan(); break;
            case "loadTablechitietbenhnhantoathuoc": loadTablechitietbenhnhantoathuoc(); break;
            case "loadTablekhambenhcanlamsan": loadTablekhambenhcanlamsan(); break;
            case "LuuTablechitietEkipBacSiMo": LuuTablekb_EkipBacsi(); break;
            case "xoa": Xoakhambenh(); break;
            case "xoachitietbenhnhantoathuoc": Xoachitietbenhnhantoathuoc(); break;
            case "xoakhambenhcanlamsan": Xoakhambenhcanlamsan(); break;
            case "chandoanbandausearch": chandoanbandausearch(); break;
            case "idthuocsearch": idthuocsearch(); break;
            case "congthucsearch": congthucsearch(); break;
            case "idcanlamsansearch": idcanlamsansearch(); break;
            case "idbacsisearch": idbacsisearch(); break;
            case "loaithuocidsearch": loaithuocidsearch(); break;
            case "doituongthuocidsearch": doituongthuocidsearch(); break;
            case "IdkhoaChuyenSearch": IdkhoaChuyenSearch(); break;
            case "banggiadichvuSearch": banggiadichvuSearch(); break;
            case "phongkhambenhSearch": phongkhambenhSearch(); break;
            case "ChonCLS": ChonCLS(); break;
            case "GetDSCLS": GetDSCLS(); break;
            case "loadTablechandoanphoihop": loadTablechandoanphoihop(); break;
            case "luuTongTienKham": luuTongTienKham(); break;
            case "idkhoasearch": idkhoasearch(); break;
            case "idphongsearch": idphongsearch(); break;
            case "cateidsearch": cateidsearch(); break;
            case "iddvtsearch": iddvtsearch(); break;
            case "iddvdungvsearch": iddvdungvsearch(); break;
            case "idcachdungsearch": idcachdungsearch(); break;
            case "TinhSoNgayRaToa": TinhSoNgayRaToa(); break;
            case "LoadChanDoanMoTaICD": LoadChanDoanMoTaICD(); break;
            case "LoadChanDoanMaICD": LoadChanDoanMaICD(); break;
            case "checkHSBA": checkHSBA(); break;
            case "ChonTT": ChonTT(); break;
            case "GetDSTT": GetDSTT(); break;
            case "loadbenhvien": loadbenhvien(); break;
            case "idkhoxuatsearch": idkhoxuatsearch(); break;
            case "idkhoxuatsearch_xk": idkhoxuatsearch_xk(); break;
            case "xuatthuoc": xuatthuoc(); break;
            case "HuyCLS": HuyCLS(); break;
            case "checkpass": checkpass(); break;
            case "loadlistphongmo": loadlistphongmo(); break;
            case "loadTablelistbacsi": loadTablelistbacsi(); break;
            case "idvaitrosearch": idvaitrosearch(); break;
            case "idnhanviensearch": idnhanviensearch(); break;
            case "loadTableAjaxchitietEkipMo": loadTablechitietbacsi_ekip(); break;
            case "XoaBacSiDieuTri": XoaBacSiDieuTri(); break;
            case "getkhoxuat": getkhoxuat(); break;
            case "idgiuongsearch": idgiuongsearch(); break;
            case "idphuongphapvocamsearch": idphuongphapvocamsearch(); break;
            case "ShowXuatVien": ShowXuatVien(); break;
            case "ChanDoanSearch": ChanDoanSearch(); break;
            case "chandoanravien": chandoanravien(); break;
            case "LuuXuatVien": LuuXuatVien(); break;
            case "LuuChanDoanPH_XK": LuuChanDoanPH_XK(); break;
            case "LuuToaThuocXuatVien": LuuToaThuocXuatVien(); break;
            case "HuyXuatVien": HuyXuatVien(); break;
            case "MakeSoVaoVien": MakeSoVaoVien(); break;
            case "showListTHChanDoan": showListTHChanDoan(); break;
            case "getListSLTON": GetListSLTon_RealTime(); break;

        }
    }
    #region XuatVienKhoaPhauThuat
    private void showListTHChanDoan()
    {
        string idkhambenh = Request.QueryString["idkhambenh"];
        string sqlSelect = @"SELECT IDBENHBHDONGTIEN 
                             FROM KHAMBENH A LEFT JOIN DANGKYKHAM B
                                    ON A.IDDANGKYKHAM=B.IDDANGKYKHAM 
                             WHERE A.IDKHAMBENH='" + idkhambenh + "'";
        DataTable dtTable = DataAcess.Connect.GetTable(sqlSelect);
        string idbenhbhdongtien = "";
        if (dtTable != null && dtTable.Rows.Count > 0)
        {
            idbenhbhdongtien = dtTable.Rows[0][0].ToString();
        }
        string sMaIcd = "";
        string sMota = "";
        System.Collections.Generic.List<string> list_Ma = new List<string>();
        System.Collections.Generic.List<string> list_MoTa = new List<string>();
        System.Collections.Generic.List<string> list_Idicd = new List<string>();
        StaticData_HS.nvk_setTongHopChanDoan(idbenhbhdongtien, true, ref sMaIcd, ref sMota, ref list_Ma, ref list_MoTa, ref list_Idicd);
        DataTable dtTHCD = new DataTable();
        dtTHCD.Columns.Add("STT", typeof(int));
        dtTHCD.Columns.Add("IdIcd", typeof(int));
        dtTHCD.Columns.Add("MaICD", typeof(string));
        dtTHCD.Columns.Add("MoTa", typeof(string));
        dtTHCD.Columns.Add("idCdXuatKhoa", typeof(string));
        for (int i = 0; i < list_Ma.Count; i++)
        {
            DataRow dr = dtTHCD.NewRow();
            dr["STT"] = i + 1;
            dr["IdIcd"] = list_Idicd[i];
            dr["MaICD"] = list_Ma[i];
            dr["MoTa"] = list_MoTa[i];
            dr["idCdXuatKhoa"] = null;
            dtTHCD.Rows.Add(dr);
        }
        string tableTHCD = strTableChanDoanPhoiHop_XK(dtTHCD);
        Response.Write(tableTHCD);
    }
    private void HuyXuatVien()
    {
        string idkhambenhxuatkhoa = Request.QueryString["idkhambenh_xk"];
        string idxuatkhoa = Request.QueryString["idxuatkhoa"];
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhambenhgoc = Request.QueryString["idkhambenh"];
        #region xoachitietbenhnhantoathuoc
        string sqlXoaCTBNTT = string.Format(@"DELETE FROM CHITIETBENHNHANTOATHUOC WHERE IDBENHNHANTOATHUOC IN (SELECT IDBENHNHANTOATHUOC FROM BENHNHANTOATHUOC WHERE IDKHAMBENH={0} AND IDBENHNHAN={1})", idkhambenhxuatkhoa, idbenhnhan);
        string sqlXoaBNTT = string.Format(@"DELETE FROM BENHNHANTOATHUOC WHERE IDBENHNHAN={0} AND IDKHAMBENH={1}", idbenhnhan, idkhambenhxuatkhoa);
        bool OK1 = DataAcess.Connect.ExecSQL(sqlXoaCTBNTT);
        if (!OK1)
        {
            Response.Clear();
            Response.Write("error=1");
            Response.StatusCode = 500;
            return;
        }
        bool OK2 = DataAcess.Connect.ExecSQL(sqlXoaBNTT);
        if (!OK2)
        {
            Response.Clear();
            Response.Write("error=2");
            Response.StatusCode = 500;
            return;
        }
        #endregion
        #region xoachandoanxuatkhoa
        string sqlXoaCDXK = string.Format(@"DELETE FROM NVK_CHANDOANXUATKHOA WHERE IDXUATKHOA={0}", idxuatkhoa);
        bool OK3 = DataAcess.Connect.ExecSQL(sqlXoaCDXK);
        if (!OK3)
        {
            Response.Clear();
            Response.Write("error=4");
            Response.StatusCode = 500;
            return;
        }
        #endregion
        #region xoabenhnhanxuatkhoa
        string sqlXoaBNXK = string.Format(@"DELETE FROM BENHNHANXUATKHOA WHERE IDXUATKHOA={0}", idxuatkhoa);
        bool OK4 = DataAcess.Connect.ExecSQL(sqlXoaBNXK);
        if (!OK4)
        {
            Response.Clear();
            Response.Write("error=5");
            Response.StatusCode = 500;
            return;
        }
        #endregion
        #region updatekhambenh
        string SQL_UPDATE_KHAMBENHGOC = string.Format(@"UPDATE KHAMBENH SET ISXUATVIEN=0 WHERE IDKHAMBENH={0}", idkhambenhgoc);
        bool OK5 = DataAcess.Connect.ExecSQL(SQL_UPDATE_KHAMBENHGOC);
        if (!OK5)
        {
            Response.Clear();
            Response.Write("error=5");
            Response.StatusCode = 500;
            return;
        }
        string SQL_UPDATE_KHAMBENH_XUATVIEN = string.Format(@"UPDATE KHAMBENH SET ISXUATVIEN=0 WHERE IDKHAMBENH={0}", idkhambenhxuatkhoa);
        bool OK6 = DataAcess.Connect.ExecSQL(SQL_UPDATE_KHAMBENH_XUATVIEN);
        if (!OK6)
        {
            Response.Clear();
            Response.Write("error=6");
            Response.StatusCode = 500;
            return;
        }
        #endregion
        if (OK1 && OK2 && OK3 && OK4 && OK5 && OK6)
        {
            Response.Clear();
            Response.Write("1");
            return;
        }
    }
    private void LuuXuatVien()
    {

        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idchitiedangkykham = Request.QueryString["idchitietdangkykham"];
        string idkhoa = Request.QueryString["idkhoa"];
        string ngayxuat = Request.QueryString["ngayxuatvien"];
        string gioXuat = Request.QueryString["gioxuatvien"];
        string idkhambenhgoc = Request.QueryString["idkhoachinh"];
        DataProcess benhnhanxuatkhoa = nvk_benhnhanxuatkhoa();
        #region Luu hướng diều trị
        string idHuongDT = benhnhanxuatkhoa.getData("IdHuongDieuTri");
        string LoiDanTThuoc = Request.QueryString["txtLoiDan"];
        if (string.IsNullOrEmpty(LoiDanTThuoc))
            LoiDanTThuoc = "";
        string idBacSiXK = "0";
        if (Request.QueryString["idbacsi_xk"] != null && Request.QueryString["idbacsi_xk"].ToString() != "")
            idBacSiXK = Request.QueryString["idbacsi_xk"].ToString();
        if (benhnhanxuatkhoa.getData("IdXuatKhoa") != null
            && !benhnhanxuatkhoa.getData("IdXuatKhoa").Equals("")
            && !benhnhanxuatkhoa.getData("IdXuatKhoa").Equals("0"))
        {
            #region cập nhật hướng điều trị
            bool ok = benhnhanxuatkhoa.Update();
            if (ok)
            {
                ok = CapNhatKhamBenhXuatKhoa(benhnhanxuatkhoa, ngayxuat, gioXuat, LoiDanTThuoc, idBacSiXK, idkhambenhgoc);
                if (!ok)
                {
                    benhnhanxuatkhoa.Delete();
                    Response.Clear(); Response.Write("");
                    return;
                }
            }
            #endregion
        }
        else
        {
            #region lưu mới bệnh nhân xuatkhoa
            bool ok = benhnhanxuatkhoa.Insert();
            if (ok)
            {
                ok = CapNhatKhamBenhXuatKhoa(benhnhanxuatkhoa, ngayxuat, gioXuat, LoiDanTThuoc, idBacSiXK, idkhambenhgoc);
                if (!ok)
                {
                    benhnhanxuatkhoa.Delete();
                    Response.Clear();
                    Response.Write("");
                    return;
                }
            }
            #endregion
        }
        if (idHuongDT.Equals("17"))
        {
            string sql = "update benhnhannoitru set IsDaNhap=0,isngoaitru=0 where idkhoanoitru='" + idkhoa + "' and idchitietdangkykham='" + idchitiedangkykham + "'";
            bool ktIsDaNhap = DataAcess.Connect.ExecSQL(sql);
            if (!ktIsDaNhap)
            {
                benhnhanxuatkhoa.Delete();
                Response.Clear();
                Response.Write("");
                return;
            }

        }

        #endregion
        Response.Clear();
        Response.Write(benhnhanxuatkhoa.getData("IdXuatKhoa"));
        return;
    }
    private bool CapNhatKhamBenhXuatKhoa(DataProcess bnxk, string ngayxuat, string GioXuat, string LoiDanTT, string idbacsi, string idkhambenhgoc)
    {

        string sqlUpdateKhambenh_XV = string.Format(@"UPDATE KHAMBENH SET IDBACSI={0},HUONGDIEUTRI={1}
                                    ,TGXUATVIEN='{2}',DANDO=N'{3}',MOTACD_EDIT=N'{4}',KETLUAN='{5}'
                                    ,IDKHAMBENHGOC={6},ISXUATVIEN=1,MAPHIEUKHAM='PKXV' WHERE IDKHAMBENH={7}",
                                    idbacsi, bnxk.getData("IDHUONGDIEUTRI"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                    LoiDanTT, bnxk.getData("MOTACD_EDIT"), bnxk.getData("CHANDOANXUATKHOA")
                                    , idkhambenhgoc, bnxk.getData("IDKHAMBENHXK"));
        string sqlUpdate_Khambenh_khoa_xuat = string.Format(@"UPDATE KHAMBENH SET IDKHAMBENHMOI={0} WHERE IDKHAMBENH={1}",
            bnxk.getData("IDKHAMBENHXK"), idkhambenhgoc);

        bool flag = false;
        bool ok_update_xv = DataAcess.Connect.ExecSQL(sqlUpdateKhambenh_XV);
        if (ok_update_xv)
        {
            bool ok_update_khoaxuat = DataAcess.Connect.ExecSQL(sqlUpdate_Khambenh_khoa_xuat);
            if (ok_update_khoaxuat)
            {
                flag = StaticData.TinhLaiTien_ByIdKhamBenh(bnxk.getData("IDKHAMBENHXK"));
            }
        }
        return flag;
    }
    private void LuuChanDoanPH_XK()
    {
        try
        {
            DataProcess process = nvk_chanDoanXuatKhoa();
            if (process.getData("idicd").Trim() == "")
            {
                Response.StatusCode = 500;
                return;
            }
            if (process.getData("idCDXuatKhoa") != null && process.getData("idCDXuatKhoa") != "" && process.getData("idCDXuatKhoa") != "0")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idCDXuatKhoa"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idCDXuatKhoa"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuToaThuocXuatVien()
    {
        try
        {

            DataProcess process = s_chitietbenhnhantoathuoc();
            #region Properties
            string idthuoc = Request.QueryString["idthuoc"];
            string tenthuoc = Request.QueryString["mkv_idthuoc"];
            string iddvt = Request.QueryString["iddvt"];
            string dvt = Request.QueryString["mkv_iddvt"];
            string idcachdung = Request.QueryString["idcachdung"];
            string cachdung = Request.QueryString["mkv_idcachdung"];
            string congthuc = Request.QueryString["mkv_congthuc"];
            string dvdung = Request.QueryString["mkv_iddvdung"];
            string loaithuocid = Request.QueryString["DoiTuongThuocID"];
            string loaithuoc = Request.QueryString["mkv_DoiTuongThuocID"];
            #endregion
            #region Check IDThuoc
            string Message = null;
            string IdThuoc_Save = null;
            bool OK_CheckThuoc = StaticData.AutoCheckSaveThuoc(idthuoc, tenthuoc, iddvt, dvt, idcachdung, cachdung
                                                                , congthuc, dvdung, loaithuocid, loaithuoc
                                                                , ref Message, ref IdThuoc_Save);
            if (!OK_CheckThuoc || idthuoc == null)
            {
                Response.StatusCode = 500;
                Response.Write(Message);
                return;
            }
            if (idthuoc != IdThuoc_Save)
            {
                process.data("idthuoc", IdThuoc_Save);
            }
            #endregion

            string idkhambenh = process.getData("idkhambenh");
            string sqlKhamBenh = "SELECT * FROM KHAMBENH WHERE IDKHAMBENH=" + idkhambenh;
            DataTable dtKhamBenh = DataAcess.Connect.GetTable(sqlKhamBenh);

            string TGXuatVien = dtKhamBenh.Rows[0]["TGXuatVien"].ToString();
            TGXuatVien = DateTime.Parse(TGXuatVien).ToString("dd/MM/yyyy hh:mm:ss");
            DataProcess benhnhantoathuoc = new DataProcess("benhnhantoathuoc");
            benhnhantoathuoc.data("idkhambenh", process.getData("idkhambenh"));
            benhnhantoathuoc.data("ngayratoa", TGXuatVien);
            benhnhantoathuoc.data("idbenhnhan", dtKhamBenh.Rows[0]["idbenhnhan"].ToString());
            benhnhantoathuoc.data("idbacsi", dtKhamBenh.Rows[0]["idbacsi"].ToString());
            string idbenhnhantoathuoc = null;
            DataTable dtBNTT = DataAcess.Connect.GetTable("SELECT IDBENHNHANTOATHUOC FROM BENHNHANTOATHUOC WHERE IDKHAMBENH=" + process.getData("idkhambenh"));
            if (dtBNTT != null && dtBNTT.Rows.Count > 0)
                idbenhnhantoathuoc = dtBNTT.Rows[0][0].ToString();
            benhnhantoathuoc.data("idbenhnhantoathuoc", idbenhnhantoathuoc);

            if (idbenhnhantoathuoc == null || idbenhnhantoathuoc == "")
            {
                bool InsertBNTT = benhnhantoathuoc.Insert();
                if (InsertBNTT == true)
                {
                    idbenhnhantoathuoc = benhnhantoathuoc.getData("idbenhnhantoathuoc");
                    process.data("idbenhnhantoathuoc", idbenhnhantoathuoc);
                }
            }
            else
            {
                benhnhantoathuoc.data("ngayratoa", DateTime.Now.ToString("dd/MM/yyyy"));
                benhnhantoathuoc.Update();
                process.data("idbenhnhantoathuoc", idbenhnhantoathuoc);
            }


            if (process.getData("idchitietbenhnhantoathuoc") != null && process.getData("idchitietbenhnhantoathuoc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {

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
    private void chandoanravien()
    {
        string loai = Request.QueryString["loai"];
        string TenSearch = Request.QueryString["q"];
        string sql = @"select top 20 idicd,maicd,mota from chandoanicd where ";
        if (loai.Equals("maicd"))
            sql += " maicd like N'" + TenSearch + "%'";
        else
            sql += " mota like N'%" + TenSearch + "%'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";

        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div>"
                       + "<div style=\"width:30%;height:30px;float:left\" >" + h["maicd"] + "</div>"
                       + "<div style=\"width:55%;height:30px;float:left\" >" + h["mota"] + "</div>"
                    + "</div>", h["idicd"], h["maicd"], h["mota"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void ShowXuatVien()
    {

        #region khaibaobien
        string idXuatKhoa = "";
        string idkhoa = "";
        idkhoa = Request.QueryString["IdKhoa"];
        string idchitietdangkykham = "";
        idchitietdangkykham = Request.QueryString["IdChiTietDangKyKham"];
        string idkhambenhgoc = Request.QueryString["IDKHAMBENHGOC"];
        string idKhamBenhXuatKhoa = "";
        string idbenhnhan = "";
        idbenhnhan = Request.QueryString["idbenhnhan"];
        #region tham số đã có(nếu có)
        DataTable dtBNXKdone = null;
        string NgayXKDone = DateTime.Now.ToString("dd/MM/yyyy");
        string GioXKDone = DateTime.Now.ToString("HH:mm:ss");
        string NgayTKDone = "";
        string GioTKDone = "08:00";
        string IdKhoaDone = "0";
        string idPhongDone = "0";
        string idBVDone = "";
        string MaBVDone = "";
        string TenBVDone = "";
        string idChanDoanDone = "";
        string MaChanDoanDone = "";
        string TenChanDoanDone = "";
        string idTinhTrangDone = "";
        string LyDoXKDone = "";
        string isCoDieuDuongCV = "";
        string isCoBacSiCV = "";
        string textPPDT = "";
        string textLoiDan = "";
        textLoiDan = @"Uống thuốc theo toa.
             @Hết thuốc tái khám";
        string idBacSiDone = "";
        string TenBacSiDone = "";
        #endregion
        #endregion
        #region tinhtrangxuatkhoa
        string sqlTinhTrang = "";
        DataTable dtTinhTrang = null;
        if (sqlTinhTrang.Equals(""))
            sqlTinhTrang = "select * from KB_TinhTrangXuatKhoa where idtinhtrang<>5 order by nvk_ttUT";
        else
            idTinhTrangDone = "5";
        dtTinhTrang = DataAcess.Connect.GetTable(sqlTinhTrang);

        //string nvk_layidxuatkhoa = "select idkb=isnull((select top 1 idkhambenh from khambenh where maphieukham=N'PKXK' and idchitietdangkykham ='" + idchitietdangkykham + "' and isnull(IsDaChuyenKhoa,0)=2 and idphongkhambenh='" + idkhoa + "' order by ngaykham desc),0)";
        //if (Request.QueryString["SuaXK"] != null)
        //    nvk_layidxuatkhoa = "select idkb=isnull((select top 1 idkhambenh from khambenh where maphieukham=N'PKXK' and idchitietdangkykham ='" + idchitietdangkykham + "' and idphongkhambenh='" + idkhoa + "' order by ngaykham desc),0)";
        //idKhamBenhXuatKhoa = DataAcess.Connect.GetTable(nvk_layidxuatkhoa).Rows[0][0].ToString();

        string SQL_CHECK_IDXUATKHOA = string.Format(@"SELECT IDXUATKHOA=ISNULL((SELECT IDKHAMBENH 
                                        FROM KHAMBENH WHERE IDKHAMBENHGOC={0} AND IDCHITIETDANGKYKHAM={1} 
                        AND IDPHONGKHAMBENH={2} AND MAPHIEUKHAM=N'PKXV'),0)", idkhambenhgoc, idchitietdangkykham, idkhoa);
        idKhamBenhXuatKhoa = DataAcess.Connect.GetTable(SQL_CHECK_IDXUATKHOA).Rows[0][0].ToString();
        if (idKhamBenhXuatKhoa.Equals("0"))
        {
            #region tạo mới khám bệnh tại khoa để xuất (nếu nhập khoa nhưng chưa có phiếu khám nào  tại khoa)

            DataTable dt_Ctdkk = DataAcess.Connect.GetTable(@"select iddangkykham
                    ,huongdieutri= isnull((select top 1 huongdieutri from khambenh where idchitietdangkykham ='" + idchitietdangkykham + "' and idkhoa ='" + idkhoa + @"' order by ngaykham desc),8)
                    ,idkbgoc=(select top 1 idkhambenh from khambenh where idchitietdangkykham ='" + idchitietdangkykham + @"')
                     from chitietdangkykham ct where idchitietdangkykham ='" + idchitietdangkykham + @"'");
            idKhamBenhXuatKhoa = nvk_addNewKhamBenhByKhoa_Hdt(idbenhnhan, dt_Ctdkk.Rows[0]["iddangkykham"].ToString(), idchitietdangkykham, idkhoa, dt_Ctdkk.Rows[0]["huongdieutri"].ToString(), idkhoa, dt_Ctdkk.Rows[0]["idkbgoc"].ToString());
            #endregion
        }
        else
        {
            #region Bác sĩ đã cho xuất khoa
            string sqlBs = @"
                    select bs.* from khambenh kb inner join bacsi bs on bs.idbacsi= kb.idbacsi where kb.idkhambenh ='" + idKhamBenhXuatKhoa + "'";
            DataTable dtBS = DataAcess.Connect.GetTable(sqlBs);
            if (dtBS != null && dtBS.Rows.Count > 0)
            {
                idBacSiDone = dtBS.Rows[0]["idbacsi"].ToString();
                TenBacSiDone = dtBS.Rows[0]["tenbacsi"].ToString();
            }
            #endregion
        }
        #region thông tin Bác sĩ cho xuất khoa
        string SQL_SELECT_BACSI = @"
                    select bs.* from (
	                    select idbacsi = isnull(
	                    (select top 1 idbacsi from khambenh where idchitietdangkykham ='" + idchitietdangkykham + @"' and isnull(idbacsi,0)>0 order by idkhambenh desc)
	                    ,(select top 1 idbacsiNhap from benhnhannoitru where idchitietdangkykham ='" + idchitietdangkykham + @"' and isnull(idbacsiNhap,0)>0 order by ngayvaovien desc)
	                    )
                    )
                    as abc inner join bacsi bs on bs.idbacsi= abc.idbacsi";
        DataTable dtTableBS = DataAcess.Connect.GetTable(SQL_SELECT_BACSI);
        if (dtTableBS != null && dtTableBS.Rows.Count > 0)
        {
            idBacSiDone = dtTableBS.Rows[0]["idbacsi"].ToString();
            TenBacSiDone = dtTableBS.Rows[0]["tenbacsi"].ToString();
        }
        #endregion
        #endregion
        #region toaxuatvien
        string tableToaThuocXuatVien = "";
        tableToaThuocXuatVien = loadTableToaThuocXuatVien(idKhamBenhXuatKhoa);
        #endregion
        #region kiemtraxuatkhoa
        string sqlBNXK = "select * from benhnhanxuatkhoa where idkhoaxuat='" + idkhoa + "' and idkhambenhXK='" + idKhamBenhXuatKhoa + "'";
        DataTable dtIsDaxuat = DataAcess.Connect.GetTable(sqlBNXK);
        if (dtIsDaxuat.Rows.Count > 0)
        {
            sqlBNXK = @"select xk.IdXuatKhoa,xk.IdKhamBenhXK,xk.IdKhoaChuyenDen,xk.IdPhongChuyenDen,xk.IdBVChuyenDen,bv.mabenhvien,bv.tenbenhvien
                        ,cd.idicd,cd.MaICD,MoTa=isnull(xk.MoTaCD_edit,cd.MoTa)
                        ,xk.PhuongPhapDT,xk.LoiDanXuatKhoa,xk.idtinhTrang,xk.LyDoXuatKhoa
                        ,isCoDieuDuongCV=convert(int,isnull(isCoDieuDuongCV,0)),isCoBacSiCV=convert(int,isnull(isCoBacSiCV,0))
                        ,ngayXK= convert(varchar(10),xk.NgayXuatKhoa,103)
                        ,gioXK= convert(varchar(8),xk.NgayXuatKhoa,108)
                        ,ngayTK= isnull( (select convert(varchar(10),NgayHenTaiKham,103) from nvk_hentaikham where idKhamBenhHenTK='" + idKhamBenhXuatKhoa + @"'),'')
                        ,gioTK=  isnull( (select convert(varchar(5),NgayHenTaiKham,108) from nvk_hentaikham where idKhamBenhHenTK='" + idKhamBenhXuatKhoa + @"'),'08:00')
                         from benhnhanxuatkhoa xk left join benhvien bv on bv.idbenhvien=xk.IdBVChuyenDen
                        left join chandoanicd cd on cd.idicd=convert(int,isnull(xk.chandoanxuatkhoa,0))
                         where idxuatkhoa='" + dtIsDaxuat.Rows[0]["idxuatkhoa"] + "'";
            dtBNXKdone = DataAcess.Connect.GetTable(sqlBNXK);
            if (dtBNXKdone.Rows.Count > 0)
            {
                idXuatKhoa = dtBNXKdone.Rows[0]["IdXuatKhoa"].ToString();
                NgayXKDone = dtBNXKdone.Rows[0]["ngayXK"].ToString();
                GioXKDone = dtBNXKdone.Rows[0]["gioXK"].ToString();
                NgayTKDone = dtBNXKdone.Rows[0]["ngayTK"].ToString();
                GioTKDone = dtBNXKdone.Rows[0]["gioTK"].ToString();
                IdKhoaDone = dtBNXKdone.Rows[0]["IdKhoaChuyenDen"].ToString();
                idPhongDone = dtBNXKdone.Rows[0]["IdPhongChuyenDen"].ToString();
                idBVDone = dtBNXKdone.Rows[0]["IdBVChuyenDen"].ToString();
                MaBVDone = dtBNXKdone.Rows[0]["mabenhvien"].ToString();
                TenBVDone = dtBNXKdone.Rows[0]["tenbenhvien"].ToString();
                idChanDoanDone = dtBNXKdone.Rows[0]["idicd"].ToString();
                MaChanDoanDone = dtBNXKdone.Rows[0]["MaICD"].ToString();
                TenChanDoanDone = dtBNXKdone.Rows[0]["MoTa"].ToString();
                textPPDT = dtBNXKdone.Rows[0]["PhuongPhapDT"].ToString();
                textLoiDan = dtBNXKdone.Rows[0]["LoiDanXuatKhoa"].ToString();
                idTinhTrangDone = dtBNXKdone.Rows[0]["idtinhTrang"].ToString();
                LyDoXKDone = dtBNXKdone.Rows[0]["LyDoXuatKhoa"].ToString();
                isCoDieuDuongCV = dtBNXKdone.Rows[0]["isCoDieuDuongCV"].ToString();
                isCoBacSiCV = dtBNXKdone.Rows[0]["isCoBacSiCV"].ToString();
            }
        }
        #endregion
        #region chandoanphoihop
        string tableCdPh = "";
        DataTable dtCDPH = DataAcess.Connect.GetTable("select ct.*,cd.maicd,mota= isnull(MoTaChanDoan_XK,cd.mota) from nvk_chanDoanXuatKhoa ct inner join chandoanicd cd on cd.idicd=ct.idicd where ct.idxuatkhoa='" + idXuatKhoa + "'");
        tableCdPh = strTableChanDoanPhoiHop_XK(dtCDPH);
        #endregion
        StringBuilder html = new StringBuilder();
        html.Append("<div id='xuatvien' class='xuatvien'>");
        html.Append("<fieldset>");
        html.Append("<legend>Lưu thông tin");
        html.Append("</legend>");
        html.Append("<div class='div-Out' style='width:47%'>");
        html.Append("<h4>Ngày giờ xuất viện </h4>");
        html.Append("<p><input type='text' id='ngayxuatvien' mkv='true' style='width:29%' value='" + NgayXKDone + "' /><input type='text' style='width:20%' id='gioxuatvien' mkv='true' value='" + GioXKDone + "' /></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:53%'>");
        html.Append("<h4>Bác sĩ</h4>");
        html.Append("<p style='width:90%;'><input type='hidden' id='idbacsi_xk' mkv='true' value='" + idBacSiDone + "' /><input type='text' id='mkv_idbacsi_xk' onfocus='idbacsisearch_xk(this);' mkv='true' style='width:51%' class='down_select' value='" + TenBacSiDone + "' /></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:100%;height:auto;'>");
        html.Append("<h4>Chẩn đoán ra viện</h4>");
        html.Append("<p style='width:81.2%;'><input id='idicd_ravien' type='hidden' mkv='true' value='" + idChanDoanDone + "' /><input type='text' id='mkv_maicd_ravien' onfocus=\"chandoanravien(this,'maicd');\" style='width:10%' mkv='true' value='" + MaChanDoanDone + "' /><input type='text' id='mkv_mota_ravien' onfocus=\"chandoanravien(this,'mota');\" style='width:60%' mkv='true' value='" + TenChanDoanDone + "' /></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:100%;height:auto;'>");
        html.Append("<h4 style='position:absolute; top:0; left:0'>Chẩn đoán kèm theo </h4>");
        html.Append("<input type='button' id='btnChanDoanTH' value='Tổng hợp chẩn đoán' style='position:absolute; top:-20%; right:2%;' onclick='showListTHChanDoan();' /><div id='tableAjaxChanDoanPHXK' style='width:78%; padding-right:3%; float:right;padding-top:1.5%;'>" + tableCdPh + "</div>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:100%;height:auto;'>");
        html.Append("<h4 style='position:absolute; top:0; left:0;'>Toa thuốc xuất viện</h4>");
        html.Append("<div id='tableAjaxToaThuocXuatVien' style='width:100%; padding-right:0.5%; float:right; padding-top:1.5%;'>" + tableToaThuocXuatVien + "</div>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:100%;height:auto;'>");
        html.Append("<h4>Phương pháp điều trị</h4>");
        html.Append("<p style='width:81.2%'><textarea id='txtPPDT' style='width:95%; height:30px' mkv='true'>" + textPPDT + "</textarea></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:100%;height:auto;'>");
        html.Append("<h4>Lời dặn của thầy thuốc</h4>");
        html.Append("<p style='width:81.2%'><textarea id='txtLoiDan' mkv='true' style='width:95%; height:30px'>" + textLoiDan + "</textarea></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:100%; height:auto;'>");
        html.Append("<h4>Tình trạng xuất khoa</h4>");
        html.Append("<p style='width:81.2%'><select id='ddlTTXK' mkv='true'><option value='0' " + (idTinhTrangDone == "0" ? "selected = selected" : "")
            + @">---Chọn tình trạng---</option>");
        if (dtTinhTrang != null && dtTinhTrang.Rows.Count > 0)
        {
            for (int i = 0; i < dtTinhTrang.Rows.Count; i++)
            {
                html.Append("<option value='" + dtTinhTrang.Rows[i]["idtinhtrang"] + "'" + (idTinhTrangDone == dtTinhTrang.Rows[i]["idtinhtrang"].ToString() ? "selected = selected" : "") + @" >" + dtTinhTrang.Rows[i]["tentinhtrang"] + "</option>");
            }
        }
        html.Append("</select></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:100%; height:auto;'>");
        html.Append("<h4>Lý do xuất khoa</h4>");
        html.Append("<p style='width:81.2%'><textarea id='txtLyDoXK' mkv='true' style='height:30px; width:95%;float:left;'>" + LyDoXKDone + "</textarea></p>");
        html.Append("</div>");
        html.Append("</fieldset>");
        html.Append("<div style='width:100%; margin:0 auto; clear:both; margin-top:5px; text-algin:center;'>");
        html.Append("<input type='button' id='btnLuuXV' style='margin:2px;padding:2px; width:100px; background: #ddd' value='Lưu xuất viện' onclick=\"XuatVien(this);\"  />");
        html.Append("<input type='button' id='btnInPhieuRaVien' style='margin:2px;padding:2px; width:100px; background: #ddd;" + (idXuatKhoa != "" ? "" : "display:none") + "' value='In phiếu ra viện' onclick=\"InPhieuRavien(" + idKhamBenhXuatKhoa + "," + idkhoa + ");\"  />");
        html.Append("<input type='button' id='btnInToaRaVien' style='margin:2px;padding:2px; width:100px; background: #ddd; " + (idXuatKhoa != "" ? "" : "display:none") + "' value='In toa ra viện' onclick=\"InToaThuocRaVien(" + idKhamBenhXuatKhoa + "," + idkhoa + ");\"  />");
        html.Append("<input type='button' id='btnHuyXuatVien' style='margin:2px;padding:2px; width:100px; background: #ddd;; " + (idXuatKhoa != "" ? "" : "display:none") + "' value='Hủy xuất viện' onclick=\"HuyXuatVien();\"  />");
        html.Append("<input type='hidden' id='idxuatkhoa' value='" + idXuatKhoa + "' mkv='true' />");
        html.Append("<input type='hidden' id='idkhambenhxuatkhoa' value='" + idKhamBenhXuatKhoa + "' mkv='true' />");
        html.Append("</div>");
        html.Append("</div>");
        Response.Clear();
        Response.Write(html);
    }
    private void ChanDoanSearch()
    {
        string IsMaICD = Request.QueryString["IsMaICD"];
        string TenSearch = Request.QueryString["q"];
        string sql = @"select top 20 idicd,maicd,mota from chandoanicd where ";
        if (IsMaICD.Equals("1"))
            sql += " maicd like N'" + TenSearch + "%'";
        else
            sql += " mota like N'%" + TenSearch + "%'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";

        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div>"
                       + "<div style=\"width:30%;height:30px;float:left\" >" + h["maicd"] + "</div>"
                       + "<div style=\"width:55%;height:30px;float:left\" >" + h["mota"] + "</div>"
                    + "</div>", h["idicd"], h["maicd"], h["mota"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    #region table chẩn đoán xuất khoa
    private string strTableChanDoanPhoiHop_XK(DataTable dt)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTableCDPH_xk\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaICD") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MoTaICD") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        if (dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + (i + 1) + "</td>");
                html.Append("<td><a onclick='xoaontableCDPH_XK(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                html.Append("<td style='width:20%'><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idicd"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='" + dt.Rows[i]["MaICD"] + "' class='down_select' style='width:90%'/></td>");
                html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='" + dt.Rows[i]["mota"] + "' class='down_select' style='width:95%'/></td>");
                html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[i]["idCdXuatKhoa"] + "'/></td>");
                html.Append("</tr>");
            }
        }
        html.Append("<tr>");
        html.Append("<td>" + (dt.Rows.Count + 1) + "</td>");
        html.Append("<td><a onclick='xoaontableCDPH_XK(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td style='width:20%'><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='' class='down_select' style='width:90%'/></td>");
        html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='' class='down_select' style='width:95%'/></td>");
        html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
        html.Append("</tr>");
        html.Append("</table>");
        return html.ToString();
    }
    #endregion
    #region toa thuoc xuat vien
    public string loadTableToaThuocXuatVien(string idkhambenh)
    {
        string sqlSelect = @"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                            ,A.tenthuoc
                                ,B.LoaiThuocID
                               ,B.MaLoai
                               ,C.tencachdung
                               ,D.TenDVT as DVT
                               ,E.TenDVT as DVDung
                               ,F.catename,
                                F.CateId,
                               A.CongThuc,
                                A.sudungchobh,
                                k.tenkho
                              from chitietbenhnhantoathuoc T
                                left join thuoc  A on T.idthuoc=A.idthuoc
                                left join Thuoc_LoaiThuoc  B on T.DoiTuongThuocID=B.LoaiThuocID
                                left join Thuoc_CachDung  C on T.idcachdung=C.idcachdung
                                left join Thuoc_DonViTinh  D on T.iddvt=D.Id
                                left join Thuoc_DonViTinh  E on T.iddvdung=E.Id
                                left join category  F on T.cateid=F.cateid
                         left join khothuoc k on k.idkho = T.idkho 
                    where T.idkhambenh='" + idkhambenh + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        return loadTablechitietbenhnhantoathuoc_xuatvien(table, null, true);
    }
    #endregion
    #region  tạo mới khám bệnh tại khoa
    private string nvk_addNewKhamBenhByKhoa_Hdt(string idbenhnhan, string iddkk, string idctdkk_, string idkhoa, string huongdieutri, string phongkhamchuyenden, string idkbGoc)
    {
        string sqlInsert_KB = @"
                insert into khambenh(
                maphieukham
                ,ngaykham
                ,idbenhnhan
                ,iddangkykham
                ,IdChiTietDangKyKham
                ,huongdieutri
                ,phongkhamchuyenden
                ,idkhambenhgoc
                ,idphongkhambenh
                ,IsDaChuyenKhoa
                )
                values (
                N'PKXV',getdate()
                ,'" + idbenhnhan + "'," + iddkk + "," + idctdkk_ + @"
                ,'" + huongdieutri + "','" + phongkhamchuyenden + "','" + idkbGoc + "','" + idkhoa + @"'
                ,2)";
        bool kt = DataAcess.Connect.ExecSQL(sqlInsert_KB);
        if (kt)
        {
            string idkhambenh_new = DataAcess.Connect.GetTable("select max(idkhambenh) from khambenh").Rows[0][0].ToString();
            return idkhambenh_new;
        }
        return null;
    }
    #endregion
    #region Load_ToaThuocXuatVien
    private string loadTablechitietbenhnhantoathuoc_xuatvien(DataTable table, string[] arrslvack, bool idctbntt)
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string loaidk = Request.QueryString["loaidk"];
        string html = "";
        html += "<table class='jtable_xk' id=\"gridTable_xk\">";
        html += "<tr style='font-size:12px'>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th style='" + (idkhoa == "1" ? "display:none" : "") + "'>Kho xuất</th>";
        html += "<th>Đối tượng</th>";
        html += "<th>Tên thuốc/VTYT/HC</th>";
        html += "<th>ĐVT</th>";
        html += "<th>SL</th>";
        html += "<th>Cách dùng</th>";
        html += "<th>Ngày dùng</th>";
        html += "<th>Mỗi lần</th>";
        html += "<th>Đ.V Dùng</th>";
        html += "<th>Sáng</th>";
        html += "<th>Trưa</th>";
        html += "<th>Chiều</th>";
        html += "<th>Tối</th>";
        html += "<th>Ghi chú</th>";
        html += "<th>Dùng theo</th>";
        html += "<th style='" + (loaidk == "1" ? "" : "display:none") + "'>?Trong dm</th>";
        html += "<th style='" + (loaidk == "1" ? "" : "display:none") + "'>?Thỏa đk</th>";
        html += "<th>?Hao phí</th>";
        html += "<th>SL.Tồn</th>";
        html += "<th></th>";
        html += "</tr>";
        bool add = true;
        bool search = true; ;
        if (search)
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            process.Page = Request.QueryString["page"];

            if (table != null && table.Rows.Count > 0)
            {

                bool delete = true;
                bool edit = true;
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    string idkhoachinh = "";
                    if (arrslvack != null)
                    {
                        for (int y = 0; y < arrslvack.Length; y++)
                        {
                            if (arrslvack[y].Split('^')[0].ToString() == table.Rows[i]["idthuoc"].ToString() && (int.Parse(arrslvack[y].Split('^')[1].ToString()) > 1 || arrslvack[y].Split('^')[2].ToString() != ""))
                            {

                                idkhoachinh = arrslvack[y].Split('^')[2].ToString();
                                break;
                            }
                        }
                    }
                    bool IsSuDungChoBH = StaticData.IsCheck(table.Rows[i]["sudungchobh"].ToString());
                    bool IsBHYT_Save = StaticData.IsCheck(table.Rows[i]["IsBHYT_Save"].ToString());
                    html += "<tr style='background-color:" + (IsSuDungChoBH == true ? "" : "#CAE3FF") + ";'>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                    html += "<td style='" + (idkhoa == "1" ? "display:none" : "") + "'><input mkv='true' id='idkhoxuat' type='hidden' value='" + table.Rows[i]["idkho"] + "'/><input mkv='true' id='mkv_idkhoxuat' type='text'  type='text' onfocusout='chuyenformout(this)' onfocus='idkhoxuatsearch_xk(this);' style='width:70px' value='" + table.Rows[i]["tenkho"].ToString() + "' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='DoiTuongThuocID' type='hidden' value='" + table.Rows[i]["LoaiThuocID"] + "'/><input mkv='true' id='mkv_DoiTuongThuocID' type='text' value='" + table.Rows[i]["MaLoai"].ToString() + "' onfocus='loaithuocidsearch_xk(this);' style='width:70px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' id='mkv_idthuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='idthuocsearch_xk(this,1);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='iddvt' type='hidden' value='" + table.Rows[i]["iddvt"] + "'/><input mkv='true' id='mkv_iddvt' type='text' value='" + table.Rows[i]["DVT"].ToString() + "' onfocus='iddvtsearch(this);' style='width:50px; text-align:center;' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongke"].ToString() + "' style='width:30px' onblur='TestSo(this,false,false);kiemtraton(this);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idcachdung' type='hidden' value='" + table.Rows[i]["idcachdung"] + "'/><input mkv='true' id='mkv_idcachdung'  type='text' value='" + table.Rows[i]["tencachdung"].ToString() + "' onfocus='idcachdungsearch(this);' style='width:30px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "'  style='width:30px' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  style='width:30px' value='" + table.Rows[i]["moilanuong"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='iddvdung' type='hidden' value='" + table.Rows[i]["iddvdung"] + "'/><input mkv='true' id='mkv_iddvdung' type='text' value='" + table.Rows[i]["DVDung"].ToString() + "' onfocus='iddvtsearch(this);'  style='width:50px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='issang' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["issang"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='istrua' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istrua"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ischieu' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["ischieu"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='istoi' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istoi"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyendong(this);chuyenphim(this);' onblur='chuyenhuong(this);'  value='" + table.Rows[i]["ghichu"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td style='width:15%'>Ngày<input mkv='true' id='isngay' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["isngay"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/>Tuần<input mkv='true' id='istuan' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istuan"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='sudungchobh' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (IsSuDungChoBH ? "checked='checked' " : "") + " disabled='disabled' /></td>";
                    html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='IsBHYT_save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + ((IsBHYT_Save && IsSuDungChoBH) ? "checked='checked'" : "disabled='disabled'") + " /></td>";
                    html += "<td><input mkv='true' id='ishaophi' type='checkbox' " + (StaticData.IsCheck(table.Rows[i]["ishaophi"].ToString()) ? "checked" : "") + " " + (!edit ? "disabled" : "") + " onblur='chuyenhuong(this);' /></td>";
                    html += "<td style='width:5%'><input mkv='false' id='SLTON' type='text' onfocusout='chuyenformout(this)' style='width:20px' onfocus='chuyendong(this);chuyenphim(this);' onblur='chuyenhuong(this);'  value='" + "" + "' " + (1 == 1 ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idctbntt ? table.Rows[i]["idchitietbenhnhantoathuoc"] : idkhoachinh) + "'/><input mkv='true' id='idkho' type='hidden' value='" + table.Rows[i]["idkho"].ToString() + "'/></td>";
                    html += "<td><input mkv='false' id='IsCheckSLTon' type='hidden' value='" + "0" + "'/></td>";
                    html += "</tr>";
                }
            }
        }
        if (add)
        {
            html += "<tr>";
            html += "<td>" + ((table.Rows.Count > 0 && table != null) ? table.Rows.Count + 1 : 1) + "</td>";
            html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td style='" + (idkhoa == "1" ? "display:none" : "") + "'><input mkv='true' id='idkhoxuat' type='hidden' value=''/><input mkv='true' id='mkv_idkhoxuat' type='text' onfocusout='chuyenformout(this)' onfocus='idkhoxuatsearch_xk(this);' style='width:70px' class=\"down_select\" /></td>";
            html += "<td><input mkv='true' id='DoiTuongThuocID' type='hidden' value=''/><input mkv='true' id='mkv_DoiTuongThuocID' type='text' value='' onfocus='loaithuocidsearch_xk(this);' style='width:70px' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus='idthuocsearch_xk(this,1);' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='iddvt' type='hidden' value=''/><input mkv='true' id='mkv_iddvt' type='text' value='' onfocus='iddvtsearch(this);' style='width:50px; text-algin:center;' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:30px' value='' onblur='TestSo(this,false,false);kiemtraton(this);' /></td>";
            html += "<td><input mkv='true' id='idcachdung' type='hidden' value=''/><input mkv='true' id='mkv_idcachdung' type='text' value='' onfocus='idcachdungsearch(this);'  style='width:50px' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:40px' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  style='width:30px' value='' /></td>";
            html += "<td><input mkv='true' id='iddvdung' type='hidden' value=''/><input mkv='true' id='mkv_iddvdung' type='text' value='' onfocus='iddvtsearch(this);'  style='width:50px' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='issang' type='checkbox'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='istrua' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='ischieu' type='checkbox'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='istoi' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)'  style='width:70px' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='chuyenhuong(this);' /></td>";
            html += "<td style='width:15%'>Ngày<input mkv='true' id='isngay' type='checkbox' checked='true'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' />Tuần<input mkv='true' id='istuan' type='checkbox'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='sudungchobh' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  /></td>";
            html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='IsBHYT_save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  /></td>";
            html += "<td><input mkv='true' id='ishaophi' type='checkbox' onblur='chuyenhuong(this);' /></td>";
            html += "<td style='width:5%'><input mkv='false' id='SLTON' type='text' onfocusout='chuyenformout(this)' style='width:20px' onfocus='chuyendong(this);chuyenphim(this);' onblur='chuyenhuong(this);'  value='" + "" + "' " + (1 == 1 ? "disabled" : "") + "/></td>";
            html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/><input mkv='true' id='idkho' type='hidden' value=''/></td>";
            html += "<td><input mkv='false' id='IsCheckSLTon' type='hidden' value='" + "0" + "'/></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
        html += "</table>";
        if (!search)
            html += "Bạn không có quyền xem.";

        return html;
    }
    #endregion
    #endregion
    private void idphuongphapvocamsearch()
    {
        string sqlppvc = @"select * from phuongphapvocam";
        DataTable table = DataAcess.Connect.GetTable(sqlppvc);
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
    private void idgiuongsearch()
    {
        string idphong = Request.QueryString["idphong"];
        string sqlGiuong = @"select * from kb_giuong where giuongcode like N'" + Request.QueryString["q"] + "%'";
        if (idphong != null && idphong != "")
            sqlGiuong += " and idphong=" + idphong;
        sqlGiuong += "   order by giuongid desc";

        DataTable table = DataAcess.Connect.GetTable(sqlGiuong);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}",
                                     "<div style=\"width:100%;height:30px\">"
                                         + "<div style=\"width:40%;float:left;height:30px\" >" + row["giuongcode"] + "</div>"
                         + "<div style=\"width:60%;float:left;height:30px\" >" + row["loaigiuong"] + "</div>"
                                     + "</div>", row["giuongcode"], row["giuongid"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idvaitrosearch()
    {
        string sqlBS_VT = @"select * from bacsi_vaitro order by tenvaitro desc";
        DataTable table = DataAcess.Connect.GetTable(sqlBS_VT);
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
    private void idnhanviensearch()
    {
        string sqlNV = @"SELECT * FROM NHANVIEN where tennhanvien like N'%" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlNV);
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
    private void loadlistphongmo()
    {
        DataTable dtPhong = null;
        if (StaticData.EnableChuyenKhoa)
            dtPhong = StaticData.dtPhong_ByChuyenKhoa("'" + Request.QueryString["banggiadichvu"] + "'", null);
        else
            dtPhong = StaticData.dtPhong_ByKhoa("'" + Request.QueryString["Idkhoa"] + "'");
        DataTable table = dtPhong;
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i]["TenPhongFull"].ToString() + "" + "" + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void checkpass()
    {
        string pass = Request.QueryString["pass"];
        string sql = "select matkhau from nguoidung where idnguoidung='" + SysParameter.UserLogin.UserID(this) + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        // if (dt != null && dt.Rows.Count > 0 && pass == dt.Rows[0][0].ToString().Trim())
        if (dt != null && dt.Rows.Count > 0 && pass == "betran")
        {
            Response.Clear();
            Response.Write("true");
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("Mật khẩu không đúng !");
            return;
        }
    }
    private void HuyCLS()
    {
        string idkhambenhcanlamsan = Request.QueryString["idkhambenhcanlamsan"];
        string idkhambenh = Request.QueryString["idkhambenh"];
        string idcanlamsan = Request.QueryString["idcanlamsan"];
        string sqlUpdate = @"UPDATE KHAMBENHCANLAMSAN SET DAHUY=1 WHERE IDKHAMBENHCANLAMSAN='" + idkhambenhcanlamsan + "' AND IDKHAMBENH='" + idkhambenh + "' AND IDCANLAMSAN='" + idcanlamsan + "'";
        bool ok = DataAcess.Connect.ExecSQL(sqlUpdate);
        if (!ok)
        {
            Response.Clear();
            Response.Write("Không thể thực hiện việc hủy");
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("Đã hủy thành công");
            return;
        }
    }
    private void xuatthuoc()
    {
        myInsertPhieuXuatKho.XuatTheoToa(this);
    }
    private void idkhoxuatsearch_xk()
    {
        string xuatvien = Request.QueryString["isxuatvien"];
        string idkhoa = Request.QueryString["idkhoa"];
        string sqlKhoXuat = @"select * from khothuoc where idkhoa='" + idkhoa + "' and  tenkho like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlKhoXuat);
        if (StaticData.IsCheck(xuatvien))
        {
            DataRow r = table.NewRow();
            r["makho"] = "PT.BHYT";
            r["tenkho"] = "Quầy PT.BHYT";
            r["idkho"] = StaticData.KhoThuocBHYT;
            table.Rows.InsertAt(r, 0);
        }
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:30px\" >" + row["makho"].ToString() + "</div>"
                                         + "<div style=\"width:65%;float:left;height:30px\" >" + row["tenkho"].ToString() + "</div>"
                                     + "</div>", row["idkho"], row["makho"], row["tenkho"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idkhoxuatsearch()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string sqlKhoXuat = @"select * from khothuoc where idkhoa='" + idkhoa + "' and  tenkho like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlKhoXuat);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:30px\" >" + row["makho"].ToString() + "</div>"
                                         + "<div style=\"width:65%;float:left;height:30px\" >" + row["tenkho"].ToString() + "</div>"
                                     + "</div>", row["idkho"], row["makho"], row["tenkho"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void getkhoxuat()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string sqlKhoXuat = @"select * from khothuoc where idkhoa='" + idkhoa + "' and  tenkho like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlKhoXuat);
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
    private void loadbenhvien()
    {
        string sqlSelect = @"SELECT * FROM BENHVIEN WHERE TENBENHVIEN LIKE N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
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
    private void GetDSTT()
    {
        try
        {
            string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
            string slvack = Request.QueryString["slvack"];
            string lstTT = Request.QueryString["listID"];
            if (lstTT == null || lstTT == "")
            {
                Response.Clear();
                Response.Write("");
                return;
            }
            lstTT = lstTT.TrimEnd(',').Replace("on,", "");
            string[] arrIdTT = lstTT.Split(',');
            string sNewArrIdTT = "";

            System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
            for (int i = 0; i < arrIdTT.Length; i++)
            {
                if (lstC.IndexOf(arrIdTT[i]) == -1)
                {
                    lstC.Add(arrIdTT[i]);
                    sNewArrIdTT += arrIdTT[i] + ",";
                }
            }
            sNewArrIdTT = sNewArrIdTT.Remove(sNewArrIdTT.Length - 1, 1);
            int length = arrIdTT.Length;

            string[] arrslvack = slvack.Split('@');

            string html = "";
            if (lstTT.Trim() == "")
            {
                lstTT = "''";
            }

            DataProcess process = s_chitietbenhnhantoathuoc();
            string sqlSelect = @"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                          ,A.tenthuoc
                              ,B.LoaiThuocID
                               ,B.MaLoai
                               ,C.tencachdung
                               ,D.TenDVT as DVT
                               ,E.TenDVT as DVDung
                               ,F.catename,
                               A.CongThuc,
                                A.sudungchobh,
                                k.tenkho
                              from chitietbenhnhantoathuoc T
                                left join thuoc  A on T.idthuoc=A.idthuoc
                                left join Thuoc_LoaiThuoc  B on T.DoiTuongThuocID=B.LoaiThuocID
                                left join Thuoc_CachDung  C on T.idcachdung=C.idcachdung
                                left join Thuoc_DonViTinh  D on T.iddvt=D.Id
                                left join Thuoc_DonViTinh  E on T.iddvdung=E.Id
                                left join category  F on T.cateid=F.cateid
                            left join khothuoc k on k.idkho = T.idkho
                                where t.idchitietbenhnhantoathuoc in (" + sNewArrIdTT + ")";
            DataTable table = process.Search(sqlSelect);
            html = loadTablechitietbenhnhantoathuoc2(table, arrslvack, false);
            Response.Clear();
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private void ChonTT()
    {
        if (Request.QueryString["idkhambenh"] != null && Request.QueryString["idkhambenh"] != "")
        {
            string sqlTest = @"select top 1 1 from chitietbenhnhantoathuoc T where idkhambenh=" + Request.QueryString["idkhambenh"];
            DataTable dtTest = DataAcess.Connect.GetTable(sqlTest);
            if (dtTest != null && dtTest.Rows.Count > 0)
            {
                Response.Clear();
                Response.Write("1907");
                return;
            }
        }
        string lstTT = Request.QueryString["listID"];
        string[] arridTT = lstTT.Split(',');
        lstTT = lstTT.TrimEnd(',');
        string IdBenhNhan = Request.QueryString["IdBenhnhan"];
        if (IdBenhNhan == null && IdBenhNhan == "")
            return;
        string sqlSelectNhom = @"
               select B.IDKHAMBENH
                ,a.ngayratoa,
		        a.idbenhnhantoathuoc
                from benhnhantoathuoc a 
                inner join khambenh b on a.idkhambenh=b.idkhambenh
                WHERE B.IDBENHNHAN=" + IdBenhNhan + @"
                ORDER BY B.IDKHAMBENH  DESC ";

        DataTable dtNhom = DataAcess.Connect.GetTable(sqlSelectNhom);
        if (dtNhom == null || dtNhom.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("");
            Response.StatusCode = 500;
            return;
        }

        string html = "";
        int mkv = 0;
        int jj = 0;
        foreach (DataRow r in dtNhom.Rows)
        {
            html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" class='jtable'>";
            string t = r["idbenhnhantoathuoc"].ToString();
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
                        html += "<th align=\"left\" width='20px'>&nbsp;<input checked id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllTT(this);\" type=\"checkbox\" /></th>";
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
                    html += "<th align=\"left\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllTT(this);\" type=\"checkbox\" /></th>";
                }


            }
            else
            {
                html += "<th align=\"right\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllTT(this);\" type=\"checkbox\" /></th>";
            }

            if (jj == 0)
            {
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Tên thuốc</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Tên DVT</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;SL Kê</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Chuyên khoa</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Mô tả</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Bác sĩ</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Ngày ra toa</th>";
            }
            else
            {
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
            }
            jj++;

            html += "</tr>";
            mkv++;
            string sqlSelect = @"select 
                        TENTHUOC
                        ,TENDVT
                        ,SOLUONGKE,
                        A0.IDCHITIETBENHNHANTOATHUOC
                        ,B.IDKHAMBENH
                        ,ngayratoa=convert(nvarchar(20),a.ngayratoa,103)
                        ,TENDICHVU
                        , c.mota
                        ,d.tenbacsi 
                        ,ISCHON=0
                        from 
                         CHITIETBENHNHANTOATHUOC A0
                        LEFT JOIN benhnhantoathuoc a ON A0.IDBENHNHANTOATHUOC=A.IDBENHNHANTOATHUOC
                        left join khambenh b on a0.idkhambenh=b.idkhambenh
                        left join chandoanicd c on c.idicd=b.ketluan
                        left join bacsi d on a.idbacsi=d.idbacsi
                        left join chitietdangkykham h on b.idchitietdangkykham=h.idchitietdangkykham
                        left join BANGGIADICHVU E ON h.IDBANGGIADICHVU=E.IDBANGGIADICHVU
                        LEFT JOIN THUOC F ON A0.IDTHUOC=F.IDTHUOC
                        LEFT JOIN THUOC_DONVITINH G ON F.IDDVT=G.ID
                        WHERE B.IDBENHNHAN=" + IdBenhNhan + @" and A0.idbenhnhantoathuoc=" + t + @" 
                        ORDER BY B.IDKHAMBENH  DESC ";

            DataTable dtToaThuoc = DataAcess.Connect.GetTable(sqlSelect);
            {
                if (dtToaThuoc != null && dtToaThuoc.Rows.Count != 0)
                {
                    System.Collections.Generic.List<string> lstIdKhamBenh = new System.Collections.Generic.List<string>();
                    foreach (DataRow tenTT in dtToaThuoc.Rows)
                    {
                        string i_idkhambenh = tenTT["idkhambenh"].ToString();
                        if (lstIdKhamBenh.IndexOf(i_idkhambenh) == -1)
                            lstIdKhamBenh.Add(i_idkhambenh);
                        else
                        {
                            tenTT["tendichvu"] = "-";
                            tenTT["tenbacsi"] = "-";
                            tenTT["mota"] = "-";
                            tenTT["ngayratoa"] = "-";
                        }

                        int dk = 0;
                        html += "<tr width=\"100%\">";
                        string id = tenTT["idchitietbenhnhantoathuoc"].ToString();
                        for (int i = 0; i < arridTT.Length; i++)
                        {
                            string tam = arridTT[i].ToString();
                            if (id == tam)
                            {
                                html += "<td  align=\"left\">&nbsp;<input id=\"chkIdChiTietTT\" onclick=\"setChonTT(this)\" value=\"" + tenTT["idchitietbenhnhantoathuoc"] + "\" checked  type=\"checkbox\" /></td>";
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
                            html += "<td align=\"left\">&nbsp;<input id=\"chkIdChiTietTT\" onclick=\"setChonTT(this)\" value=\"" + tenTT["idchitietbenhnhantoathuoc"] + "\" type=\"checkbox\" /></td>";
                        }

                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"20%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["tenthuoc"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"10%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left' >&nbsp;" + tenTT["tendvt"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"5%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["soluongke"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"15%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["tendichvu"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"15%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["mota"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"20%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["tenbacsi"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"10%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + string.Format("{0:dd/MM/yyyy}", tenTT["ngayratoa"]) + "</td>";
                        html += "</tr>";
                    }

                }

            }
            html += "</table>";
        }
        Response.Clear();
        Response.Write(html);

    }
    private void checkHSBA()
    {
        string idbn = Request.QueryString["idbenhnhan"];
        if (idbn != null && idbn != "")
        {
            idbn = Request.QueryString["idbenhnhan"];
        }
        DataTable tb1 = DataAcess.Connect.GetTable("select idkhambenh from khambenh where idbenhnhan=" + idbn + " order by idkhambenh desc ");
        string idkb = "";
        if (tb1.Rows.Count > 0 && tb1.Rows[0][0].ToString() != "")
        {
            idkb = tb1.Rows[0][0].ToString();
            Response.Clear();
            Response.Write(idkb);
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("Bệnh nhân này chưa khám bệnh");
            return;

        }
    }
    private void LoadChanDoanMaICD()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and maicd like N'%" + Request.QueryString["q"] + "%'";
        }

        string sql = @"SELECT top 20 * FROM chandoanicd where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:15%;float:left;height:20px\" >" + row["maicd"] + "</div>"
                         + "<div style=\"width:85%;float:left;height:20px\" >" + row["mota"] + "</div>"
                                     + "</div>", row["maicd"], row["mota"], row["idicd"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void LoadChanDoanMoTaICD()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and mota like N'%" + Request.QueryString["q"] + "%'";
        }

        string sql = @"SELECT top 20 * FROM chandoanicd where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:30px\">"
                                         + "<div style=\"width:15%;float:left;height:30px\" >" + row["maicd"] + "</div>"
                         + "<div style=\"width:85%;float:left;height:30px\" >" + row["mota"] + "</div>"
                                     + "</div>", row["maicd"], row["mota"], row["idicd"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void TinhSoNgayRaToa()
    {
        string songay = Request.QueryString["songay"];
        if (songay == "0" || songay == "" || songay == null) songay = "0";
        string ngaytaikham = DateTime.Now.AddDays(StaticData.ParseInt(songay)).ToString("dd/MM/yyyy");
        Response.Write(ngaytaikham);
    }
    private void congthucsearch()
    {

        string html = "";
        string congthuc = Request.QueryString["q"];
        string IdKhoa = Request.QueryString["IdKhoa"];
        int idbenhnhan = StaticData.ParseInt(Request.QueryString["idBN"]);
        string IsNoiTru = KiemTraNoiTru(IdKhoa);
        string LoaiBN = StaticData.GetValue("benhnhan", "idbenhnhan", idbenhnhan.ToString(), "loai");
        string loaithuocid = "";
        if (Request.QueryString["loaithuocid"].ToString() != "")
            loaithuocid = " and t.loaithuocid = " + Request.QueryString["loaithuocid"];
        string cateid = "";
        if (Request.QueryString["cateid"].ToString() != "")
            cateid = " and t.cateid = " + Request.QueryString["cateid"];
        string MaKho = "PPT";
        if (IsNoiTru == "1")
            MaKho = "KhoLe";
        else if (LoaiBN == "2" || LoaiBN == "3")
            MaKho = "0";
        else if (LoaiBN == "1")
        {
            DataTable tbmk = DataAcess.Connect.GetTable("select dbo.kb_getIDKhoFromBN_NGOAITRU(" + idbenhnhan + ")");
            if (tbmk.Rows.Count > 0)
                MaKho = tbmk.Rows[0][0].ToString();
        }
        string IdKho = "0";
        IdKho = Request.QueryString["idkho"];

        if ((IdKho == null || IdKho == "") && IdKhoa == "1")
        {
            if (LoaiBN == "1") IdKho = StaticData.GetParaValueDB("KhoThuocBHYT");
            else IdKho = StaticData.GetParaValueDB("KhoThuocDV");
        }
        if (IdKho == "") IdKho = "0";
        string sqlKhoThuoc = "SELECT * FROM KHOTHUOC WHERE IDKHOA=" + IdKhoa;
        DataTable dtKho = DataAcess.Connect.GetTable(sqlKhoThuoc);
        if (dtKho != null && dtKho.Rows.Count > 0)
            IdKho = dtKho.Rows[0]["IdKho"].ToString();
        if (IdKho == "") IdKho = StaticData.GetParaValueDB("KhoThuocBHYT");
        string sql = @"SELECT top 20 t.idthuoc,t.tenthuoc
                        ,t.loaithuocid
                        ,dvt.tendvt as donvitinh,t.iddvt
                        ,t.congthuc as congthuc
                        , cd.tencachdung as duongdung,cd.idcachdung
                        ,DBO.Thuoc_TinhGiaXuat2(t.idthuoc,'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + @"',1,1,1," + IdKho + @") as giaThuoc 
                        ,t.sudungchobh
                        ,t.isthuocbv
                        FROM thuoc t
                        left join thuoc_donvitinh dvt on dvt.id=t.iddvt
                        left join thuoc_cachdung cd on cd.idcachdung=t.idcachdung
                        where 1=1 and  t.congthuc LIKE N'" + congthuc + @"%'";
        if (LoaiBN == "1" || (IdKho != null && IdKho != "" && IdKho != "0"))
            sql += " AND T.ISTHUOCBV=1";
        if (loaithuocid != null && loaithuocid != "")
            sql += loaithuocid;
        if (cateid != null && cateid != "")
            sql += cateid;
        sql += " ORDER BY t.tenthuoc ASC";
        if (IdKhoa == null || IdKhoa == "" || IdKhoa == "0")
            IdKhoa = "1";
        DataTable arr = DataAcess.Connect.GetTable(sql);
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                string strTon = "select [dbo].[Thuoc_TonKho_new](" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'," + IdKho + ")";
                DataTable tbTon = DataAcess.Connect.GetTable(strTon);
                string number = "";
                try
                {
                    number = h["giaThuoc"].ToString().Replace(",", "");
                }
                catch
                {
                }
                html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}",
                                      "<div style=\"width:100%;height:30px\">"
                                      + "<div style=\"width:22.5%;float:left;height:30px\" >" + h["tenthuoc"] + "</div>"
                                      + "<div style=\"width:19.5%;float:left;height:30px; margin:5px;\" >" + h["congthuc"] + "</div>"
                                      + "<div style=\"text-align:left;width:10%;float:left;height:30px\" >" + h["duongdung"] + "</div>"
                                      + "<div style=\"text-align:center;width:8%;float:left;height:30px\" >" + h["donvitinh"] + "</div>"
                                      + "<div style=\"text-align:center;width:12%;float:left;height:30px\" >" + h["giaThuoc"] + "</div>"
                                      + "<div style=\"text-align:right;width:3.5%;float:left;height:30px\" >" + tbTon.Rows[0][0] + "</div>"
                                      + "<div style=\"text-align:right;width:11%;float:left;height:30px\" >" + (StaticData.IsCheck(h["sudungchobh"].ToString()) == true ? "BH" : "DV") + "</div>"
                                      + "<div style=\"text-align:right;width:12%;float:left;height:30px\" >" + (StaticData.IsCheck(h["isthuocbv"].ToString()) == true ? "Thuốc BV" : "Ngoài BV") + "</div>"
                                      + "</div>", h["idthuoc"], h["donvitinh"], h["duongdung"], h["tenthuoc"], number,
                                      tbTon.Rows[0][0], h["congthuc"], (StaticData.IsCheck(h["sudungchobh"].ToString()) == true ? "BH" : "DV"), h["iddvt"], h["idcachdung"], Environment.NewLine);
                ;

            }
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void idthuocsearch()
    {

        string html = "";
        string tenthuoc = Request.QueryString["q"];
        string IdKhoa = Request.QueryString["IdKhoa"];
        int idbenhnhan = StaticData.ParseInt(Request.QueryString["idbenhnhan"]);
        string IsNoiTru = KiemTraNoiTru(IdKhoa);
        string LoaiBN = StaticData.GetValue("benhnhan", "idbenhnhan", idbenhnhan.ToString(), "loai");
        string loaithuocid = "";
        if (Request.QueryString["loaithuocid"].ToString() != "")
            loaithuocid = " and t.loaithuocid = " + Request.QueryString["loaithuocid"];
        string IdKho = "0";
        IdKho = Request.QueryString["idkho"];
        string sqlKhoThuoc = "";
        if ((IdKho == null || IdKho == "") && IdKhoa == "1" && LoaiBN == "1")
        {
            sqlKhoThuoc += "SELECT * FROM KHOTHUOC WHERE IDKHOA='" + IdKhoa + "'";
            string IsTuTruc = Request.QueryString["IsTuTruc"];
            if (IsTuTruc == "true")
            {
                sqlKhoThuoc += " and tenkho like N'%tủ%'";
            }
            if (IdKhoa == "1")
            {
                if (LoaiBN != "1")
                    IdKho = "0";
            }

            DataTable dtKho = DataAcess.Connect.GetTable(sqlKhoThuoc);
            if (dtKho != null && dtKho.Rows.Count > 0)
                IdKho = dtKho.Rows[0]["IdKho"].ToString();
        }
        if (IdKho == "") IdKho = "0";
        string sql = @"SELECT top 20 t.idthuoc,t.tenthuoc
                        ,t.loaithuocid
                        ,dvt.tendvt as donvitinh,t.iddvt
                        ,t.congthuc as congthuc
                        , cd.tencachdung as duongdung,cd.idcachdung
                        ,DBO.Thuoc_TinhGiaXuat2(t.idthuoc,'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + @"',1,1,1," + IdKho + @") as giaThuoc 
                        ,t.sudungchobh
                        ,t.isthuocbv
                        FROM thuoc t
                        left join thuoc_donvitinh dvt on dvt.id=t.iddvt
                        left join thuoc_cachdung cd on cd.idcachdung=t.idcachdung
                        where 1=1 and  t.tenthuoc LIKE N'" + tenthuoc + @"%'";
        sql += " AND T.ISTHUOCBV=1";

        if (loaithuocid != null && loaithuocid != "")
            sql += loaithuocid;

        sql += " ORDER BY  isnull(t.sudungchobh,0) desc, isnull( t.isthuocbv,0) desc ,  t.tenthuoc ASC";
        if (IdKhoa == null || IdKhoa == "" || IdKhoa == "0")
            IdKhoa = "1";
        DataTable arr = DataAcess.Connect.GetTable(sql);

        string ChoPhepTheHienThuocKhongCoSLTon = StaticData.GetParaValueDB("ChoPhepTheHienThuocKhongCoSLTon");
        bool Allow = (ChoPhepTheHienThuocKhongCoSLTon == "1");
        bool AllowAddRow = true;

        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {

                string SLTon = "0";
                if (IdKho != null && IdKho != "" && IdKho != "0")
                {
                    string strTon = "";
                    strTon = "select [dbo].[Thuoc_TonKho_new_1910](" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + "'," + IdKho + ")";
                    DataTable tbTon = DataAcess.Connect.GetTable(strTon);
                    SLTon = tbTon.Rows[0][0].ToString();
                    if (!Allow && (SLTon == "" || SLTon == "0"))
                        AllowAddRow = false;
                    else AllowAddRow = true;
                }
                else AllowAddRow = true;
                if (AllowAddRow)
                {
                    string number = "";
                    try
                    {
                        number = h["giaThuoc"].ToString().Replace(",", "");
                    }
                    catch
                    {
                    }
                    html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}",
                                       "<div style=\"width:100%;height:30px\">"
                                       + "<div style=\"width:22%;float:left;height:30px\" >" + h["tenthuoc"] + "</div>"
                                       + "<div style=\"width:25%;float:left;height:30px\" >" + h["congthuc"] + "</div>"
                                       + "<div style=\"text-align:left;width:11%;float:left;height:30px\" >" + h["duongdung"] + "</div>"
                                       + "<div style=\"text-align:left;width:10%;float:left;height:30px\" >" + h["donvitinh"] + "</div>"
                                       + "<div style=\"text-align:left;width:8%;float:left;height:30px\" >" + h["giaThuoc"] + "</div>"
                                       + "<div style=\"text-align:left;width:4%;float:left;height:30px\" >" + SLTon + "</div>"
                                       + "<div style=\"text-align:center;width:8%;float:left;height:30px\" >" + (StaticData.IsCheck(h["sudungchobh"].ToString()) == true ? "BH" : "DV") + "</div>"
                                       + "<div style=\"text-align:right;width:9%;float:left;height:30px\" >" + (StaticData.IsCheck(h["isthuocbv"].ToString()) == true ? "Thuốc BV" : "Ngoài BV") + "</div>"
                                       + "</div>", h["idthuoc"], h["donvitinh"], h["duongdung"], h["tenthuoc"], number,
                                       SLTon, h["congthuc"], StaticData.IsCheck(h["sudungchobh"].ToString()), h["iddvt"], h["idcachdung"], IdKho, Environment.NewLine);
                    ;

                }
            }
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void idcachdungsearch()
    {
        string sqlDVT = @"select * from thuoc_cachdung where tencachdung like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlDVT);
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
    private void iddvtsearch()
    {

        string sqlDVT = @"select * from thuoc_donvitinh where tendvt like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlDVT);
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
    private void iddvdungvsearch()
    {

        string sqlDVT = @"select * from thuoc_donvitinh where tendvt like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlDVT);
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
    private void cateidsearch()
    {
        string loaithuocid = Request.QueryString["loaithuocid"];
        if (loaithuocid != null && loaithuocid != "")
        {
            loaithuocid = " and loaithuocid=" + loaithuocid;
        }
        string sqlSelect = @"select * from category where 1=1" + loaithuocid + " and catename like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}",
                                     "<div style=\"width:100%;height:30px\">"
                                         + "<div style=\"width:85%;float:left;height:30px\" >" + StaticData.IntelName(row["catename"].ToString()) + "</div>"
                                     + "</div>", row["cateid"], row["catename"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idphongsearch()
    {
        string swhere = "";
        string idpkb = Request.QueryString["idpkb"];
        if (idpkb != null && idpkb != "")
        {
            swhere += " and bg.idphongkhambenh=" + StaticData.ParseInt(idpkb);
        }
        string sqlSelectTenNhom = ""
                                    + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh" + "\r\n"
                                    + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
                                    + " where 1=1  " + swhere + "  and  loaiphong=1 \r\n";
        DataTable table = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][0].ToString() + "|" + StaticData.IntelName(table.Rows[i][1].ToString()) + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);

    }
    private void idkhoasearch()
    {
        string selectTenPhong = @"select pkb.idphongkhambenh,pkb.tenphongkhambenh from phongkhambenh
            pkb where loaiphong=1 order by pkb.idphongkhambenh";
        DataTable table = DataAcess.Connect.GetTable(selectTenPhong);
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
    private void GetDSCLS()
    {
        try
        {
            string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
            string IdKhambenh = (Request.QueryString["IdKhambenh"] != null ? Request.QueryString["IdKhambenh"].ToString() : "");
            string slvack = Request.QueryString["slvack"];
            string LoaiBN = (Request.QueryString["loaidk"] != null ? Request.QueryString["loaidk"].ToString() : "");
            if (LoaiBN == "")
            {

                DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN B WHERE idbenhnhan='" + IdBenhNhan + "'");
                if (dtBN != null && dtBN.Rows.Count > 0)
                {
                    LoaiBN = dtBN.Rows[0][0].ToString();
                    IdBenhNhan = dtBN.Rows[0]["IdBenhNhan"].ToString();
                }
            }



            string listidcanlamsan = Request.QueryString["listID"];
            if (listidcanlamsan == null || listidcanlamsan == "")
            {
                Response.Clear();
                Response.Write("");
                return;
            }
            listidcanlamsan = listidcanlamsan.TrimEnd(',').Replace("on,", "");
            string[] arridcls = listidcanlamsan.Split(',');
            string sNewArrCLSID = "";

            System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
            for (int i = 0; i < arridcls.Length; i++)
            {
                if (lstC.IndexOf(arridcls[i]) == -1)
                {
                    lstC.Add(arridcls[i]);
                    sNewArrCLSID += arridcls[i] + ",";
                }
            }
            sNewArrCLSID = sNewArrCLSID.Remove(sNewArrCLSID.Length - 1, 1);


            int length = arridcls.Length;

            string[] arrslvack = slvack.Split('@');

            string html = "";
            if (listidcanlamsan.Trim() == "")
            {
                listidcanlamsan = "''";
            }
            string sqlSelectBangGiaDichVu = ""
                   + " select STT=0,A.idbanggiadichvu,dathu=0, B.tenphongkhambenh,A.TenNhom,A.tendichvu,DONGIA=0, GIADICHVU,BHTRA,A.IsSuDungChoBH,A.PhuThuBH,A.idphongkhambenh,IsBHYT_Save=0" + "\r\n"
                   + " 				from banggiadichvu a" + "\r\n"
                   + " 				left join phongkhambenh b on a.idphongkhambenh=b.idphongkhambenh" + "\r\n"
                   + " WHERE b.loaiphong = 1 and a.idbanggiadichvu in (" + sNewArrCLSID + ")"
                   + "  " + "\r\n";
            DataTable dt = DataAcess.Connect.GetTable(sqlSelectBangGiaDichVu);

            dt.Columns.Add("nSTT", length.GetType());
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string IdBangGiaDichVu_ = dt.Rows[i]["IdBangGiaDichVu"].ToString();
                int n_ = lstC.IndexOf(IdBangGiaDichVu_);
                dt.Rows[i]["nSTT"] = n_;

            }
            dt.DefaultView.Sort = "nSTT";
            dt = dt.DefaultView.ToTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsSuDungChoBH = StaticData.IsCheck(dt.Rows[i]["IsSuDungChoBH"].ToString());
                string DonGia = "0";
                if (LoaiBN == "1" && IsSuDungChoBH)
                {
                    DonGia = dt.Rows[i]["BHTra"].ToString();
                }
                else DonGia = dt.Rows[i]["GiaDichVu"].ToString();
                dt.Rows[i]["DonGia"] = DonGia;
                dt.Rows[i]["STT"] = i + 1;
                string sql = @"select dathu from khambenhcanlamsan where idcanlamsan=" + dt.Rows[i]["idbanggiadichvu"].ToString() + (IdKhambenh != null && IdKhambenh != "" ? " and idkhambenh=" + IdKhambenh : "") + " and idbenhnhan=" + IdBenhNhan;
                DataTable dtCheckDathu = DataAcess.Connect.GetTable(sql);
                if (dtCheckDathu != null && dtCheckDathu.Rows.Count > 0 && dtCheckDathu.Rows[0][0].ToString() == "1")
                {
                    dt.Rows[i]["dathu"] = "1";
                }
                else
                {
                    dt.Rows[i]["dathu"] = "0";
                }
            }
            html = tableCLS(dt, arrslvack, false);
            Response.Clear();
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private void Xoakhambenh()
    {
        try
        {
            DataProcess process = s_khambenh();
            string sqlCheckCLS = @"SELECT * FROM KHAMBENHCANLAMSAN WHERE IDKHAMBENH='" + process.getData("IDKHAMBENH") + "'" + " AND ISNULL(DAHUY,0)=0";
            DataTable dtCheckCLS = DataAcess.Connect.GetTable(sqlCheckCLS);
            if (dtCheckCLS != null && dtCheckCLS.Rows.Count > 0)
            {
                if (!SysParameter.UserLogin.IsAdmin(this.Page))
                {
                    Response.Clear();
                    Response.Write("Lỗi: Bệnh nhân đã cận lâm sàn");
                    Response.StatusCode = 500;
                    return;
                }
                int n_DaThu = StaticData.int_Search(dtCheckCLS, "DATHU=1");
                if (n_DaThu != -1)
                {
                    Response.Clear();
                    Response.Write("Lỗi: Cận lâm sàn đã thu tiền rồi");
                    Response.StatusCode = 500;
                    return;
                }
            }
            string sqlCheckThuoc = @"SELECT DAXUAT=DBO.THUOC_ISDAXUAT_TOA(IDCHITIETBENHNHANTOATHUOC) FROM CHITIETBENHNHANTOATHUOC WHERE IDKHAMBENH='" + process.getData("IDKHAMBENH") + "'";
            DataTable dtCheckThuoc = DataAcess.Connect.GetTable(sqlCheckThuoc);
            if (dtCheckThuoc != null && dtCheckThuoc.Rows.Count > 0)
            {
                if (!SysParameter.UserLogin.IsAdmin(this.Page))
                {
                    Response.Clear();
                    Response.Write("Lỗi: Bệnh nhân đã có thuốc rồi");
                    Response.StatusCode = 500;
                    return;
                }
                int n_DaXuat = StaticData.int_Search(dtCheckThuoc, "DAXUAT=1");
                if (n_DaXuat != -1)
                {
                    Response.Clear();
                    Response.Write("Lỗi : Không thể xóa khi đã xuất thuốc");
                    Response.StatusCode = 500;
                    return;
                }
            }
      
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
    private void idbacsisearch()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string idkhoaClause = "";
        if (idkhoa == "1")
        {
            idkhoaClause = " and A.IDPHONGKHAMBENH ='" + idkhoa + "'";
        }


        string TenBS = Request.QueryString["q"].ToString();
        string sqlBS = @"SELECT 
            A.IDBACSI AS IDBACSI
            ,A.TENBACSI AS TENBACSI
            FROM BACSI A   LEFT JOIN NGUOIDUNG B ON A.IDBACSI=B.IDBACSI 
            WHERE A.TENBACSI like N'%" + TenBS + "%'" + idkhoaClause;
        DataTable table = DataAcess.Connect.GetTable(sqlBS);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += table.Rows[i]["tenbacsi"].ToString() + "|" + table.Rows[i]["idbacsi"].ToString() + "|" + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdkhoaChuyenSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM phongkhambenh where loaiphong=0 ");
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
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM banggiadichvu where  idphongkhambenh='" + Request.QueryString["IdkhoaChuyen"] + "'");
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
        DataTable dtPhong = null;
        if (StaticData.EnableChuyenKhoa)
            dtPhong = StaticData.dtPhong_ByChuyenKhoa("'" + Request.QueryString["banggiadichvu"] + "'", null);
        else
            dtPhong = StaticData.dtPhong_ByKhoa("'" + Request.QueryString["IdkhoaChuyen"] + "'");
        DataTable table = dtPhong;
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i]["TenPhongFull"].ToString() + "" + "" + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idcanlamsansearch()
    {
        string swhere = "";
        string tennhom = Request.QueryString["tennhom"];
        if (tennhom != null && tennhom != "")
        {
            swhere += " and bg.tennhom like N'" + tennhom + "'";
        }
        string idphongkhambenh = Request.QueryString["idphongkhambenh"];
        if (idphongkhambenh != null && idphongkhambenh != "")
        {
            swhere += " and bg.idphongkhambenh=" + idphongkhambenh;
        }
        string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
        string LoaiBN = (Request.QueryString["loaidk"] != null ? Request.QueryString["loaidk"].ToString() : "");
        if (LoaiBN == "")
        {

            DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN B WHERE idbenhnhan='" + IdBenhNhan + "'");
            if (dtBN != null && dtBN.Rows.Count > 0)
            {
                LoaiBN = dtBN.Rows[0][0].ToString();
                IdBenhNhan = dtBN.Rows[0]["IdBenhNhan"].ToString();
            }
        }
        //        string sqlSelect = @"SELECT top 20 idbanggiadichvu,tendichvu,dongia=0,GIADICHVU,BHTRA, IsSuDungChoBH FROM banggiadichvu  left join phongkhambenh on phongkhambenh.idphongkhambenh=banggiadichvu.idphongkhambenh
        //            where 1=1 "  +  swhere + " and  loaiphong=1 and  tendichvu like N'%" + Request.QueryString["q"] + "%'";
        string sqlSelect = @"SELECT  bg.idbanggiadichvu,bg.tendichvu,dongia=0,bg.GIADICHVU,bg.BHTRA, bg.IsSuDungChoBH 
                            FROM banggiadichvu bg
                            left join phongkhambenh pkb on pkb.idphongkhambenh=bg.idphongkhambenh
                            where 1=1  " + swhere + " and pkb.loaiphong=1 and  bg.tendichvu like N'%" + Request.QueryString["q"].Trim() + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                bool IsSuDungChoBH = StaticData.IsCheck(table.Rows[i]["IsSuDungChoBH"].ToString());
                string DonGia = "";
                if (LoaiBN == "1" && IsSuDungChoBH)
                {
                    DonGia = (table.Rows[i]["BHTRA"] == "NULL" ? "0" : table.Rows[i]["BHTRA"].ToString());
                }
                else
                    DonGia = table.Rows[i]["GiaDichVu"].ToString();
                table.Rows[i]["DonGia"] = DonGia;
                html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString() + "|" + IsSuDungChoBH + Environment.NewLine;

            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loaithuocidsearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM thuoc_loaithuoc where tenloai like N'" + Request.QueryString["q"] + "%'");
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
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM thuoc_doituongthuoc where tendoituong like N'" + Request.QueryString["q"] + "%'");
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
    protected string KiemTraNoiTru(string idPKB)
    {
        string isnoitru = StaticData.GetValue("phongkhambenh", "idphongkhambenh", idPKB, "isnoitru");
        if (isnoitru.ToUpper() == "TRUE" || isnoitru.ToUpper() == "1")
            return "1";
        else return "0";
    }
    private void Xoachitietbenhnhantoathuoc()
    {
        try
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            string idchitietbenhnhantoathuoc = process.getData("idchitietbenhnhantoathuoc");
            string sqlSelect = "select top 1 1 from chitietphieuxuatkho where idchitietbenhnhantoathuoc=" + idchitietbenhnhantoathuoc + " and isnull(IsDaHuy,0)<>0";
            DataTable dtChitietPX = DataAcess.Connect.GetTable(sqlSelect);
            if (dtChitietPX == null)
            {
                Response.StatusCode = 500;
                Response.Write("Không kiểm tra được tình trạng xuất thuốc !");
                return;
            }
            if (dtChitietPX.Rows.Count > 0)
            {
                Response.StatusCode = 500;
                Response.Write("Thuốc này đã xuất rồi, không thể xoá được!");
                return;
            }
         
            bool ok = process.Delete();
            if (ok)
            {
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
            DataProcess process = s_khambenhcanlamsan();
            string idKhamBenhCLS = process.getData("idkhambenhcanlamsan");
            string sqlCLS = "select dathu,ISBNDaTra from khambenhcanlamsan where idkhambenhcanlamsan=" + idKhamBenhCLS;
            DataTable dtCLS = DataAcess.Connect.GetTable(sqlCLS);
            string dathu = dtCLS.Rows[0]["dathu"].ToString();
            if (dathu == "" || dathu.ToLower() == "false" || dathu == "0") dathu = "0";
            else dathu = "1";


            string ISBNDaTra = dtCLS.Rows[0]["ISBNDaTra"].ToString();
            if (ISBNDaTra == "" || ISBNDaTra.ToLower() == "false" || ISBNDaTra == "0") ISBNDaTra = "0";
            else ISBNDaTra = "1";
            if (dathu == "1" || ISBNDaTra == "1")
            {
                Response.StatusCode = 500;
                Response.Write("Dịch vụ kĩ thuật này được thu tiền rồi !");
                return;

            }
            bool ok = process.Delete();
            if (ok)
            {
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
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        string dk = "";
        dk = " KB.idkhambenh='" + idkhoachinh + "'";
        string sqlSelect = @"SELECT  
            IdKhoa = kb.idkhoa,IdChiTietDangKyKham = kb.idchitietdangkykham,
            iddangkykham=kb.iddangkykham,
            PhongID = kb.phongid,
            TGXuatVien,
            kb.ketluan,
            kb.ketluan1,
            DichVuKCBID =kb.DichVuKCBID,
            kb.IdChuyenPK,
			kb.idbacsi,
            kb.trieuchung,
            kb.benhsu,
            kb.tiensu,
            BN.IDBENHNHAN AS idbenhnhan,
            RIGHT( CONVERT(VARCHAR(13),tgxuatvien,120),2) as gioravien,RIGHT( CONVERT(VARCHAR(16),tgxuatvien,120),2) as phutravien,
            BN.TENBENHNHAN AS tenbenhnhan,
            BN.mabenhnhan AS mabenhnhan,
            bn.diachi,
            BN.NGAYSINH AS NGAYSINH,
            ngaykham = isnull(kb.ngaykham,getdate()),
            mkv_idchandoan=CD.MAICD,
            mkv_mota =CD.MOTA,
            mkv_ketluan1=CD1.MAICD,
            mkv_mota1 =CD1.MOTA,
            mkv_IdChuyenPK =dbo.HS_TenPhong(kb.idchuyenpk),
            mkv_idDVPhongChuyenDen =chuyenkhoa_Chuyen.TenDichVu,
            mkv_IdkhoaChuyen =Khoa_Chuyen.TenPhongKhamBenh
            ,IdkhoaChuyen
            ,idDVPhongChuyenDen
            ,XuatVien=(case when isnull(idkhambenhmoi,0)=0 then 0 else isnull((select isxuatvien from khambenh where idkhambenh=KB.idkhambenhmoi),0) end)
            ,GIOITINH=dbo.GetGioiTinh(Bn.GioiTinh),
            bs.tenbacsi as mkv_idbacsi,
            SH.MACH ,
            SH.NHIETDO ,
            SH.HUYETAP1 ,
            SH.HUYETAP2 ,
            SH.NHIPTHO ,
            SH.CANNANG ,
            SH.CHIEUCAO,
            SH.BMI,
            IsChuyenPhongCoPhi,
            TENKHOA=K2.TENPHONGKHAMBENH,
            mkv_PhongID=DBO.HS_TENPHONG(KB.PHONGID),
            songayratoa=KB.songayratoa,KB.ngayhentaikham,
            loidan=KB.dando,
            KB.ischovekt,
            KB.ischuyenvien,
            KB.idbenhvienchuyen,
            KB.iskhongkham,
            KB.idbacsi2,
            mkv_idbenhvienchuyen =BV.TENBENHVIEN,
            mkv_idbacsi2 =BS.TENBACSI,
            IsBSMoiKham,
            KB.idphuongphapvocam
            ,mkv_idphuongphapvocam=PPVC.TENPHUONGPHAPVOCAM
            ,chuyenkhoaravien=case when isnull(tgxuatvien,1)=1 then '0' else '1' end
            ,giuongid
            ,mkv_giuongid=(select giuongcode from kb_giuong where giuongid=kb.giuongid)
            ,thoigian=isnull((convert(char(8),kb.ngaykham,114)),convert(char(8),getdate(),114)),
            loaidk=DK.LOAIKHAMID,
            sobhyt=upper(BHYT.SOBHYT),
            ngaybatdau=BHYT.NGAYBATDAU,
            ngayhethan=BHYT.NGAYHETHAN,
            NoiDangKyKCB=KCB.TENNOIDANGKY,
            IsDungTuyen=BHYT.IsDungTuyen,
            idkhambenhmoi,
            SOVAOVIEN1=HS.SOVAOVIEN
            ,HS.isNoiTru
            ,isNgoaiTru=( CASE WHEN ISNULL( HS.isNoiTru,0)=0 THEN 1 ELSE 0 END)
            FROM KHAMBENH KB
            LEFT JOIN BENHNHAN BN  ON KB.IDBENHNHAN=BN.IDBENHNHAN
			left join chitietdangkykham ct on ct.idchitietdangkykham = kb.idchitietdangkykham
			left join dangkykham dk on dk.iddangkykham = ct.iddangkykham
            left join bacsi bs on bs.idbacsi = kb.idbacsi
            left join kb_phong phong_chuyen on phong_chuyen.id = kb.idchuyenpk
            left join BANGGIADICHVU ChuyenKhoa_chuyen on ChuyenKhoa_chuyen.idbanggiadichvu = phong_chuyen.DichVuKCB
            left join PHONGKHAMBENH Khoa_chuyen on Khoa_chuyen.idphongkhambenh = kb.idkhoachuyen
            left join SINHHIEU SH on SH.idkhambenh=kb.idkhambenh
            LEFT JOIN PHONGKHAMBENH K2 ON KB.IDKHOA=K2.IDPHONGKHAMBENH
            LEFT JOIN KB_PHONG P2 ON KB.PHONGID=P2.ID
            LEFT JOIN BENHNHAN_BHYT BHYT ON DK.IDBENHNHAN_BH=BHYT.IDBENHNHAN_BH
            LEFT JOIN KB_NOIDANGKYKB KCB ON BHYT.IDNOIDANGKYBH=KCB.IDNOIDANGKY
            LEFT JOIN BENHVIEN BV ON BV.IDBENHVIEN=KB.IDBENHVIENCHUYEN
            LEFT JOIN CHANDOANICD CD ON CD.IDICD=KB.KETLUAN
            LEFT JOIN CHANDOANICD CD1 ON CD1.IDICD=KB.KETLUAN1
            LEFT JOIN PHUONGPHAPVOCAM PPVC ON PPVC.IDPHUONGPHAPVOCAM=KB.IDPHUONGPHAPVOCAM
            LEFT JOIN HS_BENHNHANBHDONGTIEN HS ON DK.IDBENHBHDONGTIEN=HS.ID
            WHERE " + dk;
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<root>";
        if (!string.IsNullOrEmpty(idkhoachinh))
            html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
        html += Environment.NewLine;
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string[] thoigian = table.Rows[0]["thoigian"].ToString().Split(':');
                html += "<data id=\"giovaovien\">" + thoigian[0].ToString() + "</data>";
                html += "<data id=\"phutvaovien\">" + thoigian[1].ToString() + "</data>";
                html += "<data id=\"IsXuatVien\">" + (StaticData.IsCheck(table.Rows[0]["XuatVien"].ToString())) + "</data>";
                for (int y = 0; y < table.Columns.Count; y++)
                {
                    if (table.Columns[y].ToString() == "ngaykham")
                    {
                        html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                    }
                    else
                    {
                        try
                        {
                            html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                        }
                        catch (Exception)
                        {
                            html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                        }
                    }
                    html += Environment.NewLine;
                }
            }
        }


        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }
    private void setTimKiem_KhamMoi()
    {
        string idchitietdangkykham = Request.QueryString["idchitietdangkykham"];
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string dk = "";
        dk = " ct.idchitietdangkykham='" + idchitietdangkykham + "'";
        string sqlSelect = @"SELECT top 1 
			IdChiTietDangKyKham = ct.idchitietdangkykham,
            iddangkykham=ct.iddangkykham,
            PhongID = ct.phongid,IdKhoa = b.idphongkhambenh,
            DichVuKCBID = a.DichVuKCB,
            BN.IDBENHNHAN AS idbenhnhan,
            BN.TENBENHNHAN AS tenbenhnhan,
            BN.mabenhnhan AS mabenhnhan,
            bn.diachi,
            BN.NGAYSINH AS NGAYSINH,
            idbacsi = '" + SysParameter.UserLogin.IdBacSi(this) + @"',
            mkv_idbacsi = (select tenbacsi from bacsi where idbacsi='" + SysParameter.UserLogin.IdBacSi(this) + @"'),
            ngaykham = getdate(),
            GIOITINH=dbo.GetGioiTinh(bn.GioiTinh),
            SH.MACH ,
            SH.NHIETDO ,
            SH.HUYETAP1 ,
            SH.HUYETAP2 ,
            SH.NHIPTHO ,
            SH.CANNANG ,
            SH.CHIEUCAO,
            SH.BMI,
            TENKHOA=c.tenphongkhambenh,
            TENPHONG=dbo.hs_tenphong(ct.phongid),
            IdPhuongPhapVocam,
            thoigian=convert(char(8),getdate(),114),
            loaidk=DK.LOAIKHAMID
            ,SOVAOVIEN1=HS.SOVAOVIEN
            ,HS.isNoiTru
            ,isNgoaiTru=( CASE WHEN ISNULL( HS.isNoiTru,0)=0 THEN 1 ELSE 0 END)
            FROM 
			chitietdangkykham ct
			left join dangkykham dk on ct.iddangkykham = dk.iddangkykham 
			left join BENHNHAN BN  on dk.idbenhnhan = bn.idbenhnhan
			left join kb_phong a on a.id = ct.phongid
			left join banggiadichvu b on a.dichvukcb = b.idbanggiadichvu
			left join phongkhambenh c on c.idphongkhambenh = b.idphongkhambenh
            left join SINHHIEU SH on SH.IDDANGKYKHAM=dk.iddangkykham
            LEFT JOIN HS_BENHNHANBHDONGTIEN HS ON DK.IDBENHBHDONGTIEN=HS.ID
            WHERE bn.idbenhnhan = '" + idbenhnhan + "' and " + dk;
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<root>";
        html += Environment.NewLine;
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string[] thoigian = table.Rows[0]["thoigian"].ToString().Split(':');
                html += "<data id=\"giovaovien\">" + thoigian[0].ToString() + "</data>";
                html += "<data id=\"phutvaovien\">" + thoigian[1].ToString() + "</data>";
                for (int y = 0; y < table.Columns.Count; y++)
                {
                    if (table.Columns[y].ToString() == "ngaykham")
                    {
                        html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                    }
                    else
                    {
                        try
                        {
                            html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                        }
                        catch (Exception)
                        {
                            html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                        }
                    }
                    html += Environment.NewLine;
                }
            }
        }


        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }
    private void setTimKiem_KhamMoiChuyenPhong()
    {
        string idkhambenhchuyenphong = Request.QueryString["idkhambenhchuyenphong"];
        string sqlSelect = @"SELECT top 1 
            IdChiTietDangKyKham =ISNULL(G.IDCHITIETDANGKYKHAM,CT.IDCHITIETDANGKYKHAM),
            iddangkykham=ct.iddangkykham,
            PhongID = a.id,IdKhoa = K2.idphongkhambenh,
            DichVuKCBID = a.DichVuKCB,
            BN.IDBENHNHAN AS idbenhnhan,
            BN.TENBENHNHAN AS tenbenhnhan,
            BN.mabenhnhan AS mabenhnhan,
            bn.diachi,
            BN.NGAYSINH AS NGAYSINH,
            ngaykham = getdate(),
            idbacsi = '" + SysParameter.UserLogin.IdBacSi(this) + @"',
            mkv_idbacsi = (select tenbacsi from bacsi where idbacsi='" + SysParameter.UserLogin.IdBacSi(this) + @"'),
            GIOITINH=dbo.GetGioiTinh(bn.GioiTinh),
            SH.MACH ,
            SH.NHIETDO ,
            SH.HUYETAP1 ,
            SH.HUYETAP2 ,
            SH.NHIPTHO ,
            SH.CANNANG ,
            SH.CHIEUCAO,
            SH.BMI,
            TENKHOA=K2.TENPHONGKHAMBENH,
            TENPHONG=DBO.HS_TENPHONG(KB.IdChuyenPK),
            KB.IDKHAMBENH,
            ischovekt=0,
            ischuyenvien=0,
            idbenhvienchuyen=NULL,
            iskhongkham=0,
            KB.idbacsi,
            mkv_idbenhvienchuyen = NULL,
            mkv_idbacsi =bs.tenbacsi,
            IdPhuongPhapVoCam ,
            thoigian=convert(char(8),getdate(),114),
            loaidk=DK.LOAIKHAMID,
            sobhyt=upper(BHYT.SOBHYT),
            ngaybatdau=BHYT.NGAYBATDAU,
            ngayhethan=BHYT.NGAYHETHAN,
            NoiDangKyKCB=KCB.TENNOIDANGKY,
            IsDungTuyen=BHYT.IsDungTuyen  
            ,SOVAOVIEN1=HS.SOVAOVIEN
            ,HS.isNoiTru
            ,isNgoaiTru=( CASE WHEN ISNULL( HS.isNoiTru,0)=0 THEN 1 ELSE 0 END)
            FROM KHAMBENH KB
			LEFT JOIN chitietdangkykham ct ON KB.idchitietdangkykham=ct.idchitietdangkykham
			left join dangkykham dk on ct.iddangkykham = dk.iddangkykham
			left join BENHNHAN BN  on KB.idbenhnhan=bn.idbenhnhan
			left join kb_phong a on a.id = kb.idchuyenpk
			left join banggiadichvu b on ct.idbanggiadichvu = b.idbanggiadichvu
			left join phongkhambenh c on c.idphongkhambenh = b.idphongkhambenh
            left join SINHHIEU SH on SH.IDDANGKYKHAM=dk.iddangkykham
            LEFT JOIN KB_PHONG P2 ON KB.IdChuyenPK=P2.ID
            LEFT JOIN PHONGKHAMBENH K2 ON isnull( KB.IdkhoaChuyen,kb.phongkhamchuyenden)=K2.IDPHONGKHAMBENH
            LEFT JOIN DANGKYKHAM F ON KB.IDKHAMBENH=F.IDKHAMBENH_CHUYEN
            LEFT JOIN CHITIETDANGKYKHAM G ON F.IDDANGKYKHAM=G.IDDANGKYKHAM
            LEFT JOIN BENHNHAN_BHYT BHYT ON DK.IDBENHNHAN_BH=BHYT.IDBENHNHAN_BH
            LEFT JOIN KB_NOIDANGKYKB KCB ON BHYT.IDNOIDANGKYBH=KCB.IDNOIDANGKY
            LEFT JOIN BACSI BS ON KB.IDBACSI=BS.IDBACSI
            LEFT JOIN HS_BENHNHANBHDONGTIEN HS ON DK.IDBENHBHDONGTIEN=HS.ID
            WHERE kb.idkhambenh = '" + idkhambenhchuyenphong + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<root>";
        html += Environment.NewLine;
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string[] thoigian = table.Rows[0]["thoigian"].ToString().Split(':');
                html += "<data id=\"giovaovien\">" + thoigian[0].ToString() + "</data>";
                html += "<data id=\"phutvaovien\">" + thoigian[1].ToString() + "</data>";
                for (int y = 0; y < table.Columns.Count; y++)
                {
                    if (table.Columns[y].ToString() == "ngaykham")
                    {
                        html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                    }
                    else
                    {
                        try
                        {
                            html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                        }
                        catch (Exception)
                        {
                            html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                        }
                    }
                    html += Environment.NewLine;
                }
            }
        }


        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }
    private void Savekhambenh()
    {
        try
        {
            DataProcess process = s_khambenh();
            #region format_ngaykham
            string UserID = SysParameter.UserLogin.UserID(this);
            string ngaykham = StaticData.CheckDate(process.getData("ngaykham"));
            string gio = Request.QueryString["giovaovien"];
            if (gio == null || gio == "") gio = "00";
            string phut = Request.QueryString["phutvaovien"];
            if (phut == null || phut == "") phut = "00";
            process.data("ngaykham", Request.QueryString["ngaykham"] + " " + gio + ":" + phut + ":" + "00");
            #endregion
            #region Set IdDangKyKham,IdChiTietDangKyKham
            string iddangkykham = process.getData("iddangkykham");
            string idchitietdangkykham = process.getData("idchitietdangkykham");
            if (idchitietdangkykham == null || idchitietdangkykham == "")
            {
                idchitietdangkykham = Request.QueryString["idchitietdangkykham"];
                process.data("idchitietdangkykham", idchitietdangkykham);
            }
            if (idchitietdangkykham == null || idchitietdangkykham == "") return;
            if (iddangkykham == null || iddangkykham == "")
            {
                string sqlSelectDKK = "SELECT IDDANGKYKHAM FROM CHITIETDANGKYKHAM WHERE IDCHITIETDANGKYKHAM='" + idchitietdangkykham + "'";
                DataTable dtDKK = DataAcess.Connect.GetTable(sqlSelectDKK);
                if (dtDKK != null && dtDKK.Rows.Count > 0)
                {
                    iddangkykham = dtDKK.Rows[0][0].ToString();
                    process.data("iddangkykham", iddangkykham);
                }
            }
            #endregion
            #region Kiem tra co xac dinh thoi gian xuat vien hay chua
            if (Request.QueryString["tgxuatvien"].ToString() == "")
            {
                if (Request.QueryString["IdChuyenPK"].ToString() != "")
                {
                    Response.Write("Thời gian Ra viện/chuyển khoa chưa chọn.");
                    Response.StatusCode = 500;
                    return;
                }
            }
            #endregion
            #region IsNoi Tru theo Khoa
            string isNoiTru = "1";
            if (isNoiTru == "") isNoiTru = "0";
            process.data("isNoiTru", isNoiTru);
            #endregion
            #region Add Extra Parameter
            process.data("MAPHIEUKHAM", process.getData("MaSo"));
            process.data("IDPHONGKHAMBENH", process.getData("IdKhoa"));
            process.data("NGAYKHAM", process.getData("ngaykham"));
            process.data("IdPhong", process.getData("PhongID"));
            process.data("idPhongChuyenDen", process.getData("IdChuyenPK"));
            process.data("phongkhamchuyenden", process.getData("IdkhoaChuyen"));
            #endregion
            #region TGXUATVIEN
            string NgayXuatVien = Request.QueryString["tgxuatvien"].ToString();
            process.data("TGXUATVIEN", NgayXuatVien + " " + Request.QueryString["gioravien"] + ":" + Request.QueryString["phutravien"] + ":00");

            if (Request.QueryString["idkhambenhchuyenphong"] != null && Request.QueryString["idkhambenhchuyenphong"].ToString() != "")
            {
                process.data("idkhambenhgoc", Request.QueryString["idkhambenhchuyenphong"]);

            }
            #endregion
            #region truong hop Update
            if (process.getData("idkhambenh") != null && process.getData("idkhambenh") != "")
            {
                process.data("IdDieuDuong", UserID);
                #region Kiểm tra xem có phải từ trường hợp chuyển phòng thu phí ,sang hướng điều trị khác không hoặc chuyển sang phòng khách hay ko?
                string idchuyenpk = process.getData("IdChuyenPK");
                string IsChuyenPhongCoPhi = process.getData("IsChuyenPhongCoPhi");
                string sqlCTDKK_Chuyen = @"SELECT TOP 1 A.* FROM CHITIETDANGKYKHAM A
                                               LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                            WHERE B.IDKHAMBENH_CHUYEN=" + process.getData("idkhambenh");
                DataTable dtCTDKK_Chuyen = DataAcess.Connect.GetTable(sqlCTDKK_Chuyen);
                if (idchuyenpk == null
                    || idchuyenpk == ""
                    || idchuyenpk == "0"
                    || StaticData.IsCheck(IsChuyenPhongCoPhi) == false
                    || (dtCTDKK_Chuyen != null && dtCTDKK_Chuyen.Rows.Count > 0 && dtCTDKK_Chuyen.Rows[0]["PhongID"].ToString() != idchuyenpk)
                    )
                {
                    if (dtCTDKK_Chuyen != null && dtCTDKK_Chuyen.Rows.Count > 0)
                    {
                        string IsDaThu = dtCTDKK_Chuyen.Rows[0]["IsDathu"].ToString();
                        string IsBNDaTra = dtCTDKK_Chuyen.Rows[0]["IsBNDaTra"].ToString();
                        if (StaticData.IsCheck(IsDaThu) || StaticData.IsCheck(IsBNDaTra))
                        {

                            Response.Write("Đã thu phí chuyển phòng rồi, chỉ có thể hướng điều trị khi huỷ phiếu thu tương ứng");
                            Response.StatusCode = 500;
                            return;
                        }
                        if (idchuyenpk == null
                            || idchuyenpk == ""
                            || idchuyenpk == "0"
                            || StaticData.IsCheck(IsChuyenPhongCoPhi) == false
                            )
                        {
                            string sqlDeleteCTDKK_chuyen = "delete dangkykham where iddangkykham=" + dtCTDKK_Chuyen.Rows[0]["IdDangKyKham"].ToString() + "\r\n"
                                                          + " delete chitietdangkykham where iddangkykham=" + dtCTDKK_Chuyen.Rows[0]["IdDangKyKham"].ToString() + "";
                            bool delete_CTDKK_Chuyen = DataAcess.Connect.ExecSQL(sqlDeleteCTDKK_chuyen);
                            if (!delete_CTDKK_Chuyen)
                            {
                                Response.Write("Không thể huỷ đăng ký khám tự động được, liên hệ Admin");
                                Response.StatusCode = 500;
                                return;
                            }
                        }
                    }

                }
                #endregion
                // Nếu idchuyenpk != phòng chuyển hiện tại nhưng đã khám thì ko được chuyển phòng
                DataTable khambenhchuyenphong = DataAcess.Connect.GetTable("select top 1 idkhambenhchuyenphong,idchuyenpk from KHAMBENH where idkhambenh=" + Request.QueryString["idkhoachinh"] + "");
                DataTable ktracphongdakham = DataAcess.Connect.GetTable("select top 1 idkhambenh from KHAMBENH where idkhambenh='" + (khambenhchuyenphong.Rows.Count > 0 ? khambenhchuyenphong.Rows[0][0] : "") + "'");
                if (ktracphongdakham.Rows.Count > 0)
                {
                    if (khambenhchuyenphong.Rows[0][1].ToString().Trim() != "" && khambenhchuyenphong.Rows[0][1].ToString() != Request.QueryString["IdChuyenPK"])
                    {
                        Response.Write("Không thể chuyển phòng,Phòng chuyển đã khám.");
                        Response.StatusCode = 500;
                        return;
                    }
                }
                string IdkhoaChuyen = Request.QueryString["IdkhoaChuyen"];
                // Cập nhật idkhambenhgoc cho phiếu khám bệnh gốc đã chuyển phòng
                bool ok = process.Update();
                if (!ok)
                {
                    Response.StatusCode = 500;
                    return;
                }
            }
            #endregion
            #region truong hop Insert
            else
            {
                process.data("ngaykham", DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("dd/MM/yyyy HH:mm"));
                process.data("maphieukham", StaticData.CreateIDTheoThuTu("PKB", "khambenh", "maphieukham", "idkhambenh"));
                process.data("IdDieuDuong", UserID);
                bool ok = process.Insert();
                if (!ok)
                {
                    Response.StatusCode = 500;
                    return;
                }
                if (Request.QueryString["idkhambenhchuyenphong"] != null && Request.QueryString["idkhambenhchuyenphong"].ToString() != "")
                {
                    DataProcess khambenhcp = new DataProcess("KHAMBENH");
                    khambenhcp.data("idkhambenh", Request.QueryString["idkhambenhchuyenphong"]);
                    khambenhcp.data("idkhambenhchuyenphong", process.getData("idkhambenh"));
                    khambenhcp.data("idkhambenhmoi", process.getData("idkhambenh"));
                    khambenhcp.Update();

                }
            }
            #endregion
            #region Luu chan doan phoi hop
            string idcdphoihop = Request.QueryString["idicd"];
            DataProcess cdphoihop = new DataProcess("chandoanphoihop");
            cdphoihop.data("idkhambenh", process.getData("idkhambenh"));
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
                        cdphoihop.data("idkhambenh", process.getData("idkhambenh"));
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
            #endregion
            #region Luu lai IdBacsi cho phien giao dien tiep theo cua dieu duong
            string idBacSiDieuDuong = SysParameter.UserLogin.IdBacSi(this);
            if (idBacSiDieuDuong == null || idBacSiDieuDuong == "" || idBacSiDieuDuong == "0")
            {

                string UserName = SysParameter.UserLogin.UserName(this);
                string FullName = SysParameter.UserLogin.FullName(this);
                string Rol = SysParameter.UserLogin.GroupID(this);
                string IdBacSi_Current = process.getData("idbacsi");
                SysParameter.UserLogin.SaveUserLogin(this, UserName, UserID, FullName, Rol, IdBacSi_Current);
            }
            #endregion
            #region LuuBenhNhanNoiTru
            string GiuongID = Request.QueryString["giuongid"];
            string PhongID = process.getData("PhongID");
            if (GiuongID != null && PhongID != null && GiuongID != "" && PhongID != "")
            {

                string sqlSelectOldGiuong = "SELECT * FROM BENHNHANNOITRU WHERE IdGiuong=" + GiuongID
                    + " AND IdPhongNoiTru=" + PhongID
                    + " AND IDCHITIETDANGKYKHAM=" + idchitietdangkykham;

                DataTable dtGiuong_old = DataAcess.Connect.GetTable(sqlSelectOldGiuong);
                if (dtGiuong_old != null)
                {
                    if (dtGiuong_old.Rows.Count == 0)
                    {
                        string GiaGiuong = "0";
                        DataTable dtGiaGiuong = DataAcess.Connect.GetTable("select giadv from kb_banggiagiuong where giuongid='" + Request.QueryString["giuongid"] + "'");
                        if (dtGiaGiuong != null && dtGiaGiuong.Rows.Count > 0) GiaGiuong = dtGiaGiuong.Rows[0][0].ToString();
                        DataProcess _benhnhannoitru = new DataProcess("BENHNHANNOITRU");
                        _benhnhannoitru.data("NgayVaoVien", process.getData("ngaykham"));
                        _benhnhannoitru.data("NhapTuKhoa", process.getData("IdKhoa"));
                        _benhnhannoitru.data("IdKhoaNoiTru", process.getData("IdKhoa"));
                        _benhnhannoitru.data("IdChiTietDangKyKham", idchitietdangkykham);
                        _benhnhannoitru.data("IdKhamBenhGoc", process.getData("idkhambenhchuyenphong"));
                        _benhnhannoitru.data("IdBenhNhan", process.getData("IdBenhNhan"));
                        _benhnhannoitru.data("IdPhongNoiTru", PhongID);
                        _benhnhannoitru.data("IdGiuong", GiuongID);
                        _benhnhannoitru.data("GhiChu", "Nhập hậu phẫu");
                        _benhnhannoitru.data("GiaGiuong", GiaGiuong);
                        _benhnhannoitru.data("IsDaNhap", "0");
                        _benhnhannoitru.data("IdKhamBenhNhap", process.getData("IdKhamBenh"));
                        _benhnhannoitru.data("idbacsiNhap", Request.QueryString["idbacsi"]);
                        _benhnhannoitru.data("iddieuduongNhap", SysParameter.UserLogin.UserID(this));
                        _benhnhannoitru.data("isChonTrongNgay", "0");
                        _benhnhannoitru.data("isChonNgaysau", "0");
                        _benhnhannoitru.data("songay", "");
                        _benhnhannoitru.data("isNhapKhoa", "0");
                        _benhnhannoitru.data("isChoSanh", "0");
                        _benhnhannoitru.Insert();
                    }
                }
            }
            #endregion
            #region luu sinh hieu
            DataProcess sinhieu = this.s_sinhhieu();
            string idSinhHieu = null;
            string sqlSelectSinhHieu = "SELECT TOP 1 IDSINHHIEU FROM SINHHIEU WHERE IDDANGKYKHAM='" + iddangkykham + "' AND IDKHAMBENH=" + process.getData("idkhambenh");
            DataTable dtSH = DataAcess.Connect.GetTable(sqlSelectSinhHieu);
            if (dtSH != null && dtSH.Rows.Count > 0)
                idSinhHieu = dtSH.Rows[0][0].ToString();
            if (idSinhHieu == null || idSinhHieu == "")
            {
                sinhieu.data("Iddangkykham", iddangkykham);
                sinhieu.data("idchitietdangkykham", idchitietdangkykham);
                sinhieu.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
                sinhieu.data("ngaydo", process.getData("ngaykham"));
                sinhieu.data("idkhoasinhhieu", process.getData("idkhoa"));
                sinhieu.data("idkhambenh", process.getData("idkhambenh"));
                bool Insert_SH = sinhieu.Insert();
            }
            else
            {
                sinhieu.data("idsinhhieu", idSinhHieu);
                bool Update_SH = sinhieu.Update();
            }
            #endregion
            #region Return true
            Response.Clear(); Response.Write(process.getData("idkhambenh"));
            return;
            #endregion
        }
        #region false  (catch)
        catch
        {
            Response.StatusCode = 500;
        }
        #endregion

    }
    public void LuuTablechitietbenhnhantoathuoc()
    {
        try
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            #region Properties
            string idthuoc = Request.QueryString["idthuoc"];
            string tenthuoc = Request.QueryString["mkv_idthuoc"];
            string iddvt = Request.QueryString["iddvt"];
            string dvt = Request.QueryString["mkv_iddvt"];
            string idcachdung = Request.QueryString["idcachdung"];
            string cachdung = Request.QueryString["mkv_idcachdung"];
            string congthuc = Request.QueryString["mkv_congthuc"];
            string dvdung = Request.QueryString["mkv_iddvdung"];
            string loaithuocid = Request.QueryString["DoiTuongThuocID"];
            string loaithuoc = Request.QueryString["mkv_DoiTuongThuocID"];
            #endregion
            #region Check IDThuoc
            string Message = null;
            string IdThuoc_Save = null;
            bool OK_CheckThuoc = StaticData.AutoCheckSaveThuoc(idthuoc, tenthuoc, iddvt, dvt, idcachdung, cachdung
                                                                , congthuc, dvdung, loaithuocid, loaithuoc
                                                                , ref Message, ref IdThuoc_Save);
            if (!OK_CheckThuoc || idthuoc == null)
            {
                Response.StatusCode = 500;
                Response.Write(Message);
                return;
            }
            if (idthuoc != IdThuoc_Save)
            {
                process.data("idthuoc", IdThuoc_Save);
            }
            #endregion

            string idkhambenh = process.getData("idkhambenh");
            string sqlKhamBenh = "SELECT * FROM KHAMBENH WHERE IDKHAMBENH=" + idkhambenh;
            DataTable dtKhamBenh = DataAcess.Connect.GetTable(sqlKhamBenh);

            string TGXuatVien = dtKhamBenh.Rows[0]["TGXuatVien"].ToString();
            TGXuatVien = DateTime.Parse(TGXuatVien).ToString("dd/MM/yyyy hh:mm:ss");


            DataProcess benhnhantoathuoc = new DataProcess("benhnhantoathuoc");
            benhnhantoathuoc.data("idkhambenh", process.getData("idkhambenh"));
            benhnhantoathuoc.data("ngayratoa", TGXuatVien);
            benhnhantoathuoc.data("idbenhnhan", dtKhamBenh.Rows[0]["idbenhnhan"].ToString());
            benhnhantoathuoc.data("idbacsi", dtKhamBenh.Rows[0]["idbacsi"].ToString());
            string idbenhnhantoathuoc = null;
            DataTable dtBNTT = DataAcess.Connect.GetTable("SELECT IDBENHNHANTOATHUOC FROM BENHNHANTOATHUOC WHERE IDKHAMBENH=" + process.getData("idkhambenh"));
            if (dtBNTT != null && dtBNTT.Rows.Count > 0)
                idbenhnhantoathuoc = dtBNTT.Rows[0][0].ToString();
            benhnhantoathuoc.data("idbenhnhantoathuoc", idbenhnhantoathuoc);

            if (idbenhnhantoathuoc == null || idbenhnhantoathuoc == "")
            {
                bool InsertBNTT = benhnhantoathuoc.Insert();
                if (InsertBNTT == true)
                {
                    idbenhnhantoathuoc = benhnhantoathuoc.getData("idbenhnhantoathuoc");
                    process.data("idbenhnhantoathuoc", idbenhnhantoathuoc);
                }
            }
            else
            {
                benhnhantoathuoc.data("ngayratoa", DateTime.Now.ToString("dd/MM/yyyy"));
                benhnhantoathuoc.Update();
                process.data("idbenhnhantoathuoc", idbenhnhantoathuoc);
            }
            //#region kiemtra loaitoa
            //string idkho = process.getData("idkho").ToString().Trim();
            //if (idkho != null && idkho != "")
            //{
            //    process.data("idbenhnhantoathuoc", "0");
            //}
            //#endregion

            if (process.getData("idchitietbenhnhantoathuoc") != null && process.getData("idchitietbenhnhantoathuoc") != "")
            {
                 
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
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
    public void LuuTablekb_EkipBacsi()
    {
        try
        {
            DataProcess process = s_bacsi_ekip();
            if (process.getData("idkhambenh").Trim() == "")
            {
                Response.StatusCode = 500;
                return;
            }
            if (process.getData("id") != null && process.getData("id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("id"));
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

            string sysdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            DataProcess process = s_khambenhcanlamsan();

            string idkhambenhcanlamsan = process.getData("idkhambenhcanlamsan");

            if (process.getData("idcanlamsan") != null && process.getData("idcanlamsan") != "" && process.getData("idcanlamsan") != "0")
            {
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
                            maphieucls = StaticData.NewSoChungTu(StaticData.CheckDate(sysdate), null, "Chỉ định CLS", "0");
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
                if (process.getData("idkhambenhcanlamsan") != "")
                {
                    bool ok = process.Update();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                        return;
                    }
                }
                else
                {
                    process.data("dathu", "0");
                    bool ok = process.Insert();
                    if (ok)
                    {
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
    private void luuTongTienKham()
    {
        string idkhambenh = Request.QueryString["idkhambenh"].ToString();
        bool IsChoVeKT = false;
        bool IsChuyenVien = false;
        bool iskhongkham = false;
        DataTable dtKhamBenh = DataAcess.Connect.GetTable("SELECT IsChoVeKT,IsChuyenVien,IdBenhVienChuyen,iskhongkham FROM KHAMBENH WHERE IDKHAMBENH=" + idkhambenh);
        if (dtKhamBenh != null && dtKhamBenh.Rows.Count > 0)
        {
            IsChoVeKT = StaticData.IsCheck(dtKhamBenh.Rows[0]["IsChoVeKT"].ToString());
            IsChuyenVien = StaticData.IsCheck(dtKhamBenh.Rows[0]["IsChuyenVien"].ToString());
            iskhongkham = StaticData.IsCheck(dtKhamBenh.Rows[0]["iskhongkham"].ToString());
        }
        #region IsHaveCLS

        string IsHaveCLS = "0";
        string sqlSelectCLS = @"Select top 1 IDKHAMBENH FROM KHAMBENHCANLAMSAN WHERE IDKHAMBENH=" + idkhambenh;
        DataTable dtCLS = DataAcess.Connect.GetTable(sqlSelectCLS);
        if (dtCLS != null && dtCLS.Rows.Count > 0)
        {
            IsHaveCLS = "1";
            bool ok_IsHaveCLS = DataAcess.Connect.ExecSQL("UPDATE KHAMBENH SET IsHaveCLS=" + IsHaveCLS + " WHERE IDKHAMBENH=" + idkhambenh);
        }
        #endregion
        #region IsTaiKham
        try
        {
            string sqlUpdateTaiKham = @"update khambenh set IsTaiKham=1
                                            where idkhambenh=" + idkhambenh + @"
                                                  and   exists (select top 1 idkhambenh
                                                            from khambenh a 
                                                            left join kb_phong b on a.phongid=b.id
                                                            where a.idkhambenh<khambenh.idkhambenh
                                                            and a.idbenhnhan=khambenh.idbenhnhan
                                                            and b.dichvukcb=( select dichvukcb from kb_phong where id=khambenh.phongid )  
                            
                                                            )";
            bool ok_UpdateIsTaiKham = DataAcess.Connect.ExecSQL(sqlUpdateTaiKham);
        }
        catch
        {
        }


        #endregion
        #region Tính tiền
        StaticData.TinhLaiTien_ByIdKhamBenh(idkhambenh);
        #endregion
        #region Hướng điều trị
        string sqlSelect = "select * from khambenh where idkhambenh=" + idkhambenh;
        DataTable dtKhambenh = DataAcess.Connect.GetTable(sqlSelect);
        if (dtKhambenh == null || dtKhambenh.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("");

        }

        string huongdieutri = "5";
        string IdkhoaChuyen = dtKhambenh.Rows[0]["IdkhoaChuyen"].ToString();
        string IsChuyenPhongCoPhi = dtKhambenh.Rows[0]["IsChuyenPhongCoPhi"].ToString();
        #region Chuyển phòng
        if (IdkhoaChuyen != null && IdkhoaChuyen != "")
        {
            DataTable dtKhoaChuyen = DataAcess.Connect.GetTable("SELECT * FROM PHONGKHAMBENH WHERE IDPHONGKHAMBENH=" + IdkhoaChuyen);
            if (dtKhoaChuyen != null && dtKhoaChuyen.Rows.Count > 0 && StaticData.IsCheck(dtKhoaChuyen.Rows[0]["IsNoiTru"].ToString()))
            {
                huongdieutri = "8";
            }
            else
            {
                if (IsChuyenPhongCoPhi.ToLower() == "true" || IsChuyenPhongCoPhi == "1")
                {
                    huongdieutri = "7";
                    #region Lưu đăng ký khám, trường hợp yêu cầu chuyển phòng thu phí

                    string idbenhnhan = dtKhambenh.Rows[0]["IdBenhNhan"].ToString();
                    string NgayDangKy = dtKhambenh.Rows[0]["TGXuatVien"].ToString();
                    string PhongID_Chuyen = dtKhambenh.Rows[0]["IdChuyenPK"].ToString();
                    string sqlSelectChuyenKhoa = "SELECT TOP 1 * FROM KB_PHONG WHERE ID=" + PhongID_Chuyen;
                    DataTable dtChuyenKhoa = DataAcess.Connect.GetTable(sqlSelectChuyenKhoa);
                    if (dtChuyenKhoa == null || dtChuyenKhoa.Rows.Count == 0)
                    {
                        Response.Clear();
                        Response.Write("Chưa chọn phòng cần chuyển, sao tính được tiền");
                        Response.StatusCode = 500;
                        return;
                    }
                    string DichVuKCB = dtChuyenKhoa.Rows[0]["DichVuKCB"].ToString();

                    string sqlSelectDKK = "SELECT TOP 1 * FROM DANGKYKHAM WHERE IDKHAMBENH_CHUYEN=" + idkhambenh;
                    DataTable dtDKK = DataAcess.Connect.GetTable(sqlSelectDKK);
                    if (dtDKK == null)
                    {
                        Response.Clear();
                        Response.Write("Không thể kiểm tra đăng ký khám chuyển, liên hệ với Admin");
                        Response.StatusCode = 500;
                        return;
                    }
                    string sqlSaveDKK = null;
                    string sqlSaveCTDKK = null;
                    string IdDangKyKham_Chuyen = null;
                    if (dtDKK.Rows.Count == 0)
                    {
                        sqlSaveDKK = @"INSERT INTO DANGKYKHAM(idbenhnhan,ngaydangky,IDKHAMBENH_CHUYEN)
                                              VALUES(" + idbenhnhan + ",'" + NgayDangKy + "'," + idkhambenh + ")";
                        bool Ok_SaveDKK = DataAcess.Connect.ExecSQL(sqlSaveDKK);
                        if (!Ok_SaveDKK)
                        {
                            Response.Clear();
                            Response.Write("Không lưu đăng ký khám tự động, liên hệ với Admin");
                            Response.StatusCode = 500;
                            return;
                        }
                        dtDKK = DataAcess.Connect.GetTable(sqlSelectDKK);
                        IdDangKyKham_Chuyen = dtDKK.Rows[0][0].ToString();
                        string SoTT_DKK = "";
                        sqlSaveCTDKK = @"INSERT INTO CHITIETDANGKYKHAM(IDDANGKYKHAM,IDBANGGIADICHVU,PHONGID,SOTT,SOLUONG)
                                        VALUES (" + IdDangKyKham_Chuyen + "," + DichVuKCB + "," + PhongID_Chuyen + ",'" + SoTT_DKK + "',1)";
                        bool Insert_CTDKK = DataAcess.Connect.ExecSQL(sqlSaveCTDKK);
                        if (!Insert_CTDKK)
                        {
                            Response.Clear();
                            Response.Write("Không lưu chi tiết đăng ký khám tự động, liên hệ với Admin");
                            Response.StatusCode = 500;
                            return;
                        }
                        else
                        {
                            StaticData.TinhLaiTien_ByIdDangKyKham(IdDangKyKham_Chuyen);
                        }

                    }
                    else
                    {
                        IdDangKyKham_Chuyen = dtDKK.Rows[0][0].ToString();
                        string sqlSelectCTDKK = "SELECT TOP 1 * FROM CHITIETDANGKYKHAM WHERE IDDANGKYKHAM=" + IdDangKyKham_Chuyen;
                        DataTable dtCTDKK = DataAcess.Connect.GetTable(sqlSelectCTDKK);
                        if (dtCTDKK == null || dtCTDKK.Rows.Count == 0)
                        {
                            Response.Clear();
                            Response.Write("Không thể kiểm tra chi tiết đăng ký khám tự động, liên hệ với Admin");
                            Response.StatusCode = 500;
                            return;
                        }
                        string PhongID_Old = dtCTDKK.Rows[0]["PhongID"].ToString();
                        if (PhongID_Old != PhongID_Chuyen)
                        {
                            string IsDathu = dtCTDKK.Rows[0]["IsDaThu"].ToString();
                            string IsBNDaTra = dtCTDKK.Rows[0]["IsBNDaTra"].ToString();
                            if (StaticData.IsCheck(IsDathu) || StaticData.IsCheck(IsBNDaTra))
                            {
                                Response.Clear();
                                Response.Write("Đã thu phí chuyển phòng rồi,chỉ đổi phòng khác sau khi huỷ phiếu thu tương ứng");
                                Response.StatusCode = 500;
                                return;
                            }
                            string IdChiTietDangKyKham_chuyen = dtCTDKK.Rows[0][0].ToString();
                            string SoTT_DKK = "";
                            sqlSaveCTDKK = "UPDATE CHITIETDANGKYKHAM SET PHONGID=" + PhongID_Chuyen
                                            + " , IDBANGGIADICHVU=" + DichVuKCB
                                            + ", SOTT= '" + SoTT_DKK + "'"
                                            + " WHERE IDCHITIETDANGKYKHAM=" + IdChiTietDangKyKham_chuyen;
                            bool Update_CTDKK = DataAcess.Connect.ExecSQL(sqlSaveCTDKK);
                            if (!Update_CTDKK)
                            {
                                Response.Clear();
                                Response.Write("Không thể đổi phòng khác được");
                                Response.StatusCode = 500;
                                return;
                            }
                            else
                            {
                                StaticData.TinhLaiTien_ByIdDangKyKham(IdDangKyKham_Chuyen);
                            }

                        }
                    }
                    #endregion
                }

                else
                {
                    huongdieutri = "1";
                }
            }
        }
        #endregion
        #region khác
        else
        {
            string sqlSelectThuoc = @"
                    Select top 1 IDCHITIETBENHNHANTOATHUOC FROM CHITIETBENHNHANTOATHUOC WHERE IDKHAMBENH=" + idkhambenh;
            DataTable dtThuoc = DataAcess.Connect.GetTable(sqlSelectThuoc);
            if (dtThuoc != null && dtThuoc.Rows.Count > 0)
            {
                huongdieutri = "2";
            }
            else
            {
                if (IsHaveCLS == "1")
                {
                    huongdieutri = "6";
                }
            }
        }
        #endregion

        if (IsChoVeKT) huongdieutri = "3";
        else if (IsChuyenVien) huongdieutri = "4";
        else if (iskhongkham) huongdieutri = "20";
        string isxuatvien = Request.QueryString["IsXuatVien"];
        if (StaticData.IsCheck(isxuatvien)) huongdieutri = "17";
        bool ok = DataAcess.Connect.ExecSQL("update khambenh set huongdieutri=" + huongdieutri + " where idkhambenh = " + idkhambenh);
        if (!ok)
        {
            Response.Clear();
            Response.Write("");
        }

        string sqlSelectThuocBH = @"
                                Select top 1 IDCHITIETBENHNHANTOATHUOC 
                                        FROM CHITIETBENHNHANTOATHUOC A
                                        WHERE DBO.KB_ISTHUCSDBHYT2(A.IDCHITIETBENHNHANTOATHUOC)=1 AND  IDKHAMBENH=" + idkhambenh;
        DataTable dtThuocBH = DataAcess.Connect.GetTable(sqlSelectThuocBH);
        if (dtThuocBH != null && dtThuocBH.Rows.Count > 0)
        {
            DataAcess.Connect.GetTable("UPDATE KHAMBENH SET ISHAVETHUOCBH=1 WHERE IDKHAMBENH=" + idkhambenh);
        }
        else
        {
            DataAcess.Connect.GetTable("UPDATE KHAMBENH SET ISHAVETHUOCBH=0 WHERE IDKHAMBENH=" + idkhambenh);
        }
        bool OK_ISDAXUATTHUOC = DataAcess.Connect.ExecSQL("UPDATE KHAMBENH SET ISDAXUATTOATHUOC=DBO.HS_ISDAXUATTOATHUOC(IDKHAMBENH) WHERE IDKHAMBENH=" + idkhambenh);

        #endregion
        Response.Clear();
        Response.Write("1");
    }
    public void loadTablechitietbenhnhantoathuoc_full(DataTable table)
    {
        DataProcess process = s_chitietbenhnhantoathuoc();
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th></th>";
        html += "<th>Tên thuốc</th>";
        html += "<th>Số lượng</th>";
        html += "<th>Đơn giá</th>";
        html += "<th>Thành tiền</th>";
        html += "<th>Cách dùng</th>";
        html += "<th>Ngày uống</th>";
        html += "<th>Mỗi lần</th>";
        html += "<th>Ghi chú</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                html += "<td><a onclick='xoaontable(this)'>Xoá</a></td>";
                html += "<td><input id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='" + table.Rows[i]["tenloai"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)'  value='" + table.Rows[i]["tenthuoc"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongke"].ToString() + "' onblur='TestSo(this,false,false);tinhtienthuoc(this);'/></td>";
                html += "<td><input mkv='true' disabled='true' style='width:70px' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["dongia"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' disabled='true' style='width:70px' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["thanhtien"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' disabled='true' style='width:70px' id='cachdung' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["duongdung"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["moilanuong"].ToString() + "' /></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + "' /></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>" + (table.Rows.Count + 1) + "</td>";
        html += "<td><a onclick='xoaontable(this)'>Xoá</a></td>";
        html += "<td><input  id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idthuoc' type='text' onfocus='idthuocsearch(this)' value=''  class='down_select'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhtienthuoc(this);'></td>";
        html += "<td><input mkv='true' disabled='true' style='width:70px' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' disabled='true' style='width:70px' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' disabled='true' style='width:70px' id='cachdung' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:100px'/></td>";
        html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging("chitietbenhnhantoathuoc");
        Response.Clear(); Response.Write(html);
    }
    public void loadTablechitietbenhnhantoathuoc(DataTable table)
    {
        DataProcess process = s_chitietbenhnhantoathuoc();
        if (StaticData.EnableThanhTienThuoc)
        {
            loadTablechitietbenhnhantoathuoc_full(table);
            return;
        }

        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Đối tượng</th>";
        html += "<th>Nhóm</th>";
        html += "<th>Tên thuốc</th>";
        html += "<th>Hoạt chất</th>";
        html += "<th>ĐVT</th>";
        html += "<th>Số lượng</th>";
        html += "<th>Cách dùng</th>";
        html += "<th>Ngày dùng</th>";
        html += "<th>Mỗi lần</th>";
        html += "<th>Đơn vị dùng</th>";
        html += "<th>Sáng</th>";
        html += "<th>Trưa</th>";
        html += "<th>Chiều</th>";
        html += "<th>Tối</th>";
        html += "<th>Ghi chú</th>";
        html += "<th>Dùng theo</th>";
        html += "<th>?BH</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                html += "<td><a onclick='xoaontable(this)'>Xoá</a></td>";
                html += "<td><input mkv='true' id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='" + table.Rows[i]["tenloai"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='cateid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["cateid"].ToString() + "' onblur='TestSo(this,false,false);'/><input id='mkv_cateid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);cateidsearch(this)' value='" + table.Rows[i]["catename"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)'  value='" + table.Rows[i]["tenthuoc"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='mkv_congthuc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);congthucsearch(this)'  value='" + table.Rows[i]["congthuc"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='iddvt' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["iddvt"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_iddvt' type='text' onfocusout='chuyenformout(this)' style='width:50px' onfocus='chuyenphim(this);iddvtsearch(this)' value='" + table.Rows[i]["tendvt"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongke"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' id='idcachdung' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idcachdung"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idcachdung' type='text' onfocusout='chuyenformout(this)' style='width:50px' onfocus='chuyenphim(this);idcachdungsearch(this)' value='" + table.Rows[i]["tencachdung"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["moilanuong"].ToString() + "' /></td>";
                html += "<td><input mkv='true' id='iddvdung' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["iddvt"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_iddvdung' type='text' onfocusout='chuyenformout(this)' style='width:40px' onfocus='chuyenphim(this);iddvtsearch(this)' value='" + table.Rows[i]["tendvdung"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='issang' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["issang"].ToString() == "True" ? "checked" : "") + "'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='istrua' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istrua"].ToString() == "True" ? "checked" : "") + " ' /></td>";
                html += "<td><input mkv='true' style='width:30px' id='ischieu' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["ischieu"].ToString() == "True" ? "checked" : "") + "' /></td>";
                html += "<td><input mkv='true' style='width:30px' id='istoi' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istoi"].ToString() == "True" ? "checked" : "") + "' /></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + "' style='width:50px' /></td>";
                html += "<td>Ngày<input mkv='true' id='isngay' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (StaticData.IsCheck(table.Rows[i]["isngay"].ToString()) == true ? "checked" : "") + " />Tuần<input mkv='true' id='isngay' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (StaticData.IsCheck(table.Rows[i]["isngay"].ToString()) == true ? "checked" : "") + " /></td>";
                html += "<td><input mkv='true' id='isbh' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (StaticData.IsCheck(table.Rows[i]["sudungchobh"].ToString()) == true ? "BH" : "DV") + "' style='width:20px;' /></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>1</td>";
        html += "<td><a onclick='xoaontable(this)'>Xoá</a></td>";
        html += "<td><input mkv='true' id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='cateid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_cateid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);cateidsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)'  value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='mkv_congthuc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);congthucsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='iddvt' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_iddvt' type='text' mkv='true' onfocusout='chuyenformout(this)' style='width:50px' onfocus='chuyenphim(this);iddvtsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' id='idcachdung' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_idcachdung' mkv='true' type='text' onfocusout='chuyenformout(this)' style='width:50px' onfocus='chuyenphim(this);idcachdungsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
        html += "<td><input mkv='true' id='iddvdung' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_iddvdung' mkv='true' type='text' onfocusout='chuyenformout(this)' style='width:40px' onfocus='chuyenphim(this);iddvtsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='issang' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='istrua' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='ischieu' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='istoi' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:50px' /></td>";
        html += "<td>Ngày<input mkv='true' id='isngay' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' />Tuần<input mkv='true' id='istuan' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  value='' /></td>";
        html += "<td><input mkv='true' id='isbh' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:20px;' /></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging("chitietbenhnhantoathuoc");
        Response.Clear(); Response.Write(html);
    }
    public void loadTablechitietbacsi_ekip()
    {

        DataProcess process = s_bacsi_ekip();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        string sqlSelect = @"select STT=row_number() over (order by T.idkhambenh),T.*
                            ,A.tennhanvien,T.Idbacsi,B.TenVaiTro,T.IdVaiTro
                    from bacsi_ekip T
                    left join nhanvien a on t.idbacsi=a.idnhanvien
                    left join bacsi_vaitro b on t.idvaitro=b.id
                    where T.idkhambenh='" + process.getData("idkhambenh") + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table.Rows.Count == 0)
        {
            sqlSelect = @"SELECT ROW_NUMBER() OVER (ORDER BY ID) AS STT, id=NULL
	                        ,idkhambenh=NULL
	                        ,idbacsi=NULL
	                        ,tennhanvien=NULL
	                        ,idvaitro=id
	                        ,TenVaiTro
                        from bacsi_vaitro order by sott ";
            table = DataAcess.Connect.GetTable(sqlSelect);
        }
        string html = "";
        html += "<table class='jtable' id=\"gridTable_EkipMo\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Tên PTV/ĐD.DC </th>";
        html += "<th>Vai trò</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + table.Rows[i]["STT"].ToString() + "</td>";
                html += "<td><a onclick='xoaontable_ekipmo(this)'>Xoá</a></td>";
                html += "<td><input mkv='true' id='idnhanvien' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idbacsi"].ToString() + "' /><input mkv='true' id='mkv_idnhanvien' type='text' onfocusout='chuyenformout(this)' style='width:90%' onfocus='chuyenphim(this);idnhanviensearch(this)' value='" + table.Rows[i]["tennhanvien"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='idvaitro' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idvaitro"].ToString() + "' /><input id='mkv_idvaitro' type='text' onfocusout='chuyenformout(this)' style='width:90%' onfocus='chuyenphim(this);idvaitrosearch(this)' value='" + table.Rows[i]["tenvaitro"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["id"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>" + ((table.Rows.Count > 0 && table != null) ? table.Rows.Count + 1 : 1) + "</td>";
        html += "<td><a onclick='xoaontable_ekipmo(this)'>Xoá</a></td>";
        html += "<td><input mkv='true' id='idnhanvien' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /><input id='mkv_idnhanvien' type='text' onfocusout='chuyenformout(this)' style='width:90%' onfocus='chuyenphim(this);idnhanviensearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idvaitro' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_idvaitro' type='text' onfocusout='chuyenformout(this)' style='width:90%' onfocus='chuyenphim(this);idvaitrosearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        Response.Clear();
        Response.Write(html);
    }
    public void loadTablechitietbenhnhantoathuoc()
    {

        DataProcess process = s_chitietbenhnhantoathuoc();
        string idkho = Request.QueryString["idkho"];
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        string sqlSelect = @"select STT=row_number() over (order by t.idkho,t.doituongthuocid,T.idchitietbenhnhantoathuoc),T.*
                                ,A.tenthuoc
                                ,B.LoaiThuocID
                                ,B.TenLoai
                                ,C.tencachdung
                                ,D.TenDVT as DVT
                                ,E.TenDVT as DVDung
                                ,F.catename
                                ,F.CateId
                                ,A.CongThuc
                                ,A.sudungchobh
                                ,k.tenkho
                                ,slton=t.slton
                                ,isdaxuat=[dbo].[KB_SLTHUCXUAT](t.idchitietbenhnhantoathuoc)
,idctYc= isnull((select top 1 idThuoc_ChiTietYeuCau from nvk_thuoc_chitietycxuat where idchitietbenhnhantoathuoc = t.idchitietbenhnhantoathuoc),0)
                                from chitietbenhnhantoathuoc T
                                left join thuoc  A on T.idthuoc=A.idthuoc
                                left join Thuoc_LoaiThuoc  B on A.LoaiThuocID=B.LoaiThuocID
                                left join Thuoc_CachDung  C on T.idcachdung=C.idcachdung
                                left join Thuoc_DonViTinh  D on T.iddvt=D.Id
                                left join Thuoc_DonViTinh  E on T.iddvdung=E.Id
                                left join Thuoc_DoiTuongThuoc DTT on T.DoiTuongThuocID=DTT.DoiTuongThuocID
                                left join category  F on T.cateid=F.cateid
                         left join khothuoc k on k.idkho = T.idkho 
                
                    where T.idkhambenh='" + process.getData("idkhambenh") + "'";
        if (idkho != null && idkho != "")
        {
            sqlSelect += " and t.idkho='" + idkho + "'";
        }

        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html = loadTablechitietbenhnhantoathuoc2(table, null, true);
        Response.Clear();
        Response.Write(html);
    }
    private string loadTablechitietbenhnhantoathuoc2(DataTable table, string[] arrslvack, bool idctbntt)
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string loaidk = Request.QueryString["loaidk"];
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th style='" + (idkhoa == "1" ? "display:none" : "") + "'>Kho xuất</th>";
        html += "<th>Loại</th>";
        html += "<th>Tên thuốc/VTYT/HC</th>";
        html += "<th>ĐVT</th>";
        html += "<th>SL</th>";
        html += "<th>? Hao phí</th>";
        html += "<th style='" + (loaidk == "1" ? "" : "display:none") + "'>?Trong dm</th>";
        html += "<th style='" + (loaidk == "1" ? "" : "display:none") + "'>?Thỏa đk</th>";
        html += "<th>SL Tồn</th>";
        html += "<th>Đã xuất</th>";
        html += "<th></th>";
        html += "</tr>";
        bool add = true;
        bool search = true; ;
        if (search)
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            process.Page = Request.QueryString["page"];

            if (table != null && table.Rows.Count > 0)
            {

                bool delete = true;
                bool edit = true;
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    string idkhoachinh = "";
                    if (arrslvack != null)
                    {
                        for (int y = 0; y < arrslvack.Length; y++)
                        {
                            if (arrslvack[y].Split('^')[0].ToString() == table.Rows[i]["idthuoc"].ToString() && (int.Parse(arrslvack[y].Split('^')[1].ToString()) > 1 || arrslvack[y].Split('^')[2].ToString() != ""))
                            {

                                idkhoachinh = arrslvack[y].Split('^')[2].ToString();
                                break;
                            }
                        }
                    }
                    string disable_editThuoc = " disabled=disabled ";
                    try
                    {
                        if (table.Rows[i]["idctYc"].ToString().Equals("0"))
                            disable_editThuoc = "";
                    }
                    catch (Exception)
                    {
                        disable_editThuoc = " ";
                    }
                    bool IsSuDungChoBH = StaticData.IsCheck(table.Rows[i]["sudungchobh"].ToString());
                    bool IsBHYT_Save = StaticData.IsCheck(table.Rows[i]["IsBHYT_Save"].ToString());
                    html += "<tr style='background-color:" + (IsSuDungChoBH == true ? "" : "#CAE3FF") + ";'>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                    html += "<td style='" + (idkhoa == "1" ? "display:none" : "") + "'><input mkv='true' id='idkhoxuat' type='hidden' value='" + table.Rows[i]["idkho"] + "'/><input mkv='true' id='mkv_idkhoxuat' type='text'  type='text' onfocusout='chuyenformout(this)' onfocus='idkhoxuatsearch(this);' style='width:90%' value='" + table.Rows[i]["tenkho"].ToString() + "' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='LoaiThuocID' type='hidden' value='" + table.Rows[i]["LoaiThuocID"] + "'/><input mkv='true' id='mkv_LoaiThuocID' type='text' value='" + table.Rows[i]["TenLoai"].ToString() + "' onfocus='loaithuocidsearch(this);' style='width:90%' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' " + disable_editThuoc + " id='mkv_idthuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='idthuocsearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:350px' /></td>";
                    html += "<td><input mkv='true' id='iddvt' type='hidden' value='" + table.Rows[i]["iddvt"] + "'/><input mkv='true' id='mkv_iddvt' type='text' value='" + table.Rows[i]["DVT"].ToString() + "' onfocus='iddvtsearch(this);' style='width:90%; text-align:left;' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongke"].ToString() + "' style='width:90%' onblur='TestSo(this,false,false);checkslton(this);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='IsHaoPhi' type='checkbox' " + (StaticData.IsCheck(table.Rows[i]["ishaophi"].ToString()) ? "checked" : "") + " " + (!edit ? "disabled" : "") + " onblur='chuyenhuong(this);' /></td>";
                    html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='sudungchobh' type='checkbox' " + (IsSuDungChoBH ? "checked='checked' " : "") + " disabled='disabled' onblur='chuyenhuong(this);' /></td>";
                    html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='IsBHYT_Save' type='checkbox' " + ((IsBHYT_Save && IsSuDungChoBH) ? "checked='checked'" : "disabled='disabled'") + " onblur='chuyenhuong(this);' /></td>";
                    html += "<td><input mkv='true' id='slton' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["slton"].ToString() + "' style='width:90%' onblur='TestSo(this,false,false);chuyenhuong(this);' " + (!edit ? "disabled" : "") + " disabled /></td>";
                    html += "<td><input mkv='true' id='isdaxuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["isdaxuat"].ToString() + "' style='width:90%'  " + (!edit ? "disabled" : "") + " disabled /></td>";
                    html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idctbntt ? table.Rows[i]["idchitietbenhnhantoathuoc"] : idkhoachinh) + "'/><input mkv='true' id='idkho' type='hidden' value='" + table.Rows[i]["idkho"].ToString() + "'/></td>";
                    html += "</tr>";
                }
            }
        }
        if (add)
        {
            html += "<tr>";
            html += "<td>" + ((table.Rows.Count > 0 && table != null) ? table.Rows.Count + 1 : 1) + "</td>";
            html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td style='" + (idkhoa == "1" ? "display:none" : "") + "'><input mkv='true' id='idkhoxuat' type='hidden' value=''/><input mkv='true' id='mkv_idkhoxuat' type='text' onfocusout='chuyenformout(this)' onfocus='idkhoxuatsearch(this);' style='width:90%' class=\"down_select\" /></td>";
            html += "<td><input mkv='true' id='LoaiThuocID' type='hidden' value=''/><input mkv='true' id='mkv_LoaiThuocID' type='text' value='' onfocus='loaithuocidsearch(this);' class=\"down_select\" style='width:90%;'/></td>";
            html += "<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus='idthuocsearch(this);' class=\"down_select\" style='width:350px'/></td>";
            html += "<td><input mkv='true' id='iddvt' type='hidden' value=''/><input mkv='true' id='mkv_iddvt' type='text' value='' onfocus='iddvtsearch(this);' style='width:90%; text-algin:left;' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:90%' value='' onblur='TestSo(this,false,false);checkslton(this);' /></td>";
            html += "<td><input mkv='true' id='IsHaoPhi' type='checkbox' onblur='chuyenhuong(this);' /></td>";
            html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='sudungchobh' type='checkbox' onblur='chuyenhuong(this);' /></td>";
            html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='IsBHYT_Save' type='checkbox' onblur='chuyenhuong(this);' /></td>";
            html += "<td><input mkv='true' id='slton' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:90%' value='' onblur='TestSo(this,false,false);' disabled /></td>";
            html += "<td><input mkv='true' id='isdaxuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:90%' value=''  disabled /></td>";
            html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/><input mkv='true' id='idkho' type='hidden' value=''/></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td colspan='1'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
        html += "</table>";
        if (!search)
            html += "Bạn không có quyền xem.";

        return html;
    }
    public void loadTablekhambenhcanlamsan()
    {

        DataProcess process = s_khambenhcanlamsan();
        string IsChuyenPhong = Request.QueryString["IsChuyenPhong"];
        string idkhambenh = process.getData("idkhambenh");
        if (idkhambenh != null && idkhambenh != "" && idkhambenh != "0" && IsChuyenPhong == "1")
        {
            //DataTable dtTT = DataAcess.Connect.GetTable("SELECT TOP 1 IDCHITIETBENHNHANTOATHUOC FROM CHITIETBENHNHANTOATHUOC WHERE IDKHAMBENH=" + idkhambenh);
            //  if (dtTT != null && dtTT.Rows.Count > 0)
            idkhambenh = "";
        }


        process.NumberRow = "10000";
        process.Page = Request.QueryString["page"];
        string sqlSelect = @"select STT=row_number() over (order by T.idkhambenhcanlamsan),T.*
                                ,a.tendichvu,a.idbanggiadichvu,a.IsSuDungChoBH,a.tennhom,a.idphongkhambenh,pkb.tenphongkhambenh
                               from khambenhcanlamsan T
                                left join banggiadichvu a on t.idcanlamsan=a.idbanggiadichvu
                                left join phongkhambenh pkb on a.idphongkhambenh=pkb.idphongkhambenh
          where T.idkhambenh=" + (idkhambenh == "" ? "null" : "'" + idkhambenh + "' and isnull(t.dahuy,0)=0");
        DataTable table = process.Search(sqlSelect);
        string html = "";
        html += tableCLS(table, null, true);
        //  html += process.Paging("khambenhcanlamsan");
        Response.Clear();
        Response.Write(html);
    }
    public void loadTablelistbacsi()
    {


        DataProcess process = new DataProcess("bacsi_dieutri");
        process.data("idkhambenh", Request.QueryString["idkhambenh"]);
        string sql = @"select STT=row_number() over (order by T.id),
		    A.tenbacsi,t.id from bacsi_dieutri T
            left join bacsi A on A.idbacsi = T.id
            where T.idkhambenh='" + process.getData("idkhambenh") + @"'
            ";
        DataTable table = process.Search(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<div style='text-align:left;float:left;width:500px;padding-left:30px;height:30px'>";
                    html += "<a style='cursor:pointer' onclick='$(this).parent().remove();'>Xoá</a> -- ";
                    html += "<input type='hidden' mkv='true' id='idbacsidieutri' value='" + table.Rows[i]["id"].ToString() + "'/>";
                    html += table.Rows[i]["tenbacsi"].ToString();
                    html += "</div>";
                }
            }
        }
        Response.Clear(); Response.Write(html);
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
                    html += "<div style='text-align:left;float:left;width:500px;padding-left:30px;height:30px'>";
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
        string html = "";
        string loaidk = Request.QueryString["loaidk"];
        html += "<table class='jtable' id=\"gridTablecls\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Khoa</th>";
        html += "<th>Tên nhóm</th>";
        html += "<th>Tên dịch vụ</th>";
        html += "<th>Số lượng</th>";
        html += "<th>Đơn giá</th>";
        html += "<th>Thành tiền</th>";
        html += "<th style='" + (loaidk == "1" ? "" : "display:none") + "'>?Trong dm</th>";
        html += "<th style='" + (loaidk == "1" ? "" : "display:none") + "'>?Thỏa đk</th>";
        html += "<th></th>";
        html += "</tr>";
        if (dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ck = 0;
                int sl = 1;

                string idkhoachinh = "";
                if (arrslvack != null)
                {
                    for (int y = 0; y < arrslvack.Length - 1; y++)
                    {
                        if (arrslvack[y].Split('^')[0].ToString() == dt.Rows[i]["idbanggiadichvu"].ToString() && (int.Parse(arrslvack[y].Split('^')[1].ToString()) > 1 || arrslvack[y].Split('^')[3].ToString() != ""))
                        {
                            ck = StaticData.ParseInt(arrslvack[y].Split('^')[2].ToString());
                            sl = StaticData.ParseInt(arrslvack[y].Split('^')[1].ToString());
                            idkhoachinh = arrslvack[y].Split('^')[3].ToString();
                            break;
                        }
                    }
                }
                try
                {
                    sl = StaticData.ParseInt(dt.Rows[i]["soluong"].ToString());
                    ck = StaticData.ParseInt(dt.Rows[i]["chietkhau"].ToString());
                }
                catch { }
                #region check_baohiem_save
                bool IsSuDungChoBH = StaticData.IsCheck(dt.Rows[i]["IsSuDungChoBH"].ToString());
                bool IsBHYT_Save = StaticData.IsCheck(dt.Rows[i]["IsBHYT_Save"].ToString());
                bool IsDathu = StaticData.IsCheck(dt.Rows[i]["dathu"].ToString());
                string isCheck = "";
                if (IsSuDungChoBH && IsDathu && IsBHYT_Save)
                {
                    isCheck += " checked disabled";
                }
                else if (IsSuDungChoBH && !IsDathu && !IsBHYT_Save)
                {
                    isCheck += " checked";
                }
                else if (!IsSuDungChoBH && !IsDathu && !IsBHYT_Save)
                {
                    isCheck += "disabled";
                }
                else if (IsDathu)
                {
                    isCheck += "disabled";
                }
                #endregion
                int thanhtien = (dt.Rows[i]["dongia"].ToString() != "" ? sl * int.Parse(dt.Rows[i]["dongia"].ToString()) : 0); ;
                html += "<tr " + (IsSuDungChoBH == true ? "" : "style='background-color:#CAE3FF'") + " >";
                html += "<td>" + dt.Rows[i]["stt"] + "</td>";
                html += "<td><a onclick='xoaontablecls(this)'>Xoá</a></td>";
                html += "<td><input mkv='true' id='idkhoa' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idphongkhambenh"] + " ' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idkhoa' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhoasearch(this)' onblur='idkhoachange(this);' value='" + dt.Rows[i]["tenphongkhambenh"] + "'  style='width:150px' class='down_select' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='mkv_tennhom' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idphongsearch(this)' value='" + dt.Rows[i]["tennhom"] + "'  style='width:180px' class='down_select' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idbanggiadichvu"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='" + dt.Rows[i]["tendichvu"] + "'  style='width:330px' class='down_select' " + (IsDathu ? "disabled='disabled'" : "") + " /></td>";
                html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + sl + "' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();'  style='width:90%' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["dongia"] + "' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();;' style='width:90%' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ((thanhtien - (thanhtien * ck) / 100)).ToString() + "'  style='width:90%' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='IsSuDungChoBH' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'" + (IsSuDungChoBH ? "checked='checked'" : "disabled='disabled'") + (IsDathu ? "disabled='disabled'" : "") + "  style='width:90%' /></td>";
                html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='IsBHYT_save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (IsBHYT_Save ? "checked='checked'" :"")+ isCheck + " style='width:90%' /></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : idkhoachinh) + "'/><a onclick='huyontablecls(this)'>Hủy</a></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>" + (dt.Rows.Count + 1) + "</td>";
        html += "<td><a onclick='xoaontablecls(this)'>Xoá</a></td>";
        html += "<td><input mkv='true' id='idkhoa' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idkhoa' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhoasearch(this)' value=''  style='width:150px' class='down_select'/></td>";
        html += "<td><input mkv='true' id='mkv_tennhom' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idphongsearch(this)' value=''  style='width:180px' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)'  style='width:330px' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();'  style='width:90%'/></td>";
        html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls()' style='width:90%' /></td>";
        html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:90%; text-algin:right' /></td>";
        html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='IsSuDungChoBH' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:90%' /></td>";
        html += "<td style='" + (loaidk == "1" ? "" : "display:none") + "'><input mkv='true' id='IsBHYT_save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:90%' /></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/><a onclick='huyontablecls(this)'>Hủy</a></td>";
        html += "</tr>";
        html += "<tr ><td></td><td colspan='4' align='right' style='font-weight:bold; font-size:13px;'>Tổng Cộng</td><td style='font-weight:bold;text-align:right; font-size:14px; padding-right:5px;' colspan='3'></td><td></td><td></td></tr>";
        html += "</table>";
        return html;
    }
    private void ChonCLS()
    {
        string loaidk = Request.QueryString["loaidk"];
        if (loaidk == null || loaidk == "")
        {
            DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN WHERE idbenhnhan='" + Request.QueryString["idbenhnhan"] + "'");
            if (dtBN != null && dtBN.Rows.Count > 0)
            {
                loaidk = dtBN.Rows[0][0].ToString();
            }
        }
        string listidcanlamsan = Request.QueryString["listID"];
        string[] arridcls = listidcanlamsan.Split(',');
        listidcanlamsan = listidcanlamsan.TrimEnd(',');
        string swhere = "";
        string html = "";
        int idpkb = StaticData.ParseInt(Request.QueryString["idpkb"]);
        string tenNhom = Request.QueryString["tN"];
        if (idpkb == 0)
        {
        }
        else
        {
            swhere = " and Bg.idphongkhambenh=" + idpkb + " ";
        }
        string selectIDDVNhomCLS = "select tenNhom,dbo.[GetIdBanggiaDVByNhomCLS](n.nhomId) as idDV from KB_NhomCLS n where status='true' order by n.tenNhom";
        DataTable arrIDDVNhomCLS = DataAcess.Connect.GetTable(selectIDDVNhomCLS);
        html += "Tên nhóm :";
        if (arrIDDVNhomCLS.Rows.Count != 0 && arrIDDVNhomCLS != null)
        {

            for (int i = 0; i < arrIDDVNhomCLS.Rows.Count; i++)
            {
                html += "<input  type=\"button\" style=\"cusor:pointer\" onclick=\"ChonCLS(this,'" + arrIDDVNhomCLS.Rows[i]["idDV"].ToString() + "');\" name=\"rbnSearchNhom\" value=\"" + arrIDDVNhomCLS.Rows[i]["tenNhom"].ToString() + "\"/>";
                html += "&nbsp;";
            }
            html += "<br/>";
        }
        string selectTenPhong = "select tenphongkhambenh,pkb.idphongkhambenh from phongkhambenh pkb where loaiphong=1 order by pkb.idphongkhambenh";
        DataTable arrT = DataAcess.Connect.GetTable(selectTenPhong);
        html += "Tên Khoa/Phòng:";
        for (int i = 0; i < arrT.Rows.Count; i++)
        {
            html += "<input  style=\"width:auto\" type=\"button\" onclick=\"ChonCLS(this,null,'" + arrT.Rows[i]["idphongkhambenh"].ToString() + "');\" name=\"rbnSearch\" value=\"" + arrT.Rows[i]["tenphongkhambenh"].ToString() + "\"/>";
        }
        html += "<table class='jtable' border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\">";
        string sqlSelectTenNhom = ""
                                    + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh" + "\r\n"
                                    + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
                                    + " where  bg.idphongkhambenh='" + idpkb + "' AND   loaiphong=1 " + "\r\n";
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

                    html += "<a href=\"#\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";
                    if (((i + 1) % 4) == 0)
                    {
                        html += "</tr>";
                    }


                }
                tenN = tenN.TrimEnd(',');
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

                    html += "<a href=\"#\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";

                }
                tenN = tenN.TrimEnd(',');
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
            string sqlSelectIDDVByTN = ""
                     + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.BHTRA,A.PhuThuBH,A.IsSuDungChoBH " + "\r\n"
                     + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "' order by A.tendichvu" + "\r\n"
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
                        html += "<th align=\"left\" width='20px'>&nbsp;<input checked id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
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
                    html += "<th align=\"left\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
                }


            }
            else
            {
                html += "<th align=\"right\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
            }
            html += "<th  align=\"left\" width=\"70%\" class=\"ptext\" ><input style=\"width:auto\" type=\"button\" id=\"mkv" + mkv + "\" style=\"font-weight:bold\" value=\"" + t + "\"/></th>";
            html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Đơn giá</th>";
            html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;?BH</th>";
            html += "</tr>";
            mkv++;
            string sqlSelectTenDV = ""
                   + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.BHTRA,A.PhuThuBH,IsSuDungChoBH " + "\r\n"
                   + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "' order by A.tendichvu" + "\r\n"
                   + "  " + "\r\n";
            idDVCLSByTN = "";
            DataTable arrTenDV = DataAcess.Connect.GetTable(sqlSelectTenDV);
            {
                if (arrTenDV.Rows.Count != 0)
                {
                    foreach (DataRow tenDV in arrTenDV.Rows)
                    {

                        bool IsSuDungChoBH = StaticData.IsCheck(tenDV["IsSuDungChoBH"].ToString());
                        int dk = 0;
                        html += "<tr style='background-color:" + (IsSuDungChoBH == true ? "" : "#CAE3FF") + ";' width=\"100%\">";
                        string id = tenDV["idbanggiadichvu"].ToString();
                        for (int i = 0; i < arridcls.Length; i++)
                        {
                            string tam = arridcls[i].ToString();
                            if (id == tam)
                            {
                                html += "<td style=\" " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\" align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" checked  type=\"checkbox\" /></td>";
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
                            html += "<td style=\" " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\" align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" type=\"checkbox\" /></td>";
                        }
                        string DonGia = "";

                        if (loaidk == "1" && IsSuDungChoBH == true)
                        {
                            DonGia = tenDV["BHTra"].ToString();
                        }
                        else
                            DonGia = tenDV["GiaDichVu"].ToString();

                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\" width=\"70%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenDV["tendichvu"] + "</td>";
                        html += "<td width=\"20%\" class=\"ptext\" align = \"left\" style = \"padding-right:20px; " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\">" + StaticData.FormatNumber(DonGia, false).ToString() + "</td>";
                        html += "<td width=\"20%\" class=\"ptext\" align = \"left\" style = \"padding-right:20px; " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\">" + (IsSuDungChoBH == true ? "BH" : "DV") + "</td>";
                        html += "</tr>";
                    }

                }
            }
            html += "</table>";
        }

        Response.Clear();
        Response.Write(html);
    }
    private void XoaBacSiDieuTri()
    {
        try
        {
            DataProcess process = s_bacsi_ekip();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("id"));
                return;
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    //-------------------------------------------------------------------------------------------------------------------
    private void MakeSoVaoVien()
    {
        string idkhambenh = Request.QueryString["idkhambenh"];
        string idchitietdangkykham = Request.QueryString["idctdkk"];
        string IsNoiTru = Request.QueryString["IsNoiTru"];
        string SoVaoVien = StaticData_HS.GetSoVaoVien(idkhambenh, idchitietdangkykham, IsNoiTru);
        Response.Write(SoVaoVien);
    }
    //-------------------------------------------------------------------------------------------------------------------
    private void GetListSLTon_RealTime()
    {
        Dictionary<string, List<SLTON_RealTime>> _dic = new Dictionary<string, List<SLTON_RealTime>>();
        string lstIdThuoc = Request.QueryString["listThuoc"];
        string[] lstId = lstIdThuoc.Split('@');
        List<SLTON_RealTime> _ls = new List<SLTON_RealTime>();
        for (int i = 0; i < lstId.Length; i++)
        {
            string lst = lstId[i].TrimEnd('|').TrimEnd('@');
            if (lst != "")
            {
                string idthuoc = lstId[i].Split('|')[0].ToString();
                string idkho = lstId[i].Split('|')[1].ToString();
                string SQL = @"SELECT DBO.THUOC_TONKHO_NEW_1910(" + idthuoc + ",GETDATE()," + idkho + ")";
                DataTable dtSLTon = DataAcess.Connect.GetTable(SQL);
                if (dtSLTon != null && dtSLTon.Rows.Count > 0)
                {
                    SLTON_RealTime _SL = new SLTON_RealTime();
                    _SL.IdThuoc = idthuoc;
                    _SL.SLTon = dtSLTon.Rows[0][0].ToString();
                    _ls.Add(_SL);
                }
            }
        }
        _dic.Add("_JSON", _ls);
        JavaScriptSerializer ser = new JavaScriptSerializer();
        Response.Write(ser.Serialize(_dic));
    }
}
public class SLTON_RealTime
{
    private string _idthuoc;
    private string _slton;
    public string IdThuoc
    {
        get { return _idthuoc; }
        set { _idthuoc = value; }
    }
    public string SLTon
    {
        get { return _slton; }
        set { _slton = value; }
    }
}



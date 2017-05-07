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
using Microsoft.Office;

public partial class nvk_khamTongHop : System.Web.UI.Page
{
    private int iTotalFields = 0;
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
    protected DataProcess nvk_benhnhanxuatkhoa()
    {

        #region khai báo tham số hướng diều trị
        string idXuatK = Request.QueryString["idXuatK"];
        string idKBXK = Request.QueryString["idKBXK"];

        string HuongDT = Request.QueryString["HuongDT"];
        string NgayXK = Request.QueryString["NgayXK"];
        if (string.IsNullOrEmpty(NgayXK))
            NgayXK = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        else
            NgayXK += " " + Request.QueryString["GioXK"];
        string IdKhoaToi = "0"; string IdPhongToi = "0";
        string idBVToi = "0"; string IsDD = "0"; string IsBS = "0";
        string idCD = "0";
        string PPDTri = "0";
        string LDTThuoc = "0";
        string idTT = "0";
        string LyDoXK = "0";
        #endregion

        #region xac định giá trị đúng theo hướng điều trị
        if (HuongDT.Equals("1"))//Chuyển phòng KTP
        {
            IdKhoaToi = Request.QueryString["IdKhoaToi"];
            if (string.IsNullOrEmpty(IdKhoaToi))
                IdKhoaToi = "0";
            IdPhongToi = Request.QueryString["IdPhongToi"];
            if (string.IsNullOrEmpty(IdPhongToi))
                IdPhongToi = "0";
        }
        else if (HuongDT.Equals("3")) //Cho về
        {

        }
        else if (HuongDT.Equals("4")) //chuyen vien
        {
            idBVToi = Request.QueryString["idBVToi"];
            if (string.IsNullOrEmpty(idBVToi))
                idBVToi = "0";
            IsDD = Request.QueryString["IsDD"];
            if (!string.IsNullOrEmpty(IsDD) && IsDD.Equals("true"))
                IsDD = "1";
            else
                IsDD = "0";
            IsBS = Request.QueryString["IsBS"];
            if (!string.IsNullOrEmpty(IsBS) && IsBS.Equals("true"))
                IsBS = "1";
            else
                IsBS = "0";
            idCD = Request.QueryString["idCD"];
            if (string.IsNullOrEmpty(idCD))
                idCD = "0";
        }
        else if (HuongDT.Equals("8"))//Nhập viện (chuyen khoa)
        {
            IdKhoaToi = Request.QueryString["IdKhoaToi"];
            if (string.IsNullOrEmpty(IdKhoaToi))
                IdKhoaToi = "0";
        }
        else if (HuongDT.Equals("11"))//Tử vong
        {

        }
        else if (HuongDT.Equals("12"))//Lưu bệnh
        {

        }
        else if (HuongDT.Equals("13"))//Ngoại trú
        {

        }
        else if (HuongDT.Equals("14"))//Đang theo dõi
        {

        }
        else if (HuongDT.Equals("16"))//Bỏ về
        {

        }
        else if (HuongDT.Equals("17"))//Xuất viện
        {
            idCD = Request.QueryString["idCD"];
            if (string.IsNullOrEmpty(idCD))
                idCD = "0";
            PPDTri = Request.QueryString["PPDTri"];
            LDTThuoc = Request.QueryString["LDTThuoc"];
        }
        else if (HuongDT.Equals("18"))//Tiểu phẫu
        {

        }
        else if (HuongDT.Equals("19"))//Bệnh án ngoại trú
        {

        }
        #endregion

        #region chung nhiều hướng điều trị
        if (HuongDT.Equals("1") || HuongDT.Equals("3") || HuongDT.Equals("4") || HuongDT.Equals("8") || HuongDT.Equals("11") || HuongDT.Equals("16") || HuongDT.Equals("17"))
        {
            idTT = Request.QueryString["idTT"];
            if (string.IsNullOrEmpty(idTT))
                idTT = "0";
            LyDoXK = Request.QueryString["LyDoXK"];
        }
        #endregion

        DataProcess benhnhanxuatkhoa = new DataProcess("benhnhanxuatkhoa");
        benhnhanxuatkhoa.data("IdXuatKhoa", idXuatK);
        benhnhanxuatkhoa.data("NgayXuatKhoa", NgayXK);
        benhnhanxuatkhoa.data("IdKhoaXuat", Request.QueryString["idKNT"]);
        benhnhanxuatkhoa.data("IdChiTietDangKyKham", Request.QueryString["idctdkk"]);
        benhnhanxuatkhoa.data("IdKhamBenhXK", idKBXK);
        benhnhanxuatkhoa.data("IdBenhNhan", Request.QueryString["idbn"]);
        benhnhanxuatkhoa.data("IdHuongDieuTri", HuongDT);
        benhnhanxuatkhoa.data("IdKhoaChuyenDen", IdKhoaToi);
        benhnhanxuatkhoa.data("IdPhongChuyenDen", IdPhongToi);
        benhnhanxuatkhoa.data("IdBVChuyenDen", idBVToi);
        benhnhanxuatkhoa.data("PhuongPhapDT", PPDTri);
        benhnhanxuatkhoa.data("LoiDanXuatKhoa", LDTThuoc);
        benhnhanxuatkhoa.data("ChanDoanXuatKhoa", idCD);
        //benhnhanxuatkhoa.data("IsNhapLai", "dfdsd");
        benhnhanxuatkhoa.data("idtinhTrang", idTT);
        benhnhanxuatkhoa.data("LyDoXuatKhoa", LyDoXK);
        benhnhanxuatkhoa.data("isCoDieuDuongCV", IsDD);
        benhnhanxuatkhoa.data("isCoBacSiCV", IsBS);
        string MoTaCD_edit = Request.QueryString["MoTaCD_edit"];
        benhnhanxuatkhoa.data("MoTaCD_edit", MoTaCD_edit);
        return benhnhanxuatkhoa;
    }
    protected DataProcess nvk_sinhhieu()
    {
        DataProcess sinhhieu = new DataProcess("sinhhieu");
        sinhhieu.data("idsinhhieu", Request.QueryString["idSinhHieu"]);
        sinhhieu.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        sinhhieu.data("ngaydo", Request.QueryString["ngaydo"]);
        sinhhieu.data("mach", Request.QueryString["mach"]);
        sinhhieu.data("nhietdo", Request.QueryString["nhietdo"]);
        sinhhieu.data("huyetap1", Request.QueryString["huyetap1"]);
        sinhhieu.data("huyetap2", Request.QueryString["huyetap2"]);
        sinhhieu.data("nhiptho", Request.QueryString["nhiptho"]);
        sinhhieu.data("chieucao", Request.QueryString["chieucao"]);
        sinhhieu.data("cannang", Request.QueryString["cannang"]);
        sinhhieu.data("tiensubenh", Request.QueryString["tiensubenh"]);
        sinhhieu.data("BMI", Request.QueryString["BMI"]);
        sinhhieu.data("diungthuoc", Request.QueryString["diungthuoc"]);
        string iddangkykham = DataAcess.Connect.GetTable("select iddangkykham=isnull((select iddangkykham from chitietdangkykham where idchitietdangkykham='" + Request.QueryString["idctdkk"] + "'),0)").Rows[0][0].ToString();
        sinhhieu.data("Iddangkykham", iddangkykham);
        sinhhieu.data("idchitietdangkykham", Request.QueryString["idctdkk"]);
        sinhhieu.data("idkhoasinhhieu", Request.QueryString["IdKhoaNoiTru"]);
        sinhhieu.data("idnguoidung", SysParameter.UserLogin.UserID(this));
        return sinhhieu;
    }
    protected DataProcess nvk_tamung()
    {
        DataProcess tamung = new DataProcess("tamung");
        tamung.data("IDTamUng", Request.QueryString["IDTamUng"]);
        tamung.data("iddangkykham", Request.QueryString["iddangkykham"]);
        tamung.data("sotien", Request.QueryString["sotien"]);
        tamung.data("ngayTamung", Request.QueryString["ngayTamung"]);
        tamung.data("NgayHoanUng", Request.QueryString["NgayHoanUng"]);
        tamung.data("SoCTHU", Request.QueryString["SoCTHU"]);
        tamung.data("SoTienHU", Request.QueryString["SoTienHU"]);
        tamung.data("GhiChu", Request.QueryString["GhiChu"]);
        tamung.data("", Request.QueryString["SoCTTU"]);
        tamung.data("", Request.QueryString["IDTamUng"]);
        return tamung;
    }
    protected DataProcess nvk_chanDoanPhoiHop()
    {
        DataProcess chandoanphoihop = new DataProcess("chandoanphoihop");
        chandoanphoihop.data("id", Request.QueryString["idkhoachinh"]);
        chandoanphoihop.data("idkhambenh", Request.QueryString["idkhambenh"]);
        chandoanphoihop.data("idicd", Request.QueryString["idicd"]);

        string MoTaCD_edit = Request.QueryString["mkv_idicdMoTa"];
        chandoanphoihop.data("MoTaCD_edit", MoTaCD_edit);
        return chandoanphoihop;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "SetBenhNhanCongNo": nvk_SetBenhNhanCongNo(); break;
            case "SetBenhNhanDangKham": SetBenhNhanDangKham(); break;
            case "TimKiemBenhNhan": TimKiemBenhNhan(); break;
            case "LoadThongTinTamUng": LoadThongTinTamUng(); break;
            case "deleteTamUng": nvk_deleteTamUng(); break;
            case "nvk_LuuTamUng": nvk_LuuTamUng(); break;

            case "LoadThongTinTienGiuong": LoadThongTinTienGiuong(); break;
            case "ThemGiuongPOPUP": ThemGiuongPOPUP(); break;
            case "SuaGiuongPOPUP": SuaGiuongPOPUP(); break;
            case "SearchGiuongTheoPhong": SearchGiuongTheoPhong(); break;
            case "SearchGiaTheoGiuong": SearchGiaTheoGiuong(); break;
            case "UpdateGiuong": UpdateAjaxGiuong(); break;
            case "InsertGiuong": InsertAjaxGiuong(); break;

            case "LoadThongTinCDDichVu": LoadThongTinAjaxCDDichVu(); break;
            case "Luukhambenhmoi": Luukhambenhmoi(); break;
            case "LoadInfoCDThuoc": LoadInfoAjaxCDThuoc(); break;
            case "LoadDsClsCd": LoadDsClsCd(); break;
            case "LoadDsThuocCd": LoadDsThuocCd(); break;

            case "LoadThongTinVienPhi": LoadThongTinAjaxVienPhi(); break;
            case "LoadChiTietVienPhiCLS": LoadChiTietVienPhiCLS(); break;
            case "LoadChiTietVienPhiThuoc": nvk_LoadChiTietVienPhiThuoc(); break;

            case "LoadThongTinXuatKhoa": LoadThongTinAjaxXuatKhoa(); break;
            case "LoadNoiDungPhongDen": nvk_LoadNoiDungPhongDen(); break;
            case "LuuHuongDieuTri_XuatKhoa": nvk_LuuHuongDieuTri_XuatKhoa(); break;

            case "LoadInfoTraThuoc": nvk_LoadInfoAjaxTraThuoc(); break;
            case "loadTablechitietbenhnhanTraThuoc": nvk_loadTablechitietbenhnhanTraThuoc(); break;

            case "LoadThongTinSinhHieu": nvk_LoadThongTinSinhHieu(); break;
            case "LuuThongTinSinhHieu": nvk_LuuThongTinSinhHieu(); break;
            case "LoadDanhSachSinhHieu": nvk_LoadDanhSachSinhHieu(); break;
            case "LoadNoiDungDoSinhHieu": nvk_LoadNoiDungDoSinhHieu(); break;
            case "loadChiTietCongNoBenhNhan": nvk_loadChiTietCongNoBenhNhan(); break;

            // from CapCuu/ajax.aspx
            case "tamUng": nvk_showTamUng(); break;
            // from khambenh_ajax3
            case "SetChanDoanPhoiHop": nvk_SetChanDoanPhoiHop(); break;
            case "luuTableGiuongNoiTru": luuTableGiuongNoiTru_2509(); break; // edit
            case "xoachitietGiuongbn_noitru": nvk_xoachitietGiuongbn_noitru(); break;
            // from nvk_NhapKhoaSan
            case "ChanDoansearch": ChanDoansearch(); break;
            case "xoanvk_chanDoanPhoiHop": xoanvk_chanDoanPhoiHop(); break;
            case "xoanvk_chanDoanXuatKhoa": xoanvk_chanDoanXuatKhoa(); break;

            case "nvk_luutableChanDoanPhoiHop": nvk_luutableChanDoanPhoiHop(); break;
            case "nvk_luutableChanDoanPhoiHop_XK": nvk_luutableChanDoanPhoiHop_XK(); break;
            case "GetDSCLS": GetDSCLS(); break;
            case "nvk_TinhLaiTienBy_idctdkk": nvk_TinhLaiTienBy_idctdkk(); break;
            // from khambenh_TH/ajax/khambenh_ajax3.cs 
            case "luuTablechitietbenhnhantoathuoc_XuatVien": luuTablechitietbenhnhantoathuoc_XuatVien_new(); break;
            case "nvkHuyChiDinhXuatKhoa": nvkHuyChiDinhXuatKhoa(); break;
            case "HuyTamTheoDoi": nvk_HuyTamTheoDoi(); break;
            case "THChanDoan_click": THChanDoan_click(); break;
            case "ChonclsThuongquy": ChonclsThuongquy(); break;
            case "getListCSLThuongQuy": getListCSLThuongQuy(); break;

            case "XuatExcelDSNoiTru": XuatExcelDSNoiTru(); break;
        }
    }
    #region hủy tạm theo dõi khám nội trú 
    private void nvk_HuyTamTheoDoi()
    {
        string value = "Lỗi hủy theo dõi bệnh nhân !";
        string idctdkk = Request.QueryString["idctdkk"];
        string idkhoanoitru = Request.QueryString["IdKhoaNoiTru"];
        string up = "update benhnhannoitru set isTamTheoDoi=0 where idchitietdangkykham ='" + idctdkk + "' and idkhoanoitru ='" + idkhoanoitru + "' ";
        bool kt = DataAcess.Connect.ExecSQL(up);
            if (kt)
                value = "1";
        Response.Clear();
        Response.Write(value);
    }
    #endregion 
    #region tính lại tiền by idchitietdangkykham
    private void nvk_TinhLaiTienBy_idctdkk()
    {
        try
        {
            string idctdkk = Request.QueryString["idctdkk"];
            string nvk_iddkk = DataAcess.Connect.GetTable("select iddangkykham from chitietdangkykham where idchitietdangkykham ='" + idctdkk + "'").Rows[0][0].ToString();
            bool kt = StaticData.TinhLaiTien_ByIdDangKyKham(nvk_iddkk);
        }
        catch (Exception)
        {

        }
        Response.Clear(); Response.Write("");
    }
    #endregion

    #region thông tin sinh hiệu
    //Luu
    private void nvk_LuuThongTinSinhHieu()
    {
        try
        {
            DataProcess process = nvk_sinhhieu();
            if (process.getData("idsinhhieu") != null && process.getData("idsinhhieu") != "" && process.getData("idsinhhieu") != "0")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idsinhhieu"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idsinhhieu"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
        //Response.StatusCode = 500;
    }
    //Load nội dung đo
    private void nvk_LoadNoiDungDoSinhHieu()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();//"Information SINH HIỆU Từ Ajax ! ĐANG CẬP NHẬT !";
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        string idsinhHieu = Request.QueryString["idsinhHieu"];
        if (idsinhHieu == null || idsinhHieu.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        string sqlDosinhHieu = @"select ngayDo103=convert(varchar(10),ngaydo,103),* from sinhhieu where idsinhhieu='" + idsinhHieu + "'";
        DataTable dtDoSinhHieu = DataAcess.Connect.GetTable(sqlDosinhHieu);
        html.Append(LoadNoiDungDoSinhHieu(dtDoSinhHieu));
        Response.Clear();
        Response.Write(html);
    }
    //Load danh sách
    private void nvk_LoadDanhSachSinhHieu()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();//"Information SINH HIỆU Từ Ajax ! ĐANG CẬP NHẬT !";
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        if (idbenhnhan == null || idbenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        string sqlDSsinhHieu = @"select STT=row_number() over (order by T.idsinhhieu),T.*
                               from sinhhieu T where  idchitietdangkykham='" + idchitiedangkykham + "'";
        DataTable dtDSSinhHieu = DataAcess.Connect.GetTable(sqlDSsinhHieu);
        html.Append(LoadDanhSachSinhHieu(dtDSSinhHieu));
        Response.Clear();
        Response.Write(html);
    }
    //Load tổng thể
    private void nvk_LoadThongTinSinhHieu()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();//"Information SINH HIỆU Từ Ajax ! ĐANG CẬP NHẬT !";
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        if (idbenhnhan == null || idbenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        html.Append(@"<fieldset><legend>Danh sách sinh hiệu</legend>
        <div class='div-Out' id='divDSSinhHieu' style='height:auto;width:96%'>");
        //Load table Danh Sách Sinh Hiệu
        #region Load table Danh Sách Sinh Hiệu
        string sqlDSsinhHieu = @"select STT=row_number() over (order by T.idsinhhieu),T.*
                               from sinhhieu T where  idchitietdangkykham='" + idchitiedangkykham + "'";
        DataTable dtDSSinhHieu = DataAcess.Connect.GetTable(sqlDSsinhHieu);
        html.Append(LoadDanhSachSinhHieu(dtDSSinhHieu));
        #endregion
        html.Append(@"</div>
        </fieldset>
        <fieldset><legend>Đo sinh hiệu</legend>
        <div class='div-Out' id='divDoSinhHieu' style='height:auto;width:96%'>");
        //Load table Đo Sinh Hiệu
        #region Load table Đo Sinh Hiệu
        html.Append(LoadNoiDungDoSinhHieu(null));
        #endregion
        html.Append(@"</div>
        </fieldset>
        <span id='spDangLuuSH'></span><br/>
        <div style='text-align:center;height:auto;width:96%'>
            <input id='btnLuuSinhHieu' type='button' value='Lưu' style='width:90px' onclick='btnLuuSH_click()'/>
            <input id='btnMoiSinhHieu' type='button' value='Mới' style='width:90px'  onclick='LoadInFoSinhHieu()'/>
        </div>");
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region table benhnhan trả thuốc
    private void nvk_loadTablechitietbenhnhanTraThuoc()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idKbTra = Request.QueryString["idkhambenh"]; string qr_loaiTra = Request.QueryString["loaitra"];
        string sql = @"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc)
                    ,nvk_TT_TH=isnull((SELECT top 1 tt=3 FROM chitietphieuxuatkho WHERE idchitietbenhnhantoathuoc =t.idchitietbenhnhantoathuoc),0)
                    ,T.*
                                ,b.loaithuocid,b.tenloai,a.tenthuoc,k.tenkho
                                ,dt.TenDoiTuong,nvk_IsHaoPhi= isnull(convert(int,ishaophi),0)
,t.soluongke as SoLuongDonVi--case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongke else isnull(SoLuongTheoDonVi,0) end as SoLuongDonVi
,t.soluongTra as TraTheoDonVi--case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongTra else isnull(t.soluongTra,0)*isnull(SoLuong1donvi,0)  end as TraTheoDonVi
,dvt.TenDVT as DonViCoBan--case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then N'' else N'/'+convert(varchar,SoLuong1donvi)+TenDonVi end as DonViCoBan

                               from chitietbenhnhantoathuoc T
                                left join thuoc a on a.idthuoc=t.idthuoc
                            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
                            left join khothuoc k on k.idkho = T.idkho
                            left join thuoc_doituongthuoc dt on dt.DoiTuongThuocID = t.DoiTuongThuocID
                            left join thuoc_donvitinh dvt on dvt.id = a.iddvt
          where T.idkhambenh='" + idKbTra + "'  order by t.idchitietbenhnhantoathuoc asc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        html.Append( "<fieldset><legend>Nội dung BN trả thuốc, VTYT...</legend>");
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>Loại</th>");
        html.Append("<th>Hao phí?</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongke") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongtra") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayuong") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("moilanuong") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
        html.Append("</tr>");
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str_checkHaoPhi = "";
                if (table.Rows[i]["DoiTuongThuocID"].ToString().Equals("3") && table.Rows[i]["nvk_IsHaoPhi"].ToString().Equals("1"))//nvk_IsHaoPhi
                    str_checkHaoPhi = "checked"; 
                string strDisabled = table.Rows[i]["nvk_TT_TH"].ToString().Equals("3") ? "" : "Disabled";// chỉ tình trạng= đã nhận và chưa YC trả mới được sửa
                if (table.Rows[i]["nvk_TT_TH"].ToString().Equals("3"))
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><input id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/>" + table.Rows[i]["tenloai"].ToString() + "</td>");
                    //html.Append("<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "' onblur='TestSo(this,false,false);'/>" + table.Rows[i]["TenDoiTuong"].ToString() + "</td>";
                    html.Append("<td><input mkv='true' id='doituongthuocid' type='checkbox' " + str_checkHaoPhi + "  value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "'/></td>");
                    html.Append("<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idkho"].ToString() + "' onblur='TestSo(this,false,false);'/>" + table.Rows[i]["tenkho"].ToString() + "</td>");
                    html.Append("<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/>" + table.Rows[i]["tenthuoc"].ToString() + "</td>");
                    html.Append(@"<td ><input mkv='true'  disabled='true' style='width:30px;text-align:right' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoLuongDonVi"].ToString() + @"' onblur='TestSo(this,false,false);'/>
<input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value='" + table.Rows[i]["DonViCoBan"].ToString() + @"'/>
                    </td>");
                    html.Append("<td><input mkv='true' style='width:40px;text-align:right' id='soluongtra' type='text' " + strDisabled + "  onfocusout='nvk_CheckValidSLTra(this," + table.Rows[i]["SoLuongDonVi"].ToString() + ")' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TraTheoDonVi"].ToString() + "' onblur='TestSo(this,false,false);ktrasltra(this);'/></td>");
                    html.Append("<td><input mkv='true' style='width:50px' id='ngayuong'  disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "' onblur='TestSo(this,false,false);'/></td>");
                    html.Append("<td><input mkv='true' style='width:50px' id='moilanuong'  disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["moilanuong"].ToString() + "' /></td>");
                    html.Append("<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + @"' />
                    <input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + @"'/>
                    </td>");
                    html.Append("</tr>");
                }
                else
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["tenloai"].ToString() + "</td>");
                    html.Append("<td><input mkv='true' id='doituongthuocid'  disabled='true' type='checkbox' " + str_checkHaoPhi + "  value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "'/></td>");
                    html.Append("<td>" + table.Rows[i]["tenkho"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["tenthuoc"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["SoLuongDonVi"].ToString() + "  " + table.Rows[i]["DonViCoBan"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["TraTheoDonVi"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["ngayuong"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["moilanuong"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["ghichu"].ToString() + "</td>");
                    html.Append("</tr>");
                }
            }
        }
        html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");

        html.Append(@"
        </fieldset>
        <div class='div-Out' style='width: 96%'>
            <div class='div-Left' style='text-transform: uppercase'>
            </div>
            <div class='div-Right' style='width: 80%;'>
                <input id='luuCLS' type='button' value='Lưu trả thuốc' style='width:110px;background-color:Blue;color:White;background-image:none' onclick='SaveTraThuoc_Click(" + idKbTra + @")'/>
            </div>
        </div>");
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region Thông tin Bệnh Nhân trả Thuốc, VTYT....
    private void nvk_LoadInfoAjaxTraThuoc()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        string NgayLoc = Request.QueryString["ngayLoc"];
        if (idbenhnhan == null || idbenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        #region html dịch vụ
        html.Append(@"<div class='in-a'>
        <div id='tableAjax_chitietbenhnhanTraThuoc' class='in-b'></div>");
        //html.Append( tableCLS(null, null, true);
        html.Append( @"</div>
        <div  style='width: 96%;z-index:1000' id='divDsChiDinhCLS'>
        <fieldset><legend>Danh sách chỉ định đã lĩnh</legend>
            <div id='divDsThuocCd'>");
        //Load table Nội dung chỉ định THUỐC
        #region Load table Nội dung chỉ định THUỐC
        string sqlChiDinh = @"
        select * from (
                select distinct idbenhnhan,kb.idchitietdangkykham,kb.idkhambenh,ngaykham,tenbacsi,nvk_idkhoa=kb.idphongkhambenh
	                ,NgayDuTru103=isnull(convert(varchar(10),kb.ngayDuTruThuoc,103),''),khoa= k.tenphongkhambenh
	                ,tinhtrang=3--[dbo].[nvk_TinhTrangYeuCauMotThuoc_idctbntt](idchitietbenhnhantoathuoc)
                --
                from khambenh kb left join bacsi bs on bs.idbacsi=kb.idbacsi
	                 --inner join chitietbenhnhantoathuoc ct on ct.idkhambenh =kb.idkhambenh
	                 inner join phongkhambenh k on k.idphongkhambenh =kb.idphongkhambenh
                where kb.idchitietdangkykham='" + idchitiedangkykham + "' and kb.idbenhnhan='" + idbenhnhan + @"' --and isnull(kb.maphieukham,'') <>'PKXK'
        ) as nvk 
        where tinhtrang in(3,4,5)
        order by ngaykham desc";
        DataTable dtNoiDungChiDinh = DataAcess.Connect.GetTable(sqlChiDinh);
        html.Append( LoadDanhSachChiDinhThuocNoiTru(dtNoiDungChiDinh, true,idkhoa));
        #endregion
        html.Append( @"</div></fieldset></div>
    </div>
");
        #endregion
        Response.Clear();
        Response.Write(html);
    }
    #endregion

    #region thông tin xuất khoa
    private void LoadThongTinAjaxXuatKhoa()
    {
        string html = "";
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string hdtQueRy = Request.QueryString["hdtQueRy"];
        if (idbenhnhan == null || idbenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        #region tham số
        string idLoaiBN = DataAcess.Connect.GetTable("select a=isnull((select loaikhamid  from dangkykham dk inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham where ct.idchitietdangkykham ='"+idchitiedangkykham+"'),0)").Rows[0][0].ToString();
        string idXuatKhoa = ""; string idKhamBenhXuatKhoa = "";

        string HuongDieuTri = "0";
        string textPPDT = "";
        string textLoiDan = "";
        string textDanDotoa = "";
        string dpKhoa = "";
        string dpPhong = "";
        string dpChuyenVien = "";
        string dpChanDoanRaVien = "";
        string dpPhuongPhapDT = "";
        string dpLoiDanTT = "";
        string dpTinhTrangXK = "";
        string dpLyDoXK = "";
        string dpTaiKham = "";
        string sqlTinhTrang = "";
        string chekTaiKham = "checked=checked";
        DataTable dtTinhTrang = null;
        DataTable dtKhoa = null;
        DataTable dtPhong = null;
        #region tham số đã có(nếu có)
        DataTable dtBNXKdone = null;
        string NgayXKDone = DateTime.Now.ToString("dd/MM/yyyy");
        string GioXKDone = DateTime.Now.ToString("HH:mm:ss");
        string NgayTKDone = "";//DateTime.Now.ToString("dd/MM/yyyy");
        string GioTKDone = "08:00";//DateTime.Now.ToString("HH:mm");
        string IdKhoaDone = "0"; string idPhongDone = "0";
        string idBVDone = ""; string MaBVDone = ""; string TenBVDone = "";
        string idChanDoanDone = ""; string MaChanDoanDone = ""; string TenChanDoanDone = "";
        string idBacSiDone = ""; string TenBacSiDone = "";
        //string PPDTdone = ""; string LoiDanDone = "";
        string idTinhTrangDone = ""; string LyDoXKDone = "";
        string isCoDieuDuongCV = ""; string isCoBacSiCV = "";
        #endregion
        #endregion
        #region xét tham số
        #region lời dặn, phương pháp điểu trị
        if (idkhoa.Equals("3"))
        {
            textLoiDan = @"Uống thuốc theo toa.
@Cho trẻ bú sữa mẹ.
@Đưa trẻ đi tiêm ngừa đúng lịch.";
            textPPDT = @"Mổ lấy thai.
@Kháng sinh.";
        }
        else if (idkhoa.Equals("25"))//tán sỏi
        {
            textLoiDan = @"Uống nhiều nước(1,5 đến 2 lít/ngày).
Khi bất thường ĐT 0948719389 (BS Dũng).
Tái khám nhịn ăn chụp KUB-siêu âm bụng TQ.";
        }
        else
            textLoiDan = @"Uống thuốc theo toa.
@Hết thuốc tái khám.";
        #endregion
        #region hướng điều trị
        HuongDieuTri = DataAcess.Connect.GetTable("select hdt=isnull((select top 1 huongdieutri from khambenh where idchitietdangkykham ='" + idchitiedangkykham + "' order by ngaykham desc),0)").Rows[0][0].ToString();
        if (!string.IsNullOrEmpty(hdtQueRy) && !hdtQueRy.Equals("0"))
            HuongDieuTri = hdtQueRy;
        #endregion
        #region display div control
        if (HuongDieuTri.Equals("0")) //không chọn
        {
            dpKhoa = ";display:none";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:none";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:none";
            dpLyDoXK = ";display:none";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
        }
        else if (HuongDieuTri.Equals("1")) //chuyên phòng KTP
        {
            dpKhoa = ";display:block";
            dpPhong = ";display:block";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:none";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:block";
            dpLyDoXK = ";display:block";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
        }
        else if (HuongDieuTri.Equals("3")) //cho về
        {
            dpKhoa = ";display:none";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:none";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:block";
            dpLyDoXK = ";display:block";
            dpTaiKham = ";display:block";
            chekTaiKham = "checked=checked";
        }

        else if (HuongDieuTri.Equals("4")) //Chuyển viện
        {
            dpKhoa = ";display:none";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:block";
            dpChanDoanRaVien = ";display:block";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:block";
            dpLyDoXK = ";display:block";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
        }
        else if (HuongDieuTri.Equals("8"))// Nhập viện( chuyển khoa)
        {
            dpKhoa = ";display:block";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:block";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:block";
            dpLyDoXK = ";display:block";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
        }
        else if (HuongDieuTri.Equals("11")) //Tử vong
        {
            dpKhoa = ";display:none";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:none";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:block";
            dpLyDoXK = ";display:block";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
            sqlTinhTrang = "select * from KB_TinhTrangXuatKhoa where idtinhtrang=5";
        }
        else if (HuongDieuTri.Equals("12")) // Lưu bệnh (cấp cứu)
        {
            dpKhoa = ";display:none";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:none";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:none";
            dpLyDoXK = ";display:none";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
        }
        else if (HuongDieuTri.Equals("13")) // Ngoại trú (cấp cứu)
        {
            dpKhoa = ";display:none";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:none";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:none";
            dpLyDoXK = ";display:none";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
        }
        else if (HuongDieuTri.Equals("14")) //Đang theo dõi (cấp cứu)
        {
            dpKhoa = ";display:none";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:none";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:none";
            dpLyDoXK = ";display:none";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
        }
        else if (HuongDieuTri.Equals("16") || HuongDieuTri.Equals("22"))//Bỏ về 
        {
            dpKhoa = ";display:none";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:none";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:block";
            dpLyDoXK = ";display:block";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
        }
        else if (HuongDieuTri.Equals("17")) //Xuất viện
        {
            dpKhoa = ";display:none";
            dpPhong = ";display:none";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:block";
            dpPhuongPhapDT = ";display:block";
            dpLoiDanTT = ";display:block";
            dpTinhTrangXK = ";display:block";
            dpLyDoXK = ";display:block";
            dpTaiKham = ";display:block";
            chekTaiKham = "checked=checked";
        }
        else if (HuongDieuTri.Equals("18") ) //Tiểu phẫu (cấp cứu)
        {
            dpKhoa = ";display:block";
            dpPhong = ";display:block";
            dpChuyenVien = ";display:none";
            dpChanDoanRaVien = ";display:none";
            dpPhuongPhapDT = ";display:none";
            dpLoiDanTT = ";display:none";
            dpTinhTrangXK = ";display:block";
            dpLyDoXK = ";display:block";
            dpTaiKham = ";display:none";
            chekTaiKham = "";
        }
        #endregion
        #region giá trị các thuộc tính done
        string nvk_layidxuatkhoa = "select idkb=isnull((select top 1 idkhambenh from khambenh where maphieukham=N'PKXK' and idchitietdangkykham ='" + idchitiedangkykham + "' and isnull(IsDaChuyenKhoa,0)=2 and idphongkhambenh='" + idkhoa + "' order by ngaykham desc),0)";
        if(Request.QueryString["SuaXK"] != null) // sửa xuất khoa từ DS bệnh xuất khoa
            nvk_layidxuatkhoa = "select idkb=isnull((select top 1 idkhambenh from khambenh where maphieukham=N'PKXK' and idchitietdangkykham ='" + idchitiedangkykham + "' and idphongkhambenh='" + idkhoa + "' order by ngaykham desc),0)";
        idKhamBenhXuatKhoa = DataAcess.Connect.GetTable(nvk_layidxuatkhoa).Rows[0][0].ToString();// and idphongkhambenh='" + idkhoa + "' // nhập khoa chưa khám vẫn cho xuất khoa->
        // isnull(IsDaChuyenKhoa,0)<>1 là chưa đúng (vì khi đã nhập khoa phẫu thuật IsDaChuyenKhoa vẫn = 0 buk wa đi dkm khoa phau thuat )
        //-> trường hợp cập nhật phiếu khám của khoa khak thì sao ?
        if (idKhamBenhXuatKhoa.Equals("0"))
        {
            #region tạo mới khám bệnh tại khoa để xuất (nếu nhập khoa nhưng chưa có phiếu khám nào  tại khoa)
            #region thông tin Bác sĩ cho xuất khoa
                string sqlBs = @"
                    select bs.* from (
	                    select idbacsi = isnull(
	                    (select top 1 idbacsi from khambenh where idchitietdangkykham ='" + idchitiedangkykham + @"' and isnull(idbacsi,0)>0 order by idkhambenh desc)
	                    ,(select top 1 idbacsiNhap from benhnhannoitru where idchitietdangkykham ='" + idchitiedangkykham + @"' and isnull(idbacsiNhap,0)>0 order by ngayvaovien desc)
	                    )
                    )
                    as abc inner join bacsi bs on bs.idbacsi= abc.idbacsi";
                DataTable dtBS = DataAcess.Connect.GetTable(sqlBs);
                if (dtBS != null && dtBS.Rows.Count > 0)
                {
                    idBacSiDone = dtBS.Rows[0]["idbacsi"].ToString();
                    TenBacSiDone = dtBS.Rows[0]["tenbacsi"].ToString();
                }
            #endregion
            DataTable dt_Ctdkk = DataAcess.Connect.GetTable(@"select iddangkykham
                    ,huongdieutri= isnull((select top 1 huongdieutri from khambenh where idchitietdangkykham ='" + idchitiedangkykham + "' and idkhoa ='" + idkhoa + @"' order by ngaykham desc),8)
                     from chitietdangkykham ct where idchitietdangkykham ='" + idchitiedangkykham + @"'");
            idKhamBenhXuatKhoa = nvk_addNewKhamBenhByKhoa_Hdt(idbenhnhan, dt_Ctdkk.Rows[0]["iddangkykham"].ToString(), idchitiedangkykham, idkhoa, dt_Ctdkk.Rows[0]["huongdieutri"].ToString(), idkhoa, idBacSiDone);
            #endregion
            //Response.Clear();
            //Response.Write("Bệnh nhân chưa khám bệnh tại khoa !");
            //return;
        }
        else
        {
            #region Bác sĩ đã cho xuất khoa
            string sqlBs = @"
                    select bs.* from khambenh kb inner join bacsi bs on bs.idbacsi= kb.idbacsi where kb.idkhambenh ='"+idKhamBenhXuatKhoa+"'";
            DataTable dtBS = DataAcess.Connect.GetTable(sqlBs);
            if (dtBS != null && dtBS.Rows.Count > 0)
            {
                idBacSiDone = dtBS.Rows[0]["idbacsi"].ToString();
                TenBacSiDone = dtBS.Rows[0]["tenbacsi"].ToString();
            }
            #endregion
        }
        string sqlBNXK = "select * from benhnhanxuatkhoa where idkhoaxuat='" + idkhoa + "' and idkhambenhXK='" + idKhamBenhXuatKhoa + "'";
        DataTable dtIsDaxuat = DataAcess.Connect.GetTable(sqlBNXK);
        if (dtIsDaxuat.Rows.Count > 0)
        {
            sqlBNXK = @"select xk.IdXuatKhoa,xk.IdKhamBenhXK,xk.IdKhoaChuyenDen,xk.IdPhongChuyenDen,xk.IdBVChuyenDen,bv.mabenhvien,bv.tenbenhvien
                        ,cd.idicd,cd.MaICD,MoTa=isnull(xk.MoTaCD_edit,cd.MoTa)
                        ,xk.PhuongPhapDT,xk.LoiDanXuatKhoa,xk.idtinhTrang,xk.LyDoXuatKhoa
                        ,DanDoToa=isnull((select dando from khambenh where idkhambenh = xk.idkhambenhxk),'')
                        ,isCoDieuDuongCV=convert(int,isnull(isCoDieuDuongCV,0)),isCoBacSiCV=convert(int,isnull(isCoBacSiCV,0))
                        ,ngayXK= convert(varchar(10),xk.NgayXuatKhoa,103)
                        ,gioXK= convert(varchar(8),xk.NgayXuatKhoa,108)
                        ,ngayTK= isnull( (select convert(varchar(10),NgayHenTaiKham,103) from nvk_hentaikham where idKhamBenhHenTK='" + idKhamBenhXuatKhoa + @"'),'')
                        ,gioTK=  isnull( (select convert(varchar(5),NgayHenTaiKham,108) from nvk_hentaikham where idKhamBenhHenTK='"+idKhamBenhXuatKhoa+@"'),'08:00')
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
                IdKhoaDone = dtBNXKdone.Rows[0]["IdKhoaChuyenDen"].ToString(); idPhongDone = dtBNXKdone.Rows[0]["IdPhongChuyenDen"].ToString();
                idBVDone = dtBNXKdone.Rows[0]["IdBVChuyenDen"].ToString(); MaBVDone = dtBNXKdone.Rows[0]["mabenhvien"].ToString(); TenBVDone = dtBNXKdone.Rows[0]["tenbenhvien"].ToString();
                idChanDoanDone = dtBNXKdone.Rows[0]["idicd"].ToString(); MaChanDoanDone = dtBNXKdone.Rows[0]["MaICD"].ToString(); TenChanDoanDone = dtBNXKdone.Rows[0]["MoTa"].ToString();
                textPPDT = dtBNXKdone.Rows[0]["PhuongPhapDT"].ToString(); textLoiDan = dtBNXKdone.Rows[0]["LoiDanXuatKhoa"].ToString(); textDanDotoa = dtBNXKdone.Rows[0]["DanDoToa"].ToString();
                idTinhTrangDone = dtBNXKdone.Rows[0]["idtinhTrang"].ToString(); LyDoXKDone = dtBNXKdone.Rows[0]["LyDoXuatKhoa"].ToString();
                isCoDieuDuongCV = dtBNXKdone.Rows[0]["isCoDieuDuongCV"].ToString(); isCoBacSiCV = dtBNXKdone.Rows[0]["isCoBacSiCV"].ToString();
            }
        }
        else
        {
            #region nvk bác sĩ chỉ định
            if (idBacSiDone.Equals(""))
            {
                //string nvk_idkhoachinh = Request.QueryString["nvk_idkhoachinh"];
                string bs_sql = @"select * from (select top 1 bs.idbacsi,tenbacsi
                        from khambenh kb inner join bacsi bs on bs.idbacsi = kb.idbacsi
                        where idchitietdangkykham = '" + idchitiedangkykham + "' and kb.idphongkhambenh='" + idkhoa + @"'
                        order by idkhambenh desc ) abc
union all
select * from (select top 1 bs.idbacsi,tenbacsi--,nvk_idicd=cd.idicd,nvk_MoTaICD=cdn.MoTaChanDoan_NK,nvk_MaICD=cd.maicd
                        from benhnhannoitru nt inner join bacsi bs on bs.idbacsi =nt.idbacsiNhap
                        where idchitietdangkykham = '" + idchitiedangkykham + "' and nt.IdKhoaNoiTru='" + idkhoa + @"'
                        order by nt.idnoitru desc ) abc";
                DataTable bs_table = DataAcess.Connect.GetTable(bs_sql);
                if (bs_table.Rows.Count > 0)
                {
                    idBacSiDone = bs_table.Rows[0]["idbacsi"].ToString(); TenBacSiDone = bs_table.Rows[0]["tenbacsi"].ToString();
                }
            }
            #endregion
            #region Chẩn đoán xác định
            string Cd_sql = @"select * from (select top 1 nvk_idicd=cd.idicd,nvk_MoTaICD=kb.MoTaCD_edit,nvk_MaICD=cd.maicd
                        from khambenh kb inner join chandoanicd cd on cd.idicd= kb.ketluan
                        where idchitietdangkykham = '" + idchitiedangkykham + "' and kb.idphongkhambenh='" + idkhoa + @"'
                        order by idkhambenh desc ) abc
union all
select * from (select top 1 nvk_idicd=cd.idicd,nvk_MoTaICD=cdn.MoTaChanDoan_NK,nvk_MaICD=cd.maicd
                        from benhnhannoitru nt inner join nvk_chanDoanNhapKhoa cdn on cdn.idnoitru= nt.idnoitru
	                        inner join chandoanicd cd on cd.idicd= cdn.idicd
                        where idchitietdangkykham = '" + idchitiedangkykham + "' and nt.IdKhoaNoiTru='" + idkhoa + @"'
                        order by nt.idnoitru desc ) abc";
            DataTable Cd_table = DataAcess.Connect.GetTable(Cd_sql);
            if (Cd_table.Rows.Count > 0)
            {
                idChanDoanDone = Cd_table.Rows[0]["nvk_idicd"].ToString(); TenChanDoanDone = Cd_table.Rows[0]["nvk_MoTaICD"].ToString();
                MaChanDoanDone = Cd_table.Rows[0]["nvk_MaICD"].ToString();
            }
            #endregion
        }
        #endregion
        #region  Khoa phòng chuyển đến
        if (HuongDieuTri.Equals("1"))
            dtKhoa = DataAcess.Connect.GetTable("select * FROM phongkhambenh where loaiphong=0 and idphongkhambenh not in(2,3,4) and idphongkhambenh not in(" + idkhoa + ")");
        else if (HuongDieuTri.Equals("8"))
            dtKhoa = DataAcess.Connect.GetTable("select * FROM phongkhambenh where loaiphong=0 and idphongkhambenh <>1 and idphongkhambenh not in(" + idkhoa + ")");
        if (dtKhoa != null)
        {
            string sqlLoaiBNin = "";
            if (idLoaiBN.Equals("1"))
                sqlLoaiBNin = " and p.loaiBN=1";
            else
                sqlLoaiBNin = " and p.loaiBN=0";
            dtPhong = DataAcess.Connect.GetTable("select id,tenphong=maso+'-'+tenphong from kb_phong p left join banggiadichvu bg on bg.idbanggiadichvu=p.dichvukcb where 1=1 " + sqlLoaiBNin + " and  isnull(p.isphongnoitru,0)=0 and bg.idphongkhambenh='" + IdKhoaDone + @"'");
        }
        #endregion
        #region tinhtrang xuất khoa
        if (sqlTinhTrang.Equals(""))
            if (HuongDieuTri.Equals("17"))// xuất viện -> không hiển thị "Không thay đổi" và "Nặng hơn"
                sqlTinhTrang = "select * from KB_TinhTrangXuatKhoa where idtinhtrang not in (3,4,5) order by nvk_ttUT";
            else
                sqlTinhTrang = "select * from KB_TinhTrangXuatKhoa where idtinhtrang not in (5) order by nvk_ttUT";
        else
            idTinhTrangDone = "5";
        dtTinhTrang = DataAcess.Connect.GetTable(sqlTinhTrang);
        #endregion
        #endregion
        html += @"<fieldset><legend>Hướng điều trị bệnh nhân</legend        >
        <div class='div-Out' style='height:auto;width:96%'>
        <div id='divHDTri' style='height:auto;width:900px;padding: 5px 5px 5px 5px'>
            <div style='float:left;height:25px'>Hướng điều trị :&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <select id='slHuongDieuTri' style='width:200px' onchange='LoadNoiDungHuongDieuTri(" + idbenhnhan+","+idchitiedangkykham+","+idkhoa+@")'>";
        string sql = @"select HuongDieuTriid,case when huongdieutriid=1 then N'Chuyển phòng KTP'
                            when huongdieutriid=8 then N'Chuyển khoa' else TenHuongDieuTri end as tenhuongdieutri
                        ,para_idTanSoi=isnull((select ParaValue from kb_parameter where paraname = N'nvk_idphongtansoi'),0)
                        ,para_idHoaTri=isnull((select ParaValue from kb_parameter where paraname = N'nvk_idphonghoatri'),0)
                        ,para_idCapCuu=isnull((select ParaValue from kb_parameter where paraname = N'nvk_idkhoacapcuu'),0)
                       from kb_huongdieutri where 1=1";
        if (idkhoa.Equals(StaticData.GetParameter("nvk_idkhoacapcuu")))
            sql += " and huongdieutriid in("+StaticData.GetParaValueDB("HUONGDIEUTRIXUATKHOA_CC")+")";
        else
            sql += " and huongdieutriid in(" + StaticData.GetParaValueDB("HUONGDIEUTRIXUATKHOA") + ")";
        sql += " order by tenhuongdieutri";
        DataTable dtHDT = DataAcess.Connect.GetTable(sql);
        html += "<option value='0' " + (HuongDieuTri == "0" ? "selected = selected" : "") + @">---Chọn hướng điều trị---</option>";
        for (int i = 0; i < dtHDT.Rows.Count; i++)
        {
            html += "<option value='" + dtHDT.Rows[i]["huongdieutriid"] + "'" + (HuongDieuTri == dtHDT.Rows[i]["huongdieutriid"].ToString() ? "selected = selected" : "") + @" >" + dtHDT.Rows[i]["tenhuongdieutri"] + "</option>";
        }
        #region Ngày tái khám
        //if (!idkhoa.Equals(dtHDT.Rows[0]["para_idTanSoi"]) && !idkhoa.Equals(dtHDT.Rows[0]["para_idHoaTri"]))
        //{
        //    dpTaiKham = ";display:none"; chekTaiKham = "";
        //}   
        if (idkhoa.Equals(dtHDT.Rows[0]["para_idCapCuu"]))
        {
            dpTaiKham = ";display:none"; chekTaiKham = "";
            dpChanDoanRaVien = ";display:block";
        }   
        string strTaiKham = @"
        <div id='divHenTaiKham' style='height:auto;float:left;padding:5px 20px 5px 40px" + dpTaiKham + @"'>
            <input type='checkbox' id='cbTaiKham' "+chekTaiKham+@" onclick='nvkEnableNgayTaiKham(this);' /> Tái khám
        </div>
        <div id='divNgayGioTK' style='height:auto;float:left" + dpTaiKham + @"'>
            <input type='text' id='txtNgayTK' style='width: 75px;' value='" + NgayTKDone + @"' onfocus='chuyenphim(this);$(this).datepick();'  onblur='nvk_testDate_this(this);'/>
            <input type='text' id='txtGioTK' style='width: 35px;' value='" + GioTKDone + @"' />
        </div>";
        #endregion
        html += @"</select> </div>
        <div style='float:left;padding:5px 20px 5px 40px'>Ngày :
        </div>
        <div style='float:left;'>
        <input type='text' id='txtNgayXK' style='width: 75px;' value='" + NgayXKDone + @"' onfocus='chuyenphim(this);$(this).datepick();'  onblur='nvk_testDate_this(this);'/>
        <input type='text' id='txtGioXK' style='width: 55px;' value='" + GioXKDone + @"' />
        </div>
        " + strTaiKham + @"
        </div>
        <div style='clear:both'></div>";
        #region chuyển khoa
        html += @"<div id='divChuyenKhoa' style='height:auto;width:1000px" + dpKhoa + @"'>
            <table style='width:100%'>
                <tr>
                    <td style='width:40%'>Chọn khoa : &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <select id='slKhoaChuyenToi' style='width:250px' onchange='LoadNoiDungPhongDen(" + idLoaiBN + ")'>";
        html += "<option value='0' " + (IdKhoaDone == "0" ? "selected = selected" : "") + @">---Chọn Khoa---</option>";
        if (dtKhoa != null && dtKhoa.Rows.Count > 0)
        {
            for (int i = 0; i < dtKhoa.Rows.Count; i++)
            {
                html += "<option value='" + dtKhoa.Rows[i]["idphongkhambenh"] + "'" + (IdKhoaDone == dtKhoa.Rows[i]["idphongkhambenh"].ToString() ? "selected = selected" : "") + @" >" + dtKhoa.Rows[i]["tenphongkhambenh"] + "</option>";
            }
        }
        html += @"</select></td>
                    <td style='width:60%'><span id='spchuyenPhong' style='height:auto" + dpPhong + @"'>Chọn phòng :<select id='slPhongChuyenToi' style='width:300px'>";
        html += "<option value='0' " + (idPhongDone == "0" ? "selected = selected" : "") + @">---Chọn Phòng---</option>";
        if (dtPhong != null && dtPhong.Rows.Count > 0)
        {
            for (int i = 0; i < dtPhong.Rows.Count; i++)
            {
                html += "<option value='" + dtPhong.Rows[i]["id"] + "'" + (idPhongDone == dtPhong.Rows[i]["id"].ToString() ? "selected = selected" : "") + @" >" + dtPhong.Rows[i]["tenphong"] + "</option>";
            }
        }
        html += @"</select></span></td>
                </tr>
            </table>
            </div>";
        #endregion
        #region Chuyển viện
        html += @"<div id='divChuyenVien' style='height:auto;width:1000px" + dpChuyenVien + @"'>
                Chọn bệnh viện : &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<INPUT onfocus='TimBenhVienTheoMa();' style='WIDTH: 70px' id='txtMaBenhVien'  type=text value='" + MaBVDone + @"' /><INPUT onfocus='TimBenhVienTheoTen();' id='txtBenhVien' style='WIDTH: 400px' type=text  value='" + TenBVDone + @"'/>
                 Có điều dưỡng <input type='checkbox' id='cbCoDD' " + (isCoDieuDuongCV.Equals("1") ? "checked" : "") + @" />&nbsp;&nbsp; &nbsp;&nbsp;  Có bác sĩ <input type='checkbox' id='cbCoBS' " + (isCoBacSiCV.Equals("1") ? "checked" : "") + @"/>
                <input runat='server' type='hidden' id='hdIdBenhVien'  value='" + idBVDone + @"' />
            </div>
            <div id='divBacSiRaVien' style='height:auto;width:1000px;" + dpChanDoanRaVien + @"'>                
                <div style='height:auto;float:left;padding:5px 95px 5px 0px'>Bác sĩ :</div>
                <div style='height:auto;padding:5px 0px 5px 0px'>
                    <INPUT onfocus='idbacsisearch(this);' id='mkv_idbacsi' style='WIDTH: 700px' type=text value='" + TenBacSiDone + @"' />
                    <input runat='server' type='hidden' id='idbacsi' value='" + idBacSiDone + @"'/>
                </div>
            </div>
            <div id='divChanDoanRaVien' style='height:auto;width:1000px" + dpChanDoanRaVien + @"'>                
            Chẩn đoán ra viện : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<INPUT onfocus='TimChanDoanTheoMa();' style='WIDTH: 70px' id='txtMaChanDoan'  type=text value='" + MaChanDoanDone + @"' /><INPUT onfocus='TimChanDoanTheoTen();' id='txtChanDoan' style='WIDTH: 630px' type=text value='" + TenChanDoanDone + @"' />
                <input runat='server' type='hidden' id='hdIdChanDoan' value='" + idChanDoanDone + @"'/>
            </div>
            ";
        #endregion
        #region chẩn đoán phối hợp
        string tableCdPh = "";
        DataTable dtCDPH = DataAcess.Connect.GetTable("select ct.*,cd.maicd,mota= isnull(MoTaChanDoan_XK,cd.mota) from nvk_chanDoanXuatKhoa ct inner join chandoanicd cd on cd.idicd=ct.idicd where ct.idxuatkhoa='" + idXuatKhoa + "'");
        tableCdPh = strTableChanDoanPhoiHop_XK(dtCDPH);
        html += "<div id='divChanDoanPhoiHop' style='height:auto;width:1000px;padding: 5px 5px 5px 5px" + dpChanDoanRaVien + @"'>                
            Chẩn đoán kèm theo :
            <input id='btnTHChanDoan' type='button' value='Tổng hợp chẩn đoán' style='width:150px' onclick='btnTHChanDoan_click(" + idbenhnhan + "," + idchitiedangkykham + "," + idkhoa + @")'/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span id='spTableCDPH'>
" + tableCdPh + @"
</span>
            </div>
            ";
        #endregion
        #region toa thuốc xuất viện
        string tableToaThuocXuatVien = "";
        string sqlToaXV = @"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                                ,b.loaithuocid,b.tenloai,a.tenthuoc,k.tenkho
                                ,dt.TenDoiTuong
,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongke else isnull(SoLuongTheoDonVi,0) end as SoLuongDonVi
,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongTra else isnull(t.soluongTra,0)*isnull(SoLuong1donvi,0)  end as TraTheoDonVi
,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then N'' else N'/'+convert(varchar,SoLuong1donvi)+TenDonVi end as DonViCoBan

                               from chitietbenhnhantoathuoc T
                                left join thuoc a on a.idthuoc=t.idthuoc
                            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
                            left join khothuoc k on k.idkho = T.idkho
                            left join thuoc_doituongthuoc dt on dt.DoiTuongThuocID = t.DoiTuongThuocID
          where T.idkhambenh='" + idKhamBenhXuatKhoa + "'";
        string strTieuDeToa = "";
        if (HuongDieuTri.Equals("17")) //Xuất Viện
        {
            //DataTable dtToaXuatVien = DataAcess.Connect.GetTable(sqlToaXV);
            //tableToaThuocXuatVien = loadTableToaThuocXuatVien(dtToaXuatVien);
            tableToaThuocXuatVien = loadTableToaThuocXuatVien_2709(idKhamBenhXuatKhoa, idLoaiBN);
            strTieuDeToa = "Toa thuốc ra viện :";
        }
        html += "<div id='divToaThuocRaVien' style='height:auto;width:100%" + dpChanDoanRaVien + @"'>                
            "+strTieuDeToa+" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + tableToaThuocXuatVien + @"
            </div>
            ";
        #endregion
        #region bỏ về no use
        #endregion
        #region Phương pháp điều trị
        html += @"<div id='divPPDT' style='height:auto;width:1000px;vertical-align: top;" + dpPhuongPhapDT + @"'>Phương pháp điều trị :&nbsp;&nbsp;<textarea id='txtPPDT' tyle='text' style='width:700px;height:30px' >" + textPPDT + "</textarea></div>";
        #endregion
        #region Lời dặn của thầy thuốc:
        html += @"<div id='divLDToa' style='height:auto;width:1000px;vertical-align: top;" + dpLoiDanTT + @"'>Lời dặn toa thuốc :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<textarea id='txtLDToa' tyle='text' style='width:700px;height:30px'  >" + textDanDotoa + "</textarea></div>";
        html += @"<div id='divLDTT' style='height:auto;width:1000px;vertical-align: top;" + dpLoiDanTT + @"'>Lời dặn xuất khoa :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<textarea id='txtLDTT' tyle='text' style='width:700px;height:70px'  >" + textLoiDan + "</textarea></div>";
        #endregion
        #region tình trạng xuất khoa
        html += @"<div id='divTinhTrangXK' style='height:auto;width:1000px" + dpTinhTrangXK + @"'>Tình trạng xuất khoa :&nbsp;&nbsp;<select id='slTinhTrangXK' style='width:700px'>";
        html += "<option value='0' " + (idTinhTrangDone == "0" ? "selected = selected" : "") + @">---Chọn tình trạng---</option>";
        if (dtTinhTrang != null && dtTinhTrang.Rows.Count > 0)
        {
            for (int i = 0; i < dtTinhTrang.Rows.Count; i++)
            {
                html += "<option value='" + dtTinhTrang.Rows[i]["idtinhtrang"] + "'" + (idTinhTrangDone == dtTinhTrang.Rows[i]["idtinhtrang"].ToString() ? "selected = selected" : "") + @" >" + dtTinhTrang.Rows[i]["tentinhtrang"] + "</option>";
            }
        }
        html += @"</select></div>";
        #endregion
        #region lý do xuất khoa
        html += @"<div id='divLyDoXK' style='height:auto;width:1000px;vertical-align: top;" + dpLyDoXK + @"'>Lý do xuất khoa :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<textarea id='txtLyDoXK' tyle='text' style='width:700px;height:30px'>" + LyDoXKDone + @"</textarea></div>";
        #endregion
        string dpInCV = ";display:none"; string dpInRaVien = ";display:none";
        if (HuongDieuTri.Equals("4") && !idXuatKhoa.Equals("") && !idXuatKhoa.Equals("0"))// chuyển viện
            dpInCV = ";display:block";
        if (HuongDieuTri.Equals("17") && !idXuatKhoa.Equals("") && !idXuatKhoa.Equals("0"))// Xuất Viện
            dpInRaVien = ";display:block";
        html += @"</fieldset>";

        #region Thông tin Số vào viện
        string IsNoiTru_vv = ""; string SoVaoVien_vv = "";
        string sql_svv = @"select noiTru=isnull(convert(int,IsNoiTru_Save),-1),SOVAOVIEN from HS_BENHNHANBHDONGTIEN
    where  id= isnull(
    (SELECT top 1 IDBENHBHDONGTIEN FROM CHITIETDANGKYKHAM A
	    LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM WHERE A.IDCHITIETDANGKYKHAM='"+idchitiedangkykham+@"'
    ),0) and isnull(sovaovien,'')<>''";
        DataTable dt_svv = DataAcess.Connect.GetTable(sql_svv);
        if (dt_svv != null && dt_svv.Rows.Count > 0)
        {
            IsNoiTru_vv = dt_svv.Rows[0]["noiTru"].ToString();
            SoVaoVien_vv = dt_svv.Rows[0]["SOVAOVIEN"].ToString();
        }
        html += @"<fieldset><legend>Số vào viện</legend>
        <div class='div-Out' style='height:auto;width:96%'>";
        html += @"      <input type='radio' id='rd_NoiTru' value='' " + (IsNoiTru_vv.Equals("1") ? "checked='true'" : "") + @" name='rdOrder'/>
                        <span style='padding-right: 10px;color:Blue'>Nội Trú</span>  
                        <input type='radio' id='rd_NgoaiTru' value='' " + (IsNoiTru_vv.Equals("0") ? "checked='true'" : "") + @"  name='rdOrder'/>
                        <span style='padding-right: 10px;color:Blue'>Ngoại Trú</span>
            <input id='btnTaoSVV' type='button' value='Tạo Số Vào Viện' style='width:110px" +(!SoVaoVien_vv.Equals("") ? ";display:none":"")+@"' onclick='btnTaoSVV_click(" + idbenhnhan + "," + idchitiedangkykham + "," + idkhoa + @")'/>
                        <span id='sp_KetQuaSoVaoVien' style='padding: 5px 5px 5px 20px;color:Red'>"+SoVaoVien_vv+@"
                        </span>
        </fieldset>";
        #endregion
        string nvk_TenbangKe = "Mẫu 02";
        if (idkhoa.Equals(StaticData.GetParameter("nvk_idkhoacapcuu")) || idkhoa.Equals(StaticData.GetParameter("nvk_idphongtansoi")))
        {
            nvk_TenbangKe = "Bảng kê CP";
        }
        html += @"<div align='center' style='padding: 0px 0px 0px 300px'>
            <span id='spDangLuu' style='float:left'></span><br/>
            <input id='btnLuuHDT' type='button' value='Lưu' style='width:90px; float:left' onclick='btnLuuHDT_click(" + idbenhnhan+","+idchitiedangkykham+","+idkhoa+@")'/>
            <input id='btnTinhTien' type='button' value='Kiểm tra lại' style='width:90px;float:left' onclick='nvk_TinhLaiTienBy_idctdkk(" + idchitiedangkykham + @")'/>
            <input id='btnMau02' type='button' value='" + nvk_TenbangKe + @"' style='width:90px;float:left' onclick='btnMau02_click()'/>
            <input id='btnInToaRaVien' type='button' value='In Toa Ra Viện' style='width:180px;float:left" + dpInRaVien + "' onclick='InToaThuocRaVien(" + idKhamBenhXuatKhoa + "," + idkhoa + @")'/>
            <input id='btnInPhieuCV' type='button' value='In Phiếu Chuyển Viện' style='width:180px;float:left" + dpInCV + "' onclick='InPhieuChuyenVien(" + idchitiedangkykham + "," + idbenhnhan + @","+idkhoa+@")'/>
            <input id='btnInPhieuRV' type='button' value='In Phiếu Ra Viện' style='width:150px;float:left" + dpInRaVien + "' onclick='InPhieuRaVien(" + idKhamBenhXuatKhoa + "," + idkhoa + @")'/>
            <input runat='server' type='hidden' id='hdIdXuatKhoa' value='" + idXuatKhoa + @"'/>
            <input runat='server' type='hidden' id='hdKbXuatKhoa' value='" + idKhamBenhXuatKhoa + @"'/>
            <br/><span id='spSoVaoVien'></span>
        </div>";
        Response.Clear();
        Response.Write(html);
    }
    private void nvk_LoadNoiDungPhongDen()
    {
        string html = "";
        string IdKhoaSelect = Request.QueryString["IdKhoaSelect"];
        string idloaiBN = Request.QueryString["idloaiBN"];
        string idPhongDone = "0";
        string sqlLoaiBNin = "";
        if (idloaiBN.Equals("1"))
            sqlLoaiBNin = " and p.loaiBN=1";
        else
            sqlLoaiBNin = " and p.loaiBN=0";
        string sqlPhong = "select id,tenphong=maso+'-'+tenphong from kb_phong p left join banggiadichvu bg on bg.idbanggiadichvu=p.dichvukcb where 1=1 " + sqlLoaiBNin + " and  isnull(p.isphongnoitru,0)=0 and bg.idphongkhambenh='" + IdKhoaSelect + @"'";
        DataTable dtPhong = DataAcess.Connect.GetTable(sqlPhong);
        html = @"Chọn phòng :<select id='slPhongChuyenToi' style='width:300px'>";
        html += "<option value='0' " + (idPhongDone == "0" ? "selected = selected" : "") + @">---Chọn Phòng---</option>";
        if (dtPhong != null && dtPhong.Rows.Count > 0)
        {
            for (int i = 0; i < dtPhong.Rows.Count; i++)
            {
                html += "<option value='" + dtPhong.Rows[i]["id"] + "'" + (idPhongDone == dtPhong.Rows[i]["id"].ToString() ? "selected = selected" : "") + @" >" + dtPhong.Rows[i]["tenphong"] + "</option>";
            }
        }
        html += @"</select>";
        Response.Clear();
        Response.Write(html);
    }
    #region luu huongdieutri xuất khoa
    private void nvk_LuuHuongDieuTri_XuatKhoa()
    {
        //try
        //{
        string idbenhnhan = Request.QueryString["idbn"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        string idkhoa = Request.QueryString["idKNT"];
        string NgayXuat103 = Request.QueryString["NgayXK"];
        string gioXuat = Request.QueryString["GioXK"];
        string idBacSiXK ="0";
        if (Request.QueryString["idBSXK"] != null && Request.QueryString["idBSXK"].ToString() != "")
            idBacSiXK = Request.QueryString["idBSXK"].ToString();

        DataProcess benhnhanxuatkhoa = nvk_benhnhanxuatkhoa();

        #region Luu hướng diều trị
        string idHuongDT = benhnhanxuatkhoa.getData("IdHuongDieuTri");
        string LoiDanToaThuoc = Request.QueryString["txtLDToa"]; if (string.IsNullOrEmpty(LoiDanToaThuoc)) LoiDanToaThuoc = "";
        string NgayHenTaiKham = "";
        if (Request.QueryString["IsTK"] != null && Request.QueryString["IsTK"].ToString().Equals("1"))
        {
            NgayHenTaiKham = StaticData.CheckDate(Request.QueryString["NtK"].ToString()) + " " + Request.QueryString["GtK"].ToString();
        }
        if (benhnhanxuatkhoa.getData("IdXuatKhoa") != null && !benhnhanxuatkhoa.getData("IdXuatKhoa").Equals("") && !benhnhanxuatkhoa.getData("IdXuatKhoa").Equals("0"))
        {
            #region cập nhật hướng điều trị
            bool ok = benhnhanxuatkhoa.Update();
            if (ok)
            {
                ok = CapNhatKhamBenhXuatKhoa(benhnhanxuatkhoa, NgayXuat103, gioXuat, LoiDanToaThuoc, idBacSiXK, NgayHenTaiKham);
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
                ok = CapNhatKhamBenhXuatKhoa(benhnhanxuatkhoa, NgayXuat103, gioXuat, LoiDanToaThuoc, idBacSiXK, NgayHenTaiKham);
                if (!ok)
                {
                    benhnhanxuatkhoa.Delete();
                    Response.Clear(); Response.Write("");
                    return;
                }
            }
            #endregion
        }
        #region Lưu tái khám (nếu có)
        if (Request.QueryString["IsTK"] != null && Request.QueryString["IsTK"].ToString().Equals("1"))
        {
            #region tham số
            string sqlHen = @"select idHenTaiKham= isnull((select top 1 idHenTaiKham from nvk_hentaikham where idKhamBenhHenTK='" + benhnhanxuatkhoa.getData("IdKhamBenhXK") + @"'),0)
                            ,IsDaTaiKham= isnull((select top 1 convert(int,IsDaTaiKham) from nvk_hentaikham where idKhamBenhHenTK='" + benhnhanxuatkhoa.getData("IdKhamBenhXK") + "'),0)";
            DataTable dtHen = DataAcess.Connect.GetTable(sqlHen);
            string idHenTaiKham = dtHen.Rows[0]["idHenTaiKham"].ToString();
            string NgayTaoPhieuHen = Request.QueryString["NgayXK"];
            if (string.IsNullOrEmpty(NgayTaoPhieuHen))
                NgayTaoPhieuHen = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            else
            {
                NgayTaoPhieuHen = StaticData.CheckDate(NgayTaoPhieuHen) + " " + Request.QueryString["GioXK"];
            }
            string IsDaTaiKham = dtHen.Rows[0]["IsDaTaiKham"].ToString();
            string GhiChuTaiKham = "Xuất khoa hẹn tái khám";
            string idKhamBenhHenTK = benhnhanxuatkhoa.getData("IdKhamBenhXK");
            #endregion
            bool ktLuuTK = nvk_LuuHenTaiKham(idHenTaiKham, NgayTaoPhieuHen, NgayHenTaiKham, idkhoa, idkhoa, idchitiedangkykham, idbenhnhan
                            , IsDaTaiKham, GhiChuTaiKham, idKhamBenhHenTK);
        }
        else
        {
            #region xóa phiếu hẹn 
            string sqlXoaHen ="delete from nvk_hentaikham where  idKhamBenhHenTK='"+benhnhanxuatkhoa.getData("IdKhamBenhXK")+"'";
            bool ktXos= DataAcess.Connect.ExecSQL(sqlXoaHen);
            #endregion
        }
        #endregion

        string isNgoaiTru_In = "";
        if (idHuongDT.Equals("12"))// lưu bệnh
            isNgoaiTru_In = ",isngoaitru=0";
        if (idHuongDT.Equals("3") || idHuongDT.Equals("4") || idHuongDT.Equals("8") || idHuongDT.Equals("11") || idHuongDT.Equals("16") || idHuongDT.Equals("17") || idHuongDT.Equals("22"))
        {
            string sql = "update benhnhannoitru set IsDaNhap=0" + isNgoaiTru_In + " where idkhoanoitru='" + idkhoa + "' and idchitietdangkykham='" + idchitiedangkykham + "'";
            bool ktIsDaNhap = DataAcess.Connect.ExecSQL(sql);
            if (!ktIsDaNhap)
            {
                benhnhanxuatkhoa.Delete();
                Response.Clear(); Response.Write("");
                return;
            }
            else
            {
                ktIsDaNhap = insertDichVuChuyenVien(idbenhnhan, idHuongDT, benhnhanxuatkhoa);
                if (ktIsDaNhap)
                {
                    #region  Update Khámbệnh 13/09
                    if (benhnhanxuatkhoa.getData("IdKhamBenhXK") != null && idHuongDT.Equals("8")) //chuyển nhập sang khoa khác thì mới cần update IsDaChuyenKhoa=0 (tránh tạo nhiều PKXK ko đúng)
                    {
                        string sqlUpDateKhamBenh = "UPDATE KHAMBENH SET IsDaChuyenKhoa=0 WHERE IDKHAMBENH='" + benhnhanxuatkhoa.getData("IdKhamBenhXK") + "'";
                        bool OK_UpdateKhamBenh = DataAcess.Connect.ExecSQL(sqlUpDateKhamBenh);
                    }
                    #endregion
                    #region thông tin số vào viện
                    string rValue = benhnhanxuatkhoa.getData("IdXuatKhoa") +"@@";
                    DataTable dtSvv = DataAcess.Connect.GetTable("select SOVAOVIEN=isnull(DBO.zHS_GetSoVaoVien(" + idchitiedangkykham + @"),0)");
                    rValue += "Số vào viện: <span style='color:Red;font-weight:bold'>"+dtSvv.Rows[0][0]+"</span>";
                    #endregion
                    Response.Clear(); Response.Write(rValue);
                    return;
                }
            }

        }
        else
        {
            #region không phải xuất khoa
            string sql = "update benhnhannoitru set IsDaNhap=1" + isNgoaiTru_In + " where idkhoanoitru='" + idkhoa + "' and idchitietdangkykham='" + idchitiedangkykham + "'";
            bool ktIsDaNhap = DataAcess.Connect.ExecSQL(sql);
            if (ktIsDaNhap)
            {

                #region thông tin số vào viện
                string rValue = benhnhanxuatkhoa.getData("IdXuatKhoa") + "@@";
                DataTable dtSvv = DataAcess.Connect.GetTable("select SOVAOVIEN=isnull(DBO.zHS_GetSoVaoVien(" + idchitiedangkykham + @"),0)");
                rValue += "Số vào viện: <span style='color:Red;font-weight:bold'>" + dtSvv.Rows[0][0] + "</span>";
                #endregion
                Response.Clear(); Response.Write(rValue);
                return;
            }
            #endregion
        }

        #endregion
        //}
        //catch
        //{
        //}
        //Response.StatusCode = 500;
        Response.Clear(); Response.Write("");
        return;
    }
    private bool nvk_LuuHenTaiKham(string idHenTaiKham, string NgayTaoPhieuHen
                    , string NgayHenTaiKham
                    , string IdKhoaTaoPhieuHen
                    , string IdKhoaSeTaiKham
                    , string idchitietdangkykham
                    , string idbenhnhan
                    , string IsDaTaiKham
                    , string GhiChuTaiKham
                    , string idKhamBenhHenTK)
    {
        string sqlTK = "";
        if (idHenTaiKham != null && !idHenTaiKham.Equals("") && !idHenTaiKham.Equals("0"))
        {
            sqlTK = @"update NVK_HenTaiKham set 
                NgayTaoPhieuHen ='" + NgayTaoPhieuHen + @"'
                    ,NgayHenTaiKham ='" + NgayHenTaiKham + @"'
                    ,IdKhoaTaoPhieuHen ='" + IdKhoaTaoPhieuHen + @"'
                    ,IdKhoaSeTaiKham ='" + IdKhoaSeTaiKham + @"'
                    ,idchitietdangkykham ='" + idchitietdangkykham + @"'
                    ,idbenhnhan ='" + idbenhnhan + @"'
                    ,IsDaTaiKham ='" + IsDaTaiKham + @"'
                    ,GhiChuTaiKham ='" + GhiChuTaiKham + @"'
                    ,idKhamBenhHenTK ='" + idKhamBenhHenTK + @"'
            where idHenTaiKham=" + idHenTaiKham + "";
        }
        else
        {
            sqlTK = @"insert into NVK_HenTaiKham (
                    NgayTaoPhieuHen
                    ,NgayHenTaiKham
                    ,IdKhoaTaoPhieuHen
                    ,IdKhoaSeTaiKham
                    ,idchitietdangkykham
                    ,idbenhnhan
                    ,IsDaTaiKham
                    ,GhiChuTaiKham
                    ,idKhamBenhHenTK
                    )
                    values (
                    '" + NgayTaoPhieuHen + @"'
                    ,'" + NgayHenTaiKham + @"'
                    ,'" + IdKhoaTaoPhieuHen + @"'
                    ,'" + IdKhoaSeTaiKham + @"'
                    ,'" + idchitietdangkykham + @"'
                    ,'" + idbenhnhan + @"'
                    ,'" + IsDaTaiKham + @"'
                    ,N'" + GhiChuTaiKham + @"'
                    ,'" + idKhamBenhHenTK + @"'
                    )";
        }
        bool kt = DataAcess.Connect.ExecSQL(sqlTK);
        return kt;
    }
    private bool CapNhatKhamBenhXuatKhoa(DataProcess bnxk, string Ngayxuat103, string GioXuat, string LoiDanTT, string idbacsi, string NgayHenTaiKham)
    {
        bool OK = false;
        string NgayHenTaiKham_in = "";
        if (!string.IsNullOrEmpty(NgayHenTaiKham))
            NgayHenTaiKham_in = ",ngayhentaikham='"+NgayHenTaiKham+"' ";
        string idDichvu = DataAcess.Connect.GetTable("select dv=isnull((select DichVuKCB from kb_phong where id='" + bnxk.getData("IdPhongChuyenDen") + "'),0)").Rows[0][0].ToString();
        string sqlUdKhamBenh = @"
                update khambenh set  idbacsi='"+idbacsi+"',huongdieutri='" + bnxk.getData("IdHuongDieuTri") + "',phongkhamchuyenden='" + bnxk.getData("IdKhoaChuyenDen") + @"'
                ,idPhongChuyenDen='" + bnxk.getData("IdPhongChuyenDen") + "',idDVPhongChuyenDen='" + idDichvu + @"'
                ,ghichuhuongdieutri='" + bnxk.getData("IdBVChuyenDen") + @"',ngaykham='" + StaticData.CheckDate(Ngayxuat103) + " " + GioXuat + @"'
                ,dando= N'" + LoiDanTT + "',KETLUAN='" + bnxk.getData("ChanDoanXuatKhoa") + "',MoTaCD_edit=N'" + bnxk.getData("MoTaCD_edit") + @"'
                "+NgayHenTaiKham_in+@"
                where idkhambenh='" + bnxk.getData("IdKhamBenhXK") + @"'
                ";
        OK = DataAcess.Connect.ExecSQL(sqlUdKhamBenh);
        return OK;
    }
    private bool insertDichVuChuyenVien(string idbenhnhanXK, string idHuongDT, DataProcess bnxk)
    {
        bool kt = true;
        if (idHuongDT.Equals("4")) //chuyển viện
        {
            string NgayKham = DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("yyyy/MM/dd HH:mm");
            DataTable dtbv = DataAcess.Connect.GetTable("select * from benhvien where idbenhvien='" + bnxk.getData("IdBVChuyenDen") + "'");
            if (dtbv.Rows.Count > 0)
            {
                string idbanggiadichvu = dtbv.Rows[0]["idbanggiadichvu"].ToString();
                #region loại dịch vụ
                if (bnxk.getData("isCoBacSiCV").Equals("1") && bnxk.getData("isCoDieuDuongCV").Equals("1"))
                    idbanggiadichvu = dtbv.Rows[0]["idbanggiadichvuDDBS"].ToString();
                else if (bnxk.getData("isCoBacSiCV").Equals("0") && bnxk.getData("isCoDieuDuongCV").Equals("1"))
                    idbanggiadichvu = dtbv.Rows[0]["idbanggiadichvuDD"].ToString();
                #endregion
                if (idbanggiadichvu.Equals("") || idbanggiadichvu.Equals("0"))
                {
                    //StaticData.MsgBox(this, "Chưa xác nhận phí vận chuyển !");
                    return kt;
                }
                string MaPhieuDV = "";
                #region Mã phiếu dịch vụ
                string sql = "select top 1 maphieucls from khambenhcanlamsan where idkhambenh='" + bnxk.getData("IdKhamBenhXK") + "'";
                DataTable dt = DataAcess.Connect.GetTable(sql);
                if (dt == null || dt.Rows.Count == 0)
                    MaPhieuDV = StaticData.NewSoChungTu(NgayKham, idbenhnhanXK, "Phí vận chuyển bệnh nhân", "0");
                else
                    MaPhieuDV = dt.Rows[0][0].ToString();
                #endregion
                string sqlDelDV = @"delete from khambenhcanlamsan where idkhambenh='" + bnxk.getData("IdKhamBenhXK") + @"'and idcanlamsan in(
                                 select idbanggiadichvu from benhvien where idbenhvien='" + bnxk.getData("IdBVChuyenDen") + @"'
                                union select idbanggiadichvuDDBS from benhvien where idbenhvien='" + bnxk.getData("IdBVChuyenDen") + @"'
                                union select idbanggiadichvuDD from benhvien where idbenhvien='" + bnxk.getData("IdBVChuyenDen") + @"'
                                )";
                kt = DataAcess.Connect.ExecSQL(sqlDelDV);
                string sqlVC = @"insert into khambenhcanlamsan (idkhambenh,idcanlamsan,ngaythu,idnguoidung,
                ngaykham,idbenhnhan,maphieuCLS,soluong,GhiChu)
                values(" + bnxk.getData("IdKhamBenhXK") + "," + idbanggiadichvu + ",getdate()," + SysParameter.UserLogin.UserID(this) + @",
                getdate()," + idbenhnhanXK + ",'" + MaPhieuDV + "',1,N'Phí vận chuyển bệnh nhân')";
                kt = DataAcess.Connect.ExecSQL(sqlVC);
            }
        }
        return kt;
    }
    #endregion
    #endregion
    #region table chẩn đoán xuất khoa
    private string strTableChanDoanPhoiHop_XK(DataTable dt)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTableCDPH0\" style='width:300px'>");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaICD") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MoTaICD") + "</th>");
        //html.Append("<th></th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        if (dt != null && dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool boQua = false;
                string idicd_i = dt.Rows[i]["idicd"].ToString();
                for (int j = 0; j < i; j++)
                {
                    if (dt.Rows[j]["idicd"].ToString().Equals(idicd_i))
                    {
                        boQua = true; break;
                    }
                }
                if (!boQua)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + (i + 1) + "</td>");
                    html.Append("<td><a onclick='xoaontableCDPH_XK(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idicd"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1,0)' value='" + dt.Rows[i]["MaICD"] + "' class='down_select' style='width:80px'/></td>");
                    html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0,0)' value='" + dt.Rows[i]["mota"] + "' class='down_select' style='width:320px'/></td>");
                    //html.Append("<td><input id='mkvDown' type='text'  value='' style='width:10px'  onkeydown=\"chuyendongPH(this);\" /></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[i]["idCdXuatKhoa"] + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        html.Append("<tr>");
        html.Append("<td>" + (dt.Rows.Count) + "</td>");
        html.Append("<td><a onclick='xoaontableCDPH_XK(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1,0)' value='' class='down_select' style='width:80px'/></td>");
        html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0,0)' value='' class='down_select' style='width:320px'/></td>");
        //html.Append("<td><input id='mkvDown' type='text'  value='' style='width:10px'  onkeydown=\"chuyendongPH(this);\" /></td>");
        html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
        html.Append("</tr>");


        //html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");
        return html.ToString();
    }
    #endregion
    #region Load thông tin viện phí bệnh nhân
    private void LoadChiTietVienPhiCLS()
    {
        string html = "";
        string idbenhnhanLoad = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idKhamBenhVP = Request.QueryString["idKBVienPhi"];
        string MaPhieuCLS = Request.QueryString["MaPhieuCLS"];
        if (idKhamBenhVP == null || idKhamBenhVP.Equals(""))
        {
            Response.Write("");
            return;
        }
        string sqlCLS = @"select STT=row_number() over (order by T.idkhambenhcanlamsan),T.*
                                ,a.tendichvu,a.idbanggiadichvu
                               from khambenhcanlamsan T
                                left join banggiadichvu a on t.idcanlamsan=a.idbanggiadichvu
                        where T.idkhambenh='" + idKhamBenhVP + "'";
        DataTable dt = DataAcess.Connect.GetTable(sqlCLS);
        if (dt != null)
        {
            #region tiêu đê chi tiết nội dung lần chỉ định cls
            html = @"<fieldset style='border:2px solid Red'><legend style='font-style:normal'>CHI TIẾT DỊCH VỤ PHIẾU : '" + MaPhieuCLS + "'</legend>";//<div class='div-Out' style='height:auto;width:96%'>";
            html += "<table class='jtable' id=\"gridTablecls\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idcanlamsan") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("chietkhau") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>";
            html += "</tr>";
            #endregion
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                #region nội dung chỉ định cls
                int ck = 0;
                int sl = 1;
                try
                {
                    ck = int.Parse(dt.Rows[i]["chietkhau"].ToString());
                    sl = int.Parse(dt.Rows[i]["soluong"].ToString());
                }
                catch { }
                int thanhtien = sl * int.Parse(dt.Rows[i]["dongia"].ToString());
                html += "<tr>";
                html += "<td>" + dt.Rows[i]["stt"] + "</td>";
                html += "<td align='left'>" + dt.Rows[i]["tendichvu"] + "</td>";
                html += "<td>" + sl + "</td>";
                html += "<td>" + dt.Rows[i]["dongia"] + "</td>";
                html += "<td>" + ck + "</td>";
                html += "<td>" + ((thanhtien - (thanhtien * ck) / 100)).ToString() + "</td>";
                html += @"<td>" + dt.Rows[i]["ghichu"] + "</td>";
                html += "</tr>";
                #endregion
            }
            html += "<tr><td></td><td></td></tr>";
            html += "</table>";
            html += "</fieldset>";
        }
        Response.Clear();
        Response.Write(html);
    }
    private void nvk_LoadChiTietVienPhiThuoc()
    {
        string html = "";
        string idbenhnhanLoad = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idKhamBenhVP = Request.QueryString["idKBVienPhi"];
        string LanCDthuoc = Request.QueryString["LanCDthuoc"];
        if (idKhamBenhVP == null || idKhamBenhVP.Equals(""))
        {
            Response.Write("");
            return;
        }
        string sqlThuoc = @"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                                ,b.loaithuocid,b.tenloai,a.tenthuoc,k.tenkho
                                ,dt.TenDoiTuong
,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongke else isnull(SoLuongTheoDonVi,0) end as SoLuongDonVi
,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongTra else isnull(t.soluongTra,0)*isnull(SoLuong1donvi,0)  end as TraTheoDonVi
,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then N'' else N'/'+convert(varchar,SoLuong1donvi)+TenDonVi end as DonViCoBan

                               from chitietbenhnhantoathuoc T
                                left join thuoc a on a.idthuoc=t.idthuoc
                            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
                            left join khothuoc k on k.idkho = T.idkho
                            left join thuoc_doituongthuoc dt on dt.DoiTuongThuocID = t.DoiTuongThuocID
          where T.idkhambenh='" + idKhamBenhVP + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlThuoc);
        #region tiêu đê chi tiết nội dung lần chỉ định
        html = @"<fieldset style='border:2px solid Red'><legend style='font-style:normal'>CHI TIẾT CHỈ ĐỊNH THUỐC LẦN '" + LanCDthuoc + "'</legend>";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>Loại</th>";
        html += "<th>Đối tượng</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongke") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongtra") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayuong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("moilanuong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>";
        html += "</tr>";
        #endregion
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                #region nội dung chỉ định
                html += "<tr>";
                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["tenloai"].ToString() + "</td>";                //
                html += "<td>" + table.Rows[i]["TenDoiTuong"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["tenkho"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["tenthuoc"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["SoLuongDonVi"].ToString() + @"" + table.Rows[i]["DonViCoBan"].ToString() + @"</td>";
                html += "<td>" + table.Rows[i]["TraTheoDonVi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["ngayuong"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["moilanuong"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["ghichu"].ToString() + "</td>";
                html += "</tr>";
                #endregion
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += "</fieldset>";
        Response.Clear();
        Response.Write(html);
    }
    private void LoadThongTinAjaxVienPhi()
    {
        string html = "";
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        if (idbenhnhan == null || idbenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        html += @"<fieldset><legend>Chỉ định dịch vụ</legend>
        <div class='div-Out' style='height:auto;width:96%'>";
        //Load table Nội dung chỉ định CLS
        #region Load table Nội dung chỉ định CLS
        //        string sqlChiDinh = @"select  ROW_NUMBER() OVER (ORDER BY kbcls.idkhambenh) as stt,kbcls.idbenhnhan,kbcls.idkhambenh,tenbenhnhan,bn.DiaChi,mabenhnhan=N'Chỉ định CLS lần'+str(ROW_NUMBER() OVER (ORDER BY kbcls.idkhambenh))
        //                                ,ngaykham=isnull(
        //                            (select top 1 ngaykham from khambenh where idkhambenh=kbcls.idkhambenh order by idkhambenh desc)
        //                            ,
        //                            (select top 1 ngaykham from khambenhcanlamsan where maphieucls= kbcls.maphieucls order by idkhambenhcanlamsan desc)
        //                            )
        //                                                            ,ChiDinh=N'Cận lâm sàn' ,maphieucls 
        //                            ,khoa=isnull((select tenphongkhambenh from khambenh kk left join phongkhambenh pp on kk.idphongkhambenh=pp.idphongkhambenh where kk.idkhambenh=kbcls.idkhambenh ),'')
        //                                from khambenhcanlamsan kbcls left join benhnhan bn on bn.idbenhnhan=kbcls.idbenhnhan where kbcls.idbenhnhan='" + idbenhnhan + @"'";
        //        sqlChiDinh += @" and isnull(kbcls.idkhambenh,0)<> 0 
        //                                group by idkhambenh,tenbenhnhan,DiaChi,maphieucls,kbcls.idbenhnhan
        //order by  kbcls.idkhambenh desc";
        string sqlChiDinh = @"select  ROW_NUMBER() OVER (ORDER BY kbcls.idkhambenh) as stt,kbcls.idbenhnhan,kbcls.idkhambenh,tenbenhnhan,bn.DiaChi
		,mabenhnhan= case when  isnull(
		(select top 1 idcanlamsan from khambenhcanlamsan cls1 inner join banggiadichvu bg1 on bg1.idbanggiadichvu=cls1.idcanlamsan inner join phongkhambenh p1 on p1.idphongkhambenh =bg1.idphongkhambenh
		 where cls1.idkhambenh =kbcls.idkhambenh and p1.maphongkhambenh ='DVKTKHAC'
		),0) >0
		and isnull(
		(select top 1 idcanlamsan from khambenhcanlamsan cls1 inner join banggiadichvu bg1 on bg1.idbanggiadichvu=cls1.idcanlamsan inner join phongkhambenh p1 on p1.idphongkhambenh =bg1.idphongkhambenh
		 where cls1.idkhambenh =kbcls.idkhambenh and p1.maphongkhambenh <>'DVKTKHAC'
		),0) >0
			then 'Chỉ định CLS & DV lần'+str(ROW_NUMBER() OVER (ORDER BY kbcls.idkhambenh))
		when isnull(
		(select top 1 idcanlamsan from khambenhcanlamsan cls1 inner join banggiadichvu bg1 on bg1.idbanggiadichvu=cls1.idcanlamsan inner join phongkhambenh p1 on p1.idphongkhambenh =bg1.idphongkhambenh
		 where cls1.idkhambenh =kbcls.idkhambenh and p1.maphongkhambenh ='DVKTKHAC'
		),0) >0
			then N'Chỉ định DV lần'+str(ROW_NUMBER() OVER (ORDER BY kbcls.idkhambenh))
		when isnull(
		(select top 1 idcanlamsan from khambenhcanlamsan cls1 inner join banggiadichvu bg1 on bg1.idbanggiadichvu=cls1.idcanlamsan inner join phongkhambenh p1 on p1.idphongkhambenh =bg1.idphongkhambenh
		 where cls1.idkhambenh =kbcls.idkhambenh and p1.maphongkhambenh <>'DVKTKHAC'
		),0) >0
			then N'Chỉ định CLS lần'+str(ROW_NUMBER() OVER (ORDER BY kbcls.idkhambenh))
		end

		,ngaykham=kb.ngaykham
        ,ChiDinh=N'Cận lâm sàn' ,maphieucls 
		,khoa=isnull((select tenphongkhambenh from khambenh kk left join phongkhambenh pp on kk.idphongkhambenh=pp.idphongkhambenh where kk.idkhambenh=kbcls.idkhambenh ),'')
from khambenhcanlamsan kbcls inner join khambenh kb on kb.idkhambenh =kbcls.idkhambenh and kb.idchitietdangkykham ='" + idchitiedangkykham + @"'
 inner join benhnhan bn on bn.idbenhnhan=kbcls.idbenhnhan

group by kbcls.idkhambenh,tenbenhnhan,DiaChi,maphieucls,kbcls.idbenhnhan,kb.ngaykham
order by  kbcls.idkhambenh desc";
        DataTable dtNoiDungChiDinh = DataAcess.Connect.GetTable(sqlChiDinh);
        html += TableHtmlDanhSachCDCLS(dtNoiDungChiDinh);
        #endregion
        html += @"</div>
        </fieldset>
        <fieldset><legend>Chỉ định thuốc, VTYT....</legend>
        <div class='div-Out' style='height:auto;width:96%'>";
        //Load table Nội dung chỉ định THUỐC
        #region Load table Nội dung chỉ định THUỐC
        string sqlChiDinhThuoc = @"select  ROW_NUMBER() OVER (ORDER BY kb.idkhambenh) as stt,kb.idbenhnhan,kb.idkhambenh,tenbenhnhan,bn.DiaChi,mabenhnhan=N'Chỉ định thuốc lần'+str(ROW_NUMBER() OVER (ORDER BY kb.idkhambenh)),kb.ngaykham ,
                                ChiDinh=N'Thuốc' ,bs.tenbacsi
            ,khoa=isnull((select tenphongkhambenh from khambenh kk left join phongkhambenh pp on kk.idphongkhambenh=pp.idphongkhambenh where kk.idkhambenh=kb.idkhambenh ),'')
            ,NgayDuTru103=isnull(convert(varchar(10),kb.ngayDuTruThuoc,103),'')
                                from chitietbenhnhantoathuoc ct  inner join khambenh kb on kb.idkhambenh=ct.idkhambenh  and kb.idchitietdangkykham ='" + idchitiedangkykham + @"'
					 inner join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan 
                      left join bacsi bs on bs.idbacsi=kb.idbacsi ";
        sqlChiDinhThuoc += @"  group by kb.idkhambenh,ngaykham,tenbenhnhan,bn.DiaChi,kb.idbenhnhan,tenbacsi,kb.ngayDuTruThuoc
order by  kb.idkhambenh desc";
        DataTable dtNoiDungThuocChiDinh = DataAcess.Connect.GetTable(sqlChiDinhThuoc);
        html += TableHtmlDanhSachCDThuoc(dtNoiDungThuocChiDinh);
        #endregion

        string nvk_TenbangKe = "MẪU 02";
        if (idkhoa.Equals(StaticData.GetParameter("nvk_idkhoacapcuu")) || idkhoa.Equals(StaticData.GetParameter("nvk_idphongtansoi")))
        {
            nvk_TenbangKe = "Bảng kê";
        }
        html += @"</div>
        </fieldset>
        <div style='text-align:center;height:auto;width:96%'>
            <input id='btnMau02' type='button' value='"+nvk_TenbangKe+ @"' style='width:90px' onclick='btnMau02_click()'/>
            <input id='btnHaoPhi' type='button' value='Tổng hợp hao phí' style='width:150px'  onclick='btnMauHaoPhi_click()'/>
            <input id='btnDongChiTra' type='button' value='Bảng kê ĐCT' style='width:150px'  onclick='btnDongChiTra_click()'/>
            
        </div>";
        //<input id='btnXemHSBA' type='button' value='XEM HSBA' style='width:100px'  onclick='btnXemHSBA_click()'/>
        //<input id='btnInHSBA' type='button' value='IN HSBA' style='width:90px'  onclick='btnInHSBA_click()'/>
        //html = ThongTinTienGiuong(idbenhnhan,idchitiedangkykham, idkhoa);
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region Lưu, cập nhật khám bệnh
    private bool nvk_isSaiThongTin(string idchitietdangkykham, string idbenhnhan)
    {
        string sqlCheck = @"select idchitietdangkykham, dk.idbenhnhan from chitietdangkykham ct inner join dangkykham dk on dk.iddangkykham =ct.iddangkykham
                    where ct.idchitietdangkykham ='"+idchitietdangkykham+"' and dk.idbenhnhan ='"+idbenhnhan+"'";
        DataTable dt = DataAcess.Connect.GetTable(sqlCheck);
        if (dt == null || dt.Rows.Count == 0)
            return true;
        else
            return false;
    }
    private void Luukhambenhmoi()
    {
        string IdKhamBenh = Request.QueryString["idkhambenh"].ToString();
        string idctdkkLuu = Request.QueryString["idctdkk"].ToString();
        string IdKhoaKham = Request.QueryString["idkhoa"].ToString();
        string idBenhNhan = Request.QueryString["idbenhnhan"].ToString();
        string IdBacSi = Request.QueryString["idbacsi"].ToString();
        string idicdxacdinh = Request.QueryString["idicdxacdinh"];
        string MoTaCD_edit = Request.QueryString["MoTaCD_edit"];

        #region kiêm tra hợp lệ 1
        if (nvk_isSaiThongTin(idctdkkLuu,idBenhNhan))
        {
            Response.Clear();
            Response.Write("0");
            return;
        }
        #endregion

        string NgayDuTruThuoc = "null";
        if (Request.QueryString["NgayDuTruThuoc"] != null && !Request.QueryString["NgayDuTruThuoc"].ToString().Trim().Equals(""))
            NgayDuTruThuoc = StaticData.CheckDate(Request.QueryString["NgayDuTruThuoc"].ToString()) ;

        string sqlKhamBenh = @"select case when isnull(idkhambenhgoc,0)<>0 then idkhambenhgoc  else idkhambenh end as GociIdkhambenh,kb.*
                     from khambenh kb 
                    where idbenhnhan=" + idBenhNhan + @" and idchitietdangkykham=" + idctdkkLuu + @"
                     order by idkhambenh desc";
        DataTable dtKhamBenhTruoc = DataAcess.Connect.GetTable(sqlKhamBenh);//
        if (dtKhamBenhTruoc != null && dtKhamBenhTruoc.Rows.Count > 0)
        {
            string idchitietdangkykham = dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString();
            string SoVVien = dtKhamBenhTruoc.Rows[0]["sovaovien"].ToString().Trim();
            string InsertKhamBenhMoi = "";
            bool ktketQuaLuu = false;
            // Update Khám bệnh cũ
            #region update khambenh cũ
            if (IdKhamBenh != "" && IdKhamBenh != "0")
            {
                string HuongDieuTri = "12";//dtKhamBenhTruoc.Rows[0]["huongdieutri"].ToString();
                string GhiChuHuongDieuTri = dtKhamBenhTruoc.Rows[0]["ghichuhuongdieutri"].ToString();
                string idDVPhongChuyenDen = dtKhamBenhTruoc.Rows[0]["idDVPhongchuyenden"].ToString();
                string idPhongChuyenDen = "0";//dtKhamBenhTruoc.Rows[0]["idphongchuyenden"].ToString();
                string ketluanin = "";
                if (idicdxacdinh != null && !idicdxacdinh.Equals("") && !idicdxacdinh.Equals("0")) ketluanin = "ketluan='" + idicdxacdinh + "', MoTaCD_edit=N'" + MoTaCD_edit + "',";
                else ketluanin = "ketluan=null, MoTaCD_edit=null,";
                string sqlUpdateKB = @"update khambenh set ngayDuTruThuoc=" + (NgayDuTruThuoc == null || NgayDuTruThuoc == "" || NgayDuTruThuoc.ToLower() == "null" ? "NULL" : "'" + NgayDuTruThuoc + "'") 
                                + ", " + ketluanin + " idbacsi='" + IdBacSi + "',huongdieutri='" + HuongDieuTri + @"'
                                --,ghichuhuongdieutri='" + GhiChuHuongDieuTri + "',idPhongChuyenDen='" + idPhongChuyenDen + "',idDVPhongChuyenDen='" + idDVPhongChuyenDen + @"'
                                ,sovaovien='" + SoVVien + "',idphongkhambenh='" + IdKhoaKham + "' where idkhambenh =" + IdKhamBenh + "";
                ktketQuaLuu = DataAcess.Connect.ExecSQL(sqlUpdateKB);
                if (!ktketQuaLuu)
                {
                    Response.Clear();
                    Response.Write("0"); return;
                }
                Response.Clear();
                Response.Write(IdKhamBenh); return;
            }
            #endregion
            ///////
            #region Thêm Khám bệnh mới
            else
            {
                if (SoVVien.Equals(""))
                {
                    SoVVien = StaticData.NewSoVaoVien(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
                    StaticData.CapNhatSoVaoVien_KhamBenh(idchitietdangkykham, SoVVien);
                }
                //NgayDuTruThuoc = "2012/09/07";
                string nvk_ngayKham = DateTime.Now.ToString("MM/dd/yyyy");
                if (Request.QueryString["ngaykham"] != null && Request.QueryString["ngaykham"].ToString() != "")
                    nvk_ngayKham = StaticData.CheckDate(Request.QueryString["ngaykham"].ToString());
                #region phòng giường bn
                string nvk_idPhongNoiTru = "0";
                string nvk_idGiuongNoiTru = "0";
                string sqlP_G = @"select idPhongNoiTru=isnull((select top 1 idPhongNoiTru from benhnhannoitru where idchitietdangkykham ='" + dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString() + "' and ngayvaovien <='" + nvk_ngayKham + " " + DateTime.Now.ToString("HH:mm:ss") + @"' order by ngayvaovien desc),0)
                                ,idGiuongNoiTru=isnull((select top 1 idGiuong from benhnhannoitru where idchitietdangkykham ='" + dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString() + "'  and ngayvaovien <='" + nvk_ngayKham + " " + DateTime.Now.ToString("HH:mm:ss") + @"' order by ngayvaovien desc),0)";
                DataTable dtP_G = DataAcess.Connect.GetTable(sqlP_G);
                nvk_idPhongNoiTru = dtP_G.Rows[0]["idPhongNoiTru"].ToString();
                nvk_idGiuongNoiTru = dtP_G.Rows[0]["idGiuongNoiTru"].ToString();
                #endregion
                InsertKhamBenhMoi = @"insert into khambenh (maphieukham
                                                            ,ngaykham
                                                            ,idbenhnhan
                                                            ,iddangkykham
                                                            ,idbacsi
                                                            ,huongdieutri
                                                            --,phongkhamchuyenden
                                                            --,ghichuhuongdieutri
                                                            ,idphongkhambenh
                                                            --,idPhongChuyenDen
                                                            --,idDVPhongChuyenDen
                                                            ,IdChiTietDangKyKham
                                                            ,isNoiTru
                                                            --,idkhambenhgoc
                                                            ,sovaovien
                                                            ,ketluan
                                                            ,MoTaCD_edit
                                                            ,ngayDuTruThuoc
                                                            ,IsDaChuyenKhoa
                                                            ,IdPhong
                                                            ,PhongID
                                                            ,giuongid)
                                                values('" + StaticData.CreateIDTheoThuTuTN("PKB", "khambenh", "maphieukham", "idkhambenh", DateTime.Now.ToString("ddMMyyyy")) + "'"
                                                            +",'" + nvk_ngayKham + " " + DateTime.Now.ToString("HH:mm:ss") + "'"
                                                            +",'" + dtKhamBenhTruoc.Rows[0]["idbenhnhan"].ToString() + "'"
                                                            +",'" + dtKhamBenhTruoc.Rows[0]["iddangkykham"].ToString() + "'"
                                                            +"," + IdBacSi 
                                                            +",12"
                                                            //+ ",'" + dtKhamBenhTruoc.Rows[0]["huongdieutri"].ToString() + "'"
                                                            //+",'" + dtKhamBenhTruoc.Rows[0]["phongkhamchuyenden"].ToString() + "'"
                                                            //+",N'" + dtKhamBenhTruoc.Rows[0]["ghichuhuongdieutri"].ToString() + "'"
                                                            +",'" + IdKhoaKham + "'"
                                                            //+",'" + dtKhamBenhTruoc.Rows[0]["idphongchuyenden"].ToString() + "'"
                                                            //+",'" + dtKhamBenhTruoc.Rows[0]["idDVPhongchuyenden"].ToString() + "'"
                                                            +",'" + dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString() + "'"
                                                            +",'1'"
                                                            //+",'" + dtKhamBenhTruoc.Rows[0]["GociIdkhambenh"].ToString() + "'"
                                                            +",'" + SoVVien + "'"
                                                            +",'" + idicdxacdinh + "'"
                                                            +",N'" + MoTaCD_edit + "'"
                                                            +"," + (NgayDuTruThuoc==null || NgayDuTruThuoc==""|| NgayDuTruThuoc.ToLower()=="null" ? "NULL" : "'"+NgayDuTruThuoc+"'") 
                                                            + ",2"
                                                            +"," + nvk_idPhongNoiTru 
                                                            + "," + nvk_idPhongNoiTru 
                                                            + ","+nvk_idGiuongNoiTru
                                                    +")"; 
            }
            #region kiêm tra hợp lệ 2
            if (nvk_isSaiThongTin(dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString(), dtKhamBenhTruoc.Rows[0]["idbenhnhan"].ToString()))
            {
                Response.Clear();
                Response.Write("0"); 
                return;
            }
            #endregion

            ktketQuaLuu = DataAcess.Connect.ExecSQL(InsertKhamBenhMoi);
            #endregion
            ////
            if (ktketQuaLuu)
            {
                #region cập nhật chẩn đoán phiếu khám gốc (nếu chưa có ??)
                if (idicdxacdinh != null && idicdxacdinh != "" && idicdxacdinh != "0")
                {
                    string sqlGoc = "update khambenh set ketluan='" + idicdxacdinh + "',MoTaCD_edit=N'" + MoTaCD_edit + "' where isnull(ketluan,'')='' and idkhambenh=isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=" + idchitietdangkykham + "),0)";
                    bool ktupKBGoc = DataAcess.Connect.ExecSQL(sqlGoc);
                }
                #endregion
                DataTable dtId = DataAcess.Connect.GetTable("select top 1 idkhambenh from khambenh where IdChiTietDangKyKham=" + dtKhamBenhTruoc.Rows[0]["IdChiTietDangKyKham"].ToString() + @" order by idkhambenh desc");
                if (dtId.Rows.Count > 0)
                    IdKhamBenh = dtId.Rows[0][0].ToString();
            }
            else 
            {
                Response.Clear();
                Response.Write("0"); return;
            }
        }
        Response.Clear();
        Response.Write(IdKhamBenh);
    }
    #endregion
    #region LoadDsThuocCd danh sách thuốc đã chỉ định
    private void LoadDsThuocCd()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idbenhnhanLoad = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        string NgayLoc = Request.QueryString["ngayLoc"];
        if (idbenhnhanLoad == null || idbenhnhanLoad.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        //Load table Nội dung chỉ định THUỐC
        #region Load table Nội dung chỉ định THUỐC
        string sqlChiDinh = @"
        select distinct idbenhnhan,kb.idchitietdangkykham,kb.idkhambenh,ngaykham,tenbacsi,nvk_idkhoa=kb.idphongkhambenh
	        ,NgayDuTru103=isnull(convert(varchar(10),kb.ngayDuTruThuoc,103),''),khoa=k.tenphongkhambenh
	        ,tinhtrang=1--[dbo].[nvk_TinhTrangYeuCauMotThuoc_idctbntt](idchitietbenhnhantoathuoc)
        --
        from khambenh kb left join bacsi bs on bs.idbacsi=kb.idbacsi
	         inner join chitietbenhnhantoathuoc ct on ct.idkhambenh =kb.idkhambenh
	         inner join phongkhambenh k on k.idphongkhambenh =kb.idphongkhambenh
        where kb.idchitietdangkykham='" + idchitiedangkykham+"' and kb.idbenhnhan='"+idbenhnhanLoad+@"' and isnull(kb.maphieukham,'') <>'PKXK'
        order by kb.ngaykham desc";
        DataTable dtNoiDungChiDinh = DataAcess.Connect.GetTable(sqlChiDinh);
        html.Append(LoadDanhSachChiDinhThuocNoiTru(dtNoiDungChiDinh, false,idkhoa));
        #endregion
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region LoadDsClsCd danh sách cls
    private void LoadDsClsCd()
    {
        string html = "";
        string idbenhnhanLoad = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        string NgayLoc = Request.QueryString["ngayLoc"];
        if (idbenhnhanLoad == null || idbenhnhanLoad.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        //Load table Nội dung chỉ định CLS
        #region Load table Nội dung chỉ định CLS
        string sqlChiDinh = @"
    select * from (
            select  kbcls.idbenhnhan,idkhambenh,tenbenhnhan,bn.DiaChi,mabenhnhan=N'Chỉ định CLS lần'+str(ROW_NUMBER() OVER (ORDER BY idkhambenh))
                                ,ngaykham=isnull(
                            (select top 1 ngaykham from khambenh where idkhambenh=kbcls.idkhambenh order by idkhambenh desc)
                            ,
                            (select top 1 ngaykham from khambenhcanlamsan where maphieucls= kbcls.maphieucls order by idkhambenhcanlamsan desc)
                            )
                                                            ,ChiDinh=N'Cận lâm sàn' ,maphieucls 
                            ,khoa=isnull((select tenphongkhambenh from khambenh kk left join phongkhambenh pp on kk.idphongkhambenh=pp.idphongkhambenh where kk.idkhambenh=kbcls.idkhambenh ),'')
                                from khambenhcanlamsan kbcls left join benhnhan bn on bn.idbenhnhan=kbcls.idbenhnhan where kbcls.idbenhnhan='" + idbenhnhanLoad + @"'";
        if (NgayLoc != null && !NgayLoc.Equals(""))
            sqlChiDinh += " and isnull((select convert(varchar(10),ngaykham,103) from khambenh where idkhambenh =kbcls.idkhambenh),'')='" + NgayLoc + "'";
        sqlChiDinh += @" and isnull(kbcls.idkhambenh,0)<> 0 
                                group by idkhambenh,tenbenhnhan,DiaChi,maphieucls,kbcls.idbenhnhan 
    ) as nvk
    order by ngaykham desc";
        DataTable dtNoiDungChiDinh = DataAcess.Connect.GetTable(sqlChiDinh);////
        html += LoadDanhSachChiDinhDichVu(dtNoiDungChiDinh);
        #endregion
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region Thông tin chỉ định Thuốc, VTYT....
    private void LoadInfoAjaxCDThuoc()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        string NgayLoc = Request.QueryString["ngayLoc"];
        if (idbenhnhan == null || idbenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        #region html dịch vụ
        html.Append(@"
<div class='in-a'>
        <fieldset><legend>Nội dung thuốc, VTYT...</legend>
        <span style='color:Black;font-weight:bold;font-size:14px;padding-right:10px;' id='spTextNgayKham'>Ngày khám:</span>
        <input mkv='true' id='txtNgayKham' type='text' disabled onblur='nvk_testDate_this(this);' style='width:110px;height: 12px;' />
        <input type='checkbox' id='cbDuTruThuoc' onclick='CheckDuTruThuoc(this,true);' /> Thuốc dự trù
        <span id='spDuTruThuoc'>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span style='' id='spTenNgay'>Dự trù cho ngày :</span>
            <input mkv='true' id='ngayDuTruThuoc' type='text' onfocus='chuyenphim(this);$(this).datepick();'   onblur='nvk_testDate_this(this);' style='width:85px;height: 12px;' />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        <input type='button'  id='btnToaThuocCu' value='Lấy toa thuốc cũ' onclick='TimKiemToaThuocCu(this)' style='width:150px'/>
        <div id='tableAjax_chitietbenhnhantoathuoc' class='in-b'></div>");
        //html += tableCLS(null, null, true);
        html.Append(@"
        </fieldset>
</div>
        <fieldset><legend>Bác sĩ - chẩn đoán</legend>
        <div class='div-Out'>
            <div class='div-Left'>
                Bác sĩ :
            </div>
            <div class='div-Right' id='divBacSi'>
                <input mkv='true' id='idbacsi' type='hidden' />
                <input mkv='true' id='mkv_idbacsi' type='text' onfocus='chuyenphim(this);idbacsisearch(this);'
                    class='down_select_hover' style='width: 90%' />
            </div>
        </div>
        <div style='width: 100%' id='divChanDoan'>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Chẩn đoán :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type='hidden' mkv='true' id='idicdxacdinh' value='0' style='width: 11px' />
            <input id='motaicdxacdinh' class='down_select_hover' type='text' style='width: 435px'");
        html.Append(" onfocus=\"loadicd(this,'mota','xd')\" />");
        html.Append(" <input id='mkv_idicdxacdinh' class='down_select_hover' type='text' style='width: 50px'");
        html.Append(" onfocus=\"loadicd(this,'ma','xd')\" />(theo ICD10)");
        html.Append(@"
        </div>
        <div style='width: 100%' id='div1'>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Chẩn đoán phối hợp :&nbsp;&nbsp;");
        //        html += @" <input type='hidden' mkv='true' id='idicdphoihop' value='0' style='width: 11px' />
        //            <input id='motaicdphoihop' class='down_select_hover' type='text' style='width: 435px'";
        //        html += " onfocus=\"loadicd(this,'mota','ph')\" />";
        //        html += " <input id='maicdphoihop' class='down_select_hover' type='text' style='width: 50px'";
        //        html += " onfocus=\"loadicd(this,'ma','ph')\" />(theo ICD10)";
        html.Append(@"<div style='float: right' id='divChanDoanPhoiHop'>
                <table id='chandoanicd10_1' border='1' style='display: none; width: 530px'>
                    <tr bgcolor='#0066ff' style='font-weight: bolder; color: White'>
                        <td style='width: 40px'>
                        </td>
                        <td style='width: 80px'>
                            Mã ICD
                        </td>
                        <td>
                            Mô tả
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        </fieldset>
        <div class='div-Out' style='width: 96%'>
            <div class='div-Left' style='text-transform: uppercase'>
            </div>
            <div class='div-Right' style='width: 80%;'>
                <input id='luuCDThuoc' type='button' value='Lưu' style='width:70px'  onclick='SaveChiDinhThuoc_Click()'/>
                <input id='incls' type='button' value='In CD thuốc' style='width: 100px' onclick='InChiDinhThuoc_Click()'/>
                <input id='Button2' type='button' value='Mới' style='width:70px'  onclick='LoadInfoChiDinhThuoc()'/>
                <input mkv='true' id='Hidden1' type='hidden' />
                <input mkv='true' id='isNoiTru' value='0' type='hidden' />
                <input mkv='true' id='idKhamBenhMoiLuuDV' value='0' type='hidden' />
            </div>
        </div>
        <div style='width: 96%;z-index:1000' id='divDsChiDinhCLS'>
        <fieldset><legend>Danh sách chỉ định</legend>
            <div id='divDsThuocCd'>");
        //Load table Nội dung chỉ định THUỐC
        #region Load table Nội dung chỉ định THUỐC
        string sqlChiDinh = @"
        select distinct idbenhnhan,kb.idchitietdangkykham,kb.idkhambenh,ngaykham,tenbacsi,nvk_idkhoa=kb.idphongkhambenh
	        ,NgayDuTru103=isnull(convert(varchar(10),kb.ngayDuTruThuoc,103),''),khoa=k.tenphongkhambenh
	        ,tinhtrang=[dbo].[nvk_TinhTrangYeuCauMotThuoc_idctbntt](idchitietbenhnhantoathuoc)
        --
        from khambenh kb left join bacsi bs on bs.idbacsi=kb.idbacsi
	         inner join chitietbenhnhantoathuoc ct on ct.idkhambenh =kb.idkhambenh
	         inner join phongkhambenh k on k.idphongkhambenh =kb.idphongkhambenh
        where kb.idchitietdangkykham='" + idchitiedangkykham + "' and kb.idbenhnhan='" + idbenhnhan + @"' and isnull(kb.maphieukham,'') <>'PKXK'
        order by kb.ngaykham desc";
        //DataTable dtNoiDungChiDinh = DataAcess.Connect.GetTable(sqlChiDinh);
        
        //html.Append(LoadDanhSachChiDinhThuocNoiTru(dtNoiDungChiDinh, false,idkhoa));
        #endregion
        html.Append(@"</div></fieldset></div>
    </div>
");
        #endregion
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region Thông tin chỉ định dịch vụ
    private void LoadThongTinAjaxCDDichVu()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        string NgayLoc = Request.QueryString["ngayLoc"];
        if (idbenhnhan == null || idbenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }

        string sqlChiDinh = @"
                    select ROW_NUMBER() OVER (ORDER BY idkhambenh desc) as stt,*
                        , ngaykham= convert(varchar(10),ngaykham1,103) +' '+ convert(varchar(8),ngaykham1,108)
                    from (
                                select  kbcls.idbenhnhan,kbcls.idkhambenh,tenbenhnhan,bn.DiaChi,LanChiDinh=N'Chỉ định lần'+str(ROW_NUMBER() OVER (ORDER BY kbcls.idkhambenh))
									            ,ngaykham1=kb.ngaykham
                                                ,ChiDinh=N'Cận lâm sàn' 
                                                ,khoa=p.tenphongkhambenh
                                                ,nvk_idkhoa= kb.idphongkhambenh
                                                ,LOAIKHAMID=DKK.LOAIKHAMID
			                    from khambenhcanlamsan kbcls 
                                     inner join benhnhan bn on bn.idbenhnhan=kbcls.idbenhnhan  
						             inner join khambenh kb on kb.idkhambenh =kbcls.idkhambenh  
						             left join phongkhambenh p on p.idphongkhambenh= kb.idphongkhambenh
                                     INNER JOIN DANGKYKHAM DKK ON KB.IDDANGKYKHAM=DKK.IDDANGKYKHAM
                                   WHERE  kbcls.idbenhnhan ='" + idbenhnhan + @"'
                                          AND  kb.idchitietdangkykham='" + idchitiedangkykham + @"'
			                    group by kbcls.idkhambenh,tenbenhnhan,DiaChi,kbcls.idbenhnhan,kb.ngaykham,p.tenphongkhambenh,kb.idphongkhambenh,DKK.LOAIKHAMID

                        ) as nvk";
        DataProcess chidinhPro = new DataProcess("KHAMBENH");
        chidinhPro.Page = Request.QueryString["page"];
        chidinhPro.NumberRow = "5";
        DataTable dtNoiDungChiDinh = chidinhPro.Search(sqlChiDinh);
        string LoaiKhamID = "2";
        if (dtNoiDungChiDinh != null && dtNoiDungChiDinh.Rows.Count > 0)
            LoaiKhamID = dtNoiDungChiDinh.Rows[0]["LoaiKhamID"].ToString();
        #region html dịch vụ
        // them moi de luu moi kham benh
        #region html THÊM MỚI LẦN CHỈ ĐỊNH

        string nvk_idbacsi = "";
        string nvk_Tenbacsi = "";
        string nvk_idicd = "";
        string nvk_MoTaIcd = "";
        string nvk_MaIcd = "";
        #region nvk bác sĩ chỉ định
        //string nvk_idkhoachinh = Request.QueryString["nvk_idkhoachinh"];
        string bs_sql = @"select * from (select top 1 bs.idbacsi,tenbacsi
                        from khambenh kb inner join bacsi bs on bs.idbacsi = kb.idbacsi
                        where idchitietdangkykham = '"+idchitiedangkykham+"' and kb.idphongkhambenh='"+idkhoa+@"'
                        order by idkhambenh desc ) abc
union all
select * from (select top 1 bs.idbacsi,tenbacsi--,nvk_idicd=cd.idicd,nvk_MoTaICD=cdn.MoTaChanDoan_NK,nvk_MaICD=cd.maicd
                        from benhnhannoitru nt inner join bacsi bs on bs.idbacsi =nt.idbacsiNhap
                        where idchitietdangkykham = '"+idchitiedangkykham+"' and nt.IdKhoaNoiTru='"+idkhoa+@"'
                        order by nt.idnoitru desc ) abc";
        DataTable bs_table = DataAcess.Connect.GetTable(bs_sql);
        if (bs_table.Rows.Count > 0)
        {
            nvk_idbacsi = bs_table.Rows[0]["idbacsi"].ToString(); nvk_Tenbacsi = bs_table.Rows[0]["tenbacsi"].ToString();
        }
        #endregion
        #region Chẩn đoán xác định
        string Cd_sql = @"select * from (select top 1 nvk_idicd=cd.idicd,nvk_MoTaICD=kb.MoTaCD_edit,nvk_MaICD=cd.maicd
                        from khambenh kb inner join chandoanicd cd on cd.idicd= kb.ketluan
                        where idchitietdangkykham = '"+idchitiedangkykham+"' --and kb.idphongkhambenh='"+idkhoa+@"'
                        order by idkhambenh desc ) abc
union all
select * from (select top 1 nvk_idicd=cd.idicd,nvk_MoTaICD=cdn.MoTaChanDoan_NK,nvk_MaICD=cd.maicd
                        from benhnhannoitru nt inner join nvk_chanDoanNhapKhoa cdn on cdn.idnoitru= nt.idnoitru
	                        inner join chandoanicd cd on cd.idicd= cdn.idicd
                        where idchitietdangkykham = '"+idchitiedangkykham+"' and nt.IdKhoaNoiTru='"+idkhoa+@"'
                        order by nt.idnoitru desc ) abc";
        DataTable Cd_table = DataAcess.Connect.GetTable(Cd_sql);
        if (Cd_table.Rows.Count > 0)
        {
            nvk_idicd = Cd_table.Rows[0]["nvk_idicd"].ToString(); nvk_MoTaIcd = Cd_table.Rows[0]["nvk_MoTaICD"].ToString();
            nvk_MaIcd = Cd_table.Rows[0]["nvk_MaICD"].ToString();
        }
        #endregion
        html.Append(@"
        <div style='border:1px groove blue;width:100%;margin-top:5px;padding-bottom:5px;float:left' id='thongtindichvu'>
        <p style='font:bold 25px arial;text-align:center;background:green;color:white;'>Chỉ định mới</p>
        <input type='hidden' id='idKhamBenhMoiLuuDV' value=''/>
        <fieldset style='width:97%;float:left;padding:0 10px 0 10px;margin-left:10px'><legend>Bác sĩ - chẩn đoán</legend>
        <div  style='width:100%'>
                Ngày chỉ định :<input type='text' clearVal='false' id='ngaykham' style='width:80px' onfocus='$(this).validDate();$(this).datepick();' value='" + DateTime.Now.ToString("dd/MM/yyyy") + @"'/>
                Bác sĩ :
                <input mkv='true' id='idbacsi' value='" + nvk_idbacsi + @"'  type='hidden' value=''/>
                <input mkv='true' id='mkv_idbacsi'  value='" + nvk_Tenbacsi + @"'  type='text' onfocus='chuyenphim(this);idbacsisearch(this);'
                    class='down_select_hover' style='width: 300px;margin-left:27px' value=''/>
                Chẩn đoán :
                <input type='hidden' mkv='true' id='idicdxacdinh' value='"+nvk_idicd+@"' style='width: 11px' value=''/>
                <input id='motaicdxacdinh' class='down_select_hover' type='text' style='width:300px'");
        //<div style='width:100%'>
        //        Bác sĩ :
        //        <input mkv='true' id='idbacsi' value='" + nvk_idbacsi + @"'  type='hidden' value=''/>
        //        <input mkv='true' id='mkv_idbacsi'  value='" + nvk_Tenbacsi + @"'  type='text' onfocus='chuyenphim(this);idbacsisearch(this);'
        //            class='down_select_hover' style='width: 75%;margin-left:27px' value=''/>
        //</div>
        //<div style='width: 100%' id='divChanDoan'>
        //    Chẩn đoán :
        //    <input type='hidden' mkv='true' id='idicdxacdinh' value='0' style='width: 11px' value=''/>
        //    <input id='motaicdxacdinh' class='down_select_hover' type='text' style='width:60%'");
        html.Append(" onfocus=\"loadicd(this,'mota','xd')\" value='"+nvk_MoTaIcd+"'/>");
        html.Append(" <input id='mkv_idicdxacdinh' class='down_select_hover' type='text' style='width: 55px'");
        html.Append(" onfocus=\"loadicd(this,'ma','xd')\" value='"+nvk_MaIcd+"'/>");
        html.Append(@"
        </div>
        <div style='width: 100%' id='div1'>
           Chẩn đoán phối hợp :
        </div>
        <div style='width: 100%' id='div1'>
           ");
        string cdphSql = @"select id=null,ct.idicd,cd.maicd,mota=isnull(ct.MoTaCD_edit,cd.mota) 
            from chandoanphoihop ct inner join chandoanicd cd on cd.idicd=ct.idicd 
            where ct.idkhambenh in 
            (select top 1 idkhambenh from khambenh kb1 where idchitietdangkykham ='"+idchitiedangkykham+"' and exists(select 1 from chandoanphoihop where idkhambenh =kb1.idkhambenh) order by ngaykham desc)";
        DataTable Dtcdph = DataAcess.Connect.GetTable(cdphSql);
        html.Append(@"<div style='float:left;overflow:auto' id='divChanDoanPhoiHop'>
                " + strTableChanDoanPhoiHop(Dtcdph, 0) + @"
            </div>
        </div>
        </fieldset>
        <fieldset id='fielClSChiDinhMoi' style='width:47%;float:left;padding:0 10px 0 10px;margin-left:10px'><legend>Chỉ định CLS</legend>");
        html.Append("<input type='button' value='Chọn cận lâm sàng' onclick='ChonCLS(this,null,null,\"cls\","+LoaiKhamID+");' style='width: auto' />");
        html.Append("<input type='button' value='Cận lâm sàng thường quy' onclick='ChoncanlamsangThuongquy(this,null,null,\"cls\"," + LoaiKhamID + ");' style='width: auto' />");
        html.Append("<div id='tableAjax_khambenhcanlamsan' class='in-b' style='width:100%;overflow:auto'>");
        html.Append(tableCLS_Mini(null, null, true, "cls", false, LoaiKhamID));
        html.Append(@"
        </div>
        </fieldset>
        <fieldset style='width:47%;float:left;padding:0 10px 0 10px;margin-left:10px'><legend>Dịch vụ chỉ định</legend>");
        html.Append("<input type='button' value='Chọn dịch vụ' onclick='ChonCLS(this,null,null,\"dichvu\","+LoaiKhamID+");' style='width: auto' />");
        html.Append("<div id='tableAjax_khambenhdichvu' class='in-b' style='width:100%;overflow:auto'>");
        html.Append(tableCLS_Mini(null, null, true, "dichvu", false, LoaiKhamID));
        html.Append(@"
        </div>
        </fieldset>
        <div style='width: 100%;text-align:left;float:left;padding-left:200px;padding-top:5px'>
                <input id='luuCLS' type='button' value='Lưu' onclick='SaveChiDinhCls_Click(this,0)'/>
                <input id='incls' type='button' value='In CLS' style='width:70px' onclick='InChiDinhCls_Click(this,1)'/>
                <input id='incls' type='button' value='In DV' style='width:70px' onclick='InChiDinhCls_Click(this,2)'/>
                <input id='incls' type='button' value='In CLS & DV' style='width:90px' onclick='InChiDinhCls_Click(this,3)'/>
                <input id='incls' type='button' value='In Tùy Chọn' style='width:90px' onclick='nvkHienTuyChonIn(this,-1)'/>
                <input id='moi' type='button' value='Phiếu Mới'/>
                <input mkv='true' id='isNoiTru' value='0' type='hidden' />
        </div>
    </div>");
        #endregion

        #region html CÁC LẦN CHỈ ĐINH TRƯỚC (nếu có)
        for (int y = 0; y < dtNoiDungChiDinh.Rows.Count; y++)
        {
            #region kiểm tra khoa 
            bool isKhacKhoa = true;
            string dpLuuChiDinh = "display:none;";
            if (dtNoiDungChiDinh.Rows[y]["nvk_idkhoa"].ToString().Equals(idkhoa))
            {
                isKhacKhoa = false;
                dpLuuChiDinh = "";
            }
            #endregion
            DataTable dtCDPH = DataAcess.Connect.GetTable("select ct.id,ct.idicd,cd.maicd,mota=isnull(ct.MoTaCD_edit,cd.mota) from chandoanphoihop ct inner join chandoanicd cd on cd.idicd=ct.idicd where ct.idkhambenh='" + dtNoiDungChiDinh.Rows[y]["idkhambenh"] + "'");
            string nvk_Cls_1kb = @"select STT=row_number() over (order by T.idkhambenhcanlamsan)
                                ,T.idkhambenhcanlamsan,a.tendichvu,a.idbanggiadichvu,t.soluong,t.ghichu,nvk_isdathu=convert(int,t.dathu)
                                ,nvk_dahuy= case when  T.dahuy=1 then N'Đã hủy' else N'Hủy' end
                                ,nvk_loaibn=isnull(
	                                (select top 1 dk.loaikhamid from dangkykham dk 
											                                inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                                  where ct.idchitietdangkykham ='" + idchitiedangkykham + @"'
	                                )
                                ,0)
                                ,nvk_isBHYT =  convert(int,isnull(T.IsBHYT_Save,0))
                                , isTrongDM= convert(int,isnull(a.IsSuDungChoBH,0))
                               from khambenhcanlamsan T
                                left join banggiadichvu a on t.idcanlamsan=a.idbanggiadichvu
          where isnull(a.isdvkt,0)=0--a.idphongkhambenh not in (select idphongkhambenh from phongkhambenh where maphongkhambenh ='DVKTKHAC')
                and T.idkhambenh='" + dtNoiDungChiDinh.Rows[y]["idkhambenh"] + "'  order by t.idkhambenhcanlamsan asc";
            DataTable cls = DataAcess.Connect.GetTable(nvk_Cls_1kb);
            string nvk_Dv_1kb = @"select STT=row_number() over (order by T.idkhambenhcanlamsan)
                                ,T.idkhambenhcanlamsan,a.tendichvu,a.idbanggiadichvu,t.soluong,t.ghichu,nvk_isdathu=convert(int,t.dathu)
                                ,nvk_dahuy= case when  T.dahuy=1 then N'Đã hủy' else N'Hủy' end
                                ,nvk_loaibn=isnull(
	                                (select top 1 dk.loaikhamid from dangkykham dk 
											                                inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                                  where ct.idchitietdangkykham ='" + idchitiedangkykham + @"'
	                                )
                                ,0)
                                ,nvk_isBHYT = convert( int,isnull(T.IsBHYT_Save,0) )
                                , isTrongDM= convert(int,isnull(a.IsSuDungChoBH,0))
                               from khambenhcanlamsan T
                                left join banggiadichvu a on t.idcanlamsan=a.idbanggiadichvu
          where isnull(a.isdvkt,0)=1--a.idphongkhambenh in (select idphongkhambenh from phongkhambenh where maphongkhambenh ='DVKTKHAC')
                and T.idkhambenh='" + dtNoiDungChiDinh.Rows[y]["idkhambenh"] + "'  order by t.idkhambenhcanlamsan asc";
            DataTable dichvu = DataAcess.Connect.GetTable(nvk_Dv_1kb);
            DataTable bacsychidinh = DataAcess.Connect.GetTable(@"
                         select bs.idbacsi ,tenbacsi,cd.idicd,cd.MaICD,mota=isnull(a.MoTaCD_edit,cd.Mota)
                         from khambenh a left join bacsi bs on bs.idbacsi=a.idbacsi 
                                left join chandoanicd cd on a.ketluan=cd.idicd 
                         where idkhambenh='" + dtNoiDungChiDinh.Rows[y]["idkhambenh"] + "'");
            //DataTable chandoanxd = DataAcess.Connect.GetTable(@"select cd.idicd,cd.MaICD,mota=isnull(a.MoTaCD_edit,cd.Mota) from khambenh a inner join chandoanicd cd on a.ketluan=cd.idicd where idkhambenh='" + dtNoiDungChiDinh.Rows[y]["idkhambenh"] + "'");

            string idICD = "";
            string MaICD = "";
            string MoTaICD = "";
            if (bacsychidinh.Rows.Count > 0)
            {
                idICD = bacsychidinh.Rows[0]["idICD"].ToString(); MaICD = bacsychidinh.Rows[0]["MaICD"].ToString();
                MoTaICD = bacsychidinh.Rows[0]["Mota"].ToString();
            }
            html.Append(@"
        <div style='border:0px groove red;width:100%;margin-top:5px;padding-bottom:5px;float:left;margin:0;padding:0;height:auto' id='thongtindichvu'>
        <input type='hidden' id='idKhamBenhMoiLuuDV' value='" + dtNoiDungChiDinh.Rows[y]["idkhambenh"] + @"'/>
        <fieldset style='width:100%;float:left;border:2px solid Black ;'><legend style='color:Red;font-weight:bold;font-style:normal;'>" + dtNoiDungChiDinh.Rows[y]["LanChiDinh"] + " : "+dtNoiDungChiDinh.Rows[y]["khoa"]+@"</legend>
        <fieldset style='width:97%;float:left;padding:0 10px 0 10px'><legend>Bác sĩ - chẩn đoán</legend>
        <div  style='width:100%'>
                Ngày chỉ định :
                <span style='font-weight:bold;' id='ngaykham' >" + dtNoiDungChiDinh.Rows[y]["ngaykham"] + @"</span>
        
                &nbsp;&nbsp;&nbsp;&nbsp;Bác sĩ :
                <input mkv='true' id='idbacsi' type='hidden' value='" + bacsychidinh.Rows[0]["idbacsi"] + @"'/>
                <input mkv='true' id='mkv_idbacsi' type='text' onfocus='chuyenphim(this);idbacsisearch(this);'
                    class='down_select_hover' style='width: 300px;margin-left:27px' value='" + bacsychidinh.Rows[0]["tenbacsi"] + @"'/>
        
            Chẩn đoán :
            <input type='hidden' mkv='true' id='idicdxacdinh' value='0' style='width: 11px' value='" + idICD + @"'/>
            <input id='motaicdxacdinh' class='down_select_hover' type='text' style='width:300px'");
            html.Append(" onfocus=\"loadicd(this,'mota','xd')\" value='" + MoTaICD + @"'/>");
            html.Append(" <input id='mkv_idicdxacdinh' class='down_select_hover' type='text' style='width: 55px'");
            html.Append(" onfocus=\"loadicd(this,'ma','xd')\" value='" + MaICD + @"'/>");
            html.Append(@"
        </div>
        <div style='width: 100%;text-align:left' id='div1' >
           Chẩn đoán phối hợp :
        </div>
        <div style='width: 100%;text-align:left' id='div1' >
           ");
            html.Append(@"<div style='float:left;overflow:auto' id='divChanDoanPhoiHop'>
                " + strTableChanDoanPhoiHop(dtCDPH, (y + 1)) + @"
            </div>
        </div>
        </fieldset>
        <fieldset style='width:47%;float:left;padding:0 10px 0 10px;margin-left:10px'><legend>Chỉ định CLS</legend>");
            html.Append("<input type='button' value='Chọn cận lâm sàng' onclick='ChonCLS(this,null,null,\"cls\","+LoaiKhamID+");' style='width: auto' />");
            html.Append("<div id='tableAjax_khambenhcanlamsan' class='in-b' style='width:100%;overflow:auto'>");
            html.Append(tableCLS_Mini(cls, null, true, "cls", isKhacKhoa, LoaiKhamID));
            html.Append(@"
        </div>
        </fieldset>
        <fieldset style='width:47%;float:left;padding:0 10px 0 10px;margin-left:10px'><legend>Dịch vụ chỉ định</legend>");
            html.Append("<input type='button' value='Chọn dịch vụ' onclick='ChonCLS(this,null,null,\"dichvu\","+LoaiKhamID+");' style='width: auto' />");
            html.Append("<div id='tableAjax_khambenhdichvu' class='in-b' style='width:100%;overflow:auto'>");
            html.Append(tableCLS_Mini(dichvu, null, true, "dichvu", isKhacKhoa, LoaiKhamID));
            html.Append(@"
        </div>
        </fieldset>
        <div style='width: 100%;text-align:left;float:left;padding-left:200px;padding-top:5px'>
                <input id='luuCLS' type='button' value='Lưu' style='" + dpLuuChiDinh + @"' onclick='SaveChiDinhCls_Click(this," + (y + 1) + @")'/>
                
                <input id='incls' type='button' value='In CLS' style='width:70px' onclick='InChiDinhCls_Click(this,1)'/>
                <input id='incls' type='button' value='In DV' style='width:70px' onclick='InChiDinhCls_Click(this,2)'/>
                <input id='incls' type='button' value='In CLS & DV' style='width:90px' onclick='InChiDinhCls_Click(this,3)'/>
                <input id='incls' type='button' value='In Tùy Chọn' style='width:90px' onclick='nvkHienTuyChonIn(this," + dtNoiDungChiDinh.Rows[y]["idkhambenh"] + @")'/>
                <input mkv='true' id='isNoiTru' value='0' type='hidden' />
        </div>
        </fieldset>
    </div>");
        }
        html.Append(chidinhPro.Pagingfunc("LoadChiDinhDichVu($(this).text());"));
        #endregion


        #endregion
        Response.Clear();
        Response.Write(html);
    }
    private void GetDSCLS()
    {
        try
        {
            string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
            string IdKhambenh = (Request.QueryString["IdKhambenh"] != null ? Request.QueryString["IdKhambenh"].ToString() : "");
            string slvack = Request.QueryString["slvack"];
            string LoaiBN = (Request.QueryString["LoaiBN"] != null ? Request.QueryString["LoaiBN"].ToString() : "");
            string listidcanlamsan = Request.QueryString["listID"];
            listidcanlamsan = listidcanlamsan.TrimEnd(',').Replace("on,", "");
            string[] arridcls = listidcanlamsan.Split(',');
            int length = arridcls.Length;

            string[] arrslvack = slvack.Split('@');

            string html = "";
            if (listidcanlamsan.Trim() == "")
            {
                listidcanlamsan = "''";
            }
            string sqlSelectBangGiaDichVu = @"
                            select STT=row_number() over (order by A.idbanggiadichvu),A.idbanggiadichvu, B.tenphongkhambenh,A.TenNhom,A.tendichvu,A.giadichvu,A.GiaBH,A.PhuThuBH
								,A.idphongkhambenh,nvk_isdathu=0,nvk_dahuy='',ghichu='',dongia=0
								,nvk_isBHYT= case when "+LoaiBN+@"=1 and a.IsSuDungChoBH=1 then 1 else 0 end
                                , isTrongDM= convert(int,isnull(a.IsSuDungChoBH,0))
							from banggiadichvu a
								left join phongkhambenh b on a.idphongkhambenh=b.idphongkhambenh
                            WHERE loaiphong = 1 and a.idbanggiadichvu in (" + listidcanlamsan + ") order by tendichvu";
            DataTable dt = DataAcess.Connect.GetTable(sqlSelectBangGiaDichVu);
            html = tableCLS_Mini(dt, arrslvack, false, Request.QueryString["loai"], false, LoaiBN);
            Response.Clear();
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private void nvk_SetChanDoanPhoiHop()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idkhambenh = Request.QueryString["idkhoachinh"];
        string idctdkk = Request.QueryString["idctdkk"];
        #region table chẩn đoán phối hợp
        string tableCdPh = "";
        DataTable dtCDPH = DataAcess.Connect.GetTable("select ct.id,ct.idicd,cd.maicd,mota=isnull(ct.MoTaCD_edit,cd.mota) from chandoanphoihop ct inner join chandoanicd cd on cd.idicd=ct.idicd where ct.idkhambenh='" + idkhambenh + "'");
        //if (dtCDPH.Rows.Count == 0)
        //{
        //    string sqlPH = "select ct.id,ct.idicd,cd.maicd,cd.mota from chandoanphoihop ct inner join chandoanicd cd on cd.idicd=ct.idicd  where idkhambenh in (select top 1 idkhambenh from khambenh where idchitietdangkykham ='" + idctdkk + "' and idkhambenh <>'" + idkhambenh + "')";
        //    dtCDPH = DataAcess.Connect.GetTable(sqlPH);
        //}
        tableCdPh = strTableChanDoanPhoiHop(dtCDPH, 0);
        html.Append(tableCdPh);
        #endregion

        Response.Clear();
        Response.Write(html);
    }

    #endregion

    #region  giường bệnh bệnh nhân nội trú
    private void InsertAjaxGiuong()
    {
        string IdKhoaThemG = Request.QueryString["IdKhoaThemG"];
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idCtietDkkTG = Request.QueryString["idCtietDkkTG"];
        string Ngay = Request.QueryString["Ngay"];
        string Gio = Request.QueryString["Gio"];
        string NgayGio = StaticData.CheckDate(Ngay) + " " + Gio;
        string Phong = Request.QueryString["Phong"];
        string Giuong = Request.QueryString["Giuong"];
        string IsTinhNguyenNgay = Request.QueryString["cbTnNgay"];
        string TinhNgay = "0";
        if (IsTinhNguyenNgay.Equals("true") || IsTinhNguyenNgay.Equals("True"))
        { TinhNgay = "1"; }
        if (Giuong == null || Giuong.Equals(""))
            Giuong = "0";
        string GiaGiuong = Request.QueryString["GiaGiuong"].Replace(",", "");
        string Str_IsNgoaiTru = StaticData.nvk_xacNhan_IsNgoaiTru(IdKhoaThemG, idCtietDkkTG, null, null);
        string sqlInsertG = "";
        sqlInsertG = @"insert into benhnhannoitru (NgayVaoVien,IdKhoaNoiTru,IdChiTietDangKyKham,IdBenhNhan
                        ,IdPhongNoiTru,IdGiuong,GiaGiuong,isChonTrongNgay,isNhapKhoa,isdanhap,IsNgoaiTru)
                        values(
                        '" + NgayGio + "','" + IdKhoaThemG + "','" + idCtietDkkTG + "','" + idbenhnhan + @"'
                        ,'" + Phong + "','" + Giuong + "','" + GiaGiuong + "'," + TinhNgay + ",0,1," + Str_IsNgoaiTru+ ")";
        bool ktInsert = DataAcess.Connect.ExecSQL(sqlInsertG);
        if (ktInsert)
        {
            string idInSert = DataAcess.Connect.GetTable("select idnoitru=isnull((select top 1 idnoitru from benhnhannoitru order by idnoitru desc),0)").Rows[0]["idnoitru"].ToString();
            if (IsTinhNguyenNgay.Equals("true") || IsTinhNguyenNgay.Equals("True"))
            {
                bool ktTTG = StaticData.NVK_CapNhatTinhTrangGiuong(Ngay, idCtietDkkTG, idInSert, "0");
            }
            Response.Clear();
            Response.Write("1");
        }
        else
        {
            Response.Clear();
            Response.Write("0");
        }
    }
    private void UpdateAjaxGiuong()
    {
        string idnoitruSua = Request.QueryString["idnoitruSua"];
        string idCtDkkSG = Request.QueryString["idCtDkkSG"];
        string Ngay = Request.QueryString["Ngay"];
        string Gio = Request.QueryString["Gio"];
        string NgayGio = StaticData.CheckDate(Ngay) + " " + Gio;
        string Phong = Request.QueryString["Phong"];
        string Giuong = Request.QueryString["Giuong"];
        string IsTinhNguyenNgay = Request.QueryString["cbTnNgay"];
        string TinhNgay = "0";
        if (IsTinhNguyenNgay.Equals("true") || IsTinhNguyenNgay.Equals("True"))
        { TinhNgay = "1"; }
        if (Giuong == null || Giuong.Equals(""))
            Giuong = "0";
        string GiaGiuong = Request.QueryString["GiaGiuong"].Replace(",", "");
        string sqlUpDateG = "update benhnhannoitru set ngayvaovien='" + NgayGio + "' ,idphongNoiTRu='" + Phong + "',idGiuong='" + Giuong + "',Giagiuong='" + GiaGiuong + "',isChonTrongNgay='" + TinhNgay + "' where idnoitru=" + idnoitruSua + "";
        bool ktUpdate = DataAcess.Connect.ExecSQL(sqlUpDateG);
        if (ktUpdate)
        {
            if (IsTinhNguyenNgay.Equals("true") || IsTinhNguyenNgay.Equals("True"))
            {
                bool ktTTG = StaticData.NVK_CapNhatTinhTrangGiuong(Ngay, idCtDkkSG, idnoitruSua, "0");
            }
            Response.Clear();
            Response.Write("1");
        }
        else
        {
            Response.Clear();
            Response.Write("0");
        }
    }
    private void SearchGiuongTheoPhong()
    {
        string htmlG = "<select id='slGiuongTG' style='width:100px' onChange='LoadGiaTheoGiuong(this)'>";
        string idphongLoadG = Request.QueryString["idphongLoadG"];
        string IdKhoaNoiTru = Request.QueryString["IdKhoaNoiTru"];
        string LoaiGiaG = "giaDV";
        string LoaiBN = Request.QueryString["loaiBN"] ?? "";
        if (LoaiBN.Equals("1"))
        { LoaiGiaG = "giaBH"; }
        DataTable dtGiuongLoad = null;
        if (idphongLoadG != null && idphongLoadG != "")
        {
            dtGiuongLoad = DataAcess.Connect.GetTable("select g.GiuongID,GiuongCode,LoaiGiuong,giaBH,giaDV,giangoaigio from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid where g.idphong='" + idphongLoadG + "' order by banggiagiuongid desc");
            if (dtGiuongLoad != null && dtGiuongLoad.Rows.Count > 0)
            {
                for (int i = 0; i < dtGiuongLoad.Rows.Count; i++)
                {
                    htmlG += "<option value='" + dtGiuongLoad.Rows[i]["GiuongID"] + "'>" + dtGiuongLoad.Rows[i]["GiuongCode"] + "</option>";
                }
            }
        }
        htmlG += @"          </select>";
        try
        {
            htmlG += "~~" + StaticData.FormatNumberOption(dtGiuongLoad.Rows[0][LoaiGiaG], ",", ".", false);
        }
        catch (Exception)
        {
            htmlG += "~~0";
        }
        Response.Clear();
        Response.Write(htmlG);
    }
    private void SearchGiaTheoGiuong()
    {
        string htmlG = "";
        string idGiuongLoadGia = Request.QueryString["idGiuongLoadGia"];
        string IdKhoaNoiTru = Request.QueryString["IdKhoaNoiTru"];
        string LoaiGiaG = "giaDV";
        string LoaiBN = Request.QueryString["loaiBN"] ?? "";
        if (LoaiBN.Equals("1"))
        { LoaiGiaG = "giaBH"; }
        DataTable dtGiuongLoad = null;
        if (idGiuongLoadGia != null && idGiuongLoadGia != "")
        {
            dtGiuongLoad = DataAcess.Connect.GetTable("select g.GiuongID,GiuongCode,LoaiGiuong,giaBH,giaDV,giangoaigio from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid where g.giuongid='" + idGiuongLoadGia + "' order by banggiagiuongid desc");
            if (dtGiuongLoad != null && dtGiuongLoad.Rows.Count > 0)
            {
                htmlG += StaticData.FormatNumberOption(dtGiuongLoad.Rows[0][LoaiGiaG], ",", ".", false).ToString();
            }
        }
        Response.Clear();
        Response.Write(htmlG);
    }
    private void ThemGiuongPOPUP()
    {
        string html = "Information thêm giường Từ Ajax !";
        string idkhoaTG = Request.QueryString["idkhoaTG"];
        string idchitiedangkykhamTG = Request.QueryString["idchitietdkkTG"];
        string LoaiGiaG = "giaDV";
        string LoaiBN = Request.QueryString["loaiBN"] ?? "";
        if (LoaiBN.Equals("1"))
        { LoaiGiaG = "giaBH"; }
        else if (!LoaiBN.Equals(""))
            LoaiBN = "0";
        // Table nội dung Phòng
        #region DanhSachPhong
        string sqlPhongTG = "select phongTen=maso +'-'+tenphong,* from kb_phong where isPhongNoiTru =1 and loaibn like '%" + LoaiBN + "%' and dichvuKCB in(select idbanggiadichvu from banggiadichvu where idphongkhambenh ='" + idkhoaTG + "')";
        DataTable dtPhongTG = DataAcess.Connect.GetTable(sqlPhongTG);
        #endregion
        // Table nội dung Giường
        #region DanhSachGiường
        DataTable dtGiuongTG = null;
        if (dtPhongTG != null && dtPhongTG.Rows.Count > 0)
        {
            dtGiuongTG = DataAcess.Connect.GetTable("select g.GiuongID,GiuongCode,LoaiGiuong,giaBH,giaDV,giangoaigio from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid where g.idphong='" + dtPhongTG.Rows[0]["id"] + "' order by banggiagiuongid desc");
        }
        #endregion
        // Ngày giường
        #region
        string NgayThem = DateTime.Now.ToString("dd/MM/yyyy");
        string GioThem = DateTime.Now.ToString("HH:mm");
        #endregion
        html = @"<div style='width:100%;overflow:auto;height:100px'>
                <table style='width:100%;height:100%'>
                    <tr>
                        <td colspan='4' style='width: 100%; padding-left: 5px;padding-right: 5px;text-align:left'>
                            Ngày :
                            <input mkv='true' id='NgayThemGiuong' type='text' value='" + NgayThem + @"' onfocus='chuyenphim(this);$(this).datepick();'
                                      onblur='nvk_testDate_this(this);' style='width: 90px' />
                                (dd\MM\yyyy)
                            <input mkv='true' id='GioThemGiuong' type='text'  value='" + GioThem + @"' style='width: 40px' />
                                (HH:mm)
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='color:red'><input type='checkbox' id='cbTinhNguyenNgay' /> Tính nguyên ngày</span>
                        </td>
                    </tr>
                    <tr>
                        <td style='width: 35%; padding-left: 5px;padding-right: 5px'>
                            Phòng :
                            <select id='slPhongTG' style='width:200px'  onChange='LoadGiuongTheoPhong(this)'>";
        if (dtPhongTG != null && dtPhongTG.Rows.Count > 0)
        {
            for (int i = 0; i < dtPhongTG.Rows.Count; i++)
            {
                //if(i==0)
                html += "<option value='" + dtPhongTG.Rows[i]["id"] + "'>" + dtPhongTG.Rows[i]["phongTen"] + "</option>";
                //else
                //    html +="<option value='"+dtPhongTG.Rows[i]["id"]+"'>"+dtPhongTG.Rows[i]["phongTen"]+"</option>";
            }
        }
        html += @"          </select>
                            </td>
                    <td  style='width: 30%; padding-left: 5px;padding-right: 5px'>
                            Giường :
                            <span id='spSlGiuongTG' style='width:100%'>
                                <select id='slGiuongTG' style='width:100px' onChange='LoadGiaTheoGiuong(this)'>";
        if (dtGiuongTG != null && dtGiuongTG.Rows.Count > 0)
        {
            for (int i = 0; i < dtGiuongTG.Rows.Count; i++)
            {
                html += "<option value='" + dtGiuongTG.Rows[i]["GiuongID"] + "'>" + dtGiuongTG.Rows[i]["GiuongCode"] + "</option>";
            }
        }
        html += @"          </select>
                            </span>
                            </td>
                    <td class='ptext' style='width: 20%; padding-left: 5px'>
                            Giá/ngày :
                            <input type='text' id='txtDonGiaGiuongTG' value='" + StaticData.FormatNumberOption(dtGiuongTG.Rows[0][LoaiGiaG], ",", ".", false) + @"' style='width:70px'/>
                            </td>
                    <td class='ptext' style='width: 15%; padding-left: 5px'>
                            <input type='button' value='Lưu giường' style='width:90px' onclick='LuuGuongMoi(" + idchitiedangkykhamTG + "," + idkhoaTG + @")'/>
                            </td>
                    </tr>
                </table>
            </div>";
        Response.Clear();
        Response.Write(html);
    }
    private void SuaGiuongPOPUP()
    {
        string html = "Information thêm giường Từ Ajax !";
        string idkhoaSG = Request.QueryString["idkhoaSG"];
        string idnoitru = Request.QueryString["idnoitru"];
        string idchitiedangkykhamSG = Request.QueryString["idchitietdkkSG"];
        string LoaiGiaG = "giaDV";
        string LoaiBN = Request.QueryString["loaiBN"] ?? "";
        if (LoaiBN.Equals("1"))
        { LoaiGiaG = "giaBH"; }
        else if (!LoaiBN.Equals(""))
            LoaiBN = "0";
        // Table Nội dung giường cũ
        #region lấy nội dung phòng, giường, giá giường cũ
        string sqlTTGiuong = @"select ngaygiuong=convert(varchar(10),ngayvaovien,103),Giogiuong=convert(varchar(5),ngayvaovien,108),idphongNoiTRu,idGiuong,Giagiuong,ischontrongngay=isnull(convert(int,ischontrongngay),0)
 from benhnhannoitru  where idnoitru='" + idnoitru + "'";
        DataTable dtTTGiuongOld = DataAcess.Connect.GetTable(sqlTTGiuong);
        string checkTinhNgay = dtTTGiuongOld.Rows[0]["ischontrongngay"].ToString() == "1" ? "checked" : "";
        #endregion
        // Table nội dung Phòng
        #region DanhSachPhong theo Khoa
        string sqlPhongTG = "select phongTen=maso +'-'+tenphong,* from kb_phong where isPhongNoiTru =1 and loaibn like '%" + LoaiBN + "%' and dichvuKCB in(select idbanggiadichvu from banggiadichvu where idphongkhambenh ='" + idkhoaSG + "')";
        DataTable dtPhongSuaG = DataAcess.Connect.GetTable(sqlPhongTG);
        #endregion
        // Table nội dung Giường
        #region DanhSachGiường theo Phòng
        DataTable dtGiuongSuaG = null;
        if (dtPhongSuaG != null && dtPhongSuaG.Rows.Count > 0)
        {
            for (int i = 0; i < dtPhongSuaG.Rows.Count; i++)
            {
                if (dtPhongSuaG.Rows[i]["id"].Equals(dtTTGiuongOld.Rows[0]["idphongNoiTRu"]))
                {
                    dtGiuongSuaG = DataAcess.Connect.GetTable("select g.GiuongID,GiuongCode,LoaiGiuong,giaBH='" + dtTTGiuongOld.Rows[0]["GiaGiuong"] + "',giaDV='" + dtTTGiuongOld.Rows[0]["GiaGiuong"] + "',giangoaigio='" + dtTTGiuongOld.Rows[0]["GiaGiuong"] + "' from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid where g.idphong='" + dtPhongSuaG.Rows[i]["id"] + "' order by banggiagiuongid desc");
                }
            }
            if (dtGiuongSuaG == null)
                dtGiuongSuaG = DataAcess.Connect.GetTable("select g.GiuongID,GiuongCode,LoaiGiuong,giaBH,giaDV,giangoaigio from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid where g.idphong='" + dtPhongSuaG.Rows[0]["id"] + "' order by banggiagiuongid desc");
        }
        #endregion
        // Ngày giường
        #region Ngày giường sửa
        string NgayThem = dtTTGiuongOld.Rows[0]["ngaygiuong"].ToString() ?? "";
        string GioThem = dtTTGiuongOld.Rows[0]["Giogiuong"].ToString() ?? "";
        #endregion
        html = @"<div style='width:100%;overflow:auto;height:100px'>
                <table style='width:100%;height:100%'>
                    <tr>
                        <td colspan='4' style='width: 100%; padding-left: 5px;padding-right: 5px;text-align:left'>
                            Ngày :
                            <input mkv='true' id='NgayThemGiuong' type='text' value='" + NgayThem + @"' onfocus='chuyenphim(this);$(this).datepick();'
                                      onblur='nvk_testDate_this(this);' style='width: 90px' />
                                (dd\MM\yyyy)
                            <input mkv='true' id='GioThemGiuong' type='text'  value='" + GioThem + @"' style='width: 40px' />
                                (HH:mm)
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='color:red'><input type='checkbox' " + checkTinhNgay + @" id='cbTinhNguyenNgay' /> Tính nguyên ngày</span>
                        </td>
                    </tr>
                    <tr>
                        <td style='width: 35%; padding-left: 5px;padding-right: 5px'>
                            Phòng :
                            <select id='slPhongTG' style='width:200px'  onChange='LoadGiuongTheoPhong(this)'>";
        if (dtPhongSuaG != null && dtPhongSuaG.Rows.Count > 0)
        {
            for (int i = 0; i < dtPhongSuaG.Rows.Count; i++)
            {
                string select = "";
                if (dtPhongSuaG.Rows[i]["id"].Equals(dtTTGiuongOld.Rows[0]["idphongNoiTRu"]))
                    select = "selected = selected";
                html += "<option value='" + dtPhongSuaG.Rows[i]["id"] + "' " + select + ">" + dtPhongSuaG.Rows[i]["phongTen"] + "</option>";
            }
        }
        html += @"          </select>
                            </td>
                    <td  style='width: 30%; padding-left: 5px;padding-right: 5px'>
                            Giường :
                            <span id='spSlGiuongTG' style='width:100%'>
                                <select id='slGiuongTG' style='width:100px' onChange='LoadGiaTheoGiuong(this)'>";
        if (dtGiuongSuaG != null && dtGiuongSuaG.Rows.Count > 0)
        {
            for (int i = 0; i < dtGiuongSuaG.Rows.Count; i++)
            {
                string select = "";
                if (dtGiuongSuaG.Rows[i]["GiuongID"].Equals(dtTTGiuongOld.Rows[0]["idGiuong"]))
                    select = "selected = selected";
                html += "<option value='" + dtGiuongSuaG.Rows[i]["GiuongID"] + "' " + select + ">" + dtGiuongSuaG.Rows[i]["GiuongCode"] + "</option>";
            }
        }
        html += @"          </select>
                            </span>
                            </td>
                    <td class='ptext' style='width: 20%; padding-left: 5px'>
                            Giá/ngày :
                            <input type='text' id='txtDonGiaGiuongTG' onblur='TestSo(this,false,true);' value='" + StaticData.FormatNumberOption(dtGiuongSuaG.Rows[0][LoaiGiaG], ",", ".", false) + @"' style='width:70px'/>
                            </td>
                    <td class='ptext' style='width: 15%; padding-left: 5px'>
                            <input type='button' value='Sửa giường' style='width:90px' onclick='UpdateGiuong(" + idnoitru + "," + idchitiedangkykhamSG + @")'/>
                            </td>
                    </tr>
                </table>
            </div>";
        Response.Clear();
        Response.Write(html);
    }

    private void luuTableGiuongNoiTru()
    {
        try
        {
            string idkhoa = Request.QueryString["idkhoa"];
            if (idkhoa == null || idkhoa.Equals(""))
                idkhoa = "0";
            string idnoitru = Request.QueryString["idkhoachinh"];
            string idgiuong = Request.QueryString["IdGiuong"];
            string nvk_idctdkk = Request.QueryString["idctdkk"];
            string IdPhongNoiTru = "0";
            DataTable dtPhong = DataAcess.Connect.GetTable("select idphong from kb_giuong where giuongid=" + Request.QueryString["IdGiuong"]);
            if (dtPhong != null && dtPhong.Rows.Count > 0)
                IdPhongNoiTru = dtPhong.Rows[0]["idphong"].ToString();
            string GiaGiuong = Request.QueryString["dongia"].Replace(",", "");
            string SoNgay = Request.QueryString["songay"].Replace(",", "");
            if (GiaGiuong == null || GiaGiuong == "") GiaGiuong = "0";
            string sqlUpdate = @"update benhnhannoitru set IdGiuong=" + idgiuong + ",IdPhongNoiTru=" + IdPhongNoiTru + ",GiaGiuong=" + GiaGiuong + ",songay=" + SoNgay + " where idnoitru=" + idnoitru + "";
            //string sqlIsKB_PTT = "select * from kb_giuongphieuthanhtoan where IDGiuong=" + idnoitru + "";
            //DataTable dtG_PTT = DataAcess.Connect.GetTable(sqlIsKB_PTT);
            //if(idkhoa.Equals("15") && dtG_PTT != null && dtG_PTT.Rows.Count>0)
            //    sqlUpdate = @"update kb_giuongphieuthanhtoan set idgiuongxet=" + idgiuong + ",ThanhTien=" + GiaGiuong + ",songay=" + SoNgay + " where IDGiuong=" + idnoitru + "";
            bool kt = DataAcess.Connect.ExecSQL(sqlUpdate);
            if (kt)
            {
                DataTable dt_kbG = DataAcess.Connect.GetTable("select IdChiTietGiuongBN= isnull((select IdChiTietGiuongBN from KB_ChiTietGiuongBN where idnoitru_G='" + idnoitru + "'),0)");
                string IdChiTietGiuongBN = dt_kbG.Rows[0]["IdChiTietGiuongBN"].ToString();//Request.QueryString["IdChiTietGiuongBN"];
                string tungaygiuong = StaticData.CheckDate(Request.QueryString["tungay"].ToString()) + " " + Request.QueryString["tugio"].ToString();
                string denngaygiuong = StaticData.CheckDate(Request.QueryString["denngay"].ToString()) + " " + Request.QueryString["dengio"].ToString();

                #region xác định các tham số KB_ChiTietGiuongBN
                string Sql_InfoG = @"select top 1 tungay
                        ,IsBHYT= case when  isnull(bg.IsBHYT,0)=1 and 
                        isnull(
	                        (select top 1 bn.loai from benhnhan bn inner join dangkykham dk on dk.idbenhnhan =bn.idbenhnhan
											                        inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                          where ct.idchitietdangkykham ='"+nvk_idctdkk+@"'
	                        )
                        ,0)=1 then 1
                        else 0 end ,DonGiaDV=GiaDV ,ThanhTienDV=GiaDV * " + SoNgay + " ,DonGiaBH=GiaBH,ThanhTienBH=GiaBH * " + SoNgay + " from kb_banggiagiuong bg where GiuongId='" + idgiuong + "' order by tungay desc ";
                DataTable dt_InfoG = DataAcess.Connect.GetTable(Sql_InfoG);
                string IsBHYT = dt_InfoG.Rows[0]["IsBHYT"].ToString();
                string DonGiaDV = dt_InfoG.Rows[0]["DonGiaDV"].ToString();
                string ThanhTienDV = dt_InfoG.Rows[0]["ThanhTienDV"].ToString();
                string DonGiaBH = dt_InfoG.Rows[0]["DonGiaBH"].ToString();
                string ThanhTienBH = dt_InfoG.Rows[0]["ThanhTienBH"].ToString();
                if (!IsBHYT.Equals("1"))
                {
                    DonGiaBH = "0";
                    ThanhTienBH = "0";
                }
                #endregion
                string nvk_sql = "";
                if (!IdChiTietGiuongBN.Equals("0"))
                {
                    nvk_sql = @"update KB_ChiTietGiuongBN set idkhoa='"+idkhoa+"', TuNgay='" + tungaygiuong + "',DenNgay='" + denngaygiuong + "',IsBHYT=" + IsBHYT + ",IdGiuong='" + idgiuong + "',SL='" + SoNgay + @"',DonGiaDV='" + DonGiaDV + "',ThanhTienDV='" + ThanhTienDV + "',DonGiaBH='" + DonGiaBH + "',ThanhTienBH='" + ThanhTienBH + @"'
                                where IdChiTietGiuongBN='" + IdChiTietGiuongBN + "'";
                }
                else
                {
                    nvk_sql = @"
                            insert into KB_ChiTietGiuongBN (

	                            TuNgay
	                            ,DenNgay
	                            ,IsBHYT
	                            ,IdGiuong
	                            ,IdChiTietDangKyKham
	                            ,SL
	                            ,DonGiaDV
	                            ,ThanhTienDV
	                            ,DonGiaBH
	                            ,ThanhTienBH
	                            ,BHTra
	                            ,BNTra
	                            ,IsDaThu
	                            ,idkhoa
	                            ,idnoitru_G)
                             values
	                            ('" + tungaygiuong + @"'
	                            ,'" + denngaygiuong + @"'
	                            ," + IsBHYT + @"
	                            ,'" + idgiuong + @"'
	                            ,'" + nvk_idctdkk + @"'
	                            ,'" + SoNgay + @"'
	                            ,'" + DonGiaDV + @"'
	                            ,'" + ThanhTienDV + @"'
	                            ,'" + DonGiaBH + @"'
	                            ,'" + ThanhTienBH + @"'
	                            ,null
	                            ,null
	                            ,'0'
	                            ,'"+idkhoa+@"'
	                            ,'" + idnoitru + "')";
                }
                bool kt_nvk = DataAcess.Connect.ExecSQL(nvk_sql);
                //StaticData.TinhLaiTien_ByIdDangKyKham(nvk_idctdkk); // gọi tính tiền sau lưu talbe nên khóa
                Response.Clear(); Response.Write(idnoitru);
                return;
            }
        }
        catch (Exception ex)
        { }
        Response.StatusCode = 500;
    }
    private void luuTableGiuongNoiTru_2509()
    {
        try
        {
            string idkhoa = Request.QueryString["idkhoa_noitru"];
            string idbenhnhan = Request.QueryString["idbenhnhan"];
            string nvk_idctdkk = Request.QueryString["idctdkk"];

            string idnoitru = Request.QueryString["idkhoachinh"];
            string idkhoa_Gi = Request.QueryString["idkhoa"];
            string idgiuong = Request.QueryString["IdGiuong"];
            string GiaGiuong = "0";//Request.QueryString["dongia"].Replace(",", "");
            string SoNgay = Request.QueryString["songay"].Replace(",", "");
            string tungaygiuong = StaticData.CheckDate(Request.QueryString["tungay"].ToString()) + " " + Request.QueryString["tugio"].ToString();
            string denngaygiuong = StaticData.CheckDate(Request.QueryString["denngay"].ToString()) + " " + Request.QueryString["dengio"].ToString();
            string nvk_isBHYT = "0";
            if (Request.QueryString["nvk_isBHYT"] != null)
                nvk_isBHYT = Request.QueryString["nvk_isBHYT"].ToString();
            if (nvk_isBHYT.ToLower().Equals("true"))
                nvk_isBHYT = "1";
            else
                nvk_isBHYT = "0";
            if (idgiuong == null || idgiuong.Equals("") || idgiuong.Equals("0"))
            {
                Response.StatusCode = 500;
                return;
            }
            string IdPhongNoiTru = "0";
            DataTable dtPhong = DataAcess.Connect.GetTable("select idphong from kb_giuong where giuongid='" + idgiuong + "'");
            if (dtPhong != null && dtPhong.Rows.Count > 0)
                IdPhongNoiTru = dtPhong.Rows[0]["idphong"].ToString();
            if (GiaGiuong == null || GiaGiuong == "") GiaGiuong = "0";
            string Str_IsNgoaiTru = StaticData.nvk_xacNhan_IsNgoaiTru(idkhoa_Gi, nvk_idctdkk, null, null);

            #region lưu bệnh nhân nội trú
            string sqlU_Igiuong ="";
            bool kt = false;
            if (idnoitru != null && idnoitru != "" && idnoitru != "")
            {
                sqlU_Igiuong = @"update benhnhannoitru set IdGiuong=" + idgiuong + ",IdPhongNoiTru=" + IdPhongNoiTru + ",GiaGiuong=" + GiaGiuong + " where idnoitru=" + idnoitru + "";//,songay=" + SoNgay + "
                kt = DataAcess.Connect.ExecSQL(sqlU_Igiuong);
            }
            else
            {
                string isdanhap = "1";
                if (!idkhoa_Gi.Equals(idkhoa) || idkhoa.Equals("22"))
                    isdanhap = "0";
                sqlU_Igiuong  = @"insert into benhnhannoitru (NgayVaoVien,IdKhoaNoiTru,IdChiTietDangKyKham,IdBenhNhan
                        ,IdPhongNoiTru,IdGiuong,GiaGiuong,isChonTrongNgay,isNhapKhoa,isdanhap,IsNgoaiTru)
                        values(
                        '" + tungaygiuong + "','" + idkhoa_Gi + "','" + nvk_idctdkk + "','" + idbenhnhan + @"'
                        ,'" + IdPhongNoiTru + "','" + idgiuong + "','" + GiaGiuong + "',0,0,"+isdanhap+"," + Str_IsNgoaiTru + ")";
                kt = DataAcess.Connect.ExecSQL(sqlU_Igiuong);
                if (kt)
                    idnoitru = DataAcess.Connect.GetTable("select isnull(max(idnoitru),0) from benhnhannoitru").Rows[0][0].ToString();
            }
            #endregion
            
            if (kt)
            {
                DataTable dt_kbG = DataAcess.Connect.GetTable("select IdChiTietGiuongBN= isnull((select IdChiTietGiuongBN from KB_ChiTietGiuongBN where idnoitru_G='" + idnoitru + "'),0)");
                string IdChiTietGiuongBN = dt_kbG.Rows[0]["IdChiTietGiuongBN"].ToString();//Request.QueryString["IdChiTietGiuongBN"];
                
                #region xác định các tham số KB_ChiTietGiuongBN
                string Sql_InfoG = @"SELECT TOP 1 TUNGAY,ISBHYT,DonGiaDV=GIADV,ThanhTienDV=GIADV*" + SoNgay + @",DonGiaBH=GIABH
                                                ,ThanhTienBH=GIABH*" + SoNgay + @"
                                             FROM 
                                                KB_GIUONG D  
	                                            INNER JOIN HS_BANGGIAGIUONG A ON A.IDLOAIGIUONG=D.IDLOAIGIUONG
                                               INNER JOIN HS_BANGGIAGIUONG_LAN B ON A.BANGGIAID=B.BANGGIAID
                                              WHERE
		                                             D.GIUONGID=" + idgiuong+@"
		                                             AND B.TUNGAY<=(SELECT NGAYDANGKY_CHITIET FROM CHITIETDANGKYKHAM WHERE IDCHITIETDANGKYKHAM=" + nvk_idctdkk + @")
                                            ORDER BY B.TUNGAY DESC";

                DataTable dt_InfoG = DataAcess.Connect.GetTable(Sql_InfoG);
                //string IsBHYT = dt_InfoG.Rows[0]["IsBHYT"].ToString();
                string DonGiaDV = dt_InfoG.Rows[0]["DonGiaDV"].ToString();
                string ThanhTienDV = dt_InfoG.Rows[0]["ThanhTienDV"].ToString();
                string DonGiaBH = dt_InfoG.Rows[0]["DonGiaBH"].ToString();
                string ThanhTienBH = dt_InfoG.Rows[0]["ThanhTienBH"].ToString();
                //if (!IsBHYT.Equals("1"))
                if (!nvk_isBHYT.Equals("1"))
                {
                    DonGiaBH = "0";
                    ThanhTienBH = "0";
                }
                #endregion
                string nvk_sql = "";
                if (!IdChiTietGiuongBN.Equals("0"))
                {
                    nvk_sql = @"update KB_ChiTietGiuongBN set idkhoa='" + idkhoa_Gi + "', TuNgay='" + tungaygiuong + "',DenNgay='" + denngaygiuong + "',IsBHYT=" + nvk_isBHYT + ",IdGiuong='" + idgiuong + "',SL='" + SoNgay + @"',DonGiaDV='" + DonGiaDV + "',ThanhTienDV='" + ThanhTienDV + "',DonGiaBH='" + DonGiaBH + "',ThanhTienBH='" + ThanhTienBH + @"'
                                where IdChiTietGiuongBN='" + IdChiTietGiuongBN + "'";
                }
                else
                {
                    nvk_sql = @"
                            insert into KB_ChiTietGiuongBN (

	                            TuNgay
	                            ,DenNgay
	                            ,IsBHYT
	                            ,IdGiuong
	                            ,IdChiTietDangKyKham
	                            ,SL
	                            ,DonGiaDV
	                            ,ThanhTienDV
	                            ,DonGiaBH
	                            ,ThanhTienBH
	                            ,BHTra
	                            ,BNTra
	                            ,IsDaThu
	                            ,idkhoa
	                            ,idnoitru_G)
                             values
	                            ('" + tungaygiuong + @"'
	                            ,'" + denngaygiuong + @"'
	                            ," + nvk_isBHYT + @"
	                            ,'" + idgiuong + @"'
	                            ,'" + nvk_idctdkk + @"'
	                            ,'" + SoNgay + @"'
	                            ,'" + DonGiaDV + @"'
	                            ,'" + ThanhTienDV + @"'
	                            ,'" + DonGiaBH + @"'
	                            ,'" + ThanhTienBH + @"'
	                            ,null
	                            ,null
	                            ,'0'
	                            ,'" + idkhoa_Gi + @"'
	                            ,'" + idnoitru + "')";
                }
                bool kt_nvk = DataAcess.Connect.ExecSQL(nvk_sql);
                //StaticData.TinhLaiTien_ByIdDangKyKham(nvk_idctdkk); // gọi tính tiền sau lưu talbe nên khóa
                Response.Clear(); Response.Write(idnoitru);
                return;
            }
        }
        catch (Exception ex)
        { }
        Response.StatusCode = 500;
    }

    private void LoadThongTinTienGiuong()
    {
        string html = "Information Tiền giường Ajax !";
        string mabenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        string isTinhLai = Request.QueryString["isTinhLai"];
        if (mabenhnhan == null || mabenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        //html = ThongTinTienGiuong(mabenhnhan,idchitiedangkykham, idkhoa);
        html = ThongTinTienGiuong_2509(mabenhnhan, idchitiedangkykham, idkhoa, isTinhLai);
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    private void TimKiemBenhNhan()
    {
        string html = "  Nam Mô a di đà !";
        string mabenhnhan = Request.QueryString["mabenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string tenbenhnhan = Request.QueryString["tenbenhnhan"];
        string sqlBN = @"
        select * from ( (
            select  distinct  dbo.idchitietdangkykham,dbo.idbenhnhan,mabenhnhan,tenbenhnhan,diachi,LoaiKham=Loai.MaLoaiBN,dk.ngaydangky
                ,case when isnull(bn.gioitinh,0)=1 then N'Nữ' else N'Nam' end as Gioi
                        ,dienthoai,gioitinh,ngaysinh as namsinh 
                        ,iddichvugoc=bg.idbanggiadichvu
                        ,dbo.ngaynhapvien
						,idkhoanoitru=" + idkhoa + @"
						,isTamTheoDoi=0
                        from  dbo.[NVK_DSBNNoiTruTheoKhoa_1](" + idkhoa + @")  dbo
                inner join benhnhan bn on bn.idbenhnhan= dbo.idbenhnhan
                        inner join chitietdangkykham ctdkk on dbo.idchitietdangkykham= ctdkk.idchitietdangkykham 
        		inner join dangkykham dk on dk.iddangkykham=ctdkk.iddangkykham
                        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
                        left join kb_phong phong on ctdkk.phongid=phong.id
                    left join kb_loaiBN Loai on Loai.id=dk.LoaiKhamID
                        where bn.mabenhnhan like N'%" + mabenhnhan + "%' and bn.tenbenhnhan like N'%" + tenbenhnhan + @"%' 
                     --order by dbo.ngaynhapvien desc
)union(
select  distinct  dbo.idchitietdangkykham,dbo.idbenhnhan,mabenhnhan,tenbenhnhan,diachi,LoaiKham=Loai.MaLoaiBN,dk.ngaydangky
                ,case when isnull(bn.gioitinh,0)=1 then N'Nữ' else N'Nam' end as Gioi
                        ,dienthoai,gioitinh,ngaysinh as namsinh 
                        ,iddichvugoc=bg.idbanggiadichvu
                        ,ngaynhapvien= (SELECT TOP 1 NGAYVAOVIEN FROM BENHNHANNOITRU KK WHERE KK.IDCHITIETDANGKYKHAM=dbo.IDCHITIETDANGKYKHAM   ORDER BY KK.IDNOITRU ASC)
						,idkhoanoitru=dbo.idkhoanoitru
						,isTamTheoDoi=1
from  benhnhannoitru  dbo
                inner join benhnhan bn on bn.idbenhnhan= dbo.idbenhnhan
                inner join chitietdangkykham ctdkk on dbo.idchitietdangkykham= ctdkk.idchitietdangkykham 
        		inner join dangkykham dk on dk.iddangkykham=ctdkk.iddangkykham
                        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
                        left join kb_phong phong on ctdkk.phongid=phong.id
                    left join kb_loaiBN Loai on Loai.id=dk.LoaiKhamID
                        where dbo.idkhoanoitru ='" + idkhoa + @"' and
                            dbo.isTamTheoDoi=1 and isdanhap=0 and bn.mabenhnhan like N'%" + mabenhnhan + "%' and bn.tenbenhnhan like N'%" + tenbenhnhan + @"%' 
)
) as nvk order by isTamTheoDoi desc,ngaynhapvien desc
";
        DataTable table = DataAcess.Connect.GetTable(sqlBN);
        html = DanhSachBenhNhanCho(table);
        Response.Clear();
        Response.Write(html);
    }
    private void LoadThongTinTamUng()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string mabenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        if (mabenhnhan == null || mabenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        #region sql danh sách tạm ứng cũ
//        string sql = @"select row_number() over(order by idtamung) as stt
//,ct.sophieuCT,ct.sodangky,ct.quyenso,tu.idtamung,ngayTU=convert(varchar(10),tu.ngaytamung,103)+' '+convert(varchar(5),tu.ngaytamung,108)
//,tu.sotien
//,case when isdathu=1 then N'Đã thu' else N'Chưa thu' end as TinhTrangThu
//,lantamung=isnull((select count(idtamung) from tamung where isnull(soctHU,'')='' and idtamung <=tu.idtamung and iddangkykham=tu.iddangkykham),1)
//,tu.idkhoaTU,p.tenphongkhambenh,tu.MAPHIEU_TU
//,case when isnull(tu.SoTienHU,0)>0 then N'Đã hoàn ứng' else N'' end as nvk_ttHU
//
// from tamung tu left join sochungtu ct on ct.STT=tu.SoCTTU left join phongkhambenh p on p.idphongkhambenh=tu.idkhoaTU  where isnull(soctHU,'')='' and iddangkykham=" + idchitiedangkykham + @"
//        ";
//        DataTable table = DataAcess.Connect.GetTable(sql);
//        html.Append(@"<fieldset><legend>Tạm ứng</legend>
//                <div class='div-Out' style='height:auto;width:96%'>");
//        html.Append(ThongTinTamUng(table, idkhoa));
//        html.Append(@"</div>
//                </fieldset>");
        #endregion
        html.Append(nvk_ThongTinCongNoBenhNhan(idkhoa, idchitiedangkykham,true));
        
        Response.Clear();
        Response.Write(html);
    }
    private void nvk_deleteTamUng()
    {
        string idtamung = Request.QueryString["idtamung"];
        DataTable dtDathu = DataAcess.Connect.GetTable("select * from tamung where isnull(isdathu,0)=1 and idtamung ='" + idtamung + "'");
        if (dtDathu.Rows.Count > 0)
        {
            Response.Clear();
            Response.Write("");// Thất bại(đã thu không được xóa)
            return;
        }
        string sql_delTU = "delete from tamung where idtamung ='" + idtamung + "'";
        bool ktDel = DataAcess.Connect.ExecSQL(sql_delTU);
        if (ktDel)
        {
            Response.Clear();
            Response.Write("1");// Thành công
        }
        else
        {
            Response.Clear();
            Response.Write("");// Thất bại
        }
    }
    private void nvk_LuuTamUng()
    {
        try
        {
            string IdKhoaTU = "0";
            if (Request.QueryString["idkhoa"] != null)
                IdKhoaTU = Request.QueryString["idkhoa"];
            string iddangkykham = Request.QueryString["iddangkykham"];
            double sotien = double.Parse(Request.QueryString["sotien"]);
            string SoDangKy = Request.QueryString["SoDangKy"].ToString();
            string quyenso = Request.QueryString["quyenso"].ToString();
            string lydoTU = Request.QueryString["lydoTU"].ToString();
            string ngayUT = DataAcess.Connect.s_SystemDate();
            string nvk_idtamung = Request.QueryString["idtamung"];
            if (string.IsNullOrEmpty(nvk_idtamung) || nvk_idtamung.Equals("0"))
            {
                #region  lưu mới tạm ứng
                string sqlbn = ""
                                   + "  select c.tenbenhnhan,c.idbenhnhan from chitietdangkykham a" + "\r\n"
                                   + "  left join dangkykham b on a.iddangkykham=b.iddangkykham" + "\r\n"
                                   + " left join benhnhan c on c.idbenhnhan=b.idbenhnhan " + "\r\n"
                                   + " where a.idchitietdangkykham=" + iddangkykham + "\r\n";
                DataTable dtht = DataAcess.Connect.GetTable(sqlbn);
                string HoTen = "";
                string idbenhnhan = "0";
                if (dtht != null && dtht.Rows.Count > 0)
                {
                    HoTen = dtht.Rows[0]["tenbenhnhan"].ToString();
                    idbenhnhan = dtht.Rows[0]["idbenhnhan"].ToString();
                }
                string NewSTT = "";
                string NgaySCT = (DateTime.Parse(DataAcess.Connect.s_SystemDate())).ToString("MM/dd/yyyy hh:ss");
                NewSTT = StaticData.NewSoChungTuGetID(NgaySCT, HoTen, "Tạm ứng khám bệnh", sotien.ToString());
                string NgayHoanU = null;
                string sqlInsert = @"insert into tamUng (iddangkykham,
                        sotien,
                        ngayTamung,
                        NgayHoanUng,
                        SoCTHU,
                        SoTienHU,
                        GhiChu,
                        SoCTTU,
                        dahoanung,
                        QuyenSo,
                        IsDaThu,
                        LyDoTU,
                        IsDaHuy,
                        idkhoaTU)
            values(" + iddangkykham + "," + sotien + ",'" + ngayUT + "','" + NgayHoanU + "',null,'',N'" + lydoTU + "','" + NewSTT + "',0,'" + quyenso + "',0,N'" + lydoTU + "',0,'" + IdKhoaTU + "')";
                bool result = DataAcess.Connect.ExecSQL(sqlInsert);
                if (result == false)
                {
                    Response.Write(""); return;
                }
                else
                {
                    string sqlIdTamung = "select isnull(max(idtamung),0) from tamung";
                    DataTable dtIdTU = DataAcess.Connect.GetTable(sqlIdTamung);
                    if (dtIdTU.Rows.Count > 0)
                        Response.Write(dtIdTU.Rows[0][0].ToString());
                    else
                        Response.Write("1");
                    return;
                }
                #endregion
            }
            else
            {
                #region update tamung
                string sqlUpDate = "update tamung set sotien='" + sotien + "',GhiChu=N'" + lydoTU + "',LyDoTU=N'" + lydoTU + "' where idtamung ='" + nvk_idtamung + "'";
                bool ktUd = DataAcess.Connect.ExecSQL(sqlUpDate);
                if (ktUd)
                    Response.Write(nvk_idtamung);
                else
                    Response.Write("");
                #endregion
            }
        }
        catch (Exception ex)
        {
            Response.Write("");
        }
    }
    private void SetBenhNhanDangKham()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string mabenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        if (mabenhnhan == null || mabenhnhan.Equals("") || idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("");
            return;
        }
        string sql = @"select mabenhnhan,tenbenhnhan,ngaysinh,gioitinh=dbo.getgioitinh(gioitinh),diachi,tenquoctich,tennghenghiep,tendantoc
            ,lankhamkhoa=isnull((select count(idchitietdangkykham) from (
            select distinct idchitietdangkykham,idbenhnhan  from khambenh where idbenhnhan=bn.idbenhnhan  and idchitietdangkykham <=" +idchitiedangkykham+" and idphongkhambenh='" + idkhoa + @"'
            ) as abc group by idbenhnhan)
            ,1)
            ,idkhambenhgoc=isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=" + idchitiedangkykham + @"),0)
            ,loai=(SELECT LOAIKHAMID FROM CHITIETDANGKYKHAM A LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM WHERE A.IDCHITIETDANGKYKHAM="+idchitiedangkykham+@")
            ,SOVAOVIEN=DBO.zHS_GetSoVaoVien(" + idchitiedangkykham + @")
        from benhnhan bn left join quoctich qt on qt.idquoctich=bn.quoctich
                left join nghenghiep nn on nn.idnghenghiep=bn.nghenghiep
                left join dantoc dt on dt.id=bn.dantoc
        where idbenhnhan='" + mabenhnhan + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null && table.Rows.Count > 0)
        {
            html.Append(@"<table  bordercolor='white' border=2px style='border-collapse:collapse;'>
                                <tr>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Mã bệnh nhân :</span></td>
                                    <td>" + table.Rows[0]["mabenhnhan"] + @"</td>
                                </tr>
                                <tr>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Tên bệnh nhân :</span></td>
                                    <td>" + table.Rows[0]["tenbenhnhan"] + @"</td>
                                </tr>
                                <tr>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Năm sinh :</span></td>
                                    <td>" + table.Rows[0]["ngaysinh"] + @"</td>
                                </tr>
                                <tr>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Giới tính :</span></td>
                                    <td>" + table.Rows[0]["gioitinh"] + @"</td>
                                </tr>
                                
                                <tr>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Địa chỉ :</span></td>
                                    <td>" + table.Rows[0]["diachi"] + @"</td>
                                </tr>
                                <tr>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Nhập khoa lần :</span></td>
                                    <td>" + table.Rows[0]["lankhamkhoa"] + @"</td>
                                </tr>
                                <tr>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Số vào viện :</span></td>
                                    <td  style='color: Red; font-weight: bold' >" + table.Rows[0]["SOVAOVIEN"] + @"</td>
                                </tr>
                                   <tr>
                                    <td colspan='2'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Quốc tịch :</span>
                                    " + table.Rows[0]["tenquoctich"] + @"&nbsp;&nbsp;
                                    <span style='color: #0000cc; font-weight: bold' class='Tieude'>Dân tộc :</span>" + table.Rows[0]["tendantoc"] + @"&nbsp;&nbsp;<br/>
                                    <span style='color: #0000cc; font-weight: bold' class='Tieude'>Nghề nghiệp :</span>" + table.Rows[0]["tennghenghiep"] + @"&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>");
            html.Append("~~" + table.Rows[0]["idkhambenhgoc"]);
            html.Append("~~" + table.Rows[0]["loai"]);
        }
        Response.Clear();
        Response.Write(html);
    }
    private void nvk_SetBenhNhanCongNo()
    {
        string html = "";
        string mabenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idchitiedangkykham = Request.QueryString["idctdkk"];
        if (mabenhnhan == null || mabenhnhan.Equals(""))
        {
            Response.Write("");
            return;
        }
        string sql = @"select mabenhnhan,tenbenhnhan,ngaysinh,gioitinh=dbo.getgioitinh(gioitinh),diachi,dienthoai
            ,lankhamkhoa=isnull((select count(idchitietdangkykham) from (
            select distinct idchitietdangkykham,idbenhnhan  from khambenh where idbenhnhan=bn.idbenhnhan  and idchitietdangkykham <="+idchitiedangkykham+"--and idphongkhambenh='" + idkhoa + @"'
            ) as abc group by idbenhnhan)
            ,1)
            ,idkhambenhgoc=isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=" + idchitiedangkykham + @"),0)
            ,loai=(SELECT LOAIKHAMID FROM CHITIETDANGKYKHAM A LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM WHERE A.IDCHITIETDANGKYKHAM=" + idchitiedangkykham + @")
            ,SOVAOVIEN=DBO.zHS_GetSoVaoVien(" + idchitiedangkykham + @")
        from benhnhan bn where idbenhnhan='" + mabenhnhan + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        html = @"<table rules='all' id='table_BenhNhanCongNo'>
                                <tr>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Mã bệnh nhân :</span></td>
                                    <td>" + table.Rows[0]["mabenhnhan"] + @"</td>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Tên bệnh nhân :</span></td>
                                    <td>" + table.Rows[0]["tenbenhnhan"] + @"</td>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Năm sinh :</span></td>
                                    <td>" + table.Rows[0]["ngaysinh"] + @"</td>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Giới tính :</span></td>
                                    <td>" + table.Rows[0]["gioitinh"] + @"</td>
                                </tr>
                                <tr>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Địa chỉ :</span></td>
                                    <td>" + table.Rows[0]["diachi"] + @"</td>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Điện thoại :</span></td>
                                    <td>" + table.Rows[0]["dienthoai"] + @"</td>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Nhập viện lần :</span></td>
                                    <td>" + table.Rows[0]["lankhamkhoa"] + @"</td>
                                    <td style='width:110px'><span style='color: #0000cc; font-weight: bold' class='Tieude'>Số vào viện :</span></td>
                                    <td>" + table.Rows[0]["SOVAOVIEN"] + @"</td>
                                    
                                </tr>
                            </table>";
        html += "~~" + table.Rows[0]["idkhambenhgoc"];
        html += "~~" + table.Rows[0]["loai"];
        Response.Clear();
        Response.Write(html);
    }
    private void nvk_xoachitietGiuongbn_noitru()
    {
        try
        {
            string idnoitruXoa = Request.QueryString["idnoitruXoa"];
            string sql_del= "delete from kb_chitietgiuongbn where idnoitru_G='" + idnoitruXoa + "'";
            bool ok = DataAcess.Connect.ExecSQL(sql_del);
            if(ok)
            {
                sql_del = "delete from benhnhannoitru where idnoitru ='"+idnoitruXoa+"' and isnull(isnhapkhoa,0)=0 ";
                ok = DataAcess.Connect.ExecSQL(sql_del);
                if (ok)
                {
                    Response.Clear(); Response.Write(idnoitruXoa);
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    
    #region Functions Call
    #region Thông tin Danh sách bệnh nhân chờ
    private string DanhSachBenhNhanCho(DataTable table)
    {
        string html = "Không tìm thấy bệnh nhân";
        if (table != null && table.Rows.Count > 0)
        {
            html = "<table class='jtable' id=\"gridTabledskb\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th></th>";
            html += "<th>Mã bệnh nhân</th>";
            html += "<th>Tên bệnh nhân</th>";
            //html += "<th>Địa chỉ</th>";
            html += "<th>Giới</th>";
            html += "<th>NS</th>";
            html += "<th>Khám</th>";
            html += "<th>Ngày nhập viện</th>";
            html += "<th></th>";
            html += "</tr>";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr >";//onclick=\"SetBenhNhanDangKham('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idchitietdangkykham"].ToString() + "');\"
                html += "<td>" + (i + 1) + "</td>";//table.Rows[i]["stt"].ToString()

                html += "<td><input type='button' value='Chọn' style='width:50px;height:23px;color:Blue;background-image:none'  onclick=\"SetBenhNhanDangKham('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idchitietdangkykham"].ToString() + "');\"/></td>";
                html += "<td>" + table.Rows[i]["MaBenhNhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["TenBenhNhan"].ToString() + "</td>";
                //html += "<td>" + table.Rows[i]["DiaChi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["Gioi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["namsinh"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["LoaiKham"].ToString() + "</td>";

                if (table.Columns.IndexOf("ngaynhapvien") != -1)
                {
                    html += "<td>" + DateTime.Parse(table.Rows[i]["ngaynhapvien"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>";
                }
                else
                {
                    if (table.Rows[i]["ngaydangky"].ToString() != "")
                    {
                        html += "<td>" + DateTime.Parse(table.Rows[i]["ngaydangky"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>";
                    }
                    else { html += "<td>" + table.Rows[i]["ngaydangky"].ToString() + "</td>"; }
                }
                if (table.Rows[i]["isTamTheoDoi"].ToString().Equals("1"))
                {
                    html += "<td><a onclick=\"HuyTheoDoi(" + table.Rows[i]["idchitietdangkykham"].ToString() + "," + table.Rows[i]["idkhoanoitru"].ToString() + ")\">Loại khỏi DS</a></td>";
                }
                else
                    html += "<td></td>";
                html += "</tr>";
            }

            html += "</table>";
        }
        return html;
    }
    #endregion
    #region Thông tin Tạm ứng
    private string ThongTinTamUng(DataTable table, string idkhoa)
    {
        string html = "";
        int stt = 0;
        html = "<table class='jtable' id=\"gridTableTamUng\">";
        html += "<tr>";
        html += "<th >STT</th>";
        html += "<th>In phiếu TU</th>";
        html += "<th>Sửa</th>";
        html += "<th>Xóa</th>";
        //nv/html += "<th>Tạm ứng mới</th>";
        html += "<th>Mã Phiếu</th>";
        html += "<th>Ngày xét tạm ứng</th>";//MAPHIEU_TU
        html += "<th>Số tiền</th>";
        //html += "<th>Lần TU</th>";
        //html += "<th>Khoa TU</th>";
        html += "<th>Đã thu ?</th>";
        //html += "<th>Đã hoàn ứng ?</th>";
        html += "</tr>";
        DataView dvTempt = new DataView(table.Copy());
        //dvTempt.RowFilter = "idkhoaTU <>" + idkhoa + "";
        //DataTable dtKhacKhoa = dvTempt.ToTable();
        //if (dtKhacKhoa.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dtKhacKhoa.Rows.Count; i++)
        //    {
        //        html += "<tr>";
        //        html += "<td>" + (i + 1) + "</td>";
        //        html += "<td ></td>";
        //        html += "<td ></td>";
        //        html += "<td ></td>";
        //        //nv/html += "<td ></td>";
        //        html += "<td>" + dtKhacKhoa.Rows[i]["MAPHIEU_TU"] + "</td>";
        //        html += "<td>" + dtKhacKhoa.Rows[i]["ngayTU"] + "</td>";
        //        html += "<td>" + StaticData.FormatNumberOption(dtKhacKhoa.Rows[i]["sotien"], ",", ".", false) + "</td>";
        //        html += "<td>" + dtKhacKhoa.Rows[i]["lantamung"] + "</td>";
        //        html += "<td>" + dtKhacKhoa.Rows[i]["tenphongkhambenh"] + "</td>";
        //        html += "<td>" + dtKhacKhoa.Rows[i]["TinhTrangThu"] + "</td>";
        //        html += "<td>" + dtKhacKhoa.Rows[i]["nvk_ttHU"] + "</td>";
        //        html += "</tr>";
        //        stt++;
        //    }
        //}
        dvTempt.RowFilter = "idkhoaTU =" + idkhoa + "";
        DataTable dtKhoa = dvTempt.ToTable();
        if (dtKhoa.Rows.Count > 0)
        {
            for (int i = 0; i < dtKhoa.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (stt + i + 1) + "</td>";
                html += "<td ><a id='linkIN' onclick='InPhieuTamUng(" + dtKhoa.Rows[i]["idtamung"] + ")'>In phiếu TU</a></td>";
                if (dtKhoa.Rows[i]["TinhTrangThu"].ToString().Equals("Đã thu"))
                {
                    html += "<td ></td>";
                    html += "<td ></td>";
                }
                else
                {
                    html += "<td ><a id='linkSua' onclick='view_tamung(" + dtKhoa.Rows[i]["idtamung"] + ")'>Sửa</a></td>";
                    html += "<td ><a id='linkXoaTU' onclick='XoaPhieuTamUng(" + dtKhoa.Rows[i]["idtamung"] + ")'>Xóa TU</a></td>";
                }
                //nv/html += "<td >";
                //nv/if (i == dtKhoa.Rows.Count - 1)
                //nv/    html += "<a id='linkTU' onclick='tamung(0,0)'>Tạm ứng</a>";
                //nv/html += "</td>";
                html += "<td>" + dtKhoa.Rows[i]["MAPHIEU_TU"] + "</td>";
                html += "<td>" + dtKhoa.Rows[i]["ngayTU"] + "</td>";
                html += "<td align='right'>" + StaticData.FormatNumberOption(dtKhoa.Rows[i]["sotien"], ",", ".", false) + "</td>";
                //html += "<td>" + dtKhoa.Rows[i]["lantamung"] + "</td>";
                //html += "<td>" + dtKhoa.Rows[i]["tenphongkhambenh"] + "</td>";
                html += "<td>" + dtKhoa.Rows[i]["TinhTrangThu"] + "</td>";
                //html += "<td>" + dtKhoa.Rows[i]["nvk_ttHU"] + "</td>";
                html += "</tr>";
            }
        }
        #region Trường hợp bệnh nhân chưa tạm ứng (tại khoa) bao giờ
        //if (dtKhoa.Rows.Count == 0)
        //{
        //    html += "<tr>";
        //    html += "<td>1</td>";
        //    html += "<td ></td>";
        //    html += "<td ></td>";
        //    //nv/html += "<td ></td>";
        //    html += "<td ><a id='linkTU' onclick='tamung(0,0)'>Tạm ứng</a></td>";
        //    html += "<td></td>";
        //    html += "<td></td>";
        //    html += "<td></td>";
        //    html += "<td></td>";
        //    html += "<td></td>";
        //    html += "<td></td>";
        //    //html += "<td></td>";
        //    html += "</tr>";
        //}
        #endregion
        //html += "<tr>";
        //html += "<td colspan='8' id='tdPopup' align='center'>tdPopup Show</td>";
        //html += "</tr>";
        html += "</table>";
        return html;
    }
    #endregion
    #region thông tin công nợ
    private void nvk_loadChiTietCongNoBenhNhan()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string idctdkk = Request.QueryString["idctdkk"];
        bool IsShowTamUng = false;
        if (Request.QueryString["IsShowTamUng"] != null && Request.QueryString["IsShowTamUng"].ToString().Equals("1"))
            IsShowTamUng = true;
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append(nvk_ThongTinCongNoBenhNhan(idkhoa,idctdkk,IsShowTamUng));
        Response.Clear();
        Response.Write(html);
    }
    private string nvk_ThongTinCongNoBenhNhan(string idkhoa, string idchitietdangkykham,bool isTamUng)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        #region sql command công nợ ///
//        string sql = @"
//        select *,nvk_phatsinh=isnull(phatsinh,0),nvk_thanhtoan=isnull(thanhtoan,0)  from (
//        (	select 
//		        convert(varchar(10),NGAYDANGKY,103)+' '+ convert(varchar(8),NGAYDANGKY,108) AS NgayCT103
//		        ,NGAYDANGKY AS NGAYCT
//		        ,'' as SoCT
//		        ,N'Phí khám' as NoiDung
//		        ,A.BNTongPhaiTra as PhatSinh
//		        ,(SELECT SUM(TONGTIEN) FROM HS_DSDATHU WHERE IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM AND LOAITHU='PHIKHAM') as ThanhToan
//	        from CHITIETDANGKYKHAM A
//           LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
//	        WHERE A.IDCHITIETDANGKYKHAM='" + idchitietdangkykham + @"' and isnull(a.isnotthuphicapcuu,0)=0
//        )
//        UNION ALL
//        (
//          SELECT DISTINCT 
//		        convert(varchar(10),NGAYTHU,103)+' '+ convert(varchar(8),NGAYTHU,108) AS NgayCT103
//	         ,NGAYTHU AS NGAYCT
//	         ,MAPHIEUCLS AS SOCT
//	         ,C.TENDICHVU AS NOIDUNG
//	         ,SUM(A.BNTongPhaiTra) AS PHATSINH
//	         ,SUM(E.TONGTIEN) AS THANHTIEN
//	        FROM KHAMBENHCANLAMSAN A
//	        LEFT JOIN KHAMBENH B ON A.IDKHAMBENH=B.IDKHAMBENH
//            LEFT JOIN BANGGIADICHVU C ON A.IDCANLAMSAN=C.IDBANGGIADICHVU
//	        LEFT JOIN PHONGKHAMBENH D ON C.IDPHONGKHAMBENH=D.IDPHONGKHAMBENH
//	        LEFT JOIN HS_DSDATHU E ON A.IDKHAMBENHCANLAMSAN=E.IDKHAMBENHCANLAMSAN
//            WHERE B.IDCHITIETDANGKYKHAM='" + idchitietdangkykham + @"'
//          GROUP BY NGAYTHU,MAPHIEUCLS,C.TENDICHVU
//        )
//        UNION ALL
//        (
//            SELECT DISTINCT  
//		        convert(varchar(10),NGAYTHANG_XUAT,103)+' '+ convert(varchar(8),NGAYTHANG_XUAT,108) AS NgayCT103
//		        ,NGAYTHANG_XUAT AS NGAYCT
//		           ,'' AS SOCT
//		           ,TENTHUOC AS  NOIDUNG
//		           ,SUM( (CASE WHEN ISBHYT=1 THEN BNTra ELSE THANHTIENDV END )) AS PHATSINH
//		           ,(SELECT TONGTIEN FROM HS_DSDATHU WHERE IDPHIEUXUAT=A.IDPHIEUXUAT AND IDTHUOC=A.IDTHUOC AND NLOAITHU=3) AS THANHTOAN
//              FROM CHITIETPHIEUXUATKHO A
//	          LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
//	          left join chitietbenhnhantoathuoc ct on ct.idchitietbenhnhantoathuoc = a.idchitietbenhnhantoathuoc
//	          LEFT JOIN KHAMBENH C ON ct.IDKHAMBENH=C.IDKHAMBENH
//	          WHERE C.IDCHITIETDANGKYKHAM='" + idchitietdangkykham + @"' and ct.doituongthuocid <> 3
//             GROUP BY NGAYTHANG_XUAT,TENTHUOC,A.IDPHIEUXUAT,A.IDTHUOC
//        )
//        UNION ALL
//        (
//           SELECT  
//		        convert(varchar(10),DENNGAY,103)+' '+ convert(varchar(8),DENNGAY,108) AS NgayCT103
//	         ,DENNGAY AS NGAYCT
//	        ,'' AS SOCT
//            ,GiuongCode AS NOIDUNG
//	        ,(CASE WHEN ISBHYT=1 THEN BNTRA ELSE THANHTIENDV END ) AS PHATSINH
//	        ,0 AS THANHTIEN
//          FROM KB_CHITIETGIUONGBN A
//           LEFT JOIN KB_GIUONG B ON A.IdGiuong=B.GiuongId
//           WHERE A.IDCHITIETDANGKYKHAM='" + idchitietdangkykham + @"'
//        )
//        UNION ALL
//        (
//          SELECT  
//		        convert(varchar(10),SYSDATE,103)+' '+ convert(varchar(8),SYSDATE,108) AS NgayCT103
//	         ,SYSDATE AS NGAYCT
//	        ,MAPHIEU AS SOCT
//	        ,TENDICHVU AS NOIDUNG
//            ,0 AS PHATSINH
//            ,TONGTIEN AS THANHTOAN
//        FROM HS_DSDATHU 
//        WHERE IDCHITIETDANGKYKHAM='" + idchitietdangkykham + @"'
//	        AND LOAITHU IN ('TAMUNG','CHENHLECHBHYT')
//        )
//        ) as nvk order by ngayct";
        #endregion

        string sql = "select * from [dbo].[hs_CongNoBenhNhan]('" + idchitietdangkykham + "') order by ngayct asc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (isTamUng)
        {
            #region sql danh sách tạm ứng cũ
            string sql_TU = @"select row_number() over(order by idtamung) as stt
                ,ct.sophieuCT,ct.sodangky,ct.quyenso,tu.idtamung,ngayTU=convert(varchar(10),tu.ngaytamung,103)+' '+convert(varchar(5),tu.ngaytamung,108)
                ,tu.sotien
                ,case when isdathu=1 then N'Đã thu' else N'Chưa thu' end as TinhTrangThu
                ,lantamung=isnull((select count(idtamung) from tamung where isnull(soctHU,'')='' and idtamung <=tu.idtamung and iddangkykham=tu.iddangkykham),1)
                ,tu.idkhoaTU,p.tenphongkhambenh,tu.MAPHIEU_TU
                ,case when isnull(tu.SoTienHU,0)>0 then N'Đã hoàn ứng' else N'' end as nvk_ttHU

                 from tamung tu left join sochungtu ct on ct.STT=tu.SoCTTU left join phongkhambenh p on p.idphongkhambenh=tu.idkhoaTU  where isnull(soctHU,'')='' and iddangkykham=" + idchitietdangkykham + @"
                        ";
            DataTable table_TU = DataAcess.Connect.GetTable(sql_TU);
            html.Append(@"<fieldset><legend>Chi Tiết Tạm Ứng</legend>
                <div class='div-Out' style='height:auto;width:96%'>");
            html.Append(ThongTinTamUng(table_TU, idkhoa));
            html.Append(@"</div>
                </fieldset>");
            #endregion
        }
        html.Append(@"<fieldset><legend>Công nợ bệnh nhân</legend>
        <div class='div-Out' style='height:auto;width:96%;text-align:left'>
        <div style='height:auto;width:100%'>");
        html.Append(nvk_tableCongNoBenhNhan(table, idkhoa, idchitietdangkykham,isTamUng));
        html.Append(@"</div></div>
        </fieldset>");

        string nvk_TenbangKe = "MẪU 02";
        if (idkhoa.Equals(StaticData.GetParameter("nvk_idkhoacapcuu")) || idkhoa.Equals(StaticData.GetParameter("nvk_idphongtansoi")))
        {
            nvk_TenbangKe = "Bảng kê CP";
        }
        html.Append(@"
        <div style='text-align:center;height:auto;width:96%'>
            <input id='btnMau02' type='button' value='"+nvk_TenbangKe+ @"' style='width:90px' onclick='btnMau02_click()'/>
            <input id='btnHaoPhi' type='button' value='Tổng hợp hao phí' style='width:150px'  onclick='btnMauHaoPhi_click()'/>
            <input id='btnDongChiTra' type='button' value='Bảng kê ĐCT' style='width:150px'  onclick='btnDongChiTra_click()'/>
            
        </div>");
        //<input id='btnXemHSBA' type='button' value='XEM HSBA' style='width:100px'  onclick='btnXemHSBA_click()'/>
        //<input id='btnInHSBA' type='button' value='IN HSBA' style='width:90px'  onclick='btnInHSBA_click()'/>
        return html.ToString();
    }
    private string nvk_tableCongNoBenhNhan(DataTable table, string idkhoa, string idchitietdangkykham, bool isTamUng)
    {
        string html = "";
        int stt = 0;
        html = "<table class='jtable'  style='border-width:medium' rules='all' id=\"gridTableTamUng\">";//class='jtable' 
        html += "<tr style='background: #CAE3FF;color:Blue'  align='center'>";
        html += "<th ><span style='color: white; font-weight: bold' class='Tieude'>Ngày</span></th>";
        html += "<th><span style='color: white; font-weight: bold' class='Tieude'>Số chứng từ</span></th>";
        html += "<th><span style='color: white; font-weight: bold' class='Tieude'>Nội dung</span></th>";
        html += "<th><span style='color: white; font-weight: bold' class='Tieude'>Phát sinh</span></th>";
        html += "<th><span style='color: white; font-weight: bold' class='Tieude'>Thanh toán</span></th>";
        html += "<th><span style='color: white; font-weight: bold' class='Tieude'>Còn lại</span></th>";//#0000cc (xanh)
        html += "<th><span style='color: white; font-weight: bold' class='Tieude'>Khoa</span></th>";//#0000cc (xanh)
        html += "</tr>";
        #region chi tiết công nợ 
        double TongPhatSinh = 0;
        double TongThanhToan = 0;
        double CongNoConLai = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            double PhatSinh_i = double.Parse(table.Rows[i]["nvk_phatsinh"].ToString());
            double ThanhToan_i = double.Parse(table.Rows[i]["nvk_thanhtoan"].ToString());
            double hieuSo_i = PhatSinh_i - ThanhToan_i;
            TongPhatSinh += PhatSinh_i;
            TongThanhToan += ThanhToan_i;
            CongNoConLai = CongNoConLai + hieuSo_i;
            html += "<tr>";
            #region màu nội dung
            string str_NoiDung = table.Rows[i]["NoiDung"].ToString();
            if (str_NoiDung.ToLower().Trim().Equals("tạm ứng"))
            {
                str_NoiDung = "<span style='color: #0000cc; font-weight: bold'>" + table.Rows[i]["NoiDung"] + "</span>";
                html += "<td align='center'><span style='color: #0000cc; font-weight: bold'>" + DateTime.Parse( table.Rows[i]["NGAYCT"].ToString()).ToString("dd/MM HH:mm") + "</span></td>";
                html += "<td align='center'><span style='color: #0000cc; font-weight: bold'>" + table.Rows[i]["SoCT"] + "</span></td>";
                html += "<td >" + str_NoiDung + "</td>";
                html += "<td align='right'><span style='color: #0000cc; font-weight: bold'>" + StaticData.FormatNumberOption(table.Rows[i]["nvk_phatsinh"], ",", ".", false) + "</span></td>";
                html += "<td align='right'><span style='color: #0000cc; font-weight: bold'>" + StaticData.FormatNumberOption(table.Rows[i]["nvk_thanhtoan"], ",", ".", false) + "</span></td>";
                html += "<td align='right'><span style='color: #0000cc; font-weight: bold'>" + StaticData.FormatNumberOption(CongNoConLai, ",", ".", false) + "</span></td>";
                html += "<td align='left'><span style='color: #0000cc; font-weight: bold'>" + table.Rows[i]["khoa"] + "</span></td>";
            }
            else
            {
                html += "<td align='center'>" + DateTime.Parse( table.Rows[i]["NGAYCT"].ToString()).ToString("dd/MM HH:mm") + "</td>";
                html += "<td align='center'>" + table.Rows[i]["SoCT"] + "</td>";
                html += "<td >" + str_NoiDung + "</td>";
                html += "<td align='right'>" + StaticData.FormatNumberOption(table.Rows[i]["nvk_phatsinh"], ",", ".", false) + "</td>";
                html += "<td align='right'>" + StaticData.FormatNumberOption(table.Rows[i]["nvk_thanhtoan"], ",", ".", false) + "</td>";
                html += "<td align='right'>" + StaticData.FormatNumberOption(CongNoConLai, ",", ".", false) + "</td>";
                html += "<td >" + table.Rows[i]["khoa"] + "</td>";
            }
            #endregion
            html += "</tr>";
        }
        #endregion

        #region dòng tổng cộng

        html += "<tr>";
            html += "<td colspan='3' align='right' ><span style='color: #0000cc; font-weight: bold' class='Tieude'>Tổng cộng</span></td>";
            html += "<td align='right'><span style='color: Black; font-weight: bold'>" + StaticData.FormatNumberOption(TongPhatSinh, ",", ".", false) + "</span></td>";
            html += "<td align='right'><span style='color: #0000cc; font-weight: bold'>" + StaticData.FormatNumberOption(TongThanhToan, ",", ".", false) + "</span></td>";
            html += "<td align='right'><span style='color: Red; font-weight: bold'>" + StaticData.FormatNumberOption(CongNoConLai, ",", ".", false) + "</span></td>";
            html += "<td></td>";
            html += "</tr>";
        #endregion

            if (isTamUng)
            {
                #region tạm ứng mới
                string sqlSoLan = @"select COUNT(distinct IDTamUng)+1
                from tamUng tu where tu.iddangkykham='" + idchitietdangkykham + "'  and idkhoatu='"+idkhoa+"'";
                DataTable SoLan = DataAcess.Connect.GetTable(sqlSoLan);
                string strSoLan = "1";
                if (SoLan.Rows.Count > 0)
                    strSoLan = SoLan.Rows[0][0].ToString();
                else
                    strSoLan = "1";
                html += "<tr align='center'>";
                html += "<td colspan='6' style='height=20px;'></td>";
                html += "</tr>";
                html += "<tr align='center'>";
                html += "<td style=''><span style='color: #0000cc; font-weight: bold' align='center' >Tạm ứng lần " + strSoLan + "</span></td>";
                html += "<td colspan='6' valign='top'><span style='color: #0000cc; font-weight: bold' align='center' >Số tiền:</span>&nbsp; &nbsp;";
                if (idkhoa == StaticData.GetParameter("nvk_idkhoacapcuu"))
                    html += "<select id=\"txtSoTien\" style=\"width: 100px\">"
                          + "<option value=\"1000000\">1,000,000</option>"
                          + "<option value=\"2000000\">2,000,000</option>"
                          + "<option value=\"3000000\">3,000,000</option>"
                          + "<option value=\"4000000\">4,000,000</option>"
                          + "<option value=\"5000000\">5,000,000</option>"
                        + "</select>";
                else
                    html += "<input type=\"text\"  onchange='nvk_formatNumBer(this)'  style=\"width: 80px\" id=\"txtSoTien\"/>";
                html += "&nbsp; &nbsp;<span style='color: #0000cc; font-weight: bold' align='center' >Lý do tam ứng:</span> &nbsp; &nbsp;<input type=\"text\" value=\"Chỉ định tạm ứng\" style=\"width: 350px\" id=\"txtLyDo\"/>";
                html += "&nbsp; &nbsp;<input type=\"button\" id=\"btnTU\" value=\"Lưu Tạm Ứng\"  style='width:130px'  onclick=\"luuTU(" + idchitietdangkykham + ",0);\"/></td>";/////
                html += "</tr>";
                #endregion
            }
            html += "<tr>";
            html += "<td colspan='7' id='tdPopup' align='center'></td>";
            html += "</tr>";
        html += "</table>";
        return html;
    }
    #endregion
    #region Thông tin giường bệnh before 25_09 ///
    private string ThongTinTienGiuong(string idbenhnhan, string IdCTDKK, string idkhoa)
    {
        string html = @"";
        // table Tiền giường
        #region tableTiền giường
        #region Danh sách giuong da nằm KHÔNG DÙNG
        //        string sqlChiTietGiuong = @"select * from (
        //select *,sogio=convert(float,DATEDIFF(hh,tungay,denngay))
        //                ,thanhtien=round(convert(float,DATEDIFF(hh,tungay,denngay))*giagiuong/24,2) from 
        //                (
        //                select nt.idnoitru,giuong=g.giuongcode+' - '+isnull(p.tenphong,''),nt.Giagiuong,tungay=nt.ngayvaovien
        //                ,denngay=isnull((select top 1 ngayvaovien from benhnhannoitru where idchitietdangkykham=nt.idchitietdangkykham and ngayvaovien>nt.ngayvaovien order by ngayvaovien),getdate())
        //                ,tenkhoa=k.tenphongkhambenh
        //                 from benhnhannoitru nt left join kb_phong p on p.id=idphongnoitru
        //                left join kb_giuong g on g.giuongid=idgiuong left join phongkhambenh k on k.idphongkhambenh=nt.idkhoanoitru
        //                where nt.idchitietdangkykham=" + IdCTDKK + @" 
        //                ) as abc --order by tungay
        //
        //union all
        //select *,sogio=convert(float,DATEDIFF(hh,tungay,denngay))
        //                ,thanhtien=round(convert(float,DATEDIFF(hh,tungay,denngay))*thanhtien/24,2) from 
        //                (
        //                select idnoitru=nt.idgiuong,giuong=g.giuongcode+' - '+p.tenphong,nt.thanhtien,tungay=nt.ngayxetgiuong
        //                ,denngay=isnull((select top 1 ngayvaovien from benhnhannoitru where idchitietdangkykham=nt.idchitietdangkykham and ngayvaovien>nt.ngayxetgiuong order by idnoitru),getdate())
        //                ,tenkhoa=N'Cấp cứu'
        //                 from kb_giuongphieuthanhtoan nt
        //left join kb_giuong g on nt.idgiuongxet=g.giuongid
        // left join kb_phong p on p.id=g.idphong
        //
        //                where nt.idchitietdangkykham=" + IdCTDKK + @" 
        // ) as abc
        //) as cba order by tungay
        //";
        #endregion
        string sqlChiTiet = @"
            select distinct ngay1=convert(varchar(10),isnull(b.tungay,a.ngay),103),gio1=convert(varchar(5),isnull(b.tungay,a.ngay),108)
		            ,DenNgay1=convert(varchar(10),isnull(b.denngay,a.denngay),103),dengio1=convert(varchar(5),isnull(b.denngay,a.denngay),108)
		            ,a.khoa,a.idkhoa,a.ngay,a.denngay,a.tiengiuongnamnhieunhat,a.idnoitrunamnhieunhat,a.tengiuong,a.idgiuong,songay,a.thanhtien
		            ,b.*
             from dbo.NVK_TableKetQuaGiuong(" + IdCTDKK + @") a  left join KB_ChiTietGiuongBN b on b.idnoitru_G = a.idnoitrunamnhieunhat
             order by a.ngay";
        DataTable dt = DataAcess.Connect.GetTable(sqlChiTiet);
        #endregion
        // tableChuyeGiuong
        #region tableChuyeGiuong
        string sqlTBchuyenG = @"
select * from (
select idnoitru,idphongkhambenh,tenphongkhambenh,NgayVaoGiuong=convert(varchar(10),nt.ngayvaovien,103)+' '+convert(varchar(5),nt.ngayvaovien,108),ngayvaovien
	,nt.IdPhongNoiTru,tenphong,nt.IdGiuong,GiuongCode,nt.GiaGiuong,isGiuongCapCuu=0
from benhnhannoitru nt left join phongkhambenh k on k.idphongkhambenh= nt.IdKhoaNoiTru
	left join kb_phong p on p.id=nt.IdPhongNoiTru
	left join kb_giuong g on g.GiuongId=nt.IdGiuong
where idchitietdangkykham =" + IdCTDKK + @" and isnull(nt.idphongnoitru,0)<>0 and isnull(nt.idgiuong,0)<>0
)as abc order by ngayvaovien 
        ";
        DataTable tbChuyenGiuong = DataAcess.Connect.GetTable(sqlTBchuyenG);
        #endregion
        if (dt != null)
        {
            //DataTable dtGiuong = DataAcess.Connect.GetTable(sqlChiTietGiuong);
            //if (dtGiuong != null)
            //{
            //}
            #region Load danh sách ngày nhiều giường
            string ListGiuongHtml = "";
            string sqlNgayG = @"select distinct convert(varchar(10),ngay,103) as ngay1,ngay from
                            (
                            select  ngay  from NVK_ListNgayTinhGiuong(" + IdCTDKK + @") 
                            ) as abc where isnull((select count(*) from dbo.NVK_ListGiuongBN_Ngay(" + IdCTDKK + @",ngay)),0)>1 order by ngay asc";
            DataTable dtNgayG = DataAcess.Connect.GetTable(sqlNgayG);
            if (dtNgayG.Rows.Count > 0)
            {
                for (int i = 0; i < dtNgayG.Rows.Count; i++)
                {
                    ListGiuongHtml += @"<input type='button' id='ngay_" + (i + 1) + "' style='width:100px' runat='server' onclick='Ngay_click(this)' value='" + dtNgayG.Rows[i]["ngay1"].ToString() + @"' style='background-color:Blue ! important' />";
                }
            }
            html = @"<div id='divCenter' style='text-align:center'>";
            html += tableChuyenGiuong(tbChuyenGiuong, idkhoa, IdCTDKK);
            html += "</div>";
            html += @"
                <div id='divNgayNhieuGiuong' style='text-align:center'>";
            html += ListGiuongHtml;
            html += @"</div>
                <div id='divCenter1' style='text-align:center'>
                <div id='divChiTietGiuongNgay' style='display:none;top:20%;bottom:50%;left:35%;width:30%;background-color:white;z-index:1001;padding:5px 5px 5px 5px;border:10px solid black;text-align:center'></div>
                </div>
                <div id='tableAjax_EditTienGiuong' style='text-align:center'>";
            #endregion
            html += tabletienGiuong(dt);
            html += "</div>";
            if (dt != null && dt.Rows.Count > 0)
            {
                html += @"<div id='divCenter2' style='text-align:center'>
<input type='button' id='CapNhatGiuong' style='width:130px' onclick='luuNoiDungGiuong(" + idbenhnhan + "," + IdCTDKK + "," + idkhoa + @");' value='Lưu bảng giường' />
                </div>";
            }
        }
        else
        {
        }
        return html;
    }
    private string tableChuyenGiuong(DataTable table, string idkhoa, string idChiTietDKK)
    {
        string html = "";
        html += "<table class='jtable' id=\"TableChuyenGiuong\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>Sửa giường</th>";
        html += "<th>Chuyển giường</th>";
        html += "<th>Ngày vào nằm</th>";
        html += "<th>Khoa</th>";
        html += "<th>Phòng</th>";
        html += "<th>Giường</th>";
        html += "<th>Đơn giá</th>";
        html += "</tr>";
        DataView dvTempt = new DataView(table.Copy());
        dvTempt.RowFilter = "idphongkhambenh <>" + idkhoa + "";
        DataTable dtKhacKhoa = dvTempt.ToTable();
        int stt = 0;
        if (dtKhacKhoa.Rows.Count > 0)
        {
            for (int i = 0; i < dtKhacKhoa.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (stt + i + 1) + "</td>";
                html += "<td ></td>";
                html += "<td ></td>";
                html += "<td>" + dtKhacKhoa.Rows[i]["NgayVaoGiuong"] + "</td>";
                html += "<td>" + dtKhacKhoa.Rows[i]["tenphongkhambenh"] + "</td>";
                html += "<td>" + dtKhacKhoa.Rows[i]["tenphong"] + "</td>";
                html += "<td>" + dtKhacKhoa.Rows[i]["GiuongCode"] + "</td>";
                html += "<td>" + StaticData.FormatNumberOption(dtKhacKhoa.Rows[i]["GiaGiuong"], ",", ".", false) + "</td>";
                html += "</tr>";
                stt++;
            }
        }
        dvTempt.RowFilter = "idphongkhambenh =" + idkhoa + "";
        DataTable dtKhoa = dvTempt.ToTable();
        if (dtKhoa.Rows.Count > 0)
        {
            for (int i = 0; i < dtKhoa.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (stt + i + 1) + "</td>";
                html += "<td ><a onclick='SuaGiuong(this," + idkhoa + "," + dtKhoa.Rows[i]["idnoitru"] + "," + idChiTietDKK + ")'>Sửa</a></td>";
                html += "<td >";
                if (i == dtKhoa.Rows.Count - 1)
                    html += "<a id='linkThemGiuong' onclick='ThemGiuong(this," + idChiTietDKK + "," + idkhoa + ")'>Giường mới</a>";
                html += "</td>";
                html += "<td>" + dtKhoa.Rows[i]["NgayVaoGiuong"] + "</td>";
                html += "<td>" + dtKhoa.Rows[i]["tenphongkhambenh"] + "</td>";
                html += "<td>" + dtKhoa.Rows[i]["tenphong"] + "</td>";
                html += "<td>" + dtKhoa.Rows[i]["GiuongCode"] + "</td>";
                html += "<td>" + StaticData.FormatNumberOption(dtKhoa.Rows[i]["GiaGiuong"], ",", ".", false) + "</td>";
                html += "</tr>";
                stt++;
            }
        }
        #region Trường hợp bệnh nhân chưa có giường
        if (dtKhoa.Rows.Count == 0)
        {
            html += "<tr>";
            html += "<td>1</td>";
            html += "<td ></td>";
            html += "<td ><a onclick='ThemGiuong(this," + idChiTietDKK + "," + idkhoa + ")'>Giường mới</a></td>";
            html += "<td></td>";
            html += "<td></td>";
            html += "<td></td>";
            html += "<td></td>";
            html += "<td></td>";
            html += "</tr>";
        }
        #endregion
        html += "<tr><td colspan='8' id='tdPopupTG' align='center'>tdPopup Show</td></tr>";
        html += "</table>";
        return html;
    }
    private string tabletienGiuong(DataTable dt)
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
        if (dt != null && dt.Rows.Count != 0)
        {
            double tongTienTable = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["tiengiuongnamnhieunhat"].ToString().Equals(""))
                    continue;
                html += "<tr>";
                html += "<td>" + (i + 1) + "</td>";
                //html += "<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input mkv='true' id='idkhoa' type='hidden' value='" + dt.Rows[i]["idkhoa"] + "' /><input mkv='true' id='mkv_idkhoa' type='text' style='width:80px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["khoa"] + "' /></td>";
                html += @"<td>
                        <input mkv='true' id='tungay' type='text' style='width:80px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["Ngay1"] + @"' onfocus='chuyenphim(this);$(this).datepick();' onblur='nvk_testDate_this(this);'  />
                        <input mkv='true' id='tugio' type='text' style='width:35px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["Gio1"] + @"' />
                    </td>";
                html += @"<td>
                        <input mkv='true' id='denngay' type='text' style='width:80px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["DenNgay1"] + @"' onfocus='chuyenphim(this);$(this).datepick();' onblur='nvk_testDate_this(this);'  />
                        <input mkv='true' id='dengio' type='text' style='width:35px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["dengio1"] + @"' />
                    </td>";
                html += "<td><input mkv='true' id='idGiuong' type='hidden' value='" + dt.Rows[i]["idgiuong"] + "' /><input mkv='true' id='mkv_idGiuong' type='text' onfocus='chuyenphim(this);idGiuongsearch(this)' value='" + dt.Rows[i]["tengiuong"] + "' class='down_select'/></td>";

                html += "<td><input mkv='true' id='dongia' type='text' style='width:80px;text-align:right' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);thanhtienTableGiuong(this);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["tiengiuongnamnhieunhat"], ",", ".", false) + "' /></td>";
                html += "<td><input mkv='true' id='songay' type='text' style='width:50px;text-align:center' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);thanhtienTableGiuong(this);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["songay"], ",", ".", false) + "' /></td>";
                html += @"<td>
                    <input mkv='true' id='thanhtien' disabled='disabled' type='text' style='width:80px;text-align:right' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["thanhtien"], ",", ".", false) + @"' />
                    <input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[i]["idnoitrunamnhieunhat"] + @"'/>
                    <input mkv='true' id='idtien_" + (i + 3) + "' type='hidden' value='" + dt.Rows[i]["thanhtien"] + @"'/>";

                #region thông tin lưu bảng KB_ChiTietGiuongBN
                html += @"<input mkv='true' id='IdChiTietGiuongBN' type='hidden' value='" + dt.Rows[i]["IdChiTietGiuongBN"] + @"'/>
                    <input mkv='true' id='tungaygiuong' type='hidden' value='" + dt.Rows[i]["ngay"] + @"'/>
                    <input mkv='true' id='denngaygiuong' type='hidden' value='" + dt.Rows[i]["denngay"] + @"'/>";
                #endregion
                html += @"</td>";
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
    #endregion

    #region thông tin giường bệnh new
    private string ThongTinTienGiuong_2509(string idbenhnhan, string IdCTDKK, string idkhoa, string isTinhLai)
    {
        string html = @"";
        string ListGiuongHtml = "";
        // table Tiền giường
        #region tableTiền giường
        string sqlChiTiet = "";
        DataTable dt = new DataTable();
        if (isTinhLai != null && isTinhLai.Equals("1"))
        {
            string del_kb_chitietgiuong = "delete from kb_chitietgiuongbn where idchitietdangkykham ='"+IdCTDKK+"' and idkhoa ='"+idkhoa+"'";
            bool kt = DataAcess.Connect.ExecSQL(del_kb_chitietgiuong);
        }
        else
        {
            sqlChiTiet = @"
select distinct a.tungay,ngay1=convert(varchar(10),a.tungay,103),gio1=convert(varchar(5),a.tungay,108)
		            ,DenNgay1=convert(varchar(10),a.denngay,103),dengio1=convert(varchar(5),a.denngay,108)
					,khoa= tenphongkhambenh,a.idkhoa,idnoitru=idnoitru_G,tengiuong=g.giuongcode+' - '+p.tenphong,a.idgiuong,songay=a.sl
                    ,nvk_giadichvu=a.DonGiaDV,nvk_GiaBaoHiem=a.DonGiaBH,nvk_isBHYT= convert(int,IsBHYT)
                    ,nvk_loaibn=isnull(
	                        (select top 1 dk.loaikhamid from dangkykham dk 
											                        inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                          where ct.idchitietdangkykham ='" + IdCTDKK + @"'
	                        )
                        ,0) 
                    ,nvk_isnhapkhoa=isnull((select top 1 convert(int,isnhapkhoa) from benhnhannoitru where idnoitru =a.idnoitru_G),0)
                    ,strDaLuu=N'Đã lưu'
from KB_ChiTietGiuongBN a inner join kb_giuong g on g.giuongid=a.idgiuong
		inner join kb_phong p on p.id=g.idphong
		inner join phongkhambenh k on k.idphongkhambenh = a.idkhoa
where a.idchitietdangkykham='" + IdCTDKK + "' order by a.tungay";
            dt = DataAcess.Connect.GetTable(sqlChiTiet);
        }
        if (dt == null || dt.Rows.Count == 0)
        {
            sqlChiTiet = @"
            select distinct ngay1=convert(varchar(10),isnull(b.tungay,a.ngay),103),gio1=convert(varchar(5),isnull(b.tungay,a.ngay),108)
		            ,DenNgay1=convert(varchar(10),isnull(b.denngay,a.denngay),103),dengio1=convert(varchar(5),isnull(b.denngay,a.denngay),108)
		            ,a.khoa,a.idkhoa,idnoitru=a.idnoitrunamnhieunhat,a.tengiuong,a.idgiuong,songay,a.ngay
                    ,nvk_giadichvu=isnull(bg.GiaDV,0),nvk_GiaBaoHiem=isnull(bg.GiaBH,0)
                    ,nvk_isBHYT = case when  isnull(bg.IsBHYT,0)=1 and 
                        isnull(
	                        (select top 1 dk.loaikhamid from dangkykham dk 
											                        inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                          where ct.idchitietdangkykham ='" + IdCTDKK + @"'
	                        )
                        ,0)=1 then 1 else 0 end
                    ,nvk_loaibn=isnull(
	                        (select top 1 dk.loaikhamid from dangkykham dk 
											                        inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
						                          where ct.idchitietdangkykham ='" + IdCTDKK + @"'
	                        )
                        ,0)  
                    ,nvk_isnhapkhoa=isnull((select top 1 convert(int,isnhapkhoa) from benhnhannoitru where idnoitru =a.idnoitrunamnhieunhat),0)
		            ,b.*
                    ,strDaLuu=N'Chưa lưu'
             from dbo.NVK_TableKetQuaGiuong(" + IdCTDKK + @") a  left join KB_ChiTietGiuongBN b on b.idnoitru_G = a.idnoitrunamnhieunhat
                    left join kb_giuong g on g.giuongid=a.idgiuong 
                    left join kb_banggiagiuong bg on bg.GiuongId = g.giuongid
             order by a.ngay";
            dt = DataAcess.Connect.GetTable(sqlChiTiet);
            #region Load danh sách ngày nhiều giường
            string sqlNgayG = @"select distinct convert(varchar(10),ngay,103) as ngay1,ngay from
                            (
                            select  ngay  from NVK_ListNgayTinhGiuong(" + IdCTDKK + @") 
                            ) as abc where isnull((select count(*) from dbo.NVK_ListGiuongBN_Ngay(" + IdCTDKK + @",ngay)),0)>1 order by ngay asc";
            DataTable dtNgayG = DataAcess.Connect.GetTable(sqlNgayG);
            if (dtNgayG.Rows.Count > 0)
            {
                for (int i = 0; i < dtNgayG.Rows.Count; i++)
                {
                    ListGiuongHtml += @"<input type='button' id='ngay_" + (i + 1) + "' style='width:100px' runat='server' onclick='Ngay_click(this,"+idbenhnhan+","+IdCTDKK+","+idkhoa+")' value='" + dtNgayG.Rows[i]["ngay1"].ToString() + @"' style='background-color:Blue ! important' />";
                }
            }
            #endregion
        }
        #endregion
        
        if (dt != null)
        {
            html = @"<div id='divCenter' style='text-align:center'>";
            //html += tableChuyenGiuong(tbChuyenGiuong, idkhoa, IdCTDKK);
            html += "</div>";
            html += @"
                <div id='divNgayNhieuGiuong' style='text-align:center'>";
            //html += ListGiuongHtml;
            html += @"</div>
                <div id='divCenter1' style='text-align:center'>
                <div id='divChiTietGiuongNgay' style='display:none;top:20%;bottom:50%;left:35%;width:30%;background-color:white;z-index:1001;padding:5px 5px 5px 5px;border:10px solid black;text-align:center'></div>
                </div>
                <div id='tableAjax_EditTienGiuong' style='text-align:center'>";
            html += tabletienGiuong_2509(dt,idkhoa);
            html += "</div>";
            //if (dt != null && dt.Rows.Count > 0)
            //{
                html += @"<div id='divCenter2' style='text-align:center'>
<input type='button' id='CapNhatGiuong' style='width:130px' onclick='luuNoiDungGiuong_2509(" + idbenhnhan + "," + IdCTDKK + "," + idkhoa + @");' value='Lưu bảng giường' />
<input type='button' id='btnTinhLaiGiuong' style='width:100px' onclick='btnTinhLaiGiuong_click(" +idbenhnhan+","+IdCTDKK+","+idkhoa+@");' value='Tính lại' />
                </div>";
            //}
        }
        else
        {
        }
        return html;
    }
    private string tabletienGiuong_2509(DataTable dt,string idkhoa)
    {
        if (dt == null)
        {
            return "Lỗi khi load nội dung giường !";
        }
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<fieldset><legend>Giường tại khoa</legend>");
        html.Append("<table class='jtable' id=\"gridTableGiuong\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>Khoa</th>");
        html.Append("<th>Từ ngày</th>");
        html.Append("<th>Đến ngày</th>");
        html.Append("<th>Giường</th>");
        html.Append("<th>Giá DV</th>");
        html.Append("<th>Giá BH</th>");
        html.Append("<th>Số ngày</th>");
        html.Append("<th>BHYT ?</th>");
        html.Append("<th></th>");
        html.Append("</tr>");

        System.Text.StringBuilder html_1 = new System.Text.StringBuilder();
        html_1.Append("<fieldset><legend>Giường khoa khác</legend>");
        html_1.Append("<table class='jtable' id=\"gridGiuongKhacKhoa\">");
        html_1.Append("<tr>");
        html_1.Append("<th>STT</th>");
        html_1.Append("<th></th>");
        html_1.Append("<th>Khoa</th>");
        html_1.Append("<th>Từ ngày</th>");
        html_1.Append("<th>Đến ngày</th>");
        html_1.Append("<th>Giường</th>");
        html_1.Append("<th>Giá DV</th>");
        html_1.Append("<th>Giá BH</th>");
        html_1.Append("<th>Số ngày</th>");
        html_1.Append("<th>BHYT ?</th>");
        html_1.Append("<th></th>");
        html_1.Append("</tr>");

        string disabled_bhyt_i = "disabled='true'";

        int stt = 1;
        int stt_1 = 1;
        if (dt.Rows.Count != 0)
        {
            if (dt.Rows[0]["nvk_loaibn"].ToString().Equals("1"))
                disabled_bhyt_i = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["idkhoa"].ToString().Equals(idkhoa))
                {
                    html.Append("<tr>");
                    html.Append("<td>" + stt + "</td>");
                    stt++;
                    string nvk_disabled = " ";
                    string lin_Xoa = "<a onclick='xoaontableChiTietGiuong(this," + dt.Rows[i]["idnoitru"] + ")'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a>";
                    if (!dt.Rows[i]["idkhoa"].ToString().Equals(idkhoa) || dt.Rows[i]["nvk_isnhapkhoa"].ToString().Equals("1"))
                    {
                        nvk_disabled = " disabled='true' ";
                        lin_Xoa = "";
                    }
                    //if (dt.Rows[i]["nvk_isnhapkhoa"].ToString().Equals("0"))
                    html.Append("<td>" + lin_Xoa + "</td>");
                    //else
                    //    html.Append("<td></td>");
                    html.Append("<td><input mkv='true' id='idkhoa' type='hidden' value='" + dt.Rows[i]["idkhoa"] + "' /><input mkv='true' id='mkv_idkhoa' type='text' style='width:100px' " + nvk_disabled + " onfocusout='chuyenformout(this)' onfocus='IdKhoaSearch_2509(this);' value='" + dt.Rows[i]["khoa"] + "' /></td>");
                    html.Append(@"<td>
                        <input mkv='true' id='tungay' type='text' style='width:70px' " + nvk_disabled + " onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["Ngay1"] + @"' onfocus='chuyenphim(this);$(this).datepick();' onblur='nvk_testDate_this_notfocus(this);'  />
                        <input mkv='true' id='tugio' type='text' style='width:35px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["Gio1"] + @"' />
                    </td>");
                    html.Append(@"<td>
                        <input mkv='true' id='denngay' type='text' style='width:70px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["DenNgay1"] + @"' onfocus='chuyenphim(this);$(this).datepick();' onblur='nvk_testDate_this_notfocus(this);'  />
                        <input mkv='true' id='dengio' type='text' style='width:35px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["dengio1"] + @"' />
                    </td>");
                    html.Append("<td><input mkv='true' id='idGiuong' type='hidden' value='" + dt.Rows[i]["idgiuong"] + "' /><input mkv='true' id='mkv_idGiuong' style='width:300px' type='text' onfocus='chuyenphim(this);idGiuongsearch_2509(this)' value='" + dt.Rows[i]["tengiuong"] + "' class='down_select'/></td>");
                    html.Append("<td align='right'><input mkv='true' disabled='true' id='nvk_giadichvu' style='width:80px;text-align:right' type='text' value='" + StaticData.FormatNumberOption(dt.Rows[i]["nvk_giadichvu"], ",", ".", false) + "' /></td>");
                    html.Append("<td align='right'><input mkv='true' disabled='true' id='nvk_giabaohiem' style='width:80px;text-align:right' type='text' value='" + StaticData.FormatNumberOption(dt.Rows[i]["nvk_giaBaoHiem"], ",", ".", false) + "' /></td>");
                    html.Append("<td><input mkv='true' id='songay' type='text' style='width:50px;text-align:center' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["songay"], ",", ".", true) + "' /></td>");//thanhtienTableGiuong(this);
                    string BHYT_i = "";
                    if (dt.Rows[i]["nvk_isBHYT"].ToString().Equals("1"))
                        BHYT_i = "checked";
                    html.Append("<td><input mkv='true' id='nvk_isBHYT' " + disabled_bhyt_i + " type='checkbox' " + BHYT_i + " /></td>");
                    html.Append("<td style='color:Blue'>" + dt.Rows[i]["strDaluu"] + "</td>");                    
                    html.Append(@"<td>
                    <input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[i]["idnoitru"] + @"'/>");
                    html.Append(@"</td>");
                    html.Append("</tr>");
                }
                else
                {
                    html_1.Append("<tr>");
                    html_1.Append("<td>" + stt_1 + "</td>");
                    stt_1 ++;
                    html_1.Append("<td></td>");
                    html_1.Append("<td>" + dt.Rows[i]["khoa"] + "</td>");
                    html_1.Append("<td>" + dt.Rows[i]["Ngay1"] + " "+ dt.Rows[i]["Gio1"]+"</td>");
                    html_1.Append("<td>" + dt.Rows[i]["DenNgay1"] + " " + dt.Rows[i]["dengio1"] + "</td>");
                    html_1.Append("<td>" + dt.Rows[i]["tengiuong"] + "</td>");
                    html_1.Append("<td>" + StaticData.FormatNumberOption(dt.Rows[i]["nvk_giadichvu"], ",", ".", false) + "</td>");
                    html_1.Append("<td>" + StaticData.FormatNumberOption(dt.Rows[i]["nvk_giaBaoHiem"], ",", ".", false) + "</td>");
                    html_1.Append("<td>" + StaticData.FormatNumberOption(dt.Rows[i]["songay"], ",", ".", true) + "</td>");
                    string BHYT_i = "";
                    if (dt.Rows[i]["nvk_isBHYT"].ToString().Equals("1"))
                        BHYT_i = "checked";
                    html_1.Append("<td><input mkv='true' id='nvk_isBHYT' disabled='true' type='checkbox' " + BHYT_i + " /></td>");
                    html_1.Append("<td style='color:Blue'>" + dt.Rows[i]["strDaluu"] + "</td>");
                    html_1.Append("</tr>");
                }
            }
        }
        #region dòng trống
        html.Append("<tr>");
        html.Append("<td>" + stt + "</td>");
        html.Append("<td><a onclick='xoaontableChiTietGiuong(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td><input mkv='true' id='idkhoa' type='hidden' value='' /><input mkv='true' id='mkv_idkhoa' type='text' style='width:100px' onfocusout='chuyenformout(this)' onfocus='IdKhoaSearch_2509(this);' value='' /></td>");
        html.Append(@"<td>
                        <input mkv='true' id='tungay' type='text' style='width:70px' onfocusout='chuyenformout(this)' value='' onfocus='chuyenphim(this);$(this).datepick();' onblur='nvk_testDate_this_notfocus(this);'  />
                        <input mkv='true' id='tugio' type='text' style='width:35px' onfocusout='chuyenformout(this)' value='' />
                    </td>");
        html.Append(@"<td>
                        <input mkv='true' id='denngay' type='text' style='width:70px' onfocusout='chuyenformout(this)' value='' onfocus='chuyenphim(this);$(this).datepick();' onblur='nvk_testDate_this_notfocus(this);'  />
                        <input mkv='true' id='dengio' type='text' style='width:35px' onfocusout='chuyenformout(this)' value='' />
                    </td>");
        html.Append("<td><input mkv='true' id='idGiuong' type='hidden' value='' /><input mkv='true' id='mkv_idGiuong' style='width:300px' type='text' onfocus='chuyenphim(this);idGiuongsearch_2509(this)' value='' class='down_select'/></td>");
        html.Append("<td align='right'><input mkv='true' disabled='true' id='nvk_giadichvu' style='width:80px;text-align:right' type='text' value='' /></td>");
        html.Append("<td align='right'><input mkv='true' disabled='true' id='nvk_giabaohiem' style='width:80px;text-align:right' type='text' value='' /></td>");
        html.Append("<td><input mkv='true' id='songay' type='text' style='width:50px;text-align:center' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' value='' /></td>");//thanhtienTableGiuong(this);
        html.Append("<td><input mkv='true' id='nvk_isBHYT' " + disabled_bhyt_i + " type='checkbox' /></td>");
        html.Append(@"<td>
                    <input mkv='true' id='idkhoachinh' type='hidden' value=''/>");
        html.Append(@"</td>");
        html.Append(@"<td</td>");
        html.Append("</tr>");
        #endregion
        html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");
        html.Append("</legend></fieldset>");
        html_1.Append("</table>");
        html_1.Append("</legend></fieldset>");
        return html_1.ToString()+ html.ToString();
    }
    #endregion
    #region Thông tin DỊCH VỤ
    //table chỉ định dịch vụ cls
    #region table chỉ định dịch vụ cls
    private string tableCLS(DataTable dt, string[] arrslvack, bool idkhambenhcls)
    {
        string html = "";
        html += "<table class='jtable' id=\"gridTablecls\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idcanlamsan") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("chietkhau") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>";
        //html += "<th></th>";
        html += "</tr>";
        if (dt != null && dt.Rows.Count != 0)
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
                html += "<tr>";
                html += "<td>" + dt.Rows[i]["stt"] + "</td>";
                html += "<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idbanggiadichvu"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='idcanlamsansearch(this)' value='" + dt.Rows[i]["tendichvu"] + "' class='down_select' style='width:400px'/></td>";
                html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + sl + "' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:30px'/></td>";
                html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["dongia"] + "' onblur='TestSo(this,false,false);thanhtiencls(this);' style='width:70px'/></td>";
                html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ck + "' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:30px'/></td>";

                html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ((thanhtien - (thanhtien * ck) / 100)).ToString() + "' style='width:70px' /></td>";
                html += @"<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' />
                <input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : "") + @"'/>
                </td>";
                //html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : "") + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>1</td>";//" + (dt.Rows.Count + 1) + "
        html += "<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
        html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='idcanlamsansearch(this)' value='' class='down_select' style='width:400px'/></td>";
        html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:30px'/></td>";
        html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);' style='width:70px'/></td>";
        html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='thanhtiencls(this);'  style='width:30px'/></td>";

        html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:70px'/></td>";

        html += @"<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' />
        <input mkv='true' id='idkhoachinh' type='hidden' value=''/>
        </td>";
        //html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";

        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        return html;
    }
    private string tableCLS_Mini(DataTable dt, string[] arrslvack, bool idkhambenhcls, string loai, bool isKhacKhoa,string LoaiBN)
    {
        string html = "";
        html += "<table class='jtable' id=\"" + (loai == "cls" ? "gridTablecls" : "gridTabledichvu") + "\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + (loai == "cls" ? hsLibrary.clDictionaryDB.sGetValueLanguage("idcanlamsan") : hsLibrary.clDictionaryDB.sGetValueLanguage("iddichvu")) + "</th>";
        html += "<th>DmBH?</th>";
        html += "<th>SL</th>";
        html += "<th>BHYT?</th>";
        html += "<th>Ghi chú</th>";
        html += "<th></th>";
        html += "<th></th>";
        html += "</tr>";
        string disabled_bhyt_i = "disabled='true'";
        if (dt != null && dt.Rows.Count != 0)
        {
            if (LoaiBN.Equals("1"))
                disabled_bhyt_i = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //if (dt.Rows[i]["nvk_dahuy"].ToString().Equals("Đã hủy"))
                //    continue;
                int sl = 1;
                if (arrslvack != null)
                {
                    for (int y = 0; y < arrslvack.Length; y++)
                    {
                        if (arrslvack[y].Split('^')[0].ToString() == dt.Rows[i]["idbanggiadichvu"].ToString() && int.Parse(arrslvack[y].Split('^')[1].ToString()) > 1)
                        {
                            sl = int.Parse(arrslvack[y].Split('^')[1].ToString());
                            break;
                        }
                    }
                }
                try
                {
                    if (dt.Columns.IndexOf("soluong") == -1) sl = 1;
                    else                sl = int.Parse(dt.Rows[i]["soluong"].ToString());
                }
                catch { }
                html += "<tr>";
                html += "<td>" + (i+1) + "</td>";
                //if (isKhacKhoa || dt.Rows[i]["nvk_isdathu"].ToString().Equals("1"))
                //{
                //    html += "<td></td>";
                //    html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idbanggiadichvu"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["tendichvu"] + "' class='down_select' style='width:90%'/></td>";
                //}
                //else
                {
                    html += "<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                    html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idbanggiadichvu"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='" + (loai == "cls" ? "idcanlamsansearch(this,\"cls\")" : "idcanlamsansearch(this,\"dichvu\")") + "' value='" + dt.Rows[i]["tendichvu"] + "' class='down_select' style='width:90%'/></td>";
                }
                html += "<td><input id='IsBHYT_DM' disabled='true' " + (dt.Rows[i]["isTrongDM"].ToString().Equals("1") ? "checked" : "") + " type='checkbox' /></td>";
                html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + sl + "' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:30px'/></td>";
                html += "<td><input mkv='true' id='IsBHYT_Save' " + (dt.Rows[i]["nvk_isBHYT"].ToString().Equals("1") ? "" : "disabled='true'") + " type='checkbox' " + (dt.Rows[i]["nvk_isBHYT"].ToString().Equals("1") ? "checked" : "") + " /></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' value='" + dt.Rows[i]["ghichu"] + "' style='width:100px'/></td>";
                if (!isKhacKhoa && dt.Rows[i]["nvk_isdathu"].ToString().Equals("1"))
                {
                    if(dt.Rows[i]["nvk_dahuy"].ToString().Equals("Đã hủy"))
                        html += "<td><a style='color:Blue;cursor:text' >" + dt.Rows[i]["nvk_dahuy"] + "</a></td>";
                    else
                        html += "<td><a onclick=\"nvk_HuyOnTablecls(this," + dt.Rows[i]["idkhambenhcanlamsan"] + ",'" + dt.Rows[i]["tendichvu"] + "')\">" + dt.Rows[i]["nvk_dahuy"] + "</a></td>";
                }
                else
                    html += "<td></td>";
                html += @"<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : "") + @"'/>
                </td>";
                //html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : "") + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>1</td>";//" + (dt.Rows.Count + 1) + "
        html += "<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
        html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='" + (loai == "cls" ? "idcanlamsansearch(this,\"cls\")" : "idcanlamsansearch(this,\"dichvu\")") + "' value='' class='down_select' style='width:250px'/></td>";
        html += "<td><input id='IsBHYT_DM' disabled='true' type='checkbox' /></td>";
        html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:30px'/></td>";
        html += "<td><input mkv='true' id='IsBHYT_Save' " + disabled_bhyt_i + " type='checkbox' /></td>";
        html += "<td><input mkv='true' id='ghichu' type='text' value='' style='width:100px'/></td>";
        html += "<td></td>";

        html += @"<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/>
        </td>";
        //html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";

        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        return html;
    }
    #endregion
    #region table danh sách chỉ định dịch vụ
    public string LoadDanhSachChiDinhDichVu(DataTable table)
    {
        string html = "";
        html += "<table class='jtable' id=\"gridTabledsCLS\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>Sửa ?</th>";
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
                    html += "<tr >";
                    html += "<td>" + (i + 1) + "</td>";//

                    #region cho phép sửa ?
                    html += "<td><input type='button' value='Sửa CD' style='width:80px;height:20px;background-color:Red;background-image:none;cursor:pointer;'  onclick=\"DongChiDinhCLS_Click('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "');\"/></td>";
                    #endregion
                    if (table.Rows[i]["ngaykham"].ToString() != "")
                    {
                        html += "<td>" + DateTime.Parse(table.Rows[i]["ngaykham"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>";
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
    #endregion
    #region table danh sach chỉ định thuốc, vtyt...
    public string LoadDanhSachChiDinhThuocNoiTru(DataTable table, bool isTraThuoc,string idkhoa)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTabledsThuoc\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>Ngày chỉ định</th>");
        html.Append("<th>Lần chỉ định</th>");
        html.Append("<th>Khoa chỉ định</th>");
        html.Append("<th>Bác sĩ chỉ định</th>");
        html.Append("<th>Dự trù ?</th>");
        html.Append("</tr>");
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    bool isKhacKhoa = true;
                    if (table.Rows[i]["nvk_idkhoa"].ToString().Equals(idkhoa))
                        isKhacKhoa = false;
                    html.Append("<tr style='cursor:pointer;' >");
                    html.Append("<td>" + (i + 1) + "</td>");//
                    if (isTraThuoc)
                    {
                        #region cho phép trả thuốc ?
                        if (isKhacKhoa)
                        {
                            html.Append("<td></td>");
                        }
                        else
                        {
                        if (table.Rows[i]["tinhtrang"].ToString().Equals("3"))
                            html.Append("<td><input type='button' value='Trả Thuốc' style='width:80px;height:20px;color:Blue;background-image:none'  onclick=\"DongTraThuoc_Click('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "',3,this);\"/></td>");
                        else if (table.Rows[i]["tinhtrang"].ToString().Equals("4"))
                            html.Append("<td><input type='button' value='Đã YC trả' style='width:80px;height:20px;color:Red;background-image:none'  onclick=\"DongTraThuoc_Click('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "',4,this);\"/></td>");
                            //html.Append("<td style='font:bold;color:Red'>Đã YC trả</td>");
                        else if (table.Rows[i]["tinhtrang"].ToString().Equals("5"))
                            html.Append("<td><input type='button' value='Đã trả' style='width:80px;height:20px;color:Red;background-image:none'  onclick=\"DongTraThuoc_Click('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "',5,this);\"/></td>");
                            //html.Append("<td style='font:bold;color:Red'>Đã trả</td>");
                        else
                            html.Append("<td></td>");
                        }
                        #endregion
                    }
                    else
                    {
                        #region cho phép sửa chỉ định ?
                        if (isKhacKhoa)
                        {
                            html.Append("<td></td>");
                        }
                        else
                        {
                            if (table.Rows[i]["tinhtrang"].ToString().Equals("1"))
                                html.Append("<td><input type='button' value='Sửa CD' style='width:80px;height:23px;color:Red;background-image:none'  onclick=\"DongChiDinhThuoc_Click('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "',this);\"/></td>");
                            else if (table.Rows[i]["tinhtrang"].ToString().Equals("2"))
                                //html.Append("<td style='font:bold;color:Blue'>Đã YC</td>");
                                html.Append("<td><input type='button' value='Đã YC' style='width:80px;height:23px;color:Green;background-image:none'  onclick=\"DongChiDinhThuoc_Click('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "',this);\"/></td>");
                            else if (table.Rows[i]["tinhtrang"].ToString().Equals("3"))
                                //html.Append("<td style='font:bold;color:Blue'>Đã nhận</td>");
                                html.Append("<td><input type='button' value='Đã nhận' style='width:80px;height:23px;color:Blue;background-image:none'  onclick=\"DongChiDinhThuoc_Click('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "',this);\"/></td>");
                            else if (table.Rows[i]["tinhtrang"].ToString().Equals("4"))
                                //html.Append("<td style='font:bold;color:Red'>Đã YC trả</td>");
                                html.Append("<td><input type='button' value='Đã YC trả' style='width:80px;height:23px;color:Red;background-image:none'  onclick=\"DongChiDinhThuoc_Click('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "',this);\"/></td>");
                            else if (table.Rows[i]["tinhtrang"].ToString().Equals("5"))
                                html.Append("<td><input type='button' value='Đã trả' style='width:80px;height:23px;color:Black;background-image:none'  onclick=\"DongChiDinhThuoc_Click('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idkhambenh"].ToString() + "',this);\"/></td>");
                                //html.Append("<td style='font:bold;color:Red'>Đã trả</td>");
                            else
                                html.Append("<td></td>");
                        }
                        #endregion
                    }
                    if (table.Rows[i]["ngaykham"].ToString() != "")
                    {
                        html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaykham"].ToString()).ToString("dd/MM/yyyy HH:mm ") + "</td>");
                    }
                    else { html.Append("<td>" + table.Rows[i]["ngaykham"].ToString() + "</td>"); }
                    html.Append("<td>Chỉ định lần "+(table.Rows.Count - i)+"</td>");
                    html.Append("<td>" + table.Rows[i]["khoa"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["tenbacsi"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["NgayDuTru103"].ToString() + "</td>");
                    html.Append("</tr>");
                }
            }
        }
        html.Append("</table>");
        return html.ToString();
    }
    #endregion
    #endregion
    #region Thông tin Viện phí_Cận lâm sàng(dịch vụ)
    private string TableHtmlDanhSachCDCLS(DataTable tableDSCLS)
    {
        string html = "";
        html += "<table class='jtable' id=\"gridTabledsCLS\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Ngày chỉ định</th>";
        html += "<th>Lần chỉ định</th>";
        html += "<th>Mã phiếu chỉ định</th>";
        html += "<th>Khoa chỉ định</th>";
        html += "</tr>";
        if (tableDSCLS != null)
        {
            if (tableDSCLS.Rows.Count > 0)
            {
                for (int i = 0; i < tableDSCLS.Rows.Count; i++)
                {
                    html += "<tr >";
                    html += "<td>" + (i + 1) + "</td>";//
                    html += "<td><input type='button' value='Xem' style='width:40px;height:20px;background-color:Blue;background-image:none'  onclick=\"DongVienPhiCLS_Click('" + tableDSCLS.Rows[i]["idbenhnhan"].ToString() + "','" + tableDSCLS.Rows[i]["idkhambenh"].ToString() + "','" + tableDSCLS.Rows[i]["maphieucls"].ToString() + "',this);\"/></td>";
                    if (tableDSCLS.Rows[i]["ngaykham"].ToString() != "")
                    {
                        html += "<td>" + DateTime.Parse(tableDSCLS.Rows[i]["ngaykham"].ToString()).ToString("dd/MM/yyyy HH:mm tt") + "</td>";
                    }
                    else { html += "<td>" + tableDSCLS.Rows[i]["ngaykham"].ToString() + "</td>"; }
                    html += "<td>" + tableDSCLS.Rows[i]["MaBenhNhan"].ToString() + "</td>";
                    html += "<td>" + tableDSCLS.Rows[i]["maphieucls"].ToString() + "</td>";
                    html += "<td>" + tableDSCLS.Rows[i]["khoa"].ToString() + "</td>";
                    html += "</tr>";
                }
            }
        }
        html += "</table>";
        return html;
    }
    #endregion
    #region Thông tin Viện phí_Thuốc(VTYT...)
    private string TableHtmlDanhSachCDThuoc(DataTable tableDSThuoc)
    {
        string html = "";
        html += "<table class='jtable' id=\"gridTabledsThuoc\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Ngày chỉ định</th>";
        html += "<th>Lần chỉ định</th>";
        html += "<th>Khoa chỉ định</th>";
        html += "<th>Bác sĩ chỉ định</th>";
        html += "<th>Dự trù ?</th>";
        html += "</tr>";
        if (tableDSThuoc != null)
        {
            if (tableDSThuoc.Rows.Count > 0)
            {
                for (int i = 0; i < tableDSThuoc.Rows.Count; i++)
                {
                    html += "<tr >";
                    html += "<td>" + (i + 1) + "</td>";//
                    html += "<td><input type='button' value='Chi tiết' style='width:80px;height:20px;background-color:Red;background-image:none'  onclick=\"DongVienPhiThuoc_Click('" + tableDSThuoc.Rows[i]["idbenhnhan"].ToString() + "','" + tableDSThuoc.Rows[i]["idkhambenh"].ToString() + "','" + tableDSThuoc.Rows[i]["stt"].ToString() + "',this);\"/></td>";
                    if (tableDSThuoc.Rows[i]["ngaykham"].ToString() != "")
                    {
                        html += "<td>" + DateTime.Parse(tableDSThuoc.Rows[i]["ngaykham"].ToString()).ToString("dd/MM/yyyy HH:mm tt") + "</td>";
                    }
                    else { html += "<td>" + tableDSThuoc.Rows[i]["ngaykham"].ToString() + "</td>"; }
                    html += "<td>" + tableDSThuoc.Rows[i]["MaBenhNhan"].ToString() + "</td>";
                    html += "<td>" + tableDSThuoc.Rows[i]["khoa"].ToString() + "</td>";
                    html += "<td>" + tableDSThuoc.Rows[i]["tenbacsi"].ToString() + "</td>";
                    html += "<td>" + tableDSThuoc.Rows[i]["NgayDuTru103"].ToString() + "</td>";
                    html += "</tr>";
                }
            }
        }
        html += "</table>";
        return html;
    }
    #endregion
    #region Thông tin sinh hiệu
    //danh sách sinh hiệu
    private string LoadDanhSachSinhHieu(DataTable table)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaydo") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("mach") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nhietdo") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("huyetap") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nhiptho") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("chieucao") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("cannang") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("BMI") + "</th>");
        html.Append("</tr>");
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr style='cursor:pointer;' onclick=\"LoadNoiDungSinhHieu('" + table.Rows[i]["idsinhhieu"].ToString() + "')\">");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    if (table.Rows[i]["ngaydo"].ToString() != "")
                    {
                        html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaydo"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                    }
                    else { html.Append("<td>" + table.Rows[i]["ngaydo"].ToString() + "</td>"); }
                    html.Append("<td>" + table.Rows[i]["mach"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["nhietdo"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["huyetap1"].ToString() + "/" + table.Rows[i]["huyetap2"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["nhiptho"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["chieucao"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["cannang"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["BMI"].ToString() + "</td>");
                    html.Append("</tr>");
                }
            }
        }
        html.Append("</table>");
        return html.ToString();
    }
    // nội dung chi tiết sinh hiệu
    private string LoadNoiDungDoSinhHieu(DataTable table)
    {
        string idsinhHieu = "";
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string NgayDoSH = DateTime.Now.ToString("dd/MM/yyyy");
        if (table != null && table.Rows.Count > 0)
        {
            #region load sinh hiệu cũ
            NgayDoSH = table.Rows[0]["ngayDo103"].ToString();
            html.Append(@"<table style='width:100%'>
                <tr>
                <td style='padding: 0px 5px 0px 5px ' align='left'>Ngày đo :</td> <td><input type='text' id='txtNgayDo' value='" + NgayDoSH + @"' style='width:90px' onfocus='chuyenphim(this);$(this).datepick();'   onblur='nvk_testDate_this(this);' />(dd/MM/yyyy)</td><td style='padding: 0px 5px 0px 5px ' align='left'>Mạch(L/PH) :</td><td><input type='text' id='mach'  value='" + table.Rows[0]["mach"] + "' onblur='TestSo(this,false,true);'/></td><td style='padding: 0px 5px 0px 5px ' align='left'>Nhiệt độ(độ C) :</td><td><input type='text' id='nhietdo'  value='" + table.Rows[0]["nhietdo"] + @"'  onblur='TestSo(this,false,true);'/></td>
                </tr>
                <tr>
                <td style='padding: 0px 5px 0px 5px ' align='left'>Huyết áp (mmHg) :</td> <td><input type='text' id='huyetap1'  value='" + table.Rows[0]["huyetap1"] + "' style='width:50px'   onblur='TestSo(this,false,true);' />/<input type='text' id='huyetap2'  value='" + table.Rows[0]["huyetap2"] + "' style='width:50px'   onblur='TestSo(this,false,true);'/></td><td style='padding: 0px 5px 0px 5px ' align='left'></td><td></td><td style='padding: 0px 5px 0px 5px ' align='left'>Nhịp Thở (lần/phút) :</td><td><input type='text' id='nhiptho'  value='" + table.Rows[0]["nhiptho"] + @"'  onblur='TestSo(this,false,true);'/></td>
                </tr>
                <tr>
                <td style='padding: 0px 5px 0px 5px ' align='left'>Chiều Cao (cm) :</td> <td><input type='text' id='chieucao'  value='" + table.Rows[0]["chieucao"] + "'  onblur='TestSo(this,false,true);tinhBMI();'/></td><td style='padding: 0px 5px 0px 5px ' align='left'>Cân Nặng (kg) :</td><td><input type='text' id='cannang'  value='" + table.Rows[0]["cannang"] + @"'  onblur='TestSo(this,false,true);tinhBMI();'/></td><td style='padding: 0px 5px 0px 5px ' align='left'>BMI :</td><td><input type='text' id='BMI' disabled='disabled'  value='" + table.Rows[0]["BMI"] + @"'  onblur='TestSo(this,false,true);'/></td>
                </tr>
                <tr><td colspan='6'><input type='hidden' id='hdIdSinhHieu' value='" + table.Rows[0]["idsinhhieu"] + @"'/></td></tr>
                </table>");
            #endregion
        }
        else
        {
            #region load mới sinh hiệu
            html.Append(@"<table style='width:100%'>
                <tr>
                <td style='padding: 0px 5px 0px 5px ' align='left'>Ngày đo :</td> <td><input type='text' id='txtNgayDo' value='" + NgayDoSH + @"'  style='width:90px' onfocus='chuyenphim(this);$(this).datepick();'   onblur='nvk_testDate_this(this);' />(dd/MM/yyyy)</td><td style='padding: 0px 5px 0px 5px ' align='left'>Mạch(L/PH) :</td><td><input type='text' id='mach'  onblur='TestSo(this,false,true);'/></td><td style='padding: 0px 5px 0px 5px ' align='left'>Nhiệt độ(độ C) :</td><td><input type='text' id='nhietdo'   onblur='TestSo(this,false,true);'/></td>
                </tr>
                <tr>
                <td style='padding: 0px 5px 0px 5px ' align='left'>Huyết áp (mmHg) :</td> <td><input type='text' id='huyetap1' style='width:50px'   onblur='TestSo(this,false,true);' />/<input type='text' id='huyetap2'  style='width:50px'   onblur='TestSo(this,false,true);'/></td><td style='padding: 0px 5px 0px 5px ' align='left'></td><td></td><td style='padding: 0px 5px 0px 5px ' align='left'>Nhịp Thở (lần/phút) :</td><td><input type='text' id='nhiptho'   onblur='TestSo(this,false,true);'/></td>
                </tr>
                <tr>
                <td style='padding: 0px 5px 0px 5px ' align='left'>Chiều Cao (cm) :</td> <td><input type='text' id='chieucao'   onblur='TestSo(this,false,true);tinhBMI();'/></td><td style='padding: 0px 5px 0px 5px ' align='left'>Cân Nặng (kg) :</td><td><input type='text' id='cannang'   onblur='TestSo(this,false,true);tinhBMI();'/></td><td style='padding: 0px 5px 0px 5px ' align='left'>BMI :</td><td><input type='text' id='BMI'  disabled='disabled' onblur='TestSo(this,false,true);'/></td>
                </tr>
                <tr><td colspan='6'><input type='hidden' id='hdIdSinhHieu' value=''/></td></tr>
                </table>");
            #endregion
        }
        return html.ToString();
    }
    #endregion
    #region stTable chẩn đoán phối hợp
    private string strTableChanDoanPhoiHop(DataTable dt, int Stt_table)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTableCDPH" + Stt_table + "\" style='width:300px'>");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaICD") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MoTaICD") + "</th>");
        //html.Append("<th></th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        int i = 0;
        if (dt != null)
        {
            for (; i < dt.Rows.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + (i + 1) + "</td>");
                html.Append("<td><a onclick='xoaontableCDPH(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                html.Append("<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idicd"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1," + Stt_table + ")' value='" + dt.Rows[i]["MaICD"] + "' class='down_select' style='width:80px'/></td>");
                html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0," + Stt_table + ")' value='" + dt.Rows[i]["mota"] + "' class='down_select' style='width:320px'/></td>");
                //html.Append("<td><input id='mkvDown' type='text'  value='' style='width:10px'  onkeydown=\"chuyendongPH(this);\" /></td>");
                html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[i]["id"] + "'/></td>");
                html.Append("</tr>");
            }
        }
        html.Append("<tr>");
        html.Append("<td>" + (i + 1) + "</td>");
        html.Append("<td><a onclick='xoaontableCDPH(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1," + Stt_table + ")' value='' class='down_select' style='width:80px'/></td>");
        html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0," + Stt_table + ")' value='' class='down_select' style='width:320px'/></td>");
        //html.Append("<td><input id='mkvDown' type='text'  value='' style='width:10px'  onkeydown=\"chuyendongPH(this);\" /></td>");
        html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
        html.Append("</tr>");


        //html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");
        return html.ToString();
    }
    #endregion

    #region  tạo mới khám bệnh tại khoa
    private string nvk_addNewKhamBenhByKhoa_Hdt(string idbenhnhan, string iddkk, string idctdkk_, string idkhoa, string huongdieutri, string phongkhamchuyenden,string idBacSi)
    {
        string sqlInsert_KB = @"
                insert into khambenh(
                maphieukham
                ,ngaykham
                ,idbenhnhan
                ,iddangkykham
                ,IdChiTietDangKyKham
                ,huongdieutri
                ,phongkhamchuyenden,idbacsi
                ,idphongkhambenh,IsDaChuyenKhoa
                )
                values (
                N'PKXK',getdate()
                ,'" + idbenhnhan + "'," + iddkk + "," + idctdkk_ + @"
                ,'" + huongdieutri + "','" + phongkhamchuyenden + "','"+idBacSi+"','" + idkhoa + @"'
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
    #region table toa thuốc xuât khoa
    public string loadTableToaThuocXuatVien(DataTable table)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>Loại</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongke") + "</th>");
        //html.Append( "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongtra") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayuong") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("moilanuong") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
        html.Append("</tr>");
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                html.Append(@"<td>");
                html.Append("<a  onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a>");
                html.Append("</td>");
                html.Append("<td><input id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='" + table.Rows[i]["tenloai"].ToString() + "' class='down_select'/></td>");
                html.Append("<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idkho"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' style='width:100px'  onfocus='chuyenphim(this);khotoaxuatviensearch(this)' value='" + table.Rows[i]["tenkho"].ToString() + "' class='down_select'/></td>");
                html.Append("<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idthuoc' style='width:350px'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocRaViensearch(this)' value='" + table.Rows[i]["tenthuoc"].ToString() + "' class='down_select'/></td>");
                html.Append(@"<td ><input mkv='true' style='width:30px;text-align:right' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoLuongDonVi"].ToString() + @"' onblur='TestSo(this,false,false);'/>
<input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value='" + table.Rows[i]["DonViCoBan"].ToString() + @"'/>
                    </td>");
                html.Append("<td><input mkv='true' style='width:50px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "' onblur='TestSo(this,false,false);'/></td>");
                html.Append("<td><input mkv='true' style='width:50px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["moilanuong"].ToString() + "' /></td>");
                html.Append(@"<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + @"' /></td>
                    <input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'/>");
                html.Append("</tr>");
            }
        }
        html.Append("<tr>");
        html.Append("<td>" + (table.Rows.Count + 1) + "</td>");
        html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td><input  id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='' class='down_select'/></td>");
        html.Append("<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);khotoaxuatviensearch(this)' style='width:100px' value='' class='down_select'/></td>");
        html.Append("<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idthuoc' style='width:350px'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocRaViensearch(this)' value='' class='down_select'/></td>");
        html.Append(@"<td><input mkv='true' style='width:30px' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'>
            <input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value=''/>
            </td>");
        html.Append("<td><input mkv='true' style='width:50px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>");
        html.Append("<td><input mkv='true' style='width:50px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:100px'/></td>");
        html.Append(@"<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>
                <input mkv='true' id='idkhoachinh' type='hidden' value=''/>");
        html.Append("</tr>");
        html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");
        //html.Append(process.Paging("chitietbenhnhantoathuoc"));
        return html.ToString();
    }

    #region table toa thuoc xuat viện from  khambenh_TH
    public string loadTableToaThuocXuatVien_2709(string idkhambenh, string idLoaiBN)
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
        string html = "";
        html = loadTablechitietbenhnhantoathuoc2(table, null, true, idLoaiBN);
        return html;
    }
    private string loadTablechitietbenhnhantoathuoc2(DataTable table, string[] arrslvack, bool idctbntt, string loaidk)
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Loại thuốc</th>";
        html += "<th style='" + (idkhoa == "1" ? "display:none" : "") + "'>Kho xuất</th>";
        //html += "<th>Nhóm</th>";
        html += "<th>Tên thuốc</th>";
        //html += "<th>Hoạt chất</th>";
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
        html += "<th " + (loaidk == "1" ? "" : "style='display:none;'") + ">?BH</th>";
        html += "<th " + (loaidk == "1" ? "" : "style='display:none;'") + ">?thỏaBH</th>";
        html += "<th></th>";
        html += "</tr>";
        bool add = true;
        bool search = true;
        if (search)
        {
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
                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                    html += "<td><input mkv='true' id='loaithuocid' type='hidden' value='" + table.Rows[i]["LoaiThuocID"] + "'/><input mkv='true' id='mkv_loaithuocid' type='text' value='" + table.Rows[i]["MaLoai"].ToString() + "' onfocus='loaithuocidsearch(this);' style='width:70px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td style='" + (idkhoa == "1" ? "display:none" : "") + "'><input mkv='true' id='idkhoxuat' type='hidden' value='" + table.Rows[i]["idkho"] + "'/><input mkv='true' id='mkv_idkhoxuat' type='text'  type='text' onfocusout='chuyenformout(this)' onfocus='khotoaxuatviensearch(this);' style='width:70px' value='" + table.Rows[i]["tenkho"].ToString() + "' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    //html += "<td><input mkv='true' id='cateid' type='hidden' value='" + table.Rows[i]["cateid"] + "'/><input mkv='true' id='mkv_cateid' type='text' value='" + table.Rows[i]["catename"].ToString() + "' onfocus='cateidsearch(this);' style='width:70px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' id='mkv_idthuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='idthuocRaViensearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    //html += "<td><input mkv='true' id='mkv_congthuc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);congthucsearch(this)'  value='" + table.Rows[i]["congthuc"].ToString() + "' class='down_select'/></td>";
                    html += "<td><input mkv='true' id='iddvt' type='hidden' value='" + table.Rows[i]["iddvt"] + "'/><input mkv='true' id='mkv_iddvt' type='text' value='" + table.Rows[i]["DVT"].ToString() + "' onfocus='iddvtsearch(this);' style='width:50px; text-align:center;' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongke"].ToString() + "' style='width:30px' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idcachdung' type='hidden' value='" + table.Rows[i]["idcachdung"] + "'/><input mkv='true' id='mkv_idcachdung'  type='text' value='" + table.Rows[i]["tencachdung"].ToString() + "' onfocus='idcachdungsearch(this);' style='width:50px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "'  style='width:40px' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  style='width:30px' value='" + table.Rows[i]["moilanuong"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='iddvdung' type='hidden' value='" + table.Rows[i]["iddvdung"] + "'/><input mkv='true' id='mkv_iddvdung' type='text' value='" + table.Rows[i]["DVDung"].ToString() + "' onfocus='iddvtsearch(this);'  style='width:50px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='issang' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["issang"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='istrua' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istrua"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ischieu' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["ischieu"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='istoi' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istoi"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyendong(this);chuyenphim(this);' onblur='chuyenhuong(this);'  value='" + table.Rows[i]["ghichu"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td>Ngày<input mkv='true' id='isngay' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["isngay"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/>Tuần<input mkv='true' id='istuan' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istuan"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    //html += "<td><input mkv='true' id='isbh' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  style='width:30px' value='" + (StaticData.IsCheck(table.Rows[i]["sudungchobh"].ToString()) == true ? "BH" : "DV") + "' /></td>";
                    html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='SuDungChoBH' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (IsSuDungChoBH ? "checked='checked' " : "") + " disabled='disabled' /></td>";
                    html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='IsBHYT_Save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + ((IsBHYT_Save && IsSuDungChoBH) ? "checked='checked'" : "") + " " + (IsSuDungChoBH ? "" : "disabled='disabled'") + "/></td>";
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
            html += "<td><input mkv='true' id='loaithuocid' type='hidden' value=''/><input mkv='true' id='mkv_loaithuocid' type='text' value='' onfocus='loaithuocidsearch(this);' style='width:70px' class=\"down_select\"/></td>";
            html += "<td style='" + (idkhoa == "1" ? "display:none" : "") + "'><input mkv='true' id='idkhoxuat' type='hidden' value=''/><input mkv='true' id='mkv_idkhoxuat' type='text' onfocusout='chuyenformout(this)' onfocus='khotoaxuatviensearch(this);' style='width:70px' class=\"down_select\" /></td>";
            //html += "<td><input mkv='true' id='cateid' type='hidden' value=''/><input mkv='true' id='mkv_cateid' type='text' value='' onfocus='cateidsearch(this);' style='width:70px' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus='idthuocRaViensearch(this);' class=\"down_select\"/></td>";
            //html += "<td><input mkv='true' id='mkv_congthuc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);congthucsearch(this)' value='' class='down_select'/></td>";
            html += "<td><input mkv='true' id='iddvt' type='hidden' value=''/><input mkv='true' id='mkv_iddvt' type='text' value='' onfocus='iddvtsearch(this);' style='width:50px; text-algin:center;' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:30px' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='idcachdung' type='hidden' value=''/><input mkv='true' id='mkv_idcachdung' type='text' value='' onfocus='idcachdungsearch(this);'  style='width:50px' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:40px' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  style='width:30px' value='' /></td>";
            html += "<td><input mkv='true' id='iddvdung' type='hidden' value=''/><input mkv='true' id='mkv_iddvdung' type='text' value='' onfocus='iddvtsearch(this);'  style='width:50px' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='issang' type='checkbox'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='istrua' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='ischieu' type='checkbox'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='istoi' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)'  style='width:70px' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='chuyenhuong(this);' /></td>";
            html += "<td>Ngày<input mkv='true' id='isngay' type='checkbox' checked='true'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' />Tuần<input mkv='true' id='istuan' type='checkbox'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='SuDungChoBH' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled='disabled' /></td>";
            html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='IsBHYT_Save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled='disabled' /></td>";
            //html += "<td><input mkv='true' id='isbh' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'   style='width:30px' value='' /></td>";
            html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/><input mkv='true' id='idkho' type='hidden' value=''/></td>";
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
    #endregion

    #region from CapCuu/ajax.aspx
    private void nvk_showTamUng()
    {
        try
        {
            string IdKhoa = Request.QueryString["idkhoa"];
            string idTamung = Request.QueryString["idtamung"].ToString();
            string idchitietdangkykham = Request.QueryString["idbn"];
            string IsSua = "";
            string html = "";
            string SoDangKy = StaticData.SoDangKyMoiNhat();
            string QuyenSo = StaticData.QuyenSoMoiNhat();
            //            string sqlSoLan = @"select COUNT(distinct IDTamUng)+1
            //                from tamUng tu
            //                left join chitietdangkykham ct on ct.idchitietdangkykham =tu.iddangkykham
            //                left join dangkykham dk on dk.iddangkykham=ct.iddangkykham
            //                where dk.idbenhnhan=(select top 1 dk1.idbenhnhan
            //	                from chitietdangkykham ct1
            //	                left join dangkykham dk1 on dk1.iddangkykham=ct1.iddangkykham
            //	                where ct1.idchitietdangkykham='" + idchitietdangkykham + "')";
            string sqlSoLan = @"select COUNT(distinct IDTamUng)+1
                from tamUng tu where tu.iddangkykham='" + idchitietdangkykham + "'";
            DataTable SoLan = DataAcess.Connect.GetTable(sqlSoLan);
            string strSoLan = "1";
            if (SoLan.Rows.Count > 0)
                strSoLan = SoLan.Rows[0][0].ToString();
            else
                strSoLan = "1";
            if (Request.QueryString["IsSua"] != null)
            {
                IsSua = Request.QueryString["IsSua"].ToString();
                if (IsSua == "1")
                {
                    string sqlTamUng = "select *,solan=isnull( (select count(*) from tamung where idtamung<=tu.idtamung and iddangkykham= tu.iddangkykham),0) from tamung tu where idtamung=" + idTamung;
                    DataTable dtTU = DataAcess.Connect.GetTable(sqlTamUng);
                    if (dtTU != null && dtTU.Rows.Count > 0)
                    {
                        html = "<div style=\"850px;overflow:auto;height:100px\">";
                        html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" >";
                        html += "<tr >";
                        html += "<td colspan=\"5\" class=\"ptext\" >Lần thứ: " + dtTU.Rows[0]["solan"] + "</td>";
                        html += "</tr>";
                        html += "<tr >";
                        //html += "<td class=\"ptext\" >Quyển Số: </td>";
                        //html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtQuyenSo\" value=\"" + QuyenSo + "\" />&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                        //html += "<td class=\"ptext\" >Số CT:</td>";
                        //html += "<td  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoCT\" value=\"\"/> &nbsp;&nbsp;&nbsp;&nbsp;</td>";
                        html += "<td class=\"ptext\" >Số tiền</td>";
                        html += "<td  class=\"ptext\"  ><input type=\"text\"  onchange='nvk_formatNumBer(this)' style=\"width: 80px\" id=\"txtSoTien\" value=\"" + StaticData.FormatNumberOption(dtTU.Rows[0]["sotien"], ",", ".", false) + "\" /></td>";
                        html += "<td class=\"ptext\" >Lý do</td>";
                        html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 350px\" value=\"" + dtTU.Rows[0]["LydoTU"] + "\" id=\"txtLyDo\"/></td>";
                        html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Sửa TU\" onclick=\"luuTU(" + idchitietdangkykham + "," + idTamung + ");\"/></td>";
                        html += "</tr>";
                        html += "</table>";
                        html += "</div>";
                    }
                }
                else
                {
                    html = "<div style=\"850px;overflow:auto;height:100px\">";
                    html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" >";

                    html += "<tr >";
                    html += "<td colspan=\"5\" class=\"ptext\" >Lần thứ: " + strSoLan + "</td>";
                    html += "</tr>";
                    html += "<tr >";
                    html += "<tr >";
                    //html += "<td class=\"ptext\" >Quyển Số: </td>";
                    //html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtQuyenSo\" value=\"" + QuyenSo + "\" />&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                    //html += "<td class=\"ptext\" >Số CT:</td>";
                    //html += "<td  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoCT\" value=\"\"/> &nbsp;&nbsp;&nbsp;&nbsp;</td>";
                    //Số tiền=
                    html += "<td class=\"ptext\" >Số tiền</td>";
                    if (IdKhoa == StaticData.GetParameter("nvk_idkhoacapcuu"))
                        html += "<td  class=\"ptext\"  > <select id=\"txtSoTien\" style=\"width: 100px\">"
                              + "<option value=\"1000000\">1,000,000</option>"
                              + "<option value=\"2000000\">2,000,000</option>"
                              + "<option value=\"3000000\">3,000,000</option>"
                              + "<option value=\"4000000\">4,000,000</option>"
                              + "<option value=\"5000000\">5,000,000</option>"
                            + "</select> </td>";
                    //html += "<td  class=\"ptext\"  ><input type=\"text\" value=\"500,000\" style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                    else
                        html += "<td  class=\"ptext\"  ><input type=\"text\"  onchange='nvk_formatNumBer(this)'  style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                    html += "<td class=\"ptext\" >Lý do</td>";
                    html += "<td  class=\"ptext\"  ><input type=\"text\" value=\"Chỉ định tạm ứng\" style=\"width: 350px\" id=\"txtLyDo\"/></td>";
                    html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Lưu TU\" onclick=\"luuTU(" + idchitietdangkykham + "," + idTamung + ");\"/></td>";
                    html += "</tr>";

                    html += "</table>";
                    html += "</div>";
                }
            }
            else
            {
                html = "<div style=\"850px;overflow:auto;height:100px\">";
                html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" >";

                html += "<tr >";
                html += "<td colspan=\"5\" class=\"ptext\" >Lần thứ: " + strSoLan + "</td>";
                html += "</tr>";
                html += "<tr >";
                //html += "<td class=\"ptext\" >Quyển Số: </td>";
                //html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtQuyenSo\" value=\"" + QuyenSo + "\" />&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                //html += "<td class=\"ptext\" >Số CT:</td>";
                //html += "<td  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoCT\" value=\"\"/> &nbsp;&nbsp;&nbsp;&nbsp;</td>";
                //Số tiền=
                html += "<td class=\"ptext\" >Số tiền</td>";
                if (IdKhoa == StaticData.GetParameter("nvk_idkhoacapcuu"))
                    html += "<td  class=\"ptext\"  > <select id=\"txtSoTien\" style=\"width: 100px\">"
                              + "<option value=\"1000000\">1,000,000</option>"
                              + "<option value=\"2000000\">2,000,000</option>"
                              + "<option value=\"3000000\">3,000,000</option>"
                              + "<option value=\"4000000\">4,000,000</option>"
                              + "<option value=\"5000000\">5,000,000</option>"
                            + "</select> </td>";
                //html += "<td  class=\"ptext\"  ><input type=\"text\" value=\"500,000\" style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                else
                    html += "<td  class=\"ptext\"  ><input type=\"text\"  onchange='nvk_formatNumBer(this)'  style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                html += "<td class=\"ptext\" >Lý do</td>";
                html += "<td  class=\"ptext\"  ><input type=\"text\" value=\"Chỉ định tạm ứng\" style=\"width: 350px\" id=\"txtLyDo\"/></td>";
                html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Lưu TU\" onclick=\"luuTU(" + idchitietdangkykham + "," + idTamung + ");\"/></td>";
                html += "</tr>";
                html += "</table>";
                html += "</div>";
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    #endregion

    #region from nvk_NhapKhoaSan
    private void ChanDoansearch()
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
        html = string.Format("{0}|{1}|{2}|{3}|{4}", ""
       + "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
       + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
       + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >MaICD</div>"
       + "<div style=\"width:55%;height:30px;color:#000;font-weight:bold;float:left\" >Mô tả</div>"
       + "</div>", "", "", "", Environment.NewLine);
        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div>"
        + "<div style=\"width:15%;height:30px;float:left\" >" + (i + 1) + "</div>"
        + "<div style=\"width:30%;height:30px;float:left\" >" + h["maicd"] + "</div>"
        + "<div style=\"width:55%;height:30px;float:left\" >" + h["mota"] + "</div>"
         + "</div>", h["idicd"], h["maicd"], h["mota"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void xoanvk_chanDoanPhoiHop()
    {
        try
        {
            DataProcess process = nvk_chanDoanPhoiHop();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void xoanvk_chanDoanXuatKhoa()
    {
        try
        {
            DataProcess process = nvk_chanDoanXuatKhoa();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idCDXuatKhoa"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void nvk_luutableChanDoanPhoiHop()
    {
        try
        {
            DataProcess process = nvk_chanDoanPhoiHop();
            if (process.getData("idicd").Trim() == "")
            {
                Response.StatusCode = 500;
                return;
            }
            if (process.getData("id") != null && process.getData("id") != "" && process.getData("id") != "0")
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
    private void nvk_luutableChanDoanPhoiHop_XK()
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
                if (!isExistsChanDoanPhoiHopXK(Request.QueryString["idxuatkhoa"].ToString(), Request.QueryString["idicd"].ToString()))//
                {
                    string idCDXuatKhoa_new = DataAcess.Connect.GetTable("select isnull(max(idCDXuatKhoa),0)+1 from  nvk_chanDoanXuatKhoa").Rows[0][0].ToString();
                    process.data("idCDXuatKhoa", idCDXuatKhoa_new);
                    bool ok = process.Insert();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("idCDXuatKhoa"));
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
    private bool isExistsChanDoanPhoiHopXK(string idxuatkhoa,string idicd)
    {
        string sqlEx = "select * from nvk_chandoanxuatkhoa where idxuatkhoa ='"+idxuatkhoa+"' and idicd ='"+idicd+"'";
        DataTable dtEx = DataAcess.Connect.GetTable(sqlEx);
        if (dtEx != null && dtEx.Rows.Count > 0)
            return true;
        else
            return false;
        return false;
    }
    #endregion

    #region from khambenh_TH/ajax/khambenh_ajax3.cs
    public void luuTablechitietbenhnhantoathuoc_XuatVien_new()
    {
        try
        {
            string idthuoc = Request.QueryString["idthuoc"];
            string idkhambenh = Request.QueryString["idkhambenh"];
            if (string.IsNullOrEmpty(idthuoc) || idthuoc.Equals("0") || string.IsNullOrEmpty(idkhambenh) || idkhambenh.Equals("0"))
            {
                Response.StatusCode = 500;
                return;
            }
            #region dtKhamBenh, TGXuatVien
            string sqlKhamBenh = "SELECT * FROM KHAMBENH WHERE IDKHAMBENH=" + idkhambenh;
            DataTable dtKhamBenh = DataAcess.Connect.GetTable(sqlKhamBenh);
            string TGXuatVien = dtKhamBenh.Rows[0]["TGXuatVien"].ToString();
            try
            {
                TGXuatVien = DateTime.Parse(TGXuatVien).ToString("yyyy/MM/dd hh:mm:ss");
            }
            catch (Exception)
            {
                TGXuatVien = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            }
            #endregion
            #region benhnhantoathuoc
            DataTable dtBNTT = DataAcess.Connect.GetTable("SELECT IDBENHNHANTOATHUOC FROM BENHNHANTOATHUOC WHERE IDKHAMBENH=" + idkhambenh);
            string idbenhnhan = dtKhamBenh.Rows[0]["idbenhnhan"].ToString();
            string idbacsi = dtKhamBenh.Rows[0]["idbacsi"].ToString();
            string benhnhantoathuocSql = "";
            string idbenhnhantoathuoc = "";
            if (dtBNTT != null && dtBNTT.Rows.Count > 0)
            {
                benhnhantoathuocSql = @"update benhnhantoathuoc set idkhambenh='" + idkhambenh + "',idbacsi='" + idbacsi + "',idbenhnhan='" + idbenhnhan + "',ngayratoa='" + TGXuatVien + "' where idbenhnhantoathuoc ='" + dtBNTT.Rows[0][0].ToString() + "'";
                idbenhnhantoathuoc = dtBNTT.Rows[0][0].ToString();
            }
            else
            {
                benhnhantoathuocSql = @"insert into benhnhantoathuoc (idkhambenh,idbacsi,idbenhnhan,ngayratoa)
                                    values ('"+idkhambenh+"','"+idbacsi+"','"+idbenhnhan+"','"+TGXuatVien+"')";
                
            }
            bool bnttOk = DataAcess.Connect.ExecSQL(benhnhantoathuocSql);
            if (string.IsNullOrEmpty(idbenhnhantoathuoc))
                idbenhnhantoathuoc = DataAcess.Connect.GetTable("SELECT IDBENHNHANTOATHUOC FROM BENHNHANTOATHUOC WHERE IDKHAMBENH='" + idkhambenh+"'").Rows[0][0].ToString();
            #endregion
            #region ChiTietBenhNhanToaThuoc
            #region parameter QueryString
            string idchitietbenhnhantoathuoc= Request.QueryString["idkhoachinh"];
            string soluongke = Request.QueryString["soluongke"];
            if (string.IsNullOrEmpty(soluongke))
                soluongke = "0";
            string ngayuong = Request.QueryString["ngayuong"];
            if (string.IsNullOrEmpty(ngayuong))
                ngayuong = "null";
            string moilanuong = Request.QueryString["moilanuong"];
            if (string.IsNullOrEmpty(moilanuong))
                moilanuong = "null";
            string ghichu = Request.QueryString["ghichu"];
            string idkho = Request.QueryString["idkho"];
            if (string.IsNullOrEmpty(idkho))
                idkho = "null";
            string idcachdung = Request.QueryString["idcachdung"];
            if (string.IsNullOrEmpty(idcachdung))
                idcachdung = "null";
            string iddvt = Request.QueryString["iddvt"];
            if (string.IsNullOrEmpty(iddvt))
                iddvt = "null";
            string istuan = StaticData.IsCheck(Request.QueryString["istuan"])?"1":"0";
            string isngay = StaticData.IsCheck(Request.QueryString["isngay"])?"1":"0";
            string issang = StaticData.IsCheck(Request.QueryString["issang"])?"1":"0";
            string istrua = StaticData.IsCheck(Request.QueryString["istrua"])?"1":"0";
            string ischieu = StaticData.IsCheck(Request.QueryString["ischieu"])?"1":"0";
            string istoi = StaticData.IsCheck(Request.QueryString["istoi"]) ? "1" : "0";
            string IsBHYT_Save = StaticData.IsCheck(Request.QueryString["IsBHYT_Save"]) ? "1" : "0";
            string iddvdung = Request.QueryString["iddvdung"];
            if (string.IsNullOrEmpty(iddvdung))
                iddvdung = "null";
            #endregion
            #region insert or update chitietbenhnhantoathuoc
            string chitietbenhnhantoathuocSql = "";
            if (string.IsNullOrEmpty(idchitietbenhnhantoathuoc) || idchitietbenhnhantoathuoc.Equals("0"))
            {
                chitietbenhnhantoathuocSql = @"
                            INSERT INTO chitietbenhnhantoathuoc(idthuoc,soluongke,ngayuong,moilanuong,ghichu,idkhambenh
                                ,idkho,ngayratoa,idcachdung,iddvt,istuan,isngay,issang
                                ,istrua,ischieu,istoi,iddvdung,idbenhnhantoathuoc,IsBHYT_Save) 
                            values(" + idthuoc+","+soluongke+","+ngayuong+","+moilanuong+",N'"+ghichu+"',"+idkhambenh+@"
                                ,"+idkho+",'"+TGXuatVien+"',"+idcachdung+","+iddvt+","+istuan+","+isngay+","+issang+@"
                                ," + istrua + "," + ischieu + "," + istoi + "," + iddvdung + "," + idbenhnhantoathuoc + "," + IsBHYT_Save + ")";
            }
            else
            {
                chitietbenhnhantoathuocSql = @"
                    update chitietbenhnhantoathuoc set idthuoc="+idthuoc+",soluongke="+soluongke+",ngayuong="+ngayuong+",moilanuong="+moilanuong+",ghichu=N'"+ghichu+"',idkhambenh="+idkhambenh+@"
                    ,idkho="+idkho+",ngayratoa='"+TGXuatVien+"',idcachdung="+idcachdung+",iddvt="+iddvt+",istuan="+istuan+",isngay='"+isngay+"',issang='"+issang+@"'
                    ,istrua='" + istrua + "',ischieu='" + ischieu + "',istoi='" + istoi + "',iddvdung=" + iddvdung + ",idbenhnhantoathuoc='" + idbenhnhantoathuoc + "',IsBHYT_Save=" + IsBHYT_Save + " where idchitietbenhnhantoathuoc ='" + idchitietbenhnhantoathuoc + "'";
            }
            bool ctbnttOk = DataAcess.Connect.ExecSQL(chitietbenhnhantoathuocSql);
            if (ctbnttOk)
            {
                if (string.IsNullOrEmpty(idchitietbenhnhantoathuoc) || idchitietbenhnhantoathuoc.Equals("0"))
                {
                    idchitietbenhnhantoathuoc = DataAcess.Connect.GetTable("select idchitietbenhnhantoathuoc from chitietbenhnhantoathuoc where idkhambenh ='"+idkhambenh+"' and idthuoc ='"+idthuoc+"'").Rows[0][0].ToString();
                }
                Response.Clear(); Response.Write(idchitietbenhnhantoathuoc);
                return;
            }
            #endregion
            #endregion
        }
        catch (Exception)
        {

        }
        Response.StatusCode = 500;
    }
    public void luuTablechitietbenhnhantoathuoc_XuatVien()
    {
        try
        {
            DataProcess process = s_chitietbenhnhantoathuoc_XuatVien();
            if (process.getData("idthuoc").Trim() == "")
            {
                Response.StatusCode = 500;
                return;
            }

            string idkhambenh = process.getData("idkhambenh");
            string sqlKhamBenh = "SELECT * FROM KHAMBENH WHERE IDKHAMBENH=" + idkhambenh;
            DataTable dtKhamBenh = DataAcess.Connect.GetTable(sqlKhamBenh);

            string TGXuatVien = dtKhamBenh.Rows[0]["TGXuatVien"].ToString();

            try
            {
                TGXuatVien = DateTime.Parse(TGXuatVien).ToString("dd/MM/yyyy hh:mm:ss");
            }
            catch (Exception)
            {
                TGXuatVien = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            }


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
            #region kiemtra loaitoa
            string idkho = process.getData("idkho").ToString().Trim();
            if (idkho != null && idkho != "")
            {
                process.data("idbenhnhantoathuoc", "0");
            }
            #endregion

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
    #endregion

    #region hủy lệnh xuất khoa 
    private void nvkHuyChiDinhXuatKhoa()
    {
        string idctdkk = Request.QueryString["idctdkk"];
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idkhoa = Request.QueryString["idkhoa"];
        if (idctdkk.Equals("") || idctdkk.Equals("0") || idbenhnhan.Equals("") || idbenhnhan.Equals("0") || idkhoa.Equals("") || idkhoa.Equals("0"))
        {
            Response.Clear();
            Response.Write("0");// lỗi
            return;
        }
        if (HuyLenhXuatKhoa(idctdkk, idkhoa))
        {

            Response.Clear();
            Response.Write("1");//thành công
        }
        else
        {
            Response.Clear();
            Response.Write("0");// lỗi
        }
    }

    private bool HuyLenhXuatKhoa(string idchitietdangkykham, string idkhoa)
    {
        bool kt = false;
        string sqlUpDate = " UPDATE BENHNHANNOITRU SET ISDANHAP=1 where idchitietdangkykham =" + idchitietdangkykham + " and idkhoanoitru =" + idkhoa + "";
        kt = DataAcess.Connect.ExecSQL(sqlUpDate);
        if (kt)
        {
            string UpdateIn = "";
            if (idkhoa.Equals(StaticData.GetParameter("nvk_idkhoacapcuu")))
                UpdateIn = "set huongdieutri=14,isdachuyenkhoa=2";
            else
                UpdateIn = "set huongdieutri=8,phongkhamchuyenden=" + idkhoa + ",isdachuyenkhoa=2";
            string sqlKbXuat = @"update khambenh " + UpdateIn + " where isdachuyenkhoa=0 and maphieukham=N'PKXK' and idchitietdangkykham=" + idchitietdangkykham + " and  huongdieutri in (1,3,4,7,8,11,16,17) and idphongkhambenh=" + idkhoa + "";
            kt = DataAcess.Connect.ExecSQL(sqlKbXuat);
            if (kt)
            {
                string idxuatkhoa = "0"; string idKBxuatkhoa = "0";
                DataTable dtXK = DataAcess.Connect.GetTable("select top 1 * from benhnhanxuatkhoa where idchitietdangkykham='" + idchitietdangkykham + "' order by idxuatkhoa desc");
                if (dtXK.Rows.Count > 0)
                {
                    idKBxuatkhoa = dtXK.Rows[0]["IdKhamBenhXK"].ToString();
                    string sqlDvCV = @"delete from khambenhcanlamsan where idkhambenh='" + idKBxuatkhoa + @"' and idcanlamsan in(
                                 select idbanggiadichvu from benhvien where idbenhvien='" + dtXK.Rows[0]["IdBVChuyenDen"] + @"'
                                union select idbanggiadichvuDDBS from benhvien where idbenhvien='" + dtXK.Rows[0]["IdBVChuyenDen"] + @"'
                                union select idbanggiadichvuDD from benhvien where idbenhvien='" + dtXK.Rows[0]["IdBVChuyenDen"] + @"'
                                )";
                    kt = DataAcess.Connect.ExecSQL(sqlDvCV);
                    if (kt)
                    {
                        kt = DataAcess.Connect.ExecSQL("delete from benhnhanxuatkhoa where idxuatkhoa='" + dtXK.Rows[0]["idxuatkhoa"] + "'");
                    }
                }
            }
        }
        return kt;
    }
    #endregion

    #region Tổng hợp chẩn đoán khi xuất khoa
    private void THChanDoan_click()
    {
        string idctdkk = Request.QueryString["idctdkk"];
        string idkhoa = Request.QueryString["idkhoa"];
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string sql_thCD = @"
	            select distinct idCDXuatKhoa,mota=ct.MoTaChanDoan_XK,cd.maicd,cd.idicd,Loai=N'XK'
                        from nvk_chandoanxuatkhoa ct
                        inner join  benhnhanxuatkhoa xk on xk.idxuatkhoa =ct.idxuatkhoa
		                left join chandoanicd cd on cd.idicd= ct.idicd
	                WHERE xk.idchitietdangkykham=" + idctdkk + @"
                union ALL
                    SELECT distinct idCDXuatKhoa=0,mota=a.MOTACD_edit,b.maicd,b.idicd,Loai=N'KB'
	                FROM KHAMBENH a
		                left JOIN CHANDOANICD b ON a.KETLUAN=b.IDICD
	                WHERE a.ketluan>0 AND a.idchitietdangkykham=" + idctdkk + @"
                union ALL
	                SELECT distinct idCDXuatKhoa=0,mota=b.MOTACD_edit,c.maicd,c.idicd,Loai=N'KB_PH'
	                FROM KHAMBENH A
		                inner JOIN CHANDOANPHOIHOP B ON  a.IDKHAMBENH=B.IDKHAMBENH
		                LEFT JOIN CHANDOANICD C ON  c.IDICD=b.IDICD
	                WHERE a.idchitietdangkykham=" + idctdkk + @"
                union ALL
	                select distinct idCDXuatKhoa=0,mota=nk.MoTaChanDoan_NK,cd.maicd,cd.idicd,Loai=N'NK'
                        from nvk_chandoannhapkhoa nk 
                        inner join  benhnhannoitru nt on nt.idnoitru =nk.idnoitru
		                left join chandoanicd cd on cd.idicd= nk.idicd
	                WHERE nt.idchitietdangkykham=" + idctdkk + @"";
        DataTable dtCDPH = DataAcess.Connect.GetTable(sql_thCD);
        html.Append(strTableChanDoanPhoiHop_XK(dtCDPH));
        Response.Clear();
        Response.Write(html);
    }
    #endregion


    #region canlamsangthuongquy
    private void ChonclsThuongquy()
    {
        string sqlSelect = string.Format(@"SELECT * FROM KB_NHOMCLS T order by tennhom");
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"tablefind\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nhóm CLS thường quy") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr style='cursor:pointer'>");
                    html.Append("<td>" + (i+1) + "</td>");
                    html.Append("<td style='text-align:left; padding-left:10px; font-family:tahoma;'>" + table.Rows[i]["TenNhom"].ToString() + "</td>");
                    html.Append("<td style='text-align:left; padding-left:10px; font-family:tahoma;'>" + table.Rows[i]["GhiChu"].ToString() + "</td>");
                    html.Append("<td><a href=\"javascript:;\" onclick=\"setCSLThuongQuy(this,'" + table.Rows[i]["NhomId"].ToString() + "')\">Chọn</a><td>");
                    html.Append("</tr>");
                }
                html.Append("</table>");
                Response.Clear();
                Response.Write(html);
                return;
            }
        }
        else
        {
            Response.StatusCode = 500;
        }
    }
    private void getListCSLThuongQuy()
    {
        string nhomid = Request.QueryString["NhomId"]; 
        string sqlTq = string.Format(@"select distinct  t.idbanggiadichvu 
                      from KB_ChiTietNhomCLS T
                      where T.NhomID='{0}'", nhomid);
        DataTable dtTQ = DataAcess.Connect.GetTable(sqlTq);
        string html = "";
        if(dtTQ != null)
        for (int i = 0; i < dtTQ.Rows.Count; i++)
        {
            html += dtTQ.Rows[i]["idbanggiadichvu"].ToString()+",";
        }
        html = html.TrimEnd(',');
        Response.Clear();
        Response.Write(html);
    }
    #endregion

    #region excel Danh Sách nội trú
    TheoDoiKhamBenhNoiTru dsNoiTru = null;
    private void XuatExcelDSNoiTru()
    {
        string idkhoa = Request.QueryString["IdKhoaNoiTru"];
        string mabenhnhan = Request.QueryString["mabenhnhan"];
        string tenbenhnhan = Request.QueryString["tenbenhnhan"];

        dsNoiTru = new TheoDoiKhamBenhNoiTru();
        dsNoiTru.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(dsNoiTru_AfterExportToExcel);
        dsNoiTru.MaBenhNhan = mabenhnhan;
        dsNoiTru.TenBenhNhan = tenbenhnhan;
        dsNoiTru.TenKhoa = DataAcess.Connect.GetTable("select isnull( (select tenphongkhambenh from phongkhambenh where idphongkhambenh ='"+idkhoa+"') ,'')").Rows[0][0].ToString();
        dsNoiTru.sqlQuery = @"
                select stt=row_number() over (order by tenbenhnhan),Phong = replace(replace(tenphong,N'Nội ',''),N'Ngoại ',''),tenbenhnhan,ngaysinh
                --,diachi ,case when isnull(bn.gioitinh,0)=1 then N'Nữ' else N'Nam' end as GioiTinh
                ,a='',b='',c='',d='',e=''
                from  dbo.[NVK_DSBNNoiTruTheoKhoa_1]("+idkhoa+@")  dbo
                inner join benhnhan bn on bn.idbenhnhan= dbo.idbenhnhan
                inner join benhnhannoitru nt on nt.IDCHITIETDANGKYKHAM=DBO.IDCHITIETDANGKYKHAM
	                and nt.idnoitru in(select top 1 idnoitru from benhnhannoitru where IDCHITIETDANGKYKHAM =DBO.IDCHITIETDANGKYKHAM AND IDKHOANOITRU ='"+idkhoa+@"' and isdanhap=1 order by NgayVaoVien desc) 
                left join kb_giuong g on g.giuongid=nt.idgiuong left join  kb_phong p on g.idphong=p.id
                        where bn.mabenhnhan like N'%" + mabenhnhan + "%' and bn.tenbenhnhan like N'%" + tenbenhnhan + @"%' 
				and exists (select idchitietdangkykham from chitietdangkykham where idchitietdangkykham =dbo.idchitietdangkykham) 
                order by isnull(isPhongChan,0),replace(replace(tenphong,N'Nội ',''),N'Ngoại ',''),tenbenhnhan";
        dsNoiTru.ExportToExcel();
    }
    void dsNoiTru_AfterExportToExcel()
    {
        Response.Write("../ReportOutput/" + dsNoiTru.OutputFileName);
    }
    #endregion
}



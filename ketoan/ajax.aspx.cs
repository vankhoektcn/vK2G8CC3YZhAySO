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
using System.IO;
using System.Data.SqlClient;
using System.Text;

public partial class ajax : System.Web.UI.Page
{
    //public SqlConnection Conn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = data.escape(Request.QueryString["do"]);
        switch (action)
        {
            case "DanhSachTaiKhoan_Jquery": DanhSachTaiKhoan_Jquery(); break;
            //=============================KẾ TOÁN MINH ĐỨC =================================================
            case "TaoMaSoTuDong": TaoMaSoTuDong(); break;
            case "TaoMaSoTuDong_TheoNgayTuChon": TaoMaSoTuDong_TheoNgayTuChon(); break;
            case "TestMaTaiKhoan": TestMaTaiKhoan(); break;
            case "TestSoHoaDon": TestSoHoaDon(); break;
            case "TestTrangThaiHoaDon": TestTrangThaiHoaDon(); break;
            case "DanhSachTaiKhoan_Jquery2": DanhSachTaiKhoan_Jquery2(); break;
            case "DanhSachTaiKhoanNganHang": DanhSachTaiKhoanNganHang(); break;
            case "LoadDanhSachKhachHang_CongNo": LoadDanhSachKhachHang_CongNo(); break;            
            case "LoadDanhSachNhaCungCap3": LoadDanhSachNhaCungCap3(); break;
            case "LoadDanhSachBenhNhan": LoadDanhSachBenhNhan(); break;
            case "LoadDanhSachBenhNhan2": LoadDanhSachBenhNhan2(); break;
            case "LoadDanhSachKhachHang": LoadDanhSachKhachHang(); break;
            case "LoadDanhSachKhachHang2": LoadDanhSachKhachHang2(); break;
            case "LoadDanhSachNhaCungCap": LoadDanhSachNhaCungCap(); break;
            case "LoadDanhSachNhaCungCap4": LoadDanhSachNhaCungCap4(); break;
            case "LoadDanhSachNhaCungCap2": LoadDanhSachNhaCungCap2(); break;
            case "LoadDanhSachNhaCungCap_UNC": LoadDanhSachNhaCungCap_UNC(); break;
            case "LoadDanhSachPhieuThu_byBenhNhan": LoadDanhSachPhieuThu_byBenhNhan(); break;
            case "LoadDanhSachPhieuThu_byKhachLe": LoadDanhSachPhieuThu_byKhachLe(); break;
            case "CapNhatTrangThaiDoanhThu": CapNhatTrangThaiDoanhThu(); break;
            case "LoadDanhSachHoaDon": LoadDanhSachHoaDon(); break;
            case "LoadDanhSachHangHoa": LoadDanhSachHangHoa(); break;

            case "LuuPhieuThu": LuuPhieuThu(); break;
            case "LuuChiTietPhieuThuHoaDon": LuuChiTietPhieuThuHoaDon(); break;
            case "LuuChiTietPhieuThuKhac": LuuChiTietPhieuThuKhac(); break;
            case "LuuSoCai_PhieuThuHoaDon": LuuSoCai_PhieuThuHoaDon(); break;
            case "LuuSoCai_PhieuThuKhac": LuuSoCai_PhieuThuKhac(); break;
            case "DanhSachPhieuThu": DanhSachPhieuThu(); break;
            case "DanhSachPhieuThuOfBenhNhan": DanhSachPhieuThuOfBenhNhan(); break;
            case "DanhSachPhieuThuOfKhachHang": DanhSachPhieuThuOfKhachHang(); break;
            case "ChiTietPhieuThuHoaDon": ChiTietPhieuThuHoaDon(); break;
            case "ChiTietPhieuThuKhac": ChiTietPhieuThuKhac(); break;
            case "XoaChiTietPhieuThu": XoaChiTietPhieuThu(); break;
            case "XoaPhieuThu": XoaPhieuThu(); break;
            case "XoaSoCaiBySoPT": XoaSoCaiBySoPT(); break;

            case "LuuPhieuChi": LuuPhieuChi(); break;
            case "LuuChiTietPhieuChi": LuuChiTietPhieuChi(); break;
            case "LuuSoCai_PhieuChiKhac": LuuSoCai_PhieuChiKhac(); break;
            case "XoaChiTietPhieuChi": XoaChiTietPhieuChi(); break;
            case "XoaPhieuChi": XoaPhieuChi(); break;
            case "XoaSoCai_PhieuChi": XoaSoCai_PhieuChi(); break;
            case "DanhSachPhieuChi": DanhSachPhieuChi(); break;
            case "LoadPhieuChiByIDPhieuChi": LoadPhieuChiByIDPhieuChi(); break;
            case "ChiTietPhieuChiKhacBySoPhieuChi": ChiTietPhieuChiKhacBySoPhieuChi(); break;

            case "SaveHoaDonDichVu": SaveHoaDonDichVu(); break;
            case "SaveChiTietHoaDonDichVu": SaveChiTietHoaDonDichVu(); break;
            case "XoaChiTietHoaDonDichVu": XoaChiTietHoaDonDichVu(); break;
            case "XoaHoaDonDichVu": XoaHoaDonDichVu(); break;
            case "LoadDanhSachPhieuThuOfHoaDonDichVu": LoadDanhSachPhieuThuOfHoaDonDichVu(); break;
            case "DanhSachHoaDon": DanhSachHoaDon(); break;
            case "LoadChiTietHoaDonDichVu": LoadChiTietHoaDonDichVu(); break;

            case "Luu_UyNhiemChi": Luu_UyNhiemChi(); break;
            case "Luu_UyNhiemThu": Luu_UyNhiemThu(); break;
            case "Luu_ChiTietUyNhiemChi": Luu_ChiTietUyNhiemChi(); break;
            case "Luu_ChiTietUyNhiemThu": Luu_ChiTietUyNhiemThu(); break;
            case "LuuSoCaiUyNhiemChi": LuuSoCaiUyNhiemChi(); break;
            case "LuuSoCaiUyNhiemThu": LuuSoCaiUyNhiemThu(); break;
            case "XoaChiTietUyNhiemChi": XoaChiTietUyNhiemChi(); break;
            case "XoaSoCai": XoaSoCai(); break;
            case "LoadChiTietUyNhiemChiBySoUNC": LoadChiTietUyNhiemChiBySoUNC(); break;
            case "LoadChiTietUyNhiemThuBySoUNT": LoadChiTietUyNhiemThuBySoUNT(); break;
            case "LoadUyNhiemChiBySoUNC": LoadUyNhiemChiBySoUNC(); break;
            case "LoadUyNhiemThuBySoUNT": LoadUyNhiemThuBySoUNT(); break;
            case "LoadDanhSachUyNhiemChi": LoadDanhSachUyNhiemChi(); break;
            case "LoadDanhSachGiayBaoCo": LoadDanhSachGiayBaoCo(); break;
            case "XoaUyNhiemChi": XoaUyNhiemChi(); break;
            case "XoaUyNhiemThu": XoaUyNhiemThu(); break;

            case "LuuSoDuDauKyTaiKhoan": LuuSoDuDauKyTaiKhoan(); break;
            case "LoadSoDuDauKyTaiKhoanByNam": LoadSoDuDauKyTaiKhoanByNam(); break;
            case "LuuCongNoDauKy": LuuCongNoDauKy(); break;
            case "LoadDanhSachCongNoDauKy": LoadDanhSachCongNoDauKy(); break;

            //case "LoadDanhMucTaiSan": LoadDanhMucTaiSan(); break;
            case "LuuKhauHaoTaiSan": LuuKhauHaoTaiSan(); break;
            case "XoaKhauHaoTaiSanByThangNam": XoaKhauHaoTaiSanByThangNam(); break;

            case "LuuGiamTaiSanCoDinh": LuuGiamTaiSanCoDinh(); break;
            case "LuuGiamTaiSanCoDinh_ChiTiet_SoCai": LuuGiamTaiSanCoDinh_ChiTiet_SoCai(); break;
            case "XoaPhieuGiamTaiSanCoDinh": XoaPhieuGiamTaiSanCoDinh(); break;
            case "XoaPhieuGiamTaiSanCoDinh_ChiTiet_SoCai": XoaPhieuGiamTaiSanCoDinh_ChiTiet_SoCai(); break;
            case "LoadPhieuGiamTaiSan": LoadPhieuGiamTaiSan(); break;
            case "LoadChiTietPhieuGiamTaiSan": LoadChiTietPhieuGiamTaiSan(); break;
            case "TapHopKhauHaoTaiSan": TapHopKhauHaoTaiSan(); break;
            case "LuuPhanBoTaiSan_SoCai": LuuPhanBoTaiSan_SoCai(); break;
            case "CheckIsPhieuPhanBoTaiSan": CheckIsPhieuPhanBoTaiSan(); break;
            case "XoaPhanBoTaiSan_SoCai": XoaPhanBoTaiSan_SoCai(); break;
            case "XoaCongCuDungCu_SoCai": XoaCongCuDungCu_SoCai(); break;

            case "CheckCCDC_KhauHao": CheckCCDC_KhauHao(); break;
            case "XoaDanhMucCongCuDungCu": XoaDanhMucCongCuDungCu(); break;
            case "TapHopKhauHaoCongCuDungCu": TapHopKhauHaoCongCuDungCu(); break;
            case "LuuPhanBoCCDC_SoCai": LuuPhanBoCCDC_SoCai(); break;
            case "LoadDanhSachCongCuDungCu": LoadDanhSachCongCuDungCu(); break;
            case "XoaKhauHaoCCDCByThangNam": XoaKhauHaoCCDCByThangNam(); break;
            case "LuuKhauHaoCCDC": LuuKhauHaoCCDC(); break;
            case "CheckIsPhieuPhanBoCCDC": CheckIsPhieuPhanBoCCDC(); break;
            case "XoaPhanBoCongCuDungCu_SoCai": XoaPhanBoCongCuDungCu_SoCai(); break;
            case "LuuPhanBoCongCuDungCu_SoCai": LuuPhanBoCongCuDungCu_SoCai(); break;
            case "Luuthamso": Luuthamso(); break;
            case "TinhKhauHao": TinhKhauHao(); break;
            case "kiemtrathongtinTable": kiemtrathongtintable(); break;
            case "themkhachhang": themkhachhang(); break;
            case "themnhacungcap": themnhacungcap(); break;
            case "loadSoNhatKyChung": loadSoNhatKyChung(); break;
            case "luuchitiethoadon_dvkh": luuchitiethoadon_dvkh(); break;
            case "luuhoadondvkh_socai": luuhoadondvkh_socai(); break;
            case "SaveHoaDonDichVu_KH": SaveHoaDonDichVu_KH(); break;
            case "loaddanhsachHDKH_CT": loaddanhsachHDKH_CT(); break;
            case "ngoaitesearch": NgoaiTeSearch(); break;
            case "PageLoadNgoaiTe": PageLoadNgoaiTe(); break;
            case "ket_noi_dl": ket_noi_dl(); break;
            case "LoadDanhSachTaiSan":LoadDanhSachTaiSan();break;
            case "LoadDSPhieuThu_byBenhNhan": LoadDSPhieuThu_byBenhNhan(); break;
            case "SaveHoaDonBanHang": SaveHoaDonBanHang(); break;
            case "XoaChiTietHoaDonBanHang": XoaChiTietHoaDonBanHang(); break;
            case "SaveChiTietHoaDonBanHang": SaveChiTietHoaDonBanHang(); break;
            case "LoadDanhSachPhieuThuHoaDonBanHang": LoadDanhSachPhieuThuHoaDonBanHang(); break;
            case "LoadChiTietHoaDonBanHang": LoadChiTietHoaDonBanHang(); break;
            case "LoadDanhSachKhachHang_UNT": LoadDanhSachKhachHang_UNT(); break;
            case "LuuPhieu_TT_Tam_Ung": LuuPhieu_TT_Tam_Ung(); break;
            case "XoaChiTietPhieu_TT_Tam_Ung": XoaChiTietPhieu_TT_Tam_Ung(); break;
            case "XoaSoCai_Phieu_TT_Tam_Ung": XoaSoCai_Phieu_TT_Tam_Ung(); break;
            case "LuuChiTietPhieu_TT_Tam_Ung": LuuChiTietPhieu_TT_Tam_Ung(); break;
            case "ChiTietPhieu_TT_Tam_Ung": ChiTietPhieu_TT_Tam_Ung(); break;
            case "DanhSachPhieu_TT_Tam_Ung": DanhSachPhieu_TT_Tam_Ung(); break;
            case "XoaPhieu_TT_Tam_Ung": XoaPhieu_TT_Tam_Ung(); break;
            case "ChiTietPhieu_TT_Tam_Ung_BySoPhieuChi": ChiTietPhieu_TT_Tam_Ung_BySoPhieuChi(); break;
            case "LoadPhieu_TT_Tam_Ung_ByIDPhieuChi": LoadPhieu_TT_Tam_Ung_ByIDPhieuChi(); break;
            case "DanhSachHoaDonDauVao": DanhSachHoaDonDauVao(); break;
            case "LuuPhieuTongHop": LuuPhieuTongHop(); break; 
            case "LoadChiTietThanhToanCongNo": LoadChiTietThanhToanCongNo(); break; 
            case "XoaSoCai_PhieuTongHop": XoaSoCai_PhieuTongHop(); break; 
            case "XoaPhieuTongHop": XoaPhieuTongHop(); break; 
            case "XoaChiTietPhieuTongHop": XoaChiTietPhieuTongHop(); break;
            case "LuuChiTietPhieuTongHop": LuuChiTietPhieuTongHop(); break;
            case "LuuSoCai_PhieuTongHop": LuuSoCai_PhieuTongHop(); break;
            case "DanhSachPhieuTongHop": DanhSachPhieuTongHop(); break;
            case "LoadDanhSachDoiTuong": LoadDanhSachDoiTuong(); break;
            case "LoadDanhSachDoiTuong2": LoadDanhSachDoiTuong2(); break;
            case "LoadPhieuTongHop": LoadPhieuTongHop(); break;
            case "XemChiTietPhieuTongHop": XemChiTietPhieuTongHop(); break;
            case "phongSearch": phongSearch(); break;
            case "LoadDanhSachKhachHang_BN": LoadDanhSachKhachHang_BN(); break;
            case "xoaphieuketoan": xoaphieuketoan(); break;
            case "kiemtraxoasuahoadon": kiemtraxoasuahoadon(); break;
            case "XoaHoaDonBanHang": XoaHoaDonBanHang(); break;               
            case "loaddanhsachHDKhac_CT": loaddanhsachHDKhac_CT(); break;
            case "luuchitiethoadon_dvkhac": luuchitiethoadon_dvkhac(); break;
            case "DanhSachPhieuChi_TTTU": DanhSachPhieuChi_TTTU(); break;
            case "LoadPhieuTTTU": LoadPhieuTTTU(); break;
            case "DanhSachPhieuThu_Khoa": DanhSachPhieuThu_Khoa(); break;
            case "updatedsdathu": updatedsdathu(); break;
            case "doanhthukhoa": doanhthukhoa(); break;
            case "TaoMaSoTuDong_minhduc": TaoMaSoTuDong_minhduc(); break;
            case "XoaPhieuThu_fault": XoaPhieuThu_fault(); break;   
            case "XoaPhieuChi_fault": XoaPhieuChi_fault(); break;
            case "XoaUyNhiemChi_fault": XoaUyNhiemChi_fault(); break;
            case "ket_chuyen_so_du_tk": ket_chuyen_so_du_tk(); break;                                    
        }
    }
    private void PageLoadNgoaiTe()
    {
        DataTable table = DataAcess.Connect.GetTable("select top 1 ngoai_te_id,ten_nt, ty_gia from dmngoaite");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    #region Code của Ngọc

    public void XoaPhanBoCongCuDungCu_SoCai()
    {
        bool rs = false;
        try
        {

            string SoKhauHao = Request.QueryString["SoKhauHao"];
            string sql = "exec spPhan_bo_CCDC_So_Cai_Delete '" + SoKhauHao + "'";
            rs = DataAcess.Connect.ExecSQL(sql);
        }
        catch
        {
            rs = false;
        }
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }
    public void LuuPhanBoCongCuDungCu_SoCai()
    {
        bool rs = false;
        try
        {
            string SoCaiID = "null";
            string SoKhauHao = Request.QueryString["SoKhauHao"];
            string NgayKH = Request.QueryString["NgayKH"];
            string DienGiai = Request.QueryString["DienGiai"];

            string TKChiPhi_list = Request.QueryString["TKChiPhi"];
            string[] TKChiPhi = TKChiPhi_list.Split(';');

            string TKKhauHao_list = Request.QueryString["TKKhauHao"];
            string[] TKKhauHao = TKKhauHao_list.Split(';');

            string GiaTriKH_list = Request.QueryString["GiaTriKH"];
            string[] GiaTriKH = GiaTriKH_list.Split(';');

            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);

            for (int i = 0; i < TKChiPhi.Length; i++)
            {
                if (TKChiPhi[i] != "")
                {
                    string sql = "exec spPhan_bo_CCDC_So_Cai_Save '" +  SoKhauHao + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayKH) + "',N'" + DienGiai + "','" + TKChiPhi[i] + "','" + TKKhauHao[i] + "','" + GiaTriKH[i] + "',N'" + UserDau + "',N'" + UserCuoi + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }
        }
        catch
        {
            rs = false;
        }
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }

    public void CheckIsPhieuPhanBoCCDC()
    {
        int thang = Int32.Parse(Request.QueryString["thang"].ToString());
        int nam = Int32.Parse(Request.QueryString["nam"].ToString());
        string rs = "";
        string sql = "select top(1) ma_ct from So_Cai where Ma_CT like 'KHCC%' and Month(Ngay_lap_ct)=" + thang + " and year(Ngay_Lap_Ct)=" + nam;
        try
        {
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rs = dt.Rows[0]["ma_ct"].ToString();
            }
            else
                rs = "";
        }
        catch { }
        Response.Write(rs);
    }
    public void XoaKhauHaoCCDCByThangNam()
    {
        try
        {
            int Thang = Int32.Parse(Request.QueryString["Thang"].ToString());
            int Nam = Int32.Parse(Request.QueryString["Nam"].ToString());
            int rs = 0;
            rs = IsExitsKhauHaoCCDC("", Thang, Nam);
            if (rs == 1)
            {
                string sql = "exec spCCDC_Delete '" + Thang + "','" + Nam + "'";
                rs = DataAcess.Connect.Exec(sql);
            }
            else
                rs = 2;
            Response.Write(rs);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }
    }
    public void LoadDanhSachCongCuDungCu()
    {
        int thang = Int32.Parse(Request.QueryString["Thang"].ToString());
        int nam = Int32.Parse(Request.QueryString["Nam"].ToString());
        int songay = DateTime.DaysInMonth(nam, thang);
        //lay ngay dau thang
        //int songay = 1;
        string date = nam.ToString() + "/" + thang.ToString() + "/" + songay.ToString(); ;
        string sql = "exec spCCDC_Load  '" + date + "'";
        string rs = "";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //ccdc.Ma_CCDC,dm.Ten_CCDC,dm.Nguyen_Gia,dm.So_Thang_Khau_Hao ,dm.TK_Phan_Bo ,dm.TK_Chi_Phi ,ccdc.GiaTriKH  ,ccdc.Dien_Giai
                rs += "&" + table.Rows[i][0] + "|" + table.Rows[i][1] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + "|" + table.Rows[i][4] + "|" + table.Rows[i][5] + "|" + table.Rows[i][6] + "|" + table.Rows[i][7] + "|" + table.Rows[i][8];
            }
        }
        Response.Write(rs);
        //DateTime b = Convert.ToDateTime("11/15/2011");
        //double a = tinhkhauhaothang(b, 5, 5000000, 11, 2011);
    }
    public void LuuPhanBoCCDC_SoCai()
    {
        bool rs = false;
        try
        {
            string SoCaiID = "null";
            string SoKhauHao = Request.QueryString["SoKhauHao"];
            string NgayKH = Request.QueryString["NgayKH"];
            string DienGiai = Request.QueryString["DienGiai"];

            string TKChiPhi_list = Request.QueryString["TKChiPhi"];
            string[] TKChiPhi = TKChiPhi_list.Split(';');

            string TKKhauHao_list = Request.QueryString["TKKhauHao"];
            string[] TKKhauHao = TKKhauHao_list.Split(';');

            string GiaTriKH_list = Request.QueryString["GiaTriKH"];
            string[] GiaTriKH = GiaTriKH_list.Split(';');

            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);

            for (int i = 0; i < TKChiPhi.Length; i++)
            {
                if (TKChiPhi[i] != "")
                {
                    string sql = "exec spPhan_bo_CCDC_So_Cai_Save " + SoCaiID + ",'" + SoKhauHao + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayKH) + "',N'" + DienGiai + "','" + TKChiPhi[i] + "','" + TKKhauHao[i] + "','" + GiaTriKH[i] + "',N'" + UserDau + "',N'" + UserCuoi + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }
        }
        catch
        {
            rs = false;
        }
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }
    public int IsExitsKhauHaoCCDC(string MaCCDC, int Thang, int Nam)
    {
        int rs = 0;

        string sqlCheck = "select * from KhauHaoCongCuDungCu where 1=1  ";

        if (MaCCDC != "")
        {
            sqlCheck += "  and Ma_ccdc ='" + MaCCDC + "'";
        }
        if (Thang != 0)
        {
            sqlCheck += "   and thang = " + Thang;
        }
        if (Nam != 0)
        {
            sqlCheck += "   and nam = " + Nam;
        }
        DataTable dt = DataAcess.Connect.GetTable(sqlCheck);
        if (dt != null && dt.Rows.Count > 0)
        {
            rs = 1;
        }
        else
            rs = 0;

        return rs;
    }
    public void LuuKhauHaoCCDC()
    {
        int rs = 0;
        try
        {
            string TypeSave = Request.QueryString["TypeSave"].ToString();
            string month = Request.QueryString["Thang"].ToString();
            string year = Request.QueryString["Nam"].ToString();
            int Thang = 0;
            int Nam = 0;
            if (month != "")
                Thang = Int32.Parse(month);
            if (year != "")
                Nam = Int32.Parse(year);
            string DienGiai = Request.QueryString["DienGiai"].ToString();

            if (TypeSave == "Save")
            {

                string MaCCDC_list = Request.QueryString["MaCCDC"];
                string[] MaCCDC = MaCCDC_list.Split(';');

                string GiaTriKH_list = Request.QueryString["GiaTriKhauHao"];
                string[] GiaTriKH = GiaTriKH_list.Split(';');

                string Tkchiphi_list = Request.QueryString["tkchiphi"];
                string[] tk_chiphi = Tkchiphi_list.Split(';');

                string NgayKhauHao_list = Request.QueryString["Ngaykhauhao"];
                string[] ngay_khau_hao = NgayKhauHao_list.Split(';');
                double gtpb = 0;
                if (MaCCDC.Length > 0)
                {
                    for (int i = 0; i < GiaTriKH.Length; i++)
                    {
                        if (GiaTriKH[i] != "" && GiaTriKH[i] != "0")
                        {
                            gtpb = Convert.ToDouble(GiaTriKH[i].Replace(",", ""));
                            string sql = "exec spPhanBo_CCDC_Save '" + MaCCDC[i] + "','" + Thang + "','" + Nam + "'," + gtpb + ",N'" + DienGiai + "','" + tk_chiphi[i] + "','" + StaticData.CheckDate_kt(ngay_khau_hao[i]) + "'";
                            rs = DataAcess.Connect.Exec(sql);
                        }
                    }
                }
            }
            else
                if (TypeSave == "Update")
                {
                    string MaCCDC = Request.QueryString["MaCCDC"];
                    string GiaTriKH = Request.QueryString["GiaTriKhauHao"];
                    string tk_chiphi2 = Request.QueryString["tkchiphi"];
                    double gtpb2 = Convert.ToDouble(GiaTriKH.Replace(",", ""));
                    //rs = IsExitsKhauHaoCCDC(MaCCDC, Thang, Nam);                   
                    if (GiaTriKH != "" && GiaTriKH != "0")
                    {
                        rs = 0;
                        string sql = "exec spPhanBo_CCDC_Save null,'" + MaCCDC + "','" + Thang + "','" + Nam + "'," + gtpb2 + ",N'" + DienGiai + "','" + tk_chiphi2;
                        rs = DataAcess.Connect.Exec(sql);
                        if (rs == 1)
                            rs = 1;
                        else
                            rs = 0;
                    }
                    else
                    {
                        rs = 2;//MaCCDC + thang +  nam chua co trong ban khau hao tai san
                    }
                }
            Response.Write(rs);

        }
        catch (Exception e)
        {
            Response.Write(rs);
        }
    }
    public void TapHopKhauHaoCongCuDungCu()
    {
        string rs = "";
        try
        {
            int Thang = Int32.Parse(Request.QueryString["Thang"].ToString());
            int Nam = Int32.Parse(Request.QueryString["Nam"].ToString());
            string sql = "";
            sql = "Exec spTapHopKhauHao_CCDC " + Thang + "," + Nam;
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rs += "&" + dt.Rows[i]["tk_chi_phi"].ToString() + "|" + dt.Rows[i]["TKKhauHao"].ToString() + "|" + dt.Rows[i]["giatrikh"].ToString();
            }
        }
        catch
        {
            rs = "";
        }
        Response.Write(rs);

    }
    public void XoaDanhMucCongCuDungCu()
    {
        string SoPhieuCCDC = Request.QueryString["SoPhieuCCDC"];
        string sql = "spDanhMucCCDC_Delete '" + SoPhieuCCDC + "'";
        int rs = DataAcess.Connect.Exec(sql);
        if (rs > 0)
        {
            Response.Write(1);
        }
        else
            Response.Write(0);
    }
    public void CheckCCDC_KhauHao()
    {
        string Ma_CCDC = Request.QueryString["MaCCDC"];
        string sql = "select * from KhauHaoCongCuDungCu where Ma_CCDC = @MaCCDC";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            Response.Write(1);
        }
        else
        {
            Response.Write(0);
        }
    }

    public void XoaCongCuDungCu_SoCai()
    {
        string SoPhieuCCDC = Request.QueryString["SoPhieuCCDC"];
        string sql = "spCCDC_SoCai_Delete '" + SoPhieuCCDC + "'";
        int rs = DataAcess.Connect.Exec(sql);
        if (rs > 0)
        {
            Response.Write(1);
        }
        else
            Response.Write(0);
    }


    public void CheckIsPhieuPhanBoTaiSan()
    {
        int thang = Int32.Parse(Request.QueryString["thang"].ToString());
        int nam = Int32.Parse(Request.QueryString["nam"].ToString());
        string rs = "";
        try
        {
            string sql = "select top(1) ma_ct from So_Cai where Ma_CT like 'KHTS%' and Month(Ngay_lap_ct)=" + thang + " and year(Ngay_Lap_Ct)=" + nam;
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                rs = dt.Rows[0]["ma_ct"].ToString();
            }
            else
                rs = "";
        }
        catch
        {
            rs = "";
        }
        Response.Write(rs);
    }
    public void XoaPhanBoTaiSan_SoCai()
    {
        bool rs = false;
        try
        {

            string SoKhauHao = Request.QueryString["SoKhauHao"];
            string sql = "exec spPhan_bo_TSCD_So_Cai_Delete '" + SoKhauHao + "'";
            rs = DataAcess.Connect.ExecSQL(sql);

        }
        catch
        {
            rs = false;
        }
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }
    public void LuuPhanBoTaiSan_SoCai()
    {
        bool rs = false;
        try
        {
            string SoCaiID = "null";
            string SoKhauHao = Request.QueryString["SoKhauHao"];
            string NgayKH = Request.QueryString["NgayKH"];
            string DienGiai = Request.QueryString["DienGiai"];

            string TKChiPhi_list = Request.QueryString["TKChiPhi"];
            string[] TKChiPhi = TKChiPhi_list.Split(';');

            string TKKhauHao_list = Request.QueryString["TKKhauHao"];
            string[] TKKhauHao = TKKhauHao_list.Split(';');

            string GiaTriKH_list = Request.QueryString["GiaTriKH"];
            string[] GiaTriKH = GiaTriKH_list.Split(';');

            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);

            for (int i = 0; i < TKChiPhi.Length; i++)
            {
                if (TKChiPhi[i] != "")
                {
                    string sql = "exec spPhan_bo_TSCD_So_Cai_Save " + SoCaiID + ",'" + SoKhauHao + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayKH) + "',N'" + DienGiai + "','" + TKChiPhi[i] + "','" + TKKhauHao[i] + "','" + GiaTriKH[i] + "',N'" + UserDau + "',N'" + UserCuoi + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }
        }
        catch
        {
            rs = false;
        }
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }

    public void TapHopKhauHaoTaiSan()
    {
        string rs = "";
        try
        {
            int Thang = Int32.Parse(Request.QueryString["Thang"].ToString());
            int Nam = Int32.Parse(Request.QueryString["Nam"].ToString());
            string sql = "";
            sql = "Exec spTapHopKhauHao_TSCD " + Thang + "," + Nam;
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rs += "&" + dt.Rows[i]["tkchiphi"].ToString() + "|" + dt.Rows[i]["tkkhauhao"].ToString() + "|" + dt.Rows[i]["giatrikh"].ToString();
                }
            }
            else
                rs = "";
        }
        catch
        {
            rs = "";
        }
        Response.Write(rs);

    }
    public void LoadPhieuGiamTaiSan()
    {
        string rs = ""; ;

        string SoPG = Request.QueryString["SoPG"];
        string TuNgay = mdlCommonFunction.ChangeDateTo_MM_dd(Request.QueryString["TuNgay"].ToString());
        string DenNgay = mdlCommonFunction.ChangeDateTo_MM_dd(Request.QueryString["DenNgay"].ToString());
        string MaTS = Request.QueryString["MaTS"];



        string sql = "select So_Phieu_Giam,Ma_TS,dmts.TenTaiSan,convert(varchar,Ngay_Giam,103)Ngay_Giam,NguyenGia,TKChiPhi,TKKhauHao,Dien_Giai " +
                     "  from Giam_TSCD g left join DanhMucTaiSan dmts on dmts.MaTS = g.Ma_TS " +
                     "  where 1=1 ";
        if (SoPG != "")
        {
            sql += " and So_Phieu_Giam ='" + SoPG + "'";

        }
        if (TuNgay != "" && DenNgay != "")
        {
            sql += "   and ( Ngay_Giam between '" + TuNgay + "' and '" + DenNgay + ")'";
        }
        else
        {
            if (TuNgay != "")
            {
                sql += "   and Ngay_Giam = '" + TuNgay + "'";
            }
            else
                if (DenNgay != "")
                {
                    sql += "   and Ngay_Giam = '" + DenNgay + "'";
                }
        }
        if (MaTS != "")
        {
            sql += " and g.Ma_TS = '" + MaTS + "'";
        }

        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rs += "&" + dt.Rows[i]["So_Phieu_Giam"].ToString() + "|" + dt.Rows[0]["Ma_TS"].ToString() + "|" + dt.Rows[i]["TenTaiSan"].ToString() + "|" + dt.Rows[i]["Ngay_Giam"].ToString() + "|" + dt.Rows[i]["NguyenGia"].ToString() + "|" + dt.Rows[i]["TKChiPhi"].ToString() + "|" + dt.Rows[i]["TKKhauHao"].ToString() + "|" + dt.Rows[i]["Dien_Giai"].ToString();
            }
        }
        else
            rs = "";
        Response.Write(rs);
    }
    public void LoadChiTietPhieuGiamTaiSan()
    {
        string rs = ""; ;
        string SoPG = Request.QueryString["SoPG"];
        string sql = "select so_phieu_giam,TK_Co,TK_No,Tien,Dien_Giai " +
                    "  From Giam_TSCD_CT " +
                    "  Where so_phieu_giam = '" + SoPG + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count > 0 && dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rs += "&" + dt.Rows[i]["so_phieu_giam"].ToString() + dt.Rows[i]["TK_Co"].ToString() + dt.Rows[i]["TK_No"].ToString() + dt.Rows[i]["Tien"].ToString() + dt.Rows[i]["Dien_Giai"].ToString();
            }
        }
        else
            rs = "";
        Response.Write(rs);
    }
    public void XoaPhieuGiamTaiSanCoDinh()
    {
        int rs = 0;
        try
        {
            string so_phieu_giam = Request.QueryString["SoPG"];
            string sql = "exec spGiam_TSCD_Delete '" + so_phieu_giam + "'";
            rs = DataAcess.Connect.Exec(sql);
        }
        catch
        {
            rs = 0;
        }
        Response.Write(rs);
    }
    public void XoaPhieuGiamTaiSanCoDinh_ChiTiet_SoCai()
    {
        int rs = 0;
        try
        {
            string so_phieu_giam = Request.QueryString["SoPG"];
            string sql = "exec spGiam_TSCD_CT_Delete '" + so_phieu_giam + "'";
            rs = DataAcess.Connect.Exec(sql);
        }
        catch
        {
            rs = 0;
        }
        Response.Write(rs);
    }
    public void LuuGiamTaiSanCoDinh_ChiTiet_SoCai()
    {
        bool rs = false;
        try
        {
            string giam_tscd_ct_id = "null";
            string so_cai_id = "null";
            string so_phieu_giam = Request.QueryString["SoPG"];

            string ngay_giam = Request.QueryString["NgayGiam"];

            string tk_no_list = Request.QueryString["TKNo"];
            string[] tk_no = tk_no_list.Split(';');

            string tk_co_list = Request.QueryString["TKCo"];
            string[] tk_co = tk_co_list.Split(';');

            string so_tien_list = Request.QueryString["SoTien"];
            string[] so_tien = so_tien_list.Split(';');

            string dien_giai_list = Request.QueryString["DienGiai"];
            string[] dien_giai = dien_giai_list.Split(';');
            string user_dau = "Tăng Thúy Ngọc";
            string user_cuoi = "Cyber Tang";

            if (tk_no.Length > 0)
            {
                for (int i = 0; i < tk_no.Length; i++)
                {
                    if (tk_no[i] != "" && tk_co[i] != "")
                    {
                        string sql1 = "exec spGiam_TSCD_CT_Save  " + giam_tscd_ct_id + ",'" + so_phieu_giam + "','" + tk_no[i] + "','" + tk_co[i] + "','" + so_tien[i] + "',N'" + dien_giai[i] + "',N'" + user_dau + "',N'" + user_cuoi + "'";
                        rs = DataAcess.Connect.ExecSQL(sql1);
                    }
                    if (rs)
                    {
                        string sql2 = "exec spGiamTSCD_SoCai_Save  " + so_cai_id + ",'" + so_phieu_giam + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(ngay_giam) + "','" + tk_no[i] + "','" + tk_co[i] + "','" + so_tien[i] + "',N'" + dien_giai[i] + "'";
                        rs = DataAcess.Connect.ExecSQL(sql2);
                    }
                }
            }

        }
        catch
        {
            rs = false;
        }
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }
    public void LuuGiamTaiSanCoDinh()
    {
        bool rs = false;
        try
        {
            string giam_tscd_id = "null";
            string so_phieu_giam = Request.QueryString["SoPG"];
            string ma_ts = Request.QueryString["MaTS"];
            string ngay_giam = Request.QueryString["NgayGiam"];
            string dien_giai = Request.QueryString["DienGiai"];
            string loai_ts = Request.QueryString["LoaiTS"];
            string user_dau = "Tăng Thúy Ngọc";
            string user_cuoi = "Cyber Tang";
            string sql = "exec spGiam_TSCD_Save " + giam_tscd_id + ",'" + so_phieu_giam + "','" + ma_ts + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(ngay_giam) + "',N'" + dien_giai + "','" + loai_ts + "',N'" + user_dau + "',N'" + user_cuoi + "'";
            rs = DataAcess.Connect.ExecSQL(sql);
        }
        catch
        {
            rs = false;
        }
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);

    }


    public void XoaKhauHaoTaiSanByThangNam()
    {
        try
        {
            int Thang = Int32.Parse(Request.QueryString["Thang"].ToString());
            int Nam = Int32.Parse(Request.QueryString["Nam"].ToString());
            int rs = 0;
            rs = IsExitsTaiSanKhauHao("", Thang, Nam);
            if (rs == 1)
            {
                rs = 0;
                string sql = "exec spTSCD_Delete '" + Thang + "','" + Nam + "'";
                rs = DataAcess.Connect.Exec(sql);
            }
            else
                rs = 2;
            Response.Write(rs);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }
    }

    public int IsExitsTaiSanKhauHao(string MaTS, int Thang, int Nam)
    {
        int rs = 0;
        string sqlCheck = "select * from KhauHaoTaiSan where 1=1  ";

        if (MaTS != "")
        {
            sqlCheck += "  and MaTS = '" + MaTS;
        }
        if (Thang != 0)
        {
            sqlCheck += "   and thang = '" + Thang;
        }
        if (Nam != 0)
        {
            sqlCheck += "   and nam ='" + Nam;
        }
        DataTable dt = DataAcess.Connect.GetTable(sqlCheck);
        if (dt != null && dt.Rows.Count > 0)
        {
            rs = 1;
        }
        else
            rs = 0;
        return rs;
    }
    public void LuuKhauHaoTaiSan()
    {
        int rs = 0;
        try
        {
            string TypeSave = Request.QueryString["TypeSave"].ToString();
            string month = Request.QueryString["Thang"].ToString();
            string year = Request.QueryString["Nam"].ToString();
            int Thang = 0;
            int Nam = 0;
            if (month != "")
                Thang = Int32.Parse(month);
            if (year != "")
                Nam = Int32.Parse(year);
            string DienGiai = Request.QueryString["DienGiai"].ToString();

            if (TypeSave == "Save")
            {
                string MaTS_list = Request.QueryString["MaTS"];
                string[] MaTS = MaTS_list.Split(';');

                string GiaTriKH_list = Request.QueryString["GiaTriKhauHao"];
                string[] GiaTriKH = GiaTriKH_list.Split(';');

                string tkchiphi_list = Request.QueryString["tkchiphi"];
                string[] tkchiphi = tkchiphi_list.Split(';');

                string ngaykhauhao_list = Request.QueryString["ngaykhauhao"];
                string[] ngaykhauhao = ngaykhauhao_list.Split(';');
                double gtkh = 0;
                if (MaTS.Length > 0)
                {
                    for (int i = 0; i < GiaTriKH.Length; i++)
                    {
                        if (GiaTriKH[i] != "" && GiaTriKH[i] != "0")
                        {
                            gtkh = Convert.ToDouble(GiaTriKH[i].Replace(",", ""));
                            string sql = "exec spTSCD_Save '" + MaTS[i] + "','" + Thang + "','" + Nam + "'," + gtkh + ",N'" + DienGiai + "','" + tkchiphi[i] + "','" +StaticData.CheckDate_kt(ngaykhauhao[i].ToString()) + "'";
                            rs = DataAcess.Connect.Exec(sql);
                        }
                    }
                }
            }
            else
                if (TypeSave == "Update")
                {
                    string MaTS = Request.QueryString["MaTS"];
                    string GiaTriKH = Request.QueryString["GiaTriKhauHao"];
                    string tkchiphi = Request.QueryString["tkchiphi"];
                    string ngaykhauhao = Request.QueryString["ngaykhauhao"];
                    //rs = IsExitsTaiSanKhauHao(MaTS,Thang,Nam);                                        
                    if (GiaTriKH != "" && GiaTriKH != "0")
                    {
                        double gtkh1 = Convert.ToDouble(GiaTriKH.Replace(",", ""));
                        string sql = "exec spTSCD_Save '" + MaTS + "','" + Thang + "','" + Nam + "'," + gtkh1 + ",N'" + DienGiai + "','" + tkchiphi + "','" + ngaykhauhao + "'";
                        rs = DataAcess.Connect.Exec(sql);
                        if (rs == 1)
                            rs = 1;
                        else
                            rs = 0;
                    }
                    else
                    {
                        rs = 2;//MaTS + thang +  nam chua co trong ban khau hao tai san
                    }
                }
            Response.Write(rs);
        }
        catch (Exception e)
        {
            Response.Write(rs);
        }
    }
    public void LoadDanhSachTaiSan()
    {
        int thang = Int32.Parse(Request.QueryString["Thang"].ToString());
        int nam = Int32.Parse(Request.QueryString["Nam"].ToString());
        //int songay = 1;
        int songay = DateTime.DaysInMonth(nam, thang);
        //MinhDuc dung ngay cuoi thang        
        //Van Tam dung ngay dau thang
        string date = nam.ToString() + "/" + thang.ToString() + "/" + songay.ToString();
        string sql = "exec spTSCD_Load  '" + date + "'";
        string rs = "";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //MaTS,TenTaiSan ,NguyenGia,SoNamKH ,TKKhauHao,TKChiPhi,GiaTriKH = '',DienGiai = ''
                rs += "&" + table.Rows[i][0] + "|" + table.Rows[i][1] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + "|" + table.Rows[i][4] + "|" + table.Rows[i][5] + "|" + table.Rows[i][6].ToString() +"|" + table.Rows[i][7] + "|" + table.Rows[i][8];
            }
        }
        //DateTime b = Convert.ToDateTime("11/15/2011");
        //double a = tinhkhauhaothang(b, 5, 5000000, 12, 2011);
        Response.Write(rs);
    }
    //tinh khau hao cho tung ngay
    public double tinhkhauhaothang(DateTime ngaykhauhao, int sothangkhauhao, double nguyengia, int thangkh, int namkh)
    {
        //lay so ngay khau hao
        //lay thang khau hao
        int i = ngaykhauhao.Month;
        int year = ngaykhauhao.Year;
        int songaykh = 0;
        int thang = 0;
        int nam = 0;
        int thang_kq = 0;
        int nam_kq = 0;
        //for (int j = i + 1; j <= i + sothangkhauhao - 1; j++)
        //{
        //    if (j <= 12)
        //    {
        //        thang = j;
        //        nam = year;
        //    }
        //    else
        //    {
        //        //j >12
        //        if (j % 12 == 0)
        //        {
        //            thang = 12;
        //        }
        //        else
        //        {
        //            int a = j / 12;
        //            thang = j - (12 * a);
        //        }
        //        if (thang == 1)
        //            nam = year + 1;
        //    }
        //    songaykh += DateTime.DaysInMonth(nam, thang);
        //    if (thang == thangkh && nam == namkh)
        //    {
        //        thang_kq = thang;
        //        nam_kq = nam;
        //    }
        //}
        songaykh = DateTime.DaysInMonth(ngaykhauhao.Year, ngaykhauhao.Month) - (ngaykhauhao.Day - 1) + songaykh + (ngaykhauhao.Day - 1);
        //gia tri khau khao moi ngay
        double khauhaocuangay = 0;
        //so ngay khau hao theo chuan 360
        double songaykh_chuan = (360 * sothangkhauhao) / 12;
        khauhaocuangay = Math.Round(nguyengia / songaykh_chuan, 3);
        //tinh gia tri khau hao thang
        double giatri_kh_thang = 0;
        int songaytrongthang_kh = 0;
        if (ngaykhauhao.Month == thangkh && ngaykhauhao.Year == namkh)
        {
            //songaytrongthang_kh = DateTime.DaysInMonth(ngaykhauhao.Year, ngaykhauhao.Month) - (ngaykhauhao.Day - 1);
            //if (ngaykhauhao.Month == 2)
            //    songaytrongthang_kh = DateTime.DaysInMonth(ngaykhauhao.Year, ngaykhauhao.Month) - (ngaykhauhao.Day - 1);
            //else
            //    songaytrongthang_kh = 30 - (ngaykhauhao.Day - 1);
            songaytrongthang_kh = DateTime.DaysInMonth(ngaykhauhao.Year, ngaykhauhao.Month) - (ngaykhauhao.Day - 1);
            if (songaytrongthang_kh > 30)
                songaytrongthang_kh = 30;
            else
                songaytrongthang_kh = songaytrongthang_kh;
            giatri_kh_thang = Math.Round(songaytrongthang_kh * khauhaocuangay, 0);
        }
        else
            giatri_kh_thang = Math.Round(nguyengia / sothangkhauhao, 0);
            //if (thangkh == thang_kq && namkh == nam_kq)
            //{
            //    //songaytrongthang_kh = DateTime.DaysInMonth(nam_kq, thang_kq);
            //    if (thangkh == 2)
            //        songaytrongthang_kh = DateTime.DaysInMonth(namkh, thangkh);
            //    else
            //        songaytrongthang_kh = 30 ;                
            //    giatri_kh_thang = Math.Round(songaytrongthang_kh * khauhaocuangay, 0);
            //}
            //else
            //{
            //    //songaytrongthang_kh = ngaykhauhao.Day - 1;
            //    if (thangkh == 2)
            //        songaytrongthang_kh = DateTime.DaysInMonth(namkh,thangkh);
            //    else
            //        songaytrongthang_kh = 30;
            //    giatri_kh_thang = Math.Round(songaytrongthang_kh * khauhaocuangay, 0);
            //}
        return giatri_kh_thang;
    }
    public double tinhkhauhaothang2(DateTime ngaykhauhao, int sothangkhauhao, double nguyengia, int thangkh, int namkh)
    {        
        double giatri_kh_thang = 0;
        giatri_kh_thang = Math.Round(nguyengia / sothangkhauhao, 0);        
        return giatri_kh_thang;
    }
    public void TinhKhauHao()
    {
        string kq = "";
        DateTime ngaykhauhao = Convert.ToDateTime(StaticData.CheckDate_kt(Request.QueryString["ngaykhauhao"].ToString()));
        int sothangkhauhao = Convert.ToInt16(Request.QueryString["sothangkhauhao"].ToString());
        double nguyengia = Convert.ToDouble(Request.QueryString["nguyengia"].ToString());
        int thang = Convert.ToInt16(Request.QueryString["thang"].ToString());
        int nam = Convert.ToInt16(Request.QueryString["nam"].ToString());
        //tinh khau cho tu ngay su dung cho BV MinhDuc
        kq = tinhkhauhaothang(ngaykhauhao, sothangkhauhao, nguyengia, thang, nam).ToString();
        //tinh khau hao theo thang su dung cho PK Van Tam
        //kq = tinhkhauhaothang2(ngaykhauhao, sothangkhauhao, nguyengia, thang, nam).ToString();
        Response.Write(kq);
    }
    public void LoadDanhSachCongNoDauKy()
    {
        string type = Request.QueryString["type"];
        string nam = Request.QueryString["nam"];
        string tk = Request.QueryString["tk"];
        string ma_kh = Request.QueryString["ma_kh"];
        string strWhere = "";
        if (nam != "")
            strWhere += "   and nam ='" + nam + "'";
        if (tk != "")
            strWhere += "   and tk = '" + tk + "'";
        if (ma_kh != "")
            strWhere += "   and ma_kh = '" + ma_kh + "'";
        string sql = "";

        sql = "select  nam,tk,tk.tentaikhoan,ma_kh,bn.tenbenhnhan, kh.tenkhachhang,ncc.TenNhaCungCap,du_no0,du_co0 " +
              "     from CongNo_DauKi left join benhnhan bn on bn.mabenhnhan = ma_kh  " +
              "     left join KhachHang kh on kh.makhachhang = ma_kh" +
              "     left join NhaCungCap ncc on convert(varchar,ncc.nhacungcapid)= ma_kh " +
              "     left join DanhMucTK tk on tk.taikhoan = tk " +
              "  where 1=1    ";
        if (strWhere != "")
            sql += strWhere;

        string rs = "";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null && table.Rows.Count > 0)
        {
            //nam,tk,tk.tentaikhoan,ma_kh,bn.tenbenhnhan as tenkhachhang,du_no0,du_co0
            for (int i = 0; i < table.Rows.Count; i++)
            {
                rs += "&" + table.Rows[i][0] + "|" + table.Rows[i][1] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + "|" + table.Rows[i][4] + "|" + table.Rows[i][5] + "|" + table.Rows[i][6] + "|" + table.Rows[i][7] + "|" + table.Rows[i][8];
            }

        }
        Response.Write(rs);

    }
    public void LuuCongNoDauKy()
    {
        string nam = Request.QueryString["nam"];
        string tk = Request.QueryString["tk"];
        string ma_kh = Request.QueryString["ma_kh"];
        string du_no0 = Request.QueryString["du_no0"];
        if (string.IsNullOrEmpty(du_no0))
            du_no0 = "0";

        string du_co0 = Request.QueryString["du_co0"];
        if (string.IsNullOrEmpty(du_co0))
            du_co0 = "0";
        string user_dau = "Tăng Thúy Ngọc";
        string user_cuoi = "Tăng Thúy Ngọc";

        string sql = "spCong_No_DK_Save null,'" + nam + "','" + tk + "','" + ma_kh + "','" + du_no0 + "','" + du_co0 + "',N'" + user_dau + "',N'" + user_cuoi + "'";
        int rs = DataAcess.Connect.Exec(sql);
        if (rs > 0)
            Response.Write(1);
        else
            Response.Write(0);
    }

    public void LuuSoDuDauKyTaiKhoan()
    {
        bool rs = false;

        string nam = Request.QueryString["nam"];
        string tai_khoan_list = Request.QueryString["tai_khoan"];
        string du_no0_list = Request.QueryString["du_no0"];
        string du_co0_list = Request.QueryString["du_co0"];
        string du_no_nt0_list = Request.QueryString["du_no_nt0"];
        string du_co_nt0_list = Request.QueryString["du_co_nt0"];

        string[] tai_khoan = tai_khoan_list.Split(';');
        string[] du_no0 = du_no0_list.Split(';');
        string[] du_co0 = du_co0_list.Split(';');
        string[] du_no0_nt = du_no_nt0_list.Split(';');
        string[] du_co0_nt = du_co_nt0_list.Split(';');

        string user_dau = SysParameter.UserLogin.UserName(this);
        string user_cuoi = SysParameter.UserLogin.UserName(this);
        if (tai_khoan.Length > 0)
        {
            for (int i = 1; i < tai_khoan.Length; i++)
            {
                if (!string.IsNullOrEmpty(tai_khoan[i]))
                {
                    if (string.IsNullOrEmpty(du_no0[i]))
                        du_no0[i] = "0";
                    if (string.IsNullOrEmpty(du_co0[i]))
                        du_co0[i] = "0";
                    if (string.IsNullOrEmpty(du_no0_nt[i]))
                        du_no0_nt[i] = "0";
                    if (string.IsNullOrEmpty(du_co0_nt[i]))
                        du_co0_nt[i] = "0";

                    string sql = "exec spSo_Du_TK_DauKy_Save '" + nam + "','" + tai_khoan[i] + "','" + du_no0[i] + "','" + du_co0[i] + "','" + du_no0_nt[i] + "','" + du_co0_nt[i] + "','" + user_dau + "','" + user_cuoi + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
                else
                    rs = false;
            }
        }
        else
            rs = false;


        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }
    //luu tham so
    public void Luuthamso()
    {
        bool rs = false;

        string ts = Request.QueryString["tham_so"];
        string gt = Request.QueryString["gia_tri"];
        string[] tham_so = ts.Split(';');
        string[] gia_tri = gt.Split(';');

        if (tham_so.Length > 0)
        {
            for (int i = 0; i < tham_so.Length; i++)
            {
                if (!string.IsNullOrEmpty(tham_so[i]))
                {
                    string sql = "exec spTham_So_Save '" + tham_so[i] + "',N'" + gia_tri[i] + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
                else
                    rs = false;
            }
        }
        else
            rs = false;

        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }
    //-----------------------//---------------------------------
    public void LoadSoDuDauKyTaiKhoanByNam()
    {

        string nam = Request.QueryString["nam"];
        string sql = "exec spSo_Du_TK_DauKy_Load '" + nam + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //nam,tai_khoan,du_no0,du_co 0,du_no_nt0,du_co_nt0
                rs += "&" + table.Rows[i][0] + "|" + table.Rows[i][1] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + "|" + table.Rows[i][4] + "|" + table.Rows[i][5];
            }
        }
        Response.Write(rs);
    }

    public void Luu_UyNhiemChi()
    {
        try
        {
            string UyNhiemChiID = Request.QueryString["UyNhiemChiID"];
            string So_UNC = Request.QueryString["So_UNC"];
            string NgayLap = Request.QueryString["NgayLap"];
            string MaNCC = Request.QueryString["MaNCC"];
            string NguoiNhan = Request.QueryString["NguoiNhan"];
            string DienGiai = Request.QueryString["DienGiai"];
            string TKCo = Request.QueryString["TKCo"];
            string TongTien = Request.QueryString["TongTien"];
            string TKNganHangNCC = Request.QueryString["TKNganHangNCC"];
            string TenNganHangCC = Request.QueryString["TenNganHangCC"];
            if (string.IsNullOrEmpty(TongTien))
                TongTien = "0";

            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            string Status = Request.QueryString["Status"];
            //@unc_id,@so_unc,@ngay_lap_unc,@ma_ncc ,@nguoi_nhan ,@dien_giai ,	@tk_co,@loai_nt,@ty_gia,@tien ,@tien_nt,@user_dau ,@user_cuoi,@status
            string sql = "exec spUy_Nhiem_Chi_Save '" + UyNhiemChiID + "','" + So_UNC + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLap) + "','" + MaNCC + "',N'" + NguoiNhan + "',N'" + DienGiai + "','" + TKCo + "',null,null," + TongTien + ",null,N'" + UserDau + "',N'" + UserCuoi + "','" + TKNganHangNCC + "',N'" + TenNganHangCC + "',0";
            int rs = DataAcess.Connect.Exec(sql);
            if (rs > 0)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }
    }
    public void Luu_ChiTietUyNhiemChi()
    {
        try
        {
            string SoUNC = Request.QueryString["SoUNC"];
            int loaiunc = int.Parse(Request.QueryString["loaiunc"]);
            string MaNCC_list = Request.QueryString["MaNCC"];
            string[] MaNCC = MaNCC_list.Split(';');

            string TenNCC_list = Request.QueryString["TenNCC"];
            string[] TenNCC = TenNCC_list.Split(';');

            string TKNo_list = Request.QueryString["TKNo"];
            string[] TKNo = TKNo_list.Split(';');

            string PhatSinhNo_list = Request.QueryString["PhatSinhNo"];
            string[] PhatSinhNo = PhatSinhNo_list.Split(';');

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string SoSeri_list = Request.QueryString["SoSeri"];
            string[] SoSeri = SoSeri_list.Split(';');

            string mapn_list = Request.QueryString["mapn"];
            string[] mapn = mapn_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');


            string DienGiai_list = Request.QueryString["DienGiai"];
            string[] DienGiai = DienGiai_list.Split(';');
            string Status = Request.QueryString["Status"];
            bool rs = false;
            decimal tongtien = 0;
            for (int i = 1; i < TKNo.Length; i++)
            {
                if (TKNo[i] != "")
                {
                    string sql = "exec spUy_Nhiem_Chi_Ct_Save null,'" + SoUNC + "','" + MaNCC[i] + "',N'" + TenNCC[i] + "','" + TKNo[i] + "','" + PhatSinhNo[i] + "',null,'" + SoHD[i] + "','" + SoSeri[i] + "','" + StaticData.CheckDate_kt(NgayLapHD[i]) + "',N'" + DienGiai[i] + "',0";
                    rs = DataAcess.Connect.ExecSQL(sql);
                    //luu vao table thanh_toan_cn
                    if (loaiunc == 1)
                    {
                        tongtien = Decimal.Parse(PhatSinhNo[i]);
                        string sqltt = "exec spThanhToanCongNo_Save '" + mapn[i] + "','" + SoUNC + "'," + tongtien;
                        DataAcess.Connect.ExecSQL(sqltt);
                    }
                }
            }

            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }

    public void LuuSoCaiUyNhiemChi()
    {
        try
        {
            string SoUNC = Request.QueryString["SoUNC"];
            string NgayLap = Request.QueryString["NgayLap"];
            string MaNCC_list = Request.QueryString["MaNCC"];
            string[] MaNCC = MaNCC_list.Split(';');
            string TKCo = Request.QueryString["TKCo"];

            string TKNo_list = Request.QueryString["TKNo"];
            string[] TKNo = TKNo_list.Split(';');

            string PhatSinhNo_list = Request.QueryString["PhatSinhNo"];
            string[] PhatSinhNo = PhatSinhNo_list.Split(';');

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string SoSeri_list = Request.QueryString["SoSeri"];
            string[] SoSeri = SoSeri_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');

            string DienGiai_list = Request.QueryString["DienGiai"];
            string[] DienGiai = DienGiai_list.Split(';');


            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            bool rs = false;
            for (int i = 1; i < TKNo.Length; i++)
            {
                if (TKNo[i] != "")
                {
                    string sql = "exec spUy_Nhiem_Chi_So_Cai_Save null,'" + SoUNC + "','" +
                                                             StaticData.CheckDate_kt(NgayLap) + "','" +
                                                             MaNCC[i] + "',N'" +
                                                             DienGiai[i] + "','" +
                                                             TKNo[i] + "','" +
                                                             TKCo + "','" +
                                                             PhatSinhNo[i] + "','" +
                                                             SoHD[i] + "','" +
                                                             SoSeri[i] + "','" +
                                                             StaticData.CheckDate_kt(NgayLapHD[i]) + "',N'" +
                                                             UserDau + "',N'" +
                                                             UserCuoi + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }



            if (rs)
            {

                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }

    }

    public void XoaChiTietUyNhiemChi()
    {
        try
        {
            string SoUNC = Request.QueryString["SoUNC"];
            string sql = "exec spUy_Nhiem_Chi_Ct_Delete  '" + SoUNC + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaSoCai()
    {
        try
        {
            //so_phieu_chi,tk_no,ps_no,ps_no_nt,tk_thue,tien_thue,tien_thue_nt,so_hd,ngay_lap_hd,tien_tren_hd,da_thanh_toan,con_phai_thanh_toan,thanh_toan,dien_giai,status_fix            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string SoCT = Request.QueryString["SoCT"];
            string sql = "exec spSo_Cai_Delete  '" + SoCT + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void LoadDanhSachUyNhiemChi()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoUyNhiemChi = Request["SoUyNhiemChi"];
        string MaNCC = Request["MaNCC"];
        string tknh = Request.QueryString["tknh"].ToString();     
        string sql = "select a.unc_id,a.so_unc,convert(varchar,ngay_lap_unc,103)ngay_lap,ma_ncc=d.manhacungcap,tennhacungcap,a.dien_giai,tk_co,SoTaiKhoanNCC=taikhoannganhang,TenNganHangNCC=nganhang,tien=sum(isnull(b.ps_no,0))+sum(isnull(tien_thue,0)) ";
        sql += "  from uy_nhiem_chi a left join uy_nhiem_chi_ct b on a.so_unc=b.so_unc  left join nhacungcap d on b.ma_ncc=d.manhacungcap left join danhmuctknh c  on a.tk_co=c.taikhoankt ";
        sql += "  where (a.isdelete is null or a.isdelete=0) and b.isdelete is null ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_lap_unc between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        else
            if (!string.IsNullOrEmpty(TuNgay))
            {
                sql += "    and ngay_lap_unc = '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "'  ";
            }
            else
                if (!string.IsNullOrEmpty(DenNgay))
                {
                    sql += "  and ngay_lap_unc = '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
                }
        if (!string.IsNullOrEmpty(SoUyNhiemChi))
            sql += "    and a.so_unc = '" + SoUyNhiemChi + "'";
        if (!string.IsNullOrEmpty(MaNCC))
            sql += " and d.manhacungcap='" + MaNCC + "'";
        if (!string.IsNullOrEmpty(tknh) && !tknh.Equals("0"))
            sql += " and tk_co='" + tknh + "'";
        sql += " group by a.unc_id,a.so_unc,convert(varchar,ngay_lap_unc,103),tk_co,d.manhacungcap,tennhacungcap,diachi,taikhoannganhang,nganhang,a.dien_giai";
        sql += " order by ngay_lap,so_unc,d.manhacungcap";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        //int k=0;
        //+"_"+ k.ToString("00") 
        //string so_uncadd = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//unc_id(0),so_unc(1),ngay_lap(2),ma_ncc(3),ncc.TenNhaCungCap(4),Dien_Giai(5),TK_Co(6),SoTaiKhoanNCC(7),TenNganHangNCC(8),	Tien(9) )
                DataRow row = table.Rows[i];               

                rs += "|" + row["unc_id"] + "$" + row["so_unc"] +"$" + row["ngay_lap"] + "$" + row["ma_ncc"] + "$" + row["TenNhaCungCap"] + "$" + row["Dien_Giai"] + "$" + row["TK_Co"] + "$" + row["SoTaiKhoanNCC"] + "$" + row["TenNganHangNCC"] + "$" + row["Tien"];
            }
            Response.Write(rs);
        }

    }
    public void LoadUyNhiemChiBySoUNC()
    {
        string SoUNC = Request.QueryString["SoUNC"];
        string sql = " select unc_id,so_unc,convert(varchar,ngay_lap_unc,103)ngay_lap,ma_ncc,ncc.TenNhaCungCap,Dien_Giai,TK_Co,SoTaiKhoanNCC,TenNganHangNCC,Tien,Nguoi_Nhan " +
                     "  from Uy_Nhiem_Chi left join NhaCungCap ncc on ncc.MaNhaCungCap = ma_ncc " +
                     "  where so_unc =  '" + SoUNC + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                rs += "|" + row["unc_id"] + "&" + row["so_unc"] + "&" + row["ngay_lap"] + "&" + row["ma_ncc"] + "&" + row["TenNhaCungCap"] + "&" + row["Dien_Giai"] + "&" + row["TK_Co"] + "&" + row["SoTaiKhoanNCC"] + "&" + row["TenNganHangNCC"] + "&" + row["Tien"] + "&" + row["Nguoi_Nhan"];
            }
            Response.Write(rs);
        }
    }
    public void LoadChiTietUyNhiemChiBySoUNC()
    {
        string SoUNC = Request.QueryString["SoUNC"];
        string sql = "select ma_ncc,ten_ncc,tk_no,so_hd,so_seri,convert(varchar,ngay_lap_hd,103)ngay_lap_hd,dien_giai,ps_no,Thue_Suat,tk_thue,tien_thue,tong_tien=isnull(ps_no,0)+isnull(tien_thue,0),idphieunhapkho,phieu_nhap_vt_id " +
                     "  from uy_nhiem_chi_ct" +
                     "  where (isdelete is null or isdelete =0) and so_unc = '" + SoUNC + "'";
        sql += " order by ma_ncc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["ma_ncc"] + "&" + row["ten_ncc"] + "&" + row["tk_no"] + "&" + row["so_hd"] + "&" + row["so_seri"] + "&" + row["ngay_lap_hd"] + "&" + row["dien_giai"] + "&" + row["ps_no"] + "&" + row["Thue_Suat"] + "&" + row["tk_thue"] + "&" + row["tien_thue"] + "&" + row["tong_tien"] + "&" + row["idphieunhapkho"] + "&" + row["phieu_nhap_vt_id"];
            }
            Response.Write(rs);
        }
    }
    public void XoaUyNhiemChi()
    {
        try
        {
            string SoUNC = Request.QueryString["SoUNC"];
            string userdelete = SysParameter.UserLogin.UserName(this);
            string sql = "exec spUy_Nhiem_Chi_Delete  '" + SoUNC + "','" + userdelete + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaUyNhiemChi_fault()
    {
        try
        {
            string SoUNC = Request.QueryString["SoUNC"];            
            string sql = "exec spUy_Nhiem_Chi_fault_Delete  '" + SoUNC + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public string TaoSoThuTu(int so_thu_tu)
    {
        so_thu_tu++;
        string stt = "";
        if (so_thu_tu > 0 && so_thu_tu < 10)
        {
            stt = "00" + so_thu_tu.ToString();
        }
        else
            if (so_thu_tu >= 10 && so_thu_tu <= 99)
            {
                stt = "0" + so_thu_tu.ToString();
            }
            else
                if (so_thu_tu >= 100 && so_thu_tu <= 999)
                {
                    stt = so_thu_tu.ToString();
                }
                else
                {
                    stt = so_thu_tu.ToString();
                }
        return stt;
    }
    public void TaoMaSoTuDong_Ngoc()
    {
        string MaTuDong = "";

        string TenTable = Request.QueryString["Table"];
        string KyTuDau = Request.QueryString["KyTuDau"];
        string FielMa = Request.QueryString["Column"];
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where " + FielMa + " like '" + KyTuDau + "%' ";
        sql += "order by " + FielMa + " desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string Ma = table.Rows[0][0].ToString();
                string[] buffer = Ma.Split('-');
                string ky_tu_dau = buffer[0];

                //Tao day so;
                string[] day_so = buffer[1].Split('/');
                int so_thu_tu = Int32.Parse(day_so[0]);
                string stt = TaoSoThuTu(so_thu_tu);

                string thangnam = day_so[1];
                int thang = Int32.Parse(thangnam.Substring(0, 2));
                int nam = Int32.Parse(thangnam.Substring(2, 4));

                //Tao thang nam
                if (nam >= DateTime.Now.Year)
                {
                    if (thang >= DateTime.Now.Month)
                    {
                        string month = "";
                        if (thang < 10)
                            month = "0" + thang.ToString();
                        else
                            month = thang.ToString();
                        MaTuDong = ky_tu_dau + "-" + stt + "/" + thang + "/" + nam.ToString();
                    }
                    else
                    {
                        thang++;
                        string month = "";
                        if (thang < 10)
                            month = "0" + thang.ToString();
                        else
                            month = thang.ToString();
                        MaTuDong = ky_tu_dau + "-" + "0001" + "/" + nam.ToString();
                    }
                }
                else
                {
                    nam++;
                    if (thang >= DateTime.Now.Month)
                    {
                        string month = "";
                        if (thang < 10)
                            month = "0" + thang.ToString();
                        else
                            month = thang.ToString();
                        MaTuDong = ky_tu_dau + "-" + "0001" + "/" + nam.ToString();
                    }
                    else
                    {
                        thang++;
                        string month = "";
                        if (thang < 10)
                            month = "0" + thang.ToString();
                        else
                            month = thang.ToString();
                        MaTuDong = ky_tu_dau + "-" + "0001" + "/" + nam.ToString();
                    }
                }
            }
            else //Mã số đầu tiên
            {
                string month = "";
                if (DateTime.Now.Month < 10)
                    month = "0" + DateTime.Now.Month.ToString();
                else
                    month = DateTime.Now.Month.ToString();

                MaTuDong = KyTuDau + "-" + "0001" + "/" + month + "/" + DateTime.Now.Year.ToString();
            }
        }
        Response.Write(MaTuDong);
    }
    public void TaoMaSoTuDong()
    {
        //tao ma so theo dang: PC1201.001
        //PC:tiep dau ngu;12:nam;01:thang;001:so thu tu trong thang
        int thang;
        int nam;
        string MaTuDong = "";
        string TenTable = Request.QueryString["Table"];        
        string FielMa = Request.QueryString["Column"];
        string ngaylap=Request.QueryString["ngaylap"].ToString().Trim();
        //lay thang va nam cua ngay lap de so sach voi thang va nam trong so phieu
        string strthang = ngaylap.Substring(3, 2);
        string strnam = ngaylap.Substring(ngaylap.Length - 2);
        string strssthangnam = strnam + strthang;
        //lay tiep dau ngu
        string manghiepvu = Request.QueryString["manghiepvu"].ToString().Trim();
        string tiepdaungu = "";
        string sqldau = "select manghiepvu,tiepdaungu from dmnghiepvu where manghiepvu='" + manghiepvu + "'";
        DataTable dttdn = new DataTable();
        dttdn = DataAcess.Connect.GetTable(sqldau);
        if (dttdn != null && dttdn.Rows.Count > 0)
            tiepdaungu = dttdn.Rows[0]["tiepdaungu"].ToString().Trim();
        //
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where " + FielMa + " like '" + tiepdaungu+strssthangnam+ "%' ";
        sql += "order by " + FielMa + " desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string Ma = table.Rows[0][0].ToString();
                string[] buffer = Ma.Split('.');
                string ky_tu_dau = buffer[0];

                //Tao day so;               
                string day_so = buffer[1];
                int so_thu_tu = Int32.Parse(day_so);
                string stt = TaoSoThuTu(so_thu_tu);               

                //Tao thang nam
                string namthang = ky_tu_dau.Substring(tiepdaungu.Length);
                nam = int.Parse(namthang.Substring(0, 2).ToString());
                thang = int.Parse(namthang.Substring(2,2).ToString());
                MaTuDong = tiepdaungu + nam.ToString("00") + thang.ToString("00")+"." + stt;                
            }
            else //Mã số đầu tiên
            {                                
                MaTuDong = tiepdaungu + strnam + strthang + "." + "001";
            }
        }
        Response.Write(MaTuDong);
    }

    public void TaoMaSoTuDong_minhduc()
    {
        //tao ma so theo dang: PC-0001
        //PC:tiep dau ngu;0001:so thu tu trong nam
        //su dung het nam 2012       
        string MaTuDong = "";
        string TenTable = Request.QueryString["Table"];
        string FielMa = Request.QueryString["Column"];        
        //lay tiep dau ngu
        string manghiepvu = Request.QueryString["manghiepvu"].ToString().Trim();
        string tiepdaungu = "";
        string sqldau = "select manghiepvu,tiepdaungu from dmnghiepvu where  manghiepvu='" + manghiepvu + "'";
        DataTable dttdn = new DataTable();
        dttdn = DataAcess.Connect.GetTable(sqldau);
        if (dttdn != null && dttdn.Rows.Count > 0)
            tiepdaungu = dttdn.Rows[0]["tiepdaungu"].ToString().Trim();
        //
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where (isdelete is null or isdelete =0) and " + FielMa + " like '" + tiepdaungu + "-%'  and len("+ FielMa +")=7 ";
        sql += "order by " + FielMa + " desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string Ma = table.Rows[0][0].ToString();
                string[] buffer = Ma.Split('-');
                string ky_tu_dau = buffer[0];

                //Tao day so;               
                string day_so = buffer[1];
                int so_thu_tu = Int32.Parse(day_so);
                string stt = TaoSoThuTu_minhduc(so_thu_tu);
                MaTuDong = tiepdaungu + "-" + stt;
            }
            else //Mã số đầu tiên
            {
                MaTuDong = tiepdaungu + "-" + "0001";
            }
        }
        Response.Write(MaTuDong);
    }
    public string TaoSoThuTu_minhduc(int so_thu_tu)
    {
        so_thu_tu++;
        string stt = "";
        if (so_thu_tu > 0 && so_thu_tu < 10)
        {
            stt = "000" + so_thu_tu.ToString();
        }
        else
            if (so_thu_tu >= 10 && so_thu_tu <= 99)
            {
                stt = "00" + so_thu_tu.ToString();
            }
            else
                if (so_thu_tu >= 100 && so_thu_tu <= 999)
                {
                    stt ="0"+ so_thu_tu.ToString();
                }
                    else
                    if (so_thu_tu >= 1000 && so_thu_tu <= 9999)
                    {
                        stt =  so_thu_tu.ToString();
                    }
                    else
                    {
                        stt = so_thu_tu.ToString();
                    }
        return stt;
    }
    public void TaoMaSoTuDong_theongayhethong()
    {
        //tao ma so theo dang: PC1201.001
        //PC:tiep dau ngu;12:nam;01:thang;001:so thu tu trong thang
        int thang;
        int nam;
        string MaTuDong = "";
        string TenTable = Request.QueryString["Table"];
        string FielMa = Request.QueryString["Column"];
        string ngaylap = Request.QueryString["ngaylap"].ToString().Trim();
        //lay thang va nam cua ngay lap de so sach voi thang va nam trong so phieu
        string strthang = ngaylap.Substring(3, 2);
        string strnam = ngaylap.Substring(ngaylap.Length - 2);
        string strssthangnam = strnam + strthang;
        //lay tiep dau ngu
        string manghiepvu = Request.QueryString["manghiepvu"].ToString().Trim();
        string tiepdaungu = "";
        string sqldau = "select manghiepvu,tiepdaungu from dmnghiepvu where manghiepvu='" + manghiepvu + "'";
        DataTable dttdn = new DataTable();
        dttdn = DataAcess.Connect.GetTable(sqldau);
        if (dttdn != null && dttdn.Rows.Count > 0)
            tiepdaungu = dttdn.Rows[0]["tiepdaungu"].ToString().Trim();
        //
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where " + FielMa + " like '" + tiepdaungu + strssthangnam + "%' ";
        sql += "order by " + FielMa + " desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string Ma = table.Rows[0][0].ToString();
                string[] buffer = Ma.Split('.');
                string ky_tu_dau = buffer[0];

                //Tao day so;               
                string day_so = buffer[1];
                int so_thu_tu = Int32.Parse(day_so);
                string stt = TaoSoThuTu(so_thu_tu);

                //Tao thang nam
                string namthang = ky_tu_dau.Substring(tiepdaungu.Length);
                nam = int.Parse(namthang.Substring(0, 2).ToString());
                thang = int.Parse(namthang.Substring(3).ToString());
                if (nam >= int.Parse(DateTime.Now.Year.ToString().Substring(2, 2)))
                {
                    if (thang >= DateTime.Now.Month)
                    {
                        MaTuDong = tiepdaungu + nam.ToString() + thang.ToString("00") + "." + stt;
                    }
                    else
                    {
                        thang = DateTime.Now.Month;
                        MaTuDong = tiepdaungu + nam.ToString() + thang.ToString("00") + "." + TaoSoThuTu(0);
                    }
                }
                else
                {
                    nam++;
                    thang = DateTime.Now.Month;
                    MaTuDong = tiepdaungu + nam.ToString() + thang.ToString("00") + "." + TaoSoThuTu(0);
                }
            }
            else //Mã số đầu tiên
            {
                thang = DateTime.Now.Month;
                string  nam1 = DateTime.Now.Year.ToString();
                nam = int.Parse(nam1.Substring(2, 2));
                MaTuDong = tiepdaungu + nam.ToString("00") + thang.ToString("00") + "." + "001";
            }
        }
        Response.Write(MaTuDong);
    }
    public void TaoMaSoTuDong_TheoNgayTuChon()
    {
        string MaTuDong = "";
        int Thang = Int32.Parse(Request.QueryString["Thang"].ToString());
        int Nam = Int32.Parse(Request.QueryString["Nam"].ToString());
        string TenTable = Request.QueryString["Table"];
        string manghiepvu = Request.QueryString["manghiepvu"].ToString().Trim();
        string FielMa = Request.QueryString["Column"];
        //lay tiep dau ngu
        string tiepdaungu = "";
        string sqldau = "select manghiepvu,tiepdaungu from dmnghiepvu where manghiepvu='" + manghiepvu + "'";
        DataTable dttdn = new DataTable();
        dttdn = DataAcess.Connect.GetTable(sqldau);
        if(dttdn!=null && dttdn.Rows.Count>0)
            tiepdaungu = dttdn.Rows[0]["tiepdaungu"].ToString().Trim();
        //
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where " + FielMa + " like '" + tiepdaungu + "%' and  " + FielMa + " like '%" + Nam + Thang + "' ";
        sql += "order by " + FielMa + " desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string Ma = table.Rows[0][0].ToString();
                string[] buffer = Ma.Split('-');
                string ky_tu_dau = buffer[0];

                //Tao day so;
                string[] day_so = buffer[1].Split('/');
                int so_thu_tu = Int32.Parse(day_so[0]);
                string stt = TaoSoThuTu(so_thu_tu);

                string thangnam = day_so[1];
                int thang = Int32.Parse(thangnam.Substring(0, 2));
                int nam = Int32.Parse(thangnam.Substring(2, 4));

                //Tao thang nam
                MaTuDong = ky_tu_dau + "-" + stt + "/" + thang.ToString() + nam.ToString();

            }
            else //Mã số đầu tiên
            {
                string month = "";
                if (Thang < 10)
                    month = "0" + Thang;
                else
                    month = Thang.ToString();

                MaTuDong = tiepdaungu + "-" + "0001" + "/" + month + Nam.ToString();
            }
        }
        Response.Write(MaTuDong);
    }
    public void LoadPhieuChiByIDPhieuChi()
    {
        string idPhieuChi = Request["idPhieuChi"];
        string sql = "select phieu_chi_id,so_phieu_chi,convert(varchar,ngay_chi,103)ngay_chi,ma_ncc,ncc.TenNhaCungCap,nguoi_giao,Dien_Giai,tk_co,Tien,so_ctgoc,chungtugoc,diachi " +
                     "  from Phieu_Chi pc left join NhaCungCap ncc on pc.ma_ncc = ncc.manhacungcap " +
                     "  where 1=1 ";
        if (!string.IsNullOrEmpty(idPhieuChi))
            sql += " and phieu_chi_id= '" + idPhieuChi + "'";

        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_id"] + "&" + row["so_phieu_chi"] + "&" + row["ngay_chi"] + "&" + row["ma_ncc"] + "&" + row["TenNhaCungCap"] + "&" + row["Dien_Giai"] + "&" + row["tk_co"] + "&" + row["Tien"] + "&" + row["nguoi_giao"] + "&" + row["so_ctgoc"] + "&" + row["chungtugoc"] + "&" + row["diachi"];
            }
            Response.Write(rs);
        }
    }
    public void DanhSachPhieuChi()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoPhieuChi = Request["SoPhieuChi"];
        string MaNCC = Request["MaNCC"];
        string sql = "select phieu_chi_id,so_phieu_chi,convert(varchar,ngay_chi,103)ngay_chi,ma_ncc,ncc.TenNhaCungCap,nguoi_giao,Dien_Giai,tk_co,Tien,loai_chi=status " +
                     "  from Phieu_Chi pc left join NhaCungCap ncc on pc.ma_ncc = ncc.manhacungcap " +
                     "  where (isdelete is null or isdelete=0)  ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_chi between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(SoPhieuChi))
            sql += "    and so_phieu_chi = '" + SoPhieuChi + "'";
        if (!string.IsNullOrEmpty(MaNCC))
            sql += "    and ma_ncc='" + MaNCC + "'";
        sql += "    order by so_phieu_chi desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_id"] + "&" + row["so_phieu_chi"] + "&" + row["ngay_chi"] + "&" + row["ma_ncc"] + "&" + row["TenNhaCungCap"] + "&" + row["Dien_Giai"] + "&" + row["tk_co"] + "&" + row["Tien"] + "&" + row["loai_chi"];
            }
            Response.Write(rs);
        }
    }
    public void loadSoNhatKyChung()
    {
        string tungay = Request.QueryString["tungay"];
        string denngay = Request.QueryString["denngay"];
        string sql = "";
        sql = "Exec spLoadSoNhatKyChung '" + StaticData.CheckDate_kt(tungay) + "','" + StaticData.CheckDate_kt(denngay) + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                rs += "|" + row["ma_ct"] + "$" +row["ngay_lap_ct"].ToString() + "$" + row["ma_kh"] + "$" + row["tenkhachhang"] + "$" + row["dien_giai"] + "$" + row["tai_khoan"] + "$" + row["ps_no"] + "$" + row["ps_co"];
            }
            Response.Write(rs);
        }
    }
    public void ChiTietPhieuChiKhacBySoPhieuChi()
    {
        string SoPhieuChi = Request.QueryString["SoPhieuChi"];
        string sql = "select phieu_chi_ct_id,tk_no,ps_no,tk_thue,tien_thue,so_hd,so_seri,convert(varchar,ngay_lap_hd,103)ngay_lap_hd,dien_giai,Thue_Suat " +
                     "  from Phieu_Chi_CT" +
                     "  where (isdelete is null or isdelete =0) and So_phieu_chi = '" + SoPhieuChi + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_ct_id"] + "&" + row["tk_no"] + "&" + row["ps_no"] + "&" + row["tk_thue"] + "&" + row["tien_thue"] + "&" + row["so_hd"] + "&" + row["so_seri"] + "&" + row["ngay_lap_hd"] + "&" + row["dien_giai"] + "&" + row["Thue_Suat"];
            }
            Response.Write(rs);
        }
    }

    public void LuuPhieuChi()
    {        
        string sqlchan = "select phieu_chi_id from phieu_chi where (isdelete is null or isdelete =0) and so_phieu_chi='" + Request.QueryString["SoPhieuChi"] + "'";
        DataTable tbpcid = DataAcess.Connect.GetTable(sqlchan);
        string PhieuChiID = "";
        if (tbpcid.Rows.Count > 0)
            PhieuChiID = tbpcid.Rows[0][0].ToString();
        else
            PhieuChiID = "null";
        ////////////////////////////
        string SoPhieuChi = "";        
        SoPhieuChi = Request.QueryString["SoPhieuChi"];          
        string NgayChi = Request.QueryString["NgayChi"];
        string MaNCC = Request.QueryString["MaNCC"];
        string NguoiGiao = Request.QueryString["NguoiGiao"];
        string DienGiai = Request.QueryString["DienGiai"];
        string soctgoc = Request.QueryString["soctgoc"];
        string chungtugoc = Request.QueryString["chungtugoc"];
        string TKCo = Request.QueryString["TKCo"];
        string Tien = Request.QueryString["TongTien"];
        //string Loai_nt = Request.QueryString["Loai_nt"];
        //string TiGia = Request.QueryString["TiGia"];
        string Loai_nt = "";
        string TiGia = "";
        double TongTien;
        if (string.IsNullOrEmpty(Tien))
            TongTien = 0;
        else
            TongTien = double.Parse(Tien);
        string UserDau = SysParameter.UserLogin.UserName(this);
        string UserCuoi = SysParameter.UserLogin.UserName(this);
        string Status = Request.QueryString["Status"];
        //SoPhieuChi,ngay_chi,ma_ncc,nguoi_giao,dien_giai,tk_co,loai_nt,ty_gia,tien,tien_nt,user_dau,date_dau,user_cuoi,date_cuoi,status
        string sql = "exec spPhieu_Chi_Save " + PhieuChiID + ",'" + SoPhieuChi + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayChi) + "','" + MaNCC + "',N'" + NguoiGiao + "',N'" + DienGiai + "','" + TKCo + "','" + Loai_nt + "',null," + TongTien + ",null,'"+soctgoc+"',N'"+chungtugoc+"',N'" + UserDau + "',N'" + UserCuoi + "',0";
        bool rs = DataAcess.Connect.ExecSQL(sql);
        if (rs == true)
            Response.Write(1);
        else
            Response.Write(0);
        //}
        //catch (Exception e)
        //{
        //    Response.Write(0);
        //}
    }
    public void luuchitiethoadon_dvkh()
    {
        bool rs = false;
        try
        {
            string so_hd = Request.QueryString["so_hd"];
            string mahang_list = Request.QueryString["ma_hang"];
            string[] ma_hang = mahang_list.Split(';');

            string tenhang_list = Request.QueryString["ten_hang"];
            string[] ten_hang = tenhang_list.Split(';');

            string dvt_list = Request.QueryString["dvt"];
            string[] dvt = dvt_list.Split(';');

            string tkco_list = Request.QueryString["tk_co"];
            string[] tk_co = tkco_list.Split(';');

            string soluong_list = Request.QueryString["so_luong"];
            string[] so_luong = soluong_list.Split(';');

            string dongia_list = Request.QueryString["don_gia"];
            string[] don_gia = dongia_list.Split(';');

            string thanhtien_list = Request.QueryString["thanh_tien"];
            string[] thanh_tien = thanhtien_list.Split(';');
            string sql = "";
            for (int i = 1; i < ma_hang.Length; i++)
            {
                sql = "Exec spHoaDonDVCTKH_save '" + so_hd + "','" + ma_hang[i] + "',N'" + ten_hang[i] + "',N'" + dvt[i] + "','" + tk_co[i] + "'," + Convert.ToInt16(so_luong[i]) + "," + Convert.ToDecimal(don_gia[i]) + "," + Convert.ToDecimal(thanh_tien[i]);
                rs = DataAcess.Connect.ExecSQL(sql);
            }
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void luuhoadondvkh_socai()
    {
        int rs = 0;
        try
        {
            string so_hd = Request.QueryString["so_hd"];
            string so_seri = Request.QueryString["so_seri"];
            string ngay_hd = Request.QueryString["ngay_hd"];
            string tk_no = Request.QueryString["tk_no"];
            string tk_thue = Request.QueryString["tk_thue"];
            //string tien_thue = Request.QueryString["tien_thue"];
            decimal tien_thue = Convert.ToDecimal(Request.QueryString["tien_thue"]);
            string ma_ncc = Request.QueryString["ma_ncc"];
            string dien_giai = Request.QueryString["dien_giai"];
            string tk_co = "";
            decimal thanh_tien = 0;
            string sql = "";
            string sql1 = "";
            string sql2 = "";
            int tmp = 0;
            sql = "select b.tk_co,sum(b.thanh_tien)thanhtien from hoa_don_dv a inner join hoa_don_dv_ct_kh b on a.so_hd=b.so_hd ";
            sql += "where a.so_hd='" + so_hd + "' and a.ngay_lap_hd='" + StaticData.CheckDate(ngay_hd) + "' group by b.tk_co ";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            ngay_hd = StaticData.CheckDate(ngay_hd);
            //insert cac dong trong luoi vao so cai
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tk_co = dt.Rows[i]["tk_co"].ToString();
                    thanh_tien = Convert.ToDecimal(dt.Rows[i]["thanhtien"].ToString());
                    sql1 = "Exec spHoaDonDV_KH_SoCai '" + so_hd + "','" + ngay_hd + "','" + tk_no + "','" + tk_co + "','" + ma_ncc + "'," + thanh_tien + ",'" + so_hd + "','" + so_seri + "','" + ngay_hd + "',N'" + dien_giai + "'," + i;
                    if (DataAcess.Connect.ExecSQL(sql1))
                        rs = 1;
                    else
                        rs = 0;
                    tmp = i;
                }
            }
            //insert tien thue vao so cai
            if (!string.IsNullOrEmpty(tk_thue))
            {
                sql2 = " Exec spHoaDonDV_KH_Thue_SoCai '" + so_hd + "','" + ngay_hd + "','" + tk_no + "','" + tk_thue + "','" + ma_ncc + "'," + tien_thue + ",'" + so_hd + "','" + so_seri + "','" + ngay_hd + "',N'" + dien_giai + "'," + (tmp + 1);
                if (DataAcess.Connect.ExecSQL(sql2))
                    rs = 1;
                else
                    rs = 0;
            }

        }
        catch
        {
            rs = 0;
        }
        Response.Write(rs);
    }

    public void LuuChiTietPhieuChi()
    {
        try
        {
         DataTable tbsopc = DataAcess.Connect.GetTable("select top 1 so_phieu_chi from phieu_chi order by phieu_chi_id desc");
        //string SoPT = Request["SoPT"];
        string SoPhieuChi = "";
        if (Request.QueryString["SoPhieuChi"] == "" || Request.QueryString["SoPhieuChi"] == null)
        {
            if (tbsopc.Rows.Count > 0)
                SoPhieuChi = tbsopc.Rows[0][0].ToString();
        }
        else
            SoPhieuChi = Request.QueryString["SoPhieuChi"].ToString();
        //////////////
        string TKNo_list = Request.QueryString["TKNo"];
        string[] TKNo = TKNo_list.Split(';');
        string PhatSinhNo_list = Request.QueryString["PhatSinhNo"];
        string[] PhatSinhNo = PhatSinhNo_list.Split(';');

        string TKThue_list = Request.QueryString["TKThue"];
        string[] TKThue = TKThue_list.Split(';');

        string ThueSuat_list = Request.QueryString["ThueSuat"];
        string[] ThueSuat = ThueSuat_list.Split(';');

        string TienThue_list = Request.QueryString["TienThue"];
        string[] TienThue = TienThue_list.Split(';');

        string SoHD_list = Request.QueryString["SoHD"];
        string[] SoHD = SoHD_list.Split(';');

        string SoSeri_list = Request.QueryString["SoSeri"];
        string[] SoSeri = SoSeri_list.Split(';');

        string NgayLapHD_list = Request.QueryString["NgayLapHD"];
        string[] NgayLapHD = NgayLapHD_list.Split(';');

        string TienTrenHD = Request.QueryString["TienTrenHD"];

        string DienGiai_list = Request.QueryString["DienGiai"];
        string[] DienGiai = DienGiai_list.Split(';');

        string Status = Request.QueryString["Status"];
        bool rs = false;
        for (int i = 1; i < TKNo.Length; i++)
        {
            if (TKNo[i] != "")
            {
                string sql = "exec spPhieu_Chi_Ct_Save null,'" + SoPhieuChi + "','" + TKNo[i] + "'," + PhatSinhNo[i] + ",null,'" + ThueSuat[i] + "','" + TKThue[i] + "'," + TienThue[i] + ",null,'" + SoHD[i] + "','" + SoSeri[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "'," + TienTrenHD + ",null,null,null,N'" + DienGiai[i] + "',0";
                rs = DataAcess.Connect.ExecSQL(sql);
            }
        }
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }
    catch
    {
        Response.Write(0);
    }
    }
    public void LuuSoCai_PhieuChiKhac()
    {
        try
        {
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            
            string NgayChi = Request.QueryString["NgayChi"];
            string MaNCC = Request.QueryString["MaNCC"];

            string DienGiai_list = Request.QueryString["DienGiai"];
            string[] DienGiai = DienGiai_list.Split(';');

            string TKNo_list = Request.QueryString["TKNo"];
            string[] TKNo = TKNo_list.Split(';');

            string TKCo = Request.QueryString["TKCo"];

            string TKThue_list = Request.QueryString["TKThue"];
            string[] TKThue = TKThue_list.Split(';');

            string PhatSinhNo_list = Request.QueryString["PhatSinhNo"];
            string[] PhatSinhNo = PhatSinhNo_list.Split(';');

            string TienThue_list = Request.QueryString["TienThue"];
            string[] TienThue = TienThue_list.Split(';');

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string SoSeri_list = Request.QueryString["SoSeri"];
            string[] SoSeri = SoSeri_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');

            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            bool rs = false;
            for (int i = 1; i < TKNo.Length; i++)
            {
                if (TKNo[i] != "")
                {
                    string sql = "exec spPhieu_Chi_khac_So_Cai_Save null,'" + SoPhieuChi + "','" +
                                                                 StaticData.CheckDate_kt(NgayChi) + "','" +
                                                                 MaNCC + "',N'" +
                                                                 DienGiai[i] + "','" +
                                                                 TKNo[i] + "','" +
                                                                 TKCo + "','" +
                                                                 TKThue[i] + "','" +
                                                                 PhatSinhNo[i] + "','" +
                                                                 TienThue[i] + "','" +
                                                                 SoHD[i] + "','" +
                                                                 SoSeri[i] + "','" +
                                                                 StaticData.CheckDate_kt(NgayLapHD[i]) + "',N'" +
                                                                 UserDau + "',N'" +
                                                                 UserCuoi + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }

            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaPhieuChi()
    {
        try
        {
            string userdelete = SysParameter.UserLogin.UserName(this);
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string sql = "exec spPhieu_Chi_Delete  '" + SoPhieuChi + "','" + userdelete + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }

    public void XoaPhieuChi_fault()
    {
        try
        {
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string sql = "exec spPhieu_Chi_fault_Delete  '" + SoPhieuChi  + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }

    public void xoaphieuketoan()
    {
        try
        {
            string sophieu = Request.QueryString["sophieu"];
            string sql = "exec spPhieu_ke_toan_delete  '" + sophieu.Trim() + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaChiTietPhieuChi()
    {
        try
        {
            //so_phieu_chi,tk_no,ps_no,ps_no_nt,tk_thue,tien_thue,tien_thue_nt,so_hd,ngay_lap_hd,tien_tren_hd,da_thanh_toan,con_phai_thanh_toan,thanh_toan,dien_giai,status_fix            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string sql = "exec spPhieu_Chi_Ct_Delete  '" + SoPhieuChi + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaSoCai_PhieuChi()
    {
        try
        {
            //so_phieu_chi,tk_no,ps_no,ps_no_nt,tk_thue,tien_thue,tien_thue_nt,so_hd,ngay_lap_hd,tien_tren_hd,da_thanh_toan,con_phai_thanh_toan,thanh_toan,dien_giai,status_fix            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string sql = "exec spPhieu_Chi_khac_So_Cai_Delete  '" + SoPhieuChi + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }

    public void ChiTietPhieuThuHoaDon()
    {
        string SoPT = "";  
        string sql ="";
        string rs = "";
        DataTable tbsopt = DataAcess.Connect.GetTable("select top 1 so_phieu_thu from phieu_thu order by phieu_thu_id desc");       
        if (Request.QueryString["SoPT"] == "" || Request.QueryString["SoPT"] == null)
        {
            if (tbsopt.Rows.Count > 0)
                SoPT = tbsopt.Rows[0][0].ToString();
        }
        else
            SoPT = Request.QueryString["SoPT"].ToString();        
        sql = "select phieu_thu_ct_id,b.ma_kh,ten_kh=c.tenkhachhang,so_hd,convert(varchar(10),ngay_lap_hd,103)ngay_lap_hd,tk_co,a.dien_giai,tien_tren_hd from phieu_thu_ct a ";
        sql += " left join phieu_thu b on a.so_phieu_thu=b.so_phieu_thu  left join (select * from(select makhachhang,tenkhachhang from khachhang union select mabenhnhan,tenbenhnhan from benhnhan) n where makhachhang is not null) c on b.ma_kh=c.makhachhang";  
        sql+=" where a.so_phieu_thu='"+ SoPT+"'";
        DataTable table = DataAcess.Connect.GetTable(sql);        
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                rs += "|" + row["ma_kh"] + "&" + row["ten_kh"] + "&" + row["so_hd"] + "&" + row["ngay_lap_hd"] + "&" + row["dien_giai"] + "&" + row["tk_co"] + "&" + row["tien_tren_hd"] + "&" + row["phieu_thu_ct_id"];
            }
            Response.Write(rs);
        }
    }

    public void ChiTietPhieuThuKhac()
    {
        string SoPT = Request["SoPT"];
        string sql = "select phieu_thu_ct_id,tk_co,dien_giai,tongtien = ps_co,tk.TenTaiKhoan " +
                     "   from phieu_thu_ct left join DanhMucTK tk on tk.TaiKhoan = tk_co	" +
                     "   where (isdelete is null or isdelete =0) and  so_phieu_thu = '" + SoPT + "'";

        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_thu_ct_id"] + "&" + row["tk_co"] + "&" + row["dien_giai"] + "&" + row["tongtien"] + "&" + row["TenTaiKhoan"];
            }
            Response.Write(rs);
        }
    }

    public void DanhSachPhieuThuOfKhachHang()
    {
        string idPhieuThu = Request["idPhieuThu"];
        string sql = "select phieu_thu_id,pt.so_phieu_thu,convert(varchar,ngay_thu,103)ngay_thu,pt.ma_kh,kh.tenkhachhang,nguoi_nop,pt.dien_giai,tk_no,tien,kh.diachi,so_ctgoc,chungtugoc " +
                     "  from Phieu_Thu pt left join khachhang kh on  pt.ma_kh = kh.MaKhachHang  " +
                     "  where (isdelete is null or isdelete =0) and   phieu_thu_id = '" + idPhieuThu + "' ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_thu_id"] + "&" + row["so_phieu_thu"] + "&" + row["ngay_thu"] + "&" + row["ma_kh"] + "&" + row["tenkhachhang"] + "&" + row["nguoi_nop"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tien"] + "&" + row["so_ctgoc"] + "&" + row["chungtugoc"] + "&" + row["diachi"];
            }
            Response.Write(rs);
        }
    }
    public void DanhSachPhieuThuOfBenhNhan()
    {
        string idPhieuThu = Request["idPhieuThu"];
        string sql = "select  phieu_thu_id,so_phieu_thu,convert(varchar,ngay_thu,103)ngay_thu,pt.ma_kh,bn.TenBenhNhan,nguoi_nop,dien_giai,tk_no,tien" +
                     "  from Phieu_Thu pt left join BenhNhan bn on  pt.ma_kh = bn.MaBenhNhan" +
                     "  where phieu_thu_id = '" + idPhieuThu + "' ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_thu_id"] + "&" + row["so_phieu_thu"] + "&" + row["ngay_thu"] + "&" + row["ma_kh"] + "&" + row["TenBenhNhan"] + "&" + row["nguoi_nop"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tien"];
            }
            Response.Write(rs);
        }
    }

    public void DanhSachPhieuThu()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoPhieuThu = Request["SoPhieuThu"];
        string MaKH = Request["MaKH"];
        string sql = "select phieu_thu_id,so_phieu_thu,convert(varchar,ngay_thu,103)ngay_thu,ma_kh,dien_giai,tk_no,tien,status from phieu_thu where (isdelete is null or isdelete =0) ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and Ngay_Thu between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(SoPhieuThu))
            sql += "    and So_phieu_thu = '" + SoPhieuThu + "'";
        if (!string.IsNullOrEmpty(MaKH))
            sql += "    and Ma_KH='" + MaKH + "'";
        sql += "    order by so_phieu_thu desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_thu_id"] + "&" + row["so_phieu_thu"] + "&" + row["ngay_thu"] + "&" + row["ma_kh"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tien"] + "&" + row["status"];
            }
            Response.Write(rs);
        }
    }
    public void DanhSachHoaDon_VanTam()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoHD = Request["SoHD"];
        string MaKH = Request["MaKH"];
        string loaixuat=Request.QueryString["loaixuat"].Trim();
        string sql="";
        if (loaixuat.Equals("0"))
        {
            sql = "select hoa_donid,so_hd,convert(varchar,ngay_lap_hd,103)ngaylap_hd, ma_kh,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien,loai_hd from Hoa_Don_Ban_Hang ";            
        }
        else 
            if (loaixuat.Equals("1"))
                    sql = "select hoa_donid,so_hd,convert(varchar,ngay_lap_hd,103)ngaylap_hd, ma_kh,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien,loai_hd from Hoa_Don_Ban_Hang where loai_hd='1' ";
            else
                if( loaixuat.Equals("2"))
                    sql = "select hoa_donid,so_hd,convert(varchar,ngay_lap_hd,103)ngaylap_hd, ma_kh,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien,loai_hd from Hoa_Don_Ban_Hang where loai_hd='2' ";
                else
                    sql = "select hoa_donid,so_hd,convert(varchar,ngay_lap_hd,103)ngaylap_hd, ma_kh,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien,loai_hd from Hoa_Don_DV where 1=1 ";

        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_lap_hd between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(SoHD))
            sql += "    and So_HD = '" + SoHD + "'";
        if (!string.IsNullOrEmpty(MaKH))
            sql += "    and Ma_KH='" + MaKH + "'";
        sql += " order by ngaylap_hd";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["hoa_donid"] + "&" + row["so_hd"] + "&" + row["ngaylap_hd"] + "&" + row["ma_kh"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tk_co"] + "&" + row["tk_thue"] + "&" + row["thue_suat"] + "&" + row["tien"] + "&" + row["tien_thue"] + "&" + row["tong_tien"] + "&" + row["loai_hd"];
            }
            Response.Write(rs);
        }
    }

    public void DanhSachHoaDon()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoHD = Request["SoHD"];
        string MaKH = Request["MaKH"];
        string sql = "select hoa_donid,so_hd,convert(varchar,ngay_lap_hd,103)ngaylap_hd, ma_kh,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien,loai_hd from Hoa_Don_DV where 1=1 ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_lap_hd between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(SoHD))
            sql += "    and So_HD = '" + SoHD + "'";
        if (!string.IsNullOrEmpty(MaKH))
            sql += "    and Ma_KH='" + MaKH + "'";
        sql += " order by ngay_lap_hd";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["hoa_donid"] + "&" + row["so_hd"] + "&" + row["ngaylap_hd"] + "&" + row["ma_kh"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tk_co"] + "&" + row["tk_thue"] + "&" + row["thue_suat"] + "&" + row["tien"] + "&" + row["tien_thue"] + "&" + row["tong_tien"] + "&" + row["loai_hd"];
            }
            Response.Write(rs);
        }
    }

    public void LoadChiTietHoaDonDichVu()
    {
        string IDHoaDon = Request["IDHoaDon"];
        string sql = "  exec spHoa_Don_Load " + IDHoaDon;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {//hoa_donID,so_hd,so_seri,ngay_lap_hd,ma_kh,ten_KH,NguoiMua,DiaChi,MaSoThue,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien
            DataRow row = table.Rows[0];
            rs += "|" + row["hoa_donID"] + "&" + row["so_hd"] + "&" + row["so_seri"] + "&" + row["ngay_lap_hd"] + "&" + row["ma_kh"] + "&" + row["ten_KH"] + "&" + row["ten_nguoi_mua"] + "&" + row["dia_chi"] + "&" + row["ma_so_thue"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tk_co"] + "&" + row["tk_thue"] + "&" + row["thue_suat"] + "&" + row["tien"] + "&" + row["tien_thue"] + "&" + row["tong_tien"];
            Response.Write(rs);
        }
    }

    public void loaddanhsachHDKhac_CT()
    {
        string sohd = Request.QueryString["so_hd"].ToString();
        string ngay_hd = Request.QueryString["ngay_hd"].ToString();
        string rs = "";
        string sql = "";
        sql = "select ten_dich_vu,a.tk_co,tien_dv from hoa_don_dv_ct_khac a left join hoa_don_dv b on a.so_hoa_don=b.so_hd ";
        sql += "where a.so_hoa_don='" + sohd + "' and b.ngay_lap_hd='" + StaticData.CheckDate_kt(ngay_hd) + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rs += "|" + dt.Rows[i]["ten_dich_vu"] + "&" + dt.Rows[i]["tk_co"] + "&" + dt.Rows[i]["tien_dv"];
            }
        }
        Response.Write(rs);
    }

    public void LuuSoCai_PhieuThuHoaDon()
    {
        try
        {
            //TKCo,TienTrenHD,SoHD,NgayLapHD)
            //string SoPT = Request.QueryString["SoPT"];
            DataTable tbsopt = DataAcess.Connect.GetTable("select top 1 so_phieu_thu from phieu_thu order by phieu_thu_id desc");
            string SoPT = "";
            if (Request.QueryString["SoPT"] == "" || Request.QueryString["SoPT"] == null)
            {
                if (tbsopt.Rows.Count > 0)
                    SoPT = tbsopt.Rows[0][0].ToString();
            }
            else
                SoPT = Request.QueryString["SoPT"].ToString();
            /////////////////
            string NgayThu = Request.QueryString["NgayThu"];
            string TKNo = Request.QueryString["TKNo"];
            string TKCo_list = Request.QueryString["TKCo"];
            string MaKH = Request.QueryString["MaKH"];
            string DienGiai = Request.QueryString["DienGiai"];
            string TienTrenHD_list = Request.QueryString["TienTrenHD"];
            string SoHD_list = Request.QueryString["SoHD"];
            string NgayLapHD_list = Request.QueryString["NgayLapHD"];

            string[] TKCo = TKCo_list.Split(';');
            string[] TienTrenHD = TienTrenHD_list.Split(';');
            string[] SoHD = SoHD_list.Split(';');
            string[] NgayLapHD = NgayLapHD_list.Split(';');
            bool rs = false;
            for (int i = 0; i < SoHD.Length; i++)
            {
                if (SoHD[i] != "")
                {
                    string sql1 = "spPhieu_Thu_HD_So_Cai_Save null,'" + SoPT + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayThu) + "','" + TKNo + "','" + TKCo[i] + "','" + MaKH + "','" + DienGiai + "'," + TienTrenHD[i] + ",'" + SoHD[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "'";
                    rs = DataAcess.Connect.ExecSQL(sql1);
                }
            }
            if (rs)
            {
                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }

    }
    public void LuuSoCai_PhieuThuKhac()
    {
        try
        {
            //string SoPT = Request.QueryString["SoPT"];
            DataTable tbsopt = DataAcess.Connect.GetTable("select top 1 so_phieu_thu from phieu_thu order by phieu_thu_id desc");
            string SoPT = "";
            if (Request.QueryString["SoPT"] == "" || Request.QueryString["SoPT"] == null)
            {
                if (tbsopt.Rows.Count > 0)
                    SoPT = tbsopt.Rows[0][0].ToString();
            }
            else
                SoPT = Request.QueryString["SoPT"].ToString();
            /////////////////
            string NgayThu = Request.QueryString["NgayThu"];
            string MaKH = Request.QueryString["MaKH"];
            string DienGiai_list = Request.QueryString["DienGiai"];
            string TKNo = Request.QueryString["TKNo"];
            string TKCo_list = Request.QueryString["TKCo"];
            string PSCo_list = Request.QueryString["PSCo"];
            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);

            string[] DienGiai = DienGiai_list.Split(';');
            string[] TKCo = TKCo_list.Split(';');
            string[] PSCo = PSCo_list.Split(';');            
            bool rs = false;
            if (TKCo.Length > 0)
            {
                for (int i = 0; i < TKCo.Length; i++)
                {
                    if (TKCo[i] != "")
                    {
                        string sql1 = "spPhieu_Thu_Khac_So_Cai_Save null,'" + SoPT + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayThu) + "','" + MaKH + "',N'" + DienGiai[i] + "','" + TKNo + "','" + TKCo[i] + "','" + PSCo[i] + "'";
                        rs = DataAcess.Connect.ExecSQL(sql1);
                    }
                }
            }

            if (rs)
            {

                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }

    }
    public void LuuChiTietPhieuThuKhac()
    {
        try
        {
            //string SoPT = Request.QueryString["SoPT"];
            DataTable tbsopt = DataAcess.Connect.GetTable("select top 1 so_phieu_thu from phieu_thu order by phieu_thu_id desc");
            string SoPT = "";
            if (Request.QueryString["SoPT"] == "" || Request.QueryString["SoPT"] == null)
            {
                if (tbsopt.Rows.Count > 0)
                    SoPT = tbsopt.Rows[0][0].ToString();
            }
            else
                SoPT = Request.QueryString["SoPT"].ToString();
            ////////////////////////////
            string TKCo_list = Request.QueryString["TKCo"];
            string DienGiai_list = Request.QueryString["DienGiai"];
            string PhatSinhCo_list = Request.QueryString["PhatSinhCo"];

            string[] TKCo = TKCo_list.Split(';');
            string[] DienGiai = DienGiai_list.Split(';');
            string[] PhatSinhCo = PhatSinhCo_list.Split(';');
            bool rs = false;
            if (TKCo.Length > 0)
            {
                for (int i = 1; i < TKCo.Length; i++)
                {
                    if (TKCo[i] != "")
                    {
                        //null,sophieuthu,tkco,psco,null,null,null,null,null,null,null,diengiai,0
                        string sql = "exec spPhieu_Thu_Ct_Save null,'" + SoPT + "','" + TKCo[i] + "'," + PhatSinhCo[i] + ",null,null,null,null,null,null,null,N'" + DienGiai[i] + "',0";
                        rs = DataAcess.Connect.ExecSQL(sql);
                    }
                }
            }
            if (rs)
            {
                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void LuuChiTietPhieuThuHoaDon()
    {
        try
        {
            //string SoPT = Request.QueryString["SoPT"];
            ////////////////////////////
            //if (Request.QueryString["do"].ToString() != "TimKiem")
            //    if (Request.QueryString["LoaiThu"].ToString() == "ThuHoaDon")
            //        SoPT = Xulychuoi("PTA", "phieu_thu", "so_phieu_thu");
            //    else
            //        SoPT = Xulychuoi("PTB", "phieu_thu", "so_phieu_thu");
            //else SoPT = Request.QueryString["SoPT"];
            DataTable tbsopt = DataAcess.Connect.GetTable("select top 1 so_phieu_thu from phieu_thu order by phieu_thu_id desc");
            string SoPT = "";
            if (Request.QueryString["SoPT"] == "" || Request.QueryString["SoPT"] == null)
            {
                if (tbsopt.Rows.Count > 0)
                    SoPT = tbsopt.Rows[0][0].ToString();
            }
            else
                SoPT = Request.QueryString["SoPT"].ToString();
            ////////////////////////////
            string IDPhieuThuCT_list = Request.QueryString["IDPhieuThuCT"];
            string[] IDPhieuThuCT = IDPhieuThuCT_list.Split(';');

            string TKCo_list = Request.QueryString["TKCo"];
            string[] TKCo = TKCo_list.Split(';');

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');

            string DienGiai_list = Request.QueryString["diengiai"];
            string[] DienGiai = DienGiai_list.Split(';');

            string TienTrenHD_list = Request.QueryString["TienTrenHD"];
            string[] TienTrenHD = TienTrenHD_list.Split(';');
            bool rs = false;
            for (int i = 0; i < SoHD.Length; i++)
            {
                if (SoHD[i] != "")
                {
                    string sql1 = "exec spPhieu_Thu_Ct_Save  " + Int64.Parse(IDPhieuThuCT[i]) + ",'" + SoPT + "','" + TKCo[i] + "',null,null,'" + SoHD[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "'," + TienTrenHD[i] + ",null,null,null,N'"+DienGiai[i]+"',0";
                    rs = DataAcess.Connect.ExecSQL(sql1);
                    if (rs)
                    {
                        string sql2 = "update Hoa_Don_DV set status = 1 where so_hd = '" + SoHD[i] + "' and ngay_lap_hd = '" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "' ";
                        rs = DataAcess.Connect.ExecSQL(sql2);
                        string sql3 = "update Hoa_Don_ban_hang set status = 1 where so_hd = '" + SoHD[i] + "' and ngay_lap_hd = '" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "' ";
                        DataAcess.Connect.ExecSQL(sql3);
                    }
                }
            }

            if (rs)
            {
                Response.Write(1);
            }
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }
    }

    /*private string Xulychuoi(string LoaiPhieu, string Bangluu, string Maphieu)
    {
        string Xuatkq, chuoi, Tiepdaungu, Isnum;

        //Lay ma chung tu
        string sqllayma = "select Ma_ct_in, Isnum, Ma_ct from DSManHinh where Ma_ct = '" + LoaiPhieu + "'";
        DataTable dtma = DataAcess.Connect.GetTable(sqllayma);

        if (Maphieu == "ma_kt")
        {
            if (dtma.Rows.Count > 0)
                Tiepdaungu = dtma.Rows[0]["Ma_ct"].ToString();
            else
                Tiepdaungu = "PT";
        }
        else
        {
            if (dtma.Rows.Count > 0)
                Tiepdaungu = dtma.Rows[0]["Ma_ct_in"].ToString();
            else
                Tiepdaungu = "PTA";
        }
        Isnum = dtma.Rows[0]["Isnum"].ToString();
        //Kiem tra bang luu
        int tn = 0;
        try
        {
            tn = int.Parse(Isnum) + 1;
        }
        catch
        {
            tn = 1;
        }
        string sql = "select top 1 " + Maphieu + " from " + Bangluu + " where " + Maphieu + " Like '" + Tiepdaungu
            + "%' and isnumeric( substring(" + Maphieu + ", " + tn + ", 3))=1 order by " + Maphieu + " desc";
        DataTable dt = DataAcess.Connect.GetTable(sql);

        if (dt.Rows.Count == 0)
        {
            Xuatkq = Tiepdaungu + "0001";
        }
        else
        {
            chuoi = dt.Rows[0][Maphieu].ToString();
            String Str = chuoi;
            string strLetter = "";
            string strDigit = "";
            int length = Str.Length;
            if ("" != Str)
            {
                for (int i = 0; i < length; i++)
                {
                    if (!Char.IsDigit(Str[i]))
                        strLetter += Str[i];
                    else
                        strDigit += Str[i];
                }
            }

            chuoi = strDigit.Replace(Tiepdaungu, "");
            Int64 so = Convert.ToInt64(chuoi) + 1;
            if (so < 10)
            {
                Xuatkq = Tiepdaungu + "000" + so;
            }
            else if (so < 100)
            {
                Xuatkq = Tiepdaungu + "00" + so;
            }
            else if (so < 1000)
            {
                Xuatkq = Tiepdaungu + "0" + so;
            }
            else
            {
                Xuatkq = Tiepdaungu + so;
            }
        }
        return Xuatkq;
    }*/
    private string Xulychuoi(string LoaiPhieu, string Bangluu, string Maphieu)
    {
        string Xuatkq, chuoi, Tiepdaungu, Isnum;

        //Lay ma chung tu
        string sqllayma = "select Ma_ct_in, Isnum from DSManHinh where Ma_ct = '" + LoaiPhieu + "'";
        DataTable dtma = DataAcess.Connect.GetTable(sqllayma);
        Tiepdaungu = dtma.Rows[0]["Ma_ct_in"].ToString();
        Isnum = dtma.Rows[0]["Isnum"].ToString();
        //Kiem tra bang luu
        string sql = "select top 1 " + Maphieu + " from " + Bangluu + " where " + Maphieu + " Like '" + Tiepdaungu
            + "%' and isnumeric( substring(" + Maphieu + ", " + Isnum + ",2))=1 order by " + Maphieu + " DESC";
        DataTable dt = DataAcess.Connect.GetTable(sql);

        if (dt.Rows.Count == 0)
        {
            Xuatkq = Tiepdaungu + "0001";
        }
        else
        {
            chuoi = dt.Rows[0][Maphieu].ToString();
            String Str = chuoi;
            string strLetter = "";
            string strDigit = "";
            int length = Str.Length;
            if ("" != Str)
            {
                for (int i = 0; i < length; i++)
                {
                    if (!Char.IsDigit(Str[i]))
                        strLetter += Str[i];
                    else
                        strDigit += Str[i];
                }
            }

            chuoi = strDigit.Replace(Tiepdaungu, "");
            Int64 so = Convert.ToInt64(chuoi) + 1;
            if (so < 10)
            {
                Xuatkq = Tiepdaungu + "000" + so;
            }
            else if (so < 100)
            {
                Xuatkq = Tiepdaungu + "00" + so;
            }
            else if (so < 1000)
            {
                Xuatkq = Tiepdaungu + "0" + so;
            }
            else
            {
                Xuatkq = Tiepdaungu + so;
            }
        }
        //string thang = DateTime.Now.Month.ToString();
        //string nam = DateTime.Now.Year.ToString().Substring(2, 2);
        return Xuatkq;
    }
    public void LuuPhieuThu()
    {        
        DataTable tbptid = DataAcess.Connect.GetTable("select phieu_thu_id from phieu_thu where (isdelete is null or isdelete =0) and so_phieu_thu='" + Request.QueryString["SoPT"] + "'");
        string PhieuThuID = "";
        if (tbptid.Rows.Count > 0)
            PhieuThuID = tbptid.Rows[0][0].ToString();
        else
            PhieuThuID = "null";        
        string SoPT = "";        
        SoPT = Request.QueryString["SoPT"];        
        string NgayThu = Request.QueryString["NgayThu"];
        string loaiphieu=Request.QueryString["loaihoadon"];
        string MaKH = Request.QueryString["MaKH"];
        string NguoiNop = Request.QueryString["NguoiNop"];
        string DienGiai = Request.QueryString["DienGiai"];
        string TKNo = Request.QueryString["TKNo"];
        string Tien = Request.QueryString["Tien"];
        string soctgoc=Request.QueryString["soctgoc"];
        string chungtugoc = Request.QueryString["chungtugoc"];
        //string ngoai_te_id = Request.QueryString["ngoai_te_id"];
        //string ty_gia = Request.QueryString["ty_gia"];
        string UserDau = SysParameter.UserLogin.UserName(this);
        string UserCuoi = SysParameter.UserLogin.UserName(this);
        string Status = Request.QueryString["Status"];
        string nguoithubd = Request.QueryString["nguoithubd"];
        string ngaythubd = Request.QueryString["ngaythubd"];
        if (string.IsNullOrEmpty(ngaythubd))
            ngaythubd = NgayThu;
        string sql = "exec spPhieu_Thu_Save " + PhieuThuID + ", '" + SoPT + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayThu) +"','"+loaiphieu+ "','" + MaKH + "',N'" + NguoiNop + "',N'" + DienGiai + "','" + TKNo + "',null,null," + Tien + ",null,'"+ soctgoc+"',N'"+chungtugoc+"',N'" + UserDau + "',N'" + UserCuoi + "','" + Status + "',N'"+nguoithubd+"','"+StaticData.CheckDate_kt(ngaythubd)+"'";
        bool rs = DataAcess.Connect.ExecSQL(sql);
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);        
    }
    public void LoadDanhSachHoaDon()
    {
        string MaKhachHang = Request.QueryString["MaKhachHang"].Trim();
        string ngaylap = Request.QueryString["ngaylap"];
        int loaihoadon = int.Parse(Request.QueryString["loaihoadon"]);
        string sql="";       
        sql = "select ma_kh,ten_kh,dien_giai,so_hd,convert(varchar,Ngay_Lap_HD,103)ngay_lap_hd,tk_no,tong_tien from hoa_don_ban_hang where status = 0 and loai_hd='" + loaihoadon.ToString() + "'";
        if (!string.IsNullOrEmpty(MaKhachHang))
            sql += " and ma_kh='"+MaKhachHang+"'";
        if (!string.IsNullOrEmpty(ngaylap))
            sql += " and convert(varchar(10),ngay_lap_hd,111)='"+ StaticData.CheckDate_kt(ngaylap)+"'";
        sql += " order by convert(varchar,Ngay_Lap_HD,103)";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string result = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            result += "|" + dt.Rows[i]["ma_kh"] + "&" + dt.Rows[i]["ten_kh"] + "&" + dt.Rows[i]["so_hd"] + "&" + dt.Rows[i]["ngay_lap_hd"] + "&" + dt.Rows[i]["dien_giai"] + "&" + dt.Rows[i]["tk_no"] + "&" + dt.Rows[i]["tong_tien"];
        }
        Response.Write(result);
    }
    public void LoadDanhSachHoaDonPhieuChi()
    {
        string MaNCC = Request.QueryString["MaNCC"];
        string sql = "select sohoadon,tkno, convert(varchar,ngayhoadon,103)ngayhoadon,thanhtien " +
                     "  from PhieuNhapKho where TrangThai = 0 and  MaNhaCungCap='" + MaNCC + "' order by ngayhoadon desc";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string result = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            result += "|" + dt.Rows[i]["sohoadon"] + "&" + dt.Rows[i]["ngayhoadon"] + "&" + dt.Rows[i]["tkno"] + "&" + dt.Rows[i]["thanhtien"];
        }

        Response.Write(result);
    }
    public void XoaPhieuThu()
    {
        try
        {
            string SoPhieuThu = Request.QueryString["SoPhieuThu"];
            //cap nhat isketoanthu=0 trong hs_dsdathu
            string sql1 = "select nguoithu,ngaythu=convert(varchar(10),ngaythu,103) from phieu_thu where so_phieu_thu='" + SoPhieuThu.Trim() + "'";
            DataTable dt = DataAcess.Connect.GetTable(sql1);
            string nguoithu = "";
            string ngaythu = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                nguoithu = dt.Rows[0]["nguoithu"].ToString();
                ngaythu = dt.Rows[0]["ngaythu"].ToString();
                string sqlupdate = " update hs_dsdathu set isketoanthu=0 where tennguoithu=N'" + nguoithu + "' and sysdate> dateadd(day,-1,'" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00') and sysdate <='" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00'";
                DataAcess.Connect.ExecSQL(sqlupdate);
            }
            string userdelete = SysParameter.UserLogin.UserName(this);
            string sql = "exec spPhieu_Thu_Delete  '" + SoPhieuThu + "','" + userdelete + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
           
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaPhieuThu_fault()
    {
        try
        {
            string SoPhieuThu = Request.QueryString["SoPhieuThu"];            
            string sql = "exec spPhieu_Thu_fault_Delete  '" + SoPhieuThu + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaChiTietPhieuThu()
    {
        try
        {
            string SoPT = Request.QueryString["SoPT"];
            string sql1 = "select so_hd from Phieu_thu_ct where so_phieu_thu='" + SoPT + "'";
            DataTable table = DataAcess.Connect.GetTable(sql1);
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string SoHD = table.Rows[i][0].ToString();
                    string sqlUpdate = "update Hoa_Don_DV set status = 0 where so_hd = '" + SoHD + "'";
                    DataAcess.Connect.ExecSQL(sqlUpdate);
                }
            }
            string sql2 = "exec spPhieu_Thu_Ct_Delete '" + SoPT + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql2);
            if (rs)
            {
                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch 
        {
            Response.Write(0);
        }
    }
    public void XoaSoCaiBySoPT()
    {
        try
        {
            string SoPT = Request.QueryString["SoPT"];
            string sql1 = "exec spSo_Cai_Delete '" + SoPT + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql1);
            if (rs)
            {
                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }

    }


    public void CapNhatTrangThaiDoanhThu()
    {
        try
        {

            bool rs = false;
            string DoanhThuID = Request.QueryString["DoanhThuID"];
            string idBenhNhan = Request.QueryString["idBenhNhan"];
            string NgayThu = Request.QueryString["NgayThu"];
            string TrangThai = Request.QueryString["TrangThai"];
            string sql = "update DoanhThu_pmbv set trang_thai = " + TrangThai + " where doanhthu_pmbvid='" + DoanhThuID + "'";
            rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch (Exception ex)
        {
            Response.Write(0);
        }
    }
    public void TestMaTaiKhoan()
    {
        string key = Request.QueryString["Key"];
        string sql = "select TaiKhoan from DanhMucTK where TaiKhoan = '" + key + "'";
        DataTable rs = DataAcess.Connect.GetTable(sql);
        if (rs.Rows.Count > 0)
            Response.Write(1);
        else
            Response.Write(0);

    }
    public void TestSoHoaDon()
    {
        string key = Request.QueryString["Key"];
        string sql = "select so_hd from hoa_don_dv where so_hd ='" + key + "'";
        DataTable rs = DataAcess.Connect.GetTable(sql);
        if (rs.Rows.Count > 0)
            Response.Write(1);
        else
            Response.Write(0);

    }
    public void TestTrangThaiHoaDon()
    {
        string SoHD = Request.QueryString["SoHD"];
        string sql = "select status from Hoa_Don_DV where So_HD = '" + SoHD + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            rs = table.Rows[0]["status"].ToString();
        }
        Response.Write(rs);
    }
    public void SaveHoaDonDichVu()
    {

        string HoaDonId = Request.QueryString["HoaDonId"];
        string SoHD = Request.QueryString["SoHD"];
        string SoSeri = Request.QueryString["SoSeri"];
        string NgayLapHD = Request.QueryString["NgayLapHD"];
        string MaKH = Request.QueryString["idKH"];
        string TenKH = Request.QueryString["TenKH"];
        string NguoiMua = Request.QueryString["NguoiMua"];
        string DiaChi = Request.QueryString["DiaChi"];
        string MaSoThue = Request.QueryString["MaSoThue"];
        string DienGiai = Request.QueryString["DienGiai"];
        string TKNo = Request.QueryString["TKNo"];
        string TKCo = Request.QueryString["TKCo"];
        string TKThue = Request.QueryString["TKThue"];
        string ThueSuat = Request.QueryString["ThueSuat"];
        string Tien = Request.QueryString["Tien"];
        string TienThue = Request.QueryString["TienThue"];
        string TongTien = Request.QueryString["TongTien"];
        string UserDau = SysParameter.UserLogin.UserName(this);
        string UserCuoi = SysParameter.UserLogin.UserName(this);
        string Status = Request.QueryString["Status"];
        string loai_hd = Request.QueryString["loai_hd"];
        string sql = "exec spHoa_Don_Save  '" + HoaDonId + "','" + SoHD + "','" + SoSeri + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD) + "','" + MaKH + "',N'" + TenKH + "',N'" + NguoiMua + "',N'" + DiaChi + "','" + MaSoThue + "',N'" + DienGiai + "','" + TKNo + "','" + TKCo + "','" + TKThue + "','" + ThueSuat + "','" + Tien + "','" + TienThue + "','" + TongTien + "',N'" + UserDau + "',N'" + UserCuoi + "','" + Status + "','" + loai_hd + "'";
        bool rs = DataAcess.Connect.ExecSQL(sql);       
        bool rs2=false;
        if (rs)
        {
            //kiem tra tai khoan khu trung
            string sqltk_khutrung = "select gia_tri from tham_so where tham_so='tai_khoan_khu_trung'";
            DataTable dttkkt = new DataTable();
            dttkkt = DataAcess.Connect.GetTable(sqltk_khutrung);
            string listtkkt = "";
            bool kq = false;
            listtkkt = dttkkt.Rows[0]["gia_tri"].ToString();
            if (!string.IsNullOrEmpty(listtkkt))
            {
                string[] tkkt = listtkkt.Split(',');
                string tkno_kt = TKNo.Substring(0, 3);
                for (int k = 0; k < tkkt.Length; k++)
                {
                    if (tkno_kt.Equals(tkkt[k]))
                        kq = true;
                }
            }
            if (kq != true)
            {
                string sql2 = "exec spHoaDon_SoCai_Save  Null,'" + SoHD + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD) + "','" + MaKH + "',N'" + DienGiai + "','" + TKNo + "','" + TKCo + "','" + TKThue + "','" + Tien + "','" + TienThue+"','"+ThueSuat + "',N'" + UserDau + "',N'" + UserCuoi + "'";
                rs2 = DataAcess.Connect.ExecSQL(sql2);
            }
            Response.Write(1);
        }
        else
            Response.Write(2);
    }
    public void SaveHoaDonDichVu_KH()
    {

        string HoaDonId = Request.QueryString["HoaDonId"];
        string SoHD = Request.QueryString["SoHD"];
        string SoSeri = Request.QueryString["SoSeri"];
        string NgayLapHD = Request.QueryString["NgayLapHD"];
        string MaKH = Request.QueryString["idKH"];
        string TenKH = Request.QueryString["TenKH"];
        string NguoiMua = Request.QueryString["NguoiMua"];
        string DiaChi = Request.QueryString["DiaChi"];
        string MaSoThue = Request.QueryString["MaSoThue"];
        string DienGiai = Request.QueryString["DienGiai"];
        string TKNo = Request.QueryString["TKNo"];
        string TKThue = Request.QueryString["TKThue"];
        string ThueSuat = Request.QueryString["ThueSuat"];
        string Tien = Request.QueryString["Tien"];
        string TienThue = Request.QueryString["TienThue"];
        string TongTien = Request.QueryString["TongTien"];
        string UserDau = SysParameter.UserLogin.UserName(this);
        string UserCuoi = SysParameter.UserLogin.UserName(this);
        string Status = Request.QueryString["Status"];
        string loai_hd = Request.QueryString["loai_hd"];
        string sql = "exec spHoa_Don_Save  '" + HoaDonId + "','" + SoHD + "','" + SoSeri + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD) + "','" + MaKH + "',N'" + TenKH + "',N'" + NguoiMua + "',N'" + DiaChi + "','" + MaSoThue + "',N'" + DienGiai + "','" + TKNo + "','" + "" + "','" + TKThue + "','" + ThueSuat + "','" + Tien + "','" + TienThue + "','" + TongTien + "',N'" + UserDau + "',N'" + UserCuoi + "','" + Status + "','" + loai_hd + "'";
        bool rs = DataAcess.Connect.ExecSQL(sql);

        if (rs)
        {
            Response.Write(1);
        }
        else
            Response.Write(2);
    }
    public void SaveChiTietHoaDonDichVu()
    {
        string SoHD = Request.QueryString["SoHD"];
        string MaPT_list = Request.QueryString["MaPT"];
        string NgayThu_list = Request.QueryString["NgayThu"];
        string MaKH_list = Request.QueryString["idKH"];
        string TienThu_list = Request.QueryString["TienThu"];

        string[] MaPT = MaPT_list.Split(';');
        string[] NgayThu = NgayThu_list.Split(';');
        string[] MaKH = MaKH_list.Split(';');
        string[] TienThu = TienThu_list.Split(';');
        bool rs = false;
        for (int i = 1; i < MaPT.Length; i++)
        {
            if (SoHD != "")
            {
                if (TienThu[i] == "")
                    TienThu[i] = "0";
                string sql = "exec spHoa_Don_Ct_Save null, '" + SoHD + "','" + MaPT[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayThu[i]) + "','" + MaKH[i] + "','" + TienThu[i] + "',null";
                rs = DataAcess.Connect.ExecSQL(sql);
            }
        }


        if (rs)
        {
            Response.Write(1);
        }
        else
            Response.Write(2);
    }
    public void XoaChiTietHoaDonDichVu()
    {
        string SoHD = Request.QueryString["SoHD"];
        string sql = "exec spHoa_Don_CT_Delete  '" + SoHD + "'";
        bool rs = DataAcess.Connect.ExecSQL(sql);

        if (rs)
        {
            Response.Write(1);
        }
        else
            Response.Write(2);
    }
    public void XoaHoaDonDichVu()
    {
        try
        {
            string SoHD = Request.QueryString["SoHD"];
            string NgayLapHD = Request.QueryString["NgayLapHD"];
            string sql = "exec spHoa_Don_Delete null,'" + SoHD + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD) + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaHoaDonBanHang()
    {
        try
        {
            string SoHD = Request.QueryString["SoHD"];
            string NgayLapHD = Request.QueryString["NgayLapHD"];
            string sql = "exec spHoa_Don_BH_Delete '" + SoHD + "','" + StaticData.CheckDate_kt(NgayLapHD) + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void kiemtraxoasuahoadon()
    {
        bool rs = false;
        try
        {
            string SoHD = Request.QueryString["SoHD"];
            string NgayLapHD = Request.QueryString["NgayLapHD"];
            string sql = "";
            sql = " select * from phieu_thu_ct where so_hd='" + SoHD.Trim() + "' and convert(varchar(10),ngay_lap_hd,111)='" + StaticData.CheckDate_kt(NgayLapHD.Trim()) + "'";
            DataTable dt = new DataTable();
            dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
                rs = true;
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void LoadDanhSachPhieuThuOfHoaDonDichVu()
    {
        //string key = Request.QueryString["q"];
        string SoHD = Request.QueryString["SoHD"];
        string sql = "";
        string result = "";
        try
        {

            sql = "  select ma_phieu_thu,convert(varchar,ngay_thu,103)ngay_thu,ma_bn as idbenhnhan,bn.mabenhnhan,bn.tenbenhnhan,tien_thu " +
                  " from Hoa_Don_DV_CT left join benhnhan bn on bn.idbenhnhan = ma_bn " +
                  " where so_hoa_don = '" + SoHD + "'";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //result += "|" + h["ngay_thu"] + "&" + h["idbenhnhan"] + "&" + h["mabenhnhan"] + "&" + h["tenbenhnhan"] + "&" + h["tien_thu"] + "&"  + h["ma_phieu_thu"];
                result += "|" + dt.Rows[i]["mabenhnhan"] + "&" + dt.Rows[i]["tenbenhnhan"] + "&" + dt.Rows[i]["ngay_thu"] + "&" + dt.Rows[i]["tien_thu"] + "&" + dt.Rows[i]["idbenhnhan"] + "&" + dt.Rows[i]["ma_phieu_thu"];

            }

            Response.Write(result);
        }

        catch (Exception)
        {
            Response.Write("error");
        }
    }

    public void LoadDanhSachPhieuThu_byKhachLe()
    {
        string NgayThu = Request.QueryString["NgayThu"];
        string sql = "";
        string result = "";
        try
        {
            sql = "  Select top(1000) doanhthu_pmbvid, bn.idBenhNhan,bn.MaBenhNhan,bn.TenBenhNhan," +
                  "  convert(varchar,dt.Ngay_Thu,103)Ngay_Thu," +
                  "  sum(dt.Thanh_Tien_BN_Tra) as ThanhTien " +
                  "  From DoanhThu_pmbv2 dt left join BenhNhan bn on bn.idbenhnhan =  dt.id_Benh_Nhan " +
                  "  Where dt.Trang_Thai = '0'";
            if (!string.IsNullOrEmpty(NgayThu))
            {
                sql += "   and convert(varchar,Ngay_Thu,111) = '" + StaticData.CheckDate_kt(NgayThu) + "' ";
            }
            sql += "  group by doanhthu_pmbvid, bn.idBenhNhan,bn.MaBenhNhan,bn.TenBenhNhan,Ngay_Thu  ";
            sql += "    order by Ngay_Thu desc";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += "|" + dt.Rows[i]["MaBenhNhan"] + "&" + dt.Rows[i]["TenBenhNhan"] + "&" + dt.Rows[i]["Ngay_Thu"] + "&" + dt.Rows[i]["ThanhTien"] + "&" + dt.Rows[i]["idBenhNhan"] + "&" + dt.Rows[i]["doanhthu_pmbvid"]; ;
            }
            Response.Write(result);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    public void LoadDanhSachPhieuThu_byBenhNhan()
    {
        //string key = Request.QueryString["q"];
        string NgayThu = Request.QueryString["NgayThu"];
        string idBenhNhan = Request.QueryString["idBenhNhan"];
        string sql = "";
        string result = "";
        try
        {
            sql = "  select top(1000) doanhthu_pmbvid, bn.idBenhNhan,bn.MaBenhNhan,bn.TenBenhNhan," +
                  "  convert(varchar,dt.Ngay_Thu,103)Ngay_Thu," +
                  "  sum(dt.Thanh_Tien_BN_Tra) as ThanhTien " +
                  "  from DoanhThu_pmbv2 dt left join BenhNhan bn on bn.idBenhNhan = dt.id_Benh_Nhan " +
                  "  where dt.Trang_Thai = '0' and  dt.id_Benh_Nhan = '" + idBenhNhan + "' ";

            if (!string.IsNullOrEmpty(NgayThu))
            {
                sql += "  and convert(varchar,Ngay_Thu,103)='" + NgayThu + "' ";
            }
            sql += "  group by doanhthu_pmbvid, bn.idBenhNhan,bn.MaBenhNhan,bn.TenBenhNhan,Ngay_Thu  ";
            sql += "    order by Ngay_Thu desc";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += "|" + dt.Rows[i]["MaBenhNhan"] + "&" + dt.Rows[i]["TenBenhNhan"] + "&" + dt.Rows[i]["Ngay_Thu"] + "&" + dt.Rows[i]["ThanhTien"] + "&" + dt.Rows[i]["idBenhNhan"] + "&" + dt.Rows[i]["doanhthu_pmbvid"]; ;
            }

            Response.Write(result);
        }

        catch (Exception)
        {
            Response.Write("error");
        }

    }

    public void DanhSachTaiKhoanCon_Jquery()
    {

        string key = Request.QueryString["q"];
        string idText = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        //html += "|<div style =\"background-color: #4D67A2;height:20px\">";
        html += "|<div style=\"width: 350px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tài khoản</div>";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên tài khoản</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Chi tiết</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Tài khoản cấp cha</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Cấp</div>";
        html += "</div>|";

        html += Environment.NewLine;
        try
        {

            sql = "select TaiKhoan,TenTaiKhoan,ChiTiet,TKCapCha,Cap from DanhMucTK ";

            if (!string.IsNullOrEmpty(key))
                sql += "  where TaiKhoan  LIKE '" + key + "%' or TKCapCha   LIKE '" + key + "%'";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoan('" + dt.Rows[i]["TaiKhoan"] + "','" + idText + "')\">";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TaiKhoan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenTaiKhoan"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ChiTiet"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TKCapCha"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["Cap"] + "</p>";
                html += "</div>|" + dt.Rows[i]["TaiKhoan"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }

    public DataTable taikhoanchitiet(string tk)
    {
        DataTable dt = new DataTable();
        string sql = "";
        string tk1 = "";        
        DataTable dtkq = new DataTable();
        dtkq.Columns.Add("taikhoan");
        dtkq.Columns.Add("tentaikhoan");
        sql = "select taikhoan,tentaikhoan from danhmuctk where taikhoan like '" + tk.Trim() + "%' order by taikhoan ";
        dt = DataAcess.Connect.GetTable(sql);
        int sodong = dt.Rows.Count;
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < sodong; i++)
            {
                tk1 = dt.Rows[i]["taikhoan"].ToString();
                string sqlkq = "select taikhoan,tentaikhoan from danhmuctk where taikhoan like '" + tk1.Trim() + "%' order by taikhoan desc"; ;
                DataTable dt1 = new DataTable();
                dt1 = DataAcess.Connect.GetTable(sqlkq);
                if (dt1 != null && dt1.Rows.Count == 1)
                {                    
                    DataRow r = dtkq.NewRow();
                    r["taikhoan"]=dt1.Rows[0]["taikhoan"];
                    r["tentaikhoan"] = dt1.Rows[0]["tentaikhoan"];
                    dtkq.Rows.Add(r);
                }
            }
        }                            
        return dtkq;
    }    

    public void DanhSachTaiKhoan_Jquery()
    {
        string key = Request.QueryString["q"];
        string idText = Request.QueryString["obj"];        
        string sql = "";
        string html = "";
        //html += "|<div style =\"background-color: #4D67A2;height:20px\">";
        html += "|<div style=\"width: 250px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tài khoản</div>";
        html += "<div style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên tài khoản</div>";
        html += "</div>|";

        html += Environment.NewLine;
        try
        {
            //sql = "select TaiKhoan,TenTaiKhoan,ChiTiet,TKCapCha,Cap from DanhMucTK ";
            //if (!string.IsNullOrEmpty(key))
            //    sql += "  where TaiKhoan  LIKE '" + key + "%'" ;         
            //sql += " order by TaiKhoan";
            //DataTable dt = DataAcess.Connect.GetTable(sql);
            DataTable dt = new DataTable();
            dt = taikhoanchitiet(key);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoan('" + dt.Rows[i]["TaiKhoan"] + "','" + idText + "')\">";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TaiKhoan"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenTaiKhoan"] + "</p>";
                html += "</div>|" + dt.Rows[i]["TaiKhoan"];
                html += Environment.NewLine;
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    
    public void DanhSachTaiKhoan_Jquery2()
    {

        string key = Request.QueryString["q"];
        string idText = Request.QueryString["obj"];
        string i = Request.QueryString["i"];
        string sql = "";
        string html = "";
        //html += "|<div style =\"background-color: #4D67A2;height:20px\">";
        html += "|<div style=\"width: 350px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tài khoản</div>";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên tài khoản</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Chi tiết</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Tài khoản cấp cha</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Cấp</div>";
        html += "</div>||";

        html += Environment.NewLine;
        try
        {

            //sql = "select TaiKhoan,TenTaiKhoan,ChiTiet,TKCapCha,Cap from DanhMucTK ";

            //if (!string.IsNullOrEmpty(key))
            //    sql += "  where TaiKhoan  LIKE '" + key + "%' or TKCapCha   LIKE '" + key + "%'";
            //DataTable dt = DataAcess.Connect.GetTable(sql);
            DataTable dt = new DataTable();
            dt = taikhoanchitiet(key);
            for (int j = 0; j < dt.Rows.Count; j++)
            {

                html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoan('" + dt.Rows[j]["TaiKhoan"] + "','" + idText + "')\">";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[j]["TaiKhoan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[j]["TenTaiKhoan"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[j]["ChiTiet"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[j]["TKCapCha"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[j]["Cap"] + "</p>";
                html += "</div>|" + dt.Rows[j]["TaiKhoan"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    public void DanhSachTaiKhoanNganHang()
    {

        string key = Request.QueryString["q"];
        string idText = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        //html += "|<div style =\"background-color: #4D67A2;height:20px\">";
        html += "|<div style=\"width: 550px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Số hiệu TK</div>";
        html += "<div style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên tài khoản</div>";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Tài khoản KT</div>";

        html += "</div>|";

        html += Environment.NewLine;
        try
        {

            sql = "select SoHieuTKNH,TenTKNH,TaiKhoanKT from DanhMucTKNH ";

            if (!string.IsNullOrEmpty(key))
                sql += "  where TaiKhoanKT  LIKE '" + key + "%'";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoanNganHang('" + dt.Rows[i]["TaiKhoanKT"] + "','" + dt.Rows[i]["SoHieuTKNH"] + "','" + dt.Rows[i]["TenTKNH"] + "')\">";
                html += "<p style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["SoHieuTKNH"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenTKNH"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TaiKhoanKT"] + "</p>";

                html += "</div>|" + dt.Rows[i]["TaiKhoanKT"] + "|" + dt.Rows[i]["SoHieuTKNH"] + "|" + dt.Rows[i]["TenTKNH"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }

    #endregion Ngoc lưu bang gia san pham
    //==================================================================================================

    private void NgoaiTeSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select ten_nt,ngoai_te_id,ty_gia from dmngoaite");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    public void GetTKNH()
    {
        string idncc = Request.QueryString["strSear"];
        string ngay = Request.QueryString["ngay"];
        string sql = "Select * From NhaCungCap Where MaNhaCungCap='" + idncc + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            Response.Write(dt.Rows[0]["taikhoannganhang"].ToString());
        }
        else
            Response.Write("");
    }



    public void LoadTieuDe()
    {
        string html = "", strnguoidung = "";
        string Userhost = Request.UserHostAddress.ToString();
        string sql = "Select a.*, b.tennguoidung From NguoiDung_Host a join NguoiDung b on a.idnguoidung=b.idnguoidung Where a.IdClient='" + Userhost.Trim() + "'";
        DataTable dt1 = DataAcess.Connect.GetTable(sql);
        if (dt1 != null && dt1.Rows.Count > 0)//neu ton tai nguoi dung & IP 
        {
            strnguoidung = dt1.Rows[0]["tennguoidung"].ToString();
            html = "<span class = \"Tieude\">PHẦN MỀM QUẢN LÝ - Người dùng: " + strnguoidung + "</span> ";
            html += "<span onclick = \"Thoat()\" style=\"cursor:pointer\" class = \"Tieude\">[Thoát]</span> ";
            Response.Write(html);
        }
        else
        {
            Response.Write("");
        }
    }
    public void LoadTKNH()
    {
        int idncc = Convert.ToInt16(Request.QueryString["strSear"]);
        string sql = "Select * From NhaCungCap Where MaNhaCungCap=" + idncc;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            Response.Write(dt.Rows[0]["taikhoannganhang"].ToString());
        }
        else
            Response.Write("");
    }
    //Lay danh muc NCC
    public void SetNCC()
    {
        int idncc = Convert.ToInt16(Request.QueryString["strSear"]);
        string strSQL = "SELECT * ";
        strSQL += "     FROM NhaCungCap ";
        strSQL += "     WHERE manhacungcap = " + idncc;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        string shtml = "";
        shtml += "<select name=\"ddlncc\" id=\"ddlncc\" style=\"width:190px;\" runat=\"server\" tabindex=\"10\" >";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + dt.Rows[i]["nhacungcapid"].ToString() + "\" ";
            shtml += ">" + dt.Rows[i]["tennhacungcap"].ToString() + "</option>";
        }
        shtml += "</select>";
        Response.Write(shtml);
        dt = null;
    }


    public void LoadDanhSachNhaCungCap3()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        html += "|<div style=\"width: 300px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã nhà cung cấp</div>";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên nhà cung cấp</div>";
        html += "</div>";
        html += "</div>|||";

        html += Environment.NewLine;
        try
        {
            sql = "select NhaCungCapId,MaNhaCungCap,TenNhaCungCap from NhaCungCap ";
            if (type == "ctl00_body_ma_ncc_ma_ncc" && !string.IsNullOrEmpty(Key))
                sql += " where MaNhaCungCap  LIKE '" + Key + "%'";
            else
                if (type == "ctl00_body_ten_ncc_ten_ncc" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenNhaCungCap  LIKE '%" + Key + "%'";
                }
            //ArrayList arr = data.SQLMultiHashReader(sql, DataAcess.Connect.GetConnection());
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonNCC('" + dt.Rows[i]["NhaCungCapId"].ToString() + "','" + dt.Rows[i]["MaNhaCungCap"].ToString() + "','" + dt.Rows[i]["TenNhaCungCap"].ToString() + "')\">";
                    html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaNhaCungCap"].ToString() + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenNhaCungCap"].ToString() + "</p>";
                    html += "</div>|" + dt.Rows[i]["NhaCungCapId"].ToString() + "|" + dt.Rows[i]["MaNhaCungCap"].ToString() + "|" + dt.Rows[i]["TenNhaCungCap"].ToString();
                    html += Environment.NewLine;
                }
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachKhachHang()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        try
        {
            sql = "select top(10) MaKhachHang,TenKhachHang,DiaChi,nguoilienhe from KhachHang ";
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaKhachHang  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenKhachHang  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            int countItem = dt.Rows.Count;
            if (countItem > 0)
            {
                html += "|<div style=\"width: 100%; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 15%; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã khách hàng</div>";
                html += "<div style=\"width: 40%; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên khách hàng</div>";
                html += "<div style=\"width: 40%; float: left; text-align: center; border-color: Blue; border-width: 2px\">Địa chỉ</div>";
                html += "</div>|||";

                html += Environment.NewLine;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div  style=\"cursor: pointer;width: 100%;\" onclick=\"setChonKhachHang('" + dt.Rows[i]["MaKhachHang"] + "','" + dt.Rows[i]["TenKhachHang"] + "',)\">";
                    html += "<p style=\"width: 15%; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaKhachHang"] + "</p>";
                    html += "<p style=\"width: 40%; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenKhachHang"] + "</p>";
                    html += "<p style=\"width: 40%; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["DiaChi"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["MaKhachHang"] + "|" + dt.Rows[i]["TenKhachHang"] + "|" + dt.Rows[i]["diachi"] + "|" + dt.Rows[i]["nguoilienhe"];
                    html += Environment.NewLine;
                }
            }
            else
            {
                html = "";
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachKhachHang_BN()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        try
        {
            sql = "select * from (select makhachhang,tenkhachhang,diachi,nguoilienhe,masothue from khachhang union select mabenhnhan,tenbenhnhan,diachi,nguoilienhe='',masothue='' from benhnhan)n where makhachhang is not null ";
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  and MaKhachHang  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  and TenKhachHang  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            int countItem = dt.Rows.Count;
            if (countItem > 0)
            {
                html += "|<div style=\"width: 100%; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 15%; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã khách hàng</div>";
                html += "<div style=\"width: 40%; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên khách hàng</div>";
                html += "<div style=\"width: 40%; float: left; text-align: center; border-color: Blue; border-width: 2px\">Địa chỉ</div>";
                html += "</div>|||";

                html += Environment.NewLine;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div  style=\"cursor: pointer;width: 100%;\" onclick=\"setChonKhachHang('" + dt.Rows[i]["MaKhachHang"] + "','" + dt.Rows[i]["TenKhachHang"] + "',)\">";
                    html += "<p style=\"width: 15%; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaKhachHang"] + "</p>";
                    html += "<p style=\"width: 40%; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenKhachHang"] + "</p>";
                    html += "<p style=\"width: 40%; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["DiaChi"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["MaKhachHang"] + "|" + dt.Rows[i]["TenKhachHang"] + "|" + dt.Rows[i]["diachi"] + "|" + dt.Rows[i]["nguoilienhe"] + "|" + dt.Rows[i]["masothue"];
                    html += Environment.NewLine;
                }
            }
            else
            {
                html = "";
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachKhachHang_CongNo()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        try
        {
            sql = "select top(10) * from(select makhachhang,tenkhachhang,diachi from khachhang union all select makhachhang=mabenhnhan,tenkhachhang=tenbenhnhan,diachi from benhnhan)n ";
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  Where makhachhang  LIKE '" + Key + "%'";            
            DataTable dt = DataAcess.Connect.GetTable(sql);
            int countItem = dt.Rows.Count;
            if (countItem > 0)
            {
                html += "|<div style=\"width: 100%; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 25%; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã khách hàng</div>";
                html += "<div style=\"width: 35%; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên khách hàng</div>";
                html += "<div style=\"width: 40%; float: left; text-align: center; border-color: Blue; border-width: 2px\">Địa chỉ</div>";
                html += "</div>|||";

                html += Environment.NewLine;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div  style=\"cursor: pointer;width: 100%;\" onclick=\"setChonKhachHang('" + dt.Rows[i]["MaKhachHang"] + "','" + dt.Rows[i]["TenKhachHang"] + "',)\">";
                    html += "<p style=\"width: 25%; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaKhachHang"] + "</p>";
                    html += "<p style=\"width: 35%; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenKhachHang"] + "</p>";
                    html += "<p style=\"width: 40%; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["DiaChi"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["MaKhachHang"] + "|" + dt.Rows[i]["TenKhachHang"] + "|" + dt.Rows[i]["diachi"] ;
                    html += Environment.NewLine;
                }
            }
            else
            {
                html = "";
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachKhachHang_PXVT()
    {
        string Key = Request.QueryString["q"];
        string type = "ma_kh";
        string sql = "";
        string html = "";

        try
        {
            sql = "select top(100) MaKhachHang,TenKhachHang,DiaChi,nguoilienhe from KhachHang ";
            if (type == "ma_kh" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaKhachHang  LIKE '%" + Key + "%'";
            else
                if (type == "ten_kh" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenKhachHang  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            int countItem = dt.Rows.Count;
            if (countItem > 0)
            {
                html += "|<div style=\"width: 500px; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã khách hàng</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên khách hàng</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Địa chỉ</div>";
                html += "</div>|||";

                html += Environment.NewLine;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    html += "| <div  style=\"cursor: pointer\" onclick=\"setChonKhachHang('" + dt.Rows[i]["MaKhachHang"] + "','" + dt.Rows[i]["TenKhachHang"] + "',)\">";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaKhachHang"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenKhachHang"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["DiaChi"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["MaKhachHang"] + "|" + dt.Rows[i]["TenKhachHang"] + "|" + dt.Rows[i]["diachi"] + "|" + dt.Rows[i]["nguoilienhe"];
                    html += Environment.NewLine;
                }
            }
            else
            {
                html = "";
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachHangHoa()
    {
        string key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        type = type.Substring(0, type.Length - 2);
        string sql = "";
        string html = "";
        html += "|<div style=\"width: 500px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html = "|<div style =\"width:50px;float:left; border-color:Blue; text-align:left; border-width: 2px\"> Mã hàng</div>";
        html += "<div style =\"width:150px;float:left; border-color:Blue; text-align:left; border-width: 2px\"> Tên hàng</div>";
        html += "<div style =\"width:50px;float:left; border-color:Blue; text-align:left; border-width: 2px\"> ĐVT</div>|";
        html += Environment.NewLine;
        try
        {
            sql = "select top(10) ma_vt,ten_vt,dvt from dm_vat_tu_kt";
            if (type == "mahang" && !string.IsNullOrEmpty(type))
            {
                sql += " where ma_vt like '%" + key + "%'";
            }
            else
                if (type == "tenhang" && !string.IsNullOrEmpty(type))
                {
                    sql += " where ten_vt like '%" + key + "%'";
                }
            DataTable dt = new DataTable();
            dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div  style=\"cursor: pointer\" onclick=\"setchonhanghoa('" + dt.Rows[i]["ma_vt"] + "','" + dt.Rows[i]["ten_vt"] + "','" + dt.Rows[i]["dvt"] + "','" + type + "',)\">";
                    html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ma_vt"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ten_vt"] + "</p>";
                    html += "<p style=\"width: 50px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["dvt"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["ma_vt"] + "|" + dt.Rows[i]["ten_vt"] + "|" + dt.Rows[i]["dvt"];
                    html += Environment.NewLine;
                }
            }
            Response.Write(html);
        }
        catch
        {
            Response.Write("error");
        }
    }
    public void LoadDanhSachKhachHang2()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        html += "|<div style=\"width: 500px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã khách hàng</div>";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên khách hàng</div>";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Địa chỉ</div>";
        html += "</div>|||";

        html += Environment.NewLine;
        try
        {
            sql = "select top(100) MaKhachHang,TenKhachHang,DiaChi,masothue from KhachHang ";
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaKhachHang  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenKhachHang  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonKhachHang('" + dt.Rows[i]["MaKhachHang"] + "','" + dt.Rows[i]["TenKhachHang"] + "','" + dt.Rows[i]["DiaChi"] + "','" + dt.Rows[i]["masothue"] + "',)\">";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaKhachHang"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenKhachHang"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["DiaChi"] + "</p>";
                html += "</div>|" + dt.Rows[i]["MaKhachHang"] + "|" + dt.Rows[i]["TenKhachHang"] + "|" + dt.Rows[i]["DiaChi"] + "|" + dt.Rows[i]["masothue"];
                html += Environment.NewLine;
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    public void LoadDanhSachKhachHang3()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        html += "|<div style=\"width: 500px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã khách hàng</div>";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên khách hàng</div>";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Địa chỉ</div>";
        html += "</div>|||";

        html += Environment.NewLine;
        try
        {
            sql = "select top(100) MaKhachHang,TenKhachHang,DiaChi from KhachHang ";
            if (type == "ctl00_body_ma_kh_ma_kh" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaKhachHang  LIKE '%" + Key + "%'";
            else
                if (type == "ctl00_body_ten_kh_ten_kh" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenKhachHang  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonKhachHang('" + dt.Rows[i]["MaKhachHang"] + "','" + dt.Rows[i]["TenKhachHang"] + "',)\">";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaKhachHang"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenKhachHang"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["DiaChi"] + "</p>";
                html += "</div>|" + dt.Rows[i]["MaKhachHang"] + "|" + dt.Rows[i]["TenKhachHang"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachNhaCungCap()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        html += Environment.NewLine;
        try
        {
            sql = "select NhaCungCapId,MaNhaCungCap,TenNhaCungCap,diachi,nguoilienhe from NhaCungCap ";
            if (type == "txtMaNCC" && !string.IsNullOrEmpty(Key))
                sql += " where MaNhaCungCap  LIKE '" + Key + "%'";
            else
                if (type == "txtTenNCC" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenNhaCungCap  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                html += "|<div style=\"width: 300px; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã nhà cung cấp</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên nhà cung cấp</div>";
                html += "</div>";
                html += "</div>|";   
             
                html += Environment.NewLine;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonNCC('" + dt.Rows[i]["NhaCungCapId"] + "','" + dt.Rows[i]["MaNhaCungCap"] + "','" + dt.Rows[i]["TenNhaCungCap"] + "')\">";
                    html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaNhaCungCap"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenNhaCungCap"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["NhaCungCapId"] + "|" + dt.Rows[i]["MaNhaCungCap"] + "|" + dt.Rows[i]["TenNhaCungCap"] + "|" + dt.Rows[i]["nguoilienhe"] + "|" + dt.Rows[i]["diachi"];
                    html += Environment.NewLine;
                }
            }
            else
                html = "";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachNhaCungCap4()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        html += "|<div style=\"width: 300px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã nhà cung cấp</div>";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên nhà cung cấp</div>";
        html += "</div>";
        html += "</div>|||";

        html += Environment.NewLine;
        try
        {
            sql = "select NhaCungCapId,MaNhaCungCap,TenNhaCungCap from NhaCungCap ";
            if (type == "txtMa_kh" && !string.IsNullOrEmpty(Key))
                sql += " where MaNhaCungCap  LIKE '" + Key + "%'";
            else
                if (type == "txtTenNCC" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenNhaCungCap  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonNCC('" + dt.Rows[i]["NhaCungCapId"] + "','" + dt.Rows[i]["MaNhaCungCap"] + "','" + dt.Rows[i]["TenNhaCungCap"] + "')\">";
                    html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaNhaCungCap"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenNhaCungCap"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["NhaCungCapId"] + "|" + dt.Rows[i]["MaNhaCungCap"] + "|" + dt.Rows[i]["TenNhaCungCap"];
                    html += Environment.NewLine;
                }
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachNhaCungCap2()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        try
        {
            sql = "select NhaCungCapId,MaNhaCungCap,TenNhaCungCap,TaiKhoanNganHang,NganHang,DiaChi,MaSoThue  from NhaCungCap ";
            if (type == "txtMaNCC" && !string.IsNullOrEmpty(Key))
                sql += " where MaNhaCungCap  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenNCC" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenNhaCungCap  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                html += "|<div style=\"width: 300px; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã nhà cung cấp</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên nhà cung cấp</div>";

                html += "</div>|||||";

                html += Environment.NewLine;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonNCC('" + dt.Rows[i]["NhaCungCapId"] + "','" + dt.Rows[i]["MaNhaCungCap"] + "','" + dt.Rows[i]["TenNhaCungCap"] + dt.Rows[i]["TaiKhoanNganHang"] + dt.Rows[i]["NganHang"] + "')\">";
                    html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaNhaCungCap"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenNhaCungCap"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["NhaCungCapId"] + "|" + dt.Rows[i]["MaNhaCungCap"] + "|" + dt.Rows[i]["TenNhaCungCap"] + "|" + dt.Rows[i]["TaiKhoanNganHang"] + "|" + dt.Rows[i]["NganHang"];
                    html += Environment.NewLine;
                }
            }
            else
                html = "";

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachNhaCungCap_UNC()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        try
        {
            sql = "select NhaCungCapId,MaNhaCungCap,TenNhaCungCap,TaiKhoanNganHang,NganHang,DiaChi,MaSoThue  from NhaCungCap ";
            if (type == "txtMaNCC" && !string.IsNullOrEmpty(Key))
                sql += " where MaNhaCungCap  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenNCC" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenNhaCungCap  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                html += "|<div style=\"width: 300px; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã nhà cung cấp</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên nhà cung cấp</div>";

                html += "</div>|||||";

                html += Environment.NewLine;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonNCC('" + dt.Rows[i]["NhaCungCapId"] + "','" + dt.Rows[i]["MaNhaCungCap"] + "','" + dt.Rows[i]["TenNhaCungCap"] + dt.Rows[i]["TaiKhoanNganHang"] + dt.Rows[i]["NganHang"] + "')\">";
                    html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaNhaCungCap"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenNhaCungCap"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["NhaCungCapId"] + "|" + dt.Rows[i]["MaNhaCungCap"] + "|" + dt.Rows[i]["TenNhaCungCap"] + "|" + dt.Rows[i]["TaiKhoanNganHang"] + "|" + dt.Rows[i]["NganHang"];
                    html += Environment.NewLine;
                }
            }
            else
                html = "";

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachBenhNhan()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        html += "|<div style=\"width: 700px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã bệnh nhân</div>";
        html += "<div style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên bệnh nhân</div>";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Ngày sinh</div>";
        html += "<div style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Địa chỉ</div>";
        html += "</div>|||";

        html += Environment.NewLine;
        try
        {
            sql = "select top(10) idBenhNhan,MaBenhNhan,TenBenhNhan,NgaySinh,GioiTinh,DiaChi from BenhNhan ";
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaBenhNhan  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenBenhNhan  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonBenhNhan('" + dt.Rows[i]["MaBenhNhan"] + "','" + dt.Rows[i]["TenBenhNhan"] + "','" + dt.Rows[i]["idBenhNhan"] + "')\">";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaBenhNhan"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenBenhNhan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["NgaySinh"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["DiaChi"] + "</p>";
                html += "</div>|" + dt.Rows[i]["MaBenhNhan"] + "|" + dt.Rows[i]["TenBenhNhan"] + "|" + dt.Rows[i]["idBenhNhan"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachBenhNhan2()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        html += "|<div style=\"width: 700px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã bệnh nhân</div>";
        html += "<div style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên bệnh nhân</div>";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Ngày sinh</div>";
        html += "<div style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Địa chỉ</div>";
        html += "</div>|||";

        html += Environment.NewLine;
        try
        {
            sql = "select top(50) idBenhNhan,MaBenhNhan,TenBenhNhan,NgaySinh,GioiTinh,DiaChi from BenhNhan ";
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaBenhNhan  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenBenhNhan  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonBenhNhan('" + dt.Rows[i]["MaBenhNhan"] + "','" + dt.Rows[i]["TenBenhNhan"] + "','" + dt.Rows[i]["idBenhNhan"] + "')\">";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaBenhNhan"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenBenhNhan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["NgaySinh"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["DiaChi"] + "</p>";
                html += "</div>|" + dt.Rows[i]["MaBenhNhan"] + "|" + dt.Rows[i]["TenBenhNhan"] + "|" + dt.Rows[i]["idBenhNhan"] + "|" + dt.Rows[i]["DiaChi"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void loaddanhsachHDKH_CT()
    {
        string sohd = Request.QueryString["so_hd"].ToString();
        string ngay_hd = Request.QueryString["ngay_hd"].ToString();
        string rs = "";
        string sql = "";
        sql = "select ma_hang,ten_hang,dvt,b.tk_co,so_luong,don_gia,thanh_tien from hoa_don_dv a inner join hoa_don_dv_ct_kh b on a.so_hd=b.so_hd ";
        sql += "where a.so_hd='" + sohd + "' and a.ngay_lap_hd='" + StaticData.CheckDate(ngay_hd) + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rs += "|" + dt.Rows[i]["ma_hang"] + "&" + dt.Rows[i]["ten_hang"] + "&" + dt.Rows[i]["dvt"] + "&" + dt.Rows[i]["tk_co"] + "&" + dt.Rows[i]["so_luong"] + "&" + dt.Rows[i]["don_gia"] + "&" + dt.Rows[i]["thanh_tien"];
            }
        }
        Response.Write(rs);
    }
    public void ket_noi_dl()
    {
        string NgayThu = Request.QueryString["NgayThu"];
        string sql = "Exec spFill_DoanhThu_pmbv2 '" + StaticData.CheckDate_kt(NgayThu) + "','" + StaticData.CheckDate_kt(NgayThu) + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ten_doanh_thu = dt.Rows[i]["ten_doanh_thu"].ToString();
                //string ngay_thu = dt.Rows[i]["ngay_thu"].ToString();
                string ngay_thu = dt.Rows[i]["ngay_thu"].ToString();
                //ngay_thu = ngay_thu.Substring(0, 10);     
                string ngayt = ngay_thu.Substring(8, 2);
                string thangt = ngay_thu.Substring(5, 2);
                string namt = ngay_thu.Substring(2, 2);
                string ma_doanh_thu = dt.Rows[i]["ma_doanh_thu"].ToString();
                if (ma_doanh_thu == "")
                    ma_doanh_thu = "PT" + ngayt + thangt + namt + "_" + i;
                string id_benh_nhan = dt.Rows[i]["id_benh_nhan"].ToString();
                string nguoi_thu = dt.Rows[i]["nguoi_thu"].ToString();
                string thanh_tien = dt.Rows[i]["thanh_tien_bn_tra"].ToString();
                string trang_thai = dt.Rows[i]["trang_thai"].ToString();
                string sql1 = "if(not exists(select * from doanhthu_pmbv2 where ma_doanh_thu ='" + ma_doanh_thu + "')) ";
                sql1 += "insert doanhthu_pmbv2(ma_doanh_thu,ten_doanh_thu,ngay_thu,id_benh_nhan,nguoi_thu,thanh_tien_bn_tra,trang_thai) ";
                sql1 += "values('" + ma_doanh_thu + "',N'" + ten_doanh_thu + "','" + ngay_thu + "'," + id_benh_nhan + "," + nguoi_thu + "," + thanh_tien + "," + trang_thai + ")";
                //sql1 += " else update doanhthu_pmbv2 set trang_thai='"+trang_thai+"' where ma_doanh_thu='"+ma_doanh_thu+"'";
                if (DataAcess.Connect.ExecSQL(sql1))
                    rs = "1";
                else
                    rs = "0";
            }
        }
        else
        {
            rs = "0";
        }
        Response.Write(rs);
    }
    public void LoadDanhSachKhachHang_UNT()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";

        try
        {
            sql = "select top(100) MaKhachHang,TenKhachHang,taikhoannganhang,nganhang,nguoilienhe from KhachHang ";
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaKhachHang  LIKE '" + Key + "%'";
            else
                if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenKhachHang  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            int countItem = dt.Rows.Count;
            if (countItem > 0)
            {
                html += "|<div style=\"width: 500px; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã khách hàng</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên khách hàng</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Người liên hệ</div>";
                html += "</div>|||";

                html += Environment.NewLine;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    //html += "| <div  style=\"cursor: pointer\" onclick=\"setChonKhachHang('" + dt.Rows[i]["MaKhachHang"] + "','" + dt.Rows[i]["TenKhachHang"] + "',)\">";
                    html += "| <div  style=\"cursor: pointer\" onclick=\"setChonKhachHang('" + dt.Rows[i]["MaKhachHang"] + "','" + dt.Rows[i]["TenKhachHang"] + "')\">";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaKhachHang"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenKhachHang"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["taikhoannganhang"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["nganhang"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["MaKhachHang"] + "|" + dt.Rows[i]["TenKhachHang"] + "|" + dt.Rows[i]["taikhoannganhang"] + "|" + dt.Rows[i]["nganhang"] + "|" + dt.Rows[i]["nguoilienhe"];
                    html += Environment.NewLine;
                }
            }
            else
            {
                html = "";
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void Luu_UyNhiemThu()
    {
        try
        {
            string UyNhiemThuID = Request.QueryString["UyNhiemThuID"];
            string So_UNT = Request.QueryString["So_UNT"];
            string NgayLap = Request.QueryString["NgayLap"];
            string MaKH = Request.QueryString["MaKH"];
            string NguoiNopTien = Request.QueryString["NguoiNopTien"];
            string DienGiai = Request.QueryString["DienGiai"];
            string TKNo = Request.QueryString["TKNo"];
            string TongTien = Request.QueryString["TongTien"];
            string TKNganHangKH = Request.QueryString["TKNganHangKH"];
            string TenNganHangKH = Request.QueryString["TenNganHangKH"];
            if (string.IsNullOrEmpty(TongTien))
                TongTien = "0";

            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            string Status = Request.QueryString["Status"];
            //@unc_id,@so_unc,@ngay_lap_unc,@ma_ncc ,@nguoi_nhan ,@dien_giai ,	@tk_co,@loai_nt,@ty_gia,@tien ,@tien_nt,@user_dau ,@user_cuoi,@status
            string sql = "exec spUy_Nhiem_Thu_Save '" + UyNhiemThuID + "','" + So_UNT + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLap) + "','" + MaKH + "',N'" + NguoiNopTien + "',N'" + DienGiai + "','" + TKNo + "',null,null," + TongTien + ",null,N'" + UserDau + "',N'" + UserCuoi + "','" + TKNganHangKH + "',N'" + TenNganHangKH + "',0";
            int rs = DataAcess.Connect.Exec(sql);
            if (rs > 0)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }
    }
    public void Luu_ChiTietUyNhiemThu()
    {
        try
        {
            string SoUNT = Request.QueryString["SoUNT"];
            string TKCo_list = Request.QueryString["TKCo"];
            string[] TKCo = TKCo_list.Split(';');

            string PhatSinhCo_list = Request.QueryString["PhatSinhCo"];
            string[] PhatSinhCo = PhatSinhCo_list.Split(';');

            string ThueSuat_list = Request.QueryString["ThueSuat"];
            string[] ThueSuat = ThueSuat_list.Split(';');

            string TKThue_list = Request.QueryString["TKThue"];
            string[] TKThue = TKThue_list.Split(';');

            string TienThue_list = Request.QueryString["TienThue"];
            string[] TienThue = TienThue_list.Split(';');

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string SoSeri_list = Request.QueryString["SoSeri"];
            string[] SoSeri = SoSeri_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');


            string DienGiai_list = Request.QueryString["DienGiai"];
            string[] DienGiai = DienGiai_list.Split(';');
            string Status = Request.QueryString["Status"];
            bool rs = false;
            for (int i = 1; i < TKCo.Length; i++)
            {
                if (TKCo[i] != "")
                {
                    string sql = "exec spUy_Nhiem_Thu_Ct_Save null,'" + SoUNT + "','" + TKCo[i] + "','" + PhatSinhCo[i] + "',null,'" + ThueSuat[i] + "','" + TKThue[i] + "','" + TienThue[i] + "',null,'" + SoHD[i] + "','" + SoSeri[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "',N'" + DienGiai[i] + "',0";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }

            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void LuuSoCaiUyNhiemThu()
    {
        try
        {

            string SoUNT = Request.QueryString["SoUNT"];
            string NgayLap = Request.QueryString["NgayLap"];
            string MaKH = Request.QueryString["MaKH"];
            string TKNo = Request.QueryString["TKNo"];
            string Dien_giai = Request.QueryString["dien_giai"];

            string TKCo_list = Request.QueryString["TKCo"];
            string[] TKCo = TKCo_list.Split(';');

            string PhatSinhCo_list = Request.QueryString["PhatSinhCo"];
            string[] PhatSinhCo = PhatSinhCo_list.Split(';');

            string TKThue_list = Request.QueryString["TKThue"];
            string[] TKThue = TKThue_list.Split(';');

            string TienThue_list = Request.QueryString["TienThue"];
            string[] TienThue = TienThue_list.Split(';');

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string SoSeri_list = Request.QueryString["SoSeri"];
            string[] SoSeri = SoSeri_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');


            string DienGiai_list = Request.QueryString["DienGiai"];
            string[] DienGiai = DienGiai_list.Split(';');


            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            bool rs = false;
            for (int i = 1; i < TKCo.Length; i++)
            {
                if (TKCo[i] != "")
                {
                    string sql = "exec spUy_Nhiem_Chi_So_Cai_Save null,'" + SoUNT + "','" +
                                                             mdlCommonFunction.ChangeDateTo_MM_dd(NgayLap) + "','" +
                                                             MaKH + "',N'" +
                                                             Dien_giai + "','" +
                                                             TKNo + "','" +
                                                             TKCo[i] + "','" +                                                            
                                                             PhatSinhCo[i] + "','" +                                                             
                                                             SoHD[i] + "','" +
                                                             SoSeri[i] + "','" +
                                                             mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "',N'" +
                                                             UserDau + "',N'" +
                                                             UserCuoi + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }



            if (rs)
            {

                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }

    }
    public void LoadChiTietUyNhiemThuBySoUNT()
    {
        string SoUNT = Request.QueryString["SoUNT"];
        string sql = "select tk_co,ps_co,tk_thue,tien_thue,so_hd,so_seri,convert(varchar,ngay_lap_hd,103)ngay_lap_hd,dien_giai,Thue_Suat " +
                     "  from uy_nhiem_thu_ct" +
                     "  where so_unt = '" + SoUNT + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["tk_co"] + "&" + row["ps_co"] + "&" + row["tk_thue"] + "&" + row["tien_thue"] + "&" + row["so_hd"] + "&" + row["so_seri"] + "&" + row["ngay_lap_hd"] + "&" + row["dien_giai"] + "&" + row["Thue_Suat"];
            }
            Response.Write(rs);
        }
    }
    public void LoadUyNhiemThuBySoUNT()
    {
        string SoUNT = Request.QueryString["SoUNT"];
        string sql = " select unt_id,so_unt,convert(varchar,ngay_lap_unt,103)ngay_lap,ma_kh,kh.tenkhachhang,Dien_Giai,TK_No,SoTaiKhoanKH,TenNganHangKH,Tien,Nguoi_Nop_Tien " +
                     "  from Uy_Nhiem_Thu left join KhachHang kh on kh.makhachhang = ma_kh " +
                     "  where so_unt =  '" + SoUNT + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                rs += "|" + row["unt_id"] + "&" + row["so_unt"] + "&" + row["ngay_lap"] + "&" + row["ma_kh"] + "&" + row["tenkhachhang"] + "&" + row["Dien_Giai"] + "&" + row["TK_No"] + "&" + row["SoTaiKhoanKH"] + "&" + row["TenNganHangKH"] + "&" + row["Tien"] + "&" + row["Nguoi_Nop_Tien"];
            }
            Response.Write(rs);
        }
    }
    public void LoadDanhSachGiayBaoCo()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoPhieu = Request["SoPhieu"];
        string MaKH = Request["MaKH"];
        string tknh = Request.QueryString["tknh"].ToString();
        string sql = "select unt_id,a.so_unt,convert(varchar,ngay_lap_unt,103)ngay_lap,ma_kh,kh.tenkhachhang,a.Dien_Giai,tk_co,SoTaiKhoanKH,TenNganHangKH,	Tien " +
                     "  from Uy_Nhiem_Thu a left join KhachHang kh on kh.makhachhang = a.ma_kh inner join uy_nhiem_thu_ct b on a.so_unt=b.so_unt " +
                     "  where 1=1 ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += " and ngay_lap_unt between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        else
            if (!string.IsNullOrEmpty(TuNgay))
            {
                sql += "    and ngay_lap_unt = '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "'  ";
            }
            else
                if (!string.IsNullOrEmpty(DenNgay))
                {
                    sql += " and ngay_lap_unt = '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
                }
        if (!string.IsNullOrEmpty(SoPhieu))
            sql += "    and a.so_unt = '" + SoPhieu + "'";
        if (!string.IsNullOrEmpty(MaKH))
            sql += "    and ma_kh='" + MaKH + "'";
        if (!string.IsNullOrEmpty(tknh) && !tknh.Equals("0"))
            sql += " and tk_no='" + tknh + "'";

        sql += "    order by convert(varchar,ngay_lap_unt,111) desc, a.so_unt desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//unc_id(0),so_unc(1),ngay_lap(2),ma_ncc(3),ncc.TenNhaCungCap(4),Dien_Giai(5),TK_Co(6),SoTaiKhoanNCC(7),TenNganHangNCC(8),	Tien(9) )
                DataRow row = table.Rows[i];
                rs += "|" + row["unt_id"] + "&" + row["so_unt"] + "&" + row["ngay_lap"] + "&" + row["ma_kh"] + "&" + row["TenKhachHang"] + "&" + row["Dien_Giai"] + "&" + row["tk_co"] + "&" + row["SoTaiKhoanKH"] + "&" + row["TenNganHangKH"] + "&" + row["Tien"];
            }
            Response.Write(rs);
        }
    }
    public void XoaUyNhiemThu()
    {
        try
        {
            string SoUNT = Request.QueryString["SoUNT"];
            string ngay_lap_unt = Request.QueryString["ngay_lap_unt"];

            string sql = "exec spUy_Nhiem_Thu_Delete  '" + SoUNT + "','" + StaticData.CheckDate(ngay_lap_unt) + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    #region hoa don bang hang   

    public void LoadDSPhieuThu_byBenhNhan()
    {
        string NgayThu = Request.QueryString["NgayThu"];
        string idBenhNhan = Request.QueryString["idBenhNhan"];
        string vat = Request.QueryString["vat"];        
        int loaixuat = Convert.ToInt16(Request.QueryString["loaixuat"].ToString());
        string sql = "";
        string result = "";
        try
        {
            if (loaixuat != 8)
            {
                sql = "select a.idphieuxuat,maphieuxuat,convert(varchar(10),ngaythang,103)ngaythang,mabenhnhan,tenbenhnhan,a.ghichu,tkno,thanhtien=ceiling(sum(isnull(soluong,0)*isnull(dongia,0))),ceiling(sum(isnull(c.tienthue,0)))tienthue,ceiling(sum(isnull(c.tienchietkhau,0)))tien_ck,tongtien=ceiling(sum(isnull(soluong,0)*isnull(dongia,0))+sum(isnull(c.tienthue,0))) - ceiling(sum(isnull(c.tienchietkhau,0)))";
                sql += " from phieuxuatkho a left join benhnhan b on a.idkhachhang=b.idbenhnhan left join chitietphieuxuatkho c on a.idphieuxuat=c.idphieuxuat ";
                sql += " where a.loaixuat=" + loaixuat + " and (a.isxuathd=0 or a.isxuathd is null) and convert(varchar,ngaythang,111)='" + StaticData.CheckDate_kt(NgayThu) + "'";
                if (!string.IsNullOrEmpty(idBenhNhan))
                    sql += " and  a.idkhachhang = '" + idBenhNhan + "'";
                if (!string.IsNullOrEmpty(vat))
                    sql += " and c.vat =" + vat + "";
                sql += " group by a.idphieuxuat,maphieuxuat,convert(varchar(10),ngaythang,103),mabenhnhan,tenbenhnhan,a.ghichu,tkno ";
            }
            else
            {
                sql = "select iddangkykham,maphieudangky,ngaydangky,mabenhnhan,tenbenhnhan,dien_giai,taikhoanno,sum(thanhtien)thanhtien,chietkhau=sum(chietkhau),tienthue,tongtien=sum(tongtien) from  ";
                sql += " (select a.iddangkykham,maphieudangky,ngaydangky=convert(varchar(10),ngaydangky,111),mabenhnhan,tenbenhnhan,dien_giai='',taikhoanno,thanhtien=sum(isnull(b.soluong,0))*isnull(giadichvu,0),chietkhau=sum(isnull(b.giamgia,0)),tienthue='',tongtien=sum(isnull(b.soluong,0))*isnull(giadichvu,0)- sum(isnull(b.giamgia,0)) ";
                sql += " from dangkykham a left join chitietdangkykham b on a.iddangkykham=b.iddangkykham left join banggiadichvu c on b.idbanggiadichvu=c.idbanggiadichvu left join benhnhan d on a.idbenhnhan=d.idbenhnhan  ";
                sql += " where (a.isxuathd=0 or a.isxuathd is null) and convert(varchar(10),ngaydangky,111) ='" + StaticData.CheckDate_kt(NgayThu) + "'";                
                if (!string.IsNullOrEmpty(idBenhNhan))
                   sql += " and a.idbenhnhan = '" + idBenhNhan + "'";
               sql += " group by a.iddangkykham,maphieudangky,convert(varchar(10),ngaydangky,111),mabenhnhan,tenbenhnhan,taikhoanno,giadichvu";
               sql += " union select idcls='',maphieucls,ngaythu=convert(varchar,ngaythu,111),mabenhnhan,tenbenhnhan,noidung=N'khám bệnh cận lâm sàn',tkno='',thanhtien=sum(thanhtien),chietkhau,tienthue='',tongtien=sum(thanhtien) ";
                sql += " from khambenhcanlamsan a left join benhnhan b on a.idbenhnhan=b.idbenhnhan ";
                sql += " where convert(varchar(10),ngaythu,111)='" + StaticData.CheckDate_kt(NgayThu) + "'";
                if (!string.IsNullOrEmpty(idBenhNhan))
                    sql += "  and a.idbenhnhan='" + idBenhNhan + "'";
                sql += " group by maphieucls,convert(varchar,ngaythu,111),mabenhnhan,tenbenhnhan,chietkhau ";
                sql += " union select a.idphieuchi,sophieu,ngaychi=convert(varchar,ngaychi,111),mabenhnhan,tenbenhnhan,a.noidung,taikhoanno='',thanhtien=-sum(b.sotien),chietkhau='',tienthue='',tongtien=-sum(b.sotien)";
                sql += " from kb_phieuchi a left join kb_chitietphieuchi b on a.idphieuchi=b.idphieuchi left join benhnhan c on a.idbenhnhan=c.idbenhnhan ";
                sql += " where convert(varchar(10),ngaychi,111)='" + StaticData.CheckDate_kt(NgayThu) + "'";
                if (!string.IsNullOrEmpty(idBenhNhan))
                    sql += "  and a.idbenhnhan='" + idBenhNhan + "'";
                sql += " group by a.idphieuchi,sophieu,convert(varchar,ngaychi,111),mabenhnhan,tenbenhnhan,a.noidung ";
                sql+=" )n ";
                sql += " group by iddangkykham,maphieudangky,ngaydangky,mabenhnhan,tenbenhnhan,dien_giai,taikhoanno,tienthue ";
                sql += " order by mabenhnhan,maphieudangky";
            }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += "|" + dt.Rows[i][0] + "&" + dt.Rows[i][1] + "&" + dt.Rows[i][2] + "&" + dt.Rows[i][3].ToString().Trim() + "&" + dt.Rows[i][4] + "&" + dt.Rows[i][5] + "&" + dt.Rows[i][6] + "&" + dt.Rows[i][7] + "&" + dt.Rows[i][8] + "&" + dt.Rows[i][9] + "&" + dt.Rows[i][10];
            }
            Response.Write(result);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    public void SaveHoaDonBanHang()
    {

        string HoaDonId = Request.QueryString["HoaDonId"];
        string SoHD = Request.QueryString["SoHD"];
        string SoSeri = Request.QueryString["SoSeri"];
        string NgayLapHD = Request.QueryString["NgayLapHD"];
        string MaKH = Request.QueryString["idKH"];
        string TenKH = Request.QueryString["TenKH"];
        string NguoiMua = Request.QueryString["NguoiMua"];
        string DiaChi = Request.QueryString["DiaChi"];
        string MaSoThue = Request.QueryString["MaSoThue"];
        string DienGiai = Request.QueryString["DienGiai"];
        string TKNo = Request.QueryString["TKNo"];
        string TKCo = Request.QueryString["TKCo"];
        string TKThue = Request.QueryString["TKThue"];
        string ThueSuat = Request.QueryString["ThueSuat"];
        string Tien = Request.QueryString["Tien"];
        string TienThue = Request.QueryString["TienThue"];
        string TongTien = Request.QueryString["TongTien"];
        string UserDau = SysParameter.UserLogin.UserName(this);
        string UserCuoi = SysParameter.UserLogin.UserName(this);
        string Status = Request.QueryString["Status"];
        string loai_hd = Request.QueryString["loai_hd"];
        string sql = "exec spHoa_Don_Ban_Hang_Save  '" + HoaDonId + "','" + SoHD + "','" + SoSeri + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD) + "','" + MaKH + "',N'" + TenKH + "',N'" + NguoiMua + "',N'" + DiaChi + "','" + MaSoThue + "',N'" + DienGiai + "','" + TKNo + "','" + TKCo + "','" + TKThue + "','" + ThueSuat + "','" + Tien + "','" + TienThue + "','" + TongTien + "',N'" + UserDau + "',N'" + UserCuoi + "','" + Status + "','" + loai_hd + "'";
        bool rs = DataAcess.Connect.ExecSQL(sql);
        bool rs2 = false;
        if (rs)
        {
            //kiem tra tai khoan khu trung
            string sqltk_khutrung = "select gia_tri from tham_so where tham_so='tai_khoan_khu_trung'";
            DataTable dttkkt = new DataTable();
            dttkkt = DataAcess.Connect.GetTable(sqltk_khutrung);
            string listtkkt = "";
            bool kq = false;
            listtkkt = dttkkt.Rows[0]["gia_tri"].ToString();
            if (!string.IsNullOrEmpty(listtkkt))
            {
                string[] tkkt = listtkkt.Split(',');
                string tkno_kt = TKNo.Substring(0, 3);
                for (int k = 0; k < tkkt.Length; k++)
                {
                    if (tkno_kt.Equals(tkkt[k]))
                        kq = true;
                }
            }
            if (kq != true)
            {
                string sql2 = "exec spHoaDon_SoCai_Save  Null,'" + SoHD + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD) + "','" + MaKH + "',N'" + DienGiai + "','" + TKNo + "','" + TKCo + "','" + TKThue + "','" + Tien + "','" + TienThue + "','" + ThueSuat + "',N'" + UserDau + "',N'" + UserCuoi + "'";
                rs2 = DataAcess.Connect.ExecSQL(sql2);
            }
            Response.Write(1);
        }
        else
            Response.Write(2);
    }
    public void XoaChiTietHoaDonBanHang()
    {
        string SoHD = Request.QueryString["SoHD"];
        string sql = "exec spHoa_Don_Ban_Hang_CT_Delete  '" + SoHD + "'";
        bool rs = DataAcess.Connect.ExecSQL(sql);

        if (rs)
        {
            Response.Write(1);
        }
        else
            Response.Write(2);
    }    
    public void SaveChiTietHoaDonBanHang()
    {
        string SoHD = Request.QueryString["SoHD"];
        string loaihd = Request.QueryString["loaihd"];
        string MaPT_list = Request.QueryString["MaPT"];
        string[] MaPT = MaPT_list.Split(';');
        bool rs = false;
        for (int i = 1; i < MaPT.Length; i++)
        {
            if (SoHD != "")
            {
                string sql = "exec spHoa_Don_Ban_Hang_Ct_Save '" + SoHD + "'," + MaPT[i] + "," + loaihd;
                rs = DataAcess.Connect.ExecSQL(sql);
            }
        }
        if (rs)
        {
            Response.Write(1);
        }
        else
            Response.Write(2);
    }

    public void LoadDanhSachPhieuThuHoaDonBanHang()
    {
        //string key = Request.QueryString["q"];
        string SoHD = Request.QueryString["SoHD"];
        string loaihd = Request.QueryString["loaihd"].ToString().Trim();
        string sql = "";
        string result = "";
        try
        {
            if (loaihd == "1" || loaihd == "2")
            {
                sql = "select a.idphieuxuat,maphieuxuat,convert(varchar(10),ngaythang,103)ngaythang,mabenhnhan,tenbenhnhan,a.ghichu,tkno,thanhtien=sum(isnull(thanhtientruocthue,0)),ceiling(sum(isnull(c.tienthue,0)))tienthue,ceiling(sum(isnull(c.tienchietkhau,0)))tien_ck,tongtien=sum(isnull(thanhtientruocthue,0))+ceiling(sum(isnull(c.tienthue,0))) - ceiling(sum(isnull(c.tienchietkhau,0)))  ";
                sql += " from phieuxuatkho a left join (select * from(select idBenhNhan,MaBenhNhan,TenBenhNhan,NgaySinh,GioiTinh,DiaChi from BenhNhan union  select idkhachhang,makhachhang,tenkhachhang,ngaysinh='',gioitinh='',diachi='' from khachhang) n where mabenhnhan is not null) b on a.idkhachhang=b.idbenhnhan left join chitietphieuxuatkho c on a.idphieuxuat=c.idphieuxuat ";
                sql += " where a.idphieuxuat in (select idphieuxuat from hoa_don_ban_hang_ct where so_hd='" + SoHD + "')";
                sql += " group by a.idphieuxuat,maphieuxuat,convert(varchar(10),ngaythang,103),mabenhnhan,tenbenhnhan,a.ghichu,tkno";
            }
            else
            {
                sql = "select iddangkykham,maphieudangky,ngaydangky,mabenhnhan,tenbenhnhan,dien_giai,taikhoanno,sum(thanhtien)thanhtien,chietkhau=sum(chietkhau),tienthue,tongtien=sum(tongtien) from  ";
                sql += " (select a.iddangkykham,maphieudangky,ngaydangky=convert(varchar(10),ngaydangky,111),mabenhnhan,tenbenhnhan,dien_giai='',taikhoanno,thanhtien=sum(isnull(b.soluong,0))*isnull(giadichvu,0),chietkhau=sum(isnull(b.giamgia,0)),tienthue='',tongtien=sum(isnull(b.soluong,0))*isnull(giadichvu,0)- sum(isnull(b.giamgia,0)) ";
                sql += " from dangkykham a left join chitietdangkykham b on a.iddangkykham=b.iddangkykham left join banggiadichvu c on b.idbanggiadichvu=c.idbanggiadichvu left join benhnhan d on a.idbenhnhan=d.idbenhnhan  ";
                sql += " where a.iddangkykham in (select idphieuxuat from hoa_don_ban_hang_ct where so_hd='" + SoHD + "')";
                sql += " group by a.iddangkykham,maphieudangky,convert(varchar(10),ngaydangky,111),mabenhnhan,tenbenhnhan,taikhoanno,giadichvu)n ";
                sql += " group by iddangkykham,maphieudangky,ngaydangky,mabenhnhan,tenbenhnhan,dien_giai,taikhoanno,tienthue ";
            }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += "|" + dt.Rows[i][0] + "&" + dt.Rows[i][1] + "&" + dt.Rows[i][2] + "&" + dt.Rows[i][3].ToString().Trim() + "&" + dt.Rows[i][4] + "&" + dt.Rows[i][5] + "&" + dt.Rows[i][6] + "&" + dt.Rows[i][7] + "&" + dt.Rows[i][8] + "&" + dt.Rows[i][9] + "&" + dt.Rows[i][10];
            }
            Response.Write(result);
        }

        catch (Exception)
        {
            Response.Write("error");
        }
    }
    public void LoadChiTietHoaDonBanHang()
    {
        string IDHoaDon = Request["IDHoaDon"];
        string sql = "";
        sql += " SELECT HOA_DONID,SO_HD,SO_SERI,CONVERT(VARCHAR,NGAY_LAP_HD,103)NGAY_LAP_HD,MA_KH,TEN_KH,TEN_NGUOI_MUA,DIA_CHI,MA_SO_THUE,DIEN_GIAI,TK_NO,TK_CO,TK_THUE,THUE_SUAT,TIEN,TIEN_THUE,TONG_TIEN,LOAI_HD ";
        sql += " FROM HOA_DON_BAN_HANG WHERE HOA_DONID ='" + IDHoaDon + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {//hoa_donID,so_hd,so_seri,ngay_lap_hd,ma_kh,ten_KH,NguoiMua,DiaChi,MaSoThue,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien
            DataRow row = table.Rows[0];
            rs += "|" + row["hoa_donID"] + "&" + row["so_hd"] + "&" + row["so_seri"] + "&" + row["ngay_lap_hd"] + "&" + row["ma_kh"] + "&" + row["ten_KH"] + "&" + row["ten_nguoi_mua"] + "&" + row["dia_chi"] + "&" + row["ma_so_thue"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tk_co"] + "&" + row["tk_thue"] + "&" + row["thue_suat"] + "&" + row["tien"] + "&" + row["tien_thue"] + "&" + row["tong_tien"] + "&" + row["loai_hd"];
            Response.Write(rs);
        }
    }
    # endregion

    # region //phieu thanh toan tam ung

    public void LuuPhieu_TT_Tam_Ung()
    {
        try
        {
            string PhieuChiID = Request.QueryString["PhieuChiID"];
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string NgayChi = Request.QueryString["NgayChi"];
            string MaNCC = Request.QueryString["MaNCC"];
            string NguoiGiao = Request.QueryString["NguoiGiao"];
            string DienGiai = Request.QueryString["DienGiai"];
            string TKCo = Request.QueryString["TKCo"];
            string Tien = Request.QueryString["TongTien"];
            string DSPhieuChi = Request.QueryString["dsphieuchi"];
            //update vao table phieu_chi nhung phieu chi nao da thanh toan tam ung
            string sqlpc = "";
            sqlpc = " update phieu_chi set istttu=1 ";
            sqlpc += " where so_phieu_chi in (" + DSPhieuChi + ")";
            DataAcess.Connect.ExecSQL(sqlpc);
            //
            string dsphieuchitttu = "";
            dsphieuchitttu = DSPhieuChi.Replace("'", "");
            string TongTienPC = Request.QueryString["tongtienpc"];
            double TongTien;
            if (string.IsNullOrEmpty(Tien))
                TongTien = 0;
            else
                TongTien = double.Parse(Tien);
            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            string Status = Request.QueryString["Status"];
            //SoPhieuChi,ngay_chi,ma_ncc,nguoi_giao,dien_giai,tk_co,loai_nt,ty_gia,tien,tien_nt,user_dau,date_dau,user_cuoi,date_cuoi,status
            string sql = "exec spPhieu_TT_Tam_Ung_Save '" + PhieuChiID + "','" + SoPhieuChi + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayChi) + "','" + MaNCC + "',N'" + NguoiGiao + "',N'" + DienGiai + "','" + TKCo + "',null,null," + TongTien + ",null,'" + dsphieuchitttu + "'," + TongTienPC + ",N'" + UserDau + "',N'" + UserCuoi + "',0";
            int rs = DataAcess.Connect.Exec(sql);
            if (rs > 0)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }
    }

    public void XoaChiTietPhieu_TT_Tam_Ung()
    {
        try
        {
            //so_phieu_chi,tk_no,ps_no,ps_no_nt,tk_thue,tien_thue,tien_thue_nt,so_hd,ngay_lap_hd,tien_tren_hd,da_thanh_toan,con_phai_thanh_toan,thanh_toan,dien_giai,status_fix            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string sql = "exec spPhieu_TT_Tam_Ung_Ct_Delete  '" + SoPhieuChi + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaSoCai_Phieu_TT_Tam_Ung()
    {
        try
        {
            //so_phieu_chi,tk_no,ps_no,ps_no_nt,tk_thue,tien_thue,tien_thue_nt,so_hd,ngay_lap_hd,tien_tren_hd,da_thanh_toan,con_phai_thanh_toan,thanh_toan,dien_giai,status_fix            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string sql = "exec spPhieu_TT_Tam_Ung_So_Cai_Delete '" + SoPhieuChi + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void LuuChiTietPhieu_TT_Tam_Ung()
    {
        try
        {
            //so_phieu_chi,tk_no,ps_no,ps_no_nt,tk_thue,tien_thue,tien_thue_nt,so_hd,ngay_lap_hd,tien_tren_hd,da_thanh_toan,con_phai_thanh_toan,thanh_toan,dien_giai,status_fix            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string TKNo_list = Request.QueryString["TKNo"];
            string[] TKNo = TKNo_list.Split(';');
            string PhatSinhNo_list = Request.QueryString["PhatSinhNo"];
            string[] PhatSinhNo = PhatSinhNo_list.Split(';');

            string TKThue_list = Request.QueryString["TKThue"];
            string[] TKThue = TKThue_list.Split(';');

            string ThueSuat_list = Request.QueryString["ThueSuat"];
            string[] ThueSuat = ThueSuat_list.Split(';');

            string TienThue_list = Request.QueryString["TienThue"];
            string[] TienThue = TienThue_list.Split(';');

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string SoSeri_list = Request.QueryString["SoSeri"];
            string[] SoSeri = SoSeri_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');

            string TienTrenHD = Request.QueryString["TienTrenHD"];

            string DienGiai_list = Request.QueryString["DienGiai"];
            string[] DienGiai = DienGiai_list.Split(';');

            string Status = Request.QueryString["Status"];
            bool rs = false;
            for (int i = 1; i < TKNo.Length; i++)
            {
                if (TKNo[i] != "")
                {
                    string sql = "exec spPhieu_TT_Tam_Ung_Ct_Save null,'" + SoPhieuChi + "','" + TKNo[i] + "','" + PhatSinhNo[i] + "',null,'" + ThueSuat[i] + "','" + TKThue[i] + "','" + TienThue[i] + "',null,'" + SoHD[i] + "','" + SoSeri[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "','" + TienTrenHD + "',null,null,null,N'" + DienGiai[i] + "',0";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void ChiTietPhieu_TT_Tam_Ung()
    {
        string SoPhieuChi = Request.QueryString["SoPhieuChi"];
        string sql = "select phieu_chi_ct_id,tk_no,ps_no,tk_thue,tien_thue,so_hd,so_seri,convert(varchar,ngay_lap_hd,103)ngay_lap_hd,dien_giai,Thue_Suat " +
                     "  from Phieu_TT_Tam_Ung_CT" +
                     "  where So_phieu_chi = '" + SoPhieuChi + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_ct_id"] + "&" + row["tk_no"] + "&" + row["ps_no"] + "&" + row["tk_thue"] + "&" + row["tien_thue"] + "&" + row["so_hd"] + "&" + row["so_seri"] + "&" + row["ngay_lap_hd"] + "&" + row["dien_giai"] + "&" + row["Thue_Suat"];
            }
            Response.Write(rs);
        }
    }
    public void DanhSachPhieu_TT_Tam_Ung()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoPhieuChi = Request["SoPhieuChi"];
        string MaNCC = Request["MaNCC"];
        string sql = "select phieu_chi_id,pc.so_phieu_chi,convert(varchar,ngay_chi,103)ngay_chi,ma_ncc,ncc.TenNhaCungCap,nguoi_giao,pcct.Dien_Giai,tk_no,Tien=isnull(pcct.ps_no,0)+isnull(pcct.tien_thue,0) " +
                     "  from Phieu_TT_Tam_Ung pc left join NhaCungCap ncc on pc.ma_ncc = ncc.manhacungcap right join phieu_TT_tam_ung_ct pcct on pc.so_phieu_chi=pcct.so_phieu_chi" +
                     "  where (pc.isdelete is null or pc.isdelete=0) ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_chi between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(SoPhieuChi))
            sql += "    and pc.so_phieu_chi = '" + SoPhieuChi + "'";
        if (!string.IsNullOrEmpty(MaNCC))
            sql += "    and ma_ncc='" + MaNCC + "'";
        sql += "    order by convert(varchar,ngay_chi,111) desc ,pc.so_phieu_chi desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_id"] + "&" + row["so_phieu_chi"] + "&" + row["ngay_chi"] + "&" + row["ma_ncc"] + "&" + row["TenNhaCungCap"] + "&" + row["Dien_Giai"] + "&" + row["tk_no"] + "&" + row["Tien"];
            }
            Response.Write(rs);
        }
    }
    public void XoaPhieu_TT_Tam_Ung()
    {
        try
        {
            //XoaChiTietPhieu_TT_Tam_Ung();
            //XoaSoCai_Phieu_TT_Tam_Ung();
            string userdelete = SysParameter.UserLogin.UserName(this);
            string sophieu = Request.QueryString["SoPhieuChi"];
            string sql = "exec spPhieu_TTTU_Delete  '" + sophieu + "','" + userdelete + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void LoadPhieu_TT_Tam_Ung_ByIDPhieuChi()
    {
        string idPhieuChi = Request["idPhieuChi"];
        string sql = "select phieu_chi_id,so_phieu_chi,convert(varchar,ngay_chi,103)ngay_chi,ma_ncc,ncc.TenNhaCungCap,nguoi_giao,Dien_Giai,tk_co,Tien " +
                     "  from Phieu_TT_Tam_Ung pc left join NhaCungCap ncc on pc.ma_ncc = ncc.manhacungcap " +
                     "  where 1=1 ";
        if (!string.IsNullOrEmpty(idPhieuChi))
            sql += "    and phieu_chi_id= '" + idPhieuChi + "'";

        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_id"] + "&" + row["so_phieu_chi"] + "&" + row["ngay_chi"] + "&" + row["ma_ncc"] + "&" + row["TenNhaCungCap"] + "&" + row["Dien_Giai"] + "&" + row["tk_co"] + "&" + row["Tien"] + "&" + row["nguoi_giao"];
            }
            Response.Write(rs);
        }
    }
    public void ChiTietPhieu_TT_Tam_Ung_BySoPhieuChi()
    {
        string SoPhieuChi = Request.QueryString["SoPhieuChi"];
        string sql = "select phieu_chi_ct_id,tk_no,ps_no,tk_thue,tien_thue,so_hd,so_seri,convert(varchar,ngay_lap_hd,103)ngay_lap_hd,dien_giai,Thue_Suat " +
                     "  from Phieu_TT_Tam_Ung_CT" +
                     "  where So_phieu_chi = '" + SoPhieuChi + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_ct_id"] + "&" + row["tk_no"] + "&" + row["ps_no"] + "&" + row["tk_thue"] + "&" + row["tien_thue"] + "&" + row["so_hd"] + "&" + row["so_seri"] + "&" + row["ngay_lap_hd"] + "&" + row["dien_giai"] + "&" + row["Thue_Suat"];
            }
            Response.Write(rs);
        }
    }
    # endregion 

    #region danh sach phieu chi tam ung
    public void LoadPhieuTTTU()
    {
        string sopclist = Request.QueryString["sopclist"];
        sopclist = sopclist.Substring(1);
        string sql = "";
        string rs = "";
        sql = "select ma_ncc,phongban=tennhacungcap,nguoilienhe,tongtien=sum(tien) from phieu_chi pc left join nhacungcap ncc on pc.ma_ncc=ncc.manhacungcap ";
        sql += " where so_phieu_chi in (" + sopclist + ") group by ma_ncc,nguoilienhe,tennhacungcap";
        DataTable dt = new DataTable();
        dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            rs = dt.Rows[0]["ma_ncc"] + "|" + dt.Rows[0]["nguoilienhe"] + "|" + dt.Rows[0]["phongban"] + "|" + dt.Rows[0]["tongtien"];
        }
        Response.Write(rs);
    }
    public void DanhSachPhieuChi_TTTU()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoPhieuChi = Request["SoPhieuChi"];
        string MaNCC = Request["MaNCC"];
        string Taikhoan = Request.QueryString["taikhoan"];
        string isthanhtoan = Request.QueryString["isthanhtoan"];
        //lay nhung phieu chi da thanh toan
        string dsphieuchi = "'";
        string dsphieuchikq = "";
        string sqltt = " select dsphieuchi from phieu_tt_tam_ung where dsphieuchi is not null";
        if (!string.IsNullOrEmpty(MaNCC))
            sqltt += " and ma_ncc='" + MaNCC + "'";
        DataTable dttt = new DataTable();
        dttt = DataAcess.Connect.GetTable(sqltt);
        if (dttt != null && dttt.Rows.Count > 0)
        {
            for (int i = 0; i < dttt.Rows.Count; i++)
            {
                if (dttt.Rows[i]["dsphieuchi"].ToString().Trim() != null)
                    dsphieuchi += dttt.Rows[i]["dsphieuchi"].ToString().Trim() + ",";
            }
            dsphieuchi = dsphieuchi.Substring(0, dsphieuchi.Length - 1);
            string[] listphieuchi = dsphieuchi.Split(',');
            if (listphieuchi.Length > 0)
            {
                for (int j = 0; j < listphieuchi.Length; j++)
                {
                    dsphieuchikq += listphieuchi[j] + "','";
                }
                dsphieuchikq = dsphieuchikq.Substring(0, dsphieuchikq.Length - 2);
            }
        }
        //
        string sql = "select phieu_chi_id,pc.so_phieu_chi,convert(varchar,ngay_chi,103)ngay_chi,ma_ncc,ncc.TenNhaCungCap,nguoi_giao,pcct.Dien_Giai,tk_no,Tien=isnull(pcct.ps_no,0)+isnull(pcct.tien_thue,0) " +
                     "  from Phieu_Chi pc left join NhaCungCap ncc on pc.ma_ncc = ncc.manhacungcap right join phieu_chi_ct pcct on pc.so_phieu_chi=pcct.so_phieu_chi" +
                     "  where 1=1 and tk_no like '" + Taikhoan.Trim() + "%'";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_chi between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(SoPhieuChi))
            sql += "    and pc.so_phieu_chi = '" + SoPhieuChi + "'";
        if (!string.IsNullOrEmpty(MaNCC))
            sql += "    and ma_ncc='" + MaNCC + "'";

        if (!string.IsNullOrEmpty(isthanhtoan))
        {
            if (isthanhtoan == "1")
            {
                sql += " and pc.istttu =1";
            }
            else
            {
                sql += " and (pc.istttu is null or pc.istttu=0)";
            }
        }
        sql += "    order by convert(varchar,ngay_chi,111) desc ,pc.so_phieu_chi desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_id"] + "&" + row["so_phieu_chi"] + "&" + row["ngay_chi"] + "&" + row["ma_ncc"] + "&" + row["TenNhaCungCap"] + "&" + row["Dien_Giai"] + "&" + row["tk_no"] + "&" + row["Tien"];
            }
            Response.Write(rs);
        }
    }
    #endregion


    public void DanhSachHoaDonDauVao()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string sohoadon = Request["SoPhieuChi"];
        string MaNCC = Request["MaNCC"];
        string sql = "";
        sql += " select * from( select ma_ncc=manhacungcap,ten_ncc=tennhacungcap,so_phieu_nhap=so_phieu,ngay_nhap=convert(varchar(10),ngay_nhap,111),dien_giai,so_hd,ngay_lap_hd=convert(varchar(10),ngay_lap_hd,103),so_seri,tk_co,hanthanhtoan=convert(varchar(10),hanthanhtoan,103),tientt=sum(tong_tien),tien_da_tt=dbo.ft_congnodatra(so_phieu),tien_chua_tt=sum(tong_tien)-dbo.ft_congnodatra(so_phieu) ";
        sql += " from phieu_nhap_vt a left join phieu_nhap_vt_ct b on a.phieu_nhap_id=b.phieu_nhap_id left join nhacungcap c on a.ma_ncc=c.manhacungcap group by manhacungcap,tennhacungcap,so_phieu,convert(varchar(10),ngay_nhap,111),dien_giai,so_hd,convert(varchar(10),ngay_lap_hd,103),so_seri,tk_co,convert(varchar(10),hanthanhtoan,103) ";
        sql += " union all select c.manhacungcap,tennhacungcap,maphieunhap,ngaythang=convert(varchar(10),ngaythang,111),ghichu,sohoadon,ngayhoadon=convert(varchar(10),ngayhoadon,103),kyhieuhoadon,tkco,hanthanhtoan=convert(varchar(10),hanthanhtoan,103),tientt=sum(b.thanhtien), tien_da_tt=dbo.ft_congnodatra(maphieunhap),tien_chua_tt=sum(b.thanhtien)-dbo.ft_congnodatra(maphieunhap) ";
        sql += " from phieunhapkho a left join chitietphieunhapkho b on a.idphieunhap=b.idphieunhap left join nhacungcap c on a.nhacungcapid=c.nhacungcapid group by c.manhacungcap,tennhacungcap,maphieunhap,convert(varchar(10),ngaythang,111),ghichu,sohoadon,convert(varchar(10),ngayhoadon,103),kyhieuhoadon,tkco,convert(varchar(10),hanthanhtoan,103)) n";
        sql += " where 1=1 ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_nhap between '" +StaticData.CheckDate_kt(TuNgay) + "' and '" + StaticData.CheckDate_kt(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(sohoadon))
            sql += "    and so_hd = '" + sohoadon + "'";
        if (!string.IsNullOrEmpty(MaNCC))
            sql += "    and ma_ncc='" + MaNCC + "'";
        sql += "    order by ngay_nhap desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                rs += "|" + row["ma_ncc"] + "&" + row["ten_ncc"] + "&" + row["tk_co"] + "&" + row["so_phieu_nhap"] + "&" + row["ngay_nhap"] + "&" + row["dien_giai"] + "&" + row["so_hd"] + "&" + row["ngay_lap_hd"] + "&" + row["hanthanhtoan"] + "&" + row["tientt"] + "&" + row["tien_da_tt"] + "&" + row["tien_chua_tt"];
            }
            Response.Write(rs);
        }
    }

    
    #region thanh toan cong no
    public void LoadChiTietThanhToanCongNo()
    {
        string MaPN = Request.QueryString["MaPN"];
       // string[] listMaPn;
        string dk = "";   
        //if(!string.IsNullOrEmpty(MaPN))
            string[] listMaPn =MaPN.Split(';');       
            if (listMaPn.Length > 0)
            {
                dk = " and (";
                if (listMaPn.Length == 1)
                    dk += " so_phieu_nhap='" + listMaPn[0] + "')";
                else
                {
                    for (int i = 1; i < listMaPn.Length; i++)
                    {                        
                        if (i == (listMaPn.Length - 1))
                        {
                            dk += " so_phieu_nhap='" + listMaPn[i] + "')";
                        }
                        else
                            dk += "so_phieu_nhap = '" + listMaPn[i] + "' or ";
                    }
                }
            }        
        string sql = "select * from( select ma_ncc=manhacungcap,ten_ncc=tennhacungcap,so_phieu_nhap=so_phieu,dien_giai,so_hd,ngay_lap_hd=convert(varchar(10),ngay_lap_hd,103),so_seri,tk_co,tientt=sum(tong_tien)-ceiling(dbo.ft_congnodatra(so_phieu)),a.vat,tienthue=ceiling(((sum(tong_tien)-dbo.ft_congnodatra(so_phieu)/(1+a.vat/100))*a.vat)/100) ";
        sql += " from phieu_nhap_vt a left join phieu_nhap_vt_ct b on a.phieu_nhap_id=b.phieu_nhap_id left join nhacungcap c on a.ma_ncc=c.manhacungcap group by manhacungcap,tennhacungcap,so_phieu,dien_giai,so_hd,convert(varchar(10),ngay_lap_hd,103),so_seri,tk_co,a.vat";
        sql += " union all select c.manhacungcap,tennhacungcap,maphieunhap,ghichu,sohoadon,ngayhoadon=convert(varchar(10),ngayhoadon,103),kyhieuhoadon,tkco,tientt=sum(b.thanhtien)-ceiling(dbo.ft_congnodatra(maphieunhap)),a.vat,tienthue=ceiling(((sum(b.thanhtien)-dbo.ft_congnodatra(maphieunhap)/(1+a.vat/100))*a.vat)/100)";
        sql += " from phieunhapkho a left join chitietphieunhapkho b on a.idphieunhap=b.idphieunhap left join nhacungcap c on a.nhacungcapid=c.nhacungcapid group by c.manhacungcap,tennhacungcap,maphieunhap,ghichu,sohoadon,convert(varchar(10),ngayhoadon,103),kyhieuhoadon,tkco,a.vat) n ";
        sql += " where 1=1 " + dk;
        sql += " order by ma_ncc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["ma_ncc"] + "&" + row["ten_ncc"] + "&" + row["tk_co"] + "&" + row["so_hd"] + "&" + row["so_seri"] + "&" + row["ngay_lap_hd"] + "&" + row["dien_giai"] + "&" + row["tientt"] + "&" + row["vat"] + "&" + "1331" + "&" + row["tienthue"] + "&" + row["so_phieu_nhap"]; ;
            }
            Response.Write(rs);
        }
    }     
    #endregion
    
    #region phieu ke toan

    public void LuuPhieuTongHop()
    {
        string NgayLap = Request.QueryString["NgayLap"];
        string SoPhieu = Request.QueryString["SoPhieu"];
        string MaNCC = Request.QueryString["MaNCC"];
        string LoaiTK = Request.QueryString["LoaiTK"];
        string DienGiai = Request.QueryString["DienGiai"];
        string TKCo = Request.QueryString["TKCo"];
        string Tien = Request.QueryString["TongTien"];
        string Loai_nt = Request.QueryString["Loai_nt"];
        string TiGia = Request.QueryString["TiGia"];
        
        string UserDau = SysParameter.UserLogin.UserName(this);
        string UserCuoi = SysParameter.UserLogin.UserName(this);
        string Status = Request.QueryString["Status"];
        //SoPhieuChi,ngay_chi,ma_ncc,nguoi_giao,dien_giai,tk_co,loai_nt,ty_gia,tien,tien_nt,user_dau,date_dau,user_cuoi,date_cuoi,status
        string sql = "Exec spPhieu_Tong_Hop_Save '" + SoPhieu + "','" + StaticData.CheckDate_kt(NgayLap) + "','" + MaNCC + "',N'" + LoaiTK + "',N'" + DienGiai + "','" + TKCo + "','" + Loai_nt + "','" + TiGia + "','" + UserDau + "','" + UserCuoi + "'";
        bool rs = DataAcess.Connect.ExecSQL(sql);
        if (rs == true)
            Response.Write(1);
        else
            Response.Write(0);       
    }
    public void XoaSoCai_PhieuTongHop()
    {
        try
        {
            //so_phieu_chi,tk_no,ps_no,ps_no_nt,tk_thue,tien_thue,tien_thue_nt,so_hd,ngay_lap_hd,tien_tren_hd,da_thanh_toan,con_phai_thanh_toan,thanh_toan,dien_giai,status_fix            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string SoPhieuTongHop = Request.QueryString["SoPhieuTongHop"];
            string sql = "exec spPhieu_Chi_khac_So_Cai_Delete  '" + SoPhieuTongHop + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaPhieuTongHop()
    {
        try
        {
            string SoPhieuTongHop = Request.QueryString["SoPhieuTongHop"];
            string sql = "exec spPhieu_Tong_Hop_Delete  '" + SoPhieuTongHop + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaChiTietPhieuTongHop()
    {
        try
        {
            //so_phieu_chi,tk_no,ps_no,ps_no_nt,tk_thue,tien_thue,tien_thue_nt,so_hd,ngay_lap_hd,tien_tren_hd,da_thanh_toan,con_phai_thanh_toan,thanh_toan,dien_giai,status_fix            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string SoPhieuTongHop = Request.QueryString["SoPhieuTongHop"];
            string sql = "exec spPhieu_Tong_Hop_Ct_Delete  '" + SoPhieuTongHop + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void LuuChiTietPhieuTongHop()
    {
        try
        {
            string SoPhieuChi = "";
            SoPhieuChi = Request.QueryString["SoPhieuTongHop"].ToString();
            string MaDT_list = Request.QueryString["MaDT"];
            string[] MaDT = MaDT_list.Split(';');
            string TenDT_list = Request.QueryString["TenDT"];
            string[] TenDT = TenDT_list.Split(';');
            string TKNo_list = Request.QueryString["TKNo"];
            string[] TKNo = TKNo_list.Split(';');
            string TKCo_list = Request.QueryString["TKCo"];
            string[] TKCo = TKCo_list.Split(';');

            string PhatSinhNo_list = Request.QueryString["PhatSinhNo"];
            string[] PhatSinhNo = PhatSinhNo_list.Split(';');          

            string ThueSuat_list = Request.QueryString["ThueSuat"];
            string[] ThueSuat = ThueSuat_list.Split(';');           

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string SoSeri_list = Request.QueryString["SoSeri"];
            string[] SoSeri = SoSeri_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');
           
            string DienGiai_list = Request.QueryString["DienGiai"];
            string[] DienGiai = DienGiai_list.Split(';');

            string LoaiHD_list = Request.QueryString["LoaiHD"];
            string[] LoaiHD = LoaiHD_list.Split(';');

            string PhongBan_list = Request.QueryString["PhongBan"];
            string[] PhongBan = PhongBan_list.Split(';');

            string loaidt_list = Request.QueryString["loaidt"];
            string[] loaidt = loaidt_list.Split(';');
           
            bool rs = false;
            for (int i = 1; i < TKNo.Length; i++)
            {
                if (TKNo[i] != "")
                {
                    string sql = "exec spPhieu_Tong_Hop_Ct_Save '" + SoPhieuChi + "','" + MaDT[i] + "','" + TKNo[i] + "','" + TKCo[i] + "'," + PhatSinhNo[i] + ",'" + ThueSuat[i] + "','" + SoHD[i] + "','" + SoSeri[i] + "','" + StaticData.CheckDate_kt(NgayLapHD[i]) + "',N'" + DienGiai[i] + "',N'" + LoaiHD[i] + "',N'" + PhongBan[i] + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void LuuSoCai_PhieuTongHop()
    {
        try
        {
            string SoPhieuTongHop = Request.QueryString["SoPhieuTongHop"];
            string NgayLap = Request.QueryString["NgayLap"];            

            string MaDT_list = Request.QueryString["MaDT"];
            string[] MaDT = MaDT_list.Split(';');

            string DienGiai_list = Request.QueryString["DienGiai"];
            string[] DienGiai = DienGiai_list.Split(';');

            string TKNo_list = Request.QueryString["TKNo"];
            string[] TKNo = TKNo_list.Split(';');

            string TKCo_list = Request.QueryString["TKCo"];
            string[] TKCo = TKCo_list.Split(';');            

            string PhatSinhNo_list = Request.QueryString["PhatSinhNo"];
            string[] PhatSinhNo = PhatSinhNo_list.Split(';');
          
            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string SoSeri_list = Request.QueryString["SoSeri"];
            string[] SoSeri = SoSeri_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');

            string ThueSuat_list = Request.QueryString["ThueSuat"];
            string[] ThueSuat = ThueSuat_list.Split(';');

            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            string iskh=Request.QueryString["iskh"];
            string isncc = Request.QueryString["isncc"];
            bool rs = false;
            for (int i = 1; i < TKNo.Length; i++)
            {
                if (TKNo[i] != "")
                {
                    string sql = "exec spPhieu_Tong_Hop_So_Cai_Save '" + SoPhieuTongHop + "','" +
                                                                 StaticData.CheckDate_kt(NgayLap) + "','" +
                                                                 MaDT[i] + "',N'" +
                                                                 DienGiai[i] + "','" +
                                                                 TKNo[i] + "','" +
                                                                 TKCo[i] + "','" +
                                                                 PhatSinhNo[i] + "','" +
                                                                 SoHD[i] + "','" +
                                                                 SoSeri[i] + "','" +
                                                                 StaticData.CheckDate_kt(NgayLapHD[i]) + "','" +
                                                                 ThueSuat[i] + "',N'" +
                                                                 UserDau + "',N'" +
                                                                 UserCuoi + "','" + iskh + "','" + isncc + "'";
                    rs = DataAcess.Connect.ExecSQL(sql);
                }
            }

            if (rs)
                Response.Write(1);
            else
                Response.Write(0);

        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XemChiTietPhieuTongHop()
    {
        string SoPhieuTongHop = "";
        string rs = "";
        SoPhieuTongHop = Request.QueryString["SoPhieuTongHop"];
        string sql = " select phieu_th_id=phieu_tong_hop_id, a.so_phieu,ngay_lap=convert(varchar(10),ngay_lap,103),a.ma_doi_tuong,a.loaidt,ten_dt=c.ten_dt,tk_no,tk_co,a.dien_giai,ps_no,so_seri,so_hd,ngay_lap_hd=convert(varchar(10),ngay_lap_hd,103),thue_suat,loai_hd=loai_hoa_don,phong_ban ";
        sql += " from phieu_tong_hop_ct a left join phieu_tong_hop b on a.so_phieu=b.so_phieu left join (select * from(select ma_dt=makhachhang,ten_dt=tenkhachhang,diachi from khachhang union select manhacungcap,tennhacungcap,diachi  from nhacungcap)n where ma_dt is not null) c on a.ma_doi_tuong=c.ma_dt";
        sql += " where a.so_phieu = '" + SoPhieuTongHop + "'";
        try
        {
            DataTable table = DataAcess.Connect.GetTable(sql);           
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                    DataRow row = table.Rows[i];
                    rs += "|" + row["phieu_th_id"] + "&" + row["ma_doi_tuong"] + "&" + row["ten_dt"] + "&" + row["tk_no"] + "&" + row["tk_co"] + "&" + row["ps_no"] + "&" + row["dien_giai"] + "&" + row["so_seri"] + "&" + row["so_hd"] + "&" + row["ngay_lap_hd"] + "&" + row["thue_suat"] + "&" + row["loai_hd"] + "&" + row["phong_ban"] + "&" + row["loaidt"];
                }
                Response.Write(rs);
            }
        }
        catch
        {
            Response.Write(rs);
        }
    }
    public void LoadPhieuTongHop()
    {
        string idPhieuTongHop = Request["idPhieuTongHop"];
        string sql = "";
        sql += "select phieu_th_id=phieu_tong_hop_id,so_phieu,ngay_lap=convert(varchar(20),ngay_lap,103),ma_dt,ten_dt,diachi,dien_giai,loai_tk=loai_tai_khoan,tai_khoan,loai_nt=(select ma_nt from dmngoaite where ngoai_te_id=loai_nt),ty_gia  ";
        sql += " from phieu_tong_hop a left join (select*from(select ma_dt=makhachhang,ten_dt=tenkhachhang,diachi from khachhang union select manhacungcap,tennhacungcap,diachi  from nhacungcap)n where ma_dt is not null) b on a.ma_doi_tuong=b.ma_dt  ";
        sql += " where 1=1 ";
        if (!string.IsNullOrEmpty(idPhieuTongHop))
            sql += "    and phieu_tong_hop_id= '" + idPhieuTongHop + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_th_id"] + "&" + row["so_phieu"] + "&" + row["ngay_lap"] + "&" + row["ma_dt"] + "&" + row["ten_dt"] + "&" + row["diachi"] + "&" + row["dien_giai"] + "&" + row["loai_tk"] + "&" + row["tai_khoan"] + "&" + row["loai_nt"] + "&" + row["ty_gia"];
            }
            Response.Write(rs);
        }
    }

    public void DanhSachPhieuTongHop()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoPhieuTH = Request["SoPhieuTH"];
        string MaDT = Request["MaDT"];
        string sql = "";
        sql += " select phieu_tong_hop_id,a.so_phieu,ngay_lap=convert(varchar(10),ngay_lap,103),a.ma_doi_tuong,ten_dt=(select ten_dt from(select ma_dt=makhachhang,ten_dt=tenkhachhang from khachhang union select manhacungcap,tennhacungcap from nhacungcap)n where ma_dt=a.ma_doi_tuong),a.dien_giai, loai_tk=case when loai_tai_khoan='0' then 'TK Nợ' else 'TK Có' end,tai_khoan,tong_tien=sum(ps_no)";
        sql += " from phieu_tong_hop a left join phieu_tong_hop_ct b on a.so_phieu=b.so_phieu ";
        sql += " where 1=1 ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_lap between '" + StaticData.CheckDate_kt(TuNgay) + "' and '" + StaticData.CheckDate_kt(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(SoPhieuTH))
            sql += "    and a.so_phieu = '" + SoPhieuTH + "'";
        if (!string.IsNullOrEmpty(MaDT))
            sql += "    and a.ma_doi_tuong='" + MaDT + "'";
        sql += " group by phieu_tong_hop_id, a.so_phieu,convert(varchar(10),ngay_lap,103),a.ma_doi_tuong,a.dien_giai,loai_tai_khoan,tai_khoan";
        sql += " order by convert(varchar(10),ngay_lap,103) desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_tong_hop_id"] + "&" + row["so_phieu"] + "&" + row["ngay_lap"] + "&" + row["ma_doi_tuong"] + "&" + row["ten_dt"] + "&" + row["dien_giai"] + "&" + row["loai_tk"]  + "&" + row["tai_khoan"] + "&" + row["tong_tien"];
            }
            Response.Write(rs);
        }
    }
    public void LoadDanhSachDoiTuong()
    {
        //bao gom khach hang va nha cung cap
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";

        html += Environment.NewLine;
        try
        {
            sql = "select * from (select ma_dt=makhachhang,ten_dt=tenkhachhang,diachi,loaidt='kh' from khachhang union select manhacungcap,tennhacungcap,diachi,loaidt='ncc' from nhacungcap)n where ma_dt is not null ";
            if (type == "txtMaDT" && !string.IsNullOrEmpty(Key))
                sql += " and ma_dt  LIKE '" + Key + "%'";
            else
                if (type == "txtTenDT" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  and ten_dt  LIKE N'%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                html += "|<div style=\"width: 400px; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã ĐT</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên đối tượng</div>";
                html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Loại ĐT</div>";
                html += "</div>";
                html += "</div>|";
                html += Environment.NewLine;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonNCC('" + dt.Rows[i]["ma_dt"] + "','" + dt.Rows[i]["ten_dt"] + "')\">";
                    html += "<p style=\"width: 50px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ma_dt"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ten_dt"] + "</p>";
                    html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["loaidt"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["ma_dt"] + "|" + dt.Rows[i]["ten_dt"] + "|" + dt.Rows[i]["diachi"] + "|" + dt.Rows[i]["loaidt"];
                    html += Environment.NewLine;
                }
            }
            else
                html = "";

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void LoadDanhSachDoiTuong2()
    {
        //bao gom khach hang va nha cung cap
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";

        html += Environment.NewLine;
        try
        {
            sql = "select * from (select ma_dt=makhachhang,ten_dt=tenkhachhang,diachi,loaidt='kh' from khachhang union select manhacungcap,tennhacungcap,diachi,loaidtt='ncc' from nhacungcap)n where ma_dt is not null ";
            if (type == "txtMaDT" && !string.IsNullOrEmpty(Key))
                sql += " and ma_dt  LIKE '" + Key + "%'";
            else
                if (type == "txtTenDT" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  and ten_dt  LIKE N'%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                html += "|<div style=\"width: 300px; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã ĐT</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên đối tượng</div>";
                html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Loại ĐT</div>";
                html += "</div>";
                html += "</div>|";
                html += Environment.NewLine;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonDT('" + dt.Rows[i]["ma_dt"] + "','" + dt.Rows[i]["ten_dt"] + "')\">";
                    html += "<p style=\"width: 50px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ma_dt"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ten_dt"] + "</p>";
                    html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["loaidt"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["ma_dt"] + "|" + dt.Rows[i]["ten_dt"] + "|" + dt.Rows[i]["loaidt"];
                    html += Environment.NewLine;
                }
            }
            else
                html = "";

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    private void phongSearch()
    {        
        string Key = Request.QueryString["q"];       
        string sql = "";
        string html = "";

        html += Environment.NewLine;
        try
        {
            sql = "select maphongban,tenphongban from phongban  ";
            sql += "  Where maphongban  LIKE '" + Key + "%'";                
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                html += "|<div style=\"width: 300px; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã phòng</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên phòng</div>";
                html += "</div>";
                html += "</div>|";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonPB('" + dt.Rows[i]["maphongban"] + "','" + dt.Rows[i]["tenphongban"] + "')\">";
                    html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["maphongban"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["tenphongban"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["maphongban"] + "|" + dt.Rows[i]["tenphongban"];
                    html += Environment.NewLine;
                }
            }
            else
                html = "";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }

    #endregion

    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    //------------------------------LongLQ Add code---------------------
    //Ham tim kiem khach hang/nha cung cap
    public void kiemtrathongtintable()
    {
        int rs = 0;
        string tenbang = Request.QueryString["tenbang"].ToString().Trim();
        string tenfield = Request.QueryString["tenfield"].ToString().Trim();
        string dieukien = Request.QueryString["dieukien"].ToString().Trim();
        string sql = "select * from " + tenbang + " where (isdelete is null or isdelete =0) and " + tenfield + " like N'" + dieukien + "%'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(dieukien))
            rs = 1;
        else
            rs = 0;

        Response.Write(rs.ToString());
    }
    //Them moi khach hang
    public void themkhachhang()
    {
        string makh = Request.QueryString["makh"].ToString();
        string tenkh = Request.QueryString["tenkh"].ToString();
        string diachi = Request.QueryString["diachi"].ToString();
        string nguoilienhe = Request.QueryString["nguoinoptien"].ToString();
        string sql = "";
        string sql2 = "";
        sql = "insert khachhang(makhachhang,tenkhachhang,diachi,nguoilienhe) values('" + makh + "',N'" + tenkh + "',N'" + diachi + "',N'" + nguoilienhe + "')";
        sql2 = "select * from khachhang where makhachhang='" + makh + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql2);
        if (dt != null && dt.Rows.Count < 1)
        {
            DataAcess.Connect.ExecSQL(sql);
        }
    }
    public void themnhacungcap()
    {
        string mancc = Request.QueryString["mancc"].ToString();
        string tenncc = Request.QueryString["tenncc"].ToString();
        string diachi = Request.QueryString["diachi"].ToString();
        string nguoilienhe = Request.QueryString["nguoilienhe"].ToString();
        string nganhang = Request.QueryString["nganhang"].ToString();
        string tknganhang = Request.QueryString["tknganhang"].ToString();
        string sql = "";
        string sql2 = "";
        sql = "insert nhacungcap(manhacungcap,tennhacungcap,diachi,nguoilienhe,nganhang,taikhoannganhang)";
        sql += " values('" + mancc + "',N'" + tenncc + "',N'" + diachi + "',N'" + nguoilienhe + "',N'" + nganhang + "','" + tknganhang + "')";
        sql2 = "select * from nhacungcap where manhacungcap='" + mancc + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql2);
        if (dt != null && dt.Rows.Count < 1)
        {
            DataAcess.Connect.ExecSQL(sql);
        }
    }

    #endregion
    public void luuchitiethoadon_dvkhac()
    {
        bool rs = false;
        try
        {

            string so_hd = Request.QueryString["so_hd"];

            string tenhang_list = Request.QueryString["ten_dich_vu"];
            string[] ten_hang = tenhang_list.Split(';');

            string tkco_list = Request.QueryString["tk_co"];
            string[] tk_co = tkco_list.Split(';');

            string thanhtien_list = Request.QueryString["tien_dich_vu"];
            string[] thanh_tien = thanhtien_list.Split(';');
            string sql = "";
            for (int i = 1; i < ten_hang.Length; i++)
            {
                sql = "Exec spHoaDonDVCTKhac_save '" + so_hd + "',N'" + ten_hang[i] + "','" + tk_co[i] + "'," + Convert.ToDecimal(thanh_tien[i]) + "," + i;
                rs = DataAcess.Connect.ExecSQL(sql);
            }
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }

    #region doanh thu theo khoa

    public void DanhSachPhieuThu_Khoa()
    {
        string ngaythu = Request["ngaythu"];
        string sophieuthu = Request["sophieuthu"];
        //string mabn = Request["mabn"];
        string nguoidung = Request.QueryString["nguoidung"];
        string isthu = Request.QueryString["isthu"];
        Int32 tongtien = 0;
        string sql = "select maphieu,ngaylap=sysdate,mabenhnhan,tenbenhnhan,noidungthu,khoa,sum(tongtien)tongtien  from hs_dsdathu ";
        sql += " where sysdate> dateadd(day,-1,'" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00') and sysdate <='" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00' and isdahuy is null  and tennguoithu=N'" + nguoidung.Trim() + "' ";
        if (!string.IsNullOrEmpty(sophieuthu))
            sql += "    and maphieu = '" + sophieuthu + "'";
        if (isthu == "1")
            sql += " and isketoanthu=1";
        else
            sql += " and (isketoanthu is null or isketoanthu=0)";
        //if (!string.IsNullOrEmpty(mabn))
        //    sql += "    and mabenhnhan='" + mabn + "'";
        sql += " group by maphieu,sysdate,mabenhnhan,tenbenhnhan,noidungthu,khoa";
        sql += "    order by maphieu ";
        DataTable table = DataAcess.Connect.GetTable(sql);       
        string rs = "";
        string sqlupdate = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                rs += "|" + row["maphieu"] + "&" + row["ngaylap"] + "&" + row["mabenhnhan"] + "&" + row["tenbenhnhan"] + "&" + row["noidungthu"] + "&" + row["khoa"] + "&" + row["tongtien"];
                tongtien += Int32.Parse(row["tongtien"].ToString());
                sqlupdate = "update hs_dsdathu set isketoanchon=1 where  maphieu='" + row["maphieu"] + "'";
                bool kq=DataAcess.Connect.ExecSQL(sqlupdate);
            }
            rs = rs + "$" + tongtien.ToString();
            Response.Write(rs);
        }
    }

    public void updatedsdathu()
    {
        string ngaythu = Request.QueryString["ngaythu"].ToString().Trim();
        string nguoidung = Request.QueryString["nguoidung"].ToString().Trim();       
        string sql = "";
        string rs="";
        sql = "update hs_dsdathu set isketoanthu=1 where isketoanchon=1 and tennguoithu=N'" + nguoidung + "' and sysdate> dateadd(day,-1,'" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00') and sysdate <='" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00'";
        bool kq = DataAcess.Connect.ExecSQL(sql);
        if (kq)
            rs = "1";
        else
            rs = "0";
        Response.Write(rs);
    }
    public void doanhthukhoa()
    {
        string ngaythu = Request["ngaythu"];
        string sophieuthu = Request["sophieuthu"];       
        string nguoidung = Request.QueryString["nguoidung"];      
        string sql = "select tkdoanhthu=(select tkdoanhthu from phongkhambenh where tenphongkhambenh=khoa),khoa,sum(tongtien)tongtien from hs_dsdathu ";
        sql += " where sysdate> dateadd(day,-1,'" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00') and sysdate <='" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00' and isdahuy is null and (isketoanthu is null or isketoanthu=0) and tennguoithu=N'" + nguoidung.Trim() + "' ";
        if (!string.IsNullOrEmpty(sophieuthu))
            sql += "    and maphieu = '" + sophieuthu + "'";       
        sql += " group by khoa";        
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";       
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                rs += "|" + row["tkdoanhthu"] + "$" + row["khoa"] + "$" + row["tongtien"];                        
            }            
            Response.Write(rs);
        }
    }
    #endregion

    public void ket_chuyen_so_du_tk()
    {
        Int16 tunam = Convert.ToInt16(Request.QueryString["tunam"].ToString());
        string tungay = tunam.ToString() + "/" + "12" + "/" + "01";
        string denngay = tunam + "/" + "12" + "/" + "31";
        decimal du_no = 0;
        decimal du_co = 0;
        int dennam = Convert.ToInt16(Request.QueryString["dennam"].ToString());
        string sql = "";
        string sql2 = "";
        string sql3 = "";
        string tk = "";
        string rs = "";
        try
        {
            sql3 = "if exists(select * from so_du_tk_dau_ky where nam=" + dennam + ") delete so_du_tk_dau_ky where nam=" + dennam;
            DataAcess.Connect.ExecSQL(sql3);
            DataTable dt = mdlCommonFunction.thamsotuychon();
            string ngaydaunam = StaticData.CheckDate(dt.Rows[7][1].ToString());
            sql = "Exec spKetChuyenSoDu_TaiKhoan  '" + ngaydaunam + "','" + tungay + "','" + denngay + "'";
            DataTable dtkc = DataAcess.Connect.GetTable(sql);
            if (dtkc != null && dtkc.Rows.Count > 0)
            {
                for (int i = 0; i < dtkc.Rows.Count; i++)
                {
                    du_no = Convert.ToDecimal(dtkc.Rows[i]["no_ck"].ToString());
                    du_co = Convert.ToDecimal(dtkc.Rows[i]["co_ck"].ToString());
                    tk = dtkc.Rows[i]["tai_khoan"].ToString();
                    sql2 = "insert So_Du_TK_Dau_Ky(nam,tai_khoan,du_no0,du_co0)";
                    sql2 += " values(" + dennam + ",'" + tk + "'," + du_no + "," + du_co + ")";
                    if (DataAcess.Connect.ExecSQL(sql2))
                        rs = "1";
                    else
                        rs = "0";
                }
            }
        }
        catch
        {
            rs = "0";
        }
        Response.Write(rs);
    }
}

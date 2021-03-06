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
    public SqlConnection conn = new SqlConnection();
    //public SqlConnection Conn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = data.getConn();
        conn.Open();
        string action = data.escape(Request.QueryString["do"]);
        switch (action)
        {
            case "timkiem": TimKiem(); break;
            case "timkiem1": TimKiem1(); break;
            case "timkiem2": TimKiem2(); break;
            case "timkiem3": TimKiem3(); break;
            case "timkiem4": TimKiem4(); break;
            case "danhsachtaikhoan": DanhSachTaiKhoan(); break;
            case "danhsachtaikhoan1": DanhSachTaiKhoan1(); break;
            case "danhsachtaikhoan2": DanhSachTaiKhoan2(); break;
            case "danhsachtaikhoan3": DanhSachTaiKhoan3(); break;
            case "danhsachtaikhoan4": DanhSachTaiKhoan4(); break;
            case "dstaikhoan": DanhSachTaiKhoan5(); break;
            case "DanhSachTaiKhoan_Jquery": DanhSachTaiKhoan_Jquery(); break;
           
          

            case "LoadVTYTtheonhom": LoadVTYTtheonhom(); break;
            case "getalldanhsachVTYT": GetDanhSachVTYT(); break;
            case "getalldanhsachThuoc": GetDanhSachThuoc(); break;
            case "LuuNX_VTYT": LuuNX_VTYT(); break;
            case "loadchitietkho": loadChiTietKho(); break;//ThuanNH 04/05/2010
            //Check ma kho
            case "checkmakhofromkho": CheckMakhoFromKho(); break;
            //ThuanNH 11/05/2010f
            case "LuuThuChiTM": LuuThuChiTM(); break;
            case "XoaThuChiTM": XoaThuChiTM(); break;
            case "SuaThuChiTM": SuaThuChiTM(); break;
            case "SaveThuChiKhacTM": SaveThuChiKhacTM(); break;
            case "LoadDVNop": LoadDVNop(); break;
            case "LoadDVNhan": LoadDVNhan(); break;

            case "checkmanccfromnhacc": CheckTrungMaNhaCungCap(); break;
            case "loadchitietnhacungcap": LoadChiTietThongTinNhaCungCap(); break;

            //ThuanNH 25/05/2010
            case "danhsachhoadon": Loaddanhsachhoadon(); break;
            case "searchdanhsachhoadon": Loadsearchdanhsachhoadon(); break;

            //ThuanNH 01/06/2010
            case "danhsachhoadon1": Loaddanhsachhoadon1(); break;
            case "LuuCanTru": LuuCanTruCongNo(); break;
            
            //ThuanNH 02/06/2010
            case "LuuChungTuTH": LoadLuuChungTuTH(); break;

            case "LuuThuChiNH": LuuThuChiNH(); break;

            //ThuanNH 26/05/2010
            case "LuuUyNhiemChi": LuuUyNhiemChi(); break;
            case "danhsachunc": LoaddanhsachUNC(); break;
            case "LoadSuaUNC": LoadSuaUNC(); break;
            case "XoaUNC": XoaUNC(); break;
            case "SuaUNC": SuaUNC(); break;
            case "ChonTKNH": ChonTKNH(); break;

            //ThuanNH 28/06/2010
            case "LoadDanhSachCCDC": LoadDanhSachCCDC(); break;

            //ThuanNH 18/08/2010
            case "LoadDMThuoc": LoadDMThuoc(); break;
            case "LoadDMThuoc1": LoadDMThuoc1(); break;
            case "LoadDMThuoc2": LoadDMThuoc2(); break;
            case "GetDonGia": GetDonGia(); break;//add 23/03/2011 - 11:35AM

            //ThuanNH 26/09/2010
            case "LoadDDNCC": LoadDDNCC(); break;
            //ThuanNH add 21/11/2010 - showlistthuoc
            case "ShowListThuoc": ShowListThuoc(); break;
            case "editthongtinphieunhap": editthongtinphieunhap(); break;
            //ThuanNH add 15/01/2011 - set tk kho
            case "SetTKKho": SetTKKho(); break;
            //ThuanNH add 06/01/2011 - Load danh sach thuoc
            case "getallthuoc": LoadDanhSachThuoc(); break;
            case "loadchangethuoc1": LoadChangeThuoc1(); break;

            //Luu phieu nhap
            case "luuphieunhap": LoadLuuPhieuNhap(); break;
            //Load chi tie phieu nhap
            case "loaddanhsachchitietphieunhap": LoadDanhsachChiTietPhieuNhap(); break;
            case "luuctphieunhap": LoadLuuChiTietPhieuNhap(); break;
            case "loadedititemphieunhap": EditItemPhieuNhap(); break;
            case "loaddeleteitemphieunhap": DeleteItemPhieuNhap(); break;

            //ThuanNH 16/02/2011
            case "getallsanpham": LoadDanhSachSP(); break;
            case "loadchangesp": LoadSP(); break;

            case "editthongtinphieuxuat": editthongtinphieuxuat(); break;
            case "getncc": getncc(); break;//11/05/2011 - 1:24PM
            case "SetNCC": SetNCC(); break;
            case "getncc1": getncc1(); break;//11/05/2011 - 1:24PM
            case "SetNCC1": SetNCC1(); break;
            case "LoadTKNH": LoadTKNH(); break;//16/05/2011 - 4:13PM
            case "LoadTieuDe": LoadTieuDe(); break;

            case "getallthuoc_JQuery": LoadDanhSachThuoc_Jquery(); break;
            case "GetTyGia": GetTyGia(); break;
            case "GetTKNH": GetTKNH(); break;

            //=====================Ngoc 05/07 -> --/09=========================================

           

            case "LoadDanhSachSanPham_Jquery": LoadDanhSachSanPham_Jquery(); break;
            case "SaveBangGiaSanPham": SaveBangGiaSanPham(); break;
            case "UpdateBangGiaSanPham": UpdateBangGiaSanPham(); break;
            case "ShowSanPham": ShowSanPham(); break;
            case "LoadKenh": LoadKenh(); break;
            case "SaveBangGiaTyGia": SaveBangGiaTyGia(); break;

            //=============================KẾ TOÁN MINH ĐỨC =================================================
            case "TaoMaSoTuDong": TaoMaSoTuDong(); break;
            case "TaoMaSoTuDong_TheoNgayTuChon": TaoMaSoTuDong_TheoNgayTuChon(); break;
            case "TestMaTaiKhoan": TestMaTaiKhoan(); break;
            case "TestSoHoaDon": TestSoHoaDon(); break;
            case "TestTrangThaiHoaDon": TestTrangThaiHoaDon(); break;
            case "DanhSachTaiKhoan_Jquery2": DanhSachTaiKhoan_Jquery2(); break;
            case "DanhSachTaiKhoanNganHang": DanhSachTaiKhoanNganHang(); break;
            case "LoadDanhSachBenhNhan": LoadDanhSachBenhNhan(); break;
            case "LoadDanhSachBenhNhan2": LoadDanhSachBenhNhan2(); break;
            case "LoadDanhSachKhachHang": LoadDanhSachKhachHang(); break;
            case "LoadDanhSachKhachHang2": LoadDanhSachKhachHang2(); break;
            case "LoadDanhSachNhaCungCap": LoadDanhSachNhaCungCap(); break;
            case "LoadDanhSachNhaCungCap2": LoadDanhSachNhaCungCap2(); break;
            case "LoadDanhSachNhaCungCap3": LoadDanhSachNhaCungCap3(); break;
            case "LoadDanhSachPhieuThu_byBenhNhan": LoadDanhSachPhieuThu_byBenhNhan(); break;
            case "LoadDanhSachPhieuThu_byKhachLe": LoadDanhSachPhieuThu_byKhachLe(); break;
            case "CapNhatTrangThaiDoanhThu": CapNhatTrangThaiDoanhThu(); break;
            case "LoadDanhSachHoaDon": LoadDanhSachHoaDon(); break;

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
            case "Luu_ChiTietUyNhiemChi": Luu_ChiTietUyNhiemChi(); break;
            case "LuuSoCaiUyNhiemChi": LuuSoCaiUyNhiemChi(); break;
            case "XoaChiTietUyNhiemChi": XoaChiTietUyNhiemChi(); break;
            case "XoaSoCai": XoaSoCai(); break;
            case "LoadChiTietUyNhiemChiBySoUNC": LoadChiTietUyNhiemChiBySoUNC(); break;
            case "LoadUyNhiemChiBySoUNC": LoadUyNhiemChiBySoUNC(); break;
            case "LoadDanhSachUyNhiemChi": LoadDanhSachUyNhiemChi(); break;
            case "XoaUyNhiemChi": XoaUyNhiemChi(); break;

            case "LuuSoDuDauKyTaiKhoan": LuuSoDuDauKyTaiKhoan(); break;
            case "LoadSoDuDauKyTaiKhoanByNam": LoadSoDuDauKyTaiKhoanByNam(); break;
            case "LuuCongNoDauKy": LuuCongNoDauKy(); break;
            case "LoadDanhSachCongNoDauKy": LoadDanhSachCongNoDauKy(); break;


            case "LoadDanhSachTaiSan": LoadDanhSachTaiSan(); break;
            case "LoadDanhMucTaiSan": LoadDanhMucTaiSan(); break;
            case "LuuKhauHaoTaiSan"  : LuuKhauHaoTaiSan();break;
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

            case "LuuDanhMucCongCuDungCuAndSoCai": LuuDanhMucCongCuDungCuAndSoCai(); break;
            case "XoaCongCuDungCu_SoCai": XoaCongCuDungCu_SoCai(); break;
            case "LoadThongTinCongCuDungCu": LoadThongTinCongCuDungCu(); break;
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
        }
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
    
    public void CheckIsPhieuPhanBoCCDC()
    {
        int thang = Int32.Parse(Request.QueryString["thang"].ToString());
        int nam = Int32.Parse(Request.QueryString["nam"].ToString());
        string rs = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = DataAcess.Connect.GetConnection();
            if (!con.State.ToString().Equals("Open"))
            {
                con.Open();
            }

            cmd.Connection = con;
            string sql = "select top(1) ma_ct from So_Cai where Ma_CT like 'KHCC%' and Month(Ngay_lap_ct)=@Thang and year(Ngay_Lap_Ct)=@Nam";
            cmd.Parameters.Add(new SqlParameter("@Thang", SqlDbType.Int));
            cmd.Parameters["@Thang"].Value = thang;

            cmd.Parameters.Add(new SqlParameter("@Nam", SqlDbType.Int));
            cmd.Parameters["@Nam"].Value = nam;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    rs = dr[0].ToString();
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
        string date = nam.ToString() + "/" + thang.ToString() + "/01";
        string sql = "exec spCCDC_Load  '" + date + "'";
        string rs = "";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //ccdc.Ma_CCDC,dm.Ten_CCDC,dm.Nguyen_Gia,dm.So_Thang_Khau_Hao ,dm.TK_Phan_Bo ,dm.TK_Chi_Phi ,ccdc.GiaTriKH  ,ccdc.Dien_Giai
                rs += "&" + table.Rows[i][0] + "|" + table.Rows[i][1] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + "|" + table.Rows[i][4] + "|" + table.Rows[i][5] + "|" + table.Rows[i][6] + "|" + table.Rows[i][7];
            }
        }
        Response.Write(rs);
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
        SqlConnection con = new SqlConnection();
        con.ConnectionString = DataAcess.Connect.GetConnectionString();
        if (!con.State.ToString().Equals("Open"))
        {
            con.Open();
        }
        string sqlCheck = "select * from KhauHaoCongCuDungCu where 1=1  ";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = sqlCheck;
        cmd.CommandType = CommandType.Text;

        if (MaCCDC != "")
        {
            sqlCheck += "  and Ma_ccdc = @MaCCDC ";
            cmd.Parameters.Add(new SqlParameter("@MaCCDC", SqlDbType.NVarChar));
            cmd.Parameters["@MaCCDC"].Value = MaCCDC;
        }
        if (Thang != 0)
        {
            sqlCheck += "   and thang = @Thang";
            cmd.Parameters.Add(new SqlParameter("@Thang", SqlDbType.Int));
            cmd.Parameters["@Thang"].Value = Thang;
        }
        if (Nam != 0)
        {
            sqlCheck += "   and nam = @Nam";
            cmd.Parameters.Add(new SqlParameter("@Nam", SqlDbType.Int));
            cmd.Parameters["@Nam"].Value = Nam;
        }


        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows)
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

                if (MaCCDC.Length > 0)
                {
                    for (int i = 0; i < GiaTriKH.Length; i++)
                    {
                        if (GiaTriKH[i] != "" && GiaTriKH[i] != "0")
                        {
                            string sql = "exec spPhanBo_CCDC_Save null,'" + MaCCDC[i] + "','" + Thang + "','" + Nam + "','" + GiaTriKH[i] + "',N'" + DienGiai + "'";
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
                    rs = IsExitsKhauHaoCCDC(MaCCDC, Thang, Nam);
                    if (rs == 1)
                    {
                        if (GiaTriKH != "" && GiaTriKH != "0")
                        {
                            rs = 0;
                            string sql = "exec spPhanBo_CCDC_Save null,'" + MaCCDC + "','" + Thang + "','" + Nam + "','" + GiaTriKH + "',N'" + DienGiai + "'";
                            rs = DataAcess.Connect.Exec(sql);
                        }
                    }
                    else
                    {
                        rs = 2;//MaCCDC + thang +  nam chua co trong ban khau hao tai san
                    }
                }
            Response.Write(rs);

        }
        catch(Exception e)
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

            SqlConnection con = DataAcess.Connect.GetConnection();
            if (!con.State.ToString().Equals("Open"))
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spTapHopKhauHao_CCDC";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int));
            cmd.Parameters["@thang"].Value = Thang;
            cmd.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int));
            cmd.Parameters["@nam"].Value = Nam;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    rs += "&" + dr["tk_chi_phi"] + "|" + dr["tk_phan_bo"] + "|" + dr["giatrikh"];
                }
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
        SqlConnection con = new SqlConnection();
        con = DataAcess.Connect.GetConnection();
        if (!con.State.ToString().Equals("Open"))
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@MaCCDC", SqlDbType.VarChar));
        cmd.Parameters["@MaCCDC"].Value = Ma_CCDC;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            Response.Write(1);
        }
        else
            Response.Write(0);
    }
    public void LoadThongTinCongCuDungCu()
    {

        string So_Phieu_CCDC = Request.QueryString["SoPhieuCCDC"];
        string Ma_CCDC = Request.QueryString["MaCCDC"];
        string Ten_CCDC = Request.QueryString["TenCCDC"];
        string Hang_SX = Request.QueryString["HangSX"];
        
        string Ngay_Nhap = Request.QueryString["NgayNhap"];
        string Ngay_Khau_Hao = Request.QueryString["NgayKH"];
        string sql = "select So_Phieu_CCDC,Ma_CCDC,Ten_CCDC,Hang_SX,Nam_SX,Nguyen_Gia,convert(varchar,Ngay_Nhap,103)Ngay_Nhap,convert(varchar,Ngay_Khau_Hao,103)Ngay_Khau_Hao,So_Thang_Khau_Hao,TK_CCDC,TK_Doi_Ung,TK_Thue,TK_Chi_Phi,TK_Phan_Bo,Thue_Suat,Tien_Thue,Dien_Giai" +
                     "  From DanhMucCCDC" +
                     "  Where 1=1 ";
        SqlConnection con = new SqlConnection();
        con = DataAcess.Connect.GetConnection();
        if (!con.State.ToString().Equals("Open"))
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        if (So_Phieu_CCDC != "")
        {
            sql += "    and So_Phieu_CCDC= @SoPhieuCCDC";
            cmd.Parameters.Add(new SqlParameter("@SoPhieuCCDC", SqlDbType.VarChar));
            cmd.Parameters["@SoPhieuCCDC"].Value = So_Phieu_CCDC;
        }
        if (Ma_CCDC != "")
        {
            sql += "    and Ma_CCDC= @MaCCDC";
            cmd.Parameters.Add(new SqlParameter("@MaCCDC", SqlDbType.VarChar));
            cmd.Parameters["@MaCCDC"].Value = Ma_CCDC;
        }
        if (Ten_CCDC != "")
        {
            sql += "    and Ten_CCDC like '%@TenCCDC%'";
            cmd.Parameters.Add(new SqlParameter("@TenCCDC", SqlDbType.NVarChar));
            cmd.Parameters["@TenCCDC"].Value = Ten_CCDC;
        }

        if (Hang_SX != "")
        {
            sql += "    and Hang_SX=@HangSX";
            cmd.Parameters.Add(new SqlParameter("@HangSX", SqlDbType.NVarChar));
            cmd.Parameters["@HangSX"].Value = Hang_SX;
        }

        
        if (Ngay_Nhap != "")
        {
            sql += "    and Ngay_Nhap=@NgayNhap";
            cmd.Parameters.Add(new SqlParameter("@NgayNhap", SqlDbType.NVarChar));
            cmd.Parameters["@NgayNhap"].Value = mdlCommonFunction.ChangeDateTo_MM_dd(Ngay_Nhap);
        }

        if (Ngay_Khau_Hao != "")
        {
            sql += "    and Ngay_Khau_Hao=@NgayKH";
            cmd.Parameters.Add(new SqlParameter("@NgayKH", SqlDbType.NVarChar));
            cmd.Parameters["@NgayKH"].Value = mdlCommonFunction.ChangeDateTo_MM_dd(Ngay_Khau_Hao);
        }
        sql += "    Order by Ngay_Nhap desc";
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        string rs = "";
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                rs += "&" + dr["So_Phieu_CCDC"] + "|" + dr["Ma_CCDC"] + "|" + dr["Ten_CCDC"] + "|" + dr["Hang_SX"] + "|" + dr["Nam_SX"] + "|" + dr["Nguyen_Gia"] + "|" + dr["Ngay_Nhap"] + "|" + dr["Ngay_Khau_Hao"] + "|" + dr["So_Thang_Khau_Hao"] + "|" + dr["TK_CCDC"] + "|" + dr["TK_Doi_Ung"] + "|" + dr["TK_Thue"] +"|"+ dr["TK_Chi_Phi"] + "|" + dr["TK_Phan_Bo"] +"|"+ dr["Thue_Suat"] + "|" + dr["Tien_Thue"] + "|" + dr["Dien_Giai"];
            }
        }
        Response.Write(rs);
    }
    public void XoaCongCuDungCu_SoCai()
    {
        string SoPhieuCCDC = Request.QueryString["SoPhieuCCDC"];
        string sql = "spCCDC_SoCai_Delete '"+SoPhieuCCDC+"'";
        int rs = DataAcess.Connect.Exec(sql);
        if (rs > 0)
        {
            Response.Write(1);
        }
        else
            Response.Write(0);
    }
    public void LuuDanhMucCongCuDungCuAndSoCai()
    {
        try
        {

            string data_list = Request.QueryString["Data"];
            string isSaveSoCai = Request.QueryString["SaveSoCai"];
            string[] data = data_list.Split(';');
            string CCDC_ID = "null";
            string SoPhieuCCDC = "";
            string MaCCDC = "";
            string TenCCDC = "";
            string HangSX = "";
            string NamSX = "";
            string NguyenGia = "";
            string NgayNhap = "";
            string NgayKhauHao = "";
            string SoThangKH = "";
            string TKNguyenGia = "";
            string TKDoiUng = "";
            string TKThue = "";
            string TKChiPhi = "";
            string TKKhauHao = "";
            string ThueSuat = "";
            string TienThue = "";
            string DienGiai = "";
            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);

            if (data.Length > 0 && data[1] != "")
            {
                SoPhieuCCDC = data[1];
                MaCCDC = data[2];
                TenCCDC = data[3];
                HangSX = data[4];
                NamSX = data[5];
                if (NamSX == "")
                    NamSX = "0";
                NguyenGia = data[6];
                if (NguyenGia == "")
                    NguyenGia = "0";
                NgayNhap = mdlCommonFunction.ChangeDateTo_MM_dd(data[7]);
                NgayKhauHao = mdlCommonFunction.ChangeDateTo_MM_dd(data[8]);
                SoThangKH = data[9];
                if (SoThangKH == "")
                    SoThangKH = "0";
                TKNguyenGia = data[10];
                TKDoiUng = data[11];
                TKThue = data[12];
                TKChiPhi = data[13];
                TKKhauHao = data[14];
                ThueSuat = data[15];
                if (ThueSuat == "")
                    ThueSuat = "0";
                TienThue = data[16];
                if (TienThue == "")
                    TienThue = "0";
                DienGiai = data[17];


                string sql = "spDanhMucCCDC_Save 0,'" + SoPhieuCCDC + "','" +
                                                          MaCCDC + "',N'" +
                                                          TenCCDC + "',N'" +
                                                          HangSX + "','" +
                                                          NamSX + "','" +
                                                          NguyenGia + "','" +
                                                          NgayNhap + "','" +
                                                          NgayKhauHao + "','" +
                                                          SoThangKH + "','" +
                                                          TKNguyenGia + "','" +
                                                          TKDoiUng + "','" +
                                                          TKThue + "','" +
                                                          TKChiPhi + "','" +
                                                          TKKhauHao + "','" +
                                                          ThueSuat + "','" +
                                                          TienThue + "',N'" +
                                                          DienGiai + "',N'" +
                                                          UserDau + "',N'" +
                                                          UserCuoi + "'";

                int rs = DataAcess.Connect.Exec(sql);
                if (rs > 0)
                {
                    if (isSaveSoCai == "true")
                    {
                        string sql_SoCai = "spCCDC_SoCai_Save null,'" + SoPhieuCCDC + "','" +
                                                                        NgayNhap + "','" +
                                                                        TKNguyenGia + "','" +
                                                                        TKDoiUng + "','" +
                                                                        TKChiPhi + "','" +
                                                                        TKKhauHao + "','" +
                                                                        TKThue + "','" +
                                                                        TienThue + "','" +
                                                                        NguyenGia + "',N'" +
                                                                        DienGiai + "','" +
                                                                        SoThangKH + "'";
                        rs = DataAcess.Connect.Exec(sql_SoCai);
                        if (rs > 0)
                            Response.Write(1);
                        else
                            Response.Write(0);
                    }
                    else
                        Response.Write(1);
                }
                else
                    Response.Write(0);

            }
            else
                Response.Write(0);


        }
        catch
        {
            Response.Write(0);
        }
    }
   
    public void CheckIsPhieuPhanBoTaiSan()
    {
        int thang = Int32.Parse(Request.QueryString["thang"].ToString());
        int nam = Int32.Parse(Request.QueryString["nam"].ToString());
        string rs = "";
        try
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = DataAcess.Connect.GetConnection();
            if (!con.State.ToString().Equals("Open"))
            {
                con.Open();
            }

            cmd.Connection = con;
            string sql = "select top(1) ma_ct from So_Cai where Ma_CT like 'KHTS%' and Month(Ngay_lap_ct)=@Thang and year(Ngay_Lap_Ct)=@Nam";
            cmd.Parameters.Add(new SqlParameter("@Thang", SqlDbType.Int));
            cmd.Parameters["@Thang"].Value = thang;

            cmd.Parameters.Add(new SqlParameter("@Nam", SqlDbType.Int));
            cmd.Parameters["@Nam"].Value = nam;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    rs = dr[0].ToString();
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
            
            SqlConnection con = DataAcess.Connect.GetConnection();
            if (!con.State.ToString().Equals("Open"))
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "spTapHopKhauHao_TSCD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@thang", SqlDbType.Int));
            cmd.Parameters["@thang"].Value = Thang;
            cmd.Parameters.Add(new SqlParameter("@nam", SqlDbType.Int));
            cmd.Parameters["@nam"].Value = Nam;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    rs += "&" + dr["tkchiphi"] + "|" + dr["tkkhauhao"] + "|" + dr["giatrikh"];
                }
            }
        }
        catch
        {
            rs = "";
        }
        Response.Write(rs);  
      
    }
    public void LoadPhieuGiamTaiSan()
    {
        string rs="";;
      
        string SoPG = Request.QueryString["SoPG"];
        string TuNgay = mdlCommonFunction.ChangeDateTo_MM_dd(Request.QueryString["TuNgay"].ToString());
        string DenNgay = mdlCommonFunction.ChangeDateTo_MM_dd(Request.QueryString["DenNgay"].ToString());
        string MaTS = Request.QueryString["MaTS"];

        SqlConnection con = DataAcess.Connect.GetConnection();
        if (!con.State.ToString().Equals("Open"))
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
      
        string sql = "select So_Phieu_Giam,Ma_TS,dmts.TenTaiSan,convert(varchar,Ngay_Giam,103)Ngay_Giam,NguyenGia,TKChiPhi,TKKhauHao,Dien_Giai " +
                     "  from Giam_TSCD g left join DanhMucTaiSan dmts on dmts.MaTS = g.Ma_TS " +
                     "  where 1=1 ";
        if (SoPG != "")
        {
           sql+= " and So_Phieu_Giam = @SoPG";
           cmd.Parameters.Add(new SqlParameter("@SoPG", SqlDbType.NVarChar));
           cmd.Parameters["@SoPG"].Value = SoPG;

        }
        if (TuNgay != "" && DenNgay != "")
        {
            sql += "   and Ngay_Giam between @TuNgay and @DenNgay";
            cmd.Parameters.Add(new SqlParameter("@TuNgay", SqlDbType.VarChar));
            cmd.Parameters["@TuNgay"].Value =  TuNgay;
            cmd.Parameters.Add(new SqlParameter("@DenNgay", SqlDbType.NVarChar));
            cmd.Parameters["@DenNgay"].Value = DenNgay;

        }
        else
        {
            if (TuNgay != "")
            {
                sql += "   and Ngay_Giam = @TuNgay";
                cmd.Parameters.Add(new SqlParameter("@TuNgay", SqlDbType.VarChar));
                cmd.Parameters["@TuNgay"].Value = TuNgay;
            }
            else
                if (DenNgay != "")
            {
                sql += "   and Ngay_Giam = @DenNgay";
                cmd.Parameters.Add(new SqlParameter("@DenNgay", SqlDbType.NVarChar));
                cmd.Parameters["@DenNgay"].Value = DenNgay;
            }
        }
        if (MaTS != "")
        {
            sql += " and g.Ma_TS = @MaTS";
            cmd.Parameters.Add(new SqlParameter("@MaTS", SqlDbType.VarChar));
            cmd.Parameters["@MaTS"].Value = MaTS;
        }
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();

        if(dr.HasRows)
        {
            while(dr.Read())
            {
                rs+="&"+dr["So_Phieu_Giam"]+"|" +dr["Ma_TS"]+"|" +dr["TenTaiSan"]+"|" +dr["Ngay_Giam"]+"|" +dr["NguyenGia"]+"|" +dr["TKChiPhi"]+"|" +dr["TKKhauHao"]+"|" +dr["Dien_Giai"];
            }

        }
        Response.Write(rs);
    }
    public void LoadChiTietPhieuGiamTaiSan()
    {
        string rs="";;
         string SoPG = Request.QueryString["SoPG"];
         string sql ="select so_phieu_giam,TK_Co,TK_No,Tien,Dien_Giai "+
                     "  From Giam_TSCD_CT "+
                     "  Where so_phieu_giam = @SoPG";
        SqlConnection con =  DataAcess.Connect.GetConnection();
        if(!con.State.ToString().Equals("Open"))
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.Add(new SqlParameter("@SoPG",SqlDbType.NVarChar));
        cmd.Parameters["@SoPG"].Value = SoPG;
        SqlDataReader dr = cmd.ExecuteReader();

        if(dr.HasRows)
        {
            while(dr.Read())
            {
                rs += "&" + dr["so_phieu_giam"] + "|" + dr["TK_Co"] + "|" + dr["TK_No"] + "|" + dr["Tien"] + "|" + dr["Dien_Giai"];
            }

        }
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
        if(rs)
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
        if(rs)
            Response.Write(1);
        else
            Response.Write(0);
            
    }

    public void LoadDanhMucTaiSan()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        html += "|<div style=\"width: 500px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã tài sản</div>";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên tài sản</div>";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Nguyên giá</div>";
        
        html += "</div>|||||";

        html += Environment.NewLine;
        try
        {
            sql = "select MaTS,TenTaiSan,NguyenGia,TKChiPhi,TKKhauHao from DanhMucTaiSan ";
            if (type == "txtMaTS" && !string.IsNullOrEmpty(Key))
                sql += " where MaTS  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenTS" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenTaiSan  LIKE '%" + Key + "%'";
                }
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonTaiSan('" + h["MaTS"] + "','" + h["TenTaiSan"] + "','" + h["NguyenGia"] + "','" + h["TKChiPhi"] + "','" + h["TKKhauHao"] + "')\">";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["MaTS"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TenTaiSan"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["NguyenGia"] + "</p>";
               
                html += "</div>|" + h["MaTS"] + "|" + h["TenTaiSan"] + "|" + h["NguyenGia"] + "|" + h["TKChiPhi"] + "|" + h["TKKhauHao"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    public void XoaKhauHaoTaiSanByThangNam()
    {
        try
        {
            int Thang = Int32.Parse(Request.QueryString["Thang"].ToString());
            int Nam = Int32.Parse(Request.QueryString["Nam"].ToString());
            int rs = 0;
            rs = IsExitsTaiSanKhauHao("",Thang,Nam);
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

    public int IsExitsTaiSanKhauHao(string MaTS,int Thang,int Nam)
    {
        int rs = 0;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = DataAcess.Connect.GetConnectionString();
        if (!con.State.ToString().Equals("Open"))
        {
            con.Open();
        }
        string sqlCheck = "select * from KhauHaoTaiSan where 1=1  ";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = sqlCheck;
        cmd.CommandType = CommandType.Text;
        
        if (MaTS != "")
        {
            sqlCheck += "  and MaTS = @MaTS ";
            cmd.Parameters.Add(new SqlParameter("@MaTS", SqlDbType.NVarChar));
            cmd.Parameters["@MaTS"].Value = MaTS;
        }
        if(Thang!=0)
        {
            sqlCheck += "   and thang = @Thang";
            cmd.Parameters.Add(new SqlParameter("@Thang", SqlDbType.Int));
            cmd.Parameters["@Thang"].Value = Thang;
        }
        if (Nam != 0)
        {
            sqlCheck += "   and nam = @Nam";
            cmd.Parameters.Add(new SqlParameter("@Nam", SqlDbType.Int));
            cmd.Parameters["@Nam"].Value = Nam;
        }
       
        
        SqlDataReader dr =  cmd.ExecuteReader();

        if (dr.HasRows)
        {
            rs =1;
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
            if(month!="")
                Thang = Int32.Parse(month);
            if(year!="")
                Nam = Int32.Parse(year);
            string DienGiai = Request.QueryString["DienGiai"].ToString();
            
            
            if(TypeSave=="Save")
            {
            
                string MaTS_list = Request.QueryString["MaTS"];
                string[] MaTS = MaTS_list.Split(';');

                string GiaTriKH_list = Request.QueryString["GiaTriKhauHao"];
                string[] GiaTriKH = GiaTriKH_list.Split(';');
               
                if (MaTS.Length > 0)
                {
                    for (int i = 0; i < GiaTriKH.Length; i++)
                    {
                        if (GiaTriKH[i] != "" && GiaTriKH[i] != "0")
                        {
                            string sql = "exec spTSCD_Save '" + MaTS[i] + "','" + Thang + "','" + Nam + "','" + GiaTriKH[i] + "',N'" + DienGiai + "'";
                            rs = DataAcess.Connect.Exec(sql);
                        }
                    }
                }
            }
            else
                if(TypeSave=="Update")
                {
                    string MaTS = Request.QueryString["MaTS"];
                    string GiaTriKH = Request.QueryString["GiaTriKhauHao"];
                    rs = IsExitsTaiSanKhauHao(MaTS,Thang,Nam);
                    if(rs==1)
                    {
                        if (GiaTriKH != "" && GiaTriKH != "0")
                        {
                            string sql = "exec spTSCD_Save '" + MaTS + "','" + Thang + "','" + Nam + "','" + GiaTriKH + "',N'" + DienGiai + "'";
                            rs = DataAcess.Connect.Exec(sql);
                        }
                    }
                    else
                    {
                        rs = 2;//MaTS + thang +  nam chua co trong ban khau hao tai san
                    }
                }
            Response.Write(rs);
           
        }
        catch(Exception e)
        {
            Response.Write(rs);
        }
    }
    public void LoadDanhSachTaiSan()
    {
        int thang = Int32.Parse(Request.QueryString["Thang"].ToString());
        int nam   = Int32.Parse(Request.QueryString["Nam"].ToString());
        string date = nam.ToString() + "/" + thang.ToString() + "/01";
        string sql = "exec spTSCD_Load  '" + date + "'";
        string rs = "";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //MaTS,TenTaiSan ,NguyenGia,SoNamKH ,TKKhauHao,TKChiPhi,GiaTriKH = '',DienGiai = ''
                rs += "&" + table.Rows[i][0] + "|" + table.Rows[i][1] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + "|" + table.Rows[i][4] + "|" + table.Rows[i][5] + "|" + table.Rows[i][6] + "|" + table.Rows[i][7] + "|" + table.Rows[i][8];
            }
        }
       //DateTime  b =Convert.ToDateTime("10/15/2011");
       //double a = tinhkhauhaothang(b, 5, 1000000, 3, 2012);
        Response.Write(rs);
    }
    public double tinhkhauhaothang(DateTime ngaykhauhao,int sothangkhauhao,double nguyengia,int thangkh,int namkh )
    {
        //lay so ngay khau hao
        //lay thang khau hao
        int i = ngaykhauhao.Month;
        int year=ngaykhauhao.Year;
        int songaykh = 0;
        int thang=0;
        int nam =0;
        int thang_kq=0;
        int nam_kq=0;
        for ( int j = i + 1; j <= i + sothangkhauhao-1; j++)
        {
            if (j <= 12)
            {
                thang = j;
                nam = year;
            }
            else
            {
                //j >12
                if (j % 12 == 0)
                {                    
                    thang = 12; 
                }
                else
                {
                    int a = j / 12;                   
                    thang = j - (12 * a);                    
                }
                if (thang == 1)
                    nam = year + 1;
            }            
            songaykh += DateTime.DaysInMonth(nam, thang);
            if (thang == thangkh && nam == namkh)
            {
                thang_kq=thang;
                nam_kq=nam;
            }
        }
        songaykh = DateTime.DaysInMonth(ngaykhauhao.Year,ngaykhauhao.Month)-(ngaykhauhao.Day-1) + songaykh + (ngaykhauhao.Day - 1);
        //gia tri khau khao moi ngay
        double khauhaocuangay = 0;
        khauhaocuangay = Math.Round(nguyengia / songaykh, 3);
        //tinh gia tri khau hao thang
        double giatri_kh_thang = 0;
        int songaytrongthang_kh = 0;
        if (ngaykhauhao.Month == thangkh && ngaykhauhao.Year == namkh)
        {
            songaytrongthang_kh = DateTime.DaysInMonth(ngaykhauhao.Year, ngaykhauhao.Month) - (ngaykhauhao.Day - 1);
            giatri_kh_thang = Math.Round(songaytrongthang_kh * khauhaocuangay, 0);
        }
        else
            if (thangkh == thang_kq && namkh == nam_kq)
            {
                songaytrongthang_kh = DateTime.DaysInMonth(nam_kq, thang_kq);
                giatri_kh_thang = Math.Round(songaytrongthang_kh * khauhaocuangay,0);
            }
            else
            {
                songaytrongthang_kh = ngaykhauhao.Day - 1;
                giatri_kh_thang = Math.Round(songaytrongthang_kh * khauhaocuangay,0);
            }
        return giatri_kh_thang;
    }

    public void TinhKhauHao()
    {
        string kq = "";
        DateTime ngaykhauhao =Convert.ToDateTime(Request.QueryString["ngaykhauhao"]);
        int sothangkhauhao = Convert.ToInt16(Request.QueryString["sothangkhauhao"].ToString());
        double nguyengia=Convert.ToDouble(Request.QueryString["nguyengia"].ToString ());
        int thang=Convert.ToInt16(Request.QueryString["thang"].ToString ());
        int nam=Convert.ToInt16(Request.QueryString["nam"].ToString ());
        kq = tinhkhauhaothang(ngaykhauhao, sothangkhauhao, nguyengia, thang, nam).ToString() ;
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
            strWhere += "   and nam ='"+nam +"'";
        if(tk!="")
            strWhere += "   and tk = '"+ tk+"'";
        if(ma_kh!="")
            strWhere += "   and ma_kh = '" + ma_kh + "'";
        string sql = "";
        
            sql = "select  nam,tk,tk.tentaikhoan,ma_kh,bn.tenbenhnhan, kh.tenkhachhang,ncc.TenNhaCungCap,du_no0,du_co0 "+
                  "     from CongNo_DauKi left join benhnhan bn on bn.mabenhnhan = ma_kh  "+
                  "     left join KhachHang kh on kh.makhachhang = ma_kh"+
                  "     left join NhaCungCap ncc on convert(varchar,ncc.nhacungcapid)= ma_kh "+
                  "     left join DanhMucTK tk on tk.taikhoan = tk " +
                  "  where 1=1    ";
            if (strWhere != "")
                sql += strWhere;
      
        
        string rs = "";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if(table!=null&&table.Rows.Count>0)
        {
            //nam,tk,tk.tentaikhoan,ma_kh,bn.tenbenhnhan as tenkhachhang,du_no0,du_co0
            for (int i = 0; i < table.Rows.Count; i++)
            {
                rs += "&" + table.Rows[i][0] + "|" + table.Rows[i][1] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + "|" + table.Rows[i][4] + "|" + table.Rows[i][5] + "|" +  table.Rows[i][6] + "|" + table.Rows[i][7] + "|" + table.Rows[i][8];
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
	
        string sql = "spCong_No_DK_Save null,'" +nam+"','"+tk+"','"+ma_kh+"','"+du_no0+"','"+du_co0 +"',N'"+user_dau+"',N'"+user_cuoi+"'";
        int rs = DataAcess.Connect.Exec(sql);
        if(rs>0)
            Response.Write(1);
        else
            Response.Write(0);
    }

    public void LuuSoDuDauKyTaiKhoan()
    {
        bool rs = false;
                
        string nam =  Request.QueryString["nam"];
        string tai_khoan_list =  Request.QueryString["tai_khoan"];
        string du_no0_list =  Request.QueryString["du_no0"];
        string du_co0_list = Request.QueryString["du_co0"];
        string du_no_nt0_list =  Request.QueryString["du_no_nt0"];
        string du_co_nt0_list =  Request.QueryString["du_co_nt0"];

        string[] tai_khoan = tai_khoan_list.Split(';');
        string[] du_no0 = du_no0_list.Split(';');
        string[] du_co0= du_co0_list.Split(';');
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
        string gt=Request .QueryString ["gia_tri"];
        string[] tham_so = ts.Split(';');
        string[] gia_tri = gt.Split(';');

        if (tham_so.Length > 0)
        {
            for (int i = 0; i < tham_so.Length; i++)
            {
                if (!string.IsNullOrEmpty(tham_so[i]))
                {
                    string sql = "exec spTham_So_Save '"+tham_so[i]+"',N'"+gia_tri[i]+"'";                    
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
            string sql = "exec spUy_Nhiem_Chi_Save '" + UyNhiemChiID + "','" + So_UNC + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLap) + "','" + MaNCC + "',N'" + NguoiNhan + "',N'" + DienGiai + "','" + TKCo + "',null,null," + TongTien + ",null,N'" + UserDau + "',N'" + UserCuoi + "','"+TKNganHangNCC+"',N'"+TenNganHangCC+"',0";
            int rs = DataAcess.Connect.Exec(sql);
            if (rs > 0)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch(Exception e)
        {
            Response.Write(0);
        }
    }
    public void Luu_ChiTietUyNhiemChi()
    {
        try
        {
            string SoUNC = Request.QueryString["SoUNC"];
            string TKNo_list = Request.QueryString["TKNo"];
            string[] TKNo = TKNo_list.Split(';');

            string PhatSinhNo_list = Request.QueryString["PhatSinhNo"];
            string[] PhatSinhNo = PhatSinhNo_list.Split(';');

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
            for (int i = 1;i<TKNo.Length; i++)
            {
                if (TKNo[i] != "")
                {
                    string sql = "exec spUy_Nhiem_Chi_Ct_Save null,'" + SoUNC + "','" + TKNo[i] + "','" + PhatSinhNo[i] + "',null,'" + ThueSuat[i] + "','" + TKThue[i] + "','" + TienThue[i] + "',null,'" + SoHD[i] + "','" + SoSeri[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "',N'" + DienGiai[i] + "',0";
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
    public void LuuSoCaiUyNhiemChi()
    {
        try
        {
          
            string SoUNC = Request.QueryString["SoUNC"];
            string NgayLap = Request.QueryString["NgayLap"];
            string MaNCC = Request.QueryString["MaNCC"];
            string TKCo = Request.QueryString["TKCo"];
           
            string TKNo_list = Request.QueryString["TKNo"];
            string[] TKNo = TKNo_list.Split(';');

            string PhatSinhNo_list = Request.QueryString["PhatSinhNo"];
            string[] PhatSinhNo = PhatSinhNo_list.Split(';');

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
            for (int i = 1;i< TKNo.Length; i++)
            {
                if (TKNo[i] != "")
                {
                    string sql = "exec spUy_Nhiem_Chi_So_Cai_Save null,'" + SoUNC + "','" +
                                                             mdlCommonFunction.ChangeDateTo_MM_dd(NgayLap) + "','" +
                                                             MaNCC + "',N'" +
                                                             DienGiai[i] + "','" +
                                                             TKNo[i] + "','" +
                                                             TKCo + "','" +
                                                             TKThue[i] + "','" +
                                                             PhatSinhNo[i]+ "','" +
                                                             TienThue[i] + "','" +
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
        string sql = "select unc_id,so_unc,convert(varchar,ngay_lap_unc,103)ngay_lap,ma_ncc,ncc.TenNhaCungCap,Dien_Giai,TK_Co,SoTaiKhoanNCC,TenNganHangNCC,	Tien "+
                     "  from Uy_Nhiem_Chi left join NhaCungCap ncc on ncc.MaNhaCungCap = ma_ncc "+
                     "  where 1=1 ";
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
                    sql += "    and ngay_lap_unc = '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
                }
        if (!string.IsNullOrEmpty(SoUyNhiemChi))
            sql += "    and so_unc = '" + SoUyNhiemChi + "'";
        if (!string.IsNullOrEmpty(MaNCC))
            sql += "    and ma_ncc='" + MaNCC + "'";
        sql += "    order by ngay_lap_unc desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//unc_id(0),so_unc(1),ngay_lap(2),ma_ncc(3),ncc.TenNhaCungCap(4),Dien_Giai(5),TK_Co(6),SoTaiKhoanNCC(7),TenNganHangNCC(8),	Tien(9) )
                 DataRow row = table.Rows[i];
                rs += "|" + row["unc_id"] + "&" + row["so_unc"] + "&" + row["ngay_lap"] + "&" + row["ma_ncc"] + "&" + row["TenNhaCungCap"] + "&" + row["Dien_Giai"] + "&" + row["TK_Co"] + "&" + row["SoTaiKhoanNCC"] + "&" + row["TenNganHangNCC"] + "&" + row["Tien"];
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
        string sql = "select tk_no,ps_no,tk_thue,tien_thue,so_hd,so_seri,convert(varchar,ngay_lap_hd,103)ngay_lap_hd,dien_giai,Thue_Suat "+
                     "  from uy_nhiem_chi_ct" +
                     "  where so_unc = '" + SoUNC + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|"  + row["tk_no"] + "&" + row["ps_no"] + "&" + row["tk_thue"] + "&" + row["tien_thue"] + "&" + row["so_hd"] + "&" + row["so_seri"] + "&" + row["ngay_lap_hd"] + "&" + row["dien_giai"] + "&" + row["Thue_Suat"];
            }
            Response.Write(rs);
        }
    }
    public void XoaUyNhiemChi()
    {
        try
        {
            string SoUNC = Request.QueryString["SoUNC"];
            string sql = "exec spUy_Nhiem_Chi_Delete  '" + SoUNC + "'";
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
                    stt = "0" + so_thu_tu.ToString();
                }
                else
                {
                    stt = so_thu_tu.ToString();
                }
        return stt;
    }
    public void TaoMaSoTuDong()
   {
        string MaTuDong = "";
        
        string TenTable = Request.QueryString["Table"];
        string KyTuDau = Request.QueryString["KyTuDau"];
        string FielMa = Request.QueryString["Column"];
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
         sql += "   where "+FielMa+" like '"+KyTuDau+"%' ";
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
                         string month ="";
                         if (thang < 10)
                             month = "0" + thang.ToString();
                         else
                             month = thang.ToString();
                         MaTuDong = ky_tu_dau + "-" + stt + "/" + month + nam.ToString();
                     }
                     else
                     {
                         thang++;
                         string month = "";
                         if (thang < 10)
                             month = "0" + thang.ToString();
                         else
                             month = thang.ToString();
                         MaTuDong = ky_tu_dau + "-" + "0001" + "/" + month + nam.ToString();
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
                         MaTuDong = ky_tu_dau + "-" + "0001" + "/" + month + nam.ToString();
                     }
                     else
                     {
                         thang++;
                         string month = "";
                         if (thang < 10)
                             month = "0" + thang.ToString();
                         else
                             month = thang.ToString();
                         MaTuDong = ky_tu_dau + "-" + "0001" + "/" + month + nam.ToString();
                     }
                 }
             }
             else //Mã số đầu tiên
             {
                 string month="";
                 if(DateTime.Now.Month<10)
                     month = "0" + DateTime.Now.Month.ToString();
                 else
                     month = DateTime.Now.Month.ToString();

                 MaTuDong = KyTuDau + "-" + "0001" + "/" + month + DateTime.Now.Year.ToString();
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
        string KyTuDau = Request.QueryString["KyTuDau"];
        string FielMa = Request.QueryString["Column"];
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where " + FielMa + " like '" + KyTuDau + "%' and  " + FielMa + " like '%"+Thang + Nam+"' ";
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

                MaTuDong = KyTuDau + "-" + "0001" + "/" + month + Nam.ToString();
            }
        }
        Response.Write(MaTuDong);
    }
    public void LoadPhieuChiByIDPhieuChi()
    {
        string idPhieuChi = Request["idPhieuChi"];
        string sql = "select phieu_chi_id,so_phieu_chi,convert(varchar,ngay_chi,103)ngay_chi,ma_ncc,ncc.TenNhaCungCap,nguoi_giao,Dien_Giai,tk_co,Tien " +
                     "  from Phieu_Chi pc left join NhaCungCap ncc on pc.ma_ncc = ncc.manhacungcap " +
                     "  where 1=1 ";
        if (!string.IsNullOrEmpty(idPhieuChi))
            sql += "    and phieu_chi_id= '"+ idPhieuChi + "'";
       
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
    public void DanhSachPhieuChi()
    {
        string TuNgay = Request["TuNgay"];
        string DenNgay = Request["DenNgay"];
        string SoPhieuChi = Request["SoPhieuChi"];
        string MaNCC = Request["MaNCC"];
        string sql = "select phieu_chi_id,so_phieu_chi,convert(varchar,ngay_chi,103)ngay_chi,ma_ncc,ncc.TenNhaCungCap,nguoi_giao,Dien_Giai,tk_co,Tien "+
                     "  from Phieu_Chi pc left join NhaCungCap ncc on pc.ma_ncc = ncc.manhacungcap "+
                     "  where 1=1 ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_chi between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(SoPhieuChi))
            sql += "    and so_phieu_chi = '" + SoPhieuChi + "'";
        if (!string.IsNullOrEmpty(MaNCC))
            sql += "    and ma_ncc='" + MaNCC + "'";
        sql += "    order by ngay_chi desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_chi_id(0),so_phieu_chi(1),ngay_chi(2),ma_ncc(3),tennnc(4),dien_giai(5),tk_co(6),tien(7)
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_id"] + "&" + row["so_phieu_chi"] + "&" + row["ngay_chi"] + "&" + row["ma_ncc"] + "&" + row["TenNhaCungCap"] + "&" + row["Dien_Giai"] + "&" + row["tk_co"] + "&" + row["Tien"];
            }
            Response.Write(rs);
        }
    }
    public void ChiTietPhieuChiKhacBySoPhieuChi()
    {
        string SoPhieuChi = Request.QueryString["SoPhieuChi"];
        string sql = "select phieu_chi_ct_id,tk_no,ps_no,tk_thue,tien_thue,so_hd,so_seri,convert(varchar,ngay_lap_hd,103)ngay_lap_hd,dien_giai,Thue_Suat "+
                     "  from Phieu_Chi_CT"+
                     "  where So_phieu_chi = '"+SoPhieuChi+"'";
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
            double TongTien ;
            if (string.IsNullOrEmpty(Tien))
                TongTien = 0;
            else
                TongTien = double.Parse(Tien);
            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            string Status = Request.QueryString["Status"];
            //SoPhieuChi,ngay_chi,ma_ncc,nguoi_giao,dien_giai,tk_co,loai_nt,ty_gia,tien,tien_nt,user_dau,date_dau,user_cuoi,date_cuoi,status
            string sql = "exec spPhieu_Chi_Save '" + PhieuChiID + "','" + SoPhieuChi + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayChi) + "','" + MaNCC + "',N'" + NguoiGiao + "',N'" + DienGiai + "','" + TKCo + "',null,null," + TongTien + ",null,N'" + UserDau + "',N'" + UserCuoi + "',0";
            int rs = DataAcess.Connect.Exec(sql);
            if (rs>0)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch(Exception e)
        {
            Response.Write(0);
        }
    }
    public void LuuChiTietPhieuChi()
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
                    string sql = "exec spPhieu_Chi_Ct_Save null,'" + SoPhieuChi + "','" + TKNo[i] + "','" + PhatSinhNo[i] + "',null,'" + ThueSuat[i] + "','" + TKThue[i] + "','" + TienThue[i] + "',null,'" + SoHD[i] + "','" + SoSeri[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "','" + TienTrenHD + "',null,null,null,N'" + DienGiai[i] + "',0";
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
            //TKNo,TKThue,PhatSinhNo,DienGiai,TienThue,SoHD,SoSeri,NgayLapHD
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
            string[]NgayLapHD = NgayLapHD_list.Split(';');

            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            bool rs = false;
            for (int i = 1; i < TKNo.Length; i++)
            {
                if (TKNo[i] != "")
                {
                    string sql = "exec spPhieu_Chi_khac_So_Cai_Save null,'" + SoPhieuChi + "','" +
                                                                 mdlCommonFunction.ChangeDateTo_MM_dd(NgayChi) + "','" +
                                                                 MaNCC + "',N'" +
                                                                 DienGiai[i] + "','" +
                                                                 TKNo[i] + "','" +
                                                                 TKCo + "','" +
                                                                 TKThue[i] + "','" +
                                                                 PhatSinhNo[i] + "','" +
                                                                 TienThue[i] + "','" +
                                                                 SoHD[i] + "','" +
                                                                 SoSeri[i] + "','" +
                                                                 mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "',N'" +
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
        catch(Exception e)
        {
            Response.Write(0);
        }
    }
    public void XoaPhieuChi()
    {
        try
        {
            string SoPhieuChi = Request.QueryString["SoPhieuChi"];
            string sql = "exec spPhieu_Chi_Delete  '" + SoPhieuChi + "'";
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
        string SoPT = Request["SoPT"];
        string sql = "select phieu_thu_ct_id,tk_co,so_hd,convert(varchar,ngay_lap_hd,103)ngay_lap_hd,tongtien = tien_tren_hd "+
                     "  from phieu_thu_ct where so_phieu_thu = '" + SoPT + "'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_thu_ct_id"] + "&" + row["tk_co"] + "&" + row["so_hd"] + "&" + row["ngay_lap_hd"] + "&" + row["tongtien"];
            }
            Response.Write(rs);
        }
    }
    public void ChiTietPhieuThuKhac()
    {
        string SoPT = Request["SoPT"];
        string sql = "select phieu_thu_ct_id,tk_co,dien_giai,tongtien = ps_co,tk.TenTaiKhoan " +
                     "   from phieu_thu_ct left join DanhMucTK tk on tk.TaiKhoan = tk_co	"+
                     "   where so_phieu_thu = '" + SoPT + "'";
                     
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
        string sql = "select  phieu_thu_id,so_phieu_thu,convert(varchar,ngay_thu,103)ngay_thu,pt.ma_kh,kh.tenkhachhang,nguoi_nop,dien_giai,tk_no,tien"+
                     "  from Phieu_Thu pt left join khachhang kh on  pt.ma_kh = kh.MaKhachHang "+
                     "  where phieu_thu_id = '" + idPhieuThu + "' ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_thu_id"] + "&" + row["so_phieu_thu"] + "&" + row["ngay_thu"] + "&" + row["ma_kh"] + "&" + row["tenkhachhang"] + "&" + row["nguoi_nop"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tien"];
            }
            Response.Write(rs);
        }
    }
    public void DanhSachPhieuThuOfBenhNhan()
    {
        string idPhieuThu = Request["idPhieuThu"];
        string sql = "select  phieu_thu_id,so_phieu_thu,convert(varchar,ngay_thu,103)ngay_thu,pt.ma_kh,bn.TenBenhNhan,nguoi_nop,dien_giai,tk_no,tien"+
                     "  from Phieu_Thu pt left join BenhNhan bn on  pt.ma_kh = bn.MaBenhNhan"+
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
        string sql = "select phieu_thu_id,so_phieu_thu,convert(varchar,ngay_thu,103)ngay_thu,ma_kh,dien_giai,tk_no,tien from phieu_thu where 1=1 ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and Ngay_Thu between '"+mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay)+"' and '"+ mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay)+"'  ";
        if (!string.IsNullOrEmpty(SoPhieuThu))
            sql += "    and So_phieu_thu = '" + SoPhieuThu + "'";
        if (!string.IsNullOrEmpty(MaKH))
            sql += "    and Ma_KH='" + MaKH + "'";
        sql += "    order by ngay_thu desc";
        DataTable table =  DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_thu_id"] + "&" + row["so_phieu_thu"] + "&" + row["ngay_thu"] + "&" + row["ma_kh"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tien"];
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
        string sql = "select hoa_donid,so_hd,convert(varchar,ngay_lap_hd,103)ngay_lap_hd, ma_kh,dien_giai,tk_no,tk_co,tk_thue,thue_suat,tien,tien_thue,tong_tien from Hoa_Don_DV where 1=1 ";
        if (!string.IsNullOrEmpty(TuNgay) && !string.IsNullOrEmpty(DenNgay))
            sql += "    and ngay_lap_hd between '" + mdlCommonFunction.ChangeDateTo_MM_dd(TuNgay) + "' and '" + mdlCommonFunction.ChangeDateTo_MM_dd(DenNgay) + "'  ";
        if (!string.IsNullOrEmpty(SoHD))
            sql += "    and So_HD = '" + SoHD + "'";
        if (!string.IsNullOrEmpty(MaKH))
            sql += "    and Ma_KH='" + MaKH + "'";
        sql += "    order by ngay_lap_hd desc";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["hoa_donid"] + "&" + row["so_hd"] + "&" + row["ngay_lap_hd"] + "&" + row["ma_kh"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tk_co"] + "&" + row["tk_thue"] + "&" + row["thue_suat"] + "&" + row["tien"] + "&" + row["tien_thue"] + "&" + row["tong_tien"];
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

    public void LuuSoCai_PhieuThuHoaDon()
    {
        try
        {
            //TKCo,TienTrenHD,SoHD,NgayLapHD)
            string SoPT = Request.QueryString["SoPT"];
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
    
            string SoPT = Request.QueryString["SoPT"];
            string NgayThu = Request.QueryString["NgayThu"];
            string MaKH = Request.QueryString["MaKH"];
            string DienGiai_list = Request.QueryString["DienGiai"];
            string TKNo = Request.QueryString["TKNo"];
            string TKCo_list = Request.QueryString["TKCo"];
            string PSCo_list = Request.QueryString["PSCo"];
            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);

            string[] TKCo = TKCo_list.Split(';');
            string[] PSCo = PSCo_list.Split(';');
            string[] DienGiai = DienGiai_list.Split(';');
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
           
            string SoPT = Request.QueryString["SoPT"];
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
        catch (Exception e)
        {
            Response.Write(0);
        }
    }
    public void LuuChiTietPhieuThuHoaDon()
    {
        try
        {
            
            string SoPT = Request.QueryString["SoPT"];

            string IDPhieuThuCT_list = Request.QueryString["IDPhieuThuCT"];
            string[] IDPhieuThuCT = IDPhieuThuCT_list.Split(';');

            string TKCo_list = Request.QueryString["TKCo"];
            string[] TKCo = TKCo_list.Split(';');

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');

            string TienTrenHD_list = Request.QueryString["TienTrenHD"];
            string[] TienTrenHD = TienTrenHD_list.Split(';');
            bool rs = false;
            for (int i = 0; i < SoHD.Length; i++)
            {
                if (SoHD[i] != "")
                {
                    string sql1 = "exec spPhieu_Thu_Ct_Save  " + Int64.Parse(IDPhieuThuCT[i]) + ",'" + SoPT + "','" + TKCo[i] + "',null,null,'" + SoHD[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "'," + TienTrenHD[i] + ",null,null,null,null,0";
                    rs = DataAcess.Connect.ExecSQL(sql1);
                    if (rs)
                    {
                        string sql2 = "update Hoa_Don_DV set status = 1 where so_hd = '" + SoHD[i] + "' and ngay_lap_hd = '" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "' ";
                        rs = DataAcess.Connect.ExecSQL(sql2);
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
    public void LuuPhieuThu()
    {
        try
        {
            string PhieuThuID = Request.QueryString["PhieuThuID"];
            if (string.IsNullOrEmpty(PhieuThuID))
                PhieuThuID = "null";
            string SoPT = Request.QueryString["SoPT"];
            string NgayThu = Request.QueryString["NgayThu"];
            string MaKH = Request.QueryString["MaKH"];
            string NguoiNop = Request.QueryString["NguoiNop"];
            string DienGiai = Request.QueryString["DienGiai"];
            string TKNo = Request.QueryString["TKNo"];
            string Tien = Request.QueryString["Tien"];
            string UserDau = SysParameter.UserLogin.UserName(this);
            string UserCuoi = SysParameter.UserLogin.UserName(this);
            string Status = Request.QueryString["Status"];

            string sql = "exec spPhieu_Thu_Save " + PhieuThuID + ", '" + SoPT + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayThu) + "','" + MaKH + "',N'" + NguoiNop + "',N'" + DienGiai + "','" + TKNo + "',null,null," + Tien + ",null,N'" + UserDau + "',N'" + UserCuoi + "',0 ";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }
    }
    public void LoadDanhSachHoaDon()
    {
        string MaKhachHang = Request.QueryString["MaKhachHang"];
        string sql = "select So_HD,convert(varchar,Ngay_Lap_HD,103)Ngay_Lap_HD,TK_Co,Tong_Tien from Hoa_Don_DV where status = 0 and  ma_kh='" + MaKhachHang + "' order by Ngay_Lap_HD desc";
        ArrayList arr = data.SQLMultiHashReader(sql, conn);
        string result = "";
        foreach (Hashtable h in arr)
        {
            result += "|" + h["So_HD"] + "&" + h["Ngay_Lap_HD"] + "&" + h["TK_Co"] + "&" + h["Tong_Tien"];
        }

        Response.Write(result);
    }
    public void LoadDanhSachHoaDonPhieuChi()
    {
        string MaNCC = Request.QueryString["MaNCC"];
        string sql = "select sohoadon,tkno, convert(varchar,ngayhoadon,103)ngayhoadon,thanhtien "+
                     "  from PhieuNhapKho where TrangThai = 0 and  MaNhaCungCap='" + MaNCC + "' order by ngayhoadon desc";
        ArrayList arr = data.SQLMultiHashReader(sql, conn);
        string result = "";
        foreach (Hashtable h in arr)
        {
            result += "|"  + h["sohoadon"] + "&" + h["ngayhoadon"] + "&" + h["tkno"] + "&" + h["thanhtien"];
        }

        Response.Write(result);
    }
    public void XoaPhieuThu()
    {
        try
        {
            string SoPhieuThu = Request.QueryString["SoPhieuThu"];
            string sql = "exec spPhieu_Thu_Delete  '" + SoPhieuThu + "'";
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
            string sql2 = "exec spPhieu_Thu_Ct_Delete '"+SoPT+"'";
            bool rs = DataAcess.Connect.ExecSQL(sql2);
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
        catch (Exception e)
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
            string sql = "update DoanhThu_pmbv set trang_thai = "+TrangThai+" where doanhthu_pmbvid='" + DoanhThuID + "'";
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
        if(rs.Rows.Count>0)
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
        string sql = "exec spHoa_Don_Save  '" + HoaDonId + "','" + SoHD + "','" + SoSeri + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD) + "','" + MaKH + "',N'" + TenKH + "',N'" + NguoiMua + "',N'" + DiaChi + "','" + MaSoThue + "',N'" + DienGiai + "','" + TKNo + "','" + TKCo + "','" + TKThue + "','" + ThueSuat + "','" + Tien + "','" + TienThue + "','" + TongTien + "',N'" + UserDau + "',N'" + UserCuoi + "','" + Status + "'";
        bool rs = DataAcess.Connect.ExecSQL(sql);
        bool rs2;
        if (rs)
        {
            string sql2 = "exec spHoaDon_SoCai_Save  Null,'" + SoHD + "','" +mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD) + "','" + MaKH + "',N'" + DienGiai + "','" + TKNo + "','" + TKCo + "','" + TKThue + "','" + Tien + "','" + TienThue + "',N'" + UserDau + "',N'" + UserCuoi + "'";
            rs2 = DataAcess.Connect.ExecSQL(sql2);
            if (rs2)
                Response.Write(1);
            else
                Response.Write(2);
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
            if(SoHD!= "")
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
    public void LoadDanhSachPhieuThuOfHoaDonDichVu()
    {
        //string key = Request.QueryString["q"];
        string SoHD = Request.QueryString["SoHD"];
        string sql = "";
        string result = "";
        try
        {

            sql = "  select ma_phieu_thu,convert(varchar,ngay_thu,103)ngay_thu,ma_bn as idbenhnhan,bn.mabenhnhan,bn.tenbenhnhan,tien_thu " +
                  " from Hoa_Don_DV_CT left join benhnhan bn on bn.idbenhnhan = ma_bn "+
                  " where so_hoa_don = '" + SoHD + "'";
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {
                //result += "|" + h["ngay_thu"] + "&" + h["idbenhnhan"] + "&" + h["mabenhnhan"] + "&" + h["tenbenhnhan"] + "&" + h["tien_thu"] + "&"  + h["ma_phieu_thu"];
                result += "|" + h["mabenhnhan"] + "&" + h["tenbenhnhan"] + "&" + h["ngay_thu"] + "&" + h["tien_thu"] + "&" + h["idbenhnhan"] + "&" + h["ma_phieu_thu"];

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
        //string key = Request.QueryString["q"];
        string NgayThu = Request.QueryString["NgayThu"];
        string sql = "";
        string result = "";
        try
        {

            sql = "  Select top(1000) doanhthu_pmbvid, bn.idBenhNhan,bn.MaBenhNhan,bn.TenBenhNhan," +
                  "  convert(varchar,dt.Ngay_Thu,103)Ngay_Thu," +
                  "  sum(dt.Thanh_Tien_BN_Tra) as ThanhTien " +
                  "  From DoanhThu_pmbv dt left join BenhNhan bn on bn.idbenhnhan =  dt.id_Benh_Nhan " +
                  "  Where dt.Trang_Thai = '0' ";
                
                 
            if (!string.IsNullOrEmpty(NgayThu))
            {
                sql += "   and convert(varchar,Ngay_Thu,101) = '" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayThu) + "' ";
            }
            sql += "  group by doanhthu_pmbvid, bn.idBenhNhan,bn.MaBenhNhan,bn.TenBenhNhan,Ngay_Thu  ";
            sql += "    order by Ngay_Thu desc";
            
                ArrayList arr = data.SQLMultiHashReader(sql, conn);
                foreach (Hashtable h in arr)
                {
                    result += "|" + h["MaBenhNhan"] + "&" + h["TenBenhNhan"] + "&" + h["Ngay_Thu"] + "&" + h["ThanhTien"] + "&" + h["idBenhNhan"] + "&" + h["doanhthu_pmbvid"];
                    

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
                  "  from DoanhThu_pmbv dt left join BenhNhan bn on bn.idBenhNhan = dt.id_Benh_Nhan "+
                  "  where dt.Trang_Thai = '0' and  dt.id_Benh_Nhan = '"+idBenhNhan+"' ";
                    
            if (!string.IsNullOrEmpty(NgayThu))
            {
                sql += "  and convert(varchar,Ngay_Thu,103)='" + NgayThu + "' ";
            }
            sql += "  group by doanhthu_pmbvid, bn.idBenhNhan,bn.MaBenhNhan,bn.TenBenhNhan,Ngay_Thu  ";
            sql += "    order by Ngay_Thu desc";
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {
                result += "|" + h["MaBenhNhan"] + "&" + h["TenBenhNhan"] + "&" + h["Ngay_Thu"] + "&" + h["ThanhTien"] + "&" + h["idBenhNhan"] + "&" + h["doanhthu_pmbvid"]; ;


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
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoan('" + h["TaiKhoan"] + "','" + idText + "')\">";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TaiKhoan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["TenTaiKhoan"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["ChiTiet"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TKCapCha"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["Cap"] + "</p>";
                html += "</div>|" + h["TaiKhoan"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    public void DanhSachTaiKhoan_Jquery()
    
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
                ArrayList arr = data.SQLMultiHashReader(sql, conn);
                foreach (Hashtable h in arr)
                {

                    html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoan('" + h["TaiKhoan"] + "','" + idText + "')\">";
                    html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TaiKhoan"] + "</p>";
                    html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["TenTaiKhoan"] + "</p>";
                    html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["ChiTiet"] + "</p>";
                    html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TKCapCha"] + "</p>";
                    html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["Cap"] + "</p>";
                    html += "</div>|" + h["TaiKhoan"] ;
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

            sql = "select TaiKhoan,TenTaiKhoan,ChiTiet,TKCapCha,Cap from DanhMucTK ";

            if (!string.IsNullOrEmpty(key))
                sql += "  where TaiKhoan  LIKE '" + key + "%' or TKCapCha   LIKE '" + key + "%'";
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoan2('" + h["TaiKhoan"] + "','" + h["TenTaiKhoan"] + "','" + idText + "','"+i+"')\">";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TaiKhoan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["TenTaiKhoan"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["ChiTiet"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TKCapCha"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["Cap"] + "</p>";
                html += "</div>|" + h["TaiKhoan"] + "|" + h["TenTaiKhoan"];
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
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoanNganHang('" + h["TaiKhoanKT"] + "','" + h["SoHieuTKNH"] + "','" + h["TenTKNH"] + "')\">";
                html += "<p style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["SoHieuTKNH"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["TenTKNH"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TaiKhoanKT"] + "</p>";

                html += "</div>|" + h["TaiKhoanKT"] + "|" + h["SoHieuTKNH"] + "|" + h["TenTKNH"];
                html += Environment.NewLine;
            }

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
            sql = "select top(200) idBenhNhan,MaBenhNhan,TenBenhNhan,NgaySinh,GioiTinh,DiaChi from BenhNhan ";
            if(type=="txtMaKH"&&!string.IsNullOrEmpty(Key))
               sql += "  Where MaBenhNhan  LIKE '%" + Key + "%'";
            else
               if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
               {
                   sql += "  Where TenBenhNhan  LIKE '%" + Key + "%'";
               }
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonBenhNhan('" + h["MaBenhNhan"] + "','" + h["TenBenhNhan"] + "','" + h["idBenhNhan"] + "')\">";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["MaBenhNhan"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["TenBenhNhan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["NgaySinh"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["DiaChi"] + "</p>";
                html += "</div>|" + h["MaBenhNhan"] + "|" + h["TenBenhNhan"] + "|" + h["idBenhNhan"];
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
            sql = "select top(200) idBenhNhan,MaBenhNhan,TenBenhNhan,NgaySinh,GioiTinh,DiaChi from BenhNhan ";
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaBenhNhan  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenBenhNhan  LIKE '%" + Key + "%'";
                }
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonBenhNhan('" + h["MaBenhNhan"] + "','" + h["TenBenhNhan"] + "','" + h["idBenhNhan"] + "','" + h["DiaChi"] + "')\">";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["MaBenhNhan"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["TenBenhNhan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["NgaySinh"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["DiaChi"] + "</p>";
                html += "</div>|" + h["MaBenhNhan"] + "|" + h["TenBenhNhan"] + "|" + h["idBenhNhan"] + "|" + h["DiaChi"];
                html += Environment.NewLine;
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
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaKhachHang  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenKhachHang  LIKE '%" + Key + "%'";
                }
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonKhachHang('" + h["MaKhachHang"] + "','" + h["TenKhachHang"] + "',)\">";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["MaKhachHang"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["TenKhachHang"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["DiaChi"] + "</p>";
                html += "</div>|" + h["MaKhachHang"] + "|" + h["TenKhachHang"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
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
            sql = "select top(100) MaKhachHang,TenKhachHang,DiaChi from KhachHang ";
            if (type == "txtMaKH" && !string.IsNullOrEmpty(Key))
                sql += "  Where MaKhachHang  LIKE '%" + Key + "%'";
            else
                if (type == "txtTenKH" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenKhachHang  LIKE '%" + Key + "%'";
                }
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonKhachHang('" + h["MaKhachHang"] + "','" + h["TenKhachHang"] + "','" + h["DiaChi"] + "')\">";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["MaKhachHang"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["TenKhachHang"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["DiaChi"] + "</p>";
                html += "</div>|" + h["MaKhachHang"] + "|" + h["TenKhachHang"] + "|" + h["DiaChi"];
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
            if (type == "txtMaNCC" && !string.IsNullOrEmpty(Key))
                sql += " where MaNhaCungCap  LIKE '" + Key + "%'";
            else
                if (type == "txtTenNCC" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenNhaCungCap  LIKE '%" + Key + "%'";
                }
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonNCC('" + h["NhaCungCapId"] + "','" + h["MaNhaCungCap"]+"','" + h["TenNhaCungCap"] + "')\">";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["MaNhaCungCap"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TenNhaCungCap"] + "</p>";
                html += "</div>|" + h["NhaCungCapId"] + "|" + h["MaNhaCungCap"] + "|" + h["TenNhaCungCap"];
                html += Environment.NewLine;
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
        html += "|<div style=\"width: 300px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã nhà cung cấp</div>";
        html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên nhà cung cấp</div>";

        html += "</div>|||||";

        html += Environment.NewLine;
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
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonNCC('" + h["NhaCungCapId"] + "','" + h["MaNhaCungCap"] + "','" + h["TenNhaCungCap"] + "','" + h["TaiKhoanNganHang"] + "','" + h["NganHang"] + "')\">";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["MaNhaCungCap"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TenNhaCungCap"] + "</p>";
                html += "</div>|" + h["NhaCungCapId"] + "|" + h["MaNhaCungCap"] + "|" + h["TenNhaCungCap"] + "|" + h["TaiKhoanNganHang"] + "|" + h["NganHang"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    
    public void SaveBangGiaTyGia()
    {
        string Ngay = Request.QueryString["Ngay"];
        string MaLoaiTien = Request.QueryString["MaLoaiTien"];
        string TyGia = Request.QueryString["TyGia"];
        string GhiChu = Request.QueryString["GhiChu"];

        string[] arrNgay = Ngay.Split('_');
        string[] arrMaLoaiTien = MaLoaiTien.Split('/');
        string[] arrTyGia = TyGia.Split('/');
        string[] arrGhiChu = GhiChu.Split('/');

        //check Ma bang gia va ma kenh
        // string sqlCheck ="select * from BangGia_Kenh where MaBangGia = '"+MaBangBaoGia+"'  and MaKenh = '"+Kenh+"'";

        for (int i = 0; i < arrMaLoaiTien.Length; i++)
        {
            if (arrMaLoaiTien[i].ToString() != "" && arrNgay[i].ToString() != "")
            {
                bool SP_BGIsExists = mdlCommonFunction.CheckExist(conn, "DanhMucTyGia", "Ngay", Convert.ToDateTime(arrNgay[i].ToString()), "MaLoaiTien", arrMaLoaiTien[i].ToString());
                string strSQL = "";
                if (SP_BGIsExists)
                {
                    string message = "Tỷ giá " + arrMaLoaiTien[i].ToString() + " trong ngày " + arrNgay[i].ToString() + " đã có. Không thể thêm mới. Vui lòng nhấn nút sửa để thay đổi! ";
                    //   strSQL = "Update BangGiaSanPham set DonGia='" + arrDonGia[i].Trim() + "',VAT='" + arrVAT[i].Trim() + "',DonGiaSauVAT='" + arrDonGiaSauVAT[i].Trim() + "',TuNgay='" + NgayBatDau + "',DenNgay='" + NgayKeThuc + "',GhiChu=N'" + GhiChu + "',ChietKhau='" + arrChietKhau[i].Trim() + "' where MaSanPham = '" + arrMaSanPham[i].Trim() + "' and MaBangGia=N'" + MaBangBaoGia + "' ";
                }
                else
                    strSQL = "insert into DanhMucTyGia (Ngay,MaLoaiTien,TyGia,GhiChu) values('" + Convert.ToDateTime(mdlCommonFunction.ChangeDateTo_MM_dd((arrNgay[i].ToString()))) + "','" + arrMaLoaiTien[i].ToString().Trim() + "','" + Double.Parse(arrTyGia[i].ToString().Trim()) + "',N'" + arrGhiChu[i].ToString() + "')";

                mdlCommonFunction.Exec(strSQL, conn);

                Response.Write(1);
            }
        }
    }
    public void SaveBangGiaSanPham()
    {

        string MaBangBaoGia = Request.QueryString["MaBangBaoGia"];
        string GhiChu = Request.QueryString["GhiChu"];
        string NgayBatDau = Request.QueryString["NgayBatDau"];
        string NgayKeThuc = Request.QueryString["NgayKeThuc"];
        string Kenh = Request.QueryString["Kenh"];
        string MaSanPham = Request.QueryString["MaSanPham"];
        string DonGia = Request.QueryString["DonGia"];
        string ChietKhau = Request.QueryString["ChietKhau"];
        string VAT = Request.QueryString["VAT"];
        string DonGiaSauVAT = Request.QueryString["DonGiaSauVAT"];

        string[] arrKenh = Kenh.Split('/');
        string[] arrMaSanPham = MaSanPham.Split('/');
        string[] arrDonGia = DonGia.Split('/');
        string[] arrChietKhau = ChietKhau.Split('/');
        string[] arrVAT = VAT.Split('/');
        string[] arrDonGiaSauVAT = DonGiaSauVAT.Split('/');
        //check Ma bang gia va ma kenh
        // string sqlCheck ="select * from BangGia_Kenh where MaBangGia = '"+MaBangBaoGia+"'  and MaKenh = '"+Kenh+"'";
        bool rs = false;
        if (!string.IsNullOrEmpty(MaBangBaoGia) && !mdlCommonFunction.CheckExist(conn, "BangGiaSanPham", "MaBangGia", MaBangBaoGia))
        {


            //---------------------------Lưu bang giá kênh--------------------------------
            bool BG_KenhIsExists = mdlCommonFunction.CheckExist(conn, "BangGia_Kenh", "MaBangGia", MaBangBaoGia);
            if (BG_KenhIsExists)
            {
                string strDeleteBangGia = "Delete BangGia_Kenh where MaBangGia = '" + MaBangBaoGia + "'";
                rs = mdlCommonFunction.Exec_Ngoc(strDeleteBangGia, conn);
                if (rs)
                {
                    for (int i = 0; i < arrKenh.Length-1; i++)
                    {
                        if (arrKenh[i] != null && arrKenh[i] != "" && arrKenh[i] != "0")
                        {
                            string strInsertBangGiaKenh = "Insert into BangGia_Kenh(MaBangGia,MaKenh) values('" + MaBangBaoGia + "','" + arrKenh[i] + "')";
                            rs = mdlCommonFunction.Exec_Ngoc(strInsertBangGiaKenh, conn);
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < arrKenh.Length-1; i++)
                {
                    if (arrKenh[i] != null && arrKenh[i] != "" && arrKenh[i] != "0")
                    {
                        string strInsertBangGiaKenh = "Insert into BangGia_Kenh(MaBangGia,MaKenh) values('" + MaBangBaoGia + "','" + arrKenh[i] + "')";
                        rs = mdlCommonFunction.Exec_Ngoc(strInsertBangGiaKenh, conn);
                    }

                }
            }
            //-----------------------------------------0o0--------------------------------------------------------------

            //------------------------------------------Lưu bảng giá sản phẩm-------------------------------------------

            for (int i = 0; i < arrMaSanPham.Length-1; i++)
            {
                //bool SP_BGIsExists = mdlCommonFunction.CheckExist(conn, "BangGiaSanPham", "MaSanPham", arrMaSanPham[i].ToString(), "MaBangGia", MaBangBaoGia);
                string strSQL = "";
                //if (SP_BGIsExists)
                // strSQL = "Update BangGiaSanPham set DonGia='" + arrDonGia[i].Trim() + "',VAT='" + arrVAT[i].Trim() + "',DonGiaSauVAT='" + arrDonGiaSauVAT[i].Trim() + "',TuNgay='" + NgayBatDau + "',DenNgay='" + NgayKeThuc + "',GhiChu=N'" + GhiChu + "',ChietKhau='" + arrChietKhau[i].Trim() + "' where MaSanPham = '" + arrMaSanPham[i].Trim() + "' and MaBangGia=N'" + MaBangBaoGia + "' ";
                //else
                strSQL = "insert into BangGiaSanPham (MaSanPham,DonGia,VAT,DonGiaSauVAT,TuNgay,DenNgay,MaBangGia,GhiChu,ChietKhau) values('" + arrMaSanPham[i].Trim() + "','" + arrDonGia[i].Trim() + "','" + arrVAT[i].Trim() + "','" + arrDonGiaSauVAT[i].Trim() + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayBatDau) + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayKeThuc) + "',N'" + MaBangBaoGia + "',N'" + GhiChu + "','" + arrChietKhau[i].Trim() + "')";

                rs = mdlCommonFunction.Exec_Ngoc(strSQL, conn);


            }
            if (rs)
            {
                Response.Write(1);
                //Console.Write("<script language=\"javascript\" type=\"text/javascript\" > alert(\"Lưu dữ liệu thành công!\")</script>");
            }
            else
            {
                Response.Write(0);
                // Console.Write("<script language=\"javascript\" type=\"text/javascript\" > alert(\"Lưu dữ liệu thất bại vui lòng kiểm tra lại. Cảm ơn!\")</script>");
            }

            //---------------------------------------------------------0o0-----------------------------------------------------------------
        }
        else
        {
            Response.Write(2);
            //Console.Write("<script language=\"javascript\" type=\"text/javascript\" > alert(\"Bảng báo giá " + MaBangBaoGia + " đã tồn tại không thể lưu mới.Vui lòng nhấn 'Sửa' nếu muốn cập nhật. Hoặc đổi tên Bảng giá nếu muốn lưu mới !\")</script>");
        }
    }
    public void UpdateBangGiaSanPham()
    {

        string MaBangBaoGia = Request.QueryString["MaBangBaoGia"];
        string GhiChu = Request.QueryString["GhiChu"];
        string NgayBatDau = Request.QueryString["NgayBatDau"];
        string NgayKeThuc = Request.QueryString["NgayKeThuc"];
        string Kenh = Request.QueryString["Kenh"];
        string MaSanPham = Request.QueryString["MaSanPham"];
        string DonGia = Request.QueryString["DonGia"];
        string ChietKhau = Request.QueryString["ChietKhau"];
        string VAT = Request.QueryString["VAT"];
        string DonGiaSauVAT = Request.QueryString["DonGiaSauVAT"];

        string[] arrKenh = Kenh.Split('/');
        string[] arrMaSanPham = MaSanPham.Split('/');
        string[] arrDonGia = DonGia.Split('/');
        string[] arrChietKhau = ChietKhau.Split('/');
        string[] arrVAT = VAT.Split('/');
        string[] arrDonGiaSauVAT = DonGiaSauVAT.Split('/');
        //check Ma bang gia va ma kenh
        // string sqlCheck ="select * from BangGia_Kenh where MaBangGia = '"+MaBangBaoGia+"'  and MaKenh = '"+Kenh+"'";
        bool rs = false;
        if (!string.IsNullOrEmpty(MaBangBaoGia) && mdlCommonFunction.CheckExist(conn, "BangGiaSanPham", "MaBangGia", MaBangBaoGia))
        {

            bool BG_KenhIsExists = mdlCommonFunction.CheckExist(conn, "BangGia_Kenh", "MaBangGia", MaBangBaoGia);
            if (BG_KenhIsExists)
            {
                string strDeleteBangGia = "Delete BangGia_Kenh where MaBangGia = '" + MaBangBaoGia + "'";
                rs = mdlCommonFunction.Exec_Ngoc(strDeleteBangGia, conn);
                if (rs)
                {
                    for (int i = 0; i < arrKenh.Length - 1; i++)
                    {
                        if (arrKenh[i] != null && arrKenh[i] != "" && arrKenh[i] != "0")
                        {
                            string strInsertBangGiaKenh = "Insert into BangGia_Kenh(MaBangGia,MaKenh) values('" + MaBangBaoGia + "','" + arrKenh[i] + "')";
                            rs = mdlCommonFunction.Exec_Ngoc(strInsertBangGiaKenh, conn);
                        }

                    }
                }
            }


            for (int i = 0; i < arrMaSanPham.Length - 1; i++)
            {
                bool SP_BGIsExists = mdlCommonFunction.CheckExist(conn, "BangGiaSanPham", "MaSanPham", arrMaSanPham[i].ToString(), "MaBangGia", MaBangBaoGia);
                string strSQL = "";
                if (SP_BGIsExists)
                    strSQL = "Update BangGiaSanPham set DonGia='" + arrDonGia[i].Trim() + "',VAT='" + arrVAT[i].Trim() + "',DonGiaSauVAT='" + arrDonGiaSauVAT[i].Trim() + "',TuNgay='" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayBatDau) + "',DenNgay='" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayKeThuc) + "',GhiChu=N'" + GhiChu + "',ChietKhau='" + arrChietKhau[i].Trim() + "' where MaSanPham = '" + arrMaSanPham[i].Trim() + "' and MaBangGia=N'" + MaBangBaoGia + "' ";
                else
                    strSQL = "insert into BangGiaSanPham (MaSanPham,DonGia,VAT,DonGiaSauVAT,TuNgay,DenNgay,MaBangGia,GhiChu,ChietKhau) values('" + arrMaSanPham[i].Trim() + "','" + arrDonGia[i].Trim() + "','" + arrVAT[i].Trim() + "','" + arrDonGiaSauVAT[i].Trim() + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayBatDau) + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayKeThuc) + "',N'" + MaBangBaoGia + "',N'" + GhiChu + "','" + arrChietKhau[i].Trim() + "')";

                rs = mdlCommonFunction.Exec_Ngoc(strSQL, conn);


            }
            if (rs)
            {
                Response.Write(1);
                //Console.Write("<script language=\"javascript\" type=\"text/javascript\" > alert(\"Lưu dữ liệu thành công!\")</script>");
            }
            else
            {
                Response.Write(0);
                //Console.Write("<script language=\"javascript\" type=\"text/javascript\" > alert(\"Lưu dữ liệu thất bại vui lòng kiểm tra lại. Cảm ơn!\")</script>");
            }
        }
        else
        {
            Response.Write(2);
            //Console.Write("<script language=\"javascript\" type=\"text/javascript\" > alert(\"Bảng báo giá "+MaBangBaoGia+" chưa có không thể cập nhật thông tin!\")</script>");
        }
    }
    private void LoadDanhSachSanPham_Jquery()
    {
        try
        {
            string TenSP = Request.QueryString["q"];
            string i = Request.QueryString["dop"];

            string html = "";

            //html += "|<div style =\"background-color: #4D67A2;height:20px\">";
            html += "|<div style=\"width: 510px; border-color: Black; border-width: 2px\">";
            html += "<div style=\"background-color:Blue; color:#66CCCC;font-weight: bold\">";
            html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã sản phẩm</div>";
            html += "<div style=\"width: 300px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên sản phẩm</div>";
            html += "<div style=\"width: 109px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Đơn vị tính</div>";
            html += "</div>|||";

            html += Environment.NewLine;
            string sql = "select top(100) *  ";
            sql += "    FROM SanPham ";
            // string swhere = "";
            if (!string.IsNullOrEmpty(TenSP))
                sql += "   Where TenSanPham LIKE N'" + TenSP + "%'";
            sql += "    ORDER BY TenSanPham ASC";
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div  style=\"cursor: pointer\" onclick=\"setChonSanPham('" + h["idsanpham"] + "','" + h["tensanpham"] + "','" + h["donvitinh"] + "','" + i + "')\">";
                html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["idsanpham"] + "</p>";
                html += "<p style=\"width: 300px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["tensanpham"] + "</p>";
                html += "<p style=\"width: 108px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["donvitinh"] + "</p>";
                html += "</div>|" + h["idsanpham"] + "|" + h["tensanpham"] + "|" + h["donvitinh"];
                html += Environment.NewLine;
            }
            //html += "<tr><td colspan=\"2\"><br/></td></tr>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private string encodeURIComponent(string p)
    {
        throw new Exception("The method or operation is not implemented.");
    }


    private void ShowSanPham()
    {
        string KeyTenSP = Request.QueryString["KeyTenSP"];
        string html = "";
        html += "<div style=\"color:Black;font-weight:bold;text-align:center\" >Danh sách sản phẩm</div>||";
        html += Environment.NewLine;
        //string idDVCLSByTN = "";
        string sqlSanPham = "select * from SanPham where TenSanPham like N'%" + KeyTenSP + "%'";
        DataTable arrSanPham = mdlCommonFunction.LoadDataTable(sqlSanPham, conn);
        html += "<div style=\"border-width:thin;  border-bottom-style: outset; width: 405px\">";
        html += "<div style=\"float: left; text-align: center; border-left: 0px; border-right: 2px;margin-left: 0px; width: 100px;font-weight:bold\">Mã sản phẩm</div>";
        html += "<div style=\"float: left; text-align: center; border-left: 2px; border-right: 2px;margin-left: 0px; width: 200px; font-weight: bold\">Tên sản phẩm</div>";
        html += "<div style=\"float: left; text-align: center; border-left: 2px; border-right: 0px;margin-left: 0px; width: 104px; font-weight: bold\">Đơn vị tính</div>";
        foreach (DataRow row in arrSanPham.Rows)
        {
            html += "<div style=\"float: left; text-align: center; border-left: 0px; border-right: 2px;margin-left: 0px; width: 100px\">" + row["MaSanPham"].ToString() + "</div>";
            html += "<div style=\"float: left; text-align: center; border-left: 2px; border-right: 2px;margin-left: 0px; width: 200px\">" + row["TenSanPham"].ToString() + "</div>";
            html += "<div style=\"float: left; text-align: center; border-left: 2px; border-right: 0px;margin-left: 0px; width: 104px\">" + row["DonViTinh"].ToString() + "</div>";
            html += Environment.NewLine;
        }
        html += "</div>";

        Response.Write(html);
    }
    private void LoadKenh()
    {
        try
        {
            string KeyTenKenh = Request.QueryString["KeyTenKenh"];
            string i = Request.QueryString["i"];

            string html = "";

            html += "|<div style=\"width: 300px; border-color:Black; border-width: 2px\">";
            html += "<div style=\"background-color:Blue;width: 300px;color:White ;font-weight: bold\">";
            html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã kênh</div>";
            html += "<div style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên kênh</div>";

            html += "</div>||";


            html += Environment.NewLine;
            string sql = "select * from DanhMucKenh where TenKenh like N'%" + KeyTenKenh.Trim() + "%'";
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {

                html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#FFFFFF'\" style=\"cursor: pointer;width: 300px\" onclick=\"setChonSanPham(" + h["MaKenh"] + ",'" + h["TenKenh"] + "','" + i + "')\">";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["MaKenh"] + "</p>";
                html += "<p style=\"width: 200px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TenKenh"] + "</p>";

                html += "</div>|" + h["MaKenh"] + "|" + h["TenKenh"];
                html += Environment.NewLine;
            }
            //html += "<tr><td colspan=\"2\"><br/></td></tr>";

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }


    #endregion Ngoc lưu bang gia san pham
   //==================================================================================================
    
    
    public void GetTKNH()
    {
        string idncc = Request.QueryString["strSear"];
        string ngay = Request.QueryString["ngay"];
        string sql = "Select * From NhaCungCap Where MaNhaCungCap='" + idncc + "'";
        DataTable dt = mdlCommonFunction.LoadDataTable(sql, conn);
        if (dt != null && dt.Rows.Count > 0)
        {
            Response.Write(dt.Rows[0]["taikhoannganhang"].ToString());
        }
        else
            Response.Write("");
    }

    public void GetTyGia()
    {
        string loaitien = Request.QueryString["strSear"];
        string ngay = Request.QueryString["ngay"];
        string sql = "Select * From DanhMucTyGia Where MaLoaiTien='" + loaitien + "' and Ngay='" + mdlCommonFunction.CheckDate(ngay) + "'";
        DataTable dt = mdlCommonFunction.LoadDataTable(sql, conn);
        if (dt != null && dt.Rows.Count > 0)
        {
            Response.Write(dt.Rows[0]["TyGia"].ToString());
        }
        else
            Response.Write("");
    }

    public void LoadTieuDe()
    {
        string html = "", strnguoidung="";
        string Userhost = Request.UserHostAddress.ToString();
        string sql = "Select a.*, b.tennguoidung From NguoiDung_Host a join NguoiDung b on a.idnguoidung=b.idnguoidung Where a.IdClient='" + Userhost.Trim() + "'";
        DataTable dt1 = mdlCommonFunction.LoadDataTable(sql, conn);
        if (dt1 != null && dt1.Rows.Count > 0)//neu ton tai nguoi dung & IP 
        {
            strnguoidung = dt1.Rows[0]["tennguoidung"].ToString();
            html = "<span class = \"Tieude\">PHẦN MỀM QUẢN LÝ - Người dùng: "+ strnguoidung +"</span> ";
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
        int idncc = data.ParseInt(Request.QueryString["strSear"]);
        string sql = "Select * From NhaCungCap Where MaNhaCungCap=" + idncc;
        DataTable dt = mdlCommonFunction.LoadDataTable(sql, conn);
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
        int idncc = data.ParseInt(Request.QueryString["strSear"]);
        string strSQL = "SELECT * ";
        strSQL += "     FROM NhaCungCap ";
        strSQL += "     WHERE manhacungcap = " + idncc;
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
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

    private void getncc()
    {
        try
        {
            
            string html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";

            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"50%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên nhà cung cấp</td>";
            html += "<td width=\"20%\" class=\"item\" style=\"color:white;font-weight:bold;\" >địa chỉ</td>";
            html += "<td width=\"25%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Mã NCC</td>";
            html += "</tr>";
            string stim = Request.QueryString["tenncc"];
            string sql = "Select * From NhaCungCap Where 1=1 ";
            if (stim != "")
                sql += " and (Tennhacungcap like N'%" + stim + "%' or dinhdanhimei like '" + stim + "%')";

            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"setChonNCC(" + h["nhacungcapid"] + ")\">";
                html += "<td width=\"50%\" class=\"ptext\" >&nbsp;" + h["tennhacungcap"] + "</td>";
                html += "<td width=\"20%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["diachi"] + "</td>";
                html += "<td width=\"25%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["dinhdanhimei"] + "</td>";
                html += "</tr>";
            }
            //html += "<tr><td colspan=\"2\"><br/></td></tr>";

            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    
    }

    //Lay danh muc NCC
    public void SetNCC1()
    {
        int idncc = data.ParseInt(Request.QueryString["strSear"]);
        string strSQL = "SELECT * ";
        strSQL += "     FROM NhaCungCap ";
        strSQL += "     WHERE nhacungcapid = " + idncc;
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddlDVNhan\" id=\"ddlDVNhan\" style=\"height:19px;width:250px;\" runat=\"server\" tabindex=\"10\" >";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + dt.Rows[i]["nhacungcapid"].ToString() + "\" ";
            shtml += ">" + dt.Rows[i]["tennhacungcap"].ToString() + "</option>";
        }
        shtml += "</select>";
        Response.Write(shtml);
        dt = null;
    }

    private void getncc1()
    {
        try
        {

            string html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";

            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"50%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên nhà cung cấp</td>";
            html += "<td width=\"20%\" class=\"item\" style=\"color:white;font-weight:bold;\" >địa chỉ</td>";
            html += "<td width=\"25%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Mã NCC</td>";
            html += "</tr>";
            string stim = Request.QueryString["tenncc"];
            string sql = "Select * From NhaCungCap Where 1=1 ";
            if (stim != "")
                sql += " and (Tennhacungcap like N'%" + stim + "%' or dinhdanhimei like '" + stim + "%')";

            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"setChonNCC(" + h["nhacungcapid"] + ")\">";
                html += "<td width=\"50%\" class=\"ptext\" >&nbsp;" + h["tennhacungcap"] + "</td>";
                html += "<td width=\"20%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["diachi"] + "</td>";
                html += "<td width=\"25%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["dinhdanhimei"] + "</td>";
                html += "</tr>";
            }
            //html += "<tr><td colspan=\"2\"><br/></td></tr>";

            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }

    private void editthongtinphieuxuat()
    {
        string tkno = Request.QueryString["tkno"];
        string tkco = Request.QueryString["tkco"];
        string tkvat = Request.QueryString["tkvat"];
        string kyhieuhd = Request.QueryString["kyhieuhd"];
        //string sopo = Request.QueryString["sopo"];
        string soct = Request.QueryString["soct"];
        string ngayct = mdlCommonFunction.CheckDate(Request.QueryString["ngayct"]);
        int kho = data.ParseInt(Request.QueryString["kho"]);
        int ncc = data.ParseInt(Request.QueryString["ncc"]);
        string ngayhoadon = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]);
        string sohoadon = Request.QueryString["sohoadon"];
        string diengiai = Request.QueryString["diengiai"];
        int loaixuat = data.ParseInt(Request.QueryString["ptn"]);

        string sql = "Update phieuxuatkhosanpham Set";
        sql += " tkno='" + tkno.Trim() + "'";
        sql += ",tkco='" + tkco.Trim() + "'";
        sql += ",tkvat='" + tkvat.Trim() + "'";
        sql += ",kyhieuhoadon='" + kyhieuhd + "'";
        sql += ",maphieuxuat='" + soct + "'";
        sql += ",ngaythang='" + ngayct + "'";
        sql += ",idtukho=" + kho;
        sql += ",iddoituong=" + ncc;
        sql += ",ngayhoadon='" + ngayhoadon + "'";
        sql += ",sohoadon='" + sohoadon + "'";
        sql += ",ghichu=N'" + diengiai + "'";
        sql += ",loaixuat=" + loaixuat;
        sql += " WHERE idphieuxuat=" + data.ParseInt(Session["MaPhieu"].ToString());
        try
        {
            mdlCommonFunction.Exec(sql, conn);
            Response.Write("Đã cập nhật thành công thông tin phiếu xuất.");
        }
        catch (Exception)
        {
            Response.Write("Có lỗi xãy ra trong quá trình cập nhật dữ liệu.");
        }
    }

    public void GetDonGia()
    {
        int idsp = data.ParseInt(Request.QueryString["strSear"]);
        int isthuoc = data.ParseInt(Request.QueryString["isthuoc"]);
        string sql = "";
        if (isthuoc == 0)
        {
            sql = "SELECT *, b.dgsauchietkhau as dongia ";
            sql += "    FROM sanpham a left join (select distinct idsanpham, dgsauchietkhau ";
            sql += "                            from chitietphieunhapkhosanpham a ";
            sql += "                            where a.idphieunhap =(select max(idphieunhap) from chitietphieunhapkhosanpham where idsanpham=a.idsanpham)";
            sql += "                            )b on a.idsanpham=b.idsanpham";
            sql += "    WHERE 1 =1 and  a.idsanpham=" + idsp;
            sql += "    ORDER BY tensanpham ASC";
        }
        else
        {
            sql = "SELECT *, b.dgsauchietkhau as dongia ";
            sql += "    FROM thuoc a left join (select distinct idthuoc, dgsauchietkhau ";
            sql += "                            from chitietphieunhapkho a ";
            sql += "                            where a.idphieunhap =(select max(idphieunhap) from chitietphieunhapkho where idthuoc=a.idthuoc)";
            sql += "                            )b on a.idthuoc=b.idthuoc";
            sql += "    WHERE 1 =1 and a.idthuoc="+ idsp;
            sql += "    ORDER BY tenthuoc ASC";
        }
        DataTable dt = mdlCommonFunction.LoadDataTable(sql, conn);
        if (dt != null && dt.Rows.Count > 0)
        {
            Response.Write(dt.Rows[0]["dongia"]);
        }
        else
            Response.Write(0);
    }

    //Lay danh muc thuoc
    public void LoadDMThuoc2()
    {
        int idncc = data.ParseInt(Request.QueryString["strSear"]);
        string strSQL = "SELECT distinct idthuoc, tenthuoc ";
        strSQL += "     FROM (";
        strSQL += "         SELECT idthuoc, tenthuoc ";
        strSQL += "         FROM thuoc ";
        strSQL += "         WHERE nhacungcapid = " + idncc;
        strSQL += "         UNION ALL ";
        strSQL += "         SELECT b.idthuoc, c.tenthuoc ";
        strSQL += "         FROM phieunhapkho a  join chitietphieunhapkho b on a.idphieunhap=b.idphieunhap ";
        strSQL += "                                     join thuoc c on b.idthuoc=c.idthuoc ";
        strSQL += "         WHERE a.nhacungcapid = " + idncc;
        strSQL += "         )A ";
        strSQL += " ORDER BY tenthuoc";
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddlVatTu\" id=\"ddlVatTu\" style=\"height:19px;width:250px;\" runat=\"server\" tabindex=\"10\" onchange=\"SetSanPham()\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + dt.Rows[i]["idthuoc"].ToString() + "\" ";
            shtml += ">" + dt.Rows[i]["tenthuoc"].ToString() + "</option>";
        }
        shtml += "</select>";
        Response.Write(shtml);
        dt = null;
    }
    //Show nhung sp search duoc
    public void LoadSP()
    {
        int sSearch = data.ParseInt(Request.QueryString["strSear"]);
        int kho = data.ParseInt(Request.QueryString["kho"]);//ThuanNH edit 29/03/2011 - 10:46PM
        string strSQL = "";
        if (kho == 1)
        {
            strSQL = "SELECT * FROM sanpham ";
            strSQL += "WHERE idsanpham = " + sSearch;
            strSQL += " ORDER BY tensanpham";
        }
        else
        {
            strSQL = "SELECT idthuoc as idsanpham, tenthuoc as tensanpham FROM thuoc ";
            strSQL += "WHERE idthuoc = " + sSearch;
            strSQL += " ORDER BY tenthuoc";
        }
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddlVatTu\" id=\"ddlVatTu\" style=\"height:19px;width:250px;\" runat=\"server\" tabindex=\"10\" >";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + dt.Rows[i]["idsanpham"].ToString() + "\" ";
            //if (dt.Rows[i]["mathuoc"].ToString() == imatp)
            //{
            //    shtml += " selected=\"selected\"";
            //}
            shtml += ">" + dt.Rows[i]["tensanpham"].ToString() + "</option>";
        }
        shtml += "</select>";
        Response.Write(shtml);
        dt = null;
    }
    private void LoadDanhSachSP()
    {
        try
        {
            string tensp = Request.QueryString["tensanpham"];
            string kho = Request.QueryString["kho"];//ThuanNH edit 29/03/2011 - 10:38PM
            string swhere = "";
            if (tensp != "")
                swhere += " AND tensanpham LIKE N'" + tensp + "%' ";
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";

            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"30%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên sản phẩm</td>";
            html += "<td width=\"30%\" class=\"item\" style=\"color:white;font-weight:bold;\" >đơn vị tính</td>";
            html += "<td width=\"25%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Imei</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Nhãn hàng</td>";
            html += "</tr>";
            string sql = "";
            if (data.ParseInt(kho)==1)
                sql = "SELECT * FROM sanpham WHERE 1 =1 " + swhere + " ORDER BY tensanpham ASC";
            else
            {
                sql = "SELECT idthuoc as idsanpham, tenthuoc as tensanpham, donvitinh, imei, '' as nhanhang ";
                sql += "FROM thuoc WHERE 1 =1 AND tenthuoc LIKE N'" + tensp + "%' ORDER BY tenthuoc ASC";
            }

            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"setChonSP(" + h["idsanpham"] + ",'" + h["tensanpham"] + "','" + h["donvitinh"] + "','" + h["imei"] + "')\">";
                html += "<td width=\"30%\" class=\"ptext\" >&nbsp;" + h["tensanpham"] + "</td>";
                html += "<td width=\"30%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["donvitinh"] + "</td>";
                html += "<td width=\"25%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["imei"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["nhanhang"] + "</td>";
                html += "</tr>";
            }
            //html += "<tr><td colspan=\"2\"><br/></td></tr>";

            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    //Update chi tiet phieu nhap
    public void EditItemPhieuNhap()
    {
        string mactp = Request.QueryString["mactp"];
        string mavt = Request.QueryString["mavt"];
        Double dongia = data.ParseFloat(Request.QueryString["dongia"]);
        int soluong = data.ParseInt(Request.QueryString["soluong"]);
        int mucck = data.ParseInt(Request.QueryString["mucck"]);
        int vat = data.ParseInt(Request.QueryString["vat"]);
        //object oNgayhethan = Request.QueryString["ngayhethan"];
        //string losx = Request.QueryString["losx"];
        clsChiTietPhieuNhap cls = new clsChiTietPhieuNhap();
        cls.IdChiTietPhieuNhapKho = data.ParseInt(mactp);
        cls.MaPhieuNhap = data.ParseInt(Session["IdPhieuNhap"]);
        cls.MaThuoc = data.ParseInt(mavt);
        cls.SoLuong = soluong;
        cls.DonGia = dongia;
        cls.chietkhau = mucck;
        cls.vat = vat;
        //if (oNgayhethan.ToString() == "" || oNgayhethan.ToString() == null)
        //    cls.NgayHetHan = DBNull.Value;
        //else
        //    cls.NgayHetHan = mdlCommonFunction.CheckDate1(oNgayhethan.ToString());
        //cls.LoSX = losx.Trim();
        try
        {
            cls.UpdateChiTietPhieuNhap(conn);
            LoadDanhsachChiTietPhieuNhap();
        }
        catch
        {
            Response.Write("0");
        }
    }

    //Delete chi tiet phieu nhap
    public void DeleteItemPhieuNhap()
    {
        int mactp = data.ParseInt(Request.QueryString["mactp"]);
        clsChiTietPhieuNhap cls = new clsChiTietPhieuNhap();
        cls.IdChiTietPhieuNhapKho = mactp;
        try
        {
            cls.DeleteChiTietPhieuNhapKho(conn);
            LoadDanhsachChiTietPhieuNhap();
        }
        catch
        {
            Response.Write("0");
        }
    }

    //Luu phieu nhap
    public void LoadLuuPhieuNhap()
    {
        string soct = Request.QueryString["soct"];
        string ngayct = mdlCommonFunction.CheckDate1(Request.QueryString["ngayct"]);
        string makho = Request.QueryString["kho"];
        string inhacc = Request.QueryString["nccid"];
        string ngayhoadon = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]);
        string tennguoigiao = Request.QueryString["tennguoigiao"];
        string diengiai = Request.QueryString["diengiai"];
        int inhapcho = data.ParseInt(Request.QueryString["nhapcho"]);
        string mavt = Request.QueryString["mavt"];
        int soluong = data.ParseInt(Request.QueryString["soluong"]);
        Double dongia = Convert.ToDouble(Request.QueryString["dongia"]);
        int vat = data.ParseInt(Request.QueryString["vat"]);
        //string loaitien = Request.QueryString["loaitien"];
        //Double tygia = Convert.ToDouble(Request.QueryString["tygia"]);
        //int thuenk = data.ParseInt(Request.QueryString["thuenk"]);

        float chietkhau = data.ParseFloat(Request.QueryString["chietkhau"]);
        Double dgsauchietkhau = dongia - ((dongia * chietkhau) / 100);
        Double dgsauvat = Math.Round(Convert.ToDouble(dgsauchietkhau * vat / 100), 0);
        string losx = Request.QueryString["losx"];
        object oNgayhethan = Request.QueryString["ngayhethan"];
        string tkno = Request.QueryString["tkno"];
        string tkco = Request.QueryString["tkco"];
        string tkvat = Request.QueryString["tkvat"];
        string kyhieuhd = Request.QueryString["kyhieuhd"];
        string sohoadon = Request.QueryString["sohoadon"];
        int ptn = data.ParseInt(Request.QueryString["ptn"]);
        if (mdlCommonFunction.CheckExist(conn, "phieunhapkho", "maphieunhap", soct.Trim(), "ngaythang", ngayct.Trim(), "", "", "", ""))
        {
            Response.Write(0);
            return;
        }
        try
        {
            //Insert thong tin phieu nhap
            clsPhieuNhapKho cls = new clsPhieuNhapKho();
            cls.MaPhieu = soct.Trim();
            cls.NgayCT = ngayct.Trim();
            cls.GhiChu = diengiai.Trim();
            cls.MaKho = data.ParseInt(makho);
            cls.NhaCungCap = data.ParseInt(inhacc);
            if (ngayhoadon.ToString() == "" || oNgayhethan.ToString() == null)
                cls.NgayHoaDon = DBNull.Value;
            else
                cls.NgayHoaDon = ngayhoadon;

            cls.TenNguoiGiao = tennguoigiao.Trim();
            cls.NhapCho = inhapcho;
            cls.KyHieuHD = kyhieuhd;
            cls.SoHoaDon = sohoadon;
            cls.TKNo = tkno;
            cls.TKCo = tkco;
            cls.TKVAT = tkvat;
            cls.PTN = ptn;
            int iIns = cls.InsertPhieuNhap(conn);

            if (iIns > 0)
            {
                Session["IdPhieuNhap"] = iIns;
                //Insert table chi tiet
                clsChiTietPhieuNhap clsct = new clsChiTietPhieuNhap();
                clsct.MaPhieuNhap = iIns;
                clsct.MaThuoc = data.ParseInt(mavt);
                clsct.SoLuong = soluong;
                clsct.DonGia = Convert.ToDouble(dongia);
                clsct.vat = vat;//ThuanNH 17/11/2010
                clsct.chietkhau = chietkhau;
                if (oNgayhethan.ToString() == "" || oNgayhethan.ToString() == null)
                    clsct.NgayHetHan = DBNull.Value;
                else
                    clsct.NgayHetHan = mdlCommonFunction.CheckDate1(oNgayhethan.ToString());
                clsct.LoSX = losx.Trim();

                try
                {
                    int imactp = clsct.InsertChiTietPhieuNhap(conn);
                    //Cap nhat tienhang, tienvat, tongtien vao table phieunhapkhosanpham
                    string strSQL = "  Select sum(dgsauchietkhau * soluong)as tienhang, sum(soluong*round((dgsauchietkhau * vat / 100),0))as tienvat ";
                    strSQL += " From chitietphieunhapkho ";
                    strSQL += " Where idphieunhap=" + iIns;
                    DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
                    if (dt.Rows.Count > 0)
                    {
                        cls.TienHang = Convert.ToDouble(dt.Rows[0]["tienhang"]);
                        cls.TienVAT = Convert.ToDouble(dt.Rows[0]["tienvat"]);
                        cls.TongTien = cls.TienHang + cls.TienVAT;
                    }
                    else
                    {
                        cls.TienHang = dgsauchietkhau * soluong;
                        cls.TienVAT = dgsauvat * soluong;
                        cls.TongTien = cls.TienHang + cls.TienVAT;
                    }
                    strSQL = "  Update phieunhapkho set tienhang=" + cls.TienHang;
                    strSQL += "         , tienvat=" + cls.TienVAT;
                    strSQL += "         , tongtien=" + cls.TongTien;
                    strSQL += " Where idphieunhap=" + iIns;
                    mdlCommonFunction.Exec(strSQL, conn);

                    dt = null;
                    if (imactp != 0)
                    {
                        clsct.idchitietphieunhapkho = imactp;
                        clsct.InsertSoLuongTon(conn);
                    }
                    Response.Write(2);
                    return;
                }
                catch
                {
                    Response.Write(1);
                    return;
                }
            }
        }
        catch
        {
            Response.Write(1);
            return;
        }
    }

    public void LoadLuuChiTietPhieuNhap()
    {
        string mavt = Request.QueryString["mavt"];
        int soluong = data.ParseInt(Request.QueryString["soluong"]);
        Double dongia = Convert.ToDouble(Request.QueryString["dongia"]);
        float chietkhau = data.ParseFloat(Request.QueryString["chietkhau"]);//ThuanNH add 16/11/2010
        int vat = data.ParseInt(Request.QueryString["vat"]);
        object oNgayhethan = Request.QueryString["ngayhethan"];
        string losx = Request.QueryString["losx"];

        //Insert table chi tiet
        clsChiTietPhieuNhap clsct = new clsChiTietPhieuNhap();
        clsct.MaPhieuNhap = data.ParseInt(Session["IdPhieuNhap"]);
        clsct.MaThuoc = data.ParseInt(mavt);
        clsct.SoLuong = soluong;
        clsct.DonGia = Convert.ToDouble(dongia);
        clsct.chietkhau = chietkhau;
        clsct.dgsauchietkhau = dongia - (dongia * chietkhau / 100);
        clsct.vat = vat;
        if (oNgayhethan.ToString() == "" || oNgayhethan.ToString() == null)
            clsct.NgayHetHan = DBNull.Value;
        else
            clsct.NgayHetHan = mdlCommonFunction.CheckDate1(oNgayhethan.ToString());
        clsct.LoSX = losx.Trim();
        try
        {
            int imactp = clsct.InsertChiTietPhieuNhap(conn);
            if (imactp != 0)
            {
                //Cap nhat tienhang, tienvat, tongtien vao table phieunhapkhosanpham
                string strSQL = "  Select sum(dgsauchietkhau * soluong)as tienhang, sum(soluong*round((dgsauchietkhau * vat / 100),0))as tienvat ";
                strSQL += " From chitietphieunhapkho ";
                strSQL += " Where idphieunhap=" + data.ParseInt(Session["IdPhieuNhap"]);
                DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
                if (dt.Rows.Count > 0)
                {
                    strSQL = "  Update phieunhapkho set tienhang=" + Convert.ToDouble(dt.Rows[0]["tienhang"]);
                    strSQL += "         , tienvat=" + Convert.ToDouble(dt.Rows[0]["tienvat"]);
                    strSQL += "         , tongtien=" + (Convert.ToDouble(dt.Rows[0]["tienhang"]) + Convert.ToDouble(dt.Rows[0]["tienvat"]));
                    strSQL += " Where idphieunhap=" + data.ParseInt(Session["IdPhieuNhap"]);
                    mdlCommonFunction.Exec(strSQL, conn);
                }
                dt = null;
                clsct.idchitietphieunhapkho = imactp;
                clsct.InsertSoLuongTon(conn);
            }
            Response.Write(2);
            return;
        }
        catch
        {
            Response.Write(1);
            return;
        }
    }
    private Double GetTongTienCT(DataTable dtSRC)
    {
        if (dtSRC == null || dtSRC.Rows.Count == 0) return 0.00;
        double dbKQ = 0;
        for (int i = 0; i < dtSRC.Rows.Count; i++)
        {
            dbKQ += Convert.ToDouble(dtSRC.Rows[i]["sotien"]);
        }
        return dbKQ;
    }
    private Double GetTongTien1(DataTable dtSRC)
    {
        if (dtSRC == null || dtSRC.Rows.Count == 0) return 0.00;
        double dbKQ = 0;
        for (int i = 0; i < dtSRC.Rows.Count; i++)
        {
            dbKQ += Convert.ToDouble(dtSRC.Rows[i]["ThanhTien"]);
        }
        return dbKQ;
    }
    private Double GetTienVAT(DataTable dtSRC)
    {
        if (dtSRC == null || dtSRC.Rows.Count == 0) return 0.00;
        double dbKQ = 0;
        for (int i = 0; i < dtSRC.Rows.Count; i++)
        {
            dbKQ += Convert.ToDouble(dtSRC.Rows[i]["TienVAT"]);
        }
        return dbKQ;
    }

    private Double GetTienHang(DataTable dtSRC)
    {
        if (dtSRC == null || dtSRC.Rows.Count == 0) return 0.00;
        double dbKQ = 0;
        for (int i = 0; i < dtSRC.Rows.Count; i++)
        {
            dbKQ += Convert.ToDouble(dtSRC.Rows[i]["TienHang"]);
        }
        return dbKQ;
    }

    public string LoadThanhPham(int imathuoc, int imact)
    {
        string stenvt = mdlCommonFunction.GetValue(conn, "thuoc", "idthuoc", imathuoc, "tenthuoc", "", "", "", "");

        string shtml = "";
        shtml += "<select name=\"ddlVatTu_" + imact + "\" id=\"ddlVatTu_" + imact + "\" style=\"height:19px;width:250px;\">";
        shtml += "<option value=\"" + imathuoc.ToString() + "\" selected=\"selected\"";
        shtml += ">" + stenvt + "</option>";
        shtml += "</select>";
        return shtml;
    }
    public void LoadDanhsachChiTietPhieuNhap()
    {
        if (Session["IdPhieuNhap"] == null || Session["IdPhieuNhap"].ToString() == "")
        {
            Response.Write("");
        }
        string strSQL = "SELECT idchitietphieunhapkho, 0 as STT, ct.idthuoc ";
        strSQL += "         , ct.dongia, ct.soluong, ct.dgsauchietkhau, ct.chietkhau, ct.vat, vt.giabanhientai ";
        strSQL += "         ,(((ct.dgsauchietkhau * ct.vat)/100)+ct.dgsauchietkhau)as giavon ";
        strSQL += "         , vt.tenthuoc ";
        strSQL += "         , vt.donvitinh as tendvt, (((ct.dgsauchietkhau * ct.vat)/100)+ct.dgsauchietkhau)*ct.soluong as ThanhTien, '' as ThanhTien1 ";
        strSQL += "         , (ct.dgsauchietkhau*ct.soluong*ct.vat/100)as TienVAT, (ct.dgsauchietkhau*ct.soluong) as TienHang ";
        strSQL += "         , Isnull(ct.ngayhethan, '') as ngayhethan, hsx.tenhangsanxuat, n.tennhom, ct.losanxuat ";
        strSQL += "FROM chitietphieunhapkho ct LEFT JOIN thuoc vt ON ct.idthuoc = vt.idthuoc ";
        strSQL += "LEFT JOIN hangsanxuat hsx ON vt.idhangsanxuat = hsx.idhangsanxuat ";
        strSQL += "LEFT JOIN nhomthuoc n ON vt.idnhomthuoc = n.idnhomthuoc ";
        strSQL += "WHERE idphieunhap = " + data.ParseInt(Session["IdPhieuNhap"]);
        strSQL += " ORDER BY idchitietphieunhapkho";
        DataTable dtCTPhieu = mdlCommonFunction.LoadDataTable(strSQL, conn);
        double dbTotal = GetTongTien1(dtCTPhieu);
        Double dbTotal1 = dbTotal;
        //ThuanNH 24/05/2010 - Lay tien VAT
        double dbTotal2 = GetTienVAT(dtCTPhieu);
        Double dbTienVAT = dbTotal2;
        //Lay tien hang truoc VAT
        double dbTotal3 = GetTienHang(dtCTPhieu);
        Double dbTienHang = dbTotal3;

        string shtml = "";
        if (dtCTPhieu != null)
        {
            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"item\" width = \"40%\" valign = \"middle\"><b>Tổng thành tiền:&nbsp;</b></td>";
            shtml += "		<td align=\"center\" class=\"item\" width = \"60%\" valign = \"top\"><input id=\"txttong\" type=\"text\" value = \"" + mdlCommonFunction.FormatNumber(dbTotal1, false).ToString() + "\" style=\"width:200px;\"/></td>";
            shtml += "</tr>";
            shtml += "</table>";

            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>	";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">STT</td>	";
            shtml += "      <td align=\"left\" class=\"header\" width = \"15%\" valign = \"top\" style=\"height: 20px\">Nhóm thuốc</td>";
            shtml += "		<td align=\"left\" class=\"header\" width = \"17%\" valign = \"top\" style=\"height: 20px\">Tên thuốc</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">ĐVT</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"6%\" valign = \"top\" style=\"height: 20px\">Lô SX&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">Ngày HH&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"3%\" valign = \"top\" style=\"height: 20px\">SL</td>	";
            shtml += "		<td align=\"center\" class=\"header\" width = \"11%\" valign = \"top\" style=\"height: 20px\">Đơn giá Chưa VAT&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">Mức CK&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"9%\" valign = \"top\" style=\"height: 20px\">Đơn giá sau CK&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"3%\" valign = \"top\" style=\"height: 20px\">VAT&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"9%\" valign = \"top\" style=\"height: 20px\">Thành Tiền&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"7%\" valign = \"top\" style=\"height: 20px\">ĐG Bán&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"8%\" valign = \"top\" style=\"height: 20px\">Lãi/Bán&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"8%\" valign = \"top\" style=\"height: 20px\">Lãi/Vốn&nbsp;</td>";
            shtml += "	</tr>";
            for (int i = 0; i < dtCTPhieu.Rows.Count; i++)
            {
                shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"xoaitemchitiet('" + dtCTPhieu.Rows[i]["idchitietphieunhapkho"].ToString() + "','" + (i + 1).ToString() + "')\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"sua\" value =\"Lưu\" onclick=\"suaitemchitiet('" + dtCTPhieu.Rows[i]["idchitietphieunhapkho"].ToString() + "','" + (i + 1).ToString() + "')\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\">" + (i + 1).ToString() + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"15%\" valign = \"middle\">" + dtCTPhieu.Rows[i]["tennhom"].ToString() + "</td>";
                //shtml += "		<td align=\"left\" class=\"item\" width = \"9%\" valign = \"middle\"><input id=\"txtmavt_" + dtCTPhieu.Rows[i]["idchitietphieunhapkho"].ToString() + "\" type=\"text\" onchange = \"LoadThanhPhamChange(this.value," + dtCTPhieu.Rows[i]["idchitietphieunhapkho"] + ")\" value = \"" + dtCTPhieu.Rows[i]["mathuoc"].ToString() + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"left\" class=\"item\" width = \"17%\" valign = \"middle\"><span id = \"list_" + (i + 1).ToString() + "\">" + LoadThanhPham(data.ParseInt(dtCTPhieu.Rows[i]["idthuoc"]), (i + 1)) + "</span></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\">" + dtCTPhieu.Rows[i]["tendvt"].ToString() + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"6%\" valign = \"middle\">" + dtCTPhieu.Rows[i]["losanxuat"].ToString() + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\">" + Convert.ToDateTime(dtCTPhieu.Rows[i]["ngayhethan"]).ToString("dd/MM/yyyy") + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"3%\" valign = \"middle\"><input id=\"txtsoluong_" + (i + 1).ToString() + "\" type=\"text\" runat = \"server\" style=\"width:20px;\" value = \"" + dtCTPhieu.Rows[i]["soluong"].ToString() + "\"/></td>	";
                shtml += "		<td align=\"center\" class=\"item\" width = \"11%\" valign = \"middle\"><input id=\"txtdongia_" + (i + 1).ToString() + "\" type=\"text\" runat = \"server\" style=\"width:100px;\" value = \"" + string.Format("{0:0,00.00}", data.ParseFloat(dtCTPhieu.Rows[i]["dongia"].ToString())) + "\"  /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\"><input id=\"txtmucck_" + (i + 1).ToString() + "\" type=\"text\" runat = \"server\" style=\"width:30px;\" value = \"" + dtCTPhieu.Rows[i]["chietkhau"] + "\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"9%\" valign = \"middle\">" + string.Format("{0:0,00.00}", data.ParseFloat(dtCTPhieu.Rows[i]["dgsauchietkhau"].ToString())) + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"3%\" valign = \"middle\"><input id=\"txtvat_" + (i + 1).ToString() + "\" type=\"text\" runat = \"server\" style=\"width:20px;\" value = \"" + dtCTPhieu.Rows[i]["vat"] + "\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"9%\" valign = \"middle\">" + string.Format("{0:0,00.00}", data.ParseFloat(dtCTPhieu.Rows[i]["thanhtien"].ToString())) + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"7%\" valign = \"middle\">" + string.Format("{0:0,00.00}", data.ParseFloat(dtCTPhieu.Rows[i]["giabanhientai"].ToString())) + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"8%\" valign = \"middle\">" + Math.Round(((data.ParseFloat(dtCTPhieu.Rows[i]["giabanhientai"].ToString()) - data.ParseFloat(dtCTPhieu.Rows[i]["giavon"].ToString())) / data.ParseFloat(dtCTPhieu.Rows[i]["giabanhientai"].ToString())) * 100, 2) + "%</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"8%\" valign = \"middle\">" + Math.Round(((data.ParseFloat(dtCTPhieu.Rows[i]["giabanhientai"].ToString()) - data.ParseFloat(dtCTPhieu.Rows[i]["giavon"].ToString())) / data.ParseFloat(dtCTPhieu.Rows[i]["giavon"].ToString())) * 100, 2) + "%</td>";
                shtml += "	</tr>";
            }
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" height = \"20\" class=\"item\" colspan = \"16\" width = \"80%\" valign = \"middle\"><b>Tiền hàng: </b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"20%\" valign = \"middle\"><b><input id=\"txttienhang\" type=\"text\" runat = \"server\" style=\"width:100px;\" value = \"" + string.Format("{0:0,00.00}", data.ParseFloat(dbTienHang.ToString())) + "\"  /></b></td>";
            //shtml += "		<td align=\"center\" class=\"item\" width = \"11%\" valign = \"middle\"><input id=\"txttienhang\" type=\"text\" runat = \"server\" style=\"width:100px;\" value = \"" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["dongia"], false).ToString().Trim() + "\"  /></td>";
            shtml += "	</tr>";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" height = \"20\" class=\"item\" colspan = \"16\" width = \"80%\" valign = \"middle\"><b>Tiền VAT: </b></td>";
            //shtml += "		<td align=\"right\" class=\"item\" width = \"20%\" valign = \"middle\"><b>" + mdlCommonFunction.FormatNumber(dbTienVAT, false).ToString() + "</b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"20%\" valign = \"middle\"><b><input id=\"txttienvat\" type=\"text\" runat = \"server\" style=\"width:100px;\" value = \"" + string.Format("{0:0,00.00}", data.ParseFloat(dbTienVAT.ToString())) + "\"  /></b></td>";
            shtml += "	</tr>";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" height = \"20\" class=\"item\" colspan = \"16\" width = \"80%\" valign = \"middle\"><b>Tổng cộng: </b></td>";
            //shtml += "		<td align=\"right\" class=\"item\" width = \"20%\" valign = \"middle\"><b>" + mdlCommonFunction.FormatNumber(dbTotal, false).ToString() + "</b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"20%\" valign = \"middle\"><b><input id=\"txttongtien\" type=\"text\" runat = \"server\" style=\"width:100px;\" value = \"" + string.Format("{0:0,00.00}", data.ParseFloat(dbTotal.ToString())) + "\"  /></b></td>";
            shtml += "	</tr>";
            shtml += "</table>";
            Response.Write(shtml);
        }
        else
        {
            Response.Write("");
        }
    }

    public void LoadChangeThuoc1()
    {
        int sSearch = data.ParseInt(Request.QueryString["strSear"]);
        string strSQL = "SELECT * FROM thuoc ";
        strSQL += "WHERE idthuoc = " + sSearch;
        strSQL += " ORDER BY tenthuoc";
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddlVatTu\" id=\"ddlVatTu\" style=\"height:19px;width:220px;\" runat=\"server\" tabindex=\"10\" onchange = \"SetSanPham()\" >";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + dt.Rows[i]["idthuoc"].ToString() + "\" ";
            //if (dt.Rows[i]["mathuoc"].ToString() == imatp)
            //{
            //    shtml += " selected=\"selected\"";
            //}
            shtml += ">" + dt.Rows[i]["tenthuoc"].ToString() + "</option>";
        }
        shtml += "</select>";
        Response.Write(shtml);
        dt = null;
    }
    private void LoadDanhSachThuoc()
    {
        try
        {
            string tenthuoc = Request.QueryString["tenthuoc"];

            string swhere = "";
            if (tenthuoc != "")
                swhere += " AND tenthuoc LIKE N'" + tenthuoc + "%' OR congthuc LIKE '%" + tenthuoc + "%'";
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";

            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"30%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên thuốc</td>";
            html += "<td width=\"30%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Công thức</td>";
            html += "<td width=\"25%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đường dùng</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đơn vị tính</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đơn giá</td>";
            html += "</tr>";
            string sql = "SELECT *, b.dgsauchietkhau as dongia ";
            sql += "    FROM thuoc a left join (select distinct idthuoc, dgsauchietkhau ";
            sql += "                            from chitietphieunhapkho a ";
            sql += "                            where a.idphieunhap =(select max(idphieunhap) from chitietphieunhapkho where idthuoc=a.idthuoc)";
            sql += "                            )b on a.idthuoc=b.idthuoc";
            sql += "    WHERE 1 =1 " + swhere + " ";
            sql += "    ORDER BY tenthuoc ASC";
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"setChonThuoc(" + h["idthuoc"] + ",'" + h["tenthuoc"] + "','" + h["donvitinh"] + "','" + h["duongdung"] + "')\">";
                html += "<td width=\"30%\" class=\"ptext\" >&nbsp;" + h["tenthuoc"] + "</td>";
                html += "<td width=\"30%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["congthuc"] + "</td>";
                html += "<td width=\"25%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["duongdung"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["donvitinh"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" nowrap = \"nowrap\" >" + h["dongia"] + "</td>";
                html += "</tr>";
            }
            //html += "<tr><td colspan=\"2\"><br/></td></tr>";

            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }

    private void LoadDanhSachThuoc_Jquery()
    {
        try
        {
            string tenthuoc = Request.QueryString["q"];

            string swhere = "";
            if (tenthuoc != "")
                swhere += " AND tenthuoc LIKE N'" + tenthuoc + "%' OR congthuc LIKE '%" + tenthuoc + "%'";
            string html = "";

            html += "|<div style =\"background-color: #4D67A2;height:20px\">";
            html += "<p class=\"item\" style=\"color:white;font-weight:bold;width:30%;float:left\" >Tên thuốc</p>";
            html += "<p class=\"item\" style=\"color:white;font-weight:bold;width:30%;float:left\" >Công thức</p>";
            html += "<p class=\"item\" style=\"color:white;font-weight:bold;width:15%;float:left\" >Đường dùng</p>";
            html += "<p class=\"item\" style=\"color:white;font-weight:bold;width:15%;float:left\" >Đơn vị tính</p>";
            html += "<p class=\"item\" style=\"color:white;font-weight:bold;width:10%;float:left\" >Đơn giá</p>";
            html += "</div>||||";
            html += Environment.NewLine;
            string sql = "SELECT *, b.dgsauchietkhau as dongia ";
            sql += "    FROM thuoc a left join (select distinct idthuoc, dgsauchietkhau ";
            sql += "                            from chitietphieunhapkho a ";
            sql += "                            where a.idphieunhap =(select max(idphieunhap) from chitietphieunhapkho where idthuoc=a.idthuoc)";
            sql += "                            )b on a.idthuoc=b.idthuoc";
            sql += "    WHERE 1 =1 " + swhere + " ";
            sql += "    ORDER BY tenthuoc ASC";
            ArrayList arr = data.SQLMultiHashReader(sql, conn);
            foreach (Hashtable h in arr)
            {
                html += "|<div onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;height:20px\" onclick=\"setChonThuoc(" + h["idthuoc"] + ",'" + h["tenthuoc"] + "','" + h["donvitinh"] + "','" + h["duongdung"] + "')\">";
                html += "<p class=\"ptext\" style=\"width:30%;float:left\">&nbsp;" + h["tenthuoc"] + "</p>";
                html += "<p class=\"ptext\" style=\"width:30%;float:left\" >" + h["congthuc"] + "</p>";
                html += "<p class=\"ptext\" style=\"width:15%;float:left\" >" + h["duongdung"] + "</p>";
                html += "<p class=\"ptext\" style=\"width:15%;float:left\" >" + h["donvitinh"] + "</p>";
                html += "<p class=\"ptext\" style=\"width:10%;float:left\" >" + h["dongia"] + "</p>";
                html += "</div>|"+ h["idthuoc"] + "|" + h["tenthuoc"] + "|" + h["donvitinh"] + "|" + h["duongdung"] ;
                html += Environment.NewLine;
            }
            //html += "<tr><td colspan=\"2\"><br/></td></tr>";

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }

    private void SetTKKho()
    {
        int kho = data.ParseInt(Request.QueryString["kho"]);
        string sql = "Select * From khothuoc where idkho=" + kho;
        DataTable dt = mdlCommonFunction.LoadDataTable(sql, conn);
        if (dt != null && dt.Rows.Count > 0)
        {
            Response.Write(dt.Rows[0]["taikhoankho"].ToString());
        }
        else
            Response.Write("");
    }
    //ThuanNH 21/11/2010
    public void ShowListThuoc()
    {
        int idncc = data.ParseInt(Request.QueryString["idncc"]);
        string strSQL = "SELECT * FROM thuoc WHERE 1 =1 ";
        if (idncc != 0)
            strSQL += " AND nhacungcapid = " + idncc;
        strSQL += " ORDER BY tenthuoc";
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddlVatTu\" id=\"ddlVatTu\" style=\"height:19px;width:250px;\" runat=\"server\" tabindex=\"6\" onchange = \"SetSanPham()\">"; //onchange = \"SetDongia_()\"
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + dt.Rows[i]["idthuoc"].ToString() + "\" ";
            //if (dt.Rows[i]["mathuoc"].ToString() == imatp)
            //{
            //    shtml += " selected=\"selected\"";
            //}
            shtml += ">" + dt.Rows[i]["tenthuoc"].ToString() + "</option>";
        }
        shtml += "</select>";
        Response.Write(shtml);
        dt = null;
    }
    private void editthongtinphieunhap()
    {
        string tkno = Request.QueryString["tkno"];
        string tkco = Request.QueryString["tkco"];
        string tkvat = Request.QueryString["tkvat"];
        string kyhieuhd = Request.QueryString["kyhieuhd"];
        //string sopo = Request.QueryString["sopo"];
        string soct = Request.QueryString["soct"];
        string ngayct = mdlCommonFunction.CheckDate(Request.QueryString["ngayct"]);
        int kho = data.ParseInt(Request.QueryString["kho"]);
        int ncc = data.ParseInt(Request.QueryString["ncc"]);
        string ngayhoadon = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]);
        string sohoadon = Request.QueryString["sohoadon"];
        string diengiai = Request.QueryString["diengiai"];
        int ptn = data.ParseInt(Request.QueryString["ptn"]);

        string sql = "Update phieunhapkho Set";
        sql += " tkno='" + tkno.Trim() + "'";
        sql += ",tkco='" + tkco.Trim() + "'";
        sql += ",tkvat='" + tkvat.Trim() + "'";
        sql += ",kyhieuhoadon='" + kyhieuhd + "'";
        sql += ",maphieunhap='" + soct + "'";
        sql += ",ngaythang='" + ngayct + "'";
        sql += ",idkho=" + kho;
        sql += ",nhacungcapid=" + ncc;
        sql += ",ngayhoadon='" + ngayhoadon + "'";
        sql += ",sohoadon='" + sohoadon + "'";
        sql += ",ghichu=N'" + diengiai + "'";
        sql += ",ptn=" + ptn;
        sql += " WHERE idphieunhap=" + data.ParseInt(Session["MaPhieu"].ToString());
        try
        {
            mdlCommonFunction.Exec(sql, conn);
            Response.Write("Đã cập nhật thành công thông tin phiếu nhập này");
        }
        catch (Exception)
        {
            Response.Write("Có lỗi xãy ra trong quá trình cập nhật dữ liệu.");
        }
    }
    private void LoadDDNCC()
    {
        int idncc = data.ParseInt(Request.QueryString["idncc"]);
        string sql = "Select dinhdanhimei from nhacungcap where nhacungcapid=" + idncc;
        DataTable dt = mdlCommonFunction.LoadDataTable(sql, conn);
        if (dt.Rows.Count > 0)
            Response.Write(dt.Rows[0]["dinhdanhimei"].ToString());
        else
            Response.Write("");
    }

    private void ChonTKNH()
    {
        string sophieu = "";//mdlCommonFunction.CreateIDUNC("UNC", "UyNhiemChi", "SoPhieu", "NH", conn);
        int tknh = data.ParseInt(Request.QueryString["tknh"]);
        string strSQL = "Select SoHieuTKNH, TaiKhoanKT From DanhMucTKNH Where id="+ tknh;
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["TaiKhoanKT"].ToString().Substring(4,2)=="NN")
                sophieu = mdlCommonFunction.CreateIDUNC("UNC", "UyNhiemChi", "SoPhieu", "AGR", conn);
            else if (dt.Rows[0]["TaiKhoanKT"].ToString().Substring(4,2) == "AC")
                sophieu = mdlCommonFunction.CreateIDUNC("UNC", "UyNhiemChi", "SoPhieu", "ACB", conn);
            Response.Write(dt.Rows[0]["SoHieuTKNH"].ToString() + '/' + dt.Rows[0]["TaiKhoanKT"].ToString()+ '/' + sophieu);
        }
        else
            Response.Write("");
    }

    private void LoadDMThuoc1()
    {
        try
        {
            int idncc = data.ParseInt(Request.QueryString["strSear"]);
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"950px\">";
            html += "<tr>";
            html += "<td width=\"100%\" align=\"center\" class=\"item\"><input type=\"button\" name=\"Chon\" value=\"Chọn\" style=\"width:80px;\" id=\"Chon\" onclick=\"ChonSP('chk',checkall.checked, chk.checked);\"/></td> ";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"8\" >DANH SÁCH SẢN PHẨM</td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2;text-align:center;\">";
            html += "<td width=\"60%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên sản phẩm</td>";
            html += "<td width=\"20%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đơn vị tính</td>";
            html += "<td width=\"20%\" class=\"header\" background=\"../images/header.gif\"><input type=\"checkbox\" name=\"checkall\" onclick=\"checkallitem('checkall')\" /></td> ";
            html += "</tr>";
            string strsql = "SELECT distinct b.idsanpham, c.tensanpham, c.donvitinh ";
            strsql += " FROM phieunhapkhosanpham a  join chitietphieunhapkhosanpham b on a.idphieunhap=b.idphieunhap ";
            strsql += "                             join sanpham c on b.idsanpham=c.idsanpham ";
            strsql += " WHERE a.nhacungcapid = " + idncc;
            strsql += " ORDER BY c.tensanpham";
            //ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            //foreach (Hashtable h in arr)
            DataTable dt = mdlCommonFunction.LoadDataTable(strsql, conn);
            if (dt != null && dt.Rows.Count > 0)
            {
                for(int i =0;i<dt.Rows.Count;i++)
                {
                    html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\">";
                    html += "<td width=\"60%\" class=\"ptext\" nowrap = \"nowrap\">" + dt.Rows[i]["tensanpham"].ToString() + "</td>";
                    html += "<td width=\"20%\" class=\"ptext\" nowrap = \"nowrap\">" + dt.Rows[i]["donvitinh"].ToString() + "</td>";
                    html += "<td width=\"20%\" class=\"ptext\" align=\"center\" nowrap = \"nowrap\"><input type=\"checkbox\" id=\"chk_" + (i+1) + "\" value=\"" + dt.Rows[i]["idsanpham"].ToString() + "\" name=\"chk\"/></td>";
                    //html += "<td width=\"60%\" class=\"ptext\" nowrap = \"nowrap\">" + h["tensanpham"] + "</td>";
                    //html += "<td width=\"20%\" class=\"ptext\" nowrap = \"nowrap\">" + h["donvitinh"] + "</td>";
                    //html += "<td width=\"20%\" class=\"ptext\" align=\"center\" nowrap = \"nowrap\"><input type=\"checkbox\" id=" + data.unescape(h["idsanpham"]) + " value=" + data.unescape(h["idsanpham"]) + " name=\"chk\"/></td>";
                    html += "</tr>";
                }
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    //Lay danh muc thuoc
    public void LoadDMThuoc()
    {
        int idkho = data.ParseInt(Request.QueryString["kho"]);
        int idncc = data.ParseInt(Request.QueryString["strSear"]);
        string strSQL = "";
        if (idkho == 1)
        {
            strSQL = "SELECT distinct idsanpham, tensanpham ";
            strSQL += "     FROM (";
            strSQL += "         SELECT idsanpham, tensanpham ";
            strSQL += "         FROM SanPham ";
            strSQL += "         WHERE nhacungcapid = " + idncc;
            strSQL += "         UNION ALL ";
            strSQL += "         SELECT b.idsanpham, c.tensanpham ";
            strSQL += "         FROM phieunhapkhosanpham a  join chitietphieunhapkhosanpham b on a.idphieunhap=b.idphieunhap ";
            strSQL += "                                     join sanpham c on b.idsanpham=c.idsanpham ";
            strSQL += "         WHERE a.nhacungcapid = " + idncc;
            strSQL += "         )A ";
            strSQL += " ORDER BY tensanpham";
        }
        else
        {
            strSQL = "SELECT distinct idsanpham, tensanpham ";
            strSQL += "     FROM (";
            strSQL += "         SELECT idthuoc as idsanpham, tenthuoc as tensanpham ";
            strSQL += "         FROM Thuoc ";
            strSQL += "         WHERE nhacungcapid = " + idncc;
            strSQL += "         UNION ALL ";
            strSQL += "         SELECT b.idthuoc as idsanpham, c.tenthuoc as tensanpham ";
            strSQL += "         FROM phieunhapkho a  join chitietphieunhapkho b on a.idphieunhap=b.idphieunhap ";
            strSQL += "                                     join thuoc c on b.idthuoc=c.idthuoc ";
            strSQL += "         WHERE a.nhacungcapid = " + idncc;
            strSQL += "         )A ";
            strSQL += " ORDER BY tensanpham";
        }
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddlVatTu\" id=\"ddlVatTu\" style=\"height:19px;width:250px;\" runat=\"server\" tabindex=\"10\" onchange=\"SetSanPham()\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + dt.Rows[i]["idsanpham"].ToString() + "\" ";
            shtml += ">" + dt.Rows[i]["tensanpham"].ToString() + "</option>";
        }
        shtml += "</select>";
        Response.Write(shtml);
        dt = null;
    }

    public void TimKiem()
    {
        try
        {
            string html = "";
            string staikhoan = Request.QueryString["taikhoan"];
            string stentaikhoan = Request.QueryString["tentaikhoan"];
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql  = "  SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  WHERE 1=1 ";
            if (staikhoan != "")
                strsql += "  and taikhoan like '" + staikhoan + "%'";
            if (stentaikhoan!="")
                strsql += "  and tentaikhoan like N'%" + stentaikhoan + "%'";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    public void TimKiem1()
    {
        try
        {
            string html = "";
            string staikhoan = Request.QueryString["taikhoan"];
            string stentaikhoan = Request.QueryString["tentaikhoan"];
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem1()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "  SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  WHERE 1=1 ";
            if (staikhoan != "")
                strsql += "  and taikhoan like '" + staikhoan + "%'";
            if (stentaikhoan != "")
                strsql += "  and tentaikhoan like N'%" + stentaikhoan + "%'";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan1('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    public void TimKiem2()
    {
        try
        {
            string html = "";
            string staikhoan = Request.QueryString["taikhoan"];
            string stentaikhoan = Request.QueryString["tentaikhoan"];
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem2()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "  SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  WHERE 1=1 ";
            if (staikhoan != "")
                strsql += "  and taikhoan like '" + staikhoan + "%'";
            if (stentaikhoan != "")
                strsql += "  and tentaikhoan like N'%" + stentaikhoan + "%'";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan2('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    public void TimKiem3()
    {
        try
        {
            string html = "";
            string staikhoan = Request.QueryString["taikhoan"];
            string stentaikhoan = Request.QueryString["tentaikhoan"];
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem3()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "  SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  WHERE 1=1 ";
            if (staikhoan != "")
                strsql += "  and taikhoan like '" + staikhoan + "%'";
            if (stentaikhoan != "")
                strsql += "  and tentaikhoan like N'%" + stentaikhoan + "%'";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan3('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    public void TimKiem4()
    {
        try
        {
            string html = "";
            string staikhoan = Request.QueryString["taikhoan"];
            string stentaikhoan = Request.QueryString["tentaikhoan"];
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem4()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "  SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  WHERE 1=1 ";
            if (staikhoan != "")
                strsql += "  and taikhoan like '" + staikhoan + "%'";
            if (stentaikhoan != "")
                strsql += "  and tentaikhoan like N'%" + stentaikhoan + "%'";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan4('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    public void DanhSachTaiKhoan()
    {
        try
        {
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "   SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch(Exception)
        {
            Response.Write("");
        }
    }
    public void DanhSachTaiKhoan1()
    {
        try
        {
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem1()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "   SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan1('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    public void DanhSachTaiKhoan2()
    {
        try
        {
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem2()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "   SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan2('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    public void DanhSachTaiKhoan3()
    {
        try
        {
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem3()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "   SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan3('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    public void DanhSachTaiKhoan4()
    {
        try
        {
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem4()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "   SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan4('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    public void DanhSachTaiKhoan5()
    {
        try
        {
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH TÀI KHOẢN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"taikhoan\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Tên tài khoản:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"tentaikhoan\" style = \"width: 190\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"TimKiem4()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tài khoản</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên tài khoản</td>";
            html += "<td width=\"7%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chi tiết</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >TK cấp cha</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Cấp</td>";

            html += "</tr>";
            string strsql = "";
            strsql = "   SELECT a.* ";
            strsql += "  FROM DanhMucTK a ";
            strsql += "  ORDER BY a.TaiKhoan ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"ChonTaiKhoan5('" + h["TaiKhoan"] + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["TaiKhoan"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" >" + h["TenTaiKhoan"] + "</td>";
                html += "<td width=\"7%\" class=\"ptext\" >" + h["ChiTiet"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + h["TKCapCha"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["Cap"] + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("");
        }
    }
    //Update chi tiet phieu nhap
    public void LoadSuaUNC()
    {
        string soct = Request.QueryString["soct"];
        string ngayct = mdlCommonFunction.CheckDate1(Request.QueryString["ngayct"]);
        string taikhoannhno = Request.QueryString["taikhoannhno"];
        string diengiai = Request.QueryString["diengiai"];
        string taikhoannh = Request.QueryString["taikhoannh"];
        float sotien = data.ParseFloat(Request.QueryString["sotien"]);
        string strSQL;
        strSQL = " Update UyNhiemChi set ";
        strSQL += " Ngay='" + ngayct + "',";
        strSQL += " TKNHDVTra ='" + taikhoannhno.Trim() + "',";
        strSQL += " TKNHDVNhan ='" + taikhoannh.Trim() + "',";
        strSQL += " NoidungTT =N'" + diengiai.Trim() + "',";
        strSQL += " sotien=" + sotien + "";
        strSQL += " Where SoPhieu = '" + soct.Trim() + "'";
        try
        {
            mdlCommonFunction.Exec(strSQL, conn);
            Response.Write("1");
        }
        catch
        {
            Response.Write("0");
        }
    }
    //ThuanNH 25/05/2010
    private void LoaddanhsachUNC()
    {
        try
        {
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH ỦY NHIỆM CHI</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Số phiếu:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"ssophieu\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Ngày:</td>";
            html += "               <td width=\"45%\" class=\"item\"  ><input type = \"text\" id = \"sngay\" style = \"width:90\">(dd/mm/yyyy)</td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Tên đơn vị trả:</td>";
            html += "               <td width=\"34%\" class=\"item\" ><input type = \"text\" id = \"stendvtra\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\" >Tên đơn vị nhận:</td>";
            html += "               <td width=\"52%\" class=\"item\" ><input type = \"text\" id = \"stendvnhan\" style = \"width: 90\"></td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"SearchHoaDon()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Số UNC</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đơn vị trả</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đơn vị nhận</td>";
            html += "<td width=\"30%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Số tiền</td>";

            html += "</tr>";
            //string snow = mdlCommonFunction.CheckDate(DateTime.Now.ToString("dd/MM/yyyy"));

            string strsql = "";
            strsql = "   SELECT a.*, b.TaiKhoanKT, c.tennhacungcap as TenDVi, c.nhacungcapid as idDonViNhan ";
            strsql += "  FROM UyNhiemChi a  left join DanhMucTKNH b on a.tknhdvnhan=b.id ";
            strsql += "                     left join Nhacungcap c on a.TenDVTra=c.nhacungcapid ";
            strsql += "                     left join Nhacungcap d on a.TenDVNhan=d.tennhacungcap ";
            strsql += "  WHERE SoPhieu not in (Select UNC From tiepnhandoanhthu Where isnull(UNC,'')<>'' and nguoinop=a.TenDVTra)";
            strsql += "  ORDER BY ngay ASC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"SetChonUNC('" + h["TenDVTra"] + "','" + h["TenDVNhan"] + "','" + h["TKNHDVTra"] + "','" + h["TKNHDVNhan"] + "','"+ Convert.ToDouble( h["SoTien"]) +"','"+ h["NoiDungTT"] +"', '"+ h["TaiKhoanKT"] +"', '"+ h["TenDVi"] +"', '"+ h["idDonViNhan"] +"', '"+ h["SoPhieu"] +"')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["SoPhieu"] + "</td>";
                html += "<td width=\"30%\" class=\"ptext\" >&nbsp;" + Convert.ToDateTime(h["ngay"]).ToString("dd/MM/yyyy") + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["TenDVTra"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["TenDVNhan"] + "</td>";
                html += "<td width=\"30%\" class=\"ptext\" >" + mdlCommonFunction.FormatNumber(h["SoTien"],false).ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    //ThuanNH 01/06/2010
    private void Loaddanhsachhoadon1()
    {
        try
        {
            int inccid = data.ParseInt(Request.QueryString["idnhacc"]);
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH HÓA ĐƠN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Số hóa đơn:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"ssohoadon\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Ngày hóa đơn:</td>";
            html += "               <td width=\"45%\" class=\"item\"  ><input type = \"text\" id = \"sngayhoadon\" style = \"width:90\">(dd/mm/yyyy)</td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Số phiếu nhập:</td>";
            html += "               <td width=\"34%\" class=\"item\" ><input type = \"text\" id = \"smaphieunhap\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\" >Ngày nhập:</td>";
            html += "               <td width=\"52%\" class=\"item\" ><input type = \"text\" id = \"sngaythang\" style = \"width: 90\">(dd/mm/yyyy)</td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"SearchHoaDon()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Số hóa đơn</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày hóa đơn</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Số phiếu</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày</td>";
            html += "<td width=\"30%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tổng tiền</td>";

            html += "</tr>";
            //string snow = mdlCommonFunction.CheckDate(DateTime.Now.ToString("dd/MM/yyyy"));

            string strsql = "";
            //Load nhung hoa don/chung tu chi ngoai hoa don
            strsql = "   SELECT sohoadon, ngayhoadon, matiepnhan as maphieunhap, ngaytiepnhan as ngaythang, sotien as conlai ";
            strsql += "  FROM tiepnhandoanhthu ";
            strsql += "  WHERE (donvinhan = " + inccid + " and left(taikhoanno,3) in ('331')) or (donvinhan = " + inccid + " and left(taikhoanco,3) in ('131','141')) ";
            strsql += "         and isnull(taikhoanno,'')<>'' and isnull(taikhoanco,'')<>'' ";
            //strsql += "         and (sohoadon not in (select sohoadon from phieunhapkhosanpham) ";
            //strsql += "              or sohoadon not in (select sohoadon from phieunhapkho)) ";
            strsql += "  UNION ALL ";//can tru
            strsql += "  SELECT sohoadonc, ngayhoadonc, matiepnhan as maphieunhap, ngaytiepnhan as ngaythang, -sotienc as conlai ";
            strsql += "  FROM tiepnhandoanhthu ";
            strsql += "  WHERE (donvinhan = " + inccid + " and left(taikhoanno,3) in ('331')) or (donvinhan = " + inccid + " and left(taikhoanco,3) in ('131','141')) ";
            strsql += "         and isnull(taikhoanno,'')<>'' and isnull(taikhoanco,'')<>'' ";
            strsql += "  UNION ALL ";
            strsql += "  SELECT sohoadon, ngayhoadon, maphieuxuat, ngaythang, sum(round(soluong*dongiavon,0)) as conlai ";
            strsql += "  FROM phieuxuatkhosanpham a join chitietphieuxuatkhosanpham b on a.idphieuxuat=b.idphieuxuat ";
            strsql += "  WHERE iddoituong = " + inccid + "  ";
            strsql += "  GROUP BY sohoadon, ngayhoadon, maphieuxuat, ngaythang ";
            strsql += "  HAVING sum(round(soluong*dongiavon,0))>0 ";

            strsql += "  ORDER BY ngaytiepnhan DESC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                if (h["ngayhoadon"].ToString() != "" && Convert.ToDateTime(h["ngayhoadon"]).ToString("dd/MM/yyyy") != "01/01/1900")
                    html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"SetHoaDon1('" + h["maphieunhap"] + "','" + h["sohoadon"] + "','" + Convert.ToDateTime(h["ngayhoadon"]).ToString("dd/MM/yyyy") + "','" + h["tkno"] + "','" + h["tkco"] + "','" + Convert.ToDouble(h["conlai"]) + "')\">";
                else
                    html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"SetHoaDon1('" + h["maphieunhap"] + "','" + h["sohoadon"] + "','','" + h["tkno"] + "','" + h["tkco"] + "','" + Convert.ToDouble(h["conlai"]) + "')\">";
                if (data.trim( h["sohoadon"]).ToString() == "")
                    html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["maphieunhap"] + "</td>";
                else
                    html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["sohoadon"] + "</td>";
                if (h["ngayhoadon"].ToString() != "")
                    html += "<td width=\"30%\" class=\"ptext\" >&nbsp;" + Convert.ToDateTime(h["ngayhoadon"]).ToString("dd/MM/yyyy") + "</td>";
                else
                    html += "<td width=\"30%\" class=\"ptext\" >&nbsp;</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["maphieunhap"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + Convert.ToDateTime(h["ngaythang"]).ToString("dd/MM/yyyy") + "</td>";
                html += "<td width=\"30%\" class=\"ptext\" >" + mdlCommonFunction.FormatNumber(h["conlai"],false).ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    //Load chi tiet uy nhiem chi
    public void DanhSachUNC(string sMaPN)
    {
        //string strSQL = " SELECT SoPhieu, convert(datetime,Ngay,103)Ngay,  b.SoHieuTKNH as TKNHDVTra, c.SoHieuTKNH as TKNHDVNhan, NoiDungTT, SoTien ";
        string strSQL = " SELECT distinct SoPhieu, convert(datetime,Ngay,103)Ngay, TKNHDVTra, TKNHDVNhan, NoiDungTT, a.SoTien, isnull(b.SoHoaDon,'')SoHoaDon, isnull(NgayHoaDon,'')NgayHoaDon";//b.id as TKNHDVTra, c.id as TKNHDVNhan, NoiDungTT, SoTien ";
        strSQL += " FROM UyNhiemChi a left join TiepNhanDoanhthu b on a.SoPhieu=b.MaTiepNhan and a.sotien=b.sotien ";
        //strSQL += " FROM UyNhiemChi a   left join DanhMucTKNH b on a.TKNHDVTra=b.id ";
        //strSQL += "                     left join DanhMucTKNH c on a.TKNHDVNhan=c.id ";
        if (sMaPN != "")
            strSQL += " Where SoPhieu = '" + sMaPN + "'";
        strSQL += " ORDER BY SoPhieu ";
        DataTable dtCTPhieu = mdlCommonFunction.LoadDataTable(strSQL, conn);
        double dbTotal = GetTongTien(dtCTPhieu);
        Double dbTotal1 = dbTotal;

        string shtml = "";
        if (dtCTPhieu != null)
        {
            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"item\" width = \"43%\" valign = \"middle\"><b>Tổng thành tiền:&nbsp;</b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"60%\" valign = \"top\"><input id=\"txttong\" type=\"text\" value = \"" + mdlCommonFunction.FormatNumber(dbTotal1, false).ToString() + "\" style=\"width:170px;\"/></td>";
            shtml += "</tr>";
            shtml += "</table>";

            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>	";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">STT</td>	";
            shtml += "      <td align=\"center\" class=\"header\" width = \"17%\" valign = \"top\" style=\"height: 20px\">Số phiếu</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">Ngày</td>";
            shtml += "      <td align=\"center\" class=\"header\" width = \"9%\" valign = \"top\" style=\"height: 20px\">Số HĐ</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">Ngày HĐ</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"25%\" valign = \"top\" style=\"height: 20px\">Nội dung thanh toán</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"8%\" valign = \"top\" style=\"height: 20px\">Tài khoản NH nợ</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"8%\" valign = \"top\" style=\"height: 20px\">Tài khoản NH có</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"8%\" valign = \"top\" style=\"height: 20px\">Số tiền</td>";
            shtml += "	</tr>";
            for (int i = 0; i < dtCTPhieu.Rows.Count; i++)
            {
                shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"XoaUNC('" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "', '" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "')\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"sua\" value =\"Sửa\" onclick=\"SuaUNC('" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "','" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "','" + dtCTPhieu.Rows[i]["NoiDungTT"].ToString() + "', '" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["SoTien"], false).ToString() + "')\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\">" + (i + 1).ToString() + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"17%\" valign = \"middle\"><input id=\"txtSoCT_" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\"><input id=\"txtNgay_" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + Convert.ToDateTime(dtCTPhieu.Rows[i]["Ngay"]).ToString("dd/MM/yyyy") + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"25%\" valign = \"middle\"><input id=\"txtSoHoaDon_" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\"><input id=\"txtNgayHoaDon_" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + Convert.ToDateTime(dtCTPhieu.Rows[i]["NgayHoaDon"]).ToString("dd/MM/yyyy") + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"25%\" valign = \"middle\"><input id=\"txtNoiDungTT_" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["NoiDungTT"].ToString() + "\" style=\"width:300px;\"/></td>";
                //shtml += "		<td align=\"center\" class=\"item\" width = \"8%\" valign = \"middle\"><span id = \"list_" + dtCTPhieu.Rows[i]["SoPhieu"] + "\">" + LoadTKNHDVTra(data.ParseInt(dtCTPhieu.Rows[i]["TKNHDVTra"])) + "</span></td>";
                //shtml += "		<td align=\"center\" class=\"item\" width = \"8%\" valign = \"middle\"><span id = \"list_" + dtCTPhieu.Rows[i]["SoPhieu"] + "\">" + LoadTKNHDVNhan(data.ParseInt(dtCTPhieu.Rows[i]["TKNHDVNhan"])) + "</span></td>";
                shtml += "		<td align=\"right\" class=\"item\" width = \"10%\" valign = \"middle\"><input id=\"txtTaiKhoanNHNo_" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["TKNHDVTra"].ToString() + "\" style=\"width:90px;\" /></td>";
                shtml += "		<td align=\"right\" class=\"item\" width = \"9%\" valign = \"middle\"><input id=\"txtTaiKhoanNH_" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "\" type=\"text\"   runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["TKNHDVNhan"].ToString() + "\" style=\"width:90px;\"/></td>	";
                shtml += "		<td align=\"right\" class=\"item\" width = \"8%\" valign = \"middle\"><input id=\"txtSoTien_" + dtCTPhieu.Rows[i]["SoPhieu"].ToString() + "\" type=\"text\"     runat = \"server\" value = \"" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["SoTien"], false).ToString() + "\" align=\"right\" style=\"width:170px;\"/></td>	";
                //" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["sotien"], false).ToString() + "</td>";                
                shtml += "	</tr>";
            }
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" height = \"20px\" class=\"item\" colspan = \"8\" width = \"80%\" valign = \"middle\"><b>Tổng cộng: </b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"20%\" valign = \"middle\"><b>" + mdlCommonFunction.FormatNumber(dbTotal, false).ToString() + "</b></td>";

            shtml += "	</tr>";
            shtml += "</table>";
            Response.Write(shtml);
        }
        else
        {
            Response.Write("0");
        }
    }
    //ThuanNH 25/05/2010
    private void Loaddanhsachhoadon()
    {
        try
        {
            int inccid = data.ParseInt(Request.QueryString["idnhacc"]);
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH HÓA ĐƠN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Số hóa đơn:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"ssohoadon\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Ngày hóa đơn:</td>";
            html += "               <td width=\"45%\" class=\"item\"  ><input type = \"text\" id = \"sngayhoadon\" style = \"width:90\">(dd/mm/yyyy)</td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Số phiếu nhập:</td>";
            html += "               <td width=\"34%\" class=\"item\" ><input type = \"text\" id = \"smaphieunhap\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\" >Ngày nhập:</td>";
            html += "               <td width=\"52%\" class=\"item\" ><input type = \"text\" id = \"sngaythang\" style = \"width: 90\">(dd/mm/yyyy)</td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"SearchHoaDon()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Số hóa đơn</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày hóa đơn</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Số phiếu nhập</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày nhập</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tổng tiền</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đã TT</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Còn lại</td>";

            html += "</tr>";
            //string snow = mdlCommonFunction.CheckDate(DateTime.Now.ToString("dd/MM/yyyy"));
            
            string strsql = "";
            strsql = "   SELECT sohoadon, ngayhoadon, tkno, tkco, maphieunhap, ngaythang, tongtien, isnull(thanhtoan,0)thanhtoan, case when conlai>0 then round(conlai,0) else round(tongtien-isnull(thanhtoan,0),0) end as conlai ";
            strsql += "  FROM phieunhapkhosanpham ";
            strsql += "  WHERE nhacungcapid = " + inccid +" and (case when conlai>0 then conlai else tongtien-isnull(thanhtoan,0) end)>0 ";
            strsql += "  UNION ALL ";
            strsql += "  SELECT a.sohoadon, a.ngayhoadon, a.tkno, a.tkco, a.maphieunhap, a.ngaythang, isnull(tongtien,0)tongtien, isnull(sotien,0)thanhtoan, (tongtien-isnull(sotien,0)) as conlai ";
            strsql += "  FROM ( ";
            strsql += "         SELECT a.sohoadon, a.ngayhoadon, a.tkno, a.tkco, a.maphieunhap, a.ngaythang, tongtien ";
            strsql += "         FROM phieunhapkho a left join tiepnhandoanhthu b on a.sohoadon=b.sohoadon ";
            strsql += "         WHERE a.nhacungcapid = " + inccid ;
            strsql += "         )a LEFT JOIN (SELECT sohoadon, sum(sotien)sotien ";
            strsql += "                 FROM tiepnhandoanhthu ";
            strsql += "                 GROUP BY sohoadon ";
            strsql += "                 )b on a.sohoadon=b.sohoadon ";
            strsql += "  WHERE (tongtien-isnull(sotien,0))>0 ";
            //strsql += "  UNION ALL ";
            //strsql += "  SELECT sohoadon, ngayhoadon, tkno, tkco, maphieuxuat, ngaythang, -sum(round(soluong*dongiavon,0)) as conlai ";
            //strsql += "  FROM phieuxuatkhosanpham a join chitietphieuxuatkhosanpham b on a.idphieuxuat=b.idphieuxuat ";
            //strsql += "  WHERE iddoituong = " + inccid + "  ";
            //strsql += "  GROUP BY sohoadon, ngayhoadon, tkno, tkco, maphieuxuat, ngaythang ";
            //strsql += "  HAVING sum(round(soluong*dongiavon,0))>0 ";
            strsql += "  ORDER BY ngaythang DESC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                if (h["ngayhoadon"].ToString()!="")
                    html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"SetHoaDon('" + h["maphieunhap"] + "','" + h["sohoadon"] + "','" + Convert.ToDateTime(h["ngayhoadon"]).ToString("dd/MM/yyyy") + "','" + h["tkco"] + "','" + (h["conlai"]) + "')\">";
                else
                    html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"SetHoaDon('" + h["maphieunhap"] + "','" + h["sohoadon"] + "','','" + h["tkco"] + "','" + (h["conlai"]) + "')\">";
                if (h["sohoadon"].ToString() == "")
                    html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["maphieunhap"] + "</td>";
                else
                    html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["sohoadon"] + "</td>";
                if (h["ngayhoadon"].ToString() != "")
                    html += "<td width=\"10%\" class=\"ptext\" >&nbsp;" + Convert.ToDateTime(h["ngayhoadon"]).ToString("dd/MM/yyyy") + "</td>";
                else
                    html += "<td width=\"30%\" class=\"ptext\" >&nbsp;</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["maphieunhap"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + Convert.ToDateTime(h["ngaythang"]).ToString("dd/MM/yyyy") + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + mdlCommonFunction.FormatNumber(h["tongtien"], false).ToString() + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + mdlCommonFunction.FormatNumber(h["thanhtoan"], false).ToString() + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + mdlCommonFunction.FormatNumber(h["conlai"],false).ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private void Loadsearchdanhsachhoadon()
    {
        try
        {
            int inccid = data.ParseInt(Request.QueryString["idnhacc"]);
            string ssohoadon= Request.QueryString["sohoadon"];
            string sngayhoadon = Request.QueryString["ngayhoadon"];
            string smaphieunhap = Request.QueryString["maphieunhap"];
            string sngaynhap = Request.QueryString["ngaynhap"];
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >DANH SÁCH HÓA ĐƠN</td>";
            html += "</tr>";
            html += "<tr>";
            html += "   <td width=\"100%\" class=\"item\" style=\"color:white;font-weight:bold;\" colspan = \"5\" >";
            html += "        <table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"100%\">";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Số hóa đơn:</td>";
            html += "               <td width=\"32%\" class=\"item\"><input type = \"text\" id = \"ssohoadon\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\">Ngày hóa đơn:</td>";
            html += "               <td width=\"45%\" class=\"item\"  ><input type = \"text\" id = \"sngayhoadon\" style = \"width:90\">(dd/mm/yyyy)</td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"15%\" class=\"item\">Số phiếu nhập:</td>";
            html += "               <td width=\"34%\" class=\"item\" ><input type = \"text\" id = \"smaphieunhap\" style = \"width: 90\"></td>";
            html += "               <td width=\"15%\" class=\"item\" >Ngày nhập:</td>";
            html += "               <td width=\"52%\" class=\"item\" ><input type = \"text\" id = \"sngaythang\" style = \"width: 90\">(dd/mm/yyyy)</td>";
            html += "           </tr>";
            html += "           <tr>";
            html += "               <td width=\"100%\" class=\"ptext\" style=\"color:white;font-weight:bold; padding-bottom:10px\" colspan = \"4\" align = \"center\" ><input type = \"button\" style = \"width:70\" value = \"Tìm kiếm\" onclick = \"SearchHoaDon()\"></td>";
            html += "           </tr>";
            html += "       </table>";
            html += "   </td>";
            html += "</tr>";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Số hóa đơn</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày hóa đơn</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Số phiếu nhập</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày nhập</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tổng tiền</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đã TT</td>";
            html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Còn lại</td>";

            html += "</tr>";
            //string snow = mdlCommonFunction.CheckDate(DateTime.Now.ToString("dd/MM/yyyy"));

            string strsql = "";
            strsql = "   SELECT sohoadon, ngayhoadon, tkno, tkco, maphieunhap, ngaythang, tongtien, isnull(thanhtoan,0)thanhtoan, case when conlai>0 then conlai else tongtien-isnull(thanhtoan,0) end as conlai ";
            strsql += "  FROM phieunhapkhosanpham ";
            strsql += "  WHERE nhacungcapid = " + inccid + " and (case when conlai>0 then conlai else tongtien-isnull(thanhtoan,0) end)>0 ";
            if (ssohoadon != "")
                strsql += "  and sohoadon like '%" + ssohoadon.Trim() + "%'";
            if (sngayhoadon != "")
                strsql += "  and ngayhoadon='" + mdlCommonFunction.CheckDate(sngayhoadon) + "'";
            if (smaphieunhap!="")
                strsql += "  and maphieunhap like '%" + smaphieunhap.Trim() + "%'";
            if (sngaynhap!= "")
                strsql += "  and ngaythang  ='" + mdlCommonFunction.CheckDate(sngaynhap) + "'";
            strsql += "  ORDER BY ngaythang DESC ";
            ArrayList arr = data.SQLMultiHashReader(strsql, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"SetHoaDon('" + h["sohoadon"] + "','" + Convert.ToDateTime(h["ngayhoadon"]).ToString("dd/MM/yyyy") + "','" + h["tkco"] + "','" + data.ParseFloat(h["conlai"]) + "')\">";
                html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\">" + h["sohoadon"] + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >&nbsp;" + Convert.ToDateTime(h["ngayhoadon"]).ToString("dd/MM/yyyy") + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + h["maphieunhap"] + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" >" + Convert.ToDateTime(h["ngaythang"]).ToString("dd/MM/yyyy") + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + mdlCommonFunction.FormatNumber(h["tongtien"], false).ToString() + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + mdlCommonFunction.FormatNumber(h["thanhtoan"], false).ToString() + "</td>";
                html += "<td width=\"15%\" class=\"ptext\" >" + mdlCommonFunction.FormatNumber(h["conlai"], false).ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private void LoadChiTietThongTinNhaCungCap()
    {
        int khid = data.ParseInt(Request.QueryString["khid"]);
        Session["khid"] = khid;
        Hashtable h = data.SQLHashReader("SELECT * FROM danhmuckhachhang WHERE khachhangid = " + khid, conn);
        string html = "";
        html += "<input type = \"hidden\" name = \"khid\" id = \"khid\" value = \"" + khid.ToString() + "\">";
        html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" id=\"user\">";
        html += "<tr><td colspan=\"2\" class=\"header\" background=\"images/header.gif\">Thêm hoặc cập nhật khách hàng </td></tr>";
        html += "<tr><td colspan=\"2\"><br /></td></tr><tr>";
        html += "<td width=\"20%\" class=\"tieude\">Mã khách hàng (&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;: </td>";
        html += "<td width=\"80%\" id=\"showtipkho\">";
        html += "<input type=\"text\" name=\"makh\" onChange=\"this.value = this.value.toUpperCase();\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["makhachhang"]) + "\"/>";
        html += "&nbsp;(&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc</td></tr><tr>";
        html += "<td width=\"20%\" class=\"tieude\">Tên khách hàng : </td><td width=\"80%\">";
        html += "<input type=\"text\" name=\"tenkh\" style=\"width:400px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["tenkhachhang"]) + "\"/>";
        html += "</td></tr>";
        html += "<tr>";
        html += "<td width=\"20%\" class=\"tieude\">Người liên hệ&nbsp;: </td>";
        html += "<td width=\"80%\" id=\"showtipkho\">";
        html += "<input type=\"text\" name=\"tennguoilienhe\" onChange=\"this.value = this.value.toUpperCase();\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["nguoilienhe"]) + "\"/>";
        html += "</td></tr><tr>";
        html += "<td width=\"20%\" class=\"tieude\">Địa chỉ : </td><td width=\"80%\">";
        html += "<input type=\"text\" name=\"diachi\" style=\"width:400px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["diachi"]) + "\"/>";
        html += "</td></tr><tr>";
        html += "<td width=\"20%\" class=\"tieude\">Điện thoại : </td><td width=\"80%\">";
        html += "<input type=\"text\" name=\"dienthoai\" style=\"width:400px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["dienthoai"]) + "\"/>";
        html += "</td></tr><tr>";
        html += "<td colspan=\"2\" align=\"center\" id=\"functionkho\"><br/>";
        html += "<input type=\"button\" name=\"new\" onclick=\"newkhachhang()\" value=\"Tạo mới\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"luu\" onclick=\"updatekhachhang()\" value=\"Cập nhật\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
        html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletekhachhang('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
        html += "<span class=\"ajax\" id=\"ajaxdanhmuckho\" name=\"ajaxdanhmuckho\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
        html += "</td></tr></table>";
        Response.Write(html);
        html = "";
        h = null;
    }
    private void CheckTrungMaNhaCungCap()
    {
        string mancc = Request.QueryString["manc"];
        int count = data.ParseInt(data.SQLScalar("SELECT count(nhacungcapid) FROM nhacungcap WHERE manhacungcap = '" + mancc + "'", conn));
        Response.Write(count == 0 ? 2 : 1);
    }
    
    //Load thong tin ca
    private void LoadDanhSachCCDC()
    {
        try
        {
            string smaccdc = data.escape(Request.QueryString["maccdc"]);
            Session["macaedit"] = smaccdc;
            Hashtable h = data.SQLHashReader("SELECT * FROM PhanBoCCDC Where maccdc = '" + smaccdc + "' ORDER BY sophieu ASC", conn);
            string html = "";
            html += "<tr><td> ";
            html +="<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" id=\"Table1\">";
            html +="<tr> ";
            html +=" <td colspan=\"2\" class=\"header\" background=\"../images/header.gif\" style=\"height: 10px\"> ";
            html +="            Nhập mới công cụ - dụng cụ</td> ";
            html +="        <td class=\"tieude\" style=\"height: 10px; width: 20%;\"> ";
            html +="            &nbsp;</td> ";
            html +="        <td width=\"80%\" id=\"showtipkho\" style=\"height: 10px\"> ";
            html +="        &nbsp;</td> ";
            html +="    </tr> ";
            html +="<tr> ";
            html +="        <td class=\"tieude\" style=\"height: 26px\" width=\"20%\"> ";
            html +="            Số phiếu:</td> ";
            html +="        <td style=\"height: 26px\" width=\"80%\"> ";
            html += "            <input type=\"text\" id=\"txtSoCT\" class=\"text\" width=\"175px\" value=\"" + data.unescape(h["SoPhieu"]) + "\"/> ";
            html +="        </td> ";
            html +="    </tr> ";
            html +="    <tr> ";
            html +="        <td class=\"tieude\" style=\"height: 26px\" width=\"20%\"> ";
            html +="            Mã công cụ - dụng cụ:</td> ";
            html +="        <td style=\"height: 26px\" width=\"80%\"> ";
            //html += "            <asp:textbox id=\"txtMaCCDC\" runat=\"server\" width=\"175px\" value=\"" + data.unescape(h["MaCCDC"]) + "></asp:textbox> ";
            html += "            <input type=\"text\" id=\"txtMaCCDC\" name=\"txtMaCCDC\" width=\"175px\" value=\"" + data.unescape(h["MaCCDC"]) + "\"/> ";
            html +="            Giá trị phân bổ: ";
            //html +="            <asp:textbox id=\"txtGiaTriPB\" runat=\"server\" width=\"106px\"></asp:textbox> ";
            html += "            <input type=\"text\" id=\"txtGiaTriPB\" width=\"106px\" value=\"" + data.unescape(h["TongGiaTri"]) + "\"/> ";
            html +="        </td> ";
            html +="    </tr> ";
            html +="     <tr> ";
            html +="        <td width=\"20%\" class=\"tieude\" style=\"height: 26px\"> ";
            html +="            Tên công cụ - dụng cụ: ";
            html +="        </td> ";
            html +="        <td width=\"80%\" style=\"height: 26px\"> ";
            //html += "            <asp:textbox id=\"txtTenCCDC\" runat=\"server\" width=\"175px\"></asp:textbox> ";
            html += "            <input type=\"text\" id=\"txtTenCCDC\" name=\"txtTenCCDC\"  width=\"175px\" value=\"" + data.unescape(h["TenCCDC"]) + "\"/> ";
            html +="            Số lần phân bổ: ";
            //html +="            <asp:textbox id=\"txtSoLanPB\" runat=\"server\" width=\"106px\"></asp:textbox> ";
            html +="            <input type=\"text\" id=\"txtSoLanPB\" name=\"txtSoLanPB\" width=\"106px\" value=\"" + data.unescape(h["TongSoLanPB"]) + "\"/> ";
            html +="        </td> ";
            html +="    </tr>                ";
            html +="    <tr> ";
            html +="        <td class=\"tieude\" style=\"height: 24px\" width=\"20%\"> ";
            html += "            Tháng phân bổ: ";
            html +="        </td> ";
            html +="        <td style=\"height: 24px\" width=\"80%\"> ";
            html += "           <input type=\"text\" id=\"txtthang\" name=\"txtthang\" runat=\"server\" width=\"10px\" value=\"" + DateTime.Now.Month + "\"/> ";
            //html += "            <span id = \"ddlThang\" value=\""+ LoadNam() +"\"/></span> ";
            //html +="            <asp:dropdownlist id=\"ddlThang\" runat=\"server\" onchange=\"GetNam();\" AutoPostBack=\"True\" OnSelectedIndexChanged=\"ddlThang_SelectedIndexChanged\"><asp:ListItem>1</asp:ListItem> ";
            //html +="                <asp:ListItem>2</asp:ListItem> ";
            //html +="                <asp:ListItem>3</asp:ListItem> ";
            //html +="                <asp:ListItem>4</asp:ListItem> ";
            //html +="                <asp:ListItem>5</asp:ListItem> ";
            //html +="                <asp:ListItem>6</asp:ListItem> ";
            //html +="                <asp:ListItem>7</asp:ListItem> ";
            //html +="                <asp:ListItem>8</asp:ListItem> ";
            //html +="                <asp:ListItem>9</asp:ListItem> ";
            //html +="                <asp:ListItem>10</asp:ListItem> ";
            //html +="                <asp:ListItem>11</asp:ListItem> ";
            //html +="                <asp:ListItem>12</asp:ListItem> ";
            //html +="                </asp:dropdownlist> ";
            html +="            năm ";
            //html +="            <asp:textbox id=\"txtnam\" runat=\"server\" width=\"175px\"></asp:textbox> ";
            html += "            <input type=\"text\" id=\"txtnam\" runat=\"server\" width=\"175px\" value=\"" + DateTime.Now.Year + "\"/> ";
            html +="            Tài khoản nợ: ";
            //html +="            <asp:textbox id=\"txttaikhoanno\" runat=\"server\" width=\"119px\"></asp:textbox> ";
            html += "            <input type=\"text\" id=\"txttaikhoanno\" name=\"txttaikhoanno\" runat=\"server\" width=\"119px\" value=\"" + data.unescape(h["TaiKhoanNo"]) + "\"/> ";
            html +="            Tài khoản có: ";
            html += "            <input type=\"text\" id=\"txttaikhoanco\" name=\"txttaikhoanco\" runat=\"server\" width=\"119px\" value=\"" + data.unescape(h["TaiKhoanCo"]) + "\"/> ";
            html +="        </td> ";
            html +="    </tr> ";
            html +="    <tr> ";
            html +="        <td class=\"tieude\" style=\"height: 24px\" width=\"20%\"> ";
            html +="            Diễn giải:</td> ";
            html +="        <td id=\"txtdiengiai\" style=\"height: 24px\" width=\"80%\"> ";
            //html +="            <asp:textbox id=\"txtDienGiai\" runat=\"server\" width=\"466px\"></asp:textbox> ";
            html += "            <input type=\"text\" id=\"txtDienGiai\" name=\"txtDienGiai\" runat=\"server\" width=\"466px\" value=\"" + data.unescape(h["DienGiai"]) + "\"/> ";
            html +="        </td> ";
            html +="    </tr> ";
            html +="    <tr> ";
            html +="        <td colspan=\"2\" align=\"center\" id=\"functionkho\"> ";
            html +="            <input type=\"button\" name=\"PhanBo\" onclick=\"{LuuPhanBo('checkall')}\" value=\"Phân bổ CCDC\" style=\"width:112px;\"/>&nbsp;&nbsp; ";
            html +="            <input type=\"button\" name=\"update\" onclick=\"Update();\" value=\"Cập nhật\" style=\"width:80px;\"/> ";
            html +="            &nbsp; ";
            html +="            <input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp; ";
            html +="            <input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deleteCCDC('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp; ";
            html +="            &nbsp; ";
            html +="            <span class=\"ajax\" id=\"ajaxphanbo\" style=\"display:none;\"><img src=\"../images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span> ";
            html +="        </td> ";
            html +="    </tr> ";
            html +="</table>";
            html += "</tr></td> ";

            //html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" id=\"user\">";
            //html += "<tr><td colspan=\"2\" class=\"header\" background=\"../images/header.gif\">Thêm hoặc cập nhật ca mới</td></tr>";
            //html += "<tr><td colspan=\"2\"><br /></td></tr><tr>";
            //html += "<td width=\"20%\" class=\"tieude\">Mã ca (&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;: </td>";
            //html += "<td width=\"80%\" id=\"showtipkho\">";
            //html += "<input type=\"text\" name=\"maca\" id=\"maca\" onChange=\"this.value = this.value.toUpperCase();\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["MaCa"]) + "\"/>";
            //html += "<img src=\"../images/quest.gif\" style=\"cursor:pointer;\" align=\"middle\" title=\"click vào để xem danh sách mã ca\"  onclick=\"showDanhSachCa(0)\"/>";
            //html += "&nbsp;(&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc</td></tr><tr>";
            //html += "<td width=\"20%\" class=\"tieude\">Tên ca : </td><td width=\"80%\">";
            //html += "<input type=\"text\" name=\"tenca\" id=\"tenca\" style=\"width:400px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["TenCa"]) + "\"/>";
            //html += "<span class=\"ajax\" id=\"ajaxca\" style=\"display:none;\">";
            //html += "<img src=\"images/processing.gif\" border=\"0\" align=\"absmiddle\" />&nbsp;&nbsp;kiểm tra mã ca...";
            //html += "</span></td></tr>";
            ////ThuanNH 04/05/2010

            //html += "<tr><td width=\"20%\" class=\"tieude\">Thời gian bắt đầu (&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;: </td><td width=\"80%\">";
            //html += "<input type=\"text\" name=\"thoigianbd\" id=\"thoigianbd\" style=\"width:120px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["ThoiGianBD"]) + "\"/>";
            //html += "</tr>";
            //html += "<tr><td width=\"20%\" class=\"tieude\">Thời gian kết thúc (&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;: </td><td width=\"80%\">";
            //html += "<input type=\"text\" name=\"thoigiankt\" id=\"thoigiankt\" style=\"width:120px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["ThoiGianKT"]) + "\"/>";
            //html += "</tr>";
            ////------------------
            //html += "<tr><td colspan=\"2\" align=\"center\" id=\"functionkho\"><br/>";
            //html += "<input type=\"button\" name=\"new\" onclick=\"newca()\" value=\"Tạo mới\" style=\"width:80px;\"/>&nbsp;&nbsp;";
            //html += "<input type=\"button\" name=\"luu\" onclick=\"saveupdateca()\" value=\"Cập nhật\" style=\"width:80px;\"/>&nbsp;&nbsp;";
            //html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
            //html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletekho('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
            //html += "<span class=\"ajax\" id=\"ajaxdanhmucca\" style=\"display:none;\"><img src=\"../images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
            //html += "</td></tr></table>";
            Response.Write(html);
            html = "";
            h = null;

        }
        catch (Exception)
        {
            Response.Write("error");
        }
    } 
    public void LoadNam()
    {

    }
    //Update chi tiet phieu nhap
    public void SuaThuChiTM()
    {
        string sophieu = Request.QueryString["sophieu"];
        Double sotien= Convert.ToDouble(Request.QueryString["sotien"].Replace(".","").ToString());
        string sohoadon = Request.QueryString["sohoadon"];
        object ngayhoadon = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]);
        string taikhoanno = Request.QueryString["taikhoanno"];
        string taikhoanco = Request.QueryString["taikhoanco"];
        string nguoinop = Request.QueryString["nguoinop"];
        string strSQL;
        strSQL = " Update TiepNhanDoanhThu set ";
        strSQL += " NgayHoaDon='" + ngayhoadon + "',";
        strSQL += " TaiKhoanNo='" + taikhoanno.Trim() + "',";
        strSQL += " TaiKhoanCo='" + taikhoanco.Trim() + "',";
        if (nguoinop.Trim() != "" && nguoinop != "undefined")
        {
            strSQL += " NguoiNop='" + nguoinop.Trim() + "',";
            if (sophieu.Substring(0, 2) == "PT")
                strSQL += " donvinop='" + nguoinop.Trim() + "', ";
            else
                strSQL += " donvinhan='" + nguoinop.Trim() + "', ";
        }
        strSQL += " sotien=" + sotien + "";
        strSQL += " Where matiepnhan = '"+ sophieu.Trim() +"'";
        strSQL += "       and SoHoaDon='" + sohoadon.Trim() + "'";
        strSQL += "       and TaiKhoanNo='" + taikhoanno.Trim() + "'";
        try
        {
            mdlCommonFunction.Exec(strSQL, conn);
            strSQL = "Select ngaytiepnhan From tiepnhandoanhthu ";
            strSQL += " Where matiepnhan = '" + sophieu.Trim() + "'";
            strSQL += "       and SoHoaDon='" + sohoadon.Trim() + "'";
            strSQL += "       and TaiKhoanNo='" + taikhoanno.Trim() + "'";
            DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
            if (dt!=null&&dt.Rows.Count>0)
                DanhSachThuChi(sophieu.Trim(),dt.Rows[0]["ngaytiepnhan"].ToString());
            //Response.Write("1");
        }
        catch
        {
            Response.Write("0");
        }
    }
    //Delete thu chi TM
    public void XoaThuChiTM()
    {
        string strSoPhieu = (Request.QueryString["mactp"]);
        string strSoHD = Request.QueryString["sohoadon"];
        double dblSoTien = Convert.ToDouble(Request.QueryString["sotien"]);
        int inguoinop = data.ParseInt(Request.QueryString["nguoinop"]);
        clsTiepNhanDoanhThu cls = new clsTiepNhanDoanhThu();
        cls.MaTiepNhan = strSoPhieu;
        try
        {
            //cls.DeleteTiepNhanDoanhThu(conn);
            string strSQL = "Delete TiepNhanDoanhThu Where matiepnhan='" + cls.MaTiepNhan + "' and sohoadon='" + strSoHD + "' and sotien="+ dblSoTien +"";
            mdlCommonFunction.Exec(strSQL, conn);
            //ThuanNH 25/05/2010 - Update table Phieunhapkhosanpham (cap nhat so tien thanh toan)
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         thanhtoan=isnull(thanhtoan,0)- "+ dblSoTien;
            strSQL += " Where nhacungcapid=" + inguoinop + " and sohoadon='" + strSoHD.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
            strSQL += " Where nhacungcapid=" + inguoinop + " and sohoadon='" + strSoHD.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            strSQL = "Select ngaytiepnhan From Tiepnhandoanhthu Where matiepnhan='" + cls.MaTiepNhan + "' and sohoadon='" + strSoHD + "' and sotien=" + dblSoTien + "";
            DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
            if (dt!=null&&dt.Rows.Count>0)
                DanhSachThuChi(cls.MaTiepNhan,dt.Rows[0]["ngaytiepnhan"].ToString());
            Session["MaPhieu"] = null;
            //Response.Redirect("ThuChiHoaDonTM1.aspx");
        }
        catch
        {
            Response.Write("0");
        }
    }
    
    //Delete Uy nhiem chi
    public void XoaUNC()
    {
        string strSoPhieu= (Request.QueryString["sophieu"]);
        string strSoHoaDon= (Request.QueryString["sohoadon"]);
        try
        {
            string strSQL;
            ////1. xoa table uyNhiemChi
            //strSQL = "Delete UyNhiemChi Where SoPhieu='" + strSoPhieu + "'";
            //mdlCommonFunction.Exec(strSQL, conn);
            //2. update table phieunhapkhosanpham
            strSQL = "Select donvinhan, sohoadon, sotien From TiepNhanDoanhThu Where matiepnhan='"+ strSoPhieu +"' and SoHoaDon='"+ data.trim(strSoHoaDon) +"'";
            DataTable dt= mdlCommonFunction.LoadDataTable(strSQL, conn);
            if (dt.Rows.Count > 0)
            {
                strSQL = " Update phieunhapkhosanpham set ";
                strSQL += "         thanhtoan=isnull(thanhtoan,0)- " + Convert.ToDouble(dt.Rows[0]["sotien"]);
                strSQL += " Where nhacungcapid=" + dt.Rows[0]["donvinhan"] + " and sohoadon='" + data.trim(dt.Rows[0]["sohoadon"].ToString()) + "'";
                mdlCommonFunction.Exec(strSQL, conn);
                strSQL = " Update phieunhapkhosanpham set ";
                strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
                strSQL += " Where nhacungcapid=" + dt.Rows[0]["donvinhan"] + " and sohoadon='" + data.trim(dt.Rows[0]["sohoadon"].ToString()) + "'";
                mdlCommonFunction.Exec(strSQL, conn);

                //Update sotien
                //mdlCommonFunction.Exec("Update UyNhiemChi Set SoTien=SoTien-"+ Convert.ToDouble(dt.Rows[0]["sotien"]) +" Where SoPhieu='"+ strSoPhieu +"'", conn);
                //1. xoa table uyNhiemChi
                strSQL = "Delete UyNhiemChi Where SoPhieu='" + strSoPhieu + "' and SoTien="+ dt.Rows[0]["sotien"] +" ";
                mdlCommonFunction.Exec(strSQL, conn);
                //3. xoa TiepNhanDoanhThu
                strSQL = "Delete TiepNhanDoanhThu Where matiepnhan='" + strSoPhieu + "' and SoHoaDon='"+ data.trim(dt.Rows[0]["sohoadon"].ToString()) +"'";
                mdlCommonFunction.Exec(strSQL, conn);
            }
            //Response.Write("1");
            DanhSachUNC(strSoPhieu);
        }
        catch
        {
            Response.Write("0");
        }
    }
    //Delete Uy nhiem chi
    public void SuaUNC()
    {
        string strSoPhieu = (Request.QueryString["sophieu"]);
        string strnoidungtt = (Request.QueryString["noidungtt"]);
        string strSoHoaDon = (Request.QueryString["sohoadon"]);
        double sotien = Convert.ToDouble(Request.QueryString["sotien"].Replace(".", "").ToString());  
        try
        {
            string strSQL;
            //cap nhat uy nhiem chi
            strSQL = "Update UyNhiemChi set noidungtt=N'"+ strnoidungtt +"', sotien="+ sotien +" ";
            strSQL += "Where SoPhieu='" + strSoPhieu + "' and isnull(SoHoaDon,'')='"+ strSoHoaDon.Trim() +"' ";
            mdlCommonFunction.Exec(strSQL, conn);
            //cap nhat tra tien
            strSQL = "Update Tiepnhandoanhthu set sotien=" + sotien + " where matiepnhan='" + strSoPhieu + "' and isnull(SoHoaDon,'')='" + strSoHoaDon.Trim() + "' ";
            mdlCommonFunction.Exec(strSQL, conn);
            //Response.Write("1");
            DanhSachUNC(strSoPhieu);
        }
        catch
        {
            Response.Write("0");
        }
    }
    public string LoadTKNHDVTra(int idTKNH)
    {
        string strSQL = " SELECT b.id, b.SoHieuTKNH as TKNHDVTra ";//SoPhieu, convert(datetime,Ngay,103)Ngay,  b.SoHieuTKNH as TKNHDVTra, c.SoHieuTKNH as TKNHDVNhan, NoiDungTT, SoTien ";
        strSQL += " FROM UyNhiemChi a   left join DanhMucTKNH b on a.TKNHDVTra=b.id ";
        //strSQL += "                     left join DanhMucTKNH c on a.TKNHDVNhan=c.id ";
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddlTKNHDVTra_" + idTKNH + "\" id=\"ddlTKNHDVTra_" + idTKNH + "\" style=\"height:19px;width:250px;\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + data.ParseInt(dt.Rows[i]["id"]) + "\" ";
            if (data.ParseInt(dt.Rows[i]["id"]) == idTKNH)
            {
                shtml += " selected=\"selected\"";
            }
            shtml += ">" + dt.Rows[i]["TKNHDVTra"].ToString() + "</option>";
        }
        shtml += "</select>";
        return shtml;
        dt = null;
    }

    public string LoadTKNHDVNhan(int idTKNH)
    {
        string strSQL = " SELECT b.id, b.SoHieuTKNH as TKNHDVNhan ";//SoPhieu, convert(datetime,Ngay,103)Ngay,  b.SoHieuTKNH as TKNHDVTra, c.SoHieuTKNH as TKNHDVNhan, NoiDungTT, SoTien ";
        strSQL += " FROM UyNhiemChi a   left join DanhMucTKNH b on a.TKNHDVNhan=b.id ";
        //strSQL += "                     left join DanhMucTKNH c on a.TKNHDVNhan=c.id ";
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddlTKNHDVNhan_" + idTKNH + "\" id=\"ddlTKNHDVNhan_" + idTKNH + "\" style=\"height:19px;width:250px;\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + data.ParseInt(dt.Rows[i]["id"]) + "\" ";
            if (data.ParseInt(dt.Rows[i]["id"]) == idTKNH)
            {
                shtml += " selected=\"selected\"";
            }
            shtml += ">" + dt.Rows[i]["TKNHDVNhan"].ToString() + "</option>";
        }
        shtml += "</select>";
        return shtml;
        dt = null;
    }
    private Double GetTongTien(DataTable dtSRC)
    {
        if (dtSRC == null || dtSRC.Rows.Count == 0) return 0.00;
        double dbKQ = 0;
        for (int i = 0; i < dtSRC.Rows.Count; i++)
        {
            dbKQ += Math.Round(Convert.ToDouble(dtSRC.Rows[i]["sotien"]), 0);
        }
        return dbKQ;
    }
    //Load danh sach thu chi tien mat
    public void DanhSachThuChi(string sMaPN, string Ngayct)
    {
        string strSQL = " SELECT * ";
        strSQL += " FROM tiepnhandoanhthu ";
        strSQL += " WHERE (TaiKhoanNo like '111%' or TaiKhoanCo like '111%') ";
        strSQL += "         and isnull(sohoadon,'')<>'' ";
        if (sMaPN != "")
            strSQL += "and matiepnhan = '"+ sMaPN +"' and ngaytiepnhan='"+ Ngayct +"'";
        strSQL += " ORDER BY matiepnhan ";
        DataTable dtCTPhieu = mdlCommonFunction.LoadDataTable(strSQL, conn);
        double dbTotal = GetTongTien(dtCTPhieu);
        Double dbTotal1 = dbTotal;

        string shtml = "";
        if (dtCTPhieu != null)
        {
            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"item\" width = \"43%\" valign = \"middle\"><b>Tổng thành tiền:&nbsp;</b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"60%\" valign = \"top\"><input id=\"txttong\" type=\"text\" value = \"" + mdlCommonFunction.FormatNumber(dbTotal1, false).ToString() + "\" style=\"width:170px;\"/></td>";
            shtml += "</tr>";
            shtml += "</table>";

            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>	";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">STT</td>	";
            shtml += "      <td align=\"center\" class=\"header\" width = \"15%\" valign = \"top\" style=\"height: 20px\">Số hóa đơn</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">Ngày hóa đơn</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"14%\" valign = \"top\" style=\"height: 20px\">KH/NCC</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"10%\" valign = \"top\" style=\"height: 20px\">Tài khoản nợ</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"9%\" valign = \"top\" style=\"height: 20px\">Tài khoản có</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"15%\" valign = \"top\" style=\"height: 20px\">Số tiền</td>";
            shtml += "	</tr>";
            for (int i = 0; i < dtCTPhieu.Rows.Count; i++)
            {
                shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"XoaThuChiTM('"+ (i+1).ToString() +"', '" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "', '" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "', " + dtCTPhieu.Rows[i]["sotien"] + ", '" + dtCTPhieu.Rows[i]["nguoinop"] + "')\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"sua\" value =\"Lưu\" onclick=\"SuaThuChiTM('" + (i + 1).ToString() + "', '" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "', '" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "')\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\">" + (i + 1).ToString() + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"15%\" valign = \"middle\"><input id=\"txtSoHoaDon_" + (i + 1).ToString() + "\" type=\"text\"   runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\"><input id=\"txtNgayHoaDon_" + (i + 1).ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + Convert.ToDateTime(dtCTPhieu.Rows[i]["NgayHoaDon"]).ToString("dd/MM/yyyy") + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"14%\" valign = \"middle\"><span id = \"list_" + (i + 1).ToString() + "\">" + LoadNCC(data.ParseInt(dtCTPhieu.Rows[i]["nguoinop"]), dtCTPhieu.Rows[i]["matiepnhan"].ToString()) + "</span></td>";
                shtml += "		<td align=\"right\" class=\"item\" width = \"10%\" valign = \"middle\"><input id=\"txtTaiKhoanNo_" + (i + 1).ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["TaiKhoanNo"].ToString() + "\" style=\"width:90px;\" /></td>";
                shtml += "		<td align=\"right\" class=\"item\" width = \"9%\" valign = \"middle\"><input id=\"txtTaiKhoanCo_" + (i + 1).ToString() + "\" type=\"text\"   runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["TaiKhoanCo"].ToString() + "\" style=\"width:90px;\"/></td>	";
                shtml += "		<td align=\"right\" class=\"item\" width = \"12%\" valign = \"middle\"><input id=\"txtSoTien_" + (i + 1).ToString() + "\" type=\"text\"      runat = \"server\" value = \"" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["sotien"], false).ToString() + "\" align=\"right\" style=\"width:170px;\"/></td>	";
                //" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["sotien"], false).ToString() + "</td>";                
                shtml += "	</tr>";
            }
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" height = \"20px\" class=\"item\" colspan = \"8\" width = \"80%\" valign = \"middle\"><b>Tổng cộng: </b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"20%\" valign = \"middle\"><b>" + mdlCommonFunction.FormatNumber(dbTotal, false).ToString() + "</b></td>";

            shtml += "	</tr>";
            shtml += "</table>";
            Response.Write(shtml);
        }
        else
        {
            Response.Write("");
        }
    }

    public void DanhSachThuChiNH(string sMaPN)
    {
        string strSQL = " SELECT * ";
        strSQL += " FROM tiepnhandoanhthu ";
        strSQL += " WHERE (TaiKhoanNo like '112%' or TaiKhoanCo like '112%') ";
        strSQL += "         and isnull(sohoadon,'')<>'' ";
        if (sMaPN != "")
            strSQL += " and matiepnhan = '" + sMaPN + "'";
        strSQL += " ORDER BY matiepnhan ";
        DataTable dtCTPhieu = mdlCommonFunction.LoadDataTable(strSQL, conn);
        double dbTotal = GetTongTien(dtCTPhieu);
        Double dbTotal1 = dbTotal;

        string shtml = "";
        if (dtCTPhieu != null)
        {
            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"item\" width = \"43%\" valign = \"middle\"><b>Tổng thành tiền:&nbsp;</b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"60%\" valign = \"top\"><input id=\"txttong\" type=\"text\" value = \"" + mdlCommonFunction.FormatNumber(dbTotal1, false).ToString() + "\" style=\"width:170px;\"/></td>";
            shtml += "</tr>";
            shtml += "</table>";

            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>	";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">STT</td>	";
            shtml += "      <td align=\"center\" class=\"header\" width = \"15%\" valign = \"top\" style=\"height: 20px\">Số hóa đơn</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">Ngày hóa đơn</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"14%\" valign = \"top\" style=\"height: 20px\">KH/NCC</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"10%\" valign = \"top\" style=\"height: 20px\">Tài khoản nợ</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"9%\" valign = \"top\" style=\"height: 20px\">Tài khoản có</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"15%\" valign = \"top\" style=\"height: 20px\">Số tiền</td>";
            shtml += "	</tr>";
            for (int i = 0; i < dtCTPhieu.Rows.Count; i++)
            {
                shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"XoaThuChiTM('" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "', '" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "', " + dtCTPhieu.Rows[i]["sotien"] + ", " + dtCTPhieu.Rows[i]["nguoinop"] + ")\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"sua\" value =\"Sửa\" onclick=\"SuaThuChiTM('" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "', '" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "')\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\">" + (i + 1).ToString() + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"15%\" valign = \"middle\"><input id=\"txtSoHoaDon_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\"><input id=\"txtNgayHoaDon_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + Convert.ToDateTime(dtCTPhieu.Rows[i]["NgayHoaDon"]).ToString("dd/MM/yyyy") + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"left\" class=\"item\" width = \"17%\" valign = \"middle\"><span id = \"list_" + dtCTPhieu.Rows[i]["matiepnhan"] + "\">" + LoadNCC(data.ParseInt(dtCTPhieu.Rows[i]["nguoinop"]), dtCTPhieu.Rows[i]["matiepnhan"].ToString()) + "</span></td>";
                //shtml += "		<td align=\"center\" class=\"item\" width = \"14%\" valign = \"middle\"><input id=\"txtnguoinop_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"   runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["nguoinop"].ToString() + "\" style=\"width:140px;\"/></td>";
                shtml += "		<td align=\"right\" class=\"item\" width = \"10%\" valign = \"middle\"><input id=\"txtTaiKhoanNo_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["TaiKhoanNo"].ToString() + "\" style=\"width:90px;\" /></td>";
                shtml += "		<td align=\"right\" class=\"item\" width = \"9%\" valign = \"middle\"><input id=\"txtTaiKhoanCo_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"   runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["TaiKhoanCo"].ToString() + "\" style=\"width:90px;\"/></td>	";
                shtml += "		<td align=\"right\" class=\"item\" width = \"12%\" valign = \"middle\"><input id=\"txtSoTien_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"     runat = \"server\" value = \"" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["sotien"], false).ToString() + "\" align=\"right\" style=\"width:170px;\"/></td>	";
                //" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["sotien"], false).ToString() + "</td>";                
                shtml += "	</tr>";
            }
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" height = \"20px\" class=\"item\" colspan = \"8\" width = \"80%\" valign = \"middle\"><b>Tổng cộng: </b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"20%\" valign = \"middle\"><b>" + mdlCommonFunction.FormatNumber(dbTotal, false).ToString() + "</b></td>";

            shtml += "	</tr>";
            shtml += "</table>";
            Response.Write(shtml);
        }
        else
        {
            Response.Write("error");
        }
    }

    public string LoadNCC(int inguoinop, string smaphieu)
    {
        string strSQL = "SELECT * FROM nhacungcap ";
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddlncc1_" + smaphieu + "\" id=\"ddlncc1_" + smaphieu + "\" style=\"height:19px;width:250px;\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<option value=\"" + data.ParseInt(dt.Rows[i]["nhacungcapid"]) + "\" ";
            if (data.ParseInt(dt.Rows[i]["nhacungcapid"]) == inguoinop)
            {
                shtml += " selected=\"selected\"";
                shtml += ">" + dt.Rows[i]["tennhacungcap"].ToString() + "</option>";
                shtml += " selected=\"\">";
                shtml += "</option>";
            }
            //shtml += "<option value=\"" + data.ParseInt(dt.Rows[i]["nhacungcapid"]) + "\" ";
            //if (data.ParseInt(dt.Rows[i]["nhacungcapid"]) == inguoinop)
            //{
            //    shtml += " selected=\"selected\"";
            //}
            //shtml += ">" + dt.Rows[i]["tennhacungcap"].ToString() + "</option>";
        }
        shtml += "</select>";
        return shtml;
        dt = null;

        //string stenncc = mdlCommonFunction.GetValue(conn, "nhacungcap", "nhacungcapid", inguoinop, "tennhacungcap", "", "", "", "");

        //string shtml = "";
        //shtml += "<select name=\"ddlncc1_" + smaphieu + "\" id=\"ddlncc1_" + smaphieu + "\" style=\"height:19px;width:250px;\">";
        //shtml += "<option value=\"" + inguoinop.ToString() + "\" selected=\"selected\"";
        //shtml += ">" + stenncc + "</option>";
        //shtml += "</select>";
        //return shtml;
    }

    public void LuuUyNhiemChi()
    {
        int pxid = data.ParseInt(Request.QueryString["Pxid"]);//-1: Them moi; 1: Chinh sua, cap nhat
        string soct = Request.QueryString["soct"];
        string ngayct = mdlCommonFunction.CheckDate1(Request.QueryString["ngayct"]);
        string inhacc = Request.QueryString["nccid"];
        string sdvnhan = Request.QueryString["dvnhan"];
        string taikhoannhno = Request.QueryString["taikhoannhno"];
        string diengiai = Request.QueryString["diengiai"];
        string taikhoannh = Request.QueryString["taikhoannh"];
        string taikhoanno = Request.QueryString["taikhoanno"];
        string taikhoanco = Request.QueryString["taikhoanco"];
        string sohoadon = Request.QueryString["sohoadon"];
        string ngayhoadon = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]);
        int vat= data.ParseInt(Request.QueryString["VAT"]);
        float tienvat = data.ParseFloat(Request.QueryString["TienVAT"]);
        string taikhoanvat = Request.QueryString["TaiKhoanVAT"];
        string loaitien = Request.QueryString["LoaiTien"];
        Double tygia = Convert.ToDouble(Request.QueryString["TyGia"]);
        if (tygia == 0) tygia = 1;
        //ThuanNH 25/02/2011
        float ck = data.ParseFloat(Request.QueryString["CK"]);
        float tienck = data.ParseFloat(Request.QueryString["TienCK"]);
        string taikhoanck = Request.QueryString["TaiKhoanCK"];

        Double sotien = Convert.ToDouble(Request.QueryString["sotien"]);
        string strSQL = "";
        string Userid = "";
        string UserName = "";
        string Userhost = Request.UserHostAddress.ToString();
        string sql2 = "Select a.*,b.tennguoidung From NguoiDung_Host a join NguoiDung b on a.idnguoidung=b.idnguoidung Where a.IdClient='" + Userhost.Trim() + "'";
        DataTable dt1 = mdlCommonFunction.LoadDataTable(sql2, conn);
        if (dt1 != null && dt1.Rows.Count > 0)//neu ton tai nguoi dung & IP -> Khong lam gi het!
        {
            Userid = dt1.Rows[0]["idnguoidung"].ToString();
            UserName = dt1.Rows[0]["tennguoidung"].ToString();
        }
        //if (Session["idnguoidung"] == null)
        //    Response.Redirect("../login.aspx");
        strSQL = " Select * From UyNhiemChi ";
        strSQL += " Where SoPhieu='" + soct.Trim() + "'";
        DataTable dtSRC = mdlCommonFunction.LoadDataTable(strSQL, conn);
        if (dtSRC.Rows.Count > 0 && pxid == -1 && mdlCommonFunction.CheckExist(conn, "UyNhiemChi", "SoPhieu", soct.Trim(), "Ngay", ngayct.Trim(), "", "", "", ""))
        {
            Response.Write(0);
            return;
        }
        try
        {
            //Xoa UNC (neu ton tai)
            mdlCommonFunction.Exec("Delete UyNhiemChi Where SoPhieu='" + soct.Trim() + "' and SoHoaDon='" + sohoadon.Trim() + "'", conn);
            //1. Insert thong tin uy nhiem chi
            strSQL = "  INSERT INTO [UyNhiemChi]([SoPhieu], [Ngay], [TenDVTra], [TKNHDVTra], [NganHangTra], [TenDVNhan], [TKNHDVNhan], [NganHangNhan], [SoTien], [SoHoaDon], [NoiDungTT]) ";
            strSQL += "     VALUES( ";
            strSQL += "     '" + soct.Trim() + "',";
            strSQL += "     '" + ngayct.Trim() + "',";
            strSQL += "     '" + inhacc.Trim() + "',";
            strSQL += "     '" + taikhoannhno.Trim() + "',";
            strSQL += "     '',";
            strSQL += "     '" + sdvnhan.Trim() + "',";
            strSQL += "     '" + taikhoannh.Trim() + "',";
            strSQL += "     '',";
            strSQL += "     " + (sotien+tienvat+tienck) + ",";
            strSQL += "     '" + sohoadon.Trim() + "',";//Thuan 26/01/2011
            strSQL += "     N'" + diengiai.Trim() + "'";
            strSQL += "     )";
            mdlCommonFunction.Exec(strSQL, conn);
            
            //2. Insert thong tin thu chi ngan hang
            strSQL = "  INSERT INTO [TiepNhanDoanhThu]([matiepnhan], [ngaytiepnhan], [nguoitiepnhan], [taikhoannh], [taikhoanno], [taikhoanco], [nguoinop], [donvinop], [donvinhan], [bophannop], [sohoadon], [ngayhoadon], [SoTien], [ghichu]) ";
            strSQL += "     VALUES( ";
            strSQL += "     '" + soct.Trim() + "',";
            strSQL += "     '" + ngayct.Trim() + "',";
            strSQL += "     '',";
            strSQL += "     '" + taikhoannhno.Trim() + "',";
            strSQL += "     '" + taikhoanno.Trim() + "',";
            strSQL += "     '" + taikhoanco.Trim() + "',";
            strSQL += "     '" + inhacc.Trim() + "',";
            strSQL += "     '" + inhacc.Trim() + "',";
            strSQL += "     '" + sdvnhan.Trim() + "',";
            strSQL += "     '',";
            strSQL += "     '" + sohoadon.Trim() + "',";
            strSQL += "     '" + ngayhoadon.Trim() + "',";
            strSQL += "     " + sotien + ",";
            strSQL += "     N'" + diengiai.Trim() + "'";
            strSQL += "     )";
            mdlCommonFunction.Exec(strSQL, conn);
            
            //Insert VAT
            if (tienvat > 0 & taikhoanvat.Trim()!="")
            {
                strSQL = "  INSERT INTO [TiepNhanDoanhThu]([matiepnhan], [ngaytiepnhan], [nguoitiepnhan], [taikhoannh], [taikhoanno], [taikhoanco], [nguoinop], [donvinop], [donvinhan], [bophannop], [sohoadon], [ngayhoadon], [vat], [SoTien], [ghichu]) ";
                strSQL += "     VALUES( ";
                strSQL += "     '" + soct.Trim() + "',";
                strSQL += "     '" + ngayct.Trim() + "',";
                strSQL += "     '',";
                strSQL += "     '" + taikhoannhno.Trim() + "',";
                strSQL += "     '" + taikhoanvat.Trim() + "',";
                strSQL += "     '" + taikhoanco.Trim() + "',";
                strSQL += "     '" + inhacc.Trim() + "',";
                strSQL += "     '" + inhacc.Trim() + "',";
                strSQL += "     '" + sdvnhan.Trim() + "',";
                strSQL += "     '',";
                strSQL += "     '" + sohoadon.Trim() + "',";
                strSQL += "     '" + ngayhoadon.Trim() + "',";
                strSQL += "     " + vat + ",";
                strSQL += "     " + tienvat + ",";
                strSQL += "     N'" + diengiai.Trim() + "'";
                strSQL += "     )";
                mdlCommonFunction.Exec(strSQL, conn);
            }
            //Insert CK (25/02/2011)
            if (tienck > 0 & taikhoanck.Trim() != "")
            {
                strSQL = "  INSERT INTO [TiepNhanDoanhThu]([matiepnhan], [ngaytiepnhan], [nguoitiepnhan], [taikhoannh], [taikhoanno], [taikhoanco], [nguoinop], [donvinop], [donvinhan], [bophannop], [sohoadon], [ngayhoadon], [ck], [SoTien], [ghichu]) ";
                strSQL += "     VALUES( ";
                strSQL += "     '" + soct.Trim() + "',";
                strSQL += "     '" + ngayct.Trim() + "',";
                strSQL += "     '',";
                strSQL += "     '" + taikhoannhno.Trim() + "',";
                strSQL += "     '" + taikhoanno.Trim() + "',";
                strSQL += "     '" + taikhoanck.Trim() + "',";
                strSQL += "     '" + inhacc.Trim() + "',";
                strSQL += "     '" + inhacc.Trim() + "',";
                strSQL += "     '" + sdvnhan.Trim() + "',";
                strSQL += "     '',";
                strSQL += "     '" + sohoadon.Trim() + "',";
                strSQL += "     '" + ngayhoadon.Trim() + "',";
                strSQL += "     " + ck + ",";
                strSQL += "     " + tienck + ",";
                strSQL += "     N'" + diengiai.Trim() + "'";
                strSQL += "     )";
                mdlCommonFunction.Exec(strSQL, conn);
            }
            //cap nhat nguoi dung
            mdlCommonFunction.Exec("Update TiepNhanDoanhThu Set Userid=" + data.ParseInt(Userid.Trim()) + " Where MatiepNhan='" + soct.Trim() + "' and NgaytiepNhan='"+ ngayct.Trim() +"'", conn);
            //cap nhat loaitien & tygia
            mdlCommonFunction.Exec("Update TiepNhanDoanhThu Set LoaiTien='" + loaitien.Trim() + "',TyGia="+ tygia +" Where MatiepNhan='" + soct.Trim() + "' and NgaytiepNhan='"+ ngayct.Trim() +"'", conn);
            //3. Update phieunhapkhosanpham 
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         thanhtoan=isnull(thanhtoan,0)+" + sotien;
            strSQL += " Where nhacungcapid=" + sdvnhan.Trim() + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
            strSQL += " Where nhacungcapid=" + sdvnhan.Trim() + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);

            //Response.Write(2);
            DanhSachUNC(soct.Trim());
            //return;
        }
        catch
        {
            Response.Write(1);
            return;
        }
    }

    public void LuuThuChiNH()
    {
        int pxid = data.ParseInt(Request.QueryString["Pxid"]);//-1: Them moi; 1: Chinh sua, cap nhat
        string soct = Request.QueryString["soct"];
        string sounc = Request.QueryString["SoUNC"];
        string ngayct = mdlCommonFunction.CheckDate1(Request.QueryString["ngayct"]);
        string inhacc = Request.QueryString["nccid"];
        string sohoadon = Request.QueryString["sohoadon"];
        string ngayhoadon = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]).ToString();
        string taikhoanno = Request.QueryString["taikhoanno"];
        string taikhoanco = Request.QueryString["taikhoanco"];
        string diengiai = Request.QueryString["diengiai"];
        string taikhoannh = Request.QueryString["taikhoannh"];
        Double sotien = Convert.ToDouble(Request.QueryString["sotien"].Replace(".","").ToString());
        float tygia = data.ParseFloat(Request.QueryString["TyGia"]);
        if (tygia == 0) tygia = 1;
        string loaitien = Request.QueryString["LoaiTien"];
        string strSQL = "";
        strSQL = " Select * From Tiepnhandoanhthu ";
        strSQL += " Where matiepnhan='" + soct.Trim() + "' and sohoadon='" + sohoadon.Trim() + "'";
        DataTable dtSRC = mdlCommonFunction.LoadDataTable(strSQL, conn);
        //if (dtSRC.Rows.Count > 0)
        //{
        //    ClassQRS.MsgBox(this, "Trùng số hóa đơn!");
        //    return;
        //}
        if (dtSRC.Rows.Count > 0 && pxid == -1 && mdlCommonFunction.CheckExist(conn, "tiepnhandoanhthu", "matiepnhan", soct.Trim(), "ngaytiepnhan", ngayct.Trim(), "", "", "", ""))
        {
            Response.Write(0);
            return;
        }
        try
        {
            //Insert thong tin thu-chi
            clsTiepNhanDoanhThu cls = new clsTiepNhanDoanhThu();
            cls.MaTiepNhan = soct.Trim();
            cls.NgayTiepNhan = ngayct.Trim();//mdlCommonFunction.CheckDate(ngayct.Trim());
            cls.NguoiTiepNhan = "";
            cls.NguoiNop = inhacc.Trim().ToString();//Luu id nha cung cap
            //ThuanNH 10/05/2010
            cls.TaiKhoanNo = taikhoanno.Trim();
            cls.TaiKhoanCo = taikhoanco.Trim();
            cls.TaiKhoanNH = taikhoannh.Trim();
            cls.SoHoaDon = sohoadon.Trim();
            cls.NgayHoaDon = ngayhoadon.Trim();
            cls.SoTien = sotien;
            cls.GhiChu = diengiai.Trim();
            cls.BoPhanNop = 0;
            cls.UNC = sounc.Trim();
            //ThuanNH 25/05/2010 - Update table Phieunhapkhosanpham (cap nhat so tien thanh toan)
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         thanhtoan=isnull(thanhtoan,0)+" + sotien;
            strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
            strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            //-----------------------------------------------------
            //if (pxid == 1)//Sua
            //{
            //    strSQL = "  Update tiepnhandoanhthu Set ";
            //    strSQL += "     Taikhoanno='" + taikhoanno.Trim() + "',";
            //    strSQL += "     Taikhoanco='" + taikhoanco.Trim() + "',";
            //    strSQL += "     Sohoadon='" + sohoadon.Trim() + "',";
            //    strSQL += "     Sotien=" + sotien + ",";
            //    strSQL += "     Diengiai='" + diengiai.Trim() + "'";
            //    strSQL += " Where Matiepnhan='" + soct.Trim() + "'";
            //    mdlCommonFunction.Exec(strSQL, conn);
            //    Response.Write(2);
            //    return;
            //}
            mdlCommonFunction.Exec("Delete TiepNhanDoanhThu Where MatiepNhan='" + soct.Trim() + "' and NgayTiepNhan='" + ngayct.Trim() + "'", conn);
            int iIns = cls.InsertTiepNhanDoanhThu(conn);
            if (iIns > 0)
            {
                //ghi nhan ty gia va loai tien
                //mdlCommonFunction.Exec("Update TiepNhanDoanhThu Set LoaiTien='" + loaitien.Trim + "', TyGia=" + tygia + " Where MaTiepNhan='" + soct.Trim + "' and NgayTiepNhan='" + ngayct.Trim() + "' ", conn);
                try
                {
                    mdlCommonFunction.Exec("Update TiepNhanDoanhThu Set LoaiTien='" + loaitien.Trim() + "',TyGia=" + tygia + " Where MatiepNhan='" + soct.Trim() + "' and NgaytiepNhan='" + ngayct.Trim() + "'", conn);
                    //Response.Write(2);
                    DanhSachThuChiNH(soct.Trim());
                    //return;
                }
                catch
                {
                    Response.Write(1);
                    return;
                }
            }
            else
            {
                Response.Write(1);
                return;
            }
        }
        catch
        {
            Response.Write(1);
            return;
        }
    }

    //ThuanNH 02/06/2010
    public void LoadLuuChungTuTH()
    {
        int pxid = data.ParseInt(Request.QueryString["Pxid"]);//-1: Them moi; 1: Chinh sua, cap nhat
        string soct = Request.QueryString["soct"];
        string ngayct = mdlCommonFunction.CheckDate1(Request.QueryString["ngayct"]);
        
        string inhacc = Request.QueryString["nccid"];
        string inhaccc = Request.QueryString["nccidc"];
        
        string sohoadon = Request.QueryString["sohoadon"];
        string sohoadonc = Request.QueryString["sohoadonc"];

        string ngayhoadon = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]).ToString();
        string ngayhoadonc = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadonc"]).ToString();
        
        string taikhoanno = Request.QueryString["taikhoanno"];
        string taikhoanco = Request.QueryString["taikhoanco"];
        string diengiai = Request.QueryString["diengiai"];
        
        float sotien = data.ParseFloat(Request.QueryString["sotien"]);
        float sotienc = data.ParseFloat(Request.QueryString["sotienc"]);

        string strSQL = "";
        strSQL = " Select * From Tiepnhandoanhthu ";
        strSQL += " Where matiepnhan='" + soct.Trim() + "' and sohoadon='" + sohoadon.Trim() + "'";
        DataTable dtSRC = mdlCommonFunction.LoadDataTable(strSQL, conn);
        
        if (dtSRC.Rows.Count > 0 && pxid==-1 && mdlCommonFunction.CheckExist(conn, "tiepnhandoanhthu", "matiepnhan", soct.Trim(), "ngaytiepnhan", ngayct.Trim(), "", "", "", ""))
        {
            Response.Write(0);
            return;
        }
        try
        {
            //ThuanNH 25/05/2010 - Update table Phieunhapkhosanpham (cap nhat so tien thanh toan)
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         thanhtoan=isnull(thanhtoan,0)+"+ sotienc ;
            strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);

            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         thanhtoan=isnull(thanhtoan,0)+" + sotienc;
            strSQL += " Where nhacungcapid=" + inhacc + " and maphieunhap='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
    
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
            strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);

            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
            strSQL += " Where nhacungcapid=" + inhacc + " and maphieunhap='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);

            //Insert chung tu tong hop
            strSQL="    INSERT [tiepnhandoanhthu](matiepnhan, ngaytiepnhan, nguoitiepnhan, nguoinop, nguoinopc, sotien, sotienc, ghichu, bophannop, taikhoanno, taikhoanco, taikhoannh, sohoadon, sohoadonc, ngayhoadon, ngayhoadonc)";
	        strSQL+= "  VALUES( "; 
            strSQL+= "'"+ soct.Trim() +"', '"+ ngayct.Trim() +"', '', '"+ inhacc.Trim()+"', '"+ inhaccc.Trim() +"',";
            strSQL += "" + sotien + ", "+ sotienc +" ,N'" + diengiai.Trim() + "', 0, '" + taikhoanno + "', '" + taikhoanco + "', '', '" + sohoadon + "', '"+ sohoadonc +"', '" + ngayhoadon + "', '"+ ngayhoadonc +"')";
            try
            {
                mdlCommonFunction.Exec(strSQL, conn);
                Response.Write(2);
                return;
            }
            catch
            {
                Response.Write(1);
                return;
            }
        }
        catch
        {
            Response.Write(1);
            return;
        }
    }

    //ThuanNH 01/06/2010
    public void LuuCanTruCongNo()
    {
        int pxid = data.ParseInt(Request.QueryString["Pxid"]);//-1: Them moi; 1: Chinh sua, cap nhat
        string soct = Request.QueryString["soct"];
        string ngayct = mdlCommonFunction.CheckDate1(Request.QueryString["ngayct"]);
        
        string inhacc = Request.QueryString["nccid"];
        string inhaccc = Request.QueryString["nccidc"];
        
        string sohoadon = Request.QueryString["sohoadon"];
        string sohoadonc = Request.QueryString["sohoadonc"];

        string ngayhoadon = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]).ToString();
        string ngayhoadonc = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadonc"]).ToString();
        
        string taikhoanno = Request.QueryString["taikhoanno"];
        string taikhoanco = Request.QueryString["taikhoanco"];
        string diengiai = Request.QueryString["diengiai"];
        
        float sotien = data.ParseFloat(Request.QueryString["sotien"]);
        float sotienc = data.ParseFloat(Request.QueryString["sotienc"]);

        string strSQL = "";
        strSQL = " Select * From Tiepnhandoanhthu ";
        strSQL += " Where matiepnhan='" + soct.Trim() + "' and sohoadon='" + sohoadon.Trim() + "'";
        DataTable dtSRC = mdlCommonFunction.LoadDataTable(strSQL, conn);
        
        if (dtSRC.Rows.Count > 0 && pxid==-1 && mdlCommonFunction.CheckExist(conn, "tiepnhandoanhthu", "matiepnhan", soct.Trim(), "ngaytiepnhan", ngayct.Trim(), "", "", "", ""))
        {
            Response.Write(0);
            return;
        }
        try
        {
            //ThuanNH 25/05/2010 - Update table Phieunhapkhosanpham (cap nhat so tien thanh toan)
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         thanhtoan=isnull(thanhtoan,0)+"+ sotienc ;
            strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);

            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         thanhtoan=isnull(thanhtoan,0)+" + sotienc;
            strSQL += " Where nhacungcapid=" + inhacc + " and maphieunhap='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
    
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
            strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);

            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
            strSQL += " Where nhacungcapid=" + inhacc + " and maphieunhap='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            if (sotien > sotienc) sotien -= sotienc;
            else
            {
                sotienc -= sotien;
            }
            //Insert can tru cong no
            strSQL="    INSERT [tiepnhandoanhthu](matiepnhan, ngaytiepnhan, nguoitiepnhan, donvinhan, donvinop, sotien, sotienc, ghichu, bophannop, taikhoanno, taikhoanco, taikhoannh, sohoadon, sohoadonc, ngayhoadon, ngayhoadonc, nguoinop)";
	        strSQL+= "  VALUES( "; 
            strSQL+= "'"+ soct.Trim() +"', '"+ ngayct.Trim() +"', '', '"+ inhacc.Trim()+"', '"+ inhaccc.Trim() +"',";
            strSQL += "" + sotien + ", " + sotienc + " ,N'" + diengiai.Trim() + "', 0, '" + taikhoanno + "', '" + taikhoanco + "', '', '" + sohoadon + "', '" + sohoadonc + "', '" + ngayhoadon + "', '" + ngayhoadonc + "', '" + inhacc.Trim() + "')";
            try
            {
                mdlCommonFunction.Exec(strSQL, conn);
                //Response.Write(2);
                DanhSachCanTruCN(soct.Trim());
                return;
            }
            catch
            {
                Response.Write(1);
                return;
            }
        }
        catch
        {
            Response.Write(1);
            return;
        }
    }

    public void DanhSachCanTruCN(string sMaPN)
    {
        string strSQL = " SELECT * ";
        strSQL += " FROM tiepnhandoanhthu ";
        strSQL += " WHERE 1=1 ";
        if (sMaPN != "")
            strSQL += " and matiepnhan = '" + sMaPN + "'";
        strSQL += " ORDER BY matiepnhan ";
        DataTable dtCTPhieu = mdlCommonFunction.LoadDataTable(strSQL, conn);
        double dbTotal = GetTongTienCT(dtCTPhieu);
        Double dbTotal1 = dbTotal;

        string shtml = "";
        if (dtCTPhieu != null)
        {
            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"item\" width = \"43%\" valign = \"middle\"><b>Tổng thành tiền:&nbsp;</b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"60%\" valign = \"top\"><input id=\"txttong\" type=\"text\" value = \"" + mdlCommonFunction.FormatNumber(dbTotal1, false).ToString() + "\" style=\"width:170px;\"/></td>";
            shtml += "</tr>";
            shtml += "</table>";

            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>	";
            shtml += "		<td align=\"center\" class=\"header\" width = \"4%\" valign = \"top\" style=\"height: 20px\">&nbsp;</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">STT</td>	";
            shtml += "      <td align=\"center\" class=\"header\" width = \"15%\" valign = \"top\" style=\"height: 20px\">Số hóa đơn/C.từ nợ</td>";
            //shtml += "		<td align=\"center\" class=\"header\" width = \"5%\" valign = \"top\" style=\"height: 20px\">Ngày hóa đơn</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"14%\" valign = \"top\" style=\"height: 20px\">KH/NCC nợ</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"10%\" valign = \"top\" style=\"height: 20px\">Số tiền</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"9%\" valign = \"top\" style=\"height: 20px\">Số hóa đơn/C.từ có</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"14%\" valign = \"top\" style=\"height: 20px\">KH/NCC có</td>";
            shtml += "		<td align=\"center\" class=\"header\" width = \"15%\" valign = \"top\" style=\"height: 20px\">Số tiền</td>";
            shtml += "	</tr>";
            for (int i = 0; i < dtCTPhieu.Rows.Count; i++)
            {
                shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"XoaCanTru('" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "', '" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "', " + dtCTPhieu.Rows[i]["sotien"] + ", " + dtCTPhieu.Rows[i]["nguoinop"] + ")\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"4%\" valign = \"middle\"><input type=\"button\" name=\"sua\" value =\"Sửa\" onclick=\"SuaCanTru('" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "', '" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "')\" style=\"width:40px;\" /></td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\">" + (i + 1).ToString() + "</td>";
                shtml += "		<td align=\"center\" class=\"item\" width = \"15%\" valign = \"middle\"><input id=\"txtSoHoaDon_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["SoHoaDon"].ToString() + "\" style=\"width:100px;\"/></td>";
                //shtml += "		<td align=\"center\" class=\"item\" width = \"5%\" valign = \"middle\"><input id=\"txtNgayHoaDon_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + Convert.ToDateTime(dtCTPhieu.Rows[i]["NgayHoaDon"]).ToString("dd/MM/yyyy") + "\" style=\"width:100px;\"/></td>";
                shtml += "		<td align=\"left\" class=\"item\" width = \"17%\" valign = \"middle\"><span id = \"list_" + dtCTPhieu.Rows[i]["matiepnhan"] + "\">" + LoadNCC(data.ParseInt(dtCTPhieu.Rows[i]["nguoinop"]), dtCTPhieu.Rows[i]["matiepnhan"].ToString()) + "</span></td>";
                //shtml += "		<td align=\"center\" class=\"item\" width = \"14%\" valign = \"middle\"><input id=\"txtnguoinop_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"   runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["nguoinop"].ToString() + "\" style=\"width:140px;\"/></td>";
                shtml += "		<td align=\"right\" class=\"item\" width = \"10%\" valign = \"middle\"><input id=\"txtSoTien_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"  runat = \"server\" value = \"" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["sotien"], false).ToString() + "\" style=\"width:90px;\" /></td>";
                shtml += "		<td align=\"right\" class=\"item\" width = \"9%\" valign = \"middle\"><input id=\"txtSoHoaDonC_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"   runat = \"server\" value = \"" + dtCTPhieu.Rows[i]["SoHoaDonC"].ToString() + "\" style=\"width:90px;\"/></td>	";
                shtml += "		<td align=\"left\" class=\"item\" width = \"17%\" valign = \"middle\"><span id = \"list_" + dtCTPhieu.Rows[i]["matiepnhan"] + "\">" + LoadNCC(data.ParseInt(dtCTPhieu.Rows[i]["nguoinop"]), dtCTPhieu.Rows[i]["matiepnhan"].ToString()) + "</span></td>";
                shtml += "		<td align=\"right\" class=\"item\" width = \"12%\" valign = \"middle\"><input id=\"txtSoTienC_" + dtCTPhieu.Rows[i]["matiepnhan"].ToString() + "\" type=\"text\"     runat = \"server\" value = \"" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["sotienc"], false).ToString() + "\" align=\"right\" style=\"width:170px;\"/></td>	";
                //" + mdlCommonFunction.FormatNumber(dtCTPhieu.Rows[i]["sotien"], false).ToString() + "</td>";                
                shtml += "	</tr>";
            }
            shtml += "    <tr width=\"100%\" style=\"background-color:#66CCCC\">";
            shtml += "		<td align=\"center\" height = \"20px\" class=\"item\" colspan = \"8\" width = \"80%\" valign = \"middle\"><b>Tổng cộng: </b></td>";
            shtml += "		<td align=\"right\" class=\"item\" width = \"20%\" valign = \"middle\"><b>" + mdlCommonFunction.FormatNumber(dbTotal, false).ToString() + "</b></td>";

            shtml += "	</tr>";
            shtml += "</table>";
            Response.Write(shtml);
        }
        else
        {
            Response.Write("error");
        }
    }

    public void LoadDVNop()
    {
        int stt = data.ParseInt(Request.QueryString["curdong"]);
        string shtml = "";
        string sql;
        sql = " SELECT * FROM nhacungcap ";
        DataTable dt = mdlCommonFunction.LoadDataTable(sql, conn);
        if (dt.Rows.Count > 0)
        {
            shtml += "<select name=\"ddldvnop_" + stt + "\" id=\"ddldvnop_" + stt + "\" style=\"height:19px;width:250px; z-index:-1;\">";
            shtml += "<option value='0'>-------Chọn đơn vị nộp-------</option>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                shtml += "<option value=\"" + data.ParseInt(dt.Rows[i]["nhacungcapid"]) + "\" ";
                shtml += ">" + dt.Rows[i]["tennhacungcap"].ToString() + "</option>";
            }
            shtml += "</select>";
        }
        Response.Write(shtml);
    }
    public void LoadDVNhan()
    {
        int stt = data.ParseInt(Request.QueryString["curdong"]);
        string shtml = "";
        string sql;
        sql = " SELECT * FROM nhacungcap ";
        DataTable dt = mdlCommonFunction.LoadDataTable(sql, conn);
        if (dt.Rows.Count > 0)
        {
            shtml += "<select name=\"ddldvnhan_" + stt + "\" id=\"ddldvnhan_" + stt + "\" style=\"height:19px;width:250px; z-index:-1;\">";
            shtml += "<option value='0'>-------Chọn đơn vị nộp-------</option>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                shtml += "<option value=\"" + data.ParseInt(dt.Rows[i]["nhacungcapid"]) + "\" ";
                shtml += ">" + dt.Rows[i]["tennhacungcap"].ToString() + "</option>";
            }
            shtml += "</select>";
        }
        Response.Write(shtml);
    }
    public void SaveThuChiKhacTM()
    {
        string smaphieu = Request.QueryString["maphieu"];
        string sngayphieu = Request.QueryString["ngayphieu"];
        string sbophan = Request.QueryString["bophan"];
        string staikhoan1 = Request.QueryString["taikhoan1"];
        string staikhoan= Request.QueryString["taikhoan"];
        string sdoituong = Request.QueryString["doituong"];
        string sdonvi = Request.QueryString["donvi"];
        string svat = Request.QueryString["vat"];
        string stienvat = Request.QueryString["tienvat"];
        string stkvat = Request.QueryString["tkvat"];
        string ssotien = Request.QueryString["sotien"];
        string ssohoadon = Request.QueryString["sohoadon"];//20/05/2011 - 8:49AM
        string sngayhoadon = Request.QueryString["ngayhoadon"];//20/05/2011 - 8:49AM
        //24/05/2011 - 9:59AM
        string stendonvi = Request.QueryString["tendonvi"];
        string smasothue = Request.QueryString["masothue"];
        string sdiachi = Request.QueryString["diachi"];

        string sghichu = Request.QueryString["ghichu"];
        staikhoan = staikhoan.TrimEnd('/');
        svat = svat.TrimEnd('/');
        stienvat = stienvat.TrimEnd('/');
        stkvat = stkvat.TrimEnd('/');
        ssotien = ssotien.TrimEnd('/');
        ssohoadon = ssohoadon.TrimEnd('/');
        sngayhoadon = sngayhoadon.TrimEnd('-');
        sghichu = sghichu.TrimEnd('/');
        string[] arrtaikhoan = staikhoan.Split('/');
        string[] arrvat = svat.Split('/');
        string[] arrtienvat = stienvat.Split('/');
        string[] arrtkvat = stkvat.Split('/');
        string[] arrsotien= ssotien.Split('/');
        string[] arrsohoadon = ssohoadon.Split('/');
        string[] arrngayhoadon = sngayhoadon.Split('-');
        string strSQL="";
        string Userid = "";
        string UserName = "";
        string Userhost = Request.UserHostAddress.ToString();
        string sql2 = "Select a.*,b.tennguoidung From NguoiDung_Host a join NguoiDung b on a.idnguoidung=b.idnguoidung Where a.IdClient='" + Userhost.Trim() + "'";
        DataTable dt1 = mdlCommonFunction.LoadDataTable(sql2, conn);
        if (dt1 != null && dt1.Rows.Count > 0)//neu ton tai nguoi dung & IP -> Khong lam gi het!
        {
            Userid = dt1.Rows[0]["idnguoidung"].ToString();
            UserName = dt1.Rows[0]["tennguoidung"].ToString();
        }
        //if (Session["idnguoidung"] == null)
        //    Response.Redirect("../login.aspx");
        strSQL = "Select * From TiepNhanDoanhThu Where MaTiepNhan='" + smaphieu.Trim() + "' ";//and Userid="+ data.ParseInt(Session["idnguoidung"])
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        if (dt!=null&&dt.Rows.Count>0)
        {
            //if (Session["idnguoidung"] != null)
            //if (Session["idnguoidung"] != null)
            //{
                if (data.ParseInt(Userid) == data.ParseInt(dt.Rows[0]["userid"]) || UserName == "administrator")//TH cung userid chinh sua - them moi
                {
                    strSQL = "Delete TiepNhanDoanhThu Where matiepnhan='" + smaphieu.Trim() + "'";
                    mdlCommonFunction.Exec(strSQL, conn);
                }
                else//truong hop trung phieu va <> userid (2 nguoi cung lam)-> tu dong phat sinh phieu moi
                {
                    System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Số phiếu đã tồn tại!');</script>");
                    Response.Write(0);
                    return;
                    //smaphieu = mdlCommonFunction.TaoMaSoPhieu(smaphieu.Substring(0, 2), "tiepnhandoanhthu", "matiepnhan", "ngaytiepnhan", sngayphieu.Substring(3, 2).ToString(), "ngaytiepnhan", conn);
                }
            //}
        }
        for (int i = 0; i < arrtaikhoan.Length; i++)
        {
            if (smaphieu.Substring(0, 2) == "PT")//thu
            {
                strSQL = "Insert into tiepnhandoanhthu(matiepnhan,ngaytiepnhan,bophannop,taikhoanno,taikhoanco,nguoinop,nguoinopc,masothue,donvinop,nguoitiepnhan,donvinhan,sotien,sohoadon,ngayhoadon,ghichu) ";
                strSQL+= "Values('" + smaphieu.Trim() + "','" + mdlCommonFunction.CheckDate(sngayphieu.Trim()) + "'," + sbophan.Trim() + ",";
                strSQL+= " '" + staikhoan1.Trim() + "','" + arrtaikhoan[i].Trim() + "' ";
                strSQL += " ,N'" + stendonvi.Trim() + "',N'"+ sdiachi.Trim() +"','"+ smasothue.Trim() +"'," + sdonvi.Trim();
                strSQL += ", N'"+ sdoituong.Trim() +"',0, " + Convert.ToDouble(arrsotien[i].Trim()) + " ";
                if (i < arrsohoadon.Length)
                {
                    strSQL += ",'" + arrsohoadon[i] + "' ";
                    if (arrngayhoadon[i] != "")
                        strSQL += ",'" + mdlCommonFunction.CheckDate(arrngayhoadon[i].Trim()) + "',N'" + sghichu.Trim() + "')";
                    else
                        strSQL += ",'',N'" + sghichu.Trim() + "')";
                }
                else
                    strSQL += ",'','',N'" + sghichu.Trim() + "')";
                mdlCommonFunction.Exec(strSQL, conn);
                //tienvat
                if (i < arrvat.Length)
                {
                    if (data.ParseInt(arrvat[i]) > 0)
                    {
                        strSQL = "Insert into tiepnhandoanhthu(matiepnhan,ngaytiepnhan,bophannop,taikhoanno,taikhoanco,nguoinop,nguoinopc,masothue,donvinop,nguoitiepnhan,donvinhan,vat,sotien,sohoadon,ngayhoadon,ghichu) ";
                        strSQL += "Values('" + smaphieu.Trim() + "','" + mdlCommonFunction.CheckDate(sngayphieu.Trim()) + "'," + sbophan.Trim() + ",";
                        strSQL += " '" + staikhoan1.Trim() + "','" + arrtkvat[i].Trim() + "' ";
                        strSQL += " ,N'" + stendonvi.Trim() + "',N'" + sdiachi.Trim() + "','" + smasothue.Trim() + "'," + sdonvi.Trim();
                        strSQL += ", N'" + sdoituong.Trim() + "',0, "+ data.ParseInt(arrvat[i]) +", " + Convert.ToDouble(arrtienvat[i].Trim()) + " ";
                        if (i < arrsohoadon.Length)
                        {
                            strSQL += ",'" + arrsohoadon[i] + "' ";
                            if (arrngayhoadon[i] != "")
                                strSQL += ",'" + mdlCommonFunction.CheckDate(arrngayhoadon[i].Trim()) + "',N'" + sghichu.Trim() + "')";
                            else
                                strSQL += ",'',N'" + sghichu.Trim() + "')";
                        }
                        else
                            strSQL += ",'','',N'" + sghichu.Trim() + "')";
                        mdlCommonFunction.Exec(strSQL, conn);
                    }
                }
            }
            else//chi
            {
                strSQL = "Insert into tiepnhandoanhthu(matiepnhan,ngaytiepnhan,bophannop,taikhoanno,taikhoanco,nguoinop,nguoinopc,masothue,donvinop,nguoitiepnhan,donvinhan,sotien,sohoadon,ngayhoadon,ghichu) ";
                strSQL += "Values('" + smaphieu.Trim() + "','" + mdlCommonFunction.CheckDate(sngayphieu.Trim()) + "'," + sbophan.Trim() + ",";
                strSQL += " '" + arrtaikhoan[i].Trim() + "','" + staikhoan1.Trim() + "', N'"+ stendonvi.Trim() +"',N'"+ sdiachi.Trim() +"','"+ smasothue.Trim() +"', 0,";
                strSQL += " N'" + sdoituong.Trim() + "'," + sdonvi.Trim() + "," + Convert.ToDouble(arrsotien[i].Trim()) + " ";
                if (i < arrsohoadon.Length)//khac phuc loi index was out of the bound of array
                {
                    strSQL += ",'" + arrsohoadon[i] + "' ";
                    if (i < arrngayhoadon.Length)
                    {
                        if (arrngayhoadon[i] != "")
                            strSQL += ",'" + mdlCommonFunction.CheckDate(arrngayhoadon[i].Trim()) + "',N'" + sghichu.Trim() + "')";
                        else
                            strSQL += ",'',N'" + sghichu.Trim() + "')";
                    }
                    else
                        strSQL += ",'',N'" + sghichu.Trim() + "')";
                }
                else
                    strSQL += ",'','',N'" + sghichu.Trim() + "')";
                
                strSQL += " ";
                mdlCommonFunction.Exec(strSQL, conn);
                //tienvat
                if (i < arrvat.Length)
                {
                    if (data.ParseInt(arrvat[i]) > 0)
                    {
                        strSQL = "Insert into tiepnhandoanhthu(matiepnhan,ngaytiepnhan,bophannop,taikhoanno,taikhoanco,nguoinop,nguoinopc,masothue,donvinop,nguoitiepnhan,donvinhan,vat,sotien,sohoadon,ngayhoadon,ghichu) ";
                        strSQL += "Values('" + smaphieu.Trim() + "','" + mdlCommonFunction.CheckDate(sngayphieu.Trim()) + "'," + sbophan.Trim() + ",";
                        strSQL += " '" + arrtkvat[i].Trim() + "','" + staikhoan1.Trim() + "', N'" + stendonvi.Trim() + "',N'" + sdiachi.Trim() + "','" + smasothue.Trim() + "', 0,";
                        strSQL += " N'" + sdoituong.Trim() + "'," + sdonvi.Trim() + ","+ arrvat[i].Trim() +"," + Convert.ToDouble(arrtienvat[i].Trim()) + " ";
                        if (i < arrsohoadon.Length)//khac phuc loi index was out of the bound of array
                        {
                            strSQL += ",'" + arrsohoadon[i] + "' ";
                            if (arrngayhoadon[i] != "")
                                strSQL += ",'" + mdlCommonFunction.CheckDate(arrngayhoadon[i].Trim()) + "',N'" + sghichu.Trim() + "')";
                            else
                                strSQL += ",'',N'" + sghichu.Trim() + "')";
                        }
                        else
                            strSQL += ",'','',N'" + sghichu.Trim() + "')";

                        strSQL += " ";
                        mdlCommonFunction.Exec(strSQL, conn);
                    }
                }
            }
            //cap nhat userid
            //if (Session["idnguoidung"] == null)
            //    Response.Redirect("../login.aspx");
            mdlCommonFunction.Exec("Update TiepNhanDoanhThu Set Userid=" + data.ParseInt(Userid.Trim()) + " Where MatiepNhan='" + smaphieu.Trim() + "'", conn);
            //Set thu/chi khac
            strSQL = "Update TiepNhanDoanhThu Set isKhac='1' Where MaTiepNhan='" + smaphieu.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            
            Response.Write(1);
        }
    }
    public void LuuThuChiTM()
    {
        int pxid = data.ParseInt(Request.QueryString["Pxid"]);//-1: Them moi; 1: Chinh sua, cap nhat
        string soct = Request.QueryString["soct"];
        string ngayct = mdlCommonFunction.CheckDate1(Request.QueryString["ngayct"]);
        string inhacc = Request.QueryString["nccid"];
        string sohoadon = Request.QueryString["sohoadon"];
        string ngayhoadon;
        if (mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]).ToString() == "")
            ngayhoadon = "";
        else
            ngayhoadon = mdlCommonFunction.CheckDate1(Request.QueryString["ngayhoadon"]).ToString();
        string kyhieuhd = Request.QueryString["KyHieuHD"];
        string loaitien = Request.QueryString["LoaiTien"];
        Double tygia = Convert.ToDouble(Request.QueryString["TyGia"]);
        string taikhoanno = Request.QueryString["taikhoanno"];
        string taikhoanco = Request.QueryString["taikhoanco"];
        string diengiai = Request.QueryString["diengiai"];
        Double sotien = Convert.ToDouble(Request.QueryString["sotien"]);
        int vat= data.ParseInt(Request.QueryString["VAT"]);
        float tienvat = data.ParseFloat(Request.QueryString["TienVAT"]);
        string taikhoanvat = Request.QueryString["TaiKhoanVAT"];
        string hoten = Request.QueryString["HoTen"];
        string tenkh = Request.QueryString["TenKH"];//ThuanNH 17/08/2010
        string diachi = Request.QueryString["DiaChi"];//ThuanNH 17/08/2010
        string masothue = Request.QueryString["MaSoThue"];//ThuanNH 17/08/2010
        string donvi = Request.QueryString["DonVi"];
        string strSQL = "", strSQL1="";
        string Userid = "";
        string UserName = "";
        string Userhost = Request.UserHostAddress.ToString();
        string sql2 = "Select a.*,b.tennguoidung From NguoiDung_Host a join NguoiDung b on a.idnguoidung=b.idnguoidung Where a.IdClient='" + Userhost.Trim() + "'";
        DataTable dt1 = mdlCommonFunction.LoadDataTable(sql2, conn);
        if (dt1 != null && dt1.Rows.Count > 0)//neu ton tai nguoi dung & IP -> Khong lam gi het!
        {
            Userid = dt1.Rows[0]["idnguoidung"].ToString();
            UserName = dt1.Rows[0]["tennguoidung"].ToString();
        }
        //if (Session["idnguoidung"] == null)
        //    Response.Redirect("../login.aspx");
        strSQL = " Select * From Tiepnhandoanhthu ";
        strSQL += " Where matiepnhan='" + soct.Trim() + "' and sohoadon='" + sohoadon.Trim() + "'";
        DataTable dtSRC = mdlCommonFunction.LoadDataTable(strSQL, conn);
        
        if (dtSRC.Rows.Count > 0 && pxid==-1 && mdlCommonFunction.CheckExist(conn, "tiepnhandoanhthu", "matiepnhan", soct.Trim(), "ngaytiepnhan", ngayct.Trim(), "", "", "", ""))
        {
            Response.Write(0);
            return;
        }
        try
        {
            //Delete phieu neu ton tai (ThuanNH 22/10/2010)
            strSQL = " Delete Tiepnhandoanhthu ";
            strSQL += " Where matiepnhan='" + soct.Trim() + "' and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            //Insert thong tin thu-chi
            clsTiepNhanDoanhThu cls = new clsTiepNhanDoanhThu();
            cls.MaTiepNhan = soct.Trim();
            cls.NgayTiepNhan = ngayct.Trim();//mdlCommonFunction.CheckDate(ngayct.Trim());
            cls.NguoiTiepNhan = hoten.Trim().ToString();
            cls.NguoiNop = inhacc.Trim().ToString();//Luu id nha cung cap
            cls.NguoiNopC = "";
            //ThuanNH 10/05/2010
            cls.TaiKhoanNo = taikhoanno.Trim();
            cls.TaiKhoanCo = taikhoanco.Trim();
            cls.TaiKhoanNH = "";
            cls.SoHoaDon = sohoadon.Trim();
            cls.SoHoaDonC = "";
            cls.NgayHoaDon = (ngayhoadon.Trim()=="" ? "" : ngayhoadon.Trim());
            cls.NgayHoaDonC = "";
            cls.SoTien = sotien;
            cls.SoTienC = 0;
            cls.GhiChu = diengiai.Trim();
            cls.BoPhanNop =0;
            //ThuanNH 25/05/2010 - Update table Phieunhapkhosanpham (cap nhat so tien thanh toan)
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         thanhtoan=isnull(thanhtoan,0)+"+ sotien ;
            strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            strSQL = " Update phieunhapkhosanpham set ";
            strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
            strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
            mdlCommonFunction.Exec(strSQL, conn);
            //ThuanNH 28/06/2010 - chi tien mua cong cu - dung cu
            if (taikhoanno.Substring(0,3) == "142" || taikhoanno.Substring(0,3) == "242")
            {
                strSQL = "Insert into PhanBoCCDC(SoPhieu, MaCCDC, TongGiaTri, TaiKhoanNo, diengiai) ";
                strSQL += "Values ( ";
                strSQL += "         '" + mdlCommonFunction.CreateIDTheoThuTu("CC", "PhanBoCCDC", "SoPhieu", "Thang", conn) + "'";
                strSQL += "         ,'" + mdlCommonFunction.CreateIDTheoThuTu("CC", "PhanBoCCDC", "MaCCDC", "Thang", conn) + "'," + sotien + ", '"+ taikhoanno.Trim() +"', N'" + diengiai.Trim() + "'";
                strSQL += ")";
                mdlCommonFunction.Exec(strSQL, conn);
            }

            strSQL="    INSERT [tiepnhandoanhthu](matiepnhan, ngaytiepnhan, nguoitiepnhan, nguoinop, nguoinopc, sotien, sotienc, ghichu, bophannop, taikhoanno, taikhoanco, taikhoannh, sohoadon, sohoadonc, ngayhoadon, ngayhoadonc, donvinop, donvinhan, kyhieuhd, masothue)";
	        strSQL+= "  VALUES( "; 
            strSQL+= "'"+ soct.Trim() +"', '"+ ngayct.Trim() +"', N'"+ hoten.Trim().ToString() +"', ";
            if (inhacc.Trim()!="" && inhacc.Trim()!="0")
                strSQL+= "'"+ inhacc.Trim()+"', '',";
            else
                strSQL += " N'" + tenkh.Trim() + "', N'"+ diachi.Trim() +"',";// truong hop KH khong nam trong danh muc
            strSQL += "" + sotien + ", 0,N'" + diengiai.Trim() + "', 0, '" + taikhoanno.Trim() + "', '" + taikhoanco.Trim() + "', '', '" + sohoadon + "', '', '" + (ngayhoadon.Trim() == "" ? "" : ngayhoadon.Trim()) + "', '' ";
            if (soct.Substring(1, 2) == "PT")
                strSQL += ", '" + donvi.Trim() + "', '', '" + kyhieuhd.Trim() + "', '" + masothue.Trim() + "' ";
            else
                strSQL += ", '', '" + donvi.Trim() + "', '" + kyhieuhd.Trim() + "', '" + masothue.Trim() + "'";
            strSQL += ")";
            if (soct.Substring(1, 2) == "PT")
            {
                //insert them dong VAT
                strSQL1 = "    INSERT [tiepnhandoanhthu](matiepnhan, ngaytiepnhan, nguoitiepnhan, nguoinop, nguoinopc, sotien, ghichu, bophannop, taikhoanno, taikhoanco, sohoadon, ngayhoadon, donvinop, kyhieuhd, masothue)";
                strSQL1 += "  VALUES( ";
                strSQL1 += "'" + soct.Trim() + "', '" + ngayct.Trim() + "', N'" + hoten.Trim().ToString() + "'";
                if (inhacc.Trim()!="" && inhacc.Trim()!="0")
                    strSQL1 += ", '" + inhacc.Trim() + "', ";
                else
                    strSQL1 += ", N'" + tenkh.Trim() + "', N'"+ diachi.Trim() +"',";// truong hop KH khong nam trong danh muc
                strSQL1 += "" + tienvat + ", N'" + diengiai.Trim() + "', 0, '" + taikhoanno.Trim() + "', '" + taikhoanvat.Trim() + "', '" + sohoadon + "', '" + (ngayhoadon.Trim() == "" ? "" : ngayhoadon.Trim()) + "', '" + donvi.Trim() + "', '" + kyhieuhd.Trim() + "', '" + masothue.Trim() + "')";
            }
            else
            {
                //insert them dong VAT
                strSQL1 = "    INSERT [tiepnhandoanhthu](matiepnhan, ngaytiepnhan, nguoitiepnhan, nguoinop, nguoinopc, sotien, ghichu, bophannop, taikhoanno, taikhoanco, sohoadon, ngayhoadon, donvinhan, kyhieuhd, masothue)";
                strSQL1 += "  VALUES( ";
                strSQL1 += "'" + soct.Trim() + "', '" + ngayct.Trim() + "', N'" + hoten.Trim().ToString() + "'";
                if (inhacc.Trim() != "" && inhacc.Trim() != "0")
                    strSQL1 += ", '" + inhacc.Trim() + "', '',";
                else
                    strSQL1 += ", N'" + tenkh.Trim() + "', N'" + diachi.Trim() + "',";// truong hop KH khong nam trong danh muc - Luu tam diachi vao column nguoinopc
                strSQL1 += "" + tienvat + ", N'" + diengiai.Trim() + "', 0, '" + taikhoanvat.Trim() + "', '" + taikhoanco.Trim() + "', '" + sohoadon + "', '" + (ngayhoadon.Trim() == "" ? "" : ngayhoadon.Trim()) + "', '" + donvi.Trim() + "', '" + kyhieuhd.Trim() + "', '" + masothue.Trim() + "')";
            }
            //int iIns = cls.InsertTiepNhanDoanhThu(conn);
            //if (iIns > 0)
            //{
                try
                {
                    if (vat > 0 && tienvat > 0)
                    {
                        //insert row vat
                        mdlCommonFunction.Exec(strSQL1, conn);
                    }
                    mdlCommonFunction.Exec(strSQL, conn);
                    mdlCommonFunction.Exec("Update TiepNhanDoanhThu Set Userid=" + data.ParseInt(Userid.Trim()) + " Where MatiepNhan='" + soct.Trim() + "'", conn);
                    DanhSachThuChi(soct.Trim(),ngayct.Trim());
                }
                catch//Loi luu du lieu
                {
                    Response.Write("1");
                    return;
                }
            //ThuanNH 22/10/2010 - Cap nhat lai bang phieunhapkhosanpham (Loai tru TH : luu nhieu lan se bi double so tien cong no???)
                strSQL =  "Select sum(sotien)sotien ";
                strSQL += "From TiepNhanDoanhThu ";
                strSQL += "Where taikhoanno like '331%' and donvinhan=" + donvi.Trim() + " and sohoadon='" + sohoadon.Trim() + "'";
                DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
                if (dt.Rows.Count > 0)
                {
                    strSQL = " Update a set thanhtoan=" + sotien;
                    strSQL += " From phieunhapkhosanpham a ";
                    strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
                    mdlCommonFunction.Exec(strSQL, conn);
                    strSQL = " Update phieunhapkhosanpham set ";
                    strSQL += "         conlai=tongtien-isnull(thanhtoan,0)";
                    strSQL += " Where nhacungcapid=" + inhacc + " and sohoadon='" + sohoadon.Trim() + "'";
                    mdlCommonFunction.Exec(strSQL, conn);
                }
            //Update LoaiTien&TyGia - 30/06/2011
                mdlCommonFunction.Exec("Update TiepNhanDoanhThu Set LoaiTien='" + loaitien.Trim() + "', TyGia=" + tygia + " Where MaTiepNhan='" + soct.Trim() + "'", conn);
            //End ----------------------------------------------------------------------------------------
            //}
            //else
            //{
            //    Response.Write(1);
            //    return;
            //}
        }
        catch
        {
            Response.Write(1);
            return;
        }
        
    }

    private void LuuNX_VTYT()
    {
        //if (data.ParseInt(Session["idnguoidung"]) != 0)
        //{
            string masophieu = Request.QueryString["masophieu"];
            string ngayphieu= Request.QueryString["ngayphatsinh"];
            //ThuanNH 22/04/2010
            string taikhoanno = Request.QueryString["taikhoanno"];
            string taikhoanco = Request.QueryString["taikhoanco"];
            //------------------
            string slistdv = Request.QueryString["slistdv"];
            string slistsoluong = Request.QueryString["slistsoluong"];
            string slistdongia = Request.QueryString["slistdongia"];
            string slistthanhtien = Request.QueryString["slistthanhtien"];
            string slistphongban= Request.QueryString["slistphongban"];
            string slistkhonhap = Request.QueryString["slistkhonhap"];
            string slistkhoxuat = Request.QueryString["slistkhoxuat"];
            string slistsolo = Request.QueryString["slistsolo"];
            string slisthsd= Request.QueryString["slisthsd"];

            int idaluu = data.ParseInt(Request.QueryString["daluu"]);
            slistdv = slistdv.TrimEnd('/'); //mavtyt
            slistsoluong = slistsoluong.TrimEnd('/');
            slistdongia = slistdongia.TrimEnd('/');
            slistthanhtien = slistthanhtien.TrimEnd('/');
            slistphongban = slistphongban.TrimEnd('/');
            slistkhonhap = slistkhonhap.TrimEnd('/');
            slistkhoxuat = slistkhoxuat.TrimEnd('/');
            if (slistsolo!="")
                slistsolo = slistsolo.TrimEnd('/');
            if (slisthsd!="")
                slisthsd = slisthsd.TrimEnd('/');

            string[] arrdichvu = slistdv.Split('/');
            string[] arrsoluong = slistsoluong.Split('/');
            string[] arrdongia = slistdongia.Split('/');
            string[] arrthanhtien = slistthanhtien.Split('/');
            string[] arrphongban = slistphongban.Split('/');
            string[] arrkhonhap = slistkhonhap.Split('/');
            string[] arrkhoxuat = slistkhoxuat.Split('/');
            string[] arrsolo = slistsolo.Split('/');
            string[] arrhsd = slisthsd.Split('/');
            if (idaluu == 0)
            {
                double dblTongTien=0;
                string msql; 
                for (int i = 0; i < arrdichvu.Length; i++)
                {
                    //1/. Luu table chitietxuatVTYT
                    msql = "sp_Insert_ChiTietVTYT "
                        + "'" + masophieu
                        + "','" + mdlCommonFunction.CheckDate(ngayphieu)
                        + "','" + arrphongban[i]
                        + "','" + arrkhoxuat[i]
                        + "','" + arrkhonhap[i]
                        + "','" + arrdichvu[i]
                        + "'," + arrsoluong[i]
                        + "," + arrdongia[i]
                        + "," + arrthanhtien[i];
                    if (arrsolo.Length < i+1)
                        msql += ",'";
                    else
                    {
                        if (arrsolo[i] == "")
                        {
                            msql += ",'";
                        }
                        else
                        {
                            msql += ",'" + arrsolo[i];
                        }
                    }
                    if (arrhsd.Length < i+1)
                        msql += "','',''";
                    else
                    {
                        if (arrhsd[i] == "")
                        {
                            msql += "','',''";
                        }
                        else
                        {
                            msql += "','" + mdlCommonFunction.CheckDate(arrhsd[i].Replace(".", "/")) + "'";
                            msql += ",''";
                        }
                    }
                    //ThuanNH 22/04/2010
                    dblTongTien += data.ParseFloat(arrthanhtien[i]);
                    try
                    {
                        mdlCommonFunction.Exec(msql, conn);
                        //return 1;
                    }
                    catch (Exception)
                    {
                        //Response.Write(0);
                        ClassQRS.MsgBox(this,"Loi luu du lieu!");
                        //return 0;
                    }
                }
                try
                {
                    //2/. Luu table TongHopVTYT
                    string strSQL = " Insert into TongHopVTYT(MaSoPhieu, Ngay, TaiKhoanNo, TaiKhoanCo, ThanhTien) ";
                    strSQL += " Values ('" + masophieu + "','" + mdlCommonFunction.CheckDate(ngayphieu) + "','" + taikhoanno + "','" + taikhoanco + "'," + dblTongTien + ")";
                    mdlCommonFunction.Exec(strSQL, conn);
                }
                catch (Exception)
                {
                    ClassQRS.MsgBox(this, "Loi luu du lieu!");
                }
            }
    }
    //ThuanNH add 12/04/2010
    //Get danh sach vat tu y te
    private void GetDanhSachVTYT()
    {
        try
        {
            //int idkhoa = data.ParseInt(Request.QueryString["idkhoa"]);
            //int iLoaidt = data.ParseInt(Request.QueryString["doituong"]);
            string srcdichvu = Request.QueryString["tenvtyt"];

            string swhere = "";
            if (srcdichvu != "")
                swhere += " AND Tenvtyt LIKE N'" + srcdichvu + "%' ";
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750\">";

            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"45%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên VTYT</td>";
            html += "<td width=\"25%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đơn vị</td>";
            html += "</tr>";
            ArrayList arr = data.SQLMultiHashReader("SELECT * FROM VTYT_DMVTYT WHERE 1 =1 " + swhere + "  ORDER BY TenVTYT ASC", conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"setChonDichVu(" + h["idvtyt"] + ",'" + h["tenvtyt"] + "')\">";
                html += "<td width=\"30%\" class=\"ptext\" >&nbsp;" + h["tenvtyt"] + "</td>";
                html += "<td width=\"45%\" class=\"ptext\">" + h["donvi"] + "</td>";
                html += "</tr>";
            }
            html += "<tr><td colspan=\"3\"><br/></td></tr>";

            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    //ThuanNH add 04/05/2010
    //Get danh sach thuoc
    private void GetDanhSachThuoc()
    {
        try
        {
            string srcdichvu = Request.QueryString["tenthuoc"];
            string strSQL="";
            string swhere = "";
            if (srcdichvu != "")
                swhere += " AND Tenthuoc LIKE N'" + srcdichvu + "%' ";
            string html = "";
            html = "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"750\">";

            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"45%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên thuốc</td>";
            html += "<td width=\"25%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Đơn vị tính</td>";
            html += "<td width=\"25%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Hãng SX</td>";
            html += "</tr>";
            strSQL = "SELECT a.*, b.tenhangsanxuat as tenhangsx FROM THUOC a join HANGSANXUAT b on a.idhangsanxuat=b.idhangsanxuat ";
            strSQL +="WHERE 1 =1 " + swhere + "  ORDER BY tenthuoc ASC ";
            ArrayList arr = data.SQLMultiHashReader(strSQL, conn);
            foreach (Hashtable h in arr)
            {
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" onclick=\"setChonDichVu(" + h["idthuoc"] + ",'" + h["tenthuoc"] + "')\">";
                html += "<td width=\"30%\" class=\"ptext\" >&nbsp;" + h["tenthuoc"] + "</td>";
                html += "<td width=\"45%\" class=\"ptext\">" + h["donvitinh"] + "</td>";
                html += "<td width=\"45%\" class=\"ptext\">" + h["tenhangsx"] + "</td>";
                html += "</tr>";
            }
            html += "<tr><td colspan=\"3\"><br/></td></tr>";

            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    public void LoadVTYTtheonhom()
    {
        string nhom = Request.QueryString["nhom"].ToString();
        string timthuoc = Request.QueryString["timthuoc"].ToString();
        string strSQL = "SELECT idvtyt,tenvtyt+' ('+donvi+')' as ten FROM VTYT_DMVTYT where 1=1";
        if (nhom != "0")
            strSQL += " and manhom ='" + nhom + "'";
        if (timthuoc.Trim() != "")
            strSQL += " and tenvtyt like N'%" + timthuoc + "%'";
        strSQL += " ORDER BY tenvtyt";
        DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        string shtml = "";
        shtml += "<select name=\"ddldmthuoc\" id=\"ddldmthuoc\" style=\"height:19px;width:300px;\" runat=\"server\" tabindex=\"12\" ) >";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i == 0)
            {
                shtml += "<option value=\"" + dt.Rows[i]["idvtyt"].ToString() + "\" ";
                shtml += " selected=\"selected\"";
                shtml += ">" + dt.Rows[i]["ten"].ToString() + "</option>";
            }
            else
            {
                shtml += "<option value=\"" + dt.Rows[i]["idvtyt"].ToString() + "\" ";
                //if (dt.Rows[i]["mathuoc"].ToString() == imatp)
                //{
                //    shtml += " selected=\"selected\"";
                //}
                shtml += ">" + dt.Rows[i]["ten"].ToString() + "</option>";
            }
        }
        shtml += "</select>";
        Response.Write(shtml);
        dt = null;
    }
    //ThuanNH 04/05/2010
    //Load thong tin kho
    private void loadChiTietKho()
    {
        try
        {
            string makho = data.escape(Request.QueryString["makho"]);
            Session["makhoedit"] = makho;
            Hashtable h = data.SQLHashReader("SELECT * FROM khothuoc WHERE makho = '" + makho + "'", conn);
            string html = "";
            html += "<input type = \"hidden\" name = \"idkho\" id = \"idkho\" value = \"" + data.unescape(h["idkho"]) + "\">";
            html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" id=\"user\">";
            html += "<tr><td colspan=\"2\" class=\"header\" background=\"images/header.gif\">Thêm hoặc cập nhật kho mới</td></tr>";
            html += "<tr><td colspan=\"2\"><br /></td></tr><tr>";
            html += "<td width=\"20%\" class=\"tieude\">Mã kho (&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;: </td>";
            html += "<td width=\"80%\" id=\"showtipkho\">";
            html += "<input type=\"text\" name=\"makho\" onChange=\"this.value = this.value.toUpperCase();\" style=\"width:250px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["makho"]) + "\"/>";
            html += "<img src=\"images/quest.gif\" style=\"cursor:pointer;\" align=\"middle\" title=\"click vào để xem danh sách mã kho\"  onclick=\"showDanhSachKho(0)\"/>";
            html += "&nbsp;(&nbsp;<font color=\"red\">*</font>&nbsp;)&nbsp;là các thông tin bắt buộc</td></tr><tr>";
            html += "<td width=\"20%\" class=\"tieude\">Tên kho : </td><td width=\"80%\">";
            html += "<input type=\"text\" name=\"tenkho\" style=\"width:400px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["tenkho"]) + "\"/>";
            html += "<span class=\"ajax\" id=\"ajaxkho\" style=\"display:none;\">";
            html += "<img src=\"images/processing.gif\" border=\"0\" align=\"absmiddle\" />&nbsp;&nbsp;kiểm tra mã kho...";
            html += "</span></td></tr>";
            //ThuanNH 04/05/2010

            html += "<tr><td width=\"20%\" class=\"tieude\">Tài khoản kho : </td><td width=\"80%\">";
            html += "<input type=\"text\" name=\"taikhoankho\" style=\"width:400px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["taikhoankho"]) + "\"/>";
            html += "<span class=\"ajax\" id=\"ajaxkho\" style=\"display:none;\">";
            html += "<img src=\"images/processing.gif\" border=\"0\" align=\"absmiddle\" />&nbsp;&nbsp;kiểm tra tài khoản kho...";
            html += "</span></td></tr>";
            html += "<tr><td width=\"20%\" class=\"tieude\">Tài khoản GV: </td><td width=\"80%\">";
            html += "<input type=\"text\" name=\"taikhoanGV\" style=\"width:400px\" class=\"text\" onmouseout=\"this.className='text'\" onmouseover=\"this.className='textover'\" value=\"" + data.unescape(h["taikhoangiavon"]) + "\"/>";
            html += "<span class=\"ajax\" id=\"ajaxkho\" style=\"display:none;\">";
            html += "<img src=\"images/processing.gif\" border=\"0\" align=\"absmiddle\" />&nbsp;&nbsp;kiểm tra tài khoản GV...";
            html += "</span></td>";
            html += "</tr>";
            //------------------
            html += "<tr><td colspan=\"2\" align=\"center\" id=\"functionkho\"><br/>";
            html += "<input type=\"button\" name=\"new\" onclick=\"newKho()\" value=\"Tạo mới\" style=\"width:80px;\"/>&nbsp;&nbsp;";
            html += "<input type=\"button\" name=\"luu\" onclick=\"saveupdatekho()\" value=\"Cập nhật\" style=\"width:80px;\"/>&nbsp;&nbsp;";
            html += "<input type=\"reset\" name=\"cancel\" value=\"Làm lại\" style=\"width:80px;\"/>&nbsp;&nbsp;";
            html += "<input type=\"button\" name=\"xoa\" value =\"Xóa\" onclick=\"deletekho('checkall')\" style=\"width:80px;\" />&nbsp;&nbsp;";
            html += "<span class=\"ajax\" id=\"ajaxdanhmuckho\" style=\"display:none;\"><img src=\"images/processing.gif\" border=\"0\" />&nbsp;đang load dữ liệu ...</span>";
            html += "</td></tr></table>";
            Response.Write(html);
            html = "";
            h = null;

        }
        catch (Exception)
        {
            Response.Write("error");
        }
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
            ArrayList arr = data.SQLMultiHashReader(sql, DataAcess.Connect.GetConnection());
            foreach (Hashtable h in arr)
            {

                html += "| <div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonNCC('" + h["NhaCungCapId"] + "','" + h["MaNhaCungCap"] + "','" + h["TenNhaCungCap"] + "')\">";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + h["MaNhaCungCap"] + "</p>";
                html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + h["TenNhaCungCap"] + "</p>";
                html += "</div>|" + h["NhaCungCapId"] + "|" + h["MaNhaCungCap"] + "|" + h["TenNhaCungCap"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }

    }
    //Check ma kho co ton tai hay chua
    private void CheckMakhoFromKho()
    {
        try
        {
            string makho = data.escape(Request.QueryString["makho"]);
            int count = data.ParseInt(data.SQLScalar("SELECT count(makho) FROM khothuoc WHERE makho = '" + makho + "'", conn));
            Response.Write(count == 0 ? 2 : 1);
        }
        catch (Exception)
        {
            Response.Write(0);
        }
    }
      #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(common_unload);
    }
    private void common_unload(object sender, System.EventArgs e)
    {
        conn.Dispose();
        conn.Close();
        conn = null;
    }
    #endregion
}

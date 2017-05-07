namespace Process_2608 {
 public class TBLS{
 public enum tbl_VTYT_nuocsanxuat{
            idnuocsanxuat,
            tentat,
            nuocsanxuat
}
//──────────────────────────────────────────────────
 public enum tbl_nguoidung_host{
            idnguoidung,
            IdClient,
            tenphongkham
}
//──────────────────────────────────────────────────
 public enum tbl_PHIEU_NHAP_VT{
            phieu_nhap_id,
            so_phieu,
            ngay_nhap,
            ma_ncc,
            ten_ncc,
            tk_co,
            dien_giai,
            so_hd,
            ngay_lap_hd,
            so_seri
}
//──────────────────────────────────────────────────
 public enum tbl_KB_PhieuThanhToan{
            Id,
            MaSo,
            SoVV,
            IdBenhNhan,
            IdKhoa,
            Buong,
            Giuong,
            TGVaoVien,
            TGXuatVien,
            ChanDoan,
            KinhPhiSN,
            TienBHYT,
            TienTongCong,
            PhaiTra,
            BienLaiSo,
            CongKham,
            dathu,
            IdKhamBenh,
            idchitietdangkykham,
            TamUng,
            ThanhToan,
            benhsu,
            DichVuKCBID,
            idbacsi,
            idchandoan,
            IdChuyenPK,
            idkhambenhchuyenphong,
            isNoiTru,
            machuandoan,
            NGAYCT,
            NgayXuatVien,
            PhongID,
            SOCT,
            trieuchung
}
//──────────────────────────────────────────────────
 public enum tbl_chitietbenhnhantoathuoc{
            idchitietbenhnhantoathuoc,
            idbenhnhantoathuoc,
            idthuoc,
            soluongke,
            soluongbanra,
            dongia,
            ngayuong,
            moilanuong,
            donvidung,
            ghichu,
            bacsixoa,
            quaythuocxoa,
            thoigiandung,
            tenNgaydung,
            thanhtien,
            heso,
            IdThuoc1,
            idkhambenh,
            idkho,
            soluongtra,
            IsDaYeuCau,
            IsDaXuatTra,
            DoiTuongThuocID,
            isdathu,
            SoLuongTheoDonVi,
            cachdung,
            cateid,
            idcachdung,
            iddvdung,
            iddvt,
            ischieu,
            isdahuy,
            isngay,
            issang,
            istoi,
            istrua,
            istuan,
            ngayratoa,
            TienThucthu
}
//──────────────────────────────────────────────────
 public enum tbl_ChiTietCLSGoiPhauThuat{
            idchitietCLSPhauThuat,
            idgoiphauthuat,
            idcanlamsang,
            idloaiphauthuat,
            giatrongoi,
            giabinhthuong,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_KB_ChiTietNhomCLS{
            Id,
            NhomID,
            idbanggiadichvu,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_VTYThangsanxuat{
            idhangsx,
            tenhang,
            diachi,
            nguoilienhe,
            dienthoai
}
//──────────────────────────────────────────────────
 public enum tbl_chitietphieuban{
            idchitietphieuban,
            idphieuban,
            idsanpham,
            soluong,
            dongia,
            imei,
            chuaxuat,
            giamgia,
            idsanphamkm,
            soluong_km,
            idncc
}
//──────────────────────────────────────────────────
 public enum tbl_Phieu_Tong_Hop_Ct{
            phieu_tong_hop_ct_id,
            so_phieu,
            dien_giai,
            ma_doi_tuong,
            tk_no,
            tk_co,
            ps_no,
            ps_co,
            so_seri,
            so_hd,
            ngay_lap_hd,
            thue_suat,
            loai_hoa_don,
            phong_ban
}
//──────────────────────────────────────────────────
 public enum tbl_LichSuPhuCap{
            idLichSuPhuCap,
            idNhanVien,
            Thang,
            Nam,
            idPhuCap,
            LuongCB,
            MucPhuCap,
            SoNgayLam,
            SocaTruc,
            SoBenhNhanKham,
            TongTienPhuCap
}
//──────────────────────────────────────────────────
 public enum tbl_Phieu_TT_Tam_Ung_CT{
            phieu_chi_ct_id,
            so_phieu_chi,
            tk_no,
            ps_no,
            ps_no_nt,
            thue_suat,
            tk_thue,
            tien_thue,
            tien_thue_nt,
            so_hd,
            so_seri,
            ngay_lap_hd,
            tien_tren_hd,
            da_thanh_toan,
            con_phai_thanh_toan,
            thanh_toan,
            dien_giai,
            status_fix
}
//──────────────────────────────────────────────────
 public enum tbl_benhnhan_temp{
            tenbnnam,
            tenbnnu,
            tencha,
            tenme,
            tencontrai,
            tencongai,
            tenanh,
            tenchi
}
//──────────────────────────────────────────────────
 public enum tbl_setting{
            idsetting,
            luongngaychunhat,
            luongtangcatrengio
}
//──────────────────────────────────────────────────
 public enum tbl_sanpham{
            idsanpham,
            tensanpham,
            idhangsanxuat,
            idnhasanxuat,
            giabanhientai,
            nhacungcapid,
            donvitinh,
            ngayhethang,
            imei,
            idnhomsanpham,
            thuexuat,
            nhanhang,
            imeinew,
            hangkm,
            soluong_km,
            quycach
}
//──────────────────────────────────────────────────
 public enum tbl_PhuongPhapVoCam{
            idPhuongPhapVoCam,
            TenPhuongPhapVoCam
}
//──────────────────────────────────────────────────
 public enum tbl_KB_NhomCLS{
            NhomId,
            TenNhom,
            GhiChu,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_VTYTkho{
            idkho,
            tenkho,
            diachi,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_XepLoai{
            idxeploai,
            tenxeploai,
            ghichu,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_NgheNghiep{
            idNgheNghiep,
            MaNgheNghiep,
            TenNgheNghiep
}
//──────────────────────────────────────────────────
 public enum tbl_kb_phongkham{
            id,
            PhongID,
            idbacsi,
            idphongkhambenh
}
//──────────────────────────────────────────────────
 public enum tbl_phieuxuatban{
            ngayxuat,
            idphieuban,
            idphieunhapkhosanpham,
            dongia,
            soluong,
            id_filefault,
            idsanpham
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucQuocGia{
            IDNuoc,
            TenNuoc
}
//──────────────────────────────────────────────────
 public enum tbl_KhachHang{
            IDKhachHang,
            IdBenhNhan,
            makhachhang,
            tenkhachhang,
            diachi,
            dienthoai,
            gioitinh,
            ngaysinh,
            fax,
            dinhdanhimei,
            taikhoannganhang,
            nganhang,
            masothue,
            nguoilienhe
}
//──────────────────────────────────────────────────
 public enum tbl_MauKetQuaCDHA{
            idMauChanDoan,
            idchitietdichvu,
            maloai,
            gioitinh,
            tenmau,
            tenfile,
            duongdan,
            noidung,
            loaimau,
            mucdichnoisoi
}
//──────────────────────────────────────────────────
 public enum tbl_chitietphieunhapkhosanpham{
            idchitietphieunhapkho,
            idphieunhap,
            idsanpham,
            soluong,
            dongia,
            ngayhethan,
            losanxuat,
            chietkhau,
            vat,
            thuenk,
            dgsauchietkhau,
            id_filefault
}
//──────────────────────────────────────────────────
 public enum tbl_NVK_ThanhToanVienPhi{
            IdThanhToan,
            NgayThanhToan,
            IdChiTietDangKyKham,
            SoTienThanhToan,
            TongSoTien,
            SoTienDaDong
}
//──────────────────────────────────────────────────
 public enum tbl_DiaChi{
            idDiaChi,
            MaDiaChi,
            idXa,
            TextDiaChi
}
//──────────────────────────────────────────────────
 public enum tbl_KB_LoiDan{
            Id,
            NoiDung,
            Status,
            Istransfer
}
//──────────────────────────────────────────────────
 public enum tbl_UyNhiemChi{
            SoPhieu,
            Ngay,
            TenDVTra,
            TKNHDVTra,
            NganHangTra,
            TenDVNhan,
            TKNHDVNhan,
            NganHangNhan,
            SoTien,
            NoiDungTT,
            sohoadon
}
//──────────────────────────────────────────────────
 public enum tbl_PHIEU_KE_TOAN{
            phieuketoanid,
            so_phieu,
            ngay_lap
}
//──────────────────────────────────────────────────
 public enum tbl_HS_OutPutDetail{
            OutPutDetailID,
            IdPhieuXuat,
            IdThuoc,
            Quantity,
            UnitID,
            Note,
            Top1IdChiTietPhieuXuatKho
}
//──────────────────────────────────────────────────
 public enum tbl_KB_Parameter{
            Id,
            ParaName,
            ParaValue,
            Description
}
//──────────────────────────────────────────────────
 public enum tbl_phieuxuatkhosanpham{
            idphieuxuat,
            maphieuxuat,
            ngaythang,
            ghichu,
            loaixuat,
            idtukho,
            iddenkho,
            idphieunhap,
            iddoituong,
            tkno,
            tkco,
            tkvat,
            kyhieuhoadon,
            sohoadon,
            ngayhoadon
}
//──────────────────────────────────────────────────
 public enum tbl_CongTy{
            idCongTy,
            hinhthuctraluong,
            chedonangluong,
            baoholaodong,
            baohiemyte,
            tendonvi,
            thoigiolamviec,
            chedonghingoi,
            chedodaotao,
            ngaytraluong
}
//──────────────────────────────────────────────────
 public enum tbl_quoctich{
            idquoctich,
            tenquoctich
}
//──────────────────────────────────────────────────
 public enum tbl_phieunhapkhosanpham{
            idphieunhap,
            maphieunhap,
            ngaythang,
            idkho,
            nhacungcapid,
            kyhieuhd,
            sohoadon,
            ngayhoadon,
            sopo,
            tkno,
            tkco,
            tkvat,
            loaitien,
            tygia,
            tienhangnt,
            tienhang,
            tienvatnt,
            tienvat,
            tongtiennt,
            tongtien,
            thanhtoannt,
            thanhtoan,
            conlaint,
            conlai,
            tienthuenknt,
            tienthuenk,
            nhapcho,
            ghichu,
            ptn
}
//──────────────────────────────────────────────────
 public enum tbl_So_Cai{
            so_cai_Id,
            ma_ct,
            ngay_lap_ct,
            tai_khoan,
            tai_khoan_du,
            ps_no,
            ps_co,
            ps_no_nt,
            ps_co_nt,
            ma_kh,
            dien_giai,
            so_hoa_don,
            so_seri,
            ngay_lap_hd,
            user_dau,
            date_dau,
            user_cuoi,
            date_cuoi,
            status,
            phieu_nhap_vtct_id,
            phieu_nhap_vt_id,
            hoadon_dv_kh_id,
            idphieunhapthuoc,
            idphieubanthuoc,
            thue_suat
}
//──────────────────────────────────────────────────
 public enum tbl_benhnhanCho{
            IDBenhNhanCho,
            idbenhnhan,
            NgayTiepNhan
}
//──────────────────────────────────────────────────
 public enum tbl_KhenThuong{
            idKhenThuong,
            idNhanVien,
            soThiDua,
            loaiThiDua,
            ngayKy,
            lyDo,
            ngayHieuLuc,
            ngayKetThuc,
            HinhThucThanhToan,
            idNguoiKy,
            SoTien
}
//──────────────────────────────────────────────────
 public enum tbl_NuocSX{
            idNuocSX,
            maNuocSX,
            tenNuocSX
}
//──────────────────────────────────────────────────
 public enum tbl_phieuban{
            idphieuban,
            maphieuban,
            ngaythang,
            idnguoiban,
            hoten,
            diachi,
            MaCa,
            tkno,
            tkco,
            tkvat,
            tkkho,
            tkgiavon,
            tienhang,
            tienvat,
            tongtien,
            tienvon,
            phuongthuctt,
            chuaxuat,
            idkhuyenmai,
            theohoadon,
            giamgia,
            idsanphamkm,
            soluong_km,
            lanin,
            MaKenh,
            MaBangGia,
            MaKhachHang
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_LoaiNhap{
            idloainhap,
            tenloainhap,
            TenReport
}
//──────────────────────────────────────────────────
 public enum tbl_Danhmuccalamviec{
            MaCa,
            TenCa,
            ThoiGianBD,
            ThoiGianKT
}
//──────────────────────────────────────────────────
 public enum tbl_PHIEU_NHAP_VT_CT{
            phieu_nhapct_id,
            phieu_nhap_id,
            ma_vt,
            ten_vt,
            ma_kho,
            so_luong,
            don_gia,
            thanh_tien,
            thue_suat,
            tien_thue,
            tong_tien,
            tk_no,
            tk_thue
}
//──────────────────────────────────────────────────
 public enum tbl_PhuCap{
            idphucap,
            tenphucap,
            vitri,
            tienphucap,
            tungay,
            tinhthue,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_KB_LoaiPhi{
            LoaiPhiId,
            TenLoaiPhi,
            IdPhongKhamBenh,
            STT,
            Status,
            Istransfer
}
//──────────────────────────────────────────────────
 public enum tbl_catruc{
            idcatruc,
            tencatruc,
            tientruc,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_phieuxuatkho{
            idphieuxuat,
            maphieuxuat,
            ngaythang,
            ghichu,
            idphongkhambenh,
            nguoinhan,
            xuatcho,
            idkho,
            loaixuat,
            IDKhachHang,
            vat,
            thanhtien,
            ngayhoadon,
            idnhacungcap,
            idkho2,
            idnguoixuat,
            IdBenhNhanToaThuoc,
            IsBHYT,
            SLPX,
            tkNo,
            TKVAT,
            TKCo,
            IdCaPhauThuat,
            IsDaHuy,
            LANSUA,
            MaPhieu,
            NGAYSUA,
            NGUOISUA,
            IdLoaiThuoc,
            IdBenhNhan,
            IDKHAMBENH1,
            IDPHIEUYC,
            SOPHIEUYC
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucKenh{
            MaKenh,
            TenKenh
}
//──────────────────────────────────────────────────
 public enum tbl_chitietdichvu{
            idchitietdichvu,
            idbanggiadichvu,
            tenchitiet,
            giatribinhthuong,
            donvi,
            tennhom
}
//──────────────────────────────────────────────────
 public enum tbl_nghiphep{
            idnhanvien,
            ngaybatdau,
            ngayketthuc,
            lydo,
            loaiphep
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucThanhPho{
            MaThanhPho,
            TenThanhPho
}
//──────────────────────────────────────────────────
 public enum tbl_DMThuocCLS{
            id,
            name,
            maloai
}
//──────────────────────────────────────────────────
 public enum tbl_PHIEU_KE_TOAN_CT{
            phieuketoan_ctid,
            phieuketoanid,
            tai_khoan,
            ma_kh,
            ten_kh,
            ps_no,
            ps_co,
            dien_giai,
            thue_xuat,
            tai_khoan_du
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_DinhMucTonKho{
            IdDinhMuc,
            Idthuoc,
            IdKho,
            SL
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucKhachHang{
            MaKhachHang,
            TenKhachHang,
            NgaySinh,
            DienThoai,
            Mobile,
            Email,
            DiaChi,
            MaThanhPho,
            ThanhPho,
            CoThai,
            TuanThai,
            NgayDuSinh,
            SoCon,
            TuoiBeNhoNhat,
            NgaySinhBeNhoNhat,
            MaKenh,
            Kenh,
            MaNhanVien,
            NgayNhap,
            NgayPhatHanhThe
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucLoaiTien{
            MaLoaiTien,
            TenLoaiTien
}
//──────────────────────────────────────────────────
 public enum tbl_DM_VAT_TU_KT{
            danhmuc_vattu_id,
            ma_vt,
            ten_vt,
            dvt,
            nuoc_sx,
            nam_sx,
            tk_kho,
            tk_khau_hao,
            tk_chi_phi,
            ghi_chu
}
//──────────────────────────────────────────────────
 public enum tbl_dieutrikhachlecanlamsan{
            iddieutrikhachlecanlamsan,
            idkhachlecanlamsan,
            idbacsi,
            ketqua,
            ketluan,
            ngaykham
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucTyGia{
            MaLoaiTien,
            Ngay,
            TyGia,
            GhiChu
}
//──────────────────────────────────────────────────
 public enum tbl_ThietLapCa{
            idthietlapca,
            idphongban,
            ngaythu,
            tungay,
            denngay,
            idcalamviec,
            sonhanvien,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_hs_DangKyCLS{
            IdDangKyCLS,
            MaPhieuCLS,
            NgayDK,
            NguoiDK,
            IDBENHNHAN
}
//──────────────────────────────────────────────────
 public enum tbl_DMMucDichNoiSoi{
            id,
            name
}
//──────────────────────────────────────────────────
 public enum tbl_PhanBoCCDC{
            SoPhieu,
            MaCCDC,
            TenCCDC,
            Thang,
            Nam,
            TongGiaTri,
            GiaTriPB,
            TongSoLanPB,
            SoLanPBConLai,
            TaiKhoanNo,
            TaiKhoanCo,
            DienGiai
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucTKNH{
            ID,
            SoHieuTKNH,
            TenTKNH,
            TaiKhoanKT
}
//──────────────────────────────────────────────────
 public enum tbl_Hoa_Don_DV_CT_Kh{
            hoadon_ctkh_id,
            so_hd,
            ma_hang,
            ten_hang,
            dvt,
            so_luong,
            don_gia,
            thanh_tien,
            tk_co
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_HeSoApGia{
            GiaThuocID,
            IdThuoc,
            TuNgay,
            HeSo,
            Status,
            Istranfers
}
//──────────────────────────────────────────────────
 public enum tbl_THTAIKHOAN2011{
            TaiKhoan,
            Cap,
            CapTren,
            ChiTiet,
            LoaiTien,
            VNNO_00,
            VNCO_00,
            NTNO_00,
            NTCO_00,
            VNNO_01,
            VNCO_01,
            NTNO_01,
            NTCO_01,
            VNNO_02,
            VNCO_02,
            NTNO_02,
            NTCO_02,
            VNNO_03,
            VNCO_03,
            NTNO_03,
            NTCO_03,
            VNNO_04,
            VNCO_04,
            NTNO_04,
            NTCO_04,
            VNNO_05,
            VNCO_05,
            NTNO_05,
            NTCO_05,
            VNNO_06,
            VNCO_06,
            NTNO_06,
            NTCO_06,
            VNNO_07,
            VNCO_07,
            NTNO_07,
            NTCO_07,
            VNNO_08,
            VNCO_08,
            NTNO_08,
            NTCO_08,
            VNNO_09,
            VNCO_09,
            NTNO_09,
            NTCO_09,
            VNNO_10,
            VNCO_10,
            NTNO_10,
            NTCO_10,
            VNNO_11,
            VNCO_11,
            NTNO_11,
            NTCO_11,
            VNNO_12,
            VNCO_12,
            NTNO_12,
            NTCO_12
}
//──────────────────────────────────────────────────
 public enum tbl_DMMayCLS{
            id,
            name,
            maloai
}
//──────────────────────────────────────────────────
 public enum tbl_benhannoivien{
            idbenhannoivien,
            idnhapvien,
            idbacsi,
            ngaythang,
            thongtinbenhan,
            chidinhdieutri,
            chidinhlamsan,
            chidinhchamsocdinhduong,
            dienbienbenh
}
//──────────────────────────────────────────────────
 public enum tbl_candoikt{
            stt,
            chi_tieu,
            ma_so,
            thuyet_minh,
            so_cuoi_nam,
            so_dau_nam,
            tai_khoan,
            tai_ngay,
            dien_giai,
            bold,
            cap,
            captren,
            chitieu,
            cuoiky,
            dauky,
            diengiai,
            maso,
            socuoiky,
            sodauky
}
//──────────────────────────────────────────────────
 public enum tbl_category{
            cateid,
            catename,
            des,
            dinhdanhimei,
            loaithuocid,
            SoTT
}
//──────────────────────────────────────────────────
 public enum tbl_khambenh{
            idkhambenh,
            maphieukham,
            ngaykham,
            idbenhnhan,
            iddangkykham,
            idbacsi,
            trieuchung,
            benhsu,
            chandoanbandau,
            ketluan,
            ketluan1,
            ketluan2,
            huongdieutri,
            phongkhamchuyenden,
            ghichuhuongdieutri,
            chidinhbacsi,
            dando,
            noidungtaikham,
            ngayhentaikham,
            hoantat,
            idphongkhambenh,
            TienSu,
            SoPhieuTT,
            idPhongChuyenDen,
            thuChuyenPhong,
            idDVPhongChuyenDen,
            IdChiTietDangKyKham,
            ChanDoanTuyenDuoi,
            isNoiTru,
            idkhambenhgoc,
            sovaovien,
            IdDieuDuong,
            IsDaRaVien,
            isdathanhtoan,
            tinhtrangtaikham,
            ishoantatcls,
            IdPhong,
            ngayDuTruThuoc,
            idkhambenhmoi,
            BienLaiSo,
            Buong,
            ChanDoan,
            CongKham,
            dathu,
            DichVuKCBID,
            Giuong,
            Id,
            idchandoan,
            IdChuyenPK,
            idkhambenhchuyenphong,
            IdKhoa,
            IdkhoaChuyen,
            IsChuyenPhongCoPhi,
            IsXuatVien,
            KinhPhiSN,
            machuandoan,
            MaSo,
            NGAYCT,
            NgayXuatVien,
            PhaiTra,
            PhongID,
            SOCT,
            SoNgayRaToa,
            SoVV,
            TGVaoVien,
            TGXuatVien,
            TienBHYT,
            TienTongCong,
            IsHaveCLS,
            IsTaiKham,
            IsChoVeKT,
            IsChuyenVien,
            IdBenhVienChuyen,
            IsKhongKham,
            idbacsi2,
            IsBSMoiKham,
            ISDAXUATTOATHUOC,
            ISHAVETHUOCBH
}
//──────────────────────────────────────────────────
 public enum tbl_congthucketchuyen{
            MaKC,
            TenKC,
            STT,
            TuTaiKhoan,
            DenTaiKhoan,
            PhuongPhap,
            CongThuc,
            GiaTri,
            status_kc
}
//──────────────────────────────────────────────────
 public enum tbl_TangCa{
            idtangca,
            idloaitangca,
            ngaytangca,
            tugio,
            dengio,
            sogiotangca,
            sogioduocduyet,
            daduyet,
            dakiemtra,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_ServerOption{
            DATA_ComputerName,
            DATA_MAC,
            DATA_UserName,
            DATA_PassWord,
            DATA_SharedPath
}
//──────────────────────────────────────────────────
 public enum tbl_NhanVien{
            idnhanvien,
            manhanvien,
            tennhanvien,
            ngaysinh,
            gioitinh,
            diachitamtru,
            dienthoai,
            didong,
            diachithuongtru,
            email,
            tinhtranghonnhan,
            ngayvaolam,
            idphongban,
            idchucvu,
            status,
            quoctich,
            nghenghiep,
            cmnd,
            ngaycapCMND,
            noicapCMND,
            solaodong,
            ngaycapSLD,
            noicapSLD,
            phuongtiendilai,
            noisinh,
            TrinhDo,
            chuyenmon,
            LoaiNhanVien
}
//──────────────────────────────────────────────────
 public enum tbl_nvk_chanDoanNhapKhoa{
            idCdNhapKhoa,
            idnoitru,
            idicd
}
//──────────────────────────────────────────────────
 public enum tbl_phieuchinhacungcap{
            phieuchiid,
            ngaychi,
            sophieuchi,
            nguoichi,
            nhacungcapid,
            sotien,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_PhieuThu{
            IdPhieuThu,
            SoPhieu,
            Ngaythu,
            IdKhachHang,
            NoiDung,
            SoTien,
            IdPhieuXuat,
            Status,
            IdNCC
}
//──────────────────────────────────────────────────
 public enum tbl_chitietkhachnhaptra{
            idchitietkhachnhaptra,
            idphieunhaptra,
            idchitiettoathuoc,
            soluong
}
//──────────────────────────────────────────────────
 public enum tbl_chitietphieuxuatkho{
            idchitietphieuxuat,
            idphieuxuat,
            idthuoc,
            soluong,
            dongia,
            idchitietphieunhapkho,
            idtu,
            idngan,
            sluongxuat,
            dvt,
            thanhtien,
            thanhtientruocthue,
            tienthue,
            chietkhau,
            giavon,
            tienvon,
            tiensauchietkhau,
            tienchietkhau,
            IDCHITIETPHIEUYEUCAUXUATKHO,
            tkkho,
            tkco,
            idchitietbenhnhantoathuoc,
            idThuocPhauThuat,
            VAT,
            IDKHO_XUAT,
            NGAYTHANG_XUAT,
            LOSANXUAT_XUAT,
            NGAYHETHAN_XUAT,
            IDLOAIXUAT_XUAT,
            BHTra,
            BNDaTra,
            BNTra,
            DonGiaBH,
            DonGiaDV,
            IsBHYT,
            ISBNDaTra,
            IsDaHuy,
            NGAYTINHBH_THUC,
            PrevBNTra,
            SL_Prev,
            ThanhTien_Prev,
            ThanhTienBH,
            ThanhTienDV,
            OutPutDetailID,
            IDKHAMBENH1
}
//──────────────────────────────────────────────────
 public enum tbl_HopDong{
            idhopdong,
            idnhanvien,
            idloaihopdong,
            masohopdong,
            ngayky,
            ngaybatdau,
            ngayketthuc,
            thoihanhopdong,
            noiky,
            chuyenmon,
            mucluongcoban,
            giolam,
            motacongviec,
            status,
            thuviectungay,
            thuviecdenngay,
            diadiemlamviec,
            thoathuankhac,
            dungculamviec,
            luongCB,
            HeSoLCB,
            noidunghopdong,
            SoHopDong,
            isCoBaoHiem
}
//──────────────────────────────────────────────────
 public enum tbl_VTYT_HangSo{
            chuc,
            tram,
            nghin,
            chucnghin,
            tramnghin,
            trieu,
            chuctrieu,
            tramtrieu,
            ty,
            chucty,
            tramty,
            nghinty
}
//──────────────────────────────────────────────────
 public enum tbl_thuoc_giaban1{
            idkey,
            idthuoc,
            giaban,
            thang,
            nam
}
//──────────────────────────────────────────────────
 public enum tbl_ChiTietNhomNSD{
            IDNhom,
            IDNguoiDung
}
//──────────────────────────────────────────────────
 public enum tbl_nhacungcap{
            nhacungcapid,
            manhacungcap,
            tennhacungcap,
            nguoilienhe,
            diachi,
            dienthoai,
            fax,
            hanmuctindung,
            taikhoannganhang,
            nganhang,
            masothue,
            dinhdanhimei,
            IsKT
}
//──────────────────────────────────────────────────
 public enum tbl_benhnhan{
            idbenhnhan,
            mabenhnhan,
            tenbenhnhan,
            lacon,
            idlacon,
            laanhem,
            idloaiuutien,
            diachi,
            dienthoai,
            gioitinh,
            ngaysinh,
            chungminhthu,
            hinhanh,
            chieucao,
            cannang,
            huyetap,
            nhiptim,
            loai,
            tiensubenhnhan,
            tinhtrangbandau,
            sobhyt,
            ngaybatdau,
            ngayhethan,
            thongtinbaotin,
            tencongty,
            thongtincongty,
            idloaibh,
            nghenghiep,
            noicongtac,
            noigioithieu,
            noidangkykcb,
            chandoansobo,
            ngaytiepnhan,
            DungTuyen,
            email,
            Mtlv,
            MTs,
            Sktl,
            SkAU,
            phuongtien,
            nhommau,
            benhvemau,
            NguoiLH,
            DiaChiLH,
            DienThoaiLH,
            tenDN,
            matKhau,
            noicapbhyt,
            MaDangKy_KCB_bandau,
            NameNotSign,
            tinhid,
            quanhuyenid,
            phuongxaid,
            sonha,
            idNoiGioiThieu,
            SoThang,
            QuocTich,
            DanToc,
            MucHuongBH,
            isgiaychuyen,
            IsCapCuu,
            IsDungTuyen,
            sobh1,
            sobh2,
            sobh3,
            sobh4,
            sobh5,
            sobh6,
            SOTT,
            SoTuoi
}
//──────────────────────────────────────────────────
 public enum tbl_chitietkhoanhaptra{
            idchitietkhoanhaptra,
            idphieunhaptra,
            idchitietphieuxuat,
            soluong
}
//──────────────────────────────────────────────────
 public enum tbl_NhomNSD{
            IDNhom,
            TenNhom,
            TenGroup,
            Cap,
            IDNhomCha,
            ChiTietGroup,
            IDNguoiDung
}
//──────────────────────────────────────────────────
 public enum tbl_ChiTietKhoaDaoTao{
            IdChiTietKhoaDaoTao,
            IdKhoaDaoTao,
            IdNhanVien,
            NgayDangKy,
            DaDong,
            status,
            GhiChu
}
//──────────────────────────────────────────────────
 public enum tbl_nhomsanpham{
            idnhomsanpham,
            cateid,
            manhom,
            tennhom,
            dinhdanhimei
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucTK{
            IDTaiKhoan,
            TaiKhoan,
            TenTaiKhoan,
            ChiTiet,
            TKCapCha,
            Cap,
            LoaiTien
}
//──────────────────────────────────────────────────
 public enum tbl_chitietphieunhaptra{
            idchitietphieunhaptra,
            idphieunhaptra,
            idchitietphieunhapkho,
            soluong
}
//──────────────────────────────────────────────────
 public enum tbl_DonDatHang{
            SoPO,
            Ngay,
            MaKH,
            MaHang,
            SoLuong,
            DonGia,
            ThanhTien,
            DienGiai,
            NguoiDaiDien,
            ChucVu,
            DTDD,
            NguoiLienHe,
            ChucVu1,
            DTDD1,
            NguoiLienHeA,
            ChucVuA,
            DTDDA,
            isthuoc
}
//──────────────────────────────────────────────────
 public enum tbl_NgayNghiCongTy{
            idngaynghicongty,
            idloaingaynghi,
            ghichu,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_quatrinhdieutrinoivien{
            idquatrinhdieutri,
            idnhapvien,
            ngaydieutri,
            idbacsi,
            trieuchung,
            chandoan,
            ketquahoichan,
            yeucaucanlamsan,
            ketquacanlamsan,
            yeucaukhamchuyenkhoa,
            ketquakhamchuyenkhoa,
            yeucauthuchienthuthuat,
            ketquathuchienthuthuat,
            ketquadieutri
}
//──────────────────────────────────────────────────
 public enum tbl_Hoa_Don_DV_CT_Khac{
            hoa_don_ctid,
            so_hoa_don,
            ten_dich_vu,
            tk_co,
            tien_dv,
            id_ct
}
//──────────────────────────────────────────────────
 public enum tbl_KB_BangGiaGiuong{
            BangGiaGiuongId,
            GiuongId,
            TuNgay,
            GiaBH,
            GiaDV,
            GiaNgoaiGio,
            Status,
            IsTransfer
}
//──────────────────────────────────────────────────
 public enum tbl_Ngaylamviec{
            IDBSNgaylamviec,
            Idphongkhambenh,
            Idbacsi,
            Ngaylamviec,
            CoLV,
            idnguoidung,
            Ngaytrongtuan
}
//──────────────────────────────────────────────────
 public enum tbl_category_sanpham{
            cateid,
            catename,
            des,
            dinhdanhimei
}
//──────────────────────────────────────────────────
 public enum tbl_TienGiuongXuatKhoa{
            id,
            ngayTinh,
            idchitietdangkykham,
            idkhoa,
            tongTienGiuong,
            idNguoiDung
}
//──────────────────────────────────────────────────
 public enum tbl_ChiTietTangCa{
            idchitiettangca,
            idtangca,
            idnhanvien
}
//──────────────────────────────────────────────────
 public enum tbl_HS_TONKHO_View{
            IdTonKho,
            IdKho,
            TuNgay,
            DenNgay,
            LoaiThuocID,
            IdThuoc,
            TenThuoc,
            IsOrderByName,
            IsHaveDonGia,
            IsSoLuong,
            IsRutGon
}
//──────────────────────────────────────────────────
 public enum tbl_KB_MucBaoHiem{
            Id,
            TuNgay,
            MaQuyen,
            DoiTuong,
            QuyenLoiChung,
            KyThuatCao,
            TLTT,
            VanChuyen,
            GhiChu,
            KyHieu,
            Hang1,
            Hang2,
            Hang3
}
//──────────────────────────────────────────────────
 public enum tbl_khachnhaptra{
            idphieunhaptra,
            ngaynhaptra,
            sonhaptra,
            idtoathuoc,
            lydo
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_PhieuChi{
            IdPhieuChi,
            SoPhieu,
            NgayChi,
            IdNCC,
            NoiDung,
            SoTien,
            Status,
            IdKhachHang
}
//──────────────────────────────────────────────────
 public enum tbl_KB_Giuong{
            GiuongId,
            GiuongCode,
            LoaiGiuong,
            DVT,
            Status,
            IsTransfer,
            idPhong,
            nvk_isGiuongCho
}
//──────────────────────────────────────────────────
 public enum tbl_DangKyCa{
            iddangkyca,
            idnhanvien,
            idcalamviec,
            thu,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_HS_TonKhoViewDetail{
            IdTonKhoDetail,
            IdTonKho,
            TTHC,
            TenSP,
            TENDVT,
            Dongia,
            DAUKY_SL,
            DAUKY_TT,
            NHAP_SL,
            NHAP_TT,
            NHAP_SL2,
            NHAP_TT2,
            XUAT_SL,
            XUAT_TT,
            XUAT_SL2,
            XUAT_TT2,
            CUOIKY_SL,
            CUOIKY_TT,
            CATENAME,
            NHOMTHUOC,
            DES,
            IdThuoc
}
//──────────────────────────────────────────────────
 public enum tbl_KB_NhomDichVu{
            IdNhomDichVu,
            IdChuongDichVu,
            IdBangGiaDichVu,
            IsDaKhoa,
            TenNhom
}
//──────────────────────────────────────────────────
 public enum tbl_phieunhaptra{
            idphieunhaptra,
            ngaynhaptra,
            sonhaptra,
            idphieunhap,
            lydo
}
//──────────────────────────────────────────────────
 public enum tbl_KB_GiuongPhieuThanhToan{
            IDGiuong,
            IdPTT,
            TenGiuong,
            DonVi,
            SoLuong,
            DonGia,
            ThanhTien,
            IdBacSi,
            idchitietdangkykham,
            ngayxetgiuong,
            idgiuongxet,
            isChonTrongNgay,
            isChonNgaysau,
            songay
}
//──────────────────────────────────────────────────
 public enum tbl_DanhGiaCuoiNam{
            iddanhgia,
            idnhanvien,
            idxeploai,
            ghichu,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_luuchuyentiente{
            idlctt,
            chitieu,
            maso,
            thuyetminh,
            congthuc,
            namnay,
            namtruoc,
            dstk_no,
            dstk_co,
            bold
}
//──────────────────────────────────────────────────
 public enum tbl_banggiadichvu{
            idbanggiadichvu,
            TenNhom,
            tendichvu,
            mota,
            giadichvu,
            daxoa,
            idphongkhambenh,
            giausd,
            ptdieutri,
            ptchidinh,
            GiaBH,
            PhuThuBH,
            PhuThuPK,
            IsKTC,
            madichvu,
            IsBatBuocthu,
            BHTra,
            IDLoaiCLS,
            IsSuDungChoBH,
            HangTraiTuyen,
            TTUUCapCuu_Nhom,
            TTUTCapCuu_DV,
            IsChuyenKhoa,
            IsCLS,
            nMax,
            TenBaoHiem,
            IsVC
}
//──────────────────────────────────────────────────
 public enum tbl_du_dau_ncc{
            ma_kh,
            tai_khoan,
            du_no0,
            du_co0
}
//──────────────────────────────────────────────────
 public enum tbl_Phieu_Chi{
            phieu_chi_id,
            so_phieu_chi,
            ngay_chi,
            ma_ncc,
            nguoi_giao,
            dien_giai,
            loai_nt,
            ty_gia,
            tk_co,
            tien,
            tien_nt,
            user_dau,
            date_dau,
            user_cuoi,
            date_cuoi,
            status,
            istttu
}
//──────────────────────────────────────────────────
 public enum tbl_phongkhambenh{
            idphongkhambenh,
            maphongkhambenh,
            tenphongkhambenh,
            truongphong,
            loaiphong,
            ishoptac,
            kyhieu,
            IsNoiTru,
            Parrent
}
//──────────────────────────────────────────────────
 public enum tbl_TienPhuCap{
            idtienphucap,
            idnhanvien,
            idphucap,
            thangnam,
            soluong,
            tienphucap,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_ChiTietXuatVTYT{
            SoPhieu,
            NgayPhatSinh,
            MaBoPhan,
            MaKhoXuat,
            MaKhoNhap,
            MaVatTu,
            SoLuong,
            DonGia,
            ThanhTien,
            SoLo,
            HanSuDung,
            GhiChu
}
//──────────────────────────────────────────────────
 public enum tbl_sinhhieu{
            idsinhhieu,
            idbenhnhan,
            ngaydo,
            mach,
            nhietdo,
            huyetap1,
            huyetap2,
            nhiptho,
            chieucao,
            cannang,
            tiensubenh,
            BMI,
            diungthuoc,
            Iddangkykham,
            idchitietdangkykham,
            idkhoasinhhieu,
            idnguoidung
}
//──────────────────────────────────────────────────
 public enum tbl_Phieu_Thu{
            phieu_thu_id,
            so_phieu_thu,
            ngay_thu,
            ma_kh,
            nguoi_nop,
            dien_giai,
            loai_nt,
            ty_gia,
            tk_no,
            tien,
            tien_nt,
            user_dau,
            date_dau,
            user_cuoi,
            date_cuoi,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_LuongNhanVien{
            idluongnhanvien,
            idnhanvien,
            luongcanban,
            luongngoaigio,
            tienthuong,
            tienphat,
            baohiemYT,
            baohiemXH,
            thuethunhap,
            status,
            baohiemThatNghiep,
            thang,
            nam,
            idhopdong,
            chucvu,
            SoNgayPhepLuong,
            SoNgayPhepKLuong,
            LuongCBHeSo,
            soGioThang,
            LuongMotNgay,
            TongLuongThuong,
            TongLuongTruc,
            TongLuongLamThem,
            TruVoKyLuat,
            TienPhuCapTrachNhiem,
            TienPhuCapDocHai,
            TienPhuCapHienVat,
            TienPhuCapBoiDuong,
            SoGioNgoaiGio,
            TongLuongNgoaiGio,
            PhuCapQuyLuong,
            TongLuongThucNhan
}
//──────────────────────────────────────────────────
 public enum tbl_VTYT_NhapLyLich{
            Sophieunhap,
            Sohoadon,
            Idnhacungcap,
            NgayNhap,
            Ngayhoadon,
            VAT,
            Tennguoigiao,
            GhiChu,
            NgayUD,
            MaNx,
            locked
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_CongNoNCC{
            Id,
            IdNCC,
            nYear,
            nMonth,
            Debit,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_Sochungtu{
            STT,
            NgayCT,
            SophieuCT,
            dahuy,
            HoTen,
            NoiDung,
            SoTien,
            SoDangKy,
            QuyenSo,
            IDBenhNhan
}
//──────────────────────────────────────────────────
 public enum tbl_dangkykham{
            iddangkykham,
            maphieudangky,
            idbenhnhan,
            ngaydangky,
            idnguoidung,
            dosinhhieu,
            idbacsichidinh,
            iddieuduong,
            phuthubhyt,
            dathu,
            ngayxacnhan,
            dahuy,
            LoaiKhamID,
            STTDKK,
            IdNguoiThu,
            taikhoanno,
            taikhoanco,
            lydo,
            MaSoKhamBenh,
            ishoantra,
            ChuyenTuIdDKK,
            IdBenhBHDongTien,
            IDKHAMBENH_CHUYEN,
            MaPhieu
}
//──────────────────────────────────────────────────
 public enum tbl_KCB_CapCuu{
            idkcbcapcuu,
            idkhambenh,
            benhly,
            tiensubanthan,
            tiensugiadinh,
            khambenhtoanthan,
            khambenhcacbophan,
            ketquacanlamsan,
            chandoanbandau,
            xuly,
            chandoanravien,
            ngaybatdaudieutri,
            ngayketthucdieutri,
            benhlyvadienbien,
            ketquacanlamsancogiatri,
            chandoanravienchinh,
            chandoanravienkemtheo,
            phuongphapdieutri,
            tinhtrangravien,
            huongdieutritieptheo,
            idbacsi
}
//──────────────────────────────────────────────────
 public enum tbl_nhomthuoc{
            idnhomthuoc,
            cateid,
            manhom,
            tennhom,
            dinhdanhimei
}
//──────────────────────────────────────────────────
 public enum tbl_tiepnhandoanhthu{
            matiepnhan,
            ngaytiepnhan,
            nguoitiepnhan,
            TaiKhoanNo,
            TaiKhoanCo,
            TaiKhoanNH,
            nguoinop,
            SoHoaDon,
            NgayHoaDon,
            sotien,
            ghichu,
            bophannop,
            idbenhnhan,
            nguoinopc,
            masothue,
            SoHoaDonC,
            NgayHoaDonC,
            KyHieuHD,
            sotienc,
            vat,
            tienvat,
            ck,
            loaitien,
            tygia,
            donvinhan,
            donvinop,
            UNC,
            isKhac,
            userid
}
//──────────────────────────────────────────────────
 public enum tbl_UserProfile{
            EPID,
            UserID,
            PermID,
            Status,
            IsTransfer
}
//──────────────────────────────────────────────────
 public enum tbl_PhanCa{
            idphanca,
            idnhanvien,
            ngaythangnam,
            thu,
            idcalamviec,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_VTYT_NhomVTYT{
            MANHOM,
            TENNHOM,
            QLyHanDung,
            QLySoLo
}
//──────────────────────────────────────────────────
 public enum tbl_KCB_PhuongPhapDieuTri{
            idphuongphapdieutri,
            idkcbkhoangoai,
            thoigiandieutri,
            phuongphap,
            bacsiphauthuat,
            bacsigayme
}
//──────────────────────────────────────────────────
 public enum tbl_nhomnguoidung{
            nhomID,
            tennhom,
            nhomLinks,
            isadmin,
            motta,
            istiepnhan,
            NameNotSign
}
//──────────────────────────────────────────────────
 public enum tbl_PHIEU_XUAT_VT{
            phieu_xuat_id,
            so_phieu,
            ngay_xuat,
            ma_kh,
            ten_kh,
            dien_giai
}
//──────────────────────────────────────────────────
 public enum tbl_Hoa_Don_DV_CT{
            hoa_don_ctid,
            so_hoa_don,
            ma_phieu_thu,
            ngay_thu,
            ma_bn,
            tien_thu,
            bao_hiem_tra
}
//──────────────────────────────────────────────────
 public enum tbl_nguoidung{
            idnguoidung,
            tennguoidung,
            username,
            matkhau,
            dienthoai,
            isadmin,
            nhomID,
            IdBacSi,
            IdClient,
            IdNhanVien
}
//──────────────────────────────────────────────────
 public enum tbl_NgayNghiNhanVien{
            idngaynghinhanvien,
            idnhanvien,
            ngaybatdau,
            ngayketthuc,
            songaynghi,
            lydo,
            truluong,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_VTYT_TonDau{
            idton,
            idthuoc,
            Soluong,
            dongia,
            handung,
            solo,
            ngaynhap,
            thang,
            nam
}
//──────────────────────────────────────────────────
 public enum tbl_kcb_khoanoi{
            idkcbkhoanoi,
            idkhambenh,
            idbacsi,
            ngayvaovien,
            tructiepvaocapcuu,
            tructiepvaoKKB,
            tructiepvaokhoa,
            coquangioithieu,
            tuden,
            khac,
            vaovienlan,
            vaokhoa,
            thoigianvaokhoa,
            songaydieutri,
            chuyentukhoa,
            thoigianchuyentukhoa,
            songaydieutritukhoa,
            denkhoathunhat,
            thoigianchuyentukhoathunhat,
            songaydieutrikhoathunhat,
            denkhoathuhai,
            thoigianchuyentukhoathuhai,
            songaydieutritukhoathuhai,
            chuyenvientuyentren,
            chuyenvientuyenduoi,
            chuyenvienCK,
            chuyenvienden,
            ngayravien,
            ravien,
            xinve,
            bove,
            duave,
            tongsongaydieutri,
            cd_noichuyenden,
            cd_manoichuyenden,
            cd_noiKKBCapCuu,
            cd_manoiKKBCapCuu,
            cd_khivaokhoadieutri,
            cd_makhoadieutri,
            cd_taibien,
            cd_bienchung,
            cd_phauthuat,
            cd_thuthuat,
            cd_benhchinh,
            cd_mabenhchinh,
            cd_benhkemtheo,
            cd_mabenhkemtheo,
            tt_khoi,
            tt_giam,
            tt_khongthaydoi,
            tt_nanghon,
            tt_tuvong,
            tt_lanhtinh,
            tt_nghingo,
            tt_actinh,
            tt_thoigiantuvong,
            tt_tuvongdobenh,
            tt_tuvongdotaibien,
            tt_tuvongkhac,
            tt_tuvongtrong24h,
            tt_tuvongsau24h,
            tt_nguyennhantuvong,
            tt_manguyennhantuvong,
            tt_khamtuthi,
            tt_chandoangiaiphaututhi,
            tt_magiaiphaututhi,
            hb_quatrinhbenhly,
            hb_tiensubenhbanthan,
            hb_diung,
            hb_thoigiandiung,
            hb_nghienmatuy,
            hb_thoigiannghienmatuy,
            hb_nghienruoubia,
            hb_thoigiannghienruoubia,
            hb_nghienthuocla,
            hb_thoigiannghienthuocla,
            hb_nghienthuoclao,
            hb_thoigiannghienthuoclao,
            hb_lydokhac,
            hb_thoigianlydokhac,
            hb_tiensubenhgiadinh,
            kb_toanthan,
            kb_tuanhoan,
            kb_hohap,
            kb_tieuhoa,
            kb_thantietnieusinhduc,
            kb_thankinh,
            kb_cosuongkhop,
            kb_taimuihong,
            kb_ranghammat,
            kb_mat,
            kb_noitietdinhduong,
            kb_canlamsan,
            kb_benhan,
            chandoankhivaokhoa,
            benhchinh,
            benhkemtheo,
            phanbiet,
            tienluong,
            huongdieutri,
            tk_quatrinhbenhly,
            tk_ketquacanlamsan,
            tk_phuongphapdieutri,
            tk_tinhtrangravien,
            tk_huongdieutritieptheo
}
//──────────────────────────────────────────────────
 public enum tbl_PHIEU_XUAT_VT_CT{
            phieu_xuatct_id,
            phieu_xuat_id,
            ma_vt,
            ten_vt,
            ma_kho,
            so_thang_pb,
            tk_ccdc,
            tk_chi_phi,
            tk_phan_bo,
            so_luong,
            don_gia,
            thanh_tien,
            thue_suat,
            tk_thue,
            tien_thue,
            tong_tien
}
//──────────────────────────────────────────────────
 public enum tbl_DU_DAU_VT{
            dau_ki_vt_id,
            nam,
            ma_vt,
            ten_vt,
            ma_kho,
            tk_vt,
            ton_dau,
            du_dau
}
//──────────────────────────────────────────────────
 public enum tbl_chitiettoathuoc{
            idchitiettoathuoc,
            idtoathuoc,
            idthuoc,
            soluong,
            dongia,
            ngayuong,
            moilan,
            ghichu,
            dongiagoc,
            imei,
            idkho,
            giamgia
}
//──────────────────────────────────────────────────
 public enum tbl_BangChamCong{
            idChamCong,
            idnhanvien,
            idPhanCa,
            NgayChamCong,
            GioVao,
            GioRa,
            IsNghi,
            SoGioCong,
            LuongMotGio,
            HeSoLuong,
            Status,
            idtangca
}
//──────────────────────────────────────────────────
 public enum tbl_benhnhantoathuoc{
            idbenhnhantoathuoc,
            matoathuoc,
            idkhambenh,
            idbacsi,
            idbenhnhan,
            ngayratoa,
            idnguoiban,
            ngayban,
            ghichu,
            bacsixoa,
            quaythuocxoa,
            idphieuthanhtoan
}
//──────────────────────────────────────────────────
 public enum tbl_kcb_khoangoai{
            idkcbkhoangoai,
            idkhambenh,
            idbacsi,
            ngayvaovien,
            tructiepvaocapcuu,
            tructiepvaoKKB,
            tructiepvaokhoa,
            coquangioithieu,
            tuden,
            khac,
            vaovienlan,
            vaokhoa,
            thoigianvaokhoa,
            songaydieutri,
            chuyentukhoa,
            thoigianchuyentukhoa,
            songaydieutritukhoa,
            denkhoathunhat,
            thoigianchuyentukhoathunhat,
            songaydieutrikhoathunhat,
            denkhoathuhai,
            thoigianchuyentukhoathuhai,
            songaydieutritukhoathuhai,
            chuyenvientuyentren,
            chuyenvientuyenduoi,
            chuyenvienCK,
            chuyenvienden,
            ngayravien,
            ravien,
            xinve,
            bove,
            duave,
            tongsongaydieutri,
            cd_noichuyenden,
            cd_manoichuyenden,
            cd_noiKKBCapCuu,
            cd_manoiKKBCapCuu,
            cd_khivaokhoadieutri,
            cd_makhoadieutri,
            cd_taibien,
            cd_bienchung,
            cd_dophauthuat,
            cd_dogayme,
            cd_donhiemkhuan,
            cd_khac,
            cd_tongsongaydieutrisauphauthuat,
            cd_tongsolanphauthuat,
            cd_benhchinh,
            cd_mabenhchinh,
            cd_nguyennhanbenhchinh,
            cd_manguyennhanbenhchinh,
            cd_benhkemtheo,
            cd_mabenhkemtheo,
            cd_chandoantruocphauthuat,
            cd_machandoantruocphauthuat,
            cd_chandoansauphauthuat,
            cd_machandoansauphauthuat,
            tt_khoi,
            tt_giam,
            tt_khongthaydoi,
            tt_nanghon,
            tt_tuvong,
            tt_lanhtinh,
            tt_nghingo,
            tt_actinh,
            tt_thoigiantuvong,
            tt_tuvongdobenh,
            tt_tuvongdotaibien,
            tt_tuvongkhac,
            tt_tuvongtrong24h,
            tt_tuvongtrong48h,
            tt_tuvongtrong72h,
            tt_nguyennhantuvong,
            tt_manguyennhantuvong,
            tt_khamtuthi,
            tt_chandoangiaiphaututhi,
            tt_magiaiphaututhi,
            hb_quatrinhbenhly,
            hb_tiensubenhbanthan,
            hb_diung,
            hb_thoigiandiung,
            hb_nghienmatuy,
            hb_thoigiannghienmatuy,
            hb_nghienruoubia,
            hb_thoigiannghienruoubia,
            hb_nghienthuocla,
            hb_thoigiannghienthuocla,
            hb_nghienthuoclao,
            hb_thoigiannghienthuoclao,
            hb_lydokhac,
            hb_thoigianlydokhac,
            hb_tiensubenhgiadinh,
            kb_toanthan,
            kb_benhngoaikhoa,
            kb_tuanhoan,
            kb_hohap,
            kb_tieuhoa,
            kb_thantietnieusinhduc,
            kb_thankinh,
            kb_cosuongkhop,
            kb_taimuihong,
            kb_ranghammat,
            kb_mat,
            kb_noitietdinhduong,
            kb_canlamsan,
            kb_benhan,
            chandoankhivaokhoa,
            benhchinh,
            benhkemtheo,
            phanbiet,
            tienluong,
            huongdieutri,
            tk_quatrinhbenhly,
            tk_ketquacanlamsan,
            tk_phuongphapdieutri,
            tk_tinhtrangravien,
            tk_huongdieutritieptheo
}
//──────────────────────────────────────────────────
 public enum tbl_DMBoPhanCDHA{
            idbophan,
            mabophan,
            tenbophan,
            maloai,
            kyhieu
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_PhieuYCXuat{
            IdPhieuYC,
            NgayYC,
            SoPhieu,
            idnguoiYC,
            idphongkhambenh,
            ghichu,
            LoaiThuocID,
            LoaiYCid
}
//──────────────────────────────────────────────────
 public enum tbl_khoanhaptra{
            idphieunhaptra,
            ngaynhaptra,
            sonhaptra,
            idphieuxuat,
            lydo
}
//──────────────────────────────────────────────────
 public enum tbl_KB_Phong{
            Id,
            MaSo,
            TenPhong,
            DichVuKCB,
            GhiChu,
            LoaiBN,
            isPhongNoiTru,
            SOTT,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_giuongbenh{
            idgiuongbenh,
            idphongkhambenh,
            tengiuongbenh,
            tinhtrang
}
//──────────────────────────────────────────────────
 public enum tbl_tuthuoc{
            idtu,
            masotu,
            tentu,
            idkho
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucCCDC{
            ccdc_id,
            phieu_nhap_id,
            ma_ccdc,
            ten_ccdc,
            hang_sx,
            nam_sx,
            nguyen_gia,
            ngay_nhap,
            ngay_khau_hao,
            so_thang_khau_hao,
            Tk_ccdc,
            Tk_doi_ung,
            tk_chi_phi,
            tk_phan_bo,
            phieu_xuat_id
}
//──────────────────────────────────────────────────
 public enum tbl_quanhuyen{
            quanhuyenid,
            tinhid,
            quanhuyenname,
            MaQuanHuyen
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_Parameter{
            Id,
            NoiDungPhieuThu,
            NoiDungPhieuChi
}
//──────────────────────────────────────────────────
 public enum tbl_NhatKyMoiChuyenKhoaKham{
            idMoiKham,
            ngayKham,
            idbacsi,
            phiKham,
            idkhambenh,
            idchitietdangkykham,
            IdKhoaMoi,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_GiaBan{
            idgiaban,
            lanthu,
            tungay,
            denngay
}
//──────────────────────────────────────────────────
 public enum tbl_BangVietTat{
            TuKhoa,
            Nghia,
            MaLoai
}
//──────────────────────────────────────────────────
 public enum tbl_NVK_Thuoc_PhieuYCTra{
            IdPhieuYCTra,
            NgayYC,
            SoPhieu,
            idnguoiYC,
            idphongkhambenh,
            ghichu,
            LoaiThuocID,
            LoaiTraID
}
//──────────────────────────────────────────────────
 public enum tbl_lichmo{
            idlichmo,
            idbacsi,
            idgiuongbenh,
            ngaymo,
            giomo
}
//──────────────────────────────────────────────────
 public enum tbl_VTYT_XuatLyLich{
            SoPhieuXuat,
            ngayxuat,
            idphongkham,
            Nguoinhan,
            ghichu,
            NgayUD
}
//──────────────────────────────────────────────────
 public enum tbl_tinh{
            tinhid,
            tinhname,
            MaTinh
}
//──────────────────────────────────────────────────
 public enum tbl_benhnhan_phongkhambenh{
            idbenhnhanphongkhambenh,
            idbenhnhan,
            idphongkhambenh,
            ishoantat,
            ngaynhap,
            idbacsi,
            dakham,
            dichvu,
            istaikham
}
//──────────────────────────────────────────────────
 public enum tbl_NVK_Thuoc_chitietPhieuYCTra{
            IdChiTietPhieuYCTra,
            IdPhieuYCTra,
            IDthuoc,
            SoLuong,
            GhiChu,
            SlNhan
}
//──────────────────────────────────────────────────
 public enum tbl_Permision{
            PermID,
            PermName,
            PermDesc,
            Status,
            IsTransfer,
            IsParent,
            SoTT
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_LoaiThuoc{
            LoaiThuocID,
            MaLoai,
            TenLoai,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_KhaiBaoCLS{
            MaKhoa,
            TenNhom,
            tendichvu,
            giadichvu,
            GiaBH,
            IsKTC,
            madichvu,
            bhtra,
            mota,
            PhuThuBH
}
//──────────────────────────────────────────────────
 public enum tbl_thutiennhapkham{
            idthutiennhapkham,
            idbenhnhan,
            sophieuthu,
            ngaythang,
            sotien,
            noidungthu,
            idnguoidung,
            tinhtrangthutien,
            tralaikhach
}
//──────────────────────────────────────────────────
 public enum tbl_ngan{
            idngan,
            masongan,
            tenngan,
            idtu
}
//──────────────────────────────────────────────────
 public enum tbl_phuongxa{
            phuongxaid,
            quanhuyenid,
            tenphuongxa,
            MaPhuongXa
}
//──────────────────────────────────────────────────
 public enum tbl_du_dau_tmp{
            du_no0,
            du_co0
}
//──────────────────────────────────────────────────
 public enum tbl_HS_TOATHUOC_View{
            IdToaThuoc,
            NgayToa,
            IdBenhNhan,
            MaBN,
            HoTenBN,
            NgaySinh,
            GioiTinh,
            SoBHYT,
            DungTuyen,
            IsHaveThuoc,
            BNTra,
            Capthuoc
}
//──────────────────────────────────────────────────
 public enum tbl_THE_KHO_KT{
            the_kho_kt_id,
            phieu_nhap_id,
            phieu_nhap_ct_id,
            phieu_xuat_id,
            phieu_xuat_ct_id,
            ma_ct,
            ngay_lap_ct,
            tk_kho,
            ma_kh,
            dien_giai,
            ma_vt,
            ma_kho,
            so_luong_nhap,
            tien_nhap,
            so_luong_xuat,
            tien_xuat,
            tk_du,
            so_hd,
            so_seri,
            ngay_lap_hd
}
//──────────────────────────────────────────────────
 public enum tbl_hangsanxuat{
            idhangsanxuat,
            mahangsanxuat,
            tenhangsanxuat,
            ishang
}
//──────────────────────────────────────────────────
 public enum tbl_toathuoc{
            idtoathuoc,
            matoathuoc,
            ngaythang,
            idnguoiban,
            hoten,
            tuoi,
            gioitinh,
            diachi,
            chandoan,
            ghichu,
            maca,
            bantam,
            dienthoai,
            lanin
}
//──────────────────────────────────────────────────
 public enum tbl_ngan_thuoc{
            idngan_thuoc,
            idthuoc,
            idngan,
            idtu,
            soluong
}
//──────────────────────────────────────────────────
 public enum tbl_CongNo_DauKi{
            CongNo_dk_id,
            nam,
            tk,
            ma_kh,
            du_no0,
            du_co0,
            du_no_nt0,
            du_co_nt0,
            date_dau,
            user_dau,
            date_cuoi,
            user_cuoi,
            trang_thai
}
//──────────────────────────────────────────────────
 public enum tbl_NVK_Thuoc_ChiTietYCTra_bntt{
            idThuoc_ChiTietYeuCauTra,
            IdChiTietPhieuYCTra,
            Idchitietbenhnhantoathuoc,
            isDaTra
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_LoaiXuat{
            idloaixuat,
            tenloaixuat,
            TenReport
}
//──────────────────────────────────────────────────
 public enum tbl_loaibh{
            idloaibh,
            kyhieu,
            soduoi,
            mota,
            tyleth,
            TyLetraituyen
}
//──────────────────────────────────────────────────
 public enum tbl_VTYT_XuatChiTiet{
            IDXuatChiTiet,
            SoPhieuXuat,
            idvtyt,
            Soluong,
            DonGia,
            Handung,
            Solo,
            ngaynhap
}
//──────────────────────────────────────────────────
 public enum tbl_bacsicanlamsang{
            idbacsicls,
            tenbacsicls
}
//──────────────────────────────────────────────────
 public enum tbl_BenhNhanXuatKhoa{
            IdXuatKhoa,
            NgayXuatKhoa,
            IdKhoaXuat,
            IdChiTietDangKyKham,
            IdKhamBenhGoc,
            IdBenhNhan,
            IdHuongDieuTri,
            IdKhoaChuyenDen,
            IdPhongChuyenDen,
            IdBVChuyenDen,
            PhuongPhapDT,
            LoiDanXuatKhoa,
            ChanDoanXuatKhoa,
            IsNhapLai,
            idtinhTrang,
            LyDoXuatKhoa,
            isCoDieuDuongCV,
            isCoBacSiCV,
            IdKhamBenhXK
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_CanhBao{
            idcanhbao,
            songay
}
//──────────────────────────────────────────────────
 public enum tbl_BenhNhanNoiTru{
            IdNoiTru,
            NgayVaoVien,
            NhapTuKhoa,
            IdKhoaNoiTru,
            IdChiTietDangKyKham,
            IdKhamBenhGoc,
            IdBenhNhan,
            IdPhongNoiTru,
            IdGiuong,
            GhiChu,
            ListIdCD,
            GiaGiuong,
            IsDaNhap,
            IdKhamBenhNhap,
            idbacsiNhap,
            iddieuduongNhap,
            isChonTrongNgay,
            isChonNgaysau,
            songay,
            isNhapKhoa,
            isChoSanh
}
//──────────────────────────────────────────────────
 public enum tbl_chitietphieunhapkho{
            idchitietphieunhapkho,
            idphieunhap,
            idthuoc,
            soluong,
            dongia,
            chietkhau,
            vat,
            dgsauchietkhau,
            ngayhethan,
            losanxuat,
            dongiaban,
            soluongthue,
            thue,
            soluongtang,
            idtu,
            idngan,
            soluongxuat,
            dvt,
            thanhtien,
            thanhtientruocthue,
            tienthue,
            daapgia,
            heso,
            tiensauchietkhau,
            tienchietkhau,
            Sltct,
            IdChiTietPhieuXuatKho,
            IdThuoc1,
            tkNo,
            SoDK,
            SLTon,
            TTXUAT,
            IDKHO_NHAP,
            NGAYTHANG_NHAP,
            IDLOAINHAP_NHAP,
            IdChiTietPhieuYCTra,
            GIABANBH,
            GIABANDV,
            IsDaHuy,
            SL_Prev,
            SLNHAP,
            ThanhTien_Prev,
            TIENCKSauTh,
            TIENCKTrTh,
            IdLoaiThuoc
}
//──────────────────────────────────────────────────
 public enum tbl_kcb_sosinh{
            idkcbsosinh,
            idkhambenh,
            idbacsi,
            ngayvaovien,
            tructiepvaocapcuu,
            tructiepvaoKKB,
            tructiepvaokhoa,
            coquangioithieu,
            tuden,
            khac,
            vaovienlan,
            vaokhoa,
            thoigianvaokhoa,
            songaydieutri,
            chuyentukhoa,
            thoigianchuyentukhoa,
            songaydieutritukhoa,
            denkhoathunhat,
            thoigianchuyentukhoathunhat,
            songaydieutrikhoathunhat,
            denkhoathuhai,
            thoigianchuyentukhoathuhai,
            songaydieutritukhoathuhai,
            chuyenvientuyentren,
            chuyenvientuyenduoi,
            chuyenvienCK,
            chuyenvienden,
            ngayravien,
            ravien,
            xinve,
            bove,
            duave,
            tongsongaydieutri,
            cd_noichuyenden,
            cd_manoichuyenden,
            cd_noiKKBCapCuu,
            cd_manoiKKBCapCuu,
            cd_khivaokhoadieutri,
            cd_makhoadieutri,
            cd_thuthuat,
            cd_phauthuat,
            cd_benhchinh,
            cd_mabenhchinh,
            cd_benhkemtheo,
            cd_mabenhkemtheo,
            cd_taibien,
            cd_bienchung,
            tt_khoi,
            tt_giam,
            tt_khongthaydoi,
            tt_nanghon,
            tt_tuvong,
            tt_lanhtinh,
            tt_nghingo,
            tt_actinh,
            tt_thoigiantuvong,
            tt_tuvongdobenh,
            tt_tuvongdotaibien,
            tt_tuvongkhac,
            tt_tuvongtrong24h,
            tt_tuvongsau24h,
            tt_nguyennhantuvong,
            tt_manguyennhantuvong,
            tt_khamtuthi,
            tt_chandoangiaiphaututhi,
            tt_magiaiphaututhi,
            hb_dienbienbenh,
            hb_oivo,
            hb_ngayoivo,
            hb_mausac,
            hb_dethuong,
            hb_canthiep,
            hb_ngayde,
            hb_lydocanthiep,
            hb_ttradoi_khocngay,
            hb_ttradoi_ngat,
            hb_ttradoi_khac,
            hb_hotennguoidobenh,
            hb_apgar1phut,
            hb_apgar5phut,
            hb_apgar10phut,
            hb_cannang,
            hb_ttdinhduongsausinh,
            hb_hs_hutdich,
            hb_hs_xoaboptim,
            hb_hs_theoxy,
            hb_hs_noikhiquan,
            hb_hs_bapbangoxy,
            hb_hs_khac,
            kb_hotennguoichuyen,
            kb_ditatbamsinh,
            kb_cohaumon,
            kb_cutheditat,
            kb_tinhhinhvaokhoa,
            kb_th_can,
            kb_th_chieudai,
            kb_th_vongdau,
            kb_tinhtrangtoanthan,
            kb_tt_nhietdo,
            kb_tt_nhiptho,
            kb_sd_honghao,
            kb_sd_xanhtai,
            kb_sd_vang,
            kb_sd_tim,
            kb_sd_khac,
            kb_hh_nhiptho,
            kb_hh_nghephoi,
            kb_hh_sosilverman,
            kb_tm_nhiptim,
            kb_bung,
            kb_sinhducngoai,
            kb_xuongkhop,
            kb_tk_phanxa,
            kb_tk_truongcoluc,
            kb_xetnghiemcls,
            kb_tomtatbenhan,
            kb_chidinhtheodoi,
            tk_quatrinhbenhly,
            tk_ketquacanlamsan,
            tk_phuongphapdieutri,
            tk_tinhtrangravien,
            tk_huongdieutritieptheo
}
//──────────────────────────────────────────────────
 public enum tbl_VTYT_NhapChiTiet{
            IDNhapChiTiet,
            Sophieunhap,
            idvtyt,
            Soluong,
            DonGia,
            SoLo,
            HanDung,
            NgayUd
}
//──────────────────────────────────────────────────
 public enum tbl_HS_ToaThuoc_ViewDetail{
            IdToaThuocDetail,
            IdToaThuoc,
            ChiTietThuoc,
            ChiTietBenh,
            ChiTietCLS,
            IdKhamBenh
}
//──────────────────────────────────────────────────
 public enum tbl_Uy_Nhiem_Chi{
            unc_id,
            so_unc,
            ngay_lap_unc,
            ma_ncc,
            nguoi_nhan,
            dien_giai,
            loai_nt,
            ty_gia,
            tk_co,
            tien,
            tien_nt,
            user_dau,
            date_dau,
            user_cuoi,
            date_cuoi,
            SoTaiKhoanNCC,
            TenNganHangNCC,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_CongNoKH{
            Id,
            IdKH,
            nYear,
            nMonth,
            Debit,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_KCB_tiensusankhoa{
            idtiensusankhoa,
            idkcbkhoasan,
            nam,
            deduthang,
            dethieuthang,
            say,
            hut,
            nao,
            chuangoaiTC,
            chuatrung,
            thaichetluu,
            conhiensong,
            cannang,
            phuongphapde,
            taibien
}
//──────────────────────────────────────────────────
 public enum tbl_KB_ChiTietPhieuThanhToan{
            ID,
            IdPTT,
            DichVuID,
            DonVi,
            SoLuong,
            DonGia,
            ThanhTien,
            IdBacSi
}
//──────────────────────────────────────────────────
 public enum tbl_trangthailuutrudulieu{
            id,
            userid,
            processDate,
            TableName,
            PrimarykeyName,
            primaryValue,
            Description,
            kieuthaotac
}
//──────────────────────────────────────────────────
 public enum tbl_TP_HoanTra{
            idHoanTra,
            maPhieu,
            idNguoiDung,
            idBenhNhan,
            idDangKyKham,
            ngayHoanTra,
            SoTien,
            noiDung,
            lyDo,
            tableName
}
//──────────────────────────────────────────────────
 public enum tbl_Uy_Nhiem_Chi_Ct{
            unc_ct_id,
            so_unc,
            tk_no,
            ps_no,
            ps_no_nt,
            thue_suat,
            tk_thue,
            tien_thue,
            tien_thue_nt,
            so_hd,
            so_seri,
            ngay_lap_hd,
            dien_giai,
            status_fix
}
//──────────────────────────────────────────────────
 public enum tbl_KB_PhieuTT{
            PhieuTTId,
            SoPhieu,
            NgayPhieu,
            IdBenhNhan,
            Status,
            Istransfer
}
//──────────────────────────────────────────────────
 public enum tbl_khothuoc{
            idkho,
            makho,
            tenkho,
            taikhoankho,
            taikhoangiavon,
            diachi,
            IsKT,
            IsCLS,
            IsKB,
            IdKhoa,
            IsNT,
            NVK_LoaiKho
}
//──────────────────────────────────────────────────
 public enum tbl_KCB_silverman{
            idsilverman,
            idkcbsosinh,
            diem,
            sudannolongnguc,
            cokeocoliensuon,
            cokeocomuiuc,
            dapcanhmui,
            renri
}
//──────────────────────────────────────────────────
 public enum tbl_VTYT_DMVTYT{
            manhom,
            idvtyt,
            tenvtyt,
            donvi,
            dongia,
            idnuocsanxuat,
            idnhacungcap,
            NguonKinhPhi,
            Ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_TP_ThanhToanVienPhi{
            idThanhToan,
            maPhieu,
            idNguoiDung,
            idBenhNhan,
            idDangKyKham,
            ngayThu,
            soTien
}
//──────────────────────────────────────────────────
 public enum tbl_nvk_HoanUng{
            idHoanUng,
            idchitietdangkykham,
            sotienHU,
            ngayhoanung,
            MaPhieuHU,
            idbenhnhan
}
//──────────────────────────────────────────────────
 public enum tbl_nvk_LoaiDvBsKham{
            idLoaiDichVuKham,
            MaLoai,
            TenLoaiDV
}
//──────────────────────────────────────────────────
 public enum tbl_DMThuoc{
            STT,
            TenThuoc,
            TenNhom,
            HoatChat,
            DVT,
            SoChungTu,
            NgayNhanHD,
            SoLuongNhap,
            DonGia,
            ThanhTien,
            LoSX,
            SoDK,
            HanDung,
            NuocSX,
            TenCongTyNhap,
            LoaiThuocID
}
//──────────────────────────────────────────────────
 public enum tbl_phanbotoathuoc{
            idphanbotoathuoc,
            idchitiettoathuoc,
            idchitietphieunhapkho,
            sluongxuat,
            dongia
}
//──────────────────────────────────────────────────
 public enum tbl_chitietdangkykham{
            idchitietdangkykham,
            iddangkykham,
            idbanggiadichvu,
            soluong,
            dongia,
            baohiemchi,
            giamgia,
            idbacsi,
            dahuy,
            dakham,
            idnguoithu,
            iddieuduong,
            PhongSo,
            SoTT,
            PhongID,
            IsDaThu,
            SLBNCho,
            SLBNDK,
            IdKhamBenhCD,
            isNotThuPhiCapCuu,
            ishoantatcls,
            IsHoanTraCT,
            BHTra,
            BNDaTra,
            BNTongPhaiTra,
            BNTra,
            DonGiaBH,
            DonGiaDV,
            IsBHYT,
            ISBNDaTra,
            NGAYTINHBH_THUC,
            PhuThuBH,
            PrevBNTra,
            ThanhTienBH,
            ThanhTienDV
}
//──────────────────────────────────────────────────
 public enum tbl_phieuHen{
            IDPhieuHen,
            iddieutricanlamsan,
            idbacsi,
            idbenhnhan,
            ngayhen,
            idkhambenh,
            idpkb,
            DaNhan
}
//──────────────────────────────────────────────────
 public enum tbl_nvk_congBacSiKhambenhKhac{
            idKhamDvKhac,
            idBacSiKhamBenh,
            idbenhnhanKhac,
            idLoaiDvKham,
            GhiChu
}
//──────────────────────────────────────────────────
 public enum tbl_kt_temp{
            chitieu,
            maso,
            bold
}
//──────────────────────────────────────────────────
 public enum tbl_HoatChat{
            TenThuoc,
            HoatChat,
            TenNhom
}
//──────────────────────────────────────────────────
 public enum tbl_nvk_congBacSiKhambenhDienBien{
            idKhamDienBien,
            idBacSiKhamBenh,
            idbenhnhanDB,
            GhiChu
}
//──────────────────────────────────────────────────
 public enum tbl_NVK_HenTaiKham{
            idHenTaiKham,
            NgayTaoPhieuHen,
            NgayHenTaiKham,
            IdKhoaTaoPhieuHen,
            IdKhoaSeTaiKham,
            idbenhnhan,
            idchitietdangkykham,
            IsDaTaiKham,
            GhiChuTaiKham
}
//──────────────────────────────────────────────────
 public enum tbl_nvk_chanDoanXuatKhoa{
            idCDXuatKhoa,
            idxuatkhoa,
            idicd
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_DoiTuongThuoc{
            DoiTuongThuocID,
            MaDoiTuong,
            TenDoiTuong,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_loaiphieuthukhambenh{
            idloaiphieuthukhambenh,
            idphieuthukhambenh,
            idcanlamsan,
            sotien
}
//──────────────────────────────────────────────────
 public enum tbl_KB_LoaiKham{
            LoaiKhamID,
            TenLoai,
            Status,
            IsTransfer
}
//──────────────────────────────────────────────────
 public enum tbl_nvk_congBacSiKhambenh{
            idBacSiKhamBenh,
            idbacsi,
            ngaykham,
            KhamThuongQuy,
            GhiChu,
            IdNguoiDung,
            IdKhoaCham
}
//──────────────────────────────────────────────────
 public enum tbl_nvk_thuoc_loaiYeuCauPhat{
            idLoaiYeuCau,
            MaLoaiYeuCau,
            MoTaLoaiYeuCau
}
//──────────────────────────────────────────────────
 public enum tbl_KB_CHITIETTHANHTOAN{
            ID,
            IDBENHNHAN,
            IDDANGKYKHAM,
            IDKB_DONGTIEN,
            IDBANGGIADICHVU,
            STT,
            IDCHUONGDICHVU,
            STTDV,
            TENNHOM,
            NHOMCON,
            TENDICHVU,
            DONVITINH,
            NGAYKHAM,
            SOLUONG,
            DONGIA,
            GIABH,
            THANHTIEN,
            BHTRA,
            BNTRA
}
//──────────────────────────────────────────────────
 public enum tbl_ZZZ{
            MAPHIEUDANGKY,
            LOAITHU,
            hoanung,
            hoantra,
            Thanhtoanravien,
            thutienxe,
            tennguoithu,
            NGAYKHAM,
            mabenhnhan,
            idbenhnhan,
            tenbenhnhan,
            SOTIEN
}
//──────────────────────────────────────────────────
 public enum tbl_thuoc_tondauky{
            idkey,
            idthuoc,
            soluong,
            thang,
            nam,
            solosx,
            ngayhethan,
            dongiaton
}
//──────────────────────────────────────────────────
 public enum tbl_ChiTietNhomDacBiet{
            IdChiTietNhom,
            IdNhom,
            IdThuoc
}
//──────────────────────────────────────────────────
 public enum tbl_Bacsi_PhongKham{
            IDChiTiet,
            idbacsi,
            idphongkhambenh
}
//──────────────────────────────────────────────────
 public enum tbl_kcb_phukhoa{
            idkcbphukhoa,
            idkhambenh,
            idbacsi,
            ngayvaovien,
            tructiepvaocapcuu,
            tructiepvaoKKB,
            tructiepvaokhoa,
            coquangioithieu,
            tuden,
            khac,
            vaovienlan,
            vaokhoa,
            thoigianvaokhoa,
            songaydieutri,
            chuyentukhoa,
            thoigianchuyentukhoa,
            songaydieutritukhoa,
            denkhoathunhat,
            thoigianchuyentukhoathunhat,
            songaydieutrikhoathunhat,
            denkhoathuhai,
            thoigianchuyentukhoathuhai,
            songaydieutritukhoathuhai,
            chuyenvientuyentren,
            chuyenvientuyenduoi,
            chuyenvienCK,
            chuyenvienden,
            ngayravien,
            ravien,
            xinve,
            bove,
            duave,
            tongsongaydieutri,
            cd_noichuyenden,
            cd_manoichuyenden,
            cd_noiKKBCapCuu,
            cd_manoiKKBCapCuu,
            cd_khivaokhoadieutri,
            cd_makhoadieutri,
            cd_taibien,
            cd_bienchung,
            cd_dophauthuat,
            cd_dogayme,
            cd_donhiemkhuan,
            cd_khac,
            cd_tongsongaydieutrisauphauthuat,
            cd_tongsolanphauthuat,
            cd_benhchinh,
            cd_mabenhchinh,
            cd_nguyennhanbenhchinh,
            cd_manguyennhanbenhchinh,
            cd_benhkemtheo,
            cd_mabenhkemtheo,
            cd_chandoantruocphauthuat,
            cd_machandoantruocphauthuat,
            cd_chandoansauphauthuat,
            cd_machandoansauphauthuat,
            tt_khoi,
            tt_giam,
            tt_khongthaydoi,
            tt_nanghon,
            tt_tuvong,
            tt_lanhtinh,
            tt_nghingo,
            tt_actinh,
            tt_thoigiantuvong,
            tt_tuvongdobenh,
            tt_tuvongdotaibien,
            tt_tuvongkhac,
            tt_tuvongtrong24h,
            tt_tuvongtrong48h,
            tt_tuvongtrong72h,
            tt_nguyennhantuvong,
            tt_manguyennhantuvong,
            tt_khamtuthi,
            tt_chandoangiaiphaututhi,
            tt_magiaiphaututhi,
            hb_quatrinhbenhly,
            hb_tiensubenhbanthan,
            hb_tiensubenhgiadinh,
            hb_batdauthaykinhnam,
            hb_batdauthaykinhotuoi,
            hb_tinhchatkinhnguyet,
            hb_chukykinhnguyet,
            hb_songaythaykinh,
            hb_luongkinh,
            hb_kinhlancuoingay,
            hb_daubung,
            hb_daubungtruoc,
            hb_daubungtrong,
            hb_daubungsau,
            hb_laychongnam,
            hb_tuoilaychong,
            hb_hetkinhnam,
            hb_hetkinhtuoi,
            hb_benhphukhoadieutrikhac,
            hb_tienthaiduthang,
            hb_tienthaisom,
            hb_tienthaisay,
            hb_tienthaisong,
            kb_daniemmac,
            kb_hach,
            kb_vu,
            kb_tuanhoan,
            kb_hohap,
            kb_tieuhoa,
            kb_thankinh,
            kb_cosuongkhop,
            kb_thantietnieu,
            kb_khac,
            kb_dauhieusinhducthunhat,
            kb_moilon,
            kb_moibe,
            kb_amvat,
            kb_amho,
            kb_mangtrinh,
            kb_tangsinhmon,
            kb_amdao,
            kb_cotucung,
            kb_thantucung,
            kb_phanphu,
            kb_cactuicung,
            kb_xetnghiemcanlamsang,
            kb_tomtatbenhan,
            benhchinh,
            benhkemtheo,
            phanbiet,
            tienluong,
            huongdieutri,
            tk_quatrinhbenhly,
            tk_ketquacanlamsan,
            tk_phuongphapdieutri,
            tk_tinhtrangravien,
            tk_huongdieutritieptheo
}
//──────────────────────────────────────────────────
 public enum tbl_chitiettoathuomau{
            idchitiettoathuoc,
            idtoathuoc,
            idthuoc,
            soluong,
            ngayuong,
            moilan,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_EkipCaMo{
            idekipmo,
            tenekipcamo,
            phamtramekipmo,
            tienekipmo,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_ChuyenKhoaBN{
            IDChuyenPK,
            IdPTT,
            idbenhnhan,
            IDKhoaChuyen,
            IDKhoaChuyenDen,
            NgayChuyen,
            NguoiChuyen,
            idPhongChuyen,
            idPhongChuyenDen
}
//──────────────────────────────────────────────────
 public enum tbl_luuchuyentt{
            chitieu,
            maso,
            cap,
            captren,
            sokytruoc,
            kytruoc,
            sonamnay,
            namnay,
            bold,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_SoDuDauKyThuocTrongKho{
            IdTonKho,
            IdThuoc,
            IdKho,
            nYear,
            nMonth,
            DVT,
            Quantity,
            Status,
            Amount
}
//──────────────────────────────────────────────────
 public enum tbl_KB_BenhNhanBHDongTien{
            Id,
            IdBenhNhan,
            NgayTinhBH,
            TongSoTien,
            SoTienBNPhaiTra,
            SoTienDaDong,
            IsTatToan,
            Status,
            IDCTDKKVUOT,
            SOTIENBHTRA
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_CachDung{
            idcachdung,
            tencachdung
}
//──────────────────────────────────────────────────
 public enum tbl_CongNoBenhNhan{
            IdCongNo,
            TongTien,
            TienBNTra,
            ConNo,
            LyDo,
            NgayThu,
            IdNguoiDung,
            IdDangKyKham,
            IdKhamBenh,
            Idbenhnhan,
            ListIdKhambenhCLS,
            MaPhieuThu
}
//──────────────────────────────────────────────────
 public enum tbl_phanquyen{
            idphanquyen,
            idnguoidung,
            idchucnang
}
//──────────────────────────────────────────────────
 public enum tbl_Phieu_Thu_Ct{
            phieu_thu_ct_id,
            so_phieu_thu,
            tk_co,
            ps_co,
            ps_co_nt,
            so_hd,
            ngay_lap_hd,
            tien_tren_hd,
            da_thanh_toan,
            con_phai_thanh_toan,
            thanh_toan,
            dien_giai,
            status_fix
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_SoDuDauKyThuocTrongNganTu{
            IdTonKho,
            IdTu,
            IdNgan,
            IdThuoc,
            IdKho,
            nYear,
            nMonth,
            DVT,
            Quantity,
            Status,
            Amount
}
//──────────────────────────────────────────────────
 public enum tbl_dieutricanlamsan{
            iddieutricanlamsan,
            idkhambenhcanlamsan,
            idbacsi,
            ketqua,
            ketluan,
            ngaykham,
            video,
            idbenhnhan
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_DonViTinh{
            Id,
            TenDVT,
            Status,
            nvk_UuTienYL
}
//──────────────────────────────────────────────────
 public enum tbl_KhauHaoTaiSan{
            khau_hao_ts_id,
            MaTS,
            Thang,
            Nam,
            GiaTriKH,
            DienGiai,
            tk_chi_phi,
            ngay_khau_hao
}
//──────────────────────────────────────────────────
 public enum tbl_khoancongtru{
            maphieu,
            ngaythang,
            nhanvienid,
            noidung,
            sotien,
            loaiphieu
}
//──────────────────────────────────────────────────
 public enum tbl_thuoc1{
            idthuoc,
            sttindm05,
            tenthuoc,
            congthuc,
            duongdung,
            idhangsanxuat,
            idnhasanxuat,
            giabanhientai,
            nhacungcapid,
            ngayhethan,
            idnhomthuoc,
            tlbhtt,
            sudungchobh,
            imei,
            iddvt,
            donvitinh,
            LoiDan,
            IsVTYT,
            thuexuat,
            quycach,
            IsHoaChat,
            ghichu,
            LoaiThuocID,
            TTHoatChat,
            IsThuocBV
}
//──────────────────────────────────────────────────
 public enum tbl_cackhoanchi{
            matiepnhan,
            ngaytiepnhan,
            nguoitiepnhan,
            sotien,
            ghichu,
            loaichi
}
//──────────────────────────────────────────────────
 public enum tbl_lich_truckhoa_khambenh{
            idlichtruc,
            idphongkhambenh,
            ngaytruc,
            giobatdau,
            gioketthuc,
            idbacsi,
            loai
}
//──────────────────────────────────────────────────
 public enum tbl_hangsanxuat2{
            idhangsanxuat,
            mahangsanxuat,
            tenhangsanxuat,
            ishang
}
//──────────────────────────────────────────────────
 public enum tbl_LoaiCanLamSang{
            IDLoaiCLS,
            MaLoaiCLS,
            TenLoaiCLS,
            MaNhom
}
//──────────────────────────────────────────────────
 public enum tbl_DoanhThu_Pmbv{
            doanhthu_pmbvid,
            ma_doanh_thu,
            ten_doanh_thu,
            ngay_thu,
            nguoi_thu,
            id_benh_nhan,
            ma_ncc_bh,
            so_byyt,
            ngay_cap_so_bhyt,
            bao_hiem_tra,
            thanh_tien_bn_tra,
            ngay_cap_nhat,
            trang_thai,
            ten_bang_doanh_thu,
            ten_bang_ids,
            nhom_doanh_thu,
            nhom_id
}
//──────────────────────────────────────────────────
 public enum tbl_HS_BenhNhanBHDongTien{
            ID,
            IsBHYT,
            IdBenhNhan,
            HoTenBN,
            DungTuyen,
            NgayTinhBH,
            TongTienBH,
            BHTra,
            BNPhaiTra,
            TienThuoc,
            TienKham,
            TienCLS,
            TienPhuThuBH,
            TienGiaDV,
            TongTienBNPT,
            BNDaTra,
            PhaiTraConLai,
            BNDaTraChenhLechBHYT,
            BNPhaiTraChenhLechBHYT,
            CDHA,
            CLSKhac,
            DVKTCao,
            Itype,
            NgayTinhBH_Thuc,
            ThuocK,
            ThuThuat,
            TiemTruyen,
            TongTienBNDaTra,
            TongTienBNPTConLai,
            VanChuyen,
            VTYT,
            XN,
            IdKhamBenh_Last,
            IsView
}
//──────────────────────────────────────────────────
 public enum tbl_phieuthukhambenh{
            idphieuthukhambenh,
            idbenhnhan,
            idbacsi,
            sophieuthu,
            ngaytao,
            sotienthu,
            noidungthu,
            tinhtrangthu,
            tralaitien
}
//──────────────────────────────────────────────────
 public enum tbl_GoiPhauThuat{
            IDGoiPhauThuat,
            TenGoiPhauThuat,
            GhiChu,
            IdPhongKhamBenh,
            MaGoiPhauThuat,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_Kho{
            IdKhoThuoc,
            IdKHo,
            IdThuoc,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucTaiSan{
            danh_muc_ts_id,
            phieu_nhap_id,
            MaTS,
            TenTaiSan,
            HangSX,
            NamSX,
            NguyenGia,
            KhauHaoLK,
            NgayNhap,
            NgayKhauHao,
            SoNamKH,
            TKNguyenGia,
            TKKhauHao,
            TKDoiUng,
            TKChiPhi,
            TKChiPhiKhac,
            phieu_xuat_id
}
//──────────────────────────────────────────────────
 public enum tbl_HS_DSDATHU{
            TENDICHVU,
            PrevName,
            TENNHOM,
            TONGTIEN,
            SOPHONG,
            mabenhnhan,
            tenbenhnhan,
            SOBHYT,
            ngaysinh,
            tennguoithu,
            dungtuyen,
            loai,
            MAPHIEU,
            IDBENHNHAN,
            SOTT,
            LoaiThu,
            nLoaiThu,
            SoLuong,
            dvt,
            DonGiaDV,
            ThanhTienDV,
            DonGiaBH,
            ThanhTienBH,
            BHTra,
            PhuThuBH,
            DONGIA,
            THANHTIEN,
            IdChiTietDangKyKham,
            IdKhamBenhCanLamSan,
            IdThuoc,
            IdPhieuXuat,
            IdBenhNhanBHDongTien,
            LoaiThu2,
            NOIDUNGTHU,
            ISBHYT,
            SysDate,
            IsDaHuy,
            LYDOHUY,
            TenNguoiHuy,
            NgayHuy
}
//──────────────────────────────────────────────────
 public enum tbl_Tham_So{
            danh_muc_id,
            tham_so,
            gia_tri,
            dien_giai
}
//──────────────────────────────────────────────────
 public enum tbl_HS_LoaiPhi{
            MaLoaiPhi,
            TenLoaiPhi
}
//──────────────────────────────────────────────────
 public enum tbl_LoaiPhauThuat{
            idloaiphauthuat,
            tenloaiphauthuat,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_nhasanxuat{
            idnhasanxuat,
            manhasanxuat,
            tennhasanxuat
}
//──────────────────────────────────────────────────
 public enum tbl_KB_CachDung{
            idcachdung,
            macachdung,
            cachdung,
            idbacsi
}
//──────────────────────────────────────────────────
 public enum tbl_KB_DMChuyenKhoa{
            id,
            machuyenkhoa,
            tenchuyenkhoa
}
//──────────────────────────────────────────────────
 public enum tbl_NVK_Thuoc_ChiTietYCXuat{
            idThuoc_ChiTietYeuCau,
            IdChiTietPhieuYC,
            Idchitietbenhnhantoathuoc,
            isDaXuat
}
//──────────────────────────────────────────────────
 public enum tbl_tmpkhachhang{
            makhachhang,
            tenkhachhang
}
//──────────────────────────────────────────────────
 public enum tbl_KB_ITypeReport{
            IType,
            A,
            B
}
//──────────────────────────────────────────────────
 public enum tbl_KB_KindICD{
            KindICDId,
            KindName
}
//──────────────────────────────────────────────────
 public enum tbl_TieuDeCty{
            ID_TT,
            Ten_Cty,
            DiaChi,
            DienThoai,
            Fax,
            SoThue,
            Email,
            Website,
            Logo,
            Logo_image
}
//──────────────────────────────────────────────────
 public enum tbl_Kb_LoaiPhongKham{
            IdLoaiPhong,
            TenLoai
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_ChiTietPhieuYCXuat{
            IdChiTietPhieuYC,
            IdPhieuYC,
            IDthuoc,
            SoLuong,
            GhiChu,
            SlXuat,
            SLKyNay,
            SLKyTruocTreo,
            Status_ThuocTreo
}
//──────────────────────────────────────────────────
 public enum tbl_khambenhcanlamsan{
            idkhambenhcanlamsan,
            idkhambenh,
            idcanlamsan,
            dongia,
            idbacsi,
            dathu,
            dakham,
            ngaythu,
            idnguoidung,
            ngaykham,
            idbenhnhan,
            tenBSChiDinh,
            maphieuCLS,
            thucthu,
            dahuy,
            soluong,
            chietkhau,
            thanhtien,
            IdNguoiThu,
            BHTra,
            GhiChu,
            LoaiKhamID,
            idkhoadangky,
            sldakham,
            istieuphau,
            isphauthuat,
            IsHoanTraCLS,
            BHYTTra,
            BNDaTra,
            BNTongPhaiTra,
            BNTra,
            DonGiaBH,
            DonGiaDV,
            IdChiTietPTT,
            IsBHYT,
            ISBNDaTra,
            NgayQuayLai,
            NGAYTINHBH_THUC,
            PhuThuBH,
            PrevBNTra,
            ThanhTienBH,
            ThanhTienDV,
            IDDANGKYCLS
}
//──────────────────────────────────────────────────
 public enum tbl_KB_NhomICD{
            NhomICDId,
            TenNhomId,
            KindICDId
}
//──────────────────────────────────────────────────
 public enum tbl_KB_PhanCaBacSi{
            IdPhanPhongKham,
            IdBacSi,
            PhongID,
            IdChuyenKhoa,
            NgayKham
}
//──────────────────────────────────────────────────
 public enum tbl_Kb_SoBienLai{
            Id,
            SysDate,
            SoTT
}
//──────────────────────────────────────────────────
 public enum tbl_KB_ThatThu{
            IdThatThu,
            IdKhamBenh,
            TongTienKham,
            TienBNTra,
            ThatThu,
            LyDo,
            IdNguoiDung,
            IDBenhNhan,
            idSoCT
}
//──────────────────────────────────────────────────
 public enum tbl_benhnhanChoTiepNhan{
            idbenhnhan,
            mabenhnhan,
            tenbenhnhan,
            lacon,
            idlacon,
            laanhem,
            diachi,
            dienthoai,
            gioitinh,
            ngaysinh,
            chungminhthu,
            hinhanh,
            chieucao,
            cannang,
            huyetap,
            nhiptim,
            loai,
            tiensubenhnhan,
            tinhtrangbandau,
            sobhyt,
            ngaybatdau,
            ngayhethan,
            thongtinbaotin,
            tencongty,
            thongtincongty,
            idloaibh,
            nghenghiep,
            noicongtac,
            noigioithieu,
            noidangkykcb,
            chandoansobo,
            ngaytiepnhan,
            DungTuyen,
            email,
            Mtlv,
            MTs,
            Sktl,
            SkAU,
            phuongtien,
            nhommau,
            benhvemau,
            NguoiLH,
            DiaChiLH,
            DienThoaiLH
}
//──────────────────────────────────────────────────
 public enum tbl_CLSPhauThuat{
            idCLSPhauThuat,
            idchitietCLSPhauThuat,
            idcaphauthuat
}
//──────────────────────────────────────────────────
 public enum tbl_KeToa{
            IdKeToa,
            IdCachDung,
            NgayDung,
            MoiLan,
            IdBacSi,
            donvidung
}
//──────────────────────────────────────────────────
 public enum tbl_TonKho{
            STT,
            MaKho,
            MaThuoc,
            TenThuoc,
            NhomThuoc,
            HoatChat,
            CachDung,
            DVT,
            HangSX,
            LoSX,
            HanSD,
            SL,
            DG,
            IsBH,
            IsVTYT,
            IDLoaiThuoc,
            isHoachat,
            TT
}
//──────────────────────────────────────────────────
 public enum tbl_mucbh{
            idmucbh,
            idloaibh,
            hinhthucbh,
            giatu,
            giaden,
            PTbh
}
//──────────────────────────────────────────────────
 public enum tbl_chucnang{
            idchucnang,
            machucnang,
            tenchucnang,
            iconimg
}
//──────────────────────────────────────────────────
 public enum tbl_KB_ChuongDichVu{
            IdChuongDichVu,
            MaChuongDichVu,
            TenChuongDichVu
}
//──────────────────────────────────────────────────
 public enum tbl_NhomThuocDacBiet{
            IdNhom,
            TenNhom
}
//──────────────────────────────────────────────────
 public enum tbl_Thue{
            thue_id,
            ma_ct,
            ngay_ct,
            ngay_hd,
            so_hd,
            so_seri,
            ma_kh,
            ten_kh,
            dia_chi,
            ma_so_thue,
            tien_truoc_thue,
            thue_suat,
            tien_thue,
            tk_thue,
            tk_doi_ung
}
//──────────────────────────────────────────────────
 public enum tbl_nvk_Thuoc_LoaiTra{
            idLoaiTra,
            MaLoaiTra,
            MoTaLoaiTra
}
//──────────────────────────────────────────────────
 public enum tbl_TH_tbd_chitiettoathuocmau{
            idtoathuocmauchitiet,
            idtoathuocmau,
            idthuoc,
            soluong,
            dongia,
            ngayuong,
            moilanuong,
            donvidung,
            ghichu,
            hostname
}
//──────────────────────────────────────────────────
 public enum tbl_chandoanphoihop{
            id,
            idkhambenh,
            idicd,
            maicd
}
//──────────────────────────────────────────────────
 public enum tbl_PhanQuyenThuoc{
            IdPhanQuyenThuoc,
            IdNhom,
            IdBacSi
}
//──────────────────────────────────────────────────
 public enum tbl_phieuthutienthuoc{
            idphieuthu,
            maphieuthu,
            ngaythang,
            idtoathuoc,
            sotien,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_lichlamviecnhanvien{
            idlichlamviecnhanvien,
            idphongkhambenh,
            idbacsi,
            ngaylamviec,
            idcalamviec
}
//──────────────────────────────────────────────────
 public enum tbl_THSDT_BHYT{
            IdTHSDTBHYT,
            IdThuoc,
            NgayThayDoi,
            TrangThai
}
//──────────────────────────────────────────────────
 public enum tbl_ChiTietPhuCapBacSiPhauThuat{
            idchitietPCBSPT,
            idloaiphauthuat,
            idvaitroBSPT,
            phantramphucap,
            tienphucap,
            ghichu
}
//──────────────────────────────────────────────────
 public enum tbl_So_Du_Tk_Dau_Ky{
            So_Du_Tk_id,
            nam,
            tai_khoan,
            du_no0,
            du_co0,
            du_no_nt0,
            du_co_nt0,
            date_dau,
            userdau,
            date_cuoi,
            user_cuoi
}
//──────────────────────────────────────────────────
 public enum tbl_KB_HuongDieuTri{
            HuongDieuTriId,
            TenHuongDieuTri,
            Status,
            ISKetThuc
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_LoaiXuat_DT{
            ID,
            idloaixuat,
            tenloaixuat
}
//──────────────────────────────────────────────────
 public enum tbl_KB_TinhTrangXuatKhoa{
            idTinhTrang,
            tenTinhTrang,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_KB_QuyenBH{
            ID,
            MaQuyen,
            TenQuyen
}
//──────────────────────────────────────────────────
 public enum tbl_KB_NOIDANGKYKB{
            IDNOIDANGKY,
            MASO,
            MADANGKY,
            TENNOIDANGKY,
            DUNGTUYEN
}
//──────────────────────────────────────────────────
 public enum tbl_ToaThuocMau{
            idToaThuoc,
            IdChanDoan,
            ngayratoa,
            nguoilap
}
//──────────────────────────────────────────────────
 public enum tbl_TongHopVTYT{
            MaSoPhieu,
            Ngay,
            TaiKhoanNo,
            TaiKhoanCo,
            ThanhTien
}
//──────────────────────────────────────────────────
 public enum tbl_loainghiphep{
            idnghiphep,
            tennghiphep
}
//──────────────────────────────────────────────────
 public enum tbl_ChanDoanICD{
            IDICD,
            MaICD,
            MoTa,
            IDNhomICD,
            EnglishName,
            IdNguoiDung,
            NhomICD,
            SoTT
}
//──────────────────────────────────────────────────
 public enum tbl_Tonghopchiphi_temp{
            DienGiai,
            Tongluong
}
//──────────────────────────────────────────────────
 public enum tbl_phieunhapkho{
            idphieunhap,
            maphieunhap,
            ngaythang,
            idkho,
            nhacungcapid,
            tennguoigiao,
            kyhieuhoadon,
            sohoadon,
            ngayhoadon,
            tkno,
            tkco,
            tkvat,
            nhapcho,
            ghichu,
            vat,
            thanhtien,
            idkhachhang,
            idnguoinhap,
            idloainhap,
            IsBHYT,
            tienhang,
            tienvat,
            tongtien,
            ptn,
            TrangThai,
            IdPhieuXuat,
            nhacungcapidbk,
            IsDaHuy,
            LANSUA,
            NGAYSUA,
            NGUOISUA
}
//──────────────────────────────────────────────────
 public enum tbl_benhnhanChoCLS{
            IDBenhNhanCho,
            idbenhnhan,
            NgayTiepNhan
}
//──────────────────────────────────────────────────
 public enum tbl_Tbd_CongnoChitiet{
            idcongno,
            idphieunhap,
            tongtien,
            datra,
            conlai
}
//──────────────────────────────────────────────────
 public enum tbl_KhauHaoCongCuDungCu{
            khau_hao_ccdc_id,
            Ma_ccdc,
            Thang,
            Nam,
            GiaTriKH,
            Dien_Giai,
            tk_chi_phi,
            ngay_khau_hao
}
//──────────────────────────────────────────────────
 public enum tbl_Thue_TNCN{
            idThueTNCN,
            MaTTNCN,
            LuongTu,
            LuongDen,
            HeSo,
            GhiChu,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_LamThemGio{
            idlamthemgio,
            idnhanvien,
            ngaylamthem,
            giobatdau,
            gioketthuc,
            ghichu,
            status,
            SoGio
}
//──────────────────────────────────────────────────
 public enum tbl_Tbd_CongnoNCC{
            idcongno,
            idnhacungcap,
            datra,
            conlai
}
//──────────────────────────────────────────────────
 public enum tbl_bacsi{
            idbacsi,
            mabacsi,
            tenbacsi,
            dienthoai,
            diachi,
            gioitinh,
            idphongkhambenh,
            username,
            pass,
            idchucvu,
            ngaysinh,
            luongcoban,
            isthoiviec,
            pthh,
            ptcd,
            ghichu,
            IsBSNgoaiVien
}
//──────────────────────────────────────────────────
 public enum tbl_KB_LoaiBN{
            Id,
            TenLoai,
            GiamGiaKB,
            TTUT,
            iskhamtruoc,
            status,
            MALOAIBN
}
//──────────────────────────────────────────────────
 public enum tbl_Phieu_Chi_Ct{
            phieu_chi_ct_id,
            so_phieu_chi,
            tk_no,
            ps_no,
            ps_no_nt,
            thue_suat,
            tk_thue,
            tien_thue,
            tien_thue_nt,
            so_hd,
            so_seri,
            ngay_lap_hd,
            tien_tren_hd,
            da_thanh_toan,
            con_phai_thanh_toan,
            thanh_toan,
            dien_giai,
            status_fix
}
//──────────────────────────────────────────────────
 public enum tbl_tangluong{
            idnhanvien,
            ngaytangluong,
            luongcu,
            luongmoi
}
//──────────────────────────────────────────────────
 public enum tbl_Th_tbd_toathuocmau{
            idtoathuocmau,
            tenbenhly,
            ghichu,
            idphongkhambenh
}
//──────────────────────────────────────────────────
 public enum tbl_BSPhauThuat{
            idBSPhauThuat,
            idCaPhauThuat,
            idchitietPCBSPT,
            idNhanVien
}
//──────────────────────────────────────────────────
 public enum tbl_GioLamViec{
            IdGioLamViec,
            ThuTu,
            GiaTri,
            GioText,
            isHanhChinh,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_Phongkham_Dichvu{
            IDPKDV,
            IDPhongkhambenh,
            IDBanggiadichvu,
            NoiDungKCB
}
//──────────────────────────────────────────────────
 public enum tbl_hs_Dictionary{
            ID,
            VN_abc,
            VN_Descript,
            EN_abc,
            EN_Descript,
            CH_abc,
            CH_Descript,
            IsTransfer
}
//──────────────────────────────────────────────────
 public enum tbl_PhongBan{
            idphongban,
            maphongban,
            tenphongban,
            ghichu,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_thoiviec{
            idnhanvien,
            ngaythoiviec,
            lydo
}
//──────────────────────────────────────────────────
 public enum tbl_KQHoatDongKD{
            ChiTieu,
            MaSo,
            ThuyetMinh,
            ThucHien,
            SoThucHien,
            KyTruoc,
            SoKyTruoc,
            DienGiai,
            Bold,
            Cap,
            CapTren,
            LuyKe,
            SoLuyKe,
            STT
}
//──────────────────────────────────────────────────
 public enum tbl_Hoa_Don_DV{
            hoa_donid,
            so_hd,
            so_seri,
            ngay_lap_hd,
            ma_kh,
            ten_kh,
            ten_nguoi_mua,
            dia_chi,
            ma_so_thue,
            dien_giai,
            tk_no,
            tk_co,
            tk_thue,
            thue_suat,
            tien,
            tien_thue,
            tong_tien,
            date_dau,
            user_dau,
            date_cuoi,
            user_cuoi,
            status,
            loai_hd
}
//──────────────────────────────────────────────────
 public enum tbl_KB_NoiDKKCBBH{
            Id,
            MaSo,
            TenDonVi
}
//──────────────────────────────────────────────────
 public enum tbl_ChucVu{
            idchucvu,
            machucvu,
            tenchucvu,
            ghichu,
            status,
            chamcong
}
//──────────────────────────────────────────────────
 public enum tbl_huydichvukham{
            maphieuhuy,
            ngayhuy,
            idnguoidung,
            idchitietdangkykham,
            sotienhoanlai,
            lydohuy,
            ngay_ud
}
//──────────────────────────────────────────────────
 public enum tbl_NhomICD{
            IDNhomICD,
            IDChuongICD,
            TenNhomICD
}
//──────────────────────────────────────────────────
 public enum tbl_BangChamCongTheoNgay{
            idChamCongTheoNgay,
            NgayCong,
            idNhanVien,
            NgayThuong,
            NgayTruc,
            PhepKhongLuong,
            PhepCoLuong,
            LamThemNuaNgay,
            LamThemMotNgay,
            NghiOm,
            VoKyLuat,
            NghiBu,
            NghiLe,
            idNguoiDung,
            idcatruc
}
//──────────────────────────────────────────────────
 public enum tbl_LoaiTangCa{
            idloaitangca,
            tenloaitangca,
            hesoluong,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_KB_KhoaTraBenhAn{
            idTraBenhAn,
            idBenhNhan,
            idKhamBenhCuoi,
            idChiTietDangKyKham,
            SoVaoVien,
            NgayTra,
            IdKhoaTra,
            idNguoiTra,
            tinhtrangBA
}
//──────────────────────────────────────────────────
 public enum tbl_CaPhauThuat{
            idCaPhauThuat,
            idBenhNhan,
            idPhongPhauThuat,
            idgoiphauthuat,
            NgayPhauThuat,
            trongoi,
            BinhThuong,
            ChiChu,
            sovaovien,
            idchitietdangkykham
}
//──────────────────────────────────────────────────
 public enum tbl_ChuongICD{
            IDChuongICD,
            TenChuongICD
}
//──────────────────────────────────────────────────
 public enum tbl_Qly_Session{
            Id,
            ClientID,
            UserID,
            UserName,
            FullName,
            Role,
            IdBacSi,
            ClientCode,
            ClientDate,
            PhongID
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucTaiSanDuBi{
            danh_muc_tsdb_id,
            phieu_nhap_id,
            MaTS_db,
            TenTaiSan_db,
            HangSX,
            NamSX,
            NguyenGia,
            NgayNhap,
            TKNguyenGia,
            TKDoiUng
}
//──────────────────────────────────────────────────
 public enum tbl_LoaiHopDong{
            idloaihopdong,
            tenloaihopdong,
            ghichu,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_ThuocPhauThuat{
            idThuocPhauThuat,
            idcaphauthuat,
            idThuoc,
            soluongthuoc,
            cachdungthuoc,
            idkho,
            khothuocid,
            iddoituong
}
//──────────────────────────────────────────────────
 public enum tbl_BenhVien{
            idBenhVien,
            MaBenhVien,
            TenBenhVien,
            idbanggiadichvu,
            idbanggiadichvuDDBS,
            idbanggiadichvuDD
}
//──────────────────────────────────────────────────
 public enum tbl_KhoaDaoTao{
            idkhoadaotao,
            mucdichdaotao,
            diadiem,
            tungay,
            denngay,
            hocphi,
            ctytra,
            nvtra,
            nopvanbang,
            ghichu,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_Uy_Nhiem_Thu_Ct{
            unt_ct_id,
            so_unt,
            tk_co,
            ps_co,
            ps_co_nt,
            thue_suat,
            tk_thue,
            tien_thue,
            tien_thue_nt,
            so_hd,
            so_seri,
            ngay_lap_hd,
            dien_giai,
            status_fix
}
//──────────────────────────────────────────────────
 public enum tbl_KB_NguoiDungKho{
            IdNguoidungKho,
            IdNguoiDung,
            Idkho
}
//──────────────────────────────────────────────────
 public enum tbl_Giam_TSCD{
            giam_tscd_id,
            so_phieu_giam,
            ma_ts,
            ngay_giam,
            dien_giai,
            loai_ts,
            user_dau,
            date_dau,
            user_cuoi,
            date_cuoi
}
//──────────────────────────────────────────────────
 public enum tbl_khachlecanlamsan{
            idkhachlecanlamsan,
            idbenhnhan,
            idcanlamsan,
            dichvu,
            ngaynhap,
            dathu,
            dakham
}
//──────────────────────────────────────────────────
 public enum tbl_HeSoBaoHiem{
            IdHeSoBH,
            MaHSBH,
            TenBaoHiem,
            CtyTra,
            NVTra,
            Ghichu,
            Status
}
//──────────────────────────────────────────────────
 public enum tbl_KB_CongTy{
            idcongty,
            macongty,
            tencongty
}
//──────────────────────────────────────────────────
 public enum tbl_Giam_TSCD_CT{
            giam_tscd_ct_id,
            so_phieu_giam,
            tk_no,
            tk_co,
            tien,
            dien_giai,
            user_dau,
            date_dau,
            user_cuoi,
            date_cuoi
}
//──────────────────────────────────────────────────
 public enum tbl_LoaiNgayNghi{
            idloaingaynghi,
            maloaingaynghi,
            mota,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_Uy_Nhiem_Thu{
            unt_id,
            so_unt,
            ngay_lap_unt,
            ma_kh,
            nguoi_nop_tien,
            dien_giai,
            loai_nt,
            ty_gia,
            tk_no,
            tien,
            tien_nt,
            user_dau,
            date_dau,
            user_cuoi,
            date_cuoi,
            SoTaiKhoanKH,
            TenNganHangKH,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_KB_LoaiUutien{
            Id,
            TenLoai,
            ThuTu
}
//──────────────────────────────────────────────────
 public enum tbl_ChiTietPhuCap_NhanVien{
            idChiTietPhuCap_NV,
            idNhanVien,
            idPhuCap,
            GiaTriMuc
}
//──────────────────────────────────────────────────
 public enum tbl_VaiTroBSPhauThuat{
            idVaiTroBS,
            tenvaitro,
            idekipmo,
            GhiChu
}
//──────────────────────────────────────────────────
 public enum tbl_DoanhThu_Pmbv2{
            doanhthu_pmbvid,
            ma_doanh_thu,
            ten_doanh_thu,
            ngay_thu,
            nguoi_thu,
            id_benh_nhan,
            ma_ncc_bh,
            so_byyt,
            ngay_cap_so_bhyt,
            bao_hiem_tra,
            thanh_tien_bn_tra,
            ngay_cap_nhat,
            trang_thai,
            ten_bang_doanh_thu,
            ten_bang_ids,
            nhom_doanh_thu,
            nhom_id
}
//──────────────────────────────────────────────────
 public enum tbl_Thuoc_ChiTietGiaBan{
            idchitietgia,
            idthuoc,
            iddvt,
            giaban,
            idgiaban,
            giabantrungbinh,
            heso
}
//──────────────────────────────────────────────────
 public enum tbl_phongbantaisan{
            idphongbantaisan,
            idphongkhambenh,
            thongtintaisan,
            nguoiquanly
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucPhuCap{
            idPhuCap,
            TenPhuCap,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_thongtinnhapvien{
            idnhapvien,
            idphongkhambenh,
            idbenhnhan,
            idgiuongbenh,
            idbacsi,
            idyta,
            ngaynhapvien,
            gionhapvien,
            phutnhapvien,
            trieuchungbandau
}
//──────────────────────────────────────────────────
 public enum tbl_chitietphieuxuatkhosanpham{
            idchitietphieuxuat,
            idphieuxuat,
            idsanpham,
            soluong,
            dongiavon,
            dongiaxuat,
            chenhlech,
            chietkhau,
            idchitietphieunhapkho
}
//──────────────────────────────────────────────────
 public enum tbl_tamUng{
            IDTamUng,
            iddangkykham,
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
            idkhoaTU,
            MAPHIEU_TU
}
//──────────────────────────────────────────────────
 public enum tbl_DanhMucDoiTac{
            MaDoiTac,
            TenDoiTac,
            Website,
            DienThoai,
            Fax,
            MaSoThue,
            DiaChi,
            ThanhPho,
            TenNguoiLienHe,
            NgaySinh,
            GioiTinh,
            ChucVu,
            DienThoai1,
            Mobile,
            SoHopDong,
            NgayKyKet,
            ThoiHanHopDong,
            LinhVucKinhDoanh,
            TyLeGiamGia,
            DieuKienGiam,
            MaNhanVien
}
//──────────────────────────────────────────────────
 public enum tbl_thuoc{
            idthuoc,
            sttindm05,
            tenthuoc,
            congthuc,
            duongdung,
            idnuocsanxuat,
            idnhasanxuat,
            giabanhientai,
            nhacungcapid,
            ngayhethan,
            idnhomthuoc,
            tlbhtt,
            sudungchobh,
            imei,
            iddvt,
            donvitinh,
            LoiDan,
            IsVTYT,
            thuexuat,
            quycach,
            IsHoaChat,
            ghichu,
            LoaiThuocID,
            TTHoatChat,
            IsThuocBV,
            idhangsanxuat,
            CateID,
            IsTGN,
            IsTHTT,
            IdCachDung,
            ISTPX,
            ISTKS,
            ISTDTL,
            ISTcorticoid,
            tkKho,
            tkDoanhThu,
            tkGiaVon,
            tkvat,
            tkco,
            SoLuong1donvi,
            TenDonVi,
            DVTChuan,
            giabh,
            HamLuong,
            IsDTUT,
            IsThucSDBHYT,
            SLDVTChuan,
            SLQuyDoi
}
//──────────────────────────────────────────────────
 public enum tbl_Phieu_Tong_Hop{
            phieu_tong_hop_id,
            so_phieu,
            ngay_lap,
            ma_doi_tuong,
            dien_giai,
            loai_tai_khoan,
            tai_khoan,
            loai_nt,
            ty_gia,
            user_dau,
            date_dau,
            user_cuoi,
            date_cuoi,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_CaLamViec{
            idcalamviec,
            tencalamviec,
            ngaythu,
            tugio,
            dengio,
            status
}
//──────────────────────────────────────────────────
 public enum tbl_Phieu_TT_Tam_Ung{
            phieu_chi_id,
            so_phieu_chi,
            ngay_chi,
            ma_ncc,
            nguoi_giao,
            dien_giai,
            loai_nt,
            ty_gia,
            tk_co,
            tien,
            tien_nt,
            user_dau,
            date_dau,
            user_cuoi,
            date_cuoi,
            status,
            dsphieuchi,
            tongtienchi
}
//──────────────────────────────────────────────────
 public enum TBL_NAME
 {
    VTYT_nuocsanxuat
,    nguoidung_host
,    PHIEU_NHAP_VT
,    KB_PhieuThanhToan
,    chitietbenhnhantoathuoc
,    ChiTietCLSGoiPhauThuat
,    KB_ChiTietNhomCLS
,    VTYThangsanxuat
,    chitietphieuban
,    Phieu_Tong_Hop_Ct
,    LichSuPhuCap
,    Phieu_TT_Tam_Ung_CT
,    benhnhan_temp
,    setting
,    sanpham
,    PhuongPhapVoCam
,    KB_NhomCLS
,    VTYTkho
,    XepLoai
,    sysdiagrams
,    NgheNghiep
,    kb_phongkham
,    phieuxuatban
,    DanhMucQuocGia
,    KhachHang
,    MauKetQuaCDHA
,    chitietphieunhapkhosanpham
,    NVK_ThanhToanVienPhi
,    DiaChi
,    KB_LoiDan
,    UyNhiemChi
,    PHIEU_KE_TOAN
,    HS_OutPutDetail
,    KB_Parameter
,    phieuxuatkhosanpham
,    CongTy
,    quoctich
,    phieunhapkhosanpham
,    So_Cai
,    benhnhanCho
,    KhenThuong
,    NuocSX
,    phieuban
,    Thuoc_LoaiNhap
,    Danhmuccalamviec
,    PHIEU_NHAP_VT_CT
,    PhuCap
,    KB_LoaiPhi
,    catruc
,    phieuxuatkho
,    DanhMucKenh
,    chitietdichvu
,    nghiphep
,    DanhMucThanhPho
,    DMThuocCLS
,    PHIEU_KE_TOAN_CT
,    Thuoc_DinhMucTonKho
,    DanhMucKhachHang
,    DanhMucLoaiTien
,    DM_VAT_TU_KT
,    dieutrikhachlecanlamsan
,    DanhMucTyGia
,    ThietLapCa
,    hs_DangKyCLS
,    DMMucDichNoiSoi
,    PhanBoCCDC
,    DanhMucTKNH
,    Hoa_Don_DV_CT_Kh
,    Thuoc_HeSoApGia
,    THTAIKHOAN2011
,    DMMayCLS
,    benhannoivien
,    candoikt
,    category
,    khambenh
,    congthucketchuyen
,    TangCa
,    ServerOption
,    NhanVien
,    nvk_chanDoanNhapKhoa
,    phieuchinhacungcap
,    Thuoc_PhieuThu
,    chitietkhachnhaptra
,    chitietphieuxuatkho
,    HopDong
,    VTYT_HangSo
,    thuoc_giaban1
,    ChiTietNhomNSD
,    nhacungcap
,    benhnhan
,    chitietkhoanhaptra
,    NhomNSD
,    ChiTietKhoaDaoTao
,    nhomsanpham
,    DanhMucTK
,    chitietphieunhaptra
,    DonDatHang
,    NgayNghiCongTy
,    quatrinhdieutrinoivien
,    Hoa_Don_DV_CT_Khac
,    KB_BangGiaGiuong
,    Ngaylamviec
,    category_sanpham
,    TienGiuongXuatKhoa
,    ChiTietTangCa
,    HS_TONKHO_View
,    KB_MucBaoHiem
,    khachnhaptra
,    Thuoc_PhieuChi
,    KB_Giuong
,    DangKyCa
,    HS_TonKhoViewDetail
,    KB_NhomDichVu
,    phieunhaptra
,    KB_GiuongPhieuThanhToan
,    DanhGiaCuoiNam
,    luuchuyentiente
,    banggiadichvu
,    du_dau_ncc
,    Phieu_Chi
,    phongkhambenh
,    TienPhuCap
,    ChiTietXuatVTYT
,    sinhhieu
,    Phieu_Thu
,    LuongNhanVien
,    VTYT_NhapLyLich
,    Thuoc_CongNoNCC
,    Sochungtu
,    dangkykham
,    KCB_CapCuu
,    nhomthuoc
,    tiepnhandoanhthu
,    UserProfile
,    PhanCa
,    VTYT_NhomVTYT
,    KCB_PhuongPhapDieuTri
,    nhomnguoidung
,    PHIEU_XUAT_VT
,    Hoa_Don_DV_CT
,    nguoidung
,    NgayNghiNhanVien
,    VTYT_TonDau
,    kcb_khoanoi
,    PHIEU_XUAT_VT_CT
,    DU_DAU_VT
,    chitiettoathuoc
,    BangChamCong
,    benhnhantoathuoc
,    kcb_khoangoai
,    DMBoPhanCDHA
,    Thuoc_PhieuYCXuat
,    khoanhaptra
,    KB_Phong
,    giuongbenh
,    tuthuoc
,    DanhMucCCDC
,    quanhuyen
,    Thuoc_Parameter
,    NhatKyMoiChuyenKhoaKham
,    Thuoc_GiaBan
,    BangVietTat
,    NVK_Thuoc_PhieuYCTra
,    lichmo
,    VTYT_XuatLyLich
,    tinh
,    benhnhan_phongkhambenh
,    NVK_Thuoc_chitietPhieuYCTra
,    Permision
,    Thuoc_LoaiThuoc
,    KhaiBaoCLS
,    thutiennhapkham
,    ngan
,    phuongxa
,    du_dau_tmp
,    HS_TOATHUOC_View
,    THE_KHO_KT
,    hangsanxuat
,    toathuoc
,    ngan_thuoc
,    CongNo_DauKi
,    NVK_Thuoc_ChiTietYCTra_bntt
,    Thuoc_LoaiXuat
,    loaibh
,    VTYT_XuatChiTiet
,    bacsicanlamsang
,    BenhNhanXuatKhoa
,    Thuoc_CanhBao
,    BenhNhanNoiTru
,    chitietphieunhapkho
,    kcb_sosinh
,    VTYT_NhapChiTiet
,    HS_ToaThuoc_ViewDetail
,    Uy_Nhiem_Chi
,    Thuoc_CongNoKH
,    KCB_tiensusankhoa
,    KB_ChiTietPhieuThanhToan
,    trangthailuutrudulieu
,    TP_HoanTra
,    Uy_Nhiem_Chi_Ct
,    KB_PhieuTT
,    khothuoc
,    KCB_silverman
,    VTYT_DMVTYT
,    TP_ThanhToanVienPhi
,    nvk_HoanUng
,    nvk_LoaiDvBsKham
,    DMThuoc
,    phanbotoathuoc
,    chitietdangkykham
,    phieuHen
,    nvk_congBacSiKhambenhKhac
,    kt_temp
,    HoatChat
,    nvk_congBacSiKhambenhDienBien
,    NVK_HenTaiKham
,    nvk_chanDoanXuatKhoa
,    Thuoc_DoiTuongThuoc
,    loaiphieuthukhambenh
,    KB_LoaiKham
,    nvk_congBacSiKhambenh
,    nvk_thuoc_loaiYeuCauPhat
,    KB_CHITIETTHANHTOAN
,    ZZZ
,    thuoc_tondauky
,    ChiTietNhomDacBiet
,    Bacsi_PhongKham
,    kcb_phukhoa
,    chitiettoathuomau
,    EkipCaMo
,    ChuyenKhoaBN
,    luuchuyentt
,    Thuoc_SoDuDauKyThuocTrongKho
,    KB_BenhNhanBHDongTien
,    Thuoc_CachDung
,    CongNoBenhNhan
,    phanquyen
,    Phieu_Thu_Ct
,    Thuoc_SoDuDauKyThuocTrongNganTu
,    dieutricanlamsan
,    Thuoc_DonViTinh
,    KhauHaoTaiSan
,    khoancongtru
,    thuoc1
,    cackhoanchi
,    lich_truckhoa_khambenh
,    hangsanxuat2
,    LoaiCanLamSang
,    DoanhThu_Pmbv
,    HS_BenhNhanBHDongTien
,    phieuthukhambenh
,    GoiPhauThuat
,    Thuoc_Kho
,    DanhMucTaiSan
,    HS_DSDATHU
,    Tham_So
,    HS_LoaiPhi
,    LoaiPhauThuat
,    nhasanxuat
,    KB_CachDung
,    KB_DMChuyenKhoa
,    NVK_Thuoc_ChiTietYCXuat
,    tmpkhachhang
,    KB_ITypeReport
,    KB_KindICD
,    TieuDeCty
,    Kb_LoaiPhongKham
,    Thuoc_ChiTietPhieuYCXuat
,    khambenhcanlamsan
,    KB_NhomICD
,    KB_PhanCaBacSi
,    Kb_SoBienLai
,    KB_ThatThu
,    benhnhanChoTiepNhan
,    CLSPhauThuat
,    KeToa
,    TonKho
,    mucbh
,    chucnang
,    KB_ChuongDichVu
,    NhomThuocDacBiet
,    Thue
,    nvk_Thuoc_LoaiTra
,    TH_tbd_chitiettoathuocmau
,    chandoanphoihop
,    PhanQuyenThuoc
,    phieuthutienthuoc
,    lichlamviecnhanvien
,    THSDT_BHYT
,    ChiTietPhuCapBacSiPhauThuat
,    So_Du_Tk_Dau_Ky
,    KB_HuongDieuTri
,    Thuoc_LoaiXuat_DT
,    KB_TinhTrangXuatKhoa
,    KB_QuyenBH
,    KB_NOIDANGKYKB
,    ToaThuocMau
,    TongHopVTYT
,    loainghiphep
,    ChanDoanICD
,    Tonghopchiphi_temp
,    phieunhapkho
,    benhnhanChoCLS
,    Tbd_CongnoChitiet
,    KhauHaoCongCuDungCu
,    Thue_TNCN
,    LamThemGio
,    Tbd_CongnoNCC
,    bacsi
,    KB_LoaiBN
,    Phieu_Chi_Ct
,    tangluong
,    Th_tbd_toathuocmau
,    BSPhauThuat
,    GioLamViec
,    Phongkham_Dichvu
,    hs_Dictionary
,    PhongBan
,    thoiviec
,    KQHoatDongKD
,    Hoa_Don_DV
,    KB_NoiDKKCBBH
,    ChucVu
,    huydichvukham
,    NhomICD
,    BangChamCongTheoNgay
,    LoaiTangCa
,    KB_KhoaTraBenhAn
,    CaPhauThuat
,    ChuongICD
,    Qly_Session
,    DanhMucTaiSanDuBi
,    LoaiHopDong
,    ThuocPhauThuat
,    BenhVien
,    KhoaDaoTao
,    Uy_Nhiem_Thu_Ct
,    KB_NguoiDungKho
,    Giam_TSCD
,    khachlecanlamsan
,    HeSoBaoHiem
,    KB_CongTy
,    Giam_TSCD_CT
,    LoaiNgayNghi
,    Uy_Nhiem_Thu
,    KB_LoaiUutien
,    ChiTietPhuCap_NhanVien
,    VaiTroBSPhauThuat
,    DoanhThu_Pmbv2
,    Thuoc_ChiTietGiaBan
,    phongbantaisan
,    DanhMucPhuCap
,    thongtinnhapvien
,    chitietphieuxuatkhosanpham
,    tamUng
,    DanhMucDoiTac
,    thuoc
,    Phieu_Tong_Hop
,    CaLamViec
,    Phieu_TT_Tam_Ung
 } 
}// end class 
}// end name space 

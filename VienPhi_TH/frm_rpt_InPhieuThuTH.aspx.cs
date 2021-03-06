using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;
using DataAcess;
using iTextSharp.text.pdf;
using SysParameter;
using System.Collections.Generic;
public partial class frm_rpt_InPhieuThuTH : System.Web.UI.Page
{
    private ReportDocument crystalReport = null;
    private bool isMauPhiKhamFull = StaticData.IsCheck(StaticData.GetParameter("isMauPhiKhamFull"));
    private bool isKhamBH = StaticData.IsCheck(StaticData.GetParameter("isKhamBH"));
    protected void Page_Load(object sender, EventArgs e)
    {
        string MaPhieuCLS = Request.QueryString["MaPhieuCLS"];
        string LoaiThu = Request.QueryString["LoaiThu"];
        string MaPhieu = Request.QueryString["MaPhieu"];
        string ID = Request.QueryString["ID"];
        if (ID == null) ID = "";
        string LoaiThu2 = Request.QueryString["LoaiThu2"];
        if (LoaiThu2 == null) LoaiThu2 = "";

        string NOIDUNGTHU = Request.QueryString["NOIDUNGTHU"];
        if (NOIDUNGTHU == null) NOIDUNGTHU = "";
        bool InLai = false;
        DataTable dt1 = null;
        DataTable dt2 = null;
        double TongTienBNPT = 0;
        string NgayThu = null;
        #region Get DataSource
        string sqlSelect = "";
        if (MaPhieu == null || MaPhieu == "") return;
        sqlSelect = @"SELECT dt.* FROM HS_DSDATHU dt WHERE MAPHIEU='" + MaPhieu + "'";
        string IsDaHuy = Request.QueryString["IsDaHuy"];
        if (IsDaHuy == null || IsDaHuy == "")
            IsDaHuy = Request.QueryString["IsHoanTra"];
        if (IsDaHuy == "1")
            sqlSelect += " AND ISHOANTRA=1";
        string ngayhoantra = Request.QueryString["ngayhoantra"];
        
        DataTable dtsrc = DataAcess.Connect.GetTable(sqlSelect);
        NgayThu = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        if (dtsrc != null && dtsrc.Rows.Count > 0)
        {
            LoaiThu = dtsrc.Rows[0]["LoaiThu"].ToString();
            NgayThu = dtsrc.Rows[0]["SysDate"].ToString();
            NOIDUNGTHU = dtsrc.Rows[0]["NOIDUNGTHU"].ToString();
            LoaiThu2 = dtsrc.Rows[0]["LoaiThu2"].ToString();
        }
        if (dtsrc == null || dtsrc.Rows.Count == 0)
        {
            string FullName = UserLogin.FullName(this);
            if (LoaiThu == "ChenhLechBHYT")
                sqlSelect = @" 
	                            SELECT   
			                            TENDICHVU=N'Đồng chi trả'
                                       ,PrevName=''
		                               ,TENNHOM =''
		                               ,a.BNPhaiTraChenhLechBHYT AS TONGTIEN
		                               ,'' AS SOPHONG
                                       ,b.mabenhnhan
                                       ,b.tenbenhnhan
                                       ,SOBHYT=NULL
                                       ,b.ngaysinh
                                       ,tennguoithu=N'" + FullName + @"'
                                       ,dungtuyen=NULL
                                       ,loai=1
                                       ,MAPHIEU='" + MaPhieu + @"'
                                       ,a.IDBENHNHAN
                                       ,SOTT=NULL
                                       ,LoaiThu=N'" + LoaiThu + @"'
                                       ,nLoaiThu=5
                                        ,SoLuong='1'
                                        ,dvt = N''
                                        ,DonGiaDV=A.TienGiaDV
                                        ,ThanhTienDV=A.TienGiaDV
                                        ,DonGiaBH=TongTienBH
                                        ,ThanhTienBH=TongTienBH
                                        ,BHTra=a.BHTra
                                        ,PHUTHUBH=a.TienPhuThuBH
                                        ,DONGIA=A.TONGTIENDV
                                        ,ThanhTien=a.TONGTIENDV
                                        ,IdChiTietDangKyKham=IDCHITIETDANGKYKHAM_LAST
                                        ,IdKhamBenhCanLamSan=NULL
                                        ,IdThuoc=NULL
                                        ,IdPhieuXuat=NULL
                                        ,IdBenhNhanBHDongTien='" + MaPhieuCLS + @"'
                                        ,loaithu2=N'" + LoaiThu2 + @"'
                                        ,NOIDUNGTHU=N'" + NOIDUNGTHU + @"'
                                        ,ISBHYT=A.ISBHYT
                                        ,Khoa=DBO.HB_KHOADANGKY2(A.IDKHAMBENH_LAST)
                                        ,CHIETKHAU=0
	                            FROM HS_BenhNhanBHDongTien A 
	                            LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
	                            WHERE	A.ID='" + MaPhieuCLS + @"'";
            if (LoaiThu == "VIENPHINOITRU")
            {
                sqlSelect = @" 
	                            SELECT   
			                            TENDICHVU=N'Thanh toán ra viện'
                                       ,PrevName=''
		                               ,TENNHOM =''
		                               ,a.TongTienBNPTConLai AS TONGTIEN
		                               ,'' AS SOPHONG
                                       ,b.mabenhnhan
                                       ,b.tenbenhnhan
                                       ,SOBHYT=NULL
                                       ,b.ngaysinh
                                       ,tennguoithu=N'" + FullName + @"'
                                       ,dungtuyen=NULL
                                       ,loai=(CASE WHEN ISNULL(A.ISBHYT,0)=1 THEN 1 ELSE 2 END )
                                       ,MAPHIEU='" + MaPhieu + @"'
                                       ,a.IDBENHNHAN
                                       ,SOTT=NULL
                                       ,LoaiThu=N'" + LoaiThu + @"'
                                       ,nLoaiThu=6
                                        ,SoLuong='1'
                                        ,dvt = N''
                                        ,DonGiaDV=A.TongTienBNDaTra
                                        ,ThanhTienDV=A.TongTienBNDaTra
                                        ,DonGiaBH=TongTienBH
                                        ,ThanhTienBH=TongTienBH
                                        ,BHTra=a.BHTra
                                        ,PHUTHUBH=0
                                        ,DONGIA=A.TONGTIENDV
                                        ,ThanhTien=a.TONGTIENDV
                                        ,IdChiTietDangKyKham=IDCHITIETDANGKYKHAM_LAST
                                        ,IdKhamBenhCanLamSan=NULL
                                        ,IdThuoc=NULL
                                        ,IdPhieuXuat=NULL
                                        ,IdBenhNhanBHDongTien='" + MaPhieuCLS + @"'
                                        ,loaithu2=N'" + LoaiThu2 + @"'
                                        ,NOIDUNGTHU=N'" + NOIDUNGTHU + @"'
                                        ,ISBHYT=A.ISBHYT
                                        ,Khoa=DBO.HB_KHOADANGKY2(A.IDKHAMBENH_LAST)
                                        ,CHIETKHAU=0
					         FROM HS_BenhNhanBHDongTien A  
	                            LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
	                            WHERE	A.ID='" + MaPhieuCLS + @"'";

            }

            if (LoaiThu == "DichVuCLS")
                sqlSelect = @"SELECT   
                        TENDICHVU
                       ,PrevName=''
                       ,TENNHOM=C.TenPhongKhamBenh
                       ,( CASE WHEN A.ISBHYT=1 THEN A.PHUTHUBH ELSE A.BNTongPhaiTra END) AS TONGTIEN
                       ,C.MAPHONGKHAMBENH AS SOPHONG
                       ,mabenhnhan
                       ,tenbenhnhan
                       ,SOBHYT=NULL
                       ,ngaysinh
                       ,tennguoithu=N'" + FullName + @"'
                       ,dungtuyen=NULL
                       ,loai=e.LoaiKhamID
                       ,MAPHIEU='" + MaPhieu + @"'
                       ,F.IDBENHNHAN
                       ,SOTT=NULL
                       ,LoaiThu=N'" + LoaiThu + @"'
                       ,nLoaiThu=2
                       ,SoLuong=isnull(A.SoLuong,1)
                       ,dvt = N'Lần'
                       ,DonGiaDV=A.DONGIADV
                        ,ThanhTienDV=A.THANHTIENDV
                        ,DonGiaBH=A.DONGIABH
                        ,ThanhTienBH=A.THANHTIENBH
                        ,BHTra=0
                        ,PHUTHUBH=A.PHUTHUBH
                        ,DONGIA=ISNULL(A.PHUTHUBH,0)+ (CASE WHEN A.ISBHYT=1 THEN 0 ELSE  A.BNTongPhaiTra  END ) /isnull(A.SoLuong,1)
                        ,THANHTIEN=ISNULL(A.PHUTHUBH,0)+ (CASE WHEN A.ISBHYT=1 THEN 0 ELSE  A.THANHTIENDV  END ) 
                        ,IdChiTietDangKyKham=H.IDCHITIETDANGKYKHAM
                        ,IdKhamBenhCanLamSan=A.IDKHAMBENHCANLAMSAN
                        ,IdThuoc=NULL
                        ,IdPhieuXuat=NULL
                        ,IdBenhNhanBHDongTien=E.IdBenhBHDongTien
                        ,loaithu2=N'" + LoaiThu2 + @"'
                        ,NOIDUNGTHU=N'" + NOIDUNGTHU + @"'
                        ,ISBHYT=A.ISBHYT
                        ,KHOA=I.TENPHONGKHAMBENH
                        ,CHIETKHAU=A.CHIETKHAU
                
                FROM KHAMBENHCANLAMSAN A
                LEFT JOIN BANGGIADICHVU B ON A.IDCANLAMSAN=B.IDBANGGIADICHVU
                LEFT JOIN PHONGKHAMBENH C ON B.IDPHONGKHAMBENH=C.IDPHONGKHAMBENH
                LEFT JOIN KHAMBENH D ON A.IDKHAMBENH=D.IDKHAMBENH
                LEFT JOIN DANGKYKHAM E ON D.IDDANGKYKHAM=E.IDDANGKYKHAM
                LEFT JOIN BENHNHAN F ON ISNULL( E.IDBENHNHAN,A.IDBENHNHAN)=F.IDBENHNHAN
                LEFT JOIN CHITIETDANGKYKHAM H ON D.IDCHITIETDANGKYKHAM=H.IDCHITIETDANGKYKHAM
                LEFT JOIN PHONGKHAMBENH I ON ISNULL(ISNULL(D.IDKHOA,D.IDPHONGKHAMBENH),A.idkhoadangky)=I.IDPHONGKHAMBENH
                WHERE	     ISNULL(A.IDKHAMBENH,0)<>0  
	                    AND  ISNULL(A.DAHUY,0)=0
	                    AND ISNULL(A.DATHU,0)=0
                        AND ISNULL(B.IsCLS,0)=1
                        AND MAPHIEUCLS='" + MaPhieuCLS + "'";

            if (LoaiThu == "DVKTKHAC")
                sqlSelect = @"SELECT   
                        TENDICHVU
                       ,PrevName=''
                       ,TENNHOM=C.TenPhongKhamBenh
                       ,( CASE WHEN A.ISBHYT=1 THEN A.PHUTHUBH ELSE A.BNTongPhaiTra END) AS TONGTIEN
                       ,C.MAPHONGKHAMBENH AS SOPHONG
                       ,mabenhnhan
                       ,tenbenhnhan
                       ,SOBHYT=NULL
                       ,ngaysinh
                       ,tennguoithu=N'" + FullName + @"'
                       ,dungtuyen=NULL
                       ,loai=e.LoaiKhamId
                       ,MAPHIEU='" + MaPhieu + @"'
                       ,F.IDBENHNHAN
                       ,SOTT=NULL
                       ,LoaiThu=N'" + LoaiThu + @"'
                       ,nLoaiThu=2
                       ,SoLuong=isnull(A.SoLuong,1)
                       ,dvt = N'Lần'
                       ,DonGiaDV=A.DONGIADV
                        ,ThanhTienDV=A.THANHTIENDV
                        ,DonGiaBH=A.DONGIABH
                        ,ThanhTienBH=A.THANHTIENBH
                        ,BHTra=0
                        ,PHUTHUBH=A.PHUTHUBH
                        ,DONGIA=ISNULL(A.PHUTHUBH,0)+ (CASE WHEN A.ISBHYT=1 THEN 0 ELSE  A.BNTongPhaiTra  END ) /isnull(A.SoLuong,1)
                        ,THANHTIEN=ISNULL(A.PHUTHUBH,0)+ (CASE WHEN A.ISBHYT=1 THEN 0 ELSE  A.THANHTIENDV  END ) 
                        ,IdChiTietDangKyKham=H.IDCHITIETDANGKYKHAM
                        ,IdKhamBenhCanLamSan=A.IDKHAMBENHCANLAMSAN
                        ,IdThuoc=NULL
                        ,IdPhieuXuat=NULL
                        ,IdBenhNhanBHDongTien=E.IdBenhBHDongTien
                        ,loaithu2=N'" + LoaiThu2 + @"'
                        ,NOIDUNGTHU=N'" + NOIDUNGTHU + @"'
                        ,ISBHYT=A.ISBHYT
                        ,KHOA=I.TENPHONGKHAMBENH
                        ,CHIETKHAU=A.CHIETKHAU
                FROM KHAMBENHCANLAMSAN A
                LEFT JOIN BANGGIADICHVU B ON A.IDCANLAMSAN=B.IDBANGGIADICHVU
                LEFT JOIN PHONGKHAMBENH C ON B.IDPHONGKHAMBENH=C.IDPHONGKHAMBENH
                LEFT JOIN KHAMBENH D ON A.IDKHAMBENH=D.IDKHAMBENH
                LEFT JOIN DANGKYKHAM E ON D.IDDANGKYKHAM=E.IDDANGKYKHAM
                LEFT JOIN BENHNHAN F ON ISNULL( E.IDBENHNHAN,A.IDBENHNHAN)=F.IDBENHNHAN
                LEFT JOIN CHITIETDANGKYKHAM H ON D.IDCHITIETDANGKYKHAM=H.IDCHITIETDANGKYKHAM
                LEFT JOIN PHONGKHAMBENH I ON ISNULL(ISNULL(D.IDKHOA,D.IDPHONGKHAMBENH),A.idkhoadangky)=I.IDPHONGKHAMBENH
                WHERE	
                        ISNULL(A.IDKHAMBENH,0)<>0  
	                    AND  ISNULL(A.DAHUY,0)=0
	                    AND ISNULL(A.DATHU,0)=0
                        AND ISNULL(B.ISDVKT,0)=1
                        AND MAPHIEUCLS='" + MaPhieuCLS + "'";


            if (LoaiThu == "DichVuCLSTUDEN")
                sqlSelect = @"SELECT   
                        TENDICHVU
                       ,PrevName=''
                       ,TENNHOM=C.TenPhongKhamBenh
                       , A.BNTongPhaiTra AS TONGTIEN
                       ,C.MAPHONGKHAMBENH AS SOPHONG
                       ,mabenhnhan
                       ,tenbenhnhan
                       ,SOBHYT=NULL
                       ,ngaysinh
                       ,tennguoithu=N'" + FullName + @"'
                       ,dungtuyen=NULL
                       ,loai=2
                       ,MAPHIEU='" + MaPhieu + @"'
                       ,D.IDBENHNHAN
                       ,SOTT=NULL
                       ,LoaiThu=N'" + LoaiThu + @"'
                       ,nLoaiThu=2
                       ,SoLuong=isnull(A.SoLuong,1)
                       ,dvt = N'Lần'
                       ,DonGiaDV=A.DONGIADV
                        ,ThanhTienDV=A.THANHTIENDV
                        ,DonGiaBH=A.DONGIABH
                        ,ThanhTienBH=A.THANHTIENBH
                        ,BHTra=0
                        ,PHUTHUBH=0
                        ,DONGIA=A.BNTongPhaiTra /isnull(A.SoLuong,1)
                        ,THANHTIEN= A.THANHTIENDV 
                        ,IdChiTietDangKyKham=NULL
                        ,IdKhamBenhCanLamSan=A.IDKHAMBENHCANLAMSAN
                        ,IdThuoc=NULL
                        ,IdPhieuXuat=NULL
                        ,IdBenhNhanBHDongTien=NULL
                        ,loaithu2=N'" + LoaiThu2 + @"'
                        ,NOIDUNGTHU=N'" + NOIDUNGTHU + @"'
                        ,ISBHYT=NULL
                        ,KHOA=F.TENPHONGKHAMBENH
                        ,CHIETKHAU=A.CHIETKHAU
                
                FROM KHAMBENHCANLAMSAN A
                LEFT JOIN BANGGIADICHVU B ON A.IDCANLAMSAN=B.IDBANGGIADICHVU
                LEFT JOIN PHONGKHAMBENH C ON B.IDPHONGKHAMBENH=C.IDPHONGKHAMBENH
                LEFT JOIN BENHNHAN D ON A.IDBENHNHAN=D.IDBENHNHAN
                LEFT JOIN PHONGKHAMBENH F ON A.idkhoadangky=F.IDPHONGKHAMBENH
                WHERE	  
                        ISNULL(A.IDKHAMBENH,0)=0
	                    AND  ISNULL(A.DAHUY,0)=0
	                    AND ISNULL(A.DATHU,0)=0
                        AND ISNULL(B.IsCLS,0)=1
                        AND MAPHIEUCLS='" + MaPhieuCLS + "'";

            if (LoaiThu == "DVKTKHACTUDEN")
                sqlSelect = @"SELECT   
                        TENDICHVU
                       ,PrevName=''
                       ,TENNHOM=C.TenPhongKhamBenh
                       , A.BNTongPhaiTra AS TONGTIEN
                       ,C.MAPHONGKHAMBENH AS SOPHONG
                       ,mabenhnhan
                       ,tenbenhnhan
                       ,SOBHYT=NULL
                       ,ngaysinh
                       ,tennguoithu=N'" + FullName + @"'
                       ,dungtuyen=NULL
                       ,loai=2
                       ,MAPHIEU='" + MaPhieu + @"'
                       ,D.IDBENHNHAN
                       ,SOTT=NULL
                       ,LoaiThu=N'" + LoaiThu + @"'
                       ,nLoaiThu=2
                       ,SoLuong=isnull(A.SoLuong,1)
                       ,dvt = N'Lần'
                       ,DonGiaDV=A.DONGIADV
                        ,ThanhTienDV=A.THANHTIENDV
                        ,DonGiaBH=A.DONGIABH
                        ,ThanhTienBH=A.THANHTIENBH
                        ,BHTra=0
                        ,PHUTHUBH=0
                        ,DONGIA=A.BNTongPhaiTra /isnull(A.SoLuong,1)
                        ,THANHTIEN= A.THANHTIENDV 
                        ,IdChiTietDangKyKham=NULL
                        ,IdKhamBenhCanLamSan=A.IDKHAMBENHCANLAMSAN
                        ,IdThuoc=NULL
                        ,IdPhieuXuat=NULL
                        ,IdBenhNhanBHDongTien=NULL
                        ,loaithu2=N'" + LoaiThu2 + @"'
                        ,NOIDUNGTHU=N'" + NOIDUNGTHU + @"'
                        ,ISBHYT=NULL
                        ,KHOA=F.TENPHONGKHAMBENH
                        ,CHIETKHAU=A.CHIETKHAU
                
                FROM KHAMBENHCANLAMSAN A
                LEFT JOIN BANGGIADICHVU B ON A.IDCANLAMSAN=B.IDBANGGIADICHVU
                LEFT JOIN PHONGKHAMBENH C ON B.IDPHONGKHAMBENH=C.IDPHONGKHAMBENH
                LEFT JOIN BENHNHAN D ON A.IDBENHNHAN=D.IDBENHNHAN
                LEFT JOIN PHONGKHAMBENH F ON A.idkhoadangky=F.IDPHONGKHAMBENH
                WHERE	  
                        ISNULL(A.IDKHAMBENH,0)=0
	                    AND  ISNULL(A.DAHUY,0)=0
	                    AND ISNULL(A.DATHU,0)=0
                        AND ISNULL(B.ISDVKT,0)=1
                        AND MAPHIEUCLS='" + MaPhieuCLS + "'";

            if (LoaiThu.ToUpper() == "PHIKHAM")
                sqlSelect = @"SELECT   
                           tendichvu= case when a.idbanggiadichvu = isnull((select convert(int,paravalue) from kb_parameter where paraname='IdDichVu_MuaSo'),628)
	                            then TENDICHVU
                                else  TENDICHVU+' ('+isnull([dbo].[nvk_PhongIn](h.id),0)+', Stt: '+convert(varchar(10),isnull(a.Sott,0))+')'
                                end
                           ,PrevName=''
                           ,TENNHOM 
                          ,(A.BNTongPhaiTra -ISNULL(A.BNTra,0)) AS TONGTIEN
                          ,H.MASO+' ,'+ 'STT: ' + CONVERT(NVARCHAR, A.SOTT) AS SOPHONG
                           ,mabenhnhan
                           ,tenbenhnhan
                           ,SOBHYT=NULL
                           ,ngaysinh
                           ,tennguoithu=N'" + FullName + @"'
                           ,dungtuyen=NULL
                           ,loai=b1.LoaiKhamId
                           ,MAPHIEU='" + MaPhieu + @"'
                           ,F.IDBENHNHAN
                           ,SOTT='STT: ' + CONVERT(NVARCHAR, A.SOTT)
                           ,LoaiThu=N'" + LoaiThu + @"'
                           ,nLoaiThu=1
                           ,SoLuong=isnull(A.SoLuong,1)
                           ,dvt = N'Lần'
                           , DonGiaDV=A.DONGIADV
                            ,ThanhTienDV=A.THANHTIENDV
                            ,DonGiaBH=A.DONGIABH
                            ,ThanhTienBH=A.THANHTIENBH
                            ,BHTra=A.BHtra
                            ,PHUTHUBH=A.PHUTHUBH
                            ,DONGIA=A.BNTongPhaiTra
                            ,THANHTIEN=A.BNTongPhaiTra
                        ,IdChiTietDangKyKham=A.IDCHITIETDANGKYKHAM
                        ,IdKhamBenhCanLamSan=NULL
                        ,IdThuoc=NULL
                        ,IdPhieuXuat=NULL
                        ,IdBenhNhanBHDongTien=B1.IdBenhBHDongTien
                        ,loaithu2=N'" + LoaiThu2 + @"'
                        ,NOIDUNGTHU=N'" + NOIDUNGTHU + @"'
                        ,ISBHYT=A.ISBHYT
                        ,KHOA=C.TENPHONGKHAMBENH
                        ,CHIETKHAU=A.CHIETKHAU

                    FROM CHITIETDANGKYKHAM A
                    LEFT JOIN DANGKYKHAM B1 ON A.IDDANGKYKHAM=B1.IDDANGKYKHAM
                    LEFT JOIN BANGGIADICHVU B ON A.IDBANGGIADICHVU=B.IDBANGGIADICHVU
                    LEFT JOIN PHONGKHAMBENH C ON ISNULL(B.IDPHONGKHAMBENH,A.IDKHOA)=C.IDPHONGKHAMBENH
                    LEFT JOIN BENHNHAN F ON b1.IDBENHNHAN=F.IDBENHNHAN
                    LEFT JOIN KB_PHONG H ON A.PHONGID=H.ID
                    WHERE	 ISNULL(A.DAHUY,0)=0
	                        AND ISNULL(A.IsDaThu,0)=0
                            
	                        AND  A.BNTongPhaiTra -ISNULL(A.BNTra,0)>0
                            AND A.IDDANGKYKHAM='" + MaPhieuCLS + @"'";

            if (LoaiThu.ToLower() == "tamung")
            {
                sqlSelect = @"select          TENDICHVU=N'Tạm ứng'
				                                        ,PrevName=''
				                                        ,TENNHOM=N'Tạm ứng'
				                                        ,TONGTIEN=sotien
				                                        ,SOPHONG=null
				                                        ,mabenhnhan=d.mabenhnhan
				                                        ,tenbenhnhan=d.tenbenhnhan
				                                        ,SOBHYT=NULL
				                                        ,ngaysinh=d.ngaysinh 
				                                        ,tennguoithu=N'" + FullName + @"'
				                                        ,dungtuyen=NULL
				                                        ,loai=c.loaikhamid
				                                        ,MAPHIEU=N'" + MaPhieu + @"'
				                                        ,IDBENHNHAN=d.idbenhnhan
				                                        ,SOTT=null
				                                        ,LoaiThu=N'TamUng'
				                                        ,nLoaiThu=4
				                                        ,SoLuong=1
				                                        ,dvt=N'Lần'
				                                        ,DonGiaDV=sotien
				                                        ,ThanhTienDV=sotien
				                                        ,DonGiaBH=0
				                                        ,ThanhTienBH=0
				                                        ,BHTra=0
				                                        ,PhuThuBH=0
				                                        ,DONGIA=sotien
				                                        ,THANHTIEN=sotien
				                                        ,b.IdChiTietDangKyKham
				                                        ,IdKhamBenhCanLamSan=null
				                                        ,IdThuoc=null
				                                        ,IdPhieuXuat=null
				                                        ,IdBenhNhanBHDongTien=c.IdBenhBHDongTien
				                                        ,LoaiThu2='tamung'
				                                        ,NOIDUNGTHU=N'Tạm ứng'
				                                        ,ISBHYT=0
                                                        ,KHOA=TENPHONGKHAMBENH
                                                        ,CHIETKHAU=0
                                         from TAMUNG a
                                         left join chitietdangkykham b on a.iddangkykham =b.idchitietdangkykham
                                        left join dangkykham c on c.iddangkykham=b.iddangkykham
                                        left join benhnhan d on c.idbenhnhan=d.idbenhnhan
                                        LEFT JOIN PHONGKHAMBENH E ON A.idkhoaTU=E.IDPHONGKHAMBENH
                                         WHERE a.idtamung=" + MaPhieuCLS + "";
            }
            dtsrc = DataAcess.Connect.GetTable(sqlSelect);

        }
        else InLai = true;
        if (dtsrc == null || dtsrc.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không thể load được thông tin phiếu thu !");
            return;
        }
        string PrevView = Request.QueryString["PrevView"];
        #region nvk mặc định số dòng trong phí khám
        if (string.IsNullOrEmpty(IsDaHuy))
            IsDaHuy = "0";
        if (LoaiThu.ToUpper() == "PHIKHAM" && !IsDaHuy.Equals("1") && !isMauPhiKhamFull && isKhamBH)
        {
            for (int i = (dtsrc.Rows.Count + 1); i < 6; i++)
            {
                DataRow nvk_row = dtsrc.NewRow();
                nvk_row["nLoaiThu"] = 100;
                for (int j = 0; j < dtsrc.Columns.Count; j++)
                {
                    if (dtsrc.Columns[j].ColumnName.ToLower().Equals("nloaithu"))
                        continue;
                    try
                    {
                        nvk_row[dtsrc.Columns[j].ColumnName] = null;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            nvk_row[dtsrc.Columns[j].ColumnName] = 0;
                        }
                        catch (Exception)
                        {
                            nvk_row[dtsrc.Columns[j].ColumnName] = DateTime.Now;
                        }
                    }
                }
                dtsrc.Rows.Add(nvk_row);
            }
        }
        #endregion
        dtsrc.DefaultView.Sort = "nLoaiThu,TENNHOM";
        dtsrc = dtsrc.DefaultView.ToTable();
        TongTienBNPT = 0;
        double dThanhTien = 0;
        double dThanhTienDV = 0;
        double dPhuThuBH = 0;

        for (int i = 0; i < dtsrc.Rows.Count; i++)
        {
            string iTongtien = dtsrc.Rows[i]["TongTien"].ToString();
            if (iTongtien == "") iTongtien = "0";
            TongTienBNPT += double.Parse(iTongtien);

            string iThanhTien = dtsrc.Rows[i]["ThanhTien"].ToString();
            if (iThanhTien == "") iThanhTien = "0";
            dThanhTien += double.Parse(iThanhTien);

            string iThanhTienDV = dtsrc.Rows[i]["ThanhTienDV"].ToString();
            if (iThanhTienDV == "") iThanhTienDV = "0";
            dThanhTienDV += double.Parse(iThanhTienDV);

            string iPhuThuBH = dtsrc.Rows[i]["PhuThuBH"].ToString();
            if (iPhuThuBH == "") iPhuThuBH = "0";
            dPhuThuBH += double.Parse(iPhuThuBH);
        }
        #endregion
        if (PrevView != "1" && !InLai)
        {
            #region Lưu  lại 1 table Đóng tiền để đưa vào danh sách đã thu
            if (!InLai)
            {
                string sysDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                for (int i = 0; i < dtsrc.Rows.Count; i++)
                {
                    if (dtsrc.Rows[i]["tongtien"].ToString() != "0")
                    {
                        int nvk_soCot = dtsrc.Columns.Count;
                        string sqlInsertIntoHS_DSDATHU = "INSERT INTO HS_DSDATHU (SysDate,";
                        for (int j = 0; j < nvk_soCot; j++)
                            sqlInsertIntoHS_DSDATHU += dtsrc.Columns[j].ColumnName + ",";
                        sqlInsertIntoHS_DSDATHU = sqlInsertIntoHS_DSDATHU.Remove(sqlInsertIntoHS_DSDATHU.Length - 1, 1);
                        sqlInsertIntoHS_DSDATHU += ") VALUES('" + sysDate + "',";
                        for (int j = 0; j < nvk_soCot; j++)
                            sqlInsertIntoHS_DSDATHU += "N'" + dtsrc.Rows[i][j].ToString() + "',";
                        sqlInsertIntoHS_DSDATHU = sqlInsertIntoHS_DSDATHU.Remove(sqlInsertIntoHS_DSDATHU.Length - 1, 1);
                        sqlInsertIntoHS_DSDATHU += ")";
                        bool OK_sqlInsertIntoHS_DSDATHU = DataAcess.Connect.ExecSQL(sqlInsertIntoHS_DSDATHU);
                        if (!OK_sqlInsertIntoHS_DSDATHU) StaticData.MsgBox(this, "Không thể lưu vào Danh sách đã thu");
                    }

                }
            }
            #endregion
            #region Lưu lại số tiền , trạng thái đã trả cho các giao dịch
            string IdBenhNhanBHDongTien_ = dtsrc.Rows[0]["IdBenhNhanBHDongTien"].ToString();
            if (IdBenhNhanBHDongTien_ == "") IdBenhNhanBHDongTien_ = "0";
            string IdBenNhan_ = dtsrc.Rows[0]["IdBenhNhan"].ToString();
            if (IdBenNhan_ == "") IdBenNhan_ = "0";
            string sqlUpdate = " EXEC zHS_CAPNHAT_SOTIENDADONG  " + IdBenhNhanBHDongTien_ + ",'" + LoaiThu + "'," + TongTienBNPT + ",'" + MaPhieuCLS + "','" + MaPhieu + "'," + IdBenNhan_;
            bool OK_ = DataAcess.Connect.ExecSQL(sqlUpdate);
            if (!OK_)
            {
                StaticData.MsgBox(this, "Không thể cập nhật được số tiền đã thu");
                return;
            }
             #endregion
        }
        if (dtsrc == null) return;
        if (dtsrc.Columns.IndexOf("GiamGia") == -1)
            dtsrc.Columns.Add("GiamGia", dPhuThuBH.GetType());
        for (int i = 0; i < dtsrc.Rows.Count; i++)
            dtsrc.Rows[i]["GiamGia"] = dtsrc.Rows[i]["ChietKhau"];
        #region View in CrytalReport
        crystalReport = new ReportDocument();
        #region ReportName
        string ReportPath = "ReportDesign";
        string ReportName = "";
        string iloaithu = LoaiThu.ToLower();
        if (iloaithu == "VIENPHINOITRU".ToLower()) iloaithu = "ChenhLechBHYT".ToLower();
        switch (iloaithu)
        {
            case "phikham":
                if (isKhamBH && dtsrc.Rows[0]["loai"].ToString().Trim().Equals("1"))
                    ReportName = isMauPhiKhamFull ? "rptPhiKham-full.rpt" : "rptPhiKham-new.rpt";
                else
                    ReportName = isMauPhiKhamFull ? "rptPhiKhamNoBH-full.rpt" : "rptPhiKhamNoBH.rpt";
                break;
            case "tamung": ReportName = "rptTamUng.rpt"; break;
            case "chenhlechbhyt": ReportName = "rptthanhtoanravien.rpt"; break;
            default:
                if (isKhamBH && dtsrc.Rows[0]["loai"].ToString().Trim().Equals("1"))
                    ReportName = "rptPhieuThuTH_MD.rpt";
                else
                    ReportName = "rptPhiKhamNoBH-full.rpt";
                break;
        }
        if (IsDaHuy == "1") ReportName = "rptPhieuThuTH_MD.rpt";

        ReportName = ReportPath + "/" + ReportName;
        crystalReport.Load(Server.MapPath(ReportName));
        #endregion
        #region DataSource
        double thanhtienbh_total = 0;

        DataTable dtTamUng = new DataTable();
        string sotienbangchu = "";
        string idbenhnhan_in = dtsrc.Rows[0]["idbenhnhan"].ToString();
        double tongtien_in = 0;
        if (LoaiThu.ToUpper() == "TAMUNG")
        {
            #region Report tiêu đề
            DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
            if (dtTieuDeCty != null)
                crystalReport.OpenSubreport("crpt_ThongTinDonVi.rpt").SetDataSource(dtTieuDeCty);
            #endregion
        }
        #region Khac mau tam ung
        else
        {
            #region Report tiêu đề công ty
            DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
            if (dtTieuDeCty != null)
                crystalReport.OpenSubreport("crpt_ThongTinDonVi.rpt").SetDataSource(dtTieuDeCty);
            string tieude = dtTieuDeCty.Rows[0]["Ten_Cty"].ToString();
            string[] slp = tieude.Split('-');
            string til = slp[0];
            string subtil = (slp.Length > 1 ? slp[1] : "");
            ((TextObject)crystalReport.OpenSubreport("crpt_ThongTinDonVi.rpt").ReportDefinition.ReportObjects["txtTitle"]).Text = til;
            #endregion
            DataSet ds = new DataSet();
            DataTable dt_new = new DataTable();
            #region ma vach
            string mabenhnhan = dtsrc.Rows[0]["mabenhnhan"].ToString();
            Barcode128 barcode = new Barcode128();
            barcode.ChecksumText = false;
            barcode.Code = mabenhnhan;
            DataTable dtmavach = new DataTable();
            DataRow Ro = dtmavach.NewRow();
            Image bmp = barcode.CreateDrawingImage(Color.Black, Color.White);
            Byte[] arrByte = (Byte[])TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
            dtmavach.Columns.Add("MaVachKhoe", arrByte.GetType());
            Ro["MaVachKhoe"] = arrByte;
            dtmavach.Rows.Add(Ro);

            #endregion
            dt_new.Columns.Add("stt");
            dt_new.Columns.Add("DienGiai");//edited
            dt_new.Columns.Add("sotienphaithu", tongtien_in.GetType());
            dt_new.Columns.Add("bhytchitra", tongtien_in.GetType());
            dt_new.Columns.Add("sotienconlai", tongtien_in.GetType());
            dt_new.Columns.Add("sotienphaithubn", tongtien_in.GetType());
            dt_new.Columns.Add("giamgia", tongtien_in.GetType());
            dt_new.Columns.Add("chietkhau", tongtien_in.GetType());
            for (int ii = 0; ii < dtsrc.Rows.Count; ii++)
            {
                string dongiaDV = dtsrc.Rows[ii]["DonGiaDV"].ToString(); //edited
                string thanhtienDV = dtsrc.Rows[ii]["thanhtiendv"].ToString();
                string phuthubh = dtsrc.Rows[ii]["phuthubh"].ToString();
                if (thanhtienDV == "") thanhtienDV = "0";
                if (phuthubh == "") phuthubh = "0";
                string thanhtienbh = dtsrc.Rows[ii]["ThanhTienBH"].ToString();
                if (thanhtienbh == "") thanhtienbh = "0";
                thanhtienbh_total += double.Parse(thanhtienbh);
                string bhtra = dtsrc.Rows[ii]["BHTRA"].ToString();
                if (bhtra == "") bhtra = "0";
                string thanhtien = dtsrc.Rows[ii]["thanhtien"].ToString();
                string dongia = dtsrc.Rows[ii]["dongia"].ToString();
                if (thanhtien == "") thanhtien = "0";
                if (dongia == "") dongia = "0";
                string tongtien = dtsrc.Rows[ii]["tongtien"].ToString();
                if (tongtien == "") tongtien = "0";
                bool IsBHYT = StaticData.IsCheck(dtsrc.Rows[ii]["IsBHYT"].ToString());
                string LoaiBN = dtsrc.Rows[ii]["loai"].ToString();

                DataRow R = dt_new.NewRow();
                R["stt"] = ii.ToString();
                R["DienGiai"] = dtsrc.Rows[ii]["tendichvu"].ToString();//edited
                R["chietkhau"] = (dtsrc.Rows[ii]["chietkhau"].ToString() != "" ? dtsrc.Rows[ii]["chietkhau"].ToString() : "0");
                R["giamgia"] = (dtsrc.Rows[ii]["giamgia"].ToString() != "" ? dtsrc.Rows[ii]["giamgia"].ToString() : "0");
                // GIA DICH VU
                R["sotienphaithu"] = dongia;
                // GIA BH
                R["bhytchitra"] = (IsBHYT ? thanhtienbh : "0");
                // PHU THU
                R["sotienconlai"] = (LoaiBN == "1" ? (IsBHYT ? phuthubh : thanhtienDV) : "0");
                // KHAC PHU THU
                R["sotienphaithubn"] = (LoaiBN == "1" ? "0" : thanhtienDV);

                if ((LoaiThu.ToUpper() == "PHIKHAM"
                    || LoaiThu.ToUpper() == "DICHVUCLS"
                    || LoaiThu.ToUpper() == "DVKTKHAC"
                    || LoaiThu.ToUpper() == "DICHVUCLSTUDEN"
                    || LoaiThu.ToUpper() == "DVKTKHACTUDEN"
                    ) && LoaiBN != "1")
                {
                    R["sotienphaithubn"] = dongia;
                    R["sotienconlai"] = thanhtienDV;
                    tongtien = thanhtienDV;
                }
                //TONG TIEN
                tongtien_in += double.Parse(tongtien);

                dt_new.Rows.Add(R);
            }
            tongtien_in = Math.Floor(tongtien_in+0.5);

            string stemp_TongTien = tongtien_in.ToString();
            stemp_TongTien = stemp_TongTien.Replace("-", "");

            sotienbangchu = StaticData.ConvertMoneyToText(stemp_TongTien);

            dtmavach.TableName = "MaVach";
            ds.Tables.Add(dtmavach);
            if (iloaithu != "chenhlechbhyt")
            {
                dt_new.TableName = "dtThuPhiDV";
                ds.Tables.Add(dt_new);
                crystalReport.SetDataSource(ds);
            }
        }
        #endregion
        #endregion
        #region set parameter
        string IdBenhNhanBHDongTien = dtsrc.Rows[0]["IdBenhNhanBHDongTien"].ToString();
        DataTable dtBenhNhan = DataAcess.Connect.GetTable("SELECT * FROM BENHNHAN WHERE IDBENHNHAN=" + idbenhnhan_in);
        string _tennguoithu = UserLogin.FullName(this);
        crystalReport.SetParameterValue("@tennguoithu", _tennguoithu);
        #region Tạm ứng
        if (LoaiThu.ToUpper() == "TAMUNG")
        {
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtTieuDe"]).Text = "PHIẾU THU TẠM ỨNG";
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtSo"]).Text = dtsrc.Rows[0]["maphieu"].ToString();
            string textTien = StaticData.ConvertMoneyToText(dtsrc.Rows[0]["tongtien"].ToString());
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtTienChu"]).Text = "(" + textTien + ")";
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtTienSo"]).Text = string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:0,0}", dtsrc.Rows[0]["tongtien"]);// StaticData.FormatSNumberToPrint(dtsrc.Rows[0]["tongtien"].ToString()) + " VNĐ";
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtTenBN"]).Text = dtsrc.Rows[0]["tenbenhnhan"].ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtDiaChi"]).Text = dtBenhNhan.Rows[0]["diachi"].ToString();

            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtNgay"]).Text = DateTime.Parse(NgayThu).ToString("dd");
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtThang"]).Text = DateTime.Parse(NgayThu).ToString("MM");
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtNam"]).Text = DateTime.Parse(NgayThu).ToString("yyyy");
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtngayphieu"]).Text = DateTime.Parse(NgayThu).ToString("dd/MM/yyyy");


            string sqlLanTamUng = @"SELECT ISNULL((SELECT COUNT (* ) +1  FROM TAMUNG WHERE IDDANGKYKHAM=T.IDDANGKYKHAM AND IDTAMUNG<T.IDTAMUNG),1)  AS SL
                                    FROM TAMUNG T
                                    WHERE T.MAPHIEU_TU='" + dtsrc.Rows[0]["MAPHIEU"].ToString() + "'";
            string nvk_lyDoTU = DataAcess.Connect.GetTable("select isnull((select LyDoTU from tamung where MAPHIEU_TU='" + dtsrc.Rows[0]["MAPHIEU"].ToString() + "'),'')").Rows[0][0].ToString();
            DataTable dtLanTU = DataAcess.Connect.GetTable(sqlLanTamUng); string LanTU = "1";
            if (dtLanTU.Rows.Count > 0) LanTU = dtLanTU.Rows[0][0].ToString();
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtQuyenSo"]).Text = LanTU;
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtLyDo"]).Text = nvk_lyDoTU;

        }
        #endregion
        #region khac bieu mau TAM UNG
        else
        {
            crystalReport.SetParameterValue("txtTienChu", sotienbangchu);
            crystalReport.SetParameterValue("txtMaBN", dtsrc.Rows[0]["mabenhnhan"].ToString());
            crystalReport.SetParameterValue("txtTenBN", dtsrc.Rows[0]["tenbenhnhan"].ToString());
            crystalReport.SetParameterValue("txtSoPhieu", MaPhieu);
            crystalReport.SetParameterValue("txtNgaySinh", dtBenhNhan.Rows[0]["ngaysinh"].ToString());
            crystalReport.SetParameterValue("txtNgayThu",  DateTime.Parse((ngayhoantra !=null && ngayhoantra !="" ? StaticData.CheckDate(ngayhoantra) : NgayThu)).ToString("dd/MM/yyyy"));
            crystalReport.SetParameterValue("txtGioiTinh", (dtBenhNhan.Rows[0]["gioitinh"].ToString() == "true" || dtBenhNhan.Rows[0]["gioitinh"].ToString() == "1" ? "Nữ" : "Nam"));
            if (dtsrc.Rows[0]["loai"].ToString() == "1")
            {
                if (iloaithu != "chenhlechbhyt")
                {
                    if (dtsrc.Rows[0]["DungTuyen"].ToString() == "Y")
                    {
                        crystalReport.SetParameterValue("txtCheck", "a");
                        crystalReport.SetParameterValue("txtTrai", "");
                    }
                    else
                    {
                        crystalReport.SetParameterValue("txtCheck", "");
                        crystalReport.SetParameterValue("txtTrai", "a");
                    }
                }
            }
            else
            {
                if (iloaithu != "chenhlechbhyt")
                {
                    crystalReport.SetParameterValue("txtCheck", "");
                    crystalReport.SetParameterValue("txtTrai", "");
                }
            }
         
            if (iloaithu == "chenhlechbhyt"||LoaiThu == "VIENPHINOITRU")
            {
                string IdBenhNhanBHDongTien_ = dtsrc.Rows[0]["IdBenhNhanBHDongTien"].ToString();
                string sqlBenhNhanBHDongTien = "SELECT * FROM HS_BENHNHANBHDONGTIEN WHERE ID=" + IdBenhNhanBHDongTien_;
                DataTable dtBNBH = DataAcess.Connect.GetTable(sqlBenhNhanBHDongTien);
                if (dtBNBH != null && dtBNBH.Rows.Count > 0)
                {
                    string TongTienBNPT_ = dtBNBH.Rows[0]["TongTienBNPT"].ToString();
                    string TongTienBNDaTra = dtBNBH.Rows[0]["TongTienBNDaTra"].ToString();
                    string TOTAL_HOANPHI = dtBNBH.Rows[0]["TOTAL_HOANPHI"].ToString();
                    string BHTra = dtBNBH.Rows[0]["BHTra"].ToString();
                    string TongTienDV = dtBNBH.Rows[0]["TongTienDV"].ToString();

                    if (TongTienBNPT_ == "") TongTienBNPT_ = "0";
                    if (TongTienBNDaTra == "") TongTienBNDaTra = "0";
                    if (BHTra == "") BHTra = "0";
                    if (TOTAL_HOANPHI == "") TOTAL_HOANPHI = "0";
                    if (TongTienDV == "") TongTienDV = "0";

                    double dTongTienBNPT = double.Parse(TongTienBNPT_);
                    double dTongTienBNDaTra = double.Parse(TongTienBNDaTra);
                    double dTOTAL_HOANPHI = double.Parse(TOTAL_HOANPHI);
                    dTongTienBNDaTra = dTongTienBNDaTra - dTOTAL_HOANPHI;
                    double dPhaiThu = dTongTienBNPT - dTongTienBNDaTra;
                    tongtien_in = dPhaiThu;

                    string stemp_TongTien1 = tongtien_in.ToString();
                    stemp_TongTien1 = stemp_TongTien1.Replace("-", "");


                    sotienbangchu = StaticData.ConvertMoneyToText(stemp_TongTien1);

                    crystalReport.SetParameterValue("tongsotienvienphi", TongTienDV);
                    crystalReport.SetParameterValue("sotienthuthem", (dPhaiThu > 0 ? dPhaiThu : 0));
                    crystalReport.SetParameterValue("tienbaohiemyt", BHTra);
                    crystalReport.SetParameterValue("sotienhoantra", (dPhaiThu > 0 ? 0 : -dPhaiThu));
                    crystalReport.SetParameterValue("tongsotientamung", dTongTienBNDaTra);
                    crystalReport.SetParameterValue("SoKhamBenh", dtBNBH.Rows[0]["Masohoso"].ToString());
                    crystalReport.SetParameterValue("khoa", dtsrc.Rows[0]["Khoa"].ToString());
                    crystalReport.SetParameterValue("txtTienChu", sotienbangchu);

                }
                
            }
            if (ReportName.IndexOf("rptPhieuThuTH_MD.rpt") != -1)
            {
                string NgayThu_Name = "Ngày thu";
                string NguoiThuTien_Name = "Người thu tiền";
                string NguoiNopTien_Name = "Người nộp tiền";
                if (IsDaHuy == "1")
                {
                    NgayThu_Name = "Ngày nhận";
                    NguoiThuTien_Name = "Kế toán viện phí";
                    NguoiNopTien_Name = "Người nhận tiền";

                }
                crystalReport.SetParameterValue("NgayThu_Name", NgayThu_Name);
                crystalReport.SetParameterValue("NguoiThuTien_Name", NguoiThuTien_Name);
                crystalReport.SetParameterValue("NguoiNopTien_Name", NguoiNopTien_Name);

            }

            DateTime dNgayThu = DateTime.Parse( ( ngayhoantra!=null &&ngayhoantra!="" ? StaticData.CheckDate(ngayhoantra): NgayThu) );
            if (LoaiThu.ToLower() != "phikham")
            {
                string headerText = "PHIẾU THU DỊCH VỤ";
                if (LoaiThu.ToLower() == "chenhlechbhyt" || LoaiThu2.ToLower() == "chenhlechbhyt" || LoaiThu == "VIENPHINOITRU")
                    headerText = "PHIẾU THANH TOÁN RA VIỆN";
                else
                    if (LoaiThu.IndexOf("DichVuCLS")==0)
                        headerText = "PHIẾU THU CẬN LÂM SÀNG";
                    else
                        if (LoaiThu.IndexOf("DVKTKHAC")==0)
                            headerText = "PHIẾU THU DỊCH VỤ";

                        else
                            if (LoaiThu.ToLower().IndexOf("thuoc") != -1)
                                headerText = "PHIẾU THU TIỀN THUỐC";
                            else if (LoaiThu2 == "PHUTHUBH;DVKT")
                                headerText = "PHIẾU THU CẬN LÂM SÀNG";
                if (IsDaHuy == "1")
                {
                    headerText = headerText.Replace("PHIẾU THU", "PHIẾU HOÀN TRẢ TIỀN");
                    headerText = headerText.Replace("TIỀN TIỀN", "TIỀN");

                }
                crystalReport.SetParameterValue("HeaderText", headerText);
                crystalReport.SetParameterValue("NgayThu", "Ngày " + dNgayThu.ToString("dd") + " tháng " + dNgayThu.ToString("MM") + " năm " + dNgayThu.ToString("yyyy"));
            }
            else
            {
                crystalReport.SetParameterValue("NgayThu", (isMauPhiKhamFull ? " Ngày " : " ") + dNgayThu.ToString("dd") + (isMauPhiKhamFull ? " tháng " : "           ") + dNgayThu.ToString("MM") + (isMauPhiKhamFull ? " năm " : "           ") + dNgayThu.ToString("yyyy"));
                if (LoaiThu.ToLower() == "phikham" && IsDaHuy == "1")
                {
                    crystalReport.SetParameterValue("HeaderText", "PHIẾU HOÀN TRẢ TIỀN KHÁM");
                    crystalReport.SetParameterValue("NgayThu", "Ngày " + dNgayThu.ToString("dd") + " tháng " + dNgayThu.ToString("MM") + " năm " + dNgayThu.ToString("yyyy"));
                }
                else
                    crystalReport.SetParameterValue("HeaderText", "");
            }

            //string nvk_idctdkk = dtsrc.Rows[0]["idchitietdangkykham"].ToString();
            nvk_SetPara_HanhChinh(idbenhnhan_in, IdBenhNhanBHDongTien, LoaiThu);
        }
        #endregion
        #endregion
        this.crptView.ReportSource = crystalReport;
        this.crptView.DataBind();
        #endregion
    }
    private string get_MaPhieuCLS(string ID, string Loaithu)
    {
        int n = ID.IndexOf(Loaithu);
        if (n == -1) return null;
        int m = ID.IndexOf(";", n);
        if (m == -1)
            m = ID.Length;
        string s = ID.Substring(n, m - n);
        string[] arrS = s.Split('_');
        return arrS[1];
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    protected void Ctrhuehongbs_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    #region khoi tao va giai phong bo nho

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }

    private void InitialComponent()
    {
        Unload += form_unload;
    }

    #endregion

    private void nvk_SetPara_HanhChinh(string idbenhnhan, string IdBenhNhanBHDongTien, string LoaiThu)
    {
        string nvk_chandoan = "";
        string nvk_strMaChanDoan = "";
        string nvk_DiaChi = "";
        string nvk_SoDienThoai = "";
        string nvk_ThoiHanthe = "";
        string nvk_noiDkKcbBd = "";

        string nvk_noiGioiThieu = "";
        string nvk_bh1 = "";
        string nvk_bh2 = "";
        string nvk_bh3 = "";
        string nvk_bh4 = "";
        string nvk_bh5 = "";
        string nvk_bh6 = "";


        DataTable dt_hanhChinh = null;
        DataTable dtDkKhamBH = DataAcess.Connect.GetTable("select * from dangkykham where idbenhbhdongtien ='" + IdBenhNhanBHDongTien + "' and loaikhamid =1");
        if (!string.IsNullOrEmpty(IdBenhNhanBHDongTien) && !IdBenhNhanBHDongTien.Equals("0") && dtDkKhamBH != null && dtDkKhamBH.Rows.Count>0)
        {
            dt_hanhChinh = StaticData_HS.nvk_thongTimBaohiemBy_idbnbhdt(IdBenhNhanBHDongTien);
        }
        else // trường hợp tự đến cls
        {
            dt_hanhChinh = StaticData_HS.dtBenhNhanInfor(idbenhnhan);
        }


        if (dt_hanhChinh != null && dt_hanhChinh.Rows.Count > 0)
        {
            nvk_DiaChi = dt_hanhChinh.Rows[0]["diachi"].ToString();
            nvk_SoDienThoai = dt_hanhChinh.Rows[0]["dienthoai"].ToString();
            nvk_ThoiHanthe = dt_hanhChinh.Rows[0]["thoihanthe"].ToString();
            nvk_noiDkKcbBd = dt_hanhChinh.Rows[0]["noidangkykcb"].ToString();
            nvk_noiGioiThieu = dt_hanhChinh.Rows[0]["noigioithieu"].ToString();
            string SoBhyt_Bn = dt_hanhChinh.Rows[0]["sobhyt"].ToString();
            if (SoBhyt_Bn.Length > 10)
            {
                nvk_bh1 = SoBhyt_Bn.Substring(0, 2);
                nvk_bh2 = SoBhyt_Bn.Substring(2, 1);
                nvk_bh3 = SoBhyt_Bn.Substring(3, 2);
                nvk_bh4 = SoBhyt_Bn.Substring(5, 2);
                nvk_bh5 = SoBhyt_Bn.Substring(7, 3);
                nvk_bh6 = SoBhyt_Bn.Substring(10, 5);
            }
        }
        try { crystalReport.SetParameterValue("@nvk_DiaChi", nvk_DiaChi); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@nvk_SoDienThoai", nvk_SoDienThoai); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@nvk_ThoiHanthe", nvk_ThoiHanthe); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@nvk_noiDkKcbBd", nvk_noiDkKcbBd); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh1", nvk_bh1); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh2", nvk_bh2); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh3", nvk_bh3); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh4", nvk_bh4); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh5", nvk_bh5); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh6", nvk_bh6); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@nvk_noiGioiThieu", nvk_noiGioiThieu); }
        catch (Exception)
        {
            try { crystalReport.SetParameterValue("txtNoiGioiThieu", nvk_noiGioiThieu); }
            catch (Exception) { }
        }
        try
        {

            if (IdBenhNhanBHDongTien != null && IdBenhNhanBHDongTien != "")
                StaticData_HS.nvk_setTongHopChanDoan(IdBenhNhanBHDongTien, true, ref nvk_strMaChanDoan, ref nvk_chandoan);
            crystalReport.SetParameterValue("@nvk_strChanDoan", nvk_chandoan);
            crystalReport.SetParameterValue("@nvk_strMaChanDoan", nvk_strMaChanDoan);

        }
        catch (Exception) { }

        try
        {
            if (IdBenhNhanBHDongTien == null || IdBenhNhanBHDongTien == "" || StaticData.IsCheck(dt_hanhChinh.Rows[0]["IsBHYT"].ToString()) == false)
            {
                crystalReport.SetParameterValue("txtCheck", "");
                crystalReport.SetParameterValue("txtTrai", "");
            }
            else
            {
                if (dt_hanhChinh.Rows[0]["DungTuyen"].ToString() == "Y")
                {
                    crystalReport.SetParameterValue("txtCheck", "a");
                    crystalReport.SetParameterValue("txtTrai", "");
                }
                else
                {
                    crystalReport.SetParameterValue("txtCheck", "");
                    crystalReport.SetParameterValue("txtTrai", "a");
                }
            }
        }
        catch (Exception) { }

    }
}
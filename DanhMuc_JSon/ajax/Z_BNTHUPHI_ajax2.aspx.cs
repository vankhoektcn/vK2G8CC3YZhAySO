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
using System.Text;

public partial class Z_BNTHUPHI_ajax : System.Web.UI.Page
{
    protected DataProcess s_Z_BNTHUPHI_View()
    {
        DataProcess Z_BNThuPhi_View = new DataProcess("Z_BNThuPhi_View");
        Z_BNThuPhi_View.data("IDTHUPHI", Request.QueryString["idkhoachinh"]);
        Z_BNThuPhi_View.data("MAPHIEUCLS", Request.QueryString["MAPHIEUCLS"]);
        Z_BNThuPhi_View.data("TONGTIEN", Request.QueryString["TONGTIEN"]);
        Z_BNThuPhi_View.data("NOIDUNGTHU", Request.QueryString["NOIDUNGTHU"]);
        Z_BNThuPhi_View.data("LoaiThu", Request.QueryString["LoaiThu"]);
        Z_BNThuPhi_View.data("TONGTIENBHYT", Request.QueryString["TONGTIENBHYT"]);
        Z_BNThuPhi_View.data("BHTRA", Request.QueryString["BHTRA"]);
        Z_BNThuPhi_View.data("BNPHAITRA", Request.QueryString["BNPHAITRA"]);
        Z_BNThuPhi_View.data("BNDaTraChenhLechBHYT", Request.QueryString["BNDaTraChenhLechBHYT"]);
        Z_BNThuPhi_View.data("LoaiBN", Request.QueryString["LoaiBN"]);
        Z_BNThuPhi_View.data("TENKHACHHANG", Request.QueryString["TENKHACHHANG"]);
        Z_BNThuPhi_View.data("Id", Request.QueryString["Id"]);
        Z_BNThuPhi_View.data("LoaiThu2", Request.QueryString["LoaiThu2"]);
        Z_BNThuPhi_View.data("MABENHNHAN", Request.QueryString["MABENHNHAN"]);
        Z_BNThuPhi_View.data("TENBENHNHAN", Request.QueryString["TENBENHNHAN"]);
        Z_BNThuPhi_View.data("DIACHI", Request.QueryString["DIACHI"]);
        Z_BNThuPhi_View.data("gioitinh", Request.QueryString["gioitinh"]);
        Z_BNThuPhi_View.data("NgaySinh", Request.QueryString["NgaySinh"]);
        Z_BNThuPhi_View.data("Khoa", Request.QueryString["Khoa"]);
        Z_BNThuPhi_View.data("HuongDieuTri", Request.QueryString["HuongDieuTri"]);
        Z_BNThuPhi_View.data("IdChiTietDangKyKham", Request.QueryString["IdChiTietDangKyKham"]);
        Z_BNThuPhi_View.data("IdBenhNhan", Request.QueryString["IdBenhNhan"]);
        Z_BNThuPhi_View.data("IdBenhNhanBHDongTien", Request.QueryString["IdBenhNhanBHDongTien"]);
        return Z_BNThuPhi_View;
    }
    protected DataProcess s_ChietKhau()
    {
        DataProcess Z_CHIETKHAU = new DataProcess("Z_CHIETKHAU");
        Z_CHIETKHAU.data("IDDETAIL", Request.QueryString["idkhoachinh"]);
        Z_CHIETKHAU.data("CHIETKHAU", Request.QueryString["chietkhau"]);
        Z_CHIETKHAU.data("THANHTIEN", (Request.QueryString["thanhtien"] != null && Request.QueryString["thanhtien"] != "" ? Request.QueryString["thanhtien"].Replace(".", "").Replace(",", ".") : ""));
        return Z_CHIETKHAU;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "TimKiem": TimKiem(); break;
            case "MaPhieu_new": MaPhieu_new(); break;
            case "showview": showview(); break;
            case "LuuChietKhau": LuuChietKhau(); break;
        }
    }
    private void TimKiem()
    {
        bool search = true;// Userlogin_new.HavePermision(this, "Z_BNThuPhi_View_Search");
        if (search)
        {
            string NgayThuPhi = Request.QueryString["NgayThuPhi"];
            string HaveVienPhiNoiTru = Request.QueryString["HaveVPNT"];
            string IsViewAll = StaticData.GetParaValueDB("IsViewAll_MoneyBH");
            NgayThuPhi = StaticData.CheckDate(NgayThuPhi) + " 23:59:59";
            string USERID = SysParameter.UserLogin.UserID(this);
            if (USERID == null || USERID == "") USERID = "0";

            string IsDCT = Request.QueryString["IsDCT"];
            if (IsDCT == "1") HaveVienPhiNoiTru = "1";
            string IsBNDV = Request.QueryString["IsBNDV"];
            string IsBNBH = Request.QueryString["IsBNBH"];
            string IsPhiKham = Request.QueryString["IsPhiKham"];
            string IsCLS = Request.QueryString["IsCLS"];
            string IsTamUng = Request.QueryString["IsTamUng"];
            string IsPhiKham_CLS_TuDK = Request.QueryString["IsPhiKham_CLS_TuDK"];
            string sqlPhiKham = @"UNION
                                       (
                                        SELECT DISTINCT MAPHIEUCLS=CONVERT(NVARCHAR(20),A.IDDANGKYKHAM),B1.IDBENHNHAN
		                                   ,SUM(A.BNTongPhaiTra -ISNULL(A.BNTra,0)) AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Phí khám'
		                                   ,LoaiThu='PhiKham'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
	                                       ,LoaiBN=(CASE WHEN B1.LOAIKHAMID=1 THEN N'BH' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='PhiKham_'+CONVERT(NVARCHAR(20),A.IDDANGKYKHAM)
                                           ,LoaiThu2='PhiKham'
                                           ,KHOA=DBO.HB_KHOADANGKY(A.IDDANGKYKHAM)
                                           ,HuongDieuTri=NULL
                                           ,IdChiTietDangKyKham=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM CHITIETDANGKYKHAM A
                                    LEFT JOIN DANGKYKHAM B1 ON A.IDDANGKYKHAM=B1.IDDANGKYKHAM
                                    LEFT JOIN BENHNHAN B ON B1.IDBENHNHAN=B.IDBENHNHAN
	                                WHERE	 
                                            ISNULL(A.isNotThuPhiCapCuu,0)=0
			                                --AND ISNULL(A.DAHUY,0)=0
                                            AND ISNULL(A.IsDaThu,0)=0
			                                AND YEAR(NGAYDANGKY)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYDANGKY)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYDANGKY)=DAY('" + NgayThuPhi + @"')
			                                AND A.BNTongPhaiTra -ISNULL(A.BNTra,0)>0"
                                      + (IsBNBH == "1" ? " AND B1.LOAIKHAMID=1" : "")
                                      + (IsBNDV == "1" ? " AND B1.LOAIKHAMID<>1" : "")
                                        + @" 
	                                GROUP BY A.IDDANGKYKHAM,B1.IDBENHNHAN,B1.LOAIKHAMID 
                                )";
            string sqlDongChiTra = @"UNION
                                    (SELECT DISTINCT MAPHIEUCLS=CONVERT(NVARCHAR(20),A.ID),A.IDBENHNHAN
		                                   ,A.BNPhaiTraChenhLechBHYT AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Đồng chi trả'
		                                   ,LoaiThu='ChenhLechBHYT'
                                           ,TONGTIENBHYT=A.TongTienBH
                                           ,BHTRA
                                           ,BNPHAITRA
                                           ,BNDaTraChenhLechBHYT
                                           ,LoaiBN=(CASE WHEN A.ISBHYT=1 THEN N'BH'+'(' +A.DungTuyen +')' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='ChenhLechBHYT_'+CONVERT(NVARCHAR(20),A.ID)
                                           ,LoaiThu2='ChenhLechBHYT'
                                           ,KHOA=DBO.HB_KHOADANGKY2(A.IDKHAMBENH_LAST)
                                           ,HuongDieuTri=A.HuongDieuTri
                                           ,IdChiTietDangKyKham=A.IdChiTietDangKyKham_Last
                                           ,IdBenhNhanBHDongTien=A.ID
	                                FROM HS_BenhNhanBHDongTien A
	                                WHERE	A.ISBHYT=1 
                                            AND ISNULL(A.ISNOITRU,0)=0
			                                AND YEAR(NgayTinhBH)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NgayTinhBH)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NgayTinhBH)=DAY('" + NgayThuPhi + @"')
			                                AND ISNULL(BNPhaiTraChenhLechBHYT,0)>0"
                                              + (IsViewAll != "1" ? " AND A.IsView=1" : "")
                                    + @"
                                )";
            string sqlCLS = @"UNION
	                                (SELECT DISTINCT MAPHIEUCLS,A.IDBENHNHAN
		                                   ,SUM((CASE WHEN A.ISBHYT=1 THEN ISNULL(A.PHUTHUBH,0) ELSE  A.THANHTIENDV  END ))   AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Dịch vụ CLS'
                                           ,LoaiThu='DichVuCLS'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
                                           ,LoaiBN=(CASE WHEN G.LOAIKHAMID=1 THEN N'BH' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='DichVuCLS_'+MAPHIEUCLS
                                           ,LoaiThu2='DichVuCLS'
                                           ,KHOA=F.TENPHONGKHAMBENH
                                           ,HuongDieuTri=N'Chờ KQCLS'
                                           ,IDCHITIETDANGKYKHAM=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM KHAMBENHCANLAMSAN A
                                    LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                    LEFT JOIN BANGGIADICHVU C ON A.IDCANLAMSAN=C.IDBANGGIADICHVU
                                    LEFT JOIN PHONGKHAMBENH D ON C.IDPHONGKHAMBENH=D.IDPHONGKHAMBENH
                                    LEFT JOIN KHAMBENH E ON A.IDKHAMBENH=E.IDKHAMBENH
                                    LEFT JOIN PHONGKHAMBENH F ON ISNULL(E.IDKHOA,E.IDPHONGKHAMBENH)=F.IDPHONGKHAMBENH
                                    LEFT JOIN DANGKYKHAM G ON E.IDDANGKYKHAM=G.IDDANGKYKHAM
                                    LEFT JOIN HS_BENHNHANBHDONGTIEN H ON G.IdBenhBHDongTien=H.ID
	                                WHERE	ISNULL(A.IDKHAMBENH,0)<>0
			                                --AND  ISNULL(A.DAHUY,0)=0
			                                AND ISNULL(A.DATHU,0)=0
			                                AND YEAR(NGAYTHU)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYTHU)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYTHU)=DAY('" + NgayThuPhi + @"')
			                                AND (CASE WHEN A.ISBHYT=1 THEN ISNULL(A.PHUTHUBH,0) ELSE  A.THANHTIENDV  END )>0
                                            AND ISNULL(C.IsCLS,0)=1"
                                      + (IsBNBH == "1" ? " AND G.LOAIKHAMID=1" : "")
                                      + (IsBNDV == "1" ? " AND G.LOAIKHAMID<>1" : "")
                                        + @"
	                                GROUP BY MAPHIEUCLS,A.IDBENHNHAN,g.LOAIKHAMID,F.TENPHONGKHAMBENH,ISNULL(E.IDKHAMBENH,0)
                                )
                                 UNION
	                                (SELECT DISTINCT MAPHIEUCLS,A.IDBENHNHAN
		                                   ,SUM((CASE WHEN A.ISBHYT=1 THEN ISNULL(A.PHUTHUBH,0) ELSE  A.THANHTIENDV  END ))   AS TONGTIEN
		                                   ,NOIDUNGTHU=N'DVKT Khác'
                                           ,LoaiThu='DVKTKHAC'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
                                           ,LoaiBN=(CASE WHEN G.LOAIKHAMID=1 THEN N'BH' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='DVKTKHAC_'+MAPHIEUCLS
                                           ,LoaiThu2='DVKTKHAC'
                                           ,KHOA=F.TENPHONGKHAMBENH
                                           ,HuongDieuTri=N'Chờ KQCLS'
                                           ,IDCHITIETDANGKYKHAM=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM KHAMBENHCANLAMSAN A
                                    LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                    LEFT JOIN BANGGIADICHVU C ON A.IDCANLAMSAN=C.IDBANGGIADICHVU
                                    LEFT JOIN PHONGKHAMBENH D ON C.IDPHONGKHAMBENH=D.IDPHONGKHAMBENH
                                    LEFT JOIN KHAMBENH E ON A.IDKHAMBENH=E.IDKHAMBENH
                                    LEFT JOIN PHONGKHAMBENH F ON ISNULL(E.IDKHOA,E.IDPHONGKHAMBENH)=F.IDPHONGKHAMBENH
                                    LEFT JOIN DANGKYKHAM G ON E.IDDANGKYKHAM=G.IDDANGKYKHAM
                                    LEFT JOIN HS_BENHNHANBHDONGTIEN H ON G.IdBenhBHDongTien=H.ID
	                                WHERE	ISNULL(A.IDKHAMBENH,0)<>0
			                                --AND  ISNULL(A.DAHUY,0)=0
			                                AND ISNULL(A.DATHU,0)=0
			                                AND YEAR(NGAYTHU)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYTHU)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYTHU)=DAY('" + NgayThuPhi + @"')
			                                AND (CASE WHEN A.ISBHYT=1 THEN ISNULL(A.PHUTHUBH,0) ELSE  A.THANHTIENDV  END )>0
                                            AND ISNULL(C.ISDVKT,0)=1"

                                      + (IsBNBH == "1" ? " AND G.LOAIKHAMID=1" : "")
                                      + (IsBNDV == "1" ? " AND G.LOAIKHAMID<>1" : "")
                                        + @"
                                        --  AND ( F.IDPHONGKHAMBENH=1 OR F.IDPHONGKHAMBENH=15 OR (ISNULL(H.IsNoiTru,0)=0 AND F.IDPHONGKHAMBENH<>22 ))
	                                GROUP BY MAPHIEUCLS,A.IDBENHNHAN,g.LOAIKHAMID,F.TENPHONGKHAMBENH,ISNULL(E.IDKHAMBENH,0)
                                )";
            string sqlCLS_TuDK = @"UNION
	                                (SELECT DISTINCT MAPHIEUCLS,A.IDBENHNHAN
		                                   ,SUM(A.THANHTIENDV)   AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Dịch vụ CLS Tự ĐK'
                                           ,LoaiThu='DichVuCLSTUDEN'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
                                           ,LoaiBN='DV'
                                           ,TENKHACHHANG=NULL
                                           ,Id='DichVuCLSTUDEN_'+MAPHIEUCLS
                                           ,LoaiThu2='DichVuCLSTUDEN'
                                           ,KHOA=F.TENPHONGKHAMBENH
                                           ,HuongDieuTri=N'Tự ĐKCLS'
                                           ,IDCHITIETDANGKYKHAM=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM KHAMBENHCANLAMSAN A
                                    LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                    LEFT JOIN BANGGIADICHVU C ON A.IDCANLAMSAN=C.IDBANGGIADICHVU
                                    LEFT JOIN PHONGKHAMBENH F ON A.idkhoadangky=F.IDPHONGKHAMBENH
	                                WHERE	
			                                ISNULL(A.IDKHAMBENH,0)=0 
                                            --AND  ISNULL(A.DAHUY,0)=0
			                                AND ISNULL(A.DATHU,0)=0
			                                AND YEAR(NGAYTHU)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYTHU)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYTHU)=DAY('" + NgayThuPhi + @"')
			                                AND   A.THANHTIENDV >0
                                            AND ISNULL(C.IsCLS,0)=1
	                                GROUP BY MAPHIEUCLS,A.IDBENHNHAN,F.TENPHONGKHAMBENH
                                )
                                UNION
	                                (SELECT DISTINCT MAPHIEUCLS,A.IDBENHNHAN
		                                   ,SUM(A.THANHTIENDV)   AS TONGTIEN
		                                   ,NOIDUNGTHU=N'DVKT Tự ĐK'
                                           ,LoaiThu='DVKTKHACTUDEN'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
                                           ,LoaiBN='DV'
                                           ,TENKHACHHANG=NULL
                                           ,Id='DVKTKHACTUDEN_'+MAPHIEUCLS
                                           ,LoaiThu2='DVKTKHACTUDEN'
                                           ,KHOA=F.TENPHONGKHAMBENH
                                           ,HuongDieuTri=N'Tự ĐKCLS'
                                           ,IDCHITIETDANGKYKHAM=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM KHAMBENHCANLAMSAN A
                                    LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                    LEFT JOIN BANGGIADICHVU C ON A.IDCANLAMSAN=C.IDBANGGIADICHVU
                                    LEFT JOIN PHONGKHAMBENH F ON A.idkhoadangky=F.IDPHONGKHAMBENH
	                                WHERE	
			                                ISNULL(A.IDKHAMBENH,0)=0 
                                            --AND  ISNULL(A.DAHUY,0)=0
			                                AND ISNULL(A.DATHU,0)=0
			                                AND YEAR(NGAYTHU)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYTHU)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYTHU)=DAY('" + NgayThuPhi + @"')
			                                AND   A.THANHTIENDV >0
                                            AND ISNULL(C.ISDVKT,0)=1
                                        
	                                GROUP BY MAPHIEUCLS,A.IDBENHNHAN,F.TENPHONGKHAMBENH
                                )";
            string sqlTamUng = @"UNION (
                                     SELECT DISTINCT MAPHIEUCLS=convert(varchar,A.IDTAMUNG),d.IDBENHNHAN,
		                                   TONGTIEN=a.sotien
		                                   ,NOIDUNGTHU=N'Tạm ứng'
		                                   ,LoaiThu='TamUng'
                                           ,TONGTIENBHYT=NULL
                                            ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
	                                       ,LoaiBN=(CASE WHEN d.LOAI=1 THEN N'BH' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='TamUng_'+convert(varchar,A.IDTAMUNG)
                                           ,LoaiThu2='TamUng'
                                           ,KHOA=TENPHONGKHAMBENH
                                           ,HuongDieuTri=DBO.HS_LAST_STATUS(A.IDDANGKYKHAM,A.idkhoaTU)
                                           ,IDCHITIETDANGKYKHAM=A.IDDANGKYKHAM
                                           ,IdBenhNhanBHDongTien=C.IdBenhBHDongTien
	                                FROM tamung A
									left join chitietdangkykham b on a.iddangkykham =b.idchitietdangkykham
									left join dangkykham c on c.iddangkykham=b.iddangkykham
                                    LEFT JOIN BENHNHAN d ON c.IDBENHNHAN=d.IDBENHNHAN
                                    LEFT JOIN PHONGKHAMBENH E ON A.idkhoaTU=E.IDPHONGKHAMBENH
	                                WHERE	ISNULL(A.isDATHU,0)=0
			                                AND YEAR(a.ngaytamung)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(a.ngaytamung)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(a.ngaytamung)=DAY('" + NgayThuPhi + @"')"
                                      + (IsBNBH == "1" ? " AND C.LOAIKHAMID=1" : "")
                                      + (IsBNDV == "1" ? " AND C.LOAIKHAMID<>1" : "")
                                        + @"
                                  )";


            string sqlThanhToanRaVien = @"UNION
                                (SELECT DISTINCT MAPHIEUCLS=CONVERT(NVARCHAR(20),A.ID),A.IDBENHNHAN
		                                   ,ABS(A.TongTienBNPTConLai) AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Thanh toán ra viện'+(case when A.TongTienBNPTConLai<0 then N'(hoàn trả)' else '' end)
		                                   ,LoaiThu='VIENPHINOITRU'
                                           ,TONGTIENBHYT=A.TongTienBH
                                           ,BHTRA
                                           ,BNPHAITRA
                                           ,BNDaTraChenhLechBHYT
                                           ,LoaiBN=(CASE WHEN A.ISBHYT=1 THEN N'BH'+'(' +A.DungTuyen +')' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='VIENPHINOITRU_'+CONVERT(NVARCHAR(20),A.ID)
                                           ,LoaiThu2='VIENPHINOITRU'
                                           ,KHOA=DBO.HB_KHOADANGKY2(A.IDKHAMBENH_LAST)
                                           ,HuongDieuTri=A.HuongDieuTri
                                           ,IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM_Last
                                           ,IdBenhNhanBHDongTien=A.ID
	                                FROM HS_BenhNhanBHDongTien A
	                                WHERE	1=1 
                                           AND ( A.ISBHYT=1 OR  ISNULL(A.ISNOITRU,0)=1 OR A.ISCAPCUU =1 OR A.IDKHOA_LAST IN (" + StaticData.GetParaValueDB("KHOATTRAVIEN") + @"))
			                                AND NgayTinhBH<='" + NgayThuPhi + @"'
			                                AND ISNULL(TongTienBNPTConLai,0)<>0"
                                      + (IsBNBH == "1" ? " AND A.ISBHYT=1" : "")
                                      + (IsBNDV == "1" ? " AND ISNULL(A.ISBHYT,0)=0" : "")
                                    + @"
                                )";

            string sqlSelectAll = "";
            if (IsPhiKham == "1")
                sqlSelectAll = sqlPhiKham; // Phi kham
            else
                if (IsCLS == "1")
                    sqlSelectAll = sqlCLS; // phi can lam san
                else
                    if (IsTamUng == "1")
                        sqlSelectAll = sqlTamUng; // phi tam ung
                    else
                        if (HaveVienPhiNoiTru == "1")
                            sqlSelectAll = sqlThanhToanRaVien; // thanh toan ra vien
                        else
                            if (IsPhiKham_CLS_TuDK == "1")
                                sqlSelectAll = sqlPhiKham + sqlCLS_TuDK;
                            else
                                sqlSelectAll = (IsBNBH == "1" ? "" : sqlPhiKham) + sqlCLS_TuDK + sqlCLS + sqlTamUng; // vien phi chung
            if (sqlSelectAll.IndexOf("UNION") == 0) sqlSelectAll = sqlSelectAll.Remove(0, "UNION".Length);
            string strSQL = @"DELETE FROM Z_BNThuPhi_View WHERE USERID=" + USERID + @"
                             INSERT INTO Z_BNThuPhi_View
                                (
                                    MAPHIEUCLS
                                    ,TONGTIEN
                                    ,NOIDUNGTHU
                                    ,LoaiThu
                                    ,TONGTIENBHYT
                                    ,BHTRA
                                    ,BNPHAITRA
                                    ,BNDaTraChenhLechBHYT
                                    ,LoaiBN
                                    ,TENKHACHHANG
                                    ,Id
                                    ,LoaiThu2
                                    ,MABENHNHAN
                                    ,TENBENHNHAN
                                    ,DIACHI
                                    ,gioitinh
                                    ,NgaySinh
                                    ,Khoa
                                    ,HuongDieuTri
                                    ,IdChiTietDangKyKham
                                    ,IdBenhNhan
                                    ,IdBenhNhanBHDongTien
                                    ,USERID
                               )
                              SELECT 
                                           TB. MAPHIEUCLS 
		                                   ,TB.TONGTIEN
		                                   ,TB.NOIDUNGTHU
		                                   ,TB.LoaiThu 
                                           ,TB.TONGTIENBHYT 
                                           ,TB.BHTRA
                                           ,TB.BNPHAITRA 
                                           ,TB.BNDaTraChenhLechBHYT
	                                       ,TB.LoaiBN 
                                           ,TB.TENKHACHHANG
                                           ,TB.Id 
                                           ,TB.LoaiThu2
                                            ,MABENHNHAN
                                            ,TENBENHNHAN=ISNULL(TENBENHNHAN,TENKHACHHANG)
                                            ,DIACHI
                                            ,gioitinh=dbo.getgioitinh(B.gioitinh)
                                            ,NgaySinh=B.NgaySinh
                                            ,Khoa=TB.Khoa
                                            ,HuongDieuTri=TB.HuongDieuTri
                                            ,IdChiTietDangKyKham=TB.IdChiTietDangKyKham
                                            ,B.IdBenhNhan
                                            ,IdBenhNhanBHDongTien=TB.IdBenhNhanBHDongTien
                                            ,UserID=" + USERID + @"
                                FROM ("
                                +
                                sqlSelectAll

                                + @"
                                ) AS TB
                                LEFT JOIN BENHNHAN B ON TB.IDBENHNHAN=B.IDBENHNHAN 
                                WHERE 1=1";
            string mabenhnhan = Request.QueryString["MABENHNHAN"];
            string tenbenhnhan = Request.QueryString["TENBENHNHAN"];
            if (mabenhnhan != null && mabenhnhan != "")
                strSQL += " AND B.MABENHNHAN='" + mabenhnhan + @"'";
            if (tenbenhnhan != null && tenbenhnhan != "")
                strSQL += " AND (B.TenBenhNhan LIKE N'%" + tenbenhnhan + @"%' OR B.NAMENOTSIGN LIKE N'%" + tenbenhnhan + "%')";
            DataAcess.Connect.ExecSQL(strSQL);
            DataProcess process = s_Z_BNTHUPHI_View();
            process.data("USERID", USERID);
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IDTHUPHI),T.*
                               from Z_BNThuPhi_View T
                                where USERID=" + USERID);
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
    private void MaPhieu_new()
    {
        string MaPhieu = null;
        while (true)
        {
            MaPhieu = StaticData.MaPhieu_new();
            string sqlSelectAgain = "SELECT TOP 1 IDBENHNHAN FROM HS_DSDATHU WHERE MAPHIEU='" + MaPhieu + "'";
            DataTable dtSearchAgain = DataAcess.Connect.GetTable(sqlSelectAgain);
            if (dtSearchAgain == null) return;
            if (dtSearchAgain.Rows.Count == 0) break;
        }
        if (MaPhieu == null)
        {
            Response.Write("0000000");
        }
        else
        {
            Response.Write(MaPhieu);
        }
    }
    //____________________________________________________________________________________________________________________
    private void showview()
    {
        string ID = Request.QueryString["Id"];
        string SQL = "";
        string[] arrID = ID.Split('_');
        if (arrID[0] == "PhiKham")
        {
            SQL = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY A.IDCHITIETDANGKYKHAM),
	                   TENNHOM=C.TENPHONGKHAMBENH,
	                   NOIDUNG=B.TENDICHVU,
	                   SOLUONG=A.SOLUONG,
	                   DONGIA=ISNULL(A.DONGIADV,0),
	                   CHIETKHAU=ISNULL(A.CHIETKHAU,0),
                       THANHTIEN=ISNULL(A.SOLUONG*A.DONGIADV,0)* (100-ISNULL(A.CHIETKHAU,0)) /100,
                       IDDETAIL=A.IDCHITIETDANGKYKHAM,
                       DAHUY=CONVERT(INT,A.DAHUY)
                FROM CHITIETDANGKYKHAM A
                INNER JOIN BANGGIADICHVU B ON A.IDBANGGIADICHVU=B.IDBANGGIADICHVU
                LEFT JOIN PHONGKHAMBENH C ON B.IDPHONGKHAMBENH=C.IDPHONGKHAMBENH
                WHERE A.IDDANGKYKHAM=" + arrID[1] + @"
                      --AND ISNULL(A.DAHUY,0)=0
	                  AND ISNULL(A.ISDATHU,0)=0";
        }
        string[] arrCLSTYPE = new string[] { "DichVuCLS", "DVKTKHAC", "DichVuCLSTUDEN", "DVKTKHACTUDEN" };
        if (Array.IndexOf(arrCLSTYPE, arrID[0]) != -1)
        {
            SQL = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY A.IDKHAMBENHCANLAMSAN),
	                       TENNHOM=C.TENPHONGKHAMBENH,
	                       NOIDUNG=B.TENDICHVU,
	                       SOLUONG=A.SOLUONG,
	                       DONGIA=case when isnull(ISNULL(A.BNtongPhaiTRa,A.dongia),0)>0 then isnull(ISNULL(A.BNtongPhaiTRa,A.dongia),0) else isnull(A.DONGIADV,0) end,
	                       CHIETKHAU=ISNULL(A.CHIETKHAU,0),
                           THANHTIEN=ISNULL(A.SOLUONG*A.DONGIADV,0)* (100-ISNULL(A.CHIETKHAU,0)) /100,
                           IDDETAIL=A.IDKHAMBENHCANLAMSAN,
                           DAHUY=CONVERT(INT,A.DAHUY)
                    FROM KHAMBENHCANLAMSAN A
                    INNER JOIN BANGGIADICHVU B ON A.IDCANLAMSAN=B.IDBANGGIADICHVU
                    INNER JOIN PHONGKHAMBENH C ON B.IDPHONGKHAMBENH=C.IDPHONGKHAMBENH
                    WHERE   A.MAPHIEUCLS='" + arrID[1] + @"'
		                    --AND ISNULL(A.DAHUY,0)=0
		                    AND ISNULL(A.DATHU,0)=0";
        }
        if (arrID[0] == "DichVuCLS")
            SQL += " AND ISNULL(A.IDKHAMBENH,0)<>0 AND ISNULL(B.ISCLS,0)=1";
        if (arrID[0] == "DVKTKHAC")
            SQL += " AND ISNULL(A.IDKHAMBENH,0)<>0 AND ISNULL(B.ISDVKT,0)=1";
        if (arrID[0] == "DichVuCLSTUDEN")
            SQL += " AND ISNULL(B.ISCLS,0)=1";
        if (arrID[0] == "DVKTKHACTUDEN")
            SQL += " AND ISNULL(B.ISDVKT,0)=1";
        DataTable table = DataAcess.Connect.GetTable(SQL);
        StringBuilder html = new StringBuilder();
        double thanhtien = 0;
        html.Append("<table class='jtable jtablecss' id='gridHead'");
        html.Append("<tr>");
        html.Append("<th style='width:4%;text-align:left;'>STT</th>");
        html.Append("<th style='width:5%;text-align:left;'>Hủy?</th>");
        html.Append("<th style='width:18%;text-align:left;'>Tên nhóm</th>");
        html.Append("<th style='width:32%;'>Nội dung</th>");
        html.Append("<th style='width:5%;'>SL</th>");
        html.Append("<th style='width:10%;'>Đơn giá</th>");
        html.Append("<th style='width:10%;'>Chiết khấu</th>");
        html.Append("<th style='width:12%;'>Thành tiền</th>");
        html.Append("</tr>");
        html.Append("</table>");
        html.Append("<div style='height:330px; overflow-y:scroll;'>");
        html.Append("<table class='jtable' id='gridDetail'>");
        html.Append("<tr style='display:none'></tr>");
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                thanhtien += double.Parse(table.Rows[i]["thanhtien"].ToString());
                html.Append("<tr>");
                html.Append("<td style='width:4%;'>" + table.Rows[i]["STT"].ToString() + "</td>");
                html.Append("<td style='width:5%;'><input mkv='true' type='checkbox' id='IsHuy' " + ((!string.IsNullOrEmpty(table.Rows[i]["dahuy"].ToString()) && table.Rows[i]["dahuy"].ToString().Equals("1")) ? "checked='checked'": "" )+ " /></td>");
                html.Append("<td style='width:20%;'>" + table.Rows[i]["TENNHOM"].ToString() + "</td>");
                html.Append("<td style='width:32%;'>" + table.Rows[i]["NOIDUNG"].ToString() + "</td>");
                html.Append("<td style='width:5%;'>" + table.Rows[i]["SOLUONG"].ToString() + "</td>");
                html.Append("<td style='width:10%;text-align:center;'>" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n0}", table.Rows[i]["DONGIA"]) + "</td>");
                html.Append("<td style='width:10%;'><input id='chietkhau'  type='text' value='" + table.Rows[i]["CHIETKHAU"].ToString() + "' onblur='TestSo(this,false,false);TinhThanhTien(this);'  mkv='true' style='width:65%;text-align:center;' />%</td>");
                html.Append("<td style='width:12%;'><input type='text' id='thanhtien' mkv='true' value='" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n0}", table.Rows[i]["THANHTIEN"]) + "' disabled style='width:90%; text-align:center;' /></td><input type='hidden' id='idkhoachinh' mkv='true' value='" + table.Rows[i]["IDDETAIL"].ToString() + "' />");
                html.Append("</tr>");
            }
        }
        html.Append("<tr><td></td><td colspan='6' style='font-weight:bold;'>Tổng cộng</td><td style='text-align:center;font-weight:bold;'>" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n0}", thanhtien) + "</td></tr>");
        html.Append("</table>");
        html.Append("</div>");
        html.Append(@"<div id='divbutton'>
            <input type='button' id='btnLuuThu' value='Lưu & thu' onclick='DongY(this,true);' />
            <input type='button' id='btnLuu' value='Lưu' onclick='DongY(this);' />
            <input type='button' id='btnThucThu' value='Thu' onclick='thucthu(this);' />
            <input type='button' id='btnCancel' value='Thoát' onclick='exit();' /><input type='hidden' id='txtRow' /></div>");
        Response.Write(html.ToString());
    }
    //____________________________________________________________________________________________________________________
    private void LuuChietKhau()
    {

        string idmaphieu = Request.QueryString["idmaphieu"];
        string[] arrID = idmaphieu.Split('_');
        if (!string.IsNullOrEmpty(Request.QueryString["idkhoachinh"]))
        {
            string iddetail = Request.QueryString["idkhoachinh"];
            string ishuy = StaticData.IsCheck(Request.QueryString["IsHuy"])?"1":"0";
            string chietkhau = Request.QueryString["chietkhau"];
            string thanhtien = (Request.QueryString["thanhtien"] != null && Request.QueryString["thanhtien"] != "" ? Request.QueryString["thanhtien"].Replace(".", "").Replace(",", ".") : "");
            string SQL_UPDATE = "";
            if (arrID[0] == "PhiKham")
            {
                SQL_UPDATE = string.Format(@"UPDATE CHITIETDANGKYKHAM 
                                                SET CHIETKHAU={0},THANHTIENDV={2},dahuy={3} WHERE IDCHITIETDANGKYKHAM={1} 
                                                AND ISNULL(ISDATHU,0)=0", chietkhau, iddetail, thanhtien,ishuy);
                bool ok_2 = DataAcess.Connect.ExecSQL(SQL_UPDATE);
                return;
            }
            string[] arrCLSTYPE = new string[] { "DichVuCLS", "DVKTKHAC", "DichVuCLSTUDEN", "DVKTKHACTUDEN" };
            if (Array.IndexOf(arrCLSTYPE, arrID[0]) != -1)
            {
                SQL_UPDATE = string.Format(@"UPDATE KHAMBENHCANLAMSAN  
                                                SET CHIETKHAU={0},THANHTIENDV={2},dahuy={3} WHERE IDKHAMBENHCANLAMSAN={1}
                                                AND ISNULL(DATHU,0)=0", chietkhau, iddetail, thanhtien,ishuy);
                bool ok_2 = DataAcess.Connect.ExecSQL(SQL_UPDATE);
                return;
            }
        }

    }
    //____________________________________________________________________________________________________________________
}



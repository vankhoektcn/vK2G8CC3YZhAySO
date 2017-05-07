using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using System.Collections.Generic;
/// <summary>
/// Summary description for StaticData
/// </summary>
public class StaticData_HS
{
    #region  MaPhieuCLS_new
    public static string MaPhieuCLS_new()
    {
        string MaPhieu_tepm = null;
        string SysDate_ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string sqlSelectMaPhieu = "select max(SoTT) from Kb_MAPHIEUCLS where year(SysDate)=year('" + SysDate_ + "') and month(SysDate)=month('" + SysDate_ + "')";
        DataTable dtMaPhieu = DataAcess.Connect.GetTable(sqlSelectMaPhieu);
        if (dtMaPhieu == null) MaPhieu_tepm = "0";
        else
        {
            if (dtMaPhieu.Rows.Count == 0) MaPhieu_tepm = "0";
            else
            {
                MaPhieu_tepm = dtMaPhieu.Rows[0][0].ToString();

            }

            if (MaPhieu_tepm == "") MaPhieu_tepm = "0";
            long d = long.Parse(MaPhieu_tepm);
            bool ok = false;
            while (ok == false)
            {

                d++;
                MaPhieu_tepm = "PT-" + DateTime.Parse(SysDate_).ToString("yyMM") + "0000000".Substring(0, 5 - d.ToString().Length) + d.ToString();
                MaPhieu_tepm = MaPhieu_tepm + "CT";
                string sqlSave = "insert into Kb_MAPHIEUCLS(SoTT,SysDate,MaBienLai) values(" + d.ToString() + ",'" + SysDate_ + "','" + MaPhieu_tepm + "')";
                ok = DataAcess.Connect.ExecSQL(sqlSave);
            }
        }
        return MaPhieu_tepm;
    }
    #endregion
    #region nvk_setTongHopChanDoan
    public static void nvk_setTongHopChanDoan(string IdBenhBHDongTien, bool IsNoiTru, ref string nvk_listMaIcd, ref string nvk_listMoTaIcd)
    {
        System.Collections.Generic.List<string> list_Ma = null;
        System.Collections.Generic.List<string> list_MoTa = null;
        nvk_setTongHopChanDoan(IdBenhBHDongTien, IsNoiTru, ref nvk_listMaIcd, ref nvk_listMoTaIcd, ref list_Ma, ref list_MoTa);
    }
    public static void nvk_setTongHopChanDoan(string IdBenhBHDongTien, bool IsNoiTru, ref string nvk_listMaIcd, ref string nvk_listMoTaIcd, ref System.Collections.Generic.List<string> list_Ma, ref System.Collections.Generic.List<string> list_MoTa, ref System.Collections.Generic.List<string> list_Idicd)
    {
        nvk_listMaIcd = "";
        nvk_listMoTaIcd = "";
        list_Ma = new System.Collections.Generic.List<string>();
        list_MoTa = new System.Collections.Generic.List<string>();

        DataTable dt_cd = null;
        if (IdBenhBHDongTien == null || IdBenhBHDongTien == "") return;

        DataTable dt1 = DataAcess.Connect.GetTable(@"select distinct  cd.idicd, xk.MoTaCD_edit,cd.maicd
														from benhnhanxuatkhoa xk 
                                                         left join chandoanicd cd on cd.idicd= xk.chandoanxuatkhoa
	                                                    LEFT JOIN CHITIETDANGKYKHAM CTDK ON XK.IDCHITIETDANGKYKHAM=CTDK.IDCHITIETDANGKYKHAM
                                                        LEFT JOIN DANGKYKHAM DK ON CTDK.IDDANGKYKHAM=DK.IDDANGKYKHAM
	                                                    WHERE xk.idHuongDieuTri=17 and DK.IDBENHBHDONGTIEN='" + IdBenhBHDongTien + @"'
												union all
												select distinct ct.idicd,MOTACD_edit=ct.MoTaChanDoan_XK,cd.maicd
                                                        from nvk_chandoanxuatkhoa ct
                                                        inner join  benhnhanxuatkhoa xk on xk.idxuatkhoa =ct.idxuatkhoa
		                                                left join chandoanicd cd on cd.idicd= ct.idicd
	                                                    LEFT JOIN CHITIETDANGKYKHAM CTDK ON XK.IDCHITIETDANGKYKHAM=CTDK.IDCHITIETDANGKYKHAM
                                                        LEFT JOIN DANGKYKHAM DK ON CTDK.IDDANGKYKHAM=DK.IDDANGKYKHAM
	                                                    WHERE xk.idHuongDieuTri=17 and DK.IDBENHBHDONGTIEN=" + IdBenhBHDongTien
                                                   );
        if (dt1 == null || dt1.Rows.Count == 0 || (dt1.Rows.Count==1 && dt1.Rows[0][0].ToString()==""))
        {


            string nvk_sq = @"	SELECT distinct b.IDICD,a.MOTACD_edit,b.maicd
	                    FROM KHAMBENH a
		                    left JOIN CHANDOANICD b ON a.KETLUAN=b.IDICD
                            LEFT JOIN DANGKYKHAM C ON A.IDDANGKYKHAM=C.IDDANGKYKHAM
	                    WHERE CONVERT(NVARCHAR(500), a.ketluan) <>'0' AND C.IDBENHBHDONGTIEN=" + IdBenhBHDongTien + @"
                    union ALL
	                    SELECT distinct c.IDICD,b.MOTACD_edit,c.maicd
	                    FROM KHAMBENH A
		                    inner JOIN CHANDOANPHOIHOP B ON  a.IDKHAMBENH=B.IDKHAMBENH
		                    LEFT JOIN CHANDOANICD C ON  c.IDICD=b.IDICD
                            LEFT JOIN DANGKYKHAM D ON A.IDDANGKYKHAM=D.IDDANGKYKHAM
	                    WHERE D.IDBENHBHDONGTIEN=" + IdBenhBHDongTien + @""
        + (IsNoiTru ? @"
                    union ALL
	                    select distinct nk.idicd,MOTACD_edit=nk.MoTaChanDoan_NK,cd.maicd
                            from nvk_chandoannhapkhoa nk 
                            inner join  benhnhannoitru nt on nt.idnoitru =nk.idnoitru
		                    left join chandoanicd cd on cd.idicd= nk.idicd
                            LEFT JOIN CHITIETDANGKYKHAM CT ON NT.IDCHITIETDANGKYKHAM=CT.IDCHITIETDANGKYKHAM
                            LEFT JOIN DANGKYKHAM DK ON CT.IDDANGKYKHAM=DK.IDDANGKYKHAM
	                    WHERE DK.IDBENHBHDONGTIEN=" + IdBenhBHDongTien + @""
            : "");
            dt_cd = DataAcess.Connect.GetTable(nvk_sq);
            dt_cd.DefaultView.RowFilter = "MOTACD_EDIT<>''";
            dt_cd = dt_cd.DefaultView.ToTable();

        }
        else dt_cd = dt1;

        System.Collections.Generic.List<String> lstC = new System.Collections.Generic.List<string>();
        list_Idicd = new System.Collections.Generic.List<string>();
        if (dt_cd != null && dt_cd.Rows.Count > 0)
        {
            for (int i = 0; i < dt_cd.Rows.Count; i++)
            {
                if (lstC.IndexOf(dt_cd.Rows[i]["maicd"].ToString()) == -1)
                {
                    nvk_listMaIcd += " " + dt_cd.Rows[i]["maicd"].ToString() + " -";
                    nvk_listMoTaIcd += " " + dt_cd.Rows[i]["MOTACD_edit"].ToString() + " -";
                    lstC.Add(dt_cd.Rows[i]["maicd"].ToString());
                    list_Ma.Add(dt_cd.Rows[i]["maicd"].ToString());
                    list_MoTa.Add(dt_cd.Rows[i]["MOTACD_edit"].ToString());
                    list_Idicd.Add(dt_cd.Rows[i]["idicd"].ToString());
                }
            }
            nvk_listMaIcd = nvk_listMaIcd.TrimEnd('-');
            nvk_listMoTaIcd = nvk_listMoTaIcd.TrimEnd('-');
        }
    }

    public static void nvk_setTongHopChanDoan(string IdBenhBHDongTien, bool IsNoiTru, ref string nvk_listMaIcd, ref string nvk_listMoTaIcd, ref System.Collections.Generic.List<string> list_Ma, ref System.Collections.Generic.List<string> list_MoTa)
    {
        nvk_listMaIcd = "";
        nvk_listMoTaIcd = "";
        list_Ma = new System.Collections.Generic.List<string>();
        list_MoTa = new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<string> list_Idicd = new List<string>();
        nvk_setTongHopChanDoan(IdBenhBHDongTien, IsNoiTru, ref  nvk_listMaIcd, ref  nvk_listMoTaIcd, ref  list_Ma, ref  list_MoTa, ref list_Idicd);
    }
    #endregion
    #region nvk thông tin bảo hiểm by idbnbhdt
    public static DataTable nvk_thongTimBaohiemBy_idbnbhdt(string idbnbhdt)
    {
        string sqlInfor = @"SELECT top 1
            b.idbenhnhan,
            b.mabenhnhan,
            b.tenbenhnhan,
            b.diachi,TuoiBN=DBO.KB_Tuoi(B.NgaySinh),
            tengioitinh=dbo.getgioitinh(b.gioitinh),
            b.gioitinh,
            b.ngaysinh,
            b.chungminhthu,
            b.ngaytiepnhan,
            (CASE WHEN DONG.ISBHYT=1 THEN 1 ELSE 2 END) as loai,
            b.dienthoai,
            bnbh.sobhyt,
            bnbh.ngaybatdau,
            bnbh.ngayhethan,
            bnbh.DungTuyen,
            noigioithieu=ngt.TENNOIDANGKY,
            noidangkykcb=ndk.TENNOIDANGKY,
			MaDangKy_KCB_bandau=ndk.MADANGKY,
            capcuu =dong.IsCapCuu,
    		thoihanthe = (case when  DONG.ISBHYT=1 then convert(varchar(10),bnbh.ngaybatdau,103)+N'  đến  '+ convert(varchar(10),bnbh.ngayhethan,103) else N'' end),
            chandoansobo=( SELECT  top 1 chandoanbandau from khambenh A1 LEFT JOIN DANGKYKHAM B1 ON A1.IDDANGKYKHAM=B1.IDDANGKYKHAM   WHERE B1.IDBENHBHDONGTIEN=" + idbnbhdt + @"  ORDER BY IDKHAMBENH   ),
            SoNgayDieuTri=CONVERT(INT,DONG.NgayTinhBH_Thuc-DONG.NgayTinhBH),
            idchitietdangkykham=DONG.IDCHITIETDANGKYKHAM_PREV,
            iddangkykham=DONG.IDDANGKYKHAM_DV,
            b.idbenhnhan,
            ngaynhapvien=DONG.NgayTinhBH,
            giovaovien= convert(varchar(5),DONG.NgayTinhBH,108),
            gioravien= convert(varchar(5),DONG.NgayTinhBH_Thuc,108),
            ngayxuatvien= DONG.NgayTinhBH_Thuc,
            NgayTinhBH_Thuc,
            IsNoiTru=Dong.IsNoiTru,
            DONG.ISBHYT,
            TenKhoa=(SELECT TENPHONGKHAMBENH FROM KHAMBENH A2 LEFT JOIN PHONGKHAMBENH B2 ON ISNULL(A2.IDKHOA,A2.IDPHONGKHAMBENH)=B2.IDPHONGKHAMBENH WHERE A2.IDKHAMBENH=DONG.IDKHAMBENH_LAST)
            ,NOICONGTAC=B.NOICONGTAC
             FROM    HS_BenhNhanBHDongTien dong 
                    left join benhnhan_bhyt bnbh on bnbh.idbenhnhan_bh=dong.idbenhnhan_bh
			        left join KB_NOIDANGKYKB ndk on ndk.IDNOIDANGKY= bnbh.IdNoiDangKyBH
			        left join KB_NOIDANGKYKB ngt on ngt.IDNOIDANGKY= bnbh.IdNoiGioiThieu
                    LEFT JOIN BENHNHAN B ON dong.IdBenhNhan=B.IdBenhNhan
            WHERE DONG.ID=" + idbnbhdt;
        DataTable dtBN = DataAcess.Connect.GetTable(sqlInfor);
        return dtBN;
    }
    #endregion
    #region nvk thông tin bảo hiểm by idchitietdangkykham
    public static DataTable nvk_thongTimBaohiemBy_idctdkk(string idchitietdangkykham)
    {
        string sqlSelect = @"SELECT isnull(IDBENHBHDONGTIEN,0) 
                                        FROM CHITIETDANGKYKHAM A
                                        LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                        WHERE A.IDCHITIETDANGKYKHAM=" + idchitietdangkykham;
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt == null || dt.Rows.Count == 0) return null;
        return nvk_thongTimBaohiemBy_idbnbhdt(dt.Rows[0][0].ToString());
    }
    #endregion
    #region nvk thông tin bảo hiểm by idkhambenh
    public static DataTable nvk_thongTimBaohiemBy_idkhambenh(string idkhambenh)
    {
        string sqlSelect = @"SELECT IDBENHBHDONGTIEN  
                                        FROM KHAMBENH A0
                                        LEFT JOIN CHITIETDANGKYKHAM A ON A0.IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM
                                        LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                        WHERE A0.IDKHAMBENH=" + idkhambenh;
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt == null || dt.Rows.Count == 0) return null;
        return nvk_thongTimBaohiemBy_idbnbhdt(dt.Rows[0][0].ToString());
    }
    #endregion
    #region ThongTinhHanhChinh Đơn thuần
    public static DataTable dtBenhNhanInfor(string IdBenhNhan)
    {
        string nvk_sql = @"
           select idbenhnhan,mabenhnhan,tenbenhnhan,namsinh =dbo.getnamsinh(ngaysinh),tuoi=dbo.kb_gettuoi(ngaysinh),gioitinh=dbo.getgioitinh(gioitinh)
		    ,diachi,dienthoai,sobhyt=null,noidangkykcb=null,noigioithieu=null
		    ,thoihanthe =null
            ,chandoansobo=null,nvk_chandoan=NULL,nvk_machandoan=NULL
           from benhnhan bn where idbenhnhan='" + IdBenhNhan + @"'";
        DataTable dt = DataAcess.Connect.GetTable(nvk_sql);
        return dt;
    }
    #endregion
    #region Get List ChanDoanICd by IdKhamBenh
    public static void nvk_setTongHopChanDoan_ByIdKhamBenh(string IdKhamBenh, ref string nvk_listMaIcd, ref string nvk_listMoTaIcd)
    {
        if (IdKhamBenh == null || IdKhamBenh == "") return;
        string nvk_sq = @"	SELECT distinct a.MOTACD_edit,b.maicd
	                FROM KHAMBENH a
		                left JOIN CHANDOANICD b ON a.KETLUAN=b.IDICD
	                WHERE a.ketluan>0 AND A.IdKhamBenh=" + IdKhamBenh + @"
                union ALL
	                SELECT distinct b.MOTACD_edit,c.maicd
	                FROM KHAMBENH A
		                inner JOIN CHANDOANPHOIHOP B ON  a.IDKHAMBENH=B.IDKHAMBENH
		                LEFT JOIN CHANDOANICD C ON  c.IDICD=b.IDICD
                       WHERE A.IdKhamBenh=" + IdKhamBenh;
        DataTable dt_cd = DataAcess.Connect.GetTable(nvk_sq);
        System.Collections.Generic.List<String> lstC = new System.Collections.Generic.List<string>();

        if (dt_cd != null && dt_cd.Rows.Count > 0)
        {
            nvk_listMoTaIcd = "";
            nvk_listMaIcd = "";
            for (int i = 0; i < dt_cd.Rows.Count; i++)
            {
                if (lstC.IndexOf(dt_cd.Rows[i]["maicd"].ToString()) == -1)
                {
                    nvk_listMaIcd += " " + dt_cd.Rows[i]["maicd"].ToString() + " -";
                    nvk_listMoTaIcd += " " + dt_cd.Rows[i]["MOTACD_edit"].ToString() + " -";
                    lstC.Add(nvk_listMaIcd);
                }
            }
            nvk_listMaIcd = nvk_listMaIcd.TrimEnd('-');
            nvk_listMoTaIcd = nvk_listMoTaIcd.TrimEnd('-');
        }
    }
    #endregion
    #region Lấy số thứ tự đăng ký khám mới
    public static string GetSoThuTuDangKyKhamMoi(string IdPhong, string NgayDangKy, bool IsSave)
    {
        if (IdPhong == null || IdPhong == "" || NgayDangKy == null || NgayDangKy == "") return null;
        string sqlSelect = @"SELECT MAX(SOTT) FROM HS_SOTHUTUDKK
                                             WHERE YEAR(SYSDATE)=YEAR('" + NgayDangKy + @"')
                                                    AND MONTH(SYSDATE)=MONTH('" + NgayDangKy + @"')
                                                    AND DAY(SYSDATE)=DAY('" + NgayDangKy + @"')
                                                    AND IDPHONG=" + IdPhong;
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt == null) return null;
        string NewSTT = "0";
        if (dt.Rows.Count > 0) NewSTT = dt.Rows[0][0].ToString();
        if (NewSTT == "") NewSTT = "0";

        NewSTT = (int.Parse(NewSTT) + 1).ToString();
        if (IsSave)
        {
            string sqlSave = "";
            if (dt.Rows.Count > 0)
                sqlSave = "INSERT INTO HS_SOTHUTUDKK(SYSDATE,IDPHONG,SOTT) VALUES('" + NgayDangKy + "'," + IdPhong + "," + NewSTT + ")";
            else
                sqlSave = "UPDATE HS_SOTHUTUDKK SET SOTT=" + NewSTT + "  WHERE YEAR(SYSDATE)=YEAR('" + NgayDangKy + @"')
                                                    AND MONTH(SYSDATE)=MONTH('" + NgayDangKy + @"')
                                                    AND DAY(SYSDATE)=DAY('" + NgayDangKy + @"')
                                                    AND IDPHONG=" + IdPhong;

            bool ok = DataAcess.Connect.ExecSQL(sqlSave);
            if (ok) return NewSTT;
            return null;
        }
        return NewSTT;
    }
    #endregion
    #region Make so vao vien
    //-------------------------------------------------------------------------------------------------------------------
    public static string GetSoVaoVien(string idkhambenh, string idchitietdangkykham, string IsNoiTru)
    {
        if (idchitietdangkykham == "" || IsNoiTru == null || IsNoiTru == "") return "";
        string sqlSelect1 = @"SELECT IDBENHBHDONGTIEN 
                                FROM CHITIETDANGKYKHAM A
                                LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                WHERE A.IDCHITIETDANGKYKHAM=" + idchitietdangkykham;
        DataTable dt1 = DataAcess.Connect.GetTable(sqlSelect1);
        if (dt1 == null || dt1.Rows.Count == 0) return "";
        string IdBenhNhanBHDongTien = dt1.Rows[0][0].ToString();
        string sqlSave1 = "EXEC ZHS_MASOVAOVIEN " + IdBenhNhanBHDongTien + "," + (StaticData.IsCheck(IsNoiTru) == true ? "1" : "0");
        bool OK = DataAcess.Connect.ExecSQL(sqlSave1);
        if (!OK) return "";
        string sqlSelect2 = "SELECT SOVAOVIEN FROM HS_BENHNHANBHDONGTIEN WHERE ID=" + IdBenhNhanBHDongTien;
        DataTable dt2 = DataAcess.Connect.GetTable(sqlSelect2);
        if (dt2 == null || dt2.Rows.Count == 0) return "";
        string SoVaoVien = dt2.Rows[0][0].ToString();
        if (idkhambenh != null && idkhambenh != "")
        {
            string sqlSave2 = "UPDATE KHAMBENH SET ISNOITRU=" + (StaticData.IsCheck(IsNoiTru) == true ? "1" : "0")
            + ", SOVAOVIEN='" + SoVaoVien + "' WHERE IDKHAMBENH=" + idkhambenh;
            bool OK2 = DataAcess.Connect.ExecSQL(sqlSave2);
        }
        return SoVaoVien;
    }
    //--------------------------------------------------------------------------
    #endregion
    #region TAOSOPHIEUYC-HV-TL
    public static string TaoSoPhieuYCTL(string idkho, string ngaythang)
    {
        string sqlSelect = @"SELECT COUNT(*) FROM PHIEUXUATKHO 
                                    WHERE YEAR(NGAYTHANG)=YEAR('" + ngaythang + @"')
                                          AND MONTH(NGAYTHANG)=MONTH('" + ngaythang + @"')
                                          AND DAY(NGAYTHANG)=DAY('" + ngaythang + @"')
                                           AND LOAIXUAT=6 ";
        int nCount = 0;
        DataTable dtCount = DataAcess.Connect.GetTable(sqlSelect);
        if (dtCount != null && dtCount.Rows.Count > 0)
            nCount = int.Parse(dtCount.Rows[0][0].ToString());
        nCount++;
        string SQL_TENKHOA = @"SELECT TOP 1 TENKHO FROM KHOTHUOC WHERE IDKHO=" + idkho;
        string ss = "";
        DataTable dtTenKhoa = DataAcess.Connect.GetTable(SQL_TENKHOA);
        if (dtTenKhoa != null && dtTenKhoa.Rows.Count > 0)
        {
            string[] tenkhoa = dtTenKhoa.Rows[0][0].ToString().Split(' ');
            foreach (string word in tenkhoa)
            {
                ss += word[0].ToString().ToUpper();
            }
        }
        string s = "";
        DateTime dNgay = DateTime.Parse(ngaythang);
        for (int i = 0; i < 2; i++)
        {
            s = "TL/" + ss + "-" + dNgay.ToString("ddMMyyyy") + "-" + nCount.ToString();
            string sqlCheckSoPhieu = @"SELECT * FROM PHIEUXUATKHO WHERE SOPHIEUYC='" + s + "' AND LOAIXUAT=6";
            DataTable dtCheckSoPhieu = DataAcess.Connect.GetTable(sqlCheckSoPhieu);
            if (dtCheckSoPhieu != null && dtCheckSoPhieu.Rows.Count > 0)
            {
                i--;
                nCount++;
            }
            else
                break;
        }
        return s;
    }
    public static string TaoSoPhieuYCXHV(string idkhoa, string ngaythang, string idkhoyeucau)
    {
        string sqlSelect = @"SELECT COUNT(*) FROM THUOC_YEUCAUTRAHONGVO 
                                    WHERE YEAR(NGAYYEUCAU)=YEAR('" + ngaythang + @"')
                                          AND MONTH(NGAYYEUCAU)=MONTH('" + ngaythang + @"')
                                          AND DAY(NGAYYEUCAU)=DAY('" + ngaythang + @"')
                                          AND IDKHOYEUCAU='" + idkhoyeucau + "'";
        int nCount = 0;
        DataTable dtCount = DataAcess.Connect.GetTable(sqlSelect);
        if (dtCount != null && dtCount.Rows.Count > 0)
            nCount = int.Parse(dtCount.Rows[0][0].ToString());
        nCount++;
        string SQL_TENKHO = @"SELECT TOP 1 MAKHO FROM KHOTHUOC WHERE IDKHO='" + idkhoyeucau + "'";
        string ss = "";
        DataTable dtTenKho = DataAcess.Connect.GetTable(SQL_TENKHO);
        if (dtTenKho != null && dtTenKho.Rows.Count > 0)
        {
            ss += dtTenKho.Rows[0][0].ToString();
        }
        string s = "";
        DateTime dNgay = DateTime.Parse(ngaythang);
        for (int i = 0; i < 2; i++)
        {
            s = "MHV/" + ss + "-" + dNgay.ToString("ddMMyyyy") + "-" + nCount.ToString();
            string sqlCheckSoPhieu = @"SELECT * FROM THUOC_YEUCAUTRAHONGVO WHERE SOYEUCAU='" + s + "'";
            DataTable dtCheckSoPhieu = DataAcess.Connect.GetTable(sqlCheckSoPhieu);
            if (dtCheckSoPhieu != null && dtCheckSoPhieu.Rows.Count > 0)
            {
                i--;
                nCount++;
            }
            else
                break;
        }
        return s;
    }
    public static string TaoSoPhieuYCXHV_KD(string idkho, string ngaythang)
    {
        string sqlSelect = @"SELECT COUNT(*) FROM PHIEUXUATKHO 
                                    WHERE YEAR(NGAYTHANG)=YEAR('" + ngaythang + @"')
                                          AND MONTH(NGAYTHANG)=MONTH('" + ngaythang + @"')
                                          AND DAY(NGAYTHANG)=DAY('" + ngaythang + @"')
                                           AND ISNULL(ISHONGVO,0)=1 ";
        int nCount = 0;
        DataTable dtCount = DataAcess.Connect.GetTable(sqlSelect);
        if (dtCount != null && dtCount.Rows.Count > 0)
            nCount = int.Parse(dtCount.Rows[0][0].ToString());
        nCount++;
        string SQL_TENKHOA = @"SELECT TOP 1 TENKHO FROM KHOTHUOC WHERE IDKHO=" + idkho;
        string ss = "";
        DataTable dtTenKhoa = DataAcess.Connect.GetTable(SQL_TENKHOA);
        if (dtTenKhoa != null && dtTenKhoa.Rows.Count > 0)
        {
            string[] tenkhoa = dtTenKhoa.Rows[0][0].ToString().Split(' ');
            foreach (string word in tenkhoa)
            {
                ss += word[0].ToString().ToUpper();
            }
        }
        string s = "";
        DateTime dNgay = DateTime.Parse(ngaythang);
        for (int i = 0; i < 2; i++)
        {
            s = "MHV/" + ss + "-" + dNgay.ToString("ddMMyyyy") + "-" + nCount.ToString();
            string sqlCheckSoPhieu = @"SELECT * FROM PHIEUXUATKHO WHERE SOPHIEUYC='" + s + "' AND ISNULL(ISHONGVO,0)=1";
            DataTable dtCheckSoPhieu = DataAcess.Connect.GetTable(sqlCheckSoPhieu);
            if (dtCheckSoPhieu != null && dtCheckSoPhieu.Rows.Count > 0)
            {
                i--;
                nCount++;
            }
            else
                break;
        }
        return s;
    }
    #endregion
    #region Get List ChiTietPhieuNhap
    private static DataTable dtGetListChiTietPhieuNhap(string TuNgay, string DenNgay, string IdKho, string LoaiThuocID, string IdThuoc, ref DataTable dtDauKy, bool IsKhoNhap, ref DataTable dtThuoc)
    {
        string sqlSelect = @"SELECT  
		                            A.IDCHITIETPHIEUNHAPKHO,
		                            B.IDTHUOC,
		                            B.sttindm05 AS TTHC,
		                            B.TENTHUOC,
                                    E.TENDVT,
                                    DAUKY_SL=0,
		                            SLNHAP=(CASE WHEN A.IDLOAINHAP_NHAP=4 THEN 0 ELSE A.SOLUONG END),
		                            SLNHAP_TRA=(CASE WHEN A.IDLOAINHAP_NHAP=4 THEN A.SOLUONG ELSE 0 END),
                                    DONGIA=ROUND(DONGIA*(100.0+ISNULL(VAT,0))/100,0),
		                            SLXUAT=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUNHAPKHO=A.IDCHITIETPHIEUNHAPKHO AND IDKHO_XUAT=A.IDKHO_NHAP AND IDLOAIXUAT_XUAT<>4  ),0),
		                            SLXUATRA=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUNHAPKHO=A.IDCHITIETPHIEUNHAPKHO AND IDKHO_XUAT=A.IDKHO_NHAP AND IDLOAIXUAT_XUAT=4),0),
		                            CATENAME=ISNULL(C.des +'.','') + CATENAME,
		                            NHOMTHUOC=ISNULL(d.MANHOM +'.','') +TENNHOM,
		                            DES1=C.SOTT
                            FROM CHITIETPHIEUNHAPKHO A
                            INNER JOIN  THUOC  B ON A.IDTHUOC=B.IDTHUOC 
                            LEFT JOIN CATEGORY C ON B.CATEID=C.CATEID
                            LEFT JOIN NHOMTHUOC D ON B.idnhomthuoc=D.idnhomthuoc
                            LEFT JOIN THUOC_DONVITINH E ON B.IDDVT=E.ID
                            WHERE B.ISTHUOCBV=1
	                            AND B.LOAITHUOCID=" + LoaiThuocID + @"
	                            AND NGAYTHANG_NHAP>='" + TuNgay + @"'
	                            AND NGAYTHANG_NHAP<='" + DenNgay + @" 23:59:59'
	                            AND IDKHO_NHAP=" + IdKho + ""
                        + (IdThuoc != null && IdThuoc != "" ? " AND A.IDTHUOC=" + IdThuoc : "");
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);

        string sqlSelect2 = @"SELECT  
		                            IDCHITIETPHIEUNHAPKHO=NULL,
		                            B.IDTHUOC,
		                            B.sttindm05 AS TTHC,
		                            B.TENTHUOC,
                                    E.TENDVT,
                                    DAUKY_SL=0,
		                            SLNHAP=  A.SOLUONG ,
		                            SLNHAP_TRA=0,
                                    DONGIA=ROUND(DONGIA*(100.0+ISNULL(VAT,0))/100,0),
		                            SLXUAT=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUNHAPKHO=A.IDCHITIETPHIEUNHAPKHO AND IDKHO_XUAT=A.IDKHO_NHAP),0),
		                            SLXUATRA=0,
		                            CATENAME=ISNULL(C.des +'.','') + CATENAME,
		                            NHOMTHUOC=ISNULL(d.MANHOM +'.','') +TENNHOM,
		                            DES1=C.SOTT
                            FROM CHITIETPHIEUNHAPKHO A
                            INNER JOIN  THUOC  B ON A.IDTHUOC=B.IDTHUOC 
                            LEFT JOIN CATEGORY C ON B.CATEID=C.CATEID
                            LEFT JOIN NHOMTHUOC D ON B.idnhomthuoc=D.idnhomthuoc
                            LEFT JOIN THUOC_DONVITINH E ON B.IDDVT=E.ID
                            WHERE B.ISTHUOCBV=1
	                            AND B.LOAITHUOCID=" + LoaiThuocID + @"
	                            AND NGAYTHANG_NHAP<'" + TuNgay + @"'
	                            AND IDKHO_NHAP=" + IdKho + ""
                        + (IdThuoc != null && IdThuoc != "" ? " AND A.IDTHUOC=" + IdThuoc : "");
        dtDauKy = DataAcess.Connect.GetTable(sqlSelect2);

        if (IsKhoNhap)
        {

            string sqlSelect3 = @"SELECT  
		                             STT=0,
                                    TTHC=B.sttindm05,
                                    tensp=B.TENTHUOC,
                                    TENDVT=TENDVT,
                                    DONGIA=0,
                                    DAUKY_SL=0,
                                    DAUKY_TT=0,
                                    NHAP_SL=0,
                                    NHAP_TT=0,
                                    NHAP_SL2=0,
                                    NHAP_TT2=0,
                                    XUAT_SL=0,
                                    XUAT_TT=0,
                                    XUAT_SL2=0,
                                    XUAT_TT2=0,
                                    CUOIKY_SL=0,
                                    CUOIKY_TT=0,
                                    GhiChu='',
                                    NHOMTHUOC=ISNULL(d.MANHOM +'.','') +TENNHOM,
                                    CATENAME=ISNULL(C.des +'.','') + CATENAME,
                                    DES=C.DES,
                                    MANHOM=D.MANHOM,
                                    IDTHUOC=B.IDTHUOC,
                                    DES1=C.SOTT
                            FROM    THUOC  B  
                            LEFT JOIN CATEGORY C ON B.CATEID=C.CATEID
                            LEFT JOIN NHOMTHUOC D ON B.idnhomthuoc=D.idnhomthuoc
                            LEFT JOIN THUOC_DONVITINH E ON B.IDDVT=E.ID
                            WHERE B.ISTHUOCBV=1
	                            AND B.LOAITHUOCID=" + LoaiThuocID + @"
                                AND NOT EXISTS (SELECT TOP 1 1 FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP=" + IdKho + @" AND IDTHUOC=B.IDTHUOC )"
                            + (IdThuoc != null && IdThuoc != "" ? " AND B.IDTHUOC=" + IdThuoc : "");
            dtThuoc = DataAcess.Connect.GetTable(sqlSelect3);
        }

        return dt;
    }
    #endregion
    #region NhapXuatTonRutGonKho
    public static DataTable dtGetListTonKho(string TuNgay, string DenNgay, string IdKho, string LoaiThuocID, string IdThuoc, bool IsRutGon, bool IsSoLuong, bool IsHaveDonGia)
    {

        bool IsKhoNhap = true;
        if (IsRutGon)
        {
            string arrIdKhoNhap = StaticData.GetParaValueDB("IdKhoNhap");

            if (arrIdKhoNhap != null && arrIdKhoNhap != "")
            {
                IsKhoNhap = (arrIdKhoNhap.IndexOf(IdKho) != -1 ? true : false);
            }
        }

        //---------------------------------------------------------
        DataTable dtDauKy = null;
        DataTable dtThuoc = null;
        DataTable dt = dtGetListChiTietPhieuNhap(TuNgay, DenNgay, IdKho, LoaiThuocID, IdThuoc, ref dtDauKy, IsKhoNhap, ref dtThuoc);
        //---------------------------------------------------------
        DataTable dtResult = new DataTable();
        double dTemp = 0;
        Type dType = dTemp.GetType();

        dtResult.Columns.Add("STT");
        dtResult.Columns.Add("TTHC");
        dtResult.Columns.Add("tensp");
        dtResult.Columns.Add("TENDVT");
        dtResult.Columns.Add("DONGIA");
        dtResult.Columns.Add("DAUKY_SL", dType);
        dtResult.Columns.Add("DAUKY_TT", dType);
        dtResult.Columns.Add("NHAP_SL", dType);
        dtResult.Columns.Add("NHAP_TT", dType);
        dtResult.Columns.Add("NHAP_SL2", dType);
        dtResult.Columns.Add("NHAP_TT2", dType);
        dtResult.Columns.Add("XUAT_SL", dType);
        dtResult.Columns.Add("XUAT_TT", dType);
        dtResult.Columns.Add("XUAT_SL2", dType);
        dtResult.Columns.Add("XUAT_TT2", dType);
        dtResult.Columns.Add("CUOIKY_SL", dType);
        dtResult.Columns.Add("CUOIKY_TT", dType);
        dtResult.Columns.Add("GhiChu");
        dtResult.Columns.Add("NHOMTHUOC");
        dtResult.Columns.Add("CATENAME");
        dtResult.Columns.Add("DES");
        dtResult.Columns.Add("MANHOM");
        dtResult.Columns.Add("IDTHUOC");
        dtResult.Columns.Add("DES1");
        //---------------------------------------------------------
        dtDauKy.DefaultView.RowFilter = "SLNHAP>SLXUAT";
        dtDauKy = dtDauKy.DefaultView.ToTable();
        if (dtDauKy.Rows.Count > 0)
        {
            DataTable dtDauKy2 = dtDauKy.Copy();
            for (int i = 0; i < dtDauKy2.Rows.Count; i++)
            {


                dt.DefaultView.RowFilter = "IDTHUOC=" + dtDauKy2.Rows[i]["IDTHUOC"].ToString();
                if (IsHaveDonGia)
                    dt.DefaultView.RowFilter += " AND DONGIA=" + dtDauKy2.Rows[i]["DONGIA"].ToString();


                int n = 0;
                if (IsHaveDonGia)
                    n = StaticData.int_Search(dtDauKy, "IDTHUOC=" + dtDauKy2.Rows[i]["IDTHUOC"].ToString() + " AND DONGIA=" + dtDauKy2.Rows[i]["DONGIA"].ToString());
                else
                    n = StaticData.int_Search(dtDauKy, "IDTHUOC=" + dtDauKy2.Rows[i]["IDTHUOC"].ToString());


                dtDauKy.Rows[n]["DAUKY_SL"] = double.Parse(dtDauKy.Rows[n]["SLNHAP"].ToString()) - double.Parse(dtDauKy.Rows[n]["SLXUAT"].ToString());
                dtDauKy.Rows[n]["SLNHAP"] = 0;
                dtDauKy.Rows[n]["SLXUAT"] = 0;

                if (dt.DefaultView.Count == 0)
                {

                    StaticData.dt_MoveRow(ref dtDauKy, n, ref dt);
                }
                else
                {
                    dt.DefaultView[0]["DAUKY_SL"] = double.Parse(dt.DefaultView[0]["DAUKY_SL"].ToString()) + double.Parse(dtDauKy.Rows[n]["DAUKY_SL"].ToString());
                    dtDauKy.Rows.RemoveAt(n);
                }
            }
        }
        //---------------------------------------------------------
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string IDTHUOC = dt.Rows[i]["IDTHUOC"].ToString();
            string DONGIA = dt.Rows[i]["DONGIA"].ToString();
            string TTHC = dt.Rows[i]["TTHC"].ToString();
            string tensp = dt.Rows[i]["TENTHUOC"].ToString();
            string TENDVT = dt.Rows[i]["TENDVT"].ToString();
            string DAUKY_SL = dt.Rows[i]["DAUKY_SL"].ToString();
            if (DAUKY_SL == "") DAUKY_SL = "0";
            string DAUKY_TT = "0";
            string NHAP_SL = dt.Rows[i]["SLNHAP"].ToString();
            string NHAP_TT = "0";
            string NHAP_SL2 = dt.Rows[i]["SLNHAP_TRA"].ToString();
            string NHAP_TT2 = "0";
            string XUAT_SL = dt.Rows[i]["SLXUAT"].ToString();
            string XUAT_TT = "0";
            string XUAT_SL2 = dt.Rows[i]["SLXUATRA"].ToString();
            string XUAT_TT2 = "0";
            double CUOIKY_SL = 0;
            double CUOIKY_TT = 0;
            string NHOMTHUOC = dt.Rows[i]["NHOMTHUOC"].ToString();
            string CATENAME = dt.Rows[i]["CATENAME"].ToString();
            string DES1 = dt.Rows[i]["DES1"].ToString();

            if (DONGIA == "") DONGIA = "0";
            if (NHAP_SL == "") NHAP_SL = "0";
            if (NHAP_SL2 == "") NHAP_SL2 = "0";
            if (NHAP_TT == "") NHAP_TT = "0";
            if (XUAT_SL == "") XUAT_SL = "0";
            if (XUAT_TT == "") XUAT_TT = "0";
            if (XUAT_SL2 == "") XUAT_SL2 = "0";
            if (XUAT_TT2 == "") XUAT_TT2 = "0";
            //----------------------------------------------------------------------
            if (IsRutGon)
            {
                dtResult.DefaultView.RowFilter = "IDTHUOC=" + IDTHUOC;
                if (dtResult.DefaultView.Count == 0)
                {
                    DataRow R1 = dtResult.NewRow();
                    R1["DAUKY_SL"] = double.Parse(DAUKY_SL);
                    R1["TTHC"] = TTHC;
                    R1["tensp"] = tensp;
                    R1["TENDVT"] = TENDVT;
                    R1["NHAP_SL"] = (IsKhoNhap ? double.Parse(NHAP_SL) : double.Parse(NHAP_SL2));
                    R1["NHAP_SL2"] = (IsKhoNhap ? double.Parse(NHAP_SL2) : double.Parse(XUAT_SL2));
                    R1["XUAT_SL"] = (IsKhoNhap ? double.Parse(XUAT_SL) + double.Parse(XUAT_SL2) : double.Parse(XUAT_SL));
                    CUOIKY_SL = double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) + double.Parse(NHAP_SL2) - double.Parse(XUAT_SL) - double.Parse(XUAT_SL2);
                    R1["CUOIKY_SL"] = CUOIKY_SL;
                    R1["IDTHUOC"] = IDTHUOC;
                    R1["DONGIA"] = DONGIA;
                    dtResult.Rows.Add(R1);
                }
                else
                {
                    dtResult.DefaultView[0]["DAUKY_SL"] = double.Parse(dtResult.DefaultView[0]["DAUKY_SL"].ToString()) + double.Parse(DAUKY_SL);
                    dtResult.DefaultView[0]["NHAP_SL"] = double.Parse(dtResult.DefaultView[0]["NHAP_SL"].ToString()) + (IsKhoNhap ? double.Parse(NHAP_SL) : double.Parse(NHAP_SL2));
                    dtResult.DefaultView[0]["NHAP_SL2"] = double.Parse(dtResult.DefaultView[0]["NHAP_SL2"].ToString()) + (IsKhoNhap ? double.Parse(NHAP_SL2) : double.Parse(XUAT_SL2));
                    dtResult.DefaultView[0]["XUAT_SL"] = double.Parse(dtResult.DefaultView[0]["XUAT_SL"].ToString()) + (IsKhoNhap ? double.Parse(XUAT_SL) + double.Parse(XUAT_SL2) : double.Parse(XUAT_SL));
                    dtResult.DefaultView[0]["CUOIKY_SL"] = double.Parse(dtResult.DefaultView[0]["CUOIKY_SL"].ToString()) + double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) + double.Parse(NHAP_SL2) - double.Parse(XUAT_SL) - double.Parse(XUAT_SL2);
                }
            }
            ////----------------------------------------------------------------------
            //else
            //    //----------------------------------------------------------------------
            //    if (IsSoLuong)
            //    {
            //        dtResult.DefaultView.RowFilter = "IDTHUOC=" + IDTHUOC;
            //        if (dtResult.DefaultView.Count == 0)
            //        {
            //            DataRow R1 = dtResult.NewRow();
            //            R1["DAUKY_SL"] = DAUKY_SL;
            //            R1["TTHC"] = TTHC;
            //            R1["tensp"] = tensp;
            //            R1["TENDVT"] = TENDVT;
            //            R1["DAUKY_SL"] = DAUKY_SL;
            //            R1["NHAP_SL"] = NHAP_SL;
            //            R1["NHAP_SL2"] = NHAP_SL2;
            //            R1["XUAT_SL"] = XUAT_SL;
            //            R1["XUAT_SL2"] = XUAT_SL2;
            //            CUOIKY_SL = double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) - double.Parse(XUAT_SL);
            //            R1["CUOIKY_SL"] = CUOIKY_SL;
            //            R1["CATENAME"] = CATENAME;
            //            R1["NHOMTHUOC"] = NHOMTHUOC;
            //            R1["DES1"] = DES1;
            //            R1["IDTHUOC"] = IDTHUOC;
            //            dtResult.Rows.Add(R1);
            //        }
            //        else
            //        {
            //            dtResult.DefaultView[0]["NHAP_SL"] = double.Parse(dtResult.DefaultView[0]["NHAP_SL"].ToString()) + double.Parse(NHAP_SL);
            //            dtResult.DefaultView[0]["NHAP_SL2"] = double.Parse(dtResult.DefaultView[0]["NHAP_SL2"].ToString()) + double.Parse(NHAP_SL2);
            //            dtResult.DefaultView[0]["NHAP_SL"] = double.Parse(dtResult.DefaultView[0]["NHAP_SL"].ToString()) + double.Parse(NHAP_SL);
            //            dtResult.DefaultView[0]["XUAT_SL"] = double.Parse(dtResult.DefaultView[0]["XUAT_SL"].ToString()) + double.Parse(XUAT_SL);
            //            dtResult.DefaultView[0]["XUAT_SL2"] = double.Parse(dtResult.DefaultView[0]["XUAT_SL2"].ToString()) + double.Parse(XUAT_SL2);
            //            dtResult.DefaultView[0]["CUOIKY_SL"] = double.Parse(dtResult.DefaultView[0]["CUOIKY_SL"].ToString()) + double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) - double.Parse(XUAT_SL);
            //        }
            //    }
            //    //----------------------------------------------------------------------
            //    else
            //        if (IsHaveDonGia)
            //        {
            //            dtResult.DefaultView.RowFilter = "IDTHUOC=" + IDTHUOC + " AND DONGIA=" + DONGIA;
            //            if (dtResult.DefaultView.Count == 0)
            //            {
            //                DataRow R1 = dtResult.NewRow();
            //                R1["DAUKY_SL"] = DAUKY_SL;
            //                R1["TTHC"] = TTHC;
            //                R1["tensp"] = tensp;
            //                R1["TENDVT"] = TENDVT;
            //                R1["DAUKY_SL"] = DAUKY_SL;
            //                R1["DAUKY_TT"] = double.Parse(DAUKY_SL) * double.Parse(DONGIA);
            //                R1["NHAP_SL"] = NHAP_SL;
            //                R1["NHAP_TT"] = double.Parse(NHAP_SL) * double.Parse(DONGIA);
            //                R1["XUAT_SL"] = XUAT_SL;
            //                R1["XUAT_TT"] = double.Parse(XUAT_SL) * double.Parse(DONGIA);
            //                R1["XUAT_SL2"] = XUAT_SL2;
            //                R1["XUAT_SL2"] = double.Parse(XUAT_SL2) * double.Parse(DONGIA);
            //                CUOIKY_SL = double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) - double.Parse(XUAT_SL);
            //                R1["CUOIKY_SL"] = CUOIKY_SL;
            //                CUOIKY_TT = (double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) - double.Parse(XUAT_SL)) * double.Parse(DONGIA);
            //                R1["CUOIKY_TT"] = CUOIKY_TT;
            //                R1[DONGIA] = DONGIA;
            //                R1["CATENAME"] = CATENAME;
            //                R1["NHOMTHUOC"] = NHOMTHUOC;
            //                R1["DES1"] = DES1;
            //                R1["IDTHUOC"] = IDTHUOC;
            //                dtResult.Rows.Add(R1);
            //            }
            //            else
            //            {
            //                dtResult.DefaultView[0]["NHAP_SL"] = double.Parse(dtResult.DefaultView[0]["NHAP_SL"].ToString()) + double.Parse(NHAP_SL);
            //                dtResult.DefaultView[0]["NHAP_TT"] = double.Parse(dtResult.DefaultView[0]["NHAP_TT"].ToString()) + double.Parse(NHAP_SL) * double.Parse(DONGIA);
            //                dtResult.DefaultView[0]["NHAP_SL2"] = double.Parse(dtResult.DefaultView[0]["NHAP_SL2"].ToString()) + double.Parse(NHAP_SL2);
            //                dtResult.DefaultView[0]["NHAP_TT2"] = double.Parse(dtResult.DefaultView[0]["NHAP_TT2"].ToString()) + double.Parse(NHAP_SL2) * double.Parse(DONGIA);
            //                dtResult.DefaultView[0]["XUAT_SL"] = double.Parse(dtResult.DefaultView[0]["XUAT_SL"].ToString()) + double.Parse(XUAT_SL);
            //                dtResult.DefaultView[0]["XUAT_TT"] = double.Parse(dtResult.DefaultView[0]["XUAT_TT"].ToString()) + double.Parse(XUAT_SL) * double.Parse(DONGIA);
            //                dtResult.DefaultView[0]["XUAT_SL2"] = double.Parse(dtResult.DefaultView[0]["XUAT_SL2"].ToString()) + double.Parse(XUAT_SL2);
            //                dtResult.DefaultView[0]["XUAT_TT2"] = double.Parse(dtResult.DefaultView[0]["XUAT_TT2"].ToString()) + double.Parse(XUAT_SL2) * double.Parse(DONGIA);
            //                dtResult.DefaultView[0]["CUOIKY_SL"] = double.Parse(dtResult.DefaultView[0]["CUOIKY_SL"].ToString()) + double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) - double.Parse(XUAT_SL);
            //            }
            //        }
            //        else
            //        {
            //            dtResult.DefaultView.RowFilter = "IDTHUOC=" + IDTHUOC;
            //            if (dtResult.DefaultView.Count == 0)
            //            {
            //                DataRow R1 = dtResult.NewRow();
            //                R1["DAUKY_SL"] = DAUKY_SL;
            //                R1["TTHC"] = TTHC;
            //                R1["tensp"] = tensp;
            //                R1["TENDVT"] = TENDVT;
            //                R1["DAUKY_SL"] = DAUKY_SL;
            //                R1["DAUKY_TT"] = double.Parse(DAUKY_SL) * double.Parse(DONGIA);
            //                R1["NHAP_SL"] = NHAP_SL;
            //                R1["NHAP_TT"] = double.Parse(NHAP_SL) * double.Parse(DONGIA);
            //                R1["XUAT_SL"] = XUAT_SL;
            //                R1["XUAT_TT"] = double.Parse(XUAT_SL) * double.Parse(DONGIA);
            //                R1["XUAT_SL2"] = XUAT_SL2;
            //                R1["XUAT_SL2"] = double.Parse(XUAT_SL2) * double.Parse(DONGIA);
            //                CUOIKY_SL = double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) - double.Parse(XUAT_SL);
            //                R1["CUOIKY_SL"] = CUOIKY_SL;
            //                CUOIKY_TT = (double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) - double.Parse(XUAT_SL)) * double.Parse(DONGIA);
            //                R1["CUOIKY_TT"] = CUOIKY_TT;
            //                R1["CATENAME"] = CATENAME;
            //                R1["NHOMTHUOC"] = NHOMTHUOC;
            //                R1["DES1"] = DES1;
            //                R1["IDTHUOC"] = IDTHUOC;
            //                dtResult.Rows.Add(R1);
            //            }
            //            else
            //            {
            //                dtResult.DefaultView[0]["NHAP_SL"] = double.Parse(dtResult.DefaultView[0]["NHAP_SL"].ToString()) + double.Parse(NHAP_SL);
            //                dtResult.DefaultView[0]["NHAP_TT"] = double.Parse(dtResult.DefaultView[0]["NHAP_TT"].ToString()) + double.Parse(NHAP_SL) * double.Parse(DONGIA);
            //                dtResult.DefaultView[0]["NHAP_SL2"] = double.Parse(dtResult.DefaultView[0]["NHAP_SL2"].ToString()) + double.Parse(NHAP_SL2);
            //                dtResult.DefaultView[0]["NHAP_TT2"] = double.Parse(dtResult.DefaultView[0]["NHAP_TT2"].ToString()) + double.Parse(NHAP_SL2) * double.Parse(DONGIA);
            //                dtResult.DefaultView[0]["XUAT_SL"] = double.Parse(dtResult.DefaultView[0]["XUAT_SL"].ToString()) + double.Parse(XUAT_SL);
            //                dtResult.DefaultView[0]["XUAT_TT"] = double.Parse(dtResult.DefaultView[0]["XUAT_TT"].ToString()) + double.Parse(XUAT_SL) * double.Parse(DONGIA);
            //                dtResult.DefaultView[0]["XUAT_SL2"] = double.Parse(dtResult.DefaultView[0]["XUAT_SL2"].ToString()) + double.Parse(XUAT_SL2);
            //                dtResult.DefaultView[0]["XUAT_TT2"] = double.Parse(dtResult.DefaultView[0]["XUAT_TT2"].ToString()) + double.Parse(XUAT_SL2) * double.Parse(DONGIA);
            //                dtResult.DefaultView[0]["CUOIKY_SL"] = double.Parse(dtResult.DefaultView[0]["CUOIKY_SL"].ToString()) + double.Parse(DAUKY_SL) + double.Parse(NHAP_SL) - double.Parse(XUAT_SL);
            //            }
            //        }
            //----------------------------------------------------------------------

        }
        //---------------------------------------------------------
        if (IsKhoNhap && dtThuoc != null && dtThuoc.Rows.Count > 0)
        {
            for (int i = 0; i < dtThuoc.Rows.Count; i++)
            {
                dtResult.DefaultView.RowFilter = "IDTHUOC=" + dtThuoc.Rows[i]["IDTHUOC"].ToString();
                if (dtResult.DefaultView.Count == 0)
                    StaticData.dt_ImportRow(dtThuoc, i, ref dtResult);
            }
        }
        //---------------------------------------------------------
        return dtResult;
    }
    #endregion
    #region DTKhoa
    private static DataTable dtKhoa_temp = null;
    public static DataTable dtKhoa
    {
        get
        {
            if (dtKhoa_temp == null)
            {
                string sqlSelect = "SELECT * FROM PHONGKHAMBENH";
                dtKhoa_temp = DataAcess.Connect.GetTable(sqlSelect);
            }
            return dtKhoa_temp;
        }
        set
        {
            dtKhoa_temp = value;
        }
    }
    #endregion
}

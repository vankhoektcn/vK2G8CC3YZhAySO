using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for myInsertPhieuXuatKho
/// </summary>
public class myInsertPhieuXuatKho
{
    #region Init
    public myInsertPhieuXuatKho()
    {
    }
    #endregion
    #region TaoSoPhieuXuat
    public static string TaoSoPhieuXuat(string NgayThangNam, ref string newSTT)
    {
        newSTT = "0";
        return "";
    }
  
    #endregion
    #region Xuất kho
    public static int LuuPhieuXuatChuyenKho(string idbenhnhan, string ngaychungtu,
        string KhoNhap, string KhoXuat,
        DataTable dtThuoc, string NguoiXuatId,
        string GhiChu
        , string VAT
        , string LoaiXuatID
        , string idbenhnhantoathuoc
        , bool IsKhachHang
        )
    {
        
        #region IdPhieuYC
        string IdPhieuYC = "NULL";
        string SOPHIEUYC = "";
        if (dtThuoc.Columns.IndexOf("IdChiTietPhieuYC") != -1)
        {
            string sqlGetPhieuYC = "SELECT A.IdPhieuYC,B.SOPHIEU FROM Thuoc_ChiTietPhieuYCXuat A LEFT JOIN THUOC_PhieuYCXuat B ON A.IDPHIEUYC=B.IDPHIEUYC  WHERE A.IdChiTietPhieuYC=" + dtThuoc.Rows[0]["IdChiTietPhieuYC"].ToString();
            DataTable dtYC = DataAcess.Connect.GetTable(sqlGetPhieuYC);
            if (dtYC != null && dtYC.Rows.Count > 0)
            {
                IdPhieuYC = dtYC.Rows[0][0].ToString();
                SOPHIEUYC = dtYC.Rows[0][1].ToString();
            }
        }
        #endregion
        #region idkhambenh
        string IdKhamBenh1 = "NULL";
        if (dtThuoc.Columns.IndexOf("IDCHITIETBENHNHANTOATHUOC") != -1)
        {
            string IdChiTietBenhNhanToaThuoc1 = dtThuoc.Rows[0]["IdChiTietBenhNhanToaThuoc"].ToString();
            if (IdChiTietBenhNhanToaThuoc1 != "" && IdChiTietBenhNhanToaThuoc1 != "0")
            {
                string sqlKB = "SELECT IDKHAMBENH FROM CHITIETBENHNHANTOATHUOC WHERE IDCHITIETBENHNHANTOATHUOC=" + IdChiTietBenhNhanToaThuoc1;
                DataTable kb = DataAcess.Connect.GetTable(sqlKB);
                if (kb != null && kb.Rows.Count > 0)
                    IdKhamBenh1 = kb.Rows[0][0].ToString();
            }
        }
        #endregion
        #region MaPhieuXuat
        string maphieuxuat = "";
        string newSTT = "";
        if (maphieuxuat == "")   maphieuxuat = TaoSoPhieuXuat(ngaychungtu, ref newSTT);
        #endregion
        #region Tham số khác
        string idkho = KhoXuat;
        string nguoixuat = NguoiXuatId;
        string ghichu = GhiChu;
        string loaixuat = LoaiXuatID;
        #endregion
        DataTable listthuoc = dtThuoc;
        DataAcess.Connect.BeginTran();
        string sidphieuxuat = InsertPhieuXuatKho(maphieuxuat
                                                , ngaychungtu
                                                , ghichu
                                                ,null
                                                ,null
                                                ,null
                                                ,idkho
                                                ,loaixuat
                                                ,null
                                                ,VAT
                                                ,null
                                                ,ngaychungtu
                                                ,null
                                                ,KhoNhap
                                                ,nguoixuat
                                                ,idbenhnhantoathuoc
                                                ,null
                                                ,newSTT
                                                ,null
                                                ,null
                                                ,null
                                                ,null
                                                ,null
                                                ,null
                                                ,null
                                                ,null
                                                ,null
                                                ,null
                                                ,idbenhnhan
                                                ,IdKhamBenh1
                                                ,IdPhieuYC
                                                ,SOPHIEUYC);
                                                 
        if (sidphieuxuat==null)
        {
            DataAcess.Connect.RollBack();
            return 0;
        }
        int idphieuxuat = int.Parse(sidphieuxuat);
        for (int i = 0; i < listthuoc.Rows.Count; i++)
        {

            string iSLXuat = (listthuoc.Columns.IndexOf("soluong") != -1 ? listthuoc.Rows[i]["soluong"].ToString() : listthuoc.Rows[i]["soluongke"].ToString());
            if (listthuoc.Columns.IndexOf("SLXuat1") != -1)
                iSLXuat = listthuoc.Rows[i]["SLXuat1"].ToString();
            float n = (float)StaticData.ParseFloat(iSLXuat);
            string nvk_idkhambenh1 = DataAcess.Connect.GetTable("select isnull((select idkhambenh from chitietbenhnhantoathuoc ct inner join khothuoc k on k.idkho=ct.idkho where nvk_loaikho =3 and idchitietbenhnhantoathuoc ='" + (dtThuoc.Columns.IndexOf("IDCHITIETBENHNHANTOATHUOC") != -1 ? listthuoc.Rows[i]["IDCHITIETBENHNHANTOATHUOC"].ToString() : "0") + "'),0)").Rows[0][0].ToString();
            string sqlSaveChiTietPhieuXuatKho = @"
                    EXEC  Thuoc_XuatThuoc_Automatic_2209 "
                                                    + listthuoc.Rows[i]["IdThuoc"].ToString()
                                                    + "," + "'" + ngaychungtu + "'"
                                                    + "," + n.ToString()
                                                    + "," + idkho
                                                    + "," + idphieuxuat.ToString()
                                                    + "," + "NULL"
                                                    + "," + (dtThuoc.Columns.IndexOf("IdChiTietPhieuYC") != -1 ? listthuoc.Rows[i]["IdChiTietPhieuYC"].ToString() : "NULL")
                                                    + "," + nvk_idkhambenh1
                                                    + "," + (dtThuoc.Columns.IndexOf("IDCHITIETBENHNHANTOATHUOC") != -1 ? listthuoc.Rows[i]["IDCHITIETBENHNHANTOATHUOC"].ToString() : "NULL");
            bool ok_ChiTiet = DataAcess.Connect.ExecSQL(sqlSaveChiTietPhieuXuatKho);
            if (!ok_ChiTiet)
            {
                DataAcess.Connect.RollBack();
                return -1;
            }
        }

        DataAcess.Connect.Commit();
        return idphieuxuat;
    }
    #endregion
    #region Xuất kho
    public static int LuuPhieuXuatChuyenKho_YCTra(string idbenhnhan, string ngaychungtu,
        string KhoNhap, string KhoXuat,
        DataTable dtThuoc, string NguoiXuatId,
        string GhiChu
        , string VAT
        , string LoaiXuatID
        , string idbenhnhantoathuoc
        , bool IsKhachHang
        )
    {

        #region IdPhieuYC
        string IdPhieuYC = "NULL";
        string SOPHIEUYC = "";
        if (dtThuoc.Columns.IndexOf("IdChiTietPhieuYC") != -1)
        {
            // lấy idphieu yc từ phiếu yc trả
            string sqlGetPhieuYC = "SELECT IdPhieuYC=A.IdPhieuYCtra,B.SOPHIEU FROM nvk_thuoc_chitietphieuyctra A LEFT JOIN nvk_thuoc_phieuyctra B ON A.IDPHIEUYCtra=B.IDPHIEUYCtra  WHERE A.IdChiTietPhieuYCtra=" + dtThuoc.Rows[0]["IdChiTietPhieuYC"].ToString();
            DataTable dtYC = DataAcess.Connect.GetTable(sqlGetPhieuYC);
            if (dtYC != null && dtYC.Rows.Count > 0)
            {
                IdPhieuYC = dtYC.Rows[0][0].ToString();
                SOPHIEUYC = dtYC.Rows[0][1].ToString();
            }
        }
        #endregion
        #region idkhambenh
        string IdKhamBenh1 = "NULL";
        if (dtThuoc.Columns.IndexOf("IDCHITIETBENHNHANTOATHUOC") != -1)
        {
            string IdChiTietBenhNhanToaThuoc1 = dtThuoc.Rows[0]["IdChiTietBenhNhanToaThuoc"].ToString();
            if (IdChiTietBenhNhanToaThuoc1 != "" && IdChiTietBenhNhanToaThuoc1 != "0")
            {
                string sqlKB = "SELECT IDKHAMBENH FROM CHITIETBENHNHANTOATHUOC WHERE IDCHITIETBENHNHANTOATHUOC=" + IdChiTietBenhNhanToaThuoc1;
                DataTable kb = DataAcess.Connect.GetTable(sqlKB);
                if (kb != null && kb.Rows.Count > 0)
                    IdKhamBenh1 = kb.Rows[0][0].ToString();
            }
        }
        #endregion
        #region MaPhieuXuat
        string maphieuxuat = "";
        string newSTT = "";
        if (maphieuxuat == "") maphieuxuat = TaoSoPhieuXuat(ngaychungtu, ref newSTT);
        #endregion
        #region Tham số khác
        string idkho = KhoXuat;
        string nguoixuat = NguoiXuatId;
        string ghichu = GhiChu;
        string loaixuat = LoaiXuatID;
        #endregion
        DataTable listthuoc = dtThuoc;
        DataAcess.Connect.BeginTran();
        string sidphieuxuat = InsertPhieuXuatKho(maphieuxuat
                                                , ngaychungtu
                                                , ghichu
                                                , null
                                                , null
                                                , null
                                                , idkho
                                                , loaixuat
                                                , null
                                                , VAT
                                                , null
                                                , ngaychungtu
                                                , null
                                                , KhoNhap
                                                , nguoixuat
                                                , idbenhnhantoathuoc
                                                , null
                                                , newSTT
                                                , null
                                                , null
                                                , null
                                                , null
                                                , null
                                                , null
                                                , null
                                                , null
                                                , null
                                                , null
                                                , idbenhnhan
                                                , IdKhamBenh1
                                                , IdPhieuYC
                                                , SOPHIEUYC);

        if (sidphieuxuat == null)
        {
            DataAcess.Connect.RollBack();
            return 0;
        }
        int idphieuxuat = int.Parse(sidphieuxuat);
        for (int i = 0; i < listthuoc.Rows.Count; i++)
        {

            string iSLXuat = (listthuoc.Columns.IndexOf("soluong") != -1 ? listthuoc.Rows[i]["soluong"].ToString() : listthuoc.Rows[i]["soluongke"].ToString());
            if (listthuoc.Columns.IndexOf("SLXuat1") != -1)
                iSLXuat = listthuoc.Rows[i]["SLXuat1"].ToString();
            float n = (float)StaticData.ParseFloat(iSLXuat);
            string sqlSaveChiTietPhieuXuatKho = @"
                    EXEC  Thuoc_XuatThuoc_Automatic_2209 "
                                                    + listthuoc.Rows[i]["IdThuoc"].ToString()
                                                    + "," + "'" + ngaychungtu + "'"
                                                    + "," + n.ToString()
                                                    + "," + idkho
                                                    + "," + idphieuxuat.ToString()
                                                    + "," + "NULL"
                                                    + "," + (dtThuoc.Columns.IndexOf("IdChiTietPhieuYC") != -1 ? listthuoc.Rows[i]["IdChiTietPhieuYC"].ToString() : "NULL")
                                                    + "," + IdKhamBenh1
                                                    + "," + (dtThuoc.Columns.IndexOf("IDCHITIETBENHNHANTOATHUOC") != -1 ? listthuoc.Rows[i]["IDCHITIETBENHNHANTOATHUOC"].ToString() : "NULL");
            bool ok_ChiTiet = DataAcess.Connect.ExecSQL(sqlSaveChiTietPhieuXuatKho);
            if (!ok_ChiTiet)
            {
                DataAcess.Connect.RollBack();
                return -1;
            }
        }

        DataAcess.Connect.Commit();
        return idphieuxuat;
    }
    #endregion
    #region Not Used try
    //#region luuthongtinkhachhang
    public static int luuthongtinkhachhang(int idbenhnhan, string makhachhang, string tenkhachhang, string diachi, string dienthoai, int gioitinh, string ngaysinh)
    {
        string sqlTest = "SELECT * FROM KHACHHANG WHERE IDBENHNHAN=" + idbenhnhan.ToString() + "";
        DataTable dt1 = DataAcess.Connect.GetTable(sqlTest);
        if (dt1 == null) return -1;
        if (dt1.Rows.Count > 0)
            return int.Parse(dt1.Rows[0][0].ToString());
        string sql = @"insert khachhang(
                IdBenhNhan
                ,makhachhang
                ,tenkhachhang
                ,diachi
                ,dienthoai
                ,gioitinh
                ,ngaysinh)
 values(" + idbenhnhan + ", '" + makhachhang + "', N'" + tenkhachhang + "', N'" + diachi + "', '" + dienthoai + "', " + gioitinh + ", '" + StaticData.CheckDate(ngaysinh) + "')";
        bool OK = DataAcess.Connect.ExecSQL(sql);
        int i = 0;
        if (OK)
        {
            DataTable dt = DataAcess.Connect.GetTable("select top 1 idkhachhang from KhachHang order by idkhachhang DESC");
            if (dt != null && dt.Rows.Count > 0)
            {
                i = StaticData.ParseInt(dt.Rows[0]["idkhachhang"]);
            }
        }
        return i;
    }
    //#endregion
    //#region Lưu thông tin khách hàng 2
    //private static int luuthongtinkhachhang(int idbenhnhan, string tenkhachhang, string diachi, string dienthoai, int gioitinh, string ngaysinh, string ngaychungtu)
    //{
    //    string makhachhang = null;
    //    string sqlTest = "SELECT * FROM KHACHHANG WHERE IDBENHNHAN=" + idbenhnhan.ToString() + "";
    //    DataTable dt1 = DataAcess.Connect.GetTable(sqlTest);
    //    if (dt1 == null) return -1;
    //    if (dt1.Rows.Count > 0)
    //        return int.Parse(dt1.Rows[0][0].ToString());
    //    string sqlBenhNhan = "SELECT * FROM BENHNHAN WHERE IDBENHNHAN='" + idbenhnhan + "'";
    //    DataTable dtBenhNhan = DataAcess.Connect.GetTable(sqlBenhNhan);
    //    if (dtBenhNhan == null) return 0;
    //    if (dtBenhNhan.Rows.Count > 0)
    //    {
    //        tenkhachhang = dtBenhNhan.Rows[0]["tenbenhnhan"].ToString();
    //        diachi = dtBenhNhan.Rows[0]["diachi"].ToString();
    //        dienthoai = dtBenhNhan.Rows[0]["dienthoai"].ToString();
    //        gioitinh = int.Parse(dtBenhNhan.Rows[0]["gioitinh"].ToString());
    //        ngaysinh = dtBenhNhan.Rows[0]["ngaysinh"].ToString();
    //        makhachhang = dtBenhNhan.Rows[0]["MaBenhNhan"].ToString();
    //    }
    //    else
    //        makhachhang = StaticData.TaoMaSoPhieu("KH", "KhachHang", "makhachhang", "getdate()", ngaychungtu.Substring(5, 2), "idkhachhang");

    //    string sql = "insert khachhang(IdBenhNhan,makhachhang,tenkhachhang,diachi,dienthoai,gioitinh,ngaysinh) values(" + idbenhnhan + ", '" + makhachhang + "', N'" + tenkhachhang + "', N'" + diachi + "', '" + dienthoai + "', " + gioitinh + ", '" + StaticData.CheckDate(ngaysinh) + "')";
    //    bool OK = DataAcess.Connect.ExecSQL(sql);
    //    int i = 0;
    //    if (OK)
    //    {
    //        DataTable dt = DataAcess.Connect.GetTable("select top 1 idkhachhang from KhachHang order by idkhachhang DESC");
    //        if (dt != null && dt.Rows.Count > 0)
    //        {
    //            i = StaticData.ParseInt(dt.Rows[0]["idkhachhang"]);
    //        }
    //    }
    //    return i;
    //}
    //#endregion
    #endregion
    #region Luu Phieu Xuat
    private static string InsertPhieuXuatKho(
              string smaphieuxuat
            , string sngaythang
            , string sghichu
            , string sidphongkhambenh
            , string snguoinhan
            , string sxuatcho
            , string sidkho
            , string sloaixuat
            , string sIDKhachHang
            , string svat
            , string sthanhtien
            , string sngayhoadon
            , string sidnhacungcap
            , string sidkho2
            , string sidnguoixuat
            , string sIdBenhNhanToaThuoc
            , string sIsBHYT
            , string sSLPX
            , string stkNo
            , string sTKVAT
            , string sTKCo
            , string sIdCaPhauThuat
            , string sIsDaHuy
            , string sLANSUA
            , string sMaPhieu
            , string sNGAYSUA
            , string sNGUOISUA
            , string sIdLoaiThuoc
            , string sIdBenhNhan
            , string sIDKHAMBENH1
            , string sIDPHIEUYC
            , string sSOPHIEUYC
            )
    {
        string tem_smaphieuxuat = DataAcess.hsSqlTool.sGetSaveValue(smaphieuxuat, "varchar");
        string tem_sngaythang = DataAcess.hsSqlTool.sGetSaveValue(sngaythang, "datetime");
        string tem_sghichu = DataAcess.hsSqlTool.sGetSaveValue(sghichu, "nvarchar");
        string tem_sidphongkhambenh = DataAcess.hsSqlTool.sGetSaveValue(sidphongkhambenh, "smallint");
        string tem_snguoinhan = DataAcess.hsSqlTool.sGetSaveValue(snguoinhan, "nvarchar");
        string tem_sxuatcho = DataAcess.hsSqlTool.sGetSaveValue(sxuatcho, "tinyint");
        string tem_sidkho = DataAcess.hsSqlTool.sGetSaveValue(sidkho, "int");
        string tem_sloaixuat = DataAcess.hsSqlTool.sGetSaveValue(sloaixuat, "int");
        string tem_sIDKhachHang = DataAcess.hsSqlTool.sGetSaveValue(sIDKhachHang, "int");
        string tem_svat = DataAcess.hsSqlTool.sGetSaveValue(svat, "float");
        string tem_sthanhtien = DataAcess.hsSqlTool.sGetSaveValue(sthanhtien, "float");
        string tem_sngayhoadon = DataAcess.hsSqlTool.sGetSaveValue(sngayhoadon, "datetime");
        string tem_sidnhacungcap = DataAcess.hsSqlTool.sGetSaveValue(sidnhacungcap, "int");
        string tem_sidkho2 = DataAcess.hsSqlTool.sGetSaveValue(sidkho2, "int");
        string tem_sidnguoixuat = DataAcess.hsSqlTool.sGetSaveValue(sidnguoixuat, "int");
        string tem_sIdBenhNhanToaThuoc = DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhanToaThuoc, "int");
        string tem_sIsBHYT = DataAcess.hsSqlTool.sGetSaveValue(sIsBHYT, "bit");
        string tem_sSLPX = DataAcess.hsSqlTool.sGetSaveValue(sSLPX, "bigint");
        string tem_stkNo = DataAcess.hsSqlTool.sGetSaveValue(stkNo, "bigint");
        string tem_sTKVAT = DataAcess.hsSqlTool.sGetSaveValue(sTKVAT, "bigint");
        string tem_sTKCo = DataAcess.hsSqlTool.sGetSaveValue(sTKCo, "bigint");
        string tem_sIdCaPhauThuat = DataAcess.hsSqlTool.sGetSaveValue(sIdCaPhauThuat, "bigint");
        string tem_sIsDaHuy = DataAcess.hsSqlTool.sGetSaveValue(sIsDaHuy, "bit");
        string tem_sLANSUA = DataAcess.hsSqlTool.sGetSaveValue(sLANSUA, "int");
        string tem_sMaPhieu = DataAcess.hsSqlTool.sGetSaveValue(sMaPhieu, "nvarchar");
        string tem_sNGAYSUA = DataAcess.hsSqlTool.sGetSaveValue(sNGAYSUA, "datetime");
        string tem_sNGUOISUA = DataAcess.hsSqlTool.sGetSaveValue(sNGUOISUA, "bigint");
        string tem_sIdLoaiThuoc = DataAcess.hsSqlTool.sGetSaveValue(sIdLoaiThuoc, "bigint");
        string tem_sIdBenhNhan = DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhan, "bigint");
        string tem_sIDKHAMBENH1 = DataAcess.hsSqlTool.sGetSaveValue(sIDKHAMBENH1, "bigint");
        string tem_sIDPHIEUYC = DataAcess.hsSqlTool.sGetSaveValue(sIDPHIEUYC, "bigint");
        string tem_sSOPHIEUYC = DataAcess.hsSqlTool.sGetSaveValue(sSOPHIEUYC, "nvarchar");

        string sqlSave = " INSERT INTO phieuxuatkho(" +
                                        "maphieuxuat,"
                                       + "ngaythang,"
                                       + "ghichu,"
                                       + "idphongkhambenh,"
                                       + "nguoinhan,"
                                       + "xuatcho,"
                                       + "idkho,"
                                       + "loaixuat,"
                                       + "IDKhachHang,"
                                       + "vat,"
                                       + "thanhtien,"
                                       + "ngayhoadon,"
                                       + "idnhacungcap,"
                                       + "idkho2,"
                                       + "idnguoixuat,"
                                       + "IdBenhNhanToaThuoc,"
                                       + "IsBHYT,"
                                       + "SLPX,"
                                       + "tkNo,"
                                       + "TKVAT,"
                                       + "TKCo,"
                                       + "IdCaPhauThuat,"
                                       + "IsDaHuy,"
                                       + "LANSUA,"
                                       + "MaPhieu,"
                                       + "NGAYSUA,"
                                       + "NGUOISUA,"
                                       + "IdLoaiThuoc,"
                                       + "IdBenhNhan,"
                                       + "IDKHAMBENH1,"
                                       + "IDPHIEUYC,"
                                       + "SOPHIEUYC) VALUES("
                            + tem_smaphieuxuat + ","
                            + tem_sngaythang + ","
                            + tem_sghichu + ","
                            + tem_sidphongkhambenh + ","
                            + tem_snguoinhan + ","
                            + tem_sxuatcho + ","
                            + tem_sidkho + ","
                            + tem_sloaixuat + ","
                            + tem_sIDKhachHang + ","
                            + tem_svat + ","
                            + tem_sthanhtien + ","
                            + tem_sngayhoadon + ","
                            + tem_sidnhacungcap + ","
                            + tem_sidkho2 + ","
                            + tem_sidnguoixuat + ","
                            + tem_sIdBenhNhanToaThuoc + ","
                            + tem_sIsBHYT + ","
                            + tem_sSLPX + ","
                            + tem_stkNo + ","
                            + tem_sTKVAT + ","
                            + tem_sTKCo + ","
                            + tem_sIdCaPhauThuat + ","
                            + tem_sIsDaHuy + ","
                            + tem_sLANSUA + ","
                            + tem_sMaPhieu + ","
                            + tem_sNGAYSUA + ","
                            + tem_sNGUOISUA + ","
                            + tem_sIdLoaiThuoc + ","
                            + tem_sIdBenhNhan + ","
                            + tem_sIDKHAMBENH1 + ","
                            + tem_sIDPHIEUYC + ","
                            + tem_sSOPHIEUYC + ")";
        bool OK =DataAcess.Connect.Exec(sqlSave) >= 1 ? true : false;
        if (OK)
        {
            string newphieuxuatkho =DataAcess.Connect.GetTable(" SELECT TOP 1 idphieuxuat FROM phieuxuatkho ORDER BY idphieuxuat DESC ").Rows[0][0].ToString();
            return newphieuxuatkho;
        }
        else return null;
    }
    #endregion
    #region XuatTheoToa
    public static void XuatTheoToa(System.Web.UI.Page currentPage, string IDKHAMBENH        )
    {
        XuatTheoToa(currentPage, IDKHAMBENH, null);
    }
    public static void XuatTheoToa(System.Web.UI.Page currentPage, string IDKHAMBENH,string IDKHOXUAT)
    {
        string sqlCheck = "SELECT DBO.HS_ISDAXUATTOATHUOC('" + IDKHAMBENH + "')";
        if(IDKHOXUAT!=null &&IDKHOXUAT!="")
            sqlCheck = "SELECT DBO.HS_ISDAXUATTOATHUOC_ByKho('" + IDKHAMBENH + "',"+IDKHOXUAT+")";

        if (currentPage != null)
        {
            string AllowXuatLai = null;
            AllowXuatLai = currentPage.Request.QueryString["AllowXuatLai"];
            DataTable dtCheck = DataAcess.Connect.GetTable(sqlCheck);
            if (dtCheck != null && dtCheck.Rows.Count > 0 && StaticData.IsCheck(dtCheck.Rows[0][0].ToString()) && AllowXuatLai != "1")
            {
                currentPage.Response.Clear();
                currentPage.Response.Write("2");
                return;
            }
        }
        string sqlDeletePX = " EXEC HS_DELETE_PHIEUXUAT " + IDKHAMBENH;
        string sqlSavePX = " EXEC THUOC_XUATTOATHUOC " + IDKHAMBENH;

        if (IDKHOXUAT != null && IDKHOXUAT != "")
        {
              sqlDeletePX = " EXEC HS_DELETE_PHIEUXUAT_ByKho " + IDKHAMBENH +","+IDKHOXUAT;
             sqlSavePX = " EXEC THUOC_XUATTOATHUOC_ByKho " + IDKHAMBENH +","+IDKHOXUAT;
        }
        bool ok_delete = DataAcess.Connect.ExecSQL(sqlDeletePX);
        bool ok_Save = DataAcess.Connect.ExecSQL(sqlSavePX);

        if (!ok_Save)
        {
            if (currentPage != null)
            {
                currentPage.Response.Clear();
                currentPage.Response.Write("0");
            }
            return;
        }
        else
        {
            StaticData.TinhLaiTien_ByIdKhamBenh(IDKHAMBENH);
            if (currentPage != null)
            {
                currentPage.Response.Clear();
                currentPage.Response.Write("1");
            }

            //ke toan 
//            #region ke toan
//            string mact = "";
//            string ngayct = "";
//            string diengiai = "";
//            string tkchiphi = "";
//            string tkkho = "";
//            double thanhtien = 0;
//            string sql1 = "";
//            string sql = @"select a.maphieuxuat,ngaythang=convert(varchar(10),a.ngaythang,111)
//            ,ghichu = N'Chi phí '+c.tenphongkhambenh
//            ,c.tkchiphi
//            ,tkkho= case when d.tkkho is null then (case when d.loaithuocid= 1 then '15211' else case when d.loaithuocid=4 then '15212' else case when d.loaithuocid=2 then '15213'end end end ) else d.tkkho end
//            ,thanhtien=sum(isnull(b.tiensauchietkhau,0))+ sum(isnull(b.tienthue,0)) 
//            from phieuxuatkho a inner join chitietphieuxuatkho b on a.idphieuxuat=b.idphieuxuat left join phongkhambenh c on a.idphongkhambenh=c.idphongkhambenh
//            left join thuoc d on b.idthuoc=d.idthuoc
//            where a.idkhambenh1=" + IDKHAMBENH + @" group by a.maphieuxuat,convert(varchar(10),a.ngaythang,111),b.ghichu,c.tkchiphi,d.tkkho,d.loaithuocid,c.tenphongkhambenh
//            ";

//            DataTable dt = DataAcess.Connect.GetTable(sql);
//            if (dt.Rows.Count > 0 && dt != null)
//            {
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    mact = dt.Rows[i][0].ToString();
//                    ngayct = dt.Rows[i][1].ToString();
//                    diengiai = dt.Rows[i][2].ToString();
//                    tkchiphi = dt.Rows[i][3].ToString();
//                    tkkho = dt.Rows[i][4].ToString();
//                    thanhtien = double.Parse(dt.Rows[i][5].ToString());
//                    sql1 = "Exec spChiPhiKhoa_SoCai_Save '" + mact + "','" + ngayct + "',N'" + diengiai + "','" + tkchiphi + "','" + tkkho + "'," + thanhtien + ",'" + "" + "','" + "" + "'";
//                    DataAcess.Connect.ExecSQL(sql1);
//                }

//            }
//            #endregion ketoan
            //end ke toan
        }
    }
     
    public static void XuatTheoToa(System.Web.UI.Page currentPage)
    {
        string IDKHAMBENH = currentPage.Request.QueryString["IDKHAMBENH"].ToString();
        XuatTheoToa(currentPage, IDKHAMBENH);
    }
    public static void XuatTheoToa_VTYT(System.Web.UI.Page currentPage, string IDKHAMBENH, ref bool IsHavetinhlaitien)
    {
        string sqlCheck = "SELECT DBO.HS_ISDAXUATTOATHUOC_VTYT('" + IDKHAMBENH + "')";

        if (currentPage != null)
        {
            string AllowXuatLai = null;
            AllowXuatLai = currentPage.Request.QueryString["AllowXuatLai"];
            DataTable dtCheck = DataAcess.Connect.GetTable(sqlCheck);
            if (dtCheck != null && dtCheck.Rows.Count > 0 && StaticData.IsCheck(dtCheck.Rows[0][0].ToString()) && AllowXuatLai != "1")
            {
                currentPage.Response.Clear();
                currentPage.Response.Write("2");
                return;
            }
        }

        bool ok_delete = DataAcess.Connect.ExecSQL(" EXEC HS_DELETE_PHIEUXUAT_VTYT " + IDKHAMBENH);
        bool ok_Save = DataAcess.Connect.ExecSQL(" EXEC THUOC_XUATTOATHUOC_VTYT " + IDKHAMBENH);

        if (!ok_Save)
        {
            if (currentPage != null)
            {
                currentPage.Response.Clear();
                currentPage.Response.Write("0");
            }
            return;
        }
        else
        {
            string IdKhoa = currentPage.Request.QueryString["idkhoa"];
            string LoaiKhamID = currentPage.Request.QueryString["loaidk"];
            if (IdKhoa == "1" && LoaiKhamID != "1")
            {
            }
            else
            {
                StaticData.TinhLaiTien_ByIdKhamBenh(IDKHAMBENH);
               
            }
            IsHavetinhlaitien = true;
            if (currentPage != null)
            {
                currentPage.Response.Clear();
                currentPage.Response.Write("1");
            }

        }
    }


    public static void XuatTheoToa_VTYT(System.Web.UI.Page currentPage, ref bool IsHavetinhlaitien)
    {
        string IDKHAMBENH = currentPage.Request.QueryString["IDKHAMBENH"].ToString();
        XuatTheoToa_VTYT(currentPage, IDKHAMBENH, ref IsHavetinhlaitien);
    }
    #endregion
}//end class

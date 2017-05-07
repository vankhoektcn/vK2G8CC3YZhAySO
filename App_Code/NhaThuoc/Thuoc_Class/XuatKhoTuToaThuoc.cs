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
/// Summary description for XuatKhoTuToaThuoc
/// </summary>
public class XuatKhoTuToaThuoc
{
    public XuatKhoTuToaThuoc()
    {
        //
        // TODO: Add constructor logic here
        //
    }
//    private static  int luuthongtinkhachhang(int idbenhnhan, string makhachhang, string tenkhachhang, string diachi, string dienthoai, int gioitinh, string ngaysinh)
//    {
//        string sqlTest = "SELECT * FROM KHACHHANG WHERE IDBENHNHAN=" + idbenhnhan.ToString() + "";
//        DataTable dt1 = DataAcess.Connect.GetTable(sqlTest);
//        if (dt1 == null) return -1;
//        if (dt1.Rows.Count > 0)
//            return int.Parse(dt1.Rows[0][0].ToString());
//        string sql = @"insert khachhang(IdBenhNhan,
//                            makhachhang,
//                            tenkhachhang,
//                            diachi,
//                            dienthoai,
//                            gioitinh,
//                            ngaysinh
//                                    ) 
//                            values(" + idbenhnhan + ", '" + makhachhang + "', N'" + tenkhachhang + "', N'" + diachi + "', '" + dienthoai + "', " + gioitinh + ", '" + StaticData.CheckDate(ngaysinh) + "')";
//        bool OK = DataAcess.Connect.ExecSQL(sql);
        
//        int i = 0;
//        if (OK)
//        {
//            DataTable dt = DataAcess.Connect.GetTable("select top 1 idkhachhang from KhachHang order by idkhachhang DESC");
//            if (dt != null && dt.Rows.Count > 0)
//            {
//                i = StaticData.ParseInt(dt.Rows[0]["idkhachhang"]);
//            }
//        }
//        return i;
//    }
    //private static  int SavePhieuXuatKho(string maphieuxuat
    //                                    ,string ngaythang
    //                                    , string ghichu
    //                                    , string idkho
    //                                    , string loaixuat
    //                                    , int idkhachhang
    //                                    , string thue
    //                                    , int tongthanhtien
    //                                    , string ngayhoadon
    //                                    , int idkhoxuat
    //                                    , string idnguoixuat
    //                                    , int idnhacungcap
    //                                    ,string IdBenNhanToaThuoc
    //                                    )
    //{
        
    //    DataTable dttemp = Process_2608.phieuxuatkho.dtSearchBymaphieuxuat(maphieuxuat);
    //    if (dttemp.Rows.Count > 0)
    //    {
    //        Process.phieuxuatkho_duoc temp = new Process.phieuxuatkho_duoc(dttemp.DefaultView, 0);
    //        bool ok = temp.Save_Object(maphieuxuat,
    //                          ngaythang,
    //                          ghichu,
    //                          "0",
    //                          "0",
    //                          "0",
    //                          idkho,
    //                          loaixuat,
    //                          idkhachhang.ToString(),
    //                         "0",
    //                          "0",
    //                          ngayhoadon,
    //                         "",
    //                         "",
    //                         idnguoixuat,
    //                         IdBenNhanToaThuoc,null
    //                         );
    //        if (ok) return int.Parse( temp.idphieuxuat);
    //        return -1;
    //    }
    //    else
    //    {
    //        Process.phieuxuatkho_duoc newPXK = Process.phieuxuatkho_duoc.Insert_Object(
    //                            maphieuxuat,
    //                           ngaythang,
    //                           ghichu,
    //                           "0",
    //                           "0",
    //                           "0",
    //                           idkho,
    //                           loaixuat,
    //                           idkhachhang.ToString(),
    //                           "0",
    //                           "0",
    //                           ngayhoadon,
    //                          "0",
    //                          "0",
    //                          idnguoixuat,
    //                          IdBenNhanToaThuoc,null
    //                          );
    //        if (newPXK != null)
    //            return  int.Parse( newPXK.idphieuxuat);
    //        return -1;
    //    }

    //}
    public static void XuatKhoTheoToa_1907(string idbenhnhan, string IdKhamBenh, string IdNguoiXuat)
    {
        myInsertPhieuXuatKho.XuatTheoToa(null,IdKhamBenh);
        #region Old Code Not Used
        //        string sThuocNotInput = "";
//        string ngayxuattoa = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//        string ngaychungtu = ngayxuattoa;
//        string maphieuxuat = null;
//        string newSTT = "";
//        if (StaticData.OutputCodeIsNumber)
//            maphieuxuat = StaticData.NewOutputCode;
//        else
//            maphieuxuat = myInsertPhieuXuatKho.TaoSoPhieuXuat(ngaychungtu, ref newSTT);
//        string sqlbn = "select * from benhnhan where idbenhnhan = " + idbenhnhan;
//        DataTable dtbn = DataAcess.Connect.GetTable(sqlbn);

//        string tenkhachhang = dtbn.Rows[0]["TenBenhNhan"].ToString();
//        string diachi = dtbn.Rows[0]["DiaChi"].ToString();
//        string LoaiBN = dtbn.Rows[0]["Loai"].ToString();
//        string makhachhang = StaticData.TaoMaSoPhieu("KH", "KhachHang", "makhachhang", "getdate()", ngaychungtu.Substring(5, 2), "idkhachhang");
//        int idkhachhang = luuthongtinkhachhang(StaticData.ParseInt(idbenhnhan), makhachhang, tenkhachhang, diachi, dtbn.Rows[0]["dienthoai"].ToString(), StaticData.ParseInt(dtbn.Rows[0]["gioitinh"]), dtbn.Rows[0]["ngaysinh"].ToString());
//        string nguoixuat = IdNguoiXuat;
//        string ghichu = null;
//        string thue = null;
//        string loaixuat = "2";

//        #region dtKhoXuat (không xuất từ kho bệnh nhân)
//        DataTable dt_nvkKho = DataAcess.Connect.GetTable("SELECT DISTINCT IDKHO FROM CHITIETBENHNHANTOATHUOC WHERE IdKhamBenh='" + IdKhamBenh + "' and idkho not in ( select idkho from khothuoc where nvk_loaikho=3 )");
//        if (dt_nvkKho == null || dt_nvkKho.Rows.Count == 0)
//            return;
//        #endregion
//        #region nvk phiếu xuất theo từng kho
//        for (int k = 0; k < dt_nvkKho.Rows.Count; k++)
//        {
//            string idkho = dt_nvkKho.Rows[k]["IDKHO"].ToString();
//            string sql = "select t.idthuoc,ct.idchitietbenhnhantoathuoc,t.tenthuoc, t.donvitinh,t.iddvt,ThanhTien=0 ,";
//            sql += " ct.soluongke, ct.soluongbanra,ct.soluongbanra as soluongconlai,HeSo=Isnull(Heso,0) ";
//            sql += ",sudungchobh=dbo.kb_IsThucSDBHYT(T.idthuoc) \r\n";
//            sql += @" from chitietbenhnhantoathuoc ct 
//                    left join thuoc t      on ct.idthuoc = t.idthuoc 
//                    LEFT JOIN khambenh A ON CT.idkhambenh=A.idkhambenh
//                    LEFT JOIN  BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN";
//            sql += @" where ct.idkho='" + idkho + @"' --and dbo.THUOC_ISDAXUAT_TOA(ct.idchitietbenhnhantoathuoc)=0 and   T.LOAITHUOCID=1
//                    AND  ct.idkhambenh = " + IdKhamBenh;
//            string LoaiKhamClause = "";
//            //if (this.IsBHYT)
//            //    LoaiKhamClause = " AND dbo.kb_IsThucSDBHYT(T.idthuoc)=1";
//            //else
//            //    LoaiKhamClause = " AND (B.Loai<>1 Or ( B.Loai=1 and  dbo.kb_IsThucSDBHYT(T.idthuoc)=0))";
//            sql += LoaiKhamClause;
//            DataTable listthuoc = DataAcess.Connect.GetTable(sql);
//            int tongtien = 0;
//            DataAcess.Connect.BeginTran();
//            int idphieuxuat = 0;
//            string listIdCTBNTT = "";
//            for (int j = 0; j < listthuoc.Rows.Count; j++)
//                listIdCTBNTT += "" + listthuoc.Rows[j]["idchitietbenhnhantoathuoc"].ToString()+",";
//            listIdCTBNTT = listIdCTBNTT.TrimEnd(',');
//            string sqlDaXuat = @"select * from chitietphieuxuatkho where idchitietbenhnhantoathuoc in(" + listIdCTBNTT + ") and idphieuxuat in(select idphieuxuat from phieuxuatkho where idkho ='" + idkho + "')";
//            DataTable dt_nvkDaXuat = DataAcess.Connect.GetTable(sqlDaXuat);
//            if (dt_nvkDaXuat != null && dt_nvkDaXuat.Rows.Count > 0)
//                idphieuxuat = StaticData.ParseInt(dt_nvkDaXuat.Rows[0]["idphieuxuat"]);
//            else
//                idphieuxuat = SavePhieuXuatKho(maphieuxuat, ngaychungtu, ghichu, idkho, loaixuat, idkhachhang, thue, tongtien, ngaychungtu, 0, nguoixuat, 0, IdKhamBenh);

//            if (idphieuxuat == 0 || idphieuxuat == -1)
//            {
//                return;
//            }
//            string sqlParameter = "SELECT   ThuTuXuat=(SELECT ParaValue FROM KB_Parameter WHERE ParaName='ThuTuXuat')"
//                                    + ",LoaiGia=(SELECT ParaValue FROM KB_Parameter WHERE ParaName='LoaiGia')";
//            string ThuTuXuat = "ngayhethan";
//            string LoaiGia = "1";
//            DataTable dtParameter = DataAcess.Connect.GetTable(sqlParameter);
//            if (dtParameter != null && dtParameter.Rows.Count > 0)
//            {
//                ThuTuXuat = dtParameter.Rows[0]["ThuTuXuat"].ToString();
//                if (ThuTuXuat == "1") ThuTuXuat = "B.NgayThang";
//                else if (ThuTuXuat == "2") ThuTuXuat = "A.NgayHetHan";
//                LoaiGia = dtParameter.Rows[0]["LoaiGia"].ToString();
//            }

//            for (int i = 0; i < listthuoc.Rows.Count; i++)
//            {
//                #region xóa chitietphieuxuatkho nếu đã xuất ==> xuất lại
//                bool nvkXoa = DataAcess.Connect.ExecSQL("delete from chitietphieuxuatkho where idphieuxuat='" + idphieuxuat + "' and idchitietbenhnhantoathuoc='" + listthuoc.Rows[i]["idchitietbenhnhantoathuoc"] + "'");
//                #endregion
//                string updatebnt = "update chitietbenhnhantoathuoc set quaythuocxoa=1 where idchitietbenhnhantoathuoc=" + listthuoc.Rows[i]["idchitietbenhnhantoathuoc"];
//                bool bnt = DataAcess.Connect.ExecSQL(updatebnt);
//                if (bnt == false)
//                {
//                    //Response.Write(0);//Lưu phiếu xuất thất bại
//                    DataAcess.Connect.RollBack();
//                    return;
//                }
//                string idthuoc = listthuoc.Rows[i]["idthuoc"].ToString();
//                string sqldspn = @" select GIABANDV=A.DONGIA*((100.0+ ISNULL(A.VAT,0))/100)
//                            ,A.*  
//                            ,GiaAp=A.DONGIA*((100.0+ ISNULL(A.VAT,0))/100)
//                            ,soluongton=(A.soluong- DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)  ) 
//                            ,giabh    =A.DONGIA*((100.0+ ISNULL(A.VAT,0))/100)
//                            from chitietphieunhapkho A";
//                sqldspn += " left join phieunhapkho B on A.idphieunhap=B.idphieunhap";
//                sqldspn += " left join THUOC  C on A.IDTHUOC=C.IDTHUOC";
//                sqldspn += " where B.IDKHO=" + idkho + " AND  A.idthuoc=" + idthuoc;
//                sqldspn += " and A.soluong>DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)";
//                sqldspn += " and B.ngaythang<=" + "'" + ngayxuattoa + "'";

//                sqldspn += " order by " + ThuTuXuat; ;
//                int m = 0;
//                int n = StaticData.ParseInt(listthuoc.Rows[i]["soluongke"].ToString());
//                DataTable dtthuoc = DataAcess.Connect.GetTable(sqldspn);
//                if (dtthuoc == null || dtthuoc.Rows.Count == 0)
//                    sThuocNotInput += listthuoc.Rows[i]["tenthuoc"].ToString() + "\r\n";

//                for (int j = 0; idthuoc != "" && j < dtthuoc.Rows.Count; j++)
//                {

//                    int slt = StaticData.ParseInt(dtthuoc.Rows[j]["soluongton"].ToString());
//                    if (n >= slt) m = slt;
//                    else
//                        m = n;
//                    string updatectpn = "update chitietphieunhapkho set soluongxuat =(soluongxuat+ " + m + ") where idchitietphieunhapkho=" + dtthuoc.Rows[j]["idchitietphieunhapkho"].ToString();
//                    bool tpn = DataAcess.Connect.ExecSQL(updatectpn);
//                    if (!tpn)
//                    {
//                        DataAcess.Connect.RollBack();
//                        //Response.Write(0);//Lưu phiếu xuất thất bại
//                        return;
//                    }

//                    string GiaDV_Name = "GiaBanDV";
//                    if (dtthuoc.Rows[j]["GiaAp"].ToString() != "" && dtthuoc.Rows[j]["GiaAp"].ToString() != "0")
//                        GiaDV_Name = "GiaAp";

//                    string DonGiaName = GiaDV_Name;
//                    if (LoaiBN != "1") DonGiaName = GiaDV_Name;
//                    else
//                    {

//                        string sudungchobh = listthuoc.Rows[i]["sudungchobh"].ToString();
//                        if (sudungchobh == "1" || sudungchobh == "true" || sudungchobh == "True")
//                            DonGiaName = "giabh";
//                        else
//                            DonGiaName = GiaDV_Name;

//                    }

//                    float giavon = StaticData.ParseFloat(dtthuoc.Rows[j][DonGiaName].ToString());
//                    float giaban = giavon;
//                    float thanhtien = m * giaban;
//                    float thanhtientruocthue = m * giaban;
//                    string sVAT = "0";
//                    if (sVAT == "") sVAT = "0";
//                    float VAT = float.Parse(sVAT);
//                    if (sVAT == "") sVAT = "0";
//                    float tienthue = (thanhtientruocthue * VAT) / 100;

//                    string sCK = listthuoc.Rows[i]["HeSo"].ToString();
//                    if (sCK == "") sCK = "0";
//                    float chietkhau = float.Parse(sCK);
//                    float tienvon = m * giavon;

//                    string luuctphieuxuat ="";
//                    //if (dt_nvkDaXuat != null && dt_nvkDaXuat.Rows.Count > 0)
//                    //{
//                    //    luuctphieuxuat = @"update chitietphieuxuatkho set idthuoc=" + idthuoc + ",soluong=" + m + ",dongia=" + giaban + @" where idchitietphieuxuat='" + dtDaXuat.Rows[0]["idchitietphieuxuat"] + "'";
//                    //}
//                    //else
//                    //{
//                    luuctphieuxuat = "insert chitietphieuxuatkho(idphieuxuat, idthuoc, soluong, dongia, idchitietphieunhapkho, idtu, idngan, sluongxuat, dvt, thanhtien, thanhtientruocthue, tienthue, chietkhau, giavon, tienvon,IdChiTietBenhNhanToaThuoc) ";
//                    luuctphieuxuat += " values(" + idphieuxuat + ", " + idthuoc + ", " + m + ", " + giaban + ", ";
//                    luuctphieuxuat += " " + dtthuoc.Rows[j]["idchitietphieunhapkho"].ToString() + ", " + (dtthuoc.Rows[j]["idtu"].ToString() != "" ? dtthuoc.Rows[j]["idtu"].ToString() : "0") + ", " + (dtthuoc.Rows[j]["idngan"].ToString() != "" ? dtthuoc.Rows[j]["idngan"].ToString() : "0") + ", " + m + ", ";
//                    luuctphieuxuat += " '" + dtthuoc.Rows[j]["dvt"].ToString() + "', " + thanhtien + ", " + thanhtientruocthue + ", " + tienthue + ", " + chietkhau + " , " + giavon + ", " + tienvon + "," + listthuoc.Rows[i]["idchitietbenhnhantoathuoc"] + ") ";
//                    //}
//                    bool luu = DataAcess.Connect.ExecSQL(luuctphieuxuat);
//                    if (!luu)
//                    {
//                        DataAcess.Connect.RollBack();
//                        //Response.Write(0);//Lưu phiếu xuất thất bại
//                        return;
//                    }

//                    bool ok_ChiTietBenhNhanToathuoc = DataAcess.Connect.ExecSQL("UPDATE CHITIETBENHNHANTOATHUOC SET THANHTIEN=ISNULL(THANHTIEN,0)+ " + thanhtien.ToString() + " WHERE IDCHITIETBENHNHANTOATHUOC=" + listthuoc.Rows[i]["IdChiTietBenhNhanToaThuoc"].ToString());


//                    if (n - slt <= 0) break;
//                    else n -= slt;
//                }//end for 1.1
//            }
//        }
        //        #endregion 
        #endregion
    }
//    public static  void XuatKhoTheoToa(string idbenhnhan,  string IdKhamBenh, string IdNguoiXuat )
//    {
//        #region Chuẩn bị tham số chung
//        string ngaychungtu = DataAcess.Connect.GetTable("SELECT convert(varchar(10),NGAYKHAM,126) FROM KHAMBENH WHERE IDKHAMBENH=" + IdKhamBenh).Rows[0][0].ToString();
//        //nvk không xuất nếu thuốc chỉ định từ kho ảo
//        #region nvk không xuất nếu thuốc chỉ định từ kho ảo
//        DataTable dtChitietBenhNhanToaThuoc = DataAcess.Connect.GetTable("SELECT DISTINCT IDKHO FROM CHITIETBENHNHANTOATHUOC WHERE IdKhamBenh='" + IdKhamBenh + "' and idkho not in ( select idkho from khothuoc where nvk_loaikho=3 )");
//        #endregion
//        if (dtChitietBenhNhanToaThuoc == null || dtChitietBenhNhanToaThuoc.Rows.Count == 0) return;
//        string maphieuxuat ="";
//        string tenkhachhang = "";
//        string diachi = "";
//        string sqlbn = "select * from benhnhan where idbenhnhan = " + idbenhnhan;
//        DataTable dtbn = DataAcess.Connect.GetTable(sqlbn);
//        string makhachhang = StaticData.TaoMaSoPhieu("KH", "KhachHang", "makhachhang", "getdate()", ngaychungtu.Substring(5, 2), "idkhachhang");
//        tenkhachhang = dtbn.Rows[0]["TenBenhNhan"].ToString();
//        diachi = dtbn.Rows[0]["DiaChi"].ToString();
//        int idkhachhang = luuthongtinkhachhang(StaticData.ParseInt(idbenhnhan), makhachhang, tenkhachhang, diachi, dtbn.Rows[0]["dienthoai"].ToString(), StaticData.ParseInt(dtbn.Rows[0]["gioitinh"]), dtbn.Rows[0]["ngaysinh"].ToString());
//        string nguoixuat ="";
//        if (IdNguoiXuat != null && IdNguoiXuat != "")
//        {
//            DataTable dtNguoiXuat = DataAcess.Connect.GetTable("SELECT TENNGUOIDUNG FROM NGUOIDUNG WHERE IDNGUOIDUNG=" + IdNguoiXuat);
//            if (dtNguoiXuat != null && dtNguoiXuat.Rows.Count > 0)
//                nguoixuat = dtNguoiXuat.Rows[0][0].ToString();
//        }

//        string ghichu = "Xuất cho BN";
//        string thue = "0";
//        string loaixuat = "2";
//        #endregion
//        for (int n_Kho=0;n_Kho<dtChitietBenhNhanToaThuoc.Rows.Count;n_Kho++)
//        {
//            #region Mã phiếu xuất
//        if (StaticData.OutputCodeIsNumber)
//            maphieuxuat = StaticData.NewOutputCode;
//        else
//            maphieuxuat = StaticData.TaoMaSoPhieu("PX", "phieuxuatkho", "maphieuxuat", "ngaythang", ngaychungtu.Substring(5, 2), "idphieuxuat");
//#endregion
//            #region Tách từng chi tiết theo IDKho, 1 IDKho=1 phiếu xuất
//            string idkho=dtChitietBenhNhanToaThuoc.Rows[n_Kho]["IdKho"].ToString();
//            if (idkho == "" || idkho == "0") idkho = "14";
//                string sql = "select t.idthuoc,ct.idchitietbenhnhantoathuoc,t.tenthuoc, t.donvitinh,t.iddvt,ThanhTien=0 ,dongia,";
//                 sql+= " ct.soluongke, ct.soluongbanra, (ct.soluongke - ct.soluongbanra) as soluongconlai,HeSo=Isnull(Heso,0) ";
//                sql += " from chitietbenhnhantoathuoc ct left join thuoc t ";
//                sql += "    on ct.idthuoc = t.idthuoc ";
//                sql += " where ct.IdKhamBenh = " + IdKhamBenh
//                    +" and ct.IdKho="+idkho;
//                 DataTable listthuoc = DataAcess.Connect.GetTable(sql);
//            #endregion
//            #region Lưu Phiếu xuất kho
//                int tongtien = 0;
//                int idphieuxuat = SavePhieuXuatKho(maphieuxuat
//                                                    , ngaychungtu
//                                                    , ghichu
//                                                    , idkho
//                                                    , loaixuat
//                                                    , idkhachhang
//                                                    , thue
//                                                    , tongtien
//                                                    , ngaychungtu
//                                                    , 0
//                                                    , nguoixuat
//                                                    , 0
//                                                    ,IdKhamBenh
//                                                    );
//            #endregion                
//            #region Lấy tham số thứ tự xuất
//            string sqlParameter = "SELECT   ThuTuXuat=(SELECT ParaValue FROM KB_Parameter WHERE ParaName='ThuTuXuat')"
//                                    + ",LoaiGia=(SELECT ParaValue FROM KB_Parameter WHERE ParaName='LoaiGia')";
//            string ThuTuXuat = "ngayhethan";
//            string LoaiGia = "1";
//            DataTable dtParameter = DataAcess.Connect.GetTable(sqlParameter);
//            if (dtParameter != null && dtParameter.Rows.Count > 0)
//            {
//                ThuTuXuat = dtParameter.Rows[0]["ThuTuXuat"].ToString();
//                if (ThuTuXuat == "1") ThuTuXuat = "B.NgayThang";
//                else if (ThuTuXuat == "2") ThuTuXuat = "A.NgayHetHan";
//                LoaiGia = dtParameter.Rows[0]["LoaiGia"].ToString();
//            }
//            #endregion
//            #region Lưu chi tiết phiếu xuất kho
//            for (int i = 0; i < listthuoc.Rows.Count; i++)
//            {
//                #region Lấy danh sách chi tiết phiếu nhập kho đối với từng IdThuốc
//                string idthuoc = listthuoc.Rows[i]["idthuoc"].ToString();
//                string sqldspn = " select A.* ,soluongton=(A.soluong- DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)  )"
//                            + ",DonGiaXuat=(IsNull(A.ThanhTien,0)/Isnull(A.SoLuong,1))"
//                            + " from chitietphieunhapkho A";
//                sqldspn += " left join phieunhapkho B on A.idphieunhap=B.idphieunhap";
//                sqldspn += " where B.IDKHO=" + idkho + " and  IsNull(A.ThanhTien,0)>0 AND  idthuoc=" + idthuoc;
//                sqldspn += " and A.soluong>DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)";
//                sqldspn += " and B.ngaythang<=" + "'" + ngaychungtu + "'";
//                sqldspn += " order by " + ThuTuXuat; ;
//                int m = 0;
//                int n = StaticData.ParseInt(listthuoc.Rows[i]["soluongke"].ToString());
//                #endregion
//                DataTable dtthuoc = DataAcess.Connect.GetTable(sqldspn);
//                #region Lưu từng chitiết phiếu xuất kho tương ứng với chitiết phiếu nhập kho
//                for (int j = 0; idthuoc != "" && j < dtthuoc.Rows.Count; j++)
//                {

//                    int slt = StaticData.ParseInt(dtthuoc.Rows[j]["soluongton"].ToString());
//                    if (n >= slt) m = slt;
//                    else
//                        m = n;
//                    string updatectpn = "update chitietphieunhapkho set soluongxuat =(soluongxuat+ " + m + ") where idchitietphieunhapkho=" + dtthuoc.Rows[j]["idchitietphieunhapkho"].ToString();
//                    bool tpn = DataAcess.Connect.ExecSQL(updatectpn);
//                    if (!tpn)
//                    {

//                        return;
//                    }
//                    string donGiaXuat = "0";
//                    if (dtthuoc.Rows[j]["DonGiaXuat"] != null)
//                        donGiaXuat = dtthuoc.Rows[j]["DonGiaXuat"].ToString();
                    
//                    int giavon = StaticData.ParseInt(donGiaXuat);
//                    int giaban = giavon;
//                    int thanhtien = m * giaban;
//                    int thanhtientruocthue = m * giaban;
//                    string sVAT = "0";
//                    if (sVAT == "") sVAT = "0";
//                    int VAT = int.Parse(sVAT);
//                    if (sVAT == "") sVAT = "0";
//                    int tienthue = (thanhtientruocthue * VAT) / 100;
//                    string sCK = listthuoc.Rows[i]["HeSo"].ToString();
//                    if (sCK == "") sCK = "0";
//                    int chietkhau = int.Parse(sCK);
//                    int tienvon = m * giavon;

//#region 
//                    string sqlDaXuat = @"select * from chitietphieuxuatkho where idchitietbenhnhantoathuoc='" + listthuoc.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "' and idphieuxuat in(select idphieuxuat from phieuxuatkho where idkho ='"+idkho+"')";
//                    DataTable dtDaXuat= DataAcess.Connect.GetTable(sqlDaXuat);
//                    string luuctphieuxuat = "";
//                    if (dtDaXuat.Rows.Count > 0)
//                    {
//                        //nvk comment //luuctphieuxuat = @"update chitietphieuxuatkho set idthuoc=" + idthuoc + ",soluong=" + m + ",dongia=" + giaban + @" where idchitietbenhnhantoathuoc='" + listthuoc.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'";
//                        luuctphieuxuat = @"update chitietphieuxuatkho set idthuoc=" + idthuoc + ",soluong=" + m + ",dongia=" + giaban + @" where idchitietphieuxuat='" + dtDaXuat.Rows[0]["idchitietphieuxuat"] + "'";
//                    }
//                    else
//                    {
//                        luuctphieuxuat = "insert chitietphieuxuatkho(idphieuxuat, idthuoc, soluong, dongia, idchitietphieunhapkho, idtu, idngan, sluongxuat, dvt, thanhtien, thanhtientruocthue, tienthue, chietkhau, giavon, tienvon,idchitietbenhnhantoathuoc) ";
//                        luuctphieuxuat += " values(" + idphieuxuat + ", " + idthuoc + ", " + m + ", " + giaban + ", ";
//                        luuctphieuxuat += " " + dtthuoc.Rows[j]["idchitietphieunhapkho"].ToString() + ", " + (dtthuoc.Rows[j]["idtu"].ToString() != "" ? dtthuoc.Rows[j]["idtu"].ToString() : "0") + ", " + (dtthuoc.Rows[j]["idngan"].ToString() != "" ? dtthuoc.Rows[j]["idngan"].ToString() : "0") + ", " + m + ", ";
//                        luuctphieuxuat += " " + dtthuoc.Rows[j]["dvt"].ToString() + ", " + thanhtien + ", " + thanhtientruocthue + ", " + tienthue + ", " + chietkhau + " , " + giavon + ", " + tienvon + ",'" + listthuoc.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "') ";
//                    }
//#endregion
//                    bool luu = DataAcess.Connect.ExecSQL(luuctphieuxuat);
//                    if (!luu)
//                    {
//                        return;
//                    }
//                    if (n - slt <= 0) break;
//                    else n -= slt;
//                }//end for 1.1
//                #endregion
//                if (dtthuoc.Rows.Count == 0)
//                {
//                    #region NVK_Khi không có phiếu nhập nào  => tạo phiếu xuất không co thông tin phiếu nhập 
//                    string sqlDaXuat = @"select * from chitietphieuxuatkho where idchitietbenhnhantoathuoc='" + listthuoc.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'";
//                    DataTable dtDaXuat = DataAcess.Connect.GetTable(sqlDaXuat);
//                    string luuctphieuxuat = "";
//                    if (dtDaXuat.Rows.Count > 0)
//                    {
//                        luuctphieuxuat = @"update chitietphieuxuatkho set idthuoc=" + idthuoc + ",soluong=" + listthuoc.Rows[i]["soluongke"].ToString() + ",dongia='0' where idchitietbenhnhantoathuoc='" + listthuoc.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'";
//                    }
//                    else
//                    {
//                        luuctphieuxuat = @"insert chitietphieuxuatkho(idphieuxuat, idthuoc, soluong, dongia, idchitietphieunhapkho, idtu, idngan, sluongxuat, dvt, thanhtien, thanhtientruocthue, tienthue, chietkhau, giavon, tienvon,idchitietbenhnhantoathuoc)
//                         values(" + idphieuxuat + ", " + idthuoc + ", " + listthuoc.Rows[i]["soluongke"].ToString() + @", '0', 
//                         0,'0', '0', " + listthuoc.Rows[i]["soluongke"].ToString() + @", 
//                         '', '0', '0', '0', '0', '0', '0','" + listthuoc.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + @"') ";
//                        bool luu = DataAcess.Connect.ExecSQL(luuctphieuxuat);
//                        if (!luu)
//                        {
//                            return;
//                        }
//                    }
//                    #endregion 
//                }
//            }
//            #endregion
//        }         
//    }


    public static string nvk_NhapTra_nBN_nThuoc(DataTable TableChiTietTra, string IdNguoiNhanThuoc, string GhiChu, string ngaychungtu, string IdKho,string soPhieuYC)
    {
        string idPhieuNhap = "";
        if ( TableChiTietTra == null || TableChiTietTra.Rows.Count == 0)
            return null;
       
        string MaPhieuNhapTra = StaticData.NVK_NewMaPhieu_TheoNgay(DateTime.Now.ToString("yyyy/MM/dd"), "BNT-", "PHIEUNHAPKHO", "NGAYTHANG");
        string sqlPhieuNhap = @"insert into phieunhapkho(
            maphieunhap
            ,ngaythang
            ,idkho -- kho nhập thuốc
            ,ghichu
            ,idkhachhang
            ,idnguoinhap
            ,idloainhap-- =2 (Khách hàng nhập trả)==> chuyển =4 theo ý a S
            ,SOPHIEUYC
            )
            values(
            '" + MaPhieuNhapTra + @"'
            ,'"+ngaychungtu+@"'
            ,'" + IdKho + @"'
            ,N'" + GhiChu + @"'
            ,'0'
            ,'" + IdNguoiNhanThuoc + @"'
            ,4
            ,'"+soPhieuYC+@"'
            )";
        bool ktPhieuNhap = DataAcess.Connect.ExecSQL(sqlPhieuNhap);
        bool kt = false;
        if (ktPhieuNhap)
        {
            idPhieuNhap = DataAcess.Connect.GetTable("select top 1 * from phieunhapkho where maphieunhap='" + MaPhieuNhapTra + "' order by idphieunhap desc ").Rows[0]["idphieunhap"].ToString();
            for (int j = 0; j < TableChiTietTra.Rows.Count; j++) //for TableChiTietTra
            {
                    try
                    {
                        string sqlCtpn = @"
                                        insert into chitietphieunhapkho (
                                        idphieunhap,
                                        idthuoc,
                                        soluong,
                                        dongia,
                                        chietkhau,
                                        vat,
                                            thanhtien,
                                            thanhtientruocthue,
                                        ngayhethan,
                                        losanxuat,
                                        IdChiTietPhieuYCTra,
                                        idchitietbenhnhantoathuoc
                                        )
                                        values (
                                        '" + idPhieuNhap + @"'
                                        ,'" + TableChiTietTra.Rows[j]["idthuoc"] + @"'
                                        ,'" + TableChiTietTra.Rows[j]["SoLuongTra"] + @"'
                                        ,'" + TableChiTietTra.Rows[j]["DonGia"] + @"'
                                        ,'0'
                                        ,'" + TableChiTietTra.Rows[j]["VAT"] + @"'
                                        ,'" + TableChiTietTra.Rows[j]["thanhTien"] + @"'
                                        ,'" + TableChiTietTra.Rows[j]["thanhtienTruocThue"] + @"'
                                        ,'" + TableChiTietTra.Rows[j]["NgayHetHan"] + @"'
                                        ,'" + TableChiTietTra.Rows[j]["losanxuat"] + @"'
                                        ,'" + TableChiTietTra.Rows[j]["IdChiTietPhieuYCTra"] + @"'
                                        ,'" + TableChiTietTra.Rows[j]["idchitietbenhnhantoathuoc"] + @"'
                                        )
                                        ";
                        kt = DataAcess.Connect.ExecSQL(sqlCtpn);
                        if (!kt)
                        {
                            DataAcess.Connect.ExecSQL("delete from chitietphieunhapkho where idphieunhap='"+idPhieuNhap+"'");
                            DataAcess.Connect.ExecSQL("delete from phieunhapkho where idphieunhap='" + idPhieuNhap + "'");
                            return null;
                        }
                    }
                    catch (Exception ex) { }

            } // for TableChiTietTra


        }
        return idPhieuNhap;
    }
    public static string nvk_NhapTra_nBN_nThuoc_bk_0512(DataTable TableBN, DataTable TableChiTietTra, string IdNguoiNhanThuoc, string GhiChu, string ngaychungtu, string IdKho)
    {
        string ListIdNhapTra = "";
        if (TableBN == null || TableChiTietTra == null || TableBN.Rows.Count == 0 || TableChiTietTra.Rows.Count == 0)
            return null;
        for (int i = 0; i < TableBN.Rows.Count; i++) // for benhnhan
        {
            string makhachhang = StaticData.TaoMaSoPhieu("KH", "KhachHang", "makhachhang", "getdate()", ngaychungtu.Substring(5, 2), "idkhachhang");
            int idkhachhang = myInsertPhieuXuatKho.luuthongtinkhachhang(StaticData.ParseInt(TableBN.Rows[i]["idbenhnhan"]), makhachhang, TableBN.Rows[i]["tenbenhnhan"].ToString(), TableBN.Rows[i]["diachi"].ToString()
                , TableBN.Rows[i]["dienthoai"].ToString(), StaticData.ParseInt(TableBN.Rows[i]["gioitinh"]), TableBN.Rows[0]["ngaysinh"].ToString());
            string MaPhieuNhapTra = StaticData.NVK_NewMaPhieu_TheoNgay(DateTime.Now.ToString("yyyy/MM/dd"), "BNT-", "PHIEUNHAPKHO", "NGAYTHANG");
            string sqlPhieuNhap = @"insert into phieunhapkho(
                maphieunhap
                ,ngaythang
                ,idkho -- kho nhập thuốc
                ,ghichu
                ,idkhachhang
                ,idnguoinhap
                ,idloainhap-- =2 (Khách hàng nhập trả)
                )
                values(
                '" + MaPhieuNhapTra + @"'
                ,getdate()
                ,'" + IdKho + @"'
                ,N'" + GhiChu + @"'
                ,'" + idkhachhang + @"' --idbenhnhan
                ,'" + IdNguoiNhanThuoc + @"'
                ,2
                )";
            bool ktPhieuNhap = DataAcess.Connect.ExecSQL(sqlPhieuNhap);
            bool kt = false;
            if (ktPhieuNhap)
            {
                string idPhieuNhap = DataAcess.Connect.GetTable("select top 1 * from phieunhapkho where maphieunhap='" + MaPhieuNhapTra + "' order by idphieunhap desc ").Rows[0]["idphieunhap"].ToString();
                ListIdNhapTra += idPhieuNhap + ",";
                for (int j = 0; j < TableChiTietTra.Rows.Count; j++) //for TableChiTietTra
                {
                    if (TableChiTietTra.Rows[j]["idbenhnhan"].ToString().Equals(TableBN.Rows[i]["idbenhnhan"].ToString()))
                    {
                        try
                        {
                            string sqlCtpn = @"
                                            insert into chitietphieunhapkho (
                                            idphieunhap,
                                            idthuoc,
                                            soluong,
                                            dongia,
                                            chietkhau,
                                            vat,
                                            ngayhethan,
                                            losanxuat
                                            )
                                            values (
                                            '" + idPhieuNhap + @"'
                                            ,'" + TableChiTietTra.Rows[j]["idthuoc"] + @"'
                                            ,'" + TableChiTietTra.Rows[j]["SoLuongTra"] + @"'
                                            ,'" + TableChiTietTra.Rows[j]["DonGia"] + @"'
                                            ,'0'
                                            ,'" + TableChiTietTra.Rows[j]["VAT"] + @"'
                                            ,'" + TableChiTietTra.Rows[j]["NgayHetHan"] + @"'
                                            ,'" + TableChiTietTra.Rows[j]["losanxuat"] + @"'
                                            )
                                            ";
                            kt = DataAcess.Connect.ExecSQL(sqlCtpn);
                        }
                        catch (Exception ex) { }
                    }

                } // for TableChiTietTra


            }
        } //end for benhnhan
        ListIdNhapTra = ListIdNhapTra.TrimEnd(',');
        return ListIdNhapTra;
    }
}

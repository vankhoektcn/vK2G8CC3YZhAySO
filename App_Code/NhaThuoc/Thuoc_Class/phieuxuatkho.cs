using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process_2608
  { 
 public class phieuxuatkho:  Connect { 
 public static string sTableName= "phieuxuatkho"; 
   public string idphieuxuat;
   public string maphieuxuat;
   public string ngaythang;
   public string ghichu;
   public string idphongkhambenh;
   public string nguoinhan;
   public string xuatcho;
   public string idkho;
   public string loaixuat;
   public string IDKhachHang;
   public string vat;
   public string thanhtien;
   public string ngayhoadon;
   public string idnhacungcap;
   public string idkho2;
   public string idnguoixuat;
   public string IdBenhNhanToaThuoc;
   public string IsBHYT;
   public string SLPX;
   public string tkNo;
   public string TKVAT;
   public string TKCo;
   public string IdCaPhauThuat;
   public string IsDaHuy;
   public string LANSUA;
   public string MaPhieu;
   public string NGAYSUA;
   public string NGUOISUA;
   public string IdLoaiThuoc;
   public string IdBenhNhan;
   public string IDKHAMBENH1;
   public string IDPHIEUYC;
   public string SOPHIEUYC;
   #region DataColumn Name ;
 public static  string cl_idphieuxuat="idphieuxuat" ;
 public static  string cl_idphieuxuat_VN="idphieuxuat";
 public static  string cl_maphieuxuat="maphieuxuat" ;
 public static  string cl_maphieuxuat_VN="maphieuxuat";
 public static  string cl_ngaythang="ngaythang" ;
 public static  string cl_ngaythang_VN="ngaythang";
 public static  string cl_ghichu="ghichu" ;
 public static  string cl_ghichu_VN="ghichu";
 public static  string cl_idphongkhambenh="idphongkhambenh" ;
 public static  string cl_idphongkhambenh_VN="idphongkhambenh";
 public static  string cl_nguoinhan="nguoinhan" ;
 public static  string cl_nguoinhan_VN="nguoinhan";
 public static  string cl_xuatcho="xuatcho" ;
 public static  string cl_xuatcho_VN="xuatcho";
 public static  string cl_idkho="idkho" ;
 public static  string cl_idkho_VN="idkho";
 public static  string cl_loaixuat="loaixuat" ;
 public static  string cl_loaixuat_VN="loaixuat";
 public static  string cl_IDKhachHang="IDKhachHang" ;
 public static  string cl_IDKhachHang_VN="IDKhachHang";
 public static  string cl_vat="vat" ;
 public static  string cl_vat_VN="vat";
 public static  string cl_thanhtien="thanhtien" ;
 public static  string cl_thanhtien_VN="thanhtien";
 public static  string cl_ngayhoadon="ngayhoadon" ;
 public static  string cl_ngayhoadon_VN="ngayhoadon";
 public static  string cl_idnhacungcap="idnhacungcap" ;
 public static  string cl_idnhacungcap_VN="idnhacungcap";
 public static  string cl_idkho2="idkho2" ;
 public static  string cl_idkho2_VN="idkho2";
 public static  string cl_idnguoixuat="idnguoixuat" ;
 public static  string cl_idnguoixuat_VN="idnguoixuat";
 public static  string cl_IdBenhNhanToaThuoc="IdBenhNhanToaThuoc" ;
 public static  string cl_IdBenhNhanToaThuoc_VN="IdBenhNhanToaThuoc";
 public static  string cl_IsBHYT="IsBHYT" ;
 public static  string cl_IsBHYT_VN="IsBHYT";
 public static  string cl_SLPX="SLPX" ;
 public static  string cl_SLPX_VN="SLPX";
 public static  string cl_tkNo="tkNo" ;
 public static  string cl_tkNo_VN="tkNo";
 public static  string cl_TKVAT="TKVAT" ;
 public static  string cl_TKVAT_VN="TKVAT";
 public static  string cl_TKCo="TKCo" ;
 public static  string cl_TKCo_VN="TKCo";
 public static  string cl_IdCaPhauThuat="IdCaPhauThuat" ;
 public static  string cl_IdCaPhauThuat_VN="IdCaPhauThuat";
 public static  string cl_IsDaHuy="IsDaHuy" ;
 public static  string cl_IsDaHuy_VN="IsDaHuy";
 public static  string cl_LANSUA="LANSUA" ;
 public static  string cl_LANSUA_VN="LANSUA";
 public static  string cl_MaPhieu="MaPhieu" ;
 public static  string cl_MaPhieu_VN="MaPhieu";
 public static  string cl_NGAYSUA="NGAYSUA" ;
 public static  string cl_NGAYSUA_VN="NGAYSUA";
 public static  string cl_NGUOISUA="NGUOISUA" ;
 public static  string cl_NGUOISUA_VN="NGUOISUA";
 public static  string cl_IdLoaiThuoc="IdLoaiThuoc" ;
 public static  string cl_IdLoaiThuoc_VN="IdLoaiThuoc";
 public static  string cl_IdBenhNhan="IdBenhNhan" ;
 public static  string cl_IdBenhNhan_VN="IdBenhNhan";
 public static  string cl_IDKHAMBENH1="IDKHAMBENH1" ;
 public static  string cl_IDKHAMBENH1_VN="IDKHAMBENH1";
 public static  string cl_IDPHIEUYC="IDPHIEUYC" ;
 public static  string cl_IDPHIEUYC_VN="IDPHIEUYC";
 public static  string cl_SOPHIEUYC="SOPHIEUYC" ;
 public static  string cl_SOPHIEUYC_VN="SOPHIEUYC";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public phieuxuatkho() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public phieuxuatkho(
         string sidphieuxuat,
         string smaphieuxuat,
         string sngaythang,
         string sghichu,
         string sidphongkhambenh,
         string snguoinhan,
         string sxuatcho,
         string sidkho,
         string sloaixuat,
         string sIDKhachHang,
         string svat,
         string sthanhtien,
         string sngayhoadon,
         string sidnhacungcap,
         string sidkho2,
         string sidnguoixuat,
         string sIdBenhNhanToaThuoc,
         string sIsBHYT,
         string sSLPX,
         string stkNo,
         string sTKVAT,
         string sTKCo,
         string sIdCaPhauThuat,
         string sIsDaHuy,
         string sLANSUA,
         string sMaPhieu,
         string sNGAYSUA,
         string sNGUOISUA,
         string sIdLoaiThuoc,
         string sIdBenhNhan,
         string sIDKHAMBENH1,
         string sIDPHIEUYC,
         string sSOPHIEUYC){
         this.idphieuxuat= sidphieuxuat;
         this.maphieuxuat= smaphieuxuat;
         this.ngaythang= sngaythang;
         this.ghichu= sghichu;
         this.idphongkhambenh= sidphongkhambenh;
         this.nguoinhan= snguoinhan;
         this.xuatcho= sxuatcho;
         this.idkho= sidkho;
         this.loaixuat= sloaixuat;
         this.IDKhachHang= sIDKhachHang;
         this.vat= svat;
         this.thanhtien= sthanhtien;
         this.ngayhoadon= sngayhoadon;
         this.idnhacungcap= sidnhacungcap;
         this.idkho2= sidkho2;
         this.idnguoixuat= sidnguoixuat;
         this.IdBenhNhanToaThuoc= sIdBenhNhanToaThuoc;
         this.IsBHYT= sIsBHYT;
         this.SLPX= sSLPX;
         this.tkNo= stkNo;
         this.TKVAT= sTKVAT;
         this.TKCo= sTKCo;
         this.IdCaPhauThuat= sIdCaPhauThuat;
         this.IsDaHuy= sIsDaHuy;
         this.LANSUA= sLANSUA;
         this.MaPhieu= sMaPhieu;
         this.NGAYSUA= sNGAYSUA;
         this.NGUOISUA= sNGUOISUA;
         this.IdLoaiThuoc= sIdLoaiThuoc;
         this.IdBenhNhan= sIdBenhNhan;
         this.IDKHAMBENH1= sIDKHAMBENH1;
         this.IDPHIEUYC= sIDPHIEUYC;
         this.SOPHIEUYC= sSOPHIEUYC;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static phieuxuatkho Create_phieuxuatkho ( string sidphieuxuat  ){
    DataTable dt=dtSearchByidphieuxuat(sidphieuxuat) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new phieuxuatkho(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM phieuxuatkho AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public phieuxuatkho( DataView dv,int pos)
{
         this.idphieuxuat= dv[pos][0].ToString();
         this.maphieuxuat= dv[pos][1].ToString();
         this.ngaythang= dv[pos][2].ToString();
         this.ghichu= dv[pos][3].ToString();
         this.idphongkhambenh= dv[pos][4].ToString();
         this.nguoinhan= dv[pos][5].ToString();
         this.xuatcho= dv[pos][6].ToString();
         this.idkho= dv[pos][7].ToString();
         this.loaixuat= dv[pos][8].ToString();
         this.IDKhachHang= dv[pos][9].ToString();
         this.vat= dv[pos][10].ToString();
         this.thanhtien= dv[pos][11].ToString();
         this.ngayhoadon= dv[pos][12].ToString();
         this.idnhacungcap= dv[pos][13].ToString();
         this.idkho2= dv[pos][14].ToString();
         this.idnguoixuat= dv[pos][15].ToString();
         this.IdBenhNhanToaThuoc= dv[pos][16].ToString();
         this.IsBHYT= dv[pos][17].ToString();
         this.SLPX= dv[pos][18].ToString();
         this.tkNo= dv[pos][19].ToString();
         this.TKVAT= dv[pos][20].ToString();
         this.TKCo= dv[pos][21].ToString();
         this.IdCaPhauThuat= dv[pos][22].ToString();
         this.IsDaHuy= dv[pos][23].ToString();
         this.LANSUA= dv[pos][24].ToString();
         this.MaPhieu= dv[pos][25].ToString();
         this.NGAYSUA= dv[pos][26].ToString();
         this.NGUOISUA= dv[pos][27].ToString();
         this.IdLoaiThuoc= dv[pos][28].ToString();
         this.IdBenhNhan= dv[pos][29].ToString();
         this.IDKHAMBENH1= dv[pos][30].ToString();
         this.IDPHIEUYC= dv[pos][31].ToString();
         this.SOPHIEUYC= dv[pos][32].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidphieuxuat(string sidphieuxuat)
{
          string sqlSelect= s_Select()+ " WHERE idphieuxuat  ="+ sidphieuxuat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidphieuxuat(string sidphieuxuat,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idphieuxuat"+ sMatch +sidphieuxuat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBymaphieuxuat(string smaphieuxuat)
{
          string sqlSelect= s_Select()+ " WHERE maphieuxuat  Like N'%"+ smaphieuxuat + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaythang(string sngaythang)
{
          string sqlSelect= s_Select()+ " WHERE ngaythang  ="+ sngaythang + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaythang(string sngaythang,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ngaythang"+ sMatch +sngaythang + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByghichu(string sghichu)
{
          string sqlSelect= s_Select()+ " WHERE ghichu  Like N'%"+ sghichu + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidphongkhambenh(string sidphongkhambenh)
{
          string sqlSelect= s_Select()+ " WHERE idphongkhambenh  ="+ sidphongkhambenh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidphongkhambenh(string sidphongkhambenh,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idphongkhambenh"+ sMatch +sidphongkhambenh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynguoinhan(string snguoinhan)
{
          string sqlSelect= s_Select()+ " WHERE nguoinhan  Like N'%"+ snguoinhan + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByxuatcho(string sxuatcho)
{
          string sqlSelect= s_Select()+ " WHERE xuatcho  ="+ sxuatcho + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByxuatcho(string sxuatcho,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE xuatcho"+ sMatch +sxuatcho + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkho(string sidkho)
{
          string sqlSelect= s_Select()+ " WHERE idkho  ="+ sidkho + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkho(string sidkho,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idkho"+ sMatch +sidkho + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByloaixuat(string sloaixuat)
{
          string sqlSelect= s_Select()+ " WHERE loaixuat  ="+ sloaixuat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByloaixuat(string sloaixuat,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE loaixuat"+ sMatch +sloaixuat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDKhachHang(string sIDKhachHang)
{
          string sqlSelect= s_Select()+ " WHERE IDKhachHang  ="+ sIDKhachHang + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDKhachHang(string sIDKhachHang,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IDKhachHang"+ sMatch +sIDKhachHang + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByvat(string svat)
{
          string sqlSelect= s_Select()+ " WHERE vat  ="+ svat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByvat(string svat,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE vat"+ sMatch +svat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBythanhtien(string sthanhtien)
{
          string sqlSelect= s_Select()+ " WHERE thanhtien  ="+ sthanhtien + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBythanhtien(string sthanhtien,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE thanhtien"+ sMatch +sthanhtien + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngayhoadon(string sngayhoadon)
{
          string sqlSelect= s_Select()+ " WHERE ngayhoadon  ="+ sngayhoadon + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngayhoadon(string sngayhoadon,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ngayhoadon"+ sMatch +sngayhoadon + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidnhacungcap(string sidnhacungcap)
{
          string sqlSelect= s_Select()+ " WHERE idnhacungcap  ="+ sidnhacungcap + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidnhacungcap(string sidnhacungcap,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idnhacungcap"+ sMatch +sidnhacungcap + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkho2(string sidkho2)
{
          string sqlSelect= s_Select()+ " WHERE idkho2  ="+ sidkho2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkho2(string sidkho2,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idkho2"+ sMatch +sidkho2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidnguoixuat(string sidnguoixuat)
{
          string sqlSelect= s_Select()+ " WHERE idnguoixuat  ="+ sidnguoixuat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidnguoixuat(string sidnguoixuat,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idnguoixuat"+ sMatch +sidnguoixuat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdBenhNhanToaThuoc(string sIdBenhNhanToaThuoc)
{
          string sqlSelect= s_Select()+ " WHERE IdBenhNhanToaThuoc  ="+ sIdBenhNhanToaThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdBenhNhanToaThuoc(string sIdBenhNhanToaThuoc,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdBenhNhanToaThuoc"+ sMatch +sIdBenhNhanToaThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsBHYT(string sIsBHYT)
{
          string sqlSelect= s_Select()+ " WHERE IsBHYT  ="+ sIsBHYT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsBHYT(string sIsBHYT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IsBHYT"+ sMatch +sIsBHYT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySLPX(string sSLPX)
{
          string sqlSelect= s_Select()+ " WHERE SLPX  ="+ sSLPX + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySLPX(string sSLPX,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SLPX"+ sMatch +sSLPX + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytkNo(string stkNo)
{
          string sqlSelect= s_Select()+ " WHERE tkNo  ="+ stkNo + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytkNo(string stkNo,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE tkNo"+ sMatch +stkNo + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTKVAT(string sTKVAT)
{
          string sqlSelect= s_Select()+ " WHERE TKVAT  ="+ sTKVAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTKVAT(string sTKVAT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE TKVAT"+ sMatch +sTKVAT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTKCo(string sTKCo)
{
          string sqlSelect= s_Select()+ " WHERE TKCo  ="+ sTKCo + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTKCo(string sTKCo,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE TKCo"+ sMatch +sTKCo + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdCaPhauThuat(string sIdCaPhauThuat)
{
          string sqlSelect= s_Select()+ " WHERE IdCaPhauThuat  ="+ sIdCaPhauThuat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdCaPhauThuat(string sIdCaPhauThuat,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdCaPhauThuat"+ sMatch +sIdCaPhauThuat + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsDaHuy(string sIsDaHuy)
{
          string sqlSelect= s_Select()+ " WHERE IsDaHuy  ="+ sIsDaHuy + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsDaHuy(string sIsDaHuy,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IsDaHuy"+ sMatch +sIsDaHuy + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLANSUA(string sLANSUA)
{
          string sqlSelect= s_Select()+ " WHERE LANSUA  ="+ sLANSUA + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLANSUA(string sLANSUA,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE LANSUA"+ sMatch +sLANSUA + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMaPhieu(string sMaPhieu)
{
          string sqlSelect= s_Select()+ " WHERE MaPhieu  Like N'%"+ sMaPhieu + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAYSUA(string sNGAYSUA)
{
          string sqlSelect= s_Select()+ " WHERE NGAYSUA  ="+ sNGAYSUA + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGAYSUA(string sNGAYSUA,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGAYSUA"+ sMatch +sNGAYSUA + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOISUA(string sNGUOISUA)
{
          string sqlSelect= s_Select()+ " WHERE NGUOISUA  ="+ sNGUOISUA + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNGUOISUA(string sNGUOISUA,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NGUOISUA"+ sMatch +sNGUOISUA + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdLoaiThuoc(string sIdLoaiThuoc)
{
          string sqlSelect= s_Select()+ " WHERE IdLoaiThuoc  ="+ sIdLoaiThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdLoaiThuoc(string sIdLoaiThuoc,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdLoaiThuoc"+ sMatch +sIdLoaiThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdBenhNhan(string sIdBenhNhan)
{
          string sqlSelect= s_Select()+ " WHERE IdBenhNhan  ="+ sIdBenhNhan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdBenhNhan(string sIdBenhNhan,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdBenhNhan"+ sMatch +sIdBenhNhan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDKHAMBENH1(string sIDKHAMBENH1)
{
          string sqlSelect= s_Select()+ " WHERE IDKHAMBENH1  ="+ sIDKHAMBENH1 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDKHAMBENH1(string sIDKHAMBENH1,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IDKHAMBENH1"+ sMatch +sIDKHAMBENH1 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDPHIEUYC(string sIDPHIEUYC)
{
          string sqlSelect= s_Select()+ " WHERE IDPHIEUYC  ="+ sIDPHIEUYC + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDPHIEUYC(string sIDPHIEUYC,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IDPHIEUYC"+ sMatch +sIDPHIEUYC + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySOPHIEUYC(string sSOPHIEUYC)
{
          string sqlSelect= s_Select()+ " WHERE SOPHIEUYC  Like N'%"+ sSOPHIEUYC + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sidphieuxuat
            , string smaphieuxuat
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
       string sqlselect=s_Select() + " WHERE" ;
      if (sidphieuxuat!=null && sidphieuxuat!="") 
            sqlselect +=" AND idphieuxuat =" + sidphieuxuat ;
      if (smaphieuxuat!=null && smaphieuxuat!="") 
            sqlselect +=" AND maphieuxuat LIKE N'%" + smaphieuxuat +"%'" ;
      if (sngaythang!=null && sngaythang!="") 
            sqlselect +=" AND ngaythang LIKE '%" + sngaythang +"%'" ;
      if (sghichu!=null && sghichu!="") 
            sqlselect +=" AND ghichu LIKE N'%" + sghichu +"%'" ;
      if (sidphongkhambenh!=null && sidphongkhambenh!="") 
            sqlselect +=" AND idphongkhambenh =" + sidphongkhambenh ;
      if (snguoinhan!=null && snguoinhan!="") 
            sqlselect +=" AND nguoinhan LIKE N'%" + snguoinhan +"%'" ;
      if (sxuatcho!=null && sxuatcho!="") 
            sqlselect +=" AND xuatcho =" + sxuatcho ;
      if (sidkho!=null && sidkho!="") 
            sqlselect +=" AND idkho =" + sidkho ;
      if (sloaixuat!=null && sloaixuat!="") 
            sqlselect +=" AND loaixuat =" + sloaixuat ;
      if (sIDKhachHang!=null && sIDKhachHang!="") 
            sqlselect +=" AND IDKhachHang =" + sIDKhachHang ;
      if (svat!=null && svat!="") 
            sqlselect +=" AND vat =" + svat ;
      if (sthanhtien!=null && sthanhtien!="") 
            sqlselect +=" AND thanhtien =" + sthanhtien ;
      if (sngayhoadon!=null && sngayhoadon!="") 
            sqlselect +=" AND ngayhoadon LIKE '%" + sngayhoadon +"%'" ;
      if (sidnhacungcap!=null && sidnhacungcap!="") 
            sqlselect +=" AND idnhacungcap =" + sidnhacungcap ;
      if (sidkho2!=null && sidkho2!="") 
            sqlselect +=" AND idkho2 =" + sidkho2 ;
      if (sidnguoixuat!=null && sidnguoixuat!="") 
            sqlselect +=" AND idnguoixuat =" + sidnguoixuat ;
      if (sIdBenhNhanToaThuoc!=null && sIdBenhNhanToaThuoc!="") 
            sqlselect +=" AND IdBenhNhanToaThuoc =" + sIdBenhNhanToaThuoc ;
      if (sIsBHYT!=null && sIsBHYT!="") 
            sqlselect +=" AND IsBHYT =" + sIsBHYT ;
      if (sSLPX!=null && sSLPX!="") 
            sqlselect +=" AND SLPX =" + sSLPX ;
      if (stkNo!=null && stkNo!="") 
            sqlselect +=" AND tkNo =" + stkNo ;
      if (sTKVAT!=null && sTKVAT!="") 
            sqlselect +=" AND TKVAT =" + sTKVAT ;
      if (sTKCo!=null && sTKCo!="") 
            sqlselect +=" AND TKCo =" + sTKCo ;
      if (sIdCaPhauThuat!=null && sIdCaPhauThuat!="") 
            sqlselect +=" AND IdCaPhauThuat =" + sIdCaPhauThuat ;
      if (sIsDaHuy!=null && sIsDaHuy!="") 
            sqlselect +=" AND IsDaHuy =" + sIsDaHuy ;
      if (sLANSUA!=null && sLANSUA!="") 
            sqlselect +=" AND LANSUA =" + sLANSUA ;
      if (sMaPhieu!=null && sMaPhieu!="") 
            sqlselect +=" AND MaPhieu LIKE N'%" + sMaPhieu +"%'" ;
      if (sNGAYSUA!=null && sNGAYSUA!="") 
            sqlselect +=" AND NGAYSUA LIKE '%" + sNGAYSUA +"%'" ;
      if (sNGUOISUA!=null && sNGUOISUA!="") 
            sqlselect +=" AND NGUOISUA =" + sNGUOISUA ;
      if (sIdLoaiThuoc!=null && sIdLoaiThuoc!="") 
            sqlselect +=" AND IdLoaiThuoc =" + sIdLoaiThuoc ;
      if (sIdBenhNhan!=null && sIdBenhNhan!="") 
            sqlselect +=" AND IdBenhNhan =" + sIdBenhNhan ;
      if (sIDKHAMBENH1!=null && sIDKHAMBENH1!="") 
            sqlselect +=" AND IDKHAMBENH1 =" + sIDKHAMBENH1 ;
      if (sIDPHIEUYC!=null && sIDPHIEUYC!="") 
            sqlselect +=" AND IDPHIEUYC =" + sIDPHIEUYC ;
      if (sSOPHIEUYC!=null && sSOPHIEUYC!="") 
            sqlselect +=" AND SOPHIEUYC LIKE N'%" + sSOPHIEUYC +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static phieuxuatkho Insert_Object(
string  smaphieuxuat
            ,string  sngaythang
            ,string  sghichu
            ,string  sidphongkhambenh
            ,string  snguoinhan
            ,string  sxuatcho
            ,string  sidkho
            ,string  sloaixuat
            ,string  sIDKhachHang
            ,string  svat
            ,string  sthanhtien
            ,string  sngayhoadon
            ,string  sidnhacungcap
            ,string  sidkho2
            ,string  sidnguoixuat
            ,string  sIdBenhNhanToaThuoc
            ,string  sIsBHYT
            ,string  sSLPX
            ,string  stkNo
            ,string  sTKVAT
            ,string  sTKCo
            ,string  sIdCaPhauThuat
            ,string  sIsDaHuy
            ,string  sLANSUA
            ,string  sMaPhieu
            ,string  sNGAYSUA
            ,string  sNGUOISUA
            ,string  sIdLoaiThuoc
            ,string  sIdBenhNhan
            ,string  sIDKHAMBENH1
            ,string  sIDPHIEUYC
            ,string  sSOPHIEUYC
            ) 
 { 
              string tem_smaphieuxuat=DataAcess.hsSqlTool.sGetSaveValue(smaphieuxuat,"varchar");
              string tem_sngaythang=DataAcess.hsSqlTool.sGetSaveValue(sngaythang,"datetime");
              string tem_sghichu=DataAcess.hsSqlTool.sGetSaveValue(sghichu,"nvarchar");
              string tem_sidphongkhambenh=DataAcess.hsSqlTool.sGetSaveValue(sidphongkhambenh,"smallint");
              string tem_snguoinhan=DataAcess.hsSqlTool.sGetSaveValue(snguoinhan,"nvarchar");
              string tem_sxuatcho=DataAcess.hsSqlTool.sGetSaveValue(sxuatcho,"tinyint");
              string tem_sidkho=DataAcess.hsSqlTool.sGetSaveValue(sidkho,"int");
              string tem_sloaixuat=DataAcess.hsSqlTool.sGetSaveValue(sloaixuat,"int");
              string tem_sIDKhachHang=DataAcess.hsSqlTool.sGetSaveValue(sIDKhachHang,"int");
              string tem_svat=DataAcess.hsSqlTool.sGetSaveValue(svat,"float");
              string tem_sthanhtien=DataAcess.hsSqlTool.sGetSaveValue(sthanhtien,"float");
              string tem_sngayhoadon=DataAcess.hsSqlTool.sGetSaveValue(sngayhoadon,"datetime");
              string tem_sidnhacungcap=DataAcess.hsSqlTool.sGetSaveValue(sidnhacungcap,"int");
              string tem_sidkho2=DataAcess.hsSqlTool.sGetSaveValue(sidkho2,"int");
              string tem_sidnguoixuat=DataAcess.hsSqlTool.sGetSaveValue(sidnguoixuat,"int");
              string tem_sIdBenhNhanToaThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhanToaThuoc,"int");
              string tem_sIsBHYT=DataAcess.hsSqlTool.sGetSaveValue(sIsBHYT,"bit");
              string tem_sSLPX=DataAcess.hsSqlTool.sGetSaveValue(sSLPX,"bigint");
              string tem_stkNo=DataAcess.hsSqlTool.sGetSaveValue(stkNo,"bigint");
              string tem_sTKVAT=DataAcess.hsSqlTool.sGetSaveValue(sTKVAT,"bigint");
              string tem_sTKCo=DataAcess.hsSqlTool.sGetSaveValue(sTKCo,"bigint");
              string tem_sIdCaPhauThuat=DataAcess.hsSqlTool.sGetSaveValue(sIdCaPhauThuat,"bigint");
              string tem_sIsDaHuy=DataAcess.hsSqlTool.sGetSaveValue(sIsDaHuy,"bit");
              string tem_sLANSUA=DataAcess.hsSqlTool.sGetSaveValue(sLANSUA,"int");
              string tem_sMaPhieu=DataAcess.hsSqlTool.sGetSaveValue(sMaPhieu,"nvarchar");
              string tem_sNGAYSUA=DataAcess.hsSqlTool.sGetSaveValue(sNGAYSUA,"datetime");
              string tem_sNGUOISUA=DataAcess.hsSqlTool.sGetSaveValue(sNGUOISUA,"bigint");
              string tem_sIdLoaiThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIdLoaiThuoc,"bigint");
              string tem_sIdBenhNhan=DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhan,"bigint");
              string tem_sIDKHAMBENH1=DataAcess.hsSqlTool.sGetSaveValue(sIDKHAMBENH1,"bigint");
              string tem_sIDPHIEUYC=DataAcess.hsSqlTool.sGetSaveValue(sIDPHIEUYC,"bigint");
              string tem_sSOPHIEUYC=DataAcess.hsSqlTool.sGetSaveValue(sSOPHIEUYC,"nvarchar");

             string sqlSave=" INSERT INTO phieuxuatkho("+
                   "maphieuxuat," 
        +                   "ngaythang," 
        +                   "ghichu," 
        +                   "idphongkhambenh," 
        +                   "nguoinhan," 
        +                   "xuatcho," 
        +                   "idkho," 
        +                   "loaixuat," 
        +                   "IDKhachHang," 
        +                   "vat," 
        +                   "thanhtien," 
        +                   "ngayhoadon," 
        +                   "idnhacungcap," 
        +                   "idkho2," 
        +                   "idnguoixuat," 
        +                   "IdBenhNhanToaThuoc," 
        +                   "IsBHYT," 
        +                   "SLPX," 
        +                   "tkNo," 
        +                   "TKVAT," 
        +                   "TKCo," 
        +                   "IdCaPhauThuat," 
        +                   "IsDaHuy," 
        +                   "LANSUA," 
        +                   "MaPhieu," 
        +                   "NGAYSUA," 
        +                   "NGUOISUA," 
        +                   "IdLoaiThuoc," 
        +                   "IdBenhNhan," 
        +                   "IDKHAMBENH1," 
        +                   "IDPHIEUYC," 
        +                   "SOPHIEUYC) VALUES("
 +tem_smaphieuxuat+","
 +tem_sngaythang+","
 +tem_sghichu+","
 +tem_sidphongkhambenh+","
 +tem_snguoinhan+","
 +tem_sxuatcho+","
 +tem_sidkho+","
 +tem_sloaixuat+","
 +tem_sIDKhachHang+","
 +tem_svat+","
 +tem_sthanhtien+","
 +tem_sngayhoadon+","
 +tem_sidnhacungcap+","
 +tem_sidkho2+","
 +tem_sidnguoixuat+","
 +tem_sIdBenhNhanToaThuoc+","
 +tem_sIsBHYT+","
 +tem_sSLPX+","
 +tem_stkNo+","
 +tem_sTKVAT+","
 +tem_sTKCo+","
 +tem_sIdCaPhauThuat+","
 +tem_sIsDaHuy+","
 +tem_sLANSUA+","
 +tem_sMaPhieu+","
 +tem_sNGAYSUA+","
 +tem_sNGUOISUA+","
 +tem_sIdLoaiThuoc+","
 +tem_sIdBenhNhan+","
 +tem_sIDKHAMBENH1+","
 +tem_sIDPHIEUYC+","
 +tem_sSOPHIEUYC +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          phieuxuatkho newphieuxuatkho= new phieuxuatkho();
                 newphieuxuatkho.idphieuxuat=GetTable( " SELECT TOP 1 idphieuxuat FROM phieuxuatkho ORDER BY idphieuxuat DESC ").Rows[0][0].ToString();
              newphieuxuatkho.maphieuxuat=smaphieuxuat;
              newphieuxuatkho.ngaythang=sngaythang;
              newphieuxuatkho.ghichu=sghichu;
              newphieuxuatkho.idphongkhambenh=sidphongkhambenh;
              newphieuxuatkho.nguoinhan=snguoinhan;
              newphieuxuatkho.xuatcho=sxuatcho;
              newphieuxuatkho.idkho=sidkho;
              newphieuxuatkho.loaixuat=sloaixuat;
              newphieuxuatkho.IDKhachHang=sIDKhachHang;
              newphieuxuatkho.vat=svat;
              newphieuxuatkho.thanhtien=sthanhtien;
              newphieuxuatkho.ngayhoadon=sngayhoadon;
              newphieuxuatkho.idnhacungcap=sidnhacungcap;
              newphieuxuatkho.idkho2=sidkho2;
              newphieuxuatkho.idnguoixuat=sidnguoixuat;
              newphieuxuatkho.IdBenhNhanToaThuoc=sIdBenhNhanToaThuoc;
              newphieuxuatkho.IsBHYT=sIsBHYT;
              newphieuxuatkho.SLPX=sSLPX;
              newphieuxuatkho.tkNo=stkNo;
              newphieuxuatkho.TKVAT=sTKVAT;
              newphieuxuatkho.TKCo=sTKCo;
              newphieuxuatkho.IdCaPhauThuat=sIdCaPhauThuat;
              newphieuxuatkho.IsDaHuy=sIsDaHuy;
              newphieuxuatkho.LANSUA=sLANSUA;
              newphieuxuatkho.MaPhieu=sMaPhieu;
              newphieuxuatkho.NGAYSUA=sNGAYSUA;
              newphieuxuatkho.NGUOISUA=sNGUOISUA;
              newphieuxuatkho.IdLoaiThuoc=sIdLoaiThuoc;
              newphieuxuatkho.IdBenhNhan=sIdBenhNhan;
              newphieuxuatkho.IDKHAMBENH1=sIDKHAMBENH1;
              newphieuxuatkho.IDPHIEUYC=sIDPHIEUYC;
              newphieuxuatkho.SOPHIEUYC=sSOPHIEUYC;
            return newphieuxuatkho; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string smaphieuxuat
                ,string sngaythang
                ,string sghichu
                ,string sidphongkhambenh
                ,string snguoinhan
                ,string sxuatcho
                ,string sidkho
                ,string sloaixuat
                ,string sIDKhachHang
                ,string svat
                ,string sthanhtien
                ,string sngayhoadon
                ,string sidnhacungcap
                ,string sidkho2
                ,string sidnguoixuat
                ,string sIdBenhNhanToaThuoc
                ,string sIsBHYT
                ,string sSLPX
                ,string stkNo
                ,string sTKVAT
                ,string sTKCo
                ,string sIdCaPhauThuat
                ,string sIsDaHuy
                ,string sLANSUA
                ,string sMaPhieu
                ,string sNGAYSUA
                ,string sNGUOISUA
                ,string sIdLoaiThuoc
                ,string sIdBenhNhan
                ,string sIDKHAMBENH1
                ,string sIDPHIEUYC
                ,string sSOPHIEUYC
                ) 
 { 
              string tem_smaphieuxuat=DataAcess.hsSqlTool.sGetSaveValue(smaphieuxuat,"varchar");
              string tem_sngaythang=DataAcess.hsSqlTool.sGetSaveValue(sngaythang,"datetime");
              string tem_sghichu=DataAcess.hsSqlTool.sGetSaveValue(sghichu,"nvarchar");
              string tem_sidphongkhambenh=DataAcess.hsSqlTool.sGetSaveValue(sidphongkhambenh,"smallint");
              string tem_snguoinhan=DataAcess.hsSqlTool.sGetSaveValue(snguoinhan,"nvarchar");
              string tem_sxuatcho=DataAcess.hsSqlTool.sGetSaveValue(sxuatcho,"tinyint");
              string tem_sidkho=DataAcess.hsSqlTool.sGetSaveValue(sidkho,"int");
              string tem_sloaixuat=DataAcess.hsSqlTool.sGetSaveValue(sloaixuat,"int");
              string tem_sIDKhachHang=DataAcess.hsSqlTool.sGetSaveValue(sIDKhachHang,"int");
              string tem_svat=DataAcess.hsSqlTool.sGetSaveValue(svat,"float");
              string tem_sthanhtien=DataAcess.hsSqlTool.sGetSaveValue(sthanhtien,"float");
              string tem_sngayhoadon=DataAcess.hsSqlTool.sGetSaveValue(sngayhoadon,"datetime");
              string tem_sidnhacungcap=DataAcess.hsSqlTool.sGetSaveValue(sidnhacungcap,"int");
              string tem_sidkho2=DataAcess.hsSqlTool.sGetSaveValue(sidkho2,"int");
              string tem_sidnguoixuat=DataAcess.hsSqlTool.sGetSaveValue(sidnguoixuat,"int");
              string tem_sIdBenhNhanToaThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhanToaThuoc,"int");
              string tem_sIsBHYT=DataAcess.hsSqlTool.sGetSaveValue(sIsBHYT,"bit");
              string tem_sSLPX=DataAcess.hsSqlTool.sGetSaveValue(sSLPX,"bigint");
              string tem_stkNo=DataAcess.hsSqlTool.sGetSaveValue(stkNo,"bigint");
              string tem_sTKVAT=DataAcess.hsSqlTool.sGetSaveValue(sTKVAT,"bigint");
              string tem_sTKCo=DataAcess.hsSqlTool.sGetSaveValue(sTKCo,"bigint");
              string tem_sIdCaPhauThuat=DataAcess.hsSqlTool.sGetSaveValue(sIdCaPhauThuat,"bigint");
              string tem_sIsDaHuy=DataAcess.hsSqlTool.sGetSaveValue(sIsDaHuy,"bit");
              string tem_sLANSUA=DataAcess.hsSqlTool.sGetSaveValue(sLANSUA,"int");
              string tem_sMaPhieu=DataAcess.hsSqlTool.sGetSaveValue(sMaPhieu,"nvarchar");
              string tem_sNGAYSUA=DataAcess.hsSqlTool.sGetSaveValue(sNGAYSUA,"datetime");
              string tem_sNGUOISUA=DataAcess.hsSqlTool.sGetSaveValue(sNGUOISUA,"bigint");
              string tem_sIdLoaiThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIdLoaiThuoc,"bigint");
              string tem_sIdBenhNhan=DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhan,"bigint");
              string tem_sIDKHAMBENH1=DataAcess.hsSqlTool.sGetSaveValue(sIDKHAMBENH1,"bigint");
              string tem_sIDPHIEUYC=DataAcess.hsSqlTool.sGetSaveValue(sIDPHIEUYC,"bigint");
              string tem_sSOPHIEUYC=DataAcess.hsSqlTool.sGetSaveValue(sSOPHIEUYC,"nvarchar");

 string sqlSave=" UPDATE phieuxuatkho SET "+"maphieuxuat ="+tem_smaphieuxuat+","
 +"ngaythang ="+tem_sngaythang+","
 +"ghichu ="+tem_sghichu+","
 +"idphongkhambenh ="+tem_sidphongkhambenh+","
 +"nguoinhan ="+tem_snguoinhan+","
 +"xuatcho ="+tem_sxuatcho+","
 +"idkho ="+tem_sidkho+","
 +"loaixuat ="+tem_sloaixuat+","
 +"IDKhachHang ="+tem_sIDKhachHang+","
 +"vat ="+tem_svat+","
 +"thanhtien ="+tem_sthanhtien+","
 +"ngayhoadon ="+tem_sngayhoadon+","
 +"idnhacungcap ="+tem_sidnhacungcap+","
 +"idkho2 ="+tem_sidkho2+","
 +"idnguoixuat ="+tem_sidnguoixuat+","
 +"IdBenhNhanToaThuoc ="+tem_sIdBenhNhanToaThuoc+","
 +"IsBHYT ="+tem_sIsBHYT+","
 +"SLPX ="+tem_sSLPX+","
 +"tkNo ="+tem_stkNo+","
 +"TKVAT ="+tem_sTKVAT+","
 +"TKCo ="+tem_sTKCo+","
 +"IdCaPhauThuat ="+tem_sIdCaPhauThuat+","
 +"IsDaHuy ="+tem_sIsDaHuy+","
 +"LANSUA ="+tem_sLANSUA+","
 +"MaPhieu ="+tem_sMaPhieu+","
 +"NGAYSUA ="+tem_sNGAYSUA+","
 +"NGUOISUA ="+tem_sNGUOISUA+","
 +"IdLoaiThuoc ="+tem_sIdLoaiThuoc+","
 +"IdBenhNhan ="+tem_sIdBenhNhan+","
 +"IDKHAMBENH1 ="+tem_sIDKHAMBENH1+","
 +"IDPHIEUYC ="+tem_sIDPHIEUYC+","
 +"SOPHIEUYC ="+tem_sSOPHIEUYC+" WHERE idphieuxuat="+DataAcess.hsSqlTool.sGetSaveValue(this.idphieuxuat,"int identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.maphieuxuat=smaphieuxuat;
                this.ngaythang=sngaythang;
                this.ghichu=sghichu;
                this.idphongkhambenh=sidphongkhambenh;
                this.nguoinhan=snguoinhan;
                this.xuatcho=sxuatcho;
                this.idkho=sidkho;
                this.loaixuat=sloaixuat;
                this.IDKhachHang=sIDKhachHang;
                this.vat=svat;
                this.thanhtien=sthanhtien;
                this.ngayhoadon=sngayhoadon;
                this.idnhacungcap=sidnhacungcap;
                this.idkho2=sidkho2;
                this.idnguoixuat=sidnguoixuat;
                this.IdBenhNhanToaThuoc=sIdBenhNhanToaThuoc;
                this.IsBHYT=sIsBHYT;
                this.SLPX=sSLPX;
                this.tkNo=stkNo;
                this.TKVAT=sTKVAT;
                this.TKCo=sTKCo;
                this.IdCaPhauThuat=sIdCaPhauThuat;
                this.IsDaHuy=sIsDaHuy;
                this.LANSUA=sLANSUA;
                this.MaPhieu=sMaPhieu;
                this.NGAYSUA=sNGAYSUA;
                this.NGUOISUA=sNGUOISUA;
                this.IdLoaiThuoc=sIdLoaiThuoc;
                this.IdBenhNhan=sIdBenhNhan;
                this.IDKHAMBENH1=sIDKHAMBENH1;
                this.IDPHIEUYC=sIDPHIEUYC;
                this.SOPHIEUYC=sSOPHIEUYC;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_idphieuxuat(string sidphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET idphieuxuat='"+ sidphieuxuat+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idphieuxuat=sidphieuxuat;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_maphieuxuat(string smaphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET maphieuxuat=N'"+ smaphieuxuat+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.maphieuxuat=smaphieuxuat;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ngaythang(string sngaythang)
{
    string sqlSave= " UPDATE phieuxuatkho SET ngaythang='"+ sngaythang+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ngaythang=sngaythang;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ghichu(string sghichu)
{
    string sqlSave= " UPDATE phieuxuatkho SET ghichu=N'"+ sghichu+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ghichu=sghichu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idphongkhambenh(string sidphongkhambenh)
{
    string sqlSave= " UPDATE phieuxuatkho SET idphongkhambenh='"+ sidphongkhambenh+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idphongkhambenh=sidphongkhambenh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_nguoinhan(string snguoinhan)
{
    string sqlSave= " UPDATE phieuxuatkho SET nguoinhan=N'"+ snguoinhan+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.nguoinhan=snguoinhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_xuatcho(string sxuatcho)
{
    string sqlSave= " UPDATE phieuxuatkho SET xuatcho='"+ sxuatcho+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.xuatcho=sxuatcho;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idkho(string sidkho)
{
    string sqlSave= " UPDATE phieuxuatkho SET idkho='"+ sidkho+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idkho=sidkho;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_loaixuat(string sloaixuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET loaixuat='"+ sloaixuat+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.loaixuat=sloaixuat;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IDKhachHang(string sIDKhachHang)
{
    string sqlSave= " UPDATE phieuxuatkho SET IDKhachHang='"+ sIDKhachHang+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IDKhachHang=sIDKhachHang;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_vat(string svat)
{
    string sqlSave= " UPDATE phieuxuatkho SET vat='"+ svat+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.vat=svat;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_thanhtien(string sthanhtien)
{
    string sqlSave= " UPDATE phieuxuatkho SET thanhtien='"+ sthanhtien+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.thanhtien=sthanhtien;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ngayhoadon(string sngayhoadon)
{
    string sqlSave= " UPDATE phieuxuatkho SET ngayhoadon='"+ sngayhoadon+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ngayhoadon=sngayhoadon;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idnhacungcap(string sidnhacungcap)
{
    string sqlSave= " UPDATE phieuxuatkho SET idnhacungcap='"+ sidnhacungcap+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idnhacungcap=sidnhacungcap;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idkho2(string sidkho2)
{
    string sqlSave= " UPDATE phieuxuatkho SET idkho2='"+ sidkho2+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idkho2=sidkho2;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idnguoixuat(string sidnguoixuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET idnguoixuat='"+ sidnguoixuat+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idnguoixuat=sidnguoixuat;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdBenhNhanToaThuoc(string sIdBenhNhanToaThuoc)
{
    string sqlSave= " UPDATE phieuxuatkho SET IdBenhNhanToaThuoc='"+ sIdBenhNhanToaThuoc+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IdBenhNhanToaThuoc=sIdBenhNhanToaThuoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsBHYT(string sIsBHYT)
{
    string sqlSave= " UPDATE phieuxuatkho SET IsBHYT='"+ sIsBHYT+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IsBHYT=sIsBHYT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SLPX(string sSLPX)
{
    string sqlSave= " UPDATE phieuxuatkho SET SLPX='"+ sSLPX+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SLPX=sSLPX;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tkNo(string stkNo)
{
    string sqlSave= " UPDATE phieuxuatkho SET tkNo='"+ stkNo+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tkNo=stkNo;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TKVAT(string sTKVAT)
{
    string sqlSave= " UPDATE phieuxuatkho SET TKVAT='"+ sTKVAT+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TKVAT=sTKVAT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TKCo(string sTKCo)
{
    string sqlSave= " UPDATE phieuxuatkho SET TKCo='"+ sTKCo+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.TKCo=sTKCo;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdCaPhauThuat(string sIdCaPhauThuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IdCaPhauThuat='"+ sIdCaPhauThuat+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IdCaPhauThuat=sIdCaPhauThuat;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsDaHuy(string sIsDaHuy)
{
    string sqlSave= " UPDATE phieuxuatkho SET IsDaHuy='"+ sIsDaHuy+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IsDaHuy=sIsDaHuy;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_LANSUA(string sLANSUA)
{
    string sqlSave= " UPDATE phieuxuatkho SET LANSUA='"+ sLANSUA+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.LANSUA=sLANSUA;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MaPhieu(string sMaPhieu)
{
    string sqlSave= " UPDATE phieuxuatkho SET MaPhieu=N'"+ sMaPhieu+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MaPhieu=sMaPhieu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGAYSUA(string sNGAYSUA)
{
    string sqlSave= " UPDATE phieuxuatkho SET NGAYSUA='"+ sNGAYSUA+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGAYSUA=sNGAYSUA;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NGUOISUA(string sNGUOISUA)
{
    string sqlSave= " UPDATE phieuxuatkho SET NGUOISUA='"+ sNGUOISUA+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NGUOISUA=sNGUOISUA;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdLoaiThuoc(string sIdLoaiThuoc)
{
    string sqlSave= " UPDATE phieuxuatkho SET IdLoaiThuoc='"+ sIdLoaiThuoc+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IdLoaiThuoc=sIdLoaiThuoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdBenhNhan(string sIdBenhNhan)
{
    string sqlSave= " UPDATE phieuxuatkho SET IdBenhNhan='"+ sIdBenhNhan+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IdBenhNhan=sIdBenhNhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IDKHAMBENH1(string sIDKHAMBENH1)
{
    string sqlSave= " UPDATE phieuxuatkho SET IDKHAMBENH1='"+ sIDKHAMBENH1+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IDKHAMBENH1=sIDKHAMBENH1;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IDPHIEUYC(string sIDPHIEUYC)
{
    string sqlSave= " UPDATE phieuxuatkho SET IDPHIEUYC='"+ sIDPHIEUYC+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IDPHIEUYC=sIDPHIEUYC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SOPHIEUYC(string sSOPHIEUYC)
{
    string sqlSave= " UPDATE phieuxuatkho SET SOPHIEUYC=N'"+ sSOPHIEUYC+ "' WHERE idphieuxuat='"+ this.idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SOPHIEUYC=sSOPHIEUYC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_maphieuxuat(string smaphieuxuat,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET maphieuxuat='N"+smaphieuxuat+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ngaythang(string sngaythang,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET ngaythang='"+sngaythang+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ghichu(string sghichu,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET ghichu='N"+sghichu+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idphongkhambenh(string sidphongkhambenh,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET idphongkhambenh='"+sidphongkhambenh+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_nguoinhan(string snguoinhan,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET nguoinhan='N"+snguoinhan+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_xuatcho(string sxuatcho,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET xuatcho='"+sxuatcho+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idkho(string sidkho,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET idkho='"+sidkho+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_loaixuat(string sloaixuat,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET loaixuat='"+sloaixuat+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IDKhachHang(string sIDKhachHang,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IDKhachHang='"+sIDKhachHang+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_vat(string svat,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET vat='"+svat+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_thanhtien(string sthanhtien,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET thanhtien='"+sthanhtien+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ngayhoadon(string sngayhoadon,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET ngayhoadon='"+sngayhoadon+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idnhacungcap(string sidnhacungcap,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET idnhacungcap='"+sidnhacungcap+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idkho2(string sidkho2,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET idkho2='"+sidkho2+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idnguoixuat(string sidnguoixuat,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET idnguoixuat='"+sidnguoixuat+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IdBenhNhanToaThuoc(string sIdBenhNhanToaThuoc,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IdBenhNhanToaThuoc='"+sIdBenhNhanToaThuoc+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsBHYT(string sIsBHYT,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IsBHYT='"+sIsBHYT+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SLPX(string sSLPX,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET SLPX='"+sSLPX+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tkNo(string stkNo,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET tkNo='"+stkNo+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TKVAT(string sTKVAT,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET TKVAT='"+sTKVAT+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TKCo(string sTKCo,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET TKCo='"+sTKCo+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IdCaPhauThuat(string sIdCaPhauThuat,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IdCaPhauThuat='"+sIdCaPhauThuat+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsDaHuy(string sIsDaHuy,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IsDaHuy='"+sIsDaHuy+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_LANSUA(string sLANSUA,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET LANSUA='"+sLANSUA+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MaPhieu(string sMaPhieu,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET MaPhieu='N"+sMaPhieu+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGAYSUA(string sNGAYSUA,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET NGAYSUA='"+sNGAYSUA+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NGUOISUA(string sNGUOISUA,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET NGUOISUA='"+sNGUOISUA+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IdLoaiThuoc(string sIdLoaiThuoc,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IdLoaiThuoc='"+sIdLoaiThuoc+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IdBenhNhan(string sIdBenhNhan,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IdBenhNhan='"+sIdBenhNhan+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IDKHAMBENH1(string sIDKHAMBENH1,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IDKHAMBENH1='"+sIDKHAMBENH1+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IDPHIEUYC(string sIDPHIEUYC,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET IDPHIEUYC='"+sIDPHIEUYC+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SOPHIEUYC(string sSOPHIEUYC,string s_idphieuxuat)
{
    string sqlSave= " UPDATE phieuxuatkho SET SOPHIEUYC='N"+sSOPHIEUYC+"' WHERE idphieuxuat='"+ s_idphieuxuat+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM phieuxuatkho " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_phieuxuatkho;
   public static bool Change_dt_phieuxuatkho = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_phieuxuatkho()
   {
   if (dt_phieuxuatkho == null || Change_dt_phieuxuatkho == true)
   {
   dt_phieuxuatkho = dtGetAll();
   Change_dt_phieuxuatkho = true && AllowAutoChange ;
   }
   return dt_phieuxuatkho;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

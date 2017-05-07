using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace KB_profess
  { 
 public class khambenhcanlamsan:  Connect { 
 public static string sTableName= "khambenhcanlamsan"; 
   public string idkhambenhcanlamsan;
   public string idkhambenh;
   public string idcanlamsan;
   public string dongia;
   public string idbacsi;
   public string dathu;
   public string dakham;
   public string ngaythu;
   public string idnguoidung;
   public string ngaykham;
   public string idbenhnhan;
   public string tenBSChiDinh;
   public string maphieuCLS;
   public string thucthu;
   public string dahuy;
   public string soluong;
   public string chietkhau;
   public string thanhtien;
   public string IdNguoiThu;
   public string BHTra;
   public string GhiChu;
   public string LoaiKhamID;
   public string idkhoadangky;
   public string NgayQuayLai;
   public string BHYTTra;
   public string BNDaTra;
   public string BNTongPhaiTra;
   public string BNTra;
   public string DonGiaBH;
   public string DonGiaDV;
   public string IsBHYT;
   public string PhuThuBH;
   public string ThanhTienBH;
   public string ThanhTienDV;
   public string ISBNDaTra;
   #region DataColumn Name ;
 public static  string cl_idkhambenhcanlamsan="idkhambenhcanlamsan" ;
 public static  string cl_idkhambenhcanlamsan_VN="idkhambenhcanlamsan";
 public static  string cl_idkhambenh="idkhambenh" ;
 public static  string cl_idkhambenh_VN="idkhambenh";
 public static  string cl_idcanlamsan="idcanlamsan" ;
 public static  string cl_idcanlamsan_VN="idcanlamsan";
 public static  string cl_dongia="dongia" ;
 public static  string cl_dongia_VN="dongia";
 public static  string cl_idbacsi="idbacsi" ;
 public static  string cl_idbacsi_VN="idbacsi";
 public static  string cl_dathu="dathu" ;
 public static  string cl_dathu_VN="dathu";
 public static  string cl_dakham="dakham" ;
 public static  string cl_dakham_VN="dakham";
 public static  string cl_ngaythu="ngaythu" ;
 public static  string cl_ngaythu_VN="ngaythu";
 public static  string cl_idnguoidung="idnguoidung" ;
 public static  string cl_idnguoidung_VN="idnguoidung";
 public static  string cl_ngaykham="ngaykham" ;
 public static  string cl_ngaykham_VN="ngaykham";
 public static  string cl_idbenhnhan="idbenhnhan" ;
 public static  string cl_idbenhnhan_VN="idbenhnhan";
 public static  string cl_tenBSChiDinh="tenBSChiDinh" ;
 public static  string cl_tenBSChiDinh_VN="tenBSChiDinh";
 public static  string cl_maphieuCLS="maphieuCLS" ;
 public static  string cl_maphieuCLS_VN="maphieuCLS";
 public static  string cl_thucthu="thucthu" ;
 public static  string cl_thucthu_VN="thucthu";
 public static  string cl_dahuy="dahuy" ;
 public static  string cl_dahuy_VN="dahuy";
 public static  string cl_soluong="soluong" ;
 public static  string cl_soluong_VN="soluong";
 public static  string cl_chietkhau="chietkhau" ;
 public static  string cl_chietkhau_VN="chietkhau";
 public static  string cl_thanhtien="thanhtien" ;
 public static  string cl_thanhtien_VN="thanhtien";
 public static  string cl_IdNguoiThu="IdNguoiThu" ;
 public static  string cl_IdNguoiThu_VN="IdNguoiThu";
 public static  string cl_BHTra="BHTra" ;
 public static  string cl_BHTra_VN="BHTra";
 public static  string cl_GhiChu="GhiChu" ;
 public static  string cl_GhiChu_VN="GhiChu";
 public static  string cl_LoaiKhamID="LoaiKhamID" ;
 public static  string cl_LoaiKhamID_VN="LoaiKhamID";
 public static  string cl_idkhoadangky="idkhoadangky" ;
 public static  string cl_idkhoadangky_VN="idkhoadangky";
 public static  string cl_NgayQuayLai="NgayQuayLai" ;
 public static  string cl_NgayQuayLai_VN="NgayQuayLai";
 public static  string cl_BHYTTra="BHYTTra" ;
 public static  string cl_BHYTTra_VN="BHYTTra";
 public static  string cl_BNDaTra="BNDaTra" ;
 public static  string cl_BNDaTra_VN="BNDaTra";
 public static  string cl_BNTongPhaiTra="BNTongPhaiTra" ;
 public static  string cl_BNTongPhaiTra_VN="BNTongPhaiTra";
 public static  string cl_BNTra="BNTra" ;
 public static  string cl_BNTra_VN="BNTra";
 public static  string cl_DonGiaBH="DonGiaBH" ;
 public static  string cl_DonGiaBH_VN="DonGiaBH";
 public static  string cl_DonGiaDV="DonGiaDV" ;
 public static  string cl_DonGiaDV_VN="DonGiaDV";
 public static  string cl_IsBHYT="IsBHYT" ;
 public static  string cl_IsBHYT_VN="IsBHYT";
 public static  string cl_PhuThuBH="PhuThuBH" ;
 public static  string cl_PhuThuBH_VN="PhuThuBH";
 public static  string cl_ThanhTienBH="ThanhTienBH" ;
 public static  string cl_ThanhTienBH_VN="ThanhTienBH";
 public static  string cl_ThanhTienDV="ThanhTienDV" ;
 public static  string cl_ThanhTienDV_VN="ThanhTienDV";
 public static  string cl_ISBNDaTra="ISBNDaTra" ;
 public static  string cl_ISBNDaTra_VN="ISBNDaTra";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public khambenhcanlamsan() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public khambenhcanlamsan(
         string sidkhambenhcanlamsan,
         string sidkhambenh,
         string sidcanlamsan,
         string sdongia,
         string sidbacsi,
         string sdathu,
         string sdakham,
         string sngaythu,
         string sidnguoidung,
         string sngaykham,
         string sidbenhnhan,
         string stenBSChiDinh,
         string smaphieuCLS,
         string sthucthu,
         string sdahuy,
         string ssoluong,
         string schietkhau,
         string sthanhtien,
         string sIdNguoiThu,
         string sBHTra,
         string sGhiChu,
         string sLoaiKhamID,
         string sidkhoadangky,
         string sNgayQuayLai,
         string sBHYTTra,
         string sBNDaTra,
         string sBNTongPhaiTra,
         string sBNTra,
         string sDonGiaBH,
         string sDonGiaDV,
         string sIsBHYT,
         string sPhuThuBH,
         string sThanhTienBH,
         string sThanhTienDV,
         string sISBNDaTra){
         this.idkhambenhcanlamsan= sidkhambenhcanlamsan;
         this.idkhambenh= sidkhambenh;
         this.idcanlamsan= sidcanlamsan;
         this.dongia= sdongia;
         this.idbacsi= sidbacsi;
         this.dathu= sdathu;
         this.dakham= sdakham;
         this.ngaythu= sngaythu;
         this.idnguoidung= sidnguoidung;
         this.ngaykham= sngaykham;
         this.idbenhnhan= sidbenhnhan;
         this.tenBSChiDinh= stenBSChiDinh;
         this.maphieuCLS= smaphieuCLS;
         this.thucthu= sthucthu;
         this.dahuy= sdahuy;
         this.soluong= ssoluong;
         this.chietkhau= schietkhau;
         this.thanhtien= sthanhtien;
         this.IdNguoiThu= sIdNguoiThu;
         this.BHTra= sBHTra;
         this.GhiChu= sGhiChu;
         this.LoaiKhamID= sLoaiKhamID;
         this.idkhoadangky= sidkhoadangky;
         this.NgayQuayLai= sNgayQuayLai;
         this.BHYTTra= sBHYTTra;
         this.BNDaTra= sBNDaTra;
         this.BNTongPhaiTra= sBNTongPhaiTra;
         this.BNTra= sBNTra;
         this.DonGiaBH= sDonGiaBH;
         this.DonGiaDV= sDonGiaDV;
         this.IsBHYT= sIsBHYT;
         this.PhuThuBH= sPhuThuBH;
         this.ThanhTienBH= sThanhTienBH;
         this.ThanhTienDV= sThanhTienDV;
         this.ISBNDaTra= sISBNDaTra;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static khambenhcanlamsan Create_khambenhcanlamsan ( string sidkhambenhcanlamsan  ){
    DataTable dt=dtSearchByidkhambenhcanlamsan(sidkhambenhcanlamsan) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new khambenhcanlamsan(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM khambenhcanlamsan AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public khambenhcanlamsan( DataView dv,int pos)
{
         this.idkhambenhcanlamsan= dv[pos][0].ToString();
         this.idkhambenh= dv[pos][1].ToString();
         this.idcanlamsan= dv[pos][2].ToString();
         this.dongia= dv[pos][3].ToString();
         this.idbacsi= dv[pos][4].ToString();
         this.dathu= dv[pos][5].ToString();
         this.dakham= dv[pos][6].ToString();
         this.ngaythu= dv[pos][7].ToString();
         this.idnguoidung= dv[pos][8].ToString();
         this.ngaykham= dv[pos][9].ToString();
         this.idbenhnhan= dv[pos][10].ToString();
         this.tenBSChiDinh= dv[pos][11].ToString();
         this.maphieuCLS= dv[pos][12].ToString();
         this.thucthu= dv[pos][13].ToString();
         this.dahuy= dv[pos][14].ToString();
         this.soluong= dv[pos][15].ToString();
         this.chietkhau= dv[pos][16].ToString();
         this.thanhtien= dv[pos][17].ToString();
         this.IdNguoiThu= dv[pos][18].ToString();
         this.BHTra= dv[pos][19].ToString();
         this.GhiChu= dv[pos][20].ToString();
         this.LoaiKhamID= dv[pos][21].ToString();
         this.idkhoadangky= dv[pos][22].ToString();
         this.NgayQuayLai= dv[pos][23].ToString();
         this.BHYTTra= dv[pos][24].ToString();
         this.BNDaTra= dv[pos][25].ToString();
         this.BNTongPhaiTra= dv[pos][26].ToString();
         this.BNTra= dv[pos][27].ToString();
         this.DonGiaBH= dv[pos][28].ToString();
         this.DonGiaDV= dv[pos][29].ToString();
         this.IsBHYT= dv[pos][30].ToString();
         this.PhuThuBH= dv[pos][31].ToString();
         this.ThanhTienBH= dv[pos][32].ToString();
         this.ThanhTienDV= dv[pos][33].ToString();
         this.ISBNDaTra= dv[pos][34].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkhambenhcanlamsan(string sidkhambenhcanlamsan)
{
          string sqlSelect= s_Select()+ " WHERE idkhambenhcanlamsan  ="+ sidkhambenhcanlamsan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkhambenhcanlamsan(string sidkhambenhcanlamsan,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idkhambenhcanlamsan"+ sMatch +sidkhambenhcanlamsan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkhambenh(string sidkhambenh)
{
          string sqlSelect= s_Select()+ " WHERE idkhambenh  ="+ sidkhambenh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkhambenh(string sidkhambenh,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idkhambenh"+ sMatch +sidkhambenh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidcanlamsan(string sidcanlamsan)
{
          string sqlSelect= s_Select()+ " WHERE idcanlamsan  ="+ sidcanlamsan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidcanlamsan(string sidcanlamsan,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idcanlamsan"+ sMatch +sidcanlamsan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydongia(string sdongia)
{
          string sqlSelect= s_Select()+ " WHERE dongia  ="+ sdongia + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydongia(string sdongia,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE dongia"+ sMatch +sdongia + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidbacsi(string sidbacsi)
{
          string sqlSelect= s_Select()+ " WHERE idbacsi  ="+ sidbacsi + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidbacsi(string sidbacsi,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idbacsi"+ sMatch +sidbacsi + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydathu(string sdathu)
{
          string sqlSelect= s_Select()+ " WHERE dathu  ="+ sdathu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydathu(string sdathu,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE dathu"+ sMatch +sdathu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydakham(string sdakham)
{
          string sqlSelect= s_Select()+ " WHERE dakham  ="+ sdakham + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydakham(string sdakham,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE dakham"+ sMatch +sdakham + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaythu(string sngaythu)
{
          string sqlSelect= s_Select()+ " WHERE ngaythu  ="+ sngaythu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaythu(string sngaythu,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ngaythu"+ sMatch +sngaythu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidnguoidung(string sidnguoidung)
{
          string sqlSelect= s_Select()+ " WHERE idnguoidung  ="+ sidnguoidung + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidnguoidung(string sidnguoidung,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idnguoidung"+ sMatch +sidnguoidung + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaykham(string sngaykham)
{
          string sqlSelect= s_Select()+ " WHERE ngaykham  ="+ sngaykham + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaykham(string sngaykham,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ngaykham"+ sMatch +sngaykham + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidbenhnhan(string sidbenhnhan)
{
          string sqlSelect= s_Select()+ " WHERE idbenhnhan  ="+ sidbenhnhan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidbenhnhan(string sidbenhnhan,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idbenhnhan"+ sMatch +sidbenhnhan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytenBSChiDinh(string stenBSChiDinh)
{
          string sqlSelect= s_Select()+ " WHERE tenBSChiDinh  Like N'%"+ stenBSChiDinh + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBymaphieuCLS(string smaphieuCLS)
{
          string sqlSelect= s_Select()+ " WHERE maphieuCLS  Like N'%"+ smaphieuCLS + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBythucthu(string sthucthu)
{
          string sqlSelect= s_Select()+ " WHERE thucthu  ="+ sthucthu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBythucthu(string sthucthu,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE thucthu"+ sMatch +sthucthu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydahuy(string sdahuy)
{
          string sqlSelect= s_Select()+ " WHERE dahuy  ="+ sdahuy + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydahuy(string sdahuy,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE dahuy"+ sMatch +sdahuy + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysoluong(string ssoluong)
{
          string sqlSelect= s_Select()+ " WHERE soluong  ="+ ssoluong + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysoluong(string ssoluong,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE soluong"+ sMatch +ssoluong + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBychietkhau(string schietkhau)
{
          string sqlSelect= s_Select()+ " WHERE chietkhau  ="+ schietkhau + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBychietkhau(string schietkhau,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE chietkhau"+ sMatch +schietkhau + ""; 
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
 public static DataTable dtSearchByIdNguoiThu(string sIdNguoiThu)
{
          string sqlSelect= s_Select()+ " WHERE IdNguoiThu  ="+ sIdNguoiThu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdNguoiThu(string sIdNguoiThu,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdNguoiThu"+ sMatch +sIdNguoiThu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBHTra(string sBHTra)
{
          string sqlSelect= s_Select()+ " WHERE BHTra  ="+ sBHTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBHTra(string sBHTra,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BHTra"+ sMatch +sBHTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByGhiChu(string sGhiChu)
{
          string sqlSelect= s_Select()+ " WHERE GhiChu  Like N'%"+ sGhiChu + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLoaiKhamID(string sLoaiKhamID)
{
          string sqlSelect= s_Select()+ " WHERE LoaiKhamID  ="+ sLoaiKhamID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLoaiKhamID(string sLoaiKhamID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE LoaiKhamID"+ sMatch +sLoaiKhamID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkhoadangky(string sidkhoadangky)
{
          string sqlSelect= s_Select()+ " WHERE idkhoadangky  ="+ sidkhoadangky + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidkhoadangky(string sidkhoadangky,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idkhoadangky"+ sMatch +sidkhoadangky + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayQuayLai(string sNgayQuayLai)
{
          string sqlSelect= s_Select()+ " WHERE NgayQuayLai  ="+ sNgayQuayLai + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayQuayLai(string sNgayQuayLai,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NgayQuayLai"+ sMatch +sNgayQuayLai + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBHYTTra(string sBHYTTra)
{
          string sqlSelect= s_Select()+ " WHERE BHYTTra  ="+ sBHYTTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBHYTTra(string sBHYTTra,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BHYTTra"+ sMatch +sBHYTTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBNDaTra(string sBNDaTra)
{
          string sqlSelect= s_Select()+ " WHERE BNDaTra  ="+ sBNDaTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBNDaTra(string sBNDaTra,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BNDaTra"+ sMatch +sBNDaTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBNTongPhaiTra(string sBNTongPhaiTra)
{
          string sqlSelect= s_Select()+ " WHERE BNTongPhaiTra  ="+ sBNTongPhaiTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBNTongPhaiTra(string sBNTongPhaiTra,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BNTongPhaiTra"+ sMatch +sBNTongPhaiTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBNTra(string sBNTra)
{
          string sqlSelect= s_Select()+ " WHERE BNTra  ="+ sBNTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBNTra(string sBNTra,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BNTra"+ sMatch +sBNTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDonGiaBH(string sDonGiaBH)
{
          string sqlSelect= s_Select()+ " WHERE DonGiaBH  ="+ sDonGiaBH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDonGiaBH(string sDonGiaBH,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DonGiaBH"+ sMatch +sDonGiaBH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDonGiaDV(string sDonGiaDV)
{
          string sqlSelect= s_Select()+ " WHERE DonGiaDV  ="+ sDonGiaDV + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDonGiaDV(string sDonGiaDV,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DonGiaDV"+ sMatch +sDonGiaDV + ""; 
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
 public static DataTable dtSearchByPhuThuBH(string sPhuThuBH)
{
          string sqlSelect= s_Select()+ " WHERE PhuThuBH  ="+ sPhuThuBH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPhuThuBH(string sPhuThuBH,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PhuThuBH"+ sMatch +sPhuThuBH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByThanhTienBH(string sThanhTienBH)
{
          string sqlSelect= s_Select()+ " WHERE ThanhTienBH  ="+ sThanhTienBH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByThanhTienBH(string sThanhTienBH,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ThanhTienBH"+ sMatch +sThanhTienBH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByThanhTienDV(string sThanhTienDV)
{
          string sqlSelect= s_Select()+ " WHERE ThanhTienDV  ="+ sThanhTienDV + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByThanhTienDV(string sThanhTienDV,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ThanhTienDV"+ sMatch +sThanhTienDV + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByISBNDaTra(string sISBNDaTra)
{
          string sqlSelect= s_Select()+ " WHERE ISBNDaTra  ="+ sISBNDaTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByISBNDaTra(string sISBNDaTra,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ISBNDaTra"+ sMatch +sISBNDaTra + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sidkhambenhcanlamsan
            , string sidkhambenh
            , string sidcanlamsan
            , string sdongia
            , string sidbacsi
            , string sdathu
            , string sdakham
            , string sngaythu
            , string sidnguoidung
            , string sngaykham
            , string sidbenhnhan
            , string stenBSChiDinh
            , string smaphieuCLS
            , string sthucthu
            , string sdahuy
            , string ssoluong
            , string schietkhau
            , string sthanhtien
            , string sIdNguoiThu
            , string sBHTra
            , string sGhiChu
            , string sLoaiKhamID
            , string sidkhoadangky
            , string sNgayQuayLai
            , string sBHYTTra
            , string sBNDaTra
            , string sBNTongPhaiTra
            , string sBNTra
            , string sDonGiaBH
            , string sDonGiaDV
            , string sIsBHYT
            , string sPhuThuBH
            , string sThanhTienBH
            , string sThanhTienDV
            , string sISBNDaTra
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sidkhambenhcanlamsan!=null && sidkhambenhcanlamsan!="") 
            sqlselect +=" AND idkhambenhcanlamsan =" + sidkhambenhcanlamsan ;
      if (sidkhambenh!=null && sidkhambenh!="") 
            sqlselect +=" AND idkhambenh =" + sidkhambenh ;
      if (sidcanlamsan!=null && sidcanlamsan!="") 
            sqlselect +=" AND idcanlamsan =" + sidcanlamsan ;
      if (sdongia!=null && sdongia!="") 
            sqlselect +=" AND dongia =" + sdongia ;
      if (sidbacsi!=null && sidbacsi!="") 
            sqlselect +=" AND idbacsi =" + sidbacsi ;
      if (sdathu!=null && sdathu!="") 
            sqlselect +=" AND dathu =" + sdathu ;
      if (sdakham!=null && sdakham!="") 
            sqlselect +=" AND dakham =" + sdakham ;
      if (sngaythu!=null && sngaythu!="") 
            sqlselect +=" AND ngaythu LIKE '%" + sngaythu +"%'" ;
      if (sidnguoidung!=null && sidnguoidung!="") 
            sqlselect +=" AND idnguoidung =" + sidnguoidung ;
      if (sngaykham!=null && sngaykham!="") 
            sqlselect +=" AND ngaykham LIKE '%" + sngaykham +"%'" ;
      if (sidbenhnhan!=null && sidbenhnhan!="") 
            sqlselect +=" AND idbenhnhan =" + sidbenhnhan ;
      if (stenBSChiDinh!=null && stenBSChiDinh!="") 
            sqlselect +=" AND tenBSChiDinh LIKE N'%" + stenBSChiDinh +"%'" ;
      if (smaphieuCLS!=null && smaphieuCLS!="") 
            sqlselect +=" AND maphieuCLS LIKE N'%" + smaphieuCLS +"%'" ;
      if (sthucthu!=null && sthucthu!="") 
            sqlselect +=" AND thucthu =" + sthucthu ;
      if (sdahuy!=null && sdahuy!="") 
            sqlselect +=" AND dahuy =" + sdahuy ;
      if (ssoluong!=null && ssoluong!="") 
            sqlselect +=" AND soluong =" + ssoluong ;
      if (schietkhau!=null && schietkhau!="") 
            sqlselect +=" AND chietkhau =" + schietkhau ;
      if (sthanhtien!=null && sthanhtien!="") 
            sqlselect +=" AND thanhtien =" + sthanhtien ;
      if (sIdNguoiThu!=null && sIdNguoiThu!="") 
            sqlselect +=" AND IdNguoiThu =" + sIdNguoiThu ;
      if (sBHTra!=null && sBHTra!="") 
            sqlselect +=" AND BHTra =" + sBHTra ;
      if (sGhiChu!=null && sGhiChu!="") 
            sqlselect +=" AND GhiChu LIKE N'%" + sGhiChu +"%'" ;
      if (sLoaiKhamID!=null && sLoaiKhamID!="") 
            sqlselect +=" AND LoaiKhamID =" + sLoaiKhamID ;
      if (sidkhoadangky!=null && sidkhoadangky!="") 
            sqlselect +=" AND idkhoadangky =" + sidkhoadangky ;
      if (sNgayQuayLai!=null && sNgayQuayLai!="") 
            sqlselect +=" AND NgayQuayLai LIKE '%" + sNgayQuayLai +"%'" ;
      if (sBHYTTra!=null && sBHYTTra!="") 
            sqlselect +=" AND BHYTTra =" + sBHYTTra ;
      if (sBNDaTra!=null && sBNDaTra!="") 
            sqlselect +=" AND BNDaTra =" + sBNDaTra ;
      if (sBNTongPhaiTra!=null && sBNTongPhaiTra!="") 
            sqlselect +=" AND BNTongPhaiTra =" + sBNTongPhaiTra ;
      if (sBNTra!=null && sBNTra!="") 
            sqlselect +=" AND BNTra =" + sBNTra ;
      if (sDonGiaBH!=null && sDonGiaBH!="") 
            sqlselect +=" AND DonGiaBH =" + sDonGiaBH ;
      if (sDonGiaDV!=null && sDonGiaDV!="") 
            sqlselect +=" AND DonGiaDV =" + sDonGiaDV ;
      if (sIsBHYT!=null && sIsBHYT!="") 
            sqlselect +=" AND IsBHYT =" + sIsBHYT ;
      if (sPhuThuBH!=null && sPhuThuBH!="") 
            sqlselect +=" AND PhuThuBH =" + sPhuThuBH ;
      if (sThanhTienBH!=null && sThanhTienBH!="") 
            sqlselect +=" AND ThanhTienBH =" + sThanhTienBH ;
      if (sThanhTienDV!=null && sThanhTienDV!="") 
            sqlselect +=" AND ThanhTienDV =" + sThanhTienDV ;
      if (sISBNDaTra!=null && sISBNDaTra!="") 
            sqlselect +=" AND ISBNDaTra =" + sISBNDaTra ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static khambenhcanlamsan Insert_Object(
string  sidkhambenh
            ,string  sidcanlamsan
            ,string  sdongia
            ,string  sidbacsi
            ,string  sdathu
            ,string  sdakham
            ,string  sngaythu
            ,string  sidnguoidung
            ,string  sngaykham
            ,string  sidbenhnhan
            ,string  stenBSChiDinh
            ,string  smaphieuCLS
            ,string  sthucthu
            ,string  sdahuy
            ,string  ssoluong
            ,string  schietkhau
            ,string  sthanhtien
            ,string  sIdNguoiThu
            ,string  sBHTra
            ,string  sGhiChu
            ,string  sLoaiKhamID
            ,string  sidkhoadangky
            ,string  sNgayQuayLai
            ,string  sBHYTTra
            ,string  sBNDaTra
            ,string  sBNTongPhaiTra
            ,string  sBNTra
            ,string  sDonGiaBH
            ,string  sDonGiaDV
            ,string  sIsBHYT
            ,string  sPhuThuBH
            ,string  sThanhTienBH
            ,string  sThanhTienDV
            ,string  sISBNDaTra
            ) 
 { 
              string tem_sidkhambenh=DataAcess.hsSqlTool.sGetSaveValue(sidkhambenh,"int");
              string tem_sidcanlamsan=DataAcess.hsSqlTool.sGetSaveValue(sidcanlamsan,"int");
              string tem_sdongia=DataAcess.hsSqlTool.sGetSaveValue(sdongia,"float");
              string tem_sidbacsi=DataAcess.hsSqlTool.sGetSaveValue(sidbacsi,"int");
              string tem_sdathu=DataAcess.hsSqlTool.sGetSaveValue(sdathu,"tinyint");
              string tem_sdakham=DataAcess.hsSqlTool.sGetSaveValue(sdakham,"tinyint");
              string tem_sngaythu=DataAcess.hsSqlTool.sGetSaveValue(sngaythu,"datetime");
              string tem_sidnguoidung=DataAcess.hsSqlTool.sGetSaveValue(sidnguoidung,"int");
              string tem_sngaykham=DataAcess.hsSqlTool.sGetSaveValue(sngaykham,"datetime");
              string tem_sidbenhnhan=DataAcess.hsSqlTool.sGetSaveValue(sidbenhnhan,"int");
              string tem_stenBSChiDinh=DataAcess.hsSqlTool.sGetSaveValue(stenBSChiDinh,"nvarchar");
              string tem_smaphieuCLS=DataAcess.hsSqlTool.sGetSaveValue(smaphieuCLS,"nvarchar");
              string tem_sthucthu=DataAcess.hsSqlTool.sGetSaveValue(sthucthu,"bit");
              string tem_sdahuy=DataAcess.hsSqlTool.sGetSaveValue(sdahuy,"bit");
              string tem_ssoluong=DataAcess.hsSqlTool.sGetSaveValue(ssoluong,"int");
              string tem_schietkhau=DataAcess.hsSqlTool.sGetSaveValue(schietkhau,"int");
              string tem_sthanhtien=DataAcess.hsSqlTool.sGetSaveValue(sthanhtien,"bigint");
              string tem_sIdNguoiThu=DataAcess.hsSqlTool.sGetSaveValue(sIdNguoiThu,"bigint");
              string tem_sBHTra=DataAcess.hsSqlTool.sGetSaveValue(sBHTra,"int");
              string tem_sGhiChu=DataAcess.hsSqlTool.sGetSaveValue(sGhiChu,"nvarchar");
              string tem_sLoaiKhamID=DataAcess.hsSqlTool.sGetSaveValue(sLoaiKhamID,"bigint");
              string tem_sidkhoadangky=DataAcess.hsSqlTool.sGetSaveValue(sidkhoadangky,"bigint");
              string tem_sNgayQuayLai=DataAcess.hsSqlTool.sGetSaveValue(sNgayQuayLai,"smalldatetime");
              string tem_sBHYTTra=DataAcess.hsSqlTool.sGetSaveValue(sBHYTTra,"float");
              string tem_sBNDaTra=DataAcess.hsSqlTool.sGetSaveValue(sBNDaTra,"float");
              string tem_sBNTongPhaiTra=DataAcess.hsSqlTool.sGetSaveValue(sBNTongPhaiTra,"float");
              string tem_sBNTra=DataAcess.hsSqlTool.sGetSaveValue(sBNTra,"float");
              string tem_sDonGiaBH=DataAcess.hsSqlTool.sGetSaveValue(sDonGiaBH,"float");
              string tem_sDonGiaDV=DataAcess.hsSqlTool.sGetSaveValue(sDonGiaDV,"float");
              string tem_sIsBHYT=DataAcess.hsSqlTool.sGetSaveValue(sIsBHYT,"bit");
              string tem_sPhuThuBH=DataAcess.hsSqlTool.sGetSaveValue(sPhuThuBH,"float");
              string tem_sThanhTienBH=DataAcess.hsSqlTool.sGetSaveValue(sThanhTienBH,"float");
              string tem_sThanhTienDV=DataAcess.hsSqlTool.sGetSaveValue(sThanhTienDV,"float");
              string tem_sISBNDaTra=DataAcess.hsSqlTool.sGetSaveValue(sISBNDaTra,"bit");

              string sqlSave = " INSERT INTO khambenhcanlamsan(" + "\r\n"
        + "idkhambenh," + "\r\n"
        + "idcanlamsan," + "\r\n"
        +                   "dongia," + "\r\n"
        +                   "idbacsi," + "\r\n"
        +                   "dathu," + "\r\n"
        +                   "dakham," + "\r\n"
        +                   "ngaythu," + "\r\n"
        +                   "idnguoidung," + "\r\n"
        +                   "ngaykham," + "\r\n"
        +                   "idbenhnhan," + "\r\n"
        +                   "tenBSChiDinh," + "\r\n"
        +                   "maphieuCLS," + "\r\n"
        +                   "thucthu," + "\r\n"
        +                   "dahuy," + "\r\n"
        +                   "soluong," + "\r\n"
        +                   "chietkhau," + "\r\n"
        +                   "thanhtien," + "\r\n"
        +                   "IdNguoiThu," + "\r\n"
        +                   "BHTra," + "\r\n"
        +                   "GhiChu," + "\r\n"
        +                   "LoaiKhamID," + "\r\n"
        +                   "idkhoadangky," + "\r\n"
        +                   "NgayQuayLai," + "\r\n"
        +                   "BHYTTra," + "\r\n"
        +                   "BNDaTra," + "\r\n"
        +                   "BNTongPhaiTra," + "\r\n"
        +                   "BNTra," + "\r\n"
        +                   "DonGiaBH," + "\r\n"
        +                   "DonGiaDV," + "\r\n"
        +                   "IsBHYT," + "\r\n"
        +                   "PhuThuBH," + "\r\n"
        +                   "ThanhTienBH," + "\r\n"
        +                   "ThanhTienDV," + "\r\n"
        +                   "ISBNDaTra) VALUES("
 +tem_sidkhambenh+","+"\r\n"
 +tem_sidcanlamsan+","+"\r\n"
 +tem_sdongia+","+"\r\n"
 +tem_sidbacsi+","+"\r\n"
 +tem_sdathu+","+"\r\n"
 +tem_sdakham+","+"\r\n"
 +tem_sngaythu+","+"\r\n"
 +tem_sidnguoidung+","+"\r\n"
 +tem_sngaykham+","+"\r\n"
 +tem_sidbenhnhan+","+"\r\n"
 +tem_stenBSChiDinh+","+"\r\n"
 +tem_smaphieuCLS+","+"\r\n"
 +tem_sthucthu+","+"\r\n"
 +tem_sdahuy+","+"\r\n"
 +tem_ssoluong+","+"\r\n"
 +tem_schietkhau+","+"\r\n"
 +tem_sthanhtien+","+"\r\n"
 +tem_sIdNguoiThu+","+"\r\n"
 +tem_sBHTra+","+"\r\n"
 +tem_sGhiChu+","+"\r\n"
 +tem_sLoaiKhamID+","+"\r\n"
 +tem_sidkhoadangky+","+"\r\n"
 +tem_sNgayQuayLai+","+"\r\n"
 +tem_sBHYTTra+","+"\r\n"
 +tem_sBNDaTra+","+"\r\n"
 +tem_sBNTongPhaiTra+","+"\r\n"
 +tem_sBNTra+","+"\r\n"
 +tem_sDonGiaBH+","+"\r\n"
 +tem_sDonGiaDV+","+"\r\n"
 +tem_sIsBHYT+","+"\r\n"
 +tem_sPhuThuBH+","+"\r\n"
 +tem_sThanhTienBH+","+"\r\n"
 +tem_sThanhTienDV+","+"\r\n"
 +tem_sISBNDaTra +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          khambenhcanlamsan newkhambenhcanlamsan= new khambenhcanlamsan();
                 newkhambenhcanlamsan.idkhambenhcanlamsan=GetTable( " SELECT TOP 1 idkhambenhcanlamsan FROM khambenhcanlamsan ORDER BY idkhambenhcanlamsan DESC ").Rows[0][0].ToString();
              newkhambenhcanlamsan.idkhambenh=sidkhambenh;
              newkhambenhcanlamsan.idcanlamsan=sidcanlamsan;
              newkhambenhcanlamsan.dongia=sdongia;
              newkhambenhcanlamsan.idbacsi=sidbacsi;
              newkhambenhcanlamsan.dathu=sdathu;
              newkhambenhcanlamsan.dakham=sdakham;
              newkhambenhcanlamsan.ngaythu=sngaythu;
              newkhambenhcanlamsan.idnguoidung=sidnguoidung;
              newkhambenhcanlamsan.ngaykham=sngaykham;
              newkhambenhcanlamsan.idbenhnhan=sidbenhnhan;
              newkhambenhcanlamsan.tenBSChiDinh=stenBSChiDinh;
              newkhambenhcanlamsan.maphieuCLS=smaphieuCLS;
              newkhambenhcanlamsan.thucthu=sthucthu;
              newkhambenhcanlamsan.dahuy=sdahuy;
              newkhambenhcanlamsan.soluong=ssoluong;
              newkhambenhcanlamsan.chietkhau=schietkhau;
              newkhambenhcanlamsan.thanhtien=sthanhtien;
              newkhambenhcanlamsan.IdNguoiThu=sIdNguoiThu;
              newkhambenhcanlamsan.BHTra=sBHTra;
              newkhambenhcanlamsan.GhiChu=sGhiChu;
              newkhambenhcanlamsan.LoaiKhamID=sLoaiKhamID;
              newkhambenhcanlamsan.idkhoadangky=sidkhoadangky;
              newkhambenhcanlamsan.NgayQuayLai=sNgayQuayLai;
              newkhambenhcanlamsan.BHYTTra=sBHYTTra;
              newkhambenhcanlamsan.BNDaTra=sBNDaTra;
              newkhambenhcanlamsan.BNTongPhaiTra=sBNTongPhaiTra;
              newkhambenhcanlamsan.BNTra=sBNTra;
              newkhambenhcanlamsan.DonGiaBH=sDonGiaBH;
              newkhambenhcanlamsan.DonGiaDV=sDonGiaDV;
              newkhambenhcanlamsan.IsBHYT=sIsBHYT;
              newkhambenhcanlamsan.PhuThuBH=sPhuThuBH;
              newkhambenhcanlamsan.ThanhTienBH=sThanhTienBH;
              newkhambenhcanlamsan.ThanhTienDV=sThanhTienDV;
              newkhambenhcanlamsan.ISBNDaTra=sISBNDaTra;
            return newkhambenhcanlamsan; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sidkhambenh
                ,string sidcanlamsan
                ,string sdongia
                ,string sidbacsi
                ,string sdathu
                ,string sdakham
                ,string sngaythu
                ,string sidnguoidung
                ,string sngaykham
                ,string sidbenhnhan
                ,string stenBSChiDinh
                ,string smaphieuCLS
                ,string sthucthu
                ,string sdahuy
                ,string ssoluong
                ,string schietkhau
                ,string sthanhtien
                ,string sIdNguoiThu
                ,string sBHTra
                ,string sGhiChu
                ,string sLoaiKhamID
                ,string sidkhoadangky
                ,string sNgayQuayLai
                ,string sBHYTTra
                ,string sBNDaTra
                ,string sBNTongPhaiTra
                ,string sBNTra
                ,string sDonGiaBH
                ,string sDonGiaDV
                ,string sIsBHYT
                ,string sPhuThuBH
                ,string sThanhTienBH
                ,string sThanhTienDV
                ,string sISBNDaTra
                ) 
 { 
              string tem_sidkhambenh=DataAcess.hsSqlTool.sGetSaveValue(sidkhambenh,"int");
              string tem_sidcanlamsan=DataAcess.hsSqlTool.sGetSaveValue(sidcanlamsan,"int");
              string tem_sdongia=DataAcess.hsSqlTool.sGetSaveValue(sdongia,"float");
              string tem_sidbacsi=DataAcess.hsSqlTool.sGetSaveValue(sidbacsi,"int");
              string tem_sdathu=DataAcess.hsSqlTool.sGetSaveValue(sdathu,"tinyint");
              string tem_sdakham=DataAcess.hsSqlTool.sGetSaveValue(sdakham,"tinyint");
              string tem_sngaythu=DataAcess.hsSqlTool.sGetSaveValue(sngaythu,"datetime");
              string tem_sidnguoidung=DataAcess.hsSqlTool.sGetSaveValue(sidnguoidung,"int");
              string tem_sngaykham=DataAcess.hsSqlTool.sGetSaveValue(sngaykham,"datetime");
              string tem_sidbenhnhan=DataAcess.hsSqlTool.sGetSaveValue(sidbenhnhan,"int");
              string tem_stenBSChiDinh=DataAcess.hsSqlTool.sGetSaveValue(stenBSChiDinh,"nvarchar");
              string tem_smaphieuCLS=DataAcess.hsSqlTool.sGetSaveValue(smaphieuCLS,"nvarchar");
              string tem_sthucthu=DataAcess.hsSqlTool.sGetSaveValue(sthucthu,"bit");
              string tem_sdahuy=DataAcess.hsSqlTool.sGetSaveValue(sdahuy,"bit");
              string tem_ssoluong=DataAcess.hsSqlTool.sGetSaveValue(ssoluong,"int");
              string tem_schietkhau=DataAcess.hsSqlTool.sGetSaveValue(schietkhau,"int");
              string tem_sthanhtien=DataAcess.hsSqlTool.sGetSaveValue(sthanhtien,"bigint");
              string tem_sIdNguoiThu=DataAcess.hsSqlTool.sGetSaveValue(sIdNguoiThu,"bigint");
              string tem_sBHTra=DataAcess.hsSqlTool.sGetSaveValue(sBHTra,"int");
              string tem_sGhiChu=DataAcess.hsSqlTool.sGetSaveValue(sGhiChu,"nvarchar");
              string tem_sLoaiKhamID=DataAcess.hsSqlTool.sGetSaveValue(sLoaiKhamID,"bigint");
              string tem_sidkhoadangky=DataAcess.hsSqlTool.sGetSaveValue(sidkhoadangky,"bigint");
              string tem_sNgayQuayLai=DataAcess.hsSqlTool.sGetSaveValue(sNgayQuayLai,"smalldatetime");
              string tem_sBHYTTra=DataAcess.hsSqlTool.sGetSaveValue(sBHYTTra,"float");
              string tem_sBNDaTra=DataAcess.hsSqlTool.sGetSaveValue(sBNDaTra,"float");
              string tem_sBNTongPhaiTra=DataAcess.hsSqlTool.sGetSaveValue(sBNTongPhaiTra,"float");
              string tem_sBNTra=DataAcess.hsSqlTool.sGetSaveValue(sBNTra,"float");
              string tem_sDonGiaBH=DataAcess.hsSqlTool.sGetSaveValue(sDonGiaBH,"float");
              string tem_sDonGiaDV=DataAcess.hsSqlTool.sGetSaveValue(sDonGiaDV,"float");
              string tem_sIsBHYT=DataAcess.hsSqlTool.sGetSaveValue(sIsBHYT,"bit");
              string tem_sPhuThuBH=DataAcess.hsSqlTool.sGetSaveValue(sPhuThuBH,"float");
              string tem_sThanhTienBH=DataAcess.hsSqlTool.sGetSaveValue(sThanhTienBH,"float");
              string tem_sThanhTienDV=DataAcess.hsSqlTool.sGetSaveValue(sThanhTienDV,"float");
              string tem_sISBNDaTra=DataAcess.hsSqlTool.sGetSaveValue(sISBNDaTra,"bit");

 string sqlSave=" UPDATE khambenhcanlamsan SET "+"idkhambenh ="+tem_sidkhambenh+","+"\r\n"
 +"idcanlamsan ="+tem_sidcanlamsan+","+"\r\n"
 +"dongia ="+tem_sdongia+","+"\r\n"
 +"idbacsi ="+tem_sidbacsi+","+"\r\n"
 +"dathu ="+tem_sdathu+","+"\r\n"
 +"dakham ="+tem_sdakham+","+"\r\n"
 +"ngaythu ="+tem_sngaythu+","+"\r\n"
 +"idnguoidung ="+tem_sidnguoidung+","+"\r\n"
 +"ngaykham ="+tem_sngaykham+","+"\r\n"
 +"idbenhnhan ="+tem_sidbenhnhan+","+"\r\n"
 +"tenBSChiDinh ="+tem_stenBSChiDinh+","+"\r\n"
 +"maphieuCLS ="+tem_smaphieuCLS+","+"\r\n"
 +"thucthu ="+tem_sthucthu+","+"\r\n"
 +"dahuy ="+tem_sdahuy+","+"\r\n"
 +"soluong ="+tem_ssoluong+","+"\r\n"
 +"chietkhau ="+tem_schietkhau+","+"\r\n"
 +"thanhtien ="+tem_sthanhtien+","+"\r\n"
 +"IdNguoiThu ="+tem_sIdNguoiThu+","+"\r\n"
 +"BHTra ="+tem_sBHTra+","+"\r\n"
 +"GhiChu ="+tem_sGhiChu+","+"\r\n"
 +"LoaiKhamID ="+tem_sLoaiKhamID+","+"\r\n"
 +"idkhoadangky ="+tem_sidkhoadangky+","+"\r\n"
 +"NgayQuayLai ="+tem_sNgayQuayLai+","+"\r\n"
 +"BHYTTra ="+tem_sBHYTTra+","+"\r\n"
 +"BNDaTra ="+tem_sBNDaTra+","+"\r\n"
 +"BNTongPhaiTra ="+tem_sBNTongPhaiTra+","+"\r\n"
 +"BNTra ="+tem_sBNTra+","+"\r\n"
 +"DonGiaBH ="+tem_sDonGiaBH+","+"\r\n"
 +"DonGiaDV ="+tem_sDonGiaDV+","+"\r\n"
 +"IsBHYT ="+tem_sIsBHYT+","+"\r\n"
 +"PhuThuBH ="+tem_sPhuThuBH+","+"\r\n"
 +"ThanhTienBH ="+tem_sThanhTienBH+","+"\r\n"
 +"ThanhTienDV ="+tem_sThanhTienDV+","+"\r\n"
 +"ISBNDaTra ="+tem_sISBNDaTra+" WHERE idkhambenhcanlamsan="+DataAcess.hsSqlTool.sGetSaveValue(this.idkhambenhcanlamsan,"int identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.idkhambenh=sidkhambenh;
                this.idcanlamsan=sidcanlamsan;
                this.dongia=sdongia;
                this.idbacsi=sidbacsi;
                this.dathu=sdathu;
                this.dakham=sdakham;
                this.ngaythu=sngaythu;
                this.idnguoidung=sidnguoidung;
                this.ngaykham=sngaykham;
                this.idbenhnhan=sidbenhnhan;
                this.tenBSChiDinh=stenBSChiDinh;
                this.maphieuCLS=smaphieuCLS;
                this.thucthu=sthucthu;
                this.dahuy=sdahuy;
                this.soluong=ssoluong;
                this.chietkhau=schietkhau;
                this.thanhtien=sthanhtien;
                this.IdNguoiThu=sIdNguoiThu;
                this.BHTra=sBHTra;
                this.GhiChu=sGhiChu;
                this.LoaiKhamID=sLoaiKhamID;
                this.idkhoadangky=sidkhoadangky;
                this.NgayQuayLai=sNgayQuayLai;
                this.BHYTTra=sBHYTTra;
                this.BNDaTra=sBNDaTra;
                this.BNTongPhaiTra=sBNTongPhaiTra;
                this.BNTra=sBNTra;
                this.DonGiaBH=sDonGiaBH;
                this.DonGiaDV=sDonGiaDV;
                this.IsBHYT=sIsBHYT;
                this.PhuThuBH=sPhuThuBH;
                this.ThanhTienBH=sThanhTienBH;
                this.ThanhTienDV=sThanhTienDV;
                this.ISBNDaTra=sISBNDaTra;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_idkhambenhcanlamsan(string sidkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idkhambenhcanlamsan='"+ sidkhambenhcanlamsan+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idkhambenhcanlamsan=sidkhambenhcanlamsan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idkhambenh(string sidkhambenh)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idkhambenh='"+ sidkhambenh+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idkhambenh=sidkhambenh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idcanlamsan(string sidcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idcanlamsan='"+ sidcanlamsan+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idcanlamsan=sidcanlamsan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_dongia(string sdongia)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET dongia='"+ sdongia+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dongia=sdongia;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idbacsi(string sidbacsi)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idbacsi='"+ sidbacsi+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idbacsi=sidbacsi;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_dathu(string sdathu)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET dathu='"+ sdathu+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dathu=sdathu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_dakham(string sdakham)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET dakham='"+ sdakham+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dakham=sdakham;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ngaythu(string sngaythu)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ngaythu='"+ sngaythu+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ngaythu=sngaythu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idnguoidung(string sidnguoidung)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idnguoidung='"+ sidnguoidung+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idnguoidung=sidnguoidung;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ngaykham(string sngaykham)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ngaykham='"+ sngaykham+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ngaykham=sngaykham;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idbenhnhan(string sidbenhnhan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idbenhnhan='"+ sidbenhnhan+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idbenhnhan=sidbenhnhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tenBSChiDinh(string stenBSChiDinh)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET tenBSChiDinh=N'"+ stenBSChiDinh+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tenBSChiDinh=stenBSChiDinh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_maphieuCLS(string smaphieuCLS)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET maphieuCLS=N'"+ smaphieuCLS+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.maphieuCLS=smaphieuCLS;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_thucthu(string sthucthu)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET thucthu='"+ sthucthu+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.thucthu=sthucthu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_dahuy(string sdahuy)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET dahuy='"+ sdahuy+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dahuy=sdahuy;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_soluong(string ssoluong)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET soluong='"+ ssoluong+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.soluong=ssoluong;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_chietkhau(string schietkhau)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET chietkhau='"+ schietkhau+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.chietkhau=schietkhau;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_thanhtien(string sthanhtien)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET thanhtien='"+ sthanhtien+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.thanhtien=sthanhtien;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdNguoiThu(string sIdNguoiThu)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET IdNguoiThu='"+ sIdNguoiThu+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IdNguoiThu=sIdNguoiThu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BHTra(string sBHTra)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BHTra='"+ sBHTra+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.BHTra=sBHTra;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GhiChu(string sGhiChu)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET GhiChu=N'"+ sGhiChu+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.GhiChu=sGhiChu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_LoaiKhamID(string sLoaiKhamID)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET LoaiKhamID='"+ sLoaiKhamID+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.LoaiKhamID=sLoaiKhamID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idkhoadangky(string sidkhoadangky)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idkhoadangky='"+ sidkhoadangky+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idkhoadangky=sidkhoadangky;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NgayQuayLai(string sNgayQuayLai)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET NgayQuayLai='"+ sNgayQuayLai+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NgayQuayLai=sNgayQuayLai;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BHYTTra(string sBHYTTra)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BHYTTra='"+ sBHYTTra+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.BHYTTra=sBHYTTra;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BNDaTra(string sBNDaTra)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BNDaTra='"+ sBNDaTra+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.BNDaTra=sBNDaTra;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BNTongPhaiTra(string sBNTongPhaiTra)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BNTongPhaiTra='"+ sBNTongPhaiTra+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.BNTongPhaiTra=sBNTongPhaiTra;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BNTra(string sBNTra)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BNTra='"+ sBNTra+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.BNTra=sBNTra;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DonGiaBH(string sDonGiaBH)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET DonGiaBH='"+ sDonGiaBH+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DonGiaBH=sDonGiaBH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DonGiaDV(string sDonGiaDV)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET DonGiaDV='"+ sDonGiaDV+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DonGiaDV=sDonGiaDV;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsBHYT(string sIsBHYT)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET IsBHYT='"+ sIsBHYT+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IsBHYT=sIsBHYT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PhuThuBH(string sPhuThuBH)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET PhuThuBH='"+ sPhuThuBH+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.PhuThuBH=sPhuThuBH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ThanhTienBH(string sThanhTienBH)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ThanhTienBH='"+ sThanhTienBH+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ThanhTienBH=sThanhTienBH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ThanhTienDV(string sThanhTienDV)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ThanhTienDV='"+ sThanhTienDV+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ThanhTienDV=sThanhTienDV;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ISBNDaTra(string sISBNDaTra)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ISBNDaTra='"+ sISBNDaTra+ "' WHERE idkhambenhcanlamsan='"+ this.idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ISBNDaTra=sISBNDaTra;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_idkhambenh(string sidkhambenh,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idkhambenh='"+sidkhambenh+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idcanlamsan(string sidcanlamsan,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idcanlamsan='"+sidcanlamsan+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dongia(string sdongia,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET dongia='"+sdongia+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idbacsi(string sidbacsi,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idbacsi='"+sidbacsi+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dathu(string sdathu,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET dathu='"+sdathu+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dakham(string sdakham,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET dakham='"+sdakham+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ngaythu(string sngaythu,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ngaythu='"+sngaythu+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idnguoidung(string sidnguoidung,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idnguoidung='"+sidnguoidung+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ngaykham(string sngaykham,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ngaykham='"+sngaykham+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idbenhnhan(string sidbenhnhan,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idbenhnhan='"+sidbenhnhan+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tenBSChiDinh(string stenBSChiDinh,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET tenBSChiDinh='N"+stenBSChiDinh+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_maphieuCLS(string smaphieuCLS,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET maphieuCLS='N"+smaphieuCLS+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_thucthu(string sthucthu,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET thucthu='"+sthucthu+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dahuy(string sdahuy,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET dahuy='"+sdahuy+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_soluong(string ssoluong,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET soluong='"+ssoluong+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_chietkhau(string schietkhau,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET chietkhau='"+schietkhau+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_thanhtien(string sthanhtien,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET thanhtien='"+sthanhtien+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IdNguoiThu(string sIdNguoiThu,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET IdNguoiThu='"+sIdNguoiThu+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BHTra(string sBHTra,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BHTra='"+sBHTra+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GhiChu(string sGhiChu,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET GhiChu='N"+sGhiChu+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_LoaiKhamID(string sLoaiKhamID,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET LoaiKhamID='"+sLoaiKhamID+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idkhoadangky(string sidkhoadangky,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET idkhoadangky='"+sidkhoadangky+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NgayQuayLai(string sNgayQuayLai,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET NgayQuayLai='"+sNgayQuayLai+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BHYTTra(string sBHYTTra,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BHYTTra='"+sBHYTTra+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BNDaTra(string sBNDaTra,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BNDaTra='"+sBNDaTra+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BNTongPhaiTra(string sBNTongPhaiTra,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BNTongPhaiTra='"+sBNTongPhaiTra+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BNTra(string sBNTra,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET BNTra='"+sBNTra+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DonGiaBH(string sDonGiaBH,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET DonGiaBH='"+sDonGiaBH+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DonGiaDV(string sDonGiaDV,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET DonGiaDV='"+sDonGiaDV+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsBHYT(string sIsBHYT,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET IsBHYT='"+sIsBHYT+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PhuThuBH(string sPhuThuBH,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET PhuThuBH='"+sPhuThuBH+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ThanhTienBH(string sThanhTienBH,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ThanhTienBH='"+sThanhTienBH+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ThanhTienDV(string sThanhTienDV,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ThanhTienDV='"+sThanhTienDV+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ISBNDaTra(string sISBNDaTra,string s_idkhambenhcanlamsan)
{
    string sqlSave= " UPDATE khambenhcanlamsan SET ISBNDaTra='"+sISBNDaTra+"' WHERE idkhambenhcanlamsan='"+ s_idkhambenhcanlamsan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM khambenhcanlamsan " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_khambenhcanlamsan;
   public static bool Change_dt_khambenhcanlamsan = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_khambenhcanlamsan()
   {
   if (dt_khambenhcanlamsan == null || Change_dt_khambenhcanlamsan == true)
   {
   dt_khambenhcanlamsan = dtGetAll();
   Change_dt_khambenhcanlamsan = true && AllowAutoChange ;
   }
   return dt_khambenhcanlamsan;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

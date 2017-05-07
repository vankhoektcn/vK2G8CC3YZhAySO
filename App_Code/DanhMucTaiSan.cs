using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace Process_kt
  { 
 public class DanhMucTaiSan:  Connect { 
 public static string sTableName= "DanhMucTaiSan"; 
   public string danh_muc_ts_id;
   public string phieu_nhap_ct_id;
   public string phieu_xuat_ct_id;
   public string MaTS;
   public string TenTaiSan;
   public string HangSX;
   public string NamSX;
   public string NguyenGia;
   public string KhauHaoLK;
   public string NgayNhap;
   public string NgayKhauHao;
   public string SoNamKH;
   public string TKNguyenGia;
   public string TKKhauHao;
   public string TKDoiUng;
   public string TKChiPhi;
   public string TKChiPhiKhac;
   public string SoHoaDonNhap;
   public string NgayLapHoaDon;
   public string GiaTriConLai;
   public string idkho;
   public string soluong_hienco;
   public string isTSCD;
   public string isCCDC;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_danh_muc_ts_id="danh_muc_ts_id" ;
 public static  string cl_danh_muc_ts_id_VN="danh_muc_ts_id";
 public static  string cl_phieu_nhap_ct_id="phieu_nhap_ct_id" ;
 public static  string cl_phieu_nhap_ct_id_VN="phieu_nhap_ct_id";
 public static  string cl_phieu_xuat_ct_id="phieu_xuat_ct_id" ;
 public static  string cl_phieu_xuat_ct_id_VN="phieu_xuat_ct_id";
 public static  string cl_MaTS="MaTS" ;
 public static  string cl_MaTS_VN="MaTS";
 public static  string cl_TenTaiSan="TenTaiSan" ;
 public static  string cl_TenTaiSan_VN="TenTaiSan";
 public static  string cl_HangSX="HangSX" ;
 public static  string cl_HangSX_VN="HangSX";
 public static  string cl_NamSX="NamSX" ;
 public static  string cl_NamSX_VN="NamSX";
 public static  string cl_NguyenGia="NguyenGia" ;
 public static  string cl_NguyenGia_VN="NguyenGia";
 public static  string cl_KhauHaoLK="KhauHaoLK" ;
 public static  string cl_KhauHaoLK_VN="KhauHaoLK";
 public static  string cl_NgayNhap="NgayNhap" ;
 public static  string cl_NgayNhap_VN="NgayNhap";
 public static  string cl_NgayKhauHao="NgayKhauHao" ;
 public static  string cl_NgayKhauHao_VN="NgayKhauHao";
 public static  string cl_SoNamKH="SoNamKH" ;
 public static  string cl_SoNamKH_VN="SoNamKH";
 public static  string cl_TKNguyenGia="TKNguyenGia" ;
 public static  string cl_TKNguyenGia_VN="TKNguyenGia";
 public static  string cl_TKKhauHao="TKKhauHao" ;
 public static  string cl_TKKhauHao_VN="TKKhauHao";
 public static  string cl_TKDoiUng="TKDoiUng" ;
 public static  string cl_TKDoiUng_VN="TKDoiUng";
 public static  string cl_TKChiPhi="TKChiPhi" ;
 public static  string cl_TKChiPhi_VN="TKChiPhi";
 public static  string cl_TKChiPhiKhac="TKChiPhiKhac" ;
 public static  string cl_TKChiPhiKhac_VN="TKChiPhiKhac";
 public static  string cl_SoHoaDonNhap="SoHoaDonNhap" ;
 public static  string cl_SoHoaDonNhap_VN="SoHoaDonNhap";
 public static  string cl_NgayLapHoaDon="NgayLapHoaDon" ;
 public static  string cl_NgayLapHoaDon_VN="NgayLapHoaDon";
 public static  string cl_GiaTriConLai="GiaTriConLai" ;
 public static  string cl_GiaTriConLai_VN="GiaTriConLai";
 public static  string cl_idkho="idkho" ;
 public static  string cl_idkho_VN="idkho";
 public static  string cl_soluong_hienco="soluong_hienco" ;
 public static  string cl_soluong_hienco_VN="soluong_hienco";
 public static  string cl_isTSCD="isTSCD" ;
 public static  string cl_isTSCD_VN="isTSCD";
 public static  string cl_isCCDC="isCCDC" ;
 public static  string cl_isCCDC_VN="isCCDC";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public DanhMucTaiSan() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public DanhMucTaiSan(
         string sdanh_muc_ts_id,
         string sphieu_nhap_ct_id,
         string sphieu_xuat_ct_id,
         string sMaTS,
         string sTenTaiSan,
         string sHangSX,
         string sNamSX,
         string sNguyenGia,
         string sKhauHaoLK,
         string sNgayNhap,
         string sNgayKhauHao,
         string sSoNamKH,
         string sTKNguyenGia,
         string sTKKhauHao,
         string sTKDoiUng,
         string sTKChiPhi,
         string sTKChiPhiKhac,
         string sSoHoaDonNhap,
         string sNgayLapHoaDon,
         string sGiaTriConLai,
         string sidkho,
         string ssoluong_hienco,
         string sisTSCD,
         string sisCCDC){
         this.danh_muc_ts_id= sdanh_muc_ts_id;
         this.phieu_nhap_ct_id= sphieu_nhap_ct_id;
         this.phieu_xuat_ct_id= sphieu_xuat_ct_id;
         this.MaTS= sMaTS;
         this.TenTaiSan= sTenTaiSan;
         this.HangSX= sHangSX;
         this.NamSX= sNamSX;
         this.NguyenGia= sNguyenGia;
         this.KhauHaoLK= sKhauHaoLK;
         this.NgayNhap= sNgayNhap;
         this.NgayKhauHao= sNgayKhauHao;
         this.SoNamKH= sSoNamKH;
         this.TKNguyenGia= sTKNguyenGia;
         this.TKKhauHao= sTKKhauHao;
         this.TKDoiUng= sTKDoiUng;
         this.TKChiPhi= sTKChiPhi;
         this.TKChiPhiKhac= sTKChiPhiKhac;
         this.SoHoaDonNhap= sSoHoaDonNhap;
         this.NgayLapHoaDon= sNgayLapHoaDon;
         this.GiaTriConLai= sGiaTriConLai;
         this.idkho= sidkho;
         this.soluong_hienco= ssoluong_hienco;
         this.isTSCD= sisTSCD;
         this.isCCDC= sisCCDC;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static DanhMucTaiSan Create_DanhMucTaiSan ( string sdanh_muc_ts_id  ){
    DataTable dt=dtSearchBydanh_muc_ts_id(sdanh_muc_ts_id) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new DanhMucTaiSan(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM DanhMucTaiSan AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by danh_muc_ts_id),T.* FROM DanhMucTaiSan AS T WHERE";
      if (this.phieu_nhap_ct_id!=null && this.phieu_nhap_ct_id!="" && this.phieu_nhap_ct_id!="0" && this.phieu_nhap_ct_id!="0.0") 
            sqlselect +=" AND phieu_nhap_ct_id =" + this.phieu_nhap_ct_id ;
      if (this.phieu_xuat_ct_id!=null && this.phieu_xuat_ct_id!="" && this.phieu_xuat_ct_id!="0" && this.phieu_xuat_ct_id!="0.0") 
            sqlselect +=" AND phieu_xuat_ct_id =" + this.phieu_xuat_ct_id ;
      if (this.MaTS!=null && this.MaTS!="") 
            sqlselect +=" AND MaTS LIKE N'%" + this.MaTS +"%'" ;
      if (this.TenTaiSan!=null && this.TenTaiSan!="") 
            sqlselect +=" AND TenTaiSan LIKE N'%" + this.TenTaiSan +"%'" ;
      if (this.HangSX!=null && this.HangSX!="") 
            sqlselect +=" AND HangSX LIKE N'%" + this.HangSX +"%'" ;
      if (this.NamSX!=null && this.NamSX!="" && this.NamSX!="0" && this.NamSX!="0.0") 
            sqlselect +=" AND NamSX =" + this.NamSX ;
      if (this.NguyenGia!=null && this.NguyenGia!="" && this.NguyenGia!="0" && this.NguyenGia!="0.0") 
            sqlselect +=" AND NguyenGia =" + this.NguyenGia ;
      if (this.KhauHaoLK!=null && this.KhauHaoLK!="" && this.KhauHaoLK!="0" && this.KhauHaoLK!="0.0") 
            sqlselect +=" AND KhauHaoLK =" + this.KhauHaoLK ;
      if (this.NgayNhap!=null && this.NgayNhap!="") 
            sqlselect +=" AND NgayNhap LIKE '%" + this.NgayNhap +"%'" ;
      if (this.NgayKhauHao!=null && this.NgayKhauHao!="") 
            sqlselect +=" AND NgayKhauHao LIKE '%" + this.NgayKhauHao +"%'" ;
      if (this.SoNamKH!=null && this.SoNamKH!="" && this.SoNamKH!="0" && this.SoNamKH!="0.0") 
            sqlselect +=" AND SoNamKH =" + this.SoNamKH ;
      if (this.TKNguyenGia!=null && this.TKNguyenGia!="") 
            sqlselect +=" AND TKNguyenGia LIKE N'%" + this.TKNguyenGia +"%'" ;
      if (this.TKKhauHao!=null && this.TKKhauHao!="") 
            sqlselect +=" AND TKKhauHao LIKE N'%" + this.TKKhauHao +"%'" ;
      if (this.TKDoiUng!=null && this.TKDoiUng!="") 
            sqlselect +=" AND TKDoiUng LIKE N'%" + this.TKDoiUng +"%'" ;
      if (this.TKChiPhi!=null && this.TKChiPhi!="") 
            sqlselect +=" AND TKChiPhi LIKE N'%" + this.TKChiPhi +"%'" ;
      if (this.TKChiPhiKhac!=null && this.TKChiPhiKhac!="") 
            sqlselect +=" AND TKChiPhiKhac LIKE N'%" + this.TKChiPhiKhac +"%'" ;
      if (this.SoHoaDonNhap!=null && this.SoHoaDonNhap!="") 
            sqlselect +=" AND SoHoaDonNhap LIKE N'%" + this.SoHoaDonNhap +"%'" ;
      if (this.NgayLapHoaDon!=null && this.NgayLapHoaDon!="") 
            sqlselect +=" AND NgayLapHoaDon LIKE '%" + this.NgayLapHoaDon +"%'" ;
      if (this.GiaTriConLai!=null && this.GiaTriConLai!="" && this.GiaTriConLai!="0" && this.GiaTriConLai!="0.0") 
            sqlselect +=" AND GiaTriConLai =" + this.GiaTriConLai ;
      if (this.idkho!=null && this.idkho!="" && this.idkho!="0" && this.idkho!="0.0") 
            sqlselect +=" AND idkho =" + this.idkho ;
      if (this.soluong_hienco!=null && this.soluong_hienco!="" && this.soluong_hienco!="0" && this.soluong_hienco!="0.0") 
            sqlselect +=" AND soluong_hienco =" + this.soluong_hienco ;
      if (this.isTSCD!=null && this.isTSCD!="") 
            sqlselect +=" AND isTSCD ='" + this.isTSCD+"'" ;
      if (this.isCCDC!=null && this.isCCDC!="") 
            sqlselect +=" AND isCCDC ='" + this.isCCDC+"'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public DanhMucTaiSan( DataView dv,int pos)
{
         this.danh_muc_ts_id= dv[pos][0].ToString();
         this.phieu_nhap_ct_id= dv[pos][1].ToString();
         this.phieu_xuat_ct_id= dv[pos][2].ToString();
         this.MaTS= dv[pos][3].ToString();
         this.TenTaiSan= dv[pos][4].ToString();
         this.HangSX= dv[pos][5].ToString();
         this.NamSX= dv[pos][6].ToString();
         this.NguyenGia= dv[pos][7].ToString();
         this.KhauHaoLK= dv[pos][8].ToString();
         this.NgayNhap= dv[pos][9].ToString();
         this.NgayKhauHao= dv[pos][10].ToString();
         this.SoNamKH= dv[pos][11].ToString();
         this.TKNguyenGia= dv[pos][12].ToString();
         this.TKKhauHao= dv[pos][13].ToString();
         this.TKDoiUng= dv[pos][14].ToString();
         this.TKChiPhi= dv[pos][15].ToString();
         this.TKChiPhiKhac= dv[pos][16].ToString();
         this.SoHoaDonNhap= dv[pos][17].ToString();
         this.NgayLapHoaDon= dv[pos][18].ToString();
         this.GiaTriConLai= dv[pos][19].ToString();
         this.idkho= dv[pos][20].ToString();
         this.soluong_hienco= dv[pos][21].ToString();
         this.isTSCD= dv[pos][22].ToString();
         this.isCCDC= dv[pos][23].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydanh_muc_ts_id(string sdanh_muc_ts_id)
{
          string sqlSelect= s_Select()+ " WHERE danh_muc_ts_id  ="+ sdanh_muc_ts_id + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydanh_muc_ts_id(string sdanh_muc_ts_id,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE danh_muc_ts_id"+ sMatch +sdanh_muc_ts_id + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByphieu_nhap_ct_id(string sphieu_nhap_ct_id)
{
          string sqlSelect= s_Select()+ " WHERE phieu_nhap_ct_id  ="+ sphieu_nhap_ct_id + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByphieu_nhap_ct_id(string sphieu_nhap_ct_id,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE phieu_nhap_ct_id"+ sMatch +sphieu_nhap_ct_id + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByphieu_xuat_ct_id(string sphieu_xuat_ct_id)
{
          string sqlSelect= s_Select()+ " WHERE phieu_xuat_ct_id  ="+ sphieu_xuat_ct_id + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByphieu_xuat_ct_id(string sphieu_xuat_ct_id,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE phieu_xuat_ct_id"+ sMatch +sphieu_xuat_ct_id + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMaTS(string sMaTS)
{
          string sqlSelect= s_Select()+ " WHERE MaTS  Like N'%"+ sMaTS + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTenTaiSan(string sTenTaiSan)
{
          string sqlSelect= s_Select()+ " WHERE TenTaiSan  Like N'%"+ sTenTaiSan + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByHangSX(string sHangSX)
{
          string sqlSelect= s_Select()+ " WHERE HangSX  Like N'%"+ sHangSX + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNamSX(string sNamSX)
{
          string sqlSelect= s_Select()+ " WHERE NamSX  ="+ sNamSX + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNamSX(string sNamSX,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NamSX"+ sMatch +sNamSX + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNguyenGia(string sNguyenGia)
{
          string sqlSelect= s_Select()+ " WHERE NguyenGia  ="+ sNguyenGia + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNguyenGia(string sNguyenGia,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NguyenGia"+ sMatch +sNguyenGia + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByKhauHaoLK(string sKhauHaoLK)
{
          string sqlSelect= s_Select()+ " WHERE KhauHaoLK  ="+ sKhauHaoLK + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByKhauHaoLK(string sKhauHaoLK,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE KhauHaoLK"+ sMatch +sKhauHaoLK + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayNhap(string sNgayNhap)
{
          string sqlSelect= s_Select()+ " WHERE NgayNhap  ="+ sNgayNhap + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayNhap(string sNgayNhap,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NgayNhap"+ sMatch +sNgayNhap + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayKhauHao(string sNgayKhauHao)
{
          string sqlSelect= s_Select()+ " WHERE NgayKhauHao  ="+ sNgayKhauHao + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayKhauHao(string sNgayKhauHao,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NgayKhauHao"+ sMatch +sNgayKhauHao + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySoNamKH(string sSoNamKH)
{
          string sqlSelect= s_Select()+ " WHERE SoNamKH  ="+ sSoNamKH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySoNamKH(string sSoNamKH,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SoNamKH"+ sMatch +sSoNamKH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTKNguyenGia(string sTKNguyenGia)
{
          string sqlSelect= s_Select()+ " WHERE TKNguyenGia  Like N'%"+ sTKNguyenGia + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTKKhauHao(string sTKKhauHao)
{
          string sqlSelect= s_Select()+ " WHERE TKKhauHao  Like N'%"+ sTKKhauHao + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTKDoiUng(string sTKDoiUng)
{
          string sqlSelect= s_Select()+ " WHERE TKDoiUng  Like N'%"+ sTKDoiUng + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTKChiPhi(string sTKChiPhi)
{
          string sqlSelect= s_Select()+ " WHERE TKChiPhi  Like N'%"+ sTKChiPhi + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTKChiPhiKhac(string sTKChiPhiKhac)
{
          string sqlSelect= s_Select()+ " WHERE TKChiPhiKhac  Like N'%"+ sTKChiPhiKhac + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySoHoaDonNhap(string sSoHoaDonNhap)
{
          string sqlSelect= s_Select()+ " WHERE SoHoaDonNhap  Like N'%"+ sSoHoaDonNhap + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayLapHoaDon(string sNgayLapHoaDon)
{
          string sqlSelect= s_Select()+ " WHERE NgayLapHoaDon  ="+ sNgayLapHoaDon + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayLapHoaDon(string sNgayLapHoaDon,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NgayLapHoaDon"+ sMatch +sNgayLapHoaDon + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByGiaTriConLai(string sGiaTriConLai)
{
          string sqlSelect= s_Select()+ " WHERE GiaTriConLai  ="+ sGiaTriConLai + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByGiaTriConLai(string sGiaTriConLai,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE GiaTriConLai"+ sMatch +sGiaTriConLai + ""; 
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
 public static DataTable dtSearchBysoluong_hienco(string ssoluong_hienco)
{
          string sqlSelect= s_Select()+ " WHERE soluong_hienco  ="+ ssoluong_hienco + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysoluong_hienco(string ssoluong_hienco,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE soluong_hienco"+ sMatch +ssoluong_hienco + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByisTSCD(string sisTSCD)
{
          string sqlSelect= s_Select()+ " WHERE isTSCD  ="+ sisTSCD + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByisTSCD(string sisTSCD,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE isTSCD"+ sMatch +sisTSCD + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByisCCDC(string sisCCDC)
{
          string sqlSelect= s_Select()+ " WHERE isCCDC  ="+ sisCCDC + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByisCCDC(string sisCCDC,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE isCCDC"+ sMatch +sisCCDC + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sdanh_muc_ts_id
            , string sphieu_nhap_ct_id
            , string sphieu_xuat_ct_id
            , string sMaTS
            , string sTenTaiSan
            , string sHangSX
            , string sNamSX
            , string sNguyenGia
            , string sKhauHaoLK
            , string sNgayNhap
            , string sNgayKhauHao
            , string sSoNamKH
            , string sTKNguyenGia
            , string sTKKhauHao
            , string sTKDoiUng
            , string sTKChiPhi
            , string sTKChiPhiKhac
            , string sSoHoaDonNhap
            , string sNgayLapHoaDon
            , string sGiaTriConLai
            , string sidkho
            , string ssoluong_hienco
            , string sisTSCD
            , string sisCCDC
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sdanh_muc_ts_id!=null && sdanh_muc_ts_id!="") 
            sqlselect +=" AND danh_muc_ts_id =" + sdanh_muc_ts_id ;
      if (sphieu_nhap_ct_id!=null && sphieu_nhap_ct_id!="") 
            sqlselect +=" AND phieu_nhap_ct_id =" + sphieu_nhap_ct_id ;
      if (sphieu_xuat_ct_id!=null && sphieu_xuat_ct_id!="") 
            sqlselect +=" AND phieu_xuat_ct_id =" + sphieu_xuat_ct_id ;
      if (sMaTS!=null && sMaTS!="") 
            sqlselect +=" AND MaTS LIKE N'%" + sMaTS +"%'" ;
      if (sTenTaiSan!=null && sTenTaiSan!="") 
            sqlselect +=" AND TenTaiSan LIKE N'%" + sTenTaiSan +"%'" ;
      if (sHangSX!=null && sHangSX!="") 
            sqlselect +=" AND HangSX LIKE N'%" + sHangSX +"%'" ;
      if (sNamSX!=null && sNamSX!="") 
            sqlselect +=" AND NamSX =" + sNamSX ;
      if (sNguyenGia!=null && sNguyenGia!="") 
            sqlselect +=" AND NguyenGia =" + sNguyenGia ;
      if (sKhauHaoLK!=null && sKhauHaoLK!="") 
            sqlselect +=" AND KhauHaoLK =" + sKhauHaoLK ;
      if (sNgayNhap!=null && sNgayNhap!="") 
            sqlselect +=" AND NgayNhap LIKE '%" + sNgayNhap +"%'" ;
      if (sNgayKhauHao!=null && sNgayKhauHao!="") 
            sqlselect +=" AND NgayKhauHao LIKE '%" + sNgayKhauHao +"%'" ;
      if (sSoNamKH!=null && sSoNamKH!="") 
            sqlselect +=" AND SoNamKH =" + sSoNamKH ;
      if (sTKNguyenGia!=null && sTKNguyenGia!="") 
            sqlselect +=" AND TKNguyenGia LIKE N'%" + sTKNguyenGia +"%'" ;
      if (sTKKhauHao!=null && sTKKhauHao!="") 
            sqlselect +=" AND TKKhauHao LIKE N'%" + sTKKhauHao +"%'" ;
      if (sTKDoiUng!=null && sTKDoiUng!="") 
            sqlselect +=" AND TKDoiUng LIKE N'%" + sTKDoiUng +"%'" ;
      if (sTKChiPhi!=null && sTKChiPhi!="") 
            sqlselect +=" AND TKChiPhi LIKE N'%" + sTKChiPhi +"%'" ;
      if (sTKChiPhiKhac!=null && sTKChiPhiKhac!="") 
            sqlselect +=" AND TKChiPhiKhac LIKE N'%" + sTKChiPhiKhac +"%'" ;
      if (sSoHoaDonNhap!=null && sSoHoaDonNhap!="") 
            sqlselect +=" AND SoHoaDonNhap LIKE N'%" + sSoHoaDonNhap +"%'" ;
      if (sNgayLapHoaDon!=null && sNgayLapHoaDon!="") 
            sqlselect +=" AND NgayLapHoaDon LIKE '%" + sNgayLapHoaDon +"%'" ;
      if (sGiaTriConLai!=null && sGiaTriConLai!="") 
            sqlselect +=" AND GiaTriConLai =" + sGiaTriConLai ;
      if (sidkho!=null && sidkho!="") 
            sqlselect +=" AND idkho =" + sidkho ;
      if (ssoluong_hienco!=null && ssoluong_hienco!="") 
            sqlselect +=" AND soluong_hienco =" + ssoluong_hienco ;
      if (sisTSCD!=null && sisTSCD!="") 
            sqlselect +=" AND isTSCD =" + sisTSCD ;
      if (sisCCDC!=null && sisCCDC!="") 
            sqlselect +=" AND isCCDC =" + sisCCDC ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public DataTable dtSearch()
      {
          if (this.page == null || this.page == "")
              this.page = "1";
          if (this.numberRow == null || this.numberRow == "")
              this.numberRow = "100";
 
          string sql = "select * from(" + this.SQLSelect() + ") abc where stt between (" + this.page + "-1)*" + this.numberRow + "+1 and " + this.page + " * " + this.numberRow;
          return GetTable(sql);
 
      }
//───────────────────────────────────────────────────────────────────────────────────────
      public string Paging()
      {
          int sumRow = GetTable(this.SQLSelect()).Rows.Count;
 
          if (this.page == null || this.page == "")
              this.page = "1";
          if (this.numberRow == null || this.numberRow == "")
              this.numberRow = "100";
 
          int sodongpaging = sumRow / int.Parse(this.numberRow);
          int sodongdu = sumRow % int.Parse(this.numberRow);
          if (sodongdu != 0)
          {
              sodongpaging = sodongpaging + 1;
          }
          string html = "";
          html += "<div style='padding-bottom:20px;width:90%;margin:auto;display:table'>";
          for (int i = 1; i <= sodongpaging; i++)
          {
              if (int.Parse(this.page) != i)
              {
                  html += "<a style='float:left;color:green;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"Find(this,'" + i + "')\">" + i + "</a>";
              }
              else
              {
                  html += "<span style='float:left;color:red'>" + i + "</span>";
              }
          }
          html += "</div>";
          return html;
      }
//───────────────────────────────────────────────────────────────────────────────────────
 public static DanhMucTaiSan Insert_Object(
string  sphieu_nhap_ct_id
            ,string  sphieu_xuat_ct_id
            ,string  sMaTS
            ,string  sTenTaiSan
            ,string  sHangSX
            ,string  sNamSX
            ,string  sNguyenGia
            ,string  sKhauHaoLK
            ,string  sNgayNhap
            ,string  sNgayKhauHao
            ,string  sSoNamKH
            ,string  sTKNguyenGia
            ,string  sTKKhauHao
            ,string  sTKDoiUng
            ,string  sTKChiPhi
            ,string  sTKChiPhiKhac
            ,string  sSoHoaDonNhap
            ,string  sNgayLapHoaDon
            ,string  sGiaTriConLai
            ,string  sidkho
            ,string  ssoluong_hienco
            ,string  sisTSCD
            ,string  sisCCDC
            ) 
 { 
              string tem_sphieu_nhap_ct_id=DataAcess.hsSqlTool.sGetSaveValue(sphieu_nhap_ct_id,"bigint");
              string tem_sphieu_xuat_ct_id=DataAcess.hsSqlTool.sGetSaveValue(sphieu_xuat_ct_id,"bigint");
              string tem_sMaTS=DataAcess.hsSqlTool.sGetSaveValue(sMaTS,"varchar");
              string tem_sTenTaiSan=DataAcess.hsSqlTool.sGetSaveValue(sTenTaiSan,"nvarchar");
              string tem_sHangSX=DataAcess.hsSqlTool.sGetSaveValue(sHangSX,"nvarchar");
              string tem_sNamSX=DataAcess.hsSqlTool.sGetSaveValue(sNamSX,"numeric");
              string tem_sNguyenGia=DataAcess.hsSqlTool.sGetSaveValue(sNguyenGia,"numeric");
              string tem_sKhauHaoLK=DataAcess.hsSqlTool.sGetSaveValue(sKhauHaoLK,"numeric");
              string tem_sNgayNhap=DataAcess.hsSqlTool.sGetSaveValue(sNgayNhap,"datetime");
              string tem_sNgayKhauHao=DataAcess.hsSqlTool.sGetSaveValue(sNgayKhauHao,"datetime");
              string tem_sSoNamKH=DataAcess.hsSqlTool.sGetSaveValue(sSoNamKH,"int");
              string tem_sTKNguyenGia=DataAcess.hsSqlTool.sGetSaveValue(sTKNguyenGia,"char");
              string tem_sTKKhauHao=DataAcess.hsSqlTool.sGetSaveValue(sTKKhauHao,"char");
              string tem_sTKDoiUng=DataAcess.hsSqlTool.sGetSaveValue(sTKDoiUng,"char");
              string tem_sTKChiPhi=DataAcess.hsSqlTool.sGetSaveValue(sTKChiPhi,"char");
              string tem_sTKChiPhiKhac=DataAcess.hsSqlTool.sGetSaveValue(sTKChiPhiKhac,"char");
              string tem_sSoHoaDonNhap=DataAcess.hsSqlTool.sGetSaveValue(sSoHoaDonNhap,"varchar");
              string tem_sNgayLapHoaDon=DataAcess.hsSqlTool.sGetSaveValue(sNgayLapHoaDon,"datetime");
              string tem_sGiaTriConLai=DataAcess.hsSqlTool.sGetSaveValue(sGiaTriConLai,"numeric");
              string tem_sidkho=DataAcess.hsSqlTool.sGetSaveValue(sidkho,"int");
              string tem_ssoluong_hienco=DataAcess.hsSqlTool.sGetSaveValue(ssoluong_hienco,"int");
              string tem_sisTSCD=DataAcess.hsSqlTool.sGetSaveValue(sisTSCD,"bit");
              string tem_sisCCDC=DataAcess.hsSqlTool.sGetSaveValue(sisCCDC,"bit");

             string sqlSave=" INSERT INTO DanhMucTaiSan("+
                   "phieu_nhap_ct_id," 
        +                   "phieu_xuat_ct_id," 
        +                   "MaTS," 
        +                   "TenTaiSan," 
        +                   "HangSX," 
        +                   "NamSX," 
        +                   "NguyenGia," 
        +                   "KhauHaoLK," 
        +                   "NgayNhap," 
        +                   "NgayKhauHao," 
        +                   "SoNamKH," 
        +                   "TKNguyenGia," 
        +                   "TKKhauHao," 
        +                   "TKDoiUng," 
        +                   "TKChiPhi," 
        +                   "TKChiPhiKhac," 
        +                   "SoHoaDonNhap," 
        +                   "NgayLapHoaDon," 
        +                   "GiaTriConLai," 
        +                   "idkho," 
        +                   "soluong_hienco," 
        +                   "isTSCD," 
        +                   "isCCDC) VALUES("
 +tem_sphieu_nhap_ct_id+","
 +tem_sphieu_xuat_ct_id+","
 +tem_sMaTS+","
 +tem_sTenTaiSan+","
 +tem_sHangSX+","
 +tem_sNamSX+","
 +tem_sNguyenGia+","
 +tem_sKhauHaoLK+","
 +tem_sNgayNhap+","
 +tem_sNgayKhauHao+","
 +tem_sSoNamKH+","
 +tem_sTKNguyenGia+","
 +tem_sTKKhauHao+","
 +tem_sTKDoiUng+","
 +tem_sTKChiPhi+","
 +tem_sTKChiPhiKhac+","
 +tem_sSoHoaDonNhap+","
 +tem_sNgayLapHoaDon+","
 +tem_sGiaTriConLai+","
 +tem_sidkho+","
 +tem_ssoluong_hienco+","
 +tem_sisTSCD+","
 +tem_sisCCDC +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          DanhMucTaiSan newDanhMucTaiSan= new DanhMucTaiSan();
                 newDanhMucTaiSan.danh_muc_ts_id=GetTable( " SELECT TOP 1 danh_muc_ts_id FROM DanhMucTaiSan ORDER BY danh_muc_ts_id DESC ").Rows[0][0].ToString();
              newDanhMucTaiSan.phieu_nhap_ct_id=sphieu_nhap_ct_id;
              newDanhMucTaiSan.phieu_xuat_ct_id=sphieu_xuat_ct_id;
              newDanhMucTaiSan.MaTS=sMaTS;
              newDanhMucTaiSan.TenTaiSan=sTenTaiSan;
              newDanhMucTaiSan.HangSX=sHangSX;
              newDanhMucTaiSan.NamSX=sNamSX;
              newDanhMucTaiSan.NguyenGia=sNguyenGia;
              newDanhMucTaiSan.KhauHaoLK=sKhauHaoLK;
              newDanhMucTaiSan.NgayNhap=sNgayNhap;
              newDanhMucTaiSan.NgayKhauHao=sNgayKhauHao;
              newDanhMucTaiSan.SoNamKH=sSoNamKH;
              newDanhMucTaiSan.TKNguyenGia=sTKNguyenGia;
              newDanhMucTaiSan.TKKhauHao=sTKKhauHao;
              newDanhMucTaiSan.TKDoiUng=sTKDoiUng;
              newDanhMucTaiSan.TKChiPhi=sTKChiPhi;
              newDanhMucTaiSan.TKChiPhiKhac=sTKChiPhiKhac;
              newDanhMucTaiSan.SoHoaDonNhap=sSoHoaDonNhap;
              newDanhMucTaiSan.NgayLapHoaDon=sNgayLapHoaDon;
              newDanhMucTaiSan.GiaTriConLai=sGiaTriConLai;
              newDanhMucTaiSan.idkho=sidkho;
              newDanhMucTaiSan.soluong_hienco=ssoluong_hienco;
              newDanhMucTaiSan.isTSCD=sisTSCD;
              newDanhMucTaiSan.isCCDC=sisCCDC;
            return newDanhMucTaiSan; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public DanhMucTaiSan Insert_Object() { 
              string tem_sphieu_nhap_ct_id=DataAcess.hsSqlTool.sGetSaveValue(this.phieu_nhap_ct_id,"bigint");
              string tem_sphieu_xuat_ct_id=DataAcess.hsSqlTool.sGetSaveValue(this.phieu_xuat_ct_id,"bigint");
              string tem_sMaTS=DataAcess.hsSqlTool.sGetSaveValue(this.MaTS,"varchar");
              string tem_sTenTaiSan=DataAcess.hsSqlTool.sGetSaveValue(this.TenTaiSan,"nvarchar");
              string tem_sHangSX=DataAcess.hsSqlTool.sGetSaveValue(this.HangSX,"nvarchar");
              string tem_sNamSX=DataAcess.hsSqlTool.sGetSaveValue(this.NamSX,"numeric");
              string tem_sNguyenGia=DataAcess.hsSqlTool.sGetSaveValue(this.NguyenGia,"numeric");
              string tem_sKhauHaoLK=DataAcess.hsSqlTool.sGetSaveValue(this.KhauHaoLK,"numeric");
              string tem_sNgayNhap=DataAcess.hsSqlTool.sGetSaveValue(this.NgayNhap,"datetime");
              string tem_sNgayKhauHao=DataAcess.hsSqlTool.sGetSaveValue(this.NgayKhauHao,"datetime");
              string tem_sSoNamKH=DataAcess.hsSqlTool.sGetSaveValue(this.SoNamKH,"int");
              string tem_sTKNguyenGia=DataAcess.hsSqlTool.sGetSaveValue(this.TKNguyenGia,"char");
              string tem_sTKKhauHao=DataAcess.hsSqlTool.sGetSaveValue(this.TKKhauHao,"char");
              string tem_sTKDoiUng=DataAcess.hsSqlTool.sGetSaveValue(this.TKDoiUng,"char");
              string tem_sTKChiPhi=DataAcess.hsSqlTool.sGetSaveValue(this.TKChiPhi,"char");
              string tem_sTKChiPhiKhac=DataAcess.hsSqlTool.sGetSaveValue(this.TKChiPhiKhac,"char");
              string tem_sSoHoaDonNhap=DataAcess.hsSqlTool.sGetSaveValue(this.SoHoaDonNhap,"varchar");
              string tem_sNgayLapHoaDon=DataAcess.hsSqlTool.sGetSaveValue(this.NgayLapHoaDon,"datetime");
              string tem_sGiaTriConLai=DataAcess.hsSqlTool.sGetSaveValue(this.GiaTriConLai,"numeric");
              string tem_sidkho=DataAcess.hsSqlTool.sGetSaveValue(this.idkho,"int");
              string tem_ssoluong_hienco=DataAcess.hsSqlTool.sGetSaveValue(this.soluong_hienco,"int");
              string tem_sisTSCD=DataAcess.hsSqlTool.sGetSaveValue(this.isTSCD,"bit");
              string tem_sisCCDC=DataAcess.hsSqlTool.sGetSaveValue(this.isCCDC,"bit");

             string sqlSave=" INSERT INTO DanhMucTaiSan("+
                   "phieu_nhap_ct_id," 
        +                   "phieu_xuat_ct_id," 
        +                   "MaTS," 
        +                   "TenTaiSan," 
        +                   "HangSX," 
        +                   "NamSX," 
        +                   "NguyenGia," 
        +                   "KhauHaoLK," 
        +                   "NgayNhap," 
        +                   "NgayKhauHao," 
        +                   "SoNamKH," 
        +                   "TKNguyenGia," 
        +                   "TKKhauHao," 
        +                   "TKDoiUng," 
        +                   "TKChiPhi," 
        +                   "TKChiPhiKhac," 
        +                   "SoHoaDonNhap," 
        +                   "NgayLapHoaDon," 
        +                   "GiaTriConLai," 
        +                   "idkho," 
        +                   "soluong_hienco," 
        +                   "isTSCD," 
        +                   "isCCDC) VALUES("
 +tem_sphieu_nhap_ct_id+","
 +tem_sphieu_xuat_ct_id+","
 +tem_sMaTS+","
 +tem_sTenTaiSan+","
 +tem_sHangSX+","
 +tem_sNamSX+","
 +tem_sNguyenGia+","
 +tem_sKhauHaoLK+","
 +tem_sNgayNhap+","
 +tem_sNgayKhauHao+","
 +tem_sSoNamKH+","
 +tem_sTKNguyenGia+","
 +tem_sTKKhauHao+","
 +tem_sTKDoiUng+","
 +tem_sTKChiPhi+","
 +tem_sTKChiPhiKhac+","
 +tem_sSoHoaDonNhap+","
 +tem_sNgayLapHoaDon+","
 +tem_sGiaTriConLai+","
 +tem_sidkho+","
 +tem_ssoluong_hienco+","
 +tem_sisTSCD+","
 +tem_sisCCDC +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          DanhMucTaiSan newDanhMucTaiSan= new DanhMucTaiSan();
                 newDanhMucTaiSan.danh_muc_ts_id=GetTable( " SELECT TOP 1 danh_muc_ts_id FROM DanhMucTaiSan ORDER BY danh_muc_ts_id DESC ").Rows[0][0].ToString();
              newDanhMucTaiSan.phieu_nhap_ct_id=this.phieu_nhap_ct_id;
              newDanhMucTaiSan.phieu_xuat_ct_id=this.phieu_xuat_ct_id;
              newDanhMucTaiSan.MaTS=this.MaTS;
              newDanhMucTaiSan.TenTaiSan=this.TenTaiSan;
              newDanhMucTaiSan.HangSX=this.HangSX;
              newDanhMucTaiSan.NamSX=this.NamSX;
              newDanhMucTaiSan.NguyenGia=this.NguyenGia;
              newDanhMucTaiSan.KhauHaoLK=this.KhauHaoLK;
              newDanhMucTaiSan.NgayNhap=this.NgayNhap;
              newDanhMucTaiSan.NgayKhauHao=this.NgayKhauHao;
              newDanhMucTaiSan.SoNamKH=this.SoNamKH;
              newDanhMucTaiSan.TKNguyenGia=this.TKNguyenGia;
              newDanhMucTaiSan.TKKhauHao=this.TKKhauHao;
              newDanhMucTaiSan.TKDoiUng=this.TKDoiUng;
              newDanhMucTaiSan.TKChiPhi=this.TKChiPhi;
              newDanhMucTaiSan.TKChiPhiKhac=this.TKChiPhiKhac;
              newDanhMucTaiSan.SoHoaDonNhap=this.SoHoaDonNhap;
              newDanhMucTaiSan.NgayLapHoaDon=this.NgayLapHoaDon;
              newDanhMucTaiSan.GiaTriConLai=this.GiaTriConLai;
              newDanhMucTaiSan.idkho=this.idkho;
              newDanhMucTaiSan.soluong_hienco=this.soluong_hienco;
              newDanhMucTaiSan.isTSCD=this.isTSCD;
              newDanhMucTaiSan.isCCDC=this.isCCDC;
            return newDanhMucTaiSan; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sphieu_nhap_ct_id
                ,string sphieu_xuat_ct_id
                ,string sMaTS
                ,string sTenTaiSan
                ,string sHangSX
                ,string sNamSX
                ,string sNguyenGia
                ,string sKhauHaoLK
                ,string sNgayNhap
                ,string sNgayKhauHao
                ,string sSoNamKH
                ,string sTKNguyenGia
                ,string sTKKhauHao
                ,string sTKDoiUng
                ,string sTKChiPhi
                ,string sTKChiPhiKhac
                ,string sSoHoaDonNhap
                ,string sNgayLapHoaDon
                ,string sGiaTriConLai
                ,string sidkho
                ,string ssoluong_hienco
                ,string sisTSCD
                ,string sisCCDC
                ) 
 { 
              string tem_sphieu_nhap_ct_id=DataAcess.hsSqlTool.sGetSaveValue(sphieu_nhap_ct_id,"bigint");
              string tem_sphieu_xuat_ct_id=DataAcess.hsSqlTool.sGetSaveValue(sphieu_xuat_ct_id,"bigint");
              string tem_sMaTS=DataAcess.hsSqlTool.sGetSaveValue(sMaTS,"varchar");
              string tem_sTenTaiSan=DataAcess.hsSqlTool.sGetSaveValue(sTenTaiSan,"nvarchar");
              string tem_sHangSX=DataAcess.hsSqlTool.sGetSaveValue(sHangSX,"nvarchar");
              string tem_sNamSX=DataAcess.hsSqlTool.sGetSaveValue(sNamSX,"numeric");
              string tem_sNguyenGia=DataAcess.hsSqlTool.sGetSaveValue(sNguyenGia,"numeric");
              string tem_sKhauHaoLK=DataAcess.hsSqlTool.sGetSaveValue(sKhauHaoLK,"numeric");
              string tem_sNgayNhap=DataAcess.hsSqlTool.sGetSaveValue(sNgayNhap,"datetime");
              string tem_sNgayKhauHao=DataAcess.hsSqlTool.sGetSaveValue(sNgayKhauHao,"datetime");
              string tem_sSoNamKH=DataAcess.hsSqlTool.sGetSaveValue(sSoNamKH,"int");
              string tem_sTKNguyenGia=DataAcess.hsSqlTool.sGetSaveValue(sTKNguyenGia,"char");
              string tem_sTKKhauHao=DataAcess.hsSqlTool.sGetSaveValue(sTKKhauHao,"char");
              string tem_sTKDoiUng=DataAcess.hsSqlTool.sGetSaveValue(sTKDoiUng,"char");
              string tem_sTKChiPhi=DataAcess.hsSqlTool.sGetSaveValue(sTKChiPhi,"char");
              string tem_sTKChiPhiKhac=DataAcess.hsSqlTool.sGetSaveValue(sTKChiPhiKhac,"char");
              string tem_sSoHoaDonNhap=DataAcess.hsSqlTool.sGetSaveValue(sSoHoaDonNhap,"varchar");
              string tem_sNgayLapHoaDon=DataAcess.hsSqlTool.sGetSaveValue(sNgayLapHoaDon,"datetime");
              string tem_sGiaTriConLai=DataAcess.hsSqlTool.sGetSaveValue(sGiaTriConLai,"numeric");
              string tem_sidkho=DataAcess.hsSqlTool.sGetSaveValue(sidkho,"int");
              string tem_ssoluong_hienco=DataAcess.hsSqlTool.sGetSaveValue(ssoluong_hienco,"int");
              string tem_sisTSCD=DataAcess.hsSqlTool.sGetSaveValue(sisTSCD,"bit");
              string tem_sisCCDC=DataAcess.hsSqlTool.sGetSaveValue(sisCCDC,"bit");

 string sqlSave=" UPDATE DanhMucTaiSan SET "+"phieu_nhap_ct_id ="+tem_sphieu_nhap_ct_id+","
 +"phieu_xuat_ct_id ="+tem_sphieu_xuat_ct_id+","
 +"MaTS ="+tem_sMaTS+","
 +"TenTaiSan ="+tem_sTenTaiSan+","
 +"HangSX ="+tem_sHangSX+","
 +"NamSX ="+tem_sNamSX+","
 +"NguyenGia ="+tem_sNguyenGia+","
 +"KhauHaoLK ="+tem_sKhauHaoLK+","
 +"NgayNhap ="+tem_sNgayNhap+","
 +"NgayKhauHao ="+tem_sNgayKhauHao+","
 +"SoNamKH ="+tem_sSoNamKH+","
 +"TKNguyenGia ="+tem_sTKNguyenGia+","
 +"TKKhauHao ="+tem_sTKKhauHao+","
 +"TKDoiUng ="+tem_sTKDoiUng+","
 +"TKChiPhi ="+tem_sTKChiPhi+","
 +"TKChiPhiKhac ="+tem_sTKChiPhiKhac+","
 +"SoHoaDonNhap ="+tem_sSoHoaDonNhap+","
 +"NgayLapHoaDon ="+tem_sNgayLapHoaDon+","
 +"GiaTriConLai ="+tem_sGiaTriConLai+","
 +"idkho ="+tem_sidkho+","
 +"soluong_hienco ="+tem_ssoluong_hienco+","
 +"isTSCD ="+tem_sisTSCD+","
 +"isCCDC ="+tem_sisCCDC+" WHERE danh_muc_ts_id="+DataAcess.hsSqlTool.sGetSaveValue(this.danh_muc_ts_id,"int identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.phieu_nhap_ct_id=sphieu_nhap_ct_id;
                this.phieu_xuat_ct_id=sphieu_xuat_ct_id;
                this.MaTS=sMaTS;
                this.TenTaiSan=sTenTaiSan;
                this.HangSX=sHangSX;
                this.NamSX=sNamSX;
                this.NguyenGia=sNguyenGia;
                this.KhauHaoLK=sKhauHaoLK;
                this.NgayNhap=sNgayNhap;
                this.NgayKhauHao=sNgayKhauHao;
                this.SoNamKH=sSoNamKH;
                this.TKNguyenGia=sTKNguyenGia;
                this.TKKhauHao=sTKKhauHao;
                this.TKDoiUng=sTKDoiUng;
                this.TKChiPhi=sTKChiPhi;
                this.TKChiPhiKhac=sTKChiPhiKhac;
                this.SoHoaDonNhap=sSoHoaDonNhap;
                this.NgayLapHoaDon=sNgayLapHoaDon;
                this.GiaTriConLai=sGiaTriConLai;
                this.idkho=sidkho;
                this.soluong_hienco=ssoluong_hienco;
                this.isTSCD=sisTSCD;
                this.isCCDC=sisCCDC;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_sphieu_nhap_ct_id=DataAcess.hsSqlTool.sGetSaveValue(this.phieu_nhap_ct_id,"bigint");
              string tem_sphieu_xuat_ct_id=DataAcess.hsSqlTool.sGetSaveValue(this.phieu_xuat_ct_id,"bigint");
              string tem_sMaTS=DataAcess.hsSqlTool.sGetSaveValue(this.MaTS,"varchar");
              string tem_sTenTaiSan=DataAcess.hsSqlTool.sGetSaveValue(this.TenTaiSan,"nvarchar");
              string tem_sHangSX=DataAcess.hsSqlTool.sGetSaveValue(this.HangSX,"nvarchar");
              string tem_sNamSX=DataAcess.hsSqlTool.sGetSaveValue(this.NamSX,"numeric");
              string tem_sNguyenGia=DataAcess.hsSqlTool.sGetSaveValue(this.NguyenGia,"numeric");
              string tem_sKhauHaoLK=DataAcess.hsSqlTool.sGetSaveValue(this.KhauHaoLK,"numeric");
              string tem_sNgayNhap=DataAcess.hsSqlTool.sGetSaveValue(this.NgayNhap,"datetime");
              string tem_sNgayKhauHao=DataAcess.hsSqlTool.sGetSaveValue(this.NgayKhauHao,"datetime");
              string tem_sSoNamKH=DataAcess.hsSqlTool.sGetSaveValue(this.SoNamKH,"int");
              string tem_sTKNguyenGia=DataAcess.hsSqlTool.sGetSaveValue(this.TKNguyenGia,"char");
              string tem_sTKKhauHao=DataAcess.hsSqlTool.sGetSaveValue(this.TKKhauHao,"char");
              string tem_sTKDoiUng=DataAcess.hsSqlTool.sGetSaveValue(this.TKDoiUng,"char");
              string tem_sTKChiPhi=DataAcess.hsSqlTool.sGetSaveValue(this.TKChiPhi,"char");
              string tem_sTKChiPhiKhac=DataAcess.hsSqlTool.sGetSaveValue(this.TKChiPhiKhac,"char");
              string tem_sSoHoaDonNhap=DataAcess.hsSqlTool.sGetSaveValue(this.SoHoaDonNhap,"varchar");
              string tem_sNgayLapHoaDon=DataAcess.hsSqlTool.sGetSaveValue(this.NgayLapHoaDon,"datetime");
              string tem_sGiaTriConLai=DataAcess.hsSqlTool.sGetSaveValue(this.GiaTriConLai,"numeric");
              string tem_sidkho=DataAcess.hsSqlTool.sGetSaveValue(this.idkho,"int");
              string tem_ssoluong_hienco=DataAcess.hsSqlTool.sGetSaveValue(this.soluong_hienco,"int");
              string tem_sisTSCD=DataAcess.hsSqlTool.sGetSaveValue(this.isTSCD,"bit");
              string tem_sisCCDC=DataAcess.hsSqlTool.sGetSaveValue(this.isCCDC,"bit");

 string sqlSave=" UPDATE DanhMucTaiSan SET ";
if(tem_sphieu_nhap_ct_id != null)
 sqlSave+="phieu_nhap_ct_id ="+tem_sphieu_nhap_ct_id+",";
if(tem_sphieu_xuat_ct_id != null)
 sqlSave+="phieu_xuat_ct_id ="+tem_sphieu_xuat_ct_id+",";
if(tem_sMaTS != null)
 sqlSave+="MaTS ="+tem_sMaTS+",";
if(tem_sTenTaiSan != null)
 sqlSave+="TenTaiSan ="+tem_sTenTaiSan+",";
if(tem_sHangSX != null)
 sqlSave+="HangSX ="+tem_sHangSX+",";
if(tem_sNamSX != null)
 sqlSave+="NamSX ="+tem_sNamSX+",";
if(tem_sNguyenGia != null)
 sqlSave+="NguyenGia ="+tem_sNguyenGia+",";
if(tem_sKhauHaoLK != null)
 sqlSave+="KhauHaoLK ="+tem_sKhauHaoLK+",";
if(tem_sNgayNhap != null)
 sqlSave+="NgayNhap ="+tem_sNgayNhap+",";
if(tem_sNgayKhauHao != null)
 sqlSave+="NgayKhauHao ="+tem_sNgayKhauHao+",";
if(tem_sSoNamKH != null)
 sqlSave+="SoNamKH ="+tem_sSoNamKH+",";
if(tem_sTKNguyenGia != null)
 sqlSave+="TKNguyenGia ="+tem_sTKNguyenGia+",";
if(tem_sTKKhauHao != null)
 sqlSave+="TKKhauHao ="+tem_sTKKhauHao+",";
if(tem_sTKDoiUng != null)
 sqlSave+="TKDoiUng ="+tem_sTKDoiUng+",";
if(tem_sTKChiPhi != null)
 sqlSave+="TKChiPhi ="+tem_sTKChiPhi+",";
if(tem_sTKChiPhiKhac != null)
 sqlSave+="TKChiPhiKhac ="+tem_sTKChiPhiKhac+",";
if(tem_sSoHoaDonNhap != null)
 sqlSave+="SoHoaDonNhap ="+tem_sSoHoaDonNhap+",";
if(tem_sNgayLapHoaDon != null)
 sqlSave+="NgayLapHoaDon ="+tem_sNgayLapHoaDon+",";
if(tem_sGiaTriConLai != null)
 sqlSave+="GiaTriConLai ="+tem_sGiaTriConLai+",";
if(tem_sidkho != null)
 sqlSave+="idkho ="+tem_sidkho+",";
if(tem_ssoluong_hienco != null)
 sqlSave+="soluong_hienco ="+tem_ssoluong_hienco+",";
if(tem_sisTSCD != null)
 sqlSave+="isTSCD ="+tem_sisTSCD+",";
if(tem_sisCCDC != null)
 sqlSave+="isCCDC ="+tem_sisCCDC+",";
sqlSave+=" WHERE danh_muc_ts_id="+DataAcess.hsSqlTool.sGetSaveValue(this.danh_muc_ts_id,"int identity");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_danh_muc_ts_id(string sdanh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET danh_muc_ts_id='"+ sdanh_muc_ts_id+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.danh_muc_ts_id=sdanh_muc_ts_id;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_phieu_nhap_ct_id(string sphieu_nhap_ct_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET phieu_nhap_ct_id='"+ sphieu_nhap_ct_id+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.phieu_nhap_ct_id=sphieu_nhap_ct_id;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_phieu_xuat_ct_id(string sphieu_xuat_ct_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET phieu_xuat_ct_id='"+ sphieu_xuat_ct_id+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.phieu_xuat_ct_id=sphieu_xuat_ct_id;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MaTS(string sMaTS)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET MaTS='N"+ sMaTS+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MaTS=sMaTS;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TenTaiSan(string sTenTaiSan)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TenTaiSan='N"+ sTenTaiSan+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TenTaiSan=sTenTaiSan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_HangSX(string sHangSX)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET HangSX='N"+ sHangSX+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.HangSX=sHangSX;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NamSX(string sNamSX)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NamSX='"+ sNamSX+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NamSX=sNamSX;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NguyenGia(string sNguyenGia)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NguyenGia='"+ sNguyenGia+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NguyenGia=sNguyenGia;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_KhauHaoLK(string sKhauHaoLK)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET KhauHaoLK='"+ sKhauHaoLK+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.KhauHaoLK=sKhauHaoLK;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NgayNhap(string sNgayNhap)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NgayNhap='"+ sNgayNhap+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NgayNhap=sNgayNhap;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NgayKhauHao(string sNgayKhauHao)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NgayKhauHao='"+ sNgayKhauHao+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NgayKhauHao=sNgayKhauHao;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SoNamKH(string sSoNamKH)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET SoNamKH='"+ sSoNamKH+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.SoNamKH=sSoNamKH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TKNguyenGia(string sTKNguyenGia)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKNguyenGia='N"+ sTKNguyenGia+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TKNguyenGia=sTKNguyenGia;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TKKhauHao(string sTKKhauHao)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKKhauHao='N"+ sTKKhauHao+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TKKhauHao=sTKKhauHao;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TKDoiUng(string sTKDoiUng)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKDoiUng='N"+ sTKDoiUng+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TKDoiUng=sTKDoiUng;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TKChiPhi(string sTKChiPhi)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKChiPhi='N"+ sTKChiPhi+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TKChiPhi=sTKChiPhi;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TKChiPhiKhac(string sTKChiPhiKhac)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKChiPhiKhac='N"+ sTKChiPhiKhac+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TKChiPhiKhac=sTKChiPhiKhac;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SoHoaDonNhap(string sSoHoaDonNhap)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET SoHoaDonNhap='N"+ sSoHoaDonNhap+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.SoHoaDonNhap=sSoHoaDonNhap;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NgayLapHoaDon(string sNgayLapHoaDon)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NgayLapHoaDon='"+ sNgayLapHoaDon+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NgayLapHoaDon=sNgayLapHoaDon;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GiaTriConLai(string sGiaTriConLai)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET GiaTriConLai='"+ sGiaTriConLai+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.GiaTriConLai=sGiaTriConLai;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idkho(string sidkho)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET idkho='"+ sidkho+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.idkho=sidkho;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_soluong_hienco(string ssoluong_hienco)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET soluong_hienco='"+ ssoluong_hienco+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.soluong_hienco=ssoluong_hienco;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_isTSCD(string sisTSCD)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET isTSCD='"+ sisTSCD+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.isTSCD=sisTSCD;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_isCCDC(string sisCCDC)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET isCCDC='"+ sisCCDC+ "' WHERE danh_muc_ts_id='"+ this.danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.isCCDC=sisCCDC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_phieu_nhap_ct_id(string sphieu_nhap_ct_id,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET phieu_nhap_ct_id='"+sphieu_nhap_ct_id+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_phieu_xuat_ct_id(string sphieu_xuat_ct_id,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET phieu_xuat_ct_id='"+sphieu_xuat_ct_id+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MaTS(string sMaTS,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET MaTS='N"+sMaTS+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TenTaiSan(string sTenTaiSan,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TenTaiSan='N"+sTenTaiSan+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_HangSX(string sHangSX,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET HangSX='N"+sHangSX+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NamSX(string sNamSX,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NamSX='"+sNamSX+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NguyenGia(string sNguyenGia,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NguyenGia='"+sNguyenGia+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_KhauHaoLK(string sKhauHaoLK,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET KhauHaoLK='"+sKhauHaoLK+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NgayNhap(string sNgayNhap,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NgayNhap='"+sNgayNhap+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NgayKhauHao(string sNgayKhauHao,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NgayKhauHao='"+sNgayKhauHao+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SoNamKH(string sSoNamKH,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET SoNamKH='"+sSoNamKH+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TKNguyenGia(string sTKNguyenGia,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKNguyenGia='N"+sTKNguyenGia+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TKKhauHao(string sTKKhauHao,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKKhauHao='N"+sTKKhauHao+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TKDoiUng(string sTKDoiUng,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKDoiUng='N"+sTKDoiUng+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TKChiPhi(string sTKChiPhi,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKChiPhi='N"+sTKChiPhi+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TKChiPhiKhac(string sTKChiPhiKhac,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET TKChiPhiKhac='N"+sTKChiPhiKhac+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SoHoaDonNhap(string sSoHoaDonNhap,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET SoHoaDonNhap='N"+sSoHoaDonNhap+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NgayLapHoaDon(string sNgayLapHoaDon,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET NgayLapHoaDon='"+sNgayLapHoaDon+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GiaTriConLai(string sGiaTriConLai,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET GiaTriConLai='"+sGiaTriConLai+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idkho(string sidkho,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET idkho='"+sidkho+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_soluong_hienco(string ssoluong_hienco,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET soluong_hienco='"+ssoluong_hienco+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_isTSCD(string sisTSCD,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET isTSCD='"+sisTSCD+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_isCCDC(string sisCCDC,string s_danh_muc_ts_id)
{
    string sqlSave= " UPDATE DanhMucTaiSan SET isCCDC='"+sisCCDC+"' WHERE danh_muc_ts_id='"+ s_danh_muc_ts_id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM DanhMucTaiSan " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_DanhMucTaiSan;
   public static bool Change_dt_DanhMucTaiSan = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_DanhMucTaiSan()
   {
   if (dt_DanhMucTaiSan == null || Change_dt_DanhMucTaiSan == true)
   {
   dt_DanhMucTaiSan = dtGetAll();
   Change_dt_DanhMucTaiSan = true && AllowAutoChange ;
   }
   return dt_DanhMucTaiSan;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

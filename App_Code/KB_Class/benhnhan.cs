using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace Profess_1511
  { 
 public class benhnhan:  Connect { 
 public static string sTableName= "benhnhan"; 
   public string idbenhnhan;
   public string mabenhnhan;
   public string tenbenhnhan;
   public string idloaiuutien;
   public string diachi;
   public string dienthoai;
   public string gioitinh;
   public string ngaysinh;
   public string chungminhthu;
   public string loai;
   public string tiensubenhnhan;
   public string tinhtrangbandau;
   public string sobhyt;
   public string ngaybatdau;
   public string ngayhethan;
   public string thongtinbaotin;
   public string tencongty;
   public string thongtincongty;
   public string idloaibh;
   public string nghenghiep;
   public string noicongtac;
   public string noigioithieu;
   public string noidangkykcb;
   public string chandoansobo;
   public string ngaytiepnhan;
   public string DungTuyen;
   public string email;
   public string NguoiLH;
   public string DiaChiLH;
   public string DienThoaiLH;
   public string tenDN;
   public string matKhau;
   public string noicapbhyt;
   public string MaDangKy_KCB_bandau;
   public string NameNotSign;
   public string tinhid;
   public string quanhuyenid;
   public string phuongxaid;
   public string sonha;
   public string idNoiGioiThieu;
   public string SoThang;
   public string quoctich;
   public string dantoc;
   public string MucHuongBH;
   public string isgiaychuyen;
   public string IsCapCuu;
   public string IsDungTuyen;
   public string sobh1;
   public string sobh2;
   public string sobh3;
   public string sobh4;
   public string sobh5;
   public string sobh6;
   public string SOTT;
   public string SoTuoi;
   #region DataColumn Name ;
 public static  string cl_idbenhnhan="idbenhnhan" ;
 public static  string cl_idbenhnhan_VN="idbenhnhan";
 public static  string cl_mabenhnhan="mabenhnhan" ;
 public static  string cl_mabenhnhan_VN="mabenhnhan";
 public static  string cl_tenbenhnhan="tenbenhnhan" ;
 public static  string cl_tenbenhnhan_VN="tenbenhnhan";
 public static  string cl_idloaiuutien="idloaiuutien" ;
 public static  string cl_idloaiuutien_VN="idloaiuutien";
 public static  string cl_diachi="diachi" ;
 public static  string cl_diachi_VN="diachi";
 public static  string cl_dienthoai="dienthoai" ;
 public static  string cl_dienthoai_VN="dienthoai";
 public static  string cl_gioitinh="gioitinh" ;
 public static  string cl_gioitinh_VN="gioitinh";
 public static  string cl_ngaysinh="ngaysinh" ;
 public static  string cl_ngaysinh_VN="ngaysinh";
 public static  string cl_chungminhthu="chungminhthu" ;
 public static  string cl_chungminhthu_VN="chungminhthu";
 public static  string cl_loai="loai" ;
 public static  string cl_loai_VN="loai";
 public static  string cl_tiensubenhnhan="tiensubenhnhan" ;
 public static  string cl_tiensubenhnhan_VN="tiensubenhnhan";
 public static  string cl_tinhtrangbandau="tinhtrangbandau" ;
 public static  string cl_tinhtrangbandau_VN="tinhtrangbandau";
 public static  string cl_sobhyt="sobhyt" ;
 public static  string cl_sobhyt_VN="sobhyt";
 public static  string cl_ngaybatdau="ngaybatdau" ;
 public static  string cl_ngaybatdau_VN="ngaybatdau";
 public static  string cl_ngayhethan="ngayhethan" ;
 public static  string cl_ngayhethan_VN="ngayhethan";
 public static  string cl_thongtinbaotin="thongtinbaotin" ;
 public static  string cl_thongtinbaotin_VN="thongtinbaotin";
 public static  string cl_tencongty="tencongty" ;
 public static  string cl_tencongty_VN="tencongty";
 public static  string cl_thongtincongty="thongtincongty" ;
 public static  string cl_thongtincongty_VN="thongtincongty";
 public static  string cl_idloaibh="idloaibh" ;
 public static  string cl_idloaibh_VN="idloaibh";
 public static  string cl_nghenghiep="nghenghiep" ;
 public static  string cl_nghenghiep_VN="nghenghiep";
 public static  string cl_noicongtac="noicongtac" ;
 public static  string cl_noicongtac_VN="noicongtac";
 public static  string cl_noigioithieu="noigioithieu" ;
 public static  string cl_noigioithieu_VN="noigioithieu";
 public static  string cl_noidangkykcb="noidangkykcb" ;
 public static  string cl_noidangkykcb_VN="noidangkykcb";
 public static  string cl_chandoansobo="chandoansobo" ;
 public static  string cl_chandoansobo_VN="chandoansobo";
 public static  string cl_ngaytiepnhan="ngaytiepnhan" ;
 public static  string cl_ngaytiepnhan_VN="ngaytiepnhan";
 public static  string cl_DungTuyen="DungTuyen" ;
 public static  string cl_DungTuyen_VN="DungTuyen";
 public static  string cl_email="email" ;
 public static  string cl_email_VN="email";
 public static  string cl_NguoiLH="NguoiLH" ;
 public static  string cl_NguoiLH_VN="NguoiLH";
 public static  string cl_DiaChiLH="DiaChiLH" ;
 public static  string cl_DiaChiLH_VN="DiaChiLH";
 public static  string cl_DienThoaiLH="DienThoaiLH" ;
 public static  string cl_DienThoaiLH_VN="DienThoaiLH";
 public static  string cl_tenDN="tenDN" ;
 public static  string cl_tenDN_VN="tenDN";
 public static  string cl_matKhau="matKhau" ;
 public static  string cl_matKhau_VN="matKhau";
 public static  string cl_noicapbhyt="noicapbhyt" ;
 public static  string cl_noicapbhyt_VN="noicapbhyt";
 public static  string cl_MaDangKy_KCB_bandau="MaDangKy_KCB_bandau" ;
 public static  string cl_MaDangKy_KCB_bandau_VN="MaDangKy_KCB_bandau";
 public static  string cl_NameNotSign="NameNotSign" ;
 public static  string cl_NameNotSign_VN="NameNotSign";
 public static  string cl_tinhid="tinhid" ;
 public static  string cl_tinhid_VN="tinhid";
 public static  string cl_quanhuyenid="quanhuyenid" ;
 public static  string cl_quanhuyenid_VN="quanhuyenid";
 public static  string cl_phuongxaid="phuongxaid" ;
 public static  string cl_phuongxaid_VN="phuongxaid";
 public static  string cl_sonha="sonha" ;
 public static  string cl_sonha_VN="sonha";
 public static  string cl_idNoiGioiThieu="idNoiGioiThieu" ;
 public static  string cl_idNoiGioiThieu_VN="idNoiGioiThieu";
 public static  string cl_SoThang="SoThang" ;
 public static  string cl_SoThang_VN="SoThang";
 public static  string cl_quoctich="quoctich" ;
 public static  string cl_quoctich_VN="quoctich";
 public static  string cl_dantoc="dantoc" ;
 public static  string cl_dantoc_VN="dantoc";
 public static  string cl_MucHuongBH="MucHuongBH" ;
 public static  string cl_MucHuongBH_VN="MucHuongBH";
 public static  string cl_isgiaychuyen="isgiaychuyen" ;
 public static  string cl_isgiaychuyen_VN="isgiaychuyen";
 public static  string cl_IsCapCuu="IsCapCuu" ;
 public static  string cl_IsCapCuu_VN="IsCapCuu";
 public static  string cl_IsDungTuyen="IsDungTuyen" ;
 public static  string cl_IsDungTuyen_VN="IsDungTuyen";
 public static  string cl_sobh1="sobh1" ;
 public static  string cl_sobh1_VN="sobh1";
 public static  string cl_sobh2="sobh2" ;
 public static  string cl_sobh2_VN="sobh2";
 public static  string cl_sobh3="sobh3" ;
 public static  string cl_sobh3_VN="sobh3";
 public static  string cl_sobh4="sobh4" ;
 public static  string cl_sobh4_VN="sobh4";
 public static  string cl_sobh5="sobh5" ;
 public static  string cl_sobh5_VN="sobh5";
 public static  string cl_sobh6="sobh6" ;
 public static  string cl_sobh6_VN="sobh6";
 public static  string cl_SOTT="SOTT" ;
 public static  string cl_SOTT_VN="SOTT";
 public static  string cl_SoTuoi="SoTuoi" ;
 public static  string cl_SoTuoi_VN="SoTuoi";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public benhnhan() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public benhnhan(
         string sidbenhnhan,
         string smabenhnhan,
         string stenbenhnhan,
         string sidloaiuutien,
         string sdiachi,
         string sdienthoai,
         string sgioitinh,
         string sngaysinh,
         string schungminhthu,
         string sloai,
         string stiensubenhnhan,
         string stinhtrangbandau,
         string ssobhyt,
         string sngaybatdau,
         string sngayhethan,
         string sthongtinbaotin,
         string stencongty,
         string sthongtincongty,
         string sidloaibh,
         string snghenghiep,
         string snoicongtac,
         string snoigioithieu,
         string snoidangkykcb,
         string schandoansobo,
         string sngaytiepnhan,
         string sDungTuyen,
         string semail,
         string sNguoiLH,
         string sDiaChiLH,
         string sDienThoaiLH,
         string stenDN,
         string smatKhau,
         string snoicapbhyt,
         string sMaDangKy_KCB_bandau,
         string sNameNotSign,
         string stinhid,
         string squanhuyenid,
         string sphuongxaid,
         string ssonha,
         string sidNoiGioiThieu,
         string sSoThang,
         string squoctich,
         string sdantoc,
         string sMucHuongBH,
         string sisgiaychuyen,
         string sIsCapCuu,
         string sIsDungTuyen,
         string ssobh1,
         string ssobh2,
         string ssobh3,
         string ssobh4,
         string ssobh5,
         string ssobh6,
         string sSOTT,
         string sSoTuoi){
         this.idbenhnhan= sidbenhnhan;
         this.mabenhnhan= smabenhnhan;
         this.tenbenhnhan= stenbenhnhan;
         this.idloaiuutien= sidloaiuutien;
         this.diachi= sdiachi;
         this.dienthoai= sdienthoai;
         this.gioitinh= sgioitinh;
         this.ngaysinh= sngaysinh;
         this.chungminhthu= schungminhthu;
         this.loai= sloai;
         this.tiensubenhnhan= stiensubenhnhan;
         this.tinhtrangbandau= stinhtrangbandau;
         this.sobhyt= ssobhyt;
         this.ngaybatdau= sngaybatdau;
         this.ngayhethan= sngayhethan;
         this.thongtinbaotin= sthongtinbaotin;
         this.tencongty= stencongty;
         this.thongtincongty= sthongtincongty;
         this.idloaibh= sidloaibh;
         this.nghenghiep= snghenghiep;
         this.noicongtac= snoicongtac;
         this.noigioithieu= snoigioithieu;
         this.noidangkykcb= snoidangkykcb;
         this.chandoansobo= schandoansobo;
         this.ngaytiepnhan= sngaytiepnhan;
         this.DungTuyen= sDungTuyen;
         this.email= semail;
         this.NguoiLH= sNguoiLH;
         this.DiaChiLH= sDiaChiLH;
         this.DienThoaiLH= sDienThoaiLH;
         this.tenDN= stenDN;
         this.matKhau= smatKhau;
         this.noicapbhyt= snoicapbhyt;
         this.MaDangKy_KCB_bandau= sMaDangKy_KCB_bandau;
         this.NameNotSign= sNameNotSign;
         this.tinhid= stinhid;
         this.quanhuyenid= squanhuyenid;
         this.phuongxaid= sphuongxaid;
         this.sonha= ssonha;
         this.idNoiGioiThieu= sidNoiGioiThieu;
         this.SoThang= sSoThang;
         this.quoctich= squoctich;
         this.dantoc= sdantoc;
         this.MucHuongBH= sMucHuongBH;
         this.isgiaychuyen= sisgiaychuyen;
         this.IsCapCuu= sIsCapCuu;
         this.IsDungTuyen= sIsDungTuyen;
         this.sobh1= ssobh1;
         this.sobh2= ssobh2;
         this.sobh3= ssobh3;
         this.sobh4= ssobh4;
         this.sobh5= ssobh5;
         this.sobh6= ssobh6;
         this.SOTT= sSOTT;
         this.SoTuoi= sSoTuoi;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static benhnhan Create_benhnhan ( string sidbenhnhan  ){
    DataTable dt=dtSearchByidbenhnhan(sidbenhnhan) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new benhnhan(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM benhnhan AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public benhnhan( DataView dv,int pos)
{
         this.idbenhnhan= dv[pos][0].ToString();
         this.mabenhnhan= dv[pos][1].ToString();
         this.tenbenhnhan= dv[pos][2].ToString();
         this.idloaiuutien= dv[pos][3].ToString();
         this.diachi= dv[pos][4].ToString();
         this.dienthoai= dv[pos][5].ToString();
         this.gioitinh= dv[pos][6].ToString();
         this.ngaysinh= dv[pos][7].ToString();
         this.chungminhthu= dv[pos][8].ToString();
         this.loai= dv[pos][9].ToString();
         this.tiensubenhnhan= dv[pos][10].ToString();
         this.tinhtrangbandau= dv[pos][11].ToString();
         this.sobhyt= dv[pos][12].ToString();
         this.ngaybatdau= dv[pos][13].ToString();
         this.ngayhethan= dv[pos][14].ToString();
         this.thongtinbaotin= dv[pos][15].ToString();
         this.tencongty= dv[pos][16].ToString();
         this.thongtincongty= dv[pos][17].ToString();
         this.idloaibh= dv[pos][18].ToString();
         this.nghenghiep= dv[pos][19].ToString();
         this.noicongtac= dv[pos][20].ToString();
         this.noigioithieu= dv[pos][21].ToString();
         this.noidangkykcb= dv[pos][22].ToString();
         this.chandoansobo= dv[pos][23].ToString();
         this.ngaytiepnhan= dv[pos][24].ToString();
         this.DungTuyen= dv[pos][25].ToString();
         this.email= dv[pos][26].ToString();
         this.NguoiLH= dv[pos][27].ToString();
         this.DiaChiLH= dv[pos][28].ToString();
         this.DienThoaiLH= dv[pos][29].ToString();
         this.tenDN= dv[pos][30].ToString();
         this.matKhau= dv[pos][31].ToString();
         this.noicapbhyt= dv[pos][32].ToString();
         this.MaDangKy_KCB_bandau= dv[pos][33].ToString();
         this.NameNotSign= dv[pos][34].ToString();
         this.tinhid= dv[pos][35].ToString();
         this.quanhuyenid= dv[pos][36].ToString();
         this.phuongxaid= dv[pos][37].ToString();
         this.sonha= dv[pos][38].ToString();
         this.idNoiGioiThieu= dv[pos][39].ToString();
         this.SoThang= dv[pos][40].ToString();
         this.quoctich= dv[pos][41].ToString();
         this.dantoc= dv[pos][42].ToString();
         this.MucHuongBH= dv[pos][43].ToString();
         this.isgiaychuyen= dv[pos][44].ToString();
         this.IsCapCuu= dv[pos][45].ToString();
         this.IsDungTuyen= dv[pos][46].ToString();
         this.sobh1= dv[pos][47].ToString();
         this.sobh2= dv[pos][48].ToString();
         this.sobh3= dv[pos][49].ToString();
         this.sobh4= dv[pos][50].ToString();
         this.sobh5= dv[pos][51].ToString();
         this.sobh6= dv[pos][52].ToString();
         this.SOTT= dv[pos][53].ToString();
         this.SoTuoi= dv[pos][54].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
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
 public static DataTable dtSearchBymabenhnhan(string smabenhnhan)
{
          string sqlSelect= s_Select()+ " WHERE mabenhnhan  Like N'%"+ smabenhnhan + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytenbenhnhan(string stenbenhnhan)
{
          string sqlSelect= s_Select()+ " WHERE tenbenhnhan  Like N'%"+ stenbenhnhan + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidloaiuutien(string sidloaiuutien)
{
          string sqlSelect= s_Select()+ " WHERE idloaiuutien  ="+ sidloaiuutien + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidloaiuutien(string sidloaiuutien,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idloaiuutien"+ sMatch +sidloaiuutien + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydiachi(string sdiachi)
{
          string sqlSelect= s_Select()+ " WHERE diachi  Like N'%"+ sdiachi + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydienthoai(string sdienthoai)
{
          string sqlSelect= s_Select()+ " WHERE dienthoai  Like N'%"+ sdienthoai + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBygioitinh(string sgioitinh)
{
          string sqlSelect= s_Select()+ " WHERE gioitinh  ="+ sgioitinh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBygioitinh(string sgioitinh,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE gioitinh"+ sMatch +sgioitinh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaysinh(string sngaysinh)
{
          string sqlSelect= s_Select()+ " WHERE ngaysinh  Like N'%"+ sngaysinh + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBychungminhthu(string schungminhthu)
{
          string sqlSelect= s_Select()+ " WHERE chungminhthu  Like N'%"+ schungminhthu + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByloai(string sloai)
{
          string sqlSelect= s_Select()+ " WHERE loai  ="+ sloai + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByloai(string sloai,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE loai"+ sMatch +sloai + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytiensubenhnhan(string stiensubenhnhan)
{
          string sqlSelect= s_Select()+ " WHERE tiensubenhnhan  Like N'%"+ stiensubenhnhan + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytinhtrangbandau(string stinhtrangbandau)
{
          string sqlSelect= s_Select()+ " WHERE tinhtrangbandau  Like N'%"+ stinhtrangbandau + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysobhyt(string ssobhyt)
{
          string sqlSelect= s_Select()+ " WHERE sobhyt  Like N'%"+ ssobhyt + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaybatdau(string sngaybatdau)
{
          string sqlSelect= s_Select()+ " WHERE ngaybatdau  ="+ sngaybatdau + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaybatdau(string sngaybatdau,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ngaybatdau"+ sMatch +sngaybatdau + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngayhethan(string sngayhethan)
{
          string sqlSelect= s_Select()+ " WHERE ngayhethan  ="+ sngayhethan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngayhethan(string sngayhethan,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ngayhethan"+ sMatch +sngayhethan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBythongtinbaotin(string sthongtinbaotin)
{
          string sqlSelect= s_Select()+ " WHERE thongtinbaotin  Like N'%"+ sthongtinbaotin + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytencongty(string stencongty)
{
          string sqlSelect= s_Select()+ " WHERE tencongty  Like N'%"+ stencongty + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBythongtincongty(string sthongtincongty)
{
          string sqlSelect= s_Select()+ " WHERE thongtincongty  Like N'%"+ sthongtincongty + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidloaibh(string sidloaibh)
{
          string sqlSelect= s_Select()+ " WHERE idloaibh  ="+ sidloaibh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidloaibh(string sidloaibh,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idloaibh"+ sMatch +sidloaibh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynghenghiep(string snghenghiep)
{
          string sqlSelect= s_Select()+ " WHERE nghenghiep  Like N'%"+ snghenghiep + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynoicongtac(string snoicongtac)
{
          string sqlSelect= s_Select()+ " WHERE noicongtac  Like N'%"+ snoicongtac + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynoigioithieu(string snoigioithieu)
{
          string sqlSelect= s_Select()+ " WHERE noigioithieu  Like N'%"+ snoigioithieu + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynoidangkykcb(string snoidangkykcb)
{
          string sqlSelect= s_Select()+ " WHERE noidangkykcb  Like N'%"+ snoidangkykcb + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBychandoansobo(string schandoansobo)
{
          string sqlSelect= s_Select()+ " WHERE chandoansobo  Like N'%"+ schandoansobo + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaytiepnhan(string sngaytiepnhan)
{
          string sqlSelect= s_Select()+ " WHERE ngaytiepnhan  ="+ sngaytiepnhan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaytiepnhan(string sngaytiepnhan,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ngaytiepnhan"+ sMatch +sngaytiepnhan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDungTuyen(string sDungTuyen)
{
          string sqlSelect= s_Select()+ " WHERE DungTuyen  Like N'%"+ sDungTuyen + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByemail(string semail)
{
          string sqlSelect= s_Select()+ " WHERE email  Like N'%"+ semail + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNguoiLH(string sNguoiLH)
{
          string sqlSelect= s_Select()+ " WHERE NguoiLH  Like N'%"+ sNguoiLH + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDiaChiLH(string sDiaChiLH)
{
          string sqlSelect= s_Select()+ " WHERE DiaChiLH  Like N'%"+ sDiaChiLH + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDienThoaiLH(string sDienThoaiLH)
{
          string sqlSelect= s_Select()+ " WHERE DienThoaiLH  Like N'%"+ sDienThoaiLH + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytenDN(string stenDN)
{
          string sqlSelect= s_Select()+ " WHERE tenDN  Like N'%"+ stenDN + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBymatKhau(string smatKhau)
{
          string sqlSelect= s_Select()+ " WHERE matKhau  Like N'%"+ smatKhau + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynoicapbhyt(string snoicapbhyt)
{
          string sqlSelect= s_Select()+ " WHERE noicapbhyt  Like N'%"+ snoicapbhyt + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMaDangKy_KCB_bandau(string sMaDangKy_KCB_bandau)
{
          string sqlSelect= s_Select()+ " WHERE MaDangKy_KCB_bandau  Like N'%"+ sMaDangKy_KCB_bandau + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNameNotSign(string sNameNotSign)
{
          string sqlSelect= s_Select()+ " WHERE NameNotSign  Like N'%"+ sNameNotSign + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytinhid(string stinhid)
{
          string sqlSelect= s_Select()+ " WHERE tinhid  ="+ stinhid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytinhid(string stinhid,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE tinhid"+ sMatch +stinhid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByquanhuyenid(string squanhuyenid)
{
          string sqlSelect= s_Select()+ " WHERE quanhuyenid  ="+ squanhuyenid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByquanhuyenid(string squanhuyenid,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE quanhuyenid"+ sMatch +squanhuyenid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByphuongxaid(string sphuongxaid)
{
          string sqlSelect= s_Select()+ " WHERE phuongxaid  ="+ sphuongxaid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByphuongxaid(string sphuongxaid,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE phuongxaid"+ sMatch +sphuongxaid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysonha(string ssonha)
{
          string sqlSelect= s_Select()+ " WHERE sonha  Like N'%"+ ssonha + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidNoiGioiThieu(string sidNoiGioiThieu)
{
          string sqlSelect= s_Select()+ " WHERE idNoiGioiThieu  ="+ sidNoiGioiThieu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidNoiGioiThieu(string sidNoiGioiThieu,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idNoiGioiThieu"+ sMatch +sidNoiGioiThieu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySoThang(string sSoThang)
{
          string sqlSelect= s_Select()+ " WHERE SoThang  ="+ sSoThang + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySoThang(string sSoThang,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SoThang"+ sMatch +sSoThang + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByquoctich(string squoctich)
{
          string sqlSelect= s_Select()+ " WHERE quoctich  Like N'%"+ squoctich + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydantoc(string sdantoc)
{
          string sqlSelect= s_Select()+ " WHERE dantoc  Like N'%"+ sdantoc + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMucHuongBH(string sMucHuongBH)
{
          string sqlSelect= s_Select()+ " WHERE MucHuongBH  ="+ sMucHuongBH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMucHuongBH(string sMucHuongBH,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE MucHuongBH"+ sMatch +sMucHuongBH + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByisgiaychuyen(string sisgiaychuyen)
{
          string sqlSelect= s_Select()+ " WHERE isgiaychuyen  ="+ sisgiaychuyen + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByisgiaychuyen(string sisgiaychuyen,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE isgiaychuyen"+ sMatch +sisgiaychuyen + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsCapCuu(string sIsCapCuu)
{
          string sqlSelect= s_Select()+ " WHERE IsCapCuu  ="+ sIsCapCuu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsCapCuu(string sIsCapCuu,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IsCapCuu"+ sMatch +sIsCapCuu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsDungTuyen(string sIsDungTuyen)
{
          string sqlSelect= s_Select()+ " WHERE IsDungTuyen  ="+ sIsDungTuyen + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsDungTuyen(string sIsDungTuyen,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IsDungTuyen"+ sMatch +sIsDungTuyen + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysobh1(string ssobh1)
{
          string sqlSelect= s_Select()+ " WHERE sobh1  Like N'%"+ ssobh1 + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysobh2(string ssobh2)
{
          string sqlSelect= s_Select()+ " WHERE sobh2  Like N'%"+ ssobh2 + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysobh3(string ssobh3)
{
          string sqlSelect= s_Select()+ " WHERE sobh3  Like N'%"+ ssobh3 + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysobh4(string ssobh4)
{
          string sqlSelect= s_Select()+ " WHERE sobh4  Like N'%"+ ssobh4 + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysobh5(string ssobh5)
{
          string sqlSelect= s_Select()+ " WHERE sobh5  Like N'%"+ ssobh5 + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBysobh6(string ssobh6)
{
          string sqlSelect= s_Select()+ " WHERE sobh6  Like N'%"+ ssobh6 + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySOTT(string sSOTT)
{
          string sqlSelect= s_Select()+ " WHERE SOTT  ="+ sSOTT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySOTT(string sSOTT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SOTT"+ sMatch +sSOTT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySoTuoi(string sSoTuoi)
{
          string sqlSelect= s_Select()+ " WHERE SoTuoi  ="+ sSoTuoi + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySoTuoi(string sSoTuoi,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE SoTuoi"+ sMatch +sSoTuoi + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sidbenhnhan
            , string smabenhnhan
            , string stenbenhnhan
            , string sidloaiuutien
            , string sdiachi
            , string sdienthoai
            , string sgioitinh
            , string sngaysinh
            , string schungminhthu
            , string sloai
            , string stiensubenhnhan
            , string stinhtrangbandau
            , string ssobhyt
            , string sngaybatdau
            , string sngayhethan
            , string sthongtinbaotin
            , string stencongty
            , string sthongtincongty
            , string sidloaibh
            , string snghenghiep
            , string snoicongtac
            , string snoigioithieu
            , string snoidangkykcb
            , string schandoansobo
            , string sngaytiepnhan
            , string sDungTuyen
            , string semail
            , string sNguoiLH
            , string sDiaChiLH
            , string sDienThoaiLH
            , string stenDN
            , string smatKhau
            , string snoicapbhyt
            , string sMaDangKy_KCB_bandau
            , string sNameNotSign
            , string stinhid
            , string squanhuyenid
            , string sphuongxaid
            , string ssonha
            , string sidNoiGioiThieu
            , string sSoThang
            , string squoctich
            , string sdantoc
            , string sMucHuongBH
            , string sisgiaychuyen
            , string sIsCapCuu
            , string sIsDungTuyen
            , string ssobh1
            , string ssobh2
            , string ssobh3
            , string ssobh4
            , string ssobh5
            , string ssobh6
            , string sSOTT
            , string sSoTuoi
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sidbenhnhan!=null && sidbenhnhan!="") 
            sqlselect +=" AND idbenhnhan =" + sidbenhnhan ;
      if (smabenhnhan!=null && smabenhnhan!="") 
            sqlselect +=" AND mabenhnhan LIKE N'%" + smabenhnhan +"%'" ;
      if (stenbenhnhan!=null && stenbenhnhan!="") 
            sqlselect +=" AND tenbenhnhan LIKE N'%" + stenbenhnhan +"%'" ;
      if (sidloaiuutien!=null && sidloaiuutien!="") 
            sqlselect +=" AND idloaiuutien =" + sidloaiuutien ;
      if (sdiachi!=null && sdiachi!="") 
            sqlselect +=" AND diachi LIKE N'%" + sdiachi +"%'" ;
      if (sdienthoai!=null && sdienthoai!="") 
            sqlselect +=" AND dienthoai LIKE N'%" + sdienthoai +"%'" ;
      if (sgioitinh!=null && sgioitinh!="") 
            sqlselect +=" AND gioitinh =" + sgioitinh ;
      if (sngaysinh!=null && sngaysinh!="") 
            sqlselect +=" AND ngaysinh LIKE N'%" + sngaysinh +"%'" ;
      if (schungminhthu!=null && schungminhthu!="") 
            sqlselect +=" AND chungminhthu LIKE N'%" + schungminhthu +"%'" ;
      if (sloai!=null && sloai!="") 
            sqlselect +=" AND loai =" + sloai ;
      if (stiensubenhnhan!=null && stiensubenhnhan!="") 
            sqlselect +=" AND tiensubenhnhan LIKE N'%" + stiensubenhnhan +"%'" ;
      if (stinhtrangbandau!=null && stinhtrangbandau!="") 
            sqlselect +=" AND tinhtrangbandau LIKE N'%" + stinhtrangbandau +"%'" ;
      if (ssobhyt!=null && ssobhyt!="") 
            sqlselect +=" AND sobhyt LIKE N'%" + ssobhyt +"%'" ;
      if (sngaybatdau!=null && sngaybatdau!="") 
            sqlselect +=" AND ngaybatdau LIKE '%" + sngaybatdau +"%'" ;
      if (sngayhethan!=null && sngayhethan!="") 
            sqlselect +=" AND ngayhethan LIKE '%" + sngayhethan +"%'" ;
      if (sthongtinbaotin!=null && sthongtinbaotin!="") 
            sqlselect +=" AND thongtinbaotin LIKE N'%" + sthongtinbaotin +"%'" ;
      if (stencongty!=null && stencongty!="") 
            sqlselect +=" AND tencongty LIKE N'%" + stencongty +"%'" ;
      if (sthongtincongty!=null && sthongtincongty!="") 
            sqlselect +=" AND thongtincongty LIKE N'%" + sthongtincongty +"%'" ;
      if (sidloaibh!=null && sidloaibh!="") 
            sqlselect +=" AND idloaibh =" + sidloaibh ;
      if (snghenghiep!=null && snghenghiep!="") 
            sqlselect +=" AND nghenghiep LIKE N'%" + snghenghiep +"%'" ;
      if (snoicongtac!=null && snoicongtac!="") 
            sqlselect +=" AND noicongtac LIKE N'%" + snoicongtac +"%'" ;
      if (snoigioithieu!=null && snoigioithieu!="") 
            sqlselect +=" AND noigioithieu LIKE N'%" + snoigioithieu +"%'" ;
      if (snoidangkykcb!=null && snoidangkykcb!="") 
            sqlselect +=" AND noidangkykcb LIKE N'%" + snoidangkykcb +"%'" ;
      if (schandoansobo!=null && schandoansobo!="") 
            sqlselect +=" AND chandoansobo LIKE N'%" + schandoansobo +"%'" ;
      if (sngaytiepnhan!=null && sngaytiepnhan!="") 
            sqlselect +=" AND ngaytiepnhan LIKE '%" + sngaytiepnhan +"%'" ;
      if (sDungTuyen!=null && sDungTuyen!="") 
            sqlselect +=" AND DungTuyen LIKE N'%" + sDungTuyen +"%'" ;
      if (semail!=null && semail!="") 
            sqlselect +=" AND email LIKE N'%" + semail +"%'" ;
      if (sNguoiLH!=null && sNguoiLH!="") 
            sqlselect +=" AND NguoiLH LIKE N'%" + sNguoiLH +"%'" ;
      if (sDiaChiLH!=null && sDiaChiLH!="") 
            sqlselect +=" AND DiaChiLH LIKE N'%" + sDiaChiLH +"%'" ;
      if (sDienThoaiLH!=null && sDienThoaiLH!="") 
            sqlselect +=" AND DienThoaiLH LIKE N'%" + sDienThoaiLH +"%'" ;
      if (stenDN!=null && stenDN!="") 
            sqlselect +=" AND tenDN LIKE N'%" + stenDN +"%'" ;
      if (smatKhau!=null && smatKhau!="") 
            sqlselect +=" AND matKhau LIKE N'%" + smatKhau +"%'" ;
      if (snoicapbhyt!=null && snoicapbhyt!="") 
            sqlselect +=" AND noicapbhyt LIKE N'%" + snoicapbhyt +"%'" ;
      if (sMaDangKy_KCB_bandau!=null && sMaDangKy_KCB_bandau!="") 
            sqlselect +=" AND MaDangKy_KCB_bandau LIKE N'%" + sMaDangKy_KCB_bandau +"%'" ;
      if (sNameNotSign!=null && sNameNotSign!="") 
            sqlselect +=" AND NameNotSign LIKE N'%" + sNameNotSign +"%'" ;
      if (stinhid!=null && stinhid!="") 
            sqlselect +=" AND tinhid =" + stinhid ;
      if (squanhuyenid!=null && squanhuyenid!="") 
            sqlselect +=" AND quanhuyenid =" + squanhuyenid ;
      if (sphuongxaid!=null && sphuongxaid!="") 
            sqlselect +=" AND phuongxaid =" + sphuongxaid ;
      if (ssonha!=null && ssonha!="") 
            sqlselect +=" AND sonha LIKE N'%" + ssonha +"%'" ;
      if (sidNoiGioiThieu!=null && sidNoiGioiThieu!="") 
            sqlselect +=" AND idNoiGioiThieu =" + sidNoiGioiThieu ;
      if (sSoThang!=null && sSoThang!="") 
            sqlselect +=" AND SoThang =" + sSoThang ;
      if (squoctich!=null && squoctich!="") 
            sqlselect +=" AND quoctich LIKE N'%" + squoctich +"%'" ;
      if (sdantoc!=null && sdantoc!="") 
            sqlselect +=" AND dantoc LIKE N'%" + sdantoc +"%'" ;
      if (sMucHuongBH!=null && sMucHuongBH!="") 
            sqlselect +=" AND MucHuongBH =" + sMucHuongBH ;
      if (sisgiaychuyen!=null && sisgiaychuyen!="") 
            sqlselect +=" AND isgiaychuyen =" + sisgiaychuyen ;
      if (sIsCapCuu!=null && sIsCapCuu!="") 
            sqlselect +=" AND IsCapCuu =" + sIsCapCuu ;
      if (sIsDungTuyen!=null && sIsDungTuyen!="") 
            sqlselect +=" AND IsDungTuyen =" + sIsDungTuyen ;
      if (ssobh1!=null && ssobh1!="") 
            sqlselect +=" AND sobh1 LIKE N'%" + ssobh1 +"%'" ;
      if (ssobh2!=null && ssobh2!="") 
            sqlselect +=" AND sobh2 LIKE N'%" + ssobh2 +"%'" ;
      if (ssobh3!=null && ssobh3!="") 
            sqlselect +=" AND sobh3 LIKE N'%" + ssobh3 +"%'" ;
      if (ssobh4!=null && ssobh4!="") 
            sqlselect +=" AND sobh4 LIKE N'%" + ssobh4 +"%'" ;
      if (ssobh5!=null && ssobh5!="") 
            sqlselect +=" AND sobh5 LIKE N'%" + ssobh5 +"%'" ;
      if (ssobh6!=null && ssobh6!="") 
            sqlselect +=" AND sobh6 LIKE N'%" + ssobh6 +"%'" ;
      if (sSOTT!=null && sSOTT!="") 
            sqlselect +=" AND SOTT =" + sSOTT ;
      if (sSoTuoi!=null && sSoTuoi!="") 
            sqlselect +=" AND SoTuoi =" + sSoTuoi ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static benhnhan Insert_Object(
string  smabenhnhan
            ,string  stenbenhnhan
            ,string  sidloaiuutien
            ,string  sdiachi
            ,string  sdienthoai
            ,string  sgioitinh
            ,string  sngaysinh
            ,string  schungminhthu
            ,string  sloai
            ,string  stiensubenhnhan
            ,string  stinhtrangbandau
            ,string  ssobhyt
            ,string  sngaybatdau
            ,string  sngayhethan
            ,string  sthongtinbaotin
            ,string  stencongty
            ,string  sthongtincongty
            ,string  sidloaibh
            ,string  snghenghiep
            ,string  snoicongtac
            ,string  snoigioithieu
            ,string  snoidangkykcb
            ,string  schandoansobo
            ,string  sngaytiepnhan
            ,string  sDungTuyen
            ,string  semail
            ,string  sNguoiLH
            ,string  sDiaChiLH
            ,string  sDienThoaiLH
            ,string  stenDN
            ,string  smatKhau
            ,string  snoicapbhyt
            ,string  sMaDangKy_KCB_bandau
            ,string  sNameNotSign
            ,string  stinhid
            ,string  squanhuyenid
            ,string  sphuongxaid
            ,string  ssonha
            ,string  sidNoiGioiThieu
            ,string  sSoThang
            ,string  squoctich
            ,string  sdantoc
            ,string  sMucHuongBH
            ,string  sisgiaychuyen
            ,string  sIsCapCuu
            ,string  sIsDungTuyen
            ,string  ssobh1
            ,string  ssobh2
            ,string  ssobh3
            ,string  ssobh4
            ,string  ssobh5
            ,string  ssobh6
            ,string  sSOTT
            ,string  sSoTuoi
            ) 
 { 
              string tem_smabenhnhan=DataAcess.hsSqlTool.sGetSaveValue(smabenhnhan,"varchar");
              string tem_stenbenhnhan=DataAcess.hsSqlTool.sGetSaveValue(stenbenhnhan,"nvarchar");
              string tem_sidloaiuutien=DataAcess.hsSqlTool.sGetSaveValue(sidloaiuutien,"bigint");
              string tem_sdiachi=DataAcess.hsSqlTool.sGetSaveValue(sdiachi,"nvarchar");
              string tem_sdienthoai=DataAcess.hsSqlTool.sGetSaveValue(sdienthoai,"varchar");
              string tem_sgioitinh=DataAcess.hsSqlTool.sGetSaveValue(sgioitinh,"tinyint");
              string tem_sngaysinh=DataAcess.hsSqlTool.sGetSaveValue(sngaysinh,"nvarchar");
              string tem_schungminhthu=DataAcess.hsSqlTool.sGetSaveValue(schungminhthu,"varchar");
              string tem_sloai=DataAcess.hsSqlTool.sGetSaveValue(sloai,"bigint");
              string tem_stiensubenhnhan=DataAcess.hsSqlTool.sGetSaveValue(stiensubenhnhan,"nvarchar");
              string tem_stinhtrangbandau=DataAcess.hsSqlTool.sGetSaveValue(stinhtrangbandau,"nvarchar");
              string tem_ssobhyt=DataAcess.hsSqlTool.sGetSaveValue(ssobhyt,"varchar");
              string tem_sngaybatdau=DataAcess.hsSqlTool.sGetSaveValue(sngaybatdau,"datetime");
              string tem_sngayhethan=DataAcess.hsSqlTool.sGetSaveValue(sngayhethan,"datetime");
              string tem_sthongtinbaotin=DataAcess.hsSqlTool.sGetSaveValue(sthongtinbaotin,"nvarchar");
              string tem_stencongty=DataAcess.hsSqlTool.sGetSaveValue(stencongty,"nvarchar");
              string tem_sthongtincongty=DataAcess.hsSqlTool.sGetSaveValue(sthongtincongty,"nvarchar");
              string tem_sidloaibh=DataAcess.hsSqlTool.sGetSaveValue(sidloaibh,"smallint");
              string tem_snghenghiep=DataAcess.hsSqlTool.sGetSaveValue(snghenghiep,"nvarchar");
              string tem_snoicongtac=DataAcess.hsSqlTool.sGetSaveValue(snoicongtac,"nvarchar");
              string tem_snoigioithieu=DataAcess.hsSqlTool.sGetSaveValue(snoigioithieu,"nvarchar");
              string tem_snoidangkykcb=DataAcess.hsSqlTool.sGetSaveValue(snoidangkykcb,"nvarchar");
              string tem_schandoansobo=DataAcess.hsSqlTool.sGetSaveValue(schandoansobo,"nvarchar");
              string tem_sngaytiepnhan=DataAcess.hsSqlTool.sGetSaveValue(sngaytiepnhan,"datetime");
              string tem_sDungTuyen=DataAcess.hsSqlTool.sGetSaveValue(sDungTuyen,"nvarchar");
              string tem_semail=DataAcess.hsSqlTool.sGetSaveValue(semail,"nvarchar");
              string tem_sNguoiLH=DataAcess.hsSqlTool.sGetSaveValue(sNguoiLH,"nvarchar");
              string tem_sDiaChiLH=DataAcess.hsSqlTool.sGetSaveValue(sDiaChiLH,"nvarchar");
              string tem_sDienThoaiLH=DataAcess.hsSqlTool.sGetSaveValue(sDienThoaiLH,"nvarchar");
              string tem_stenDN=DataAcess.hsSqlTool.sGetSaveValue(stenDN,"nvarchar");
              string tem_smatKhau=DataAcess.hsSqlTool.sGetSaveValue(smatKhau,"nvarchar");
              string tem_snoicapbhyt=DataAcess.hsSqlTool.sGetSaveValue(snoicapbhyt,"nvarchar");
              string tem_sMaDangKy_KCB_bandau=DataAcess.hsSqlTool.sGetSaveValue(sMaDangKy_KCB_bandau,"nchar");
              string tem_sNameNotSign=DataAcess.hsSqlTool.sGetSaveValue(sNameNotSign,"nvarchar");
              string tem_stinhid=DataAcess.hsSqlTool.sGetSaveValue(stinhid,"int");
              string tem_squanhuyenid=DataAcess.hsSqlTool.sGetSaveValue(squanhuyenid,"int");
              string tem_sphuongxaid=DataAcess.hsSqlTool.sGetSaveValue(sphuongxaid,"int");
              string tem_ssonha=DataAcess.hsSqlTool.sGetSaveValue(ssonha,"nvarchar");
              string tem_sidNoiGioiThieu=DataAcess.hsSqlTool.sGetSaveValue(sidNoiGioiThieu,"int");
              string tem_sSoThang=DataAcess.hsSqlTool.sGetSaveValue(sSoThang,"int");
              string tem_squoctich=DataAcess.hsSqlTool.sGetSaveValue(squoctich,"nvarchar");
              string tem_sdantoc=DataAcess.hsSqlTool.sGetSaveValue(sdantoc,"nvarchar");
              string tem_sMucHuongBH=DataAcess.hsSqlTool.sGetSaveValue(sMucHuongBH,"int");
              string tem_sisgiaychuyen=DataAcess.hsSqlTool.sGetSaveValue(sisgiaychuyen,"bit");
              string tem_sIsCapCuu=DataAcess.hsSqlTool.sGetSaveValue(sIsCapCuu,"bit");
              string tem_sIsDungTuyen=DataAcess.hsSqlTool.sGetSaveValue(sIsDungTuyen,"bit");
              string tem_ssobh1=DataAcess.hsSqlTool.sGetSaveValue(ssobh1,"char");
              string tem_ssobh2=DataAcess.hsSqlTool.sGetSaveValue(ssobh2,"char");
              string tem_ssobh3=DataAcess.hsSqlTool.sGetSaveValue(ssobh3,"char");
              string tem_ssobh4=DataAcess.hsSqlTool.sGetSaveValue(ssobh4,"char");
              string tem_ssobh5=DataAcess.hsSqlTool.sGetSaveValue(ssobh5,"char");
              string tem_ssobh6=DataAcess.hsSqlTool.sGetSaveValue(ssobh6,"char");
              string tem_sSOTT=DataAcess.hsSqlTool.sGetSaveValue(sSOTT,"bigint");
              string tem_sSoTuoi=DataAcess.hsSqlTool.sGetSaveValue(sSoTuoi,"int");

             string sqlSave=" INSERT INTO benhnhan("+
                   "mabenhnhan," 
        +                   "tenbenhnhan," 
        +                   "idloaiuutien," 
        +                   "diachi," 
        +                   "dienthoai," 
        +                   "gioitinh," 
        +                   "ngaysinh," 
        +                   "chungminhthu," 
        +                   "loai," 
        +                   "tiensubenhnhan," 
        +                   "tinhtrangbandau," 
        +                   "sobhyt," 
        +                   "ngaybatdau," 
        +                   "ngayhethan," 
        +                   "thongtinbaotin," 
        +                   "tencongty," 
        +                   "thongtincongty," 
        +                   "idloaibh," 
        +                   "nghenghiep," 
        +                   "noicongtac," 
        +                   "noigioithieu," 
        +                   "noidangkykcb," 
        +                   "chandoansobo," 
        +                   "ngaytiepnhan," 
        +                   "DungTuyen," 
        +                   "email," 
        +                   "NguoiLH," 
        +                   "DiaChiLH," 
        +                   "DienThoaiLH," 
        +                   "tenDN," 
        +                   "matKhau," 
        +                   "noicapbhyt," 
        +                   "MaDangKy_KCB_bandau," 
        +                   "NameNotSign," 
        +                   "tinhid," 
        +                   "quanhuyenid," 
        +                   "phuongxaid," 
        +                   "sonha," 
        +                   "idNoiGioiThieu," 
        +                   "SoThang," 
        +                   "quoctich," 
        +                   "dantoc," 
        +                   "MucHuongBH," 
        +                   "isgiaychuyen," 
        +                   "IsCapCuu," 
        +                   "IsDungTuyen," 
        +                   "sobh1," 
        +                   "sobh2," 
        +                   "sobh3," 
        +                   "sobh4," 
        +                   "sobh5," 
        +                   "sobh6," 
        +                   "SOTT," 
        +                   "SoTuoi) VALUES("
 +tem_smabenhnhan+","
 +tem_stenbenhnhan+","
 +tem_sidloaiuutien+","
 +tem_sdiachi+","
 +tem_sdienthoai+","
 +tem_sgioitinh+","
 +tem_sngaysinh+","
 +tem_schungminhthu+","
 +tem_sloai+","
 +tem_stiensubenhnhan+","
 +tem_stinhtrangbandau+","
 +tem_ssobhyt+","
 +tem_sngaybatdau+","
 +tem_sngayhethan+","
 +tem_sthongtinbaotin+","
 +tem_stencongty+","
 +tem_sthongtincongty+","
 +tem_sidloaibh+","
 +tem_snghenghiep+","
 +tem_snoicongtac+","
 +tem_snoigioithieu+","
 +tem_snoidangkykcb+","
 +tem_schandoansobo+","
 +tem_sngaytiepnhan+","
 +tem_sDungTuyen+","
 +tem_semail+","
 +tem_sNguoiLH+","
 +tem_sDiaChiLH+","
 +tem_sDienThoaiLH+","
 +tem_stenDN+","
 +tem_smatKhau+","
 +tem_snoicapbhyt+","
 +tem_sMaDangKy_KCB_bandau+","
 +tem_sNameNotSign+","
 +tem_stinhid+","
 +tem_squanhuyenid+","
 +tem_sphuongxaid+","
 +tem_ssonha+","
 +tem_sidNoiGioiThieu+","
 +tem_sSoThang+","
 +tem_squoctich+","
 +tem_sdantoc+","
 +tem_sMucHuongBH+","
 +tem_sisgiaychuyen+","
 +tem_sIsCapCuu+","
 +tem_sIsDungTuyen+","
 +tem_ssobh1+","
 +tem_ssobh2+","
 +tem_ssobh3+","
 +tem_ssobh4+","
 +tem_ssobh5+","
 +tem_ssobh6+","
 +tem_sSOTT+","
 +tem_sSoTuoi +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          benhnhan newbenhnhan= new benhnhan();
                 newbenhnhan.idbenhnhan=GetTable( " SELECT TOP 1 idbenhnhan FROM benhnhan ORDER BY idbenhnhan DESC ").Rows[0][0].ToString();
              newbenhnhan.mabenhnhan=smabenhnhan;
              newbenhnhan.tenbenhnhan=stenbenhnhan;
              newbenhnhan.idloaiuutien=sidloaiuutien;
              newbenhnhan.diachi=sdiachi;
              newbenhnhan.dienthoai=sdienthoai;
              newbenhnhan.gioitinh=sgioitinh;
              newbenhnhan.ngaysinh=sngaysinh;
              newbenhnhan.chungminhthu=schungminhthu;
              newbenhnhan.loai=sloai;
              newbenhnhan.tiensubenhnhan=stiensubenhnhan;
              newbenhnhan.tinhtrangbandau=stinhtrangbandau;
              newbenhnhan.sobhyt=ssobhyt;
              newbenhnhan.ngaybatdau=sngaybatdau;
              newbenhnhan.ngayhethan=sngayhethan;
              newbenhnhan.thongtinbaotin=sthongtinbaotin;
              newbenhnhan.tencongty=stencongty;
              newbenhnhan.thongtincongty=sthongtincongty;
              newbenhnhan.idloaibh=sidloaibh;
              newbenhnhan.nghenghiep=snghenghiep;
              newbenhnhan.noicongtac=snoicongtac;
              newbenhnhan.noigioithieu=snoigioithieu;
              newbenhnhan.noidangkykcb=snoidangkykcb;
              newbenhnhan.chandoansobo=schandoansobo;
              newbenhnhan.ngaytiepnhan=sngaytiepnhan;
              newbenhnhan.DungTuyen=sDungTuyen;
              newbenhnhan.email=semail;
              newbenhnhan.NguoiLH=sNguoiLH;
              newbenhnhan.DiaChiLH=sDiaChiLH;
              newbenhnhan.DienThoaiLH=sDienThoaiLH;
              newbenhnhan.tenDN=stenDN;
              newbenhnhan.matKhau=smatKhau;
              newbenhnhan.noicapbhyt=snoicapbhyt;
              newbenhnhan.MaDangKy_KCB_bandau=sMaDangKy_KCB_bandau;
              newbenhnhan.NameNotSign=sNameNotSign;
              newbenhnhan.tinhid=stinhid;
              newbenhnhan.quanhuyenid=squanhuyenid;
              newbenhnhan.phuongxaid=sphuongxaid;
              newbenhnhan.sonha=ssonha;
              newbenhnhan.idNoiGioiThieu=sidNoiGioiThieu;
              newbenhnhan.SoThang=sSoThang;
              newbenhnhan.quoctich=squoctich;
              newbenhnhan.dantoc=sdantoc;
              newbenhnhan.MucHuongBH=sMucHuongBH;
              newbenhnhan.isgiaychuyen=sisgiaychuyen;
              newbenhnhan.IsCapCuu=sIsCapCuu;
              newbenhnhan.IsDungTuyen=sIsDungTuyen;
              newbenhnhan.sobh1=ssobh1;
              newbenhnhan.sobh2=ssobh2;
              newbenhnhan.sobh3=ssobh3;
              newbenhnhan.sobh4=ssobh4;
              newbenhnhan.sobh5=ssobh5;
              newbenhnhan.sobh6=ssobh6;
              newbenhnhan.SOTT=sSOTT;
              newbenhnhan.SoTuoi=sSoTuoi;
            return newbenhnhan; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string smabenhnhan
                ,string stenbenhnhan
                ,string sidloaiuutien
                ,string sdiachi
                ,string sdienthoai
                ,string sgioitinh
                ,string sngaysinh
                ,string schungminhthu
                ,string sloai
                ,string stiensubenhnhan
                ,string stinhtrangbandau
                ,string ssobhyt
                ,string sngaybatdau
                ,string sngayhethan
                ,string sthongtinbaotin
                ,string stencongty
                ,string sthongtincongty
                ,string sidloaibh
                ,string snghenghiep
                ,string snoicongtac
                ,string snoigioithieu
                ,string snoidangkykcb
                ,string schandoansobo
                ,string sngaytiepnhan
                ,string sDungTuyen
                ,string semail
                ,string sNguoiLH
                ,string sDiaChiLH
                ,string sDienThoaiLH
                ,string stenDN
                ,string smatKhau
                ,string snoicapbhyt
                ,string sMaDangKy_KCB_bandau
                ,string sNameNotSign
                ,string stinhid
                ,string squanhuyenid
                ,string sphuongxaid
                ,string ssonha
                ,string sidNoiGioiThieu
                ,string sSoThang
                ,string squoctich
                ,string sdantoc
                ,string sMucHuongBH
                ,string sisgiaychuyen
                ,string sIsCapCuu
                ,string sIsDungTuyen
                ,string ssobh1
                ,string ssobh2
                ,string ssobh3
                ,string ssobh4
                ,string ssobh5
                ,string ssobh6
                ,string sSOTT
                ,string sSoTuoi
                ) 
 { 
              string tem_smabenhnhan=DataAcess.hsSqlTool.sGetSaveValue(smabenhnhan,"varchar");
              string tem_stenbenhnhan=DataAcess.hsSqlTool.sGetSaveValue(stenbenhnhan,"nvarchar");
              string tem_sidloaiuutien=DataAcess.hsSqlTool.sGetSaveValue(sidloaiuutien,"bigint");
              string tem_sdiachi=DataAcess.hsSqlTool.sGetSaveValue(sdiachi,"nvarchar");
              string tem_sdienthoai=DataAcess.hsSqlTool.sGetSaveValue(sdienthoai,"varchar");
              string tem_sgioitinh=DataAcess.hsSqlTool.sGetSaveValue(sgioitinh,"tinyint");
              string tem_sngaysinh=DataAcess.hsSqlTool.sGetSaveValue(sngaysinh,"nvarchar");
              string tem_schungminhthu=DataAcess.hsSqlTool.sGetSaveValue(schungminhthu,"varchar");
              string tem_sloai=DataAcess.hsSqlTool.sGetSaveValue(sloai,"bigint");
              string tem_stiensubenhnhan=DataAcess.hsSqlTool.sGetSaveValue(stiensubenhnhan,"nvarchar");
              string tem_stinhtrangbandau=DataAcess.hsSqlTool.sGetSaveValue(stinhtrangbandau,"nvarchar");
              string tem_ssobhyt=DataAcess.hsSqlTool.sGetSaveValue(ssobhyt,"varchar");
              string tem_sngaybatdau=DataAcess.hsSqlTool.sGetSaveValue(sngaybatdau,"datetime");
              string tem_sngayhethan=DataAcess.hsSqlTool.sGetSaveValue(sngayhethan,"datetime");
              string tem_sthongtinbaotin=DataAcess.hsSqlTool.sGetSaveValue(sthongtinbaotin,"nvarchar");
              string tem_stencongty=DataAcess.hsSqlTool.sGetSaveValue(stencongty,"nvarchar");
              string tem_sthongtincongty=DataAcess.hsSqlTool.sGetSaveValue(sthongtincongty,"nvarchar");
              string tem_sidloaibh=DataAcess.hsSqlTool.sGetSaveValue(sidloaibh,"smallint");
              string tem_snghenghiep=DataAcess.hsSqlTool.sGetSaveValue(snghenghiep,"nvarchar");
              string tem_snoicongtac=DataAcess.hsSqlTool.sGetSaveValue(snoicongtac,"nvarchar");
              string tem_snoigioithieu=DataAcess.hsSqlTool.sGetSaveValue(snoigioithieu,"nvarchar");
              string tem_snoidangkykcb=DataAcess.hsSqlTool.sGetSaveValue(snoidangkykcb,"nvarchar");
              string tem_schandoansobo=DataAcess.hsSqlTool.sGetSaveValue(schandoansobo,"nvarchar");
              string tem_sngaytiepnhan=DataAcess.hsSqlTool.sGetSaveValue(sngaytiepnhan,"datetime");
              string tem_sDungTuyen=DataAcess.hsSqlTool.sGetSaveValue(sDungTuyen,"nvarchar");
              string tem_semail=DataAcess.hsSqlTool.sGetSaveValue(semail,"nvarchar");
              string tem_sNguoiLH=DataAcess.hsSqlTool.sGetSaveValue(sNguoiLH,"nvarchar");
              string tem_sDiaChiLH=DataAcess.hsSqlTool.sGetSaveValue(sDiaChiLH,"nvarchar");
              string tem_sDienThoaiLH=DataAcess.hsSqlTool.sGetSaveValue(sDienThoaiLH,"nvarchar");
              string tem_stenDN=DataAcess.hsSqlTool.sGetSaveValue(stenDN,"nvarchar");
              string tem_smatKhau=DataAcess.hsSqlTool.sGetSaveValue(smatKhau,"nvarchar");
              string tem_snoicapbhyt=DataAcess.hsSqlTool.sGetSaveValue(snoicapbhyt,"nvarchar");
              string tem_sMaDangKy_KCB_bandau=DataAcess.hsSqlTool.sGetSaveValue(sMaDangKy_KCB_bandau,"nchar");
              string tem_sNameNotSign=DataAcess.hsSqlTool.sGetSaveValue(sNameNotSign,"nvarchar");
              string tem_stinhid=DataAcess.hsSqlTool.sGetSaveValue(stinhid,"int");
              string tem_squanhuyenid=DataAcess.hsSqlTool.sGetSaveValue(squanhuyenid,"int");
              string tem_sphuongxaid=DataAcess.hsSqlTool.sGetSaveValue(sphuongxaid,"int");
              string tem_ssonha=DataAcess.hsSqlTool.sGetSaveValue(ssonha,"nvarchar");
              string tem_sidNoiGioiThieu=DataAcess.hsSqlTool.sGetSaveValue(sidNoiGioiThieu,"int");
              string tem_sSoThang=DataAcess.hsSqlTool.sGetSaveValue(sSoThang,"int");
              string tem_squoctich=DataAcess.hsSqlTool.sGetSaveValue(squoctich,"nvarchar");
              string tem_sdantoc=DataAcess.hsSqlTool.sGetSaveValue(sdantoc,"nvarchar");
              string tem_sMucHuongBH=DataAcess.hsSqlTool.sGetSaveValue(sMucHuongBH,"int");
              string tem_sisgiaychuyen=DataAcess.hsSqlTool.sGetSaveValue(sisgiaychuyen,"bit");
              string tem_sIsCapCuu=DataAcess.hsSqlTool.sGetSaveValue(sIsCapCuu,"bit");
              string tem_sIsDungTuyen=DataAcess.hsSqlTool.sGetSaveValue(sIsDungTuyen,"bit");
              string tem_ssobh1=DataAcess.hsSqlTool.sGetSaveValue(ssobh1,"char");
              string tem_ssobh2=DataAcess.hsSqlTool.sGetSaveValue(ssobh2,"char");
              string tem_ssobh3=DataAcess.hsSqlTool.sGetSaveValue(ssobh3,"char");
              string tem_ssobh4=DataAcess.hsSqlTool.sGetSaveValue(ssobh4,"char");
              string tem_ssobh5=DataAcess.hsSqlTool.sGetSaveValue(ssobh5,"char");
              string tem_ssobh6=DataAcess.hsSqlTool.sGetSaveValue(ssobh6,"char");
              string tem_sSOTT=DataAcess.hsSqlTool.sGetSaveValue(sSOTT,"bigint");
              string tem_sSoTuoi=DataAcess.hsSqlTool.sGetSaveValue(sSoTuoi,"int");

 string sqlSave=" UPDATE benhnhan SET "+"mabenhnhan ="+tem_smabenhnhan+","
 +"tenbenhnhan ="+tem_stenbenhnhan+","
 +"idloaiuutien ="+tem_sidloaiuutien+","
 +"diachi ="+tem_sdiachi+","
 +"dienthoai ="+tem_sdienthoai+","
 +"gioitinh ="+tem_sgioitinh+","
 +"ngaysinh ="+tem_sngaysinh+","
 +"chungminhthu ="+tem_schungminhthu+","
 +"loai ="+tem_sloai+","
 +"tiensubenhnhan ="+tem_stiensubenhnhan+","
 +"tinhtrangbandau ="+tem_stinhtrangbandau+","
 +"sobhyt ="+tem_ssobhyt+","
 +"ngaybatdau ="+tem_sngaybatdau+","
 +"ngayhethan ="+tem_sngayhethan+","
 +"thongtinbaotin ="+tem_sthongtinbaotin+","
 +"tencongty ="+tem_stencongty+","
 +"thongtincongty ="+tem_sthongtincongty+","
 +"idloaibh ="+tem_sidloaibh+","
 +"nghenghiep ="+tem_snghenghiep+","
 +"noicongtac ="+tem_snoicongtac+","
 +"noigioithieu ="+tem_snoigioithieu+","
 +"noidangkykcb ="+tem_snoidangkykcb+","
 +"chandoansobo ="+tem_schandoansobo+","
 +"ngaytiepnhan ="+tem_sngaytiepnhan+","
 +"DungTuyen ="+tem_sDungTuyen+","
 +"email ="+tem_semail+","
 +"NguoiLH ="+tem_sNguoiLH+","
 +"DiaChiLH ="+tem_sDiaChiLH+","
 +"DienThoaiLH ="+tem_sDienThoaiLH+","
 +"tenDN ="+tem_stenDN+","
 +"matKhau ="+tem_smatKhau+","
 +"noicapbhyt ="+tem_snoicapbhyt+","
 +"MaDangKy_KCB_bandau ="+tem_sMaDangKy_KCB_bandau+","
 +"NameNotSign ="+tem_sNameNotSign+","
 +"tinhid ="+tem_stinhid+","
 +"quanhuyenid ="+tem_squanhuyenid+","
 +"phuongxaid ="+tem_sphuongxaid+","
 +"sonha ="+tem_ssonha+","
 +"idNoiGioiThieu ="+tem_sidNoiGioiThieu+","
 +"SoThang ="+tem_sSoThang+","
 +"quoctich ="+tem_squoctich+","
 +"dantoc ="+tem_sdantoc+","
 +"MucHuongBH ="+tem_sMucHuongBH+","
 +"isgiaychuyen ="+tem_sisgiaychuyen+","
 +"IsCapCuu ="+tem_sIsCapCuu+","
 +"IsDungTuyen ="+tem_sIsDungTuyen+","
 +"sobh1 ="+tem_ssobh1+","
 +"sobh2 ="+tem_ssobh2+","
 +"sobh3 ="+tem_ssobh3+","
 +"sobh4 ="+tem_ssobh4+","
 +"sobh5 ="+tem_ssobh5+","
 +"sobh6 ="+tem_ssobh6+","
 +"SOTT ="+tem_sSOTT+","
 +"SoTuoi ="+tem_sSoTuoi+" WHERE idbenhnhan="+DataAcess.hsSqlTool.sGetSaveValue(this.idbenhnhan,"int identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.mabenhnhan=smabenhnhan;
                this.tenbenhnhan=stenbenhnhan;
                this.idloaiuutien=sidloaiuutien;
                this.diachi=sdiachi;
                this.dienthoai=sdienthoai;
                this.gioitinh=sgioitinh;
                this.ngaysinh=sngaysinh;
                this.chungminhthu=schungminhthu;
                this.loai=sloai;
                this.tiensubenhnhan=stiensubenhnhan;
                this.tinhtrangbandau=stinhtrangbandau;
                this.sobhyt=ssobhyt;
                this.ngaybatdau=sngaybatdau;
                this.ngayhethan=sngayhethan;
                this.thongtinbaotin=sthongtinbaotin;
                this.tencongty=stencongty;
                this.thongtincongty=sthongtincongty;
                this.idloaibh=sidloaibh;
                this.nghenghiep=snghenghiep;
                this.noicongtac=snoicongtac;
                this.noigioithieu=snoigioithieu;
                this.noidangkykcb=snoidangkykcb;
                this.chandoansobo=schandoansobo;
                this.ngaytiepnhan=sngaytiepnhan;
                this.DungTuyen=sDungTuyen;
                this.email=semail;
                this.NguoiLH=sNguoiLH;
                this.DiaChiLH=sDiaChiLH;
                this.DienThoaiLH=sDienThoaiLH;
                this.tenDN=stenDN;
                this.matKhau=smatKhau;
                this.noicapbhyt=snoicapbhyt;
                this.MaDangKy_KCB_bandau=sMaDangKy_KCB_bandau;
                this.NameNotSign=sNameNotSign;
                this.tinhid=stinhid;
                this.quanhuyenid=squanhuyenid;
                this.phuongxaid=sphuongxaid;
                this.sonha=ssonha;
                this.idNoiGioiThieu=sidNoiGioiThieu;
                this.SoThang=sSoThang;
                this.quoctich=squoctich;
                this.dantoc=sdantoc;
                this.MucHuongBH=sMucHuongBH;
                this.isgiaychuyen=sisgiaychuyen;
                this.IsCapCuu=sIsCapCuu;
                this.IsDungTuyen=sIsDungTuyen;
                this.sobh1=ssobh1;
                this.sobh2=ssobh2;
                this.sobh3=ssobh3;
                this.sobh4=ssobh4;
                this.sobh5=ssobh5;
                this.sobh6=ssobh6;
                this.SOTT=sSOTT;
                this.SoTuoi=sSoTuoi;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_idbenhnhan(string sidbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET idbenhnhan='"+ sidbenhnhan+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idbenhnhan=sidbenhnhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_mabenhnhan(string smabenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET mabenhnhan=N'"+ smabenhnhan+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.mabenhnhan=smabenhnhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tenbenhnhan(string stenbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET tenbenhnhan=N'"+ stenbenhnhan+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tenbenhnhan=stenbenhnhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idloaiuutien(string sidloaiuutien)
{
    string sqlSave= " UPDATE benhnhan SET idloaiuutien='"+ sidloaiuutien+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idloaiuutien=sidloaiuutien;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_diachi(string sdiachi)
{
    string sqlSave= " UPDATE benhnhan SET diachi=N'"+ sdiachi+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.diachi=sdiachi;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_dienthoai(string sdienthoai)
{
    string sqlSave= " UPDATE benhnhan SET dienthoai=N'"+ sdienthoai+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dienthoai=sdienthoai;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_gioitinh(string sgioitinh)
{
    string sqlSave= " UPDATE benhnhan SET gioitinh='"+ sgioitinh+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.gioitinh=sgioitinh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ngaysinh(string sngaysinh)
{
    string sqlSave= " UPDATE benhnhan SET ngaysinh=N'"+ sngaysinh+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ngaysinh=sngaysinh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_chungminhthu(string schungminhthu)
{
    string sqlSave= " UPDATE benhnhan SET chungminhthu=N'"+ schungminhthu+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.chungminhthu=schungminhthu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_loai(string sloai)
{
    string sqlSave= " UPDATE benhnhan SET loai='"+ sloai+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.loai=sloai;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tiensubenhnhan(string stiensubenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET tiensubenhnhan=N'"+ stiensubenhnhan+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tiensubenhnhan=stiensubenhnhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tinhtrangbandau(string stinhtrangbandau)
{
    string sqlSave= " UPDATE benhnhan SET tinhtrangbandau=N'"+ stinhtrangbandau+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tinhtrangbandau=stinhtrangbandau;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_sobhyt(string ssobhyt)
{
    string sqlSave= " UPDATE benhnhan SET sobhyt=N'"+ ssobhyt+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.sobhyt=ssobhyt;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ngaybatdau(string sngaybatdau)
{
    string sqlSave= " UPDATE benhnhan SET ngaybatdau='"+ sngaybatdau+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ngaybatdau=sngaybatdau;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ngayhethan(string sngayhethan)
{
    string sqlSave= " UPDATE benhnhan SET ngayhethan='"+ sngayhethan+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ngayhethan=sngayhethan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_thongtinbaotin(string sthongtinbaotin)
{
    string sqlSave= " UPDATE benhnhan SET thongtinbaotin=N'"+ sthongtinbaotin+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.thongtinbaotin=sthongtinbaotin;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tencongty(string stencongty)
{
    string sqlSave= " UPDATE benhnhan SET tencongty=N'"+ stencongty+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tencongty=stencongty;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_thongtincongty(string sthongtincongty)
{
    string sqlSave= " UPDATE benhnhan SET thongtincongty=N'"+ sthongtincongty+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.thongtincongty=sthongtincongty;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idloaibh(string sidloaibh)
{
    string sqlSave= " UPDATE benhnhan SET idloaibh='"+ sidloaibh+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idloaibh=sidloaibh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_nghenghiep(string snghenghiep)
{
    string sqlSave= " UPDATE benhnhan SET nghenghiep=N'"+ snghenghiep+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.nghenghiep=snghenghiep;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_noicongtac(string snoicongtac)
{
    string sqlSave= " UPDATE benhnhan SET noicongtac=N'"+ snoicongtac+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.noicongtac=snoicongtac;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_noigioithieu(string snoigioithieu)
{
    string sqlSave= " UPDATE benhnhan SET noigioithieu=N'"+ snoigioithieu+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.noigioithieu=snoigioithieu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_noidangkykcb(string snoidangkykcb)
{
    string sqlSave= " UPDATE benhnhan SET noidangkykcb=N'"+ snoidangkykcb+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.noidangkykcb=snoidangkykcb;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_chandoansobo(string schandoansobo)
{
    string sqlSave= " UPDATE benhnhan SET chandoansobo=N'"+ schandoansobo+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.chandoansobo=schandoansobo;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ngaytiepnhan(string sngaytiepnhan)
{
    string sqlSave= " UPDATE benhnhan SET ngaytiepnhan='"+ sngaytiepnhan+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ngaytiepnhan=sngaytiepnhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DungTuyen(string sDungTuyen)
{
    string sqlSave= " UPDATE benhnhan SET DungTuyen=N'"+ sDungTuyen+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DungTuyen=sDungTuyen;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_email(string semail)
{
    string sqlSave= " UPDATE benhnhan SET email=N'"+ semail+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.email=semail;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NguoiLH(string sNguoiLH)
{
    string sqlSave= " UPDATE benhnhan SET NguoiLH=N'"+ sNguoiLH+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NguoiLH=sNguoiLH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DiaChiLH(string sDiaChiLH)
{
    string sqlSave= " UPDATE benhnhan SET DiaChiLH=N'"+ sDiaChiLH+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DiaChiLH=sDiaChiLH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DienThoaiLH(string sDienThoaiLH)
{
    string sqlSave= " UPDATE benhnhan SET DienThoaiLH=N'"+ sDienThoaiLH+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.DienThoaiLH=sDienThoaiLH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tenDN(string stenDN)
{
    string sqlSave= " UPDATE benhnhan SET tenDN=N'"+ stenDN+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tenDN=stenDN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_matKhau(string smatKhau)
{
    string sqlSave= " UPDATE benhnhan SET matKhau=N'"+ smatKhau+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.matKhau=smatKhau;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_noicapbhyt(string snoicapbhyt)
{
    string sqlSave= " UPDATE benhnhan SET noicapbhyt=N'"+ snoicapbhyt+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.noicapbhyt=snoicapbhyt;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MaDangKy_KCB_bandau(string sMaDangKy_KCB_bandau)
{
    string sqlSave= " UPDATE benhnhan SET MaDangKy_KCB_bandau=N'"+ sMaDangKy_KCB_bandau+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MaDangKy_KCB_bandau=sMaDangKy_KCB_bandau;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NameNotSign(string sNameNotSign)
{
    string sqlSave= " UPDATE benhnhan SET NameNotSign=N'"+ sNameNotSign+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.NameNotSign=sNameNotSign;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tinhid(string stinhid)
{
    string sqlSave= " UPDATE benhnhan SET tinhid='"+ stinhid+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tinhid=stinhid;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_quanhuyenid(string squanhuyenid)
{
    string sqlSave= " UPDATE benhnhan SET quanhuyenid='"+ squanhuyenid+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.quanhuyenid=squanhuyenid;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_phuongxaid(string sphuongxaid)
{
    string sqlSave= " UPDATE benhnhan SET phuongxaid='"+ sphuongxaid+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.phuongxaid=sphuongxaid;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_sonha(string ssonha)
{
    string sqlSave= " UPDATE benhnhan SET sonha=N'"+ ssonha+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.sonha=ssonha;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_idNoiGioiThieu(string sidNoiGioiThieu)
{
    string sqlSave= " UPDATE benhnhan SET idNoiGioiThieu='"+ sidNoiGioiThieu+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idNoiGioiThieu=sidNoiGioiThieu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SoThang(string sSoThang)
{
    string sqlSave= " UPDATE benhnhan SET SoThang='"+ sSoThang+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SoThang=sSoThang;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_quoctich(string squoctich)
{
    string sqlSave= " UPDATE benhnhan SET quoctich=N'"+ squoctich+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.quoctich=squoctich;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_dantoc(string sdantoc)
{
    string sqlSave= " UPDATE benhnhan SET dantoc=N'"+ sdantoc+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dantoc=sdantoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MucHuongBH(string sMucHuongBH)
{
    string sqlSave= " UPDATE benhnhan SET MucHuongBH='"+ sMucHuongBH+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.MucHuongBH=sMucHuongBH;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_isgiaychuyen(string sisgiaychuyen)
{
    string sqlSave= " UPDATE benhnhan SET isgiaychuyen='"+ sisgiaychuyen+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.isgiaychuyen=sisgiaychuyen;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsCapCuu(string sIsCapCuu)
{
    string sqlSave= " UPDATE benhnhan SET IsCapCuu='"+ sIsCapCuu+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IsCapCuu=sIsCapCuu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsDungTuyen(string sIsDungTuyen)
{
    string sqlSave= " UPDATE benhnhan SET IsDungTuyen='"+ sIsDungTuyen+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IsDungTuyen=sIsDungTuyen;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_sobh1(string ssobh1)
{
    string sqlSave= " UPDATE benhnhan SET sobh1=N'"+ ssobh1+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.sobh1=ssobh1;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_sobh2(string ssobh2)
{
    string sqlSave= " UPDATE benhnhan SET sobh2=N'"+ ssobh2+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.sobh2=ssobh2;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_sobh3(string ssobh3)
{
    string sqlSave= " UPDATE benhnhan SET sobh3=N'"+ ssobh3+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.sobh3=ssobh3;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_sobh4(string ssobh4)
{
    string sqlSave= " UPDATE benhnhan SET sobh4=N'"+ ssobh4+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.sobh4=ssobh4;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_sobh5(string ssobh5)
{
    string sqlSave= " UPDATE benhnhan SET sobh5=N'"+ ssobh5+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.sobh5=ssobh5;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_sobh6(string ssobh6)
{
    string sqlSave= " UPDATE benhnhan SET sobh6=N'"+ ssobh6+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.sobh6=ssobh6;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SOTT(string sSOTT)
{
    string sqlSave= " UPDATE benhnhan SET SOTT='"+ sSOTT+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SOTT=sSOTT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SoTuoi(string sSoTuoi)
{
    string sqlSave= " UPDATE benhnhan SET SoTuoi='"+ sSoTuoi+ "' WHERE idbenhnhan='"+ this.idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.SoTuoi=sSoTuoi;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_mabenhnhan(string smabenhnhan,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET mabenhnhan='N"+smabenhnhan+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tenbenhnhan(string stenbenhnhan,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET tenbenhnhan='N"+stenbenhnhan+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idloaiuutien(string sidloaiuutien,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET idloaiuutien='"+sidloaiuutien+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_diachi(string sdiachi,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET diachi='N"+sdiachi+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dienthoai(string sdienthoai,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET dienthoai='N"+sdienthoai+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_gioitinh(string sgioitinh,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET gioitinh='"+sgioitinh+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ngaysinh(string sngaysinh,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET ngaysinh='N"+sngaysinh+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_chungminhthu(string schungminhthu,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET chungminhthu='N"+schungminhthu+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_loai(string sloai,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET loai='"+sloai+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tiensubenhnhan(string stiensubenhnhan,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET tiensubenhnhan='N"+stiensubenhnhan+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tinhtrangbandau(string stinhtrangbandau,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET tinhtrangbandau='N"+stinhtrangbandau+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_sobhyt(string ssobhyt,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET sobhyt='N"+ssobhyt+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ngaybatdau(string sngaybatdau,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET ngaybatdau='"+sngaybatdau+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ngayhethan(string sngayhethan,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET ngayhethan='"+sngayhethan+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_thongtinbaotin(string sthongtinbaotin,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET thongtinbaotin='N"+sthongtinbaotin+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tencongty(string stencongty,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET tencongty='N"+stencongty+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_thongtincongty(string sthongtincongty,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET thongtincongty='N"+sthongtincongty+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idloaibh(string sidloaibh,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET idloaibh='"+sidloaibh+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_nghenghiep(string snghenghiep,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET nghenghiep='N"+snghenghiep+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_noicongtac(string snoicongtac,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET noicongtac='N"+snoicongtac+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_noigioithieu(string snoigioithieu,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET noigioithieu='N"+snoigioithieu+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_noidangkykcb(string snoidangkykcb,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET noidangkykcb='N"+snoidangkykcb+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_chandoansobo(string schandoansobo,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET chandoansobo='N"+schandoansobo+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ngaytiepnhan(string sngaytiepnhan,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET ngaytiepnhan='"+sngaytiepnhan+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DungTuyen(string sDungTuyen,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET DungTuyen='N"+sDungTuyen+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_email(string semail,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET email='N"+semail+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NguoiLH(string sNguoiLH,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET NguoiLH='N"+sNguoiLH+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DiaChiLH(string sDiaChiLH,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET DiaChiLH='N"+sDiaChiLH+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DienThoaiLH(string sDienThoaiLH,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET DienThoaiLH='N"+sDienThoaiLH+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tenDN(string stenDN,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET tenDN='N"+stenDN+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_matKhau(string smatKhau,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET matKhau='N"+smatKhau+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_noicapbhyt(string snoicapbhyt,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET noicapbhyt='N"+snoicapbhyt+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MaDangKy_KCB_bandau(string sMaDangKy_KCB_bandau,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET MaDangKy_KCB_bandau='N"+sMaDangKy_KCB_bandau+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NameNotSign(string sNameNotSign,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET NameNotSign='N"+sNameNotSign+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tinhid(string stinhid,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET tinhid='"+stinhid+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_quanhuyenid(string squanhuyenid,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET quanhuyenid='"+squanhuyenid+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_phuongxaid(string sphuongxaid,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET phuongxaid='"+sphuongxaid+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_sonha(string ssonha,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET sonha='N"+ssonha+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_idNoiGioiThieu(string sidNoiGioiThieu,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET idNoiGioiThieu='"+sidNoiGioiThieu+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SoThang(string sSoThang,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET SoThang='"+sSoThang+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_quoctich(string squoctich,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET quoctich='N"+squoctich+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dantoc(string sdantoc,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET dantoc='N"+sdantoc+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MucHuongBH(string sMucHuongBH,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET MucHuongBH='"+sMucHuongBH+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_isgiaychuyen(string sisgiaychuyen,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET isgiaychuyen='"+sisgiaychuyen+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsCapCuu(string sIsCapCuu,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET IsCapCuu='"+sIsCapCuu+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsDungTuyen(string sIsDungTuyen,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET IsDungTuyen='"+sIsDungTuyen+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_sobh1(string ssobh1,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET sobh1='N"+ssobh1+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_sobh2(string ssobh2,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET sobh2='N"+ssobh2+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_sobh3(string ssobh3,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET sobh3='N"+ssobh3+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_sobh4(string ssobh4,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET sobh4='N"+ssobh4+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_sobh5(string ssobh5,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET sobh5='N"+ssobh5+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_sobh6(string ssobh6,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET sobh6='N"+ssobh6+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SOTT(string sSOTT,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET SOTT='"+sSOTT+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SoTuoi(string sSoTuoi,string s_idbenhnhan)
{
    string sqlSave= " UPDATE benhnhan SET SoTuoi='"+sSoTuoi+"' WHERE idbenhnhan='"+ s_idbenhnhan+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM benhnhan " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_benhnhan;
   public static bool Change_dt_benhnhan = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_benhnhan()
   {
   if (dt_benhnhan == null || Change_dt_benhnhan == true)
   {
   dt_benhnhan = dtGetAll();
   Change_dt_benhnhan = true && AllowAutoChange ;
   }
   return dt_benhnhan;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace Process
  {
     public class phieuxuatkho_duoc : Connect
     { 
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
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public phieuxuatkho_duoc() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public phieuxuatkho_duoc(
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
         string sIsBHYT){
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
}
//───────────────────────────────────────────────────────────────────────────────────────
         public static phieuxuatkho_duoc Create_phieuxuatkho(string sidphieuxuat)
         {
    DataTable dt=dtSearchByidphieuxuat(sidphieuxuat) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new phieuxuatkho_duoc(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM phieuxuatkho AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public phieuxuatkho_duoc( DataView dv,int pos)
{
         this.idphieuxuat= dv[pos]["idphieuxuat"].ToString();
         this.maphieuxuat= dv[pos]["maphieuxuat"].ToString();
         this.ngaythang= dv[pos]["ngaythang"].ToString();
         this.ghichu= dv[pos]["ghichu"].ToString();
         this.idphongkhambenh= dv[pos]["idphongkhambenh"].ToString();
         this.nguoinhan= dv[pos]["nguoinhan"].ToString();
         this.xuatcho= dv[pos]["xuatcho"].ToString();
         this.idkho= dv[pos]["idkho"].ToString();
         this.loaixuat= dv[pos]["loaixuat"].ToString();
         this.IDKhachHang= dv[pos]["IDKhachHang"].ToString();
         this.vat= dv[pos]["vat"].ToString();
         this.thanhtien= dv[pos]["thanhtien"].ToString();
         this.ngayhoadon= dv[pos]["ngayhoadon"].ToString();
         this.idnhacungcap= dv[pos]["idnhacungcap"].ToString();
         this.idkho2= dv[pos]["idkho2"].ToString();
         this.idnguoixuat= dv[pos]["idnguoixuat"].ToString();
         this.IdBenhNhanToaThuoc= dv[pos]["IdBenhNhanToaThuoc"].ToString();
         this.IsBHYT= dv[pos]["IsBHYT"].ToString();
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
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
         public static phieuxuatkho_duoc Insert_Object(
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
            ) 
 { 
              string tem_smaphieuxuat=DataAcess.hsSqlTool.sGetSaveValue(smaphieuxuat,"varchar");
              string tem_sngaythang=DataAcess.hsSqlTool.sGetSaveValue(sngaythang,"smalldatetime");
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
        +                   "IsBHYT) VALUES("
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
 +tem_sIsBHYT +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           {
               phieuxuatkho_duoc newphieuxuatkho = new phieuxuatkho_duoc();
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
            return newphieuxuatkho; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
         public static phieuxuatkho_duoc Insert_Object2(
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
     , string STT
       )
{
    string tem_smaphieuxuat = DataAcess.hsSqlTool.sGetSaveValue(smaphieuxuat, "varchar");
    string tem_sngaythang = DataAcess.hsSqlTool.sGetSaveValue(sngaythang, "smalldatetime");
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
    string tem_STT= DataAcess.hsSqlTool.sGetSaveValue(STT, "int");


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
+ "IsBHYT,SLPX) VALUES("
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
+ tem_sIsBHYT + ","+tem_STT +")";
    bool OK = Exec(sqlSave) >= 1 ? true : false;
    if (OK)
    {
        phieuxuatkho_duoc newphieuxuatkho = new phieuxuatkho_duoc();
        newphieuxuatkho.idphieuxuat = GetTable(" SELECT TOP 1 idphieuxuat FROM phieuxuatkho ORDER BY idphieuxuat DESC ").Rows[0][0].ToString();
        newphieuxuatkho.maphieuxuat = smaphieuxuat;
        newphieuxuatkho.ngaythang = sngaythang;
        newphieuxuatkho.ghichu = sghichu;
        newphieuxuatkho.idphongkhambenh = sidphongkhambenh;
        newphieuxuatkho.nguoinhan = snguoinhan;
        newphieuxuatkho.xuatcho = sxuatcho;
        newphieuxuatkho.idkho = sidkho;
        newphieuxuatkho.loaixuat = sloaixuat;
        newphieuxuatkho.IDKhachHang = sIDKhachHang;
        newphieuxuatkho.vat = svat;
        newphieuxuatkho.thanhtien = sthanhtien;
        newphieuxuatkho.ngayhoadon = sngayhoadon;
        newphieuxuatkho.idnhacungcap = sidnhacungcap;
        newphieuxuatkho.idkho2 = sidkho2;
        newphieuxuatkho.idnguoixuat = sidnguoixuat;
        newphieuxuatkho.IdBenhNhanToaThuoc = sIdBenhNhanToaThuoc;
        newphieuxuatkho.IsBHYT = sIsBHYT;
        return newphieuxuatkho;
    }
    else return null;
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
                ) 
 { 
              string tem_smaphieuxuat=DataAcess.hsSqlTool.sGetSaveValue(smaphieuxuat,"varchar");
              string tem_sngaythang=DataAcess.hsSqlTool.sGetSaveValue(sngaythang,"smalldatetime");
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
 +"IsBHYT ="+tem_sIsBHYT+" WHERE idphieuxuat="+DataAcess.hsSqlTool.sGetSaveValue(this.idphieuxuat,"int identity");;
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
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

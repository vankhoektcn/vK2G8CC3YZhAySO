using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process_2608
  { 
 public class HS_TOATHUOC_View:  Connect { 
 public static string sTableName= "HS_TOATHUOC_View"; 
   public string IdToaThuoc;
   public string NgayToa;
   public string IdBenhNhan;
   public string MaBN;
   public string HoTenBN;
   public string NgaySinh;
   public string GioiTinh;
   public string SoBHYT;
   public string DungTuyen;
   public string IsHaveThuoc;
   public string BNTra;
   public string Capthuoc;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_IdToaThuoc="IdToaThuoc" ;
 public static  string cl_IdToaThuoc_VN="IdToaThuoc";
 public static  string cl_NgayToa="NgayToa" ;
 public static  string cl_NgayToa_VN="NgayToa";
 public static  string cl_IdBenhNhan="IdBenhNhan" ;
 public static  string cl_IdBenhNhan_VN="IdBenhNhan";
 public static  string cl_MaBN="MaBN" ;
 public static  string cl_MaBN_VN="MaBN";
 public static  string cl_HoTenBN="HoTenBN" ;
 public static  string cl_HoTenBN_VN="HoTenBN";
 public static  string cl_NgaySinh="NgaySinh" ;
 public static  string cl_NgaySinh_VN="NgaySinh";
 public static  string cl_GioiTinh="GioiTinh" ;
 public static  string cl_GioiTinh_VN="GioiTinh";
 public static  string cl_SoBHYT="SoBHYT" ;
 public static  string cl_SoBHYT_VN="SoBHYT";
 public static  string cl_DungTuyen="DungTuyen" ;
 public static  string cl_DungTuyen_VN="DungTuyen";
 public static  string cl_IsHaveThuoc="IsHaveThuoc" ;
 public static  string cl_IsHaveThuoc_VN="IsHaveThuoc";
 public static  string cl_BNTra="BNTra" ;
 public static  string cl_BNTra_VN="BNTra";
 public static  string cl_Capthuoc="Capthuoc" ;
 public static  string cl_Capthuoc_VN="Capthuoc";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public HS_TOATHUOC_View() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public HS_TOATHUOC_View(
         string sIdToaThuoc,
         string sNgayToa,
         string sIdBenhNhan,
         string sMaBN,
         string sHoTenBN,
         string sNgaySinh,
         string sGioiTinh,
         string sSoBHYT,
         string sDungTuyen,
         string sIsHaveThuoc,
         string sBNTra,
         string sCapthuoc){
         this.IdToaThuoc= sIdToaThuoc;
         this.NgayToa= sNgayToa;
         this.IdBenhNhan= sIdBenhNhan;
         this.MaBN= sMaBN;
         this.HoTenBN= sHoTenBN;
         this.NgaySinh= sNgaySinh;
         this.GioiTinh= sGioiTinh;
         this.SoBHYT= sSoBHYT;
         this.DungTuyen= sDungTuyen;
         this.IsHaveThuoc= sIsHaveThuoc;
         this.BNTra= sBNTra;
         this.Capthuoc= sCapthuoc;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static HS_TOATHUOC_View Create_HS_TOATHUOC_View ( string sIdToaThuoc  ){
    DataTable dt=dtSearchByIdToaThuoc(sIdToaThuoc) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new HS_TOATHUOC_View(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM HS_TOATHUOC_View AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by IdToaThuoc),T.* FROM HS_TOATHUOC_View AS T WHERE";
      if (this.NgayToa!=null && this.NgayToa!="") 
            sqlselect +=" AND NgayToa LIKE '%" + this.NgayToa +"%'" ;
      if (this.IdBenhNhan!=null && this.IdBenhNhan!="" && this.IdBenhNhan!="0" && this.IdBenhNhan!="0.0") 
            sqlselect +=" AND IdBenhNhan =" + this.IdBenhNhan ;
      if (this.MaBN!=null && this.MaBN!="") 
            sqlselect +=" AND MaBN LIKE N'%" + this.MaBN +"%'" ;
      if (this.HoTenBN!=null && this.HoTenBN!="") 
            sqlselect +=" AND HoTenBN LIKE N'%" + this.HoTenBN +"%'" ;
      if (this.NgaySinh!=null && this.NgaySinh!="") 
            sqlselect +=" AND NgaySinh LIKE '%" + this.NgaySinh +"%'" ;
      if (this.GioiTinh!=null && this.GioiTinh!="") 
            sqlselect +=" AND GioiTinh LIKE N'%" + this.GioiTinh +"%'" ;
      if (this.SoBHYT!=null && this.SoBHYT!="") 
            sqlselect +=" AND SoBHYT LIKE N'%" + this.SoBHYT +"%'" ;
      if (this.DungTuyen!=null && this.DungTuyen!="") 
            sqlselect +=" AND DungTuyen ='" + this.DungTuyen+"'" ;
      if (this.IsHaveThuoc!=null && this.IsHaveThuoc!="") 
            sqlselect +=" AND IsHaveThuoc ='" + this.IsHaveThuoc+"'" ;
      if (this.BNTra!=null && this.BNTra!="" && this.BNTra!="0" && this.BNTra!="0.0") 
            sqlselect +=" AND BNTra =" + this.BNTra ;
      if (this.Capthuoc!=null && this.Capthuoc!="") 
            sqlselect +=" AND Capthuoc LIKE N'%" + this.Capthuoc +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public HS_TOATHUOC_View( DataView dv,int pos)
{
         this.IdToaThuoc= dv[pos][0].ToString();
         this.NgayToa= dv[pos][1].ToString();
         this.IdBenhNhan= dv[pos][2].ToString();
         this.MaBN= dv[pos][3].ToString();
         this.HoTenBN= dv[pos][4].ToString();
         this.NgaySinh= dv[pos][5].ToString();
         this.GioiTinh= dv[pos][6].ToString();
         this.SoBHYT= dv[pos][7].ToString();
         this.DungTuyen= dv[pos][8].ToString();
         this.IsHaveThuoc= dv[pos][9].ToString();
         this.BNTra= dv[pos][10].ToString();
         this.Capthuoc= dv[pos][11].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdToaThuoc(string sIdToaThuoc)
{
          string sqlSelect= s_Select()+ " WHERE IdToaThuoc  ="+ sIdToaThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdToaThuoc(string sIdToaThuoc,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdToaThuoc"+ sMatch +sIdToaThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayToa(string sNgayToa)
{
          string sqlSelect= s_Select()+ " WHERE NgayToa  ="+ sNgayToa + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgayToa(string sNgayToa,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NgayToa"+ sMatch +sNgayToa + ""; 
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
 public static DataTable dtSearchByMaBN(string sMaBN)
{
          string sqlSelect= s_Select()+ " WHERE MaBN  Like N'%"+ sMaBN + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByHoTenBN(string sHoTenBN)
{
          string sqlSelect= s_Select()+ " WHERE HoTenBN  Like N'%"+ sHoTenBN + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgaySinh(string sNgaySinh)
{
          string sqlSelect= s_Select()+ " WHERE NgaySinh  ="+ sNgaySinh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNgaySinh(string sNgaySinh,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NgaySinh"+ sMatch +sNgaySinh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByGioiTinh(string sGioiTinh)
{
          string sqlSelect= s_Select()+ " WHERE GioiTinh  Like N'%"+ sGioiTinh + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBySoBHYT(string sSoBHYT)
{
          string sqlSelect= s_Select()+ " WHERE SoBHYT  Like N'%"+ sSoBHYT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDungTuyen(string sDungTuyen)
{
          string sqlSelect= s_Select()+ " WHERE DungTuyen  ="+ sDungTuyen + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDungTuyen(string sDungTuyen,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DungTuyen"+ sMatch +sDungTuyen + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsHaveThuoc(string sIsHaveThuoc)
{
          string sqlSelect= s_Select()+ " WHERE IsHaveThuoc  ="+ sIsHaveThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsHaveThuoc(string sIsHaveThuoc,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IsHaveThuoc"+ sMatch +sIsHaveThuoc + ""; 
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
 public static DataTable dtSearchByCapthuoc(string sCapthuoc)
{
          string sqlSelect= s_Select()+ " WHERE Capthuoc  Like N'%"+ sCapthuoc + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sIdToaThuoc
            , string sNgayToa
            , string sIdBenhNhan
            , string sMaBN
            , string sHoTenBN
            , string sNgaySinh
            , string sGioiTinh
            , string sSoBHYT
            , string sDungTuyen
            , string sIsHaveThuoc
            , string sBNTra
            , string sCapthuoc
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sIdToaThuoc!=null && sIdToaThuoc!="") 
            sqlselect +=" AND IdToaThuoc =" + sIdToaThuoc ;
      if (sNgayToa!=null && sNgayToa!="") 
            sqlselect +=" AND NgayToa LIKE '%" + sNgayToa +"%'" ;
      if (sIdBenhNhan!=null && sIdBenhNhan!="") 
            sqlselect +=" AND IdBenhNhan =" + sIdBenhNhan ;
      if (sMaBN!=null && sMaBN!="") 
            sqlselect +=" AND MaBN LIKE N'%" + sMaBN +"%'" ;
      if (sHoTenBN!=null && sHoTenBN!="") 
            sqlselect +=" AND HoTenBN LIKE N'%" + sHoTenBN +"%'" ;
      if (sNgaySinh!=null && sNgaySinh!="") 
            sqlselect +=" AND NgaySinh LIKE '%" + sNgaySinh +"%'" ;
      if (sGioiTinh!=null && sGioiTinh!="") 
            sqlselect +=" AND GioiTinh LIKE N'%" + sGioiTinh +"%'" ;
      if (sSoBHYT!=null && sSoBHYT!="") 
            sqlselect +=" AND SoBHYT LIKE N'%" + sSoBHYT +"%'" ;
      if (sDungTuyen!=null && sDungTuyen!="") 
            sqlselect +=" AND DungTuyen =" + sDungTuyen ;
      if (sIsHaveThuoc!=null && sIsHaveThuoc!="") 
            sqlselect +=" AND IsHaveThuoc =" + sIsHaveThuoc ;
      if (sBNTra!=null && sBNTra!="") 
            sqlselect +=" AND BNTra =" + sBNTra ;
      if (sCapthuoc!=null && sCapthuoc!="") 
            sqlselect +=" AND Capthuoc LIKE N'%" + sCapthuoc +"%'" ;
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
 public static HS_TOATHUOC_View Insert_Object(
string  sIdToaThuoc
            ,string  sNgayToa
            ,string  sIdBenhNhan
            ,string  sMaBN
            ,string  sHoTenBN
            ,string  sNgaySinh
            ,string  sGioiTinh
            ,string  sSoBHYT
            ,string  sDungTuyen
            ,string  sIsHaveThuoc
            ,string  sBNTra
            ,string  sCapthuoc
            ) 
 { 
              string tem_sIdToaThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIdToaThuoc,"bigint");
              string tem_sNgayToa=DataAcess.hsSqlTool.sGetSaveValue(sNgayToa,"datetime");
              string tem_sIdBenhNhan=DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhan,"bigint");
              string tem_sMaBN=DataAcess.hsSqlTool.sGetSaveValue(sMaBN,"nvarchar");
              string tem_sHoTenBN=DataAcess.hsSqlTool.sGetSaveValue(sHoTenBN,"nvarchar");
              string tem_sNgaySinh=DataAcess.hsSqlTool.sGetSaveValue(sNgaySinh,"datetime");
              string tem_sGioiTinh=DataAcess.hsSqlTool.sGetSaveValue(sGioiTinh,"nvarchar");
              string tem_sSoBHYT=DataAcess.hsSqlTool.sGetSaveValue(sSoBHYT,"nvarchar");
              string tem_sDungTuyen=DataAcess.hsSqlTool.sGetSaveValue(sDungTuyen,"bit");
              string tem_sIsHaveThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIsHaveThuoc,"bit");
              string tem_sBNTra=DataAcess.hsSqlTool.sGetSaveValue(sBNTra,"bigint");
              string tem_sCapthuoc=DataAcess.hsSqlTool.sGetSaveValue(sCapthuoc,"nvarchar");

             string sqlSave=" INSERT INTO HS_TOATHUOC_View("+
                   "IdToaThuoc," 
        +                   "NgayToa," 
        +                   "IdBenhNhan," 
        +                   "MaBN," 
        +                   "HoTenBN," 
        +                   "NgaySinh," 
        +                   "GioiTinh," 
        +                   "SoBHYT," 
        +                   "DungTuyen," 
        +                   "IsHaveThuoc," 
        +                   "BNTra," 
        +                   "Capthuoc) VALUES("
 +tem_sIdToaThuoc+","
 +tem_sNgayToa+","
 +tem_sIdBenhNhan+","
 +tem_sMaBN+","
 +tem_sHoTenBN+","
 +tem_sNgaySinh+","
 +tem_sGioiTinh+","
 +tem_sSoBHYT+","
 +tem_sDungTuyen+","
 +tem_sIsHaveThuoc+","
 +tem_sBNTra+","
 +tem_sCapthuoc +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          HS_TOATHUOC_View newHS_TOATHUOC_View= new HS_TOATHUOC_View();
              newHS_TOATHUOC_View.IdToaThuoc=sIdToaThuoc;
              newHS_TOATHUOC_View.NgayToa=sNgayToa;
              newHS_TOATHUOC_View.IdBenhNhan=sIdBenhNhan;
              newHS_TOATHUOC_View.MaBN=sMaBN;
              newHS_TOATHUOC_View.HoTenBN=sHoTenBN;
              newHS_TOATHUOC_View.NgaySinh=sNgaySinh;
              newHS_TOATHUOC_View.GioiTinh=sGioiTinh;
              newHS_TOATHUOC_View.SoBHYT=sSoBHYT;
              newHS_TOATHUOC_View.DungTuyen=sDungTuyen;
              newHS_TOATHUOC_View.IsHaveThuoc=sIsHaveThuoc;
              newHS_TOATHUOC_View.BNTra=sBNTra;
              newHS_TOATHUOC_View.Capthuoc=sCapthuoc;
            return newHS_TOATHUOC_View; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public HS_TOATHUOC_View Insert_Object() { 
              string tem_sIdToaThuoc=(GetTable( " SELECT IdToaThuoc FROM HS_TOATHUOC_View").Rows.Count + 1)+"";
              string tem_sNgayToa=DataAcess.hsSqlTool.sGetSaveValue(this.NgayToa,"datetime");
              string tem_sIdBenhNhan=DataAcess.hsSqlTool.sGetSaveValue(this.IdBenhNhan,"bigint");
              string tem_sMaBN=DataAcess.hsSqlTool.sGetSaveValue(this.MaBN,"nvarchar");
              string tem_sHoTenBN=DataAcess.hsSqlTool.sGetSaveValue(this.HoTenBN,"nvarchar");
              string tem_sNgaySinh=DataAcess.hsSqlTool.sGetSaveValue(this.NgaySinh,"datetime");
              string tem_sGioiTinh=DataAcess.hsSqlTool.sGetSaveValue(this.GioiTinh,"nvarchar");
              string tem_sSoBHYT=DataAcess.hsSqlTool.sGetSaveValue(this.SoBHYT,"nvarchar");
              string tem_sDungTuyen=DataAcess.hsSqlTool.sGetSaveValue(this.DungTuyen,"bit");
              string tem_sIsHaveThuoc=DataAcess.hsSqlTool.sGetSaveValue(this.IsHaveThuoc,"bit");
              string tem_sBNTra=DataAcess.hsSqlTool.sGetSaveValue(this.BNTra,"bigint");
              string tem_sCapthuoc=DataAcess.hsSqlTool.sGetSaveValue(this.Capthuoc,"nvarchar");

             string sqlSave=" INSERT INTO HS_TOATHUOC_View("+
                   "IdToaThuoc," 
        +                   "NgayToa," 
        +                   "IdBenhNhan," 
        +                   "MaBN," 
        +                   "HoTenBN," 
        +                   "NgaySinh," 
        +                   "GioiTinh," 
        +                   "SoBHYT," 
        +                   "DungTuyen," 
        +                   "IsHaveThuoc," 
        +                   "BNTra," 
        +                   "Capthuoc) VALUES("
 +tem_sIdToaThuoc+","
 +tem_sNgayToa+","
 +tem_sIdBenhNhan+","
 +tem_sMaBN+","
 +tem_sHoTenBN+","
 +tem_sNgaySinh+","
 +tem_sGioiTinh+","
 +tem_sSoBHYT+","
 +tem_sDungTuyen+","
 +tem_sIsHaveThuoc+","
 +tem_sBNTra+","
 +tem_sCapthuoc +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          HS_TOATHUOC_View newHS_TOATHUOC_View= new HS_TOATHUOC_View();
              newHS_TOATHUOC_View.IdToaThuoc=this.IdToaThuoc;
              newHS_TOATHUOC_View.NgayToa=this.NgayToa;
              newHS_TOATHUOC_View.IdBenhNhan=this.IdBenhNhan;
              newHS_TOATHUOC_View.MaBN=this.MaBN;
              newHS_TOATHUOC_View.HoTenBN=this.HoTenBN;
              newHS_TOATHUOC_View.NgaySinh=this.NgaySinh;
              newHS_TOATHUOC_View.GioiTinh=this.GioiTinh;
              newHS_TOATHUOC_View.SoBHYT=this.SoBHYT;
              newHS_TOATHUOC_View.DungTuyen=this.DungTuyen;
              newHS_TOATHUOC_View.IsHaveThuoc=this.IsHaveThuoc;
              newHS_TOATHUOC_View.BNTra=this.BNTra;
              newHS_TOATHUOC_View.Capthuoc=this.Capthuoc;
            return newHS_TOATHUOC_View; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sIdToaThuoc
                ,string sNgayToa
                ,string sIdBenhNhan
                ,string sMaBN
                ,string sHoTenBN
                ,string sNgaySinh
                ,string sGioiTinh
                ,string sSoBHYT
                ,string sDungTuyen
                ,string sIsHaveThuoc
                ,string sBNTra
                ,string sCapthuoc
                ) 
 { 
              string tem_sNgayToa=DataAcess.hsSqlTool.sGetSaveValue(sNgayToa,"datetime");
              string tem_sIdBenhNhan=DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhan,"bigint");
              string tem_sMaBN=DataAcess.hsSqlTool.sGetSaveValue(sMaBN,"nvarchar");
              string tem_sHoTenBN=DataAcess.hsSqlTool.sGetSaveValue(sHoTenBN,"nvarchar");
              string tem_sNgaySinh=DataAcess.hsSqlTool.sGetSaveValue(sNgaySinh,"datetime");
              string tem_sGioiTinh=DataAcess.hsSqlTool.sGetSaveValue(sGioiTinh,"nvarchar");
              string tem_sSoBHYT=DataAcess.hsSqlTool.sGetSaveValue(sSoBHYT,"nvarchar");
              string tem_sDungTuyen=DataAcess.hsSqlTool.sGetSaveValue(sDungTuyen,"bit");
              string tem_sIsHaveThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIsHaveThuoc,"bit");
              string tem_sBNTra=DataAcess.hsSqlTool.sGetSaveValue(sBNTra,"bigint");
              string tem_sCapthuoc=DataAcess.hsSqlTool.sGetSaveValue(sCapthuoc,"nvarchar");

 string sqlSave=" UPDATE HS_TOATHUOC_View SET "+"NgayToa ="+tem_sNgayToa+","
 +"IdBenhNhan ="+tem_sIdBenhNhan+","
 +"MaBN ="+tem_sMaBN+","
 +"HoTenBN ="+tem_sHoTenBN+","
 +"NgaySinh ="+tem_sNgaySinh+","
 +"GioiTinh ="+tem_sGioiTinh+","
 +"SoBHYT ="+tem_sSoBHYT+","
 +"DungTuyen ="+tem_sDungTuyen+","
 +"IsHaveThuoc ="+tem_sIsHaveThuoc+","
 +"BNTra ="+tem_sBNTra+","
 +"Capthuoc ="+tem_sCapthuoc+" WHERE IdToaThuoc="+DataAcess.hsSqlTool.sGetSaveValue(this.IdToaThuoc,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.NgayToa=sNgayToa;
                this.IdBenhNhan=sIdBenhNhan;
                this.MaBN=sMaBN;
                this.HoTenBN=sHoTenBN;
                this.NgaySinh=sNgaySinh;
                this.GioiTinh=sGioiTinh;
                this.SoBHYT=sSoBHYT;
                this.DungTuyen=sDungTuyen;
                this.IsHaveThuoc=sIsHaveThuoc;
                this.BNTra=sBNTra;
                this.Capthuoc=sCapthuoc;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_sNgayToa=DataAcess.hsSqlTool.sGetSaveValue(this.NgayToa,"datetime");
              string tem_sIdBenhNhan=DataAcess.hsSqlTool.sGetSaveValue(this.IdBenhNhan,"bigint");
              string tem_sMaBN=DataAcess.hsSqlTool.sGetSaveValue(this.MaBN,"nvarchar");
              string tem_sHoTenBN=DataAcess.hsSqlTool.sGetSaveValue(this.HoTenBN,"nvarchar");
              string tem_sNgaySinh=DataAcess.hsSqlTool.sGetSaveValue(this.NgaySinh,"datetime");
              string tem_sGioiTinh=DataAcess.hsSqlTool.sGetSaveValue(this.GioiTinh,"nvarchar");
              string tem_sSoBHYT=DataAcess.hsSqlTool.sGetSaveValue(this.SoBHYT,"nvarchar");
              string tem_sDungTuyen=DataAcess.hsSqlTool.sGetSaveValue(this.DungTuyen,"bit");
              string tem_sIsHaveThuoc=DataAcess.hsSqlTool.sGetSaveValue(this.IsHaveThuoc,"bit");
              string tem_sBNTra=DataAcess.hsSqlTool.sGetSaveValue(this.BNTra,"bigint");
              string tem_sCapthuoc=DataAcess.hsSqlTool.sGetSaveValue(this.Capthuoc,"nvarchar");

 string sqlSave=" UPDATE HS_TOATHUOC_View SET ";
if(tem_sNgayToa != null)
 sqlSave+="NgayToa ="+tem_sNgayToa+",";
if(tem_sIdBenhNhan != null)
 sqlSave+="IdBenhNhan ="+tem_sIdBenhNhan+",";
if(tem_sMaBN != null)
 sqlSave+="MaBN ="+tem_sMaBN+",";
if(tem_sHoTenBN != null)
 sqlSave+="HoTenBN ="+tem_sHoTenBN+",";
if(tem_sNgaySinh != null)
 sqlSave+="NgaySinh ="+tem_sNgaySinh+",";
if(tem_sGioiTinh != null)
 sqlSave+="GioiTinh ="+tem_sGioiTinh+",";
if(tem_sSoBHYT != null)
 sqlSave+="SoBHYT ="+tem_sSoBHYT+",";
if(tem_sDungTuyen != null)
 sqlSave+="DungTuyen ="+tem_sDungTuyen+",";
if(tem_sIsHaveThuoc != null)
 sqlSave+="IsHaveThuoc ="+tem_sIsHaveThuoc+",";
if(tem_sBNTra != null)
 sqlSave+="BNTra ="+tem_sBNTra+",";
if(tem_sCapthuoc != null)
 sqlSave+="Capthuoc ="+tem_sCapthuoc+",";
sqlSave+=" WHERE IdToaThuoc="+DataAcess.hsSqlTool.sGetSaveValue(this.IdToaThuoc,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_IdToaThuoc(string sIdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET IdToaThuoc='"+ sIdToaThuoc+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IdToaThuoc=sIdToaThuoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NgayToa(string sNgayToa)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET NgayToa='"+ sNgayToa+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NgayToa=sNgayToa;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdBenhNhan(string sIdBenhNhan)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET IdBenhNhan='"+ sIdBenhNhan+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IdBenhNhan=sIdBenhNhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MaBN(string sMaBN)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET MaBN='N"+ sMaBN+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MaBN=sMaBN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_HoTenBN(string sHoTenBN)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET HoTenBN='N"+ sHoTenBN+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.HoTenBN=sHoTenBN;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NgaySinh(string sNgaySinh)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET NgaySinh='"+ sNgaySinh+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NgaySinh=sNgaySinh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_GioiTinh(string sGioiTinh)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET GioiTinh='N"+ sGioiTinh+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.GioiTinh=sGioiTinh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_SoBHYT(string sSoBHYT)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET SoBHYT='N"+ sSoBHYT+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.SoBHYT=sSoBHYT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DungTuyen(string sDungTuyen)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET DungTuyen='"+ sDungTuyen+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DungTuyen=sDungTuyen;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsHaveThuoc(string sIsHaveThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET IsHaveThuoc='"+ sIsHaveThuoc+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IsHaveThuoc=sIsHaveThuoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BNTra(string sBNTra)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET BNTra='"+ sBNTra+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.BNTra=sBNTra;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Capthuoc(string sCapthuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET Capthuoc='N"+ sCapthuoc+ "' WHERE IdToaThuoc='"+ this.IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Capthuoc=sCapthuoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_IdToaThuoc(string sIdToaThuoc,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET IdToaThuoc='"+sIdToaThuoc+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NgayToa(string sNgayToa,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET NgayToa='"+sNgayToa+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IdBenhNhan(string sIdBenhNhan,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET IdBenhNhan='"+sIdBenhNhan+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MaBN(string sMaBN,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET MaBN='N"+sMaBN+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_HoTenBN(string sHoTenBN,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET HoTenBN='N"+sHoTenBN+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NgaySinh(string sNgaySinh,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET NgaySinh='"+sNgaySinh+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_GioiTinh(string sGioiTinh,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET GioiTinh='N"+sGioiTinh+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_SoBHYT(string sSoBHYT,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET SoBHYT='N"+sSoBHYT+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DungTuyen(string sDungTuyen,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET DungTuyen='"+sDungTuyen+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsHaveThuoc(string sIsHaveThuoc,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET IsHaveThuoc='"+sIsHaveThuoc+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BNTra(string sBNTra,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET BNTra='"+sBNTra+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Capthuoc(string sCapthuoc,string s_IdToaThuoc)
{
    string sqlSave= " UPDATE HS_TOATHUOC_View SET Capthuoc='N"+sCapthuoc+"' WHERE IdToaThuoc='"+ s_IdToaThuoc+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM HS_TOATHUOC_View " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_HS_TOATHUOC_View;
   public static bool Change_dt_HS_TOATHUOC_View = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_HS_TOATHUOC_View()
   {
   if (dt_HS_TOATHUOC_View == null || Change_dt_HS_TOATHUOC_View == true)
   {
   dt_HS_TOATHUOC_View = dtGetAll();
   Change_dt_HS_TOATHUOC_View = true && AllowAutoChange ;
   }
   return dt_HS_TOATHUOC_View;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

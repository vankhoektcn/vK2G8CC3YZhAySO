using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process_2608
  { 
 public class HS_TonKhoViewDetail:  Connect { 
 public static string sTableName= "HS_TonKhoViewDetail"; 
   public string IdTonKhoDetail;
   public string IdTonKho;
   public string TTHC;
   public string TenSP;
   public string TENDVT;
   public string Dongia;
   public string DAUKY_SL;
   public string DAUKY_TT;
   public string NHAP_SL;
   public string NHAP_TT;
   public string NHAP_SL2;
   public string NHAP_TT2;
   public string XUAT_SL;
   public string XUAT_TT;
   public string XUAT_SL2;
   public string XUAT_TT2;
   public string CUOIKY_SL;
   public string CUOIKY_TT;
   public string CATENAME;
   public string NHOMTHUOC;
   public string DES;
   public string IdThuoc;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_IdTonKhoDetail="IdTonKhoDetail" ;
 public static  string cl_IdTonKhoDetail_VN="IdTonKhoDetail";
 public static  string cl_IdTonKho="IdTonKho" ;
 public static  string cl_IdTonKho_VN="IdTonKho";
 public static  string cl_TTHC="TTHC" ;
 public static  string cl_TTHC_VN="TTHC";
 public static  string cl_TenSP="TenSP" ;
 public static  string cl_TenSP_VN="TenSP";
 public static  string cl_TENDVT="TENDVT" ;
 public static  string cl_TENDVT_VN="TENDVT";
 public static  string cl_Dongia="Dongia" ;
 public static  string cl_Dongia_VN="Dongia";
 public static  string cl_DAUKY_SL="DAUKY_SL" ;
 public static  string cl_DAUKY_SL_VN="DAUKY_SL";
 public static  string cl_DAUKY_TT="DAUKY_TT" ;
 public static  string cl_DAUKY_TT_VN="DAUKY_TT";
 public static  string cl_NHAP_SL="NHAP_SL" ;
 public static  string cl_NHAP_SL_VN="NHAP_SL";
 public static  string cl_NHAP_TT="NHAP_TT" ;
 public static  string cl_NHAP_TT_VN="NHAP_TT";
 public static  string cl_NHAP_SL2="NHAP_SL2" ;
 public static  string cl_NHAP_SL2_VN="NHAP_SL2";
 public static  string cl_NHAP_TT2="NHAP_TT2" ;
 public static  string cl_NHAP_TT2_VN="NHAP_TT2";
 public static  string cl_XUAT_SL="XUAT_SL" ;
 public static  string cl_XUAT_SL_VN="XUAT_SL";
 public static  string cl_XUAT_TT="XUAT_TT" ;
 public static  string cl_XUAT_TT_VN="XUAT_TT";
 public static  string cl_XUAT_SL2="XUAT_SL2" ;
 public static  string cl_XUAT_SL2_VN="XUAT_SL2";
 public static  string cl_XUAT_TT2="XUAT_TT2" ;
 public static  string cl_XUAT_TT2_VN="XUAT_TT2";
 public static  string cl_CUOIKY_SL="CUOIKY_SL" ;
 public static  string cl_CUOIKY_SL_VN="CUOIKY_SL";
 public static  string cl_CUOIKY_TT="CUOIKY_TT" ;
 public static  string cl_CUOIKY_TT_VN="CUOIKY_TT";
 public static  string cl_CATENAME="CATENAME" ;
 public static  string cl_CATENAME_VN="CATENAME";
 public static  string cl_NHOMTHUOC="NHOMTHUOC" ;
 public static  string cl_NHOMTHUOC_VN="NHOMTHUOC";
 public static  string cl_DES="DES" ;
 public static  string cl_DES_VN="DES";
 public static  string cl_IdThuoc="IdThuoc" ;
 public static  string cl_IdThuoc_VN="IdThuoc";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public HS_TonKhoViewDetail() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public HS_TonKhoViewDetail(
         string sIdTonKhoDetail,
         string sIdTonKho,
         string sTTHC,
         string sTenSP,
         string sTENDVT,
         string sDongia,
         string sDAUKY_SL,
         string sDAUKY_TT,
         string sNHAP_SL,
         string sNHAP_TT,
         string sNHAP_SL2,
         string sNHAP_TT2,
         string sXUAT_SL,
         string sXUAT_TT,
         string sXUAT_SL2,
         string sXUAT_TT2,
         string sCUOIKY_SL,
         string sCUOIKY_TT,
         string sCATENAME,
         string sNHOMTHUOC,
         string sDES,
         string sIdThuoc){
         this.IdTonKhoDetail= sIdTonKhoDetail;
         this.IdTonKho= sIdTonKho;
         this.TTHC= sTTHC;
         this.TenSP= sTenSP;
         this.TENDVT= sTENDVT;
         this.Dongia= sDongia;
         this.DAUKY_SL= sDAUKY_SL;
         this.DAUKY_TT= sDAUKY_TT;
         this.NHAP_SL= sNHAP_SL;
         this.NHAP_TT= sNHAP_TT;
         this.NHAP_SL2= sNHAP_SL2;
         this.NHAP_TT2= sNHAP_TT2;
         this.XUAT_SL= sXUAT_SL;
         this.XUAT_TT= sXUAT_TT;
         this.XUAT_SL2= sXUAT_SL2;
         this.XUAT_TT2= sXUAT_TT2;
         this.CUOIKY_SL= sCUOIKY_SL;
         this.CUOIKY_TT= sCUOIKY_TT;
         this.CATENAME= sCATENAME;
         this.NHOMTHUOC= sNHOMTHUOC;
         this.DES= sDES;
         this.IdThuoc= sIdThuoc;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static HS_TonKhoViewDetail Create_HS_TonKhoViewDetail ( string sIdTonKhoDetail  ){
    DataTable dt=dtSearchByIdTonKhoDetail(sIdTonKhoDetail) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new HS_TonKhoViewDetail(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM HS_TonKhoViewDetail AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by IdTonKhoDetail),T.* FROM HS_TonKhoViewDetail AS T WHERE";
      if (this.IdTonKho!=null && this.IdTonKho!="" && this.IdTonKho!="0" && this.IdTonKho!="0.0") 
            sqlselect +=" AND IdTonKho =" + this.IdTonKho ;
      if (this.TTHC!=null && this.TTHC!="") 
            sqlselect +=" AND TTHC LIKE N'%" + this.TTHC +"%'" ;
      if (this.TenSP!=null && this.TenSP!="") 
            sqlselect +=" AND TenSP LIKE N'%" + this.TenSP +"%'" ;
      if (this.TENDVT!=null && this.TENDVT!="") 
            sqlselect +=" AND TENDVT LIKE N'%" + this.TENDVT +"%'" ;
      if (this.Dongia!=null && this.Dongia!="" && this.Dongia!="0" && this.Dongia!="0.0") 
            sqlselect +=" AND Dongia =" + this.Dongia ;
      if (this.DAUKY_SL!=null && this.DAUKY_SL!="" && this.DAUKY_SL!="0" && this.DAUKY_SL!="0.0") 
            sqlselect +=" AND DAUKY_SL =" + this.DAUKY_SL ;
      if (this.DAUKY_TT!=null && this.DAUKY_TT!="" && this.DAUKY_TT!="0" && this.DAUKY_TT!="0.0") 
            sqlselect +=" AND DAUKY_TT =" + this.DAUKY_TT ;
      if (this.NHAP_SL!=null && this.NHAP_SL!="" && this.NHAP_SL!="0" && this.NHAP_SL!="0.0") 
            sqlselect +=" AND NHAP_SL =" + this.NHAP_SL ;
      if (this.NHAP_TT!=null && this.NHAP_TT!="" && this.NHAP_TT!="0" && this.NHAP_TT!="0.0") 
            sqlselect +=" AND NHAP_TT =" + this.NHAP_TT ;
      if (this.NHAP_SL2!=null && this.NHAP_SL2!="" && this.NHAP_SL2!="0" && this.NHAP_SL2!="0.0") 
            sqlselect +=" AND NHAP_SL2 =" + this.NHAP_SL2 ;
      if (this.NHAP_TT2!=null && this.NHAP_TT2!="" && this.NHAP_TT2!="0" && this.NHAP_TT2!="0.0") 
            sqlselect +=" AND NHAP_TT2 =" + this.NHAP_TT2 ;
      if (this.XUAT_SL!=null && this.XUAT_SL!="" && this.XUAT_SL!="0" && this.XUAT_SL!="0.0") 
            sqlselect +=" AND XUAT_SL =" + this.XUAT_SL ;
      if (this.XUAT_TT!=null && this.XUAT_TT!="" && this.XUAT_TT!="0" && this.XUAT_TT!="0.0") 
            sqlselect +=" AND XUAT_TT =" + this.XUAT_TT ;
      if (this.XUAT_SL2!=null && this.XUAT_SL2!="" && this.XUAT_SL2!="0" && this.XUAT_SL2!="0.0") 
            sqlselect +=" AND XUAT_SL2 =" + this.XUAT_SL2 ;
      if (this.XUAT_TT2!=null && this.XUAT_TT2!="" && this.XUAT_TT2!="0" && this.XUAT_TT2!="0.0") 
            sqlselect +=" AND XUAT_TT2 =" + this.XUAT_TT2 ;
      if (this.CUOIKY_SL!=null && this.CUOIKY_SL!="" && this.CUOIKY_SL!="0" && this.CUOIKY_SL!="0.0") 
            sqlselect +=" AND CUOIKY_SL =" + this.CUOIKY_SL ;
      if (this.CUOIKY_TT!=null && this.CUOIKY_TT!="" && this.CUOIKY_TT!="0" && this.CUOIKY_TT!="0.0") 
            sqlselect +=" AND CUOIKY_TT =" + this.CUOIKY_TT ;
      if (this.CATENAME!=null && this.CATENAME!="") 
            sqlselect +=" AND CATENAME LIKE N'%" + this.CATENAME +"%'" ;
      if (this.NHOMTHUOC!=null && this.NHOMTHUOC!="") 
            sqlselect +=" AND NHOMTHUOC LIKE N'%" + this.NHOMTHUOC +"%'" ;
      if (this.DES!=null && this.DES!="") 
            sqlselect +=" AND DES LIKE N'%" + this.DES +"%'" ;
      if (this.IdThuoc!=null && this.IdThuoc!="" && this.IdThuoc!="0" && this.IdThuoc!="0.0") 
            sqlselect +=" AND IdThuoc =" + this.IdThuoc ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public HS_TonKhoViewDetail( DataView dv,int pos)
{
         this.IdTonKhoDetail= dv[pos][0].ToString();
         this.IdTonKho= dv[pos][1].ToString();
         this.TTHC= dv[pos][2].ToString();
         this.TenSP= dv[pos][3].ToString();
         this.TENDVT= dv[pos][4].ToString();
         this.Dongia= dv[pos][5].ToString();
         this.DAUKY_SL= dv[pos][6].ToString();
         this.DAUKY_TT= dv[pos][7].ToString();
         this.NHAP_SL= dv[pos][8].ToString();
         this.NHAP_TT= dv[pos][9].ToString();
         this.NHAP_SL2= dv[pos][10].ToString();
         this.NHAP_TT2= dv[pos][11].ToString();
         this.XUAT_SL= dv[pos][12].ToString();
         this.XUAT_TT= dv[pos][13].ToString();
         this.XUAT_SL2= dv[pos][14].ToString();
         this.XUAT_TT2= dv[pos][15].ToString();
         this.CUOIKY_SL= dv[pos][16].ToString();
         this.CUOIKY_TT= dv[pos][17].ToString();
         this.CATENAME= dv[pos][18].ToString();
         this.NHOMTHUOC= dv[pos][19].ToString();
         this.DES= dv[pos][20].ToString();
         this.IdThuoc= dv[pos][21].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdTonKhoDetail(string sIdTonKhoDetail)
{
          string sqlSelect= s_Select()+ " WHERE IdTonKhoDetail  ="+ sIdTonKhoDetail + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdTonKhoDetail(string sIdTonKhoDetail,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdTonKhoDetail"+ sMatch +sIdTonKhoDetail + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdTonKho(string sIdTonKho)
{
          string sqlSelect= s_Select()+ " WHERE IdTonKho  ="+ sIdTonKho + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdTonKho(string sIdTonKho,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdTonKho"+ sMatch +sIdTonKho + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTTHC(string sTTHC)
{
          string sqlSelect= s_Select()+ " WHERE TTHC  Like N'%"+ sTTHC + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTenSP(string sTenSP)
{
          string sqlSelect= s_Select()+ " WHERE TenSP  Like N'%"+ sTenSP + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTENDVT(string sTENDVT)
{
          string sqlSelect= s_Select()+ " WHERE TENDVT  Like N'%"+ sTENDVT + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDongia(string sDongia)
{
          string sqlSelect= s_Select()+ " WHERE Dongia  ="+ sDongia + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDongia(string sDongia,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE Dongia"+ sMatch +sDongia + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDAUKY_SL(string sDAUKY_SL)
{
          string sqlSelect= s_Select()+ " WHERE DAUKY_SL  ="+ sDAUKY_SL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDAUKY_SL(string sDAUKY_SL,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DAUKY_SL"+ sMatch +sDAUKY_SL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDAUKY_TT(string sDAUKY_TT)
{
          string sqlSelect= s_Select()+ " WHERE DAUKY_TT  ="+ sDAUKY_TT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDAUKY_TT(string sDAUKY_TT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DAUKY_TT"+ sMatch +sDAUKY_TT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNHAP_SL(string sNHAP_SL)
{
          string sqlSelect= s_Select()+ " WHERE NHAP_SL  ="+ sNHAP_SL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNHAP_SL(string sNHAP_SL,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NHAP_SL"+ sMatch +sNHAP_SL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNHAP_TT(string sNHAP_TT)
{
          string sqlSelect= s_Select()+ " WHERE NHAP_TT  ="+ sNHAP_TT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNHAP_TT(string sNHAP_TT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NHAP_TT"+ sMatch +sNHAP_TT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNHAP_SL2(string sNHAP_SL2)
{
          string sqlSelect= s_Select()+ " WHERE NHAP_SL2  ="+ sNHAP_SL2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNHAP_SL2(string sNHAP_SL2,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NHAP_SL2"+ sMatch +sNHAP_SL2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNHAP_TT2(string sNHAP_TT2)
{
          string sqlSelect= s_Select()+ " WHERE NHAP_TT2  ="+ sNHAP_TT2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNHAP_TT2(string sNHAP_TT2,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE NHAP_TT2"+ sMatch +sNHAP_TT2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByXUAT_SL(string sXUAT_SL)
{
          string sqlSelect= s_Select()+ " WHERE XUAT_SL  ="+ sXUAT_SL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByXUAT_SL(string sXUAT_SL,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE XUAT_SL"+ sMatch +sXUAT_SL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByXUAT_TT(string sXUAT_TT)
{
          string sqlSelect= s_Select()+ " WHERE XUAT_TT  ="+ sXUAT_TT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByXUAT_TT(string sXUAT_TT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE XUAT_TT"+ sMatch +sXUAT_TT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByXUAT_SL2(string sXUAT_SL2)
{
          string sqlSelect= s_Select()+ " WHERE XUAT_SL2  ="+ sXUAT_SL2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByXUAT_SL2(string sXUAT_SL2,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE XUAT_SL2"+ sMatch +sXUAT_SL2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByXUAT_TT2(string sXUAT_TT2)
{
          string sqlSelect= s_Select()+ " WHERE XUAT_TT2  ="+ sXUAT_TT2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByXUAT_TT2(string sXUAT_TT2,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE XUAT_TT2"+ sMatch +sXUAT_TT2 + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCUOIKY_SL(string sCUOIKY_SL)
{
          string sqlSelect= s_Select()+ " WHERE CUOIKY_SL  ="+ sCUOIKY_SL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCUOIKY_SL(string sCUOIKY_SL,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CUOIKY_SL"+ sMatch +sCUOIKY_SL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCUOIKY_TT(string sCUOIKY_TT)
{
          string sqlSelect= s_Select()+ " WHERE CUOIKY_TT  ="+ sCUOIKY_TT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCUOIKY_TT(string sCUOIKY_TT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CUOIKY_TT"+ sMatch +sCUOIKY_TT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCATENAME(string sCATENAME)
{
          string sqlSelect= s_Select()+ " WHERE CATENAME  Like N'%"+ sCATENAME + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNHOMTHUOC(string sNHOMTHUOC)
{
          string sqlSelect= s_Select()+ " WHERE NHOMTHUOC  Like N'%"+ sNHOMTHUOC + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDES(string sDES)
{
          string sqlSelect= s_Select()+ " WHERE DES  Like N'%"+ sDES + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdThuoc(string sIdThuoc)
{
          string sqlSelect= s_Select()+ " WHERE IdThuoc  ="+ sIdThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdThuoc(string sIdThuoc,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdThuoc"+ sMatch +sIdThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sIdTonKhoDetail
            , string sIdTonKho
            , string sTTHC
            , string sTenSP
            , string sTENDVT
            , string sDongia
            , string sDAUKY_SL
            , string sDAUKY_TT
            , string sNHAP_SL
            , string sNHAP_TT
            , string sNHAP_SL2
            , string sNHAP_TT2
            , string sXUAT_SL
            , string sXUAT_TT
            , string sXUAT_SL2
            , string sXUAT_TT2
            , string sCUOIKY_SL
            , string sCUOIKY_TT
            , string sCATENAME
            , string sNHOMTHUOC
            , string sDES
            , string sIdThuoc
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sIdTonKhoDetail!=null && sIdTonKhoDetail!="") 
            sqlselect +=" AND IdTonKhoDetail =" + sIdTonKhoDetail ;
      if (sIdTonKho!=null && sIdTonKho!="") 
            sqlselect +=" AND IdTonKho =" + sIdTonKho ;
      if (sTTHC!=null && sTTHC!="") 
            sqlselect +=" AND TTHC LIKE N'%" + sTTHC +"%'" ;
      if (sTenSP!=null && sTenSP!="") 
            sqlselect +=" AND TenSP LIKE N'%" + sTenSP +"%'" ;
      if (sTENDVT!=null && sTENDVT!="") 
            sqlselect +=" AND TENDVT LIKE N'%" + sTENDVT +"%'" ;
      if (sDongia!=null && sDongia!="") 
            sqlselect +=" AND Dongia =" + sDongia ;
      if (sDAUKY_SL!=null && sDAUKY_SL!="") 
            sqlselect +=" AND DAUKY_SL =" + sDAUKY_SL ;
      if (sDAUKY_TT!=null && sDAUKY_TT!="") 
            sqlselect +=" AND DAUKY_TT =" + sDAUKY_TT ;
      if (sNHAP_SL!=null && sNHAP_SL!="") 
            sqlselect +=" AND NHAP_SL =" + sNHAP_SL ;
      if (sNHAP_TT!=null && sNHAP_TT!="") 
            sqlselect +=" AND NHAP_TT =" + sNHAP_TT ;
      if (sNHAP_SL2!=null && sNHAP_SL2!="") 
            sqlselect +=" AND NHAP_SL2 =" + sNHAP_SL2 ;
      if (sNHAP_TT2!=null && sNHAP_TT2!="") 
            sqlselect +=" AND NHAP_TT2 =" + sNHAP_TT2 ;
      if (sXUAT_SL!=null && sXUAT_SL!="") 
            sqlselect +=" AND XUAT_SL =" + sXUAT_SL ;
      if (sXUAT_TT!=null && sXUAT_TT!="") 
            sqlselect +=" AND XUAT_TT =" + sXUAT_TT ;
      if (sXUAT_SL2!=null && sXUAT_SL2!="") 
            sqlselect +=" AND XUAT_SL2 =" + sXUAT_SL2 ;
      if (sXUAT_TT2!=null && sXUAT_TT2!="") 
            sqlselect +=" AND XUAT_TT2 =" + sXUAT_TT2 ;
      if (sCUOIKY_SL!=null && sCUOIKY_SL!="") 
            sqlselect +=" AND CUOIKY_SL =" + sCUOIKY_SL ;
      if (sCUOIKY_TT!=null && sCUOIKY_TT!="") 
            sqlselect +=" AND CUOIKY_TT =" + sCUOIKY_TT ;
      if (sCATENAME!=null && sCATENAME!="") 
            sqlselect +=" AND CATENAME LIKE N'%" + sCATENAME +"%'" ;
      if (sNHOMTHUOC!=null && sNHOMTHUOC!="") 
            sqlselect +=" AND NHOMTHUOC LIKE N'%" + sNHOMTHUOC +"%'" ;
      if (sDES!=null && sDES!="") 
            sqlselect +=" AND DES LIKE N'%" + sDES +"%'" ;
      if (sIdThuoc!=null && sIdThuoc!="") 
            sqlselect +=" AND IdThuoc =" + sIdThuoc ;
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
 public static HS_TonKhoViewDetail Insert_Object(
string  sIdTonKhoDetail
            ,string  sIdTonKho
            ,string  sTTHC
            ,string  sTenSP
            ,string  sTENDVT
            ,string  sDongia
            ,string  sDAUKY_SL
            ,string  sDAUKY_TT
            ,string  sNHAP_SL
            ,string  sNHAP_TT
            ,string  sNHAP_SL2
            ,string  sNHAP_TT2
            ,string  sXUAT_SL
            ,string  sXUAT_TT
            ,string  sXUAT_SL2
            ,string  sXUAT_TT2
            ,string  sCUOIKY_SL
            ,string  sCUOIKY_TT
            ,string  sCATENAME
            ,string  sNHOMTHUOC
            ,string  sDES
            ,string  sIdThuoc
            ) 
 { 
              string tem_sIdTonKhoDetail=DataAcess.hsSqlTool.sGetSaveValue(sIdTonKhoDetail,"bigint");
              string tem_sIdTonKho=DataAcess.hsSqlTool.sGetSaveValue(sIdTonKho,"bigint");
              string tem_sTTHC=DataAcess.hsSqlTool.sGetSaveValue(sTTHC,"nvarchar");
              string tem_sTenSP=DataAcess.hsSqlTool.sGetSaveValue(sTenSP,"nvarchar");
              string tem_sTENDVT=DataAcess.hsSqlTool.sGetSaveValue(sTENDVT,"nvarchar");
              string tem_sDongia=DataAcess.hsSqlTool.sGetSaveValue(sDongia,"float");
              string tem_sDAUKY_SL=DataAcess.hsSqlTool.sGetSaveValue(sDAUKY_SL,"float");
              string tem_sDAUKY_TT=DataAcess.hsSqlTool.sGetSaveValue(sDAUKY_TT,"float");
              string tem_sNHAP_SL=DataAcess.hsSqlTool.sGetSaveValue(sNHAP_SL,"float");
              string tem_sNHAP_TT=DataAcess.hsSqlTool.sGetSaveValue(sNHAP_TT,"float");
              string tem_sNHAP_SL2=DataAcess.hsSqlTool.sGetSaveValue(sNHAP_SL2,"float");
              string tem_sNHAP_TT2=DataAcess.hsSqlTool.sGetSaveValue(sNHAP_TT2,"float");
              string tem_sXUAT_SL=DataAcess.hsSqlTool.sGetSaveValue(sXUAT_SL,"float");
              string tem_sXUAT_TT=DataAcess.hsSqlTool.sGetSaveValue(sXUAT_TT,"float");
              string tem_sXUAT_SL2=DataAcess.hsSqlTool.sGetSaveValue(sXUAT_SL2,"float");
              string tem_sXUAT_TT2=DataAcess.hsSqlTool.sGetSaveValue(sXUAT_TT2,"float");
              string tem_sCUOIKY_SL=DataAcess.hsSqlTool.sGetSaveValue(sCUOIKY_SL,"float");
              string tem_sCUOIKY_TT=DataAcess.hsSqlTool.sGetSaveValue(sCUOIKY_TT,"float");
              string tem_sCATENAME=DataAcess.hsSqlTool.sGetSaveValue(sCATENAME,"nvarchar");
              string tem_sNHOMTHUOC=DataAcess.hsSqlTool.sGetSaveValue(sNHOMTHUOC,"nvarchar");
              string tem_sDES=DataAcess.hsSqlTool.sGetSaveValue(sDES,"nvarchar");
              string tem_sIdThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIdThuoc,"bigint");

             string sqlSave=" INSERT INTO HS_TonKhoViewDetail("+
                   "IdTonKhoDetail," 
        +                   "IdTonKho," 
        +                   "TTHC," 
        +                   "TenSP," 
        +                   "TENDVT," 
        +                   "Dongia," 
        +                   "DAUKY_SL," 
        +                   "DAUKY_TT," 
        +                   "NHAP_SL," 
        +                   "NHAP_TT," 
        +                   "NHAP_SL2," 
        +                   "NHAP_TT2," 
        +                   "XUAT_SL," 
        +                   "XUAT_TT," 
        +                   "XUAT_SL2," 
        +                   "XUAT_TT2," 
        +                   "CUOIKY_SL," 
        +                   "CUOIKY_TT," 
        +                   "CATENAME," 
        +                   "NHOMTHUOC," 
        +                   "DES," 
        +                   "IdThuoc) VALUES("
 +tem_sIdTonKhoDetail+","
 +tem_sIdTonKho+","
 +tem_sTTHC+","
 +tem_sTenSP+","
 +tem_sTENDVT+","
 +tem_sDongia+","
 +tem_sDAUKY_SL+","
 +tem_sDAUKY_TT+","
 +tem_sNHAP_SL+","
 +tem_sNHAP_TT+","
 +tem_sNHAP_SL2+","
 +tem_sNHAP_TT2+","
 +tem_sXUAT_SL+","
 +tem_sXUAT_TT+","
 +tem_sXUAT_SL2+","
 +tem_sXUAT_TT2+","
 +tem_sCUOIKY_SL+","
 +tem_sCUOIKY_TT+","
 +tem_sCATENAME+","
 +tem_sNHOMTHUOC+","
 +tem_sDES+","
 +tem_sIdThuoc +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          HS_TonKhoViewDetail newHS_TonKhoViewDetail= new HS_TonKhoViewDetail();
              newHS_TonKhoViewDetail.IdTonKhoDetail=sIdTonKhoDetail;
              newHS_TonKhoViewDetail.IdTonKho=sIdTonKho;
              newHS_TonKhoViewDetail.TTHC=sTTHC;
              newHS_TonKhoViewDetail.TenSP=sTenSP;
              newHS_TonKhoViewDetail.TENDVT=sTENDVT;
              newHS_TonKhoViewDetail.Dongia=sDongia;
              newHS_TonKhoViewDetail.DAUKY_SL=sDAUKY_SL;
              newHS_TonKhoViewDetail.DAUKY_TT=sDAUKY_TT;
              newHS_TonKhoViewDetail.NHAP_SL=sNHAP_SL;
              newHS_TonKhoViewDetail.NHAP_TT=sNHAP_TT;
              newHS_TonKhoViewDetail.NHAP_SL2=sNHAP_SL2;
              newHS_TonKhoViewDetail.NHAP_TT2=sNHAP_TT2;
              newHS_TonKhoViewDetail.XUAT_SL=sXUAT_SL;
              newHS_TonKhoViewDetail.XUAT_TT=sXUAT_TT;
              newHS_TonKhoViewDetail.XUAT_SL2=sXUAT_SL2;
              newHS_TonKhoViewDetail.XUAT_TT2=sXUAT_TT2;
              newHS_TonKhoViewDetail.CUOIKY_SL=sCUOIKY_SL;
              newHS_TonKhoViewDetail.CUOIKY_TT=sCUOIKY_TT;
              newHS_TonKhoViewDetail.CATENAME=sCATENAME;
              newHS_TonKhoViewDetail.NHOMTHUOC=sNHOMTHUOC;
              newHS_TonKhoViewDetail.DES=sDES;
              newHS_TonKhoViewDetail.IdThuoc=sIdThuoc;
            return newHS_TonKhoViewDetail; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public HS_TonKhoViewDetail Insert_Object() { 
              string tem_sIdTonKhoDetail=(GetTable( " SELECT IdTonKhoDetail FROM HS_TonKhoViewDetail").Rows.Count + 1)+"";
              string tem_sIdTonKho=DataAcess.hsSqlTool.sGetSaveValue(this.IdTonKho,"bigint");
              string tem_sTTHC=DataAcess.hsSqlTool.sGetSaveValue(this.TTHC,"nvarchar");
              string tem_sTenSP=DataAcess.hsSqlTool.sGetSaveValue(this.TenSP,"nvarchar");
              string tem_sTENDVT=DataAcess.hsSqlTool.sGetSaveValue(this.TENDVT,"nvarchar");
              string tem_sDongia=DataAcess.hsSqlTool.sGetSaveValue(this.Dongia,"float");
              string tem_sDAUKY_SL=DataAcess.hsSqlTool.sGetSaveValue(this.DAUKY_SL,"float");
              string tem_sDAUKY_TT=DataAcess.hsSqlTool.sGetSaveValue(this.DAUKY_TT,"float");
              string tem_sNHAP_SL=DataAcess.hsSqlTool.sGetSaveValue(this.NHAP_SL,"float");
              string tem_sNHAP_TT=DataAcess.hsSqlTool.sGetSaveValue(this.NHAP_TT,"float");
              string tem_sNHAP_SL2=DataAcess.hsSqlTool.sGetSaveValue(this.NHAP_SL2,"float");
              string tem_sNHAP_TT2=DataAcess.hsSqlTool.sGetSaveValue(this.NHAP_TT2,"float");
              string tem_sXUAT_SL=DataAcess.hsSqlTool.sGetSaveValue(this.XUAT_SL,"float");
              string tem_sXUAT_TT=DataAcess.hsSqlTool.sGetSaveValue(this.XUAT_TT,"float");
              string tem_sXUAT_SL2=DataAcess.hsSqlTool.sGetSaveValue(this.XUAT_SL2,"float");
              string tem_sXUAT_TT2=DataAcess.hsSqlTool.sGetSaveValue(this.XUAT_TT2,"float");
              string tem_sCUOIKY_SL=DataAcess.hsSqlTool.sGetSaveValue(this.CUOIKY_SL,"float");
              string tem_sCUOIKY_TT=DataAcess.hsSqlTool.sGetSaveValue(this.CUOIKY_TT,"float");
              string tem_sCATENAME=DataAcess.hsSqlTool.sGetSaveValue(this.CATENAME,"nvarchar");
              string tem_sNHOMTHUOC=DataAcess.hsSqlTool.sGetSaveValue(this.NHOMTHUOC,"nvarchar");
              string tem_sDES=DataAcess.hsSqlTool.sGetSaveValue(this.DES,"nvarchar");
              string tem_sIdThuoc=DataAcess.hsSqlTool.sGetSaveValue(this.IdThuoc,"bigint");

             string sqlSave=" INSERT INTO HS_TonKhoViewDetail("+
                   "IdTonKhoDetail," 
        +                   "IdTonKho," 
        +                   "TTHC," 
        +                   "TenSP," 
        +                   "TENDVT," 
        +                   "Dongia," 
        +                   "DAUKY_SL," 
        +                   "DAUKY_TT," 
        +                   "NHAP_SL," 
        +                   "NHAP_TT," 
        +                   "NHAP_SL2," 
        +                   "NHAP_TT2," 
        +                   "XUAT_SL," 
        +                   "XUAT_TT," 
        +                   "XUAT_SL2," 
        +                   "XUAT_TT2," 
        +                   "CUOIKY_SL," 
        +                   "CUOIKY_TT," 
        +                   "CATENAME," 
        +                   "NHOMTHUOC," 
        +                   "DES," 
        +                   "IdThuoc) VALUES("
 +tem_sIdTonKhoDetail+","
 +tem_sIdTonKho+","
 +tem_sTTHC+","
 +tem_sTenSP+","
 +tem_sTENDVT+","
 +tem_sDongia+","
 +tem_sDAUKY_SL+","
 +tem_sDAUKY_TT+","
 +tem_sNHAP_SL+","
 +tem_sNHAP_TT+","
 +tem_sNHAP_SL2+","
 +tem_sNHAP_TT2+","
 +tem_sXUAT_SL+","
 +tem_sXUAT_TT+","
 +tem_sXUAT_SL2+","
 +tem_sXUAT_TT2+","
 +tem_sCUOIKY_SL+","
 +tem_sCUOIKY_TT+","
 +tem_sCATENAME+","
 +tem_sNHOMTHUOC+","
 +tem_sDES+","
 +tem_sIdThuoc +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          HS_TonKhoViewDetail newHS_TonKhoViewDetail= new HS_TonKhoViewDetail();
              newHS_TonKhoViewDetail.IdTonKhoDetail=this.IdTonKhoDetail;
              newHS_TonKhoViewDetail.IdTonKho=this.IdTonKho;
              newHS_TonKhoViewDetail.TTHC=this.TTHC;
              newHS_TonKhoViewDetail.TenSP=this.TenSP;
              newHS_TonKhoViewDetail.TENDVT=this.TENDVT;
              newHS_TonKhoViewDetail.Dongia=this.Dongia;
              newHS_TonKhoViewDetail.DAUKY_SL=this.DAUKY_SL;
              newHS_TonKhoViewDetail.DAUKY_TT=this.DAUKY_TT;
              newHS_TonKhoViewDetail.NHAP_SL=this.NHAP_SL;
              newHS_TonKhoViewDetail.NHAP_TT=this.NHAP_TT;
              newHS_TonKhoViewDetail.NHAP_SL2=this.NHAP_SL2;
              newHS_TonKhoViewDetail.NHAP_TT2=this.NHAP_TT2;
              newHS_TonKhoViewDetail.XUAT_SL=this.XUAT_SL;
              newHS_TonKhoViewDetail.XUAT_TT=this.XUAT_TT;
              newHS_TonKhoViewDetail.XUAT_SL2=this.XUAT_SL2;
              newHS_TonKhoViewDetail.XUAT_TT2=this.XUAT_TT2;
              newHS_TonKhoViewDetail.CUOIKY_SL=this.CUOIKY_SL;
              newHS_TonKhoViewDetail.CUOIKY_TT=this.CUOIKY_TT;
              newHS_TonKhoViewDetail.CATENAME=this.CATENAME;
              newHS_TonKhoViewDetail.NHOMTHUOC=this.NHOMTHUOC;
              newHS_TonKhoViewDetail.DES=this.DES;
              newHS_TonKhoViewDetail.IdThuoc=this.IdThuoc;
            return newHS_TonKhoViewDetail; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sIdTonKhoDetail
                ,string sIdTonKho
                ,string sTTHC
                ,string sTenSP
                ,string sTENDVT
                ,string sDongia
                ,string sDAUKY_SL
                ,string sDAUKY_TT
                ,string sNHAP_SL
                ,string sNHAP_TT
                ,string sNHAP_SL2
                ,string sNHAP_TT2
                ,string sXUAT_SL
                ,string sXUAT_TT
                ,string sXUAT_SL2
                ,string sXUAT_TT2
                ,string sCUOIKY_SL
                ,string sCUOIKY_TT
                ,string sCATENAME
                ,string sNHOMTHUOC
                ,string sDES
                ,string sIdThuoc
                ) 
 { 
              string tem_sIdTonKho=DataAcess.hsSqlTool.sGetSaveValue(sIdTonKho,"bigint");
              string tem_sTTHC=DataAcess.hsSqlTool.sGetSaveValue(sTTHC,"nvarchar");
              string tem_sTenSP=DataAcess.hsSqlTool.sGetSaveValue(sTenSP,"nvarchar");
              string tem_sTENDVT=DataAcess.hsSqlTool.sGetSaveValue(sTENDVT,"nvarchar");
              string tem_sDongia=DataAcess.hsSqlTool.sGetSaveValue(sDongia,"float");
              string tem_sDAUKY_SL=DataAcess.hsSqlTool.sGetSaveValue(sDAUKY_SL,"float");
              string tem_sDAUKY_TT=DataAcess.hsSqlTool.sGetSaveValue(sDAUKY_TT,"float");
              string tem_sNHAP_SL=DataAcess.hsSqlTool.sGetSaveValue(sNHAP_SL,"float");
              string tem_sNHAP_TT=DataAcess.hsSqlTool.sGetSaveValue(sNHAP_TT,"float");
              string tem_sNHAP_SL2=DataAcess.hsSqlTool.sGetSaveValue(sNHAP_SL2,"float");
              string tem_sNHAP_TT2=DataAcess.hsSqlTool.sGetSaveValue(sNHAP_TT2,"float");
              string tem_sXUAT_SL=DataAcess.hsSqlTool.sGetSaveValue(sXUAT_SL,"float");
              string tem_sXUAT_TT=DataAcess.hsSqlTool.sGetSaveValue(sXUAT_TT,"float");
              string tem_sXUAT_SL2=DataAcess.hsSqlTool.sGetSaveValue(sXUAT_SL2,"float");
              string tem_sXUAT_TT2=DataAcess.hsSqlTool.sGetSaveValue(sXUAT_TT2,"float");
              string tem_sCUOIKY_SL=DataAcess.hsSqlTool.sGetSaveValue(sCUOIKY_SL,"float");
              string tem_sCUOIKY_TT=DataAcess.hsSqlTool.sGetSaveValue(sCUOIKY_TT,"float");
              string tem_sCATENAME=DataAcess.hsSqlTool.sGetSaveValue(sCATENAME,"nvarchar");
              string tem_sNHOMTHUOC=DataAcess.hsSqlTool.sGetSaveValue(sNHOMTHUOC,"nvarchar");
              string tem_sDES=DataAcess.hsSqlTool.sGetSaveValue(sDES,"nvarchar");
              string tem_sIdThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIdThuoc,"bigint");

 string sqlSave=" UPDATE HS_TonKhoViewDetail SET "+"IdTonKho ="+tem_sIdTonKho+","
 +"TTHC ="+tem_sTTHC+","
 +"TenSP ="+tem_sTenSP+","
 +"TENDVT ="+tem_sTENDVT+","
 +"Dongia ="+tem_sDongia+","
 +"DAUKY_SL ="+tem_sDAUKY_SL+","
 +"DAUKY_TT ="+tem_sDAUKY_TT+","
 +"NHAP_SL ="+tem_sNHAP_SL+","
 +"NHAP_TT ="+tem_sNHAP_TT+","
 +"NHAP_SL2 ="+tem_sNHAP_SL2+","
 +"NHAP_TT2 ="+tem_sNHAP_TT2+","
 +"XUAT_SL ="+tem_sXUAT_SL+","
 +"XUAT_TT ="+tem_sXUAT_TT+","
 +"XUAT_SL2 ="+tem_sXUAT_SL2+","
 +"XUAT_TT2 ="+tem_sXUAT_TT2+","
 +"CUOIKY_SL ="+tem_sCUOIKY_SL+","
 +"CUOIKY_TT ="+tem_sCUOIKY_TT+","
 +"CATENAME ="+tem_sCATENAME+","
 +"NHOMTHUOC ="+tem_sNHOMTHUOC+","
 +"DES ="+tem_sDES+","
 +"IdThuoc ="+tem_sIdThuoc+" WHERE IdTonKhoDetail="+DataAcess.hsSqlTool.sGetSaveValue(this.IdTonKhoDetail,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.IdTonKho=sIdTonKho;
                this.TTHC=sTTHC;
                this.TenSP=sTenSP;
                this.TENDVT=sTENDVT;
                this.Dongia=sDongia;
                this.DAUKY_SL=sDAUKY_SL;
                this.DAUKY_TT=sDAUKY_TT;
                this.NHAP_SL=sNHAP_SL;
                this.NHAP_TT=sNHAP_TT;
                this.NHAP_SL2=sNHAP_SL2;
                this.NHAP_TT2=sNHAP_TT2;
                this.XUAT_SL=sXUAT_SL;
                this.XUAT_TT=sXUAT_TT;
                this.XUAT_SL2=sXUAT_SL2;
                this.XUAT_TT2=sXUAT_TT2;
                this.CUOIKY_SL=sCUOIKY_SL;
                this.CUOIKY_TT=sCUOIKY_TT;
                this.CATENAME=sCATENAME;
                this.NHOMTHUOC=sNHOMTHUOC;
                this.DES=sDES;
                this.IdThuoc=sIdThuoc;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_sIdTonKho=DataAcess.hsSqlTool.sGetSaveValue(this.IdTonKho,"bigint");
              string tem_sTTHC=DataAcess.hsSqlTool.sGetSaveValue(this.TTHC,"nvarchar");
              string tem_sTenSP=DataAcess.hsSqlTool.sGetSaveValue(this.TenSP,"nvarchar");
              string tem_sTENDVT=DataAcess.hsSqlTool.sGetSaveValue(this.TENDVT,"nvarchar");
              string tem_sDongia=DataAcess.hsSqlTool.sGetSaveValue(this.Dongia,"float");
              string tem_sDAUKY_SL=DataAcess.hsSqlTool.sGetSaveValue(this.DAUKY_SL,"float");
              string tem_sDAUKY_TT=DataAcess.hsSqlTool.sGetSaveValue(this.DAUKY_TT,"float");
              string tem_sNHAP_SL=DataAcess.hsSqlTool.sGetSaveValue(this.NHAP_SL,"float");
              string tem_sNHAP_TT=DataAcess.hsSqlTool.sGetSaveValue(this.NHAP_TT,"float");
              string tem_sNHAP_SL2=DataAcess.hsSqlTool.sGetSaveValue(this.NHAP_SL2,"float");
              string tem_sNHAP_TT2=DataAcess.hsSqlTool.sGetSaveValue(this.NHAP_TT2,"float");
              string tem_sXUAT_SL=DataAcess.hsSqlTool.sGetSaveValue(this.XUAT_SL,"float");
              string tem_sXUAT_TT=DataAcess.hsSqlTool.sGetSaveValue(this.XUAT_TT,"float");
              string tem_sXUAT_SL2=DataAcess.hsSqlTool.sGetSaveValue(this.XUAT_SL2,"float");
              string tem_sXUAT_TT2=DataAcess.hsSqlTool.sGetSaveValue(this.XUAT_TT2,"float");
              string tem_sCUOIKY_SL=DataAcess.hsSqlTool.sGetSaveValue(this.CUOIKY_SL,"float");
              string tem_sCUOIKY_TT=DataAcess.hsSqlTool.sGetSaveValue(this.CUOIKY_TT,"float");
              string tem_sCATENAME=DataAcess.hsSqlTool.sGetSaveValue(this.CATENAME,"nvarchar");
              string tem_sNHOMTHUOC=DataAcess.hsSqlTool.sGetSaveValue(this.NHOMTHUOC,"nvarchar");
              string tem_sDES=DataAcess.hsSqlTool.sGetSaveValue(this.DES,"nvarchar");
              string tem_sIdThuoc=DataAcess.hsSqlTool.sGetSaveValue(this.IdThuoc,"bigint");

 string sqlSave=" UPDATE HS_TonKhoViewDetail SET ";
if(tem_sIdTonKho != null)
 sqlSave+="IdTonKho ="+tem_sIdTonKho+",";
if(tem_sTTHC != null)
 sqlSave+="TTHC ="+tem_sTTHC+",";
if(tem_sTenSP != null)
 sqlSave+="TenSP ="+tem_sTenSP+",";
if(tem_sTENDVT != null)
 sqlSave+="TENDVT ="+tem_sTENDVT+",";
if(tem_sDongia != null)
 sqlSave+="Dongia ="+tem_sDongia+",";
if(tem_sDAUKY_SL != null)
 sqlSave+="DAUKY_SL ="+tem_sDAUKY_SL+",";
if(tem_sDAUKY_TT != null)
 sqlSave+="DAUKY_TT ="+tem_sDAUKY_TT+",";
if(tem_sNHAP_SL != null)
 sqlSave+="NHAP_SL ="+tem_sNHAP_SL+",";
if(tem_sNHAP_TT != null)
 sqlSave+="NHAP_TT ="+tem_sNHAP_TT+",";
if(tem_sNHAP_SL2 != null)
 sqlSave+="NHAP_SL2 ="+tem_sNHAP_SL2+",";
if(tem_sNHAP_TT2 != null)
 sqlSave+="NHAP_TT2 ="+tem_sNHAP_TT2+",";
if(tem_sXUAT_SL != null)
 sqlSave+="XUAT_SL ="+tem_sXUAT_SL+",";
if(tem_sXUAT_TT != null)
 sqlSave+="XUAT_TT ="+tem_sXUAT_TT+",";
if(tem_sXUAT_SL2 != null)
 sqlSave+="XUAT_SL2 ="+tem_sXUAT_SL2+",";
if(tem_sXUAT_TT2 != null)
 sqlSave+="XUAT_TT2 ="+tem_sXUAT_TT2+",";
if(tem_sCUOIKY_SL != null)
 sqlSave+="CUOIKY_SL ="+tem_sCUOIKY_SL+",";
if(tem_sCUOIKY_TT != null)
 sqlSave+="CUOIKY_TT ="+tem_sCUOIKY_TT+",";
if(tem_sCATENAME != null)
 sqlSave+="CATENAME ="+tem_sCATENAME+",";
if(tem_sNHOMTHUOC != null)
 sqlSave+="NHOMTHUOC ="+tem_sNHOMTHUOC+",";
if(tem_sDES != null)
 sqlSave+="DES ="+tem_sDES+",";
if(tem_sIdThuoc != null)
 sqlSave+="IdThuoc ="+tem_sIdThuoc+",";
sqlSave+=" WHERE IdTonKhoDetail="+DataAcess.hsSqlTool.sGetSaveValue(this.IdTonKhoDetail,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_IdTonKhoDetail(string sIdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET IdTonKhoDetail='"+ sIdTonKhoDetail+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IdTonKhoDetail=sIdTonKhoDetail;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdTonKho(string sIdTonKho)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET IdTonKho='"+ sIdTonKho+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IdTonKho=sIdTonKho;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TTHC(string sTTHC)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET TTHC='N"+ sTTHC+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TTHC=sTTHC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TenSP(string sTenSP)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET TenSP='N"+ sTenSP+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TenSP=sTenSP;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TENDVT(string sTENDVT)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET TENDVT='N"+ sTENDVT+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TENDVT=sTENDVT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Dongia(string sDongia)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET Dongia='"+ sDongia+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Dongia=sDongia;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DAUKY_SL(string sDAUKY_SL)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET DAUKY_SL='"+ sDAUKY_SL+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DAUKY_SL=sDAUKY_SL;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DAUKY_TT(string sDAUKY_TT)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET DAUKY_TT='"+ sDAUKY_TT+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DAUKY_TT=sDAUKY_TT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NHAP_SL(string sNHAP_SL)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHAP_SL='"+ sNHAP_SL+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NHAP_SL=sNHAP_SL;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NHAP_TT(string sNHAP_TT)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHAP_TT='"+ sNHAP_TT+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NHAP_TT=sNHAP_TT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NHAP_SL2(string sNHAP_SL2)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHAP_SL2='"+ sNHAP_SL2+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NHAP_SL2=sNHAP_SL2;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NHAP_TT2(string sNHAP_TT2)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHAP_TT2='"+ sNHAP_TT2+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NHAP_TT2=sNHAP_TT2;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_XUAT_SL(string sXUAT_SL)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET XUAT_SL='"+ sXUAT_SL+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.XUAT_SL=sXUAT_SL;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_XUAT_TT(string sXUAT_TT)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET XUAT_TT='"+ sXUAT_TT+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.XUAT_TT=sXUAT_TT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_XUAT_SL2(string sXUAT_SL2)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET XUAT_SL2='"+ sXUAT_SL2+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.XUAT_SL2=sXUAT_SL2;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_XUAT_TT2(string sXUAT_TT2)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET XUAT_TT2='"+ sXUAT_TT2+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.XUAT_TT2=sXUAT_TT2;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CUOIKY_SL(string sCUOIKY_SL)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET CUOIKY_SL='"+ sCUOIKY_SL+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CUOIKY_SL=sCUOIKY_SL;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CUOIKY_TT(string sCUOIKY_TT)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET CUOIKY_TT='"+ sCUOIKY_TT+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CUOIKY_TT=sCUOIKY_TT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CATENAME(string sCATENAME)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET CATENAME='N"+ sCATENAME+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CATENAME=sCATENAME;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_NHOMTHUOC(string sNHOMTHUOC)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHOMTHUOC='N"+ sNHOMTHUOC+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.NHOMTHUOC=sNHOMTHUOC;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DES(string sDES)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET DES='N"+ sDES+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DES=sDES;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdThuoc(string sIdThuoc)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET IdThuoc='"+ sIdThuoc+ "' WHERE IdTonKhoDetail='"+ this.IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IdThuoc=sIdThuoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_IdTonKhoDetail(string sIdTonKhoDetail,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET IdTonKhoDetail='"+sIdTonKhoDetail+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IdTonKho(string sIdTonKho,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET IdTonKho='"+sIdTonKho+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TTHC(string sTTHC,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET TTHC='N"+sTTHC+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TenSP(string sTenSP,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET TenSP='N"+sTenSP+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TENDVT(string sTENDVT,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET TENDVT='N"+sTENDVT+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Dongia(string sDongia,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET Dongia='"+sDongia+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DAUKY_SL(string sDAUKY_SL,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET DAUKY_SL='"+sDAUKY_SL+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DAUKY_TT(string sDAUKY_TT,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET DAUKY_TT='"+sDAUKY_TT+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NHAP_SL(string sNHAP_SL,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHAP_SL='"+sNHAP_SL+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NHAP_TT(string sNHAP_TT,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHAP_TT='"+sNHAP_TT+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NHAP_SL2(string sNHAP_SL2,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHAP_SL2='"+sNHAP_SL2+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NHAP_TT2(string sNHAP_TT2,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHAP_TT2='"+sNHAP_TT2+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_XUAT_SL(string sXUAT_SL,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET XUAT_SL='"+sXUAT_SL+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_XUAT_TT(string sXUAT_TT,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET XUAT_TT='"+sXUAT_TT+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_XUAT_SL2(string sXUAT_SL2,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET XUAT_SL2='"+sXUAT_SL2+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_XUAT_TT2(string sXUAT_TT2,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET XUAT_TT2='"+sXUAT_TT2+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CUOIKY_SL(string sCUOIKY_SL,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET CUOIKY_SL='"+sCUOIKY_SL+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CUOIKY_TT(string sCUOIKY_TT,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET CUOIKY_TT='"+sCUOIKY_TT+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CATENAME(string sCATENAME,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET CATENAME='N"+sCATENAME+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_NHOMTHUOC(string sNHOMTHUOC,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET NHOMTHUOC='N"+sNHOMTHUOC+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DES(string sDES,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET DES='N"+sDES+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IdThuoc(string sIdThuoc,string s_IdTonKhoDetail)
{
    string sqlSave= " UPDATE HS_TonKhoViewDetail SET IdThuoc='"+sIdThuoc+"' WHERE IdTonKhoDetail='"+ s_IdTonKhoDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM HS_TonKhoViewDetail " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_HS_TonKhoViewDetail;
   public static bool Change_dt_HS_TonKhoViewDetail = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_HS_TonKhoViewDetail()
   {
   if (dt_HS_TonKhoViewDetail == null || Change_dt_HS_TonKhoViewDetail == true)
   {
   dt_HS_TonKhoViewDetail = dtGetAll();
   Change_dt_HS_TonKhoViewDetail = true && AllowAutoChange ;
   }
   return dt_HS_TonKhoViewDetail;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

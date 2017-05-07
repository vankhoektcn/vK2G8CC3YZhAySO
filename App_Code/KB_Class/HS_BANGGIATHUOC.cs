using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace Process
  { 
 public class HS_BANGGIATHUOC:  Connect { 
 public static string sTableName= "HS_BANGGIATHUOC"; 
   public string IDBANGGIA;
   public string TuNgay;
   public string DenNgay;
   public string LanThu;
   public string LoaiThuocID;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_IDBANGGIA="IDBANGGIA" ;
 public static  string cl_IDBANGGIA_VN="IDBANGGIA";
 public static  string cl_TuNgay="TuNgay" ;
 public static  string cl_TuNgay_VN="TuNgay";
 public static  string cl_DenNgay="DenNgay" ;
 public static  string cl_DenNgay_VN="DenNgay";
 public static  string cl_LanThu="LanThu" ;
 public static  string cl_LanThu_VN="LanThu";
 public static  string cl_LoaiThuocID="LoaiThuocID" ;
 public static  string cl_LoaiThuocID_VN="LoaiThuocID";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public HS_BANGGIATHUOC() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public HS_BANGGIATHUOC(
         string sIDBANGGIA,
         string sTuNgay,
         string sDenNgay,
         string sLanThu,
         string sLoaiThuocID){
         this.IDBANGGIA= sIDBANGGIA;
         this.TuNgay= sTuNgay;
         this.DenNgay= sDenNgay;
         this.LanThu= sLanThu;
         this.LoaiThuocID= sLoaiThuocID;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static HS_BANGGIATHUOC Create_HS_BANGGIATHUOC ( string sIDBANGGIA  ){
    DataTable dt=dtSearchByIDBANGGIA(sIDBANGGIA) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new HS_BANGGIATHUOC(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM HS_BANGGIATHUOC AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by IDBANGGIA),T.* FROM HS_BANGGIATHUOC AS T WHERE";
      if (this.TuNgay!=null && this.TuNgay!="") 
            sqlselect +=" AND TuNgay LIKE '%" + this.TuNgay +"%'" ;
      if (this.DenNgay!=null && this.DenNgay!="") 
            sqlselect +=" AND DenNgay LIKE '%" + this.DenNgay +"%'" ;
      if (this.LanThu!=null && this.LanThu!="" && this.LanThu!="0" && this.LanThu!="0.0") 
            sqlselect +=" AND LanThu =" + this.LanThu ;
      if (this.LoaiThuocID!=null && this.LoaiThuocID!="" && this.LoaiThuocID!="0" && this.LoaiThuocID!="0.0") 
            sqlselect +=" AND LoaiThuocID =" + this.LoaiThuocID ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public HS_BANGGIATHUOC( DataView dv,int pos)
{
         this.IDBANGGIA= dv[pos][0].ToString();
         this.TuNgay= dv[pos][1].ToString();
         this.DenNgay= dv[pos][2].ToString();
         this.LanThu= dv[pos][3].ToString();
         this.LoaiThuocID= dv[pos][4].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDBANGGIA(string sIDBANGGIA)
{
          string sqlSelect= s_Select()+ " WHERE IDBANGGIA  ="+ sIDBANGGIA + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDBANGGIA(string sIDBANGGIA,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IDBANGGIA"+ sMatch +sIDBANGGIA + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTuNgay(string sTuNgay)
{
          string sqlSelect= s_Select()+ " WHERE TuNgay  ="+ sTuNgay + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTuNgay(string sTuNgay,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE TuNgay"+ sMatch +sTuNgay + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDenNgay(string sDenNgay)
{
          string sqlSelect= s_Select()+ " WHERE DenNgay  ="+ sDenNgay + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDenNgay(string sDenNgay,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DenNgay"+ sMatch +sDenNgay + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLanThu(string sLanThu)
{
          string sqlSelect= s_Select()+ " WHERE LanThu  ="+ sLanThu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLanThu(string sLanThu,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE LanThu"+ sMatch +sLanThu + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLoaiThuocID(string sLoaiThuocID)
{
          string sqlSelect= s_Select()+ " WHERE LoaiThuocID  ="+ sLoaiThuocID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLoaiThuocID(string sLoaiThuocID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE LoaiThuocID"+ sMatch +sLoaiThuocID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sIDBANGGIA
            , string sTuNgay
            , string sDenNgay
            , string sLanThu
            , string sLoaiThuocID
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sIDBANGGIA!=null && sIDBANGGIA!="") 
            sqlselect +=" AND IDBANGGIA =" + sIDBANGGIA ;
      if (sTuNgay!=null && sTuNgay!="") 
            sqlselect +=" AND TuNgay LIKE '%" + sTuNgay +"%'" ;
      if (sDenNgay!=null && sDenNgay!="") 
            sqlselect +=" AND DenNgay LIKE '%" + sDenNgay +"%'" ;
      if (sLanThu!=null && sLanThu!="") 
            sqlselect +=" AND LanThu =" + sLanThu ;
      if (sLoaiThuocID!=null && sLoaiThuocID!="") 
            sqlselect +=" AND LoaiThuocID =" + sLoaiThuocID ;
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
 public static HS_BANGGIATHUOC Insert_Object(
string  sIDBANGGIA
            ,string  sTuNgay
            ,string  sDenNgay
            ,string  sLanThu
            ,string  sLoaiThuocID
            ) 
 { 
              string tem_sIDBANGGIA=DataAcess.hsSqlTool.sGetSaveValue(sIDBANGGIA,"bigint");
              string tem_sTuNgay=DataAcess.hsSqlTool.sGetSaveValue(sTuNgay,"datetime");
              string tem_sDenNgay=DataAcess.hsSqlTool.sGetSaveValue(sDenNgay,"datetime");
              string tem_sLanThu=DataAcess.hsSqlTool.sGetSaveValue(sLanThu,"int");
              string tem_sLoaiThuocID=DataAcess.hsSqlTool.sGetSaveValue(sLoaiThuocID,"bigint");

             string sqlSave=" INSERT INTO HS_BANGGIATHUOC("+
                   "IDBANGGIA," 
        +                   "TuNgay," 
        +                   "DenNgay," 
        +                   "LanThu," 
        +                   "LoaiThuocID) VALUES("
 +tem_sIDBANGGIA+","
 +tem_sTuNgay+","
 +tem_sDenNgay+","
 +tem_sLanThu+","
 +tem_sLoaiThuocID +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          HS_BANGGIATHUOC newHS_BANGGIATHUOC= new HS_BANGGIATHUOC();
              newHS_BANGGIATHUOC.IDBANGGIA=sIDBANGGIA;
              newHS_BANGGIATHUOC.TuNgay=sTuNgay;
              newHS_BANGGIATHUOC.DenNgay=sDenNgay;
              newHS_BANGGIATHUOC.LanThu=sLanThu;
              newHS_BANGGIATHUOC.LoaiThuocID=sLoaiThuocID;
            return newHS_BANGGIATHUOC; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public HS_BANGGIATHUOC Insert_Object() { 
              string tem_sIDBANGGIA=(GetTable( " SELECT IDBANGGIA FROM HS_BANGGIATHUOC").Rows.Count + 1)+"";
              string tem_sTuNgay=DataAcess.hsSqlTool.sGetSaveValue(this.TuNgay,"datetime");
              string tem_sDenNgay=DataAcess.hsSqlTool.sGetSaveValue(this.DenNgay,"datetime");
              string tem_sLanThu=DataAcess.hsSqlTool.sGetSaveValue(this.LanThu,"int");
              string tem_sLoaiThuocID=DataAcess.hsSqlTool.sGetSaveValue(this.LoaiThuocID,"bigint");

             string sqlSave=" INSERT INTO HS_BANGGIATHUOC("+
                   "IDBANGGIA," 
        +                   "TuNgay," 
        +                   "DenNgay," 
        +                   "LanThu," 
        +                   "LoaiThuocID) VALUES("
 +tem_sIDBANGGIA+","
 +tem_sTuNgay+","
 +tem_sDenNgay+","
 +tem_sLanThu+","
 +tem_sLoaiThuocID +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          HS_BANGGIATHUOC newHS_BANGGIATHUOC= new HS_BANGGIATHUOC();
              newHS_BANGGIATHUOC.IDBANGGIA=this.IDBANGGIA;
              newHS_BANGGIATHUOC.TuNgay=this.TuNgay;
              newHS_BANGGIATHUOC.DenNgay=this.DenNgay;
              newHS_BANGGIATHUOC.LanThu=this.LanThu;
              newHS_BANGGIATHUOC.LoaiThuocID=this.LoaiThuocID;
            return newHS_BANGGIATHUOC; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sIDBANGGIA
                ,string sTuNgay
                ,string sDenNgay
                ,string sLanThu
                ,string sLoaiThuocID
                ) 
 { 
              string tem_sTuNgay=DataAcess.hsSqlTool.sGetSaveValue(sTuNgay,"datetime");
              string tem_sDenNgay=DataAcess.hsSqlTool.sGetSaveValue(sDenNgay,"datetime");
              string tem_sLanThu=DataAcess.hsSqlTool.sGetSaveValue(sLanThu,"int");
              string tem_sLoaiThuocID=DataAcess.hsSqlTool.sGetSaveValue(sLoaiThuocID,"bigint");

 string sqlSave=" UPDATE HS_BANGGIATHUOC SET "+"TuNgay ="+tem_sTuNgay+","
 +"DenNgay ="+tem_sDenNgay+","
 +"LanThu ="+tem_sLanThu+","
 +"LoaiThuocID ="+tem_sLoaiThuocID+" WHERE IDBANGGIA="+DataAcess.hsSqlTool.sGetSaveValue(this.IDBANGGIA,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.TuNgay=sTuNgay;
                this.DenNgay=sDenNgay;
                this.LanThu=sLanThu;
                this.LoaiThuocID=sLoaiThuocID;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_sTuNgay=DataAcess.hsSqlTool.sGetSaveValue(this.TuNgay,"datetime");
              string tem_sDenNgay=DataAcess.hsSqlTool.sGetSaveValue(this.DenNgay,"datetime");
              string tem_sLanThu=DataAcess.hsSqlTool.sGetSaveValue(this.LanThu,"int");
              string tem_sLoaiThuocID=DataAcess.hsSqlTool.sGetSaveValue(this.LoaiThuocID,"bigint");

 string sqlSave=" UPDATE HS_BANGGIATHUOC SET ";
if(tem_sTuNgay != null)
 sqlSave+="TuNgay ="+tem_sTuNgay+",";
if(tem_sDenNgay != null)
 sqlSave+="DenNgay ="+tem_sDenNgay+",";
if(tem_sLanThu != null)
 sqlSave+="LanThu ="+tem_sLanThu+",";
if(tem_sLoaiThuocID != null)
 sqlSave+="LoaiThuocID ="+tem_sLoaiThuocID+",";
sqlSave+=" WHERE IDBANGGIA="+DataAcess.hsSqlTool.sGetSaveValue(this.IDBANGGIA,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_IDBANGGIA(string sIDBANGGIA)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET IDBANGGIA='"+ sIDBANGGIA+ "' WHERE IDBANGGIA='"+ this.IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IDBANGGIA=sIDBANGGIA;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TuNgay(string sTuNgay)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET TuNgay='"+ sTuNgay+ "' WHERE IDBANGGIA='"+ this.IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TuNgay=sTuNgay;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DenNgay(string sDenNgay)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET DenNgay='"+ sDenNgay+ "' WHERE IDBANGGIA='"+ this.IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DenNgay=sDenNgay;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_LanThu(string sLanThu)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET LanThu='"+ sLanThu+ "' WHERE IDBANGGIA='"+ this.IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.LanThu=sLanThu;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_LoaiThuocID(string sLoaiThuocID)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET LoaiThuocID='"+ sLoaiThuocID+ "' WHERE IDBANGGIA='"+ this.IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.LoaiThuocID=sLoaiThuocID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_IDBANGGIA(string sIDBANGGIA,string s_IDBANGGIA)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET IDBANGGIA='"+sIDBANGGIA+"' WHERE IDBANGGIA='"+ s_IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TuNgay(string sTuNgay,string s_IDBANGGIA)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET TuNgay='"+sTuNgay+"' WHERE IDBANGGIA='"+ s_IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DenNgay(string sDenNgay,string s_IDBANGGIA)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET DenNgay='"+sDenNgay+"' WHERE IDBANGGIA='"+ s_IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_LanThu(string sLanThu,string s_IDBANGGIA)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET LanThu='"+sLanThu+"' WHERE IDBANGGIA='"+ s_IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_LoaiThuocID(string sLoaiThuocID,string s_IDBANGGIA)
{
    string sqlSave= " UPDATE HS_BANGGIATHUOC SET LoaiThuocID='"+sLoaiThuocID+"' WHERE IDBANGGIA='"+ s_IDBANGGIA+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM HS_BANGGIATHUOC " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_HS_BANGGIATHUOC;
   public static bool Change_dt_HS_BANGGIATHUOC = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_HS_BANGGIATHUOC()
   {
   if (dt_HS_BANGGIATHUOC == null || Change_dt_HS_BANGGIATHUOC == true)
   {
   dt_HS_BANGGIATHUOC = dtGetAll();
   Change_dt_HS_BANGGIATHUOC = true && AllowAutoChange ;
   }
   return dt_HS_BANGGIATHUOC;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

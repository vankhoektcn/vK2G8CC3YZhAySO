using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process
  { 
 public class danhmucnghenghiep:  Connect { 
 public static string sTableName= "danhmucnghenghiep"; 
   public string idnghenghiep;
   public string manghenghiep;
   public string tennghenghiep;
   public string tennghenghieptheoboyte;
   #region DataColumn Name ;
 public static  string cl_idnghenghiep="idnghenghiep" ;
 public static  string cl_idnghenghiep_VN="idnghenghiep";
 public static  string cl_manghenghiep="manghenghiep" ;
 public static  string cl_manghenghiep_VN="manghenghiep";
 public static  string cl_tennghenghiep="tennghenghiep" ;
 public static  string cl_tennghenghiep_VN="tennghenghiep";
 public static  string cl_tennghenghieptheoboyte="tennghenghieptheoboyte" ;
 public static  string cl_tennghenghieptheoboyte_VN="tennghenghieptheoboyte";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public danhmucnghenghiep() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public danhmucnghenghiep(
         string sidnghenghiep,
         string smanghenghiep,
         string stennghenghiep,
         string stennghenghieptheoboyte){
         this.idnghenghiep= sidnghenghiep;
         this.manghenghiep= smanghenghiep;
         this.tennghenghiep= stennghenghiep;
         this.tennghenghieptheoboyte= stennghenghieptheoboyte;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static danhmucnghenghiep Create_danhmucnghenghiep ( string sidnghenghiep  ){
    DataTable dt=dtSearchByidnghenghiep(sidnghenghiep) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new danhmucnghenghiep(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM danhmucnghenghiep AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public danhmucnghenghiep( DataView dv,int pos)
{
         this.idnghenghiep= dv[pos][0].ToString();
         this.manghenghiep= dv[pos][1].ToString();
         this.tennghenghiep= dv[pos][2].ToString();
         this.tennghenghieptheoboyte= dv[pos][3].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidnghenghiep(string sidnghenghiep)
{
          string sqlSelect= s_Select()+ " WHERE idnghenghiep  ="+ sidnghenghiep + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidnghenghiep(string sidnghenghiep,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idnghenghiep"+ sMatch +sidnghenghiep + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBymanghenghiep(string smanghenghiep)
{
          string sqlSelect= s_Select()+ " WHERE manghenghiep  Like N'%"+ smanghenghiep + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytennghenghiep(string stennghenghiep)
{
          string sqlSelect= s_Select()+ " WHERE tennghenghiep  Like N'%"+ stennghenghiep + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytennghenghieptheoboyte(string stennghenghieptheoboyte)
{
          string sqlSelect= s_Select()+ " WHERE tennghenghieptheoboyte  Like N'%"+ stennghenghieptheoboyte + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sidnghenghiep
            , string smanghenghiep
            , string stennghenghiep
            , string stennghenghieptheoboyte
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sidnghenghiep!=null && sidnghenghiep!="") 
            sqlselect +=" AND idnghenghiep =" + sidnghenghiep ;
      if (smanghenghiep!=null && smanghenghiep!="") 
            sqlselect +=" AND manghenghiep LIKE N'%" + smanghenghiep +"%'" ;
      if (stennghenghiep!=null && stennghenghiep!="") 
            sqlselect +=" AND tennghenghiep LIKE N'%" + stennghenghiep +"%'" ;
      if (stennghenghieptheoboyte!=null && stennghenghieptheoboyte!="") 
            sqlselect +=" AND tennghenghieptheoboyte LIKE N'%" + stennghenghieptheoboyte +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static danhmucnghenghiep Insert_Object(
string  smanghenghiep
            ,string  stennghenghiep
            ,string  stennghenghieptheoboyte
            ) 
 { 
              string tem_smanghenghiep=DataAcess.hsSqlTool.sGetSaveValue(smanghenghiep,"char");
              string tem_stennghenghiep=DataAcess.hsSqlTool.sGetSaveValue(stennghenghiep,"nvarchar");
              string tem_stennghenghieptheoboyte=DataAcess.hsSqlTool.sGetSaveValue(stennghenghieptheoboyte,"nvarchar");

             string sqlSave=" INSERT INTO danhmucnghenghiep("+
                   "manghenghiep," 
        +                   "tennghenghiep," 
        +                   "tennghenghieptheoboyte) VALUES("
 +tem_smanghenghiep+","
 +tem_stennghenghiep+","
 +tem_stennghenghieptheoboyte +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          danhmucnghenghiep newdanhmucnghenghiep= new danhmucnghenghiep();
                 newdanhmucnghenghiep.idnghenghiep=GetTable( " SELECT TOP 1 idnghenghiep FROM danhmucnghenghiep ORDER BY idnghenghiep DESC ").Rows[0][0].ToString();
              newdanhmucnghenghiep.manghenghiep=smanghenghiep;
              newdanhmucnghenghiep.tennghenghiep=stennghenghiep;
              newdanhmucnghenghiep.tennghenghieptheoboyte=stennghenghieptheoboyte;
            return newdanhmucnghenghiep; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string smanghenghiep
                ,string stennghenghiep
                ,string stennghenghieptheoboyte
                ) 
 { 
              string tem_smanghenghiep=DataAcess.hsSqlTool.sGetSaveValue(smanghenghiep,"char");
              string tem_stennghenghiep=DataAcess.hsSqlTool.sGetSaveValue(stennghenghiep,"nvarchar");
              string tem_stennghenghieptheoboyte=DataAcess.hsSqlTool.sGetSaveValue(stennghenghieptheoboyte,"nvarchar");

 string sqlSave=" UPDATE danhmucnghenghiep SET "+"manghenghiep ="+tem_smanghenghiep+","
 +"tennghenghiep ="+tem_stennghenghiep+","
 +"tennghenghieptheoboyte ="+tem_stennghenghieptheoboyte+" WHERE idnghenghiep="+DataAcess.hsSqlTool.sGetSaveValue(this.idnghenghiep,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.manghenghiep=smanghenghiep;
                this.tennghenghiep=stennghenghiep;
                this.tennghenghieptheoboyte=stennghenghieptheoboyte;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_idnghenghiep(string sidnghenghiep)
{
    string sqlSave= " UPDATE danhmucnghenghiep SET idnghenghiep='"+ sidnghenghiep+ "' WHERE idnghenghiep='"+ this.idnghenghiep+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.idnghenghiep=sidnghenghiep;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_manghenghiep(string smanghenghiep)
{
    string sqlSave= " UPDATE danhmucnghenghiep SET manghenghiep=N'"+ smanghenghiep+ "' WHERE idnghenghiep='"+ this.idnghenghiep+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.manghenghiep=smanghenghiep;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tennghenghiep(string stennghenghiep)
{
    string sqlSave= " UPDATE danhmucnghenghiep SET tennghenghiep=N'"+ stennghenghiep+ "' WHERE idnghenghiep='"+ this.idnghenghiep+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tennghenghiep=stennghenghiep;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tennghenghieptheoboyte(string stennghenghieptheoboyte)
{
    string sqlSave= " UPDATE danhmucnghenghiep SET tennghenghieptheoboyte=N'"+ stennghenghieptheoboyte+ "' WHERE idnghenghiep='"+ this.idnghenghiep+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tennghenghieptheoboyte=stennghenghieptheoboyte;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_manghenghiep(string smanghenghiep,string s_idnghenghiep)
{
    string sqlSave= " UPDATE danhmucnghenghiep SET manghenghiep='N"+smanghenghiep+"' WHERE idnghenghiep='"+ s_idnghenghiep+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tennghenghiep(string stennghenghiep,string s_idnghenghiep)
{
    string sqlSave= " UPDATE danhmucnghenghiep SET tennghenghiep='N"+stennghenghiep+"' WHERE idnghenghiep='"+ s_idnghenghiep+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tennghenghieptheoboyte(string stennghenghieptheoboyte,string s_idnghenghiep)
{
    string sqlSave= " UPDATE danhmucnghenghiep SET tennghenghieptheoboyte='N"+stennghenghieptheoboyte+"' WHERE idnghenghiep='"+ s_idnghenghiep+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM danhmucnghenghiep " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_danhmucnghenghiep;
   public static bool Change_dt_danhmucnghenghiep = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_danhmucnghenghiep()
   {
   if (dt_danhmucnghenghiep == null || Change_dt_danhmucnghenghiep == true)
   {
   dt_danhmucnghenghiep = dtGetAll();
   Change_dt_danhmucnghenghiep = true && AllowAutoChange ;
   }
   return dt_danhmucnghenghiep;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process
  { 
 public class dantoc:  Connect { 
 public static string sTableName= "dantoc"; 
   public string id;
   public string tendantoc;
   #region DataColumn Name ;
 public static  string cl_id="id" ;
 public static  string cl_id_VN="id";
 public static  string cl_tendantoc="tendantoc" ;
 public static  string cl_tendantoc_VN="tendantoc";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public dantoc() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public dantoc(
         string sid,
         string stendantoc){
         this.id= sid;
         this.tendantoc= stendantoc;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static dantoc Create_dantoc ( string sid  ){
    DataTable dt=dtSearchByid(sid) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new dantoc(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM dantoc AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public dantoc( DataView dv,int pos)
{
         this.id= dv[pos][0].ToString();
         this.tendantoc= dv[pos][1].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByid(string sid)
{
          string sqlSelect= s_Select()+ " WHERE id  ="+ sid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByid(string sid,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE id"+ sMatch +sid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytendantoc(string stendantoc)
{
          string sqlSelect= s_Select()+ " WHERE tendantoc  Like N'%"+ stendantoc + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sid
            , string stendantoc
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sid!=null && sid!="") 
            sqlselect +=" AND id =" + sid ;
      if (stendantoc!=null && stendantoc!="") 
            sqlselect +=" AND tendantoc LIKE N'%" + stendantoc +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static dantoc Insert_Object(
string  stendantoc
            ) 
 { 
              string tem_stendantoc=DataAcess.hsSqlTool.sGetSaveValue(stendantoc,"varchar");

             string sqlSave=" INSERT INTO dantoc("+
                   "tendantoc) VALUES("
 +tem_stendantoc +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          dantoc newdantoc= new dantoc();
                 newdantoc.id=GetTable( " SELECT TOP 1 id FROM dantoc ORDER BY id DESC ").Rows[0][0].ToString();
              newdantoc.tendantoc=stendantoc;
            return newdantoc; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string stendantoc
                ) 
 { 
              string tem_stendantoc=DataAcess.hsSqlTool.sGetSaveValue(stendantoc,"varchar");

 string sqlSave=" UPDATE dantoc SET "+"tendantoc ="+tem_stendantoc+" WHERE id="+DataAcess.hsSqlTool.sGetSaveValue(this.id,"bigint identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.tendantoc=stendantoc;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_id(string sid)
{
    string sqlSave= " UPDATE dantoc SET id='"+ sid+ "' WHERE id='"+ this.id+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.id=sid;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tendantoc(string stendantoc)
{
    string sqlSave= " UPDATE dantoc SET tendantoc=N'"+ stendantoc+ "' WHERE id='"+ this.id+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tendantoc=stendantoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_tendantoc(string stendantoc,string s_id)
{
    string sqlSave= " UPDATE dantoc SET tendantoc='N"+stendantoc+"' WHERE id='"+ s_id+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM dantoc " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_dantoc;
   public static bool Change_dt_dantoc = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_dantoc()
   {
   if (dt_dantoc == null || Change_dt_dantoc == true)
   {
   dt_dantoc = dtGetAll();
   Change_dt_dantoc = true && AllowAutoChange ;
   }
   return dt_dantoc;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

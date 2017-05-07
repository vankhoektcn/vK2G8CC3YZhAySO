using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace Process
  { 
 public class quoctich:  Connect { 
 public static string sTableName= "quoctich"; 
   public string idquoctich;
   public string tenquoctich;
   public string maquoctich;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_idquoctich="idquoctich" ;
 public static  string cl_idquoctich_VN="idquoctich";
 public static  string cl_tenquoctich="tenquoctich" ;
 public static  string cl_tenquoctich_VN="tenquoctich";
 public static  string cl_maquoctich="maquoctich" ;
 public static  string cl_maquoctich_VN="maquoctich";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public quoctich() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public quoctich(
         string sidquoctich,
         string stenquoctich,
         string smaquoctich){
         this.idquoctich= sidquoctich;
         this.tenquoctich= stenquoctich;
         this.maquoctich= smaquoctich;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static quoctich Create_quoctich ( string sidquoctich  ){
    DataTable dt=dtSearchByidquoctich(sidquoctich) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new quoctich(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM quoctich AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by idquoctich),T.* FROM quoctich AS T WHERE";
      if (this.tenquoctich!=null && this.tenquoctich!="") 
            sqlselect +=" AND tenquoctich LIKE N'%" + this.tenquoctich +"%'" ;
      if (this.maquoctich!=null && this.maquoctich!="") 
            sqlselect +=" AND maquoctich LIKE N'%" + this.maquoctich +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public quoctich( DataView dv,int pos)
{
         this.idquoctich= dv[pos][0].ToString();
         this.tenquoctich= dv[pos][1].ToString();
         this.maquoctich= dv[pos][2].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidquoctich(string sidquoctich)
{
          string sqlSelect= s_Select()+ " WHERE idquoctich  ="+ sidquoctich + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidquoctich(string sidquoctich,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idquoctich"+ sMatch +sidquoctich + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytenquoctich(string stenquoctich)
{
          string sqlSelect= s_Select()+ " WHERE tenquoctich  Like N'%"+ stenquoctich + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBymaquoctich(string smaquoctich)
{
          string sqlSelect= s_Select()+ " WHERE maquoctich  Like N'%"+ smaquoctich + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sidquoctich
            , string stenquoctich
            , string smaquoctich
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sidquoctich!=null && sidquoctich!="") 
            sqlselect +=" AND idquoctich =" + sidquoctich ;
      if (stenquoctich!=null && stenquoctich!="") 
            sqlselect +=" AND tenquoctich LIKE N'%" + stenquoctich +"%'" ;
      if (smaquoctich!=null && smaquoctich!="") 
            sqlselect +=" AND maquoctich LIKE N'%" + smaquoctich +"%'" ;
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
 public static quoctich Insert_Object(
string  stenquoctich
            ,string  smaquoctich
            ) 
 { 
              string tem_stenquoctich=DataAcess.hsSqlTool.sGetSaveValue(stenquoctich,"nvarchar");
              string tem_smaquoctich=DataAcess.hsSqlTool.sGetSaveValue(smaquoctich,"varchar");

             string sqlSave=" INSERT INTO quoctich("+
                   "tenquoctich," 
        +                   "maquoctich) VALUES("
 +tem_stenquoctich+","
 +tem_smaquoctich +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          quoctich newquoctich= new quoctich();
                 newquoctich.idquoctich=GetTable( " SELECT TOP 1 idquoctich FROM quoctich ORDER BY idquoctich DESC ").Rows[0][0].ToString();
              newquoctich.tenquoctich=stenquoctich;
              newquoctich.maquoctich=smaquoctich;
            return newquoctich; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public quoctich Insert_Object() { 
              string tem_stenquoctich=DataAcess.hsSqlTool.sGetSaveValue(this.tenquoctich,"nvarchar");
              string tem_smaquoctich=DataAcess.hsSqlTool.sGetSaveValue(this.maquoctich,"varchar");

             string sqlSave=" INSERT INTO quoctich("+
                   "tenquoctich," 
        +                   "maquoctich) VALUES("
 +tem_stenquoctich+","
 +tem_smaquoctich +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          quoctich newquoctich= new quoctich();
                 newquoctich.idquoctich=GetTable( " SELECT TOP 1 idquoctich FROM quoctich ORDER BY idquoctich DESC ").Rows[0][0].ToString();
              newquoctich.tenquoctich=this.tenquoctich;
              newquoctich.maquoctich=this.maquoctich;
            return newquoctich; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string stenquoctich
                ,string smaquoctich
                ) 
 { 
              string tem_stenquoctich=DataAcess.hsSqlTool.sGetSaveValue(stenquoctich,"nvarchar");
              string tem_smaquoctich=DataAcess.hsSqlTool.sGetSaveValue(smaquoctich,"varchar");

 string sqlSave=" UPDATE quoctich SET "+"tenquoctich ="+tem_stenquoctich+","
 +"maquoctich ="+tem_smaquoctich+" WHERE idquoctich="+DataAcess.hsSqlTool.sGetSaveValue(this.idquoctich,"int identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.tenquoctich=stenquoctich;
                this.maquoctich=smaquoctich;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_stenquoctich=DataAcess.hsSqlTool.sGetSaveValue(this.tenquoctich,"nvarchar");
              string tem_smaquoctich=DataAcess.hsSqlTool.sGetSaveValue(this.maquoctich,"varchar");

 string sqlSave=" UPDATE quoctich SET ";
if(tem_stenquoctich != null)
 sqlSave+="tenquoctich ="+tem_stenquoctich+",";
if(tem_smaquoctich != null)
 sqlSave+="maquoctich ="+tem_smaquoctich+",";
sqlSave+=" WHERE idquoctich="+DataAcess.hsSqlTool.sGetSaveValue(this.idquoctich,"int identity");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_idquoctich(string sidquoctich)
{
    string sqlSave= " UPDATE quoctich SET idquoctich='"+ sidquoctich+ "' WHERE idquoctich='"+ this.idquoctich+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.idquoctich=sidquoctich;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tenquoctich(string stenquoctich)
{
    string sqlSave= " UPDATE quoctich SET tenquoctich='N"+ stenquoctich+ "' WHERE idquoctich='"+ this.idquoctich+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.tenquoctich=stenquoctich;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_maquoctich(string smaquoctich)
{
    string sqlSave= " UPDATE quoctich SET maquoctich='N"+ smaquoctich+ "' WHERE idquoctich='"+ this.idquoctich+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.maquoctich=smaquoctich;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_tenquoctich(string stenquoctich,string s_idquoctich)
{
    string sqlSave= " UPDATE quoctich SET tenquoctich='N"+stenquoctich+"' WHERE idquoctich='"+ s_idquoctich+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_maquoctich(string smaquoctich,string s_idquoctich)
{
    string sqlSave= " UPDATE quoctich SET maquoctich='N"+smaquoctich+"' WHERE idquoctich='"+ s_idquoctich+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM quoctich " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_quoctich;
   public static bool Change_dt_quoctich = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_quoctich()
   {
   if (dt_quoctich == null || Change_dt_quoctich == true)
   {
   dt_quoctich = dtGetAll();
   Change_dt_quoctich = true && AllowAutoChange ;
   }
   return dt_quoctich;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

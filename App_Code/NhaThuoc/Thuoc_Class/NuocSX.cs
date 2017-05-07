using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace Process_2608
  { 
 public class NuocSX:  Connect { 
 public static string sTableName= "NuocSX"; 
   public string idNuocSX;
   public string maNuocSX;
   public string tenNuocSX;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_idNuocSX="idNuocSX" ;
 public static  string cl_idNuocSX_VN="idNuocSX";
 public static  string cl_maNuocSX="maNuocSX" ;
 public static  string cl_maNuocSX_VN="maNuocSX";
 public static  string cl_tenNuocSX="tenNuocSX" ;
 public static  string cl_tenNuocSX_VN="tenNuocSX";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public NuocSX() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public NuocSX(
         string sidNuocSX,
         string smaNuocSX,
         string stenNuocSX){
         this.idNuocSX= sidNuocSX;
         this.maNuocSX= smaNuocSX;
         this.tenNuocSX= stenNuocSX;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static NuocSX Create_NuocSX ( string sidNuocSX  ){
    DataTable dt=dtSearchByidNuocSX(sidNuocSX) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new NuocSX(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM NuocSX AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by idNuocSX),T.* FROM NuocSX AS T WHERE";
      if (this.maNuocSX!=null && this.maNuocSX!="") 
            sqlselect +=" AND maNuocSX LIKE N'%" + this.maNuocSX +"%'" ;
      if (this.tenNuocSX!=null && this.tenNuocSX!="") 
            sqlselect +=" AND tenNuocSX LIKE N'%" + this.tenNuocSX +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public NuocSX( DataView dv,int pos)
{
         this.idNuocSX= dv[pos][0].ToString();
         this.maNuocSX= dv[pos][1].ToString();
         this.tenNuocSX= dv[pos][2].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidNuocSX(string sidNuocSX)
{
          string sqlSelect= s_Select()+ " WHERE idNuocSX  ="+ sidNuocSX + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidNuocSX(string sidNuocSX,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idNuocSX"+ sMatch +sidNuocSX + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBymaNuocSX(string smaNuocSX)
{
          string sqlSelect= s_Select()+ " WHERE maNuocSX  Like N'%"+ smaNuocSX + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytenNuocSX(string stenNuocSX)
{
          string sqlSelect= s_Select()+ " WHERE tenNuocSX  Like N'%"+ stenNuocSX + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sidNuocSX
            , string smaNuocSX
            , string stenNuocSX
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sidNuocSX!=null && sidNuocSX!="") 
            sqlselect +=" AND idNuocSX =" + sidNuocSX ;
      if (smaNuocSX!=null && smaNuocSX!="") 
            sqlselect +=" AND maNuocSX LIKE N'%" + smaNuocSX +"%'" ;
      if (stenNuocSX!=null && stenNuocSX!="") 
            sqlselect +=" AND tenNuocSX LIKE N'%" + stenNuocSX +"%'" ;
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
 public static NuocSX Insert_Object(
string  sidNuocSX
            ,string  smaNuocSX
            ,string  stenNuocSX
            ) 
 { 
              string tem_sidNuocSX=DataAcess.hsSqlTool.sGetSaveValue(sidNuocSX,"int");
              string tem_smaNuocSX=DataAcess.hsSqlTool.sGetSaveValue(smaNuocSX,"nvarchar");
              string tem_stenNuocSX=DataAcess.hsSqlTool.sGetSaveValue(stenNuocSX,"nvarchar");

             string sqlSave=" INSERT INTO NuocSX("+
                   "idNuocSX," 
        +                   "maNuocSX," 
        +                   "tenNuocSX) VALUES("
 +tem_sidNuocSX+","
 +tem_smaNuocSX+","
 +tem_stenNuocSX +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          NuocSX newNuocSX= new NuocSX();
              newNuocSX.idNuocSX=sidNuocSX;
              newNuocSX.maNuocSX=smaNuocSX;
              newNuocSX.tenNuocSX=stenNuocSX;
            return newNuocSX; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public NuocSX Insert_Object() { 
              string tem_sidNuocSX=(GetTable( " SELECT idNuocSX FROM NuocSX").Rows.Count + 1)+"";
              string tem_smaNuocSX=DataAcess.hsSqlTool.sGetSaveValue(this.maNuocSX,"nvarchar");
              string tem_stenNuocSX=DataAcess.hsSqlTool.sGetSaveValue(this.tenNuocSX,"nvarchar");

             string sqlSave=" INSERT INTO NuocSX("+
                   "idNuocSX," 
        +                   "maNuocSX," 
        +                   "tenNuocSX) VALUES("
 +tem_sidNuocSX+","
 +tem_smaNuocSX+","
 +tem_stenNuocSX +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          NuocSX newNuocSX= new NuocSX();
              newNuocSX.idNuocSX=this.idNuocSX;
              newNuocSX.maNuocSX=this.maNuocSX;
              newNuocSX.tenNuocSX=this.tenNuocSX;
            return newNuocSX; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sidNuocSX
                ,string smaNuocSX
                ,string stenNuocSX
                ) 
 { 
              string tem_smaNuocSX=DataAcess.hsSqlTool.sGetSaveValue(smaNuocSX,"nvarchar");
              string tem_stenNuocSX=DataAcess.hsSqlTool.sGetSaveValue(stenNuocSX,"nvarchar");

 string sqlSave=" UPDATE NuocSX SET "+"maNuocSX ="+tem_smaNuocSX+","
 +"tenNuocSX ="+tem_stenNuocSX+" WHERE idNuocSX="+DataAcess.hsSqlTool.sGetSaveValue(this.idNuocSX,"int");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.maNuocSX=smaNuocSX;
                this.tenNuocSX=stenNuocSX;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_smaNuocSX=DataAcess.hsSqlTool.sGetSaveValue(this.maNuocSX,"nvarchar");
              string tem_stenNuocSX=DataAcess.hsSqlTool.sGetSaveValue(this.tenNuocSX,"nvarchar");

 string sqlSave=" UPDATE NuocSX SET ";
if(tem_smaNuocSX != null)
 sqlSave+="maNuocSX ="+tem_smaNuocSX+",";
if(tem_stenNuocSX != null)
 sqlSave+="tenNuocSX ="+tem_stenNuocSX+",";
sqlSave+=" WHERE idNuocSX="+DataAcess.hsSqlTool.sGetSaveValue(this.idNuocSX,"int");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_idNuocSX(string sidNuocSX)
{
    string sqlSave= " UPDATE NuocSX SET idNuocSX='"+ sidNuocSX+ "' WHERE idNuocSX='"+ this.idNuocSX+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.idNuocSX=sidNuocSX;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_maNuocSX(string smaNuocSX)
{
    string sqlSave= " UPDATE NuocSX SET maNuocSX='N"+ smaNuocSX+ "' WHERE idNuocSX='"+ this.idNuocSX+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.maNuocSX=smaNuocSX;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tenNuocSX(string stenNuocSX)
{
    string sqlSave= " UPDATE NuocSX SET tenNuocSX='N"+ stenNuocSX+ "' WHERE idNuocSX='"+ this.idNuocSX+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.tenNuocSX=stenNuocSX;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_idNuocSX(string sidNuocSX,string s_idNuocSX)
{
    string sqlSave= " UPDATE NuocSX SET idNuocSX='"+sidNuocSX+"' WHERE idNuocSX='"+ s_idNuocSX+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_maNuocSX(string smaNuocSX,string s_idNuocSX)
{
    string sqlSave= " UPDATE NuocSX SET maNuocSX='N"+smaNuocSX+"' WHERE idNuocSX='"+ s_idNuocSX+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tenNuocSX(string stenNuocSX,string s_idNuocSX)
{
    string sqlSave= " UPDATE NuocSX SET tenNuocSX='N"+stenNuocSX+"' WHERE idNuocSX='"+ s_idNuocSX+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM NuocSX " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_NuocSX;
   public static bool Change_dt_NuocSX = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_NuocSX()
   {
   if (dt_NuocSX == null || Change_dt_NuocSX == true)
   {
   dt_NuocSX = dtGetAll();
   Change_dt_NuocSX = true && AllowAutoChange ;
   }
   return dt_NuocSX;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

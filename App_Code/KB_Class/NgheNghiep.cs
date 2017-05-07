using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace Process
  { 
 public class NgheNghiep:  Connect { 
 public static string sTableName= "NgheNghiep"; 
   public string idNgheNghiep;
   public string MaNgheNghiep;
   public string TenNgheNghiep;
   public string tennghenghieptheoboyte;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_idNgheNghiep="idNgheNghiep" ;
 public static  string cl_idNgheNghiep_VN="idNgheNghiep";
 public static  string cl_MaNgheNghiep="MaNgheNghiep" ;
 public static  string cl_MaNgheNghiep_VN="MaNgheNghiep";
 public static  string cl_TenNgheNghiep="TenNgheNghiep" ;
 public static  string cl_TenNgheNghiep_VN="TenNgheNghiep";
 public static  string cl_tennghenghieptheoboyte="tennghenghieptheoboyte" ;
 public static  string cl_tennghenghieptheoboyte_VN="tennghenghieptheoboyte";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public NgheNghiep() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public NgheNghiep(
         string sidNgheNghiep,
         string sMaNgheNghiep,
         string sTenNgheNghiep,
         string stennghenghieptheoboyte){
         this.idNgheNghiep= sidNgheNghiep;
         this.MaNgheNghiep= sMaNgheNghiep;
         this.TenNgheNghiep= sTenNgheNghiep;
         this.tennghenghieptheoboyte= stennghenghieptheoboyte;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static NgheNghiep Create_NgheNghiep ( string sidNgheNghiep  ){
    DataTable dt=dtSearchByidNgheNghiep(sidNgheNghiep) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new NgheNghiep(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM NgheNghiep AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by idNgheNghiep),T.* FROM NgheNghiep AS T WHERE";
      if (this.MaNgheNghiep!=null && this.MaNgheNghiep!="") 
            sqlselect +=" AND MaNgheNghiep LIKE N'%" + this.MaNgheNghiep +"%'" ;
      if (this.TenNgheNghiep!=null && this.TenNgheNghiep!="") 
            sqlselect +=" AND TenNgheNghiep LIKE N'%" + this.TenNgheNghiep +"%'" ;
      if (this.tennghenghieptheoboyte!=null && this.tennghenghieptheoboyte!="") 
            sqlselect +=" AND tennghenghieptheoboyte LIKE N'%" + this.tennghenghieptheoboyte +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public NgheNghiep( DataView dv,int pos)
{
         this.idNgheNghiep= dv[pos][0].ToString();
         this.MaNgheNghiep= dv[pos][1].ToString();
         this.TenNgheNghiep= dv[pos][2].ToString();
         this.tennghenghieptheoboyte= dv[pos][3].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidNgheNghiep(string sidNgheNghiep)
{
          string sqlSelect= s_Select()+ " WHERE idNgheNghiep  ="+ sidNgheNghiep + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidNgheNghiep(string sidNgheNghiep,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idNgheNghiep"+ sMatch +sidNgheNghiep + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByMaNgheNghiep(string sMaNgheNghiep)
{
          string sqlSelect= s_Select()+ " WHERE MaNgheNghiep  Like N'%"+ sMaNgheNghiep + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTenNgheNghiep(string sTenNgheNghiep)
{
          string sqlSelect= s_Select()+ " WHERE TenNgheNghiep  Like N'%"+ sTenNgheNghiep + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytennghenghieptheoboyte(string stennghenghieptheoboyte)
{
          string sqlSelect= s_Select()+ " WHERE tennghenghieptheoboyte  Like N'%"+ stennghenghieptheoboyte + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sidNgheNghiep
            , string sMaNgheNghiep
            , string sTenNgheNghiep
            , string stennghenghieptheoboyte
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sidNgheNghiep!=null && sidNgheNghiep!="") 
            sqlselect +=" AND idNgheNghiep =" + sidNgheNghiep ;
      if (sMaNgheNghiep!=null && sMaNgheNghiep!="") 
            sqlselect +=" AND MaNgheNghiep LIKE N'%" + sMaNgheNghiep +"%'" ;
      if (sTenNgheNghiep!=null && sTenNgheNghiep!="") 
            sqlselect +=" AND TenNgheNghiep LIKE N'%" + sTenNgheNghiep +"%'" ;
      if (stennghenghieptheoboyte!=null && stennghenghieptheoboyte!="") 
            sqlselect +=" AND tennghenghieptheoboyte LIKE N'%" + stennghenghieptheoboyte +"%'" ;
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
 public static NgheNghiep Insert_Object(
string  sMaNgheNghiep
            ,string  sTenNgheNghiep
            ,string  stennghenghieptheoboyte
            ) 
 { 
              string tem_sMaNgheNghiep=DataAcess.hsSqlTool.sGetSaveValue(sMaNgheNghiep,"nvarchar");
              string tem_sTenNgheNghiep=DataAcess.hsSqlTool.sGetSaveValue(sTenNgheNghiep,"nvarchar");
              string tem_stennghenghieptheoboyte=DataAcess.hsSqlTool.sGetSaveValue(stennghenghieptheoboyte,"nvarchar");

             string sqlSave=" INSERT INTO NgheNghiep("+
                   "MaNgheNghiep," 
        +                   "TenNgheNghiep," 
        +                   "tennghenghieptheoboyte) VALUES("
 +tem_sMaNgheNghiep+","
 +tem_sTenNgheNghiep+","
 +tem_stennghenghieptheoboyte +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          NgheNghiep newNgheNghiep= new NgheNghiep();
                 newNgheNghiep.idNgheNghiep=GetTable( " SELECT TOP 1 idNgheNghiep FROM NgheNghiep ORDER BY idNgheNghiep DESC ").Rows[0][0].ToString();
              newNgheNghiep.MaNgheNghiep=sMaNgheNghiep;
              newNgheNghiep.TenNgheNghiep=sTenNgheNghiep;
              newNgheNghiep.tennghenghieptheoboyte=stennghenghieptheoboyte;
            return newNgheNghiep; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public NgheNghiep Insert_Object() { 
              string tem_sMaNgheNghiep=DataAcess.hsSqlTool.sGetSaveValue(this.MaNgheNghiep,"nvarchar");
              string tem_sTenNgheNghiep=DataAcess.hsSqlTool.sGetSaveValue(this.TenNgheNghiep,"nvarchar");
              string tem_stennghenghieptheoboyte=DataAcess.hsSqlTool.sGetSaveValue(this.tennghenghieptheoboyte,"nvarchar");

             string sqlSave=" INSERT INTO NgheNghiep("+
                   "MaNgheNghiep," 
        +                   "TenNgheNghiep," 
        +                   "tennghenghieptheoboyte) VALUES("
 +tem_sMaNgheNghiep+","
 +tem_sTenNgheNghiep+","
 +tem_stennghenghieptheoboyte +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          NgheNghiep newNgheNghiep= new NgheNghiep();
                 newNgheNghiep.idNgheNghiep=GetTable( " SELECT TOP 1 idNgheNghiep FROM NgheNghiep ORDER BY idNgheNghiep DESC ").Rows[0][0].ToString();
              newNgheNghiep.MaNgheNghiep=this.MaNgheNghiep;
              newNgheNghiep.TenNgheNghiep=this.TenNgheNghiep;
              newNgheNghiep.tennghenghieptheoboyte=this.tennghenghieptheoboyte;
            return newNgheNghiep; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sMaNgheNghiep
                ,string sTenNgheNghiep
                ,string stennghenghieptheoboyte
                ) 
 { 
              string tem_sMaNgheNghiep=DataAcess.hsSqlTool.sGetSaveValue(sMaNgheNghiep,"nvarchar");
              string tem_sTenNgheNghiep=DataAcess.hsSqlTool.sGetSaveValue(sTenNgheNghiep,"nvarchar");
              string tem_stennghenghieptheoboyte=DataAcess.hsSqlTool.sGetSaveValue(stennghenghieptheoboyte,"nvarchar");

 string sqlSave=" UPDATE NgheNghiep SET "+"MaNgheNghiep ="+tem_sMaNgheNghiep+","
 +"TenNgheNghiep ="+tem_sTenNgheNghiep+","
 +"tennghenghieptheoboyte ="+tem_stennghenghieptheoboyte+" WHERE idNgheNghiep="+DataAcess.hsSqlTool.sGetSaveValue(this.idNgheNghiep,"int identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.MaNgheNghiep=sMaNgheNghiep;
                this.TenNgheNghiep=sTenNgheNghiep;
                this.tennghenghieptheoboyte=stennghenghieptheoboyte;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_sMaNgheNghiep=DataAcess.hsSqlTool.sGetSaveValue(this.MaNgheNghiep,"nvarchar");
              string tem_sTenNgheNghiep=DataAcess.hsSqlTool.sGetSaveValue(this.TenNgheNghiep,"nvarchar");
              string tem_stennghenghieptheoboyte=DataAcess.hsSqlTool.sGetSaveValue(this.tennghenghieptheoboyte,"nvarchar");

 string sqlSave=" UPDATE NgheNghiep SET ";
if(tem_sMaNgheNghiep != null)
 sqlSave+="MaNgheNghiep ="+tem_sMaNgheNghiep+",";
if(tem_sTenNgheNghiep != null)
 sqlSave+="TenNgheNghiep ="+tem_sTenNgheNghiep+",";
if(tem_stennghenghieptheoboyte != null)
 sqlSave+="tennghenghieptheoboyte ="+tem_stennghenghieptheoboyte+",";
sqlSave+=" WHERE idNgheNghiep="+DataAcess.hsSqlTool.sGetSaveValue(this.idNgheNghiep,"int identity");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_idNgheNghiep(string sidNgheNghiep)
{
    string sqlSave= " UPDATE NgheNghiep SET idNgheNghiep='"+ sidNgheNghiep+ "' WHERE idNgheNghiep='"+ this.idNgheNghiep+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.idNgheNghiep=sidNgheNghiep;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MaNgheNghiep(string sMaNgheNghiep)
{
    string sqlSave= " UPDATE NgheNghiep SET MaNgheNghiep='N"+ sMaNgheNghiep+ "' WHERE idNgheNghiep='"+ this.idNgheNghiep+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MaNgheNghiep=sMaNgheNghiep;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TenNgheNghiep(string sTenNgheNghiep)
{
    string sqlSave= " UPDATE NgheNghiep SET TenNgheNghiep='N"+ sTenNgheNghiep+ "' WHERE idNgheNghiep='"+ this.idNgheNghiep+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TenNgheNghiep=sTenNgheNghiep;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tennghenghieptheoboyte(string stennghenghieptheoboyte)
{
    string sqlSave= " UPDATE NgheNghiep SET tennghenghieptheoboyte='N"+ stennghenghieptheoboyte+ "' WHERE idNgheNghiep='"+ this.idNgheNghiep+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.tennghenghieptheoboyte=stennghenghieptheoboyte;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_MaNgheNghiep(string sMaNgheNghiep,string s_idNgheNghiep)
{
    string sqlSave= " UPDATE NgheNghiep SET MaNgheNghiep='N"+sMaNgheNghiep+"' WHERE idNgheNghiep='"+ s_idNgheNghiep+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TenNgheNghiep(string sTenNgheNghiep,string s_idNgheNghiep)
{
    string sqlSave= " UPDATE NgheNghiep SET TenNgheNghiep='N"+sTenNgheNghiep+"' WHERE idNgheNghiep='"+ s_idNgheNghiep+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tennghenghieptheoboyte(string stennghenghieptheoboyte,string s_idNgheNghiep)
{
    string sqlSave= " UPDATE NgheNghiep SET tennghenghieptheoboyte='N"+stennghenghieptheoboyte+"' WHERE idNgheNghiep='"+ s_idNgheNghiep+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM NgheNghiep " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_NgheNghiep;
   public static bool Change_dt_NgheNghiep = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_NgheNghiep()
   {
   if (dt_NgheNghiep == null || Change_dt_NgheNghiep == true)
   {
   dt_NgheNghiep = dtGetAll();
   Change_dt_NgheNghiep = true && AllowAutoChange ;
   }
   return dt_NgheNghiep;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

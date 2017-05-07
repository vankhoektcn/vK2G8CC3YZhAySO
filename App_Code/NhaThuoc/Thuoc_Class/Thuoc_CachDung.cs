using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process_2608
  { 
 public class Thuoc_CachDung:  Connect { 
 public static string sTableName= "Thuoc_CachDung"; 
   public string idcachdung;
   public string tencachdung;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_idcachdung="idcachdung" ;
 public static  string cl_idcachdung_VN="idcachdung";
 public static  string cl_tencachdung="tencachdung" ;
 public static  string cl_tencachdung_VN="tencachdung";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public Thuoc_CachDung() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public Thuoc_CachDung(
         string sidcachdung,
         string stencachdung){
         this.idcachdung= sidcachdung;
         this.tencachdung= stencachdung;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static Thuoc_CachDung Create_Thuoc_CachDung ( string sidcachdung  ){
    DataTable dt=dtSearchByidcachdung(sidcachdung) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new Thuoc_CachDung(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM Thuoc_CachDung AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by idcachdung),T.* FROM Thuoc_CachDung AS T WHERE";
      if (this.tencachdung!=null && this.tencachdung!="") 
            sqlselect +=" AND tencachdung LIKE N'%" + this.tencachdung +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public Thuoc_CachDung( DataView dv,int pos)
{
         this.idcachdung= dv[pos][0].ToString();
         this.tencachdung= dv[pos][1].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidcachdung(string sidcachdung)
{
          string sqlSelect= s_Select()+ " WHERE idcachdung  ="+ sidcachdung + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByidcachdung(string sidcachdung,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE idcachdung"+ sMatch +sidcachdung + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytencachdung(string stencachdung)
{
          string sqlSelect= s_Select()+ " WHERE tencachdung  Like N'%"+ stencachdung + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sidcachdung
            , string stencachdung
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sidcachdung!=null && sidcachdung!="") 
            sqlselect +=" AND idcachdung =" + sidcachdung ;
      if (stencachdung!=null && stencachdung!="") 
            sqlselect +=" AND tencachdung LIKE N'%" + stencachdung +"%'" ;
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
 public static Thuoc_CachDung Insert_Object(
string  stencachdung
            ) 
 { 
              string tem_stencachdung=DataAcess.hsSqlTool.sGetSaveValue(stencachdung,"nvarchar");

             string sqlSave=" INSERT INTO Thuoc_CachDung("+
                   "tencachdung) VALUES("
 +tem_stencachdung +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          Thuoc_CachDung newThuoc_CachDung= new Thuoc_CachDung();
                 newThuoc_CachDung.idcachdung=GetTable( " SELECT TOP 1 idcachdung FROM Thuoc_CachDung ORDER BY idcachdung DESC ").Rows[0][0].ToString();
              newThuoc_CachDung.tencachdung=stencachdung;
            return newThuoc_CachDung; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public Thuoc_CachDung Insert_Object() { 
              string tem_stencachdung=DataAcess.hsSqlTool.sGetSaveValue(this.tencachdung,"nvarchar");

             string sqlSave=" INSERT INTO Thuoc_CachDung("+
                   "tencachdung) VALUES("
 +tem_stencachdung +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          Thuoc_CachDung newThuoc_CachDung= new Thuoc_CachDung();
                 newThuoc_CachDung.idcachdung=GetTable( " SELECT TOP 1 idcachdung FROM Thuoc_CachDung ORDER BY idcachdung DESC ").Rows[0][0].ToString();
              newThuoc_CachDung.tencachdung=this.tencachdung;
            return newThuoc_CachDung; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string stencachdung
                ) 
 { 
              string tem_stencachdung=DataAcess.hsSqlTool.sGetSaveValue(stencachdung,"nvarchar");

 string sqlSave=" UPDATE Thuoc_CachDung SET "+"tencachdung ="+tem_stencachdung+" WHERE idcachdung="+DataAcess.hsSqlTool.sGetSaveValue(this.idcachdung,"int identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.tencachdung=stencachdung;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_stencachdung=DataAcess.hsSqlTool.sGetSaveValue(this.tencachdung,"nvarchar");

 string sqlSave=" UPDATE Thuoc_CachDung SET ";
if(tem_stencachdung != null)
 sqlSave+="tencachdung ="+tem_stencachdung+",";
sqlSave+=" WHERE idcachdung="+DataAcess.hsSqlTool.sGetSaveValue(this.idcachdung,"int identity");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_idcachdung(string sidcachdung)
{
    string sqlSave= " UPDATE Thuoc_CachDung SET idcachdung='"+ sidcachdung+ "' WHERE idcachdung='"+ this.idcachdung+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.idcachdung=sidcachdung;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tencachdung(string stencachdung)
{
    string sqlSave= " UPDATE Thuoc_CachDung SET tencachdung='N"+ stencachdung+ "' WHERE idcachdung='"+ this.idcachdung+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.tencachdung=stencachdung;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_tencachdung(string stencachdung,string s_idcachdung)
{
    string sqlSave= " UPDATE Thuoc_CachDung SET tencachdung='N"+stencachdung+"' WHERE idcachdung='"+ s_idcachdung+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM Thuoc_CachDung " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_Thuoc_CachDung;
   public static bool Change_dt_Thuoc_CachDung = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_Thuoc_CachDung()
   {
   if (dt_Thuoc_CachDung == null || Change_dt_Thuoc_CachDung == true)
   {
   dt_Thuoc_CachDung = dtGetAll();
   Change_dt_Thuoc_CachDung = true && AllowAutoChange ;
   }
   return dt_Thuoc_CachDung;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
 namespace Process
  { 
 public class Thuoc_LoaiThuoc:  Connect { 
 public static string sTableName= "Thuoc_LoaiThuoc"; 
   public string LoaiThuocID;
   public string MaLoai;
   public string TenLoai;
   public string Status;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_LoaiThuocID="LoaiThuocID" ;
 public static  string cl_LoaiThuocID_VN="LoaiThuocID";
 public static  string cl_MaLoai="MaLoai" ;
 public static  string cl_MaLoai_VN="MaLoai";
 public static  string cl_TenLoai="TenLoai" ;
 public static  string cl_TenLoai_VN="TenLoai";
 public static  string cl_Status="Status" ;
 public static  string cl_Status_VN="Status";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public Thuoc_LoaiThuoc() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public Thuoc_LoaiThuoc(
         string sLoaiThuocID,
         string sMaLoai,
         string sTenLoai,
         string sStatus){
         this.LoaiThuocID= sLoaiThuocID;
         this.MaLoai= sMaLoai;
         this.TenLoai= sTenLoai;
         this.Status= sStatus;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static Thuoc_LoaiThuoc Create_Thuoc_LoaiThuoc ( string sLoaiThuocID  ){
    DataTable dt=dtSearchByLoaiThuocID(sLoaiThuocID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new Thuoc_LoaiThuoc(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM Thuoc_LoaiThuoc AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by LoaiThuocID),T.* FROM Thuoc_LoaiThuoc AS T WHERE";
      if (this.MaLoai!=null && this.MaLoai!="") 
            sqlselect +=" AND MaLoai LIKE N'%" + this.MaLoai +"%'" ;
      if (this.TenLoai!=null && this.TenLoai!="") 
            sqlselect +=" AND TenLoai LIKE N'%" + this.TenLoai +"%'" ;
      if (this.Status!=null && this.Status!="") 
            sqlselect +=" AND Status ='" + this.Status+"'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public Thuoc_LoaiThuoc( DataView dv,int pos)
{
         this.LoaiThuocID= dv[pos][0].ToString();
         this.MaLoai= dv[pos][1].ToString();
         this.TenLoai= dv[pos][2].ToString();
         this.Status= dv[pos][3].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
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
 public static DataTable dtSearchByMaLoai(string sMaLoai)
{
          string sqlSelect= s_Select()+ " WHERE MaLoai  Like N'%"+ sMaLoai + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTenLoai(string sTenLoai)
{
          string sqlSelect= s_Select()+ " WHERE TenLoai  Like N'%"+ sTenLoai + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByStatus(string sStatus)
{
          string sqlSelect= s_Select()+ " WHERE Status  ="+ sStatus + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByStatus(string sStatus,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE Status"+ sMatch +sStatus + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sLoaiThuocID
            , string sMaLoai
            , string sTenLoai
            , string sStatus
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sLoaiThuocID!=null && sLoaiThuocID!="") 
            sqlselect +=" AND LoaiThuocID =" + sLoaiThuocID ;
      if (sMaLoai!=null && sMaLoai!="") 
            sqlselect +=" AND MaLoai LIKE N'%" + sMaLoai +"%'" ;
      if (sTenLoai!=null && sTenLoai!="") 
            sqlselect +=" AND TenLoai LIKE N'%" + sTenLoai +"%'" ;
      if (sStatus!=null && sStatus!="") 
            sqlselect +=" AND Status =" + sStatus ;
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
 public static Thuoc_LoaiThuoc Insert_Object(
string  sLoaiThuocID
            ,string  sMaLoai
            ,string  sTenLoai
            ,string  sStatus
            ) 
 { 
              string tem_sLoaiThuocID=DataAcess.hsSqlTool.sGetSaveValue(sLoaiThuocID,"bigint");
              string tem_sMaLoai=DataAcess.hsSqlTool.sGetSaveValue(sMaLoai,"nvarchar");
              string tem_sTenLoai=DataAcess.hsSqlTool.sGetSaveValue(sTenLoai,"nvarchar");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(sStatus,"bit");

             string sqlSave=" INSERT INTO Thuoc_LoaiThuoc("+
                   "LoaiThuocID," 
        +                   "MaLoai," 
        +                   "TenLoai," 
        +                   "Status) VALUES("
 +tem_sLoaiThuocID+","
 +tem_sMaLoai+","
 +tem_sTenLoai+","
 +tem_sStatus +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          Thuoc_LoaiThuoc newThuoc_LoaiThuoc= new Thuoc_LoaiThuoc();
              newThuoc_LoaiThuoc.LoaiThuocID=sLoaiThuocID;
              newThuoc_LoaiThuoc.MaLoai=sMaLoai;
              newThuoc_LoaiThuoc.TenLoai=sTenLoai;
              newThuoc_LoaiThuoc.Status=sStatus;
            return newThuoc_LoaiThuoc; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public Thuoc_LoaiThuoc Insert_Object() { 
              string tem_sLoaiThuocID=(GetTable( " SELECT LoaiThuocID FROM Thuoc_LoaiThuoc").Rows.Count + 1)+"";
              string tem_sMaLoai=DataAcess.hsSqlTool.sGetSaveValue(this.MaLoai,"nvarchar");
              string tem_sTenLoai=DataAcess.hsSqlTool.sGetSaveValue(this.TenLoai,"nvarchar");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(this.Status,"bit");

             string sqlSave=" INSERT INTO Thuoc_LoaiThuoc("+
                   "LoaiThuocID," 
        +                   "MaLoai," 
        +                   "TenLoai," 
        +                   "Status) VALUES("
 +tem_sLoaiThuocID+","
 +tem_sMaLoai+","
 +tem_sTenLoai+","
 +tem_sStatus +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          Thuoc_LoaiThuoc newThuoc_LoaiThuoc= new Thuoc_LoaiThuoc();
              newThuoc_LoaiThuoc.LoaiThuocID=this.LoaiThuocID;
              newThuoc_LoaiThuoc.MaLoai=this.MaLoai;
              newThuoc_LoaiThuoc.TenLoai=this.TenLoai;
              newThuoc_LoaiThuoc.Status=this.Status;
            return newThuoc_LoaiThuoc; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sLoaiThuocID
                ,string sMaLoai
                ,string sTenLoai
                ,string sStatus
                ) 
 { 
              string tem_sMaLoai=DataAcess.hsSqlTool.sGetSaveValue(sMaLoai,"nvarchar");
              string tem_sTenLoai=DataAcess.hsSqlTool.sGetSaveValue(sTenLoai,"nvarchar");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(sStatus,"bit");

 string sqlSave=" UPDATE Thuoc_LoaiThuoc SET "+"MaLoai ="+tem_sMaLoai+","
 +"TenLoai ="+tem_sTenLoai+","
 +"Status ="+tem_sStatus+" WHERE LoaiThuocID="+DataAcess.hsSqlTool.sGetSaveValue(this.LoaiThuocID,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.MaLoai=sMaLoai;
                this.TenLoai=sTenLoai;
                this.Status=sStatus;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_sMaLoai=DataAcess.hsSqlTool.sGetSaveValue(this.MaLoai,"nvarchar");
              string tem_sTenLoai=DataAcess.hsSqlTool.sGetSaveValue(this.TenLoai,"nvarchar");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(this.Status,"bit");

 string sqlSave=" UPDATE Thuoc_LoaiThuoc SET ";
if(tem_sMaLoai != null)
 sqlSave+="MaLoai ="+tem_sMaLoai+",";
if(tem_sTenLoai != null)
 sqlSave+="TenLoai ="+tem_sTenLoai+",";
if(tem_sStatus != null)
 sqlSave+="Status ="+tem_sStatus+",";
sqlSave+=" WHERE LoaiThuocID="+DataAcess.hsSqlTool.sGetSaveValue(this.LoaiThuocID,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_LoaiThuocID(string sLoaiThuocID)
{
    string sqlSave= " UPDATE Thuoc_LoaiThuoc SET LoaiThuocID='"+ sLoaiThuocID+ "' WHERE LoaiThuocID='"+ this.LoaiThuocID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.LoaiThuocID=sLoaiThuocID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_MaLoai(string sMaLoai)
{
    string sqlSave= " UPDATE Thuoc_LoaiThuoc SET MaLoai='N"+ sMaLoai+ "' WHERE LoaiThuocID='"+ this.LoaiThuocID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.MaLoai=sMaLoai;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TenLoai(string sTenLoai)
{
    string sqlSave= " UPDATE Thuoc_LoaiThuoc SET TenLoai='N"+ sTenLoai+ "' WHERE LoaiThuocID='"+ this.LoaiThuocID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TenLoai=sTenLoai;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Status(string sStatus)
{
    string sqlSave= " UPDATE Thuoc_LoaiThuoc SET Status='"+ sStatus+ "' WHERE LoaiThuocID='"+ this.LoaiThuocID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Status=sStatus;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_LoaiThuocID(string sLoaiThuocID,string s_LoaiThuocID)
{
    string sqlSave= " UPDATE Thuoc_LoaiThuoc SET LoaiThuocID='"+sLoaiThuocID+"' WHERE LoaiThuocID='"+ s_LoaiThuocID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_MaLoai(string sMaLoai,string s_LoaiThuocID)
{
    string sqlSave= " UPDATE Thuoc_LoaiThuoc SET MaLoai='N"+sMaLoai+"' WHERE LoaiThuocID='"+ s_LoaiThuocID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TenLoai(string sTenLoai,string s_LoaiThuocID)
{
    string sqlSave= " UPDATE Thuoc_LoaiThuoc SET TenLoai='N"+sTenLoai+"' WHERE LoaiThuocID='"+ s_LoaiThuocID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Status(string sStatus,string s_LoaiThuocID)
{
    string sqlSave= " UPDATE Thuoc_LoaiThuoc SET Status='"+sStatus+"' WHERE LoaiThuocID='"+ s_LoaiThuocID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM Thuoc_LoaiThuoc where status = 1" ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_Thuoc_LoaiThuoc;
   public static bool Change_dt_Thuoc_LoaiThuoc = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_Thuoc_LoaiThuoc()
   {
   if (dt_Thuoc_LoaiThuoc == null || Change_dt_Thuoc_LoaiThuoc == true)
   {
   dt_Thuoc_LoaiThuoc = dtGetAll();
   Change_dt_Thuoc_LoaiThuoc = true && AllowAutoChange ;
   }
   return dt_Thuoc_LoaiThuoc;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

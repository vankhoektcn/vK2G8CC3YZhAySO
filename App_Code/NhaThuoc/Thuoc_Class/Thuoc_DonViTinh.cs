using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process_2608
  { 
 public class Thuoc_DonViTinh:  Connect { 
 public static string sTableName= "Thuoc_DonViTinh"; 
   public string Id;
   public string TenDVT;
   public string Status;
   public string nvk_UuTienYL;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_Id="Id" ;
 public static  string cl_Id_VN="Id";
 public static  string cl_TenDVT="TenDVT" ;
 public static  string cl_TenDVT_VN="TenDVT";
 public static  string cl_Status="Status" ;
 public static  string cl_Status_VN="Status";
 public static  string cl_nvk_UuTienYL="nvk_UuTienYL" ;
 public static  string cl_nvk_UuTienYL_VN="nvk_UuTienYL";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public Thuoc_DonViTinh() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public Thuoc_DonViTinh(
         string sId,
         string sTenDVT,
         string sStatus,
         string snvk_UuTienYL){
         this.Id= sId;
         this.TenDVT= sTenDVT;
         this.Status= sStatus;
         this.nvk_UuTienYL= snvk_UuTienYL;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static Thuoc_DonViTinh Create_Thuoc_DonViTinh ( string sId  ){
    DataTable dt=dtSearchById(sId) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new Thuoc_DonViTinh(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM Thuoc_DonViTinh AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by Id),T.* FROM Thuoc_DonViTinh AS T WHERE";
      if (this.TenDVT!=null && this.TenDVT!="") 
            sqlselect +=" AND TenDVT LIKE N'%" + this.TenDVT +"%'" ;
      if (this.Status!=null && this.Status!="") 
            sqlselect +=" AND Status ='" + this.Status+"'" ;
      if (this.nvk_UuTienYL!=null && this.nvk_UuTienYL!="" && this.nvk_UuTienYL!="0" && this.nvk_UuTienYL!="0.0") 
            sqlselect +=" AND nvk_UuTienYL =" + this.nvk_UuTienYL ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public Thuoc_DonViTinh( DataView dv,int pos)
{
         this.Id= dv[pos][0].ToString();
         this.TenDVT= dv[pos][1].ToString();
         this.Status= dv[pos][2].ToString();
         this.nvk_UuTienYL= dv[pos][3].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchById(string sId)
{
          string sqlSelect= s_Select()+ " WHERE Id  ="+ sId + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchById(string sId,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE Id"+ sMatch +sId + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTenDVT(string sTenDVT)
{
          string sqlSelect= s_Select()+ " WHERE TenDVT  Like N'%"+ sTenDVT + "%'"; 
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
 public static DataTable dtSearchBynvk_UuTienYL(string snvk_UuTienYL)
{
          string sqlSelect= s_Select()+ " WHERE nvk_UuTienYL  ="+ snvk_UuTienYL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynvk_UuTienYL(string snvk_UuTienYL,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE nvk_UuTienYL"+ sMatch +snvk_UuTienYL + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sId
            , string sTenDVT
            , string sStatus
            , string snvk_UuTienYL
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sId!=null && sId!="") 
            sqlselect +=" AND Id =" + sId ;
      if (sTenDVT!=null && sTenDVT!="") 
            sqlselect +=" AND TenDVT LIKE N'%" + sTenDVT +"%'" ;
      if (sStatus!=null && sStatus!="") 
            sqlselect +=" AND Status =" + sStatus ;
      if (snvk_UuTienYL!=null && snvk_UuTienYL!="") 
            sqlselect +=" AND nvk_UuTienYL =" + snvk_UuTienYL ;
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
 public static Thuoc_DonViTinh Insert_Object(
string  sTenDVT
            ,string  sStatus
            ,string  snvk_UuTienYL
            ) 
 { 
              string tem_sTenDVT=DataAcess.hsSqlTool.sGetSaveValue(sTenDVT,"nvarchar");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(sStatus,"bit");
              string tem_snvk_UuTienYL=DataAcess.hsSqlTool.sGetSaveValue(snvk_UuTienYL,"int");

             string sqlSave=" INSERT INTO Thuoc_DonViTinh("+
                   "TenDVT," 
        +                   "Status," 
        +                   "nvk_UuTienYL) VALUES("
 +tem_sTenDVT+","
 +tem_sStatus+","
 +tem_snvk_UuTienYL +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          Thuoc_DonViTinh newThuoc_DonViTinh= new Thuoc_DonViTinh();
                 newThuoc_DonViTinh.Id=GetTable( " SELECT TOP 1 Id FROM Thuoc_DonViTinh ORDER BY Id DESC ").Rows[0][0].ToString();
              newThuoc_DonViTinh.TenDVT=sTenDVT;
              newThuoc_DonViTinh.Status=sStatus;
              newThuoc_DonViTinh.nvk_UuTienYL=snvk_UuTienYL;
            return newThuoc_DonViTinh; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public Thuoc_DonViTinh Insert_Object() { 
              string tem_sTenDVT=DataAcess.hsSqlTool.sGetSaveValue(this.TenDVT,"nvarchar");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(this.Status,"bit");
              string tem_snvk_UuTienYL=DataAcess.hsSqlTool.sGetSaveValue(this.nvk_UuTienYL,"int");

             string sqlSave=" INSERT INTO Thuoc_DonViTinh("+
                   "TenDVT," 
        +                   "Status," 
        +                   "nvk_UuTienYL) VALUES("
 +tem_sTenDVT+","
 +tem_sStatus+","
 +tem_snvk_UuTienYL +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          Thuoc_DonViTinh newThuoc_DonViTinh= new Thuoc_DonViTinh();
                 newThuoc_DonViTinh.Id=GetTable( " SELECT TOP 1 Id FROM Thuoc_DonViTinh ORDER BY Id DESC ").Rows[0][0].ToString();
              newThuoc_DonViTinh.TenDVT=this.TenDVT;
              newThuoc_DonViTinh.Status=this.Status;
              newThuoc_DonViTinh.nvk_UuTienYL=this.nvk_UuTienYL;
            return newThuoc_DonViTinh; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sTenDVT
                ,string sStatus
                ,string snvk_UuTienYL
                ) 
 { 
              string tem_sTenDVT=DataAcess.hsSqlTool.sGetSaveValue(sTenDVT,"nvarchar");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(sStatus,"bit");
              string tem_snvk_UuTienYL=DataAcess.hsSqlTool.sGetSaveValue(snvk_UuTienYL,"int");

 string sqlSave=" UPDATE Thuoc_DonViTinh SET "+"TenDVT ="+tem_sTenDVT+","
 +"Status ="+tem_sStatus+","
 +"nvk_UuTienYL ="+tem_snvk_UuTienYL+" WHERE Id="+DataAcess.hsSqlTool.sGetSaveValue(this.Id,"bigint identity");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.TenDVT=sTenDVT;
                this.Status=sStatus;
                this.nvk_UuTienYL=snvk_UuTienYL;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_sTenDVT=DataAcess.hsSqlTool.sGetSaveValue(this.TenDVT,"nvarchar");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(this.Status,"bit");
              string tem_snvk_UuTienYL=DataAcess.hsSqlTool.sGetSaveValue(this.nvk_UuTienYL,"int");

 string sqlSave=" UPDATE Thuoc_DonViTinh SET ";
if(tem_sTenDVT != null)
 sqlSave+="TenDVT ="+tem_sTenDVT+",";
if(tem_sStatus != null)
 sqlSave+="Status ="+tem_sStatus+",";
if(tem_snvk_UuTienYL != null)
 sqlSave+="nvk_UuTienYL ="+tem_snvk_UuTienYL+",";
sqlSave+=" WHERE Id="+DataAcess.hsSqlTool.sGetSaveValue(this.Id,"bigint identity");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_Id(string sId)
{
    string sqlSave= " UPDATE Thuoc_DonViTinh SET Id='"+ sId+ "' WHERE Id='"+ this.Id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Id=sId;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TenDVT(string sTenDVT)
{
    string sqlSave= " UPDATE Thuoc_DonViTinh SET TenDVT='N"+ sTenDVT+ "' WHERE Id='"+ this.Id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TenDVT=sTenDVT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Status(string sStatus)
{
    string sqlSave= " UPDATE Thuoc_DonViTinh SET Status='"+ sStatus+ "' WHERE Id='"+ this.Id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Status=sStatus;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_nvk_UuTienYL(string snvk_UuTienYL)
{
    string sqlSave= " UPDATE Thuoc_DonViTinh SET nvk_UuTienYL='"+ snvk_UuTienYL+ "' WHERE Id='"+ this.Id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.nvk_UuTienYL=snvk_UuTienYL;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_TenDVT(string sTenDVT,string s_Id)
{
    string sqlSave= " UPDATE Thuoc_DonViTinh SET TenDVT='N"+sTenDVT+"' WHERE Id='"+ s_Id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Status(string sStatus,string s_Id)
{
    string sqlSave= " UPDATE Thuoc_DonViTinh SET Status='"+sStatus+"' WHERE Id='"+ s_Id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_nvk_UuTienYL(string snvk_UuTienYL,string s_Id)
{
    string sqlSave= " UPDATE Thuoc_DonViTinh SET nvk_UuTienYL='"+snvk_UuTienYL+"' WHERE Id='"+ s_Id+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM Thuoc_DonViTinh where status = 1" ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_Thuoc_DonViTinh;
   public static bool Change_dt_Thuoc_DonViTinh = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_Thuoc_DonViTinh()
   {
   if (dt_Thuoc_DonViTinh == null || Change_dt_Thuoc_DonViTinh == true)
   {
   dt_Thuoc_DonViTinh = dtGetAll();
   Change_dt_Thuoc_DonViTinh = true && AllowAutoChange ;
   }
   return dt_Thuoc_DonViTinh;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

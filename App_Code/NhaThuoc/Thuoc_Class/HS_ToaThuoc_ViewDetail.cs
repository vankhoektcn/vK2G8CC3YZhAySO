using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process_2608
  { 
 public class HS_ToaThuoc_ViewDetail:  Connect { 
 public static string sTableName= "HS_ToaThuoc_ViewDetail"; 
   public string IdToaThuocDetail;
   public string IdToaThuoc;
   public string ChiTietThuoc;
   public string ChiTietBenh;
   public string ChiTietCLS;
   public string page;
   public string numberRow;
   #region DataColumn Name ;
 public static  string cl_IdToaThuocDetail="IdToaThuocDetail" ;
 public static  string cl_IdToaThuocDetail_VN="IdToaThuocDetail";
 public static  string cl_IdToaThuoc="IdToaThuoc" ;
 public static  string cl_IdToaThuoc_VN="IdToaThuoc";
 public static  string cl_ChiTietThuoc="ChiTietThuoc" ;
 public static  string cl_ChiTietThuoc_VN="ChiTietThuoc";
 public static  string cl_ChiTietBenh="ChiTietBenh" ;
 public static  string cl_ChiTietBenh_VN="ChiTietBenh";
 public static  string cl_ChiTietCLS="ChiTietCLS" ;
 public static  string cl_ChiTietCLS_VN="ChiTietCLS";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public HS_ToaThuoc_ViewDetail() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public HS_ToaThuoc_ViewDetail(
         string sIdToaThuocDetail,
         string sIdToaThuoc,
         string sChiTietThuoc,
         string sChiTietBenh,
         string sChiTietCLS){
         this.IdToaThuocDetail= sIdToaThuocDetail;
         this.IdToaThuoc= sIdToaThuoc;
         this.ChiTietThuoc= sChiTietThuoc;
         this.ChiTietBenh= sChiTietBenh;
         this.ChiTietCLS= sChiTietCLS;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static HS_ToaThuoc_ViewDetail Create_HS_ToaThuoc_ViewDetail ( string sIdToaThuocDetail  ){
    DataTable dt=dtSearchByIdToaThuocDetail(sIdToaThuocDetail) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new HS_ToaThuoc_ViewDetail(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM HS_ToaThuoc_ViewDetail AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
   private string SQLSelect()
    {
   string sqlselect = " SELECT stt= row_number() over (order by IdToaThuocDetail),T.* FROM HS_ToaThuoc_ViewDetail AS T WHERE";
      if (this.IdToaThuoc!=null && this.IdToaThuoc!="" && this.IdToaThuoc!="0" && this.IdToaThuoc!="0.0") 
            sqlselect +=" AND IdToaThuoc =" + this.IdToaThuoc ;
      if (this.ChiTietThuoc!=null && this.ChiTietThuoc!="") 
            sqlselect +=" AND ChiTietThuoc LIKE '%" + this.ChiTietThuoc +"%'" ;
      if (this.ChiTietBenh!=null && this.ChiTietBenh!="") 
            sqlselect +=" AND ChiTietBenh LIKE '%" + this.ChiTietBenh +"%'" ;
      if (this.ChiTietCLS!=null && this.ChiTietCLS!="") 
            sqlselect +=" AND ChiTietCLS LIKE '%" + this.ChiTietCLS +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return sqlselect;
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public HS_ToaThuoc_ViewDetail( DataView dv,int pos)
{
         this.IdToaThuocDetail= dv[pos][0].ToString();
         this.IdToaThuoc= dv[pos][1].ToString();
         this.ChiTietThuoc= dv[pos][2].ToString();
         this.ChiTietBenh= dv[pos][3].ToString();
         this.ChiTietCLS= dv[pos][4].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdToaThuocDetail(string sIdToaThuocDetail)
{
          string sqlSelect= s_Select()+ " WHERE IdToaThuocDetail  ="+ sIdToaThuocDetail + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdToaThuocDetail(string sIdToaThuocDetail,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdToaThuocDetail"+ sMatch +sIdToaThuocDetail + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdToaThuoc(string sIdToaThuoc)
{
          string sqlSelect= s_Select()+ " WHERE IdToaThuoc  ="+ sIdToaThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdToaThuoc(string sIdToaThuoc,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdToaThuoc"+ sMatch +sIdToaThuoc + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByChiTietThuoc(string sChiTietThuoc)
{
          string sqlSelect= s_Select()+ " WHERE ChiTietThuoc  Like '%"+ sChiTietThuoc + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByChiTietBenh(string sChiTietBenh)
{
          string sqlSelect= s_Select()+ " WHERE ChiTietBenh  Like '%"+ sChiTietBenh + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByChiTietCLS(string sChiTietCLS)
{
          string sqlSelect= s_Select()+ " WHERE ChiTietCLS  Like '%"+ sChiTietCLS + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sIdToaThuocDetail
            , string sIdToaThuoc
            , string sChiTietThuoc
            , string sChiTietBenh
            , string sChiTietCLS
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sIdToaThuocDetail!=null && sIdToaThuocDetail!="") 
            sqlselect +=" AND IdToaThuocDetail =" + sIdToaThuocDetail ;
      if (sIdToaThuoc!=null && sIdToaThuoc!="") 
            sqlselect +=" AND IdToaThuoc =" + sIdToaThuoc ;
      if (sChiTietThuoc!=null && sChiTietThuoc!="") 
            sqlselect +=" AND ChiTietThuoc LIKE '%" + sChiTietThuoc +"%'" ;
      if (sChiTietBenh!=null && sChiTietBenh!="") 
            sqlselect +=" AND ChiTietBenh LIKE '%" + sChiTietBenh +"%'" ;
      if (sChiTietCLS!=null && sChiTietCLS!="") 
            sqlselect +=" AND ChiTietCLS LIKE '%" + sChiTietCLS +"%'" ;
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
 public static HS_ToaThuoc_ViewDetail Insert_Object(
string  sIdToaThuocDetail
            ,string  sIdToaThuoc
            ,string  sChiTietThuoc
            ,string  sChiTietBenh
            ,string  sChiTietCLS
            ) 
 { 
              string tem_sIdToaThuocDetail=DataAcess.hsSqlTool.sGetSaveValue(sIdToaThuocDetail,"bigint");
              string tem_sIdToaThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIdToaThuoc,"bigint");
              string tem_sChiTietThuoc=DataAcess.hsSqlTool.sGetSaveValue(sChiTietThuoc,"ntext");
              string tem_sChiTietBenh=DataAcess.hsSqlTool.sGetSaveValue(sChiTietBenh,"ntext");
              string tem_sChiTietCLS=DataAcess.hsSqlTool.sGetSaveValue(sChiTietCLS,"ntext");

             string sqlSave=" INSERT INTO HS_ToaThuoc_ViewDetail("+
                   "IdToaThuocDetail," 
        +                   "IdToaThuoc," 
        +                   "ChiTietThuoc," 
        +                   "ChiTietBenh," 
        +                   "ChiTietCLS) VALUES("
 +tem_sIdToaThuocDetail+","
 +tem_sIdToaThuoc+","
 +tem_sChiTietThuoc+","
 +tem_sChiTietBenh+","
 +tem_sChiTietCLS +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          HS_ToaThuoc_ViewDetail newHS_ToaThuoc_ViewDetail= new HS_ToaThuoc_ViewDetail();
              newHS_ToaThuoc_ViewDetail.IdToaThuocDetail=sIdToaThuocDetail;
              newHS_ToaThuoc_ViewDetail.IdToaThuoc=sIdToaThuoc;
              newHS_ToaThuoc_ViewDetail.ChiTietThuoc=sChiTietThuoc;
              newHS_ToaThuoc_ViewDetail.ChiTietBenh=sChiTietBenh;
              newHS_ToaThuoc_ViewDetail.ChiTietCLS=sChiTietCLS;
            return newHS_ToaThuoc_ViewDetail; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public HS_ToaThuoc_ViewDetail Insert_Object() { 
              string tem_sIdToaThuocDetail=(GetTable( " SELECT IdToaThuocDetail FROM HS_ToaThuoc_ViewDetail").Rows.Count + 1)+"";
              string tem_sIdToaThuoc=DataAcess.hsSqlTool.sGetSaveValue(this.IdToaThuoc,"bigint");
              string tem_sChiTietThuoc=DataAcess.hsSqlTool.sGetSaveValue(this.ChiTietThuoc,"ntext");
              string tem_sChiTietBenh=DataAcess.hsSqlTool.sGetSaveValue(this.ChiTietBenh,"ntext");
              string tem_sChiTietCLS=DataAcess.hsSqlTool.sGetSaveValue(this.ChiTietCLS,"ntext");

             string sqlSave=" INSERT INTO HS_ToaThuoc_ViewDetail("+
                   "IdToaThuocDetail," 
        +                   "IdToaThuoc," 
        +                   "ChiTietThuoc," 
        +                   "ChiTietBenh," 
        +                   "ChiTietCLS) VALUES("
 +tem_sIdToaThuocDetail+","
 +tem_sIdToaThuoc+","
 +tem_sChiTietThuoc+","
 +tem_sChiTietBenh+","
 +tem_sChiTietCLS +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          HS_ToaThuoc_ViewDetail newHS_ToaThuoc_ViewDetail= new HS_ToaThuoc_ViewDetail();
              newHS_ToaThuoc_ViewDetail.IdToaThuocDetail=this.IdToaThuocDetail;
              newHS_ToaThuoc_ViewDetail.IdToaThuoc=this.IdToaThuoc;
              newHS_ToaThuoc_ViewDetail.ChiTietThuoc=this.ChiTietThuoc;
              newHS_ToaThuoc_ViewDetail.ChiTietBenh=this.ChiTietBenh;
              newHS_ToaThuoc_ViewDetail.ChiTietCLS=this.ChiTietCLS;
            return newHS_ToaThuoc_ViewDetail; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sIdToaThuocDetail
                ,string sIdToaThuoc
                ,string sChiTietThuoc
                ,string sChiTietBenh
                ,string sChiTietCLS
                ) 
 { 
              string tem_sIdToaThuoc=DataAcess.hsSqlTool.sGetSaveValue(sIdToaThuoc,"bigint");
              string tem_sChiTietThuoc=DataAcess.hsSqlTool.sGetSaveValue(sChiTietThuoc,"ntext");
              string tem_sChiTietBenh=DataAcess.hsSqlTool.sGetSaveValue(sChiTietBenh,"ntext");
              string tem_sChiTietCLS=DataAcess.hsSqlTool.sGetSaveValue(sChiTietCLS,"ntext");

 string sqlSave=" UPDATE HS_ToaThuoc_ViewDetail SET "+"IdToaThuoc ="+tem_sIdToaThuoc+","
 +"ChiTietThuoc ="+tem_sChiTietThuoc+","
 +"ChiTietBenh ="+tem_sChiTietBenh+","
 +"ChiTietCLS ="+tem_sChiTietCLS+" WHERE IdToaThuocDetail="+DataAcess.hsSqlTool.sGetSaveValue(this.IdToaThuocDetail,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.IdToaThuoc=sIdToaThuoc;
                this.ChiTietThuoc=sChiTietThuoc;
                this.ChiTietBenh=sChiTietBenh;
                this.ChiTietCLS=sChiTietCLS;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
public bool Save_Object() { 
              string tem_sIdToaThuoc=DataAcess.hsSqlTool.sGetSaveValue(this.IdToaThuoc,"bigint");
              string tem_sChiTietThuoc=DataAcess.hsSqlTool.sGetSaveValue(this.ChiTietThuoc,"ntext");
              string tem_sChiTietBenh=DataAcess.hsSqlTool.sGetSaveValue(this.ChiTietBenh,"ntext");
              string tem_sChiTietCLS=DataAcess.hsSqlTool.sGetSaveValue(this.ChiTietCLS,"ntext");

 string sqlSave=" UPDATE HS_ToaThuoc_ViewDetail SET ";
if(tem_sIdToaThuoc != null)
 sqlSave+="IdToaThuoc ="+tem_sIdToaThuoc+",";
if(tem_sChiTietThuoc != null)
 sqlSave+="ChiTietThuoc ="+tem_sChiTietThuoc+",";
if(tem_sChiTietBenh != null)
 sqlSave+="ChiTietBenh ="+tem_sChiTietBenh+",";
if(tem_sChiTietCLS != null)
 sqlSave+="ChiTietCLS ="+tem_sChiTietCLS+",";
sqlSave+=" WHERE IdToaThuocDetail="+DataAcess.hsSqlTool.sGetSaveValue(this.IdToaThuocDetail,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_IdToaThuocDetail(string sIdToaThuocDetail)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET IdToaThuocDetail='"+ sIdToaThuocDetail+ "' WHERE IdToaThuocDetail='"+ this.IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IdToaThuocDetail=sIdToaThuocDetail;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdToaThuoc(string sIdToaThuoc)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET IdToaThuoc='"+ sIdToaThuoc+ "' WHERE IdToaThuocDetail='"+ this.IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IdToaThuoc=sIdToaThuoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ChiTietThuoc(string sChiTietThuoc)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET ChiTietThuoc='"+ sChiTietThuoc+ "' WHERE IdToaThuocDetail='"+ this.IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ChiTietThuoc=sChiTietThuoc;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ChiTietBenh(string sChiTietBenh)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET ChiTietBenh='"+ sChiTietBenh+ "' WHERE IdToaThuocDetail='"+ this.IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ChiTietBenh=sChiTietBenh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ChiTietCLS(string sChiTietCLS)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET ChiTietCLS='"+ sChiTietCLS+ "' WHERE IdToaThuocDetail='"+ this.IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ChiTietCLS=sChiTietCLS;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_IdToaThuocDetail(string sIdToaThuocDetail,string s_IdToaThuocDetail)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET IdToaThuocDetail='"+sIdToaThuocDetail+"' WHERE IdToaThuocDetail='"+ s_IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IdToaThuoc(string sIdToaThuoc,string s_IdToaThuocDetail)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET IdToaThuoc='"+sIdToaThuoc+"' WHERE IdToaThuocDetail='"+ s_IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ChiTietThuoc(string sChiTietThuoc,string s_IdToaThuocDetail)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET ChiTietThuoc='"+sChiTietThuoc+"' WHERE IdToaThuocDetail='"+ s_IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ChiTietBenh(string sChiTietBenh,string s_IdToaThuocDetail)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET ChiTietBenh='"+sChiTietBenh+"' WHERE IdToaThuocDetail='"+ s_IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ChiTietCLS(string sChiTietCLS,string s_IdToaThuocDetail)
{
    string sqlSave= " UPDATE HS_ToaThuoc_ViewDetail SET ChiTietCLS='"+sChiTietCLS+"' WHERE IdToaThuocDetail='"+ s_IdToaThuocDetail+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM HS_ToaThuoc_ViewDetail " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_HS_ToaThuoc_ViewDetail;
   public static bool Change_dt_HS_ToaThuoc_ViewDetail = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_HS_ToaThuoc_ViewDetail()
   {
   if (dt_HS_ToaThuoc_ViewDetail == null || Change_dt_HS_ToaThuoc_ViewDetail == true)
   {
   dt_HS_ToaThuoc_ViewDetail = dtGetAll();
   Change_dt_HS_ToaThuoc_ViewDetail = true && AllowAutoChange ;
   }
   return dt_HS_ToaThuoc_ViewDetail;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

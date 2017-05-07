using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process_2608
  { 
 public class nhacungcap:  Connect { 
 public static string sTableName= "nhacungcap"; 
   public string nhacungcapid;
   public string manhacungcap;
   public string tennhacungcap;
   public string nguoilienhe;
   public string diachi;
   public string dienthoai;
   public string fax;
   public string hanmuctindung;
   public string taikhoannganhang;
   public string nganhang;
   public string masothue;
   public string dinhdanhimei;
   public string IsKT;
   #region DataColumn Name ;
 public static  string cl_nhacungcapid="nhacungcapid" ;
 public static  string cl_nhacungcapid_VN="nhacungcapid";
 public static  string cl_manhacungcap="manhacungcap" ;
 public static  string cl_manhacungcap_VN="manhacungcap";
 public static  string cl_tennhacungcap="tennhacungcap" ;
 public static  string cl_tennhacungcap_VN="tennhacungcap";
 public static  string cl_nguoilienhe="nguoilienhe" ;
 public static  string cl_nguoilienhe_VN="nguoilienhe";
 public static  string cl_diachi="diachi" ;
 public static  string cl_diachi_VN="diachi";
 public static  string cl_dienthoai="dienthoai" ;
 public static  string cl_dienthoai_VN="dienthoai";
 public static  string cl_fax="fax" ;
 public static  string cl_fax_VN="fax";
 public static  string cl_hanmuctindung="hanmuctindung" ;
 public static  string cl_hanmuctindung_VN="hanmuctindung";
 public static  string cl_taikhoannganhang="taikhoannganhang" ;
 public static  string cl_taikhoannganhang_VN="taikhoannganhang";
 public static  string cl_nganhang="nganhang" ;
 public static  string cl_nganhang_VN="nganhang";
 public static  string cl_masothue="masothue" ;
 public static  string cl_masothue_VN="masothue";
 public static  string cl_dinhdanhimei="dinhdanhimei" ;
 public static  string cl_dinhdanhimei_VN="dinhdanhimei";
 public static  string cl_IsKT="IsKT" ;
 public static  string cl_IsKT_VN="IsKT";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public nhacungcap() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public nhacungcap(
         string snhacungcapid,
         string smanhacungcap,
         string stennhacungcap,
         string snguoilienhe,
         string sdiachi,
         string sdienthoai,
         string sfax,
         string shanmuctindung,
         string staikhoannganhang,
         string snganhang,
         string smasothue,
         string sdinhdanhimei,
         string sIsKT){
         this.nhacungcapid= snhacungcapid;
         this.manhacungcap= smanhacungcap;
         this.tennhacungcap= stennhacungcap;
         this.nguoilienhe= snguoilienhe;
         this.diachi= sdiachi;
         this.dienthoai= sdienthoai;
         this.fax= sfax;
         this.hanmuctindung= shanmuctindung;
         this.taikhoannganhang= staikhoannganhang;
         this.nganhang= snganhang;
         this.masothue= smasothue;
         this.dinhdanhimei= sdinhdanhimei;
         this.IsKT= sIsKT;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static nhacungcap Create_nhacungcap ( string snhacungcapid  ){
    DataTable dt=dtSearchBynhacungcapid(snhacungcapid) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new nhacungcap(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM nhacungcap AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public nhacungcap( DataView dv,int pos)
{
         this.nhacungcapid= dv[pos][0].ToString();
         this.manhacungcap= dv[pos][1].ToString();
         this.tennhacungcap= dv[pos][2].ToString();
         this.nguoilienhe= dv[pos][3].ToString();
         this.diachi= dv[pos][4].ToString();
         this.dienthoai= dv[pos][5].ToString();
         this.fax= dv[pos][6].ToString();
         this.hanmuctindung= dv[pos][7].ToString();
         this.taikhoannganhang= dv[pos][8].ToString();
         this.nganhang= dv[pos][9].ToString();
         this.masothue= dv[pos][10].ToString();
         this.dinhdanhimei= dv[pos][11].ToString();
         this.IsKT= dv[pos][12].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynhacungcapid(string snhacungcapid)
{
          string sqlSelect= s_Select()+ " WHERE nhacungcapid  ="+ snhacungcapid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynhacungcapid(string snhacungcapid,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE nhacungcapid"+ sMatch +snhacungcapid + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBymanhacungcap(string smanhacungcap)
{
          string sqlSelect= s_Select()+ " WHERE manhacungcap  Like N'%"+ smanhacungcap + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytennhacungcap(string stennhacungcap)
{
          string sqlSelect= s_Select()+ " WHERE tennhacungcap  Like N'%"+ stennhacungcap + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynguoilienhe(string snguoilienhe)
{
          string sqlSelect= s_Select()+ " WHERE nguoilienhe  Like N'%"+ snguoilienhe + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydiachi(string sdiachi)
{
          string sqlSelect= s_Select()+ " WHERE diachi  Like N'%"+ sdiachi + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydienthoai(string sdienthoai)
{
          string sqlSelect= s_Select()+ " WHERE dienthoai  Like N'%"+ sdienthoai + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByfax(string sfax)
{
          string sqlSelect= s_Select()+ " WHERE fax  Like N'%"+ sfax + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByhanmuctindung(string shanmuctindung)
{
          string sqlSelect= s_Select()+ " WHERE hanmuctindung  ="+ shanmuctindung + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByhanmuctindung(string shanmuctindung,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE hanmuctindung"+ sMatch +shanmuctindung + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytaikhoannganhang(string staikhoannganhang)
{
          string sqlSelect= s_Select()+ " WHERE taikhoannganhang  Like N'%"+ staikhoannganhang + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBynganhang(string snganhang)
{
          string sqlSelect= s_Select()+ " WHERE nganhang  Like N'%"+ snganhang + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBymasothue(string smasothue)
{
          string sqlSelect= s_Select()+ " WHERE masothue  Like N'%"+ smasothue + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydinhdanhimei(string sdinhdanhimei)
{
          string sqlSelect= s_Select()+ " WHERE dinhdanhimei  Like N'%"+ sdinhdanhimei + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsKT(string sIsKT)
{
          string sqlSelect= s_Select()+ " WHERE IsKT  ="+ sIsKT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsKT(string sIsKT,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IsKT"+ sMatch +sIsKT + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string snhacungcapid
            , string smanhacungcap
            , string stennhacungcap
            , string snguoilienhe
            , string sdiachi
            , string sdienthoai
            , string sfax
            , string shanmuctindung
            , string staikhoannganhang
            , string snganhang
            , string smasothue
            , string sdinhdanhimei
            , string sIsKT
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (snhacungcapid!=null && snhacungcapid!="") 
            sqlselect +=" AND nhacungcapid =" + snhacungcapid ;
      if (smanhacungcap!=null && smanhacungcap!="") 
            sqlselect +=" AND manhacungcap LIKE N'%" + smanhacungcap +"%'" ;
      if (stennhacungcap!=null && stennhacungcap!="") 
            sqlselect +=" AND tennhacungcap LIKE N'%" + stennhacungcap +"%'" ;
      if (snguoilienhe!=null && snguoilienhe!="") 
            sqlselect +=" AND nguoilienhe LIKE N'%" + snguoilienhe +"%'" ;
      if (sdiachi!=null && sdiachi!="") 
            sqlselect +=" AND diachi LIKE N'%" + sdiachi +"%'" ;
      if (sdienthoai!=null && sdienthoai!="") 
            sqlselect +=" AND dienthoai LIKE N'%" + sdienthoai +"%'" ;
      if (sfax!=null && sfax!="") 
            sqlselect +=" AND fax LIKE N'%" + sfax +"%'" ;
      if (shanmuctindung!=null && shanmuctindung!="") 
            sqlselect +=" AND hanmuctindung =" + shanmuctindung ;
      if (staikhoannganhang!=null && staikhoannganhang!="") 
            sqlselect +=" AND taikhoannganhang LIKE N'%" + staikhoannganhang +"%'" ;
      if (snganhang!=null && snganhang!="") 
            sqlselect +=" AND nganhang LIKE N'%" + snganhang +"%'" ;
      if (smasothue!=null && smasothue!="") 
            sqlselect +=" AND masothue LIKE N'%" + smasothue +"%'" ;
      if (sdinhdanhimei!=null && sdinhdanhimei!="") 
            sqlselect +=" AND dinhdanhimei LIKE N'%" + sdinhdanhimei +"%'" ;
      if (sIsKT!=null && sIsKT!="") 
            sqlselect +=" AND IsKT =" + sIsKT ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static nhacungcap Insert_Object(
string  smanhacungcap
            ,string  stennhacungcap
            ,string  snguoilienhe
            ,string  sdiachi
            ,string  sdienthoai
            ,string  sfax
            ,string  shanmuctindung
            ,string  staikhoannganhang
            ,string  snganhang
            ,string  smasothue
            ,string  sdinhdanhimei
            ,string  sIsKT
            ) 
 { 
              string tem_smanhacungcap=DataAcess.hsSqlTool.sGetSaveValue(smanhacungcap,"varchar");
              string tem_stennhacungcap=DataAcess.hsSqlTool.sGetSaveValue(stennhacungcap,"nvarchar");
              string tem_snguoilienhe=DataAcess.hsSqlTool.sGetSaveValue(snguoilienhe,"nvarchar");
              string tem_sdiachi=DataAcess.hsSqlTool.sGetSaveValue(sdiachi,"nvarchar");
              string tem_sdienthoai=DataAcess.hsSqlTool.sGetSaveValue(sdienthoai,"varchar");
              string tem_sfax=DataAcess.hsSqlTool.sGetSaveValue(sfax,"varchar");
              string tem_shanmuctindung=DataAcess.hsSqlTool.sGetSaveValue(shanmuctindung,"int");
              string tem_staikhoannganhang=DataAcess.hsSqlTool.sGetSaveValue(staikhoannganhang,"nvarchar");
              string tem_snganhang=DataAcess.hsSqlTool.sGetSaveValue(snganhang,"nvarchar");
              string tem_smasothue=DataAcess.hsSqlTool.sGetSaveValue(smasothue,"nvarchar");
              string tem_sdinhdanhimei=DataAcess.hsSqlTool.sGetSaveValue(sdinhdanhimei,"char");
              string tem_sIsKT=DataAcess.hsSqlTool.sGetSaveValue(sIsKT,"bit");

             string sqlSave=" INSERT INTO nhacungcap("+
                   "manhacungcap," 
        +                   "tennhacungcap," 
        +                   "nguoilienhe," 
        +                   "diachi," 
        +                   "dienthoai," 
        +                   "fax," 
        +                   "hanmuctindung," 
        +                   "taikhoannganhang," 
        +                   "nganhang," 
        +                   "masothue," 
        +                   "dinhdanhimei," 
        +                   "IsKT) VALUES("
 +tem_smanhacungcap+","
 +tem_stennhacungcap+","
 +tem_snguoilienhe+","
 +tem_sdiachi+","
 +tem_sdienthoai+","
 +tem_sfax+","
 +tem_shanmuctindung+","
 +tem_staikhoannganhang+","
 +tem_snganhang+","
 +tem_smasothue+","
 +tem_sdinhdanhimei+","
 +tem_sIsKT +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          nhacungcap newnhacungcap= new nhacungcap();
                 newnhacungcap.nhacungcapid=GetTable( " SELECT TOP 1 nhacungcapid FROM nhacungcap ORDER BY nhacungcapid DESC ").Rows[0][0].ToString();
              newnhacungcap.manhacungcap=smanhacungcap;
              newnhacungcap.tennhacungcap=stennhacungcap;
              newnhacungcap.nguoilienhe=snguoilienhe;
              newnhacungcap.diachi=sdiachi;
              newnhacungcap.dienthoai=sdienthoai;
              newnhacungcap.fax=sfax;
              newnhacungcap.hanmuctindung=shanmuctindung;
              newnhacungcap.taikhoannganhang=staikhoannganhang;
              newnhacungcap.nganhang=snganhang;
              newnhacungcap.masothue=smasothue;
              newnhacungcap.dinhdanhimei=sdinhdanhimei;
              newnhacungcap.IsKT=sIsKT;
            return newnhacungcap; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string smanhacungcap
                ,string stennhacungcap
                ,string snguoilienhe
                ,string sdiachi
                ,string sdienthoai
                ,string sfax
                ,string shanmuctindung
                ,string staikhoannganhang
                ,string snganhang
                ,string smasothue
                ,string sdinhdanhimei
                ,string sIsKT
                ) 
 { 
              string tem_smanhacungcap=DataAcess.hsSqlTool.sGetSaveValue(smanhacungcap,"varchar");
              string tem_stennhacungcap=DataAcess.hsSqlTool.sGetSaveValue(stennhacungcap,"nvarchar");
              string tem_snguoilienhe=DataAcess.hsSqlTool.sGetSaveValue(snguoilienhe,"nvarchar");
              string tem_sdiachi=DataAcess.hsSqlTool.sGetSaveValue(sdiachi,"nvarchar");
              string tem_sdienthoai=DataAcess.hsSqlTool.sGetSaveValue(sdienthoai,"varchar");
              string tem_sfax=DataAcess.hsSqlTool.sGetSaveValue(sfax,"varchar");
              string tem_shanmuctindung=DataAcess.hsSqlTool.sGetSaveValue(shanmuctindung,"int");
              string tem_staikhoannganhang=DataAcess.hsSqlTool.sGetSaveValue(staikhoannganhang,"nvarchar");
              string tem_snganhang=DataAcess.hsSqlTool.sGetSaveValue(snganhang,"nvarchar");
              string tem_smasothue=DataAcess.hsSqlTool.sGetSaveValue(smasothue,"nvarchar");
              string tem_sdinhdanhimei=DataAcess.hsSqlTool.sGetSaveValue(sdinhdanhimei,"char");
              string tem_sIsKT=DataAcess.hsSqlTool.sGetSaveValue(sIsKT,"bit");

 string sqlSave=" UPDATE nhacungcap SET "+"manhacungcap ="+tem_smanhacungcap+","
 +"tennhacungcap ="+tem_stennhacungcap+","
 +"nguoilienhe ="+tem_snguoilienhe+","
 +"diachi ="+tem_sdiachi+","
 +"dienthoai ="+tem_sdienthoai+","
 +"fax ="+tem_sfax+","
 +"hanmuctindung ="+tem_shanmuctindung+","
 +"taikhoannganhang ="+tem_staikhoannganhang+","
 +"nganhang ="+tem_snganhang+","
 +"masothue ="+tem_smasothue+","
 +"dinhdanhimei ="+tem_sdinhdanhimei+","
 +"IsKT ="+tem_sIsKT+" WHERE nhacungcapid="+DataAcess.hsSqlTool.sGetSaveValue(this.nhacungcapid,"int identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.manhacungcap=smanhacungcap;
                this.tennhacungcap=stennhacungcap;
                this.nguoilienhe=snguoilienhe;
                this.diachi=sdiachi;
                this.dienthoai=sdienthoai;
                this.fax=sfax;
                this.hanmuctindung=shanmuctindung;
                this.taikhoannganhang=staikhoannganhang;
                this.nganhang=snganhang;
                this.masothue=smasothue;
                this.dinhdanhimei=sdinhdanhimei;
                this.IsKT=sIsKT;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_nhacungcapid(string snhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET nhacungcapid='"+ snhacungcapid+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.nhacungcapid=snhacungcapid;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_manhacungcap(string smanhacungcap)
{
    string sqlSave= " UPDATE nhacungcap SET manhacungcap=N'"+ smanhacungcap+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.manhacungcap=smanhacungcap;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tennhacungcap(string stennhacungcap)
{
    string sqlSave= " UPDATE nhacungcap SET tennhacungcap=N'"+ stennhacungcap+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tennhacungcap=stennhacungcap;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_nguoilienhe(string snguoilienhe)
{
    string sqlSave= " UPDATE nhacungcap SET nguoilienhe=N'"+ snguoilienhe+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.nguoilienhe=snguoilienhe;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_diachi(string sdiachi)
{
    string sqlSave= " UPDATE nhacungcap SET diachi=N'"+ sdiachi+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.diachi=sdiachi;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_dienthoai(string sdienthoai)
{
    string sqlSave= " UPDATE nhacungcap SET dienthoai=N'"+ sdienthoai+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dienthoai=sdienthoai;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_fax(string sfax)
{
    string sqlSave= " UPDATE nhacungcap SET fax=N'"+ sfax+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.fax=sfax;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_hanmuctindung(string shanmuctindung)
{
    string sqlSave= " UPDATE nhacungcap SET hanmuctindung='"+ shanmuctindung+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.hanmuctindung=shanmuctindung;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_taikhoannganhang(string staikhoannganhang)
{
    string sqlSave= " UPDATE nhacungcap SET taikhoannganhang=N'"+ staikhoannganhang+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.taikhoannganhang=staikhoannganhang;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_nganhang(string snganhang)
{
    string sqlSave= " UPDATE nhacungcap SET nganhang=N'"+ snganhang+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.nganhang=snganhang;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_masothue(string smasothue)
{
    string sqlSave= " UPDATE nhacungcap SET masothue=N'"+ smasothue+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.masothue=smasothue;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_dinhdanhimei(string sdinhdanhimei)
{
    string sqlSave= " UPDATE nhacungcap SET dinhdanhimei=N'"+ sdinhdanhimei+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dinhdanhimei=sdinhdanhimei;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsKT(string sIsKT)
{
    string sqlSave= " UPDATE nhacungcap SET IsKT='"+ sIsKT+ "' WHERE nhacungcapid='"+ this.nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IsKT=sIsKT;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_manhacungcap(string smanhacungcap,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET manhacungcap='N"+smanhacungcap+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tennhacungcap(string stennhacungcap,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET tennhacungcap='N"+stennhacungcap+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_nguoilienhe(string snguoilienhe,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET nguoilienhe='N"+snguoilienhe+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_diachi(string sdiachi,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET diachi='N"+sdiachi+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dienthoai(string sdienthoai,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET dienthoai='N"+sdienthoai+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_fax(string sfax,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET fax='N"+sfax+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_hanmuctindung(string shanmuctindung,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET hanmuctindung='"+shanmuctindung+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_taikhoannganhang(string staikhoannganhang,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET taikhoannganhang='N"+staikhoannganhang+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_nganhang(string snganhang,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET nganhang='N"+snganhang+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_masothue(string smasothue,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET masothue='N"+smasothue+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dinhdanhimei(string sdinhdanhimei,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET dinhdanhimei='N"+sdinhdanhimei+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsKT(string sIsKT,string s_nhacungcapid)
{
    string sqlSave= " UPDATE nhacungcap SET IsKT='"+sIsKT+"' WHERE nhacungcapid='"+ s_nhacungcapid+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM nhacungcap " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_nhacungcap;
   public static bool Change_dt_nhacungcap = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_nhacungcap()
   {
   if (dt_nhacungcap == null || Change_dt_nhacungcap == true)
   {
   dt_nhacungcap = dtGetAll();
   Change_dt_nhacungcap = true && AllowAutoChange ;
   }
   return dt_nhacungcap;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

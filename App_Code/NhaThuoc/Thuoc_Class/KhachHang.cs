using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process_2608
  { 
 public class KhachHang:  Connect { 
 public static string sTableName= "KhachHang"; 
   public string IDKhachHang;
   public string IdBenhNhan;
   public string makhachhang;
   public string tenkhachhang;
   public string diachi;
   public string dienthoai;
   public string gioitinh;
   public string ngaysinh;
   public string fax;
   public string dinhdanhimei;
   public string taikhoannganhang;
   public string nganhang;
   public string masothue;
   public string nguoilienhe;
   #region DataColumn Name ;
 public static  string cl_IDKhachHang="IDKhachHang" ;
 public static  string cl_IDKhachHang_VN="IDKhachHang";
 public static  string cl_IdBenhNhan="IdBenhNhan" ;
 public static  string cl_IdBenhNhan_VN="IdBenhNhan";
 public static  string cl_makhachhang="makhachhang" ;
 public static  string cl_makhachhang_VN="makhachhang";
 public static  string cl_tenkhachhang="tenkhachhang" ;
 public static  string cl_tenkhachhang_VN="tenkhachhang";
 public static  string cl_diachi="diachi" ;
 public static  string cl_diachi_VN="diachi";
 public static  string cl_dienthoai="dienthoai" ;
 public static  string cl_dienthoai_VN="dienthoai";
 public static  string cl_gioitinh="gioitinh" ;
 public static  string cl_gioitinh_VN="gioitinh";
 public static  string cl_ngaysinh="ngaysinh" ;
 public static  string cl_ngaysinh_VN="ngaysinh";
 public static  string cl_fax="fax" ;
 public static  string cl_fax_VN="fax";
 public static  string cl_dinhdanhimei="dinhdanhimei" ;
 public static  string cl_dinhdanhimei_VN="dinhdanhimei";
 public static  string cl_taikhoannganhang="taikhoannganhang" ;
 public static  string cl_taikhoannganhang_VN="taikhoannganhang";
 public static  string cl_nganhang="nganhang" ;
 public static  string cl_nganhang_VN="nganhang";
 public static  string cl_masothue="masothue" ;
 public static  string cl_masothue_VN="masothue";
 public static  string cl_nguoilienhe="nguoilienhe" ;
 public static  string cl_nguoilienhe_VN="nguoilienhe";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public KhachHang() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public KhachHang(
         string sIDKhachHang,
         string sIdBenhNhan,
         string smakhachhang,
         string stenkhachhang,
         string sdiachi,
         string sdienthoai,
         string sgioitinh,
         string sngaysinh,
         string sfax,
         string sdinhdanhimei,
         string staikhoannganhang,
         string snganhang,
         string smasothue,
         string snguoilienhe){
         this.IDKhachHang= sIDKhachHang;
         this.IdBenhNhan= sIdBenhNhan;
         this.makhachhang= smakhachhang;
         this.tenkhachhang= stenkhachhang;
         this.diachi= sdiachi;
         this.dienthoai= sdienthoai;
         this.gioitinh= sgioitinh;
         this.ngaysinh= sngaysinh;
         this.fax= sfax;
         this.dinhdanhimei= sdinhdanhimei;
         this.taikhoannganhang= staikhoannganhang;
         this.nganhang= snganhang;
         this.masothue= smasothue;
         this.nguoilienhe= snguoilienhe;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static KhachHang Create_KhachHang ( string sIDKhachHang  ){
    DataTable dt=dtSearchByIDKhachHang(sIDKhachHang) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new KhachHang(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM KhachHang AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public KhachHang( DataView dv,int pos)
{
         this.IDKhachHang= dv[pos][0].ToString();
         this.IdBenhNhan= dv[pos][1].ToString();
         this.makhachhang= dv[pos][2].ToString();
         this.tenkhachhang= dv[pos][3].ToString();
         this.diachi= dv[pos][4].ToString();
         this.dienthoai= dv[pos][5].ToString();
         this.gioitinh= dv[pos][6].ToString();
         this.ngaysinh= dv[pos][7].ToString();
         this.fax= dv[pos][8].ToString();
         this.dinhdanhimei= dv[pos][9].ToString();
         this.taikhoannganhang= dv[pos][10].ToString();
         this.nganhang= dv[pos][11].ToString();
         this.masothue= dv[pos][12].ToString();
         this.nguoilienhe= dv[pos][13].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDKhachHang(string sIDKhachHang)
{
          string sqlSelect= s_Select()+ " WHERE IDKhachHang  ="+ sIDKhachHang + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIDKhachHang(string sIDKhachHang,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IDKhachHang"+ sMatch +sIDKhachHang + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdBenhNhan(string sIdBenhNhan)
{
          string sqlSelect= s_Select()+ " WHERE IdBenhNhan  ="+ sIdBenhNhan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIdBenhNhan(string sIdBenhNhan,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IdBenhNhan"+ sMatch +sIdBenhNhan + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBymakhachhang(string smakhachhang)
{
          string sqlSelect= s_Select()+ " WHERE makhachhang  Like N'%"+ smakhachhang + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBytenkhachhang(string stenkhachhang)
{
          string sqlSelect= s_Select()+ " WHERE tenkhachhang  Like N'%"+ stenkhachhang + "%'"; 
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
 public static DataTable dtSearchBygioitinh(string sgioitinh)
{
          string sqlSelect= s_Select()+ " WHERE gioitinh  ="+ sgioitinh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBygioitinh(string sgioitinh,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE gioitinh"+ sMatch +sgioitinh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaysinh(string sngaysinh)
{
          string sqlSelect= s_Select()+ " WHERE ngaysinh  ="+ sngaysinh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByngaysinh(string sngaysinh,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ngaysinh"+ sMatch +sngaysinh + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByfax(string sfax)
{
          string sqlSelect= s_Select()+ " WHERE fax  Like N'%"+ sfax + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchBydinhdanhimei(string sdinhdanhimei)
{
          string sqlSelect= s_Select()+ " WHERE dinhdanhimei  Like N'%"+ sdinhdanhimei + "%'"; 
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
 public static DataTable dtSearchBynguoilienhe(string snguoilienhe)
{
          string sqlSelect= s_Select()+ " WHERE nguoilienhe  Like N'%"+ snguoilienhe + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sIDKhachHang
            , string sIdBenhNhan
            , string smakhachhang
            , string stenkhachhang
            , string sdiachi
            , string sdienthoai
            , string sgioitinh
            , string sngaysinh
            , string sfax
            , string sdinhdanhimei
            , string staikhoannganhang
            , string snganhang
            , string smasothue
            , string snguoilienhe
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sIDKhachHang!=null && sIDKhachHang!="") 
            sqlselect +=" AND IDKhachHang =" + sIDKhachHang ;
      if (sIdBenhNhan!=null && sIdBenhNhan!="") 
            sqlselect +=" AND IdBenhNhan =" + sIdBenhNhan ;
      if (smakhachhang!=null && smakhachhang!="") 
            sqlselect +=" AND makhachhang LIKE N'%" + smakhachhang +"%'" ;
      if (stenkhachhang!=null && stenkhachhang!="") 
            sqlselect +=" AND tenkhachhang LIKE N'%" + stenkhachhang +"%'" ;
      if (sdiachi!=null && sdiachi!="") 
            sqlselect +=" AND diachi LIKE N'%" + sdiachi +"%'" ;
      if (sdienthoai!=null && sdienthoai!="") 
            sqlselect +=" AND dienthoai LIKE N'%" + sdienthoai +"%'" ;
      if (sgioitinh!=null && sgioitinh!="") 
            sqlselect +=" AND gioitinh =" + sgioitinh ;
      if (sngaysinh!=null && sngaysinh!="") 
            sqlselect +=" AND ngaysinh LIKE '%" + sngaysinh +"%'" ;
      if (sfax!=null && sfax!="") 
            sqlselect +=" AND fax LIKE N'%" + sfax +"%'" ;
      if (sdinhdanhimei!=null && sdinhdanhimei!="") 
            sqlselect +=" AND dinhdanhimei LIKE N'%" + sdinhdanhimei +"%'" ;
      if (staikhoannganhang!=null && staikhoannganhang!="") 
            sqlselect +=" AND taikhoannganhang LIKE N'%" + staikhoannganhang +"%'" ;
      if (snganhang!=null && snganhang!="") 
            sqlselect +=" AND nganhang LIKE N'%" + snganhang +"%'" ;
      if (smasothue!=null && smasothue!="") 
            sqlselect +=" AND masothue LIKE N'%" + smasothue +"%'" ;
      if (snguoilienhe!=null && snguoilienhe!="") 
            sqlselect +=" AND nguoilienhe LIKE N'%" + snguoilienhe +"%'" ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static KhachHang Insert_Object(
string  sIdBenhNhan
            ,string  smakhachhang
            ,string  stenkhachhang
            ,string  sdiachi
            ,string  sdienthoai
            ,string  sgioitinh
            ,string  sngaysinh
            ,string  sfax
            ,string  sdinhdanhimei
            ,string  staikhoannganhang
            ,string  snganhang
            ,string  smasothue
            ,string  snguoilienhe
            ) 
 { 
              string tem_sIdBenhNhan=DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhan,"int");
              string tem_smakhachhang=DataAcess.hsSqlTool.sGetSaveValue(smakhachhang,"varchar");
              string tem_stenkhachhang=DataAcess.hsSqlTool.sGetSaveValue(stenkhachhang,"nvarchar");
              string tem_sdiachi=DataAcess.hsSqlTool.sGetSaveValue(sdiachi,"nvarchar");
              string tem_sdienthoai=DataAcess.hsSqlTool.sGetSaveValue(sdienthoai,"varchar");
              string tem_sgioitinh=DataAcess.hsSqlTool.sGetSaveValue(sgioitinh,"tinyint");
              string tem_sngaysinh=DataAcess.hsSqlTool.sGetSaveValue(sngaysinh,"datetime");
              string tem_sfax=DataAcess.hsSqlTool.sGetSaveValue(sfax,"varchar");
              string tem_sdinhdanhimei=DataAcess.hsSqlTool.sGetSaveValue(sdinhdanhimei,"char");
              string tem_staikhoannganhang=DataAcess.hsSqlTool.sGetSaveValue(staikhoannganhang,"nvarchar");
              string tem_snganhang=DataAcess.hsSqlTool.sGetSaveValue(snganhang,"nvarchar");
              string tem_smasothue=DataAcess.hsSqlTool.sGetSaveValue(smasothue,"nvarchar");
              string tem_snguoilienhe=DataAcess.hsSqlTool.sGetSaveValue(snguoilienhe,"nvarchar");

             string sqlSave=" INSERT INTO KhachHang("+
                   "IdBenhNhan," 
        +                   "makhachhang," 
        +                   "tenkhachhang," 
        +                   "diachi," 
        +                   "dienthoai," 
        +                   "gioitinh," 
        +                   "ngaysinh," 
        +                   "fax," 
        +                   "dinhdanhimei," 
        +                   "taikhoannganhang," 
        +                   "nganhang," 
        +                   "masothue," 
        +                   "nguoilienhe) VALUES("
 +tem_sIdBenhNhan+","
 +tem_smakhachhang+","
 +tem_stenkhachhang+","
 +tem_sdiachi+","
 +tem_sdienthoai+","
 +tem_sgioitinh+","
 +tem_sngaysinh+","
 +tem_sfax+","
 +tem_sdinhdanhimei+","
 +tem_staikhoannganhang+","
 +tem_snganhang+","
 +tem_smasothue+","
 +tem_snguoilienhe +")";
             bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
          KhachHang newKhachHang= new KhachHang();
                 newKhachHang.IDKhachHang=GetTable( " SELECT TOP 1 IDKhachHang FROM KhachHang ORDER BY IDKhachHang DESC ").Rows[0][0].ToString();
              newKhachHang.IdBenhNhan=sIdBenhNhan;
              newKhachHang.makhachhang=smakhachhang;
              newKhachHang.tenkhachhang=stenkhachhang;
              newKhachHang.diachi=sdiachi;
              newKhachHang.dienthoai=sdienthoai;
              newKhachHang.gioitinh=sgioitinh;
              newKhachHang.ngaysinh=sngaysinh;
              newKhachHang.fax=sfax;
              newKhachHang.dinhdanhimei=sdinhdanhimei;
              newKhachHang.taikhoannganhang=staikhoannganhang;
              newKhachHang.nganhang=snganhang;
              newKhachHang.masothue=smasothue;
              newKhachHang.nguoilienhe=snguoilienhe;
            return newKhachHang; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sIdBenhNhan
                ,string smakhachhang
                ,string stenkhachhang
                ,string sdiachi
                ,string sdienthoai
                ,string sgioitinh
                ,string sngaysinh
                ,string sfax
                ,string sdinhdanhimei
                ,string staikhoannganhang
                ,string snganhang
                ,string smasothue
                ,string snguoilienhe
                ) 
 { 
              string tem_sIdBenhNhan=DataAcess.hsSqlTool.sGetSaveValue(sIdBenhNhan,"int");
              string tem_smakhachhang=DataAcess.hsSqlTool.sGetSaveValue(smakhachhang,"varchar");
              string tem_stenkhachhang=DataAcess.hsSqlTool.sGetSaveValue(stenkhachhang,"nvarchar");
              string tem_sdiachi=DataAcess.hsSqlTool.sGetSaveValue(sdiachi,"nvarchar");
              string tem_sdienthoai=DataAcess.hsSqlTool.sGetSaveValue(sdienthoai,"varchar");
              string tem_sgioitinh=DataAcess.hsSqlTool.sGetSaveValue(sgioitinh,"tinyint");
              string tem_sngaysinh=DataAcess.hsSqlTool.sGetSaveValue(sngaysinh,"datetime");
              string tem_sfax=DataAcess.hsSqlTool.sGetSaveValue(sfax,"varchar");
              string tem_sdinhdanhimei=DataAcess.hsSqlTool.sGetSaveValue(sdinhdanhimei,"char");
              string tem_staikhoannganhang=DataAcess.hsSqlTool.sGetSaveValue(staikhoannganhang,"nvarchar");
              string tem_snganhang=DataAcess.hsSqlTool.sGetSaveValue(snganhang,"nvarchar");
              string tem_smasothue=DataAcess.hsSqlTool.sGetSaveValue(smasothue,"nvarchar");
              string tem_snguoilienhe=DataAcess.hsSqlTool.sGetSaveValue(snguoilienhe,"nvarchar");

 string sqlSave=" UPDATE KhachHang SET "+"IdBenhNhan ="+tem_sIdBenhNhan+","
 +"makhachhang ="+tem_smakhachhang+","
 +"tenkhachhang ="+tem_stenkhachhang+","
 +"diachi ="+tem_sdiachi+","
 +"dienthoai ="+tem_sdienthoai+","
 +"gioitinh ="+tem_sgioitinh+","
 +"ngaysinh ="+tem_sngaysinh+","
 +"fax ="+tem_sfax+","
 +"dinhdanhimei ="+tem_sdinhdanhimei+","
 +"taikhoannganhang ="+tem_staikhoannganhang+","
 +"nganhang ="+tem_snganhang+","
 +"masothue ="+tem_smasothue+","
 +"nguoilienhe ="+tem_snguoilienhe+" WHERE IDKhachHang="+DataAcess.hsSqlTool.sGetSaveValue(this.IDKhachHang,"int identity");;
              bool OK = Exec(sqlSave)>=1?true:false;
           if (OK) 
           { 
                this.IdBenhNhan=sIdBenhNhan;
                this.makhachhang=smakhachhang;
                this.tenkhachhang=stenkhachhang;
                this.diachi=sdiachi;
                this.dienthoai=sdienthoai;
                this.gioitinh=sgioitinh;
                this.ngaysinh=sngaysinh;
                this.fax=sfax;
                this.dinhdanhimei=sdinhdanhimei;
                this.taikhoannganhang=staikhoannganhang;
                this.nganhang=snganhang;
                this.masothue=smasothue;
                this.nguoilienhe=snguoilienhe;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_IDKhachHang(string sIDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET IDKhachHang='"+ sIDKhachHang+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IDKhachHang=sIDKhachHang;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IdBenhNhan(string sIdBenhNhan)
{
    string sqlSave= " UPDATE KhachHang SET IdBenhNhan='"+ sIdBenhNhan+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.IdBenhNhan=sIdBenhNhan;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_makhachhang(string smakhachhang)
{
    string sqlSave= " UPDATE KhachHang SET makhachhang=N'"+ smakhachhang+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.makhachhang=smakhachhang;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_tenkhachhang(string stenkhachhang)
{
    string sqlSave= " UPDATE KhachHang SET tenkhachhang=N'"+ stenkhachhang+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.tenkhachhang=stenkhachhang;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_diachi(string sdiachi)
{
    string sqlSave= " UPDATE KhachHang SET diachi=N'"+ sdiachi+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
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
    string sqlSave= " UPDATE KhachHang SET dienthoai=N'"+ sdienthoai+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dienthoai=sdienthoai;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_gioitinh(string sgioitinh)
{
    string sqlSave= " UPDATE KhachHang SET gioitinh='"+ sgioitinh+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.gioitinh=sgioitinh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ngaysinh(string sngaysinh)
{
    string sqlSave= " UPDATE KhachHang SET ngaysinh='"+ sngaysinh+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.ngaysinh=sngaysinh;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_fax(string sfax)
{
    string sqlSave= " UPDATE KhachHang SET fax=N'"+ sfax+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.fax=sfax;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_dinhdanhimei(string sdinhdanhimei)
{
    string sqlSave= " UPDATE KhachHang SET dinhdanhimei=N'"+ sdinhdanhimei+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.dinhdanhimei=sdinhdanhimei;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_taikhoannganhang(string staikhoannganhang)
{
    string sqlSave= " UPDATE KhachHang SET taikhoannganhang=N'"+ staikhoannganhang+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
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
    string sqlSave= " UPDATE KhachHang SET nganhang=N'"+ snganhang+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
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
    string sqlSave= " UPDATE KhachHang SET masothue=N'"+ smasothue+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.masothue=smasothue;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_nguoilienhe(string snguoilienhe)
{
    string sqlSave= " UPDATE KhachHang SET nguoilienhe=N'"+ snguoilienhe+ "' WHERE IDKhachHang='"+ this.IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 if(OK)
 {
    this.nguoilienhe=snguoilienhe;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_IdBenhNhan(string sIdBenhNhan,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET IdBenhNhan='"+sIdBenhNhan+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_makhachhang(string smakhachhang,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET makhachhang='N"+smakhachhang+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_tenkhachhang(string stenkhachhang,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET tenkhachhang='N"+stenkhachhang+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_diachi(string sdiachi,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET diachi='N"+sdiachi+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dienthoai(string sdienthoai,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET dienthoai='N"+sdienthoai+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_gioitinh(string sgioitinh,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET gioitinh='"+sgioitinh+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ngaysinh(string sngaysinh,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET ngaysinh='"+sngaysinh+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_fax(string sfax,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET fax='N"+sfax+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_dinhdanhimei(string sdinhdanhimei,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET dinhdanhimei='N"+sdinhdanhimei+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_taikhoannganhang(string staikhoannganhang,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET taikhoannganhang='N"+staikhoannganhang+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_nganhang(string snganhang,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET nganhang='N"+snganhang+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_masothue(string smasothue,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET masothue='N"+smasothue+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_nguoilienhe(string snguoilienhe,string s_IDKhachHang)
{
    string sqlSave= " UPDATE KhachHang SET nguoilienhe='N"+snguoilienhe+"' WHERE IDKhachHang='"+ s_IDKhachHang+"' ";
 bool OK=Exec(sqlSave)>=1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM KhachHang " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_KhachHang;
   public static bool Change_dt_KhachHang = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_KhachHang()
   {
   if (dt_KhachHang == null || Change_dt_KhachHang == true)
   {
   dt_KhachHang = dtGetAll();
   Change_dt_KhachHang = true && AllowAutoChange ;
   }
   return dt_KhachHang;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

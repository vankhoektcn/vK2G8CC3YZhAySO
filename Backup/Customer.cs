using System;
 using System.Collections.Generic;
 using System.Text;
 using System.Data;
 using System.Data.SqlClient;
 using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace ExportToExcel
  { 
 public class Customer:  Connect { 
 public static string sTableName= "Customer"; 
   public string CusID;
   public string CusCode;
   public string CusName;
   public string RepName;
   public string CC_Name;
   public string DepartmentID;
   public string PositionID;
   public string CountryID;
   public string ProvineID;
   public string DistrictID;
   public string WardID;
   public string BlockID;
   public string StreetID;
   public string AddNo;
   public string Address;
   public string Tel;
   public string Email;
   public string TaxCode;
   public string Website;
   public string Fax;
   public string BussinessCode;
   public string AwardDate;
   public string AwardPlace;
   public string BankID;
   public string BankAccount;
   public string LinkCusID;
   public string EmplID;
   public string BrachID;
   public string ContactDate;
   public string Note;
   public string ManagerName;
   public string ResignName;
   public string IsIntermedia;
   public string IsSupplier;
   public string KindCustomerID;
   public string Status;
   public string IsTransfer;
   #region DataColumn Name ;
 public static  string cl_CusID="CusID" ;
 public static  string cl_CusID_VN="CusID";
 public static  string cl_CusCode="CusCode" ;
 public static  string cl_CusCode_VN="CusCode";
 public static  string cl_CusName="CusName" ;
 public static  string cl_CusName_VN="CusName";
 public static  string cl_RepName="RepName" ;
 public static  string cl_RepName_VN="RepName";
 public static  string cl_CC_Name="CC_Name" ;
 public static  string cl_CC_Name_VN="CC_Name";
 public static  string cl_DepartmentID="DepartmentID" ;
 public static  string cl_DepartmentID_VN="DepartmentID";
 public static  string cl_PositionID="PositionID" ;
 public static  string cl_PositionID_VN="PositionID";
 public static  string cl_CountryID="CountryID" ;
 public static  string cl_CountryID_VN="CountryID";
 public static  string cl_ProvineID="ProvineID" ;
 public static  string cl_ProvineID_VN="ProvineID";
 public static  string cl_DistrictID="DistrictID" ;
 public static  string cl_DistrictID_VN="DistrictID";
 public static  string cl_WardID="WardID" ;
 public static  string cl_WardID_VN="WardID";
 public static  string cl_BlockID="BlockID" ;
 public static  string cl_BlockID_VN="BlockID";
 public static  string cl_StreetID="StreetID" ;
 public static  string cl_StreetID_VN="StreetID";
 public static  string cl_AddNo="AddNo" ;
 public static  string cl_AddNo_VN="AddNo";
 public static  string cl_Address="Address" ;
 public static  string cl_Address_VN="Address";
 public static  string cl_Tel="Tel" ;
 public static  string cl_Tel_VN="Tel";
 public static  string cl_Email="Email" ;
 public static  string cl_Email_VN="Email";
 public static  string cl_TaxCode="TaxCode" ;
 public static  string cl_TaxCode_VN="TaxCode";
 public static  string cl_Website="Website" ;
 public static  string cl_Website_VN="Website";
 public static  string cl_Fax="Fax" ;
 public static  string cl_Fax_VN="Fax";
 public static  string cl_BussinessCode="BussinessCode" ;
 public static  string cl_BussinessCode_VN="BussinessCode";
 public static  string cl_AwardDate="AwardDate" ;
 public static  string cl_AwardDate_VN="AwardDate";
 public static  string cl_AwardPlace="AwardPlace" ;
 public static  string cl_AwardPlace_VN="AwardPlace";
 public static  string cl_BankID="BankID" ;
 public static  string cl_BankID_VN="BankID";
 public static  string cl_BankAccount="BankAccount" ;
 public static  string cl_BankAccount_VN="BankAccount";
 public static  string cl_LinkCusID="LinkCusID" ;
 public static  string cl_LinkCusID_VN="LinkCusID";
 public static  string cl_EmplID="EmplID" ;
 public static  string cl_EmplID_VN="EmplID";
 public static  string cl_BrachID="BrachID" ;
 public static  string cl_BrachID_VN="BrachID";
 public static  string cl_ContactDate="ContactDate" ;
 public static  string cl_ContactDate_VN="ContactDate";
 public static  string cl_Note="Note" ;
 public static  string cl_Note_VN="Note";
 public static  string cl_ManagerName="ManagerName" ;
 public static  string cl_ManagerName_VN="ManagerName";
 public static  string cl_ResignName="ResignName" ;
 public static  string cl_ResignName_VN="ResignName";
 public static  string cl_IsIntermedia="IsIntermedia" ;
 public static  string cl_IsIntermedia_VN="IsIntermedia";
 public static  string cl_IsSupplier="IsSupplier" ;
 public static  string cl_IsSupplier_VN="IsSupplier";
 public static  string cl_KindCustomerID="KindCustomerID" ;
 public static  string cl_KindCustomerID_VN="KindCustomerID";
 public static  string cl_Status="Status" ;
 public static  string cl_Status_VN="Status";
 public static  string cl_IsTransfer="IsTransfer" ;
 public static  string cl_IsTransfer_VN="IsTransfer";
 #endregion;
//───────────────────────────────────────────────────────────────────────────────────────
       public Customer() {}
//───────────────────────────────────────────────────────────────────────────────────────
       public Customer(
         string sCusID,
         string sCusCode,
         string sCusName,
         string sRepName,
         string sCC_Name,
         string sDepartmentID,
         string sPositionID,
         string sCountryID,
         string sProvineID,
         string sDistrictID,
         string sWardID,
         string sBlockID,
         string sStreetID,
         string sAddNo,
         string sAddress,
         string sTel,
         string sEmail,
         string sTaxCode,
         string sWebsite,
         string sFax,
         string sBussinessCode,
         string sAwardDate,
         string sAwardPlace,
         string sBankID,
         string sBankAccount,
         string sLinkCusID,
         string sEmplID,
         string sBrachID,
         string sContactDate,
         string sNote,
         string sManagerName,
         string sResignName,
         string sIsIntermedia,
         string sIsSupplier,
         string sKindCustomerID,
         string sStatus,
         string sIsTransfer){
         this.CusID= sCusID;
         this.CusCode= sCusCode;
         this.CusName= sCusName;
         this.RepName= sRepName;
         this.CC_Name= sCC_Name;
         this.DepartmentID= sDepartmentID;
         this.PositionID= sPositionID;
         this.CountryID= sCountryID;
         this.ProvineID= sProvineID;
         this.DistrictID= sDistrictID;
         this.WardID= sWardID;
         this.BlockID= sBlockID;
         this.StreetID= sStreetID;
         this.AddNo= sAddNo;
         this.Address= sAddress;
         this.Tel= sTel;
         this.Email= sEmail;
         this.TaxCode= sTaxCode;
         this.Website= sWebsite;
         this.Fax= sFax;
         this.BussinessCode= sBussinessCode;
         this.AwardDate= sAwardDate;
         this.AwardPlace= sAwardPlace;
         this.BankID= sBankID;
         this.BankAccount= sBankAccount;
         this.LinkCusID= sLinkCusID;
         this.EmplID= sEmplID;
         this.BrachID= sBrachID;
         this.ContactDate= sContactDate;
         this.Note= sNote;
         this.ManagerName= sManagerName;
         this.ResignName= sResignName;
         this.IsIntermedia= sIsIntermedia;
         this.IsSupplier= sIsSupplier;
         this.KindCustomerID= sKindCustomerID;
         this.Status= sStatus;
         this.IsTransfer= sIsTransfer;
}
//───────────────────────────────────────────────────────────────────────────────────────
       public static Customer Create_Customer ( string sCusID  ){
    DataTable dt=dtSearchByCusID(sCusID) ;
    if(dt!=null && dt.Rows.Count>0) 
      return new Customer(dt.DefaultView,0);
      return null;
}
//───────────────────────────────────────────────────────────────────────────────────────
   private static string s_Select()
    {
   return " SELECT T.* FROM Customer AS T";
    }
//───────────────────────────────────────────────────────────────────────────────────────
 public Customer( DataView dv,int pos)
{
         this.CusID= dv[pos][0].ToString();
         this.CusCode= dv[pos][1].ToString();
         this.CusName= dv[pos][2].ToString();
         this.RepName= dv[pos][3].ToString();
         this.CC_Name= dv[pos][4].ToString();
         this.DepartmentID= dv[pos][5].ToString();
         this.PositionID= dv[pos][6].ToString();
         this.CountryID= dv[pos][7].ToString();
         this.ProvineID= dv[pos][8].ToString();
         this.DistrictID= dv[pos][9].ToString();
         this.WardID= dv[pos][10].ToString();
         this.BlockID= dv[pos][11].ToString();
         this.StreetID= dv[pos][12].ToString();
         this.AddNo= dv[pos][13].ToString();
         this.Address= dv[pos][14].ToString();
         this.Tel= dv[pos][15].ToString();
         this.Email= dv[pos][16].ToString();
         this.TaxCode= dv[pos][17].ToString();
         this.Website= dv[pos][18].ToString();
         this.Fax= dv[pos][19].ToString();
         this.BussinessCode= dv[pos][20].ToString();
         this.AwardDate= dv[pos][21].ToString();
         this.AwardPlace= dv[pos][22].ToString();
         this.BankID= dv[pos][23].ToString();
         this.BankAccount= dv[pos][24].ToString();
         this.LinkCusID= dv[pos][25].ToString();
         this.EmplID= dv[pos][26].ToString();
         this.BrachID= dv[pos][27].ToString();
         this.ContactDate= dv[pos][28].ToString();
         this.Note= dv[pos][29].ToString();
         this.ManagerName= dv[pos][30].ToString();
         this.ResignName= dv[pos][31].ToString();
         this.IsIntermedia= dv[pos][32].ToString();
         this.IsSupplier= dv[pos][33].ToString();
         this.KindCustomerID= dv[pos][34].ToString();
         this.Status= dv[pos][35].ToString();
         this.IsTransfer= dv[pos][36].ToString();
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCusID(string sCusID)
{
          string sqlSelect= s_Select()+ " WHERE CusID  ="+ sCusID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCusID(string sCusID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CusID"+ sMatch +sCusID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCusCode(string sCusCode)
{
          string sqlSelect= s_Select()+ " WHERE CusCode  Like N'%"+ sCusCode + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCusName(string sCusName)
{
          string sqlSelect= s_Select()+ " WHERE CusName  Like N'%"+ sCusName + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByRepName(string sRepName)
{
          string sqlSelect= s_Select()+ " WHERE RepName  Like N'%"+ sRepName + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCC_Name(string sCC_Name)
{
          string sqlSelect= s_Select()+ " WHERE CC_Name  Like N'%"+ sCC_Name + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDepartmentID(string sDepartmentID)
{
          string sqlSelect= s_Select()+ " WHERE DepartmentID  ="+ sDepartmentID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDepartmentID(string sDepartmentID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DepartmentID"+ sMatch +sDepartmentID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPositionID(string sPositionID)
{
          string sqlSelect= s_Select()+ " WHERE PositionID  ="+ sPositionID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByPositionID(string sPositionID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE PositionID"+ sMatch +sPositionID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCountryID(string sCountryID)
{
          string sqlSelect= s_Select()+ " WHERE CountryID  ="+ sCountryID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByCountryID(string sCountryID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE CountryID"+ sMatch +sCountryID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByProvineID(string sProvineID)
{
          string sqlSelect= s_Select()+ " WHERE ProvineID  ="+ sProvineID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByProvineID(string sProvineID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ProvineID"+ sMatch +sProvineID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDistrictID(string sDistrictID)
{
          string sqlSelect= s_Select()+ " WHERE DistrictID  ="+ sDistrictID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByDistrictID(string sDistrictID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE DistrictID"+ sMatch +sDistrictID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByWardID(string sWardID)
{
          string sqlSelect= s_Select()+ " WHERE WardID  ="+ sWardID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByWardID(string sWardID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE WardID"+ sMatch +sWardID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBlockID(string sBlockID)
{
          string sqlSelect= s_Select()+ " WHERE BlockID  ="+ sBlockID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBlockID(string sBlockID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BlockID"+ sMatch +sBlockID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByStreetID(string sStreetID)
{
          string sqlSelect= s_Select()+ " WHERE StreetID  ="+ sStreetID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByStreetID(string sStreetID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE StreetID"+ sMatch +sStreetID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByAddNo(string sAddNo)
{
          string sqlSelect= s_Select()+ " WHERE AddNo  Like N'%"+ sAddNo + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByAddress(string sAddress)
{
          string sqlSelect= s_Select()+ " WHERE Address  Like N'%"+ sAddress + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTel(string sTel)
{
          string sqlSelect= s_Select()+ " WHERE Tel  Like N'%"+ sTel + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByEmail(string sEmail)
{
          string sqlSelect= s_Select()+ " WHERE Email  Like N'%"+ sEmail + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByTaxCode(string sTaxCode)
{
          string sqlSelect= s_Select()+ " WHERE TaxCode  Like N'%"+ sTaxCode + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByWebsite(string sWebsite)
{
          string sqlSelect= s_Select()+ " WHERE Website  Like N'%"+ sWebsite + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByFax(string sFax)
{
          string sqlSelect= s_Select()+ " WHERE Fax  Like N'%"+ sFax + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBussinessCode(string sBussinessCode)
{
          string sqlSelect= s_Select()+ " WHERE BussinessCode  Like N'%"+ sBussinessCode + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByAwardDate(string sAwardDate)
{
          string sqlSelect= s_Select()+ " WHERE AwardDate  ="+ sAwardDate + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByAwardDate(string sAwardDate,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE AwardDate"+ sMatch +sAwardDate + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByAwardPlace(string sAwardPlace)
{
          string sqlSelect= s_Select()+ " WHERE AwardPlace  Like N'%"+ sAwardPlace + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBankID(string sBankID)
{
          string sqlSelect= s_Select()+ " WHERE BankID  ="+ sBankID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBankID(string sBankID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BankID"+ sMatch +sBankID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBankAccount(string sBankAccount)
{
          string sqlSelect= s_Select()+ " WHERE BankAccount  Like N'%"+ sBankAccount + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLinkCusID(string sLinkCusID)
{
          string sqlSelect= s_Select()+ " WHERE LinkCusID  ="+ sLinkCusID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByLinkCusID(string sLinkCusID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE LinkCusID"+ sMatch +sLinkCusID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByEmplID(string sEmplID)
{
          string sqlSelect= s_Select()+ " WHERE EmplID  ="+ sEmplID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByEmplID(string sEmplID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE EmplID"+ sMatch +sEmplID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBrachID(string sBrachID)
{
          string sqlSelect= s_Select()+ " WHERE BrachID  ="+ sBrachID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByBrachID(string sBrachID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE BrachID"+ sMatch +sBrachID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByContactDate(string sContactDate)
{
          string sqlSelect= s_Select()+ " WHERE ContactDate  ="+ sContactDate + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByContactDate(string sContactDate,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE ContactDate"+ sMatch +sContactDate + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByNote(string sNote)
{
          string sqlSelect= s_Select()+ " WHERE Note  Like N'%"+ sNote + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByManagerName(string sManagerName)
{
          string sqlSelect= s_Select()+ " WHERE ManagerName  Like N'%"+ sManagerName + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByResignName(string sResignName)
{
          string sqlSelect= s_Select()+ " WHERE ResignName  Like N'%"+ sResignName + "%'"; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsIntermedia(string sIsIntermedia)
{
          string sqlSelect= s_Select()+ " WHERE IsIntermedia  ="+ sIsIntermedia + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsIntermedia(string sIsIntermedia,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IsIntermedia"+ sMatch +sIsIntermedia + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsSupplier(string sIsSupplier)
{
          string sqlSelect= s_Select()+ " WHERE IsSupplier  ="+ sIsSupplier + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsSupplier(string sIsSupplier,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IsSupplier"+ sMatch +sIsSupplier + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByKindCustomerID(string sKindCustomerID)
{
          string sqlSelect= s_Select()+ " WHERE KindCustomerID  ="+ sKindCustomerID + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByKindCustomerID(string sKindCustomerID,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE KindCustomerID"+ sMatch +sKindCustomerID + ""; 
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
 public static DataTable dtSearchByIsTransfer(string sIsTransfer)
{
          string sqlSelect= s_Select()+ " WHERE IsTransfer  ="+ sIsTransfer + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearchByIsTransfer(string sIsTransfer,string sMatch)
{
          string sqlSelect= s_Select()+ " WHERE IsTransfer"+ sMatch +sIsTransfer + ""; 
          DataTable dt=GetTable(sqlSelect) ;
          return dt; 
 }//───────────────────────────────────────────────────────────────────────────────────────
 public static DataTable dtSearch( string sCusID
            , string sCusCode
            , string sCusName
            , string sRepName
            , string sCC_Name
            , string sDepartmentID
            , string sPositionID
            , string sCountryID
            , string sProvineID
            , string sDistrictID
            , string sWardID
            , string sBlockID
            , string sStreetID
            , string sAddNo
            , string sAddress
            , string sTel
            , string sEmail
            , string sTaxCode
            , string sWebsite
            , string sFax
            , string sBussinessCode
            , string sAwardDate
            , string sAwardPlace
            , string sBankID
            , string sBankAccount
            , string sLinkCusID
            , string sEmplID
            , string sBrachID
            , string sContactDate
            , string sNote
            , string sManagerName
            , string sResignName
            , string sIsIntermedia
            , string sIsSupplier
            , string sKindCustomerID
            , string sStatus
            , string sIsTransfer
            )
 {
       string sqlselect=s_Select() + " WHERE" ;
      if (sCusID!=null && sCusID!="") 
            sqlselect +=" AND CusID =" + sCusID ;
      if (sCusCode!=null && sCusCode!="") 
            sqlselect +=" AND CusCode LIKE N'%" + sCusCode +"%'" ;
      if (sCusName!=null && sCusName!="") 
            sqlselect +=" AND CusName LIKE N'%" + sCusName +"%'" ;
      if (sRepName!=null && sRepName!="") 
            sqlselect +=" AND RepName LIKE N'%" + sRepName +"%'" ;
      if (sCC_Name!=null && sCC_Name!="") 
            sqlselect +=" AND CC_Name LIKE N'%" + sCC_Name +"%'" ;
      if (sDepartmentID!=null && sDepartmentID!="") 
            sqlselect +=" AND DepartmentID =" + sDepartmentID ;
      if (sPositionID!=null && sPositionID!="") 
            sqlselect +=" AND PositionID =" + sPositionID ;
      if (sCountryID!=null && sCountryID!="") 
            sqlselect +=" AND CountryID =" + sCountryID ;
      if (sProvineID!=null && sProvineID!="") 
            sqlselect +=" AND ProvineID =" + sProvineID ;
      if (sDistrictID!=null && sDistrictID!="") 
            sqlselect +=" AND DistrictID =" + sDistrictID ;
      if (sWardID!=null && sWardID!="") 
            sqlselect +=" AND WardID =" + sWardID ;
      if (sBlockID!=null && sBlockID!="") 
            sqlselect +=" AND BlockID =" + sBlockID ;
      if (sStreetID!=null && sStreetID!="") 
            sqlselect +=" AND StreetID =" + sStreetID ;
      if (sAddNo!=null && sAddNo!="") 
            sqlselect +=" AND AddNo LIKE N'%" + sAddNo +"%'" ;
      if (sAddress!=null && sAddress!="") 
            sqlselect +=" AND Address LIKE N'%" + sAddress +"%'" ;
      if (sTel!=null && sTel!="") 
            sqlselect +=" AND Tel LIKE N'%" + sTel +"%'" ;
      if (sEmail!=null && sEmail!="") 
            sqlselect +=" AND Email LIKE N'%" + sEmail +"%'" ;
      if (sTaxCode!=null && sTaxCode!="") 
            sqlselect +=" AND TaxCode LIKE N'%" + sTaxCode +"%'" ;
      if (sWebsite!=null && sWebsite!="") 
            sqlselect +=" AND Website LIKE N'%" + sWebsite +"%'" ;
      if (sFax!=null && sFax!="") 
            sqlselect +=" AND Fax LIKE N'%" + sFax +"%'" ;
      if (sBussinessCode!=null && sBussinessCode!="") 
            sqlselect +=" AND BussinessCode LIKE N'%" + sBussinessCode +"%'" ;
      if (sAwardDate!=null && sAwardDate!="") 
            sqlselect +=" AND AwardDate LIKE '%" + sAwardDate +"%'" ;
      if (sAwardPlace!=null && sAwardPlace!="") 
            sqlselect +=" AND AwardPlace LIKE N'%" + sAwardPlace +"%'" ;
      if (sBankID!=null && sBankID!="") 
            sqlselect +=" AND BankID =" + sBankID ;
      if (sBankAccount!=null && sBankAccount!="") 
            sqlselect +=" AND BankAccount LIKE N'%" + sBankAccount +"%'" ;
      if (sLinkCusID!=null && sLinkCusID!="") 
            sqlselect +=" AND LinkCusID =" + sLinkCusID ;
      if (sEmplID!=null && sEmplID!="") 
            sqlselect +=" AND EmplID =" + sEmplID ;
      if (sBrachID!=null && sBrachID!="") 
            sqlselect +=" AND BrachID =" + sBrachID ;
      if (sContactDate!=null && sContactDate!="") 
            sqlselect +=" AND ContactDate LIKE '%" + sContactDate +"%'" ;
      if (sNote!=null && sNote!="") 
            sqlselect +=" AND Note LIKE N'%" + sNote +"%'" ;
      if (sManagerName!=null && sManagerName!="") 
            sqlselect +=" AND ManagerName LIKE N'%" + sManagerName +"%'" ;
      if (sResignName!=null && sResignName!="") 
            sqlselect +=" AND ResignName LIKE N'%" + sResignName +"%'" ;
      if (sIsIntermedia!=null && sIsIntermedia!="") 
            sqlselect +=" AND IsIntermedia =" + sIsIntermedia ;
      if (sIsSupplier!=null && sIsSupplier!="") 
            sqlselect +=" AND IsSupplier =" + sIsSupplier ;
      if (sKindCustomerID!=null && sKindCustomerID!="") 
            sqlselect +=" AND KindCustomerID =" + sKindCustomerID ;
      if (sStatus!=null && sStatus!="") 
            sqlselect +=" AND Status =" + sStatus ;
      if (sIsTransfer!=null && sIsTransfer!="") 
            sqlselect +=" AND IsTransfer =" + sIsTransfer ;
   sqlselect=sqlselect.Replace("WHERE AND","WHERE");
   int n=sqlselect.IndexOf("WHERE");
   if(n==sqlselect.Length -5) sqlselect=sqlselect.Remove(n,5) ;
   return GetTable(sqlselect);
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static Customer Insert_Object(
string  sCusID
            ,string  sCusCode
            ,string  sCusName
            ,string  sRepName
            ,string  sCC_Name
            ,string  sDepartmentID
            ,string  sPositionID
            ,string  sCountryID
            ,string  sProvineID
            ,string  sDistrictID
            ,string  sWardID
            ,string  sBlockID
            ,string  sStreetID
            ,string  sAddNo
            ,string  sAddress
            ,string  sTel
            ,string  sEmail
            ,string  sTaxCode
            ,string  sWebsite
            ,string  sFax
            ,string  sBussinessCode
            ,string  sAwardDate
            ,string  sAwardPlace
            ,string  sBankID
            ,string  sBankAccount
            ,string  sLinkCusID
            ,string  sEmplID
            ,string  sBrachID
            ,string  sContactDate
            ,string  sNote
            ,string  sManagerName
            ,string  sResignName
            ,string  sIsIntermedia
            ,string  sIsSupplier
            ,string  sKindCustomerID
            ,string  sStatus
            ,string  sIsTransfer
            ) 
 { 
              string tem_sCusID=DataAcess.hsSqlTool.sGetSaveValue(sCusID,"bigint");
              string tem_sCusCode=DataAcess.hsSqlTool.sGetSaveValue(sCusCode,"nvarchar");
              string tem_sCusName=DataAcess.hsSqlTool.sGetSaveValue(sCusName,"nvarchar");
              string tem_sRepName=DataAcess.hsSqlTool.sGetSaveValue(sRepName,"nvarchar");
              string tem_sCC_Name=DataAcess.hsSqlTool.sGetSaveValue(sCC_Name,"nvarchar");
              string tem_sDepartmentID=DataAcess.hsSqlTool.sGetSaveValue(sDepartmentID,"bigint");
              string tem_sPositionID=DataAcess.hsSqlTool.sGetSaveValue(sPositionID,"bigint");
              string tem_sCountryID=DataAcess.hsSqlTool.sGetSaveValue(sCountryID,"bigint");
              string tem_sProvineID=DataAcess.hsSqlTool.sGetSaveValue(sProvineID,"bigint");
              string tem_sDistrictID=DataAcess.hsSqlTool.sGetSaveValue(sDistrictID,"bigint");
              string tem_sWardID=DataAcess.hsSqlTool.sGetSaveValue(sWardID,"bigint");
              string tem_sBlockID=DataAcess.hsSqlTool.sGetSaveValue(sBlockID,"bigint");
              string tem_sStreetID=DataAcess.hsSqlTool.sGetSaveValue(sStreetID,"bigint");
              string tem_sAddNo=DataAcess.hsSqlTool.sGetSaveValue(sAddNo,"nvarchar");
              string tem_sAddress=DataAcess.hsSqlTool.sGetSaveValue(sAddress,"nvarchar");
              string tem_sTel=DataAcess.hsSqlTool.sGetSaveValue(sTel,"nvarchar");
              string tem_sEmail=DataAcess.hsSqlTool.sGetSaveValue(sEmail,"nvarchar");
              string tem_sTaxCode=DataAcess.hsSqlTool.sGetSaveValue(sTaxCode,"nvarchar");
              string tem_sWebsite=DataAcess.hsSqlTool.sGetSaveValue(sWebsite,"nvarchar");
              string tem_sFax=DataAcess.hsSqlTool.sGetSaveValue(sFax,"nvarchar");
              string tem_sBussinessCode=DataAcess.hsSqlTool.sGetSaveValue(sBussinessCode,"nvarchar");
              string tem_sAwardDate=DataAcess.hsSqlTool.sGetSaveValue(sAwardDate,"datetime");
              string tem_sAwardPlace=DataAcess.hsSqlTool.sGetSaveValue(sAwardPlace,"nvarchar");
              string tem_sBankID=DataAcess.hsSqlTool.sGetSaveValue(sBankID,"bigint");
              string tem_sBankAccount=DataAcess.hsSqlTool.sGetSaveValue(sBankAccount,"nvarchar");
              string tem_sLinkCusID=DataAcess.hsSqlTool.sGetSaveValue(sLinkCusID,"bigint");
              string tem_sEmplID=DataAcess.hsSqlTool.sGetSaveValue(sEmplID,"bigint");
              string tem_sBrachID=DataAcess.hsSqlTool.sGetSaveValue(sBrachID,"bigint");
              string tem_sContactDate=DataAcess.hsSqlTool.sGetSaveValue(sContactDate,"datetime");
              string tem_sNote=DataAcess.hsSqlTool.sGetSaveValue(sNote,"nvarchar");
              string tem_sManagerName=DataAcess.hsSqlTool.sGetSaveValue(sManagerName,"nvarchar");
              string tem_sResignName=DataAcess.hsSqlTool.sGetSaveValue(sResignName,"nvarchar");
              string tem_sIsIntermedia=DataAcess.hsSqlTool.sGetSaveValue(sIsIntermedia,"bit");
              string tem_sIsSupplier=DataAcess.hsSqlTool.sGetSaveValue(sIsSupplier,"bit");
              string tem_sKindCustomerID=DataAcess.hsSqlTool.sGetSaveValue(sKindCustomerID,"bigint");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(sStatus,"bit");
              string tem_sIsTransfer=DataAcess.hsSqlTool.sGetSaveValue(sIsTransfer,"bit");

             string sqlSave=" INSERT INTO Customer("+
                   "CusID," 
        +                   "CusCode," 
        +                   "CusName," 
        +                   "RepName," 
        +                   "CC_Name," 
        +                   "DepartmentID," 
        +                   "PositionID," 
        +                   "CountryID," 
        +                   "ProvineID," 
        +                   "DistrictID," 
        +                   "WardID," 
        +                   "BlockID," 
        +                   "StreetID," 
        +                   "AddNo," 
        +                   "Address," 
        +                   "Tel," 
        +                   "Email," 
        +                   "TaxCode," 
        +                   "Website," 
        +                   "Fax," 
        +                   "BussinessCode," 
        +                   "AwardDate," 
        +                   "AwardPlace," 
        +                   "BankID," 
        +                   "BankAccount," 
        +                   "LinkCusID," 
        +                   "EmplID," 
        +                   "BrachID," 
        +                   "ContactDate," 
        +                   "Note," 
        +                   "ManagerName," 
        +                   "ResignName," 
        +                   "IsIntermedia," 
        +                   "IsSupplier," 
        +                   "KindCustomerID," 
        +                   "Status," 
        +                   "IsTransfer) VALUES("
 +tem_sCusID+","
 +tem_sCusCode+","
 +tem_sCusName+","
 +tem_sRepName+","
 +tem_sCC_Name+","
 +tem_sDepartmentID+","
 +tem_sPositionID+","
 +tem_sCountryID+","
 +tem_sProvineID+","
 +tem_sDistrictID+","
 +tem_sWardID+","
 +tem_sBlockID+","
 +tem_sStreetID+","
 +tem_sAddNo+","
 +tem_sAddress+","
 +tem_sTel+","
 +tem_sEmail+","
 +tem_sTaxCode+","
 +tem_sWebsite+","
 +tem_sFax+","
 +tem_sBussinessCode+","
 +tem_sAwardDate+","
 +tem_sAwardPlace+","
 +tem_sBankID+","
 +tem_sBankAccount+","
 +tem_sLinkCusID+","
 +tem_sEmplID+","
 +tem_sBrachID+","
 +tem_sContactDate+","
 +tem_sNote+","
 +tem_sManagerName+","
 +tem_sResignName+","
 +tem_sIsIntermedia+","
 +tem_sIsSupplier+","
 +tem_sKindCustomerID+","
 +tem_sStatus+","
 +tem_sIsTransfer +")";
             bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
          Customer newCustomer= new Customer();
              newCustomer.CusID=sCusID;
              newCustomer.CusCode=sCusCode;
              newCustomer.CusName=sCusName;
              newCustomer.RepName=sRepName;
              newCustomer.CC_Name=sCC_Name;
              newCustomer.DepartmentID=sDepartmentID;
              newCustomer.PositionID=sPositionID;
              newCustomer.CountryID=sCountryID;
              newCustomer.ProvineID=sProvineID;
              newCustomer.DistrictID=sDistrictID;
              newCustomer.WardID=sWardID;
              newCustomer.BlockID=sBlockID;
              newCustomer.StreetID=sStreetID;
              newCustomer.AddNo=sAddNo;
              newCustomer.Address=sAddress;
              newCustomer.Tel=sTel;
              newCustomer.Email=sEmail;
              newCustomer.TaxCode=sTaxCode;
              newCustomer.Website=sWebsite;
              newCustomer.Fax=sFax;
              newCustomer.BussinessCode=sBussinessCode;
              newCustomer.AwardDate=sAwardDate;
              newCustomer.AwardPlace=sAwardPlace;
              newCustomer.BankID=sBankID;
              newCustomer.BankAccount=sBankAccount;
              newCustomer.LinkCusID=sLinkCusID;
              newCustomer.EmplID=sEmplID;
              newCustomer.BrachID=sBrachID;
              newCustomer.ContactDate=sContactDate;
              newCustomer.Note=sNote;
              newCustomer.ManagerName=sManagerName;
              newCustomer.ResignName=sResignName;
              newCustomer.IsIntermedia=sIsIntermedia;
              newCustomer.IsSupplier=sIsSupplier;
              newCustomer.KindCustomerID=sKindCustomerID;
              newCustomer.Status=sStatus;
              newCustomer.IsTransfer=sIsTransfer;
            return newCustomer; 
           } 
           else return null ;
}
//───────────────────────────────────────────────────────────────────────────────────────
public bool  Save_Object(string sCusID
                ,string sCusCode
                ,string sCusName
                ,string sRepName
                ,string sCC_Name
                ,string sDepartmentID
                ,string sPositionID
                ,string sCountryID
                ,string sProvineID
                ,string sDistrictID
                ,string sWardID
                ,string sBlockID
                ,string sStreetID
                ,string sAddNo
                ,string sAddress
                ,string sTel
                ,string sEmail
                ,string sTaxCode
                ,string sWebsite
                ,string sFax
                ,string sBussinessCode
                ,string sAwardDate
                ,string sAwardPlace
                ,string sBankID
                ,string sBankAccount
                ,string sLinkCusID
                ,string sEmplID
                ,string sBrachID
                ,string sContactDate
                ,string sNote
                ,string sManagerName
                ,string sResignName
                ,string sIsIntermedia
                ,string sIsSupplier
                ,string sKindCustomerID
                ,string sStatus
                ,string sIsTransfer
                ) 
 { 
              string tem_sCusCode=DataAcess.hsSqlTool.sGetSaveValue(sCusCode,"nvarchar");
              string tem_sCusName=DataAcess.hsSqlTool.sGetSaveValue(sCusName,"nvarchar");
              string tem_sRepName=DataAcess.hsSqlTool.sGetSaveValue(sRepName,"nvarchar");
              string tem_sCC_Name=DataAcess.hsSqlTool.sGetSaveValue(sCC_Name,"nvarchar");
              string tem_sDepartmentID=DataAcess.hsSqlTool.sGetSaveValue(sDepartmentID,"bigint");
              string tem_sPositionID=DataAcess.hsSqlTool.sGetSaveValue(sPositionID,"bigint");
              string tem_sCountryID=DataAcess.hsSqlTool.sGetSaveValue(sCountryID,"bigint");
              string tem_sProvineID=DataAcess.hsSqlTool.sGetSaveValue(sProvineID,"bigint");
              string tem_sDistrictID=DataAcess.hsSqlTool.sGetSaveValue(sDistrictID,"bigint");
              string tem_sWardID=DataAcess.hsSqlTool.sGetSaveValue(sWardID,"bigint");
              string tem_sBlockID=DataAcess.hsSqlTool.sGetSaveValue(sBlockID,"bigint");
              string tem_sStreetID=DataAcess.hsSqlTool.sGetSaveValue(sStreetID,"bigint");
              string tem_sAddNo=DataAcess.hsSqlTool.sGetSaveValue(sAddNo,"nvarchar");
              string tem_sAddress=DataAcess.hsSqlTool.sGetSaveValue(sAddress,"nvarchar");
              string tem_sTel=DataAcess.hsSqlTool.sGetSaveValue(sTel,"nvarchar");
              string tem_sEmail=DataAcess.hsSqlTool.sGetSaveValue(sEmail,"nvarchar");
              string tem_sTaxCode=DataAcess.hsSqlTool.sGetSaveValue(sTaxCode,"nvarchar");
              string tem_sWebsite=DataAcess.hsSqlTool.sGetSaveValue(sWebsite,"nvarchar");
              string tem_sFax=DataAcess.hsSqlTool.sGetSaveValue(sFax,"nvarchar");
              string tem_sBussinessCode=DataAcess.hsSqlTool.sGetSaveValue(sBussinessCode,"nvarchar");
              string tem_sAwardDate=DataAcess.hsSqlTool.sGetSaveValue(sAwardDate,"datetime");
              string tem_sAwardPlace=DataAcess.hsSqlTool.sGetSaveValue(sAwardPlace,"nvarchar");
              string tem_sBankID=DataAcess.hsSqlTool.sGetSaveValue(sBankID,"bigint");
              string tem_sBankAccount=DataAcess.hsSqlTool.sGetSaveValue(sBankAccount,"nvarchar");
              string tem_sLinkCusID=DataAcess.hsSqlTool.sGetSaveValue(sLinkCusID,"bigint");
              string tem_sEmplID=DataAcess.hsSqlTool.sGetSaveValue(sEmplID,"bigint");
              string tem_sBrachID=DataAcess.hsSqlTool.sGetSaveValue(sBrachID,"bigint");
              string tem_sContactDate=DataAcess.hsSqlTool.sGetSaveValue(sContactDate,"datetime");
              string tem_sNote=DataAcess.hsSqlTool.sGetSaveValue(sNote,"nvarchar");
              string tem_sManagerName=DataAcess.hsSqlTool.sGetSaveValue(sManagerName,"nvarchar");
              string tem_sResignName=DataAcess.hsSqlTool.sGetSaveValue(sResignName,"nvarchar");
              string tem_sIsIntermedia=DataAcess.hsSqlTool.sGetSaveValue(sIsIntermedia,"bit");
              string tem_sIsSupplier=DataAcess.hsSqlTool.sGetSaveValue(sIsSupplier,"bit");
              string tem_sKindCustomerID=DataAcess.hsSqlTool.sGetSaveValue(sKindCustomerID,"bigint");
              string tem_sStatus=DataAcess.hsSqlTool.sGetSaveValue(sStatus,"bit");
              string tem_sIsTransfer=DataAcess.hsSqlTool.sGetSaveValue(sIsTransfer,"bit");

 string sqlSave=" UPDATE Customer SET "+"CusCode ="+tem_sCusCode+","
 +"CusName ="+tem_sCusName+","
 +"RepName ="+tem_sRepName+","
 +"CC_Name ="+tem_sCC_Name+","
 +"DepartmentID ="+tem_sDepartmentID+","
 +"PositionID ="+tem_sPositionID+","
 +"CountryID ="+tem_sCountryID+","
 +"ProvineID ="+tem_sProvineID+","
 +"DistrictID ="+tem_sDistrictID+","
 +"WardID ="+tem_sWardID+","
 +"BlockID ="+tem_sBlockID+","
 +"StreetID ="+tem_sStreetID+","
 +"AddNo ="+tem_sAddNo+","
 +"Address ="+tem_sAddress+","
 +"Tel ="+tem_sTel+","
 +"Email ="+tem_sEmail+","
 +"TaxCode ="+tem_sTaxCode+","
 +"Website ="+tem_sWebsite+","
 +"Fax ="+tem_sFax+","
 +"BussinessCode ="+tem_sBussinessCode+","
 +"AwardDate ="+tem_sAwardDate+","
 +"AwardPlace ="+tem_sAwardPlace+","
 +"BankID ="+tem_sBankID+","
 +"BankAccount ="+tem_sBankAccount+","
 +"LinkCusID ="+tem_sLinkCusID+","
 +"EmplID ="+tem_sEmplID+","
 +"BrachID ="+tem_sBrachID+","
 +"ContactDate ="+tem_sContactDate+","
 +"Note ="+tem_sNote+","
 +"ManagerName ="+tem_sManagerName+","
 +"ResignName ="+tem_sResignName+","
 +"IsIntermedia ="+tem_sIsIntermedia+","
 +"IsSupplier ="+tem_sIsSupplier+","
 +"KindCustomerID ="+tem_sKindCustomerID+","
 +"Status ="+tem_sStatus+","
 +"IsTransfer ="+tem_sIsTransfer+" WHERE CusID="+DataAcess.hsSqlTool.sGetSaveValue(this.CusID,"bigint");;
              bool OK = Exec(sqlSave)==1?true:false;
           if (OK) 
           { 
                this.CusCode=sCusCode;
                this.CusName=sCusName;
                this.RepName=sRepName;
                this.CC_Name=sCC_Name;
                this.DepartmentID=sDepartmentID;
                this.PositionID=sPositionID;
                this.CountryID=sCountryID;
                this.ProvineID=sProvineID;
                this.DistrictID=sDistrictID;
                this.WardID=sWardID;
                this.BlockID=sBlockID;
                this.StreetID=sStreetID;
                this.AddNo=sAddNo;
                this.Address=sAddress;
                this.Tel=sTel;
                this.Email=sEmail;
                this.TaxCode=sTaxCode;
                this.Website=sWebsite;
                this.Fax=sFax;
                this.BussinessCode=sBussinessCode;
                this.AwardDate=sAwardDate;
                this.AwardPlace=sAwardPlace;
                this.BankID=sBankID;
                this.BankAccount=sBankAccount;
                this.LinkCusID=sLinkCusID;
                this.EmplID=sEmplID;
                this.BrachID=sBrachID;
                this.ContactDate=sContactDate;
                this.Note=sNote;
                this.ManagerName=sManagerName;
                this.ResignName=sResignName;
                this.IsIntermedia=sIsIntermedia;
                this.IsSupplier=sIsSupplier;
                this.KindCustomerID=sKindCustomerID;
                this.Status=sStatus;
                this.IsTransfer=sIsTransfer;
           } 
 return OK;  }
//───────────────────────────────────────────────────────────────────────────────────────
 #region Update DataColumn  
 public bool Update_CusID(string sCusID)
{
    string sqlSave= " UPDATE Customer SET CusID='"+ sCusID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CusID=sCusID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CusCode(string sCusCode)
{
    string sqlSave= " UPDATE Customer SET CusCode='N"+ sCusCode+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CusCode=sCusCode;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CusName(string sCusName)
{
    string sqlSave= " UPDATE Customer SET CusName='N"+ sCusName+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CusName=sCusName;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_RepName(string sRepName)
{
    string sqlSave= " UPDATE Customer SET RepName='N"+ sRepName+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.RepName=sRepName;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CC_Name(string sCC_Name)
{
    string sqlSave= " UPDATE Customer SET CC_Name='N"+ sCC_Name+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CC_Name=sCC_Name;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DepartmentID(string sDepartmentID)
{
    string sqlSave= " UPDATE Customer SET DepartmentID='"+ sDepartmentID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DepartmentID=sDepartmentID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_PositionID(string sPositionID)
{
    string sqlSave= " UPDATE Customer SET PositionID='"+ sPositionID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.PositionID=sPositionID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_CountryID(string sCountryID)
{
    string sqlSave= " UPDATE Customer SET CountryID='"+ sCountryID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.CountryID=sCountryID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ProvineID(string sProvineID)
{
    string sqlSave= " UPDATE Customer SET ProvineID='"+ sProvineID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ProvineID=sProvineID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_DistrictID(string sDistrictID)
{
    string sqlSave= " UPDATE Customer SET DistrictID='"+ sDistrictID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.DistrictID=sDistrictID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_WardID(string sWardID)
{
    string sqlSave= " UPDATE Customer SET WardID='"+ sWardID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.WardID=sWardID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BlockID(string sBlockID)
{
    string sqlSave= " UPDATE Customer SET BlockID='"+ sBlockID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.BlockID=sBlockID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_StreetID(string sStreetID)
{
    string sqlSave= " UPDATE Customer SET StreetID='"+ sStreetID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.StreetID=sStreetID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_AddNo(string sAddNo)
{
    string sqlSave= " UPDATE Customer SET AddNo='N"+ sAddNo+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.AddNo=sAddNo;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Address(string sAddress)
{
    string sqlSave= " UPDATE Customer SET Address='N"+ sAddress+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Address=sAddress;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Tel(string sTel)
{
    string sqlSave= " UPDATE Customer SET Tel='N"+ sTel+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Tel=sTel;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Email(string sEmail)
{
    string sqlSave= " UPDATE Customer SET Email='N"+ sEmail+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Email=sEmail;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_TaxCode(string sTaxCode)
{
    string sqlSave= " UPDATE Customer SET TaxCode='N"+ sTaxCode+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.TaxCode=sTaxCode;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Website(string sWebsite)
{
    string sqlSave= " UPDATE Customer SET Website='N"+ sWebsite+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Website=sWebsite;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Fax(string sFax)
{
    string sqlSave= " UPDATE Customer SET Fax='N"+ sFax+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Fax=sFax;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BussinessCode(string sBussinessCode)
{
    string sqlSave= " UPDATE Customer SET BussinessCode='N"+ sBussinessCode+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.BussinessCode=sBussinessCode;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_AwardDate(string sAwardDate)
{
    string sqlSave= " UPDATE Customer SET AwardDate='"+ sAwardDate+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.AwardDate=sAwardDate;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_AwardPlace(string sAwardPlace)
{
    string sqlSave= " UPDATE Customer SET AwardPlace='N"+ sAwardPlace+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.AwardPlace=sAwardPlace;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BankID(string sBankID)
{
    string sqlSave= " UPDATE Customer SET BankID='"+ sBankID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.BankID=sBankID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BankAccount(string sBankAccount)
{
    string sqlSave= " UPDATE Customer SET BankAccount='N"+ sBankAccount+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.BankAccount=sBankAccount;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_LinkCusID(string sLinkCusID)
{
    string sqlSave= " UPDATE Customer SET LinkCusID='"+ sLinkCusID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.LinkCusID=sLinkCusID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_EmplID(string sEmplID)
{
    string sqlSave= " UPDATE Customer SET EmplID='"+ sEmplID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.EmplID=sEmplID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_BrachID(string sBrachID)
{
    string sqlSave= " UPDATE Customer SET BrachID='"+ sBrachID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.BrachID=sBrachID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ContactDate(string sContactDate)
{
    string sqlSave= " UPDATE Customer SET ContactDate='"+ sContactDate+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ContactDate=sContactDate;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Note(string sNote)
{
    string sqlSave= " UPDATE Customer SET Note='N"+ sNote+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Note=sNote;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ManagerName(string sManagerName)
{
    string sqlSave= " UPDATE Customer SET ManagerName='N"+ sManagerName+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ManagerName=sManagerName;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_ResignName(string sResignName)
{
    string sqlSave= " UPDATE Customer SET ResignName='N"+ sResignName+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.ResignName=sResignName;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsIntermedia(string sIsIntermedia)
{
    string sqlSave= " UPDATE Customer SET IsIntermedia='"+ sIsIntermedia+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IsIntermedia=sIsIntermedia;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsSupplier(string sIsSupplier)
{
    string sqlSave= " UPDATE Customer SET IsSupplier='"+ sIsSupplier+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IsSupplier=sIsSupplier;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_KindCustomerID(string sKindCustomerID)
{
    string sqlSave= " UPDATE Customer SET KindCustomerID='"+ sKindCustomerID+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.KindCustomerID=sKindCustomerID;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_Status(string sStatus)
{
    string sqlSave= " UPDATE Customer SET Status='"+ sStatus+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.Status=sStatus;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public bool Update_IsTransfer(string sIsTransfer)
{
    string sqlSave= " UPDATE Customer SET IsTransfer='"+ sIsTransfer+ "' WHERE CusID='"+ this.CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 if(OK)
 {
    this.IsTransfer=sIsTransfer;
 }
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 #region Update DataColumn  Static 
 public static bool Update_CusID(string sCusID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET CusID='"+sCusID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CusCode(string sCusCode,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET CusCode='N"+sCusCode+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CusName(string sCusName,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET CusName='N"+sCusName+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_RepName(string sRepName,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET RepName='N"+sRepName+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CC_Name(string sCC_Name,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET CC_Name='N"+sCC_Name+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DepartmentID(string sDepartmentID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET DepartmentID='"+sDepartmentID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_PositionID(string sPositionID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET PositionID='"+sPositionID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_CountryID(string sCountryID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET CountryID='"+sCountryID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ProvineID(string sProvineID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET ProvineID='"+sProvineID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_DistrictID(string sDistrictID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET DistrictID='"+sDistrictID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_WardID(string sWardID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET WardID='"+sWardID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BlockID(string sBlockID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET BlockID='"+sBlockID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_StreetID(string sStreetID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET StreetID='"+sStreetID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_AddNo(string sAddNo,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET AddNo='N"+sAddNo+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Address(string sAddress,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET Address='N"+sAddress+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Tel(string sTel,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET Tel='N"+sTel+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Email(string sEmail,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET Email='N"+sEmail+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_TaxCode(string sTaxCode,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET TaxCode='N"+sTaxCode+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Website(string sWebsite,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET Website='N"+sWebsite+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Fax(string sFax,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET Fax='N"+sFax+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BussinessCode(string sBussinessCode,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET BussinessCode='N"+sBussinessCode+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_AwardDate(string sAwardDate,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET AwardDate='"+sAwardDate+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_AwardPlace(string sAwardPlace,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET AwardPlace='N"+sAwardPlace+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BankID(string sBankID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET BankID='"+sBankID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BankAccount(string sBankAccount,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET BankAccount='N"+sBankAccount+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_LinkCusID(string sLinkCusID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET LinkCusID='"+sLinkCusID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_EmplID(string sEmplID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET EmplID='"+sEmplID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_BrachID(string sBrachID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET BrachID='"+sBrachID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ContactDate(string sContactDate,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET ContactDate='"+sContactDate+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Note(string sNote,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET Note='N"+sNote+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ManagerName(string sManagerName,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET ManagerName='N"+sManagerName+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_ResignName(string sResignName,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET ResignName='N"+sResignName+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsIntermedia(string sIsIntermedia,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET IsIntermedia='"+sIsIntermedia+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsSupplier(string sIsSupplier,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET IsSupplier='"+sIsSupplier+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_KindCustomerID(string sKindCustomerID,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET KindCustomerID='"+sKindCustomerID+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_Status(string sStatus,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET Status='"+sStatus+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
 public static bool Update_IsTransfer(string sIsTransfer,string s_CusID)
{
    string sqlSave= " UPDATE Customer SET IsTransfer='"+sIsTransfer+"' WHERE CusID='"+ s_CusID+"' ";
 bool OK=Exec(sqlSave)==1?true:false;
 return OK;
}
//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
 #endregion
 public static DataTable dtGetAll() 
 {
        string sqlSelect=" SELECT * FROM Customer " ;
        return GetTable(sqlSelect) ;
 }
//───────────────────────────────────────────────────────────────────────────────────────
   private static DataTable dt_Customer;
   public static bool Change_dt_Customer = true;
   public static bool AllowAutoChange = true;
   public static DataTable get_Customer()
   {
   if (dt_Customer == null || Change_dt_Customer == true)
   {
   dt_Customer = dtGetAll();
   Change_dt_Customer = true && AllowAutoChange ;
   }
   return dt_Customer;
   }
   //───────────────────────────────────────────────────────────────────────────────────────
}  
 } 

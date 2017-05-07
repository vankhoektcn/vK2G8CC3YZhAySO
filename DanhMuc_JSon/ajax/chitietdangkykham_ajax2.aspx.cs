 using System;
 using System.Data;
 using System.Configuration;
 using System.Collections;
 using System.Web;
 using System.Web.Security;
 using System.Web.UI;
 using System.Web.UI.WebControls;
 using System.Web.UI.WebControls.WebParts;
 using System.Web.UI.HtmlControls;
 using System.Text;
 
 public partial class chitietdangkykham_ajax : System.Web.UI.Page
 {
     protected DataProcess s_chitietdangkykham()
     {
             DataProcess chitietdangkykham = new DataProcess("chitietdangkykham"); 
             chitietdangkykham.data("idchitietdangkykham",Request.QueryString["TENKHOAchinh"]);
             chitietdangkykham.data("iddangkykham",Request.QueryString["iddangkykham"]);
             chitietdangkykham.data("soluong",Request.QueryString["soluong"]);
             chitietdangkykham.data("dongia",Request.QueryString["dongia"]);
             chitietdangkykham.data("baohiemchi",Request.QueryString["baohiemchi"]);
             chitietdangkykham.data("giamgia",Request.QueryString["giamgia"]);
             chitietdangkykham.data("idbacsi",Request.QueryString["idbacsi"]);
             chitietdangkykham.data("dahuy",Request.QueryString["dahuy"]);
             chitietdangkykham.data("dakham",Request.QueryString["dakham"]);
             chitietdangkykham.data("idnguoithu",Request.QueryString["idnguoithu"]);
             chitietdangkykham.data("iddieuduong",Request.QueryString["iddieuduong"]);
             chitietdangkykham.data("PhongSo",Request.QueryString["PhongSo"]);
             chitietdangkykham.data("SoTT",Request.QueryString["SoTT"]);
             chitietdangkykham.data("IsDaThu",Request.QueryString["IsDaThu"]);
             chitietdangkykham.data("SLBNCho",Request.QueryString["SLBNCho"]);
             chitietdangkykham.data("SLBNDK",Request.QueryString["SLBNDK"]);
             chitietdangkykham.data("IdKhamBenhCD",Request.QueryString["IdKhamBenhCD"]);
             chitietdangkykham.data("isNotThuPhiCapCuu",Request.QueryString["isNotThuPhiCapCuu"]);
             chitietdangkykham.data("ishoantatcls",Request.QueryString["ishoantatcls"]);
             chitietdangkykham.data("IsHoanTraCT",Request.QueryString["IsHoanTraCT"]);
             chitietdangkykham.data("BHTra",Request.QueryString["BHTra"]);
             chitietdangkykham.data("BNDaTra",Request.QueryString["BNDaTra"]);
             chitietdangkykham.data("BNTongPhaiTra",Request.QueryString["BNTongPhaiTra"]);
             chitietdangkykham.data("BNTra",Request.QueryString["BNTra"]);
             chitietdangkykham.data("DonGiaBH",Request.QueryString["DonGiaBH"]);
             chitietdangkykham.data("DonGiaDV",Request.QueryString["DonGiaDV"]);
             chitietdangkykham.data("IsBHYT",Request.QueryString["IsBHYT"]);
             chitietdangkykham.data("ISBNDaTra",Request.QueryString["ISBNDaTra"]);
             chitietdangkykham.data("NGAYTINHBH_THUC",Request.QueryString["NGAYTINHBH_THUC"]);
             chitietdangkykham.data("PhuThuBH",Request.QueryString["PhuThuBH"]);
             chitietdangkykham.data("PrevBNTra",Request.QueryString["PrevBNTra"]);
             chitietdangkykham.data("ThanhTienBH",Request.QueryString["ThanhTienBH"]);
             chitietdangkykham.data("ThanhTienDV",Request.QueryString["ThanhTienDV"]);
             chitietdangkykham.data("iskhongkham",Request.QueryString["iskhongkham"]);
             chitietdangkykham.data("NGAYDANGKY_CHITIET",Request.QueryString["NGAYDANGKY_CHITIET"]);
             chitietdangkykham.data("IDBENHNHAN_CHITIET",Request.QueryString["IDBENHNHAN_CHITIET"]);
             chitietdangkykham.data("IsCoDKCLS",Request.QueryString["IsCoDKCLS"]);
             chitietdangkykham.data("NgayTraKQCLS",Request.QueryString["NgayTraKQCLS"]);
            return chitietdangkykham;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_chitietdangkykham();break ;
             case "xoa": Xoa_chitietdangkykham(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_chitietdangkykham()
     {
         try
         {
                DataProcess process = s_chitietdangkykham();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idchitietdangkykham"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_chitietdangkykham()
     {
         try
         {
              DataProcess process = s_chitietdangkykham();
             if (!string.IsNullOrEmpty(process.getData("idchitietdangkykham")))
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idchitietdangkykham"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idchitietdangkykham"));
                 return;
             }
           }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
     private void TimKiem()
     {
         string IDBENHBHDONGTIEN = Request.QueryString["IDBENHBHDONGTIEN"];
         if (IDBENHBHDONGTIEN == null) IDBENHBHDONGTIEN = "0";

        bool search = Userlogin_new.HavePermision(this, "chitietdangkykham_Search");
        if(search){
                     bool add = Userlogin_new.HavePermision(this, "chitietdangkykham_Add");
                     bool delete = Userlogin_new.HavePermision(this, "chitietdangkykham_Delete");
                      bool edit = Userlogin_new.HavePermision(this, "chitietdangkykham_Edit");
                                    DataProcess process = s_chitietdangkykham();
                             DataTable table =DataAcess.Connect.GetTable(@"select STT=row_number() over (order by T.idchitietdangkykham),T.*
                                                    ,TENKHOA=P.TENPHONGKHAMBENH
                                                    ,TENPHONG=DBO.HS_TENPHONG(T.PHONGID)
                                                   from chitietdangkykham T
                                                      LEFT JOIN PHONGKHAMBENH P ON T.idkhoa=P.IDPHONGKHAMBENH
                                                      INNER JOIN DANGKYKHAM DK ON T.IDDANGKYKHAM=DK.IDDANGKYKHAM
                              where             DK.IDBENHBHDONGTIEN=" + IDBENHBHDONGTIEN+@"
					                           AND ISNULL(T.DAHUY,0)=0
                                              AND ISNULL(T.THANHTIENDV,0)>0");
                         string head = "\"\":\"\""
                             + ",\"TENKHOA\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENKHOA") + "\""
                             + ",\"TENPHONG\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENPHONG") + "\""
                             + ",\"SOLUONG\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "\""
                             + ",\"DONGIADV\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("DonGiaDV") + "\""
                             + ",\"THANHTIENDV\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("ThanhTienDV") + "\""
                             + ",\"ISNOTTHUPHICAPCUU\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("isNotThuPhiCapCuu") + "\""
                             + ",\"ISBHYT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISBHYT") + "\""
                             + ",\"DONGIABH\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("DonGiaBH") + "\""
                             + ",\"THANHTIENBH\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("ThanhTienBH") + "\""
                             + ",\"BHTRA\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("BHTra") + "\""
                             + ",\"BNTRA\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("BNTra") + "\""
                    + "";
                             Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete,head));
                 }
                 else{
                     Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
                 }
                 }
 }
 
 

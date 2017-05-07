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
 
 public partial class KB_ChiTietGiuongBN_ajax : System.Web.UI.Page
 {
     protected DataProcess s_KB_ChiTietGiuongBN()
     {
             DataProcess KB_ChiTietGiuongBN = new DataProcess("KB_ChiTietGiuongBN"); 
             KB_ChiTietGiuongBN.data("IdChiTietGiuongBN",Request.QueryString["idkhoachinh"]);
             KB_ChiTietGiuongBN.data("TuNgay",Request.QueryString["TuNgay"]);
             KB_ChiTietGiuongBN.data("DenNgay",Request.QueryString["DenNgay"]);
             KB_ChiTietGiuongBN.data("IsBHYT",Request.QueryString["IsBHYT"]);
             KB_ChiTietGiuongBN.data("IdGiuong",Request.QueryString["IdGiuong"]);
             KB_ChiTietGiuongBN.data("IdChiTietDangKyKham",Request.QueryString["IdChiTietDangKyKham"]);
             KB_ChiTietGiuongBN.data("SL",Request.QueryString["SL"]);
             KB_ChiTietGiuongBN.data("DonGiaDV",Request.QueryString["DonGiaDV"]);
             KB_ChiTietGiuongBN.data("ThanhTienDV",Request.QueryString["ThanhTienDV"]);
             KB_ChiTietGiuongBN.data("DonGiaBH",Request.QueryString["DonGiaBH"]);
             KB_ChiTietGiuongBN.data("ThanhTienBH",Request.QueryString["ThanhTienBH"]);
             KB_ChiTietGiuongBN.data("BHTra",Request.QueryString["BHTra"]);
             KB_ChiTietGiuongBN.data("BNTra",Request.QueryString["BNTra"]);
             KB_ChiTietGiuongBN.data("IsDaThu",Request.QueryString["IsDaThu"]);
             KB_ChiTietGiuongBN.data("idnoitru_G",Request.QueryString["idnoitru_G"]);
             KB_ChiTietGiuongBN.data("idkhoa",Request.QueryString["idkhoa"]);
             KB_ChiTietGiuongBN.data("PHUTHUBH",Request.QueryString["PHUTHUBH"]);
             KB_ChiTietGiuongBN.data("IDBENHBHDONGTIEN",Request.QueryString["IDBENHBHDONGTIEN"]);
            return KB_ChiTietGiuongBN;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_KB_ChiTietGiuongBN();break ;
             case "xoa": Xoa_KB_ChiTietGiuongBN(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_KB_ChiTietGiuongBN()
     {
         try
         {
                DataProcess process = s_KB_ChiTietGiuongBN();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IdChiTietGiuongBN"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_KB_ChiTietGiuongBN()
     {
         try
         {
              DataProcess process = s_KB_ChiTietGiuongBN();
             if (!string.IsNullOrEmpty(process.getData("IdChiTietGiuongBN")))
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IdChiTietGiuongBN"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IdChiTietGiuongBN"));
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
             bool search = Userlogin_new.HavePermision(this, "KB_ChiTietGiuongBN_Search");
            if(search){
             bool add = Userlogin_new.HavePermision(this, "KB_ChiTietGiuongBN_Add");
             bool delete = Userlogin_new.HavePermision(this, "KB_ChiTietGiuongBN_Delete");
              bool edit = Userlogin_new.HavePermision(this, "KB_ChiTietGiuongBN_Edit");
                DataProcess process = s_KB_ChiTietGiuongBN();
         process.EnablePaging = false;
         DataTable table = process.Search(@"select STT=row_number() over (order by G.IdChiTietGiuongBN),G.*
                                ,LOAIGIUONG=LG.TENLOAIGIUONG
                                ,TENKHOA=PKB.TENPHONGKHAMBENH
                               from KB_ChiTietGiuongBN G
                                    LEFT JOIN KB_GIUONG TG ON TG.GIUONGID = G.IDGIUONG
					                                    LEFT JOIN KB_PHONG P ON TG.IDPHONG= P.ID
					                                    LEFT JOIN HS_LOAIGIUONG LG ON TG.IDLOAIGIUONG=LG.IDLOAIGIUONG
					                                    INNER JOIN  chitietdangkykham ctt on ctt.idchitietdangkykham = g.idchitietdangkykham
					                                    INNER JOIN dangkykham dkk ON dkk.iddangkykham=ctt.iddangkykham
					                                    LEFT JOIN PHONGKHAMBENH PKB ON G.IDKHOA=PKB.IDPHONGKHAMBENH
			                                    WHERE dkk.idbenhbhdongtien=" + IDBENHBHDONGTIEN
                                          );
				   
     string head = "\"\":\"\""
         + ",\"TENKHOA\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENKHOA") + "\""
         + ",\"LOAIGIUONG\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("LOAIGIUONG") + "\""
         + ",\"TUNGAY\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay") + "\""
         + ",\"DENNGAY\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay") + "\""
         + ",\"SL\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL") + "\""
         + ",\"DONGIADV\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("DonGiaDV") + "\""
         + ",\"THANHTIENDV\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("ThanhTienDV") + "\""
         + ",\"ISBHYT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsBHYT") + "\""
         + ",\"DONGIABH\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("DonGiaBH") + "\""
         + ",\"THANHTIENBH\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("ThanhTienBH") + "\""
         + ",\"BHTRA\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("BHTra") + "\""
         + ",\"BNTRA\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("BNTra") + "\""
         + ",\"PHUTHUBH\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("PHUTHUBH") + "\""
+ "";
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete,head));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

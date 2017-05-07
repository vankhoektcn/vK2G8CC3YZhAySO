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
 
 public partial class khambenhcanlamsan_ajax : System.Web.UI.Page
 {
     protected DataProcess s_khambenhcanlamsan()
     {
             DataProcess khambenhcanlamsan = new DataProcess("khambenhcanlamsan"); 
             khambenhcanlamsan.data("idkhambenhcanlamsan",Request.QueryString["idkhoachinh"]);
             khambenhcanlamsan.data("idkhambenh",Request.QueryString["idkhambenh"]);
             khambenhcanlamsan.data("idcanlamsan",Request.QueryString["idcanlamsan"]);
             khambenhcanlamsan.data("dongia",Request.QueryString["dongia"]);
             khambenhcanlamsan.data("idbacsi",Request.QueryString["idbacsi"]);
             khambenhcanlamsan.data("dathu",Request.QueryString["dathu"]);
             khambenhcanlamsan.data("dakham",Request.QueryString["dakham"]);
             khambenhcanlamsan.data("ngaythu",Request.QueryString["ngaythu"]);
             khambenhcanlamsan.data("idnguoidung",Request.QueryString["idnguoidung"]);
             khambenhcanlamsan.data("ngaykham",Request.QueryString["ngaykham"]);
             khambenhcanlamsan.data("idbenhnhan",Request.QueryString["idbenhnhan"]);
             khambenhcanlamsan.data("tenBSChiDinh",Request.QueryString["tenBSChiDinh"]);
             khambenhcanlamsan.data("maphieuCLS",Request.QueryString["maphieuCLS"]);
             khambenhcanlamsan.data("thucthu",Request.QueryString["thucthu"]);
             khambenhcanlamsan.data("dahuy",Request.QueryString["dahuy"]);
             khambenhcanlamsan.data("soluong",Request.QueryString["soluong"]);
             khambenhcanlamsan.data("chietkhau",Request.QueryString["chietkhau"]);
             khambenhcanlamsan.data("thanhtien",Request.QueryString["thanhtien"]);
             khambenhcanlamsan.data("IdNguoiThu",Request.QueryString["IdNguoiThu"]);
             khambenhcanlamsan.data("BHTra",Request.QueryString["BHTra"]);
             khambenhcanlamsan.data("GhiChu",Request.QueryString["GhiChu"]);
             khambenhcanlamsan.data("LoaiKhamID",Request.QueryString["LoaiKhamID"]);
             khambenhcanlamsan.data("idkhoadangky",Request.QueryString["idkhoadangky"]);
             khambenhcanlamsan.data("sldakham",Request.QueryString["sldakham"]);
             khambenhcanlamsan.data("istieuphau",Request.QueryString["istieuphau"]);
             khambenhcanlamsan.data("isphauthuat",Request.QueryString["isphauthuat"]);
             khambenhcanlamsan.data("IsHoanTraCLS",Request.QueryString["IsHoanTraCLS"]);
             khambenhcanlamsan.data("BHYTTra",Request.QueryString["BHYTTra"]);
             khambenhcanlamsan.data("BNDaTra",Request.QueryString["BNDaTra"]);
             khambenhcanlamsan.data("BNTongPhaiTra",Request.QueryString["BNTongPhaiTra"]);
             khambenhcanlamsan.data("BNTra",Request.QueryString["BNTra"]);
             khambenhcanlamsan.data("DonGiaBH",Request.QueryString["DonGiaBH"]);
             khambenhcanlamsan.data("DonGiaDV",Request.QueryString["DonGiaDV"]);
             khambenhcanlamsan.data("IdChiTietPTT",Request.QueryString["IdChiTietPTT"]);
             khambenhcanlamsan.data("IsBHYT",Request.QueryString["IsBHYT"]);
             khambenhcanlamsan.data("ISBNDaTra",Request.QueryString["ISBNDaTra"]);
             khambenhcanlamsan.data("NgayQuayLai",Request.QueryString["NgayQuayLai"]);
             khambenhcanlamsan.data("NGAYTINHBH_THUC",Request.QueryString["NGAYTINHBH_THUC"]);
             khambenhcanlamsan.data("PhuThuBH",Request.QueryString["PhuThuBH"]);
             khambenhcanlamsan.data("PrevBNTra",Request.QueryString["PrevBNTra"]);
             khambenhcanlamsan.data("ThanhTienBH",Request.QueryString["ThanhTienBH"]);
             khambenhcanlamsan.data("ThanhTienDV",Request.QueryString["ThanhTienDV"]);
             khambenhcanlamsan.data("IDDANGKYCLS",Request.QueryString["IDDANGKYCLS"]);
             khambenhcanlamsan.data("IsDaDKK",Request.QueryString["IsDaDKK"]);
             khambenhcanlamsan.data("IdnhomInBV",Request.QueryString["IdnhomInBV"]);
             khambenhcanlamsan.data("IsBHYT_Save",Request.QueryString["IsBHYT_Save"]);
             khambenhcanlamsan.data("IDBENHBHDONGTIEN",Request.QueryString["IDBENHBHDONGTIEN"]);
             khambenhcanlamsan.data("TOP1_IDKHAMBENHCANLAMSAN",Request.QueryString["TOP1_IDKHAMBENHCANLAMSAN"]);
             khambenhcanlamsan.data("ISDATRAKQ",Request.QueryString["ISDATRAKQ"]);
             khambenhcanlamsan.data("THOIGIANTRAKQ",Request.QueryString["THOIGIANTRAKQ"]);
            return khambenhcanlamsan;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_khambenhcanlamsan();break ;
             case "xoa": Xoa_khambenhcanlamsan(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_khambenhcanlamsan()
     {
         try
         {
                DataProcess process = s_khambenhcanlamsan();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkhambenhcanlamsan"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_khambenhcanlamsan()
     {
         try
         {
              DataProcess process = s_khambenhcanlamsan();
             if (!string.IsNullOrEmpty(process.getData("idkhambenhcanlamsan")))
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkhambenhcanlamsan"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkhambenhcanlamsan"));
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

 bool search = Userlogin_new.HavePermision(this, "khambenhcanlamsan_Search");
if(search){
         bool add = Userlogin_new.HavePermision(this, "khambenhcanlamsan_Add");
         bool delete = Userlogin_new.HavePermision(this, "khambenhcanlamsan_Delete");
          bool edit = Userlogin_new.HavePermision(this, "khambenhcanlamsan_Edit");
                DataProcess process = s_khambenhcanlamsan();
         DataTable table = process.Search(@"select STT=row_number() over (order by T.idkhambenhcanlamsan),T.*
                               ,TENDICHVU=A.TENDICHVU
                               ,TENKHOA=B.TENPHONGKHAMBENH
                               from khambenhcanlamsan T
                                   LEFT JOIN BANGGIADICHVU A ON T.IDCANLAMSAN=A.IDBANGGIADICHVU
                                   LEFT JOIN KHAMBENH C ON T.IDKHAMBENH=C.IDKHAMBENH
                                   LEFT JOIN PHONGKHAMBENH B ON B.IDPHONGKHAMBENH=C.IDPHONGKHAMBENH
                                where T.IDBENHBHDONGTIEN=" + IDBENHBHDONGTIEN);
     string head = "\"\":\"\""
         + ",\"TENKHOA\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENKHOA") + "\""
         + ",\"TENDICHVU\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENDICHVU") + "\""
         + ",\"NGAYTHU\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythu") + "\""
         + ",\"SOLUONG\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "\""
         + ",\"DONGIADV\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("DonGiaDV") + "\""
         + ",\"THANHTIENDV\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("ThanhTienDV") + "\""
         + ",\"ISBHYT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsBHYT") + "\""
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
 
 

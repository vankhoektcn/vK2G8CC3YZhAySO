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
 
 public partial class chitietphieuxuatkho_ajax : System.Web.UI.Page
 {
     protected DataProcess s_chitietphieuxuatkho()
     {
             DataProcess chitietphieuxuatkho = new DataProcess("chitietphieuxuatkho"); 
             chitietphieuxuatkho.data("idchitietphieuxuat",Request.QueryString["idkhoachinh"]);
             chitietphieuxuatkho.data("idphieuxuat",Request.QueryString["idphieuxuat"]);
             chitietphieuxuatkho.data("idthuoc",Request.QueryString["idthuoc"]);
             chitietphieuxuatkho.data("soluong",Request.QueryString["soluong"]);
             chitietphieuxuatkho.data("dongia",Request.QueryString["dongia"]);
             chitietphieuxuatkho.data("idchitietphieunhapkho",Request.QueryString["idchitietphieunhapkho"]);
             chitietphieuxuatkho.data("idtu",Request.QueryString["idtu"]);
             chitietphieuxuatkho.data("idngan",Request.QueryString["idngan"]);
             chitietphieuxuatkho.data("sluongxuat",Request.QueryString["sluongxuat"]);
             chitietphieuxuatkho.data("thanhtien",Request.QueryString["thanhtien"]);
             chitietphieuxuatkho.data("thanhtientruocthue",Request.QueryString["thanhtientruocthue"]);
             chitietphieuxuatkho.data("tienthue",Request.QueryString["tienthue"]);
             chitietphieuxuatkho.data("chietkhau",Request.QueryString["chietkhau"]);
             chitietphieuxuatkho.data("giavon",Request.QueryString["giavon"]);
             chitietphieuxuatkho.data("tienvon",Request.QueryString["tienvon"]);
             chitietphieuxuatkho.data("tiensauchietkhau",Request.QueryString["tiensauchietkhau"]);
             chitietphieuxuatkho.data("tienchietkhau",Request.QueryString["tienchietkhau"]);
             chitietphieuxuatkho.data("IDCHITIETPHIEUYEUCAUXUATKHO",Request.QueryString["IDCHITIETPHIEUYEUCAUXUATKHO"]);
             chitietphieuxuatkho.data("tkkho",Request.QueryString["tkkho"]);
             chitietphieuxuatkho.data("tkco",Request.QueryString["tkco"]);
             chitietphieuxuatkho.data("idchitietbenhnhantoathuoc",Request.QueryString["idchitietbenhnhantoathuoc"]);
             chitietphieuxuatkho.data("idThuocPhauThuat",Request.QueryString["idThuocPhauThuat"]);
             chitietphieuxuatkho.data("NGAYTHANG_XUAT",Request.QueryString["NGAYTHANG_XUAT"]);
             chitietphieuxuatkho.data("LOSANXUAT_XUAT",Request.QueryString["LOSANXUAT_XUAT"]);
             chitietphieuxuatkho.data("NGAYHETHAN_XUAT",Request.QueryString["NGAYHETHAN_XUAT"]);
             chitietphieuxuatkho.data("IDLOAIXUAT_XUAT",Request.QueryString["IDLOAIXUAT_XUAT"]);
             chitietphieuxuatkho.data("BHTra",Request.QueryString["BHTra"]);
             chitietphieuxuatkho.data("BNDaTra",Request.QueryString["BNDaTra"]);
             chitietphieuxuatkho.data("BNTra",Request.QueryString["BNTra"]);
             chitietphieuxuatkho.data("DonGiaBH",Request.QueryString["DonGiaBH"]);
             chitietphieuxuatkho.data("DonGiaDV",Request.QueryString["DonGiaDV"]);
             chitietphieuxuatkho.data("IsBHYT",Request.QueryString["IsBHYT"]);
             chitietphieuxuatkho.data("ISBNDaTra",Request.QueryString["ISBNDaTra"]);
             chitietphieuxuatkho.data("IsDaHuy",Request.QueryString["IsDaHuy"]);
             chitietphieuxuatkho.data("NGAYTINHBH_THUC",Request.QueryString["NGAYTINHBH_THUC"]);
             chitietphieuxuatkho.data("PrevBNTra",Request.QueryString["PrevBNTra"]);
             chitietphieuxuatkho.data("SL_Prev",Request.QueryString["SL_Prev"]);
             chitietphieuxuatkho.data("ThanhTien_Prev",Request.QueryString["ThanhTien_Prev"]);
             chitietphieuxuatkho.data("ThanhTienBH",Request.QueryString["ThanhTienBH"]);
             chitietphieuxuatkho.data("ThanhTienDV",Request.QueryString["ThanhTienDV"]);
             chitietphieuxuatkho.data("OutPutDetailID",Request.QueryString["OutPutDetailID"]);
             chitietphieuxuatkho.data("IDKHAMBENH1",Request.QueryString["IDKHAMBENH1"]);
             chitietphieuxuatkho.data("IdNuocSX_X",Request.QueryString["IdNuocSX_X"]);
             chitietphieuxuatkho.data("GhiChu",Request.QueryString["GhiChu"]);
             chitietphieuxuatkho.data("soPhieuTra",Request.QueryString["soPhieuTra"]);
             chitietphieuxuatkho.data("ngayNhanTra",Request.QueryString["ngayNhanTra"]);
             chitietphieuxuatkho.data("soLuong_bk",Request.QueryString["soLuong_bk"]);
             chitietphieuxuatkho.data("IsTinhTien",Request.QueryString["IsTinhTien"]);
             chitietphieuxuatkho.data("PHUTHUBH",Request.QueryString["PHUTHUBH"]);
             chitietphieuxuatkho.data("IDBENHBHDONGTIEN",Request.QueryString["IDBENHBHDONGTIEN"]);
             chitietphieuxuatkho.data("TOP1_IDCHITIETBENHNHANTOATHUOC",Request.QueryString["TOP1_IDCHITIETBENHNHANTOATHUOC"]);
             chitietphieuxuatkho.data("NHACUNGCAPID_X",Request.QueryString["NHACUNGCAPID_X"]);
             chitietphieuxuatkho.data("SOHOADON_X",Request.QueryString["SOHOADON_X"]);
             chitietphieuxuatkho.data("NGAYHOADON_X",Request.QueryString["NGAYHOADON_X"]);
             chitietphieuxuatkho.data("IdLoaiThuoc",Request.QueryString["IdLoaiThuoc"]);
             chitietphieuxuatkho.data("ISBHYT_NHAP",Request.QueryString["ISBHYT_NHAP"]);
             chitietphieuxuatkho.data("SODK_X",Request.QueryString["SODK_X"]);
            return chitietphieuxuatkho;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_chitietphieuxuatkho();break ;
             case "xoa": Xoa_chitietphieuxuatkho(); break;
              case "TimKiem": TimKiem(); break;
              case "idphieuxuatSearch": idphieuxuatSearch(); break;
              case "idthuocSearch": idthuocSearch(); break;
         }
     }
 
     private void idphieuxuatSearch()
     {
         DataTable table = DataProcess.GetTable("select * from phieuxuatkho  where maphieuxuat like N'%"+Request.QueryString["q"]+"%'");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i]["maphieuxuat"].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
                Response.Clear(); Response.Write(html);
}
     private void idthuocSearch()
     {
         DataTable table = DataProcess.GetTable("select * from thuoc  where tenthuoc like N'%"+Request.QueryString["q"]+"%'");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i]["tenthuoc"].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
                Response.Clear(); Response.Write(html);
}
     private void Xoa_chitietphieuxuatkho()
     {
         try
         {
                DataProcess process = s_chitietphieuxuatkho();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idchitietphieuxuat"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_chitietphieuxuatkho()
     {
         try
         {
              DataProcess process = s_chitietphieuxuatkho();
             if (!string.IsNullOrEmpty(process.getData("idchitietphieuxuat")))
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idchitietphieuxuat"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idchitietphieuxuat"));
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
                bool search = Userlogin_new.HavePermision(this, "chitietphieuxuatkho_Search");
                if(search){
                 bool add = Userlogin_new.HavePermision(this, "chitietphieuxuatkho_Add");
                 bool delete = Userlogin_new.HavePermision(this, "chitietphieuxuatkho_Delete");
                  bool edit = Userlogin_new.HavePermision(this, "chitietphieuxuatkho_Edit");
                DataProcess process = s_chitietphieuxuatkho();
                DataTable table = process.Search(@"select STT=row_number() over (order by b.tenthuoc),T.*
                               ,A.maphieuxuat
                               ,B.tenthuoc
                               ,TENKHOA=E.TENPHONGKHAMBENH
                               ,D.TENDVT
                               ,KHOXUAT=F.TENKHO
                               ,SOLUONGVIEW=ISNULL(T.SOLUONG_BK,T.SOLUONG)
                                           from chitietphieuxuatkho T
                                left join phieuxuatkho  A on T.idphieuxuat=A.idphieuxuat
                                left join thuoc  B on T.idthuoc=B.idthuoc
                                LEFT JOIN KHAMBENH C ON T.IDKHAMBENH1=C.IDKHAMBENH
                                LEFT JOIN THUOC_DONVITINH D ON B.IDDVT=D.ID
                                LEFT JOIN PHONGKHAMBENH E ON C.IDPHONGKHAMBENH=E.IDPHONGKHAMBENH
                                LEFT JOIN KHOTHUOC F ON A.IDKHO=F.IDKHO
                      where T.IDBENHBHDONGTIEN=" + IDBENHBHDONGTIEN + " AND T.ISTINHTIEN=1");
         string head = "\"\":\"\""
                 + ",\"TENKHOA\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENKHOA") + "\""
                  + ",\"KHOXUAT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("KHO") + "\""
                 + ",\"MAPHIEUXUAT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("MAPHIEUXUAT") + "\""
                 + ",\"IDTHUOC\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "\""
                 + ",\"DVT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("DVT") + "\""
                 + ",\"SODK_X\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("SODK_X") + "\""
                 + ",\"SOLUONG\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("SOLUONG") + "\""
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
 
 

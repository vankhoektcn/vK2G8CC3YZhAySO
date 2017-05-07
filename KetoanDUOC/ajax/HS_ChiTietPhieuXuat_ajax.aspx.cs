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

public partial class HS_ChiTietPhieuXuat_ajax : System.Web.UI.Page
 {
     protected DataProcess s_phieuxuatkho()
     {
             DataProcess phieuxuatkho = new DataProcess("phieuxuatkho"); 
             phieuxuatkho.data("idphieuxuat",Request.QueryString["idkhoachinh"]);
             phieuxuatkho.data("maphieuxuat",Request.QueryString["maphieuxuat"]);
             phieuxuatkho.data("ngaythang",Request.QueryString["ngaythang"]);
             phieuxuatkho.data("ghichu",Request.QueryString["ghichu"]);
             phieuxuatkho.data("idphongkhambenh",Request.QueryString["idphongkhambenh"]);
             phieuxuatkho.data("nguoinhan",Request.QueryString["nguoinhan"]);
             phieuxuatkho.data("xuatcho",Request.QueryString["xuatcho"]);
             phieuxuatkho.data("idkho",Request.QueryString["idkho"]);
             phieuxuatkho.data("loaixuat",Request.QueryString["loaixuat"]);
             phieuxuatkho.data("IDKhachHang",Request.QueryString["IDKhachHang"]);
             phieuxuatkho.data("vat",Request.QueryString["vat"]);
             phieuxuatkho.data("thanhtien",Request.QueryString["thanhtien"]);
             phieuxuatkho.data("ngayhoadon",Request.QueryString["ngayhoadon"]);
             phieuxuatkho.data("idnhacungcap",Request.QueryString["idnhacungcap"]);
             phieuxuatkho.data("idkho2",Request.QueryString["idkho2"]);
             phieuxuatkho.data("idnguoixuat",Request.QueryString["idnguoixuat"]);
             phieuxuatkho.data("IdBenhNhanToaThuoc",Request.QueryString["IdBenhNhanToaThuoc"]);
             phieuxuatkho.data("IsBHYT",Request.QueryString["IsBHYT"]);
             phieuxuatkho.data("SLPX",Request.QueryString["SLPX"]);
             phieuxuatkho.data("tkNo",Request.QueryString["tkNo"]);
             phieuxuatkho.data("TKVAT",Request.QueryString["TKVAT"]);
             phieuxuatkho.data("TKCo",Request.QueryString["TKCo"]);
             phieuxuatkho.data("IdCaPhauThuat",Request.QueryString["IdCaPhauThuat"]);
             phieuxuatkho.data("IsDaHuy",Request.QueryString["IsDaHuy"]);
             phieuxuatkho.data("LANSUA",Request.QueryString["LANSUA"]);
             phieuxuatkho.data("MaPhieu",Request.QueryString["MaPhieu"]);
             phieuxuatkho.data("NGAYSUA",Request.QueryString["NGAYSUA"]);
             phieuxuatkho.data("NGUOISUA",Request.QueryString["NGUOISUA"]);
             phieuxuatkho.data("IdLoaiThuoc",Request.QueryString["IdLoaiThuoc"]);
             phieuxuatkho.data("IdBenhNhan",Request.QueryString["IdBenhNhan"]);
             phieuxuatkho.data("IDKHAMBENH1",Request.QueryString["IDKHAMBENH1"]);
             phieuxuatkho.data("IDPHIEUYC",Request.QueryString["IDPHIEUYC"]);
             phieuxuatkho.data("SOPHIEUYC",Request.QueryString["SOPHIEUYC"]);
            return phieuxuatkho;
     }
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
             chitietphieuxuatkho.data("dvt",Request.QueryString["dvt"]);
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
             chitietphieuxuatkho.data("VAT",Request.QueryString["VAT"]);
             chitietphieuxuatkho.data("IDKHO_XUAT",Request.QueryString["IDKHO_XUAT"]);
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
            return chitietphieuxuatkho;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": Savephieuxuatkho(); break;
             case "TimKiem": TimKiem(); break;
             case "setTimKiem": setTimKiem(); break;
             case "luuTablechitietphieuxuatkho": LuuTablechitietphieuxuatkho();break ;
             case "loadTablechitietphieuxuatkho": loadTablechitietphieuxuatkho(); break;
             case "xoa": Xoaphieuxuatkho(); break;
             case "xoachitietphieuxuatkho": Xoachitietphieuxuatkho(); break;
              case "idthuocSearch": idthuocSearch(); break;
              case "dvtSearch": dvtSearch(); break;
         }
     }
 
     private void idthuocSearch()
     {
         DataTable table = Thuoc_Process.thuoc.dtGetAll();
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
                Response.Clear(); Response.Write(html);
}
     private void dvtSearch()
     {
         DataTable table = Process_2608.Thuoc_DonViTinh.dtGetAll();
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
                Response.Clear(); Response.Write(html);
}
     private void Xoaphieuxuatkho()
     {
         try
         {
                DataProcess process = s_phieuxuatkho();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idphieuxuat"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void Xoachitietphieuxuatkho()
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
     private void setTimKiem()
     {
 if (StaticData.HavePermision(this, "phieuxuatkho_Search"))
         {
         string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
         string sqlSelect = @"select 
		                        idphieuxuat,
		                        maphieuxuat,
		                        ngaythang,
		                        idkho=T2.TENKHO,
		                        loaixuat=T3.tenloaixuat,
		                        IDKhachHang=T4.TENKHACHHANG,
		                        idkho2=T5.TENKHO,
		                        idnguoixuat=T6.TENNGUOIDUNG,
		                        MaPhieu
                        FROM PHIEUXUATKHO T
                        LEFT JOIN KHOTHUOC T2 ON T.IDKHO=T2.IDKHO
                        LEFT JOIN THUOC_LOAIXUAT T3 ON T.LOAIXUAT=T3.idloaixuat
                        LEFT JOIN KHACHHANG T4 ON T.IDKHACHHANG=T4.IDKHACHHANG
                        LEFT JOIN KHOTHUOC T5 ON T.IDKHO2=T5.IDKHO
                        LEFT JOIN NGUOIDUNG T6 ON T.IDNGUOIXUAT=T6.IDNGUOIDUNG
                        WHERE IDPHIEUXUAT="+idkhoachinh;
         DataTable table = DataAcess.Connect.GetTable(sqlSelect);
 StringBuilder html = new StringBuilder();
 html.AppendLine("<root>");
         html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");

         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
 
                 for (int y = 0; y < table.Columns.Count; y++)
                 {
                     try
                     {
                         html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>");
                     }
                     catch
                     {
                         html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>");
                     }
                 }
             }
         }
         html.AppendLine("</root>");
         Response.Clear();
         Response.Write(html.ToString().Replace("&", "&amp;"));
     }
 else
         {
             Response.Write("Bạn không có quyền xem dữ liệu");
             Response.StatusCode = 500;
         }
     }
 
     private void TimKiem()
     {
         if (StaticData.HavePermision(this, "phieuxuatkho_Search"))
         {
                DataProcess process = s_phieuxuatkho();
         process.Page = Request.QueryString["page"];
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.idphieuxuat),T.*
                               from phieuxuatkho T
          where "+process.sWhere());
         StringBuilder html = new StringBuilder();
         html.Append("<table class='jtable' id=\"tablefind\">");
         html.Append("<tr>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idphieuxuat") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaixuat") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IDKhachHang") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho2") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnguoixuat") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaPhieu") + "</th>");
         html.Append("</tr>");
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["idphieuxuat"].ToString() + "')\">");
                         html.Append("<td>" + table.Rows[i]["maphieuxuat"].ToString() + "</td>");
                         if(table.Rows[i]["ngaythang"].ToString() != ""){
                        html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaythang"].ToString()).ToString("dd/MM/yyyy") + "</td>");}
                        else{html.Append("<td>" + table.Rows[i]["ngaythang"].ToString()+ "</td>");}
                         html.Append("<td>" + table.Rows[i]["idkho"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["loaixuat"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["IDKhachHang"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["idkho2"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["idnguoixuat"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["MaPhieu"].ToString() + "</td>");
                 html.Append("</tr>");
             }
             html.Append("</table>");
            html.Append(process.Paging());
                     Response.Clear();Response.Write(html);
             return;
         }}
         else
         {
                     Response.StatusCode = 500;
         }
         }
         else
         {
             Response.Write("Bạn không có quyền xem dữ liệu.");
         }
     }
 
     private void Savephieuxuatkho()
     {
         try
         {
              DataProcess process = s_phieuxuatkho();
             if (process.getData("idphieuxuat") != null && process.getData("idphieuxuat") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idphieuxuat"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idphieuxuat"));
                 return;
             }
           }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
  public void LuuTablechitietphieuxuatkho()
     {
         try
         {
              DataProcess process = s_chitietphieuxuatkho();
             if (process.getData("idchitietphieuxuat") != null && process.getData("idchitietphieuxuat") != "")
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
 public void loadTablechitietphieuxuatkho()
     {
        string paging = "";
         StringBuilder html = new StringBuilder();
         html.Append("<table class='jtable' id=\"gridTable\">");
         html.Append("<tr>");
         html.Append("<th>STT</th>");
         html.Append("<th></th>");
         
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaPhieuNhap") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayThang") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LOSANXUAT_XUAT") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYHETHAN_XUAT") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtientruocthue") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("VAT") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>");
         
         html.Append("<th></th>");
         html.Append("</tr>");
 bool add = StaticData.HavePermision(this, "chitietphieuxuatkho_Add");
 bool search = StaticData.HavePermision(this, "chitietphieuxuatkho_Search");
         if (search){
                DataProcess process = s_chitietphieuxuatkho();
         process.Page = Request.QueryString["page"];
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietphieuxuat),T.*
                   ,A.TenThuoc
                   ,B.TenDVT
                   ,C.MaPhieuNhap
                   ,NgayThang=CONVERT(NVARCHAR(20),C.NgayThang,103)
                     from chitietphieuxuatkho T
                    left join thuoc  A on T.idthuoc=A.idthuoc
                    left join Thuoc_DonViTinh  B on T.dvt=B.Id
                    left join ChiTietPhieuNhapKho T2 on T.IdChiTietPhieuNhapKho=T2.IdChiTietPhieuNhapKho
                    left join PhieuNhapKho C on T2.IdPhieuNhap=C.IdPhieuNhap
          where T.idphieuxuat='"+process.getData("idphieuxuat")+"'");
         if (table.Rows.Count > 0)
         {
          paging = process.Paging("chitietphieuxuatkho");
          bool delete = StaticData.HavePermision(this, "chitietphieuxuatkho_Delete");
          bool edit = StaticData.HavePermision(this, "chitietphieuxuatkho_Edit");
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html.Append("<tr>");
                 html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                 html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                 html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' id='mkv_idthuoc' type='text' value='" + table.Rows[i]["TenThuoc"].ToString() + "' onfocus='idthuocSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                 html.Append("<td><input mkv='true' id='dvt' type='hidden' value='" + table.Rows[i]["dvt"] + "'/><input mkv='true' id='mkv_dvt' type='text' value='" + table.Rows[i]["TenDVT"].ToString() + "' onfocus='dvtSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:50px;' /></td>");
                 html.Append("<td><input mkv='true' id='MaPhieuNhap' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["MaPhieuNhap"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "   style='width:100px;'   /></td>");
                 html.Append("<td><input mkv='true' id='NgayThang' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["NgayThang"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "  style='width:100px;' /></td>");
                 html.Append("<td><input mkv='true' id='LOSANXUAT_XUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["LOSANXUAT_XUAT"].ToString() + "' " + (!edit ? "disabled" : "") + "  style='width:70px;'  /></td>");
                 if (table.Rows[i]["NGAYHETHAN_XUAT"].ToString() != "")
                 {
                    html.Append("<td><input mkv='true' id='NGAYHETHAN_XUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + DateTime.Parse(table.Rows[i]["NGAYHETHAN_XUAT"].ToString()).ToString("dd/MM/yyyy") + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + " style='width:70px;' /></td>");
                 }
                 else { html.Append("<td><input mkv='true' id='NGAYHETHAN_XUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + table.Rows[i]["NGAYHETHAN_XUAT"].ToString() + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + "   style='width:70px;'/></td>"); }
                 html.Append("<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluong"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:50px;'/></td>");
                 html.Append("<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["dongia"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:50px;'/></td>");
                 html.Append("<td><input mkv='true' id='thanhtientruocthue' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["thanhtientruocthue"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:50px;'/></td>");
                 html.Append("<td><input mkv='true' id='VAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["VAT"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:50px;'/></td>");
                 html.Append("<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["thanhtien"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:50px;'/></td>");
                 html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietphieuxuat"].ToString() + "'/></td>");
                 html.Append("</tr>");
             }
         }}
         if(add)
         {
                 html.Append("<tr>");
                 html.Append("<td>1</td>");
                 html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                 html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus='idthuocSearch(this);' class=\"down_select\"/></td>");
                 html.Append("<td><input mkv='true' id='dvt' type='hidden' value=''/><input mkv='true' id='mkv_dvt' type='text' value='' onfocus='dvtSearch(this);' class=\"down_select\"  style='width:50px;' /></td>");
                 html.Append("<td><input mkv='true' id='MaPhieuNhap' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:100px;' /></td>");
                 html.Append("<td><input mkv='true' id='NgayThang' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:100px;' /></td>");   
                 html.Append("<td><input mkv='true' id='LOSANXUAT_XUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:70px;' /></td>");
                 html.Append("<td><input mkv='true' id='NGAYHETHAN_XUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)'  style='width:70px;' /></td>");
                 html.Append("<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:50px;' /></td>");
                 html.Append("<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:50px;'/></td>");
                 html.Append("<td><input mkv='true' id='thanhtientruocthue' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:50px;'/></td>");
                 html.Append("<td><input mkv='true' id='VAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:50px;'/></td>");
                 html.Append("<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:50px;'/></td>");
                 html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
                 html.Append("</tr>");
         }
         html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
         html.Append("</table>");
         if(!search)
             html.Append("Bạn không có quyền xem.");
         else
            html.Append(paging);
                 Response.Clear();Response.Write(html);
     }
 }
 
 

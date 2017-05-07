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
 
 public partial class thuoc_ajax : System.Web.UI.Page
 {
     protected DataProcess s_thuoc()
     {
             DataProcess thuoc = new DataProcess("thuoc"); 
             thuoc.data("idthuoc",Request.QueryString["idkhoachinh"]);
             thuoc.data("sttindm05",Request.QueryString["sttindm05"]);
             thuoc.data("tenthuoc",Request.QueryString["tenthuoc"]);
             thuoc.data("congthuc",Request.QueryString["congthuc"]);
             thuoc.data("duongdung",Request.QueryString["duongdung"]);
             thuoc.data("idnuocsanxuat",Request.QueryString["idnuocsanxuat"]);
             thuoc.data("idnhasanxuat",Request.QueryString["idnhasanxuat"]);
             thuoc.data("giabanhientai",Request.QueryString["giabanhientai"]);
             thuoc.data("nhacungcapid",Request.QueryString["nhacungcapid"]);
             thuoc.data("ngayhethan",Request.QueryString["ngayhethan"]);
             thuoc.data("idnhomthuoc",Request.QueryString["idnhomthuoc"]);
             thuoc.data("tlbhtt",Request.QueryString["tlbhtt"]);
             thuoc.data("sudungchobh",Request.QueryString["sudungchobh"]);
             thuoc.data("imei",Request.QueryString["imei"]);
             thuoc.data("iddvt",Request.QueryString["iddvt"]);
             thuoc.data("donvitinh",Request.QueryString["donvitinh"]);
             thuoc.data("LoiDan",Request.QueryString["LoiDan"]);
             thuoc.data("IsVTYT",Request.QueryString["IsVTYT"]);
             thuoc.data("thuexuat",Request.QueryString["thuexuat"]);
             thuoc.data("quycach",Request.QueryString["quycach"]);
             thuoc.data("IsHoaChat",Request.QueryString["IsHoaChat"]);
             thuoc.data("ghichu",Request.QueryString["ghichu"]);
             thuoc.data("LoaiThuocID",Request.QueryString["LoaiThuocID"]);
             thuoc.data("TTHoatChat",Request.QueryString["TTHoatChat"]);
             thuoc.data("IsThuocBV",Request.QueryString["IsThuocBV"]);
             thuoc.data("idhangsanxuat",Request.QueryString["idhangsanxuat"]);
             thuoc.data("CateID",Request.QueryString["CateID"]);
             thuoc.data("IsTGN",Request.QueryString["IsTGN"]);
             thuoc.data("IsTHTT",Request.QueryString["IsTHTT"]);
             thuoc.data("IdCachDung",Request.QueryString["IdCachDung"]);
             thuoc.data("ISTPX",Request.QueryString["ISTPX"]);
             thuoc.data("ISTKS",Request.QueryString["ISTKS"]);
             thuoc.data("ISTDTL",Request.QueryString["ISTDTL"]);
             thuoc.data("ISTcorticoid",Request.QueryString["ISTcorticoid"]);
             thuoc.data("tkKho",Request.QueryString["tkKho"]);
             thuoc.data("tkDoanhThu",Request.QueryString["tkDoanhThu"]);
             thuoc.data("tkGiaVon",Request.QueryString["tkGiaVon"]);
             thuoc.data("tkvat",Request.QueryString["tkvat"]);
             thuoc.data("tkco",Request.QueryString["tkco"]);
             thuoc.data("SoLuong1donvi",Request.QueryString["SoLuong1donvi"]);
             thuoc.data("TenDonVi",Request.QueryString["TenDonVi"]);
             thuoc.data("DVTChuan",Request.QueryString["DVTChuan"]);
             thuoc.data("giabh",Request.QueryString["giabh"]);
             thuoc.data("HamLuong",Request.QueryString["HamLuong"]);
             thuoc.data("IsDTUT",Request.QueryString["IsDTUT"]);
             thuoc.data("IsThucSDBHYT",Request.QueryString["IsThucSDBHYT"]);
             thuoc.data("SLDVTChuan",Request.QueryString["SLDVTChuan"]);
             thuoc.data("SLQuyDoi",Request.QueryString["SLQuyDoi"]);
             thuoc.data("IsThuocBV", "1");

            return thuoc;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_thuoc();break ;
             case "xoa": Xoa_thuoc(); break;
              case "TimKiem": TimKiem(); break;
              case "idnuocsanxuatSearch": idnuocsanxuatSearch(); break;
              case "idnhomthuocSearch": idnhomthuocSearch(); break;
              case "iddvtSearch": iddvtSearch(); break;
              case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
              case "idhangsanxuatSearch": idhangsanxuatSearch(); break;
              case "CateIDSearch": CateIDSearch(); break;
              case "IdCachDungSearch": IdCachDungSearch(); break;
         }
     }
 
     private void idnuocsanxuatSearch()
     {
         DataTable table = DataAcess.Connect.GetTable("SELECT * FROM NUOCSX");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i]["TenNuocSX"].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void idnhomthuocSearch()
     {
         DataTable table = Thuoc_Process.nhomthuoc .dtGetAll();
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i]["tennhom"].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void iddvtSearch()
     {
         DataTable table = DataAcess.Connect.GetTable("select * from thuoc_donvitinh");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void LoaiThuocIDSearch()
     {
         DataTable table = Thuoc_Process.Thuoc_LoaiThuoc .dtGetAll();
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void idhangsanxuatSearch()
     {
         DataTable table = Thuoc_Process.hangsanxuat .dtGetAll();
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void CateIDSearch()
     {
         DataTable table = Thuoc_Process.category .dtGetAll();
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void IdCachDungSearch()
     {
         DataTable table = DataAcess.Connect.GetTable("SELECT * FROM THUOC_CACHDUNG");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void Xoa_thuoc()
     {
         try
         {
                DataProcess process = s_thuoc();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idthuoc"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_thuoc()
     {
         try
         {
              DataProcess process = s_thuoc();
             if (process.getData("idthuoc") != null && process.getData("idthuoc") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idthuoc"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idthuoc"));
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
        string paging = "";
         StringBuilder html = new StringBuilder();
         html.Append("<table class='jtable' id=\"gridTable\">");
         html.Append("<tr>");
          html.Append("<th>STT</th>");
          html.Append("<th></th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sttindm05") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("congthuc") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnuocsanxuat") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnhomthuoc") + "</th>");
         
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("iddvt") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TTHoatChat") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idhangsanxuat") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("CateID") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsTGN") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsTHTT") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdCachDung") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISTPX") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISTKS") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISTDTL") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISTcorticoid") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DVTChuan") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("HamLuong") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsDTUT") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SLDVTChuan") + "</th>");
         //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SLQuyDoi") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sudungchobh") + "</th>");
          html.Append("<th></th>");
         html.Append("</tr>");
 bool add = StaticData.HavePermision(this, "thuoc_Add");
 bool search = StaticData.HavePermision(this, "thuoc_Search");
         if (search)
         {
                DataProcess process = s_thuoc();
         process.Page = Request.QueryString["page"];
         process.NumberRow = "50";
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.idthuoc),T.*
                   ,A.TenNuocSX
                   ,B.tennhom
                   ,C.TenDVT
                   ,D.MaLoai
                   ,E.TenHangSanXuat
                   ,F.catename
                   ,G.tencachdung
                               from thuoc T
                    left join NuocSX  A on T.idnuocsanxuat=A.idNuocSX
                    left join nhomthuoc  B on T.idnhomthuoc=B.idnhomthuoc
                    left join Thuoc_DonViTinh  C on T.iddvt=C.Id
                    left join Thuoc_LoaiThuoc  D on T.LoaiThuocID=D.LoaiThuocID
                    left join hangsanxuat  E on T.idhangsanxuat=E.idhangsanxuat
                    left join category  F on T.CateID=F.cateid
                    left join Thuoc_CachDung  G on T.IdCachDung=G.idcachdung
          where " + process.sWhere());
 paging = process.Paging();
         if (table.Rows.Count > 0)
         {
 bool delete = StaticData.HavePermision(this, "thuoc_Delete");
  bool edit = StaticData.HavePermision(this, "thuoc_Edit");
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html.Append("<tr>");
 html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
 html.Append("<td> <a id=\"xoaRow\" style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + delete.ToString().ToLower() + ");\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>");
 //html.Append("<td><input mkv='true' id='sttindm05' type='text' value='" + table.Rows[i]["sttindm05"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>");
 html.Append("<td><input mkv='true' id='tenthuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>");
 html.Append("<td><input mkv='true' id='congthuc' type='text' value='" + table.Rows[i]["congthuc"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='idnuocsanxuat' type='hidden' value='" + table.Rows[i]["idnuocsanxuat"] + "'/><input mkv='true' id='mkv_idnuocsanxuat' type='text' value='"+ table.Rows[i]["TenNuocSX"] +"' onfocus='idnuocsanxuatSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='idnhomthuoc' type='hidden' value='" + table.Rows[i]["idnhomthuoc"] + "'/><input mkv='true' id='mkv_idnhomthuoc' type='text' value='" + table.Rows[i]["tennhom"] + "' onfocus='idnhomthuocSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>");
 
 html.Append("<td><input mkv='true' id='iddvt' type='hidden' value='" + table.Rows[i]["iddvt"] + "'/><input mkv='true' id='mkv_iddvt' type='text' value='"+ table.Rows[i]["TenDVT"] +"' onfocus='iddvtSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='LoaiThuocID' type='hidden' value='" + table.Rows[i]["LoaiThuocID"] + "'/><input mkv='true' id='mkv_LoaiThuocID' type='text' value='"+ table.Rows[i]["MaLoai"] +"' onfocus='LoaiThuocIDSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='TTHoatChat' type='text' value='" + table.Rows[i]["TTHoatChat"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='idhangsanxuat' type='hidden' value='" + table.Rows[i]["idhangsanxuat"] + "'/><input mkv='true' id='mkv_idhangsanxuat' type='text' value='"+ table.Rows[i]["TenHangSanXuat"] +"' onfocus='idhangsanxuatSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>");
 html.Append("<td><input mkv='true' id='CateID' type='hidden' value='" + table.Rows[i]["CateID"] + "'/><input mkv='true' id='mkv_CateID' type='text' value='"+ table.Rows[i]["catename"] +"' onfocus='CateIDSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='IsTGN' type='checkbox' " + (table.Rows[i]["IsTGN"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='IsTHTT' type='checkbox' " + (table.Rows[i]["IsTHTT"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='IdCachDung' type='hidden' value='" + table.Rows[i]["IdCachDung"] + "'/><input mkv='true' id='mkv_IdCachDung' type='text' value='"+ table.Rows[i]["tencachdung"] +"' onfocus='IdCachDungSearch(this);' class=\"down_select\" style='width:90%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='ISTPX' type='checkbox' " + (table.Rows[i]["ISTPX"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='ISTKS' type='checkbox' " + (table.Rows[i]["ISTKS"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='ISTDTL' type='checkbox' " + (table.Rows[i]["ISTDTL"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='ISTcorticoid' type='checkbox' " + (table.Rows[i]["ISTcorticoid"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='DVTChuan' type='text' value='" + table.Rows[i]["DVTChuan"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='HamLuong' type='text' value='" + table.Rows[i]["HamLuong"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='IsDTUT' type='checkbox' " + (table.Rows[i]["IsDTUT"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='SLDVTChuan' type='text' value='" + table.Rows[i]["SLDVTChuan"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>");
 //html.Append("<td><input mkv='true' id='SLQuyDoi' type='text' value='" + table.Rows[i]["SLQuyDoi"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>");
 html.Append("<td><input mkv='true' id='sudungchobh' type='checkbox' " + (table.Rows[i]["sudungchobh"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!edit ? "disabled" : "") + "/></td>");
 html.Append("<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["idthuoc"] + "'/></td>");
                 html.Append("</tr>");
             }}}
if (add){
                 html.Append("<tr>");
 html.Append("<td>1</td>");
 html.Append("<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>");
 //html.Append("<td><input mkv='true' id='sttindm05' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>");
 html.Append("<td><input mkv='true' id='tenthuoc' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>");
 html.Append("<td><input mkv='true' id='congthuc' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>");
// html.Append("<td><input mkv='true' id='idnuocsanxuat' type='hidden' value=''/><input mkv='true' id='mkv_idnuocsanxuat' type='text' value='' onfocus='idnuocsanxuatSearch(this);' class=\"down_select\" style='width:90%'/></td>");
 //html.Append("<td><input mkv='true' id='idnhomthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idnhomthuoc' type='text' value='' onfocus='idnhomthuocSearch(this);' class=\"down_select\" style='width:90%'/></td>");
 
 html.Append("<td><input mkv='true' id='iddvt' type='hidden' value=''/><input mkv='true' id='mkv_iddvt' type='text' value='' onfocus='iddvtSearch(this);' class=\"down_select\" style='width:90%'/></td>");
// html.Append("<td><input mkv='true' id='LoaiThuocID' type='hidden' value=''/><input mkv='true' id='mkv_LoaiThuocID' type='text' value='' onfocus='LoaiThuocIDSearch(this);' class=\"down_select\" style='width:90%'/></td>");
 //html.Append("<td><input mkv='true' id='TTHoatChat' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>");
 //html.Append("<td><input mkv='true' id='idhangsanxuat' type='hidden' value=''/><input mkv='true' id='mkv_idhangsanxuat' type='text' value='' onfocus='idhangsanxuatSearch(this);' class=\"down_select\" style='width:90%'/></td>");
 html.Append("<td><input mkv='true' id='CateID' type='hidden' value=''/><input mkv='true' id='mkv_CateID' type='text' value='' onfocus='CateIDSearch(this);' class=\"down_select\" style='width:90%'/></td>");
 //html.Append("<td><input mkv='true' id='IsTGN' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>");
 //html.Append("<td><input mkv='true' id='IsTHTT' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>");
 //html.Append("<td><input mkv='true' id='IdCachDung' type='hidden' value=''/><input mkv='true' id='mkv_IdCachDung' type='text' value='' onfocus='IdCachDungSearch(this);' class=\"down_select\" style='width:90%'/></td>");
 //html.Append("<td><input mkv='true' id='ISTPX' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>");
 //html.Append("<td><input mkv='true' id='ISTKS' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>");
 //html.Append("<td><input mkv='true' id='ISTDTL' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>");
 //html.Append("<td><input mkv='true' id='ISTcorticoid' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>");
 //html.Append("<td><input mkv='true' id='DVTChuan' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>");
 //html.Append("<td><input mkv='true' id='HamLuong' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>");
 //html.Append("<td><input mkv='true' id='IsDTUT' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>");
 //html.Append("<td><input mkv='true' id='SLDVTChuan' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>");
 //html.Append("<td><input mkv='true' id='SLQuyDoi' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>");
 html.Append("<td><input mkv='true' id='sudungchobh' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>");
 html.Append("<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>");
                 html.Append("</tr>");
}
         html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
         html.Append("</table>");
         if(!search)
             html.Append("Bạn không có quyền xem.");
         else
            html.Append(paging);
         string  xhtml = paging;
         xhtml += html.ToString();
         Response.Clear(); Response.Write(xhtml);
     }
 }
 
 

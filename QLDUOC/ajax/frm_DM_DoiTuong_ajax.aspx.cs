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

public partial class frm_DM_DoiTuong_ajax : System.Web.UI.Page
 {
     protected DataProcess s_Thuoc_LoaiThuoc()
     {
             DataProcess Thuoc_LoaiThuoc = new DataProcess("Thuoc_LoaiThuoc"); 
             Thuoc_LoaiThuoc.data("LoaiThuocID",Request.QueryString["idkhoachinh"]);
             Thuoc_LoaiThuoc.data("MaLoai",Request.QueryString["MaLoai"]);
             Thuoc_LoaiThuoc.data("TenLoai",Request.QueryString["TenLoai"]);
             Thuoc_LoaiThuoc.data("Status",Request.QueryString["Status"]);
            return Thuoc_LoaiThuoc;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_Thuoc_LoaiThuoc();break ;
             case "xoa": Xoa_Thuoc_LoaiThuoc(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_Thuoc_LoaiThuoc()
     {
         try
         {
                DataProcess process = s_Thuoc_LoaiThuoc();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("LoaiThuocID"));
                 return;
             }
         }
         catch
         {
         }
                     Response.Clear();Response.Write("");
     }
 
     private void LuuTable_Thuoc_LoaiThuoc()
     {
         try
         {
              DataProcess process = s_Thuoc_LoaiThuoc();
             if (process.getData("LoaiThuocID") != null && process.getData("LoaiThuocID") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("LoaiThuocID"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("LoaiThuocID"));
                 return;
             }
           }
         }
         catch
         {
         }
                     Response.Clear();Response.Write("");
     }
     private void TimKiem()
     {
                DataProcess process = s_Thuoc_LoaiThuoc();
         process.Page = Request.QueryString["page"];
         process.NumberRow = "50";
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.LoaiThuocID),T.*
                               from Thuoc_LoaiThuoc T
          where "+process.sWhere());
         string html ="";
                html += process.Paging();
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
          html += "<th>STT</th>";
          html += "<th></th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaLoai") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenLoai") + "</th>";
          html += "<th></th>";
         html += "</tr>";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr>";
 html+= "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
 html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='MaLoai' type='text' value='" + table.Rows[i]["MaLoai"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='TenLoai' type='text' value='" + table.Rows[i]["TenLoai"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["LoaiThuocID"] + "'/></td>";
                 html += "</tr>";
             }}else{
                 html += "<tr>";
 html+= "<td>1</td>";
 html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='MaLoai' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='TenLoai' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                 html += "</tr>";
}}
         html += "<tr><td></td><td></td></tr>";
         html += "</table>";
         html += process.Paging();
         Response.Clear(); Response.Write(html);
     }
 }
 
 

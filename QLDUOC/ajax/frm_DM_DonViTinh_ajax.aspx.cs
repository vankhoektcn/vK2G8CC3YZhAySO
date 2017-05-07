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

public partial class frm_DM_DonViTinh_ajax : System.Web.UI.Page
 {
     protected DataProcess s_Thuoc_DonViTinh()
     {
             DataProcess Thuoc_DonViTinh = new DataProcess("Thuoc_DonViTinh"); 
             Thuoc_DonViTinh.data("Id",Request.QueryString["idkhoachinh"]);
             Thuoc_DonViTinh.data("TenDVT",Request.QueryString["TenDVT"]);
             Thuoc_DonViTinh.data("Status","1");
            return Thuoc_DonViTinh;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_Thuoc_DonViTinh();break ;
             case "xoa": Xoa_Thuoc_DonViTinh(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_Thuoc_DonViTinh()
     {
         try
         {
                DataProcess process = s_Thuoc_DonViTinh();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("Id"));
                 return;
             }
         }
         catch
         {
         }
                     Response.Clear();Response.Write("");
     }
 
     private void LuuTable_Thuoc_DonViTinh()
     {
         try
         {
              DataProcess process = s_Thuoc_DonViTinh();
             if (process.getData("Id") != null && process.getData("Id") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("Id"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("Id"));
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
                DataProcess process = s_Thuoc_DonViTinh();
         process.Page = Request.QueryString["page"];
         process.NumberRow = "50";
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.TENDVT),T.*
                               from Thuoc_DonViTinh T
          where "+process.sWhere());
         string html ="";
                html += process.Paging();
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
          html += "<th>STT</th>";
          html += "<th></th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenDVT") + "</th>";
          html += "<th></th>";
         html += "</tr>";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr>";
 html+= "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
 html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='TenDVT' type='text' value='" + table.Rows[i]["TenDVT"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:800px'/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["Id"] + "'/></td>";
                 html += "</tr>";
             }}else{
                 html += "<tr>";
 html+= "<td>1</td>";
 html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='TenDVT' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:800px'/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                 html += "</tr>";
}}
         html += "<tr><td></td><td></td></tr>";
         html += "</table>";
         html += process.Paging();
         Response.Clear(); Response.Write(html);
     }
 }
 
 

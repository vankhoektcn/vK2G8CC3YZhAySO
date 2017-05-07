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
 
 public partial class tamUng_ajax : System.Web.UI.Page
 {
     protected DataProcess s_tamUng()
     {
             DataProcess tamUng = new DataProcess("tamUng"); 
             tamUng.data("IDTamUng",Request.QueryString["idkhoachinh"]);
             tamUng.data("iddangkykham",Request.QueryString["iddangkykham"]);
             tamUng.data("sotien",Request.QueryString["sotien"]);
             tamUng.data("ngayTamung",Request.QueryString["ngayTamung"]);
             tamUng.data("NgayHoanUng",Request.QueryString["NgayHoanUng"]);
             tamUng.data("SoCTHU",Request.QueryString["SoCTHU"]);
             tamUng.data("SoTienHU",Request.QueryString["SoTienHU"]);
             tamUng.data("GhiChu",Request.QueryString["GhiChu"]);
             tamUng.data("SoCTTU",Request.QueryString["SoCTTU"]);
             tamUng.data("dahoanung",Request.QueryString["dahoanung"]);
             tamUng.data("QuyenSo",Request.QueryString["QuyenSo"]);
             tamUng.data("IsDaThu",Request.QueryString["IsDaThu"]);
             tamUng.data("LyDoTU",Request.QueryString["LyDoTU"]);
             tamUng.data("IsDaHuy",Request.QueryString["IsDaHuy"]);
             tamUng.data("idkhoaTU",Request.QueryString["idkhoaTU"]);
             tamUng.data("MAPHIEU_TU",Request.QueryString["MAPHIEU_TU"]);
            return tamUng;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": SavetamUng(); break;
             case "TimKiem": TimKiem(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": XoatamUng(); break;
         }
     }
 
     private void XoatamUng()
     {
         try
         {
                DataProcess process = s_tamUng();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDTamUng"));
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
         string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
         DataTable table = DataProcess.GetTable(@"select top 1 T.*
                               from tamUng T
 where T.IDTamUng ='"+idkhoachinh+"'");
          StringBuilder html = new StringBuilder(); html.AppendLine("<root>");
         html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");

         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
 
                 for (int y = 0; y < table.Columns.Count; y++)
                 {
                         html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + DataProcess.sGetDate(table.Rows[0][y].ToString(),false,true) + "</data>");
                 }
             }
         }
         html.AppendLine("</root>");
         Response.Clear();
         Response.Write(html.ToString().Replace("&", "&amp;"));
     }
 
     private void TimKiem()
     {
                DataProcess process = s_tamUng();
         process.Page = Request.QueryString["page"];
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.IDTamUng),T.*
                               from tamUng T
          where "+process.sWhere());
         StringBuilder html = new StringBuilder();
         html.Append("<table class='jtable' id=\"gridTable\">");
         html.Append("<tr>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IDTamUng") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("iddangkykham") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sotien") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayTamung") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayHoanUng") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoCTHU") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoTienHU") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoCTTU") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dahoanung") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("QuyenSo") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsDaThu") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LyDoTU") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsDaHuy") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkhoaTU") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MAPHIEU_TU") + "</th>");
         html.Append("</tr>");
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["IDTamUng"].ToString() + "')\">");
                         html.Append("<td>" + table.Rows[i]["iddangkykham"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["sotien"].ToString() + "</td>");
                        html.Append("<td>" + DataProcess.sGetDate(table.Rows[i]["ngayTamung"].ToString(),false,true) + "</td>");
                        html.Append("<td>" + DataProcess.sGetDate(table.Rows[i]["NgayHoanUng"].ToString(),false,true) + "</td>");
                         html.Append("<td>" + table.Rows[i]["SoCTHU"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["SoTienHU"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["GhiChu"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["SoCTTU"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["dahoanung"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["QuyenSo"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["IsDaThu"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["LyDoTU"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["IsDaHuy"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["idkhoaTU"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["MAPHIEU_TU"].ToString() + "</td>");
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
 
     private void SavetamUng()
     {
         try
         {
              DataProcess process = s_tamUng();
             if (process.getData("IDTamUng") != null && process.getData("IDTamUng") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDTamUng"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDTamUng"));
                 return;
             }
           }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 }
 
 

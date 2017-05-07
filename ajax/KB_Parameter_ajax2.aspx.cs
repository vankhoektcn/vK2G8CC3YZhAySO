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
 
 public partial class KB_Parameter_ajax : Genaratepage
 {
     protected DataProcess s_KB_Parameter()
     {
             DataProcess KB_Parameter = new DataProcess("KB_Parameter"); 
             KB_Parameter.data("Id",Request.QueryString["idkhoachinh"]);
             KB_Parameter.data("ParaName",Request.QueryString["ParaName"]);
             KB_Parameter.data("ParaValue",Request.QueryString["ParaValue"]);
             KB_Parameter.data("Description",Request.QueryString["Description"]);
            return KB_Parameter;   
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_KB_Parameter();break ;
             case "xoa": Xoa_KB_Parameter(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_KB_Parameter()
     {
         try
         {
                DataProcess process = s_KB_Parameter();
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
 
     private void LuuTable_KB_Parameter()
     {
         try
         {
              DataProcess process = s_KB_Parameter();
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
         DataProcess process = s_KB_Parameter();
         process.Page = Request.QueryString["page"];
         process.NumberRow = "50";
         DataTable table = process.Search(@"select STT=row_number() over (order by T.Id),T.*
                               from KB_Parameter T
          where " + process.sWhere());
         string html = "";
         html += process.Paging();
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
         html += "<th>STT</th>";
         html += "<th></th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ParaName") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ParaValue") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Description") + "</th>";
         html += "<th></th>";
         html += "</tr>";
         string qT = StaticData.EnabledHavePermision(this, "DMThamSoHeThong_Them");
         string qX = StaticData.VisibleLinkXoaPermision(this, "DMThamSoHeThong_Xoa");
         string qS = StaticData.EnabledHavePermision(this, "DMThamSoHeThong_Sua");
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {
                     html += "<tr>";
                     html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                     html += "<td> <a id=\"xoaRow\" " + qX + " onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                     html += "<td><input " + qS + " mkv='true' id='ParaName' type='text' value='" + table.Rows[i]["ParaName"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                     html += "<td><input " + qS + " mkv='true' id='ParaValue' type='text' value='" + table.Rows[i]["ParaValue"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                     html += "<td><input " + qS + " mkv='true' id='Description' type='text' value='" + table.Rows[i]["Description"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                     html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["Id"] + "'/></td>";
                     html += "</tr>";
                 }
             }
             if (StaticData.HavePermision(this, "DMThamSoHeThong_Them"))            
             {
                 html += "<tr>";
                 html += "<td>1</td>";
                 html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                 html += "<td><input mkv='true' id='ParaName' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                 html += "<td><input mkv='true' id='ParaValue' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                 html += "<td><input mkv='true' id='Description' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                 html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                 html += "</tr>";
             }
         }
         if (StaticData.HavePermision(this, "DMThamSoHeThong_Them"))            
              html += "<tr><td></td><td></td></tr>";
         else
              html += "<tr><td></td><td></td></tr>";
         html += "</table>";
         html += process.Paging();
         Response.Clear(); Response.Write(html);
     }
 }
 
 

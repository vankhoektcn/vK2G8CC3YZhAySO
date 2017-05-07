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
 using KT_Profess;
 
 public partial class luuchuyentiente_ajax : System.Web.UI.Page
 {
     protected DataProcess s_luuchuyentiente()
     {
             DataProcess luuchuyentiente = new DataProcess("luuchuyentiente"); 
             luuchuyentiente.data("idlctt",Request.QueryString["idkhoachinh"]);
             luuchuyentiente.data("chitieu",Request.QueryString["chitieu"]);
             luuchuyentiente.data("maso",Request.QueryString["maso"]);
             luuchuyentiente.data("thuyetminh",Request.QueryString["thuyetminh"]);
             luuchuyentiente.data("congthuc",Request.QueryString["congthuc"]);
             luuchuyentiente.data("namnay",Request.QueryString["namnay"]);
             luuchuyentiente.data("namtruoc",Request.QueryString["namtruoc"]);
             luuchuyentiente.data("dstk_no",Request.QueryString["dstk_no"]);
             luuchuyentiente.data("dstk_co",Request.QueryString["dstk_co"]);
             luuchuyentiente.data("bold",Request.QueryString["bold"]);
            return luuchuyentiente;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_luuchuyentiente();break ;
             case "xoa": Xoa_luuchuyentiente(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_luuchuyentiente()
     {
         try
         {
                DataProcess KT_Profess = s_luuchuyentiente();
                  bool ok = KT_Profess.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(KT_Profess.getData("idlctt"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_luuchuyentiente()
     {
         try
         {
              DataProcess KT_Profess = s_luuchuyentiente();
             if (KT_Profess.getData("idlctt") != null && KT_Profess.getData("idlctt") != "")
             {
             bool ok = KT_Profess.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(KT_Profess.getData("idlctt"));
                 return;
             }
           }
           else
           {
                bool ok =  KT_Profess.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(KT_Profess.getData("idlctt"));
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
                DataProcess KT_Profess = s_luuchuyentiente();
         KT_Profess.Page = Request.QueryString["page"];
         KT_Profess.NumberRow = "50";
                 DataTable table = KT_Profess.Search(@"select STT=row_number() over (order by T.idlctt),T.*
                               from luuchuyentiente T
          where "+KT_Profess.sWhere());
         string html ="";
                html += KT_Profess.Paging();
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
          html += "<th>STT</th>";
          html += "<th></th>";
         html += "<th>Chỉ tiêu</th>";
         html += "<th>Mã số</th>";
         html += "<th>Thuyết minh</th>";
         html += "<th>DSTK Nợ</th>";
         html += "<th>DSTK Có</th>";
         html += "<th>In đậm</th>";
          html += "<th></th>";
         html += "</tr>";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr>";
 html+= "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
 html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='chitieu' type='text' value='" + table.Rows[i]["chitieu"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='maso' type='text' value='" + table.Rows[i]["maso"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='thuyetminh' type='text' value='" + table.Rows[i]["thuyetminh"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='dstk_no' type='text' value='" + table.Rows[i]["dstk_no"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='dstk_co' type='text' value='" + table.Rows[i]["dstk_co"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='bold' type='checkbox' " + (table.Rows[i]["bold"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["idlctt"] + "'/></td>";
                 html += "</tr>";
             }}else{
                 html += "<tr>";
 html+= "<td>1</td>";
 html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='chitieu' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='maso' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='thuyetminh' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='dstk_no' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='dstk_co' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='bold' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                 html += "</tr>";
}}
         html += "<tr><td></td><td></td></tr>";
         html += "</table>";
         html += KT_Profess.Paging();
         Response.Clear(); Response.Write(html);
     }
 }
 
 

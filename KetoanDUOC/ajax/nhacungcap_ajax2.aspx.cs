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
 
 public partial class nhacungcap_ajax : System.Web.UI.Page
 {
     protected DataProcess s_nhacungcap()
     {
             DataProcess nhacungcap = new DataProcess("nhacungcap"); 
             nhacungcap.data("nhacungcapid",Request.QueryString["idkhoachinh"]);
             nhacungcap.data("manhacungcap",Request.QueryString["manhacungcap"]);
             nhacungcap.data("tennhacungcap",Request.QueryString["tennhacungcap"]);
             nhacungcap.data("nguoilienhe",Request.QueryString["nguoilienhe"]);
             nhacungcap.data("diachi",Request.QueryString["diachi"]);
             nhacungcap.data("dienthoai",Request.QueryString["dienthoai"]);
             nhacungcap.data("fax",Request.QueryString["fax"]);
             nhacungcap.data("hanmuctindung",Request.QueryString["hanmuctindung"]);
             nhacungcap.data("taikhoannganhang",Request.QueryString["taikhoannganhang"]);
             nhacungcap.data("nganhang",Request.QueryString["nganhang"]);
             nhacungcap.data("masothue",Request.QueryString["masothue"]);
             nhacungcap.data("dinhdanhimei",Request.QueryString["dinhdanhimei"]);
             nhacungcap.data("IsKT",Request.QueryString["IsKT"]);
            return nhacungcap;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_nhacungcap();break ;
             case "xoa": Xoa_nhacungcap(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_nhacungcap()
     {
         try
         {
                DataProcess process = s_nhacungcap();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("nhacungcapid"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_nhacungcap()
     {
         try
         {
              DataProcess process = s_nhacungcap();
             if (process.getData("nhacungcapid") != null && process.getData("nhacungcapid") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("nhacungcapid"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("nhacungcapid"));
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
         string html ="";
         bool add = true;
         bool search = true;
         if (search)
         {
                DataProcess process = s_nhacungcap();
                 process.Page = Request.QueryString["page"];
                 process.NumberRow = "50";
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.nhacungcapid),T.*
                               from nhacungcap T
          where "+process.sWhere() +" AND ISNULL(ISKT,0)=0");
         paging = process.Paging();
         html +=  paging;
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
          html += "<th  style='width:20px'>STT</th>";
          html += "<th style='width:20px'></th>";
          html += "<th style='width:50px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("manhacungcap") + "</th>";
          html += "<th style='width:300px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tennhacungcap") + "</th>";
          html += "<th style='width:300px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("diachi") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dienthoai") + "</th>";
          html += "<th></th>";
         html += "</tr>";
         if (table.Rows.Count > 0)
         {
             bool delete = true;
             bool edit = true;
             for (int i = 0; i < table.Rows.Count; i++)
             {
                     html += "<tr>";
                     html+= "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                     html+= "<td> <a id=\"xoaRow\" style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + delete.ToString().ToLower() + ");\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
                     html+= "<td><input mkv='true' id='manhacungcap' type='text' value='" + table.Rows[i]["manhacungcap"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                     html += "<td><input mkv='true' id='tennhacungcap' type='text' value='" + table.Rows[i]["tennhacungcap"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                     html += "<td><input mkv='true' id='diachi' type='text' value='" + table.Rows[i]["diachi"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                     html += "<td><input mkv='true' id='dienthoai' type='text' value='" + table.Rows[i]["dienthoai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                     html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["nhacungcapid"] + "'/></td>";
                         html += "</tr>";
             }}}
            if (add){
                             html += "<tr>";
             html+= "<td>1</td>";
             html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
             html += "<td><input mkv='true' id='manhacungcap' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
             html += "<td><input mkv='true' id='tennhacungcap' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
             html += "<td><input mkv='true' id='diachi' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
             html += "<td><input mkv='true' id='dienthoai' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
             html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                             html += "</tr>";
            }
         html += "<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
         html += "</table>";
         if(!search)
             html += "Bạn không có quyền xem.";
         else
            html += paging;
         Response.Clear(); Response.Write(html);
     }
 }
 
 

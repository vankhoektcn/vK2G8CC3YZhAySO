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
 
 public partial class DanhMucCCDC_ajax : System.Web.UI.Page
 {
     protected DataProcess s_DanhMucCCDC()
     {
             DataProcess DanhMucCCDC = new DataProcess("DanhMucCCDC"); 
             DanhMucCCDC.data("ccdc_id",Request.QueryString["idkhoachinh"]);
             DanhMucCCDC.data("phieu_nhap_id",Request.QueryString["phieu_nhap_id"]);
             DanhMucCCDC.data("ma_ccdc",Request.QueryString["ma_ccdc"]);
             DanhMucCCDC.data("ten_ccdc",Request.QueryString["ten_ccdc"]);
             DanhMucCCDC.data("hang_sx",Request.QueryString["hang_sx"]);
             DanhMucCCDC.data("nam_sx",Request.QueryString["nam_sx"]);
             DanhMucCCDC.data("nguyen_gia",Request.QueryString["nguyen_gia"]);
             DanhMucCCDC.data("ngay_nhap",Request.QueryString["ngay_nhap"]);
             DanhMucCCDC.data("ngay_het_han",Request.QueryString["ngay_het_han"]);
             DanhMucCCDC.data("ngay_khau_hao",Request.QueryString["ngay_khau_hao"]);
             DanhMucCCDC.data("so_thang_khau_hao",Request.QueryString["so_thang_khau_hao"]);
             DanhMucCCDC.data("Tk_ccdc",Request.QueryString["Tk_ccdc"]);
             DanhMucCCDC.data("Tk_doi_ung",Request.QueryString["Tk_doi_ung"]);
             DanhMucCCDC.data("tk_chi_phi",Request.QueryString["tk_chi_phi"]);
             DanhMucCCDC.data("tk_phan_bo",Request.QueryString["tk_phan_bo"]);
             DanhMucCCDC.data("phieu_xuat_id",Request.QueryString["phieu_xuat_id"]);
             DanhMucCCDC.data("CCDC",Request.QueryString["CCDC"]);
             DanhMucCCDC.data("TSCD",Request.QueryString["TSCD"]);
             DanhMucCCDC.data("ma_pb",Request.QueryString["ma_pb"]);
             DanhMucCCDC.data("ten_pb",Request.QueryString["ten_pb"]);
            return DanhMucCCDC;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_DanhMucCCDC();break ;
             case "xoa": Xoa_DanhMucCCDC(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_DanhMucCCDC()
     {
         try
         {
                DataProcess process = s_DanhMucCCDC();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("ccdc_id"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_DanhMucCCDC()
     {
         try
         {
              DataProcess process = s_DanhMucCCDC();
             if (process.getData("ccdc_id") != null && process.getData("ccdc_id") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("ccdc_id"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("ccdc_id"));
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
                DataProcess process = s_DanhMucCCDC();
         process.Page = Request.QueryString["page"];
         process.NumberRow = "50";
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.ccdc_id),T.*
                               from DanhMucCCDC T
          where "+process.sWhere());
         string html ="";
                html += process.Paging();
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
          html += "<th>STT</th>";
          html += "<th></th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ma_ccdc") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ten_ccdc") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("hang_sx") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nam_sx") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nguyen_gia") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngay_nhap") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngay_het_han") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tk_ccdc") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tk_doi_ung") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("CCDC") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TSCD") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ma_pb") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ten_pb") + "</th>";
          html += "<th></th>";
         html += "</tr>";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr>";
 html+= "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
 html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='ma_ccdc' type='text' value='" + table.Rows[i]["ma_ccdc"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='ten_ccdc' type='text' value='" + table.Rows[i]["ten_ccdc"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='hang_sx' type='text' value='" + table.Rows[i]["hang_sx"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='nam_sx' type='text' value='" + table.Rows[i]["nam_sx"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='nguyen_gia' type='text' value='" + table.Rows[i]["nguyen_gia"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                         if(table.Rows[i]["ngay_nhap"].ToString() != ""){
html+="<td><input mkv='true' id='ngay_nhap' type='text' value='" + DateTime.Parse(table.Rows[i]["ngay_nhap"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                        }else{html+="<td><input mkv='true' id='ngay_nhap' type='text' value='" + table.Rows[i]["ngay_nhap"] + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
}
                         if(table.Rows[i]["ngay_het_han"].ToString() != ""){
html+="<td><input mkv='true' id='ngay_het_han' type='text' value='" + DateTime.Parse(table.Rows[i]["ngay_het_han"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                        }else{html+="<td><input mkv='true' id='ngay_het_han' type='text' value='" + table.Rows[i]["ngay_het_han"] + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
}
 html+= "<td><input mkv='true' id='Tk_ccdc' type='text' value='" + table.Rows[i]["Tk_ccdc"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='Tk_doi_ung' type='text' value='" + table.Rows[i]["Tk_doi_ung"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='CCDC' type='checkbox' " + (table.Rows[i]["CCDC"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>";
 html+= "<td><input mkv='true' id='TSCD' type='checkbox' " + (table.Rows[i]["TSCD"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>";
 html+= "<td><input mkv='true' id='ma_pb' type='text' value='" + table.Rows[i]["ma_pb"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='ten_pb' type='text' value='" + table.Rows[i]["ten_pb"].ToString()+ "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["ccdc_id"] + "'/></td>";
                 html += "</tr>";
             }}else{
                 html += "<tr>";
 html+= "<td>1</td>";
 html+= "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">"+hsLibrary.clDictionaryDB.sGetValueLanguage("delete")+"</td>";
 html+= "<td><input mkv='true' id='ma_ccdc' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='ten_ccdc' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='hang_sx' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='nam_sx' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='nguyen_gia' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
html+="<td><input mkv='true' id='ngay_nhap' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
html+="<td><input mkv='true' id='ngay_het_han' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='Tk_ccdc' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='Tk_doi_ung' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='CCDC' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>";
 html+= "<td><input mkv='true' id='TSCD' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>";
 html+= "<td><input mkv='true' id='ma_pb' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id='ten_pb' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
 html+= "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                 html += "</tr>";
}}
         html += "<tr><td></td><td></td></tr>";
         html += "</table>";
         html += process.Paging();
         Response.Clear(); Response.Write(html);
     }
 }
 
 

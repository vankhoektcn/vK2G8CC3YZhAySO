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
 
 public partial class Phieu_Thu_NH_ajax : System.Web.UI.Page
 {
     protected DataProcess s_Phieu_Thu_NH()
     {
             DataProcess Phieu_Thu_NH = new DataProcess("Phieu_Thu_NH"); 
             Phieu_Thu_NH.data("phieu_thu_id",Request.QueryString["idkhoachinh"]);
             Phieu_Thu_NH.data("so_ct",Request.QueryString["so_ct"]);
             Phieu_Thu_NH.data("ngay_thu",Request.QueryString["ngay_thu"]);
             Phieu_Thu_NH.data("ma_nh",Request.QueryString["ma_nh"]);
             Phieu_Thu_NH.data("ten_nh",Request.QueryString["ten_nh"]);
             Phieu_Thu_NH.data("tk_nh",Request.QueryString["tk_nh"]);
             Phieu_Thu_NH.data("ma_nvthu",Request.QueryString["ma_nvthu"]);
             Phieu_Thu_NH.data("ten_nvthu",Request.QueryString["ten_nvthu"]);
             Phieu_Thu_NH.data("loai_tien",Request.QueryString["loai_tien"]);
             Phieu_Thu_NH.data("ty_gia",Request.QueryString["ty_gia"]);
             Phieu_Thu_NH.data("user_dau",Request.QueryString["user_dau"]);
             Phieu_Thu_NH.data("date_dau",Request.QueryString["date_dau"]);
             Phieu_Thu_NH.data("user_cuoi",Request.QueryString["user_cuoi"]);
             Phieu_Thu_NH.data("date_cuoi",Request.QueryString["date_cuoi"]);
             Phieu_Thu_NH.data("status",Request.QueryString["status"]);
            return Phieu_Thu_NH;
     }
     protected DataProcess s_Phieu_Thu_NH_Ct()
     {
             DataProcess Phieu_Thu_NH_Ct = new DataProcess("Phieu_Thu_NH_Ct"); 
             Phieu_Thu_NH_Ct.data("phieu_thu_ct_id",Request.QueryString["idkhoachinh"]);
             Phieu_Thu_NH_Ct.data("id_phieuthu_nh",Request.QueryString["id_phieuthu_nh"]);
             Phieu_Thu_NH_Ct.data("tk_no",Request.QueryString["tk_no"]);
             Phieu_Thu_NH_Ct.data("tk_co",Request.QueryString["tk_co"]);
             Phieu_Thu_NH_Ct.data("thanh_tienVND",Request.QueryString["thanh_tienVND"]);
             Phieu_Thu_NH_Ct.data("dien_giai",Request.QueryString["dien_giai"]);
             Phieu_Thu_NH_Ct.data("so_hd",Request.QueryString["so_hd"]);
             Phieu_Thu_NH_Ct.data("VAT",Request.QueryString["VAT"]);
             Phieu_Thu_NH_Ct.data("ma_ncc",Request.QueryString["ma_ncc"]);
             Phieu_Thu_NH_Ct.data("ten_ncc",Request.QueryString["ten_ncc"]);
             Phieu_Thu_NH_Ct.data("so_series",Request.QueryString["so_series"]);
             Phieu_Thu_NH_Ct.data("status_fix",Request.QueryString["status_fix"]);
             Phieu_Thu_NH_Ct.data("ngay_hd",Request.QueryString["ngay_hd"]);
            return Phieu_Thu_NH_Ct;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": SavePhieu_Thu_NH(); break;
             case "TimKiem": TimKiem(); break;
             case "setTimKiem": setTimKiem(); break;
             case "luuTablePhieu_Thu_NH_Ct": LuuTablePhieu_Thu_NH_Ct();break ;
             case "loadTablePhieu_Thu_NH_Ct": loadTablePhieu_Thu_NH_Ct(); break;
             case "xoa": XoaPhieu_Thu_NH(); break;
             case "xoaPhieu_Thu_NH_Ct": XoaPhieu_Thu_NH_Ct(); break;
         }
     }
 
     private void XoaPhieu_Thu_NH()
     {
         try
         {
                DataProcess process = s_Phieu_Thu_NH();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phieu_thu_id"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void XoaPhieu_Thu_NH_Ct()
     {
         try
         {
                DataProcess process = s_Phieu_Thu_NH_Ct();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phieu_thu_ct_id"));
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
 //        string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
 //        DataTable table = Process.Phieu_Thu_NH.dtSearchByphieu_thu_id(idkhoachinh);
 //string html = "";
 //html += "<root>";
 //        html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
 //        html += Environment.NewLine;
 //        if (table != null)
 //        {
 //            if (table.Rows.Count > 0)
 //            {
 
 //                for (int y = 0; y < table.Columns.Count; y++)
 //                {
 //                    try
 //                    {
 //                        html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
 //                    }
 //                    catch (Exception)
 //                    {
 //                        html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
 //                    }
 //                    html += Environment.NewLine;
 //                }
 //            }
 //        }
 //        html += "</root>";
 //        Response.Clear();
 //        Response.Write(html);
     }
 
     private void TimKiem()
     {
                DataProcess process = s_Phieu_Thu_NH();
         process.Page = Request.QueryString["page"];
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.phieu_thu_id),T.*
                               from Phieu_Thu_NH T
          where "+process.sWhere());
         string html ="";
         html += "<table class='jtable' id=\"tablefind\">";
         html += "<tr>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("phieu_thu_id") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("so_ct") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngay_thu") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ma_nh") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ten_nh") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tk_nh") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ma_nvthu") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ten_nvthu") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loai_tien") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ty_gia") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("user_dau") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("date_dau") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("user_cuoi") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("date_cuoi") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("status") + "</th>";
         html += "</tr>";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr onclick=\"setControlFind('" + table.Rows[i]["phieu_thu_id"].ToString() + "')\">";
                         html += "<td>" + table.Rows[i]["so_ct"].ToString() + "</td>";
                         if(table.Rows[i]["ngay_thu"].ToString() != ""){
                        html += "<td>" + DateTime.Parse(table.Rows[i]["ngay_thu"].ToString()).ToString("dd/MM/yyyy") + "</td>";}
                        else{html += "<td>" + table.Rows[i]["ngay_thu"].ToString()+ "</td>";}
                         html += "<td>" + table.Rows[i]["ma_nh"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["ten_nh"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["tk_nh"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["ma_nvthu"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["ten_nvthu"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["loai_tien"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["ty_gia"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["user_dau"].ToString() + "</td>";
                         if(table.Rows[i]["date_dau"].ToString() != ""){
                        html += "<td>" + DateTime.Parse(table.Rows[i]["date_dau"].ToString()).ToString("dd/MM/yyyy") + "</td>";}
                        else{html += "<td>" + table.Rows[i]["date_dau"].ToString()+ "</td>";}
                         html += "<td>" + table.Rows[i]["user_cuoi"].ToString() + "</td>";
                         if(table.Rows[i]["date_cuoi"].ToString() != ""){
                        html += "<td>" + DateTime.Parse(table.Rows[i]["date_cuoi"].ToString()).ToString("dd/MM/yyyy") + "</td>";}
                        else{html += "<td>" + table.Rows[i]["date_cuoi"].ToString()+ "</td>";}
                         html += "<td>" + table.Rows[i]["status"].ToString() + "</td>";
                 html += "</tr>";
             }
             html += "</table>";
            html += process.Paging();
                     Response.Clear();Response.Write(html);
             return;
         }}
         else
         {
                     Response.StatusCode = 500;
         }
     }
 
     private void SavePhieu_Thu_NH()
     {
         try
         {
              DataProcess process = s_Phieu_Thu_NH();
             if (process.getData("phieu_thu_id") != null && process.getData("phieu_thu_id") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phieu_thu_id"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phieu_thu_id"));
                 return;
             }
           }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
  public void LuuTablePhieu_Thu_NH_Ct()
     {
         try
         {
              DataProcess process = s_Phieu_Thu_NH_Ct();
             if (process.getData("phieu_thu_ct_id") != null && process.getData("phieu_thu_ct_id") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phieu_thu_ct_id"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phieu_thu_ct_id"));
                 return;
             }
           }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 public void loadTablePhieu_Thu_NH_Ct()
     {
                DataProcess process = s_Phieu_Thu_NH_Ct();
         process.Page = Request.QueryString["page"];
         DataTable table = process.Search(@"select STT=row_number() over (order by T.phiu_thu_ct_id),T.*
                               from Phieu_Thu_NH_Ct T
          where T.id_phieuthu_nh='" + process.getData("phieu_thu_id") + "'");
         string html ="";
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
         html += "<th>STT</th>";
         html += "<th></th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tk_no") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tk_co") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanh_tienVND") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dien_giai") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("so_hd") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("VAT") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ma_ncc") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ten_ncc") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("so_series") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("status_fix") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngay_hd") + "</th>";
         html += "<th></th>";
         html += "</tr>";
         if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr>";
                 html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                 html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                         html += "<td><input mkv='true' id='tk_no' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tk_no"].ToString() + "' /></td>";
                         html += "<td><input mkv='true' id='tk_co' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tk_co"].ToString() + "' /></td>";
                         html += "<td><input mkv='true' id='thanh_tienVND' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["thanh_tienVND"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                         html += "<td><input mkv='true' id='dien_giai' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["dien_giai"].ToString() + "' /></td>";
                         html += "<td><input mkv='true' id='so_hd' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["so_hd"].ToString() + "' /></td>";
                         html += "<td><input mkv='true' id='VAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["VAT"].ToString() + "' /></td>";
                         html += "<td><input mkv='true' id='ma_ncc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ma_ncc"].ToString() + "' /></td>";
                         html += "<td><input mkv='true' id='ten_ncc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ten_ncc"].ToString() + "' /></td>";
                         html += "<td><input mkv='true' id='so_series' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["so_series"].ToString() + "' /></td>";
                         html += "<td><input mkv='true' id='status_fix' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["status_fix"].ToString() == "True" ? "checked" : "") + " /></td>";
                         if(table.Rows[i]["ngay_hd"].ToString() != ""){
                         html += "<td><input mkv='true' id='ngay_hd' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + DateTime.Parse(table.Rows[i]["ngay_hd"].ToString()).ToString("dd/MM/yyyy") + "' onblur='TestDate(this)' /></td>";}
                        else{ html += "<td><input mkv='true' id='ngay_hd' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + table.Rows[i]["ngay_hd"].ToString() + "' onblur='TestDate(this)' /></td>";}
                 html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["phieu_thu_ct_id"].ToString() + "'/></td>";
                 html += "</tr>";
             }
         }
         else
         {
                 html += "<tr>";
                 html += "<td>1</td>";
                 html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                         html += "<td><input mkv='true' id='tk_no' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                         html += "<td><input mkv='true' id='tk_co' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                         html += "<td><input mkv='true' id='thanh_tienVND' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
                         html += "<td><input mkv='true' id='dien_giai' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                         html += "<td><input mkv='true' id='so_hd' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                         html += "<td><input mkv='true' id='VAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                         html += "<td><input mkv='true' id='ma_ncc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                         html += "<td><input mkv='true' id='ten_ncc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                         html += "<td><input mkv='true' id='so_series' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                         html += "<td><input mkv='true' id='status_fix' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
                         html += "<td><input mkv='true' id='ngay_hd' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)'/></td>";
                 html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
                 html += "</tr>";
         }
         html += "<tr><td></td><td></td></tr>";
         html += "</table>";
        html += process.Paging("Phieu_Thu_NH_Ct");
                 Response.Clear();Response.Write(html);
     }
 }
 
 

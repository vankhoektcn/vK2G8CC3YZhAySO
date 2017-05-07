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
 
 public partial class KCB_CapCuu_ajax : System.Web.UI.Page
 {
     protected DataProcess s_KCB_CapCuu()
     {
             DataProcess KCB_CapCuu = new DataProcess("KCB_CapCuu"); 
             KCB_CapCuu.data("idkcbcapcuu",Request.QueryString["idkcbcapcuu"]);
             KCB_CapCuu.data("idkhambenh", Request.QueryString["idkhambenhgoc"]);
             KCB_CapCuu.data("benhly",Request.QueryString["benhly"]);
             KCB_CapCuu.data("tiensubanthan",Request.QueryString["tiensubanthan"]);
             KCB_CapCuu.data("tiensugiadinh",Request.QueryString["tiensugiadinh"]);
             KCB_CapCuu.data("khambenhtoanthan",Request.QueryString["khambenhtoanthan"]);
             KCB_CapCuu.data("khambenhcacbophan",Request.QueryString["khambenhcacbophan"]);
             KCB_CapCuu.data("ketquacanlamsan",Request.QueryString["ketquacanlamsan"]);
             KCB_CapCuu.data("chandoanbandau",Request.QueryString["chandoanbandau"]);
             KCB_CapCuu.data("xuly",Request.QueryString["xuly"]);
             KCB_CapCuu.data("chandoanravien",Request.QueryString["chandoanravien"]);
             KCB_CapCuu.data("ngaybatdaudieutri",Request.QueryString["ngaybatdaudieutri"]);
             KCB_CapCuu.data("ngayketthucdieutri",Request.QueryString["ngayketthucdieutri"]);
             KCB_CapCuu.data("benhlyvadienbien",Request.QueryString["benhlyvadienbien"]);
             KCB_CapCuu.data("ketquacanlamsancogiatri",Request.QueryString["ketquacanlamsancogiatri"]);
             KCB_CapCuu.data("chandoanravienchinh",Request.QueryString["chandoanravienchinh"]);
             KCB_CapCuu.data("chandoanravienkemtheo",Request.QueryString["chandoanravienkemtheo"]);
             KCB_CapCuu.data("phuongphapdieutri",Request.QueryString["phuongphapdieutri"]);
             KCB_CapCuu.data("tinhtrangravien",Request.QueryString["tinhtrangravien"]);
             KCB_CapCuu.data("huongdieutritieptheo",Request.QueryString["huongdieutritieptheo"]);
             KCB_CapCuu.data("idbacsi",Request.QueryString["idbacsi"]);
            return KCB_CapCuu;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": SaveKCB_CapCuu(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": XoaKCB_CapCuu(); break;
              case "idkhambenhSearch": idkhambenhSearch(); break;
              case "idbacsiSearch": idbacsiSearch(); break;
         }
     }
 
     private void idkhambenhSearch()
     {
         DataTable table = Process.khambenh .dtGetAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void idbacsiSearch()
     {
         DataTable table = Process.bacsi .dtGetAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void XoaKCB_CapCuu()
     {
         try
         {
                DataProcess process = s_KCB_CapCuu();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkcbcapcuu"));
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
         string idkhoachinh = Request.QueryString["idkhambenhgoc"].ToString();
         DataTable table = Process.KCB_CapCuu.dtSearchByidkhambenh("'"+idkhoachinh+"'");
          string html = ""; 
         html += "<root>";
          
         html += Environment.NewLine;
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 //DataTable tablesovaovien = DataAcess.Connect.GetTable("select sovaovien from khambenh where idkhambenh = '"+idkhoachinh+"'");
                 //if (tablesovaovien.Rows.Count > 0)
                 //   html += "<data id=\"sovaovien\">" + tablesovaovien.Rows[0]["sovaovien"] + "</data>";

                 html += "<data id=\"idkcbcapcuu\">" + table.Rows[0]["idkcbcapcuu"] + "</data>";
                 for (int y = 0; y < table.Columns.Count; y++)
                 {
                     try
                     {
                         html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                     }
                     catch (Exception)
                     {
                         html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                     }
                     html += Environment.NewLine;
                 }
             }
         }
         html += "</root>";
         Response.Clear();
         Response.Write(html);
     }
 
     private void SaveKCB_CapCuu()
     {
         try
         {
             //DataProcess khambenh = new DataProcess("khambenh");
             //khambenh.data("sovaovien", (!string.IsNullOrEmpty(Request.QueryString["sovaovien"]) ? Request.QueryString["sovaovien"] : StaticData.NewSoVaoVien(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())));
             //khambenh.data("idkhambenh", Request.QueryString["idkhambenhgoc"]);
             DataProcess process = s_KCB_CapCuu();
             if (process.getData("idkcbcapcuu") != null && process.getData("idkcbcapcuu") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                 //khambenh.Update("idkhambenh");
                         Response.Clear();Response.Write(process.getData("idkcbcapcuu"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                 //khambenh.Update("idkhambenh");
                         Response.Clear();Response.Write(process.getData("idkcbcapcuu"));
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
 
 

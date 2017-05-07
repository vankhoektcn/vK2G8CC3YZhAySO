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
 
 public partial class nhomnguoidung_ajax : System.Web.UI.Page
 {
     protected DataProcess s_nhomnguoidung()
     {
             DataProcess nhomnguoidung = new DataProcess("nhomnguoidung"); 
             nhomnguoidung.data("nhomID",Request.QueryString["idkhoachinh"]);
             nhomnguoidung.data("tennhom",Request.QueryString["tennhom"]);
             nhomnguoidung.data("nhomLinks",Request.QueryString["nhomLinks"]);
             nhomnguoidung.data("isadmin",Request.QueryString["isadmin"]);
             nhomnguoidung.data("motta",Request.QueryString["motta"]);
             nhomnguoidung.data("istiepnhan",Request.QueryString["istiepnhan"]);
             nhomnguoidung.data("NameNotSign",Request.QueryString["NameNotSign"]);
            return nhomnguoidung;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_nhomnguoidung();break ;
             case "xoa": Xoa_nhomnguoidung(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_nhomnguoidung()
     {
         try
         {
                DataProcess process = s_nhomnguoidung();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("nhomID"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_nhomnguoidung()
     {
         try
         {
              DataProcess process = s_nhomnguoidung();
             if (process.getData("nhomID") != null && process.getData("nhomID") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("nhomID"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("nhomID"));
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
 bool search = Userlogin_new.HavePermision(this, "nhomnguoidung_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "nhomnguoidung_Add");
 bool delete = Userlogin_new.HavePermision(this, "nhomnguoidung_Delete");
  bool edit = Userlogin_new.HavePermision(this, "nhomnguoidung_Edit");
                DataProcess process = s_nhomnguoidung();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.nhomID),T.*
                               from nhomnguoidung T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

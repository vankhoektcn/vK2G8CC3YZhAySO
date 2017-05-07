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
 
 public partial class dantoc_ajax : System.Web.UI.Page
 {
     protected DataProcess s_dantoc()
     {
             DataProcess dantoc = new DataProcess("dantoc"); 
             dantoc.data("id",Request.QueryString["idkhoachinh"]);
             dantoc.data("tendantoc",Request.QueryString["tendantoc"]);
             dantoc.data("madantoc",Request.QueryString["madantoc"]);
             dantoc.data("diengiai",Request.QueryString["diengiai"]);
            return dantoc;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_dantoc();break ;
             case "xoa": Xoa_dantoc(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_dantoc()
     {
         try
         {
                DataProcess process = s_dantoc();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("id"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_dantoc()
     {
         try
         {
              DataProcess process = s_dantoc();
             if (process.getData("id") != null && process.getData("id") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("id"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("id"));
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
 bool search = Userlogin_new.HavePermision(this, "dantoc_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "dantoc_Add");
 bool delete = Userlogin_new.HavePermision(this, "dantoc_Delete");
  bool edit = Userlogin_new.HavePermision(this, "dantoc_Edit");
                DataProcess process = s_dantoc();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.id),T.*
                               from dantoc T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

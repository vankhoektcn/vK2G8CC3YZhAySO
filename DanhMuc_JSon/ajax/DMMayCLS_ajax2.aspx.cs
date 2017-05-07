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
 
 public partial class DMMayCLS_ajax : System.Web.UI.Page
 {
     protected DataProcess s_DMMayCLS()
     {
             DataProcess DMMayCLS = new DataProcess("DMMayCLS"); 
             DMMayCLS.data("id",Request.QueryString["idkhoachinh"]);
             DMMayCLS.data("name",Request.QueryString["name"]);
             DMMayCLS.data("maloai",Request.QueryString["maloai"]);
            return DMMayCLS;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_DMMayCLS();break ;
             case "xoa": Xoa_DMMayCLS(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_DMMayCLS()
     {
         try
         {
                DataProcess process = s_DMMayCLS();
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
 
     private void LuuTable_DMMayCLS()
     {
         try
         {
              DataProcess process = s_DMMayCLS();
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
 bool search = Userlogin_new.HavePermision(this, "DMMayCLS_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "DMMayCLS_Add");
 bool delete = Userlogin_new.HavePermision(this, "DMMayCLS_Delete");
  bool edit = Userlogin_new.HavePermision(this, "DMMayCLS_Edit");
                DataProcess process = s_DMMayCLS();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.id),T.*
                               from DMMayCLS T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

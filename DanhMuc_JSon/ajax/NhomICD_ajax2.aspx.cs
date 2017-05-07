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
 
 public partial class NhomICD_ajax : System.Web.UI.Page
 {
     protected DataProcess s_NhomICD()
     {
             DataProcess NhomICD = new DataProcess("NhomICD"); 
             NhomICD.data("IDNhomICD",Request.QueryString["idkhoachinh"]);
             NhomICD.data("IDChuongICD",Request.QueryString["IDChuongICD"]);
             NhomICD.data("TenNhomICD",Request.QueryString["TenNhomICD"]);
            return NhomICD;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_NhomICD();break ;
             case "xoa": Xoa_NhomICD(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_NhomICD()
     {
         try
         {
                DataProcess process = s_NhomICD();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDNhomICD"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_NhomICD()
     {
         try
         {
              DataProcess process = s_NhomICD();
             if (process.getData("IDNhomICD") != null && process.getData("IDNhomICD") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDNhomICD"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDNhomICD"));
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
 bool search = Userlogin_new.HavePermision(this, "NhomICD_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "NhomICD_Add");
 bool delete = Userlogin_new.HavePermision(this, "NhomICD_Delete");
  bool edit = Userlogin_new.HavePermision(this, "NhomICD_Edit");
                DataProcess process = s_NhomICD();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.IDNhomICD),T.*
                               from NhomICD T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

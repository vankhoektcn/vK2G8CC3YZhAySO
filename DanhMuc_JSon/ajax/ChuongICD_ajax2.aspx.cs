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
 
 public partial class ChuongICD_ajax : System.Web.UI.Page
 {
     protected DataProcess s_ChuongICD()
     {
             DataProcess ChuongICD = new DataProcess("ChuongICD"); 
             ChuongICD.data("IDChuongICD",Request.QueryString["idkhoachinh"]);
             ChuongICD.data("TenChuongICD",Request.QueryString["TenChuongICD"]);
            return ChuongICD;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_ChuongICD();break ;
             case "xoa": Xoa_ChuongICD(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_ChuongICD()
     {
         try
         {
                DataProcess process = s_ChuongICD();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDChuongICD"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_ChuongICD()
     {
         try
         {
              DataProcess process = s_ChuongICD();
             if (process.getData("IDChuongICD") != null && process.getData("IDChuongICD") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDChuongICD"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDChuongICD"));
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
 bool search = Userlogin_new.HavePermision(this, "ChuongICD_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "ChuongICD_Add");
 bool delete = Userlogin_new.HavePermision(this, "ChuongICD_Delete");
  bool edit = Userlogin_new.HavePermision(this, "ChuongICD_Edit");
                DataProcess process = s_ChuongICD();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.IDChuongICD),T.*
                               from ChuongICD T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

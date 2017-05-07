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
 
 public partial class phuongxa_ajax : System.Web.UI.Page
 {
     protected DataProcess s_phuongxa()
     {
             DataProcess phuongxa = new DataProcess("phuongxa"); 
             phuongxa.data("phuongxaid",Request.QueryString["idkhoachinh"]);
             phuongxa.data("quanhuyenid",Request.QueryString["quanhuyenid"]);
             phuongxa.data("tenphuongxa",Request.QueryString["tenphuongxa"]);
             phuongxa.data("MaPhuongXa",Request.QueryString["MaPhuongXa"]);
             phuongxa.data("KYHIEU",Request.QueryString["KYHIEU"]);
            return phuongxa;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_phuongxa();break ;
             case "xoa": Xoa_phuongxa(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_phuongxa()
     {
         try
         {
                DataProcess process = s_phuongxa();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phuongxaid"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_phuongxa()
     {
         try
         {
              DataProcess process = s_phuongxa();
             if (process.getData("phuongxaid") != null && process.getData("phuongxaid") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phuongxaid"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phuongxaid"));
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
 bool search = Userlogin_new.HavePermision(this, "phuongxa_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "phuongxa_Add");
 bool delete = Userlogin_new.HavePermision(this, "phuongxa_Delete");
  bool edit = Userlogin_new.HavePermision(this, "phuongxa_Edit");
                DataProcess process = s_phuongxa();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.phuongxaid),T.*
                               from phuongxa T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

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
 
 public partial class KB_NOIDANGKYKB_ajax : System.Web.UI.Page
 {
     protected DataProcess s_KB_NOIDANGKYKB()
     {
             DataProcess KB_NOIDANGKYKB = new DataProcess("KB_NOIDANGKYKB"); 
             KB_NOIDANGKYKB.data("IDNOIDANGKY",Request.QueryString["idkhoachinh"]);
             KB_NOIDANGKYKB.data("MADANGKY",Request.QueryString["MADANGKY"]);
             KB_NOIDANGKYKB.data("TENNOIDANGKY",Request.QueryString["TENNOIDANGKY"]);
             KB_NOIDANGKYKB.data("DUNGTUYEN",Request.QueryString["DUNGTUYEN"]);
            return KB_NOIDANGKYKB;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_KB_NOIDANGKYKB();break ;
             case "xoa": Xoa_KB_NOIDANGKYKB(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_KB_NOIDANGKYKB()
     {
         try
         {
                DataProcess process = s_KB_NOIDANGKYKB();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDNOIDANGKY"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_KB_NOIDANGKYKB()
     {
         try
         {
              DataProcess process = s_KB_NOIDANGKYKB();
             if (process.getData("IDNOIDANGKY") != null && process.getData("IDNOIDANGKY") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDNOIDANGKY"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDNOIDANGKY"));
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
 bool search = Userlogin_new.HavePermision(this, "KB_NOIDANGKYKB_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "KB_NOIDANGKYKB_Add");
 bool delete = Userlogin_new.HavePermision(this, "KB_NOIDANGKYKB_Delete");
  bool edit = Userlogin_new.HavePermision(this, "KB_NOIDANGKYKB_Edit");
                DataProcess process = s_KB_NOIDANGKYKB();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.IDNOIDANGKY),T.*
                               from KB_NOIDANGKYKB T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

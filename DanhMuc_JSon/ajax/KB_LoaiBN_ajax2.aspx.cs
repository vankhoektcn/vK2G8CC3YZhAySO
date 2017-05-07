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
 
 public partial class KB_LoaiBN_ajax : System.Web.UI.Page
 {
     protected DataProcess s_KB_LoaiBN()
     {
             DataProcess KB_LoaiBN = new DataProcess("KB_LoaiBN"); 
             KB_LoaiBN.data("Id",Request.QueryString["idkhoachinh"]);
             KB_LoaiBN.data("TenLoai",Request.QueryString["TenLoai"]);
             KB_LoaiBN.data("GiamGiaKB",Request.QueryString["GiamGiaKB"]);
             KB_LoaiBN.data("TTUT",Request.QueryString["TTUT"]);
             KB_LoaiBN.data("iskhamtruoc",Request.QueryString["iskhamtruoc"]);
             KB_LoaiBN.data("status",Request.QueryString["status"]);
             KB_LoaiBN.data("MALOAIBN",Request.QueryString["MALOAIBN"]);
            return KB_LoaiBN;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_KB_LoaiBN();break ;
             case "xoa": Xoa_KB_LoaiBN(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_KB_LoaiBN()
     {
         try
         {
                DataProcess process = s_KB_LoaiBN();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("Id"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_KB_LoaiBN()
     {
         try
         {
              DataProcess process = s_KB_LoaiBN();
             if (process.getData("Id") != null && process.getData("Id") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("Id"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("Id"));
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
 bool search = Userlogin_new.HavePermision(this, "KB_LoaiBN_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "KB_LoaiBN_Add");
 bool delete = Userlogin_new.HavePermision(this, "KB_LoaiBN_Delete");
  bool edit = Userlogin_new.HavePermision(this, "KB_LoaiBN_Edit");
                DataProcess process = s_KB_LoaiBN();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.Id),T.*
                               from KB_LoaiBN T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

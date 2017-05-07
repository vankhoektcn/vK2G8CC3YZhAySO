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
 
 public partial class KB_DONVITINH_DV_ajax : System.Web.UI.Page
 {
     protected DataProcess s_KB_DONVITINH_DV()
     {
             DataProcess KB_DONVITINH_DV = new DataProcess("KB_DONVITINH_DV"); 
             KB_DONVITINH_DV.data("IDDVT",Request.QueryString["idkhoachinh"]);
             KB_DONVITINH_DV.data("TenDVt",Request.QueryString["TenDVt"]);
            return KB_DONVITINH_DV;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_KB_DONVITINH_DV();break ;
             case "xoa": Xoa_KB_DONVITINH_DV(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_KB_DONVITINH_DV()
     {
         try
         {
                DataProcess process = s_KB_DONVITINH_DV();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDDVT"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_KB_DONVITINH_DV()
     {
         try
         {
              DataProcess process = s_KB_DONVITINH_DV();
             if (process.getData("IDDVT") != null && process.getData("IDDVT") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDDVT"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDDVT"));
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
             bool search = Userlogin_new.HavePermision(this, "KB_DONVITINH_DV_Search");
            if(search){
             bool add = Userlogin_new.HavePermision(this, "KB_DONVITINH_DV_Add");
             bool delete = Userlogin_new.HavePermision(this, "KB_DONVITINH_DV_Delete");
              bool edit = Userlogin_new.HavePermision(this, "KB_DONVITINH_DV_Edit");
                            DataProcess process = s_KB_DONVITINH_DV();
                     process.EnablePaging = false;
                             DataTable table = process.Search(@"select STT=row_number() over (order by T.IDDVT),T.*
                                           from KB_DONVITINH_DV T
                      where "+process.sWhere());
                     Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
                 }
                 else{
                     Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
                }
     }
 }
 
 

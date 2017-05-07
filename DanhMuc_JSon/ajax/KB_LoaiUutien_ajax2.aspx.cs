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
 
 public partial class KB_LoaiUutien_ajax : System.Web.UI.Page
 {
     protected DataProcess s_KB_LoaiUutien()
     {
             DataProcess KB_LoaiUutien = new DataProcess("KB_LoaiUutien"); 
             KB_LoaiUutien.data("Id",Request.QueryString["idkhoachinh"]);
             KB_LoaiUutien.data("TenLoai",Request.QueryString["TenLoai"]);
             KB_LoaiUutien.data("ThuTu",Request.QueryString["ThuTu"]);
            return KB_LoaiUutien;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_KB_LoaiUutien();break ;
             case "xoa": Xoa_KB_LoaiUutien(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_KB_LoaiUutien()
     {
         try
         {
                DataProcess process = s_KB_LoaiUutien();
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
 
     private void LuuTable_KB_LoaiUutien()
     {
         try
         {
              DataProcess process = s_KB_LoaiUutien();
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
 bool search = Userlogin_new.HavePermision(this, "KB_LoaiUutien_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "KB_LoaiUutien_Add");
 bool delete = Userlogin_new.HavePermision(this, "KB_LoaiUutien_Delete");
  bool edit = Userlogin_new.HavePermision(this, "KB_LoaiUutien_Edit");
                DataProcess process = s_KB_LoaiUutien();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.Id),T.*
                               from KB_LoaiUutien T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

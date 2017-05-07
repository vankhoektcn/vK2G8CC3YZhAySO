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
 
 public partial class KB_HuongDieuTri_ajax : System.Web.UI.Page
 {
     protected DataProcess s_KB_HuongDieuTri()
     {
             DataProcess KB_HuongDieuTri = new DataProcess("KB_HuongDieuTri"); 
             KB_HuongDieuTri.data("HuongDieuTriId",Request.QueryString["idkhoachinh"]);
             KB_HuongDieuTri.data("TenHuongDieuTri",Request.QueryString["TenHuongDieuTri"]);
             KB_HuongDieuTri.data("Status",Request.QueryString["Status"]);
             KB_HuongDieuTri.data("ISKetThuc",Request.QueryString["ISKetThuc"]);
            return KB_HuongDieuTri;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_KB_HuongDieuTri();break ;
             case "xoa": Xoa_KB_HuongDieuTri(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_KB_HuongDieuTri()
     {
         try
         {
                DataProcess process = s_KB_HuongDieuTri();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("HuongDieuTriId"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_KB_HuongDieuTri()
     {
         try
         {
              DataProcess process = s_KB_HuongDieuTri();
             if (process.getData("HuongDieuTriId") != null && process.getData("HuongDieuTriId") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("HuongDieuTriId"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("HuongDieuTriId"));
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
 bool search = Userlogin_new.HavePermision(this, "KB_HuongDieuTri_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "KB_HuongDieuTri_Add");
 bool delete = Userlogin_new.HavePermision(this, "KB_HuongDieuTri_Delete");
  bool edit = Userlogin_new.HavePermision(this, "KB_HuongDieuTri_Edit");
                DataProcess process = s_KB_HuongDieuTri();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.HuongDieuTriId),T.*
                               from KB_HuongDieuTri T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

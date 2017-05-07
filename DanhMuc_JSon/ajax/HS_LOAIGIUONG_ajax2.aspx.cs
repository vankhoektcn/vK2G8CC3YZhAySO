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
 
 public partial class HS_LOAIGIUONG_ajax : System.Web.UI.Page
 {
     protected DataProcess s_HS_LOAIGIUONG()
     {
             DataProcess HS_LOAIGIUONG = new DataProcess("HS_LOAIGIUONG"); 
             HS_LOAIGIUONG.data("IDLOAIGIUONG",Request.QueryString["idkhoachinh"]);
             HS_LOAIGIUONG.data("TENLOAIGIUONG",Request.QueryString["TENLOAIGIUONG"]);
            return HS_LOAIGIUONG;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_HS_LOAIGIUONG();break ;
             case "xoa": Xoa_HS_LOAIGIUONG(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_HS_LOAIGIUONG()
     {
         try
         {
                DataProcess process = s_HS_LOAIGIUONG();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDLOAIGIUONG"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_HS_LOAIGIUONG()
     {
         try
         {
              DataProcess process = s_HS_LOAIGIUONG();
             if (process.getData("IDLOAIGIUONG") != null && process.getData("IDLOAIGIUONG") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDLOAIGIUONG"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("IDLOAIGIUONG"));
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
 bool search = Userlogin_new.HavePermision(this, "HS_LOAIGIUONG_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "HS_LOAIGIUONG_Add");
 bool delete = Userlogin_new.HavePermision(this, "HS_LOAIGIUONG_Delete");
  bool edit = Userlogin_new.HavePermision(this, "HS_LOAIGIUONG_Edit");
                DataProcess process = s_HS_LOAIGIUONG();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.IDLOAIGIUONG),T.*
                               from HS_LOAIGIUONG T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

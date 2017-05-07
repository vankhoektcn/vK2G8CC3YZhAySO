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
 
 public partial class KB_DoiTuongBH_ajax : System.Web.UI.Page
 {
     protected DataProcess s_KB_DoiTuongBH()
     {
             DataProcess KB_DoiTuongBH = new DataProcess("KB_DoiTuongBH"); 
             KB_DoiTuongBH.data("Id",Request.QueryString["idkhoachinh"]);
             KB_DoiTuongBH.data("DoiTuong",Request.QueryString["DoiTuong"]);
             KB_DoiTuongBH.data("QuyenLoiChung",Request.QueryString["QuyenLoiChung"]);
             KB_DoiTuongBH.data("KyThuatCao",Request.QueryString["KyThuatCao"]);
             KB_DoiTuongBH.data("TLTT",Request.QueryString["TLTT"]);
             KB_DoiTuongBH.data("VanChuyen",Request.QueryString["VanChuyen"]);
             KB_DoiTuongBH.data("GhiChu",Request.QueryString["GhiChu"]);
            return KB_DoiTuongBH;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_KB_DoiTuongBH();break ;
             case "xoa": Xoa_KB_DoiTuongBH(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_KB_DoiTuongBH()
     {
         try
         {
                DataProcess process = s_KB_DoiTuongBH();
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
 
     private void LuuTable_KB_DoiTuongBH()
     {
         try
         {
              DataProcess process = s_KB_DoiTuongBH();
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
 bool search = Userlogin_new.HavePermision(this, "KB_DoiTuongBH_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "KB_DoiTuongBH_Add");
 bool delete = Userlogin_new.HavePermision(this, "KB_DoiTuongBH_Delete");
  bool edit = Userlogin_new.HavePermision(this, "KB_DoiTuongBH_Edit");
                DataProcess process = s_KB_DoiTuongBH();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.Id),T.*
                               from KB_DoiTuongBH T
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

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
 
 public partial class kb_phongkham_ajax : System.Web.UI.Page
 {
     protected DataProcess s_kb_phongkham()
     {
             DataProcess kb_phongkham = new DataProcess("kb_phongkham"); 
             kb_phongkham.data("id",Request.QueryString["idkhoachinh"]);
             kb_phongkham.data("PhongID",Request.QueryString["PhongID"]);
             kb_phongkham.data("idbacsi",Request.QueryString["idbacsi"]);
             kb_phongkham.data("idphongkhambenh",Request.QueryString["idphongkhambenh"]);
            return kb_phongkham;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_kb_phongkham();break ;
             case "xoa": Xoa_kb_phongkham(); break;
              case "TimKiem": TimKiem(); break;
              case "PhongIDSearch": PhongIDSearch(); break;
              case "idbacsiSearch": idbacsiSearch(); break;
              case "idphongkhambenhSearch": idphongkhambenhSearch(); break;
         }
     }
 
     private void PhongIDSearch()
     {
         DataTable table = DataProcess.GetTable("select * from KB_Phong ");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i]["TenPhong"].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void idbacsiSearch()
     {
         DataTable table = DataProcess.GetTable("select * from bacsi ");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i]["tenbacsi"].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void idphongkhambenhSearch()
     {
         DataTable table = DataProcess.GetTable("select * from phongkhambenh ");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i]["tenphongkhambenh"].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void Xoa_kb_phongkham()
     {
         try
         {
                DataProcess process = s_kb_phongkham();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("id"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void LuuTable_kb_phongkham()
     {
         try
         {
              DataProcess process = s_kb_phongkham();
             if (process.getData("id") != null && process.getData("id") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("id"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("id"));
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
 bool search = Userlogin_new.HavePermision(this, "kb_phongkham_Search");
if(search){
 bool add = Userlogin_new.HavePermision(this, "kb_phongkham_Add");
 bool delete = Userlogin_new.HavePermision(this, "kb_phongkham_Delete");
  bool edit = Userlogin_new.HavePermision(this, "kb_phongkham_Edit");
                DataProcess process = s_kb_phongkham();
         process.EnablePaging = false;
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.id),T.*
                   ,A.TenPhong
                   ,B.tenbacsi
                   ,C.tenphongkhambenh
                               from kb_phongkham T
                    left join KB_Phong  A on T.PhongID=A.Id
                    left join bacsi  B on T.idbacsi=B.idbacsi
                    left join phongkhambenh  C on T.idphongkhambenh=C.idphongkhambenh
          where "+process.sWhere());
         Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
     }
     else{
         Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
 }
 
 

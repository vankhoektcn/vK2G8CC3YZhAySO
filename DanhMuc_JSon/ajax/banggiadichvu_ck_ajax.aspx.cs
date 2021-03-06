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

public partial class banggiadichvu_ck_ajax : System.Web.UI.Page
 {
     //___________________________________________________________________________________________________________________________
     protected DataProcess s_banggiadichvu()
     {
             DataProcess banggiadichvu = new DataProcess("banggiadichvu"); 
             banggiadichvu.data("idbanggiadichvu",Request.QueryString["idkhoachinh"]);
             banggiadichvu.data("tendichvu",Request.QueryString["tendichvu"]);
             banggiadichvu.data("giadichvu",Request.QueryString["giadichvu"]);
             banggiadichvu.data("idphongkhambenh",Request.QueryString["idphongkhambenh"]);
             banggiadichvu.data("PhuThuBH",Request.QueryString["PhuThuBH"]);
             banggiadichvu.data("BHTra",Request.QueryString["BHTra"]);
             banggiadichvu.data("IsSuDungChoBH",Request.QueryString["IsSuDungChoBH"]);
             banggiadichvu.data("IsChuyenKhoa","1");
            return banggiadichvu;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_banggiadichvu();break ;
             case "xoa": Xoa_banggiadichvu(); break;
              case "TimKiem": TimKiem(); break;
              case "idphongkhambenhSearch": idphongkhambenhSearch(); break;
         }
     }
     //___________________________________________________________________________________________________________________________
     private void idphongkhambenhSearch()
     {
         AutoComplete.idphongkhambenhSearch(this, true);
     }
     private void Xoa_banggiadichvu()
     {
         try
         {
                DataProcess process = s_banggiadichvu();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idbanggiadichvu"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
     //___________________________________________________________________________________________________________________________ 
     private void LuuTable_banggiadichvu()
     {
         try
         {
              DataProcess process = s_banggiadichvu();
              string tenbaohiem = process.getData("tenbaohiem");
              if (tenbaohiem == null || tenbaohiem == "")
                  tenbaohiem = process.getData("tendichvu");
              process.data("tenbaohiem", tenbaohiem);
             if (process.getData("idbanggiadichvu") != null && process.getData("idbanggiadichvu") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idbanggiadichvu"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idbanggiadichvu"));
                 return;
             }
           }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
//___________________________________________________________________________________________________________________________
     private void TimKiem()
     {
             bool search = Userlogin_new.HavePermision(this, "banggiadichvu_Search");
            if(search){
             bool add = Userlogin_new.HavePermision(this, "banggiadichvu_Add");
             bool delete = Userlogin_new.HavePermision(this, "banggiadichvu_Delete");
              bool edit = Userlogin_new.HavePermision(this, "banggiadichvu_Edit");
                            DataProcess process = s_banggiadichvu();
                     process.EnablePaging = false;
                             DataTable table = process.Search(@"select STT=row_number() over (order by T.idbanggiadichvu),T.*
                               ,A.tenphongkhambenh
                                           from banggiadichvu T
                                left join phongkhambenh  A on T.idphongkhambenh=A.idphongkhambenh
                      where "+process.sWhere());
                     Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
                 }
                 else{
                     Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
     }
     }
     //___________________________________________________________________________________________________________________________
 }
 
 

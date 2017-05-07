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

public partial class banggiadichvu_dvkt_ajax : System.Web.UI.Page
 {
     protected DataProcess s_banggiadichvu()
     {
             DataProcess banggiadichvu = new DataProcess("banggiadichvu"); 
             banggiadichvu.data("idbanggiadichvu",Request.QueryString["idkhoachinh"]);
             banggiadichvu.data("TenNhom",Request.QueryString["TenNhom"]);
             banggiadichvu.data("tendichvu",Request.QueryString["tendichvu"]);
             banggiadichvu.data("giadichvu",Request.QueryString["giadichvu"]);
             banggiadichvu.data("idphongkhambenh",Request.QueryString["idphongkhambenh"]);
             banggiadichvu.data("PhuThuBH",Request.QueryString["PhuThuBH"]);
             banggiadichvu.data("IsKTC","0");
             banggiadichvu.data("BHTra",Request.QueryString["BHTra"]);
             banggiadichvu.data("IsSuDungChoBH",Request.QueryString["IsSuDungChoBH"]);
             banggiadichvu.data("HangTraiTuyen",Request.QueryString["HangTraiTuyen"]);
             banggiadichvu.data("IsChuyenKhoa","0");
             banggiadichvu.data("IsCLS", "0");
             banggiadichvu.data("IsVC","0");
             banggiadichvu.data("TENNHOMCD",Request.QueryString["TENNHOMCD"]);
             banggiadichvu.data("IsDVKT", "1");
             banggiadichvu.data("IDDVT", Request.QueryString["IDDVT"]);
             banggiadichvu.data("IDNHOMINBV", Request.QueryString["IDNHOMINBV"]);
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
              case "IDDVTSearch": IDDVTSearch(); break;
              case "IDNhomINBV_Search": IDNhomINBV_Search(); break;
          }
      }

      private void IDNhomINBV_Search()
      {
          AutoComplete.IDNhomINBV_Search(this);
      }


      private void IDDVTSearch()
      {
          AutoComplete.IDDVT_CLS_Search(this);
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
    private void TimKiem()
    {
        bool search = Userlogin_new.HavePermision(this, "banggiadichvu_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "banggiadichvu_Add");
            bool delete = Userlogin_new.HavePermision(this, "banggiadichvu_Delete");
            bool edit = Userlogin_new.HavePermision(this, "banggiadichvu_Edit");
            DataProcess process = s_banggiadichvu();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idbanggiadichvu),T.*
                                ,A.tenphongkhambenh
                                ,B.TENDVT
                                ,TENHOMBV=C.TENNHOM
                               from banggiadichvu T
                               left join phongkhambenh  A on T.idphongkhambenh=A.idphongkhambenh
                               LEFT JOIN KB_DONVITINH_DV B ON ISNULL(T.IDDVT,1)=B.IDDVT
                               LEFT JOIN HS_NhomINBV C ON T.IDNHOMINBV=C.IdNhom
                  where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
 }
 
 

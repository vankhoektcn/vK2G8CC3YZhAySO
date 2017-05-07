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

public partial class BenhVien_ajax : System.Web.UI.Page
{
    protected DataProcess s_BenhVien()
    {
        DataProcess BenhVien = new DataProcess("BenhVien");
        BenhVien.data("idBenhVien", Request.QueryString["idkhoachinh"]);
        BenhVien.data("MaBenhVien", Request.QueryString["MaBenhVien"]);
        BenhVien.data("TenBenhVien", Request.QueryString["TenBenhVien"]);
        BenhVien.data("idbanggiadichvu", Request.QueryString["idbanggiadichvu"]);
        BenhVien.data("idbanggiadichvuDDBS", Request.QueryString["idbanggiadichvuDDBS"]);
        BenhVien.data("idbanggiadichvuDD", Request.QueryString["idbanggiadichvuDD"]);
        return BenhVien;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_BenhVien(); break;
            case "xoa": Xoa_BenhVien(); break;
            case "TimKiem": TimKiem(); break;
        }
    }
    private void Xoa_BenhVien()
    {
        try
        {
            DataProcess process = s_BenhVien();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idBenhVien"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_BenhVien()
    {
        try
        {
            DataProcess process = s_BenhVien();
            if (process.getData("idBenhVien") != null && process.getData("idBenhVien") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idBenhVien"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idBenhVien"));
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
        bool search = Userlogin_new.HavePermision(this, "BenhVien_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "BenhVien_Add");
            bool delete = Userlogin_new.HavePermision(this, "BenhVien_Delete");
            bool edit = Userlogin_new.HavePermision(this, "BenhVien_Edit");
            DataProcess process = s_BenhVien();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idBenhVien),T.*
                               from BenhVien T
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



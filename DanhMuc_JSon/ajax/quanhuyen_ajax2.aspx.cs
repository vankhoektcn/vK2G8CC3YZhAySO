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

public partial class quanhuyen_ajax : System.Web.UI.Page
{
    protected DataProcess s_quanhuyen()
    {
        DataProcess quanhuyen = new DataProcess("quanhuyen");
        quanhuyen.data("quanhuyenid", Request.QueryString["idkhoachinh"]);
        quanhuyen.data("tinhid", Request.QueryString["tinhid"]);
        quanhuyen.data("quanhuyenname", Request.QueryString["quanhuyenname"]);
        quanhuyen.data("MaQuanHuyen", Request.QueryString["MaQuanHuyen"]);
        return quanhuyen;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_quanhuyen(); break;
            case "xoa": Xoa_quanhuyen(); break;
            case "TimKiem": TimKiem(); break;
        }
    }
    private void Xoa_quanhuyen()
    {
        try
        {
            DataProcess process = s_quanhuyen();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("quanhuyenid"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_quanhuyen()
    {
        try
        {
            DataProcess process = s_quanhuyen();
            if (process.getData("quanhuyenid") != null && process.getData("quanhuyenid") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("quanhuyenid"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("quanhuyenid"));
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
        bool search = Userlogin_new.HavePermision(this, "quanhuyen_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "quanhuyen_Add");
            bool delete = Userlogin_new.HavePermision(this, "quanhuyen_Delete");
            bool edit = Userlogin_new.HavePermision(this, "quanhuyen_Edit");
            DataProcess process = s_quanhuyen();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.quanhuyenid),T.*
                               from quanhuyen T
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



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

public partial class tinh_ajax : System.Web.UI.Page
{
    protected DataProcess s_tinh()
    {
        DataProcess tinh = new DataProcess("tinh");
        tinh.data("tinhid", Request.QueryString["idkhoachinh"]);
        tinh.data("tinhname", Request.QueryString["tinhname"]);
        tinh.data("MaTinh", Request.QueryString["MaTinh"]);
        return tinh;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_tinh(); break;
            case "xoa": Xoa_tinh(); break;
            case "TimKiem": TimKiem(); break;
        }
    }
    private void Xoa_tinh()
    {
        try
        {
            DataProcess process = s_tinh();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("tinhid"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_tinh()
    {
        try
        {
            DataProcess process = s_tinh();
            if (process.getData("tinhid") != null && process.getData("tinhid") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("tinhid"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("tinhid"));
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
        bool search = Userlogin_new.HavePermision(this, "tinh_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "tinh_Add");
            bool delete = Userlogin_new.HavePermision(this, "tinh_Delete");
            bool edit = Userlogin_new.HavePermision(this, "tinh_Edit");
            DataProcess process = s_tinh();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.tinhid),T.*
                               from tinh T
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



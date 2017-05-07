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

public partial class So_Du_Tk_Dau_Ky_ajax : System.Web.UI.Page
{
    protected DataProcess s_So_Du_Tk_Dau_Ky()
    {
        DataProcess So_Du_Tk_Dau_Ky = new DataProcess("So_Du_Tk_Dau_Ky");
        So_Du_Tk_Dau_Ky.data("So_Du_Tk_id", Request.QueryString["idkhoachinh"]);
        So_Du_Tk_Dau_Ky.data("nam", Request.QueryString["nam"]);
        So_Du_Tk_Dau_Ky.data("tai_khoan", Request.QueryString["tai_khoan"]);
        So_Du_Tk_Dau_Ky.data("du_no0", Request.QueryString["du_no0"]);
        So_Du_Tk_Dau_Ky.data("du_co0", Request.QueryString["du_co0"]);
        So_Du_Tk_Dau_Ky.data("du_no_nt0", Request.QueryString["du_no_nt0"]);
        So_Du_Tk_Dau_Ky.data("du_co_nt0", Request.QueryString["du_co_nt0"]);
        So_Du_Tk_Dau_Ky.data("date_dau", Request.QueryString["date_dau"]);
        So_Du_Tk_Dau_Ky.data("userdau", Request.QueryString["userdau"]);
        So_Du_Tk_Dau_Ky.data("date_cuoi", Request.QueryString["date_cuoi"]);
        So_Du_Tk_Dau_Ky.data("user_cuoi", Request.QueryString["user_cuoi"]);
        return So_Du_Tk_Dau_Ky;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_So_Du_Tk_Dau_Ky(); break;
            case "xoa": Xoa_So_Du_Tk_Dau_Ky(); break;
            case "TimKiem": TimKiem(); break;
        }
    }
    private void Xoa_So_Du_Tk_Dau_Ky()
    {
        try
        {
            DataProcess process = s_So_Du_Tk_Dau_Ky();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("So_Du_Tk_id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_So_Du_Tk_Dau_Ky()
    {
        try
        {
            DataProcess process = s_So_Du_Tk_Dau_Ky();
            if (process.getData("So_Du_Tk_id") != null && process.getData("So_Du_Tk_id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("So_Du_Tk_id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("So_Du_Tk_id"));
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
        bool search = StaticData.HavePermision(this, "So_Du_Tk_Dau_Ky_Search");
        if (search)
        {
            bool add = StaticData.HavePermision(this, "So_Du_Tk_Dau_Ky_Add");
            bool delete = StaticData.HavePermision(this, "So_Du_Tk_Dau_Ky_Delete");
            bool edit = StaticData.HavePermision(this, "So_Du_Tk_Dau_Ky_Edit");
            DataProcess process = s_So_Du_Tk_Dau_Ky();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.So_Du_Tk_id),T.*
                               from So_Du_Tk_Dau_Ky T
            where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



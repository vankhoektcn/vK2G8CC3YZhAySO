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
public partial class Permision_ajax : System.Web.UI.Page
{
    protected DataProcess s_Permision()
    {
        DataProcess Permision = new DataProcess("Permision");
        Permision.data("PermID", Request.QueryString["idkhoachinh"]);
        Permision.data("PermName", Request.QueryString["PermName"]);
        Permision.data("PermDesc", Request.QueryString["PermDesc"]);
        Permision.data("Status", Request.QueryString["Status"]);
        Permision.data("IsTransfer", Request.QueryString["IsTransfer"]);
        Permision.data("IsParent", Request.QueryString["IsParent"]);
        Permision.data("SoTT", Request.QueryString["SoTT"]);
        return Permision;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_Permision(); break;
            case "xoa": Xoa_Permision(); break;
            case "TimKiem": TimKiem(); break;
        }
    }
    private void Xoa_Permision()
    {
        try
        {
            DataProcess process = s_Permision();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("PermID"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_Permision()
    {
        try
        {
            DataProcess process = s_Permision();
            if (process.getData("PermID") != null && process.getData("PermID") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("PermID"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("PermID"));
                    return;
                }
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }
    }
    private void TimKiem()
    {
        bool search = Userlogin_new.HavePermision(this, "Permision_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "Permision_Add");
            bool delete = Userlogin_new.HavePermision(this, "Permision_Delete");
            bool edit = Userlogin_new.HavePermision(this, "Permision_Edit");
            DataProcess process = s_Permision();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.PermID),T.*
                               from Permision T
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



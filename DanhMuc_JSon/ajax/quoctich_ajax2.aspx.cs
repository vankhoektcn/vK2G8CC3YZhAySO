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

public partial class quoctich_ajax : System.Web.UI.Page
{
    protected DataProcess s_quoctich()
    {
        DataProcess quoctich = new DataProcess("quoctich");
        quoctich.data("idquoctich", Request.QueryString["idkhoachinh"]);
        quoctich.data("tenquoctich", Request.QueryString["tenquoctich"]);
        quoctich.data("maquoctich", Request.QueryString["maquoctich"]);
        return quoctich;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_quoctich(); break;
            case "xoa": Xoa_quoctich(); break;
            case "TimKiem": TimKiem(); break;
        }
    }
    private void Xoa_quoctich()
    {
        try
        {
            DataProcess process = s_quoctich();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idquoctich"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_quoctich()
    {
        try
        {
            DataProcess process = s_quoctich();
            if (process.getData("idquoctich") != null && process.getData("idquoctich") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idquoctich"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idquoctich"));
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
        bool search = Userlogin_new.HavePermision(this, "quoctich_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "quoctich_Add");
            bool delete = Userlogin_new.HavePermision(this, "quoctich_Delete");
            bool edit = Userlogin_new.HavePermision(this, "quoctich_Edit");
            DataProcess process = s_quoctich();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idquoctich),T.*
                               from quoctich T
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



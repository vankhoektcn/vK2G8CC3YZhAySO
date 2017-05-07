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

public partial class DMLoaiPhi_ajax : System.Web.UI.Page
{
    protected DataProcess s_DMLoaiPhi()
    {
        DataProcess DMLoaiPhi = new DataProcess("DMLoaiPhi");
        DMLoaiPhi.data("Id_lp", Request.QueryString["idkhoachinh"]);
        DMLoaiPhi.data("TenLoaiPhi", Request.QueryString["TenLoaiPhi"]);
        return DMLoaiPhi;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_DMLoaiPhi(); break;
            case "xoa": Xoa_DMLoaiPhi(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_DMLoaiPhi()
    {
        try
        {
            DataProcess process = s_DMLoaiPhi();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("Id_lp"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_DMLoaiPhi()
    {
        try
        {
            DataProcess process = s_DMLoaiPhi();
            if (process.getData("Id_lp") != null && process.getData("Id_lp") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id_lp"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id_lp"));
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
        bool search = Userlogin_new.HavePermision(this, "DMLoaiPhi_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "DMLoaiPhi_Add");
            bool delete = Userlogin_new.HavePermision(this, "DMLoaiPhi_Delete");
            bool edit = Userlogin_new.HavePermision(this, "DMLoaiPhi_Edit");
            DataProcess process = s_DMLoaiPhi();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.Id_lp),T.*
                               from DMLoaiPhi T
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



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

public partial class DMNhomDVKT_ajax2 : System.Web.UI.Page
{
    protected DataProcess s_phongkhambenh()
    {
        DataProcess phongkhambenh = new DataProcess("phongkhambenh");
        phongkhambenh.data("idphongkhambenh", Request.QueryString["idkhoachinh"]);
        phongkhambenh.data("maphongkhambenh", Request.QueryString["maphongkhambenh"]);
        phongkhambenh.data("tenphongkhambenh", Request.QueryString["tenphongkhambenh"]);
        phongkhambenh.data("loaiphong", "1");
        phongkhambenh.data("kyhieu", Request.QueryString["kyhieu"]);
        return phongkhambenh;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_phongkhambenh(); break;
            case "xoa": Xoa_phongkhambenh(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_phongkhambenh()
    {
        try
        {
            DataProcess process = s_phongkhambenh();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idphongkhambenh"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_phongkhambenh()
    {
        try
        {
            DataProcess process = s_phongkhambenh();
            if (process.getData("idphongkhambenh") != null && process.getData("idphongkhambenh") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idphongkhambenh"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idphongkhambenh"));
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
        bool search = Userlogin_new.HavePermision(this, "phongkhambenh_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "phongkhambenh_Add");
            bool delete = Userlogin_new.HavePermision(this, "phongkhambenh_Delete");
            bool edit = Userlogin_new.HavePermision(this, "phongkhambenh_Edit");
            DataProcess process = s_phongkhambenh();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idphongkhambenh),T.*
                               from phongkhambenh T
          where " + process.sWhere());
            table.DefaultView.RowFilter = "loaiphong=1";
            table = table.DefaultView.ToTable();
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



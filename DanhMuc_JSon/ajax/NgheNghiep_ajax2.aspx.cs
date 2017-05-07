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

public partial class NgheNghiep_ajax : System.Web.UI.Page
{
    protected DataProcess s_NgheNghiep()
    {
        DataProcess NgheNghiep = new DataProcess("NgheNghiep");
        NgheNghiep.data("idNgheNghiep", Request.QueryString["idkhoachinh"]);
        NgheNghiep.data("MaNgheNghiep", Request.QueryString["MaNgheNghiep"]);
        NgheNghiep.data("TenNgheNghiep", Request.QueryString["TenNgheNghiep"]);
        NgheNghiep.data("tennghenghieptheoboyte", Request.QueryString["tennghenghieptheoboyte"]);
        return NgheNghiep;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_NgheNghiep(); break;
            case "xoa": Xoa_NgheNghiep(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_NgheNghiep()
    {
        try
        {
            DataProcess process = s_NgheNghiep();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idNgheNghiep"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_NgheNghiep()
    {
        try
        {
            DataProcess process = s_NgheNghiep();
            if (process.getData("idNgheNghiep") != null && process.getData("idNgheNghiep") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idNgheNghiep"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idNgheNghiep"));
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
        bool search = Userlogin_new.HavePermision(this, "NgheNghiep_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "NgheNghiep_Add");
            bool delete = Userlogin_new.HavePermision(this, "NgheNghiep_Delete");
            bool edit = Userlogin_new.HavePermision(this, "NgheNghiep_Edit");
            DataProcess process = s_NgheNghiep();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idNgheNghiep),T.*
                               from NgheNghiep T
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



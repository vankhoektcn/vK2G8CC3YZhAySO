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

public partial class KB_TinhTrangXuatKhoa_ajax : System.Web.UI.Page
{
    protected DataProcess s_KB_TinhTrangXuatKhoa()
    {
        DataProcess KB_TinhTrangXuatKhoa = new DataProcess("KB_TinhTrangXuatKhoa");
        KB_TinhTrangXuatKhoa.data("idTinhTrang", Request.QueryString["idkhoachinh"]);
        KB_TinhTrangXuatKhoa.data("tenTinhTrang", Request.QueryString["tenTinhTrang"]);
        KB_TinhTrangXuatKhoa.data("status", Request.QueryString["status"]);
        KB_TinhTrangXuatKhoa.data("nvk_ttUT", Request.QueryString["nvk_ttUT"]);
        return KB_TinhTrangXuatKhoa;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_KB_TinhTrangXuatKhoa(); break;
            case "xoa": Xoa_KB_TinhTrangXuatKhoa(); break;
            case "TimKiem": TimKiem(); break;
        }
    }
    private void Xoa_KB_TinhTrangXuatKhoa()
    {
        try
        {
            DataProcess process = s_KB_TinhTrangXuatKhoa();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idTinhTrang"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_KB_TinhTrangXuatKhoa()
    {
        try
        {
            DataProcess process = s_KB_TinhTrangXuatKhoa();
            if (process.getData("idTinhTrang") != null && process.getData("idTinhTrang") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idTinhTrang"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idTinhTrang"));
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
        bool search = Userlogin_new.HavePermision(this, "KB_TinhTrangXuatKhoa_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "KB_TinhTrangXuatKhoa_Add");
            bool delete = Userlogin_new.HavePermision(this, "KB_TinhTrangXuatKhoa_Delete");
            bool edit = Userlogin_new.HavePermision(this, "KB_TinhTrangXuatKhoa_Edit");
            DataProcess process = s_KB_TinhTrangXuatKhoa();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idTinhTrang),T.*
                               from KB_TinhTrangXuatKhoa T
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



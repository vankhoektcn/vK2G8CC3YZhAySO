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

public partial class chitietdichvu_ajax : System.Web.UI.Page
{
    protected DataProcess s_chitietdichvu()
    {
        DataProcess chitietdichvu = new DataProcess("chitietdichvu");
        chitietdichvu.data("idchitietdichvu", Request.QueryString["idkhoachinh"]);
        chitietdichvu.data("tenchitiet", Request.QueryString["tenchitiet"]);
        chitietdichvu.data("giatribinhthuong", Request.QueryString["giatribinhthuong"]);
        chitietdichvu.data("donvi", Request.QueryString["donvi"]);
        chitietdichvu.data("tennhom", Request.QueryString["tennhom"]);
        chitietdichvu.data("idbanggiadichvu", Request.QueryString["idbanggiadichvu"]);
        return chitietdichvu;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_chitietdichvu(); break;
            case "xoa": Xoa_chitietdichvu(); break;
            case "TimKiem": TimKiem(); break;
            case "idbanggiadichvuSearch": idbanggiadichvuSearch(); break;
        }
    }

    private void idbanggiadichvuSearch()
    {
        AutoComplete.DichVuKCBSearch(this, false);
    }
    private void Xoa_chitietdichvu()
    {
        try
        {
            DataProcess process = s_chitietdichvu();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idchitietdichvu"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_chitietdichvu()
    {
        try
        {
            DataProcess process = s_chitietdichvu();
            if (process.getData("idchitietdichvu") != null && process.getData("idchitietdichvu") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietdichvu"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietdichvu"));
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
        bool search = Userlogin_new.HavePermision(this, "chitietdichvu_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "chitietdichvu_Add");
            bool delete = Userlogin_new.HavePermision(this, "chitietdichvu_Delete");
            bool edit = Userlogin_new.HavePermision(this, "chitietdichvu_Edit");
            DataProcess process = s_chitietdichvu();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietdichvu),T.*
                   ,A.tendichvu
                               from chitietdichvu T
                    left join banggiadichvu  A on T.idbanggiadichvu=A.idbanggiadichvu
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



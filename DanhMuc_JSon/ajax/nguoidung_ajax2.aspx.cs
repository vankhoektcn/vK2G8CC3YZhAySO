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

public partial class nguoidung_ajax : System.Web.UI.Page
{
    protected DataProcess s_nguoidung()
    {
        DataProcess nguoidung = new DataProcess("nguoidung");
        nguoidung.data("idnguoidung", Request.QueryString["idkhoachinh"]);
        nguoidung.data("tennguoidung", Request.QueryString["tennguoidung"]);
        nguoidung.data("username", Request.QueryString["username"]);
        nguoidung.data("matkhau", Request.QueryString["matkhau"]);
        // nguoidung.data("matkhau", (!string.IsNullOrEmpty(Request.QueryString["matkhau"]) ? HashPassWord.sGetHashPass(Request.QueryString["username"], Request.QueryString["matkhau"]) : ""));
        nguoidung.data("dienthoai", Request.QueryString["dienthoai"]);
        nguoidung.data("isadmin", Request.QueryString["isadmin"]);
        nguoidung.data("nhomID", Request.QueryString["nhomID"]);
        nguoidung.data("idphong", Request.QueryString["idphong"]);
        nguoidung.data("IdBacSi", "");
        return nguoidung;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_nguoidung(); break;
            case "xoa": Xoa_nguoidung(); break;
            case "TimKiem": TimKiem(); break;
            case "nhomIDSearch": nhomIDSearch(); break;
            case "phongidSearch": phongidSearch(); break;
        }
    }
    private void phongidSearch()
    {
        DataTable table = DataProcess.GetTable("select * from kb_phong where tenphong like N'%" + Request.QueryString["q"] + "%'");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenphong"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void nhomIDSearch()
    {
        DataTable table = DataProcess.GetTable("select * from nhomnguoidung where tennhom like N'%"+ Request.QueryString["q"]+"%'");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tennhom"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoa_nguoidung()
    {
        try
        {
            DataProcess process = s_nguoidung();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idnguoidung"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_nguoidung()
    {
        try
        {
            DataProcess process = s_nguoidung();
            if (process.getData("idnguoidung") != null && process.getData("idnguoidung") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idnguoidung"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idnguoidung"));
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
        bool search = Userlogin_new.HavePermision(this, "nguoidung_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "nguoidung_Add");
            bool delete = Userlogin_new.HavePermision(this, "nguoidung_Delete");
            bool edit = Userlogin_new.HavePermision(this, "nguoidung_Edit");
            DataProcess process = s_nguoidung();
            process.EnablePaging = false;
            string sqlSelect = @"select STT=row_number() over (order by T.idnguoidung),T.*
                   ,A.tennhom,B.tenphong
                               from nguoidung T
                    left join nhomnguoidung  A on T.nhomID=A.nhomID
                    left join kb_phong B on T.idphong=B.id
                   where isnull(idbacsi,0)=0 and " + process.sWhere();
            DataTable table = process.Search(sqlSelect);
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    table.Rows[i]["matkhau"] = HashPassWord.sGetHashPass(table.Rows[i]["username"].ToString().Trim(), table.Rows[i]["matkhau"].ToString().Trim());
            //}
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



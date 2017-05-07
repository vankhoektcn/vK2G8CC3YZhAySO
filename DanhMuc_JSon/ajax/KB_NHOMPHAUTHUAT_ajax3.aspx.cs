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

public partial class KB_NHOMPHAUTHUAT_ajax : System.Web.UI.Page
{
    protected DataProcess s_KB_NHOMPHAUTHUAT()
    {
        DataProcess KB_NHOMPHAUTHUAT = new DataProcess("KB_NHOMPHAUTHUAT");
        KB_NHOMPHAUTHUAT.data("IdNhomPhauThuat", Request.QueryString["idkhoachinh"]);
        KB_NHOMPHAUTHUAT.data("TenNhom", Request.QueryString["TenNhom"]);
        return KB_NHOMPHAUTHUAT;
    }
    protected DataProcess s_KB_PHANNHOMPHAUTHUAT()
    {
        DataProcess KB_PHANNHOMPHAUTHUAT = new DataProcess("KB_PHANNHOMPHAUTHUAT");
        KB_PHANNHOMPHAUTHUAT.data("IdPhanNhomPhauThuat", Request.QueryString["idkhoachinh"]);
        KB_PHANNHOMPHAUTHUAT.data("IdNhomPhauThuat", Request.QueryString["IdNhomPhauThuat"]);
        return KB_PHANNHOMPHAUTHUAT;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveKB_NHOMPHAUTHUAT(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableKB_PHANNHOMPHAUTHUAT": LuuTableKB_PHANNHOMPHAUTHUAT(); break;
            case "loadTableKB_PHANNHOMPHAUTHUAT": loadTableKB_PHANNHOMPHAUTHUAT(); break;
            case "xoa": XoaKB_NHOMPHAUTHUAT(); break;
            case "xoaKB_PHANNHOMPHAUTHUAT": XoaKB_PHANNHOMPHAUTHUAT(); break;
        }
    }
    private void XoaKB_NHOMPHAUTHUAT()
    {
        try
        {
            DataProcess process = s_KB_NHOMPHAUTHUAT();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdNhomPhauThuat"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void XoaKB_PHANNHOMPHAUTHUAT()
    {
        try
        {
            DataProcess process = s_KB_PHANNHOMPHAUTHUAT();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdPhanNhomPhauThuat"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void setTimKiem()
    {
        if (Userlogin_new.HavePermision(this, "KB_NHOMPHAUTHUAT_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 idkhoachinh=T.IdNhomPhauThuat,T.*
                               from KB_NHOMPHAUTHUAT T
 where T.IdNhomPhauThuat ='" + idkhoachinh + "'");
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }

    private void TimKiem()
    {
        if (Userlogin_new.HavePermision(this, "KB_NHOMPHAUTHUAT_Search"))
        {
            DataProcess process = s_KB_NHOMPHAUTHUAT();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdNhomPhauThuat),T.*
                               from KB_NHOMPHAUTHUAT T
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdNhomPhauThuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenNhom") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["IdNhomPhauThuat"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["TenNhom"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                    html.Append("</table>");
                    html.Append(process.Paging());
                    Response.Clear(); Response.Write(html);
                    return;
                }
            }
            else
            {
                Response.StatusCode = 500;
            }
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }

    private void SaveKB_NHOMPHAUTHUAT()
    {
        try
        {
            DataProcess process = s_KB_NHOMPHAUTHUAT();
            if (process.getData("IdNhomPhauThuat") != null && process.getData("IdNhomPhauThuat") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdNhomPhauThuat"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdNhomPhauThuat"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableKB_PHANNHOMPHAUTHUAT()
    {
        try
        {
            DataProcess process = s_KB_PHANNHOMPHAUTHUAT();
            if (process.getData("IdPhanNhomPhauThuat") != null && process.getData("IdPhanNhomPhauThuat") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdPhanNhomPhauThuat"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdPhanNhomPhauThuat"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableKB_PHANNHOMPHAUTHUAT()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = Userlogin_new.HavePermision(this, "KB_PHANNHOMPHAUTHUAT_Add");
        bool search = Userlogin_new.HavePermision(this, "KB_PHANNHOMPHAUTHUAT_Search");
        if (search)
        {
            DataProcess process = s_KB_PHANNHOMPHAUTHUAT();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdPhanNhomPhauThuat),T.*
                   ,A.TenNhom
                               from KB_PHANNHOMPHAUTHUAT T
                    left join KB_NHOMPHAUTHUAT  A on T.IdNhomPhauThuat=A.IdNhomPhauThuat
          where T.IdNhomPhauThuat='" + process.getData("IdNhomPhauThuat") + "'");
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("KB_PHANNHOMPHAUTHUAT");
                bool delete = Userlogin_new.HavePermision(this, "KB_PHANNHOMPHAUTHUAT_Delete");
                bool edit = Userlogin_new.HavePermision(this, "KB_PHANNHOMPHAUTHUAT_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["IdPhanNhomPhauThuat"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
}



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

public partial class KB_NhomCLS_ajax : System.Web.UI.Page
{
    protected DataProcess s_KB_NhomCLS()
    {
        DataProcess KB_NhomCLS = new DataProcess("KB_NhomCLS");
        KB_NhomCLS.data("NhomId", Request.QueryString["idkhoachinh"]);
        KB_NhomCLS.data("TenNhom", Request.QueryString["TenNhom"]);
        KB_NhomCLS.data("GhiChu", Request.QueryString["GhiChu"]);
        return KB_NhomCLS;
    }
    protected DataProcess s_KB_ChiTietNhomCLS()
    {
        DataProcess KB_ChiTietNhomCLS = new DataProcess("KB_ChiTietNhomCLS");
        KB_ChiTietNhomCLS.data("Id", Request.QueryString["idkhoachinh"]);
        KB_ChiTietNhomCLS.data("NhomID", Request.QueryString["NhomID"]);
        KB_ChiTietNhomCLS.data("idbanggiadichvu", Request.QueryString["idbanggiadichvu"]);
        return KB_ChiTietNhomCLS;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveKB_NhomCLS(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableKB_ChiTietNhomCLS": LuuTableKB_ChiTietNhomCLS(); break;
            case "loadTableKB_ChiTietNhomCLS": loadTableKB_ChiTietNhomCLS(); break;
            case "xoa": XoaKB_NhomCLS(); break;
            case "xoaKB_ChiTietNhomCLS": XoaKB_ChiTietNhomCLS(); break;
            case "idbanggiadichvuSearch": idbanggiadichvuSearch(); break;
        }
    }
    private void idbanggiadichvuSearch()
    {
        string svalue = Request.QueryString["q"];
        string sqlSelect = "select * from banggiadichvu where isnull(ischuyenkhoa,0)=0";
        if (svalue != null) sqlSelect += " and tendichvu like N'%" + svalue + "%'";

        DataTable table = DataProcess.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tendichvu"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaKB_NhomCLS()
    {
        try
        {
            DataProcess process = s_KB_NhomCLS();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("NhomId"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void XoaKB_ChiTietNhomCLS()
    {
        try
        {
            DataProcess process = s_KB_ChiTietNhomCLS();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("Id"));
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
        if (Userlogin_new.HavePermision(this, "KB_NhomCLS_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 idkhoachinh=T.NhomId,T.*
                               from KB_NhomCLS T
 where T.NhomId ='" + idkhoachinh + "'");
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
        if (Userlogin_new.HavePermision(this, "KB_NhomCLS_Search"))
        {
            DataProcess process = s_KB_NhomCLS();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.NhomId),T.*
                               from KB_NhomCLS T
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NhomId") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenNhom") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["NhomId"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["TenNhom"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["GhiChu"].ToString() + "</td>");
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
    private void SaveKB_NhomCLS()
    {
        try
        {
            DataProcess process = s_KB_NhomCLS();
            if (process.getData("NhomId") != null && process.getData("NhomId") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("NhomId"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("NhomId"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableKB_ChiTietNhomCLS()
    {
        try
        {
            DataProcess process = s_KB_ChiTietNhomCLS();
            if (process.getData("Id") != null && process.getData("Id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableKB_ChiTietNhomCLS()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + "Dịch vụ" + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = Userlogin_new.HavePermision(this, "KB_ChiTietNhomCLS_Add");
        bool search = Userlogin_new.HavePermision(this, "KB_ChiTietNhomCLS_Search");
        if (search)
        {
            DataProcess process = s_KB_ChiTietNhomCLS();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.Id),T.*
                   ,A.TenNhom
                   ,B.tendichvu
                               from KB_ChiTietNhomCLS T
                    left join KB_NhomCLS  A on T.NhomID=A.NhomId
                    left join banggiadichvu  B on T.idbanggiadichvu=B.idbanggiadichvu
          where T.NhomID='" + process.getData("NhomID") + "'");
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("KB_ChiTietNhomCLS");
                bool delete = Userlogin_new.HavePermision(this, "KB_ChiTietNhomCLS_Delete");
                bool edit = Userlogin_new.HavePermision(this, "KB_ChiTietNhomCLS_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td   style='width:20px'   >" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td   style='width:50px'  ><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='idbanggiadichvu' type='hidden' value='" + table.Rows[i]["idbanggiadichvu"] + "'/><input mkv='true' id='mkv_idbanggiadichvu' type='text' value='" + table.Rows[i]["tendichvu"].ToString() + "' onfocus='idbanggiadichvuSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "  style='width:800px'  /></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["Id"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td  style='width:20px' >1</td>");
            html.Append("<td style='width:50px' ><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='idbanggiadichvu' type='hidden' value=''/><input mkv='true' id='mkv_idbanggiadichvu' type='text' value='' onfocus='idbanggiadichvuSearch(this);' class=\"down_select\"   style='width:800px'/></td>");
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



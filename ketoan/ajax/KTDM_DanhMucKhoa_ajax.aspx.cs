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
public partial class phongkhambenh_ajax : System.Web.UI.Page
{

    protected DataProcess s_phongkhambenh()
    {
        DataProcess phongkhambenh = new DataProcess("phongkhambenh");
        phongkhambenh.data("idphongkhambenh", Request.QueryString["idkhoachinh"]);
        phongkhambenh.data("maphongkhambenh", Request.QueryString["maphongkhambenh"]);
        phongkhambenh.data("tenphongkhambenh", Request.QueryString["tenphongkhambenh"]);
        phongkhambenh.data("truongphong", Request.QueryString["truongphong"]);
        phongkhambenh.data("loaiphong", Request.QueryString["loaiphong"]);
        phongkhambenh.data("ishoptac", Request.QueryString["ishoptac"]);
        phongkhambenh.data("kyhieu", Request.QueryString["kyhieu"]);
        phongkhambenh.data("IsNoiTru", Request.QueryString["IsNoiTru"]);
        phongkhambenh.data("Parrent", Request.QueryString["Parrent"]);
        phongkhambenh.data("tkdoanhthu",Request.QueryString["tkdoanhthu"]);
        phongkhambenh.data("tkchiphi",Request.QueryString["tkchiphi"]);
        return phongkhambenh;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savephongkhambenh(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoaphongkhambenh(); break;
            case "TimKiem": TimKiem(); break;
        }
    }
    private void Xoaphongkhambenh()
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
    private void setTimKiem()
    {
        if (StaticData.HavePermision(this, "phongkhambenh_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = Process.phongkhambenh.dtSearchByidphongkhambenh(idkhoachinh);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            html.AppendLine("<data id=\"mkv_tkdoanhthu\">" + table.Rows[0]["tkdoanhthu"].ToString() + "</data>");
            html.AppendLine("<data id=\"mkv_tkchiphi\">" + table.Rows[0]["tkchiphi"].ToString() + "</data>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int y = 0; y < table.Columns.Count; y++)
                    {
                        try
                        {
                            html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>");
                        }
                        catch
                        {
                            html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>");
                        }
                    }
                }
            }
            html.AppendLine("</root>");
            Response.Clear();
            Response.Write(html.ToString().Replace("&", "&amp;"));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }
    private void Savephongkhambenh()
    {
        try
        {
            DataProcess process = s_phongkhambenh();
            string tkdoanhthu = process.getData("tkdoanhthu");
            string tkchiphi = process.getData("tkchiphi");
            if (process.getData("idphongkhambenh") != null && process.getData("idphongkhambenh") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    string sqlupdate = "update phongkhambenh set tkdoanhthu='" + tkdoanhthu + "',tkchiphi='" + tkchiphi + "' where idphongkhambenh=" + process.getData("idphongkhambenh");
                    DataAcess.Connect.ExecSQL(sqlupdate);
                    Response.Clear(); Response.Write(process.getData("idphongkhambenh"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    string sqlinsert = " insert phongkhambenh(tkdoanhthu,tkchiphi) values ('" + tkdoanhthu + "','" + tkchiphi + "') where idphongkhambenh=" + process.getData("idphongkhambenh");
                    DataAcess.Connect.ExecSQL(sqlinsert);
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
        if (StaticData.HavePermision(this, "phongkhambenh_Search"))
        {
            DataProcess process = s_phongkhambenh();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idphongkhambenh),T.*
                               from phongkhambenh T
                  where parrent is null and " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append(process.Paging());
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphongkhambenh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenphongkhambenh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("truongphong") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaiphong") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkdoanhthu") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkchiphi") + "</th>");            
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idphongkhambenh"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["maphongkhambenh"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tenphongkhambenh"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["truongphong"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["loaiphong"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tkdoanhthu"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tkchiphi"].ToString() + "</td>");                        
                        html.Append("</tr>");
                    }
                }
            }
            html.Append("</table>");
            html.Append(process.Paging());
            Response.Clear(); Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }
}



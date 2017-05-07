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

public partial class khothuoc_ajax : System.Web.UI.Page
{
    protected DataProcess s_khothuoc()
    {
        DataProcess khothuoc = new DataProcess("khothuoc");
        khothuoc.data("idkho", Request.QueryString["idkhoachinh"]);
        khothuoc.data("makho", Request.QueryString["makho"]);
        khothuoc.data("tenkho", Request.QueryString["tenkho"]);
        khothuoc.data("taikhoankho", Request.QueryString["taikhoankho"]);
        khothuoc.data("taikhoangiavon", Request.QueryString["taikhoangiavon"]);
        khothuoc.data("diachi", Request.QueryString["diachi"]);
        khothuoc.data("IsKT", Request.QueryString["IsKT"]);
        khothuoc.data("IsCLS", Request.QueryString["IsCLS"]);
        khothuoc.data("IsKB", Request.QueryString["IsKB"]);
        khothuoc.data("IdKhoa", Request.QueryString["IdKhoa"]);
        return khothuoc;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savekhothuoc(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoakhothuoc(); break;
            case "TimKiem": TimKiem(); break;
            case "IdKhoaSearch": IdKhoaSearch(); break;
        }
    }
    private void IdKhoaSearch()
    {
        DataTable table = Thuoc_Process.phongkhambenh.dtGetAll();
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i]["TenPhongKhamBenh"].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoakhothuoc()
    {
        try
        {
            DataProcess process = s_khothuoc();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idkho"));
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }
    private void setTimKiem()
    {
        string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
        DataTable table = Thuoc_Process.khothuoc.dtSearchByidkho(idkhoachinh);
        string html = "";
        html += "<root>";
        html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
        DataTable IdKhoa = Thuoc_Process.phongkhambenh.dtSearchByidphongkhambenh("'" + table.Rows[0]["IdKhoa"] + "'");
        html += "<data id=\"mkv_IdKhoa\">" + ((IdKhoa.Rows.Count > 0) ? IdKhoa.Rows[0]["TenPhongKhamBenh"] : "") + "</data>";
        html += Environment.NewLine;
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {

                for (int y = 0; y < table.Columns.Count; y++)
                {
                    try
                    {
                        html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                    }
                    catch (Exception)
                    {
                        html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                    }
                    html += Environment.NewLine;
                }
            }
        }
        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }
    private void Savekhothuoc()
    {
        try
        {
            DataProcess process = s_khothuoc();
            if (process.getData("idkho") != null && process.getData("idkho") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idkho"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idkho"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }
    private void TimKiem()
    {
        string sqlSelect = @"select STT=row_number() over (order by ISNULL(T.IDKHOA,0), T.idkho),T.*
                   ,C.tenphongkhambenh
                               from khothuoc T
                    left join phongkhambenh  C on T.IdKhoa=C.idphongkhambenh
          where 1=1";
        string makho = Request.QueryString["makho"];
        if (makho != null && makho != "")
        {
            sqlSelect += " and makho like N'%" + makho + "%'";
        }
        string tenkho = Request.QueryString["tenkho"];
        if (tenkho != null && tenkho != "")
        {
            sqlSelect += " and tenkho like N'%" + tenkho + "%'";
        }
        DataProcess process = s_khothuoc();
        process.Page = Request.QueryString["page"];
        DataTable table = process.Search(sqlSelect);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("makho") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenkho") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("diachi") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsCLS") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsKB") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoa") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsKT") + "</th>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idkho"].ToString() + "')\">";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td style='text-align:left; padding-left:10px;' >" + table.Rows[i]["makho"].ToString() + "</td>";
                    html += "<td style='text-align:left; padding-left:10px;'>" + table.Rows[i]["tenkho"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["diachi"].ToString() + "</td>";
                    html += "<td><input disabled='true' type='checkbox' " + ((table.Rows[i]["IsCLS"].ToString() == "True") ? "checked" : "") + "/></td>";
                    html += "<td><input disabled='true' type='checkbox' " + ((table.Rows[i]["IsKB"].ToString() == "True") ? "checked" : "") + "/></td>";
                    html += "<td style='text-align:left; padding-left:10px;'>" + table.Rows[i]["tenphongkhambenh"].ToString() + "</td>";
                    html += "<td><input disabled='true' type='checkbox' " + ((table.Rows[i]["IsKT"].ToString() == "True") ? "checked" : "") + "/></td>";
                    html += "</tr>";
                }
            }
        }
        html += "</table>";
        html += process.Paging();
        Response.Clear();
        Response.Write(html);
    }
}



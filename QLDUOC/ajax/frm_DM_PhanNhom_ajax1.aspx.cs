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

public partial class nhomthuoc_ajax : System.Web.UI.Page
{
    protected DataProcess s_nhomthuoc()
    {
        DataProcess nhomthuoc = new DataProcess("nhomthuoc");
        nhomthuoc.data("idnhomthuoc", Request.QueryString["idkhoachinh"]);
        nhomthuoc.data("cateid", Request.QueryString["cateid"]);
        nhomthuoc.data("manhom", Request.QueryString["manhom"]);
        nhomthuoc.data("tennhom", Request.QueryString["tennhom"]);
        nhomthuoc.data("dinhdanhimei", Request.QueryString["dinhdanhimei"]);
        return nhomthuoc;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savenhomthuoc(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoanhomthuoc(); break;
            case "TimKiem": TimKiem(); break;
            case "cateidSearch": cateidSearch(); break;
            case "loaithuocidSearch": loaithuocidSearch(); break;
        }
    }

    private void cateidSearch()
    {
        DataTable table = Thuoc_Process.category.dtSearchByloaithuocid("'" + Request.QueryString["loaithuocid"] + "'");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loaithuocidSearch()
    {
        DataTable table = Thuoc_Process.Thuoc_LoaiThuoc.dtGetAll();
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoanhomthuoc()
    {
        try
        {
            DataProcess process = s_nhomthuoc();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idnhomthuoc"));
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
        DataTable table = Thuoc_Process.nhomthuoc.dtSearchByidnhomthuoc(idkhoachinh);
        string html = "";
        html += "<root>";
        html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
        DataTable cateid = Thuoc_Process.category.dtSearchBycateid("'" + table.Rows[0]["cateid"] + "'");
        DataTable loaithuocid = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID("'" + cateid.Rows[0]["loaithuocid"] + "'");
        html += "<data id=\"mkv_cateid\">" + ((cateid.Rows.Count > 0) ? cateid.Rows[0][1] : "") + "</data>";
        html += "<data id=\"mkv_loaithuocid\">" + ((loaithuocid.Rows.Count > 0) ? loaithuocid.Rows[0][2] : "") + "</data>";
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
        html += "<data id='" + loaithuocid.Columns["loaithuocid"].ToString() + "'>" + loaithuocid.Rows[0]["loaithuocid"].ToString() + "</data>";
        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }

    private void Savenhomthuoc()
    {
        try
        {
            DataProcess process = s_nhomthuoc();
            if (process.getData("idnhomthuoc") != null && process.getData("idnhomthuoc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idnhomthuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idnhomthuoc"));
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
        DataProcess process = s_nhomthuoc();
        process.Page = Request.QueryString["page"];
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idnhomthuoc),T.*
                   ,A.catename
                               from nhomthuoc T
                    left join category  A on T.cateid=A.cateid
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("manhom") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tennhom") + "</th>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idnhomthuoc"].ToString() + "')\">";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["manhom"].ToString() + "</td>";
                    html += "<td style='text-align:left; padding-left:10px;'>" + table.Rows[i]["tennhom"].ToString() + "</td>";
                    html += "</tr>";
                }
            }
        }
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }
}
 
 

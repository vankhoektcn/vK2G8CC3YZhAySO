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

public partial class quanhuyen_ajax : System.Web.UI.Page
{
    protected DataProcess s_quanhuyen()
    {
        DataProcess quanhuyen = new DataProcess("quanhuyen");
        quanhuyen.data("quanhuyenid", Request.QueryString["idkhoachinh"]);
        quanhuyen.data("tinhid", Request.QueryString["tinhid"]);
        quanhuyen.data("quanhuyenname", Request.QueryString["quanhuyenname"]);
        return quanhuyen;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_quanhuyen(); break;
            case "xoa": Xoa_quanhuyen(); break;
            case "TimKiem": TimKiem(); break;
            case "tinhidSearch": tinhidSearch(); break;
        }
    }

    private void tinhidSearch()
    {
        DataTable table = KB_Process.tinh.dtGetAll();
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
    private void Xoa_quanhuyen()
    {
        try
        {
            DataProcess process = s_quanhuyen();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("quanhuyenid"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_quanhuyen()
    {
        try
        {
            DataProcess process = s_quanhuyen();
            if (process.getData("quanhuyenid") != null && process.getData("quanhuyenid") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("quanhuyenid"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("quanhuyenid"));
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
        DataProcess process = s_quanhuyen();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.quanhuyenid),T.*
                   ,A.tinhname
                               from quanhuyen T
                    left join tinh  A on T.tinhid=A.tinhid
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tinhid") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("quanhuyenname") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    html += "<td><input mkv='true' id='tinhid' type='hidden' value='" + table.Rows[i]["tinhid"] + "'/><input mkv='true' id='mkv_tinhid' type='text' value='" + table.Rows[i]["tinhname"] + "' onfocus='tinhidSearch(this);' class=\"down_select\" style='width:90%'/></td>";
                    html += "<td><input mkv='true' id='quanhuyenname' type='text' value='" + table.Rows[i]["quanhuyenname"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["quanhuyenid"] + "'/></td>";
                    html += "</tr>";
                }
            }

            html += "<tr>";
            html += "<td>1</td>";
            html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
            html += "<td><input mkv='true' id='tinhid' type='hidden' value=''/><input mkv='true' id='mkv_tinhid' type='text' value='' onfocus='tinhidSearch(this);' class=\"down_select\" style='width:90%'/></td>";
            html += "<td><input mkv='true' id='quanhuyenname' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }
}
 
 

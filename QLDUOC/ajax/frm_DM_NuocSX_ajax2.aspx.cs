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

public partial class NuocSX_ajax : System.Web.UI.Page
{
    protected DataProcess s_NuocSX()
    {
        DataProcess NuocSX = new DataProcess("NuocSX");
        NuocSX.data("idNuocSX", Request.QueryString["idkhoachinh"]);
        NuocSX.data("maNuocSX", Request.QueryString["maNuocSX"]);
        NuocSX.data("tenNuocSX", Request.QueryString["tenNuocSX"]);
        return NuocSX;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_NuocSX(); break;
            case "xoa": Xoa_NuocSX(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_NuocSX()
    {
        try
        {
            DataProcess process = s_NuocSX();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idNuocSX"));
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }

    private void LuuTable_NuocSX()
    {
        try
        {
            DataProcess process = s_NuocSX();
            if (process.getData("idNuocSX") != null && process.getData("idNuocSX") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idNuocSX"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idNuocSX"));
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
        DataProcess process = s_NuocSX();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idNuocSX),T.*
                               from NuocSX T
          where " + process.sWhere());
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maNuocSX") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenNuocSX") + "</th>";
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
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onkeydown=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    html += "<td><input mkv='true' id='maNuocSX' type='text' value='" + table.Rows[i]["maNuocSX"].ToString() + "' onfocusout='chuyenformout(this)' onkeyup='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='tenNuocSX' type='text' value='" + table.Rows[i]["tenNuocSX"].ToString() + "' onfocusout='chuyenformout(this)' onkeyup='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["idNuocSX"] + "'/></td>";
                    html += "</tr>";
                }
            }
            else
            {
                html += "<tr>";
                html += "<td>1</td>";
                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onkeydown=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                html += "<td><input mkv='true' id='maNuocSX' type='text' value='' onfocusout='chuyenformout(this)' onkeyup='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='tenNuocSX' type='text' value='' onfocusout='chuyenformout(this)' onkeyup='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                html += "</tr>";
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }
}



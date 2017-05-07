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

public partial class frm_DM_CachDung_ajax : System.Web.UI.Page
{
    protected DataProcess s_Thuoc_CachDung()
    {
        DataProcess Thuoc_CachDung = new DataProcess("Thuoc_CachDung");
        Thuoc_CachDung.data("idcachdung", Request.QueryString["idkhoachinh"]);
        Thuoc_CachDung.data("tencachdung", Request.QueryString["tencachdung"]);
        return Thuoc_CachDung;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable":
                LuuTable_Thuoc_CachDung();
                break;
            case "xoa":
                Xoa_Thuoc_CachDung();
                break;
            case "TimKiem":
                TimKiem();
                break;
        }
    }

    private void Xoa_Thuoc_CachDung()
    {
        try
        {
            DataProcess process = s_Thuoc_CachDung();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear();
                Response.Write(process.getData("idcachdung"));
                return;
            }
        }
        catch
        {
        }
        Response.Clear();
        Response.Write("");
    }

    private void LuuTable_Thuoc_CachDung()
    {
        try
        {
            DataProcess process = s_Thuoc_CachDung();
            if (process.getData("idcachdung") != null && process.getData("idcachdung") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear();
                    Response.Write(process.getData("idcachdung"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear();
                    Response.Write(process.getData("idcachdung"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.Clear();
        Response.Write("");
    }

    private void TimKiem()
    {
        DataProcess process = s_Thuoc_CachDung();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table =
            process.Search(
                @"select STT=row_number() over (order by T.TenCachDung),T.*
                               from Thuoc_CachDung T
          where " +
                process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tencachdung") + "</th>";
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
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" +
                            hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    html += "<td><input mkv='true' id='tencachdung' type='text' value='" +
                            table.Rows[i]["tencachdung"].ToString() +
                            "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:800px'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" +
                            table.Rows[i]["idcachdung"] + "'/></td>";
                    html += "</tr>";

                }
            }
            else
            {
                html += "<tr>";
                html += "<td>1</td>";
                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" +
                        hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                html +=
                    "<td><input mkv='true' id='tencachdung' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:800px'/></td>";
                html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                html += "</tr>";
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging();
        Response.Clear();
        Response.Write(html);
    }
}



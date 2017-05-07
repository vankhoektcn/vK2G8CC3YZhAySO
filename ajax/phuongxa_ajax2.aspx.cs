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

public partial class phuongxa_ajax : System.Web.UI.Page
{
    protected DataProcess s_phuongxa()
    {
        DataProcess phuongxa = new DataProcess("phuongxa");
        phuongxa.data("phuongxaid", Request.QueryString["idkhoachinh"]);
        phuongxa.data("quanhuyenid", Request.QueryString["quanhuyenid"]);
        phuongxa.data("tenphuongxa", Request.QueryString["tenphuongxa"]);
        return phuongxa;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_phuongxa(); break;
            case "xoa": Xoa_phuongxa(); break;
            case "TimKiem": TimKiem(); break;
            case "quanhuyenidSearch": quanhuyenidSearch(); break;
            case "tinhidSearch": tinhidSearch(); break;
        }
    }

    private void quanhuyenidSearch()
    {
        string SW = "";
        if (Request.QueryString["tinhid"] != null)
            SW = " and tinhid='" + Request.QueryString["tinhid"].ToString() + "'";
        DataTable table = DataAcess.Connect.GetTable("select * from quanhuyen where 1=1 " + SW);
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
    private void Xoa_phuongxa()
    {
        try
        {
            DataProcess process = s_phuongxa();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("phuongxaid"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_phuongxa()
    {
        try
        {
            DataProcess process = s_phuongxa();
            if (process.getData("phuongxaid") != null && process.getData("phuongxaid") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("phuongxaid"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("phuongxaid"));
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
        string SW = "";
        if (Request.QueryString["tinhid"] != null && Request.QueryString["tinhid"].ToString() != "")
            SW = " and A.tinhid='" + Request.QueryString["tinhid"].ToString() + "'";
        DataProcess process = s_phuongxa();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.phuongxaid),T.*
                   ,A.tinhid,A.quanhuyenname,b.tinhname
                               from phuongxa T
                    left join quanhuyen  A on T.quanhuyenid=A.quanhuyenid
                    left join tinh b on b.tinhid=a.tinhid
          where " + process.sWhere() + SW);
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tinhid") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("quanhuyenid") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenphuongxa") + "</th>";
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
                    html += "<td><input mkv='true' id='quanhuyenid' type='hidden' value='" + table.Rows[i]["quanhuyenid"] + "'/><input mkv='true' id='mkv_quanhuyenid' type='text' value='" + table.Rows[i]["quanhuyenname"] + "' onfocus='quanhuyenidSearch(this);' class=\"down_select\" style='width:90%'/></td>";
                    html += "<td><input mkv='true' id='tenphuongxa' type='text' value='" + table.Rows[i]["tenphuongxa"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["phuongxaid"] + "'/></td>";
                    html += "</tr>";
                }
            }

            html += @"<tr>";
            html += "<td>1</td>";
            html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
            html += "<td><input mkv='true' id='tinhid' type='hidden' value=''/><input mkv='true' id='mkv_tinhid' type='text' value='' onfocus='tinhidSearch(this);' class=\"down_select\" style='width:90%'/></td>";
            html += "<td><input mkv='true' id='quanhuyenid' type='hidden' value=''/><input mkv='true' id='mkv_quanhuyenid' type='text' value='' onfocus='quanhuyenidSearch(this);' class=\"down_select\" style='width:90%'/></td>";
            html += "<td><input mkv='true' id='tenphuongxa' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }
}
 
 

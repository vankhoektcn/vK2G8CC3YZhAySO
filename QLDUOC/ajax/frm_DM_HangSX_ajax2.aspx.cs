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

public partial class hangsanxuat_ajax : System.Web.UI.Page
{
    protected DataProcess s_hangsanxuat()
    {
        DataProcess hangsanxuat = new DataProcess("hangsanxuat");
        hangsanxuat.data("idhangsanxuat", Request.QueryString["idkhoachinh"]);
        hangsanxuat.data("mahangsanxuat", Request.QueryString["mahangsanxuat"]);
        hangsanxuat.data("tenhangsanxuat", Request.QueryString["tenhangsanxuat"]);
        hangsanxuat.data("ishang", Request.QueryString["ishang"]);
        return hangsanxuat;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_hangsanxuat(); break;
            case "xoa": Xoa_hangsanxuat(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_hangsanxuat()
    {
        try
        {
            DataProcess process = s_hangsanxuat();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idhangsanxuat"));
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }

    private void LuuTable_hangsanxuat()
    {
        try
        {
            DataProcess process = s_hangsanxuat();
            if (process.getData("idhangsanxuat") != null && process.getData("idhangsanxuat") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idhangsanxuat"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idhangsanxuat"));
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
        DataProcess process = s_hangsanxuat();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idhangsanxuat),T.*
                               from hangsanxuat T
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("mahangsanxuat") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenhangsanxuat") + "</th>";
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
                    html += "<td><input mkv='true' id='mahangsanxuat' type='text' value='" + table.Rows[i]["mahangsanxuat"].ToString() + "' onfocusout='chuyenformout(this)' onkeyup='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='tenhangsanxuat' type='text' value='" + table.Rows[i]["tenhangsanxuat"].ToString() + "' onfocusout='chuyenformout(this)' onkeyup='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["idhangsanxuat"] + "'/></td>";
                    html += "</tr>";
                }
            }
            else
            {
                html += "<tr>";
                html += "<td>1</td>";
                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onkeydown=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                html += "<td><input mkv='true' id='mahangsanxuat' type='text' value='' onfocusout='chuyenformout(this)' onkeyup='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='tenhangsanxuat' type='text' value='' onfocusout='chuyenformout(this)' onkeyup='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
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
 
 

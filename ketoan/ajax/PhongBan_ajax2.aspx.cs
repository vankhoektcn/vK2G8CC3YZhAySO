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

public partial class PhongBan_ajax : System.Web.UI.Page
{
    protected DataProcess s_PhongBan()
    {
        DataProcess PhongBan = new DataProcess("PhongBan");
        PhongBan.data("idphongban", Request.QueryString["idkhoachinh"]);
        PhongBan.data("maphongban", Request.QueryString["maphongban"]);
        PhongBan.data("tenphongban", Request.QueryString["tenphongban"]);
        PhongBan.data("ghichu", Request.QueryString["ghichu"]);
        PhongBan.data("status", Request.QueryString["status"]);
        return PhongBan;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_PhongBan(); break;
            case "xoa": Xoa_PhongBan(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_PhongBan()
    {
        try
        {
            DataProcess process = s_PhongBan();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idphongban"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_PhongBan()
    {
        try
        {
            DataProcess process = s_PhongBan();
            if (process.getData("idphongban") != null && process.getData("idphongban") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idphongban"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idphongban"));
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
        DataProcess process = s_PhongBan();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idphongban),T.*
                               from PhongBan T
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphongban") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenphongban") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("status") + "</th>";
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
                    if (StaticData.HavePermision(this.Page, "KeToanDM_DMPhongBan_Xoa"))
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    else
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                    html += "<td><input mkv='true' id='maphongban' type='text' value='" + table.Rows[i]["maphongban"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='tenphongban' type='text' value='" + table.Rows[i]["tenphongban"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='ghichu' type='text' value='" + table.Rows[i]["ghichu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='status' type='checkbox' " + (table.Rows[i]["status"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["idphongban"] + "'/></td>";
                    html += "</tr>";
                }
            }
            else
            {
                html += "<tr>";
                html += "<td>1</td>";
                if (StaticData.HavePermision(this.Page, "KeToanDM_DMPhongBan_Xoa"))
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                else
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                html += "<td><input mkv='true' id='maphongban' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='tenphongban' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='status' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'/></td>";
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



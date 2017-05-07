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

public partial class DSManHinh_ajax : System.Web.UI.Page
{
    protected DataProcess s_DSManHinh()
    {
        DataProcess DSManHinh = new DataProcess("DSManHinh");
        DSManHinh.data("Id_ct", Request.QueryString["idkhoachinh"]);
        DSManHinh.data("Ma_ct", Request.QueryString["Ma_ct"]);
        DSManHinh.data("Ten_ct", Request.QueryString["Ten_ct"]);
        DSManHinh.data("Ten_ct2", Request.QueryString["Ten_ct2"]);
        DSManHinh.data("Ma_ct_cha", Request.QueryString["Ma_ct_cha"]);
        DSManHinh.data("So_ct", Request.QueryString["So_ct"]);
        DSManHinh.data("Ma_ct_in", Request.QueryString["Ma_ct_in"]);
        DSManHinh.data("Ma_nt", Request.QueryString["Ma_nt"]);
        DSManHinh.data("Tieu_de_ct", Request.QueryString["Tieu_de_ct"]);
        DSManHinh.data("Tieu_de_ct2", Request.QueryString["Tieu_de_ct2"]);
        DSManHinh.data("Ngay_ct", Request.QueryString["Ngay_ct"]);
        DSManHinh.data("Isnum", Request.QueryString["Isnum"]);
        return DSManHinh;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_DSManHinh(); break;
            case "xoa": Xoa_DSManHinh(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_DSManHinh()
    {
        try
        {
            DataProcess process = s_DSManHinh();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("Id_ct"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_DSManHinh()
    {
        try
        {
            DataProcess process = s_DSManHinh();
            if (process.getData("Id_ct") != null && process.getData("Id_ct") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id_ct"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id_ct"));
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
        DataProcess process = s_DSManHinh();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.Id_ct),T.*
                               from DSManHinh T
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ma_ct") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ten_ct") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ten_ct2") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ma_ct_cha") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("So_ct") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ma_ct_in") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ma_nt") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tieu_de_ct") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tieu_de_ct2") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngay_ct") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Isnum") + "</th>";
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
                    html += "<td><input mkv='true' id='Ma_ct' type='text' value='" + table.Rows[i]["Ma_ct"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='Ten_ct' type='text' value='" + table.Rows[i]["Ten_ct"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:250px'/></td>";
                    html += "<td><input mkv='true' id='Ten_ct2' type='text' value='" + table.Rows[i]["Ten_ct2"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='Ma_ct_cha' type='text' value='" + table.Rows[i]["Ma_ct_cha"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='So_ct' type='text' value='" + table.Rows[i]["So_ct"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='Ma_ct_in' type='text' value='" + table.Rows[i]["Ma_ct_in"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='Ma_nt' type='text' value='" + table.Rows[i]["Ma_nt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='Tieu_de_ct' type='text' value='" + table.Rows[i]["Tieu_de_ct"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:200px'/></td>";
                    html += "<td><input mkv='true' id='Tieu_de_ct2' type='text' value='" + table.Rows[i]["Tieu_de_ct2"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    if (table.Rows[i]["Ngay_ct"].ToString() != "")
                    {
                        html += "<td><input mkv='true' id='Ngay_ct' type='text' value='" + DateTime.Parse(table.Rows[i]["Ngay_ct"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                    }
                    else
                    {
                        html += "<td><input mkv='true' id='Ngay_ct' type='text' value='" + table.Rows[i]["Ngay_ct"] + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                    }
                    html += "<td><input mkv='true' id='Isnum' type='text' disabled value='" + table.Rows[i]["Isnum"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["Id_ct"] + "'/></td>";
                    html += "</tr>";
                }
            }
            else
            {
                html += "<tr>";
                html += "<td>1</td>";
                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                html += "<td><input mkv='true' id='Ma_ct' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='Ten_ct' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:250px'/></td>";
                html += "<td><input mkv='true' id='Ten_ct2' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='Ma_ct_cha' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='So_ct' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='Ma_ct_in' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='Ma_nt' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='Tieu_de_ct' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:200px'/></td>";
                html += "<td><input mkv='true' id='Tieu_de_ct2' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='Ngay_ct' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='Isnum' disabled type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
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



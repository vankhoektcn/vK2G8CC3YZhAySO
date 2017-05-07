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

public partial class DMKhoanMucPhi_ajax : System.Web.UI.Page
{
    protected DataProcess s_DMKhoanMucPhi()
    {
        DataProcess DMKhoanMucPhi = new DataProcess("DMKhoanMucPhi");
        DMKhoanMucPhi.data("khoan_muc_phi_id", Request.QueryString["idkhoachinh"]);
        DMKhoanMucPhi.data("ma_phi", Request.QueryString["ma_phi"]);
        DMKhoanMucPhi.data("ten_phi", Request.QueryString["ten_phi"]);
        DMKhoanMucPhi.data("loai_tien", Request.QueryString["loai_tien"]);
        DMKhoanMucPhi.data("ghi_chu", Request.QueryString["ghi_chu"]);
        DMKhoanMucPhi.data("ten_phi2", Request.QueryString["ten_phi2"]);
        return DMKhoanMucPhi;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_DMKhoanMucPhi(); break;
            case "xoa": Xoa_DMKhoanMucPhi(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_DMKhoanMucPhi()
    {
        try
        {
            DataProcess process = s_DMKhoanMucPhi();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("khoan_muc_phi_id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_DMKhoanMucPhi()
    {
        try
        {
            DataProcess process = s_DMKhoanMucPhi();
            if (process.getData("khoan_muc_phi_id") != null && process.getData("khoan_muc_phi_id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("khoan_muc_phi_id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("khoan_muc_phi_id"));
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
        DataProcess process = s_DMKhoanMucPhi();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.khoan_muc_phi_id),T.*
                               from DMKhoanMucPhi T
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ma_phi") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ten_phi") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loai_tien") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghi_chu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ten_phi2") + "</th>";
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
                    if (StaticData.HavePermision(this.Page, "KeToanD_DMKhoanMucPhi_Xoa"))
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    else
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";

                    html += "<td><input mkv='true' id='ma_phi' type='text' value='" + table.Rows[i]["ma_phi"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='ten_phi' type='text' value='" + table.Rows[i]["ten_phi"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='loai_tien' type='text' value='" + table.Rows[i]["loai_tien"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='ghi_chu' type='text' value='" + table.Rows[i]["ghi_chu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='ten_phi2' type='text' value='" + table.Rows[i]["ten_phi2"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["khoan_muc_phi_id"] + "'/></td>";
                    html += "</tr>";
                }
            }
            else
            {
                html += "<tr>";
                html += "<td>1</td>";
                if (StaticData.HavePermision(this.Page, "KeToanD_DMKhoanMucPhi_Xoa"))
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                else
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";

                html += "<td><input mkv='true' id='ma_phi' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='ten_phi' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='loai_tien' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='ghi_chu' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='ten_phi2' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
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



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

public partial class DMNgoaiTe_ajax : System.Web.UI.Page
{
    protected DataProcess s_DMNgoaiTe()
    {
        DataProcess DMNgoaiTe = new DataProcess("DMNgoaiTe");
        DMNgoaiTe.data("ngoai_te_id", Request.QueryString["idkhoachinh"]);
        DMNgoaiTe.data("ma_nt", Request.QueryString["ma_nt"]);
        DMNgoaiTe.data("ten_nt", Request.QueryString["ten_nt"]);
        DMNgoaiTe.data("ngay", Request.QueryString["ngay"]);
        DMNgoaiTe.data("ty_gia", Request.QueryString["ty_gia"]);
        return DMNgoaiTe;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_DMNgoaiTe(); break;
            case "xoa": Xoa_DMNgoaiTe(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_DMNgoaiTe()
    {
        try
        {
            DataProcess process = s_DMNgoaiTe();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("ngoai_te_id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_DMNgoaiTe()
    {
        try
        {
            DataProcess process = s_DMNgoaiTe();
            if (process.getData("ngoai_te_id") != null && process.getData("ngoai_te_id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("ngoai_te_id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("ngoai_te_id"));
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
        DataProcess process = s_DMNgoaiTe();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.ngoai_te_id),T.*
                               from DMNgoaiTe T
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ma_nt") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ten_nt") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngay") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ty_gia") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        bool quyenthem = StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Them");
        bool quyensua = StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Sua");
        bool quyenxoa = StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Xoa");

        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (quyenthem && quyensua)
                    {
                        html += "<tr>";
                        html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                        if (quyenxoa)
                            html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                        else
                            html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                        html += "<td><input mkv='true' id='ma_nt' type='text' value='" + table.Rows[i]["ma_nt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id='ten_nt' type='text' value='" + table.Rows[i]["ten_nt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                        if (table.Rows[i]["ngay"].ToString() != "")
                        {
                            html += "<td><input mkv='true' id='ngay' type='text' value='" + DateTime.Parse(table.Rows[i]["ngay"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                        }
                        else
                        {
                            html += "<td><input mkv='true' id='ngay' type='text' value='" + table.Rows[i]["ngay"] + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                        }
                        html += "<td><input mkv='true' id='ty_gia' type='text' value='" + table.Rows[i]["ty_gia"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["ngoai_te_id"] + "'/></td>";
                        html += "</tr>";
                    }
                    else
                    {
                        if (quyenthem)
                        {
                            html += "<tr>";
                            html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                            if (StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Xoa"))
                                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                            else
                                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                            html += "<td><input mkv='true' readonly='true' id='ma_nt' type='text' value='" + table.Rows[i]["ma_nt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' readonly='true' id='ten_nt' type='text' value='" + table.Rows[i]["ten_nt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                            if (table.Rows[i]["ngay"].ToString() != "")
                            {
                                html += "<td><input mkv='true' id='ngay' readonly='true' type='text' value='" + DateTime.Parse(table.Rows[i]["ngay"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                            }
                            else
                            {
                                html += "<td><input mkv='true' id='ngay' readonly='true' type='text' value='" + table.Rows[i]["ngay"] + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                            }
                            html += "<td><input mkv='true' id='ty_gia' type='text' readonly='true' value='" + table.Rows[i]["ty_gia"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["ngoai_te_id"] + "'/></td>";
                            html += "</tr>";
                        }
                        else
                        {
                            if (quyensua)
                            {
                                html += "<tr>";
                                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                                if (StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Xoa"))
                                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                                else
                                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                                html += "<td><input mkv='true' id='ma_nt' type='text' value='" + table.Rows[i]["ma_nt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='ten_nt' type='text' value='" + table.Rows[i]["ten_nt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                if (table.Rows[i]["ngay"].ToString() != "")
                                {
                                    html += "<td><input mkv='true' id='ngay' type='text' value='" + DateTime.Parse(table.Rows[i]["ngay"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                                }
                                else
                                {
                                    html += "<td><input mkv='true' id='ngay' type='text' value='" + table.Rows[i]["ngay"] + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                                }
                                html += "<td><input mkv='true' id='ty_gia' type='text' value='" + table.Rows[i]["ty_gia"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["ngoai_te_id"] + "'/></td>";
                                html += "</tr>";
                            }
                            else
                            {
                                html += "<tr>";
                                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                                if (StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Xoa"))
                                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                                else
                                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                                html += "<td><input mkv='true' id='ma_nt' readonly='true' type='text' value='" + table.Rows[i]["ma_nt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='ten_nt' readonly='true' type='text' value='" + table.Rows[i]["ten_nt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                if (table.Rows[i]["ngay"].ToString() != "")
                                {
                                    html += "<td><input mkv='true' id='ngay' readonly='true' type='text' value='" + DateTime.Parse(table.Rows[i]["ngay"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                                }
                                else
                                {
                                    html += "<td><input mkv='true' id='ngay' readonly='true' type='text' value='" + table.Rows[i]["ngay"] + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                                }
                                html += "<td><input mkv='true' id='ty_gia' readonly='true' type='text' value='" + table.Rows[i]["ty_gia"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["ngoai_te_id"] + "'/></td>";
                                html += "</tr>";
                            }
                        }
                        
                    }
                }
            }
            else
            {
                if (StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Them"))
                {
                    html += "<tr>";
                    html += "<td>1</td>";
                    if (StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Xoa"))
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    else
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                    html += "<td><input mkv='true' id='ma_nt' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='ten_nt' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='ngay' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='ty_gia' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                    html += "</tr>";
                }
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }
}



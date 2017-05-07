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

public partial class DMNghiepVu_ajax : System.Web.UI.Page
{
    protected DataProcess s_DMNghiepVu()
    {
        DataProcess DMNghiepVu = new DataProcess("DMNghiepVu");
        DMNghiepVu.data("Id", Request.QueryString["idkhoachinh"]);
        DMNghiepVu.data("MaNghiepVu", Request.QueryString["MaNghiepVu"]);
        DMNghiepVu.data("TenNghiepVu", Request.QueryString["TenNghiepVu"]);
        DMNghiepVu.data("LoaiChungTu", Request.QueryString["LoaiChungTu"]);
        DMNghiepVu.data("DienGiai", Request.QueryString["DienGiai"]);
        DMNghiepVu.data("TKNo", Request.QueryString["TKNo"]);
        DMNghiepVu.data("TKCo", Request.QueryString["TKCo"]);
        DMNghiepVu.data("TKThue", Request.QueryString["TKThue"]);
        DMNghiepVu.data("VAT", Request.QueryString["VAT"]);
        return DMNghiepVu;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_DMNghiepVu(); break;
            case "xoa": Xoa_DMNghiepVu(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_DMNghiepVu()
    {
        try
        {
            DataProcess process = s_DMNghiepVu();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("Id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_DMNghiepVu()
    {
        try
        {
            DataProcess process = s_DMNghiepVu();
            if (process.getData("Id") != null && process.getData("Id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id"));
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
        DataProcess process = s_DMNghiepVu();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.Id),T.*
                               from DMNghiepVu T
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaNghiepVu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenNghiepVu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiChungTu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DienGiai") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TKNo") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TKCo") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TKThue") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("VAT") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        bool quyenthem = StaticData.HavePermision(this.Page, "KeToanDM_KTDM_DanhMucNghiepVu_Them");
        bool quyensua = StaticData.HavePermision(this.Page, "KeToanDM_KTDM_DanhMucNghiepVu_Sua");
        bool quyenxoa = StaticData.HavePermision(this.Page, "KeToanDM_KTDM_DanhMucNghiepVu_Sua");
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
                        html += "<td><input mkv='true' id='MaNghiepVu' type='text' value='" + table.Rows[i]["MaNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id='TenNghiepVu' type='text' value='" + table.Rows[i]["TenNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id='LoaiChungTu' type='text' value='" + table.Rows[i]["LoaiChungTu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id='DienGiai' type='text' value='" + table.Rows[i]["DienGiai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id='TKNo' type='text' value='" + table.Rows[i]["TKNo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id='TKCo' type='text' value='" + table.Rows[i]["TKCo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan2(this);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id='TKThue' type='text' value='" + table.Rows[i]["TKThue"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan3(this);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id='VAT' type='text' value='" + table.Rows[i]["VAT"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                        html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["Id"] + "'/></td>";
                        html += "</tr>";
                    }
                    else
                    {
                        if (quyenthem)
                        {
                            html += "<tr>";
                            html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                            if (quyenxoa)
                                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                            else
                                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                            html += "<td><input mkv='true' id='MaNghiepVu' readonly='true' type='text' value='" + table.Rows[i]["MaNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' id='TenNghiepVu' readonly='true' type='text' value='" + table.Rows[i]["TenNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' id='LoaiChungTu' readonly='true' type='text' value='" + table.Rows[i]["LoaiChungTu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' id='DienGiai' readonly='true' type='text' value='" + table.Rows[i]["DienGiai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' id='TKNo' readonly='true' type='text' value='" + table.Rows[i]["TKNo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' id='TKCo' readonly='true' type='text' value='" + table.Rows[i]["TKCo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan2(this);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' id='TKThue' readonly='true' type='text' value='" + table.Rows[i]["TKThue"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan3(this);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' id='VAT' readonly='true' type='text' value='" + table.Rows[i]["VAT"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                            html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["Id"] + "'/></td>";
                            html += "</tr>";
                        }
                        else
                        {
                            if (quyensua)
                            {
                                html += "<tr>";
                                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                                if (quyenxoa)
                                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                                else
                                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                                html += "<td><input mkv='true' id='MaNghiepVu' type='text' value='" + table.Rows[i]["MaNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='TenNghiepVu' type='text' value='" + table.Rows[i]["TenNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='LoaiChungTu' type='text' value='" + table.Rows[i]["LoaiChungTu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='DienGiai' type='text' value='" + table.Rows[i]["DienGiai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='TKNo' type='text' value='" + table.Rows[i]["TKNo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='TKCo' type='text' value='" + table.Rows[i]["TKCo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan2(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='TKThue' type='text' value='" + table.Rows[i]["TKThue"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan3(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='VAT' type='text' value='" + table.Rows[i]["VAT"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["Id"] + "'/></td>";
                                html += "</tr>";
                            }
                            else
                            {
                                html += "<tr>";
                                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                                if (quyenxoa)
                                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                                else
                                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                                html += "<td><input mkv='true' id='MaNghiepVu' readonly='true' type='text' value='" + table.Rows[i]["MaNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='TenNghiepVu' readonly='true' type='text' value='" + table.Rows[i]["TenNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='LoaiChungTu' readonly='true' type='text' value='" + table.Rows[i]["LoaiChungTu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='DienGiai' readonly='true' type='text' value='" + table.Rows[i]["DienGiai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='TKNo' readonly='true' type='text' value='" + table.Rows[i]["TKNo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='TKCo' readonly='true' type='text' value='" + table.Rows[i]["TKCo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan2(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='TKThue' readonly='true' type='text' value='" + table.Rows[i]["TKThue"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan3(this);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id='VAT' readonly='true' type='text' value='" + table.Rows[i]["VAT"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                                html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["Id"] + "'/></td>";
                                html += "</tr>";
                            }
                        }
                    }
                }
            }
            else
            {
                html += "<tr>";
                html += "<td>1</td>";
                if(quyenxoa)
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                else
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                html += "<td><input mkv='true' id='MaNghiepVu' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TenNghiepVu' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='LoaiChungTu' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='DienGiai' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TKNo'" + table.Rows.Count.ToString() + " type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TKCo'" + table.Rows.Count.ToString() + " type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan2(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TKThue'" + table.Rows.Count.ToString() + " type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan3(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='VAT' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
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



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

public partial class KTTM_DoanhThuKhoa_ajax : System.Web.UI.Page
{
    protected DataProcess s_doanhthu_khoa_kt()
    {
        DataProcess doanhthu_khoa_kt = new DataProcess("doanhthu_khoa_kt");
        doanhthu_khoa_kt.data("doanhthukhoaid", Request.QueryString["idkhoachinh"]);
        doanhthu_khoa_kt.data("sophieu", Request.QueryString["sophieu"]);
        doanhthu_khoa_kt.data("ngaylap", Request.QueryString["ngaylap"]);
        doanhthu_khoa_kt.data("idkhoa", Request.QueryString["idkhoa"]);
        doanhthu_khoa_kt.data("nguoilienhe", Request.QueryString["nguoilienhe"]);
        doanhthu_khoa_kt.data("tkno", Request.QueryString["tkno"]);
        doanhthu_khoa_kt.data("tkco", Request.QueryString["tkco"]);
        doanhthu_khoa_kt.data("tkvat", Request.QueryString["tkvat"]);
        doanhthu_khoa_kt.data("tkck", Request.QueryString["tkck"]);
        doanhthu_khoa_kt.data("vat", Request.QueryString["vat"]);
        doanhthu_khoa_kt.data("doanhthu", Request.QueryString["doanhthu"]);
        doanhthu_khoa_kt.data("tienthue", Request.QueryString["tienthue"]);
        doanhthu_khoa_kt.data("tienchietkhau", Request.QueryString["tienchietkhau"]);
        doanhthu_khoa_kt.data("tongtien", Request.QueryString["tongtien"]);
        doanhthu_khoa_kt.data("diengiai", Request.QueryString["diengiai"]);
        doanhthu_khoa_kt.data("ngaythu1", Request.QueryString["ngaythu1"]);
        doanhthu_khoa_kt.data("ngaythu2", Request.QueryString["ngaythu2"]);
        doanhthu_khoa_kt.data("loaitien", Request.QueryString["loaitien"]);
        doanhthu_khoa_kt.data("doanhthu_nt", Request.QueryString["doanhthu_nt"]);
        doanhthu_khoa_kt.data("tong_tien_nt", Request.QueryString["tong_tien_nt"]);
        doanhthu_khoa_kt.data("user_dau", Request.QueryString["user_dau"]);
        doanhthu_khoa_kt.data("user_cuoi", Request.QueryString["user_cuoi"]);
        doanhthu_khoa_kt.data("date_dau", Request.QueryString["date_dau"]);
        doanhthu_khoa_kt.data("date_cuoi", Request.QueryString["date_cuoi"]);
        doanhthu_khoa_kt.data("ishuy", Request.QueryString["ishuy"]);
        return doanhthu_khoa_kt;
    }
    protected DataProcess s_doanhthu_khoa_kt_ct()
    {
        DataProcess doanhthu_khoa_kt_ct = new DataProcess("doanhthu_khoa_kt_ct");
        doanhthu_khoa_kt_ct.data("doanhthukhoaidct", Request.QueryString["idkhoachinh"]);
        doanhthu_khoa_kt_ct.data("doanhthukhoaid", Request.QueryString["doanhthukhoaid"]);
        doanhthu_khoa_kt_ct.data("sophieu", Request.QueryString["sophieu"]);
        doanhthu_khoa_kt_ct.data("ngaylap", Request.QueryString["ngaylap"]);
        doanhthu_khoa_kt_ct.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        doanhthu_khoa_kt_ct.data("loaithu", Request.QueryString["loaithu"]);
        doanhthu_khoa_kt_ct.data("diengiai", Request.QueryString["diengiai"]);
        doanhthu_khoa_kt_ct.data("doanhthu", Request.QueryString["doanhthu"]);
        doanhthu_khoa_kt_ct.data("tienthue", Request.QueryString["tienthue"]);
        doanhthu_khoa_kt_ct.data("tienck", Request.QueryString["tienck"]);
        doanhthu_khoa_kt_ct.data("tongtien", Request.QueryString["tongtien"]);
        return doanhthu_khoa_kt_ct;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savedoanhthu_khoa_kt(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTabledoanhthu_khoa_kt_ct": LuuTabledoanhthu_khoa_kt_ct(); break;
            case "loadTabledoanhthu_khoa_kt_ct": loadTabledoanhthu_khoa_kt_ct(); break;
            case "xoa": Xoadoanhthu_khoa_kt(); break;
            case "xoadoanhthu_khoa_kt_ct": Xoadoanhthu_khoa_kt_ct(); break;
        }
    }

    private void Xoadoanhthu_khoa_kt()
    {
        try
        {
            DataProcess process = s_doanhthu_khoa_kt();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("doanhthukhoaid"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void Xoadoanhthu_khoa_kt_ct()
    {
        try
        {
            DataProcess process = s_doanhthu_khoa_kt_ct();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("doanhthukhoaidct"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void setTimKiem()
    {
        if (Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = KTDT_Process.doanhthu_khoa_kt.dtSearchBydoanhthukhoaid(idkhoachinh);
            string html = "";
            html += "<root>";
            html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
            html += Environment.NewLine;
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {

                    for (int y = 0; y < table.Columns.Count; y++)
                    {
                        try
                        {
                            html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                        }
                        catch (Exception)
                        {
                            html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                        }
                        html += Environment.NewLine;
                    }
                }
            }
            html += "</root>";
            Response.Clear();
            Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }

    private void TimKiem()
    {
        if (Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_Search"))
        {
            DataProcess process = s_doanhthu_khoa_kt();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.doanhthukhoaid),T.*
                               from doanhthu_khoa_kt T
          where " + process.sWhere());
            string html = "";
            html += "<table class='jtable' id=\"tablefind\">";
            html += "<tr>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("doanhthukhoaid") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sophieu") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaylap") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkhoa") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nguoilienhe") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkno") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkco") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkvat") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkck") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("vat") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("doanhthu") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tienthue") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tienchietkhau") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tongtien") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("diengiai") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythu1") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythu2") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaitien") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("doanhthu_nt") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tong_tien_nt") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("user_dau") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("user_cuoi") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("date_dau") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("date_cuoi") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ishuy") + "</th>";
            html += "</tr>";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr onclick=\"setControlFind('" + table.Rows[i]["doanhthukhoaid"].ToString() + "')\">";
                        html += "<td>" + table.Rows[i]["sophieu"].ToString() + "</td>";
                        if (table.Rows[i]["ngaylap"].ToString() != "")
                        {
                            html += "<td>" + DateTime.Parse(table.Rows[i]["ngaylap"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                        }
                        else { html += "<td>" + table.Rows[i]["ngaylap"].ToString() + "</td>"; }
                        html += "<td>" + table.Rows[i]["idkhoa"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["nguoilienhe"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["tkno"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["tkco"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["tkvat"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["tkck"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["vat"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["doanhthu"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["tienthue"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["tienchietkhau"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["tongtien"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["diengiai"].ToString() + "</td>";
                        if (table.Rows[i]["ngaythu1"].ToString() != "")
                        {
                            html += "<td>" + DateTime.Parse(table.Rows[i]["ngaythu1"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                        }
                        else { html += "<td>" + table.Rows[i]["ngaythu1"].ToString() + "</td>"; }
                        if (table.Rows[i]["ngaythu2"].ToString() != "")
                        {
                            html += "<td>" + DateTime.Parse(table.Rows[i]["ngaythu2"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                        }
                        else { html += "<td>" + table.Rows[i]["ngaythu2"].ToString() + "</td>"; }
                        html += "<td>" + table.Rows[i]["loaitien"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["doanhthu_nt"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["tong_tien_nt"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["user_dau"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["user_cuoi"].ToString() + "</td>";
                        if (table.Rows[i]["date_dau"].ToString() != "")
                        {
                            html += "<td>" + DateTime.Parse(table.Rows[i]["date_dau"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                        }
                        else { html += "<td>" + table.Rows[i]["date_dau"].ToString() + "</td>"; }
                        if (table.Rows[i]["date_cuoi"].ToString() != "")
                        {
                            html += "<td>" + DateTime.Parse(table.Rows[i]["date_cuoi"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                        }
                        else { html += "<td>" + table.Rows[i]["date_cuoi"].ToString() + "</td>"; }
                        html += "<td>" + table.Rows[i]["ishuy"].ToString() + "</td>";
                        html += "</tr>";
                    }
                    html += "</table>";
                    html += process.Paging();
                    Response.Clear(); Response.Write(html);
                    return;
                }
            }
            else
            {
                Response.StatusCode = 500;
            }
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }

    private void Savedoanhthu_khoa_kt()
    {
        try
        {
            DataProcess process = s_doanhthu_khoa_kt();
            if (process.getData("doanhthukhoaid") != null && process.getData("doanhthukhoaid") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("doanhthukhoaid"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("doanhthukhoaid"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTabledoanhthu_khoa_kt_ct()
    {
        try
        {
            DataProcess process = s_doanhthu_khoa_kt_ct();
            if (process.getData("doanhthukhoaidct") != null && process.getData("doanhthukhoaidct") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("doanhthukhoaidct"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("doanhthukhoaidct"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTabledoanhthu_khoa_kt_ct()
    {
        string paging = "";
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sophieu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaylap") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idbenhnhan") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaithu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("diengiai") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("doanhthu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tienthue") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tienck") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tongtien") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        bool add = Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_ct_Add");
        bool search = Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_ct_Search");
        if (search)
        {
            DataProcess process = s_doanhthu_khoa_kt_ct();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.doanhthukhoaidct),T.*
                   ,A.sophieu
                               from doanhthu_khoa_kt_ct T
                    left join doanhthu_khoa_kt  A on T.doanhthukhoaid=A.doanhthukhoaid
          where T.doanhthukhoaid='" + process.getData("doanhthukhoaid") + "'");
            if (table !=null && table.Rows.Count > 0)
            {
                paging = process.Paging("doanhthu_khoa_kt_ct");
                bool delete = Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_ct_Delete");
                bool edit = Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_ct_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                    html += "<td><input mkv='true' id='sophieu' type='text' onfocusout='chuyenformout(this)'  style=\"width:50px\" onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["sophieu"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    if (table.Rows[i]["ngaylap"].ToString() != "")
                    {
                        html += "<td><input mkv='true' id='ngaylap' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + DateTime.Parse(table.Rows[i]["ngaylap"].ToString()).ToString("dd/MM/yyyy") + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + "/></td>";
                    }
                    else { html += "<td><input mkv='true' id='ngaylap' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + table.Rows[i]["ngaylap"].ToString() + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + "/></td>"; }
                    html += "<td><input mkv='true' id='idbenhnhan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idbenhnhan"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='loaithu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithu"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='diengiai' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["diengiai"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='doanhthu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["doanhthu"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='tienthue' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tienthue"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='tienck' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tienck"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='tongtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tongtien"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["doanhthukhoaidct"].ToString() + "'/></td>";
                    html += "</tr>";
                }
            }
        }
        if (add)
        {
            html += "<tr>";
            html += "<td>1</td>";
            html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td><input mkv='true' id='sophieu' type='text' onfocusout='chuyenformout(this)' style=\"width:70px \" onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' id='ngaylap' type='text' onfocusout='chuyenformout(this)'  style=\"width:70px\" onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)'/></td>";
            html += "<td><input mkv='true' id='idbenhnhan' type='text' onfocusout='chuyenformout(this)'  style=\"width:120px\" onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' id='loaithu' type='text' onfocusout='chuyenformout(this)'  style=\"width:70px\" onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' id='diengiai' type='text' onfocusout='chuyenformout(this)'  style=\"width:120px\" onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' id='doanhthu' type='text' onfocusout='chuyenformout(this)'  style=\"width:70px\" onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='tienthue' type='text' onfocusout='chuyenformout(this)'  style=\"width:70px\" onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='tienck' type='text' onfocusout='chuyenformout(this)'  style=\"width:70px\" onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='tongtien' type='text' onfocusout='chuyenformout(this)'  style=\"width:70px \" onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
        html += "</table>";
        if (!search)
            html += "Bạn không có quyền xem.";
        else
            html += paging;
        Response.Clear(); Response.Write(html);
    }
}



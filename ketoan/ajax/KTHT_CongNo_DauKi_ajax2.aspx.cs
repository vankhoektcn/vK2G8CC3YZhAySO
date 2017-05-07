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

public partial class CongNo_DauKi_ajax : System.Web.UI.Page
{
    protected DataProcess s_CongNo_DauKi()
    {
        DataProcess CongNo_DauKi = new DataProcess("CongNo_DauKi");
        CongNo_DauKi.data("CongNo_dk_id", Request.QueryString["idkhoachinh"]);
        CongNo_DauKi.data("nam", Request.QueryString["nam"]);
        CongNo_DauKi.data("tk", Request.QueryString["tk"]);
        CongNo_DauKi.data("ma_dt", Request.QueryString["ma_dt"]);
        CongNo_DauKi.data("loai_dt", Request.QueryString["loai_dt"]);
        CongNo_DauKi.data("so_hd", Request.QueryString["so_hd"]);
        CongNo_DauKi.data("ngay_lap_hd", Request.QueryString["ngay_lap_hd"]);
        CongNo_DauKi.data("dien_giai", Request.QueryString["dien_giai"]);
        CongNo_DauKi.data("loai_tien", Request.QueryString["loai_tien"]);
        CongNo_DauKi.data("du_no0", Request.QueryString["du_no0"]);
        CongNo_DauKi.data("du_co0", Request.QueryString["du_co0"]);
        CongNo_DauKi.data("du_no_nt0", Request.QueryString["du_no_nt0"]);
        CongNo_DauKi.data("du_co_nt0", Request.QueryString["du_co_nt0"]);
        CongNo_DauKi.data("date_dau", Request.QueryString["date_dau"]);
        CongNo_DauKi.data("user_dau", Request.QueryString["user_dau"]);
        CongNo_DauKi.data("date_cuoi", Request.QueryString["date_cuoi"]);
        CongNo_DauKi.data("user_cuoi", Request.QueryString["user_cuoi"]);
        CongNo_DauKi.data("trang_thai", Request.QueryString["trang_thai"]);
        return CongNo_DauKi;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_CongNo_DauKi(); break;
            case "xoa": Xoa_CongNo_DauKi(); break;
            case "TimKiem": TimKiem(); break;
            case "doituongsearch": doituongsearch(); break;                
        }
    }
    private void doituongsearch()
    {
        string loaidt = "";
        string key = "";
        string sql = "";
        if (!string.IsNullOrEmpty(Request.QueryString["loaidt"]))
            loaidt = Request.QueryString["loaidt"];
        key = Request.QueryString["q"];
        if (loaidt == "kh")
            sql = "select idkhachhang,makhachhang,tenkhachhang from khachhang where tenkhachhang like N'%" + key + "%'";
        if (loaidt == "ncc")
            sql = "select nhacungcapid,manhacungcap,tennhacungcap from nhacungcap where tennhacungcap like N'%" + key + "%'";
         
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString()  + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
     

    private void Xoa_CongNo_DauKi()
    {
        try
        {
            DataProcess process = s_CongNo_DauKi();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("CongNo_dk_id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_CongNo_DauKi()
    {
        try
        {
            //Process_KTHT process = s_CongNo_DauKi();
            string loaidt = "";
            if (!string.IsNullOrEmpty(Request.QueryString["loai_dt"]))
                loaidt = Request.QueryString["loai_dt"];
            DataProcess process = s_CongNo_DauKi();
            if (process.getData("CongNo_dk_id") != null && process.getData("CongNo_dk_id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("CongNo_dk_id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("CongNo_dk_id"));
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
        string paging = "";
        string html = "";
        bool add = StaticData.HavePermision(this, "CongNo_DauKi_Add");
        bool search = StaticData.HavePermision(this, "CongNo_DauKi_Search");
        if (search)
        {
            DataProcess process = s_CongNo_DauKi();
            process.Page = Request.QueryString["page"];
            process.NumberRow = "50";
            DataTable table = process.Search(@"select STT=row_number() over (order by T.CongNo_dk_id),T.*
                               from CongNo_DauKi T
             where " + process.sWhere());
            paging = process.Paging();
            html += paging;
            html += "<table class='jtable' id=\"gridTable\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th></th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nam") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("taikhoan") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ma dt") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Loai dt") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("So HD") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngay lap hd") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Dien giai") + "</th>";
            //html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loai_tien") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Du no dk") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Du co dk") + "</th>";
            //html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("du_no_nt0") + "</th>";
            //html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("du_co_nt0") + "</th>";
            html += "<th></th>";
            html += "</tr>";
            if (table.Rows.Count > 0)
            {
                bool delete = StaticData.HavePermision(this, "CongNo_DauKi_Delete");
                bool edit = StaticData.HavePermision(this, "CongNo_DauKi_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td> <a id=\"xoaRow\" style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + delete.ToString().ToLower() + ");\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    html += "<td><input mkv='true' id='nam' type='text' value='" + table.Rows[i]["nam"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='tk' type='text' value='" + table.Rows[i]["tk"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='taikhoansearch1(this.id);chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ma_dt' type='text' value='" + table.Rows[i]["ma_dt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='loai_dt' type='text' value='" + table.Rows[i]["loai_dt"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='so_hd' type='text' value='" + table.Rows[i]["so_hd"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    if (table.Rows[i]["ngay_lap_hd"].ToString() != "")
                    {
                        html += "<td><input mkv='true' id='ngay_lap_hd' type='text' value='" + DateTime.Parse(table.Rows[i]["ngay_lap_hd"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    }
                    else
                    {
                        html += "<td><input mkv='true' id='ngay_lap_hd' type='text' value='" + table.Rows[i]["ngay_lap_hd"] + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    }
                    html += "<td><input mkv='true' id='dien_giai' type='text' value='" + table.Rows[i]["dien_giai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    //html += "<td><input mkv='true' id='loai_tien' type='text' value='" + table.Rows[i]["loai_tien"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='du_no0' type='text' value='" + table.Rows[i]["du_no0"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='du_co0' type='text' value='" + table.Rows[i]["du_co0"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    //html += "<td><input mkv='true' id='du_no_nt0' type='text' value='" + table.Rows[i]["du_no_nt0"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    //html += "<td><input mkv='true' id='du_co_nt0' type='text' value='" + table.Rows[i]["du_co_nt0"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["CongNo_dk_id"] + "'/></td>";
                    html += "</tr>";
                }
            }
        }
        if (add)
        {
            html += "<tr>";
            html += "<td>1</td>";
            html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
            html += "<td><input mkv='true' id='nam' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='tk' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);taikhoansearch1(this.id);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='ma_dt' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='loai_dt' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='so_hd' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='ngay_lap_hd' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='dien_giai' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            //html += "<td><input mkv='true' id='loai_tien' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='du_no0' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='du_co0' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            //html += "<td><input mkv='true' id='du_no_nt0' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            //html += "<td><input mkv='true' id='du_co_nt0' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
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



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

public partial class DanhMucTaiSan_ajax : System.Web.UI.Page
{
    protected DataProcess s_DanhMucTaiSan()
    {
        DataProcess DanhMucTaiSan = new DataProcess("DanhMucTaiSan");
        DanhMucTaiSan.data("danh_muc_ts_id", Request.QueryString["idkhoachinh"]);
        DanhMucTaiSan.data("phieu_nhap_ct_id", Request.QueryString["phieu_nhap_ct_id"]);
        DanhMucTaiSan.data("phieu_xuat_ct_id", Request.QueryString["phieu_xuat_ct_id"]);
        DanhMucTaiSan.data("MaTS", Request.QueryString["MaTS"]);
        DanhMucTaiSan.data("TenTaiSan", Request.QueryString["TenTaiSan"]);
        DanhMucTaiSan.data("HangSX", Request.QueryString["HangSX"]);
        DanhMucTaiSan.data("NamSX", Request.QueryString["NamSX"]);
        DanhMucTaiSan.data("NguyenGia", Request.QueryString["NguyenGia"]);
        DanhMucTaiSan.data("KhauHaoLK", Request.QueryString["KhauHaoLK"]);
        DanhMucTaiSan.data("NgayNhap", Request.QueryString["NgayNhap"]);
        DanhMucTaiSan.data("NgayKhauHao", Request.QueryString["NgayKhauHao"]);
        DanhMucTaiSan.data("SoNamKH", Request.QueryString["SoNamKH"]);
        DanhMucTaiSan.data("TKNguyenGia", Request.QueryString["TKNguyenGia"]);
        DanhMucTaiSan.data("TKKhauHao", Request.QueryString["TKKhauHao"]);
        DanhMucTaiSan.data("TKDoiUng", Request.QueryString["TKDoiUng"]);
        DanhMucTaiSan.data("TKChiPhi", Request.QueryString["TKChiPhi"]);
        DanhMucTaiSan.data("TKChiPhiKhac", Request.QueryString["TKChiPhiKhac"]);
        DanhMucTaiSan.data("SoHoaDonNhap", Request.QueryString["SoHoaDonNhap"]);
        DanhMucTaiSan.data("NgayLapHoaDon", Request.QueryString["NgayLapHoaDon"]);
        DanhMucTaiSan.data("GiaTriConLai", Request.QueryString["GiaTriConLai"]);
        DanhMucTaiSan.data("idkho", Request.QueryString["idkho"]);
        DanhMucTaiSan.data("soluong_hienco", Request.QueryString["soluong_hienco"]);
        DanhMucTaiSan.data("isTSCD", Request.QueryString["isTSCD"]);
        DanhMucTaiSan.data("isCCDC", Request.QueryString["isCCDC"]);
        return DanhMucTaiSan;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_DanhMucTaiSan(); break;
            case "xoa": Xoa_DanhMucTaiSan(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoa_DanhMucTaiSan()
    {
        try
        {
            DataProcess process = s_DanhMucTaiSan();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("danh_muc_ts_id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_DanhMucTaiSan()
    {
        try
        {
            DataProcess process = s_DanhMucTaiSan();
            if (process.getData("danh_muc_ts_id") != null && process.getData("danh_muc_ts_id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("danh_muc_ts_id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("danh_muc_ts_id"));
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
        bool add = Profess.Userlogin.HavePermision(this, "DanhMucTaiSan_Add");
        bool search = Profess.Userlogin.HavePermision(this, "DanhMucTaiSan_Search");
        if (search)
        {
            DataProcess process = s_DanhMucTaiSan();
            process.Page = Request.QueryString["page"];
            process.NumberRow = "50";
            DataTable table = process.Search(@"select STT=row_number() over (order by T.danh_muc_ts_id),T.*
                               from DanhMucTaiSan T
          where " + process.sWhere());
            paging = process.Paging();
            html += paging;
            html += "<table class='jtable' id=\"gridTable\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th></th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaTS") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenTaiSan") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NguyenGia") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("KhauHaoLK") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayNhap") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayKhauHao") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoNamKH") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TKNguyenGia") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TKKhauHao") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoHoaDonNhap") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayLapHoaDon") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GiaTriConLai") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong_hienco") + "</th>";
            html += "<th></th>";
            html += "</tr>";
            if (table.Rows.Count > 0)
            {
                bool delete = Profess.Userlogin.HavePermision(this, "DanhMucTaiSan_Delete");
                bool edit = Profess.Userlogin.HavePermision(this, "DanhMucTaiSan_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td> <a id=\"xoaRow\" style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoa(this," + delete.ToString().ToLower() + ");\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    html += "<td><input mkv='true' id='MaTS' type='text' value='" + table.Rows[i]["MaTS"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='TenTaiSan' type='text' value='" + table.Rows[i]["TenTaiSan"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='NguyenGia' type='text' value='" + table.Rows[i]["NguyenGia"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='KhauHaoLK' type='text' value='" + table.Rows[i]["KhauHaoLK"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    if (table.Rows[i]["NgayNhap"].ToString() != "")
                    {
                        html += "<td><input mkv='true' id='NgayNhap' type='text' value='" + DateTime.Parse(table.Rows[i]["NgayNhap"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    }
                    else
                    {
                        html += "<td><input mkv='true' id='NgayNhap' type='text' value='" + table.Rows[i]["NgayNhap"] + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    }
                    if (table.Rows[i]["NgayKhauHao"].ToString() != "")
                    {
                        html += "<td><input mkv='true' id='NgayKhauHao' type='text' value='" + DateTime.Parse(table.Rows[i]["NgayKhauHao"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    }
                    else
                    {
                        html += "<td><input mkv='true' id='NgayKhauHao' type='text' value='" + table.Rows[i]["NgayKhauHao"] + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    }
                    html += "<td><input mkv='true' id='SoNamKH' type='text' value='" + table.Rows[i]["SoNamKH"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='TKNguyenGia' type='text' value='" + table.Rows[i]["TKNguyenGia"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='TKKhauHao' type='text' value='" + table.Rows[i]["TKKhauHao"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='SoHoaDonNhap' type='text' value='" + table.Rows[i]["SoHoaDonNhap"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    if (table.Rows[i]["NgayLapHoaDon"].ToString() != "")
                    {
                        html += "<td><input mkv='true' id='NgayLapHoaDon' type='text' value='" + DateTime.Parse(table.Rows[i]["NgayLapHoaDon"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    }
                    else
                    {
                        html += "<td><input mkv='true' id='NgayLapHoaDon' type='text' value='" + table.Rows[i]["NgayLapHoaDon"] + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    }
                    html += "<td><input mkv='true' id='GiaTriConLai' type='text' value='" + table.Rows[i]["GiaTriConLai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idkho' type='text' value='" + table.Rows[i]["idkho"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='soluong_hienco' type='text' value='" + table.Rows[i]["soluong_hienco"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["danh_muc_ts_id"] + "'/></td>";
                    html += "</tr>";
                }
            }
        }
        if (add)
        {
            html += "<tr>";
            html += "<td>1</td>";
            html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
            html += "<td><input mkv='true' id='MaTS' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='TenTaiSan' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='NguyenGia' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='KhauHaoLK' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='NgayNhap' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='NgayKhauHao' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='SoNamKH' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='TKNguyenGia' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='TKKhauHao' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='SoHoaDonNhap' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='NgayLapHoaDon' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='GiaTriConLai' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='idkho' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
            html += "<td><input mkv='true' id='soluong_hienco' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
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



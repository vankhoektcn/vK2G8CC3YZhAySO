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

public partial class ketoan_ajax_KTTSCD_DanhMucCCDC_ajax : System.Web.UI.Page
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
        if (Request.QueryString["do"].ToString() == "TimKiem")
        {
            if (Request.QueryString["NgayNhap"] != "" && Request.QueryString["NgayNhap"] != null)
                DanhMucTaiSan.data("NgayNhap", Request.QueryString["NgayNhap"]);
            else
                DanhMucTaiSan.data("NgayNhap", Request.QueryString["NgayNhap"]);
        }
        else
            DanhMucTaiSan.data("NgayNhap", Request.QueryString["NgayNhap"]);
        if (Request.QueryString["do"].ToString() == "TimKiem")
        {
            if (Request.QueryString["NgayKhauHao"] != "" && Request.QueryString["NgayKhauHao"] != null)
                DanhMucTaiSan.data("NgayKhauHao", Request.QueryString["NgayKhauHao"]);
            else
                DanhMucTaiSan.data("NgayKhauHao", Request.QueryString["NgayKhauHao"]);
        }
        else
            DanhMucTaiSan.data("NgayKhauHao", Request.QueryString["NgayKhauHao"]);

        //DanhMucTaiSan.data("NgayKhauHao",Request.QueryString["NgayKhauHao"]);
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
            case "DanhSachTaiKhoan_Jquery": DanhSachTaiKhoan_Jquery(); break;
            case "luuTable": LuuTable_DanhMucTaiSan(); break;
            case "xoa": Xoa_DanhMucTaiSan(); break;
            case "TimKiem": TimKiem(); break;
            case "khoSearch": khoSearch(); break;
        }
    }
    private void khoSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select idkho,tenkho from khothuoc");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    #region Load danh sach tai khoan
    public void DanhSachTaiKhoan_Jquery()
    {
        string key = Request.QueryString["q"];
        string idText = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        //html += "|<div style =\"background-color: #4D67A2;height:20px\">";
        html += "|<div style=\"width: 350px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tài khoản</div>";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên tài khoản</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Chi tiết</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Tài khoản cấp cha</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Cấp</div>";
        html += "</div>|";

        html += Environment.NewLine;
        try
        {

            sql = "select TaiKhoan,TenTaiKhoan,ChiTiet,TKCapCha,Cap from DanhMucTK ";

            if (!string.IsNullOrEmpty(key))
                sql += "  where TaiKhoan  LIKE '" + key + "%' or TKCapCha   LIKE '" + key + "%'";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoan('" + dt.Rows[i]["TaiKhoan"] + "','" + idText + "')\">";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TaiKhoan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenTaiKhoan"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ChiTiet"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TKCapCha"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["Cap"] + "</p>";
                html += "</div>|" + dt.Rows[i]["TaiKhoan"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    #endregion
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
        DataProcess process = s_DanhMucTaiSan();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.danh_muc_ts_id),T.*,kt.tenkho
                               from DanhMucTaiSan T
                                left join khothuoc kt on T.idkho=kt.idkho
          where " + process.sWhere() + " and isCCDC='True' and isnull(mats,'') != ''");
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã CCDC") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên CCDC") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nguyên Giá") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Khấu Hao LK") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Nhập") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Khấu Hao") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK_NguyenGia") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK_KhauHao") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK_ChiPhi") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Giá Trị Còn Lại") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Kho") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số Lượng Hiện Có") + "</th>";
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
                    if (StaticData.HavePermision(this.Page, "KeToanCCDC_KTCCDC_DanhMucCCDC_Xoa"))
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    else
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"\"></td>";

                    html += "<td><input mkv='true' id='MaTS' readonly='readonly' type='text' value='" + table.Rows[i]["MaTS"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='TenTaiSan' readonly='readonly' type='text' value='" + table.Rows[i]["TenTaiSan"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100px'/></td>";
                    html += "<td><input mkv='true' id='NguyenGia' type='text' value='" + table.Rows[i]["NguyenGia"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='KhauHaoLK' type='text' value='" + table.Rows[i]["KhauHaoLK"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                    if (table.Rows[i]["NgayNhap"].ToString() != "")
                    {
                        html += "<td><input mkv='true' id='NgayNhap' type='text' value='" + DateTime.Parse(table.Rows[i]["NgayNhap"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:90px'/></td>";
                    }
                    else
                    {
                        html += "<td><input mkv='true' id='NgayNhap' type='text' value='" + table.Rows[i]["NgayNhap"] + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:90px'/></td>";
                    }
                    if (table.Rows[i]["NgayKhauHao"].ToString() != "")
                    {
                        html += "<td><input mkv='true' id='NgayKhauHao' type='text' value='" + DateTime.Parse(table.Rows[i]["NgayKhauHao"].ToString()).ToString("dd/MM/yyyy") + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:90px'/></td>";
                    }
                    else
                    {
                        html += "<td><input mkv='true' id='NgayKhauHao' type='text' value='" + table.Rows[i]["NgayKhauHao"] + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:90px'/></td>";
                    }
                    html += "<td><input mkv='true' id='TKNguyenGia' type='text' value='" + table.Rows[i]["TKNguyenGia"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='TKKhauHao' type='text' value='" + table.Rows[i]["TKKhauHao"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='TKChiPhi' type='text' value='" + table.Rows[i]["TKChiPhi"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='GiaTriConLai' type='text' value='" + table.Rows[i]["GiaTriConLai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:50px'/></td>";
                    html += "<td><input mkv='true' id='idkho' type='hidden' value='" + table.Rows[i]["idkho"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100px'/>";
                    html += "<input mkv='true' id='mkv_idkho' type='text' value='" + table.Rows[i]["tenkho"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);khoSearch(this);' onblur='' style='width:100px'/></td>";
                    html += "<td><input mkv='true' id='soluong_hienco' type='text' value='" + table.Rows[i]["soluong_hienco"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["danh_muc_ts_id"] + "'/></td>";
                    html += "</tr>";
                }
            }
            else
            {
                /*html += "<tr>";
                html += "<td>1</td>";
                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                html += "<td><input mkv='true' id='MaTS' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TenTaiSan' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='NguyenGia' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='KhauHaoLK' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='NgayNhap' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='NgayKhauHao' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TKNguyenGia' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TKKhauHao' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TKChiPhi' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='GiaTriConLai' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='idkho' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='soluong_hienco' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                html += "</tr>";
                 */ 
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }
}

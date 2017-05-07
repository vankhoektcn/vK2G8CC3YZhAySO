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
using System.Text;

public partial class THUOC_YEUCAUTRAHONGVO_ajax : System.Web.UI.Page
{
    protected DataProcess s_THUOC_YEUCAUTRAHONGVO()
    {
        DataProcess THUOC_YEUCAUTRAHONGVO = new DataProcess("THUOC_YEUCAUTRAHONGVO");
        THUOC_YEUCAUTRAHONGVO.data("IdPhieuYeuCauTraHongVo", Request.QueryString["idkhoachinh"]);
        THUOC_YEUCAUTRAHONGVO.data("NgayYeuCau", Request.QueryString["NgayYeuCau"]);
        THUOC_YEUCAUTRAHONGVO.data("SoYeuCau", Request.QueryString["SoYeuCau"]);
        THUOC_YEUCAUTRAHONGVO.data("IdKhoYeuCau", Request.QueryString["IdKhoYeuCau"]);
        THUOC_YEUCAUTRAHONGVO.data("IdKhoNhanTra", Request.QueryString["IdKhoNhanTra"]);
        THUOC_YEUCAUTRAHONGVO.data("IdNguoiYeuCau", Request.QueryString["IdNguoiYeuCau"]);
        return THUOC_YEUCAUTRAHONGVO;
    }
    protected DataProcess s_THUOC_YEUCAUTRAHONGVO_CHITIET()
    {
        DataProcess THUOC_YEUCAUTRAHONGVO_CHITIET = new DataProcess("THUOC_YEUCAUTRAHONGVO_CHITIET");
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("IdChitietYeuCauTraHongVo", Request.QueryString["idkhoachinh"]);
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("IdYeuCauTraHongVo", Request.QueryString["IdYeuCauTraHongVo"]);
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("LoaiThuocId", Request.QueryString["LoaiThuocId"]);
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("IdThuoc", Request.QueryString["IdThuoc"]);
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("IdDVT", Request.QueryString["IdDVT"]);
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("LoSanXuat", Request.QueryString["LoSanXuat"]);
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("NgayHetHan", Request.QueryString["NgayHetHan"]);
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("SoLuong", Request.QueryString["SoLuong"]);
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("GhiChu", Request.QueryString["GhiChu"]);
        THUOC_YEUCAUTRAHONGVO_CHITIET.data("SLTON", Request.QueryString["SLTON"]);
        return THUOC_YEUCAUTRAHONGVO_CHITIET;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveTHUOC_YEUCAUTRAHONGVO(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableTHUOC_YEUCAUTRAHONGVO_CHITIET": LuuTableTHUOC_YEUCAUTRAHONGVO_CHITIET(); break;
            case "loadTableTHUOC_YEUCAUTRAHONGVO_CHITIET": loadTableTHUOC_YEUCAUTRAHONGVO_CHITIET(); break;
            case "xoa": XoaTHUOC_YEUCAUTRAHONGVO(); break;
            case "xoaTHUOC_YEUCAUTRAHONGVO_CHITIET": XoaTHUOC_YEUCAUTRAHONGVO_CHITIET(); break;
            case "IdKhoYeuCauSearch": IdKhoYeuCauSearch(); break;
            case "IdKhoNhanTraSearch": IdKhoNhanTraSearch(); break;
            case "IdNguoiYeuCauSearch": IdNguoiYeuCauSearch(); break;
            case "LoaiThuocIdSearch": LoaiThuocIdSearch(); break;
            case "IdThuocSearch": IdThuocSearch(); break;
            case "IdDVTSearch": IdDVTSearch(); break;
            case "PrintBienBan": PrintBienBan(); break;
            case "DuyetYeuCauTra": DuyetYeuCauTra(); break;
            case "TaoSoPhieuYC": TaoSoPhieuYC(); break;

        }
    }
    private void TaoSoPhieuYC()
    {
        string idkho = Request.QueryString["idkhoyeucau"];
        string idkhoa = Request.QueryString["idkhoa"];
        string ngaythang = Request.QueryString["ngaythang"];
        string sophieuyc = StaticData_HS.TaoSoPhieuYCXHV(idkhoa, StaticData.CheckDate(ngaythang + " 23:59:59"), idkho);
        Response.Clear();
        Response.Write(sophieuyc);
    }
    private void IdKhoYeuCauSearch()
    {
        string sqlSelect = @"select * from khothuoc";
        if (Request.QueryString["idkhoa"] != null && Request.QueryString["idkhoa"] != "")
        {
            sqlSelect += " where idkhoa='" + Request.QueryString["IdKhoa"] + "'";
        }
        DataTable table = DataProcess.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenkho"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdKhoNhanTraSearch()
    {
        DataTable table = DataProcess.GetTable("select * from khothuoc where idkho=51");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenkho"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdNguoiYeuCauSearch()
    {
        DataTable table = DataProcess.GetTable("select * from nguoidung ");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tennguoidung"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void LoaiThuocIdSearch()
    {
        DataTable table = DataProcess.GetTable("select * from Thuoc_LoaiThuoc");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenLoai"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdThuocSearch()
    {
        StaticData.getthuoc(this, false);
    }
    private void IdDVTSearch()
    {
        DataTable table = DataProcess.GetTable("select * from Thuoc_DonViTinh");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenDVT"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaTHUOC_YEUCAUTRAHONGVO()
    {
        try
        {
            DataProcess process = s_THUOC_YEUCAUTRAHONGVO();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdPhieuYeuCauTraHongVo"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void XoaTHUOC_YEUCAUTRAHONGVO_CHITIET()
    {
        try
        {
            DataProcess process = s_THUOC_YEUCAUTRAHONGVO_CHITIET();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdChitietYeuCauTraHongVo"));
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
        if (StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 T.*
                   ,mkv_IdKhoYeuCau = A.tenkho
                   ,mkv_IdKhoNhanTra = B.tenkho
                   ,mkv_IdNguoiYeuCau = C.tennguoidung
                               from THUOC_YEUCAUTRAHONGVO T
                    left join khothuoc  A on T.IdKhoYeuCau=A.idkho
                    left join khothuoc  B on T.IdKhoNhanTra=B.idkho
                    left join nguoidung  C on T.IdNguoiYeuCau=C.idnguoidung
                where T.IdPhieuYeuCauTraHongVo ='" + idkhoachinh + "'");
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {

                    for (int y = 0; y < table.Columns.Count; y++)
                    {
                        html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + DataProcess.sGetDate(table.Rows[0][y].ToString(), false, true) + "</data>");
                    }
                }
            }
            html.AppendLine("</root>");
            Response.Clear();
            Response.Write(html.ToString().Replace("&", "&amp;"));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Search"))
        {
            DataProcess process = s_THUOC_YEUCAUTRAHONGVO();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdPhieuYeuCauTraHongVo),T.*
                   ,khoyeucau=A.tenkho
                   ,khonhan=B.tenkho
                   ,C.username
                               from THUOC_YEUCAUTRAHONGVO T
                    left join khothuoc  A on T.IdKhoYeuCau=A.idkho
                    left join khothuoc  B on T.IdKhoNhanTra=B.idkho
                    left join nguoidung  C on T.IdNguoiYeuCau=C.idnguoidung
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayYeuCau") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoYeuCau") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoYeuCau") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoNhanTra") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdNguoiYeuCau") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["IdPhieuYeuCauTraHongVo"].ToString() + "')\">");
                        html.Append("<td>" + DataProcess.sGetDate(table.Rows[i]["NgayYeuCau"].ToString(), false, true) + "</td>");
                        html.Append("<td>" + table.Rows[i]["SoYeuCau"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["khoyeucau"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["khonhan"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["username"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                }
                html.Append("</table>");
                html.Append(process.Paging());
                Response.Clear(); Response.Write(html);
                return;
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
    private void SaveTHUOC_YEUCAUTRAHONGVO()
    {
        try
        {
            DataProcess process = s_THUOC_YEUCAUTRAHONGVO();
            string NgayThang = process.getData("ngayyeucau");
            string sophieuyc = process.getData("soyeucau");
            string idkhoyeucau = process.getData("IdKhoYeuCau");
            if (sophieuyc == null || sophieuyc == "")
            {
                sophieuyc = StaticData_HS.TaoSoPhieuYCXHV(process.getData("idkho"), StaticData.CheckDate(NgayThang + " 23:59:59"), idkhoyeucau);
                {
                    process.data("soyeucau", sophieuyc);
                }
            }
            if (process.getData("IdPhieuYeuCauTraHongVo") != null && process.getData("IdPhieuYeuCauTraHongVo") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdPhieuYeuCauTraHongVo"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdPhieuYeuCauTraHongVo"));
                    return;
                }
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }
    }
    public void LuuTableTHUOC_YEUCAUTRAHONGVO_CHITIET()
    {
        try
        {
            DataProcess process = s_THUOC_YEUCAUTRAHONGVO_CHITIET();
            if (process.getData("IdChitietYeuCauTraHongVo") != null && process.getData("IdChitietYeuCauTraHongVo") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdChitietYeuCauTraHongVo"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdChitietYeuCauTraHongVo"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableTHUOC_YEUCAUTRAHONGVO_CHITIET()
    {
        string NgayDuyetYeuCau = Request.QueryString["ngayduyetyc"];
        if (NgayDuyetYeuCau != null && NgayDuyetYeuCau != "")
        {
            NgayDuyetYeuCau = StaticData.CheckDate(NgayDuyetYeuCau + ":00") + " " + NgayDuyetYeuCau.Substring(NgayDuyetYeuCau.Length - 5) + ":00";
        }
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocId") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdDVT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoLuong") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SLTON") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_CHITIET_Add");
        bool search = StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_CHITIET_Search");
        if (search)
        {
            DataProcess process = s_THUOC_YEUCAUTRAHONGVO_CHITIET();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdChitietYeuCauTraHongVo),T.*
                   ,A.NgayYeuCau
                   ,B.TenLoai
                   ,C.tenthuoc
                   ,D.TenDVT
                   ,SLTON1=(CASE WHEN A.ISDADUYET=1 THEN T.SLTON ELSE DBO.[Thuoc_TonKho_new_1910](t.IDTHUOC,'" + NgayDuyetYeuCau + @"',a.IdKhoYeuCau) end)
                               from THUOC_YEUCAUTRAHONGVO_CHITIET T
                    left join THUOC_YEUCAUTRAHONGVO  A on T.IdYeuCauTraHongVo=A.IdPhieuYeuCauTraHongVo
                    left join thuoc  C on T.IdThuoc=C.idthuoc
                    left join Thuoc_LoaiThuoc  B on c.LoaiThuocId=B.LoaiThuocID
                    left join Thuoc_DonViTinh  D on c.IdDVT=D.Id
                 where T.IdYeuCauTraHongVo='" + process.getData("IdYeuCauTraHongVo") + "'");
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("THUOC_YEUCAUTRAHONGVO_CHITIET");
                bool delete = StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_CHITIET_Delete");
                bool edit = StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_CHITIET_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='LoaiThuocId' type='hidden' value='" + table.Rows[i]["LoaiThuocId"] + "'/><input mkv='true' id='mkv_LoaiThuocId' type='text' value='" + table.Rows[i]["TenLoai"].ToString() + "' onfocus='LoaiThuocIdSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value='" + table.Rows[i]["IdThuoc"] + "'/><input mkv='true' id='mkv_IdThuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='IdThuocSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='IdDVT' type='hidden' value='" + table.Rows[i]["IdDVT"] + "'/><input mkv='true' id='mkv_IdDVT' type='text' value='" + table.Rows[i]["TenDVT"].ToString() + "' onfocus='IdDVTSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='SoLuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoLuong"].ToString() + "' onblur='TestSo(this,false,false);checkSLNhap(this);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='GhiChu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["GhiChu"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='SLTON' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SLTON1"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["IdChitietYeuCauTraHongVo"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='LoaiThuocId' type='hidden' value=''/><input mkv='true' id='mkv_LoaiThuocId' type='text' value='' onfocus='LoaiThuocIdSearch(this);' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value=''/><input mkv='true' id='mkv_IdThuoc' type='text' value='' onfocus='IdThuocSearch(this);' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='IdDVT' type='hidden' value=''/><input mkv='true' id='mkv_IdDVT' type='text' value='' onfocus='IdDVTSearch(this);' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='SoLuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);checkSLNhap(this);' /></td>");
            html.Append("<td><input mkv='true' id='GhiChu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
            html.Append("<td><input mkv='true' id='SLTON' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
    profess_Rpt_PhieuYCHongVo NXTReport = null;
    private void PrintBienBan()
    {
        string idphieuxuat = Request.QueryString["idphieuxuat"];
        NXTReport = new profess_Rpt_PhieuYCHongVo();
        NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        NXTReport.idphieuxuat = idphieuxuat;
        NXTReport.ExportToExcel();
    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
    private void DuyetYeuCauTra()
    {
        string IdPhieuYeuCauTraHongVo = Request.QueryString["IdPhieuYeuCauTraHongVo"];
        string NgayDuyetYeuCau = Request.QueryString["ngayduyetyc"];
        string SoYeuCau = Request.QueryString["SoYeuCau"];
        string IdKhoYeuCau = Request.QueryString["IdKhoYeuCau"];
        string IdKhoNhanTra = Request.QueryString["IdKhoNhanTra"];
        DataProcess s_phieuxuatkho = new DataProcess("PHIEUXUATKHO");
        string maphieuxuat = s_phieuxuatkho.getData("maphieuxuat");
        if (maphieuxuat == null || maphieuxuat == "")
        {
            string temp = null;
            maphieuxuat = myInsertPhieuXuatKho.TaoSoPhieuXuat(StaticData.CheckDate(NgayDuyetYeuCau + ":00"), ref temp);
            s_phieuxuatkho.data("maphieuxuat", maphieuxuat);
            s_phieuxuatkho.data("SLPX", temp);
        }
        s_phieuxuatkho.data("ngaythang", NgayDuyetYeuCau);
        s_phieuxuatkho.data("idkho", IdKhoYeuCau);
        s_phieuxuatkho.data("idkho2", IdKhoNhanTra);
        s_phieuxuatkho.data("loaixuat", "4");
        s_phieuxuatkho.data("sophieuyc", SoYeuCau);
        s_phieuxuatkho.data("ishongvo", "1");
        if (IdPhieuYeuCauTraHongVo == null || IdPhieuYeuCauTraHongVo == "") return;
        string idphieuxuat = null;
        string ngaythang = null;
        string idkho_xuat = null;
        bool ok = s_phieuxuatkho.Insert();
        if (ok)
        {
            idphieuxuat = s_phieuxuatkho.getData("idphieuxuat");
            ngaythang = s_phieuxuatkho.getData("ngaythang");
            idkho_xuat = IdKhoYeuCau;
        }
        string SQL_SELECT = string.Format(@"SELECT IdChitietYeuCauTraHongVo,IdThuoc,SoLuong
                                            FROM THUOC_YEUCAUTRAHONGVO_CHITIET WHERE IdYeuCauTraHongVo='" + IdPhieuYeuCauTraHongVo + @"'");
        DataTable table = DataAcess.Connect.GetTable(SQL_SELECT);
        if (table == null || table.Rows.Count == 0) return;
        bool check = false;
        for (int i = 0; i < table.Rows.Count; i++)
        {

            string IdChitietYeuCauTraHongVo = table.Rows[i]["IdChitietYeuCauTraHongVo"].ToString();
            string idthuoc = table.Rows[i]["idthuoc"].ToString();
            string SoLuong = table.Rows[i]["SoLuong"].ToString();
            string sqlInsertChiTietPX = @"	EXEC dbo.[Thuoc_XuatThuoc_Automatic_2209] " + idthuoc
                                                                 + ",'" + StaticData.CheckDate(NgayDuyetYeuCau + ":00") + " " + NgayDuyetYeuCau.Substring(NgayDuyetYeuCau.Length - 5) + ":00" + "'"
                                                                 + "," + SoLuong
                                                                 + "," + idkho_xuat
                                                                 + "," + idphieuxuat
                                                                 + ",NULL"
                                                                 + "," + IdChitietYeuCauTraHongVo
                                                                 + ",NULL"
                                                                 + ",NULL";
            bool ok_InsertChiTietPhieuXuatKho = DataAcess.Connect.ExecSQL(sqlInsertChiTietPX);
            if (!ok_InsertChiTietPhieuXuatKho)
            {
                check = false;
                s_phieuxuatkho.Delete();
                Response.Write(check.ToString().ToLower());
                return;
            }
            else check = true;
        }
        if (check)
        {
            DataAcess.Connect.ExecSQL("UPDATE THUOC_YEUCAUTRAHONGVO SET ISDADUYET=1 WHERE IdPhieuYeuCauTraHongVo='" + IdPhieuYeuCauTraHongVo + "'");
            Response.Write(check.ToString().ToLower());
            return;
        }

    }
}



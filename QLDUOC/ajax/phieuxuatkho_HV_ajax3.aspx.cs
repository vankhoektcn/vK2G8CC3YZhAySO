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

public partial class phieuxuatkho_HV_ajax3 : System.Web.UI.Page
{
    protected DataProcess s_phieuxuatkho()
    {
        DataProcess phieuxuatkho = new DataProcess("phieuxuatkho");
        phieuxuatkho.data("idphieuxuat", Request.QueryString["idkhoachinh"]);
        phieuxuatkho.data("maphieuxuat", Request.QueryString["maphieuxuat"]);
        phieuxuatkho.data("ngaythang", Request.QueryString["ngaythang"]);
        phieuxuatkho.data("ghichu", Request.QueryString["ghichu"]);
        phieuxuatkho.data("idphongkhambenh", Request.QueryString["idphongkhambenh"]);
        phieuxuatkho.data("nguoinhan", Request.QueryString["nguoinhan"]);
        phieuxuatkho.data("xuatcho", Request.QueryString["xuatcho"]);
        phieuxuatkho.data("idkho", Request.QueryString["idkho"]);
        phieuxuatkho.data("loaixuat", "6");
        phieuxuatkho.data("IDKhachHang", Request.QueryString["IDKhachHang"]);
        phieuxuatkho.data("vat", Request.QueryString["vat"]);
        phieuxuatkho.data("thanhtien", Request.QueryString["thanhtien"]);
        phieuxuatkho.data("ngayhoadon", Request.QueryString["ngayhoadon"]);
        phieuxuatkho.data("idnhacungcap", Request.QueryString["idnhacungcap"]);
        phieuxuatkho.data("idkho2", Request.QueryString["idkho2"]);
        phieuxuatkho.data("idnguoixuat", Request.QueryString["idnguoixuat"]);
        phieuxuatkho.data("IdBenhNhanToaThuoc", Request.QueryString["IdBenhNhanToaThuoc"]);
        phieuxuatkho.data("IsBHYT", Request.QueryString["IsBHYT"]);
        phieuxuatkho.data("SLPX", Request.QueryString["SLPX"]);
        phieuxuatkho.data("tkNo", Request.QueryString["tkNo"]);
        phieuxuatkho.data("TKVAT", Request.QueryString["TKVAT"]);
        phieuxuatkho.data("TKCo", Request.QueryString["TKCo"]);
        phieuxuatkho.data("IdCaPhauThuat", Request.QueryString["IdCaPhauThuat"]);
        phieuxuatkho.data("IsDaHuy", Request.QueryString["IsDaHuy"]);
        phieuxuatkho.data("LANSUA", Request.QueryString["LANSUA"]);
        phieuxuatkho.data("MaPhieu", Request.QueryString["MaPhieu"]);
        phieuxuatkho.data("NGAYSUA", Request.QueryString["NGAYSUA"]);
        phieuxuatkho.data("NGUOISUA", Request.QueryString["NGUOISUA"]);
        phieuxuatkho.data("IdLoaiThuoc", Request.QueryString["IdLoaiThuoc"]);
        phieuxuatkho.data("IdBenhNhan", Request.QueryString["IdBenhNhan"]);
        phieuxuatkho.data("IDKHAMBENH1", Request.QueryString["IDKHAMBENH1"]);
        phieuxuatkho.data("IDPHIEUYC", Request.QueryString["IDPHIEUYC"]);
        phieuxuatkho.data("SOPHIEUYC", Request.QueryString["SOPHIEUYC"]);
        return phieuxuatkho;
    }
    protected DataProcess s_chitietphieuxuatkho()
    {
        DataProcess chitietphieuxuatkho = new DataProcess("chitietphieuxuatkho");
        chitietphieuxuatkho.data("idchitietphieuxuat", Request.QueryString["idkhoachinh"]);
        chitietphieuxuatkho.data("idphieuxuat", Request.QueryString["idphieuxuat"]);
        chitietphieuxuatkho.data("idthuoc", Request.QueryString["idthuoc"]);
        chitietphieuxuatkho.data("soluong", (Request.QueryString["soluong"] != null && Request.QueryString["soluong"] != "" ? Request.QueryString["soluong"].Replace(".", "").Replace(",", ".") : ""));
        chitietphieuxuatkho.data("dongia", (Request.QueryString["dongia"] != null && Request.QueryString["dongia"] != "" ? Request.QueryString["dongia"].Replace(".", "").Replace(",", ".") : ""));
        chitietphieuxuatkho.data("idchitietphieunhapkho", Request.QueryString["idchitietphieunhapkho"]);
        chitietphieuxuatkho.data("idtu", Request.QueryString["idtu"]);
        chitietphieuxuatkho.data("idngan", Request.QueryString["idngan"]);
        chitietphieuxuatkho.data("sluongxuat", Request.QueryString["sluongxuat"]);
        chitietphieuxuatkho.data("dvt", Request.QueryString["dvt"]);
        chitietphieuxuatkho.data("thanhtien", (Request.QueryString["thanhtien"] != null && Request.QueryString["thanhtien"] != "" ? Request.QueryString["thanhtien"].Replace(".", "").Replace(",", ".") : ""));
        chitietphieuxuatkho.data("thanhtientruocthue", Request.QueryString["thanhtientruocthue"]);
        chitietphieuxuatkho.data("tienthue", Request.QueryString["tienthue"]);
        chitietphieuxuatkho.data("chietkhau", Request.QueryString["chietkhau"]);
        chitietphieuxuatkho.data("giavon", Request.QueryString["giavon"]);
        chitietphieuxuatkho.data("tienvon", Request.QueryString["tienvon"]);
        chitietphieuxuatkho.data("tiensauchietkhau", Request.QueryString["tiensauchietkhau"]);
        chitietphieuxuatkho.data("tienchietkhau", Request.QueryString["tienchietkhau"]);
        chitietphieuxuatkho.data("IDCHITIETPHIEUYEUCAUXUATKHO", Request.QueryString["IDCHITIETPHIEUYEUCAUXUATKHO"]);
        chitietphieuxuatkho.data("tkkho", Request.QueryString["tkkho"]);
        chitietphieuxuatkho.data("tkco", Request.QueryString["tkco"]);
        chitietphieuxuatkho.data("idchitietbenhnhantoathuoc", Request.QueryString["idchitietbenhnhantoathuoc"]);
        chitietphieuxuatkho.data("idThuocPhauThuat", Request.QueryString["idThuocPhauThuat"]);
        chitietphieuxuatkho.data("VAT", Request.QueryString["VAT"]);
        chitietphieuxuatkho.data("IDKHO_XUAT", Request.QueryString["IDKHO_XUAT"]);
        chitietphieuxuatkho.data("NGAYTHANG_XUAT", Request.QueryString["NGAYTHANG_XUAT"]);
        chitietphieuxuatkho.data("LOSANXUAT_XUAT", Request.QueryString["LOSANXUAT_XUAT"]);
        chitietphieuxuatkho.data("NGAYHETHAN_XUAT", Request.QueryString["NGAYHETHAN_XUAT"]);
        chitietphieuxuatkho.data("IDLOAIXUAT_XUAT", Request.QueryString["IDLOAIXUAT_XUAT"]);
        chitietphieuxuatkho.data("BHTra", Request.QueryString["BHTra"]);
        chitietphieuxuatkho.data("BNDaTra", Request.QueryString["BNDaTra"]);
        chitietphieuxuatkho.data("BNTra", Request.QueryString["BNTra"]);
        chitietphieuxuatkho.data("DonGiaBH", Request.QueryString["DonGiaBH"]);
        chitietphieuxuatkho.data("DonGiaDV", Request.QueryString["DonGiaDV"]);
        chitietphieuxuatkho.data("IsBHYT", Request.QueryString["IsBHYT"]);
        chitietphieuxuatkho.data("ISBNDaTra", Request.QueryString["ISBNDaTra"]);
        chitietphieuxuatkho.data("IsDaHuy", Request.QueryString["IsDaHuy"]);
        chitietphieuxuatkho.data("NGAYTINHBH_THUC", Request.QueryString["NGAYTINHBH_THUC"]);
        chitietphieuxuatkho.data("PrevBNTra", Request.QueryString["PrevBNTra"]);
        chitietphieuxuatkho.data("SL_Prev", Request.QueryString["SL_Prev"]);
        chitietphieuxuatkho.data("ThanhTien_Prev", Request.QueryString["ThanhTien_Prev"]);
        chitietphieuxuatkho.data("ThanhTienBH", Request.QueryString["ThanhTienBH"]);
        chitietphieuxuatkho.data("ThanhTienDV", Request.QueryString["ThanhTienDV"]);
        chitietphieuxuatkho.data("OutPutDetailID", Request.QueryString["OutPutDetailID"]);
        chitietphieuxuatkho.data("IDKHAMBENH1", Request.QueryString["IDKHAMBENH1"]);
        chitietphieuxuatkho.data("IdNuocSX_X", Request.QueryString["IdNuocSX_X"]);
        chitietphieuxuatkho.data("GhiChu", Request.QueryString["GhiChu"]);
        chitietphieuxuatkho.data("IdLoaiThuoc", Request.QueryString["IdLoaiThuoc"]);
        return chitietphieuxuatkho;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savephieuxuatkho(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTablechitietphieuxuatkho": LuuTablechitietphieuxuatkho(); break;
            case "loadTablechitietphieuxuatkho": loadTablechitietphieuxuatkho(); break;
            case "xoa": Xoaphieuxuatkho(); break;
            case "xoachitietphieuxuatkho": Xoachitietphieuxuatkho(); break;
            case "idthuocSearch": idthuocSearch(); break;
            case "dvtSearch": dvtSearch(); break;
            case "IdNuocSX_XSearch": IdNuocSX_XSearch(); break;
            case "idkhoSearch": idkhoSearch(); break;
            case "PrintBienBan": PrintBienBan(); break;
            case "setIdKho": setIdKho(); break;
            case "setNuocSX": setNuocSX(); break;
        }
    }
    private void setNuocSX()
    {
        string idthuoc = Request.QueryString["idthuoc"];
        string sqlSelectTHUOC = @"select top 1 A.idnuocsanxuat,B.tenNuocSX ,A.idhangsanxuat,C.tenhangsanxuat 
                           from THUOC a
                           left join NUOCSX B ON A.idnuocsanxuat=B.IDNUOCSX
                           LEFT JOIN HANGSANXUAT C ON a.idhangsanxuat=C.IDHANGSANXUAT
                           where a.idthuoc=" + idthuoc;
        string sqlSelect = @"SELECT TOP 1 DONGIA=ROUND(DONGIA+(DONGIA*(ISNULL(VAT,0))/100),0) FROM CHITIETPHIEUNHAPKHO A 
                                   WHERE A.IDKHO_NHAP=" + StaticData.MacDinhKhoNhapMuaID + " AND A.IDLOAINHAP_NHAP=1 AND A.IDTHUOC=" + idthuoc;
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        string DonGia = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            DonGia = dt.Rows[0]["DONGIA"].ToString();
        }
        DataTable dtTHUOC = DataAcess.Connect.GetTable(sqlSelectTHUOC);
        if (dtTHUOC != null && dtTHUOC.Rows.Count > 0)
        {
            Response.Clear();
            Response.Write(dtTHUOC.Rows[0]["idnuocsanxuat"].ToString()
                            + "|" + dtTHUOC.Rows[0]["tenNuocSX"].ToString()
                            + "|" + DonGia);
            return;
        }
    }
    private void setIdKho()
    {
        string sqlSelect = @"SELECT IDKHO,TENKHO FROM KHOTHUOC WHERE IDKHO='"
            + StaticData.KhoHuHongVo
            + "' AND ISNULL(ISKT,0)=0 ";
        DataTable dtKhoHH = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        html.AppendLine("<root>");
        if (dtKhoHH != null & dtKhoHH.Rows.Count > 0)
        {
            for (int i = 0; i < dtKhoHH.Rows.Count; i++)
            {
                html.AppendLine("<data id=\"idkho\">" + dtKhoHH.Rows[0]["idkho"].ToString() + "</data>");
                html.AppendLine("<data id=\"mkv_idkho\">" + dtKhoHH.Rows[0]["tenkho"].ToString() + "</data>");
            }
        }
        html.AppendLine("</root>");
        Response.Clear();
        Response.Write(html.ToString().Replace("&", "&amp;"));

    }
    private void idthuocSearch()
    {
        StaticData.getthuoc_thanhly(this, false);
    }
    private void dvtSearch()
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
    private void IdNuocSX_XSearch()
    {
        DataTable table = DataProcess.GetTable("select * from NuocSX");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenNuocSX"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoaphieuxuatkho()
    {
        try
        {
            DataProcess process = s_phieuxuatkho();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idphieuxuat"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void Xoachitietphieuxuatkho()
    {
        try
        {
            DataProcess process = s_chitietphieuxuatkho();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idchitietphieuxuat"));
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
        if (StaticData.HavePermision(this, "phieuxuatkho_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 T.*
                               ,mkv_idkho=kt.tenkho
                               from phieuxuatkho T
                               left join khothuoc kt on t.idkho=kt.idkho 
             where T.idphieuxuat ='" + idkhoachinh + "'");
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
    private void idkhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "phieuxuatkho_Search"))
        {
            DataProcess process = s_phieuxuatkho();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idphieuxuat),T.*
                        ,kt.tenkho       
                        from phieuxuatkho T
                        left join khothuoc kt on t.idkho=kt.idkho
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["idphieuxuat"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["maphieuxuat"].ToString() + "</td>");
                        html.Append("<td>" + DataProcess.sGetDate(table.Rows[i]["ngaythang"].ToString(), false, true) + "</td>");
                        html.Append("<td>" + table.Rows[i]["ghichu"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tenkho"].ToString() + "</td>");
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
    private void Savephieuxuatkho()
    {
        try
        {
            DataProcess process = s_phieuxuatkho();
            string MaPhieuXuat = process.getData("MaPhieuXuat");
            string NgayThang = process.getData("ngaythang");
            if (MaPhieuXuat == null || MaPhieuXuat == "")
            {
                string stemp = null;
                MaPhieuXuat = myInsertPhieuXuatKho.TaoSoPhieuXuat(StaticData.CheckDate(NgayThang), ref stemp);
                {
                    process.data("maphieuxuat", MaPhieuXuat);
                    process.data("SLPX", stemp);
                }
            }
            string sophieuyc = process.getData("sophieuyc");
            if (sophieuyc == null || sophieuyc == "")
            {
                sophieuyc = StaticData_HS.TaoSoPhieuYCTL(process.getData("idkho"), StaticData.CheckDate(NgayThang + " 23:59:59"));
                {
                    process.data("sophieuyc", sophieuyc);
                }
            }
            if (process.getData("idphieuxuat") != null && process.getData("idphieuxuat") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idphieuxuat"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idphieuxuat"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablechitietphieuxuatkho()
    {
        try
        {
            DataProcess process = s_chitietphieuxuatkho();
            if (process.getData("idchitietphieuxuat") != null && process.getData("idchitietphieuxuat") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietphieuxuat"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietphieuxuat"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTablechitietphieuxuatkho()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();

        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LOSANXUAT_XUAT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdNuocSX_X") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYHETHAN_XUAT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "chitietphieuxuatkho_Add");
        bool search = StaticData.HavePermision(this, "chitietphieuxuatkho_Search");
        if (search)
        {
            DataProcess process = s_chitietphieuxuatkho();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietphieuxuat),T.*
                   ,A.maphieuxuat
                   ,B.tenthuoc
                   ,C.TenDVT
                   ,D.tenNuocSX
                   ,E.tenloai
                               from chitietphieuxuatkho T
                    left join phieuxuatkho  A on T.idphieuxuat=A.idphieuxuat
                    left join thuoc  B on T.idthuoc=B.idthuoc
                    left join Thuoc_DonViTinh  C on T.dvt=C.Id
                    left join NuocSX  D on T.IdNuocSX_X=D.idNuocSX
                    left join Thuoc_LoaiThuoc  E on T.IdLoaiThuoc=E.LoaiThuocID
          where T.idphieuxuat='" + process.getData("idphieuxuat") + "'");
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("chitietphieuxuatkho");
                bool delete = StaticData.HavePermision(this, "chitietphieuxuatkho_Delete");
                bool edit = StaticData.HavePermision(this, "chitietphieuxuatkho_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='IdLoaiThuoc' type='hidden' value='" + table.Rows[i]["IdLoaiThuoc"] + "'/><input mkv='true' id='mkv_IdLoaiThuoc' type='text' value='" + table.Rows[i]["tenloai"].ToString() + "' onfocus='IdLoaiThuocSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "  style='width:70px'/></td>");
                    html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' id='mkv_idthuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='idthuocSearch(this);' onblur='setNuocSX(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:90%' /></td>");
                    html.Append("<td><input mkv='true' id='dvt' type='hidden' value='" + table.Rows[i]["dvt"] + "'/><input mkv='true' id='mkv_dvt' type='text' value='" + table.Rows[i]["TenDVT"].ToString() + "' onfocus='dvtSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "  style='width:90%;' /></td>");
                    html.Append("<td><input mkv='true' id='LOSANXUAT_XUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["LOSANXUAT_XUAT"].ToString() + "' " + (!edit ? "disabled" : "") + "  style='width:90%;text-align:center;' /></td>");
                    html.Append("<td><input mkv='true' id='IdNuocSX_X' type='hidden' value='" + table.Rows[i]["IdNuocSX_X"] + "'/><input mkv='true' id='mkv_IdNuocSX_X' type='text' value='" + table.Rows[i]["tenNuocSX"].ToString() + "' onfocus='IdNuocSX_XSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "  style='width:90%;' /></td>");
                    html.Append("<td><input mkv='true' id='NGAYHETHAN_XUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + DataProcess.sGetDate(table.Rows[i]["NGAYHETHAN_XUAT"].ToString(), false, true) + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + " style='width:90%;text-align:center;' /></td>");
                    html.Append("<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n3}", table.Rows[i]["dongia"]) + "' onblur='checkSLTON(this);tinhtien(this);' " + (!edit ? "disabled" : "") + " style='width:90%;text-align:center;' /></td>");
                    html.Append("<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n2}", table.Rows[i]["soluong"]) + "' onblur='checkSLTON(this);tinhtien(this);' " + (!edit ? "disabled" : "") + " style='width:90%;text-align:center;' /></td>");
                    html.Append("<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n3}", table.Rows[i]["thanhtien"]) + "' " + (!edit ? "disabled" : "") + " style='width:90%;text-align:center;' /></td>");
                    html.Append("<td><input mkv='true' id='GhiChu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["GhiChu"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:90%;' /></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietphieuxuat"].ToString() + "'/><input mkv='true' id='idkhoachinh' type='SLTON' value=''/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='IdLoaiThuoc' type='hidden' value=''/><input mkv='true' id='mkv_IdLoaiThuoc' type='text' value='' onfocus='IdLoaiThuocSearch(this);' class=\"down_select\" style='width:70px'/></td>");
            html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus='idthuocSearch(this);' onblur='setNuocSX(this);' class=\"down_select\"  style='width:90%;' /></td>");
            html.Append("<td><input mkv='true' id='dvt' type='hidden' value=''/><input mkv='true' id='mkv_dvt' type='text' value='' onfocus='dvtSearch(this);' class=\"down_select\"  style='width:90%;'/></td>");
            html.Append("<td><input mkv='true' id='LOSANXUAT_XUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:90%;text-align:center;' /></td>");
            html.Append("<td><input mkv='true' id='IdNuocSX_X' type='hidden' value=''/><input mkv='true' id='mkv_IdNuocSX_X' type='text' value='' onfocus='IdNuocSX_XSearch(this);' class=\"down_select\"  style='width:90%;'/></td>");
            html.Append("<td><input mkv='true' id='NGAYHETHAN_XUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)'  style='width:90%;text-align:center;;'/></td>");
            html.Append("<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='checkSLTON(this);tinhtien(this);'  style='width:90%;text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='checkSLTON(this);tinhtien(this);' style='width:90%;text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:90%;text-align:center;' /></td>");
            html.Append("<td><input mkv='true' id='GhiChu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:90%;'/></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/><input mkv='true' id='SLTON' type='hidden' value=''/></td>");
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
    //______________________________________________________________________
    profess_Rpt_BienBanThanhLy NXTReport = null;
    private void PrintBienBan()
    {
        string idphieuxuat = Request.QueryString["idphieuxuat"];
        NXTReport = new profess_Rpt_BienBanThanhLy();
        NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        NXTReport.IdPhieuXuat = idphieuxuat;
        NXTReport.ExportToExcel();
    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
}



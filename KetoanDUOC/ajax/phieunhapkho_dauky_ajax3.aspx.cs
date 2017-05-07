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

public partial class phieunhapkho_dauky_ajax : System.Web.UI.Page
{
    protected DataProcess s_phieunhapkho()
    {
        DataProcess phieunhapkho = new DataProcess("phieunhapkho");
        phieunhapkho.data("idphieunhap", Request.QueryString["idkhoachinh"]);
        phieunhapkho.data("maphieunhap", Request.QueryString["maphieunhap"]);
        phieunhapkho.data("ngaythang", Request.QueryString["ngaythang"]);
        phieunhapkho.data("idkho", Request.QueryString["idkho"]);
        phieunhapkho.data("nhacungcapid", Request.QueryString["nhacungcapid"]);
        phieunhapkho.data("tennguoigiao", Request.QueryString["tennguoigiao"]);
        phieunhapkho.data("kyhieuhoadon", Request.QueryString["kyhieuhoadon"]);
        phieunhapkho.data("sohoadon", Request.QueryString["sohoadon"]);
        phieunhapkho.data("ngayhoadon", Request.QueryString["ngayhoadon"]);
        phieunhapkho.data("tkno", Request.QueryString["tkno"]);
        phieunhapkho.data("tkco", Request.QueryString["tkco"]);
        phieunhapkho.data("tkvat", Request.QueryString["tkvat"]);
        phieunhapkho.data("nhapcho", Request.QueryString["nhapcho"]);
        phieunhapkho.data("ghichu", Request.QueryString["ghichu"]);
        phieunhapkho.data("vat", Request.QueryString["vat"]);
        phieunhapkho.data("thanhtien", Request.QueryString["thanhtien"]);
        phieunhapkho.data("idkhachhang", Request.QueryString["idkhachhang"]);
        phieunhapkho.data("idnguoinhap", Request.QueryString["idnguoinhap"]);
        string idloainhap = Request.QueryString["idloainhap"];
        if (idloainhap == null || idloainhap == "")
            idloainhap = "1";
        string IsDauKy = Request.QueryString["IsDauKy"];
        if (IsDauKy == "1")
            idloainhap = "3";
        idloainhap = idloainhap.Replace(",", "");

        if (idloainhap == "11")
            idloainhap = "1";
        if (idloainhap == "33")
            idloainhap = "3";
        phieunhapkho.data("idloainhap", idloainhap);
        phieunhapkho.data("IsBHYT", Request.QueryString["IsBHYT"]);
        phieunhapkho.data("tienhang", Request.QueryString["tienhang"]);
        phieunhapkho.data("tienvat", Request.QueryString["tienvat"]);
        phieunhapkho.data("tongtien", Request.QueryString["tongtien"]);
        phieunhapkho.data("ptn", Request.QueryString["ptn"]);
        phieunhapkho.data("TrangThai", Request.QueryString["TrangThai"]);
        phieunhapkho.data("IdPhieuXuat", Request.QueryString["IdPhieuXuat"]);
        phieunhapkho.data("nhacungcapidbk", Request.QueryString["nhacungcapidbk"]);
        phieunhapkho.data("IsDaHuy", Request.QueryString["IsDaHuy"]);
        phieunhapkho.data("LANSUA", Request.QueryString["LANSUA"]);
        phieunhapkho.data("NGAYSUA", Request.QueryString["NGAYSUA"]);
        phieunhapkho.data("NGUOISUA", Request.QueryString["NGUOISUA"]);
        return phieunhapkho;
    }
    protected DataProcess s_chitietphieunhapkho()
    {
        DataProcess chitietphieunhapkho = new DataProcess("chitietphieunhapkho");
        chitietphieunhapkho.data("idchitietphieunhapkho", Request.QueryString["idkhoachinh"]);
        chitietphieunhapkho.data("idphieunhap", Request.QueryString["idphieunhap"]);
        chitietphieunhapkho.data("idthuoc", Request.QueryString["idthuoc"]);
        chitietphieunhapkho.data("Soluong_N", Request.QueryString["Soluong_N"]);
        chitietphieunhapkho.data("Dongia_N", Request.QueryString["Dongia_N"]);

        chitietphieunhapkho.data("Soluong", Request.QueryString["Soluong"]);
        chitietphieunhapkho.data("Dongia", Request.QueryString["Dongia"]);


        chitietphieunhapkho.data("chietkhau", Request.QueryString["chietkhau"]);
        chitietphieunhapkho.data("vat", Request.QueryString["vat"]);
        chitietphieunhapkho.data("dgsauchietkhau", Request.QueryString["dgsauchietkhau"]);
        chitietphieunhapkho.data("ngayhethan", Request.QueryString["ngayhethan"]);
        chitietphieunhapkho.data("losanxuat", Request.QueryString["losanxuat"]);
        chitietphieunhapkho.data("dongiaban", Request.QueryString["dongiaban"]);
        chitietphieunhapkho.data("soluongthue", Request.QueryString["soluongthue"]);
        chitietphieunhapkho.data("thue", Request.QueryString["thue"]);
        chitietphieunhapkho.data("soluongtang", Request.QueryString["soluongtang"]);
        chitietphieunhapkho.data("idtu", Request.QueryString["idtu"]);
        chitietphieunhapkho.data("idngan", Request.QueryString["idngan"]);
        chitietphieunhapkho.data("soluongxuat", Request.QueryString["soluongxuat"]);
        chitietphieunhapkho.data("IdDVT_N", Request.QueryString["IdDVT_N"]);
        chitietphieunhapkho.data("ThanhTien", Request.QueryString["ThanhTien"]);
        chitietphieunhapkho.data("thanhtientruocthue", Request.QueryString["thanhtientruocthue"]);
        chitietphieunhapkho.data("tienthue", Request.QueryString["tienthue"]);
        chitietphieunhapkho.data("daapgia", Request.QueryString["daapgia"]);
        chitietphieunhapkho.data("heso", Request.QueryString["heso"]);
        chitietphieunhapkho.data("tiensauchietkhau", Request.QueryString["tiensauchietkhau"]);
        chitietphieunhapkho.data("tienchietkhau", Request.QueryString["tienchietkhau"]);
        chitietphieunhapkho.data("Sltct", Request.QueryString["Sltct"]);
        chitietphieunhapkho.data("IdChiTietPhieuXuatKho", Request.QueryString["IdChiTietPhieuXuatKho"]);
        chitietphieunhapkho.data("IdThuoc1", Request.QueryString["IdThuoc1"]);
        chitietphieunhapkho.data("tkNo", Request.QueryString["tkNo"]);
        chitietphieunhapkho.data("SoDK", Request.QueryString["SoDK"]);
        chitietphieunhapkho.data("SLTon", Request.QueryString["SLTon"]);
        chitietphieunhapkho.data("TTXUAT", Request.QueryString["TTXUAT"]);
        chitietphieunhapkho.data("IDKHO_NHAP", Request.QueryString["IDKHO_NHAP"]);
        chitietphieunhapkho.data("NGAYTHANG_NHAP", Request.QueryString["NGAYTHANG_NHAP"]);
        chitietphieunhapkho.data("IDLOAINHAP_NHAP", Request.QueryString["IDLOAINHAP_NHAP"]);
        chitietphieunhapkho.data("IdChiTietPhieuYCTra", Request.QueryString["IdChiTietPhieuYCTra"]);
        chitietphieunhapkho.data("GIABANBH", Request.QueryString["GIABANBH"]);
        chitietphieunhapkho.data("GIABANDV", Request.QueryString["GIABANDV"]);
        chitietphieunhapkho.data("IsDaHuy", Request.QueryString["IsDaHuy"]);
        chitietphieunhapkho.data("SL_Prev", Request.QueryString["SL_Prev"]);
        chitietphieunhapkho.data("SLNHAP", Request.QueryString["SLNHAP"]);
        chitietphieunhapkho.data("ThanhTien_Prev", Request.QueryString["ThanhTien_Prev"]);
        chitietphieunhapkho.data("TIENCKSauTh", Request.QueryString["TIENCKSauTh"]);
        chitietphieunhapkho.data("TIENCKTrTh", Request.QueryString["TIENCKTrTh"]);
        chitietphieunhapkho.data("IdLoaiThuoc", Request.QueryString["IdLoaiThuoc"]);
        chitietphieunhapkho.data("IdNuocSX_N", Request.QueryString["IdNuocSX_N"]);
        chitietphieunhapkho.data("IdHangSX_N", Request.QueryString["IdHangSX_N"]);
        return chitietphieunhapkho;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savephieunhapkho(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTablechitietphieunhapkho": LuuTablechitietphieunhapkho(); break;
            case "loadTablechitietphieunhapkho": loadTablechitietphieunhapkho(); break;
            case "xoa": Xoaphieunhapkho(); break;
            case "xoachitietphieunhapkho": Xoachitietphieunhapkho(); break;
            case "idkhoSearch": idkhoSearch(); break;
            case "nhacungcapidSearch": nhacungcapidSearch(); break;
            case "idnguoinhapSearch": idnguoinhapSearch(); break;
            case "idthuocSearch": idthuocSearch(); break;
            case "dvtSearch": dvtSearch(); break;
            case "IdLoaiThuocSearch": IdLoaiThuocSearch(); break;
            case "setIdKho": setIdKho(); break;
            case "GetMaPhieuNhap": GetMaPhieuNhap(); break;
            case "IdNuocSX_NSearch": IdNuocSX_NSearch(); break;
            case "IdHangSX_NSearch": IdHangSX_NSearch(); break;
            case "SetNuocSX": SetNuocSX_NSearch(); break;
        }
    }
    private void IdNuocSX_NSearch()
    {
        string tenDVT = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM nuocsx WHERE tenNuocSX LIKE N'" + tenDVT + "%' ORDER BY tenNuocSX");
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
    private void IdHangSX_NSearch()
    {
        string tenDVT = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM hangsanxuat WHERE tenhangsanxuat LIKE N'" + tenDVT + "%' ORDER BY tenhangsanxuat");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenhangsanxuat"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void SetNuocSX_NSearch()
    {
        string idthuoc = Request.QueryString["idthuoc"];
        string sqlSelect = @"select top 1 IdNuocSX_N ,TenNuocSX,IdHangSX_N,TenHangSanXuat
                           from chitietphieunhapkho a
                           left join thuoc b on a.idthuoc=b.idthuoc
                           left join NUOCSX C ON IdNuocSX_N=C.IDNUOCSX
                           LEFT JOIN HANGSANXUAT D ON IdHangSX_N=D.IDHANGSANXUAT
                           where a.idthuoc=" + idthuoc
                            + @" AND ( ISNULL(IDNUOCSX_N,0)<>0 OR ISNULL(IDHANGSX_N,0)<>0)   ORDER BY NGAYTHANG_NHAP DESC";
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt == null || dt.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("");
            return;
        }
        Response.Write(dt.Rows[0][0].ToString() + "|" + dt.Rows[0][1].ToString() + "|" + dt.Rows[0][2].ToString() + "|" + dt.Rows[0][3].ToString());
    }
    private void GetMaPhieuNhap()
    {
        string sqlSelect = @"SELECT MAPHIEUNHAP FROM PHIEUNHAPKHO WHERE IDPHIEUNHAP='" + Request.QueryString["IDPHIEUNHAP"] + "'";
        DataTable dtMaPhieuNhap = DataAcess.Connect.GetTable(sqlSelect);
        if (dtMaPhieuNhap == null || dtMaPhieuNhap.Rows.Count == 0) return;
        Response.Write(dtMaPhieuNhap.Rows[0]["MAPHIEUNHAP"].ToString());
    }
    private void setIdKho()
    {
        StaticData.SetDefaultIdKho(this, "idkho", "mkv_idkho", null, null);
    }
    private void idkhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void nhacungcapidSearch()
    {
        string TenNhaCungCap = Request.QueryString["q"];
        DataTable table = null;
        string sqlSelect = " SELECT * FROM NHACUNGCAP WHERE ISNULL(ISKT,0)=0 ";
        if (TenNhaCungCap != null && TenNhaCungCap != "")
            sqlSelect += " AND TENNHACUNGCAP LIKE N'%" + TenNhaCungCap + "%'";
        sqlSelect += " ORDER BY TENNHACUNGCAP";
        table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenNhaCungCap"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idnguoinhapSearch()
    {
        DataTable table = Thuoc_Process.nguoidung.dtGetAll();
        table.DefaultView.Sort = "TenNguoiDung";
        table = table.DefaultView.ToTable();
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenNguoiDung"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idthuocSearch()
    {
        StaticData.getthuoc(this, true);
    }
    private void dvtSearch()
    {
        string tenDVT = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM THUOC_DONVITINH WHERE TENDVT LIKE N'" + tenDVT + "%' ORDER BY TENDVT");
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
    private void IdLoaiThuocSearch()
    {
        StaticData.IdLoaiThuocSearch(this);
    }
    private void Xoaphieunhapkho()
    {
        try
        {
            DataProcess process = s_phieunhapkho();
            string idphieunhap = process.getData("idphieunhap");
            bool ok_Detail = DataAcess.Connect.ExecSQL("DELETE CHITIETPHIEUNHAPKHO WHERE IDPHIEUNHAP=" + idphieunhap);
            if (!ok_Detail)
            {
                Response.StatusCode = 500;
                return;
            }
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idphieunhap"));
                return;
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    private void Xoachitietphieunhapkho()
    {
        try
        {
            DataProcess process = s_chitietphieunhapkho();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idchitietphieunhapkho"));
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
        if (StaticData.HavePermision(this, "phieunhapkho_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = Thuoc_Process.phieunhapkho.dtSearchByidphieunhap(idkhoachinh);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");

            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable idkho = Thuoc_Process.khothuoc.dtSearchByidkho("'" + table.Rows[0]["idkho"] + "'");
            html.AppendLine("<data id=\"mkv_idkho\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0]["tenkho"] : "") + "</data>");
            DataTable nhacungcapid = Thuoc_Process.nhacungcap.dtSearchBynhacungcapid("'" + table.Rows[0]["nhacungcapid"] + "'");
            html.AppendLine("<data id=\"mkv_nhacungcapid\">" + ((nhacungcapid.Rows.Count > 0) ? nhacungcapid.Rows[0]["tennhacungcap"] : "") + "</data>");
            DataTable idnguoinhap = Thuoc_Process.nguoidung.dtSearchByidnguoidung("'" + table.Rows[0]["idnguoinhap"] + "'");
            html.AppendLine("<data id=\"mkv_idnguoinhap\">" + ((idnguoinhap.Rows.Count > 0) ? idnguoinhap.Rows[0]["tennguoidung"] : "") + "</data>");

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {

                    for (int y = 0; y < table.Columns.Count; y++)
                    {
                        try
                        {
                            html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>");
                        }
                        catch
                        {
                            html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>");
                        }
                    }
                }
            }
            html.AppendLine("<data id=\"gio\">" + string.Format("{0:hh}", table.Rows[0]["ngaythang"]) + "</data>");
            html.AppendLine("<data id=\"phut\">" + string.Format("{0:mm}", table.Rows[0]["ngaythang"]) + "</data>");
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
        if (StaticData.HavePermision(this, "phieunhapkho_Search"))
        {

            DataProcess process = s_phieunhapkho();
            string idloainhap = process.getData("idloainhap");
            string IdKho = Request.QueryString["IdKho"];
            string sqlSelect = @"select STT=row_number() over (order by T.idphieunhap),T.*
                   ,A.TenKho
                   ,B.TenNhaCungCap
                   ,C.tennguoidung
                               from phieunhapkho T
                    left join khothuoc  A on T.idkho=A.idkho
                    left join nhacungcap  B on T.nhacungcapid=B.nhacungcapid
                    left join nguoidung  C on T.idnguoinhap=C.idnguoidung
                  where " + process.sWhere();
            if (idloainhap == "3")
            {
                string NgayThang = process.getData("ngaythang");
                if (NgayThang != null && NgayThang != "")
                {
                    NgayThang = StaticData.CheckDate(NgayThang);
                    sqlSelect = sqlSelect.ToUpper().Replace("AND T.NGAYTHANG >= '" + DateTime.Parse(NgayThang).ToString("MM/dd/yyyy") + "' AND T.NGAYTHANG <= '" + DateTime.Parse(NgayThang).ToString("MM/dd/yyyy") + " 23:59:59'", "");
                }
            }
            if (IdKho != null && IdKho != "")
            {
               sqlSelect += " AND T.IdKho='" + IdKho+"'";
            }
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(sqlSelect);
            if (table == null || table.Rows.Count == 0) return;
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieunhap") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nhacungcapid") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sohoadon") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhoadon") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnguoinhap") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["idphieunhap"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["maphieunhap"].ToString() + "</td>");
                        if (table.Rows[i]["ngaythang"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaythang"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["ngaythang"].ToString() + "</td>"); }
                        html.Append("<td style='width:150px;' >" + table.Rows[i]["TenKho"].ToString() + "</td>");
                        html.Append("<td style='width:300px; text-align:left;'>" + table.Rows[i]["TenNhaCungCap"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["sohoadon"].ToString() + "</td>");
                        if (table.Rows[i]["ngayhoadon"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngayhoadon"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["ngayhoadon"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["ghichu"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tennguoidung"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                    html.Append("</table>");
                    html.Append(process.Paging());
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
    private void Savephieunhapkho()
    {
        try
        {
            DataProcess process = s_phieunhapkho();
            string MaPhieuNhap = process.getData("maphieunhap");
            string NewSTT = "";
            if (MaPhieuNhap == null || MaPhieuNhap == "")
            {
                MaPhieuNhap = StaticData.TaoSoPhieuNhap(ref NewSTT);
                {
                    process.data("maphieunhap", MaPhieuNhap);
                }
            }
            string nhacungcapid = process.getData("nhacungcapid");
            if (nhacungcapid == null || nhacungcapid == "")
            {
                string sqlNhaCC = @"select * from nhacungcap where tennhacungcap=N'" + Request.QueryString["mkv_nhacungcapid"] + "'";
                DataTable dtCheck = DataAcess.Connect.GetTable(sqlNhaCC);
                if (dtCheck == null || dtCheck.Rows.Count == 0)
                {
                    sqlNhaCC = @"insert nhacungcap(tennhacungcap) values(N'" + Request.QueryString["mkv_nhacungcapid"] + "')";
                    bool ok = DataAcess.Connect.ExecSQL(sqlNhaCC);
                    if (ok)
                    {
                        sqlNhaCC = "select top 1 nhacungcapid from nhacungcap order by nhacungcapid desc";
                        dtCheck = DataAcess.Connect.GetTable(sqlNhaCC);
                        if (dtCheck != null && dtCheck.Rows.Count > 0)
                        {
                            process.data("nhacungcapid", dtCheck.Rows[0]["nhacungcapid"].ToString());
                        }
                        else
                        {
                            process.data("nhacungcapid", process.getData("nhacungcapid"));
                        }
                    }
                }

                else
                {
                    process.data("nhacungcapid", process.getData("nhacungcapid"));
                }
            }
            string abc = Request.QueryString["gio"] + ":" + Request.QueryString["phut"] + ":" + "59";
            string ngaythangfull = string.Format("{0:yyyy/MM/dd}", Request.QueryString["ngaythang"]) + " " + abc;
            process.data("ngaythang", ngaythangfull);
            if (process.getData("idphieunhap") != null && process.getData("idphieunhap") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idphieunhap"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idphieunhap"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablechitietphieunhapkho()
    {
        try
        {
            DataProcess process = s_chitietphieunhapkho();
            string idthuoc = process.getData("IDTHUOC");
            string mkv_idthuoc = Request.QueryString["mkv_idthuoc"];
            if (mkv_idthuoc == null || mkv_idthuoc == "")
            {
                Response.StatusCode = 500;
                return;
            }

            string IdNuocSX_N = process.getData("IdNuocSX_N");
            string IdHangSX_N = process.getData("IdHangSX_N");
            string NuocSX_Update = "";
            string HangSX_Update = "";
            if (IdNuocSX_N == null || IdNuocSX_N == "")
            {
                string mkv_IdNuocSX_N = Request.QueryString["mkv_IdNuocSX_N"];
                if (mkv_IdNuocSX_N != null && mkv_IdNuocSX_N != "")
                {
                    DataProcess NuocSX = new DataProcess("nuocsx");
                    NuocSX.data("tenNuocSX", mkv_IdNuocSX_N);
                    DataTable dtNuocSX = DataAcess.Connect.GetTable("select * from NuocSX where tenNuocSX=N'" + mkv_IdNuocSX_N + "'");

                    if (dtNuocSX == null || dtNuocSX.Rows.Count == 0)
                    {
                        bool OK_NuocSX = NuocSX.Insert();
                        if (OK_NuocSX)
                        {
                            IdNuocSX_N = NuocSX.getData("idNuocSX");
                            process.data("IdNuocSX_N", IdNuocSX_N);
                        }
                    }
                    else
                    {
                        IdNuocSX_N = dtNuocSX.Rows[0][0].ToString();
                        process.data("IdNuocSX_N", IdNuocSX_N);
                    }
                    NuocSX_Update = ",idnuocsanxuat='" + IdNuocSX_N + "'";
                }
            }

            if (IdHangSX_N == null || IdHangSX_N == "")
            {
                string mkv_IdHangSX_N = Request.QueryString["mkv_IdHangSX_N"];
                if (mkv_IdHangSX_N != null && mkv_IdHangSX_N != "")
                {
                    DataProcess HangSX = new DataProcess("hangsanxuat");
                    HangSX.data("tenhangsanxuat", mkv_IdHangSX_N);
                    DataTable dtHangSX = DataAcess.Connect.GetTable("SELECT * FROM HANGSANXUAT WHERE tenhangsanxuat=N'" + mkv_IdHangSX_N + "'");
                    if (dtHangSX == null || dtHangSX.Rows.Count == 0)
                    {
                        bool OK_HangSX = HangSX.Insert();
                        if (OK_HangSX)
                        {
                            IdHangSX_N = HangSX.getData("idhangsanxuat");
                            process.data("IdHangSX_N", IdHangSX_N);
                        }
                    }
                    else
                    {
                        IdHangSX_N = dtHangSX.Rows[0][0].ToString();
                        process.data("IdHangSX_N", IdHangSX_N);
                    }
                    HangSX_Update = ",idhangsanxuat='" + IdHangSX_N + "'";
                }
            }

            string iddvt = Request.QueryString["iddvt"];
            string dvtchuan = Request.QueryString["IdDVT_N"];
            string slquydoi = Request.QueryString["slquydoi"];
            string VAT = process.getData("VAT");
            if (VAT == "" || VAT == null)
            {
                VAT = "0";
                process.data("VAT", VAT);
            }

            string LoaiThuocID = process.getData("IdLoaiThuoc");
            #region Xử lý lưu thuốc
            #region Trường hợp chưa có thuốc
            if (idthuoc == null || idthuoc == "")
            {
                string sqlSelectThuoc = "SELECT IDTHUOC FROM THUOC WHERE TENTHUOC=N'" + mkv_idthuoc + "' AND ISTHUOCBV=1 AND ISNULL(IDDVT,0)=" + iddvt;
                DataTable dtThuoc = DataAcess.Connect.GetTable(sqlSelectThuoc);
                if (dtThuoc == null)
                {
                    return;
                }
                if (dtThuoc.Rows.Count == 0)
                {
                    DataProcess Thuoc_Pr = new DataProcess("Thuoc");
                    Thuoc_Pr.data("TenThuoc", mkv_idthuoc);
                    Thuoc_Pr.data("IdDVT", iddvt);
                    Thuoc_Pr.data("DVTChuan", dvtchuan);
                    Thuoc_Pr.data("slquydoi", slquydoi);
                    Thuoc_Pr.data("LoaiThuocID", LoaiThuocID);
                    Thuoc_Pr.data("IsThuocBV", "1");
                    Thuoc_Pr.data("idnuocsanxuat", IdNuocSX_N);
                    Thuoc_Pr.data("idhangsanxuat", IdHangSX_N);
                    bool InsertThuoc = Thuoc_Pr.Insert();
                    if (InsertThuoc == false)
                    {
                        Response.StatusCode = 500;
                        return;
                    }
                    else
                        process.data("idthuoc", Thuoc_Pr.getData("idthuoc"));
                }
                else
                {
                    idthuoc = dtThuoc.Rows[0][0].ToString();
                    process.data("idthuoc", idthuoc);
                }
            }
            #endregion
            #region Trường hợp đã có thuốc
            else
            {
                string sqlUpdate = "UPDATE THUOC SET";
                if (iddvt != null && iddvt != "")
                {
                    sqlUpdate += ",IDDVT='" + iddvt + "'";
                }
                if (dvtchuan != null && dvtchuan != "")
                {
                    sqlUpdate += ",DVTCHUAN='" + dvtchuan + "'";
                }
                if (slquydoi != null && slquydoi != "")
                {
                    sqlUpdate += ",SLQUYDOI='" + slquydoi + "'";
                }
                sqlUpdate += NuocSX_Update + HangSX_Update;
                sqlUpdate += " WHERE IDTHUOC='" + process.getData("IDTHUOC") + "'";
                sqlUpdate = sqlUpdate.Replace("SET,", "SET ");
                if (sqlUpdate != "UPDATE THUOC SET ")
                {
                    bool OK_thuoc = DataAcess.Connect.ExecSQL(sqlUpdate);
                    if (!OK_thuoc)
                    {
                        Response.StatusCode = 500;
                        return;
                    }
                }
            }
            #endregion
            #endregion
            string idloainhap = Request.QueryString["idloainhap"];
            if (idloainhap == null || idloainhap == "")
                idloainhap = DataAcess.Connect.GetTable("SELECT IDLOAINHAP FROM PHIEUNHAPKHO WHERE IDPHIEUNHAP=" + process.getData("idphieunhap")).Rows[0][0].ToString();

            if (idloainhap == null || idloainhap == "") idloainhap = "1";
            if (VAT == "") VAT = "0";
            double dongia = double.Parse(process.getData("Dongia"));
            double soluong = double.Parse(process.getData("Soluong"));
            string sChietKhau = process.getData("chietkhau");
            if (sChietKhau == null || sChietKhau == "")
                sChietKhau = "0";
            double chietkhau = double.Parse(sChietKhau);
            double THANHTIENTRUOCTHUE = dongia * soluong;
            double thanhtien = THANHTIENTRUOCTHUE * (100 + double.Parse(VAT)) / 100;
            thanhtien = Math.Round(thanhtien, 0);
            process.data("THANHTIENTRUOCTHUE", THANHTIENTRUOCTHUE.ToString());
            process.data("THANHTIEN", thanhtien.ToString());
            process.data("dvt", process.getData("iddvt"));

            bool OK_SAVE = false;
            if (process.getData("idchitietphieunhapkho") != null && process.getData("idchitietphieunhapkho") != "")
            {
                OK_SAVE = process.Update();

            }
            else
            {
                OK_SAVE = process.Insert();

            }
            if (OK_SAVE)
            {
                bool OK_QUYDOI3 = DataAcess.Connect.ExecSQL(" EXEC HS_QUYDOI03_PHIEUNHAP " + process.getData("idchitietphieunhapkho"));
                //bool OK_QUYDOI1 = DataAcess.Connect.ExecSQL(" EXEC HS_QUYDOI01_PHIEUNHAP " + process.getData("idchitietphieunhapkho"));
                Response.Clear(); Response.Write(process.getData("idchitietphieunhapkho"));
                return;
            }

        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    public void loadTablechitietphieunhapkho()
    {
        string idloainhap = Request.QueryString["idloainhap"];
        if (idloainhap == null || idloainhap == "") idloainhap = "1";

        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ĐVT\r\nchẵn") + "</th>");
        html.Append("<th style='width:40px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL\r\nchẵn") + "</th>");
        html.Append("<th style='width:40px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đơn giá\r\nchẵn") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Q.Đổi") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ĐVT\r\nlẻ") + "</th>");
        html.Append("<th style='width:40px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL\r\nlẻ") + "</th>");
        html.Append("<th style='width:40px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đơn giá\r\nlẻ") + "</th>");
        html.Append("<th style='width:40px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số ĐK") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("losanxuat") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhethan") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nuocsx") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("hangsx") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("vat\r\n(%)") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ck\r\n(%)") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "chitietphieunhapkho_Add");
        bool search = StaticData.HavePermision(this, "chitietphieunhapkho_Search");
        if (search)
        {
            DataProcess process = s_chitietphieunhapkho();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietphieunhapkho),T.*
                   ,D.MaLoai
                   ,B.tenthuoc
                   ,DVTChan.TenDVT as mkv_IdDVT_N
                   ,B.iddvt 
                   ,DVTLe.TenDVT as mkv_iddvt
                   ,TenNuocSX
                   ,TenHangSanXuat
                   ,B.SLQuyDoi
                   
                    from chitietphieunhapkho T
                    left join phieunhapkho  A on T.idphieunhap=A.idphieunhap
                    left join thuoc  B on T.idthuoc=B.idthuoc
                    left join Thuoc_LoaiThuoc  D on T.IdLoaiThuoc=D.LoaiThuocID
                    left join Thuoc_DonViTinh  DVTChan on T.IdDVT_N=DVTChan.Id
                    left join Thuoc_DonViTinh DVTLe on B.IdDVT=DVTLe.ID
                    left join NUOCSX  NSX on T.IdNuocSX_N=NSX.idNuocSX
                    left join HANGSANXUAT HSX  on T.IdHangSX_N=HSX.idhangsanxuat
                    
                 where T.idphieunhap='" + process.getData("idphieunhap") + "'");
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("chitietphieunhapkho");
                bool delete = StaticData.HavePermision(this, "chitietphieunhapkho_Delete");
                bool edit = StaticData.HavePermision(this, "chitietphieunhapkho_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='IdLoaiThuoc' type='hidden' value='" + table.Rows[i]["IdLoaiThuoc"] + "'/><input mkv='true' id='mkv_IdLoaiThuoc' type='text' value='" + table.Rows[i]["MaLoai"].ToString() + "' onfocus='IdLoaiThuocSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "  style='width:70px'/></td>");
                    html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' id='mkv_idthuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='idthuocSearch(this);'  onblur='CheckExistThuoc(this);'  class=\"down_select\" " + (!edit ? "disabled" : "") + "   style='width:190px'  /></td>");
                    html.Append("<td><input mkv='true' id='IdDVT_N' type='hidden' value='" + table.Rows[i]["IdDVT_N"] + "'/><input mkv='true' id='mkv_IdDVT_N' type='text' value='" + table.Rows[i]["mkv_IdDVT_N"].ToString() + "' onfocus='dvtSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:50px'/></td>");
                    html.Append("<td><input mkv='true' id='Soluong_N' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["Soluong_N"].ToString() + "' onblur='QuyDoiDVTChan(this);tinhtongtien();' " + (!edit ? "disabled" : "") + " style='width:40px; text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='Dongia_N' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format("{0:0,0.##}", table.Rows[i]["Dongia_N"]) + "' onblur='QuyDoiDVTChan(this);tinhtongtien();' " + (!edit ? "disabled" : "") + " style='width:70px; text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='SLQuyDoi' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SLQuyDoi"].ToString() + "' onblur='' " + (!edit ? "disabled" : "") + " style='width:40px; text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='iddvt' type='hidden' value='" + table.Rows[i]["iddvt"] + "'/><input mkv='true' id='mkv_iddvt' type='text' value='" + table.Rows[i]["mkv_iddvt"].ToString() + "' onfocus='dvtSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:50px'/></td>");
                    html.Append("<td><input mkv='true' id='Soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["Soluong"].ToString() + "' onblur='QuyDoiDVTLe(this);tinhtongtien();' " + (!edit ? "disabled" : "") + " style='width:40px; text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='Dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format("{0:0,0.##}", table.Rows[i]["Dongia"]) + "' onblur='QuyDoiDVTLe(this);tinhtongtien();' " + (!edit ? "disabled" : "") + " style='width:70px; text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='SoDK' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoDK"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:70px'/></td>");
                    html.Append("<td><input mkv='true' id='losanxuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["losanxuat"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:70px'/></td>");
                    if (table.Rows[i]["ngayhethan"].ToString() != "")
                    {
                        html.Append("<td><input mkv='true' id='ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).validDate();' value='" + DateTime.Parse(table.Rows[i]["ngayhethan"].ToString()).ToString("dd/MM/yyyy") + "' onblur='TestDate(this);checkHSD(this);' " + (!edit ? "disabled" : "") + " style='width:80px;text-align:center;'/></td>");
                    }
                    else { html.Append("<td><input mkv='true' id='ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + table.Rows[i]["ngayhethan"].ToString() + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + " style='width:80px;text-align:center;'/></td>"); }
                    html.Append("<td><input mkv='true' id='IdNuocSX_N' type='hidden' value='" + table.Rows[i]["IdNuocSX_N"] + "'/><input mkv='true' id='mkv_IdNuocSX_N' type='text' value='" + table.Rows[i]["tenNuocSX"].ToString() + "' onfocus='IdNuocSX_NSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/  style='width:80px;text-align:center;' ></td>");
                    html.Append("<td><input mkv='true' id='IdHangSX_N' type='hidden' value='" + table.Rows[i]["IdHangSX_N"] + "'/><input mkv='true' id='mkv_IdHangSX_N' type='text' value='" + table.Rows[i]["tenhangsanxuat"].ToString() + "' onfocus='IdHangSX_NSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/  style='width:80px;text-align:center;'></td>");
                    html.Append("<td><input mkv='true' id='vat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["vat"].ToString() + "' onblur='tinhthanhtien();' " + (!edit ? "disabled" : "") + " style='width:100%;text-align:center;' /></td>");
                    html.Append("<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["chietkhau"].ToString() + "' onblur='' " + (!edit ? "disabled" : "") + " style='width:30px; text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietphieunhapkho"].ToString() + "'/></td>");
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
            html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus='idthuocSearch(this);'  onblur='CheckExistThuoc(this);' class=\"down_select\"   style='width:190px' /></td>");
            html.Append("<td><input mkv='true' id='IdDVT_N' type='hidden' value=''/><input mkv='true' id='mkv_IdDVT_N' type='text' value='' onfocus='dvtSearch(this);' class=\"down_select\"/ style='width:50px'></td>");
            html.Append("<td><input mkv='true' id='Soluong_N' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='QuyDoiDVTChan(this);tinhtongtien();'  style='width:40px; text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='Dongia_N' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='QuyDoiDVTChan(this);tinhtongtien();' style='width:70px;text-align:center;' /></td>");
            html.Append("<td><input mkv='true' id='SLQuyDoi' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='' " + " style='width:40px; text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='iddvt' type='hidden' value='" + "" + "'/><input mkv='true' id='mkv_iddvt' type='text' value='" + "" + "' onfocus='dvtSearch(this);' class=\"down_select\" " + " style='width:50px'/></td>");
            html.Append("<td><input mkv='true' id='Soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='QuyDoiDVTLe(this);tinhtongtien();'  style='width:40px; text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='Dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='QuyDoiDVTLe(this);tinhtongtien();' style='width:70px;text-align:center;' /></td>");
            html.Append("<td><input mkv='true' id='SoDK' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:70px'/></td>");
            html.Append("<td><input mkv='true' id='losanxuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:70px'/></td>");
            html.Append("<td><input mkv='true' id='ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).validDate();' onblur='checkHSD(this);' style='width:80px;text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='IdNuocSX_N' type='hidden' value=''/><input mkv='true' id='mkv_IdNuocSX_N' type='text' value='' onfocus='IdNuocSX_NSearch(this);' class=\"down_select\"/style='width:80px;text-align:center;'></td>");
            html.Append("<td><input mkv='true' id='IdHangSX_N' type='hidden' value=''/><input mkv='true' id='mkv_IdHangSX_N' type='text' value='' onfocus='IdHangSX_NSearch(this);' class=\"down_select\"/style='width:80px;text-align:center;'></td>");
            html.Append("<td><input mkv='true' id='vat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='' style='width:100%;text-align:center;' /></td>");
            html.Append("<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='' style='width:30px;text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }

        html.Append("<tr><td></td><td colspan='11' style='text-align:right; font-weight:bold; font-size:16px;'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("total") + "</td><td><input mkv='true' id='tienhang' type='text' style='width:100%;text-align:center;' disabled='true'  /></td><td><input mkv='true' id='tienvat' type='text' style='width:100%;text-align:center;' disabled='true' /></td><td><input mkv='true' id='tongtien' type='text' style='width:100%;text-align:center;' disabled='true' /></td><td></td></tr>");

        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
}


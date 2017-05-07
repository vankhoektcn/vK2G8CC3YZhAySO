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

public partial class phieunhapkho_ajax : System.Web.UI.Page
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
        phieunhapkho.data("idloainhap", "1");
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
            case "LuuSoCai": LuuSoCai(); break;            
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
    private void GetMaPhieuNhap()
    {
        string sqlSelect = @"SELECT MAPHIEUNHAP FROM PHIEUNHAPKHO WHERE IDPHIEUNHAP='" + Request.QueryString["IDPHIEUNHAP"] + "'";
        DataTable dtMaPhieuNhap = DataAcess.Connect.GetTable(sqlSelect);
        if (dtMaPhieuNhap == null || dtMaPhieuNhap.Rows.Count == 0) return;
        Response.Write(dtMaPhieuNhap.Rows[0]["MAPHIEUNHAP"].ToString());
    }
    private void setIdKho()
    {
        string fullName = SysParameter.UserLogin.FullName(this);
        string userID = SysParameter.UserLogin.UserID(this);

        StringBuilder html = new StringBuilder();
        html.AppendLine("<root>");
        html.AppendLine("<data id=\"ngaythang\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"gio\">" + DateTime.Now.ToString("HH") + "</data>");
        html.AppendLine("<data id=\"phut\">" + DateTime.Now.ToString("mm") + "</data>");
        html.AppendLine("<data id=\"vat\">" + "5" + "</data>");
        DataTable idkho = DataAcess.Connect.GetTable("select * from khothuoc where idkho=4");
        html.AppendLine("<data id=\"idkho\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0]["idkho"] : "") + "</data>");
        html.AppendLine("<data id=\"mkv_idkho\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0]["tenkho"] : "") + "</data>");

        html.AppendLine("<data id=\"idnguoinhap\">" + userID + "</data>");
        html.AppendLine("<data id=\"mkv_idnguoinhap\">" + fullName + "</data>");


        html.AppendLine("</root>");
        Response.Clear();
        Response.Write(html.ToString().Replace("&", "&amp;"));
    }
    private void idkhoSearch()
    {
        string TenKho = Request.QueryString["q"];
        DataTable table = null;
        string sqlSelect = " SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 ";
        if (TenKho != null && TenKho != "")
            sqlSelect += " AND TenKho LIKE N'%" + TenKho + "%'";
        sqlSelect += " ORDER BY TENKHO";
        table = DataAcess.Connect.GetTable(sqlSelect);

        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenKho"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
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
        StaticData.getthuoc(this,true);
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
        DataTable table = Thuoc_Process.Thuoc_LoaiThuoc.dtGetAll();
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoaphieunhapkho()
    {
        try
        {
            DataProcess process = s_phieunhapkho();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idphieunhap"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
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
            html.AppendLine("<data id=\"mkv_tkco\">" + table.Rows[0]["tkco"] + "</data>");
            html.AppendLine("<data id=\"mkv_tkvat\">" + table.Rows[0]["tkvat"] + "</data>");
            html.AppendLine("<data id=\"mkv_tkno\">" + table.Rows[0]["tkno"] + "</data>");

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
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idphieunhap),T.*
                   ,A.TenKho
                   ,B.TenNhaCungCap
                   ,C.tennguoidung
                               from phieunhapkho T
                    left join khothuoc  A on T.idkho=A.idkho
                    left join nhacungcap  B on T.nhacungcapid=B.nhacungcapid
                    left join nguoidung  C on T.idnguoinhap=C.idnguoidung
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieunhap") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkco") + "</th>");
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
            if (process.getData("idchitietphieunhapkho") != null && process.getData("idchitietphieunhapkho") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    //LuuSoCai();
                    Response.Clear(); Response.Write(process.getData("idchitietphieunhapkho"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietphieunhapkho"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    public void loadTablechitietphieunhapkho()
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
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("losanxuat") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhethan") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TkNo") + "</th>");        
        html.Append("<th style='width:40px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ck\r\n(%)") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtientruocthue") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("vat\r\n(%)") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "chitietphieunhapkho_Add");
        bool search = StaticData.HavePermision(this, "chitietphieunhapkho_Search");
        if (search)
        {
            DataProcess process = s_chitietphieunhapkho();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietphieunhapkho),T.*
                   ,A.maphieunhap
                   ,B.tenthuoc
                   ,C.TenDVT
                   ,D.MaLoai
                   ,TenNuocSX
                   ,TenHangSanXuat
                   ,B.tkkho
                               from chitietphieunhapkho T
                    left join phieunhapkho  A on T.idphieunhap=A.idphieunhap
                    left join thuoc  B on T.idthuoc=B.idthuoc
                    left join Thuoc_DonViTinh  C on T.IdDVT_N=C.Id
                    left join Thuoc_LoaiThuoc  D on T.IdLoaiThuoc=D.LoaiThuocID
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
                    html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' id='mkv_idthuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='idthuocSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='IdDVT_N' type='hidden' value='" + table.Rows[i]["IdDVT_N"] + "'/><input mkv='true' id='mkv_dvt' type='text' value='" + table.Rows[i]["TenDVT"].ToString() + "' onfocus='dvtSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:50px'/></td>");
                    html.Append("<td><input mkv='true' id='losanxuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["losanxuat"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:70px'/></td>");
                    if (table.Rows[i]["ngayhethan"].ToString() != "")
                    {
                        html.Append("<td><input mkv='true' id='ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + DateTime.Parse(table.Rows[i]["ngayhethan"].ToString()).ToString("dd/MM/yyyy") + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + " style='width:80px;text-align:center;'/></td>");
                    }
                    else { html.Append("<td><input mkv='true' id='ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + table.Rows[i]["ngayhethan"].ToString() + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + " style='width:80px;text-align:center;'/></td>"); }
                    html.Append("<td><input mkv='true' id='tkno' type='hidden' value='" + (string.IsNullOrEmpty(table.Rows[i]["tkno"].ToString()) ? table.Rows[i]["tkkho"] : table.Rows[i]["tkno"]) + "'/><input mkv='true' id='mkv_tkno' type='text' value='" + (string.IsNullOrEmpty(table.Rows[i]["tkno"].ToString()) ? table.Rows[i]["tkkho"] : table.Rows[i]["tkno"]) + "' onfocus='tknoSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");                    
                    html.Append("<td><input mkv='true' id='Soluong_N' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["Soluong_N"].ToString() + "' onblur='TestSo(this,false,false);tinhthanhtien(this);' " + (!edit ? "disabled" : "") + " style='width:40px; text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='Dongia_N' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format("{0:0,0.##}", table.Rows[i]["Dongia_N"]) + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:100%; text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["chietkhau"].ToString() + "' onblur='TestSo(this,false,false);tinhthanhtien(this);' " + (!edit ? "disabled" : "") + " style='width:30px; text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='thanhtientruocthue' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format("{0:0,0.##}", table.Rows[i]["thanhtientruocthue"]) + "' onblur='tinhthanhtien(this);' " + (!edit ? "disabled" : "") + " style='width:100%;text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='vat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["vat"].ToString() + "' onblur='TestSo(this,false,false);tinhthanhtien();' " + (!edit ? "disabled" : "") + " style='width:100%;text-align:center;' /></td>");
                    html.Append("<td><input mkv='true' id='ThanhTien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format("{0:0,0.##}", table.Rows[i]["ThanhTien"]) + "' " + (!edit ? "disabled" : "") + " style='width:100%;text-align:center;'/></td>");
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
            html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus='idthuocSearch(this);' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='IdDVT_N' type='hidden' value=''/><input mkv='true' id='mkv_IdDVT_N' type='text' value='' onfocus='dvtSearch(this);' class=\"down_select\"/ style='width:50px'></td>");
            html.Append("<td><input mkv='true' id='losanxuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:70px'/></td>");
            html.Append("<td><input mkv='true' id='ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestDate(this)' style='width:80px;text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='tkno' type='hidden' value=''/><input mkv='true' id='mkv_tkno' type='text' value='' onfocus='tknoSearch(this);' class=\"down_select\"/></td>");            
            html.Append("<td><input mkv='true' id='Soluong_N' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhthanhtien(this);'  style='width:40px; text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='Dongia_N' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' style='width:100%;text-align:center;' /></td>");
            html.Append("<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhthanhtien(this);' style='width:30px;text-align:center;'/></td>");
            html.Append("<td><input mkv='true' id='thanhtientruocthue' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='tinhthanhtien(this);' style='width:100%;text-align:center;' /></td>");
            html.Append("<td><input mkv='true' id='vat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhthanhtien(this);' style='width:100%;text-align:center;' /></td>");
            html.Append("<td><input mkv='true' id='ThanhTien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:100%;text-align:center;' /></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td colspan='10' style='text-align:right; font-weight:bold; font-size:16px;'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("total") + "</td><td><input mkv='true' id='tienhang' type='text' style='width:100%;text-align:center;' disabled='true'  /></td><td><input mkv='true' id='tienvat' type='text' style='width:100%;text-align:center;' disabled='true' /></td><td><input mkv='true' id='tongtien' type='text' style='width:100%;text-align:center;' disabled='true' /></td><td></td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
    public void LuuSoCai()
    {
        //thong tin phieu nhap
        string phieunhap = "";
        string phieunhap_duoc = "";
        string ngaynhap = "";
        string sohd = "";
        //string soseri = "";
        string ngaylaphd = "";
        string tkco = "";        
        string tkthue = "";
        //string mancc = "";
        int idncc = 0;
        string diengiai = "";
        string thuesuat = "";                 
        phieunhap_duoc = Request.QueryString["maphieunhap"];
        phieunhap = Request.QueryString["ma_kt"];
        ngaynhap = Request.QueryString["ngaythang"];
        sohd = Request.QueryString["sohoadon"];
        //soseri = Request.QueryString["kyhieuhoadon"];
        ngaylaphd = Request.QueryString["ngayhoadon"];
        tkco = Request.QueryString["tkco"];
        string  tkck = Request.QueryString["tkck"];        
        tkthue = Request.QueryString["tkvat"];
        idncc = int.Parse(Request.QueryString["nhacungcapid"]);
        thuesuat = Request.QueryString["thuesuat"];
        diengiai = Request.QueryString["ghichu"];
        try
        {
            string tk_no = "";
            double tien_thue = 0;
            double tien_hang = 0;
            double tien_ck = 0;
            double tong_tien = 0;
            //string ma_cc = "";
            string sql = "select b.tkno,sum(tienthue)tienthue,sum(thanhtientruocthue)tienhang,sum(tienchietkhau)tienck ";
            sql += " from phieunhapkho a inner join chitietphieunhapkho b on a.idphieunhap=b.idphieunhap  ";
            sql += " where a.idphieunhap=" + Request.QueryString["idphieunhap"] + " and b.tkno is not null";
            sql += " group by  b.tkno";
            DataTable dt = new DataTable();
            dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["tkno"].ToString()))
                        tk_no = dt.Rows[i]["tkno"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[i]["tienthue"].ToString()))
                        tien_thue = Convert.ToDouble(dt.Rows[i]["tienthue"].ToString());
                    if (!string.IsNullOrEmpty(dt.Rows[i]["tienhang"].ToString()))
                        tien_hang = Convert.ToDouble(dt.Rows[i]["tienhang"].ToString());
                    if (!string.IsNullOrEmpty(dt.Rows[i]["tienck"].ToString()))
                        tien_ck = Convert.ToDouble(dt.Rows[i]["tienck"].ToString());
                    tong_tien = tien_hang + tien_ck;
                    string sqlexec = "Exec spPhieuNhapKhoDuoc_SoCai_Save '" + phieunhap_duoc + "','" + StaticData.CheckDate_kt(ngaynhap) + "','" + tk_no + "','" + tkck + "','" + tkco + "','" + tkthue + "',N'" + diengiai + "','" + sohd + "','" + "" + "','";
                    sqlexec += StaticData.CheckDate_kt(ngaynhap) + "'," + tien_thue + "," + tong_tien + "," + tien_ck + ",'" + idncc + "'," + i + "," + thuesuat + "";
                    bool ktsc = DataAcess.Connect.ExecSQL(sqlexec);
                }
            }
        }
        catch
        { }
    }
}


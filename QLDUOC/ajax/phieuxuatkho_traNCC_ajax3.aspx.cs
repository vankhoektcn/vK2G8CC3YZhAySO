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

public partial class phieuxuatkho_traNCC_ajax3 : System.Web.UI.Page
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
        phieuxuatkho.data("idkho", StaticData.MacDinhKhoNhapMuaID);
        phieuxuatkho.data("loaixuat", "3");
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
        chitietphieuxuatkho.data("thanhtientruocthue", (Request.QueryString["thanhtientruocthue"] != null && Request.QueryString["thanhtientruocthue"] != "" ? Request.QueryString["thanhtientruocthue"].Replace(".", "").Replace(",", ".") : ""));
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
            case "idnhacungcapSearch": idnhacungcapSearch(); break;
            case "idthuocSearch": idthuocSearch(); break;
            case "idchitietphieunhapkhoSearch": idchitietphieunhapkhoSearch(); break;
            case "dvtSearch": dvtSearch(); break;
            case "IdLoaiThuocSearch": IdLoaiThuocSearch(); break;
            case "setIdKho": setIdKho(); break;
            case "GetMaPhieuXuat": GetMaPhieuXuat(); break;
            case "PrintBienBan": PrintBienBan(); break;
            case "PrintPhieuXuatKho": PrintPhieuXuatKho(); break;
        }
    }
    private void setIdKho()
    {
        StaticData.SetDefaultIdKho(this, "idkho", "mkv_idkho", "IdLoaiThuoc", "mkv_IdLoaiThuoc");
    }
    private void idnhacungcapSearch()
    {
        string tenNhaCungCap = Request.QueryString["q"];
        string sqlSelect = "SELECT NHACUNGCAPID,TENNHACUNGCAP FROM NHACUNGCAP WHERE ISNULL(ISKT,0)=0 AND   NHACUNGCAPID IN ( SELECT DISTINCT  nhacungcapid FROM PHIEUNHAPKHO )";
        if (tenNhaCungCap != null && tenNhaCungCap != "")
        {
            sqlSelect += " AND TENNHACUNGCAP LIKE N'%" + tenNhaCungCap + "%'";
        }

        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tennhacungcap"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idthuocSearch()
    {

        string tenthuoc = Request.QueryString["q"];
        if (tenthuoc.Length < 2) return;
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string ngaythang = Request.QueryString["ngaythang"];
        string idkho = Request.QueryString["idkho"];
        string idnhacungcap = Request.QueryString["idnhacungcap"];
        string sql = @"
                select *,tonSauDuTru=nvk_ton-tonao from (
                SELECT A.IDTHUOC
                                        ,B.TENTHUOC
                                        ,B.CONGTHUC
                                        ,B.sttindm05
                                        ,B.IDDVT
                                        ,C.TENDVT
                                        ,A.IDCHITIETPHIEUNHAPKHO
                                        ,D.NGAYHOADON
                                        ,D.NGAYTHANG
                                        ,D.SOHOADON
                                        ,A.DONGIA
                                        ,DONGIA_ST=ROUND(A.DONGIA*(100.0+ISNULL(A.VAT,0))/100,0)
                                        ,A.VAT
                                        ,A.SOLUONG
                                        ,A.CHIETKHAU
                                        ,A.IDKHO_NHAP
                                        ,SLTON=A.SOLUONG-ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUNHAPKHO=A.IDCHITIETPHIEUNHAPKHO AND IDKHO_XUAT=A.IDKHO_NHAP),0)
						                ,nvk_ton=DBO.Thuoc_TonKho_new_1910(B.IDTHUOC,getdate(),A.IDKHO_NHAP) 
						                ,tonao=DBO.HS_SLYEUCAUCHUADUYET(B.IDTHUOC,A.IDKHO_NHAP,NULL)
                                        FROM CHITIETPHIEUNHAPKHO A
                                        LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
                                        LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                                        LEFT JOIN PHIEUNHAPKHO D ON A.IDPHIEUNHAP=D.IDPHIEUNHAP
                                        WHERE B.ISTHUOCBV=1";
        if (tenthuoc != null && tenthuoc != "")
            sql += " AND B.TENTHUOC LIKE N'" + tenthuoc + "%'";
        if (LoaiThuocID != null && LoaiThuocID != "")
            sql += " AND B.LOAITHUOCID=" + LoaiThuocID;
        if (idkho != null && idkho != "")
            sql += " AND D.IDKHO=" + idkho;
        if (idnhacungcap != null && idnhacungcap != "")
            sql += " AND  ISNULL(A.NHACUNGCAPID_N,  D.NHACUNGCAPID)=" + idnhacungcap;
        sql += ") as nvk";

        sql += " ORDER BY TENTHUOC";
        string TenLoaiThuoc = "Thuốc";
        if (LoaiThuocID == "2") TenLoaiThuoc = "Hoá chất";
        if (LoaiThuocID == "4") TenLoaiThuoc = "VTYT";
        string html = "";
        DataTable table = DataAcess.Connect.GetTable(sql);
        table.DefaultView.RowFilter = "SLTON>0";
        table = table.DefaultView.ToTable();
        string Para_idDuoc = StaticData.GetParameter("nvk_idKhoDuoc");
        string strTenSoTon = "SLTON";
        if (Para_idDuoc.Equals(idkho))
            strTenSoTon = "tonSauDuTru";
        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            string ngayhoadon = (h["ngayhoadon"].ToString() != "" ? h["ngayhoadon"].ToString() : h["NgayThang"].ToString());
            if (ngayhoadon != "")
                ngayhoadon = DateTime.Parse(ngayhoadon).ToString("dd/MM/yyyy");
            html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}", "<div>"
                  + "<div style=\"width:4%;height:30px;float:left;\" >" + (i + 1) + "</div>"
                 + "<div style=\"width:33%;height:30px;float:left\" >" + h["tenthuoc"] + "</div>"
                 + "<div style=\"width:7%;height:30px;float:left\" >" + h["sohoadon"] + "</div>"
                 + "<div style=\"width:20%;height:30px;float:left;text-align:center;\" >" + ngayhoadon + "</div>"
                 + "<div style=\"width:7%;height:30px;float:left;text-align:center;\" >" + h["TenDVT"] + "</div>"
                 + "<div style=\"width:8%;height:30px;float:left;text-align:center;\" >" + h["SLTON"] + "</div>"
                 + (idkho.Equals(Para_idDuoc) ? "<div style=\"width:7%;height:30px;float:left;text-align:center;\" >" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n2}", h["tonao"]) + "</div>" : "<div style=\"width:7%;height:30px;float:left;text-align:center;\" ></div>")
                 + "<div style=\"width:10%;height:30px;float:left\" >" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n3}", h["DonGia_ST"]) + "</div>"
                 + "</div>", h["idthuoc"], h["congthuc"], h["iddvt"], h["tenthuoc"], h["sttindm05"],
                 h["chietkhau"],  string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n3}",h["Dongia"]), h["IdChitietPhieuNhapkho"], h["vat"], h[strTenSoTon], h["TENDVT"],
                 h["VAT"], h["SOHOADON"], ngayhoadon, h["IDCHITIETPHIEUNHAPKHO"],
                 Environment.NewLine);

        }
        Page.Response.Clear();
        Page.Response.Write(html);
        Page.Response.End();
    }
    private void GetMaPhieuXuat()
    {
        string sqlSelect = @"SELECT MAPHIEUXUAT FROM PHIEUXUATKHO WHERE IDPHIEUXUAT=" + Request.QueryString["IDPHIEUXUAT"];
        DataTable dtMaPhieuXuat = DataAcess.Connect.GetTable(sqlSelect);
        if (dtMaPhieuXuat == null || dtMaPhieuXuat.Rows.Count == 0) return;
        Response.Write(dtMaPhieuXuat.Rows[0]["MAPHIEUXUAT"].ToString());
    }
    private void idchitietphieunhapkhoSearch()
    {
        return;

    }
    private void dvtSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select * from thuoc_donvitinh");
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
            DataTable table = Process_2608.phieuxuatkho.dtSearchByidphieuxuat(idkhoachinh);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable idnhacungcap = Thuoc_Process.nhacungcap.dtSearchBynhacungcapid("'" + table.Rows[0]["idnhacungcap"] + "'");
            html.AppendLine("<data id=\"mkv_idnhacungcap\">" + ((idnhacungcap.Rows.Count > 0) ? idnhacungcap.Rows[0]["TenNhaCungCap"] : "") + "</data>");

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
        if (StaticData.HavePermision(this, "phieuxuatkho_Search"))
        {
            DataProcess process = s_phieuxuatkho();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idphieuxuat),T.*
                   ,A.manhacungcap
                               from phieuxuatkho T
                    left join nhacungcap  A on T.idnhacungcap=A.nhacungcapid
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idphieuxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnhacungcap") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["idphieuxuat"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["maphieuxuat"].ToString() + "</td>");
                        if (table.Rows[i]["ngaythang"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaythang"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["ngaythang"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["ghichu"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["manhacungcap"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["IdLoaiThuoc"].ToString() + "</td>");
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
            process.data("idnguoixuat", SysParameter.UserLogin.UserID(this));
            process.data("loaixuat", "3");
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
                string sNgayThang = StaticData.CheckDate(NgayThang);
                DateTime saveDate = DateTime.Parse(sNgayThang);
                DateTime Now = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                if (saveDate < Now)
                    NgayThang = NgayThang += " 23:59:59";
                else
                {
                    NgayThang = NgayThang += " " + DateTime.Now.ToString("HH:mm:ss");
                }
                process.data("ngaythang", NgayThang);

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
            if (process.getData("idchitietphieuxuat") != null && process.getData("idchitietphieuxuat") != "" && process.getData("idthuoc") != null && process.getData("idthuoc") != "")
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
                if (process.getData("idthuoc") != null && process.getData("idthuoc") != "")
                {
                    bool ok = process.Insert();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("idchitietphieuxuat"));
                        return;
                    }
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void IdLoaiThuocSearch()
    {
        StaticData.IdLoaiThuocSearch(this);
    }
    public void loadTablechitietphieuxuatkho()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sl") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtientruocthue") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("VAT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoHoaDon") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayHoaDon") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SLTON") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "chitietphieuxuatkho_Add");
        bool search = StaticData.HavePermision(this, "chitietphieuxuatkho_Search");
        if (search)
        {
            DataProcess process = s_chitietphieuxuatkho();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietphieuxuat),T.*
                   ,A.TenThuoc
                   ,B.idphieunhap
                   ,C.TenDVT
                   ,d.SoHoaDon,NGAYHOADON=(CASE WHEN   D.NgayHoaDon IS NULL THEN '' ELSE CONVERT(NVARCHAR(20),D.NGAYHOADON,103) END)
                    from chitietphieuxuatkho T
                    left join thuoc  A on T.idthuoc=A.idthuoc
                    left join chitietphieunhapkho  B on T.idchitietphieunhapkho=B.idchitietphieunhapkho
                    left join Thuoc_DonViTinh  C on T.dvt=C.Id
                    left join phieunhapkho d on b.idphieunhap=d.idphieunhap
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
                    html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' id='mkv_idthuoc' type='text' value='" + table.Rows[i]["TenThuoc"].ToString() + "' onfocus='idthuocSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='dvt' type='hidden' value='" + table.Rows[i]["dvt"] + "'/><input mkv='true' id='mkv_dvt' type='text' value='" + table.Rows[i]["TenDVT"].ToString() + "' onfocus='dvtSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:50px' /></td>");
                    html.Append("<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n2}", table.Rows[i]["soluong"]) + "' onblur='TestSo(this,false,false);CheckSLTon(this);' " + (!edit ? "disabled" : "") + " style='width:50px;text-align:center' /></td>");
                    html.Append("<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n3}", table.Rows[i]["dongia"]) + "' onblur='TestSo(this,false,false);tinhthanhtien(this);' " + (!edit ? "disabled" : "") + " style='width:80px'/></td>");
                    html.Append("<td><input mkv='true' id='thanhtientruocthue' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n3}", table.Rows[i]["thanhtientruocthue"]) + "' " + (!edit ? "disabled" : "") + " style='width:100px' /></td>");
                    html.Append("<td><input mkv='true' id='VAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["VAT"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:100px;text-align:center' /></td>");
                    html.Append("<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:n3}", table.Rows[i]["thanhtien"]) + "' " + (!edit ? "disabled" : "") + " style='width:100px'/></td>");
                    html.Append("<td><input mkv='true' id='idchitietphieunhapkho' type='hidden' value='" + table.Rows[i]["idchitietphieunhapkho"] + "'/><input mkv='true' id='mkv_idchitietphieunhapkho' type='text' value='" + table.Rows[i]["SoHoaDon"].ToString() + "' onfocus='idchitietphieunhapkhoSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:80px'/></td>");
                    html.Append("<td><input mkv='false' id='NgayHoaDon' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format("{0:d}", table.Rows[i]["NgayHoaDon"]) + "' " + (!edit ? "disabled" : "") + " style='text-align:center;'/></td>");
                    html.Append("<td><input mkv='true' id='SLTON' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + "''" + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:80px;text-align:center' disabled='true'/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietphieuxuat"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus='idthuocSearch(this);' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='dvt' type='hidden' value=''/><input mkv='true' id='mkv_dvt' type='text' value='' onfocus='dvtSearch(this);' class=\"down_select\" style='width:50px' /></td>");
            html.Append("<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);CheckSLTon(this);' style='width:50px;text-align:center' /></td>");
            html.Append("<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhthanhtien(this);' style='width:80px' /></td>");
            html.Append("<td><input mkv='true' id='thanhtientruocthue' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:100px' /></td>");
            html.Append("<td><input mkv='true' id='VAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' style='width:100px;text-align:center' /></td>");
            html.Append("<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:100px' /></td>");
            html.Append("<td><input mkv='true' id='idchitietphieunhapkho' type='hidden' value=''/><input mkv='true' id='mkv_idchitietphieunhapkho' type='text' value='' onfocus='idchitietphieunhapkhoSearch(this);' class=\"down_select\"  style='width:80px'/></td>");
            html.Append("<td><input mkv='false' id='NgayHoaDon' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + "" + "' " + " style='text-align:center'/></td>");
            html.Append("<td><input mkv='true' id='SLTON' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:80px;text-align:center' disabled='true' /></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td colspan='1'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
    //______________________________________________________________________
    profess_Rpt_BienBanTraHang NXTReport = null;
    private void PrintBienBan()
    {
        string idphieuxuat = Request.QueryString["idphieuxuat"];
        NXTReport = new profess_Rpt_BienBanTraHang();
        NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        NXTReport.IdPhieuXuat = idphieuxuat;
        NXTReport.ExportToExcel();
    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
    //______________________________________________________________________
    //______________________________________________________________________
    profess_Rpt_PhieuXuatKho NXTReport_PXK = null;
    private void PrintPhieuXuatKho()
    {
        string idphieuxuat = Request.QueryString["idphieuxuat"];
        NXTReport_PXK = new profess_Rpt_PhieuXuatKho();
        NXTReport_PXK.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_PXK_AfterExportToExcel);
        NXTReport_PXK.IdPhieuXuat = idphieuxuat;
        NXTReport_PXK.ExportToExcel();
    }
    void NXTReport_PXK_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport_PXK.OutputFileName);
    }
    //______________________________________________________________________
}



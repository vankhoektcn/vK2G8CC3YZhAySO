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

public partial class phieuxuatkho_ajax : System.Web.UI.Page
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
        phieuxuatkho.data("loaixuat", Request.QueryString["loaixuat"]);
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
        phieuxuatkho.data("IdBenhNhan", Request.QueryString["IdBenhNhan"]);
        phieuxuatkho.data("IdLoaiThuoc", Request.QueryString["IdLoaiThuoc"]);
        phieuxuatkho.data("SOPHIEUYC", Request.QueryString["SOPHIEUYC"]);
        return phieuxuatkho;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savephieuxuatkho(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoaphieuxuatkho(); break;
            case "TimKiem": TimKiem(); break;
            case "idkhoSearch": idkhoSearch(); break;
            case "loaixuatSearch": loaixuatSearch(); break;
            case "IDKhachHangSearch": IDKhachHangSearch(); break;
            case "idnhacungcapSearch": idnhacungcapSearch(); break;
            case "idkho2Search": idkho2Search(); break;
            case "IdLoaiThuocSearch": IdLoaiThuocSearch(); break;
            case "setIdKho": setIdKho(); break;
            case "idthuocSearch": idthuocSearch(); break;
            case "nvk_TimKiemPhieuNhapTra": nvk_TimKiemPhieuNhapTra(); break;
            case "ChiTiet_PhieuNhapTra": nvk_ChiTiet_PhieuNhapTra(); break;
        }
    }
    private void idthuocSearch()
    {
        string tenthuoc = Request.QueryString["q"];
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string sql = "SELECT * FROM THUOC WHERE ISTHUOCBV=1";
        if (tenthuoc != null && tenthuoc != "")
            sql += " AND TENTHUOC LIKE N'" + tenthuoc + "%'";

        if (LoaiThuocID != null && LoaiThuocID != "")
            sql += " AND LOAITHUOCID=" + LoaiThuocID;
        sql += " ORDER BY TENTHUOC";

        DataTable table = DataAcess.Connect.GetTable(sql);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenThuoc"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void setIdKho()
    {
        StringBuilder html = new StringBuilder();
        html.AppendLine("<root>");
        string idkho = Request.QueryString["idkho"];
        if (idkho != null && idkho != "")
        {
            DataTable dtkho = DataAcess.Connect.GetTable("select * from khothuoc where idkho=" + idkho);
            html.AppendLine("<data id=\"idkho\">" + ((dtkho.Rows.Count > 0) ? dtkho.Rows[0]["idkho"] : "") + "</data>");
            html.AppendLine("<data id=\"mkv_idkho\">" + ((dtkho.Rows.Count > 0) ? dtkho.Rows[0]["tenkho"] + " " : "") + "</data>");
        }

        string idkho2 = Request.QueryString["idkho2"];
        if (idkho2 != null && idkho2 != "")
        {
            DataTable dtkho2 = DataAcess.Connect.GetTable("select * from khothuoc where idkho=" + idkho2);
            html.AppendLine("<data id=\"idkho2\">" + ((dtkho2.Rows.Count > 0) ? dtkho2.Rows[0]["idkho"] : "") + "</data>");
            html.AppendLine("<data id=\"mkv_idkho2\">" + ((dtkho2.Rows.Count > 0) ? dtkho2.Rows[0]["tenkho"] : "") + "</data>");
        }



        DataTable loaixuat = DataAcess.Connect.GetTable("select * from thuoc_loaixuat where idloaixuat=4");
        html.AppendLine("<data id=\"tungay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"denngay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");

        html.AppendLine("<data id=\"loaixuat\">" + ((loaixuat.Rows.Count > 0) ? loaixuat.Rows[0]["idloaixuat"] : "") + "</data>");
        html.AppendLine("<data id=\"mkv_loaixuat\">" + ((loaixuat.Rows.Count > 0) ? loaixuat.Rows[0]["tenloaixuat"] : "") + "</data>");


        string IdLoaiThuoc = Request.QueryString["LoaiThuocID"];
        if (IdLoaiThuoc != null && IdLoaiThuoc != "")
        {
            DataTable dtLoaiThuoc = DataAcess.Connect.GetTable("select * from THUOC_LOAITHUOC where LoaiThuocID=" + IdLoaiThuoc);
            html.AppendLine("<data id=\"IdLoaiThuoc\">" + ((dtLoaiThuoc.Rows.Count > 0) ? dtLoaiThuoc.Rows[0]["LoaiThuocID"] : "") + "</data>");
            html.AppendLine("<data id=\"mkv_IdLoaiThuoc\">" + ((dtLoaiThuoc.Rows.Count > 0) ? dtLoaiThuoc.Rows[0]["TenLoai"] + " " : "") + "</data>");
        }

        html.AppendLine("</root>");
        Response.Clear();
        Response.Write(html.ToString().Replace("&", "&amp;"));
    }
    private void idkhoSearch()
    {
        string tenkho = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 AND TENKHO LIKE N'" + tenkho.Trim() + "%' ORDER BY TENKHO");
        string GroupID = SysParameter.UserLogin.GroupID(this);
        if (GroupID == "8")
        {
            table.DefaultView.RowFilter = "IdKho=" + StaticData.KhoThuocBHYT;
            table = table.DefaultView.ToTable();
        }
        if (GroupID == "9")
        {
            table.DefaultView.RowFilter = "IdKho=" + StaticData.KhoThuocDV;
            table = table.DefaultView.ToTable();
        }

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
    private void loaixuatSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select * from thuoc_loaixuat");
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
    private void IDKhachHangSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT IDKHACHHANG,TENKHACHHANG FROM KHACHHANG WHERE IDKHACHHANG IN ( SELECT DISTINCT IDKHACHHANG FROM PHIEUXUATKHO )");
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
    private void idnhacungcapSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT NHACUNGCAPID,TENNHACUNGCAP FROM NHACUNGCAP WHERE NHACUNGCAPID IN ( SELECT DISTINCT IDNHACUNGCAP FROM PHIEUXUATKHO )");
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
    private void idkho2Search()
    {
        string tenkho = Request.QueryString["q"];
        string sqlSelect = @"SELECT IDKHO,TENKHO FROM KHOTHUOC 
                                WHERE ISNULL(ISKT,0)=0";
        if (tenkho != null && tenkho != "")
            sqlSelect += " AND TENKHO LIKE N'" + tenkho + "'%'";
        sqlSelect += " ORDER BY TENKHO";

        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
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
    private void IdLoaiThuocSearch()
    {
        DataTable table = Thuoc_Process.Thuoc_LoaiThuoc.dtGetAll();
        string GroupID = SysParameter.UserLogin.GroupID(this);
        if (GroupID == "8")
        {
            table.DefaultView.RowFilter = "LoaiThuocID=1";
            table = table.DefaultView.ToTable();
        }
        if (GroupID == "9")
        {
            table.DefaultView.RowFilter = "LoaiThuocID=1";
            table = table.DefaultView.ToTable();
        }

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
    private void setTimKiem()
    {
        if (StaticData.HavePermision(this, "phieuxuatkho_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = Process_2608.phieuxuatkho.dtSearchByidphieuxuat(idkhoachinh);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable idkho = Thuoc_Process.khothuoc.dtSearchByidkho("'" + table.Rows[0]["idkho"] + "'");
            html.AppendLine("<data id=\"mkv_idkho\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0][2] : "") + "</data>");
            DataTable loaixuat = DataAcess.Connect.GetTable("SELECT * FROM THUOC_LOAIXUAT WHERE IDLOAIXUAT='" + table.Rows[0]["loaixuat"] + "'");
            html.AppendLine("<data id=\"mkv_loaixuat\">" + ((loaixuat.Rows.Count > 0) ? loaixuat.Rows[0][1] : "") + "</data>");
            DataTable IDKhachHang = DataAcess.Connect.GetTable("SELECT * FROM KHACHHANG WHERE IDKHACHHANG='" + table.Rows[0]["IDKhachHang"] + "'");
            html.AppendLine("<data id=\"mkv_IDKhachHang\">" + ((IDKhachHang.Rows.Count > 0) ? IDKhachHang.Rows[0][1] : "") + "</data>");
            DataTable idnhacungcap = Thuoc_Process.nhacungcap.dtSearchBynhacungcapid("'" + table.Rows[0]["idnhacungcap"] + "'");
            html.AppendLine("<data id=\"mkv_idnhacungcap\">" + ((idnhacungcap.Rows.Count > 0) ? idnhacungcap.Rows[0][1] : "") + "</data>");
            DataTable idkho2 = Thuoc_Process.khothuoc.dtSearchByidkho("'" + table.Rows[0]["idkho2"] + "'");
            html.AppendLine("<data id=\"mkv_idkho2\">" + ((idkho2.Rows.Count > 0) ? idkho2.Rows[0][1] : "") + "</data>");
            DataTable IdBenhNhan = Thuoc_Process.benhnhan.dtSearchByidbenhnhan("'" + table.Rows[0]["IdBenhNhan"] + "'");
            html.AppendLine("<data id=\"mkv_IdBenhNhan\">" + ((IdBenhNhan.Rows.Count > 0) ? IdBenhNhan.Rows[0][1] : "") + "</data>");
            DataTable IdLoaiThuoc = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID("'" + table.Rows[0]["IdLoaiThuoc"] + "'");
            html.AppendLine("<data id=\"mkv_IdLoaiThuoc\">" + ((IdLoaiThuoc.Rows.Count > 0) ? IdLoaiThuoc.Rows[0][1] : "") + "</data>");

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
    private void Savephieuxuatkho()
    {
        try
        {
            DataProcess process = s_phieuxuatkho();
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
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "phieuxuatkho_Search"))
        {
            DataProcess process = s_phieuxuatkho();
            string tungay = Request.QueryString["tungay"];
            string denngay = Request.QueryString["denngay"];
            string IdLoaiThuoc = Request.QueryString["IdLoaiThuoc"];
            string maphieuxuat = Request.QueryString["maphieuxuat"];
            string loaixuat = Request.QueryString["loaixuat"];
            string IDKhachHang = Request.QueryString["IDKhachHang"];
            string idnhacungcap = Request.QueryString["idnhacungcap"];
            string idkho2 = Request.QueryString["idkho2"];
            string SOPHIEUYC = Request.QueryString["SOPHIEUYC"];
            string idthuoc = Request.QueryString["idthuoc"];
            string idkho = Request.QueryString["idkho"];
            process.Page = Request.QueryString["page"];
            string sql = @"select STT=row_number() over (order by T.MAPHIEUXUAT),T.*
                   ,A.TENKHO AS KHO1
                   , tenloaixuat=(CASE WHEN ISNULL(T.SOPHIEUYC,'')<>'' THEN  T.SOPHIEUYC  ELSE  B.tenloaixuat END) 
                   ,D.TenNhaCungCap
                   ,E.TENKHO AS KHO2
                  , TENLOAI=ISNULL( F.TenLoai,DBO.HS_TOP1LOAITHUOC(T.IDPHIEUXUAT))
                  , C.TENKHACHHANG
                  , SoCT= T.MAPHIEUXUAT 
                  , GhiChuCT=(CASE WHEN ISNULL(T.SOPHIEUYC,'')<>'' THEN '' ELSE  T.GhiChu END)
                               from phieuxuatkho T
                    left join khothuoc  A on T.idkho=A.idkho
                    left join Thuoc_LoaiXuat  B on T.loaixuat=B.idloaixuat
                    left join KhachHang  C on T.IDKhachHang=C.IDKhachHang
                    left join nhacungcap  D on T.idnhacungcap=D.nhacungcapid
                    left join khothuoc  E on T.idkho2=E.idkho
                   left join Thuoc_LoaiThuoc  F on T.IdLoaiThuoc=F.LoaiThuocID
                   
             where 1=1";
            if (maphieuxuat != null && maphieuxuat != "")
            {
                sql += " and t.maphieuxuat='" + maphieuxuat + "'";
            }
            if (loaixuat != null && loaixuat != "")
            {
                sql += " and t.loaixuat='" + loaixuat + "'";
            }
            if (IDKhachHang != null && IDKhachHang != "")
            {
                sql += " and t.IDKhachHang='" + IDKhachHang + "'";
            }
            if (idnhacungcap != null && idnhacungcap != "")
            {
                sql += " and t.idnhacungcap='" + idnhacungcap + "'";
            }
            if (idkho2 != null && idkho2 != "")
            {
                sql += " and t.idkho2='" + idkho2 + "'";
            }
            if (idkho != null && idkho != "")
            {
                sql += " and t.idkho='" + idkho + "'";
            }

            if (tungay != null && tungay != "")
            {
                sql += " and t.ngaythang >='" + StaticData.CheckDate(tungay) + " 00:00:00'";
            }
            if (denngay != null && denngay != "")
            {
                sql += " and t.ngaythang <='" + StaticData.CheckDate(denngay) + " 23:59:59'";
            }
            if (IdLoaiThuoc != null && IdLoaiThuoc != "")
            {
                sql += @" AND EXISTS (SELECT  A1.IDTHUOC FROM chitietphieuxuatkho A1
			             LEFT JOIN thuoc B1 ON A1.idthuoc=B1.idthuoc
                         WHERE A1.idphieuxuat=t.IDPHIEUXUAT
                              AND B1.IsThuocBV=1
				              AND B1.LoaiThuocID=" + IdLoaiThuoc + @")";

            }
            if (idthuoc != null && idthuoc != "")
            {
                sql += " AND EXISTS (SELECT IDTHUOC FROM CHITIETPHIEUXUATKHO WHERE IDPHIEUXUAT=T.IDPHIEUXUAT AND IDTHUOC=" + idthuoc + ")";
            }

            if (SOPHIEUYC != null && SOPHIEUYC != "")
                sql += " AND SOPHIEUYC='" + SOPHIEUYC + "'";
            DataTable table = process.Search(sql);
            //DataTable table = DataAcess.Connect.GetTable(sql);
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") + "</th>");

            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaixuat") + "</th>");
            if (idkho2 != "51") html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IDKhachHang") + "</th>");
            if (idkho2 != "51") html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnhacungcap") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho2") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
            html.Append("<th>Số TT</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idphieuxuat"].ToString() + "')\">");
                        html.Append("<td style='width:5%;'>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td style='width:10%;'>" + table.Rows[i]["SoCT"].ToString() + "</td>");
                        if (table.Rows[i]["ngaythang"].ToString() != "")
                        {
                            html.Append("<td style='width:15%;'>" + DateTime.Parse(table.Rows[i]["ngaythang"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "</td>");
                        }
                        else { html.Append("<td style='width:15%;'>" + table.Rows[i]["ngaythang"].ToString() + "</td>"); }

                        html.Append("<td style='width:15%;'>" + table.Rows[i]["KHO1"].ToString() + "</td>");
                        html.Append("<td style='width:10%;'>" + table.Rows[i]["tenloaixuat"].ToString() + "</td>");
                        if (idkho2 != "51") html.Append("<td style='width:10%;'>" + table.Rows[i]["TENKHACHHANG"].ToString() + "</td>");
                        if (idkho2 != "51") html.Append("<td style='width:15%;'>" + table.Rows[i]["TenNhaCungCap"].ToString() + "</td>");
                        html.Append("<td style='width:10%;'>" + table.Rows[i]["KHO2"].ToString() + "</td>");
                        html.Append("<td style='width:10%;'>" + table.Rows[i]["tenloai"].ToString() + "</td>");
                        html.Append("<td style='width:15%;'>" + table.Rows[i]["GhiChuCT"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                }
            }
            html.Append("</table>");
            html.Append(process.Paging());
            Response.Clear();
            Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }
    #region nvk tìm phếu nhập trả từ các khoa, hiện nội dung
    private void nvk_TimKiemPhieuNhapTra()
    {
        if (StaticData.HavePermision(this, "phieunhapkho_Search"))
        {
            string MaPhieuTra = Request.QueryString["SOPHIEUYC"];
            string tungay = Request.QueryString["tungay"];
            string denngay = Request.QueryString["denngay"];
            string IdLoaiThuoc = Request.QueryString["IdLoaiThuoc"];
            string loaixuat = Request.QueryString["loaixuat"];
            string idkhoTra = Request.QueryString["idkho"];
            string LoaiTraID = Request.QueryString["LoaiTraID"];
            string idkho2 = Request.QueryString["idkho2"];
            string mkv_tenthuoc = Request.QueryString["mkv_tenthuoc"];

            string sql = @"
                select distinct idphieunhap,pn.SOPHIEUYC,khotra=kt.tenkho
                    ,loaitra= case when isnull(yc.LoaiTraID,1)=1 then N'Bệnh nhân trả theo toa'
	                    when isnull(yc.LoaiTraID,1)=2 then N'Khoa Trả Dư'
	                    when isnull(yc.LoaiTraID,1)=3 then N'Khoa Chuyển Trả'
                    else '' end
                    ,doituong=dt.TenLoai,ngayduyet=convert(varchar(10),pn.ngaythang,103)+' '+ convert(varchar(5),pn.ngaythang,108),khonhap=kn.tenkho,ghichu=''
                from phieunhapkho pn inner join nvk_thuoc_phieuyctra yc on yc.SoPhieu=pn.SOPHIEUYC
                    inner join thuoc_loaithuoc dt on dt.LoaiThuocID=yc.LoaiThuocID
                    inner join khothuoc kt on kt.idkho=yc.idphongkhambenh
                    inner join khothuoc kn on kn.idkho=pn.idkho
                    left join nvk_thuoc_chitietphieuyctra ctyc on ctyc.idphieuyctra=yc.idphieuyctra
                    left join thuoc t on t.idthuoc =ctyc.idthuoc
                where sophieuyc is not null";
            if (MaPhieuTra != null && MaPhieuTra != "")
            {
                sql += " and pn.SOPHIEUYC like N'%" + MaPhieuTra + "%'";
            }
            if (LoaiTraID != null && LoaiTraID != "")
            {
                sql += " and yc.LoaiTraID='" + LoaiTraID + "'";
            }
            if (idkho2 != null && idkho2 != "")
            {
                sql += " and pn.idkho='" + idkho2 + "'";
            }
            if (idkhoTra != null && idkhoTra != "")
            {
                sql += " and kt.idkho='" + idkhoTra + "'";
            }

            if (tungay != null && tungay != "")
            {
                sql += " and pn.ngaythang >='" + StaticData.CheckDate(tungay) + " 00:00:00'";
            }
            if (denngay != null && denngay != "")
            {
                sql += " and pn.ngaythang <='" + StaticData.CheckDate(denngay) + " 23:59:58:999'";
            }
            if (IdLoaiThuoc != null && IdLoaiThuoc != "")
            {
                sql += @" and dt.LoaiThuocID=" + IdLoaiThuoc + @"";
            }
            if (mkv_tenthuoc != null && mkv_tenthuoc != "")
            {
                sql += @" and t.tenthuoc like N'%" + mkv_tenthuoc + "%' ";
            }
            DataTable table = DataAcess.Connect.GetTable(sql);
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th></th>");
            html.Append("<th>Số phiếu trả</th>");
            html.Append("<th>Kho trả</th>");
            html.Append("<th>Loại trả</th>");
            html.Append("<th>Đối tượng</th>");
            html.Append("<th>Ngày duyệt</th>");
            html.Append("<th>Kho nhập</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr >");
                        html.Append("<td>" + (i + 1) + "</td>");
                        html.Append("<td> <a  onclick=\"ViewDetail_PhieuNhapTra(this,'" + table.Rows[i]["idphieunhap"].ToString() + "')\">Chi tiết</a></td>");
                        html.Append("<td>" + table.Rows[i]["SOPHIEUYC"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["khotra"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["loaitra"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["doituong"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["ngayduyet"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["khonhap"].ToString() + "</td>");
                        //html.Append("<td>" + table.Rows[i]["ghichu"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                }
            }
            html.Append("</table>");
            Response.Clear(); Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }

    private void nvk_ChiTiet_PhieuNhapTra()
    {
        string idphieunhaptra = Request.QueryString["idphieunhap"];
        string sql = @"
            select tenthuoc,congthuc,donvitinh=dvt.tendvt,soluong=sum(ct.soluong) from phieunhapkho pn
	            inner join chitietphieunhapkho ct on ct.idphieunhap=pn.idphieunhap
	            inner join thuoc t on t.idthuoc =ct.idthuoc
	            inner join thuoc_donvitinh dvt on dvt.id=t.iddvt
            where pn.idphieunhap ='" + idphieunhaptra + @"'
                group by tenthuoc,congthuc,dvt.tendvt,nvk_UuTienYL
                ORDER BY isnull(nvk_UuTienYL,100),dvt.tendvt,tenthuoc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable_ChiTiet\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>Tên thuốc</th>");
        html.Append("<th>Hoạt chất</th>");
        html.Append("<th>Đơn vị tính</th>");
        html.Append("<th>Số lượng nhận</th>");
        html.Append("</tr>");
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html.Append("<tr style='cursor:pointer;'>");
                html.Append("<td>" + (i + 1) + "</td>");
                html.Append("<td>" + table.Rows[i]["tenthuoc"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["congthuc"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["donvitinh"].ToString() + "</td>");
                html.Append("<td style='color:Blue;font:bold'>" + table.Rows[i]["soluong"].ToString() + "</td>");
                html.Append("</tr>");
            }
        }
        html.Append("</table>");
        Response.Clear(); Response.Write(html);
    }
    #endregion
}



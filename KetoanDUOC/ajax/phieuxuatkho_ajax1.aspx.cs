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
            DataTable dtkho = DataAcess.Connect.GetTable("select * from khothuoc where idkho="+idkho);
            html.AppendLine("<data id=\"idkho\">" + ((dtkho.Rows.Count > 0) ? dtkho.Rows[0]["idkho"] : "") + "</data>");
            html.AppendLine("<data id=\"mkv_idkho\">" + ((dtkho.Rows.Count > 0) ? dtkho.Rows[0]["tenkho"] +" " : "") + "</data>");
        }

        string idkho2 = Request.QueryString["idkho2"];
        if (idkho2 != null && idkho2 != "")
        {
            DataTable dtkho2 = DataAcess.Connect.GetTable("select * from khothuoc where idkho=" + idkho);
            html.AppendLine("<data id=\"idkho2\">" + ((dtkho2.Rows.Count > 0) ? dtkho2.Rows[0]["idkho"] : "") + "</data>");
            html.AppendLine("<data id=\"mkv_idkho2\">" + ((dtkho2.Rows.Count > 0) ? dtkho2.Rows[0]["tenkho"] : "") + "</data>");
        }
        


        DataTable loaixuat = DataAcess.Connect.GetTable("select * from thuoc_loaixuat where idloaixuat=4");
        html.AppendLine("<data id=\"denngay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        
        html.AppendLine("<data id=\"loaixuat\">" + ((loaixuat.Rows.Count > 0) ? loaixuat.Rows[0]["idloaixuat"] : "") + "</data>");
        html.AppendLine("<data id=\"mkv_loaixuat\">" + ((loaixuat.Rows.Count > 0) ? loaixuat.Rows[0]["tenloaixuat"] : "") + "</data>");


        string IdLoaiThuoc = Request.QueryString["IdLoaiThuoc"];
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
            html.AppendLine("<data id=\"mkv_idkho\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0][1] : "") + "</data>");
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
            string sql = @"select STT=row_number() over (order by T.idphieuxuat),T.*
                   ,A.TENKHO AS KHO1
                   ,B.tenloaixuat
                   ,D.TenNhaCungCap
                   ,E.TENKHO AS KHO2
                  ,F.TenLoai
                   ,C.TENKHACHHANG
                               from phieuxuatkho T
                    left join khothuoc  A on T.idkho=A.idkho
                    left join Thuoc_LoaiXuat  B on T.loaixuat=B.idloaixuat
                    left join KhachHang  C on T.IDKhachHang=C.IDKhachHang
                    left join nhacungcap  D on T.idnhacungcap=D.nhacungcapid
                    left join khothuoc  E on T.idkho2=E.idkho
                   left join Thuoc_LoaiThuoc  F on T.IdLoaiThuoc=F.LoaiThuocID
                   
             where 1=1";
            if (maphieuxuat != null && maphieuxuat != "") {
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
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaixuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IDKhachHang") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnhacungcap") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho2") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idphieuxuat"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["maphieuxuat"].ToString() + "</td>");
                        if (table.Rows[i]["ngaythang"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaythang"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["ngaythang"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["ghichu"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["KHO1"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tenloaixuat"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TENKHACHHANG"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TenNhaCungCap"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["KHO2"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TenLoai"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                }
            }
            html.Append("</table>");
            html.Append(process.Paging());
            Response.Clear(); Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }
}



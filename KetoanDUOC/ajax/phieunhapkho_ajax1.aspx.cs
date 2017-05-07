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
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savephieunhapkho(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoaphieunhapkho(); break;
            case "TimKiem": TimKiem(); break;
            case "idkhoSearch": idkhoSearch(); break;
            case "nhacungcapidSearch": nhacungcapidSearch(); break;
            case "idthuocSearch": idthuocSearch(); break;
        }
    }

    private void idkhoSearch()
    {
        string tenkho = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 AND TENKHO LIKE N'" + tenkho + "%' ORDER BY TENKHO");
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
    private void idthuocSearch()
    {
        string tenthuoc = Request.QueryString["q"];
        string sql = "SELECT * FROM THUOC WHERE ISTHUOCBV=1";
        if (tenthuoc != null && tenthuoc != "")
            sql += " AND TENTHUOC LIKE N'" + tenthuoc + "%'";
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
            html.AppendLine("<data id=\"mkv_idkho\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0][1] : "") + "</data>");
            DataTable nhacungcapid = Thuoc_Process.nhacungcap.dtSearchBynhacungcapid("'" + table.Rows[0]["nhacungcapid"] + "'");
            html.AppendLine("<data id=\"mkv_nhacungcapid\">" + ((nhacungcapid.Rows.Count > 0) ? nhacungcapid.Rows[0]["tennhacungcap"] : "") + "</data>");

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
    private void Savephieunhapkho()
    {
        try
        {
            DataProcess process = s_phieunhapkho();
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
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "phieunhapkho_Search"))
        {


            string maphieunhap = Request.QueryString["maphieunhap"];
            string ngaythang = Request.QueryString["ngaythang"];
            string idkho = Request.QueryString["idkho"];
            string nhacungcapid = Request.QueryString["nhacungcapid"];
            string tennguoigiao = Request.QueryString["tennguoigiao"];
            string kyhieuhoadon = Request.QueryString["kyhieuhoadon"];
            string sohoadon = Request.QueryString["sohoadon"];
            string ngayhoadon = Request.QueryString["ngayhoadon"];
            string tkno = Request.QueryString["tkno"];
            string tkco = Request.QueryString["tkco"];
            string tkvat = Request.QueryString["tkvat"];
            string nhapcho = Request.QueryString["nhapcho"];
            string ghichu = Request.QueryString["ghichu"];
            string vat = Request.QueryString["vat"];
            string thanhtien = Request.QueryString["thanhtien"];
            string idkhachhang = Request.QueryString["idkhachhang"];
            string idthuoc = Request.QueryString["idthuoc"];
            string idloainhap = "1";
            string IsBHYT = Request.QueryString["IsBHYT"];
            string tienhang = Request.QueryString["tienhang"];
            string tienvat = Request.QueryString["tienvat"];
            string tongtien = Request.QueryString["tongtien"];
            string ptn = Request.QueryString["ptn"];
            string TrangThai = Request.QueryString["TrangThai"];
            string IdPhieuXuat = Request.QueryString["IdPhieuXuat"];
            string nhacungcapidbk = Request.QueryString["nhacungcapidbk"];
            string IsDaHuy = Request.QueryString["IsDaHuy"];
            string LANSUA = Request.QueryString["LANSUA"];
            string NGAYSUA = Request.QueryString["NGAYSUA"];
            string NGUOISUA = Request.QueryString["NGUOISUA"];
            string TuNgay = Request.QueryString["TuNgay"];

            string sqlSelect = @"select STT=row_number() over (order by T.idphieunhap),T.*
                   ,A.makho
                   ,B.TenNhaCungCap
                   ,C.tennguoidung
                   ,ThanhTienNhap=(SELECT SUM(THANHTIEN) FROM CHITIETPHIEUNHAPKHO DT WHERE DT.IDPHIEUNHAP=T.IDPHIEUNHAP)
                    from phieunhapkho T
                    left join khothuoc  A on T.idkho=A.idkho
                    left join nhacungcap  B on T.nhacungcapid=B.nhacungcapid
                    left join nguoidung  C on T.idnguoinhap=C.idnguoidung
                    where 1=1";
            if (idkho != null && idkho != "")
                sqlSelect += " and T.IDKHO=" + idkho;
            if (nhacungcapid != null && nhacungcapid != "")
                sqlSelect += " and T.nhacungcapid=" + nhacungcapid;

            if (ngaythang != null && ngaythang != "")
            {
                ngaythang = StaticData.CheckDate(ngaythang) + " 23:59:59";
                sqlSelect += " and T.NGAYHOADON<='" + ngaythang + "'";
            }
            if (TuNgay != null && TuNgay != "")
            {
                string[] arrTuNgay = TuNgay.Split(',');
                if (arrTuNgay.Length > 1) TuNgay = arrTuNgay[0];
                TuNgay = StaticData.CheckDate(TuNgay); ;
                sqlSelect += " and T.NGAYHOADON>='" + TuNgay + "'";
            }

            if (maphieunhap != null && maphieunhap != "")
                sqlSelect += " and T.maphieunhap like N'%" + maphieunhap + "%'";

            if (sohoadon != null && sohoadon != "")
                sqlSelect += " and T.sohoadon like N'%" + sohoadon + "%'";


            if (ngayhoadon != null && ngayhoadon != "")
            {
                ngayhoadon = StaticData.CheckDate(ngayhoadon);
                sqlSelect += " and T.ngayhoadon>='" + ngayhoadon + "'";
                sqlSelect += " and T.ngayhoadon<='" + ngayhoadon + " 23:59:59'";

            }
            if (idloainhap != null && idloainhap != "")
                sqlSelect += " AND T.IDLOAINHAP=" + idloainhap;

            if (idthuoc != null && idthuoc != "")
            {
                sqlSelect += " AND EXISTS (SELECT IDTHUOC FROM CHITIETPHIEUNHAPKHO WHERE IDPHIEUNHAP=T.IDPHIEUNHAP AND IDTHUOC=" + idthuoc + ")";
            }

            DataProcess process = s_phieunhapkho();
            process.Page = Request.QueryString["page"];
            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            StringBuilder html = new StringBuilder();
            html.Append(process.Paging());
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieunhap") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nhacungcapid") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tennguoigiao") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sohoadon") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhoadon") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnguoinhap") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idphieunhap"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["maphieunhap"].ToString() + "</td>");
                        if (table.Rows[i]["ngaythang"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaythang"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["ngaythang"].ToString() + "</td>"); }
                        html.Append("<td  align='LEFT' >" + table.Rows[i]["TenNhaCungCap"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tennguoigiao"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["sohoadon"].ToString() + "</td>");
                        if (table.Rows[i]["ngayhoadon"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngayhoadon"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["ngayhoadon"].ToString() + "</td>"); }
                        html.Append("<td>" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["ThanhTienNhap"]) + "</td>");
                        html.Append("<td>" + table.Rows[i]["tennguoidung"].ToString() + "</td>");
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



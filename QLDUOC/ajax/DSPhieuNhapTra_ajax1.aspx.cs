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

public partial class DSPhieuNhapTra_ajax : System.Web.UI.Page
{
    protected DataProcess s_phieunhapkho()
    {
        DataProcess phieunhapkho = new DataProcess("phieunhapkho");
        phieunhapkho.data("idphieunhap", Request.QueryString["idkhoachinh"]);
        phieunhapkho.data("maphieunhap", Request.QueryString["maphieunhap"]);
        phieunhapkho.data("ngaythang", Request.QueryString["ngaythang"]);
        phieunhapkho.data("idkho", Request.QueryString["idkho"]);
        phieunhapkho.data("idloainhap", "1");
        phieunhapkho.data("TrangThai", Request.QueryString["TrangThai"]);
        phieunhapkho.data("IdPhieuXuat", Request.QueryString["IdPhieuXuat"]);
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
            case "loaithuocidSearch": loaithuocidSearch(); break;

        }
    }
    private void idkhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }


    private void loaithuocidSearch()
    {
        string sqlSelect = @"SELECT * FROM THUOC_LOAITHUOC WHERE TENLOAI LIKE N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
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
            string tungay = Request.QueryString["tungay"];
            string denngay = Request.QueryString["denngay"];
            string idkho = Request.QueryString["idkho"];
            if (idkho == null || idkho == "")
                idkho = StaticData.MacDinhKhoNhapMuaID;
            string IdPhieuXuat = Request.QueryString["IdPhieuXuat"];
            string loaithuocid = Request.QueryString["loaithuocid"];
            string sophieuyc = Request.QueryString["SOPHIEUYC"];
            string sqlSelect = @"select STT=row_number() over (order by T.idphieunhap),T.*
                   ,A.makho
                   ,C.TENNGUOIDUNG
                   ,ThanhTienNhap=(SELECT SUM(THANHTIEN) FROM CHITIETPHIEUNHAPKHO DT WHERE DT.IDPHIEUNHAP=T.IDPHIEUNHAP)
                    from phieunhapkho T
                    left join khothuoc  A on T.idkho=A.idkho
                    left join nguoidung  C on T.idnguoinhap=C.idnguoidung
                    where 1=1  AND ISNULL(SOPHIEUYC,'')<> ''";
            if (idkho != null && idkho != "")
                sqlSelect += " and T.IDKHO=" + idkho;
            if (tungay != null && tungay != "")
            {
                tungay = StaticData.CheckDate(tungay);
                sqlSelect += " AND T.NGAYTHANG >='" + tungay + "'";
            }
            if (denngay != null && denngay != "")
            {
                denngay = StaticData.CheckDate(denngay) + " 23:59:59";
                sqlSelect += " AND T.NGAYTHANG <='" + denngay + "'";
            }
            if (maphieunhap != null && maphieunhap != "")
                sqlSelect += " and T.maphieunhap like N'%" + maphieunhap + "%'";

            if (loaithuocid != null && loaithuocid != "")
            {
                sqlSelect += @" AND EXISTS (SELECT A1.IDTHUOC FROM CHITIETPHIEUNHAPKHO A1
											INNER JOIN THUOC B1 ON A1.IDTHUOC=B1.IDTHUOC
									 WHERE IDPHIEUNHAP=T.IDPHIEUNHAP AND B1.LOAITHUOCID=" + loaithuocid + ")";
            }
            if (sophieuyc != null && sophieuyc != "")
            {
                sqlSelect += " AND T.SOPHIEUYC='" + sophieuyc + "'";
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
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sophieuyc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnguoinhap") + "</th>");
            html.Append("<th>Thao tác ? </th>");
            html.Append("</tr>");
            double tong_thanhtien = 0;
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        tong_thanhtien += StaticData.ParseFloat(table.Rows[i]["THANHTIENNHAP"]);
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idphieunhap"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["maphieunhap"].ToString() + "</td>");
                        if (table.Rows[i]["ngaythang"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaythang"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["ngaythang"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["sophieuyc"].ToString() + "</td>");
                        html.Append("<td style='text-align:right'>" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["ThanhTienNhap"]) + "</td>");
                        html.Append("<td>" + table.Rows[i]["tennguoidung"].ToString() + "</td>");
                        html.Append("<td><a onclick=\"javascript:XemChiTiet(" + table.Rows[i]["idphieunhap"].ToString() + ");\">Chi tiết</a></td>");
                        html.Append("</tr>");
                    }
                }
            }
            html.Append("<tr><td></td><td colspan='3' style='text-align:right;'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("total") + "</td><td style='text-align:right'>" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:0,0.###}", tong_thanhtien) + "</td><td></td><td></td></tr>");
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



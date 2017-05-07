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
using System.Globalization;
public partial class chitietphieunhapkho_ajax : System.Web.UI.Page
{
    protected DataProcess s_chitietphieunhapkho()
    {
        DataProcess chitietphieunhapkho = new DataProcess("chitietphieunhapkho");
        chitietphieunhapkho.data("idchitietphieunhapkho", Request.QueryString["idkhoachinh"]);
        chitietphieunhapkho.data("idphieunhap", Request.QueryString["idphieunhap"]);
        chitietphieunhapkho.data("idthuoc", Request.QueryString["idthuoc"]);
        chitietphieunhapkho.data("soluong", Request.QueryString["soluong"]);
        chitietphieunhapkho.data("dongia", Request.QueryString["dongia"]);
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
        chitietphieunhapkho.data("dvt", Request.QueryString["dvt"]);
        chitietphieunhapkho.data("thanhtien", Request.QueryString["thanhtien"]);
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
        chitietphieunhapkho.data("IDKHO_NHAP", "4");
        chitietphieunhapkho.data("NGAYTHANG_NHAP", Request.QueryString["NGAYTHANG_NHAP"]);
        chitietphieunhapkho.data("IDLOAINHAP_NHAP", "1");
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
        return chitietphieunhapkho;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savechitietphieunhapkho(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoachitietphieunhapkho(); break;
            case "TimKiem": TimKiem(); break;
            case "idphieunhapSearch": idphieunhapSearch(); break;
            case "idthuocSearch": idthuocSearch(); break;
            case "dvtSearch": dvtSearch(); break;
            case "IdLoaiThuocSearch": IdLoaiThuocSearch(); break;
        }
    }
    private void idphieunhapSearch()
    {
        string sohoadon = Request.QueryString["q"];
        DataTable table = Thuoc_Process.phieunhapkho.dtSearchBysohoadon(sohoadon.ToString());
        table.DefaultView.Sort = "sohoadon";
        table = table.DefaultView.ToTable();
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["SoHoaDon"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idthuocSearch()
    {
        string TenThuoc = Request.QueryString["q"].ToString();
        string LoaiThuocID = Request.QueryString["IdLoaiThuoc"].ToString();
        string sqlSelectThuoc = "SELECT * FROM THUOC WHERE ISTHUOCBV=1 AND TENTHUOC LIKE N'" + TenThuoc + "%'";
        if (LoaiThuocID != "")
            sqlSelectThuoc += " AND LoaiThuocID=" + LoaiThuocID;
        sqlSelectThuoc += " ORDER BY TENTHUOC";

        DataTable table = DataAcess.Connect.GetTable(sqlSelectThuoc);
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
    private void dvtSearch()
    {
        DataTable table = Process_2608.Thuoc_DonViTinh.dtGetAll();
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
        if (StaticData.HavePermision(this, "chitietphieunhapkho_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = Thuoc_Process.chitietphieunhapkho.dtSearchByidchitietphieunhapkho(idkhoachinh);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable idphieunhap = Thuoc_Process.phieunhapkho.dtSearchByidphieunhap("'" + table.Rows[0]["idphieunhap"] + "'");
            html.AppendLine("<data id=\"mkv_idphieunhap\">" + ((idphieunhap.Rows.Count > 0) ? idphieunhap.Rows[0]["Sohoadon"] : "") + "</data>");
            DataTable idthuoc = Thuoc_Process.thuoc.dtSearchByidthuoc("'" + table.Rows[0]["idthuoc"] + "'");
            html.AppendLine("<data id=\"mkv_idthuoc\">" + ((idthuoc.Rows.Count > 0) ? idthuoc.Rows[0][1] : "") + "</data>");
            DataTable dvt = Process_2608.Thuoc_DonViTinh.dtSearchById("'" + table.Rows[0]["dvt"] + "'");
            html.AppendLine("<data id=\"mkv_dvt\">" + ((dvt.Rows.Count > 0) ? dvt.Rows[0][1] : "") + "</data>");
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
    private void Savechitietphieunhapkho()
    {
        try
        {
            DataProcess process = s_chitietphieunhapkho();
            if (process.getData("idchitietphieunhapkho") != null && process.getData("idchitietphieunhapkho") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
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
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "chitietphieunhapkho_Search"))
        {
            string idkho_nhap = Request.QueryString["idkho_nhap"];
            string tungay = Request.QueryString["tungay"];
            string denngay = Request.QueryString["denngay"];
            string sohoadon = Request.QueryString["sohoadon"];
            string LoaiThuocID = Request.QueryString["loaithuocid"];
            string idthuoc = Request.QueryString["idthuoc"];
            string idphieunhap = Request.QueryString["idphieunhap"];
            string sqlSelect = @"select STT=row_number() over (order by T.idchitietphieunhapkho),T.*
                   ,B.TenThuoc
                   ,C.TenDVT
                   ,D.MaLoai
                   ,E.TenKho as KhoNhap
                   ,F.TenNhaCungCap
                   ,G.tenloainhap,A.SOHOADON,A.NGAYTHANG
                   ,DonGiaView=DonGia*(100.0+isnull(T.VAT,0))/100
                    from chitietphieunhapkho T
                    left join phieunhapkho  A on T.idphieunhap=A.idphieunhap
                    left join thuoc  B on T.idthuoc=B.idthuoc
                    left join Thuoc_DonViTinh  C on T.dvt=C.Id
                    left join Thuoc_LoaiThuoc  D on T.IdLoaiThuoc=D.LoaiThuocID
                    left join KHOTHUOC E ON T.IDKHO_NHAP=E.IDKHO
                    LEFT JOIN NHACUNGCAP F ON A.NHACUNGCAPID=F.NHACUNGCAPID
                    LEFT JOIN THUOC_LOAINHAP G ON T.IDLOAINHAP_NHAP=G.IDLOAINHAP
                where A.IDLOAINHAP=1 AND A.IDKHO=4 ";
            if(sohoadon!=null &&sohoadon!="")
                sqlSelect+="    AND A.sohoadon LIKE N'%" + sohoadon + "%'";
            if (idphieunhap != null && idphieunhap != "")
                sqlSelect += "    AND A.idphieunhap =" + idphieunhap;

            if (LoaiThuocID != null && LoaiThuocID != "")
                sqlSelect += " AND B.LOAITHUOCID=" + LoaiThuocID;
            if (idthuoc != null && idthuoc != "")
                sqlSelect += " AND T.IDTHUOC=" + idthuoc;
            if (tungay != null && tungay != ""&&tungay.Length>=10)
            {
                if (tungay.Split(',').Length > 1) tungay = tungay.Split(',')[0];
                tungay = StaticData.CheckDate(tungay);
                sqlSelect += " AND A.NGAYTHANG>='" + tungay + "'";
            }
            if (denngay != null && denngay != "" && denngay.Length>=10)
            {
                if (denngay.Split(',').Length > 1) denngay = denngay.Split(',')[0];
                denngay = StaticData.CheckDate(denngay) + " 23:59:59";
                sqlSelect += " AND A.NGAYTHANG<='" + denngay + "'";
            }

            DataProcess process = s_chitietphieunhapkho();
            process.Page = Request.QueryString["page"];
            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            StringBuilder html = new StringBuilder();
            html.Append(process.Paging());
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaPhieuNhap") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày CT") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("losanxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhethan") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenNhaCungCap") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idchitietphieunhapkho"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["sohoadon"].ToString() + "</td>");
                        string NGAYTHANG = table.Rows[i]["NGAYTHANG"].ToString();
                        if (NGAYTHANG != "")
                        {
                            html.Append("<td>" + DateTime.Parse(NGAYTHANG).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["NGAYTHANG_NHAP"].ToString() + "</td>"); }

                        html.Append("<td>" + table.Rows[i]["TenThuoc"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TenDVT"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["losanxuat"].ToString() + "</td>");
                        if (table.Rows[i]["ngayhethan"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngayhethan"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["ngayhethan"].ToString() + "</td>"); }

                        html.Append("<td>" + table.Rows[i]["soluong"].ToString() + "</td>");
                        html.Append("<td>" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["DonGiaView"]) + "</td>");
                        html.Append("<td>" + string.Format(new CultureInfo("de-DE"), "{0:0,0.##}", table.Rows[i]["thanhtien"]) + "</td>");
                        html.Append("<td>" + table.Rows[i]["TenNhaCungCap"].ToString() + "</td>");
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



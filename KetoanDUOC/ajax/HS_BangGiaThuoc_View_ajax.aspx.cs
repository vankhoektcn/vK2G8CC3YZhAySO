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

public partial class HS_BangGiaThuoc_View_ajax : System.Web.UI.Page
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
            case "setIdKho": setIdKho(); break;
            case "idkhoSearch": idkhoSearch(); break;
            case "XuatExcel": XuatExcel(); break;
        }
    }
    private void idkhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void idphieunhapSearch()
    {
        string MaPhieuNhap = Request.QueryString["q"];
        DataTable table = Thuoc_Process.phieunhapkho.dtSearchBymaphieunhap(MaPhieuNhap.ToString());
        table.DefaultView.Sort = "MaPhieuNhap";
        table = table.DefaultView.ToTable();
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["MaPhieuNhap"].ToString() + "|" + table.Rows[i][0].ToString());

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
            html.AppendLine("<data id=\"mkv_idphieunhap\">" + ((idphieunhap.Rows.Count > 0) ? idphieunhap.Rows[0]["MaPhieuNhap"] : "") + "</data>");
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
            string IDKHO_NHAP = Request.QueryString["IDKHO_NHAP"];
            string tungay = Request.QueryString["tungay"];
            string denngay = Request.QueryString["denngay"];
            string LoaiThuocID = Request.QueryString["IdLoaiThuoc"];
            string idthuoc = Request.QueryString["idthuoc"];
            string[] arrDenNgay = denngay.Split(',');
            if (arrDenNgay.Length > 1)
                denngay = arrDenNgay[0];

            string sqlSelect = @"select STT=row_number() over (order by TENTHUOC),T.IdChiTietPhieuNhapKho,T.LOSANXUAT,T.NGAYHETHAN
                   ,B.TenThuoc
                   ,C.TenDVT
                   ,D.MaLoai
                   ,E.TenKho as KhoNhap
                   ,F.TenNhaCungCap
                   ,G.tenloainhap,A.MaPhieuNhap,A.NgayThang
                   ,DonGiaView=ROUND( DonGia*(100.0+isnull(T.VAT,0))/100,0)
                   ,SLTon1=SUM(DBO.Thuoc_SoLuongXuat_new(T.IDCHITIETPHIEUNHAPKHO))
                    ,A.SoHoaDon
                    ,A.NgayHoaDon
                    ,T.SOLUONG
                    from chitietphieunhapkho T
                    left join phieunhapkho  A on T.idphieunhap=A.idphieunhap
                    left join thuoc  B on T.idthuoc=B.idthuoc
                    left join Thuoc_DonViTinh  C on T.dvt=C.Id
                    left join Thuoc_LoaiThuoc  D on T.IdLoaiThuoc=D.LoaiThuocID
                    left join KHOTHUOC E ON T.IDKHO_NHAP=E.IDKHO
                    LEFT JOIN NHACUNGCAP F ON A.NHACUNGCAPID=F.NHACUNGCAPID
                    LEFT JOIN THUOC_LOAINHAP G ON T.IDLOAINHAP_NHAP=G.IDLOAINHAP
                where 1=1 AND B.ISTHUOCBV=1" + "\r\n";

            if (IDKHO_NHAP != null && IDKHO_NHAP != "")
                sqlSelect += " AND T.IDKHO_NHAP=" + IDKHO_NHAP + "\r\n";
            if (LoaiThuocID != null && LoaiThuocID != "")
                sqlSelect += " AND B.LOAITHUOCID=" + LoaiThuocID;
            if (idthuoc != null && idthuoc != "")
                sqlSelect += " AND T.IDTHUOC=" + idthuoc;
            if (denngay != null && denngay != "" && denngay.Length >= 10)
            {
                denngay = StaticData.CheckDate(denngay) + " 23:59:59";
                sqlSelect += " AND A.NgayThang<='" + denngay + "'";
            }

            if (tungay != null && tungay != "" && tungay.Length >= 10)
            {
                tungay = StaticData.CheckDate(tungay);
                sqlSelect += " AND A.NgayThang>='" + tungay + "'";
            }
            sqlSelect += @" GROUP BY T.LOSANXUAT,T.NGAYHETHAN
                   ,B.TenThuoc
                   ,C.TenDVT
                   ,D.MaLoai
                   ,E.TenKho 
                   ,F.TenNhaCungCap
                   ,G.tenloainhap,A.MaPhieuNhap,A.NgayThang
                   ,ROUND( DonGia*(100.0+isnull(T.VAT,0))/100,0)
                   ,SOHOADON
                    ,NGAYHOADON
                    ,T.IDCHITIETPHIEUNHAPKHO
                    ,T.SOLUONG";

            DataProcess process = s_chitietphieunhapkho();
            process.Page = Request.QueryString["page"];
            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            table.DefaultView.RowFilter = " SLTon1 > 0 ";
            table = table.DefaultView.ToTable();
            StringBuilder html = new StringBuilder();
            html.Append(process.Paging());
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaPhieuNhap") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày nhập") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("losanxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhethan") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SLTon") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Loại nhập") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SOHD") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYHD") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idchitietphieunhapkho"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["MaPhieuNhap"].ToString() + "</td>");
                        string NgayThang = table.Rows[i]["NgayThang"].ToString();
                        if (NgayThang != "")
                        {
                            html.Append("<td>" + DateTime.Parse(NgayThang).ToString("dd/MM/yyyy") + "</td>");
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

                        html.Append("<td>" + table.Rows[i]["SoLuong"].ToString() + "</td>");
                        html.Append("<td stlye='text-align:right;'>" + string.Format(new System.Globalization.CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["DonGiaView"]) + "</td>");
                        html.Append("<td>" + table.Rows[i]["SLTon1"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tenloainhap"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["sohoadon"].ToString() + "</td>");
                        string NGAYHD = table.Rows[i]["NGAYHOADON"].ToString();
                        if (NGAYHD != "")
                        {
                            html.Append("<td style='text-align:center;'>" + DateTime.Parse(NGAYHD).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td style='text-align:center;'>" + table.Rows[i]["NGAYHOADON"].ToString() + "</td>"); }
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
    }//end void
    private void setIdKho()
    {
        StaticData.SetDefaultIdKho(this, "IDKHO_NHAP", "mkv_IDKHO_NHAP", "IdLoaiThuoc", "mkv_IdLoaiThuoc");
    }
    profess_Rpt_BangGiaThuoc NXTReport = null;
    private void XuatExcel()
    {
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string tungay = Request.QueryString["tungay"];
        string denngay = Request.QueryString["denngay"];
        string IdKho = Request.QueryString["IdKho"];
        string TenKho = Request.QueryString["TenKho"];

        NXTReport = new profess_Rpt_BangGiaThuoc();
        NXTReport.LoaiThuocID = LoaiThuocID;
        NXTReport.IdKho = IdKho;
        NXTReport.TenKho = TenKho;
        NXTReport.FromDate = StaticData.CheckDate(tungay);
        NXTReport.ToDate = StaticData.CheckDate(denngay)+" 23:59:59";
        NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        NXTReport.ExportToExcel();

    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
}//end class



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
        chitietphieunhapkho.data("dongiaBH", Request.QueryString["dongiaBH"]);
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
        chitietphieunhapkho.data("ISBHYT", Request.QueryString["ISBHYT"]);
        return chitietphieunhapkho;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "setTimKiem": setTimKiem(); break;
            case "TimKiem": TimKiem(); break;
            case "idphieunhapSearch": idphieunhapSearch(); break;
            case "idthuocSearch": idthuocSearch(); break;
            case "dvtSearch": dvtSearch(); break;
            case "IdLoaiThuocSearch": IdLoaiThuocSearch(); break;
            case "setIdKho": setIdKho(); break;
            case "idkhoSearch": idkhoSearch(); break;
            case "XuatExcel": XuatExcel(); break;
            case "luuTableBangGia": luuTableBangGia(); break;
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
    private void luuTableBangGia()
    {
        try
        {
            string idthuoc = Request.QueryString["idkhoachinh"];
            string dongia = Request.QueryString["dongia"];
            string ISBHYT = StaticData.IsCheck(Request.QueryString["ISBHYT"]) ?"1":"0";
            if (!string.IsNullOrEmpty(idthuoc) && !string.IsNullOrEmpty(dongia))
            {
                dongia = dongia.Replace(".", "").Replace(",", ".");
                string losanxuat = Request.QueryString["losanxuat"];
                string ngayhethan = Request.QueryString["ngayhethan"];
                string IDKHO_NHAP = Request.QueryString["IDKHO_NHAP"];
                string sql = "update chitietphieunhapkho set dongia ='" + dongia + "',ISBHYT=" + ISBHYT+ " where idthuoc ='" + idthuoc + "' and IDKHO_NHAP='" + IDKHO_NHAP + "' and losanxuat ='" + losanxuat + "' and convert(varchar(10),ngayhethan,103)='" + ngayhethan + "' ";
                bool ok = DataAcess.Connect.ExecSQL(sql);
                if (ok)
                {
                    Response.Clear(); Response.Write(idthuoc);
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
            string denngay = Request.QueryString["denngay"];
            string tungay = Request.QueryString["tungay"];
            string LoaiThuocID = Request.QueryString["IdLoaiThuoc"];
            string idthuoc = Request.QueryString["idthuoc"];
            string[] arrDenNgay = denngay.Split(',');
            if (arrDenNgay.Length > 1)
                denngay = arrDenNgay[0];


            string sqlGetDeclareDate = @"SELECT DECLAREDATE FROM zKhoDeclared WHERE IDKHO=" + IDKHO_NHAP;
            DataTable dtDeclareDate = DataAcess.Connect.GetTable(sqlGetDeclareDate);
            string DeclateDate = "2013-07-29 13:30:00";
            if (dtDeclareDate != null && dtDeclareDate.Rows.Count > 0)
                DeclateDate = dtDeclareDate.Rows[0][0].ToString();



            string sqlSelect = @"select DISTINCT T.LOSANXUAT,T.NGAYHETHAN
                   ,B.TenThuoc,ngayhethan103=convert(varchar(10),T.ngayhethan,103)
                   ,C.TenDVT
					,DonGia=ROUND(T.DonGia,2),T.VAT
                   ,DonGiaView=ROUND( DonGia*(100.0+isnull(T.VAT,0))/100,2)
                   ,SLTon=SUM(DBO.Thuoc_SoLuongXuat_new(T.IDCHITIETPHIEUNHAPKHO))
                   ,T.ISBHYT,B.idthuoc,T.IDKHO_NHAP
                    from chitietphieunhapkho T
                    left join phieunhapkho  A on T.idphieunhap=A.idphieunhap
                    left join thuoc  B on T.idthuoc=B.idthuoc
                    left join Thuoc_DonViTinh  C on b.iddvt=C.Id
                where 1=1 AND B.ISTHUOCBV=1 AND T.NGAYTHANG_NHAP>='" + DeclateDate + "' " + "\r\n";

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
            sqlSelect += @" GROUP BY T.LOSANXUAT,T.NGAYHETHAN,T.ISBHYT
                   ,B.TenThuoc,B.idthuoc
                   ,C.TenDVT,T.IDKHO_NHAP
				    ,ROUND(T.DonGia,2),T.VAT
                   ,ROUND( DonGia*(100.0+isnull(T.VAT,0))/100,2)";
            DataProcess process = s_chitietphieunhapkho();
            process.Page = Request.QueryString["page"];
            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            table.DefaultView.RowFilter = " SLTon > 0 ";
            table.DefaultView.Sort = "TENTHUOC";
            table = table.DefaultView.ToTable();
            StringBuilder html = new StringBuilder();
            html.Append(process.Paging());
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");

            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("losanxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhethan") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("?BHYT") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL.Tồn") + "</th>");
            html.Append("<th></th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        //html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idchitietphieunhapkho"].ToString() + "')\">");
                        html.Append("<td>" + (i + 1).ToString() + "</td>");


                        html.Append("<td style='text-align:left'>" + table.Rows[i]["TenThuoc"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TenDVT"].ToString() + "</td>");
                        html.Append("<td><input type='text' mkv='true' id='losanxuat' disabled style='text-align:center;' value='" + table.Rows[i]["losanxuat"].ToString() + "' /></td>");
                        html.Append("<td><input type='text' mkv='true' id='ngayhethan' disabled style='text-align:center;' value='" + table.Rows[i]["ngayhethan103"].ToString() + "' /></td>");
                        html.Append(@"<td>
                            <input type='text' mkv='true' id='dongia' onblur='TinhDonGiaSauVAT(this);'  style='text-align:right;width:100px;' value='" + StaticData.FormatNumberOption(table.Rows[i]["DonGia"], ".", ",", true) + @"' />
                            <input type='text' mkv='true' id='VAT' disabled style='text-align:right;width:40px;' value='" + table.Rows[i]["VAT"] + @"' />
                            <input type='text' id='DonGiaView' onblur='TinhDonGiaTruocVAT(this);' style='text-align:right;width:100px;' value='" + StaticData.FormatNumberOption(table.Rows[i]["DonGiaView"],".",",",true) + @"' />
                        </td>");
                        html.Append("<td><input type='checkbox' mkv='true' id='ISBHYT' " + (StaticData.IsCheck(table.Rows[i]["ISBHYT"].ToString()) ? "checked" : "") + "/></td>");
                        html.Append("<td>" + table.Rows[i]["SLTon"].ToString() + "</td>");
                        html.Append(@"<td>
                            <input type='hidden' mkv='true' id='idkhoachinh' value='" + table.Rows[i]["idthuoc"].ToString() + @"' />
                            <input type='hidden' mkv='true' id='IDKHO_NHAP' value='" + table.Rows[i]["IDKHO_NHAP"].ToString() + @"' />
                        </td>");
                        html.Append("</tr>");
                    }
                }
            }
            html.Append("<tr><td></td><td colspan='8'></td></tr>");
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
        NXTReport.ToDate = StaticData.CheckDate(denngay) + " 23:59:59";
        NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        NXTReport.ExportToExcel();

    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
}//end class



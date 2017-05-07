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
using System.Collections.Generic;
using System.Globalization;
public partial class HS_TONKHO_View_ajax : System.Web.UI.Page
{
    protected DataProcess s_HS_TONKHO_View()
    {
        DataProcess HS_TONKHO_View = new DataProcess("HS_TONKHO_View");
        HS_TONKHO_View.data("IdTonKho", Request.QueryString["idkhoachinh"]);
        HS_TONKHO_View.data("IdKho", Request.QueryString["IdKho"]);
        HS_TONKHO_View.data("TuNgay", Request.QueryString["TuNgay"]);
        HS_TONKHO_View.data("DenNgay", Request.QueryString["DenNgay"]);
        HS_TONKHO_View.data("LoaiThuocID", Request.QueryString["LoaiThuocID"]);
        HS_TONKHO_View.data("IdThuoc", Request.QueryString["IdThuoc"]);
        HS_TONKHO_View.data("TenThuoc", Request.QueryString["TenThuoc"]);
        HS_TONKHO_View.data("IsOrderByName", Request.QueryString["IsOrderByName"]);
        HS_TONKHO_View.data("IsHaveDonGia", Request.QueryString["IsHaveDonGia"]);
        HS_TONKHO_View.data("IsSoLuong", Request.QueryString["IsSoLuong"]);
        HS_TONKHO_View.data("IsRutGon", Request.QueryString["IsRutGon"]);
        return HS_TONKHO_View;
    }
    protected DataProcess s_HS_TonKhoViewDetail()
    {
        DataProcess HS_TonKhoViewDetail = new DataProcess("HS_TonKhoViewDetail");
        HS_TonKhoViewDetail.data("IdTonKhoDetail", Request.QueryString["idkhoachinh"]);
        HS_TonKhoViewDetail.data("IdTonKho", Request.QueryString["IdTonKho"]);
        HS_TonKhoViewDetail.data("TTHC", Request.QueryString["TTHC"]);
        HS_TonKhoViewDetail.data("TenSP", Request.QueryString["TenSP"]);
        HS_TonKhoViewDetail.data("TENDVT", Request.QueryString["TENDVT"]);
        HS_TonKhoViewDetail.data("Dongia", Request.QueryString["Dongia"]);
        HS_TonKhoViewDetail.data("DAUKY_SL", Request.QueryString["DAUKY_SL"]);
        HS_TonKhoViewDetail.data("DAUKY_TT", Request.QueryString["DAUKY_TT"]);
        HS_TonKhoViewDetail.data("NHAP_SL", Request.QueryString["NHAP_SL"]);
        HS_TonKhoViewDetail.data("NHAP_TT", Request.QueryString["NHAP_TT"]);
        HS_TonKhoViewDetail.data("NHAP_SL2", Request.QueryString["NHAP_SL2"]);
        HS_TonKhoViewDetail.data("NHAP_TT2", Request.QueryString["NHAP_TT2"]);
        HS_TonKhoViewDetail.data("XUAT_SL", Request.QueryString["XUAT_SL"]);
        HS_TonKhoViewDetail.data("XUAT_TT", Request.QueryString["XUAT_TT"]);
        HS_TonKhoViewDetail.data("XUAT_SL2", Request.QueryString["XUAT_SL2"]);
        HS_TonKhoViewDetail.data("XUAT_TT2", Request.QueryString["XUAT_TT2"]);
        HS_TonKhoViewDetail.data("CUOIKY_SL", Request.QueryString["CUOIKY_SL"]);
        HS_TonKhoViewDetail.data("CUOIKY_TT", Request.QueryString["CUOIKY_TT"]);
        HS_TonKhoViewDetail.data("CATENAME", Request.QueryString["CATENAME"]);
        HS_TonKhoViewDetail.data("NHOMTHUOC", Request.QueryString["NHOMTHUOC"]);
        HS_TonKhoViewDetail.data("DES", Request.QueryString["DES"]);
        HS_TonKhoViewDetail.data("IdThuoc", Request.QueryString["IdThuoc"]);
        return HS_TonKhoViewDetail;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveHS_TONKHO_View(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableHS_TonKhoViewDetail": LuuTableHS_TonKhoViewDetail(); break;
            case "loadTableHS_TonKhoViewDetail": loadTableHS_TonKhoViewDetail(); break;
            case "xoa": XoaHS_TONKHO_View(); break;
            case "xoaHS_TonKhoViewDetail": XoaHS_TonKhoViewDetail(); break;
            case "IdTonKhoSearch": IdTonKhoSearch(); break;
            case "IdKhoSearch": IdKhoSearch(); break;
            case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
            case "IdThuocSearch": IdThuocSearch(); break;
            case "XuatExcel": XuatExcel(); break;
            case "SetDeaultValue": SetDeaultValue(); break;
        }
    }
    profess_Rpt_TongHopNhapXuatTon NXTReport = null;
    profess_Rpt_nhapxuatton NXTReport_Short = null;
    private void XuatExcel()
    {

        string IdKho = Request.QueryString["IdKho"];
        string TuNgay = Request.QueryString["TuNgay"];
        string DenNgay = Request.QueryString["DenNgay"];
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string IdThuoc = Request.QueryString["IdThuoc"];
        string TenThuoc = Request.QueryString["TenThuoc"];
        string IsOrderByName = Request.QueryString["IsOrderByName"];
        string IsHaveDonGia = Request.QueryString["IsHaveDonGia"];
        string IsSoLuong = Request.QueryString["IsSoLuong"];
        string IsRutGon = Request.QueryString["IsRutGon"];
        string TenKho = Request.QueryString["TenKho"]; string tugio = Request.QueryString["tugio"];
        string tuphut = Request.QueryString["tuphut"];
        string dengio = Request.QueryString["dengio"];
        string denphut = Request.QueryString["denphut"];

        Process_2608.HS_TONKHO_View TonKhoView = new Process_2608.HS_TONKHO_View();
        TonKhoView.IdKho = IdKho;
        TonKhoView.TuNgay = TuNgay;
        TonKhoView.DenNgay = DenNgay;
        TonKhoView.LoaiThuocID = LoaiThuocID;
        TonKhoView.IdThuoc = IdThuoc;
        TonKhoView.TenThuoc = TenThuoc;
        TonKhoView.IsOrderByName = IsOrderByName;
        TonKhoView.IsHaveDonGia = IsHaveDonGia;
        TonKhoView.IsSoLuong = IsSoLuong;
        TonKhoView.IsRutGon = IsRutGon;

        if (TonKhoView != null)
        {
            if (!StaticData.IsCheck(TonKhoView.IsRutGon))
            {
                NXTReport = new profess_Rpt_TongHopNhapXuatTon();
                NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
                NXTReport.TuNgay = DateTime.Parse(StaticData.CheckDate(TonKhoView.TuNgay)).ToString("dd/MM/yyyy");
                NXTReport.DenNgay = DateTime.Parse(StaticData.CheckDate(TonKhoView.DenNgay)).ToString("dd/MM/yyyy");
                NXTReport.IdKho = TonKhoView.IdKho;
                NXTReport.LoaiThuocID = TonKhoView.LoaiThuocID;
                NXTReport.TenThuoc = TonKhoView.TenThuoc;
                NXTReport.IsOrderByName = StaticData.IsCheck(TonKhoView.IsOrderByName);
                NXTReport.IsHaveDonGia = StaticData.IsCheck(TonKhoView.IsHaveDonGia);
                NXTReport.IsOnlySoLuong = StaticData.IsCheck(TonKhoView.IsSoLuong);
                NXTReport.IsRutGon = StaticData.IsCheck(TonKhoView.IsRutGon);
                NXTReport.IDTHUOC = TonKhoView.IdThuoc;
                NXTReport.TenKho = TenKho;
                NXTReport.tugio = tugio;
                NXTReport.tuphut = tuphut;
                NXTReport.dengio = dengio;
                NXTReport.denphut = denphut;

                NXTReport.ExportToExcel();
            }
            else
            {
                NXTReport_Short = new profess_Rpt_nhapxuatton();
                NXTReport_Short.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_Short_AfterExportToExcel);
                NXTReport_Short.FromDate = DateTime.Parse(StaticData.CheckDate(TonKhoView.TuNgay)).ToString("yyyy-MM-dd");
                NXTReport_Short.ToDate = DateTime.Parse(StaticData.CheckDate(TonKhoView.DenNgay)).ToString("yyyy-MM-dd");
                NXTReport_Short.IdKho = TonKhoView.IdKho;
                NXTReport_Short.LoaiThuocID = TonKhoView.LoaiThuocID;
                NXTReport_Short.TenThuoc = TonKhoView.TenThuoc;
                NXTReport_Short.IsOrderByName = StaticData.IsCheck(TonKhoView.IsOrderByName);
                NXTReport_Short.IdThuoc = TonKhoView.IdThuoc;
                NXTReport_Short.TenKho = TenKho;
                NXTReport_Short.tugio = tugio;
                NXTReport_Short.tuphut = tuphut;
                NXTReport_Short.dengio = dengio;
                NXTReport_Short.denphut = denphut;
                NXTReport_Short.ExportToExcel();

            }
        }
    }

    void NXTReport_Short_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport_Short.OutputFileName);
    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
    private void IdTonKhoSearch()
    {
        DataTable table = Process_2608.HS_TONKHO_View.dtGetAll();
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
    private void IdKhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void IdKhoSearch1()
    {
        string tenkho = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 AND TENKHO LIKE N'" + tenkho + "%' ORDER BY TENKHO");
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

                    html.AppendLine(table.Rows[i]["TENKHO"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void LoaiThuocIDSearch()
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
    private void IdThuocSearch()
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
    private void XoaHS_TONKHO_View()
    {
        try
        {
            DataProcess process = s_HS_TONKHO_View();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdTonKho"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void XoaHS_TonKhoViewDetail()
    {
        try
        {
            DataProcess process = s_HS_TonKhoViewDetail();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdTonKhoDetail"));
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
        if (StaticData.HavePermision(this, "HS_TONKHO_View_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = Process_2608.HS_TONKHO_View.dtSearchByIdTonKho(idkhoachinh);
            if (table == null || table.Rows.Count == 0) return;
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable IdTonKho = Process_2608.HS_TONKHO_View.dtSearchByIdTonKho("'" + table.Rows[0]["IdTonKho"] + "'");
            html.AppendLine("<data id=\"mkv_IdTonKho\">" + ((IdTonKho.Rows.Count > 0) ? IdTonKho.Rows[0][1] : "") + "</data>");
            DataTable IdKho = Thuoc_Process.khothuoc.dtSearchByidkho("'" + table.Rows[0]["IdKho"] + "'");
            html.AppendLine("<data id=\"mkv_IdKho\">" + ((IdKho.Rows.Count > 0) ? IdKho.Rows[0]["TENKHO"] : "") + "</data>");
            DataTable LoaiThuocID = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID("'" + table.Rows[0]["LoaiThuocID"] + "'");
            html.AppendLine("<data id=\"mkv_LoaiThuocID\">" + ((LoaiThuocID.Rows.Count > 0) ? LoaiThuocID.Rows[0][1] : "") + "</data>");
            DataTable IdThuoc = Thuoc_Process.thuoc.dtSearchByidthuoc("'" + table.Rows[0]["IdThuoc"] + "'");
            html.AppendLine("<data id=\"mkv_IdThuoc\">" + ((IdThuoc.Rows.Count > 0) ? IdThuoc.Rows[0]["TENTHUOC"] : "") + "</data>");

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
        if (StaticData.HavePermision(this, "HS_TONKHO_View_Search"))
        {
            DataProcess process = s_HS_TONKHO_View();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdTonKho),T.*
                   ,B.makho
                   ,C.MaLoai
                   ,D.sttindm05
                               from HS_TONKHO_View T
                    left join khothuoc  B on T.IdKho=B.idkho
                    left join Thuoc_LoaiThuoc  C on T.LoaiThuocID=C.LoaiThuocID
                    left join thuoc  D on T.IdThuoc=D.idthuoc
          where 1=1");
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdTonKho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenThuoc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsOrderByName") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsHaveDonGia") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["IdTonKho"].ToString() + "','1')\">");
                        if (table.Rows[i]["TuNgay"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["TuNgay"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["TuNgay"].ToString() + "</td>"); }
                        if (table.Rows[i]["DenNgay"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["DenNgay"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["DenNgay"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["MaLoai"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["sttindm05"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TenThuoc"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["IsOrderByName"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["IsHaveDonGia"].ToString() + "</td>");
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
    private void SaveHS_TONKHO_View()
    {
        try
        {
            DataProcess process = s_HS_TONKHO_View();
            string sqlSelect = "SELECT * FROM HS_TONKHO_View ";
            DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
            if (dt == null) return;
            if (dt.Rows.Count > 0)
                process.data("idtonkho", dt.Rows[0][0].ToString());

            if (process.getData("IdTonKho") != null && process.getData("IdTonKho") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdTonKho"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdTonKho"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableHS_TonKhoViewDetail()
    {
        try
        {
            DataProcess process = s_HS_TonKhoViewDetail();
            if (process.getData("IdTonKhoDetail") != null && process.getData("IdTonKhoDetail") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdTonKhoDetail"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdTonKhoDetail"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableHS_TonKhoViewDetail()
    {
        #region Properties
        string IdKho = Request.QueryString["IdKho"];
        string TuNgay = Request.QueryString["TuNgay"];
        string DenNgay = Request.QueryString["DenNgay"];
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string IdThuoc = Request.QueryString["IdThuoc"];
        string TenThuoc = Request.QueryString["TenThuoc"];
        string IsOrderByName = Request.QueryString["IsOrderByName"];
        string IsHaveDonGia = Request.QueryString["IsHaveDonGia"];
        string IsSoLuong = Request.QueryString["IsSoLuong"];
        string IsRutGon = Request.QueryString["IsRutGon"];
        string TenKho = Request.QueryString["TenKho"];

        string tugio = Request.QueryString["tugio"];
        string tuphut = Request.QueryString["tuphut"];
        string dengio = Request.QueryString["dengio"];
        string denphut = Request.QueryString["denphut"];


        Process_2608.HS_TONKHO_View TonKhoView = new Process_2608.HS_TONKHO_View();
        TonKhoView.IdKho = IdKho;
        TonKhoView.TuNgay = TuNgay;
        TonKhoView.DenNgay = DenNgay;
        TonKhoView.LoaiThuocID = LoaiThuocID;
        TonKhoView.IdThuoc = IdThuoc;
        TonKhoView.TenThuoc = TenThuoc;
        TonKhoView.IsOrderByName = IsOrderByName;
        TonKhoView.IsHaveDonGia = IsHaveDonGia;
        TonKhoView.IsSoLuong = IsSoLuong;
        TonKhoView.IsRutGon = IsRutGon;


        DataTable table = null;
        if (TonKhoView != null)
        {
            profess_Rpt_TongHopNhapXuatTon NXTReport = new profess_Rpt_TongHopNhapXuatTon();
            if (TonKhoView.TuNgay == "") return;
            if (TonKhoView.DenNgay == "") return;
            if (TonKhoView.IdKho == "") return;
            if (TonKhoView.LoaiThuocID == "") return;
            NXTReport.TuNgay = DateTime.Parse(StaticData.CheckDate(TonKhoView.TuNgay)).ToString("dd/MM/yyyy");
            NXTReport.DenNgay = DateTime.Parse(StaticData.CheckDate(TonKhoView.DenNgay)).ToString("dd/MM/yyyy");
            NXTReport.IdKho = TonKhoView.IdKho;
            NXTReport.LoaiThuocID = TonKhoView.LoaiThuocID;
            NXTReport.TenThuoc = TonKhoView.TenThuoc;
            NXTReport.IsOrderByName = StaticData.IsCheck(TonKhoView.IsOrderByName);
            NXTReport.IsHaveDonGia = StaticData.IsCheck(TonKhoView.IsHaveDonGia);
            NXTReport.IsRutGon = StaticData.IsCheck(TonKhoView.IsRutGon);
            NXTReport.TenKho = TenKho;
            NXTReport.IDTHUOC = TonKhoView.IdThuoc;

            NXTReport.tugio=tugio;
            NXTReport.tuphut=tuphut;
            NXTReport.dengio=dengio;
            NXTReport.denphut=denphut;


            table = NXTReport.getViewTable();
            table.Columns.Add("IdTonKhoDetail", table.Rows.Count.GetType());
        }


        string paging = "";
        StringBuilder html = new StringBuilder();
        string TenSPName = "Tên sản phẩm";
        if (TonKhoView.LoaiThuocID == "2")
            TenSPName = "Tên hóa chất";
        else
            if (TonKhoView.LoaiThuocID == "4")
                TenSPName = "Tên vật tư y tế";
        if (TonKhoView.LoaiThuocID == "1")
            TenSPName = "Tên thuốc";
        html.Append("<table class='jtable' id=\"gridTable\">");
        bool IsDayDu = true;
        if (StaticData.IsCheck(TonKhoView.IsSoLuong)) IsDayDu = false;
        #endregion
        #region view header
        #region HienThiDayDu
        if (IsDayDu && !StaticData.IsCheck(TonKhoView.IsRutGon))
        {

            html.Append("<tr>");
            html.Append("<th rowspan='3'>STT</th>");
            html.Append("<th rowspan='3'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TTHC") + "</th>");
            html.Append("<th rowspan='3'>" + hsLibrary.clDictionaryDB.sGetValueLanguage(TenSPName) + "</th>");
            html.Append("<th rowspan='3'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENDVT") + "</th>");
            if (StaticData.IsCheck(TonKhoView.IsHaveDonGia))
                html.Append("<th rowspan='3'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Dongia") + "</th>");
            html.Append("<th colspan='2'>Tồn đầu kỳ</th>");
            html.Append("<th colspan='4'>Nhập trong kỳ</th>");
            html.Append("<th colspan='4'>Xuất trong kỳ</th>");
            html.Append("<th colspan='2'>Tồn cuối kỳ</th>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<th rowspan='2'>SL</th>");
            html.Append("<th rowspan='2'>TT</th>");
            html.Append("<th colspan='2'>Nhập</th>");
            html.Append("<th colspan='2'>Chuyển kho</th>");
            html.Append("<th colspan='2'>Xuất</th>");
            html.Append("<th colspan='2'>Chuyển kho</th>");
            html.Append("<th rowspan='2'>SL</th>");
            html.Append("<th rowspan='2'>TT</th>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<th>SL</th>");
            html.Append("<th>TT</th>");
            html.Append("<th>SL</th>");
            html.Append("<th>TT</th>");
            html.Append("<th>SL</th>");
            html.Append("<th>TT</th>");
            html.Append("<th>SL</th>");
            html.Append("<th>TT</th>");
            html.Append("</tr>");
        }
        #endregion
        #region HienThiSoLuong
        if (StaticData.IsCheck(TonKhoView.IsSoLuong) && !StaticData.IsCheck(TonKhoView.IsRutGon))
        {
            html.Append("<tr>");
            html.Append("<th rowspan='2'>STT</th>");
            html.Append("<th rowspan='2'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TTHC") + "</th>");
            html.Append("<th rowspan='2'>" + hsLibrary.clDictionaryDB.sGetValueLanguage(TenSPName) + "</th>");
            html.Append("<th rowspan='2'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENDVT") + "</th>");
            if (StaticData.IsCheck(TonKhoView.IsHaveDonGia))
                html.Append("<th rowspan='2'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Dongia") + "</th>");
            html.Append("<th rowspan='2'>Tồn đầu kỳ</th>");
            html.Append("<th colspan='2'>Nhập trong kỳ</th>");
            html.Append("<th colspan='2'>Xuất trong kỳ</th>");
            html.Append("<th rowspan='2'>Tồn cuối kỳ</th>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<th>Nhập</th>");
            html.Append("<th>Chuyển kho</th>");
            html.Append("<th>Xuất</th>");
            html.Append("<th>Chuyển kho</th>");
            html.Append("</tr>");
        }
        #endregion
        #region HienThiRutGon
        if (StaticData.IsCheck(TonKhoView.IsRutGon))
        {
            html.Append("<th>STT</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TTHC") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage(TenSPName) + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENDVT") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DAUKY_SL") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NHAP_SL") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("XUAT_SL") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NHAP_SL2") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("CUOIKY_SL") + "</th>");
            html.Append("</tr>");
        }
        #endregion
        #endregion
        #region khoitao bien tong tien day du
        double tongtientondauky = 0;
        double tongtiennhaptrongky = 0;
        double tongtiennhapchuyentrongky = 0;
        double tongtienxuattrongky = 0;
        double tongtienxuatchuyentrongky = 0;
        double tongtiencuoiky = 0;
        #endregion
        #region View Row data
        bool search = StaticData.HavePermision(this, "HS_TonKhoViewDetail_Search");
        if (search)
        {
            if (table.Rows.Count > 0)
            {
                bool edit = false;
                List<string> lstCateName = new List<string>();
                List<string> lstNhomThuoc = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    #region HienThiGroup


                    if (!StaticData.IsCheck(TonKhoView.IsOrderByName))
                    {
                        string CATENAME = table.Rows[i]["CateName"].ToString();
                        if (CATENAME != "" && lstCateName.IndexOf(CATENAME.Trim().ToLower()) == -1)
                        {
                            lstCateName.Add(CATENAME.Trim().ToLower());
                            html.Append("<tr>");
                            html.Append("<td colspan=9 > <input type='text' value ='" + CATENAME + "' style='width:100%;font-weight:bold;color:blue!important;text-align:left!important;'  >");
                            html.Append("</td>");
                            html.Append("</tr>");
                        }
                        string TenNhom = table.Rows[i]["NhomThuoc"].ToString();
                        if (TenNhom != "")
                        {
                            string NhomThuocView = CATENAME + "##" + TenNhom;
                            if (lstNhomThuoc.IndexOf(NhomThuocView) == -1)
                            {
                                lstNhomThuoc.Add(NhomThuocView);
                                html.Append("<tr>");
                                html.Append("<td>");
                                html.Append("</td>");
                                html.Append("<td colspan='7' > <input type='text' value ='" + TenNhom + "' style='width:100%;font-weight:bold;color:blue!important;text-align:left!important;'  >");
                                html.Append("</td>");
                                html.Append("</tr>");
                            }
                        }
                    }
                    #endregion
                    #region DangDayDu
                    if (!StaticData.IsCheck(TonKhoView.IsRutGon))
                    {
                        tongtientondauky += StaticData.ParseFloat(table.Rows[i]["DAUKY_TT"]);
                        tongtiennhaptrongky += StaticData.ParseFloat(table.Rows[i]["NHAP_TT"]);
                        tongtiennhapchuyentrongky += StaticData.ParseFloat(table.Rows[i]["NHAP_TT2"]);
                        tongtienxuattrongky += StaticData.ParseFloat(table.Rows[i]["XUAT_TT"]);
                        tongtienxuatchuyentrongky += StaticData.ParseFloat(table.Rows[i]["XUAT_TT2"]);
                        tongtiencuoiky += StaticData.ParseFloat(table.Rows[i]["CUOIKY_TT"]);

                        html.Append("<tr>");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td><input mkv='true' id='TTHC' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TTHC"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:50px'/></td>");
                        html.Append("<td><input mkv='true' id='TenSP' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TenSP"].ToString() + "' " + (!edit ? "disabled" : "") + " style='text-align:justify!important;'/></td>");
                        html.Append("<td><input mkv='true' id='TENDVT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TENDVT"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:50px'/></td>");
                        if (StaticData.IsCheck(TonKhoView.IsHaveDonGia))
                            html.Append("<td><input mkv='true' id='Dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["Dongia"]) + "'  " + (!edit ? "disabled" : "") + " style='width:60px'/></td>");
                        html.Append("<td><input mkv='true' id='DAUKY_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format(new CultureInfo("de-DE"), "{0:0,0.##}", table.Rows[i]["DAUKY_SL"].ToString()) : table.Rows[i]["DAUKY_SL"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:40px;text-algin:right;'/></td>");
                        if (!StaticData.IsCheck(TonKhoView.IsSoLuong))
                            html.Append("<td><input mkv='true' id='DAUKY_TT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["DAUKY_TT"]) + "'  " + (!edit ? "disabled" : "") + " style='width:100%;text-align:right;'/></td>");
                        html.Append("<td><input mkv='true' id='NHAP_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format("{0:0,0.##}", table.Rows[i]["NHAP_SL"].ToString()) : table.Rows[i]["NHAP_SL"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:40px;text-algin:right;'/></td>");
                        if (!StaticData.IsCheck(TonKhoView.IsSoLuong))
                            html.Append("<td><input mkv='true' id='NHAP_TT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["NHAP_TT"]) + "'  " + (!edit ? "disabled" : "") + " style='width:100%;text-align:right;'/></td>");
                        html.Append("<td><input mkv='true' id='NHAP_SL2' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format("{0:0,0.##}", table.Rows[i]["NHAP_SL2"].ToString()) : table.Rows[i]["NHAP_SL2"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:40px;text-algin:right;'/></td>");
                        if (!StaticData.IsCheck(TonKhoView.IsSoLuong))
                            html.Append("<td><input mkv='true' id='NHAP_TT2' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["NHAP_TT2"]) + "'  " + (!edit ? "disabled" : "") + " style='width:100%;text-align:right;'/></td>");
                        html.Append("<td><input mkv='true' id='XUAT_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format("{0:0,0.##}", table.Rows[i]["XUAT_SL"].ToString()) : table.Rows[i]["XUAT_SL"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:40px;text-algin:right;'/></td>");
                        if (!StaticData.IsCheck(TonKhoView.IsSoLuong))
                            html.Append("<td><input mkv='true' id='XUAT_TT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["XUAT_TT"]) + "'  " + (!edit ? "disabled" : "") + " style='width:100%;text-align:right;'/></td>");
                        html.Append("<td><input mkv='true' id='XUAT_SL2' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format("{0:0,0.##}", table.Rows[i]["XUAT_SL2"].ToString()) : table.Rows[i]["XUAT_SL2"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:40px;text-algin:right;'/></td>");
                        if (!StaticData.IsCheck(TonKhoView.IsSoLuong))
                            html.Append("<td><input mkv='true' id='XUAT_TT2' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["XUAT_TT2"]) + "'  " + (!edit ? "disabled" : "") + " style='width:100%;text-align:right;'/></td>");
                        html.Append("<td><input mkv='true' id='CUOIKY_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format("{0:0,0.##}", table.Rows[i]["CUOIKY_SL"].ToString()) : table.Rows[i]["CUOIKY_SL"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:40px;text-algin:right;'/></td>");
                        if (!StaticData.IsCheck(TonKhoView.IsSoLuong))
                            html.Append("<td><input mkv='true' id='CUOIKY_TT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", table.Rows[i]["CUOIKY_TT"]) + "'  " + (!edit ? "disabled" : "") + " style='width:100%;text-align:right;'/></td>");
                        html.Append("</tr>");
                    }
                    #endregion
                    #region DangRutGon
                    else
                    {
                        html.Append("<tr>");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td><input mkv='true' id='TTHC' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TTHC"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:50px'/></td>");
                        html.Append("<td><input mkv='true' id='TenSP' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TenSP"].ToString() + "' " + (!edit ? "disabled" : "") + " style='text-align:justify!important;width:100%'/></td>");
                        html.Append("<td><input mkv='true' id='TENDVT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TENDVT"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:50px;'/></td>");
                        html.Append("<td><input mkv='true' id='DAUKY_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format(new CultureInfo("de-DE"), "{0:0,0.##}", table.Rows[i]["DAUKY_SL"].ToString()) : table.Rows[i]["DAUKY_SL"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:60px;text-algin:right;'/></td>");
                        html.Append("<td><input mkv='true' id='NHAP_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format(new CultureInfo("de-DE"), "{0:0,0.##}", table.Rows[i]["NHAP_SL"].ToString()) : table.Rows[i]["NHAP_SL"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:60px;text-algin:right;'/></td>");
                        html.Append("<td><input mkv='true' id='XUAT_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (double.Parse(table.Rows[i]["XUAT_SL"].ToString()) + double.Parse( (table.Rows[i]["XUAT_SL2"].ToString()!="" ? table.Rows[i]["XUAT_SL2"].ToString():"0"))).ToString() + "'  " + (!edit ? "disabled" : "") + " style='width:60px;text-algin:right;'/></td>");
                        html.Append("<td><input mkv='true' id='NHAP_SL2' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format(new CultureInfo("de-DE"), "{0:0,0.##}", table.Rows[i]["NHAP_SL2"].ToString()) : table.Rows[i]["NHAP_SL2"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:60px;text-algin:right;'/></td>");
                        html.Append("<td><input mkv='true' id='CUOIKY_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (TonKhoView.LoaiThuocID == "2" ? string.Format(new CultureInfo("de-DE"), "{0:0,0.##}", table.Rows[i]["CUOIKY_SL"].ToString()) : table.Rows[i]["CUOIKY_SL"].ToString()) + "'  " + (!edit ? "disabled" : "") + " style='width:60px;text-algin:right;'/></td>");
                        html.Append("</tr>");
                    }
                    #endregion
                }
            }
        }
        #endregion
        #region other
        #region totalwith-full
        if (IsDayDu && !StaticData.IsCheck(TonKhoView.IsRutGon))
        {
            html.Append("<tr><td></td><td colspan='4' style='text-align:right;'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("total") + "</td><td><input type='text' style='width:100%;text-align:right;' disabled='true' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", tongtientondauky) + "' /></td><td></td><td><input type='text' style='width:100%;text-align:right;' disabled='true' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", tongtiennhaptrongky) + "' /></td><td></td><td><input type='text' style='width:100%;text-align:right;' disabled='true' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", tongtiennhapchuyentrongky) + "' /></td><td></td><td><input type='text' style='width:100%;text-align:right;' disabled='true' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", tongtienxuattrongky) + "' /></td><td></td><td><input type='text' style='width:100%;text-align:right;' disabled='true' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", tongtienxuatchuyentrongky) + "' /></td><td></td><td><input type='text' style='width:100%;text-align:right;' disabled='true' value='" + string.Format(new CultureInfo("de-DE"), "{0:0,0.###}", tongtiencuoiky) + "' /></td></tr>");
        }
        #endregion
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
        #endregion
    }
  
    private void SetDeaultValue()
    {
        StaticData.SetDefaultIdKho(this, null, null, null, null, false);
    }
}



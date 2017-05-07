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

public partial class HS_KHAMBENH_VIEW_ajax3 : System.Web.UI.Page
{
    //───────────────────────────────────────────────────────────────────────────────────────
    protected DataProcess s_HS_KHAMBENH_VIEW()
    {
        DataProcess HS_KHAMBENH_VIEW = new DataProcess("HS_KHAMBENH_VIEW");
        HS_KHAMBENH_VIEW.data("IdToaThuoc", Request.QueryString["idkhoachinh"]);
        HS_KHAMBENH_VIEW.data("DenNgay", Request.QueryString["DenNgay"]);
        HS_KHAMBENH_VIEW.data("IdBenhNhan", Request.QueryString["IdBenhNhan"]);
        HS_KHAMBENH_VIEW.data("MaBN", Request.QueryString["MaBN"]);
        HS_KHAMBENH_VIEW.data("HoTenBN", Request.QueryString["HoTenBN"]);
        HS_KHAMBENH_VIEW.data("NgaySinh", Request.QueryString["NgaySinh"]);
        HS_KHAMBENH_VIEW.data("GioiTinh", Request.QueryString["GioiTinh"]);
        HS_KHAMBENH_VIEW.data("SoBHYT", Request.QueryString["SoBHYT"]);
        HS_KHAMBENH_VIEW.data("DungTuyen", Request.QueryString["DungTuyen"]);
        return HS_KHAMBENH_VIEW;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    protected DataProcess s_HS_KHAMBENH_VIEWDetail()
    {
        DataProcess HS_KHAMBENH_VIEWDetail = new DataProcess("HS_KHAMBENH_VIEWDetail");
        HS_KHAMBENH_VIEWDetail.data("IdToaThuocDetail", Request.QueryString["idkhoachinh"]);
        HS_KHAMBENH_VIEWDetail.data("IdToaThuoc", Request.QueryString["IdToaThuoc"]);
        HS_KHAMBENH_VIEWDetail.data("ChiTietThuoc", Request.QueryString["ChiTietThuoc"]);
        HS_KHAMBENH_VIEWDetail.data("ChiTietBenh", Request.QueryString["ChiTietBenh"]);
        HS_KHAMBENH_VIEWDetail.data("ChiTietCLS", Request.QueryString["ChiTietCLS"]);
        return HS_KHAMBENH_VIEWDetail;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "setTimKiem": setTimKiem(); break;
            case "loadTableHS_KHAMBENH_VIEWDetail": loadTableHS_KHAMBENH_VIEWDetail(); break;
        }
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void setTimKiem()
    {
        if (StaticData.HavePermision(this, "HS_KHAMBENH_VIEW_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sqlSelect = @"select A.* 
                            ,MaBN=B.MABENHNHAN 
                            ,HoTenBN=B.TENBENHNHAN
                            ,NgaySinh=B.NGAYSINH
                            ,GioiTinh=DBO.GETGIOITINH(B.GIOITINH)
                            ,SoBHYT=NULL
                            ,DungTuyen=NULL
                            from HS_KHAMBENH_VIEW A
                            LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                        where idtoathuoc=" + idkhoachinh;

            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");

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
    //───────────────────────────────────────────────────────────────────────────────────────
    public void loadTableHS_KHAMBENH_VIEWDetail()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Chẩn đoán bệnh") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Cận lâm sàng & DVKT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đơn thuốc & VTYT & HC") + "</th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "HS_KHAMBENH_VIEWDetail_Add");
        bool search = StaticData.HavePermision(this, "HS_KHAMBENH_VIEWDetail_Search");
        if (search)
        {
            DataProcess process = s_HS_KHAMBENH_VIEWDetail();
            process.Page = Request.QueryString["page"];
            string sqlSelect = @"select STT=row_number() over (order by T.IdToaThuocDetail),T.*
                                from HS_KHAMBENH_VIEWDetail T
                                where T.IdToaThuoc='" + process.getData("IdToaThuoc") + "'";
            DataTable table = process.Search(sqlSelect);
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("HS_KHAMBENH_VIEWDetail");
                bool delete = StaticData.HavePermision(this, "HS_KHAMBENH_VIEWDetail_Delete");
                bool edit = StaticData.HavePermision(this, "HS_KHAMBENH_VIEWDetail_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr onclick=\"ViewKhamBenh('" + table.Rows[i]["IdKhamBenh"].ToString() + "')\">");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td  valign='top'>" + table.Rows[i]["ChiTietBenh"].ToString().Replace(";", "<br/>") + " </td>");
                    html.Append("<td valign='top'>" + table.Rows[i]["ChiTietCLS"].ToString().Replace(";", "<br/>") + " </td>");
                    html.Append("<td valign='top'>" + table.Rows[i]["ChiTietThuoc"].ToString().Replace(";", "<br/>") + " </td>");
                    html.Append("</tr>");
                }
            }
        }
        html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
    //───────────────────────────────────────────────────────────────────────────────────────
}//end class



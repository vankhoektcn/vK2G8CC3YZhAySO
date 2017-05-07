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

public partial class THUOC_YEUCAUTRAHONGVO_ajax : System.Web.UI.Page
{
    protected DataProcess s_THUOC_YEUCAUTRAHONGVO()
    {
        DataProcess THUOC_YEUCAUTRAHONGVO = new DataProcess("THUOC_YEUCAUTRAHONGVO");
        THUOC_YEUCAUTRAHONGVO.data("IdPhieuYeuCauTraHongVo", Request.QueryString["idkhoachinh"]);
        THUOC_YEUCAUTRAHONGVO.data("NgayYeuCau", Request.QueryString["NgayYeuCau"]);
        THUOC_YEUCAUTRAHONGVO.data("SoYeuCau", Request.QueryString["SoYeuCau"]);
        THUOC_YEUCAUTRAHONGVO.data("IdKhoYeuCau", Request.QueryString["IdKhoYeuCau"]);
        THUOC_YEUCAUTRAHONGVO.data("IdKhoNhanTra", Request.QueryString["IdKhoNhanTra"]);
        THUOC_YEUCAUTRAHONGVO.data("IdNguoiYeuCau", Request.QueryString["IdNguoiYeuCau"]);
        return THUOC_YEUCAUTRAHONGVO;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveTHUOC_YEUCAUTRAHONGVO(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": XoaTHUOC_YEUCAUTRAHONGVO(); break;
            case "TimKiem": TimKiem(); break;
            case "IdKhoYeuCauSearch": IdKhoYeuCauSearch(); break;
            case "IdKhoNhanTraSearch": IdKhoNhanTraSearch(); break;
        }
    }

    private void IdKhoYeuCauSearch()
    {
        DataTable table = DataProcess.GetTable("select * from khothuoc ");
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
    private void IdKhoNhanTraSearch()
    {
        DataTable table = DataProcess.GetTable("select * from khothuoc ");
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
    private void XoaTHUOC_YEUCAUTRAHONGVO()
    {
        try
        {
            DataProcess process = s_THUOC_YEUCAUTRAHONGVO();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdPhieuYeuCauTraHongVo"));
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
        if (StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 T.*
                   ,mkv_IdKhoYeuCau = A.tenkho
                   ,mkv_IdKhoNhanTra = B.tenkho
                   ,mkv_IdNguoiYeuCau = C.username
                               from THUOC_YEUCAUTRAHONGVO T
                    left join khothuoc  A on T.IdKhoYeuCau=A.idkho
                    left join khothuoc  B on T.IdKhoNhanTra=B.idkho
                    left join nguoidung  C on T.IdNguoiYeuCau=C.idnguoidung
 where T.IdPhieuYeuCauTraHongVo ='" + idkhoachinh + "'");
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {

                    for (int y = 0; y < table.Columns.Count; y++)
                    {
                        html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + DataProcess.sGetDate(table.Rows[0][y].ToString(), false, true) + "</data>");
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

    private void SaveTHUOC_YEUCAUTRAHONGVO()
    {
        try
        {
            DataProcess process = s_THUOC_YEUCAUTRAHONGVO();
            if (process.getData("IdPhieuYeuCauTraHongVo") != null && process.getData("IdPhieuYeuCauTraHongVo") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdPhieuYeuCauTraHongVo"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdPhieuYeuCauTraHongVo"));
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
        if (StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Search"))
        {
            string tungay = Request.QueryString["tungay"];
            string denngay = Request.QueryString["denngay"];
            DataProcess process = s_THUOC_YEUCAUTRAHONGVO();
            process.Page = Request.QueryString["page"];
            string sqlSelect = @"select STT=row_number() over (order by T.IdPhieuYeuCauTraHongVo),T.*
                   ,khoyeucau=A.tenkho
                   ,khonhan=B.tenkho
                   ,DaDuyet=isnull(IsDaDuyet,0)
                               from THUOC_YEUCAUTRAHONGVO T
                    left join khothuoc  A on T.IdKhoYeuCau=A.idkho
                    left join khothuoc  B on T.IdKhoNhanTra=B.idkho
             where " + process.sWhere();
            if (tungay != null && tungay != "")
            {
                sqlSelect += " AND T.NgayYeuCau >='" + StaticData.CheckDate(tungay) + "'";
            }
            if (denngay != null && denngay != "")
            {
                sqlSelect += " AND T.NgayYeuCau <='" + StaticData.CheckDate(denngay) + " 23:59:59" + "'";
            }
            DataTable table = process.Search(sqlSelect);
            StringBuilder html = new StringBuilder();
            html.Append(process.Paging());
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayYeuCau") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoYeuCau") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoYeuCau") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoNhanTra") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đã duyệt") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["IdPhieuYeuCauTraHongVo"].ToString() + "'," + (StaticData.IsCheck(table.Rows[i]["DaDuyet"]) ? "1" : "0") + ")\">");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td>" + DataProcess.sGetDate(table.Rows[i]["NgayYeuCau"].ToString(), false, true) + "</td>");
                        html.Append("<td>" + table.Rows[i]["SoYeuCau"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["khoyeucau"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["khonhan"].ToString() + "</td>");
                        html.Append("<td>" + (StaticData.IsCheck(table.Rows[i]["DaDuyet"]) ? "Đã duyệt" : "Chưa duyệt") + "</td>");
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



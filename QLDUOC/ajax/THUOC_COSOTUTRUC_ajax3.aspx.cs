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

public partial class THUOC_COSOTUTRUC_ajax : System.Web.UI.Page
{
    protected DataProcess s_THUOC_COSOTUTRUC()
    {
        DataProcess THUOC_COSOTUTRUC = new DataProcess("THUOC_COSOTUTRUC");
        THUOC_COSOTUTRUC.data("IdCoSoTuTruc", Request.QueryString["idkhoachinh"]);
        THUOC_COSOTUTRUC.data("IdKho", Request.QueryString["IdKho"]);
        THUOC_COSOTUTRUC.data("LoaiThuocID", Request.QueryString["LoaiThuocID"]);
        return THUOC_COSOTUTRUC;
    }
    protected DataProcess s_THUOC_COSOTUTRUC_CHITIET()
    {
        DataProcess THUOC_COSOTUTRUC_CHITIET = new DataProcess("THUOC_COSOTUTRUC_CHITIET");
        THUOC_COSOTUTRUC_CHITIET.data("IdCoSoTuTrucChiTiet", Request.QueryString["idkhoachinh"]);
        THUOC_COSOTUTRUC_CHITIET.data("IdCoSoTuTruc", Request.QueryString["IdCoSoTuTruc"]);
        THUOC_COSOTUTRUC_CHITIET.data("IdThuoc", Request.QueryString["IdThuoc"]);
        THUOC_COSOTUTRUC_CHITIET.data("CoSo", Request.QueryString["CoSo"]);
        return THUOC_COSOTUTRUC_CHITIET;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveTHUOC_COSOTUTRUC(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableTHUOC_COSOTUTRUC_CHITIET": LuuTableTHUOC_COSOTUTRUC_CHITIET(); break;
            case "loadTableTHUOC_COSOTUTRUC_CHITIET": loadTableTHUOC_COSOTUTRUC_CHITIET(); break;
            case "xoa": XoaTHUOC_COSOTUTRUC(); break;
            case "xoaTHUOC_COSOTUTRUC_CHITIET": XoaTHUOC_COSOTUTRUC_CHITIET(); break;
            case "IdKhoSearch": IdKhoSearch(); break;
            case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
            case "IdThuocSearch": IdThuocSearch(); break;
            case "setIdKho": setIdKho(); break;
        }
    }
    private void setIdKho()
    {
        string sqlSelect = @"SELECT IDKHO,TENKHO FROM KHOTHUOC"
            + " WHERE ISNULL(ISKT,0)=0 AND NVK_LOAIKHO=2 AND ISNULL(ISKB,0)=0 ";
        if (Request.QueryString["idkhoa"] != null && Request.QueryString["idkhoa"] != "")
        {
            sqlSelect += " AND IDKHOA='" + Request.QueryString["idkhoa"] + "'";
        }
        if (Request.QueryString["idkho"] != null && Request.QueryString["idkho"] != "")
        {
            sqlSelect += " AND idkho='" + Request.QueryString["idkho"] + "'";
        }
        string IDNGUOIDUNG = SysParameter.UserLogin.UserID(this);
        if (IDNGUOIDUNG != null && IDNGUOIDUNG != "" && !SysParameter.UserLogin.IsAdmin(this))
            sqlSelect += " and idkho in (select idkho from khothuocnguoidung where idnguoidung=" + IDNGUOIDUNG + ")";
        DataTable dtKhoHH = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        html.AppendLine("<root>");
        if (dtKhoHH != null & dtKhoHH.Rows.Count > 0)
        {
            for (int i = 0; i < dtKhoHH.Rows.Count; i++)
            {
                html.AppendLine("<data id=\"IdKho\">" + dtKhoHH.Rows[i]["idkho"].ToString() + "</data>");
                html.AppendLine("<data id=\"mkv_IdKho\">" + dtKhoHH.Rows[i]["tenkho"].ToString() + "</data>");
            }
        }
        html.AppendLine("</root>");
        Response.Clear();
        Response.Write(html.ToString().Replace("&", "&amp;"));

    }
    private void IdKhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void LoaiThuocIDSearch()
    {
        DataTable table = DataProcess.GetTable("select * from Thuoc_LoaiThuoc ");
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
    private void IdThuocSearch()
    {
        string SQL = @"select a.idthuoc,a.tenthuoc,b.tendvt from thuoc a left join thuoc_donvitinh b on a.iddvt=b.id
                        where a.tenthuoc like N'%" + Request.QueryString["q"] + "%'" 
                  + " and a.loaithuocid='" + Request.QueryString["LoaiThuocId"] + "'";
        DataTable table = DataProcess.GetTable(SQL);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenthuoc"].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaTHUOC_COSOTUTRUC()
    {
        try
        {
            DataProcess process = s_THUOC_COSOTUTRUC();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdCoSoTuTruc"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void XoaTHUOC_COSOTUTRUC_CHITIET()
    {
        try
        {
            DataProcess process = s_THUOC_COSOTUTRUC_CHITIET();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdCoSoTuTrucChiTiet"));
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
        if (StaticData.HavePermision(this, "THUOC_COSOTUTRUC_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 T.*
                   ,mkv_IdKho = A.tenkho
                   ,mkv_LoaiThuocID = B.TenLoai
                               from THUOC_COSOTUTRUC T
                    left join khothuoc  A on T.IdKho=A.idkho
                    left join Thuoc_LoaiThuoc  B on T.LoaiThuocID=B.LoaiThuocID
                where T.IdCoSoTuTruc ='" + idkhoachinh + "'");
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
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "THUOC_COSOTUTRUC_Search"))
        {
            DataProcess process = s_THUOC_COSOTUTRUC();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdCoSoTuTruc),T.*
                   ,A.tenkho
                   ,B.TenLoai
                               from THUOC_COSOTUTRUC T
                    left join khothuoc  A on T.IdKho=A.idkho
                    left join Thuoc_LoaiThuoc  B on T.LoaiThuocID=B.LoaiThuocID
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["IdCoSoTuTruc"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["tenkho"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TenLoai"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                }
                html.Append("</table>");
                html.Append(process.Paging());
                Response.Clear(); Response.Write(html);
                return;
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
    private void SaveTHUOC_COSOTUTRUC()
    {
        try
        {
            DataProcess process = s_THUOC_COSOTUTRUC();
            if (process.getData("IdCoSoTuTruc") != null && process.getData("IdCoSoTuTruc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdCoSoTuTruc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdCoSoTuTruc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableTHUOC_COSOTUTRUC_CHITIET()
    {
        try
        {
            DataProcess process = s_THUOC_COSOTUTRUC_CHITIET();
            if (process.getData("IdCoSoTuTrucChiTiet") != null && process.getData("IdCoSoTuTrucChiTiet") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdCoSoTuTrucChiTiet"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdCoSoTuTrucChiTiet"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableTHUOC_COSOTUTRUC_CHITIET()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DVT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("CoSo") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "THUOC_COSOTUTRUC_CHITIET_Add");
        bool search = StaticData.HavePermision(this, "THUOC_COSOTUTRUC_CHITIET_Search");
        if (search)
        {
            DataProcess process = s_THUOC_COSOTUTRUC_CHITIET();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by B.TENTHUOC),T.*
                   ,A.IdKho
                   ,B.tenthuoc
                   ,c.tendvt
                               from THUOC_COSOTUTRUC_CHITIET T
                    left join THUOC_COSOTUTRUC  A on T.IdCoSoTuTruc=A.IdCoSoTuTruc
                    left join thuoc  B on T.IdThuoc=B.idthuoc
                    left join thuoc_donvitinh c on b.iddvt=c.id        
                where T.IdCoSoTuTruc='" + process.getData("IdCoSoTuTruc") + "'");
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("THUOC_COSOTUTRUC_CHITIET");
                bool delete = StaticData.HavePermision(this, "THUOC_COSOTUTRUC_CHITIET_Delete");
                bool edit = StaticData.HavePermision(this, "THUOC_COSOTUTRUC_CHITIET_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value='" + table.Rows[i]["IdThuoc"] + "'/><input mkv='true' id='mkv_IdThuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='IdThuocSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:90%;'/></td>");
                    html.Append("<td><input mkv='true' id='tendvt' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tendvt"].ToString() + "' disabled style='width:90%;'/></td>");
                    html.Append("<td><input mkv='true' id='CoSo' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["CoSo"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:90%;'/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["IdCoSoTuTrucChiTiet"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value=''/><input mkv='true' id='mkv_IdThuoc' type='text' value='' onfocus='IdThuocSearch(this);' class=\"down_select\" style='width:90%;'/></td>");
            html.Append("<td><input mkv='true' id='tendvt' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' disabled style='width:90%;'/></td>");
            html.Append("<td><input mkv='true' id='CoSo' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' style='width:90%;'/></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
}



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

public partial class HS_BANGGIATHUOC_ajax : System.Web.UI.Page
{
    protected DataProcess s_HS_BANGGIATHUOC()
    {
        DataProcess HS_BANGGIATHUOC = new DataProcess("HS_BANGGIATHUOC");
        HS_BANGGIATHUOC.data("IDBANGGIA", Request.QueryString["idkhoachinh"]);
        HS_BANGGIATHUOC.data("TuNgay", Request.QueryString["TuNgay"]);
        HS_BANGGIATHUOC.data("DenNgay", Request.QueryString["DenNgay"]);
        HS_BANGGIATHUOC.data("LanThu", Request.QueryString["LanThu"]);
        HS_BANGGIATHUOC.data("LoaiThuocID", Request.QueryString["LoaiThuocID"]);
        HS_BANGGIATHUOC.data("ISBHYT", Request.QueryString["ISBHYT"]);
        return HS_BANGGIATHUOC;
    }
    protected DataProcess s_HS_BANGGIATHUOC_DETAIL()
    {
        DataProcess HS_BANGGIATHUOC_DETAIL = new DataProcess("HS_BANGGIATHUOC_DETAIL");
        HS_BANGGIATHUOC_DETAIL.data("IDCHITIETBANGGIA", Request.QueryString["idkhoachinh"]);
        HS_BANGGIATHUOC_DETAIL.data("IDBANGGIA", Request.QueryString["IDBANGGIA"]);
        HS_BANGGIATHUOC_DETAIL.data("IDTHUOC", Request.QueryString["IDTHUOC"]);
        HS_BANGGIATHUOC_DETAIL.data("IdDVT", Request.QueryString["IdDVT"]);
        HS_BANGGIATHUOC_DETAIL.data("DonGia", Request.QueryString["DonGia"]);
        return HS_BANGGIATHUOC_DETAIL;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveHS_BANGGIATHUOC(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableHS_BANGGIATHUOC_DETAIL": LuuTableHS_BANGGIATHUOC_DETAIL(); break;
            case "loadTableHS_BANGGIATHUOC_DETAIL": loadTableHS_BANGGIATHUOC_DETAIL(); break;
            case "xoa": XoaHS_BANGGIATHUOC(); break;
            case "xoaHS_BANGGIATHUOC_DETAIL": XoaHS_BANGGIATHUOC_DETAIL(); break;
            case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
            case "IDTHUOCSearch": IDTHUOCSearch(); break;
            case "IdDVTSearch": IdDVTSearch(); break;
        }
    }
    private void LoaiThuocIDSearch()
    {
        DataTable table = Process.Thuoc_LoaiThuoc.dtGetAll();
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
    private void IDTHUOCSearch()
    {
        string tenthuoc = Request.QueryString["q"];
        bool IsBHYT = StaticData.IsCheck( Request.QueryString["ISBHYT"]);
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string sql = "SELECT A.*,B.TENDVT FROM THUOC A LEFT JOIN THUOC_DONVITINH B ON A.IDDVT=B.ID WHERE ISNULL(A.ISTHUOCBV,0)=1  ";
        if (tenthuoc != null && tenthuoc != "")
            sql += " AND A.TENTHUOC LIKE N'" + tenthuoc + "%'";

        if (LoaiThuocID != null && LoaiThuocID != "")
            sql += " AND A.LOAITHUOCID=" + LoaiThuocID;

        if (IsBHYT)
            sql += " AND SUDUNGCHOBH=1";

        if (!IsBHYT)
            sql += " AND ISNULL(SUDUNGCHOBH,0)=0";


        sql += " ORDER BY A.TENTHUOC";

        DataTable table = DataAcess.Connect.GetTable(sql);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.AppendLine(table.Rows[i]["TenThuoc"].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i]["IDDVT"].ToString() + "|" + table.Rows[i]["TENDVT"].ToString());
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdDVTSearch()
    {
        DataTable table = Process.Thuoc_DonViTinh.dtGetAll();
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
    private void XoaHS_BANGGIATHUOC()
    {
        try
        {
            DataProcess process = s_HS_BANGGIATHUOC();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IDBANGGIA"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void XoaHS_BANGGIATHUOC_DETAIL()
    {
        try
        {
            DataProcess process = s_HS_BANGGIATHUOC_DETAIL();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IDCHITIETBANGGIA"));
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
        if (Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = Process.HS_BANGGIATHUOC.dtSearchByIDBANGGIA(idkhoachinh);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable LoaiThuocID = Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID("'" + table.Rows[0]["LoaiThuocID"] + "'");
            html.AppendLine("<data id=\"mkv_LoaiThuocID\">" + ((LoaiThuocID.Rows.Count > 0) ? LoaiThuocID.Rows[0][1] : "") + "</data>");

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
        if (Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_Search"))
        {
            DataProcess process = s_HS_BANGGIATHUOC();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IDBANGGIA),T.*
                   ,A.MaLoai
                               from HS_BANGGIATHUOC T
                    left join Thuoc_LoaiThuoc  A on T.LoaiThuocID=A.LoaiThuocID
          where " + process.sWhere() + (StaticData.IsCheck(process.getData("ISBHYT")) == true ? " AND ISNULL(ISBHYT,0)=1" : " AND ISNULL(ISBHYT,0)=0"));
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LanThu") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["IDBANGGIA"].ToString() + "')\">");
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
                        html.Append("<td>" + table.Rows[i]["LanThu"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["MaLoai"].ToString() + "</td>");
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
                Response.Write("");

            }
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }
    private void SaveHS_BANGGIATHUOC()
    {
        try
        {
            DataProcess process = s_HS_BANGGIATHUOC();
            if (process.getData("IDBANGGIA") != null && process.getData("IDBANGGIA") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDBANGGIA"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDBANGGIA"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableHS_BANGGIATHUOC_DETAIL()
    {
        try
        {
            DataProcess process = s_HS_BANGGIATHUOC_DETAIL();
            if (process.getData("IDCHITIETBANGGIA") != null && process.getData("IDCHITIETBANGGIA") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDCHITIETBANGGIA"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDCHITIETBANGGIA"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableHS_BANGGIATHUOC_DETAIL()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IDTHUOC") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdDVT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DonGia") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_DETAIL_Add");
        bool search = Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_DETAIL_Search");
        if (search)
        {
            DataProcess process = s_HS_BANGGIATHUOC_DETAIL();
            process.Page = Request.QueryString["page"];
            string sqlSelect = @"select STT=row_number() over (order by B.TENTHUOC),T.*
                                           ,A.TuNgay
                                           ,B.TenThuoc
                                           ,C.TenDVT
                                                       from HS_BANGGIATHUOC_DETAIL T
                                            left join HS_BANGGIATHUOC  A on T.IDBANGGIA=A.IDBANGGIA
                                            left join thuoc  B on T.IDTHUOC=B.idthuoc
                                            left join Thuoc_DonViTinh  C on T.IdDVT=C.Id
                                  where T.IDBANGGIA='" + process.getData("IDBANGGIA") + "'";
            DataTable table = process.Search(sqlSelect);
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("HS_BANGGIATHUOC_DETAIL");
                bool delete = Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_DETAIL_Delete");
                bool edit = Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_DETAIL_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='IDTHUOC' type='hidden' value='" + table.Rows[i]["IDTHUOC"] + "'/><input mkv='true' id='mkv_IDTHUOC' type='text' value='" + table.Rows[i]["TenThuoc"].ToString() + "' onfocus='IDTHUOCSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:90%'/></td>");
                    html.Append("<td><input mkv='true' id='IdDVT' type='hidden' value='" + table.Rows[i]["IdDVT"] + "'/><input mkv='true' id='mkv_IdDVT' type='text' value='" + table.Rows[i]["TenDVT"].ToString() + "' onfocus='IdDVTSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:100%'/></td>");
                    html.Append("<td><input mkv='true' id='DonGia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DonGia"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:100%'/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["IDCHITIETBANGGIA"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='IDTHUOC' type='hidden' value=''/><input mkv='true' id='mkv_IDTHUOC' type='text' value='' onfocus='IDTHUOCSearch(this);' class=\"down_select\" style='width:90%'/></td>");
            html.Append("<td><input mkv='true' id='IdDVT' type='hidden' value=''/><input mkv='true' id='mkv_IdDVT' type='text' value='' onfocus='IdDVTSearch(this);' class=\"down_select\" style='width:100%' /></td>");
            html.Append("<td><input mkv='true' id='DonGia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' style='width:100%' /></td>");
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



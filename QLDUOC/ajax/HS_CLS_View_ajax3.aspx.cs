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

public partial class HS_CLS_View_ajax : System.Web.UI.Page
{
    protected DataProcess s_HS_CLS_View()
    {
        DataProcess HS_CLS_View = new DataProcess("HS_CLS_View");
        HS_CLS_View.data("IdToaThuoc", Request.QueryString["idkhoachinh"]);
        HS_CLS_View.data("NgayToa", Request.QueryString["NgayToa"]);
        HS_CLS_View.data("IdBenhNhan", Request.QueryString["IdBenhNhan"]);
        HS_CLS_View.data("MaBN", Request.QueryString["MaBN"]);
        HS_CLS_View.data("HoTenBN", Request.QueryString["HoTenBN"]);
        HS_CLS_View.data("NgaySinh", Request.QueryString["NgaySinh"]);
        HS_CLS_View.data("GioiTinh", Request.QueryString["GioiTinh"]);
        HS_CLS_View.data("SoBHYT", Request.QueryString["SoBHYT"]);
        HS_CLS_View.data("DungTuyen", Request.QueryString["DungTuyen"]);
        HS_CLS_View.data("IsHaveThuoc", Request.QueryString["IsHaveThuoc"]);
        HS_CLS_View.data("BNTra", Request.QueryString["BNTra"]);
        HS_CLS_View.data("Capthuoc", Request.QueryString["Capthuoc"]);
        return HS_CLS_View;
    }
    protected DataProcess s_HS_CLS_ViewDetail()
    {
        DataProcess HS_CLS_ViewDetail = new DataProcess("HS_CLS_ViewDetail");
        HS_CLS_ViewDetail.data("IdToaThuocDetail", Request.QueryString["idkhoachinh"]);
        HS_CLS_ViewDetail.data("IdToaThuoc", Request.QueryString["IdToaThuoc"]);
        HS_CLS_ViewDetail.data("ChiTietThuoc", Request.QueryString["ChiTietThuoc"]);
        HS_CLS_ViewDetail.data("ChiTietBenh", Request.QueryString["ChiTietBenh"]);
        HS_CLS_ViewDetail.data("ChiTietCLS", Request.QueryString["ChiTietCLS"]);
        return HS_CLS_ViewDetail;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveHS_CLS_View(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableHS_CLS_ViewDetail": LuuTableHS_CLS_ViewDetail(); break;
            case "loadTableHS_CLS_ViewDetail": loadTableHS_CLS_ViewDetail(); break;
            case "xoa": XoaHS_CLS_View(); break;
            case "xoaHS_CLS_ViewDetail": XoaHS_CLS_ViewDetail(); break;
            case "XuatThuoc": XuatThuoc(); break;
            case "InBV01": InBV01(); break;
        }
    }
     
    private void XoaHS_CLS_View()
    {
        try
        {
            DataProcess process = s_HS_CLS_View();
            bool ok = true;
            #region Xóa Phiếu xuất theo toa
            string sdel = "select distinct idkhambenh from HS_CLS_ViewDetail where IdToaThuoc='" + process.getData("IdToaThuoc") + "'";
            DataTable dtDel= DataAcess.Connect.GetTable(sdel);
            if(dtDel != null && dtDel.Rows.Count>0)
            {
                for (int i = 0; i < dtDel.Rows.Count; i++)
                {
                    ok = DataAcess.Connect.ExecSQL("update khambenh set ISCHECKCLS=0 where idkhambenh= " + dtDel.Rows[i]["idkhambenh"]);
                    if (!ok)
                        break;
                }
            }
            #endregion
            if (ok)
            {
                bool kk = DataAcess.Connect.ExecSQL("delete HS_CLS_ViewDetail where IdToaThuoc='" + process.getData("IdToaThuoc") + "'");
                ok = DataAcess.Connect.ExecSQL("delete HS_CLS_View where IdToaThuoc='" + process.getData("IdToaThuoc") + "'");
            }
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdToaThuoc"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void XoaHS_CLS_ViewDetail()
    {
        try
        {
            DataProcess process = s_HS_CLS_ViewDetail();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdToaThuocDetail"));
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
        if (StaticData.HavePermision(this, "HS_CLS_View_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataAcess.Connect.GetTable("SELECT * FROM  HS_CLS_View  WHERE IdToaThuoc="+idkhoachinh);
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
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "HS_CLS_View_Search"))
        {
            DataProcess process = s_HS_CLS_View();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdToaThuoc),T.*
                   ,A.NgayToa
                               from HS_CLS_View T
                    left join HS_CLS_View  A on T.IdToaThuoc=A.IdToaThuoc
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdToaThuoc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayToa") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdBenhNhan") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaBN") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("HoTenBN") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgaySinh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GioiTinh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoBHYT") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DungTuyen") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsHaveThuoc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("BNTra") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Capthuoc") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["IdToaThuoc"].ToString() + "')\">");
                        if (table.Rows[i]["NgayToa"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["NgayToa"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["NgayToa"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["IdBenhNhan"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["MaBN"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["HoTenBN"].ToString() + "</td>");
                        if (table.Rows[i]["NgaySinh"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["NgaySinh"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["NgaySinh"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["GioiTinh"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["SoBHYT"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["DungTuyen"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["IsHaveThuoc"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["BNTra"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["Capthuoc"].ToString() + "</td>");
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
    private void SaveHS_CLS_View()
    {
        try
        {
            DataProcess process = s_HS_CLS_View();
            if (process.getData("IdToaThuoc") != null && process.getData("IdToaThuoc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdToaThuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdToaThuoc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableHS_CLS_ViewDetail()
    {
        try
        {
            DataProcess process = s_HS_CLS_ViewDetail();
            if (process.getData("IdToaThuocDetail") != null && process.getData("IdToaThuocDetail") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdToaThuocDetail"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdToaThuocDetail"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableHS_CLS_ViewDetail()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Cận lâm sàng & DVKT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Chẩn đoán bệnh") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "HS_CLS_ViewDetail_Add");
        bool search = StaticData.HavePermision(this, "HS_CLS_ViewDetail_Search");
        if (search)
        {
            DataProcess process = s_HS_CLS_ViewDetail();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdToaThuocDetail),T.*
                               from HS_CLS_ViewDetail T
          where T.IdToaThuoc='" + process.getData("IdToaThuoc") + "'");
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("HS_CLS_ViewDetail");
                bool delete = StaticData.HavePermision(this, "HS_CLS_ViewDetail_Delete");
                bool edit = StaticData.HavePermision(this, "HS_CLS_ViewDetail_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                     
                    #region chitietcls_dvkt
                    html.Append("<td valign='top'><table style='width:100%'>");
                    html.Append("<tr>");
                    html.Append("<th>STT</th>");
                    html.Append("<th style='text-align:left;'>Tên cận lâm sàng</th>");
                    html.Append("<th>SL</th>");
                    html.Append("<th>DVT</th>");
                    html.Append("</tr>");
                    string[] chitietcls = table.Rows[i]["chitietcls"].ToString().Split(';');
                    for (int k = 0; k < chitietcls.Length; k++)
                    {
                        string dk = chitietcls[k].Trim();
                        if (dk != "")
                        {
                            int p = dk.LastIndexOf("(");
                            int q = dk.LastIndexOf(")");
                            string tencls = dk.Substring(0, p);
                            string dvt = dk.Substring(p + 1, q - p - 1);
                            string sl = dvt.Substring(0, dvt.IndexOf(" "));
                            string dvt_i = dvt.Replace(sl, "");
                            html.Append("<tr>");
                            html.Append("<td>" + (k + 1) + "</td>");
                            html.Append("<td style='text-align:left;'>" + tencls + "</td>");
                            html.Append("<td>" + sl + "</td>");
                            html.Append("<td>" + dvt_i + "</td>");
                            html.Append("</tr>");
                        }
                    }
                    html.Append("</table></td>");
                    #endregion
                    html.Append("<td valign='top'>" + table.Rows[i]["ChiTietBenh"].ToString().Replace(";", "<br/>") + " </td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["IdToaThuocDetail"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
    private void XuatThuoc()
    {
        string IdToaThuoc = Request.QueryString["idkhoachinh"];
        if (IdToaThuoc == null || IdToaThuoc == "") return;
        string sqlSelect = "select * from HS_CLS_ViewDetail where IdToaThuoc=" + IdToaThuoc;
        DataTable dtToaThuoc = DataAcess.Connect.GetTable(sqlSelect);
        if (dtToaThuoc == null || dtToaThuoc.Rows.Count == 0) return;
        for (int ii = 0; ii < dtToaThuoc.Rows.Count; ii++)
        {
            string IDKHAMBENH = dtToaThuoc.Rows[ii]["idkhambenh"].ToString();
            bool ok_khambenh = DataAcess.Connect.ExecSQL(" update khambenh set ISCHECKCLS=1 where idkhambenh=" + IDKHAMBENH);
        }//end for

        bool ok_toathuoc = DataAcess.Connect.ExecSQL(" update HS_CLS_View set Capthuoc=1 where IdToaThuoc=" + IdToaThuoc);

        Response.Clear();
        Response.Write("1");

    }//end void
    private void InBV01()
    {
        string IdToaThuoc = Request.QueryString["idkhoachinh"];
        if (IdToaThuoc == null || IdToaThuoc == "") return;
        string sqlSelect = @"select b.ID
                             from  HS_CLS_View A
	                            INNER JOIN  hs_benhnhanbhdongtien B ON A.IDBENHNHAN=B.IDBENHNHAN AND ( CONVERT(NVARCHAR(20),A.NgayToa,103)=CONVERT(NVARCHAR(20),B.NgayTinhBH,103) OR CONVERT(NVARCHAR(20),A.NgayToa,103)=CONVERT(NVARCHAR(20),B.NgayTinhBH_THUC,103))
                            WHERE IdToaThuoc=" + IdToaThuoc;
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt == null || dt.Rows.Count == 0) return;
        Response.Clear();
        Response.Write(dt.Rows[0][0].ToString());
    }
}//end class



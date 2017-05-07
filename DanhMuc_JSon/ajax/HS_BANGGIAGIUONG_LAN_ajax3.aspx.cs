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

public partial class HS_BANGGIAGIUONG_LAN_ajax : System.Web.UI.Page
{
    protected DataProcess s_HS_BANGGIAGIUONG_LAN()
    {
        DataProcess HS_BANGGIAGIUONG_LAN = new DataProcess("HS_BANGGIAGIUONG_LAN");
        HS_BANGGIAGIUONG_LAN.data("BANGGIAID", Request.QueryString["idkhoachinh"]);
        HS_BANGGIAGIUONG_LAN.data("TUNGAY", Request.QueryString["TUNGAY"]);
        HS_BANGGIAGIUONG_LAN.data("LANID", Request.QueryString["LANID"]);
        return HS_BANGGIAGIUONG_LAN;
    }
    protected DataProcess s_HS_BANGGIAGIUONG()
    {
        DataProcess HS_BANGGIAGIUONG = new DataProcess("HS_BANGGIAGIUONG");
        HS_BANGGIAGIUONG.data("BangGiaGiuongId", Request.QueryString["idkhoachinh"]);
        HS_BANGGIAGIUONG.data("BANGGIAID", Request.QueryString["BANGGIAID"]);
        HS_BANGGIAGIUONG.data("IDLOAIGIUONG", Request.QueryString["IDLOAIGIUONG"]);
        HS_BANGGIAGIUONG.data("TuNgay", Request.QueryString["TuNgay"]);
        HS_BANGGIAGIUONG.data("GiaDV", Request.QueryString["GiaDV"]);
        HS_BANGGIAGIUONG.data("GiaBH", Request.QueryString["GiaBH"]);
        HS_BANGGIAGIUONG.data("IsBHYT", Request.QueryString["IsBHYT"]);
        return HS_BANGGIAGIUONG;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveHS_BANGGIAGIUONG_LAN(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableHS_BANGGIAGIUONG": LuuTableHS_BANGGIAGIUONG(); break;
            case "loadTableHS_BANGGIAGIUONG": loadTableHS_BANGGIAGIUONG(); break;
            case "xoa": XoaHS_BANGGIAGIUONG_LAN(); break;
            case "xoaHS_BANGGIAGIUONG": XoaHS_BANGGIAGIUONG(); break;
            case "IDLOAIGIUONGSearch": IDLOAIGIUONGSearch(); break;
            case "PhanBoBangGia": PhanBoBangGia(); break;
        }
    }

    private void IDLOAIGIUONGSearch()
    {
        DataTable table = DataProcess.GetTable("select * from HS_LOAIGIUONG");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TENLOAIGIUONG"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaHS_BANGGIAGIUONG_LAN()
    {
        try
        {
            DataProcess process = s_HS_BANGGIAGIUONG_LAN();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("BANGGIAID"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void XoaHS_BANGGIAGIUONG()
    {
        try
        {
            DataProcess process = s_HS_BANGGIAGIUONG();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("BangGiaGiuongId"));
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
        if (Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_LAN_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 idkhoachinh=T.BANGGIAID,T.*
                               from HS_BANGGIAGIUONG_LAN T
 where T.BANGGIAID ='" + idkhoachinh + "'");
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }

    private void TimKiem()
    {
        if (Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_LAN_Search"))
        {
            DataProcess process = s_HS_BANGGIAGIUONG_LAN();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.BANGGIAID),T.*
                               from HS_BANGGIAGIUONG_LAN T
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("BANGGIAID") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TUNGAY") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LANID") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["BANGGIAID"].ToString() + "')\">");
                        html.Append("<td>" + DataProcess.sGetDate(table.Rows[i]["TUNGAY"].ToString(), false, true) + "</td>");
                        html.Append("<td>" + table.Rows[i]["LANID"].ToString() + "</td>");
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

    private void SaveHS_BANGGIAGIUONG_LAN()
    {
        try
        {
            DataProcess process = s_HS_BANGGIAGIUONG_LAN();
            if (process.getData("BANGGIAID") != null && process.getData("BANGGIAID") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("BANGGIAID"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("BANGGIAID"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableHS_BANGGIAGIUONG()
    {
        try
        {
            DataProcess process = s_HS_BANGGIAGIUONG();
            if (process.getData("BangGiaGiuongId") != null && process.getData("BangGiaGiuongId") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("BangGiaGiuongId"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("BangGiaGiuongId"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableHS_BANGGIAGIUONG()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên loại giường") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Giá DV") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Giá BH") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("?BHYT") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_Add");
        bool search = Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_Search");
        if (search)
        {
            DataProcess process = s_HS_BANGGIAGIUONG();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"SELECT DISTINCT STT=ROW_NUMBER() OVER (ORDER BY A.IDLOAIGIUONG)
			                                        , A.IDLOAIGIUONG
			                                        ,A.TENLOAIGIUONG 
			                                        ,BangGiaGiuongID=B.BangGiaGiuongID
			                                        ,B.BANGGIAID
			                                        ,B.GiaDV
			                                        ,B.GiaBH
			                                        ,B.IsBHYT
                                        FROM HS_LOAIGIUONG A
                                        LEFT JOIN HS_BANGGIAGIUONG B ON A.IDLOAIGIUONG=B.IDLOAIGIUONG AND B.BANGGIAID='" + process.getData("BANGGIAID") + "'");
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("HS_BANGGIAGIUONG");
                bool delete = Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_Delete");
                bool edit = Userlogin_new.HavePermision(this, "HS_BANGGIAGIUONG_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='IDLOAIGIUONG' type='hidden' value='" + table.Rows[i]["IDLOAIGIUONG"] + "'/><input mkv='true' id='mkv_IDLOAIGIUONG' type='text' value='" + table.Rows[i]["TENLOAIGIUONG"].ToString() + "'  class=\"down_select\" " + (1 == 1 ? "disabled" : "") + "   style='width:600px' /></td>");
                    html.Append("<td><input mkv='true' id='GiaDV' type='text' value='" + table.Rows[i]["GiaDV"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "  style='width:100%' /></td>");
                    html.Append("<td><input mkv='true' id='IsBHYT' type='checkbox' " + (table.Rows[i]["IsBHYT"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + " style='width:100%' /></td>");
                    html.Append("<td><input mkv='true' id='GiaBH' type='text' value='" + table.Rows[i]["GiaBH"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "  style='width:100%' /></td>");

                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["BangGiaGiuongId"].ToString() + "'/></td>");
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
    }//end void

    private void PhanBoBangGia()
    {
        string BangGiaID = Request.QueryString["BangGiaID"].ToString();
        string SqlSave = "EXEC zHS_AutoConvertTo_KBBangGiaGiuong " + BangGiaID;
        bool ok = DataAcess.Connect.ExecSQL(SqlSave);
    }
}



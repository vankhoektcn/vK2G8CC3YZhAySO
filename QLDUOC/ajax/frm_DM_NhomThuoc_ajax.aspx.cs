
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

public partial class frm_DM_NhomThuoc_ajax : System.Web.UI.Page
{
    protected DataProcess s_category()
    {
        DataProcess category = new DataProcess("category");
        category.data("cateid", Request.QueryString["idkhoachinh"]);
        category.data("catename", Request.QueryString["catename"]);
        category.data("des", Request.QueryString["des"]);
        category.data("dinhdanhimei", Request.QueryString["dinhdanhimei"]);
        category.data("loaithuocid", Request.QueryString["loaithuocid"]);
        category.data("SoTT", Request.QueryString["SoTT"]);
        return category;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savecategory(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoacategory(); break;
            case "TimKiem": TimKiem(); break;
            case "cateidSearch": cateidSearch(); break;
            case "loaithuocidSearch": loaithuocidSearch(); break;
        }
    }

    private void cateidSearch()
    {
        DataTable table = Thuoc_Process.category.dtGetAll();
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loaithuocidSearch()
    {
        DataTable table = Thuoc_Process.Thuoc_LoaiThuoc.dtGetAll();
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoacategory()
    {
        try
        {
            DataProcess process = s_category();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("cateid"));
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }

    private void setTimKiem()
    {
        string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
        DataTable table = Thuoc_Process.category.dtSearchBycateid(idkhoachinh);
        string html = "";
        html += "<root>";
        html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
        DataTable cateid = Thuoc_Process.category.dtSearchBycateid("'" + table.Rows[0]["cateid"] + "'");
        html += "<data id=\"mkv_cateid\">" + ((cateid.Rows.Count > 0) ? cateid.Rows[0][1] : "") + "</data>";
        DataTable loaithuocid = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID("'" + table.Rows[0]["loaithuocid"] + "'");
        html += "<data id=\"mkv_loaithuocid\">" + ((loaithuocid.Rows.Count > 0) ? loaithuocid.Rows[0][1] : "") + "</data>";
        html += Environment.NewLine;
        if (table.Rows.Count > 0)
        {

            for (int y = 0; y < table.Columns.Count; y++)
            {
                try
                {
                    html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                }
                catch (Exception)
                {
                    html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                }
                html += Environment.NewLine;
            }
        }
        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }

    private void Savecategory()
    {
        try
        {
            DataProcess process = s_category();
            if (process.getData("cateid") != null && process.getData("cateid") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("cateid"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("cateid"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }
    private void TimKiem()
    {
        DataProcess process = s_category();
        process.Page = Request.QueryString["page"];
        DataTable table = process.Search(@"select STT=row_number() over (order by T.cateid),T.*
                   ,B.MaLoai
                               from category T
                    left join Thuoc_LoaiThuoc  B on T.loaithuocid=B.LoaiThuocID
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("catename") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("des") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaithuocid") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoTT") + "</th>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["cateid"].ToString() + "')\">";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td style='text-align:left; padding-left:10px;'>" + table.Rows[i]["catename"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["des"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["MaLoai"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["SoTT"].ToString() + "</td>";
                    html += "</tr>";
                }
            }
        }
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }
}
 
 

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

public partial class DiaChi_ajax : System.Web.UI.Page
{
    protected DataProcess s_DiaChi()
    {
        DataProcess DiaChi = new DataProcess("DiaChi");
        DiaChi.data("idDiaChi", Request.QueryString["idkhoachinh"]);
        DiaChi.data("MaDiaChi", Request.QueryString["MaDiaChi"]);
        DiaChi.data("idXa", Request.QueryString["idXa"]);
        DiaChi.data("TextDiaChi", Request.QueryString["TextDiaChi"]);

        return DiaChi;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_DiaChi(); break;
            case "xoa": Xoa_DiaChi(); break;
            case "TimKiem": TimKiem(); break;
            case "MaDiaChiSearch": MaDiaChiSearch(); break;
            case "idXaSearch": idXaSearch(); break;
            case "idQuanHuyenSearch": idQuanHuyenSearch(); break;
            case "tinhidSearch": tinhidSearch(); break;
        }
    }
    private void tinhidSearch()
    {
        DataTable table = KB_Process.tinh.dtGetAll();
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
    private void idXaSearch()
    {
        string quanhuyenid = Request.QueryString["quanhuyenid"];
        string w = "";
        if (quanhuyenid != "" && quanhuyenid != "0")
        {
            w = " and quanhuyenid='" + quanhuyenid + "'";
        }
        string sqlS = "select * from phuongxa where 1=1 " + w;
        DataTable table = KB_Process.phuongxa.GetTable(sqlS);
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
    private void MaDiaChiSearch()
    {
        DataTable table = KB_Process.DiaChi.dtGetAll();
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][3].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }

        Response.Clear(); Response.Write(html);
    }
    private void idQuanHuyenSearch()
    {
        string tinhid = Request.QueryString["tinhid"];
        string w = "";
        if (tinhid != "" && tinhid != "0")
        {
            w = " and tinhid='" + tinhid + "'";
        }
        string sqlS = "select * from quanhuyen where 1=1 " + w;
        DataTable table = KB_Process.quanhuyen.GetTable(sqlS);
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
    private void Xoa_DiaChi()
    {
        try
        {
            DataProcess process = s_DiaChi();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idDiaChi"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_DiaChi()
    {
        try
        {
            DataProcess process = s_DiaChi();
            if (process.getData("idDiaChi") != null && process.getData("idDiaChi") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idDiaChi"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idDiaChi"));
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
        DataProcess process = s_DiaChi();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idDiaChi),T.*
                   ,A.quanhuyenid
                               from DiaChi T
                    left join phuongxa  A on T.idXa=A.phuongxaid
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaDiaChi") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tinhid") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("quanhuyenid") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idXa") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TextDiaChi") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table != null)
        {
            int istt = 1;
            if (table.Rows.Count > 0)
            {
                istt = table.Rows.Count + 1;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string sqlGT = @"select px.phuongxaid,qh.quanhuyenid,qh.quanhuyenname,qh.tinhid ,t.tinhname,px.tenphuongxa
                            from diachi dc
                            left join phuongxa px on dc.idxa=px.phuongxaid
                            left join quanhuyen qh on qh.quanhuyenid=px.quanhuyenid
                            left join tinh t on qh.tinhid=t.tinhid
                            where dc.iddiachi='" + table.Rows[i]["iddiachi"] + "'";
                    DataTable dbGT = DataAcess.Connect.GetTable(sqlGT);
                    string tinhid = "";
                    string tinhname = "";
                    string quanhuyenid = "";
                    string quanhuyenname = "";
                    string phuongxaname = "";
                    if (dbGT.Rows.Count > 0)
                    {
                        tinhid = dbGT.Rows[0]["tinhid"].ToString();
                        tinhname = dbGT.Rows[0]["tinhname"].ToString();
                        quanhuyenid = dbGT.Rows[0]["quanhuyenid"].ToString();
                        quanhuyenname = dbGT.Rows[0]["quanhuyenname"].ToString();
                        phuongxaname = dbGT.Rows[0]["tenphuongxa"].ToString();
                    }
                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onkeydown=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    html += "<td><input mkv='true' id='MaDiaChi' type='text' value='" + table.Rows[i]["MaDiaChi"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:90%'/></td>";
                    html += "<td><input mkv='true' id='tinhid' type='hidden' value='" + tinhid + "'/><input mkv='true' id='mkv_tinhid' type='text' value='" + tinhname + "' onfocus='tinhidSearch(this);' class=\"down_select\" style='width:90%'/></td>";
                    html += "<td><input mkv='true' id='quanhuyenid' type='hidden' value='" + quanhuyenid + "'/><input mkv='true' id='mkv_quanhuyenid' type='text' value='" + quanhuyenname + "' onfocus='idQuanHuyenSearchLuoi(this);' class=\"down_select\" style='width:90%'/></td>";
                    html += "<td><input mkv='true' id='idXa' type='hidden' value='" + table.Rows[i]["idXa"] + "'/><input mkv='true' id='mkv_idXa' type='text' value='" + phuongxaname + "' onfocus='idXaSearchLuoi(this);' class=\"down_select\" style='width:90%'/></td>";
                    html += "<td><input mkv='true' id='TextDiaChi' type='text'  value='" + table.Rows[i]["TextDiaChi"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);GhepDiaChi(this);' style='width:90%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["idDiaChi"] + "'/></td>";
                    html += "</tr>";
                }
            }

            html += "<tr>";
            html += "<td>" + istt.ToString() + "</td>";
            html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onkeydown=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
            html += "<td><input mkv='true' id='MaDiaChi' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:90%'/></td>";
            html += "<td><input mkv='true' id='tinhid' type='hidden' value=''/><input mkv='true' id='mkv_tinhid' type='text' value='' onfocus='tinhidSearch(this);' class=\"down_select\" style='width:90%'/></td>";
            html += "<td><input mkv='true' id='quanhuyenid' type='hidden' value=''/><input mkv='true' id='mkv_quanhuyenid' type='text' value='' onfocus='idQuanHuyenSearchLuoi(this);' class=\"down_select\" style='width:90%'/></td>";
            html += "<td><input mkv='true' id='idXa' type='hidden' value=''/><input mkv='true' id='mkv_idXa' type='text' value='' onfocus='idXaSearchLuoi(this);' class=\"down_select\" style='width:90%'/></td>";
            html += "<td><input mkv='true' id='TextDiaChi' type='text' value='' onfocus='chuyendong(this);chuyenphim(this);GhepDiaChi(this);' onfocusout='chuyenformout(this)' style='width:90%'/></td>";
            html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
            html += "</tr>";

        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }
}



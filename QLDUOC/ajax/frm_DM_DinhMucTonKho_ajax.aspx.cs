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

public partial class frm_DM_DinhMucTonKho_ajax : System.Web.UI.Page
{
    protected DataProcess s_Thuoc_DinhMucTonKho()
    {
        DataProcess Thuoc_DinhMucTonKho = new DataProcess("Thuoc_DinhMucTonKho");
        Thuoc_DinhMucTonKho.data("IdDinhMuc", Request.QueryString["idkhoachinh"]);
        Thuoc_DinhMucTonKho.data("Idthuoc", Request.QueryString["Idthuoc"]);
        Thuoc_DinhMucTonKho.data("idkho", Request.QueryString["idkho"]);
        Thuoc_DinhMucTonKho.data("SL", Request.QueryString["SL"]);
        Thuoc_DinhMucTonKho.data("loaithuocid", Request.QueryString["loaithuocid"]);
        Thuoc_DinhMucTonKho.data("cateid", Request.QueryString["cateid"]);
        return Thuoc_DinhMucTonKho;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_Thuoc_DinhMucTonKho(); break;
            case "xoa": Xoa_Thuoc_DinhMucTonKho(); break;
            case "TimKiem": TimKiem(); break;
            case "IdthuocSearch": IdthuocSearch(); break;
            case "IdKhoSearch": IdKhoSearch(); break;
            case "loaithuocidSearch": loaithuocidSearch(); break;
            case "cateidSearch": cateidSearch(); break;
        }
    }

    private void IdthuocSearch()
    {
        string sqlSelect = @"SELECT idthuoc,tenthuoc
                                        FROM thuoc T
                                        where 1=1
                                        and IsThuocBV=1";
        if(Request.QueryString["cateid"].ToString()!="")
            sqlSelect+="               and CateID="+Request.QueryString["cateid"].ToString();

        if(Request.QueryString["loaithuocid"].ToString()!="")
            sqlSelect+="               and loaithuocid="+Request.QueryString["loaithuocid"].ToString();

        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
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
    private void cateidSearch()
    {
        DataTable table = Thuoc_Process.category.dtSearchByloaithuocid("'" + Request.QueryString["loaithuocid"] + "'");
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
    private void IdKhoSearch()
    {
        string tenkho = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 AND TENKHO LIKE N'" + tenkho + "%' ORDER BY TENKHO");
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
    private void Xoa_Thuoc_DinhMucTonKho()
    {
        try
        {
            DataProcess process = s_Thuoc_DinhMucTonKho();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdDinhMuc"));
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }

    private void LuuTable_Thuoc_DinhMucTonKho()
    {
        try
        {
            DataProcess process = s_Thuoc_DinhMucTonKho();
            if (process.getData("IdDinhMuc") != null && process.getData("IdDinhMuc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdDinhMuc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdDinhMuc"));
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
        DataProcess process = s_Thuoc_DinhMucTonKho();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";

        string idthuoc = process.getData("idthuoc");
        string idkho = process.getData("idkho");
        string loaithuocid = process.getData("loaithuocid");
        string cateid = process.getData("cateid");
        if (idkho == null || idkho == "") idkho = StaticData.MacDinhKhoNhapMuaID;


        string sqlSelect = @"SELECT row_number() OVER(ORDER by loaithuocid,tenthuoc) as STT
	                                        ,T2.IDDINHMUC
	                                        ,T.Idthuoc
	                                        ,T2.IdKho
	                                        ,T2.SL
                                            ,T.TenThuoc
                                            

                                        FROM thuoc T
                                        LEFT JOIN THUOC_DINHMUCTONKHO T2 ON  (SELECT TOP 1 IDDINHMUC FROM THUOC_DINHMUCTONKHO WHERE idthuoc=T.idthuoc AND IDKHO=" + idkho + @")=T2.IDDINHMUC
                                        where 1=1
                                        and IsThuocBV=1";
                                        
        if(loaithuocid!=null &&loaithuocid!="")
            sqlSelect+=@" and LoaiThuocID="+loaithuocid;
        if(cateid!=null &&cateid!="")
            sqlSelect+=@" and CateID="+cateid;

        if (idthuoc != null && idthuoc != "")
            sqlSelect += @" and T.idthuoc=" + idthuoc;


        DataTable table = process.Search(sqlSelect);
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Idthuoc") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    html += "<td><input mkv='true' id='Idthuoc' type='hidden' value='" + table.Rows[i]["Idthuoc"] + "'/><input mkv='true' id='mkv_Idthuoc' type='text' value='" + table.Rows[i]["tenthuoc"] + "' onfocus='IdthuocSearch(this);' class=\"down_select\" style='width:90%'/></td>";
                    html += "<td><input mkv='true' id='SL' type='text' value='" + table.Rows[i]["SL"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["IdDinhMuc"] + "'/></td>";
                    html += "</tr>";
                }
            }
            else
            {
                html += "<tr>";
                html += "<td>1</td>";
                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                html += "<td><input mkv='true' id='Idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_Idthuoc' type='text' value='' onfocus='IdthuocSearch(this);' class=\"down_select\" style='width:90%'/></td>";
                html += "<td><input mkv='true' id='SL' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                html += "</tr>";
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }
}
 
 

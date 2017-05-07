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

public partial class zKiemDuyet_ajax : System.Web.UI.Page
{
    protected DataProcess s_zKiemDuyet()
    {
        DataProcess zKiemDuyet = new DataProcess("zKiemDuyet");
        zKiemDuyet.data("idKiemDuyet", Request.QueryString["idkhoachinh"]);
        zKiemDuyet.data("NGAYYC", Request.QueryString["NGAYYC"]);
        zKiemDuyet.data("NGAYDUYET", Request.QueryString["NGAYDUYET"]);
        zKiemDuyet.data("KHOYC", Request.QueryString["KHOYC"]);
        zKiemDuyet.data("TENTHUOC", Request.QueryString["TENTHUOC"]);
        zKiemDuyet.data("IDTHUOC", Request.QueryString["IDTHUOC"]);
        zKiemDuyet.data("SOPHIEUYC", Request.QueryString["SOPHIEUYC"]);
        zKiemDuyet.data("TENDVT", Request.QueryString["TENDVT"]);
        zKiemDuyet.data("SOLUONGYC", Request.QueryString["SOLUONGYC"]);
        zKiemDuyet.data("SOLUONGDUYET", Request.QueryString["SOLUONGDUYET"]);
        zKiemDuyet.data("THUCXUAT", Request.QueryString["THUCXUAT"]);
        zKiemDuyet.data("ISDUYETPHAT", Request.QueryString["ISDUYETPHAT"]);
        return zKiemDuyet;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SavezKiemDuyet(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": XoazKiemDuyet(); break;
            case "TimKiem": TimKiem(); break;
            case "KHOYCSearch": KHOYCSearch(); break;
            case "IDTHUOCSearch": IDTHUOCSearch(); break;
        }
    }

    private void KHOYCSearch()
    {
        DataTable table = DataProcess.GetTable("select * from khothuoc  where tenkho like N'%" + Request.QueryString["q"] + "%'");
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
    private void IDTHUOCSearch()
    {
        DataTable table = DataProcess.GetTable("select * from thuoc  where  isthuocBV=1 and tenthuoc like N'%" + Request.QueryString["q"] + "%'");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenthuoc"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoazKiemDuyet()
    {
        try
        {
            DataProcess process = s_zKiemDuyet();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idKiemDuyet"));
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
        if (StaticData.HavePermision(this, "zKiemDuyet_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 idkhoachinh=T.idKiemDuyet,T.*
                   ,mkv_KHOYC = A.tenkho
                   ,mkv_IDTHUOC = B.tenthuoc
                               from zKiemDuyet T
                    left join khothuoc  A on T.KHOYC=A.idkho
                    left join thuoc  B on T.IDTHUOC=B.idthuoc
 where T.idKiemDuyet ='" + idkhoachinh + "'");
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }

    private void SavezKiemDuyet()
    {
        try
        {
            DataProcess process = s_zKiemDuyet();
            if (!string.IsNullOrEmpty(process.getData("idKiemDuyet")))
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idKiemDuyet"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idKiemDuyet"));
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
        DataProcess process = s_zKiemDuyet();
        process.EnablePaging = false;
        #region truy van bao  cao
        string where = @" 
            and B.NGAYDUYET>='" + (!string.IsNullOrEmpty(StaticData.CheckDate(Request.QueryString["TUNGAY"])) ? StaticData.CheckDate(Request.QueryString["TUNGAY"]) : DateTime.Now.ToString("yyyy-MM-dd")) 
            + " "+Request.QueryString["TUGIO"]+@"'
            and B.NGAYDUYET<='" + (!string.IsNullOrEmpty(StaticData.CheckDate(Request.QueryString["DENNGAY"])) ? StaticData.CheckDate(Request.QueryString["DENNGAY"]) : DateTime.Now.ToString("yyyy-MM-dd"))
            + " " + (!string.IsNullOrEmpty(Request.QueryString["DENGIO"])?Request.QueryString["TUGIO"]: "23:59:59") + "'";
        if (!string.IsNullOrEmpty(Request.QueryString["SOPHIEUYC"]))
            where += @"
            and B.SoPhieuYc='" + Request.QueryString["SOPHIEUYC"] + "'";
        if (!string.IsNullOrEmpty(Request.QueryString["KHOYC"]))
            where += @"
            and B.IdKhoYc='" + Request.QueryString["KHOYC"] + "'";
        if (!string.IsNullOrEmpty(Request.QueryString["IDTHUOC"]))
            where += @"
            and a.idthuoc='" + Request.QueryString["IDTHUOC"] + "'";
        string sql = @"delete zkiemduyet
                insert into zkiemduyet
                SELECT B.NGAYYC
	                ,NGAYDUYET
	                ,idkhoyc
	                ,TENTHUOC
	                ,A.idthuoc
	                ,SOPHIEUYC
	                ,TENDVT
	                ,SOLUONGYC
	                ,SOLUONGDUYET
	                ,THUCXUAT=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUYEUCAUXUATKHO=A.IDCHITIETYC),0)
	                ,ISDUYETPHAT=isnull(B.ISDUYETPHAT,0)
	                ,E.TENKHO
                FROM YC_PHIEUYCXUATCHITIET A
	                LEFT JOIN YC_PHIEUYCXUAT B ON A.IDPHIEUYC=B.IDPHIEUYC
	                LEFT JOIN THUOC C ON A.IDTHUOC=C.IDTHUOC
	                LEFT JOIN THUOC_DONVITINH D ON C.IDDVT=D.ID
	                LEFT JOIN KHOTHUOC E ON B.IDKHOYC=E.IDKHO
                where B.IDKHODUYET=4
                    AND A.ISDUYETIN=1
                    AND ( SOLUONGYC<>ISNULL(SOLUONGDUYET,0)
                        OR ISNULL(SOLUONGDUYET,0)<>ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUYEUCAUXUATKHO=A.IDCHITIETYC),0)
                       )" + where;
        bool ok = DataAcess.Connect.ExecSQL(sql);
        #endregion
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idKiemDuyet),T.*,NGAYDUYET103=convert(varchar(10),NGAYDUYET,103)+' '+convert(varchar(10),NGAYDUYET,108)
                               from zKiemDuyet T ");
        string head = "\"\":\"\""
            + ",\"NGAYYC\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYYC") + "\""
            + ",\"NGAYDUYET\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYDUYET") + "\""
            + ",\"TENKHO\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENKHO") + "\""
            + ",\"TENTHUOC\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENTHUOC") + "\""
            + ",\"IDTHUOC\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("IDTHUOC") + "\""
            + ",\"SOPHIEUYC\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("SOPHIEUYC") + "\""
            + ",\"TENDVT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENDVT") + "\""
            + ",\"SOLUONGYC\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("SOLUONGYC") + "\""
            + ",\"SOLUONGDUYET\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("SOLUONGDUYET") + "\""
            + ",\"THUCXUAT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("THUCXUAT") + "\""
            + ",\"ISDUYETPHAT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISDUYETPHAT") + "\""
   + "";
        Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, head));
    }
}



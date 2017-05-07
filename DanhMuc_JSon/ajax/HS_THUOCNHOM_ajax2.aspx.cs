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
public partial class HS_THUOCNHOM_ajax : System.Web.UI.Page
{
    protected DataProcess s_HS_THUOCNHOM()
    {
        DataProcess HS_THUOCNHOM = new DataProcess("HS_THUOCNHOM");
        HS_THUOCNHOM.data("IDTHUOCNHOM", Request.QueryString["idkhoachinh"]);
        HS_THUOCNHOM.data("IDTHUOC", Request.QueryString["IDTHUOC"]);
        HS_THUOCNHOM.data("CATEID", Request.QueryString["CATEID"]);
        HS_THUOCNHOM.data("IDNHOMTHUOC", Request.QueryString["IDNHOMTHUOC"]);
        HS_THUOCNHOM.data("TTHOATCHAT1", Request.QueryString["TTHoatChat"]);
        return HS_THUOCNHOM;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_HS_THUOCNHOM(); break;
            case "xoa": Xoa_HS_THUOCNHOM(); break;
            case "TimKiem": TimKiem(); break;
            case "IDTHUOCSearch": IDTHUOCSearch(); break;
            case "CATEIDSearch": CATEIDSearch(); break;
            case "IDNHOMTHUOCSearch": IDNHOMTHUOCSearch(); break;
        }
    }
    private void IDTHUOCSearch()
    {
        string TenThuoc = Request.QueryString["q"].ToString();
        string LoaiThuocID = Request.QueryString["IdLoaiThuoc"].ToString();
        string sqlSelectThuoc = "SELECT * FROM THUOC WHERE ISTHUOCBV=1 AND TENTHUOC LIKE N'" + TenThuoc + "%'";
        if (LoaiThuocID != "")
            sqlSelectThuoc += " AND LoaiThuocID=" + LoaiThuocID;
        sqlSelectThuoc += " ORDER BY TENTHUOC";

        DataTable table = DataAcess.Connect.GetTable(sqlSelectThuoc);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenThuoc"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void CATEIDSearch()
    {
        string value = Request.QueryString["q"];
        DataTable table = DataProcess.GetTable("select * from category WHERE LOAITHUOCID=1 " + (value != null && value != "" ? " AND CATENAME LIKE N'%" + value + "%'" : ""));
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["catename"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IDNHOMTHUOCSearch()
    {
        string value = Request.QueryString["q"];
        string cateid = Request.QueryString["cateid"];
        DataTable table = DataProcess.GetTable("select T.* from nhomthuoc T LEFT JOIN CATEGORY T1 ON T.CATEID=T1.CATEID WHERE T1.LOAITHUOCID=1 "
            + (value != null && value != "" ? " AND TENNHOM LIKE N'%" + value + "%'" : "")
            + (cateid != null && cateid != "" ? " AND T.CATEID=" + cateid : ""));
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tennhom"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoa_HS_THUOCNHOM()
    {
        try
        {
            DataProcess process = s_HS_THUOCNHOM();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IDTHUOCNHOM"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_HS_THUOCNHOM()
    {
        try
        {
            DataProcess process = s_HS_THUOCNHOM();
            if (process.getData("IDTHUOCNHOM") != null && process.getData("IDTHUOCNHOM") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDTHUOCNHOM"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDTHUOCNHOM"));
                    return;
                }
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }
    }
    private void TimKiem()
    {
        bool search = Userlogin_new.HavePermision(this, "HS_THUOCNHOM_search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "HS_THUOCNHOM_add");
            bool delete = Userlogin_new.HavePermision(this, "HS_THUOCNHOM_del");
            bool edit = Userlogin_new.HavePermision(this, "HS_THUOCNHOM_edit");
            DataProcess process = s_HS_THUOCNHOM();
            process.EnablePaging = false;
            string sqlSelect = @"select STT=row_number() over (order by A.TENTHUOC),T.*
                           ,A.TENTHUOC
                           ,B.catename
                           ,C.tennhom
                                       from HS_THUOCNHOM T
                            left join thuoc  A on T.IDTHUOC=A.idthuoc
                            left join category  B on T.CATEID=B.cateid
                            left join nhomthuoc  C on T.IDNHOMTHUOC=C.idnhomthuoc
                  where 1=1";
            string IDTHUOC_CRT = Request.QueryString["IDTHUOC_CRT"];
            string CATEID_CRT = Request.QueryString["CATEID_CRT"];
            string IDNHOMTHUOC_CRT = Request.QueryString["IDNHOMTHUOC_CRT"];
            if (IDTHUOC_CRT != null && IDTHUOC_CRT != "")
                sqlSelect += " AND T.IDTHUOC=" + IDTHUOC_CRT;
            if (CATEID_CRT != null && CATEID_CRT != "")
                sqlSelect += " AND T.CATEID=" + CATEID_CRT;
            if (IDNHOMTHUOC_CRT != null && IDNHOMTHUOC_CRT != "")
                sqlSelect += " AND T.IDNHOMTHUOC=" + IDNHOMTHUOC_CRT;
            DataTable table = process.Search(sqlSelect);
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}



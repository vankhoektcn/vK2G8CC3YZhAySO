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

public partial class thuoc_ajax : System.Web.UI.Page
{
    protected DataProcess s_thuoc()
    {
        DataProcess thuoc = new DataProcess("thuoc");
        thuoc.data("idthuoc", Request.QueryString["idkhoachinh"]);
        thuoc.data("TTHoatChat", Request.QueryString["TTHoatChat"]);
        thuoc.data("tenthuoc", Request.QueryString["tenthuoc"]);
        thuoc.data("congthuc", Request.QueryString["congthuc"]);
        thuoc.data("idnhomthuoc", Request.QueryString["idnhomthuoc"]);
        thuoc.data("iddvt", Request.QueryString["iddvt"]);
        thuoc.data("LoaiThuocID", Request.QueryString["LoaiThuocID"]);
        thuoc.data("TTHoatChat", Request.QueryString["TTHoatChat"]);
        thuoc.data("IsThuocBV", Request.QueryString["IsThuocBV"]);
        thuoc.data("CateID", Request.QueryString["CateID"]);
        thuoc.data("IsNgoaiTru", Request.QueryString["IsNgoaiTru"]);
        thuoc.data("sudungchobh", Request.QueryString["sudungchobh"]);
        thuoc.data("IsThuocBV", "1");
        return thuoc;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_thuoc(); break;
            case "TimKiem": TimKiem(); break;
            case "CateIDSearch": CateIDSearch(); break;
            case "IDNHOMTHUOCSearch": IDNHOMTHUOCSearch(); break;
            case "TenThuocSearch": TenThuocSearch(); break;
        }
    }
    private void LuuTable_thuoc()
    {
        try
        {
            DataProcess process = s_thuoc();
            if (process.getData("idthuoc") != null && process.getData("idthuoc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idthuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idthuoc"));
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
        bool search = Userlogin_new.HavePermision(this, "thuoc_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "thuoc_Add");
            bool delete = Userlogin_new.HavePermision(this, "thuoc_Delete");
            bool edit = Userlogin_new.HavePermision(this, "thuoc_Edit");
            DataProcess process = s_thuoc();
            process.EnablePaging = false;
            string CateID = Request.QueryString["CateID"];
            string IDNHOMTHUOC = Request.QueryString["IDNHOMTHUOC"];
            string IDTHUOC = Request.QueryString["IDTHUOC"];
            string SQL = null;
            if ((CateID == null || CateID == "") && (IDNHOMTHUOC == null || IDNHOMTHUOC == ""))
                SQL = @"select STT=row_number() over (order by congthuc,tenthuoc)
,T.*,B.TENDVT,C.TENNHOM
                               from thuoc T LEFT JOIN THUOC_DONVITINH B ON T.IDDVT=B.ID
                                            LEFT JOIN NHOMTHUOC C ON T.IDNHOMTHUOC=C.IDNHOMTHUOC
                                where " + process.sWhere();
            else
            {
                SQL = @"SELECT STT= row_number() over(order by congthuc,tenthuoc)
                      ,T.*,B.TENDVT
                    FROM HS_THUOCNHOM T1
                      LEFT JOIN THUOC T ON T.IDTHUOC=T1.IDTHUOC
                      LEFT JOIN CATEGORY T2 ON T1.CATEID=T2.CATEID
                      LEFT JOIN NHOMTHUOC T3 ON T1.IDNHOMTHUOC=T3.IDNHOMTHUOC
                      LEFT JOIN THUOC_DONVITINH B ON T.IDDVT=B.ID
                      WHERE 1=1  ";
                if (CateID != null && CateID != "")
                    SQL += " AND T1.CATEID=" + CateID;
                if (IDNHOMTHUOC != null && IDNHOMTHUOC != "")
                    SQL += " AND T1.IDNHOMTHUOC=" + IDNHOMTHUOC;
                if (IDTHUOC != null && IDTHUOC != "")
                    SQL += " AND T1.IDTHUOC=" + IDTHUOC;


            }
            DataTable table = process.Search(SQL);
            Response.Clear();
            string kj = DataProcess.JSONDataTable_Parameters(table, add, edit, delete);
            Response.Write(kj);
        }
        else
        {

            Response.Clear();
            Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
    private void CateIDSearch()
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
        string CateID = Request.QueryString["cateid"];
        if (CateID == "undefined") CateID = "";
        string TenNhom = Request.QueryString["q"].ToString();
        string SQL = @"SELECT * FROM NHOMTHUOC WHERE 1=1";
        if (CateID != null && CateID != "")
        {
            SQL += "AND CATEID=" + CateID;
        }
        if (TenNhom != null && TenNhom != "")
        {
            SQL += "AND TENNHOM LIKE N'%" + TenNhom + "%' ORDER BY TENNHOM ";
        }
        DataTable table = DataAcess.Connect.GetTable(SQL);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][3].ToString() + "|" + table.Rows[i][0].ToString());
                }
            }
        }
        Response.Clear();
        Response.Write(html);
    }
    private void TenThuocSearch()
    {
        string IDNHOMTHUOC = Request.QueryString["idnhomthuoc"];
        string LOAITHUOCID = Request.QueryString["LOAITHUOCID"];
        string CATEID = Request.QueryString["CATEID"];
        string sqlSelect = " SELECT * FROM THUOC WHERE ISNULL(ISTHUOCBV,0)=1";
        string tenThuoc = Request.QueryString["q"];
        if (tenThuoc != null && tenThuoc != "")
            sqlSelect += " AND TENTHUOC LIKE N'" + tenThuoc + "%'";
        if (IDNHOMTHUOC != null && IDNHOMTHUOC != "")
            sqlSelect += " AND IDNHOMTHUOC=" + IDNHOMTHUOC;
        if (IDNHOMTHUOC != null && IDNHOMTHUOC != "")
            sqlSelect += " AND LOAITHUOCID=" + LOAITHUOCID;
        if (CATEID != null && CATEID != "")
            sqlSelect += " AND CATEID=" + CATEID;
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
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
}



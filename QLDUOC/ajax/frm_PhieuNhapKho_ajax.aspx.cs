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

public partial class frm_PhieuNhapKho_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "ChonSanPham": ChonSanPham(); break;
            case "ChonSanPham2": ChonSanPham2(); break;
            case "ChonNhomSanPham": ChonNhomSanPham(); break;
            case "ChonHoatChat": ChonHoatChat(); break;
        }
    }
    private void ChonSanPham()
    {
        ChonSanPham2();
    }
    private void ChonSanPham2()
    {
        string sql = "";
        if (Request.QueryString["q"] != null)
        {
            sql = "and a.tenthuoc like N'" + Request.QueryString["q"] + "%'";
        }
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        if (LoaiThuocID != null && LoaiThuocID != "")
        {
            if (int.Parse(LoaiThuocID) == 0)
            {
                sql += "";
            }
            else
            {
                sql += " and a.LoaiThuocID=" + LoaiThuocID;
            }
        }

        string sqlThuoc = @"SELECT	B.idthuoc
                                    ,B.tenthuoc
                                    ,B.sttindm05
                                    ,B.iddvt
                                    ,B.congthuc
                                    ,B.TTHoatChat
                                   
                                    ,C.TenDVt

                            FROM 
                            (
                            SELECT   DISTINCT TOP 20 tenthuoc
                            ,(SELECT top 1 idthuoc from thuoc where tenthuoc=A.tenthuoc AND ISTHUOCBV=1 order by idthuoc) as IdThuoc
                            from thuoc a
                            where IsThuocBV=1 "
                          + sql
                          + @"
                            )
                             AS A
                            LEFT JOIN thuoc B ON A.IdThuoc=B.idthuoc
                            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                            WHERE 1=1 AND B.ISTHUOCBV=1  ORDER BY B.TENTHUOC,B.TTHOATCHAT,B.CONGTHUC";



        string html = "";
        DataTable table = DataAcess.Connect.GetTable(sqlThuoc);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += table.Rows[i][1] + Environment.NewLine;
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void ChonNhomSanPham()
    {
        string sql = "";
        if (Request.QueryString["q"] != null)
        {
            sql = "catename like N'%" + Request.QueryString["q"] + "%'";
        }
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        if (LoaiThuocID != null && LoaiThuocID != "")
        {
            sql += " and LoaiThuocID=" + LoaiThuocID;
        }
        string html = "";
        DataTable table = DataAcess.Connect.GetTable("select top 20 cateid,catename from category where  " + sql + " order by catename ");
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += table.Rows[i][1] + Environment.NewLine;
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void ChonHoatChat()
    {
        string sql = "";
        if (Request.QueryString["q"] != null)
        {
            sql = "congthuc like N'%" + Request.QueryString["q"] + "%'";
        }
        string CateName = Request.QueryString["CateName"];
        if (CateName != null && CateName != "")
        {
            sql += " AND CATEID IN (SELECT CATEID FROM CATEGORY WHERE CATENAME LIKE N'%" + CateName + "%')";
        }
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        if (LoaiThuocID != null && LoaiThuocID != "")
        {
            sql += " and LoaiThuocID=" + LoaiThuocID;
        }
        string html = "";
        DataTable table = DataAcess.Connect.GetTable("select top 20 idthuoc,congthuc from thuoc where  " + sql + " and isthuocbv=1 order by congthuc ");
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += table.Rows[i][1] + Environment.NewLine;
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
}



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

public partial class Yc_PhieuYCXuat_ajax : System.Web.UI.Page
{
    protected DataProcess s_Yc_PhieuYCXuat()
    {
        DataProcess Yc_PhieuYCXuat = new DataProcess("Yc_PhieuYCXuat");
        Yc_PhieuYCXuat.data("IdPhieuYc", Request.QueryString["idkhoachinh"]);
        Yc_PhieuYCXuat.data("SoPhieuYc", Request.QueryString["SoPhieuYc"]);
        Yc_PhieuYCXuat.data("NgayYc", Request.QueryString["NgayYc"]);
        Yc_PhieuYCXuat.data("IdKhoYc", Request.QueryString["IdKhoYc"]);
        Yc_PhieuYCXuat.data("IdKhoDuyet", Request.QueryString["IdKhoDuyet"]);
        Yc_PhieuYCXuat.data("IdNguoiYc", Request.QueryString["IdNguoiYc"]);
        Yc_PhieuYCXuat.data("IdNguoiDuyet", Request.QueryString["IdNguoiDuyet"]);
        Yc_PhieuYCXuat.data("NgayDuyet", Request.QueryString["NgayDuyet"]);
        Yc_PhieuYCXuat.data("IsDuyetIn", Request.QueryString["IsDuyetIn"]);
        Yc_PhieuYCXuat.data("IsDuyetPhat", Request.QueryString["IsDuyetPhat"]);
        Yc_PhieuYCXuat.data("LoaiThuocID", Request.QueryString["LoaiThuocID"]);
        Yc_PhieuYCXuat.data("Status", Request.QueryString["Status"]);
        return Yc_PhieuYCXuat;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveYc_PhieuYCXuat(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": XoaYc_PhieuYCXuat(); break;
            case "TimKiem": TimKiem(); break;
            case "IdKhoYcSearch": IdKhoYcSearch(); break;
            case "IdKhoDuyetSearch": IdKhoDuyetSearch(); break;
            case "IdNguoiYcSearch": IdNguoiYcSearch(); break;
            case "IdNguoiDuyetSearch": IdNguoiDuyetSearch(); break;
            case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
            case "TenThuocSearch": TenThuocSearch(); break;
            case "setDefault": setDefault(); break;

        }
    }
    private void setDefault()
    {
        string sql = "select TuNgay=convert(varchar(10),getdate(),103),DenNgay=convert(varchar(10),getdate(),103),perDuyetPhat='" + Userlogin_new.HavePermision(this, "xetduyet1") + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                html.AppendLine("<data id=\"" + dt.Columns[i].ColumnName + "\">" + dt.Rows[0][i].ToString() + "</data>");
            }
            html.AppendLine("</root>");
            Response.Clear();
            Response.Write(html);
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("");
        }
    }
    private void IdKhoYcSearch()
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
    private void IdKhoDuyetSearch()
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
    private void IdNguoiYcSearch()
    {
        DataTable table = DataProcess.GetTable("select * from nguoidung  where tennguoidung like N'%" + Request.QueryString["q"] + "%'");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tennguoidung"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdNguoiDuyetSearch()
    {
        DataTable table = DataProcess.GetTable("select * from nguoidung  where tennguoidung like N'%" + Request.QueryString["q"] + "%'");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tennguoidung"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void LoaiThuocIDSearch()
    {
        DataTable table = DataProcess.GetTable("select * from Thuoc_LoaiThuoc  where TenLoai like N'%" + Request.QueryString["q"] + "%'");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenLoai"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaYc_PhieuYCXuat()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYCXuat();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdPhieuYc"));
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
        if (Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 idkhoachinh=T.IdPhieuYc,T.*
                   ,mkv_IdKhoYc = A.tenkho
                   ,mkv_IdKhoDuyet = B.tenkho
                   ,mkv_IdNguoiYc = C.tennguoidung
                   ,mkv_IdNguoiDuyet = D.tennguoidung
                   ,mkv_LoaiThuocID = E.TenLoai
                               from Yc_PhieuYCXuat T
                    left join khothuoc  A on T.IdKhoYc=A.idkho
                    left join khothuoc  B on T.IdKhoDuyet=B.idkho
                    left join nguoidung  C on T.IdNguoiYc=C.idnguoidung
                    left join nguoidung  D on T.IdNguoiDuyet=D.idnguoidung
                    left join Thuoc_LoaiThuoc  E on T.LoaiThuocID=E.LoaiThuocID
 where T.IdPhieuYc ='" + idkhoachinh + "'");
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }

    private void SaveYc_PhieuYCXuat()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYCXuat();
            if (!string.IsNullOrEmpty(process.getData("IdPhieuYc")))
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdPhieuYc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdPhieuYc"));
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
        if (Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Search"))
        {
            DataProcess process = s_Yc_PhieuYCXuat();
            process.EnablePaging = false;
            string tungayFull = "";
            string dengayFull = "";
            string TuNgay = Request.QueryString["TuNgay"];
            string TuGio = Request.QueryString["TuGio"];
            string TuPhut = Request.QueryString["TuPhut"];
            string DenNgay = Request.QueryString["DenNgay"];
            string DenGio = Request.QueryString["DenGio"];
            string DenPhut = Request.QueryString["DenPhut"];
            if (TuGio == null || TuGio == "") TuGio = "00";
            if (TuPhut == null || TuPhut == "") TuPhut = "00";
            if (DenGio == null || DenGio == "") TuGio = "23";
            if (DenPhut == null || DenPhut == "") TuPhut = "59";
            if (TuNgay != null && TuNgay != "")
            {
                TuNgay = StaticData.CheckDate(TuNgay) + " " + TuGio + ":" + TuPhut + ":00";
                tungayFull = " AND  T.NGAYDUYET IS NOT NULL AND  T.NGAYDUYET>='" + TuNgay + "'";
            }
            if (DenNgay != null && DenNgay != "")
            {
                DenNgay = StaticData.CheckDate(DenNgay) + " " + DenGio + ":" + DenPhut + ":00";
                dengayFull = " AND  T.NGAYDUYET IS NOT NULL AND  T.NGAYDUYET<='" + DenNgay + "'";
            }
            string IdThuoc = Request.QueryString["IdThuoc"];
            string tenthuocIn = (!string.IsNullOrEmpty(IdThuoc) ? " and exists( select IdChiTietYc from Yc_PhieuYcXuatChiTiet ctyc  where IdThuoc ='" + IdThuoc + "' and idphieuyc=t.idphieuyc)" : "");
            string sql = @"select STT=row_number() over (order by T.IdPhieuYc),T.*
                   ,NGAYYC_VIEW=CONVERT(NVARCHAR(20),T.NGAYYC,103)+' ' + LEFT( CONVERT(NVARCHAR(20),T.NGAYYC,108),5)
                   ,NGAYDUYET_VIEW= CONVERT(NVARCHAR(20),T.NGAYDUYET,103)+' ' + LEFT( CONVERT(NVARCHAR(20),T.NGAYDUYET,108),5) 
                   ,KhoYeuCau=A.tenkho
                   ,KhoDuyet=B.tenkho
                   ,NguoiYeuCau=C.tennguoidung
                   ,NguoiDuyet=D.tennguoidung
                   ,TenLoai=(CASE WHEN T.LOAITHUOCID=5 THEN N'Thuốc GN' ELSE (CASE WHEN T.LOAITHUOCID=6 THEN N'Thuốc HTT' ELSE E.TENLOAI END) END)
                    ,px.maphieuxuat
                    ,px.IDPHIEUXUAT
                    ,T.IsTheoCD
                               from Yc_PhieuYCXuat T
                    left join PHIEUXUATKHO px on px.idphieuxuat = T.idphieuxuat
                    left join khothuoc  A on T.IdKhoYc=A.idkho
                    left join khothuoc  B on T.IdKhoDuyet=B.idkho
                    left join nguoidung  C on T.IdNguoiYc=C.idnguoidung
                    left join nguoidung  D on T.IdNguoiDuyet=D.idnguoidung
                    left join Thuoc_LoaiThuoc  E on T.LoaiThuocID=E.LoaiThuocID
          where " + process.sWhere() + @"
                " + tenthuocIn + @"
                " + tungayFull + dengayFull;
            DataTable table = process.Search(sql);
            string head = "\"\":\"\""
                + ",\"SOPHIEUYC\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoPhieuYc") + "\""
                + ",\"NGAYYC_VIEW\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày YC") + "\""
                + ",\"IDKHOYC\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("Kho YC") + "\""
                + ",\"IDKHODUYET\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("Kho duyệt") + "\""
                + ",\"IDNGUOIYC\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("Người YC") + "\""
                + ",\"IDNGUOIDUYET\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("Người duyệt") + "\""
                + ",\"NGAYDUYET_VIEW\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày duyệt") + "\""
                + ",\"ISDUYETIN\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("Duyệt in?") + "\""
                + ",\"ISDUYETPHAT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("Duyệt phát?") + "\""
                + ",\"LOAITHUOCID\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID") + "\""
                + ",\"MAPHIEUXUAT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat") + "\""
                + ",\"IsTheoCD\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsTheoCD") + "\""

       + "";
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, head));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }


    private void TenThuocSearch()
    {
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string sqlSelect = " SELECT * FROM THUOC WHERE ISTHUOCBV=1";
        string tenThuoc = Request.QueryString["q"];
        if (tenThuoc != null && tenThuoc != "")
            sqlSelect += " AND TENTHUOC LIKE N'" + tenThuoc + "%'";
        if (LoaiThuocID != null && LoaiThuocID != "")
            sqlSelect += " AND LOAITHUOCID=" + LoaiThuocID;

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


}//



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
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveHS_CLS_View(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": XoaHS_CLS_View(); break;
            case "TimKiem": TimKiem(); break;
            case "PHATTHUOC": PHATTHUOC(); break;
            case "SetDefaultData": SetDefaultData(); break;
        }
    }
    
    private void XoaHS_CLS_View()
    {
        try
        {
            DataProcess process = s_HS_CLS_View();
            bool ok = process.Delete();
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
    private void setTimKiem()
    {
        if (StaticData.HavePermision(this, "HS_CLS_View_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataAcess.Connect.GetTable("SELECT * FROM HS_CLS_View WHERE IDTOATHUOC="+ idkhoachinh);
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
    private void PHATTHUOC()
    {
        string idkhambenh = Request.QueryString["idkhambenh"];
        DataTable dt = DataAcess.Connect.GetTable("SELECT * FROM HS_CLS_View WHERE idkhambenh=" + idkhambenh );
        if (dt == null) return;
        string idkhoachinh = null;
        if (dt.Rows.Count > 0) idkhoachinh = dt.Rows[0][0].ToString();
        else
        {
            string sqlMaxIdToathuoc = "SELECT MAX(IdToaThuoc) FROM HS_CLS_View";
            DataTable dtIdToaThuoc = DataAcess.Connect.GetTable(sqlMaxIdToathuoc);
            if (dtIdToaThuoc == null) return;
            if (dtIdToaThuoc.Rows.Count == 0 || dtIdToaThuoc.Rows[0][0].ToString() == "0" || dtIdToaThuoc.Rows[0][0].ToString() == "")
                idkhoachinh = "1";
            else
                idkhoachinh = (int.Parse(dtIdToaThuoc.Rows[0][0].ToString()) + 1).ToString();

            string sqlSave = @"
                                  INSERT INTO HS_CLS_View(IdToaThuoc,NGAYTOA,IDBENHNHAN,MABN,HOTENBN,NGAYSINH,GIOITINH,SOBHYT,DUNGTUYEN)
                                  select DISTINCT IdToaThuoc=" + idkhoachinh
                                           + @",NGAYTOA= A.ngaykham
                                            , A.IDBENHNHAN
                                            , MABN=B.MABENHNHAN
                                            ,HOTENBN=B.TENBENHNHAN
                                            ,NGAYSINH=B.NGAYSINH
                                            ,GIOITINH=DBO.GETGIOITINH(B.GIOITINH)
                                            ,SOBHYT=bhyt.SOBHYT
                                            ,DUNGTUYEN=BHYT.IsDUNGTUYEN
                                            FROM KHAMBENH A
                                            LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                            left join dangkykham dkk on A.iddangkykham=dkk.iddangkykham
                                            left join benhnhan_bhyt bhyt on dkk.idbenhnhan_bh=bhyt.idbenhnhan_bh
                                            LEFT JOIN KB_PHONG C ON ISNULL(A.PHONGID,A.IDPHONG)=C.ID
                                            WHERE DKK.LOAIKHAMID=1   
                                            AND A.IsHaveCLS=1
                                            AND ISNULL(A.ISCHECKCLS,0)=0
                                            AND ISNULL( A.ISHAVETHUOCBH,0)=0
                                            AND ( A.IDPHONGKHAMBENH=1 OR ( A.IDPHONGKHAMBENH=3 AND ISNULL(C.isPhongNoiTru,0)=0 ))";
            sqlSave += " AND A.idkhambenh =" + idkhambenh;
            bool ok = DataAcess.Connect.ExecSQL(sqlSave);
            if (!ok) return;
        }
        #region Lưu chi tiết đơn thuốc
        string SQLSAVECHITIET = @"
                                                DELETE HS_CLS_ViewDetail WHERE IdToaThuoc=" + idkhoachinh + @"
                                                INSERT INTO HS_CLS_ViewDetail (IdToaThuoc,
                                   
                                                                                    ChiTietBenh,
                                                                                    ChiTietCLS,
                                                                                    IDKHAMBENH
                                                                                   )
                                                
                                                SELECT DISTINCT " + idkhoachinh
                               + @" 
	                                                   ,ChiTietBenh=DBO.HS_CHITIETBENH(A.IDKHAMBENH)
	                                                   ,ChiTietCLS=DBO.HS_CHITIETCANLAMSAN(A.IDKHAMBENH)
                                                       ,A.IDKHAMBENH
                                                FROM KHAMBENH A
                                                LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                                LEFT JOIN KB_PHONG C ON ISNULL(A.PHONGID,A.IDPHONG)=C.ID
                                                left join dangkykham dkk on A.iddangkykham=dkk.iddangkykham
                                                 WHERE DKK.LOAIKHAMID=1   
                                                        AND A.IsHaveCLS=1
                                                        AND ISNULL(A.ISCHECKCLS,0)=0
                                                        AND ISNULL( A.ISHAVETHUOCBH,0)=0
                                                    AND ( A.IDPHONGKHAMBENH=1 OR ( A.IDPHONGKHAMBENH=3 AND ISNULL(C.isPhongNoiTru,0)=0 ))
		                                            AND A.idkhambenh=" + idkhambenh;
        bool ok_detail = DataAcess.Connect.ExecSQL(SQLSAVECHITIET);

        #endregion

        Response.Clear();
        Response.Write(idkhoachinh);

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
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "HS_CLS_View_Search"))
        {
            string NgayToa = Request.QueryString["NgayToa"];
            string MaBN = Request.QueryString["MaBN"];
            string HoTenBN = Request.QueryString["HoTenBN"];
            string SoBHYT = Request.QueryString["SoBHYT"];
            string TuNgay = Request.QueryString["TuNgay"];
            string DenNgay = Request.QueryString["DenNgay"];
            string IsDaXuat = Request.QueryString["IsDaXuat"];

            if (TuNgay != null && TuNgay != "")
            {
                TuNgay = StaticData.CheckDate(TuNgay);
            }
            if (DenNgay != null && DenNgay != "")
            {
                DenNgay = StaticData.CheckDate(DenNgay);

            }

            string sqlSelect = null;
            #region Danh sach thuoc chua xuat
            if (IsDaXuat != "1")
            {
                    sqlSelect = @" 
                                    select DISTINCT idkhambenh,
                                     MABN=B.MABENHNHAN
                                    ,HOTENBN=B.TENBENHNHAN
                                    ,NGAYSINH=B.NGAYSINH
                                    ,GIOITINH=DBO.GETGIOITINH(B.GIOITINH)
                                    ,SOBHYT=BHYT.SOBHYT
                                    ,DUNGTUYEN=BHYT.DUNGTUYEN,A.IDBENHNHAN
                                    ,ISNULL(A.TGXuatVien,A.NGAYKHAM) as NgayToa
                                    FROM   KHAMBENH A 
                                    LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                    LEFT JOIN KB_PHONG C ON ISNULL(A.PHONGID,A.IDPHONG)=C.ID
                                    LEFT JOIN DANGKYKHAM D ON A.IDDANGKYKHAM=D.IDDANGKYKHAM
                                    LEFT JOIN BENHNHAN_BHYT BHYT ON D.IDBENHNHAN_BH=BHYT.IDBENHNHAN_BH
                                    WHERE D.LOAIKHAMID=1   
                                          AND A.IsHaveCLS=1 
                                          AND ISNULL(A.ISCHECKCLS,0)=0
                                          AND ISNULL( A.ISHAVETHUOCBH,0)=0
                                          AND ( A.IDPHONGKHAMBENH=1 OR ( A.IDPHONGKHAMBENH=3 AND ISNULL(C.isPhongNoiTru,0)=0 ))
                                       " + "\r\n";
                if (NgayToa != null && NgayToa != "")
                {
                    NgayToa = StaticData.CheckDate(NgayToa);
                    sqlSelect += " AND ISNULL(A.TGXuatVien,A.NGAYKHAM)>='" + NgayToa + @"'
	                         AND ISNULL(A.TGXuatVien,A.NGAYKHAM)<='" + NgayToa + " 23:59:59'" + "\r\n";
                }

                if (TuNgay != null && TuNgay != "")
                {
                    sqlSelect += " AND ISNULL(A.TGXuatVien,A.NGAYKHAM)>='" + TuNgay + @"'";
                }
                if (DenNgay != null && DenNgay != "")
                {
                    sqlSelect += " AND ISNULL(A.TGXuatVien,A.NGAYKHAM)<='" + DenNgay + @" 23:59:59'";
                }

                if (MaBN != null && MaBN != "")
                    sqlSelect += " AND B.MABENHNHAN LIKE N'%" + MaBN + "%'" + "\r\n";
                if (HoTenBN != null && HoTenBN != "")
                    sqlSelect += " AND B.TENBENHNHAN LIKE N'%" + HoTenBN + "%'" + "\r\n";
                if (SoBHYT != null && SoBHYT != "")
                    sqlSelect += " AND BHYT.SOBHYT LIKE N'%" + SoBHYT + "%'" + "\r\n";
            }
            #endregion
            #region Danh Sach thuoc da xuat
            else
            {
                sqlSelect = @"SELECT T.* FROM HS_CLS_View T WHERE Capthuoc=1";
                if (TuNgay != null && TuNgay != "")
                {
                   
                    sqlSelect += " AND NgayToa>='" + TuNgay + @"'";
                }
                if (DenNgay != null && DenNgay != "")
                {
                    sqlSelect += " AND NgayToa<='" + DenNgay + @" 23:59:59'";
                }

                if (MaBN != null && MaBN != "")
                    sqlSelect += " AND MaBN LIKE N'%" + MaBN + "%'" + "\r\n";
                if (HoTenBN != null && HoTenBN != "")
                    sqlSelect += " AND HoTenBN LIKE N'%" + HoTenBN + "%'" + "\r\n";
                if (SoBHYT != null && SoBHYT != "")
                    sqlSelect += " AND BHYT.SoBHYT LIKE N'%" + SoBHYT + "%'" + "\r\n";
            }
            #endregion
            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaBN") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("HoTenBN") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgaySinh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GioiTinh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoBHYT") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DungTuyen") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (IsDaXuat != "1")
                        {
                            NgayToa = table.Rows[i]["NgayToa"].ToString();
                            html.Append("<tr style='cursor:pointer;' onclick=\"PHATTHUOC('" + table.Rows[i]["idkhambenh"].ToString() + "','" + NgayToa + "',this)\">");
                        }
                        else
                            html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["IdToaThuoc"].ToString() + "')\">");

                        html.Append("<td>" + (i + 1).ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["MaBN"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["HoTenBN"].ToString() + "</td>");
                        if (table.Rows[i]["NgaySinh"].ToString() != "")
                        {
                            html.Append("<td>" + table.Rows[i]["NgaySinh"].ToString() + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["NgaySinh"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["GioiTinh"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["SoBHYT"].ToString() + "</td>");
                        html.Append("<td><input type='checkbox' disabled='true' " + (StaticData.IsCheck(table.Rows[i]["DungTuyen"].ToString()) == true ? "checked" : "") + "/></td>");
                        html.Append("</tr>");
                    }
                }
            }
            html.Append("</table>");
            Response.Clear(); Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }//end void
    private void SetDefaultData()
    {
        StringBuilder html = new StringBuilder();
        html.AppendLine("<root>");
        html.AppendLine("<data id=\"NgayToa\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"TuNgay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"DenNgay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("</root>");
        Response.Clear();
        Response.Write(html.ToString().Replace("&", "&amp;"));
    }
}//end class



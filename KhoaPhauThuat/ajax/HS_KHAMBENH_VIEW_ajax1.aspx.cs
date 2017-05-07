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
public partial class HS_KHAMBENH_VIEW_ajax1 : System.Web.UI.Page
{
    protected DataProcess s_HS_KHAMBENH_VIEW()
    {
        DataProcess HS_KHAMBENH_VIEW = new DataProcess("HS_KHAMBENH_VIEW");
        HS_KHAMBENH_VIEW.data("IdToaThuoc", Request.QueryString["idkhoachinh"]);
        HS_KHAMBENH_VIEW.data("DenNgay", Request.QueryString["DenNgay"]);
        HS_KHAMBENH_VIEW.data("IdBenhNhan", Request.QueryString["IdBenhNhan"]);
        HS_KHAMBENH_VIEW.data("IdKhoa", Request.QueryString["IdKhoa"]);
        return HS_KHAMBENH_VIEW;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "SetDefaultData": SetDefaultData(); break;
            case "TimKiem": TimKiem(); break;
            case "CHITIETDIEUTRI": CHITIETDIEUTRI(); break;

        }
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void SetDefaultData()
    {
        StringBuilder html = new StringBuilder();
        html.AppendLine("<root>");
        html.AppendLine("<data id=\"NgayKham\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"TuNgay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"DenNgay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("</root>");
        Response.Clear();
        Response.Write(html.ToString().Replace("&", "&amp;"));
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "HS_KHAMBENH_VIEW_Search"))
        {
            string MaBN = Request.QueryString["MaBN"];
            string HoTenBN = Request.QueryString["HoTenBN"];
            string SoBHYT = Request.QueryString["SoBHYT"];
            string DenNgay = Request.QueryString["DenNgay"];
            if (DenNgay == null || DenNgay == "")
                DenNgay = DateTime.Now.ToString("dd/MM/yyyy");

            string TuNgay = Request.QueryString["TuNgay"];
            if (TuNgay == null || TuNgay == "")
                TuNgay = DateTime.Now.ToString("dd/MM/yyyy");

            string IdKhoa = Request.QueryString["IdKhoa"];
            if (IdKhoa == null || IdKhoa == "") IdKhoa = "22";
            string IsAll = Request.QueryString["IsAll"];
            if (IsAll == null || IsAll == "") IsAll = "1";


            string sqlSelect = null;
            sqlSelect = @"select DISTINCT
                                B.IDBENHNHAN
                                ,A.IDCHITIETDANGKYKHAM     
                                ,MABN=B.MABENHNHAN
                                ,HOTENBN=B.TENBENHNHAN
                                ,NGAYSINH=B.NGAYSINH
                                ,GIOITINH=DBO.GETGIOITINH(B.GIOITINH)
                                ,SOBHYT=E.SOBHYT
                                ,DUNGTUYEN=E.DUNGTUYEN,A.IDBENHNHAN,ISNULL(A.TGXuatVien,A.NGAYKHAM) as NgayKham
                                ,IsDaLuu=(CASE WHEN ISNULL(A.IdKhamBenhMoi,0)=0 THEN N'Chưa lưu' else N'Đã lưu' end)"
            + (IsAll == "1" ? "\r\n" + @",DBO.HS_STATUS_KHAMBENH(A.IDKHAMBENH) AS TINHTRANG"
               : "")
            + @"

                                FROM KHAMBENH A
                                LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                LEFT JOIN KB_PHONG C ON ISNULL(A.PHONGID,A.IDPHONG)=C.ID
                                LEFT JOIN DANGKYKHAM D ON A.IDDANGKYKHAM=D.IDDANGKYKHAM
                                LEFT JOIN BENHNHAN_BHYT E ON D.IDBENHNHAN_BH=E.IDBENHNHAN_BH
                                WHERE   IDKHOACHUYEN=" + IdKhoa + @"
                                        AND ISNULL(A.IDKHOA,A.IDPHONGKHAMBENH)=" + IdKhoa;
            if (IsAll == "0")
                sqlSelect += @" AND NOT EXISTS(SELECT TOP 1 IDKHAMBENH FROM KHAMBENH
                                                        WHERE IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM
                                                        AND IDKHAMBENH>=A.IDKHAMBENH
                                                        AND ( ( IsDaChuyenKhoa=1
                                                                AND ISNULL(IDKHOACHUYEN,phongkhamchuyenden)<>" + IdKhoa + @")
                                                              OR ISNULL(IsChuyenVien,0)=1
                                                             )
                                                     )"
                              + "\r\n";
            if (DenNgay != null && DenNgay != "")
            {
                DenNgay = StaticData.CheckDate(DenNgay) + " 23:59:59";
                sqlSelect += " AND ISNULL(A.TGXuatVien,A.NGAYKHAM)<='" + DenNgay + @"'";
            }
            if (TuNgay != null && TuNgay != "")
            {
                TuNgay = StaticData.CheckDate(TuNgay);
                sqlSelect += " AND ISNULL(A.TGXuatVien,A.NGAYKHAM)>='" + TuNgay + @"'";
            }

            if (MaBN != null && MaBN != "")
                sqlSelect += " AND B.MABENHNHAN LIKE N'%" + MaBN + "%'" + "\r\n";
            if (HoTenBN != null && HoTenBN != "")
                sqlSelect += " AND B.TENBENHNHAN LIKE N'%" + HoTenBN + "%'" + "\r\n";
            if (SoBHYT != null && SoBHYT != "")
                sqlSelect += " AND E.SOBHYT LIKE N'%" + SoBHYT + "%'" + "\r\n";



            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th></th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaBN") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("HoTenBN") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgaySinh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GioiTinh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoBHYT") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày nhập") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đã lưu?") + "</th>");
            if (IsAll == "1")
                html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tình trạng") + "</th>");
            html.Append("<th></th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr>");
                        html.Append("<td>" + (i + 1).ToString() + "</td>");
                        html.Append("<td><a href=\"javascript:;\" onclick=\"CHITIETDIEUTRI('" + table.Rows[i]["IDBENHNHAN"].ToString() + "','" + DenNgay + "')\">Chi tiết điều trị</a></td>");
                        html.Append("<td>" + table.Rows[i]["MaBN"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["HoTenBN"].ToString() + "</td>");
                        if (table.Rows[i]["NgaySinh"].ToString() != "")
                        {
                            html.Append("<td>" + table.Rows[i]["NgaySinh"].ToString() + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["NgaySinh"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["GioiTinh"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["SoBHYT"].ToString() + "</td>");
                        html.Append("<td>" + DateTime.Parse(table.Rows[i]["NgayKham"].ToString()).ToString("dd/MM HH:mm") + "</td>");
                        html.Append("<td>" + table.Rows[i]["IsDaLuu"].ToString() + "</td>");
                        if (Request.QueryString["IsAll"] != "0")
                            html.Append("<td>" + table.Rows[i]["TINHTRANG"].ToString() + "</td>");
                        html.Append("<td><a href='javascript:;' onclick=\"XemChiTietCongNo('" + table.Rows[i]["idbenhnhan"] + "','" + table.Rows[i]["idchitietdangkykham"] + "');\">Xem công nợ </a></td>");
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
    //───────────────────────────────────────────────────────────────────────────────────────
    private void CHITIETDIEUTRI()
    {
        string IDBENHNHAN = Request.QueryString["IDBENHNHAN"];
        string DenNgay = Request.QueryString["DenNgay"];
        if (DenNgay == null || DenNgay == "")
            DenNgay = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
        if (IDBENHNHAN == null || IDBENHNHAN == "") return;
        string IdKhoa = Request.QueryString["IdKhoa"];
        if (IdKhoa == null || IdKhoa == "") IdKhoa = "22";

        DataTable dt = DataAcess.Connect.GetTable("SELECT * FROM HS_KHAMBENH_VIEW WHERE IDBENHNHAN=" + IDBENHNHAN
                                               + " AND DenNgay<='" + DenNgay + "' AND IDKHOA=" + IdKhoa);
        if (dt == null) return;
        string idkhoachinh = null;
        if (dt.Rows.Count > 0) idkhoachinh = dt.Rows[0][0].ToString();
        else
        {
            string sqlMaxIdToathuoc = "SELECT MAX(IdToaThuoc) FROM HS_KHAMBENH_VIEW";
            DataTable dtIdToaThuoc = DataAcess.Connect.GetTable(sqlMaxIdToathuoc);
            if (dtIdToaThuoc == null) return;
            if (dtIdToaThuoc.Rows.Count == 0 || dtIdToaThuoc.Rows[0][0].ToString() == "0" || dtIdToaThuoc.Rows[0][0].ToString() == "")
                idkhoachinh = "1";
            else
                idkhoachinh = (int.Parse(dtIdToaThuoc.Rows[0][0].ToString()) + 1).ToString();

            string sqlSave = @"
                                  INSERT INTO HS_KHAMBENH_VIEW(IdToaThuoc,DenNgay,IDBENHNHAN,IDKHOA)
                                  select DISTINCT IdToaThuoc=" + idkhoachinh
                                           + @",DenNgay='" + DenNgay
                                           + @"', A.IDBENHNHAN
                                            , " + IdKhoa + @"
                                            FROM KHAMBENH A
                                            WHERE  IDKHOACHUYEN=" + IdKhoa
                                                   + @" AND ISNULL(A.IDKHOA,A.IDPHONGKHAMBENH)=" + IdKhoa
                                                   + "  AND   ISNULL(A.TGXuatVien,A.NGAYKHAM)<='" + DenNgay + "'"
                                                   + "   AND A.IDBENHNHAN =" + IDBENHNHAN;
            bool ok = DataAcess.Connect.ExecSQL(sqlSave);
            if (!ok) return;
        }

        #region Lưu chi tiết đơn thuốc
        string SQLSAVECHITIET = @"
                                                DELETE HS_KHAMBENH_VIEWDetail WHERE IdToaThuoc=" + idkhoachinh + @"
                                                INSERT INTO HS_KHAMBENH_VIEWDetail (IdToaThuoc,
                                                                                    ChiTietThuoc,
                                                                                    ChiTietBenh,
                                                                                    ChiTietCLS,
                                                                                    IDKHAMBENH
                                                                                   )
                                                
                                                SELECT " + idkhoachinh
                                                   + @", ChiTietThuoc=DBO.HS_CHITIETTHUOC(A.IDKHAMBENH)
	                                                   ,ChiTietBenh=DBO.HS_CHITIETBENH2(A.IDKHAMBENH)
	                                                   ,ChiTietCLS=DBO.HS_CHITIETCANLAMSAN(A.IDKHAMBENH)
                                                       ,A.IDKHAMBENH
                                                  FROM KHAMBENH A
                                                  LEFT JOIN KB_PHONG B ON ISNULL(A.PHONGID,A.IDPHONG)=B.ID  
                                            WHERE  isnull(B.ISPHONGNOITRU,-1)<>0"
                                                   + @" AND ISNULL(A.IDKHOA,A.IDPHONGKHAMBENH)=" + IdKhoa
                                                   + "  AND   ISNULL(A.TGXuatVien,A.NGAYKHAM)<='" + DenNgay + "'"
                                                   + "   AND A.IDBENHNHAN =" + IDBENHNHAN;

        bool ok_detail = DataAcess.Connect.ExecSQL(SQLSAVECHITIET);
        if (!ok_detail)
        {
            Response.Clear();
            Response.StatusCode = 500;
            return;
        }
        string sqlDetail = "SELECT TOP 1 IDKHAMBENH FROM HS_KHAMBENH_VIEWDETAIL WHERE IDTOATHUOC=" + idkhoachinh;
        DataTable dtDetail = DataAcess.Connect.GetTable(sqlDetail);
        if (dtDetail == null)
        {
            Response.Clear();
            Response.StatusCode = 500;
            return;
        }

        string sqlKhamBenh = @" select DISTINCT 
                                            LoaiBN=B.Loai
                                            ,idchitietdangkykham=A.idchitietdangkykham
                                            , idkhambenhchuyenphong=A.IDKHAMBENH
                                            FROM KHAMBENH A
                                            LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                            WHERE  IDKHOACHUYEN=" + IdKhoa
                                               + @" AND ISNULL(A.IDKHOA,A.IDPHONGKHAMBENH)=" + IdKhoa
                                               + "  AND   ISNULL(A.TGXuatVien,A.NGAYKHAM)<='" + DenNgay + "'"
                                               + "   AND A.IDBENHNHAN =" + IDBENHNHAN;
        DataTable dtKhamBenh = DataAcess.Connect.GetTable(sqlKhamBenh);
        if (dtKhamBenh == null || dtKhamBenh.Rows.Count == 0)
        {
            Response.Clear();
            Response.StatusCode = 500;
            return;
        }

        string LoaiBN = dtKhamBenh.Rows[0]["LoaiBN"].ToString();
        string idchitietdangkykham = dtKhamBenh.Rows[0]["idchitietdangkykham"].ToString();
        string idkhambenhchuyenphong = dtKhamBenh.Rows[0]["idkhambenhchuyenphong"].ToString();

        string IsHaveKhamBenh = "1";
        if (dtDetail.Rows.Count == 0) IsHaveKhamBenh = "0";
        Response.Clear();
        Response.Write(idkhoachinh + "|" + IsHaveKhamBenh + "|" + LoaiBN + "|" + idchitietdangkykham + "|" + IDBENHNHAN + "|" + idkhambenhchuyenphong);
        #endregion
    }
    //───────────────────────────────────────────────────────────────────────────────────────
}//end class



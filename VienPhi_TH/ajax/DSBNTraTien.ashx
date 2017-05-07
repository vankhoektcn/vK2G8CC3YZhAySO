<%@ WebHandler Language="C#" Class="DSBNTraTien" %>

using System;
using System.Web;
using System.Data;
public class DSBNTraTien : IHttpHandler
{
    HttpResponse _resq = HttpContext.Current.Response;
    public void ProcessRequest(HttpContext context)
    {
        string action = context.Request.QueryString["do"];
        switch (action)
        {
            case "loadDSBNCLS": loadDSBNCLS(); break;
            case "HienThiChiTietCLS": HienThiChiTietCLS(); break;
            case "setHoanTraCLS": setHoanTraCLS(); break;
            case "loadDSBNPhiKham": loadDSBNPhiKham(); break;
            case "HienThiChiTietPhiKham": HienThiChiTietPhiKham(); break;
            case "setHoanTraPhiKham": setHoanTraPhiKham(); break;
        }
    }
    #region SETHOANTRATIENCLS
    private void setHoanTraCLS()
    {
        int r = 0;
        string lstId = HttpContext.Current.Request.QueryString["lstId"].TrimEnd('@');
        string maphieu = HttpContext.Current.Request.QueryString["MaPhieu"];
        string ngayhoantra = HttpContext.Current.Request.QueryString["ngayhoantra"];
        string[] arrId = lstId.Split('@');
        string strSQL = "";
        string NguoiNhanTra = HttpContext.Current.Request.QueryString["FullName"];
        for (int i = 0; i < arrId.Length; i++)
        {
            strSQL = @"UPDATE HS_DSDATHU SET ISHOANTRA=1, ngayhoantra='" + StaticData.CheckDate(ngayhoantra) + "',NguoiNhanTra=N'" + NguoiNhanTra + "' WHERE MAPHIEU='" + maphieu
                        + "' and IdKhamBenhCanLamSan='" + arrId[i].ToString() + "'";
            bool ok = DataAcess.Connect.ExecSQL(strSQL);
            if (ok)
            {
                r++;
            }

        }
        if (r > 0)
        {
            _resq.Clear();
            _resq.Write("Cập nhật thành công !");
            return;
        }

    }
    #endregion
    #region SETHOANTRATIENPHIKHAM
    private void setHoanTraPhiKham()
    {
        int r = 0;
        string lstId = HttpContext.Current.Request.QueryString["lstId"].TrimEnd('@');
        string maphieu = HttpContext.Current.Request.QueryString["MaPhieu"];
        string ngayhoantra = HttpContext.Current.Request.QueryString["ngayhoantra"];
        string[] arrId = lstId.Split('@');
        string strSQL = "";
        string NguoiNhanTra = HttpContext.Current.Request.QueryString["FullName"];
        for (int i = 0; i < arrId.Length; i++)
        {
            strSQL = @"UPDATE HS_DSDATHU SET ISHOANTRA=1, ngayhoantra='" + StaticData.CheckDate(ngayhoantra) + "',NguoiNhanTra=N'" + NguoiNhanTra + "' WHERE MAPHIEU='" + maphieu + "' and IDCHITIETDANGKYKHAM='" + arrId[i].ToString() + "'";
            bool ok = DataAcess.Connect.ExecSQL(strSQL);

            string sqlUpdateChiTietDangKyKham = " UPDATE CHITIETDANGKYKHAM SET DAHUY=1 WHERE IDCHITIETDANGKYKHAM=" + arrId[i].ToString() + " AND ISNULL(DAHUY,0)=0 AND ISNULL(ISKHONGKHAM,0)=1";
            sqlUpdateChiTietDangKyKham += "\r\n" + " EXEC zHS_TraTienPhiKham " + arrId[i].ToString() + "\r\n";
            bool ok2 = DataAcess.Connect.ExecSQL(sqlUpdateChiTietDangKyKham);

            if (ok && ok2)
            {

                r++;
            }

        }
        if (r > 0)
        {
            _resq.Clear();
            _resq.Write("Cập nhật thành công !");
            return;
        }

    }
    #endregion
    #region HienThiDSBNTraTienPhiKham
    private void loadDSBNPhiKham()
    {
        string mabenhnhan = HttpContext.Current.Request.QueryString["mabenhnhan"];
        string tenbenhnhan = HttpContext.Current.Request.QueryString["tenbenhnhan"];
        string NgayThuPhi = StaticData.CheckDate(HttpContext.Current.Request.QueryString["ngaybd"]);
        string strSQL = @"SELECT DISTINCT STT=1
                                    ,MAPHIEU
                                    ,MABENHNHAN
                                    ,TENBENHNHAN
                                    ,NGAYSINH
                                    ,NGAYTHU=A.SYSDATE        
				                    ,TONGTIENKHAM=DBO.[HS_SOTIENTRALAI2](A.IDCHITIETDANGKYKHAM)
                                    ,HOANTRA=''
				                    ,DATRA=DBO.[HS_SOTIENDATRALAI2](A.IDCHITIETDANGKYKHAM)             
                                      
                    FROM HS_DSDATHU A
                        INNER JOIN CHITIETDANGKYKHAM B ON A.IDCHITIETDANGKYKHAM=B.IDCHITIETDANGKYKHAM
                        INNER JOIN KHAMBENH C ON C.IDCHITIETDANGKYKHAM=B.IDCHITIETDANGKYKHAM   AND C.IDKHOA IN (1,2)                                         
                    WHERE  1=1
                            AND   (C.ISKHONGKHAM=1 OR B.ISKHONGKHAM=1)
                            AND A.NLOAITHU=1 ";
        if (mabenhnhan != null && mabenhnhan != "")
            strSQL += " AND A.MABENHNHAN like '%" + mabenhnhan + @"%'";
        if (tenbenhnhan != null && tenbenhnhan != "")
            strSQL += " AND (dbo.untiengviet(LOWER(tenbenhnhan)) LIKE N'%" + tenbenhnhan + @"%' or tenbenhnhan like N'%" + tenbenhnhan + "%')";
        if (NgayThuPhi != "")
        {
            strSQL += " AND YEAR( SysDate)=YEAR('" + NgayThuPhi + "')" + "\r\n";
            strSQL += " AND MONTH( SysDate)=MONTH('" + NgayThuPhi + "')" + "\r\n";
            strSQL += " AND DAY( SysDate)=DAY('" + NgayThuPhi + "')" + "\r\n";
        }

        strSQL += @" ORDER BY MAPHIEU";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã phiếu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã bệnh nhân") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên bệnh nhân") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày sinh") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số tiền") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày thu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Chức năng") + "</th>";
        html += "</tr>";

        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string hoantra = dt.Rows[i]["HOANTRA"].ToString();
                string datra = dt.Rows[i]["DATRA"].ToString();
                string TONGTIENKHAM = dt.Rows[i]["TONGTIENKHAM"].ToString();
                if (TONGTIENKHAM == "") TONGTIENKHAM = "0";
                if (datra == "") datra = "0";
                long dTongTien = long.Parse(TONGTIENKHAM);
                long dDaTra = long.Parse(datra);
                if (dDaTra == 0)
                    hoantra = "Chưa trả";
                else
                    if (dDaTra < dTongTien)
                        hoantra = "Chưa trả hết";
                    else hoantra = "Đã trả";

                html += "<tr>";
                html += "<td>" + (i + 1) + "</td>";
                html += "<td style='text-align:center;'>" + dt.Rows[i]["MAPHIEU"].ToString() + "</td>";
                html += "<td style='text-align:center;'>" + dt.Rows[i]["MABENHNHAN"].ToString() + "</td>";
                html += "<td>" + dt.Rows[i]["TENBENHNHAN"].ToString() + "</td>";
                html += "<td style='text-align:center;'>" + dt.Rows[i]["NGAYSINH"].ToString() + "</td>";
                html += "<td style='text-align:center;'>" + string.Format("{0:0,0}", dt.Rows[i]["TONGTIENKHAM"]) + "</td>";
                html += "<td style='text-align:center;'>" + string.Format("{0:dd/MM/yyyy}", dt.Rows[i]["NGAYTHU"]) + "</td>";
                html += "<td style='text-align:center;'><a id='HoanTra' onclick='javascript:HienThiChiTietCLS(this);'>" + hoantra + "</a></td>";
                html += "</tr>";
            }
        }
        html += "</table>";
        _resq.Clear();
        _resq.Write(html);

    }
    #endregion
    #region HienThiDSBNTraTienCLS
    private void loadDSBNCLS()
    {
        string mabenhnhan = HttpContext.Current.Request.QueryString["mabenhnhan"];
        string tenbenhnhan = HttpContext.Current.Request.QueryString["tenbenhnhan"];
        string NgayThuPhi = StaticData.CheckDate(HttpContext.Current.Request.QueryString["ngaybd"]);
        string strSQL = @"SELECT DISTINCT STT=1,
				                        A.MAPHIEU,A.MABENHNHAN,A.TENBENHNHAN,A.NGAYSINH,NGAYTHU=A.SYSDATE,
				                        TONGTIENCLS=(SELECT SUM(TONGTIEN)
							                         FROM HS_DSDATHU A1
                                        LEFT JOIN KHAMBENHCANLAMSAN B1 ON A1.IDKHAMBENHCANLAMSAN=B1.IDKHAMBENHCANLAMSAN
                                        WHERE A1.MAPHIEU=A.MAPHIEU AND A1.NLOAITHU=2  AND B1.DAHUY=1),
				                        HOANTRA=(CASE WHEN ISNULL(A.ISHOANTRA,0)=0 THEN N'Hoàn trả' ELSE N'' END),
				                        DATRA=(CASE WHEN ISNULL(A.ISHOANTRA,0)=0 THEN N'' ELSE N'Đã trả' END)
                        FROM HS_DSDATHU A
                        LEFT JOIN KHAMBENHCANLAMSAN B
                        ON A.IDKHAMBENHCANLAMSAN=B.IDKHAMBENHCANLAMSAN
                                WHERE 1=1 AND A.NLOAITHU=2 AND B.DAHUY=1";

        if (mabenhnhan != null && mabenhnhan != "")
            strSQL += " AND A.MABENHNHAN LIKE  '%" + mabenhnhan + @"%'";
        if (tenbenhnhan != null && tenbenhnhan != "")
            strSQL += " AND (dbo.untiengviet(LOWER(tenbenhnhan)) LIKE N'%" + tenbenhnhan + @"%' or tenbenhnhan like N'%" + tenbenhnhan + "%')";

        if (NgayThuPhi != "")
        {
            strSQL += " AND YEAR( SysDate)=YEAR('" + NgayThuPhi + "')" + "\r\n";
            strSQL += " AND MONTH( SysDate)=MONTH('" + NgayThuPhi + "')" + "\r\n";
            strSQL += " AND DAY( SysDate)=DAY('" + NgayThuPhi + "')" + "\r\n";
        }

        strSQL += @" ORDER BY MAPHIEU";

        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã phiếu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã bệnh nhân") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên bệnh nhân") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày sinh") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số tiền") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày thu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Chức năng") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string hoantra = dt.Rows[i]["HOANTRA"].ToString();
                string datra = dt.Rows[i]["DATRA"].ToString();
                if (hoantra.Trim() == "")
                    hoantra = datra;
                html += "<tr>";
                html += "<td>" + (i + 1) + "</td>";
                html += "<td style='text-align:center;'>" + dt.Rows[i]["MAPHIEU"].ToString() + "</td>";
                html += "<td style='text-align:center;'>" + dt.Rows[i]["MABENHNHAN"].ToString() + "</td>";
                html += "<td>" + dt.Rows[i]["TENBENHNHAN"].ToString() + "</td>";
                html += "<td style='text-align:center;'>" + dt.Rows[i]["NGAYSINH"].ToString() + "</td>";
                html += "<td style='text-align:center;'>" + string.Format("{0:0,0}", dt.Rows[i]["TONGTIENCLS"]) + "</td>";
                html += "<td style='text-align:center;'>" + string.Format("{0:dd/MM/yyyy}", dt.Rows[i]["NGAYTHU"]) + "</td>";
                html += "<td><a id='HoanTra' onclick='javascript:HienThiChiTietCLS(this);'>" + hoantra + "</a></td>";
                html += "</tr>";
            }
        }
        html += "</table>";
        _resq.Clear();
        _resq.Write(html);

    }
    #endregion
    #region HienThiChiTietCLS
    private void HienThiChiTietCLS()
    {
        string MaPhieu = HttpContext.Current.Request.QueryString["MaPhieu"];
        string strSQL = @"SELECT DISTINCT A.IDKHAMBENHCANLAMSAN,STT=ROW_NUMBER() OVER(ORDER BY A.IDKHAMBENHCANLAMSAN DESC),
				                        A.TENDICHVU,A.SOLUONG,A.DONGIA,A.THANHTIEN,HOANTRA=ISNULL(A.ISHOANTRA,0),
                                       NGAYHOANTRA=(SELECT TOP 1 NGAYHOANTRA FROM HS_DSDATHU WHERE MAPHIEU=A.MAPHIEU AND ISNULL(ISHOANTRA,0)=1)				                        
                        FROM HS_DSDATHU A
                        LEFT JOIN KHAMBENHCANLAMSAN B
                        ON A.IDKHAMBENHCANLAMSAN=B.IDKHAMBENHCANLAMSAN
                                WHERE 1=1 AND A.NLOAITHU=2 AND B.DAHUY=1";
        if (MaPhieu != null && MaPhieu != "")
        {
            strSQL += " AND A.MAPHIEU='" + MaPhieu + "'";
        }
        DataTable dtChiTietCLS = DataAcess.Connect.GetTable(strSQL);
        if (dtChiTietCLS == null && dtChiTietCLS.Rows.Count == 0) return;
        string html = "";
        html += "<input type='hidden' id='maphieu' value='" + MaPhieu + "' />";
        html += "<table class='jtable' id=\"gridTableCLS\">";
        html += "<tr>";
        html += "<th align='center'><input type='checkbox' id='chkAll' onclick='checkAllCLS(this);' /></th>";
        html += "<th>STT</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên dịch vụ") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số lượng") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đơn giá") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Thành tiền") + "</th>";
        html += "</tr>";
        double tongtien = 0;
        if (dtChiTietCLS != null && dtChiTietCLS.Rows.Count > 0)
        {
            for (int i = 0; i < dtChiTietCLS.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td align='center'><input type='checkbox' " + (StaticData.IsCheck(dtChiTietCLS.Rows[i]["HOANTRA"].ToString()) ? "checked" : "") + " id='chk_" + dtChiTietCLS.Rows[i]["IDKHAMBENHCANLAMSAN"] + "' /></td>";
                html += "<td>" + (i + 1) + "</td>";
                html += "<td style='text-align:left;'>" + dtChiTietCLS.Rows[i]["TENDICHVU"].ToString() + "</td>";
                html += "<td>" + dtChiTietCLS.Rows[i]["SOLUONG"].ToString() + "</td>";
                html += "<td>" + string.Format("{0:0,0}", dtChiTietCLS.Rows[i]["DONGIA"]) + "</td>";
                html += "<td>" + string.Format("{0:0,0}", dtChiTietCLS.Rows[i]["THANHTIEN"]) + "</td>";
                html += "</tr>";
                tongtien += double.Parse(dtChiTietCLS.Rows[i]["thanhtien"].ToString());
            }
        }
        html += "<tr>";
        html += "<td colspan='5' style='text-align:right; font-weight:bold;'>Tổng tiền : </td><td>" + string.Format("{0:0,0}", tongtien) + "</td>";
        html += "</tr>";
        html += "</table><div style='clear:both; padding:0 auto; margin:0 auto;'>";
        html += "<div class='div-Out'><h4>Ngày hoàn trả</h4><p><input type='text' onfocus='$(this).datepick();$(this).validDate();' id='ngayhoantra' value='" + ((dtChiTietCLS != null && dtChiTietCLS.Rows.Count > 0) ? string.Format("{0:dd/MM/yyyy}", dtChiTietCLS.Rows[0]["NGAYHOANTRA"]) : "") + "' /></p></div><div class='div-Out'><h4><input type='button' value=\"Đồng ý\" id='btnOK' onclick='javascript:setHoanTraCLS(this);' />&nbsp;<input type='button' value=\"Hủy\" id='btnCancel' onclick='$.mkv.closeDivTimKiem();'/></h4></div></div>";
        _resq.Clear();
        _resq.Write(html);
    }
    #endregion
    #region HienThiChiTietPhiKham
    private void HienThiChiTietPhiKham()
    {
        string MaPhieu = HttpContext.Current.Request.QueryString["MaPhieu"];
        string strSQL = @"SELECT DISTINCT A.IDCHITIETDANGKYKHAM,
					        A.TENDICHVU,A.THANHTIEN,HOANTRA=ISNULL(A.ISHOANTRA,0),
                            NGAYHOANTRA=(SELECT TOP 1 NGAYHOANTRA FROM HS_DSDATHU WHERE MAPHIEU=A.MAPHIEU AND ISNULL(ISHOANTRA,0)=1)						                          
                            FROM HS_DSDATHU A
                            WHERE DBO.HS_ISTRALAI_DETAIL(A.MAPHIEU,A.IDCHITIETDANGKYKHAM)=1 and A.NLOAITHU=1";
        if (MaPhieu != null && MaPhieu != "")
        {
            strSQL += " AND A.MAPHIEU='" + MaPhieu + "'";
        }
        DataTable dtChiTietPhiKham = DataAcess.Connect.GetTable(strSQL);
        if (dtChiTietPhiKham == null || dtChiTietPhiKham.Rows.Count == 0)
        {
            _resq.Clear();
            _resq.StatusCode = 500;
            return;
        };
        string html = "";
        html += "<input type='hidden' id='maphieucls' value='" + MaPhieu + "' />";
        html += "<table class='jtable' id=\"gridTablePhiKham\">";
        html += "<tr>";
        html += "<th align='center'><input type='checkbox' id='chkAll' onclick='checkAllPhiKham(this);' /></th>";
        html += "<th>STT</th>";
        html += "<th style='text-align:left;'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên dịch vụ") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Thành tiền") + "</th>";
        html += "</tr>";
        double tongtien = 0;
        if (dtChiTietPhiKham != null && dtChiTietPhiKham.Rows.Count > 0)
        {
            for (int i = 0; i < dtChiTietPhiKham.Rows.Count; i++)
            {

                html += "<tr>";
                html += "<td align='center'><input type='checkbox' " + (StaticData.IsCheck(dtChiTietPhiKham.Rows[i]["HOANTRA"].ToString()) ? "checked" : "") + " id='chk_" + dtChiTietPhiKham.Rows[i]["IDCHITIETDANGKYKHAM"] + "' /></td>";
                html += "<td>" + (i + 1) + "</td>";
                html += "<td style='text-align:left;'>" + dtChiTietPhiKham.Rows[i]["TENDICHVU"].ToString() + "</td>";
                html += "<td>" + string.Format("{0:0,0}", dtChiTietPhiKham.Rows[i]["THANHTIEN"]) + "</td>";
                html += "</tr>";
                tongtien += double.Parse(dtChiTietPhiKham.Rows[i]["thanhtien"].ToString());
            }
        }
        html += "<tr>";
        html += "<td colspan='3' style='text-align:right; font-weight:bold;'>Tổng tiền : </td><td>" + string.Format("{0:0,0}", tongtien) + "</td>";
        html += "</tr>";
        html += "</table><div style='clear:both;margin:0; padding:0;'>";
        html += "<div class='div-Out'><h4>Ngày hoàn trả</h4><p><input type='text' onfocus='$(this).datepick();$(this).validDate();' id='ngayhoantra' value='" + ((dtChiTietPhiKham != null && dtChiTietPhiKham.Rows.Count > 0) ? string.Format("{0:dd/MM/yyyy}", dtChiTietPhiKham.Rows[0]["NGAYHOANTRA"]) : "") + "' /></p></div><div class='div-Out'><h4><input type='button' value=\"Đồng ý\" id='btnOK' onclick='javascript:setHoanTraPhiKham(this);' />&nbsp;<input type='button' value=\"Hủy\" id='btnCancel' onclick='$.mkv.closeDivTimKiem();'/></h4></div></div>";
        _resq.Clear();
        _resq.Write(html);
    }
    #endregion
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
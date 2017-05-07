<%@ WebHandler Language="C#" Class="BangTDCNBenhNhan" %>

using System;
using System.Web;
using System.Data;
public class BangTDCNBenhNhan : IHttpHandler
{
    HttpResponse _resq = HttpContext.Current.Response;
    public void ProcessRequest(HttpContext context)
    {
        string action = context.Request.QueryString["do"];
        switch (action)
        {
            case "loadchitietdsphieuthuhoantra": loadchitietdsphieuthuhoantra();
                break;
            case "setTimKiem": setTimKiem();
                break;
            case "TimKiem": TimKiem();
                break;
            case "loadchitietcongno": loadchitietcongno();
                break;
            case "loaddsphieuchidinhcls": loaddsphieuchidinhcls();
                break;
            case "loaddsphieuchidinhdvkt": loaddsphieuchidinhdvkt();
                break;
            case "loaddstoathuoc": loaddstoathuoc();
                break;
            case "tinhlaitien": tinhlaitien(); break;
                
        }
    }
    private void tinhlaitien()
    {
        string IDBENHBHDONGTIEN = HttpContext.Current.Request.QueryString["IDBENHBHDONGTIEN"];
        string sqlSave = "EXEC ZHS_TONGTIEN_AGAIN " + IDBENHBHDONGTIEN;
        bool OK = DataAcess.Connect.ExecSQL(sqlSave);
        if(OK)
            _resq.Write("Tính tiền thành công");
        else
            _resq.Write("Tính tiền thất bại");

    }
    private void loadchitietcongno()
    {
        string id = HttpContext.Current.Request.QueryString["id"];
        string sql = "select * from [dbo].[hs_CongNoBenhNhan0]('" + id + "') order by ngayct asc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(nvk_tableCongNoBenhNhan(table, "", id, false));
        _resq.Write(builder);
    }
    private string nvk_tableCongNoBenhNhan(DataTable table, string idkhoa, string idchitietdangkykham, bool isTamUng)
    {
        string html = "";
        int stt = 0;
        html = "<table class='jtable'  style='border-width:medium' rules='all' id=\"gridTableTamUng\">";//class='jtable' 
        html += "<tr align='center'>";
        html += "<th><span style='color: #333; font-weight: bold' class='Tieude'>Ngày</span></th>";
        html += "<th><span style='color: #333; font-weight: bold' class='Tieude'>Số chứng từ</span></th>";
        html += "<th><span style='color: #333; font-weight: bold' class='Tieude'>Nội dung</span></th>";
        html += "<th><span style='color: #333; font-weight: bold' class='Tieude'>Phát sinh</span></th>";
        html += "<th><span style='color: #333; font-weight: bold' class='Tieude'>Thanh toán</span></th>";
        html += "<th><span style='color: #333; font-weight: bold' class='Tieude'>Còn lại</span></th>";//#0000cc (xanh)
        html += "<th><span style='color: #333; font-weight: bold' class='Tieude'>Khoa</span></th>";//#0000cc (xanh)
        html += "</tr>";
        #region chi tiết công nợ
        double TongPhatSinh = 0;
        double TongThanhToan = 0;
        double CongNoConLai = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            double PhatSinh_i = double.Parse(table.Rows[i]["nvk_phatsinh"].ToString());
            double ThanhToan_i = double.Parse(table.Rows[i]["nvk_thanhtoan"].ToString());
            double hieuSo_i = PhatSinh_i - ThanhToan_i;
            TongPhatSinh += PhatSinh_i;
            TongThanhToan += ThanhToan_i;
            CongNoConLai = CongNoConLai + hieuSo_i;
            html += "<tr>";
            #region màu nội dung
            string str_NoiDung = table.Rows[i]["NoiDung"].ToString();
            if (str_NoiDung.ToLower().Trim().Equals("tạm ứng"))
            {
                str_NoiDung = "<span style='color: #0000cc; font-weight: bold'>" + table.Rows[i]["NoiDung"] + "</span>";
                html += "<td align='center'><span style='color: #0000cc; font-weight: bold'>" + table.Rows[i]["ngayct"] + "</span></td>";
                html += "<td align='center'><span style='color: #0000cc; font-weight: bold'>" + table.Rows[i]["SoCT"] + "</span></td>";
                html += "<td align='left' >" + str_NoiDung + "</td>";
                html += "<td align='right'><span style='color: #0000cc; font-weight: bold'>" + StaticData.FormatNumberOption(table.Rows[i]["nvk_phatsinh"], ",", ".", false) + "</span></td>";
                html += "<td align='right'><span style='color: #0000cc; font-weight: bold'>" + StaticData.FormatNumberOption(table.Rows[i]["nvk_thanhtoan"], ",", ".", false) + "</span></td>";
                html += "<td align='right'><span style='color: #0000cc; font-weight: bold'>" + StaticData.FormatNumberOption(CongNoConLai, ",", ".", false) + "</span></td>";
                html += "<td align='right'><span style='color: #0000cc; font-weight: bold'>" + table.Rows[i]["khoa"] + "</span></td>";
            }
            else
            {
                html += "<td align='center'>" + table.Rows[i]["ngayct"] + "</td>";
                html += "<td align='center'>" + table.Rows[i]["SoCT"] + "</td>";
                html += "<td align='left'>" + str_NoiDung + "</td>";
                html += "<td align='right'>" + StaticData.FormatNumberOption(table.Rows[i]["nvk_phatsinh"], ",", ".", false) + "</td>";
                html += "<td align='right'>" + StaticData.FormatNumberOption(table.Rows[i]["nvk_thanhtoan"], ",", ".", false) + "</td>";
                html += "<td align='right'>" + StaticData.FormatNumberOption(CongNoConLai, ",", ".", false) + "</td>";
                html += "<td >" + table.Rows[i]["khoa"] + "</td>";
            }
            #endregion
            html += "</tr>";
        }
        #endregion

        #region dòng tổng cộng

        html += "<tr>";
        html += "<td colspan='3' align='right' ><span style='color: #0000cc; font-weight: bold' class='Tieude'>Tổng cộng</span></td>";
        html += "<td align='right'><span style='color: Black; font-weight: bold'>" + StaticData.FormatNumberOption(TongPhatSinh, ",", ".", false) + "</span></td>";
        html += "<td align='right'><span style='color: #0000cc; font-weight: bold'>" + StaticData.FormatNumberOption(TongThanhToan, ",", ".", false) + "</span></td>";
        html += "<td align='right'><span style='color: Red; font-weight: bold'>" + StaticData.FormatNumberOption(CongNoConLai, ",", ".", false) + "</span></td>";
        html += "<td></td>";
        html += "</tr>";
        #endregion

        if (isTamUng)
        {
            #region tạm ứng mới
            string sqlSoLan = @"select COUNT(distinct IDTamUng)+1
                from tamUng tu where tu.iddangkykham='" + idchitietdangkykham + "'  and idkhoatu='" + idkhoa + "'";
            DataTable SoLan = DataAcess.Connect.GetTable(sqlSoLan);
            string strSoLan = "1";
            if (SoLan.Rows.Count > 0)
                strSoLan = SoLan.Rows[0][0].ToString();
            else
                strSoLan = "1";
            html += "<tr align='center'>";
            html += "<td colspan='6' style='height=20px;'></td>";
            html += "</tr>";
            html += "<tr align='center'>";
            html += "<td style=''><span style='color: #0000cc; font-weight: bold' align='center' >Tạm ứng lần " + strSoLan + "</span></td>";
            html += "<td colspan='6' valign='top'><span style='color: #0000cc; font-weight: bold' align='center' >Số tiền:</span>&nbsp; &nbsp;";
            if (idkhoa == "15")
                html += "<select id=\"txtSoTien\" style=\"width: 100px\">"
                      + "<option value=\"500000\">500,000</option>"
                      + "<option value=\"1000000\">1,000,000</option>"
                      + "<option value=\"2000000\">2,000,000</option>"
                      + "<option value=\"3000000\">3,000,000</option>"
                      + "<option value=\"4000000\">4,000,000</option>"
                    + "</select>";
            else
                html += "<input type=\"text\"  onchange='nvk_formatNumBer(this)'  style=\"width: 80px\" id=\"txtSoTien\"/>";
            html += "&nbsp; &nbsp;<span style='color: #0000cc; font-weight: bold' align='center' >Lý do tam ứng:</span> &nbsp; &nbsp;<input type=\"text\" value=\"Chỉ định tạm ứng\" style=\"width: 350px\" id=\"txtLyDo\"/>";
            html += "&nbsp; &nbsp;<input type=\"button\" id=\"btnTU\" value=\"Lưu Tạm Ứng\"  style='width:130px'  onclick=\"luuTU(" + idchitietdangkykham + ",0);\"/></td>";/////
            html += "</tr>";
            #endregion
        }
        html += "<tr>";
        html += "<td colspan='7' id='tdPopup' align='center'></td>";
        html += "</tr>";
        html += "</table>";
        return html;
    }

    public void TimKiem()
    {
        string mabenhnhan = HttpContext.Current.Request.QueryString["mabenhnhan"];
        string tenbenhnhan = HttpContext.Current.Request.QueryString["tenbenhnhan"];
        string sobhyt = HttpContext.Current.Request.QueryString["sobhyt"];
        string sqlSelectBN = @"select distinct top 10 a.mabenhnhan,a.tenbenhnhan,a.sobhyt,b.ngaytinhbh,a.diachi,
                        gioitinh=dbo.GetGioiTinh(a.gioitinh),a.ngaysinh,b.id 
                        from hs_benhnhanbhdongtien b 
                         left join benhnhan a on a.idbenhnhan=b.idbenhnhan 
                        where 1=1";
        if (mabenhnhan != null && mabenhnhan != "")
        {
            sqlSelectBN += " and a.mabenhnhan='" + mabenhnhan + "'";
        }
        if (tenbenhnhan != null && tenbenhnhan != "")
        {
            sqlSelectBN += " and a.tenbenhnhan like N'%" + tenbenhnhan + "%'";
        }
        if (sobhyt != null && sobhyt != "")
        {
            sqlSelectBN += " and a.sobhyt like N'%" + sobhyt + "%'";
        }
        DataTable table = DataAcess.Connect.GetTable(sqlSelectBN);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>Mã bệnh nhân</th>";
        html += "<th>Tên bệnh nhân</th>";
        html += "<th>Địa chỉ</th>";
        html += "<th>Ngày sinh</th>";
        html += "<th>Giới tính</th>";
        html += "<th>Ngày bắt đầu</th>";
        html += "</tr>";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr style='cursor:pointer' onclick=\"setControlFind('" + table.Rows[i]["id"].ToString() + "')\">";
                html += "<td>" + (i + 1) + "</td>";
                html += "<td>" + table.Rows[i]["mabenhnhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["tenbenhnhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["diachi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["ngaysinh"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["gioitinh"].ToString() + "</td>";
                html += "<td>" + string.Format("{0:dd/MM/yyyy}", table.Rows[i]["ngaytinhbh"]) + "</td>";
                html += "</tr>";
            }
        }
        else
        {
            return;
            _resq.Write("");
        }
        html += "</table>";
        _resq.Write(html);
    }
    private void setTimKiem()
    {
        string idkhoachinh = HttpContext.Current.Request.QueryString["idkhoachinh"];
        string sqlSelect = @"SELECT A.ID,A.idbenhnhan,A.hotenbn as tenbenhnhan,A.ngaytinhbh,A.isbhyt,A.isnoitru,
                            B.mabenhnhan,B.ngaysinh,B.gioitinh,A.IDCHITIETDANGKYKHAM_LAST AS idchitietdangkykham,
                            C.sobh1,C.sobh2,C.sobh3,C.sobh4,C.sobh5,C.sobh6,
                            loaidieutri=(case when isnull(a.isnoitru,0)=0 then N'Ngoại trú' else N'Nội trú' end),
                            loaihinh=(case when isnull(a.isbhyt,0)=1 then N'Bảo hiểm' else N'Dịch vụ' end)                                                        
                            FROM HS_BENHNHANBHDONGTIEN A 
                            INNER JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN 
                            LEFT JOIN BENHNHAN_BHYT C ON A.IDBENHNHAN_BH=C.IDBENHNHAN_BH
                            WHERE A.ID='" + idkhoachinh + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<root>";
        if (table != null && table.Rows.Count > 0)
        {
            html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
            html += Environment.NewLine;
            for (int y = 0; y < table.Columns.Count; y++)
            {
                try
                {
                    html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                }
                catch (Exception)
                {
                    html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                }
                html += Environment.NewLine;
            }
        }
        html += "</root>";
        _resq.Clear();
        _resq.Write(html);
    }
    private void loadchitietdsphieuthuhoantra()
    {
        string id = HttpContext.Current.Request.QueryString["id"];
        string sqlSelect = @"SELECT DISTINCT MAPHIEU,SYSDATE,
                          NOIDUNGTHU=(CASE WHEN ISNULL(NOIDUNGTHU,'')='' AND LOAITHU='PHIKHAM' THEN N'Phí khám' Else NOIDUNGTHU end),
                          THANHTIEN=(SELECT SUM(ABS(TONGTIEN)) FROM HS_DSDATHU WHERE MAPHIEU=T.MAPHIEU),
                          TENNGUOITHU,
                          LOAITHU,
                          Khoa=(select top 1 khoa from hs_dsdathu where maphieu=t.maphieu and isnull(khoa,'')<>''),
                          CoHoanTra=isnull((select top 1 1 from hs_dsdathu where maphieu=t.maphieu and isnull(ishoantra,0)=1),0)
                          FROM HS_DSDATHU T WHERE ISNULL(T.ISDAHUY,0)=0 AND IDBENHNHANBHDONGTIEN='" + id + "' ORDER BY SYSDATE";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số phiếu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày thu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nội dung") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số tiền") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Người thu / người trả") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Khoa") + "</th>";
        html += "<th></th>";
        html += "<th></th>";
        html += "</tr>";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (i + 1) + "</td>";
                html += "<td>" + table.Rows[i]["MAPHIEU"].ToString() + "</td>";
                html += "<td>" + string.Format("{0:dd/MM/yyyy}", table.Rows[i]["SYSDATE"]) + "</td>";
                html += "<td>" + table.Rows[i]["NOIDUNGTHU"].ToString() + "</td>";
                html += "<td>" + string.Format("{0:0,0}", table.Rows[i]["THANHTIEN"]) + "</td>";
                html += "<td>" + table.Rows[i]["TENNGUOITHU"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["Khoa"].ToString() + "</td>";
                html += "<td><a style=\"color:#ff0000;\" href=\"javascript:setPrint('" + table.Rows[i]["MAPHIEU"].ToString() + "','" + table.Rows[i]["LOAITHU"] + "');\">In lại </a></td>";
                html += "<td><a style=\"color:#ff0000;\" href=\"javascript:setHoanTra('" + table.Rows[i]["MAPHIEU"].ToString() + "');\">" + (StaticData.IsCheck(table.Rows[i]["CoHoanTra"].ToString()) ? "In hoàn trả" : "") + "</a></td>";
                html += "</tr>";
            }
        }
        html += "</table>";
        _resq.Write(html);

    }
    private void loaddsphieuchidinhcls()
    {
        string id = HttpContext.Current.Request.QueryString["id"];
        string sqlSelect = @"select idkhambenh,ngaykham  as ngaychidinh
                            from khambenh a
                            left join dangkykham b on a.iddangkykham=b.iddangkykham
                            where b.idbenhbhdongtien='" + id + "'" + @"
                            and exists (select 1 from khambenhcanlamsan a1
				                            left join banggiadichvu b1 on a1.idcanlamsan=b1.idbanggiadichvu
				                            left join phongkhambenh c1 on b1.idphongkhambenh=c1.idphongkhambenh
				                            where idkhambenh=a.idkhambenh and c1.maphongkhambenh<>'dvktkhac'
			                )";
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (i + 1) + "</td>";
                html += "<td>" + string.Format("{0:dd/MM/yyyy hh:mm}", table.Rows[i]["ngaychidinh"]) + "</td>";
                html += "<td><a href=\"javascript:setPrintCLS('" + table.Rows[i]["idkhambenh"] + "');\">In chỉ định CLS</a></td>";
                html += "</tr>";
            }
        }
        html += "</table>";
        _resq.Clear();
        _resq.Write(html);
    }
    private void loaddsphieuchidinhdvkt()
    {
        string id = HttpContext.Current.Request.QueryString["id"];
        string sqlSelect = @"select idkhambenh,ngaykham  as ngaychidinh
                            from khambenh a
                            left join dangkykham b on a.iddangkykham=b.iddangkykham
                            where b.idbenhbhdongtien='" + id + "'" + @"
                            and exists (select 1 from khambenhcanlamsan a1
				                            left join banggiadichvu b1 on a1.idcanlamsan=b1.idbanggiadichvu
				                            left join phongkhambenh c1 on b1.idphongkhambenh=c1.idphongkhambenh
				                            where idkhambenh=a.idkhambenh and c1.maphongkhambenh='dvktkhac'
			                )";
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (i + 1) + "</td>";
                html += "<td>" + string.Format("{0:dd/MM/yyyy hh:mm}", table.Rows[i]["ngaychidinh"]) + "</td>";
                html += "<td><a href=\"javascript:setPrintDVKT('" + table.Rows[i]["idkhambenh"] + "');\">In chỉ định DVKT</a></td>";
                html += "</tr>";
            }
        }
        html += "</table>";
        _resq.Clear();
        _resq.Write(html);
    }
    private void loaddstoathuoc()
    {
        string id = HttpContext.Current.Request.QueryString["id"];
        string sqlSelect = @"select idkhambenh,isnull(tgxuatvien,ngaykham)  as ngayratoa
                            from khambenh a
                            left join dangkykham b on a.iddangkykham=b.iddangkykham
                            where b.idbenhbhdongtien='" + id + "'" + @"
                            and exists (select 1 from chitietbenhnhantoathuoc a1
                                        left join benhnhantoathuoc b1 on a1.idbenhnhantoathuoc=b1.idbenhnhantoathuoc
			                            where isnull(a1.idkhambenh,b1.idkhambenh)=a.idkhambenh
			                    )";
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (i + 1) + "</td>";
                html += "<td>" + string.Format("{0:dd/MM/yyyy hh:mm}", table.Rows[i]["ngayratoa"]) + "</td>";
                html += "<td><a href=\"javascript:setPrintToaThuoc('" + table.Rows[i]["idkhambenh"].ToString() + "');\">In chỉ định thuốc</a></td>";
                html += "</tr>";
            }
        }
        html += "</table>";
        _resq.Clear();
        _resq.Write(html);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
<%@ WebHandler Language="C#" Class="ThongKeDoanhThu" %>

using System;
using System.Web;
using System.Data;
using System.Globalization;
public class ThongKeDoanhThu : IHttpHandler
{
    HttpResponse _resq = HttpContext.Current.Response;
    private ExportToExcel.Profess_ExportToExcelByCode doanhThu;
    public void ProcessRequest(HttpContext context)
    {
        string action = context.Request.QueryString["do"];
        switch (action)
        {
            case "idnguoidungsearch": idnguoidungsearch(); break;
            case "getDoanhThu": getDoanhThu(); break;
            case "ExportExcel": ExportExcel(); break;
        }
    }
    private void ExportExcel()
    {
        string tungay = StaticData.CheckDate(HttpContext.Current.Request.QueryString["tungay"].ToString());
        string denngay = StaticData.CheckDate(HttpContext.Current.Request.QueryString["denngay"].ToString());
        string IdNguoiThu = HttpContext.Current.Request.QueryString["idnguoidung"];
        string tennguoidung = HttpContext.Current.Request.QueryString["tennguoidung"];
        clsDoanhThuNguoiDung_1807 temp1 = new clsDoanhThuNguoiDung_1807(tungay, denngay, IdNguoiThu, tennguoidung);
        this.doanhThu = temp1;
        doanhThu.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(doanhThu_AfterExportToExcel);
        doanhThu.ExportToExcel();
    }

    void doanhThu_AfterExportToExcel()
    {
        string html = "";
        html += "" + "../ReportOutput/" + doanhThu.OutputFileName;
        _resq.Clear();
        _resq.Write(html);
    }

    private void idnguoidungsearch()
    {
        string sql = @" 
                        (   select  IDNGUOIDUNG,TENNGUOIDUNG from nguoidung where nhomID=2 or nhomid=12
                         )
                            UNION
                        (
                            SELECT DISTINCT  IDNGUOIDUNG=0, TENNGUOITHU AS TENGNUOIDUNG FROM HS_DSDATHU
                        )
                         ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string html = "";

        if (dt != null)
        {
            dt.DefaultView.Sort = "TENNGUOIDUNG ASC ,IDNGUOIDUNG DESC ";
            dt = dt.DefaultView.ToTable();
            dt.Columns.Add("IsTrung", sql.GetType());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int n = StaticData.int_Search(dt, "TENNGUOIDUNG='" + dt.Rows[i]["TENNGUOIDUNG"].ToString() + "'");
                if (n != i)
                {
                    dt.Rows[i]["IdNguoiDung"] = dt.Rows[n]["IdNguoiDung"].ToString();
                    dt.Rows[i]["IsTrung"] = "1";
                }
                else
                {
                    dt.Rows[i]["IsTrung"] = "0";
                }
                #region if idnguoidung vẫn = 0
                if (dt.Rows[i]["IdNguoiDung"].ToString().Trim().Equals("0"))
                {
                    dt.Rows[i]["IdNguoiDung"] = DataAcess.Connect.GetTable("select isnull((select top 1 idnguoidung from nguoidung where tennguoidung =N'" + dt.Rows[i]["TENNGUOIDUNG"] + "'),0)").Rows[0][0];
                }
                #endregion
                if (dt.Rows[i]["istrung"].ToString() == "0")
                {
                    html += dt.Rows[i]["tennguoidung"].ToString() + "|" + dt.Rows[i]["idnguoidung"].ToString() + Environment.NewLine;
                }
            }

        }

        _resq.Clear();
        _resq.Write(html);
    }
    private void getDoanhThu()
    {
        string tungay = StaticData.CheckDate(HttpContext.Current.Request.QueryString["tungay"].ToString());
        string denngay = StaticData.CheckDate(HttpContext.Current.Request.QueryString["denngay"].ToString());
        string IdNguoiThu = HttpContext.Current.Request.QueryString["idnguoidung"];
        string tennguoidung = HttpContext.Current.Request.QueryString["tennguoidung"];
        string sql = null;
        clsDoanhThuNguoiDung_1807 processR = new clsDoanhThuNguoiDung_1807(tungay, denngay, IdNguoiThu, tennguoidung);
        sql = processR.GetSQL();
        DataTable dtDoanhThu = DataAcess.Connect.GetTable(sql);
        
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số phiếu thu") + "</th>";
        html += "<th >" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên bệnh nhân") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiền sổ") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiền khám") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiền CLS") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiền DVKT") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiền thuốc") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tạm ứng") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Hoàn ứng") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Hoàn trả") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Thu tiền xe") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Thanh toán ra viện") + "</th>";
        html += "</tr>";
        double tienso = 0;
        double tienkham = 0;
        double tiencls = 0;
        double tiendvkt = 0;
        double tienthuoc = 0;
        double tamung = 0;
        double hoanung = 0;
        double hoantra = 0;
        double tienxe = 0;
        double ravien = 0;
        if (dtDoanhThu != null && dtDoanhThu.Rows.Count > 0)
        {
            dtDoanhThu.DefaultView.Sort = "MAPHIEUDANGKY";
            if (dtDoanhThu.Columns.IndexOf("stt") == -1)
            {
                dtDoanhThu.Columns.Add("stt");
            }
            dtDoanhThu = dtDoanhThu.DefaultView.ToTable();
            for (int i = 0; i < dtDoanhThu.Rows.Count; i++)
            {
                if ((dtDoanhThu.Rows[i]["TIENSO"].ToString() != "" && dtDoanhThu.Rows[i]["TIENSO"].ToString() != "0") ||
                     (dtDoanhThu.Rows[i]["TIENKHAM"].ToString() != "" && dtDoanhThu.Rows[i]["TIENKHAM"].ToString() != "0") ||
                     (dtDoanhThu.Rows[i]["TIENCLS"].ToString() != "" && dtDoanhThu.Rows[i]["TIENCLS"].ToString() != "0") ||
                     (dtDoanhThu.Rows[i]["TIENDVKT"].ToString() != "" && dtDoanhThu.Rows[i]["TIENDVKT"].ToString() != "0") ||
                     (dtDoanhThu.Rows[i]["TIENTHUOC"].ToString() != "" && dtDoanhThu.Rows[i]["TIENTHUOC"].ToString() != "0") ||
                     (dtDoanhThu.Rows[i]["tamung"].ToString() != "" && dtDoanhThu.Rows[i]["tamung"].ToString() != "0") ||
                     (dtDoanhThu.Rows[i]["THANHTOANRAVIEN"].ToString() != "" && dtDoanhThu.Rows[i]["THANHTOANRAVIEN"].ToString() != "0") ||
                     (dtDoanhThu.Rows[i]["hoantra"].ToString() != "" && dtDoanhThu.Rows[i]["hoantra"].ToString() != "0")
                   )
                 {
                            dtDoanhThu.Rows[i]["stt"] = i + 1;
                            html += "<tr>";
                            html += "<td>" + (i + 1) + "</td>";
                            html += "<td style='width:100px'>" + dtDoanhThu.Rows[i]["MAPHIEUDANGKY"].ToString() + "</td>";
                            html += "<td style='width:150px; text-align:left;'>" + dtDoanhThu.Rows[i]["TENBENHNHAN"].ToString() + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["TIENSO"]) + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["TIENKHAM"]) + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["TIENCLS"]) + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["TIENDVKT"]) + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["TIENTHUOC"]) + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["TAMUNG"]) + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["HOANUNG"]) + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["HOANTRA"]) + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["THUTIENXE"]) + "</td>";
                            html += "<td style='text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", dtDoanhThu.Rows[i]["THANHTOANRAVIEN"]) + "</td>";
                            html += "</tr>";
                            tienso += double.Parse(dtDoanhThu.Rows[i]["TIENSO"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["TIENSO"].ToString());
                            tienkham += double.Parse(dtDoanhThu.Rows[i]["TIENKHAM"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["TIENKHAM"].ToString());
                            tiencls += double.Parse(dtDoanhThu.Rows[i]["TIENCLS"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["TIENCLS"].ToString());
                            tiendvkt += double.Parse(dtDoanhThu.Rows[i]["TIENDVKT"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["TIENDVKT"].ToString());
                            tienthuoc += double.Parse(dtDoanhThu.Rows[i]["TIENTHUOC"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["TIENTHUOC"].ToString());
                            tamung += double.Parse(dtDoanhThu.Rows[i]["TAMUNG"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["TAMUNG"].ToString());
                            hoanung += double.Parse(dtDoanhThu.Rows[i]["HOANUNG"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["HOANUNG"].ToString());
                            hoantra += double.Parse(dtDoanhThu.Rows[i]["HOANTRA"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["HOANTRA"].ToString());
                            tienxe += double.Parse(dtDoanhThu.Rows[i]["THUTIENXE"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["THUTIENXE"].ToString());
                            ravien += double.Parse(dtDoanhThu.Rows[i]["THANHTOANRAVIEN"].ToString() == "" ? "0" : dtDoanhThu.Rows[i]["THANHTOANRAVIEN"].ToString());
                 }
            }
        }
        html += "<tr>";
        html += "<td colspan='3' style='text-align:right;font-weight:bold;'>Tổng tiền : </td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", tienso) + "</td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", tienkham) + "</td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", tiencls) + "</td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", tiendvkt) + "</td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", tienthuoc) + "</td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", tamung) + "</td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", hoanung) + "</td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", hoantra) + "</td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", tienxe) + "</td>";
        html += "<td style='font-weight:bold; text-align:right; padding:0'>" + string.Format(new CultureInfo("de-DE"), "{0:0,0}", ravien) + "</td>";
        html += "</tr>";
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
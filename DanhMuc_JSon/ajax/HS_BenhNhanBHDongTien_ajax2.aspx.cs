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

public partial class HS_BenhNhanBHDongTien_ajax : System.Web.UI.Page
{
    protected DataProcess s_HS_BenhNhanBHDongTien()
    {
        DataProcess HS_BenhNhanBHDongTien = new DataProcess("HS_BenhNhanBHDongTien");
        HS_BenhNhanBHDongTien.data("ID", Request.QueryString["idkhoachinh"]);
        HS_BenhNhanBHDongTien.data("IsBHYT", Request.QueryString["IsBHYT"]);
        HS_BenhNhanBHDongTien.data("IdBenhNhan", Request.QueryString["IdBenhNhan"]);
        HS_BenhNhanBHDongTien.data("HoTenBN", Request.QueryString["HoTenBN"]);
        HS_BenhNhanBHDongTien.data("SoBHYT", Request.QueryString["SoBHYT"]);
        HS_BenhNhanBHDongTien.data("DungTuyen", Request.QueryString["DungTuyen"]);
        HS_BenhNhanBHDongTien.data("TongTienBH", Request.QueryString["TongTienBH"]);
        HS_BenhNhanBHDongTien.data("BHTra", Request.QueryString["BHTra"]);
        HS_BenhNhanBHDongTien.data("BNPhaiTra", Request.QueryString["BNPhaiTra"]);
        HS_BenhNhanBHDongTien.data("TienThuoc", Request.QueryString["TienThuoc"]);
        HS_BenhNhanBHDongTien.data("TienKham", Request.QueryString["TienKham"]);
        HS_BenhNhanBHDongTien.data("TienCLS", Request.QueryString["TienCLS"]);
        HS_BenhNhanBHDongTien.data("TienGiuong", Request.QueryString["TienGiuong"]);
        HS_BenhNhanBHDongTien.data("TienPhuThuBH", Request.QueryString["TienPhuThuBH"]);
        HS_BenhNhanBHDongTien.data("TienGiaDV", Request.QueryString["TienGiaDV"]);
        HS_BenhNhanBHDongTien.data("TongTienBNPT", Request.QueryString["TongTienBNPT"]);
        HS_BenhNhanBHDongTien.data("BNDaTraChenhLechBHYT", Request.QueryString["BNDaTraChenhLechBHYT"]);
        HS_BenhNhanBHDongTien.data("BNPhaiTraChenhLechBHYT", Request.QueryString["BNPhaiTraChenhLechBHYT"]);
        HS_BenhNhanBHDongTien.data("CDHA", Request.QueryString["CDHA"]);
        HS_BenhNhanBHDongTien.data("CLSKhac", Request.QueryString["CLSKhac"]);
        HS_BenhNhanBHDongTien.data("DVKTCao", Request.QueryString["DVKTCao"]);
        HS_BenhNhanBHDongTien.data("Itype", Request.QueryString["Itype"]);
        HS_BenhNhanBHDongTien.data("NgayTinhBH_Thuc", Request.QueryString["NgayTinhBH_Thuc"]);
        HS_BenhNhanBHDongTien.data("ThuocK", Request.QueryString["ThuocK"]);
        HS_BenhNhanBHDongTien.data("ThuThuat", Request.QueryString["ThuThuat"]);
        HS_BenhNhanBHDongTien.data("TiemTruyen", Request.QueryString["TiemTruyen"]);
        HS_BenhNhanBHDongTien.data("TongTienBNDaTra", Request.QueryString["TongTienBNDaTra"]);
        HS_BenhNhanBHDongTien.data("TongTienBNPTConLai", Request.QueryString["TongTienBNPTConLai"]);
        HS_BenhNhanBHDongTien.data("VanChuyen", Request.QueryString["VanChuyen"]);
        HS_BenhNhanBHDongTien.data("VTYT", Request.QueryString["VTYT"]);
        HS_BenhNhanBHDongTien.data("XN", Request.QueryString["XN"]);
        HS_BenhNhanBHDongTien.data("IdKhamBenh_Last", Request.QueryString["IdKhamBenh_Last"]);
        HS_BenhNhanBHDongTien.data("IsView", Request.QueryString["IsView"]);
        HS_BenhNhanBHDongTien.data("HuongDieuTri", Request.QueryString["HuongDieuTri"]);
        HS_BenhNhanBHDongTien.data("IDDANGKYKHAM_DV", Request.QueryString["IDDANGKYKHAM_DV"]);
        HS_BenhNhanBHDongTien.data("TongTienDV", Request.QueryString["TongTienDV"]);
        HS_BenhNhanBHDongTien.data("TOTAL_TAMUNG", Request.QueryString["TOTAL_TAMUNG"]);
        HS_BenhNhanBHDongTien.data("IsNoiTru", Request.QueryString["IsNoiTru"]);
        HS_BenhNhanBHDongTien.data("TOTAL_HOANPHI", Request.QueryString["TOTAL_HOANPHI"]);
        HS_BenhNhanBHDongTien.data("IDCHITIETDANGKYKHAM_LAST", Request.QueryString["IDCHITIETDANGKYKHAM_LAST"]);
        HS_BenhNhanBHDongTien.data("IDBENHNHAN_BH", Request.QueryString["IDBENHNHAN_BH"]);
        HS_BenhNhanBHDongTien.data("MACHANDOAN", Request.QueryString["MACHANDOAN"]);
        HS_BenhNhanBHDongTien.data("TENCHANDOAN", Request.QueryString["TENCHANDOAN"]);
        HS_BenhNhanBHDongTien.data("IDCHITIETDANGKYKHAM_PREV", Request.QueryString["IDCHITIETDANGKYKHAM_PREV"]);
        HS_BenhNhanBHDongTien.data("MASOHOSO", Request.QueryString["MASOHOSO"]);
        HS_BenhNhanBHDongTien.data("SOVAOVIEN", Request.QueryString["SOVAOVIEN"]);
        HS_BenhNhanBHDongTien.data("ISCAPCUU", Request.QueryString["ISCAPCUU"]);
        HS_BenhNhanBHDongTien.data("NGAYTRINHTHE", Request.QueryString["NGAYTRINHTHE"]);
        HS_BenhNhanBHDongTien.data("IsNoiTru_Save", (StaticData.IsCheck(Request.QueryString["IsNoiTru_Save"]) ? "1" : "0"));
        HS_BenhNhanBHDongTien.data("IsNoiTru", Request.QueryString["IsNoiTru_Save"]);
        return HS_BenhNhanBHDongTien;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_HS_BenhNhanBHDongTien(); break;
            case "xoa": Xoa_HS_BenhNhanBHDongTien(); break;
            case "TimKiem": TimKiem(); break;
            case "Config": Config(); break;
        }
    }
    private void Xoa_HS_BenhNhanBHDongTien()
    {
        try
        {
            DataProcess process = s_HS_BenhNhanBHDongTien();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("ID"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_HS_BenhNhanBHDongTien()
    {
        try
        {
            DataProcess process = s_HS_BenhNhanBHDongTien();
            if (process.getData("ID") != null && process.getData("ID") != "")
            {
                string ID = process.getData("ID");
                bool OK2 = DataAcess.Connect.ExecSQL("UPDATE HS_SOVAOVIEN SET ISDAHUY=1 ,NGAYHUY=GETDATE() WHERE IDBENHNHANBHDONGTIEN=" + ID);
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear();
                    Response.Write(process.getData("ID"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear();
                    Response.Write(process.getData("ID"));
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
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("HoTenBN") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgaySinh") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("BHYT?") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoBHYT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày vào viện") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Khoa tạo ") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("CHUYỂN TỚI") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SOVAOVIEN") + "</th>");
        
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nội trú?") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool search = Userlogin_new.HavePermision(this, "HS_BenhNhanBHDongTien_Search");
        if (search)
        {
            DataProcess process = s_HS_BenhNhanBHDongTien();
            process.Page = Request.QueryString["page"];
            process.NumberRow = "50";
            string sqlSelect = @"select STT=row_number() over (order by T.SOVAOVIEN),
                              T.*,B.Ngaysinh,KhoaTao=dbo.HS_KHOATAOSOVAOVIEN(t.id),CHUYENTOI=dbo.HS_KHOACHUYEN_SOVAOVIEN(t.id)
                               from HS_BenhNhanBHDongTien T
                              LEFT JOIN BENHNHAN B ON T.IDBENHNHAN=B.IDBENHNHAN
                             where " + process.sWhere();
            string TuNgay = Request.QueryString["TuNgay"];
            string DenNgay = Request.QueryString["DenNgay"];
            string SoVaoVienNotEmply = Request.QueryString["SoVaoVienNotEmply"];
            if (TuNgay != null && TuNgay != "")
            {
                TuNgay = StaticData.CheckDate(TuNgay);
                sqlSelect += " AND NGAYTINHBH>='" + TuNgay + "'";
            }
            if (DenNgay != null && DenNgay != "")
            {
                DenNgay = StaticData.CheckDate(DenNgay) + " 23:59:59";
                sqlSelect += " AND NGAYTINHBH<='" + DenNgay + "'";
            }
            if (StaticData.IsCheck(SoVaoVienNotEmply))
                sqlSelect += " AND ISNULL(SOVAOVIEN ,'') <>''";

            //string TenBenhNhan = process.getData("HoTenBN");
            //string SoBHYT = process.getData("SoBHYT");
            //if (TenBenhNhan != null && TenBenhNhan != "")
            //    sqlSelect += " AND ( B.TENBENHNHAN LIKE N'%" + TenBenhNhan + "%' OR NameNotSign LIKE N'" + StaticData.s_GetNameNotSign(TenBenhNhan) + "')";
            //if (SoBHYT != null && SoBHYT != "")
            //    sqlSelect += " AND B.SOBHYT LIKE N'" + SoBHYT + "'";

            sqlSelect = sqlSelect.Replace("T.isnoitru_save LIKE N'%1%'", "ISNULL(T.isnoitru_save,0) = '1'");
            sqlSelect = sqlSelect.Replace("T.isnoitru_save LIKE N'%0%'", "ISNULL(T.isnoitru_save,0) = '0'");
            DataTable table = process.Search(sqlSelect);
            if (table.Rows.Count > 0)
            {
                bool delete = Profess.Userlogin.HavePermision(this, "HS_BenhNhanBHDongTien_Delete");
                bool edit = Profess.Userlogin.HavePermision(this, "HS_BenhNhanBHDongTien_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><input mkv='true' id='HoTenBN' type='text' value='" + table.Rows[i]["HoTenBN"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:250px' " + (!(1 > 1) ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='NgaySinh' type='text' value='" + table.Rows[i]["NgaySinh"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:70px' " + (!(1 > 1) ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='IsBHYT' type='checkbox' " + (table.Rows[i]["IsBHYT"].ToString() == "True" ? "checked" : "") + " onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!(1 > 1) ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='SoBHYT' type='text' value='" + table.Rows[i]["SoBHYT"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100px' " + (!(1 > 1) ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='NgayTinhBH' type='text' value='" + DateTime.Parse(table.Rows[i]["NgayTinhBH"].ToString()).ToString("dd/MM/yyyy HH:mm") + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:70px' " + (!(1 > 1) ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='KHOATAO' type='text' value='" + table.Rows[i]["KHOATAO"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100px' " + (!(1 > 1) ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='CHUYENTOI' type='text' value='" + table.Rows[i]["CHUYENTOI"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100px' " + (!(1 > 1) ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='SOVAOVIEN' type='text' value='" + table.Rows[i]["SOVAOVIEN"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100px' " + (!(1 == 1) ? "disabled" : "") + "/></td>");
                    
                    html.Append("<td><input mkv='true' id='IsNoiTru_Save' type='checkbox' " + (StaticData.IsCheck(table.Rows[i]["IsNoiTru_Save"].ToString()) == true ? "checked" : "") + " style='width:20px' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (!(1 == 1) ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id=\"idkhoachinh\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["ID"] + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        string xhtml = paging;
        xhtml += html.ToString();
        Response.Clear(); Response.Write(xhtml);

    }
    private void Config()
    {
        string DenNgay = Request.QueryString["DenNgay"];
        string IsNoiTru_Save = Request.QueryString["IsNoiTru_Save"];
        string SoVaoVienMax = Request.QueryString["SoVaoVienMax"];
        if (DenNgay == null || DenNgay == "") return;
        if (IsNoiTru_Save == null || IsNoiTru_Save == "") return;
        if (SoVaoVienMax == null || SoVaoVienMax == "") return;
        if (StaticData.IsNumber(SoVaoVienMax) == false) return;
        DenNgay = StaticData.CheckDate(DenNgay);
        IsNoiTru_Save = (StaticData.IsCheck(IsNoiTru_Save) == true ? "1" : "0");
        string sqlDelete = "DELETE HS_SOVAOVIEN WHERE YEAR(SYSDATE)=YEAR('" + DenNgay + "')"
                                + " AND ISNOITRU=" + IsNoiTru_Save
                                + " AND SL>" + SoVaoVienMax;
        bool OK1 = DataAcess.Connect.ExecSQL(sqlDelete);
        string sqlInsert = @" 
                            IF NOT EXISTS (SELECT * FROM HS_SOVAOVIEN WHERE YEAR(SYSDATE)=YEAR('" + DenNgay + "')"
                                + " AND ISNOITRU=" + IsNoiTru_Save
                                + " AND SL=" + SoVaoVienMax + @") 
                            INSERT INTO HS_SOVAOVIEN(SYSDATE,SL,ISNOITRU) VALUES (N'" + DenNgay + "'," + SoVaoVienMax + "," + IsNoiTru_Save + ")";
        bool OK2 = DataAcess.Connect.ExecSQL(sqlInsert);
        Response.Write("1");

    }
}



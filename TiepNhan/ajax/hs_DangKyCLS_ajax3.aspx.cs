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

public partial class hs_DangKyCLS_ajax : System.Web.UI.Page
{
    protected DataProcess s_hs_DangKyCLS()
    {
        DataProcess hs_DangKyCLS = new DataProcess("hs_DangKyCLS");
        hs_DangKyCLS.data("IdDangKyCLS", Request.QueryString["idkhoachinh"]);
        hs_DangKyCLS.data("MaPhieuCLS", Request.QueryString["MaPhieuCLS"]);
        hs_DangKyCLS.data("NgayDK", Request.QueryString["NgayDK"]);
        hs_DangKyCLS.data("NguoiDK", Request.QueryString["idnguoidung"]);
        hs_DangKyCLS.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        return hs_DangKyCLS;
    }
    protected DataProcess s_khambenhcanlamsan()
    {
        DataProcess khambenhcanlamsan = new DataProcess("khambenhcanlamsan");
        khambenhcanlamsan.data("idkhambenhcanlamsan", Request.QueryString["idkhoachinh"]);
        khambenhcanlamsan.data("idkhambenh", Request.QueryString["idkhambenh"]);
        khambenhcanlamsan.data("idcanlamsan", Request.QueryString["idcanlamsan"]);
        khambenhcanlamsan.data("dongia", Request.QueryString["dongia"]);
        khambenhcanlamsan.data("idbacsi", Request.QueryString["idbacsi"]);
        khambenhcanlamsan.data("dathu", Request.QueryString["dathu"]);
        khambenhcanlamsan.data("dakham", Request.QueryString["dakham"]);
        khambenhcanlamsan.data("ngaythu", Request.QueryString["ngaythu"]);
        khambenhcanlamsan.data("idnguoidung", Request.QueryString["idnguoidung"]);
        khambenhcanlamsan.data("ngaykham", Request.QueryString["ngaykham"]);
        khambenhcanlamsan.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        khambenhcanlamsan.data("tenBSChiDinh", Request.QueryString["tenBSChiDinh"]);
        khambenhcanlamsan.data("maphieuCLS", Request.QueryString["maphieuCLS"]);
        khambenhcanlamsan.data("thucthu", Request.QueryString["thucthu"]);
        khambenhcanlamsan.data("dahuy", Request.QueryString["dahuy"]);
        khambenhcanlamsan.data("soluong", Request.QueryString["soluong"]);
        khambenhcanlamsan.data("chietkhau", Request.QueryString["chietkhau"]);
        khambenhcanlamsan.data("thanhtien", Request.QueryString["thanhtien"]);
        khambenhcanlamsan.data("IdNguoiThu", Request.QueryString["IdNguoiThu"]);
        khambenhcanlamsan.data("BHTra", Request.QueryString["BHTra"]);
        khambenhcanlamsan.data("GhiChu", Request.QueryString["GhiChu"]);
        khambenhcanlamsan.data("LoaiKhamID", Request.QueryString["LoaiKhamID"]);
        khambenhcanlamsan.data("idkhoadangky", Request.QueryString["idkhoadangky"]);
        khambenhcanlamsan.data("sldakham", Request.QueryString["sldakham"]);
        khambenhcanlamsan.data("istieuphau", Request.QueryString["istieuphau"]);
        khambenhcanlamsan.data("isphauthuat", Request.QueryString["isphauthuat"]);
        khambenhcanlamsan.data("IsHoanTraCLS", Request.QueryString["IsHoanTraCLS"]);
        khambenhcanlamsan.data("BHYTTra", Request.QueryString["BHYTTra"]);
        khambenhcanlamsan.data("BNDaTra", Request.QueryString["BNDaTra"]);
        khambenhcanlamsan.data("BNTongPhaiTra", Request.QueryString["BNTongPhaiTra"]);
        khambenhcanlamsan.data("BNTra", Request.QueryString["BNTra"]);
        khambenhcanlamsan.data("DonGiaBH", Request.QueryString["DonGiaBH"]);
        khambenhcanlamsan.data("DonGiaDV", Request.QueryString["DonGiaDV"]);
        khambenhcanlamsan.data("IsBHYT", Request.QueryString["IsBHYT"]);
        khambenhcanlamsan.data("ISBNDaTra", Request.QueryString["ISBNDaTra"]);
        khambenhcanlamsan.data("NgayQuayLai", Request.QueryString["NgayQuayLai"]);
        khambenhcanlamsan.data("NGAYTINHBH_THUC", Request.QueryString["NGAYTINHBH_THUC"]);
        khambenhcanlamsan.data("PhuThuBH", Request.QueryString["PhuThuBH"]);
        khambenhcanlamsan.data("PrevBNTra", Request.QueryString["PrevBNTra"]);
        khambenhcanlamsan.data("ThanhTienBH", Request.QueryString["ThanhTienBH"]);
        khambenhcanlamsan.data("ThanhTienDV", Request.QueryString["ThanhTienDV"]);
        khambenhcanlamsan.data("IdChiTietPTT", Request.QueryString["IdChiTietPTT"]);
        khambenhcanlamsan.data("IdDangKyCLS", Request.QueryString["IdDangKyCLS"]);
        khambenhcanlamsan.data("idbacsicd", Request.QueryString["idbacsicd"]);
        return khambenhcanlamsan;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savehs_DangKyCLS(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTablekhambenhcanlamsan": LuuTablekhambenhcanlamsan(); break;
            case "loadTablekhambenhcanlamsan": loadTablekhambenhcanlamsan(); break;
            case "xoa": Xoahs_DangKyCLS(); break;
            case "xoakhambenhcanlamsan": Xoakhambenhcanlamsan(); break;
            case "idkhoasearch": idkhoasearch(); break;
            case "idphongsearch": idphongsearch(); break;
            case "idcanlamsanSearch": idcanlamsanSearch(); break;
            case "idbenhnhanSearch": idbenhnhanSearch(); break;
            case "idnguoidungSearch": idnguoidungSearch(); break;
            case "LoadDanhSachBacSiCD": LoadDanhSachBacSiCD(); break;
            case "idkhoadangkysearch": idkhoadangkysearch(); break;
            case "HuyCLS": HuyCLS(); break;
        }
    }
    private void HuyCLS()
    {
        string idkhambenhcanlamsan = Request.QueryString["idkhambenhcanlamsan"];
        string idcanlamsan = Request.QueryString["idcanlamsan"];
        string sqlUpdate = @"UPDATE KHAMBENHCANLAMSAN SET DAHUY=1 WHERE IDKHAMBENHCANLAMSAN='" + idkhambenhcanlamsan + "' AND IDCANLAMSAN='" + idcanlamsan + "'";
        bool ok = DataAcess.Connect.ExecSQL(sqlUpdate);
        if (!ok)
        {
            Response.Clear();
            Response.Write("Không thể thực hiện việc hủy");
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("Đã hủy thành công");
            return;
        }
    }
    private void LoadDanhSachBacSiCD()
    {
        string sqlBacSi = @"select * from bacsi";
        DataTable table = DataAcess.Connect.GetTable(sqlBacSi);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idbenhnhanSearch()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        if (idbenhnhan == "" && idbenhnhan == null) return;
        DataTable table = DataAcess.Connect.GetTable("select top 1 * from benhnhan where idbenhnhan=" + idbenhnhan);
        string html = "";

        if (table != null)
        {

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idnguoidungSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select idnguoidung ,tennguoidung from nguoidung where idbacsi is null");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idkhoasearch()
    {
        string selectTenPhong = @"select pkb.idphongkhambenh,pkb.tenphongkhambenh from phongkhambenh
            pkb where loaiphong=1 order by pkb.idphongkhambenh";
        DataTable table = DataAcess.Connect.GetTable(selectTenPhong);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idphongsearch()
    {
        string swhere = "";
        string idpkb = Request.QueryString["idpkb"];
        if (idpkb != null && idpkb != "")
        {
            swhere += " and bg.idphongkhambenh=" + StaticData.ParseInt(idpkb);
        }
        string sqlSelectTenNhom = ""
                                    + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh" + "\r\n"
                                    + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
                                    + " where 1=1  " + swhere + "  and  loaiphong=1 \r\n";
        DataTable table = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][0].ToString() + "|" + StaticData.IntelName(table.Rows[i][1].ToString()) + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);

    }
    private void idcanlamsanSearch()
    {
        string swhere = "";
        string tennhom = Request.QueryString["tennhom"];
        if (tennhom != null && tennhom != "")
        {
            swhere += " and bg.tennhom like N'" + tennhom + "'";
        }
        string sqlSelect = @"SELECT * FROM BANGGIADICHVU bg WHERE 1=1 " + swhere + " and ISCHUYENKHOA=0 AND TENDICHVU LIKE N'%" + Request.QueryString["q"] + "%'";

        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i]["TenDichVu"].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoahs_DangKyCLS()
    {
        try
        {
            DataProcess process = s_hs_DangKyCLS();
            string IdDangKyCLS = process.getData("IdDangKyCLS");
            string sqlSelect = "SELECT COUNT(*) FROM KHAMBENHCANLAMSAN WHERE  IdDangKyCLS=" + IdDangKyCLS + " AND ( DATHU=1 OR ISBNDATRA=1 ) AND ISNULL(dahuy,0)=0";
            DataTable dtTest = DataAcess.Connect.GetTable(sqlSelect);
            if (dtTest != null && dtTest.Rows.Count != 0)
            {
                if (dtTest.Rows[0][0].ToString() != "0")
                {
                    Response.StatusCode = 500;
                    return;
                }
            }

            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdDangKyCLS"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void Xoakhambenhcanlamsan()
    {
        try
        {
            DataProcess process = s_khambenhcanlamsan();
            string idKhamBenhCLS = process.getData("idkhambenhcanlamsan");
            string sqlCLS = "select dathu,ISBNDaTra from khambenhcanlamsan where idkhambenhcanlamsan=" + idKhamBenhCLS;
            DataTable dtCLS = DataAcess.Connect.GetTable(sqlCLS);
            string dathu = dtCLS.Rows[0]["dathu"].ToString();
            if (dathu == "" || dathu.ToLower() == "false" || dathu == "0") dathu = "0";
            else dathu = "1";


            string ISBNDaTra = dtCLS.Rows[0]["ISBNDaTra"].ToString();
            if (ISBNDaTra == "" || ISBNDaTra.ToLower() == "false" || ISBNDaTra == "0") ISBNDaTra = "0";
            else ISBNDaTra = "1";
            if (dathu == "1" || ISBNDaTra == "1")
            {
                Response.StatusCode = 500;
                Response.Write("Dịch vụ kĩ thuật này được thu tiền rồi !");
                return;

            }
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
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
        if (StaticData.HavePermision1(this, "hs_DangKyCLS_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"];
            if (idkhoachinh == "") idkhoachinh = "0";
            string sql = @"SELECT a.*, tenbschidinh=(CASE WHEN ISNULL(B.IDKHAMBENH,0)=0 THEN b.tenbschidinh ELSE E.TENBACSI END),b.dathu ,b.idkhambenh,b.idkhoadangky,c.tenphongkhambenh as mkv_idkhoadangky 
                    from hs_DangKyCLS a left join khambenhcanlamsan b on a.iddangkycls=b.iddangkycls 
                    left join phongkhambenh c on b.idkhoadangky=c.idphongkhambenh 
                    LEFT JOIN KHAMBENH D ON B.IDKHAMBENH=D.IDKHAMBENH
                    LEFT JOIN BACSI E ON D.IDBACSI=E.IDBACSI
                    where a.IDDANGKYCLS='" + idkhoachinh + "' ";
            DataTable table = DataAcess.Connect.GetTable(sql);
            string html = "";
            html += "<root>";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
                    DataTable DT_idbenhnhan = Process.benhnhan.dtSearchByidbenhnhan("'" + table.Rows[0]["idbenhnhan"] + "'");
                    html += "<data id='idbenhnhan'>" + ((DT_idbenhnhan.Rows.Count > 0) ? DT_idbenhnhan.Rows[0][0] : "") + "</data>";
                    html += "<data id=\"mkv_idbenhnhan\">" + ((DT_idbenhnhan.Rows.Count > 0) ? DT_idbenhnhan.Rows[0][2] : "") + "</data>";


                    DataTable DT_idnguoidung = Process.nguoidung.dtSearchByidnguoidung("'" + table.Rows[0]["nguoidk"] + "'");
                    html += "<data id='idnguoidung'>" + ((DT_idnguoidung.Rows.Count > 0) ? DT_idnguoidung.Rows[0][0] : "") + "</data>";
                    html += "<data id=\"mkv_idnguoidung\">" + ((DT_idnguoidung.Rows.Count > 0) ? DT_idnguoidung.Rows[0][1] : "") + "</data>";
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
            }
            html += "</root>";
            Response.Clear();
            Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }
    private void TimKiem()
    {
        if (StaticData.HavePermision1(this, "hs_DangKyCLS_Search"))
        {
            DataProcess process = s_hs_DangKyCLS();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdDangKyCLS),T.*
                               from hs_DangKyCLS T
          where " + process.sWhere());
            string html = "";
            html += "<table class='jtable' id=\"gridTablecls\">";
            html += "<tr>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdDangKyCLS") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaPhieuCLS") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayDK") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NguoiDK") + "</th>";
            html += "</tr>";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr onclick=\"setControlFind('" + table.Rows[i]["IdDangKyCLS"].ToString() + "')\">";
                        html += "<td>" + table.Rows[i]["MaPhieuCLS"].ToString() + "</td>";
                        if (table.Rows[i]["NgayDK"].ToString() != "")
                        {
                            html += "<td>" + DateTime.Parse(table.Rows[i]["NgayDK"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                        }
                        else { html += "<td>" + table.Rows[i]["NgayDK"].ToString() + "</td>"; }
                        html += "<td>" + table.Rows[i]["NguoiDK"].ToString() + "</td>";
                        html += "</tr>";
                    }
                    html += "</table>";
                    html += process.Paging();
                    Response.Clear(); Response.Write(html);
                    return;
                }
            }
            else
            {
                Response.StatusCode = 500;
            }
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }
    private void Savehs_DangKyCLS()
    {
        try
        {
            DataProcess process = s_hs_DangKyCLS();
            if (process.getData("IdDangKyCLS") != null && process.getData("IdDangKyCLS") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdDangKyCLS"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdDangKyCLS"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablekhambenhcanlamsan()
    {
        try
        {
            DataProcess process = s_khambenhcanlamsan();
            string idcanlamsan = process.getData("idcanlamsan");

            string idkhoadangky = Request.QueryString["idkhoadangky"];
            if (idkhoadangky != null && idkhoadangky != "")
            {
                idkhoadangky = Request.QueryString["idkhoadangky"];
            }

            DataTable dt = DataAcess.Connect.GetTable("SELECT * FROM BANGGIADICHVU WHERE IDBANGGIADICHVU=" + idcanlamsan);
            if (dt == null || dt.Rows.Count == 0)
            {
                Response.StatusCode = 500;
                return;
            }
            string bscd = Request.QueryString["bscd"];
            if (bscd != null && bscd != "")
            {
                process.data("tenbschidinh", bscd);
            }

            string DonGiaDV = dt.Rows[0]["GiaDichVu"].ToString();
            string SoLuongDV = process.getData("soluong");
            if (DonGiaDV == "") DonGiaDV = "0";
            if (SoLuongDV == "0" || SoLuongDV == "") SoLuongDV = "1";

            double ThanhTienDV = double.Parse(DonGiaDV) * double.Parse(SoLuongDV);
            process.data("DonGiaDV", DonGiaDV);
            process.data("ThanhTienDV", ThanhTienDV.ToString());
            process.data("SoLuong", SoLuongDV);
            process.data("IsBHYT", "0");
            process.data("idkhoadangky", idkhoadangky);

            if (process.getData("idkhambenhcanlamsan") != null && process.getData("idkhambenhcanlamsan") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                    return;
                }
            }
            else
            {
                string sqlSelect = "SELECT TOP 1 * FROM HS_DANGKYCLS WHERE iddangkycls=" + Request.QueryString["iddangkycls"] + " ORDER BY NGAYDK DESC";
                DataTable dtHS_CLS = DataAcess.Connect.GetTable(sqlSelect);
                if (dtHS_CLS == null)
                {
                    Response.Write("");
                    return;
                }
                else
                {
                    process.data("DaThu", "0");
                    process.data("dongia", dt.Rows[0]["giadichvu"].ToString());
                    process.data("bntongphaitra", ThanhTienDV.ToString());
                    process.data("idbenhnhan", dtHS_CLS.Rows[0]["idbenhnhan"].ToString());

                    string maphieucls = "";
                    string idbenhnhan = process.getData("idbenhnhan");
                    if (idbenhnhan != null && idbenhnhan != "" && idbenhnhan != "0")
                    {
                        string sqlPrev = "SELECT TOP 1 MAPHIEUCLS FROM KHAMBENHCANLAMSAN WHERE CONVERT(NVARCHAR, NGAYTHU,120)=CONVERT(NVARCHAR, '" + dtHS_CLS.Rows[0]["ngaydk"] + "',120) AND IDBENHNHAN=" + process.getData("idbenhnhan") + " AND ISNULL(DATHU,0)=0 ORDER BY IDKHAMBENHCANLAMSAN DESC";
                        DataTable dtPrev = DataAcess.Connect.GetTable(sqlPrev);
                        if (dtPrev != null && dtPrev.Rows.Count > 0)
                            maphieucls = dtPrev.Rows[0][0].ToString();
                    }
                    if (maphieucls == null || maphieucls == "")
                        maphieucls = dtHS_CLS.Rows[0]["maphieucls"].ToString();
                    process.data("maphieucls", maphieucls);

                    process.data("nguoithu", dtHS_CLS.Rows[0]["nguoidk"].ToString());
                    process.data("ngaythu", string.Format("{0:dd/MM/yyyy hh:mm}", dtHS_CLS.Rows[0]["ngaydk"]));
                    process.data("idkhambenh", "0");
                    bool ok = process.Insert();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                        return;
                    }
                }

            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTablekhambenhcanlamsan()
    {
        string paging = "";
        string html = "";
        html += "<table class='jtable' id=\"gridTablecls\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Khoa</th>";
        html += "<th>Tên nhóm</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idcanlamsan") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DaThu") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        bool add = StaticData.HavePermision1(this, "khambenhcanlamsan_Add");
        bool search = StaticData.HavePermision1(this, "khambenhcanlamsan_Search");
        DataProcess process = s_khambenhcanlamsan();
        process.Page = Request.QueryString["page"];
        string sqlSelect = @"select STT=row_number() over (order by T.idkhambenhcanlamsan),T.*
                   ,A.TenDichVu,a.tennhom,a.idphongkhambenh,pkb.tenphongkhambenh
                               from khambenhcanlamsan T
                    left join banggiadichvu  A on T.idcanlamsan=A.idbanggiadichvu
                    left join phongkhambenh pkb on a.idphongkhambenh=pkb.idphongkhambenh
                        where T.IdDangKyCLS='" + process.getData("IdDangKyCLS") + "'  and isnull(t.dahuy,0)=0";
        DataTable table = process.Search(sqlSelect);

        if (search)
        {
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("khambenhcanlamsan");
                bool delete = StaticData.HavePermision1(this, "khambenhcanlamsan_Delete");
                bool edit = StaticData.HavePermision1(this, "khambenhcanlamsan_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string dathu = table.Rows[i]["dathu"].ToString();
                    if (dathu == "" || dathu.ToLower() == "false" || dathu == "0") dathu = "0";
                    else dathu = "1";
                    string ISBNDaTra = table.Rows[i]["ISBNDaTra"].ToString();
                    if (ISBNDaTra == "" || ISBNDaTra.ToLower() == "false" || ISBNDaTra == "0") ISBNDaTra = "0";
                    else ISBNDaTra = "1";

                    string idkhambenh = table.Rows[i]["idkhambenh"].ToString();
                    bool IsKhamBenh = false;
                    if (idkhambenh != "" && idkhambenh != "0")
                        IsKhamBenh = true;

                    if (dathu == "1" || ISBNDaTra == "1") dathu = "Đã thu";
                    else dathu = "Chưa thu";
                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + (dathu == "Đã thu" || IsKhamBenh ? "" : hsLibrary.clDictionaryDB.sGetValueLanguage("delete")) + "</a></td>";
                    html += "<td><input mkv='true' id='idkhoa' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idphongkhambenh"] + " ' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idkhoa' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhoasearch(this)' onblur='idkhoachange(this);' value='" + table.Rows[i]["tenphongkhambenh"] + "'  style='width:150px' class='down_select'/></td>";
                    html += "<td><input mkv='true' id='mkv_tennhom' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idphongsearch(this)' value='" + table.Rows[i]["tennhom"] + "'  style='width:180px' class='down_select'/></td>";
                    html += "<td><input mkv='true' id='idcanlamsan' type='hidden' value='" + table.Rows[i]["idcanlamsan"] + "'/><input mkv='true' id='mkv_idcanlamsan' type='text' value='" + table.Rows[i]["TenDichVu"].ToString() + "' onfocus='idcanlamsanSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluong"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input  id='isDaThu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dathu + "'" + "/></td>";
                    html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idkhambenhcanlamsan"].ToString() + "'/><a onclick='huyontablecls(this)'>Hủy</a></td>";
                    html += "</tr>";
                }
            }
        }
        if (add)
        {
            html += "<tr>";
            html += "<td>" + (table.Rows.Count > 0 && table != null ? table.Rows.Count + 1 : 1) + "</td>";
            html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td><input mkv='true' id='idkhoa' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idkhoa' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhoasearch(this)' value=''  style='width:150px' class='down_select'/></td>";
            html += "<td><input mkv='true' id='mkv_tennhom' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idphongsearch(this)' value=''  style='width:180px' class='down_select'/></td>";
            html += "<td><input mkv='true' id='idcanlamsan' type='hidden' value=''/><input mkv='true' id='mkv_idcanlamsan' type='text' value='' onfocus='idcanlamsanSearch(this);' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input id='isDaThu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  /></td>";
            html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/><a onclick='huyontablecls(this)'>Hủy</a></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
        html += "</table>";
        if (!search)
            html += "Bạn không có quyền xem.";
        else
            html += paging;
        Response.Clear(); Response.Write(html);
    }
    private void idkhoadangkysearch()
    {
        string selectTenPhong = @"select pkb.idphongkhambenh,pkb.tenphongkhambenh from phongkhambenh
            pkb where loaiphong=0 order by pkb.idphongkhambenh";
        DataTable table = DataAcess.Connect.GetTable(selectTenPhong);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
}



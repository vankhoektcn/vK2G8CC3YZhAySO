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
using hsLibrary;
public partial class benhnhan_ajax : System.Web.UI.Page
{
    protected DataProcess s_benhnhan()
    {
        DataProcess benhnhan = new DataProcess("benhnhan");
        benhnhan.data("idbenhnhan", Request.QueryString["idkhoachinh"]);
        benhnhan.data("mabenhnhan", Request.QueryString["mabenhnhan"]);
        benhnhan.data("tenbenhnhan", Request.QueryString["tenbenhnhan"]);
        benhnhan.data("idloaiuutien", Request.QueryString["idloaiuutien"]);
        benhnhan.data("diachi", Request.QueryString["diachi"]);
        benhnhan.data("dienthoai", Request.QueryString["dienthoai"]);
        benhnhan.data("gioitinh", Request.QueryString["gioitinh"]);
        benhnhan.data("ngaysinh", Request.QueryString["ngaysinh"]);
        benhnhan.data("loai", Request.QueryString["loai"]);
        benhnhan.data("nghenghiep", Request.QueryString["nghenghiep"]);
        benhnhan.data("noicongtac", Request.QueryString["noicongtac"]);
        benhnhan.data("ngaytiepnhan", Request.QueryString["ngaytiepnhan"]);
        benhnhan.data("SoTuoi", Request.QueryString["SoTuoi"]);
        benhnhan.data("SoThang", Request.QueryString["SoThang"]);
        benhnhan.data("nghenghiep", Request.QueryString["nghenghiep"]);
        benhnhan.data("quoctich", Request.QueryString["quoctich"]);
        benhnhan.data("dantoc", Request.QueryString["dantoc"]);
        benhnhan.data("noicongtac", Request.QueryString["noicongtac"]);
        benhnhan.data("chungminhthu", Request.QueryString["chungminhthu"]);
        benhnhan.data("lidovaovien", Request.QueryString["lidovaovien"]);
        benhnhan.data("tinhid", Request.QueryString["tinhid"]);
        benhnhan.data("quanhuyenid", Request.QueryString["quanhuyenid"]);
        benhnhan.data("phuongxaid", Request.QueryString["phuongxaid"]);
        benhnhan.data("sonha", Request.QueryString["sonha"]);
        benhnhan.data("SLBN", Request.QueryString["SLBN"]);
        benhnhan.data("NguoiGiamHo", Request.QueryString["NguoiGiamHo"]);
        return benhnhan;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savebenhnhan(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoabenhnhan(); break;
            case "idloaiuutienSearch": idloaiuutienSearch(); break;
            case "loaiSearch": loaiSearch(); break;
            //case "idloaitainan": idloaitainan(); break;
            case "idphongkhambenhSearch": idphongkhambenhSearch(); break;
            case "idkhoasearch": idkhoasearch(); break;
            case "dangkykhambenh": dangkykhambenh(); break;
            case "loadSTT": loadSTT(); break;
            case "ktramabh": ktramabh(); break;
            case "idChuyenKhoaSearch": idChuyenKhoaSearch(); break;
            case "tinhidSearch": tinhidSearch(); break;
            case "quanhuyenidSearch": quanhuyenidSearch(); break;
            case "phuongxaidSearch": phuongxaidSearch(); break;
            case "loadDSDangkykham": loadDSDangkykham(); break;
            case "TimDiaChi": TimDiaChi(); break;
            case "getTileBHYT": getTileBHYT(); break;
            case "TinhTuoiBenhNhan": TinhTuoiBenhNhan(); break;
            case "TinhNamSinh_TheoTuoi": TinhNamSinh_TheoTuoi(); break;
            case "TinhNamSinh_TheoThang": TinhNamSinh_TheoThang(); break;
            case "GetLastIDDangKyCLS": GetLastIDDangKyCLS(); break;
            case "checkBN": checkBN(); break;
            case "nhapvienmoi": nhapvienmoi(); break;
            case "idbacsisearch": idbacsisearch(); break;
            case "LoadChanDoanMoTaICD": LoadChanDoanMoTaICD(); break;
            case "LoadChanDoanMaICD": LoadChanDoanMaICD(); break;
            case "LuuNhapVien": LuuNhapVien(); break;
            case "idkhoa_noitru_search": idkhoa_noitru_search(); break;
            case "chonbhkhac": chonbhkhac(); break;
            case "chonthongtinbh": chonthongtinbh(); break;
            case "loadmanghenghiep": loadmanghenghiep(); break;
            case "loadtennghenghiep": loadtennghenghiep(); break;
            case "loadmaquoctich": loadmaquoctich(); break;
            case "loadtenquoctich": loadtenquoctich(); break;
            case "loadmadantoc": loadmadantoc(); break;
            case "loadtendantoc": loadtendantoc(); break;
            case "idnghenghiepsearch": idnghenghiepsearch(); break;
            case "iddantocsearch": iddantocsearch(); break;
            case "idquoctichsearch": idquoctichsearch(); break;
            case "loadmadangky": loadmadangky(); break;
            case "loadnoidangky": loadnoidangky(); break;
            case "setdefault": setdefault(); break;
            case "check_chungminhthu": check_chungminhthu(); break;
            case "get_last_thongtin_bh": get_last_thongtin_bh(); break;
            case "check_thuphi": check_thuphi(); break;
            case "TinhLaiTien": TinhLaiTien(); break;

        }
    }
    private void check_thuphi()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string idbenhnhan_bh = Request.QueryString["idbenhnhan_bh"];
        string sqlSelect = @"SELECT DATHU 
                             FROM DANGKYKHAM  
                        WHERE IDBENHNHAN='" + idbenhnhan + "'" + " AND IDBENHNHAN_BH='" + idbenhnhan_bh + "'";
        DataTable dtCheck = DataAcess.Connect.GetTable(sqlSelect);
        if (dtCheck == null || dtCheck.Rows.Count == 0) return;
        Response.Write("Không thể sửa số BHYT khi đã thu phí rồi. Cảm ơn.");

    }
    private void Set_ThongTinBaoHiem(string IdBenhNhan, string IdBenhNhan_BH)
    {
        string sql = @"SELECT TOP 1 * FROM BENHNHAN_BHYT WHERE " + (IdBenhNhan_BH != null && IdBenhNhan_BH != "" ? "  IdBenhNhan_BH=" + IdBenhNhan_BH : "  IDBENHNHAN='" + IdBenhNhan + "'") + " ORDER BY IDBENHNHAN_BH DESC";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        html += "<root>";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string sqlSelect = @"SELECT * FROM KB_NOIDANGKYKB WHERE IDNOIDANGKY='" + table.Rows[i]["IdNoiDangKyBH"].ToString() + "'";
                DataTable dtKBNoiDangKy = DataAcess.Connect.GetTable(sqlSelect);
                html += "<data id=\"mvk_MADANGKY\">" + ((dtKBNoiDangKy != null && dtKBNoiDangKy.Rows.Count > 0) ? dtKBNoiDangKy.Rows[0]["MADANGKY"].ToString() : "") + "</data>";
                html += "<data id=\"mkv_TENNOIDANGKY\">" + ((dtKBNoiDangKy != null && dtKBNoiDangKy.Rows.Count > 0) ? dtKBNoiDangKy.Rows[0]["TENNOIDANGKY"].ToString() : "") + "</data>";
                string sqlSelect2 = @"SELECT * FROM KB_NOIDANGKYKB WHERE IDNOIDANGKY='" + table.Rows[i]["IdNoiGioiThieu"].ToString() + "'";
                DataTable dtKBNoiDangKy2 = DataAcess.Connect.GetTable(sqlSelect2);
                html += "<data id=\"mkv_ma_noigioithieu\">" + ((dtKBNoiDangKy2 != null && dtKBNoiDangKy2.Rows.Count > 0) ? dtKBNoiDangKy2.Rows[0]["MADANGKY"].ToString() : "") + "</data>";
                html += "<data id=\"mkv_ten_noigioithieu\">" + ((dtKBNoiDangKy2 != null && dtKBNoiDangKy2.Rows.Count > 0) ? dtKBNoiDangKy2.Rows[0]["TENNOIDANGKY"].ToString() : "") + "</data>";
                html += "<data id=\"TraiTuyen\">" + (table.Rows[i]["DungTuyen"].ToString() == "Y" ? "False" : "True") + "</data>";
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
                html += "<data id=\"dungtuyen\">" + (table.Rows[i]["DungTuyen"].ToString() == "Y" ? "True" : "False") + "</data>";
            }
        }
        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }
    private void get_last_thongtin_bh()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        Set_ThongTinBaoHiem(idbenhnhan, null);
    }
    private void check_chungminhthu()
    {
        string socmnd = Request.QueryString["chungminhthu"];
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        if (socmnd == null && socmnd == "") return;
        string sqlSelect = @"SELECT CHUNGMINHTHU FROM BENHNHAN WHERE CHUNGMINHTHU='" + socmnd + "'";
        if (idbenhnhan != null && idbenhnhan != "")
            sqlSelect += " AND IDBENHNHAN<>" + idbenhnhan;
        DataTable dtCheck = DataAcess.Connect.GetTable(sqlSelect);
        if (dtCheck != null && dtCheck.Rows.Count > 0)
        {
            Response.Write("Số chứng minh thư này đã có người khác dùng rồi ! \n Vui lòng chọn số khác");
            return;
        }
    }
    private void setdefault()
    {
        string html = "";
        html += "<root>";
        DataTable dtDanToc = DataAcess.Connect.GetTable("SELECT TOP 1 * FROM DANTOC WHERE ID=1");
        if (dtDanToc != null && dtDanToc.Rows.Count > 0)
        {
            html += "<data id=\"dantoc\">" + dtDanToc.Rows[0]["ID"].ToString() + "</data>";
            html += "<data id=\"mkv_madantoc\">" + dtDanToc.Rows[0]["MADANTOC"].ToString() + "</data>";
            html += "<data id=\"mkv_tendantoc\">" + dtDanToc.Rows[0]["TENDANTOC"].ToString() + "</data>";
        }
        DataTable dtQuocTich = DataAcess.Connect.GetTable("SELECT TOP 1 * FROM QUOCTICH WHERE IDQUOCTICH=22");
        if (dtQuocTich != null && dtQuocTich.Rows.Count > 0)
        {
            html += "<data id=\"quoctich\">" + dtQuocTich.Rows[0]["IDQUOCTICH"].ToString() + "</data>";
            html += "<data id=\"mkv_maquoctich\">" + dtQuocTich.Rows[0]["MAQUOCTICH"].ToString() + "</data>";
            html += "<data id=\"mkv_tenquoctich\">" + dtQuocTich.Rows[0]["TENQUOCTICH"].ToString() + "</data>";
        }

        DateTime now = DateTime.Now;

        html += "<data id=\"ngaytiepnhan\">" + string.Format("{0:dd/MM/yyyy}", now) + "</data>";
        html += "<data id=\"gio\">" + string.Format("{0:HH}", now) + "</data>";
        html += "<data id=\"phut\">" + string.Format("{0:mm}", now) + "</data>";
        html += "<data id=\"giodk\">" + string.Format("{0:HH}", now) + "</data>";
        html += "<data id=\"phutdk\">" + string.Format("{0:mm}", now) + "</data>";
        html += "<data id=\"ngaydangky\">" + string.Format("{0:dd/MM/yyyy}", now) + "</data>";
        string SqlOption = @"
            select isInMaVachBN=isnull((SELECT ParaValue FROM KB_Parameter WHERE ParaName='isInMaVachBN' ),0)
            ,isInTheBN=isnull((SELECT ParaValue FROM KB_Parameter WHERE ParaName='isInTheBN' ),0)
            ,isInBaoThuPK=isnull((SELECT ParaValue FROM KB_Parameter WHERE ParaName='isInBaoThuPK' ),0)
            ,isKhamBH=isnull((SELECT ParaValue FROM KB_Parameter WHERE ParaName='isKhamBH' ),0)";
        DataTable dtOption = DataAcess.Connect.GetTable(SqlOption);
        html += "<data id=\"isInMaVachBN\">" + dtOption.Rows[0]["isInMaVachBN"] + "</data>";
        html += "<data id=\"isInTheBN\">" + dtOption.Rows[0]["isInTheBN"] + "</data>";
        html += "<data id=\"isInBaoThuPK\">"+ dtOption.Rows[0]["isInBaoThuPK"] + "</data>";
        html += "<data id=\"isKhamBH\">" + dtOption.Rows[0]["isKhamBH"] + "</data>";

        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }
    public void idquoctichsearch()
    {
        string sql1 = "select * from quoctich where tenquoctich like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sql1);
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
    public void idnghenghiepsearch()
    {
        string sql1 = "select * from nghenghiep where tennghenghiep like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sql1);
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
    public void iddantocsearch()
    {
        string sql1 = "select * from dantoc where tendantoc like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sql1);
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
    private void loadmadantoc()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and madantoc like N'" + Request.QueryString["q"] + "%'";
        }

        string sql = @"select top 10 * from dantoc where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                             + "<div style=\"width:35%;float:left;height:20px\" >" + row["madantoc"] + "</div>"
                         + "<div style=\"width:55%;float:left;height:20px\" >" + row["tendantoc"] + "</div>"
                                     + "</div>", row["madantoc"], row["tendantoc"], row["id"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loadtendantoc()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and tendantoc like N'" + Request.QueryString["q"] + "%'";
        }

        string sql = @"select top 10 * from dantoc where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:20px\" >" + row["madantoc"] + "</div>"
                         + "<div style=\"width:55%;float:left;height:20px\" >" + row["tendantoc"] + "</div>"
                                     + "</div>", row["madantoc"], row["tendantoc"], row["id"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loadmaquoctich()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and maquoctich like N'" + Request.QueryString["q"] + "%'";
        }

        string sql = @"select * from quoctich where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:20px\" >" + row["maquoctich"] + "</div>"
                         + "<div style=\"width:55%;float:left;height:20px\" >" + row["tenquoctich"] + "</div>"
                                     + "</div>", row["maquoctich"], row["tenquoctich"], row["idquoctich"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loadtenquoctich()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and tenquoctich like N'" + Request.QueryString["q"] + "%'";
        }

        string sql = @"select top 10 * from quoctich where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:20px\" >" + row["maquoctich"] + "</div>"
                         + "<div style=\"width:55%;float:left;height:20px\" >" + row["tenquoctich"] + "</div>"
                                     + "</div>", row["maquoctich"], row["tenquoctich"], row["idquoctich"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loadmanghenghiep()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and manghenghiep like N'" + Request.QueryString["q"] + "%'";
        }

        string sql = @"select top 10 * from nghenghiep where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:20px\" >" + row["manghenghiep"] + "</div>"
                         + "<div style=\"width:55%;float:left;height:20px\" >" + row["tennghenghiep"] + "</div>"
                                     + "</div>", row["manghenghiep"], row["tennghenghiep"], row["idnghenghiep"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loadtennghenghiep()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and tennghenghiep like N'" + Request.QueryString["q"] + "%'";
        }

        string sql = @"select top 10 * from nghenghiep where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:20px\" >" + row["manghenghiep"] + "</div>"
                         + "<div style=\"width:55%;float:left;height:20px\" >" + row["tennghenghiep"] + "</div>"
                                     + "</div>", row["manghenghiep"], row["tennghenghiep"], row["idnghenghiep"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loadmadangky()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and MADANGKY like N'%" + Request.QueryString["q"] + "%'";
        }

        string sql = @"select top 10 * from kb_noidangkykb where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:20%;float:left;height:20px; padding-left:10px;\" >" + row["MADANGKY"] + "</div>"
                                         + "<div style=\"width:60%;float:left;height:20px\" >" + row["TENNOIDANGKY"] + "</div>"
                                         + "<div style=\"width:20%;float:left;height:20px\" >" + (StaticData.IsCheck(row["DUNGTUYEN"].ToString()) ? "Đúng tuyến" : "Trái tuyến") + "</div>"
                                     + "</div>", row["MADANGKY"], row["TENNOIDANGKY"], row["IDNOIDANGKY"], (StaticData.IsCheck(row["DUNGTUYEN"].ToString()) ? "Đúng tuyến" : "Trái tuyến"), Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loadnoidangky()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and TENNOIDANGKY like N'%" + Request.QueryString["q"] + "%'";
        }

        string sql = @"select * from kb_noidangkykb where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:20%;float:left;height:20px; padding-left:10px;\" >" + row["MADANGKY"] + "</div>"
                                         + "<div style=\"width:60%;float:left;height:20px\" >" + row["TENNOIDANGKY"] + "</div>"
                                         + "<div style=\"width:20%;float:left;height:20px\" >" + (StaticData.IsCheck(row["DUNGTUYEN"].ToString()) ? "Đúng tuyến" : "Trái tuyến") + "</div>"
                                     + "</div>", row["MADANGKY"], row["TENNOIDANGKY"], row["IDNOIDANGKY"], (StaticData.IsCheck(row["DUNGTUYEN"].ToString()) ? "Đúng tuyến" : "Trái tuyến"), Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void chonthongtinbh()
    {
        Set_ThongTinBaoHiem(null, Request.QueryString["idbenhnhan_bh"]);

    }
    private void chonbhkhac()
    {
        string sql = @"SELECT A.*,B.MaBenhNhan 
                        ,NOIGT=NGT.TENNOIDANGKY
                        ,NOIDANGKYKB=NDK.TENNOIDANGKY
                        ,MADANGKYKB=NDK.MADANGKY
                        FROM BENHNHAN_BHYT A 
                        LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN 
                        LEFT JOIN KB_NOIDANGKYKB NDK ON A.IDNOIDANGKYBH=NDK.IDNOIDANGKY
                        LEFT JOIN KB_NOIDANGKYKB NGT ON A.IDNOIGIOITHIEU=NGT.IDNOIDANGKY  
                        WHERE 1=1";
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        if (idbenhnhan != null && idbenhnhan != "")
        {
            sql += " AND A.IDBENHNHAN=" + idbenhnhan;
        }
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã bệnh nhân") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số BHYT") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày bắt đầu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày hết hạn") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nơi giới thiệu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nơi ĐK.KCB") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã nơi ĐK.KCB") + "</th>";
        html += "</tr>";
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr style='cursor:pointer' onclick=\"javascript:chonthongtinbh(" + dt.Rows[i]["IDBENHNHAN_BH"] + ",'" + string.Format("{0:dd/MM/yyyy}", dt.Rows[i]["ngayhethan"]) + "');\" >";
                html += "<td>" + dt.Rows[i]["mabenhnhan"].ToString() + "</td>";
                html += "<td>" + dt.Rows[i]["sobhyt"].ToString() + "</td>";
                html += "<td>" + string.Format("{0:dd/MM/yyyy}", dt.Rows[i]["ngaybatdau"]) + "</td>";
                html += "<td>" + string.Format("{0:dd/MM/yyyy}", dt.Rows[i]["ngayhethan"]) + "</td>";
                html += "<td>" + dt.Rows[i]["NOIGT"] + "</td>";
                html += "<td>" + dt.Rows[i]["NOIDANGKYKB"] + "</td>";
                html += "<td>" + dt.Rows[i]["MADANGKYKB"] + " </td>";
                html += "</tr>";
            }
        }
        else
        {
            Response.Clear();
            Response.Write("");
            return;
        }
        html += "</table>";
        Response.Clear();
        Response.Write(html);
    }
    private void LuuNhapVien()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string ngaynhapvien = Request.QueryString["ngaynhapvien"];
        string stemp = "13/08/2012";
        string sNgay = ngaynhapvien.Substring(0, stemp.Length);
        string sgio = ngaynhapvien.Replace(sNgay, "").Trim();
        string sNgayLuu = StaticData.CheckDate(sNgay) + " " + sgio;

        string idkhoa = Request.QueryString["idkhoanhap"];
        if (idkhoa != null && idkhoa != "") idkhoa = idkhoa.Trim();
        string idbacsi = Request.QueryString["idbacsi"];
        if (idbacsi != null && idbacsi != "") idbacsi = idbacsi.Trim();
        string idchandoan = Request.QueryString["idchandoan"];
        if (idchandoan != null && idchandoan != "") idchandoan = idchandoan.Trim();
        string idkhoachuyen = Request.QueryString["idkhoachuyen"];
        if (idkhoachuyen != null && idkhoachuyen != "") idkhoachuyen = idkhoachuyen.Trim();
        string idphong = Request.QueryString["idphong"];
        if (idphong != null && idphong != "") idphong = idphong.Trim();
        string LoaiKhamID = Request.QueryString["LoaiKhamID"];
        if (LoaiKhamID != null && LoaiKhamID != "") LoaiKhamID = LoaiKhamID.Trim();
        string IDBENHNHAN_BH = Request.QueryString["IDBENHNHAN_BH"];
        if (IDBENHNHAN_BH != null && IDBENHNHAN_BH != "") IDBENHNHAN_BH = IDBENHNHAN_BH.Trim();
        string isNhapNew = Request.QueryString["isNhapNew"];
        string sqlCheckNhapVien = @"SELECT TOP 1 a.idkhambenh
                                                ,a.idchitietdangkykham
                                                ,a.iddangkykham
                                                ,ketluan
                                                ,IdKhoa
                                                ,IdBacSi
                                                ,IdKhoaChuyen
                                                ,IdPhong
                                    FROM KHAMBENH A
                                    WHERE A.IDBENHNHAN=" + idbenhnhan + @"
                                        AND year(ngaykham)=year('" + sNgayLuu + @"') 
                                        and month(ngaykham)=month('" + sNgayLuu + @"')
                                        and day(ngaykham)=day('" + sNgayLuu + "')";
        DataTable dtCheckNhapVien = DataAcess.Connect.GetTable(sqlCheckNhapVien);
        if (dtCheckNhapVien != null && dtCheckNhapVien.Rows.Count != 0)
        {

            string idkhoa_old = dtCheckNhapVien.Rows[0]["IDKHOA"].ToString().Trim();
            string idbacsi_old = dtCheckNhapVien.Rows[0]["idbacsi"].ToString().Trim();
            string ketluan_old = dtCheckNhapVien.Rows[0]["ketluan"].ToString().Trim();
            string idkhoachuyen_old = dtCheckNhapVien.Rows[0]["idkhoachuyen"].ToString().Trim();
            string idphong_old = dtCheckNhapVien.Rows[0]["idphong"].ToString().Trim();

            if (idkhoa == idkhoa_old && idbacsi == idbacsi_old && idchandoan == ketluan_old && idkhoachuyen == idkhoachuyen_old && idphong == idphong_old)
            {
                Response.Clear();
                Response.Write("0");
                return;
            }
            else
            {

                string sqlUpdate = "UPDATE KHAMBENH SET IDKHOA='" + idkhoa + "',phongkhamchuyenden='" + idkhoachuyen + "',KETLUAN='" + idchandoan + "',IDBACSI='" + idbacsi + "',IdKhoaChuyen='" + idkhoachuyen + "',IdPhong='" + idphong + "',PHONGID='" + idphong + "' WHERE IDKHAMBENH=" + dtCheckNhapVien.Rows[0]["IDKHAMBENH"];
                bool UPDATE = DataAcess.Connect.ExecSQL(sqlUpdate);
                if (!UPDATE)
                {
                    Response.Clear();
                    Response.Write("Cập nhật thông tin không thành công");
                    Response.StatusCode = 500;
                    return;
                }
                if (idkhoa != idkhoa_old)
                {
                    string IdBangGiaDichVu1 = "NULL";
                    if (idphong != null && idphong != "" && idphong != "0")
                    {
                        string sqlSelectDichVu1 = "SELECT TOP 1 A.IDBANGGIADICHVU FROM BANGGIADICHVU A LEFT JOIN KB_PHONG B ON A.IDBANGGIADICHVU=B.DICHVUKCB WHERE A.IDPHONGKHAMBENH='" + idkhoa + "' AND B.ID='" + idphong + "'";
                        DataTable dtDichVu1 = DataAcess.Connect.GetTable(sqlSelectDichVu1);
                        if (dtDichVu1 == null || dtDichVu1.Rows.Count == 0)
                        {
                            Response.Clear();
                            Response.Write("Không lưu được ( ErrorCode =3");
                            Response.StatusCode = 500;
                            return;
                        }
                        IdBangGiaDichVu1 = dtDichVu1.Rows[0][0].ToString();
                    }

                    string sqlUpdateCTDKK = "UPDATE CHITIETDANGKYKHAM  SET IDBANGGIADICHVU=" + IdBangGiaDichVu1 + " WHERE IDCHITIETDANGKYKHAM=" + dtCheckNhapVien.Rows[0]["IDCHITIETDANGKYKHAM"];
                    bool UPDATECTDKK = DataAcess.Connect.ExecSQL(sqlUpdateCTDKK);
                    if (!UPDATECTDKK)
                    {
                        Response.Clear();
                        Response.Write("Cập nhật thông tin không thành công");
                        Response.StatusCode = 500;
                        return;
                    }
                }
            }
            Response.Clear();
            Response.Write("1;" + "");
            return;

        }
        string IdBenhBHDongTien="null";
        #region Nhập viện Cũ
        if (!string.IsNullOrEmpty(Request.QueryString["sovaovien"]))
        {
            if (string.IsNullOrEmpty(isNhapNew) || isNhapNew.Equals("0"))
            {
                DataTable dtt = DataAcess.Connect.GetTable("select IdBenhBHDongTien from dangkykham where idbenhnhan ='" + idbenhnhan + "' and SOVAOVIEN1 is not null order by iddangkykham desc");
                if (dtt != null && dtt.Rows.Count > 0)
                    IdBenhBHDongTien = "'" + dtt.Rows[0]["IdBenhBHDongTien"].ToString() + "'";
            }
        }
        #endregion
        string sqlInserDangKyKham = "INSERT INTO DANGKYKHAM(idbenhnhan,ngaydangky,LoaiKhamID,IDBENHNHAN_BH,IdBenhBHDongTien) VALUES ('" + idbenhnhan + "','" + sNgayLuu + "','" + LoaiKhamID + "','" + IDBENHNHAN_BH + "',"+IdBenhBHDongTien+")";
        bool ok1 = DataAcess.Connect.ExecSQL(sqlInserDangKyKham);
        if (!ok1)
        {
            Response.Clear();
            Response.Write("Không lưu được ( ErrorCode =1");
            Response.StatusCode = 500;
            return;
        }
        string sqlSelectDKK = "SELECT TOP 1 IDDANGKYKHAM FROM DANGKYKHAM WHERE IDBENHNHAN='" + idbenhnhan + "' AND NGAYDANGKY='" + sNgayLuu + "' ORDER BY IDDANGKYKHAM DESC";
        DataTable dtDKK = DataAcess.Connect.GetTable(sqlSelectDKK);
        if (dtDKK == null || dtDKK.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("Không lưu được ( ErrorCode =2");
            Response.StatusCode = 500;
            return;
        }
        string IdBangGiaDichVu = "NULL";

        string IdDangKyKham = dtDKK.Rows[0][0].ToString();
        if (idphong != null && idphong != "")
        {
            string sqlSelectDichVu = "SELECT TOP 1 A.IDBANGGIADICHVU FROM BANGGIADICHVU A LEFT JOIN KB_PHONG B ON A.IDBANGGIADICHVU=B.DICHVUKCB WHERE A.IDPHONGKHAMBENH='" + idkhoa + "' AND B.ID='" + idphong + "'";
            DataTable dtDichVu = DataAcess.Connect.GetTable(sqlSelectDichVu);
            if (dtDichVu == null || dtDichVu.Rows.Count == 0)
            {
                Response.Clear();
                Response.Write("Không lưu được ( ErrorCode =3");
                Response.StatusCode = 500;
                return;
            }
            IdBangGiaDichVu = dtDichVu.Rows[0][0].ToString();
        }
        string sqlInsertChiTietDangKyKham = "INSERT INTO CHITIETDANGKYKHAM (iddangkykham,idbanggiadichvu) VALUES(" + IdDangKyKham + ",'" + (IdBangGiaDichVu == "NULL" ? "" : IdBangGiaDichVu) + "')";
        bool OK2 = DataAcess.Connect.ExecSQL(sqlInsertChiTietDangKyKham);
        if (!OK2)
        {
            Response.Clear();
            Response.Write("Không lưu được ( ErrorCode =4");
            Response.StatusCode = 500;
            return;
        }


        string sqlSelectChiTietDKK = "SELECT TOP 1 IDCHITIETDANGKYKHAM FROM CHITIETDANGKYKHAM WHERE IDDANGKYKHAM='" + IdDangKyKham + "'";
        DataTable dtChiTietDKK = DataAcess.Connect.GetTable(sqlSelectChiTietDKK);
        if (dtChiTietDKK == null || dtChiTietDKK.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("Không lưu được ( ErrorCode =5");
            Response.StatusCode = 500;
            return;
        }
        if (string.IsNullOrEmpty(idphong)) idphong = "NULL";
        if (string.IsNullOrEmpty(idchandoan)) idchandoan = "NULL";
        string IdChiTietDangKyKham = dtChiTietDKK.Rows[0][0].ToString();
        string SQL_INSERT_KHAMBENH = string.Format(@"INSERT INTO KHAMBENH(NGAYKHAM,IDBENHNHAN,IDDANGKYKHAM,IDBACSI,KETLUAN,
                                                             HUONGDIEUTRI,IDPHONGKHAMBENH,IDCHITIETDANGKYKHAM,DICHVUKCBID,IDCHANDOAN,
                                                       IDKHOA,PHONGKHAMCHUYENDEN,IDKHOACHUYEN,IDPHONG,PHONGID,ISKHONGKHAM,ISKHONGTINHCABS)
                                                       VALUES('{0}',{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})",
                                                            sNgayLuu, idbenhnhan, IdDangKyKham, (idbacsi == null || idbacsi == "" ? "NULL" : idbacsi), idchandoan, "8", idkhoa, IdChiTietDangKyKham,
                                                                                                    IdBangGiaDichVu, idchandoan, idkhoa, idkhoachuyen, idkhoachuyen, idphong, idphong, "0", "1");
        bool OK3 = DataAcess.Connect.ExecSQL(SQL_INSERT_KHAMBENH);
        if (OK3)
        {
            StaticData.TinhLaiTien_ByIdDangKyKham(IdDangKyKham, "1");
            string sovaovien_new = "";
            if (!IdBenhBHDongTien.Equals("null"))
                sovaovien_new = IdBenhBHDongTien;
            else
                StaticData_HS.GetSoVaoVien(null, IdChiTietDangKyKham, "1");
            Response.Clear();
            Response.Write("Bệnh nhân đã nhập viện;" + sovaovien_new);
            return;
        }
    }
    private void LoadChanDoanMaICD()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and maicd like N'" + Request.QueryString["q"] + "%'";
        }

        string sql = @"SELECT top 20 * FROM chandoanicd where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:15%;float:left;height:20px\" >" + row["maicd"] + "</div>"
                         + "<div style=\"width:85%;float:left;height:20px\" >" + row["mota"] + "</div>"
                                     + "</div>", row["maicd"], row["mota"], row["idicd"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void LoadChanDoanMoTaICD()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and mota like N'" + Request.QueryString["q"] + "%'";
        }

        string sql = @"SELECT top 20 * FROM chandoanicd where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:30px\">"
                                         + "<div style=\"width:15%;float:left;height:30px\" >" + row["maicd"] + "</div>"
                         + "<div style=\"width:85%;float:left;height:30px\" >" + row["mota"] + "</div>"
                                     + "</div>", row["maicd"], row["mota"], row["idicd"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idbacsisearch()
    {
        string TenBS = Request.QueryString["q"].ToString();
        string idkhoa = Request.QueryString["idkhoa"].ToString().Trim();
        string sqlBS = @"SELECT 
            A.IDBACSI AS IDBACSI
            ,A.TENBACSI AS TENBACSI
            FROM BACSI A
            WHERE tenbacsi like N'%" + TenBS + "%'";

        if (idkhoa != null && idkhoa != "")
        {
            sqlBS += "   and idphongkhambenh = '" + Request.QueryString["idkhoa"] + "'";
        }
        DataTable table = DataAcess.Connect.GetTable(sqlBS);
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
    private void nhapvienmoi()
    {

        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string sql =
            @"SELECT TOP 1 a.idkhambenh,a.idbenhnhan
                ,a.idchitietdangkykham
                ,a.iddangkykham
                ,ketluan,MOTA,MAICD
                ,IdKhoa,TENKHOA=D.TENPHONGKHAMBENH
                ,A.IdBacSi,TENBACSI,
                IDKHOACHUYEN,IDPHONG,
                TENKHOACHUYEN=E.TENPHONGKHAMBENH,
                TENPHONG='P.' + DBO.HS_TENPHONG(A.PHONGID),
                SOVAOVIEN=[dbo].[zHS_GetSoVaoVienFromKB](a.idkhambenh)
            FROM KHAMBENH A LEFT JOIN CHANDOANICD B ON A.KETLUAN=B.IDICD
            LEFT JOIN BACSI C ON A.IDBACSI=C.IDBACSI
	        LEFT JOIN PHONGKHAMBENH D ON A.IDKHOA=D.IDPHONGKHAMBENH
            LEFT JOIN PHONGKHAMBENH E ON A.IDKHOACHUYEN=E.IDPHONGKHAMBENH
            
            WHERE A.IDBENHNHAN=" + idbenhnhan + " ORDER BY A.NGAYKHAM DESC ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt == null || dt.Rows.Count == 0)
        {
            sql = @"select idkhambenh='',
                           idbenhnhan,
                           idbacsi='',
                           tenbacsi='',
                           idkhoa=(select top 1 idphongkhambenh from phongkhambenh where isnoitru=0),
                           tenphongkhambenh='',
                           ketluan='',
                           mota='',
                           maicd='',
                           IDPHONG='',
                           IDKHOACHUYEN='',
                           TENKHOA=(select top 1 tenphongkhambenh from phongkhambenh where isnoitru=0),
                           TENPHONG='',
                           TENKHOACHUYEN='',
                           phongid='',
                           sovaovien=''
                           from benhnhan where idbenhnhan=" + idbenhnhan;
            dt = DataAcess.Connect.GetTable(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                Response.Clear();
                Response.Write("Lỗi không có thông tin");
                Response.StatusCode = 500;
                return;
            }
        }

        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<div id='thongtinnhapvien' class='nhapvien' align='center'>");
        html.Append("<input id='idbenhnhan' mkv='true' type='hidden' value='" + (dt.Rows.Count == 0 ? idbenhnhan : dt.Rows[0]["idbenhnhan"].ToString()) + "' />");
        html.Append("<div class='div-Out' style='width:32%'>");
        html.Append("<h4>Ngày nhập viện</h4>");
        html.Append("<p style='width:57%;'><input type='text' id='ngaynhapvien' mkv='true' onfocus='chuyenphim(this);' value='" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "' /></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='border-right:1px solid #999; width:60%;'>");
        html.Append("<h4>Bác sĩ chỉ định</h4>");
        html.Append("<p style='width:75.8%;'><input id='idbacsi' mkv='true' type='hidden' value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["IDBACSI"]) + "' /><input type='text' id='mkv_idbacsi'  value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["TENBACSI"]) + "' onfocus=\"chuyenphim(this);idbacsisearch(this);\" class='down_select' value='' /> </p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:32%;'>");
        html.Append("<h4>Từ khoa</h4>");
        html.Append("<p style='width:57%;'><input id='idkhoanhap' mkv='true' type='hidden' value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["IDKHOA"]) + " ' /><input type='text' id='mkv_idkhoanhap' class='down_select' onfocus=\"chuyenphim(this);idkhoasearch(this);\" value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["TENKHOA"]) + "' /></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='border-right:1px solid #999; width:60%;'>");
        html.Append("<h4>Phòng</h4>");
        html.Append("<p style='width:76%;'><input id='idphong' mkv='true' type='hidden' value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["IDPHONG"]) + " ' /><input type='text' id='mkv_idphong' class='down_select' onfocus=\"chuyenphim(this);idphongkhambenhsearch(this);\" value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["TENPHONG"]) + "' /></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:32%'>");
        html.Append("<h4>Chuyển khoa</h4>");
        html.Append("<p style='width:57%;'><input id='idkhoachuyen' mkv='true' type='hidden' value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["IDKHOACHUYEN"].ToString().Trim()) + " ' /><input id='mkv_idkhoachuyen' type='text' class='down_select' onfocus=\"chuyenphim(this);idkhoa_noitru_search(this);\" value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["TENKHOACHUYEN"]) + "' /></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='border-right:1px solid #999; width:60%;'>");
        html.Append("<h4>Chẩn đoán ICD</h4>");
        html.Append("<p style='width:77%;'><input id='idchandoan' mkv='true' type='hidden' value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["KETLUAN"]) + "' /><input id='mkv_idchandoan' type='text' style='width:22%;' class='down_select' onfocus=\"LoadChanDoanMaICD(this,'xacdinh');\" value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["MAICD"]) + "' />&nbsp;<input id='mkv_mota'type='text' style='width:63%;' class='down_select' onfocus=\"LoadChanDoanMoTaICD(this,'xacdinh');\" value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["MOTA"]) + "' /></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='width:32%'>");
        html.Append("<h4>Số vào viện</h4>");
        html.Append("<p style='width:57%;'><input type='text' style='color: red;font-weight: bold;' disabled='disabled' id='sovaovien' mkv='true' value='" + (dt.Rows.Count == 0 ? "" : dt.Rows[0]["SOVAOVIEN"]) + "' /></p>");
        html.Append("</div>");
        html.Append("<div class='div-Out' style='border-right:1px solid #999; width:60%;'>");
        string strcheckNhapVienMoi = "";
        if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["SOVAOVIEN"].ToString()))
        {
            strcheckNhapVienMoi = "<span>Nhập viện mới ?</span> <input type='checkbox' id='isNhapNew' mkv='true' style='margin-right: 20px;' />";
        }
        html.Append("<p style='width:99%;'>" + strcheckNhapVienMoi + "<input  id='btnnhapvien' onclick='xacdinhnhapvien(this)'  type='button' value='Nhập viện' /> &nbsp;<input  id='btnHuy' onclick=\"$.mkv.dongtimkiem('default');\" type='button' value='Thoát' /></p>");
        html.Append("</div>");
        Response.Clear();
        Response.Write(html);
    }
    private void checkBN()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string tenBN = Request.QueryString["tenbenhnhan"];
        string swhere = "";
        if (tenBN != null && tenBN != "")
        {
            swhere += " and (tenbenhnhan like N'" + tenBN + "' or NameNotSign like N'" + StaticData.s_GetNameNotSign(tenBN) + "')";
        }

        string ngaysinh = Request.QueryString["ngaysinh"];
        if (ngaysinh != null && ngaysinh != "")
        {
            swhere += "  and ngaysinh='" + ngaysinh + "'";
        }
        if (idbenhnhan != null && idbenhnhan != "")
            swhere += " AND IDBENHNHAN<>" + idbenhnhan;

        string sqlCheck = @"SELECT TOP 5 STT=ROW_NUMBER() OVER (ORDER BY T.IDBENHNHAN) ,T.IDBENHNHAN,
                                     T.TENBENHNHAN,T.MABENHNHAN,T.DIACHI,T.NGAYSINH,T.NGAYTIEPNHAN
                                    ,A.TenLoai,TenLoaiBN = B.TenLoai
                            FROM BENHNHAN T
                                  LEFT JOIN KB_LoaiUutien  A on T.idloaiuutien=A.Id
                                  LEFT JOIN KB_LoaiBN  B on T.loai=B.Id
                            WHERE 1=1 " + swhere;
        sqlCheck += " order by ngaytiepnhan desc";
        DataTable table = DataAcess.Connect.GetTable(sqlCheck);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>Mã bệnh nhân</th>";
        html += "<th>Tên bệnh nhân</th>";
        html += "<th>Loại ưu tiên</th>";
        html += "<th>Địa chỉ</th>";
        html += "<th>Ngày sinh</th>";
        html += "<th>Loại khám</th>";
        html += "<th>Ngày tiếp nhận</th>";
        html += "</tr>";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr style='cursor:pointer' onclick=\"setControlFind('" + table.Rows[i]["idbenhnhan"].ToString() + "')\">";
                html += "<td>" + table.Rows[i]["mabenhnhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["tenbenhnhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["TenLoai"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["diachi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["ngaysinh"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["TenLoaiBN"].ToString() + "</td>";
                if (table.Rows[i]["ngaytiepnhan"].ToString() != "")
                {
                    html += "<td>" + DateTime.Parse(table.Rows[i]["ngaytiepnhan"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>";
                }
                else { html += "<td>" + table.Rows[i]["ngaytiepnhan"].ToString() + "</td>"; }
                html += "</tr>";
            }
            html += "</table>";
            Response.Clear(); Response.Write(html);
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("");
            return;
        }
    }
    private void TinhTuoiBenhNhan()
    {
        string NgaySinh = Request.QueryString["NgaySinh"];
        if (NgaySinh == "" || NgaySinh.Length < 4)
        {
            Response.Clear();
            Response.Write("");
            return;
        }
        int TuoiBN = 0;
        DateTime Now = DateTime.Now;
        if (NgaySinh.Length == 4)
        {
            TuoiBN = Now.Year - int.Parse(NgaySinh);
            if (TuoiBN == 0) TuoiBN = 1;
            Response.Clear();
            Response.Write(TuoiBN.ToString() + ";0");
            return;
        }
        if (NgaySinh.Length >= "19/07/2012".Length)
        {
            DateTime dNgaySinh = DateTime.Parse(StaticData.CheckDate(NgaySinh));
            TuoiBN = Now.Year - dNgaySinh.Year;
            if (TuoiBN == 0) TuoiBN = 1;
            Response.Clear();
            Response.Write(TuoiBN.ToString() + ";" + "0");
            return;
        }
        return;
    }
    private void TinhNamSinh_TheoTuoi()
    {
        string Tuoi = Request.QueryString["Tuoi"];
        if (Tuoi == null || Tuoi == "" || Tuoi == "0")
        {
            Response.Clear();
            Response.Write("-1");
            return;
        }
        DateTime dNgayHienTai = DateTime.Now;
        int n = dNgayHienTai.Year - int.Parse(Tuoi);
        if (n == 0) n = dNgayHienTai.Year;
        Response.Clear();
        Response.Write(n.ToString());
    }
    private void TinhNamSinh_TheoThang()
    {
        string Thang = Request.QueryString["Thang"];
        if (Thang == null || Thang == "" || Thang == "0")
        {
            Response.Clear();
            Response.Write("-1");
            return;
        }
        Response.Clear();
        Response.Write(DateTime.Now.Year.ToString());
    }
    private void idkhoasearch()
    {
        DataTable table = StaticData.dtKhoa();

        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i]["TenPhongKhamBenh"].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idkhoa_noitru_search()
    {
        DataTable table = StaticData.dtKhoa();
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i]["TenPhongKhamBenh"].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void getTileBHYT()
    {
        string DungTuyen = Request.QueryString["istraituyen"];
        string iscapcuu = Request.QueryString["iscapcuu"];
        string sobh1 = Request.QueryString["bh1"];
        string sobh2 = Request.QueryString["bh2"];
        if (sobh1 != null && sobh2 != null && DungTuyen != null)
        {
            string sql = "select quyenloichung from KB_DOITUONGBH where doituong='" + sobh2 + "'";
            DataTable dtTile = DataAcess.Connect.GetTable(sql);
            if (dtTile == null || dtTile.Rows.Count == 0)
            {
                Response.Write("0");
                return;
            }
            string Quyenloichung = dtTile.Rows[0]["QuyenLoiChung"].ToString();
            string TLTT = StaticData.GetParameter("TLTT");
            string value = Quyenloichung;

            if (DungTuyen.ToLower() == "true" || DungTuyen == "1") value = TLTT;
            Response.Write(value);


        }
    }
    public void tinhidSearch()
    {
        string sql1 = @"select tinhid,case when matinh IS NULL  OR matinh='' then tinhname else
                isnull(matinh,'')+'_'+tinhname end as tinhname from tinh where 1=1 ";
        if (Request.QueryString["tinhid"] != null && Request.QueryString["tinhid"] != "")
        {
            sql1 += " and tinhid='" + Request.QueryString["tinhid"] + "'";
        }
        string matinh = Request.QueryString["q"].Split('_')[0];
        if (matinh != null && matinh != "")
        {
            sql1 += " and matinh like N'" + matinh + "%'";
        }
        sql1 += "order by matinh+'_'+tinhname ";
        DataTable table = DataAcess.Connect.GetTable(sql1);
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
    public void quanhuyenidSearch()
    {
        string sql1 = "select * from quanhuyen where tinhid='" + Request.QueryString["tinhid"] + "'";
        DataTable table = DataAcess.Connect.GetTable(sql1);
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
    public void phuongxaidSearch()
    {
        string sql1 = "select * from phuongxa";
        if (Request.QueryString["quanhuyenid"] != null && Request.QueryString["quanhuyenid"] != "")
        {
            sql1 += " where quanhuyenid='" + Request.QueryString["quanhuyenid"] + "'";
        }
        DataTable table = DataAcess.Connect.GetTable(sql1);
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
    private void ktramabh()
    {
        string SQL_SELECT = string.Format(@"SELECT DUNGTUYEN FROM KB_NOIDANGKYKB WHERE IDNOIDANGKY={0}", Request.QueryString["IDNOIDANGKY"]);
        DataTable table = DataAcess.Connect.GetTable(SQL_SELECT);
        string html = "";
        if (table.Rows.Count > 0)
        {
            html += table.Rows[0][0].ToString();
        }
        Response.Clear();
        Response.Write(html);
    }
    private void idloaiuutienSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select * from kb_loaiuutien");
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
    private void loadSTT()
    {
        string ngay = "";
        if (Request.QueryString["ngaydk"].ToString() == "") ngay = DateTime.Now.ToString("dd/MM/yyyy");
        else
            ngay = Request.QueryString["ngaydk"].ToString();
        string NgayDKK = StaticData.CheckDate(ngay);
        DateTime dNgayDKK = DateTime.Parse(NgayDKK);
        string PhongId = Request.QueryString["idphongkhambenh"];
        string stt = StaticData_HS.GetSoThuTuDangKyKhamMoi(PhongId, NgayDKK, false);
        string slbncho = "";
        string slbnkham = "";
        Response.Clear();
        Response.Write(stt + "@" + slbncho + "@" + slbnkham);
    }
    private void idphongkhambenhSearch()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        DataTable table = null;
        if (idkhoa != null && idkhoa != "")
        {
            table = StaticData.dtPhong_NgoaiTru_ByKhoa(idkhoa);

        }
        else
        {
            table = StaticData.dtPhong_NgoaiTru_ByKhoa("1");
        }

        string html = "";

        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string s = table.Rows[i]["TenPhongFull"].ToString();
                    html += s + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idChuyenKhoaSearch()
    {
        string sql = "";
        if (Request.QueryString["ngaydk"].ToString() == "") sql = DateTime.Now.ToString("dd/MM/yyyy");
        else
            sql = Request.QueryString["ngaydk"].ToString();
        string NgayDKK = StaticData.CheckDate(sql);
        DateTime dNgayDKK = DateTime.Parse(NgayDKK);
        string PhongId = Request.QueryString["phongid"].ToString();
        string sqlChuyenKhoa = "select IdBangGiaDichVu,TenDichVu from BangGiaDichVu A left join phongkhambenh B On A.IdPHongKhamBenh=B.IdPhongKhamBenh where loaiphong=0 ";
        DataTable dtAllChuyenKhoa = DataAcess.Connect.GetTable(sqlChuyenKhoa);

        if (PhongId != null && PhongId != "" && PhongId != "0")
        {
            sqlChuyenKhoa = @"select IdBangGiaDichVu
		                            ,TenDichVu
                             from BangGiaDichVu A
                                  left join phongkhambenh B On A.IdPHongKhamBenh=B.IdPhongKhamBenh
                             where loaiphong=0 
			                        and idbanggiadichvu in (    select IdChuyenKhoa 
									                            from KB_PhanCaBacSi 
									                            where phongid=" + PhongId + @" 
											                            and year(ngaykham)=" + dNgayDKK.Year.ToString() + @"
											                            and month(ngaykham)=" + dNgayDKK.Month.ToString() + @"
											                            and day(ngaykham)=" + dNgayDKK.Day.ToString() + @"
								                               )";
        }
        DataTable dtbChuyenKhoa = DataAcess.Connect.GetTable(sqlChuyenKhoa);
        if (dtbChuyenKhoa == null || dtbChuyenKhoa.Rows.Count == 0) dtbChuyenKhoa = dtAllChuyenKhoa;
        string html = "";
        if (dtbChuyenKhoa != null)
        {
            if (dtbChuyenKhoa.Rows.Count > 0)
            {
                for (int i = 0; i < dtbChuyenKhoa.Rows.Count; i++)
                {

                    html += dtbChuyenKhoa.Rows[i][1].ToString() + "|" + dtbChuyenKhoa.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loaiSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select * from kb_loaibn" + (StaticData.IsCheck(StaticData.GetParameter("isKhamBH")) ? "" : " where id not in (1)"));
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
    //private void idloaitainan()
    //{
    //    DataTable table = new DataTable();
    //    table.Columns.Add("idloaitainan");
    //    table.Columns.Add("tentainan");
    //    table.Rows.Add(4);
    //    table.Rows[0][0]= "1";
    //    table.Rows[1][0].ToString() = "2";
    //    table.Rows[2][0].ToString() = "3";
    //    table.Rows[3][0].ToString() = "4";
    //    table.Rows[0][1].ToString() = "Tai nạn giao thông";
    //    table.Rows[1][1].ToString() = "tai nạn sinh hoạt";
    //    table.Rows[2][1].ToString() = "Bị đánh, bị chém";
    //    table.Rows[3][1].ToString() = "Khác";
    //    string html = "";
    //    if (table != null)
    //    {
    //        if (table.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < table.Rows.Count; i++)
    //            {

    //                html += table.Rows[i][1].ToString() + Environment.NewLine;

    //            }
    //        }
    //    }
    //    Response.Clear(); Response.Write(html);
    //}
    private void Xoabenhnhan()
    {
        try
        {
            DataProcess process = s_benhnhan();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idbenhnhan"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private System.Text.StringBuilder dtHistory(string IdBenhNhan)
    {
        string sqlDangKyKham = @"SELECT DISTINCT  DK.IDDANGKYKHAM,DK.NGAYDANGKY
            ,dk.MAPHIEU
            ,KHOAPHONG=[dbo].[TenKhoaPhongByIDDANGKYKHAM](DK.IDDANGKYKHAM)
            ,strNGAYDANGKY=CONVERT(VARCHAR(10),DK.NGAYDANGKY,103)+' '+CONVERT(VARCHAR(8),DK.NGAYDANGKY,108)
            ,LOAIKHAM=LBN.TENLOAI
            ,strNGAYXUATVIEN=''
        FROM DANGKYKHAM DK
            INNER JOIN KB_LOAIBN LBN ON LBN.ID= DK.LOAIKHAMID
        WHERE ISNULL( DK.dahuy ,0)=0 AND DK.IDBENHNHAN='" + IdBenhNhan + "' order by dk.ngaydangky";
        DataTable dtDKK = DataAcess.Connect.GetTable(sqlDangKyKham);
        string sqlKhamBenh = @"select idkhambenh,kb.iddangkykham
            ,khoa=case when p.idphongkhambenh<>1 then P.tenphongkhambenh else DBO.HS_TenPhong(kb.PhongID) end
            ,ngaykham=CONVERT(VARCHAR(10),kb.ngaykham,103)+' '+CONVERT(VARCHAR(8),kb.ngaykham,108)
            ,HuongDieuTri=( case when p2.tenphongkhambenh is not null  
				then N'Chuyển '
						+ ( CASE WHEN KB.HUONGDIEUTRI=1 THEN N'KTP :' ELSE ': ' END )
						+ ( CASE WHEN p2.idphongkhambenh = p.idphongkhambenh THEN ISNULL(' -'+ DBO.HS_TENPHONG(KB.IDCHUYENPK),'') ELSE P2.TENPHONGKHAMBENH END)  
				else hdt.tenhuongdieutri end)
			,bs.TenBacSi,TenBenh=kb.MoTaCD_edit
        from khambenh kb 
            left join phongkhambenh p on p.idphongkhambenh =kb.idphongkhambenh
            left join bacsi bs on bs.idbacsi =kb.idbacsi
            left join kb_huongdieutri hdt on hdt.HuongDieuTriId =kb.huongdieutri
			left join phongkhambenh p2 on p2.idphongkhambenh =isnull(kb.idkhoachuyen,phongkhamchuyenden)
        where kb.idbenhnhan ='" + IdBenhNhan + "' ORDER BY IDDANGKYKHAM,NGAYKHAM";
        DataTable dtKhamBenh = DataAcess.Connect.GetTable(sqlKhamBenh);
        DataView dv = new DataView(dtKhamBenh);

        DataProcess pro = new DataProcess("benhnhan");
        pro.Page = Request.QueryString["page"];
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id='TableDKKFather'>");
        html.Append("<tr>");
        html.Append("<th style='padding: 0px 0px 0px 10px;'>Lần ĐK</th>");
        html.Append("<th>Ngày đăng ký</th>");
        html.Append("<th>Khoa/Phòng</th>");
        html.Append("<th>Số phiếu</th>");
        html.Append("<th>Loại khám</th>");
        //html.Append("<th>Ngày xuất viện</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        if (dtDKK != null && dtDKK.Rows.Count > 0)//&& dtKhamBenh != null && dtKhamBenh.Rows.Count > 0)
        {
            for (int i = dtDKK.Rows.Count - 1; i >= 0; i--)
            {
                string IdDangKyKham = dtDKK.Rows[i]["IdDangKyKham"].ToString();
                bool isShow = false;
                if (i == dtDKK.Rows.Count - 1)
                    isShow = true;
                dv.RowFilter = "IDDANGKYKHAM=" + IdDangKyKham;
                html.Append("<tr>");
                html.Append("<td  style='padding: 0px 0px 0px 10px;text-align: left;'>" + (i < 9 ? "0" : "") + (i + 1) + (dv.Count > 0 ? "<a onclick=\"displayChildTable(this,'childTable" + i + "');\" style='font-size: 17px;font-weight: bold;color: Blue;padding-left:15px;'>" + (isShow ? "-" : "+") + "</a>" : "") + "</td>");
                html.Append("<td style='text-align: left;'>" + dtDKK.Rows[i]["strNGAYDANGKY"].ToString() + "</td>");
                html.Append("<td style='text-align: left;'>" + dtDKK.Rows[i]["KHOAPHONG"].ToString() + "</td>");
                html.Append("<td style='text-align: left;'>" + dtDKK.Rows[i]["MAPHIEU"].ToString() + "</td>");
                html.Append("<td style='text-align: left;'>" + dtDKK.Rows[i]["LOAIKHAM"].ToString() + "</td>");
                //html.Append("<td>" + dtDKK.Rows[i]["strNGAYXUATVIEN"].ToString() + "</td>");
                html.Append("<td><a onclick=\"setDangkykham('" + dtDKK.Rows[i]["iddangkykham"].ToString() + "','" + DateTime.Parse(dtDKK.Rows[i]["ngaydangky"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "')\">Chi tiết</a></td>");
                html.Append("</tr>");

                if (dv != null && dv.Count > 0)
                {
                    html.Append("<tr id='childTable" + i + "' " + (isShow ? "" : "style='display:none;'") + " >");
                    html.Append("<td></td>");
                    html.Append("<td colspan='5'>");
                    html.Append("<table class='jtable' >");
                    //html.Append("<tr>");
                    //html.Append("<th style='background: #A08FB8;'>Khoa</th>");
                    //html.Append("<th style='background: #A08FB8;'>Ngày</th>");
                    //html.Append("<th style='background: #A08FB8;'>Điều trị</th>");
                    //html.Append("<th style='background: #A08FB8;'>Bác sĩ</th>");
                    //html.Append("<th style='background: #A08FB8;'>Chẩn đoán</th>");
                    //html.Append("</tr>");
                    for (int j = 0; j < dv.Count; j++)
                    {
                        html.Append("<tr " + (j == 0 ? "style='border-top: 2px solid blue;'" : "") + ">");
                        html.Append("<td style='text-align: left;'>" + dv[j]["khoa"].ToString() + "</td>");
                        html.Append("<td style='text-align: left;'>" + dv[j]["NgayKham"].ToString() + "</td>");
                        html.Append("<td style='text-align: left;'>" + dv[j]["HuongDieuTri"].ToString() + "</td>");
                        html.Append("<td style='text-align: left;'>" + dv[j]["TenBacSi"].ToString() + "</td>");
                        html.Append("<td style='text-align: left;'>" + dv[j]["TenBenh"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                    html.Append("</table>");
                    html.Append("</td>");
                    html.Append("</tr>");
                }
            }
        }
        html.Append("</table>");
        html.Append(pro.Paging("Dangkykham"));
        html.Append("<input type='hidden' id='da_dangky' value='" + (dtDKK.Rows.Count > 0 ? "1" : "0") + "' />");
        return html;
    }
    private void loadDSDangkykham()
    {
        string IdBenhNhan = Request.QueryString["idbenhnhan"];
        string MaBenhNhan = Request.QueryString["mabenhnhan"];
        if (StaticData.GetParameter("HistoryStyle") == "2")
        {
            Response.Clear();
            Response.Write(dtHistory(IdBenhNhan));
            return;
        }
        DataProcess pro = new DataProcess("benhnhan");
        pro.Page = Request.QueryString["page"];

        string sqlSelect = @"select   STT=ROW_NUMBER() OVER(ORDER BY A.IDCHITIETDANGKYKHAM DESC)
                                ,MaPhieu=( CASE WHEN ISNULL(A.ISDATHU,0)=0 THEN NULL ELSE  ( CASE WHEN J.HUONGDIEUTRI=1 THEN '' ELSE  B.MaPhieu END) END)
                                ,ngaydangky=( CASE WHEN J.HUONGDIEUTRI=1 THEN J.TGXuatVien ELSE  ( CASE WHEN D.HUONGDIEUTRI=17 THEN ISNULL(D.TGXUATVIEN,D.NGAYKHAM) ELSE  ( CASE WHEN D.HUONGDIEUTRI=12 THEN D.NGAYKHAM ELSE  B.NGAYDANGKY END ) END) END)
                                ,B.iddangkykham
                                ,PhongSo=( CASE WHEN XK.IDKHAMBENHXK IS NOT NULL THEN KHOA.TENPHONGKHAMBENH   ELSE  ISNULL( (case when A.IdbangGiaDichvu=628 then N'Sổ khám bệnh' else ( CASE WHEN ISNULL(A.PHONGID,0)=0 THEN TENDICHVU ELSE   DBO.HS_TENPHONG(( CASE WHEN D.PHONGID<>A.PHONGID THEN D.PHONGID ELSE  A.PHONGID END )) END) end ),KHOA.TENPHONGKHAMBENH) END)
                                ,C.tendichvu as ChuyenKhoa
                                ,E.tenbacsi AS bacsi 
                                ,TenHuongDieuTri=(CASE WHEN D.IdkhoaChuyen=15 THEN N'Chuyển cấp cứu' else   H.TenHuongDieuTri END ) 
                                ,KhoaChuyenDen= ( CASE WHEN ISNULL(D.IdBenhVienChuyen,0)<>0 THEN TenBenhVien ELSE   (Case When ISNULL(I.IsNoiTru,0)=1  THEN ( CASE WHEN ISNULL(D.IdChuyenPK,0)=0 THEN I.TenPhongKhamBenh ELSE DBO.HS_TENPHONG(D.IdChuyenPK) +' - ' + I.TenPhongKhamBenh END  )ELSE DBO.HS_TENPHONG(D.IdChuyenPK) END) END)
                                ,NgayDK2=( CASE WHEN J.HUONGDIEUTRI=1 THEN convert(nvarchar(20), J.TGXuatVien,111) ELSE convert(nvarchar(20), B.ngaydangky,111) END)
                                ,LBN.TENLOAI
                            from  chitietdangkykham A
                            LEFT JOIN dangkykham B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                            LEFT JOIN BANGGIADICHVU C ON C.IDBANGGIADICHVU=A.IDBANGGIADICHVU
                            LEFT JOIN KHAMBENH D 
                                            ON 
                                           --( SELECT TOP 1 IDKHAMBENH FROM KHAMBENH WHERE IDCHITIETDANGKYKHAM= A.IDCHITIETDANGKYKHAM ORDER BY IDKHAMBENH )=D.IDKHAMBENH 
                                           A.IDCHITIETDANGKYKHAM= D.IDCHITIETDANGKYKHAM 
                            LEFT JOIN BACSI E ON ( CASE WHEN ISNULL(D.IDBACSI2,0)<>0 THEN D.IDBACSI2 ELSE  D.IDBACSI END)   =E.IDBACSI
                            LEFT JOIN BENHNHAN F ON B.IDBENHNHAN=F.IDBENHNHAN
                            LEFT JOIN KB_HUONGDIEUTRI H ON D.HUONGDIEUTRI=H.HUONGDIEUTRIID
                            LEFT JOIN PHONGKHAMBENH I ON D.IdkhoaChuyen=I.IDPHONGKHAMBENH
                            LEFT JOIN KHAMBENH J ON D.IDKHAMBENHGOC=J.IDKHAMBENH
                            LEFT JOIN BENHVIEN K ON D.IdBenhVienChuyen=K.idBenhVien
                            LEFT JOIN KB_LOAIBN LBN ON B.LoaiKhamID=LBN.ID
                            LEFT JOIN PHONGKHAMBENH KHOA ON D.IDPHONGKHAMBENH=KHOA.IDPHONGKHAMBENH
                            LEFT JOIN BenhNhanXuatKhoa  AS XK ON D.IDKHAMBENH=XK.IDKHAMBENHXK
                            where  ISNULL(A.dahuy,0)=0 AND ISNULL(A.ISKHONGKHAM,0)=0";

        if (IdBenhNhan != null && IdBenhNhan != "")
            sqlSelect += " AND  B.IDBENHNHAN='" + IdBenhNhan + "'\r\n";
        if (MaBenhNhan != null && MaBenhNhan != "")
            sqlSelect += " AND  F.MaBenhNhan='" + MaBenhNhan + "'\r\n";
        sqlSelect += " ORDER BY NGAYDANGKY DESC";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table != null)
        {
            table.DefaultView.Sort = "NgayDK2 desc, ngaydangky asc ";
            table = table.DefaultView.ToTable();
        }
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable'>");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>Số phiếu</th>");
        html.Append("<th>Ngày đăng ký</th>");
        html.Append("<th>Phòng khám</th>");
        html.Append("<th>Bác sỹ</th>");
        html.Append("<th>Hướng điều trị</th>");
        html.Append("<th>Chuyển đến</th>");
        html.Append("<th>Loại khám</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["maphieu"].ToString() + "</td>");
                if (table.Rows[i]["ngaydangky"].ToString() != "")
                {
                    html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaydangky"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>");
                }
                else { html.Append("<td>" + table.Rows[i]["ngaydangky"].ToString() + "</td>"); }
                html.Append("<td style='text-align:left; padding-left:10px;'>" + table.Rows[i]["phongso"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["bacsi"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["TenHuongDieuTri"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["KhoaChuyenDen"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["tenloai"].ToString() + "</td>");
                html.Append("<td><a onclick=\"setDangkykham('" + table.Rows[i]["iddangkykham"].ToString() + "','" + DateTime.Parse(table.Rows[i]["ngaydangky"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + "')\">Chi tiết</a></td>");
                html.Append("</tr>");
            }
        }
        html.Append("</table>");
        html.Append(pro.Paging("Dangkykham"));
        html.Append("<input type='hidden' id='da_dangky' value='" + (table.Rows.Count > 0 ? "1" : "0") + "' />");
        Response.Clear();
        Response.Write(html);
    }
    private void setTimKiem()
    {
        string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
        string sqlSelect = @"SELECT top 1 C.*
                    ,IDPHONG_INFOR=(SELECT TOP 1 CONVERT(NVARCHAR(20), A.PHONGID) + '-'+  CONVERT(NVARCHAR(20),B.LoaiKhamID)
                                        FROM CHITIETDANGKYKHAM A 
                                            LEFT JOIN DANGKYKHAM B  ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                            LEFT JOIN BENHNHAN C
                                                  ON B.IDBENHNHAN=C.IDBENHNHAN
                                                  WHERE isnull(a.dahuy,0)=0 and  C.IDBENHNHAN= '" + idkhoachinh + "'" +
                                                  @" ORDER BY B.NGAYDANGKY DESC
                                      )
                        ,thoigian=convert(char(8),c.ngaytiepnhan,114)
                        ,mkv_maquoctich=QT.MAQUOCTICH
                        ,mkv_tenquoctich=QT.TENQUOCTICH
                        ,mkv_madantoc=DT.MADANTOC
                        ,mkv_tendantoc=DT.TENDANTOC
                        ,mkv_manghenghiep=NN.MANGHENGHIEP
                        ,mkv_tennghenghiep=NN.TENNGHENGHIEP
                        ,mkv_tinhid=tinh.matinh + '_' + tinh.tinhname
                        ,mkv_quanhuyenid=qh.quanhuyenname
                        ,mkv_phuongxaid=px.tenphuongxa
                        from BENHNHAN C 
                        LEFT JOIN QUOCTICH QT ON C.QUOCTICH=QT.IDQUOCTICH
                        LEFT JOIN DANTOC DT ON C.DANTOC=DT.ID
                        LEFT JOIN NGHENGHIEP NN ON C.NGHENGHIEP=NN.IDNGHENGHIEP
                        LEFT JOIN tinh ON c.tinhid=tinh.tinhID
                        LEFT JOIN quanhuyen qh ON C.quanhuyenid=qh.quanhuyenid
                        LEFT JOIN phuongxa px ON C.phuongxaid=px.phuongxaid
                        WHERE 
                        C.idbenhnhan = '" + idkhoachinh + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<root>";

        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string[] thoigian = table.Rows[0]["thoigian"].ToString().Split(':');
                html += "<data id=\"gio\">" + thoigian[0].ToString() + "</data>";
                html += "<data id=\"phut\">" + thoigian[1].ToString() + "</data>";
                html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
                DataTable loai = DataAcess.Connect.GetTable("SELECT * FROM  KB_LoaiBN WHERE  Id='" + table.Rows[0]["loai"] + "'");
                html += "<data id=\"mkv_loai\">" + ((loai.Rows.Count > 0) ? loai.Rows[0][1] : "") + "</data>";
                html += "<data id=\"ngaydangky\">" + string.Format("{0:dd/MM/yyyy}", DateTime.Now) + "</data>";

                string IDPHONG_INFOR = table.Rows[0]["IDPHONG_INFOR"].ToString();
                if (IDPHONG_INFOR != null && IDPHONG_INFOR != "")
                {
                    string idphongkhambenh = IDPHONG_INFOR.Split('-')[0];
                    string LoaiKhamID = IDPHONG_INFOR.Split('-')[1];
                    html += "<data id=\"idphongkhambenh\">" + idphongkhambenh + "</data>";
                    html += "<data id=\"loai\">" + LoaiKhamID + "</data>";
                }

                html += Environment.NewLine;
                for (int y = 0; y < table.Columns.Count; y++)
                {
                    try
                    {
                        if (table.Columns[y].DataType == DateTime.Now.GetType())
                            html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                        else
                        {
                            if (table.Columns[y].ColumnName.ToLower() != "loai")
                                html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                            else
                            {
                                if (IDPHONG_INFOR == "")
                                    html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                            }
                        }
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
        Response.Write(html.Replace("&", "&amp"));
    }
    private void TimKiem()
    {
        DataProcess process = s_benhnhan();
        string swhere = "";
        string mabenhnhan = Request.QueryString["mabenhnhan"];
        if (mabenhnhan != null && mabenhnhan != "")
        {
            swhere += " AND T.mabenhnhan='" + mabenhnhan + "'";
        }
        string tenbenhnhan = Request.QueryString["tenbenhnhan"];
        if (tenbenhnhan != null && tenbenhnhan != "")
        {
            swhere += " and (T.tenbenhnhan like N'%" + tenbenhnhan + "%' or T.NAMENOTSIGN like N'%" + StaticData.s_GetNameNotSign(tenbenhnhan) + "%')";
        }
        string sodt = Request.QueryString["dienthoai"];
        if (sodt != null && sodt != "")
        {
            swhere += " AND t.dienthoai='" + sodt + "'";
        }
        string sobhyt = Request.QueryString["sobh1"] + Request.QueryString["sobh2"] + Request.QueryString["sobh3"] + Request.QueryString["sobh4"] + Request.QueryString["sobh5"] + Request.QueryString["sobh6"];
        if (sobhyt != null && sobhyt != "")
        {
            swhere += " AND t.sobhyt='" + sobhyt + "'";
        }
        process.Page = Request.QueryString["page"];
        string sqlSelect = @"select top 20 STT=ROW_NUMBER() OVER (ORDER BY T.IDBENHNHAN) , T.*" + "\r\n"
                  + " ,A.TenLoai " + "\r\n"
                  + " ,TenLoaiBN = B.TenLoai" + "\r\n"
                    + "           from benhnhan T" + "\r\n"
                    + "left join KB_LoaiUutien  A on T.idloaiuutien=A.Id" + "\r\n"
                    + "left join KB_LoaiBN  B on T.loai=B.Id" + "\r\n"
                    + "where 1=1 " + swhere;
        sqlSelect += " order by ngaytiepnhan desc";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>Mã bệnh nhân</th>";
        html += "<th>Tên bệnh nhân</th>";
        html += "<th>Loại ưu tiên</th>";
        html += "<th>Địa chỉ</th>";
        html += "<th>Ngày sinh</th>";
        html += "<th>Loại khám</th>";
        html += "<th>Ngày tiếp nhận</th>";
        html += "</tr>";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr style='cursor:pointer' onclick=\"setControlFind('" + table.Rows[i]["idbenhnhan"].ToString() + "')\">";
                html += "<td>" + table.Rows[i]["mabenhnhan"].ToString() + "</td>";
                html += "<td style='text-align:left;'>" + table.Rows[i]["tenbenhnhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["TenLoai"].ToString() + "</td>";
                html += "<td style='text-align:left;'>" + table.Rows[i]["diachi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["ngaysinh"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["TenLoaiBN"].ToString() + "</td>";
                if (table.Rows[i]["ngaytiepnhan"].ToString() != "")
                {
                    html += "<td>" + DateTime.Parse(table.Rows[i]["ngaytiepnhan"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>";
                }
                else { html += "<td>" + table.Rows[i]["ngaytiepnhan"].ToString() + "</td>"; }
                html += "</tr>";
            }
            html += "</table>";
            html += process.Paging();
            Response.Clear(); Response.Write(html);
            return;
        }
        else
        {
            Response.StatusCode = 500;
        }

    }
    private void Savebenhnhan()
    {
        try
        {
            DataProcess process = s_benhnhan();
            string ngayTN = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            string benhnhan_bhyt = "";
            string Result = "";
            string da_dang_ky = "";
            if (process.getData("mabenhnhan") == null || process.getData("mabenhnhan") == "")
            {
                string SLBN = "0";
                string NewMaBN = NewMaBenhNhan(StaticData.CheckDate(ngayTN), ref SLBN);
                process.data("mabenhnhan", NewMaBN);
                process.data("SLBN", SLBN);
            }
            if (process.getData("idbenhnhan") != null && process.getData("idbenhnhan") != "")
            {
                string sql_Before_Change = @"SELECT TOP 1 MABENHNHAN,TENBENHNHAN,NGAYSINH,GIOITINH FROM BENHNHAN WHERE IDBENHNHAN='" + process.getData("idbenhnhan") + "'";
                DataTable dt_Before_Change = DataAcess.Connect.GetTable(sql_Before_Change);
                string sDescription = "";

                if (dt_Before_Change != null && dt_Before_Change.Rows[0]["MABENHNHAN"].ToString().ToLower() != Request.QueryString["MABENHNHAN"].ToLower())
                {
                    sDescription += @"MÃ BN1=" + dt_Before_Change.Rows[0]["MABENHNHAN"].ToString() + ",MÃ BN2=" + Request.QueryString["MABENHNHAN"] + ",";
                }
                if (dt_Before_Change != null && dt_Before_Change.Rows[0]["TENBENHNHAN"].ToString().ToLower() != Request.QueryString["TENBENHNHAN"].ToLower())
                {
                    sDescription += @"TÊN BN1=" + dt_Before_Change.Rows[0]["TENBENHNHAN"].ToString() + ",TÊN BN2=" + Request.QueryString["TENBENHNHAN"] + ",";
                }
                if (dt_Before_Change != null && dt_Before_Change.Rows[0]["NGAYSINH"].ToString().ToLower() != Request.QueryString["NGAYSINH"].ToLower())
                {
                    sDescription += @"NGÀY SINH BN1=" + dt_Before_Change.Rows[0]["NGAYSINH"].ToString() + ",NGÀY SINH BN2=" + Request.QueryString["NGAYSINH"] + ",";
                }
                if (dt_Before_Change != null && dt_Before_Change.Rows[0]["GIOITINH"].ToString().ToLower() != Request.QueryString["GIOITINH"].ToLower())
                {
                    sDescription += @"GIỚI TÍNH BN1=" + (dt_Before_Change.Rows[0]["GIOITINH"].ToString() == "1" ? "Nữ" : "Nam") + ",GIỚI TÍNH BN2=" + (Request.QueryString["GIOITINH"].ToString() == "1" ? "Nữ" : "Nam") + ",";
                }
                if (sDescription != "" && sDescription != null)
                {
                    string UserID = SysParameter.UserLogin.UserID(this);
                    if (UserID == null || UserID == "") UserID = "NULL";
                    string sql_After_Change = @"INSERT INTO ZHISTORYCHANGE(TableName,SaveDate,Description,TypeEdit,IdKhoaChinh,IdNguoiDung) VALUES('" + process.STableName + "',getdate(),N'CẬP NHẬT IDBENHNHAN: " + process.getData("idbenhnhan") + ", " + sDescription + "','EDIT','" + process.getData("idbenhnhan") + "'," + UserID + ")";
                    bool SAVE_CHANGE = DataAcess.Connect.ExecSQL(sql_After_Change);
                }
                bool ok = process.Update();
                if (!ok)
                {
                    Response.StatusCode = 500;
                    return;
                }
                else if (sDescription != null && sDescription != "")
                {
                    string SQLUpdate_PhieuThu = @"UPDATE HS_DSDATHU SET mabenhnhan='" + Request.QueryString["MABENHNHAN"].ToUpper() + @"'
                                                                    ,tenbenhnhan=N'" + Request.QueryString["TENBENHNHAN"].ToUpper() + @"'
                                                                    ,ngaysinh='" + Request.QueryString["NGAYSINH"].ToUpper() + @"'
                                                WHERE IDBENHNHAN=" + process.getData("idbenhnhan")
                                          + "" + "\r\n";
                    SQLUpdate_PhieuThu += "\r\n" + @"UPDATE HS_BENHNHANBHDONGTIEN SET  
                                                                    HoTenBN=N'" + Request.QueryString["TENBENHNHAN"].ToUpper() + @"'
                                                WHERE IDBENHNHAN=" + process.getData("idbenhnhan");
                    bool ok_UpdatePhieuThu = DataAcess.Connect.ExecSQL(SQLUpdate_PhieuThu);

                }
            }
            else
            {
                process.data("ngaytiepnhan", ngayTN);
                bool ok = process.Insert();
                da_dang_ky = "0";
                if (!ok)
                {
                    Response.StatusCode = 500;
                    return;
                }
            }
            if (process.getData("loai") == "1")
            {
                string sobh1 = Request.QueryString["sobh1"];
                string sobh2 = Request.QueryString["sobh2"];
                string sobh3 = Request.QueryString["sobh3"];
                string sobh4 = Request.QueryString["sobh4"];
                string sobh5 = Request.QueryString["sobh5"];
                string sobh6 = Request.QueryString["sobh6"];
                string sobhyt = sobh1 + sobh2 + sobh3 + sobh4 + sobh5 + sobh6;
                bool IsTraiTuyen = StaticData.IsCheck(Request.QueryString["TraiTuyen"]);
                benhnhan_bhyt = Luu_BenhNhan_BHYT(process.getData("idbenhnhan"), sobhyt, Request.QueryString["ngaybatdau"],
                                      Request.QueryString["ngayhethan"],
                                     (Request.QueryString["TraiTuyen"] != null && !IsTraiTuyen ? "Y" : "N"),
                                      Request.QueryString["isgiaychuyen"],
                                      Request.QueryString["IsCapCuu"],
                                     (!IsTraiTuyen ? "1" : "0")
                                     , sobh1, sobh2, sobh3, sobh4, sobh5, sobh6
                                     , Request.QueryString["IdNoiDangKyBH"]
                                     , Request.QueryString["IdNoiGioiThieu"]
                                     , Request.QueryString["tilebhyt"]
                                    );
            }

            Response.Clear();
            Result = process.getData("idbenhnhan") + "@" + process.getData("mabenhnhan");
            Result += "@" + benhnhan_bhyt + "@" + da_dang_ky;
            Response.Write(Result);

        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    private string Luu_BenhNhan_BHYT(string idbenhnhan, string sobhyt
                                        , string ngaybatdau, string ngayhethan,
                                        string dungtuyen, string isgiaychuyen,
                                        string iscapcuu, string isdungtuyen
                                        , string sobh1, string sobh2, string sobh3, string sobh4,
                                        string sobh5, string sobh6, string IdNoiDangKyBH
                                        , string IdNoiGioiThieu, string tilebhyt)
    {
        DataProcess s_benhnhan_bhyt = new DataProcess("benhnhan_bhyt");
        s_benhnhan_bhyt.data("IDBENHNHAN_BH", Request.QueryString["IDBENHNHAN_BH"]);
        s_benhnhan_bhyt.data("IDBENHNHAN", idbenhnhan);
        s_benhnhan_bhyt.data("sobhyt", sobhyt);
        s_benhnhan_bhyt.data("ngaybatdau", ngaybatdau);
        s_benhnhan_bhyt.data("ngayhethan", ngayhethan);
        s_benhnhan_bhyt.data("DungTuyen", dungtuyen);
        s_benhnhan_bhyt.data("isgiaychuyen", isgiaychuyen);
        s_benhnhan_bhyt.data("IsCapCuu", iscapcuu);
        s_benhnhan_bhyt.data("IsDungTuyen", isdungtuyen);
        s_benhnhan_bhyt.data("sobh1", sobh1);
        s_benhnhan_bhyt.data("sobh2", sobh2);
        s_benhnhan_bhyt.data("sobh3", sobh3);
        s_benhnhan_bhyt.data("sobh4", sobh4);
        s_benhnhan_bhyt.data("sobh5", sobh5);
        s_benhnhan_bhyt.data("sobh6", sobh6);
        s_benhnhan_bhyt.data("IdNoiDangKyBH", IdNoiDangKyBH);
        s_benhnhan_bhyt.data("IdNoiGioiThieu", IdNoiGioiThieu);
        s_benhnhan_bhyt.data("tilebhyt", tilebhyt);
        DataTable dt = s_benhnhan_bhyt.Search_Object("IDBENHNHAN_BH");
        string bn_bhyt = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            if (s_benhnhan_bhyt.Update())
            {
                bn_bhyt = s_benhnhan_bhyt.getData("IDBENHNHAN_BH");
            }
        }
        else
        {

            if (s_benhnhan_bhyt.Insert())
            {
                bn_bhyt = s_benhnhan_bhyt.getData("IDBENHNHAN_BH");

            }
        }
        return bn_bhyt;
    }

    private void dangkykhambenh()
    {
        #region kiểm tra thông tin
        string idbenhnhan = Request.QueryString["idbenhnhan"].ToString();
        string idphong = Request.QueryString["idphongkhambenh"];
        string da_dangky = Request.QueryString["da_dangky"];
        string idkhoa = Request.QueryString["idkhoa"];
        string[] sismuaso = Request.QueryString["ismuaso"].Split(',');
        string ismuaso = sismuaso[0];
        if (ismuaso.IndexOf("false") != -1)
            ismuaso = "0";
        else
            ismuaso = "1";
        string isNotThuPhiCapCuu = Request.QueryString["isNotThuPhiCapCuu"];
        if (StaticData.IsCheck(isNotThuPhiCapCuu) == false)
            isNotThuPhiCapCuu = "0";
        else
            isNotThuPhiCapCuu = "1";

        string giodk = Request.QueryString["giodk"];
        string phutdk = Request.QueryString["phutdk"];
        string NgayDangKy = DataProcess.sGetValidDate(giodk, phutdk, Request.QueryString["ngaydangky"]);
        string NgayDangKy_KB = NgayDangKy;
        if (NgayDangKy.Substring(0, 5).IndexOf(":") != -1)
        {
            NgayDangKy_KB = StaticData.CheckDate(NgayDangKy.Substring(6, "29/11/2012".Length)) + " " + NgayDangKy.Substring(0, 5) + ":00";
        }
        #endregion
        #region checkphongdk
        if (da_dangky != "0")
        {
            string sqlCheck = @"select c.idbenhnhan,c.mabenhnhan,c.tenbenhnhan,a.phongid,b.ngaydangky,tenphong=(select tenphong from kb_phong where id=a.phongid)
	        from chitietdangkykham a 
	        left join dangkykham b 
            on a.iddangkykham=b.iddangkykham 
	        left join benhnhan c 
            on b.idbenhnhan=c.idbenhnhan
            where isnull(a.dahuy,0)=0" + (Request.QueryString["idphongkhambenh"] != null && Request.QueryString["idphongkhambenh"].ToString() != "" ? " and a.phongid=" + Request.QueryString["idphongkhambenh"].ToString() : " and a.idbanggiadichvu=628") + @"
	            and convert(varchar(10),ngaydangky,103)='" + string.Format("{0:dd/MM/yyyy}", Request.QueryString["ngaydangky"]) + @"'
	            and c.idbenhnhan=" + idbenhnhan + " ";
            DataTable dtCheckPhong = DataAcess.Connect.GetTable(sqlCheck);
            if (dtCheckPhong != null && dtCheckPhong.Rows.Count > 0 && idkhoa != "15")
            {
                Response.Clear();
                Response.StatusCode = 500;
                Response.Write("Bệnh nhân đã đăng ký khám nội dung này trong ngày rồi");
                return;
            }
            else
            {
                if (Request.QueryString["AllowDKKThem"] == "0" && Request.QueryString["idphongkhambenh"] != null && Request.QueryString["idphongkhambenh"].ToString() != "")
                {
                    string sqlCheck2 = @"select c.idbenhnhan,c.mabenhnhan,c.tenbenhnhan,a.phongid,b.ngaydangky,tenphong=(select tenphong from kb_phong where id=a.phongid)
	                    from chitietdangkykham a 
	                    left join dangkykham b 
                        on a.iddangkykham=b.iddangkykham 
	                    left join benhnhan c 
                        on b.idbenhnhan=c.idbenhnhan
                        where isnull(a.dahuy,0)=0 and  a.phongid <>" + Request.QueryString["idphongkhambenh"].ToString() + @"
	                        and convert(varchar(10),ngaydangky,103)='" + string.Format("{0:dd/MM/yyyy}", Request.QueryString["ngaydangky"]) + @"'
	                        and c.idbenhnhan=" + idbenhnhan + "";
                    DataTable dtCheckPhong2 = DataAcess.Connect.GetTable(sqlCheck2);
                    if (dtCheckPhong2 != null && dtCheckPhong2.Rows.Count > 0)
                    {
                        string ss = "";
                        for (int ii = 0; ii < dtCheckPhong2.Rows.Count; ii++)
                        {
                            ss += dtCheckPhong2.Rows[ii]["tenphong"].ToString() + ",";
                        }
                        Response.Clear();
                        Response.Write("Bệnh nhân đã đăng ký: " + ss + " trong ngày rồi, bạn muốn đăng ký  vui lòng nhấn lại nút Đăng ký");
                        return;
                    }
                }
            }
        }
        #endregion
        #region Lưu đăng ký khám
        string UserID = SysParameter.UserLogin.UserID(this);
        DataProcess DKK = new DataProcess("dangkykham");
        DKK.data("idbenhnhan", idbenhnhan);
        DKK.data("ngaydangky", NgayDangKy);
        DKK.data("dathu", "0");
            DKK.data("ngayxacnhan", NgayDangKy);
        DKK.data("dahuy", "0");
        DKK.data("loaitainanid", Request.QueryString["idloaitainan"].ToString());
        string LoaiKhamID = Request.QueryString["loai"];
        if (LoaiKhamID.IndexOf(",") != -1)
            LoaiKhamID = LoaiKhamID.Split(',')[0];
        DKK.data("LoaiKhamID", LoaiKhamID);
        DKK.data("IdNguoiDung", UserID);
        DKK.data("IDBENHNHAN_BH", (Request.QueryString["IDBENHNHAN_BH"] == null || Request.QueryString["IDBENHNHAN_BH"] == "") ? "" : Request.QueryString["IDBENHNHAN_BH"].ToString());
        bool saveDKK = DKK.Insert();
        string iddangkykham = "";
        if (!saveDKK)
        {
            Response.Clear();
            Response.StatusCode = 500;
            Response.Write("Không lưu được đăng ký khám !");
            return;
        }
        else
        {
            string sql = "select top 1 * from dangkykham where idbenhnhan='"+idbenhnhan+"' order by ngaydangky desc";
            DataTable dtBn = DataAcess.Connect.GetTable(sql);
             iddangkykham = dtBn.Rows[0]["iddangkykham"].ToString();
           
        }
        #endregion
        #region Kiem tra ngay ra toa khi tai kham
        if (da_dangky != "0")
        {
            if (Request.QueryString["idphongkhambenh"] != null
                && Request.QueryString["idphongkhambenh"].ToString() != ""
                && !KiemTraNgayRaToa(Request.QueryString["idbenhnhan"].ToString(), Request.QueryString["idphongkhambenh"].ToString()))
            {
                Response.Clear();
                Response.StatusCode = 500;
                Response.Write("Bệnh nhân này chưa tới ngày tái khám!");
                return;
            }
        }
        #endregion
        #region  Lưu dịch vụ khác mua sổ
        DataProcess ctdkkham = new DataProcess("chitietdangkykham");
        if (idphong != null && idphong != "")
        {

            DataTable dtb = DataAcess.Connect.GetTable("SELECT DichVuKCB FROM KB_Phong WHERE  Id=" + Request.QueryString["idphongkhambenh"].ToString());
            if (dtb == null || dtb.Rows.Count == 0)
            {
                Response.Clear();
                Response.StatusCode = 500;
                Response.Write("phòng khám ...");
                return;
            }
            string IdPhong = idphong;
            string DichVuKCB = dtb.Rows[0][0].ToString();
            string SoTT = StaticData_HS.GetSoThuTuDangKyKhamMoi(IdPhong, NgayDangKy_KB, true);
            string SLBNCho = "0"; //StaticData.GetSLBNChoKham(IdPhong, NgayDangKy_KB);
            string SLBNDaKham = "0";// StaticData.GetSLBNDaKham(IdPhong, NgayDangKy_KB);
            ctdkkham.data("iddangkykham", DKK.getData("iddangkykham"));
            ctdkkham.data("idbanggiadichvu", DichVuKCB);
            ctdkkham.data("soluong", "1");
            ctdkkham.data("dahuy", "0");
            ctdkkham.data("dakham", "0");
            ctdkkham.data("IdNguoiDung", UserID);
            ctdkkham.data("SoTT", SoTT);
            ctdkkham.data("phongid", IdPhong);
            ctdkkham.data("SLBNCho", SLBNCho);
            ctdkkham.data("SLBNDK", SLBNDaKham);
            ctdkkham.data("IsDaThu", "0");
            ctdkkham.data("isbndatra", "0");
            ctdkkham.data("isNotThuPhiCapCuu", isNotThuPhiCapCuu);
            ctdkkham.data("idkhoa", idkhoa);

            if (!ctdkkham.Insert())
            {
                Response.Clear();
                Response.StatusCode = 500;
                Response.Write("Đăng ký khám thất bại");
                return;
            }
        }
        #endregion
        #region Lưu dịch vụ mua sổ
        if (ismuaso == "1")
        {
            DataProcess ctdkkham_muaso = new DataProcess("chitietdangkykham");
            ctdkkham_muaso.data("iddangkykham", DKK.getData("iddangkykham"));
            ctdkkham_muaso.data("idbanggiadichvu", "628");
            ctdkkham_muaso.data("soluong", "1");
            ctdkkham_muaso.data("idkhoa", idkhoa);
            if (!ctdkkham_muaso.Insert())
            {
                Response.Clear();
                Response.StatusCode = 500;
                Response.Write("Đăng ký khám thất bại");
                return;
            }
        }
        #endregion
        #region LuuKhamBenhNoiTru
        string IdKhoa = Request.QueryString["IdKhoa"];
        if (IdKhoa != "1" && IdKhoa != "3")
        {

            string sqlInserKhamBenh = @"INSERT INTO KHAMBENH(     ngaykham,
                                                            idbenhnhan,
                                                            iddangkykham,
                                                            idbacsi,
                                                            ketluan,
                                                            huongdieutri,
                                                            idphongkhambenh,
                                                            IdChiTietDangKyKham,
                                                            DichVuKCBID,
                                                            IdKhoa,phongkhamchuyenden,
                                                            IdKhoaChuyen,IdPhong,PHONGID,IsKhongKham,isDaChuyenKhoa
                                                        )
                                  VALUES (";
            sqlInserKhamBenh += ""
                                                + "'" + NgayDangKy_KB + "'," + "\r\n"
                                                + idbenhnhan + "," + "\r\n"
                                                + DKK.getData("iddangkykham") + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "5" + "," + "\r\n"
                                                + IdKhoa + "," + "\r\n"
                                                + ctdkkham.getData("idchitietdangkykham") + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + ",0,2" + "\r\n"
                                             + ")";
            bool OK3 = DataAcess.Connect.ExecSQL(sqlInserKhamBenh);
            if (!OK3)
            {
                Response.Clear();
                Response.StatusCode = 500;
                return;
            }
            string sqlSelectKB = "SELECT TOP 1 IDKHAMBENH FROM KHAMBENH WHERE IDBENHNHAN='" + idbenhnhan + "' AND IDDANGKYKHAM='" + DKK.getData("IDDANGKYKHAM") + "' ORDER BY IDKHAMBENH DESC";
            DataTable dtKB = DataAcess.Connect.GetTable(sqlSelectKB);
            if (dtKB == null || dtKB.Rows.Count == 0)
            {
                Response.Clear();
                Response.Write("Không lưu được ( ErrorCode =1");
                Response.StatusCode = 500;
                return;
            }
            string Str_IsNgoaiTru = StaticData.nvk_xacNhan_IsNgoaiTru(IdKhoa, ctdkkham.getData("idchitietdangkykham"), "1", null);
            string IDKHAMBENH = dtKB.Rows[0][0].ToString();
            string sqlInsertBNNT = @"INSERT INTO BENHNHANNOITRU(
                                        NgayVaoVien
                                        ,NhapTuKhoa
                                        ,IdKhoaNoiTru
                                        ,IdChiTietDangKyKham
                                        ,IdKhamBenhGoc
                                        ,IdBenhNhan
                                        ,IdPhongNoiTru
                                        ,IdGiuong
                                        ,GhiChu
                                        ,ListIdCD
                                        ,GiaGiuong
                                        ,IsDaNhap
                                        ,IdKhamBenhNhap
                                        ,idbacsiNhap
                                        ,iddieuduongNhap
                                        ,isChonTrongNgay
                                        ,isChonNgaysau
                                        ,songay
                                        ,isNhapKhoa
                                        ,isChoSanh
                                        ,IsNgoaiTru)
                                                             
                                  VALUES (";
            sqlInsertBNNT += ""
                                                + "'" + NgayDangKy_KB + "'," + "\r\n"
                                                + IdKhoa + "," + "\r\n"
                                                + IdKhoa + "," + "\r\n"
                                                + ctdkkham.getData("idchitietdangkykham") + "," + "\r\n"
                                                + IDKHAMBENH + "," + "\r\n"
                                                + idbenhnhan + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "1" + "," + "\r\n"
                                                + IDKHAMBENH + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                + "NULL" + "," + "\r\n"
                                                 + "NULL" + "," + "\r\n"
                                                  + "NULL" + "," + "\r\n"
                                                   + "NULL" + "," + "\r\n"
                                                    + "0" + "," + "\r\n"
                                                    + "0" + "," + "\r\n"
                                                     + Str_IsNgoaiTru + "" + "\r\n"
                                             + ")";
            bool OK4 = DataAcess.Connect.ExecSQL(sqlInsertBNNT);
            if (!OK4)
            {
                Response.Clear();
                Response.StatusCode = 500;
                return;
            }
        }
        #endregion
        #region TinhLaiTien_ByIdDangKyKham
        if (da_dangky != "1")// CHUA CO DANG KY KHAM LAN NAO CA
        {
            StaticData.TinhLaiTien_ByIdDangKyKham(DKK.getData("iddangkykham"), "1");
        }
        else // DA CO DANG KY KHAM 1 LAN ROI
        {
            if (LoaiKhamID != "1")
            {
                string sqlTinhTienDKK = "EXEC ZHS_TONGTIENDV_CHUYENKHOA_BY_IDDANGKYKHAM " + DKK.getData("iddangkykham");
                bool OK_TINHTIENDKK = DataAcess.Connect.ExecSQL(sqlTinhTienDKK);
            }
            else
            {
                StaticData.TinhLaiTien_ByIdDangKyKham(DKK.getData("iddangkykham"), "0");
            }
        }
        Response.Clear();
        Response.Write(iddangkykham);
        #endregion
    }
    private bool KiemTraNgayRaToa(string idbenhnhan, string phongid)
    {
        return true;
        int idbnTT = 0;
        idbnTT = StaticData.ParseInt(idbenhnhan);
        string hetThuoc = @"select convert(datetime,dateadd(day,max(ct.ngayuong),max(ngayratoa)),111) as HetThuoc 
                        from benhnhantoathuoc bntt
                        left join chitietbenhnhantoathuoc ct on ct.idbenhnhantoathuoc=bntt.idbenhnhantoathuoc
                        inner join khambenh kb on kb.idkhambenh=bntt.idkhambenh
                        inner join chitietdangkykham ctdk on ctdk.idchitietdangkykham=kb.idchitietdangkykham
                        where bntt.idbenhnhan=" + idbnTT + " and ctdk.phongid='" + phongid + @"'
                        group by ngayratoa";
        DataTable dtHetThuoc = DataAcess.Connect.GetTable(hetThuoc);
        if (dtHetThuoc == null) return true;
        if (dtHetThuoc.Rows.Count <= 0) return true;
        if (dtHetThuoc.Rows[0]["HetThuoc"].ToString() == "")
            return true;
        DateTime hetThuocDung = DateTime.Parse(dtHetThuoc.Rows[0]["HetThuoc"].ToString());
        DateTime currenDay = DateTime.Parse(System.DateTime.Now.ToString("yyyy/MM/dd"));
        if (currenDay <= hetThuocDung)
        {
            return false;
        }
        else
            return true;
    }
    private void TimDiaChi()
    {
        string sqlSelect = @"SELECT TOP 10 A.KYHIEU,A.PHUONGXAID,A.QUANHUYENID,B.TINHID,
                            A.TENPHUONGXA + ',' + B.QUANHUYENNAME + ',' + C.TINHNAME AS DIACHI,
                           A.TENPHUONGXA,B.QUANHUYENNAME,C.MATINH + '_' + C.TINHNAME AS TENTINH
                            FROM PHUONGXA A LEFT JOIN QUANHUYEN B ON A.QUANHUYENID=B.QUANHUYENID
                            LEFT JOIN TINH C ON B.TINHID=C.TINHID
                            WHERE A.KYHIEU LIKE N'" + Request.QueryString["q"] + "%' ORDER BY C.TINHNAME";
        string html = "";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table != null && table.Rows.Count > 0)
        {
            foreach (DataRow row in table.Rows)
            {
                html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}", "<div>"
                      + "<div style=\"width:15%; float:left; padding-left:10px; font-size:13px;\">" + row["KYHIEU"] + "</div>"
                      + "<div style=\"width:80%; float:left; font-size:13px;\">" + row["DIACHI"] + "</div>"
                      + "</div>", row["KYHIEU"], row["DIACHI"], row["PHUONGXAID"], row["QUANHUYENID"], row["TINHID"], row["TENPHUONGXA"], row["QUANHUYENNAME"], row["TENTINH"], Environment.NewLine
                    );
            }
        }
        Response.Clear();
        Response.Write(html);

    }
    private void GetLastIDDangKyCLS()
    {
        string IdBenhNhan = Request.QueryString["IdBenhNhan"];
        if (IdBenhNhan == null || IdBenhNhan == "")
        {
            Response.Write("");
            return;
        }

        string sqlSelect = @"SELECT DISTINCT IDBENHNHAN,MAPHIEUCLS,NGAYTHU,IdNguoiDung
                                    FROM KHAMBENHCANLAMSAN
                                   WHERE ISNULL(IDKHAMBENH,0)=0 AND IDBENHNHAN=" + IdBenhNhan;
        DataTable dtCheck = DataAcess.Connect.GetTable(sqlSelect);
        if (dtCheck == null || dtCheck.Rows.Count == 0)
        {
            Response.Write("not");
            return;
        }
        sqlSelect = "SELECT TOP 1 * FROM HS_DANGKYCLS WHERE IDBENHNHAN=" + IdBenhNhan + @"  ORDER BY NGAYDK DESC";

        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt == null || dt.Rows.Count == 0)
        {
            return;
        }
        Response.Clear();
        Response.Write(dt.Rows[0][0].ToString());
        return;
    }
    //────────────────────────────────────────────────────────────────────────────────────────── 
    public static string NewSTT(string NgayTiepNhan)
    {
        string SLBN = "0";
        DateTime dNgayTiepNhan = DateTime.Parse(NgayTiepNhan);
        string sqlSelect = @"SELECT count(idbenhnhan) 
                                FROM BENHNHAN
                                WHERE YEAR(NGAYTIEPNHAN)=" + dNgayTiepNhan.Year.ToString()
                                    + " AND MONTH(NGAYTIEPNHAN)=" + dNgayTiepNhan.Month.ToString()
                                    + " AND DAY(NGAYTIEPNHAN)=" + dNgayTiepNhan.Day.ToString();
        DataTable dtBenhNhan = DataAcess.Connect.GetTable(sqlSelect);
        if (dtBenhNhan == null) return "";
        SLBN = "0";
        if (dtBenhNhan.Rows.Count > 0) SLBN = dtBenhNhan.Rows[0][0].ToString();
        if (SLBN == "") SLBN = "0";
        SLBN = (int.Parse(SLBN) + 1).ToString();
        return SLBN;

    }
    //────────────────────────────────────────────────────────────────────────────────────────── 
    public static string NewMaBenhNhan(string NgayTiepNhan, ref string SLBN)
    {
        string s = "";
        while (true)
        {
            DateTime dNgayTiepNhan = DateTime.Parse(NgayTiepNhan);
            string sqlSelect = @"SELECT MAX(SLBN) 
                                FROM HS_MaBenhNhanSave
                                WHERE YEAR(sysdate)=" + dNgayTiepNhan.Year.ToString()
                                        + " AND MONTH(sysdate)=" + dNgayTiepNhan.Month.ToString()
                                        + " AND DAY(sysdate)=" + dNgayTiepNhan.Day.ToString();
            DataTable dtBenhNhan = DataAcess.Connect.GetTable(sqlSelect);
            if (dtBenhNhan == null) return "";
            SLBN = "0";
            if (dtBenhNhan.Rows.Count > 0) SLBN = dtBenhNhan.Rows[0][0].ToString();
            if (SLBN == "") SLBN = "0";
            SLBN = (int.Parse(SLBN) + 1).ToString();
            s = "BN-" + dNgayTiepNhan.ToString("ddMMyyyy") + "-" + SLBN;

            bool OK = DataAcess.Connect.ExecSQL(@"insert into HS_MaBenhNhanSave (sysdate,slbn,mabenhnhan)
                                    values('" + NgayTiepNhan + "','" + SLBN + "','" + s + "')");
            if (OK == false) return null;
            string sqlTest = "SELECT TOP 1 IDBENHNHAN FROM BENHNHAN WHERE MABENHNHAN=N'" + s + "'";
            DataTable dtTest = DataAcess.Connect.GetTable(sqlTest);
            if (dtTest == null) return null;
            if (dtTest.Rows.Count == 0) break;

        }
        return s;

    }
    //────────────────────────────────────────────────────────────────────────────────────────── 
    private void TinhLaiTien()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        if (idbenhnhan == null || idbenhnhan == "") return;
        string sqlEx = "EXEC DBO.zHS_TinhLaiTienByIdBenhNhan " + idbenhnhan;
        bool OK = DataAcess.Connect.ExecSQL(sqlEx);
        if (OK)
            Response.Write("Tính tiền lại thành công");
        else
            Response.Write("Tính tiền lại thất bại");
    }
    //────────────────────────────────────────────────────────────────────────────────────────── 

}



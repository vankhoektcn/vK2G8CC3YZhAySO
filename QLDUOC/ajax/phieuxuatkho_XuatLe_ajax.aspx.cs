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

public partial class phieuxuatkho_XuatLe_ajax : System.Web.UI.Page
{
    protected DataProcess s_phieuxuatkho()
    {
        DataProcess phieuxuatkho = new DataProcess("phieuxuatkho");
        phieuxuatkho.data("idphieuxuat", Request.QueryString["idkhoachinh"]);
        phieuxuatkho.data("maphieuxuat", Request.QueryString["maphieuxuat"]);
        phieuxuatkho.data("ngaythang", Request.QueryString["ngaythang"]);
        phieuxuatkho.data("ghichu", Request.QueryString["ghichu"]);
        phieuxuatkho.data("idphongkhambenh", Request.QueryString["idphongkhambenh"]);
        phieuxuatkho.data("nguoinhan", Request.QueryString["nguoinhan"]);
        phieuxuatkho.data("xuatcho", Request.QueryString["xuatcho"]);
        phieuxuatkho.data("idkho", Request.QueryString["idkho"]);
        phieuxuatkho.data("loaixuat", "1");
        phieuxuatkho.data("IDKhachHang", Request.QueryString["IDKhachHang"]);
        phieuxuatkho.data("vat", Request.QueryString["vat"]);
        phieuxuatkho.data("thanhtien", Request.QueryString["thanhtien"]);
        phieuxuatkho.data("ngayhoadon", Request.QueryString["ngayhoadon"]);
        phieuxuatkho.data("idnhacungcap", Request.QueryString["idnhacungcap"]);
        phieuxuatkho.data("idkho2", Request.QueryString["idkho2"]);
        phieuxuatkho.data("idnguoixuat", Request.QueryString["idnguoixuat"]);
        phieuxuatkho.data("IdBenhNhanToaThuoc", Request.QueryString["IdBenhNhanToaThuoc"]);
        phieuxuatkho.data("IsBHYT", Request.QueryString["IsBHYT"]);
        phieuxuatkho.data("SLPX", Request.QueryString["SLPX"]);
        phieuxuatkho.data("tkNo", Request.QueryString["tkNo"]);
        phieuxuatkho.data("TKVAT", Request.QueryString["TKVAT"]);
        phieuxuatkho.data("TKCo", Request.QueryString["TKCo"]);
        phieuxuatkho.data("IdCaPhauThuat", Request.QueryString["IdCaPhauThuat"]);
        phieuxuatkho.data("IsDaHuy", Request.QueryString["IsDaHuy"]);
        phieuxuatkho.data("LANSUA", Request.QueryString["LANSUA"]);
        phieuxuatkho.data("MaPhieu", Request.QueryString["MaPhieu"]);
        phieuxuatkho.data("NGAYSUA", Request.QueryString["NGAYSUA"]);
        phieuxuatkho.data("NGUOISUA", Request.QueryString["NGUOISUA"]);
        phieuxuatkho.data("IdBenhNhan", Request.QueryString["IdBenhNhan"]);
        phieuxuatkho.data("IdLoaiThuoc", Request.QueryString["IdLoaiThuoc"]);
        return phieuxuatkho;
    }
    protected DataProcess s_HS_OutPutDetail()
    {
        DataProcess HS_OutPutDetail = new DataProcess("HS_OutPutDetail");
        HS_OutPutDetail.data("OutPutDetailID", Request.QueryString["idkhoachinh"]);
        HS_OutPutDetail.data("IdPhieuXuat", Request.QueryString["IdPhieuXuat"]);
        HS_OutPutDetail.data("IdThuoc", Request.QueryString["IdThuoc"]);
        HS_OutPutDetail.data("Quantity", Request.QueryString["Quantity"]);
        HS_OutPutDetail.data("UnitID", Request.QueryString["UnitID"]);
        HS_OutPutDetail.data("Note", Request.QueryString["Note"]);
        HS_OutPutDetail.data("losanxuat_", Request.QueryString["losanxuat_"]);
        HS_OutPutDetail.data("ngayhethan_", Request.QueryString["ngayhethan_"]);
        HS_OutPutDetail.data("SLTON", Request.QueryString["SLTON"]);
        return HS_OutPutDetail;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savephieuxuatkho(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableHS_OutPutDetail": LuuTableHS_OutPutDetail(); break;
            case "loadTableHS_OutPutDetail": loadTableHS_OutPutDetail(); break;
            case "xoa": Xoaphieuxuatkho(); break;
            case "xoaHS_OutPutDetail": XoaHS_OutPutDetail(); break;
            case "idkhoSearch": idkhoSearch(); break;
            case "IdLoaiThuocSearch": IdLoaiThuocSearch(); break;
            case "IdThuocSearch": IdThuocSearch(); break;
            case "UnitIDSearch": UnitIDSearch(); break;
            case "GetMaPhieuXuat": GetMaPhieuXuat(); break;
            case "PrevInfo": PrevInfo(); break;
            case "idkhachhangsearch": idkhachhangsearch(); break;
            case "setIdKho": setIdKho(); break;

        }
    }
    private void setIdKho()
    {
        StaticData.SetDefaultIdKho(this, "idkho", "mkv_idkho", "IdLoaiThuoc", "mkv_IdLoaiThuoc");
    }
    private void GetMaPhieuXuat()
    {
        string sqlSelect = @"SELECT *,DSTHUOC=DBO.HS_DSTHUOCGXUATKOPHUHOP(IDPHIEUXUAT) FROM PHIEUXUATKHO WHERE IDPHIEUXUAT=" + Request.QueryString["IDPHIEUXUAT"];
        DataTable dtMaPhieuXuat = DataAcess.Connect.GetTable(sqlSelect);
        if (dtMaPhieuXuat == null || dtMaPhieuXuat.Rows.Count == 0) return;
        Response.Write(dtMaPhieuXuat.Rows[0]["MAPHIEUXUAT"].ToString()
                            + "|" + ""
                            + "|" + dtMaPhieuXuat.Rows[0]["IDKHO"].ToString()
                            + "|" + DateTime.Parse(dtMaPhieuXuat.Rows[0]["NGAYTHANG"].ToString()).ToString("dd/MM/yyyy")
                            + "|" + dtMaPhieuXuat.Rows[0]["IDKHO2"].ToString()
                            + "|" + dtMaPhieuXuat.Rows[0]["MAPHIEUXUAT"].ToString()
                            + "|" + dtMaPhieuXuat.Rows[0]["DSTHUOC"].ToString()
                        );
    }
    private void idkhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void idkhachhangsearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT IDKHACHHANG,TENKHACHHANG from khachhang");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TENKHACHHANG"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdLoaiThuocSearch()
    {
        StaticData.IdLoaiThuocSearch(this);
    }
    private void IdThuocSearch()
    {
        StaticData.getthuoc_new(this,false);
    }
    private void UnitIDSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select * from thuoc_donvitinh");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenDVT"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoaphieuxuatkho()
    {
        try
        {
            DataProcess process = s_phieuxuatkho();

            string sqlDeleteOldChiTietPhieuXuatKho = "DELETE CHITIETPHIEUXUATKHO WHERE IDPHIEUXUATKHO=" + process.getData("idphieuxuat");
            bool ok1 = DataAcess.Connect.ExecSQL(sqlDeleteOldChiTietPhieuXuatKho);
            if (!ok1)
            {
                Response.StatusCode = 500;
            }

            string sqlDeleteOldHS_OUTPUTDETAIL = "DELETE HS_OUTPUTDETAIL WHERE IDPHIEUXUATKHO=" + process.getData("idphieuxuat");
            bool ok2 = DataAcess.Connect.ExecSQL(sqlDeleteOldHS_OUTPUTDETAIL);
            if (!ok2)
            {
                Response.StatusCode = 500;
            }

            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idphieuxuat"));
                return;
            }
        }
        catch
        {
            Response.StatusCode = 500;

        }
    }
    private void XoaHS_OutPutDetail()
    {
        try
        {
            DataProcess process = s_HS_OutPutDetail();
            string sqlDeleteOldChiTietPhieuXuatKho = "DELETE CHITIETPHIEUXUATKHO WHERE OUTPUTDETAILID=" + process.getData("OutPutDetailID");
            bool ok1 = DataAcess.Connect.ExecSQL(sqlDeleteOldChiTietPhieuXuatKho);
            if (ok1)
            {
                bool ok = process.Delete();
                if (ok)
                {

                    Response.Clear(); Response.Write(process.getData("OutPutDetailID"));
                    return;
                }
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    private void setTimKiem()
    {
        if (StaticData.HavePermision(this, "phieuxuatkho_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = Process_2608.phieuxuatkho.dtSearchByidphieuxuat(idkhoachinh);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable idkho = Thuoc_Process.khothuoc.dtSearchByidkho("'" + table.Rows[0]["idkho"] + "'");
            html.AppendLine("<data id=\"mkv_idkho\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0]["tenkho"] : "") + "</data>");
            DataTable IdLoaiThuoc = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID("'" + table.Rows[0]["IdLoaiThuoc"] + "'");

            DataTable idkhachhang = DataAcess.Connect.GetTable("SELECT IDKHACHHANG ,TENKHACHHANG FROM KHACHHANG WHERE IDKHACHHANG='" + table.Rows[0]["idkhachhang"] + "'");
            html.AppendLine("<data id=\"mkv_idkhachhang\">" + ((idkhachhang.Rows.Count > 0) ? idkhachhang.Rows[0]["TENKHACHHANG"] : "") + "</data>");

            html.AppendLine("<data id=\"mkv_IdLoaiThuoc\">" + ((IdLoaiThuoc.Rows.Count > 0) ? IdLoaiThuoc.Rows[0][1] : "") + "</data>");

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
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "phieuxuatkho_Search"))
        {
            DataProcess process = s_phieuxuatkho();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idphieuxuat),T.*
                   ,A.TENKHO
                   ,B.TenLoai
                   ,C.TENKHACHHANG
                               from phieuxuatkho T
                    left join khothuoc  A on T.idkho=A.idkho
                    left join Thuoc_LoaiThuoc  B on T.IdLoaiThuoc=B.LoaiThuocID
                    LEFT JOIN KHACHHANG C ON T.IDKHACHHANG=C.IDKHACHHANG
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idphieuxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaixuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkhachhang") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["idphieuxuat"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["maphieuxuat"].ToString() + "</td>");
                        if (table.Rows[i]["ngaythang"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["ngaythang"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["ngaythang"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["ghichu"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TENKHO"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["loaixuat"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TENKHACHHANG"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TenLoai"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                    html.Append("</table>");
                    html.Append(process.Paging());
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
    private void Savephieuxuatkho()
    {
        try
        {
            DataProcess process = s_phieuxuatkho();
            string MaPhieuXuat = process.getData("MaPhieuXuat");
            string NgayThang = process.getData("ngaythang");
            string NgayThang_Prev = Request.QueryString["NgayThang_Prev"];
            if (NgayThang_Prev == null || NgayThang_Prev == "")
                NgayThang_Prev = NgayThang;

            string MaPhieuXuat_Prev = Request.QueryString["MaPhieuXuat_Prev"];
            if (MaPhieuXuat_Prev == null || MaPhieuXuat_Prev == "")
                MaPhieuXuat_Prev = MaPhieuXuat;


          
            process.data("loaixuat", "1");
            string idnguoixuat = process.getData("idnguoixuat");
            if (idnguoixuat == null || idnguoixuat == "")
            {
                idnguoixuat = SysParameter.UserLogin.UserID(this);
                process.data("idnguoixuat", idnguoixuat);
            }
            #region Xử lý ngày tháng lưu lại
            #region Trường hợp Update
            if (process.getData("idphieuxuat") != null && process.getData("idphieuxuat") != "")
            {
                DataTable dt_oldNgayThang = DataAcess.Connect.GetTable("SELECT NGAYTHANG FROM PHIEUXUATKHO WHERE IDPHIEUXUAT=" + process.getData("idphieuxuat"));
                if (dt_oldNgayThang != null && dt_oldNgayThang.Rows.Count != 0)
                {
                    DateTime oldNgayThang = DateTime.Parse(dt_oldNgayThang.Rows[0][0].ToString());
                    DateTime saveDate1 = DateTime.Parse(StaticData.CheckDate(NgayThang));
                    if (oldNgayThang.ToString("yyyy-MM-dd") == saveDate1.ToString("yyyy-MM-dd"))
                    {
                        NgayThang = NgayThang + " " + oldNgayThang.ToString("HH:mm:ss");

                    }
                    else
                    {
                        DateTime Now1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        if (saveDate1 < Now1)
                            NgayThang = NgayThang += " 23:59:00";
                        else
                        {
                            NgayThang = NgayThang += " " + DateTime.Now.ToString("HH:mm:ss");
                        }

                    }

                }
            }
            #endregion
            #region Trường hợp Insert
            else
            {
                string sNgayThang = StaticData.CheckDate(NgayThang);
                DateTime saveDate = DateTime.Parse(sNgayThang);
                DateTime Now = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                if (saveDate < Now)
                    NgayThang = NgayThang += " 23:59:00";
                else
                {
                    NgayThang = NgayThang += " " + DateTime.Now.ToString("HH:mm:ss");
                }
            }
            #endregion
            process.data("ngaythang", NgayThang);
            #endregion
            if (process.getData("idphieuxuat") != null && process.getData("idphieuxuat") != "")
            {
                if (StaticData.CheckDate(NgayThang) != StaticData.CheckDate(NgayThang_Prev))
                {
                    string sqlDelete1 = "DELETE HS_MAPHIEUXUAT WHERE MAPHIEUXUAT='" + MaPhieuXuat_Prev + "'";
                    bool ok_delete1 = DataAcess.Connect.ExecSQL(sqlDelete1);
                    if (MaPhieuXuat != null || MaPhieuXuat != "")
                    {
                        string MaPhieuXuat_s = MaPhieuXuat.Substring(0, "PXKD130417".Length).Remove(0, 4);
                        if (MaPhieuXuat_s.Length == 6)
                        {
                            if (DateTime.Parse(StaticData.CheckDate(NgayThang)).ToString("yyMMdd") != MaPhieuXuat_s)
                            {
                                MaPhieuXuat = "";
                            }
                        }


                    }
                }
                if (MaPhieuXuat != null || MaPhieuXuat != "")
                {
                    DataTable dtTest = DataAcess.Connect.GetTable("SELECT * FROM PHIEUXUATKHO WHERE IDPHIEUXUAT<>" + process.getData("idphieuxuat") + " AND MAPHIEUXUAT='" + MaPhieuXuat + "'");
                    if (dtTest != null && dtTest.Rows.Count > 0)
                    {
                        Response.StatusCode = 500;
                        return;
                    }
                }
                bool ok = process.Update();
                if (ok)
                {
                    if (StaticData.CheckDate(NgayThang) != StaticData.CheckDate(NgayThang_Prev) && MaPhieuXuat == "")
                    { 
                    }

                    Response.Clear(); Response.Write(process.getData("idphieuxuat"));
                    return;
                }
            }
            else
            {

                bool ok = process.Insert();
                if (ok)
                {
                    if (process.getData("maphieuxuat") == null || process.getData("maphieuxuat") == "")
                    {
                        
                    }
                    else
                    {
                        DataTable dtTest = DataAcess.Connect.GetTable("SELECT * FROM PHIEUXUATKHO WHERE IDPHIEUXUAT<>" + process.getData("idphieuxuat") + " AND MAPHIEUXUAT='" + MaPhieuXuat + "'");
                        if (dtTest != null && dtTest.Rows.Count > 0)
                        {
                            Response.StatusCode = 500;
                            return;
                        }
                    }
                    Response.Clear(); Response.Write(process.getData("idphieuxuat"));
                    return;
                }
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    public void LuuTableHS_OutPutDetail()
    {
        try
        {
            DataProcess process = s_HS_OutPutDetail();
            if (process.getData("OutPutDetailID") != null && process.getData("OutPutDetailID") != "")
            {
                string IdKho_Prev = Request.QueryString["IdKho_Prev"];
                string NgayThang_Prev = Request.QueryString["NgayThang_Prev"];



                string IdKho = Request.QueryString["IdKho"];
                string NgayThang = Request.QueryString["NgayThang"];

                if (IdKho_Prev == null || IdKho_Prev == "") IdKho_Prev = IdKho;
                if (NgayThang_Prev == null || NgayThang_Prev == "") NgayThang_Prev = NgayThang;

                bool IsChange1 = false;
                if (IdKho_Prev != IdKho
                   || DateTime.Parse(StaticData.CheckDate(NgayThang_Prev)).ToString("yyyy-MM-dd") != DateTime.Parse(StaticData.CheckDate(NgayThang)).ToString("yyyy-MM-dd")
                   )
                    IsChange1 = true;

                string sqlSelect = "SELECT * FROM HS_OUTPUTDETAIL WHERE OutPutDetailID=" + process.getData("OutPutDetailID");
                DataTable dtTest = DataAcess.Connect.GetTable(sqlSelect);
                if (dtTest != null && dtTest.Rows.Count > 0)
                {
                    string Idthuoc_old = dtTest.Rows[0]["IdThuoc"].ToString();
                    string Quantity_old = dtTest.Rows[0]["Quantity"].ToString();
                    string IdThuoc_new = process.getData("idthuoc");
                    string Quantity_new = process.getData("quantity");
                    if (IdThuoc_new != Idthuoc_old || Quantity_new != Quantity_old || IsChange1)
                    {
                        string sqlDeleteOldChiTietPhieuXuatKho = "DELETE CHITIETPHIEUXUATKHO WHERE OUTPUTDETAILID=" + process.getData("OutPutDetailID");
                        bool ok1 = DataAcess.Connect.ExecSQL(sqlDeleteOldChiTietPhieuXuatKho);
                        if (ok1)
                        {
                            bool ok = process.Update();
                            if (!ok)
                            {

                                Response.Clear(); Response.StatusCode = 500;
                                return;
                            }

                            string OutPutDetailID = process.getData("OutPutDetailID");
                            string sqlSave2 = "EXEC [Thuoc_XuatThuoc_Automatic2] " + OutPutDetailID;
                            bool OK2 = DataAcess.Connect.ExecSQL(sqlSave2);
                            if (OK2)
                            {
                                Response.Clear(); Response.Write(process.getData("OutPutDetailID"));
                                return;
                            }
                            else
                            {
                                Response.StatusCode = 500;
                                return;
                            }
                        }
                        else
                        {
                            Response.StatusCode = 500;
                            return;
                        }
                    }
                }
                Response.Write(process.getData("OutPutDetailID"));

            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    string OutPutDetailID = process.getData("OutPutDetailID");
                    string sqlSave2 = "EXEC [Thuoc_XuatThuoc_Automatic2] " + OutPutDetailID;
                    bool OK2 = DataAcess.Connect.ExecSQL(sqlSave2);
                    if (!OK2)
                    {
                        Response.Clear();
                        Response.StatusCode = 500;
                        return;

                    }
                    Response.Clear(); Response.Write(OutPutDetailID);

                    return;
                }
            }



        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    public void loadTableHS_OutPutDetail()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("UnitID") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Quantity") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("losanxuat") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhethan") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Note") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SLTON") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "HS_OutPutDetail_Add");
        bool search = StaticData.HavePermision(this, "HS_OutPutDetail_Search");
        if (search)
        {
            DataProcess process = s_HS_OutPutDetail();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.OutPutDetailID),T.*
                   ,A.TenThuoc
                   ,B.TenDVT,ngayhethan103=convert(varchar(10),ngayhethan_,103)
                               from HS_OutPutDetail T
                    left join thuoc  A on T.IdThuoc=A.idthuoc
                    left join Thuoc_DonViTinh  B on T.UnitID=B.Id
          where T.IdPhieuXuat='" + process.getData("IdPhieuXuat") + "'");
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("HS_OutPutDetail");
                bool delete = StaticData.HavePermision(this, "HS_OutPutDetail_Delete");
                bool edit = StaticData.HavePermision(this, "HS_OutPutDetail_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value='" + table.Rows[i]["IdThuoc"] + "'/><input mkv='true' id='mkv_IdThuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='IdThuocSearch(this);' style='width:200px'  class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='UnitID' type='hidden' value='" + table.Rows[i]["UnitID"] + "'/><input mkv='true' id='mkv_UnitID' type='text' value='" + table.Rows[i]["TenDVT"].ToString() + "' onfocus='UnitIDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='Quantity' style='width:50px;' onblur='CheckSLTon(this);' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["Quantity"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='losanxuat_' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["losanxuat_"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='ngayhethan_' type='text' style='width:90px;' onblur='$.TestDate(this)'  value='" + table.Rows[i]["ngayhethan103"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='Note' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["Note"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='SLTON' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SLTON"].ToString() + "' " + "disabled" + "/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["OutPutDetailID"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value=''/><input mkv='true' id='mkv_IdThuoc' type='text' value='' onfocus='IdThuocSearch(this);' style='width:200px' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='UnitID' type='hidden' value=''/><input mkv='true' id='mkv_UnitID' type='text' value='' onfocus='UnitIDSearch(this);' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='Quantity' type='text' style='width:50px;' onblur='CheckSLTon(this);' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>");
            html.Append("<td><input mkv='true' id='losanxuat_' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
            html.Append("<td><input mkv='true' id='ngayhethan_' type='text' style='width:90px;' onblur='$.TestDate(this)'  value='' /></td>");
            html.Append("<td><input mkv='true' id='Note' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
            html.Append("<td><input mkv='true' id='SLTON' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  disabled /></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }//end void

    private void PrevInfo()
    {
        string sqlSelect = @" select top 1  a.idkho,tenkho1=B.tenkho, a.idkho2,tenkho2=C.tenkho
                                ,A.IDLOAITHUOC,D.TENLOAI
                                from phieuxuatkho A
                                 LEFT JOIN KHOTHUOC B ON A.IDKHO=B.IDKHO
                                 LEFT JOIN KHOTHUOC C ON A.IDKHO2=C.IDKHO
                                 LEFT JOIN THUOC_LOAITHUOC D ON A.IDLOAITHUOC=D.LOAITHUOCID
                                where loaixuat=4 order by  idphieuxuat desc";
        DataTable dtPrevInfo = DataAcess.Connect.GetTable(sqlSelect);
        if (dtPrevInfo == null || dtPrevInfo.Rows.Count == 0) return;
        Response.Write(dtPrevInfo.Rows[0]["idkho"].ToString() + "|" + dtPrevInfo.Rows[0]["tenkho1"].ToString() + "| " + dtPrevInfo.Rows[0]["idkho2"].ToString() + "|" + dtPrevInfo.Rows[0]["tenkho2"].ToString() + "| " + dtPrevInfo.Rows[0]["IDLOAITHUOC"].ToString() + "|" + dtPrevInfo.Rows[0]["TENLOAI"].ToString());

    }


}



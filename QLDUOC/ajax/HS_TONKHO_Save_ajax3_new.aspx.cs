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

public partial class HS_TONKHO_Save_ajax3_new : System.Web.UI.Page
{
    protected DataProcess s_HS_TONKHO_Save()
    {
        DataProcess HS_TONKHO_Save = new DataProcess("HS_TONKHO_View");
        HS_TONKHO_Save.data("IdTonKho", Request.QueryString["idkhoachinh"]);
        HS_TONKHO_Save.data("IdKho", Request.QueryString["IdKho"]);
        HS_TONKHO_Save.data("TuNgay", Request.QueryString["TuNgay"]);
        HS_TONKHO_Save.data("DenNgay", Request.QueryString["DenNgay"]);
        HS_TONKHO_Save.data("LoaiThuocID", Request.QueryString["LoaiThuocID"]);
        HS_TONKHO_Save.data("IdThuoc", Request.QueryString["IdThuoc"]);
        HS_TONKHO_Save.data("TenThuoc", Request.QueryString["TenThuoc"]);
        HS_TONKHO_Save.data("IsOrderByName", Request.QueryString["IsOrderByName"]);
        HS_TONKHO_Save.data("IsHaveDONGIA", Request.QueryString["IsHaveDONGIA"]);
        HS_TONKHO_Save.data("IsSoLuong", Request.QueryString["IsSoLuong"]);
        HS_TONKHO_Save.data("IsRutGon", Request.QueryString["IsRutGon"]);
        return HS_TONKHO_Save;
    }
    protected DataProcess s_HS_TonKhoViewDetail()
    {
        DataProcess HS_TonKhoViewDetail = new DataProcess("HS_TonKhoViewDetail");
        HS_TonKhoViewDetail.data("IdTonKhoDetail", Request.QueryString["idkhoachinh"]);
        HS_TonKhoViewDetail.data("IdTonKho", Request.QueryString["IdTonKho"]);
        HS_TonKhoViewDetail.data("TTHC", Request.QueryString["TTHC"]);
        HS_TonKhoViewDetail.data("TenSP", Request.QueryString["mkv_IdThuoc"]);
        HS_TonKhoViewDetail.data("TENDVT", Request.QueryString["TENDVT"]);
        HS_TonKhoViewDetail.data("DONGIA", Request.QueryString["DONGIA"]);
        HS_TonKhoViewDetail.data("LoSanXuat", Request.QueryString["LoSanXuat"]);
        HS_TonKhoViewDetail.data("Ngayhethan", Request.QueryString["Ngayhethan"]);
        HS_TonKhoViewDetail.data("DAUKY_SL", Request.QueryString["DAUKY_SL"]);
        HS_TonKhoViewDetail.data("DAUKY_TT", Request.QueryString["DAUKY_TT"]);
        HS_TonKhoViewDetail.data("NHAP_SL", Request.QueryString["NHAP_SL"]);
        HS_TonKhoViewDetail.data("NHAP_TT", Request.QueryString["NHAP_TT"]);
        HS_TonKhoViewDetail.data("NHAP_SL2", Request.QueryString["NHAP_SL2"]);
        HS_TonKhoViewDetail.data("NHAP_TT2", Request.QueryString["NHAP_TT2"]);
        HS_TonKhoViewDetail.data("XUAT_SL", Request.QueryString["XUAT_SL"]);
        HS_TonKhoViewDetail.data("XUAT_TT", Request.QueryString["XUAT_TT"]);
        HS_TonKhoViewDetail.data("XUAT_SL2", Request.QueryString["XUAT_SL2"]);
        HS_TonKhoViewDetail.data("XUAT_TT2", Request.QueryString["XUAT_TT2"]);
        HS_TonKhoViewDetail.data("CUOIKY_SL", Request.QueryString["CUOIKY_SL"]);
        HS_TonKhoViewDetail.data("CUOIKY_TT", Request.QueryString["CUOIKY_TT"]);
        HS_TonKhoViewDetail.data("CATENAME", Request.QueryString["CATENAME"]);
        HS_TonKhoViewDetail.data("NHOMTHUOC", Request.QueryString["NHOMTHUOC"]);
        HS_TonKhoViewDetail.data("DES", Request.QueryString["DES"]);
        HS_TonKhoViewDetail.data("IdThuoc", Request.QueryString["IdThuoc"]);
        HS_TonKhoViewDetail.data("CuoiKy_SL1", Request.QueryString["CuoiKy_SL1"]);
        HS_TonKhoViewDetail.data("CUOIKY_TT1", Request.QueryString["CUOIKY_TT1"]);
        HS_TonKhoViewDetail.data("DONGIA1", Request.QueryString["DONGIA1"]);
        HS_TonKhoViewDetail.data("SODK", Request.QueryString["SODK"]);
        HS_TonKhoViewDetail.data("IDNUOCSX_N", Request.QueryString["IDNUOCSX_N"]);
        HS_TonKhoViewDetail.data("isdelete", Request.QueryString["isdelete"]);
        HS_TonKhoViewDetail.data("Isdieuchinh", Request.QueryString["Isdieuchinh"]);

        return HS_TonKhoViewDetail;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveHS_TONKHO_Save(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableHS_TonKhoViewDetail": LuuTableHS_TonKhoViewDetail(); break;
            case "loadTableHS_TonKhoViewDetail": loadTableHS_TonKhoViewDetail(); break;
            case "xoa": XoaHS_TONKHO_Save(); break;
            case "xoaHS_TonKhoViewDetail": XoaHS_TonKhoViewDetail(); break;
            case "IdKhoSearch": IdKhoSearch(); break;
            case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
            case "IdThuocSearch": IdThuocSearch(); break;
            case "IdNuocSX_NSearch": IdNuocSX_NSearch(); break;
            case "XuatExcel": XuatExcel(); break;
            case "DieuChinhKho": DieuChinhKho(); break;
            case "SetDeaultValue": SetDeaultValue(); break;
            case "help": help(); break;
        }
    }
    private void help()
    {
        string html = "";
        html += "<table id='gridTableHelp' class='jtable'>";
        html += "<tr><td style='text-align:left;'>1. Bước 1: Kiểm tra lại thông tin : Kho, từ ngày, đến ngày, đối tượng , Trường hợp muốn điều chỉnh kho nên để từ ngày và đến ngày  là ngày mặc định của hệ thống .</td> </tr>";
        html += "<tr><td style='text-align:left;'>2. Bước 2: Nhất nút \" Tìm kiếm\"  để xác định tồn kho hiện tại. </td></tr>";
        html += "<tr><td style='text-align:left;'>3. Bước 3: Nhấn nút \"Sửa\" </td></tr>";
        html += "<tr><td style='text-align:left;'>4. Bước 4: So sánh số lượng và đơn giá trên phần mềm ( Số lượng SS, Đơn giá SS) với Số lượng thực tế và đơn giá thực tế. Nếu nhận thấy sự khác biệt thì nhập lại vào cột số lượng thực tế hoặc đơn giá thực tế.</td></tr>";
        html += "<tr><td style='text-align:left;'>5. Bước 5: Nhấn nút \"Lưu\"</td></tr>";
        html += "<tr><td style='text-align:left;'>6. Bước 6: Nhấn nút \"Điều chỉnh kho\"</td></tr>";
        html += "<tr><td style='text-align:left;'>7. Bước 7: Nhấn nút Xuất excel : để xuất Exel mẩu biên bản kiểm kê</td></tr>";
        html += "<tr><td style='text-align:left;'>8. Bước 8: Trường hợp muốn điều chỉnh lại một lần nữa , thì phải click bỏ dấu chọn điều chỉnh ở dòng cần điều chỉnh, rồi nhấn nút \"Lưu\" , sau đó nhấn nút \"Điều chỉnh kho\"</td></tr>";
        html += "<tr><td style='text-align:left;'>9. Bước 9: Trường hợp muốn xem lại kết quả điều chỉnh , nhấn nút \"Xóa\" và nhấn nút \"Tìm kiếm\"  : lúc đó cột đơn giá, và số lượng sổ sách đã thay đổi theo số liệu mới, đồng thời: đơn giá và số lượng thực tế lại trở về rỗng</td></tr>";
        html += "</table>";
        Response.Clear();
        Response.Write(html);
    }
    private void IdKhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void LoaiThuocIDSearch()
    {
        StaticData.IdLoaiThuocSearch(this);
    }
    private void IdNuocSX_NSearch()
    {
        string tenDVT = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM nuocsx WHERE tenNuocSX LIKE N'" + tenDVT + "%' ORDER BY tenNuocSX");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenNuocSX"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdThuocSearch()
    {
        string tenthuoc = Request.QueryString["q"];
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string sql = @"SELECT A.*,TenDVT 
                        FROM THUOC A 
                        LEFT JOIN THUOC_DONVITINH B ON A.IDDVT=B.ID
                     WHERE ISTHUOCBV=1";
        if (tenthuoc != null && tenthuoc != "")
            sql += " AND A.TENTHUOC LIKE N'" + tenthuoc + "%'";

        if (LoaiThuocID != null && LoaiThuocID != "")
            sql += " AND A.LOAITHUOCID=" + LoaiThuocID;
        sql += " ORDER BY TENTHUOC";

        DataTable table = DataAcess.Connect.GetTable(sql);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenThuoc"].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i]["IDDVT"].ToString() + "|" + table.Rows[i]["TENDVT"].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaHS_TONKHO_Save()
    {
        try
        {
            DataProcess process = s_HS_TONKHO_Save();
            bool OK1 = DataAcess.Connect.ExecSQL(" DELETE HS_TonKhoViewDetail WHERE IDTONKHO=" + process.getData("IdTonKho"));
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdTonKho"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void XoaHS_TonKhoViewDetail()
    {
        try
        {
            DataProcess process = s_HS_TonKhoViewDetail();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdTonKhoDetail"));
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
        if (StaticData.HavePermision(this, "HS_TONKHO_Save_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = Process_2608.HS_TONKHO_View.dtSearchByIdTonKho(idkhoachinh);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable IdKho = Process.khothuoc.dtSearchByidkho("'" + table.Rows[0]["IdKho"] + "'");
            html.AppendLine("<data id=\"mkv_IdKho\">" + ((IdKho.Rows.Count > 0) ? IdKho.Rows[0]["TENKHO"] : "") + "</data>");
            DataTable LoaiThuocID = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID("'" + table.Rows[0]["LoaiThuocID"] + "'");
            html.AppendLine("<data id=\"mkv_LoaiThuocID\">" + ((LoaiThuocID.Rows.Count > 0) ? LoaiThuocID.Rows[0][1] : "") + "</data>");
            DataTable IdThuoc = Process.thuoc.dtSearchByidthuoc("'" + table.Rows[0]["IdThuoc"] + "'");
            html.AppendLine("<data id=\"mkv_IdThuoc\">" + ((IdThuoc.Rows.Count > 0) ? IdThuoc.Rows[0][1] : "") + "</data>");

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
        if (StaticData.HavePermision(this, "HS_TONKHO_Save_Search"))
        {
            DataProcess process = s_HS_TONKHO_Save();
            string TuNgay = process.getData("TuNgay");
            TuNgay = StaticData.CheckDate(TuNgay);
            string DenNgay = process.getData("DenNgay");


            string sNgayThang = StaticData.CheckDate(DenNgay);
            DateTime saveDate = DateTime.Parse(sNgayThang);
            DateTime Now = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            if (saveDate < Now)
                sNgayThang = sNgayThang + " 23:59:59";
            else
            {
                sNgayThang = sNgayThang + " " + DateTime.Now.ToString("HH:mm:ss");
            }




            DenNgay = sNgayThang;
            string LoaiThuocID = process.getData("LoaiThuocID");
            string IdThuoc = process.getData("IdThuoc");
            string IdKho = process.getData("IdKho");



            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdTonKho),T.*
                   ,A.TenKho
                   ,B.TenLoai
                               from HS_TONKHO_view T
                    left join khothuoc  A on T.IdKho=A.idkho
                    left join Thuoc_LoaiThuoc  B on T.LoaiThuocID=B.LoaiThuocID
                    left join thuoc  C on T.IdThuoc=C.IdThuoc
                    where " + process.sWhere());
            if (table.Rows.Count == 0)
            {
                string sqlMaxTonKho = "SELECT MAX(IdTonKho) FROM HS_TONKHO_View";
                DataTable dtMaxTonKHo = DataAcess.Connect.GetTable(sqlMaxTonKho);
                if (dtMaxTonKHo == null || dtMaxTonKHo.Rows.Count == 0)
                {
                    Response.Write("");
                    Response.StatusCode = 500;
                    return;
                }
                string MaxIdTonKho = dtMaxTonKHo.Rows[0][0].ToString();
                if (MaxIdTonKho == "" || MaxIdTonKho == "0") MaxIdTonKho = "1";
                else
                    MaxIdTonKho = (long.Parse(MaxIdTonKho) + 1).ToString();
                string sqlInsertTonKho = @"INSERT INTO HS_TONKHO_View(IdTonKho
                                                                      ,IdKho
                                                                      ,TuNgay
                                                                      ,DenNgay
                                                                      ,LoaiThuocID
                                                                    )
                                                            VALUES ("
                                                                  + "'" + MaxIdTonKho + "',"
                                                                  + "'" + IdKho + "',"
                                                                  + "'" + TuNgay + "',"
                                                                  + "'" + sNgayThang + "',"
                                                                  + "'" + LoaiThuocID + "'"
                                                                 + ")";
                bool ok1 = DataAcess.Connect.ExecSQL(sqlInsertTonKho);
                process.data("IdTonKho", MaxIdTonKho);

                table = process.Search(@"select STT=row_number() over (order by T.IdTonKho),T.*
                   ,A.TenKho
                   ,B.TenLoai
                               from HS_TONKHO_View T
                    left join khothuoc  A on T.IdKho=A.idkho
                    left join Thuoc_LoaiThuoc  B on T.LoaiThuocID=B.LoaiThuocID
                    left join thuoc  C on T.IdThuoc=C.IdThuoc
                    where " + process.sWhere());
            }
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["IdTonKho"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["TenKho"].ToString() + "</td>");
                        if (table.Rows[i]["TuNgay"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["TuNgay"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["TuNgay"].ToString() + "</td>"); }
                        if (table.Rows[i]["DenNgay"].ToString() != "")
                        {
                            html.Append("<td>" + DateTime.Parse(table.Rows[i]["DenNgay"].ToString()).ToString("dd/MM/yyyy") + "</td>");
                        }
                        else { html.Append("<td>" + table.Rows[i]["DenNgay"].ToString() + "</td>"); }
                        html.Append("<td>" + table.Rows[i]["TenLoai"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["TenThuoc"].ToString() + "</td>");
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
    private void SaveHS_TONKHO_Save()
    {
        try
        {
            DataProcess process = s_HS_TONKHO_Save();
            if (process.getData("IdTonKho") != null && process.getData("IdTonKho") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdTonKho"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdTonKho"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableHS_TonKhoViewDetail()
    {
        try
        {
            DataProcess process = s_HS_TonKhoViewDetail();
            if (process.getData("IdTonKhoDetail") != null && process.getData("IdTonKhoDetail") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdTonKhoDetail"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdTonKhoDetail"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableHS_TonKhoViewDetail()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th >" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc") + "</th>");
        html.Append("<th >" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENDVT") + "</th>");
        //html.Append("<th style='width:50px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số ĐK") + "</th>");
        //html.Append("<th style='width:90px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoSanXuat") + "</th>");
        //html.Append("<th style='width:90px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngayhethan") + "</th>");
        //html.Append("<th style='width:90px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nước SX") + "</th>");
        html.Append("<th >" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL tồn\r\nS.S") + "</th>");
        html.Append("<th >" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL tồn\r\nthực") + "</th>");
        //html.Append("<th style='width:70px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đơn giá\r\nS.S") + "</th>");
        //html.Append("<th style='width:70px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đơn giá\r\nthực") + "</th>");
        ////html.Append("<th style='width:70px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Delete") + "<input type='checkbox' id='chkAllDelete' onclick='checkAllDelete(this);' /></th>");
        html.Append("<th style='width:70px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đ.Chỉnh?") + "<input type='checkbox' id='chkAllDieuChinh' onclick='checkAllDieuChinh(this);' /></th>");
        html.Append("<th></th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "HS_TonKhoViewDetail_Add");
        bool search = StaticData.HavePermision(this, "HS_TonKhoViewDetail_Search");
        bool update_sodk = Userlogin_new.HavePermision(this, "update_sodk");
        bool update_losx = Userlogin_new.HavePermision(this, "update_losx");
        bool update_ngayhethan = Userlogin_new.HavePermision(this, "update_ngayhethan");
        if (search)
        {
            DataProcess process = s_HS_TonKhoViewDetail();
            process.Page = Request.QueryString["page"];
            string sqlSelect = @"select STT=row_number() over (order by  tensp),T.*,mkv_IdThuoc=TenSP
                               from HS_TonKhoViewDetail T
                            where T.IdTonKho='" + process.getData("IdTonKho") + "'";
            DataTable table = process.Search(sqlSelect);
            if (table.Rows.Count == 0)
            {
                string TuNgay=Request.QueryString["TuNgay"];
                string DenNgay=Request.QueryString["DenNgay"];
                string IdKho=Request.QueryString["IdKho"];
                string LoaiThuocID=Request.QueryString["LoaiThuocID"];
                string IdThuoc = null;
                if (IdKho == null || IdKho == "") return;
                if (TuNgay == null || TuNgay == "") return;
                if (DenNgay == null || DenNgay == "") return;
                if (LoaiThuocID == null || LoaiThuocID == "") return;

                profess_Rpt_nhapxuatton PROF=new profess_Rpt_nhapxuatton();
                PROF.FromDate=StaticData.CheckDate( TuNgay);
                PROF.ToDate=StaticData.CheckDate( DenNgay);
                PROF.IdKho=IdKho;
                PROF.IdThuoc=IdThuoc;
                PROF.LoaiThuocID = LoaiThuocID;
                table = PROF.getViewTable();

                table.Columns.Add("IdTonKho");
                table.Columns.Add("IdTonKhoDetail");
                table.Columns.Add("CuoiKy_SL1");
                table.Columns.Add("Isdieuchinh",(1==1).GetType());
                table.DefaultView.RowFilter = "";
                table.DefaultView.Sort = "TENSP";
                table = table.DefaultView.ToTable();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["IdTonKho"] = process.getData("IdTonKho");
                    table.Rows[i]["STT"] = i + 1;
                }
            }
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("HS_TonKhoViewDetail");
                bool delete = StaticData.HavePermision(this, "HS_TonKhoViewDetail_Delete");
                bool edit = StaticData.HavePermision(this, "HS_TonKhoViewDetail_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value='" + table.Rows[i]["IdThuoc"] + "'/><input mkv='true' id='mkv_IdThuoc' type='text' value='" + table.Rows[i]["tensp"].ToString() + "'  onblur='CheckExistThuoc(this);' onfocus='IdThuocSearch(this);'    class=\"down_select\" " + (1 == 1 ? "disabled" : "") + "   style='width:500px;'  /></td>");
                    html.Append("<td><input mkv='true' id='TENDVT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TENDVT"].ToString() + "' " + (1 == 1 ? "disabled" : "") + "  style='width:50px' /></td>");
                    //html.Append("<td><input mkv='true' id='SoDK' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoDK"].ToString() + "' " + ((!update_sodk && !update_losx && !update_ngayhethan) ? "disabled" : "") + " style='width:90px'/></td>");
                    //html.Append("<td><input mkv='true' id='LoSanXuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["LoSanXuat"].ToString() + "' " + ((!update_sodk && !update_losx && !update_ngayhethan) ? "disabled" : "") + " style='width:90px'/></td>");
                    //html.Append("<td><input mkv='true' id='Ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["Ngayhethan"].ToString() + "' " + ((!update_sodk && !update_losx && !update_ngayhethan) ? "disabled" : "") + " style='width:90px'/></td>");
                    //html.Append("<td><input mkv='true' id='IdNuocSX_N' type='hidden' value='" + table.Rows[i]["IdNuocSX_N"] + "'/><input mkv='true' id='mkv_IdNuocSX_N' type='text' value='" + table.Rows[i]["TenNuocSX"].ToString() + "' onfocus='IdNuocSX_NSearch(this);'    class=\"down_select\" " + (1 == 1 ? "disabled" : "") + "   style='width:70px'  /></td>");
                    html.Append("<td><input mkv='true' id='CUOIKY_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["CUOIKY_SL"].ToString() + "' onblur='TestSo(this,false,false);' " + (1 == 1 ? "disabled" : "") + " style='width:40px'/></td>");
                    html.Append("<td><input mkv='true' id='CuoiKy_SL1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["CuoiKy_SL1"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:40px'/></td>");
                    //html.Append("<td><input mkv='true' id='DONGIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DONGIA"].ToString() + "' onblur='TestSo(this,false,false);' " + (1 == 1 ? "disabled" : "") + " style='width:70px'/></td>");
                    //html.Append("<td><input mkv='true' id='DONGIA1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DONGIA1"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:70px'/></td>");
                    ////html.Append("<td align='center'><input mkv='true' id='isdelete' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["isdelete"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td align='center'><input mkv='true' id='Isdieuchinh' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["Isdieuchinh"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["IdTonKhoDetail"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value=''/><input mkv='true' id='mkv_IdThuoc' type='text' value='' onfocus='IdThuocSearch(this);'   onblur='CheckExistThuoc(this);'  class=\"down_select\"   style='width:500px' /></td>");
            html.Append("<td><input mkv='true' id='TENDVT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:50px'/></td>");
            //html.Append("<td><input mkv='true' id='SoDK' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:90px'/></td>");
            //html.Append("<td><input mkv='true' id='LoSanXuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:90px'/></td>");
            //html.Append("<td><input mkv='true' id='Ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)' style='width:90px'/></td>");
            //html.Append("<td><input mkv='true' id='IdNuocSX_N' type='hidden' value=''/><input mkv='true' id='mkv_IdNuocSX_N' type='text' value='' onfocus='IdNuocSX_NSearch(this);'   class=\"down_select\"   style='width:70px' /></td>");
            html.Append("<td><input mkv='true' id='CUOIKY_SL' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled value='' onblur='TestSo(this,false,false);'  style='width:40px'/></td>");
            html.Append("<td><input mkv='true' id='CuoiKy_SL1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:40px'/></td>");
            //html.Append("<td><input mkv='true' id='DONGIA' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled value='' onblur='TestSo(this,false,false);'  style='width:70px'/></td>");
            //html.Append("<td><input mkv='true' id='DONGIA1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'  style='width:70px'/></td>");
            //html.Append("<td align='center'><input mkv='true' id='isdelete' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>");
            html.Append("<td align='center'><input mkv='true' id='Isdieuchinh' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }//END VOID
    Profess_rpt_BienBanKiemKe NXTReport = null;
    private void XuatExcel()
    {
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string mkv_LoaiThuocID = Request.QueryString["mkv_LoaiThuocID"];
        string tungay = Request.QueryString["TuNgay"];
        string denngay = Request.QueryString["DenNgay"];
        string IdKho = Request.QueryString["IdKho"];
        string IdTonKho = Request.QueryString["IdTonKho"];
        NXTReport = new Profess_rpt_BienBanKiemKe();
        NXTReport.LoaiThuocID = LoaiThuocID;
        NXTReport.TenLoaiThuoc = mkv_LoaiThuocID;
        NXTReport.IdKho = IdKho;
        NXTReport.FromDate = StaticData.CheckDate(tungay);
        NXTReport.ToDate = StaticData.CheckDate(denngay);
        NXTReport.IdTonKho = IdTonKho;
        NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        NXTReport.ExportToExcel();

    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void DieuChinhKho()
    {
        string IdTonKho = Request.QueryString["IdTonKho"];
        if (IdTonKho == null || IdTonKho == "") return;
        string IdKho = null;
        string TuNgay = null;
        string DenNgay = null;
        string LoaiThuocID = null;
        string sqlTonKho = @"
			            SELECT IDKHO,DENNGAY,LOAITHUOCID,TUNGAY
			            FROM HS_TONKHO_View
			            where idtonkho=" + IdTonKho;
        DataTable dtTonKho = DataAcess.Connect.GetTable(sqlTonKho);
        if (dtTonKho == null || dtTonKho.Rows.Count == 0) return;
        DenNgay = dtTonKho.Rows[0]["DenNgay"].ToString();
        DenNgay = DateTime.Parse(DenNgay).ToString("yyyy-MM-dd");
        string sNgayThang = DenNgay;
        DateTime saveDate = DateTime.Parse(sNgayThang);
        DateTime Now = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
        string DenNgay_Save = "";
        if (saveDate < Now)
        {
            DenNgay_Save = sNgayThang + " 23:58:00";
            sNgayThang = sNgayThang + " 23:59:59";
        }
        else
        {
            sNgayThang = sNgayThang += " " + DateTime.Now.ToString("HH:mm:ss");
            DenNgay_Save = sNgayThang;
        }
        DenNgay = sNgayThang;



        IdKho = dtTonKho.Rows[0]["idkho"].ToString();
        TuNgay = dtTonKho.Rows[0]["TuNgay"].ToString();
        LoaiThuocID = dtTonKho.Rows[0]["LoaiThuocID"].ToString();
        string sqlDetail = @" SELECT  A.IDTHUOC
                                        ,CUOIKY_SL
                                        ,CUOIKY_SL1
                                        ,B.IDDVT
                                        ,IdTonKhoDetail
                                        ,IsDelete
							    FROM HS_TonKhoViewDetail A 
								LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
								WHERE IDTONKHO=" + IdTonKho + @"
								 	  and isnull(IsDieuChinh,0)=0";
        DataTable dtDetail = DataAcess.Connect.GetTable(sqlDetail);
        if (dtDetail == null) return;

        string IdPhieuNhap = null;
        string IdPhieuXuat = null;

        for (int i = 0; i < dtDetail.Rows.Count; i++)
        {
            string IDTHUOC = dtDetail.Rows[i]["IDTHUOC"].ToString();
            string CUOIKY_SL = dtDetail.Rows[i]["CUOIKY_SL"].ToString();
            string CUOIKY_SL1 = dtDetail.Rows[i]["CUOIKY_SL1"].ToString();
            string IDDVT = dtDetail.Rows[i]["IDDVT"].ToString();
            string IdTonKhoDetail = dtDetail.Rows[i]["IdTonKhoDetail"].ToString();
            string IsDelete = dtDetail.Rows[i]["IsDelete"].ToString();
                if (CUOIKY_SL == "") CUOIKY_SL = "0";
                if (CUOIKY_SL != "0" && CUOIKY_SL1 == "") CUOIKY_SL1 = CUOIKY_SL;
                if (CUOIKY_SL1 == "") CUOIKY_SL1 = "0";
                #region Nếu số lượng SS < Số lượng thực tế
                if (double.Parse(CUOIKY_SL1) > double.Parse(CUOIKY_SL))
                {
                    #region Trường hợp IdPhieuNhap =null
                    if (IdPhieuNhap == null)
                    {
                        string sqlPhieuNhap_Ins = @"SELECT TOP 1 IDPHIEUNHAP FROM PHIEUNHAPKHO WHERE MAPHIEUNHAP LIKE 'DC%' AND IDLOAINHAP=5 AND IDKHO=" + IdKho + " AND NGAYTHANG='" + DenNgay_Save + "'";
                        DataTable dtPhieuNhap_Ins = DataAcess.Connect.GetTable(sqlPhieuNhap_Ins);
                        if (dtPhieuNhap_Ins == null) return;
                        if (dtPhieuNhap_Ins.Rows.Count == 0)
                        {
                            string sqlInsertPhieuNhap_Ins = @" INSERT INTO PHIEUNHAPKHO(IDKHO,NGAYTHANG,IDLOAINHAP,GHICHU,MAPHIEUNHAP) 
					                                            VALUES
						                                            ( 
                                                                         " + IdKho + ",'" + DenNgay_Save + @"',5,N'Điều chỉnh tự động','DC'+convert(nvarchar(20),'" + DenNgay_Save + @"',103)
						                                            )";
                            bool Ok_InsertPhieuNhap_IS = DataAcess.Connect.ExecSQL(sqlInsertPhieuNhap_Ins);
                            if (!Ok_InsertPhieuNhap_IS) return;
                            sqlPhieuNhap_Ins = @"SELECT TOP 1 IDPHIEUNHAP FROM PHIEUNHAPKHO WHERE MAPHIEUNHAP LIKE 'DC%' AND IDLOAINHAP=5 AND IDKHO=" + IdKho + " AND NGAYTHANG='" + DenNgay_Save + "'";
                            dtPhieuNhap_Ins = DataAcess.Connect.GetTable(sqlPhieuNhap_Ins);
                            if (dtPhieuNhap_Ins.Rows.Count == 0)
                            {
                                return;
                            }

                        }
                        IdPhieuNhap = dtPhieuNhap_Ins.Rows[0][0].ToString();

                    }
                    #endregion
                    #region Insert ChiTietPhieuNhapKho
                    double SoLuong_Nhap = double.Parse(CUOIKY_SL1) - double.Parse(CUOIKY_SL);
                    string IdNuocSX_N = "";
                    string LoSanXuat = "";
                    string NGAYHETHAN = "";
                    string DONGIA1 = "";
                    string VAT = "";
                    double ThanhTien_TT = 0;
                    double ThanhTien_ST = 0;
                    string sqlSelect_ADD = @"SELECT TOP 1 IdNuocSX_N,LoSanXuat,NGAYHETHAN,DONGIA,VAT
                                     FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP=" + IdKho
                                     + " AND IDTHUOC=" + IDTHUOC
                                     + " ORDER BY NGAYTHANG_NHAP DESC ";
                    DataTable dt_add = DataAcess.Connect.GetTable(sqlSelect_ADD);
                    if (dt_add != null && dt_add.Rows.Count == 0)
                    {
                        sqlSelect_ADD = @"SELECT TOP 1 IdNuocSX_N,LoSanXuat,NGAYHETHAN,DONGIA,VAT
                                     FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP=" + StaticData.MacDinhKhoNhapMuaID
                                     + " AND IDTHUOC=" + IDTHUOC
                                     + " ORDER BY NGAYTHANG_NHAP DESC ";
                        dt_add = DataAcess.Connect.GetTable(sqlSelect_ADD);

                    }
                    if (dt_add != null && dt_add.Rows.Count > 0)
                    {
                        IdNuocSX_N = dt_add.Rows[0]["IdNuocSX_N"].ToString();
                        LoSanXuat = dt_add.Rows[0]["LoSanXuat"].ToString();
                        NGAYHETHAN =StaticData.CheckDate(dt_add.Rows[0]["NGAYHETHAN"].ToString());
                        DONGIA1 = dt_add.Rows[0]["DONGIA"].ToString();
                        VAT = dt_add.Rows[0]["VAT"].ToString();
                        if (DONGIA1 == "") DONGIA1 = "0";
                        if (VAT == "") VAT = "0";
                        ThanhTien_TT = SoLuong_Nhap * double.Parse(DONGIA1);
                        ThanhTien_ST =Math.Round( SoLuong_Nhap * double.Parse(DONGIA1)*(100.0+double.Parse(VAT))/100,0);
                    }
                    if (VAT == "") VAT = "0";
                    if (DONGIA1 == "") DONGIA1 = "0";
                    VAT = VAT.Replace(",", ".");
                    DONGIA1 = DONGIA1.Replace(",", ".");

                    
                    string sqlInsertChiTietPN = @"			 
												INSERT INTO CHITIETPHIEUNHAPKHO (IDPHIEUNHAP
                                                                                ,IDTHUOC
                                                                                ,DVT
                                                                                ,SOLUONG
                                                                                ,DONGIA
                                                                                ,VAT
                                                                                ,THANHTIENTRUOCTHUE
                                                                                ,THANHTIEN
                                                                                ,IdNuocSX_N
                                                                                ,LoSanXuat
                                                                                ,Ngayhethan
                                                                               )
													  VALUES(";
                    sqlInsertChiTietPN += "\r\n" + IdPhieuNhap + "" + "\r\n"
                                                          + "," + IDTHUOC + "\r\n"
                                                          + "," + IDDVT + "\r\n"
                                                          + "," + SoLuong_Nhap.ToString() + "\r\n"
                                                          + "," + DONGIA1 + "\r\n"
                                                          + "," + VAT + "\r\n"
                                                          + "," + ThanhTien_TT.ToString().Replace(",",".") + "\r\n"
                                                          + "," + ThanhTien_ST.ToString().Replace(",", ".") + "\r\n"
                                                          + "," + (IdNuocSX_N != "" && IdNuocSX_N != "0" ? IdNuocSX_N : "NULL") + "\r\n"
                                                          + ",'" + LoSanXuat + "'\r\n"
                                                          + "," + "'" + NGAYHETHAN + "'" + "\r\n"
                                                      + ")";
                    bool ok_InsertChiTietPhieuNHAPKho = DataAcess.Connect.ExecSQL(sqlInsertChiTietPN);
                    if (!ok_InsertChiTietPhieuNHAPKho) return;
                    #endregion
                    CUOIKY_SL = CUOIKY_SL1;
                }
                #endregion
                #region Nếu số lượng > Số lượng thực tế
                if (double.Parse(CUOIKY_SL1) < double.Parse(CUOIKY_SL))
                {
                    #region Trường hợp IdPhieuXuat =null
                    if (IdPhieuXuat == null)
                    {
                        string sqlPhieuXuat_Ins = @"SELECT TOP 1 IDPHIEUXuat FROM PHIEUXuatKHO WHERE GHICHU LIKE N'Điều chỉnh tự động' AND LOAIXuat=5 AND IDKHO=" + IdKho + " AND NGAYTHANG='" + DenNgay_Save + "'";
                        DataTable dtPhieuXuat_Ins = DataAcess.Connect.GetTable(sqlPhieuXuat_Ins);
                        if (dtPhieuXuat_Ins == null) return;
                        if (dtPhieuXuat_Ins.Rows.Count == 0)
                        {
                            string sqlInsertPhieuXuat_Ins = @" INSERT INTO PHIEUXuatKHO(IDKHO,NGAYTHANG,LOAIXuat,GHICHU,MAPHIEUXuat) 
					                                            VALUES
						                                            ( 
                                                                        " + IdKho + ",'" + DenNgay_Save + @"',5,N'Điều chỉnh tự động','DC'+convert(nvarchar(20),'" + DenNgay_Save + @"',103)
						                                            )";
                            bool Ok_InsertPhieuXuat_IS = DataAcess.Connect.ExecSQL(sqlInsertPhieuXuat_Ins);
                            if (!Ok_InsertPhieuXuat_IS) return;
                            sqlPhieuXuat_Ins = @"SELECT TOP 1 IDPHIEUXuat FROM PHIEUXuatKHO WHERE GHICHU LIKE N'Điều chỉnh tự động' AND LOAIXuat=5 AND IDKHO=" + IdKho + " AND NGAYTHANG='" + DenNgay_Save + "'";
                            dtPhieuXuat_Ins = DataAcess.Connect.GetTable(sqlPhieuXuat_Ins);
                            if (dtPhieuXuat_Ins.Rows.Count == 0)
                            {
                                return;
                            }

                        }
                        IdPhieuXuat = dtPhieuXuat_Ins.Rows[0][0].ToString();

                    }
                    #endregion
                    #region Insert ChiTietPhieuXuatKho
                    double SoLuong_Xuat = double.Parse(CUOIKY_SL) - double.Parse(CUOIKY_SL1);
                    //double ThanhTien_Xuat = SoLuong_Xuat * double.Parse(DONGIA1);
                    string sqlInsertChiTietPX = @"	
												EXEC Thuoc_XuatThuoc_Automatic_all	" + IDTHUOC
                                                                    + ",'" + DenNgay_Save + "'"
                                                                    + "," + SoLuong_Xuat
                                                                    + "," + IdKho
                                                                    + "," + IdPhieuXuat + @"
																	,NULL
																	,NULL
																	,NULL
																	,NULL
                                                                    ,1,0";

                    bool ok_InsertChiTietPhieuXuatKho = DataAcess.Connect.ExecSQL(sqlInsertChiTietPX);
                    if (!ok_InsertChiTietPhieuXuatKho) return;
                    #endregion
                    CUOIKY_SL = CUOIKY_SL1;
                }
                #endregion
                #region Update After
                string sqlUpdateAfter = " UPDATE HS_TonKhoViewDetail SET CUOIKY_SL=" + CUOIKY_SL + ", CUOIKY_SL1=" + CUOIKY_SL1
                                                                       + ", ISDIEUCHINH=" + "1"
                                                                       + " WHERE IdTonKhoDetail=" + IdTonKhoDetail;
                bool okUpdateAfter = DataAcess.Connect.ExecSQL(sqlUpdateAfter);
                if (!okUpdateAfter)
                {
                    return;
                }
                #endregion
        }
        Response.Clear();
        Response.Write("Đã điều chỉnh kho.");
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void SetDeaultValue()
    {
        StaticData.SetDefaultIdKho(this, null, null, null, null, true);
    }
}//END CLASS



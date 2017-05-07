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

public partial class phieuxuatkho_ajax3 : System.Web.UI.Page
{
    protected DataProcess s_phieuxuatkho()
    {
        DataProcess phieuxuatkho = new DataProcess("phieuxuatkho");
        phieuxuatkho.data("idphieuxuat", Request.QueryString["idkhoachinh"]);
        phieuxuatkho.data("maphieuxuat", Request.QueryString["maphieuxuat"]);
        phieuxuatkho.data("ngaythang", Request.QueryString["ngaythang"]);
        phieuxuatkho.data("ghichu", Request.QueryString["mkv_ghichu"]);
        phieuxuatkho.data("nguoinhan", Request.QueryString["nguoinhan"]);
        phieuxuatkho.data("xuatcho", Request.QueryString["xuatcho"]);
        phieuxuatkho.data("idkho", Request.QueryString["idkho"]);
        phieuxuatkho.data("loaixuat", "4");
        phieuxuatkho.data("IDKhachHang", Request.QueryString["IDKhachHang"]);
        phieuxuatkho.data("vat", Request.QueryString["vat"]);
        phieuxuatkho.data("thanhtien", Request.QueryString["thanhtien"]);
        phieuxuatkho.data("idkho2", Request.QueryString["idkho2"]);
        phieuxuatkho.data("idnguoixuat", Request.QueryString["idnguoixuat"]);
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
            case "setIdKho": setIdKho(); break;
            case "idkho2Search": idkho2Search(); break;
            case "PrintBienBan": PrintBienBan(); break;
            
            case "ghichuSearch": ghichuSearch(); break;
        }
    }
    
    private void setIdKho()
    {
        StaticData.SetDefaultIdKho(this, "idkho", "mkv_idkho", "IdLoaiThuoc", "mkv_IdLoaiThuoc");
    }
    private void PrevInfo()
    {
        string sqlSelect = @" select top 1  a.idkho,tenkho1=B.tenkho, a.idkho2,tenkho2=C.tenkho
                                ,A.IDLOAITHUOC,D.TENLOAI,GIO=RIGHT( CONVERT(VARCHAR(13),A.NGAYTHANG,120),2),PHUT=RIGHT( CONVERT(VARCHAR(16),A.NGAYTHANG,120),2)
                                from phieuxuatkho A
                                 LEFT JOIN KHOTHUOC B ON A.IDKHO=B.IDKHO
                                 LEFT JOIN KHOTHUOC C ON A.IDKHO2=C.IDKHO
                                 LEFT JOIN THUOC_LOAITHUOC D ON A.IDLOAITHUOC=D.LOAITHUOCID
                                where loaixuat=4 order by  idphieuxuat desc";
        DataTable dtPrevInfo = DataAcess.Connect.GetTable(sqlSelect);
        if (dtPrevInfo == null || dtPrevInfo.Rows.Count == 0) return;
        Response.Write(dtPrevInfo.Rows[0]["idkho"].ToString() 
            + "|" + dtPrevInfo.Rows[0]["tenkho1"].ToString() 
            + "| " + dtPrevInfo.Rows[0]["idkho2"].ToString() 
            + "|" + dtPrevInfo.Rows[0]["tenkho2"].ToString() 
            + "| " + dtPrevInfo.Rows[0]["IDLOAITHUOC"].ToString() 
            + "|" + dtPrevInfo.Rows[0]["TENLOAI"].ToString()
            + "|" + dtPrevInfo.Rows[0]["Gio"].ToString()
            + "|" + dtPrevInfo.Rows[0]["Phut"].ToString()
            );

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
    private void ghichuSearch()
    {

        string IdKhoClause = "";
        string tenkho = this.Request.QueryString["q"];
        if (tenkho != null && tenkho != "")
            IdKhoClause += " AND GHICHU LIKE N'%" + tenkho + "%'";
        string sqlSelect = "SELECT DISTINCT ghichu FROM PHIEUXUATKHO WHERE LOAIXUAT=4"+IdKhoClause;
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["GHICHU"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        this.Response.Clear(); this.Response.Write(html);
    }
    private void idkhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void idkho2Search()
    {

        string IdKhoClause = "";
        string tenkho = this.Request.QueryString["q"];
        if (tenkho != null && tenkho != "")
            IdKhoClause += " AND TENKHO LIKE N'" + tenkho + "%'";
        string sqlSelect = "SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 " + IdKhoClause + " ORDER BY TENKHO";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TENKHO"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        this.Response.Clear(); this.Response.Write(html);
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

            string sqlDeleteOldChiTietPhieuXuatKho = "DELETE CHITIETPHIEUXUATKHO WHERE idphieuxuat=" + process.getData("idphieuxuat");
            bool ok1 = DataAcess.Connect.ExecSQL(sqlDeleteOldChiTietPhieuXuatKho);
            if (!ok1)
            {
                Response.StatusCode = 500;
            }

            string sqlDeleteOldHS_OUTPUTDETAIL = "DELETE HS_OUTPUTDETAIL WHERE idphieuxuat=" + process.getData("idphieuxuat");
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
            else
            {
                Response.StatusCode = 500;
                return;
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    private void setTimKiem()
    {
        if (Userlogin_new.HavePermision(this, "phieuxuatkho_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataAcess.Connect.GetTable("SELECT *,mkv_ghichu=ghichu,SoPhieuYCTra=(SELECT TOP 1 SOPHIEUYC FROM YC_PHIEUYCTRA WHERE IDPHIEUYC=PHIEUXUATKHO.IDPHIEUYCTRA) FROM PHIEUXUATKHO WHERE IDPHIEUXUAT=" + idkhoachinh);
            if (table == null || table.Rows.Count == 0) return;
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable idkho = Thuoc_Process.khothuoc.dtSearchByidkho("'" + table.Rows[0]["idkho"] + "'");
            html.AppendLine("<data id=\"mkv_idkho\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0]["tenkho"] : "") + "</data>");
            string LoaiThuocID = table.Rows[0]["IdLoaiThuoc"].ToString();
            string TenLoaiThuoc = null;
            if (LoaiThuocID == "")
            {
                string sqlLoaiThuoc = @"SELECT TOP 1 B.LOAITHUOCID ,B.IsTHTT,B.IsTGN
                                         FROM CHITIETPHIEUXUATKHO A
                                        LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
                                        WHERE A.IDPHIEUXUAT=" + idkhoachinh;
                DataTable dtTemp = DataAcess.Connect.GetTable(sqlLoaiThuoc);
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    LoaiThuocID = dtTemp.Rows[0][0].ToString();
                    table.Rows[0]["IdLoaiThuoc"] = LoaiThuocID;
                    if (LoaiThuocID == "1")
                    {
                        if (StaticData.IsCheck(dtTemp.Rows[0]["IsTHTT"].ToString()))
                            TenLoaiThuoc = "Thuốc H.tâm thần";
                        if (StaticData.IsCheck(dtTemp.Rows[0]["IsTGN"].ToString()))
                            TenLoaiThuoc = "Thuốc gây nghiện";
                    }
                }

            }

            html.AppendLine("<data id=\"gio\">" + string.Format("{0:HH}", table.Rows[0]["ngaythang"]) + "</data>");
            html.AppendLine("<data id=\"phut\">" + string.Format("{0:mm}", table.Rows[0]["ngaythang"]) + "</data>");


            DataTable IdLoaiThuoc = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID("'" + table.Rows[0]["IdLoaiThuoc"] + "'");
            DataTable idkho2 = Thuoc_Process.khothuoc.dtSearchByidkho("'" + table.Rows[0]["idkho2"] + "'");
            html.AppendLine("<data id=\"mkv_idkho2\">" + ((idkho2.Rows.Count > 0) ? idkho2.Rows[0]["tenkho"] : "") + "</data>");
            if (TenLoaiThuoc == null)
                html.AppendLine("<data id=\"mkv_IdLoaiThuoc\">" + ((IdLoaiThuoc.Rows.Count > 0) ? IdLoaiThuoc.Rows[0][1] : "") + "</data>");
            else
                html.AppendLine("<data id=\"mkv_IdLoaiThuoc\">" + TenLoaiThuoc + "</data>");

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    //html.AppendLine("<data id='mkv_ghichu'>" + table.Rows[0]["ghichu"].ToString() + "</data>");
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
        if (Userlogin_new.HavePermision(this, "phieuxuatkho_Search"))
        {
            DataProcess process = s_phieuxuatkho();
            process.Page = Request.QueryString["page"];
            string sql = @"select STT=row_number() over (order by T.idphieuxuat),T.*
                   ,A.tenkho as kho1
                   ,B.MaLoai
                   ,tenloaixuat
                   ,D.TENKHO AS kho2
                 from phieuxuatkho T
                    left join khothuoc  A on T.idkho=A.idkho
                    left join Thuoc_LoaiThuoc  B on T.IdLoaiThuoc=B.LoaiThuocID
                    left join thuoc_loaixuat c on t.loaixuat=c.idloaixuat
                    left join KHOTHUOC D ON T.IDKHO2=D.IDKHO
                where " + process.sWhere();
            DataTable table = process.Search(sql);
            if (table == null || table.Rows.Count == 0) return;
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaixuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho2") + "</th>");
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
                        html.Append("<td>" + table.Rows[i]["kho1"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tenloaixuat"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["kho2"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["MaLoai"].ToString() + "</td>");
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

            
           
            process.data("loaixuat", "4");
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
                string gio = Request.QueryString["gio"];
                string phut = Request.QueryString["phut"];
                if ((gio == null || gio == "") && (phut == null || phut == ""))
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
                else
                    NgayThang = NgayThang + " " + gio + ":" + phut +":00";

             
            }
            #endregion
            #region Trường hợp Insert
            else
            {
                 string gio = Request.QueryString["gio"];
                string phut = Request.QueryString["phut"];
                if ((gio == null || gio == "") && (phut == null || phut == ""))
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
                else
                    NgayThang = NgayThang + " " + gio + ":" + phut + ":00";

            }
            #endregion
            process.data("ngaythang", NgayThang);
            #endregion
            if (process.getData("idphieuxuat") != null && process.getData("idphieuxuat") != "")
            {
                 if(DateTime.Parse( StaticData.CheckDate(NgayThang)).ToString("yyyy-MM-dd")!=DateTime.Parse( StaticData.CheckDate(NgayThang_Prev)).ToString("yyyy-MM-dd"))
                 {
                     string sqlDelete1="DELETE HS_MAPHIEUXUAT WHERE MAPHIEUXUAT='"+MaPhieuXuat_Prev+"'";
                     bool ok_delete1 = DataAcess.Connect.ExecSQL(sqlDelete1);
                     if (MaPhieuXuat != null || MaPhieuXuat != "")
                     {
                         string MaPhieuXuat_s = MaPhieuXuat.Substring(0, "PXKD130417".Length).Remove(0,4);
                         if (MaPhieuXuat_s.Length == 6)
                         {
                             if (DateTime.Parse( StaticData.CheckDate(NgayThang)).ToString("yyMMdd") != MaPhieuXuat_s)
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
                        DataTable dtTest = DataAcess.Connect.GetTable("SELECT * FROM PHIEUXUATKHO WHERE  IDPHIEUXUAT<>" + process.getData("idphieuxuat") + " AND  MAPHIEUXUAT='" + MaPhieuXuat + "'");
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
                string IdKho2_Prev = Request.QueryString["IdKho2_Prev"];

                

                string IdKho = Request.QueryString["IdKho"];
                string NgayThang = Request.QueryString["NgayThang"];
                string IdKho2 = Request.QueryString["IdKho2"];

                if (IdKho_Prev == null || IdKho_Prev == "") IdKho_Prev = IdKho;
                if (NgayThang_Prev == null || NgayThang_Prev == "") NgayThang_Prev = NgayThang;
                if (IdKho2_Prev == null || IdKho2_Prev == "") IdKho2_Prev = IdKho2;

                 string Gio = Request.QueryString["Gio"];
                string Gio_Prev = Request.QueryString["Gio_Prev"];
                string Phut = Request.QueryString["Phut"];
                string Phut_Prev = Request.QueryString["Phut_Prev"];
                 



                bool IsChange1 = false;
                if (IdKho_Prev != IdKho
                   || DateTime.Parse(StaticData.CheckDate(NgayThang_Prev)).ToString("yyyy-MM-dd") != DateTime.Parse(StaticData.CheckDate(NgayThang)).ToString("yyyy-MM-dd")
                   ||Gio!=Gio_Prev
                   ||Phut!=Phut_Prev
                   || IdKho2_Prev != IdKho2)
                    IsChange1 = true;

                string sqlSelect = "SELECT * FROM HS_OUTPUTDETAIL WHERE OutPutDetailID=" + process.getData("OutPutDetailID");
                DataTable dtTest = DataAcess.Connect.GetTable(sqlSelect);
                if (dtTest != null && dtTest.Rows.Count > 0)
                {
                    string Idthuoc_old = dtTest.Rows[0]["IdThuoc"].ToString();
                    string Quantity_old = dtTest.Rows[0]["Quantity"].ToString();
                    string IdThuoc_new = process.getData("idthuoc");
                    string Quantity_new = process.getData("quantity");
                    if (IdThuoc_new != Idthuoc_old || Quantity_new != Quantity_old ||IsChange1)
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
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã thuốc /vtyt") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("UnitID") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Quantity") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Note") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SLTON") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");

        string IDPHIEUYC = Request.QueryString["IDPHIEUYC"];
        string IDPHIEUYCTRA = Request.QueryString["IDPHIEUYCTRA"];


        bool add = Userlogin_new.HavePermision(this, "HS_OutPutDetail_Add");
        bool search = Userlogin_new.HavePermision(this, "HS_OutPutDetail_Search");
        if (search)
        {
            DataProcess process = s_HS_OutPutDetail();
            process.Page = Request.QueryString["page"];
            DataTable table = nvk_tableChiTietXuat(process.getData("IdPhieuXuat"));
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("HS_OutPutDetail");
                bool delete = Userlogin_new.HavePermision(this, "HS_OutPutDetail_Delete");
                bool edit = Userlogin_new.HavePermision(this, "HS_OutPutDetail_Edit");
                if (IDPHIEUYC != null && IDPHIEUYC != "" && IDPHIEUYC != "0" && IDPHIEUYC != "null")
                {
                    edit = delete =add= false;
                }
                if (IDPHIEUYCTRA != null && IDPHIEUYCTRA != "" && IDPHIEUYCTRA != "0" && IDPHIEUYCTRA != "null")
                {
                    edit = delete =add= false;
                }


                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + (i + 1) + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='tthoatchat' type='text' value='" + table.Rows[i]["tthoatchat"].ToString() + "' onfocus='IdThuocSearch(this,2);' style='width:250px'  class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value='" + table.Rows[i]["IdThuoc"] + "'/><input mkv='true' id='mkv_IdThuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='IdThuocSearch(this,1);' style='width:250px'  class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='UnitID' type='hidden' value='" + table.Rows[i]["UnitID"] + "'/><input mkv='true' id='mkv_UnitID' type='text' value='" + table.Rows[i]["TenDVT"].ToString() + "' onfocus='UnitIDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='Quantity' onblur='TestSo(this,false,false);CheckSLTon(this);' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["Quantity"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
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
            html.Append("<td><input mkv='true' id='tthoatchat' type='text' value='' onfocus='IdThuocSearch(this,2);' style='width:250px'  class=\"down_select\" /></td>");
            html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value=''/><input mkv='true' id='mkv_IdThuoc' type='text' value='' onfocus='IdThuocSearch(this,1);' style='width:250px' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='UnitID' type='hidden' value=''/><input mkv='true' id='mkv_UnitID' type='text' value='' onfocus='UnitIDSearch(this);' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='Quantity' type='text' onblur='TestSo(this,false,false);CheckSLTon(this);' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
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
    }
    private DataTable nvk_tableChiTietXuat(string idphieuxuat)
    {
        DataTable table = new DataTable();
        DataTable dt_XuatDuyet = DataAcess.Connect.GetTable("select * from chitietphieuxuatkho where idphieuxuat='" + idphieuxuat + "' and  IDCHITIETPHIEUYEUCAUXUATKHO >0");
        string nvk_orderBy = "";
        if (dt_XuatDuyet != null && dt_XuatDuyet.Rows.Count > 0)
        {
            nvk_orderBy = " order by isnull(b.nvk_UuTienYL,100),b.TENDVT,a.TENTHUOC ";
        }
        string nvk_sql = @"select STT=row_number() over (order by T.OutPutDetailID),T.*
                   ,A.TenThuoc
                   ,A.tthoatchat
                   ,B.TenDVT,SLTON
                               from HS_OutPutDetail T
                    left join thuoc  A on T.IdThuoc=A.idthuoc
                    left join Thuoc_DonViTinh  B on A.IDDVT=B.Id
                  where T.IdPhieuXuat='" + idphieuxuat + @"' " + nvk_orderBy + "";
        table = DataAcess.Connect.GetTable(nvk_sql);
        return table;
    }
    //______________________________________________________________________
     
    profess_Rpt_BienBanHongVo NXTReport = null;
    private void PrintBienBan()
    {
        string idphieuxuat = Request.QueryString["idphieuxuat"];
        NXTReport = new profess_Rpt_BienBanHongVo();
        NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        NXTReport.idphieuxuat = idphieuxuat;
        NXTReport.ExportToExcel();
    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
}



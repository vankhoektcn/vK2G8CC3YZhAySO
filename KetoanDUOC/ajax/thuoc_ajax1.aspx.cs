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

public partial class thuoc_ajax : System.Web.UI.Page
{
    protected DataProcess s_thuoc()
    {
        DataProcess thuoc = new DataProcess("thuoc");
        thuoc.data("idthuoc", Request.QueryString["idkhoachinh"]);
        thuoc.data("sttindm05", Request.QueryString["sttindm05"]);
        thuoc.data("tenthuoc", Request.QueryString["tenthuoc"]);
        thuoc.data("congthuc", Request.QueryString["congthuc"]);
        thuoc.data("duongdung", Request.QueryString["duongdung"]);
        thuoc.data("idnuocsanxuat", Request.QueryString["idnuocsanxuat"]);
        thuoc.data("idnhasanxuat", Request.QueryString["idnhasanxuat"]);
        thuoc.data("giabanhientai", Request.QueryString["giabanhientai"]);
        thuoc.data("nhacungcapid", Request.QueryString["nhacungcapid"]);
        thuoc.data("ngayhethan", Request.QueryString["ngayhethan"]);
        thuoc.data("idnhomthuoc", Request.QueryString["idnhomthuoc"]);
        thuoc.data("tlbhtt", Request.QueryString["tlbhtt"]);
        thuoc.data("sudungchobh", Request.QueryString["sudungchobh"]);
        thuoc.data("imei", Request.QueryString["imei"]);
        thuoc.data("iddvt", Request.QueryString["iddvt"]);
        thuoc.data("donvitinh", Request.QueryString["donvitinh"]);
        thuoc.data("LoiDan", Request.QueryString["LoiDan"]);
        thuoc.data("IsVTYT", Request.QueryString["IsVTYT"]);
        thuoc.data("thuexuat", Request.QueryString["thuexuat"]);
        thuoc.data("quycach", Request.QueryString["quycach"]);
        thuoc.data("IsHoaChat", Request.QueryString["IsHoaChat"]);
        thuoc.data("ghichu", Request.QueryString["ghichu"]);
        thuoc.data("LoaiThuocID", Request.QueryString["LoaiThuocID"]);
        thuoc.data("TTHoatChat", Request.QueryString["TTHoatChat"]);
        thuoc.data("IsThuocBV", Request.QueryString["IsThuocBV"]);
        thuoc.data("idhangsanxuat", Request.QueryString["idhangsanxuat"]);
        thuoc.data("CateID", Request.QueryString["CateID"]);
        thuoc.data("IsTGN", Request.QueryString["IsTGN"]);
        thuoc.data("IsTHTT", Request.QueryString["IsTHTT"]);
        thuoc.data("IdCachDung", Request.QueryString["IdCachDung"]);
        thuoc.data("ISTPX", Request.QueryString["ISTPX"]);
        thuoc.data("ISTKS", Request.QueryString["ISTKS"]);
        thuoc.data("ISTDTL", Request.QueryString["ISTDTL"]);
        thuoc.data("ISTcorticoid", Request.QueryString["ISTcorticoid"]);
        thuoc.data("tkKho", Request.QueryString["tkKho"]);
        thuoc.data("tkDoanhThu", Request.QueryString["tkDoanhThu"]);
        thuoc.data("tkGiaVon", Request.QueryString["tkGiaVon"]);
        thuoc.data("tkvat", Request.QueryString["tkvat"]);
        thuoc.data("tkco", Request.QueryString["tkco"]);
        thuoc.data("SoLuong1donvi", Request.QueryString["SoLuong1donvi"]);
        thuoc.data("TenDonVi", Request.QueryString["TenDonVi"]);
        thuoc.data("DVTChuan", Request.QueryString["DVTChuan"]);
        thuoc.data("giabh", Request.QueryString["giabh"]);
        thuoc.data("HamLuong", Request.QueryString["HamLuong"]);
        thuoc.data("IsDTUT", Request.QueryString["IsDTUT"]);
        thuoc.data("IsThucSDBHYT", Request.QueryString["IsThucSDBHYT"]);
        thuoc.data("SLDVTChuan", Request.QueryString["SLDVTChuan"]);
        thuoc.data("SLQuyDoi", Request.QueryString["SLQuyDoi"]);
        thuoc.data("IsThuocBV", "1");
        return thuoc;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savethuoc(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoathuoc(); break;
            case "TimKiem": TimKiem(); break;
            case "idnuocsanxuatSearch": idnuocsanxuatSearch(); break;
            case "idnhomthuocSearch": idnhomthuocSearch(); break;
            case "iddvtSearch": iddvtSearch(); break;
            case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
            case "idhangsanxuatSearch": idhangsanxuatSearch(); break;
            case "CateIDSearch": CateIDSearch(); break;
            case "IdCachDungSearch": IdCachDungSearch(); break;
            case "TenThuocSearch": TenThuocSearch(); break;
            case "tkkhoSearch": tkkhoSearch(); break;
        }
    }
    private void tkkhoSearch()
    {
        string tkkho = Request.QueryString["q"].ToString();
        //string sql = "select taikhoan,tentaikhoan from danhmuctk where taikhoan like '" + tkkho.Trim() + "%'";
        //DataTable table = DataAcess.Connect.GetTable(sql);
        DataTable table = taikhoanchitiet(tkkho);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:20px\" >" + row["TaiKhoan"] + "</div>"
                                         + "<div style=\"width:65%;float:left;height:20px\" >" + row["TenTaiKhoan"] + "</div>"
                                     + "</div>", row["TaiKhoan"].ToString().Trim(), Environment.NewLine);
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    public DataTable taikhoanchitiet(string tk)
    {
        DataTable dt = new DataTable();
        string sql = "";
        string tk1 = "";
        DataTable dtkq = new DataTable();
        dtkq.Columns.Add("taikhoan");
        dtkq.Columns.Add("tentaikhoan");
        sql = "select taikhoan,tentaikhoan from danhmuctk where taikhoan like '" + tk.Trim() + "%' order by taikhoan ";
        dt = DataAcess.Connect.GetTable(sql);
        int sodong = dt.Rows.Count;
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < sodong; i++)
            {
                tk1 = dt.Rows[i]["taikhoan"].ToString();
                string sqlkq = "select taikhoan,tentaikhoan from danhmuctk where taikhoan like '" + tk1.Trim() + "%' order by taikhoan desc"; ;
                DataTable dt1 = new DataTable();
                dt1 = DataAcess.Connect.GetTable(sqlkq);
                if (dt1 != null && dt1.Rows.Count == 1)
                {
                    DataRow r = dtkq.NewRow();
                    r["taikhoan"] = dt1.Rows[0]["taikhoan"];
                    r["tentaikhoan"] = dt1.Rows[0]["tentaikhoan"];
                    dtkq.Rows.Add(r);
                }
            }
        }
        return dtkq;
    }    
    private void idnuocsanxuatSearch()
    {
        DataTable table = Process_2608.NuocSX.dtGetAll();
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void TenThuocSearch()
    {
        string LoaiThuocID = Request.QueryString["LoaiThuocID"].ToString();
        string sqlSelect = " SELECT * FROM THUOC WHERE ISTHUOCBV=1";
        string tenThuoc = Request.QueryString["q"];
        if (tenThuoc != null && tenThuoc != "")
            sqlSelect += " AND TENTHUOC LIKE N'" + tenThuoc + "%'";
        if (LoaiThuocID != null && LoaiThuocID != "")
            sqlSelect += " AND LOAITHUOCID=" + LoaiThuocID;

        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenThuoc"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idnhomthuocSearch()
    {
        string CateID = Request.QueryString["CateID"];
        if (CateID == null || CateID == "") return;
        string TenNhom = Request.QueryString["q"].ToString();
        DataTable table = DataAcess.Connect.GetTable("select * from nhomthuoc where cateid=" + CateID + " AND TENNHOM LIKE N'%" + TenNhom + "%' ORDER BY TENNHOM ");
        if (table == null) return;
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][3].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void iddvtSearch()
    {
        string tenDVT = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM THUOC_DONVITINH WHERE TENDVT LIKE N'" + tenDVT + "%' ORDER BY TENDVT");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void LoaiThuocIDSearch()
    {
        DataTable table = Thuoc_Process.Thuoc_LoaiThuoc.dtGetAll();
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idhangsanxuatSearch()
    {
        DataTable table = Thuoc_Process.hangsanxuat.dtGetAll();
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void CateIDSearch()
    {
        string loaithuocid = Request.QueryString["loaithuocid"];
        DataTable table = Thuoc_Process.category.dtSearchByloaithuocid(loaithuocid);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdCachDungSearch()
    {
        DataTable table = Process_2608.Thuoc_CachDung.dtGetAll();
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoathuoc()
    {
        try
        {
            DataProcess process = s_thuoc();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idthuoc"));
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
        if (StaticData.HavePermision(this, "thuoc_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = Thuoc_Process.thuoc.dtSearchByidthuoc(idkhoachinh);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
            DataTable idnuocsanxuat = Process_2608.NuocSX.dtSearchByidNuocSX("'" + table.Rows[0]["idnuocsanxuat"] + "'");
            html.AppendLine("<data id=\"mkv_idnuocsanxuat\">" + ((idnuocsanxuat.Rows.Count > 0) ? idnuocsanxuat.Rows[0][1] : "") + "</data>");
            DataTable idnhomthuoc = Thuoc_Process.nhomthuoc.dtSearchByidnhomthuoc("'" + table.Rows[0]["idnhomthuoc"] + "'");
            html.AppendLine("<data id=\"mkv_idnhomthuoc\">" + ((idnhomthuoc.Rows.Count > 0) ? idnhomthuoc.Rows[0]["tennhom"] : "") + "</data>");
            DataTable iddvt = Process_2608.Thuoc_DonViTinh.dtSearchById("'" + table.Rows[0]["iddvt"] + "'");
            html.AppendLine("<data id=\"mkv_iddvt\">" + ((iddvt.Rows.Count > 0) ? iddvt.Rows[0][1] : "") + "</data>");
            DataTable LoaiThuocID = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID("'" + table.Rows[0]["LoaiThuocID"] + "'");
            html.AppendLine("<data id=\"mkv_LoaiThuocID\">" + ((LoaiThuocID.Rows.Count > 0) ? LoaiThuocID.Rows[0][1] : "") + "</data>");
            DataTable idhangsanxuat = Thuoc_Process.hangsanxuat.dtSearchByidhangsanxuat("'" + table.Rows[0]["idhangsanxuat"] + "'");
            html.AppendLine("<data id=\"mkv_idhangsanxuat\">" + ((idhangsanxuat.Rows.Count > 0) ? idhangsanxuat.Rows[0][1] : "") + "</data>");
            DataTable CateID = Thuoc_Process.category.dtSearchBycateid("'" + table.Rows[0]["CateID"] + "'");
            html.AppendLine("<data id=\"mkv_CateID\">" + ((CateID.Rows.Count > 0) ? CateID.Rows[0][1] : "") + "</data>");
            DataTable IdCachDung = Process_2608.Thuoc_CachDung.dtSearchByidcachdung("'" + table.Rows[0]["IdCachDung"] + "'");
            html.AppendLine("<data id=\"mkv_IdCachDung\">" + ((IdCachDung.Rows.Count > 0) ? IdCachDung.Rows[0][1] : "") + "</data>");

            DataTable DVTChuan = Process_2608.Thuoc_DonViTinh.dtSearchById("'" + table.Rows[0]["DVTChuan"] + "'");
            html.AppendLine("<data id=\"mkv_DVTChuan\">" + ((DVTChuan.Rows.Count > 0) ? DVTChuan.Rows[0][1] : "") + "</data>");
            html.AppendLine("<data id=\"mkv_tkkho\">" + table.Rows[0]["tkkho"] + "</data>");
            html.AppendLine("<data id=\"mkv_tkdoanhthu\">" + table.Rows[0]["tkdoanhthu"] + "</data>");
            html.AppendLine("<data id=\"mkv_tkgiavon\">" + table.Rows[0]["tkgiavon"] + "</data>");
            html.AppendLine("<data id=\"tkkho\">" + table.Rows[0]["tkkho"] + "</data>");
            html.AppendLine("<data id=\"tkdoanhthu\">" + table.Rows[0]["tkdoanhthu"] + "</data>");
            html.AppendLine("<data id=\"tkgiavon\">" + table.Rows[0]["tkgiavon"] + "</data>");

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

    private void Savethuoc()
    {
        try
        {
            DataProcess process = s_thuoc();
            if (process.getData("idthuoc") != null && process.getData("idthuoc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idthuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idthuoc"));
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
        if (StaticData.HavePermision(this, "thuoc_Search"))
        {
            string tenthuoc = Request.QueryString["tenthuoc"];
            string congthuc = Request.QueryString["congthuc"];
            string cateid = Request.QueryString["cateid"];
            string idnhomthuoc = Request.QueryString["idnhomthuoc"];
            string loaithuocid = Request.QueryString["loaithuocid"];
            string tkkho = Request.QueryString["tkkho"];
            string tkdoanhthu = Request.QueryString["tkdoanhthu"];
            string tkgiavon = Request.QueryString["tkgiavon"];

            string searchbyIsTGN = StaticData.getBitvalue(Request.QueryString["searchbyIsTGN"]);
            string searchbyIsTHTT = StaticData.getBitvalue(Request.QueryString["searchbyIsTHTT"]);
            string searchbyISTPX = StaticData.getBitvalue(Request.QueryString["searchbyISTPX"]);
            string searchbyISTKS = StaticData.getBitvalue(Request.QueryString["searchbyISTKS"]);
            string searchbyISTDTL = StaticData.getBitvalue(Request.QueryString["searchbyISTDTL"]);
            string searchbyISTcorticoid = StaticData.getBitvalue(Request.QueryString["searchbyISTcorticoid"]);
            string searchbyIsDTUT = StaticData.getBitvalue(Request.QueryString["searchbyIsDTUT"]);

            string IsTGN = StaticData.getBitvalue(Request.QueryString["IsTGN"]);
            string IsTHTT = StaticData.getBitvalue(Request.QueryString["IsTHTT"]);
            string ISTPX = StaticData.getBitvalue(Request.QueryString["ISTPX"]);
            string ISTKS = StaticData.getBitvalue(Request.QueryString["ISTKS"]);
            string ISTDTL = StaticData.getBitvalue(Request.QueryString["ISTDTL"]);
            string ISTcorticoid = StaticData.getBitvalue(Request.QueryString["ISTcorticoid"]);
            string IsDTUT = StaticData.getBitvalue(Request.QueryString["IsDTUT"]);



            string sqlSelect = @"select STT=row_number() over (order by T.TENTHUOC),T.*
                   ,A.maNuocSX
                   ,B.tennhom
                   ,C.TenDVT
                   ,D.MaLoai
                   ,E.mahangsanxuat
                   ,H.tenNuocSX
                   ,G.tencachdung                   
                   from thuoc T
                    left join NuocSX  A on T.idnuocsanxuat=A.idNuocSX
                    left join nhomthuoc  B on T.idnhomthuoc=B.idnhomthuoc
                    left join Thuoc_DonViTinh  C on T.iddvt=C.Id
                    left join Thuoc_LoaiThuoc  D on T.LoaiThuocID=D.LoaiThuocID
                    left join hangsanxuat  E on T.idhangsanxuat=E.idhangsanxuat
                    left join category  F on T.CateID=F.cateid
                    left join Thuoc_CachDung  G on T.IdCachDung=G.idcachdung
                    left join NUOCSX H ON T.idnuocsanxuat=H.IDNUOCSX
                    where ISTHUOCBV=1";
            if (tenthuoc != null && tenthuoc != "")
                sqlSelect += " AND T.TENTHUOC LIKE N'" + tenthuoc + "%'";
            if (congthuc != null && congthuc != "")
                sqlSelect += " AND T.congthuc LIKE N'" + congthuc + "%'";
            if (cateid != null && cateid != "")
                sqlSelect += " AND T.cateid = '" + cateid + "'";
            if (idnhomthuoc != null && idnhomthuoc != "")
                sqlSelect += " AND T.idnhomthuoc = '" + idnhomthuoc + "'";
            if (loaithuocid != null && loaithuocid != "")
                sqlSelect += " AND T.loaithuocid = '" + loaithuocid + "'";

            if (searchbyIsTGN == "1" || IsTGN == "1")
                sqlSelect += " AND ISNULL(T.ISTGN,0)=" + IsTGN;
            if (searchbyIsTHTT == "1" || IsTHTT == "1")
                sqlSelect += " AND  ISNULL(T.IsTHTT,0)=" + IsTHTT;
            if (searchbyISTPX == "1" || ISTPX == "1")
                sqlSelect += " AND  ISNULL(T.ISTPX,0)=" + ISTPX;
            if (searchbyISTKS == "1" || ISTKS == "1")
                sqlSelect += " AND  ISNULL(T.ISTKS,0)=" + ISTKS;
            if (searchbyISTDTL == "1" || ISTDTL == "1")
                sqlSelect += " AND  ISNULL(T.ISTDTL,0)=" + ISTDTL;
            if (searchbyISTcorticoid == "1" || ISTcorticoid == "1")
                sqlSelect += " AND  ISNULL(T.ISTcorticoid,0)=" + ISTcorticoid;
            if (searchbyIsDTUT == "1" || IsDTUT == "1")
                sqlSelect += " AND  ISNULL(T.IsDTUT,0)=" + IsDTUT;
            if (!string.IsNullOrEmpty(tkkho))
                sqlSelect += " and T.tkkho='" + tkkho + "'";
            if (!string.IsNullOrEmpty(tkdoanhthu))
                sqlSelect += " and T.tkdoanhthu='" + tkdoanhthu + "'";
            if (!string.IsNullOrEmpty(tkgiavon))
                sqlSelect += " and T.tkgiavon='" + tkgiavon + "'";

            DataProcess process = s_thuoc();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(sqlSelect);
            StringBuilder html = new StringBuilder();
            html.Append(process.Paging());
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sttindm05") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc") + "</th>");
            if (loaithuocid == "1")
            {
                html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TTHoatChat") + "</th>");
                html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("congthuc") + "</th>");
            }
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnuocsanxuat") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnhomthuoc") + "</th>");

            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("iddvt") + "</th>");
            

            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idhangsanxuat") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NuocSX") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsTGN") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsTHTT") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdCachDung") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISTPX") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISTKS") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISTDTL") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ISTcorticoid") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DVTChuan") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("HamLuong") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsDTUT") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SLDVTChuan") + "</th>");
            //html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SLQuyDoi") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sudungchobh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkkho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkdoanhthu") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkgiavon") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idthuoc"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        //html.Append("<td>" + table.Rows[i]["sttindm05"].ToString() + "</td>");
                        html.Append("<td align='LEFT'>" + table.Rows[i]["tenthuoc"].ToString() + "</td>");
                        if (loaithuocid == "1")
                        {
                            html.Append("<td>" + table.Rows[i]["TTHoatChat"].ToString() + "</td>");
                            html.Append("<td align='LEFT'>" + table.Rows[i]["congthuc"].ToString() + "</td>");
                        }
                        //html.Append("<td>" + table.Rows[i]["maNuocSX"].ToString() + "</td>");
                        //html.Append("<td>" + table.Rows[i]["tennhom"].ToString() + "</td>");

                        html.Append("<td>" + table.Rows[i]["TenDVT"].ToString() + "</td>");
                        //html.Append("<td>" + table.Rows[i]["MaLoai"].ToString() + "</td>");

                        //html.Append("<td>" + table.Rows[i]["mahangsanxuat"].ToString() + "</td>");
                        html.Append("<td align='LEFT'>" + table.Rows[i]["TenNuocSX"].ToString() + "</td>");
                        //html.Append("<td><input type='checkbox' disabled='true' " + (table.Rows[i]["IsTGN"].ToString() == "True" ? "checked" : "") + "/></td>");
                        //html.Append("<td><input type='checkbox' disabled='true' " + (table.Rows[i]["IsTHTT"].ToString() == "True" ? "checked" : "") + "/></td>");
                        //html.Append("<td>" + table.Rows[i]["tencachdung"].ToString() + "</td>");
                        //html.Append("<td><input type='checkbox' disabled='true' " + (table.Rows[i]["ISTPX"].ToString() == "True" ? "checked" : "") + "/></td>");
                        //html.Append("<td><input type='checkbox' disabled='true' " + (table.Rows[i]["ISTKS"].ToString() == "True" ? "checked" : "") + "/></td>");
                        //html.Append("<td><input type='checkbox' disabled='true' " + (table.Rows[i]["ISTDTL"].ToString() == "True" ? "checked" : "") + "/></td>");
                        //html.Append("<td><input type='checkbox' disabled='true' " + (table.Rows[i]["ISTcorticoid"].ToString() == "True" ? "checked" : "") + "/></td>");
                        //html.Append("<td>" + table.Rows[i]["DVTChuan"].ToString() + "</td>");
                        //html.Append("<td>" + table.Rows[i]["HamLuong"].ToString() + "</td>");
                        //html.Append("<td><input type='checkbox' disabled='true' " + (table.Rows[i]["IsDTUT"].ToString() == "True" ? "checked" : "") + "/></td>");
                        //html.Append("<td>" + table.Rows[i]["SLDVTChuan"].ToString() + "</td>");
                        //html.Append("<td>" + table.Rows[i]["SLQuyDoi"].ToString() + "</td>");
                        html.Append("<td><input type='checkbox' disabled='true' " + (table.Rows[i]["sudungchobh"].ToString() == "True" ? "checked" : "") + "/></td>");
                        html.Append("<td>" + table.Rows[i]["tkkho"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tkdoanhthu"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tkgiavon"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                }
            }
            html.Append("</table>");
            html.Append(process.Paging());
            Response.Clear(); Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }
}



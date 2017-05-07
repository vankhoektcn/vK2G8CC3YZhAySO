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

public partial class Yc_PhieuYCXuat_ajax : System.Web.UI.Page
{
    protected DataProcess s_Yc_PhieuYCXuat()
    {
        DataProcess Yc_PhieuYCXuat = new DataProcess("Yc_PhieuYCXuat");
        Yc_PhieuYCXuat.data("IdPhieuYc", Request.QueryString["idkhoachinh"]);
        string timeYC = "";
        if (Request.QueryString["GioYc"] != null && Request.QueryString["PhutYC"] != null)
            timeYC = " " + Request.QueryString["GioYc"] + ":" + Request.QueryString["PhutYC"];
        Yc_PhieuYCXuat.data("NgayYc", Request.QueryString["NgayYc"] + timeYC);
        Yc_PhieuYCXuat.data("IdKhoYc", Request.QueryString["IdKhoYc"]);
        Yc_PhieuYCXuat.data("IdKhoDuyet", Request.QueryString["IdKhoDuyet"]);
        Yc_PhieuYCXuat.data("IdNguoiDuyet", Request.QueryString["IdNguoiDuyet"]);
        Yc_PhieuYCXuat.data("LoaiThuocID", Request.QueryString["LoaiThuocID"]);
        Yc_PhieuYCXuat.data("IsDuTru", Request.QueryString["IsDuTru"]);

        string timeYC_Tungay = "";
        if (Request.QueryString["TuGio"] != null && Request.QueryString["TuPhut"] != null)
            timeYC_Tungay = " " + Request.QueryString["TuGio"] + ":" + Request.QueryString["TuPhut"];
        else
            timeYC_Tungay = " " + "00" + ":" + "00";

        string timeYC_DenNgay = "";
        if (Request.QueryString["DenGio"] != null && Request.QueryString["DenPhut"] != null)
            timeYC_DenNgay = " " + Request.QueryString["DenGio"] + ":" + Request.QueryString["DenPhut"];
        else
            timeYC_DenNgay = " " + "23" + ":" + "59";

        Yc_PhieuYCXuat.data("TuNgay", Request.QueryString["TuNgay"] + timeYC_Tungay);
         
        Yc_PhieuYCXuat.data("DenNgay", Request.QueryString["DenNgay"]+timeYC_DenNgay);
        Yc_PhieuYCXuat.data("IsDuTru", Request.QueryString["IsDuTru"]);


        string timeDuyet = "";
        if (Request.QueryString["GioDuyet"] != null && Request.QueryString["PhutDuyet"] != null)
            timeDuyet = " " + Request.QueryString["GioDuyet"] + ":" + Request.QueryString["PhutDuyet"];
        Yc_PhieuYCXuat.data("NgayDuyet", Request.QueryString["NgayDuyet"] + timeDuyet);



        return Yc_PhieuYCXuat;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    protected DataProcess s_Yc_PhieuYcXuatChiTiet()
    {
        DataProcess Yc_PhieuYcXuatChiTiet = new DataProcess("Yc_PhieuYcXuatChiTiet");
        Yc_PhieuYcXuatChiTiet.data("IdChiTietYc", Request.QueryString["idkhoachinh"]);
        Yc_PhieuYcXuatChiTiet.data("IdPhieuYc", Request.QueryString["IdPhieuYc"]);
        Yc_PhieuYcXuatChiTiet.data("IdThuoc", Request.QueryString["IdThuoc"]);
        Yc_PhieuYcXuatChiTiet.data("SoLuongYc", Request.QueryString["SoLuongYc"]);
        Yc_PhieuYcXuatChiTiet.data("SoLuongDuyet", Request.QueryString["SoLuongDuyet"]);
        Yc_PhieuYcXuatChiTiet.data("SlTon", Request.QueryString["SlTon"]);
        Yc_PhieuYcXuatChiTiet.data("SlDutru", Request.QueryString["SlDutru"]);
        Yc_PhieuYcXuatChiTiet.data("GhiChu", Request.QueryString["GhiChu"]);
        Yc_PhieuYcXuatChiTiet.data("Status", Request.QueryString["Status"]);
        return Yc_PhieuYcXuatChiTiet;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveYc_PhieuYCXuat(); break;
          
            case "setTimKiem": setTimKiem(); break;
            case "luuTableYc_PhieuYcXuatChiTiet": LuuTableYc_PhieuYcXuatChiTiet(); break;
            case "loadTableYc_PhieuYcXuatChiTiet": loadTableYc_PhieuYcXuatChiTiet(false); break;
            case "xoa": XoaYc_PhieuYCXuat(); break;
            case "xoaYc_PhieuYcXuatChiTiet": XoaYc_PhieuYcXuatChiTiet(); break;
            case "IdKhoYcSearch": IdKhoYcSearch(); break;
            case "IdKhoDuyetSearch": IdKhoDuyetSearch(); break;
            case "IdNguoiYcSearch": IdNguoiYcSearch(); break;
            case "IdNguoiDuyetSearch": IdNguoiDuyetSearch(); break;
            case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
            case "IdThuocSearch": IdThuocSearch(); break;
            case "setDefault": setDefault(); break;
            case "LoadDanhSachYCTuChiDinh": loadTableYc_PhieuYcXuatChiTiet(true); break;
            case "LuuDuyetIn": LuuDuyetIn(); break;
            case "luuDuyetInTableYc_PhieuYcXuatChiTiet": luuDuyetInTableYc_PhieuYcXuatChiTiet(); break;
            case "LuuDuyetPhat": LuuDuyetPhat(); break;
            case "HuyDuyetPhat": HuyDuyetPhat(); break;
            case "GetSoPhieuYC": GetSoPhieuYC(); break;
        }
    }
    //───────────────────────────────────────────────────────────────────────────────────────

    private void IdKhoYcSearch()
    {
        string IdKhoa = Request.QueryString["IdKhoa"];
        string sqlKhoXuat = @"select * from khothuoc where 1=1 " + (IdKhoa != null && IdKhoa != "" ? " and IdKhoa='" + IdKhoa + "'" : "") + " and  tenkho like N'" + Request.QueryString["q"] + "%' ORDER BY SOTT ";
        //string IDNGUOIDUNG = SysParameter.UserLogin.UserID(this);
        //if (IDNGUOIDUNG != null && IDNGUOIDUNG != "" && !SysParameter.UserLogin.IsAdmin(this))
        //    sqlKhoXuat += " and idkho in (select idkho from khothuocnguoidung where idnguoidung=" + IDNGUOIDUNG + ")";
        DataTable table = DataAcess.Connect.GetTable(sqlKhoXuat);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["SoTT"].ToString()+"-"+ table.Rows[i]["tenkho"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void IdKhoDuyetSearch()
    {
        string strKhoDuyet = "nvk_loaikho = 1 ";
        string paraIdKhoNhap = StaticData.GetParameter("IdKhoNhap");
        if (!string.IsNullOrEmpty(paraIdKhoNhap))
            strKhoDuyet = "AND idkho in ("+paraIdKhoNhap+") ";

        string IdKho = Request.QueryString["IdKho"];
        if (IdKho != null && IdKho != "")
            strKhoDuyet += " AND IDKHO=" + IdKho;

        DataTable table = DataProcess.GetTable("select * from khothuoc  where 1=1  "+strKhoDuyet+" and  tenkho like N'%" + Request.QueryString["q"] + "%'");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenkho"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void IdNguoiYcSearch()
    {
        DataTable table = DataProcess.GetTable("select * from nguoidung  where tennguoidung like N'%" + Request.QueryString["q"] + "%'");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tennguoidung"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void IdNguoiDuyetSearch()
    {
        DataTable table = DataProcess.GetTable("select * from nguoidung  where tennguoidung like N'%" + Request.QueryString["q"] + "%'");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tennguoidung"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void LoaiThuocIDSearch()
    {
        string sqlSelect = "select * from Thuoc_LoaiThuoc  where TenLoai like N'%" + Request.QueryString["q"] + "%' ";
        
        DataTable table = DataProcess.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenLoai"].ToString() + "|" + table.Rows[i][0].ToString());

                }
                html.AppendLine("Gây nghiện" + "|" + "5");
                html.AppendLine("Hướng tâm thần" + "|" + "6");
            }
        }
        Response.Clear(); Response.Write(html);
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void IdThuocSearch()
    {
        StaticData.getthuoc_new(this,false);
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void XoaYc_PhieuYCXuat()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYCXuat();
            string IdPhieuYc = process.getData("IdPhieuYc");
            string sqlTest = "SELECT ISDUYETIN FROM Yc_PhieuYcXuat WHERE IdPhieuYc=" + IdPhieuYc;
            DataTable dtTEst = DataAcess.Connect.GetTable(sqlTest);
            if (dtTEst != null && dtTEst.Rows.Count > 0)
            {
                if (StaticData.IsCheck(dtTEst.Rows[0][0].ToString()))
                {
                    Response.StatusCode = 500;
                    return;
                }
            }


            bool ok = process.Delete();
            if (ok)
            {
                ok = DataAcess.Connect.ExecSQL("DELETE Yc_PhieuYCXuatchitiet WHERE IdPhieuYc=" + process.getData("IdPhieuYc"));
                string sqlUpCD = "update chitietbenhnhantoathuoc set IsDaXuatTheoYC=0,IdPhieuYc_XUAT=0 where IdPhieuYc_XUAT='" + process.getData("IdPhieuYc") + "'";
                ok = DataAcess.Connect.ExecSQL(sqlUpCD);
                Response.Clear(); Response.Write(process.getData("IdPhieuYc"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void XoaYc_PhieuYcXuatChiTiet()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYcXuatChiTiet();
            string IdChiTietYc = process.getData("IdChiTietYc");
            string sqlTest = "SELECT ISDUYETIN FROM Yc_PhieuYcXuatChiTiet WHERE IdChiTietYc=" + IdChiTietYc;
            DataTable dtTEst = DataAcess.Connect.GetTable(sqlTest);
            if (dtTEst != null && dtTEst.Rows.Count > 0)
            {
                if (StaticData.IsCheck(dtTEst.Rows[0][0].ToString()))
                {
                    Response.StatusCode = 500;
                    return;
                }
            }
            string sqlInfo = "select ct.idthuoc,ct.idphieuyc,IsTheoCD=convert(int,isnull(IsTheoCD,0)) from yc_phieuycxuatchitiet ct inner join yc_phieuycxuat yc on yc.idphieuyc =ct.idphieuyc where idchitietyc ='" + IdChiTietYc + "' ";
            DataTable dtCT = DataAcess.Connect.GetTable(sqlInfo);
            if (dtCT != null && dtCT.Rows.Count > 0)
            {
                bool ok = process.Delete();
                if (ok)
                {
                    if (dtCT.Rows[0]["IsTheoCD"].ToString().Equals("1"))
                    {
                        string sqlUp = "update chitietbenhnhantoathuoc set IsDaXuatTheoYC=0,IdPhieuYc_XUAT=0 where IdPhieuYc_XUAT='" + dtCT.Rows[0]["idphieuyc"].ToString() + "' and idthuoc='" + dtCT.Rows[0]["idthuoc"].ToString() + "'";
                        ok = DataAcess.Connect.ExecSQL(sqlUp);
                    }
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("IdChiTietYc"));
                        return;
                    }
                }
            }
        }
        catch
        {
        }
        
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void setTimKiem()
    {
        if (Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 idkhoachinh=T.IdPhieuYc
                ,T.IdPhieuYc,T.SoPhieuYc,NgayYc=convert(varchar(10),T.NgayYc,103),GioYc=DATEPART(Hh,T.NgayYc),PhutYC=DATEPART(Mi,T.NgayYc)
                ,T.IdKhoYc,T.IdKhoDuyet,T.IdNguoiYc,T.IdNguoiDuyet
                ,NgayDuyet=convert(varchar(10),T.NgayDuyet,103),GioDuyet=DATEPART(Hh,T.NgayDuyet),PhutDuyet=DATEPART(Mi,T.NgayDuyet)
                ,T.IsDuyetIn,T.IsDuyetPhat,T.LoaiThuocID,T.Status,T.idphieuxuat
                ,isviewIn= case T.IsDuyetIn when 1 then 1 else 0 end
                ,isDaPhat= case when isnull(T.idphieuxuat,0)>0 then 1 else 0 end
                   ,mkv_IdKhoYc = A.tenkho
                   ,mkv_IdKhoDuyet = B.tenkho
                   ,mkv_IdNguoiYc = C.tennguoidung
                   ,mkv_IdNguoiDuyet = D.tennguoidung
                   ,mkv_LoaiThuocID = E.TenLoai
                   ,px.maphieuxuat
                   ,TuNgay=convert(varchar(10),T.TuNgay,103),TuGio=DATEPART(Hh,T.TuNgay),TuPhut=DATEPART(Mi,T.TuNgay)
                   ,DenNgay=convert(varchar(10),T.DenNgay,103),DenGio=DATEPART(Hh,T.DenNgay),DenPhut=DATEPART(Mi,T.DenNgay)
                   ,T.IsDuTru
                   ,T.IsTheoCD
                               from Yc_PhieuYCXuat T
                    left join PHIEUXUATKHO px on px.idphieuxuat = T.idphieuxuat
                    left join khothuoc  A on T.IdKhoYc=A.idkho
                    left join khothuoc  B on T.IdKhoDuyet=B.idkho
                    left join nguoidung  C on T.IdNguoiYc=C.idnguoidung
                    left join nguoidung  D on T.IdNguoiDuyet=D.idnguoidung
                    left join Thuoc_LoaiThuoc  E on T.LoaiThuocID=E.LoaiThuocID
                    where T.IdPhieuYc ='" + idkhoachinh + "'");
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }
    //───────────────────────────────────────────────────────────────────────────────────────
   
    private void SaveYc_PhieuYCXuat()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYCXuat();
            if (!string.IsNullOrEmpty(process.getData("IdPhieuYc")))
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdPhieuYc"));
                    return;
                }
            }
            else
            {
                process.data("IdNguoiYc", SysParameter.UserLogin.UserID(this));
                bool ok = process.Insert();
                if (ok)
                {
                    string NgayDuyet = process.getData("NgayDuyet");
                    if (NgayDuyet.Length > "17/07/2013".Length)
                    {
                        NgayDuyet = NgayDuyet.Substring(0, "17/07/2013".Length);
                    }

                    string IdKhoDuyet = process.getData("IdKhoDuyet");
                    string IdPhieuYc = process.getData("IdPhieuYc");
                    NgayDuyet = StaticData.CheckDate(NgayDuyet);
                    string sqlSaveSoPhieuYC = "EXEC HS_CREATE_MAPHIEUYCXUATBYKHO '" + NgayDuyet + "' ," + IdKhoDuyet + " ," + IdPhieuYc + "  ";
                    bool ok1= DataAcess.Connect.ExecSQL(sqlSaveSoPhieuYC);
                    Response.Clear(); Response.Write(process.getData("IdPhieuYc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    public void LuuTableYc_PhieuYcXuatChiTiet()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYcXuatChiTiet();
            if (!string.IsNullOrEmpty(process.getData("IdChiTietYc")))
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdChiTietYc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdChiTietYc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    public void loadTableYc_PhieuYcXuatChiTiet(bool isGetList)
    {
        bool IsTheoCD = false;
        string IsDuyetPhat="0";
        bool IsViewSLDuyet = ((Userlogin_new.HavePermision(this, "xetduyet1") || Userlogin_new.HavePermision(this, "xetduyet2")) ?true:false);
        string paging = "";
        bool add = Userlogin_new.HavePermision(this, "Yc_PhieuYcXuatChiTiet_Add");
        bool search = Userlogin_new.HavePermision(this, "Yc_PhieuYcXuatChiTiet_Search");
        bool DuyetIn = Userlogin_new.HavePermision(this, "xetduyet1");
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' rowspan='2'>STT</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' rowspan='2'></th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' rowspan='2'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc") + "</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' rowspan='2'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' rowspan='2'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoLuong") + "</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' rowspan='2'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SL Duyệt") + "</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' colspan='2'>Duyệt</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' rowspan='2'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Duyệt in") + "<input mkv='true' id='IsDuyetInAll' " + (!DuyetIn ? "disabled" : "") + " onclick=\"checkDuyetAllTable(this,'gridTable','IsDuyetIn');\" type='checkbox' /></th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' colspan='2'>Phát</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' rowspan='2' >" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' rowspan='2'></th>");
        html.Append("</tr>");
        html.Append("<tr>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' >Tồn</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' >Dự trù</th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' >Tồn </th>");
        html.Append("<th style='font-weight: bold;color: #fff;background: #3090c7 url(./images/bg_header.jpg) no-repeat;' >Dự trù </th>");
        html.Append("</tr>");

        if (search)
        {
            DataProcess process = s_Yc_PhieuYcXuatChiTiet();
            process.Page = Request.QueryString["page"];
            string sqlYc ="";
            DataTable table = new DataTable();
            #region dtSource . Truong Hop Tu Chi dinh
            if (isGetList && string.IsNullOrEmpty(process.getData("IdPhieuYc")))
            {
                #region Load Danh sach Yeu Cau Tu Chi Dinh
                string IdKhoYc = Request.QueryString["IdKhoYc"];
                string IdKhoDuyet = Request.QueryString["IdKhoDuyet"];
                string LoaiThuocID = Request.QueryString["LoaiThuocID"];
                string TuNgay = Request.QueryString["TuNgay"];
                string TuGio = Request.QueryString["TuGio"];
                string TuPhut = Request.QueryString["TuPhut"];
                string DenNgay = Request.QueryString["DenNgay"];
                string DenGio = Request.QueryString["DenGio"];
                string DenPhut = Request.QueryString["DenPhut"];

                string NgayYC = Request.QueryString["NgayYC"];
                string GioYC = Request.QueryString["GioYC"];
                string PhutYC = Request.QueryString["PhutYC"];
                if (GioYC == null || GioYC == "") GioYC = DateTime.Now.ToString("HH");
                if (PhutYC == null || PhutYC == "") PhutYC = DateTime.Now.ToString("mm");
                string NgayYC_save=StaticData.CheckDate(NgayYC.ToString())+" "+GioYC+":"+PhutYC+":00";

                bool IsDuTru = StaticData.IsCheck(Request.QueryString["IsDuTru"]);

                string tungayFull = (!string.IsNullOrEmpty(TuNgay) ? ((!IsDuTru ? " AND KB.ngayDuTruThuoc IS NULL " : " AND KB.ngayDuTruThuoc IS NOT NULL ") + " and " + (!IsDuTru ? "KB.ngaykham" : "KB.ngayDuTruThuoc") + " >='" + StaticData.CheckDate(TuNgay) + ((!string.IsNullOrEmpty(TuGio) && !string.IsNullOrEmpty(TuPhut)) ? " " + TuGio + ":" + TuPhut + "'" : "'")) : "");
                string dengayFull = (!string.IsNullOrEmpty(DenNgay) ? ((!IsDuTru ? " AND KB.ngayDuTruThuoc IS NULL " : " AND KB.ngayDuTruThuoc IS NOT NULL ") + " and " + (!IsDuTru ? "KB.ngaykham" : "KB.ngayDuTruThuoc") + " <='" + StaticData.CheckDate(DenNgay) + ((!string.IsNullOrEmpty(DenGio) && !string.IsNullOrEmpty(DenPhut)) ? " " + DenGio + ":" + DenPhut + "'" : " 23:59:58:999'")) : "");

                


                string dkLoaiThuoc = " and t.LoaiThuocID='" + LoaiThuocID + @"'";
                if (LoaiThuocID.Equals("1"))//Gây nghiện
                    dkLoaiThuoc += " and isnull(t.istgn,0)=0 and isnull(t.IsTHTT,0)=0";
                if (LoaiThuocID.Equals("5"))//Gây nghiện
                    dkLoaiThuoc = " and t.LoaiThuocID=1 and t.IsTGN=1";
                if (LoaiThuocID.Equals("6"))//Gây nghiện
                    dkLoaiThuoc = " and t.LoaiThuocID=1 and t.IsTHTT=1";

                sqlYc = @" select
							DISTINCT
							 ct.idthuoc
							,t.tenthuoc
                            ,t.tthoatchat
							,UnitID=T.iddvt
							,mkv_UnitID=dvt.TenDVT
							,SlTon=dbo.Thuoc_TonKho_PHIEUNHAP(CT.idthuoc,'" + NgayYC_save + "'," + IdKhoDuyet + @")
							,SlDutru=dbo.HS_SLYEUCAUCHUADUYET(CT.idthuoc," + IdKhoDuyet + @",null)
							,IsDuyetIn=0
							,GhiChu=''
						    ,SoLuongYc=0
							,tthoatchat
							,IdChiTietYc=null 
							,TonPhat=0
							,DutruPhat=0
							,SoLuongDuyet=0
							,slChiDinh=sum(soluongke)
                            ,isnull(nvk_UuTienYL,100)
	                    from chitietbenhnhantoathuoc ct
							 inner join khambenh kb on kb.idkhambenh =ct.idkhambenh
							 inner join thuoc t on t.idthuoc =ct.idthuoc
							 left join thuoc_donvitinh dvt on dvt.id=T.iddvt
						where 1=1
                                    AND ISNULL(CT.IsDaXuatTheoYC,0)=0
									 AND  ct.idkho=" + IdKhoYc + "\r\n"
                                      + dkLoaiThuoc + "\r\n"
                                     + tungayFull + "\r\n"
                                     + dengayFull + "\r\n"
                                     + @"
                    group by
							 ct.idthuoc
							,t.tenthuoc
                            ,t.tthoatchat
							, T.iddvt
							, dvt.TenDVT
							,isnull(nvk_UuTienYL,100)
						ORDER BY   isnull(nvk_UuTienYL,100),TENDVT,tenthuoc  ";
               
                #region set SoLuong co the Yc
                table = DataAcess.Connect.GetTable(sqlYc);
                if (table != null && table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        float slChiDinh = StaticData.ParseFloat(table.Rows[i]["slChiDinh"]);
                        float slCoTheXuat = StaticData.ParseFloat(table.Rows[i]["SlTon"]) - StaticData.ParseFloat(table.Rows[i]["SlDutru"]);
                        float slYeuCau = (slChiDinh> slCoTheXuat ? slCoTheXuat: slChiDinh);
                        table.Rows[i]["SoLuongYc"] = slChiDinh;
                        table.Rows[i]["SoLuongDuyet"] = slYeuCau;
                    }
                }
                #endregion
            }
                #endregion
            #endregion
            #region dtSource. TH Binh Thuong
            else
            {
                #region Cap nhat TonPhat , DutruPhat khi đã Duyệt + Chưa phát
                string IdPhieuYc= process.getData("IdPhieuYc");
                if (!string.IsNullOrEmpty(IdPhieuYc))
                {
                    string sqlSelect0 = "SELECT * FROM Yc_PhieuYCXuat WHERE IdPhieuYc=" + IdPhieuYc;
                    
                    DataTable dt0 = DataAcess.Connect.GetTable(sqlSelect0);
                    if (dt0 == null || dt0.Rows.Count == 0) return;
                    IsTheoCD = StaticData.IsCheck(dt0.Rows[0]["IsTheoCD"].ToString());
                    string IdKhoDuyet = dt0.Rows[0]["IDKHODUYET"].ToString();
                    string NgayDuyet = dt0.Rows[0]["NgayDuyet"].ToString();
                    if(NgayDuyet==null ||NgayDuyet=="")
                        NgayDuyet = dt0.Rows[0]["NgayYC"].ToString();
                    IsDuyetPhat = dt0.Rows[0]["IsDuyetPhat"].ToString();
                    string IsDuyetIn = dt0.Rows[0]["IsDuyetIn"].ToString();
                    IsDuyetPhat = (StaticData.IsCheck(IsDuyetPhat) ? "1" : "0");
                    NgayDuyet = DateTime.Parse(NgayDuyet).ToString("yyyy-MM-dd HH:mm:ss");
                    if (StaticData.IsCheck(IsDuyetPhat) == false  && DateTime.Parse(NgayDuyet).ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                       NgayDuyet= DateTime.Parse(NgayDuyet).ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss");
                    }
                    if (StaticData.IsCheck(IsDuyetIn) == false  && StaticData.GetParaValueDB("ChoPhepCapNhatSLTonDuyetIn")=="1")
                    {
                        string sqlUpDateTonDuyetIN = "  UPDATE  Yc_PhieuYcXuatChiTiet SET  SLTON=DBO.Thuoc_TonKho_PHIEUNHAP(IDTHUOC,'" + NgayDuyet + @"'," + IdKhoDuyet + @") 
                                                                                      ,SlDutru=DBO.HS_SLYEUCAUCHUADUYET(IDTHUOC," + IdKhoDuyet + @",IdChiTietYc)
                                                                                    WHERE ISNULL(ISDUYETIN,0)=0 AND IdPhieuYc=" + IdPhieuYc
                                                                                        + "\r\n";
                        bool OK1 = DataAcess.Connect.ExecSQL(sqlUpDateTonDuyetIN);
                        

                    }
                    if (StaticData.IsCheck(IsDuyetIn) == false)
                    {
                        string sqlUpdateSoLuongDuyet = "UPDATE Yc_PhieuYcXuatChiTiet SET SoLuongDuyet=(CASE WHEN SLTON-SlDutru>SoLuongYc THEN SoLuongYc ELSE SLTON-SlDutru END  ) WHERE ISNULL(ISDUYETIN,0)=0 AND IdPhieuYc=" + IdPhieuYc;
                        bool OK2 = DataAcess.Connect.ExecSQL(sqlUpdateSoLuongDuyet);

                    }

                    if (StaticData.IsCheck(IsDuyetPhat) == false && StaticData.GetParaValueDB("ChoPhepCapNhatSLTonPhat")=="1")
                    {
                        string sqlUpdateTonDuyetPhat = " UPDATE  Yc_PhieuYcXuatChiTiet SET TonPhat=DBO.Thuoc_TonKho_PHIEUNHAP(IDTHUOC,'" + NgayDuyet + @"'," + IdKhoDuyet + @") 
                                                                                      ,DutruPhat=DBO.HS_SLYEUCAUCHUADUYET(IDTHUOC," + IdKhoDuyet + @",IdChiTietYc)
                                                                                   WHERE " + IsDuyetPhat + @"=0 AND  ISNULL(ISDUYETIN,0)=1  AND IdPhieuYc=" + IdPhieuYc;
                        bool OK3 = DataAcess.Connect.ExecSQL(sqlUpdateTonDuyetPhat);

                        
                    }
                }
                #endregion
                sqlYc = @"select STT=row_number() over (order by   isnull(nvk_UuTienYL,100),TENDVT,tenthuoc  )
                                       ,T.IdChiTietYc,T.IdPhieuYc,T.IdThuoc,T.SoLuongYc,T.SoLuongDuyet,T.IsDuyetIn,T.GhiChu,T.Status
                                       ,T.SlTon,T.SlDutru,T.TonPhat,T.DutruPhat
                                       ,A.SoPhieuYc
                                       ,B.tenthuoc
                                        ,B.tthoatchat
                                        ,UnitID=b.iddvt
                                        ,mkv_UnitID=dvt.TenDVT
                               from Yc_PhieuYcXuatChiTiet T
                                left join Yc_PhieuYCXuat  A on T.IdPhieuYc=A.IdPhieuYc
                                left join thuoc  B on T.IdThuoc=B.idthuoc
                                left join thuoc_donvitinh  dvt on dvt.id=B.iddvt
                            where T.IdPhieuYc='" + process.getData("IdPhieuYc") + "'";
                 table = process.Search(sqlYc);

             
            }
            #endregion

            if (table != null && table.Rows.Count > 0)
            {
                paging = process.Paging("Yc_PhieuYcXuatChiTiet");
                bool delete0 = Userlogin_new.HavePermision(this, "Yc_PhieuYcXuatChiTiet_Delete");
                bool edit0 = Userlogin_new.HavePermision(this, "Yc_PhieuYcXuatChiTiet_Edit");
                if (IsTheoCD == true) delete0 = edit0 = false;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                   bool edit = edit0 & !StaticData.IsCheck(table.Rows[i]["IsDuyetIn"]);
                   bool delete = delete0 & !StaticData.IsCheck(table.Rows[i]["IsDuyetIn"]);
                    html.Append("<tr>");
                    html.Append("<td>" + (table.Columns.IndexOf("STT")!=-1? table.Rows[i]["stt"].ToString() : (i+1).ToString()) + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value='" + table.Rows[i]["IdThuoc"] + "'/><input mkv='true' id='mkv_IdThuoc' type='text' style='width: 250px;' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='IdThuocSearch(this,1);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='UnitID' type='hidden' value='" + table.Rows[i]["UnitID"] + "'/><input mkv='true' id='mkv_UnitID' type='text' style='width: 80px;' value='" + table.Rows[i]["mkv_UnitID"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='SoLuongYc' type='text' style='width: 50px;text-align: right;' value='" + table.Rows[i]["SoLuongYc"].ToString() + "' onblur='KiemTraTonYC(this);TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='SoLuongDuyet' type='text' style='width: 50px;text-align: right;' value='" + table.Rows[i]["SoLuongDuyet"].ToString() + "' onblur='TestSo(this,false,false);KiemTraTonDuyet(this);' " + (DuyetIn && StaticData.IsCheck(table.Rows[i]["IsDuyetIn"].ToString()) == false ? "" : "disabled") + " /></td>");
                    html.Append(@"<td><input mkv='true' id='SlTon' disabled type='text' style='width: 30px;text-align: right;' value='" + table.Rows[i]["SlTon"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append(@"<td><input mkv='true' id='SlDutru' disabled type='text' style='width: 30px;text-align: right;' value='" + table.Rows[i]["SlDutru"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='IsDuyetIn' type='checkbox' " + (table.Rows[i]["IsDuyetIn"].ToString() == "True" ? "checked" : "") + " " + (!DuyetIn || IsDuyetPhat=="1" ? "disabled" : "") + " onclick=\"rowSetCheck(this,'gridTable','IsDuyetIn');\"/></td>");
                    html.Append(@"<td><input mkv='true' id='TonPhat' disabled type='text' style='width: 30px;text-align: right;' value='" + table.Rows[i]["TonPhat"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append(@"<td><input mkv='true' id='DutruPhat' disabled type='text' style='width: 30px;text-align: right;' value='" + table.Rows[i]["DutruPhat"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='GhiChu' type='text'  value='" + table.Rows[i]["GhiChu"].ToString() + "' /></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["IdChiTietYc"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (IsTheoCD == true) add  = false;
        if (add && !isGetList)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value=''/><input mkv='true' id='mkv_IdThuoc' type='text' style='width: 250px;' value='' onfocus='IdThuocSearch(this,1);' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='UnitID' type='hidden' value=''/><input mkv='true' id='mkv_UnitID' type='text' style='width: 80px;' value='' /></td>");
            html.Append("<td><input mkv='true' id='SoLuongYc' style='width: 50px;text-align: right;' type='text' value='' onblur='KiemTraTonYC(this);TestSo(this,false,false);' /></td>");
            html.Append("<td><input mkv='true' id='SoLuongDuyet' style='width: 50px;text-align: right;' type='text' value='' onblur='TestSo(this,false,false);KiemTraTonDuyet(this);' " + (DuyetIn ? "" : "disabled") + " /></td>");
            html.Append(@"<td><input mkv='true' id='SlTon' disabled style='width: 30px;text-align: right;' type='text' value='' onblur='TestSo(this,false,false);' /></td>");
            html.Append(@"<td><input mkv='true' id='SlDutru' disabled style='width: 30px;text-align: right;' type='text' value='' onblur='TestSo(this,false,false);' /></td>");
            html.Append("<td><input mkv='true' id='IsDuyetIn' type='checkbox' onclick=\"rowSetCheck(this,'gridTable','IsDuyetIn');\" " + (DuyetIn ? "" : "disabled") + " /></td>");
            html.Append(@"<td><input mkv='true' id='TonPhat' disabled style='width: 30px;text-align: right;' type='text' value='' onblur='TestSo(this,false,false);' /></td>");
            html.Append(@"<td><input mkv='true' id='DutruPhat' disabled style='width: 30px;text-align: right;' type='text' value='' onblur='TestSo(this,false,false);' /></td>");
            html.Append("<td><input mkv='true' id='GhiChu' type='text' value='' /></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới !") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }//end void
    //───────────────────────────────────────────────────────────────────────────────────────
    private void setDefault()
    {
        string IsTheoCD = "0";
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        bool PerDuyetIn = Userlogin_new.HavePermision(this, "xetduyet1");
        string sql = @"select perDuyetIn=" + (PerDuyetIn ? "1" : "0") + @"
                      ,perDuyetPhat=" + (PerDuyetIn ? "1" : "0")
                                      + (idkhoachinh != null && idkhoachinh != "" && idkhoachinh != "0" ? "" : ",NgayYc=convert(varchar(10),getdate(),103),GioYc=DATEPART(Hh,getdate()),PhutYC=DATEPART(Mi,getdate())");
                                       
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string IsKhoBN = "0";
        if (idkhoachinh != null && idkhoachinh != "" && idkhoachinh != "0")
        {
            string sqlTestDuyetIn = "SELECT *,IsKhoBN=(SELECT 1 FROM KHOTHUOC WHERE IDKHO=IDKHOYC AND NVK_LOAIKHO=3 )  FROM YC_PHIEUYCXUAT WHERE IdPhieuYc=" + idkhoachinh;
            
            DataTable dtTest = DataAcess.Connect.GetTable(sqlTestDuyetIn);
            if (dtTest != null && dtTest.Rows.Count > 0) IsKhoBN = dtTest.Rows[0]["IsKhoBN"].ToString();

            if (dtTest != null && dtTest.Rows.Count > 0 && StaticData.IsCheck(dtTest.Rows[0]["IsTheoCD"].ToString())) IsTheoCD = "1";

            if (dtTest != null && dtTest.Rows.Count > 0 && dtTest.Rows[0]["NGAYDUYET"].ToString()=="" && StaticData.IsCheck(dtTest.Rows[0]["ISDUYETIN"].ToString())==false)
            {
                dt.Columns.Add("NgayDuyet");
                dt.Columns.Add("GioDuyet");
                dt.Columns.Add("PhutDuyet");
                string NgayYC = dtTest.Rows[0]["NGAYYC"].ToString();
                DateTime dNgayDuyet = StaticData.Caculate_NgayDuyet(NgayYC);
                dt.Rows[0]["NgayDuyet"] = dNgayDuyet.ToString("dd/MM/yyyy");
                dt.Rows[0]["GioDuyet"] = dNgayDuyet.ToString("HH");
                dt.Rows[0]["PhutDuyet"] = dNgayDuyet.ToString("mm");
            }
            else
                if (dtTest != null && dtTest.Rows.Count > 0 && dtTest.Rows[0]["NGAYDUYET"].ToString() != "" && StaticData.IsCheck(dtTest.Rows[0]["ISDUYETIN"].ToString()) == true   && StaticData.IsCheck(dtTest.Rows[0]["ISDUYETPHAT"].ToString()) == false  
                    && DateTime.Parse(dtTest.Rows[0]["NGAYDUYET"].ToString()).ToString("yyyy-MM-dd")==DateTime.Now.ToString("yyyy-MM-dd")  
                    )
                {
                    dt.Columns.Add("NgayDuyet");
                    dt.Columns.Add("GioDuyet");
                    dt.Columns.Add("PhutDuyet");
                    dt.Rows[0]["NgayDuyet"] = DateTime.Parse(dtTest.Rows[0]["NGAYDUYET"].ToString()).ToString("dd-MM-yyyy");
                    dt.Rows[0]["GioDuyet"] = DateTime.Now.ToString("HH");
                    dt.Rows[0]["PhutDuyet"] = DateTime.Now.ToString("mm");
                }
        }
        else
        {

            dt.Columns.Add("NgayDuyet");
            dt.Columns.Add("GioDuyet");
            dt.Columns.Add("PhutDuyet");
            string NgayYC = StaticData.CheckDate(dt.Rows[0]["NGAYYC"].ToString()) + " " + dt.Rows[0]["GioYc"].ToString() + ":" + dt.Rows[0]["PhutYC"].ToString();
            DateTime dNgayDuyet = StaticData.Caculate_NgayDuyet(NgayYC);
            dt.Rows[0]["NgayDuyet"] = dNgayDuyet.ToString("dd/MM/yyyy");
            dt.Rows[0]["GioDuyet"] = dNgayDuyet.ToString("HH");
            dt.Rows[0]["PhutDuyet"] = dNgayDuyet.ToString("mm");
        }
        
        if (dt != null && dt.Rows.Count > 0)
        {
            
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                html.AppendLine("<data id=\""+dt.Columns[i].ColumnName+"\">" + dt.Rows[0][i].ToString() + "</data>");
            }
            if (IsTheoCD == "1")
            {
                html.AppendLine("<data id=\"" + "IsTheoCD" + "\">" + "1" + "</data>");
            }
            html.AppendLine("<data id=\"" + "IsKhoBN" + "\">" + IsKhoBN + "</data>");
            html.AppendLine("</root>");
            Response.Clear();
            Response.Write(html);
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("");
        }
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    #region Duyệt In
    private void LuuDuyetIn()
    {
        string isDuyet = Request.QueryString["isDuyet"];
        string IdPhieuYc = Request.QueryString["IdPhieuYc"];
        if (string.IsNullOrEmpty(isDuyet) || string.IsNullOrEmpty(IdPhieuYc))
        {
            Response.Clear();
            Response.Write("");//lỗi
            return;
        }
        string UserID = "NULL";
        UserID = SysParameter.UserLogin.UserID(this);
        bool kt = DataAcess.Connect.ExecSQL("update yc_phieuycxuat set IsDuyetIn='"+isDuyet+"',IdNguoiDuyet="+UserID+" where IdPhieuYc='" + IdPhieuYc + "'");
        if (kt)
        {
            Response.Clear();
            Response.Write("1");//Thành công
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("");//lỗi
            return;
        }
    }
    private void luuDuyetInTableYc_PhieuYcXuatChiTiet()
    {
        try
        {
            string IdChiTietYc = Request.QueryString["idkhoachinh"];
            string isDuyet = Request.QueryString["IsDuyetIn"];
            string SoLuongDuyet = Request.QueryString["SoLuongDuyet"];
            if (string.IsNullOrEmpty(SoLuongDuyet))
                SoLuongDuyet = "0";
            string SlTon = Request.QueryString["SlTon"];
            if (string.IsNullOrEmpty(SlTon))
                SlTon = "0";
            string SlDutru = Request.QueryString["SlDutru"];
            if (string.IsNullOrEmpty(SlDutru))
                SlDutru = "0";
            string GhiChu = Request.QueryString["GhiChu"];
            if (!string.IsNullOrEmpty(GhiChu))
                GhiChu = ",GhiChu=N'" + GhiChu + "'";
            else
                GhiChu = "";
            if (!string.IsNullOrEmpty(IdChiTietYc))
            {
                if (isDuyet.ToLower() == "true")
                    isDuyet = "1";
                if (isDuyet.ToLower() == "false")
                    isDuyet = "0";
                string sql = "update Yc_PhieuYcXuatChiTiet set IsDuyetIn=" + isDuyet + ",SoLuongDuyet='" + SoLuongDuyet + "',SlTon='" + SlTon + "',SlDutru='" + SlDutru + "'"+GhiChu+" where IdChiTietYc='" + IdChiTietYc + "'";
                bool kt = DataAcess.Connect.ExecSQL(sql);
                if (kt)
                {
                    Response.Clear(); Response.Write(IdChiTietYc);
                    return;
                }
            }
        }
        catch (Exception)
        {
            
        }
        Response.StatusCode = 500;
    }
    #endregion
    //───────────────────────────────────────────────────────────────────────────────────────
    #region Luu Duyet Phat
    private void LuuDuyetPhat()
    {
        string IdPhieuYc = Request.QueryString["IdPhieuYc"];
        if (string.IsNullOrEmpty(IdPhieuYc))
        {
            Response.Clear();
            Response.Write("");//lỗi
            return;
        }
        bool kt = DataAcess.Connect.ExecSQL("EXEC THUOC_XUATTHUOC_THEOYC "+IdPhieuYc+"",500000);
        if (kt)
        {
            Response.Clear();
            string sql1 = "SELECT MAPHIEUXUAT FROM PHIEUXUATKHO WHERE IdPhieuYc=" + IdPhieuYc;
            DataTable dt = DataAcess.Connect.GetTable(sql1);
            string maphieuxuat = "";
            if (dt != null && dt.Rows.Count > 0)
                maphieuxuat = dt.Rows[0][0].ToString();
            Response.Write(maphieuxuat);//Thành công
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("");//lỗi
            return;
        }
    }
    private void HuyDuyetPhat()
    {
        string IdPhieuYc = Request.QueryString["IdPhieuYc"];
        if (string.IsNullOrEmpty(IdPhieuYc))
        {
            Response.Clear();
            Response.Write("");//lỗi
            return;
        }
        bool kt = DataAcess.Connect.ExecSQL("EXEC THUOC_HUYXUATTHUOC_THEOYC " + IdPhieuYc + "",500000);
        if (kt)
        {
            Response.Clear();
            Response.Write("1");//Thành công
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("");//lỗi
            return;
        }
    }
    #endregion
    //───────────────────────────────────────────────────────────────────────────────────────
    private void GetSoPhieuYC()
    {
        string sqlSelect = "SELECT SOPHIEUYC,idphieuxuat FROM YC_PHIEUYCXUAT WHERE IdPhieuYc=" + Request.QueryString["IdPhieuYc"];
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt == null || dt.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("");
            return;
        }
        Response.Clear();
        Response.Write(dt.Rows[0][0].ToString() +"|"+ dt.Rows[0][1].ToString());
    }
   
}
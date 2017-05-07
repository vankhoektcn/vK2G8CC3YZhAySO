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
using System.IO;

public partial class Yc_PhieuYCTra_ajax : System.Web.UI.Page
{
    protected DataProcess s_Yc_PhieuYCTra()
    {
        DataProcess Yc_PhieuYCTra = new DataProcess("Yc_PhieuYCTra");
        Yc_PhieuYCTra.data("IdPhieuYc", Request.QueryString["idkhoachinh"]);
        string timeYC = "";
        if (Request.QueryString["GioYc"] != null && Request.QueryString["PhutYC"] != null)
            timeYC = " " + Request.QueryString["GioYc"] + ":" + Request.QueryString["PhutYC"];
        Yc_PhieuYCTra.data("NgayYc", Request.QueryString["NgayYc"] + timeYC);


        string timeDuyet = "";
        if (Request.QueryString["GioDuyet"] != null && Request.QueryString["PhutDuyet"] != null)
            timeDuyet = " " + Request.QueryString["GioDuyet"] + ":" + Request.QueryString["PhutDuyet"];
        Yc_PhieuYCTra.data("NgayDuyet", Request.QueryString["NgayDuyet"] + timeDuyet);




        Yc_PhieuYCTra.data("IdKhoYc", Request.QueryString["IdKhoYc"]);
        Yc_PhieuYCTra.data("IdKhoDuyet", Request.QueryString["IdKhoDuyet"]);
        Yc_PhieuYCTra.data("IdNguoiDuyet", Request.QueryString["IdNguoiDuyet"]);
        Yc_PhieuYCTra.data("LoaiThuocID", Request.QueryString["LoaiThuocID"]);

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

        Yc_PhieuYCTra.data("TuNgay", Request.QueryString["TuNgay"] + timeYC_Tungay);
        Yc_PhieuYCTra.data("DenNgay", Request.QueryString["DenNgay"] + timeYC_DenNgay);
        Yc_PhieuYCTra.data("IsTraTienBN", Request.QueryString["IsTraTienBN"]  );
        return Yc_PhieuYCTra;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    protected DataProcess s_Yc_PhieuYCTraChiTiet()
    {
        DataProcess Yc_PhieuYCTraChiTiet = new DataProcess("Yc_PhieuYCTraChiTiet");
        Yc_PhieuYCTraChiTiet.data("IdChiTietYc", Request.QueryString["idkhoachinh"]);
        Yc_PhieuYCTraChiTiet.data("IdPhieuYc", Request.QueryString["IdPhieuYc"]);
        Yc_PhieuYCTraChiTiet.data("IdThuoc", Request.QueryString["IdThuoc"]);
        Yc_PhieuYCTraChiTiet.data("SoLuongYc", Request.QueryString["SoLuongYc"]);
        Yc_PhieuYCTraChiTiet.data("SlTon", Request.QueryString["SlTon"]);
        Yc_PhieuYCTraChiTiet.data("SlDutru", Request.QueryString["SlDutru"]);
        Yc_PhieuYCTraChiTiet.data("GhiChu", Request.QueryString["GhiChu"]);
        Yc_PhieuYCTraChiTiet.data("Status", Request.QueryString["Status"]);
        return Yc_PhieuYCTraChiTiet;
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveYc_PhieuYCTra(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableYc_PhieuYCTraChiTiet": LuuTableYc_PhieuYCTraChiTiet(); break;
            case "loadTableYc_PhieuYcTraChiTiet": loadTableYc_PhieuYCTraChiTiet(false); break;
            case "xoa": XoaYc_PhieuYCTra(); break;
            case "xoaYc_PhieuYcTraChiTiet": XoaYc_PhieuYCTraChiTiet(); break;
            case "IdKhoYcSearch": IdKhoYcSearch(); break;
            case "IdKhoDuyetSearch": IdKhoDuyetSearch(); break;
            case "IdNguoiYcSearch": IdNguoiYcSearch(); break;
            case "IdNguoiDuyetSearch": IdNguoiDuyetSearch(); break;
            case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
            case "IdThuocSearch": IdThuocSearch(); break;
            case "setDefault": setDefault(); break;
            case "LoadDanhSachYCTuChiDinh": loadTableYc_PhieuYCTraChiTiet(true); break;
            case "LuuDuyetTra": LuuDuyetTra(); break;
            case "HuyDuyetTra": HuyDuyetTra(); break;
            case "XuatThuoc_Treo_TheoPhieuTra": XuatThuoc_Treo_TheoPhieuTra(); break;
        }
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void XuatThuoc_Treo_TheoPhieuTra()
    {
        string idPhieuYcTra = Request.QueryString["idPhieuYcTra"];
        string value = "";
        if (!string.IsNullOrEmpty(idPhieuYcTra) && !idPhieuYcTra.Equals("0"))
        {
            bool ok1 = DataAcess.Connect.ExecSQL( "EXEC THUOC_HUYTRATHUOC_TREO_YCTRA " + idPhieuYcTra ,50000);
            bool ok2 = DataAcess.Connect.ExecSQL(" EXEC THUOC_XUAT_TREO_THEOYCTRA  " + idPhieuYcTra, 50000);
            string sql = @"select A.sophieuyc,B.maphieuxuat FROM YC_PHIEUYCTRA A  LEFT JOIN   phieuxuatkho B  ON A.IDPHIEUXUAT=B.IDPHIEUXUAT
                            where A.IDPHIEUYC ='" + idPhieuYcTra + "'";
                DataTable dt = DataAcess.Connect.GetTable(sql);
                if(dt != null && dt.Rows.Count>0)
                    value = dt.Rows[0]["sophieuyc"].ToString() + "@@" + dt.Rows[0]["maphieuxuat"].ToString();
        }
        Response.Clear();
        Response.Write(value);
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

                    html.AppendLine(table.Rows[i]["SoTT"].ToString() + "-" + table.Rows[i]["tenkho"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void IdKhoDuyetSearch()
    {
        string strKhoDuyet = " 1=1 ";
        string IsHongVo = Request.QueryString["IsHongVo"];
        string paraIdKhoNhap = "";
        if(IsHongVo!="1") paraIdKhoNhap=   StaticData.GetParameter("IdKhoNhap");
        else paraIdKhoNhap = StaticData.GetParameter("nvk_idKhoHuHongVo");

        if (!string.IsNullOrEmpty(paraIdKhoNhap))
            strKhoDuyet = " AND idkho in ("+paraIdKhoNhap+") ";

        string IdKho = Request.QueryString["IdKho"];
        if (IdKho != null && IdKho != "")
            strKhoDuyet += " AND IDKHO=" + IdKho;

        DataTable table = DataProcess.GetTable("select * from khothuoc  where 1=1 "+strKhoDuyet+" and  tenkho like N'%" + Request.QueryString["q"] + "%'");
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
        DataTable table = DataProcess.GetTable("select * from Thuoc_LoaiThuoc  where TenLoai like N'%" + Request.QueryString["q"] + "%'");
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
    private void XoaYc_PhieuYCTra()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYCTra();
            string IdPhieuYc = process.getData("IdPhieuYc");
            string sqlTest = "SELECT IsDuyetTra FROM Yc_PhieuYCTra WHERE IdPhieuYc=" + IdPhieuYc;
            DataTable dtTEst = DataAcess.Connect.GetTable(sqlTest);
            if (dtTEst != null && dtTEst.Rows.Count > 0)
            {
                if (StaticData.IsCheck(dtTEst.Rows[0][0].ToString()))
                {
                    Response.StatusCode = 500;
                    return;
                }
            }

            bool ok1 = DataAcess.Connect.ExecSQL("EXEC THUOC_HUYTRATHUOC_TREO_YCTRA " + IdPhieuYc,50000);
            if (!ok1)
            {
                Response.Clear(); Response.StatusCode = 500;
                return;
            }
            bool ok = process.Delete();
            if (ok)
            {
                bool ok2 = DataAcess.Connect.ExecSQL(" DELETE YC_PHIEUYCTRACHITIET WHERE IDPHIEUYC= " + IdPhieuYc);

                Response.Clear(); Response.Write(process.getData("IdPhieuYc"));
                return;
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }
        
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void XoaYc_PhieuYCTraChiTiet()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYCTraChiTiet();
            string IdChiTietYc = process.getData("IdChiTietYc");
            string DeleteOther = " EXEC THUOC_HUYTRATHUOC_TREO_YCTRA_BY_IDCHITIETYC " + IdChiTietYc;
            bool OK2 = DataAcess.Connect.ExecSQL(DeleteOther,50000);

            bool ok = process.Delete();
            if (ok)
            {
                
                Response.Clear(); Response.Write(IdChiTietYc);
                return;
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }
        
    }
    //───────────────────────────────────────────────────────────────────────────────────────
    private void setTimKiem()
    {
        if (Userlogin_new.HavePermision(this, "Yc_PhieuYCTra_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 idkhoachinh=T.IdPhieuYc
                ,T.IdPhieuYc,T.SoPhieuYc,NgayYc=convert(varchar(10),T.NgayYc,103),GioYc=DATEPART(Hh,T.NgayYc),PhutYC=DATEPART(Mi,T.NgayYc)
                ,T.IdKhoYc,T.IdKhoDuyet,T.IdNguoiYc,T.IdNguoiDuyet
                ,NgayDuyet=convert(varchar(10),T.NgayDuyet,103),GioDuyet=DATEPART(Hh,T.NgayDuyet),PhutDuyet=DATEPART(Mi,T.NgayDuyet)
                ,T.IsDuyetTra,T.LoaiThuocID,T.Status,T.idphieuxuat
                   ,mkv_IdKhoYc = A.tenkho
                   ,mkv_IdKhoDuyet = B.tenkho
                   ,mkv_IdNguoiYc = C.tennguoidung
                   ,mkv_IdNguoiDuyet = D.tennguoidung
                   ,mkv_LoaiThuocID = E.TenLoai
                   ,px.maphieuxuat
                    ,TuNgay=convert(varchar(10),T.TuNgay,103),TuGio=DATEPART(Hh,T.TuNgay),TuPhut=DATEPART(Mi,T.TuNgay)
                   ,DenNgay=convert(varchar(10),T.DenNgay,103),DenGio=DATEPART(Hh,T.DenNgay),DenPhut=DATEPART(Mi,T.DenNgay)
                   ,IsTraTienBN 
           
                               from Yc_PhieuYCTra T
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
   
    //───────────────────────────────────────────────────────────────────────────────────────
    private void SaveYc_PhieuYCTra()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYCTra();
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
                    string sqlSaveSoPhieuYC = "EXEC HS_CREATE_MAPHIEUYCTRABYKHO '" + NgayDuyet + "' ," + IdKhoDuyet + " ," + IdPhieuYc + "  ";
                    bool ok1 = DataAcess.Connect.ExecSQL(sqlSaveSoPhieuYC);


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
    public void LuuTableYc_PhieuYCTraChiTiet()
    {
        try
        {
            DataProcess process = s_Yc_PhieuYCTraChiTiet();
            string IdChiTietYc = process.getData("IdChiTietYc");
            if (!string.IsNullOrEmpty(IdChiTietYc))
            {
               
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(IdChiTietYc);
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
    public void loadTableYc_PhieuYCTraChiTiet(bool isGetList)
    {
        bool IsViewSLDuyet = ((Userlogin_new.HavePermision(this, "xetduyet1") || Userlogin_new.HavePermision(this, "xetduyet2")) ?true:false);
        string paging = "";
        bool add = Userlogin_new.HavePermision(this, "Yc_PhieuYCTraChiTiet_Add");
        bool search = Userlogin_new.HavePermision(this, "Yc_PhieuYCTraChiTiet_Search");
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th style='width:50px'>STT</th>");
        html.Append("<th style='width:50px'></th>");
        html.Append("<th style='width:350px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc") + "</th>");
        html.Append("<th  style='width:80px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</th>");
        html.Append("<th  style='width:50px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoLuong") + "</th>");
        html.Append("<th  style='width:100px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SlTon") + "</th>");
        html.Append("<th   style='width:200px' >" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool IsDuyetTra = false;
        if (search)
        {
            DataProcess process = s_Yc_PhieuYCTraChiTiet();
            process.Page = Request.QueryString["page"];
            string sqlYc ="";
            DataTable table = new DataTable();
            #region dtSource . Truong Hop Tu Chi dinh
            if (isGetList && string.IsNullOrEmpty(process.getData("IdPhieuYc")))
            {
                #region Load Danh sach Yeu Cau Tu Chi Dinh
                string IdKhoYc = Request.QueryString["IdKhoYc"];
                DataTable dtTestKhoYC = DataAcess.Connect.GetTable("SELECT NVK_LOAIKHO FROM KHOTHUOC WHERE  IDKHO=" + IdKhoYc);
                if (dtTestKhoYC == null || dtTestKhoYC.Rows.Count == 0) return;
                bool IsKho_BN =  (dtTestKhoYC.Rows[0][0].ToString() == "3");
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
                string NgayYC_save = StaticData.CheckDate(NgayYC.ToString()) + " " + GioYC + ":" + PhutYC + ":00";


                string tungayFull = (!string.IsNullOrEmpty(TuNgay) ? ("  and ISNULL(D.ngayDuTruThuoc, D.ngaykham)>='" + StaticData.CheckDate(TuNgay) + ((!string.IsNullOrEmpty(TuGio) && !string.IsNullOrEmpty(TuPhut)) ? " " + TuGio + ":" + TuPhut + "'" : "'")) : "");
                string dengayFull = (!string.IsNullOrEmpty(DenNgay) ? (" and ISNULL(D.ngayDuTruThuoc, D.ngaykham) <='" + StaticData.CheckDate(DenNgay) + ((!string.IsNullOrEmpty(DenGio) && !string.IsNullOrEmpty(DenPhut)) ? " " + DenGio + ":" + DenPhut + "'" : " 23:59:58:999'")) : "");



                string dkLoaiThuoc = " and B.LoaiThuocID='" + LoaiThuocID + @"'";
                if (LoaiThuocID.Equals("1"))//Gây nghiện
                    dkLoaiThuoc += " and isnull(B.istgn,0)=0 and isnull(B.IsTHTT,0)=0";
                if (LoaiThuocID.Equals("5"))//Gây nghiện
                    dkLoaiThuoc = " and B.LoaiThuocID=1 and B.IsTGN=1";
                if (LoaiThuocID.Equals("6"))//Gây nghiện
                    dkLoaiThuoc = " and B.LoaiThuocID=1 and B.IsTHTT=1";


                sqlYc = @" select STT=row_number() over (order by   TENTHUOC)
                                       ,IdChiTietYc=NULL
									    ,IdPhieuYc=NULL
										,A.IdThuoc
										,SoLuongYc=0
                                        ,slChiDinh=SUM(A.soluongtra)
										,GhiChu=NULL
										,Status=1
                                       , SlTon=" +(IsKho_BN==false ?" DBO.Thuoc_TonKho_PHIEUNHAP(A.IDTHUOC,'" + NgayYC_save+@"',"+IdKhoYc+ @")" : "0")+@" 
                                       ,B.tenthuoc
                                        ,B.tthoatchat
                                        ,UnitID=b.iddvt
                                        ,mkv_UnitID=C.TenDVT
                                        ,IsDuyetTra=0
                               from CHITIETBENHNHANTOATHUOC A
                                    INNER JOIN   thuoc  B on A.IdThuoc=B.idthuoc
                                    left join thuoc_donvitinh  C on C.id=B.iddvt
									LEFT JOIN KHAMBENH D ON A.IDKHAMBENH=D.IDKHAMBENH
									WHERE ISNULL( A.soluongtra,0)>0  AND ISNULL(IsDaNhapTheoYC,0)=0"
                                        + tungayFull
                                        +dengayFull
				                        +"  AND A.IDKHO="+IdKhoYc 
                                        +dkLoaiThuoc
                                        +@"
								GROUP BY  							 
										A.IdThuoc
                                       ,B.tenthuoc
                                        ,B.tthoatchat
                                        ,b.iddvt
                                        ,C.TenDVT
                                    
                   ";

                #region set SoLuong co the Yc
                table = DataAcess.Connect.GetTable(sqlYc);
                if (table != null && table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        float slChiDinh = StaticData.ParseFloat(table.Rows[i]["slChiDinh"]);
                        float slCoTheXuat = StaticData.ParseFloat(table.Rows[i]["SlTon"]);
                        if (IsKho_BN)
                            slCoTheXuat = slChiDinh;
                        float slYeuCau = (slChiDinh > slCoTheXuat ? slCoTheXuat : slChiDinh);
                        table.Rows[i]["SoLuongYc"] = slYeuCau;
                    }
                }
                #endregion
            }
                #endregion
            #endregion

            #region dtSource. TH Binh Thuong
            else
            {

                sqlYc = @"select STT=row_number() over (order by  isnull(nvk_UuTienYL,100),TENDVT,tenthuoc)
                                       ,T.IdChiTietYc,T.IdPhieuYc,T.IdThuoc,T.SoLuongYc,T.GhiChu,T.Status
                                       ,T.SlTon,T.SlDutru,T.TonPhat,T.DutruPhat
                                       ,A.SoPhieuYc
                                       ,B.tenthuoc
                                        ,B.tthoatchat
                                        ,UnitID=b.iddvt
                                        ,mkv_UnitID=dvt.TenDVT
                                        ,A.IsDuyetTra
                               from Yc_PhieuYCTraChiTiet T
                                left join Yc_PhieuYCTra  A on T.IdPhieuYc=A.IdPhieuYc
                                left join thuoc  B on T.IdThuoc=B.idthuoc
                                left join thuoc_donvitinh  dvt on dvt.id=B.iddvt
                            where T.IdPhieuYc='" + process.getData("IdPhieuYc") + "'";
                table = process.Search(sqlYc);
            }
            #endregion
          
            if (table != null && table.Rows.Count > 0)
            {
                paging = process.Paging("Yc_PhieuYCTraChiTiet");
                bool delete0 = Userlogin_new.HavePermision(this, "Yc_PhieuYCTraChiTiet_Delete");
                bool edit0 = Userlogin_new.HavePermision(this, "Yc_PhieuYCTraChiTiet_Edit");
                IsDuyetTra = StaticData.IsCheck( table.Rows[0]["IsDuyetTra"].ToString());
                if (IsDuyetTra) delete0 = edit0 = false;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    bool edit = edit0; 
                    bool delete = delete0; 
                    html.Append("<tr>");
                    html.Append("<td style='width:50px'>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td style='width:50px' ><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value='" + table.Rows[i]["IdThuoc"] + "'/><input mkv='true' id='mkv_IdThuoc' type='text' style='width: 350px;' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='IdThuocSearch(this,1);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='UnitID' type='hidden' value='" + table.Rows[i]["UnitID"] + "'/><input mkv='true' id='mkv_UnitID' type='text' style='width: 80px;' value='" + table.Rows[i]["mkv_UnitID"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='SoLuongYc' type='text' style='width: 50px;text-align: right;' value='" + table.Rows[i]["SoLuongYc"].ToString() + "' onblur='KiemTraTonYC(this);TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append(@"<td><input mkv='true' id='SlTon' disabled type='text' style='width: 100px;text-align: right;' value='" + table.Rows[i]["SlTon"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='GhiChu' type='text'    style='width:200px'   value='" + table.Rows[i]["GhiChu"].ToString() + "' /></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["IdChiTietYc"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (IsDuyetTra) add = false;

        if (add && !isGetList)
        {
            html.Append("<tr>");
            html.Append("<td style='width:50px' >1</td>");
            html.Append("<td   style='width:50px'  ><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='IdThuoc' type='hidden' value=''/><input mkv='true' id='mkv_IdThuoc' type='text' style='width: 350px;' value='' onfocus='IdThuocSearch(this,1);' class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='UnitID' type='hidden' value=''/><input mkv='true' id='mkv_UnitID' type='text' style='width: 80px;' value='' /></td>");
            html.Append("<td><input mkv='true' id='SoLuongYc' style='width: 50px;text-align: right;' type='text' value='' onblur='KiemTraTonYC(this);TestSo(this,false,false);' /></td>");
            html.Append(@"<td><input mkv='true' id='SlTon' disabled style='width: 100px;text-align: right;' type='text' value='' onblur='TestSo(this,false,false);' /></td>");
            html.Append("<td><input mkv='true' id='GhiChu' type='text' value=''   style='width:200px'   /></td>");
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
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        bool perDuyetTra = Userlogin_new.HavePermision(this, "xetduyet1");
        string sql = @"select perDuyetTra=" + (perDuyetTra ? "1" : "0")
                                      + (idkhoachinh != null && idkhoachinh != "" && idkhoachinh != "0" ? "" : ",NgayYc=convert(varchar(10),getdate(),103),GioYc=DATEPART(Hh,getdate()),PhutYC=DATEPART(Mi,getdate())");
        DataTable dt = DataAcess.Connect.GetTable(sql);

        if (idkhoachinh != null && idkhoachinh != "" && idkhoachinh != "0")
        {
            string sqlTestDuyetIn = "SELECT ISDUYETTRA,NGAYYC,NGAYDUYET  FROM YC_PHIEUYCTRA WHERE IDPHIEUYC=" + idkhoachinh;
            DataTable dtTest = DataAcess.Connect.GetTable(sqlTestDuyetIn);
            if (dtTest != null && dtTest.Rows.Count > 0 && dtTest.Rows[0]["NGAYDUYET"].ToString() == "" && StaticData.IsCheck(dtTest.Rows[0]["ISDUYETTRA"].ToString())== false)
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
   
    #region LuuDuyetTra
    private void LuuDuyetTra()
    {
        string IdPhieuYc = Request.QueryString["IdPhieuYc"];
        if (string.IsNullOrEmpty(IdPhieuYc))
        {
            Response.Clear();
            Response.Write("");//lỗi
            return;
        }
        string UserID = "NULL";
        UserID = SysParameter.UserLogin.UserID(this);
        string NgayDuyet = Request.QueryString["NgayDuyet"];
        string GioDuyet = Request.QueryString["GioDuyet"];
        string PhutDuyet = Request.QueryString["PhutDuyet"];
        if (!string.IsNullOrEmpty(NgayDuyet))
            NgayDuyet = StaticData.CheckDate(Request.QueryString["NgayDuyet"].ToString());
        if (!string.IsNullOrEmpty(NgayDuyet) && !string.IsNullOrEmpty(GioDuyet) && !string.IsNullOrEmpty(PhutDuyet))
            NgayDuyet += " " + GioDuyet + ":" + PhutDuyet;
        if (string.IsNullOrEmpty(NgayDuyet))
            NgayDuyet = " ,ngayduyet=getdate() ";
        else
            NgayDuyet = " ,ngayduyet='" + NgayDuyet + "'";
 

        bool kt = DataAcess.Connect.ExecSQL("EXEC THUOC_TRATHUOC_THEOYC "+IdPhieuYc+"",50000);
        if (kt)
        {
            bool kt2 = DataAcess.Connect.ExecSQL("update yc_phieuyctra set IsDuyetTra=1 " + NgayDuyet + ",IdNguoiDuyet=" + UserID + " where IdPhieuYc='" + IdPhieuYc + "'");
            Response.Clear();
            string sql1 = "SELECT MAPHIEUXUAT FROM PHIEUXUATKHO WHERE IdPhieuYcTra=" + IdPhieuYc;
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
    private void HuyDuyetTra()
    {
        string IdPhieuYc = Request.QueryString["IdPhieuYc"];
        if (string.IsNullOrEmpty(IdPhieuYc))
        {
            Response.Clear();
            Response.Write("");//lỗi
            return;
        }
        bool kt = DataAcess.Connect.ExecSQL("EXEC THUOC_HUYTRATHUOC_THEOYC " + IdPhieuYc + "");
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

    

}
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

public partial class HS_BangGiaThuoc_View_ajax : System.Web.UI.Page
{
    protected DataProcess s_HS_BANGGIATHUOC_VIEW()
    {
        DataProcess HS_BANGGIATHUOC_VIEW = new DataProcess("HS_BANGGIATHUOC_VIEW");
        HS_BANGGIATHUOC_VIEW.data("ID", Request.QueryString["idkhoachinh"]);
        HS_BANGGIATHUOC_VIEW.data("IDTHUOC", Request.QueryString["IDTHUOC"]);
        HS_BANGGIATHUOC_VIEW.data("NGAYHETHAN", Request.QueryString["NGAYHETHAN"]);
        HS_BANGGIATHUOC_VIEW.data("LOSANXUAT", Request.QueryString["LOSANXUAT"]);
        HS_BANGGIATHUOC_VIEW.data("dongia", (Request.QueryString["dongia"] != null && Request.QueryString["dongia"] != "" ? Request.QueryString["dongia"].Replace(".", "").Replace(",", ".") : ""));
        HS_BANGGIATHUOC_VIEW.data("vat", Request.QueryString["vat"]);
        HS_BANGGIATHUOC_VIEW.data("DonGiaView", (Request.QueryString["DonGiaView"] != null && Request.QueryString["DonGiaView"] != "" ? Request.QueryString["DonGiaView"].Replace(".", "").Replace(",", ".") : ""));
        HS_BANGGIATHUOC_VIEW.data("IDCHITIETPHIEUNHAPS", Request.QueryString["IDCHITIETPHIEUNHAPS"]);
        return HS_BANGGIATHUOC_VIEW;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "TimKiem": TimKiem(); break;
            case "IDTHUOCSearch": IDTHUOCSearch(); break;
            case "IdLoaiThuocSearch": IdLoaiThuocSearch(); break;
            case "setIdKho": setIdKho(); break;
            case "idkhoSearch": idkhoSearch(); break;
            case "XuatExcel": XuatExcel(); break;
            case "luuTable": LuuTable_BANGGIATHUOC(); break;

        }
    }
    private void idkhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void IDTHUOCSearch()
    {
        string TenThuoc = Request.QueryString["q"].ToString();
        string LoaiThuocID = Request.QueryString["IdLoaiThuoc"].ToString();
        string sqlSelectThuoc = "SELECT * FROM THUOC WHERE ISTHUOCBV=1 AND TENTHUOC LIKE N'" + TenThuoc + "%'";
        if (LoaiThuocID != "")
            sqlSelectThuoc += " AND LoaiThuocID=" + LoaiThuocID;
        sqlSelectThuoc += " ORDER BY TENTHUOC";

        DataTable table = DataAcess.Connect.GetTable(sqlSelectThuoc);
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
    private void IdLoaiThuocSearch()
    {
        DataTable table = Thuoc_Process.Thuoc_LoaiThuoc.dtGetAll();

        string GroupID = SysParameter.UserLogin.GroupID(this);
        if (GroupID == "8")
        {
            table.DefaultView.RowFilter = "LoaiThuocID=1";
            table = table.DefaultView.ToTable();
        }
        if (GroupID == "9")
        {
            table.DefaultView.RowFilter = "LoaiThuocID=1";
            table = table.DefaultView.ToTable();
        }

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
    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "chitietphieunhapkho_Search"))
        {
            bool add = Userlogin_new.HavePermision(this, "chitietphieunhapkho_Add");
            bool delete = Userlogin_new.HavePermision(this, "chitietphieunhapkho_Delete");
            bool edit = Userlogin_new.HavePermision(this, "chitietphieunhapkho_Edit");

            string IDKHO_NHAP = Request.QueryString["IDKHO_NHAP"];
            string denngay = Request.QueryString["denngay"];
            string tungay = Request.QueryString["tungay"];
            string LoaiThuocID = Request.QueryString["IdLoaiThuoc"];
            string iIDTHUOC = Request.QueryString["IDTHUOC"];
            string[] arrDenNgay = denngay.Split(',');
            if (arrDenNgay.Length > 1)
                denngay = arrDenNgay[0];

            if (tungay != null && tungay != "" && tungay.Length >= 10)
            {
                tungay = StaticData.CheckDate(tungay);
            }
            if (denngay != null && denngay != "" && denngay.Length >= 10)
            {
                denngay = StaticData.CheckDate(denngay) + " 23:59:59";
            }
            DataAcess.Connect.ExecSQL("DELETE HS_BANGGIATHUOC_VIEW");
            string sqlSelect = @" 
                        SELECT DISTINCT T.IDTHUOC
                               ,B.TenThuoc
                               ,C.TenDVT
                                ,T.LOSANXUAT
                                ,NGAYHETHAN=ISNULL(CONVERT(VARCHAR(10),T.NGAYHETHAN,103),'')
                               ,T.dongia
                               ,T.vat
                               ,DonGiaView=ROUND( DonGia*(100.0+isnull(T.VAT,0))/100,0)
                               ,SLTon=0.0
                               ,IDCHITIETPHIEUNHAPS=''
                               ,NGAYTHANG_NHAP2=T.NGAYTHANG_NHAP 
                               ,KHONHAP=tenkho
                               ,T.IDCHITIETPHIEUNHAPKHO
                               ,T.SOLUONG
                               ,SLXUAT=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUNHAPKHO=T.IDCHITIETPHIEUNHAPKHO),0)
                            
                    from chitietphieunhapkho T
                    left join phieunhapkho  A on T.idphieunhap=A.idphieunhap
                    left join thuoc  B on T.IDTHUOC=B.IDTHUOC 
                    left join Thuoc_DonViTinh  C on b.iddvt=C.Id
                    left join khothuoc k on t.idkho_nhap=k.idkho AND ( K.NVK_LOAIKHO=2  OR K.IDKHO=4)
                where 1=1 
                        AND B.ISTHUOCBV=1" + "\r\n";

            if (IDKHO_NHAP != null && IDKHO_NHAP != "")
                sqlSelect += " AND T.IDKHO_NHAP=" + IDKHO_NHAP + "\r\n";
            if (LoaiThuocID != null && LoaiThuocID != "")
                sqlSelect += " AND B.LOAITHUOCID=" + LoaiThuocID;
            if (iIDTHUOC != null && iIDTHUOC != "")
                sqlSelect += " AND T.IDTHUOC=" + iIDTHUOC;
            if (denngay != null && denngay != "" && denngay.Length >= 10)
            {
                sqlSelect += " AND A.NgayThang<='" + denngay + "'";
            }
            if (tungay != null && tungay != "" && tungay.Length >= 10)
            {
                sqlSelect += " AND A.NgayThang>='" + tungay + "'";
            }
            sqlSelect += " ORDER BY B.TENTHUOC";
            DataTable table = new DataTable();
                    table.Columns.Add("ID");
                    table.Columns.Add("IDTHUOC");
                    table.Columns.Add("TenThuoc");
                    table.Columns.Add("TenDVT");
                    table.Columns.Add("LOSANXUAT");
                    table.Columns.Add("NGAYHETHAN");
                    table.Columns.Add("dongia");
                    table.Columns.Add("vat");
                    table.Columns.Add("DonGiaView");
                    table.Columns.Add("SLTon");
                    table.Columns.Add("IDCHITIETPHIEUNHAPS");
                    table.Columns.Add("NGAYTHANG_NHAP2");
                    table.Columns.Add("KHONHAP");
                    table.Columns.Add("INFOR_PHIEUNHAP");
            DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
            if (dt != null )
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string IDTHUOC = dt.Rows[i]["IDTHUOC"].ToString();
                    string TenThuoc=dt.Rows[i]["TenThuoc"].ToString();
                    string TenDVT=dt.Rows[i]["TenDVT"].ToString();
                    string LOSANXUAT=dt.Rows[i]["LOSANXUAT"].ToString();
                    string NGAYHETHAN=dt.Rows[i]["NGAYHETHAN"].ToString();
                    string dongia=dt.Rows[i]["dongia"].ToString();
                    string vat=dt.Rows[i]["vat"].ToString();
                    string DonGiaView=dt.Rows[i]["DonGiaView"].ToString();
                    string SLTon=dt.Rows[i]["SLTon"].ToString();
                    string IDCHITIETPHIEUNHAPS=dt.Rows[i]["IDCHITIETPHIEUNHAPS"].ToString();
                    string NGAYTHANG_NHAP2 =DateTime.Parse( dt.Rows[i]["NGAYTHANG_NHAP2"].ToString()).ToString("dd/MM/yyyy");
                    string KHONHAP=dt.Rows[i]["KHONHAP"].ToString();
                    string SLXUAT = dt.Rows[i]["SLXUAT"].ToString();
                    string SOLUONG = dt.Rows[i]["SOLUONG"].ToString();
                    string IDCHITIETPHIEUNHAPKHO = dt.Rows[i]["IDCHITIETPHIEUNHAPKHO"].ToString();
                    if(SOLUONG=="")SOLUONG="0";
                    if(SLXUAT=="")SLXUAT="0";
                    if(double.Parse(SOLUONG)>double.Parse(SLXUAT))
                    {
                            int n = StaticData.int_Search(table, "IDTHUOC=" + IDTHUOC +" AND LOSANXUAT='"+LOSANXUAT+"'" +" AND NGAYHETHAN='"+NGAYHETHAN+"' AND DONGIA='"+dongia+"' AND VAT='"+vat+"'");
                            if (n == -1)
                            {
                                DataRow R = table.NewRow();
                                R["IDTHUOC"] = IDTHUOC;
                                R["TenThuoc"] = TenThuoc;
                                R["TenDVT"] = TenDVT;
                                R["LOSANXUAT"] = LOSANXUAT;
                                R["NGAYHETHAN"] = NGAYHETHAN;
                                R["dongia"] = dongia;
                                R["vat"] = vat;
                                R["DonGiaView"] = DonGiaView;
                                //R["SLTon"] = double.Parse(SOLUONG) - double.Parse(SLXUAT);
                                R["IDCHITIETPHIEUNHAPS"] = IDCHITIETPHIEUNHAPKHO;
                                R["NGAYTHANG_NHAP2"] = NGAYTHANG_NHAP2;
                                R["KHONHAP"] = KHONHAP;
                                table.Rows.Add(R);
                            }
                            else
                            {
                                DataRow R1 = table.Rows[n];
                                //R1["SLTon"] =double.Parse( R1["SLTon"].ToString())+  double.Parse(SOLUONG) - double.Parse(SLXUAT);
                                R1["IDCHITIETPHIEUNHAPS"] =R1["IDCHITIETPHIEUNHAPS"].ToString()+","+ IDCHITIETPHIEUNHAPKHO;
                                if (R1["NGAYTHANG_NHAP2"].ToString().IndexOf(NGAYTHANG_NHAP2)==-1)
                                {
                                    string[] arrNgayThang = R1["NGAYTHANG_NHAP2"].ToString().Split('-');
                                    string MinNgay = arrNgayThang[0];
                                    string MaxNgay = arrNgayThang[0];
                                    if (arrNgayThang.Length > 1) MaxNgay = arrNgayThang[1];
                                    string   NgayThangNhap = StaticData.CheckDate(NGAYTHANG_NHAP2);
                                    if (DateTime.Parse( NgayThangNhap) <DateTime.Parse( StaticData.CheckDate(MinNgay)))
                                        MinNgay = NGAYTHANG_NHAP2;
                                    if (DateTime.Parse( NgayThangNhap) > DateTime.Parse( StaticData.CheckDate(MaxNgay)))
                                        MaxNgay = NGAYTHANG_NHAP2;
                                    R1["NGAYTHANG_NHAP2"] = MinNgay + "-" + MaxNgay;
                                }

                                R1["KHONHAP"] =(R1["KHONHAP"].ToString().IndexOf(KHONHAP)==-1? R1["KHONHAP"].ToString()+","+ KHONHAP : R1["KHONHAP"].ToString());
                            }
                    }
                }
            }

            DataProcess process = s_HS_BANGGIATHUOC_VIEW();
            process.Page = Request.QueryString["page"];
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }//end void
    private void setIdKho()
    {
        StaticData.SetDefaultIdKho(this, "IDKHO_NHAP", "mkv_IDKHO_NHAP", "IdLoaiThuoc", "mkv_IdLoaiThuoc");
    }
    profess_Rpt_BangGiaThuoc NXTReport = null;
    private void XuatExcel()
    {
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string tungay = Request.QueryString["tungay"];
        string denngay = Request.QueryString["denngay"];
        string IdKho = Request.QueryString["IdKho"];
        string TenKho = Request.QueryString["TenKho"];

        NXTReport = new profess_Rpt_BangGiaThuoc();
        NXTReport.LoaiThuocID = LoaiThuocID;
        NXTReport.IdKho = IdKho;
        NXTReport.TenKho = TenKho;
        NXTReport.FromDate = StaticData.CheckDate(tungay);
        NXTReport.ToDate = StaticData.CheckDate(denngay) + " 23:59:59";
        NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        NXTReport.ExportToExcel();

    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
    private void LuuTable_BANGGIATHUOC()
    {
        try
        {
                    DataProcess process = s_HS_BANGGIATHUOC_VIEW();
                    string IDTHUOC = process.getData("IDTHUOC");
                    string IDCHITIETPHIEUNHAPS = process.getData("IDCHITIETPHIEUNHAPS");
                    string NGAYHETHAN = process.getData("NGAYHETHAN");
                    string LOSANXUAT = process.getData("LOSANXUAT");
                    string dongia = process.getData("dongia");
                    string vat = process.getData("vat");
                    string DonGiaView = process.getData("DonGiaView");
                    if (dongia == "") dongia = "0";
                    if (vat == "") vat = "0";
                    if (DonGiaView == "") DonGiaView = "0";
                    if (NGAYHETHAN != null && NGAYHETHAN != "")
                    {
                        NGAYHETHAN = StaticData.CheckDate(NGAYHETHAN);
                    }
                    
                    string sqlUpdate1 = "UPDATE CHITIETPHIEUNHAPKHO SET LOSANXUAT='" + LOSANXUAT + "'";
                    if (NGAYHETHAN != null && NGAYHETHAN != "")
                    {
                        sqlUpdate1 += ", NGAYHETHAN='" + NGAYHETHAN + "'";
                    }
                    sqlUpdate1 += " , DONGIA='" + dongia + "'";
                    sqlUpdate1 += " , vat='" + vat + "'";
                    sqlUpdate1 += " , thanhtientruocthue=" + dongia + "*soluong";
                    sqlUpdate1 += " , thanhtien=" + DonGiaView + "*soluong";
                    sqlUpdate1 += " WHERE IDCHITIETPHIEUNHAPKHO IN (" + IDCHITIETPHIEUNHAPS + ")";
                    bool OK2 = DataAcess.Connect.ExecSQL(sqlUpdate1);


                    string sqlUpdate2 = "UPDATE CHITIETPHIEUXUATKHO SET LOSANXUAT_XUAT='" + LOSANXUAT + "'";
                    if (NGAYHETHAN != null && NGAYHETHAN != "")
                    {
                        sqlUpdate2 += ", NGAYHETHAN_XUAT='" + NGAYHETHAN + "'";
                    }
                    sqlUpdate2 += " , DONGIA='" + dongia + "'";
                    sqlUpdate2 += " , vat='" + vat + "'";
                    sqlUpdate2 += " , thanhtientruocthue=" + dongia + "*soluong";
                    sqlUpdate2 += " , thanhtien=" + DonGiaView + "*soluong";
                    sqlUpdate2 += " WHERE IDCHITIETPHIEUNHAPKHO IN (" + IDCHITIETPHIEUNHAPS + ")";
                    bool OK3 = DataAcess.Connect.ExecSQL(sqlUpdate2);

                    Response.Clear();
                    return;
        }
        catch
        {
            Response.StatusCode = 500;
        }
    }
}//end class



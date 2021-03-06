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
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;


public partial class frm_PhieuChuyenKho_Crpt : Genaratepage
{
    ReportDocument report;
    int idloaiphieuxuat = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        int idphieuxuat = StaticData.ParseInt(Request.QueryString["idphieuxuat"]);
        int idbenhnhan = StaticData.ParseInt(Request.QueryString["idbenhnhan"]);
        idloaiphieuxuat = 0;
        if (idphieuxuat != 0)
            idloaiphieuxuat = StaticData.ParseInt(StaticData.GetValue("phieuxuatkho", "idphieuxuat", idphieuxuat, "loaixuat"));
        loadphieuxuat(idphieuxuat);
        if (IsPostBack)
        {
            loadphieuxuat(idphieuxuat);
        }
    }

    
    
    private void loadphieuxuat(int idphieuxuat)
    {
        //#region Nếu có phiếu xuất trả khoa dược riêng
        //string sqlTest = "SELECT IDKHO2 ,LOAIXUAT FROM PHIEUXUATKHO WHERE IDPHIEUXUAT=" +( idphieuxuat.ToString());
        //DataTable dtTest = DataAcess.Connect.GetTable(sqlTest);
        //if (dtTest == null || dtTest.Rows.Count == 0) return;
        //if (dtTest.Rows[0]["IdKHo2"].ToString()==StaticData.GetParameter("KhoNhapMuaID")
        //    && dtTest.Rows[0]["LoaiXuat"].ToString()=="4"
        //    && StaticData.GetParameter("HavePhieuXuatTra") == "1"
        //    )
        //{
        //    return;
        //}
        //#endregion
        #region  load chi tiet phieu xuat
        string IsGiaBan = ( Request.QueryString["IsGiaBan"]!=null ?  Request.QueryString["IsGiaBan"].ToString():"0");
        string Gia_Columns="GiaVon";
        if (IsGiaBan != null && IsGiaBan != "" && IsGiaBan != "0")
            Gia_Columns = "DonGia";

        string sqlctpxt = " ";
        if (StaticData.BieuMauPhieuXuat == "1")
        {
            sqlctpxt = "SELECT DISTINCT row_number() over (order by tenthuoc) as STT, TenNhanHieu=TENTHUOC, MASO=C.sttindm05,";
            sqlctpxt += " DonViTinh=TENDVT,TheoChungTu=sum( SoLuong),";
            sqlctpxt += " ThucNhap=sum( SoLuong),";
            sqlctpxt += " DonGia=A." + Gia_Columns + ",";
            sqlctpxt += " ThanhTien=sum( A.SoLuong*A." + Gia_Columns + ")";
            sqlctpxt += " From Chitietphieuxuatkho a";
            sqlctpxt += " left join Thuoc C on A.Idthuoc=C.Idthuoc";
            sqlctpxt += " left join Thuoc_DonViTinh D on C.IdDVT=D.ID";
            sqlctpxt += " left join  PhieuXuatKho G on A.IdPhieuXuat=G.IdPhieuXuat";
            sqlctpxt += " where A.IdPhieuXuat=" + idphieuxuat;
            sqlctpxt += " group by 	TENTHUOC,  TENDVT,   A." + Gia_Columns + ",sttindm05";
        }

        else
        {
            sqlctpxt = "SELECT   row_number() over (order by tenthuoc) as STT, TenNhanHieu=TENTHUOC, MASO=C.sttindm05,";
            sqlctpxt += " DonViTinh=TENDVT,TheoChungTu=(SELECT SUM(SoLuong) FROM Thuoc_ChiTietPhieuYCXuat WHERE A.IDCHITIETPHIEUYEUCAUXUATKHO=IdChiTietPhieuYC),H.ngayhethan,losanxuat,";
            sqlctpxt += " ThucNhap= A.SoLuong,";
            sqlctpxt += " DonGia=A." + Gia_Columns + ",";
            sqlctpxt += " ThanhTien= A.SoLuong*A." + Gia_Columns + "";
            sqlctpxt += " From Chitietphieuxuatkho a";
            sqlctpxt += " left join Thuoc C on A.Idthuoc=C.Idthuoc";
            sqlctpxt += " left join Thuoc_DonViTinh D on C.IdDVT=D.ID";
            sqlctpxt += " left join  PhieuXuatKho G on A.IdPhieuXuat=G.IdPhieuXuat";
            sqlctpxt += " left join  ChiTietPhieuNhapKho H on A.IdChiTietPhieuNhapKho=H.IdChiTietPhieuNhapKho";
            sqlctpxt += " where A.IdPhieuXuat=" + idphieuxuat;
            
        }
        DataTable dtCTPhieuXuat = DataAcess.Connect.GetTable(sqlctpxt);
        #endregion
        #region set paramaters
        int tongtien = 0;
        for (int j = 0; j < dtCTPhieuXuat.Rows.Count; j++)
        {
            tongtien = tongtien + StaticData.ParseInt(dtCTPhieuXuat.Rows[j]["ThanhTien"].ToString());
        }
        string sqlctpx = "  select kt.tenkho,tenkho2=kt2.tenkho,nd.tennguoidung,kh.tenkhachhang,kh.diachi ,px.maphieuxuat,nguoinhan,ghichu,TenReport,TenNhacungCap,idloaixuat=px.loaixuat from phieuxuatkho px";
            sqlctpx+=" left join khothuoc kt on kt.idkho=px.idkho";
            sqlctpx += " left join khothuoc kt2 on kt2.idkho=px.idkho2";
            sqlctpx+=" left join nguoidung nd on nd.idnguoidung=px.idnguoixuat";
            sqlctpx += " left join khachhang kh on kh.idkhachhang=px.idkhachhang";
            sqlctpx += " left join thuoc_loaixuat lx on lx.idloaixuat=px.loaixuat";
            sqlctpx += " left join NhaCungCap cc on cc.NhaCungCapid=px.idNhaCungCap";

            sqlctpx+=" where IdPhieuXuat="+ idphieuxuat;
            DataTable dtctpx = DataAcess.Connect.GetTable(sqlctpx);
            if (dtctpx.Rows.Count < 1) return;

            report = new ReportDocument();
            report.Load(Server.MapPath("CrptDesign/crpt_PhieuXuatChuyenKho.rpt"));
            report.SetDataSource(dtCTPhieuXuat);
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.DataBind();

            string tenkho = dtctpx.Rows[0]["tenkho"].ToString();
            string tenkho2 = dtctpx.Rows[0]["tenkho2"].ToString();
            string tennguoidung = dtctpx.Rows[0]["tennguoidung"].ToString();
            string tenkhachhang = dtctpx.Rows[0]["tenkhachhang"].ToString();
            string TenNhaCungcap = dtctpx.Rows[0]["TenNhaCungCap"].ToString();
            string diachi = dtctpx.Rows[0]["diachi"].ToString();
            string maphieuxuat = dtctpx.Rows[0]["maphieuxuat"].ToString();
            string loaixuat = dtctpx.Rows[0]["TenReport"].ToString();
            string idloaixuat = dtctpx.Rows[0]["idloaixuat"].ToString();

            report.SetParameterValue("sophieu", maphieuxuat.ToString());
            report.SetParameterValue("NguoiLapPhieu", "");
            report.SetParameterValue("diachibophan",diachi);
            report.SetParameterValue("Nguoinhan","");
            report.SetParameterValue("thukho","");
            report.SetParameterValue("khothuoc",tenkho);

            if (idloaixuat == "1")
                tenkho2 = tenkhachhang;
            if (idloaixuat == "3")
                tenkho2 = TenNhaCungcap;

            report.SetParameterValue("kho2", tenkho2);
            report.SetParameterValue("LydoXuatKho", dtctpx.Rows[0]["ghichu"].ToString());
            report.SetParameterValue("DiaChiBophan", "Khoa dược");
            report.SetParameterValue("TruongKhoa","");
            string bangchu = new clsDocSoTien().ReadNumToString(tongtien.ToString());
            report.SetParameterValue("docthanhtien", bangchu);
            string ngaythang= DateTime.Now.ToString("dd/MM/yyyy");
            string ngay = DateTime.Now.ToString("dd");
            string thang = DateTime.Now.ToString("MM");
            string nam = DateTime.Now.ToString("yyyy");
            report.SetParameterValue("NgayThangNam","Ngày "+ngay +" tháng "+thang+"  năm "+nam);
            report.SetParameterValue("MaDonVi", StaticData.MaDonViKhoaDuoc);
            report.SetParameterValue("TenDonVi", StaticData.TenCty);
            report.SetParameterValue("ReportHeader", loaixuat);
         
            #endregion
    }
    #region get ten nguoi xuat
    private string gettennguoixuat(int idnguoidung)
    {
        DataTable dt = DataAcess.Connect.GetTable("select * from nguoidung where idnguoidung = " + idnguoidung);
        if (dt != null && dt.Rows.Count > 0)
        {
            return dt.Rows[0]["tennguoidung"].ToString();
        }
        else
        {
            return null;
        }
    }
    #endregion
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        if (report != null)
        {
            report.Clone();
            report.Dispose();
            CrystalReportViewer1.Dispose();
            GC.Collect();
        }
    }
    protected void form_unload(object sender, EventArgs e)
    {
        if (report != null)
        {
            report.Clone();
            report.Dispose();
            report = null;
            CrystalReportViewer1.Dispose();
            CrystalReportViewer1 = null;
            GC.Collect();
        }
    }
    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(form_unload);
    }
    #endregion
}

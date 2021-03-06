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


public partial class frm_PhieuNhapKho_Crpt : Genaratepage
{
    ReportDocument report;
    protected void Page_Load(object sender, EventArgs e)
    {
        int idphieuxuat = StaticData.ParseInt(Request.QueryString["idphieunhap"]);
        int idbenhnhan = StaticData.ParseInt(Request.QueryString["idbenhnhan"]);
        loadphieunhap(idphieuxuat);
        if (IsPostBack)
        {
            loadphieunhap(idphieuxuat);
        }
    }



    private void loadphieunhap(int idphieunhap)
    {
        #region  load chi tiet phieu xuat
        string IsGiaBan = ( Request.QueryString["IsGiaBan"]!=null ?  Request.QueryString["IsGiaBan"].ToString():"0");
        string Gia_Columns = "DonGia";
        if (IsGiaBan != null && IsGiaBan != "" && IsGiaBan != "0")
            Gia_Columns = "DonGia";

        string sqlctpxt = " ";        
        //sqlctpxt = "SELECT   row_number() over (order by tenthuoc) as STT, TenNhanHieu=TENTHUOC, MASO=C.sttindm05,";
        //sqlctpxt += " DonViTinh=TENDVT,TheoChungTu=''";
        //sqlctpxt += " ThucNhap= A.SoLuong,";
        //sqlctpxt += " DonGia=A." + Gia_Columns + ",";
        //sqlctpxt += " ThanhTien= A.SoLuong*A." + Gia_Columns + "";
        //sqlctpxt += " From Chitietphieuxuatkho a";
        //sqlctpxt += " left join Thuoc C on A.Idthuoc=C.Idthuoc";
        //sqlctpxt += " left join Thuoc_DonViTinh D on C.IdDVT=D.ID";
        //sqlctpxt += " left join  PhieuXuatKho G on A.IdPhieuXuat=G.IdPhieuXuat";
        //sqlctpxt += " left join  ChiTietPhieuNhapKho H on A.IdChiTietPhieuNhapKho=H.IdChiTietPhieuNhapKho";
        //sqlctpxt += " where A.IdPhieuXuat=" + idphieuxuat;

        string sqlctpn = "select row_number() over (order by tenthuoc) as STT,TenNhanHieu=t.tenthuoc";
        sqlctpn += ",MASO=t.sttindm05,DonViTinh=dvt.TENDVT";
        sqlctpn += ",sum(ctp.soluong) as thucnhap, ctp." + Gia_Columns ;
        sqlctpn += " , sum(ctp.thanhtien) as thanhtien ";
        sqlctpn += " from chitietphieunhapkho ctp left join thuoc t ";
        sqlctpn += " on ctp.idthuoc = t.idthuoc left join Thuoc_DonViTinh dvt ";
        sqlctpn += " on ctp.dvt = dvt.id ";
        sqlctpn += " where ctp.idphieunhap = " + idphieunhap;
        sqlctpn += " group by t.tenthuoc, t.congthuc, ctp.dvt, dvt.tendvt, ";
        sqlctpn += " ctp.dongia, ctp.chietkhau, ctp.losanxuat, ctp.ngayhethan,t.sttindm05 ";
        DataTable dtCTPhieuXuat = DataAcess.Connect.GetTable(sqlctpn);
        #endregion
        #region set paramaters
        int tongtien = 0;
        for (int j = 0; j < dtCTPhieuXuat.Rows.Count; j++)
        {
            tongtien = tongtien + StaticData.ParseInt(dtCTPhieuXuat.Rows[j]["ThanhTien"].ToString());
        }
        //string sqlctpx = "  select kt.tenkho,tenkho2=kt2.tenkho,nd.tennguoidung,kh.tenkhachhang,kh.diachi ,";
        //    sqlctpx+=" px.maphieunhap,nguoinhan,ghichu,TenReport,TenNhacungCap,idloaixuat=px.loaixuat from phieunhapkho px";
        //    sqlctpx+=" left join khothuoc kt on kt.idkho=px.idkho";
        //    sqlctpx += " left join khothuoc kt2 on kt2.idkho=px.idkho2";
        //    sqlctpx+=" left join nguoidung nd on nd.idnguoidung=px.idnguoixuat";
        //    sqlctpx += " left join khachhang kh on kh.idkhachhang=px.idkhachhang";
        //    sqlctpx += " left join thuoc_loaixuat lx on lx.idloaixuat=px.loaixuat";
        //    sqlctpx += " left join NhaCungCap cc on cc.NhaCungCapid=px.idNhaCungCap";

        //    sqlctpx += " where IdPhieuXuat=" + idphieunhap;
        string sqlctpx = @"   select sophieu=pn.maphieunhap,nguoigiao=pn.tennguoigiao,pn.sohoadon,ngayhoadon
          ,nhacungcap=CC.TenNhacungCap,TENREPORT=N'Phiếu nhập kho',LN.idloaiNHAP
           from phieunhapkho pn
           left join NhaCungCap cc on cc.NhaCungCapid=pn.NhaCungCapid
           left join thuoc_loaiNHAP lN on lN.idloaiNHAP=pN.IDLOAINHAP          
             where pn.IdPhieunhap=" + idphieunhap;
            DataTable dtctpx = DataAcess.Connect.GetTable(sqlctpx);
            if (dtctpx.Rows.Count < 1) return;
            string sHome = dtCTPhieuXuat.Rows.Count.ToString();
            if (dtCTPhieuXuat.Rows.Count < 10) sHome = "0" + sHome;

        
            int nMax = 11 - dtCTPhieuXuat.Rows.Count;
            if (dtCTPhieuXuat.Rows.Count < 11)
            {
                for (int k = 1; k < nMax; k++)
                {
                    DataRow DR = dtCTPhieuXuat.NewRow();
                    DR["STT"] = dtCTPhieuXuat.Rows.Count + 1;
                    dtCTPhieuXuat.Rows.Add(DR);
                }
            }
        //    DataRow R_end = dtCTPhieuXuat.NewRow();
        //    R_end["STT"] = dtCTPhieuXuat.Rows.Count + 1;
        //    R_end["TenNhanHieu"] ="     "+ sHome + " cộng khoản";
        //dtCTPhieuXuat.Rows.Add(R_end);
            report = new ReportDocument();
            report.Load(Server.MapPath("CrptDesign/crpt_PhieuNhapKho_Mau1.rpt"));
            report.SetDataSource(dtCTPhieuXuat);
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.DataBind();

            DataTable DT1 = DataAcess.Connect.GetTable("SELECT * FROM THUOC_LOAINHAP WHERE IDLOAINHAP=" + dtctpx.Rows[0]["idloaiNHAP"].ToString());
            string sReportHeader = "PHIẾU NHẬP KHO";
            if (DT1 != null && DT1.Rows.Count > 0) sReportHeader = DT1.Rows[0]["TenReport"].ToString();

            //string tenkho = dtctpx.Rows[0]["tenkho"].ToString();
            //string tenkho2 = dtctpx.Rows[0]["tenkho2"].ToString();
            string tennguoidung = "";// dtctpx.Rows[0]["tennguoidung"].ToString();
            string tenkhachhang = "";// dtctpx.Rows[0]["tenkhachhang"].ToString();
            string TenNhaCungcap = dtctpx.Rows[0]["nhacungcap"].ToString();
            string diachi = StaticData.GetParaValueDB("DiaChiNhapKho");// dtctpx.Rows[0]["diachi"].ToString();
            string maphieuxuat = dtctpx.Rows[0]["sophieu"].ToString();
            string loaixuat = sReportHeader;
            string idloaixuat = dtctpx.Rows[0]["idloaiNHAP"].ToString();

            report.SetParameterValue("sophieu", maphieuxuat.ToString());
            report.SetParameterValue("NguoiLapPhieu", tennguoidung);
           // report.SetParameterValue("diachibophan",diachi);
            report.SetParameterValue("NguoiGiao", dtctpx.Rows[0]["NguoiGiao"].ToString());
            report.SetParameterValue("thukho","");
            report.SetParameterValue("sRowCount", sHome + " khoản");
            report.SetParameterValue("sRow", (dtCTPhieuXuat.Rows.Count+1).ToString());
            string NgayHD = dtctpx.Rows[0]["NgayHoaDon"].ToString();
            if (NgayHD != "")
            {
                DateTime dNgayHD = DateTime.Parse(NgayHD);
                NgayHD ="Số "+ dtctpx.Rows[0]["sohoadon"].ToString() +  " Ngày " + dNgayHD.ToString("dd") + " tháng " 
                    + dNgayHD.ToString("MM") + " năm " 
                    + dNgayHD.ToString("yyyy")
                    +". Của" ;

            }
        
            //report.SetParameterValue("khothuoc",tenkho);

            //if (idloaixuat == "1")
            //    tenkho2 = tenkhachhang;
            //if (idloaixuat == "3")
            //    tenkho2 = TenNhaCungcap;

            //report.SetParameterValue("kho2", tenkho2);
            //report.SetParameterValue("LydoXuatKho", dtctpx.Rows[0]["ghichu"].ToString());
            //report.SetParameterValue("DiaChiBophan", "Khoa dược");
            report.SetParameterValue("TruongKhoa", "");
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
            report.SetParameterValue("SoHoaDon", dtctpx.Rows[0]["sohoadon"].ToString());
            report.SetParameterValue("nhacungcap", dtctpx.Rows[0]["nhacungcap"].ToString());
            report.SetParameterValue("NgayHD", NgayHD);
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

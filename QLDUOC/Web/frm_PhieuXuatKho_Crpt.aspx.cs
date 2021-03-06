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


public partial class frm_PhieuXuatKho_Crpt : Genaratepage
{
    ReportDocument report;
    int idloaiphieuxuat = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        int idphieuxuat = StaticData.ParseInt(Request.QueryString["idphieuxuat"]);
        int idbenhnhan = StaticData.ParseInt(Request.QueryString["idbenhnhan"]);
        idloaiphieuxuat = 0;
        if(idphieuxuat!=0)
            idloaiphieuxuat=StaticData.ParseInt(StaticData.GetValue("phieuxuatkho","idphieuxuat",idphieuxuat,"loaixuat"));
        //loadbenhnhan(idbenhnhan);
        loadphieuxuat(idphieuxuat);
        if (IsPostBack)
        {
            loadphieuxuat(idphieuxuat);
        }
    }

    
    
    private void loadphieuxuat(int idphieuxuat)
    {
      
        #region  load chi tiet phieu xuat
        string sqlctpxt = "";
        string LoaiBieuMauPhieuXuat=StaticData.GetParameter("BieuMauPhieuXuat") ;
        if (LoaiBieuMauPhieuXuat== "1")
        {
            sqlctpxt = @"SELECT DISTINCT row_number() over (order by tenthuoc) as STT, TENTHUOC, MASO=C.sttindm05, TENDVT
	                ,YEUCAU=soluongke
	                , ThucXuat=sum( SoLuong)
	                , DonGia=((A.DonGia*isnull(a.vat,0)/100)+a.dongia)
	                , ThanhTien=sum( A.SoLuong*((A.DonGia*isnull(a.vat,0)/100)+a.dongia)) 
                From Chitietphieuxuatkho a left join Thuoc C on A.Idthuoc=C.Idthuoc 
	                left join Thuoc_DonViTinh D on C.IdDVT=D.ID left join  PhieuXuatKho G on A.IdPhieuXuat=G.IdPhieuXuat 
	                left join ChiTietBenhNhanToaThuoc B on A.Idthuoc=B.Idthuoc and B.idbenhnhantoathuoc=G.IdBenhNhanToaThuoc 
                where A.IdPhieuXuat='"+idphieuxuat+@"' 
                group by 	TENTHUOC,  TENDVT,  soluongke, sttindm05,((A.DonGia*isnull(a.vat,0)/100)+a.dongia)";
        }
        else
        {
            sqlctpxt = @"SELECT   row_number() over (order by tenthuoc) as STT, TENTHUOC, MASO=C.sttindm05, TENDVT
                    ,YEUCAU=case when A.idloaixuat_xuat=1 then O.LoSanXuat_ else H.LoSanXuat end
                    , ThucXuat= A.SoLuong, DonGia=   ROUND( A.DonGia* ( 100.0 +isnull(a.vat,0) )  /100 ,0)
                    ,ThanhTien= A.SoLuong*ROUND( A.DonGia* ( 100.0 +isnull(a.vat,0) )  /100 ,0)
                    ,LoSanXuat=case when A.idloaixuat_xuat=1 then isnull(O.LoSanXuat_,H.LoSanXuat) else H.LoSanXuat end
                    ,HanSuDung=case when A.idloaixuat_xuat=1 then convert(nvarchar(20), isnull(O.ngayhethan_,H.NgayHetHan),103) else convert(nvarchar(20), H.NgayHetHan,103) end
                From Chitietphieuxuatkho a 
                    left join Thuoc C on A.Idthuoc=C.Idthuoc left join Thuoc_DonViTinh D on C.IdDVT=D.ID 
                    left join hs_OutPutDetail O on O.OutputDetailid =A.OutputDetailid
                    left join  PhieuXuatKho G on A.IdPhieuXuat=G.IdPhieuXuat 
                    left join ChiTietBenhNhanToaThuoc B on A.Idthuoc=B.Idthuoc and B.idbenhnhantoathuoc=G.IdBenhNhanToaThuoc 
                    left join  Chitietphieunhapkho H on A.IdChiTietPHieuNhapKHo=H.IdChiTietPhieuNhapKHo 
                where A.IdPhieuXuat=" + idphieuxuat;
        }

               DataTable dtCTPhieuXuat = DataAcess.Connect.GetTable(sqlctpxt);
        #endregion
               
        #region create instance and set report source
        report = new ReportDocument();
        string TenReport = "";
        if (LoaiBieuMauPhieuXuat == "1")
            TenReport = "CrptDesign/crpt_PhieuXuatKho.rpt";
        else
            TenReport = "CrptDesign/crpt_PhieuXuatKho_new.rpt";

        report.Load(Server.MapPath(TenReport));
        report.SetDataSource(dtCTPhieuXuat);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DataBind();
        #endregion
       
        
            #region load thong tin benh nhan
       
            #endregion
        #region set paramaters
        int tongtien = 0;
        for (int j = 0; j < dtCTPhieuXuat.Rows.Count; j++)
        {
            tongtien = tongtien + StaticData.ParseInt(dtCTPhieuXuat.Rows[j]["ThanhTien"].ToString());
        }
        string sqlctpx = "  select kt.tenkho,nd.tennguoidung,kh.tenkhachhang,kh.diachi ,px.maphieuxuat,ncc.tennhacungcap ";
        sqlctpx += " ,diachincc=ncc.diachi,isnull(kt.diachi,tenkho) as diachixuat,tenloaixuat,px.ghichu as LyDoXuatKho,px.nguoinhan";
            sqlctpx+=" from phieuxuatkho px";
            sqlctpx+=" left join khothuoc kt on kt.idkho=px.idkho";
            sqlctpx+=" left join nguoidung nd on nd.idnguoidung=px.idnguoixuat";
            sqlctpx += " left join khachhang kh on kh.idkhachhang=px.idkhachhang";
            sqlctpx += " LEFT JOIN dbo.nhacungcap ncc on ncc.nhacungcapid=px.idnhacungcap ";
            sqlctpx += " LEFT JOIN dbo.thuoc_loaixuat loaixuat on px.loaixuat=loaixuat.idloaixuat ";

            sqlctpx+=" where IdPhieuXuat="+ idphieuxuat;
            DataTable dtctpx = DataAcess.Connect.GetTable(sqlctpx);
            string tenkho = dtctpx.Rows[0]["tenkho"].ToString();
            string tennguoidung = dtctpx.Rows[0]["tennguoidung"].ToString();
            string tenkhachhang = dtctpx.Rows[0]["tenkhachhang"].ToString();
            if (idloaiphieuxuat == 3) 
                tenkhachhang = dtctpx.Rows[0]["tennhacungcap"].ToString();
            string diachi = dtctpx.Rows[0]["diachi"].ToString();
            string LyDoXT = (dtctpx.Rows[0]["lydoxuatkho"].ToString()!="" ? dtctpx.Rows[0]["lydoxuatkho"].ToString(): dtctpx.Rows[0]["tenloaixuat"].ToString());
            if (idloaiphieuxuat == 3)
            {
                diachi = dtctpx.Rows[0]["diachincc"].ToString();
                 
            }
            string maphieuxuat = dtctpx.Rows[0]["maphieuxuat"].ToString();
            report.SetParameterValue("sophieu", maphieuxuat.ToString());
            report.SetParameterValue("tennguoinhanhang",(idloaiphieuxuat!=3?  dtctpx.Rows[0]["tenkhachhang"].ToString(): dtctpx.Rows[0]["tennhacungcap"].ToString()));//tenkhachhang
            report.SetParameterValue("NguoiLapPhieu", "");// SysParameter.UserLogin.FullName(this)

            report.SetParameterValue("diachibophan",diachi);
            report.SetParameterValue("thukho",StaticData.GetParameter("TenThuKho"));
            report.SetParameterValue("KeToanTruong", StaticData.GetParameter("TenKeToanTruong"));
            report.SetParameterValue("ManagerName", StaticData.GetParameter("TenThuTruong"));

            report.SetParameterValue("khothuoc",tenkho);
            report.SetParameterValue("LydoXuatKho", LyDoXT);
            report.SetParameterValue("DiaChiXuat", dtctpx.Rows[0]["diachixuat"].ToString());

            string bangchu = new clsDocSoTien().ReadNumToString(tongtien.ToString());
            report.SetParameterValue("tongtien",tongtien);
            report.SetParameterValue("docthanhtien", bangchu);
            string ngaythang= DateTime.Now.ToString("dd/MM/yyyy");
            string ngay = DateTime.Now.ToString("dd");
            string thang = DateTime.Now.ToString("MM");
            string nam = DateTime.Now.ToString("yyyy");
            report.SetParameterValue("ngay", ngay);
            report.SetParameterValue("thang", thang);
            report.SetParameterValue("nam", nam);
            report.SetParameterValue("MaDonVi", StaticData.MaDonViKhoaDuoc);
            report.SetParameterValue("TenDonVi", StaticData.TenCty);
            string headerR = "";
            headerR = StaticData.GetValue("thuoc_loaixuat", "idloaixuat", idloaiphieuxuat, "TenReport");
            if(headerR=="")
                headerR = "PHIẾU XUẤT KHO";
            report.SetParameterValue("headerReport",headerR);
        
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

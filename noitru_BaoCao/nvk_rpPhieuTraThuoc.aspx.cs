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
using System.Text.RegularExpressions;

public partial class noitru_BaoCao_nvk_rpPhieuTraThuoc : System.Web.UI.Page
{
    ReportDocument nvkR;
    protected void Page_Load(object sender, EventArgs e)
    {
        nvk_Gereport();
    }
    private void nvk_Gereport()
    {
        nvkR = new ReportDocument();
        string IdPhieuTra = "";
        string loaitraID = "";
        try
        {
            IdPhieuTra = Request.QueryString["IdPhieuTra"].ToString();
            //loaitraID = Request.QueryString["LoaiTra"].ToString();
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Không load được nội dung phiếu !");
            return;
        }
        string TenReport = "Report/nvk_rpTraThuoc";
        nvkR.Load(Server.MapPath(TenReport + ".rpt"));
        DataTable dtTraThuoc = getdtTraThuoc(IdPhieuTra,loaitraID);
        nvkR.SetDataSource(dtTraThuoc);
        #region set parameter
        string sqlPara = @"
                select SoYTe=N'Bến Tre',TenBenhVien=N'Đa khoa Minh Đức',Khoa=p.tenphongkhambenh,k.TenKho,SoPhieuTra= yc.SoPhieu,yc.idphongkhambenh
                ,strNgayYC=case when ngayyc < convert(datetime, convert(varchar(10),ngayyc,126)+' 13:30:00') then N'Ngày '+convert(varchar,day(ngayyc))+N' tháng '+convert(varchar,month(ngayyc))+N' năm '+convert(varchar,year(ngayyc))+''
                    else N'Ngày '+convert(varchar,day(dateadd(dd,1,ngayyc)))+N' tháng '+convert(varchar,month(dateadd(dd,1,ngayyc)))+N' năm '+convert(varchar,year(dateadd(dd,1,ngayyc)))+'' end
                from NVK_Thuoc_PhieuYCTra yc
                    inner join khothuoc k on k.idkho=yc.idphongkhambenh
                    left join phongkhambenh p on p.idphongkhambenh=k.idkhoa
                where yc.idphieuyctra='" + IdPhieuTra + "' ";// and isnull(yc.LoaiTraID,1)='" + loaitraID + @"'
        DataTable dtPara = DataAcess.Connect.GetTable(sqlPara);
        //DataAcess.Connect.GetTable(sqlPara);
        if (dtPara == null || dtPara.Rows.Count == 0)
        {
            StaticData.MsgBox(this,"Không tìm thấy phiếu YC !");
            return;
        }
        #region Bản in ?
        string nvkBanIn = "-BG";
        if (Request.QueryString["IsBanSao"] != null && Request.QueryString["IsBanSao"] == "1")
        {
            nvkBanIn = "-BL";
        }
        #endregion
        nvkR.SetParameterValue("@SoYTe", dtPara.Rows[0]["SoYTe"]);
        nvkR.SetParameterValue("@TenBenhVien", dtPara.Rows[0]["TenBenhVien"]);
        nvkR.SetParameterValue("@KhoaTra", dtPara.Rows[0]["Khoa"].ToString());
        nvkR.SetParameterValue("@SoPhieuTra", dtPara.Rows[0]["SoPhieuTra"].ToString() + nvkBanIn);
        nvkR.SetParameterValue("@strNgayYC",dtPara.Rows[0]["strNgayYC"].ToString());
        nvkR.SetParameterValue("@strKhoTra", dtPara.Rows[0]["TenKho"].ToString());
        ((TextObject)nvkR.ReportDefinition.ReportObjects["txtTruongKhoaDuoc"]).Text = "";//StaticData.GetParameter("nvk_TenTruongKhoaDuoc");        
        string IdKhoYc = dtPara.Rows[0]["idphongkhambenh"].ToString();
        if (StaticData.GetParameter("KhoThuocBHYT").Equals(IdKhoYc))
            ((TextObject)nvkR.ReportDefinition.ReportObjects["txtTruongKhoaYC"]).Text = "TRƯỞNG QUẦY PT.BHYT";
        this.report.ReportSource = nvkR;
        this.report.DataBind();
        #endregion
    }
    private DataTable getdtTraThuoc(string idPhieuYCTra,string loaitraID)
    {
        string sql = @"
            select *,ThanhTien=ROUND(soluong * dongia,3) from (
                select t.TenThuoc,dvt.tenDVT DonVi,SoKiemSoat=null,SoLuong=ct.soluong
                ,DonGia=isnull((select top 1 DONGIA*(100.0+VAT)/100 from chitietphieuxuatkho where idthuoc=ct.idthuoc and idkho_xuat=4 order by idchitietphieuxuat desc),0)
                ,GhiChu='',nvk_UuTienYL=isnull(nvk_UuTienYL,100)
                from NVK_Thuoc_PhieuYCTra yc inner join NVK_Thuoc_chitietPhieuYCTra ct on yc.idphieuyctra=ct.idphieuyctra 
                    inner join thuoc t on ct.idthuoc =t.idthuoc
                left join thuoc_donvitinh dvt on dvt.id=t.iddvt
                where yc.IdPhieuYCTra='" + idPhieuYCTra + @"'
            ) as nvk
         ORDER BY isnull(nvk_UuTienYL,100),DonVi,tenthuoc ";// and isnull(yc.LoaiTraID,1)='"+loaitraID+@"'
        DataTable nvk_dt = DataAcess.Connect.GetTable(sql); ;
        return nvk_dt;
    }
    protected void report_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(nvkR);
    }
}

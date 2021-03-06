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

public partial class rptPhieuYCTra_new : System.Web.UI.Page
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
            IdPhieuTra = Request.QueryString["IdPhieuYC"].ToString();
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Không load được nội dung phiếu !");
            return;
        }
        string TenReport = "CrptDesign/nvk_rpTraThuoc";
        nvkR.Load(Server.MapPath(TenReport + ".rpt"));
        DataTable dtTraThuoc = getdtTraThuoc(IdPhieuTra,loaitraID);
        nvkR.SetDataSource(dtTraThuoc);
        #region set parameter
        string sqlPara = @"
                select SoYTe=N'"+StaticData.GetParaValueDB("TenSoYTe")+"',TenBenhVien=N'"+StaticData.GetParaValueDB("TenDonVi")+ @"',Khoa=ISNULL(p.tenphongkhambenh,K.TENKHO) ,k.TenKho,SoPhieuTra= yc.SoPhieuyc
                ,strNgayYC= N'Ngày '+convert(varchar,day(NgayDuyet))+N' tháng '+convert(varchar,month(NgayDuyet))+N' năm '+convert(varchar,year(NgayDuyet))
                ,yc.idkhoyc
                from YC_PHIEUYCTRA yc
                    inner join khothuoc k on k.idkho=yc.idkhoyc
                    LEFT join phongkhambenh p on p.idphongkhambenh=k.idkhoa
                where yc.IdPhieuYc='" + IdPhieuTra + "' "; 
        DataTable dtPara = DataAcess.Connect.GetTable(sqlPara);
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
        nvkR.SetParameterValue("@KhoaTra", dtPara.Rows[0]["Khoa"]);
        nvkR.SetParameterValue("@SoPhieuTra", dtPara.Rows[0]["SoPhieuTra"].ToString() + nvkBanIn);
        nvkR.SetParameterValue("@strNgayYC",dtPara.Rows[0]["strNgayYC"].ToString());
        nvkR.SetParameterValue("@strKhoTra", dtPara.Rows[0]["TenKho"].ToString());
        //((TextObject)nvkR.ReportDefinition.ReportObjects["txtTruongKhoaDuoc"]).Text = StaticData.GetParameter("nvk_TenTruongKhoaDuoc");        
        ((TextObject)nvkR.ReportDefinition.ReportObjects["TruongKhoaLamSang"]).Text =(dtPara.Rows[0]["idkhoyc"].ToString() !="5" ?  "TRƯỞNG KHOA\r\n KHOA LÂM SÀNG" : "TRƯỞNG QUẦY\r\n PT.BHYT");
        this.report.ReportSource = nvkR;
        this.report.DataBind();
        #endregion
    }
    private DataTable getdtTraThuoc(string idPhieuYCTra,string loaitraID)
    {
        string sql = @"
                            SELECT   DISTINCT    
                                     B.tenthuoc
		                            ,donvi=C.tenDVT
		                            ,SoKiemSoat=ISNULL( A.LOSANXUAT_XUAT,'')
		                            ,Soluong=SUM( A.SOLUONG)
	                                ,DonGia=ROUND( A.DONGIA*(100.0 +ISNULL(A.VAT,0))/100,0)
		                            ,ghichu=ISNULL(E.ghichu,'')
		                            ,thanhtien=SUM(A.SOLUONG)*ROUND( A.DONGIA*(100.0 +ISNULL(A.VAT,0))/100,0)
                                    ,isnull(nvk_UuTienYL,100)
                            FROM CHITIETPHIEUXUATKHO A
                            LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
                            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                            LEFT JOIN PHIEUXUATKHO D ON A.IDPHIEUXUAT=D.IDPHIEUXUAT
                            LEFT JOIN YC_PHIEUYCTRACHITIET E ON A.IDCHITIETPHIEUYEUCAUTRAKHO=E.IDCHITIETYC
                            WHERE D.IDPHIEUYCTRA=" + idPhieuYCTra + @"
                                    GROUP BY 
                                     B.tenthuoc
		                            ,C.tenDVT
		                            ,ISNULL( A.LOSANXUAT_XUAT,'')
	                                ,ROUND( A.DONGIA*(100.0 +ISNULL(A.VAT,0))/100,0)
		                            ,ISNULL(E.ghichu,'')
                                    ,isnull(nvk_UuTienYL,100)
                                ORDER BY isnull(nvk_UuTienYL,100),TENDVT,tenthuoc 
                        ";
        DataTable nvk_dt = DataAcess.Connect.GetTable(sql); ;
        return nvk_dt;
    }
    protected void report_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(nvkR);
    }
}

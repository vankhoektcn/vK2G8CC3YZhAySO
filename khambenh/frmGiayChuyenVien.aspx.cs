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
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;

public partial class khambenh_frmGiayChuyenVien : System.Web.UI.Page
{
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        getReport();
    }
    private void getReport()
    {
        int idchitietdangkykham = 0;
        string nvk_idkhoa = Request.QueryString["IdKhoa"].ToString() ;
        if (Request.QueryString["idctdkk"] != null && Request.QueryString["idctdkk"].ToString() != "")
            idchitietdangkykham = int.Parse(Request.QueryString["idctdkk"].ToString());
        if (Request.QueryString["idkhambenh"] != null && Request.QueryString["idkhambenh"].ToString() != "" )//idkhambenh
        {
            if (Request.QueryString["idctdkk"] == null || Request.QueryString["idctdkk"] == "")
            {
                DataTable dtkb = DataAcess.Connect.GetTable("select * from khambenh where idkhambenh='" + Request.QueryString["idkhambenh"].ToString() + "' order by idkhambenh desc ");
                if (dtkb != null && dtkb.Rows.Count > 0)
                    idchitietdangkykham = StaticData.ParseInt(dtkb.Rows[0]["idchitietdangkykham"]);
            }
        }
        crystalReport = new ReportDocument();
        string ReportSourceName = "rptGiayChuyenVien";
        crystalReport.Load(Server.MapPath("../report/" + ReportSourceName + ".rpt"));
        DataTable dtsrc = loadData(idchitietdangkykham, nvk_idkhoa);
        if (dtsrc.Rows.Count==0) return;
        crystalReport.SetParameterValue("txtBVChuyenDen", dtsrc.Rows[0]["tenbenhvien"].ToString());
        crystalReport.SetParameterValue("txtNguoiBenh", dtsrc.Rows[0]["tenbenhnhan"].ToString());
        crystalReport.SetParameterValue("txtTuoi", dtsrc.Rows[0]["tuoi"].ToString());
        crystalReport.SetParameterValue("txtGioiTinh", dtsrc.Rows[0]["GioiTinh"].ToString());
        crystalReport.SetParameterValue("txtNgheNghiep", dtsrc.Rows[0]["nghenghiep"].ToString());
        crystalReport.SetParameterValue("txtNoiLamViec", dtsrc.Rows[0]["NoiCongTac"].ToString());
        if (dtsrc.Rows[0]["sobhyt"].ToString() != "")
        {
            string ngaybatdau = string.Format("{0:dd/MM/yyyy}", dtsrc.Rows[0]["ngaybatdau"]);
            string ngayketthuc = string.Format("{0:dd/MM/yyyy}", dtsrc.Rows[0]["ngayhethan"]);
            crystalReport.SetParameterValue("txtBHYT", "Từ ngày " + ngaybatdau + " đến ngày " + ngayketthuc);
            crystalReport.SetParameterValue("txtSo", dtsrc.Rows[0]["sobhyt"].ToString());
        }
        else
        {

            crystalReport.SetParameterValue("txtBHYT", "");
            crystalReport.SetParameterValue("txtSo","");
        }

        crystalReport.SetParameterValue("txtDiaChi", dtsrc.Rows[0]["DiaChi"].ToString());
        crystalReport.SetParameterValue("txtDauHieu", dtsrc.Rows[0]["TRIEUCHUNG"].ToString());
        crystalReport.SetParameterValue("txtXetNghiem", dtsrc.Rows[0]["XETNGHIEM"].ToString());
        crystalReport.SetParameterValue("txtChanDoan", dtsrc.Rows[0]["ChanDoanBanDau"].ToString());
        crystalReport.SetParameterValue("txtThuoc", dtsrc.Rows[0]["thuoc"].ToString());
        crystalReport.SetParameterValue("txtXetNghiem", dtsrc.Rows[0]["XETNGHIEM"].ToString());
        crystalReport.SetParameterValue("txtTuNgay", dtsrc.Rows[0]["ngayvaovien"].ToString());
        crystalReport.SetParameterValue("txtDieuTriDenNgay", dtsrc.Rows[0]["ngayravien"].ToString());
        crystalReport.SetParameterValue("txtDieuTri",StaticData.TenCty.ToString());
        crystalReport.SetParameterValue("@DanToc", dtsrc.Rows[0]["dantoc"].ToString());
        crystalReport.SetParameterValue("@ChanDoanPhoiHop", dtsrc.Rows[0]["chandoanphoihop"].ToString());
        R.ReportSource = crystalReport;
        R.DataBind(); 
    }
    private DataTable loadData(int idctdkk, string idkhoa)
    {
        string sql = "";
        string IsGetByKhamBenh = Request.QueryString["IsGetByKhamBenh"];
        if (IsGetByKhamBenh == "1")
        {
            string IdKhamBenh = Request.QueryString["idkhambenh"];
            if (IdKhamBenh == null || IdKhamBenh == "") return null;
            sql = @"        SELECT  tenbenhvien,
				                        TENBENHNHAN,
				                        DBO.GetNamSinh( BN.ngaysinh) as namsinh,
				                        tuoi=dbo.kb_gettuoi(bn.ngaysinh),
				                        [dbo].[GetGioiTinh](BN.GIOITINH) AS GIOITINH,
				                        bn.dantoc,
				                        ngayvaovien= convert(varchar(10),DKK.NGAYDANGKY,103)+' '+ convert(varchar(5),DKK.NGAYDANGKY,108),
				                        ngayravien=convert(varchar(10),ISNULL(KB.TGXUATVIEN,KB.NGAYKHAM),103)+' '+ convert(varchar(5),ISNULL(KB.TGXUATVIEN,KB.NGAYKHAM),108) ,
				                        BN.NGHENGHIEP,
				                        BN.NOICONGTAC,
				                        BH.NGAYBATDAU,
				                        BH.NGAYHETHAN,
				                        BH.SOBHYT,
				                        BN.DIACHI,
				                        XETNGHIEM= DBO.HS_GetDichVuXetNghiem(KB.IDKHAMBENH),
				                        KB.TRIEUCHUNG,
				                        CHANDOANBANDAU = KB.CHANDOANBANDAU,
				                        THUOC='' ,
				                        chandoanphoihop = DBO.KB_GETCHANDOAN_ICD_BY_IDKHAMBENH(KB.IDKHAMBENH)
                                 FROM KHAMBENH KB
				                        inner JOIN  BENHNHAN BN ON KB.IDBENHNHAN=BN.IDBENHNHAN
				                        left join benhvien bv on bv.idbenhvien=kb.IdBenhVienChuyen
				                        LEFT JOIN DANGKYKHAM DKK ON KB.IDDANGKYKHAM=DKK.IDDANGKYKHAM
				                        LEFT JOIN BENHNHAN_BHYT BH ON DKK.IDBENHNHAN_BH=BH.IDBENHNHAN_BH
                                 WHERE   KB.IDKHAMBENH="+IdKhamBenh;


        }
        else
            sql=
                        @"
                        SELECT tenbenhvien,TENBENHNHAN,DBO.GetNamSinh( BN.ngaysinh) as namsinh,tuoi=dbo.kb_gettuoi(bn.ngaysinh)
	                        ,[dbo].[GetGioiTinh](BN.GIOITINH) AS GIOITINH
	                        ,bn.dantoc
	                        ,ngayvaovien= convert(varchar(10),HS.NGAYTINHBH,103)+' '+ convert(varchar(5),HS.NGAYTINHBH,108)
                            ,ngayravien=convert(varchar(10),HS.NgayTinhBH_Thuc,103)+' '+ convert(varchar(5),HS.NgayTinhBH_Thuc,108) 
                            ,BN.NGHENGHIEP,BN.NOICONGTAC,BH.NGAYBATDAU,BH.NGAYHETHAN,BH.SOBHYT,BN.DIACHI
	                        , XETNGHIEM= dbo.[nvk_GetDichVuCLS_idctdkk]('" + idctdkk+ @"')
	                        ,KB.TRIEUCHUNG
	                        ,CHANDOANBANDAU =(select top 1  '('+maicd+') '+mota from benhnhanxuatkhoa xk
					                         inner join chandoanicd cd on cd.idicd=xk.chandoanxuatkhoa where xk.idchitietdangkykham='" + idctdkk + @"'  and xk.idkhoaxuat='"+idkhoa+@"' order by idxuatkhoa desc)
                            ,THUOC='' 
                        ,chandoanphoihop = dbo.[nvk_TongHopCDPhoiHop_XuatKhoa]('" +idctdkk+@"','"+idkhoa+ @"')
                         FROM BENHNHAN BN
	                         inner JOIN KHAMBENH KB ON KB.IDBENHNHAN=BN.IDBENHNHAN
	                        inner join benhnhanxuatkhoa xk on xk.idkhambenhXK =kb.idkhambenh
	                         left join benhvien bv on bv.idbenhvien=kb.ghichuhuongdieutri
                             LEFT JOIN CHITIETDANGKYKHAM CTDKK ON XK.idchitietdangkykham=CTDKK.idchitietdangkykham
                             LEFT JOIN DANGKYKHAM DKK ON CTDKK.IDDANGKYKHAM=DKK.IDDANGKYKHAM
                             LEFT JOIN BENHNHAN_BHYT BH ON DKK.IDBENHNHAN_BH=BH.IDBENHNHAN_BH
                             LEFT JOIN HS_BENHNHANBHDONGTIEN HS ON DKK.IDBENHBHDONGTIEN=HS.ID
                         WHERE xk.idchitietdangkykham='" + idctdkk+@"' and xk.idkhoaxuat ='"+idkhoa+@"' order by kb.idkhambenh desc";
        DataTable dtSRC = new DataTable();
        dtSRC = null;
        dtSRC = DataAcess.Connect.GetTable(sql);
        return dtSRC;
    }
    protected void crptView_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);

    }
    #region khoi tao va giai phong bo nho
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
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

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


public partial class rptPhieuYCXuat_new : System.Web.UI.Page
{
    public string IdPhieuYC="0";
    private string LoaiThuoc = "1";
    private string nvk_strDuTru = "";
    private string nvk_strNgayYc = "";
    string para_idLoaiThuocGayNghien = ""; string para_idLoaiThuocHuongTamThan = "";

    ReportDocument R;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["IdPhieuYC"] != null && Request.QueryString["IdPhieuYC"].ToString() != "")
        {
            IdPhieuYC = Request.QueryString["IdPhieuYC"];
            string nvksql = @"select top 1 *, nvk_strDuTru=(CASE WHEN ISDUTRU=1 THEN N'Dự trù:' +convert(varchar(10),TUNGAY,103)+N' đến '+ convert(varchar(10),DENNGAY,103) ELSE '' END)";
                nvksql +=@"
                    ,strNgayYc=N'Ngày '+convert(varchar,day(NgayDuyet))+' tháng '+convert(varchar,month(NgayDuyet))+N' năm '+convert(varchar,year(NgayDuyet))";
            nvksql += @"
                    ,LOAITHUOCID1=ISNULL(LOAITHUOCID,0)
                 from yc_PhieuYcXuat where IsDuyetIn=1 and IdPhieuYc ='" + IdPhieuYC + "'";
            DataTable dt = DataAcess.Connect.GetTable(nvksql);
            if (dt == null || dt.Rows.Count == 0)
            {
                Response.Write("Không có nội dung. Có thể chưa duyệt In?");
                return;
            }
            this.LoaiThuoc = dt.Rows[0]["LOAITHUOCID1"].ToString();
            this.nvk_strDuTru = dt.Rows[0]["nvk_strDuTru"].ToString();
            this.nvk_strNgayYc = dt.Rows[0]["strNgayYc"].ToString();
        }
        else
        {
            StaticData.MsgBox(this,"Không xem đc phiếu !");
            return;
        }
        #region  
        para_idLoaiThuocGayNghien = StaticData.GetParameter("nvk_idLoaiThuocGayNghien") != null ? StaticData.GetParameter("nvk_idLoaiThuocGayNghien") : "5";
        para_idLoaiThuocHuongTamThan = StaticData.GetParameter("nvk_idLoaiThuocHuongTamThan") != null ? StaticData.GetParameter("nvk_idLoaiThuocHuongTamThan") : "6";
        if (this.LoaiThuoc == para_idLoaiThuocGayNghien || this.LoaiThuoc == para_idLoaiThuocHuongTamThan)
            getReport_A5(this.LoaiThuoc);
        else
            getReport_A4(this.LoaiThuoc);
            
        #endregion
    }
    private DataTable LoadDetail()
    {
        string sqlThuoc = "";
        DataTable dtPhieuYC = null;
        sqlThuoc = @"
            SELECT MA=PRODUCTCODE,
            TENTHUOC,
            DonVi=TENDVT,
            yeucau= A.SoLuongYc,
            PHAT= ( CASE WHEN ISNULL( A.SoLuongDuyet,0)=0 THEN A.SoLuongDuyet  else A.SoLuongDuyet END),
            GHICHU=A.GHICHU,B.IDTHUOC
            FROM yc_PhieuYcXuatChiTiet A
            LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
            WHERE --A.IsDuyetIn=1 and 
            isnull(A.SoLuongYc,0)> 0 and A.IdPhieuYC='" + IdPhieuYC + @"' ORDER BY   isnull(nvk_UuTienYL,100),TENDVT,tenthuoc 
            ";
            dtPhieuYC = DataAcess.Connect.GetTable(sqlThuoc);
        return dtPhieuYC;
    }
    private void getReport_A5(string loaithuocID)
    {
        string loaiReport = loaithuocID;
        R = new ReportDocument();
        string TenReport = "CrptDesign/phieulinhthuoc";
        R.Load(Server.MapPath(TenReport + ".rpt"));
        DataTable dtThuoc = this.LoadDetail();
        bool isGayNghien = false;
        string stemp = "";
        Type tTemp = stemp.GetType();
        dtThuoc.Columns.Add("strSoluong", tTemp);
        dtThuoc.Columns.Add("strPhat", tTemp);
        clsDocSoTien docso = new clsDocSoTien();
        if (this.LoaiThuoc == para_idLoaiThuocGayNghien)
        {
            #region convert số lượng yêu cầu từ số sang chữ (đối với thuốc gây nghiện)
            for (int i = 0; i < dtThuoc.Rows.Count; i++)
            {
                //dtThuoc.Rows[i]["yeucau"] = "0.00005"; -> sai (0.0005,0.005,.. đúng)
                string strSoLuongYC = docso.nvk_ReadNumToString_NotCurrency(dtThuoc.Rows[i]["yeucau"].ToString());
                string strSoLuongPhat = docso.nvk_ReadNumToString_NotCurrency(dtThuoc.Rows[i]["PHAT"].ToString());
                dtThuoc.Rows[i]["strSoluong"] = strSoLuongYC;
                dtThuoc.Rows[i]["strPhat"] = strSoLuongPhat;
            }
            #endregion
        }
        else
        {
            #region số lượng dạng số đối với hướng tâm thần
            for (int i = 0; i < dtThuoc.Rows.Count; i++)
            {
                dtThuoc.Rows[i]["strSoluong"] = dtThuoc.Rows[i]["yeucau"].ToString();
                dtThuoc.Rows[i]["strPhat"] = dtThuoc.Rows[i]["PHAT"].ToString();
            }
            #endregion
        }
        R.SetDataSource(dtThuoc);

        #region parameterValue
        string sqlPhieuYC = @"
                select k.tenkho,p.tenphongkhambenh,sophieu=yc.SoPhieuYc
                ,tongkhoan= isnull((select count(*) from yc_PhieuYcXuatChiTiet where idphieuyc='" + IdPhieuYC + @"' and isnull(SoLuongYc,0)>0 ),0)
                ,ngay= day(NgayYc)
                ,thang= month(NgayYc)
                ,nam= year(NgayYc)
                 from yc_PhieuYcXuat yc inner join khothuoc k on k.idkho=yc.IdKhoYc
                left join phongkhambenh p  on p.idphongkhambenh= k.idkhoa
                 where idphieuyc='" + IdPhieuYC + "'";
        DataTable dtYC = DataAcess.Connect.GetTable(sqlPhieuYC);
        if (dtYC.Rows.Count == 0)
            return;
        string KhoaYC = dtYC.Rows[0]["tenkho"].ToString();
        string MaPhieuYC = dtYC.Rows[0]["sophieu"].ToString();
        string tongCongKhoan = docso.nvk_ReadNumToString_NotCurrency(dtYC.Rows[0]["tongkhoan"].ToString());
        string NgayYc = dtYC.Rows[0]["ngay"].ToString();
        string thangYC = dtYC.Rows[0]["thang"].ToString();
        string namYC = dtYC.Rows[0]["nam"].ToString();
        string txtHeader = "PHIẾU LĨNH THUỐC HƯỚNG THẦN (TIỀN CHẤT)";
        if(this.LoaiThuoc==para_idLoaiThuocGayNghien)
            txtHeader = "PHIẾU LĨNH THUỐC GÂY NGHIỆN";
        #endregion

        #region set parameter
        R.SetParameterValue("@idphieuyc", IdPhieuYC);
        R.SetParameterValue("txtHeader", txtHeader);
        R.SetParameterValue("ngay", NgayYc);
        R.SetParameterValue("thang", thangYC);
        R.SetParameterValue("nam", namYC);
        R.SetParameterValue("demtongcong", tongCongKhoan);
        R.SetParameterValue("@Khoa", KhoaYC);
        #region Bản in ?
        string nvkBanIn = "-BG";
        if (Request.QueryString["IsBanSao"] != null && Request.QueryString["IsBanSao"] =="1")
        {
            nvkBanIn = "-BL";
        }
        #endregion
        R.SetParameterValue("@MaPhieuYC", MaPhieuYC+nvkBanIn);
        R.SetParameterValue("@strNgayDuTru", this.nvk_strDuTru);
        R.SetParameterValue("@strNgayYc", this.nvk_strNgayYc);
        #endregion
        this.report.ReportSource = R;
        this.report.DataBind();
    }
    private void getReport_A4(string loaithuocID)
    {
        string loaiReport = loaithuocID;
        R = new ReportDocument();

        string TenReport = "CrptDesign/crpt_PhieuLinhThuoc";
        R.Load(Server.MapPath(TenReport + ".rpt"));
        DataTable dtThuoc = this.LoadDetail();

        R.SetDataSource(dtThuoc);

        DataTable dtLoaiThuoc = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID(loaithuocID);
        string TenLoai = "";
        if(dtLoaiThuoc.Rows.Count>0)
        {
            TenLoai=   dtLoaiThuoc.Rows[0]["TenLoai"].ToString();
            TenLoai = TenLoai.ToLower();
        }
        
        
        if (loaithuocID == "5" || loaithuocID=="6")
        {
            string IdThuoc = dtThuoc.Rows[0]["IDTHUOC"].ToString();
            DataTable dtOneThuoc = Thuoc_Process.thuoc.dtSearchByidthuoc(IdThuoc);
            if (dtOneThuoc == null || dtOneThuoc.Rows.Count == 0) return;
            Thuoc_Process.thuoc Currentthuoc = new Thuoc_Process.thuoc(dtOneThuoc.DefaultView, 0);
            if (Currentthuoc.IsTGN == "1" || Currentthuoc.IsTGN.ToLower() == "true")
                TenLoai = " thuốc gây nghiện";

            if (Currentthuoc.IsTHTT == "1" || Currentthuoc.IsTHTT.ToLower() == "true")
                TenLoai = " thuốc hướng tâm thần";

        }
        string ReportHeader = "phiếu lĩnh " + TenLoai;
        if (Request.QueryString["ListIdCTTT"] != null)
            ReportHeader = "phiếu nhập " + TenLoai+" bệnh nhân trả ";

        ReportHeader = ReportHeader.ToUpper();
        string HeaderThuoc = "Tên " + TenLoai;
        if (loaithuocID == "1" || loaithuocID=="5" ||loaithuocID=="6")
        {
            HeaderThuoc = "Tên thuốc-hàm lượng";
        }
        R.SetParameterValue("txtHeader", ReportHeader);
        R.SetParameterValue("txtHeaderThuoc", HeaderThuoc);


        string sqltt = @"select sophieu=ycx.sophieuyc,khoa=tenkho 
        ,Sum_YC=isnull((select sum(SoLuongYc) from yc_PhieuYcXuatChiTiet where IdPhieuYC=" + IdPhieuYC + @" ),0)
        ,Sum_TX=isnull((select sum(SoLuongDuyet) from yc_PhieuYcXuatChiTiet where IdPhieuYC=" + IdPhieuYC + @" ),0)
        ,YCX.IDKHOYC
        from yc_PhieuYcXuat ycx 
        left join khothuoc pkb on pkb.idkho=ycx.idkhoyc
        where ycx.IdPhieuYC='" + IdPhieuYC + "' ";
        
        DataTable tbYC = DataAcess.Connect.GetTable(sqltt);
        string khoa = "";
        if (tbYC.Rows.Count > 0)
            khoa = tbYC.Rows[0]["khoa"].ToString();
        R.SetParameterValue("tendonvi",StaticData.TenCty);
        R.SetParameterValue("khoa",khoa);

        R.SetParameterValue("Sum_YC", tbYC.Rows[0]["Sum_YC"].ToString());
        R.SetParameterValue("Sum_TX", tbYC.Rows[0]["Sum_TX"].ToString());
        #region Bản in ?
        string nvkBanIn = "-BG";
        if (Request.QueryString["IsBanSao"] != null && Request.QueryString["IsBanSao"] == "1")
        {
            nvkBanIn = "-BL";
        }
        #endregion
        R.SetParameterValue("@SoPhieuYC", tbYC.Rows[0]["SoPhieu"].ToString() + nvkBanIn);
        R.SetParameterValue("@strNgayDuTru", this.nvk_strDuTru);
        R.SetParameterValue("@strNgayYc", this.nvk_strNgayYc);
        ((TextObject)R.ReportDefinition.ReportObjects["txtTruongKhoaDuoc"]).Text = StaticData.GetParameter("nvk_TenTruongKhoaDuoc");

        ((TextObject)R.ReportDefinition.ReportObjects["TruongKhoaLamSang"]).Text = (tbYC.Rows[0]["IdKhoYC"].ToString() != "5" ? " TRƯỞNG KHOA LÂM SÀNG" : "TRƯỞNG QUẦY PT.BHYT");
        
        this.report.ReportSource = R;
        this.report.DataBind();
    }
    protected void report_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
    }
    #region khoi tao va giai phong bo nho
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
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

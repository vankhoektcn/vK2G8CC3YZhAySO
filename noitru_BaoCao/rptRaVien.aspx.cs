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

public partial class nhanbenh_rptRaVien :Genaratepage
{
    public string idphieutt;
    ReportDocument R;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        //{
            loadData();
        //}
    }
    private void loadData()
    {
        string nvk_idkhoa = Request.QueryString["IdKhoa"].ToString() ;
        try
        {
            idphieutt = Request.QueryString["idphieutt"].ToString();
            if (idphieutt == null || idphieutt == "") return;
        }
        catch
        {
            StaticData.MsgBox(this, "Lỗi bạn chưa chọn bệnh nhân cần thanh toán");
            Response.Write("KHÔNG CÓ DỮ LIỆU");
            return;
        }

        DateTime NgayThangNam = DataAcess.Connect.d_SystemDate();
        string sqlInfor = @"
 SELECT bh.ngaybatdau,bh.ngayhethan
	,bhTu=convert(varchar(10),bh.ngaybatdau,103),bhDen=convert(varchar(10),bh.ngayhethan,103)
	,a.*,b.tenbenhnhan,b.mabenhnhan,bh.sobhyt,b.gioitinh,nghenghiep=nn.tennghenghiep,b.diachi,dantoc=dt.tendantoc
            ,TuoiBN=DBO.KB_Tuoi(B.NgaySinh),TenKhoa=tenphongkhambenh, ChanDoan=CD.MOTA,ngayvaoviendk=dk.ngaydangky
    ,B.NgaySinh
 FROM KHAMBENH A 
inner JOIN BENHNHAN B ON A.IdBenhNhan=B.IdBenhNhan
	 inner JOIN PhongKhamBenh C on A.IDPHONGKHAMBENH=C.idphongkhambenh
	 LEFT JOIN CHANDOANICD CD ON A.KETLUAN=CD.IDICD
     inner join dangkykham dk on a.iddangkykham=dk.iddangkykham
left join nghenghiep nn on convert(varchar,nn.idnghenghiep)= b.nghenghiep
left join dantoc dt on convert(varchar,dt.id)= b.dantoc
left join benhnhan_bhyt bh on dk.idbenhnhan_bh=bh.idbenhnhan_bh
 Where A.IDKHAMBENH='" + idphieutt+"'";
        DataTable dt = DataAcess.Connect.GetTable(sqlInfor);
        if (dt == null) return;
        R = new ReportDocument();
        //string TenReport = "rptRaVien";
        string TenReport = "../report/rptGiayRaVien";
        R.Load(Server.MapPath(TenReport + ".rpt"));
        #region Report tiêu đề
        DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
        if (dtTieuDeCty != null)
            R.OpenSubreport("crpt_ThongTinDonVi.rpt").SetDataSource(dtTieuDeCty);
        #endregion
        R.SetParameterValue("txtKhoa", dt.Rows[0]["TenKhoa"].ToString().ToUpper());
        R.SetParameterValue("txtHoTen", dt.Rows[0]["tenbenhnhan"].ToString());
        R.SetParameterValue("txtTuoi", dt.Rows[0]["NgaySinh"].ToString());
        
        if (dt.Rows[0]["gioitinh"].ToString() == "0")
        {
            R.SetParameterValue("txtGioiTinh", "Nam");
        }
        else
        {
            R.SetParameterValue("txtGioiTinh", "Nữ");
        }
        R.SetParameterValue("txtNgheNghiep", dt.Rows[0]["nghenghiep"].ToString().ToLower());
        string ngaybatdau = dt.Rows[0]["bhTu"].ToString();//String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["ngaybatdau"].ToString());
        string ngaykethuc = dt.Rows[0]["bhDen"].ToString();//String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["ngayhethan"].ToString());
        #region thông tin Bảo Hiểm
        string bhyt1 = "";
        string bhyt2 = "";
        string bhyt3 = "";
        string bhyt4 = "";
        string bhyt5 = "";
        string bhyt6 = "";
        string nvk_SoBH = dt.Rows[0]["sobhyt"].ToString().Trim();
        if (ngaybatdau == "" || ngaykethuc == "" || nvk_SoBH.Equals("") || nvk_SoBH.Equals("0"))
        {
            R.SetParameterValue("txtThoiHanThe", "");
        }
        else
        {
            R.SetParameterValue("txtThoiHanThe",""+ ngaybatdau + "  đến  " + ngaykethuc);
            //string nvk_SoBH = nvk_TachChuoiBHYT_in(dt.Rows[0]["sobhyt"].ToString());
            bhyt1 = nvk_SoBH.Substring(0, 2);
            bhyt2 = nvk_SoBH.Substring(2, 1);
            bhyt3 = nvk_SoBH.Substring(3, 2);
            bhyt4 = nvk_SoBH.Substring(5, 2);
            bhyt5 = nvk_SoBH.Substring(7, 3);
            bhyt6 = nvk_SoBH.Substring(10, 5);
        }
        R.SetParameterValue("@bh1", bhyt1);
        R.SetParameterValue("@bh2", bhyt2);
        R.SetParameterValue("@bh3", bhyt3);
        R.SetParameterValue("@bh4", bhyt4);
        R.SetParameterValue("@bh5", bhyt5);
        R.SetParameterValue("@bh6", bhyt6);
        //R.SetParameterValue("txtMaBHYT", nvk_TachChuoiBHYT_in(nvk_SoBH));
        #endregion
        try
        {
            DateTime dtNgayVao = DateTime.Parse(dt.Rows[0]["ngayvaoviendk"].ToString());
            string NgayGioVaoVien = dtNgayVao.Hour + "  giờ  " + dtNgayVao.Minute + "  phút, ngày  " + dtNgayVao.Day + "  tháng  " + dtNgayVao.Month + "  năm  " + dtNgayVao.Year;
            R.SetParameterValue("txtVaoVien", NgayGioVaoVien);
        }
        catch (Exception ex)
        {
            string vaovien = DateTime.Parse(dt.Rows[0]["NgayKham"].ToString()).ToString("dd/MM/yyyy HH:mm");
            R.SetParameterValue("txtVaoVien", vaovien);
        }
        string nvk_idctdkk = dt.Rows[0]["idchitietdangkykham"].ToString();
        string sqlXK = @"
            select tenKhoaXuat=k.tenphongkhambenh,xk.*
            --,chandoanXacdinh = (select top 1 isnull(xk.MoTaCD_edit,mota) + ' ('+maicd+')' from benhnhanxuatkhoa xk
			--		             inner join chandoanicd cd on cd.idicd=xk.chandoanxuatkhoa where xk.idchitietdangkykham='" + nvk_idctdkk + @"'
			--		             and xk.idkhoaxuat='" + nvk_idkhoa + @"' order by idxuatkhoa desc)
            --,chandoanphoihop = dbo.[nvk_TongHopCDPhoiHop_XuatKhoa]('" + nvk_idctdkk + @"','" + nvk_idkhoa + @"')
			,sovaovien= isnull(
			(select top 1 SOVAOVIEN from hs_benhnhanbhdongtien bhdt inner join dangkykham dkk on dkk.IdBenhBHDongTien=id where dkk.iddangkykham = ctdkk.iddangkykham )
			,'')
            ,ngayxuat=convert(varchar(10),ngayxuatkhoa,103 ) + ' '+ convert(varchar(10),ngayxuatkhoa,108 ),NgayXuatdt=ngayxuatkhoa
            ,tinhtrangravien= tt.tenTinhTrang
			,Bacsixuatkhoa = isnull((select tenbacsi from khambenh k left join bacsi b on b.idbacsi=k.idbacsi where idkhambenh =xk.idkhambenhxk),'')

            from benhnhanxuatkhoa xk left join chandoanicd cd on convert(int,ChanDoanXuatKhoa)=cd.idicd
            left join phongkhambenh k on k.idphongkhambenh=xk.IdKhoaXuat
            left join KB_TinhTrangXuatKhoa tt on tt.idTinhTrang=xk.idtinhTrang
			left join chitietdangkykham ctdkk on ctdkk.idchitietdangkykham =xk.idchitietdangkykham
            where xk.idchitietdangkykham= '" + nvk_idctdkk + @"' and idkhoaxuat ='"+nvk_idkhoa+@"' order by idxuatkhoa desc
            ";
        DataTable dtXK = DataAcess.Connect.GetTable(sqlXK);
        if (dtXK != null && dtXK.Rows.Count > 0)
        {
            R.SetParameterValue("txtKhoa", dtXK.Rows[0]["tenKhoaXuat"].ToString().ToUpper());
            try
            {
                DateTime dtNgayRa = DateTime.Parse(dtXK.Rows[0]["NgayXuatdt"].ToString());
                string NgayGioRaVien = dtNgayRa.Hour + "  giờ  " + dtNgayRa.Minute + "  phút, ngày  " + dtNgayRa.Day + "  tháng  " + dtNgayRa.Month + "  năm  " + dtNgayRa.Year;
                R.SetParameterValue("@RaVienLuc", NgayGioRaVien); 
            }
            catch (Exception ex)
            {
                R.SetParameterValue("@RaVienLuc", dtXK.Rows[0]["ngayxuat"].ToString());
            }
            #region nvk bác sĩ điều trị
            string strBacSiDT = dtXK.Rows[0]["Bacsixuatkhoa"].ToString();
            if (strBacSiDT.Equals(""))
            {
                string sqlBs = @"
                select bs.* from (
	                select idbacsi = isnull(
	                (select top 1 idbacsi from khambenh where idchitietdangkykham ='" + nvk_idctdkk + @"' and isnull(idbacsi,0)>0 order by idkhambenh desc)
	                ,(select top 1 idbacsiNhap from benhnhannoitru where idchitietdangkykham ='" + nvk_idctdkk + @"' and isnull(idbacsiNhap,0)>0 order by ngayvaovien desc)
	                )
                )
                as abc inner join bacsi bs on bs.idbacsi= abc.idbacsi";
                DataTable dtBS = DataAcess.Connect.GetTable(sqlBs);
                if (dtBS != null && dtBS.Rows.Count > 0)
                    strBacSiDT = dtBS.Rows[0]["tenbacsi"].ToString();
            }
            #endregion
            R.SetParameterValue("txtBacSiDieuTri", strBacSiDT);

            #region chẩn đoán ra viện từ StaticData_HS
            string chanDoanRV_hs = "";
            System.Collections.Generic.List<string> list_Ma = null;
            System.Collections.Generic.List<string> list_MoTa = null;
            string ma_cd = null;
            string moTa_cd = null;
            string idbenhbhdongtien = DataAcess.Connect.GetTable(@"select isnull(
                    (select top 1 dk.IDBENHBHDONGTIEN from benhnhanxuatkhoa xk left join chandoanicd cd on cd.idicd= xk.chandoanxuatkhoa
	                    LEFT JOIN CHITIETDANGKYKHAM CTDK ON XK.IDCHITIETDANGKYKHAM=CTDK.IDCHITIETDANGKYKHAM
	                    LEFT JOIN DANGKYKHAM DK ON CTDK.IDDANGKYKHAM=DK.IDDANGKYKHAM
	                    WHERE xk.IdChiTietDangKyKham='"+nvk_idctdkk+@"'
                    ),0)").Rows[0][0].ToString();
            StaticData_HS.nvk_setTongHopChanDoan(idbenhbhdongtien, true,ref ma_cd,ref moTa_cd,ref list_Ma,ref list_MoTa);
            for (int i = 0; i < list_Ma.Count; i++)
            {
                chanDoanRV_hs += list_MoTa[i] + " (" + list_Ma[i] + "); ";
            }
            #endregion
            R.SetParameterValue("txtChanDoan", chanDoanRV_hs);// dtXK.Rows[0]["chandoanXacdinh"].ToString() + ";  " + dtXK.Rows[0]["chandoanphoihop"].ToString());
            
            //string[] arrPhuongPhap = dtXK.Rows[0]["phuongphapDT"].ToString().TrimStart('.').Split('.');
            string nvk_PhuongPhap = dtXK.Rows[0]["phuongphapDT"].ToString().TrimStart('.').Replace("\r\n", ".").Replace("..",".").Replace("@","                                    ");
            string Last_PP = nvk_PhuongPhap.Replace(".", "\r\n");
            R.SetParameterValue("@PhuongPhap1", Last_PP);
            
            string[] arrLoiDan = dtXK.Rows[0]["Loidanxuatkhoa"].ToString().TrimStart('.').Split('.');
            string nvk_LoiDan = dtXK.Rows[0]["Loidanxuatkhoa"].ToString().TrimStart('.').Replace("\r\n", ".").Replace("..", ".").Replace(". .", ".").Replace("@", "                                       ");

            R.SetParameterValue("@LoiDan1", nvk_LoiDan.Replace(".", "\r\n"));
            R.SetParameterValue("@SoBH_MaYTe", "811.6.01/" + dt.Rows[0]["mabenhnhan"].ToString().Replace("BN-", "")+"5");
            
            string nvk_SoLuuTru = dtXK.Rows[0]["sovaovien"].ToString();
            if (!txtSoLuuTru.Value.Trim().Equals(""))
                nvk_SoLuuTru = txtSoLuuTru.Value.Trim();
            R.SetParameterValue("@SoVaoVien", nvk_SoLuuTru);
            R.SetParameterValue("@nvk_tinhTrangRV", dtXK.Rows[0]["tinhtrangravien"].ToString());
            #region ngày tháng năm in 
            R.SetParameterValue("@NgayIn", forMatNgay(DateTime.Now.Day.ToString()));
            R.SetParameterValue("@ThangIn", forMatNgay(DateTime.Now.Month.ToString()));
            R.SetParameterValue("@NamIn", DateTime.Now.Year);
            #endregion
            ((TextObject)R.ReportDefinition.ReportObjects["txtdiachi"]).Text = dt.Rows[0]["diachi"].ToString();
            ((TextObject)R.ReportDefinition.ReportObjects["txtDanToc"]).Text = dt.Rows[0]["DanToc"].ToString();
        }
        else
        {
            StaticData.MsgBox(this, "Không tìm thấy thông tin !"); return;
        }
        this.report.ReportSource = R;
        this.report.DataBind(); 
       
    }
    private string forMatNgay(string ngay)
    {
        if (ngay.Length < 2)
            ngay = "0" + ngay;
        return ngay;
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
    protected void report_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
    }
    protected void btnLayBaoCao_Click(object sender, EventArgs e)
    {
        loadData();
    }
    private string nvk_TachChuoiBHYT_in(string SoBHYT)
    {
        string BHYT = (SoBHYT != null ? SoBHYT : "");
        string bhyt1 = "";
        string bhyt2 = "";
        string bhyt3 = "";
        string bhyt4 = "";
        string bhyt5 = "";
        string bhyt6 = "";
        if (BHYT.Length > 10)
        {
            bhyt1 = BHYT.Substring(0, 2);
            bhyt2 = BHYT.Substring(2, 1);
            bhyt3 = BHYT.Substring(3, 2);
            bhyt4 = BHYT.Substring(5, 2);
            bhyt5 = BHYT.Substring(7, 3);
            bhyt6 = BHYT.Substring(10, 5);

            BHYT = bhyt1 + " " + bhyt2 + " " + bhyt3 + " " + bhyt4 + " " + bhyt5 + " " + bhyt6;
        }
        return BHYT;
    }
}

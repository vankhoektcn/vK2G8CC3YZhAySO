using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using DataAcess;
using Profess;

public partial class noitru_frm_Rpt_BieuMau02 : Page
{
    //public string IdPhieuThanhToan = "3";
    private ReportDocument R;
    private string nvk_listMaIcd = "";
    private string nvk_listMoTaIcd = "";
    //_______________________________________________________________________________________________
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["idchitietdangkykham"] == null || Request.QueryString["idchitietdangkykham"].ToString().Equals("")) // từ thanh toán Nội trú,cấp Cứu
        {
            StaticData.MsgBox(this, "Không có thông tin !"); return;
        }
        string TieuDeBangKe = "BẢNG KÊ CHI PHÍ KHÁM BỆNH, CHỮA BỆNH NỘI TRÚ";
        string SoMau = " 02/BV";
        int idphieutt = 0;
        int iddangkykham = 0;
        int Idbenhnhan = 0;
        string IdChiTietDkk = "0";
        string strDateNgayBH = "";
        string isNoiTru = "0";
        string vaovien = "";
        string TGxuatvien = "";
        string SoKhamBenh = "";
        string SoNgayDieuTri = "";
        IdChiTietDkk = Request.QueryString["idchitietdangkykham"];
        string sql_dongtien = @"
            select top 1 hs.id,
                        nvk_IsNoiTru=convert(int,hs.IsNoiTru),
                        nvk_isBH=convert(int,hs.isBHYT),
                        nvk_BNphaiTra=isnull(hs.BNphaiTra,0),
                        nvk_PhuThu=isnull(hs.tienPhuThuBH,0),
                        nvk_DichVu=isnull(hs.tienGiaDV,0),
                        nvk_TongTienBNPT=isnull(TongTienBNPT,0),
                        nvk_TongTienBNDaTra=isnull(TongTienBNDaTra,0)-isnull(TOTAL_HOANPHI,0),
                        nvk_bnptConLai=isnull(TongTienBNPT,0)-(isnull(TongTienBNDaTra,0)-isnull(TOTAL_HOANPHI,0)),
                        nvk_tenKhoa=(SELECT TENPHONGKHAMBENH FROM KHAMBENH A1 LEFT JOIN PHONGKHAMBENH B1 ON ISNULL(A1.IDKHOA,A1.IDPHONGKHAMBENH)=B1.IDPHONGKHAMBENH WHERE IDKHAMBENH=HS.IDKHAMBENH_LAST) ,
                        LoaiKhamID=dk.LoaiKhamID
                        ,HS.NgayTinhBH
                        ,HS.NgayTinhBH_Thuc
                        ,MASOHOSO=HS.MASOHOSO
                        ,IDBENHNHAN=HS.IDBENHNHAN
            from chitietdangkykham ct 
             left join dangkykham dk on dk.iddangkykham=ct.iddangkykham 
            left join hs_benhnhanbhdongtien hs on hs.id=dk.IdBenhBHDongTien
            where idchitietdangkykham ='" + IdChiTietDkk + "'";

        DataTable dt_bhdongtien = DataAcess.Connect.GetTable(sql_dongtien);
        string nvk_idbenhnhanBHdongtien = "0";
        if (dt_bhdongtien != null && dt_bhdongtien.Rows.Count > 0 && !dt_bhdongtien.Rows[0]["id"].ToString().Equals("0"))
        {
            if (!dt_bhdongtien.Rows[0]["nvk_IsNoiTru"].ToString().Equals("1"))
            {
                    Response.Redirect("../VienPhi_BH/frm_rpt_chiphikhambenh.aspx?idphieutt=" + dt_bhdongtien.Rows[0]["id"].ToString() + "");
                    return;
            }
            
        }
        else
        {
            StaticData.MsgBox(this, "Không lấy được biểu mẫu !"); return;
        }
       
        Idbenhnhan = StaticData.ParseInt(dt_bhdongtien.Rows[0]["idbenhnhan"].ToString());
        SoKhamBenh = dt_bhdongtien.Rows[0]["MASOHOSO"].ToString();
        nvk_idbenhnhanBHdongtien = dt_bhdongtien.Rows[0]["id"].ToString();
        string giaKham = "giaBH";
        string LoaiKhamID = dt_bhdongtien.Rows[0]["LoaiKhamID"].ToString();
        if(LoaiKhamID!="1")    giaKham = "GiaDichVu";
        DateTime NgayThangNam = Connect.d_SystemDate();
        DataTable dt = StaticData_HS.nvk_thongTimBaohiemBy_idbnbhdt(nvk_idbenhnhanBHdongtien);
        if (dt == null || dt.Rows.Count == 0) return;
        DataTable dtDetail = null;
        string chuoi = @"select *,TenKhoa=KHOADICHVU from [dbo].[nvk_Mau02_TheoKhoa_TH_idbhDongTien](" + nvk_idbenhnhanBHdongtien + @") a where noidung is not null order by KHOADICHVU, STT,NOIDUNG";
        dtDetail = Connect.GetTable(chuoi);
        if (dtDetail == null) return;
        R = new ReportDocument();
        string TenReport = "rptBieuMau02";
        R.Load(Server.MapPath("../report/" + TenReport + ".rpt"));
        R.SetDataSource(dtDetail);

        #region {LOAD HEADER}

        string strSo = "";
        string BV = "";
        string nvk_tenKhoa = dt_bhdongtien.Rows[0]["nvk_tenKhoa"].ToString();//nvk_tenKhoa;
        string[] arrTD = StaticData.TenCty.Split('-');
        if (arrTD.Length == 2)
        {
            strSo = arrTD[0];
            BV = arrTD[1];
        }
        if (strSo.Trim() == "") strSo = "Sở Y Tế tỉnh Bến Tre";
        if (BV.Trim() == "") BV = "Bệnh viện Minh Đức";
        R.SetParameterValue("txtHeaderLeft1", strSo);
        R.SetParameterValue("txtHeaderLeft2", BV);
        R.SetParameterValue("txtHeaderLeft3", nvk_tenKhoa);
        R.SetParameterValue("txtHeaderMain1", TieuDeBangKe);
        R.SetParameterValue("txtHeaderMain2", "");
        R.SetParameterValue("txtHeaderRight1", SoMau);
        R.SetParameterValue("txtHeaderRight2", SoKhamBenh);
        R.SetParameterValue("txtHeaderRight3", dt.Rows[0][TBLS.tbl_benhnhan.mabenhnhan.ToString()]);

        #endregion

        #region {TACH CHUOI BHYT}

        if (dt.Rows[0]["sobhyt"].ToString() != "")
        {
            string BHYT = dt.Rows[0][TBLS.tbl_benhnhan.sobhyt.ToString()].ToString();
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
            }
            R.SetParameterValue("BHYT1", bhyt1);
            R.SetParameterValue("BHYT2", bhyt2);
            R.SetParameterValue("BHYT3", bhyt3);
            R.SetParameterValue("BHYT4", bhyt4);
            R.SetParameterValue("BHYT5", bhyt5);
            R.SetParameterValue("BHYT6", bhyt6);
        }
        else
        {
            R.SetParameterValue("BHYT1", "");
            R.SetParameterValue("BHYT2", "");
            R.SetParameterValue("BHYT3", "");
            R.SetParameterValue("BHYT4", "");
            R.SetParameterValue("BHYT5", "");
            R.SetParameterValue("BHYT6", "");
        }

        #endregion

        #region {LOAD THONG TIN BENH NHAN}

        R.SetParameterValue("txtHoTenBN", dt.Rows[0][TBLS.tbl_benhnhan.tenbenhnhan.ToString()].ToString());
        R.SetParameterValue("txtNgaySinh", dt.Rows[0]["NgaySinh"].ToString());
        R.SetParameterValue("txtDiaChi",( dt.Rows[0][TBLS.tbl_benhnhan.noicongtac.ToString()].ToString().Trim()!="" ? dt.Rows[0][TBLS.tbl_benhnhan.noicongtac.ToString()].ToString() : dt.Rows[0][TBLS.tbl_benhnhan.diachi.ToString()].ToString()));
        R.SetParameterValue("txtGioiTinhNu",
                            dt.Rows[0][TBLS.tbl_benhnhan.gioitinh.ToString()].ToString() == "1" ? "a" : "");
        R.SetParameterValue("txtGioiTinhNam",
                            dt.Rows[0][TBLS.tbl_benhnhan.gioitinh.ToString()].ToString() == "1" ? "" : "a");
        R.SetParameterValue("txtCoBHYT", dt.Rows[0]["loai"].ToString() == "1" ? "a" : "");
        R.SetParameterValue("txtKoCoBHYT", dt.Rows[0]["loai"].ToString() == "1" ? "" : "a");
        R.SetParameterValue("txtMaBHYT", dt.Rows[0][TBLS.tbl_benhnhan.sobhyt.ToString()].ToString());
        string ngaybatdau = String.Format("{0:dd/MM/yyyy}", dt.Rows[0][TBLS.tbl_benhnhan.ngaybatdau.ToString()]);
        string ngaykethuc = String.Format("{0:dd/MM/yyyy}", dt.Rows[0][TBLS.tbl_benhnhan.ngayhethan.ToString()]);
        if (ngaybatdau == "" || ngaykethuc == "")
        {
            R.SetParameterValue("txtGiaTriTu", "");
        }
        else
        {
            R.SetParameterValue("txtGiaTriTu", ngaybatdau + " đến " + ngaykethuc);
        }
        R.SetParameterValue("txtCoSoDKBH", dt.Rows[0]["noidangkykcb"].ToString());
        R.SetParameterValue("txtMaCSDKBH", dt.Rows[0]["MaDangKy_KCB_bandau"].ToString());

        if (dt.Rows[0]["ngaynhapvien"].ToString() != "" && vaovien.Trim() == "")
            vaovien = dt.Rows[0]["ngaynhapvien"].ToString();
        int lng = dt.Rows.Count;
        for (int i = lng; i > 0; i--)
        {
            if (dt.Rows[i - 1]["ngayxuatvien"].ToString() != "")
            {
                TGxuatvien = dt.Rows[i - 1]["ngayxuatvien"].ToString();
                break;
            }
        }

        DateTime NgayTinhBH = DateTime.Parse(dt_bhdongtien.Rows[0]["NgayTinhBH"].ToString());
        DateTime NgayTinhBH_Thuc = DateTime.Parse(dt_bhdongtien.Rows[0]["NgayTinhBH_Thuc"].ToString());

        DateTime NgayTinhBH0 = DateTime.Parse( DateTime.Parse(dt_bhdongtien.Rows[0]["NgayTinhBH"].ToString()).ToString("yyyy-MM-dd 00:00:00"));
        DateTime NgayTinhBH_Thuc0 = DateTime.Parse( DateTime.Parse(dt_bhdongtien.Rows[0]["NgayTinhBH_Thuc"].ToString()).ToString("yyyy-MM-dd 23:59:59"));
        TimeSpan SoNgayDT_span = (TimeSpan)(NgayTinhBH_Thuc0 - NgayTinhBH0);
        int songaydt =(int) SoNgayDT_span.TotalDays;
        if (songaydt == 0) songaydt = 1;

        string vaovienluc = NgayTinhBH.ToString("HH") + " giờ " + NgayTinhBH.ToString("mm") + ", ngày " + NgayTinhBH.ToString("dd/MM/yyyy");
        string ravienluc = NgayTinhBH_Thuc.ToString("HH") + " giờ " + NgayTinhBH_Thuc.ToString("mm") + ", ngày " + NgayTinhBH_Thuc.ToString("dd/MM/yyyy");
        R.SetParameterValue("txtDenKham", vaovienluc);
        R.SetParameterValue("txtKetThucDieuTri", ravienluc);
        R.SetParameterValue("txtTongNgayDieuTri", songaydt);

        if (LoaiKhamID != "1")
        {
            R.SetParameterValue("txtDungTuyen", "");
            R.SetParameterValue("txtTraiTuyen", "");
            R.SetParameterValue("txtCapCuu", "");
        }
        else
        {
            if (dt.Rows[0]["DungTuyen"].ToString() == "Y")
            {
                R.SetParameterValue("txtDungTuyen", "a");
                R.SetParameterValue("txtTraiTuyen", "");
            }
            if (dt.Rows[0]["DungTuyen"].ToString() == "N")
            {
                R.SetParameterValue("txtDungTuyen", "");
                R.SetParameterValue("txtTraiTuyen", "a");
            }
            if (dt.Rows[0]["DungTuyen"].ToString() == "")
            {
                R.SetParameterValue("txtDungTuyen", "");
                R.SetParameterValue("txtTraiTuyen", "");
            }
            R.SetParameterValue("txtCapCuu", (StaticData.IsCheck( dt.Rows[0]["capcuu"].ToString()) ? "a" :"") );
        }
        R.SetParameterValue("txtNoiChuyenDen", dt.Rows[0]["noigioithieu"].ToString());
       StaticData_HS.nvk_setTongHopChanDoan(nvk_idbenhnhanBHdongtien,true,ref nvk_listMaIcd,ref nvk_listMoTaIcd);
        R.SetParameterValue("@chandoan", nvk_listMoTaIcd);
        R.SetParameterValue("txtMaBenh", nvk_listMaIcd);
        
        #endregion
        #region tổng tiền, hoàn trả, thu thêm
        float nvk_tongChiPhi = StaticData.ParseFloat(dt_bhdongtien.Rows[0]["nvk_TongTienBNPT"]);//nvk_TongTienBNPT
        float nvk_daThanhToan = StaticData.ParseFloat(dt_bhdongtien.Rows[0]["nvk_TongTienBNDaTra"]);
        float nvk_hoanTra = 0;
        float nvk_thuThem = 0;
        float nvk_HoanTraChu = StaticData.ParseFloat(dt_bhdongtien.Rows[0]["nvk_bnptConLai"]);
        if (nvk_HoanTraChu > 0)
            nvk_thuThem = nvk_HoanTraChu;
        else
        {
            nvk_HoanTraChu = nvk_HoanTraChu * -1;
            nvk_hoanTra = nvk_HoanTraChu;
        }
        string str_SO = new clsDocSo.clsDocSo().ChuyenSo(nvk_tongChiPhi.ToString());
        R.SetParameterValue("txtTongTienChu", str_SO);
        R.SetParameterValue("txtNguonKhac", nvk_daThanhToan);
        ((TextObject)R.ReportDefinition.ReportObjects["txtTienHoanTraBN"]).Text = StaticData.FormatNumberOption(nvk_hoanTra, ".", ",", false).ToString() + " VNĐ";
        ((TextObject)R.ReportDefinition.ReportObjects["txtThuThem"]).Text = StaticData.FormatNumberOption(nvk_thuThem, ".", ",", false).ToString() + " VNĐ";
        ((TextObject)R.ReportDefinition.ReportObjects["txtHoanTraChu"]).Text = new clsDocSo.clsDocSo().ChuyenSo(nvk_HoanTraChu.ToString());
        #endregion
        #region trong đó
        if (dt_bhdongtien.Rows[0]["nvk_isBH"].ToString().Equals("1"))
        {
            float nvk_tiendichvu = StaticData.ParseFloat(dt_bhdongtien.Rows[0]["nvk_PhuThu"].ToString()) + StaticData.ParseFloat(dt_bhdongtien.Rows[0]["nvk_DichVu"].ToString());
            string nvk_trongdo = "(Đồng chi trả: " + StaticData.FormatNumberOption(dt_bhdongtien.Rows[0]["nvk_BNphaiTra"], ".", ",", false) + " VNĐ    Dịch vụ: " + StaticData.FormatNumberOption(nvk_tiendichvu, ".", ",", false) + " VNĐ)";
            ((TextObject)R.ReportDefinition.ReportObjects["txtTrongDo"]).Text = nvk_trongdo;
        }
        #endregion
        crptPhieuThanhToan.ReportSource = R;
        crptPhieuThanhToan.DataBind();
    }
    
    //_______________________________________________________________________________________________
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
    }
    //_______________________________________________________________________________________________
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
    }
    //_______________________________________________________________________________________________
    #region khoi tao va giai phong bo nho

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }

    private void InitialComponent()
    {
        Unload += form_unload;
    }

    #endregion
    //_______________________________________________________________________________________________
    #region TinhLaiTien
   protected void TinhLaiTien(object sender, EventArgs e)
    {
        if (Request.QueryString["idchitietdangkykham"] == null || Request.QueryString["idchitietdangkykham"].ToString().Equals("")) // từ thanh toán Nội trú,cấp Cứu
        {
            StaticData.MsgBox(this, "Không có thông tin !"); return;
        }
        string sqlSelect = "SELECT IDDANGKYKHAM FROM CHITIETDANGKYKHAM WHERE IDCHITIETDANGKYKHAM=" + Request.QueryString["idchitietdangkykham"];
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt == null || dt.Rows.Count == 0) return;
        StaticData.TinhLaiTien_ByIdDangKyKham(dt.Rows[0][0].ToString());
        StaticData.MsgBox(this, "Đã tính lại tiền !"); return;

    }
    #endregion

}
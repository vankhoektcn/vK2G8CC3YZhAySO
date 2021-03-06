using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;
using DataAcess;
using iTextSharp.text.pdf;
using SysParameter;
using System.Collections.Generic;
public partial class frm_rpt_InPhieuThuTH : System.Web.UI.Page
{
    private ReportDocument crystalReport = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Request.QueryString["ID"];
        if (ID == null || ID == "") return;
        string sqlInforAll = @"SELECT IDBENHNHAN,DungTuyen
                            ,TYLE= convert(float, A.BHTRA)/ convert(float, A.TONGTIENBH)*100
                            ,NgayTinhBH
                            ,NgayTinhBH_Thuc
                            ,SoNgayDieuTri=CONVERT(INT,NgayTinhBH_Thuc-NgayTinhBH)
                            FROM HS_BENHNHANBHDONGTIEN A WHERE ID=" + ID;
        DataTable dtInforAll = DataAcess.Connect.GetTable(sqlInforAll);
        if (dtInforAll == null || dtInforAll.Rows.Count == 0) return;
        string TyLe = dtInforAll.Rows[0]["TYLE"].ToString();

        string NgayThu = null;
        #region Get DataSource
        string sqlSelect = "";
        DataTable dtsrc = null;
        sqlSelect = @"(
	                            SELECT    
			                             DienGiai= TENDICHVU
                                        ,SOLUONG=A.SOLUONG
                                        ,dvt = N'Lần'
                                        ,DonGiaBH=A.DONGIABH
                                        ,PHAMVI=A.THANHTIENBH
                                        ,TyLe="+TyLe+ @"
                                        ,SOTIEN=A.BNTRA
                                        ,nLoaiPhi=1
                                        ,loaiphi=N'Phí khám'
	                            FROM CHITIETDANGKYKHAM A
	                            LEFT JOIN BANGGIADICHVU B ON A.IDBANGGIADICHVU=B.IDBANGGIADICHVU
	                            LEFT JOIN DANGKYKHAM E ON A.IdDangKyKham=E.IdDangKyKham
	                            WHERE	A.ISBHYT=1 
			                            AND ISNULL(A.DAHUY,0)=0
			                            AND E.IdBenhBHDongTien='" + ID + @"'
                        )
                        UNION
                        (
	                            SELECT   DISTINCT
			                             DienGiai=TENDICHVU
                                        ,SOLUONG=SUM(A.SOLUONG)
                                        ,dvt = N'Lần'
                                        ,DonGiaBH=A.DONGIABH
                                        ,PHAMVI=SUM(A.THANHTIENBH)
                                        ,TyLe=" + TyLe + @"
                                        ,SOTIEN=SUM(A.BNTRA)
                                        ,nLoaiPhi=2
                                        ,LoaiPhi=N'Phí cận lâm sàng'
                                
	                            FROM KHAMBENHCANLAMSAN A
	                            LEFT JOIN BANGGIADICHVU B ON A.IDCANLAMSAN=B.IDBANGGIADICHVU
	                            LEFT JOIN KHAMBENH D ON A.IDKHAMBENH=D.IDKHAMBENH
	                            LEFT JOIN DANGKYKHAM E ON D.IdDangKyKham=E.IdDangKyKham
	                            WHERE	A.ISBHYT=1 
			                            AND ISNULL(A.DAHUY,0)=0
			                            AND E.IdBenhBHDongTien=" + ID + @"
                         GROUP BY
                                         TENDICHVU
                                        ,A.DONGIABH
                        )

                        UNION
                        (
		                            SELECT DISTINCT  
			                             DienGiai=B.TENTHUOC
                                        ,SOLUONG=SUM(ISNULL(A.SOLUONG_BK,A.SOLUONG))
                                        ,dvt = TENDVT
                                        ,DonGiaBH=A.DONGIABH
                                        ,PHAMVI=SUM(A.THANHTIENBH)
                                        ,TyLe=" + TyLe + @"
                                        ,SOTIEN=SUM(A.BNTRA)
                                        ,nLoaiPhi=3
                                        ,LoaiPhi=N'Phí thuốc & VTYT'
		                            
                                    FROM CHITIETPHIEUXUATKHO A 
                                    LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
		                            LEFT JOIN KHAMBENH D ON A.IDKHAMBENH1=D.IDKHAMBENH
		                            LEFT JOIN DANGKYKHAM E ON D.IdDangKyKham=E.IdDangKyKham
                                    LEFT JOIN THUOC_DONVITINH H ON B.IDDVT=H.ID
		                            WHERE	A.ISBHYT=1 
				                            AND E.IdBenhBHDongTien=" + ID + @"
                                            AND A.ISTINHTIEN=1
                                     GROUP BY 
                                        B.TENTHUOC
                                        ,TENDVT
                                        ,A.DONGIABH
                                            
                        )

                    UNION
                  (
 
		                            SELECT   
				                          DienGiai=D.GIUONGCODE
                                        ,SOLUONG=SUM(A.SL)
                                        ,dvt = N'Ngày'
                                        ,DonGiaBH=A.DONGIABH
                                        ,PHAMVI=SUM(A.THANHTIENBH)
                                        ,TyLe=" + TyLe + @"
                                        ,SOTIEN=SUM(A.BNTRA)
                                        ,nLoaiPhi=4
                                        ,LoaiPhi=N'Phí tiền gường'
                                        from kb_chitietgiuongbn a
                                        left join chitietdangkykham b on a.idchitietdangkykham=b.idchitietdangkykham
                                        left join dangkykham c on b.IdDangKyKham=c.IdDangKyKham
                                        left join kb_giuong d on a.idgiuong=d.giuongid
                                        where c.idbenhbhdongtien=" + ID + @"
                                                AND A.ISBHYT=1 AND A.THANHTIENBH>0
                                        GROUP BY 
                                        D.GIUONGCODE
                                        ,A.DONGIABH
                        )";

                    
         dtsrc = DataAcess.Connect.GetTable(sqlSelect);
        if (dtsrc == null || dtsrc.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không thể load được thông tin phiếu thu !");
            return;
        }
        if (dtsrc == null) return;
        #endregion
        #region View in CrytalReport
        crystalReport = new ReportDocument();
        #region ReportName
        string ReportPath = "ReportDesign";
        string ReportName = "";
        ReportName = "rptbangkechiphidongchitra.rpt";
        ReportName = ReportPath + "/" + ReportName;
        crystalReport.Load(Server.MapPath(ReportName));
        #endregion
        #region DataSource
        string sotienbangchu = "";
        string idbenhnhan_in = dtInforAll.Rows[0]["idbenhnhan"].ToString();
        double tongtien_in = 0;
        //Profess_1511.benhnhan bn_in = Profess_1511.benhnhan.Create_benhnhan(idbenhnhan_in);
            DataTable dtBenhNhan = DataAcess.Connect.GetTable("SELECT * FROM BENHNHAN WHERE IDBENHNHAN=" + idbenhnhan_in);
            #region Report tiêu đề công ty
            DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
            if (dtTieuDeCty != null)
                crystalReport.OpenSubreport("crpt_ThongTinDonVi.rpt").SetDataSource(dtTieuDeCty);
            string tieude = dtTieuDeCty.Rows[0]["Ten_Cty"].ToString();
            string[] slp = tieude.Split('-');
            string til = slp[0];
            string subtil = (slp.Length > 1 ? slp[1] : "");
            //((TextObject)R.OpenSubreport("crpt_ThongTinDonVi.rpt").ReportDefinition.ReportObjects["txtSubtitle"]).Text = subtil;
            ((TextObject)crystalReport.OpenSubreport("crpt_ThongTinDonVi.rpt").ReportDefinition.ReportObjects["txtTitle"]).Text = til;
            #endregion
            DataSet ds = new DataSet();
            DataTable dt_new = dtsrc;
            #region ma vach
            string mabenhnhan = dtBenhNhan.Rows[0]["mabenhnhan"].ToString();
            Barcode128 barcode = new Barcode128();
            barcode.ChecksumText = false;
            barcode.Code = mabenhnhan;
            DataTable dtmavach = new DataTable();
            DataRow Ro = dtmavach.NewRow();
            Image bmp = barcode.CreateDrawingImage(Color.Black, Color.White);
            Byte[] arrByte = (Byte[])TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
            dtmavach.Columns.Add("MaVachKhoe", arrByte.GetType());
            Ro["MaVachKhoe"] = arrByte;
            dtmavach.Rows.Add(Ro);

            #endregion
            double tempTyLe = 0;
            for (int ii = 0; ii < dtsrc.Rows.Count; ii++)
            {
                string tongtien = dtsrc.Rows[ii]["SOTIEN"].ToString();
                if (tongtien == "") tongtien = "0";
                tongtien_in += double.Parse(tongtien);
            }
            tongtien_in = Math.Floor(Math.Round(tongtien_in, 0));
            sotienbangchu = StaticData.ConvertMoneyToText(tongtien_in.ToString());
            dtmavach.TableName = "MaVach";
            ds.Tables.Add(dtmavach);
            dt_new.TableName = "phichitra";
            ds.Tables.Add(dt_new);
            crystalReport.SetDataSource(ds);
        #endregion
        #region set parameter
            crystalReport.SetParameterValue("txtTienChu", sotienbangchu);
            crystalReport.SetParameterValue("txtMaBN", dtBenhNhan.Rows[0]["mabenhnhan"].ToString());
            crystalReport.SetParameterValue("txtTenBN", dtBenhNhan.Rows[0]["tenbenhnhan"].ToString());
            crystalReport.SetParameterValue("txtDiaChi", dtBenhNhan.Rows[0]["diachi"].ToString());
            crystalReport.SetParameterValue("txtSoDienThoai", dtBenhNhan.Rows[0]["dienthoai"].ToString());
            crystalReport.SetParameterValue("txtNgaySinh", dtBenhNhan.Rows[0]["NgaySinh"].ToString());
            crystalReport.SetParameterValue("txtGioiTinh", dtBenhNhan.Rows[0]["Gioitinh"].ToString());
            crystalReport.SetParameterValue("NgayThu", DateTime.Now.ToString("dd/MM/yyyy"));
             bool IsDungTuyen=StaticData.IsCheck(dtInforAll.Rows[0]["DungTuyen"].ToString());
             crystalReport.SetParameterValue("txtDungTuyen", (IsDungTuyen == true ? "a" : ""));
             crystalReport.SetParameterValue("txtTraiTuyen", (IsDungTuyen == true ? "" : "a"));
             DateTime NgayTinhBH=DateTime.Parse(dtInforAll.Rows[0]["NgayTinhBH"].ToString());
             DateTime NgayTinhBH_Thuc=DateTime.Parse(dtInforAll.Rows[0]["NgayTinhBH_Thuc"].ToString());
             string denkhamluc = NgayTinhBH.ToString("HH") + " giờ " + NgayTinhBH.ToString("mm") + ", ngày " + NgayTinhBH.ToString("dd/MM/yyyy");
             string ketthucluc = NgayTinhBH_Thuc.ToString("HH") + " giờ " + NgayTinhBH_Thuc.ToString("mm") + ", ngày " + NgayTinhBH_Thuc.ToString("dd/MM/yyyy");
             crystalReport.SetParameterValue("txtDenKham",denkhamluc );
             crystalReport.SetParameterValue("txtKetThucDieuTri",ketthucluc);
             crystalReport.SetParameterValue("txtTongNgayDieuTri", dtInforAll.Rows[0]["SoNgayDieuTri"]);

            string headerText = "BẢNG KÊ CHI PHÍ ĐỒNG CHI TRẢ";
            crystalReport.SetParameterValue("HeaderText", headerText);
        #endregion
            #region nvk set parameter
            nvk_SetPara_HanhChinh(Request.QueryString["ID"]);
            #endregion
            this.crptView.ReportSource = crystalReport;
        this.crptView.DataBind();
        #endregion

    }
    
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    protected void Ctrhuehongbs_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
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

    private void nvk_SetPara_HanhChinh(string idbenhnhanbhdongtien)
    {
        DataTable dt_hanhChinh =  StaticData_HS.nvk_thongTimBaohiemBy_idbnbhdt(idbenhnhanbhdongtien); 
        string nvk_DiaChi = "";
        string nvk_SoDienThoai = "";
        string nvk_ThoiHanthe = "";
        string nvk_noiDkKcbBd = "";
        string nvk_bh1 = "";
        string nvk_bh2 = "";
        string nvk_bh3 = "";
        string nvk_bh4 = "";
        string nvk_bh5 = "";
        string nvk_bh6 = "";
        string nvk_ListMaChanDoan = "";
        string nvk_ListMoTaChanDoan = "";
        if (dt_hanhChinh != null && dt_hanhChinh.Rows.Count > 0)
        {
            nvk_DiaChi = dt_hanhChinh.Rows[0]["diachi"].ToString();
            nvk_SoDienThoai = dt_hanhChinh.Rows[0]["dienthoai"].ToString();
            nvk_ThoiHanthe = dt_hanhChinh.Rows[0]["thoihanthe"].ToString();
            nvk_noiDkKcbBd = dt_hanhChinh.Rows[0]["noidangkykcb"].ToString();
            string SoBhyt_Bn = dt_hanhChinh.Rows[0]["sobhyt"].ToString();
            if (SoBhyt_Bn.Length > 10)
            {
                nvk_bh1 = SoBhyt_Bn.Substring(0, 2);
                nvk_bh2 = SoBhyt_Bn.Substring(2, 1);
                nvk_bh3 = SoBhyt_Bn.Substring(3, 2);
                nvk_bh4 = SoBhyt_Bn.Substring(5, 2);
                nvk_bh5 = SoBhyt_Bn.Substring(7, 3);
                nvk_bh6 = SoBhyt_Bn.Substring(10, 5);
            }
            StaticData_HS.nvk_setTongHopChanDoan(idbenhnhanbhdongtien, StaticData.IsCheck(dt_hanhChinh.Rows[0]["IsNoiTru"].ToString()), ref nvk_ListMaChanDoan, ref nvk_ListMoTaChanDoan);
        }
        try { crystalReport.SetParameterValue("@nvk_DiaChi", nvk_DiaChi); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@nvk_SoDienThoai", nvk_SoDienThoai); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@nvk_ThoiHanthe", nvk_ThoiHanthe); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@nvk_noiDkKcbBd", nvk_noiDkKcbBd); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh1", nvk_bh1); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh2", nvk_bh2); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh3", nvk_bh3); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh4", nvk_bh4); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh5", nvk_bh5); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("@bh6", nvk_bh6); }
        catch (Exception) { }

        //try {
            crystalReport.SetParameterValue("txtMaCSDKBH", dt_hanhChinh.Rows[0]["MaDangKy_KCB_bandau"]);
            
            crystalReport.SetParameterValue("txtNoiChuyenDen", dt_hanhChinh.Rows[0]["noigioithieu"].ToString());// bên trên
            crystalReport.SetParameterValue("txtMaBenh", nvk_ListMaChanDoan);
            crystalReport.SetParameterValue("txtCapCuu",(StaticData.IsCheck( dt_hanhChinh.Rows[0]["capcuu"].ToString()) ? "a":""));
            crystalReport.SetParameterValue("@chandoan", nvk_ListMoTaChanDoan);
            
        //}
        //catch (Exception) { }
    }
   
   
   
}
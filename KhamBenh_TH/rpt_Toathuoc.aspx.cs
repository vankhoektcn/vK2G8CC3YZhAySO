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

public partial class rpt_Toathuoc : Page
{
    string IdBenhNhanToaThuoc = "";
    ReportDocument crystalReport;
    private bool isToaThuocBHFull = StaticData.IsCheck(StaticData.GetParameter("isToaThuocBHFull"));
    private bool isHaveCLSToaThuocBH = StaticData.IsCheck(StaticData.GetParameter("isHaveCLSToaThuocBH"));
    private bool isToaThuocA5 = StaticData.IsCheck(StaticData.GetParameter("isToaThuocA5"));
    private string isToaBH = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string IdKhamBenh = Request.QueryString["IdKhamBenh"].ToString();
        isToaBH = !string.IsNullOrEmpty(Request.QueryString["IsBHYT"]) && Request.QueryString["IsBHYT"].ToString().Equals("1") ? "1" : "0";
        if (IdKhamBenh == null || IdKhamBenh == "" || IdKhamBenh == "0") return;
        DataTable dtTemp = DataAcess.Connect.GetTable("SELECT TOP 1 IDBENHNHANTOATHUOC FROM BENHNHANTOATHUOC WHERE IDKHAMBENH=" + IdKhamBenh + " ORDER BY IDBENHNHANTOATHUOC DESC");
        if (dtTemp == null || dtTemp.Rows.Count == 0) return;
        IdBenhNhanToaThuoc = dtTemp.Rows[0][0].ToString();
        load();
    }
    private DataTable loadDV(string idKhamBenh, string IsAll)
    {
        string sW = "";
        string ColumTenDV = "tendichvu";
        if (Request.QueryString["IsBH"] != null && Request.QueryString["IsBH"].ToString() != "")
        {
            sW = " and bg.isSudungchobh='" + Request.QueryString["IsBH"].ToString() + "'";
            if (Request.QueryString["IsBH"].ToString() == "1")
                ColumTenDV = "TenBaoHiem";
            else
                ColumTenDV = "tendichvu";
        }
        if (Request.QueryString["listIdCls"] == null)
        {
            if (Request.QueryString["listIdClsCu"] != null && Request.QueryString["listIdClsCu"].ToString().TrimStart(',').TrimEnd(',') != "")
                sW += " and  bg.idbanggiadichvu in(" + Request.QueryString["listIdClsCu"].ToString().TrimStart(',').TrimEnd(',') + ")";
        }
        else
        {
            if (Request.QueryString["listIdClsCu"] != null && Request.QueryString["listIdClsCu"].ToString().TrimStart(',').TrimEnd(',') != "")
                sW += " and  bg.idbanggiadichvu not in(" + Request.QueryString["listIdClsCu"].ToString().TrimStart(',').TrimEnd(',') + ")";
            if (Request.QueryString["listIdCls"].ToString().TrimStart(',').TrimEnd(',') != "")
                sW += " and  bg.idbanggiadichvu in(" + Request.QueryString["listIdCls"].ToString().TrimStart(',').TrimEnd(',') + ")";
        }
        string IsBH = Request.QueryString["IsBH"];
        string SoBHYT_Columns = "soBHYT";
        if (IsBH != null && IsBH == "0")
            SoBHYT_Columns = "''";

        string sql = @"select
                            tendichvu=bg." + ColumTenDV + @",
                            khoa.tenphongkhambenh,
                            soluong=cls.soluong
            from khambenhcanlamsan cls left join khambenh kb on kb.idkhambenh=cls.idkhambenh
            left join chitietdangkykham ctdk on ctdk.idchitietdangkykham=kb.idchitietdangkykham
            inner join banggiadichvu bg on bg.idbanggiadichvu=cls.idcanlamsan
            left join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan
            left join phongkhambenh khoa on bg.idphongkhambenh= khoa.idphongkhambenh
            left join bacsi bs on bs.idbacsi=kb.idbacsi
            left join chandoanicd icd on icd.idicd=kb.ketluan
            where  isnull(cls.dahuy,0)=0 and cls.idkhambenh=" + idKhamBenh + sW;
        if (IsAll != "1")
        {
            sql += " AND ISNULL(cls.ISBNDaTra,0)=0 AND ISNULL(CLS.DATHU,0)=0";
        }

        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;
    }
    void load()
    {
        crystalReport = new ReportDocument();
        string ReportSourceName = "ToaThuocBH_CLS_hidden";
        if (isToaThuocBHFull)
        {
            if (isToaThuocA5)
                ReportSourceName = "ToaThuocBH_CLS_A5_full";
            else
                ReportSourceName = "ToaThuocBH_CLS_full";
        }
        else
        {
            if (isToaThuocA5)
                ReportSourceName = "ToaThuocBH_CLS_A5_full";
            else
                ReportSourceName = "ToaThuocBH_CLS_hidden";
        }
        if (Request.QueryString["IsToaRV"] != null && Request.QueryString["IsToaRV"].ToString() == "1")
            ReportSourceName = "crptToaThuocRaVien_CLS2";
        crystalReport.Load(Server.MapPath("ReportDesign/" + ReportSourceName + ".rpt"));

        #region subReportCLS
        if (isHaveCLSToaThuocBH)
        {
            string IdKhamBenh = Request.QueryString["IdKhamBenh"].ToString();
            if (IdKhamBenh == null || IdKhamBenh == "" || IdKhamBenh == "0") return;
            string IsAll = Request.QueryString["IsAll"];
            DataTable dtCLS = loadDV(IdKhamBenh, IsAll);
            if (dtCLS != null)
            {
                dtCLS.TableName = "dtSubCLS";
                crystalReport.OpenSubreport("rptSubReportCLS.rpt").SetDataSource(dtCLS);
            }
        }
        #endregion

        #region main Report toathuoc
        DataTable dtsrc = dtSource();
        if (dtsrc == null || dtsrc.Rows.Count == 0) return;
        DataTable dtCD = loadChanDonPhoihop();
        if (dtsrc.Rows.Count == 0 && dtsrc == null)
        {
            return;
        }
        dtsrc.TableName = "SP_rpintoathuoc;1";
        DataSet ds = new DataSet();
        ds.Tables.Add(dtsrc);
        #endregion

        #region TieuDeCty
        string sqlSelectCompanyInfor = "SELECT  top 1 * from TieuDeCty";
        DataTable dtCompanyInfor = DataAcess.Connect.GetTable(sqlSelectCompanyInfor);
        dtCompanyInfor.TableName = "command";
        ds.Tables.Add(dtCompanyInfor);
        #endregion

        #region ma vach
        string mabenhnhan = dtsrc.Rows[0]["mabenhnhan"].ToString();
        iTextSharp.text.pdf.Barcode128 barcode = new iTextSharp.text.pdf.Barcode128();
        barcode.ChecksumText = false;
        barcode.Code = mabenhnhan;
        DataTable dtmavach = new DataTable();
        bool dkPK = (StaticData.GetParameter("sysBarcode") == "1");
        if (dkPK == true)
        {

            DataRow R = dtmavach.NewRow();
            System.Drawing.Image bmp = barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
            Byte[] arrByte = (Byte[])System.ComponentModel.TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
            dtmavach.Columns.Add("mavach", arrByte.GetType());
            R["mavach"] = arrByte;
            dtmavach.Rows.Add(R);
        }
        dtmavach.TableName = "command_1";
        ds.Tables.Add(dtmavach);
        #endregion

        DataTable dtChuyenKhoa = DataAcess.Connect.GetTable("SELECT TENDICHVU FROM KHAMBENH A LEFT JOIN BANGGIADICHVU B ON A.DichVuKCBID=b.idbanggiadichvu");
        string ChuyenKhoa = "";
        if (dtChuyenKhoa != null && dtChuyenKhoa.Rows.Count > 0)
            ChuyenKhoa = dtChuyenKhoa.Rows[0][0].ToString();

        DataTable dt = loadChanDonPhoihop();
        crystalReport.SetDataSource(ds);
        crystalReport.SetParameterValue("TenCty", dtCompanyInfor.Rows[0]["Ten_Cty"].ToString());
        crystalReport.SetParameterValue("DiaChi", dtCompanyInfor.Rows[0]["DiaChi"].ToString());
        crystalReport.SetParameterValue("DienThoai", dtCompanyInfor.Rows[0]["DienThoai"].ToString());
        crystalReport.SetParameterValue("Email", dtCompanyInfor.Rows[0]["Email"].ToString());
        crystalReport.SetParameterValue("Website", dtCompanyInfor.Rows[0]["Website"].ToString());
        crystalReport.SetParameterValue("Fax", dtCompanyInfor.Rows[0]["Fax"].ToString());
        crystalReport.SetParameterValue("phong", ChuyenKhoa);
        crystalReport.SetParameterValue("dcphCount", dt != null ? dt.Rows.Count : 0);
        crystalReport.SetParameterValue("isShowCLS", isHaveCLSToaThuocBH ? "1" : "0");
        crystalReport.SetParameterValue("isToaBH", isToaBH);

        string NgayTaiKham = "Khi hết thuốc";
        if (StaticData.GetParameter("HienThiMacDinhKhiHetThuocTrongToa") == "0")
        {
            NgayTaiKham = dtsrc.Rows[0]["ngaytaikham"].ToString();
            if (NgayTaiKham != "")
                NgayTaiKham = string.Format("{0:dd/MM/yyyy}", NgayTaiKham);
        }
        crystalReport.SetParameterValue("NgayTaiKham", NgayTaiKham);
        string ghichu = dtsrc.Rows[0]["ghichu2"].ToString();
        crystalReport.SetParameterValue("ghichu", ghichu);
        if (dtsrc != null && dtsrc.Rows.Count > 0)
        {
            if (StaticData.LoaiToaThuoc == "1")
            {
                ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtNoiDungTK"]).Text = dtsrc.Rows[0]["noidungtaikham"].ToString();
            }
        }

        if (StaticData.LoaiToaThuoc == "3")
        {
            crystalReport.SetParameterValue("txtNgayDo", "   " + string.Format("{0:dd}", dtsrc.Rows[0]["ngaydo"]) + "        " + string.Format("{0:MM}", dtsrc.Rows[0]["ngaydo"]) + "         " + string.Format("{0:yyyy}", dtsrc.Rows[0]["ngaydo"]) + "");
            crystalReport.SetParameterValue("txtDanDo", dtsrc.Rows[0]["dando"].ToString());
            crystalReport.SetParameterValue("txtHuyetAp1", dtsrc.Rows[0]["huyetap1"].ToString());
            crystalReport.SetParameterValue("txtHuyetAp2", dtsrc.Rows[0]["huyetap2"].ToString());
            crystalReport.SetParameterValue("txtNhipTim", dtsrc.Rows[0]["mach"].ToString());
            crystalReport.SetParameterValue("txtCanNang", dtsrc.Rows[0]["cannang"].ToString());
        }
        else
        {
            crystalReport.SetParameterValue("txtDanDo", dtsrc.Rows[0]["dando"].ToString());
            crystalReport.SetParameterValue("txtHuyetAp1", dtsrc.Rows[0]["huyetap1"].ToString());
            crystalReport.SetParameterValue("txtHuyetAp2", dtsrc.Rows[0]["huyetap2"].ToString());
            crystalReport.SetParameterValue("txtNhipTim", dtsrc.Rows[0]["mach"].ToString());
            crystalReport.SetParameterValue("txtCanNang", dtsrc.Rows[0]["cannang"].ToString());

        }

        crystalReport.SetParameterValue("txtCDPhoiHop", dtCD.Rows[0]["mota"].ToString());

        #region nvk set parameter
        nvk_SetPara_HanhChinh(dtsrc.Rows[0]["idbenhnhan"].ToString(), dtsrc.Rows[0]["idchitietdangkykham"].ToString());
        #endregion
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
    }

    private DataTable dtSource()
    {
        DataAcess.Connect.ExecSQL("update chitietbenhnhantoathuoc set tenNgayDung=N'Ngày dùng' where TenNgayDung='undefined'");
        string sql = @" SELECT    khambenh.idchitietdangkykham,sinhhieu.ngaydo,khambenh.idbenhnhan,khambenh.dando,sinhhieu.huyetap1,sinhhieu.huyetap2,sinhhieu.mach,sinhhieu.cannang,
                                 benhnhantoathuoc.idbenhnhantoathuoc,
                                  benhnhantoathuoc.idbacsi, ngayratoa =  bhyt.sobhyt,
                                  benhnhantoathuoc.matoathuoc,
                                  tenbacsi = bacsi.tenbacsi, chitietbenhnhantoathuoc.ngayuong,
                                 ( CASE WHEN ISNULL(isngay,0) =0 AND ISNULL(istuan,0)=0 THEN N'Ngày ' else  ( case when IsNgay=1 then N'Ngày ' else N'Tuần ' end )   End )  as mabacsi,
                                 diachi = chitietbenhnhantoathuoc.moilanuong ,donvidung = (dvt2.TenDVT + ' . '),
                                 tenthuoc= thuoc.tenthuoc, ketluan=(case when isnull(thuoc.congthuc,'')<>'' then ('('+ thuoc.congthuc + ')') else '' end), 
                                 lower( CACHDUNG.TenCachDung) as duongdung,benhnhan.dienthoai as sobhyt,donvitinh = DVT1.TenDVT,
                                  benhnhan.mabenhnhan, tenbenhnhan=upper(benhnhan.tenbenhnhan),
                                 gioitinh=( case benhnhan.gioitinh when 0 then 'Nam' else N'Nữ' end ),  
                                  benhnhan.DiaChi as dienthoai,DBO.GetNamSinh( benhnhan.ngaysinh) as ngaysinh, bhyt.sobhyt ,
                                  bhyt.ngayhethan,chandoanbandau=replace( cd.mota  + IsNull(','+cd1.Mota,'') +IsNull(','+ cd2.Mota,''),',undefined','') , 
                                   khambenh.ketluan,khambenh.noidungtaikham,
                                 ghichu=  DBO.KB_GetGhiChuToaThuoc2(chitietbenhnhantoathuoc.Idchitietbenhnhantoathuoc),
                                  chitietbenhnhantoathuoc.soluongke, chitietbenhnhantoathuoc.soluongbanra, dando,
                                  convert(nvarchar, ngayhentaikham, 103) as ngaytaikham 
                                  ,khambenh.ghichu as ghichu2
                                 FROM       chitietbenhnhantoathuoc 
                                     LEFT JOIN   benhnhantoathuoc ON chitietbenhnhantoathuoc.idbenhnhantoathuoc = benhnhantoathuoc.idbenhnhantoathuoc 
                                 LEFT JOIN  thuoc ON chitietbenhnhantoathuoc.idthuoc = thuoc.idthuoc
                                 LEFT JOIN   khambenh ON chitietbenhnhantoathuoc.idkhambenh = khambenh.idkhambenh 
                                  LEFT JOIN  benhnhan ON khambenh.idbenhnhan = benhnhan.idbenhnhan 
                                 LEFT JOIN   bacsi ON  ( CASE WHEN ISNULL(KHAMBENH.IDBACSI2,0)<>0  AND  ISNULL(IsBSMoiKham,0)=0  THEN KHAMBENH.IDBACSI2 ELSE     KHAMBENH.idbacsi END ) = bacsi.idbacsi 
                                  left join ChanDoanICD cd on khambenh.ketluan=cd.idicd 
                                 left join ChanDoanICD cd1 on khambenh.ketluan1=cd1.idicd
                                  LEFT JOIN sinhhieu ON sinhhieu.idkhambenh=khambenh.idkhambenh 
                                 left join ChanDoanICD cd2 on khambenh.ketluan2=cd2.idicd 
                                 left join Thuoc_DonViTinh dvt1 ON  ISNULL( CHITIETBENHNHANTOATHUOC.IDDVT,THUOC.IDDVT)=DVT1.ID 
                                 left join Thuoc_DonViTinh dvt2 ON  ISNULL(CHITIETBENHNHANTOATHUOC.IDDVDUNG,THUOC.IDDVT)=DVT2.ID 
                                 left join Thuoc_CACHDUNG CACHDUNG ON ISNULL(CHITIETBENHNHANTOATHUOC.IDCACHDUNG,THUOC.IDCACHDUNG)=CACHDUNG.IDCACHDUNG 
                                 left join dangkykham dkk on khambenh.iddangkykham=dkk.iddangkykham
                                left join benhnhan_bhyt bhyt on dkk.idbenhnhan_bh=bhyt.idbenhnhan_bh
                                 WHERE  ISNULL( thuoc.loaithuocid,1)=1 and khambenh.idkhambenh=" + Request.QueryString["idkhambenh"].ToString();

        //string IsAll = Request.QueryString["IsAll"];
        //if (!StaticData.IsCheck(IsAll))
        //{
        // sql += " AND ( isnull(khambenh.idkhoa,khambenh.idphongkhambenh)<>1 or  dbo.THUOC_ISDAXUAT_TOA(idchitietbenhnhantoathuoc)=0 )";
        //}
        string IsBHYT = Request.QueryString["IsBHYT"];
        string IsDV = Request.QueryString["IsDV"];
        if (IsBHYT == "1")
            sql += " and ( dkk.LOAIKHAMID=1 AND  thuoc.sudungchobh=1  AND ISNULL(chitietbenhnhantoathuoc.ISBHYT_SAVE,0)=1  AND chitietbenhnhantoathuoc .IDKHO=5 )";
        if (IsDV == "1")
            sql += " and ( dkk.LOAIKHAMID<>1 OR   isnull(thuoc.sudungchobh,0)=0  OR ISNULL(chitietbenhnhantoathuoc.ISBHYT_SAVE,0)=0  OR ISNULL( chitietbenhnhantoathuoc.IDKHO ,0)<>5) ";
        sql += @"
        order by chitietbenhnhantoathuoc.idchitietbenhnhantoathuoc";
        DataTable dtSRC = DataAcess.Connect.GetTable(sql);
        return dtSRC;
    }
    private DataTable loadChanDonPhoihop()
    {
        string sql = string.Format(@"select stuff(a, len(a),1,'') mota
                                        from (select 
                                        (select isnull(icd.mota+',','')
                                        from chandoanphoihop ph
                                        left join chandoanicd icd on ph.idicd=icd.idicd
                                        left join benhnhantoathuoc tt on ph.idkhambenh=tt.idkhambenh
                                        where tt.idbenhnhantoathuoc={0} for xml path('')) as a) as abc", IdBenhNhanToaThuoc);
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null) dt.TableName = "dtChanDoanPhoiHop";
        return dt;
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    protected void form_unload(object sender, EventArgs e)
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
        this.Unload += new EventHandler(form_unload);
    }
    #endregion

    private void nvk_SetPara_HanhChinh(string idbenhnhan, string idctdkk)
    {
        string IsBHYT = Request.QueryString["IsBHYT"];
        string IsDV = Request.QueryString["IsDV"];

        string idkhambenh = Request.QueryString["IdKhamBenh"].ToString();
        DataTable dt_hanhChinh = StaticData_HS.nvk_thongTimBaohiemBy_idkhambenh(idkhambenh);
        string nvk_TenBenNhan = "";
        string nvk_MaBenhNhan = "";
        string nvk_NgaySinh = "";
        string nvk_GioiTinh = "";
        string nvk_DiaChi = "";
        string nvk_SoDienThoai = "";
        string nvk_ThoiHanthe = "";
        string nvk_noiDkKcbBd = "";
        string nvk_noigioithieu = "";
        string nvk_chandoan = "";
        string nvk_strMaChanDoan = "";
        string nvk_bh1 = "";
        string nvk_bh2 = "";
        string nvk_bh3 = "";
        string nvk_bh4 = "";
        string nvk_bh5 = "";
        string nvk_bh6 = "";
        if (dt_hanhChinh != null && dt_hanhChinh.Rows.Count > 0)
        {
            IsBHYT = "1";
            nvk_TenBenNhan = dt_hanhChinh.Rows[0]["tenbenhnhan"].ToString();
            nvk_MaBenhNhan = dt_hanhChinh.Rows[0]["mabenhnhan"].ToString();
            nvk_NgaySinh = dt_hanhChinh.Rows[0]["ngaysinh"].ToString();
            nvk_GioiTinh = dt_hanhChinh.Rows[0]["tengioitinh"].ToString();
            nvk_DiaChi = dt_hanhChinh.Rows[0]["diachi"].ToString();
            nvk_SoDienThoai = dt_hanhChinh.Rows[0]["dienthoai"].ToString();
            nvk_ThoiHanthe = (IsBHYT == "1" ? dt_hanhChinh.Rows[0]["thoihanthe"].ToString() : "");
            nvk_noiDkKcbBd = (IsBHYT == "1" ? dt_hanhChinh.Rows[0]["noidangkykcb"].ToString() : "");
            nvk_noigioithieu = (IsBHYT == "1" ? dt_hanhChinh.Rows[0]["noigioithieu"].ToString() : "");
            if (Request.QueryString["IsToaRV"] == null || Request.QueryString["IsToaRV"].ToString() != "")
                StaticData_HS.nvk_setTongHopChanDoan_ByIdKhamBenh(idkhambenh, ref nvk_strMaChanDoan, ref nvk_chandoan);
            string SoBhyt_Bn = (IsBHYT == "1" ? dt_hanhChinh.Rows[0]["sobhyt"].ToString() : ""); ;
            if (SoBhyt_Bn.Length > 10)
            {
                if (IsBHYT == "1" && (string.IsNullOrEmpty(IsDV) || IsDV.Equals("0")))
                {
                    nvk_bh1 = SoBhyt_Bn.Substring(0, 2);
                    nvk_bh2 = SoBhyt_Bn.Substring(2, 1);
                    nvk_bh3 = SoBhyt_Bn.Substring(3, 2);
                    nvk_bh4 = SoBhyt_Bn.Substring(5, 2);
                    nvk_bh5 = SoBhyt_Bn.Substring(7, 3);
                    nvk_bh6 = SoBhyt_Bn.Substring(10, 5);
                }
                else
                {
                    nvk_ThoiHanthe = "";
                    nvk_noiDkKcbBd = "";
                }
            }
        }
        try { crystalReport.SetParameterValue("txtTenBN", nvk_TenBenNhan); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("txtNgaySinh", nvk_NgaySinh); }
        catch (Exception) { }
        try { crystalReport.SetParameterValue("txtGioiTinh", nvk_GioiTinh); }
        catch (Exception) { }
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
        try { crystalReport.SetParameterValue("@nvk_noiGioiThieu", nvk_noigioithieu); }
        catch (Exception) { }

        #region chẩn đoán ra viện từ StaticData_HS
        if (Request.QueryString["IsToaRV"] != null && Request.QueryString["IsToaRV"].ToString() == "1")
        {
            string chanDoanRV_hs = "";
            System.Collections.Generic.List<string> list_Ma = null;
            System.Collections.Generic.List<string> list_MoTa = null;
            string ma_cd = null;
            string moTa_cd = null;
            string idbenhbhdongtien = DataAcess.Connect.GetTable(@"select isnull(
                    (select top 1 dk.IDBENHBHDONGTIEN from benhnhanxuatkhoa xk left join chandoanicd cd on cd.idicd= xk.chandoanxuatkhoa
	                    LEFT JOIN CHITIETDANGKYKHAM CTDK ON XK.IDCHITIETDANGKYKHAM=CTDK.IDCHITIETDANGKYKHAM
	                    LEFT JOIN DANGKYKHAM DK ON CTDK.IDDANGKYKHAM=DK.IDDANGKYKHAM
	                    WHERE xk.IdChiTietDangKyKham='" + idctdkk + @"'
                    ),0)").Rows[0][0].ToString();
            StaticData_HS.nvk_setTongHopChanDoan(idbenhbhdongtien, true, ref ma_cd, ref moTa_cd, ref list_Ma, ref list_MoTa);
            for (int i = 0; i < list_Ma.Count; i++)
            {
                chanDoanRV_hs += list_MoTa[i] + " (" + list_Ma[i] + "); ";
            }
            try { crystalReport.SetParameterValue("@nvk_strChanDoan", chanDoanRV_hs); }
            catch (Exception) { }
            try { crystalReport.SetParameterValue("@nvk_strMaChanDoan", ""); }
            catch (Exception) { }
        }
        else
        {



            try { crystalReport.SetParameterValue("@nvk_strChanDoan", nvk_chandoan); }
            catch (Exception) { }
            try { crystalReport.SetParameterValue("@nvk_strMaChanDoan", nvk_strMaChanDoan); }
            catch (Exception) { }
        }
        #endregion
    }
}




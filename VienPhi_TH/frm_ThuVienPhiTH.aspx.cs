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
using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Generic;

public partial class frm_ThuVienPhiTH : MKVPage
{
    private string dkMenu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetValueEmpty();
            BindListBenhNhan();
            StaticData.SetFocus(this, "txtMaBenhNhan");
        }
        dkMenu = Request.QueryString["dkMenu"];
        if (dkMenu != null && dkMenu != "")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/" + dkMenu + "/uscmenu.ascx"));
        }
    }

    #region "U Function"
    private void BindListBenhNhan()
    {
        string HaveVienPhiNoiTru = Request.QueryString["HaveVPNT"];
        string IsViewAll = StaticData.GetParaValueDB("IsViewAll_MoneyBH");
        string NgayThuPhi = StaticData.CheckDate(this.txtNgayBD.Text)+" 23:59:59";
        string strSQL = @" SELECT ROW_NUMBER() OVER (ORDER BY ISNULL(TENBENHNHAN,TENKHACHHANG),LoaiThu) STT
                                ,TB.*
                                ,MABENHNHAN
                                ,TENBENHNHAN=ISNULL(TENBENHNHAN,TENKHACHHANG)
                                ,DIACHI
                                ,gioitinh=dbo.getgioitinh(B.gioitinh)
                                ,NgaySinh=B.NgaySinh
                                ,Khoa=TB.Khoa
                                ,HuongDieuTri=TB.HuongDieuTri
                                ,IdChiTietDangKyKham=TB.IdChiTietDangKyKham
                                ,B.IdBenhNhan
                                ,IdBenhNhanBHDongTien=TB.IdBenhNhanBHDongTien
                                
                                
                                FROM (
   
	                                (
                                        SELECT DISTINCT MAPHIEUCLS=CONVERT(NVARCHAR(20),A.IDDANGKYKHAM),B1.IDBENHNHAN
		                                   ,SUM(A.BNTongPhaiTra -ISNULL(A.BNTra,0)) AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Phí khám'
		                                   ,LoaiThu='PhiKham'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
	                                       ,LoaiBN=(CASE WHEN B1.LOAIKHAMID=1 THEN N'BH' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='PhiKham_'+CONVERT(NVARCHAR(20),A.IDDANGKYKHAM)
                                           ,LoaiThu2='PhiKham'
                                           ,KHOA=DBO.HB_KHOADANGKY(A.IDDANGKYKHAM)
                                           ,HuongDieuTri=NULL
                                           ,IdChiTietDangKyKham=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM CHITIETDANGKYKHAM A
                                    LEFT JOIN DANGKYKHAM B1 ON A.IDDANGKYKHAM=B1.IDDANGKYKHAM
                                    LEFT JOIN BENHNHAN B ON B1.IDBENHNHAN=B.IDBENHNHAN
	                                WHERE	 
                                            ISNULL(A.isNotThuPhiCapCuu,0)=0
			                                AND ISNULL(A.DAHUY,0)=0
                                            AND ISNULL(A.IsDaThu,0)=0
			                                AND YEAR(NGAYDANGKY)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYDANGKY)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYDANGKY)=DAY('" + NgayThuPhi + @"')
			                                AND A.BNTongPhaiTra -ISNULL(A.BNTra,0)>0
	                                GROUP BY A.IDDANGKYKHAM,B1.IDBENHNHAN,B1.LOAIKHAMID
                                )"
        +(HaveVienPhiNoiTru == "1" ?@"
                                UNION
                                (SELECT DISTINCT MAPHIEUCLS=CONVERT(NVARCHAR(20),A.ID),A.IDBENHNHAN
		                                   ,A.BNPhaiTraChenhLechBHYT AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Đồng chi trả'
		                                   ,LoaiThu='ChenhLechBHYT'
                                           ,TONGTIENBHYT=A.TongTienBH
                                           ,BHTRA
                                           ,BNPHAITRA
                                           ,BNDaTraChenhLechBHYT
                                           ,LoaiBN=(CASE WHEN A.ISBHYT=1 THEN N'BH'+'(' +A.DungTuyen +')' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='ChenhLechBHYT_'+CONVERT(NVARCHAR(20),A.ID)
                                           ,LoaiThu2='ChenhLechBHYT'
                                           ,KHOA=DBO.HB_KHOADANGKY2(A.IDKHAMBENH_LAST)
                                           ,HuongDieuTri=A.HuongDieuTri
                                           ,IdChiTietDangKyKham=A.IdChiTietDangKyKham_Last
                                           ,IdBenhNhanBHDongTien=A.ID
	                                FROM HS_BenhNhanBHDongTien A
	                                WHERE	A.ISBHYT=1 
                                            AND ISNULL(A.ISNOITRU,0)=0
			                                AND YEAR(NgayTinhBH)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NgayTinhBH)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NgayTinhBH)=DAY('" + NgayThuPhi + @"')
			                                AND ISNULL(BNPhaiTraChenhLechBHYT,0)>0"
                                          +(IsViewAll!="1"? " AND A.IsView=1" : "")
                                + @"
                                )"
                                :"")
                    +@"
                                UNION
	                                (SELECT DISTINCT MAPHIEUCLS,A.IDBENHNHAN
		                                   ,SUM((CASE WHEN A.ISBHYT=1 THEN ISNULL(A.PHUTHUBH,0) ELSE  A.THANHTIENDV  END ))   AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Dịch vụ CLS'
                                           ,LoaiThu='DichVuCLS'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
                                           ,LoaiBN=(CASE WHEN G.LOAIKHAMID=1 THEN N'BH' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='DichVuCLS_'+MAPHIEUCLS
                                           ,LoaiThu2='DichVuCLS'
                                           ,KHOA=F.TENPHONGKHAMBENH
                                           ,HuongDieuTri=N'Chờ KQCLS'
                                           ,IDCHITIETDANGKYKHAM=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM KHAMBENHCANLAMSAN A
                                    LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                    LEFT JOIN BANGGIADICHVU C ON A.IDCANLAMSAN=C.IDBANGGIADICHVU
                                    LEFT JOIN PHONGKHAMBENH D ON C.IDPHONGKHAMBENH=D.IDPHONGKHAMBENH
                                    LEFT JOIN KHAMBENH E ON A.IDKHAMBENH=E.IDKHAMBENH
                                    LEFT JOIN PHONGKHAMBENH F ON ISNULL(E.IDKHOA,E.IDPHONGKHAMBENH)=F.IDPHONGKHAMBENH
                                    LEFT JOIN DANGKYKHAM G ON E.IDDANGKYKHAM=G.IDDANGKYKHAM
                                    LEFT JOIN HS_BENHNHANBHDONGTIEN H ON G.IdBenhBHDongTien=H.ID
	                                WHERE	ISNULL(A.IDKHAMBENH,0)<>0
			                                AND  ISNULL(A.DAHUY,0)=0
			                                AND ISNULL(A.DATHU,0)=0
			                                AND YEAR(NGAYTHU)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYTHU)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYTHU)=DAY('" + NgayThuPhi + @"')
			                                AND (CASE WHEN A.ISBHYT=1 THEN ISNULL(A.PHUTHUBH,0) ELSE  A.THANHTIENDV  END )>0
                                            AND ISNULL(C.IsCLS,0)=1
                                        
	                                GROUP BY MAPHIEUCLS,A.IDBENHNHAN,g.LOAIKHAMID,F.TENPHONGKHAMBENH,ISNULL(E.IDKHAMBENH,0)
                                )
                                 UNION
	                                (SELECT DISTINCT MAPHIEUCLS,A.IDBENHNHAN
		                                   ,SUM((CASE WHEN A.ISBHYT=1 THEN ISNULL(A.PHUTHUBH,0) ELSE  A.THANHTIENDV  END ))   AS TONGTIEN
		                                   ,NOIDUNGTHU=N'DVKT Khác'
                                           ,LoaiThu='DVKTKHAC'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
                                           ,LoaiBN=(CASE WHEN G.LOAIKHAMID=1 THEN N'BH' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='DVKTKHAC_'+MAPHIEUCLS
                                           ,LoaiThu2='DVKTKHAC'
                                           ,KHOA=F.TENPHONGKHAMBENH
                                           ,HuongDieuTri=N'Chờ KQCLS'
                                           ,IDCHITIETDANGKYKHAM=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM KHAMBENHCANLAMSAN A
                                    LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                    LEFT JOIN BANGGIADICHVU C ON A.IDCANLAMSAN=C.IDBANGGIADICHVU
                                    LEFT JOIN PHONGKHAMBENH D ON C.IDPHONGKHAMBENH=D.IDPHONGKHAMBENH
                                    LEFT JOIN KHAMBENH E ON A.IDKHAMBENH=E.IDKHAMBENH
                                    LEFT JOIN PHONGKHAMBENH F ON ISNULL(E.IDKHOA,E.IDPHONGKHAMBENH)=F.IDPHONGKHAMBENH
                                    LEFT JOIN DANGKYKHAM G ON E.IDDANGKYKHAM=G.IDDANGKYKHAM
                                    LEFT JOIN HS_BENHNHANBHDONGTIEN H ON G.IdBenhBHDongTien=H.ID
	                                WHERE	ISNULL(A.IDKHAMBENH,0)<>0
			                                AND  ISNULL(A.DAHUY,0)=0
			                                AND ISNULL(A.DATHU,0)=0
			                                AND YEAR(NGAYTHU)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYTHU)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYTHU)=DAY('" + NgayThuPhi + @"')
			                                AND (CASE WHEN A.ISBHYT=1 THEN ISNULL(A.PHUTHUBH,0) ELSE  A.THANHTIENDV  END )>0
                                            AND ISNULL(C.ISDVKT,0)=1
                                          --  AND ( F.IDPHONGKHAMBENH=1 OR F.IDPHONGKHAMBENH=15 OR (ISNULL(H.IsNoiTru,0)=0 AND F.IDPHONGKHAMBENH<>22 ))
                                        
	                                GROUP BY MAPHIEUCLS,A.IDBENHNHAN,g.LOAIKHAMID,F.TENPHONGKHAMBENH,ISNULL(E.IDKHAMBENH,0)
                                )
                                UNION
	                                (SELECT DISTINCT MAPHIEUCLS,A.IDBENHNHAN
		                                   ,SUM(A.THANHTIENDV)   AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Dịch vụ CLS Tự ĐK'
                                           ,LoaiThu='DichVuCLSTUDEN'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
                                           ,LoaiBN='DV'
                                           ,TENKHACHHANG=NULL
                                           ,Id='DichVuCLSTUDEN_'+MAPHIEUCLS
                                           ,LoaiThu2='DichVuCLSTUDEN'
                                           ,KHOA=F.TENPHONGKHAMBENH
                                           ,HuongDieuTri=N'Tự ĐKCLS'
                                           ,IDCHITIETDANGKYKHAM=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM KHAMBENHCANLAMSAN A
                                    LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                    LEFT JOIN BANGGIADICHVU C ON A.IDCANLAMSAN=C.IDBANGGIADICHVU
                                    LEFT JOIN PHONGKHAMBENH F ON A.idkhoadangky=F.IDPHONGKHAMBENH
	                                WHERE	
			                                ISNULL(A.IDKHAMBENH,0)=0 
                                            AND  ISNULL(A.DAHUY,0)=0
			                                AND ISNULL(A.DATHU,0)=0
			                                AND YEAR(NGAYTHU)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYTHU)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYTHU)=DAY('" + NgayThuPhi + @"')
			                                AND   A.THANHTIENDV >0
                                            AND ISNULL(C.IsCLS,0)=1
                                        
	                                GROUP BY MAPHIEUCLS,A.IDBENHNHAN,F.TENPHONGKHAMBENH
                                )
                                UNION
	                                (SELECT DISTINCT MAPHIEUCLS,A.IDBENHNHAN
		                                   ,SUM(A.THANHTIENDV)   AS TONGTIEN
		                                   ,NOIDUNGTHU=N'DVKT Tự ĐK'
                                           ,LoaiThu='DVKTKHACTUDEN'
                                           ,TONGTIENBHYT=NULL
                                           ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
                                           ,LoaiBN='DV'
                                           ,TENKHACHHANG=NULL
                                           ,Id='DVKTKHACTUDEN_'+MAPHIEUCLS
                                           ,LoaiThu2='DVKTKHACTUDEN'
                                           ,KHOA=F.TENPHONGKHAMBENH
                                           ,HuongDieuTri=N'Tự ĐKCLS'
                                           ,IDCHITIETDANGKYKHAM=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM KHAMBENHCANLAMSAN A
                                    LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                                    LEFT JOIN BANGGIADICHVU C ON A.IDCANLAMSAN=C.IDBANGGIADICHVU
                                    LEFT JOIN PHONGKHAMBENH F ON A.idkhoadangky=F.IDPHONGKHAMBENH
	                                WHERE	
			                                ISNULL(A.IDKHAMBENH,0)=0 
                                            AND  ISNULL(A.DAHUY,0)=0
			                                AND ISNULL(A.DATHU,0)=0
			                                AND YEAR(NGAYTHU)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYTHU)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYTHU)=DAY('" + NgayThuPhi + @"')
			                                AND   A.THANHTIENDV >0
                                            AND ISNULL(C.ISDVKT,0)=1
                                        
	                                GROUP BY MAPHIEUCLS,A.IDBENHNHAN,F.TENPHONGKHAMBENH
                                )

                                ------ TIỀN THUỐC DỊCH VỤ Ở ĐÂY, TUỲ KHÁCH HÀNG MÀ CÓ THỂ THÊM VÀO
                            "
                       + (StaticData.GetParameter("IsThuTienThuocInDSThuPhi") == "1" ? @"
                                UNION 
	                                (SELECT DISTINCT MAPHIEUCLS=CONVERT(NVARCHAR,A.IDPHIEUXUAT) ,B.IDBENHNHAN
		                                   ,SUM(A.THANHTIEN) AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Thuốc dịch vụ'
		                                   ,LoaiThu='ThuocDV'
                                           ,TONGTIENBHYT=NULL
                                            ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
	                                       ,LoaiBN=(CASE WHEN D.LOAI=1 THEN N'BH' ELSE 'DV' END )
                                           ,TENKHACHHANG=C.TENKHACHHANG
                                           ,Id='ThuocDV_'+CONVERT(NVARCHAR,A.IDPHIEUXUAT)
                                           ,LoaiThu2='ThuocDV'
                                           ,IDKHOA=NULL
                                           ,HuongDieuTri=NULL
                                           ,IDCHITIETDANGKYKHAM=NULL
                                           ,IdBenhNhanBHDongTien=NULL
	                                FROM   CHITIETPHIEUXUATKHO  A
                                    LEFT JOIN PHIEUXUATKHO B ON A.IDPHIEUXUAT=B.IDPHIEUXUAT
                                    LEFT JOIN KHACHHANG C ON B.IDKHACHHANG=C.IDKHACHHANG
                                    LEFT JOIN BENHNHAN D ON C.IDBENHNHAN=D.IDBENHNHAN
	                                WHERE	ISNULL(A.IsDaHuy,0)=0
			                                AND ISNULL(A.ISBNDaTra,0)=0
			                                AND YEAR(NGAYTHANG)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(NGAYTHANG)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(NGAYTHANG)=DAY('" + NgayThuPhi + @"')
			                               -- AND ISNULL(A.THANHTIEN,0)>0
                                            AND B.ISBHYT=0
	                                GROUP BY A.IDPHIEUXUAT,C.IDBENHNHAN,D.LOAI,C.TENKHACHHANG
                                  )"
                               : "")
                               + @"
                           UNION (
                                     SELECT DISTINCT MAPHIEUCLS=convert(varchar,A.IDTAMUNG),d.IDBENHNHAN,
		                                   TONGTIEN=a.sotien
		                                   ,NOIDUNGTHU=N'Tạm ứng'
		                                   ,LoaiThu='TamUng'
                                           ,TONGTIENBHYT=NULL
                                            ,BHTRA=NULL
                                           ,BNPHAITRA=NULL
                                           ,BNDaTraChenhLechBHYT=NULL
	                                       ,LoaiBN=(CASE WHEN d.LOAI=1 THEN N'BH' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='TamUng_'+convert(varchar,A.IDTAMUNG)
                                           ,LoaiThu2='TamUng'
                                           ,KHOA=TENPHONGKHAMBENH
                                           ,HuongDieuTri=DBO.HS_LAST_STATUS(A.IDDANGKYKHAM,A.idkhoaTU)
                                           ,IDCHITIETDANGKYKHAM=A.IDDANGKYKHAM
                                           ,IdBenhNhanBHDongTien=C.IdBenhBHDongTien
	                                FROM tamung A
									left join chitietdangkykham b on a.iddangkykham =b.idchitietdangkykham
									left join dangkykham c on c.iddangkykham=b.iddangkykham
                                    LEFT JOIN BENHNHAN d ON c.IDBENHNHAN=d.IDBENHNHAN
                                    LEFT JOIN PHONGKHAMBENH E ON A.idkhoaTU=E.IDPHONGKHAMBENH
	                                WHERE	ISNULL(A.isDATHU,0)=0
			                                AND YEAR(a.ngaytamung)=YEAR('" + NgayThuPhi + @"')
			                                AND MONTH(a.ngaytamung)=MONTH('" + NgayThuPhi + @"')
			                                AND DAY(a.ngaytamung)=DAY('" + NgayThuPhi + @"')
                                  )"
        +(HaveVienPhiNoiTru == "1" ? @"
                                UNION
                                (SELECT DISTINCT MAPHIEUCLS=CONVERT(NVARCHAR(20),A.ID),A.IDBENHNHAN
		                                   ,ABS(A.TongTienBNPTConLai) AS TONGTIEN
		                                   ,NOIDUNGTHU=N'Thanh toán ra viện'+(case when A.TongTienBNPTConLai<0 then N'(hoàn trả)' else '' end)
		                                   ,LoaiThu='VIENPHINOITRU'
                                           ,TONGTIENBHYT=A.TongTienBH
                                           ,BHTRA
                                           ,BNPHAITRA
                                           ,BNDaTraChenhLechBHYT
                                           ,LoaiBN=(CASE WHEN A.ISBHYT=1 THEN N'BH'+'(' +A.DungTuyen +')' ELSE 'DV' END )
                                           ,TENKHACHHANG=NULL
                                           ,Id='VIENPHINOITRU_'+CONVERT(NVARCHAR(20),A.ID)
                                           ,LoaiThu2='VIENPHINOITRU'
                                           ,KHOA=DBO.HB_KHOADANGKY2(A.IDKHAMBENH_LAST)
                                           ,HuongDieuTri=A.HuongDieuTri
                                           ,A.IDCHITIETDANGKYKHAM_Last
                                           ,IdBenhNhanBHDongTien=A.ID
	                                FROM HS_BenhNhanBHDongTien A
	                                WHERE	1=1 
                                          AND  ISNULL(A.ISNOITRU,0)=1
                                           --  AND ( ISNULL(A.ISNOITRU,0)=1 OR A.ISCAPCUU =1)
			                                AND NgayTinhBH<='" + NgayThuPhi + @"'
			                                AND ISNULL(TongTienBNPTConLai,0)<>0"
                                + @"
                                )"
                                :"")
          +@"
                                ) AS TB
                                LEFT JOIN BENHNHAN B ON TB.IDBENHNHAN=B.IDBENHNHAN 
                                WHERE 1=1";
        if (this.txtMaBenhNhan.Text != "")
            strSQL += " AND B.MABENHNHAN LIKE '%" + this.txtMaBenhNhan.Text + @"%'";
        if (this.txtTenBenhNhan.Text != "")
            strSQL += " AND B.TenBenhNhan LIKE N'%" + this.txtTenBenhNhan.Text + @"%'";

        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dtCTPhieu.DefaultView.RowFilter = "1=1";

        string IsDCT = Request.QueryString["IsDCT"];
        if (IsDCT == "1")
        {
            dtCTPhieu.DefaultView.RowFilter += " AND LoaiThu='ChenhLechBHYT'";
        }

        string IsBNDV = Request.QueryString["IsBNDV"];
        if (IsBNDV == "1")
        {
            dtCTPhieu.DefaultView.RowFilter += " AND LoaiBN='DV'";
        }
        string IsBNBH = Request.QueryString["IsBNBH"];
        if (IsBNBH == "1")
        {
            dtCTPhieu.DefaultView.RowFilter += " AND LoaiBN<>'DV'";
        }

        string IsPhiKham = Request.QueryString["IsPhiKham"];
        if (IsPhiKham == "1")
        {
            dtCTPhieu.DefaultView.RowFilter += " AND LoaiThu='PhiKham'";
        }

        if (HaveVienPhiNoiTru == "1")
        {
            dtCTPhieu.DefaultView.RowFilter += " AND LoaiThu='VIENPHINOITRU'";
        }
      


        dtCTPhieu = dtCTPhieu.DefaultView.ToTable();



        DataTable dt = dtCTPhieu.Copy();


        dgr.DataSource = dt;
        dgr.DataBind();
        try
        {
            if (Request.QueryString["IsBNDV"] == "1")
            {
                dgr.Columns[9].Visible = false;
                dgr.Columns[10].Visible = false;
                dgr.Columns[11].Visible = false;
                dgr.Columns[12].Visible = false;
                dgr.Columns[13].Visible = false;
                dgr.Columns[19].Visible = false;
            }
            if (HaveVienPhiNoiTru != "1")
            {
                dgr.Columns[17].Visible = false;
                dgr.Columns[18].Visible = false;
                
            }
        }
        catch (Exception)
        {

        }

    }
    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtNgayBD.Text = DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyyy");
    }
    #endregion
    #region "Grid Event"

    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string ID = dgr.DataKeys[e.Item.ItemIndex].ToString();
        string newID = ID;
        if (newID.IndexOf(";") != -1)
        {
            string[] arrID = ID.Split(';');
            newID = arrID[0];
        }

        string[] s = newID.Split('_');
        string MaPhieuCLS = s[1];
        string LoaiThu = s[0];
        if (newID != ID)
            LoaiThu = "PTDVDCT";
        TextBox txtLoaiThu2 = (TextBox)this.dgr.Items[e.Item.ItemIndex].FindControl("txtILoaiThu2");
        string NOIDUNGTHU =  System.Web.HttpUtility.UrlEncode(this.dgr.Items[e.Item.ItemIndex].Cells[7].Text);
        string LoaiThu2 = txtLoaiThu2.Text;
        TextBox IdBenhNhanBHDongTienTXT = (TextBox)this.dgr.Items[e.Item.ItemIndex].FindControl("txtIdBenhNhanBHDongTien");
        
        #region Trường hợp In đồng chi trả
        if (e.CommandName == "DONGCHITRAVIEW")
        {
            this.OpenLink("../VIENPHI_BH/frm_rpt_DongChiTra.aspx?ID=" + IdBenhNhanBHDongTienTXT.Text);
            return;
        }
        #endregion
        #region Trường hợp View phiếu thu
        if (e.CommandName != "DebitView" && e.CommandName!="BV02View")
        {
            string PrevView = "0";
            if (e.CommandName == "PrevView")
                PrevView = "1";
            string MaPhieu = "00000";
            if (PrevView != "1")
            {
                while (true)
                {
                    MaPhieu = this.MaPhieu_new;
                    string sqlSelectAgain = "SELECT TOP 1 IDBENHNHAN FROM HS_DSDATHU WHERE MAPHIEU='" + MaPhieu + "'";
                    DataTable dtSearchAgain = DataAcess.Connect.GetTable(sqlSelectAgain);
                    if (dtSearchAgain == null) return;
                    if (dtSearchAgain.Rows.Count == 0) break;
                }
                 
            }
            this.OpenLink("frm_rpt_InPhieuThuTH.aspx?ID=" + ID + "&LoaiThu2=" + LoaiThu2 + "&MaPhieuCLS=" + MaPhieuCLS + "&LoaiThu=" + LoaiThu + "&MaPhieu=" + MaPhieu + "&NOIDUNGTHU=" + NOIDUNGTHU + "&PrevView=" + PrevView + "&InTrucTiep=1");

            if (LoaiThu == "ChenhLechBHYT" && StaticData.GetParaValueDB("InMau01SauKhiTT") == "1")
            {
                this.OpenLink("frm_rpt_chiphikhambenh.aspx?idphieutt=" + MaPhieuCLS);
            }
            if (PrevView != "1")
                this.dgr.Items[e.Item.ItemIndex].Visible = false;
        }
        #endregion
        #region Trường hợp xem công nợ
        else
        {
            TextBox txtIdChiTietDangKyKham = (TextBox)this.dgr.Items[e.Item.ItemIndex].FindControl("txtIdChiTietDangKyKham");
            string IdChiTietDangKyKham = txtIdChiTietDangKyKham.Text;
            TextBox txtIdBenhNhan = (TextBox)this.dgr.Items[e.Item.ItemIndex].FindControl("txtIdBenhNhan");
            string IdBenhNhan = txtIdBenhNhan.Text;
            TextBox txtIdBenhNhanBHDongTien = (TextBox)this.dgr.Items[e.Item.ItemIndex].FindControl("txtIdBenhNhanBHDongTien");
            string IdBenhNhanBHDongTien = txtIdBenhNhanBHDongTien.Text;


            if (IdChiTietDangKyKham != null && IdChiTietDangKyKham != "")
            {
                if (e.CommandName == "DebitView")
                {
                    this.OpenLink("../noitru_BaoCao/nvk_ChiTietCongNoBenhNhan.aspx?dkmenu=VienPhi_TH&idbenhnhan=" + IdBenhNhan + "&idctdkk=" + IdChiTietDangKyKham);
                }
                else
                    if (e.CommandName == "BV02View")
                    {
                        this.OpenLink("../noitru/frm_Rpt_BieuMau02.aspx?idchitietdangkykham=" + IdChiTietDangKyKham);
                    }
            }
        }
        #endregion
    }
    #endregion
    #region Make New MaPhieu
    private string MaPhieu_tepm = null;
    private string MaPhieu_new
    {
        get
        {
            if (this.MaPhieu_tepm == null)
            {
                this.MaPhieu_tepm = StaticData.MaPhieu_new();



            }
            return this.MaPhieu_tepm;
        }
    }
    #endregion
    private void OpenLink(string LinkName)
    {
        ScriptManager.RegisterStartupScript(Page, Page. GetType(), "script", "window.open (\"" + LinkName + "\",'_blank');", true);
    }

    protected void btnLayDS_Click(object sender, EventArgs e)
    {
        BindListBenhNhan();
    }
}

public class hsClass_PhieuThuTH
{
    public string IdBenhNhan;
    public string LoaiThu;
    public hsClass_PhieuThuTH(string idbenhnhan, string loaithu)
    {
        this.IdBenhNhan = idbenhnhan;
        this.LoaiThu = loaithu;
    }
    public static int IndexOfPhieuThu(ref  List<hsClass_PhieuThuTH> lstC, string idbenhnhan,string loaithu,ref  bool OK)
    {
        OK = false;
        if (lstC == null)
        {
            lstC = new List<hsClass_PhieuThuTH>();
            lstC.Add(new hsClass_PhieuThuTH(idbenhnhan, loaithu));
            return 0;
        }
        bool temp = false;
        int i = 0;
        while (i < lstC.Count && !temp)
        {
            if (lstC[i].IdBenhNhan == idbenhnhan)
                temp = true;
            else i++;
        }
        if (!temp)
        {
            lstC.Add(new hsClass_PhieuThuTH(idbenhnhan, loaithu));
            return lstC.Count - 1;
        }
        else
        {
            OK = true;
            return i;
        }
        return -1;
    }
}
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BienBangKiemNhap
/// </summary>
public class BaoCaoKhamBenh : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IdKhoa = "1";
    public DataTable dtOther = null;
    public BaoCaoKhamBenh()
    {
    }
    public BaoCaoKhamBenh(string TuNgay, string DenNgay, string Khoa)
    {
        this.FromDate = StaticData.CheckDate(TuNgay);  
        this.ToDate =StaticData.CheckDate( DenNgay);
        this.IdKhoa = Khoa;
    }

    public override DataTable getViewTable() // bắt buộc
    {

        string sqlOther = @"
                            SELECT PHONG=ISNULL(A.IDPHONG,A.PHONGID) ,
                             TENPHONG,
                             TONGCONG=COUNT(IDKHAMBENH)
                            FROM KHAMBENH A
                            LEFT JOIN KB_PHONG B ON ISNULL(A.IDPHONG,A.PHONGID)=B.ID
                            WHERE  (IDKHOA="+IdKhoa+@" OR IDPHONGKHAMBENH="+IdKhoa+@")
		                            AND HUONGDIEUTRI<>1
		                            AND ISNULL(ISKHONGKHAM,0)=0
		                            AND NGAYKHAM>='"+this.FromDate+@"'
		                            AND NGAYKHAM<='"+this.ToDate+@" 23:59:59'
                            GROUP BY ISNULL(A.IDPHONG,A.PHONGID),TENPHONG

                            select NOISOITMH= count( distinct maphieucls )
                            from khambenhcanlamsan a
                            left join banggiadichvu b on a.idcanlamsan=b.idbanggiadichvu
                            left join khambenh c on a.idkhambenh=c.idkhambenh
                            where b.tendichvu in (      N'Nội soi tai, mũi, họng',
							                            N'Nội soi tai',
							                            N'Nội soi mũi',
							                            N'Nội soi họng'
					                             )
                             and isnull(dahuy,0)=0
                             and A.dathu=1
                             and ngaythu>='"+this.FromDate+@"'
                             and ngaythu<='"+this.ToDate+@" 23:59:59'
                             and (case when isnull(a.idkhambenh,0)=0 then idkhoadangky else isnull(c.idkhoa,c.idphongkhambenh) end )=1  

                            select TONGCLS= count( distinct maphieucls )
                            from khambenhcanlamsan a
                            where isnull(dahuy,0)=0
                             and ngaythu>='"+this.FromDate+@"'
                             and ngaythu<='"+this.ToDate+ @" 23:59:59' 
                            and isnull(idkhambenh,0)=0
                             and isnull(a.idkhoadangky,1)=" + IdKhoa + @"
                             and dathu=1
                             AND ISNULL(a.IsDaDKK,0)=0
                             
                            SELECT   NHAPVIEN=COUNT(IDKHAMBENH)
                            FROM KHAMBENH A
                            WHERE       IDKHOA=1
		                            AND HUONGDIEUTRI=8
		                            AND ISNULL(ISKHONGKHAM,0)=0
		                            AND NGAYKHAM>='" + this.FromDate+@"'
		                            AND NGAYKHAM<='"+this.ToDate+@" 23:59:59'
		                            AND  IdkhoaChuyen<>15
                             
                            SELECT   CHUYENVIEN=COUNT(IDKHAMBENH)
                            FROM KHAMBENH A
                            WHERE  (IDKHOA="+IdKhoa+@" OR IDPHONGKHAMBENH="+IdKhoa+@")
		                            AND HUONGDIEUTRI=4
		                            AND NGAYKHAM>='"+this.FromDate+@"'
		                            AND NGAYKHAM<='"+this.ToDate+@" 23:59:59'
                             ";
        DataSet ds = DataAcess.Connect.GetDataSet(sqlOther);
        if (ds == null) return null;
        DataTable dtKhamBenh = ds.Tables[0];
        DataTable dtNoiSoi = ds.Tables[1];
        DataTable dtTongCongCLS = ds.Tables[2];
        DataTable dtNhapVien = ds.Tables[3];
        DataTable dtChuyenVien = ds.Tables[4];

        string TONGCONG1 = dtKhamBenh.Compute("sum(TONGCONG)", "").ToString();
        DataView dv = new DataView(dtKhamBenh);
        dv.RowFilter = @"   Phong=7 
                             OR  Phong=      8
                             OR  Phong=       9
                             OR  Phong=       10
                             OR  Phong=       79
                             OR  Phong=       80
                             OR  Phong=       81
                             OR  Phong=       82
                             OR  Phong=       159
                             OR  Phong=       160";
        string BenhNoi = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();

      

        dv.RowFilter = "Phong=7 or Phong=8";
        string TongQuat1 = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();

        dv.RowFilter = "Phong=79 or Phong=80";
        string TongQuat2 = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();


        dv.RowFilter = "Phong=9 or Phong=10";
        string TimMach = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();

        dv.RowFilter = "Phong=159 or Phong=160";
        string TieuHoaViemGan = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();

        dv.RowFilter = "Phong=3 or Phong=4";
        string KhamNgoai = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();

        dv.RowFilter = "Phong=11 or Phong=12";
        string KhamNhi = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();

        dv.RowFilter = "Phong=19 or Phong=20";
        string KhamMat = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();

        dv.RowFilter = "Phong=17 or Phong=18";
        string TaiMuiHong = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();


        dv.RowFilter = "Phong=35 or Phong=36";
        string CTCH = dv.ToTable().Compute("sum(TONGCONG)", "").ToString();



        string NoiSoi = dtNoiSoi.Rows[0][0].ToString();
        string TongCongCLS = dtTongCongCLS.Rows[0][0].ToString();
        string NhapVien = dtNhapVien.Rows[0][0].ToString();
        string ChuyenVien = dtChuyenVien.Rows[0][0].ToString();
        string TongCong2 = TONGCONG1;


        dtOther = new DataTable();

        dtOther.Columns.Add("NgayThangNam");
        dtOther.Columns.Add("TONGCONG1");
        dtOther.Columns.Add("BENHNOI");
        dtOther.Columns.Add("TONGQUAT1");
        dtOther.Columns.Add("TONGQUAT2");
        dtOther.Columns.Add("TIMMACH");
        dtOther.Columns.Add("TIEUHOAVIEMGAN");
        dtOther.Columns.Add("KHAMNGOAI");
        dtOther.Columns.Add("KHAMNHI");
        dtOther.Columns.Add("KHAMMAT");
        dtOther.Columns.Add("TAIMUIHONG");
        dtOther.Columns.Add("NOISOITMH");
        dtOther.Columns.Add("CTCH");

        dtOther.Columns.Add("TONGCLS");
        dtOther.Columns.Add("NHAPVIEN");
        dtOther.Columns.Add("CHUYENVIEN");
        dtOther.Columns.Add("TONGCONG2");

        DataRow R = dtOther.NewRow();

        R["NgayThangNam"] = StaticData.TimeDescription(this.FromDate, this.ToDate);
        R["TONGCONG1"] = (TONGCONG1!=""? TONGCONG1 :"0") ;
        R["BENHNOI"] = (BenhNoi!="" ? BenhNoi:"0");
        R["TONGQUAT1"] = (TongQuat1 != "" ? TongQuat1 : "0");
        R["TONGQUAT2"] = (TongQuat2 != "" ? TongQuat2 : "0");
        R["TIMMACH"] = (TimMach != "" ? TimMach : "0");
        R["TIEUHOAVIEMGAN"] = (TieuHoaViemGan != "" ? TieuHoaViemGan : "0");
        R["KHAMNGOAI"] = (KhamNgoai != "" ? KhamNgoai : "0");
        R["KHAMNHI"] = (KhamNhi != "" ? KhamNhi : "0");
        R["KHAMMAT"] = (KhamMat != "" ? KhamMat : "0");
        R["TAIMUIHONG"] = (TaiMuiHong != "" ? TaiMuiHong : "0");
        R["NOISOITMH"] = (NoiSoi != "" ? NoiSoi : "0");
        R["CTCH"] = (CTCH != "" ? CTCH : "0");

        R["TONGCLS"] = (TongCongCLS != "" ? TongCongCLS : "0");
        R["NHAPVIEN"] = (NhapVien != "" ? NhapVien : "0");
        R["CHUYENVIEN"] = (ChuyenVien != "" ? ChuyenVien : "0");
        R["TONGCONG2"] = (TongCong2 != "" ? TongCong2 : "0");
        dtOther.Rows.Add(R);
        this.CurrentLanguage = 1;
        DataTable dtList = new DataTable();
        dtList.Columns.Add("STT");
        dtList.Rows.Add(dtList.NewRow());
        return dtList;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("B33");
    }
    
    protected override string SetInputFileName()
    {
        return "BAOCAOKHAMBENH.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BAOCAOKHAMBENH.xls";
    }
   
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        if (this.dtOther == null || this.dtOther.Rows.Count == 0) return null;
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A2"));// ngay thang nam
        lst.Add(GetCellIndex("D3")); // tong cong 1
        lst.Add(GetCellIndex("E3")); // BENH NOI  , TONG CONG CUA :  TONG QUAT 1, 2 + TIM MACH + TIEU HOA VIEM GAN
        lst.Add(GetCellIndex("F4")); // TONG QUAT 1
        lst.Add(GetCellIndex("F5"));// TONG QUAT 2
        lst.Add(GetCellIndex("F6")); // NOI TIM MACH
        lst.Add(GetCellIndex("F7"));//TIEU HOA-VIEM GAN
        lst.Add(GetCellIndex("F8"));//KHAM NGOAI
        lst.Add(GetCellIndex("F9"));// CTCH
        lst.Add(GetCellIndex("F10"));//KHAM NHI
        lst.Add(GetCellIndex("F11"));//KHAM MAT
        lst.Add(GetCellIndex("F12"));//KHAM TAI MUI HONG
        lst.Add(GetCellIndex("F13"));// NOI SOI TMH
        lst.Add(GetCellIndex("D15"));// TONG CONG CLS
        lst.Add(GetCellIndex("D16"));// NHAP VIEN
        lst.Add(GetCellIndex("D17"));// CHUYEN VIEN
        lst.Add(GetCellIndex("D31"));// TONG CONG 2
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        if (this.dtOther == null || this.dtOther.Rows.Count == 0) return null;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(dtOther.Rows[0]["NGAYTHANGNAM"]);// ngay thang nam
        lst.Add(dtOther.Rows[0]["TONGCONG1"]); // tong cong 1
        lst.Add("( Bệnh nội : " + dtOther.Rows[0]["BENHNOI"].ToString() +" )" ); // BENH NOI  , TONG CONG CUA :  TONG QUAT 1, 2 + TIM MACH + TIEU HOA VIEM GAN
        lst.Add(dtOther.Rows[0]["TONGQUAT1"]); // TONG QUAT 1
        lst.Add(dtOther.Rows[0]["TONGQUAT2"]);// TONG QUAT 2
        lst.Add(dtOther.Rows[0]["TIMMACH"]); // NOI TIM MACH
        lst.Add(dtOther.Rows[0]["TIEUHOAVIEMGAN"]);//TIEU HOA-VIEM GAN
        lst.Add(dtOther.Rows[0]["KHAMNGOAI"]);//KHAM NGOAI
        lst.Add(dtOther.Rows[0]["CTCH"]);// NOI SOI TMH
        lst.Add(dtOther.Rows[0]["KHAMNHI"]);//KHAM NHI
        lst.Add(dtOther.Rows[0]["KHAMMAT"]);//KHAM MAT
        lst.Add(dtOther.Rows[0]["TAIMUIHONG"]);//KHAM TAI MUI HONG
        lst.Add(dtOther.Rows[0]["NOISOITMH"]);// NOI SOI TMH
        lst.Add(dtOther.Rows[0]["TONGCLS"]);// TONG CONG CLS
        lst.Add(dtOther.Rows[0]["NHAPVIEN"]);// NHAP VIEN
        lst.Add(dtOther.Rows[0]["CHUYENVIEN"]);// CHUYEN VIEN
        lst.Add(dtOther.Rows[0]["TONGCONG2"]);// TONG CONG 2
        return lst;
    }
    
}

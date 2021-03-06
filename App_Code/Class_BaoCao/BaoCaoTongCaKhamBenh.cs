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
public class BaoCaoTongCaKhamBenh : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    public string Khoa = "0";

     
    private string SoCaCLS ;

    private string SoCaKB_ALL ;
    private string SoCaKB_BH ;
    private string SoCaKB_MP ;
    private string SoCaKB_DV;
    private string SoCaKB_NV ;
    private string SoCaKB_CV ;
    private string SoCaKB_CPKTP ;
    private string SoCaKB_CPTP;
    private string SoCaKB_MOI ;
    private string SoCaKB_TK ;
    private string SoCaKB_Huy;

    private string SoCaDKK_ALL;
    private string SoCaDKK_BH;
    private string SoCaDKK_DV;
    private string SoCaDKK_MP;


    private string SoCaTP_ALL;
    private string SoCaTP_BH;
    private string SoCaTP_DV;
    private string SoCaTP_MP;
    private string SoCaTP_Huy;

    private string SoCaDK_Huy;

    private string tu_ngaySQL="";
    private string den_ngaySQL="";


    public BaoCaoTongCaKhamBenh()
    {
    }
    public BaoCaoTongCaKhamBenh(string TuNgay, string DenNgay,  string Khoa )
    {
        this.TuNgay = TuNgay;
        this.DenNgay = DenNgay;
        this.Khoa = Khoa;
        this.tu_ngaySQL = StaticData.CheckDate(TuNgay);
        this.den_ngaySQL = StaticData.CheckDate(DenNgay);
    }

    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;

        string sqlUpdate1 = @"if(exists ( select name from sysobjects where name like 'z_KhamBenh_' and type='u'))
                            drop table z_KhamBenh_";
        bool ok1= DataAcess.Connect.ExecSQL(sqlUpdate1);

        string sqlUpdate2 = @"SELECT TENBACSI,B.idbacsi
                                ,LOAI=D.LOAIKHAMID
                                ,HUONGDIEUTRI ,IsKhongKham=ISNULL(A.IsKhongKham,0)
                                ,TaiKham=A.IsTaiKham
                                ,IsHaveCLS=A.IsHaveCLS
                                ,NhapVienKK=(CASE WHEN HUONGDIEUTRI=8 AND ( A.ISKHONGKHAM=1 OR ISNULL( IDKHOACHUYEN,0) =25 ) THEN 1 ELSE 0 END)
                                ,NhapVienCC=(CASE WHEN HUONGDIEUTRI=8 AND IDKHOACHUYEN = 15 THEN 1 ELSE 0 END)
                                ,MPK=  isNotThuPhiCapCuu
                                ,ISKHONGTINHCABS=(CASE WHEN ISNULL(A.ISKHONGTINHCABS,0)=1 THEN 1 ELSE 0 END)
                                into z_KhamBenh_
                                FROM KHAMBENH A
                                LEFT JOIN BACSI B ON ( CASE WHEN ISNULL(A.IDBACSI2,0)<>0 THEN A.IDBACSI2 ELSE  A.IDBACSI END )=B.IDBACSI
                                LEFT JOIN BENHNHAN C ON A.IDBENHNHAN=C.IDBENHNHAN
                                LEFT JOIN DANGKYKHAM D ON A.IDDANGKYKHAM=D.IDDANGKYKHAM
                                LEFT JOIN CHITIETDANGKYKHAM E ON A.IDCHITIETDANGKYKHAM=E.IDCHITIETDANGKYKHAM
                                WHERE NGAYKHAM>='" + tu_ngaySQL + "' AND NGAYKHAM<='" + den_ngaySQL + " 23:59:59'";
        if (this.Khoa != null && this.Khoa != "" && this.Khoa != "0")
            sqlUpdate2 += " AND A.IDKHOA=" + this.Khoa;
       bool ok2= DataAcess.Connect.ExecSQL(sqlUpdate2);
        string sqlSelect = @" SELECT Row_Number() OVER(order by TenBacSi)  as STT, tenbacsi 
                             ,bhyt=(select count(*) 
 				                            from z_KhamBenh_  where idbacsi=a.idbacsi    and loai=1 ) 
                             
                             ,DichVu=(select count(*) 
 				                            from z_KhamBenh_  where idbacsi=a.idbacsi     and loai=2 ) 
                             ,MienPhi=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi     and MPK=1) 
                             ,NhapVien=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi     and huongdieutri=8 and IsKhongKham=0 and NhapVienCC <>1) 
                             ,ChuyenVien=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi     and huongdieutri=4) 
                             ,CPKTP=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi     and huongdieutri=1) 
                            ,CPTP=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi     and huongdieutri=7) 
                            ,CoCDCLS=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi   AND IsHaveCLS=1  ) 
                            ,CDCLS=(select count(*) 
 		                            from z_KhamBenh_  where idbacsi=a.idbacsi     and huongdieutri=6) 
                            ,IsKhongKham=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi    and isnull(IsKhongKham,0)=1 AND HUONGDIEUTRI<>8) 
                            ,TongCaKham=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi  and huongdieutri<>1  and isnull(iskhongkham,0)<>1 and  NhapVienKK<>1  AND ISKHONGTINHCABS<>1 ) 
                            ,TaiKham=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi    and isnull(TaiKham,0)<>0 and huongdieutri<>1  and isnull(iskhongkham,0)<>1 and  NhapVienKK<>1) 
                            ,DKK=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi    and isnull(TaiKham,0)=0  and huongdieutri<>1  and isnull(iskhongkham,0)<>1 and  NhapVienKK<>1) 
                            ,NhapVienKK=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi    and isnull(NhapVienKK,0)=1 ) 
                            ,NhapVienCC=(select count(*) 
 					                            from z_KhamBenh_  where idbacsi=a.idbacsi    and isnull(NhapVienCC,0)=1 )                              
                              FROM bacsi a
                               where   idbacsi in (SELECT idbacsi from z_KhamBenh_ ) 
                            ";
        DataTable dtList = DataAcess.Connect.GetTable(sqlSelect);
        if (dtList != null)
        {

            SoCaKB_ALL = dtList.Compute("sum(TongCaKham)", "").ToString();
            SoCaKB_BH = dtList.Compute("sum(bhyt)", "").ToString();
            SoCaKB_DV = dtList.Compute("sum(DichVu)", "").ToString();
            SoCaKB_MP = dtList.Compute("sum(MienPhi)", "").ToString();
            SoCaKB_TK = dtList.Compute("sum(TaiKham)", "").ToString();
            SoCaKB_MOI = dtList.Compute("sum(DKK)", "").ToString();
            SoCaKB_CV = dtList.Compute("sum(ChuyenVien)", "").ToString();
            SoCaKB_NV = dtList.Compute("sum(NhapVien)", "").ToString();
            SoCaKB_CPKTP = dtList.Compute("sum(CPKTP)", "").ToString();
            SoCaKB_CPTP = dtList.Compute("sum(CPTP)", "").ToString();
            SoCaKB_Huy = dtList.Compute("sum(IsKhongKham)", "").ToString();
        }
        string sqlSelect2 = @"select ( case when isnull(a.dahuy,0)=0 then 1 else 0 end )  AS DKK
                                ,IsDaThu=( case when ISNULL(A.IsDaThu,0)=1 then 1 else 0 end)
                                ,IsDaHuy=( case when EXISTS(SELECT TOP 1 1 FROM HS_DSDATHU WHERE NLOAITHU=1 AND IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM AND ISDAHUY=1)  then 1 else 0 end)
                                ,IsDaHuy_DK=a.dahuy
                                ,BH=(CASE WHEN b.LOAIkhamid=1 THEN 1 ELSE 0 END)
                                ,DV=(CASE WHEN b.LOAIkhamid=2 THEN 1 ELSE 0 END)
                                ,MP=(CASE WHEN isnull(a.isNotThuPhiCapCuu,0)=1 THEN 1 ELSE 0 END)
                                ,ISHOANTRA=ISNULL(( SELECT top 1 1 FROM HS_DSDATHU WHERE NLOAITHU=1 AND  IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM AND ISHOANTRA=1),0)
                                    from chitietdangkykham a
                                    left join dangkykham b on a.iddangkykham=b.iddangkykham
                                    left join banggiadichvu c on a.idbanggiadichvu=c.idbanggiadichvu
                                    LEFT JOIN BENHNHAN E ON B.IDBENHNHAN=E.IDBENHNHAN
                                    where ngaydangky>='" + this.tu_ngaySQL+@"'
                                    and ngaydangky<='"+this.den_ngaySQL+@" 23:59:59'
                                    and a.idbanggiadichvu<>628
                                    ";
        if (this.Khoa != null && this.Khoa != "" && this.Khoa != "0")
            sqlSelect2 += " AND c.IDphongkhambenh=" + this.Khoa;
        DataTable dt2 = DataAcess.Connect.GetTable(sqlSelect2);
        if (dt2 != null && dt2.Rows.Count > 0)
        {
            SoCaDKK_ALL = dt2.Compute("sum(DKK)", "").ToString();
            SoCaDKK_BH = dt2.Compute("sum(BH)", "").ToString();
            SoCaDKK_DV = dt2.Compute("sum(DV)", "").ToString();
            SoCaDKK_MP = dt2.Compute("sum(MP)", "").ToString();


          

            DataView dv1 = new DataView(dt2);
            dv1.RowFilter = "IsDaThu=1 AND BH=1";
            SoCaTP_BH = dv1.Count.ToString();

            dv1.RowFilter = "IsDaThu=1 AND DV=1";
            SoCaTP_DV = dv1.Count.ToString();

            dv1.RowFilter = "IsDaThu=1 AND MP=1";
            SoCaTP_MP = dv1.Count.ToString();


            dv1.RowFilter = " IsDaHuy=1  or ISHOANTRA=1";
            SoCaTP_Huy = dv1.Count.ToString();

            dv1.RowFilter = "ISHOANTRA=1";
            int HoanTra = dv1.Count;


            SoCaTP_ALL = (int.Parse(dt2.Compute("sum(IsDaThu)", "").ToString()) - HoanTra).ToString();

            dv1.RowFilter = "IsDaHuy_DK=1";
            SoCaDK_Huy = dv1.Count.ToString();


        }


        string sqlSelect3 = @"select  count(distinct maphieucls) 
                                from khambenhcanlamsan a
                                where ngaythu>='"+this.tu_ngaySQL+@"'
                                and ngaythu<='"+this.den_ngaySQL+ @" 23:59:59'
                                and isnull(dahuy,0)=0
                                and dathu=1
                                and isnull(idkhambenh,0)=0
                                and isnull(a.idkhoadangky,1)="+Khoa+ @"
                               and  ISNULL(IsDaDKK,0)=0
                                    ";

        DataTable dt3 = DataAcess.Connect.GetTable(sqlSelect3);
        if (dt3 != null && dt3.Rows.Count > 0)
        {
            SoCaCLS = dt3.Rows[0][0].ToString();
        }


        return dtList;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A25");
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("bhyt");
        lst.Add("DichVu");
        lst.Add("MienPhi");
        lst.Add("NhapVien");
        lst.Add("ChuyenVien");
        lst.Add("CPKTP");
        lst.Add("CPTP");
        lst.Add("CoCDCLS");
        lst.Add("CDCLS");
        lst.Add("IsKhongKham");
        lst.Add("TongCaKham");
        return lst;
    }
    
    protected override string SetInputFileName()
    {
        return "TongKeCaKhamBenh.xls";
    }
    protected override string SetOutputFileName()
    {
        return "TongKeCaKhamBenh.xls";
    }
   
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A7"));// ngay thang nam
        lst.Add(GetCellIndex("C10")); lst.Add(GetCellIndex("D10")); lst.Add(GetCellIndex("E10")); lst.Add(GetCellIndex("F10")); lst.Add(GetCellIndex("G10"));
        lst.Add(GetCellIndex("C11")); lst.Add(GetCellIndex("D11")); lst.Add(GetCellIndex("E11")); lst.Add(GetCellIndex("F11")); lst.Add(GetCellIndex("G11"));
        lst.Add(GetCellIndex("C12")); lst.Add(GetCellIndex("D12")); lst.Add(GetCellIndex("E12")); lst.Add(GetCellIndex("F12")); lst.Add(GetCellIndex("G12"));
        lst.Add(GetCellIndex("C14"));// so ca dang ky cls
        lst.Add(GetCellIndex("C16")); // kham moi
        lst.Add(GetCellIndex("C17"));//tai kham
        lst.Add(GetCellIndex("C18"));//nhap vien
        lst.Add(GetCellIndex("C19"));//chuyen vien
        lst.Add(GetCellIndex("C20"));//chuyen phong khong thu phi
        lst.Add(GetCellIndex("C21"));//chuyen phong thu thu phi

        lst.Add(GetCellIndex("F10"));//HUY DANG KY


        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(string.Format("Báo cáo ngày {0:dd/MM/yyy}", DateTime.Today));

        lst.Add(SoCaDKK_BH);
        lst.Add(SoCaDKK_DV);
        lst.Add(SoCaDKK_MP);
        lst.Add("0");
        lst.Add(SoCaDKK_ALL);

        lst.Add(SoCaTP_BH);
        lst.Add(SoCaTP_DV);
        lst.Add(SoCaTP_MP);
        lst.Add(SoCaTP_Huy);
        lst.Add(SoCaTP_ALL);

        lst.Add(SoCaKB_BH);
        lst.Add(SoCaKB_DV);
        lst.Add(SoCaKB_MP);
        lst.Add(SoCaKB_Huy);
        lst.Add(SoCaKB_ALL);

        lst.Add(SoCaCLS);

        lst.Add(SoCaKB_MOI);
        lst.Add(SoCaKB_TK);

        lst.Add(SoCaKB_NV);
        lst.Add(SoCaKB_CV);

        lst.Add(SoCaKB_CPKTP);
        lst.Add(SoCaKB_CPTP);

        lst.Add(SoCaDK_Huy);

        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("TaiKham");
        lst.Add("DKK");
        lst.Add("NhapVienKK");
        lst.Add("NhapVienCC");
        return lst;
    }
}

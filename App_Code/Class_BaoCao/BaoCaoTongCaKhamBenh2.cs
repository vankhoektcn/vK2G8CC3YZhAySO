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
public class BaoCaoTongCaKhamBenh2 : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    public string BacSi = "0";
    public string Khoa = "0";
    public string Phong = "0";

    private string SoCaDKK;
    private string SoCaCLS ;
    private string SoCaKB ;
    private string SoCaKB_BH ;
    private string SoCaKB_MP ;
    private string SoCaKB_DV;
    private string SoCaKB_NV ;
    private string SoCaKB_CV ;
    private string SoCaKB_CP ;
    private string SoCaKB_CLS ;
    private string SoCaKB_TK ;
    private string tu_ngaySQL="";
    private string den_ngaySQL="";
    public BaoCaoTongCaKhamBenh2()
    {
    }
    public BaoCaoTongCaKhamBenh2(string TuNgay, string DenNgay, string BacSi, string Khoa, string Phong)
    {
        this.TuNgay = TuNgay;
        this.DenNgay = DenNgay;
        this.BacSi = BacSi;
        this.Khoa = Khoa;
        this.Phong = Phong;
        this.tu_ngaySQL = StaticData.CheckDate(TuNgay);
        this.den_ngaySQL = StaticData.CheckDate(DenNgay);
    }

    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;


        string sql = ""
                    + " SELECT Row_Number() OVER(order by TenBacSi)  as STT, tenbacsi " + "\r\n"
                    + " ,bhyt=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + "                 LEFT join benhnhan b1 ON a1.idbenhnhan=b1.idbenhnhan" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND  b1.loai=1" + "\r\n"
                    + " 					 AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                     + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                     + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " " + "\r\n"
                    + " ,DichVu=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + "                 LEFT join benhnhan b1 ON a1.idbenhnhan=b1.idbenhnhan" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND  b1.loai=2" + "\r\n"
                    + " 					AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa!=null &&this.Khoa!="" &&this.Khoa!="0" ? " AND A1.IDPHONGKHAMBENH="+this.Khoa +"\r\n":"")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " " + "\r\n"
                    + " " + "\r\n"
                    + " ,MienPhi=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + "                 LEFT join benhnhan b1 ON a1.idbenhnhan=b1.idbenhnhan" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND  b1.loai=3" + "\r\n"
                    + " 					AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " " + "\r\n"
                    + " ,NhapVien=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND  huongdieutri=8" + "\r\n"
                    + " 					 AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0 AND ISNULL(A1.IDKHOACHUYEN,0) IN (2,3,4)  " + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " ,ChuyenVien=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND  huongdieutri=4" + "\r\n"
                    + " 					 AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " " + "\r\n"
                    + " " + "\r\n"
                    + " ,CPKTP=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND  huongdieutri=1" + "\r\n"
                    + " 					 AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " " + "\r\n"
                    + " " + "\r\n"
                    + "    ,CoCDCLS=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND (" + "\r\n"
                    + " 							 huongdieutri=6" + "\r\n"
                    + "                              OR exists (SELECT idkhambenhcanlamsan from khambenhcanlamsan  where idkhambenh=a1.idkhambenh AND isnull (dahuy,0)=0)" + "\r\n"
                    + " 						  )" + "\r\n"
                    + " 					 AND  dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + "    ,CDCLS=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='" + den_ngaySQL + " 23:59:59'" + "\r\n"
                    + " 					 AND (" + "\r\n"
                    + " 							 huongdieutri=6" + "\r\n"
                    + " 						  )" + "\r\n"
                    + " 					 AND  dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"

                    + " ,RATOA=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND  huongdieutri IN(2,9,10)" + "\r\n"
                    + " 					 AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + "  " + "\r\n"
                    + " ,CHOVE=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND  huongdieutri IN(3)" + "\r\n"
                    + " 					 AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " " + "\r\n"
                    + " ,KHAC=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND  huongdieutri =5" + "\r\n"
                    + " 					 AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " ,TongCong=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + "                 LEFT join benhnhan b1 ON a1.idbenhnhan=b1.idbenhnhan" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					 AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " " + "\r\n"
                    + " ,TongCaKham=(select count(*) " + "\r\n"
                    + " 				from khambenh a1" + "\r\n"
                    + "                 LEFT join benhnhan b1 ON a1.idbenhnhan=b1.idbenhnhan" + "\r\n"
                    + " 				where idbacsi=a.idbacsi " + "\r\n"
                    + " 					AND ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                    + " 					 AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                    + " 					and huongdieutri<>1" + "\r\n"
                    + " 					 AND dbo.KB_IsDaHuyPK(a1.idchitietdangkykham)=0" + "\r\n"
                    + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND A1.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                    + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                    + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(a1.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                    + "            ) " + "\r\n"
                    + " " + "\r\n"
                    + " " + "\r\n"
                    + "  FROM bacsi a" + "\r\n"
                    + "   where   idbacsi in (SELECT idbacsi from khambenh "+"\r\n"
                                                +" where ngaykham>='" + tu_ngaySQL + "'"
                                                +" AND ngaykham<='"+den_ngaySQL+" 23:59:59'"
                                                + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND khambenh.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                                                + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND A1.IdBacSi=" + this.BacSi + "\r\n" : "")
                                                + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(khambenh.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                                            +" )" 
                    + "\r\n"
                    ;

        DataTable dtList = DataAcess.Connect.GetTable(sql);
        if (dtList != null)
        {
            SoCaKB = dtList.Compute("sum(TongCaKham)", "").ToString();
            SoCaKB_BH = dtList.Compute("sum(bhyt)", "").ToString();
            SoCaKB_DV = dtList.Compute("sum(DichVu)", "").ToString();
            SoCaKB_MP = dtList.Compute("sum(mienphi)", "").ToString();
            SoCaKB_CV = dtList.Compute("sum(ChuyenVien)", "").ToString();
            SoCaKB_CP = dtList.Compute("sum(CPKTP)", "").ToString();
            SoCaKB_NV = dtList.Compute("sum(NhapVien)", "").ToString();

        }
        string sqlSum = ""
                        + " SELECT socadkk=(SELECT count(*) FROM chitietdangkykham A " + "\r\n"
                        + " 					LEFT JOIN dangkykham B ON A.iddangkykham=B.iddangkykham" + "\r\n"
                        +"                      LEFT JOIN BANGGIADICHVU C ON A.IDBANGGIADICHVU=C.IDBANGGIADICHVU"
                        + " 					WHERE ISNULL(maphieudangky,'')<>''  " + "\r\n"
                        + " 					    AND	ngaydangky>='" + tu_ngaySQL + "'" + "\r\n"
                        + " 	  					AND ngaydangky<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                        + " 						AND A.idbanggiadichvu<>(SELECT ParaValue from KB_Parameter where ParaName='IdDichVu_MuaSo')" + "\r\n"
                        + " 						AND B.dathu=1" + "\r\n"
                        + " 						AND isnull( B.dahuy,0)=0" + "\r\n"
                        + " 						AND isnull( A.dahuy,0)=0" + "\r\n"
                        + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND C.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                        + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A.PHONGID=" + this.Phong + "\r\n" : "")


                        + " " + "\r\n"
                        + " " + "\r\n"
                        + " )" + "\r\n"
                        + " " + "\r\n"
                        + " ,socatucls=(select count(distinct maphieucls) " + "\r\n"
                        + " 				from khambenhcanlamsan a " + "\r\n"
                        + " 			WHERE  ISNULL(IDKHAMBENH,0)=0 AND " + "\r\n"
                        + " 			        ngaythu>='" + tu_ngaySQL + "'" + "\r\n"
                        + " 					AND ngaythu<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                        + " 					AND A.idcanlamsan<>(SELECT ParaValue from KB_Parameter where ParaName='IdDichVu_MuaSo')" + "\r\n"
                        + " 					AND a.dathu=1" + "\r\n"
                        + " 					AND isnull( a.dahuy,0)=0" + "\r\n"
                        + " AND DBO.kb_IsKhamBenh(A.IDKHAMBENHCANLAMSAN)=0" + "\r\n"
                        + " 		    )" + "\r\n"
                        + " ,socataikham=(  SELECT count(idkhambenh) " + "\r\n"
                        + " 				from khambenh " + "\r\n"
                        + " 				where   ngaykham>='" + tu_ngaySQL + "'" + "\r\n"
                        + " 					    AND ngaykham<='"+den_ngaySQL+" 23:59:59'" + "\r\n"
                        + " 						AND dbo.KB_IsDaHuyPK(idchitietdangkykham)=0" + "\r\n"
                        + "                         and dbo.KB_IsTaiKham(idkhambenh)=1" + "\r\n"
                        + (this.Khoa != null && this.Khoa != "" && this.Khoa != "0" ? " AND khambenh.IDPHONGKHAMBENH=" + this.Khoa + "\r\n" : "")
                        + (this.BacSi != null && this.BacSi != "" && this.BacSi != "0" ? " AND khambenh.IdBacSi=" + this.BacSi + "\r\n" : "")
                        + (this.Phong != null && this.Phong != "" && this.Phong != "0" ? " AND A1.dbo.kb_GetPhongID(KHAMBENH.idchitietdangkykham)=" + this.Phong + "\r\n" : "")
                        + " 			  )" + "\r\n"
                        + " " + "\r\n"
                        + " " + "\r\n"
                        + " " + "\r\n"
                        + "  " + "\r\n"
                                ;

        DataTable dtSum = DataAcess.Connect.GetTable(sqlSum);
        if (dtSum != null && dtSum.Rows.Count > 0)
        {
            SoCaDKK = dtSum.Rows[0]["socadkk"].ToString();
            SoCaCLS = dtSum.Rows[0]["socatucls"].ToString();
            SoCaKB_TK = dtSum.Rows[0]["socataikham"].ToString();

        }
        return dtList;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A5");
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
        lst.Add("CDCLS");
        lst.Add("TongCong");
        lst.Add("TongCaKham");
        return lst;
    }
    
    protected override string SetInputFileName()
    {
        return "TongKeCaKhamBenh2.xls";
    }
    protected override string SetOutputFileName()
    {
        return "TongKeCaKhamBenh2.xls";
    }
   
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A2"));
        //lst.Add(GetCellIndex("C9"));
        //lst.Add(GetCellIndex("C10"));
        //lst.Add(GetCellIndex("C11"));
        //lst.Add(GetCellIndex("C12"));
        //lst.Add(GetCellIndex("C13"));
        //lst.Add(GetCellIndex("C14"));
        //lst.Add(GetCellIndex("C15"));
        //lst.Add(GetCellIndex("C16"));
        //lst.Add(GetCellIndex("C17"));
        //lst.Add(GetCellIndex("C18"));
        //lst.Add(GetCellIndex("A20"));


        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(string.Format("Báo cáo ngày {0:dd/MM/yyy}", DateTime.Today));
        //lst.Add(SoCaDKK);
        //lst.Add(SoCaCLS);
        //lst.Add(SoCaKB);
        //lst.Add(SoCaKB_BH);
        //lst.Add(SoCaKB_DV);
        //lst.Add(SoCaKB_MP);
        //lst.Add(SoCaKB_TK);
        //lst.Add(SoCaKB_NV);
        //lst.Add(SoCaKB_CV);
        //lst.Add(SoCaKB_CP);
        //lst.Add("Danh sách tổng số ca khám bệnh " + (TuNgay == DenNgay ? (string.Format("ngày {0:dd/MM/yyyy}", TuNgay)) : (string.Format("từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TuNgay, DenNgay))));
        return lst;

    }
     
     
    
}

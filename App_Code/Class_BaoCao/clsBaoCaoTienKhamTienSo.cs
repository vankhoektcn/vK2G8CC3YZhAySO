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
public class clsBaoCaoTienKhamTienSo : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    private string tu_ngaySQL = "";
    private string den_ngaySQL = "";
    public string BacSi = "0";
    public string Khoa = "0";
    public string Phong = "0";
    public clsBaoCaoTienKhamTienSo()
    {
    }
    public clsBaoCaoTienKhamTienSo(string TuNgay, string DenNgay, string BacSi, string Khoa, string Phong)
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

        string subWhere = "";
        string mainWhere = "";

        #region Where

        if (!string.IsNullOrEmpty(tu_ngaySQL))
        {
            mainWhere += " and a.ngaydangky>='" + tu_ngaySQL + "'";         

        }
        if (!string.IsNullOrEmpty(den_ngaySQL))
        {
            mainWhere += " and a.ngaydangky<='" + den_ngaySQL + " 23:59:59'";
        }
        if (!string.IsNullOrEmpty(Khoa) && Khoa != "0"
            && !string.IsNullOrEmpty(Phong) && Phong != "0")
        {
            mainWhere += string.Format(@" and exists(select top 1 c.idchitietdangkykham
                from chitietdangkykham c
                left join banggiadichvu dv on c.idbanggiadichvu=dv.idbanggiadichvu
                where c.iddangkykham=a.iddangkykham and dv.idphongkhambenh={0}
                and c.phongid={1} )",Khoa,Phong);
            subWhere += string.Format(@" and dv.idphongkhambenh={0}
                                        and c.phongid={1}",Khoa, Phong);


        }
        else if (!string.IsNullOrEmpty(Khoa) && Khoa != "0")
        {
            mainWhere += string.Format(@" and exists(select top 1 c.idchitietdangkykham
                from chitietdangkykham c
                left join banggiadichvu dv on c.idbanggiadichvu=dv.idbanggiadichvu
                where c.iddangkykham=a.iddangkykham and dv.idphongkhambenh={0})", Khoa);
            subWhere += string.Format(@" and dv.idphongkhambenh={0}", Khoa);


        }
        else if (!string.IsNullOrEmpty(Phong) && Phong != "0")
        {
            mainWhere += string.Format(@" and exists(select top 1 c.idchitietdangkykham
                from chitietdangkykham c
                left join banggiadichvu dv on c.idbanggiadichvu=dv.idbanggiadichvu
                where c.iddangkykham=a.iddangkykham
                and c.phongid={0} )", Phong);
            subWhere += string.Format(@" and c.phongid={0}", Phong);

        }
        if (!string.IsNullOrEmpty(BacSi) && BacSi != "0")
        {
           
        }

        #endregion

        string select = string.Format(@"
               select STT=ROW_NUMBER() OVER(ORDER BY NGAY, SOPT), NGAY,SOPT,MABN,TENBN,
                stuff(NOIDUNGKCB,len(NOIDUNGKCB)-1,1,'') NOIDUNGKCB,nullif(TIENKHAM,0) TIENKHAM,
                nullif(TIENSO,0) TIENSO,nullif(tienHoanTra,0) tienHoanTra, TONGCONG=nullif(isnull(TIENKHAM,0)+isnull(TIENSO,0),0)
                from
                (
                select NGAY=ngaydangky,SOPT=maphieudangky,MABN=B.MABENHNHAN,TENBN=B.TENBENHNHAN,
                NOIDUNGKCB=
                (
		                select distinct isnull(dv.tendichvu +', ','')
		                from chitietdangkykham c
		                left join banggiadichvu dv on dv.idbanggiadichvu=c.idbanggiadichvu
		                where c.iddangkykham=a.iddangkykham
		                and c.phongid<>0 and c.phongid is not null {0}                	
		                for xml path('')
                ),
                TIENKHAM=(SELECT SUM(c.SOLUONG*c.DONGIA) 
		                FROM  CHITIETDANGKYKHAM  c 
		                left join banggiadichvu dv on c.idbanggiadichvu=dv.idbanggiadichvu
		                WHERE c.IDDANGKYKHAM=A.IDDANGKYKHAM
		                AND c.phongid<>0 and c.phongid is not null 
and isnull(c.IsHoanTraCT,0)=0 
{0}
                ),
                TIENSO=(SELECT SUM(c.SOLUONG*c.DONGIA)  
		                FROM  CHITIETDANGKYKHAM  c  
		                WHERE c.IDDANGKYKHAM=A.IDDANGKYKHAM 
		                AND (c.phongid is null or c.phongid=0) 
and isnull(c.IsHoanTraCT,0)=0
                ),
tienHoanTra=(SELECT SUM(c.SOLUONG*c.DONGIA) 
		                FROM  CHITIETDANGKYKHAM  c 
		                left join banggiadichvu dv on c.idbanggiadichvu=dv.idbanggiadichvu
		                WHERE c.IDDANGKYKHAM=A.IDDANGKYKHAM
		                AND c.phongid<>0 and c.phongid is not null 
and isnull(c.IsHoanTraCT,0)=1 
{0}
                )
                FROM DANGKYKHAM A
                LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN
                WHERE  ISNULL(A.DAHUY,0)=0 AND ISNULL(A.DATHU,0)=1 AND   ISNULL(A.maphieudangky,'')<>'' AND  1=1 {1}
                ) abc", subWhere, mainWhere);

   

        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("TIENKHAM");
        lst.Add("TIENSO");
        lst.Add("tienHoanTra");
        lst.Add("TongCong");
        return lst;
    }
    protected override string SetInputFileName()
    {
        return "BaoCaoTienKhamTienSo.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BaoCaoTienKhamTienSo.xls";
    }
    //protected override System.Collections.Generic.List<string> SetListGroupName()
    //{
    //    System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
    //    lstC.Add("NGAY");
    //    return lstC;
    //}
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A4"));
        lst.Add(GetCellIndex("G10"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        DateTime d=DateTime.Now;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add((TuNgay == DenNgay ? (string.Format("Ngày {0:dd/MM/yyyy}", TuNgay)) : (string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TuNgay, DenNgay))));
        lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("MM") + "  năm " + d.ToString("yyyy"));
        return lst;
    }
}

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
public class profess_Rpt_PhieuNhap : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IdPhieuNhap = null;
    private string NgayThangName = null;
    private string Kho = null;

    public profess_Rpt_PhieuNhap()
    {
        this.IsDeleteTotalRow = true;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        if (this.IdPhieuNhap == null || this.IdPhieuNhap == "") return null;
       

        string select = @"								
                        SELECT STT=ROW_NUMBER()OVER(ORDER BY D.TENLOAI,TENTHUOC) ,
                                TENTHUOC,
		                        TENDVT,
		                        SODK,
		                        LOSANXUAT,
		                        A.NGAYHETHAN,
		                        DONGIA= ROUND(A.DONGIA*(100.0+ISNULL(A.VAT,0))/100,0),
                                ISBHYT=(CASE WHEN A.ISBHYT=1 THEN 'a' else '' end),
		                        SOLUONG,
                                D.TENLOAI
                        FROM CHITIETPHIEUNHAPKHO A
                        LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
                        LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                        LEFT JOIN THUOC_LOAITHUOC D ON B.LOAITHUOCID=D.LOAITHUOCID
                        WHERE A.IDPHIEUNHAP=" + this.IdPhieuNhap
                             ;

        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        return "PhieuNhap.xls"; 
    }
    protected override string SetOutputFileName()
    {
        return "PhieuNhap.xls";
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A9");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A5"));
        lst.Add(GetCellIndex("F11"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        string sqlSelect0 = @"SELECT TENKHO,TENKHOA=TENPHONGKHAMBENH,NGAYTHANG
                           FROM PHIEUNHAPKHO A
                                INNER JOIN KHOTHUOC B ON A.IDKHO=B.IDKHO
                                left JOIN PHONGKHAMBENH C ON B.IDKHOA=C.IDPHONGKHAMBENH
                            WHERE A.IDPHIEUNHAP=" + this.IdPhieuNhap;
        DataTable dt0 = DataAcess.Connect.GetTable(sqlSelect0);
        if (dt0 == null || dt0.Rows.Count == 0) return null;
        this.NgayThangName = dt0.Rows[0]["ngaythang"].ToString();
        this.Kho = dt0.Rows[0]["tenkhoa"].ToString() + "-" + dt0.Rows[0]["tenkho"].ToString();


        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(this.Kho);
        DateTime ngaythang =   DateTime.Parse(this.NgayThangName);
        string s = ngaythang.ToString("HH:mm") + ",Ngày " + ngaythang.ToString("dd/MM/yyyy");
        lst.Add(s);
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("TENLOAI");
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true;
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("SOLUONG");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("TENLOAI");
        return lst;
    }
}

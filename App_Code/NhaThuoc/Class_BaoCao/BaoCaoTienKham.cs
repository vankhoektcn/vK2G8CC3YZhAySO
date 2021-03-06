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
public class BaoCaoTienKham : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        string select = ""
                + " select STT=ROW_NUMBER() OVER(ORDER BY maphieudangky) ," + "\r\n"
                + "        NGAY=ngaydangky," + "\r\n"
                + "        SOPT=maphieudangky," + "\r\n"
                + "        MABN=MABENHNHAN," + "\r\n"
                + "        TENBN=TENBENHNHAN," + "\r\n"
                + "        NOIDUNGKCB=''," + "\r\n"
                + "        TIENKHAM=(SELECT SUM(A1.SOLUONG*A1.DONGIA)  FROM  CHITIETDANGKYKHAM  A1 WHERE IDDANGKYKHAM=A.IDDANGKYKHAM AND IDBANGGIADICHVU<>628)," + "\r\n"
                + " 	   TIENSO=(SELECT SUM(A1.SOLUONG*A1.DONGIA)  FROM  CHITIETDANGKYKHAM  A1  WHERE IDDANGKYKHAM=A.IDDANGKYKHAM AND IDBANGGIADICHVU=628)," + "\r\n"
                + " 	   TongCong=(SELECT SUM(A1.SOLUONG*A1.DONGIA)  FROM  CHITIETDANGKYKHAM  A1  WHERE IDDANGKYKHAM=A.IDDANGKYKHAM )" + "\r\n"
                + "  FROM DANGKYKHAM A" + "\r\n"
                + "       LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN" + "\r\n"
                + " WHERE 1=1" + "\r\n";
            if(TuNgay!=null &&TuNgay!="")
                select += "and   ngaydangky>='"+TuNgay+"'" + "\r\n";
            if (DenNgay != null && DenNgay != "")
                select += " AND ngaydangky<='" + DenNgay + " 23:59:59'" + "\r\n";

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
        lst.Add("TongCong");
        return lst;
    }
    protected override string SetInputFileName()
    {
        return "ThuPhiKhamBenh.xls";
    }
    protected override string SetOutputFileName()
    {
        return "ThuPhiKhamBenh.xls";
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
        lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("mm") + "  năm " + d.ToString("yyyy"));
        lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("mm") + "  năm " + d.ToString("yyyy"));
        return lst;
    }
}

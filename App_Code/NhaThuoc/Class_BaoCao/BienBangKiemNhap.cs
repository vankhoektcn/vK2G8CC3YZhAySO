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
public class BienBangKiemNhap : ExportToExcel.Profess_ExportToExcelByCode
{
    public BienBangKiemNhap()
    {
        this.IsDeleteTotalRow = false;
    }
    public string idloainhap = "";
    public string IDKHO = "";
    public string LOAITHUOCID = "";
    public string TuNgay = "";
    public string DenNgay = "";
    public string TenLoaiThuoc = "";
    public override DataTable getViewTable() // bắt buộc
    {
        string sql = "";

        string select = ""
                        + "  SELECT ROW_NUMBER() OVER (ORDER BY B.NGAYTHANG) AS STT," + "\r\n"
                        + " TENTHUOC,TenDVT," + "\r\n"
                        + " SOCHUNGTU1=B.sohoadon," + "\r\n"
                        + " NGAYHD=convert(varchar(10),B.ngayhoadon,103)," + "\r\n"
                        + " SOLUONG=A.SOLUONG," + "\r\n"
                        + " DONGIA= A.DONGIA + isnull( A.VAT,0)/ 100.0 * A.DONGIA," + "\r\n"
                        + " THANHTIEN=A.SOLUONG*(A.DONGIA + isnull( A.VAT,0)/ 100.0 * A.DONGIA)," + "\r\n"
                        + " LOSANXUAT,SoDK=isnull(A.SoDK,sttindm05)," + "\r\n"
                        + " HANSUDUNG=convert(varchar(10), ISNULL(A.NGAYHETHAN,''),103)," + "\r\n"
                        + " NUOCSX=D.TenNuocSX," + "\r\n"
                        + " CTYNHAP=E.tennhacungcap" + "\r\n"
                           + " ,SOCHUNGTU=B.sohoadon" + "\r\n"
                        + " FROM CHITIETPHIEUNHAPKHO A" + "\r\n"
                        + " LEFT JOIN PHIEUNHAPKHO B ON A.IDPHIEUNHAP=B.IDPHIEUNHAP" + "\r\n"
                        + " LEFT JOIN THUOC C ON A.IDTHUOC=C.IDTHUOC" + "\r\n"
                        + " LEFT JOIN  NuocSX D ON A.IDNUOCSX_N=D.idNuocSX" + "\r\n"
                        + " LEFT JOIN NHACUNGCAP E ON B.NHACUNGCAPID=E.NHACUNGCAPID" + "\r\n"
                        + " LEFT JOIN Thuoc_DonViTinh F ON C.IdDVT=F.ID" + "\r\n"
                        + " WHERE 1=1 and b.idloainhap=1 ";

      
        if (LOAITHUOCID != "")
        {
            select += " AND C.LOAITHUOCID=" + LOAITHUOCID;
        }

        if (DenNgay != "")
        {
            DenNgay = DenNgay + " 23:59:59";
        }
        string NgaySoSanh = "NgayThang";
        if (StaticData.GetParameter("NgayKiemNhap") == "NgayHoaDon")
            NgaySoSanh = "NgayHoaDon";
        if (TuNgay != "")
            select += " AND B." + NgaySoSanh + ">='" + TuNgay + "' ";
        if (DenNgay != "")
            select += " AND B." + NgaySoSanh + "<='" + DenNgay + "'";

        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }

    protected override string SetInputFileName() // bắt buộc
    {
        return "BienBangKiemNhap.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName()
    {
        return "BienBangKiemNhap.xls";//TÊN FILE XUẤT RA
    }
    protected override string SetHeaderText()
    {
        return "BIÊN BẢN KIỂM NHẬP KHO";// TÊN REPORT
    }
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("B4");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A15");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("THANHTIEN"); //theo câu select

        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("SOCHUNGTU"); //theo câu select
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("SOCHUNGTU");
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true;
    }

    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        string s0 = null;
        string s = "BIÊN BẢN KIỂM KÊ THUÔC, VẬT TƯ Y TẾ, HÓA CHẤT";
        string s1 = "BIÊN BẢN KIỂM NHẬP ";
        s1 += TenLoaiThuoc.ToUpper();
        s0 = s1;
        if (this.LOAITHUOCID == "1")
            lst.Add("Tên thuốc, nồng độ, hàm lượng");
        else
            lst.Add("Tên " + TenLoaiThuoc);

        //lst.Add(s0);
        //string TimeDesc = StaticData.TimeDescription(this.tungay, this.denngay, true);
        //lst.Add(TimeDesc);

        return lst;
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        if (this.TenLoaiThuoc != null && this.TenLoaiThuoc != "")
        {
            lst.Add(GetCellIndex("B14"));
        }
        //lst.Add(GetCellIndex("B4"));
        //lst.Add(GetCellIndex("A5"));
        //lst.Add(GetCellIndex("D13"));
        //lst.Add(GetCellIndex("D14"));
        return lst;

    }
    protected override bool SetIsSumByGroup1Value()
    {
        return true;
    }
    protected override string Set_Total1_Name()
    {
        return "Cộng hóa đơn ";
    }
}

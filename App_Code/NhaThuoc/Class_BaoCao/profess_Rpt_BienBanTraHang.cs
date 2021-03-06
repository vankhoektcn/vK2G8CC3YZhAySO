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
public class profess_Rpt_BienBanTraHang : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IdPhieuXuat = null;
    public profess_Rpt_BienBanTraHang()
    {
    }
    public override DataTable getViewTable() // bắt buộc
    {
        string sqlSelect = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY A.IDCHITIETPHIEUXUAT),
                                    TENHANG=B.TENTHUOC,
                                    C=NULL,
                                    DVT=C.TENDVT,
                                    SOLUONG=A.SOLUONG,
                                    SOLO=null,--A.LOSANXUAT_XUAT,
                                    HANDUNG=null,--A.NGAYHETHAN_XUAT,
                                    DONGIA=ROUND(A.DONGIA*(100.0+ISNULL(A.VAT,0))/100,0),
                                    THANHTIEN=A.SOLUONG*ROUND(A.DONGIA*(100.0+ISNULL(A.VAT,0))/100,0)
                            FROM CHITIETPHIEUXUATKHO A 
	                            LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
	                            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                            WHERE A.IDPHIEUXUAT=" + IdPhieuXuat + "";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        return table;
    }
    protected override string SetInputFileName() // bắt buộc
    {

        return "BienBanTraHang.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BienBanTraHang.xls";
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("B17");
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("THANHTIEN");
        return lst;
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> _lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        _lst.Add(GetCellIndex("C7"));
        _lst.Add(GetCellIndex("D8"));
        _lst.Add(GetCellIndex("D9"));
        _lst.Add(GetCellIndex("D10"));
        _lst.Add(GetCellIndex("D11"));
        _lst.Add(GetCellIndex("D12"));
        _lst.Add(GetCellIndex("D13"));
        _lst.Add(GetCellIndex("C20"));
        return _lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {

        string ngayxuat = null;
        string tenncc = null;
        string diachincc = null;
        string masothuencc = null;
        string tencty = null;
        string diachicty = null;
        string masothuecty = null;
        string lydoxuat = null;
        string TENTINH = null;
        string sqlSelectNCC = @"
                        SELECT TOP 1 B.TENNHACUNGCAP,B.DIACHI,B.MASOTHUE,A.NGAYTHANG,A.GHICHU
                                ,TENTINH=(
                                        SELECT PARAVALUE
                                        FROM KB_PARAMETER
                                        WHERE PARANAME='TINH_VALUE'
                                )
                        FROM NHACUNGCAP B 
	                        INNER JOIN PHIEUXUATKHO A ON A.IDNHACUNGCAP=B.NHACUNGCAPID 
                        WHERE A.IDPHIEUXUAT=" + this.IdPhieuXuat + @"";
        DataTable dtNCC = DataAcess.Connect.GetTable(sqlSelectNCC);
        if (dtNCC != null && dtNCC.Rows.Count > 0)
        {
            ngayxuat = dtNCC.Rows[0]["NGAYTHANG"].ToString();
            tenncc = dtNCC.Rows[0]["TENNHACUNGCAP"].ToString();
            diachincc = dtNCC.Rows[0]["DIACHI"].ToString();
            masothuencc = dtNCC.Rows[0]["MASOTHUE"].ToString();
            lydoxuat = dtNCC.Rows[0]["GHICHU"].ToString();
            TENTINH = dtNCC.Rows[0]["TENTINH"].ToString();
        }
        string sqlTenCTY = @"
                        SELECT TOP 1 Ten_Cty,DiaChi,SoThue
                            FROM TIEUDECTY
                            ORDER BY ID_TT DESC";
        DataTable dtCTY = DataAcess.Connect.GetTable(sqlTenCTY);
        if (dtCTY != null && dtCTY.Rows.Count > 0)
        {
            tencty = dtCTY.Rows[0]["Ten_Cty"].ToString();
            diachicty = dtCTY.Rows[0]["DiaChi"].ToString();
            masothuecty = dtCTY.Rows[0]["SoThue"].ToString();
        }
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        DateTime d_ngayxuat = DateTime.Parse(ngayxuat);
        ngayxuat = TENTINH + ", " + "ngày " + d_ngayxuat.ToString("dd") + " tháng " + d_ngayxuat.ToString("MM") + " năm " + d_ngayxuat.ToString("yyyy") + " chúng tôi gồm: ";
        tenncc = tenncc.ToUpper();
        diachincc = "Địa chỉ: " + diachincc;
        masothuencc = "Mã số thuế: " + masothuencc;
        tencty = tencty.ToUpper();
        diachicty = "Địa chỉ: " + diachicty;
        masothuecty = "Mã số thuế: " + masothuecty;
        lydoxuat = "Lý do trả hàng: " + lydoxuat;
        lst.Add(ngayxuat);
        lst.Add(tenncc);
        lst.Add(diachincc);
        lst.Add(masothuencc);
        lst.Add(tencty);
        lst.Add(diachicty);
        lst.Add(masothuecty);
        lst.Add(lydoxuat);
        return lst;

    }
    protected override string Set_Total_Name()
    {
        return "Tổng cộng : " + this.dtSoucre.Rows.Count + " khoản";
    }
}

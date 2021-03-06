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
public class profess_Rpt_PhieuXuatKho : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IdPhieuXuat = null;
    public profess_Rpt_PhieuXuatKho()
    {
    }
    public override DataTable getViewTable() 
    {
        string sqlSelect = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY A.IDCHITIETPHIEUXUAT),
                                    TENHANG=B.TENTHUOC,
                                    MASO=NULL,
                                    DVT=C.TENDVT,
                                    YEUCAU=A.SOLUONG,
                                    THUCXUAT=A.SOLUONG,
                                    HANDUNG=null,--A.NGAYHETHAN_XUAT,
                                    LOSX=null,--A.LOSANXUAT_XUAT,
                                    DONGIA=ROUND(A.DONGIA*(100.0+ISNULL(A.VAT,0))/100,0),
                                    THANHTIEN=A.SOLUONG*ROUND(A.DONGIA*(100.0+ISNULL(A.VAT,0))/100,0)
                            FROM CHITIETPHIEUXUATKHO A 
	                            LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
	                            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                            WHERE A.IDPHIEUXUAT=" + IdPhieuXuat + "";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        return table;
    }
    protected override string SetInputFileName() 
    {
        return "PhieuXuatKho.xls";
    }
    protected override string SetOutputFileName()
    {
        return "PhieuXuatKho.xls";
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("B14");
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
        _lst.Add(GetCellIndex("B1"));
        _lst.Add(GetCellIndex("B2"));
        _lst.Add(GetCellIndex("D5"));
        _lst.Add(GetCellIndex("B8"));
        _lst.Add(GetCellIndex("I8"));
        _lst.Add(GetCellIndex("B9"));
        _lst.Add(GetCellIndex("B10"));
        _lst.Add(GetCellIndex("B16"));
        _lst.Add(GetCellIndex("I18"));
		_lst.Add(GetCellIndex("H4"));
        return _lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        string TENSO = null;
        string TENCTY = null;
        string TENTINH = null;
        string NGAYXUAT = null;
        string TENNCC = null;
        string LYDOXUAT = null;
        string TONGTIEN = null;
        string NGUOINHAN = null;
        string KHOXUAT = null;
		string SOPHIEU = null;
        string sqlSelectNCC = @"
                        SELECT TOP 1 B.TENNHACUNGCAP,A.NGAYTHANG,A.GHICHU
                                ,TENTINH=(
                                        SELECT PARAVALUE
                                        FROM KB_PARAMETER
                                        WHERE PARANAME='TINH_VALUE'
                                ),TENSO=(
                                     SELECT PARAVALUE
                                        FROM KB_PARAMETER
                                        WHERE PARANAME='TenSoYTe'
                                ),NGUOINHAN=A.NGUOINHAN
                                ,KHOXUAT=(SELECT TOP 1 TENKHO FROM KHOTHUOC WHERE IDKHO=A.IDKHO)
                                ,TONGTIEN=(SELECT SUM(SOLUONG*ROUND(DONGIA*(100.0+ISNULL(VAT,0))/100,0))
                                           FROM CHITIETPHIEUXUATKHO WHERE IDPHIEUXUAT=A.IDPHIEUXUAT)
								,A.MAPHIEUXUAT
                        FROM NHACUNGCAP B 
	                        INNER JOIN PHIEUXUATKHO A ON A.IDNHACUNGCAP=B.NHACUNGCAPID 
                        WHERE A.IDPHIEUXUAT=" + this.IdPhieuXuat + @"";
        DataTable dtNCC = DataAcess.Connect.GetTable(sqlSelectNCC);
        if (dtNCC != null && dtNCC.Rows.Count > 0)
        {
            NGAYXUAT = dtNCC.Rows[0]["NGAYTHANG"].ToString();
            TENNCC  = dtNCC.Rows[0]["TENNHACUNGCAP"].ToString();
            LYDOXUAT = dtNCC.Rows[0]["GHICHU"].ToString();
            TENTINH = dtNCC.Rows[0]["TENTINH"].ToString();
            TENSO = dtNCC.Rows[0]["TENSO"].ToString();
            NGUOINHAN = dtNCC.Rows[0]["NGUOINHAN"].ToString();
            KHOXUAT = dtNCC.Rows[0]["KHOXUAT"].ToString();
            TONGTIEN = dtNCC.Rows[0]["TONGTIEN"].ToString();
			SOPHIEU = dtNCC.Rows[0]["MAPHIEUXUAT"].ToString();
        }
        string sqlTenCTY = @"
                        SELECT TOP 1 TEN_CTY
                            FROM TIEUDECTY
                            ORDER BY ID_TT DESC";
        DataTable dtCTY = DataAcess.Connect.GetTable(sqlTenCTY);
        if (dtCTY != null && dtCTY.Rows.Count > 0)
        {
            TENCTY = dtCTY.Rows[0]["TEN_CTY"].ToString();
        }
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        DateTime d_ngayxuat = DateTime.Parse(NGAYXUAT);
        string ngayxuat_1 = "Ngày " + d_ngayxuat.ToString("dd") + " tháng " + d_ngayxuat.ToString("MM") + " năm " + d_ngayxuat.ToString("yyyy") + "";
        string ngayxuat_2 = TENTINH + ", " + "ngày " + d_ngayxuat.ToString("dd") + " tháng " + d_ngayxuat.ToString("MM") + " năm " + d_ngayxuat.ToString("yyyy") + "";
        TENNCC = TENNCC.ToUpper();
        NGUOINHAN = "Họ tên người nhận hàng: " + NGUOINHAN;
        LYDOXUAT = "Lý do xuất kho: " + LYDOXUAT;
        KHOXUAT = "Xuất tại kho: " + KHOXUAT;
        TONGTIEN = "Tổng tiền (viết bằng chữ): " + StaticData.ConvertMoneyToText(TONGTIEN);
        lst.Add(TENSO);
        lst.Add(TENCTY.ToUpperInvariant());
        lst.Add(ngayxuat_1);
        lst.Add(NGUOINHAN);
        lst.Add(TENNCC);
        lst.Add(LYDOXUAT);
        lst.Add(KHOXUAT);
        lst.Add(TONGTIEN);
        lst.Add(ngayxuat_2);
		lst.Add("Số: "+SOPHIEU);
        return lst;
    }
    protected override string Set_Total_Name()
    {
        return "Tổng cộng : " + this.dtSoucre.Rows.Count + " khoản";
    }
}

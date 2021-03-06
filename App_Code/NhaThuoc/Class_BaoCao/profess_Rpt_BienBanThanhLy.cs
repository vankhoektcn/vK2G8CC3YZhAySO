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
public class profess_Rpt_BienBanThanhLy : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IdPhieuXuat = null;
    public profess_Rpt_BienBanThanhLy()
    {

    }
    public override DataTable getViewTable()
    {
        string sqlSelect = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY A.IDCHITIETPHIEUXUAT),
	                            TENHANG=B.TENTHUOC,
	                            DVT=C.TENDVT,
	                            SOKIEMSOAT=A.LOSANXUAT_XUAT,
	                            NUOCSX=D.TENNUOCSX,
	                            HANDUNG=A.NGAYHETHAN_XUAT,
	                            DONGIA=ROUND(A.DONGIA*(100.0+ISNULL(A.VAT,0))/100,0),
	                            SOLUONG=A.SOLUONG,
	                            THANHTIEN=A.SOLUONG*ROUND(A.DONGIA*(100.0+ISNULL(A.VAT,0))/100,0),
	                            DEXUAT=REPLACE(A.GHICHU,',',';')
                            FROM CHITIETPHIEUXUATKHO A
	                            LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
	                            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
	                            LEFT JOIN NUOCSX D ON A.IdNuocSX_X=D.IdNuocSX
                            WHERE A.IDPHIEUXUAT=" + IdPhieuXuat + "";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        return table;
    }
    protected override string SetInputFileName()
    {
        return "BienBanThanhLy.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BienBanThanhLy.xls";
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A37");
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> _lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        _lst.Add(GetCellIndex("A1"));
        _lst.Add(GetCellIndex("A2"));
        _lst.Add(GetCellIndex("A3"));
        _lst.Add(GetCellIndex("I2"));
        _lst.Add(GetCellIndex("E6"));
        _lst.Add(GetCellIndex("B31"));
        _lst.Add(GetCellIndex("H53"));
        return _lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        string TENSO = null;
        string TENDONVI = null;
        string TENCTY = null;
        string TENTINH = null;
        string NGAYXUAT = null;
        string LYDOXUAT = null;
        string KHOXUAT = null;
        string MAPHIEUXUAT = null;
        string SQL_INFO_XUAT = @"
                        SELECT TOP 1 A.NGAYTHANG,A.GHICHU,A.SOPHIEUYC
                                ,TENTINH=(
                                        SELECT PARAVALUE
                                        FROM KB_PARAMETER
                                        WHERE PARANAME='TINH_VALUE'
                                ),TENSO=(
                                     SELECT PARAVALUE
                                        FROM KB_PARAMETER
                                        WHERE PARANAME='TenSoYTe'
                                ),TENDONVI=( SELECT PARAVALUE
                                        FROM KB_PARAMETER
                                        WHERE PARANAME='TenDonVi')
                                ,KHOXUAT=(SELECT TOP 1 TENKHO FROM KHOTHUOC WHERE IDKHO=A.IDKHO)
                        FROM PHIEUXUATKHO A  
                        WHERE A.IDPHIEUXUAT=" + this.IdPhieuXuat + @"";
        DataTable dt_INFO_XUAT = DataAcess.Connect.GetTable(SQL_INFO_XUAT);
        if (dt_INFO_XUAT != null && dt_INFO_XUAT.Rows.Count > 0)
        {
            NGAYXUAT = dt_INFO_XUAT.Rows[0]["NGAYTHANG"].ToString();
            LYDOXUAT = dt_INFO_XUAT.Rows[0]["GHICHU"].ToString();
            TENTINH = dt_INFO_XUAT.Rows[0]["TENTINH"].ToString();
            TENSO = dt_INFO_XUAT.Rows[0]["TENSO"].ToString();
            KHOXUAT = dt_INFO_XUAT.Rows[0]["KHOXUAT"].ToString();
            TENDONVI = dt_INFO_XUAT.Rows[0]["TENDONVI"].ToString();
            MAPHIEUXUAT = dt_INFO_XUAT.Rows[0]["SOPHIEUYC"].ToString();
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
        string ngayxuat_1 = "Tháng " + d_ngayxuat.ToString("MM") + " năm " + d_ngayxuat.ToString("yyyy") + "";
        string ngayxuat_2 = "Ngày " + d_ngayxuat.ToString("dd") + " tháng " + d_ngayxuat.ToString("MM") + " năm " + d_ngayxuat.ToString("yyyy") + "";
        MAPHIEUXUAT = "Số: " + MAPHIEUXUAT;
        LYDOXUAT = "'- Đã tiến hành họp xét thanh lý tại Khoa Dược từ .....giờ ...., ngày ...../...../....... đến .... giờ ...., ngày ...../...../......";
        lst.Add(TENSO);
        lst.Add(TENDONVI);
        lst.Add(KHOXUAT);
        lst.Add(MAPHIEUXUAT);
        lst.Add(ngayxuat_1);
        lst.Add(LYDOXUAT);
        lst.Add(ngayxuat_2);
        return lst;
    }
    protected override string[] SetListColumnFixValues()
    {
        string[] lst = new string[] { "DEXUAT" };
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListColumnMergeRow()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("STT");
        lst.Add("TENHANG");
        lst.Add("SOKIEMSOAT");
        lst.Add("NUOCSX");
        lst.Add("DONGIA");
        lst.Add("DEXXUAT");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("THANHTIEN");
        return lst;
    }
    protected override string Set_Total_Name()
    {
        return "Cộng khoản: " + this.dtSoucre.Rows.Count.ToString() + " khoản";
    }
}

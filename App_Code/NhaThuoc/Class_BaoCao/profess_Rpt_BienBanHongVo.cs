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
public class profess_Rpt_BienBanHongVo : ExportToExcel.Profess_ExportToExcelByCode
{
    public string idphieuxuat = null;
    public profess_Rpt_BienBanHongVo()
    {
    }
    public override DataTable getViewTable()
    {
        string sqlSelect = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY A.OUTPUTDETAILID),
	                            TENTHUOC=B.TENTHUOC,
	                            DONVI=C.TENDVT,
	                            SOKIEMSOAT=NULL,
	                            NUOCSANXUAT=D.TENNUOCSX,
	                            HANDUNG=NULL,
	                            SOLUONG=A.QUANTITY,
	                            KETLUAN=A.NOTE
                            FROM HS_OUTPUTDETAIL A
	                            LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
	                            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                                LEFT JOIN NUOCSX D ON B.IDNUOCSANXUAT=D.IDNUOCSX
                            WHERE A.IDPHIEUXUAT=" + idphieuxuat + "";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        return table;
    }
    protected override string SetInputFileName()
    {
        return "BienBanHongVo.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BienBanHongVo.xls";
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("B16");
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> _lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        _lst.Add(GetCellIndex("B1"));
        _lst.Add(GetCellIndex("B2"));
        _lst.Add(GetCellIndex("B3"));
        _lst.Add(GetCellIndex("H2"));
        _lst.Add(GetCellIndex("C4"));
        _lst.Add(GetCellIndex("G19"));
        _lst.Add(GetCellIndex("C17"));
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
                        WHERE A.IDPHIEUXUAT=" + this.idphieuxuat + @"";
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
        DateTime d_ngayXUAT = DateTime.Parse(NGAYXUAT);
        string ngayXUAT_1 = "Hồi: " + " ..... giờ " 
            + " ...... phút, ngày " 
            + d_ngayXUAT.ToString("dd") + " tháng " 
            + d_ngayXUAT.ToString("MM") + " năm " + d_ngayXUAT.ToString("yyyy");
        string ngayXUAT_2 = "Ngày "
           + d_ngayXUAT.ToString("dd") + " tháng "
           + d_ngayXUAT.ToString("MM") + " năm " + d_ngayXUAT.ToString("yyyy");
        MAPHIEUXUAT = "Số: " + MAPHIEUXUAT;
        string CONGKHOAN = "Cộng khoản: " + dtSoucre.Rows.Count  + " khoản";
        lst.Add(TENSO);
        lst.Add(TENDONVI);
        lst.Add(KHOXUAT);
        lst.Add(MAPHIEUXUAT);
        lst.Add(ngayXUAT_1);
        lst.Add(ngayXUAT_2);
        lst.Add(CONGKHOAN);
        return lst;
    }
   
}

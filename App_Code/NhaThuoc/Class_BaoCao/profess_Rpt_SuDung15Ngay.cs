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
public class profess_Rpt_SuDung15Ngay : ExportToExcel.Profess_ExportToExcelByCode
{
    public string LoaiThuocID = null;
    public bool IsOrderByName = false;
    public string IdKho = "31";
    public string TenLoaiThuoc = "";
    public string TenKho = "";
    public profess_Rpt_SuDung15Ngay()
    {
    }
    public override DataTable getViewTable() // bắt buộc
    {
        #region Select DataTable TenThuoc,DVT,NgayThang,SoLuong
        string select = @"SELECT DISTINCT  B.TENTHUOC,C.TENDVT
	                    ,NGAYXUAT=CONVERT(NVARCHAR(20),NGAYTHANG_XUAT,111)
	                    , SL=SUM(A.SOLUONG)
                     FROM CHITIETPHIEUXUATKHO A
                    LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
                    LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                    WHERE 
		                    A.IDKHO_XUAT=" + IdKho+@"
		                    AND NGAYTHANG_XUAT>='"+this.FromDate+@"'
		                    AND NGAYTHANG_XUAT<='"+this.ToDate +" 23:59:59"+@"'
		                    AND B.LOAITHUOCID="+LoaiThuocID+ @"
                    GROUP BY TENTHUOC ,CONVERT(NVARCHAR(20),NGAYTHANG_XUAT,111),C.TENDVT
                    ORDER BY TENTHUOC,CONVERT(NVARCHAR(20),NGAYTHANG_XUAT,111)";
        DataTable dt1 = DataAcess.Connect.GetTable(select);
        if (dt1 == null) return null;
        #endregion
        #region Tạo DataTable Result : Tên thuốc, DVT, các ngày  là các column
        DataTable dt = new DataTable();
        dt.Columns.Add("TENTHUOC", "TENTHUOC".GetType());
        dt.Columns.Add("TENDVT", "TENDVT".GetType());
        #endregion
        #region Thêm các Columns tương ứng với các ngày
        DateTime d1 = DateTime.Parse(FromDate);
        DateTime d2 = DateTime.Parse(ToDate);
        while (true)
        {
            dt.Columns.Add("_"+d1.ToString("yyyyMMdd")+"_");
            
            if(d1.ToString("yyyy-MM-dd")==d2.ToString("yyyy-MM-dd"))
                break;
            d1 = d1.AddDays(1);
        }
        #endregion
        #region Có thêm cột tổng cộng
        dt.Columns.Add("Total");
        #endregion
        #region Mỗi một dòng tương ứng với 1 tên thuốc
        DataView dv = new DataView(dt1);
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        for (int i = 0;i< dt1.Rows.Count; i++)
        {
            string TenThuoc = dt1.Rows[i]["TenThuoc"].ToString();
            if (lstC.IndexOf(TenThuoc) == -1)
            {
                double totalSL = 0;
                DataRow DR = dt.NewRow();
                DR["TenThuoc"] = TenThuoc;
                DR["TENDVT"] = dt1.Rows[i]["TENDVT"].ToString();
                 d1 = DateTime.Parse(FromDate);
                 d2 = DateTime.Parse(ToDate);
                while (true)
                {
                    dv.RowFilter = "TENTHUOC='" + TenThuoc + "' AND NGAYXUAT='" + d1.ToString("yyyy/MM/dd") + "'";
                    if (dv.Count > 0)
                    {
                        DR["_" + d1.ToString("yyyyMMdd") + "_"] = dv[0]["SL"].ToString();
                        if (dv[0]["SL"].ToString() != "" && dv[0]["SL"].ToString() != "0")
                            totalSL += double.Parse(dv[0]["SL"].ToString());
                    }
                    
                    if(d1.ToString("yyyy-MM-dd")==d2.ToString("yyyy-MM-dd"))
                        break;
                    d1 = d1.AddDays(1);
                }
                DR["Total"] = totalSL;
                dt.Rows.Add(DR);
                lstC.Add(TenThuoc);
            }
        }
        #endregion
        return dt;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        DateTime dToDate = DateTime.Parse(ToDate);
            if (dToDate.Day == 15)
                return "BAOCAO15NGAYSD_15.xls"; 
            if (dToDate.Day == 28)
                return "BAOCAO15NGAYSD_13.xls";
            if (dToDate.Day == 29)
                return "BAOCAO15NGAYSD_14.xls";
            if (dToDate.Day == 30)
                return "BAOCAO15NGAYSD_15.xls";
            if (dToDate.Day == 31)
                return "BAOCAO15NGAYSD_16.xls";

            return "BAOCAO15NGAYSD_15.xls"; 
    }
    protected override string SetOutputFileName()
    {
        DateTime dToDate = DateTime.Parse(ToDate);
        if (dToDate.Day == 15)
            return "BAOCAO15NGAYSD_15.xls";
        if (dToDate.Day == 28)
            return "BAOCAO15NGAYSD_13.xls";
        if (dToDate.Day == 29)
            return "BAOCAO15NGAYSD_14.xls";
        if (dToDate.Day == 30)
            return "BAOCAO15NGAYSD_15.xls";
        if (dToDate.Day == 31)
            return "BAOCAO15NGAYSD_16.xls";

        return "BAOCAO15NGAYSD_15.xls"; 
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        #region Tên column Ngày tháng
        DateTime d1 = DateTime.Parse(FromDate);
        DateTime d2 = DateTime.Parse(ToDate);
        int i=0;
        while (true)
        {
            lst.Add(new ExportToExcel.CellIndex(6, 3 + i));
            
            if(d1.ToString("yyyy-MM-dd")==d2.ToString("yyyy-MM-dd"))
                break;
            d1 = d1.AddDays(1); i++;
        }
        #endregion
        #region Column Tổng cộng
        lst.Add(new ExportToExcel.CellIndex(6, 3 + i+1));
        #endregion
        #region Tên Report
        lst.Add(GetCellIndex("A4"));
        #endregion
        #region Tên Kho
        lst.Add(GetCellIndex("A2"));
        #endregion
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        #region Giá trị tên cột ngày tháng 
        DateTime d1 = DateTime.Parse(FromDate);
        DateTime d2 = DateTime.Parse(ToDate);
        int i = 0;
        while (true)
        {
            lst.Add(d1.ToString("dd/MM"));
            
            if(d1.ToString("yyyy-MM-dd")==d2.ToString("yyyy-MM-dd"))
                break;
            d1 = d1.AddDays(1); i++;
        }
        lst.Add("Tổng cộng");
        #endregion
        #region Tên Report
        string ReportName = "BÁO CÁO SỬ DỤNG " + TenLoaiThuoc +" "+ StaticData.TimeDescription(FromDate, ToDate);
        ReportName = ReportName.ToUpper();
        lst.Add(ReportName);
        #endregion
        #region Tên Kho
        lst.Add(TenKho);
        #endregion
        return lst;
    }
}

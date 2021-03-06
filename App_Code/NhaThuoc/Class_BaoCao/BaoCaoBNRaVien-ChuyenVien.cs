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
public class BaoCaoBNRaVienChuyenVien : ExportToExcel.Profess_ExportToExcelByCode
{
    public string strSql = null;
    public string tuNgayDenNgay = null;
    public string TenKhoa = "";
    public string TongBH = "";
    public string TongDV = "";

    public BaoCaoBNRaVienChuyenVien()
    {
        //this.IsDeleteTotalRow = true;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        DataTable dt = DataAcess.Connect.GetTable(strSql);
        DataView dv = new DataView(dt.Copy());
        dv.RowFilter=" BHYT='a'";
        this.TongBH = dv.Count.ToString();
        dv.RowFilter = " DICHVU='a'";
        this.TongDV = dv.Count.ToString();
        return dt;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        return "BaoCaoBNRaVien-ChuyenVien.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BaoCaoBNRaVien-ChuyenVien.xls";
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A3"));
        lst.Add(GetCellIndex("A4"));
        lst.Add(GetCellIndex("D9"));
        lst.Add(GetCellIndex("E9"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(TenKhoa);
        lst.Add(tuNgayDenNgay);
        lst.Add(TongBH);
        lst.Add(TongDV);
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("mabenhnhan");
        lst.Add("idchitietdangkykham");
        return lst;
    }
}

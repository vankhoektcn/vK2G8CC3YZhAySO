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
public class profess_Rpt_THSDVTYT : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IDKho = null;
    public string TuNgay = null;
    public string DenNgay = null;
    public bool IsThuocGN=false;
    public bool IsThuocHTT=false;
    public string TenKho = null;
    public string TenThuoc = null;

    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;

        string select = @"SELECT row_number () OVER (order by tenthuoc) AS STT,
			                            MaThuoc='',
			                            TenThuoc,
			                            TenDVT,
			                            DonGia=0,
			                            SL_NT=dbo.Thuoc_XuatSL_2(" + this.IDKho + @",'" + this.TuNgay + @"','" + this.DenNgay + @"',a.idthuoc,a.iddvt),
			                            TT_NT=dbo.Thuoc_XuatTT_2(" + this.IDKho + @",'" + this.TuNgay + @"','" + this.DenNgay + @"',a.idthuoc,a.iddvt)/1000,
			                            SL_NgT=0,
			                            TT_NgTu=0,
			                            SL_Khac=0,
			                            TT_Khac=0,
			                            SL_Huy=0,
			                            TT_Huy=0,
			                            SL_SUM=0,
			                            TT_Sum=0
                            from Thuoc a
                            LEFT join Thuoc_DonViTinh b ON a.iddvt=b.Id
                            where  ISTHUOCBV=1 AND LOAITHUOCID=4 ";
        select += @" and a.TENTHUOC LIKE N'" + this.TenThuoc + "%'";
        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");
    }
   
    protected override string SetInputFileName()
    {
        return "BAOCAOSUDUNGVTYT.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BAOCAOSUDUNGVTYT.xls";
    }
    
    //protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    //{
    //    System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
    //    lst.Add(GetCellIndex("G14"));
    //    return lst;
    //}
    //protected override System.Collections.Generic.List<object> SetListOtherValue()
    //{
    //    System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
    //    DateTime d = d_SystemDate();
    //    lst.Add( "Ngày "+ d.ToString("dd") +" tháng "+ d.ToString("MM") +" năm "+ d.ToString("yyyy"));
    //    return lst;
    //}
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("F2");
    }
    protected override string SetHeaderText()
    {
        string s = "";
        s = StaticData.TimeDescription(this.TuNgay, this.DenNgay).ToUpper();
        return s;
    }
}

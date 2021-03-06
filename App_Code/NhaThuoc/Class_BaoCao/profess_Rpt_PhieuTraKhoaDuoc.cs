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
public class profess_Rpt_PhieuTraKhoaDuoc : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IDKho = null;
    public string IdPhieuXuat = null;
    public override DataTable getViewTable() // bắt buộc
    {
        if (this.IdPhieuXuat == null || this.IdPhieuXuat == "") return null;
        this.CurrentLanguage = 1;
        string select = @"SELECT row_number() OVER (ORDER BY A.idchitietphieuxuat) AS STT,
                            tenthuoc,
                            TenDVT,
                            sttindm05,
                            A.soluong,
                            A.dongia,
                            A.thanhtien,
                            ghichu=''
                             FROM chitietphieuxuatkho A
                            LEFT JOIN phieuxuatkho B ON A.idphieuxuat=B.idphieuxuat
                            LEFT JOIN THUOC C ON A.idthuoc=C.idthuoc
                            LEFT JOIN Thuoc_DonViTinh D ON A.dvt=D.Id
                            WHERE B.idphieuxuat="+this.IdPhieuXuat+@"
                            ";
        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");
    }
   
    protected override string SetInputFileName()
    {
        return "PHIEUTRATHUOC.xls";
    }
    protected override string SetOutputFileName()
    {
        return "PHIEUTRATHUOC.xls";
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
    //protected override ExportToExcel.CellIndex SetHeaderIndex()
    //{
    //    return GetCellIndex("F2");
    //}
    //protected override string SetHeaderText()
    //{
    //    string s = "";
    //    s = StaticData.TimeDescription(this.TuNgay, this.DenNgay).ToUpper();
    //    return s;
    //}
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("soluong");
        lst.Add("thanhtien");
        return lst;
    }
}

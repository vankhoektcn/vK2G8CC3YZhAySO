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
/// Summary description for Class1
/// </summary>
public class TheoDoiKhamBenhNoiTru:ExportToExcel.Profess_ExportToExcelByCode
{
    public string IdKho = null;
    public string MaBenhNhan = "";
    public string TenBenhNhan = "";
    public string TenKhoa = "";
    public string sqlQuery = "";

    public TheoDoiKhamBenhNoiTru()
	{
        this.IsDeleteTotalRow = true;  
	}
    public override DataTable getViewTable()
    {
        DataTable dt = DataAcess.Connect.GetTable(this.sqlQuery);
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A6");
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A1"));
        lst.Add(GetCellIndex("A2"));
        
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(TenKhoa);
        string header = "BẢNG THEO DÕI BÁC SĨ KHÁM BỆNH NGÀY " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "";
        lst.Add(header);
        return lst;

    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        return lst;
    }
    protected override string SetInputFileName()
    {
        return "DsTheoDoiKbNoiTru.xls";
        
    }
    protected override string SetOutputFileName()
    {
        return "DsTheoDoiKbNoiTru.xls";
        
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true;
    }
}

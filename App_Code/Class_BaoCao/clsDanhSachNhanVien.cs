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
public class clsDanhSachNhanVien:ExportToExcel.Profess_ExportToExcelByCode
{
    public  string search = "";
    public clsDanhSachNhanVien()
    {

    }
    public clsDanhSachNhanVien(string search)
    {
        this.search = search;
    }
    public override DataTable getViewTable() // bắt buộc
    {           
        DataTable dt = DataAcess.Connect.GetTable(search);
        return dt;
    }

    protected override string SetInputFileName() // bắt buộc
    {
        return "DanhSachNhanVien.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "DanhSachNhanVien.xls";//TÊN FILE XUẤT RA
    }
    //protected override string SetHeaderText()
    //{
    //    return "Từ ngày : " + tungay + " Đến ngày : " + denngay;// TÊN REPORT
    //}
    //protected override ExportToExcel.CellIndex SetHeaderIndex()
    //{
    //    return GetCellIndex("G3");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    //}
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A6");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("tong"); //theo câu select
        //lst.Add("cot 2");
        //lst.Add("cot 3");
        return lst;
    }
    //protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    //{
    //    System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
    //    //lst.Add("idnhanvien"); //theo câu select
    //    //lst.Add("manhanvien");
    //    return lst;
    //}
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("phongban");
        //lst.Add("cot2");
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true;
    }
     
    //protected override System.Collections.Generic.List<object> SetListOtherValue()
    //{
    //    //System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
    //    //lst.Add("giá 1"); //theo câu select
    //    //lst.Add("giá 2");
    //    //lst.Add("giá 3");// 
    //    //return lst;
    //}
    //protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    //{
    //    System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
    //    //lst.Add(GetCellIndex("D12"));
    //    //lst.Add(GetCellIndex("D13"));
    //    //lst.Add(GetCellIndex("D14"));
    //    return lst;
    //}
     
}

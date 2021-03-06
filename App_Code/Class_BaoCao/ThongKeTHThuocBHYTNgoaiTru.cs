using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for BienBangKiemNhap
/// </summary>
public class ThongKeTHThuocBHYTNgoaiTru : ExportToExcel.Profess_ExportToExcelByCode
{
    private string Chu_sumBHYT = "";
    public string IsNoiTru = "0";
    public DataTable dtGetReportSource()
    {
        return this.getViewTable();
    }
    public ThongKeTHThuocBHYTNgoaiTru()
    {
    }
    
    public  override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        string procLBN = "dbo.[func_rpt_ThongKeTHThuocBHYTNgoaiTru]";
        string sql = "select * from " + procLBN + "('" + FromDate + "','" + ToDate  + "',"+this.IsNoiTru+")";
        DataTable dtSource1 = null;
        dtSource1 = DataAcess.Connect.GetTable(sql);
        dtSource1.DefaultView.Sort = "TENTHUOC";
        dtSource1 = dtSource1.DefaultView.ToTable();
        if (dtSource1 != null)
        {
            for (int i = 0;i< dtSource1.Rows.Count; i++)
                dtSource1.Rows[i]["STT"] = i + 1;
        }
        return dtSource1;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A11");
    }
    protected override string SetInputFileName()
    {
        return "ThongKeTongHopThuocThang.xls";
    }
    protected override string SetOutputFileName()
    {
        return "ThongKeTongHopThuocThang.xls";
    }   
   
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("THANHTIEN");       
        return lst;
    }
    protected override bool SetIsSumByGroupValue()
    {
        return true;
    }

    protected override string[] SetListColumnFixValues()
    {
        string[] arr = new string[] { "GHICHU"};
        return arr;
    }

    protected override string SetHeaderText()
    {
        string s = "THỐNG KÊ TỔNG HỢP THUỐC";
        string s1 = DSDeNghiThanhToanNgoaiTru.TimeDescription(FromDate , ToDate);
        s1 = s1.ToUpper();
        s += " " + s1;
        s = s.Replace(":", "");
        return s;
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A5"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        string S = "ĐIỀU TRỊ CHO BỆNH NHÂN BHYT KCB ";
        if (this.IsNoiTru == "1")
            S += "NỘI TRÚ";
        else
            S += "NGOẠI TRÚ";
        lst.Add(S);
        return lst;

    }
 
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("A4");
    }
    protected override string Set_Total_Name()
    {
        return "TỔNG CỘNG ";
    }
    
    
}

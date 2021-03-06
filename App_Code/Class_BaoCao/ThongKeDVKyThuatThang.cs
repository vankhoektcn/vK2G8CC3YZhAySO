using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for BienBangKiemNhap
/// </summary>
public class ThongKeDVKyThuatThang : ExportToExcel.Profess_ExportToExcelByCode
{
    private string Chu_sumBHYT = "";
    public string IsNoiTru = "0";
    public DataTable dtGetReportSource()
    {
        return this.getViewTable();
    }
    public ThongKeDVKyThuatThang()
    {
        this.CurrentLanguage = 1;
    }
    

    public  override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        string procLBN = "dbo.[func_rpt_ThongKeDVKyThuatThang]";
        string sql = "select * from " + procLBN + "( '" + this.FromDate + "','" + this.ToDate + "',"+IsNoiTru+") ORDER BY xType,TenDichVu";
        DataTable dtSource1 = null;
        dtSource1 = DataAcess.Connect.GetTable(sql);
        if (dtSource1 != null)
        {
            string[] ArrTenNhom = new string[] { "Xét nghiệm", "Chẩn đoán hình ảnh, thăm dò chức năng", "Thủ thuật, phẫu thuật", "Vật tư y tế tiêu hao", "Dịch vụ kỹ thuật cao" };
            for (int ii = 0; ii < ArrTenNhom.Length; ii++)
            {
                dtSource1.DefaultView.RowFilter = "xType=" + (ii + 1).ToString();
                if (dtSource1.DefaultView.Count == 0)
                {
                    DataRow R = dtSource1.NewRow();
                    R["TENNHOM"] = ArrTenNhom[ii];
                    R["XTYPE"] = ii + 1;
                    dtSource1.Rows.Add(R);
                }
            }
            dtSource1.DefaultView.RowFilter = "";
            dtSource1.DefaultView.Sort = "xType,TenDichVu";
            dtSource1 = dtSource1.DefaultView.ToTable();
            for (int i = 0; i < dtSource1.Rows.Count; i++)
            {
                dtSource1.Rows[i][0] = i + 1;
            }
        }
        return dtSource1;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");
    }
    
    protected override string SetInputFileName()
    {
        return "ThongKeDichVuKyThuatSuDungThang.xls";
    }
    protected override string SetOutputFileName()
    {
        return "ThongKeDichVuKyThuatSuDungThang.xls";
    }   
    protected override System.Collections.Generic.List<string> SetListGroupName()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        lstC.Add("TENNHOM");
        return lstC;
    }
    
     protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        lstC.Add("TENNHOM");
        lstC.Add("XTYPE");
        return lstC;
    }

    
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        //lst.Add("SOLUONG");       
        lst.Add("THANHTIEN");       
        return lst;
    }
    protected override bool SetIsSumByGroupValue()
    {
        return true;
    }
    protected override bool SetIsSumByGroup1Value()
    {
        return true;
    }
    protected override bool Set_IsABC_Group1()
    {
        return true;
    }
    
    protected override string Set_Total1_Name()
    {
        return "CỘNG";
    }
    protected override string Set_Total_Name()
    {
        return "TỔNG CỘNG (A+B+C+D+E)"; 
    }
    protected override string SetHeaderText()
    {
        string s = "THỐNG KÊ DỊCH VỤ KỸ THUẬT SỬ DỤNG";

        string s1 = DSDeNghiThanhToanNgoaiTru.TimeDescription(FromDate, ToDate);
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
}

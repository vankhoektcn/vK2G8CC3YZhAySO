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
public class profess_Rpt_nhapxuatton:ExportToExcel.Profess_ExportToExcelByCode
{
    public string IdKho = null;
    public string LoaiThuocID = null;
    public string TenLoaiThuoc = "";
    public string TenThuoc = null;
    public bool IsOrderByName = false;
    public string IdThuoc = null;
    public string TenKho = "KHOA DƯỢC";
    public string tugio;
    public string tuphut;
    public string dengio;
    public string denphut;

    public profess_Rpt_nhapxuatton()
	{
        this.IsDeleteTotalRow = true;  
	}
    public override DataTable getViewTable()
    {
        profess_Rpt_TongHopNhapXuatTon NXTReport = new profess_Rpt_TongHopNhapXuatTon();
        if (this.FromDate == "") return null;
        if (this.ToDate == "") return null;
        if (this.IdKho == "") return null;
        if (this.LoaiThuocID == "") return null;
        NXTReport.TuNgay = DateTime.Parse(this.FromDate).ToString("dd/MM/yyyy");
        NXTReport.DenNgay = DateTime.Parse(this.ToDate).ToString("dd/MM/yyyy");
        NXTReport.IdKho = this.IdKho;
        NXTReport.LoaiThuocID = this.LoaiThuocID;
        NXTReport.TenThuoc = this.TenThuoc;
        NXTReport.IsOrderByName =  this.IsOrderByName;
        NXTReport.IsHaveDonGia = false;
        NXTReport.IsRutGon = true;
        NXTReport.TenKho = this.TenKho;
        NXTReport.IDTHUOC = this.IdThuoc;

        NXTReport.tugio = this.tugio;
        NXTReport.tuphut = this.tuphut;
        NXTReport.dengio = this.dengio;
        NXTReport.denphut = this.denphut;

        DataTable dt = NXTReport.getViewTable();
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string XUAT_SL = dt.Rows[i]["XUAT_SL"].ToString();
                string XUAT_SL2 = dt.Rows[i]["XUAT_SL2"].ToString();
                if (XUAT_SL == "") XUAT_SL = "0";
                if (XUAT_SL2 == "") XUAT_SL2 = "0";
                dt.Rows[i]["XUAT_SL"] = double.Parse(XUAT_SL) + double.Parse(XUAT_SL2);

            }
            string[] arrColumns = new string[] { "STT", "tensp", "TENDVT", "DAUKY_SL", "NHAP_SL", "XUAT_SL", "NHAP_SL2", "CUOIKY_SL", "CATENAME", "NHOMTHUOC", "IdThuoc" };
            if (IsOrderByName)
            {
                dt.Columns.Remove("CATENAME");
                dt.Columns.Remove("NHOMTHUOC");
                dt.Columns.Remove("DES");
            }
            else
            {
                dt.Columns.Remove("DES");
            }

            DataTable dt2 = dt.Copy();
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                string ColumnsName = dt2.Columns[i].ColumnName;
                if (Array.IndexOf(arrColumns, ColumnsName) == -1)
                    dt.Columns.Remove(ColumnsName);
            }
                        
        }
        dt.Columns["NHAP_SL2"].SetOrdinal(dt.Columns["XUAT_SL"].Ordinal);

        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A11");
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A4"));
        lst.Add(GetCellIndex("A6"));
        lst.Add(GetCellIndex("B8"));
        
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        string header = "BÁO CÁO XUẤT NHẬP TỒN ";
        header += TenLoaiThuoc.ToUpper();
        lst.Add(header);
        string s1 = this.FromDate;
        string s2 = this.ToDate;
        lst.Add(TenKho + " - " + StaticData.TimeDescription(s1, s2) + " (" + this.tugio + "h" + this.tuphut + "->" + this.dengio + "h" + this.denphut + ")"); ;
        string tensp="Tên "+this.TenLoaiThuoc.ToLower();
        lst.Add(tensp);
        return lst;

    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        if (!this.IsOrderByName)
        {
            lst.Add("CATENAME"); //theo câu select
            lst.Add("NHOMTHUOC"); //theo câu select
        }
        lst.Add("IdThuoc"); //theo câu select
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        if (!this.IsOrderByName)
        {
            lst.Add("CATENAME"); //theo câu select
            lst.Add("NHOMTHUOC"); //theo câu select
        }
        return lst;
    }
    protected override string SetInputFileName()
    {
        if(LoaiThuocID=="2")
            return "nhapxuatton_hc.xls";
        else
            return "nhapxuatton.xls";
        
    }
    protected override string SetOutputFileName()
    { 
            return "nhapxuatton.xls";
        
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
         if (!this.IsOrderByName)
             lst.Add("CUOIKY_SL");
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true;
    }
}

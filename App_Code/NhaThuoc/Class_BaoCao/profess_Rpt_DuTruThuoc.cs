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
public class profess_Rpt_DuTruThuoc : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IDKho = null;
    public string TuNgay = null;
    public string DenNgay = null;
    public bool IsThuocGN=true;
    public bool IsThuocHTT=false;

    public string TenKho = null;
    public string TenThuoc = null;
    public string Year = null;
    public string Month = null;



    public override DataTable getViewTable() // bắt buộc
    {
        if (this.Year != null && this.Year != "")
        {
            if (this.Month == null || this.Month == "")
            {
                int nYear = int.Parse(Year) - 1;
                this.TuNgay = nYear.ToString() + "/01/01";
                this.DenNgay = nYear.ToString() + "/12/31";
            }
            else
            {
                if (this.Month != null && this.Month != "")
                {
                    if (Month == "01"||Month=="1")
                    {
                        int nYear = int.Parse(Year) - 1;
                        this.TuNgay = nYear.ToString() + "/12/01";
                        this.DenNgay = nYear.ToString() + "/12/31";
                    }
                    else
                    {
                        int nMonth = int.Parse(Month) - 1;
                        this.TuNgay = Year.ToString() + "/" + nMonth.ToString() + "/01";
                        this.DenNgay = Year.ToString() + "/" + nMonth + "/" + DateTime.DaysInMonth(int.Parse(Year), nMonth);
                    }
                }
            }
        }

        this.CurrentLanguage = 1;
        string select ="";
        if(this.IsThuocGN)
            select = @"SELECT STT,TENTHUOC,TENDVT,DAUKY_SL,NHAP_SL,TONGNHAP=DAUKY_SL+NHAP_SL,XUAT_SL,CUOIKY_SL,SLDUTRU=XUAT_SL*2,DUYET='',GHICHU=''
                            from  dbo.Thuoc_TonKho10(" + this.IDKho + ",'" + this.TuNgay + "','" + DenNgay + " 23:59:59') T";
        else 
            if(this.IsThuocHTT)
                select = @"SELECT STT,TENTHUOC,TENDVT,DAUKY_SL,NHAP_SL,TONGNHAP=DAUKY_SL+NHAP_SL,XUAT_SL,CUOIKY_SL,SLDUTRU=XUAT_SL*2,DUYET='',GHICHU=''
                            from  dbo.Thuoc_TonKho11(" + this.IDKho + ",'" + this.TuNgay + "','" + DenNgay + " 23:59:59') T";

        if (IsThuocGN == false && IsThuocHTT == false)
        {
            select = @"SELECT STT,TENTHUOC,TENDVT,DAUKY_SL,NHAP_SL,TONGNHAP=DAUKY_SL+NHAP_SL,XUAT_SL,CUOIKY_SL,SLDUTRU=XUAT_SL*2,DUYET='',GHICHU=''
                            from  dbo.Thuoc_TonKho12(" + this.IDKho + ",'" + this.TuNgay + "','" + DenNgay + " 23:59:59') T";
        }

        if (this.TenThuoc != null && this.TenThuoc != "")
            select += " LEFT JOIN THUOC T2 ON T.IDTHUOC=T2.IDTHUOC WHERE T2.TENTHUOC LIKE N'"+this.TenThuoc+"%'";
        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A11");
    }
   
    protected override string SetInputFileName()
    {
        return "DuTruThuoc.xls";
    }
    protected override string SetOutputFileName()
    {
        return "DuTruThuoc.xls";
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
        return GetCellIndex("A5");
    }
    protected override string SetHeaderText()
    {
        string s = "DỰ TRÙ MUA ";
        if (IsThuocGN)
            s += "THUỐC GÂY NGHIỆN";
        else 
            if(this.IsThuocHTT)
                s += "THUỐC HƯỚNG TÂM THẦN";

        if (this.IsThuocGN == false && this.IsThuocHTT == false)
            s += " THUỐC ";

        string sYear = "Năm " + this.Year;
        if (this.Month != null && this.Month != "")
            sYear = "THÁNG " +this.Month +"/"+ this.Year;
        return s +sYear;
    }
}

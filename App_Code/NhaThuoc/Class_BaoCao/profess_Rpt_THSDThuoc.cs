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
public class profess_Rpt_THSDThuoc : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IDKho = null;
    public string TuNgay = null;
    public string DenNgay = null;
    public bool IsThuocGN=false ;
    public bool IsThuocHTT=false;
    public bool IsThuocKS = false;

    public string TenKho = null;
    public string TenThuoc = null;




    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        
        string select ="";
        if(this.IsThuocGN)      
                select=@"SELECT *
                            from  dbo.Thuoc_TonKho10(" + this.IDKho + ",'" + this.TuNgay + "','" + DenNgay + " 23:59:59') T";
        else 
            if(this.IsThuocHTT)
                select=@"SELECT *
                            from  dbo.Thuoc_TonKho11(" + this.IDKho + ",'" + this.TuNgay + "','" + DenNgay + " 23:59:59') T";

            else
                if (this.IsThuocKS)
                    select = @"SELECT *
                            from  dbo.Thuoc_TonKho_KS(" + this.IDKho + ",'" + this.TuNgay + "','" + DenNgay + " 23:59:59') T";

        else

        if (IsThuocGN == false && IsThuocHTT == false)
        {
            select = @"SELECT *
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
        return "TinhHinhSDThuocGayNghien.xls";
    }
    protected override string SetOutputFileName()
    {
        return "TinhHinhSDThuoc.xls";
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
        string s = "BÁO CÁO SỬ DỤNG THUỐC THÀNH PHẨM";
        if (IsThuocGN)
            s += " THUỐC GÂY NGHIỆN";
        else
            if (this.IsThuocHTT)
            s += " HƯỚNG TÂM THẦN";
            else if(this.IsThuocKS)
                s += " KHÁNG SINH";

        if (this.IsThuocGN == false && this.IsThuocHTT == false)
            s += " THUỐC ";

        s += " " + StaticData.TimeDescription(this.TuNgay, this.DenNgay).ToUpper();
        return s;
    }
}

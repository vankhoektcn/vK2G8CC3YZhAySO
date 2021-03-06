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
public class clsBaoCaoTongHopXetNghiem : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    private string tu_ngaySQL = "";
    private string den_ngaySQL = "";
    public clsBaoCaoTongHopXetNghiem()
    {
    }
    public clsBaoCaoTongHopXetNghiem(string TuNgay, string DenNgay)
    {
        this.TuNgay = TuNgay;
        this.DenNgay = DenNgay;
        this.tu_ngaySQL = StaticData.CheckDate(TuNgay);
        this.den_ngaySQL = StaticData.CheckDate(DenNgay);
    }

    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;

        string mainWhere = "";

        #region Where

        if (!string.IsNullOrEmpty(tu_ngaySQL))
        {
            mainWhere += " and k.ngaythu>='" + tu_ngaySQL + "'";

        }
        if (!string.IsNullOrEmpty(den_ngaySQL))
        {
            mainWhere += " and k.ngaythu<='" + den_ngaySQL + " 23:59:59'";
        }


        #endregion

        string select = string.Format(@"SELECT ROW_NUMBER() OVER (ORDER  BY B.TENDICHVU) STT,
            B.TENDICHVU, SUM(ISNULL(K.SOLUONG,1)) SOLUONG
            ,K.DONGIA,
            NULLIF( SUM(ISNULL(K.SOLUONG,1)*K.DONGIA*(K.CHIETKHAU/100)),0) CHIETKHAU,
            SUM(ISNULL(K.SOLUONG,1)*K.DONGIA*(1-(K.CHIETKHAU/100))) THANHTIEN        
            FROM DBO.KHAMBENHCANLAMSAN K
            INNER JOIN DBO.BANGGIADICHVU B ON K.IDCANLAMSAN=B.IDBANGGIADICHVU
            INNER JOIN DBO.PHONGKHAMBENH P ON B.IDPHONGKHAMBENH=P.IDPHONGKHAMBENH
            WHERE ISNULL(K.DAHUY,0)=0 AND K.DATHU =1
            AND P.MAPHONGKHAMBENH='XN' {0}
            GROUP BY B.IDBANGGIADICHVU, B.TENDICHVU, K.DONGIA
        
            ", mainWhere);

        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        return lst;


    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A12");
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("SOLUONG");
        lst.Add("CHIETKHAU");
        lst.Add("THANHTIEN");
        return lst;
    }
    protected override string SetInputFileName()
    {
        return "BaoCaoTongKetXetNghiem.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BaoCaoTongKetXetNghiem.xls";
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();

        return lstC;
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A7"));
        lst.Add(GetCellIndex("E16"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        DateTime d = DateTime.Today;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add((TuNgay == DenNgay ? (string.Format("Ngày {0:dd/MM/yyyy}", TuNgay)) : (string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TuNgay, DenNgay))));
        lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("MM") + "  năm " + d.ToString("yyyy"));
        return lst;
    }

    protected override bool SetIsSumByGroupValue()
    {
        return true;
    }
    protected override string Set_Total1_Name()
    {
        return "Tổng";
    }
   


}

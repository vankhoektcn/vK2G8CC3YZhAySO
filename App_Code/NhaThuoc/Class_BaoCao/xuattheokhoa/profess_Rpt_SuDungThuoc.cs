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
public class profess_Rpt_Xuattheokhoa1 : ExportToExcel.Profess_ExportToExcelByCode
{
    public string StockID = null;
    public string LoaiThuocID = null;
    public profess_Rpt_Xuattheokhoa1()
    {
        //this.IsDeleteTotalRow = true;	  
    }
    public override DataTable getViewTable()
    {
        if (this.FromDate == null || this.FromDate == "") return null;
        if (this.ToDate == null || this.ToDate == "") return null;
        if (this.StockID == null) this.StockID = StaticData.MacDinhKhoNhapMuaID;
        if (this.LoaiThuocID == null) this.LoaiThuocID = "1";
        string IdThuocName = "A.IdThuoc";
        if (LoaiThuocID == "1")
            IdThuocName = "DBO.Thuoc_Top1IDthuoc( A.IDTHUOC)";
        string sqlSelect = @"select Row_Number() Over(order by TenThuoc) AS STT
            ,thuoc=tenthuoc
            ,tondau=ISNULL((   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUNHAPKHO A1
                        LEFT JOIN PHIEUNHAPKHO B1 ON A1.IDPHIEUNHAP=B1.IDPHIEUNHAP
                         WHERE B1.IDKHO=" + this.StockID
                        + @" AND NGAYTHANG<'" + this.FromDate + @"'
                            AND A1.IDTHUOC="+IdThuocName + @"
                     ),0)
                    +ISNULL((   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUNHAPKHO A1
                        LEFT JOIN PHIEUNHAPKHO B1 ON A1.IDPHIEUNHAP=B1.IDPHIEUNHAP
                         WHERE B1.IDKHO=" + this.StockID
                        + @" AND NGAYTHANG>='" + this.FromDate + @"'"
                        + @" AND NGAYTHANG<='" + this.ToDate + @"'
                            AND A1.IDTHUOC="+IdThuocName + @"
                     ),0)
                    -ISNULL((   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                        LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                         WHERE B1.IDKHO=" + this.StockID
                        + @" AND NGAYTHANG<'" + this.FromDate + @"'
                            AND A1.IDTHUOC="+IdThuocName + @"
                      ),0)
              ,xuat=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                        LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                         WHERE B1.IDKHO=" + this.StockID
                        + @" AND NGAYTHANG>='" + this.FromDate + @"'
                             AND NGAYTHANG<='" + this.ToDate + @"'
                             AND A1.IDTHUOC="+IdThuocName + @"
                   )
            ,toncuoi=0,Top1IDthuoc="+IdThuocName + @",A.IDThuoc
            from thuoc a
            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
            where a.isThuocBV=1
            
             and A.LoaiThuociD=" + this.LoaiThuocID;
            
            

        DataTable dt = GetTable(sqlSelect);
        if (dt != null && dt.Rows.Count > 0)
        {
            dt.DefaultView.RowFilter = "Top1IDthuoc=IDThuoc"; dt.DefaultView.Sort = "thuoc";
            dt = dt.DefaultView.ToTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string iTonDau = dt.Rows[i]["tondau"].ToString();
                if (iTonDau == "") iTonDau = "0";
                string ixuat = dt.Rows[i]["xuat"].ToString();
                if (ixuat == "") ixuat = "0";
                double iTonCuoi = double.Parse(iTonDau) -  double.Parse(ixuat);
                dt.Rows[i]["toncuoi"] = iTonCuoi;
                dt.Rows[i]["STT"] = i + 1;

            }
        }
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A6");
    }
   
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("C3"));
        lst.Add(GetCellIndex("E3"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(FromDate);
        lst.Add(ToDate);
        return lst;

    }
    protected override string SetInputFileName()
    {
        return "Xuattheokhoa.xls";
    }
    protected override string SetOutputFileName()
    {
        return "Xuattheokhoa.xls";
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lstt = new System.Collections.Generic.List<string>();
        lstt.Add("Top1IDthuoc");
        lstt.Add("IDThuoc");
        return lstt;
    }
}

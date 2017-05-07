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
public class profess_Rpt_Xuattaikhoa : ExportToExcel.Profess_ExportToExcelByCode
{
    public string StockID = null;
    public string LoaiThuocID = null;
    public string Year = null;
    public string TenLoaiThuoc = null;

    public profess_Rpt_Xuattaikhoa()
    {
        //this.IsDeleteTotalRow = true;	  
    }
    public override DataTable getViewTable()
    {
        if (this.Year == null || this.Year == "") return null;
        if (this.StockID == null) this.StockID = StaticData.MacDinhKhoNhapMuaID;
        if (this.LoaiThuocID == null)
        {
            this.LoaiThuocID = "1";
            this.TenLoaiThuoc = "Thuốc";
        }
        string IdThuocName = "A.IdThuoc";
        if (LoaiThuocID == "1")
            IdThuocName = "DBO.Thuoc_Top1IDthuoc( A.IDTHUOC)";
        string sqlSelect = @"select Row_Number() Over(order by TenThuoc) AS STT
                                ,thuoc=tenthuoc
                                ,thangmot=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=1
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
	                            ,thanghai=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=2
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
	                            ,thangba=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=3
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
	                            ,thangtu=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=4
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
	                            ,thangnam=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=5
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
	                            ,thangsau=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=6
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
                                ,thangbay=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=7
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
                                ,thangtam=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=8
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
                                ,thangchin=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=9
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
                                ,thangmuoi=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=10
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
                                ,thangmuoimot=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=11
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
                                ,thangmuoihai=(   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                                              LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                               WHERE B1.IDKHO=" + this.StockID
                                                + @" AND year(NGAYTHANG)=" + this.Year
                                                + @" AND Month(NGAYTHANG)=12
                                                  AND A1.IDTHUOC=A.IDTHUOC
                                          )
                                ,Top1IDthuoc="+IdThuocName + @",A.IDThuoc
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
                dt.Rows[i]["STT"] = i + 1;
            }
        }
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");
    }
    //protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    //{
    //    System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
    //    lst.Add("ghichu2");
    //     lst.Add("tenloai");
    //    return lst;
    //}
    //protected override System.Collections.Generic.List<string> SetListGroupName()
    //{
    //    System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
    //    lst.Add("tenloai");
    //    return lst;
    //}
    //protected override System.Collections.Generic.List<string> SetListSumColumnName()
    //{
    //    System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
    //    lst.Add("tondau");
    //    return lst;
    //}
    //protected override bool SetIsSumByGroupValue()
    //{
    //    return true;
    //}
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("D4"));
        lst.Add(GetCellIndex("H4"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(StockName);
        lst.Add(TenLoaiThuoc);
        return lst;

    }
    protected override string SetInputFileName()
    {
        return "Tong xuat.xls";
    }
    protected override string SetOutputFileName()
    {
        return "Tong xuat.xls";
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lstt = new System.Collections.Generic.List<string>();
        lstt.Add("Top1IDthuoc");
        lstt.Add("IDThuoc");
        return lstt;
    }
}

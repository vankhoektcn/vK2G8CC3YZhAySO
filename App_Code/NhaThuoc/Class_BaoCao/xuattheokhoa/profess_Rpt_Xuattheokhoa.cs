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
public class profess_Rpt_Xuattheokhoa : ExportToExcel.Profess_ExportToExcelByCode
{
    public string StockID = null;
    public string LoaiThuocID = null;
    public string TenThuoc = null;
    public profess_Rpt_Xuattheokhoa()
    {
        //this.IsDeleteTotalRow = true;	  
    }
    public override DataTable getViewTable()
    {
        if (this.FromDate == null || this.FromDate == "") return null;
        if (this.ToDate == null || this.ToDate == "") return null;
        if (this.LoaiThuocID == null) this.LoaiThuocID = "1";
        string IdThuocName = "A.IdThuoc";
        if (LoaiThuocID == "1")
            IdThuocName = "DBO.Thuoc_Top1IDthuoc( A.IDTHUOC)";

        string sqlSelectKho = @"selecT DISTINCT IDKHOA= b.idphongkhambenh,b.tenphongkhambenh as TENKHOA
                                FROM KHOTHUOC A
                                    LEFT JOIN PHONGKHAMBENH B ON A.IDKHOA=B.IDPHONGKHAMBENH
                                        where b.idphongkhambenh is not null";

        if (this.StockID != null && this.StockID != "" && this.StockID != "0")
            sqlSelectKho = @"selecT  IDKHOA= a.idkho,TENKHO as TENKHOA
                                FROM KHOTHUOC A
                                        where A.IDKHOA=" + this.StockID;

        DataTable dtKho = GetTable(sqlSelectKho);
        if (dtKho == null || dtKho.Rows.Count == 0) return null;

        string sqlSelect = @"select Row_Number() Over(order by TenThuoc) AS STT
            ,thuoc=tenthuoc,DVT=TenDVT";
        for(int i=0;i<dtKho.Rows.Count;i++)
        {
          sqlSelect+=@",xuat_"+dtKho.Rows[i]["IdKhoa"].ToString()+@"=(   SELECT SUM(A1.SOLUONG)
                            FROM CHITIETPHIEUXUATKHO A1
                            LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                            LEFT JOIN KHOTHUOC C1 ON B1.IDKHO2=C1.IDKHO
                             WHERE 1=1"
                               +@" AND B1.LoaiXuat<>4 "
                               + (this.StockID != null && this.StockID != "" && this.StockID != "0" ?
                                    " and    C1.IDKHOA=" + dtKho.Rows[i]["IDKHOA"].ToString()
                                    : " AND B1.IDKHO="+dtKho.Rows[i]["IDKHOA"].ToString()
                                   )
                               + @" AND NGAYTHANG>='" + this.FromDate + @"'
                                    AND NGAYTHANG<='" + this.ToDate + @"'
                                    AND A1.IDTHUOC="+IdThuocName + @"
                   )
                    ";
        }
        sqlSelect+=@"
            ,Top1IDthuoc="+IdThuocName + @",A.IDThuoc
            from thuoc a
            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
            left join thuoc_DonViTinh C on A.IdDVT=C.ID
            where a.isThuocBV=1
             and A.LoaiThuociD=" + this.LoaiThuocID;

        if (this.TenThuoc != null)
            sqlSelect += " AND A.TENTHUOC LIKE N'" + this.TenThuoc + "%'";

        DataTable dt = GetTable(sqlSelect);
        if (dt != null && dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "thuoc";
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
        return GetCellIndex("A6");
    }
    string[] arrIndeHeader = new string[] {"C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T" ,"U","V","W","X","Y","Z"};

    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("C3"));
        lst.Add(GetCellIndex("E3"));
        string sqlSelectKho = @"selecT DISTINCT IDKHOA= b.idphongkhambenh,b.tenphongkhambenh as TENKHOA
                                FROM KHOTHUOC A
                                    LEFT JOIN PHONGKHAMBENH B ON A.IDKHOA=B.IDPHONGKHAMBENH
                                        where b.idphongkhambenh is not null";

        if (this.StockID != null && this.StockID != "" && this.StockID != "0")
            sqlSelectKho = @"selecT  IDKHOA= idkho,TENKHO as TENKHOA
                                FROM KHOTHUOC A
                                        where A.IDKHOA=" + this.StockID;

            DataTable dtKho = GetTable( sqlSelectKho);
            if (dtKho != null && dtKho.Rows.Count > 0)
            {
                for (int i = 1; i <= dtKho.Rows.Count; i++)
                    lst.Add(GetCellIndex(arrIndeHeader[i] + "5"));
            }

        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(FromDate);
        lst.Add(ToDate);
        string sqlSelectKho = @"selecT DISTINCT IDKHOA= b.idphongkhambenh,b.tenphongkhambenh as TENKHOA
                                FROM KHOTHUOC A
                                    LEFT JOIN PHONGKHAMBENH B ON A.IDKHOA=B.IDPHONGKHAMBENH
                                        where b.idphongkhambenh is not null";

        if (this.StockID != null && this.StockID != "" && this.StockID != "0")
            sqlSelectKho = @"selecT  IDKHOA= idkho,TENKHO as TENKHOA
                                FROM KHOTHUOC A
                                        where A.IDKHOA=" + this.StockID;


            DataTable dtKho = GetTable(sqlSelectKho);
            if (dtKho != null && dtKho.Rows.Count > 0)
            {
                for (int i = 0; i < dtKho.Rows.Count; i++)
                    lst.Add(dtKho.Rows[i]["TENKHOA"].ToString());
            }
        return lst;

    }
    protected override string SetInputFileName()
    {
        if (this.StockID == null || this.StockID == "" || this.StockID == "0")
        {
            return "Xuattheokhoa1.xls";
        }
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

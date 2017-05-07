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
public class profess_Rpt_khoatra : ExportToExcel.Profess_ExportToExcelByCode
{
    public string StockID = null;
    public string LoaiThuocID = null;
    public string TENLOAITHUOC = "Thuốc";
    public string tenthuoc = null;
    public profess_Rpt_khoatra()
	{
        //this.IsDeleteTotalRow = true;	  
	}
    public override DataTable getViewTable()
    {
        if (this.FromDate == null || this.FromDate == "") return null;
        if (this.ToDate == null || this.ToDate == "") return null;
        string sqlSelectKho = "SELECT IDKHO,TENKHO FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 AND  IDKHO<>" + StaticData.MacDinhKhoNhapMuaID;
        if (this.StockID != null && this.StockID != "" && this.StockID != "0")
            sqlSelectKho += " AND IDKHO=" + this.StockID;

        DataTable dtKho = GetTable(sqlSelectKho);
        if (dtKho == null || dtKho.Rows.Count == 0) return null;

        if (this.LoaiThuocID == null) this.LoaiThuocID = "1";
        string IdThuocName = "A.IdThuoc";
        if (LoaiThuocID == "1")
            IdThuocName = "DBO.Thuoc_Top1IDthuoc( A.IDTHUOC)";
        string sqlSelect = @"select Row_Number() Over(order by TenThuoc) AS STT
            ,thuoc=tenthuoc
            ,C=''
            ,D=''
            ,E=''
            ,F=''
            ,G=''";
          for(int i=0;i<dtKho.Rows.Count;i++)
        {
           sqlSelect+=",tra_"+dtKho.Rows[i]["IdKho"].ToString() +@"=
              ISNULL((   SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUxuatKHO A1
                        LEFT JOIN PHIEUxuatKHO B1 ON A1.IDPHIEUxuat=B1.IDPHIEUxuat
                         WHERE B1.idkho2=" + StaticData.MacDinhKhoNhapMuaID
                        + @" AND NGAYTHANG>='" + this.FromDate + @"'
                             AND NGAYTHANG<='" + this.ToDate + @"'
                             AND A1.IDTHUOC="+IdThuocName + @"
                             AND B1.loaixuat=4
                            and    B1.IDKHO=" + dtKho.Rows[i]["IdKho"].ToString()
                            +@"

                   ),0)";
            };

           sqlSelect+=@" ,Top1IDthuoc=" + IdThuocName + @",A.IDThuoc
            from thuoc a
            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
            where a.isThuocBV=1
             and A.LoaiThuociD=" + this.LoaiThuocID;
           if (this.tenthuoc != null)
               sqlSelect += " AND A.TENTHUOC LIKE N'" + this.tenthuoc + "%'";
 
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
        return GetCellIndex("A9");
    }

    string[] arrIndeHeader = new string[] { "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("D5"));
        lst.Add(GetCellIndex("H5"));
        lst.Add(GetCellIndex("D6"));
        lst.Add(GetCellIndex("H6"));
        if (this.StockID == null || this.StockID == "" || this.StockID == "0")
        {
            DataTable dtKho = GetTable("SELECT IDKHO,TENKHO FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 AND  IDKHO<>" + StaticData.MacDinhKhoNhapMuaID);
            if (dtKho != null && dtKho.Rows.Count > 0)
            {
                for (int i = 0; i < dtKho.Rows.Count; i++)
                    lst.Add(GetCellIndex(arrIndeHeader[i] + "8"));
            }
        }

        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(FromDate);
        lst.Add(ToDate);
        lst.Add(StockName);
        lst.Add(TENLOAITHUOC);
        if (this.StockID == null || this.StockID == "" || this.StockID == "0")
        {
            DataTable dtKho = GetTable("SELECT IDKHO,TENKHO FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 AND  IDKHO<>" + StaticData.MacDinhKhoNhapMuaID);
            if (dtKho != null && dtKho.Rows.Count > 0)
            {
                for (int i = 0; i < dtKho.Rows.Count; i++)
                    lst.Add(dtKho.Rows[i]["TenKho"].ToString());
            }
        }
        return lst;

    }
    protected override string SetInputFileName()
    {
        if (this.StockID == null || this.StockID == "" || this.StockID == "0")
        {
            return "khoatra1.xls";
        } 
        return "khoatra.xls";
    }
    protected override string SetOutputFileName()
    {
        return "khoatra.xls";
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lstt = new System.Collections.Generic.List<string>();
        lstt.Add("Top1IDthuoc");
        lstt.Add("IDThuoc");
        return lstt;
    }
}

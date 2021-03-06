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
public class profess_Rpt_SoDuDauKy : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IDKho = null;
    public string TuNgay = null;
    public string loaithuoc = null;

    public string TenKho = null;
    public string TenLoaiThuoc = null;
    public string TenThuoc = null;




    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        string select = @"SELECT row_number() OVER (ORDER BY T.TENTHUOC) AS STT
                            ,T.TENTHUOC
                            ,T.TENDVT
                            ,T.LOSANXUAT
                            ,T.NGAYHETHAN
                            ,T.DAUKY_SL
                            ,T.DAUKY_TT,CATENAME,TENNHOM,DES,MANHOM,des1=0,manhom1=0
                            from  dbo.Thuoc_TonKho5(" + this.IDKho + ",'" + this.TuNgay + "','" + TuNgay + "',"+this.loaithuoc+") T"
                         +" WHERE T.TENTHUOC LIKE N'"+this.TenThuoc+"%'";
        DataTable dt = DataAcess.Connect.GetTable(select);

        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["des1"] = StaticData.DoiTuSoLaMaSangInt(dt.Rows[i]["des"].ToString());
               // dt.Rows[i]["manhom1"] = StaticData.DoiTuSoLaMaSangInt(dt.Rows[i]["manhom"].ToString());
            }

            dt.DefaultView.Sort = "des1,manhom,TENTHUOC";
            dt = dt.DefaultView.ToTable();

            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
        }

        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");
    }
   
    protected override string SetInputFileName()
    {
        return "SoDuDauKy.xls";
    }
    protected override string SetOutputFileName()
    {
        return "SoDuDauKy.xls";
    }
    protected override System.Collections.Generic.List<string> SetListExcelHidenColumns()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("CATENAME");
        lst.Add("TENNHOM");
        lst.Add("DES");
        lst.Add("MANHOM");
        lst.Add("des1");
        lst.Add("manhom1");
        return lst;

    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("C4"));
        lst.Add(GetCellIndex("C5"));
        lst.Add(GetCellIndex("B7"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
         
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(this.TenKho);
        lst.Add("Tháng: " + DateTime.Parse(this.TuNgay).ToString("MM/yyyy"));
        lst.Add(TenLoaiThuoc);
        
        return lst;
    }
}

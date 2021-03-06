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
public class clsBaoCaoTienCLS : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    private string tu_ngaySQL = "";
    private string den_ngaySQL = "";
    public string Khoa = "0";
    public string Loai = "0";
    public string KhoaText = "";
    public string LoaiText = "";
    public string KhoaCLS = "";
    public string KhoaCLSText = "";
    public clsBaoCaoTienCLS()
    {
    }
    public clsBaoCaoTienCLS(string TuNgay, string DenNgay,
        string Khoa, string KhoaText, string Loai, string LoaiText, string KhoaCLS, string KhoaCLSText)
    {
        this.TuNgay = TuNgay;
        this.DenNgay = DenNgay;
        this.Khoa = Khoa;
        this.Loai = Loai;
        this.tu_ngaySQL = StaticData.CheckDate(TuNgay);
        this.den_ngaySQL = StaticData.CheckDate(DenNgay);
        this.LoaiText = LoaiText;
        this.KhoaText = KhoaText;
        this.KhoaCLS = KhoaCLS;
        this.KhoaCLSText = KhoaCLSText;
    }

    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;

        string mainWhere = "";

        #region Where

        if (!string.IsNullOrEmpty(tu_ngaySQL))
        {
            mainWhere += " and cls.ngaythu>='" + tu_ngaySQL + "'";

        }
        if (!string.IsNullOrEmpty(den_ngaySQL))
        {
            mainWhere += " and cls.ngaythu<='" + den_ngaySQL + " 23:59:59'";
        }

        if (!string.IsNullOrEmpty(KhoaCLS) && KhoaCLS != "0")
        {
            mainWhere += string.Format(@" and dv.idphongkhambenh={0}", KhoaCLS);
        }
        if (!string.IsNullOrEmpty(Khoa) && Khoa != "0")
        {
            mainWhere += string.Format(@" and cls.idkhoadangky={0}", Khoa);
        }
        if (!string.IsNullOrEmpty(Loai) && Loai != "0")
        {
            if (Loai == "1")
                mainWhere += string.Format(@" and ( cls.idkhambenh is not null and cls.idkhambenh <>0)");
            else if (Loai == "2")
                mainWhere += string.Format(@" and ( cls.idkhambenh is null or cls.idkhambenh =0)");

        }

        #endregion

        string select = string.Format(@"
                           select cls.maphieucls,bn.tenbenhnhan
,TongTienPhieu=isnull((select sum(thanhtien) from khambenhcanlamsan where maphieucls=cls.maphieucls),0)
,tienHoanTra=isnull((select sum(thanhtien) from khambenhcanlamsan where maphieucls=cls.maphieucls and isnull(isHoanTracls,0)=1),0)
,tiencls=isnull((select sum(thanhtien) from khambenhcanlamsan where maphieucls=cls.maphieucls and isnull(isHoanTracls,0)=0),0)
,null tientu, null tienxe, null tongthu, null hoanung, null noptq, null conlai
            from khambenhcanlamsan cls
            left join banggiadichvu dv on cls.idcanlamsan = dv.idbanggiadichvu
            left join benhnhan bn on bn.idbenhnhan=dbo.KB_getidbenhnhan(cls.idkhambenhcanlamsan)
            where 1=1 and cls.dathu =1 and isnull(cls.dahuy,0)=0 {0}
            group by cls.maphieucls, bn.tenbenhnhan
            order by cls.maphieucls
            
            ", mainWhere);



        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A13");
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("TongTienPhieu");        
        lst.Add("tiencls");
        lst.Add("tienHoanTra");        
        return lst;
    }
    protected override string SetInputFileName()
    {
        return "BaoCaoThuCLS.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BaoCaoThuCLS.xls";
    }
    //protected override System.Collections.Generic.List<string> SetListGroupName()
    //{
    //    System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
    //    lstC.Add("NGAY");
    //    return lstC;
    //}
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A6"));        
        lst.Add(GetCellIndex("A7"));
        lst.Add(GetCellIndex("A8"));
        lst.Add(GetCellIndex("G17"));
        
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        DateTime d=DateTime.Now;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add("BÁO CÁO THU TIỀN CẬN LÂM SÀN " + ((!string.IsNullOrEmpty(Loai) && Loai != "0") ? LoaiText.ToUpper() : ""));


        lst.Add((TuNgay == DenNgay ? (string.Format("Ngày {0:dd/MM/yyyy}", TuNgay)) : (string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TuNgay, DenNgay))));
        string khoa = (!string.IsNullOrEmpty(Khoa) && Khoa != "0") ? "Khoa: " + KhoaText : "";
        string khoaCLS=(!string.IsNullOrEmpty(KhoaCLS) && KhoaCLS != "0") ? "Cận lâm sàn: " + KhoaCLSText : "";

        lst.Add(khoa != "" && khoaCLS != "" ? khoa + " - " + khoaCLS :
            khoa != "" && khoaCLS == "" ? khoa : khoa == "" && khoaCLS != "" ? khoaCLS : "");
        lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("MM") + "  năm " + d.ToString("yyyy"));
        return lst;
    }
}

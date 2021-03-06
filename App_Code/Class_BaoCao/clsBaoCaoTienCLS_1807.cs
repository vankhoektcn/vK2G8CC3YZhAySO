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
public class clsBaoCaoTienCLS_1807 : ExportToExcel.Profess_ExportToExcelByCode
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
    public clsBaoCaoTienCLS_1807()
    {
    }
    public clsBaoCaoTienCLS_1807(string TuNgay, string DenNgay,
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
        this.CurrentLanguage = 1;
    }

    public override DataTable getViewTable() // bắt buộc
    {
        string select = @"
                    select distinct  MAPHIEU,tenbenhnhan
					                    ,TongTienPhieu=isnull((select sum(tongtien) from hs_dsdathu a
                                            left join khambenhcanlamsan b on b.idkhambenhcanlamsan=a.idkhambenhcanlamsan
                                            left join banggiadichvu c on c.idbanggiadichvu=b.idcanlamsan
                                              where ISNULL(ISDAHUY,0)=0 AND MAPHIEU=dt.MAPHIEU 
                                            " + ((!this.KhoaCLS.Equals("") && !this.KhoaCLS.Equals("0")) ? " and c.idphongkhambenh ='" + this.KhoaCLS + @"'" : "") + @"
                                            ),0)
					                    ,tienHoanTra=0
					                    ,tiencls=0,tientu=0,tienxe=0,tongthu=0,hoanung=0,noptq=0,conlai=0
					                    --,SysDate
                     from hs_dsdathu dt
                     left join khambenhcanlamsan ct on ct.idkhambenhcanlamsan=dt.idkhambenhcanlamsan
                     left join banggiadichvu bg on bg.idbanggiadichvu=ct.idcanlamsan
                     left join khambenh kb on kb.idkhambenh=ct.idkhambenh
                     where  ISNULL(ISDAHUY,0)=0 AND nloaithu=2
		                    " + (!this.tu_ngaySQL.Equals("") ? " and SysDate>='" + this.tu_ngaySQL + @"'" : "") + @"
                            " + (!this.den_ngaySQL.Equals("") ? " and SysDate<='" + this.den_ngaySQL + @" 23:59:59'" : "") + @"
                            " + ((!this.Khoa.Equals("") && !this.Khoa.Equals("0")) ? " and kb.idkhoa='" + this.Khoa + @"'" : "") + @"
                            " + ((!this.KhoaCLS.Equals("") && !this.KhoaCLS.Equals("0")) ? " and bg.idphongkhambenh ='" + this.KhoaCLS + @"'" : "") + @"   ";
        if (!this.Loai.Equals("") && !this.Loai.Equals("0"))
        {
            if (this.Loai.Equals("1"))
                select += @" and isnull(ct.idkhambenh,0)<>0";
            else
                select += @" and isnull(ct.idkhambenh,0)=0";
        }
        select += " order by maphieu";
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
       // lst.Add(GetCellIndex("G17"));
        
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
        //lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("MM") + "  năm " + d.ToString("yyyy"));
        return lst;
    }
}

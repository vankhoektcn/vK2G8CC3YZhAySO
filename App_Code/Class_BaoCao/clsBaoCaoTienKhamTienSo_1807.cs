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
public class clsBaoCaoTienKhamTienSo_1807 : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    private string tu_ngaySQL = "";
    private string den_ngaySQL = "";
    public string BacSi = "0";
    public string Khoa = "0";
    public string Phong = "0";
    public clsBaoCaoTienKhamTienSo_1807()
    {
    }
    public clsBaoCaoTienKhamTienSo_1807(string TuNgay, string DenNgay, string BacSi, string Khoa, string Phong)
    {
        this.TuNgay = TuNgay;
        this.DenNgay = DenNgay;
        this.BacSi = BacSi;
        this.Khoa = Khoa;
        this.Phong = Phong;
        this.tu_ngaySQL = StaticData.CheckDate(TuNgay);
        this.den_ngaySQL = StaticData.CheckDate(DenNgay);
        this.CurrentLanguage = 1;
    }

    public override DataTable getViewTable() // bắt buộc
    {
        string select = @"
            select    distinct  stt=1,SysDate,MAPHIEU,mabenhnhan,tenbenhnhan,
					            noidung =isnull((select top 1 TENDICHVU from hs_dsdathu where ISNULL(ISDAHUY,0)=0 AND MAPHIEU=dt.MAPHIEU),'')
					            ,TIENKHAM=isnull((select sum(tongtien) from hs_dsdathu  where ISNULL(ISDAHUY,0)=0 AND MAPHIEU=dt.MAPHIEU and TENDICHVU<>N'Sổ khám bệnh'),0)
					            ,TIENSO=isnull((select sum(tongtien) from hs_dsdathu  where ISNULL(ISDAHUY,0)=0 AND MAPHIEU=dt.MAPHIEU and TENDICHVU=N'Sổ khám bệnh'),0)
					            ,tienHoanTra=0
					            ,TongCong=0
             from hs_dsdathu dt
             left join chitietdangkykham ct on ct.idchitietdangkykham=dt.idchitietdangkykham
             left join banggiadichvu bg on bg.idbanggiadichvu=ct.idbanggiadichvu
             where ISNULL(ISDAHUY,0)=0 AND loaithu='phikham'
                " + (!this.tu_ngaySQL.Equals("") ? " and SysDate>='" + this.tu_ngaySQL + @"'" : "") + @"
                " + (!this.den_ngaySQL.Equals("") ? " and SysDate<='" + this.den_ngaySQL + @" 23:59:59'" : "") + @"
                " + ((!this.Khoa.Equals("") && !this.Khoa.Equals("0")) ? " and bg.idphongkhambenh='" + this.Khoa + @"'" : "") + @"
                " + ((!this.Phong.Equals("") && !this.Phong.Equals("0")) ? " and ct.phongid='" + this.Phong + @"'" : "") + @"      
             ";
        DataTable dt = DataAcess.Connect.GetTable(select);
        if(dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                float tong_i= StaticData.ParseFloat(dt.Rows[i]["TIENKHAM"]) + StaticData.ParseFloat(dt.Rows[i]["TIENSO"]) - StaticData.ParseFloat(dt.Rows[i]["tienHoanTra"]);
                dt.Rows[i]["TongCong"] = tong_i.ToString();
                dt.Rows[i]["stt"] = (i + 1);
            }
        }
            return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("TIENKHAM");
        lst.Add("TIENSO");
        lst.Add("tienHoanTra");
        lst.Add("TongCong");
        return lst;
    }
    protected override string SetInputFileName()
    {
        return "BaoCaoTienKhamTienSo.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BaoCaoTienKhamTienSo.xls";
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
        lst.Add(GetCellIndex("A4"));
       // lst.Add(GetCellIndex("G10"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        DateTime d=DateTime.Now;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add((TuNgay == DenNgay ? (string.Format("Ngày {0:dd/MM/yyyy}", TuNgay)) : (string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TuNgay, DenNgay))));
       // lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("MM") + "  năm " + d.ToString("yyyy"));
        return lst;
    }
}

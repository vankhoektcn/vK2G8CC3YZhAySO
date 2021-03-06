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
public class profess_Rpt_DSBNCLS : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    private string tu_ngaySQL = "";
    private string den_ngaySQL = "";
    public string KhoaCLS = "0";
    public string Khoa = "0";
    public string LoaiCLS = "0";
    public profess_Rpt_DSBNCLS()
    {
    }
    public profess_Rpt_DSBNCLS(string sTuNgay, string sDenNgay, string sKhoaCLS, string sKhoa, string sLoaiCLS)
    {
        this.TuNgay = sTuNgay;
        this.DenNgay = sDenNgay;
        this.KhoaCLS = sKhoaCLS;
        this.Khoa = sKhoa;
        this.LoaiCLS = sLoaiCLS;
        this.tu_ngaySQL = StaticData.CheckDate(TuNgay);
        this.den_ngaySQL = StaticData.CheckDate(DenNgay);
    }

    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        string LoaiCLS_Clause = "";
        if (this.LoaiCLS != null && this.LoaiCLS != "" && this.LoaiCLS != "0")
        {
            if (LoaiCLS == "1")
            {
                LoaiCLS_Clause = " AND ISNULL(b.IDBENHNHAN,0)<>0 AND ISNULL(b.IDKHAMBENH,0)=0 AND dbo.KB_HaveKhamBenh(a.idbenhnhan,b.ngaythu)=0  and (select top 1 iddangkykham from dangkykham where idbenhnhan=a.idbenhnhan and ngaydangky>='" + tu_ngaySQL + "'  and ngaydangky <='" + den_ngaySQL + " 23:59:59' ) is null  " + "\r\n";
            }
            else
                LoaiCLS_Clause = " AND  ISNULL(b.IDKHAMBENH,0)<>0" + "\r\n";
        }

        string select = ""
                        + " select distinct STT=1," + "\r\n"
                        + " 		mabenhnhan," + "\r\n"
                        + " 		tenbenhnhan," + "\r\n"
                        + " 		ngaysinh," + "\r\n"
                        + " 		gioitinh=dbo.GetGioiTinh(a.gioitinh) ," + "\r\n"
                        + " 		diachi," + "\r\n"
                        + "         TuDK=dbo.KB_IsTuDangKy(a.idbenhnhan,b.ngaythu)," + "\r\n"
                        + "         BCCD=dbo.KB_IsBSCD(a.idbenhnhan,b.ngaythu)" + "\r\n"
                        + " " + "\r\n"
                        + " FROM benhnhan a" + "\r\n"
                        + " LEFT join khambenhcanlamsan b on   b.idbenhnhan=a.idbenhnhan " + "\r\n"
                        + " WHERE  ISNULL(b.DATHU,0)=1 AND ISNULL(b.DAHUY,0)=0 "
                                    + (this.tu_ngaySQL!=null &&this.tu_ngaySQL!="" ?  " and b.ngaythu>='"+tu_ngaySQL+"' " + "\r\n" :"")
                                    +(this.den_ngaySQL!=null &&this.den_ngaySQL!="" ? " and b.ngaythu<='"+den_ngaySQL+" 23:59:59' " + "\r\n" :"")
                                    +(this.Khoa!=null &&this.Khoa!="" &&this.Khoa!="0"?  " 	   and isnull( idkhoadangky,1)="+Khoa+"" + "\r\n" :"")
                                    + LoaiCLS_Clause
                                    + "        " + "\r\n";
        DataTable dt = DataAcess.Connect.GetTable(select);
        if (dt != null)
        {
            dt.DefaultView.Sort = "TenBenhNhan";
            dt = dt.DefaultView.ToTable();
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
        }
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");
    }
     
    protected override string SetInputFileName()
    {
        return "DanhSachBenhNhanCanLamSang.xls";
    }
    protected override string SetOutputFileName()
    {
        return "DanhSachBenhNhanCanLamSang.xls";
    }
    
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A4"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        DateTime d=DateTime.Now;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add((TuNgay == DenNgay ? (string.Format("Ngày {0:dd/MM/yyyy}", TuNgay)) : (string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TuNgay, DenNgay))));
        return lst;
    }
}

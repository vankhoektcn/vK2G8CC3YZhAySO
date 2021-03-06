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
public class Profess_rpt_BienBanKiemKe : ExportToExcel.Profess_ExportToExcelByCode
{
    public Profess_rpt_BienBanKiemKe()
    {
        
    }
    public string IdKho = null;
    public string LoaiThuocID = null;
    public string TenLoaiThuoc = null;
    public string IdTonKho = null;
    public override DataTable getViewTable()
    {
        string sql = @"	   select  STT=0
                            ,tenthuoc=TenSP
                            ,CONGTHUC=C.CONGTHUC
                            ,TENDVT
                            ,TENNUOCSX
                            ,A.SODK
                            ,A.LoSanXuat
                            ,handung=A.Ngayhethan
                            ,SLTON= A.CUOIKY_SL
                            ,slThucTe=A.CUOIKY_SL1
                            ,DONGIA=ISNULL(A.DONGIA1,A.DONGIA)
                            ,thanhtien=A.CUOIKY_TT
                            ,slthua=null
                            ,slthieu=null
                            ,slhong=null
                            ,ghichu=null
                            FROM  HS_TonKhoViewDetail A
                              left join nuocsx B on A.IDNUOCSX_N=B.idNuocSX
                              LEFT JOIN THUOC C ON A.IDTHUOC=C.IDTHUOC  
                              WHERE A.IDTONKHO=" + this.IdTonKho;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count > 0) {
            dt.DefaultView.RowFilter = "SLTON > 0";
            dt.DefaultView.Sort = "tenthuoc,congthuc,losanxuat,handung";
            dt = dt.DefaultView.ToTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
        }
        return dt;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        return "BienBankiemke.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName()
    {
        return "BienBankiemke.xls";//TÊN FILE XUẤT RA
    }

    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A17");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
   

    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        string s0 = null;
        string s = "BIÊN BẢN KIỂM KÊ THUÔC, VẬT TƯ Y TẾ, HÓA CHẤT";
        string s1 = "BIÊN BẢN KIỂM KÊ ";
        if (this.TenLoaiThuoc != null && this.TenLoaiThuoc != "")
        {
            s1 += TenLoaiThuoc.ToUpper();
            s0 = s1;
            if (this.LoaiThuocID == "1" || this.LoaiThuocID == "5" || this.LoaiThuocID == "6")
                lst.Add("Tên thuốc, nồng độ, hàm lượng");
            else
                lst.Add("Tên " + this.TenLoaiThuoc);
        }
        else s0 = s;
        lst.Add(s0);

        string TimeDesc = StaticData.TimeDescription(this.FromDate, this.ToDate, true);
        lst.Add(TimeDesc);


        return lst;
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        if (this.TenLoaiThuoc != null && this.TenLoaiThuoc != "")
        {
            lst.Add(GetCellIndex("B15"));
        }
        lst.Add(GetCellIndex("B4"));
        lst.Add(GetCellIndex("A5"));
        return lst;
    }
}

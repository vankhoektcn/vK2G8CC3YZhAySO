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
public class profess_Rpt_BangGiaThuoc : ExportToExcel.Profess_ExportToExcelByCode
{
    public string LoaiThuocID = null;
    public string IdKho = null;
    public string TenKho = "KHOA DƯỢC";

    public profess_Rpt_BangGiaThuoc()
    {
        //this.IsDeleteTotalRow = true;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        string sqlSelect = @"select  STT =ROW_NUMBER() OVER (ORDER BY tenthuoc) 
                                ,tenthuoc 
                                ,TTHoatChat
                                ,hoatchat=CongThuc 
                                ,tenDVT
                                ,DONGIA=ROUND(DonGia*(100.0+isnull(T.VAT,0))/100,0)
                                ,SLTon=SUM(DBO.Thuoc_SoLuongXuat_new(T.IDCHITIETPHIEUNHAPKHO))
                                , ISBHYT=(CASE WHEN  T.isbhyt=1 THEN 'a' else '' end)
                                ,T.LOSANXUAT
                                ,T.NGAYHETHAN
                                ,TENNUOCSX
                           from chitietphieunhapkho T
                    left join phieunhapkho  A on T.idphieunhap=A.idphieunhap
                    left join thuoc  B on T.idthuoc=B.idthuoc
                    left join Thuoc_DonViTinh  C on b.iddvt=C.Id
                    left join Thuoc_LoaiThuoc  D on T.IdLoaiThuoc=D.LoaiThuocID
                    left join KHOTHUOC E ON T.IDKHO_NHAP=E.IDKHO
                    LEFT JOIN NHACUNGCAP F ON A.NHACUNGCAPID=F.NHACUNGCAPID
                    LEFT JOIN THUOC_LOAINHAP G ON T.IDLOAINHAP_NHAP=G.IDLOAINHAP
                    LEFT JOIN NUOCSX H ON T.IDNUOCSX_N=H.IDNUOCSX
                where 1=1 AND B.ISTHUOCBV=1" + "\r\n";
             
            if (IdKho != null && IdKho != "")
                sqlSelect += " AND T.IDKHO_NHAP=" + IdKho + "\r\n";
            if (LoaiThuocID != null && LoaiThuocID != "")
                sqlSelect += " AND B.LOAITHUOCID=" + LoaiThuocID;
            if (ToDate != null && ToDate != "" && ToDate.Length >= 10)
            {
                sqlSelect += " AND A.NgayThang<='" + ToDate + "'";
            }
            if (FromDate != null && FromDate != "" && FromDate.Length >= 10)
            {
                sqlSelect += " AND A.NgayThang>='" + FromDate + "'";
            }
            ;
            sqlSelect += @" GROUP BY TTHoatChat
                                ,CongThuc 
                                ,tenthuoc 
                                ,tenDVT
                                ,ROUND(DonGia*(100.0+isnull(T.VAT,0))/100,0)
                                ,T.LOSANXUAT
                                ,T.NGAYHETHAN
                                ,TENNUOCSX
                                ,T.isbhyt";
                               

            DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        return dt;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        if (this.LoaiThuocID == "2") return "BANGGIAHoaChat.xls";
        if (this.LoaiThuocID == "3") return "BANGGIADungCu.xls";
        if (this.LoaiThuocID == "4") return "BANGGIAVTYT.xls";
        return "BANGGIATHUOC.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        if (this.LoaiThuocID == "2") return "BANGGIAHOACHAT.xls";
        if (this.LoaiThuocID == "4") return "BANGGIAVTYT.xls";
        if (this.LoaiThuocID == "3") return "BANGGIADUNGCU.xls";
        return "BANGGIATHUOC.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A5"));

        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        string s1 = this.FromDate;
        string s2 = this.ToDate;
        lst.Add(TenKho + " - " + StaticData.TimeDescription(s1, s2));
        return lst;

    }
}

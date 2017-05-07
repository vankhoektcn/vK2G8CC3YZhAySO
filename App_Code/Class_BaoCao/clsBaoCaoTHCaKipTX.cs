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
public class clsBaoCaoTHCaKipTX:ExportToExcel.Profess_ExportToExcelByCode
{
    public  string tungay = "";
    public  string denngay = "";
    public string idbacsichinh = "";
    public clsBaoCaoTHCaKipTX()
    {

    }
    public clsBaoCaoTHCaKipTX(string tungay, string denngay, string idbacsichinh)
    {
        this.tungay = tungay;
        this.denngay = denngay;
        this.idbacsichinh = idbacsichinh;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        string sqlW="";
        if (!string.IsNullOrEmpty(idbacsichinh) && idbacsichinh != "0")
        {
            sqlW = @"   and a.idCaPhauThuat in(select distinct idcaphauthuat 
					    from BSPhauThuat bspt
					    left join ChiTietPhuCapBacSiPhauThuat ctpc on bspt.idchitietPCBSPT=ctpc.idchitietPCBSPT
					    where bspt.idNhanVien='" + idbacsichinh + "' and ctpc.idvaitroBSPT=1) ";
        }
        string select = @"  select 
                            STT=row_number() over ( order by abc.NgayPhauThuat),
                            abc.NgayPhauThuat,abc.TenBenhNhan,abc.TenPhauThuat,abc.BSPThuat,
                            abc.BSGayMe, abc.dieuduong, abc.tienphauthuat,

                            tienbschinh=ISNULL((select ISNULL(c.phantramphucap*abc.tienphauthuat/100,0)
                            from dbo.ChiTietPhuCapBacSiPhauThuat c where c.idvaitroBSPT=1 
                              AND c.idloaiphauthuat=abc.idloaiphauthuat),0),
                            tienbsphu=ISNULL((SELECT CASE dbo.NS_KiemTraThuongXuyen(2,abc.idcaphauthuat) 
                            WHEN 0 then ISNULL(c.phantramphucap*abc.tienphauthuat/100,0)
                            ELSE c.tienphucap END
                            from dbo.ChiTietPhuCapBacSiPhauThuat c where c.idvaitroBSPT=1 
                              AND c.idloaiphauthuat=abc.idloaiphauthuat),0),
                            gaymechinh=ISNULL((SELECT CASE dbo.NS_KiemTraThuongXuyen(3,abc.idcaphauthuat) 
                            WHEN 0 then ISNULL(c.phantramphucap*abc.tienphauthuat/100,0)
                            ELSE c.tienphucap END
                            from dbo.ChiTietPhuCapBacSiPhauThuat c where c.idvaitroBSPT=1 
                              AND c.idloaiphauthuat=abc.idloaiphauthuat),0),
                            gaymephu=ISNULL((SELECT CASE dbo.NS_KiemTraThuongXuyen(4,abc.idcaphauthuat) 
                            WHEN 0 then ISNULL(c.phantramphucap*abc.tienphauthuat/100,0)
                            ELSE c.tienphucap END
                            from dbo.ChiTietPhuCapBacSiPhauThuat c where c.idvaitroBSPT=1 
                              AND c.idloaiphauthuat=abc.idloaiphauthuat),0),

                            ktv=ISNULL((SELECT CASE dbo.NS_KiemTraThuongXuyen(5,abc.idcaphauthuat) 
                            WHEN 0 then ISNULL(c.phantramphucap*abc.tienphauthuat/100,0)
                            ELSE c.tienphucap END
                            from dbo.ChiTietPhuCapBacSiPhauThuat c where c.idvaitroBSPT=1 
                              AND c.idloaiphauthuat=abc.idloaiphauthuat),0),
                            ddtrong=ISNULL((SELECT CASE dbo.NS_KiemTraThuongXuyen(6,abc.idcaphauthuat) 
                            WHEN 0 then ISNULL(c.phantramphucap*abc.tienphauthuat/100,0)
                            ELSE c.tienphucap END
                            from dbo.ChiTietPhuCapBacSiPhauThuat c where c.idvaitroBSPT=1 
                              AND c.idloaiphauthuat=abc.idloaiphauthuat),0),
                            dieuduongngoai=ISNULL((SELECT CASE dbo.NS_KiemTraThuongXuyen(8,abc.idcaphauthuat) 
                            WHEN 0 then ISNULL(c.phantramphucap*abc.tienphauthuat/100,0)
                            ELSE c.tienphucap END
                            from dbo.ChiTietPhuCapBacSiPhauThuat c where c.idvaitroBSPT=1 
                              AND c.idloaiphauthuat=abc.idloaiphauthuat),0)
                            from(
                            select distinct 
                            NgayPhauThuat=convert(nvarchar(10),ngayphauthuat,103)
                            ,TenBenhNhan=b.tenbenhnhan
                            ,TenPhauThuat=e.tendichvu
                            ,BSPThuat=(select [dbo].[NS_ChuoiEkip] (a.idcaphauthuat,1))
                            ,BSGayMe=(select [dbo].[NS_ChuoiEkip] (a.idcaphauthuat,2))
                            ,DieuDuong=(select [dbo].[NS_ChuoiEkip] (a.idcaphauthuat,3))
                            ,tienphauthuat=ISNULL(case when a.BinhThuong=1 then d.giabinhthuong else d.giatrongoi END,0)
                            ,a.idCaPhauThuat, d.idloaiphauthuat

                            from caphauthuat a
                            left join benhnhan b on b.idbenhnhan=a.idbenhnhan
                            left join clsphauthuat c on c.idcaphauthuat=a.idcaphauthuat
                            left join chitietclsgoiphauthuat d on d.idchitietclsphauthuat=c.idchitietclsphauthuat
                            left join banggiadichvu e on e.idbanggiadichvu=d.idcanlamsang
                            left join bsphauthuat f on f.idcaphauthuat=a.idcaphauthuat
                            left join nhanvien g on g.idnhanvien=f.idnhanvien "
                        + " where dbo.NS_KiemTraBacSiChinh(a.idcaphauthuat)=0 and a.ngayphauthuat>='" + StaticData.CheckDate(tungay) + " 00:00:00' and a.ngayphauthuat<='" + StaticData.CheckDate(denngay) + " 23:59:59'  " + sqlW + "\r\n"
                        + " )abc" + "\r\n";
                
        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }

    protected override string SetInputFileName() // bắt buộc
    {
        return "THKipMoTX.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "THKipMoTX.xls";//TÊN FILE XUẤT RA
    }
    //protected override string SetHeaderText()
    //{
    //    return "Từ ngày : "+ tungay+" Đến ngày : "+denngay;// TÊN REPORT
    //}
    //protected override ExportToExcel.CellIndex SetHeaderIndex()
    //{
    //    return GetCellIndex("G3");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    //}
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("tienbschinh"); //theo câu select
        lst.Add("tienbsphu");
        lst.Add("gaymechinh");
        lst.Add("gaymephu");
        lst.Add("ktv");
        lst.Add("ddtrong");
        lst.Add("dieuduongngoai");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        //lst.Add("idnhanvien"); //theo câu select
        //lst.Add("manhanvien");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        //lst.Add("cot1");
        //lst.Add("cot2");
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true; 
    }
     
    //protected override System.Collections.Generic.List<object> SetListOtherValue()
    //{
    //    //System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
    //    //lst.Add("giá 1"); //theo câu select
    //    //lst.Add("giá 2");
    //    //lst.Add("giá 3");// 
    //    //return lst;
    //}
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        //lst.Add(GetCellIndex("D12"));
        //lst.Add(GetCellIndex("D13"));
        //lst.Add(GetCellIndex("D14"));
        return lst;
    }
     
}

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
public class clsBangTongHopNgayLuong:ExportToExcel.Profess_ExportToExcelByCode
{
    public  string thang = "";
    public  string nam = "";
    public string phongban = "";
    public string LoaiNhanVien = "";
    public string idNhanVien = "";
    public clsBangTongHopNgayLuong()
    {

    }
    public clsBangTongHopNgayLuong(string thang, string nam, string phongban)
    {
        this.thang = thang;
        this.nam = nam;
        this.phongban = phongban;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        string idphong="";
        if (!string.IsNullOrEmpty(phongban) && phongban != "0")
        {
            idphong = "   and nv.idphongban=" + phongban;
        }
        if (!string.IsNullOrEmpty(LoaiNhanVien) && LoaiNhanVien != "-1")
        {
            idphong += "   and nv.LoaiNhanVien=" + LoaiNhanVien;
        }
        if (!string.IsNullOrEmpty(idNhanVien) && idNhanVien != "0")
        {
            idphong = "   and nv.idnhanvien=" + idNhanVien;
        }
        idphong += " ) abc ";
        string select = @"select  ROW_NUMBER() over(order by isnull(tenphong,'z'),thucnhan desc)as stt, abc.*
                            from
                            (  select HoTen=nv.tennhanvien,";
        for(int i=1;i<32;i++)
        {
            select += @"t"+i.ToString()+"=case when ( [dbo].[NhanSu_NoiDungNgay](nv.idnhanvien," + i.ToString() + "," + thang.ToString() + "," + nam.ToString() + @")='' OR [dbo].[NhanSu_SoGioLamMotNgay](nv.idnhanvien," + i.ToString() + "," + thang.ToString() + "," + nam.ToString() + @")='')
		then [dbo].[NhanSu_NoiDungNgay](nv.idnhanvien," + i.ToString() + "," + thang.ToString() + "," + nam.ToString() + @")+[dbo].[NhanSu_SoGioLamMotNgay](nv.idnhanvien," + i.ToString() + "," + thang.ToString() + "," + nam.ToString() + @")
		 else [dbo].[NhanSu_NoiDungNgay](nv.idnhanvien," + i.ToString() + "," + thang.ToString() + "," + nam.ToString() + @")+','+[dbo].[NhanSu_SoGioLamMotNgay](nv.idnhanvien," + i.ToString() + "," + thang.ToString() + "," + nam.ToString() + @") end,";
        }
        select += @"congthoigian=[dbo].[NS_SoGioLamNgoaiGio](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
        X=[dbo].[GetSoNgayNhanVienLamThuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
        T=[dbo].[GetSoNgayNhanVienTruc](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
		nghipk=[dbo].[GetSoNgayNhanVienPhepKhongLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
		nghipc=[dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
        L=[dbo].[GetSoNgayNhanVienLamThemNuaNgay](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
	    O=[dbo].[GetSoNgayNhanVienNghiOm](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
        VoKyLuat=[dbo].[GetSoNgayNhanVienVoKyLuat](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
        NghiBu=[dbo].[GetSoNgayNhanVienNghiBu](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
        conglephep=[dbo].[GetSoNgayNhanVienNghiLe](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
        L1=[dbo].[GetSoNgayNhanVienLamThemMotNgay](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
        thucnhan=[dbo].[NS_GetLuongThucNhan](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + @"),
        pb.tenphongban as tenphong
        from nhanvien nv left join phongban pb on pb.idphongban=nv.idphongban where 1=1 " + idphong;
  
                
        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }

    protected override string SetInputFileName() // bắt buộc
    {
        return "bangchamcong.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "bangchamcong.xls";//TÊN FILE XUẤT RA
    }
    protected override string SetHeaderText()
    {
        return "Tháng "+thang.ToString()+" Năm "+nam.ToString();// TÊN REPORT
    }
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("I4");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A9");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("thucnhan");
        return lst;
    }
    //protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    //{
    //    System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
    //    lst.Add("tenphong");
    //    return lst;
    //}
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("tenphong");
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true;
    }

    //protected override System.Collections.Generic.List<object> SetListOtherValue()
    //{
    //    System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
    //    string TenPhongBan = StaticData.GetValue("PhongBan", "idphongban", phongban, "tenphongban");
    //    lst.Add(TenPhongBan); //theo câu select
    //    //lst.Add("giá 2");
    //    //lst.Add("giá 3");// 
    //    return lst;
    //}
    //protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    //{
    //    System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
    //    lst.Add(GetCellIndex("C2"));//phong ban
    //    //lst.Add(GetCellIndex("D13"));
    //    //lst.Add(GetCellIndex("D14"));
    //    return lst;
    //}
     
}

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
public class clsTongHopTienLuong:ExportToExcel.Profess_ExportToExcelByCode
{
    public  string thang = "";
    public  string nam = "";
    public string phongban = "";
    public string LoaiNhanVien = "";
    public string idNhanVien = "";
    public clsTongHopTienLuong()
    {

    }
    public clsTongHopTienLuong(string thang, string nam, string phongban)
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
            idphong = "   and pb.idphongban=" + phongban;
        }
        if (!string.IsNullOrEmpty(LoaiNhanVien) && LoaiNhanVien != "-1")
        {
            idphong += "   and nv.LoaiNhanVien=" + LoaiNhanVien;
        }
        if (!string.IsNullOrEmpty(idNhanVien) && idNhanVien != "0")
        {
            idphong = "   and nv.idnhanvien=" + idNhanVien;
        }
        string select = ""
+ " select STT,tennhanvien,chucvu,LuongCBGio,TongLuongTruc,TongLuongLamThem" + "\r\n"
+ ",TienPhuCapDocHai,TienPhuCapTrachNhiem,TienPhuCapHienVat,TienPhuCapBoiDuong" + "\r\n"
+ ",QuyTienLuong,TongTienNgoaiGio,PCK,TienBHXH,TienBHYT,TienBHTN,ThueTNCN" + "\r\n"
+ ",ThucNhan=TongLuongThuong+TongLuongTruc+TongLuongLamThem+TienPhuCapTrachNhiem+TienPhuCapDocHai+TienPhuCapHienVat+TienPhuCapBoiDuong +TongTienNgoaiGio + QuyTienLuong+PCK" + "\r\n"
            //+ " -TruVoKyLuat " + "\r\n"
+ "-(TienBHXH+TienBHYT+TienBHTN+ThueTNCN) " + "\r\n"
+ ",tenphongban from " + "\r\n"
+ "  (" + "\r\n"
+ "  select ROW_NUMBER ( ) OVER(ORDER BY tennhanvien) AS STT" + "\r\n"
+ "                   ,nv.idnhanvien,manhanvien,tennhanvien,tenphongban" + "\r\n"
+ "  ,chucvu=cv.tenchucvu,ngayvao=hd.ngaybatdau,luongcoban=round(convert(real,isnull(hd.mucluongcoban,0)),0) " + "\r\n"
//+ "  ,soGioThang=hd.giolam" + "\r\n"
+ "  ,LuongCBGio=hd.luongCB +'/'+convert(varchar,hd.HeSoLCB) " + "\r\n"
+ "  ,TongLuongTruc=[dbo].[GetSoTienCaTruc](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")"
+ " - [dbo].[NS_GetSoNgayTrucTinhThuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")"
+ " * (select isnull( (select top 1 ct.tientruc from bangchamcongtheongay cc "
+ "	inner join catruc  ct on ct.idcatruc=cc.idcatruc where idnhanvien=nv.idnhanvien ),0))"
+ "  ,TongLuongLamThem=([dbo].[GetLuongNuaNgayNhanVien] (nv.idnhanvien) * [dbo].[GetSoNgayNhanVienLamThemNuaNgay](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")) +([dbo].[GetLuongMotNgayNhanVien] (nv.idnhanvien) * [dbo].[GetSoNgayNhanVienLamThemMotNgay](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + "))" + "\r\n"
+ "  ,TienPhuCapDocHai=[dbo].[NS_GetPhuCapDocHai_TN](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ",1)" + "\r\n"
+ "  ,TienPhuCapTrachNhiem=[dbo].[NS_GetPhuCapDocHai_TN](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ",2)" + "\r\n"
+ "  ,TienPhuCapHienVat=[dbo].[NS_GetPhuCapHienVat](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ "  ,TienPhuCapBoiDuong=[dbo].[NS_GetPhuCapBoiDuongSanPham](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ " ,QuyTienLuong=[dbo].[NS_GetQuyTienLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ "  ,TongTienNgoaiGio=[dbo].[NS_TongTienLamNgoaiGio] (nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ " ,PCK=[dbo].[NS_GetPhuCapKhac](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ "  ,TienBHXH=dbo.[GetTienBHXH_NhanVien](nv.idnhanvien)" + "\r\n"
+ "  ,TienBHYT=[dbo].[GetTienBHYT_NhanVien](nv.idnhanvien)" + "\r\n"
+ "  ,TienBHTN=[dbo].[GetTienBHTN_NhanVien](nv.idnhanvien)" + "\r\n"
+ "  ,ThueTNCN= [dbo].[ThueTNCN_NhanVien](nv.idnhanvien)" + "\r\n"

//+ "  ,SoNgayPC=[dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
//+ "  ,SoNgayPK=[dbo].[GetSoNgayNhanVienPhepKhongLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ "  ,LuongMotNgay=[dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ "  ,TongLuongThuong= [dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")*([dbo].[GetSoNgayNhanVienLamThuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")+[dbo].[GetSoNgayNhanVienNghiLe](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")+[dbo].[NS_GetSoNgayTrucTinhThuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ") + [dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + "))" + "\r\n"
            //+ "  ,TongLuongThuong= ([dbo].[GetSoNgayNhanVienLamThuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")+[dbo].[GetSoNgayNhanVienNghiLe](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")+[dbo].[GetSoNgayNhanVienNghiBu](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ") + [dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + "))" + "\r\n"


+ "  ,TruVoKyLuat=[dbo].[GetSoNgayNhanVienVoKyLuat](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")* [dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ") " + "\r\n"
+ "  ,TienThuong=0" + "\r\n"
+ "  ,TienPhat=0" + "\r\n"
+ "  " + "\r\n"
+ "  from NhanVien NV left join phongban pb on pb.idphongban=nv.idphongban " + "\r\n"
+ "  left join hopdong hd on hd.idnhanvien=nv.idnhanvien" + "\r\n"
        + "  and hd.idhopdong=(select top 1 idhopdong from hopdong "
        + "  where idnhanvien=nv.idnhanvien and status=1 "
        + "  order by idhopdong desc)"
        + " and hd.status=1 "
+ "  left join chucvu cv on cv.idchucvu=nv.idchucvu" + "\r\n"
+ "  " + "\r\n"
+ "  where  nv.status=1 " + idphong + " " + "\r\n"
+ "  ) abc" + "\r\n";
                
        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }

    protected override string SetInputFileName() // bắt buộc
    {
        return "TongHopTienLuong.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "TongHopTienLuong.xls";//TÊN FILE XUẤT RA
    }
    protected override string SetHeaderText()
    {
        return "Tháng "+thang.ToString()+" Năm "+nam.ToString();// TÊN REPORT
    }
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("A7");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A12");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        //lst.Add("tenphongban"); //theo câu select
        lst.Add("LuongCBGio");
        lst.Add("TongLuongTruc");
        lst.Add("TongLuongLamThem"); //theo câu select
        lst.Add("TienPhuCapDocHai");
        lst.Add("TienPhuCapTrachNhiem");
        lst.Add("TienPhuCapHienVat"); //theo câu select
        lst.Add("TienPhuCapBoiDuong");
        lst.Add("QuyTienLuong");
        lst.Add("TongTienNgoaiGio"); //theo câu select
        lst.Add("PCK");
        lst.Add("TienBHXH");
        lst.Add("TienBHYT"); //theo câu select
        lst.Add("TienBHTN");
        lst.Add("ThueTNCN");
        lst.Add("ThucNhan");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("idnhanvien"); //theo câu select
        lst.Add("manhanvien");
        //lst.Add("tenphongban");        
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("tenphongban");        
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
        lst.Add(GetCellIndex("D12"));
        lst.Add(GetCellIndex("D13"));
        lst.Add(GetCellIndex("D14"));
        return lst;
    }
     
}

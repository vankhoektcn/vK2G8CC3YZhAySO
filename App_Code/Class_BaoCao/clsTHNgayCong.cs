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
public class clsTHNgayCong:ExportToExcel.Profess_ExportToExcelByCode
{
    public  string thang = "";
    public  string nam = "";
    public string phongban = "";
    public clsTHNgayCong()
    {

    }
    public clsTHNgayCong(string thang,string nam,string phongban)
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
        string select=""
         + " select STT=row_number() over (order by abc.tennhanvien), abc.* from" + "\r\n"
                  + "   (" + "\r\n"
                  + "   select DISTINCT " + "\r\n"
                  + "                    tennhanvien" + "\r\n"
                  + "   ,NgayThuong=(select count(ngaythuong) from bangchamcongtheongay where idnhanvien=nv.idnhanvien and ngaythuong=1 and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")" + "\r\n"
                  + "   ,NgayTruc=(select count(ngaytruc) from bangchamcongtheongay where ngaytruc=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")" + "\r\n"
                  + "   ,SoNgayPK=[dbo].[GetSoNgayNhanVienPhepKhongLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
                  + "   ,SoNgayPC=[dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
                   + "   ,NgayNuaBuoi=(select count(LamThemNuaNgay) from bangchamcongtheongay where LamThemNuaNgay=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + " )" + "\r\n"
                  + "   ,LamThemMotNgay=(select count(LamThemMotNgay) from bangchamcongtheongay where LamThemMotNgay=1 and idnhanvien=nv.idnhanvien)  " + "\r\n"
                  + "   ,NghiOm=(select count(NghiOm) from bangchamcongtheongay where NghiOm=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")  " + "\r\n"
                  + "   ,NghiBu=(select count(NghiBu) from bangchamcongtheongay where NghiBu=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")  " + "\r\n"
                  + "   ,NghiLe=(select count(NghiLe) from bangchamcongtheongay where NghiLe=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")  " + "\r\n"
                  + "   ,NgoaiGio=[dbo].[NS_SoGioLamNgoaiGio] (nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
                   + "   ,PhepNam=12  - [dbo].[GetSoNgayNhanVienPhepKhongLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
                  + "  ,nv.idnhanvien,manhanvien" + "\r\n"
                  + "     from NhanVien NV left join bangchamcongtheongay c on c.idnhanvien=nv.idnhanvien " + "\r\n"
                  + "   inner join hopdong hd on hd.idnhanvien=nv.idnhanvien" + "\r\n"
                  + "   inner join phongban pb on nv.idphongban=pb.idphongban" + "\r\n"
                  + "   where hd.status=1 and nv.status=1 and Month(c.ngaycong)=" + thang.ToString() + " and year(c.ngaycong)=" + nam.ToString() + "" + "\r\n"
                  + "   "+idphong+"" + "\r\n"
                  + "   ) abc" + "\r\n"
                  + " " + "\r\n";
                
        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }

    protected override string SetInputFileName() // bắt buộc
    {
        return "THNgayCong.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "THNgayCong.xls";//TÊN FILE XUẤT RA
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
        //lst.Add("cot 1"); //theo câu select
        //lst.Add("cot 2");
        //lst.Add("cot 3");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("idnhanvien"); //theo câu select
        lst.Add("manhanvien");
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
        lst.Add(GetCellIndex("D12"));
        lst.Add(GetCellIndex("D13"));
        lst.Add(GetCellIndex("D14"));
        return lst;
    }
     
}

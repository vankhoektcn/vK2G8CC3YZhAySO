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
public class clsTHBNPhauThuat:ExportToExcel.Profess_ExportToExcelByCode
{
    public  string tungay = "";
    public  string denngay = "";
    public string phongban = "";
    public clsTHBNPhauThuat()
    {

    }
    public clsTHBNPhauThuat(string tungay, string denngay, string phongban)
    {
        this.tungay = tungay;
        this.denngay = denngay;
        this.phongban = phongban;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        string idphong="";
        if (!string.IsNullOrEmpty(phongban) && phongban != "0")
        {
            idphong = "   and a.idphongphauthuat='" + phongban+"'";
        }
        string select = ""
                        + " select " + "\r\n"
                        + " STT=row_number() over ( order by abc.sovaovien),*" + "\r\n"
                        + " from(" + "\r\n"
                        + " select distinct " + "\r\n"
                        + " So=''" + "\r\n"
                        + " ,Ngay=''" + "\r\n"
                        + " ,NgayPhauThuat=convert(nvarchar(10),ngayphauthuat,103)" + "\r\n"
                        + " ,SoVaoVien=a.sovaovien" + "\r\n"
                        + " ,TenBenhNhan=b.tenbenhnhan" + "\r\n"
                        + " ,TenPhauThuat=e.tendichvu" + "\r\n"
                        + " ,EkipMo=(select [dbo].[NS_ChuoiEkip] (a.idcaphauthuat,1))" + "\r\n"
                        + " ,KTV=(select [dbo].[NS_ChuoiEkip] (a.idcaphauthuat,2))" + "\r\n"
                        + " ,DieuDuong=(select [dbo].[NS_ChuoiEkip] (a.idcaphauthuat,3))" + "\r\n"
                        + "  from caphauthuat a" + "\r\n"
                        + " left join benhnhan b on b.idbenhnhan=a.idbenhnhan" + "\r\n"
                        + " left join clsphauthuat c on c.idcaphauthuat=a.idcaphauthuat" + "\r\n"
                        + " left join chitietclsgoiphauthuat d on d.idchitietclsphauthuat=c.idchitietclsphauthuat" + "\r\n"
                        + " left join banggiadichvu e on e.idbanggiadichvu=d.idcanlamsang" + "\r\n"
                        + " left join bsphauthuat f on f.idcaphauthuat=a.idcaphauthuat" + "\r\n"
                        + " left join nhanvien g on g.idnhanvien=f.idnhanvien" + "\r\n"
                        + " where a.ngayphauthuat>='"+StaticData.CheckDate(tungay)+" 00:00:00' and a.ngayphauthuat<='"+StaticData.CheckDate(denngay)+" 23:59:59'  "+idphong + "\r\n"
                        + " )abc" + "\r\n";
                
        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }

    protected override string SetInputFileName() // bắt buộc
    {
        return "THBNPT.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "THBNPT.xls";//TÊN FILE XUẤT RA
    }
    protected override string SetHeaderText()
    {
        return "Từ ngày : "+ tungay+" Đến ngày : "+denngay;// TÊN REPORT
    }
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("G3");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
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

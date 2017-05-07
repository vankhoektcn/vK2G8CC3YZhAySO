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
public class clsDanhSachSBangGiaDichVu:ExportToExcel.Profess_ExportToExcelByCode
{
    public  string tennhom = "";
    public  string phongkham = "";
    public string tendichvu = "";
    public string loaikhoa = "";
    public string mota = "";
    public string giadichvu = "";
    public string madichvu = "";
    public string loaicls = "";
    public string batbuocthu = "";
    public clsDanhSachSBangGiaDichVu()
    {

    }
    public clsDanhSachSBangGiaDichVu(string tennhom, string phongkham, string tendichvu, string loaikhoa, string mota, string giadichvu, string madichvu, string loaicls, string batbuocthu)
    {
        this.tennhom = tennhom;
        this.phongkham = phongkham;
        this.tendichvu = tendichvu;
        this.loaikhoa = loaikhoa;
        this.mota = mota;
        this.giadichvu=giadichvu;
        this.madichvu=madichvu;
        this.loaicls=loaicls;
        this.batbuocthu=batbuocthu;
    }
    public override DataTable getViewTable() // bắt buộc
    {

        string skq = "";
        if (tennhom != "")
        {
            skq += "AND bg.tennhom like  N'%" + tennhom+ "%'";
        }
        if (phongkham != "" && phongkham != "0" )
        {
            skq += " AND bg.idphongkhambenh =' " + phongkham +"'";
        }
        if (tendichvu != "")
        {
            skq += " AND tendichvu LIKE N'%" + tendichvu + "%' ";
        }
        if (loaikhoa!="")
        {
            if (loaikhoa == "1")
                skq += " AND pk.loaiphong=0";
            else skq += " AND pk.loaiphong=1";
        }
        if (mota != "")
        {
            skq += " AND mota LIKE N'%" + mota + "%' ";
        }
        if (giadichvu != "0" && giadichvu != "")
        {
            skq += " AND giadichvu = " + giadichvu;
        }
        if (madichvu != "")
        {
            skq += " AND madichvu = '" + madichvu+ "'";
        }
        if (loaicls !="")
        {
            skq += " AND LOAI.IDLOAICLS='" + loaicls+"'";
        }
        if (batbuocthu !="")
        {
            skq += " AND isbatbuocthu ="+batbuocthu;
        }


        string sql = ""
                    + " SELECT tenphongkhambenh,bg.TenNhom,bg.madichvu,bg.tendichvu,bg.giadichvu,bg.GiaBH,bg.bhtra,bg.phuthubh," + "\r\n"
                    + " case when bg.issudungchobh=0 then N'Không' else N'Có' end as issudungchobh, " + "\r\n"
                    + " case when bg.isbatbuocthu=0 then N'Không' else N'Bắt buộc' end as isbatbuoc " + "\r\n"
                    + "  FROM banggiadichvu bg INNER JOIN phongkhambenh pk ON bg.idphongkhambenh = pk.idphongkhambenh " + "\r\n"
                    + "  left JOIN LOAICANLAMSANG LOAI ON LOAI.IDLOAICLS=BG.IDLOAICLS " + "\r\n"
                    + "  WHERE 1=1 AND daxoa = 0 " + skq+"\r\n"
                    + "  ORDER BY bg.idphongkhambenh,tennhom, tendichvu  ASC" + "\r\n";
        DataTable dtDoanThu = DataAcess.Connect.GetTable(sql);
        return dtDoanThu;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        return "BangGiaDichVu.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "BangGiaDichVu.xls";//TÊN FILE XUẤT RA
    }
    protected override string SetHeaderText()
    {
        return "Áp dụng từ ngày : " + DateTime.Now.ToString("dd/MM/yyyy") ;
    }
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("D4");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("giadichvu"); //theo câu select
        //lst.Add("TienKham");
        //lst.Add("TienCLS");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        //lst.Add("ngaykham"); //theo câu select
        //lst.Add("idbenhnhan");
        //lst.Add("LoaiPhi");
        //lst.Add("tendichvu");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("tenphongkhambenh");
        lst.Add("TenNhom");
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

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
public class clsDoanhThuNguoiDung:ExportToExcel.Profess_ExportToExcelByCode
{
    public  string tungay = "";
    public  string denngay = "";
    public string nguoidung = "";
    public string tennguoidung = "";
    public clsDoanhThuNguoiDung()
    {

    }
    public clsDoanhThuNguoiDung(string tungay,string denngay,string nguoidung,string tennguoidung)
    {
        this.tungay = tungay;
        this.denngay = denngay;
        this.nguoidung=nguoidung;

    }
    public override DataTable getViewTable() // bắt buộc
    {

        string sWhere1 = "";
        string sWhere2 = "";
        string sWhere3 = "";

        if (!string.IsNullOrEmpty(tungay))
        {
            sWhere1 += " AND DKK.NGAYDANGKY>='" + tungay + "'";
            sWhere2 += " AND A.NGAYTHU>='" + tungay + "'";
        }
        if (!string.IsNullOrEmpty(denngay))
        {
            sWhere1 += " AND DKK.NGAYDANGKY<='" + denngay + " 23:59:59'";
            sWhere2 += " AND A.NGAYTHU<='" + denngay + " 23:59:59'";
        }

        if (!string.IsNullOrEmpty(nguoidung) && nguoidung != "0")
        {
            sWhere1 += " AND DKK.IDNGUOITHU=" + nguoidung;
            sWhere2 += " AND A.IDNGUOITHU=" + nguoidung;
            sWhere3 += " AND A1.IDNGUOITHU=" + nguoidung;
        }

        string  sql = @" 
SELECT ROW_NUMBER() OVER ( ORDER BY MAPHIEUDANGKY, TENBENHNHAN ) AS STT ,
                                    MAPHIEUDANGKY,TENBENHNHAN,TIENSO,TIENKHAM,TIENCLS,TAMUNG,HOANUNG,THANHTOANRAVIEN
,THUTIENXE,NGAYKHAM= NGAYKHAM,TENDICHVU
                                    FROM   (
(
 SELECT 
 MAPHIEUDANGKY
 ,C.TENBENHNHAN
 ,TIENSO=(SELECT TOP 1 dongia*soluong *((100.0-giamgia)/100) FROM chitietdangkykham A1 LEFT JOIN banggiadichvu B1 ON A1.idbanggiadichvu=B1.idbanggiadichvu WHERE A1.iddangkykham=B.iddangkykham AND A1.idbanggiadichvu=628)
 ,TIENKHAM=(SELECT TOP 1 dongia*soluong *((100.0-giamgia)/100) FROM chitietdangkykham A1 LEFT JOIN banggiadichvu B1 ON A1.idbanggiadichvu=B1.idbanggiadichvu WHERE A1.iddangkykham=B.iddangkykham AND A1.idbanggiadichvu<>628)
 ,TIENCLS=0
 ,TAMUNG=0
 ,HOANUNG=0
 ,THANHTOANRAVIEN=0
 ,THUTIENXE=0
 ,NGAYKHAM= B.NGAYDANGKY
 ,TENDICHVU=(SELECT TOP 1 tendichvu FROM chitietdangkykham A1 LEFT JOIN banggiadichvu B1 ON A1.idbanggiadichvu=B1.idbanggiadichvu WHERE A1.iddangkykham=B.iddangkykham AND A1.idbanggiadichvu<>628)
 --,LOAIPHI=1
 --,NGUOITHU= E.tennguoidung
 FROM   dangkykham B 
 LEFT JOIN benhnhan C ON B.idbenhnhan=C.idbenhnhan
 LEFT JOIN nguoidung E ON B.IdNguoiThu=E.idnguoidung
 WHERE		isnull(B.dathu,0)=1
 			AND isnull(B.dahuy,0)=0
 			AND isnull(B.maphieudangky,'')<>''";
        sql += " 			AND B.ngaydangky>='" + tungay + "' " + "\r\n";
        sql += " 			AND B.ngaydangky<='" + denngay + " 23:59:59'" + "\r\n";
        sql += (nguoidung != "" && nguoidung != "0" ? " AND B.IdNguoiThu=" + nguoidung + " " : "");

        sql += @"      )
 
 UNION
 (
 SELECT DISTINCT 
 MAPHIEUDANGKY=maphieuCLS  
 ,C.tenbenhnhan
 ,TIENSO=0
 ,TIENKHAM=0
 ,TIENCLS=  sum(ISNULL(B.SOLUONG,1)* dbo.KB_GETSOTIEN_BNTra(B.idcanlamsan,C.idbenhnhan)) 
 ,TAMUNG=0
 ,HOANUNG=0
 ,THANHTOANRAVIEN=0
 ,THUTIENXE=0

 ,NGAYKHAM= B.ngaythu
 ,TENDICHVU='' 
 --,LOAIPHI=2
 --,NGUOITHU= E.tennguoidung
 
 FROM   khambenhcanlamsan B 
 LEFT JOIN benhnhan C ON dbo.KB_GetIdBenhNhan(B.IDKHAMBENHCANLAMSAN)=C.idbenhnhan
 LEFT JOIN nguoidung E ON B.IdNguoiThu=E.idnguoidung
 LEFT JOIN banggiadichvu F ON B.idcanlamsan=F.idbanggiadichvu
 LEFT JOIN phongkhambenh G ON F.idphongkhambenh=G.idphongkhambenh
 WHERE		isnull(B.dathu,0)=1
 			AND isnull(B.dahuy,0)=0
 			AND isnull(B.maphieuCLS,'')<>''";
        sql += " 			AND B.ngaythu>='" + tungay + "' " + "\r\n";
        sql += " 			AND B.ngaythu<='" + denngay + " 23:59:59'" + "\r\n";
        sql += (nguoidung != "" && nguoidung != "0" ? " AND B.IdNguoiThu=" + nguoidung + " " : "");

        sql += @"GROUP BY  C.IDBENHNHAN
 ,C.tenbenhnhan
 ,B.ngaythu
 ,maphieuCLS
 ,E.tennguoidung

) ) as abcs

";

        DataTable dtDoanThu = DataAcess.Connect.GetTable(sql);
        return dtDoanThu;
    }
    private string Nguoithuphi()
    {
        string tennguoidung = "";
        string sqlNguoiDung="select * from nguoidung where idnguoidung="+nguoidung;
        DataTable dtNguoiDung=DataAcess.Connect.GetTable(sqlNguoiDung);
        if (dtNguoiDung !=null && dtNguoiDung.Rows.Count>0)
        {
            tennguoidung = dtNguoiDung.Rows[0]["tennguoidung"].ToString();
        }
        return tennguoidung;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        return "DTNguoiDung.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "DTNguoiDung.xls";//TÊN FILE XUẤT RA
    }
    protected override string SetHeaderText()
    {
        string ngay=StaticData.TimeDescription(tungay, denngay);
        string tennguoithuphi = Nguoithuphi();
        return "Người thu phí:"+tennguoithuphi+" - "+ngay;
    }
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("A4");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("TIENSO"); //theo câu select
        lst.Add("TIENKHAM");
        lst.Add("TIENCLS");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("NGAYKHAM"); //theo câu select
        lst.Add("TENDICHVU");
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

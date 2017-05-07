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
public class clsBangKeBienLai:ExportToExcel.Profess_ExportToExcelByCode
{
    public string iddangkykham = "";
    public clsBangKeBienLai()
    {

    }
    public clsBangKeBienLai(string iddangkykham)
    {
        this.iddangkykham = iddangkykham;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        DataTable dt = null;
        string sql="";
        if (!string.IsNullOrEmpty(iddangkykham))
        {
            sql = string.Format(@"

                SELECT 
                ROW_NUMBER() OVER  (ORDER BY SOBIENLAI) AS STT, 
                NGAYTHANG,
                KYHIEU,
                QUYENSO,
                SOBIENLAI,
                NOIDUNGTHU,
                SOTIEN
                FROM (
		                (
				                SELECT convert(varchar(10),A.NGAYDANGKY, 103) AS NGAYTHANG,KYHIEU='',QUYENSO='',A.MAPHIEUDANGKY AS SOBIENLAI,B.NOIDUNG AS NOIDUNGTHU,
				                (SELECT ISNULL( SUM(DONGIA),0) FROM CHITIETDANGKYKHAM WHERE IDDANGKYKHAM=21568) AS SOTIEN
				                FROM DANGKYKHAM A
				                LEFT JOIN SOCHUNGTU B ON B.SOPHIEUCT=A.MAPHIEUDANGKY
				                WHERE A.IDDANGKYKHAM={0}
		                )
                UNION ALL
		                (
				                SELECT convert(varchar(10),A.NGAYTHU, 103) AS NGAYTHANG,KYHIEU='',QUYENSO='',A.MAPHIEUCLS AS SOBIENLAI,B.NOIDUNG AS NOIDUNGTHU,
				                 ISNULL( SUM(A.DONGIA),0)  AS SOTIEN
				                FROM KHAMBENHCANLAMSAN A
				                LEFT JOIN SOCHUNGTU B ON B.SOPHIEUCT=A.MAPHIEUCLS
				                LEFT JOIN KHAMBENH C ON C.IDKHAMBENH=A.IDKHAMBENH
				                WHERE C.IDDANGKYKHAM={0} GROUP BY A.NGAYTHU,A.MAPHIEUCLS,B.NOIDUNG
		                )
                UNION ALL
		                (
				                SELECT convert(varchar(10),A.NGAYTAMUNG, 103) AS NGAYTHANG,KYHIEU='',QUYENSO='',B.SOPHIEUCT AS SOBIENLAI,N'Thu tạm ứng' AS NOIDUNGTHU,
				                ISNULL( SUM(A.SOTIEN),0)  AS SOTIEN
				                FROM TAMUNG A
				                LEFT JOIN SOCHUNGTU B ON B.STT=A.SOCTTU
				                WHERE A.IDDANGKYKHAM={0} GROUP BY A.NGAYTAMUNG,B.SOPHIEUCT,B.NOIDUNG
		                )
                )ABC
                ", iddangkykham);
            dt = DataAcess.Connect.GetTable(sql);
        }
        return dt;
    }

    protected override string SetInputFileName() // bắt buộc
    {
        return "BangKeBienLai.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "BangKeBienLai.xls";//TÊN FILE XUẤT RA
    }
    protected override string SetHeaderText()
    {
        string sql = string.Format(@"select bn.idbenhnhan,bn.tenbenhnhan,dbo.kb_GetTuoi(bn.NGAYSINH) as NamSinh,bn.DiaChi
                                     from benhnhan bn left join dangkykham dkk on bn.idbenhnhan=dkk.idbenhnhan
                                    where dkk.iddangkykham={0}
                                    ",iddangkykham);
        DataTable dtBN = DataAcess.Connect.GetTable(sql);
        if (dtBN == null) return "";
        return ""
                + "Tên bệnh nhân:" + dtBN.Rows[0]["TenBenhnhan"].ToString() + "\t     Tuổi:" + dtBN.Rows[0]["NamSinh"] + "" + "\r\n"
                + "Địa chỉ:" + dtBN.Rows[0]["DiaChi"].ToString() + "" + "\r\n";
        //return "Tên bệnh nhân:" + dtBN.Rows[0]["TenBenhnhan"].ToString() + " Tuổi:" + dtBN.Rows[0]["NamSinh"] + "   Địa chỉ:" + dtBN.Rows[0]["DiaChi"].ToString() + "";// TÊN REPORT
    }
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("A6");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A9");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("SOTIEN");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        //lst.Add("TenKhachHang");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
       // lst.Add("TenKhachHang");        
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

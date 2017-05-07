
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
public class clsDoanhThuNguoiDung_1807 : ExportToExcel.Profess_ExportToExcelByCode
{
    public string tungay = "";
    public string denngay = "";
    public string nguoidung = "";
    public string tennguoidung = "";

    public clsDoanhThuNguoiDung_1807()
    {

    }
    public clsDoanhThuNguoiDung_1807(string tungay, string denngay, string nguoidung, string tennguoidung)
    {
        this.tungay = tungay;
        this.denngay = denngay;
        this.nguoidung = nguoidung;
        this.tennguoidung = tennguoidung;

    }
    public string GetSQL()
    {
        string sqlSelect = @" IF EXISTS ( SELECT NAME FROM SYSOBJECTS WHERE NAME LIKE 'ZZZ' ) DROP TABLE ZZZ 
                                SELECT DISTINCT MAPHIEU AS MAPHIEUDANGKY,LOAITHU=(CASE WHEN NLOAITHU=1 AND TENDICHVU=N'Sổ khám bệnh' THEN 'TIENSO' ELSE ( CASE WHEN NLOAITHU=1 THEN 'TIENKHAM' ELSE  (CASE WHEN NLOAITHU=3 THEN 'TIENTHUOC' ELSE  LOAITHU END) END  ) END)
		                                ,hoanung=''
		                                ,hoantra=isnull(t.ishoantra,0)
                                        ,Thanhtoanravien=( CASE WHEN NLOAITHU=6 THEN 1 ELSE 0 END )
		                                ,thutienxe =''
                                        ,tennguoithu
		                                ,SysDate AS NGAYKHAM
		                                ,mabenhnhan
                                        ,idbenhnhan
                                        ,tenbenhnhan
                                        ,NguoiNhanTra
                                ,SUM(TONGTIEN) AS SOTIEN
                                INTO ZZZ
                                FROM HS_DSDATHU T
                                WHERE ISNULL(ISDAHUY,0)=0"
                                  + (this.tungay != null && this.tungay != "" ? "and ( SYSDATE >='" + this.tungay + @"' OR ngayhoantra >='" + this.tungay + @"')" : "")
                                  + (this.denngay != null && this.denngay != "" ? "and ( SYSDATE <='" + this.denngay + @" 23:59:59' OR ngayhoantra <='" + this.denngay + @" 23:59:59')" : "")
                                   + (this.nguoidung != null && this.nguoidung != "" && this.nguoidung != "0" ? "and ( tennguoithu =N'" + this.tennguoidung + @"' OR NguoiNhanTra =N'" + this.tennguoidung + @"')" : "") + @"
                                GROUP BY MAPHIEU,tennguoithu,NguoiNhanTra
		                                ,SysDate
		                                ,mabenhnhan
                                        ,tenbenhnhan
                                        ,idbenhnhan,
                                        isnull(t.ishoantra,0)
		                                ,(CASE WHEN NLOAITHU=1 AND TENDICHVU=N'Sổ khám bệnh' THEN 'TIENSO' ELSE ( CASE WHEN NLOAITHU=1 THEN 'TIENKHAM' ELSE  (CASE WHEN NLOAITHU=3 THEN 'TIENTHUOC' ELSE  LOAITHU END) END  ) END)
                                        ,NLOAITHU
                            SELECT DISTINCT  
                            MAPHIEUDANGKY
	                         ,MABENHNHAN
                            ,TENBENHNHAN
                            ,TIENSO=(SELECT SUM(SOTIEN) FROM ZZZ WHERE LOAITHU='TIENSO' AND MAPHIEUDANGKY=T.MAPHIEUDANGKY   " + (this.nguoidung != null && this.nguoidung != "" && this.nguoidung != "0" ? " AND tennguoithu=N'" + this.tennguoidung + "'" : "") + @") 
                            ,TIENKHAM=(SELECT SUM(SOTIEN) FROM ZZZ WHERE LOAITHU='TIENKHAM'  AND MAPHIEUDANGKY=T.MAPHIEUDANGKY  " + (this.nguoidung != null && this.nguoidung != "" && this.nguoidung != "0" ? " AND tennguoithu=N'" + this.tennguoidung + "'" : "") + @") 
                            ,TIENCLS=(SELECT SUM(SOTIEN) FROM ZZZ WHERE (LOAITHU='DichVuCLSTUDEN'  AND MAPHIEUDANGKY=T.MAPHIEUDANGKY) OR (LOAITHU='DichVuCLS'  AND MAPHIEUDANGKY=T.MAPHIEUDANGKY) OR (LOAITHU='DVKTKHACTUDEN'  AND MAPHIEUDANGKY=T.MAPHIEUDANGKY  " + (this.nguoidung != null && this.nguoidung != "" && this.nguoidung != "0" ? " AND tennguoithu=N'" + this.tennguoidung + "'" : "") + @")) 
                            ,TIENDVKT=(SELECT SUM(SOTIEN) FROM ZZZ WHERE LOAITHU='DVKTKHAC'  AND MAPHIEUDANGKY=T.MAPHIEUDANGKY " + (this.nguoidung != null && this.nguoidung != "" && this.nguoidung != "0" ? " AND tennguoithu=N'" + this.tennguoidung + "'" : "") + @") 
                            ,TIENTHUOC=(SELECT SUM(SOTIEN) FROM ZZZ WHERE LOAITHU='TIENTHUOC'  AND MAPHIEUDANGKY=T.MAPHIEUDANGKY AND ISNULL( HOANTRA,0)<>1" + (this.nguoidung != null && this.nguoidung != "" && this.nguoidung != "0" ? " AND tennguoithu=N'" + this.tennguoidung + "'" : "") + @") 
                            ,tamung=(SELECT SUM(SOTIEN) FROM ZZZ WHERE LOAITHU='tamung'  AND MAPHIEUDANGKY=T.MAPHIEUDANGKY AND ISNULL( HOANTRA,0)<>1" + (this.nguoidung != null && this.nguoidung != "" && this.nguoidung != "0" ? " AND tennguoithu=N'" + this.tennguoidung + "'" : "") + @") 
                            ,hoanung
                            ,hoantra=(SELECT SUM(SOTIEN) FROM ZZZ WHERE ISNULL( HOANTRA,0)=1 AND MAPHIEUDANGKY=T.MAPHIEUDANGKY " + (this.nguoidung != null && this.nguoidung != "" && this.nguoidung != "0" ? " AND NGUOINHANTRA=N'" + this.tennguoidung + "'" : "") + @") 
                            ,Thanhtoanravien=(SELECT SUM(SOTIEN) FROM ZZZ WHERE LOAITHU='VIENPHINOITRU'  AND MAPHIEUDANGKY=T.MAPHIEUDANGKY AND ISNULL( THANHTOANRAVIEN,0)=1" + (this.nguoidung != null && this.nguoidung != "" && this.nguoidung != "0" ? " AND tennguoithu=N'" + this.tennguoidung + "'" : "") + @") 
                            ,thutienxe
                            ,tennguoithu
                            ,NGAYKHAM
                            ,idbenhnhan
                            FROM ZZZ T  
                            ";
        return sqlSelect;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        string sql = this.GetSQL();
        DataTable dtDoanhThu = DataAcess.Connect.GetTable(sql);
        if (dtDoanhThu != null)
        {
            dtDoanhThu.Columns.Add("IsView",dtDoanhThu.Rows.Count.GetType());
            if (dtDoanhThu.Columns.IndexOf("STT") == -1)
            {
                dtDoanhThu.Columns.Add("STT");
                dtDoanhThu.Columns["STT"].SetOrdinal(0);
            }

            for (int i = 0; i < dtDoanhThu.Rows.Count; i++)
            {
                if ((dtDoanhThu.Rows[i]["TIENSO"].ToString() != "" && dtDoanhThu.Rows[i]["TIENSO"].ToString() != "0") ||
                   (dtDoanhThu.Rows[i]["TIENKHAM"].ToString() != "" && dtDoanhThu.Rows[i]["TIENKHAM"].ToString() != "0") ||
                   (dtDoanhThu.Rows[i]["TIENCLS"].ToString() != "" && dtDoanhThu.Rows[i]["TIENCLS"].ToString() != "0") ||
                   (dtDoanhThu.Rows[i]["TIENDVKT"].ToString() != "" && dtDoanhThu.Rows[i]["TIENDVKT"].ToString() != "0") ||
                   (dtDoanhThu.Rows[i]["TIENTHUOC"].ToString() != "" && dtDoanhThu.Rows[i]["TIENTHUOC"].ToString() != "0") ||
                   (dtDoanhThu.Rows[i]["tamung"].ToString() != "" && dtDoanhThu.Rows[i]["tamung"].ToString() != "0") ||
                   (dtDoanhThu.Rows[i]["THANHTOANRAVIEN"].ToString() != "" && dtDoanhThu.Rows[i]["THANHTOANRAVIEN"].ToString() != "0") ||
                   (dtDoanhThu.Rows[i]["hoantra"].ToString() != "" && dtDoanhThu.Rows[i]["hoantra"].ToString() != "0")
                 )
                {
                    dtDoanhThu.Rows[i]["IsView"] = "1";
                    dtDoanhThu.Rows[i]["STT"] = i + 1;
                }
            }
            dtDoanhThu.DefaultView.RowFilter = "IsView=1";
            dtDoanhThu = dtDoanhThu.DefaultView.ToTable();
            dtDoanhThu.Columns.Remove("IsView");
        }
        return dtDoanhThu;
    }
    private string Nguoithuphi()
    {
        string tennguoidung = "";
        string sqlNguoiDung = "select * from nguoidung where idnguoidung='" + nguoidung + "'";
        DataTable dtNguoiDung = DataAcess.Connect.GetTable(sqlNguoiDung);
        if (dtNguoiDung != null && dtNguoiDung.Rows.Count > 0)
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
        string ngay = StaticData.TimeDescription(tungay, denngay);
        string tennguoithuphi = Nguoithuphi();
        return "Người thu phí:" + tennguoithuphi + " - " + ngay;
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
        lst.Add("TIENDVKT");
        lst.Add("TIENTHUOC");
        lst.Add("TAMUNG");
        lst.Add("HOANTRA");
        lst.Add("HOANUNG");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("NGAYKHAM"); //theo câu select
        lst.Add("tennguoithu");
        lst.Add("idbenhnhan");
        lst.Add("thanhtoanravien");
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

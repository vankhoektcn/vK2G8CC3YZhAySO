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
/// 
/// </summary>
public class clsBaCaoSuDung:ExportToExcel.Profess_ExportToExcelByCode
{
    public  string tungay = "";
    public  string denngay = "";
    public string idkhoa = "";
    public string idloai = ""; //loai thuoc , hoa chat , hay vat tu y te?
    public string ngayBD = "";
    public string thangBD = "";
    public string namBD = "";
    public clsBaCaoSuDung()
    {

    }
    public clsBaCaoSuDung(string tungay,string denngay,string idkhoa,string ngayBD,string thangBD,string namBD)
    {
        this.tungay = tungay;
        this.denngay = denngay;
        this.idkhoa=idkhoa;
        this.ngayBD = ngayBD;
        this.thangBD = thangBD;
        this.namBD = namBD;
    }
    private string DatetimeToString126(DateTime date)
    {
        string ngay = date.Day.ToString();
        if (ngay.Length < 2)
            ngay = "0" + ngay;
        string thang = date.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = date.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        return nam + "/" + thang + "/" + ngay;
    }
    private string DatetimeToString103_10(DateTime date)
    {
        string ngay = date.Day.ToString();
        if (ngay.Length < 2)
            ngay = "0" + ngay;
        string thang = date.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = date.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        return ngay + "/" + thang;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        DateTime DayBD = DateTime.Parse(this.tungay);
        DateTime DayKT = DateTime.Parse(this.denngay);
        int songay = DayKT.Day - DayBD.Day + 1;
        DateTime DayFor = DayBD;
        string NVK_SQL = @"
    select --ca.cateid,CateName,idthuoc,
    tenthuoc,donvitinh=dvt.tenDVT ";

        for (int i = 1; i <= songay ; i++)
        {
            string NgayInFor = this.DatetimeToString126(DayFor);
            NVK_SQL += @"
                ,HC=dbo.NVK_Thuoc15_HC(" + this.idkhoa + @",t.idthuoc,'" + NgayInFor + @"')
                ,BS=dbo.NVK_Thuoc15_BS(" + this.idkhoa + @",t.idthuoc,'" + NgayInFor + @"')
                ,T=dbo.NVK_Thuoc15_T(" + this.idkhoa + @",t.idthuoc,'" + NgayInFor + @"')
                ";
            DayFor = DayFor.AddDays(1);
        }

        NVK_SQL += @"--,nhomthuoc=CateName
from thuoc t left join category ca on t.cateid=ca.cateid 
    left join thuoc_donvitinh dvt on dvt.id=t.iddvt
    where 1=1 ";
        if (!this.idloai.Equals("") && !this.idloai.Equals("0"))
            NVK_SQL += @" and t.loaithuocid=" + this.idloai + @"";
        NVK_SQL += @" and idthuoc in
    (
     select  idthuoc from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh
     where kb.maphieukham <> 'pkxk' and kb.idphongkhambenh =" + this.idkhoa + "  and (   (kb.ngaykham>='" + this.tungay + @"' and kb.ngaykham<='" + this.denngay + @" 23:59:58:999' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
				    or ( ngayDuTruThuoc>='" + this.tungay + @"' and  ngayDuTruThuoc<='" + this.denngay + @" 23:58:59:999' )
			    )
     )";


        DataTable dtDoanThu = DataAcess.Connect.GetTable(NVK_SQL);
        return dtDoanThu;
    }
    private string loaiExcel()
    {
        return "BCSuDungThuoc.xls";
    }
    protected override string SetInputFileName() // bắt buộc
    {
        string filename = loaiExcel();
        return filename;//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        return "BCSuDungThuoc.xls"; 
    }
    protected override string SetHeaderText()
    {
        string ngay = "";// StaticData.TimeDescription(tungay, denngay);
        return  ngay;
    }
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("A4");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
     
     
     


    string[] arrIndexLoai = new string[] { "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        ,"AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX","AY","AZ"
        ,"BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX","BY","BZ"
        ,"CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX","CY","CZ"
    };
    string[] arrIndeHeader = new string[] {
        "C", "F", "I", "L", "O", "R", "U", "X"
        , "AA", "AD", "AG", "AJ", "AM", "AP", "AS","AV","AY"
        , "BA", "BD", "BG", "BJ", "BM", "BP", "BS","BV","BY"
        , "CA", "CD", "CG", "CJ", "CM", "CP", "CS","CV","CY"
    };

    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        string tenkhoa = "";
        string TieuDeBaoCao = "";
        try
        {
            tenkhoa = DataAcess.Connect.GetTable("select tenphongkhambenh from phongkhambenh where idphongkhambenh=" + this.idkhoa).Rows[0]["tenphongkhambenh"].ToString();
            string TenLoaiThuoc = "";
            string KhoangNgay = "";
            if (this.idloai.Equals("0") || this.idloai.Equals(""))
            {
            }
            else
                TenLoaiThuoc = DataAcess.Connect.GetTable("select tenloai from thuoc_loaithuoc where loaithuocid=" + this.idloai).Rows[0][0].ToString();
            KhoangNgay = "TỪ " + DateTime.Parse(this.tungay).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(this.denngay).ToString("dd/MM/yyyy");
            TieuDeBaoCao = "BÁO CÁO SỬ DỤNG " + TenLoaiThuoc.ToUpper() + " 15 NGÀY (" + KhoangNgay + ")";
        }
        catch (Exception ex)
        {
        }

        lst.Add("Khoa :" + tenkhoa);
        lst.Add(TieuDeBaoCao);

        #region Tiêu đề các cột nội dung báo cáo
        DateTime DayBD = DateTime.Parse(this.tungay);
        DateTime DayKT = DateTime.Parse(this.denngay);
        int songay = DayKT.Day - DayBD.Day + 1;
        DateTime DayFor = DayBD;
        string NVK_SQLCot = @"";

        for (int i = 1; i < songay; i++)
        {
            string NgayInFor = this.DatetimeToString103_10(DayFor);
            NVK_SQLCot += @" select ngay='" + NgayInFor + @"' 
            union all
            ";
            DayFor = DayFor.AddDays(1);
        }
        NVK_SQLCot += @" select ngay='" + this.DatetimeToString103_10(DayFor) + @"'";
        DataTable dtCotNgay = DataAcess.Connect.GetTable(NVK_SQLCot);
        for (int i = 0; i < dtCotNgay.Rows.Count; i++)
        {
            lst.Add(dtCotNgay.Rows[i]["ngay"].ToString());
        }
        int viTri = 1;
        for (int j = 0; j < songay * 3; j++)
        {
            if(viTri==1)
                lst.Add("HC");
            else if(viTri==2)
                lst.Add("BS");
            else if(viTri==3)
                lst.Add("T");
            if (viTri == 3)
                viTri = 1;
            else
                viTri++;
        }
        #endregion
            return lst;
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A2"));
        lst.Add(GetCellIndex("C3"));

        #region Tiêu đề các cột nội dung báo cáo
        DateTime DayBD = DateTime.Parse(this.tungay);
        DateTime DayKT = DateTime.Parse(this.denngay);
        int songay = DayKT.Day - DayBD.Day + 1;
        DateTime DayFor = DayBD;
        string NVK_SQLCot = @"";
        string RowIndex = "5";
        int giatri = 0;
        for (int i = 0; i < songay; i++)
        {
            try
            {
                //lst.Add(GetCellIndex(arrIndeHeader[i] + RowIndex));
                lst.Add(NVK_GetCellIndex(arrIndeHeader[i] + RowIndex));
            }
            catch (Exception ex)
            {
                break;
            }
        }
        for (int j = 0; j < songay * 3; j++)
        {
            lst.Add(NVK_GetCellIndex(arrIndexLoai[j] + "6"));
        }
        #endregion
            return lst;
    }
     
}

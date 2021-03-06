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
/// Summary description for BienBangKiemNhap
/// </summary>
public class profess_Rpt_DanhMucThuoc : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TTHoatChat = null;
    public string TenHoatChat = null;
    public string BietDuoc = null;
    public string TenNhom = null;
    public string CateName = null;
    public string LoaiThuocID = "1";
    public bool IsCoGia = false;
    public bool IsTGN = false;
    public bool IsTHTT = false;

    public profess_Rpt_DanhMucThuoc()
    {
        this.IsDeleteTotalRow = true;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        string select = "";
        if (this.IsCoGia)
        {
            select = @"select distinct STT =ROW_NUMBER() OVER (ORDER BY CATENAME,TENNHOM,TENTHUOC)"
            + (this.LoaiThuocID == "1" ? @"
                                ,TTHoatChat
                                ,hoatchat=CongThuc"
            : "")
            + @" ,BietDuoc=tenthuoc"
            + (this.LoaiThuocID == "1" ? @"
                                ,a.dongia,ngayhethan=isnull( convert(nvarchar(20), a.ngayhethan,103),''),  losanxuat=isnull(a.losanxuat,'')"
               : "")
               + @"
                                ,tenDVT,
                                catename=IsNULL(d.des +'.','') + CateName
                        ,tennhom=Isnull(c.MaNhom +'.','')+ tennhom
                        ,des1=0,manhom1=0
                        ,des,manhom,hide=1
                                from chitietphieunhapkho a
                                left join thuoc b on a.idthuoc=b.idthuoc
                                left join nhomthuoc c on b.idnhomthuoc=c.idnhomthuoc
                                left join category d on b.cateid=d.cateid
                                LEFT JOIN THUOC_DONVITINH E ON B.IDDVT=E.ID
                                where a.idthuoc is not null 
                                  and b.loaithuocid=" + this.LoaiThuocID + "  and b.isthuocbv=1";
        }
        else
        {
            select = @"select distinct TTHoatChat
                        ,STT =ROW_NUMBER() OVER (ORDER BY CATENAME,TENNHOM,"+(LoaiThuocID!="1"?" TENTHUOC" :"CONGTHUC")+")"
          + @" ,BietDuoc=tenthuoc
                        ,tenDVT
                        ,catename=IsNULL(d.des +'.','') + CateName
                        ,tennhom=Isnull(c.MaNhom +'.','')+ tennhom
                        ,des1=null,manhom1=null
                        ,des,manhom,hide=1
                                from thuoc b 
                                left join nhomthuoc c on b.idnhomthuoc=c.idnhomthuoc
                                left join category d on b.cateid=d.cateid
                                LEFT JOIN THUOC_DONVITINH E ON B.IDDVT=E.ID
                                where 1=1
                                  and b.loaithuocid=" + this.LoaiThuocID + "  and b.isthuocbv=1";
        }


        if (this.TTHoatChat != null && this.TTHoatChat != "")
            select += " AND B.TTHOATCHAT='" + this.TTHoatChat + "'";
        if (this.TenHoatChat != null && this.TenHoatChat != "")
            select += " AND B.CONGTHUC LIKE N'%" + this.TenHoatChat + "%'";
        if (this.BietDuoc != null && this.BietDuoc != "")
            select += " AND B.TENTHUOC LIKE  N'%" + this.BietDuoc + "%'";
        if (this.TenNhom != null && this.TenNhom != "")
            select += " AND c.TenNhom LIKE  N'%" + this.TenNhom + "%'";

        if (this.CateName != null && this.CateName != "")
            select += " AND d.catename LIKE  N'%" + this.CateName + "%'";

        if (this.IsTGN)
            select += " AND B.IsTGN=1";
        if (this.IsTHTT)
            select += " AND B.ISTHTT=1";

        DataTable dt = DataAcess.Connect.GetTable(select);
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["des1"] = StaticData.DoiTuSoLaMaSangInt(dt.Rows[i]["des"].ToString());
              //  dt.Rows[i]["manhom1"] = StaticData.DoiTuSoLaMaSangInt(dt.Rows[i]["manhom"].ToString());
            }

            dt.DefaultView.Sort = "des1,manhom,bietduoc";
            dt = dt.DefaultView.ToTable();

            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
        }
        return dt;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        if(this.LoaiThuocID=="2") return  "DanhMucHoaChat.xls";
        if (this.LoaiThuocID == "3") return "DanhMucDungCu.xls";
        if (this.LoaiThuocID == "4") return "DanhMucVTYT.xls";

        if (this.IsCoGia)
            return "DanhMucThuoc.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
        else
            return "DanhMucThuoc2.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName() 
    {
        if (this.LoaiThuocID == "2") return "DanhMucHoaChat.xls";
        if (this.LoaiThuocID == "4") return "DanhMucVTYT.xls";
        if (this.LoaiThuocID == "3") return "DanhMucDungCu.xls";
        if(this.IsCoGia)
            return "DanhMucThuoc.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
        else
            return "DanhMucThuoc2.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A5");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("hide"); //theo câu select
         
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("catename");
        lst.Add("tennhom");
        lst.Add("des1");
        lst.Add("manhom1");
        lst.Add("des");
        lst.Add("manhom");
        lst.Add("hide");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("catename");
        if (this.LoaiThuocID == "1")
            lst.Add("tennhom");
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true;
    }
    //protected override System.Collections.Generic.List<string> SetListColumnMergeRow()
    //{
    //    System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
    //    if (this.LoaiThuocID == "1")
    //    {
    //        lstC.Add("TTHoatChat");
    //        lstC.Add("hoatchat");
    //    }
    //    return lstC;

    //}
    
     
    
}

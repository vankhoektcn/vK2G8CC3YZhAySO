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
public class profess_Rpt_THSDThuoc2 : ExportToExcel.Profess_ExportToExcelByCode
{
    public string IDKho = null;
    public string TuNgay = null;
    public string DenNgay = null;
    public bool IsThuocGN = false;
    public bool IsThuocHTT = false;
    public string TenKho = null;
    public string TenThuoc = null;

    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
       
        string select = @"select STT=ROW_NUMBER()OVER (ORDER BY TENTHUOC) ,
		                        mathuoc='',
		                        tenthuoc,
		                        tendvt,
		                        a.dongia*((100.0 + isnull(a.vat,0)) /100)/1000 as dongia ,
		                        SL_NGTRU=case e.isnt when 1 then null else sum(A.SOLUONG) END,
		                        TT_NGTRU=case e.isnt when 1 then null else sum(A.THANHTIEN)/1000 END,
		                        SL_NT=case e.isnt when 0 then null else sum(A.SOLUONG) END,
		                        TT_NT=case e.isnt when 0 then null else sum(A.THANHTIEN)/1000 END,
		                        SL_KHAC=NULL,
		                        TT_KHAC=NULL,
		                        SL_HUY=0,
		                        TT_HUY=0 ,
		                        SL=sum(A.SOLUONG),
		                        TT=sum(A.THANHTIEN)/1000
                        from chitietphieuxuatkho a
                        left join phieuxuatkho b on a.idphieuxuat=b.idphieuxuat
                        left join thuoc c on a.idthuoc=c.idthuoc
                        left join thuoc_donvitinh d on c.iddvt=d.id
                        left join khothuoc e on b.idkho2=e.idkho
	                        where       b.ngaythang>='" + this.TuNgay + @"' 
			                        and b.ngaythang<='" + this.DenNgay + @"'
			                         AND B.IDKHO="+StaticData.MacDinhKhoNhapMuaID +@" 
			                        and loaixuat=4 and c.loaithuocid=1 and c.isthuocbv=1 and c.tenthuoc like N'" + this.TenThuoc + @"%'
                        group by a.dongia,isnull(a.vat,0),c.tenthuoc,d.tendvt,e.isnt";
        DataTable dt = DataAcess.Connect.GetTable(select);

        return dt;
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("TT_NGTRU");
        lst.Add("TT_NT");
        lst.Add("TT_KHAC");
        lst.Add("TT_HUY");
        lst.Add("TT");
        return lst;
    }
    //protected override string Set_Total_Name()
    //{
    //    return "Cộng khoản";
    //}
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");
    }

    protected override string SetInputFileName()
    {
        return "BAOCAOSUDUNGTHUOC.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BAOCAOSUDUNGTHUOC.xls";
    }

    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("D2"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        string s = StaticData.TimeDescription(this.TuNgay, this.DenNgay);
        lst.Add(s);
        return lst;
    }
    //protected override ExportToExcel.CellIndex SetHeaderIndex()
    //{
    //    return GetCellIndex("F2");
    //}
    //protected override string SetHeaderText()
    //{
    //    string s = "";
    //    s = StaticData.TimeDescription(this.TuNgay, this.DenNgay).ToUpper();
    //    return s;
    //}
}

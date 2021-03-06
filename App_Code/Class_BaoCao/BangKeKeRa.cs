using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ExportToExcel;

/// <summary>
/// Summary description for BienBangKiemNhap
/// </summary>
public class BangKeKeRa : ExportToExcel.Profess_ExportToExcelByCode
{
    public string thang = "";
    public string nam = "";
    private string tongdoanhthu = "";
    private string tongthue = "";
    public BangKeKeRa()
    {
        thang = DateTime.Today.Month.ToString();
        nam = DateTime.Today.Year.ToString();
    }
    public BangKeKeRa(string thang, string nam)
    {
        this.nam = nam;
        this.thang = thang;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        string select = string.Format(@"select STT =case when temp.so_hd is null then null else
                                    row_number() over (partition by gr.stt order by gr.stt, temp.ngay_ct)end, temp.so_seri,temp.so_hd,ngay_hd,temp.ten_kh,temp.ma_so_thue,
		                            temp.mat_hang,temp.tien_truoc_thue,temp.tien_thue,temp.dien_giai, gr.ten
                                    from 
                                    (
                                    select -1 as khoa, ten=N'1. Hàng hoá, dịch vụ không chịu thuế GTGT:', stt=1
                                    union 
                                    select 0 as khoa,ten= N'2. Hàng hoá, dịch vụ chịu thuế suất thuế GTGT 0%:',stt=2
                                    union 
                                    select 5 as khoa,ten=N'3. Hàng hoá, dịch vụ chịu thuế suất thuế GTGT 5%:', stt=3
                                    union 
                                    select 10 as khoa,ten= N'4. Hàng hoá, dịch vụ chịu thuế suất thuế GTGT 10%:',stt=4
                                    union 
                                    select -2 as khoa,ten= N'5. Hàng hóa, dịch vụ không phải tổng hợp trên tờ khai 01/GTGT:', stt=5
                                    ) as gr
                                    left join (
	                                    select so_seri,so_hd,ngay_hd,ten_kh,ma_so_thue,mat_hang,dien_giai,
		                                    tien_truoc_thue,tien_thue,ngay_ct,(case when 1=-1 then -2 else
		                                     case when thue_suat is null then -1 else thue_suat end end) khoa
	                                    from thue where tk_thue like '333'+'%'  and month(ngay_ct)={0} and year(ngay_ct)={1}
                                    ) temp on gr.khoa=temp.khoa
                                    order by gr.stt, temp.ngay_ct", thang, nam);

        DataTable dt = DataAcess.Connect.GetTable(select);
        if (dt != null)
        {
            tongdoanhthu = dt.Compute("sum(tien_truoc_thue)", "").ToString();
            tongthue = dt.Compute("sum(tien_thue)", "").ToString();
        }
        return dt;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("B17");
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("tien_truoc_thue");
        lst.Add("tien_thue");
        return lst;
    }
    protected override string SetInputFileName()
    {
        return "BangKeBanRa.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BangKeBanRa.xls";
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        lstC.Add("ten");
        return lstC;
    }
    protected override bool SetIsSumByGroup1Value()
    {
        return true;
    }
    protected override bool SetIsSumByGroupValue()
    {
        return true;
    }
      protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("ten");
        return lst; 
    }
    
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("B7"));
        lst.Add(GetCellIndex("B9"));
        lst.Add(GetCellIndex("B10"));
        lst.Add(GetCellIndex("B20"));
        lst.Add(GetCellIndex("B21"));
        lst.Add(GetCellIndex("I23"));

        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        DateTime d = DateTime.Now;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(string.Format("Kỳ tính thuế: tháng {0} năm {1}", thang, nam));
        lst.Add(string.Format("Người nộp thuế: {0}", ""));
        lst.Add(string.Format("Mã số thuế: {0}", ""));
        lst.Add(string.Format("Tổng doanh thu hàng hoá, dịch vụ bán ra: {0}", tongdoanhthu));
        lst.Add(string.Format("Tổng thuế GTGT của hàng hóa, dịch vụ bán ra: {0}", tongthue));
        lst.Add(string.Format("Ngày {0} tháng {1} năm {2}",
            DateTime.Today.ToString("dd"), DateTime.Today.ToString("MM"), DateTime.Today.ToString("yyyy")));
        return lst;
    }
    protected override string Set_Total1_Name()
    {
        return "Tổng";
    }
    protected override bool Set_IsHidenTotal()
    {
        return true;
    }
    
}

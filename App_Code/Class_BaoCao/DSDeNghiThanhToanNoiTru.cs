using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for BienBangKiemNhap
/// </summary>
public class DSDeNghiThanhToanNoiTru : ExportToExcel.Profess_ExportToExcelByCode
{
    private string Chu_sumBHYT = "";

    public DataTable dtGetReportSource()
    {
        return this.getViewTable();
    }
    public DSDeNghiThanhToanNoiTru()
    {
    }

    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        string sql = "SELECT * FROM  DBO.KB_DSDeNghiChiPhiKCBNoiTru_TH( '" + FromDate + "','" + ToDate + "') order by ITYPE,TENBENHNHAN";
        DataTable dtSource1 = DataAcess.Connect.GetTable(sql);
        for (int i = 0; i < dtSource1.Rows.Count; i++)
        {
            string iTenBenhNhan = dtSource1.Rows[i]["TenBenhNhan"].ToString();
            iTenBenhNhan = StaticData.IntelName(iTenBenhNhan);
            dtSource1.Rows[i]["TenBenhNhan"] = iTenBenhNhan;
        }

        if (dtSource1 != null)
        {
            DataTable dt_ITYPEReport = DataAcess.Connect.GetTable("SELECT * FROM KB_ITYPEReport");
            for (int i = 0; i < dt_ITYPEReport.Rows.Count; i++)
            {
                int ii = StaticData.int_Search(dtSource1, "ITYPE=" + dt_ITYPEReport.Rows[i][0].ToString());
                if (ii == -1)
                {
                    DataRow DR = dtSource1.NewRow();
                    DR["LOAIBENHNHAN"] = dt_ITYPEReport.Rows[i][1].ToString();
                    DR["DUNGTUYEN"] = dt_ITYPEReport.Rows[i][2].ToString();
                    DR["ITYPE"] = dt_ITYPEReport.Rows[i][0].ToString();
                    dtSource1.Rows.Add(DR);
                }
            }
            dtSource1.DefaultView.Sort = "ITYPE,TENBENHNHAN";
            dtSource1 = dtSource1.DefaultView.ToTable();
        }
        System.Collections.Generic.List<string> lstLoaiBN = new System.Collections.Generic.List<string>();
        int n_ = 0;
        double TT = 0;
        for (int i = 0; i < dtSource1.Rows.Count; i++)
        {
            string LOAIBENHNHAN = dtSource1.Rows[i]["LOAIBENHNHAN"].ToString();
            string DUNGTUYEN = dtSource1.Rows[i]["DUNGTUYEN"].ToString();
            if (lstLoaiBN.IndexOf(LOAIBENHNHAN + "_" + DUNGTUYEN) == -1)
            {
                n_ = 1;
                lstLoaiBN.Add(LOAIBENHNHAN + "_" + DUNGTUYEN);
            }
            else n_++;

            dtSource1.Rows[i]["STT"] = n_;
            string BHTRA = dtSource1.Rows[i]["BHTRA"].ToString(); if (BHTRA != "") TT += double.Parse(BHTRA);

        }
        Chu_sumBHYT = StaticData.ConvertMoneyToText(TT.ToString());
        return dtSource1;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A8");
    }
    //protected override System.Collections.Generic.List<string> SetListSumColumnName()
    //{
    //    System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
    //    lst.Add("tiencls");
    //    return lst;
    //}
    protected override string SetInputFileName()
    {
        return "dsDeNghiThanhToanNoiTru.xls";
    }
    protected override string SetOutputFileName()
    {
        return "dsDeNghiThanhToanNoiTru.xls";
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        lstC.Add("LOAIBENHNHAN");
        lstC.Add("DUNGTUYEN");
        return lstC;
    }

    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        lstC.Add("LOAIBENHNHAN");
        lstC.Add("DUNGTUYEN");
        lstC.Add("ITYPE");
        return lstC;
    }

    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("D3"));
        lst.Add(GetCellIndex("H10"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        DateTime d = DateTime.Now;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(DSDeNghiThanhToanNoiTru.TimeDescription(this.FromDate, this.ToDate));
        lst.Add(Chu_sumBHYT);
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("XETNGHIEM");
        lst.Add("CDHA");
        lst.Add("THUOC");
        lst.Add("MAU");
        lst.Add("THUTHUATPHAUTHUAT");
        lst.Add("VTYT");
        lst.Add("DVKTC");
        lst.Add("THAIGHEP");
        lst.Add("TIENGIUONG");
        lst.Add("VANCHUYEN");
        lst.Add("TONGCONG");
        lst.Add("BENHNHANCUNGTRA");
        lst.Add("BHTRA");
        return lst;
    }
    protected override bool SetIsSumByGroupValue()
    {
        return true;
    }
    protected override bool SetIsSumByGroup2Value()
    {
        return true;
    }
    protected override bool SetIsSumColumnInGroupValue()
    {
        return true;
    }
    protected override int Set_start_ColumnIndex_Group2()
    {
        return 0;
    }
    protected override string Set_Total_Name()
    {
        return "TỔNG CỘNG A + B + C";
    }
    public static string TimeDescription(string FromDate, string ToDate)
    {
        bool IsLongFormatMonth = false;
        return TimeDescription(FromDate, ToDate, IsLongFormatMonth);
    }
    public static string TimeDescription(string FromDate, string ToDate, bool IsLongFormatMonth)
    {
        #region lấy từ ngày tới ngày
        string FromDateToiNgay = "";
        if (FromDate != null && FromDate != "")
            FromDateToiNgay = "Từ ngày: " + DateTime.Parse(FromDate).ToString("dd/MM/yyyy") + " ";
        if (ToDate != null && ToDate != "")
            FromDateToiNgay += "Đến  ngày: " + DateTime.Parse(ToDate).ToString("dd/MM/yyyy");
        if (FromDate != null && FromDate != "" && ToDate != null && ToDate != "")
        {
            DateTime dFromDate = DateTime.Parse(FromDate);
            DateTime dToDate = DateTime.Parse(ToDate);
            if (dFromDate.Year == dToDate.Year & dFromDate.ToString("dd-MM") == "01-01" && dToDate.ToString("dd-MM") == "31-12")
                return "Năm " + dToDate.Year.ToString();

            if (dFromDate.Month != dToDate.Month && dFromDate.Day == 1 && dToDate.Day == DateTime.DaysInMonth(dToDate.Year, dToDate.Month))
            {
                if (dFromDate.Year == dToDate.Year)
                    return "Từ tháng " + dFromDate.ToString("MM") + " đến tháng " + dToDate.ToString("MM") + " năm " + dToDate.Year.ToString();
                else
                    return "Từ tháng " + dFromDate.ToString("MM/yyyy") + " đến tháng " + dToDate.ToString("MM/yyyy");

            }

            if (DateTime.Parse(FromDate).ToString("dd/MM/yyyy") == DateTime.Parse(ToDate).ToString("dd/MM/yyyy"))
                FromDateToiNgay = "Ngày: " + DateTime.Parse(FromDate).ToString("dd/MM/yyyy");
            if (dFromDate.Year == dToDate.Year && dFromDate.Month == dToDate.Month && dFromDate.Day == 1 && dToDate.Day == DateTime.DaysInMonth(dToDate.Year, dToDate.Month))
            {
                if (!IsLongFormatMonth)
                    FromDateToiNgay = "Tháng: " + dFromDate.ToString("MM/yyyy");
                else
                    FromDateToiNgay = "Tháng " + dFromDate.ToString("MM") + " năm " + dFromDate.Year.ToString();

            }
        }
        if ((FromDate == null || FromDate == "") && (ToDate == null || ToDate == ""))
            FromDateToiNgay = "Đến ngày :" + DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyyy");
        return FromDateToiNgay;
        #endregion
    }


}

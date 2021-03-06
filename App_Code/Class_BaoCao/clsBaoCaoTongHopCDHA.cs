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
public class clsBaoCaoTongHopCDHA : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    private string tu_ngaySQL = "";
    private string den_ngaySQL = "";
    public clsBaoCaoTongHopCDHA()
    {
    }
    public clsBaoCaoTongHopCDHA(string TuNgay, string DenNgay)
    {
        this.TuNgay = TuNgay;
        this.DenNgay = DenNgay;
        this.tu_ngaySQL = StaticData.CheckDate(TuNgay);
        this.den_ngaySQL = StaticData.CheckDate(DenNgay);
    }

    public override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        string mainWhere = "";

        #region Where

        if (!string.IsNullOrEmpty(tu_ngaySQL))
        {
            mainWhere += " and k.ngaythu>='" + tu_ngaySQL + "'";

        }
        if (!string.IsNullOrEmpty(den_ngaySQL))
        {
            mainWhere += " and k.ngaythu<='" + den_ngaySQL + " 23:59:59'";
        }


        #endregion

        string select = string.Format(@"SELECT STT=ROW_NUMBER() OVER (PARTITION BY YEAR(K.NGAYTHU),
                MONTH(K.NGAYTHU),
                DAY(K.NGAYTHU) ORDER BY YEAR(K.NGAYTHU), MONTH(K.NGAYTHU),
                DAY(K.NGAYTHU), B.TENBENHNHAN),
                B.TENBENHNHAN,DBO.KB_GETTUOI(B.NGAYSINH) TUOI,
                P.TENPHONGKHAMBENH KHOA, CASE WHEN B.LOAI=1 THEN 'a' ELSE NULL END BH,
                SUM(CASE WHEN L.MALOAICLS='XQ' THEN ISNULL (K.SOLUONG,1) ELSE NULL END ) XQ,
                SUM(CASE WHEN L.MALOAICLS='CT' THEN ISNULL (K.SOLUONG,1) ELSE NULL END ) CT,
                SUM(CASE WHEN L.MALOAICLS='MRI' THEN ISNULL (K.SOLUONG,1) ELSE NULL END ) MRI,
                SUM(CASE WHEN L.MALOAICLS='SAM' THEN ISNULL (K.SOLUONG,1) ELSE NULL END ) SAM,
                SUM(CASE WHEN L.MALOAICLS='SATD' THEN ISNULL (K.SOLUONG,1) ELSE NULL END ) SATD,
                SUM(CASE WHEN L.MALOAICLS='SATI' THEN ISNULL (K.SOLUONG,1) ELSE NULL END ) SATI,
                SUM(CASE WHEN L.MALOAICLS='SATH' THEN ISNULL (K.SOLUONG,1) ELSE NULL END ) SATH,
                SUM(CASE WHEN L.MALOAICLS='DDT' THEN ISNULL (K.SOLUONG,1) ELSE NULL END ) DDT,
                SUM(CASE WHEN L.MALOAICLS='NSTH' THEN ISNULL (K.SOLUONG,1) ELSE NULL END ) NSTH,
                BG.TENDICHVU, NULL PHIM18, NULL PHIM24, NULL PHIM35, NULL THUOC,
                BSCD.TENBACSI BSCD, NULL BSDP, BSCLS.TENBACSI KTV, NULL NGUOINHANPHIM,
                NULL GHICHU, N'Ngày ' +CONVERT (VARCHAR(10),K.NGAYTHU,103) NGAYKHAM
                FROM DBO.KHAMBENHCANLAMSAN K
                INNER JOIN DBO.BENHNHAN B ON B.IDBENHNHAN=DBO.KB_GETIDBENHNHAN(K.IDKHAMBENHCANLAMSAN)
                LEFT JOIN DBO.PHONGKHAMBENH P ON P.IDPHONGKHAMBENH=K.IDKHOADANGKY
                LEFT JOIN DBO.BANGGIADICHVU BG ON BG.IDBANGGIADICHVU=K.IDCANLAMSAN
                LEFT JOIN DBO.LOAICANLAMSANG L ON BG.IDLOAICLS=L.IDLOAICLS
                LEFT JOIN DIEUTRICANLAMSAN DT ON K.IDKHAMBENHCANLAMSAN=DT.IDKHAMBENHCANLAMSAN
                OR (DT.IDKHAMBENHCANLAMSAN=K.IDKHAMBENH AND K.IDKHAMBENH<>0)
                LEFT JOIN DBO.BACSI BSCLS ON BSCLS.IDBACSI=DT.IDBACSI
                LEFT JOIN DBO.KHAMBENH KB ON KB.IDKHAMBENH=K.IDKHAMBENH
                LEFT JOIN DBO.BACSI BSCD ON BSCD.IDBACSI=KB.IDBACSI
                WHERE ISNULL(K.DAHUY,0)=0 AND K.DATHU=1
                AND L.MANHOM='CHANDOANHINHANH' {0}
                GROUP BY B.TENBENHNHAN, B.NGAYSINH, B.LOAI, P.TENPHONGKHAMBENH,
                L.MALOAICLS, BG.TENDICHVU,BSCD.TENBACSI, BSCLS.TENBACSI
                ,CONVERT (VARCHAR(10),K.NGAYTHU,103) ,YEAR(K.NGAYTHU), MONTH(K.NGAYTHU),
                DAY(K.NGAYTHU)", mainWhere);
        DataTable dt = DataAcess.Connect.GetTable(select);
        return dt;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        return lst;


    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A11");
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("XQ");
        lst.Add("CT");
        lst.Add("MRI");
        lst.Add("SAM");
        lst.Add("SATD");
        lst.Add("SATI");
        lst.Add("SATH");
        lst.Add("DDT");
        lst.Add("NSTH");
        lst.Add("PHIM18");
        lst.Add("PHIM24");
        lst.Add("PHIM35");
        return lst;
    }
    protected override string SetInputFileName()
    {
        return "BaoCaoTongKetCDHA.xls";
    }
    protected override string SetOutputFileName()
    {
        return "BaoCaoTongKetCDHA.xls";
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        lstC.Add("NGAYKHAM");
        return lstC;
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A6"));
        lst.Add(GetCellIndex("W15"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        DateTime d = DateTime.Today;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add((TuNgay == DenNgay ? (string.Format("Ngày {0:dd/MM/yyyy}", TuNgay)) : (string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TuNgay, DenNgay))));
        lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("MM") + "  năm " + d.ToString("yyyy"));
        return lst;
    }
    protected override bool SetIsSumByGroup1Value()
    {
        return true;
    }
    protected override bool SetIsSumByGroupValue()
    {
        return true;
    }
    protected override string Set_Total1_Name()
    {
        return "Tổng";
    }
   


}

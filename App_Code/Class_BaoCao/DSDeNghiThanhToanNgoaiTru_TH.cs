using System;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for BienBangKiemNhap
/// </summary>
public class DSDeNghiThanhToanNgoaiTru_TH : ExportToExcel.Profess_ExportToExcelByCode
{
    private string Chu_sumBHYT = "";
    
    public DSDeNghiThanhToanNgoaiTru_TH()
    {
    }
    public DataTable dtGetReportSource()
    {
        return this.getViewTable();
    }
    

    public  override DataTable getViewTable() // bắt buộc
    {
        this.CurrentLanguage = 1;
        string sqlUpdate = @"if(exists (select name from sysobjects where name='z_mau25b' and type='u'))  drop table z_mau25b
                             SELECT * into z_mau25b FROM DBO.KB_DSDeNghiChiPhiKCBNgoaiTru_TH('" + FromDate + @"','" + ToDate + @"') order by Itype,TENBENHNHAN";
        DataAcess.Connect.ExecSQL(sqlUpdate,360);

        string sql = @"select  STT=DUNGTUYEN, 
                                        TENBENHNHAN='',
		                                count(*) as soluot,
			                            XETNGHIEM=sum(XETNGHIEM),
			                            CDHA=sum(CDHA),
			                            THUOC=sum(THUOC),
			                            MAU=sum(MAU),
			                            THUTHUATPHAUTHUAT=sum(THUTHUATPHAUTHUAT),
			                            VTYT=sum(VTYT),
			                            DVKTC=sum(DVKTC),
			                            THAIGHEP=sum(THAIGHEP),
			                            TIENKHAM=sum(TIENKHAM),
			                            VANCHUYEN=sum(VANCHUYEN),
			                            TONGCONG=sum(TONGCONG),
			                            BENHNHANCUNGTRA=sum(BENHNHANCUNGTRA),
			                            BHXHTHANHTOAN=sum(BHXHTHANHTOAN),
			                            CHIPHINGOAIDS=null,DUNGTUYEN,itype,LOAIBENHNHAN
                            from z_mau25B
                            group by itype,LOAIBENHNHAN,DUNGTUYEN";
        DataTable dtSource1 =DataAcess.Connect.GetTable(sql);
        if (dtSource1 != null)
        {
            DataTable dt_ITypeReport = DataAcess.Connect.GetTable("SELECT * FROM KB_ITypeReport");
            for (int i = 0; i < dt_ITypeReport.Rows.Count; i++)
            {
                int ii = StaticData.int_Search(dtSource1, "itype=" + dt_ITypeReport.Rows[i][0].ToString());
                if (ii == -1)
                {
                    DataRow DR = dtSource1.NewRow();
                    DR["LOAIBENHNHAN"] = dt_ITypeReport.Rows[i][1].ToString();
                    DR["DUNGTUYEN"] = dt_ITypeReport.Rows[i][2].ToString();
                    DR["TENBENHNHAN"] = dt_ITypeReport.Rows[i][2].ToString();
                    DR["itype"] = dt_ITypeReport.Rows[i][0].ToString();
                    dtSource1.Rows.Add(DR);
                }
            }
            dtSource1.DefaultView.Sort = "itype";
            dtSource1 = dtSource1.DefaultView.ToTable();
        }

        double TT = 0;
        for (int i = 0; i < dtSource1.Rows.Count; i++)
        {
            string BHTRA = dtSource1.Rows[i]["bhxhthanhtoan"].ToString(); if (BHTRA != "") TT += double.Parse(BHTRA);
        }

        Chu_sumBHYT = StaticData.ConvertMoneyToText(TT.ToString());
        Chu_sumBHYT += " chẵn /./";
        return dtSource1;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");
    }
    protected override string SetInputFileName()
    {
        return "mau 25b.xls";
    }
    protected override string SetOutputFileName()
    {
        return "mau 25b.xls";
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        lstC.Add("LOAIBENHNHAN");
       // lstC.Add("DUNGTUYEN");
        return lstC;
    }
    
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        lstC.Add("LOAIBENHNHAN");
        lstC.Add("DUNGTUYEN");
        lstC.Add("itype");
        return lstC;
    }

    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("C2"));
        lst.Add(GetCellIndex("O10"));
        lst.Add(GetCellIndex("E9"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
         
        DateTime d = DateTime.Now;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        string timedesc =   DSDeNghiThanhToanNgoaiTru.TimeDescription(this.FromDate, this.ToDate);
        lst.Add(timedesc.ToUpper());        
        lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("MM") + "  năm " + d.ToString("yyyy"));
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
        lst.Add("TIENKHAM");
        lst.Add("VANCHUYEN");
        lst.Add("tongcong");
        lst.Add("benhnhancungtra");
        lst.Add("bhxhthanhtoan");
        return lst;
    }
    protected override bool SetIsSumByGroupValue()
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
    
    
}

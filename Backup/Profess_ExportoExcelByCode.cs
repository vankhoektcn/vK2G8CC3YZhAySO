using System;
using System.Collections.Generic;
using System.Text;
//using Suport;
using System.Data;
namespace ExportToExcel
{
public    class Profess_ExportToExcelByCode:DataAcess.Connect
{
    #region Properties
    public DataTable dtSoucre = null;
    public DateTime ReportDate;
    public string ReportNo=null ;
    public string CusName=null ;
    public string Address = null;
    public string TaxCode = null;
    public string Receier = null;
    public string Tel = null;
    public string Fax = null;
    public string Title = null;
    public string DateTimeDescripton = null;
    public string DateTimeDescriptonE = null;
    public string DateTimeDescriptonV = null;
    
    private string InputFileName = null;
    public string OutputFileName = null;

    private bool show_ReportDate = true;
    private bool show_ReportNo = true;
    private bool show_CusName = true;
    private bool show_Address = true;
    private bool show_TaxCode = true;
    private bool show_Receier = true;
    private bool show_Tel = true;
    private bool show_Fax = false ;
    public string ContainerNo = null;
    public string StockName = null;
    public string ExchangeCode = null;
    public string BillNo = null;
    public string InvoiceNo = null;
    public string Declaretion = null;
    public string Description = null;
    public string sHeaderTex = "";
    public string sDateTimeDescription;
    public bool show_RowHeaderText = false;
    public CellIndex StartDataRowIndex = null;
    public bool _ShowRowHeaderText = false;
    public bool SendForIntermediaCus = false;
    public bool FilterFollowIntermediaCus = false;
    public string CusID2 = null;
    public string ExStatus = null;
    public string ExShipStatus = null;
    public bool IsByDateExchange = true;
    public bool IsByExchangeDate = false;
    public bool IsByExchangeDateCus = false;
    public string DateColumnName = null;
    public string ExchangeID = null;
    public string CusID;
    public string FromDate = null;
    public string ToDate = null;
    public string KindIO = null;
    public string KindCarry = null;
    public string KindExchangeID = null;
    public string EmplID = null;
    public int CurrentLanguage = 1;
    public long TotalVND = 0;
    public Customer current_Customer = null;

    public string ReportID = null;
    public long Total_ServiceVND = 0;
    public double Total_ServiceORC = 0;
    public long Total_AmountVND = 0;
    public double Total_AmountORC = 0;
    public long Total_VATVND = 0;
    public double Total_VATORC = 0;
    public long Total_CH = 0;
    public long Total_AmountVND2 = 0;
    public long Total_VATVND2 = 0;
    public long Total_ServiceVND2 = 0;
    public string DefaultORC = "2";
    public DataTable dtReport = null;
    public DataTable dtReportDeclare;
    public int AddCplumnQuantity = 0;
    public List<string> lstSpenColumns = null;
    public List<string> lstHidenColumn_add = null;
    public string PrevSQLSelect = null;
    public bool IsDetailChiHo = true;
    public DataTable dtOtherValue_ = null;
    public List<string> lstOtherName_ = null;
    public List<CellIndex> lstOtherIndex_ = null;
    public string InputFile_ = null;
    public bool IsReplaceExistFile = false;
    public List<ExportToExcel.MergeRow> lstMergRow_ = null;
    public List<string> lstGroupBy_ = null;

    #region Trạng thái tất toán
    public bool IsSetIsOK = false;
    #endregion
    #endregion
    #region Init
    public bool IsFixStatus = false;
    public Profess_ExportToExcelByCode()
    {
    }
    #endregion
    #region Clause Select =Where clause
    protected virtual string SetWhereClause()
    {
        if (this.IsByExchangeDate)
            DateColumnName = "ExchangeDate";
        if (this.IsByExchangeDateCus)
            DateColumnName = "ExchangeDateCus";
        if (this.DateColumnName == null) this.DateColumnName = this.SetDateColumnNameF();
         
        string s = "   T.STATUS=1";
        if (CusID != null && CusID != "")
        {
            s += " AND T." + "CusID" + "=" + CusID;
        }
        if (CusID2 != null && CusID2 != "")
        {
            s += " AND T." + "CusID2" + "=" + CusID2;
        }
        if (this.DateColumnName!="" && this.DateColumnName!=""&&  FromDate != null && FromDate != "")
        {
             FixTuNgay(ref FromDate);
            s += " AND T." + DateColumnName + ">='" + FromDate + "'";
        }
        if (this.DateColumnName != "" && this.DateColumnName != "" && ToDate != null && ToDate != "")
        {
             FixDenNgay(ref ToDate);
            s += " AND T." + DateColumnName + "<='" + ToDate + "'";
        }
        if (KindIO != null && KindIO != "")
            s += " AND T." +"KindIOID" + "=" + KindIO;
        if (KindCarry != null && KindCarry != "")
            s += " AND T." + "KindCarryID" + "=" + KindCarry;
        if (this.KindExchangeID != null && this.KindExchangeID != "")
            s += " AND T." + "KindExchangeID" + "=" + KindExchangeID;
        if (this.ContainerNo != null && this.ContainerNo != "")
            s += " AND T." + "ContainerNo" + " Like  N'%" + ContainerNo +"%'";
        if (this.StockName != null && this.StockName != "")
            s += " AND T." + "StockName" + " like  N'%" + StockName + "%'";


        if (this.ExchangeCode != null && this.ExchangeCode != "")
            s += " AND T." + "ExchangeCode" + " like  N'%" + ExchangeCode + "%'";
        if (this.BillNo != null && this.BillNo != "")
            s += " AND T." + "BillNo" + " like  N'%" + BillNo + "%'";
        if (this.InvoiceNo != null && this.InvoiceNo != "")
            s += " AND T." + "InvoiceNO" + " like  N'%" + InvoiceNo + "%'";
        if (this.Declaretion != null && this.Declaretion != "")
            s += " AND T." + "Declaration" + " like  N'%" + Declaretion + "%'";
        if (this.ExStatus != null && this.ExStatus != "")
            s += " AND DBO.Get_ExStatusID(T.ExchangeID)=" + this.ExStatus;
        if (this.ExShipStatus != null && this.ExShipStatus != "")
            s += " AND DBO.Get_ExShipStatusID(T.ExchangeID)=" + this.ExShipStatus;
        if (this.ExchangeID != null && this.ExchangeID != "")
            s += " AND T.ExchangeID=" + this.ExchangeID;
        if (this.EmplID != null && this.EmplID != "")
            s += " AND E.EmplID=" + this.EmplID;
        if (this.IsSetIsOK)
        {
            s += " AND (T.IsOK Is Null Or T.IsOK=0)";
            if(this.IsByDateExchange && this.FromDate!=null &&this.FromDate!="" && this.ToDate!=null && this.ToDate!="")
                s+=" AND DBO.IsFixStatus(T.ExchangeID,'"+this.ToDate+"')=1";
        }
        return s;

    }
    #endregion
    #region Set View Parameter

    protected virtual DataTable Set_dtOtherValue_()
    {
        return null;
    }
    protected virtual List<string> Set_lstOtherName_()
    {
        return null;
    }
    protected virtual List<CellIndex> Set_lstOtherIndex_()
    {
        return null;
    }

    public static string[] ExcelIndexNames = new string[] {
    "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
    , "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "A0", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ"
    , "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "B0", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ"
    , "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "C0", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"
    };
    public static CellIndex GetCellIndex(string ExcelIndexName)
    {
        string s = ExcelIndexName.Trim();
        if (s.Length < 2) return null;
        string E = s[0].ToString();
        string N = s.Remove(0, 1);
        int Row = Array.IndexOf(ExcelIndexNames, E.ToUpper());
        if (Row == -1) return null;
        return new CellIndex(int.Parse(N), Row);

    }
    public static CellIndex NVK_GetCellIndex(string ExcelIndexName)
    {
        string s = ExcelIndexName.Trim();
        if (s.Length < 2) return null;
        string E = "";
        string N = "";
        if (s.Length == 3)
        {
            E = s.Remove(2, 1);
            N = s[2].ToString();
        }
        else
        {
            E = s[0].ToString();
            N = s.Remove(0, 1);
        }
        int Row = Array.IndexOf(ExcelIndexNames, E.ToUpper());
        if (Row == -1) return null;
        return new CellIndex(int.Parse(N), Row);


    }
    protected virtual string SetInputFileName()
    {
        if (this.InputFile_ != null && this.InputFile_ != "") return this.InputFile_;
        return null;
    }
    protected virtual string SetOutputFileName()
    {
        return null;
    }
    protected virtual bool SetShowTimeOnHeaderRow()
    {
        return true;
    }
    protected virtual string SetHeaderText()
    {
        string s = "";
        if (this.sHeaderTex != null && this.sHeaderTex != "")
            s = this.sHeaderTex;
        bool ShowTimeOnHeaderRow = this.SetShowTimeOnHeaderRow();
        if (ShowTimeOnHeaderRow)
        {
            if (this.DateTimeDescripton != null && this.DateTimeDescripton != "")
                s += " " + DateTimeDescripton;
        }
        if (s != "") return s;
        return null;
    }
    protected virtual CellIndex SetHeaderIndex()
    {
        return null;
    }

    protected virtual CellIndex SetStartDataIndex()
    {
        return null;
    }
    protected virtual List<string> SetListSumColumnName()
    {
        return null;
    }
    protected virtual List<string> SetListGroupName()
    {
        if (this.lstGroupBy_ != null) return this.lstGroupBy_;
        return null;
    }
    protected virtual bool SetIsSumByGroupValue()
    {
        return false ;
    }
    protected virtual bool SetIsSumByGroup1Value()
    {
        return false;
    }
    protected virtual bool SetIsSumByGroup2Value()
    {
        return false;
    }

    protected virtual bool SetIsSumColumnInGroupValue()
    {
        return false ;
    }
    protected virtual List<string> SetListHidenColumnName()
    {
        return null;
    }
    private List<string> ListHidenColumnName_Final()
    {
        List<string> lstC = this.SetListHidenColumnName();
        if (lstC == null ) 
        {
            if(this.lstHidenColumn_add != null && this.lstHidenColumn_add.Count > 0)
            return this.lstHidenColumn_add;
            return null;
        }
        else
        {
            if (this.lstHidenColumn_add != null && this.lstHidenColumn_add.Count > 0)
            {
                for (int i = 0; i < this.lstHidenColumn_add.Count; i++)
                    lstC.Add(this.lstHidenColumn_add[i]);
            }
            return lstC;

        }
    }
    protected virtual List<object> SetListOtherValue()
    {
        return null;
    }
    protected virtual List<CellIndex> SetListOtherIndex()
    {
        return null;
    }
    protected virtual bool Setshow_ReportDate() { return false ; }
    protected virtual bool Setshow_ReportNo() { return false ; }
    protected virtual bool Setshow_CusName() { return false ; }
    protected virtual bool Setshow_Address() { return false ; }
    protected virtual bool Setshow_TaxCode() { return false ; }
    protected virtual bool Setshow_Receier() { return false ; }
    protected virtual bool Setshow_Tel() { return false ; }
    protected virtual bool Setshow_Fax() { return false  ; }

    protected virtual CellIndex SetReportNoIndex() { return null ; }
    protected virtual CellIndex SetReportDateIndex() { return null ; }
    protected virtual CellIndex SetCusNameIndex() { return null ; }
    protected virtual CellIndex SetAddressIndex() { return null ; }
    protected virtual CellIndex SetTaxCodeIndex() { return null ; }
    protected virtual CellIndex SetReceierIndex() { return null ; }
    protected virtual CellIndex SetTelIndex() { return null; }
    protected virtual CellIndex SetFaxIndex() { return null ; }
    protected virtual CellIndex SetSumTotalIndex() { return null ; }

    protected virtual CellIndex SetEmplName_Index() { return null; }
    protected virtual CellIndex SetDeptName_Index() { return null; }
    protected virtual CellIndex SetEmplAndDeptIndex() { return null; }

    protected virtual List<string> SetRowHeaderText()
    {
        return null;
    }
    protected virtual bool SetShowRowHeaderText() { return _ShowRowHeaderText; }
    protected virtual CellIndex SetRowHeaderIndex()
    {
        return null;
    }
    protected virtual string[] SetListColumnFixValues()
    {
        return null;
    }
    protected virtual bool Set_VATAllField_Show()
    {
        return false;
    }
    protected virtual int  Set_VATAllFieldPercent()
    {
        return 10;
    }

    public string GetSourceFile()
    {
        return this.SetInputFileName();
    }
    protected virtual List<string> SetListExcelHidenColumns()
    {
        return null;
    }
    protected virtual bool  SetSendForIntermediaCus()
    {
        return false;
    }
    protected virtual bool SetVATChiHo()
    {
        return false;
    }
    protected virtual List<string> SetlstColumnsNotVAT()
    {
        return null;
    }
    protected virtual Profess_Excel.ShowType SetShowType()
    {
        return Profess_Excel.ShowType.ExcelFile;
    }
    protected virtual List<string> SetListColumnMergeRow()
    {
        return null;
    }
    protected virtual string SetIsIndexColumn()
    {
        return null;
    }
    protected virtual string SetDateColumnNameF()
    {
        return "DateExchange";
    }
    #endregion
    #region Export To Excel File
    public virtual void ExportToExcel()
    {
        ReportDate = DataAcess.Connect.d_SystemDate();
        System.Web.UI.Page P = new System.Web.UI.Page();
        string ReportSource_Path = P.Server.MapPath("~/App_Data/ReportSource");
        string ReportOutput_Path = P.Server.MapPath("~/ReportOutput");
        if (!System.IO.Directory.Exists(ReportSource_Path)) System.IO.Directory.CreateDirectory(ReportSource_Path);
        if (!System.IO.Directory.Exists(ReportOutput_Path)) System.IO.Directory.CreateDirectory(ReportOutput_Path);
        this.InputFileName = this.SetInputFileName();
        this.OutputFileName = this.SetOutputFileName();
        this.OutputFileName =this.OutputFileName.Replace(".xls","")+  "_" + this.ReportDate.ToString("dd-MM-yyyy")
            +".xls";

        string FileSource=ReportSource_Path +"\\"+this.InputFileName;

        if (!System.IO.File.Exists(FileSource))
        {
//            MessageBox.Show(Dictionary.clDictionaryDB.sGetValueLanguage("File") + " : " + FileSource + " " + Dictionary.clDictionaryDB.sGetValueLanguage("Not Exists"), Dictionary.clDictionaryDB.sGetValueLanguage("Alert"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        Profess_Excel E = new Profess_Excel(FileSource ,ReportOutput_Path+"\\"+ this.OutputFileName);
        E.AfterReport += new Profess_Excel.AfterReportHandle(E_AfterReport);
        CellIndex StartDataI = this.SetStartDataIndex();
        this.StartDataRowIndex = StartDataI;
        E.ReportShowType = this.SetShowType();
        E.IsReplaceExistFile = this.IsReplaceExistFile;
        E.Start_Row_Data = StartDataI.Row;
        E.Start_Col_Data = StartDataI.Col;
        E.lstGroupName = this.SetListGroupName();
        E.lstHidenColumnName = this.ListHidenColumnName_Final();
        E.lstSumName = this.SetListSumColumnName();
        E.lstExcelHidenColumnName = this.SetListExcelHidenColumns();
        E.IsSumByGroup = this.SetIsSumByGroupValue();
        E.IsSumByGroup1 = this.SetIsSumByGroup1Value();
        E.IsSumByGroup2 = this.SetIsSumByGroup2Value();
        E.IsSumColumnInGroup = this.SetIsSumColumnInGroupValue();
        E.VATAllField_Show = this.Set_VATAllField_Show();
        E.VATAllPercent = this.Set_VATAllFieldPercent();
        E.lstColumnNotVAT = this.SetlstColumnsNotVAT();
        this.show_RowHeaderText = this.SetShowRowHeaderText();
        if (this.show_RowHeaderText)
        {
            E.RowHeaderIndex = this.SetRowHeaderIndex();
            E.lstRowHeaderName = this.SetRowHeaderText();
            
        }
        this.dtSoucre = this.getViewTable();
        if (this.dtSoucre != null)
        {

            E.dtSource = this.dtSoucre.Copy(); 
            E.lstColumnMergeRow = this.SetListColumnMergeRow();
            E.IsIndexColulmn = this.SetIsIndexColumn();
            string[] arrFixColumns = this.SetListColumnFixValues();
            if (arrFixColumns != null)
            {
                for (int i = 0; i < arrFixColumns.Length; i++)
                {
                    if (dtSoucre.Columns.IndexOf(arrFixColumns[i]) != -1)
                    {
                        for (int j = 0; j < dtSoucre.Rows.Count; j++)
                        {
                            string FixColumnValue = dtSoucre.Rows[j][arrFixColumns[i]].ToString();
                            if (FixColumnValue != "" && (FixColumnValue.IndexOf(";") != -1))
                            {
                                FixColumnValue = FixColumnValue.Trim();
                                if (FixColumnValue != "" && FixColumnValue[0] == ';') FixColumnValue = FixColumnValue.Remove(0, 1);
                                if (FixColumnValue != "" && FixColumnValue[FixColumnValue.Length - 1] == ';') FixColumnValue = FixColumnValue.Remove(FixColumnValue.Length - 1, 1);
                                FixColumnValue = FixColumnValue.Replace(";", "\r\n");
                                E.dtSource.Rows[j][arrFixColumns[i]] = FixColumnValue;
                            }
                        }
                    }
                }
            }
        }
        E.Language = this.CurrentLanguage;
        E.lstOtherIndex = new List<CellIndex>();
        E.lstOtherValues = new List<object>();
        string HeaderText = this.SetHeaderText();
        if (HeaderText != null)
        {
            CellIndex HeaderIndex = this.SetHeaderIndex();
            if (HeaderText != null)
            {
                E.lstOtherValues.Add(HeaderText);
                E.lstOtherIndex.Add(HeaderIndex);
            }
        }
        CellIndex SumIndex = this.SetSumTotalIndex();
        if (SumIndex != null)
        {
            E.lstOtherIndex.Add(SumIndex);
            E.lstOtherValues.Add(this.TotalVND);
        }
        if (this.ReportNo != null && this.ReportNo != "" )
        {
            this.show_ReportNo = this.Setshow_ReportNo();
            if (this.show_ReportNo)
            {
                CellIndex ReportNoIndex = this.SetReportNoIndex();
                E.lstOtherIndex.Add(ReportNoIndex);
                E.lstOtherValues.Add(this.ReportNo);
            }

           

        }

        this.show_ReportDate = this.Setshow_ReportDate();
        if (this.show_ReportDate)
        {
            CellIndex ReportDateIndex = this.SetReportDateIndex();
            E.lstOtherIndex.Add(ReportDateIndex);
            E.lstOtherValues.Add(this.ReportDate);
        }
        if (this.CusName == null && this.current_Customer != null)
            this.CusName = this.current_Customer.CusName;
        if (this.CusName != null)
        {
            this.show_CusName = this.Setshow_CusName();
            if (this.show_CusName)
            {
                CellIndex CusNameIndex = this.SetCusNameIndex();
                E.lstOtherIndex.Add(CusNameIndex);
        
                E.lstOtherValues.Add(this.CusName);
            }
        }

        if (this.Address == null && this.current_Customer != null)
            this.Address = this.current_Customer.Address;
        if (this.Address != null)
        {
            this.show_Address = this.Setshow_Address();
            if (this.show_Address)
            {
                CellIndex AddressIndex = this.SetAddressIndex();
                E.lstOtherIndex.Add(AddressIndex);
                
                E.lstOtherValues.Add(this.Address);
            }
        }
        if (this.TaxCode == null && this.current_Customer != null)
            this.TaxCode = this.current_Customer.TaxCode;

        if (this.TaxCode != null)
        {
            this.show_TaxCode = this.Setshow_TaxCode();
            if (this.show_TaxCode)
            {
                CellIndex TaxCodeIndex = this.SetTaxCodeIndex();
                E.lstOtherIndex.Add(TaxCodeIndex);
                
                E.lstOtherValues.Add(this.TaxCode);
            }
        }
        if (this.Receier == null && this.current_Customer != null)
            this.Receier = this.current_Customer.RepName;

        if (this.Receier != null)
        {
            this.show_Receier = this.Setshow_Receier();
            if (this.show_Receier)
            {
                CellIndex ReceierIndex = this.SetReceierIndex();
                E.lstOtherIndex.Add(ReceierIndex);
        

                E.lstOtherValues.Add(this.Receier);
            }
        }
        if (this.Tel == null && this.current_Customer != null)
            this.Tel = this.current_Customer.Tel;
        if (this.Tel != null)
        {
            this.show_Tel = this.Setshow_Tel();
            if (this.show_Tel)
            {
                CellIndex TelIndex = this.SetTelIndex();
                E.lstOtherIndex.Add(TelIndex);
        

                E.lstOtherValues.Add(this.Tel);
            }
        }
        if (this.Fax == null && this.current_Customer != null)
            this.Fax = this.current_Customer.Fax;
        if (this.Fax != null)
        {
            this.show_Fax = this.Setshow_Fax();
            if (this.show_Fax)
            {
                CellIndex FaxIndex = this.SetFaxIndex();
                E.lstOtherIndex.Add(FaxIndex);
                
                E.lstOtherValues.Add(this.Fax);
            }
        }
        //string DeptName="";
        //if(ProfessObject.UserLogin.ID!=null && ProfessObject.UserLogin.ID!="")
        //{
        //    if(this.CurrentLanguage==1)
        //        DeptName=ProfessObject.UserLogin.DepartMent;
        //    if(this.CurrentLanguage==2)
        //        DeptName=ProfessObject.UserLogin.DepartMentE;
        //    if(this.CurrentLanguage==3)
        //        DeptName=ProfessObject.UserLogin.DepartMentC;
        //}
        //CellIndex EmplName_Index = this.SetEmplName_Index(); 
        //if (EmplName_Index != null )
        //{
        //    E.lstOtherIndex.Add(EmplName_Index);
        //    E.lstOtherValues.Add(ProfessObject.UserLogin.EmplName);
        //}

        //CellIndex DeptName_Index = this.SetDeptName_Index();
        //if (DeptName_Index != null)
        //{
        //    E.lstOtherIndex.Add(DeptName_Index);
        //    E.lstOtherValues.Add(DeptName);
        //}

        //CellIndex EmplAndDeptIndex = this.SetEmplAndDeptIndex();
        //if (EmplAndDeptIndex != null)
        //{
        //    E.lstOtherIndex.Add(EmplAndDeptIndex);
        //    E.lstOtherValues.Add(ProfessObject.UserLogin.EmplName+"/"+ DeptName);
        //}



        List<object> listOtherValue = this.SetListOtherValue();
        if (listOtherValue != null && listOtherValue.Count > 0)
        {
            List<CellIndex> lstOtherIndex = this.SetListOtherIndex();
            if (lstOtherIndex != null && lstOtherIndex.Count > 0)
            {
                E.lstOtherValues.AddRange(listOtherValue);
                E.lstOtherIndex.AddRange(lstOtherIndex);
            }
        }
        #region Other Value from DataBase
        this.dtOtherValue_ = this.Set_dtOtherValue_();
        if (this.dtOtherValue_ != null && this.dtOtherValue_.Rows.Count > 0)
        {
            this.lstOtherName_ = this.Set_lstOtherName_();
            if (this.lstOtherName_ != null && this.lstOtherName_.Count > 0)
            {
                this.lstOtherIndex_ = this.Set_lstOtherIndex_();
                if (this.lstOtherIndex_ != null && this.lstOtherIndex_.Count > 0)
                {
                    for (int i = 0; i < this.lstOtherIndex_.Count; i++)
                    {
                        
                        int n = this.dtOtherValue_.Columns.IndexOf(this.lstOtherName_[i]);
                        if (n != -1)
                        {
                            E.lstOtherIndex.Add(this.lstOtherIndex_[i]);
                            E.lstOtherValues.Add(this.dtOtherValue_.Rows[0][n]);
                        }
                    }
                }
            }

        }
        #endregion
        E.lstMergeRow_ = this.lstMergRow_;
        E.Total1_Name = this.Set_Total1_Name();
        E.Total2_Name = this.Set_Total2_Name();
        E.IsHideTotal = this.Set_IsHidenTotal();
        E.IsDeleteTotalRow = this.IsDeleteTotalRow;
        E.ExportThead();
    }

    void E_AfterReport()
    {
        this.OnAfterExport();
    }

    
    #endregion
    #region Get Data
    public virtual System.Data.DataTable getViewTable()
    {
        return null;
    }
    #endregion
    public bool IsDeleteTotalRow = false;
    public static void FixTuNgay(ref string TuNgay)
    {
        TuNgay = DateTime.Parse(TuNgay).ToString("yyyy-MM-dd 00:00:00");
         

    }
    public static void FixDenNgay(ref string TuNgay)
    {
        TuNgay = DateTime.Parse(TuNgay).ToString("yyyy-MM-dd 23:59:59");
    }
    protected virtual string Set_Total1_Name()
    {
        return null;
    }
    protected virtual string Set_Total2_Name()
    {
        return null;
    }
    protected virtual bool Set_IsHidenTotal()
    {
        return false;
    }
    //public static string[] ExcelIndexNames = new string[] { "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AB", "AC", "AD", "AE", "AF", "AG", "AH" };
    //public static CellIndex GetCellIndex(string ExcelIndexName)
    //{
    //    string s = ExcelIndexName.Trim();
    //    if (s.Length < 2) return null;
    //    string E = s[0].ToString();
    //    string N = s.Remove(0, 1);
    //    int Row = Array.IndexOf(ExcelIndexNames, E.ToUpper());
    //    if (Row == -1) return null;
    //    return new CellIndex(int.Parse(N), Row);

    //}
     

    #region Event

    public delegate void AfterExportToExcelHandle();
    public event AfterExportToExcelHandle AfterExportToExcel;
    private void OnAfterExport()
    {
        if (AfterExportToExcel != null)
        {
            AfterExportToExcel();
        }
    }
    #endregion
}
}

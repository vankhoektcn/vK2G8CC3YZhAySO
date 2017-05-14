using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Web.SessionState;
using System.Web.UI.Adapters;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Data;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Web.UI;
using System.Web.Util;
using System.Web.UI.WebControls;


using System.Web.Hosting;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;

 
namespace ExportToExcel
{
    //───────────────────────────────────────────────────
  public  class Profess_Excel
    {
      private static int CountThread = 0;
      public string SourceFile;
      public string DestinationFile;
      private COMExcel.Worksheet exSheet;
      public string HeaderText="";
      public CellIndex RowHeaderIndex = null;
      public  DataTable dtSource;
      public List<string> lstRowHeaderName;
      public int Start_Row_Header;
      public int Start_Col_Header;
      public int Start_Row_Data;
      public int Start_Col_Data;
      public List<string> lstHidenColumnName;
      public List<string> lstGroupName;
      public List<string> lstSumName;
      public bool IsSumColumnInGroup=false ;
      public bool IsSumByGroup = false;
      public List<object> lstOtherValues;
      public List<CellIndex> lstOtherIndex;
      public int Language = 1;
      public bool VATAllField_Show = false;
      public int VATAllPercent = 10;
      public List<string> lstExcelHidenColumnName=null;
      public List<string> lstColumnNotVAT = null;
      public ShowType ReportShowType = ShowType.ExcelFile;
      public List<string> lstColumnMergeRow = null;
      public string IsIndexColulmn = null;
      public bool IsSumByGroup1 = true;
      public bool IsSumByGroup2 = true;
      public bool IsReplaceExistFile = false;
      public List<MergeRow> lstMergeRow_ = null;
      public string Total1_Name = null;
      public string Total2_Name = null;
      public bool IsHideTotal = false;
      //───────────────────────────────────────────────────
      #region Event

      public delegate void AfterReportHandle();
      public   event AfterReportHandle AfterReport;
      private   void OnAfterReport()
      {
          if (AfterReport != null)
          {
              AfterReport();
          }
      }
      #endregion
      public Profess_Excel(string SourceFileName, string DestinationFileName)
      {
          this.SourceFile = SourceFileName;
          this.DestinationFile = DestinationFileName;
      }

      //───────────────────────────────────────────────────
      public bool IsDeleteTotalRow = false;
      protected virtual void ExportTable(
                                        )
      {
          #region Nếu có dt Source
          int c = 0;
          if (this.dtSource != null)
          {
              #region Fix DtV
              DataTable dt = dtSource.Copy();
              DataTable dtV = dtSource.Copy();
              if (this.lstHidenColumnName != null && this.lstHidenColumnName.Count != 0)
              {
                  for (int i = 0; i < this.lstHidenColumnName.Count; i++)
                  {
                      if(dtV.Columns.IndexOf(this.lstHidenColumnName[i])!=-1)
                        dtV.Columns.Remove(this.lstHidenColumnName[i]);
                  }
              }
              #endregion
              #region Fill DataTable Row
              #region Get Columns Type
              List<string> lstDataType = new List<string>();
              for (int j = 0; j < dt.Columns.Count; j++)
                  lstDataType.Add(dt.Columns[j].DataType.ToString());
              #endregion
              #region Khởi động các list value
              List<List<string>> lstRowFilterValue = new List<List<string>>();
              List<int> lstGroup1Index = new List<int>();
              List<int> lstGroup2Index = new List<int>();
              List<string> lstGroup1Value = new List<string>();
              List<string> lstGroup2Value = new List<string>();
              List<string> lstGroup2Value_Compare = new List<string>();
              List<string> lstGroup2Value_Filter = new List<string>();

              List<List<double>> lstGroupValue1 = new List<List<double>>();
              List<List<double>> lstGroupValue2 = new List<List<double>>();
              List<double> lstTemp = new List<double>();
              #endregion
              #region Khởi động tổng cộng =0
              if (this.lstSumName != null && this.lstSumName.Count > 0)
              {
                  for (int i = 0; i < lstSumName.Count; i++)
                      lstTemp.Add(0);
              }
              #endregion
              #region Tính các value cho group
              if (lstGroupName != null && lstGroupName.Count > 0)
              {
                  for (int k = 0; k < lstGroupName.Count; k++)
                  {
                      lstRowFilterValue.Add(new List<string>());
                  }
                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      for (int j = 0; j < lstGroupName.Count; j++)
                      {
                          if (lstRowFilterValue[j].IndexOf(dt.Rows[i][lstGroupName[j]].ToString()) == -1)
                          {
                              lstRowFilterValue[j].Add(dt.Rows[i][lstGroupName[j]].ToString());

                          }
                      }
                  }
                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      string sValue = dt.Rows[i][lstGroupName[0]].ToString();
                      if (lstGroup1Value.IndexOf(sValue) == -1)
                      {
                          lstGroup1Index.Add(i);
                          lstGroup1Value.Add(sValue);

                      }
                      if (lstGroupName.Count == 2)
                      {
                          string sValue1 = dt.Rows[i][lstGroupName[0]].ToString();
                          string sValue2 = dt.Rows[i][lstGroupName[1]].ToString();
                          if (lstGroup2Value_Compare.IndexOf(sValue1 + sValue2) == -1)
                          {
                              lstGroup2Index.Add(i);
                              lstGroup2Value_Compare.Add(sValue1 + sValue2);
                              lstGroup2Value.Add(sValue2);
                              lstGroup2Value_Filter.Add(lstGroupName[0] + "='" + sValue1 + "' AND " + lstGroupName[1] + "='" + sValue2 + "'");
                          }
                      }
                  }
              #endregion
              #region Nếu có tính tổng theo group
                  if (this.IsSumByGroup)
                  {
                      DataView dv = new DataView(dtSource.Copy());
                      #region Group 1
                      for (int i = 0; i < lstGroup1Value.Count; i++)
                      {
                          List<double> lstTemp2 = new List<double>();
                          for (int b = 0; b < lstSumName.Count; b++)
                              lstTemp2.Add(0);

                          dv.RowFilter = lstGroupName[0] + "='" + lstGroup1Value[i].ToString() + "'";
                          for (int j = 0; j < dv.Count; j++)
                          {
                              for (int m = 0; m < lstSumName.Count; m++)
                              {
                                  if (dv.Table.Columns.IndexOf(lstSumName[m]) != -1)
                                  {
                                      string stemp = dv[j][lstSumName[m]].ToString();
                                      if (stemp == "") stemp = "0";


                                      try
                                      {
                                          if (stemp.IndexOf("\n") == -1)
                                          {
                                              double d = double.Parse(stemp);
                                              lstTemp2[m] += d;
                                          }
                                          else
                                          {
                                              stemp = stemp.Replace("\r", "");
                                              string[] arrTempI = stemp.Split('\n');
                                              for (int nn = 0; nn < arrTempI.Length; nn++)
                                              {
                                                  if (arrTempI[nn] != "")
                                                  {
                                                      double dd = double.Parse(arrTempI[nn]);
                                                      lstTemp2[m] += dd;
                                                  }
                                              }
                                          }
                                      }
                                      catch (Exception) { }
                                  }
                              }

                          }
                          lstGroupValue1.Add(lstTemp2);
                      }
                      #endregion
                      #region Group 2
                      for (int i = 0; i < lstGroup2Value.Count; i++)
                      {
                          List<double> lstTemp2 = new List<double>();
                          for (int b = 0; b < lstSumName.Count; b++)
                              lstTemp2.Add(0);

                          dv.RowFilter = lstGroup2Value_Filter[i];
                          for (int j = 0; j < dv.Count; j++)
                          {
                              for (int m = 0; m < lstSumName.Count; m++)
                              {
                                  string stemp = dv[j][lstSumName[m]].ToString();
                                  if (stemp == "") stemp = "0";
                                  try
                                  {
                                      if (stemp.IndexOf("\n") == -1)
                                      {
                                          double d = double.Parse(stemp);
                                          lstTemp2[m] += d;
                                      }
                                      else
                                      {
                                          stemp = stemp.Replace("\r", "");
                                          string[] arrTempI = stemp.Split('\n');
                                          for (int nn = 0; nn < arrTempI.Length; nn++)
                                          {
                                              if (arrTempI[nn] != "")
                                              {
                                                  double dd = double.Parse(arrTempI[nn]);
                                                  lstTemp2[m] += dd;
                                              }
                                          }
                                      }
                                  }
                                  catch (Exception) { }
                              }

                          }
                          lstGroupValue2.Add(lstTemp2);
                      }
                      #endregion
                  }

              }
              #endregion
              #region các tham số temp
              bool PrevRowIsGroup = false;
              int c1 = 0;
              int c2 = 0;
              int NewCount = 1;
              bool IsFill_Group2 = false;
              #endregion
              #region Chiều cao của một dòng
              COMExcel.Range R1_temp = (COMExcel.Range)exSheet.Cells[Start_Row_Data + 1, Start_Col_Data];
              double dHeightTemp = (double)R1_temp.RowHeight;
              #endregion
              #region Fill Data trên từng dòng ,từng cell
              List<int> lstMaxRowL = new List<int>();
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  #region Số dòng lớn nhất cho từng dòng
                  lstMaxRowL.Add(1);
                  #endregion
                  #region Nếu có nhóm 1 và dòng đầu tiên của nhóm 1 đã được tìm thấy
                  IsFill_Group2 = false;
                  PrevRowIsGroup = false;
                  if (lstGroupName != null && lstGroupName.Count > 0)
                  {
                      int GroupIndex1 = lstGroup1Index.IndexOf(i);
                      if (GroupIndex1 != -1 )
                      {
                          #region Nếu đây là giá trị thứ 2 trở đi và đồng thời giá trị tổng cộng không cùng nằm trên nhóm
                          if (this.lstSumName != null && this.lstSumName.Count > 0 && this.IsSumByGroup  && !this.IsSumColumnInGroup && GroupIndex1>=1)
                          {
                              #region Tính tổng của nhóm 2 của giá trị trước đó trước khi Insert dòng tổng cộng này
                                #region Nếu có nhóm 2 và dòng đầu tiên của nhóm 2 đã được tìm thấy
                              if (lstGroup2Index.Count > 0)
                              {
                                  int GroupIndex2 = lstGroup2Index.IndexOf(i);
                                  if (GroupIndex2 != -1 )
                                  {
                                      #region Nếu đây là giá trị thứ 2 trở đi và đồng thời giá trị tổng cộng không cùng nằm trên nhóm
                                      if (this.lstSumName != null && this.lstSumName.Count > 0 && this.IsSumByGroup &&this.IsSumByGroup2 && !this.IsSumColumnInGroup && GroupIndex2 >= 1)
                                      {

                                          IsFill_Group2 = true;
                                          // ta sẽ lặp lại bước thêm một dòng nhóm và các giá trị tổng cộng của nó và fill vào một dòng dưới 
                                          #region Insert 1 dòng trống để chèn nhóm 2 vào
                                          COMExcel.Range RGroup2_Home_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data];
                                          COMExcel.Range RGroup2_End_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data + dtSource.Columns.Count];
                                          COMExcel.Range RGroup2_2 = exSheet.get_Range(RGroup2_Home_2, RGroup2_End_2);
                                          RGroup2_2.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);
                                          #endregion

                                          #region Fill Tên nhóm 2 với định dạng in đậm vào chiều cao *1.2
                                          COMExcel.Range r_2_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + 1];
                                          r_2_2.Value2 = (this.Total2_Name == null || this.Total2_Name == "" ? Dictionary.clDictionaryDB.sGetValueLanguage("Sub total of", this.Language) + " " + lstGroup2Value[GroupIndex2 - 1] : Dictionary.clDictionaryDB.sGetValueLanguage(Total2_Name));
                                          r_2_2.Font.Bold = true;
                                          r_2_2.RowHeight = dHeightTemp * 1.2;
                                          #endregion
                                          #region Merge cell từ ô đầu tiên đến cell có tính tổng
                                          COMExcel.Range r5_end_2_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtSource.Columns[lstSumName[0]].Ordinal - 1];
                                          COMExcel.Range RRR5_2_2 = exSheet.get_Range(r_2_2, r5_end_2_2);
                                          RRR5_2_2.Merge(null);
                                          #endregion
                                          #region Fill các tổng cộng vào
                                          for (int t = 0; t < lstSumName.Count; t++)
                                          {
                                              COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];

                                              rs.Value2 = lstGroupValue2[c2 - 1][t];
                                              rs.Font.Bold = true;
                                          }
                                          #endregion
                                          #region tăng số dòng lên 1
                                          c++;
                                          #endregion


                                      }
                                      #endregion
                                  }
                              }
                                #endregion
                              #endregion
                              #region Sau Đó làm bình thường
                              // ta sẽ lặp lại bước thêm một dòng nhóm và các giá trị tổng cộng của nó và fill vào một dòng dưới 
                              if (this.IsSumByGroup1)
                              {
                                  #region Insert 1 dòng trống để chèn nhóm 1 vào
                                  COMExcel.Range RGroup1_Home_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data];
                                  COMExcel.Range RGroup1_End_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data + dtSource.Columns.Count];
                                  COMExcel.Range RGroup1_2 = exSheet.get_Range(RGroup1_Home_2, RGroup1_End_2);
                                  RGroup1_2.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);
                                  #endregion
                                  #region Merge cell từ ô đầu tiên đến cell có tính tổng
                                  COMExcel.Range r_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data];
                                  COMExcel.Range r_end_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtSource.Columns[lstSumName[0]].Ordinal - 1];
                                  COMExcel.Range RRR_2 = exSheet.get_Range(r_2, r_end_2);
                                  RRR_2.Merge(null);
                                  #endregion
                                  #region Fill Tên nhóm 1 với định dạng in đậm vào chiều cao *1.2
                                  r_2.Value2 =(this.Total1_Name==null ||this.Total1_Name=="" ?  Dictionary.clDictionaryDB.sGetValueLanguage("Sub total of", this.Language)
                                      + " " + lstGroup1Value[GroupIndex1 - 1] :Dictionary.clDictionaryDB.sGetValueLanguage(this.Total1_Name));
                                  r_2.Font.Bold = true;
                                  r_2.RowHeight = dHeightTemp * 1.2;
                                  PrevRowIsGroup = true;
                                  #endregion
                                  #region Fill các giá trị tổng cộng vào
                                  for (int t = 0; t < lstSumName.Count; t++)
                                  {
                                      if (dtV.Columns.IndexOf(lstSumName[t]) != -1)
                                      {
                                          try
                                          {

                                              COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];

                                              rs.Value2 = lstGroupValue1[c1 - 1][t];

                                              rs.Font.Bold = true;
                                          }
                                          catch (Exception)
                                          {
                                          }
                                      }
                                  }//end for
                                  #endregion
                                  #region tăng lên một dòng như bình thường
                                  c++;
                                  #endregion

                              }

                                  }
                              #endregion
                          #endregion
                                  
                                      #region Insert 1 dòng trống để chèn nhóm 1 vào
                                      COMExcel.Range RGroup1_Home = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data];
                                      COMExcel.Range RGroup1_End = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data + dtSource.Columns.Count];
                                      COMExcel.Range RGroup1 = exSheet.get_Range(RGroup1_Home, RGroup1_End);
                                      RGroup1.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);
                                      #endregion
                                      #region Merge cell từ ô đầu tiên đến cell có tính tổng
                                      if (this.IsSumByGroup && this.lstSumName != null && this.lstSumName.Count > 0)
                                      {
                                          COMExcel.Range r = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data];
                                          int endGroup1Index = (this.IsSumByGroup && this.lstSumName != null && this.lstSumName.Count > 0 ? dtSource.Columns[lstSumName[0]].Ordinal : dtSource.Columns.Count);
                                          COMExcel.Range r_end = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data +endGroup1Index  - 1];
                                          COMExcel.Range RRR = exSheet.get_Range(r, r_end);
                                          RRR.Merge(null);

                                      #endregion
                                          #region Fill Tên nhóm 1 với định dạng in đậm vào chiều cao *1.2
                                          r.Value2 = lstGroup1Value[GroupIndex1];
                                          r.Font.Bold = true;
                                          r.RowHeight = dHeightTemp * 1.2;
                                          PrevRowIsGroup = true;
                                      #endregion
                                      #region Nếu có tổng cộng và có fill giá trị tổng lên nhóm
                                      if (this.lstSumName != null && this.lstSumName.Count > 0 && this.IsSumByGroup)
                                      {
                                          #region Nếu Fill các tổng lên cùng dòng của nhóm
                                          if (this.IsSumColumnInGroup)
                                          {
                                              for (int t = 0; t < lstSumName.Count; t++)
                                              {
                                                  if (dtV.Columns.IndexOf(lstSumName[t]) != -1)
                                                  {
                                                      try
                                                      {

                                                          COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];

                                                          rs.Value2 = lstGroupValue1[c1][t];

                                                          rs.Font.Bold = true;
                                                      }
                                                      catch (Exception)
                                                      {
                                                      }
                                                  }
                                              }//end for
                                          }
                                          #endregion

                                          c1++;
                                      }
                                      c++;
                                      #endregion
                                  }
                      }
                  #endregion
                  #region Nếu có nhóm 2 và dòng đầu tiên của nhóm 2 đã được tìm thấy
                      if (lstGroup2Index.Count > 0)
                      {
                          int GroupIndex2 = lstGroup2Index.IndexOf(i);
                          if (GroupIndex2 != -1)
                          {
                              #region Nếu đây là giá trị thứ 2 trở đi và đồng thời giá trị tổng cộng không cùng nằm trên nhóm
                              if (this.lstSumName != null && this.lstSumName.Count > 0 && this.IsSumByGroup && this.IsSumByGroup2 && !this.IsSumColumnInGroup && GroupIndex2 >= 1 && !IsFill_Group2)
                              {

                                  // kiểm tra xem dòng này được fill chưa 
                                  // ta sẽ lặp lại bước thêm một dòng nhóm và các giá trị tổng cộng của nó và fill vào một dòng dưới 
                                  #region Insert 1 dòng trống để chèn nhóm 2 vào
                                  COMExcel.Range RGroup2_Home_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data];
                                  COMExcel.Range RGroup2_End_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data + dtSource.Columns.Count];
                                  COMExcel.Range RGroup2_2 = exSheet.get_Range(RGroup2_Home_2, RGroup2_End_2);
                                  RGroup2_2.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);
                                  #endregion
                                  #region Fill Tên nhóm 2 với định dạng in đậm vào chiều cao *1.2
                                  COMExcel.Range r_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + 1];
                                  r_2.Value2 = Dictionary.clDictionaryDB.sGetValueLanguage("Sub total of", this.Language) + " " + lstGroup2Value[GroupIndex2 - 1];
                                  r_2.Font.Bold = true;
                                  r_2.RowHeight = dHeightTemp * 1.2;
                                  #endregion
                                  #region Merge cell từ ô đầu tiên đến cell có tính tổng
                                  COMExcel.Range r5_end_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtSource.Columns[lstSumName[0]].Ordinal - 1];
                                  COMExcel.Range RRR5_2 = exSheet.get_Range(r_2, r5_end_2);
                                  RRR5_2.Merge(null);
                                  #endregion
                                  #region Fill các tổng cộng vào
                                  for (int t = 0; t < lstSumName.Count; t++)
                                  {
                                      COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];

                                      rs.Value2 = lstGroupValue2[c2 - 1][t];
                                      rs.Font.Bold = true;
                                  }
                                  #endregion
                                  #region tăng số dòng lên 1
                                  c++;
                                  #endregion


                              }
                              #endregion
                              if (lstGroup2Value[GroupIndex2].ToString() != "")
                              {
                                  PrevRowIsGroup = true;
                                  #region Insert 1 dòng trống để chèn nhóm 2 vào
                                  COMExcel.Range RGroup2_Home = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data];
                                  COMExcel.Range RGroup2_End = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data + dtSource.Columns.Count];
                                  COMExcel.Range RGroup2 = exSheet.get_Range(RGroup2_Home, RGroup2_End);
                                  RGroup2.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);
                                  #endregion
                                  #region Fill Tên nhóm 2 với định dạng in đậm vào chiều cao *1.2
                                  COMExcel.Range r = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + 1];
                                  r.Value2 = lstGroup2Value[GroupIndex2];
                                  r.Font.Bold = true;
                                  r.RowHeight = dHeightTemp * 1.2;
                                  #endregion
                                  #region Merge cell từ ô đầu tiên đến cell có tính tổng
                                  int columnEndIndex2 = dtSource.Columns.Count;
                                  if (this.lstSumName != null && this.lstSumName.Count > 0)
                                      columnEndIndex2 = dtSource.Columns[lstSumName[0]].Ordinal;
                                  COMExcel.Range r5_end = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + columnEndIndex2 - 1];
                                  COMExcel.Range RRR5 = exSheet.get_Range(r, r5_end);
                                  RRR5.Merge(null);
                                  #endregion
                                  #region Nếu tổng cộng và có fill giá trị tổng trên cùng dòng chứa nhóm
                                  if (this.lstSumName != null && this.lstSumName.Count > 0 && this.IsSumByGroup)
                                  {
                                      #region Nếu dòng tổng cộng trên cùng dòng tên nhóm 2
                                      if (this.IsSumColumnInGroup)
                                      {
                                          for (int t = 0; t < lstSumName.Count; t++)
                                          {
                                              COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];

                                              rs.Value2 = lstGroupValue2[c2][t];
                                              rs.Font.Bold = true;
                                          }
                                      }
                                      #endregion

                                      c2++;
                                  }
                                  c++;
                              }
                                  #endregion
                          }
                      }
                  }
                      #endregion
                  #region Insert một dòng trống trước khi đổ dữ liệu vào từng dòng
                  try
                  {
                      COMExcel.Range RData_Home = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data];
                      COMExcel.Range RData_End = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data + dtSource.Columns.Count];
                      COMExcel.Range RData = exSheet.get_Range(RData_Home, RData_End);
                      RData.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);
                  }
                  catch (Exception) { }
                  #endregion
                  #region Đổ dữ liệu vào từng columns , tất nhiên là chỉ Column ko ẩn
                  #region Chạy từng cột (columns và đổ dữ liệu vào)

                  for (int j = 0; j < dt.Columns.Count; j++)
                  {
                      if (lstHidenColumnName == null || lstHidenColumnName.Count == 0 || lstHidenColumnName.IndexOf(dt.Columns[j].ColumnName) == -1)
                      {
                          if (lstGroupName == null || lstGroupName.Count == 0 || lstGroupName.IndexOf(dt.Columns[j].ColumnName) == -1)
                          {
                              #region Đổ dữ liệu vào từng Cột
                              try
                              {
                                  COMExcel.Range r = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + j];

                                  if (lstDataType[j].ToString().IndexOf("String") != -1)
                                  {
                                      string sss = dt.Rows[i][j].ToString();
                                      if (sss != "")
                                      {
                                          sss = sss.Replace("\r\n", "\n");
                                          string[] arrsss = sss.Split('\n');
                                          if (arrsss.Length > 1)
                                          {
                                              if (arrsss.Length > lstMaxRowL[i])
                                              {
                                                  lstMaxRowL[i] = arrsss.Length;
                                                  r.RowHeight = dHeightTemp * arrsss.Length;
                                              }
                                          }
                                          r.Value2 = sss;
                                      }
                                      else
                                          r.Value2 = null;
                                  }
                                  else
                                      r.Value2 = dt.Rows[i][j];
                              }
                              catch(Exception){ }
                              #endregion
                              #region Merge Row
                              if (this.lstColumnMergeRow != null && this.lstColumnMergeRow.Count > 0
                                  && this.lstColumnMergeRow.IndexOf(dt.Columns[j].ColumnName) != -1
                                  && PrevRowIsGroup == false && i >= 1)
                              {
                                  object PrevCell_Value = dtSource.Rows[i - 1][j];
                                  object CurrentCell_Value = dtSource.Rows[i][j];
                                  bool SameValue = false;
                                  if (lstDataType[j].ToString().IndexOf("String") != -1)
                                  {
                                      SameValue = (PrevCell_Value.ToString().Trim() != "" && PrevCell_Value.ToString().Trim().ToLower() == CurrentCell_Value.ToString().Trim().ToLower());
                                  }
                                  else
                                  {
                                      if (lstDataType[j].ToString().IndexOf("DateTime") != -1)
                                      {
                                          if (PrevCell_Value.ToString() == "") SameValue = false;
                                          if (CurrentCell_Value.ToString() == "") SameValue = false;
                                         string  s_PrevCell_Value = getDatefromString(PrevCell_Value.ToString()).ToString("yyyy-MM-dd");
                                         string  s_CurrentCell_Value = getDatefromString(CurrentCell_Value.ToString()).ToString("yyyy-MM-dd");
                                         SameValue = (s_PrevCell_Value == s_CurrentCell_Value);
                                      }
                                      else 
                                          SameValue = (PrevCell_Value == CurrentCell_Value);
                                  }
                                  if (SameValue)
                                  {
                                      COMExcel.Range R_MergeR1 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c - 1, Start_Col_Data + j];
                                      COMExcel.Range R_MergeR2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + j];
                                      COMExcel.Range R_Merge = exSheet.get_Range(R_MergeR1, R_MergeR2);
                                      R_MergeR1.Value2 = null;
                                      R_MergeR2.Value2 = null;
                                      R_Merge.Merge(null);
                                      R_Merge.Value2 = PrevCell_Value;
                                  }
                              }
                              #endregion
                              #region Set No (STT)
                              if (this.IsIndexColulmn != null && IsIndexColulmn!=""
                                 && this.IsIndexColulmn == dt.Columns[j].ColumnName
                                 && PrevRowIsGroup == false && i >= 1)
                              {
                                  object PrevCell_Value = dtSource.Rows[i - 1][j];
                                  object CurrentCell_Value = dtSource.Rows[i][j];
                                  bool SameValue = false;
                                  if (lstDataType[j].ToString().IndexOf("String") != -1)
                                  {
                                      SameValue = (PrevCell_Value.ToString().Trim() != "" && PrevCell_Value.ToString().Trim().ToLower() == CurrentCell_Value.ToString().Trim().ToLower());
                                  }
                                  else SameValue = (PrevCell_Value == CurrentCell_Value);
                                  if (SameValue)
                                  {
                                      COMExcel.Range R_MergeR3 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c - 1, Start_Col_Data];
                                      COMExcel.Range R_MergeR4 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data];
                                      COMExcel.Range R_Merge2 = exSheet.get_Range(R_MergeR3, R_MergeR4);
                                      R_MergeR3.Value2 = null;
                                      R_MergeR4.Value2 = null;
                                      R_Merge2.Merge(null);
                                      string sNewCount = NewCount.ToString();
                                      if (NewCount < 10) sNewCount = "0" + sNewCount;
                                      R_Merge2.Value2 = sNewCount;
                                  }
                                  else
                                  {
                                      NewCount++;
                                      COMExcel.Range R_STT = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data];
                                      string sNewCount = NewCount.ToString();
                                      if (NewCount < 10) sNewCount = "0" + sNewCount;
                                      R_STT.Value2 = sNewCount;

                                      
                                  }
                                  
                                  
                              }
                              
                              #endregion
                              #region là cột ẩn thì ẩn cột
                              //if (this.lstExcelHidenColumnName != null && this.lstExcelHidenColumnName.Count > 0 && this.lstExcelHidenColumnName.IndexOf(dt.Columns[j].ColumnName) != -1)
                              //{

                              //}
                              #endregion
                              #region Nếu là dòng cuối cùng có nội dung tổng cộng hoặc số dư
                              if ( j==dtSource.Columns.Count-1-(this.lstHidenColumnName!=null && this.lstHidenColumnName.Count>0? this.lstHidenColumnName.Count :0 ) && i==dtSource.Rows.Count-1 )
                              {
                                  string sss0 = dt.Rows[i][0].ToString().Trim().ToLower();
                                  string sss1 = null;
                                  if(this.dtSource.Columns.Count>1)
                                      sss1 = dt.Rows[i][1].ToString().Trim().ToLower();

                                  string NoiDung_Value=null;
                                    string NoiDung_Name = "";
                                  if (this.dtSource.Columns.IndexOf("NoiDung") != -1)
                                  {
                                      NoiDung_Name = "NoiDung";
                                  }
                                  if (this.dtSource.Columns.IndexOf("Description") != -1)
                                  {
                                      NoiDung_Name = "Description";
                                  }
                                  if (NoiDung_Name != "")
                                      NoiDung_Value = this.dtSource.Rows[i][NoiDung_Name].ToString().Trim().ToLower();

                                  string TotalName=Dictionary.clDictionaryDB.sGetValueLanguage("total", this.Language).ToLower();
                                  string SoduCC = Dictionary.clDictionaryDB.sGetValueLanguage("SoduCC", this.Language).ToLower();

                                  if (sss0 ==TotalName|| sss1==TotalName || sss0==SoduCC||sss1==SoduCC  || ( NoiDung_Name!="" && NoiDung_Value==SoduCC))
                                  {
                                      for (int t = 0; t < this.dtSource.Columns.Count; t++)
                                      {
                                          COMExcel.Range rs_AutoBold = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data +t   ];
                                          rs_AutoBold.Font.Bold = true;
                                      }

                                  }
                              }
                              #endregion
                              #region Nếu là dòng đầu tiên với nội dung là số dư đầu kỳ
                              if (j == dtSource.Columns.Count - 1 && i == 0)
                              {
                                  string NoiDung_Value = null;
                                  string NoiDung_Name = "";
                                  if (this.dtSource.Columns.IndexOf("NoiDung") != -1)
                                  {
                                      NoiDung_Name = "NoiDung";
                                  }
                                  if (this.dtSource.Columns.IndexOf("Description") != -1)
                                  {
                                      NoiDung_Name = "Description";
                                  }
                                  if (NoiDung_Name != "")
                                      NoiDung_Value = this.dtSource.Rows[i][NoiDung_Name].ToString().Trim().ToLower();


                                  string TotalName = Dictionary.clDictionaryDB.sGetValueLanguage("BeginningFigures", this.Language).ToLower();
                                  if (NoiDung_Value == TotalName)
                                  {
                                      for (int t = 0; t < this.dtSource.Columns.Count; t++)
                                      {
                                          COMExcel.Range rs_AutoBold = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + t];
                                          rs_AutoBold.Font.Bold = true;
                                      }

                                  }
                              }
                              #endregion
                              #region Nếu là dòng kế cuối với nội dung là tổng phát sinh
                              if (dtSource.Rows.Count >= 2 && j == dtSource.Columns.Count - 1-(this.lstHidenColumnName != null && this.lstHidenColumnName.Count > 0 ? this.lstHidenColumnName.Count : 0) && i == dtSource.Rows.Count - 2)
                              {
                                  string NoiDung_Name = "";
                                  if (this.dtSource.Columns.IndexOf("NoiDung") != -1)
                                  {
                                      NoiDung_Name = "NoiDung";
                                  }
                                  if (this.dtSource.Columns.IndexOf("Description") != -1)
                                  {
                                      NoiDung_Name = "Description";
                                  }
                                  if(NoiDung_Name!="")
                                  {
                                      string sss0 = dt.Rows[i][NoiDung_Name].ToString().Trim().ToLower();
                                      string TotalName = Dictionary.clDictionaryDB.sGetValueLanguage("SumArise", this.Language).ToLower();
                                      if (sss0 == TotalName )
                                      {
                                          for (int t = 0; t < this.dtSource.Columns.Count; t++)
                                          {
                                              COMExcel.Range rs_AutoBold = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + t];
                                              rs_AutoBold.Font.Bold = true;
                                          }

                                      }
                                  }
                              }
                                #endregion
                          }
                      }
                  }
                  #endregion
                  #region Nếu là dòng cuối cùng hãy kiểm tra và đưa dòng tổng cộng và nhóm 2 trong trường hợp IsSumInGroupRow=false
                  if (i == dtSource.Rows.Count - 1 && this.lstSumName != null && this.lstSumName.Count > 1 && this.IsSumByGroup &&  this.IsSumByGroup2 && !this.IsSumColumnInGroup)
                  {
                      #region tăng số dòng lên 1
                      c++;
                      #endregion
                      #region Insert 1 dòng trống để chèn nhóm 2 vào
                      COMExcel.Range RGroup2_Home_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data];
                      COMExcel.Range RGroup2_End_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c + 1, Start_Col_Data + dtSource.Columns.Count];
                      COMExcel.Range RGroup2_2 = exSheet.get_Range(RGroup2_Home_2, RGroup2_End_2);
                      RGroup2_2.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);
                      #endregion
                      #region Fill Tên nhóm 2 với định dạng in đậm vào chiều cao *1.2
                      COMExcel.Range r_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + 1];
                      r_2.Value2 = (this.Total2_Name==null ||this.Total2_Name==""?  Dictionary.clDictionaryDB.sGetValueLanguage("Sub total of", this.Language) + " " + lstGroup2Value[lstGroup2Value.Count-1 ]:Dictionary.clDictionaryDB.sGetValueLanguage(Total2_Name));
                      r_2.Font.Bold = true;
                      r_2.RowHeight = dHeightTemp * 1.2;
                      #endregion
                      #region Merge cell từ ô đầu tiên đến cell có tính tổng
                      COMExcel.Range r5_end_2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtSource.Columns[lstSumName[0]].Ordinal - 1];
                      COMExcel.Range RRR5_2 = exSheet.get_Range(r_2, r5_end_2);
                      RRR5_2.Merge(null);
                      #endregion
                      #region Fill các tổng cộng vào
                      for (int t = 0; t < lstSumName.Count; t++)
                      {
                          COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];

                          rs.Value2 = lstGroupValue2[c2 - 1][t];
                          rs.Font.Bold = true;
                      }
                      #endregion
                      
                  }
#endregion
                  #region Nếu là dòng cưối cùng  hãy kiểm tra và đưa dòng tổng cộng và nhóm 1 trong trường hợp IsSumInGroupRow=false
                  if (i == dtSource.Rows.Count - 1 && this.lstSumName != null && this.lstSumName.Count > 0 && this.IsSumByGroup &&this.IsSumByGroup1  && !this.IsSumColumnInGroup)
                  {
                      #region Làm lại thao tác giống như ban đầu
                      c++;
                      #region Insert 1 dòng trống để chèn nhóm 1 vào
                      COMExcel.Range RGroup1_Home = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c , Start_Col_Data];
                      COMExcel.Range RGroup1_End = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c , Start_Col_Data + dtSource.Columns.Count];
                      COMExcel.Range RGroup1 = exSheet.get_Range(RGroup1_Home, RGroup1_End);
                      RGroup1.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);
                      
                      #endregion 
                      #region Merge cell từ ô đầu tiên đến cell có tính tổng
                      COMExcel.Range r = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data];
                      COMExcel.Range r_end = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtSource.Columns[lstSumName[0]].Ordinal - 1];
                      COMExcel.Range RRR = exSheet.get_Range(r, r_end);
                      RRR.Merge(null);
                      #endregion
                      #region Fill Tên nhóm 1 với định dạng in đậm vào chiều cao *1.2
                      r.Value2 =( this.Total1_Name==null ||this.Total1_Name=="" ? Dictionary.clDictionaryDB.sGetValueLanguage("Sub total of", this.Language)
                          + " " + lstGroup1Value[lstGroup1Value.Count - 1] :Dictionary.clDictionaryDB.sGetValueLanguage(Total1_Name));
                      r.Font.Bold = true;
                      r.RowHeight = dHeightTemp * 1.2;
                      PrevRowIsGroup = true;
                      #endregion
                      #region Fill tổng cộng
                      c1--;
                      for (int t = 0; t < lstSumName.Count; t++)
                              {
                                  if (dtV.Columns.IndexOf(lstSumName[t]) != -1)
                                  {
                                      try
                                      {

                                          COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];

                                          rs.Value2 = lstGroupValue1[c1][t];

                                          rs.Font.Bold = true;
                                      }
                                      catch (Exception)
                                      {
                                      }
                                  }
                              }//end for
                      #endregion
                   }
                      #endregion
                  #endregion
                  #endregion
                  #region MergeRows =merge những cell lại theo chỉ định
                  if (this.lstMergeRow_ != null && this.lstMergeRow_.Count > 0 )
                  {
                      int n_MergerRow = MergeRow.IndexOf_(i, this.lstMergeRow_);
                      if (n_MergerRow != -1)
                      {
                          MergeRow MergRowT = this.lstMergeRow_[n_MergerRow];
                          if (dtSource.Columns.IndexOf(MergRowT.StartColumnName) != -1 && dtSource.Columns.IndexOf(MergRowT.EndColumnName) != -1)
                          {
                              try
                              {
                                  COMExcel.Range R_MergeR1 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c , Start_Col_Data + dtSource.Columns[MergRowT.StartColumnName].Ordinal];
                                  COMExcel.Range R_MergeR2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + i + c, Start_Col_Data + dtSource.Columns[MergRowT.EndColumnName].Ordinal];
                                  COMExcel.Range R_Merge = exSheet.get_Range(R_MergeR1, R_MergeR2);
                                  R_MergeR1.Value2 = null;
                                  R_MergeR2.Value2 = null;
                                  R_Merge.Merge(null);
                                  R_Merge.Value2 = dtSource.Rows[i][MergRowT.StartColumnName];

                              }
                              catch(Exception)
                              {
                              }
                          }
                      }
                  }
                  #endregion
                }
                  
             
              #endregion
                if (!this.IsDeleteTotalRow)
                {
                    #region Tinh Tong Cuoi Cung
                    if (this.lstSumName != null && lstSumName.Count != 0)
                    {

                        List<double> lstTemp2 = new List<double>();
                        for (int b = 0; b < lstSumName.Count; b++)
                            lstTemp2.Add(0);
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {

                            for (int m = 0; m < lstSumName.Count; m++)
                            {
                                string stemp = dt.Rows[j][lstSumName[m]].ToString();
                                if (stemp == "") stemp = "0";
                                try
                                {
                                    if (stemp.IndexOf("\n") == -1)
                                    {
                                        double d = double.Parse(stemp);
                                        lstTemp2[m] += d;
                                    }
                                    else
                                    {
                                        stemp = stemp.Replace("\r", "");
                                        string[] arrTempI = stemp.Split('\n');
                                        for (int nn = 0; nn < arrTempI.Length; nn++)
                                        {
                                            if (arrTempI[nn] != "")
                                            {
                                                double dd = double.Parse(arrTempI[nn]);
                                                lstTemp2[m] += dd;
                                            }
                                        }
                                    }
                                }
                                catch (Exception) { }
                            }
                        }
                        COMExcel.Range RAmount_Home = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dtSource.Rows.Count + c + 1, Start_Col_Data];
                        COMExcel.Range RAmount_End = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dtSource.Rows.Count + c + 1, Start_Col_Data + dtSource.Columns.Count];
                        COMExcel.Range RAmount = exSheet.get_Range(RAmount_Home, RAmount_End);
                        RAmount.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);

                        if (!this.IsHideTotal)
                        {
                            COMExcel.Range rT = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dt.Rows.Count + c, Start_Col_Data];
                            rT.Value2 = Dictionary.clDictionaryDB.sGetValueLanguage("TOTAL", this.Language);
                            rT.Font.Bold = true;
                            rT.RowHeight = dHeightTemp * 1.2;

                            COMExcel.Range r2_end = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dt.Rows.Count + c, Start_Col_Data + dtSource.Columns[lstSumName[0]].Ordinal - 1];
                            COMExcel.Range RRR2 = exSheet.get_Range(rT, r2_end);
                            RRR2.Merge(null);
                            for (int t = 0; t < lstSumName.Count; t++)
                            {
                                COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dt.Rows.Count + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];
                                rs.Value2 = lstTemp2[t];
                                rs.Font.Bold = true;
                            }
                            #region Nếu có một dòng VAT
                            if (this.VATAllField_Show)
                            {
                                #region Chỉnh lại tên Total =Amount
                                rT.Value2 = Dictionary.clDictionaryDB.sGetValueLanguage("Amount", this.Language);
                                #endregion
                                #region Thêm dòng trống mới
                                c++;
                                COMExcel.Range RVAT_Home = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dtSource.Rows.Count + c + 1, Start_Col_Data];
                                COMExcel.Range RVAT_End = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dtSource.Rows.Count + c + 1, Start_Col_Data + dtSource.Columns.Count];
                                COMExcel.Range RVAT = exSheet.get_Range(RVAT_Home, RVAT_End);
                                RVAT.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);

                                #endregion
                                #region Thêm Cell VAT
                                COMExcel.Range rT2 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dt.Rows.Count + c, Start_Col_Data];
                                rT2.Value2 = Dictionary.clDictionaryDB.sGetValueLanguage("VAT", this.Language) + VATAllPercent.ToString() + " %";
                                rT2.Font.Bold = true;
                                rT2.RowHeight = dHeightTemp * 1.2;
                                COMExcel.Range r3_end = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dt.Rows.Count + c, Start_Col_Data + dtSource.Columns[lstSumName[0]].Ordinal - 1];
                                COMExcel.Range RRR3 = exSheet.get_Range(rT2, r3_end);
                                RRR3.Merge(null);


                                #endregion
                                #region Tính và đưa tiền VAT vào
                                for (int t = 0; t < lstSumName.Count; t++)
                                {
                                    COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dt.Rows.Count + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];
                                    if (VATAllPercent != 0)
                                        rs.Value2 = double.Parse(lstTemp2[t].ToString()) * (double.Parse(VATAllPercent.ToString()) / 100);
                                    else
                                        rs.Value2 = 0;
                                    rs.Font.Bold = true;
                                    if (this.lstColumnNotVAT != null && this.lstColumnNotVAT.Count > 0)
                                    {
                                        if (this.lstColumnNotVAT.IndexOf(lstSumName[t]) != -1)
                                            rs.Value2 = 0;
                                    }
                                }
                                #endregion
                                #region Thêm dòng trống
                                c++;
                                COMExcel.Range RTOTAL_Home = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dtSource.Rows.Count + c + 1, Start_Col_Data];
                                COMExcel.Range RTOTAL_End = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dtSource.Rows.Count + c + 1, Start_Col_Data + dtSource.Columns.Count];
                                COMExcel.Range RTOTAL = exSheet.get_Range(RTOTAL_Home, RTOTAL_End);
                                RTOTAL.Insert(COMExcel.XlInsertShiftDirection.xlShiftDown, COMExcel.XlOrientation.xlDownward);

                                #endregion
                                #region Thêm Cell Total
                                COMExcel.Range rT3 = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dt.Rows.Count + c, Start_Col_Data];
                                rT3.Value2 = Dictionary.clDictionaryDB.sGetValueLanguage("Total", this.Language);
                                rT3.Font.Bold = true;
                                rT3.RowHeight = dHeightTemp * 1.2;
                                COMExcel.Range r4_end = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dt.Rows.Count + c, Start_Col_Data + dtSource.Columns[lstSumName[0]].Ordinal - 1];
                                COMExcel.Range RRR4 = exSheet.get_Range(rT3, r4_end);
                                RRR4.Merge(null);

                                #endregion
                                #region Tính và đưa Total
                                for (int t = 0; t < lstSumName.Count; t++)
                                {
                                    COMExcel.Range rs = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dt.Rows.Count + c, Start_Col_Data + dtV.Columns[lstSumName[t]].Ordinal];
                                    if (VATAllPercent != 0)
                                        rs.Value2 = (double)lstTemp2[t] + double.Parse(lstTemp2[t].ToString()) * (double.Parse(VATAllPercent.ToString()) / 100);
                                    else
                                        rs.Value2 = lstTemp2[t];
                                    rs.Font.Bold = true;


                                    if (this.lstColumnNotVAT != null && this.lstColumnNotVAT.Count > 0)
                                    {
                                        if (this.lstColumnNotVAT.IndexOf(lstSumName[t]) != -1)
                                            rs.Value2 = lstTemp2[t];
                                    }

                                }

                                #endregion
                            }
                            #endregion
                        }
                    }
                    #endregion
                }
              #region Xoa Not Dong Cuoi cung trong

              COMExcel.Range REnd_Home = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dtSource.Rows.Count + c+1 , Start_Col_Data];
              COMExcel.Range REnd_End = (COMExcel.Range)exSheet.Cells[Start_Row_Data + dtSource.Rows.Count + c +2, Start_Col_Data + dtSource.Columns.Count];
              COMExcel.Range REnd = exSheet.get_Range(REnd_Home, REnd_End);
              REnd.Delete(COMExcel.XlDeleteShiftDirection.xlShiftUp);

               



              #endregion
              #region Fill Row Header Text
              if (this.lstRowHeaderName != null && this.lstRowHeaderName.Count != 0)
              {
                  if (this.RowHeaderIndex == null)
                  {
                      this.RowHeaderIndex = new CellIndex(1, 1);
                  }
                  for (int i = 0; i < lstRowHeaderName.Count; i++)
                  {
                      COMExcel.Range r = (COMExcel.Range)exSheet.Cells[RowHeaderIndex.Row, RowHeaderIndex.Col + i];
                      r.Value2 = lstRowHeaderName[i];
                  }
              }
              #endregion
          }
          #endregion
          #endregion
          #region Fill other Value
          if (lstOtherValues != null && lstOtherValues.Count > 0)
          {
              for (int i = 0; i < lstOtherValues.Count; i++)
              {
                  if (lstOtherIndex[i] != null)
                  {
                      if (this.dtSource != null && this.dtSource.Rows.Count > 0)
                      {
                          if (lstOtherIndex[i].Row > this.Start_Row_Data)
                              lstOtherIndex[i].Row += this.dtSource.Rows.Count + c-1 ;
                      }
                      try
                      {
                          COMExcel.Range r = (COMExcel.Range)exSheet.Cells[lstOtherIndex[i].Row, lstOtherIndex[i].Col];
                          r.Value2 = lstOtherValues[i];
                      }
                      catch (Exception) { }
                  }
              }
          }

          #endregion
        
      }
      //───────────────────────────────────────────────────
      private static System.Web.UI.Page tempP = new Page();
      public void ExportThead()
      {
         
          COMExcel.Application exApp = new COMExcel.Application();
          COMExcel.Workbook exBook = exApp.Workbooks.Open(SourceFile,
                                      0,true , 5, "", "", true, COMExcel.XlPlatform.xlWindows, "",
                                      true, false, 0, true, false, false);
          this.exSheet = (COMExcel.Worksheet)exBook.Worksheets[1];
          exSheet.Activate();
     
          
          try
          {
          this.ExportTable();
          this.OnExitThread();

          if (System.IO.File.Exists(DestinationFile)) System.IO.File.Delete(DestinationFile);
              exBook.SaveAs(DestinationFile, COMExcel.XlFileFormat.xlWorkbookNormal,
              null, null, false, false,
              COMExcel.XlSaveAsAccessMode.xlExclusive,
              false, false, false, false, false);
              exBook.Close(false, false, false);
              exApp.Quit();
          System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
          System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
          this.OnAfterReport();
      }
      catch (Exception) {
          try
          {
              this.OnExitThread();
              exApp.Quit();
              System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
              System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
          }
          catch (Exception E) 
          {
          }

      }
      }//end void
      //───────────────────────────────────────────────────
    
      public enum ShowType
      {
          Print,
          PrintPrevview,
          ExcelFile,
          Nothing,
          Question

      }
      #region ExitThreadHandle
      public delegate void ExitThreadHandle();
      public event ExitThreadHandle ExitThread;
      private void OnExitThread()
      {
          if (ExitThread != null)
          {
              ExitThread();
          }
      }
      #endregion
      public static DateTime getDatefromString(string sValue)
      {
          if (sValue == null || sValue == "") return DateTime.Now;
          return DateTime.Parse(sValue);
      }
    }//end class
}//end name space

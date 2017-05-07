using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for StaticData
/// </summary>
public class StaticData_thuoc
{
    public static string TenCty
    {

        get
        {
            DataTable dt = DataAcess.Connect.GetTable("SELECT Ten_Cty FROM TieuDeCty");
            if (dt == null || dt.Rows.Count == 0) return "";
            return dt.Rows[0]["Ten_Cty"].ToString();
        }
    }
    public static string TenHinhNen
    {
        get
        {
            return GetParameter("TenHinhNen");
        }
    }
    public static string GetParameter(string ParamterName)
    {
        return GetParaValueDB(ParamterName);

    }
    public static string KhoThuocBHYT
    {
        get
        {
            return GetParaValueDB("KhoThuocBHYT");

        }
    }
    public static string KhoThuocDV
    {
        get
        {
            return GetParaValueDB("KhoThuocDV");

        }
    }
    public static string KhoThuocTE
    {
        get
        {
            return GetParaValueDB("KhoThuocBHYTTE");

        }
    }
    public static string TenHeader(System.Web.UI.Page p)
    {
        
            string NhomND = SysParameter.UserLogin.GroupID(p);
            string TenMenu = "QUẢN LÝ NHÀ THUỐC";
            switch (NhomND)
            {
                case "7": TenMenu = "QUẢN LÝ KHOA DƯỢC"; break;
                case "8": TenMenu = "QUẢN LÝ QUẦY PHÁT THUỐC BHYT"; break;
                case "10": TenMenu = "QUẢN LÝ DƯỢC NỘI TRÚ"; break;
            }
            return TenMenu;
         
    }
    public static string PhieuNhapStyle
    {
        get
        {


            return GetParaValueDB("PhieuNhapStyle");
        }
    }
    public static string PageHomeLink
    {
        get
        {

            string s = GetParaValueDB("pagehomelink_NT");
            if (s == null || s == "") return "index.aspx";
            return s;

        }
    }
    public static string MaDonViKhoaDuoc
    {
        get
        {


            return GetParaValueDB("MaDonViKhoaDuoc");
        }
    }
    public static string MacDinhKhoNhapMuaID
    {
        get
        {
            return GetParaValueDB("KhoNhapMuaID");
        }
    }
    public static  string ChoPhepChonKhoNhapMua
    {
        get
        {
            string sChoPhepChonKhoNhapMua = GetParaValueDB("ChoPhepChonKhoNhapMua");
            if (sChoPhepChonKhoNhapMua == "1") return "false";
            else return "true";
        }
    }
    public static string MacDinhLyDoXuatKho
    {
        get
        {
            return GetParaValueDB("MacDinhLyDoXuatKho");
        }
    }
    public static string DiaChiXuat
    {
        get
        {
            return GetParaValueDB("DiaChiXuat");
        }
    }
    public static string TenThuKho
    {
        get
        {
            return GetParaValueDB("TenThuKho");
        }
    }
    public static string TenKeToanTruong
    {
        get
        {
            return GetParaValueDB("TenKeToanTruong");
        }
    }
    public static string TenThuTruong
    {
        get
        {
            return GetParaValueDB("TenThuTruong");
        }
    }
    public static string TenTruongKhoaDuoc
    {
        get
        {
            return GetParaValueDB("TenTruongKhoaDuoc");
        }
    }
    public static string TenPhieuXuatbanLe
    {
        get
        {
            return GetParaValueDB("TenPhieuXuatbanLe");
        }
    }
    public static string MacDinhTenThaoTacXuat
    {
        get
        {
            return GetParaValueDB("MacDinhTenThaoTacXuat");
        }
    }
    public static bool ChoPhepXuatToaCu
    {
        get
        {
            string  S= GetParaValueDB("ChoPhepXuatToaCu");
            if (S == "1") return true;
            return false;

        }
    }
    public static string NguoiThuQuy
    {
        get
        {
            return GetParaValueDB("NguoiThuQuy");
        }
    }
    public static string TimeDescription(string TuNgay, string DenNgay )
    {
        bool IsLongFormatMonth = false;
        return TimeDescription(TuNgay, DenNgay, IsLongFormatMonth);
    }
    public static string TimeDescription(string TuNgay,string DenNgay,bool IsLongFormatMonth)
    {
        #region lấy từ ngày tới ngày
        string TuNgayToiNgay = "";
        if (TuNgay != null && TuNgay != "")
            TuNgayToiNgay = "Từ ngày: " + DateTime.Parse(TuNgay).ToString("dd/MM/yyyy") + " ";
        if (DenNgay != null && DenNgay != "")
            TuNgayToiNgay += "Đến  ngày: " + DateTime.Parse(DenNgay).ToString("dd/MM/yyyy");
        if (TuNgay != null && TuNgay != "" && DenNgay != null && DenNgay != "")
        {
            DateTime dTuNgay = DateTime.Parse(TuNgay);
            DateTime dDenNgay = DateTime.Parse(DenNgay);
            if (dTuNgay.Year == dDenNgay.Year & dTuNgay.ToString("dd-MM") == "01-01" && dDenNgay.ToString("dd-MM") == "31-12")
                return "Năm " + dDenNgay.Year.ToString();

            if (dTuNgay.Month != dDenNgay.Month && dTuNgay.Day == 1 && dDenNgay.Day == DateTime.DaysInMonth(dDenNgay.Year, dDenNgay.Month))
            {
                if (dTuNgay.Year == dDenNgay.Year)
                    return "Từ tháng " + dTuNgay.ToString("MM") + " đến tháng " + dDenNgay.ToString("MM") + " năm " + dDenNgay.Year.ToString();
                else
                    return "Từ tháng " + dTuNgay.ToString("MM/yyyy") + " đến tháng " + dDenNgay.ToString("MM/yyyy");

            }

            if (DateTime.Parse(TuNgay).ToString("dd/MM/yyyy") == DateTime.Parse(DenNgay).ToString("dd/MM/yyyy"))
                TuNgayToiNgay = "Ngày: " + DateTime.Parse(TuNgay).ToString("dd/MM/yyyy");
            if (dTuNgay.Year == dDenNgay.Year && dTuNgay.Month == dDenNgay.Month && dTuNgay.Day == 1 && dDenNgay.Day == DateTime.DaysInMonth(dDenNgay.Year, dDenNgay.Month))
            {
                if (!IsLongFormatMonth)
                    TuNgayToiNgay = "Tháng: " + dTuNgay.ToString("MM/yyyy");
                else
                    TuNgayToiNgay = "Tháng " + dTuNgay.ToString("MM") + " năm " + dTuNgay.Year.ToString();

            }
        }
        if ((TuNgay == null || TuNgay == "") && (DenNgay == null || DenNgay == ""))
            TuNgayToiNgay = "Đến ngày :" + DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyyy");
        return TuNgayToiNgay;
        #endregion
    }
    public static bool IsNumber(string S)
    {
        if (S == null || S == "") return false;
        char[] C = S.ToCharArray();

        int i = 0; bool temp = true;
        if (C[0] == '-') i = 1;
        while (i < S.Length && temp)
        {
            if (!char.IsNumber(C[i])) temp = false;
            else i++;
        }
        return temp;
    }//end void
    public static string IntelName(string sValue)
    {
        if (sValue == null || sValue == "") return sValue;
        string s = "";
        string[] arr = sValue.Split(' ');

        for (int i = 0; i < arr.Length; i++)
        {

            string s1 = arr[i];
            if (s1 != "")
            {
                s += s1[0].ToString().ToUpper();

                for (int j = 1; j < s1.Length; j++)
                {
                    if (j >= 1 && IsNumber(s1[j - 1].ToString()))
                        s += s1[j].ToString().ToUpper();
                    else
                        s += s1[j].ToString().ToLower();
                }
                s += " ";
            }
        }
        s = s.Remove(s.Length - 1, 1);
        return s;
    }
    public static string[] arr1 = new string[] { "ứ", "ẽ", "ỳ", "ị", "ễ", "ọ", "à", "ũ", "ủ", "ạ", "ị", "à", "ả", "ố", "Nguyễn", "Thúy", "Hằng", "Bé", "Sáu", "NGỌC", "HUẤN", "Thành", "Trần", "Cẩn", "BÍCH", "HƯỜNG", "THỊ", "HOÀNG", "ỗ", "Ồ" };
    public static string[] arr2 = new string[] { "ứ", "ẽ", "ỳ", "ị", "ễ", "ọ", "à", "ũ", "ủ", "ạ", "ị", "à", "ả", "ố", "Nguyễn", "Thúy", "Hằng", "Bé", "Sáu", "Ngọc", "Huấn", "Thành", "Trần", "Cẩn", "Bích", "Hường", "Thị", "Hoàng", "ỗ", "Ồ" };
    public static string s_GetNameNotSign(string s_Value)
    {
        
        for (int k = 0; k < arr1.Length; k++)
            s_Value = s_Value.Replace(arr1[k], arr2[k]);

        s_Value = s_Value.ToLower(); 
        
        char[] cut = s_Value.ToCharArray();
        string a = "";
        for (int i = 0; i <= cut.Length - 1; i++)
        {
            a = cut[i].ToString();
            switch (a)
            {
                 
                    
                case "á":
                case "à":
                case "ả":
                case "ã":
                case "ạ":
                case "ă":
                case "ắ":
                case "ằ":
                case "ẳ":
                case "ẵ":
                case "ặ":
                case "â":
                case "ấ":
                case "ầ":
                case "ẩ":
                case "ẫ":
                case "ậ":
                    cut[i] = 'A'; break;
                case "ú":
                case "ù":
                case "ủ":
                case "ũ":
                case "ụ":
                case "ứ":
                case "ừ":
                case "ử":
                case "ữ":
                case "ự":
                case "ư":
                    cut[i] = 'U'; break;
                case "ó":
                case "ò":
                case "ỏ":
                case "õ":
                case "ọ":
                case "ơ":
                case "ớ":
                case "ờ":
                case "ở":
                case "ỡ":
                case "ợ":
                case "ô":
                case "ố":
                case "ồ":
                case "ổ":
                case "ỗ":
                case "ộ":
                    cut[i] = 'O'; break;
                case "é":
                case "è":
                case "ẻ":
                case "ẽ":
                case "ẹ":
                case "ê":
                case "ề":
                case "ế":
                case "ể":
                case "ễ":
                case "ệ":
                    cut[i] = 'E'; break;
                case "í":
                case "ì":
                case "ỉ":
                case "ĩ":
                case "ị":
                    cut[i] = 'I'; break;
                case "ý":
                case "ỳ":
                case "ỷ":
                case "ỹ":
                case "ỵ":
                    cut[i] = 'Y'; break;
                case "đ": cut[i] = 'D'; break;
            }

        }//end for
        string sUserName = "";
        for (int j = 0; j < cut.Length; j++)
        {
            sUserName = sUserName + cut[j].ToString().ToLower();
        }
        return sUserName;
    }
    public static int int_Search(DataTable dtSearch, string s_Filter)
    {
        try
        {
            DataRow[] DR = dtSearch.Select(s_Filter);
            if (DR.Length == 0) return -1;
            return dtSearch.Rows.IndexOf(DR[0]);
        }
        catch (Exception)
        {
            return -1;
        }
    }
    #region lam tron
    public static string RoundMoney(string giaban)
    {
        giaban = giaban.Replace(",", "");
        if (giaban.Length >= 4)
        {
            string s1 = giaban.Substring(0, giaban.Length - 3);
            string s2 = giaban.Substring(giaban.Length - 3, 3);
            int nS2 = int.Parse(s2);
            int nS1 = int.Parse(s1);
            if (nS2 >= 500)
            {
                nS1++;
            }
            giaban = nS1.ToString() + "000";
        }
        return giaban;
    }
    #endregion
    public static bool OutputCodeIsNumber
    {
        get
        {
            string OK = GetParameter("OutputCodeIsNumber");
            if (OK == "1") return true;
            return false;
        }
    }
    public static int LenghtOfOutputCode
    {
        get
        {
            string Len = GetParameter("LengOfOutputCode");
            if (Len != null && Len != "")
                return int.Parse(Len);
            return 6;
        }
    }
    public static string StartedOutputCodeBHYT
    {
        get
        {
            string s = GetParameter("StartedOutputCodeBHYT");
            if (s == null || s == "") return "0";
            if (!IsNumber(s)) return "0";
            return s;
        }
    }
    public static string DiachiNhapDefault
    {
        get
        {
            return GetParameter("DiaChiNhap");
        }
    }
    public static string MacDinhLyDoNhapKho
    {
        get
        {
            return GetParameter("MacDinhLyDoNhapKho");
        }
    }
    public static string NewOutputCode
    {
        get
        {
            string sqlSelect = "SELECT MAX(MAPHIEUXUAT) FROM PHIEUXUATKHO ";
            DataTable DT = DataAcess.Connect.GetTable(sqlSelect);
            if (DT == null || DT.Rows.Count == 0) return "0";
            string s = DT.Rows[0][0].ToString();
            if (s == "") s = "0";
            if (!IsNumber(s)) return "0";
            int d = int.Parse(s);
            if (d == 0) d = int.Parse(StartedOutputCodeBHYT);
            d++;
            int Len = LenghtOfOutputCode;
            string NewCode = "000000000000000000000000".Substring(0, Len - d.ToString().Length) + d.ToString();
            return NewCode;
        }
    }
    static public void DisPoseReport(ReportDocument report)
    {
        if (report != null)
        {
            report.Close();
            report.Clone();
            report.Dispose();
            GC.Collect();
        }
    }
    #region Other function
    public static void SetFocus(Page pParent, string sControlID)
    {
        string strScript;
        strScript = "<script language=javascript> document.all(\'";
        strScript = strScript + sControlID;
        strScript = strScript + "\').focus() </script>";
        pParent.RegisterStartupScript("focus", strScript);
    }
    public static void SetFocus(System.Web.UI.UserControl pParent, string sControlID)
    {
        string strScript;
        strScript = "<script language=javascript> document.all(\'";
        strScript = strScript + sControlID;
        strScript = strScript + "\').focus() </script>";
        pParent.Page.RegisterStartupScript("focus", strScript);
    }

    public static void MsgBox(Page pParent, string StrText)
    {
        string strScript = "alert (\'" + StrText + "\');";
        ScriptManager.RegisterStartupScript(pParent, pParent.GetType(), null, strScript, true);
    }
    public static void MsgComfirm(Page pParent, string StrText)
    {
        string strScript;
        strScript = " <script language=JavaScript> ";
        strScript += "if (confirm(\"Bạn có muốn xóa mẫu tin này không?\") == true)return true; else return false;";
        strScript += "</script>";
        pParent.RegisterStartupScript("test", strScript);
    }
    public static void MsgBox(System.Web.UI.UserControl pParent, string StrText)
    {
        string strScript = "alert (\'" + StrText + "\');";
        ScriptManager.RegisterStartupScript(pParent, pParent.GetType(), null, strScript, true);
    }
    public static int ParseInt(object ojb)
    {
        try
        {
            if (ojb == DBNull.Value) return 0;
            if (ojb == null) return 0;
            if (ojb.ToString() == "") return 0;
            if (ojb.ToString().Split('.').Length > 1)
                ojb =Math.Round(double.Parse(ojb.ToString()));
            return int.Parse(ojb.ToString());
        }
        catch(Exception ex)
        {
            return 0;
        }
    }
    public static int nvk_ParseInt_TraThuoc(object ojb)
    {
        try
        {
            if (ojb == DBNull.Value) return 0;
            if (ojb == null) return 0;
            if (ojb.ToString() == "") return 0;
            if (ojb.ToString().Split('.').Length > 1)
                ojb = Math.Round(double.Parse(ojb.ToString()) - 0.4);
            return int.Parse(ojb.ToString());
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
    //==============================================================
    public static float ParseFloat(object ojb)
    {
        try
        {
            return float.Parse(ojb.ToString());
        }
        catch
        {
            return 0;
        }
    }
    public static void FillCombo(DropDownList ComboboxName, string strSQL)
    {
        try
        {
            if (strSQL == "")
            {
                return;
            }
            DataTable dt = DataAcess.Connect.GetTable(strSQL);
            ComboboxName.DataSource = null;
            ComboboxName.Items.Clear();
            if (dt == null)
            {
                return;
            }
            if (dt.Columns.Count > 1)
            {
                ComboboxName.DataValueField = dt.Columns[0].ColumnName.ToString();
                ComboboxName.DataTextField = dt.Columns[1].ColumnName.ToString();
            }
            else
            {
                ComboboxName.DataValueField = dt.Columns[0].ColumnName.ToString();
                ComboboxName.DataTextField = dt.Columns[1].ColumnName.ToString();
            }
            ComboboxName.DataSource = dt;
            ComboboxName.SelectedIndex = -1;
        }
        catch (Exception)
        {
        }
    }

    public static void FillCombo(DropDownList ComboboxName, DataTable dt, string DataValueField, string DataTextField, string DataTextEmpty)
    {
        DataRow Item;
        ComboboxName.Items.Clear();
        ComboboxName.Items.Add(new ListItem(DataTextEmpty, "0"));
        //ThuanNH sua 06/05/2010
        try
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow tempLoopVar_Item in dt.Rows)
                {
                    Item = tempLoopVar_Item;
                    ComboboxName.Items.Add(new ListItem(System.Convert.ToString(Item[DataTextField]), System.Convert.ToString(Item[DataValueField])));
                }
            }
        }
        catch (Exception)
        {

        }
    }

    public static void FillCombo(DropDownList ComboboxName, DataTable dt, string DataValueField, string DataTextField)
    {
        if (dt == null)
        {
            return;
        }
        try
        {
            ComboboxName.DataSource = null;
            ComboboxName.Items.Clear();
            if (DataValueField == "")
            {
                if (dt.Columns.Count > 1)
                {
                    ComboboxName.DataValueField = dt.Columns[0].ColumnName.ToString();
                    ComboboxName.DataTextField = dt.Columns[1].ColumnName.ToString();
                }
                else
                {
                    ComboboxName.DataValueField = dt.Columns[0].ColumnName.ToString();
                    ComboboxName.DataTextField = dt.Columns[0].ColumnName.ToString();
                }
            }
            else
            {
                ComboboxName.DataValueField = dt.Columns[DataValueField].ColumnName.ToString();
                ComboboxName.DataTextField = dt.Columns[DataTextField].ColumnName.ToString();
            }
            ComboboxName.DataSource = dt;
            ComboboxName.SelectedIndex = -1;
            ComboboxName.DataBind();
        }
        catch (Exception)
        {
        }
    }
    public static string CheckDate(string strDate)
    {
        if (strDate == null || strDate == "" || strDate.Length<"29-06-2011".Length)
        {
            return "";
        }
        return strDate.Substring(6, 4) + "-" + strDate.Substring(3, 2) + "-" + strDate.Substring(0, 2);
    }
    static public int GetSoNgay(int iThang, int iNam)
    {
        return DateTime.DaysInMonth(iNam, iThang);
    }
    static public string CreateIDTheoThuTuTN(string sBegin, string sTableName, string sFieldMa, string sFieldOrder, string ngaytn)
    {

        string dates = ngaytn;
        string skq = "";
        //ThuanNH 10/05/2010 - Sua cach tao lai ma
        string ssql = "SELECT TOP 1 " + sFieldMa + " FROM " + sTableName + " WHERE " + sFieldMa + " LIKE '%" + dates + "%'" + " AND " + sFieldMa + " LIKE '" + sBegin + "%' ORDER BY " + sFieldOrder + " DESC";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows.Count == 1)
            {
                string sCodeEnd = dt.Rows[0][sFieldMa].ToString();

                string[] add = sCodeEnd.Split('-');
                int stt = StaticData.ParseInt(add[add.Length - 1]);
                stt++;
                if (stt <= 9)
                {
                    skq = sBegin + "-" + dates + "-0" + stt;
                }
                else
                {
                    skq = sBegin + "-" + dates + "-" + stt;
                }
            }

        }
        else
        {
            skq = sBegin + "-" + dates + "-01";
        }
        return skq;
    }

    static public string CreateIDTheoThuTu(string sBegin, string sTableName, string sFieldMa, string sFieldOrder)
    {
        string dates = DataAcess.Connect.d_SystemDate().ToString("ddMMyyyy");
        string skq = "";
        //ThuanNH 10/05/2010 - Sua cach tao lai ma
        string ssql = "SELECT TOP 1 " + sFieldMa + " FROM " + sTableName + " WHERE " + sFieldMa + " LIKE '%" + dates + "%'" + " AND " + sFieldMa + " LIKE '" + sBegin + "%' ORDER BY " + sFieldOrder + " DESC";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows.Count == 1)
            {
                string sCodeEnd = dt.Rows[0][sFieldMa].ToString();

                string[] add = sCodeEnd.Split('-');
                int stt = StaticData.ParseInt(add[add.Length - 1]);
                stt++;
                if (stt <= 9)
                {
                    skq = sBegin + "-" + dates + "-0" + stt;
                }
                else
                {
                    skq = sBegin + "-" + dates + "-" + stt;
                }
            }

        }
        else
        {
            skq = sBegin + "-" + dates + "-01";
        }
        return skq;
    }

    static public object FormatNumber(object objNumber, bool isDB)
    {
        if (objNumber == "&nbsp;") objNumber = "0";
        objNumber = Convert.ToDouble(objNumber);
        if (StaticData.ParseFloat(objNumber) == 0) return "";
        if (Regex.IsMatch(objNumber.ToString(), @"^(\-|\+|\d)+(\d+((\.|\,)\d+)?)$") || Regex.IsMatch(objNumber.ToString(), @"^(\d+((\.|\,)\d+)?)$"))
        {
            string strFormat = objNumber.ToString();
            string[] arrNum = strFormat.Split('.');
            string strAdd;
            if (arrNum.Length > 1)
            {
                strAdd = arrNum[1];// ' Phan thap phan


                if (strAdd.Length == 1)
                    strAdd += "0";
                else
                    strAdd = strAdd.Substring(0, 2);
            }
            else
            {
                strAdd = "00";
            }
            Double objint = Convert.ToDouble(arrNum[0]);
            Double objint1 = objint;
            if (objint < 0)
                objint = objint * -1;
            arrNum[0] = objint.ToString();
            int iMod = arrNum[0].Length % 3;
            int iDiv = arrNum[0].Length / 3;
            //int idau;

            if (iMod != 0)
            {
                for (int i = 1; i <= 3 - iMod; i++)
                {
                    arrNum[0] = " " + arrNum[0];
                }
            }

            string strInt = "";
            if (objint1 < 0) strInt = "-";
            for (int i = 0; i <= arrNum[0].Length - 1; i++)
            {
                strInt += arrNum[0].Substring(i, 1);
                if ((i + 1) % 3 == 0) strInt += ".";
            }

            strInt = strInt.Substring(0, strInt.Length - 1);

            object objResult = strInt + "," + strAdd;
            if (!isDB) return strInt;
            return objResult;
        }
        else
        {
            return "0.00";
        }
    }

    //==============================================================
    private static string FormatNumber(string s)
    {
        if (s.Length <= 3) return s;
        string s1 = "";
        int j = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            s1 += s[i];
            j++;
            if (j == 3)
            {
                j = 0;
                s1 += ",";
            }
        }
        if (s1[s1.Length - 1] == ',') s1 = s1.Remove(s1.Length - 1, 1);

        string s2 = "";
        for (int i = s1.Length - 1; i >= 0; i--)
        {
            s2 += s1[i];

        }
        return s2;
    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static string FormatSNumberToPrint(string s)
    {
        if (s == null || s == "" || s.Length <= 3) return s;
        s = s.Replace(",", "");
        string s1 = "";
        string s2 = "";
        string s3 = "";
        string s4 = "";
        string s5 = "";
        if (s[0] == '-') s1 = "-";
        if (s[0] == '(') s1 = "(";
        if (s[s.Length - 1] == ')') s5 = ")";

        int n = s.IndexOf(".");
        if (n != -1)
        {
            s2 = s.Substring(s1.Length, n);
            s4 = s.Substring(n + 1, s.Length - s5.Length - n - 1);
            s3 = ".";

        }
        else
        {
            s2 = s.Substring(s1.Length, s.Length - s5.Length - s1.Length);
            s4 = "";
            s3 = "";
        }

        s = s1 + FormatNumber(s2) + s3 + FormatNumber(s4) + s5;
        return s;
    }

    public static string escape(object str)
    {
        if (str != null)
        {
            string tmp = str.ToString();
            if (tmp != "")
            {
                tmp = tmp.Replace("'", "`");
                tmp = tmp.Replace("\"", "&quot;");
                tmp = tmp.Replace("<", "[");
                tmp = tmp.Replace(">", "]");
                tmp = tmp.Replace("--", "");
                return tmp;
            }
            else
                return "";
        }
        else
            return "";
    }
    //==============================================================
    public static string unescape(object str)
    {
        if (str == null) return "";
        string tmp = str.ToString();
        if (tmp != "")
        {
            tmp = tmp.Replace("[", "<");
            tmp = tmp.Replace("]", ">");
            tmp = tmp.Replace("&quot;", "\"");
            return tmp;
        }
        else
            return "";
    }

    //==============================================================
    public static string toTitleCase(object str)
    {
        if (str == null) return string.Empty;
        string re = "";
        string source = str.ToString();
        for (int i = 0; i < source.Length; i++)
            if (i == 0 || (i > 0 && source.Substring(i - 1, 1) == " ")) re += source.Substring(i, 1).ToUpper(); else re += source.Substring(i, 1).ToLower();
        return re;
    }
    //==============================================================
    public static string GetValue(string TableName, string PrimaryKeyName, string PrimaryKeyValue, string ValueMember)
    {
        DataTable dt = DataAcess.Connect.GetTable("SELECT " + ValueMember + " FROM " + TableName + " WHERE " + PrimaryKeyName + "=N'" + PrimaryKeyValue + "'");
        if (dt == null || dt.Rows.Count == 0) return "";
        return dt.Rows[0][0].ToString();
    }
    //==============================================================

    public static string GetValue(string TableName, string PrimaryKeyName, int PrimaryKeyValue, string ValueMember)
    {
        return GetValue(TableName, PrimaryKeyName, PrimaryKeyValue.ToString(), ValueMember);
    }
    //==============================================================

    public static int CheckExist(string TableName, string[] FielName, object[] FieldValue)
    {
        string sWhere = "";
        for (int i = 0; i < FielName.Length; i++)
            sWhere += " " + FielName + "=N'" + FieldValue[i].ToString() + "' AND";
        sWhere = sWhere.Remove(sWhere.Length - " AND".Length - 1, " AND".Length);
        DataTable dt = DataAcess.Connect.GetTable("SELECT " + FielName + " FROM " + TableName + " WHERE " + sWhere);
        if (dt == null || dt.Rows.Count == 0) return 0;
        return int.Parse(dt.Rows[0][0].ToString());
    }

    public static bool CheckExist(string TableName, string FielName, string FieldValue)
    {
        DataTable dt = DataAcess.Connect.GetTable("SELECT " + FielName + " FROM " + TableName + " WHERE " + FielName + "=N'" + FieldValue + "'");
        if (dt == null || dt.Rows.Count == 0) return false;
        return true;
    }
    public static bool CheckExist(string TableName, string FielName1, string FieldValue1, string FielName2, string FieldValue2)
    {
        DataTable dt = DataAcess.Connect.GetTable("SELECT " + FielName1 + " FROM " + TableName + " WHERE " + FielName1 + "=N'" + FieldValue1 + "'" + " AND " + FielName2 + "=N'" + FieldValue2 + "'");
        if (dt == null || dt.Rows.Count == 0) return false;
        return true;
    }
    public static bool CheckExist(string TableName, string FielName1, string FieldValue1, string FielName2, string FieldValue2, string FielName3, string FieldValue3)
    {
        DataTable dt = DataAcess.Connect.GetTable("SELECT " + FielName1 + " FROM " + TableName + " WHERE " + FielName1 + "=N'" + FieldValue1 + "'" + " AND " + FielName2 + "=N'" + FieldValue2 + "" + " AND " + FielName3 + "=N'" + FieldValue3 + "");
        if (dt == null || dt.Rows.Count == 0) return false;
        return true;
    }
    public static bool CheckNumberColumn(string sqlSelect)
    {
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        if (dt == null || dt.Rows.Count == 0) return false;
        string s = dt.Rows[0][0].ToString();
        if (s != "0") return true;
        return false;

    }
    public static bool  DeleteRow(string TableName, string PrimaryKeyName, string PrimaryKeyValue)
    {
       return DataAcess.Connect.ExecSQL("DELETE FROM " + TableName + " WHERE " + PrimaryKeyName + "=N'" + PrimaryKeyValue + "'");
    }
    public static void DeleteRow(string TableName, string PrimaryKeyName, int PrimaryKeyValue)
    {
        DeleteRow(TableName, PrimaryKeyName, PrimaryKeyValue.ToString());
    }
    public static string hsConvertBit(object value)
    {
        if (value == null) return "0";
        return hsConvertBit(value.ToString());
    }
    public static string hsConvertBit(string value)
    {
        if (value == null) value = "0";
        if (value.ToLower() == "true" || value == "1") value = "1";
        else value = "0";
        return value;
    }
    public static Boolean compare(object ob1, object ob2)
    {
        if (ob1 == null || ob2 == null)
            return false;
        else if (ob1.ToString().Trim().ToLower() == ob2.ToString().Trim().ToLower())
            return true;
        return false;
    }
    static public string TaoMaSoPhieu(string sBegin, string sTableName, string sFieldMa, string sNgay, string sdates, string sFieldOrder )
    {
        sdates = sdates.Replace("/", "");
        string skq = "";
        string ssql = "";
        ssql = " SELECT TOP 1 " + sFieldMa + " FROM " + sTableName + " ";
        ssql += " WHERE " + sFieldMa + " like '%/" + sdates + "' AND " + sFieldMa + " LIKE '" + sBegin + "%' ";
        ssql += "       and " + sFieldMa + " = (Select max(" + sFieldMa + ") ";
        ssql += "                               From " + sTableName + " ";
        ssql += "                               Where " + sFieldMa + " like '%/" + sdates + "' AND " + sFieldMa + " LIKE '" + sBegin + "%' ";
        ssql += "                               ) ";
        ssql += " ORDER BY " + sFieldOrder + " DESC ";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows.Count == 1)
            {
                string sCodeEnd = dt.Rows[0][sFieldMa].ToString();

                string[] add = sCodeEnd.Split('-');
                int stt = StaticData.ParseInt(add[1].Substring(0, 3));//data.ParseInt(add[add.Length - 1]);
                stt++;
                if (stt <= 9)
                {
                    skq = sBegin + "-00" + stt + "/" + sdates;
                }
                else
                {
                    if (stt.ToString().Length == 3)
                        skq = sBegin + "-" + stt + "/" + sdates;
                    else
                        skq = sBegin + "-0" + stt + "/" + sdates;
                }
            }

        }
        else
        {
            skq = sBegin + "-001" + "/" + sdates;
        }
        return skq;
    }
    public static string EncodePass(string strPAss)
    {
        string strCode;
        //If Page.IsValid Then
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

        byte[] hashedDataBytes;
        UTF8Encoding encoder = new UTF8Encoding();
        hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(strPAss));

        //Dim b As Byte
        //For Each b In hashedDataBytes
        //    strCode &= "" & Convert.ToChar(b) & ""
        //Next b
        strCode = Convert.ToBase64String(hashedDataBytes);
        //End If
        return strCode;
    }
    public static bool XuatToaChungMoiLuaTuoi
    {
        get
        {
            string s = GetParameter("XuatToaChungMoiLuaTuoi");
            if (s == "1" || s.ToLower() == "true") return true;
            return false;
        }
    }
    public static string LoaiGiaID
    {
        get
        {
            string sqlParameter = "SELECT    "
                              + "LoaiGia=(SELECT ParaValue FROM KB_Parameter WHERE ParaName='LoaiGia')";
            string LoaiGia = "1";
            DataTable dtParameter = DataAcess.Connect.GetTable(sqlParameter);
            if (dtParameter != null && dtParameter.Rows.Count > 0)
            {
                LoaiGia = dtParameter.Rows[0][0].ToString();
            }
            return LoaiGia;
        }
    }
    public static string BieuMauPhieuXuat
    {
        get
        {
            string s= GetParameter("BieuMauPhieuXuat");
            if (s == null || s == "") return "1";
            return s;
        }
    }
    public static string BieuMauPhieuNhap
    {
        get
        {
            string s = GetParameter("BieuMauPhieuNhap");
            if (s == null || s == "") return "1";
            return s;
        }
    }
    public static string NewPhieuYeuCauTraThuoc(string NgayYeuCau)
    {
        NgayYeuCau += " 23:59:59";
        string sqlSelect = "select count(*) from NVK_Thuoc_PhieuYCTra where year(ngayYC)= year('" + NgayYeuCau + "') and month(ngayYc)= month('" + NgayYeuCau + "') and day(ngayyc)=day('" + NgayYeuCau + "')";
        DataTable dtCountBN = DataAcess.Connect.GetTable(sqlSelect);
        int nCount = 0;
        if (dtCountBN != null || dtCountBN.Rows.Count > 0)
            nCount = int.Parse(dtCountBN.Rows[0][0].ToString());
        nCount++;
        string sCount = nCount.ToString();
        DateTime dNgay = DateTime.Parse(NgayYeuCau);
        string s = "PTT-" + dNgay.ToString("ddMMyyyy") + "-" + sCount.ToString();
        return s;
    }
    public static string NVK_NewMaPhieu_TheoNgay(string NgayYeuCau, string prefix, string TableName, string ColumnNgay)
    {
        NgayYeuCau += " 23:59:59";
        string sqlSelect = "select count(*) from " + TableName + " where year(" + ColumnNgay + ")= year('" + NgayYeuCau + "') and month(" + ColumnNgay + ")= month('" + NgayYeuCau + "') and day(" + ColumnNgay + ")=day('" + NgayYeuCau + "')  and maphieunhap like N'"+prefix+"%'";
        DataTable dtCountBN = DataAcess.Connect.GetTable(sqlSelect);
        int nCount = 0;
        if (dtCountBN != null || dtCountBN.Rows.Count > 0)
            nCount = int.Parse(dtCountBN.Rows[0][0].ToString());
        nCount++;
        string sCount = nCount.ToString();
        DateTime dNgay = DateTime.Parse(NgayYeuCau);
        string s = prefix + dNgay.ToString("ddMMyyyy") + "-" + sCount.ToString();
        return s;
    }
    public static string TaoSoPhieuNhap(ref string newSTT)
    {
        //if (NgayThangNam.Length > "2011/09/29".Length)
        //    NgayThangNam = NgayThangNam.Remove(NgayThangNam.Length - "15:25:51".Length, "15:25:51".Length);
        string sqlSelect = @"SELECT TOP 1 RIGHT(MAPHIEUNHAP,4) FROM PHIEUNHAPKHO 
        WHERE YEAR(NGAYTHANG)=YEAR(getdate()) 
        AND MAPHIEUNHAP LIKE 'PN%'
        ORDER BY IDPHIEUNHAP DESC";
        DataTable tbPN = DataAcess.Connect.GetTable(sqlSelect);
        string STT = "0";
        if (tbPN.Rows.Count > 0)
            STT=tbPN.Rows[0][0].ToString();
        else STT = "0";
        long nSTT = long.Parse(STT);
        nSTT++;
        string s = nSTT.ToString();
        newSTT = nSTT.ToString();
        string stemp = "000000000000000000000";
        s = stemp.Substring(0, "9900".Length - s.Length) + s;
        string year = DateTime.Now.Year.ToString();
        s = "PN" + year.Substring(year.Length - 2, 2) + s;
        return s;
    }
    #endregion
   public static string DoiTuSoSangChuLaMa(int x)
    {
        string rs = "";
        int k = x;
        int s = 1000, t;
        do
        {
            t = k - k % s;
            k = k - t;

            s = s / 10;
            if ( t>=1 && t<=10)
            {
                if (t == 1) rs += "I";
                if (t == 2) rs += "II";
                if (t == 3) rs += "III";
                if (t == 4) rs += "IV";
                if (t == 5) rs += "V";
                if (t == 6) rs += "VI";
                if (t == 7) rs += "VII";
                if (t == 8) rs += "VIII";
                if (t == 9) rs += "IX";
                if (t == 10) rs += "X";
            }
            if (t>10 &&t<=100)
            {

                if (t == 20) rs += "XX";
                if (t == 30) rs += "XXX";
                if (t == 40) rs += "XL";
                if (t == 50) rs += "L";
                if (t == 60) rs += "LX";
                if (t == 70) rs += "LXX";
                if (t == 80) rs += "LXXX";
                if (t == 90) rs += "XC";
                if (t == 100) rs += "C";
            }
            if (t>100 &&t<=1000)
            {
                if (t == 200) rs += "CC";
                if (t == 300) rs += "CCC";
                if (t == 400) rs += "CD";
                if (t == 500) rs += "D";
                if (t == 600) rs += "DC";
                if (t == 700) rs += "DCC";
                if (t == 800) rs += "DCCC";
                if (t == 900) rs += "CM";
                if (t == 1000) rs += "M";
            }
            if (t>1000 &&t<=5000)
            {
                if (t == 2000) rs += "MM";
                if (t == 3000) rs += "MMM";
                if (t == 4000) rs += "MMMM";
            }

        } while (k > 0);
        return rs;
    }
    public static int  DoiTuSoLaMaSangInt(string pstrRomanNumeral )
        {
 
         int[] aintRomanValues =null;
        int  intInputLen =0;
        int intSum=0;
          intInputLen = pstrRomanNumeral.Length;

          if (intInputLen == 0)
              return 0;

        Array.Resize(ref aintRomanValues,intInputLen);
         for(int intX = 0 ;intX< intInputLen;intX++)
         {
             switch(pstrRomanNumeral.Substring(intX, 1))
             {
                  
                 case "M" : aintRomanValues[intX] = 1000;break;
                 case "D" : aintRomanValues[intX] = 500;break;
                 case "C" : aintRomanValues[intX] = 100;break;
                 case "L" : aintRomanValues[intX] = 50;break;
                 case "X" : aintRomanValues[intX] = 10;break;
                 case "V" : aintRomanValues[intX] = 5;break;
                 case "I" : aintRomanValues[intX] = 1;break;
             };
         }
        for(int intX = 0;intX<intInputLen;intX++)
        {
             if( intX == intInputLen-1 )
                 intSum = intSum + aintRomanValues[intX];
             else
                 if (aintRomanValues[intX] >= aintRomanValues[intX + 1] )
                    intSum = intSum + aintRomanValues[intX];
                 else
                    intSum = intSum - aintRomanValues[intX];
                
        }
         return intSum;
 
    }

    public static DataTable fixCateGory(DataTable dt)
    {
        if (dt != null)
        {
            if (dt.Columns.IndexOf("des1") == -1) dt.Columns.Add("des1", dt.Rows.Count.GetType());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["des1"] = StaticData.DoiTuSoLaMaSangInt(dt.Rows[i]["des"].ToString());
            }

            dt.DefaultView.Sort = "des1";
            dt = dt.DefaultView.ToTable();

            
        }
        return dt;
    }
    public static DataTable fixReport(DataTable dt)
    {
        if (dt != null)
        {
            if (dt.Columns.IndexOf("des1") == -1)
                dt.Columns.Add("des1", dt.Columns.Count.GetType());
            if (dt.Columns.IndexOf("manhom1") == -1)
                dt.Columns.Add("manhom1", dt.Columns.Count.GetType());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["des1"] = StaticData.DoiTuSoLaMaSangInt(dt.Rows[i]["des"].ToString());
                dt.Rows[i]["manhom1"] = StaticData.DoiTuSoLaMaSangInt(dt.Rows[i]["manhom"].ToString());
            }

            dt.DefaultView.Sort = "des1,manhom1,TENTHUOC";
            dt = dt.DefaultView.ToTable();

            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["STT"] = i + 1;
        }
        return dt;
    }
    public static string getBitvalue(string s)
    {
        if (s == null || s.Trim() == "") return "0";
        s = s.Trim().ToLower();
        if (s == "1" || s == "true") return "1";
        return "0";

    }
    public static void getnguoixuat(System.Web.UI.Page Page)
    {
        string sqlSelect = @"SELECT * from nguoidung  
                                where idnguoidung IN (SELECT DISTINCT userid from UserProfile where PermID=12)";

        DataTable table = Thuoc_Process.phongkhambenh.GetTable(sqlSelect);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {

                    html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y][1].ToString();

                }
            }
        }
        Page.Response.Clear(); Page.Response.Write(html);
    }
    private static string IsHaveThuocGN_TT_temp = "-1";

    public static bool IsHaveThuocGN_TT
    {
        get
        {
            if (IsHaveThuocGN_TT_temp == "-1")
            {
                 DataTable dtStructThuoc = DataAcess.Connect.GetTable("SP_COLUMNS THUOC");
                 if (int_Search(dtStructThuoc, "COLUMN_NAME='ISTGN'") != -1 && int_Search(dtStructThuoc, "COLUMN_NAME='ISTHTT'") != -1)
                 {
                     IsHaveThuocGN_TT_temp = "True";
                 }
                 else
                     IsHaveThuocGN_TT_temp = "False";
            }
            return bool.Parse(IsHaveThuocGN_TT_temp);
        }
    }
    public static void getthuoc(System.Web.UI.Page Page)
    {
        getthuoc(Page, false);
    }
    public static void getthuoc(System.Web.UI.Page Page,bool IsNhapKho)
    {

        string idKho = (Page.Request.QueryString["idkho"] != null ? Page.Request.QueryString["idkho"].ToString() : StaticData.GetParaValueDB("KhoNhapMuaID"));
        if (idKho == "") return;
        string sqlClause = "";
        if (Page.Request.QueryString["q"] != null)
        {
            sqlClause += " and A.tenthuoc like N'" + Page.Request.QueryString["q"] + "%'";
        }
        string NgayCT = "GETDATE()";
        if (Page.Request.QueryString["NgayCT"] != null && Page.Request.QueryString["NgayCT"] !="")
        {
            NgayCT = Page.Request.QueryString["NgayCT"].ToString();
            NgayCT = StaticData.CheckDate(NgayCT);
            NgayCT = "'" + NgayCT + " " + "23:59:59" + "'";
        }

        if (Page.Request.QueryString["loaithuoc"] != null && Page.Request.QueryString["loaithuoc"].ToString() != "")
        {
            string LoaiThuocID = Page.Request.QueryString["loaithuoc"].ToString();
            if (LoaiThuocID != "5" && LoaiThuocID != "6")
                sqlClause += " and A.loaithuocid='" + LoaiThuocID + "'";
            else
            {
                if (IsHaveThuocGN_TT)
                {
                    if (LoaiThuocID == "5")
                    {
                        sqlClause += " and A.IsTGN=1 and A.LoaithuocID=1";
                    }
                    if (LoaiThuocID == "6")
                    {
                        sqlClause += " and A.IsTHTT=1 and A.LoaithuocID=1";
                    }
                }
                else
                    sqlClause += " and A.loaithuocid='" + LoaiThuocID + "'";
            }

        }


        string sqlThuoc = @"SELECT	B.idthuoc
                                    ,B.tenthuoc
                                    ,B.sttindm05
                                    ,B.iddvt
                                    ,B.congthuc
                                    ,B.TTHoatChat
                                    ,SLTON=DBO.Thuoc_TonKho_new_1910(B.IDTHUOC," + NgayCT + "," + idKho + @") 
                                    ,C.TenDVt

                            FROM 
                            (
                            SELECT   DISTINCT TOP 20 tenthuoc
                            ,(SELECT top 1 idthuoc from thuoc where tenthuoc=A.tenthuoc AND ISTHUOCBV=1 order by idthuoc) as IdThuoc
                            from thuoc a
                            where IsThuocBV=1 "
                           + sqlClause
                           + @"
                            )
                             AS A
                            LEFT JOIN thuoc B ON A.IdThuoc=B.idthuoc
                            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                            WHERE 1=1 " +(IsNhapKho==false ? (StaticData.GetParaValueDB("ChoPhepTheHienThuocKhongCoSLTon") != "1" ? " AND  DBO.Thuoc_TonKho_new_1910(B.IDTHUOC," + NgayCT + "," + idKho + @") >0 " : ""):"")
                            + " ORDER BY B.TENTHUOC,B.TTHOATCHAT,B.CONGTHUC";

        string html = "";
        //string html = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", ""
        //+ "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
        //+ "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
        //+ "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >Biệt dược</div>"
        //+ "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
        //+ "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >Hoạt chất</div>"
        //+ "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
        //+ "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
        //+ "</div>", "", "", "", "", "","","", Environment.NewLine);
        //html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", "", "", "", "", "", "","","", Environment.NewLine);

        DataTable table = DataAcess.Connect.GetTable(sqlThuoc);
        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", "<div>"
                  + "<div style=\"width:5%;height:30px;float:left\" >" + (i + 1) + "</div>"
                 + "<div style=\"width:32%;height:30px;float:left\" >" + h["tenthuoc"] + "</div>"
                 + "<div style=\"width:10%;height:30px;float:left\" >" + h["TTHoatChat"] + "</div>"
                 + "<div style=\"width:30%;height:30px;float:left\" >" + h["congthuc"] + "</div>"
                 + "<div style=\"width:12%;height:30px;float:left\" >" + h["TenDVT"] + "</div>"
                 + "<div style=\"width:5%;height:30px;float:left\" >" + string.Format("{0:0.##}",h["SLTON"]) + "</div>"
                 + "</div>", h["idthuoc"], h["congthuc"], h["iddvt"], h["tenthuoc"], h["sttindm05"], string.Format("{0:0.##}",h["SLTON"]),h["TenDVT"], Environment.NewLine);

        }
        Page.Response.Clear();
        Page.Response.Write(html);
        Page.Response.End();
    }

    public static string EnabledHavePermision(Page p, string Permisionname)
    {
        if (SysParameter.UserLogin.IsAdmin(p))
            return "";
        bool rs = Userlogin_new.HavePermision(p, Permisionname);
        if (rs)
            return "";
        else
            return "disabled=true";
    }
    public static bool HavePermision(Page p, string Permisionname)
    {
        //if (SysParameter.UserLogin.IsAdmin(p))
            return true;
       // else
          //  return Userlogin_new.HavePermision(p, Permisionname);
    }

    public static void GetKho(Page P,bool IsKhoaDuoc)
    {
        string sqlSelect = @"select idkho,makho,tenkho=replace(tenkho,N'-tủ trực','') from khothuoc where isnull(iskt,0)=0 and nvk_loaikho in(1,2)";

        if (IsKhoaDuoc)
            sqlSelect = @"select idkho,makho,tenkho=replace(tenkho,N'-tủ trực','') from khothuoc where  idkho=" + StaticData.MacDinhKhoNhapMuaID;

        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {

                    html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y][2].ToString();

                }
            }
        }
       P.Response.Clear();P.Response.Write(html);

    }
    public static DataTable dtGetKho(Page P, bool IsKhoaDuoc)
    {
        string sqlSelect = @"select idkho,makho,tenkho=replace(tenkho,N'-tủ trực','') from khothuoc where isnull(iskt,0)=0 and nvk_loaikho not in(3,4)";

        if (IsKhoaDuoc)
            sqlSelect = @"select idkho,makho,tenkho=replace(tenkho,N'-tủ trực','') from khothuoc where  idkho=" + StaticData.MacDinhKhoNhapMuaID;

        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        return table;
    }
    public static DataTable dtGetKho2(Page P, bool IsNotKhoaDuoc)
    {
        string sqlSelect = @"select idkho,makho,tenkho=replace(tenkho,N'-tủ trực','') from khothuoc where isnull(iskt,0)=0 and nvk_loaikho not in (3,4)";

        if (IsNotKhoaDuoc)
            sqlSelect = @"select idkho,makho,tenkho=replace(tenkho,N'-tủ trực','') from khothuoc where isnull(iskt,0)=0 and nvk_loaikho not in (3,4) and idkho <>" + StaticData.MacDinhKhoNhapMuaID;

        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        return table;
    }

    #region New Parameter
    public static string GetParaValueDB(string ParaName)
    {
        string sqlSelect = "SELECT ParaValue FROM KB_Parameter WHERE ParaName='"+ParaName+"'";
        DataTable DT = DataAcess.Connect.GetTable(sqlSelect);
        if (DT == null || DT.Rows.Count == 0) return null;
        string svalue = DT.Rows[0][0].ToString();
        return svalue;
    }
    public static bool IsMaHoaMatKhau 
    {
        get
        {

            string ParaName = "IsMaHoaMatKhau";
            string ParaValue = GetParaValueDB(ParaName);
            if (ParaValue == null || ParaValue == "" || ParaValue == "0")
                return false;
            return true;
        }
    }
    public static bool IsMaHoaTenDangNhap 
    {
        get
        {
            string ParaName = "IsMaHoaTenDangNhap";
            string ParaValue = GetParaValueDB(ParaName);
            if (ParaValue == null || ParaValue == "" || ParaValue == "0")
                return false;
            return true;
        }
    }
    public static void Update_Parameter()
    {
        Page P = new Page();
        string SourceF = P.Server.MapPath("~/App_Data");
        if (!System.IO.Directory.Exists(SourceF)) return;
        string[] arrS = System.IO.Directory.GetFiles(SourceF);
        if (arrS.Length == 0) return;
        DataTable dtCount =DataAcess.Connect.GetTable("SELECT MAX(Id) FROM KB_Parameter");
        int MaxID=1;
        if(dtCount==null ) return;
        if(dtCount.Rows.Count==0 ||dtCount.Rows[0][0].ToString()=="") MaxID=1;
        else
            MaxID = int.Parse(dtCount.Rows[0][0].ToString()) + 1;
        for (int i = 0; i < arrS.Length; i++)
        {

            string fileName = arrS[i];
            string sortF = System.IO.Path.GetFileName(fileName);
            if (sortF != "SaoLuuPhucHoiDB.exe" && sortF != "ServerConfig.txt")
            {
                int nO = sortF.LastIndexOf(".");
                sortF = sortF.Substring(0, nO);
                string ParaName = sortF;
                string value = s_ReadFile(fileName);
                string sqlSave = " IF ( NOT EXISTS (SELECT * FROM KB_Parameter WHERE ParaName=N'" + ParaName + "') )   INSERT INTO KB_Parameter(id,ParaName,ParaValue) VALUES(" + MaxID.ToString() + ",N'" + ParaName + "',N'" + value + "')";
                bool OK = DataAcess.Connect.ExecSQL(sqlSave);
                if (OK)
                {
                    MaxID++;
                   
                }
            }
           
        }

    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static string s_ReadFile(string s_FileName)
    {

        if (!System.IO.File.Exists(s_FileName))
            return "";

        System.IO.StreamReader sR = new StreamReader(s_FileName);
        string S = sR.ReadToEnd();
        sR.Close();
        return S;

    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static bool s_WriteFile(string s_FileName, string value)
    {
        try
        {
            if (!System.IO.File.Exists(s_FileName))
                System.IO.File.WriteAllText(s_FileName, value);
            else
            {
                System.IO.StreamWriter sW = new StreamWriter(s_FileName);
                sW.Write(value);
                sW.Close();
            }
            return true;
        }
        catch (Exception) { return false; }
    }

    #endregion
    #region Tính lại tiền cho bệnh nhân
    public static bool TinhLaiTien_ByIdDangKyKham(string IdDangKyKham)
    {
        string SQLUpdate = " EXEC zHS_TONGTIENBHYT " + IdDangKyKham;
        bool OK = DataAcess.Connect.ExecSQL(SQLUpdate);
        if (!OK)
        {
            MsgBox(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
        }
        return OK;
    }
    public static bool TinhLaiTien_ByIdKhamBenh(string IdKhamBenh)
    {
        string sqlSelect = "SELECT IDDANGKYKHAM FROM KHAMBENH WHERE IDKHAMBENH=" + IdKhamBenh;
        DataTable DT = DataAcess.Connect.GetTable(sqlSelect);
        if (DT == null || DT.Rows.Count == 0)
        {
            MsgBox(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
            return false;
        }
        string IdDangKyKham = DT.Rows[0][0].ToString();
        string SQLUpdate = " EXEC zHS_TONGTIENBHYT " + IdDangKyKham;
        bool OK = DataAcess.Connect.ExecSQL(SQLUpdate);
        if (!OK)
        {
            MsgBox(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
        }
        return OK;
    }

    public static bool TinhLaiTien_ByIdBenhNhanToaThuoc(string IdBenhNhanToaThuoc)
    {
        string sqlSelect = @"SELECT IDDANGKYKHAM FROM BENHNHANTOATHUOC A 
                             LEFT JOIN KHAMBENH B ON A.IDKHAMBENH=B.IDKHAMBENH
                             WHERE IDBENHNHANTOATHUOC=" + IdBenhNhanToaThuoc;

        DataTable DT = DataAcess.Connect.GetTable(sqlSelect);
        if (DT == null || DT.Rows.Count == 0)
        {
            MsgBox(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
            return false;
        }
        string IdDangKyKham = DT.Rows[0][0].ToString();
        string SQLUpdate = " EXEC zHS_TONGTIENBHYT " + IdDangKyKham;
        bool OK = DataAcess.Connect.ExecSQL(SQLUpdate);
        if (!OK)
        {
            MsgBox(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
        }
        return OK;
    }

    public static bool TinhLaiTien_ByIdMaPhieuCLS(string MaPhieuCLS)
    {
        string sqlSelect = @"SELECT IDDANGKYKHAM FROM KHAMBENHCANLAMSAN A 
                             LEFT JOIN KHAMBENH B ON A.IDKHAMBENH=B.IDKHAMBENH
                             WHERE MaPhieuCLS='" + MaPhieuCLS + "'";

        DataTable DT = DataAcess.Connect.GetTable(sqlSelect);
        if (DT == null || DT.Rows.Count == 0)
        {
            MsgBox(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
            return false;
        }
        string IdDangKyKham = DT.Rows[0][0].ToString();
        string SQLUpdate = " EXEC zHS_TONGTIENBHYT " + IdDangKyKham;
        bool OK = DataAcess.Connect.ExecSQL(SQLUpdate);
        if (!OK)
        {
            MsgBox(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
        }
        return OK;
    }
    #region New MaPHieu
    public static string MaPhieu_new()
    {
        string MaPhieu_tepm = null;

        string SysDate_ = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string sqlSelectMaPhieu = "select max(SoTT) from Kb_SoBienLai where year(SysDate)=year('" + SysDate_ + "') and month(SysDate)=month('" + SysDate_ + "')";
        DataTable dtMaPhieu = DataAcess.Connect.GetTable(sqlSelectMaPhieu);
        if (dtMaPhieu == null) MaPhieu_tepm = "0";
        else
        {
            if (dtMaPhieu.Rows.Count == 0) MaPhieu_tepm = "0";
            else
            {
                MaPhieu_tepm = dtMaPhieu.Rows[0][0].ToString();

            }

            if (MaPhieu_tepm == "") MaPhieu_tepm = "0";
            long d = long.Parse(MaPhieu_tepm);
            d++;
            MaPhieu_tepm = "PT" + DateTime.Parse(SysDate_).ToString("yyMM") + "0000000".Substring(0, 5 - d.ToString().Length) + d.ToString();
            string sqlSave = "insert into Kb_SoBienLai(SoTT,SysDate) values(" + d.ToString() + ",'" + SysDate_ + "')";
            bool ok = DataAcess.Connect.ExecSQL(sqlSave);
        }
        return MaPhieu_tepm;


    }
    #endregion
    #region Inphiếu thanh toán
    public static void InPhieuThanhToan(string IdPhieuXuat, bool IsBHYT, Page P, bool IsOpenNewWindow)
    {
        string MaPhieuCLS = IdPhieuXuat;
        string LoaiThu = "ThuocDV";
        if (IsBHYT)
        {
            LoaiThu = "ChenhLechBHYT";
            string sqlSelect = @" SELECT    TOP 1 D.IdBenhBHDongTien
                                        FROM PHIEUXUATKHO A  
			                            LEFT JOIN BENHNHANTOATHUOC  B ON A.IDBENHNHANTOATHUOC=B.IDBENHNHANTOATHUOC
			                            LEFT JOIN KHAMBENH C ON B.IDKHAMBENH=C.IDKHAMBENH
			                            LEFT JOIN DANGKYKHAM D ON C.IDDANGKYKHAM=D.IDDANGKYKHAM
			                            WHERE	 A.IDPHIEUXUAT=" + IdPhieuXuat;
            DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
            if (dt == null || dt.Rows.Count == 0) return;
            string IdBenhBHDongTien = dt.Rows[0]["IdBenhBHDongTien"].ToString();
            MaPhieuCLS = IdBenhBHDongTien;
            string sqlTestVuotNguong = "SELECT * FROM HS_BENHNHANBHDONGTIEN WHERE ID=" + IdBenhBHDongTien;
            DataTable dtTestVuotNguong = DataAcess.Connect.GetTable(sqlTestVuotNguong);
            if (dtTestVuotNguong == null || dtTestVuotNguong.Rows.Count == 0) return;
            string DungTuyen = dtTestVuotNguong.Rows[0]["DungTuyen"].ToString();
            if (DungTuyen.ToLower() == "y" || DungTuyen == "1")
            {
                string BNPhaiTraChenhLechBHYT = dtTestVuotNguong.Rows[0]["BNPhaiTraChenhLechBHYT"].ToString();
                if (BNPhaiTraChenhLechBHYT == "" || BNPhaiTraChenhLechBHYT == "0")
                {
                    MaPhieuCLS = IdPhieuXuat;
                    LoaiThu = "thuocbhdungtuyenchuavuot";
                }
            }
        }
        string MaPhieu = null;
        DataTable dtTest = DataAcess.Connect.GetTable("SELECT MAPHIEU FROM PHIEUXUATKHO WHERE IDPHIEUXUAT=" + IdPhieuXuat);
        if (dtTest == null || dtTest.Rows.Count == 0) return;
        MaPhieu = dtTest.Rows[0]["MaPhieu"].ToString();
        if (MaPhieu == null || MaPhieu == "")
        {
            MaPhieu = StaticData.MaPhieu_new();

        }
        if (IsOpenNewWindow)
            ScriptManager.RegisterStartupScript(P, P.GetType(), null, "setTimeout(function(){window.open(\"frm_rpt_InPhieuThuTH.aspx?MaPhieuCLS=" + MaPhieuCLS + "&LoaiThu=" + LoaiThu + "&MaPhieu=" + MaPhieu + "&InTrucTiep=0\",'_blank');},1000);", true);
        else
            P.Response.Write("frm_rpt_InPhieuThuTH.aspx?MaPhieuCLS=" + MaPhieuCLS + "&LoaiThu=" + LoaiThu + "&MaPhieu=" + MaPhieu + "&InTrucTiep=0");
    }
    #endregion
    #region Đóng phí khám bệnh
    public static void DongPhiKham(string iddangkykham)
    {
        bool ok_UpdateDathu = DataAcess.Connect.ExecSQL("EXEC zHS_DongPhiKham " + iddangkykham);
    }
    #endregion

      #endregion
    public static string PadText(String csText, int nLen, int nType)
    {
        if (csText.Length == nLen)
            return csText;

        if (csText.Length > nLen)
        {
            if (nType == 1)
                csText = csText.Substring(csText.Length - nLen, nLen);
            else
                csText = csText.Substring(0, nLen);
        }
        else
        {
            while (csText.Length < nLen)
            {
                if (nType == 0)
                {
                    csText = csText + " ";
                    if (csText.Length < nLen)
                        csText = " " + csText;
                }
                else
                    if (nType == 1)
                        csText = " " + csText;
                    else
                        csText = csText + " ";
            }
        }
        return csText;
    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static string ConvertMoneyToText(string csMoney)
    {
        string csResult = "";
        if (csMoney == "") return "";
        while (csMoney.Substring(0, 1) == "0")
        {
            if (csMoney.Length > 1)
                csMoney = csMoney.Substring(1, csMoney.Length - 1);
            else
                if (csMoney == "0")
                {
                    csMoney = "";
                    break;
                }
        }

        if (csMoney != "")
        {
            string csTram = "";
            string csNghin = "";
            string csTrieu = "";
            string csPart1 = "";
            string csPart2 = "";
            string delimStr = ",.";
            char[] delimiter = delimStr.ToCharArray();
            string[] split = null;
            split = csMoney.Split(delimiter, 2);
            csPart1 = split[0];
            if (split.Length > 1)
            {
                csPart2 = split[1];
                if (csPart2.Length > 3)
                    csPart2 = csPart2.Substring(0, 3);

                csPart2 = SplipNumber(csPart2);

                if (csPart2 != "")
                    csResult = "phay " + csPart2;
            }

            if (csPart1.Length > 9)
            {
                //  MessageBox.Show("Tien thanh toan len den tien ty la dieu khong the\r\nHay xem du lieu va tinh toan lai di Oai vo van");
                return "";
            }

            while (csPart1.Length > 3)
            {
                if (csTram == "")
                    csTram = csPart1.Substring(csPart1.Length - 3, 3);
                else
                    csNghin = csPart1.Substring(csPart1.Length - 3, 3);

                csPart1 = csPart1.Substring(0, csPart1.Length - 3);

            }

            if (csTram == "")
                csTram = csPart1;
            else
                if (csNghin == "")
                    csNghin = csPart1;
                else
                    csTrieu = csPart1;

            if (csTram != "")
                csTram = SplipNumber(csTram);
            if (csNghin != "")
                csNghin = SplipNumber(csNghin);
            if (csTrieu != "")
                csTrieu = SplipNumber(csTrieu);

            if (csTram != "")
                csResult = csTram + csResult;
            if (csNghin != "")
                csResult = csNghin + "nghìn " + csResult;
            if (csTrieu != "")
                csResult = csTrieu + "triệu " + csResult;

            csResult += "đồng";
        }
        if (csResult.Length > 2)

            return csResult = char.ToUpper(csResult[0]).ToString() + csResult.Substring(1, csResult.Length - 1);
        return csResult;
    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static string SplipNumber(string csNumber)
    {
        string csText = "";
        string csResult = "";

        if (csNumber == "000" || csNumber == "00" || csNumber == "0")
            return csResult;

        char[] NumberArr = null;
        int nCount = 0;
        NumberArr = csNumber.ToCharArray();
        for (int i = NumberArr.Length - 1; i >= 0; i--)
        {
            switch (NumberArr[i])
            {
                case '0':
                    if (i == NumberArr.Length - 1)
                        csText = "";
                    else
                        if (i == NumberArr.Length - 2)
                            if (NumberArr[NumberArr.Length - 1] != '0')
                                csText = "lẻ ";
                            else
                                csText = "";
                        else
                            csText = "không ";
                    break;
                case '1':
                    if (i == NumberArr.Length - 2)
                        csText = "mười ";
                    else
                        csText = "môt ";
                    break;
                case '2':
                    csText = "hai ";
                    break;
                case '3':
                    csText = "ba ";
                    break;
                case '4':
                    csText = "bốn ";
                    break;
                case '5':
                    if ((i == NumberArr.Length - 1) && (NumberArr.Length != 1))
                        csText = "lăm ";
                    else
                        csText = "năm ";
                    break;
                case '6':
                    csText = "sáu ";
                    break;
                case '7':
                    csText = "bảy ";
                    break;
                case '8':
                    csText = "tám ";
                    break;
                case '9':
                    csText = "chín ";
                    break;
            }
            if ((nCount == 1) && (NumberArr[i] != '0') && (NumberArr[i] != '1'))
                csText += "mươi ";
            else
                if (nCount == 2)
                    csText += "trăm ";
            csResult = csText + csResult;
            nCount++;
        }
        return csResult;
    }
    //─────────────────────────────────────────
    public static bool IsCheck(string value)
    {
        if (value == null || value == "") return false;
        if (value == "0" || value.ToLower() == "false") return false;
        return true;
    }
    //──────────────────────────────────────────────────────────────────────────────────────────   
}

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
/// <summary>
/// Summary description for StaticData
/// </summary>
public class StaticData
{
    public static string GetParameter(string ParamterName)
    {

        return GetParaValueDB(ParamterName);

    }
    public static string ChuyenKhoaNameInTiepNhan
    {
        get
        {
            string s = GetParaValueDB("HaveChuyenKhoaInTiepNhan");
            if (s == null || s != "1")
                return "";
            return "Chuyên khoa";
        }
    }
    public static string HaveChuyenKhoaInTiepNhan
    {
        get
        {
            string s = GetParaValueDB("HaveChuyenKhoaInTiepNhan");
            if (s == null || s != "1")
                return "display:none";
            return "width: 152px";
        }
    }
    public static string HaveShowThanhTienThuoc
    {
        get
        {
            string s = GetParaValueDB("HaveShowThanhTienThuoc");
            if (s == null || s != "1")
                return "display:none";
            return "width: 70px";
        }
    }
    public static string HaveChuyenKhoaInTiepNhan2
    {
        get
        {
            string s = GetParaValueDB("HaveChuyenKhoaInTiepNhan");
            if (s == null || s != "1")
                return "display:none";
            return "width: 261px";
        }
    }
    public static bool EnableThanhTienThuoc
    {
        get
        {
            string s = GetParaValueDB("HaveShowThanhTienThuoc");
            if (s == null || s != "1")
                return false;
            return true;
        }
    }
    public static bool EnableChuyenKhoa
    {
        get
        {
            string s = GetParaValueDB("HaveChuyenKhoaInTiepNhan");
            if (s == null || s != "1")
                return false;
            return true;
        }
    }

    private static string IsHaveThuocGN_TT_temp = "-1";
    public static string GetParaValueDB(string ParaName)
    {
        string sqlSelect = "SELECT ParaValue FROM KB_Parameter WHERE ParaName='" + ParaName + "'";
        DataTable DT = DataAcess.Connect.GetTable(sqlSelect);
        if (DT == null || DT.Rows.Count == 0) return null;
        string svalue = DT.Rows[0][0].ToString();
        return svalue;
    }
    public static int AccountNumber = 0;
    public static System.Web.UI.Page P = new Page();
    public static bool HaveBHYT
    {
        get
        {

            string s = GetParameter("HaveBHYT");
            if (s == "1") return true;
            return false;
        }
    }
    public static string MaBenhVien
    {
        get
        {
            return GetParameter("MaBenhVien");
        }
    }
    public static string ConvertDayToyyyyMMdd(string strDate, string format)
    {
        if (strDate == null || strDate == "")
        {
            return null;
        }
        strDate = strDate.Split(' ')[0];
        string[] arrDDMMYY;
        arrDDMMYY = strDate.Split('/');
        int intDay = DateTime.Now.Day;
        int intMonth = DateTime.Now.Month;
        int intYear = DateTime.Now.Year;
        try
        {
            if (format == "dd/MM/yyyy")
            {
                intDay = System.Convert.ToInt32(arrDDMMYY[0]);
                intMonth = System.Convert.ToInt32(arrDDMMYY[1]);
                intYear = System.Convert.ToInt32(arrDDMMYY[2]);
                //				DateTime dtmDate = new DateTime(intYear, intMonth, intDay);
                if (intMonth > 12)
                {
                    int temp = intMonth;
                    intMonth = intDay;
                    intDay = temp;
                }
                return intYear + "-" + intMonth + "-" + intDay;
            }
            else if (format == "MM/dd/yyyy")
            {
                intDay = System.Convert.ToInt32(arrDDMMYY[1]);
                intMonth = System.Convert.ToInt32(arrDDMMYY[0]);
                intYear = System.Convert.ToInt32(arrDDMMYY[2]);
                //				DateTime dtmDate = new DateTime(intYear, intMonth, intDay);
                if (intMonth > 12)
                {
                    int temp = intMonth;
                    intMonth = intDay;
                    intDay = temp;
                }
                return intYear + "-" + intMonth + "-" + intDay;
            }
            else if (format == "yyyy/MM/dd")
            {
                intDay = System.Convert.ToInt32(arrDDMMYY[2]);
                intMonth = System.Convert.ToInt32(arrDDMMYY[1]);
                intYear = System.Convert.ToInt32(arrDDMMYY[0]);
                //				DateTime dtmDate = new DateTime(intYear, intMonth, intDay);
                if (intMonth > 12)
                {
                    int temp = intMonth;
                    intMonth = intDay;
                    intDay = temp;
                }
                return intYear + "-" + intMonth + "-" + intDay;
            }
            return intYear + "-" + intMonth + "-" + intDay;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static string QuyenSoMoiNhat()
    {
        string Sql = " select top 1 * from sochungtu order by stt desc";
        DataTable dtSCT = DataAcess.Connect.GetTable(Sql);
        if (dtSCT.Rows.Count > 0)
            return dtSCT.Rows[0]["QuyenSo"].ToString().Trim();
        else
            return "";
    }
    public static string SoDangKyMoiNhat()
    {
        string Sql = " select top 1 * from sochungtu order by stt desc";
        DataTable dtSCT = DataAcess.Connect.GetTable(Sql);
        if (dtSCT.Rows.Count > 0)
            return dtSCT.Rows[0]["SoDangKy"].ToString().Trim();
        else
            return "";
    }
    public static bool DKCLSTrucTiep
    {

        get
        {

            string s = GetParameter("DKCLSTrucTiep");
            if (s == "1") return true;
            return false;
        }
    }

    #region static vanduc 13/12
    static public string CreateIDTheoThuTuMaSoKhamBenh(string sBegin, string sTableName, string sFieldMa, string sFieldOrder, string ngaytn)
    {

        string dates = ngaytn;
        string skq = "";
        string ssql = "SELECT TOP 1 " + sFieldMa + " FROM " + sTableName + " ORDER BY " + sFieldOrder + " DESC";
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
    #endregion
    public static string DaThuBHYT
    {
        get
        {

            return GetParaValueDB("DaThuBHYT");
        }
    }
    public static string IdNhomKhamBenhID
    {
        get
        {
            return GetParaValueDB("IdNhomKhamBenhID");
        }
    }
    public static bool RemoveSoChungTu(string SoCT)
    {
        return DataAcess.Connect.ExecSQL("DELETE SOCHUNGTU WHERE SophieuCT='" + SoCT + "'");
    }
    public static string NewSoChungTu(string NgayCT,
                                            string HoTen,
                                            string NoiDung,
                                            string SoTien
                                        )
    {
        string STT = "";
        string sql = "select  isnull(Max(STT),0) as SoCT from sochungtu where dahuy is null or dahuy=0";
        DataTable dtb = DataAcess.Connect.GetTable(sql);
        string NewSTT = "";
        if (dtb == null || dtb.Rows.Count == 0)
            NewSTT = StaticData.StartedSoCT;
        else
        {
            NewSTT = dtb.Rows[0]["SoCT"].ToString();
        }
        NewSTT = (long.Parse(NewSTT) + 1).ToString();
        STT = NewSTT;
        NewSTT = "PT-" + "000000000".Substring(0, 6 - NewSTT.Length) + NewSTT;
        string sqlSave = "INSERT INTO SOCHUNGTU(STT,NgayCT,SophieuCT,dahuy,HoTen,NoiDung,SoTien) VALUES(" + STT + ",'" + NgayCT + "','" + NewSTT + "',0,N'" + HoTen + "',N'" + NoiDung + "'," + SoTien + ")";
        bool OK = DataAcess.Connect.ExecSQL(sqlSave);
        if (OK) return NewSTT;
        return null;

    }
    public static string NewSoChungTuGetID(string NgayCT,
                                            string HoTen,
                                            string NoiDung,
                                            string SoTien
                                        )
    {
        string STT = "";
        string sql = "select  isnull(Max(STT),0) as SoCT from sochungtu where dahuy is null or dahuy=0";
        DataTable dtb = DataAcess.Connect.GetTable(sql);
        string NewSTT = "";
        if (dtb == null || dtb.Rows.Count == 0)
            NewSTT = StaticData.StartedSoCT;
        else
        {
            NewSTT = dtb.Rows[0]["SoCT"].ToString();
        }
        NewSTT = (long.Parse(NewSTT) + 1).ToString();
        STT = NewSTT;
        NewSTT = "PT-" + "000000000".Substring(0, 6 - NewSTT.Length) + NewSTT;
        string sqlSave = "INSERT INTO SOCHUNGTU(STT,NgayCT,SophieuCT,dahuy,HoTen,NoiDung,SoTien) VALUES(" + STT + ",'" + NgayCT + "','" + NewSTT + "',0,N'" + HoTen + "',N'" + NoiDung + "'," + SoTien + ")";
        bool OK = DataAcess.Connect.ExecSQL(sqlSave);
        if (OK) return STT;
        return null;

    }
    public static string NewSoChungTuTamUng(string NgayCT,
                                            string HoTen,
                                            string NoiDung,
                                            string SoTien,
                                            string SoChungTu,
                                            string QuyenSo
                                        )
    {
        string STT = "";
        string sql = "select  isnull(Max(STT),0) as SoCT from sochungtu where dahuy is null or dahuy=0";
        DataTable dtb = DataAcess.Connect.GetTable(sql);
        string NewSTT = "";
        if (dtb == null || dtb.Rows.Count == 0)
            NewSTT = StaticData.StartedSoCT;
        else
        {
            NewSTT = dtb.Rows[0]["SoCT"].ToString();
        }
        NewSTT = (long.Parse(NewSTT) + 1).ToString();
        STT = NewSTT;
        string sqlSave = "INSERT INTO SOCHUNGTU(STT,NgayCT,SophieuCT,dahuy,HoTen,NoiDung,SoTien,QuyenSo) VALUES(" + STT + ",'" + NgayCT + "','" + SoChungTu + "',0,N'" + HoTen + "',N'" + NoiDung + "'," + SoTien + ",'" + QuyenSo + "')";
        bool OK = DataAcess.Connect.ExecSQL(sqlSave);
        if (OK) return NewSTT;
        return null;

    }
    public static string StartedSoCT
    {
        get
        {
            return GetParaValueDB("StartedSoCT");
        }
    }
    public static string KhoThuocBHYT
    {
        get
        {
            return GetParaValueDB("KhoThuocBHYT");

        }
    }
    public static string LoaiToaThuoc
    {
        get
        {
            return GetParaValueDB("LoaiToaThuoc");
        }
    }
    public static string NhaThuocLink
    {
        get
        {
            return GetParaValueDB("sysNhaThuocLink");

        }
    }
    public static bool HaveNhaThuoc
    {
        get
        {

            string s = GetParaValueDB("HaveNhaThuoc");
            if (s == null || s == "") return false;
            return true;
        }
    }
    public static string XNMauID
    {
        get
        {
            return GetParaValueDB("HaveNhaThuoc");
        }
    }
    public static string SieuAmID
    {
        get
        {

            return GetParaValueDB("SieuAmID");
        }
    }
    public static string XQuangID
    {
        get
        {
            return GetParaValueDB("zChupXQ");

        }
    }
    public static string ECGId
    {
        get
        {
            return GetParaValueDB("zECGID");

        }
    }
    public static string NhanSu_Link
    {
        get
        {

            return GetParaValueDB("NhanSu_Link");
        }
    }
    public static string KeToan_Link
    {
        get
        {

            return GetParaValueDB("KeToan_Link");
        }
    }
    public static bool sysCheckReceipt
    {
        get
        {

            string s = GetParaValueDB("sysCheckReceipt");
            if (s == null || s == "") return false;
            if (s == "1") return true;
            return false;
        }
    }
    public static bool AllowEditReceipAfterCLS
    {
        get
        {

            string s = GetParaValueDB("sysCheckReceipt");
            if (s == null || s == "") return false;
            if (s == "1") return true;
            return false;

        }
    }
    public static bool AllowUpdateTenBN
    {
        get
        {

            string s = GetParaValueDB("sysCheckReceipt");
            if (s == null || s == "") return false;
            if (s == "1") return true;
            return false;

        }
    }
    public static string NguoiPhuTrachTT
    {
        get
        {

            return GetParaValueDB("NguoiPhuTrachTT");

        }
    }
    public static string NguoiThuQuy
    {
        get
        {

            return GetParaValueDB("NguoiThuQuy");

        }
    }
    public static string TimeDescription(string TuNgay, string DenNgay)
    {
        bool IsLongFormatMonth = false;
        return TimeDescription(TuNgay, DenNgay, IsLongFormatMonth);
    }
    public static string TimeDescription(string TuNgay, string DenNgay, bool IsLongFormatMonth)
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
    public static bool HaveChanDoanPhanBiet1
    {
        get
        {

            string s = GetParaValueDB("HaveChanDoanPhanBiet1");
            if (s == null || s == "") return false;
            if (s == "1") return true;
            return false;

        }
    }
    public static bool HaveChanDoanPhanBiet2
    {
        get
        {

            string s = GetParaValueDB("HaveChanDoanPhanBiet2");
            if (s == null || s == "") return false;
            if (s == "1") return true;
            return false;

        }
    }
    public static bool AllowNotCLS
    {
        get
        {

            string s = GetParaValueDB("AllowNotCLS");
            if (s == null || s == "" || s == "0") return false;
            if (s == "1") return true;
            return false;

        }
    }
    public static string MaxRowOfCDCLS
    {
        get
        {


            string s = GetParaValueDB("MaxRowOfCDCLS");
            if (s == null || s == "") return "1";
            return s;

        }
    }
    public static bool ChoPhepThongKePhieuKhamBenhCuaBacSiKhac
    {
        get
        {


            string s = GetParaValueDB("ChoPhepThongKePhieuKhamBenhCuaBacSiKhac");
            if (s == null || s == "") return false;
            if (s == "1") return true;
            return false;

        }
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
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static string TenCty
    {

        get
        {
            DataTable dt = DataAcess.Connect.GetTable("SELECT Ten_Cty FROM TieuDeCty");
            if (dt == null || dt.Rows.Count == 0) return "";
            return dt.Rows[0]["Ten_Cty"].ToString();
        }
    }
    public static string TenPhanMem
    {

        get
        {

            return GetParameter("TenPhanMem");
        }
    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static void Update_SQL_Automatic()
    {
        string SourceF = P.Server.MapPath("~/App_Data/SQLFile_Source");
        string DesF = P.Server.MapPath("~/App_Data/SQLFile_Des");
        if (!System.IO.Directory.Exists(SourceF)) return;
        if (!System.IO.Directory.Exists(DesF)) System.IO.Directory.CreateDirectory(DesF);
        string[] arrS = System.IO.Directory.GetFiles(SourceF);
        if (arrS.Length == 0) return;
        string ss = "";
        for (int i = 0; i < arrS.Length; i++)
        {

            string fileName = arrS[i];
            string sortF = System.IO.Path.GetFileName(fileName);
            string sqlSave = s_ReadFile(fileName);
            bool OK = DataAcess.Connect.ExecSQL(sqlSave);
            if (OK)
            {
                if (System.IO.File.Exists(DesF + "\\" + sortF))
                    System.IO.File.Delete(DesF + "\\" + sortF);

                System.IO.File.Move(fileName, DesF + "\\" + sortF);
            }
            else
                ss += sortF + "\r\n";
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
    //────────────────────────────────────────────────────────────────────────────────────────── 
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

    public static void MsgAlert(Page pParent, string StrText)
    {
        string strScript = "window.confirm (\'" + StrText + "\');";
        //string strScript = "if (window.confirm (\'" + StrText + "\')==true)return true;else return false;";
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
            return int.Parse(ojb.ToString());
        }
        catch
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
        if (strDate == null || strDate == "")
        {
            return "";
        }
        if (strDate.Length == "08/01/2012 00:00:00".Length)
        {
            strDate = strDate.Substring(0, "08/01/2012".Length);
        }
        if (strDate.Length == "11/18/2012 12:07:00 PM".Length)
        {
            strDate = strDate.Substring(0, "11/18/2012".Length);
        }

        string[] arrDDMMYY;
        arrDDMMYY = strDate.Split('/');
        int intDay;
        int intMonth;
        int intYear;
        try
        {
            intDay = System.Convert.ToInt32(arrDDMMYY[0]);
            intMonth = System.Convert.ToInt32(arrDDMMYY[1]);
            intYear = System.Convert.ToInt32(arrDDMMYY[2]);
            //				DateTime dtmDate = new DateTime(intYear, intMonth, intDay);
            if (intMonth > 12)
            {
                int temp = intMonth;
                intMonth = intDay;
                intDay = temp;
            }
            //return intYear + "/" + intMonth + "/" + intDay;
            #region nvk str
            string nvk_Day = intDay.ToString().Trim();
            string nvk_Month = intMonth.ToString().Trim();
            string nvk_Year = intYear.ToString().Trim();
            if (nvk_Day.Length == 1)
                nvk_Day = "0" + nvk_Day;
            if (nvk_Month.Length == 1)
                nvk_Month = "0" + nvk_Month;
            return nvk_Year + "/" + nvk_Month + "/" + nvk_Day;
            #endregion
        }
        catch (Exception)
        {
            return "";
        }
    }
    static public int GetSoNgay(int iThang, int iNam)
    {
        return DateTime.DaysInMonth(iNam, iThang);
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
        string s = "";
        // nvk create MaPhieuTra (cho phép xóa Phiếu trong ngày vẫn đúng mã)
        #region nvk create MaPhieuTra
        for (int k = 0; k < 2; k++)
        {
            s = "PTT-" + dNgay.ToString("ddMMyyyy") + "-" + nCount.ToString();
            string sql_nvkChekMa = "select * from nvk_thuoc_phieuyctra where SoPhieu='" + s + "'";
            DataTable dtBN_nvk = DataAcess.Connect.GetTable(sql_nvkChekMa);
            if (dtBN_nvk != null && dtBN_nvk.Rows.Count > 0)
            {
                k--; nCount++;
            }
            else
                break;
        }
        #endregion
        return s;
    }
    public static string NewPhieuYeuCauLinhThuoc(string NgayYeuCau)
    {
        NgayYeuCau += " 23:59:59";
        string sqlSelect = "select count(*) from Thuoc_PhieuYCXuat where year(ngayYC)= year('" + NgayYeuCau + "') and month(ngayYc)= month('" + NgayYeuCau + "') and day(ngayyc)=day('" + NgayYeuCau + "')";
        DataTable dtCountBN = DataAcess.Connect.GetTable(sqlSelect);
        int nCount = 0;
        if (dtCountBN != null || dtCountBN.Rows.Count > 0)
            nCount = int.Parse(dtCountBN.Rows[0][0].ToString());
        nCount++;
        string sCount = nCount.ToString();
        DateTime dNgay = DateTime.Parse(NgayYeuCau);
        string s = "";
        // nvk create MaPhieuTra (cho phép xóa Phiếu trong ngày vẫn đúng mã)
        #region nvk create MaPhieuTra
        for (int k = 0; k < 2; k++)
        {
            s = "PYC-" + dNgay.ToString("ddMMyyyy") + "-" + nCount.ToString();
            string sql_nvkChekMa = "select * from thuoc_phieuycxuat where SoPhieu='" + s + "'";
            DataTable dtBN_nvk = DataAcess.Connect.GetTable(sql_nvkChekMa);
            if (dtBN_nvk != null && dtBN_nvk.Rows.Count > 0)
            {
                k--; nCount++;
            }
            else
                break;
        }
        #endregion
        return s;
    }
    public static string nvk_CheckNewMaPhieuYC(object SoPhieuYC)
    {
        string curentDay = DateTime.Now.ToString("yyyy/MM/dd");
        if (SoPhieuYC == null || SoPhieuYC.ToString().Equals(""))
            return NewPhieuYeuCauLinhThuoc(curentDay);
        string sqlCheck = "select idphieuyc from thuoc_phieuycxuat where sophieu='" + SoPhieuYC.ToString() + "'";
        DataTable dt = DataAcess.Connect.GetTable(sqlCheck);
        if (dt != null && dt.Rows.Count > 0)
        {
            return NewPhieuYeuCauLinhThuoc(curentDay);
        }
        else
            return SoPhieuYC.ToString();
    }
    public static string nvk_CheckNewMaPhieuTra(object SoPhieuYC)
    {
        string curentDay = DateTime.Now.ToString("yyyy/MM/dd");
        if (SoPhieuYC == null || SoPhieuYC.ToString().Equals(""))
            return NewPhieuYeuCauTraThuoc(curentDay);
        string sqlCheck = "select idphieuycTra from nvk_thuoc_phieuyctra where sophieu='" + SoPhieuYC.ToString() + "'";
        DataTable dt = DataAcess.Connect.GetTable(sqlCheck);
        if (dt != null && dt.Rows.Count > 0)
        {
            return NewPhieuYeuCauTraThuoc(curentDay);
        }
        else
            return SoPhieuYC.ToString();
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
        if (objNumber.ToString().Trim() == "") return 0;
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
                if ((i + 1) % 3 == 0) strInt += ",";
            }

            strInt = strInt.Substring(0, strInt.Length - 1);

            object objResult = strInt + "." + strAdd;
            if (!isDB) return strInt;
            return objResult;
        }
        else
        {
            return "0.00";
        }
    }

    //==============================================================
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
        string sqlSelect = "SELECT " + FielName1 + " FROM " + TableName + " WHERE 1=1  ";
        if (FielName1 != null && FielName1 != "")
            sqlSelect += "  AND " + FielName1 + "=N'" + FieldValue1 + "'";
        if (FielName2 != null && FielName2 != "")
            sqlSelect += " AND " + FielName2 + "=N'" + FieldValue2 + "'";

        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
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
    public static void DeleteRow(string TableName, string PrimaryKeyName, string PrimaryKeyValue)
    {
        DataAcess.Connect.ExecSQL("DELETE FROM " + TableName + " WHERE " + PrimaryKeyName + "=N'" + PrimaryKeyValue + "'");
    }
    public static void DeleteRow(string TableName, string PrimaryKeyName, int PrimaryKeyValue)
    {
        DeleteRow(TableName, PrimaryKeyName, PrimaryKeyValue.ToString());
    }
    static public int KiemTraChuNhat(string sYMD)
    {
        int ikq = 0;
        string ssql = "SELECT dbo.GetTenThuTrongTuan('" + sYMD + "') as KQ";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt != null && dt.Rows.Count > 0)
        {
            ikq = ParseInt(dt.Rows[0]["KQ"]);
        }
        return ikq;
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
    #endregion
    #region Nhan Su
    static public string MaxIdNhanSuTheoTable(string TableName, string FielId)
    {
        string createId = "select isnull(max(" + FielId + "),0)+1 as MaxID from " + TableName + "";
        DataTable dtId = DataAcess.Connect.GetTable(createId);
        return dtId.Rows[0][0].ToString();
    }
    public static int NamGioiHan
    {
        get
        {

            string ConnectFileName = P.Server.MapPath("~/App_Data/Nam.txt");
            string fileName = ConnectFileName;
            if (!System.IO.File.Exists(fileName))
                return 2020;
            string s = System.IO.File.ReadAllText(fileName);
            if (s == null || s == "") return 2020;
            return ParseInt(s);

        }
    }
    public static int LuongCoBan
    {
        get
        {

            string ConnectFileName = P.Server.MapPath("~/App_Data/LuongCoBan.txt");
            string fileName = ConnectFileName;
            if (!System.IO.File.Exists(fileName))
                return 830000;
            string s = System.IO.File.ReadAllText(fileName);
            if (s == null || s == "") return 830000;
            return ParseInt(s);

        }
    }
    public static int FontSizeHopDong
    {
        get
        {

            string ConnectFileName = P.Server.MapPath("~/App_Data/FontSizeHopDong.txt");
            string fileName = ConnectFileName;
            if (!System.IO.File.Exists(fileName))
                return 13;
            string s = System.IO.File.ReadAllText(fileName);
            if (s == null || s == "") return 13;
            return ParseInt(s);

        }
    }
    public static double HeSoLuongCB
    {
        get
        {

            string ConnectFileName = P.Server.MapPath("~/App_Data/HeSoLuongCB.txt");
            string fileName = ConnectFileName;
            if (!System.IO.File.Exists(fileName))
                return 1.86;
            string s = System.IO.File.ReadAllText(fileName);
            if (s == null || s == "") return 1.86;
            return Math.Round(ParseFloat(s), 2);
        }
    }
    static public object FormatNumberOption(object objNumber, string PhanNgan, string ThapPhan, bool isDB)
    {
        objNumber = Convert.ToDouble(objNumber);
        if (StaticData.ParseFloat(objNumber) == 0) return "0.00";
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
                if ((i + 1) % 3 == 0) strInt += PhanNgan;
            }

            strInt = strInt.Substring(0, strInt.Length - 1);

            object objResult = strInt + "" + ThapPhan + "" + strAdd;
            if (!isDB) return strInt;
            return objResult;
        }
        else
        {
            return "0.00";
        }
    }
    #endregion
    public static void Update_Parameter()
    {
        Page P = new Page();
        string SourceF = P.Server.MapPath("~/App_Data");
        if (!System.IO.Directory.Exists(SourceF)) return;
        string[] arrS = System.IO.Directory.GetFiles(SourceF);
        if (arrS.Length == 0) return;
        DataTable dtCount = DataAcess.Connect.GetTable("SELECT MAX(Id) FROM KB_Parameter");
        int MaxID = 1;
        if (dtCount == null) return;
        if (dtCount.Rows.Count == 0 || dtCount.Rows[0][0].ToString() == "") MaxID = 1;
        else
            MaxID = int.Parse(dtCount.Rows[0][0].ToString()) + 1;
        for (int i = 0; i < arrS.Length; i++)
        {

            string fileName = arrS[i];
            string sortF = System.IO.Path.GetFileName(fileName);
            if (sortF != "SaoLuuPhucHoiDB.exe" && sortF != "ServerConfig.txt" && sortF != "SystemLanguage.txt" && sortF != "SystemLanguage_IsShort.txt")
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
                    System.IO.File.Delete(fileName);

                }
            }

        }

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
    public static bool OutputCodeIsNumber
    {
        get
        {
            string OK = GetParameter("OutputCodeIsNumber");
            if (OK == "1") return true;
            return false;
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
            STT = tbPN.Rows[0][0].ToString();
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
    public static int DoiTuSoLaMaSangInt(string pstrRomanNumeral)
    {

        int[] aintRomanValues = null;
        int intInputLen = 0;
        int intSum = 0;
        intInputLen = pstrRomanNumeral.Length;

        if (intInputLen == 0)
            return 0;

        Array.Resize(ref aintRomanValues, intInputLen);
        for (int intX = 0; intX < intInputLen; intX++)
        {
            switch (pstrRomanNumeral.Substring(intX, 1))
            {

                case "M": aintRomanValues[intX] = 1000; break;
                case "D": aintRomanValues[intX] = 500; break;
                case "C": aintRomanValues[intX] = 100; break;
                case "L": aintRomanValues[intX] = 50; break;
                case "X": aintRomanValues[intX] = 10; break;
                case "V": aintRomanValues[intX] = 5; break;
                case "I": aintRomanValues[intX] = 1; break;
            };
        }
        for (int intX = 0; intX < intInputLen; intX++)
        {
            if (intX == intInputLen - 1)
                intSum = intSum + aintRomanValues[intX];
            else
                if (aintRomanValues[intX] >= aintRomanValues[intX + 1])
                    intSum = intSum + aintRomanValues[intX];
                else
                    intSum = intSum - aintRomanValues[intX];

        }
        return intSum;

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
    static public string TaoMaSoPhieu(string sBegin, string sTableName, string sFieldMa, string sNgay, string sdates, string sFieldOrder)
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
    public static string KhoThuocDV
    {
        get
        {
            return GetParaValueDB("KhoThuocDV");

        }
    }
    public static string KhoHuHongVo
    {
        get
        {
            return GetParaValueDB("nvk_idKhoHuHongVo");

        }
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
    public static string MacDinhKhoNhapMuaID
    {
        get
        {


            System.Web.UI.Page P = new Page();
            string ConnectFileName = P.Server.MapPath("~/App_Data/MacDinhKhoNhapMuaID.txt");
            string fileName = ConnectFileName;
            if (!System.IO.File.Exists(fileName))
                return "4";
            string s = System.IO.File.ReadAllText(fileName);
            if (s == null || s == "") return "4";
            return s;
        }
    }
    public static string NVK_MacDinhKhoNhapMuaID
    {
        get
        {
            return GetParaValueDB("KhoNhapMuaID");
        }
    }
    public static bool nvk_CapNhatTonAoThuoc_One(string idthuoc)
    {
        bool ktUp = false;
        string sqlEx = "select * from nvk_TonAoThuoc where idthuoc ='" + idthuoc + "'";
        DataTable dtEx = DataAcess.Connect.GetTable(sqlEx);
        string sqlUp = "";
        if (dtEx != null && dtEx.Rows.Count > 0)
        {
            sqlUp = "update nvk_tonaothuoc set  tonao =dbo.thuoc_dutru('" + idthuoc + "') where idthuoc ='" + idthuoc + "'";
        }
        else
        {
            sqlUp = "insert into nvk_TonAoThuoc (idthuoc,TonAo,tonAoTuTruc) values (" + idthuoc + ",dbo.thuoc_dutru('" + idthuoc + "'),0)";
        }
        ktUp = DataAcess.Connect.ExecSQL(sqlUp);
        return ktUp;
    }
    public static bool nvk_CapNhatTonAoThuoc(string idkho, string idthuoc, float soluongcapnhat)
    {
        return nvk_CapNhatTonAoThuoc_One(idthuoc);
        #region Code Old Not use
        //string LoaiKho = DataAcess.Connect.GetTable("select isnull((select nvk_loaikho from khothuoc where isnull(idkhoa,0) <>1 and idkho='" + idkho + "'),0)").Rows[0][0].ToString();
        //if (LoaiKho.Equals("1") || LoaiKho.Equals("2") || LoaiKho.Equals("3"))// =1: khi tạo phiếu yc tay, =2: cđịnh tủ trực, =3: chỉ định từ kho ảo
        //{
        //    string TenLoaiTon = "TonAo";
        //    if (LoaiKho.Equals("2"))
        //        TenLoaiTon = "tonAoTuTruc";
        //    string sqlEx = "select * from nvk_TonAoThuoc where idthuoc ='" + idthuoc + "'";
        //    DataTable dtEx = DataAcess.Connect.GetTable(sqlEx);
        //    string sqlUp = "";
        //    if (dtEx != null && dtEx.Rows.Count > 0)
        //    {
        //        sqlUp = "update nvk_TonAoThuoc set " + TenLoaiTon + "= " + TenLoaiTon + " + " + soluongcapnhat + " where idthuoc =" + idthuoc + " -- and (" + TenLoaiTon + " + " + soluongcapnhat + ") >=0";
        //        ktUp = DataAcess.Connect.ExecSQL(sqlUp);
        //        if (ktUp)
        //            return ktUp;
        //    }
        //    else if (soluongcapnhat > 0)
        //    {
        //        sqlUp = "insert into nvk_TonAoThuoc (idthuoc,TonAo,tonAoTuTruc) values (" + idthuoc + ",0,0)";
        //        ktUp = DataAcess.Connect.ExecSQL(sqlUp);
        //        sqlUp = "update nvk_tonaothuoc set " + TenLoaiTon + "=" + soluongcapnhat + " where idthuoc =" + idthuoc + " --and idTonAo = isnull( (select max(idtonao) from nvk_tonaothuoc),1)";
        //        ktUp = DataAcess.Connect.ExecSQL(sqlUp);
        //    }
        //}
        #endregion
        //return ktUp;
    }
    public static string CheckDate_kt(string strDate)
    {
        if (strDate == null || strDate == "")
        {
            return "";
        }
        string[] arrDDMMYY;
        arrDDMMYY = strDate.Split('/');
        string intDay;
        string intMonth;
        string intYear;
        try
        {
            intDay = arrDDMMYY[0];
            intMonth = arrDDMMYY[1];
            intYear = arrDDMMYY[2];
            //DateTime dtmDate = new DateTime(intYear, intMonth, intDay);
            if (Int16.Parse(intMonth) > 12)
            {
                string temp = intMonth;
                intMonth = intDay;
                intDay = temp;
            }
            return intYear + "/" + intMonth + "/" + intDay;
            //return intMonth + "/" + intDay + "/" + intYear;
        }
        catch (Exception)
        {
            return "";
        }
    }
    public static string TenPhieuXuatbanLe
    {
        get
        {
            System.Web.UI.Page P = new Page();
            string ConnectFileName = P.Server.MapPath("~/App_Data/TenPhieuXuatbanLe.txt");
            string fileName = ConnectFileName;
            if (!System.IO.File.Exists(fileName))
                return "XUẤT BÁN LẺ";
            string s = System.IO.File.ReadAllText(fileName);
            if (s == null || s == "") return "XUẤT BÁN LẺ";
            return s;
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
            string S = GetParaValueDB("ChoPhepXuatToaCu");
            if (S == "1") return true;
            return false;

        }
    }
    public static string NewSoVaoVien(string thang, string nam)
    {
        string nam2N = nam;
        if (thang.Length == 1)
            thang = "0" + thang;
        if (nam.Length == 4)
            nam2N = nam.Substring(2, 2);

        string sql1 = @"select SoVaoVienTruoc=isnull(
                        (	select top 1 sovaovien from khambenh kb where isnull(sovaovien,'0')<>'0' AND isnull(sovaovien,'')<>''
	                        and datepart(MM,kb.ngaykham)=" + thang + @" and datepart(yyyy,kb.ngaykham)=" + nam + @"
	                        order by idkhambenh desc
                         ),'0/0112') ";
        DataTable tb1 = DataAcess.Connect.GetTable(sql1);
        if (tb1.Rows.Count > 0)
        {
            string SoVaoVienTruoc = tb1.Rows[0]["SoVaoVienTruoc"].ToString();
            string[] arr = SoVaoVienTruoc.Split('/');
            int SoDauMoi = StaticData.ParseInt(arr[0]) + 1;
            return SoDauMoi.ToString() + '/' + thang + nam2N;
        }
        else
            return "1/" + thang + nam2N;
    }
    public static bool CapNhatSoVaoVien_KhamBenh(string idchitietdangkykham, string SoVaoVien)
    {
        string sql = @"update khambenh set sovaovien='" + SoVaoVien + @"' where idchitietdangkykham=" + idchitietdangkykham + "";
        bool kt = DataAcess.Connect.ExecSQL(sql);
        return kt;
    }
    public static string getBitvalue(string s)
    {
        if (s == null || s.Trim() == "") return "0";
        s = s.Trim().ToLower();
        if (s == "1" || s == "true") return "1";
        return "0";

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
    public static string MaDonViKhoaDuoc
    {
        get
        {
            return GetParaValueDB("MaDonViKhoaDuoc");
        }
    }
    public static bool NVK_CapNhatTinhTrangGiuong(string ngay, string idctdkk, string idnoitru, string idkb_Giuong)
    {
        if (ngay.Equals("") || ngay.Equals("0") || (idnoitru == "0" && idkb_Giuong == "0"))
            return true;
        if (idnoitru != "0" && idnoitru != "")
        {
            #region cập nhật dựa vào benhnhannoitru
            string sql = "select * from benhnhannoitru where idchitietdangkykham=" + idctdkk + " and convert(varchar(10),ngayvaovien,103)='" + ngay + "' and idnoitru=" + idnoitru;
            DataTable dtGiuongNgayTruoc = DataAcess.Connect.GetTable(sql);
            bool ktsetChon = false;
            if (dtGiuongNgayTruoc.Rows.Count > 0) //set chon nội trú trong ngày, hủy chọn ischonngaysau nội trú trước
            {
                sql = @"update benhnhannoitru set ischontrongngay=1 where idnoitru=" + idnoitru + @"";
                ktsetChon = DataAcess.Connect.ExecSQL(sql);
                if (ktsetChon)
                {
                    #region hủy chọn ischonngaysau benhnhannoitru
                    sql = @"update benhnhannoitru set ischonngaysau=0 where idnoitru=
                    isnull((select top 1 idnoitru from benhnhannoitru where idchitietdangkykham=" + idctdkk + @"
	                    and ngayvaovien < dateadd(dd,0,'" + StaticData.CheckDate(ngay) + @"')
                    order by ngayvaovien desc
                    ),0)";
                    bool ktupNTTruoc = DataAcess.Connect.ExecSQL(sql);
                    #endregion
                    #region hủy chọn ischonngaysau kb_giuongphieuthanhtoan
                    //                    sql = @"update kb_giuongphieuthanhtoan set ischonngaysau=0 where IDgiuong=
                    //                    isnull((select top 1 IDgiuong from kb_giuongphieuthanhtoan where idchitietdangkykham=" + idctdkk + @"
                    //	                    and ngayxetgiuong < dateadd(dd,0,'" + StaticData.CheckDate(ngay) + @"')
                    //                    order by ngayxetgiuong desc
                    //                    ),0)";
                    //                    ktupNTTruoc = DataAcess.Connect.ExecSQL(sql);
                    #endregion
                }
            }
            else  //Trường hợp này chỉ dùng cho gọi trong ajax
            {
                sql = "update benhnhannoitru set ischonngaysau=1 where idnoitru=" + idnoitru;
                ktsetChon = DataAcess.Connect.ExecSQL(sql);
                #region hủy chọn ischonngaysau kb_giuongphieuthanhtoan
                //                sql = @"update kb_giuongphieuthanhtoan set ischonngaysau=0 where IDgiuong=
                //                    isnull((select top 1 IDgiuong from kb_giuongphieuthanhtoan where idchitietdangkykham=" + idctdkk + @"
                //	                     and ngayxetgiuong < dateadd(dd,0,'" + StaticData.CheckDate(ngay) + @"')
                //                    order by ngayxetgiuong desc
                //                    ),0)";
                //                bool ktupNTTruoc = DataAcess.Connect.ExecSQL(sql);
                #endregion
            }
            //ktsetChon = DataAcess.Connect.ExecSQL(sql);
            if (ktsetChon)
            {
                #region hủy chọn ischontrongngay benhnhannoitru
                sql = "update benhnhannoitru set ischontrongngay=0 where idchitietdangkykham=" + idctdkk + " and convert(varchar(10),ngayvaovien,103)='" + ngay + "' and idnoitru<>" + idnoitru;
                bool ktSetHuyChon = DataAcess.Connect.ExecSQL(sql);
                #endregion
                #region hủy chọn ischontrongngay kb_giuongphieuthanhtoan
                //sql = "update kb_giuongphieuthanhtoan set ischontrongngay=0 where idchitietdangkykham=" + idctdkk + " and convert(varchar(10),ngayxetgiuong,103)='" + ngay + "'";
                //ktSetHuyChon = DataAcess.Connect.ExecSQL(sql);
                #endregion
                return ktSetHuyChon;
            }
            #endregion
        }
        #region không dùng kb_giuongphieuthanhtoan
        else if (idkb_Giuong != "0" && idkb_Giuong != "")
        {
            #region cập nhật dựa vào kb_giuongphieuthanhtoan
            string sql = "select * from kb_giuongphieuthanhtoan where idchitietdangkykham=" + idctdkk + " and convert(varchar(10),ngayxetgiuong,103)='" + ngay + "' and IDgiuong=" + idkb_Giuong;
            DataTable dtGiuongNgayTruoc = DataAcess.Connect.GetTable(sql);
            bool ktsetChon = false;
            if (dtGiuongNgayTruoc.Rows.Count > 0) //set chon nội trú trong ngày, hủy chọn ischonngaysau nội trú trước
            {
                sql = @"update kb_giuongphieuthanhtoan set ischontrongngay=1 where IDgiuong=" + idkb_Giuong + @"";
                ktsetChon = DataAcess.Connect.ExecSQL(sql);
                if (ktsetChon)
                {
                    #region hủy chọn ischonngaysau benhnhannoitru
                    sql = @"update benhnhannoitru set ischonngaysau=0 where idnoitru=
                    isnull((select top 1 idnoitru from benhnhannoitru where idchitietdangkykham=" + idctdkk + @"
	                    and ngayvaovien < dateadd(dd,0,'" + StaticData.CheckDate(ngay) + @"')
                    order by ngayvaovien desc
                    ),0)";
                    bool ktupNTTruoc = DataAcess.Connect.ExecSQL(sql);
                    #endregion
                    #region hủy chọn ischonngaysau kb_giuongphieuthanhtoan
                    sql = @"update kb_giuongphieuthanhtoan set ischonngaysau=0 where IDgiuong=
                    isnull((select top 1 IDgiuong from kb_giuongphieuthanhtoan where idchitietdangkykham=" + idctdkk + @"
	                    and ngayxetgiuong < dateadd(dd,0,'" + StaticData.CheckDate(ngay) + @"')
                    order by ngayxetgiuong desc
                    ),0)";
                    ktupNTTruoc = DataAcess.Connect.ExecSQL(sql);
                    #endregion
                }
            }
            else  //Trường hợp này chỉ dùng cho gọi trong ajax
            {
                sql = "update kb_giuongphieuthanhtoan set ischonngaysau=1 where IDgiuong=" + idkb_Giuong;
                #region hủy chọn ischonngaysau benhnhannoitru
                sql = @"update benhnhannoitru set ischonngaysau=0 where idnoitru=
                    isnull((select top 1 idnoitru from benhnhannoitru where idchitietdangkykham=" + idctdkk + @"
	                    and ngayvaovien < dateadd(dd,0,'" + StaticData.CheckDate(ngay) + @"')
                    order by ngayvaovien desc
                    ),0)";
                bool ktupNTTruoc = DataAcess.Connect.ExecSQL(sql);
                #endregion
            }
            //ktsetChon = DataAcess.Connect.ExecSQL(sql);
            if (ktsetChon)
            {
                #region hủy chọn ischontrongngay kb_giuongphieuthanhtoan
                sql = "update kb_giuongphieuthanhtoan set ischontrongngay=0 where idchitietdangkykham=" + idctdkk + " and convert(varchar(10),ngayxetgiuong,103)='" + ngay + "' and IDgiuong<>" + idkb_Giuong;
                bool ktSetHuyChon = DataAcess.Connect.ExecSQL(sql);
                #endregion
                #region hủy chọn ischontrongngay benhnhannoitru
                sql = "update benhnhannoitru set ischontrongngay=0 where idchitietdangkykham=" + idctdkk + " and convert(varchar(10),ngayvaovien,103)='" + ngay + "'";
                ktSetHuyChon = DataAcess.Connect.ExecSQL(sql);
                #endregion
                return ktSetHuyChon;
            }
            #endregion
        }
        #endregion

        return false;
    }
    public static bool NVK_XoaXuatKhoTheoCTBNTT(string idchitietbenhnhantoathuoc)
    {
        string sql = "delete from chitietphieuxuatkho where idchitietbenhnhantoathuoc ='" + idchitietbenhnhantoathuoc + "'";
        return DataAcess.Connect.ExecSQL(sql);
    }

    public static string NVK_LoadMenuPhanHe(string dkmenu)
    {
        dkmenu = dkmenu.ToLower();
        string LinkMenu = "";
        if (dkmenu == "tiepnhan".ToLower())
        {
            LinkMenu = "~/tiepnhan/uscmenu.ascx";
        }
        else if (dkmenu == "thuphi".ToLower())
        {
            LinkMenu = "~/ThuVienPhi/uscmenu.ascx";
        }
        else if (dkmenu == "kb".ToLower())
        {
            LinkMenu = "~/khambenh_TH/uscmenu.ascx";
        }
        else if (dkmenu == "khambenh".ToLower())
        {
            LinkMenu = "~/khambenh_TH/uscmenu.ascx";
        }
        else if (dkmenu == "khambenh_TH".ToLower())
        {
            LinkMenu = "~/khambenh_TH/uscmenu.ascx";
        }
        else if (dkmenu == "capcuu".ToLower())
        {
            LinkMenu = "~/capcuu/uscmenu.ascx";
        }
        else if (dkmenu == "khoasan".ToLower())
        {
            LinkMenu = "~/khoasan/uscmenu.ascx";
        }
        else if (dkmenu == "khoanoi".ToLower())
        {
            LinkMenu = "~/khoanoi/uscmenu.ascx";
        }
        else if (dkmenu == "khoangoai".ToLower())
        {
            LinkMenu = "~/khoangoai/uscmenu.ascx";
        }
        else if (dkmenu == "khoaphauthuat".ToLower())
        {
            LinkMenu = "~/KhoaPhauThuat/uscmenu.ascx";
        }
        else if (dkmenu == "tansoi".ToLower())
        {
            LinkMenu = "~/tansoi/uscmenu.ascx";
        }
        else if (dkmenu == "hoatri".ToLower())
        {
            LinkMenu = "~/HoaTri/uscmenu_HoaTri.ascx";
        }
        else if (dkmenu == "quanlyND".ToLower())
        {
            LinkMenu = "~/GiamDinhBHYT/uscmenu.ascx";
        }
        else if (dkmenu == "thongke".ToLower())
        {
            LinkMenu = "~/thongke/uscmenu.ascx";
        }
        else if (dkmenu == "phongsanh".ToLower())
        {
            LinkMenu = "~/khoasan/uscmenu_NgoaiSan.ascx";
        }
        else if (dkmenu == "cls".ToLower())
        {
            LinkMenu = "~/canlamsang/uscmenu.ascx";
        }
        else if (dkmenu == "canlamsang".ToLower())
        {
            LinkMenu = "~/canlamsang/uscmenu.ascx";
        }
        else if (dkmenu == "KhoHCQT".ToLower())
        {
            LinkMenu = "~/KhoHCQT/uscmenu.ascx";
        }
        else if (dkmenu == "GiamDinhBHYT".ToLower())
        {
            LinkMenu = "~/GiamDinhBHYT/uscmenu.ascx";
        }
        else if (dkmenu == "DanhMuc_JSon".ToLower())
        {
            LinkMenu = "~/DanhMuc_JSon/uscmenu.ascx";
        }
        else if (dkmenu == "KT_DanhMuc".ToLower())
        {
            LinkMenu = "~/ketoan/Menu_KT/uscmenuKT_HeThongDanhMuc.ascx";
        }
        else if (dkmenu == "VienPhi_TH".ToLower())
        {
            LinkMenu = "~/VienPhi_TH/uscmenu.ascx";
        }
        else if (dkmenu == "khoaduoc".ToLower())
        {
            LinkMenu = "~/QLDuoc/web/uscmenu.ascx";
        }
        else if (dkmenu == "quayptdv".ToLower())
        {
            LinkMenu = "~/QLDuoc/web/ucMenuQuayPTDV.ascx";
        }
        else if (dkmenu == "ketoanduoc".ToLower())
        {
            LinkMenu = "~/KETOANDUOC/web/uscmenu.ascx";
        }
        else if (dkmenu == "nomenu".ToLower())
        {
            LinkMenu = "";
        }
        else
            LinkMenu = "uscmenu.ascx";
        return LinkMenu;
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
            bool ok = false;
            while (ok == false)
            {

                d++;
                MaPhieu_tepm = "PT-" + DateTime.Parse(SysDate_).ToString("yyMM") + "0000000".Substring(0, 5 - d.ToString().Length) + d.ToString();
                string sqlSave = "insert into Kb_SoBienLai(SoTT,SysDate,MaBienLai) values(" + d.ToString() + ",'" + SysDate_ + "','" + MaPhieu_tepm + "')";
                ok = DataAcess.Connect.ExecSQL(sqlSave);
            }
        }
        return MaPhieu_tepm;


    }
    #endregion

    #region SoluongBNDaKham
    public static string GetSLBNChoKham(string PhongID, string NgayDangKy)
    {
        return "0";
        if (PhongID == "") PhongID = "0";
        string sqlstt = @"select count(A.idchitietdangkykham)  as SoTT 
                            from    chitietdangkykham A  
                            LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM 
                            WHERE A.PHONGID=" + PhongID
                                         + " AND YEAR(ngaydangky)=YEAR('" + NgayDangKy + "')" + "\r\n"
                                         + " AND MONTH(ngaydangky)=MONTH('" + NgayDangKy + "')" + "\r\n"
                                         + " AND DAY(ngaydangky)=DAY('" + NgayDangKy + "')" + "\r\n"
                                         + " AND NOT EXISTS (SELECT IDKHAMBENH FROM KHAMBENH WHERE IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM)";
        DataTable dtb = DataAcess.Connect.GetTable(sqlstt);
        if (dtb != null) return dtb.Rows[0][0].ToString();
        return "0";
    }
    #endregion
    #region SoluongBNDaKham
    public static string GetSLBNDaKham(string PhongID, string NgayDangKy)
    {
        return "0";

        if (PhongID == "") PhongID = "0";
        string sqlstt = @"select count(A.idchitietdangkykham)  as SoTT 
                            from    chitietdangkykham A  
                            LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM 
                            WHERE A.PHONGID=" + PhongID
                                         + " AND YEAR(ngaydangky)=YEAR('" + NgayDangKy + "')" + "\r\n"
                                         + " AND MONTH(ngaydangky)=MONTH('" + NgayDangKy + "')" + "\r\n"
                                         + " AND DAY(ngaydangky)=DAY('" + NgayDangKy + "')" + "\r\n"
                                         + " AND   EXISTS (SELECT IDKHAMBENH FROM KHAMBENH WHERE IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM)";
        DataTable dtb = DataAcess.Connect.GetTable(sqlstt);
        if (dtb != null) return dtb.Rows[0][0].ToString();
        return "0";
    }
    #endregion
    #region Links khám bệnh
    public static string KhamBenhLink
    {
        get
        {
            string ChonPhongTruocKhiKham = GetParaValueDB("ChonPhongTruocKhiKham");
            if (ChonPhongTruocKhiKham == null || ChonPhongTruocKhiKham != "1")
                return "KhamBenh/Index.aspx";
            return "ChonPK.aspx";
        }
    }
    #endregion
    #region Tính lại tiền cho bệnh nhân
    public static bool TinhLaiTien_ByIdDangKyKham(string IdDangKyKham, string IsBenhNhanMoi)
    {
        string SQLUpdate = " EXEC zHS_TONGTIENBHYT " + IdDangKyKham;
        if (IsBenhNhanMoi == "1")
            SQLUpdate = " EXEC zHS_TONGTIENBHYT_Full " + IdDangKyKham + ",1";

        bool OK = DataAcess.Connect.ExecSQL(SQLUpdate);
        if (!OK)
        {
            MsgAlert(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
        }
        return OK;
    }
    public static bool TinhLaiTien_ByIdDangKyKham(string IdDangKyKham)
    {
        return TinhLaiTien_ByIdDangKyKham(IdDangKyKham, "0");
    }
    public static bool TinhLaiTien_ByIdKhamBenh(string IdKhamBenh)
    {
        string sqlSelect = "SELECT IDDANGKYKHAM FROM KHAMBENH WHERE IDKHAMBENH=" + IdKhamBenh;
        DataTable DT = DataAcess.Connect.GetTable(sqlSelect);
        if (DT == null || DT.Rows.Count == 0)
        {
            MsgAlert(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
            return false;
        }
        string IdDangKyKham = DT.Rows[0][0].ToString();
        string SQLUpdate = " EXEC zHS_TONGTIENBHYT " + IdDangKyKham;
        bool OK = DataAcess.Connect.ExecSQL(SQLUpdate);
        if (!OK)
        {
            MsgAlert(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
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
            MsgAlert(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
            return false;
        }
        string IdDangKyKham = DT.Rows[0][0].ToString();
        string SQLUpdate = " EXEC zHS_TONGTIENBHYT " + IdDangKyKham;
        bool OK = DataAcess.Connect.ExecSQL(SQLUpdate);
        if (!OK)
        {
            MsgAlert(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
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
            MsgAlert(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
            return false;
        }
        string IdDangKyKham = DT.Rows[0][0].ToString();
        string SQLUpdate = " EXEC zHS_TONGTIENBHYT " + IdDangKyKham;
        bool OK = DataAcess.Connect.ExecSQL(SQLUpdate);
        if (!OK)
        {
            MsgAlert(new Page(), "Không tính tiền được , vui lòng liên hệ Admin");
        }
        return OK;
    }


    #endregion
    #region Đóng phí khám bệnh
    public static void DongPhiKham(string iddangkykham)
    {
        bool ok_UpdateDathu = DataAcess.Connect.ExecSQL("EXEC zHS_DongPhiKham " + iddangkykham);
    }
    #endregion
    #region Function with Data Table
    public static void dt_Repalce(System.Data.DataTable dtResource, int Pos, System.Data.DataTable dtDes, int ToPos)
    {
        dt_Repalce(dtResource, Pos, ref  dtDes, ToPos);
    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static void dt_Repalce(System.Data.DataTable dtResource, int Pos, ref   System.Data.DataTable dtDes, int ToPos)
    {
        if (dtDes == null)
        {
            dtDes = new System.Data.DataTable();
            System.Data.DataColumn[] arrC = new System.Data.DataColumn[dtResource.Columns.Count];
            for (int i = 0; i < dtResource.Columns.Count; i++)
                dtDes.Columns.Add(dtResource.Columns[i].ColumnName, dtResource.Columns[i].DataType);
            dtDes.TableName = dtResource.TableName;
        }

        try
        {
            for (int i = 0; i < dtResource.Columns.Count; i++)
                dtDes.Rows[ToPos][i] = dtResource.Rows[Pos][i];
        }
        catch (Exception) { }

    }

    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static void dt_Paste(System.Data.DataTable dtResource, int Pos, System.Data.DataTable dtDes)
    {
        dt_Paste(dtResource, Pos, ref dtDes);
    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static void dt_Paste(System.Data.DataTable dtResource, int Pos, ref  System.Data.DataTable dtDes)
    {
        dt_Repalce(dtResource, Pos, dtDes, Pos);

    }
    //──────────────────────────────────────────────────────────────────────────────────────────  
    public static void dt_Copy(System.Data.DataTable dtResource, int Pos, System.Data.DataTable dtDes)
    {
        dt_Copy(dtResource, Pos, ref  dtDes);
    }
    //──────────────────────────────────────────────────────────────────────────────────────────  
    public static void dt_Copy(System.Data.DataTable dtResource, int Pos, ref   System.Data.DataTable dtDes)
    {
        if (dtDes == null)
        {
            dtDes = new System.Data.DataTable();
            System.Data.DataColumn[] arrC = new System.Data.DataColumn[dtResource.Columns.Count];
            for (int i = 0; i < dtResource.Columns.Count; i++)
                dtDes.Columns.Add(dtResource.Columns[i].ColumnName, dtResource.Columns[i].DataType);
            dtDes.TableName = dtResource.TableName;
        }
        else
            dtDes.Rows.Clear();

        System.Data.DataRow[] arrR = new System.Data.DataRow[dtResource.Rows.Count];
        dtResource.Rows.CopyTo(arrR, 0);
        dtDes.ImportRow(arrR[Pos]);
    }
    //──────────────────────────────────────────────────────────────────────────────────────────  
    public static void dt_ImportRow(System.Data.DataTable dtResource, int Pos, System.Data.DataTable dtDes)
    {
        dt_ImportRow(dtResource, Pos, ref  dtDes);
    }
    //──────────────────────────────────────────────────────────────────────────────────────────  
    public static void dt_ImportRow(System.Data.DataTable dtResource, int Pos, ref  System.Data.DataTable dtDes)
    {
        if (dtDes == null)
        {
            dtDes = new System.Data.DataTable();
            System.Data.DataColumn[] arrC = new System.Data.DataColumn[dtResource.Columns.Count];
            for (int i = 0; i < dtResource.Columns.Count; i++)
                dtDes.Columns.Add(dtResource.Columns[i].ColumnName, dtResource.Columns[i].DataType);
            dtDes.TableName = dtResource.TableName;
        }
        System.Data.DataRow[] arrR = new System.Data.DataRow[dtResource.Rows.Count];
        dtResource.Rows.CopyTo(arrR, 0);
        dtDes.ImportRow(arrR[Pos]);
    }
    //──────────────────────────────────────────────────────────────────────────────────────────  
    public static void dt_MoveRow(DataTable dtSource, int Pos, DataTable dtDes)
    {
        dt_MoveRow(ref dtSource, Pos, ref dtDes);
    }
    //──────────────────────────────────────────────────────────────────────────────────────────  
    public static void dt_MoveRow(ref  DataTable dtSource, int Pos, ref DataTable dtDes)
    {
        if (dtDes == null)
        {
            dtDes = new System.Data.DataTable();
            System.Data.DataColumn[] arrC = new System.Data.DataColumn[dtSource.Columns.Count];
            for (int i = 0; i < dtSource.Columns.Count; i++)
                dtDes.Columns.Add(dtSource.Columns[i].ColumnName, dtSource.Columns[i].DataType);
            dtDes.TableName = dtSource.TableName;
        }
        System.Data.DataRow[] arrR = new System.Data.DataRow[dtSource.Rows.Count];
        dtSource.Rows.CopyTo(arrR, 0);
        dtDes.ImportRow(arrR[Pos]);
        dtSource.Rows.RemoveAt(Pos);

    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static void dt_MoveRow(DataTable dtSource, DataTable dtDes)
    {
        dt_MoveRow(ref  dtSource, ref   dtDes);
    }
    //──────────────────────────────────────────────────────────────────────────────────────────     
    public static void dt_MoveRow(ref  DataTable dtSource, ref  DataTable dtDes)
    {
        if (dtDes == null)
        {
            dtDes = new System.Data.DataTable();
            System.Data.DataColumn[] arrC = new System.Data.DataColumn[dtSource.Columns.Count];
            for (int i = 0; i < dtSource.Columns.Count; i++)
                dtDes.Columns.Add(dtSource.Columns[i].ColumnName, dtSource.Columns[i].DataType);
            dtDes.TableName = dtSource.TableName;
        }
        System.Data.DataRow[] arrR = new System.Data.DataRow[dtSource.Rows.Count];
        dtSource.Rows.CopyTo(arrR, 0);
        for (int i = 0; i < arrR.Length; i++)
            dtDes.ImportRow(arrR[i]);
        dtSource.Rows.Clear();

    }
    //──────────────────────────────────────────────────────────────────────────────────────────  

    #endregion
    public static void OpenLink(System.Web.UI.Page P, string LinkName)
    {
        P.Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open ('" + LinkName + "')</script>");
    }
    public static string EnabledHavePermision(Page p, string Permisionname)
    {
        return "";
        if (SysParameter.UserLogin.IsAdmin(p))
            return "";
        bool rs = Profess.Userlogin.HavePermision(p, Permisionname);
        if (rs)
            return "";
        else
            return "disabled=true";
    }
    public static bool HavePermision(Page p, string Permisionname)
    {
        return true;
        if (SysParameter.UserLogin.IsAdmin(p))
            return true;
        else
            return Profess.Userlogin.HavePermision(p, Permisionname);
    }
    public static bool BoolDisabledPermision(Page p, string Permisionname)
    {
        return false;
        if (SysParameter.UserLogin.IsAdmin(p))
            return false;
        else if (Profess.Userlogin.HavePermision(p, Permisionname))
            return false;
        else
            return true;
    }
    public static string VisibleLinkXoaPermision(Page p, string Permisionname)
    {
        return "";
        if (SysParameter.UserLogin.IsAdmin(p))
            return "";
        bool rs = Profess.Userlogin.HavePermision(p, Permisionname);
        if (rs)
            return "";
        else
            return "style=\"display:none\"";
    }
    public static string StyleVisibleLinkXoaPermision(Page p, string Permisionname)
    {
        return "";
        if (SysParameter.UserLogin.IsAdmin(p))
            return "";
        bool rs = Profess.Userlogin.HavePermision(p, Permisionname);
        if (rs)
            return "";
        else
            return "display:none";
    }

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
                        csText = "một ";
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

        csResult = csResult.Replace("mươi một", "mươi mốt");
        return csResult;
    }
    //──────────────────────────────────────────────────────────────────────────────────────────   
    public static DataTable dtPhong_NgoaiTru()
    {

        string sql = @"SELECT * FROM DBO.HS_DSPHONG_NGOAITRU() 
                       ORDER BY ISNULL(SOTT,0),ISNULL(MASO,'') ,TENPHONG ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;


    }
    //-----------------------------
    public static DataTable dtPhong()
    {

        string sql = @"SELECT * FROM DBO.HS_DSPHONG() 
                       ORDER BY ISNULL(SOTT,0),ISNULL(MASO,'') ,TENPHONG ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;


    }
    //-----------------------------

    public static DataTable dtKhoa_NgoaiTru()
    {

        string sql = @"select * from phongkhambenh where isnoitru=0 and loaiphong=0";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;


    }
    //──────────────────────────────────────────────────────────────────────────────────────────   

    public static DataTable dtKhoa()
    {

        string sql = @"select * from phongkhambenh where  loaiphong=0";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;


    }
    //────────────────────────────────────────────────────────────────────────────────────────── 

    public static DataTable dtPhong_NgoaiTru_ByChuyenKhoa(string IdDichVu, string LoaiBN)
    {

        string sql = @"SELECT *,TenPhongFull=DBO.HS_TenPhong(ID)
                         FROM KB_PHONG
                        WHERE ID IN (
                        SELECT DISTINCT
	                        ID=(SELECT TOP 1 ID FROM KB_PHONG WHERE TENPHONG=A.TENPHONG )
                         FROM KB_PHONG A
                        )
                         AND status=1
                         and DichVuKCB=" + IdDichVu
                         + @"and isnull(isphongnoitru,0)=0
                       ORDER BY ISNULL(SOTT,0),ISNULL(MASO,'') ,TENPHONG ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;


    }
    //──────────────────────────────────────────────────────────────────────────────────────────   
    public static DataTable dtPhong_NgoaiTru_ByKhoa(string IdKhoa)
    {

        string sql = @"SELECT *,TenPhongFull=DBO.HS_TenPhong(ID)
                             FROM KB_PHONG A1
                             LEFT JOIN BANGGIADICHVU B1 ON A1.DICHVUKCB=B1.IDBANGGIADICHVU
                            WHERE ID IN (
                            SELECT DISTINCT 
	                            ID=(SELECT TOP 1 ID FROM KB_PHONG WHERE TENPHONG=A.TENPHONG ) 
                             FROM KB_PHONG A
                              
                            )  
                             --AND status=1
                             and isnull(isphongnoitru,0)=0
                             AND B1.IDPHONGKHAMBENH=" + IdKhoa + @" 
                             ORDER BY ISNULL(SOTT,0),ISNULL(MASO,'') ,TENPHONG ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;


    }
    //──────────────────────────────────────────────────────────────────────────────────────────  

    public static DataTable dtPhong_ByKhoa(string IdKhoa)
    {
        string sql = @"SELECT *,TenPhongFull=DBO.HS_TenPhong(ID)
	                     FROM KB_PHONG A1
	                    LEFT JOIN BANGGIADICHVU B1 ON A1.DICHVUKCB=B1.IDBANGGIADICHVU
	                    WHERE ID IN (
		                    SELECT DISTINCT
		                    ID=(SELECT TOP 1 ID FROM KB_PHONG WHERE TENPHONG=A.TENPHONG )
		                    FROM KB_PHONG A
	                    )
	                    AND status=1
	                    AND B1.IDPHONGKHAMBENH=" + IdKhoa
                     + @"  ORDER BY ISNULL(SOTT,0),ISNULL(MASO,'') ,TENPHONG ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;


    }
    //──────────────────────────────────────────────────────────────────────────────────────────  

    public static DataTable dtPhong_ByChuyenKhoa(string IdDichVu, string LoaiBN)
    {

        string sql = @"SELECT *,TenPhongFull=DBO.HS_TenPhong(ID)
                         FROM KB_PHONG
                        WHERE ID IN (
                        SELECT DISTINCT
	                        ID=(SELECT TOP 1 ID FROM KB_PHONG WHERE TENPHONG=A.TENPHONG )
                         FROM KB_PHONG A
                        )
                         AND status=1
                         and DichVuKCB=" + IdDichVu
                        + " ORDER BY ISNULL(SOTT,0),ISNULL(MASO,'') ,TENPHONG ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;


    }
    //──────────────────────────────────────────────────────────────────────────────────────────   

    public static bool IsCheck(string value)
    {
        if (value == null || value == "") return false;
        if (value == "0" || value.ToLower() == "false" || value.ToLower() == "n") return false;
        return true;
    }
    //──────────────────────────────────────────────────────────────────────────────────────────   
    public static bool IsCheck(object value)
    {
        if (value == null || value.ToString() == "") return false;
        return IsCheck(value.ToString());
    }
    //──────────────────────────────────────────────────────────────────────────────────────────   
    public static string NewMaBenhNhan(string NgayTiepNhan)
    {
        NgayTiepNhan += " 23:59:59";
        string sqlSelect = "SELECT COUNT(*) FROM BENHNHAN WHERE year(ngaytiepnhan)=year('" + NgayTiepNhan + "') and month(ngaytiepnhan)=month('" + NgayTiepNhan + "') and day(ngaytiepnhan)=day('" + NgayTiepNhan + "')";
        DataTable dtCountBN = DataAcess.Connect.GetTable(sqlSelect);
        if (dtCountBN == null || dtCountBN.Rows.Count == 0) return "";
        int nCount = int.Parse(dtCountBN.Rows[0][0].ToString());
        nCount++;
        DateTime dNgay = DateTime.Parse(NgayTiepNhan);
        string s = "";
        // nvk create MaBenhNhan (cho phép xóa BN trong ngày vẫn đúng mã)
        #region nvk create MaBenhNhan
        for (int k = 0; k < 2; k++)
        {
            s = "BN-" + dNgay.ToString("ddMMyyyy") + "-" + nCount.ToString();
            string sql_nvkChekMa = "select * from benhnhan where mabenhnhan='" + s + "'";
            DataTable dtBN_nvk = DataAcess.Connect.GetTable(sql_nvkChekMa);
            if (dtBN_nvk != null && dtBN_nvk.Rows.Count > 0)
            {
                k--; nCount++;
            }
            else
                break;
        }
        #endregion
        return s;
    }
    //──────────────────────────────────────────────────────────────────────────────────────────   
    public static bool HavePermision1(System.Web.UI.Page P, string PermName)
    {
        return true;
    }
    #region nvk Thông tin giường bệnh
    public static string nvk_ThongTinTienGiuong(string IdCTDKK, string idkhoa)
    {
        string html = @"";
        // table Tiền giường
        #region tableTiền giường
        #region Danh sách giuong da nằm KHÔNG DÙNG
        //        string sqlChiTietGiuong = @"select * from (
        //select *,sogio=convert(float,DATEDIFF(hh,tungay,denngay))
        //                ,thanhtien=round(convert(float,DATEDIFF(hh,tungay,denngay))*giagiuong/24,2) from 
        //                (
        //                select nt.idnoitru,giuong=g.giuongcode+' - '+isnull(p.tenphong,''),nt.Giagiuong,tungay=nt.ngayvaovien
        //                ,denngay=isnull((select top 1 ngayvaovien from benhnhannoitru where idchitietdangkykham=nt.idchitietdangkykham and ngayvaovien>nt.ngayvaovien order by ngayvaovien),getdate())
        //                ,tenkhoa=k.tenphongkhambenh
        //                 from benhnhannoitru nt left join kb_phong p on p.id=idphongnoitru
        //                left join kb_giuong g on g.giuongid=idgiuong left join phongkhambenh k on k.idphongkhambenh=nt.idkhoanoitru
        //                where nt.idchitietdangkykham=" + IdCTDKK + @" 
        //                ) as abc --order by tungay
        //
        //union all
        //select *,sogio=convert(float,DATEDIFF(hh,tungay,denngay))
        //                ,thanhtien=round(convert(float,DATEDIFF(hh,tungay,denngay))*thanhtien/24,2) from 
        //                (
        //                select idnoitru=nt.idgiuong,giuong=g.giuongcode+' - '+p.tenphong,nt.thanhtien,tungay=nt.ngayxetgiuong
        //                ,denngay=isnull((select top 1 ngayvaovien from benhnhannoitru where idchitietdangkykham=nt.idchitietdangkykham and ngayvaovien>nt.ngayxetgiuong order by idnoitru),getdate())
        //                ,tenkhoa=N'Cấp cứu'
        //                 from kb_giuongphieuthanhtoan nt
        //left join kb_giuong g on nt.idgiuongxet=g.giuongid
        // left join kb_phong p on p.id=g.idphong
        //
        //                where nt.idchitietdangkykham=" + IdCTDKK + @" 
        // ) as abc
        //) as cba order by tungay
        //";
        #endregion
        string sqlChiTiet = @"select distinct *,ngay1=convert(varchar(10),ngay,103)+' '+convert(varchar(5),ngay,108)
,DenNgay1=convert(varchar(10),denngay,103)+' '+convert(varchar(5),denngay,108) from [dbo].[NVK_TableKetQuaGiuong](" + IdCTDKK + ") order by ngay";
        DataTable dt = DataAcess.Connect.GetTable(sqlChiTiet);
        #endregion
        // tableChuyeGiuong
        #region tableChuyeGiuong
        string sqlTBchuyenG = @"
select * from (
select idnoitru,idphongkhambenh,tenphongkhambenh,NgayVaoGiuong=convert(varchar(10),nt.ngayvaovien,103)+' '+convert(varchar(5),nt.ngayvaovien,108),ngayvaovien
	,nt.IdPhongNoiTru,tenphong,nt.IdGiuong,GiuongCode,nt.GiaGiuong,isGiuongCapCuu=0
from benhnhannoitru nt left join phongkhambenh k on k.idphongkhambenh= nt.IdKhoaNoiTru
	left join kb_phong p on p.id=nt.IdPhongNoiTru
	left join kb_giuong g on g.GiuongId=nt.IdGiuong
where idchitietdangkykham =" + IdCTDKK + @" --and isnull(nt.idphongnoitru,0)<>0
 and isnull(nt.idgiuong,0)<>0
)as abc order by ngayvaovien 
        ";
        DataTable tbChuyenGiuong = DataAcess.Connect.GetTable(sqlTBchuyenG);
        #endregion
        if (dt != null)
        {
            //DataTable dtGiuong = DataAcess.Connect.GetTable(sqlChiTietGiuong);
            //if (dtGiuong != null)
            //{
            //}
            #region Load danh sách ngày nhiều giường
            string ListGiuongHtml = "";
            string sqlNgayG = @"select distinct convert(varchar(10),ngay,103) as ngay1,ngay from
                            (
                            select  ngay  from NVK_ListNgayTinhGiuong(" + IdCTDKK + @") 
                            ) as abc where isnull((select count(*) from dbo.NVK_ListGiuongBN_Ngay(" + IdCTDKK + @",ngay)),0)>1 order by ngay asc";
            DataTable dtNgayG = DataAcess.Connect.GetTable(sqlNgayG);
            if (dtNgayG.Rows.Count > 0)
            {
                for (int i = 0; i < dtNgayG.Rows.Count; i++)
                {
                    ListGiuongHtml += @"<input type='button' id='ngay_" + (i + 1) + "' style='width:100px' runat='server' onclick='Ngay_click(this)' value='" + dtNgayG.Rows[i]["ngay1"].ToString() + @"' style='background-color:Blue ! important' />";
                }
            }
            html = @"<div id='divCenter' style='text-align:center'>";
            html += tableChuyenGiuong(tbChuyenGiuong, idkhoa, IdCTDKK);
            html += "</div>";
            html += @"
                <div id='divNgayNhieuGiuong' style='text-align:center'>";
            html += ListGiuongHtml;
            html += @"</div>
                <div id='divCenter1' style='text-align:center'>
                <div id='divChiTietGiuongNgay' style='display:none;top:20%;bottom:50%;left:35%;width:30%;background-color:white;z-index:1001;padding:5px 5px 5px 5px;border:10px solid black;text-align:center'></div>
                </div>
                <div id='tableAjax_EditTienGiuong' style='text-align:center'>";
            #endregion
            html += tabletienGiuong(dt);
            html += "</div>";
            if (dt != null && dt.Rows.Count > 0)
            {
                html += @"<div id='divCenter2' style='text-align:center'>
<input type='button' id='CapNhatGiuong' style='width:130px' onclick='luuNoiDungGiuong();' value='Lưu bảng giường' />
                </div>";
            }
        }
        else
        {
        }
        return html;
    }
    public static string tableChuyenGiuong(DataTable table, string idkhoa, string idChiTietDKK)
    {
        string html = "";
        html += "<table class='jtable' id=\"TableChuyenGiuong\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th>Sửa giường</th>";
        html += "<th>Chuyển giường</th>";
        html += "<th>Ngày vào nằm</th>";
        html += "<th>Khoa</th>";
        html += "<th>Phòng</th>";
        html += "<th>Giường</th>";
        html += "<th>Đơn giá</th>";
        html += "</tr>";
        DataView dvTempt = new DataView(table.Copy());
        dvTempt.RowFilter = "idphongkhambenh <>" + idkhoa + "";
        DataTable dtKhacKhoa = dvTempt.ToTable();
        int stt = 0;
        if (dtKhacKhoa.Rows.Count > 0)
        {
            for (int i = 0; i < dtKhacKhoa.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (stt + i + 1) + "</td>";
                html += "<td ></td>";
                html += "<td ></td>";
                html += "<td>" + dtKhacKhoa.Rows[i]["NgayVaoGiuong"] + "</td>";
                html += "<td>" + dtKhacKhoa.Rows[i]["tenphongkhambenh"] + "</td>";
                html += "<td>" + dtKhacKhoa.Rows[i]["tenphong"] + "</td>";
                html += "<td>" + dtKhacKhoa.Rows[i]["GiuongCode"] + "</td>";
                html += "<td>" + StaticData.FormatNumberOption(dtKhacKhoa.Rows[i]["GiaGiuong"], ",", ".", false) + "</td>";
                html += "</tr>";
                stt++;
            }
        }
        dvTempt.RowFilter = "idphongkhambenh =" + idkhoa + "";
        DataTable dtKhoa = dvTempt.ToTable();
        if (dtKhoa.Rows.Count > 0)
        {
            for (int i = 0; i < dtKhoa.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (stt + i + 1) + "</td>";
                html += "<td ><a onclick='SuaGiuong(this," + idkhoa + "," + dtKhoa.Rows[i]["idnoitru"] + "," + idChiTietDKK + ")'>Sửa</a></td>";
                html += "<td >";
                if (i == dtKhoa.Rows.Count - 1)
                    html += "<a id='linkThemGiuong' onclick='ThemGiuong(this," + idChiTietDKK + "," + idkhoa + ")'>Giường mới</a>";
                html += "</td>";
                html += "<td>" + dtKhoa.Rows[i]["NgayVaoGiuong"] + "</td>";
                html += "<td>" + dtKhoa.Rows[i]["tenphongkhambenh"] + "</td>";
                html += "<td>" + dtKhoa.Rows[i]["tenphong"] + "</td>";
                html += "<td>" + dtKhoa.Rows[i]["GiuongCode"] + "</td>";
                html += "<td>" + StaticData.FormatNumberOption(dtKhoa.Rows[i]["GiaGiuong"], ",", ".", false) + "</td>";
                html += "</tr>";
                stt++;
            }
        }
        #region Trường hợp bệnh nhân chưa có giường
        if (dtKhoa.Rows.Count == 0)
        {
            html += "<tr>";
            html += "<td>1</td>";
            html += "<td ></td>";
            html += "<td ><a onclick='ThemGiuong(this," + idChiTietDKK + "," + idkhoa + ")'>Giường mới</a></td>";
            html += "<td></td>";
            html += "<td></td>";
            html += "<td></td>";
            html += "<td></td>";
            html += "<td></td>";
            html += "</tr>";
        }
        #endregion
        html += "<tr><td colspan='8' id='tdPopupTG' align='center'>tdPopup Show</td></tr>";
        html += "</table>";
        return html;
    }
    public static string tabletienGiuong(DataTable dt)
    {
        string html = "";
        html += "<table class='jtable' id=\"gridTableGiuong\">";
        html += "<tr>";
        html += "<th>STT</th>";
        //html += "<th></th>";
        html += "<th>Khoa</th>";
        html += "<th>Từ ngày</th>";
        html += "<th>Đến ngày</th>";
        html += "<th>Giường</th>";
        html += "<th>Đơn giá/ngày</th>";
        html += "<th>Số ngày</th>";
        html += "<th>Thành tiền</th>";
        html += "</tr>";
        if (dt != null && dt.Rows.Count != 0)
        {
            double tongTienTable = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["tiengiuongnamnhieunhat"].ToString().Equals(""))
                    continue;
                html += "<tr>";
                html += "<td>" + (i + 1) + "</td>";
                //html += "<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input mkv='true' id='idkhoa' type='hidden' value='" + dt.Rows[i]["idkhoa"] + "' /><input mkv='true' id='mkv_idkhoa' type='text' style='width:80px' onfocusout='chuyenformout(this)' value='" + dt.Rows[i]["khoa"] + "' class='down_select'/></td>";
                html += "<td>" + dt.Rows[i]["Ngay1"] + "</td>";
                html += "<td>" + dt.Rows[i]["denngay1"] + "</td>";
                html += "<td><input mkv='true' id='idGiuong' type='hidden' value='" + dt.Rows[i]["idgiuong"] + "' /><input mkv='true' id='mkv_idGiuong' type='text' onfocus='chuyenphim(this);idGiuongsearch(this)' value='" + dt.Rows[i]["tengiuong"] + "' class='down_select'/></td>";

                html += "<td><input mkv='true' id='dongia' type='text' style='width:80px;text-align:right' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);thanhtienTableGiuong(this);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["tiengiuongnamnhieunhat"], ",", ".", false) + "' /></td>";
                html += "<td><input mkv='true' id='songay' type='text' style='width:50px;text-align:center' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);thanhtienTableGiuong(this);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["songay"], ",", ".", false) + "' /></td>";
                html += @"<td>
                    <input mkv='true' id='thanhtien' disabled='disabled' type='text' style='width:80px;text-align:right' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + StaticData.FormatNumberOption(dt.Rows[i]["thanhtien"], ",", ".", false) + @"' />
                    <input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[i]["idnoitrunamnhieunhat"] + @"'/>
                    <input mkv='true' id='idtien_" + (i + 3) + "' type='hidden' value='" + dt.Rows[i]["thanhtien"] + @"'/>
                    </td>";
                html += "</tr>";
                tongTienTable += StaticData.ParseFloat(dt.Rows[i]["thanhtien"]);
            }
            html += "<tr>";
            html += "<td colspan='8'>";
            html += @"<div style='text-align:right;width:95%'>
        Tổng tiền : <input type='text' style='text-align:right;color:Red' runat='server' id='txtTongtien' disabled='disabled' value='" + StaticData.FormatNumberOption(tongTienTable, ",", ".", false).ToString() + "'/>";
            html += "<td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        return html;
    }
    #endregion

    #region nvk xác định isNgoaiTru bệnh nhân điều trị ngoại trú
    public static string nvk_xacNhan_IsNgoaiTru(string idkhoa, string idchitietdangkykham, string isLuuCho, string isHauSanh)
    {
        string isNgoaiTru = "0";
        try
        {
            if (idkhoa.Equals(GetParameter("nvk_idkhoacapcuu")) || idkhoa.Equals(GetParameter("nvk_idphongtansoi")))
                isNgoaiTru = "1";

            if (isLuuCho != null && isLuuCho.Equals("1"))
            {
                isNgoaiTru = "1";
            }
            if (isHauSanh != null && isHauSanh.Equals("1"))
            {
                isNgoaiTru = "0";
            }
        }
        catch (Exception)
        {
        }
        return isNgoaiTru;
    }
    #endregion


    #region select_KhoDuyetYC
    public static string select_KhoDuyetYC()
    {
        DataTable dt_khoDuyet = DataAcess.Connect.GetTable("select * from khothuoc where nvk_loaikho =1");
        string select = "Kho duyệt YC: <select id='khoduyetyc' mkv='true' style='height:28px'>";
        for (int i = 0; i < dt_khoDuyet.Rows.Count; i++)
        {
            select += "<option value='" + dt_khoDuyet.Rows[i]["idkho"] + "'>" + dt_khoDuyet.Rows[i]["tenkho"] + "</option>";
        }
        select += "</select>";
        return select;
    }
    #endregion

    #region thông tin chẩn đoán đợt khám

    public static void nvk_setTongHopChanDoan_2511(string IdBenhNhanBHDongTien, ref string nvk_listMaIcd, ref string nvk_listMoTaIcd)
    {
        string nvk_sq = @"	SELECT distinct MOTACD_edit=isnull(a.MOTACD_edit,b.mota),b.maicd
	        FROM KHAMBENH a
		        inner JOIN CHANDOANICD b ON a.KETLUAN=b.IDICD
                inner JOIN DANGKYKHAM C ON A.IDDANGKYKHAM=C.IDDANGKYKHAM
	        WHERE a.ketluan>0 and C.IdBenhBHDongTien ='" + IdBenhNhanBHDongTien + @"'
        union
	        SELECT distinct MOTACD_edit=isnull(b.MOTACD_edit,c.mota),c.maicd
	        FROM KHAMBENH A
		        inner JOIN CHANDOANPHOIHOP B ON  a.IDKHAMBENH=B.IDKHAMBENH
		        inner JOIN CHANDOANICD C ON  c.IDICD=b.IDICD
                inner JOIN DANGKYKHAM D ON A.IDDANGKYKHAM=D.IDDANGKYKHAM
	        WHERE  D.IdBenhBHDongTien ='" + IdBenhNhanBHDongTien + @"'
        union 
	        select distinct nk.MoTaChanDoan_NK,cd.maicd
                from nvk_chandoannhapkhoa nk 
                inner join  benhnhannoitru nt on nt.idnoitru =nk.idnoitru
		        inner join chandoanicd cd on cd.idicd= nk.idicd
                inner JOIN CHITIETDANGKYKHAM CT ON nt.idchitietdangkykham=CT.idchitietdangkykham
                inner JOIN DANGKYKHAM DK ON CT.IDDANGKYKHAM=DK.IDDANGKYKHAM
	        where DK.IdBenhBHDongTien ='" + IdBenhNhanBHDongTien + @"'
        union 
	        select distinct ct.MoTaChanDoan_XK,cd.maicd 
            from nvk_chandoanxuatkhoa ct 
            inner join  benhnhanxuatkhoa xk on xk.idxuatkhoa =ct.idxuatkhoa
		        inner join chandoanicd cd on cd.idicd= ct.idicd
                inner JOIN CHITIETDANGKYKHAM CT ON XK.idchitietdangkykham=CT.idchitietdangkykham
                inner JOIN DANGKYKHAM DK ON CT.IDDANGKYKHAM=DK.IDDANGKYKHAM
	          where DK.IdBenhBHDongTien ='" + IdBenhNhanBHDongTien + @"'";

        DataTable dt_cd = DataAcess.Connect.GetTable(nvk_sq);
        if (dt_cd != null && dt_cd.Rows.Count > 0)
        {
            nvk_listMoTaIcd = "";
            nvk_listMaIcd = "";
            for (int i = 0; i < dt_cd.Rows.Count; i++)
            {
                nvk_listMaIcd += " " + dt_cd.Rows[i]["maicd"].ToString() + " -";
                nvk_listMoTaIcd += " " + dt_cd.Rows[i]["MOTACD_edit"].ToString() + " -";
            }
            nvk_listMaIcd = nvk_listMaIcd.TrimEnd('-');
            nvk_listMoTaIcd = nvk_listMoTaIcd.TrimEnd('-');
        }

    }
    public static void nvk_setTongHopChanDoan(string idctdkk, ref string nvk_listMaIcd, ref string nvk_listMoTaIcd)
    {
        string nvk_sq = @"	SELECT distinct MOTACD_edit=isnull(a.MOTACD_edit,b.mota),b.maicd
	FROM KHAMBENH a
		left JOIN CHANDOANICD b ON a.KETLUAN=b.IDICD
	WHERE a.ketluan>0 and a.idchitietdangkykham ='" + idctdkk + @"'
union
	SELECT distinct MOTACD_edit=isnull(b.MOTACD_edit,c.mota),c.maicd
	FROM KHAMBENH A
		inner JOIN CHANDOANPHOIHOP B ON  a.IDKHAMBENH=B.IDKHAMBENH
		LEFT JOIN CHANDOANICD C ON  c.IDICD=b.IDICD
	WHERE  a.idchitietdangkykham ='" + idctdkk + @"'
union 
	select distinct nk.MoTaChanDoan_NK,cd.maicd from nvk_chandoannhapkhoa nk inner join  benhnhannoitru nt on nt.idnoitru =nk.idnoitru
		left join chandoanicd cd on cd.idicd= nk.idicd
	where nt.idchitietdangkykham ='" + idctdkk + @"'
union 
	select distinct ct.MoTaChanDoan_XK,cd.maicd from nvk_chandoanxuatkhoa ct inner join  benhnhanxuatkhoa xk on xk.idxuatkhoa =ct.idxuatkhoa
		left join chandoanicd cd on cd.idicd= ct.idicd
	where  xk.idchitietdangkykham ='" + idctdkk + @"'";
        DataTable dt_cd = DataAcess.Connect.GetTable(nvk_sq);
        if (dt_cd != null && dt_cd.Rows.Count > 0)
        {
            nvk_listMoTaIcd = "";
            nvk_listMaIcd = "";
            for (int i = 0; i < dt_cd.Rows.Count; i++)
            {
                nvk_listMaIcd += " " + dt_cd.Rows[i]["maicd"].ToString() + " -";
                nvk_listMoTaIcd += " " + dt_cd.Rows[i]["MOTACD_edit"].ToString() + " -";
            }
            nvk_listMaIcd = nvk_listMaIcd.TrimEnd('-');
            nvk_listMoTaIcd = nvk_listMoTaIcd.TrimEnd('-');
        }
    }
    #endregion
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
            string s = GetParameter("BieuMauPhieuXuat");
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
    public static string NVK_NewMaPhieu_TheoNgay(string NgayYeuCau, string prefix, string TableName, string ColumnNgay)
    {
        NgayYeuCau += " 23:59:59";
        string sqlSelect = "select count(*) from " + TableName + " where year(" + ColumnNgay + ")= year('" + NgayYeuCau + "') and month(" + ColumnNgay + ")= month('" + NgayYeuCau + "') and day(" + ColumnNgay + ")=day('" + NgayYeuCau + "')  and maphieunhap like N'" + prefix + "%'";
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
            if (t >= 1 && t <= 10)
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
            if (t > 10 && t <= 100)
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
            if (t > 100 && t <= 1000)
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
            if (t > 1000 && t <= 5000)
            {
                if (t == 2000) rs += "MM";
                if (t == 3000) rs += "MMM";
                if (t == 4000) rs += "MMMM";
            }

        } while (k > 0);
        return rs;
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
    public static void getthuoc(System.Web.UI.Page Page)
    {
        getthuoc(Page, false);
    }
    public static void getthuoc_thanhly(System.Web.UI.Page Page, bool isNhapKho)
    {

        string idKho = (Page.Request.QueryString["idkho"] != null ? Page.Request.QueryString["idkho"].ToString() : StaticData.GetParaValueDB("KhoNhapMuaID"));
        if (idKho == "") return;
        string sqlClause = "";
        if (Page.Request.QueryString["q"] != null)
        {
            sqlClause += " and A.tenthuoc like N'" + Page.Request.QueryString["q"] + "%'";
        }
        string NgayCT = "GETDATE()";
        if (Page.Request.QueryString["NgayCT"] != null && Page.Request.QueryString["NgayCT"] != "")
        {
            NgayCT = Page.Request.QueryString["NgayCT"].ToString();
            NgayCT = StaticData.CheckDate(NgayCT);
            NgayCT = "'" + NgayCT + " " + "23:59:59" + "'";
        }

        string loaithuoc = Page.Request.QueryString["loaithuoc"];
        if (loaithuoc == null || loaithuoc == "")
            loaithuoc = Page.Request["LoaiThuocID"];
        if (loaithuoc != null && loaithuoc != "")
        {
            string LoaiThuocID = loaithuoc;
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
        string idkho2 = Page.Request.QueryString["idkho2"];
        if (idkho2 == StaticData.KhoThuocBHYT)
        {
            sqlClause += " AND A.sudungchobh=1";
        }
        string strTenSoTon = "SLTON";
        string sqlThuoc = @" SELECT TOP 20 a.idthuoc
                                    ,a.tenthuoc
                                    ,a.sttindm05
                                    ,a.iddvt
                                    ,tendvt=b.tendvt
                                    ,a.congthuc
                                    ,a.TTHoatChat
                                    ,SLDVTChuan
                                    ,SLQuyDoi
                                    ,a.dvtchuan
                                    ,tendvtchuan=c.tendvt
                                    ,SLTON=DBO.Thuoc_TonKho_new_1910(a.IDTHUOC,GETDATE(),51)
                             from  thuoc A
                                    LEFT JOIN THUOC_DONVITINH B ON A.dvtchuan=b.ID
                                    LEFT JOIN THUOC_DONVITINH c ON A.IDDVT=c.ID
                                    where IsThuocBV=1  "
                                         + sqlClause
                                   + @" ORDER BY TENTHUOC,TTHOATCHAT,CONGTHUC ";
        string html = "";
        DataTable table = DataAcess.Connect.GetTable(sqlThuoc);
        table.DefaultView.RowFilter = "SLTON >0";
        table = table.DefaultView.ToTable();
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow h = table.Rows[i];
                html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}", "<div>"
                      + "<div style=\"width:5%;height:30px;float:left\" >" + (i + 1) + "</div>"
                     + "<div style=\"width:35%;height:30px;float:left\" >" + h["tenthuoc"] + "</div>"
                     + "<div style=\"width:15%;height:30px;float:left;text-align:center;\" >" + h["TTHoatChat"] + "</div>"
                     + "<div style=\"width:20%;height:30px;float:left\" >" + h["congthuc"] + "</div>"
                     + "<div style=\"width:7%;height:30px;float:left;text-align:center;\" >" + h["tendvt"] + "</div>"
                     + "<div style=\"width:8%;height:30px;float:left;text-align:center;\" >" + string.Format("{0:0.##}", h["SLTON"]) + "</div>"
                     + "</div>", h["idthuoc"], h["congthuc"], h["iddvt"], h["tenthuoc"], h["sttindm05"], string.Format("{0:0.##}", h[strTenSoTon]), h["tendvt"], h["SLQuyDoi"], h["dvtchuan"], h["tendvtchuan"], Environment.NewLine);

            }
        }
        Page.Response.Clear();
        Page.Response.Write(html);
    }
    public static void getthuoc(System.Web.UI.Page Page, bool IsNhapKho)
    {
        string idkhoNhapMua = StaticData.GetParaValueDB("KhoNhapMuaID");
        string idKho = (Page.Request.QueryString["idkho"] != null ? Page.Request.QueryString["idkho"].ToString() : idkhoNhapMua);
        if (idKho == "") return;
        string sqlClause = "";
        if (Page.Request.QueryString["q"] != null)
        {
            sqlClause += " and B.tenthuoc like N'" + Page.Request.QueryString["q"] + "%'";
        }
        string NgayCT = "GETDATE()";
        if (Page.Request.QueryString["NgayCT"] != null && Page.Request.QueryString["NgayCT"] != "")
        {
            NgayCT = Page.Request.QueryString["NgayCT"].ToString();
            NgayCT = StaticData.CheckDate(NgayCT);
            NgayCT = "'" + NgayCT + " " + "23:59:59" + "'";
        }

        string loaithuoc = Page.Request.QueryString["loaithuoc"];
        if (loaithuoc == null || loaithuoc == "")
            loaithuoc = Page.Request["LoaiThuocID"];
        if (loaithuoc != null && loaithuoc != "")
        {
            string LoaiThuocID = loaithuoc;
            if (LoaiThuocID != "5" && LoaiThuocID != "6")
                sqlClause += " and B.loaithuocid='" + LoaiThuocID + "'";
            else
            {
                if (IsHaveThuocGN_TT)
                {
                    if (LoaiThuocID == "5")
                    {
                        sqlClause += " and B.IsTGN=1 and B.LoaithuocID=1";
                    }
                    if (LoaiThuocID == "6")
                    {
                        sqlClause += " and B.IsTHTT=1 and B.LoaithuocID=1";
                    }
                }
                else
                    sqlClause += " and B.loaithuocid='" + LoaiThuocID + "'";
            }

        }
        string idkho2 = Page.Request.QueryString["idkho2"];
        if (idkho2 == StaticData.KhoThuocBHYT)
        {
            sqlClause += " AND B.sudungchobh=1";
        }
        string Para_idDuoc = idkhoNhapMua;
        bool ChoPhepTheHien = (StaticData.GetParaValueDB("ChoPhepTheHienThuocKhongCoSLTon") == "1" ? true : false);


        string strTenSoTon = "SLTON";
        if (Para_idDuoc.Equals(idKho))
            strTenSoTon = "tonSauDuTru";
        string sqlThuoc = @"
                            select  tonSauDuTru=0
                             	    ,B.idthuoc
                                    ,B.tenthuoc
                                    ,B.sttindm05
                                    ,B.iddvt
                                    ,tendvt=d.tendvt
                                    ,B.congthuc
                                    ,B.TTHoatChat
                                    ,SLDVTChuan
                                    ,SLQuyDoi
                                    ,b.dvtchuan
                                    ,tendvtchuan=c.tendvt
                                    ,SLTON=DBO.Thuoc_TonKho_new_1910(B.IDTHUOC," + NgayCT + "," + idKho + @") 
									,tonao=  DBO.HS_SLYEUCAUCHUADUYET(B.IDTHUOC," + idKho + @",NULL)
                                    ,BHYT= isnull((select top 1 convert(int,ISBHYT) from chitietphieunhapkho where IDLOAINHAP_NHAP=1 and idthuoc= B.idthuoc order by NGAYTHANG_NHAP desc ),0)
                            FROM 
                              THUOC B  
                                    LEFT JOIN THUOC_DONVITINH C ON B.dvtchuan=C.ID
                                    LEFT JOIN THUOC_DONVITINH D ON B.IDDVT=D.ID
                             WHERE B.ISTHUOCBV=1 " + sqlClause +@"
                                     ORDER BY TENTHUOC,TTHOATCHAT,CONGTHUC";

        string html = "";
        DataTable table = DataAcess.Connect.GetTable(sqlThuoc);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            string iSLTon = table.Rows[i]["SLTON"].ToString();
            if(iSLTon=="")iSLTon="0";
            double dSLTON = double.Parse(iSLTon);
            if (ChoPhepTheHien || dSLTON > 0)
            {
                string tonao = table.Rows[i]["tonao"].ToString();
                if (tonao == "") tonao = "0";
                double dtonao = double.Parse(tonao);
                double dtonSauDuTru = dSLTON - dtonao;
                table.Rows[i]["tonSauDuTru"] = dtonSauDuTru;
                DataRow h = table.Rows[i];
                html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}", "<div>"
                      + "<div style=\"width:5%;height:30px;float:left\" >" + (i + 1) + "</div>"
                     + "<div style=\"width:35%;height:30px;float:left\" >" + h["tenthuoc"] + "</div>"
                     + "<div style=\"width:15%;height:30px;float:left;text-align:center;\" >" + h["TTHoatChat"] + "</div>"
                     + "<div style=\"width:20%;height:30px;float:left\" >" + h["congthuc"] + "</div>"
                     + "<div style=\"width:7%;height:30px;float:left;text-align:center;\" >" + h["tendvt"] + "</div>"
                     + "<div style=\"width:8%;height:30px;float:left;text-align:center;\" >" + string.Format("{0:0.##}", h["SLTON"]) + "</div>"
                     + (idKho.Equals(Para_idDuoc) ? "<div style=\"width:7%;height:30px;float:left;text-align:center;\" >" + string.Format("{0:0.##}", h["tonao"]) + "</div>" : "")
                     + "</div>", h["idthuoc"], h["congthuc"], h["iddvt"], h["tenthuoc"], h["sttindm05"], string.Format("{0:0.##}", h[strTenSoTon]), h["tendvt"], h["SLQuyDoi"], h["dvtchuan"], h["tendvtchuan"], h["BHYT"], Environment.NewLine);
            }

        }
        Page.Response.Clear();
        Page.Response.Write(html);
        Page.Response.End();
    }
    public static void GetKho(Page P, bool IsKhoaDuoc)
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
        P.Response.Clear(); P.Response.Write(html);

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
    //───────────────────────────────────────────────────────────────────────────────────────
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
    //───────────────────────────────────────────────────────────────────────────────────────
    #region ham dung cho ke toan

    #region T?o mã s? t? d?ng-k? toán
    public static string TaoSoThuTu(int so_thu_tu)
    {
        so_thu_tu++;
        string stt = "";
        if (so_thu_tu > 0 && so_thu_tu < 10)
        {
            stt = "00" + so_thu_tu.ToString();
        }
        else
            if (so_thu_tu >= 10 && so_thu_tu <= 99)
            {
                stt = "0" + so_thu_tu.ToString();
            }
            else
                if (so_thu_tu >= 100 && so_thu_tu <= 999)
                {
                    stt = so_thu_tu.ToString();
                }
                else
                {
                    stt = so_thu_tu.ToString();
                }
        return stt;
    }

    public static string TaoMaSoTuDongKT_theongayhethong(string TenTable, string FielMa, string manghiepvu, string loaiphieu, string idloaict)
    {
        //tao ma so theo dang: PC1201.001
        //PC:tiep dau ngu;12:nam;01:thang;001:so thu tu trong thang
        //tao so phieu nhap/xuat tang tu dong theo tiep dau ngu trong table: dmnghiepvu
        //loaiphieu: phieunhap hay phieuxuat
        //idloaict: cac loai nhap/xuat
        int thang;
        int nam;
        string MaTuDong = "";
        //lay tiep dau ngu
        string tiepdaungu = "";
        string sqldau = "select manghiepvu,tiepdaungu from dmnghiepvu where manghiepvu='" + manghiepvu + "'";
        DataTable dttdn = new DataTable();
        dttdn = DataAcess.Connect.GetTable(sqldau);
        if (dttdn != null && dttdn.Rows.Count > 0)
            tiepdaungu = dttdn.Rows[0]["tiepdaungu"].ToString().Trim();
        //
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where " + FielMa + " like '" + tiepdaungu + "%' ";
        if (loaiphieu.Equals("phieunhap"))
            sql += " and idloainhap='" + idloaict.Trim() + "'";
        if (loaiphieu.Equals("phieuxuat"))
            sql += " and loaixuat='" + idloaict.Trim() + "'";
        sql += "order by " + FielMa + " desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string Ma = table.Rows[0][0].ToString();
                string[] buffer = Ma.Split('.');
                string ky_tu_dau = buffer[0];

                //Tao day so;               
                string day_so = buffer[1];
                int so_thu_tu = Int32.Parse(day_so);
                string stt = TaoSoThuTu(so_thu_tu);

                //Tao thang nam
                string namthang = ky_tu_dau.Substring(tiepdaungu.Length);
                nam = int.Parse(namthang.Substring(0, 2).ToString());
                thang = int.Parse(namthang.Substring(3).ToString());
                if (nam >= int.Parse(DateTime.Now.Year.ToString().Substring(2, 2)))
                {
                    if (thang >= DateTime.Now.Month)
                    {
                        MaTuDong = tiepdaungu + nam.ToString() + thang.ToString("00") + "." + stt;
                    }
                    else
                    {
                        thang = DateTime.Now.Month;
                        MaTuDong = tiepdaungu + nam.ToString() + thang.ToString("00") + "." + TaoSoThuTu(0);
                    }
                }
                else
                {
                    nam++;
                    thang = DateTime.Now.Month;
                    MaTuDong = tiepdaungu + nam.ToString() + thang.ToString("00") + "." + TaoSoThuTu(0);
                }
            }
            else //Mã s? d?u tiên
            {
                thang = DateTime.Now.Month;
                string nam1 = DateTime.Now.Year.ToString();
                nam = int.Parse(nam1.Substring(2, 2));
                MaTuDong = tiepdaungu + nam.ToString() + thang.ToString("00") + "." + "001";
            }
        }
        return MaTuDong;
    }
    public static string TaoMaSoTuDongKT(string TenTable, string FielMa, string manghiepvu, string ngaylap, string loaiphieu, string idloaict)
    {
        //tao ma so theo dang: PC1201.001
        //PC:tiep dau ngu;12:nam;01:thang;001:so thu tu trong thang
        //tao so phieu nhap/xuat tang tu dong theo tiep dau ngu trong table: dmnghiepvu
        //loaiphieu: phieunhap hay phieuxuat
        //idloaict: cac loai nhap/xuat
        int thang;
        int nam;
        string MaTuDong = "";
        //lay tiep dau ngu
        string tiepdaungu = "";
        string sqldau = "select manghiepvu,tiepdaungu from dmnghiepvu where manghiepvu='" + manghiepvu + "'";
        DataTable dttdn = new DataTable();
        dttdn = DataAcess.Connect.GetTable(sqldau);
        if (dttdn != null && dttdn.Rows.Count > 0)
            tiepdaungu = dttdn.Rows[0]["tiepdaungu"].ToString().Trim();
        //
        //lay thang va nam cua ngay lap de so sach voi thang va nam trong so phieu
        string strthang = ngaylap.Substring(3, 2);
        string strnam = ngaylap.Substring(ngaylap.Length - 2);
        string strssthangnam = strnam + strthang;
        //
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where " + FielMa + " like '" + tiepdaungu + strssthangnam + "%' ";
        if (loaiphieu.Equals("phieunhap"))
            sql += " and idloainhap='" + idloaict.Trim() + "'";
        if (loaiphieu.Equals("phieuxuat"))
            sql += " and loaixuat='" + idloaict.Trim() + "'";
        sql += "order by " + FielMa + " desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string Ma = table.Rows[0][0].ToString();
                string[] buffer = Ma.Split('.');
                string ky_tu_dau = buffer[0];

                //Tao day so;               
                string day_so = buffer[1];
                int so_thu_tu = Int32.Parse(day_so);
                string stt = TaoSoThuTu(so_thu_tu);

                //Tao thang nam
                string namthang = ky_tu_dau.Substring(tiepdaungu.Length);
                nam = int.Parse(namthang.Substring(0, 2).ToString());
                thang = int.Parse(namthang.Substring(2, 2).ToString());
                MaTuDong = tiepdaungu + nam.ToString("00") + thang.ToString("00") + "." + stt;
            }
            else //Mã s? d?u tiên
            {
                MaTuDong = tiepdaungu + strnam + strthang + "." + "001";
            }
        }
        return MaTuDong;
    }
    public static string TaoMaSoTuDongKT_TSCC(string TenTable, string FielMa, string manghiepvu, string ngaylap)
    {
        //tao ma so theo dang: PC1201.001
        //PC:tiep dau ngu;12:nam;01:thang;001:so thu tu trong thang
        //tao so phieu nhap/xuat tang tu dong theo tiep dau ngu trong table: dmnghiepvu
        //loaiphieu: phieunhap hay phieuxuat
        //idloaict: cac loai nhap/xuat
        int thang;
        int nam;
        string MaTuDong = "";
        //lay tiep dau ngu
        string tiepdaungu = "";
        string sqldau = "select manghiepvu,tiepdaungu from dmnghiepvu where manghiepvu='" + manghiepvu + "'";
        DataTable dttdn = new DataTable();
        dttdn = DataAcess.Connect.GetTable(sqldau);
        if (dttdn != null && dttdn.Rows.Count > 0)
            tiepdaungu = dttdn.Rows[0]["tiepdaungu"].ToString().Trim();
        //
        //lay thang va nam cua ngay lap de so sach voi thang va nam trong so phieu
        string strthang = ngaylap.Substring(3, 2);
        string strnam = ngaylap.Substring(ngaylap.Length - 2);
        string strssthangnam = strnam + strthang;
        //
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where " + FielMa + " like '" + tiepdaungu + strssthangnam + "%' ";
        sql += "order by " + FielMa + " desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string Ma = table.Rows[0][0].ToString();
                string[] buffer = Ma.Split('.');
                string ky_tu_dau = buffer[0];

                //Tao day so;               
                string day_so = buffer[1];
                int so_thu_tu = Int32.Parse(day_so);
                string stt = TaoSoThuTu(so_thu_tu);

                //Tao thang nam
                string namthang = ky_tu_dau.Substring(tiepdaungu.Length);
                nam = int.Parse(namthang.Substring(0, 2).ToString());
                thang = int.Parse(namthang.Substring(2, 2).ToString());
                MaTuDong = tiepdaungu + nam.ToString("00") + thang.ToString("00") + "." + stt;
            }
            else //Mã s? d?u tiên
            {
                MaTuDong = tiepdaungu + strnam + strthang + "." + "001";
            }
        }
        return MaTuDong;
    }
    public static string ConvertDDMMtoMMDD(string ngay)
    {
        if (ngay.Equals(""))
        {
            return "";
        }
        else
        {
            string ngayC = ngay.Substring(0, 2);
            string thangC = ngay.Substring(3, 2);
            string namC = ngay.Substring(6, 4);
            return thangC + "/" + ngayC + "/" + namC;
        }
    }
    #endregion


    #endregion
    //───────────────────────────────────────────────────────────────────────────────────────
    #region  Get List Kho
    public static void IdKhoSearch(Page P)
    {
        string IdKhoClause = "";
        string idkhoa = P.Request.QueryString["idkhoa"];
        string IdKho = P.Request.QueryString["IdKho"];
        if (IdKho != null && IdKho != "")
            IdKhoClause = " AND IDKHO=" + IdKho;
        else
        {
            if (idkhoa == null || idkhoa == "" || idkhoa == "0")
            {

                //  string idkho1 = StaticData.MacDinhKhoNhapMuaID; ;
                string idkho1 = "";
                string groupID = SysParameter.UserLogin.GroupID(P);
                if (groupID == "8")
                    idkho1 = StaticData.KhoThuocBHYT;
                if (groupID == "9")
                    idkho1 = StaticData.KhoThuocDV;
                if (groupID != "7" && !idkho1.Equals("") && !idkho1.Equals("0"))
                    IdKhoClause += " and idkho='" + idkho1 + "'";

            }
            else
                IdKhoClause += " and idkhoa='" + idkhoa + "'";

        }
        string tenkho = P.Request.QueryString["q"];
        if (tenkho != null && tenkho != "")
            IdKhoClause += " AND TENKHO LIKE N'" + tenkho + "%'";
        string sqlSelect = "SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 " + IdKhoClause + " ORDER BY TENKHO";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TENKHO"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        P.Response.Clear(); P.Response.Write(html);
    }
    public static void SetDefaultIdKho(Page P, string Idkho_Control_Name, string TenKho_Control_Name, string LoaiThuocID_ControlName, string LoaiThuocName_ControlName)
    {
        SetDefaultIdKho(P, Idkho_Control_Name, TenKho_Control_Name, LoaiThuocID_ControlName, LoaiThuocName_ControlName, false);
    }
    public static void SetDefaultIdKho(Page P, string Idkho_Control_Name, string TenKho_Control_Name, string LoaiThuocID_ControlName, string LoaiThuocName_ControlName, bool IsBeginDate)
    {
        string IdKhoClause = "";
        string idkhoa = P.Request.QueryString["idkhoa"];
        string IdKho = P.Request.QueryString["IdKho"];
        if (IdKho != null && IdKho != "")
            IdKhoClause = " AND IDKHO=" + IdKho;
        else
        {
            if (idkhoa == null || idkhoa == "" || idkhoa == "0")
            {
                string idkho1 = StaticData.MacDinhKhoNhapMuaID; ;
                string groupID = SysParameter.UserLogin.GroupID(P);
                if (groupID == "8")
                    idkho1 = StaticData.KhoThuocBHYT;
                if (groupID == "9")
                    idkho1 = StaticData.KhoThuocDV;
                IdKhoClause += " and idkho=" + idkho1;
            }
            else
                IdKhoClause += " and idkhoa=" + idkhoa;
        }

        string sqlSelect = "SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 " + IdKhoClause + " ORDER BY TENKHO";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);

        string IdLoaiThuoc = P.Request.QueryString["LoaiThuocID"];
        if (IdLoaiThuoc == null || IdLoaiThuoc == "") IdLoaiThuoc = "1";
        DataTable dtLoaiThuoc = DataAcess.Connect.GetTable("SELECT * FROM THUOC_LOAITHUOC WHERE  LoaiThuocID=" + IdLoaiThuoc);
        StringBuilder html = new StringBuilder();
        html.AppendLine("<root>");
        DataTable idkho = table;

        if (Idkho_Control_Name == null || Idkho_Control_Name == "")
            Idkho_Control_Name = "IdKho";

        if (TenKho_Control_Name == null || TenKho_Control_Name == "")
            TenKho_Control_Name = "mkv_IdKho";


        html.AppendLine("<data id=\"" + Idkho_Control_Name + "\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0]["idkho"] : "") + "</data>");
        html.AppendLine("<data id=\"" + TenKho_Control_Name + "\">" + ((idkho.Rows.Count > 0) ? idkho.Rows[0]["tenkho"] : "") + "</data>");

        DateTime currentDate = DateTime.Now;
        if (IsBeginDate)
        {
            string sqlSelectTemp = "SELECT TOP 1 NGAYTHANG FROM PHIEUNHAPKHO ORDER BY NGAYTHANG";
            DataTable dtTemp = DataAcess.Connect.GetTable(sqlSelectTemp);
            if (dtTemp != null && dtTemp.Rows.Count > 0)
                currentDate = DateTime.Parse(dtTemp.Rows[0][0].ToString());
        }

        DateTime endMonth = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));
        html.AppendLine("<data id=\"TuNgay\">" + currentDate.ToString("01/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"tungay\">" + currentDate.ToString("01/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"DenNgay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"denngay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"NgayThang\">" + currentDate.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"ngaythang\">" + currentDate.ToString("dd/MM/yyyy") + "</data>");
        if (LoaiThuocID_ControlName == null || LoaiThuocID_ControlName == "")
            LoaiThuocID_ControlName = "LoaiThuocID";

        if (LoaiThuocName_ControlName == null || LoaiThuocName_ControlName == "")
            LoaiThuocName_ControlName = "mkv_LoaiThuocID";


        html.AppendLine("<data id=\"" + LoaiThuocID_ControlName + "\">" + dtLoaiThuoc.Rows[0][0].ToString() + "</data>");
        html.AppendLine("<data id=\"" + LoaiThuocName_ControlName + "\">" + dtLoaiThuoc.Rows[0]["TenLoai"].ToString() + "</data>");


        html.AppendLine("<data id=\"gio\">" + DateTime.Now.ToString("HH") + "</data>");
        html.AppendLine("<data id=\"phut\">" + DateTime.Now.ToString("mm") + "</data>");
        html.AppendLine("<data id=\"vat\">" + "5" + "</data>");

        string fullName = SysParameter.UserLogin.FullName(P);
        string userID = SysParameter.UserLogin.UserID(P);

        html.AppendLine("<data id=\"idnguoinhap\">" + userID + "</data>");
        html.AppendLine("<data id=\"mkv_idnguoinhap\">" + fullName + "</data>");
        string Idkho2 = P.Request.QueryString["IdKho2"];
        if (Idkho2 != null && Idkho2 != "")
        {
            html.AppendLine("<data id=\"idkho2\">" + Idkho2 + "</data>");
            html.AppendLine("<data id=\"mkv_idkho2\">" + "Hư hỏng vỡ" + "</data>");

        }
        html.AppendLine("<data id=\"idnguoixuat\">" + userID + "</data>");
        html.AppendLine("<data id=\"mkv_idnguoixuat\">" + fullName + "</data>");
        html.AppendLine("</root>");
        P.Response.Clear();
        P.Response.Write(html.ToString().Replace("&", "&amp;"));
    }
    #endregion
    //───────────────────────────────────────────────────────────────────────────────────────
    #region LoaiThuoc ID Search
    public static void IdLoaiThuocSearch(Page P)
    {
        string LoaiThuocID = P.Request.QueryString["LoaiThuocID"];
        string tenLoaithuoc = P.Request.QueryString["q"];
        string sqlSelect = "SELECT * FROM THUOC_LOAITHUOC WHERE 1=1";
        if (tenLoaithuoc != null && tenLoaithuoc != "")
            sqlSelect += " AND TENLOAI LIKE N'" + tenLoaithuoc + "%'";
        if (LoaiThuocID != null && LoaiThuocID != "")
            sqlSelect += " AND LoaiThuocID = " + LoaiThuocID + "";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        P.Response.Clear(); P.Response.Write(html);
    }
    #endregion
    //───────────────────────────────────────────────────────────────────────────────────────
    #region AutoCheckSaveThuoc
    public static bool AutoCheckSaveThuoc(string idthuoc,
                                        string tenthuoc,
                                        string iddvt,
                                        string dvt,
                                        string idcachdung,
                                        string cachdung,
                                        string congthuc,
                                        string dvdung,
                                        string loaithuocid,
                                        string loaithuoc,
                                        ref string Message,
                                        ref string newIDThuoc


        )
    {
        #region Trường hợp đã có IDThuoc
        bool IsChoPhepTuDongLuuThuocKhiKeToa = StaticData.IsCheck(StaticData.GetParaValueDB("IsChoPhepTuDongLuuThuocKhiKeToa"));

        if (tenthuoc == null || tenthuoc == "") return false;
        if (idthuoc != null && idthuoc != "" && idthuoc != "0")
        {
            DataTable dtThuoc = DataAcess.Connect.GetTable("SELECT  * FROM THUOC WHERE IDTHUOC=" + idthuoc);
            if (dtThuoc == null || dtThuoc.Rows.Count == 0)
            {
                Message = "Không thể kiểm tra thuốc";
                return false;
            }
            string IsThuocBV = dtThuoc.Rows[0]["IsThuocBV"].ToString();
            #region Xử lý với thuốc ngoài bệnh viện
            if (StaticData.IsCheck(IsThuocBV) == false && IsChoPhepTuDongLuuThuocKhiKeToa)
            {
                string sqlSaveThuoc = "UPDATE THUOC SET";
                bool IsUpdateThuoc = false;
                #region trường hợp tên thuốc khác tên thuốc gốc
                if (tenthuoc.Trim().ToLower() != dtThuoc.Rows[0]["tenthuoc"].ToString().Trim().ToLower())
                {
                    #region kiểm tra xem tên thuốc này đã có trong hệ thống hay chưa, nếu tồn tại rồi thì báo lỗi
                    DataTable dtCheckThuoc = DataAcess.Connect.GetTable("SELECT * FROM THUOC WHERE TENTHUOC=N'" + tenthuoc + "'");
                    if (dtCheckThuoc == null)
                    {

                        Message = "Không thể kiểm tra thuốc";
                        return false;
                    }
                    if (dtCheckThuoc.Rows.Count > 0)
                    {
                        Message = "Đã tồn tại " + tenthuoc + " trong hệ thống";
                        return false;
                    }
                    #endregion
                    sqlSaveThuoc += ",TENTHUOC=N'" + tenthuoc + "'";
                    IsUpdateThuoc = true;
                }
                #endregion
                #region trường hợp  hoạt chất khác hoạt chất gốc
                if (congthuc.Trim().ToLower() != dtThuoc.Rows[0]["CongThuc"].ToString().Trim().ToLower())
                {
                    sqlSaveThuoc += ",CONGTHUC=N'" + congthuc + "'";
                    IsUpdateThuoc = true;
                }
                #endregion
                #region trường hợp  đơn vị tính   khác đơn vị tính
                if (iddvt.Trim().ToLower() != dtThuoc.Rows[0]["iddvt"].ToString().Trim().ToLower())
                {
                    sqlSaveThuoc += ",iddvt=N'" + iddvt + "'";
                    IsUpdateThuoc = true;
                }
                #endregion
                #region trường hợp  cách dùng   khác cách dùng
                if (idcachdung.Trim().ToLower() != dtThuoc.Rows[0]["idcachdung"].ToString().Trim().ToLower())
                {
                    sqlSaveThuoc += ",idcachdung=N'" + idcachdung + "'";
                    IsUpdateThuoc = true;
                }
                #endregion
                #region cập  nhật thuốc
                if (IsUpdateThuoc)
                {
                    sqlSaveThuoc = sqlSaveThuoc.Replace("SET,", "SET ");
                    sqlSaveThuoc += " WHERE IDTHUOC=" + idthuoc;
                    bool OK_UpdateThuoc = DataAcess.Connect.ExecSQL(sqlSaveThuoc);
                    if (!OK_UpdateThuoc)
                    {
                        Message = "Không thể cập nhật được thông tin thuốc";
                        return false;
                    }
                }
                newIDThuoc = idthuoc;
                return true;
                #endregion
            }
            #endregion
            newIDThuoc = idthuoc;
            return true;
        }
        #endregion
        #region Trường hợp thuốc mới
        else
        {
            if (IsChoPhepTuDongLuuThuocKhiKeToa)
            {
                string sqlInsertThuoc = @"INSERT INTO THUOC(TENTHUOC,LOAITHUOCID,IDDVT,IDCACHDUNG,CONGTHUC,ISTHUOCBV) 
                                    VALUES (N'" + tenthuoc + "',1," + iddvt + "," + idcachdung + ",N'" + congthuc + "',0)";
                bool OK_InsertThuoc = DataAcess.Connect.ExecSQL(sqlInsertThuoc);
                if (!OK_InsertThuoc)
                {
                    Message = "Không thể lưu thuốc mới";
                    return false;
                }
                string sqlGetTop1IdThuoc = "SELECT TOP 1 IDTHUOC FROM THUOC WHERE TENTHUOC=N'" + tenthuoc + "'AND CONGTHUC=N'" + congthuc + "' AND ISTHUOCBV=0 AND IDDVT=" + iddvt + " ORDER BY IDTHUOC DESC";
                DataTable dtThuoc_New = DataAcess.Connect.GetTable(sqlGetTop1IdThuoc);
                if (dtThuoc_New == null || dtThuoc_New.Rows.Count == 0)
                {
                    Message = "Không thể lấy IdThuoc vừa lưu";
                    return false;
                }
                newIDThuoc = dtThuoc_New.Rows[0][0].ToString();
                return true;
            }
            else
            {
                return false;

            }
        }
        #endregion

    }
    #endregion
    //───────────────────────────────────────────────────────────────────────────────────────
    #region getthuoc_new 
    public static void getthuoc_new(System.Web.UI.Page Page, bool IsNhapKho)
    {
        string idkhoNhapMua = StaticData.GetParaValueDB("KhoNhapMuaID");
        string IsCoSoTuTruc = Page.Request.QueryString["IsCoSoTuTruc"];
        string IdChiTietYc = Page.Request.QueryString["IdChiTietYc"];
        if (IdChiTietYc == null || IdChiTietYc == "" || IdChiTietYc == "0") IdChiTietYc = "NULL";
        string type = Page.Request.QueryString["type"];
        string CurrentSL = Page.Request.QueryString["CurrentSL"];
        string CurrentIdThuoc = Page.Request.QueryString["CurrentIdThuoc"];
        string idKho = (Page.Request.QueryString["idkho"] != null ? Page.Request.QueryString["idkho"].ToString() : idkhoNhapMua);
        if (idKho == "") return;
        DataTable dtTestKhoYC = DataAcess.Connect.GetTable("SELECT NVK_LOAIKHO FROM KHOTHUOC WHERE  IDKHO=" + idKho);
        if (dtTestKhoYC == null || dtTestKhoYC.Rows.Count == 0) return;
        string IsYCXuat = Page.Request.QueryString["IsYCXuat"];
        string IsYCTRA = Page.Request.QueryString["IsYCTRA"];
        bool IsCheckSLTon = true;
        if (Page.Request.QueryString["IsCheckSLTon"] == "0") IsCheckSLTon = false;

        string sqlClause = "";
        if (Page.Request.QueryString["q"] != null)
        {
            if (type == "2")
                sqlClause += " and B.TTHoatChat like N'%" + Page.Request.QueryString["q"] + "%'";
            else

                sqlClause += " and B.tenthuoc like N'" + Page.Request.QueryString["q"] + "%'";
        }
        string NgayCT = "GETDATE()";
        if (Page.Request.QueryString["NgayCT"] != null && Page.Request.QueryString["NgayCT"] != "")
        {
            NgayCT = Page.Request.QueryString["NgayCT"].ToString();
            NgayCT = StaticData.CheckDate(NgayCT);
            string Gio = Page.Request.QueryString["Gio"];
            string Phut = Page.Request.QueryString["Phut"];
            if (Gio == null || Gio == "") Gio = "23";
            if (Phut == null || Phut == "") Phut = "59";
            NgayCT = "'" + NgayCT + " " + Gio + ":" + Phut + ":59" + "'";
        }

        string loaithuoc = Page.Request.QueryString["loaithuoc"];
        if (loaithuoc == null || loaithuoc == "")
            loaithuoc = Page.Request["LoaiThuocID"];
        if (loaithuoc != null && loaithuoc != "")
        {
            string LoaiThuocID = loaithuoc;
            if (LoaiThuocID != "5" && LoaiThuocID != "6")
                sqlClause += " and B.loaithuocid='" + LoaiThuocID + "'";
            else
            {
                if (IsHaveThuocGN_TT)
                {
                    if (LoaiThuocID == "5")
                    {
                        sqlClause += " and B.IsTGN=1 and B.LoaithuocID=1";
                    }
                    if (LoaiThuocID == "6")
                    {
                        sqlClause += " and B.IsTHTT=1 and B.LoaithuocID=1";
                    }
                }
                else
                    sqlClause += " and B.loaithuocid='" + LoaiThuocID + "'";
            }

        }
        string idkho2 = Page.Request.QueryString["idkho2"];
        if (idkho2 == StaticData.KhoThuocBHYT)
        {
            sqlClause += " AND B.sudungchobh=1";
        }
        string Para_idDuoc = idkhoNhapMua;
        bool ChoPhepTheHien = (StaticData.GetParaValueDB("ChoPhepTheHienThuocKhongCoSLTon") == "1" ? true : false);


        string strTenSoTon = "SLTON";
        if (Para_idDuoc.Equals(idKho))
            strTenSoTon = "tonSauDuTru";
        string sqlThuoc = @"
                            select top 20 tonSauDuTru=0
                             	    ,B.idthuoc
                                    ,B.sttindm05
                                    ,B.tenthuoc
                                    ,B.iddvt
                                    ,tendvt=d.tendvt
                                    ,B.congthuc
                                    ,B.TTHoatChat
                                    ,SLDVTChuan
                                    ,SLQuyDoi
                                    ,b.dvtchuan
                                    ,tendvtchuan=c.tendvt
                                    ,SLTON=" + (IsCheckSLTon ? " DBO.Thuoc_TonKho_PHIEUNHAP(B.IDTHUOC," + NgayCT + "," + idKho + @")" : "0") + @" 
									,tonao=" + (IsCheckSLTon && IsYCTRA!="1" ? " DBO.HS_SLYEUCAUCHUADUYET(B.IDTHUOC," + idKho + @"," + IdChiTietYc + @")" : "0") + @"
                            FROM 
                              THUOC B  
                                    LEFT JOIN THUOC_DONVITINH C ON B.dvtchuan=C.ID
                                    LEFT JOIN THUOC_DONVITINH D ON B.IDDVT=D.ID
                             WHERE B.ISTHUOCBV=1 " + sqlClause + @"
                                     ORDER BY TENTHUOC,TTHOATCHAT,CONGTHUC";

        string html = "";

        DataTable dtCoSoTuTruc = null;
        bool View = true;

//        if (IsCoSoTuTruc == "1" && dtTestKhoYC.Rows[0][0].ToString() != "3")
//        {
//            string idkho_CosSo = idKho;

        

//            if (IsYCXuat == "1") idkho_CosSo = idkho2;
//            if (IsYCTRA == "1") idkho_CosSo = idKho;

//            string sqlCoSo = @"select idthuoc from thuoc_cosotutruc_chitiet tt 
//                                        inner join thuoc_cosotutruc bb on tt.IdCoSoTuTruc=bb.IdCoSoTuTruc
//                                        where bb.idkho=" + idkho_CosSo;
//            dtCoSoTuTruc = DataAcess.Connect.GetTable(sqlCoSo);
//        }

        DataTable table = DataAcess.Connect.GetTable(sqlThuoc);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            if (dtCoSoTuTruc != null && dtCoSoTuTruc.Rows.Count > 0)
            {
                int nn = StaticData.int_Search(dtCoSoTuTruc, "idthuoc=" + table.Rows[i]["idthuoc"].ToString());
                if (nn == -1)
                    View = false;
                else View = true;
            }
            if (View)
            {
                string iSLTon = table.Rows[i]["SLTON"].ToString();
                if (iSLTon == "") iSLTon = "0";
                double dSLTON = double.Parse(iSLTon);
                if (CurrentIdThuoc != null && CurrentIdThuoc != "" && CurrentIdThuoc != "0" && CurrentSL != null && CurrentSL != "" && CurrentSL != "0" && table.Rows[i]["idthuoc"].ToString() == CurrentIdThuoc)
                {
                    dSLTON = dSLTON + double.Parse(CurrentSL);
                    table.Rows[i]["SLTON"] = double.Parse(table.Rows[i]["SLTON"].ToString()) + double.Parse(CurrentSL);
                }
                if (ChoPhepTheHien || dSLTON > 0)
                {
                    string tonao = table.Rows[i]["tonao"].ToString();
                    if (tonao == "") tonao = "0";
                    double dtonao = double.Parse(tonao);
                    double dtonSauDuTru = dSLTON - dtonao;
                    table.Rows[i]["tonSauDuTru"] = dtonSauDuTru;
                    DataRow h = table.Rows[i];
                    html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}", "<div>"
                          + "<div style=\"width:5%;height:30px;float:left\" >" + (i + 1) + "</div>"
                         + "<div style=\"width:15%;height:30px;float:left; text-align:left;\" >" + h["TTHoatChat"] + "</div>"
                         + "<div style=\"width:35%;height:30px;float:left; text-align:left;\" >" + h["tenthuoc"] + "</div>"
                         + "<div style=\"width:20%;height:30px;float:left\" >" + h["congthuc"] + "</div>"
                         + "<div style=\"width:7%;height:30px;float:left;text-align:center;\" >" + h["tendvt"] + "</div>"
                         + "<div style=\"width:8%;height:30px;float:left;text-align:center;\" >" + string.Format("{0:0.##}", h["SLTON"]) + "</div>"
                         + (idKho.Equals(Para_idDuoc) ? "<div style=\"width:7%;height:30px;float:left;text-align:center;\" >" + string.Format("{0:0.##}", h["tonao"]) + "</div>" : "")
                         + "</div>", h["idthuoc"], h["congthuc"], h["iddvt"], h["tenthuoc"], h["sttindm05"], string.Format("{0:0.##}", h[strTenSoTon]), h["tendvt"], h["SLQuyDoi"], h["dvtchuan"], h["tendvtchuan"], h["tthoatchat"], h["tonao"], h["SLTON"], Environment.NewLine);
                }
            }

        }
        Page.Response.Clear();
        Page.Response.Write(html);
        Page.Response.End();
    }
    #endregion
    #region Caculate
    public static DateTime Caculate_NgayDuyet(string NgayYC)
    {
        DateTime dNgayYC = DateTime.Parse(NgayYC);
        DateTime dNgayDuyet = dNgayYC;
        if (dNgayYC>DateTime.Parse( DateTime.Parse(NgayYC).ToString("yyyy-MM-dd 13:30:00")))
        {
            dNgayDuyet = dNgayDuyet.AddDays(1);
            dNgayDuyet = DateTime.Parse(dNgayDuyet.ToString("yyyy-MM-dd 00:00:00"));
        }
        return dNgayDuyet;
    }
    #endregion
}//end class

using Microsoft.VisualBasic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public class mdlCommonFunction
	{
    static public object FormatNumber(object objNumber, bool isDB)
    {
        objNumber = Convert.ToDouble(objNumber);
        if (Convert.ToDouble(objNumber) == 0) return "";
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
	
    //Kiem tra ngay thang nam dua vao co phai la chu nhat hay khong
     static public string ChangeDateTo_MM_dd(string date_dd_MM)
    {
        string Date="";
        if (!string.IsNullOrEmpty(date_dd_MM))
        {
            string[] buffer = date_dd_MM.Split('/');
            string Day="" , Month="", Year="";
           
               if (Int32.Parse(buffer[0].ToString()) < 10&&buffer[0].Length<2)
                    Day = "0" + buffer[0].ToString();
                else
                {
                    Day = buffer[0].ToString();
                }
                if (Int32.Parse(buffer[1].ToString()) < 10 && buffer[1].Length < 2)
                    Month = "0" + buffer[1].ToString();
                else
                {
                    Month = buffer[1].ToString();
                }
                if (buffer[2].Length == 4)
                {
                    Year = buffer[2].ToString();
                }
                
                Date = Month +'/'+ Day+'/' + Year;
            
           
      }
      return Date;
    }
    static public string ChangeDateTo_dd_MM(string date_MM_dd)
    {
        string Date = "";
        if (!string.IsNullOrEmpty(date_MM_dd))
        {
            string date_new = date_MM_dd.Substring(0, 10);
            string[] buffer = date_new.Split('/');
            string Day = "", Month = "", Year = "";

            if (Int32.Parse(buffer[1].ToString()) < 10 && buffer[1].Length < 2)
                Day = "0" + buffer[1].ToString();
            else
            {
                Day = buffer[1].ToString();
            }
            if (Int32.Parse(buffer[0].ToString()) < 10 && buffer[0].Length < 2)
                Month = "0" + buffer[0].ToString();
            else
            {
                Month = buffer[0].ToString();
            }
            if (buffer[2].Length == 4)
            {
                Year = buffer[2].ToString();
            }

            Date = Day + '/' + Month + '/' + Year;
        }
        return Date;
    }
    static public string TaoSoThuTu(int so_thu_tu)
    {
        so_thu_tu++;
        string stt = "";
        if (so_thu_tu > 0 && so_thu_tu < 10)
        {
            stt = "000" + so_thu_tu.ToString();
        }
        else
            if (so_thu_tu >= 10 && so_thu_tu <= 99)
            {
                stt = "00" + so_thu_tu.ToString();
            }
            else
                if (so_thu_tu >= 100 && so_thu_tu <= 999)
                {
                    stt = "0" + so_thu_tu.ToString();
                }
                else
                {
                    stt = so_thu_tu.ToString();
                }
        return stt;
    }
    static public string TaoMaSoTuDong_TheoNgayTuChon(int Thang, int Nam, string TenTable, string KyTuDau, string FielMa)
    {
        string MaTuDong = "";
        //int Thang = Int32.Parse(Request.QueryString["Thang"].ToString());
        //int Nam = Int32.Parse(Request.QueryString["Nam"].ToString());
        //string TenTable = Request.QueryString["Table"];
        //string KyTuDau = Request.QueryString["KyTuDau"];
        //string FielMa = Request.QueryString["Column"];
        string sql = "select top(1) " + FielMa + " from  " + TenTable;
        sql += "   where " + FielMa + " like '" + KyTuDau + "%' and  " + FielMa + " like '%" + Thang + Nam + "' ";
        sql += "order by " + FielMa + " desc ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                string Ma = table.Rows[0][0].ToString();
                string[] buffer = Ma.Split('-');
                string ky_tu_dau = buffer[0];

                //Tao day so;
                string[] day_so = buffer[1].Split('/');
                int so_thu_tu = Int32.Parse(day_so[0]);
                string stt = TaoSoThuTu(so_thu_tu);

                string thangnam = day_so[1];
                int thang = Int32.Parse(thangnam.Substring(0, 2));
                int nam = Int32.Parse(thangnam.Substring(2, 4));

                //Tao thang nam
                MaTuDong = ky_tu_dau + "-" + stt + "/" + thang.ToString() + nam.ToString();

            }
            else //Mã số đầu tiên
            {
                string month = "";
                if (Thang < 10)
                    month = "0" + Thang;
                else
                    month = Thang.ToString();

                MaTuDong = KyTuDau + "-" + "0001" + "/" + month + Nam.ToString();
            }
        }
        return MaTuDong;
    }
    static public DataTable congty()
    {
        //lay ten, dia chi cong ty
        string sql = "select ten_cty,diachi from tieudecty";
        DataTable dtcty = new DataTable();
        dtcty = DataAcess.Connect.GetTable(sql);
        return dtcty;
    }
    static public DataTable thamsotuychon()
    {
        //lây tên giám đốc,....
        string sql = "select tham_so,gia_tri from tham_so where tham_so='ma_so_thue' or tham_so='so_quet_dinh_ke_toan' or tham_so='ho_ten_giam_doc' ";
        sql += " or tham_so='ho_ten_ke_toan_truong' or tham_so='ho_ten_thu_quy' or tham_so='ho_ten_nguoi_lap_phieu' or tham_so='ngay_dau_sd_chuong_trinh' or tham_so='ngay_dau_nam_tai_chinh' or tham_so='' or tham_so='ngay_khoa_so'";
        DataTable dt = new DataTable();
        dt = DataAcess.Connect.GetTable(sql);
        return dt;
    }
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
            string csTi = "";
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
            //if (csPart1.Length > 9)
            //{
            //    //  MessageBox.Show("Tien thanh toan len den tien ty la dieu khong the\r\nHay xem du lieu va tinh toan lai di Oai vo van");
            //    return "";
            //}
            while (csPart1.Length > 3)
            {
                if (csTram == "")
                    csTram = csPart1.Substring(csPart1.Length - 3, 3);
                else
                    if(csNghin=="")
                        csNghin = csPart1.Substring(csPart1.Length - 3, 3);
                    else
                        csTrieu = csPart1.Substring(csPart1.Length - 3, 3);
                csPart1 = csPart1.Substring(0, csPart1.Length - 3);
            }
            if (csTram == "")
                csTram = csPart1;
            else
                if (csNghin == "")
                    csNghin = csPart1;
                else
                    if (csTrieu == "")
                        csTrieu = csPart1;
                    else
                        csTi = csPart1;

            if (csTram != "")
                csTram = SplipNumber(csTram);
            if (csNghin != "")
                csNghin = SplipNumber(csNghin);
            if (csTrieu != "")
                csTrieu = SplipNumber(csTrieu);
            if (csTi != "")
                csTi = SplipNumber(csTi);

            if (csTram != "")
                csResult = csTram + csResult;
            if (csNghin != "")
                csResult = csNghin + "nghìn " + csResult;
            if (csTrieu != "")
                csResult = csTrieu + "triệu " + csResult;
            if (csTi != "")
                csResult = csTi + "tỉ " + csResult;

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
        return csResult;
    }
    //──────────────────────────────────────────────────────────────────────────────────────────   
    
}

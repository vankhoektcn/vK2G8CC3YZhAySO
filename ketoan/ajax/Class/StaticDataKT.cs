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
/// Summary description for StaticDataKT
/// </summary>
public class StaticDataKT
{
    public StaticDataKT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string CreateMaKT(string manghiepvu, string table)
    {
        string soctmoi = "";
        int thang = int.Parse(DateTime.Now.Month.ToString());
        int nam = int.Parse(DateTime.Now.Year.ToString().Substring(2,2));
        int stt = 0;
        DataTable tbdmnv = DataAcess.Connect.GetTable("select tiepdaungu,soct_hientai=isnull(soct_hientai,'') from dmnghiepvu where manghiepvu='" + manghiepvu + "'");
        if(tbdmnv.Rows.Count == 0)
            return "";
        string tiepdaungu = tbdmnv.Rows[0]["tiepdaungu"].ToString();
        string soct_hientai = tbdmnv.Rows["soct_hientai"].ToString();
        if (soct_hientai != "")
        {
            //Tìm số chứng từ kế tiếp
            string sqlsoctmax=@"select top 1 stt_soct_max=substring(so_phieu,len(so_phieu)-7,4) from "+ table +" where substring(so_phieu,0,len(so_phieu)-7)='PN' and right(so_phieu,4)='0412'";
                   sqlsoctmax += " order by substring(so_phieu,len(so_phieu)-7,4) desc";
            DataTable tbsoctmax = DataAcess.Connect.ExecSQL(sqlsoctmax);
            int stt_soct_hientai = 1;
            int stt_soct_max = 1;
            if (tbsoctmax.Rows.Count > 0)
                stt_soct_max = int.Parse(tbsoctmax.Rows[0][0].ToString());
            stt_soct_max = int.Parse(soct_hientai.Substring(soct_hientai.Length - 7, 4));
            if (stt_soct_hientai >= stt_soct_max + 1)
                stt = stt_soct_hientai + 1;
            else
            {
                for (int i = (stt_soct_hientai + 1); i < (stt_soct_max + 1); i++)
                {
                    string checksoct = tiepdaungu + getchuoi_dd4(i.ToString()) + thang.ToString() + nam.ToString();
                    DataTable tbchecksoct = DataAcess.Connect.GetTable("select top 1 so_phieu from " + table + " where so_phieu='" + checksoct + "'");
                    if (tbchecksoct.Rows.Count > 0)
                    {
                        stt = i;
                        break;
                    }
                }
            }
            soctmoi = tiepdaungu + getchuoi_dd4(stt.ToString()) + thang.ToString() + nam.ToString();
            //Cập nhật lại số chứng từ hiện tại
            string sqlupdatedmnv = "update dmnghiepvu set soct_hientai='" + soctmoi + "'";
            bool updatedmnv = DataAcess.Connect.ExecSQL(sqlupdatedmnv);
            ////////////////
            return soct_hientai;
        }
        else
        {
            //Cập nhật số so_ct hiện tại= tiepdaungu + "0002" + thang.ToString() + nam.ToString()
            soctmoi = tiepdaungu + "0002" + thang.ToString() + nam.ToString();
            string sqlupdatedmnv = "update dmnghiepvu set soct_hientai='" + soctmoi + "'";
            bool updatedmnv = DataAcess.Connect.ExecSQL(sqlupdatedmnv);
            ////////
            return tiepdaungu + "0001" + thang.ToString() + nam.ToString();
        }
    }
    public static string getchuoi_dd4(string chuoi)
    {
        if (chuoi.Length == 1)
            return "000" + chuoi;
        if (chuoi.Length == 2)
            return "00" + chuoi;
        if (chuoi.Length == 3)
            return "0" + chuoi;
        if (chuoi.Length == 4)
            return chuoi;
    }
}

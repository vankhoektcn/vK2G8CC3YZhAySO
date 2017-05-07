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
public class AutoComplete
{
    //__________________________________________________________________________________
    public static void idphongkhambenhSearch(Page P,bool IsChuyenKhoa)
    {
        string svalue = P.Request.QueryString["q"];
        string sqlSelect = "select * from phongkhambenh WHERE LOAIPHONG="+(IsChuyenKhoa==true ?"0":"1");
        if (svalue != null && svalue != "")
            sqlSelect += " AND TENPHONGKHAMBENH LIKE N'%" + svalue + "%'";

        DataTable table = DataProcess.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenphongkhambenh"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        P.Response.Clear(); P.Response.Write(html);
    }
    //__________________________________________________________________________________
    public static void DichVuKCBSearch(Page P, bool IsChuyenKhoa)
    {
        string svalue = P.Request.QueryString["q"];
        string sqlSelect = "select * from banggiadichvu WHERE IsChuyenKhoa=" + (IsChuyenKhoa == true ? "1" : "0");
        if (svalue != null && svalue != "")
            sqlSelect += " AND tendichvu LIKE N'%" + svalue + "%'";

        DataTable table = DataProcess.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tendichvu"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        P.Response.Clear(); P.Response.Write(html);
    }
    //__________________________________________________________________________________
    public static void IDDVT_CLS_Search(Page P)
    {
        string svalue = P.Request.QueryString["q"];
        string sqlSelect = "select * from KB_DONVITINH_DV WHERE 1=1";
        if (svalue != null && svalue != "")
            sqlSelect += " AND TENDVT LIKE N'%" + svalue + "%'";

        DataTable table = DataProcess.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TENDVT"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        P.Response.Clear(); P.Response.Write(html);
    }
    //__________________________________________________________________________________
    public static void IDNhomINBV_Search(Page P)
    {
        string svalue = P.Request.QueryString["q"];
        string sqlSelect = "select *,TENHOMBV=TENNHOM from HS_NhomINBV WHERE 1=1";
        if (svalue != null && svalue != "")
            sqlSelect += " AND TenNhom LIKE N'%" + svalue + "%'";

        DataTable table = DataProcess.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TENHOMBV"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        P.Response.Clear(); P.Response.Write(html);
    }
    //__________________________________________________________________________________
    #region Static DataTable
    #region dtThuocNgoaiBV
    private static DataTable dtThuocNgoaiBV_temp = null;
    public static DataTable dtThuocNgoaiBV
    {
        get
        {
            if (dtThuocNgoaiBV_temp == null)
                dtThuocNgoaiBV_temp = DataAcess.Connect.GetTable("SELECT * FROM THUOC WHERE ISNULL(ISTHUOCBV,0)=0");
            return dtThuocNgoaiBV_temp;
        }
        set
        {
            dtThuocNgoaiBV_temp = value;
        }
    }
    #endregion
    #region dtThuocBV
    private static DataTable dtThuocBV_temp = null;
    public static DataTable dtThuocBV
    {
        get
        {
            if (dtThuocBV_temp == null)
                dtThuocBV_temp = DataAcess.Connect.GetTable("SELECT * FROM THUOC WHERE ISTHUOCBV=1");
            return dtThuocBV_temp;
        }
        set
        {
            dtThuocBV_temp = value;
        }
    }
    #endregion
    #region Kho
    private static DataTable dtKho_temp = null;
    public static DataTable dtKho
    {
        get
        {
            if (dtKho_temp == null)
                dtKho_temp = DataAcess.Connect.GetTable("SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0");
            return dtKho_temp;
        }
        set
        {
            dtKho_temp = value;
        }
    }
    #endregion
    #region KhoByKhoa
    public static DataTable dtKhoByKhoa(string IdKhoa)
    {
        DataTable dt = dtKho;
        DataView dv = new DataView(dt.Copy());
        dv.RowFilter = "IDKHOA=" + IdKhoa;
        return dv.ToTable();
    }
     #endregion
    #region DTKhoa
    private static DataTable dtKhoa_temp = null;
    public static DataTable dtKhoa
    {
        get
        {
            if (dtKhoa_temp == null)
            {
                string sqlSelect = "SELECT * FROM PHONGKHAMBENH";
                dtKhoa_temp = DataAcess.Connect.GetTable(sqlSelect);
            }
            return dtKhoa_temp;
        }
        set
        {
            dtKhoa_temp = value;
        }
    }
    #endregion
    #region dtThuocSearch
    private static DataTable dtThuocSearch_Temp = null;
    public static string sqlThuocSearch_KB
    {
        get
        {
            string sql = @"SELECT  t.idthuoc,t.tenthuoc
                                        ,t.loaithuocid
                                        ,dvt.tendvt as donvitinh,t.iddvt
                                        ,t.congthuc as congthuc
                                        , cd.tencachdung as duongdung,cd.idcachdung
                                        ,t.sudungchobh
                                        ,t.isthuocbv
                                        ,t.*
                                        FROM thuoc t
                                        left join thuoc_donvitinh dvt on dvt.id=t.iddvt
                                        left join thuoc_cachdung cd on cd.idcachdung=t.idcachdung";
            return sql;
        }
    }
    public static string sqlThuocOrderBy_KB = @"ORDER BY  isnull(t.sudungchobh,0) desc, isnull( t.isthuocbv,0) desc ,  t.tenthuoc ASC";
    public static string ClauseThuocOrderBy_KB = @"sudungchobh desc,  isthuocbv desc ,  tenthuoc ASC";
    public static DataTable dtThuocSearch
    {
        get
        {
            if (dtThuocSearch_Temp == null)
            {
                string sqlSelect = sqlThuocSearch_KB +" "+sqlThuocOrderBy_KB;
                                        
                                    
                dtThuocSearch_Temp = DataAcess.Connect.GetTable(sqlSelect);
                
            }
            return dtThuocSearch_Temp;
        }

        set
        {
            dtThuocSearch_Temp = value;
        }

    }
    #endregion
    #region InsertNewThuocRefresh
    public static void RefreshAffer_InsertThuoc(string idthuoc)
    {
        DataTable dt01 = AutoComplete.dtThuocSearch;
        string sqlInsert1 = AutoComplete.sqlThuocSearch_KB + "     where t.idthuoc=" + idthuoc;
        DataTable dt1 = DataAcess.Connect.GetTable(sqlInsert1);
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            StaticData.dt_ImportRow(dt1, 0, dt01);
            dt1.DefaultView.Sort = AutoComplete.ClauseThuocOrderBy_KB;
            dt1 = dt1.DefaultView.ToTable();
        }
    }
    #endregion
    #region RefreshAffer_SaveThuoc
    public static void RefreshAffer_SaveThuoc(string idthuoc)
    {
        DataTable dt01 = AutoComplete.dtThuocSearch;
        string sqlInsert1 = AutoComplete.sqlThuocSearch_KB + "     where t.idthuoc=" + idthuoc;
        DataTable dt1 = DataAcess.Connect.GetTable(sqlInsert1);
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            int n = StaticData.int_Search(dt01, "idthuoc=" +idthuoc);
            if (n != -1)
                StaticData.dt_Repalce(dt1, 0, dt01, n);
        }
    }
    #endregion

    #endregion
    //__________________________________________________________________________________
    public static void AutoSearchSimpleOption(Page P, string TableName,string columnId,string ColumnName,string where)
    {
        string sqlSelect = "select " + columnId + "," + ColumnName + " from "+TableName+" WHERE 1=1 "+where+"";
        DataTable table = DataProcess.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][ColumnName].ToString() + "|" + table.Rows[i][columnId].ToString());

                }
            }
        }
        P.Response.Clear(); P.Response.Write(html);
    }
    //__________________________________________________________________________________
}//end class

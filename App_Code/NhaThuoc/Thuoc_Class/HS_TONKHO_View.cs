using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAcess;
//───────────────────────────────────────────────────────────────────────────────────────
namespace Process_2608
{
    public class HS_TONKHO_View : Connect
    {
        public static string sTableName = "HS_TONKHO_View";
        public string IdTonKho;
        public string IdKho;
        public string TuNgay;
        public string DenNgay;
        public string LoaiThuocID;
        public string IdThuoc;
        public string TenThuoc;
        public string IsOrderByName;
        public string IsHaveDonGia;
        public string IsSoLuong;
        public string IsRutGon;
        public string page;
        public string numberRow;
        #region DataColumn Name ;
        public static string cl_IdTonKho = "IdTonKho";
        public static string cl_IdTonKho_VN = "IdTonKho";
        public static string cl_IdKho = "IdKho";
        public static string cl_IdKho_VN = "IdKho";
        public static string cl_TuNgay = "TuNgay";
        public static string cl_TuNgay_VN = "TuNgay";
        public static string cl_DenNgay = "DenNgay";
        public static string cl_DenNgay_VN = "DenNgay";
        public static string cl_LoaiThuocID = "LoaiThuocID";
        public static string cl_LoaiThuocID_VN = "LoaiThuocID";
        public static string cl_IdThuoc = "IdThuoc";
        public static string cl_IdThuoc_VN = "IdThuoc";
        public static string cl_TenThuoc = "TenThuoc";
        public static string cl_TenThuoc_VN = "TenThuoc";
        public static string cl_IsOrderByName = "IsOrderByName";
        public static string cl_IsOrderByName_VN = "IsOrderByName";
        public static string cl_IsHaveDonGia = "IsHaveDonGia";
        public static string cl_IsHaveDonGia_VN = "IsHaveDonGia";
        public static string cl_IsSoLuong = "IsSoLuong";
        public static string cl_IsSoLuong_VN = "IsSoLuong";
        public static string cl_IsRutGon = "IsRutGon";
        public static string cl_IsRutGon_VN = "IsRutGon";
        #endregion;
        //───────────────────────────────────────────────────────────────────────────────────────
        public HS_TONKHO_View() { }
        //───────────────────────────────────────────────────────────────────────────────────────
        public HS_TONKHO_View(
          string sIdTonKho,
          string sIdKho,
          string sTuNgay,
          string sDenNgay,
          string sLoaiThuocID,
          string sIdThuoc,
          string sTenThuoc,
          string sIsOrderByName,
          string sIsHaveDonGia,
          string sIsSoLuong,
          string sIsRutGon)
        {
            this.IdTonKho = sIdTonKho;
            this.IdKho = sIdKho;
            this.TuNgay = sTuNgay;
            this.DenNgay = sDenNgay;
            this.LoaiThuocID = sLoaiThuocID;
            this.IdThuoc = sIdThuoc;
            this.TenThuoc = sTenThuoc;
            this.IsOrderByName = sIsOrderByName;
            this.IsHaveDonGia = sIsHaveDonGia;
            this.IsSoLuong = sIsSoLuong;
            this.IsRutGon = sIsRutGon;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static HS_TONKHO_View Create_HS_TONKHO_View(string sIdTonKho)
        {
            DataTable dt = dtSearchByIdTonKho(sIdTonKho);
            if (dt != null && dt.Rows.Count > 0)
                return new HS_TONKHO_View(dt.DefaultView, 0);
            return null;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        private static string s_Select()
        {
            return " SELECT T.* FROM HS_TONKHO_View AS T";
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        private string SQLSelect()
        {
            string sqlselect = " SELECT stt= row_number() over (order by IdTonKho),T.* FROM HS_TONKHO_View AS T WHERE";
            if (this.IdKho != null && this.IdKho != "" && this.IdKho != "0" && this.IdKho != "0.0")
                sqlselect += " AND IdKho =" + this.IdKho;
            if (this.TuNgay != null && this.TuNgay != "")
                sqlselect += " AND TuNgay LIKE '%" + this.TuNgay + "%'";
            if (this.DenNgay != null && this.DenNgay != "")
                sqlselect += " AND DenNgay LIKE '%" + this.DenNgay + "%'";
            if (this.LoaiThuocID != null && this.LoaiThuocID != "" && this.LoaiThuocID != "0" && this.LoaiThuocID != "0.0")
                sqlselect += " AND LoaiThuocID =" + this.LoaiThuocID;
            if (this.IdThuoc != null && this.IdThuoc != "" && this.IdThuoc != "0" && this.IdThuoc != "0.0")
                sqlselect += " AND IdThuoc =" + this.IdThuoc;
            if (this.TenThuoc != null && this.TenThuoc != "")
                sqlselect += " AND TenThuoc LIKE N'%" + this.TenThuoc + "%'";
            if (this.IsOrderByName != null && this.IsOrderByName != "")
                sqlselect += " AND IsOrderByName ='" + this.IsOrderByName + "'";
            if (this.IsHaveDonGia != null && this.IsHaveDonGia != "")
                sqlselect += " AND IsHaveDonGia ='" + this.IsHaveDonGia + "'";
            if (this.IsSoLuong != null && this.IsSoLuong != "")
                sqlselect += " AND IsSoLuong ='" + this.IsSoLuong + "'";
            if (this.IsRutGon != null && this.IsRutGon != "")
                sqlselect += " AND IsRutGon ='" + this.IsRutGon + "'";
            sqlselect = sqlselect.Replace("WHERE AND", "WHERE");
            int n = sqlselect.IndexOf("WHERE");
            if (n == sqlselect.Length - 5) sqlselect = sqlselect.Remove(n, 5);
            return sqlselect;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public HS_TONKHO_View(DataView dv, int pos)
        {
            this.IdTonKho = dv[pos][0].ToString();
            this.IdKho = dv[pos][1].ToString();
            this.TuNgay = dv[pos][2].ToString();
            this.DenNgay = dv[pos][3].ToString();
            this.LoaiThuocID = dv[pos][4].ToString();
            this.IdThuoc = dv[pos][5].ToString();
            this.TenThuoc = dv[pos][6].ToString();
            this.IsOrderByName = dv[pos][7].ToString();
            this.IsHaveDonGia = dv[pos][8].ToString();
            this.IsSoLuong = dv[pos][9].ToString();
            this.IsRutGon = dv[pos][10].ToString();
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdTonKho(string sIdTonKho)
        {
            string sqlSelect = s_Select() + " WHERE IdTonKho  =" + sIdTonKho + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdTonKho(string sIdTonKho, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IdTonKho" + sMatch + sIdTonKho + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdKho(string sIdKho)
        {
            string sqlSelect = s_Select() + " WHERE IdKho  =" + sIdKho + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdKho(string sIdKho, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IdKho" + sMatch + sIdKho + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByTuNgay(string sTuNgay)
        {
            string sqlSelect = s_Select() + " WHERE TuNgay  =" + sTuNgay + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByTuNgay(string sTuNgay, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE TuNgay" + sMatch + sTuNgay + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByDenNgay(string sDenNgay)
        {
            string sqlSelect = s_Select() + " WHERE DenNgay  =" + sDenNgay + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByDenNgay(string sDenNgay, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE DenNgay" + sMatch + sDenNgay + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByLoaiThuocID(string sLoaiThuocID)
        {
            string sqlSelect = s_Select() + " WHERE LoaiThuocID  =" + sLoaiThuocID + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByLoaiThuocID(string sLoaiThuocID, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE LoaiThuocID" + sMatch + sLoaiThuocID + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdThuoc(string sIdThuoc)
        {
            string sqlSelect = s_Select() + " WHERE IdThuoc  =" + sIdThuoc + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdThuoc(string sIdThuoc, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IdThuoc" + sMatch + sIdThuoc + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByTenThuoc(string sTenThuoc)
        {
            string sqlSelect = s_Select() + " WHERE TenThuoc  Like N'%" + sTenThuoc + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsOrderByName(string sIsOrderByName)
        {
            string sqlSelect = s_Select() + " WHERE IsOrderByName  =" + sIsOrderByName + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsOrderByName(string sIsOrderByName, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IsOrderByName" + sMatch + sIsOrderByName + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsHaveDonGia(string sIsHaveDonGia)
        {
            string sqlSelect = s_Select() + " WHERE IsHaveDonGia  =" + sIsHaveDonGia + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsHaveDonGia(string sIsHaveDonGia, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IsHaveDonGia" + sMatch + sIsHaveDonGia + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsSoLuong(string sIsSoLuong)
        {
            string sqlSelect = s_Select() + " WHERE IsSoLuong  =" + sIsSoLuong + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsSoLuong(string sIsSoLuong, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IsSoLuong" + sMatch + sIsSoLuong + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsRutGon(string sIsRutGon)
        {
            string sqlSelect = s_Select() + " WHERE IsRutGon  =" + sIsRutGon + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsRutGon(string sIsRutGon, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IsRutGon" + sMatch + sIsRutGon + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearch(string sIdTonKho
                   , string sIdKho
                   , string sTuNgay
                   , string sDenNgay
                   , string sLoaiThuocID
                   , string sIdThuoc
                   , string sTenThuoc
                   , string sIsOrderByName
                   , string sIsHaveDonGia
                   , string sIsSoLuong
                   , string sIsRutGon
                   )
        {
            string sqlselect = s_Select() + " WHERE";
            if (sIdTonKho != null && sIdTonKho != "")
                sqlselect += " AND IdTonKho =" + sIdTonKho;
            if (sIdKho != null && sIdKho != "")
                sqlselect += " AND IdKho =" + sIdKho;
            if (sTuNgay != null && sTuNgay != "")
                sqlselect += " AND TuNgay LIKE '%" + sTuNgay + "%'";
            if (sDenNgay != null && sDenNgay != "")
                sqlselect += " AND DenNgay LIKE '%" + sDenNgay + "%'";
            if (sLoaiThuocID != null && sLoaiThuocID != "")
                sqlselect += " AND LoaiThuocID =" + sLoaiThuocID;
            if (sIdThuoc != null && sIdThuoc != "")
                sqlselect += " AND IdThuoc =" + sIdThuoc;
            if (sTenThuoc != null && sTenThuoc != "")
                sqlselect += " AND TenThuoc LIKE N'%" + sTenThuoc + "%'";
            if (sIsOrderByName != null && sIsOrderByName != "")
                sqlselect += " AND IsOrderByName =" + sIsOrderByName;
            if (sIsHaveDonGia != null && sIsHaveDonGia != "")
                sqlselect += " AND IsHaveDonGia =" + sIsHaveDonGia;
            if (sIsSoLuong != null && sIsSoLuong != "")
                sqlselect += " AND IsSoLuong =" + sIsSoLuong;
            if (sIsRutGon != null && sIsRutGon != "")
                sqlselect += " AND IsRutGon =" + sIsRutGon;
            sqlselect = sqlselect.Replace("WHERE AND", "WHERE");
            int n = sqlselect.IndexOf("WHERE");
            if (n == sqlselect.Length - 5) sqlselect = sqlselect.Remove(n, 5);
            return GetTable(sqlselect);
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public DataTable dtSearch()
        {
            if (this.page == null || this.page == "")
                this.page = "1";
            if (this.numberRow == null || this.numberRow == "")
                this.numberRow = "100";

            string sql = "select * from(" + this.SQLSelect() + ") abc where stt between (" + this.page + "-1)*" + this.numberRow + "+1 and " + this.page + " * " + this.numberRow;
            return GetTable(sql);

        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public string Paging()
        {
            int sumRow = GetTable(this.SQLSelect()).Rows.Count;

            if (this.page == null || this.page == "")
                this.page = "1";
            if (this.numberRow == null || this.numberRow == "")
                this.numberRow = "100";

            int sodongpaging = sumRow / int.Parse(this.numberRow);
            int sodongdu = sumRow % int.Parse(this.numberRow);
            if (sodongdu != 0)
            {
                sodongpaging = sodongpaging + 1;
            }
            string html = "";
            html += "<div style='padding-bottom:20px;width:90%;margin:auto;display:table'>";
            for (int i = 1; i <= sodongpaging; i++)
            {
                if (int.Parse(this.page) != i)
                {
                    html += "<a style='float:left;color:green;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"Find(this,'" + i + "')\">" + i + "</a>";
                }
                else
                {
                    html += "<span style='float:left;color:red'>" + i + "</span>";
                }
            }
            html += "</div>";
            return html;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static HS_TONKHO_View Insert_Object(
       string sIdTonKho
                   , string sIdKho
                   , string sTuNgay
                   , string sDenNgay
                   , string sLoaiThuocID
                   , string sIdThuoc
                   , string sTenThuoc
                   , string sIsOrderByName
                   , string sIsHaveDonGia
                   , string sIsSoLuong
                   , string sIsRutGon
                   )
        {
            string tem_sIdTonKho = DataAcess.hsSqlTool.sGetSaveValue(sIdTonKho, "bigint");
            string tem_sIdKho = DataAcess.hsSqlTool.sGetSaveValue(sIdKho, "bigint");
            string tem_sTuNgay = DataAcess.hsSqlTool.sGetSaveValue(sTuNgay, "datetime");
            string tem_sDenNgay = DataAcess.hsSqlTool.sGetSaveValue(sDenNgay, "datetime");
            string tem_sLoaiThuocID = DataAcess.hsSqlTool.sGetSaveValue(sLoaiThuocID, "bigint");
            string tem_sIdThuoc = DataAcess.hsSqlTool.sGetSaveValue(sIdThuoc, "bigint");
            string tem_sTenThuoc = DataAcess.hsSqlTool.sGetSaveValue(sTenThuoc, "nvarchar");
            string tem_sIsOrderByName = DataAcess.hsSqlTool.sGetSaveValue(sIsOrderByName, "bit");
            string tem_sIsHaveDonGia = DataAcess.hsSqlTool.sGetSaveValue(sIsHaveDonGia, "bit");
            string tem_sIsSoLuong = DataAcess.hsSqlTool.sGetSaveValue(sIsSoLuong, "bit");
            string tem_sIsRutGon = DataAcess.hsSqlTool.sGetSaveValue(sIsRutGon, "bit");

            string sqlSave = " INSERT INTO HS_TONKHO_View(" +
                  "IdTonKho,"
       + "IdKho,"
       + "TuNgay,"
       + "DenNgay,"
       + "LoaiThuocID,"
       + "IdThuoc,"
       + "TenThuoc,"
       + "IsOrderByName,"
       + "IsHaveDonGia,"
       + "IsSoLuong,"
       + "IsRutGon) VALUES("
+ tem_sIdTonKho + ","
+ tem_sIdKho + ","
+ tem_sTuNgay + ","
+ tem_sDenNgay + ","
+ tem_sLoaiThuocID + ","
+ tem_sIdThuoc + ","
+ tem_sTenThuoc + ","
+ tem_sIsOrderByName + ","
+ tem_sIsHaveDonGia + ","
+ tem_sIsSoLuong + ","
+ tem_sIsRutGon + ")";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                HS_TONKHO_View newHS_TONKHO_View = new HS_TONKHO_View();
                newHS_TONKHO_View.IdTonKho = sIdTonKho;
                newHS_TONKHO_View.IdKho = sIdKho;
                newHS_TONKHO_View.TuNgay = sTuNgay;
                newHS_TONKHO_View.DenNgay = sDenNgay;
                newHS_TONKHO_View.LoaiThuocID = sLoaiThuocID;
                newHS_TONKHO_View.IdThuoc = sIdThuoc;
                newHS_TONKHO_View.TenThuoc = sTenThuoc;
                newHS_TONKHO_View.IsOrderByName = sIsOrderByName;
                newHS_TONKHO_View.IsHaveDonGia = sIsHaveDonGia;
                newHS_TONKHO_View.IsSoLuong = sIsSoLuong;
                newHS_TONKHO_View.IsRutGon = sIsRutGon;
                return newHS_TONKHO_View;
            }
            else return null;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public HS_TONKHO_View Insert_Object()
        {
            string tem_sIdTonKho = (GetTable(" SELECT IdTonKho FROM HS_TONKHO_View").Rows.Count + 1) + "";
            string tem_sIdKho = DataAcess.hsSqlTool.sGetSaveValue(this.IdKho, "bigint");
            string tem_sTuNgay = DataAcess.hsSqlTool.sGetSaveValue(this.TuNgay, "datetime");
            string tem_sDenNgay = DataAcess.hsSqlTool.sGetSaveValue(this.DenNgay, "datetime");
            string tem_sLoaiThuocID = DataAcess.hsSqlTool.sGetSaveValue(this.LoaiThuocID, "bigint");
            string tem_sIdThuoc = DataAcess.hsSqlTool.sGetSaveValue(this.IdThuoc, "bigint");
            string tem_sTenThuoc = DataAcess.hsSqlTool.sGetSaveValue(this.TenThuoc, "nvarchar");
            string tem_sIsOrderByName = DataAcess.hsSqlTool.sGetSaveValue(this.IsOrderByName, "bit");
            string tem_sIsHaveDonGia = DataAcess.hsSqlTool.sGetSaveValue(this.IsHaveDonGia, "bit");
            string tem_sIsSoLuong = DataAcess.hsSqlTool.sGetSaveValue(this.IsSoLuong, "bit");
            string tem_sIsRutGon = DataAcess.hsSqlTool.sGetSaveValue(this.IsRutGon, "bit");

            string sqlSave = " INSERT INTO HS_TONKHO_View(" +
                  "IdTonKho,"
       + "IdKho,"
       + "TuNgay,"
       + "DenNgay,"
       + "LoaiThuocID,"
       + "IdThuoc,"
       + "TenThuoc,"
       + "IsOrderByName,"
       + "IsHaveDonGia,"
       + "IsSoLuong,"
       + "IsRutGon) VALUES("
+ tem_sIdTonKho + ","
+ tem_sIdKho + ","
+ tem_sTuNgay + ","
+ tem_sDenNgay + ","
+ tem_sLoaiThuocID + ","
+ tem_sIdThuoc + ","
+ tem_sTenThuoc + ","
+ tem_sIsOrderByName + ","
+ tem_sIsHaveDonGia + ","
+ tem_sIsSoLuong + ","
+ tem_sIsRutGon + ")";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                HS_TONKHO_View newHS_TONKHO_View = new HS_TONKHO_View();
                newHS_TONKHO_View.IdTonKho = this.IdTonKho;
                newHS_TONKHO_View.IdKho = this.IdKho;
                newHS_TONKHO_View.TuNgay = this.TuNgay;
                newHS_TONKHO_View.DenNgay = this.DenNgay;
                newHS_TONKHO_View.LoaiThuocID = this.LoaiThuocID;
                newHS_TONKHO_View.IdThuoc = this.IdThuoc;
                newHS_TONKHO_View.TenThuoc = this.TenThuoc;
                newHS_TONKHO_View.IsOrderByName = this.IsOrderByName;
                newHS_TONKHO_View.IsHaveDonGia = this.IsHaveDonGia;
                newHS_TONKHO_View.IsSoLuong = this.IsSoLuong;
                newHS_TONKHO_View.IsRutGon = this.IsRutGon;
                return newHS_TONKHO_View;
            }
            else return null;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Save_Object(string sIdTonKho
                        , string sIdKho
                        , string sTuNgay
                        , string sDenNgay
                        , string sLoaiThuocID
                        , string sIdThuoc
                        , string sTenThuoc
                        , string sIsOrderByName
                        , string sIsHaveDonGia
                        , string sIsSoLuong
                        , string sIsRutGon
                        )
        {
            string tem_sIdKho = DataAcess.hsSqlTool.sGetSaveValue(sIdKho, "bigint");
            string tem_sTuNgay = DataAcess.hsSqlTool.sGetSaveValue(sTuNgay, "datetime");
            string tem_sDenNgay = DataAcess.hsSqlTool.sGetSaveValue(sDenNgay, "datetime");
            string tem_sLoaiThuocID = DataAcess.hsSqlTool.sGetSaveValue(sLoaiThuocID, "bigint");
            string tem_sIdThuoc = DataAcess.hsSqlTool.sGetSaveValue(sIdThuoc, "bigint");
            string tem_sTenThuoc = DataAcess.hsSqlTool.sGetSaveValue(sTenThuoc, "nvarchar");
            string tem_sIsOrderByName = DataAcess.hsSqlTool.sGetSaveValue(sIsOrderByName, "bit");
            string tem_sIsHaveDonGia = DataAcess.hsSqlTool.sGetSaveValue(sIsHaveDonGia, "bit");
            string tem_sIsSoLuong = DataAcess.hsSqlTool.sGetSaveValue(sIsSoLuong, "bit");
            string tem_sIsRutGon = DataAcess.hsSqlTool.sGetSaveValue(sIsRutGon, "bit");

            string sqlSave = " UPDATE HS_TONKHO_View SET " + "IdKho =" + tem_sIdKho + ","
            + "TuNgay =" + tem_sTuNgay + ","
            + "DenNgay =" + tem_sDenNgay + ","
            + "LoaiThuocID =" + tem_sLoaiThuocID + ","
            + "IdThuoc =" + tem_sIdThuoc + ","
            + "TenThuoc =" + tem_sTenThuoc + ","
            + "IsOrderByName =" + tem_sIsOrderByName + ","
            + "IsHaveDonGia =" + tem_sIsHaveDonGia + ","
            + "IsSoLuong =" + tem_sIsSoLuong + ","
            + "IsRutGon =" + tem_sIsRutGon + " WHERE IdTonKho=" + DataAcess.hsSqlTool.sGetSaveValue(this.IdTonKho, "bigint"); ;
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.IdKho = sIdKho;
                this.TuNgay = sTuNgay;
                this.DenNgay = sDenNgay;
                this.LoaiThuocID = sLoaiThuocID;
                this.IdThuoc = sIdThuoc;
                this.TenThuoc = sTenThuoc;
                this.IsOrderByName = sIsOrderByName;
                this.IsHaveDonGia = sIsHaveDonGia;
                this.IsSoLuong = sIsSoLuong;
                this.IsRutGon = sIsRutGon;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Save_Object()
        {
            string tem_sIdKho = DataAcess.hsSqlTool.sGetSaveValue(this.IdKho, "bigint");
            string tem_sTuNgay = DataAcess.hsSqlTool.sGetSaveValue(this.TuNgay, "datetime");
            string tem_sDenNgay = DataAcess.hsSqlTool.sGetSaveValue(this.DenNgay, "datetime");
            string tem_sLoaiThuocID = DataAcess.hsSqlTool.sGetSaveValue(this.LoaiThuocID, "bigint");
            string tem_sIdThuoc = DataAcess.hsSqlTool.sGetSaveValue(this.IdThuoc, "bigint");
            string tem_sTenThuoc = DataAcess.hsSqlTool.sGetSaveValue(this.TenThuoc, "nvarchar");
            string tem_sIsOrderByName = DataAcess.hsSqlTool.sGetSaveValue(this.IsOrderByName, "bit");
            string tem_sIsHaveDonGia = DataAcess.hsSqlTool.sGetSaveValue(this.IsHaveDonGia, "bit");
            string tem_sIsSoLuong = DataAcess.hsSqlTool.sGetSaveValue(this.IsSoLuong, "bit");
            string tem_sIsRutGon = DataAcess.hsSqlTool.sGetSaveValue(this.IsRutGon, "bit");

            string sqlSave = " UPDATE HS_TONKHO_View SET ";
            if (tem_sIdKho != null)
                sqlSave += "IdKho =" + tem_sIdKho + ",";
            if (tem_sTuNgay != null)
                sqlSave += "TuNgay =" + tem_sTuNgay + ",";
            if (tem_sDenNgay != null)
                sqlSave += "DenNgay =" + tem_sDenNgay + ",";
            if (tem_sLoaiThuocID != null)
                sqlSave += "LoaiThuocID =" + tem_sLoaiThuocID + ",";
            if (tem_sIdThuoc != null)
                sqlSave += "IdThuoc =" + tem_sIdThuoc + ",";
            if (tem_sTenThuoc != null)
                sqlSave += "TenThuoc =" + tem_sTenThuoc + ",";
            if (tem_sIsOrderByName != null)
                sqlSave += "IsOrderByName =" + tem_sIsOrderByName + ",";
            if (tem_sIsHaveDonGia != null)
                sqlSave += "IsHaveDonGia =" + tem_sIsHaveDonGia + ",";
            if (tem_sIsSoLuong != null)
                sqlSave += "IsSoLuong =" + tem_sIsSoLuong + ",";
            if (tem_sIsRutGon != null)
                sqlSave += "IsRutGon =" + tem_sIsRutGon + ",";
            sqlSave += " WHERE IdTonKho=" + DataAcess.hsSqlTool.sGetSaveValue(this.IdTonKho, "bigint"); ;
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        #region Update DataColumn
        public bool Update_IdTonKho(string sIdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IdTonKho='" + sIdTonKho + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.IdTonKho = sIdTonKho;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_IdKho(string sIdKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IdKho='" + sIdKho + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.IdKho = sIdKho;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_TuNgay(string sTuNgay)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET TuNgay='" + sTuNgay + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.TuNgay = sTuNgay;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_DenNgay(string sDenNgay)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET DenNgay='" + sDenNgay + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.DenNgay = sDenNgay;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_LoaiThuocID(string sLoaiThuocID)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET LoaiThuocID='" + sLoaiThuocID + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.LoaiThuocID = sLoaiThuocID;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_IdThuoc(string sIdThuoc)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IdThuoc='" + sIdThuoc + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.IdThuoc = sIdThuoc;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_TenThuoc(string sTenThuoc)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET TenThuoc='N" + sTenThuoc + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.TenThuoc = sTenThuoc;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_IsOrderByName(string sIsOrderByName)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IsOrderByName='" + sIsOrderByName + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.IsOrderByName = sIsOrderByName;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_IsHaveDonGia(string sIsHaveDonGia)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IsHaveDonGia='" + sIsHaveDonGia + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.IsHaveDonGia = sIsHaveDonGia;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_IsSoLuong(string sIsSoLuong)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IsSoLuong='" + sIsSoLuong + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.IsSoLuong = sIsSoLuong;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_IsRutGon(string sIsRutGon)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IsRutGon='" + sIsRutGon + "' WHERE IdTonKho='" + this.IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                this.IsRutGon = sIsRutGon;
            }
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        #endregion
        #region Update DataColumn  Static
        public static bool Update_IdTonKho(string sIdTonKho, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IdTonKho='" + sIdTonKho + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_IdKho(string sIdKho, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IdKho='" + sIdKho + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_TuNgay(string sTuNgay, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET TuNgay='" + sTuNgay + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_DenNgay(string sDenNgay, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET DenNgay='" + sDenNgay + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_LoaiThuocID(string sLoaiThuocID, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET LoaiThuocID='" + sLoaiThuocID + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_IdThuoc(string sIdThuoc, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IdThuoc='" + sIdThuoc + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_TenThuoc(string sTenThuoc, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET TenThuoc='N" + sTenThuoc + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_IsOrderByName(string sIsOrderByName, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IsOrderByName='" + sIsOrderByName + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_IsHaveDonGia(string sIsHaveDonGia, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IsHaveDonGia='" + sIsHaveDonGia + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_IsSoLuong(string sIsSoLuong, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IsSoLuong='" + sIsSoLuong + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_IsRutGon(string sIsRutGon, string s_IdTonKho)
        {
            string sqlSave = " UPDATE HS_TONKHO_View SET IsRutGon='" + sIsRutGon + "' WHERE IdTonKho='" + s_IdTonKho + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        //───────────────────────────────────────────────────────────────────────────────────────
        #endregion
        public static DataTable dtGetAll()
        {
            string sqlSelect = " SELECT * FROM HS_TONKHO_View ";
            return GetTable(sqlSelect);
        }
        //───────────────────────────────────────────────────────────────────────────────────────
        private static DataTable dt_HS_TONKHO_View;
        public static bool Change_dt_HS_TONKHO_View = true;
        public static bool AllowAutoChange = true;
        public static DataTable get_HS_TONKHO_View()
        {
            if (dt_HS_TONKHO_View == null || Change_dt_HS_TONKHO_View == true)
            {
                dt_HS_TONKHO_View = dtGetAll();
                Change_dt_HS_TONKHO_View = true && AllowAutoChange;
            }
            return dt_HS_TONKHO_View;
        }
        //───────────────────────────────────────────────────────────────────────────────────────
    }
}

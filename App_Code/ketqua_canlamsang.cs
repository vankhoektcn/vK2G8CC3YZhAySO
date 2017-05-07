namespace Process_cls
{
    using DataAcess;
    using System;
    using System.Data;

    public class ketqua_canlamsang : Connect
    {
        public static bool AllowAutoChange = true;
        public static bool Change_dt_ketqua_canlamsang = true;
        public static string cl_idbenhnhan = "idbenhnhan";
        public static string cl_idbenhnhan_VN = "idbenhnhan";
        public static string cl_idketqua_canlamsang = "idketqua_canlamsang";
        public static string cl_idketqua_canlamsang_VN = "idketqua_canlamsang";
        public static string cl_idkhambenh = "idkhambenh";
        public static string cl_idkhambenh_VN = "idkhambenh";
        public static string cl_madangkycls = "madangkycls";
        public static string cl_madangkycls_VN = "madangkycls";
        private static DataTable dt_ketqua_canlamsang;
        public string idbenhnhan;
        public string idketqua_canlamsang;
        public string idkhambenh;
        public string madangkycls;
        public string numberRow;
        public string page;
        public static string sTableName = "ketqua_canlamsang";

        public ketqua_canlamsang()
        {
        }

        public ketqua_canlamsang(DataView dv, int pos)
        {
            this.idketqua_canlamsang = dv[pos][0].ToString();
            this.madangkycls = dv[pos][1].ToString();
            this.idbenhnhan = dv[pos][2].ToString();
            this.idkhambenh = dv[pos][3].ToString();
        }

        public ketqua_canlamsang(string sidketqua_canlamsang, string smadangkycls, string sidbenhnhan, string sidkhambenh)
        {
            this.idketqua_canlamsang = sidketqua_canlamsang;
            this.madangkycls = smadangkycls;
            this.idbenhnhan = sidbenhnhan;
            this.idkhambenh = sidkhambenh;
        }

        public static ketqua_canlamsang Create_ketqua_canlamsang(string sidketqua_canlamsang)
        {
            DataTable table = dtSearchByidketqua_canlamsang(sidketqua_canlamsang);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return new ketqua_canlamsang(table.DefaultView, 0);
            }
            return null;
        }

        public static DataTable dtGetAll()
        {
            string strSelect = " SELECT * FROM ketqua_canlamsang ";
            return Connect.GetTable(strSelect);
        }

        public DataTable dtSearch()
        {
            if ((this.page == null) || (this.page == ""))
            {
                this.page = "1";
            }
            if ((this.numberRow == null) || (this.numberRow == ""))
            {
                this.numberRow = "100";
            }
            return Connect.GetTable("select * from(" + this.SQLSelect() + ") abc where stt between (" + this.page + "-1)*" + this.numberRow + "+1 and " + this.page + " * " + this.numberRow);
        }

        public static DataTable dtSearch(string sidketqua_canlamsang, string smadangkycls, string sidbenhnhan, string sidkhambenh)
        {
            string strSelect = s_Select() + " WHERE";
            if ((sidketqua_canlamsang != null) && (sidketqua_canlamsang != ""))
            {
                strSelect = strSelect + " AND idketqua_canlamsang =" + sidketqua_canlamsang;
            }
            if ((smadangkycls != null) && (smadangkycls != ""))
            {
                strSelect = strSelect + " AND madangkycls LIKE N'%" + smadangkycls + "%'";
            }
            if ((sidbenhnhan != null) && (sidbenhnhan != ""))
            {
                strSelect = strSelect + " AND idbenhnhan =" + sidbenhnhan;
            }
            if ((sidkhambenh != null) && (sidkhambenh != ""))
            {
                strSelect = strSelect + " AND idkhambenh =" + sidkhambenh;
            }
            strSelect = strSelect.Replace("WHERE AND", "WHERE");
            int index = strSelect.IndexOf("WHERE");
            if (index == (strSelect.Length - 5))
            {
                strSelect = strSelect.Remove(index, 5);
            }
            return Connect.GetTable(strSelect);
        }

        public static DataTable dtSearchByidbenhnhan(string sidbenhnhan)
        {
            return Connect.GetTable(s_Select() + " WHERE idbenhnhan  =" + sidbenhnhan + "");
        }

        public static DataTable dtSearchByidbenhnhan(string sidbenhnhan, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE idbenhnhan" + sMatch + sidbenhnhan + "");
        }

        public static DataTable dtSearchByidketqua_canlamsang(string sidketqua_canlamsang)
        {
            return Connect.GetTable(s_Select() + " WHERE idketqua_canlamsang  =" + sidketqua_canlamsang + "");
        }

        public static DataTable dtSearchByidketqua_canlamsang(string sidketqua_canlamsang, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE idketqua_canlamsang" + sMatch + sidketqua_canlamsang + "");
        }

        public static DataTable dtSearchByidkhambenh(string sidkhambenh)
        {
            return Connect.GetTable(s_Select() + " WHERE idkhambenh  =" + sidkhambenh + "");
        }

        public static DataTable dtSearchByidkhambenh(string sidkhambenh, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE idkhambenh" + sMatch + sidkhambenh + "");
        }

        public static DataTable dtSearchBymadangkycls(string smadangkycls)
        {
            return Connect.GetTable(s_Select() + " WHERE madangkycls  Like N'%" + smadangkycls + "%'");
        }

        public static DataTable get_ketqua_canlamsang()
        {
            if ((dt_ketqua_canlamsang == null) || Change_dt_ketqua_canlamsang)
            {
                dt_ketqua_canlamsang = dtGetAll();
                Change_dt_ketqua_canlamsang = AllowAutoChange;
            }
            return dt_ketqua_canlamsang;
        }

        public ketqua_canlamsang Insert_Object()
        {
            string str = hsSqlTool.sGetSaveValue(this.madangkycls, "varchar");
            string str2 = hsSqlTool.sGetSaveValue(this.idbenhnhan, "bigint");
            string str3 = hsSqlTool.sGetSaveValue(this.idkhambenh, "bigint");
            if (Connect.Exec(" INSERT INTO ketqua_canlamsang(madangkycls,idbenhnhan,idkhambenh) VALUES(" + str + "," + str2 + "," + str3 + ")") == 1)
            {
                ketqua_canlamsang _canlamsang = new ketqua_canlamsang();
                _canlamsang.idketqua_canlamsang = Connect.GetTable(" SELECT TOP 1 idketqua_canlamsang FROM ketqua_canlamsang ORDER BY idketqua_canlamsang DESC ").Rows[0][0].ToString();
                _canlamsang.madangkycls = this.madangkycls;
                _canlamsang.idbenhnhan = this.idbenhnhan;
                _canlamsang.idkhambenh = this.idkhambenh;
                return _canlamsang;
            }
            return null;
        }

        public static ketqua_canlamsang Insert_Object(string smadangkycls, string sidbenhnhan, string sidkhambenh)
        {
            string str = hsSqlTool.sGetSaveValue(smadangkycls, "varchar");
            string str2 = hsSqlTool.sGetSaveValue(sidbenhnhan, "bigint");
            string str3 = hsSqlTool.sGetSaveValue(sidkhambenh, "bigint");
            if (Connect.Exec(" INSERT INTO ketqua_canlamsang(madangkycls,idbenhnhan,idkhambenh) VALUES(" + str + "," + str2 + "," + str3 + ")") == 1)
            {
                ketqua_canlamsang _canlamsang = new ketqua_canlamsang();
                _canlamsang.idketqua_canlamsang = Connect.GetTable(" SELECT TOP 1 idketqua_canlamsang FROM ketqua_canlamsang ORDER BY idketqua_canlamsang DESC ").Rows[0][0].ToString();
                _canlamsang.madangkycls = smadangkycls;
                _canlamsang.idbenhnhan = sidbenhnhan;
                _canlamsang.idkhambenh = sidkhambenh;
                return _canlamsang;
            }
            return null;
        }

        public string Paging()
        {
            int count = Connect.GetTable(this.SQLSelect()).Rows.Count;
            if ((this.page == null) || (this.page == ""))
            {
                this.page = "1";
            }
            if ((this.numberRow == null) || (this.numberRow == ""))
            {
                this.numberRow = "100";
            }
            int num2 = count / int.Parse(this.numberRow);
            int num3 = count % int.Parse(this.numberRow);
            if (num3 != 0)
            {
                num2++;
            }
            string str = "";
            str = str + "<div style='padding-bottom:20px;width:90%;margin:auto;display:table'>";
            for (int i = 1; i <= num2; i++)
            {
                object obj2;
                if (int.Parse(this.page) != i)
                {
                    obj2 = str;
                    str = string.Concat(new object[] { obj2, "<a style='float:left;color:green;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"Find(this,'", i, "')\">", i, "</a>" });
                }
                else
                {
                    obj2 = str;
                    str = string.Concat(new object[] { obj2, "<span style='float:left;color:red'>", i, "</span>" });
                }
            }
            return (str + "</div>");
        }

        private static string s_Select()
        {
            return " SELECT T.* FROM ketqua_canlamsang AS T";
        }

        public bool Save_Object()
        {
            string str = hsSqlTool.sGetSaveValue(this.madangkycls, "varchar");
            string str2 = hsSqlTool.sGetSaveValue(this.idbenhnhan, "bigint");
            string str3 = hsSqlTool.sGetSaveValue(this.idkhambenh, "bigint");
            string str4 = " UPDATE ketqua_canlamsang SET ";
            if (str != null)
            {
                str4 = str4 + "madangkycls =" + str + ",";
            }
            if (str2 != null)
            {
                str4 = str4 + "idbenhnhan =" + str2 + ",";
            }
            if (str3 != null)
            {
                str4 = str4 + "idkhambenh =" + str3 + ",";
            }
            return (Connect.Exec(str4 + " WHERE idketqua_canlamsang=" + hsSqlTool.sGetSaveValue(this.idketqua_canlamsang, "bigint identity")) == 1);
        }

        public bool Save_Object(string smadangkycls, string sidbenhnhan, string sidkhambenh)
        {
            string str = hsSqlTool.sGetSaveValue(smadangkycls, "varchar");
            string str2 = hsSqlTool.sGetSaveValue(sidbenhnhan, "bigint");
            string str3 = hsSqlTool.sGetSaveValue(sidkhambenh, "bigint");
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsang SET madangkycls =" + str + ",idbenhnhan =" + str2 + ",idkhambenh =" + str3 + " WHERE idketqua_canlamsang=" + hsSqlTool.sGetSaveValue(this.idketqua_canlamsang, "bigint identity")) == 1;
            if (flag)
            {
                this.madangkycls = smadangkycls;
                this.idbenhnhan = sidbenhnhan;
                this.idkhambenh = sidkhambenh;
            }
            return flag;
        }

        private string SQLSelect()
        {
            string str = " SELECT stt= row_number() over (order by idketqua_canlamsang),T.* FROM ketqua_canlamsang AS T WHERE";
            if ((this.madangkycls != null) && (this.madangkycls != ""))
            {
                str = str + " AND madangkycls LIKE N'%" + this.madangkycls + "%'";
            }
            if ((((this.idbenhnhan != null) && (this.idbenhnhan != "")) && (this.idbenhnhan != "0")) && (this.idbenhnhan != "0.0"))
            {
                str = str + " AND idbenhnhan =" + this.idbenhnhan;
            }
            if ((((this.idkhambenh != null) && (this.idkhambenh != "")) && (this.idkhambenh != "0")) && (this.idkhambenh != "0.0"))
            {
                str = str + " AND idkhambenh =" + this.idkhambenh;
            }
            str = str.Replace("WHERE AND", "WHERE");
            int index = str.IndexOf("WHERE");
            if (index == (str.Length - 5))
            {
                str = str.Remove(index, 5);
            }
            return str;
        }

        public bool Update_idbenhnhan(string sidbenhnhan)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsang SET idbenhnhan='" + sidbenhnhan + "' WHERE idketqua_canlamsang='" + this.idketqua_canlamsang + "' ") == 1;
            if (flag)
            {
                this.idbenhnhan = sidbenhnhan;
            }
            return flag;
        }

        public static bool Update_idbenhnhan(string sidbenhnhan, string s_idketqua_canlamsang)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsang SET idbenhnhan='" + sidbenhnhan + "' WHERE idketqua_canlamsang='" + s_idketqua_canlamsang + "' ") == 1);
        }

        public bool Update_idketqua_canlamsang(string sidketqua_canlamsang)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsang SET idketqua_canlamsang='" + sidketqua_canlamsang + "' WHERE idketqua_canlamsang='" + this.idketqua_canlamsang + "' ") == 1;
            if (flag)
            {
                this.idketqua_canlamsang = sidketqua_canlamsang;
            }
            return flag;
        }

        public bool Update_idkhambenh(string sidkhambenh)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsang SET idkhambenh='" + sidkhambenh + "' WHERE idketqua_canlamsang='" + this.idketqua_canlamsang + "' ") == 1;
            if (flag)
            {
                this.idkhambenh = sidkhambenh;
            }
            return flag;
        }

        public static bool Update_idkhambenh(string sidkhambenh, string s_idketqua_canlamsang)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsang SET idkhambenh='" + sidkhambenh + "' WHERE idketqua_canlamsang='" + s_idketqua_canlamsang + "' ") == 1);
        }

        public bool Update_madangkycls(string smadangkycls)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsang SET madangkycls='N" + smadangkycls + "' WHERE idketqua_canlamsang='" + this.idketqua_canlamsang + "' ") == 1;
            if (flag)
            {
                this.madangkycls = smadangkycls;
            }
            return flag;
        }

        public static bool Update_madangkycls(string smadangkycls, string s_idketqua_canlamsang)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsang SET madangkycls='N" + smadangkycls + "' WHERE idketqua_canlamsang='" + s_idketqua_canlamsang + "' ") == 1);
        }
    }
}


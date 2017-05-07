namespace Process_cls
{
    using DataAcess;
    using System;
    using System.Data;

    public class ketqua_canlamsangchitiet : Connect
    {
        public static bool AllowAutoChange = true;
        public static bool Change_dt_ketqua_canlamsangchitiet = true;
        public static string cl_giatribinhthuong = "giatribinhthuong";
        public static string cl_giatribinhthuong_VN = "giatribinhthuong";
        public static string cl_idbanggiadichvu = "idbanggiadichvu";
        public static string cl_idbanggiadichvu_VN = "idbanggiadichvu";
        public static string cl_idbbscls = "idbbscls";
        public static string cl_idbbscls_VN = "idbbscls";
        public static string cl_idchitietdichvu = "idchitietdichvu";
        public static string cl_idchitietdichvu_VN = "idchitietdichvu";
        public static string cl_idketqua_canlamsang = "idketqua_canlamsang";
        public static string cl_idketqua_canlamsang_VN = "idketqua_canlamsang";
        public static string cl_idketqua_canlamsangchitiet = "idketqua_canlamsangchitiet";
        public static string cl_idketqua_canlamsangchitiet_VN = "idketqua_canlamsangchitiet";
        public static string cl_isBatThuong = "isBatThuong";
        public static string cl_isBatThuong_VN = "isBatThuong";
        public static string cl_ketqua = "ketqua";
        public static string cl_ketqua_VN = "ketqua";
        public static string cl_ketquacdha = "ketquacdha";
        public static string cl_ketquacdha_VN = "ketquacdha";
        public static string cl_ngaycls = "ngaycls";
        public static string cl_ngaycls_VN = "ngaycls";
        private static DataTable dt_ketqua_canlamsangchitiet;
        public string giatribinhthuong;
        public string idbanggiadichvu;
        public string idbbscls;
        public string idchitietdichvu;
        public string idketqua_canlamsang;
        public string idketqua_canlamsangchitiet;
        public string isBatThuong;
        public string ketqua;
        public string ketquacdha;
        public string ngaycls;
        public string numberRow;
        public string page;
        public static string sTableName = "ketqua_canlamsangchitiet";

        public ketqua_canlamsangchitiet()
        {
        }

        public ketqua_canlamsangchitiet(DataView dv, int pos)
        {
            this.idketqua_canlamsangchitiet = dv[pos][0].ToString();
            this.idketqua_canlamsang = dv[pos][1].ToString();
            this.idbanggiadichvu = dv[pos][2].ToString();
            this.idchitietdichvu = dv[pos][3].ToString();
            this.ketqua = dv[pos][4].ToString();
            this.isBatThuong = dv[pos][5].ToString();
            this.ngaycls = dv[pos][6].ToString();
            this.idbbscls = dv[pos][7].ToString();
            this.ketquacdha = dv[pos][8].ToString();
            this.giatribinhthuong = dv[pos][9].ToString();
        }

        public ketqua_canlamsangchitiet(string sidketqua_canlamsangchitiet, string sidketqua_canlamsang, string sidbanggiadichvu, string sidchitietdichvu, string sketqua, string sisBatThuong, string sngaycls, string sidbbscls, string sketquacdha, string sgiatribinhthuong)
        {
            this.idketqua_canlamsangchitiet = sidketqua_canlamsangchitiet;
            this.idketqua_canlamsang = sidketqua_canlamsang;
            this.idbanggiadichvu = sidbanggiadichvu;
            this.idchitietdichvu = sidchitietdichvu;
            this.ketqua = sketqua;
            this.isBatThuong = sisBatThuong;
            this.ngaycls = sngaycls;
            this.idbbscls = sidbbscls;
            this.ketquacdha = sketquacdha;
            this.giatribinhthuong = sgiatribinhthuong;
        }

        public static ketqua_canlamsangchitiet Create_ketqua_canlamsangchitiet(string sidketqua_canlamsangchitiet)
        {
            DataTable table = dtSearchByidketqua_canlamsangchitiet(sidketqua_canlamsangchitiet);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return new ketqua_canlamsangchitiet(table.DefaultView, 0);
            }
            return null;
        }

        public static DataTable dtGetAll()
        {
            string strSelect = " SELECT * FROM ketqua_canlamsangchitiet ";
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

        public static DataTable dtSearch(string sidketqua_canlamsangchitiet, string sidketqua_canlamsang, string sidbanggiadichvu, string sidchitietdichvu, string sketqua, string sisBatThuong, string sngaycls, string sidbbscls, string sketquacdha, string sgiatribinhthuong)
        {
            string strSelect = s_Select() + " WHERE";
            if ((sidketqua_canlamsangchitiet != null) && (sidketqua_canlamsangchitiet != ""))
            {
                strSelect = strSelect + " AND idketqua_canlamsangchitiet =" + sidketqua_canlamsangchitiet;
            }
            if ((sidketqua_canlamsang != null) && (sidketqua_canlamsang != ""))
            {
                strSelect = strSelect + " AND idketqua_canlamsang =" + sidketqua_canlamsang;
            }
            if ((sidbanggiadichvu != null) && (sidbanggiadichvu != ""))
            {
                strSelect = strSelect + " AND idbanggiadichvu =" + sidbanggiadichvu;
            }
            if ((sidchitietdichvu != null) && (sidchitietdichvu != ""))
            {
                strSelect = strSelect + " AND idchitietdichvu =" + sidchitietdichvu;
            }
            if ((sketqua != null) && (sketqua != ""))
            {
                strSelect = strSelect + " AND ketqua LIKE N'%" + sketqua + "%'";
            }
            if ((sisBatThuong != null) && (sisBatThuong != ""))
            {
                strSelect = strSelect + " AND isBatThuong =" + sisBatThuong;
            }
            if ((sngaycls != null) && (sngaycls != ""))
            {
                strSelect = strSelect + " AND ngaycls LIKE '%" + sngaycls + "%'";
            }
            if ((sidbbscls != null) && (sidbbscls != ""))
            {
                strSelect = strSelect + " AND idbbscls =" + sidbbscls;
            }
            if ((sketquacdha != null) && (sketquacdha != ""))
            {
                strSelect = strSelect + " AND ketquacdha LIKE '%" + sketquacdha + "%'";
            }
            if ((sgiatribinhthuong != null) && (sgiatribinhthuong != ""))
            {
                strSelect = strSelect + " AND giatribinhthuong LIKE N'%" + sgiatribinhthuong + "%'";
            }
            strSelect = strSelect.Replace("WHERE AND", "WHERE");
            int index = strSelect.IndexOf("WHERE");
            if (index == (strSelect.Length - 5))
            {
                strSelect = strSelect.Remove(index, 5);
            }
            return Connect.GetTable(strSelect);
        }

        public static DataTable dtSearchBygiatribinhthuong(string sgiatribinhthuong)
        {
            return Connect.GetTable(s_Select() + " WHERE giatribinhthuong  Like N'%" + sgiatribinhthuong + "%'");
        }

        public static DataTable dtSearchByidbanggiadichvu(string sidbanggiadichvu)
        {
            return Connect.GetTable(s_Select() + " WHERE idbanggiadichvu  =" + sidbanggiadichvu + "");
        }

        public static DataTable dtSearchByidbanggiadichvu(string sidbanggiadichvu, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE idbanggiadichvu" + sMatch + sidbanggiadichvu + "");
        }

        public static DataTable dtSearchByidbbscls(string sidbbscls)
        {
            return Connect.GetTable(s_Select() + " WHERE idbbscls  =" + sidbbscls + "");
        }

        public static DataTable dtSearchByidbbscls(string sidbbscls, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE idbbscls" + sMatch + sidbbscls + "");
        }

        public static DataTable dtSearchByidchitietdichvu(string sidchitietdichvu)
        {
            return Connect.GetTable(s_Select() + " WHERE idchitietdichvu  =" + sidchitietdichvu + "");
        }

        public static DataTable dtSearchByidchitietdichvu(string sidchitietdichvu, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE idchitietdichvu" + sMatch + sidchitietdichvu + "");
        }

        public static DataTable dtSearchByidketqua_canlamsang(string sidketqua_canlamsang)
        {
            return Connect.GetTable(s_Select() + " WHERE idketqua_canlamsang  =" + sidketqua_canlamsang + "");
        }

        public static DataTable dtSearchByidketqua_canlamsang(string sidketqua_canlamsang, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE idketqua_canlamsang" + sMatch + sidketqua_canlamsang + "");
        }

        public static DataTable dtSearchByidketqua_canlamsangchitiet(string sidketqua_canlamsangchitiet)
        {
            return Connect.GetTable(s_Select() + " WHERE idketqua_canlamsangchitiet  =" + sidketqua_canlamsangchitiet + "");
        }

        public static DataTable dtSearchByidketqua_canlamsangchitiet(string sidketqua_canlamsangchitiet, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE idketqua_canlamsangchitiet" + sMatch + sidketqua_canlamsangchitiet + "");
        }

        public static DataTable dtSearchByisBatThuong(string sisBatThuong)
        {
            return Connect.GetTable(s_Select() + " WHERE isBatThuong  =" + sisBatThuong + "");
        }

        public static DataTable dtSearchByisBatThuong(string sisBatThuong, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE isBatThuong" + sMatch + sisBatThuong + "");
        }

        public static DataTable dtSearchByketqua(string sketqua)
        {
            return Connect.GetTable(s_Select() + " WHERE ketqua  Like N'%" + sketqua + "%'");
        }

        public static DataTable dtSearchByketquacdha(string sketquacdha)
        {
            return Connect.GetTable(s_Select() + " WHERE ketquacdha  Like '%" + sketquacdha + "%'");
        }

        public static DataTable dtSearchByngaycls(string sngaycls)
        {
            return Connect.GetTable(s_Select() + " WHERE ngaycls  =" + sngaycls + "");
        }

        public static DataTable dtSearchByngaycls(string sngaycls, string sMatch)
        {
            return Connect.GetTable(s_Select() + " WHERE ngaycls" + sMatch + sngaycls + "");
        }

        public static DataTable get_ketqua_canlamsangchitiet()
        {
            if ((dt_ketqua_canlamsangchitiet == null) || Change_dt_ketqua_canlamsangchitiet)
            {
                dt_ketqua_canlamsangchitiet = dtGetAll();
                Change_dt_ketqua_canlamsangchitiet = AllowAutoChange;
            }
            return dt_ketqua_canlamsangchitiet;
        }

        public ketqua_canlamsangchitiet Insert_Object()
        {
            string str = hsSqlTool.sGetSaveValue(this.idketqua_canlamsang, "bigint");
            string str2 = hsSqlTool.sGetSaveValue(this.idbanggiadichvu, "bigint");
            string str3 = hsSqlTool.sGetSaveValue(this.idchitietdichvu, "bigint");
            string str4 = hsSqlTool.sGetSaveValue(this.ketqua, "nvarchar");
            string str5 = hsSqlTool.sGetSaveValue(this.isBatThuong, "bit");
            string str6 = hsSqlTool.sGetSaveValue(this.ngaycls, "datetime");
            string str7 = hsSqlTool.sGetSaveValue(this.idbbscls, "bigint");
            string str8 = hsSqlTool.sGetSaveValue(this.ketquacdha, "varbinary");
            string str9 = hsSqlTool.sGetSaveValue(this.giatribinhthuong, "nvarchar");
            if (Connect.Exec(" INSERT INTO ketqua_canlamsangchitiet(idketqua_canlamsang,idbanggiadichvu,idchitietdichvu,ketqua,isBatThuong,ngaycls,idbbscls,ketquacdha,giatribinhthuong) VALUES(" + str + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + ")") == 1)
            {
                ketqua_canlamsangchitiet _canlamsangchitiet = new ketqua_canlamsangchitiet();
                _canlamsangchitiet.idketqua_canlamsangchitiet = Connect.GetTable(" SELECT TOP 1 idketqua_canlamsangchitiet FROM ketqua_canlamsangchitiet ORDER BY idketqua_canlamsangchitiet DESC ").Rows[0][0].ToString();
                _canlamsangchitiet.idketqua_canlamsang = this.idketqua_canlamsang;
                _canlamsangchitiet.idbanggiadichvu = this.idbanggiadichvu;
                _canlamsangchitiet.idchitietdichvu = this.idchitietdichvu;
                _canlamsangchitiet.ketqua = this.ketqua;
                _canlamsangchitiet.isBatThuong = this.isBatThuong;
                _canlamsangchitiet.ngaycls = this.ngaycls;
                _canlamsangchitiet.idbbscls = this.idbbscls;
                _canlamsangchitiet.ketquacdha = this.ketquacdha;
                _canlamsangchitiet.giatribinhthuong = this.giatribinhthuong;
                return _canlamsangchitiet;
            }
            return null;
        }

        public static ketqua_canlamsangchitiet Insert_Object(string sidketqua_canlamsang, string sidbanggiadichvu, string sidchitietdichvu, string sketqua, string sisBatThuong, string sngaycls, string sidbbscls, string sketquacdha, string sgiatribinhthuong)
        {
            string str = hsSqlTool.sGetSaveValue(sidketqua_canlamsang, "bigint");
            string str2 = hsSqlTool.sGetSaveValue(sidbanggiadichvu, "bigint");
            string str3 = hsSqlTool.sGetSaveValue(sidchitietdichvu, "bigint");
            string str4 = hsSqlTool.sGetSaveValue(sketqua, "nvarchar");
            string str5 = hsSqlTool.sGetSaveValue(sisBatThuong, "bit");
            string str6 = hsSqlTool.sGetSaveValue(sngaycls, "datetime");
            string str7 = hsSqlTool.sGetSaveValue(sidbbscls, "bigint");
            string str8 = hsSqlTool.sGetSaveValue(sketquacdha, "varbinary");
            string str9 = hsSqlTool.sGetSaveValue(sgiatribinhthuong, "nvarchar");
            if (Connect.Exec(" INSERT INTO ketqua_canlamsangchitiet(idketqua_canlamsang,idbanggiadichvu,idchitietdichvu,ketqua,isBatThuong,ngaycls,idbbscls,ketquacdha,giatribinhthuong) VALUES(" + str + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + ")") == 1)
            {
                ketqua_canlamsangchitiet _canlamsangchitiet = new ketqua_canlamsangchitiet();
                _canlamsangchitiet.idketqua_canlamsangchitiet = Connect.GetTable(" SELECT TOP 1 idketqua_canlamsangchitiet FROM ketqua_canlamsangchitiet ORDER BY idketqua_canlamsangchitiet DESC ").Rows[0][0].ToString();
                _canlamsangchitiet.idketqua_canlamsang = sidketqua_canlamsang;
                _canlamsangchitiet.idbanggiadichvu = sidbanggiadichvu;
                _canlamsangchitiet.idchitietdichvu = sidchitietdichvu;
                _canlamsangchitiet.ketqua = sketqua;
                _canlamsangchitiet.isBatThuong = sisBatThuong;
                _canlamsangchitiet.ngaycls = sngaycls;
                _canlamsangchitiet.idbbscls = sidbbscls;
                _canlamsangchitiet.ketquacdha = sketquacdha;
                _canlamsangchitiet.giatribinhthuong = sgiatribinhthuong;
                return _canlamsangchitiet;
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
            return " SELECT T.* FROM ketqua_canlamsangchitiet AS T";
        }

        public bool Save_Object()
        {
            string str = hsSqlTool.sGetSaveValue(this.idketqua_canlamsang, "bigint");
            string str2 = hsSqlTool.sGetSaveValue(this.idbanggiadichvu, "bigint");
            string str3 = hsSqlTool.sGetSaveValue(this.idchitietdichvu, "bigint");
            string str4 = hsSqlTool.sGetSaveValue(this.ketqua, "nvarchar");
            string str5 = hsSqlTool.sGetSaveValue(this.isBatThuong, "bit");
            string str6 = hsSqlTool.sGetSaveValue(this.ngaycls, "datetime");
            string str7 = hsSqlTool.sGetSaveValue(this.idbbscls, "bigint");
            string str8 = hsSqlTool.sGetSaveValue(this.ketquacdha, "varbinary");
            string str9 = hsSqlTool.sGetSaveValue(this.giatribinhthuong, "nvarchar");
            string str10 = " UPDATE ketqua_canlamsangchitiet SET ";
            if (str != null)
            {
                str10 = str10 + "idketqua_canlamsang =" + str + ",";
            }
            if (str2 != null)
            {
                str10 = str10 + "idbanggiadichvu =" + str2 + ",";
            }
            if (str3 != null)
            {
                str10 = str10 + "idchitietdichvu =" + str3 + ",";
            }
            if (str4 != null)
            {
                str10 = str10 + "ketqua =" + str4 + ",";
            }
            if (str5 != null)
            {
                str10 = str10 + "isBatThuong =" + str5 + ",";
            }
            if (str6 != null)
            {
                str10 = str10 + "ngaycls =" + str6 + ",";
            }
            if (str7 != null)
            {
                str10 = str10 + "idbbscls =" + str7 + ",";
            }
            if (str8 != null)
            {
                str10 = str10 + "ketquacdha =" + str8 + ",";
            }
            if (str9 != null)
            {
                str10 = str10 + "giatribinhthuong =" + str9 + ",";
            }
            return (Connect.Exec(str10 + " WHERE idketqua_canlamsangchitiet=" + hsSqlTool.sGetSaveValue(this.idketqua_canlamsangchitiet, "bigint identity")) == 1);
        }

        public bool Save_Object(string sidketqua_canlamsang, string sidbanggiadichvu, string sidchitietdichvu, string sketqua, string sisBatThuong, string sngaycls, string sidbbscls, string sketquacdha, string sgiatribinhthuong)
        {
            string str = hsSqlTool.sGetSaveValue(sidketqua_canlamsang, "bigint");
            string str2 = hsSqlTool.sGetSaveValue(sidbanggiadichvu, "bigint");
            string str3 = hsSqlTool.sGetSaveValue(sidchitietdichvu, "bigint");
            string str4 = hsSqlTool.sGetSaveValue(sketqua, "nvarchar");
            string str5 = hsSqlTool.sGetSaveValue(sisBatThuong, "bit");
            string str6 = hsSqlTool.sGetSaveValue(sngaycls, "datetime");
            string str7 = hsSqlTool.sGetSaveValue(sidbbscls, "bigint");
            string str8 = hsSqlTool.sGetSaveValue(sketquacdha, "varbinary");
            string str9 = hsSqlTool.sGetSaveValue(sgiatribinhthuong, "nvarchar");
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idketqua_canlamsang =" + str + ",idbanggiadichvu =" + str2 + ",idchitietdichvu =" + str3 + ",ketqua =" + str4 + ",isBatThuong =" + str5 + ",ngaycls =" + str6 + ",idbbscls =" + str7 + ",ketquacdha =" + str8 + ",giatribinhthuong =" + str9 + " WHERE idketqua_canlamsangchitiet=" + hsSqlTool.sGetSaveValue(this.idketqua_canlamsangchitiet, "bigint identity")) == 1;
            if (flag)
            {
                this.idketqua_canlamsang = sidketqua_canlamsang;
                this.idbanggiadichvu = sidbanggiadichvu;
                this.idchitietdichvu = sidchitietdichvu;
                this.ketqua = sketqua;
                this.isBatThuong = sisBatThuong;
                this.ngaycls = sngaycls;
                this.idbbscls = sidbbscls;
                this.ketquacdha = sketquacdha;
                this.giatribinhthuong = sgiatribinhthuong;
            }
            return flag;
        }

        private string SQLSelect()
        {
            string str = " SELECT stt= row_number() over (order by idketqua_canlamsangchitiet),T.* FROM ketqua_canlamsangchitiet AS T WHERE";
            if ((((this.idketqua_canlamsang != null) && (this.idketqua_canlamsang != "")) && (this.idketqua_canlamsang != "0")) && (this.idketqua_canlamsang != "0.0"))
            {
                str = str + " AND idketqua_canlamsang =" + this.idketqua_canlamsang;
            }
            if ((((this.idbanggiadichvu != null) && (this.idbanggiadichvu != "")) && (this.idbanggiadichvu != "0")) && (this.idbanggiadichvu != "0.0"))
            {
                str = str + " AND idbanggiadichvu =" + this.idbanggiadichvu;
            }
            if ((((this.idchitietdichvu != null) && (this.idchitietdichvu != "")) && (this.idchitietdichvu != "0")) && (this.idchitietdichvu != "0.0"))
            {
                str = str + " AND idchitietdichvu =" + this.idchitietdichvu;
            }
            if ((this.ketqua != null) && (this.ketqua != ""))
            {
                str = str + " AND ketqua LIKE N'%" + this.ketqua + "%'";
            }
            if ((this.isBatThuong != null) && (this.isBatThuong != ""))
            {
                str = str + " AND isBatThuong ='" + this.isBatThuong + "'";
            }
            if ((this.ngaycls != null) && (this.ngaycls != ""))
            {
                str = str + " AND ngaycls LIKE '%" + this.ngaycls + "%'";
            }
            if ((((this.idbbscls != null) && (this.idbbscls != "")) && (this.idbbscls != "0")) && (this.idbbscls != "0.0"))
            {
                str = str + " AND idbbscls =" + this.idbbscls;
            }
            if ((this.ketquacdha != null) && (this.ketquacdha != ""))
            {
                str = str + " AND ketquacdha LIKE '%" + this.ketquacdha + "%'";
            }
            if ((this.giatribinhthuong != null) && (this.giatribinhthuong != ""))
            {
                str = str + " AND giatribinhthuong LIKE N'%" + this.giatribinhthuong + "%'";
            }
            str = str.Replace("WHERE AND", "WHERE");
            int index = str.IndexOf("WHERE");
            if (index == (str.Length - 5))
            {
                str = str.Remove(index, 5);
            }
            return str;
        }

        public bool Update_giatribinhthuong(string sgiatribinhthuong)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET giatribinhthuong='N" + sgiatribinhthuong + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.giatribinhthuong = sgiatribinhthuong;
            }
            return flag;
        }

        public static bool Update_giatribinhthuong(string sgiatribinhthuong, string s_idketqua_canlamsangchitiet)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET giatribinhthuong='N" + sgiatribinhthuong + "' WHERE idketqua_canlamsangchitiet='" + s_idketqua_canlamsangchitiet + "' ") == 1);
        }

        public bool Update_idbanggiadichvu(string sidbanggiadichvu)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idbanggiadichvu='" + sidbanggiadichvu + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.idbanggiadichvu = sidbanggiadichvu;
            }
            return flag;
        }

        public static bool Update_idbanggiadichvu(string sidbanggiadichvu, string s_idketqua_canlamsangchitiet)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idbanggiadichvu='" + sidbanggiadichvu + "' WHERE idketqua_canlamsangchitiet='" + s_idketqua_canlamsangchitiet + "' ") == 1);
        }

        public bool Update_idbbscls(string sidbbscls)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idbbscls='" + sidbbscls + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.idbbscls = sidbbscls;
            }
            return flag;
        }

        public static bool Update_idbbscls(string sidbbscls, string s_idketqua_canlamsangchitiet)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idbbscls='" + sidbbscls + "' WHERE idketqua_canlamsangchitiet='" + s_idketqua_canlamsangchitiet + "' ") == 1);
        }

        public bool Update_idchitietdichvu(string sidchitietdichvu)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idchitietdichvu='" + sidchitietdichvu + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.idchitietdichvu = sidchitietdichvu;
            }
            return flag;
        }

        public static bool Update_idchitietdichvu(string sidchitietdichvu, string s_idketqua_canlamsangchitiet)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idchitietdichvu='" + sidchitietdichvu + "' WHERE idketqua_canlamsangchitiet='" + s_idketqua_canlamsangchitiet + "' ") == 1);
        }

        public bool Update_idketqua_canlamsang(string sidketqua_canlamsang)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idketqua_canlamsang='" + sidketqua_canlamsang + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.idketqua_canlamsang = sidketqua_canlamsang;
            }
            return flag;
        }

        public static bool Update_idketqua_canlamsang(string sidketqua_canlamsang, string s_idketqua_canlamsangchitiet)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idketqua_canlamsang='" + sidketqua_canlamsang + "' WHERE idketqua_canlamsangchitiet='" + s_idketqua_canlamsangchitiet + "' ") == 1);
        }

        public bool Update_idketqua_canlamsangchitiet(string sidketqua_canlamsangchitiet)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET idketqua_canlamsangchitiet='" + sidketqua_canlamsangchitiet + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.idketqua_canlamsangchitiet = sidketqua_canlamsangchitiet;
            }
            return flag;
        }

        public bool Update_isBatThuong(string sisBatThuong)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET isBatThuong='" + sisBatThuong + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.isBatThuong = sisBatThuong;
            }
            return flag;
        }

        public static bool Update_isBatThuong(string sisBatThuong, string s_idketqua_canlamsangchitiet)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET isBatThuong='" + sisBatThuong + "' WHERE idketqua_canlamsangchitiet='" + s_idketqua_canlamsangchitiet + "' ") == 1);
        }

        public bool Update_ketqua(string sketqua)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET ketqua='N" + sketqua + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.ketqua = sketqua;
            }
            return flag;
        }

        public static bool Update_ketqua(string sketqua, string s_idketqua_canlamsangchitiet)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET ketqua='N" + sketqua + "' WHERE idketqua_canlamsangchitiet='" + s_idketqua_canlamsangchitiet + "' ") == 1);
        }

        public bool Update_ketquacdha(string sketquacdha)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET ketquacdha='" + sketquacdha + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.ketquacdha = sketquacdha;
            }
            return flag;
        }

        public static bool Update_ketquacdha(string sketquacdha, string s_idketqua_canlamsangchitiet)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET ketquacdha='" + sketquacdha + "' WHERE idketqua_canlamsangchitiet='" + s_idketqua_canlamsangchitiet + "' ") == 1);
        }

        public bool Update_ngaycls(string sngaycls)
        {
            bool flag = Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET ngaycls='" + sngaycls + "' WHERE idketqua_canlamsangchitiet='" + this.idketqua_canlamsangchitiet + "' ") == 1;
            if (flag)
            {
                this.ngaycls = sngaycls;
            }
            return flag;
        }

        public static bool Update_ngaycls(string sngaycls, string s_idketqua_canlamsangchitiet)
        {
            return (Connect.Exec(" UPDATE ketqua_canlamsangchitiet SET ngaycls='" + sngaycls + "' WHERE idketqua_canlamsangchitiet='" + s_idketqua_canlamsangchitiet + "' ") == 1);
        }
    }
}


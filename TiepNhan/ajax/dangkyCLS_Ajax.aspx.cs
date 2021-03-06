using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
public partial class thuphiCLS_BNTuDen_Ajax : MKVPage
{
    protected DataProcess s_khambenhcanlamsan()
    {
        DataProcess khambenhcanlamsan = new DataProcess("khambenhcanlamsan");
        khambenhcanlamsan.data("idkhambenhcanlamsan", Request.QueryString["idkhoachinh"]);
        khambenhcanlamsan.data("idcanlamsan", Request.QueryString["idcanlamsan"]);
        khambenhcanlamsan.data("idkhambenh", Request.QueryString["idkhambenh"]);
        khambenhcanlamsan.data("dongia", Request.QueryString["dongia"]);
        khambenhcanlamsan.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        string loaiBN = StaticData.GetValue("benhnhan", "idbenhnhan", StaticData.ParseInt(Request.QueryString["idbenhnhan"]), "loai");
        string ngaythu = Request.QueryString["ngaythu"];
        if (ngaythu == "" || ngaythu == "0") ngaythu = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        khambenhcanlamsan.data("ngaythu", ngaythu);
        khambenhcanlamsan.data("maphieucls", Request.QueryString["MaPhieuCLS"]);
        khambenhcanlamsan.data("soluong", Request.QueryString["soluong"]);
        khambenhcanlamsan.data("chietkhau", Request.QueryString["chietkhau"]);
        khambenhcanlamsan.data("thanhtien", Request.QueryString["thanhtien"]);
        khambenhcanlamsan.data("ghichu", Request.QueryString["ghichu"]);
        khambenhcanlamsan.data("idbacsicd", Request.QueryString["idbacsi"]);
        khambenhcanlamsan.data("IsDaDKK",(Request.QueryString["IsDKK"]=="undefined" ? "0" : (StaticData.IsCheck(Request.QueryString["IsDKK"]) == true ? "1" : "0")));
        return khambenhcanlamsan;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = StaticData.escape(Request.QueryString["do"]);
        switch (action)
        {
            case "LoadDanhSachBacSiCD": LoadDanhSachBacSiCD(); break;
            case "loadTablekhambenhcanlamsan": loadTablekhambenhcanlamsan(); break;
            case "idcanlamsansearch": idcanlamsansearch(); break;
            case "ChonCLS": ChonCLS(); break;
            case "GetDSCLS": GetDSCLS(); break;
            case "xoakhambenhcanlamsan": Xoakhambenhcanlamsan(); break;
            case "luuTablekhambenhcanlamsan": LuuTablekhambenhcanlamsan(); break;
            case "idkhoasearch": idkhoasearch(); break;
            case "idphongsearch": idphongsearch(); break;
            case "create": create(); break;
            case "idkhoadangkysearch": idkhoadangkysearch(); break;
            case "loadMacdinhKhoa": loadMacdinhKhoa(); break;
            case "LoadDSNguoiTiepNhan": LoadDSNguoiTiepNhan(); break;
            case "setTimKiem": setTimKiem(); break;
            case "ChonclsThuongquy": ChonclsThuongquy(); break;
            case "setCSLThuongQuy": setCSLThuongQuy(); break;
        }
    }
    #region canlamsangthuongquy
    private void ChonclsThuongquy()
    {
        string sqlSelect = string.Format(@"SELECT STT=ROW_NUMBER() OVER(ORDER BY T.NHOMID),* FROM KB_NHOMCLS T ");
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"tablefind\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nhóm CLS thường quy") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr style='cursor:pointer'>");
                    html.Append("<td>" + table.Rows[i]["STT"].ToString() + "</td>");
                    html.Append("<td style='text-align:left; padding-left:10px; font-family:tahoma;'>" + table.Rows[i]["TenNhom"].ToString() + "</td>");
                    html.Append("<td style='text-align:left; padding-left:10px; font-family:tahoma;'>" + table.Rows[i]["GhiChu"].ToString() + "</td>");
                    html.Append("<td><a href=\"javascript:;\" onclick=\"setCSLThuongQuy('" + table.Rows[i]["NhomId"].ToString() + "')\">Chọn</a><td>");
                    html.Append("</tr>");
                }
                html.Append("</table>");
                Response.Clear();
                Response.Write(html);
                return;
            }
        }
        else
        {
            Response.StatusCode = 500;
        }
    }
    private void setCSLThuongQuy()
    {
        string LoaiBN = (Request.QueryString["loaibenhnhan"] != null ? Request.QueryString["loaibenhnhan"].ToString() : "");
        string nhomid = Request.QueryString["NhomId"]; string sqlSelect = "", sqlSelect_1 = "", sqlSelect_2 = "";
        System.Collections.Generic.List<string> lstC = null;
        string[] arrslvack = null;
        //lay du lieu tu nhom cls thuong quy
        sqlSelect_1 = string.Format(@"select distinct STT=0
                               ,b.idbanggiadichvu
                               ,pkb.tenphongkhambenh
                               ,B.TenNhom
                               ,B.tendichvu
                               ,Dongia=0
                               ,b.giadichvu
                               ,b.bhtra
                               ,B.IsSuDungChoBH
                               ,pkb.idphongkhambenh
                               ,dathu=0
                      from KB_ChiTietNhomCLS T
                                left join KB_NhomCLS  A on T.NhomID=A.NhomId
                                left join banggiadichvu  B on T.idbanggiadichvu=B.idbanggiadichvu
                                left join phongkhambenh pkb on b.idphongkhambenh=pkb.idphongkhambenh
                      where T.NhomID='{0}'", nhomid);
        //kiem tra listID tu gridview co san
        string slvack = Request.QueryString["slvack"];
        string listidcanlamsan = Request.QueryString["listID"];
        if (listidcanlamsan == null || listidcanlamsan == "")
        {
            //Response.Clear();
            //Response.Write("");
            //return;
            sqlSelect = sqlSelect_1 +"  order by tendichvu ";
        }
        else
        {
            listidcanlamsan = listidcanlamsan.TrimEnd(',').Replace("on,", "");
            string[] arridcls = listidcanlamsan.Split(',');
            string sNewArrCLSID = "";
            lstC = new System.Collections.Generic.List<string>();
            for (int i = 0; i < arridcls.Length; i++)
            {
                if (lstC.IndexOf(arridcls[i]) == -1)
                {
                    lstC.Add(arridcls[i]);
                    sNewArrCLSID += arridcls[i] + ",";
                }
            }
            sNewArrCLSID = sNewArrCLSID.Remove(sNewArrCLSID.Length - 1, 1);
            arrslvack = slvack.Split('@');
            if (listidcanlamsan.Trim() == "")
            {
                listidcanlamsan = "''";
            }
            sqlSelect_2 = string.Format(@"SELECT distinct STT=0
                                               ,A.idbanggiadichvu 
                                               ,B.tenphongkhambenh
                                               ,A.TenNhom
                                               ,A.tendichvu
                                               ,DONGIA=0
                                               ,GIADICHVU
                                               ,BHTRA
                                               ,A.IsSuDungChoBH
                                               ,A.idphongkhambenh
                                               ,dathu=0
                  				            FROM BANGGIADICHVU A
               				                LEFT JOIN PHONGKHAMBENH b on a.idphongkhambenh=b.idphongkhambenh
                                            WHERE b.loaiphong = 1 and a.idbanggiadichvu in (" + sNewArrCLSID + ")");
            sqlSelect = string.Format(@"select * from(
                                                (" + sqlSelect_1 + @") 
                                          UNION (" + sqlSelect_2 + @")
                                        ) nvk order by tendichvu");
        }
        //end kiem tra
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        dt.Columns.Add("nSTT", typeof(int));
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string IdBangGiaDichVu_ = dt.Rows[i]["IdBangGiaDichVu"].ToString();
                if (lstC != null)
                {
                    int n_ = lstC.IndexOf(IdBangGiaDichVu_);
                    dt.Rows[i]["nSTT"] = n_;
                }
                bool IsSuDungChoBH = StaticData.IsCheck(dt.Rows[i]["IsSuDungChoBH"].ToString());
                string DonGia = "0";
                if (LoaiBN == "1" && IsSuDungChoBH)
                {
                    DonGia = dt.Rows[i]["BHTra"].ToString();
                }
                else DonGia = dt.Rows[i]["GiaDichVu"].ToString();
                dt.Rows[i]["DonGia"] = DonGia;

            }
        }
        dt.DefaultView.Sort = "dathu desc";
        dt = dt.DefaultView.ToTable();
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            dt.Rows[j]["STT"] = j + 1;
        }
        string html = "";
        html += tableCLS(dt, arrslvack, false);
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region canlamsang
    private void GetDSCLS()
    {
        try
        {
            string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
            string IdKhambenh = (Request.QueryString["IdKhambenh"] != null ? Request.QueryString["IdKhambenh"].ToString() : "");
            string slvack = Request.QueryString["slvack"];
            string LoaiBN = (Request.QueryString["loaibenhnhan"] != null ? Request.QueryString["loaibenhnhan"].ToString() : "");
            if (LoaiBN == "")
            {
                DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN B WHERE idbenhnhan='" + IdBenhNhan + "'");
                if (dtBN != null && dtBN.Rows.Count > 0)
                {
                    LoaiBN = dtBN.Rows[0][0].ToString();
                    IdBenhNhan = dtBN.Rows[0]["IdBenhNhan"].ToString();
                }
            }
            //khoi tao array cls
            string listidcanlamsan = Request.QueryString["listID"];
            if (listidcanlamsan == null || listidcanlamsan == "")
            {
                Response.Clear();
                Response.Write("");
                return;
            }
            listidcanlamsan = listidcanlamsan.TrimEnd(',').Replace("on,", "");
            string[] arridcls = listidcanlamsan.Split(',');
            string sNewArrCLSID = "";
            System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
            for (int i = 0; i < arridcls.Length; i++)
            {
                if (lstC.IndexOf(arridcls[i]) == -1)
                {
                    lstC.Add(arridcls[i]);
                    sNewArrCLSID += arridcls[i] + ",";
                }
            }
            sNewArrCLSID = sNewArrCLSID.Remove(sNewArrCLSID.Length - 1, 1);
            int length = arridcls.Length;
            string[] arrslvack = slvack.Split('@');
            string html = "";
            if (listidcanlamsan.Trim() == "")
            {
                listidcanlamsan = "''";
            }
            //end array
            string sqlSelectBangGiaDichVu = ""
                   + " select STT=0,A.idbanggiadichvu, B.tenphongkhambenh,A.TenNhom,A.tendichvu,DONGIA=0, GIADICHVU,BHTRA,A.IsSuDungChoBH,A.PhuThuBH,A.idphongkhambenh" + "\r\n"
                   + " 				from banggiadichvu a" + "\r\n"
                   + " 				left join phongkhambenh b on a.idphongkhambenh=b.idphongkhambenh" + "\r\n"
                   + " WHERE b.loaiphong = 1 and a.idbanggiadichvu in (" + sNewArrCLSID + ")"
                   + "  " + "\r\n";
            DataTable dt = DataAcess.Connect.GetTable(sqlSelectBangGiaDichVu);
            dt.Columns.Add("nSTT", length.GetType());
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string IdBangGiaDichVu_ = dt.Rows[i]["IdBangGiaDichVu"].ToString();
                    int n_ = lstC.IndexOf(IdBangGiaDichVu_);
                    dt.Rows[i]["nSTT"] = n_;

                    bool IsSuDungChoBH = StaticData.IsCheck(dt.Rows[i]["IsSuDungChoBH"].ToString());
                    string DonGia = "0";
                    if (LoaiBN == "1" && IsSuDungChoBH)
                    {
                        DonGia = dt.Rows[i]["BHTra"].ToString();
                    }
                    else DonGia = dt.Rows[i]["GiaDichVu"].ToString();
                    dt.Rows[i]["DonGia"] = DonGia;
                    dt.Rows[i]["STT"] = i + 1;
                }
            }
            dt.DefaultView.Sort = "nSTT";
            dt = dt.DefaultView.ToTable();
            html = tableCLS(dt, arrslvack, false);
            Response.Clear();
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private void ChonCLS()
    {
        string LoaiBenhNhan = Request.QueryString["loaibenhnhan"];
        if (LoaiBenhNhan == null || LoaiBenhNhan == "")
        {
            DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN WHERE idbenhnhan='" + Request.QueryString["idbenhnhan"] + "'");
            if (dtBN != null && dtBN.Rows.Count > 0)
            {
                LoaiBenhNhan = dtBN.Rows[0][0].ToString();
            }
        }
        string listidcanlamsan = Request.QueryString["listID"];
        string[] arridcls = listidcanlamsan.Split(',');
        listidcanlamsan = listidcanlamsan.TrimEnd(',');
        string swhere = "";
        int idpkb = StaticData.ParseInt(Request.QueryString["idpkb"]);
        string tenNhom = Request.QueryString["tN"];
        if (idpkb == 0)
        {

        }
        else
        {
            swhere = " and Bg.idphongkhambenh=" + idpkb + " ";
        }
        string html = "";
        string selectIDDVNhomCLS = "select tenNhom,dbo.[GetIdBanggiaDVByNhomCLS](n.nhomId) as idDV from KB_NhomCLS n where status='true' order by n.tenNhom";
        DataTable arrIDDVNhomCLS = DataAcess.Connect.GetTable(selectIDDVNhomCLS);
        string selectTenPhong = "select tenphongkhambenh,pkb.idphongkhambenh from phongkhambenh pkb where loaiphong=1 order by pkb.idphongkhambenh";
        DataTable arrT = DataAcess.Connect.GetTable(selectTenPhong);
        html += "Tên Khoa/Phòng:";
        for (int i = 0; i < arrT.Rows.Count; i++)
        {

            html += "<input  style=\"width:auto\" type=\"button\" onclick=\"ChonCLS(this,null,'" + arrT.Rows[i]["idphongkhambenh"].ToString() + "','cls');\" name=\"rbnSearch\" value=\"" + arrT.Rows[i]["tenphongkhambenh"].ToString() + "\"/>";

        }
        html += "<table class='jtable' border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\">";


        string sqlSelectTenNhom = ""
                                    + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh" + "\r\n"
                                    + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
                                    + " where  bg.idphongkhambenh= " + idpkb + " AND   loaiphong=1 " + swhere + " " + "\r\n";
        DataTable arrT1 = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" >";
        int mkvclick = 0;
        if (arrT1 != null && arrT1.Rows.Count != 0)
        {
            if (arrT1.Rows.Count >= 4)
            {
                string tenPKB = arrT1.Rows[0]["tenphongkhambenh"].ToString();
                string tenN = "";

                for (int i = 0; i < arrT1.Rows.Count; i++)
                {
                    tenN = tenN + arrT1.Rows[i]["tennhom"].ToString() + ",";
                    string t = arrT1.Rows[i]["tennhom"].ToString();
                    string tNext = "";
                    if (i < arrT1.Rows.Count - 1)
                    {
                        tNext = arrT1.Rows[i + 1]["tennhom"].ToString();
                    }
                    else
                        tNext = arrT1.Rows[i]["tennhom"].ToString();
                    html += "<td align=\"left\" style=\"width:20%\" class=\"ptext\" >";

                    html += "<a href=\"#\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";
                    if (((i + 1) % 4) == 0)
                    {
                        html += "</tr>";
                    }


                }
                tenN = tenN.TrimEnd(',');
            }
            else
            {
                string tenPKB = arrT1.Rows[0]["tenphongkhambenh"].ToString();
                string tenN = "";
                for (int i = 0; i < arrT1.Rows.Count; i++)
                {
                    tenN = tenN + arrT1.Rows[i]["tennhom"].ToString() + ",";
                    string t = arrT1.Rows[i]["tennhom"].ToString();
                    string tNext = "";
                    if (i < arrT1.Rows.Count - 1)
                    {
                        tNext = arrT1.Rows[i + 1]["tennhom"].ToString();
                    }
                    else
                        tNext = arrT1.Rows[i]["tennhom"].ToString();
                    html += "<td align=\"left\"  style=\"width:30%\" class=\"ptext\" >";

                    html += "<a href=\"#\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";

                }
                tenN = tenN.TrimEnd(',');
            }
        }

        html += "</tr>";



        html += "</table>";


        string idDVCLSByTN = "";

        DataTable arr = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        int mkv = 0;
        foreach (DataRow h in arr.Rows)
        {
            html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" class='jtable'>";
            string t = h["tennhom"].ToString();
            string sqlSelectIDDVByTN = ""
                     + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.BHTRA,A.PhuThuBH,A.IsSuDungChoBH " + "\r\n"
                     + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "' order by A.tendichvu" + "\r\n"
                     + "  " + "\r\n";
            DataTable arrIDDVByTN = DataAcess.Connect.GetTable(sqlSelectIDDVByTN);
            foreach (DataRow idDVByTN in arrIDDVByTN.Rows)
            {
                idDVCLSByTN = idDVCLSByTN + idDVByTN["idbanggiadichvu"].ToString() + ",";
            }
            html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" width=\"100%\">";
            string t1 = Request.QueryString["checkTN"];
            if (Request.QueryString["checkTN"] != null && Request.QueryString["checkTN"] != "")
            {

                int dk = 0;
                string[] arrTenNhom = t1.Split(',');
                for (int i = 0; i < arrTenNhom.Length; i++)
                {
                    string tam = arrTenNhom[i].ToString();
                    if (t == tam)
                    {
                        html += "<th align=\"left\" width='20px'>&nbsp;<input checked id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
                        dk = 1;
                        break;
                    }
                    else
                    {
                        dk = 0;
                    }
                }
                if (dk == 0)
                {
                    html += "<th align=\"left\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
                }


            }
            else
            {
                html += "<th align=\"right\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
            }
            html += "<th  align=\"left\" width=\"70%\" class=\"ptext\" ><input style=\"width:auto\" type=\"button\" id=\"mkv" + mkv + "\" style=\"font-weight:bold\" value=\"" + t + "\"/></th>";
            html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Đơn giá</th>";
            html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;?BH</th>";
            html += "</tr>";
            mkv++;
            string sqlSelectTenDV = ""
                   + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.BHTRA,A.PhuThuBH,IsSuDungChoBH " + "\r\n"
                   + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "' order by A.tendichvu" + "\r\n"
                   + "  " + "\r\n";
            idDVCLSByTN = "";
            DataTable arrTenDV = DataAcess.Connect.GetTable(sqlSelectTenDV);
            {
                if (arrTenDV.Rows.Count != 0)
                {
                    foreach (DataRow tenDV in arrTenDV.Rows)
                    {

                        bool IsSuDungChoBH = StaticData.IsCheck(tenDV["IsSuDungChoBH"].ToString());
                        int dk = 0;
                        html += "<tr style='background-color:" + (IsSuDungChoBH == true ? "" : "#CAE3FF") + ";' width=\"100%\">";
                        string id = tenDV["idbanggiadichvu"].ToString();
                        for (int i = 0; i < arridcls.Length; i++)
                        {
                            string tam = arridcls[i].ToString();
                            if (id == tam)
                            {
                                html += "<td style=\" " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\" align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" checked  type=\"checkbox\" /></td>";
                                dk = 1;
                                break;
                            }
                            else
                            {
                                dk = 0;
                            }
                        }
                        if (dk == 1)
                        {

                        }
                        else
                        {
                            html += "<td style=\" " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\" align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" type=\"checkbox\" /></td>";
                        }
                        string DonGia = "";

                        if (LoaiBenhNhan == "1" && IsSuDungChoBH == true)
                        {
                            DonGia = tenDV["BHTra"].ToString();
                        }
                        else
                            DonGia = tenDV["GiaDichVu"].ToString();

                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\" width=\"70%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenDV["tendichvu"] + "</td>";
                        html += "<td width=\"20%\" class=\"ptext\" align = \"left\" style = \"padding-right:20px; " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\">" + StaticData.FormatNumber(DonGia, false).ToString() + "</td>";
                        html += "<td width=\"20%\" class=\"ptext\" align = \"left\" style = \"padding-right:20px; " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\">" + (IsSuDungChoBH == true ? "BH" : "DV") + "</td>";
                        html += "</tr>";
                    }

                }
            }
            html += "</table>";
        }

        Response.Clear();
        Response.Write(html);
    }
    #endregion
    private void setTimKiem()
    {
        string idbn = Request.QueryString["idkhoachinh"];
        string strsql = "SELECT * FROM benhnhan WHERE idbenhnhan ='" + idbn + "'";
        DataTable table = DataAcess.Connect.GetTable(strsql);
        string html = "";
        html += "<root>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                html += "<data id=\"ngaythu\">" + string.Format("{0:dd/MM/yyyy}", DateTime.Now) + "</data>";
                html += "<data id=\"idnguoidung\">" + SysParameter.UserLogin.UserID(this) + "</data>";
                html += "<data id=\"idkhoadangky\">" + Request.QueryString["idkhoa"] + "</data>";
                html += "<data id=\"chietkhau\">0</data>";
                html += Environment.NewLine;
                for (int y = 0; y < table.Columns.Count; y++)
                {

                    try
                    {
                        html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                    }
                    catch (Exception)
                    {
                        html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                    }
                    html += Environment.NewLine;
                }
            }
        }
        html += "</root>";
        Response.Clear();
        Response.Write(html.Replace("&", "&amp"));
    }
    private void LoadDSNguoiTiepNhan()
    {
        string sqlSelectND = "select distinct nd.* from nguoidung nd left join nhomnguoidung nnd on nnd.nhomid= nd.nhomid "
        + " where 1=1 ";
        if (!SysParameter.UserLogin.GroupID(this).Equals("4"))
        {
            sqlSelectND += "AND ND.IDNGUOIDUNG= " + SysParameter.UserLogin.UserID(this) + "";
        }
        DataTable table = DataAcess.Connect.GetTable(sqlSelectND);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loadMacdinhKhoa()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string selectTenPhong = @"select pkb.idphongkhambenh,pkb.tenphongkhambenh from phongkhambenh
            pkb where loaiphong=0  and pkb.idphongkhambenh='" + idkhoa + "'" + " order by pkb.idphongkhambenh";
        DataTable table = DataAcess.Connect.GetTable(selectTenPhong);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString();

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idkhoadangkysearch()
    {
        string selectTenPhong = @"select pkb.idphongkhambenh,pkb.tenphongkhambenh from phongkhambenh
            pkb where loaiphong=0 order by pkb.idphongkhambenh";
        DataTable table = DataAcess.Connect.GetTable(selectTenPhong);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void create()
    {
        string IdKhoa = Request.QueryString["IdKhoa"];
        string maphieucls = StaticData_HS.MaPhieuCLS_new();
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        if (idbenhnhan != null && idbenhnhan != "")
        {
            idbenhnhan = Request.QueryString["idbenhnhan"];
        }
        string ngaydk = Request.QueryString["ngaydk"];

        if (ngaydk != null && ngaydk != "")
        {
            ngaydk = Request.QueryString["ngaydk"];
        }
        string stemp = "13/08/2012";
        string sNgay = ngaydk.Substring(0, stemp.Length);
        string sgio = ngaydk.Replace(sNgay, "").Trim();
        string sNgayLuu = StaticData.CheckDate(sNgay) + " " + sgio;

        string nguoidk = Request.QueryString["nguoidk"];
        if (nguoidk != null && nguoidk != "")
        {
            nguoidk = Request.QueryString["nguoidk"];
        }
        string sqlExecute = @"SELECT TOP 1 * FROM HS_DANGKYCLS WHERE IDBENHNHAN=" + idbenhnhan + " AND NGAYDK=CONVERT(VARCHAR(20),'" + sNgayLuu + "',103) AND MAPHIEUCLS='" + maphieucls + "' ORDER BY NGAYDK DESC";
        string iddangkycls = "";
        DataTable dtcheck = DataAcess.Connect.GetTable(sqlExecute);
        if (dtcheck != null && dtcheck.Rows.Count > 0)
        {
            iddangkycls = dtcheck.Rows[0]["IDDANGKYCLS"].ToString();
        }
        else
        {
            sqlExecute = "INSERT INTO HS_DANGKYCLS(MAPHIEUCLS,NGAYDK,NGUOIDK,IDBENHNHAN) VALUES('" + maphieucls + "','" + sNgayLuu + "','" + nguoidk + "','" + idbenhnhan + "')";
            bool OK = DataAcess.Connect.ExecSQL(sqlExecute);
            if (OK)
            {
                sqlExecute = @"SELECT TOP 1 * FROM HS_DANGKYCLS WHERE IDBENHNHAN=" + idbenhnhan + " AND NGAYDK=CONVERT(VARCHAR(20),'" + sNgayLuu + "',103) AND MAPHIEUCLS='" + maphieucls + "' ORDER BY NGAYDK DESC";
                dtcheck = dtcheck = DataAcess.Connect.GetTable(sqlExecute);
                if (dtcheck != null && dtcheck.Rows.Count > 0)
                {
                    iddangkycls = dtcheck.Rows[0]["IDDANGKYCLS"].ToString();
                }
            }
        }
        string sqlTestDKK = @"SELECT TOP 1 A.IDCHITIETDANGKYKHAM
                             FROM CHITIETDANGKYKHAM A
                             LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                             WHERE  
                                    A.IDKHOA=" + IdKhoa + @"
                                    AND B.IDBENHNHAN=" + idbenhnhan + @"
                                    AND ISNULL(A.DAHUY,0)=0
                                    AND A.ISDATHU=1
                                    AND YEAR(NGAYDANGKY)=YEAR('" + sNgayLuu + @"')
                                    AND MONTH(NGAYDANGKY)=MONTH('" + sNgayLuu + @"')
                                    AND DAY(NGAYDANGKY)=DAY('" + sNgayLuu + @"')";
        DataTable dtTestDKK = DataAcess.Connect.GetTable(sqlTestDKK);
        string IsDKK = "0";
        if (dtTestDKK != null && dtTestDKK.Rows.Count > 0)
            IsDKK = "1";

        if (iddangkycls != null && iddangkycls != "" && maphieucls != null && maphieucls != "")
        {
            Response.Clear();
            Response.Write(maphieucls + "|" + iddangkycls + "|" + IsDKK);
            return;
        }
    }
    private void idkhoasearch()
    {
        string selectTenPhong = @"select pkb.idphongkhambenh,pkb.tenphongkhambenh from phongkhambenh
            pkb where loaiphong=1 order by pkb.idphongkhambenh";
        DataTable table = DataAcess.Connect.GetTable(selectTenPhong);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idphongsearch()
    {
        string swhere = "";
        string idpkb = Request.QueryString["idpkb"];
        if (idpkb != null && idpkb != "")
        {
            swhere += " and bg.idphongkhambenh=" + StaticData.ParseInt(idpkb);
        }
        string sqlSelectTenNhom = ""
                                    + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh" + "\r\n"
                                    + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
                                    + " where 1=1  " + swhere + "  and  loaiphong=1 \r\n";
        DataTable table = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][0].ToString() + "|" + StaticData.IntelName(table.Rows[i][1].ToString()) + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);

    }
    private void Xoakhambenhcanlamsan()
    {
        try
        {
            DataProcess process = s_khambenhcanlamsan();
            string idKhamBenhCLS = process.getData("idkhambenhcanlamsan");
            string sqlCLS = "select dathu,ISBNDaTra from khambenhcanlamsan where idkhambenhcanlamsan=" + idKhamBenhCLS;
            DataTable dtCLS = DataAcess.Connect.GetTable(sqlCLS);
            string dathu = dtCLS.Rows[0]["dathu"].ToString();
            if (dathu == "" || dathu.ToLower() == "false" || dathu == "0") dathu = "0";
            else dathu = "1";


            string ISBNDaTra = dtCLS.Rows[0]["ISBNDaTra"].ToString();
            if (ISBNDaTra == "" || ISBNDaTra.ToLower() == "false" || ISBNDaTra == "0") ISBNDaTra = "0";
            else ISBNDaTra = "1";
            if (dathu == "1" || ISBNDaTra == "1")
            {
                Response.StatusCode = 500;
                Response.Write("Dịch vụ kĩ thuật này được thu tiền rồi !");
                return;

            }
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void idcanlamsansearch()
    {
        string swhere = "";
        string tennhom = Request.QueryString["tennhom"];
        if (tennhom != null && tennhom != "")
        {
            swhere += " and bg.tennhom like N'" + tennhom + "'";
        }
        string idphongkhambenh = Request.QueryString["idphongkhambenh"];
        if (idphongkhambenh != null && idphongkhambenh != "")
        {
            swhere += " and bg.idphongkhambenh=" + idphongkhambenh;
        }
        string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
        string LoaiBN = (Request.QueryString["loaibenhnhan"] != null ? Request.QueryString["loaibenhnhan"].ToString() : "");
        if (LoaiBN == "")
        {

            DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN B WHERE idbenhnhan='" + IdBenhNhan + "'");
            if (dtBN != null && dtBN.Rows.Count > 0)
            {
                LoaiBN = dtBN.Rows[0][0].ToString();
                IdBenhNhan = dtBN.Rows[0]["IdBenhNhan"].ToString();
            }
        }
        string sqlSelect = @"SELECT  bg.idbanggiadichvu,bg.tendichvu,dongia=0,bg.GIADICHVU,bg.BHTRA, bg.IsSuDungChoBH 
                            FROM banggiadichvu bg
                            left join phongkhambenh pkb on pkb.idphongkhambenh=bg.idphongkhambenh
                            where 1=1  " + swhere + " and pkb.loaiphong=1 and  bg.tendichvu like N'%" + Request.QueryString["q"].Trim() + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                bool IsSuDungChoBH = StaticData.IsCheck(table.Rows[i]["IsSuDungChoBH"].ToString());
                string DonGia = "";
                if (LoaiBN == "1" && IsSuDungChoBH)
                {
                    DonGia = table.Rows[i]["BHTra"].ToString();
                }
                else
                    DonGia = table.Rows[i]["GiaDichVu"].ToString();
                table.Rows[i]["DonGia"] = DonGia;
                html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString() + "|" + (IsSuDungChoBH == true ? " BH" : "DV") + Environment.NewLine;

            }
        }
        Response.Clear(); Response.Write(html);
    }
    public void loadTablekhambenhcanlamsan()
    {
        DataProcess process = s_khambenhcanlamsan();
        process.NumberRow = "10000";
        process.Page = Request.QueryString["page"];
        string sqlSelect = @"select STT=row_number() over (order by T.idkhambenhcanlamsan),T.*
                                ,a.tendichvu,a.idbanggiadichvu,a.IsSuDungChoBH,a.tennhom,a.idphongkhambenh,pkb.tenphongkhambenh
                               from khambenhcanlamsan T
                                left join banggiadichvu a on t.idcanlamsan=a.idbanggiadichvu
                                left join phongkhambenh pkb on a.idphongkhambenh=pkb.idphongkhambenh
          where T.idkhambenh=" + (process.getData("idkhambenh") == "" ? "null" : "'" + process.getData("idkhambenh") + "'");
        DataTable table = process.Search(sqlSelect);
        string html = "";
        html += tableCLS(table, null, true);
        //  html += process.Paging("khambenhcanlamsan");
        Response.Clear();
        Response.Write(html);
    }
    private string tableCLS(DataTable dt, string[] arrslvack, bool idkhambenhcls)
    {
        string html = "";
        html += "<table class='jtable' id=\"gridTablecls\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Tên Khoa</th>";
        html += "<th>Tên nhóm</th>";
        html += "<th>Tên dịch vụ</th>";
        html += "<th>Số lượng</th>";
        html += "<th>Đơn giá</th>";
        html += "<th>Chiết khấu</th>";
        html += "<th>Thành tiền</th>";
        html += "<th>Ghi chú</th>";
        html += "<th>?BH</th>";
        html += "<th></th>";
        html += "</tr>";
        if (dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsSuDungChoBH = StaticData.IsCheck(dt.Rows[i]["IsSuDungChoBH"].ToString());
                int ck = 0;
                int sl = 1;

                string idkhoachinh = "";
                if (arrslvack != null)
                {
                    for (int y = 0; y < arrslvack.Length; y++)
                    {
                        if (arrslvack[y].Split('^')[0].ToString() == dt.Rows[i]["idbanggiadichvu"].ToString() && (int.Parse(arrslvack[y].Split('^')[1].ToString()) > 1 || int.Parse(arrslvack[y].Split('^')[2].ToString()) > 0 || arrslvack[y].Split('^')[3].ToString() != ""))
                        {
                            ck = int.Parse(arrslvack[y].Split('^')[2].ToString());
                            sl = int.Parse(arrslvack[y].Split('^')[1].ToString());
                            idkhoachinh = arrslvack[y].Split('^')[3].ToString();
                            break;
                        }
                    }
                }
                try
                {
                    ck = int.Parse(dt.Rows[i]["chietkhau"].ToString());
                    sl = int.Parse(dt.Rows[i]["soluong"].ToString());
                }
                catch { }
                int thanhtien = (dt.Rows[i]["dongia"].ToString() != "" ? sl * int.Parse(dt.Rows[i]["dongia"].ToString()) : 0); ;

                html += "<tr " + (IsSuDungChoBH == true ? "" : "style='background-color:#CAE3FF'") + " >";
                html += "<td>" + dt.Rows[i]["stt"] + "</td>";
                html += "<td><a onclick='xoaontablecls(this)'>Xoá</a></td>";
                html += "<td><input mkv='true' id='idkhoa' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idphongkhambenh"] + " ' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idkhoa' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhoasearch(this)' onblur='idkhoachange(this);' value='" + dt.Rows[i]["tenphongkhambenh"] + "'  style='width:120px' class='down_select'/></td>";
                html += "<td><input mkv='true' id='mkv_tennhom' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idphongsearch(this)' value='" + dt.Rows[i]["tennhom"] + "'  style='width:120px' class='down_select'/></td>";
                html += "<td ><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idbanggiadichvu"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='" + dt.Rows[i]["tendichvu"] + "'  style='width:180px' class='down_select'/></td>";
                html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + sl + "' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();'  style='width:30px'/></td>";
                html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["dongia"] + "' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();;' style='width:50px'/></td>";
                html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ck + "' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();'  style='width:30px'/></td>";
                html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ((thanhtien - (thanhtien * ck) / 100)).ToString() + "'  style='width:50px' /></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                html += "<td><input mkv='true' id='isbh' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (IsSuDungChoBH == true ? "BH" : "DV") + "' style='width:30px' /></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : idkhoachinh) + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>" + (dt.Rows.Count + 1) + "</td>";
        html += "<td><a onclick='xoaontablecls(this)'>Xoá</a></td>";
        html += "<td><input mkv='true' id='idkhoa' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idkhoa' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhoasearch(this)' value=''  style='width:120px' class='down_select'/></td>";
        html += "<td><input mkv='true' id='mkv_tennhom' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idphongsearch(this)' value=''  style='width:120px' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)'  style='width:180px' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();'  style='width:30px'/></td>";
        html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls()' style='width:50px' /></td>";
        html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls()'  style='width:30px'/></td>";
        html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:50px; text-algin:right' /></td>";
        html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
        html += "<td><input mkv='true' id='isbh' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:30px' /></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";
        html += "<tr ><td></td><td colspan='6' align='right' style='font-weight:bold; font-size:13px;'>Tổng Cộng</td><td style='font-weight:bold;text-align:right; font-size:14px; padding-right:5px;' colspan='2'></td><td></td><td></td><td></td></tr>";
        html += "</table>";
        return html;
    }
    private void LoadDanhSachBacSiCD()
    {
        string sqlBacSi = @"select * from bacsi";
        DataTable table = DataAcess.Connect.GetTable(sqlBacSi);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    public void LuuTablekhambenhcanlamsan()
    {
        try
        {
            string sysdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string save_SysDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string iddangkycls = Request.QueryString["iddangkycls"];

            string gio = Request.QueryString["gio"];
            string phut = Request.QueryString["phut"];

            if (iddangkycls != null && iddangkycls != "")
            {
                iddangkycls = Request.QueryString["iddangkycls"];
            }
            string idkhoadangky = Request.QueryString["idkhoadangky"];
            if (idkhoadangky != null && idkhoadangky != "")
            {
                idkhoadangky = Request.QueryString["idkhoadangky"];
            }
            DataProcess process = s_khambenhcanlamsan();
            string bscd = Request.QueryString["bscd"];
            if (bscd != null && bscd != "")
            {
                process.data("tenbschidinh", bscd);
            }
            string nguoitiepnhan = Request.QueryString["idnguoidung"];
            if (nguoitiepnhan != null && nguoitiepnhan != "")
            {
                process.data("idnguoidung", nguoitiepnhan);
            }
            process.data("iddangkycls", iddangkycls);
            process.data("idkhambenh", "0");
            process.data("bntongphaitra", process.getData("thanhtien"));
            process.data("idkhoadangky", "16");
            process.data("isbhyt", "0");
            process.data("thanhtiendv", process.getData("thanhtien"));
            process.data("idkhoadangky", idkhoadangky);

            string maphieucls = process.getData("MaPhieuCLS");
            string IsDKK = process.getData("IsDKK");

            string idkhambenhcanlamsan = process.getData("idkhambenhcanlamsan");
            if (process.getData("idcanlamsan") != null && process.getData("idcanlamsan") != "" && process.getData("idcanlamsan") != "0")
            {

                string ngaythu = process.getData("ngaythu");
                if (ngaythu == null || ngaythu == "")
                {
                    ngaythu = sysdate;
                    process.data("ngaythu", sysdate);
                }
                else
                    if (gio != null && gio != "" && phut != null && phut != "")
                    {
                        string ngaythu_new = ngaythu + " " + gio + ":" + phut;
                        process.data("ngaythu", ngaythu_new);
                    }

                if (maphieucls == null || maphieucls == "")
                {
                    string idbenhnhan = process.getData("idbenhnhan");
                    if (idbenhnhan != null && idbenhnhan != "" && idbenhnhan != "0")
                    {
                        string sqlPrev = "SELECT TOP 1 MAPHIEUCLS FROM KHAMBENHCANLAMSAN WHERE CONVERT(NVARCHAR, NGAYTHU,120)=CONVERT(NVARCHAR, '" + ngaythu + "',120) AND IDBENHNHAN=" + process.getData("idbenhnhan") + " AND ISNULL(DATHU,0)=0 ORDER BY IDKHAMBENHCANLAMSAN DESC";
                        DataTable dtPrev = DataAcess.Connect.GetTable(sqlPrev);
                        if (dtPrev != null && dtPrev.Rows.Count > 0)
                            maphieucls = dtPrev.Rows[0][0].ToString();
                    }
                    if (maphieucls == null || maphieucls == "")
                        maphieucls = Request.QueryString["maphieucls"];
                    process.data("maphieucls", maphieucls);
                }

                if (process.getData("idkhambenhcanlamsan") != "")
                {
                    bool ok = process.Update();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                        return;
                    }
                }
                else
                {
                    process.data("dathu", "0");
                    bool ok = process.Insert();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                        return;
                    }
                }

            }
        }
        catch
        {
            Response.StatusCode = 500;
        }
    }

}

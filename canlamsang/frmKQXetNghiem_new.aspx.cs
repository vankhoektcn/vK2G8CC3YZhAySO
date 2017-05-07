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

public partial class canlamsang_frmKQXetNghiem_new : System.Web.UI.Page
{
    String dkmenu = "cls";
    private int n;
    private string tennhom = "";
    private string gioitinh = "";
    private string idbs = null;
    private string madangkyCLS = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                madangkyCLS = Request.QueryString["macls"];
                idbs = idbs = Request.QueryString["idbs"];
            }
            catch
            {
                madangkyCLS = "";
                idbs = SysParameter.UserLogin.IdBacSi(this);
            }
            loadPK();
            BindPListBacSi();
            showDSDV(lblMaCLS.Text.ToString());
            if (Request.QueryString["new"].ToString() == "0")
            {
                getDieuTriCLS();
            }
            else
            {
               // string list = txtMaKetQuaCLS.Value;
                //loadDieuTriCLS(madangkyCLS);
                UpdateMadangkyCLS();
                LayChiTietDichVuKham1();
            }
            loadThongTinBenhNhan();
        }
        dkmenu = Request.QueryString["dkmenu"].ToString();
        if (dkmenu == "tiepnhan")
        {
            placeMenu.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        }
        if (dkmenu == "thuphi")
        {
            placeMenu.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
        }
        if (dkmenu == "cls")
        {
            placeMenu.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
        }
        if (dkmenu == "laymau")
        {
            placeMenu.Controls.Add(LoadControl("~/canlamsang/menuLayMauThu.ascx"));
        }   
    }
    private void UpdateMadangkyCLS()
    {
        string maPhieuCls = Request.QueryString["macls"];
        if (!string.IsNullOrEmpty(maPhieuCls))
        {
            string sqlMaDkCLS = "update khambenhcanlamsan set madangkycls=" + maPhieuCls + " where maphieuCLS=" + maPhieuCls + "";
            bool kt = DataAcess.Connect.ExecSQL(sqlMaDkCLS);
        }
    }
    private void LayChiTietDichVuKham1()
    {
        string sqlDV = string.Format(@"SELECT mamaycls
                                            FROM DMMayCanLamSang
                                            WHERE mamaycls IN (SELECT b.mamaycls
                                            FROM khambenhcanlamsan k
                                            INNER JOIN banggiadichvu b ON k.idcanlamsan=b.idbanggiadichvu
                                            left join phongkhambenh pk on pk.idphongkhambenh =b.idphongkhambenh
                                            where pk.maphongkhambenh='XN' and  k.madangkycls={0})", madangkyCLS);
        DataTable dt = DataAcess.Connect.GetTable(sqlDV);
        string lmakq = "";
        if (dt != null)
        {
            foreach (DataRow r in dt.Rows)
            {

                lmakq = lmakq + madangkyCLS.Trim('\'') + "$" + r["mamaycls"] + "$" + DateTime.Today.ToString("dd/MM/yyyy") + "@";
            }
        }
        loadDieuTriCLS(lmakq);
    }
    private void loadPK()
    {
        string sql = "select * from phongkhambenh pk ";
        if (idbs != null && idbs != "" && idbs != "0")
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where bspk.idbacsi=" + idbs + " and pk.loaiphong=1";
        }
        else
        {
            sql += "where pk.loaiphong = 1 order by pk.tenphongkhambenh";
        }
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPK, dt, "idphongkhambenh", "tenphongkhambenh", "Chọn phòng/khoa");
        ddlPK.SelectedIndex = 0;
        if (ddlPK.Items.Count == 2)
        {
            ddlPK.SelectedIndex = 1;
        }
    }
    private void BindPListBacSi()
    {
        string strSQL = "SELECT * FROM bacsi WHERE idbacsi = " + idbs + " ORDER BY tenbacsi";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlBacSi, dt, "idbacsi", "tenbacsi", "Chọn tên bác sĩ CLS");
        ddlBacSi.SelectedIndex = 1;
    }
    private void loadThongTinBenhNhan()
    {
        DataTable dt = null;
        string sql = @"select top 1 bn.tenbenhnhan, bn.mabenhnhan,dbo.GetNamSinh(ngaysinh) as namsinh,tenbenhnhan,SOBHYT,
                        tengioitinh=DBO.GetGioiTinh(GioiTinh),kbcls.madangkycls,bn.idbenhnhan,kbcls.ngaythu  from benhnhan bn
                        left join khambenhcanlamsan kbcls on kbcls.idbenhnhan=bn.idbenhnhan 
                        where kbcls.madangkycls=" + madangkyCLS;
        dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            lblTenBN.Text = dt.Rows[0]["Tenbenhnhan"].ToString();
            lbMaBN.Text = dt.Rows[0]["mabenhnhan"].ToString();
            lblGioiTinh.Text = dt.Rows[0]["tengioitinh"].ToString();
            lblNamSinh.Text = dt.Rows[0]["namsinh"].ToString();
            lblMaCLS.Text = dt.Rows[0]["madangkycls"].ToString();
            txtMaDKCLS.Value = dt.Rows[0]["madangkycls"].ToString();
            lblNgayCLS.Text = DateTime.Parse(dt.Rows[0]["ngaythu"].ToString()).ToString("dd/MM/yyyy");
            txtidbenhnhan.Value = dt.Rows[0]["idbenhnhan"].ToString();
        }
        else
        {
            return;
        }
    }
    private void LayMaCLSSauPostBack()
    {
        string[] list = txtTemp.Value.Split('@');
        int k = 0;
        string html = "";
        html = " <span id=\"headerntt\">Thông tin máy cận lâm sàn</span>";
        html += "<table id=\"gridTableMay\" border=\"1\" cellpadding=\"1\" cellspacing=\"1\" width=\"600px\">";
        html += "<tr style =\"background-color: #4D67A2\">";
        html += "<td width=\"150px\" class=\"item\" style=\"color:white;font-weight:bold;\" >Mã KQ CLS</td>";
        html += "<td width=\"300px\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên dịch vụ - máy cận lâm sàn</td>";
        html += "<td width=\"100px\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày thực hiện</td>";
        html += "</tr>";
        for (int i = 0; i < list.Length; i++)
        { 
            if (list[i].ToString() != "")
            {
                k++;
                string[] listDetail = list[i].Split('$');
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" >";
                html += "<td width=\"150px\" class=\"ptext\" align = \"left\" style = \"padding-right:2px\"><input class=\"input\" type=\"text\" id=\"txtMaCLSan_" + (i + 1).ToString() + "\" value = \"" + listDetail[0].ToString() + "\" style =\"width:150px; text-align:left;\"" + (i == 0 ? "/ onblur=\"setValue();\"" : "") + "></td>";
                html += "<td width=\"300px\" class=\"ptext\" align = \"left\" style = \"padding-right:2px\"><input class=\"input\" type=\"text\" id=\"txtTenDV_" + (i + 1).ToString() + "\" value = \"" + listDetail[1].ToString() + "\" style =\"width:300px; text-align:left;\" ><input type=\"hidden\" id=\"txtmamaycls_" + (i + 1).ToString() + "\" value = \"" + listDetail[2].ToString() + "\" style =\"width:100px; text-align:left;\" /></td>";
                html += "<td width=\"100px\" class=\"ptext\" align = \"left\" style = \"padding-right:2px\"><input class=\"input\" type=\"text\" id=\"txtNgayThucHien_" + (i + 1).ToString() + "\" value = \"" + listDetail[3].ToString() + "\" style =\"width:100px; text-align:left;\" /></td>";
                html += "</tr>";
            }

        }
        html += "</table>";
        html += "<input type=\"hidden\" id=\"txtSodong1\" value = \"" + k+ "\" style =\"width:100px; text-align:left;\" >";
        showchidinhCLS.InnerHtml = html;
    }
    private void showDSDV(string madangkycls)
    {
        LayMaCLSSauPostBack();
        string idcls = madangkycls;
        string sqlDV = string.Format(@"SELECT mamaycls,tendichvu +ISNULL(' - '+tenmaycls,'') tendichvu
                                            FROM DMMayCanLamSang
                                            WHERE mamaycls IN (SELECT b.mamaycls
                                            FROM khambenhcanlamsan k
                                            INNER JOIN banggiadichvu b ON k.idcanlamsan=b.idbanggiadichvu
                                            where b.idphongkhambenh=14 and  k.madangkycls='{0}')", idcls);
        DataTable dt = DataAcess.Connect.GetTable(sqlDV);
        DateTime date = DateTime.Now;
        string ngaymacdinh = date.ToString("dd/MM/yyyy");
        string maketquacls = Request.QueryString["listmacls"];
        if (maketquacls == null) maketquacls = "";
        maketquacls = maketquacls.TrimEnd('@');
        string[] listMacls = maketquacls.Split('@');
        if (listMacls == null || listMacls.Length < dt.Rows.Count)
            listMacls = new string[dt.Rows.Count];

        string madangkycsl = madangkycls;
        if (dt != null && dt.Rows.Count > 0)
        {
            string html = "";
            html = " <span id=\"headerntt\">Thông tin máy cận lâm sàn</span>";
            html += "<table id=\"gridTableMay\" border=\"1\" cellpadding=\"1\" cellspacing=\"1\" width=\"600px\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"150px\" class=\"item\" style=\"color:white;font-weight:bold;\" >Mã KQ CLS</td>";
            html += "<td width=\"300px\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên dịch vụ - máy cận lâm sàn</td>";
            html += "<td width=\"100px\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày thực hiện</td>";
            html += "</tr>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tendichvu = dt.Rows[i]["tendichvu"].ToString();
                string mamaycls = dt.Rows[i]["mamaycls"].ToString();
                string macls = "";
                string ngaythuchien = "";
                string temma = listMacls[i];
                if (temma != null)
                {
                    string[] temp = temma.Split('$');
                    if (temp.Length > 2)
                    {
                        macls = temp[0];
                        ngaythuchien = temp[2];
                    }
                }

                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" >";
                html += "<td width=\"150px\" class=\"ptext\" align = \"left\" style = \"padding-right:2px\"><input class=\"input\" type=\"text\" id=\"txtMaCLSan_" + (i + 1).ToString() + "\" value = \"" + (macls != "" ? macls : madangkycsl) + "\" style =\"width:150px; text-align:left;\"" + (i == 0 ? "/ onblur=\"setValue();\"" : "") + "></td>";
                html += "<td width=\"300px\" class=\"ptext\" align = \"left\" style = \"padding-right:2px\"><input class=\"input\" type=\"text\" id=\"txtTenDV_" + (i + 1).ToString() + "\" value = \"" + tendichvu + "\" style =\"width:300px; text-align:left;\" ><input type=\"hidden\" id=\"txtmamaycls_" + (i + 1).ToString() + "\" value = \"" + mamaycls + "\" style =\"width:100px; text-align:left;\" /></td>";
                html += "<td width=\"100px\" class=\"ptext\" align = \"left\" style = \"padding-right:2px\"><input class=\"input\" type=\"text\" id=\"txtNgayThucHien_" + (i + 1).ToString() + "\" value = \"" + (ngaythuchien == "" ? ngaymacdinh : ngaythuchien) + "\" style =\"width:100px; text-align:left;\" /></td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<input type=\"hidden\" id=\"txtSodong1\" value = \"" + dt.Rows.Count.ToString() + "\" style =\"width:100px; text-align:left;\" >";
            showchidinhCLS.InnerHtml = html;
        }
        else
        {
            showchidinhCLS.InnerHtml = "";
        }
    }
    private void loadDieuTriCLS(string maketquacls)
    {
        string strDichVu = "";
        this.n = 1;
        string strSql = "";
        int k = 1;
        string madkcls = Request.QueryString["macls"];
        string where = "";
        madangkyCLS = Request.QueryString["macls"].ToString();
        if (!string.IsNullOrEmpty(maketquacls))
        {
            maketquacls = maketquacls.TrimEnd('@');
            string[] listMacls = maketquacls.Split('@');
            foreach (string str in listMacls)
            {
                string[] temps = str.Split('$');
                if (temps[0] == "") continue;
                if (where != "") where += " or ";
                where += string.Format("(kqtmc.maketqua='{0}' AND  kqtmc.loaimay='{1}' AND (convert(varchar(10),kqtmc.ngaythuchien,103)='{2}' or '{2}'=''))",
                    temps[0], temps[1], temps[2]);

            }

        }
        if (where == "")
        {
            strSql = "SELECT dv.idbanggiadichvu,dv.tendichvu,tennhomdichvu=dv.tennhom,ct.*, null giatri,null giatrichuoi,isTra=k.dahuy FROM banggiadichvu dv ";
            strSql += " left join chitietdichvu ct on  ct.idbanggiadichvu=dv.idbanggiadichvu";
            strSql += " left join khambenhcanlamsan k ON k.idcanlamsan=dv.idbanggiadichvu";
            //strSql += " WHERE dv.idbanggiadichvu IN ( ";
            //strSql += " SELECT idcanlamsan FROM khambenhcanlamsan ";
            //strSql += " WHERE dv.idphongkhambenh=25 and madangkycls=" +madangkyCLS;
            //strSql += ")"
            strSql += " where k.madangkycls="+madangkyCLS+"";
            strSql += " and IdPhongKhamBenh =" + Request.QueryString["idphongkhambenh"].ToString() + " order by dv.tennhom,dv.stt,ct.stt";
        }
        else
        {
            
            where = " AND " + where;
            strSql = string.Format(@"SELECT dv.idbanggiadichvu,dv.tendichvu,tennhomdichvu=dv.tennhom,
                                ct.* ,ketqua.giatri,ketqua.giatrichuoi,isTra=k.dahuy
                                FROM banggiadichvu dv 
                                left join chitietdichvu ct on  ct.idbanggiadichvu=dv.idbanggiadichvu
                                LEFT JOIN (SELECT kqtmc.loaimay,kqtmcc.tenthongso,kqtmcc.giatri,kqtmcc.giatrichuoi
                                FROM KetQuaTuMayCLS_CT kqtmcc
                                INNER JOIN KetQuaTuMayCLS kqtmc ON kqtmc.idKetQuaTuMayCLS = kqtmcc.idKetQuaTuMayCLS
                                WHERE 1=1 {0})
                                AS ketqua ON ketqua.loaimay=dv.mamaycls AND ct.machitiet=ketqua.tenthongso 
                                INNER JOIN khambenhcanlamsan k ON dv.idbanggiadichvu=k.idcanlamsan", where);
            strSql += " where k.madangkycls="+madangkyCLS+"";
            //strSql += " WHERE dv.idbanggiadichvu IN ( ";
            //strSql += " SELECT idcanlamsan FROM khambenhcanlamsan ";
            //strSql += " WHERE dv.idphongkhambenh=25 and madangkycls="+madkcls;
            //strSql += ")"
            strSql += " and IdPhongKhamBenh =" + Request.QueryString["idphongkhambenh"].ToString() + " order by dv.tennhom,dv.stt,ct.stt";//,ct.stt
        }
        DataTable dt = DataAcess.Connect.GetTable(strSql);
        string strTable = "";
        string MaPhong = Request.QueryString["MaPhong"];
        if (string.IsNullOrEmpty(MaPhong))
            MaPhong = "XN";
        if (dt != null && dt.Rows.Count > 0)
        {
            if (MaPhong.ToLower().Equals("xn"))
            {
                strTable = "";// <span id=\"headerntt\">Thông tin điều trị xét nghiệm</span>";
                strTable += "<table id=\"gridTableCLS\"  style=\"border: 2px solid #000000; border-bottom: none;\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">";
                strTable += "<tr style=\" width:100%;\">";
                strTable += "<td id=\"rowstyle\" style=\"width:20px;font-size:14px; font-weight:bold;border:1px solid #000000;border-right:2px solid #000000; border-top:none; border-left:none \" align=\"center\" rowspan=\"2\">IN</td>";
                strTable += "<td id=\"rowstyle\" style=\"width:60px;font-size:14px; font-weight:bold;border:1px solid #000000;border-right:2px solid #000000; border-top:none; border-left:none \" align=\"center\" rowspan=\"2\">STT</td>";
                strTable += "<td id=\"rowstyle\" style=\" max-width:400px;font-size:14px; font-weight:bold; border:1px solid #000000; border-right:2px solid #000000;border-top:none; border-left:none \"align=\"center\" rowspan=\"2\">TÊN XÉT NGHIỆM</td>";
                strTable += "<td id=\"rowstyle\" style=\" width:200px; font-size:14px; font-weight:bold;border:2px solid #000000;border-right:2px solid #000000; border-top:none; border-left:none \" align=\"center\">TRỊ SỐ BÌNH THƯỜNG</td>";
                strTable += "<td id=\"rowstyle\" style=\"width:200px; font-size:14px; font-weight:bold;border:1px solid #000000; border-right:2px solid #000000;border-top:none; border-left:none \" align=\"center\" rowspan=\"2\">KẾT QUẢ</td>";
                strTable += "<td id=\"rowstyle\" style=\"font-size:14px;width:100px; font-weight:bold;border:1px solid #000000; border-top:none; border-left:none ; border-right:none\" align=\"center\" rowspan=\"2\">&nbsp;ĐƠN VỊ</td>";
                strTable += "<td id=\"rowstyle\" style=\" border:1px solid #000000;border-right:none; font-weight:bold\" align=\"center\" rowspan=\"2\">BẤT THƯỜNG</td>";
                strTable += "<td id=\"rowstyle\" style=\" border:1px solid #000000;border-right:none; font-weight:bold;display: none;\" align=\"center\" rowspan=\"2\">TRẢ DỊCH VỤ</td>";
                strTable += "</tr>";
                strTable += "<tr>";
                strTable += " <td id=\"rowstyle\" align=\"center\" style=\"border-right: #000000 2px solid; border-top: #000000 0px solid;";
                strTable += "font-weight: bold; font-size: 14px; border-left: #000000 0px solid; width: 270px;";
                strTable += "border-bottom: #000000 1px solid\">NAM/NỮ</td>";
                strTable += "</tr>";
            }
            else
            {

                strTable += "<table id=\"gridTableCLS\" width=\"100%\" height=\"10%\"  cellpadding=\"0\" cellspacing=\"0\">";
                strTable += "<tr>";
                strTable += "<td style=\"font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">STT</td>";
                strTable += "<td style=\" font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Chiêu thể</td>";
                strTable += "<td style=\" font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Chi định</td>";
                strTable += "<td style=\"font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Kết quả</td>";
                //strTable += "<td style=\"width:200px; font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Giá trị bình thường</td> ";
                strTable += "<td style=\"  font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Ghi chú</td>";
                strTable += "</tr>";
            }
            int j = 0;
            int count = 0;
            int n = 0;
           // int k = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string isChecKBatThuong = "";
                DataRow row = dt.Rows[i];
                if (row["tennhomdichvu"].ToString() != tennhom)
                {
                    if (madangkyCLS == "")
                    {
                        madangkyCLS =madkcls;
                    }
                    string countNhom = "select count(idchitietdichvu) as SL from chitietdichvu ct"
                                       + " left join banggiadichvu dv on dv.idbanggiadichvu=ct.idbanggiadichvu"
                                        + " left join khambenhcanlamsan cls on cls.idcanlamsan=ct.idbanggiadichvu"
                                       + " where cls.madangkycls=" + madangkyCLS + " and dv.tennhom=N'" + row["tennhomdichvu"].ToString() + "'";
                    DataTable dtCountNhom = DataAcess.Connect.GetTable(countNhom);
                    n++;
                    strTable += "<tr style=\"height:25px;font-size:14px;\">"
                        +"<td style=\"border-bottom:1px solid #000000;border-top:1px  solid #000000; \" colspan=\"7\" valign=\"center\">"
                        +"<input class=\"checkbox\" type=\"checkbox\" id=\"ckbTenNhom_" + n + "\"/ onclick=\"checkNhom(" + n + "," + StaticData.ParseInt(dtCountNhom.Rows[0]["SL"]) + "," + i + ")\" /><b>&nbsp;" + row["tennhomdichvu"].ToString() + "<b></td></tr>";
                }
                strTable += "<tr style=\"height:30px;font-size:14px\" rules=\"group\">";
                #region 3 cột đầu IN, STT, TÊN XÉT NGHIỆM
                if (row["tenchitiet"].ToString() != "")
                {
                    if (row["tendichvu"].ToString() != strDichVu)
                    {
                        #region
                        string countSLCT = "select count(idchitietdichvu) as SL from chitietdichvu where idbanggiadichvu=" + row["idbanggiadichvu"].ToString();
                        DataTable dtCount = DataAcess.Connect.GetTable(countSLCT);
                        #endregion
                        count = StaticData.ParseInt(dtCount.Rows[0]["SL"].ToString());
                        if (count > 1)
                        {
                            strTable += "<td style=\"border:1px solid #000000;border-left:none;\"><input class=\"checkbox\" value=\"10\" onclick=\"checkAll(" + (count - 1) + "," + i + ");\" type=\"checkbox\" id=\"checkValue\" /></td>";
                            strTable += "<td style=\"border:1px solid #000000;	border-top:none;border-left:none \">&nbsp;" + (n).ToString() + "</td>";
                            strTable += "<td  style=\"table-layout:fixed;border:1px solid #000000;border-left:none;	border-top:none;height:20px \" colspan=\"7\">&nbsp;<b>" + row["tendichvu"].ToString() + "<b/><input type=\"hidden\" id=\"txtIdDichVu_" + i + "\" value=\"" + row["idbanggiadichvu"].ToString() + "\"/><input type=\"hidden\" id=\"txtIdChiTietDichVu_" + i + "\" value=\"" + row["idchitietdichvu"].ToString() + "\"/></td>";
                            strTable += "<td class=\"itemstyle\"></td>";
                            strTable += "<td class=\"itemstyle\"></td>";
                            strTable += "<td class=\"itemstyle\"></td>";
                            strTable += "<tr>";
                            strTable += "<td style=\"border:1px solid #000000;border-left:none;height:20px\"><input class=\"checkbox\" type=\"checkbox\" id=\"ckb_" + i + "\"/ /></td>";
                            strTable += "<td class=\"itemstyle\"></td>";
                            strTable += "<td style=\"table-layout:fixed;border:1px solid #000000;	border-top:none;\">&nbsp;" + row["tenchitiet"].ToString() + "<input type=\"hidden\" id=\"txtIdDichVu_" + i + "\" value=\"" + row["idbanggiadichvu"].ToString() + "\"/><input type=\"hidden\" id=\"txtIdChiTietDichVu_" + i + "\" value=\"" + row["idchitietdichvu"].ToString() + "\"/></td>";
                            n++;
                            j = 1;

                        }
                        else
                        {
                            strTable += "<td style=\"border:1px solid #000000;border-left:none;\"><input class=\"checkbox\" type=\"checkbox\" id=\"ckb_" + i + "\"/ /></td>";
                            strTable += "<td style=\" border:1px solid #000000;border-left:none; width:30px; text-align:center;height:20px\">&nbsp;" + (n).ToString() + "</td>";
                            strTable += "<td style=\"border:1px solid #000000;width:300px;text-align:left;table-layout:fixed;height:20px;border-left:none\">&nbsp;" + row["tenchitiet"].ToString() + "<input type=\"hidden\" id=\"txtIdDichVu_" + i + "\" value=\"" + row["idbanggiadichvu"].ToString() + "\"/><input type=\"hidden\" id=\"txtIdChiTietDichVu_" + i + "\" value=\"" + row["idchitietdichvu"].ToString() + "\"/></td>";
                            n++;

                        }
                    }
                    else
                    {
                        j++;
                        if (j == count)
                        {
                            strTable += "<td style=\"border:1px solid #000000;border-left:none;\"><input class=\"checkbox\" type=\"checkbox\" id=\"ckb_" + i + "\"/ /></td>";
                            strTable += "<td style=\" ;border:0px solid #000000;border-bottom:1px solid #000000; border-right:1px solid #000000;width:30px;font-size:14px; text-align:center;\">&nbsp;</td>";
                            j = 0;
                        }
                        else
                        {
                            strTable += "<td style=\"border:1px solid #000000;border-left:none;;height:20px\"><input class=\"checkbox\" type=\"checkbox\" id=\"ckb_" + i + "\"/ /></td>";
                            strTable += "<td style=\" border:0px solid #000000; border-right:1px solid #000000;width:30px;text-align:center;;height:20px\">&nbsp;</td>";

                        }
                        if (row["tenchitiet"].ToString() == row["tennhom"].ToString())
                        {
                            strTable += "<td style=\"border:1px solid #000000;width:300px; border-left:none;text-align:left;table-layout:fixed;font-size:14px;\">&nbsp;<b>" + row["tenchitiet"].ToString() + "<b/><input type=\"hidden\" id=\"txtIdDichVu_" + i + "\" value=\"" + row["idbanggiadichvu"].ToString() + "\"/><input type=\"hidden\" id=\"txtIdChiTietDichVu_" + i + "\" value=\"" + row["idchitietdichvu"].ToString() + "\"/></td>";
                        }
                        else
                        {
                            strTable += "<td style=\"border:1px solid #000000;width:300px;border-left:none; text-align:left;table-layout:fixed;font-size:14px;\">&nbsp;" + row["tenchitiet"].ToString() + "<input type=\"hidden\" id=\"txtIdDichVu_" + i + "\" value=\"" + row["idbanggiadichvu"].ToString() + "\"/><input type=\"hidden\" id=\"txtIdChiTietDichVu_" + i + "\" value=\"" + row["idchitietdichvu"].ToString() + "\"/></td>";
                        }


                    }
                }
                else
                {
                    strTable += "<td style=\"border:1px solid #000000;border-left:none\"><input class=\"checkbox\" type=\"checkbox\" id=\"ckb_" + i + "\"/ /></td>";
                    strTable += "<td style=\" border:1px solid #000000; border-left:0px solid #000000; width:30px;  text-align:center;\" align=\"center\">&nbsp;" + (n).ToString() + "</td>";
                    strTable += "<td style=\"border:1px solid #000000;width:300px; text-align:left;table-layout:fixed;font-size:14px;\">&nbsp;" + row["tendichvu"].ToString() + "<input type=\"hidden\" id=\"txtIdDichVu_" + i + "\" value=\"" + row["idbanggiadichvu"].ToString() + "\"/><input type=\"hidden\" id=\"txtIdChiTietDichVu_" + i + "\" value=\"" + row["idchitietdichvu"].ToString() + "\"/></td>";
                    n++;
                }
                #endregion
                #region cột GIÁ TRỊ BÌNH THƯƠNG
                if (row["tenchitiet"].ToString() == row["tennhom"].ToString())
                {
                    strTable += "<td style=\" border:1px solid #000000;border-left:none; width:260px;text-align:center;\"><input class=\"input\" style=\"height:30px\" type=\"text\" id=\"txtGiaTriBT_" + i + "\" value=\"" + row["giatribinhthuongnu"].ToString() + "\"/></td>";
                }
                else
                {
                    if (gioitinh == null || gioitinh.ToLower() == "nam")
                    {
                        strTable += "<td style=\" border:1px solid #000000;border-left:none; width:260px; text-align:center;\"><input class=\"input\" style=\"height:30px\" type=\"text\" id=\"txtGiaTriBT_" + i + "\" value=\"" + row["giatribinhthuongnu"].ToString() + "\"/></td>";
                    }
                    else
                    {
                        strTable += "<td style=\" border:1px solid #000000; border-left:none;width:260px; text-align:center;\"><input class=\"input\" style=\"height:30px\" type=\"text\" id=\"txtGiaTriBT_" + i + "\" value=\"" + row["giatribinhthuongnu"].ToString() + "\"/></td>";
                    }
                }
                #endregion
                #region cột KẾT QUẢ
                string kqGiaTri;
                if (row["giatrichuoi"].ToString() != "")
                {
                    strTable += "<td style=\" border:1px solid #000000;border-left:none; width:100px;text-align:center;\"><input style=\"height:30px\" type=\"text\" onkeydown='focusNextRowKQ(this);' ondblclick=\"showPopup(this,'" + row["idchitietdichvu"] + "');\" id=\"txtKQ_" + i + "\" value=\"" + row["giatrichuoi"].ToString() + "\"></td>";

                }
                else if (row["giatri"].ToString() != "")
                {
                    float? canduoi, cantren;
                    if (gioitinh == null || gioitinh.ToLower() == "nam")
                    {
                        if (row["canduoi"].ToString() != "")
                            canduoi = StaticData.ParseFloat(row["canduoi"].ToString());
                        else canduoi = null;
                        if (row["cantren"].ToString() != "")
                            cantren = StaticData.ParseFloat(row["cantren"].ToString());
                        else
                            cantren = null;
                    }
                    else
                    {
                        if (row["canduoinu"].ToString() != "")
                            canduoi = StaticData.ParseFloat(row["canduoinu"].ToString());
                        else canduoi = null;
                        if (row["cantrennu"].ToString() != "")
                            cantren = StaticData.ParseFloat(row["cantrennu"].ToString());
                        else
                            cantren = null;
                    }
                    kqGiaTri = row["giatri"].ToString();
                    float kq = StaticData.ParseFloat(kqGiaTri);
                    if (kqGiaTri.Contains(".") == false && kqGiaTri.Contains(",") == false)
                    {
                        kqGiaTri = kq.ToString("#.0");
                    }
                    if (canduoi != null && cantren != null)
                    {
                        if (kq < canduoi.Value || kq > cantren.Value)
                        {
                            kqGiaTri=""+kqGiaTri;
                            isChecKBatThuong = "checked=\"checked\"";
                        }

                    }
                    else if (canduoi != null && cantren == null)
                    {
                        if (kq <= canduoi.Value)
                        {
                            kqGiaTri = "" + kqGiaTri;
                            isChecKBatThuong = "checked=\"checked\"";
                        }

                    }
                    else if (canduoi == null && cantren != null)
                    {
                        if (kq >= cantren.Value)
                        {
                            kqGiaTri = "" + kqGiaTri;
                            isChecKBatThuong = "checked=\"checked\"";
                        }

                    }
                    if (isChecKBatThuong != "")
                    {
                        strTable += "<td style=\" border:1px solid #000000;border-left:0px; width:100px;text-align:center;\"><input class=\"input\" type=\"text\" style=\"height:30px ;font-weight:bold; color: red\" size=50 onkeydown='focusNextRowKQ(this);' ondblclick=\"showPopup(this,'" + row["idchitietdichvu"] + "');\"  id=\"txtKQ_" + i + "\" value=\"" + kqGiaTri + "\"/></td>";
                    }
                    else
                    {
                        strTable += "<td style=\" border:1px solid #000000;border-left:0px; width:100px;text-align:center;\"><input class=\"input\" style=\"height:30px;\" type=\"text\" size=50 onkeydown='focusNextRowKQ(this);' ondblclick=\"showPopup(this,'" + row["idchitietdichvu"] + "');\" id=\"txtKQ_" + i + "\" value=\"" + kqGiaTri + "\"/></td>";

                    }
                }
                else
                {
                    strTable += "<td style=\" border:1px solid #000000;border-left:none; width:100px;text-align:center;\" ";
                    strTable += "><input class=\"input\" style=\"height:30px\" type=\"text\" onkeydown='focusNextRowKQ(this);' ondblclick=\"showPopup(this,'" + row["idchitietdichvu"] + "');\" id=\"txtKQ_" + i + "\"/></td>";
                }
                #endregion
                #region cột ĐƠN VỊ, BẤT THƯỜNG
                if (row["tenchitiet"].ToString() == row["tennhom"].ToString())
                {
                    strTable += "<td style=\"border:1px solid #000000;border-left:none; border-right:0px solid #000000;text-align:center;\">&nbsp;<b>" + row["donvi"].ToString() + "<b/></td>";
                    strTable += "<td style=\" border:1px solid #000000;border-right:none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\" " + isChecKBatThuong + "  id=\"ckbBatThuong_" + i + "\"/ /></td>";
                    if (row["isTra"].ToString()=="True")
                    {
                        strTable += "<td style=\" border:1px solid #000000;border-right:none;display: none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\"  id=\"ckbTraDV_" + i + "\"checked=\"checked\"/ /></td>";
                    }
                    else
                    {
                        strTable += "<td style=\" border:1px solid #000000;border-right:none;display: none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\"  id=\"ckbTraDV_" + i + "\"/ /></td>";
                    }
                    k++;
                }
                else
                {
                    strTable += "<td style=\"border:1px solid #000000; border-left:none;border-right:0px solid #000000;text-align:center;\">&nbsp;" + row["donvi"].ToString() + "</td>";
                    strTable += "<td style=\" border:1px solid #000000;border-right:none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\" " + isChecKBatThuong + "  id=\"ckbBatThuong_" + i + "\"/ /></td>";
                    k++;
                    if (row["isTra"].ToString() == "True")
                    {
                strTable += "<td id=\"rowstyle\" style=\" width:200px; font-size:14px; font-weight:bold;border:2px solid #000000;border-right:2px solid #000000; border-top:none; border-left:none \" align=\"center\">TRỊ SỐ BÌNH THƯỜNG</td>";
                strTable += "<td style=\" border:1px solid #000000;border-right:none;display: none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\"  id=\"ckbTraDV_" + i + "\"checked=\"checked\"/ /></td>";
                    }
                    else
                    {
                        strTable += "<td style=\" border:1px solid #000000;border-right:none;display: none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\"  id=\"ckbTraDV_" + i + "\"/ /></td>";
                    }
                    //strTable += "<td style=\" border:1px solid #000000;border-right:none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\" " + isChecKBatThuong + " id=\"ckbBatThuong_" + i + "\"/ /></td>";
                    //strTable += "<td style=\" border:1px solid #000000;border-right:none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\"  id=\"ckbTraDV_" + i + "\"/ /></td>";
                }
                #endregion
                strTable += "</tr>";
               
                //strTable += LayChiTietMotDichVu(int.Parse(row["idbanggiadichvu"].ToString()), row["tennhom"].ToString(), row["tendichvu"].ToString());
                tennhom = row["tennhomdichvu"].ToString();
                strDichVu = row["tendichvu"].ToString();
            }
            strTable += "</table>";
            strTable += "<input type=\"hidden\" value=\""+k+"\" id=\"txtSoDong\"/>";
            //strTable += "<table style=\"border: 0px solid #000000;\" width=\"900px\" cellpadding=\"0\" cellspacing=\"0\">";
            //strTable += "<tr><td style=\"border-left:none\" colspan=\"5\"></td><tr/><tr><td style=\"line-height:110%;text-align:center;font-size:18px;padding-left:70%\" valign=\"top\">Ngày " + DateTime.Now.ToString("dd/MM/yyyy") + "<br/>";
            //strTable += "&nbsp;Bác sĩ xét nghiệm<br/><br/><br/><br/><br/><br/><br/>TS.BS MAI VĂN ĐIỂN</td></tr></table>";
        }
        divDieuTri.InnerHtml = strTable;
    }
    private DataTable loadDichVu(string madangkls)
    {
        string swhere = "";
        if (madangkls != "")
        {
            swhere = " WHERE KQ_CLS.MADANGKYCLS=" + madangkls;
        }
        string sqlDV = @"SELECT DV_CT.IDCHITIETDICHVU,CLS_CT.idketqua_canlamsang,CLS_CT.isBatThuong,DV.IDBANGGIADICHVU,CLS_CT.IDCHITIETDICHVU,DV.TENNHOM,DV.TENDICHVU,CLS_CT.KETQUA,GIATRIBT=CLS_CT.GIATRIBINHTHUONG,DV_CT.DONVI,
                    CASE WHEN isnull(tenchitiet,'')<>'' THEN TENCHITIET ELSE TENDICHVU END AS TENCHITIET,isTra=k.dahuy
                    FROM ketqua_canlamsangchitiet CLS_CT
                    LEFT JOIN ketqua_canlamsang KQ_CLS ON CLS_CT.IDKETQUA_CANLAMSANG=KQ_CLS.IDKETQUA_CANLAMSANG
                    LEFT JOIN BANGGIADICHVU DV ON DV.IDBANGGIADICHVU=CLS_CT.IDBANGGIADICHVU
                    LEFT JOIN CHITIETDICHVU DV_CT ON DV_CT.IDCHITIETDICHVU=CLS_CT.IDCHITIETDICHVU
                    LEFT JOIN khambenhcanlamsan  k ON k.idcanlamsan=dv.idbanggiadichvu AND k.madangkyCLS=kq_cls.madangkycls " + swhere + " order by tennhom,dv.STT,DV_CT.stt";//,DV_CT.stt desc

        DataTable dtDV = null;
        dtDV = DataAcess.Connect.GetTable(sqlDV);
        return dtDV;
    }
    private void getDieuTriCLS()
    {
        DataTable dtDV = loadDichVu(madangkyCLS);
        string tennhom = "";
        string tendichvu = "";
        string tenchitiet = "";
        string iddv = "";
        string html = "";
        int k = 1;

        html = "";// <span id=\"headerntt\">Thông tin điều trị xét nghiệm</span>";
        html += "<table id=\"gridTableCLS\" style=\"border: 2px solid #000000; border-bottom: none;\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">";
        html += "<tr style=\" width:100%;\">";
        html += "<td id=\"rowstyle\" style=\"width:20px;font-size:14px; font-weight:bold;border:1px solid #000000;border-right:2px solid #000000; border-top:none; border-left:none \" align=\"center\" rowspan=\"2\">IN</td>";
        html += "<td id=\"rowstyle\" style=\"width:60px;font-size:14px; font-weight:bold;border:1px solid #000000;border-right:2px solid #000000; border-top:none; border-left:none \" align=\"center\" rowspan=\"2\">STT</td>";
        html += "<td id=\"rowstyle\" style=\" max-width:400px;font-size:14px; font-weight:bold; border:1px solid #000000; border-right:2px solid #000000;border-top:none; border-left:none \"align=\"center\" rowspan=\"2\">TÊN XÉT NGHIỆM</td>";
        html += "<td id=\"rowstyle\" style=\" width:200px; font-size:14px; font-weight:bold;border:2px solid #000000;border-right:2px solid #000000; border-top:none; border-left:none \" align=\"center\">TRỊ SỐ BÌNH THƯỜNG</td>";
        html += "<td id=\"rowstyle\" style=\"width:200px; font-size:14px; font-weight:bold;border:1px solid #000000; border-right:2px solid #000000;border-top:none; border-left:none \" align=\"center\" rowspan=\"2\">KẾT QUẢ</td>";
        html += "<td id=\"rowstyle\" style=\"font-size:14px;width:100px; font-weight:bold;border:1px solid #000000; border-top:none; border-left:none ; border-right:none\" align=\"center\" rowspan=\"2\">&nbsp;ĐƠN VỊ</td>";
        html += "<td id=\"rowstyle\" style=\" border:1px solid #000000;border-right:none; font-weight:bold\" align=\"center\" rowspan=\"2\">BẤT THƯỜNG</td>";
        html += "<td id=\"rowstyle\" style=\" border:1px solid #000000;border-right:none; font-weight:bold;display: none;\" align=\"center\" rowspan=\"2\">TRẢ DỊCH VỤ</td>";
        html += "</tr>";
        html += "<tr>";
        html += " <td id=\"rowstyle\" align=\"center\" style=\"border-right: #000000 2px solid; border-top: #000000 0px solid;";
        html += "font-weight: bold; font-size: 14px; border-left: #000000 0px solid; width: 270px;";
        html += "border-bottom: #000000 1px solid\">NAM/NỮ</td>";
        html += "</tr>";


        if (dtDV != null&&dtDV.Rows.Count>0)
        {
            int count = 0;
            int n = 0;
            int temp = 0;
            DataRow r = null;
            string isChecKBatThuong = "";
            string isChecKTra = "";
            string format = "";
            for (int i = 0; i < dtDV.Rows.Count; i++)
            {
                k++;
                isChecKBatThuong = "";
                format = "style=\"height:30px\"";
                r = dtDV.Rows[i];
                if (r["tennhom"].ToString() != tennhom)
                {
                    string countNhom = "select count(idchitietdichvu) as SL from ketqua_canlamsangchitiet ct"
                                       +" left join banggiadichvu dv on dv.idbanggiadichvu=ct.idbanggiadichvu"
                                       +" left join ketqua_canlamsang kq on kq.idketqua_canlamsang=ct.idketqua_canlamsang "
                                       + " where dv.tennhom=N'" + r["tennhom"].ToString() + "' and madangkycls="+madangkyCLS;
                    DataTable dtCountNhom = DataAcess.Connect.GetTable(countNhom);
                    temp++;
                    //html += "<tr><td style=\"font-size:14px;border-bottom:1px solid #000000;border-top:1px  solid #000000; \" colspan=\"5\" valign=\"center\"><b>&nbsp;" + r["tennhom"].ToString() + "<b></td></tr>";
                    html += "<tr><td style=\"border: black 1px solid;font-weight:bold\" colspan=\"7\"><input class=\"checkbox\" type=\"checkbox\" id=\"ckbTenNhom_" + temp + "\"/ onclick=\"checkNhom(" + temp + "," + StaticData.ParseInt(dtCountNhom.Rows[0]["SL"]) + ","+i+")\" />  &nbsp;" + "\r\n"
                    + "" + r["tennhom"].ToString() + "</td></tr>" + "\r\n";
                    tennhom = r["tennhom"].ToString();
                }
                #region
                string countSLCT = "select count(idchitietdichvu) as SL from chitietdichvu where idbanggiadichvu=" + r["IDBANGGIADICHVU"].ToString();
                DataTable dtCount = DataAcess.Connect.GetTable(countSLCT);
                #endregion
                count = StaticData.ParseInt(dtCount.Rows[0]["SL"].ToString());
                if (r["isBatThuong"].ToString() == "True")
                {
                    isChecKBatThuong = "checked=\"checked\"";
                    format = "style=\"font-weight:bold; color: red;height:30px\"";
                };
                if (r["isTra"].ToString() == "True")
                {
                    isChecKTra = "checked=\"checked\"";
                    format = "style=\"font-weight:bold; color: red;height:30px\"";
                };
                    
                if (count > 1)
                {
                    tenchitiet = r["tenchitiet"].ToString();
                    tendichvu = r["tendichvu"].ToString();
                    if (tendichvu == tenchitiet)
                    {
                        n++;
                        html += ""
                        + " <tr>" + "\r\n"
                        + "<td style=\"border:1px solid #000000;border-right:none;\"><input class=\"checkbox\" type=\"checkbox\" id=\"ckb_" + i + "\"/ /></td>"
                        + "                     <td rowspan=\"1\" style=\"border: black 1px solid;\" align=\"center\">&nbsp;" + "\r\n"
                        + "                       " + n.ToString() + "</td>" + "\r\n"
                        + "                     <td rowspan=\"1\" style=\"border: black 1px solid;border-left:none\"> &nbsp;" + "\r\n"
                        + "                         " + r["tenchitiet"].ToString() + "<input type=\"hidden\" id=\"txtIdDichVu_" + i + "\" value=\"" + r["idbanggiadichvu"].ToString() + "\"/><input type=\"hidden\" id=\"txtIdChiTietDichVu_" + i + "\" value=\"" + r["idchitietdichvu"].ToString() + "\"/></td>" + "\r\n"
                        + "                     <td style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                        + "                        <input class=\"input\" type=\"text\" id=\"txtGiaTriBT_" + i + "\" value=\"" + r["GiaTriBT"].ToString() + "\"/></td>" + "\r\n"
                        + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                        + "                         <input class=\"input\"  type=\"text\" " + format + " onkeydown='focusNextRowKQ(this);' ondblclick=\"showPopup(this,'" + r["idchitietdichvu"].ToString() + "');\" id=\"txtKQ_" + i + "\" value=\"" + r["ketqua"].ToString() + "\"/></td>" + "\r\n"
                        + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                        + "                        " + r["DonVi"].ToString() + "</td>" + "\r\n"
                        + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\" " + isChecKBatThuong + " id=\"ckbBatThuong_" + i + "\"/ /></td>"
                        + "                      <td rowspan=\"1\" style=\"border: 1px solid;display: none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\" " + isChecKTra + " id=\"ckbTraDV_" + i + "\"/ /></td>"
                        + "                 </tr>" + "\r\n";
                    }
                    else
                    {
                        if (r["IDBANGGIADICHVU"].ToString() != iddv)
                        {
                            n++;
                            html += ""
                               + " <tr>" + "\r\n"
                               + "<td style=\"border:1px solid #000000;border-right:none;\"><input class=\"checkbox\" type=\"checkbox\" id=\"checkValue\" onclick=\"checkAll(" + (count - 1) + "," + i + ")\" /></td>"
                               + "                     <td rowspan=\"1\" style=\"border: black 1px solid;\" align=\"center\">" + "\r\n"
                               + "                       " + n.ToString() + "</td>" + "\r\n"
                               + "                     <td rowspan=\"1\" style=\"border: black 1px solid;border-left:none;font-weight:bold\"> &nbsp;" + "\r\n"
                               + "                         " + r["tendichvu"].ToString() + "</td>" + "\r\n"
                               + "                     <td style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                               + "                        </td>" + "\r\n"
                               + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                               + "                        </td>" + "\r\n"
                               + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                               + "                       </td>" + "\r\n"
                                + "<td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"></td>"

                               + "                 </tr>" + "\r\n";
                            iddv = r["IDBANGGIADICHVU"].ToString();
                        }
                        html += ""
                        + " <tr>" + "\r\n"
                        + "<td style=\"border:1px solid #000000;border-right:none;\"><input class=\"checkbox\" type=\"checkbox\" id=\"ckb_" + i + "\"/ /></td>"
                        + "                     <td rowspan=\"1\" style=\"border-left: black 1px solid;\" align=\"center\">&nbsp;" + "\r\n"
                        + "                       </td>" + "\r\n"
                        + "                     <td rowspan=\"1\" style=\"border: black 1px solid;\"> &nbsp;" + "\r\n"
                        + "                         " + r["tenchitiet"].ToString() + "<input type=\"hidden\" id=\"txtIdDichVu_" + i + "\" value=\"" + r["idbanggiadichvu"].ToString() + "\"/><input type=\"hidden\" id=\"txtIdChiTietDichVu_" + i + "\" value=\"" + r["idchitietdichvu"].ToString() + "\"/></td>" + "\r\n"
                        + "                     <td style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                        + "                       <input class=\"input\" style=\"height:30px\" type=\"text\" id=\"txtGiaTriBT_" + i + "\" value=\"" + r["GiaTriBT"].ToString() + "\"/></td>" + "\r\n"
                        + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                        + "                         <input class=\"input\" type=\"text\" " + format + " onkeydown='focusNextRowKQ(this);' ondblclick=\"showPopup(this,'" + r["idchitietdichvu"].ToString() + "');\" id=\"txtKQ_" + i + "\" value=\"" + r["ketqua"].ToString() + "\"/></td>" + "\r\n"
                        + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                        + "                        " + r["DonVi"].ToString() + "</td>" + "\r\n"
                        + "                 <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\" " + isChecKBatThuong + " id=\"ckbBatThuong_" + i + "\"/ /></td>"
                        + "                 <td rowspan=\"1\" style=\"border: 1px solid;display: none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\" " + isChecKTra + " id=\"ckbTraDV_" + i + "\"/ /></td>"
                        + "                 </tr>" + "\r\n";
                    }
                }
                else
                {
                    n++;
                    html += ""
                    + " <tr>" + "\r\n"
                    + "<td style=\"border:1px solid #000000;border-right:none;\"><input class=\"checkbox\" type=\"checkbox\" id=\"ckb_" + i + "\"/ /></td>"
                    + "                     <td rowspan=\"1\" style=\"border: black 1px solid;\" align=\"center\">&nbsp;" + "\r\n"
                    + "                       " + n.ToString() + "</td>" + "\r\n"
                    + "                     <td rowspan=\"1\" style=\"border: black 1px solid;border-left:none\"> &nbsp;" + "\r\n"
                    + "                         " + r["tenchitiet"].ToString() + "<input type=\"hidden\" id=\"txtIdDichVu_" + i + "\" value=\"" + r["idbanggiadichvu"].ToString() + "\"/><input type=\"hidden\" id=\"txtIdChiTietDichVu_" + i + "\" value=\"" + r["idchitietdichvu"].ToString() + "\"/></td>" + "\r\n"
                    + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                    + "                        <input class=\"input\" style=\"height:30px\" type=\"text\" id=\"txtGiaTriBT_" + i + "\" value=\"" + r["GiaTriBT"].ToString() + "\"/></td>" + "\r\n"
                    + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                    + "                         <input class=\"input\" type=\"text\" " + format + " onkeydown='focusNextRowKQ(this);' ondblclick=\"showPopup(this,'" + r["idchitietdichvu"].ToString() + "');\" id=\"txtKQ_" + i + "\" value=\"" + r["ketqua"].ToString() + "\"/></td>" + "\r\n"
                    + "                     <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"> &nbsp;" + "\r\n"
                    + "                        " + r["DonVi"].ToString() + "</td>" + "\r\n"
                    + "                 <td rowspan=\"1\" style=\"border: 1px solid;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\" " + isChecKBatThuong + " id=\"ckbBatThuong_" + i + "\"/ /></td>"
                    + "                 <td rowspan=\"1\" style=\"border: 1px solid;display: none;\" align=\"center\"><input class=\"checkbox\" type=\"checkbox\" " + isChecKTra + " id=\"ckbTraDV_" + i + "\"/ /></td>"
                    + "                 </tr>" + "\r\n";
                }
            }
            txtIdKQCLS.Value = (dtDV.Rows[0]["idketqua_canlamsang"] != null ? dtDV.Rows[0]["idketqua_canlamsang"].ToString() : "");
        }
        html += "<input type=\"hidden\" value=\"" + k + "\" id=\"txtSoDong\"/>";
        //html += "<input type=\"hidden\" id=\"txtIdKQCLS\" value=\"" + dtDV.Rows[0]["idketqua_canlamsang"].ToString() + "\" runat=\"server\"/>";
        html += "  </table>";
        divDieuTri.InnerHtml = html;

    }
    protected void btnLayKQ_Click(object sender, EventArgs e)
    {
            string list = txtMaKetQuaCLS.Value;
            loadDieuTriCLS(list);
            LayMaCLSSauPostBack();
    }
}

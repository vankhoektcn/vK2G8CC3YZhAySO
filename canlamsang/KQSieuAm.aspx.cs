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
using System.IO;

public partial class KQSieuAm : Genaratepage
{
    string idbs = null;
    private string tendichvu = "";
    private string gioitinh = "";
    private string idbnhan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
         
            if (Request.QueryString["idbn"] != null)
            {
                if(!IsPostBack){
                BenhNhanInfo();
                txtChiDinhBacSi.Value = loaddieutriCLS(StaticData.ParseInt(Request.QueryString["idbn"]));
                loadPhieuHen(StaticData.ParseInt(Request.QueryString["idbn"]));
                btnAdd.Visible = false;
                return;
                }
            }
      
                else
                {
                    idbs = Request.QueryString["idbs"];
                }
            }
        catch
        {
            return;   
        }
      
        if (!IsPostBack)
        {
            string maPhieuCls=Request.QueryString["madangky"];
            if (!string.IsNullOrEmpty(maPhieuCls))
            {
                string sqlMaDkCLS = "update khambenhcanlamsan set madangkycls='" + maPhieuCls + "' where maphieuCLS='" + maPhieuCls + "'";
                bool kt= DataAcess.Connect.ExecSQL(sqlMaDkCLS);
            }
            VisibleBtn(true);
            SetValueEmpty();
            BindPListBacSi();
            bindNgaykham();
            loadPK();
            string idPhongKhamBenh = Request.QueryString["IdPhongKhamBenh"];
            ddlPK.SelectedValue = idPhongKhamBenh;
            LoadThongTinBenhNhan();
            int inew = StaticData.ParseInt(Request.QueryString["new"]);
            if (Session["idDieutri"] != null)
            {
                VisibleBtn(false);
                iddieutri.Value = Session["idDieutri"].ToString();
                LoadDataThamBenh(StaticData.ParseInt(Session["idDieutri"]));
            }
            else
            {
                iddieutri.Value = "0";
                txtChiDinhBacSi.Value = LayChiTietDichVuKham();
            }
            btnAdd.Attributes.Add("Onclick", "CheckInfoThamBenhCLS()");
            btnEdit.Attributes.Add("Onclick", "CheckInfoThamBenhCLS()");
            txtGioHen.Text = DateTime.Now.ToString(" HH:mm");
            txtNgayHen.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            if (action.Value == "Y")
            {

                if (Session["idDieutri"] == null)
                {
                    LuuKetQuaThambenh();
                }
                else
                {
                    CapNhatKetQuaThambenh(StaticData.ParseInt(Session["idDieutri"]));
                }

            }
            else if (action.Value == "C")
            {
                HistoryReturn();
            }
        }

    }
    private void loadPK()
    {
        string sql = "select * from phongkhambenh pk ";
        if (this.idbs!=null &&this.idbs!="" &&this.idbs!="0")
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where bspk.idbacsi=" + this.idbs.ToString() + "";
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

    private void bindNgaykham()
    {
        string strSQL = "SELECT distinct ngaythu FROM khambenhcanlamsan WHERE idbenhnhan=" + Session["idbnCLS"] + " and idkhambenhcanlamsan in ( " + Session["idkhachlecanlamsan"].ToString() + ")";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        if (dt != null && dt.Rows.Count != 0)
        {
            txtngayCLS.Text = DateTime.Parse(dt.Rows[0]["ngaythu"].ToString()).ToString("dd/MM/yyyy");
        }
    }
    private string loadKQCuBN(string idbn)
    {
        string table = "";
        string sqlSA = "Select count(soID) from dieutricanlamsan where idbenhnhan=" + idbn + " and idphongkhambenh=5";
        int dtCount = StaticData.ParseInt(DataAcess.Connect.GetTable(sqlSA).Rows[0][0]);
        if (dtCount >= 1)
        {
                string layKQ = "select top 1 ketqua from dieutricanlamsan where  idphongkhambenh=5 and idbenhnhan=" + idbnhan + " order by iddieutricanlamsan desc";
                DataTable dtKQ = DataAcess.Connect.GetTable(layKQ);
                table = dtKQ.Rows[0][0].ToString();
        }
        return table;
    }
    private int n = 1;
    private string LayChiTietDichVuKham()
    {
        string strTable = "";
        string KQcu=loadKQCuBN(idbnhan);
        if (KQcu != "")
        {
            strTable = KQcu;
        }
        else
        {
            this.n = 0;
            string strSql = "SELECT dv.idbanggiadichvu, dv.tendichvu FROM banggiadichvu dv ";
            strSql += "WHERE dv.idbanggiadichvu IN ( ";
            strSql += "SELECT idcanlamsan FROM khambenhcanlamsan ";
            strSql += "WHERE  idkhambenhcanlamsan in ( " + Session["idkhachlecanlamsan"].ToString() + ")";
            strSql += ")"
            + " and IdPhongKhamBenh =" + Request.QueryString["idphongkhambenh"].ToString();
            DataTable dt = DataAcess.Connect.GetTable(strSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string idPhongKham_ = string.IsNullOrEmpty(Request.QueryString["IdPhongKhamBenh"]) ? "0" : Request.QueryString["IdPhongKhamBenh"].ToString();
                string MaPhong = string.IsNullOrEmpty(Request.QueryString["MaPhong"]) ? "SA" : Request.QueryString["MaPhong"].ToString();
                //string MaPhong = DataAcess.Connect.GetTable("select isnull((select maphongkhambenh from phongkhambenh where idphongkhambenh ='" + idPhongKham_ + "'),'')").Rows[0][0].ToString();

                if (MaPhong.ToUpper() == "SA")
                {
                    strTable = "<table  width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" rules=\"all\" style=\"text-align:top\">";
                    strTable += "<tr>";
                    strTable += "<td style=\"width:160px;font-weight:bold;font-size:22px;border:1px solid #000000; border-bottom: none;\" valign=\"center\">&nbsp; GAN:</div></td>";
                    strTable += "<td style=\"line-height:125%;border:1px solid #000000;font-size:24px; border-bottom: none;height:78px\" valign=\"middle\">&nbsp;Không to,&nbsp;đồng nhất,&nbsp;bờ đều</br>&nbsp;Các TM trên gan và TM cửa bình thường</td></tr>";
                    strTable += "<tr><td style=\"width:160px;font-weight:bold;font-size:22px;border:1px solid #000000; border-bottom: none;\" valign=\"center\">&nbsp; ĐƯỜNG MẬT:</td>";
                    strTable += "<td style=\"line-height:115%;border:1px solid #000000; font-size:24px;border-bottom: none;height:60px\">&nbsp;Trong và ngoài gan không giãn.&nbsp;Không thấy sỏi</td></tr>";
                    strTable += "<tr><td style=\"width:160px;font-weight:bold;font-size:22px;border:1px solid #000000; border-bottom: none;\" valign=\"center\">&nbsp; TÚI MẬT:</td>";
                    strTable += "<td style=\"line-height:115%;border:1px solid #000000;font-size:24px; border-bottom: none;height:65px\">&nbsp;Vách đều,&nbsp;không dày,&nbsp;lòng không thấy gì lạ</td></tr>";
                    strTable += "<tr><td style=\"width:150px;font-weight:bold;font-size:22px;border:1px solid #000000; border-bottom: none;\" valign=\"center\">&nbsp; LÁCH:</td>";
                    strTable += "<td style=\"line-height:115%;border:1px solid #000000; font-size:24px;border-bottom: none;height:65px\">&nbsp;Không to,&nbsp;đồng nhất</td></tr>";
                    strTable += "<tr><td style=\"width:160px;font-weight:bold;font-size:22px;border:1px solid #000000; border-bottom: none;\" valign=\"center\">&nbsp; TỤY:</td>";
                    strTable += "<td style=\"line-height:110%;border:1px solid #000000; font-size:24px;border-bottom: none;height:65px\">&nbsp;Không to,&nbsp;đồng nhất</td></tr>";
                    strTable += "<tr><td style=\"width:150px;font-weight:bold;font-size:22px;border:1px solid #000000; border-bottom: none;\" valign=\"center\">&nbsp; THẬN:</div></td>";
                    strTable += "<td style=\"line-height:110%;border:1px solid #000000; font-size:24px;border-bottom: none;height:280px\">&nbsp;<u>Thận phải</u>:&nbsp;Cấu trúc và kích thước:&nbsp;bình thường.&nbsp;Phân biệt vỏ-tủy rõ,&nbsp;không ứ nước,&nbsp;không thấy sỏi<br/><br/>&nbsp;Niệu quản phải:&nbsp;không giãn.&nbsp;Thượng thận:&nbsp;không thấy";
                    strTable += "<br/><br/>&nbsp;<u>Thận trái</u>:Cấu trúc và kích thước:&nbsp;bình thường.&nbsp;Phân biệt vỏ-tủy rõ,&nbsp;không ứ nước,&nbsp;không thấy sỏi</br><br/>&nbsp;Niệu quản trái:&nbsp;không giãn.&nbsp;Thượng thận:&nbsp;không thấy</td></tr>";
                    strTable += "<tr><td style=\"width:180px;font-weight:bold;font-size:22px;border:1px solid #000000; border-bottom: none;\" valign=\"center\">&nbsp; BÀNG QUANG:</td>";
                    strTable += "<td style=\"line-height:115%;border:1px solid #000000;font-size:24px; border-bottom: none;height:65px\">&nbsp;Thành đều,&nbsp;lòng phản âm trống</td></tr>";

                    if (gioitinh.ToUpper() == "NAM")
                    {
                        strTable += "<tr><td style=\"width:170px;font-weight:bold;font-size:22px;border:1px solid #000000; border-bottom: none;text-align:center\" valign=\"center\">&nbsp; TIỀN LIỆT TUYẾN:</td>";
                        strTable += "<td style=\"line-height:115%;border:1px solid #000000; font-size:24px;border-bottom: none;height:65px\">&nbsp;Không to,&nbsp;khá đồng nhất,&nbsp;vỏ bọc đều</td></tr>";
                    }
                    else
                    {
                        strTable += "<tr><td style=\"width:160px;font-weight:bold;font-size:22px;border:1px solid #000000;text-align:center\" valign=\"center\">&nbsp; TỬ CUNG &&nbsp; 2 PHẦN PHỤ:</td>";
                        strTable += "<td style=\"line-height:115%;border:1px solid #000000;font-size:24px; border-bottom: none;height:65px\">&nbsp;Tư thế và kích thước bình thường (theo tuổi)</td></tr>";
                    }

                    strTable += "<tr><td style=\"width:160px;font-weight:bold;font-size:22px;border:1px solid #000000; border-bottom: none;text-align:center\" valign=\"center\">&nbsp;CÁC BỘ PHẬN KHÁC:</td>";
                    strTable += "<td style=\"line-height:110%;border:1px solid #000000;font-size:24px; border-bottom: none;height:110px\">&nbsp;Các mạch máu lớn và khoang sau phúc mạc không thấy gì lạ</br><br/>&nbsp;Dịch màng phổi (-)</td></tr>";
                    strTable += "<tr><td style=\"width:180px;font-weight:bold;font-size:22px;border:1px solid #000000;\" valign=\"center\">&nbsp; XOANG BỤNG:</td>";
                    strTable += "<td style=\"line-height:115%;border:1px solid #000000;font-size:24px;height:65px\">&nbsp;Chưa ghi nhận bất thường</td></tr>";
                    strTable += "</table>";
                    strTable += "</br>";
                    //strTable += "<div><span style=\"padding-left:50%;\">"+ddlBacSi.SelectedItem.ToString()+"</span></div>";
                    strTable += "<div>";
                    strTable += "<div>";
                    strTable += "<table style=\"width:950px;\">";
                    strTable += "<tr><td style=\"width:700px;\"><span class=\"ptext\" style=\"font-weight:bold;font-size:26px\" valign=\"top\" coslpan=\"2\"><u>Chẩn đoán</u>:</span><span style=\"font-size:24px\">&nbsp;Chưa thấy bất thường trên siêu âm bụng<span></td>";
                    strTable += "<td style=\"line-height:110%;text-align:center;width:300px;font-size:24px\" valign=\"top\"></td></tr>";
                    //strTable += "<tr><td style=\"width:850px;\"><span class=\"ptext\" style=\"font-weight:normal;font-size:25px\"></td></tr>";
                    strTable += "<tr><td style=\"width:700px;\"><span class=\"ptext\" style=\"font-weight:normal;font-size:24px\" valign=\"top\"></td>";
                    strTable += "<td style=\"line-height:110%;text-align:center;width:300px;font-size:24px;text-align:center\" valign=\"top\" rowspan=\"2\">Ngày " + DateTime.Now.ToString("dd/MM/yyyy") + "<br/>&nbsp;Bác sĩ siêu âm <br/><br/><br/><br/><br/>" + ddlBacSi.SelectedItem.Text + "</td></tr>";
                    strTable += "<tr><td style=\"width:850px;\"><span class=\"ptext\" style=\"font-weight:normal;font-size:24px\"></td></tr>";
                    // strTable += "<td style=\"line-height:110%;text-align:center;\"valign=\"middle\"><br/><br/>" + ddlBacSi.SelectedItem.ToString() + "</td></tr>";
                    strTable += "</table>";
                    //strTable += "</div>";
                    //strTable += "<div style=\"position:absolute; left: 70%; width:300px; top: 90%;text-align:center\">";
                    //strTable += "<table tyle=\"width:100%;\">";
                    //strTable += "<tr><td style=\"line-height:110%;text-align:center;width:100%;font-size:midium; font-weight:normal;\" valign=\"middle\">Ngày " + DateTime.Now.ToString("dd/MM/yyyy") + "<br/>&nbsp;Bác sĩ siêu âm</td></tr>";
                    //strTable += "<tr><td style=\"line-height:110%;text-align:center;font-size:midium; font-weight:normal;\"valign=\"middle\"><br/><br/></td></tr>";
                    //strTable += "</table>";
                    //strTable += "</div>";
                    //strTable += "<div>";
                    return strTable;
                }
                else
                {
                    strTable = "<table width=\"100%\" height=\"10%\" cellpadding=\"0\" cellspacing=\"0\">";
                    strTable += "<tr>";
                    strTable += "<td style=\"width:15px;height:15px;font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">STT</td>";
                    strTable += "<td style=\" width:100px; height:15px;font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Chiêu thể</td>";
                    strTable += "<td style=\"width:150px;height:15px; font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Chi định</td>";
                    strTable += "<td style=\" width:100px;height:15px; font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Kết quả</td>";
                    //strTable += "<td style=\"width:100px;height:15px; font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Giá trị bình thường</td> ";
                    strTable += "<td style=\" width:50px;height:15px; font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Ghi chú</td>";
                    strTable += "</tr>";
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    n++;
                    strTable += LayChiTietMotDichVu(int.Parse(dt.Rows[i]["idbanggiadichvu"].ToString()), dt.Rows[i]["tendichvu"].ToString());

                }
                strTable += "</table>";
            }
        }
        return strTable;

    }

    private string LayChiTietMotDichVu(int iIdDichVu, string strTenDichVu)
    {

        //Chuẩn bị 1 bảng
        string strTable = "";
        //strTable += strTenDichVu + "</span></td></tr>";
        //Lấy dữ liệu
        string strSql = "SELECT ROW_NUMBER() OVER (ORDER BY TENCHITIET) AS STT,tenchitiet,tendichvu,giatribinhthuong,donvi,dv.tennhom  FROM chitietdichvu ct left JOIN banggiadichvu dv ON ct.idbanggiadichvu = dv.idbanggiadichvu";
        strSql += " WHERE ct.idbanggiadichvu = " + iIdDichVu.ToString();

        string idPhongKham_ = string.IsNullOrEmpty(Request.QueryString["IdPhongKhamBenh"]) ? "0" : Request.QueryString["IdPhongKhamBenh"].ToString();
        string MaPhong = string.IsNullOrEmpty(Request.QueryString["MaPhong"]) ? "SA" : Request.QueryString["MaPhong"].ToString();

        DataTable dt = DataAcess.Connect.GetTable(strSql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // n++;
                string strStyle = "font-size:11px; color:#000000; border-right: 1px solid #000000; border-bottom: 1px solid #000000;";

                strStyle += " border-top: 1px solid #000000;";
                strTable += "<tr style=\"height:10px;width:100%\">";
                if (MaPhong.ToUpper() != "SA")
                {
                    strTable += "<td style=\" border:1px solid #000000; width:15px; font-size:11px; text-align:center;\">" + (n).ToString() + "</td>";

                    if (dt.Rows[i]["tendichvu"] != dt.Rows[0]["tendichvu"])
                    {
                        strTable += "<td style=\"border:1px solid #000000;width:150px; font-size:11px;  text-align:center;\">" + strTenDichVu + "</td>";
                    }
                    else
                    {
                        strTable += "<td style=\"border:1px solid #000000;width:150px; font-size:11px;  text-align:center;\">" + strTenDichVu + "</td>";
                    }
                    strTable += "<td style=\" border:1px solid #000000; width:150px;font-size:11px; height:20px;  text-align:center;\">&nbsp;&nbsp;" + dt.Rows[i]["tenchitiet"].ToString() + "</td>";
                    strTable += "<td style=\" border:1px solid #000000; width:100px; font-size:11px; height:20px; text-align:center;\"><span class = \"ptext\">&nbsp;&nbsp;</span></td>";
                    strTable += "<td style=\"border:1px solid #000000; width:50px; font-size:11px; height=20px; text-align:center;\">&nbsp;&nbsp;</td>";
                    strTable += "</tr>";
                }
                else
                {
                    strTable += "<td style=\" border:1px solid #000000; width:15px; font-size:11px; text-align:center;\">" + (n).ToString() + "</td>";
                    if (i > 0)
                    {
                        if (dt.Rows[i]["tennhom"] != dt.Rows[0]["tennhom"])
                        {
                            strTable += "<td style=\"border:1px solid #000000;width:150px; font-size:11px;  text-align:center;\">" + dt.Rows[i]["tennhom"].ToString() + "</td>";
                        }
                        else
                        {
                            strTable += "<td style=\"border:1px solid #000000;width:150px; font-size:11px;  text-align:center;\">_</td>";

                        }
                    }
                    else
                    {
                        //TRUONGNHAT-PC 15/7/2011
                        if (dt.Rows[0]["tennhom"].ToString() != tendichvu)
                        {
                            strTable += "<td style=\"border:1px solid #000000;width:150px; font-size:11px;  text-align:center;\">" + dt.Rows[i]["tennhom"].ToString() + "</td>";
                            tendichvu = dt.Rows[0]["tennhom"].ToString();
                        }
                        else
                        {
                            strTable += "<td style=\"border:1px solid #000000;width:150px; font-size:11px;  text-align:center;\">__</td>";
                        }
                    }
                    //strTable += "<td style=\"border:1px solid #000000;width:130px; font-size:11px;  height:20px; text-align:center;\">" + strTenDichVu + "</td>";
                    strTable += "<td style=\" border:1px solid #000000; width:150px;font-size:11px; height:20px;  text-align:center;\">&nbsp;&nbsp;" + dt.Rows[i]["tenchitiet"].ToString() + "</td>";
                    strTable += "<td style=\" border:1px solid #000000; width:100px; font-size:11px; height:20px; text-align:center;\"><span class = \"ptext\">&nbsp;&nbsp;</span></td>";
                    strTable += "<td style=\"border:1px solid #000000; width:100px;font-size:11px;  height:20px; text-align:center;\">&nbsp;&nbsp;" + dt.Rows[i]["giatribinhthuong"].ToString() + "</td> ";
                    strTable += "<td style=\"border:1px solid #000000; width:50px; font-size:11px; height=20px; text-align:center;\">&nbsp;&nbsp;" + dt.Rows[i]["donvi"].ToString() + "</td>";
                    //strTable += "<td style=\"border:1px solid #000000; width:50px; font-size:11px; height=20px; text-align:center;\">&nbsp;&nbsp;</td>";
                    strTable += "</tr>";


                    //strTable += "<tr>";
                    //int j = i + 1;
                    //strTable += "<td align=\"left\" width=\"10px\" height = \"20\" style=\"" + strStyle + "\"><span class = \"ptext\">&nbsp;" + j.ToString() + "&nbsp;</span></td>";
                    //strTable += "<td align=\"left\" width=\"70px\" height = \"20\" style=\"" + strStyle + "\"><span class = \"ptext\">&nbsp;" + strTenDichVu + "&nbsp;</span></td>";
                    //strTable += "<td align=\"left\" width=\"50px\" height = \"20\" style=\"" + strStyle + "\"><span class = \"ptext\">&nbsp;" + dt.Rows[i]["tenchitiet"].ToString() + "&nbsp;</span></td>";
                    //strTable += "<td width=\"30px\" height = \"20px\" style=\"" + strStyle + "\"><span class = \"ptext\">&nbsp;&nbsp;</span></td>";
                    //strTable += "<td align=\"center\" width=\"20px\" height = \"20\" style=\"" + strStyle + "\"><span class = \"ptext\">" + dt.Rows[i]["giatribinhthuong"].ToString() + "&nbsp;</span></td>";
                    //strTable += "<td align=\"center\" width=\"10px\" height = \"20\" style=\"" + strStyle.Replace("border-right: 1px solid #000000;", "") + "\"><span class = \"ptext\">" + dt.Rows[i]["donvi"].ToString() + "&nbsp;</span></td>";
                    //strTable += "</tr>";
                }


            }
        }

        else
        {
            //strTable += "<tr><td colspan=\"5\" style=\"border-bottom: 1px solid #000000; border-top: 1px solid #000000;\">&nbsp;</td></tr>";
        }
        return strTable;
    }

    #region Huy hoac ket thuc qua trinh tham benh
    private void HistoryReturn()
    {
        Session["dieutricanlamsan"] = null;
        Session["idkhambenhcls"] = null;
        if (StaticData.ParseInt(Session["themmoi"]) == 1)
            Response.Redirect("benhnhanlist.aspx");
        else
            Response.Redirect("listdakhamhoantat.aspx");
    }
    #endregion
    #region Load du lieu lan tham benh truoc do
    private void LoadDataThamBenh(int iIddieutrikhachlecanlamsan)
    {
        string strsql = "SELECT * FROM dieutricanlamsan WHERE iddieutricanlamsan = " + iIddieutrikhachlecanlamsan;
        DataTable dt = DataAcess.Connect.GetTable( strsql);
        if (dt != null && dt.Rows.Count > 0)
        {
            ddlBacSi.SelectedIndex = ddlBacSi.Items.IndexOf(ddlBacSi.Items.FindByValue(dt.Rows[0]["idbacsi"].ToString()));
           // txtChiDinhBacSi.Value = dt.Rows[0]["ketqua"].ToString();
            txtKetLuan.Text = dt.Rows[0]["ketluan"].ToString();
            ddlBacSi.Enabled = false;
            if (StaticData.ParseInt(dt.Rows[0]["idbacsi"]) != StaticData.ParseInt(this.idbs))
            {
                btnEdit.Visible = false;
            }
        }
    }
    #endregion
    #region "Luu ket qua tham benh"
    private void LuuKetQuaThambenh()
    {
        int idbn = StaticData.ParseInt(Session["idbnCLS"]);
        string madangky = "";
        try
        {
            madangky = Request.QueryString["madangky"].ToString();
        }
        catch
        {
            madangky = "";
        }
		 string idkbcls = Request.QueryString["idkhachlecanlamsan"].ToString();
        string ncls = "";
        if (txtngayCLS.Text != "")
        {
            ncls = StaticData.CheckDate(txtngayCLS.Text) + DateTime.Now.ToString(" HH:mm");
        }
        string idphongkhambenh = Request.QueryString["idphongkhambenh"].ToString();
        string sqlInsertCLS = "insert into dieutricanlamsan (idkhambenhcanlamsan,idbacsi,ketqua,ketluan,ngaykham,video,idbenhnhan,idphongkhambenh,SoID) "
        + "values (''," + StaticData.ParseInt(ddlBacSi.SelectedValue) + ",N'" + txtChiDinhBacSi.Value + "',N'" + txtKetLuan.Text + "','" + ncls + "',''," + idbn + ","+idphongkhambenh+",'"+madangky+"')";
        bool kq = DataAcess.Connect.ExecSQL(sqlInsertCLS);
        string maxIdDieuTri = "select Max(iddieutricanlamsan) from dieutricanlamsan";

        string iddieutri = DataAcess.Connect.GetTable(maxIdDieuTri).Rows[0][0].ToString();
        
        if (kq == true)
        {

            string strsql = "UPDATE khambenhcanlamsan SET dakham = 1,ngaykham='" + ncls + "',idbacsi=" + idbs + " WHERE  IdKhamBenhCanLamSan in (" + Request.QueryString["idkhachlecanlamsan"].ToString() + ")"
            + " and IdCanLamSan in (select idbangGiaDichVu from BanggiaDichVu where   IdPhongKhamBenh =" + Request.QueryString["IdPhongKhamBenh"].ToString() + ")";
            bool IsInsertCLS = DataAcess.Connect.ExecSQL(strsql);
            if (IsInsertCLS == false)
            {
                StaticData.MsgBox(this, "Có lỗi trong quá trình lưu kết quả thăm bệnh.");

            }
            if (txtNgayHen.Text.Trim() != "")
            {
                 
                DateTime d = DateTime.Parse(txtNgayHen.Text.Trim(), new System.Globalization.CultureInfo("tr-TR"));
                DataAcess.Connect.d_SystemDate().ToString("G", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                if (txtGioHen.Text.Trim() == "")
                {
                    txtGioHen.Text = " 00:00";
                }
                string ngayHen = d.ToString("MM/dd/yyyy") + " " + txtGioHen.Text;
                string insertNgayHen = "insert into phieuhen (iddieutricanlamsan,idbacsi,idbenhnhan,ngayhen) values (" + iddieutri + "," + ddlBacSi.SelectedValue + "," + idbn + ",'" + ngayHen + "')";
                bool resNH = DataAcess.Connect.ExecSQL(insertNgayHen);
                

                string maxIDPH = "select Max(IDPhieuHen) from phieuhen";

                txidPH.Text = DataAcess.Connect.GetTable(maxIDPH).Rows[0][0].ToString();
                
                btnInPhieuHen.Visible = true;
            }
            Session["idDieutri"] = maxIdDieuTri;
        }

        StaticData.MsgBox(this, "Đã lưu kết quả thăm bệnh thành công.");
        StaticData.SetFocus(this, "btnCancel");
        idkq.Value = iddieutri.ToString();
        VisibleBtn(false);
        action.Value = "";
    }

    //Cap nhat ket qua tham benh
    private void CapNhatKetQuaThambenh(int iIdcanlamsan)
    {
        string idcls = Session["idkhachlecanlamsan"].ToString();
        idcls = idcls.TrimEnd(',');
        string[] arrIdCls = idcls.Split(',');
        

        string sql = "update dieutricanlamsan set idbacsi = " + ddlBacSi.SelectedValue + ", ketqua = '" + txtChiDinhBacSi.Value + "',ketluan = '" + txtKetLuan.Text + "' where iddieutricanlamsan =" + iIdcanlamsan + "";
        bool check = DataAcess.Connect.ExecSQL(sql);
        if (check == false)
        {
            StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình cập nhật kết quả thăm bệnh.");

        }
        StaticData.MsgBox(this, "Đã cập nhật kết quả thăm bệnh thành công.");
        StaticData.SetFocus(this, "btnCancel");
    }

    #endregion
    #region "U Function"
    private void BindPListBacSi()
    {
        string strSQL = "SELECT * FROM bacsi WHERE idbacsi = " + idbs + " ORDER BY tenbacsi";
        DataTable dt =DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlBacSi, dt, "idbacsi", "tenbacsi", "Chọn tên bác sĩ CLS");
        ddlBacSi.SelectedIndex = 1;
    }

    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
        btnIn.Visible = !bl;
    }

    private bool CheckValid(int isadd)
    {
        return true;
    }
    private void SetValueEmpty()
    {
        //txtChiDinhBacSi.Text = "";
    }

    #endregion

    #region "Load thong tin benh nhan va thong tin cac khoa can lam san"

    //Lay thong tin benh nhan 

    private DataTable GetIdBenhNhan(string IdKhamBenhCanLamsang)
    {
        string ssql = ""
                            + " select distinct bn.*," + "\r\n"
                            + "  ngaythambenh= convert(nvarchar, getdate(), 103) ," + "\r\n"
                            + " tenbacsi=(select tenbacsi from bacsi where idbacsi=" + Request.QueryString["idbs"] + ")," + "\r\n"
                            + "  dbo.GetGioiTinh(bn.gioitinh) as sex " + "\r\n"
                            + " ,dbo.GetNamSinh(bn.ngaysinh) as namsinh,SoBHYT" + "\r\n"
                            + " from khambenhcanlamsan a" + "\r\n"
                            + " left join benhnhan bn on a.idbenhnhan=bn.idbenhnhan" + "\r\n"
                            + " where a.idkhambenhcanlamsan in (" + IdKhamBenhCanLamsang + ")";
        DataTable dt = DataAcess.Connect.GetTable( ssql);
        gioitinh = dt.Rows[0]["sex"].ToString();
        idbnhan = dt.Rows[0]["idbenhnhan"].ToString();
        return dt;
    }

    private DataTable GetInFoBenhNhan(int iIdkhambenh)
    {
        string ssql = "SELECT bn.idbenhnhan,bn.ngaysinh as tuoi, bn.*, dbo.GetGioiTinh(bn.gioitinh) as sex,dbo.GetNamSinh(bn.ngaysinh) as namsinh ";
        ssql += "FROM dangkykham dk INNER JOIN benhnhan bn ON dk.idbenhnhan = bn.idbenhnhan ";
        ssql += "WHERE dk.iddangkykham = " + iIdkhambenh;
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        return dt;
    }
    private DataTable GetBenhNhan(int idbn)
    {
        int idbenhnhan = StaticData.ParseInt(Request.QueryString["idbn"]);
        string sql = "select *,dbo.GetNamSinh(bn.ngaysinh) as namsinh,tenbenhnhan,TenGioiTinh=DBO.GetGioiTinh(GioiTinh) from benhnhan where idbbenhnhan=" + idbenhnhan;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;
    }
    //TRUONGNHAT-PC LOAD DIEU TRI CAN LAM SAN
    private string loaddieutriCLS(int idbn)
    {
        int iddieutri = StaticData.ParseInt(Request.QueryString["idcls"].ToString());
        string sql = "select iddieutricanlamsan,ngaykham,idbacsi,ketqua from dieutricanlamsan  where idbenhnhan=" + idbn + " and iddieutricanlamsan=" + iddieutri;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string strTable = dt.Rows[0]["ketqua"].ToString();
        idbs = dt.Rows[0]["idbacsi"].ToString();
        txtngayCLS.Text = string.Format("{0:dd/MM/yyyy}", dt.Rows[0]["ngaykham"]);
        idcls.Value = dt.Rows[0]["iddieutricanlamsan"].ToString();
        idkq.Value = dt.Rows[0]["iddieutricanlamsan"].ToString();
        BindPListBacSi();
        loadPK();
        return strTable;

    }
    private void loadPhieuHen(int idbnhan)
    {
        string sql = "select ngayhen,giohen=convert(varchar(5),ngayhen,108) from phieuhen where idbenhnhan=" + idbnhan;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            txtNgayHen.Text = string.Format("{0:dd/MM/yyyy}", dt.Rows[0]["ngayhen"]);
            txtGioHen.Text = dt.Rows[0]["giohen"].ToString();
        }
        else
        {
            txtNgayHen.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtGioHen.Text = DateTime.Now.ToString("hh:ss");
        }
    }
    private DataTable getBenhNhan(int idbenhnhan)
    {
        string ssql = "SELECT top 1 bn.idbenhnhan,bn.ngaysinh as tuoi, bn.*, dbo.GetGioiTinh(bn.gioitinh) as sex,dbo.GetNamSinh(bn.ngaysinh) as namsinh ";
        ssql += "FROM dangkykham dk INNER JOIN benhnhan bn ON dk.idbenhnhan = bn.idbenhnhan ";
        ssql += "WHERE bn.idbenhnhan = " +idbenhnhan;
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        return dt;
    }
    public void BenhNhanInfo()
    {
        DataTable dt = new DataTable();

        if (Request.QueryString["idbn"] != null)
        {
            int idbenhnhan = StaticData.ParseInt(Request.QueryString["idbn"]);
            string sql = "select *,dbo.GetNamSinh(ngaysinh) as namsinh,tenbenhnhan,TenGioiTinh=DBO.GetGioiTinh(GioiTinh) from benhnhan where idbenhnhan=" + idbenhnhan;
            dt = DataAcess.Connect.GetTable(sql);
           //dt = getBenhNhan(idbenhnhan);
        }
        else
        {
            return;
        }
        if (dt != null && dt.Rows.Count > 0)
        {
            string html = "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" width=\"100%\" bgcolor=\"#CCCCCC\">";
            html += "            <tr bgcolor=\"#B5CFF8\">";
            html += "                 <td width=\"18%\" valign=\"top\"><span class=\"ptext\"><b>Mã bệnh nhân</b></span></td>";
            html += "                 <td width=\"19%\" valign=\"top\"><span class=\"ptext\" ><b>Tên bệnh nhân</b></span></td>";
            html += "                 <td width=\"17%\" valign=\"top\"><span class=\"ptext\" ><b>Giới tính</b></span></td>";
            html += "                 <td width=\"17%\" valign=\"top\"><span class=\"ptext\" ><b>Năm sinh</b></span></td>";
            html += "                 <td width=\"17%\" valign=\"top\"><span class=\"ptext\" ><b>Số BHYT</b></span></td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\" >";
            html += "                 <td style = \"padding-bottom:10px; padding-top:10px\"><span class=\"ptext\">" + dt.Rows[0]["mabenhnhan"].ToString() + "</span></td>	";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["tenbenhnhan"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["TenGioiTinh"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["namsinh"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["SOBHYT"].ToString() + "</span></td>";
            html += "             </tr>";
            html += "<input type = \"hidden\" id = \"idbn\" runat = \"server\" value=\"" + dt.Rows[0]["idbenhnhan"].ToString() + "\" />";
            html += "         </table>";
            thongtinbenhnhan.InnerHtml = html;

        }
    }



    //Load thog tin dang ky cua benh nhan
    private bool IsLoadTT = false;
    public void LoadThongTinBenhNhan()
    {
        if (IsLoadTT) return;
        IsLoadTT = true;
        string iIdkhachlecanlamsan = Request.QueryString["idkhachlecanlamsan"];
        DataTable dt;
        if (StaticData.ParseInt(Request.QueryString["new"]) == 1)
            dt = GetIdBenhNhan(iIdkhachlecanlamsan);
        else
            dt = GetInFoBenhNhan(StaticData.ParseInt(Request.QueryString["idkhambenh"]));
        if (dt != null && dt.Rows.Count > 0)
        {
            string html = "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" width=\"100%\" bgcolor=\"#CCCCCC\">";
            html += "            <tr bgcolor=\"#B5CFF8\">";
            html += "                 <td width=\"18%\" valign=\"top\"><span class=\"ptext\"><b>Mã bệnh nhân</b></span></td>";
            html += "                 <td width=\"19%\" valign=\"top\"><span class=\"ptext\" ><b>Tên bệnh nhân</b></span></td>";
            html += "                 <td width=\"17%\" valign=\"top\"><span class=\"ptext\" ><b>Giới tính</b></span></td>";
            html += "                 <td width=\"17%\" valign=\"top\"><span class=\"ptext\" ><b>Năm sinh</b></span></td>";
            html += "                 <td width=\"17%\" valign=\"top\"><span class=\"ptext\" ><b>Số BHYT</b></span></td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\" >";
            html += "                 <td style = \"padding-bottom:10px; padding-top:10px\"><span class=\"ptext\">" + dt.Rows[0]["mabenhnhan"].ToString() + "</span></td>	";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["tenbenhnhan"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["Sex"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["namsinh"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["SOBHYT"].ToString() + "</span></td>";
            html += "             </tr>";
            html += "<input type = \"hidden\" id = \"idbn\" runat = \"server\" value=\"" + dt.Rows[0]["idbenhnhan"].ToString() + "\" />";
            html += "         </table>";
            thongtinbenhnhan.InnerHtml = html;

        }
    }

    //Load cac vung chi dinh can lam san
    private string LoadVungChiDinhCLS(int iddangkykham, int idbacsi)
    {
        string ssql = "SELECT * FROM banggiadichvu WHERE idbanggiadichvu IN (SELECT idbanggiadichvu FROM chitietdangkykham WHERE iddangkykham = " + iddangkykham + "  AND idbacsi = " + idbacsi + ")";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt == null || dt.Rows.Count == 0) return "";
        string slistdangky = "";
        string shtml = "<table width=\"100%\" align=\"left\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            slistdangky += dt.Rows[i]["idbanggiadichvu"].ToString() + ",";
            shtml += "<tr><td style = \"padding-left:1px\"> - ";
            shtml += dt.Rows[i]["tendichvu"].ToString();
            shtml += "</td></tr>";
        }
        shtml += "</table>";
        if (slistdangky != "")
            slistdangky = slistdangky.TrimEnd(',');
        Session["listcls"] = slistdangky;
        return slistdangky; // shtml;
    }
    #endregion

    protected void btnInPhieuHen_Click(object sender, ImageClickEventArgs e)
    {
        
        string idPH = txidPH.Text;
        Response.Write("<script>window.open(\"PhieuHenKQ.aspx?idPH=" + idPH + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');</script>");
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string LoaiBN = Request.QueryString["loaibn"];
        Response.Redirect("listkhacklecanlamsan.aspx?IdPhongKhamBenh=" + this.ddlPK.SelectedValue.ToString() + "&IdBacSi=" + this.ddlBacSi.SelectedValue.ToString() + "&loaibn=" + LoaiBN);
    }
    private void CapNhatDieuTriCLS(int idbenhnhan)
    {

        string sql;
        if (idcls.Value != "")
        {
          sql = "update dieutricanlamsan set idbacsi = " + ddlBacSi.SelectedValue + ", ketqua = N'" + txtChiDinhBacSi.Value + "',ketluan = '" + txtKetLuan.Text + "' where iddieutricanlamsan =" + idcls.Value + "";
          if (!string.IsNullOrEmpty(txtNgayHen.Text))
          {
              sql += @" 
                go
                update phieuhen set ngayhen='" + StaticData.CheckDate(txtNgayHen.Text) + " " + txtGioHen.Text + "' where iddieutricanlamsan='" + idcls.Value + "'";
          }
        }
        else
        {
            sql = "update dieutricanlamsan set idbacsi = " + ddlBacSi.SelectedValue + ", ketqua = N'" + txtChiDinhBacSi.Value + "',ketluan = '" + txtKetLuan.Text + "' where iddieutricanlamsan =" +idbenhnhan + "";
        }
        bool check = DataAcess.Connect.ExecSQL(sql);
        //if (check == false)
        //{
        //    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình cập nhật kết quả thăm bệnh.");

        //}
        StaticData.MsgBox(this, "Đã cập nhật kết quả thăm bệnh thành công.");
        StaticData.SetFocus(this, "btnCancel");
        action.Value = "";
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (idkq.Value!="")
        {
			CapNhatDieuTriCLS(StaticData.ParseInt(idkq.Value));
        }
        else
        {
           CapNhatDieuTriCLS(StaticData.ParseInt(Session["idDieutri"]));
        }
      
    }
    //protected void btninphieu_Click(object sender, EventArgs e)
    //{
    //    string filname = "KQSA";
    //    string attachment = "attachment; filename=" + filname + ".xls";
    //    HttpContext.Current.Response.ClearContent();
    //    HttpContext.Current.Response.AddHeader("content-disposition", attachment);
    //    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
    //    StringWriter sWriter = new StringWriter();
    //    HtmlTextWriter htwWriter = new HtmlTextWriter(sWriter);
    //    //tdHeader.RenderControl(htwWriter);
    //    txtChiDinhBacSi.RenderControl(htwWriter);
    //    string str = txtChiDinhBacSi.Value;
    //    HttpContext.Current.Response.Write(str);
    //    HttpContext.Current.Response.End();
    //}
}

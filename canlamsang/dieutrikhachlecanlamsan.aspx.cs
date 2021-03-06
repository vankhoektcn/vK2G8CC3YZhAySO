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
public partial class dieutrikhachlecanlamsan : Genaratepage
{
    string idbs = null;
    private string tendichvu = "";
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
                if (Session["idbnCLS"] == null)
                {
                    StaticData.MsgBox(this, "Bạn đã hết phiên làm việc. Vui lòng đăng nhập lại.");
                    Response.Redirect("javascript:window.close();");
                }
                else
                {
                    idbs = Request.QueryString["idbs"];
                }
            }
          
        }
        catch
        {
            return;   
        }
      
        if (!IsPostBack)
        {

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
    private int n = 1;
    private string LayChiTietDichVuKham()
    {
        this.n = 0;
        string strSql = "SELECT dv.idbanggiadichvu, dv.tendichvu FROM banggiadichvu dv ";
        strSql += "WHERE dv.idbanggiadichvu IN ( ";
        strSql += "SELECT idcanlamsan FROM khambenhcanlamsan ";
        strSql += "WHERE  idkhambenhcanlamsan in ( " + Session["idkhachlecanlamsan"].ToString() + ")";
        strSql += ")"
        + " and IdPhongKhamBenh =" + Request.QueryString["idphongkhambenh"].ToString();
        DataTable dt = DataAcess.Connect.GetTable(strSql);
        string strTable = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            if (Request.QueryString["IdPhongKhamBenh"].ToString() == "5")
            {
                strTable = "<table style=\" border: 1px solid #000000; border-bottom: none;\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">";
                strTable += "<tr>";
                strTable += "<td style=\"width:15px;height:15px;font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">STT</td>";
                strTable += "<td style=\" width:100px; height:15px;font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Tên nhóm</td>";
                strTable += "<td style=\"width:150px;height:15px; font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Chi tiết</td>";
                strTable += "<td style=\" width:100px;height:15px; font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Kết quả</td>";
                strTable += "<td style=\"width:100px;height:15px; font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Giá trị bình thường</td> ";
                strTable += "<td style=\" width:50px;height:15px; font-size:14px; font-weight:bold; text-align:center; color:blue;border:1px solid #000000;\">Đơn vị</td>";
                strTable += "</tr>";

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
        DataTable dt = DataAcess.Connect.GetTable(strSql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // n++;
                string strStyle = "font-size:11px; color:#000000; border-right: 1px solid #000000; border-bottom: 1px solid #000000;";

                strStyle += " border-top: 1px solid #000000;";
                strTable += "<tr style=\"height:10px;width:100%\">";
                if (Request.QueryString["IdPhongKhamBenh"].ToString() != "5")
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
        string ncls = "";
        if (txtngayCLS.Text != "")
        {
            ncls = StaticData.CheckDate(txtngayCLS.Text) + DateTime.Now.ToString(" HH:mm");
        }
        string sqlInsertCLS = "insert into dieutricanlamsan (idkhambenhcanlamsan,idbacsi,ketqua,ketluan,ngaykham,video,idbenhnhan) "
        + "values (0," + StaticData.ParseInt(ddlBacSi.SelectedValue) + ",N'" + txtChiDinhBacSi.Value + "',N'" + txtKetLuan.Text + "','" + ncls + "',''," + idbn + ")";
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
    //TRUONGNHAT-PC LOAD DIEU TRI CAN LAM SAN
    private string loaddieutriCLS(int idbn)
    {
        string sql = "select iddieutricanlamsan,ngaykham,idbacsi,ketqua from dieutricanlamsan  where idbenhnhan=" + idbn;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string strTable = dt.Rows[0]["ketqua"].ToString();
        idbs = dt.Rows[0]["idbacsi"].ToString();
        txtngayCLS.Text = string.Format("{0:dd/MM/yyyy}", dt.Rows[0]["ngaykham"]);
        idcls.Value = dt.Rows[0]["iddieutricanlamsan"].ToString();
        BindPListBacSi();
        loadPK();
        return strTable;

    }
    private void loadPhieuHen(int idbnhan)
    {
        string sql = "select ngayhen from phieuhen where idbenhnhan=" + idbnhan;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        txtNgayHen.Text = string.Format("{0:dd/MM/yyyy}", dt.Rows[0]["ngayhen"]);
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
            //string sql = "select *,dbo.GetNamSinh(bn.ngaysinh) as namsinh,tenbenhnhan,TenGioiTinh=DBO.GetGioiTinh(GioiTinh) from benhnhan where idbbenhnhan=" + idbenhnhan;
            //dt = DataAcess.Connect.GetTable(sql);
           dt = getBenhNhan(idbenhnhan);
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
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["Sex"].ToString() + "</span></td>";
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
        Response.Write("<script>window.open(\"PhieuHenKQ.aspx?idPH=" + idPH  + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');</script>");
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string LoaiBN = Request.QueryString["loaibn"];
        Response.Redirect("listkhacklecanlamsan.aspx?IdPhongKhamBenh=" + this.ddlPK.SelectedValue.ToString() + "&IdBacSi=" + this.ddlBacSi.SelectedValue.ToString() + "&loaibn=" + LoaiBN );
    }
    private void CapNhatDieuTriCLS(int idbenhnhan)
    {

        string sql = "update dieutricanlamsan set idbacsi = " + ddlBacSi.SelectedValue + ", ketqua = '" + txtChiDinhBacSi.Value + "',ketluan = '" + txtKetLuan.Text + "' where iddieutricanlamsan =" + idcls.Value + "";
        bool check = DataAcess.Connect.ExecSQL(sql);
        if (check == false)
        {
            StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình cập nhật kết quả thăm bệnh.");

        }
        StaticData.MsgBox(this, "Đã cập nhật kết quả thăm bệnh thành công.");
        StaticData.SetFocus(this, "btnCancel");
        action.Value = "";
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if(Session["idDieutri"]!=null)
            CapNhatDieuTriCLS(StaticData.ParseInt(Session["idDieutri"])); 
      
    }
    

}

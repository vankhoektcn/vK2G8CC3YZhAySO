

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
public partial class thambenhentry : System.Web.UI.Page
{
    string idbs = null;
    string dkmenu = null;
    private string currentIDBacSi = null;
    private string tendichvu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["idbn"] != null)
            {
                if (!IsPostBack)
                {
                    BenhNhanInfo();
                    txtChiDinhBacSi.Value = loaddieutriCLS(StaticData.ParseInt(Request.QueryString["idbn"]));
                    loadPhieuHen(StaticData.ParseInt(Request.QueryString["idbn"]));
                    btnAdd.Visible = false;
                    dkmenu = Request.QueryString["dkmenu"].ToString();

                    if (dkmenu == "kb")
                    {
                        PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
                    }
                    if (dkmenu == "tiepnhan")
                    {
                        PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
                    }
                    if (dkmenu == "cls")
                    {
                        PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
                    }
                    if (dkmenu == "thuphi")
                    {
                        PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
                    }
                    if (dkmenu == "thongke")
                    {
                        PlaceHolder1.Controls.Add(LoadControl("~/thongke/uscmenu.ascx"));
                    }

                    return;
                }
            }
            else
            {
                this.currentIDBacSi = this.idbs;
            if (Session["idkb"] == null)
            {
                StaticData.MsgBox(this, "Bạn đã hết phiên làm việc. Vui lòng đăng nhập lại.");
                Response.Redirect("javascript:window.close();");
            }
            else if (Request.QueryString["idbs"]!= null)
            {
                idbs = Request.QueryString["idbs"];
            }
            }
           
        }
        catch
        {
            return;
             
            //else
            //{
            //    StaticData.MsgBox(this,"Lỗi bạn không có quyền truy cập");
            //    Response.Redirect("javascript:window.close();");
            //}
        }
       
        if (!IsPostBack)
        {
            VisibleBtn(true);
            SetValueEmpty();
            BindPListBacSi();
            bindNgaykham();
            LoadThongTinBenhNhan();
            loadPK();
            string idPhongKhamBenh = Request.QueryString["IdPhongKhamBenh"];
            ddlPK.SelectedValue = idPhongKhamBenh;

            if (StaticData.ParseInt(Session["dieutricls"]) != 0)
            {
                VisibleBtn(false);
                iddieutri.Value = Session["dieutricls"].ToString();
                btnluuphieuhen.Value = "Sửa phiếu";
                LoadDataThamBenh(StaticData.ParseInt(Session["dieutricls"]));
                loadNgayHen(iddieutri.Value);
            }
            else
            {
                iddieutri.Value = "0";
                txtChiDinhBacSi.Value = LayChiTietDichVuKham();
                txtNgayHen.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtGioHen.Text = DateTime.Now.ToString(" HH:mm");
            }
            btnAdd.Attributes.Add("Onclick", "CheckInfoThamBenhCLS()");
            btnEdit.Attributes.Add("Onclick", "CheckInfoThamBenhCLS()");
            btnCancel.Attributes.Add("Onclick", "CanCelAction()");
            if (Session["idkb"] != null && Session["idkb"].ToString() != "" && Request.QueryString["IdPhongKhamBenh"]!=null)
            {
                string strsql =""
                + " select top 1 dt.iddieutricanlamsan,ph.idphieuhen,dt.idbacsi from dieutricanlamsan dt" + "\r\n"
                + " left join khambenhcanlamsan kbcls on kbcls.idkhambenh=dt.idkhambenhcanlamsan" + "\r\n"
                + " left join phieuhen ph on ph.iddieutricanlamsan=dt.iddieutricanlamsan" + "\r\n"
                + " where kbcls.idkhambenh='" + Session["idkb"] + "' and idpkb='" + Request.QueryString["IdPhongKhamBenh"] + "'" + "\r\n"
                + " order by iddieutricanlamsan desc" + "\r\n";               
                DataTable tb2 = DataAcess.Connect.GetTable(strsql);
                if (tb2.Rows.Count > 0)
                {
                    iddieutri.Value = tb2.Rows[0]["iddieutricanlamsan"].ToString();
                    btnluuphieuhen.Value = "Sửa phiếu";
                    Session["dieutricls"] = tb2.Rows[0]["iddieutricanlamsan"].ToString();
                    txidPH.Text = tb2.Rows[0]["idphieuhen"].ToString();
                    if (ddlBacSi.SelectedIndex < 1)
                    {
                        idbs = tb2.Rows[0]["idbacsi"].ToString();
                        if (idbs != "" || idbs != "0")
                            BindPListBacSi();
                    }

                }
                else
                {
                    iddieutri.Value = "0";
                    Session["dieutricls"] = null;
                    txidPH.Text = "0";
                }
            }
        }
        else
        {
            if (iddieutri.Value != "0" || iddieutri.Value != "")
                btnluuphieuhen.Value = "Sửa phiếu";
            if (action.Value == "Y")
            {
                if (iddieutri.Value == "" || iddieutri.Value == "0")
                    LuuKetQuaThambenh();
                else
                        CapNhatKetQuaThambenh(StaticData.ParseInt(iddieutri.Value));                
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
        if (this.currentIDBacSi!=null &&this.currentIDBacSi!="0" &&this.currentIDBacSi!="")
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where bspk.idbacsi=" + this.currentIDBacSi + "";
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

    private void loadNgayHen(string iddt)
    {
        string getNgayhen = "select ngayhen from phieuhen where iddieutricanlamsan = " + iddt + "";
        DataTable dt = DataAcess.Connect.GetTable(getNgayhen);
        if (dt != null && dt.Rows.Count != 0)
        {
            string ngayhen = dt.Rows[0]["ngayhen"].ToString();
            string[] split = ngayhen.Split(' ');
            txtNgayHen.Text = DateTime.Parse(split[0]).ToString("dd/MM/yyyy");
            txtGioHen.Text = DateTime.Parse(split[1]).ToString("HH:mm");
        }
    }
    //TRUONGNHAT-PC LOAD DIEU TRI CAN LAM SAN
    private string loaddieutriCLS(int idbn)
    {
        string sql = "select iddieutricanlamsan,ngaykham,idbacsi,ketqua from dieutricanlamsan  where idbenhnhan=" + idbn;
         DataTable dt = DataAcess.Connect.GetTable(sql);
         string strTable = dt.Rows[0]["ketqua"].ToString();
         idbs = dt.Rows[0]["idbacsi"].ToString();
         idcls.Value = dt.Rows[0]["iddieutricanlamsan"].ToString();
         txtngayCLS.Text = string.Format("{0:dd/MM/yyyy}",dt.Rows[0]["ngaykham"]);
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
    private int n = 0;

    private string LayChiTietDichVuKham()
    {
        this.n = 0;
        string iIdkhambenhCLS = Session["idkhambenhcls"].ToString();
        string slistchidinh = GetListChiDinhCLSBenhNhan(iIdkhambenhCLS);
        if (slistchidinh != "")
        {
            string strSql = "SELECT dv.idbanggiadichvu, dv.tendichvu FROM banggiadichvu dv ";
            strSql += "WHERE dv.idbanggiadichvu IN ( " + slistchidinh + ")"
            + " and IdPhongKhamBenh =" + Request.QueryString["IdPhongKhamBenh"].ToString();
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
        return "";
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
                    strTable += "<td style=\" border:1px solid #000000; width:150px;font-size:11px; height:20px;  text-align:center;\">&nbsp;&nbsp;"+ dt.Rows[i]["tenchitiet"].ToString() + "</td>";
                    strTable += "<td style=\" border:1px solid #000000; width:100px; font-size:11px; height:20px; text-align:center;\"><span class = \"ptext\">&nbsp;&nbsp;</span></td>";
                    strTable += "<td style=\"border:1px solid #000000; width:50px; font-size:11px; height=20px; text-align:center;\">&nbsp;&nbsp;</td>";
                    strTable += "</tr>";
                }
                else
                {
                    strTable += "<td style=\" border:1px solid #000000; width:15px; font-size:11px; text-align:center;\">" + (n).ToString() + "</td>";
                    if (i>0)
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
        iddieutri.Value = "0";
        if (StaticData.ParseInt(Session["themmoi"]) == 1)
        {
            string LoaiBN = Request.QueryString["loaibn"];
            Response.Redirect("benhnhanlist.aspx?IdPhongKhamBenh=" + this.ddlPK.SelectedValue.ToString() + "&IdBacSi=" + this.ddlBacSi.SelectedValue.ToString() + "&loaibn=" + LoaiBN );
        }
        else
            Response.Redirect("listdakhamhoantat.aspx");
    }
    #endregion
    #region Load du lieu lan tham benh truoc do
    private void LoadDataThamBenh(int iIddieutricanlamsan)
    {
        string strsql = "SELECT * FROM dieutricanlamsan WHERE iddieutricanlamsan = " + iIddieutricanlamsan;
        DataTable dt = DataAcess.Connect.GetTable(strsql);
        if (dt != null && dt.Rows.Count > 0)
        {
            ddlBacSi.SelectedIndex = ddlBacSi.Items.IndexOf(ddlBacSi.Items.FindByValue(dt.Rows[0]["idbacsi"].ToString()));
            txtChiDinhBacSi.Value = dt.Rows[0]["ketqua"].ToString();
            txtKetLuan.Text = dt.Rows[0]["ketluan"].ToString();
            ddlBacSi.Enabled = false;
            if (StaticData.ParseInt(dt.Rows[0]["idbacsi"]) != StaticData.ParseInt(idbs))
            {
                btnEdit.Visible = false;
            }
            if (dt.Rows[0]["video"].ToString() != "" && dt.Rows[0]["video"].ToString() != null)
            {
                string result = "<OBJECT id=\"wmp\" CLASSID=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\"  TYPE=\"application/x-oleobject\" WIDTH=\"300\"  HEIGHT=\"230\">" +
                                    "<PARAM name=\"URL\" value=\"Video/" + dt.Rows[0]["video"].ToString() + "\">" +
                                    "<PARAM name=\"EnableContextMenu\" value=\"1\">" +
                                    "<EMBED type=\"application/x-mplayer2\" pluginspage=\"http://microsoft.com/windows/mediaplayer/en/download/\" id=\"wmp\" name=\"wmp\" displaysize=\"4\" autosize=\"-1\" bgcolor=\"darkblue\"  showtracker=\"-1\" 	showdisplay=\"0\" showstatusbar=\"-1\" videoborder3d=\"-1\" width=\"300\" height=\"220\" src=\"Video/" + dt.Rows[0]["video"].ToString() + "\"  designtimesp=\"5311\" loop=\"false\" volume=\"0\">" +
                                    "</EMBED></OBJECT>";
                showvideo.InnerHtml = result;
            }
        }
    }
    #endregion
    #region "Luu ket qua tham benh"
    private void LuuKetQuaThambenh()
    {
        string video="";
        if (iddieutri.Value != "0" && iddieutri.Value != "")            
           video= UploadHinh();
        int idkb = StaticData.ParseInt(Session["idkb"]);        
        string ncls = "";
        if (txtngayCLS.Text != "")
        {
            ncls = StaticData.CheckDate(txtngayCLS.Text) + DateTime.Now.ToString(" HH:mm");
        }
        Process.dieutricanlamsan DTCLS = Process.dieutricanlamsan.Insert_Object(idkb.ToString(),
            ddlBacSi.SelectedValue,
            txtChiDinhBacSi.Value,
            "N"+txtKetLuan.Text,
            ncls,
            video,
            txtidBN.Text);

        string iId = "0";
        if (DTCLS != null) iId = DTCLS.iddieutricanlamsan;

        if (iId != "0")
        {
            string strsql = "UPDATE khambenhcanlamsan SET ngaykham='" + ncls + "' , idbacsi=" + idbs + ",  dakham = 1 WHERE idkhambenh = '" + idkb.ToString()
                + "' and IdCanLamSan in (select idbangGiaDichVu from BanggiaDichVu where  IdPhongKhamBenh =" + Request.QueryString["IdPhongKhamBenh"].ToString() + ")";
            ;
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

                //string insertNgayHen = "insert into phieuhen (iddieutricanlamsan,idbacsi,idbenhnhan,ngayhen) values (" + iId + "," + ddlBacSi.SelectedValue + "," + txtidBN.Text + ",'" + ngayHen + "')";
                Process.phieuHen ph = Process.phieuHen.Insert_Object(iId, ddlBacSi.SelectedValue, txtidBN.Text, ngayHen, idkb.ToString(), ddlPK.SelectedValue);

                //bool resNH = DataAcess.Connect.ExecSQL(insertNgayHen);
                string maxIDPH = "select Max(IDPhieuHen) from phieuhen";
                txidPH.Text = DataAcess.Connect.GetTable(maxIDPH).Rows[0][0].ToString();
                btnInPhieuHen.Visible = true;
               
            }
            iddieutri.Value = iId;
            Session["dieutricls"] = iId;
        }
        StaticData.MsgBox(this, "Đã lưu kết quả thăm bệnh thành công.");
        StaticData.SetFocus(this, "btnCancel");
        VisibleBtn(false);
        action.Value = "";
    }

    //Cap nhat ket qua tham benh
    private void CapNhatKetQuaThambenh(int iIddieutricanlamsan)
    {
        string video="";
        video = UploadHinh();
        Process.dieutricanlamsan DTCLS = Process.dieutricanlamsan.Create_dieutricanlamsan(iIddieutricanlamsan.ToString());
        if (DTCLS == null) return;
         bool OK=DTCLS.Save_Object(DTCLS.idkhambenhcanlamsan,
             ddlBacSi.SelectedValue,
             txtChiDinhBacSi.Value,
             txtKetLuan.Text,
             DTCLS.ngaykham,
             video,
             DTCLS.idbenhnhan);

         if (OK)
         {
             int idkb = StaticData.ParseInt(Session["idkb"]);
             string ncls = "";
             if (txtngayCLS.Text != "")
             {
                 ncls = StaticData.CheckDate(txtngayCLS.Text) + DateTime.Now.ToString(" HH:mm");
             }
             string strsql = "UPDATE khambenhcanlamsan SET ngaykham='" + ncls + "' , idbacsi=" + idbs + ",  dakham = 1 WHERE idkhambenh = '" + idkb.ToString()
                + "' and IdCanLamSan in (select idbangGiaDichVu from BanggiaDichVu where  IdPhongKhamBenh =" + Request.QueryString["IdPhongKhamBenh"].ToString() + ")";
             ;
             bool IsInsertCLS = DataAcess.Connect.ExecSQL(strsql);
             if (IsInsertCLS == false)
             {
                 StaticData.MsgBox(this, "Có lỗi trong quá trình lưu kết quả thăm bệnh.");

             }

             StaticData.MsgBox(this, "Đã cập nhật kết quả thăm bệnh thành công.");
             StaticData.SetFocus(this, "btnCancel");
             if (txtNgayHen.Text.Trim() != "" && txidPH.Text != "")
             {
                 string insertNgayHen = "update phieuhen set ngayhen='" + DateTime.Now.ToString("MM/dd/yyyy HH:mm") + "' where IDPhieuHen=" + txidPH.Text + "";
                 bool resNH = DataAcess.Connect.ExecSQL(insertNgayHen);
                 btnInPhieuHen.Visible = true;
             }
         }
         action.Value = "";
    }
    #endregion
    #region "U Function"
    private void BindPListBacSi()
    {
        string strSQL = "SELECT * FROM bacsi WHERE idbacsi=" + idbs.ToString() + "";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StaticData.FillCombo(ddlBacSi, dt, "idbacsi", "tenbacsi", "Chọn tên bác sĩ CLS");
        ddlBacSi.SelectedIndex = 1;
    }
    private void bindNgaykham()
    {
        //string IdKhambenh = Request.QueryString["listIdcls"];
        //if (Session["idkb"] == null || Session["idkb"] == "" || Session["idkb"] == "0")
        //    Session["idkb"] = IdKhambenh;

        string strSQL = "SELECT ngaykham FROM khambenh WHERE idkhambenh=" + Session["idkb"] + "";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        if(dt.Rows.Count>0)
            if (dt.Rows[0]["ngaykham"].ToString()!="")
                txtngayCLS.Text = DateTime.Parse(dt.Rows[0]["ngaykham"].ToString()).ToString("dd/MM/yyyy");
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
    #region Upload hinh anh
    public bool WorngFileExtend()
    {
        HttpPostedFile objFile;
        string strExtend;
        objFile = Request.Files[0];
        if (objFile.FileName != "")
        {
            strExtend = System.IO.Path.GetExtension(objFile.FileName);
            strExtend = strExtend.Remove(0, 1);
            strExtend = strExtend.ToUpper();
            if (strExtend == "FLV" || strExtend == "WMV" || strExtend == "BMP" || strExtend == "JPG" || strExtend == "GIF")
            {
                return true;
            }
        }
        return false;
    }

    public string saveFiles(int i)
    {
        string strFileName;
        string strExtend;
        HttpPostedFile objFile;
        string PathFile;
        string RealFile;
        objFile = Request.Files[i];
        if (objFile.FileName != "")
        {
            if (objFile.ContentLength > 0)
            {

                PathFile = Request.PhysicalApplicationPath;

                PathFile = PathFile + "canlamsang\\Video\\";

                strFileName = System.IO.Path.GetFileName(objFile.FileName);
                //Quan ly ten file: yymmdd_number
                string yy;
                string mm;
                string dd;
                yy = System.Convert.ToString(DataAcess.Connect.d_SystemDate().Year);
                mm = System.Convert.ToString(DataAcess.Connect.d_SystemDate().Month);
                dd = System.Convert.ToString(DataAcess.Connect.d_SystemDate().Day);
                strExtend = System.IO.Path.GetExtension(objFile.FileName);
                strFileName += yy + mm + dd + strExtend;

                int nAppend = 1;
                RealFile = PathFile + strFileName;
                string sFile;
                sFile = RealFile;
                while (System.IO.File.Exists(RealFile))
                {
                    //strFileName = System.IO.Path.GetFileNameWithoutExtension(objFile.FileName) & "_" & nAppend.ToString() + strExtend
                    strFileName = System.IO.Path.GetFileNameWithoutExtension(sFile) + "_" + (nAppend.ToString() + strExtend);
                    RealFile = PathFile + strFileName;
                    nAppend++;
                }
                try
                {
                    objFile.SaveAs(RealFile);
                    return strFileName;
                }
                catch (Exception)
                {
                    return "Upload Failed";
                }
            }
            else
            {
                return "Upload Failed";
            }
        }
        else
        {
            return "Upload Failed";
        }
    }
    private string UploadHinh()
    {
        string sFileUpload = "";        
        if (vdoCanLamSan.FileName != "")
        {
            if (!WorngFileExtend())
            {
                StaticData.MsgBox(this, "Chỉ chấp nhận file: *.FLV,*.WMV,*.PNG,*.BMP,*.JPG !");
                StaticData.SetFocus(this, "fHinhAnh");
                return "";
            }

            sFileUpload = saveFiles(0);
            if (sFileUpload == "Upload Failed")
            {
                StaticData.MsgBox(this, "Không thể upload hình bệnh nhân! Vui lòng thử lại!");
                StaticData.SetFocus(this, "fHinhAnh");
                return "";
            }
            
        }
        else
        {
            sFileUpload = "";
        }
        return sFileUpload;
    }
    #endregion
    #region "Load thong tin benh nhan va thong tin cac khoa can lam san"

    //Lay idbenhnhan

    private string GetListChiDinhCLSBenhNhan(string iIdkhambenhCLS)
    {
        string skq = "";
        string strSQL = "SELECT idcanlamsan ";
        strSQL += "FROM khambenhcanlamsan ";
        strSQL += " WHERE 1=1  AND idkhambenhcanlamsan in( " + iIdkhambenhCLS + ")";
        DataTable dtCT = DataAcess.Connect.GetTable(strSQL);
        if (dtCT != null && dtCT.Rows.Count > 0)
        {
            for (int i = 0; i < dtCT.Rows.Count; i++)
            {
                skq = skq + dtCT.Rows[i]["idcanlamsan"].ToString() + ",";
            }
        }
        if (skq != "")
            skq = skq.TrimEnd(',');
        return skq;
    }
    private DataTable getBenhNhan(int idbenhnhan)
    {
        string strSQL = "SELECT bn.*,dbo.GetNamSinh(bn.ngaysinh) as namsinh, bs.tenbacsi , kb.trieuchung, kb.chandoanbandau,TenGioiTinh=DBO.GetGioiTinh(bn.GioiTinh),TenPhongKhamBenh ";
        strSQL += "FROM khambenh kb LEFT JOIN bacsi bs ON kb.idbacsi = bs.idbacsi ";
        strSQL += "LEFT JOIN benhnhan bn ON kb.idbenhnhan = bn.idbenhnhan ";
        strSQL += "LEFT JOIN PhongKhamBenh PKB ON kb.IdPhongKhamBenh = PKB.IdPhongKhamBenh ";
        strSQL += " WHERE 1=1 AND bn.idbenhnhan="+idbenhnhan;
        DataTable dtCT = DataAcess.Connect.GetTable(strSQL);
        return dtCT;
    }

    public void BenhNhanInfo()
    {
        DataTable dt = new DataTable();

        if (Request.QueryString["idbn"] != null)
        {
            int idbenhnhan = StaticData.ParseInt(Request.QueryString["idbn"]);
            dt = getBenhNhan(idbenhnhan);
        }
        else
        {
            return;
        }
        if (dt != null)
        {
            string html = "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" width=\"100%\" bgcolor=\"#CCCCCC\">";
            html += "            <tr bgcolor=\"#B5CFF8\">";
            html += "                 <td width=\"10%\" valign=\"top\"><span class=\"ptext\"><b>Mã bệnh nhân</b></span></td>";
            html += "                 <td width=\"15%\" valign=\"top\"><span class=\"ptext\" ><b>Tên bệnh nhân</b></span></td>";
            //html += "                 <td width=\"15%\"><span class=\"ptext\" ><b>Địa chỉ</b></span></td>";
            html += "                 <td width=\"5%\" valign=\"top\"><span class=\"ptext\" ><b>Giới tính</b></span></td>";
            html += "                 <td width=\"5%\" valign=\"top\"><span class=\"ptext\" ><b>Năm sinh</b></span></td>";
            html += "                 <td width=\"10%\" valign=\"top\"><span class=\"ptext\" ><b>Số BHYT</b></span></td>";

            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\" >";
            html += "                 <td style = \"padding-bottom:10px; padding-top:10px\"><span class=\"ptext\">" + dt.Rows[0]["mabenhnhan"].ToString() + "</span></td>	";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["tenbenhnhan"].ToString() + "</span></td>";
            //html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["diachi"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["TenGioiTinh"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["namsinh"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["SoBHYT"].ToString() + "</span></td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
            html += "                            <td width=\"25%\" nowrap = \"nowrap\"><span class=\"ptext\"><b>Triệu chứng&nbsp;:&nbsp;</b></span></td>";
            html += "                            <td width=\"75%\"><span class=\"ptext\">" + dt.Rows[0]["trieuchung"].ToString() + "</span></td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
            html += "                            <td width=\"25%\"  nowrap = \"nowrap\"><span class=\"ptext\"><b>Chẩn đoán sơ bộ&nbsp;:&nbsp;</b></span></td>";
            html += "                            <td width=\"75%\"><span class=\"ptext\">" + dt.Rows[0]["chandoanbandau"].ToString() + "</span></td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";


            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";

            html += "                         <tr>";
            html += "                            <td width=\"25%\"  nowrap = \"nowrap\"><span class=\"ptext\"><b>Khoa khám &nbsp;:&nbsp;</b></span></td>";
            html += "                            <td width=\"75%\"><span class=\"ptext\">" + dt.Rows[0]["TenPhongKhamBenh"].ToString() + "</span></td>";
            html += "                         </tr>";

            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";





            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
            html += "                            <td width=\"25%\"  nowrap = \"nowrap\"><span class=\"ptext\"><b>Bác sĩ chỉ định&nbsp;:&nbsp;</b></span></td>";
            if (dt.Rows[0]["tenbacsi"].ToString() == null)
            {
                html += "                            <td width=\"75%\"><span class=\"ptext\"></span></td>";
            }
            else
            {
                html += "                            <td width=\"75%\"><span class=\"ptext\">" + dt.Rows[0]["tenbacsi"].ToString() + "</span></td>";
            }
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            html += "         </table>";
            txtidBN.Text = dt.Rows[0]["idbenhnhan"].ToString();
            thongtinbenhnhan.InnerHtml = html;
        }
    }


    //Load thog tin dang ky cua benh nhan
    public void LoadThongTinBenhNhan()
    {
        DataTable dt = new DataTable();
        int iIdkhambenhCLS = StaticData.ParseInt(Session["idkb"]);
            dt = GetIdBenhNhan(iIdkhambenhCLS);
        if (dt != null && dt.Rows.Count>0)
        {
            string html = "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" width=\"100%\" bgcolor=\"#CCCCCC\">";
            html += "            <tr bgcolor=\"#B5CFF8\">";
            html += "                 <td width=\"10%\" valign=\"top\"><span class=\"ptext\"><b>Mã bệnh nhân</b></span></td>";
            html += "                 <td width=\"15%\" valign=\"top\"><span class=\"ptext\" ><b>Tên bệnh nhân</b></span></td>";
            //html += "                 <td width=\"15%\"><span class=\"ptext\" ><b>Địa chỉ</b></span></td>";
            html += "                 <td width=\"5%\" valign=\"top\"><span class=\"ptext\" ><b>Giới tính</b></span></td>";
            html += "                 <td width=\"5%\" valign=\"top\"><span class=\"ptext\" ><b>Năm sinh</b></span></td>";
            html += "                 <td width=\"10%\" valign=\"top\"><span class=\"ptext\" ><b>Số BHYT</b></span></td>";

            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\" >";
            html += "                 <td style = \"padding-bottom:10px; padding-top:10px\"><span class=\"ptext\">" + dt.Rows[0]["mabenhnhan"].ToString() + "</span></td>	";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["tenbenhnhan"].ToString() + "</span></td>";
            //html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["diachi"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["TenGioiTinh"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["namsinh"].ToString() + "</span></td>";
            html += "                 <td><span class=\"ptext\">" + dt.Rows[0]["SoBHYT"].ToString() + "</span></td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
            html += "                            <td width=\"25%\" nowrap = \"nowrap\"><span class=\"ptext\"><b>Triệu chứng&nbsp;:&nbsp;</b></span></td>";
            html += "                            <td width=\"75%\"><span class=\"ptext\">" + dt.Rows[0]["trieuchung"].ToString() + "</span></td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
            html += "                            <td width=\"25%\"  nowrap = \"nowrap\"><span class=\"ptext\"><b>Chẩn đoán sơ bộ&nbsp;:&nbsp;</b></span></td>";
            html += "                            <td width=\"75%\"><span class=\"ptext\">" + dt.Rows[0]["chandoanbandau"].ToString() + "</span></td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";


            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";

            html += "                         <tr>";
            html += "                            <td width=\"25%\"  nowrap = \"nowrap\"><span class=\"ptext\"><b>Khoa khám &nbsp;:&nbsp;</b></span></td>";
            html += "                            <td width=\"75%\"><span class=\"ptext\">" + dt.Rows[0]["TenPhongKhamBenh"].ToString() + "</span></td>";
            html += "                         </tr>";

            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            




            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
                html += "                            <td width=\"75%\"><span class=\"ptext\"></span></td>";
                html += "                            <td width=\"75%\"><span class=\"ptext\">" + dt.Rows[0]["tenbacsi"].ToString() + "</span></td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            html += "         </table>";
            txtidBN.Text = dt.Rows[0]["idbenhnhan"].ToString();
            thongtinbenhnhan.InnerHtml = html;
            

        }
    }

    //Lay idbenhnhan

    private DataTable GetIdBenhNhan(int iIdkhambenhCLS)
    {
        string strSQL = "SELECT bn.*,dbo.GetNamSinh(bn.ngaysinh) as namsinh, bs.tenbacsi , kb.trieuchung, kb.chandoanbandau,TenGioiTinh=DBO.GetGioiTinh(bn.GioiTinh),TenPhongKhamBenh ";
        strSQL += "FROM khambenh kb LEFT JOIN bacsi bs ON kb.idbacsi = bs.idbacsi ";
        strSQL += "LEFT JOIN benhnhan bn ON kb.idbenhnhan = bn.idbenhnhan ";
        strSQL += "LEFT JOIN PhongKhamBenh PKB ON kb.IdPhongKhamBenh = PKB.IdPhongKhamBenh ";
        strSQL += " WHERE 1=1 AND kb.idkhambenh in (select idkhambenh from khambenhcanlamsan where idkhambenh =" + iIdkhambenhCLS + ")";
        DataTable dtCT = DataAcess.Connect.GetTable(strSQL);
        return dtCT;
    }
    //Load cac vung chi dinh can lam san
    private string LoadVungChiDinhCLS(string schidinh)
    {
        string iIdkhambenhCLS = Session["idkhambenhcls"].ToString();
        string slistchidinh = GetListChiDinhCLSBenhNhan(iIdkhambenhCLS);
        if (slistchidinh == "")
            return "";
        string ssql = "SELECT * FROM banggiadichvu WHERE idbanggiadichvu IN (" + slistchidinh + ")";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt == null || dt.Rows.Count == 0) return "";
        string shtml = "<table width=\"100%\" align=\"left\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            shtml += "<tr><td style = \"padding-left:1px\"> - ";
            shtml += dt.Rows[i]["tendichvu"].ToString();
            shtml += "</td></tr>";
        }
        shtml += "</table>";
        return shtml;
    }
    #endregion
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //LuuKetQuaThambenh();
    }
    protected void btnluuphieuhen_Click(object sender, EventArgs e)
    {
         if (ddlBacSi.SelectedIndex < 1)
        {
            StaticData.MsgBox(this, "Bạn chưa chọn bác sĩ");
            return;
        }
        Process.phieuHen ph = null;
        int idkb = StaticData.ParseInt(Session["idkb"]);
        string iId = "0";
        if (iddieutri.Value == "" || iddieutri.Value == "0")
        {            
            string ncls = "";
            Process.dieutricanlamsan DTCLS = Process.dieutricanlamsan.Insert_Object(idkb.ToString(),
                ddlBacSi.SelectedValue,
                txtChiDinhBacSi.Value,
                "N" + txtKetLuan.Text,
                "",
                "",
                txtidBN.Text);

           
            if (DTCLS != null)
            {
                iId = DTCLS.iddieutricanlamsan;
                iddieutri.Value = iId;
                btnInPhieuHen.Visible = false;
                if (txtNgayHen.Text.Trim() != "")
                {
                    DateTime d = DateTime.Parse(txtNgayHen.Text.Trim(), new System.Globalization.CultureInfo("tr-TR"));
                    DataAcess.Connect.d_SystemDate().ToString("G", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                    if (txtGioHen.Text.Trim() == "")
                    {
                        txtGioHen.Text = " 00:00";
                    }
                    string ngayHen = d.ToString("MM/dd/yyyy") + " " + txtGioHen.Text;
                    if (txidPH.Text == "" || txidPH.Text == "0")
                        ph = Process.phieuHen.Insert_Object(iId, ddlBacSi.SelectedValue, txtidBN.Text, ngayHen, idkb.ToString(), ddlPK.SelectedValue);
                    else
                    {
                        ph = new Process.phieuHen();
                        ph.IDPhieuHen = txidPH.Text.ToString();
                        ph.Save_Object(iId, ddlBacSi.SelectedValue, txtidBN.Text, ngayHen, idkb.ToString(), ddlPK.SelectedValue);
                    }
                    //bool resNH = DataAcess.Connect.ExecSQL(insertNgayHen);
                    string maxIDPH = "select Max(IDPhieuHen) from phieuhen";
                    txidPH.Text = DataAcess.Connect.GetTable(maxIDPH).Rows[0][0].ToString();
                    btnInPhieuHen.Visible = true;
                }
                iddieutri.Value = iId;
                Session["dieutricls"] = iId;
                btnluuphieuhen.Value = "Sửa phiếu";
            }
        }
        else
        {
            iId = iddieutri.Value;
            if (txtNgayHen.Text.Trim() != "")
            {
                DateTime d = DateTime.Parse(txtNgayHen.Text.Trim(), new System.Globalization.CultureInfo("tr-TR"));
                DataAcess.Connect.d_SystemDate().ToString("G", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                if (txtGioHen.Text.Trim() == "")
                {
                    txtGioHen.Text = " 00:00";
                }
                string ngayHen = d.ToString("MM/dd/yyyy") + " " + txtGioHen.Text;
                if (txidPH.Text == "" || txidPH.Text == "0")
                    ph = Process.phieuHen.Insert_Object(iId, ddlBacSi.SelectedValue, txtidBN.Text, ngayHen, idkb.ToString(), ddlPK.SelectedValue);
                else
                {
                    ph = new Process.phieuHen();
                    ph.IDPhieuHen = txidPH.Text.ToString();
                    ph.Save_Object(iId, ddlBacSi.SelectedValue, txtidBN.Text, ngayHen, idkb.ToString(), ddlPK.SelectedValue);
                }
                //bool resNH = DataAcess.Connect.ExecSQL(insertNgayHen);
                string maxIDPH = "select Max(IDPhieuHen) from phieuhen";
                txidPH.Text = DataAcess.Connect.GetTable(maxIDPH).Rows[0][0].ToString();
                btnInPhieuHen.Visible = true;
            }
        }

    }
    protected void btnInPhieuHen_Click(object sender, EventArgs e)
    {      
        if (txidPH.Text != "" && txidPH.Text != "0")
            Response.Write("<script>window.open(\"PhieuHenKQ.aspx?idPH=" + txidPH.Text + "\");</script>");
        else StaticData.MsgBox(this, " Chưa có phiếu hẹn");
    }
    protected void InCLS_Click(object sender, ImageClickEventArgs e)
    {
        string idbn = txtidBN.Text;
        //string url = "../khambenh/inlisthosobenhan01.aspx?idbn=" + obj.value;
        Response.Write("<script>window.open(\"../khambenh/inlisthosobenhan01.aspx?idbn=" +idbn + "\");</script>");
    }
    private void CapNhatDieuTriCLS(int idbenhnhan)
    {

        string sql = "update dieutricanlamsan set idbacsi = " + ddlBacSi.SelectedValue + ", ketqua = N'" + txtChiDinhBacSi.Value + "',ketluan = N'" + txtKetLuan.Text + "' where iddieutricanlamsan =" + idbenhnhan + "";
        bool check = DataAcess.Connect.ExecSQL(sql);
        if (check == false)
        {
            StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình cập nhật kết quả thăm bệnh.");

        }
        StaticData.MsgBox(this, "Đã cập nhật kết quả thăm bệnh thành công.");
        StaticData.SetFocus(this, "btnCancel");
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        CapNhatDieuTriCLS(StaticData.ParseInt(iddieutri.Value)); ;

    }
}

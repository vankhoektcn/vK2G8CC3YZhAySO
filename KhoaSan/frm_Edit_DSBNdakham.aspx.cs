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

public partial class frm_Edit_DSBNdakham : Genaratepage
{
    private string current_NoiDungKCBID = null;
    private string current_PhongID = null;
    private string current_KhoaID = null;
    private string current_KhamBenhID = null;
    private string current_BenhNhanID = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadMenu();
        current_KhamBenhID = Request.QueryString["IdKhamBenh"].ToString();
         if (!IsPostBack)
         {
             StaticData.FillCombo(ddBacSi, Process.bacsi.dtGetAll(), Profess.TBLS.tbl_bacsi.idbacsi.ToString(), Profess.TBLS.tbl_bacsi.tenbacsi.ToString(), "Bác sĩ khám");

            if (current_KhamBenhID != null && current_KhamBenhID != "")
            {
                string sql1 = "SELECT A.*, D.IDBANGGIADICHVU,D.IDPHONGKHAMBENH,C.PhongID,P.DICHVUKCB" + "\r\n"
                + " FROM KHAMBENH  A " + "\r\n"
                + " LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM" + "\r\n"
                + " LEFT JOIN CHITIETDANGKYKHAM C ON C.IDDANGKYKHAM=B.IDDANGKYKHAM AND 		A.IDPHONGKHAMBENH=DBO.KB_GETIDPHONGKHAMBENH(C.IDCHITIETDANGKYKHAM)" + "\r\n"
                + " LEFT JOIN BANGGIADICHVU D ON C.IDBANGGIADICHVU=D.IDBANGGIADICHVU" + "\r\n"
                + " LEFT JOIN KB_PHONG P ON P.ID=C.PHONGID" + "\r\n"
                + " WHERE A.IDKHAMBENH=" + current_KhamBenhID;
                DataTable dtKhamBenh = DataAcess.Connect.GetTable(sql1);
                if (dtKhamBenh != null && dtKhamBenh.Rows.Count > 0)
                {
                    txtidkham.Value=dtKhamBenh.Rows[0]["IdKhamBenh"].ToString();
                    txtidbn.Value = dtKhamBenh.Rows[0]["IdBenhNhan"].ToString();
                    txtLoaiBN.Value = DataAcess.Connect.GetTable("select loai from benhnhan where idbenhnhan=" + dtKhamBenh.Rows[0]["IdBenhNhan"].ToString() + "").Rows[0][0].ToString();
                    // lấy số Ngày BH
                    txtSoNgayBH.Value = DataAcess.Connect.GetTable("select isnull(convert(int, convert(datetime,ngayhethan)- getdate()),0) from benhnhan WHERE  idbenhnhan=" + dtKhamBenh.Rows[0]["IdBenhNhan"].ToString()).Rows[0][0].ToString();
                   
                    current_NoiDungKCBID = dtKhamBenh.Rows[0]["DICHVUKCB"].ToString();
                    current_PhongID = dtKhamBenh.Rows[0]["PhongID"].ToString();
                    this.current_KhoaID=dtKhamBenh.Rows[0]["IdPhongKhamBenh"].ToString();
                    this.current_BenhNhanID = dtKhamBenh.Rows[0]["IdBenhNhan"].ToString();
                    hdidchitietdangkykham.Value = dtKhamBenh.Rows[0]["idchitietdangkykham"].ToString();
                    this.ddBacSi.SelectedValue = dtKhamBenh.Rows[0]["IdBacSi"].ToString();

                    LoadPhongKhamBenh();
                    if (dtKhamBenh.Rows[0]["phongkhamchuyenden"].ToString() != "0")
                    {
                        ddlPhongKhamBenh.SelectedValue = dtKhamBenh.Rows[0]["phongkhamchuyenden"].ToString();
                        noidungkcbChuyenDen(ddlPhongKhamBenh.SelectedValue);
                        if (dtKhamBenh.Rows[0]["idDVphongchuyenden"].ToString() != "0")
                        {
                            ddlNdCD.SelectedValue = dtKhamBenh.Rows[0]["idDVphongchuyenden"].ToString();
                            if (ddlNdCD.SelectedValue != "0")
                                phongkhamChuyenDen(ddlNdCD.SelectedValue);
                            ddlPKBCD.SelectedValue = dtKhamBenh.Rows[0]["idphongchuyenden"].ToString();
                        }
                        if (dtKhamBenh.Rows[0]["huongdieutri"].ToString() == "8")
                        {
                            ddlKhoaNhapVien.SelectedValue = dtKhamBenh.Rows[0]["phongkhamchuyenden"].ToString();
                        }
                    }

                }
            }
            noidungkcb( (Request.QueryString["idpk"]!=null ?  Request.QueryString["idpk"].ToString() : this.current_KhoaID));
            this.ddlnd.SelectedValue = this.current_NoiDungKCBID;
            phongkham(ddlnd.SelectedValue);
            this.ddlphongkhamdo.SelectedValue = this.current_PhongID;

            txt_kiemtra1.Value = (StaticData.HaveChanDoanPhanBiet1 ? "1" : "0");
            txt_kiemtra2.Value = (StaticData.HaveChanDoanPhanBiet2 ? "1" : "0");
            bool kt1 = StaticData.HaveChanDoanPhanBiet1;
            bool kt2 = StaticData.HaveChanDoanPhanBiet2;
            txtchandoan_3.Visible = kt2;
            lb2.Visible = kt2;
            txtmachandoan_3.Visible = kt2;
            lblCDPB2.Visible = kt2;
            lblCDPB2.Text = StaticData.GetParameter("sysChanDoan");
            lbHuongDieuTri.InnerText = StaticData.GetParameter("TenHuongDieuTri");
            LoadThongtienBN();
        }
        else
        {
        }        
        listIDKBCLS.Value = LoadChiDinhCanLamSang(StaticData.ParseInt(txtidkham.Value));
        LoadBenhLyMau();
    }
    private void LoadMenu()
    {
        string dkmenu = Request.QueryString["dkmenu"].ToString();
        if (dkmenu == "khoasan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/KhoaSan/uscmenu.ascx"));
        }
        else if (dkmenu == "phukhoa")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/PhuKhoa/uscmenu.ascx"));
        }
        if (dkmenu == "tresosinh")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/TreSoSinh/menu_HeThong.ascx"));
        }
        if (dkmenu == "capcuu")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/CapCuu/uscmenu.ascx"));
        }
        if (dkmenu == "khoanoi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/KhoaNoi/uscmenu.ascx"));
        }
        if (dkmenu == "khoangoai")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/KhoaNgoai/uscmenu.ascx"));
        }
    }
    private void LoadBenhLyMau()
    {
        string strsql = "SELECT * FROM Th_tbd_toathuocmau ORDER BY TENBENHLY";
        DataTable dt = DataAcess.Connect.GetTable(strsql);
        StaticData.FillCombo(ddlbenhlymau, dt, "idtoathuocmau", "tenbenhly", "--Chọn bệnh lý mẫu--");
        StaticData.FillCombo(ddGhiChuBenhLy, dt, "idtoathuocmau", "ghichu", "--Lời dặn dò mẫu--");

    }
    private string LoadChiDinhCanLamSang(int idkhambenh)
    {
        string sql, strlistid = "";      

        sql = "SELECT kbcls.idkhambenhcanlamsan, tendichvu,kbcls.idcanlamsan,kbcls.dathu FROM khambenhcanlamsan kbcls INNER JOIN banggiadichvu bg ON kbcls.idcanlamsan = bg.idbanggiadichvu";
        sql += " WHERE kbcls.idkhambenh = " + idkhambenh;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strlistid += dt.Rows[i]["idkhambenhcanlamsan"].ToString() + ",";

            }
            if (strlistid != "" && strlistid != null) strlistid = strlistid.TrimEnd(',');

        }

        return strlistid;
    }

    #region U Function
    

    private void LoadThongtienBN()
    {
        string idbenhnhan = this.current_BenhNhanID;
        string lsql = "select mabenhnhan as ma, tenbenhnhan as ten, diachi,case gioitinh when 0 then 'Nam'" +
            " else N'Nữ' end as phai, ngaysinh as ns from benhnhan where idbenhnhan=" + idbenhnhan;
        DataTable dt =  DataAcess.Connect.GetTable(lsql);
        if (dt == null || dt.Rows.Count <= 0)
            return;
        txtTenBenhNhan.Text = dt.Rows[0]["ten"].ToString();
        txtMaBenhNhan.Text = dt.Rows[0]["ma"].ToString();
        txtTuoi.Text = dt.Rows[0]["ns"].ToString();
        txtGioiTinh.Text = dt.Rows[0]["phai"].ToString();
        txtDiaChi.Text = dt.Rows[0]["diachi"].ToString();
        string idtoathuoc = "select max(idbenhnhantoathuoc) as idtoathuoc from benhnhantoathuoc where idbenhnhan="+idbenhnhan;
        DataTable dtIDToaThuoc = DataAcess.Connect.GetTable(idtoathuoc);
        if (dtIDToaThuoc.Rows[0]["idtoathuoc"].ToString() == "" || dtIDToaThuoc.Rows[0]["idtoathuoc"].ToString() == null)
        {
            btnXemTTOld.Visible = false;
            return;
        }
        else{
            idbntoathuoc.Value = dtIDToaThuoc.Rows[0]["idtoathuoc"].ToString();
            btnXemTTOld.Visible = true;
        }
    }

    private void loadthongtinkham()
    {
        //string idlankham = Session["idlankham"].ToString();
        //string lsql = "select  convert(nvarchar(10),ngaykham,103) as ngaykham, maphieukham, trieuchung, "+
        //" chandoanbandau, chidinhbacsi,dando,ngayhentaikham" +
        //    ",noidungtaikham from khambenh where idkhambenh=" + idlankham;
        //DataTable dt = DataAcess.Connect.GetTable(lsql);
        //if (dt.Rows.Count < 0) return;
        //txtNgayKham.Text = dt.Rows[0]["ngaykham"].ToString();
        //txtMaPhieuKham.Text = dt.Rows[0]["maphieukham"].ToString();
        //txtTrieuChung.Text = dt.Rows[0]["trieuchung"].ToString();
        //txtChanDoanSoBo.Text = dt.Rows[0]["chandoanbandau"].ToString();
        //txtChiDinhBacSi.Text = dt.Rows[0]["chidinhbacsi"].ToString();
        //txtDanDo.Text = dt.Rows[0]["dando"].ToString();
        //txtngayhen.Text = dt.Rows[0]["ngayhentaikham"].ToString();
        //txtNoiDungTaiKham.Text = dt.Rows[0]["noidungtaikham"].ToString();
        //LoadThongTinKhamBenh();
        //txtidkham.Attributes.Add("onchange", "LoadThongTinKhamBenh(this)");
        //txtNgayHH.Attributes.Add("onTextchanged", "LoadThongTinKhamBenh(this)");
        //txtidkham.Text = idlankham;

    }
    #endregion

    #region "Load thong tin benh nhan va thong tin cac khoa can lam san"
    //Check xem mot phan tu co ton ton trong mot chuoi nao do hay khong
    private int CheckExistValue(string sKey, string sChuoi)
    {
        if (sChuoi == "")
            return -1; // Khong ton tai sKey trong chuoi sChuoi
        string[] sarr = sChuoi.Split(',');
        for (int i = 0; i < sarr.Length; i++)
        {
            string snoi = "^" + sKey;
            if (sKey == sarr[i] || sarr[i] == snoi)
                return i;
        }
        return -1;
    }
    //Load cac khoa can lam san
    public void LoadCanLamSan()
    {
        string[] arrVCD = Session["noidungchidinh"].ToString().Split('^');
        string strSQL = "SELECT * FROM phongkhambenh WHERE loaiphong = 1 ORDER BY tenphongkhambenh";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        if (dt != null)
        {
            string html = "";
            html = "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string schk = "";
                string sndcd = "";
                string sactive = "none";
                int iIdx = CheckExistValue(dt.Rows[i]["idphongkhambenh"].ToString(), Session["listcanlamsang"].ToString());
                if (iIdx != -1)
                {
                    schk = "checked=\"checked\"";
                    if (arrVCD.Length > 0)
                        sndcd = arrVCD[iIdx];
                    if (StaticData.ParseInt(Session["dathambenh"]) == 1)
                        sactive = "";
                }

                html += "    <tr>";
                html += "        <td width=\"16%\" valign=\"top\"></td>";
                html += "        <td width=\"84%\" valign=\"top\" align = \"left\"><p class=\"ptext\" ><input type = \"checkbox\" " + schk + " onclick = \"ShowChiDinh(" + dt.Rows[i]["idphongkhambenh"] + ")\" id = \"chk_" + dt.Rows[i]["idphongkhambenh"] + "\" value = \"" + dt.Rows[i]["idphongkhambenh"] + "\"><b>" + dt.Rows[i]["tenphongkhambenh"] + "</b>&nbsp;<input type = \"hidden\" id = \"txtVungchidinh_" + dt.Rows[i]["idphongkhambenh"] + "\" name = \"txtVungchidinh_" + dt.Rows[i]["idphongkhambenh"] + "\" value = \"" + sndcd + "\" runat = \"server\"></p></td>";
                html += "    </tr>";
                html += "    <tr style = \"display:" + sactive + "\" id = \"canlamsan_" + dt.Rows[i]["idphongkhambenh"] + "\">";
                html += "        <td width=\"16%\" valign=\"top\"><p class=\"ptext\" >Vùng chỉ định:&nbsp;</p></td>";
                //html += "        <td width=\"84%\" valign=\"top\" align = \"left\"><p class=\"ptext\"><textarea name=\"txtVungchidinh_" + dt.Rows[i]["idphongkhambenh"] + "\" rows=\"2\" cols=\"20\" id=\"txtVungchidinh_" + dt.Rows[i]["idphongkhambenh"] + "\" style=\"height:40px;width:440px;\"></textarea></p></td>";
                html += "        <td width=\"84%\" valign=\"top\" align = \"left\" style = \"padding-left:10px\"><p class=\"ptext\">" + LoadDichVu(StaticData.ParseInt(dt.Rows[i]["idphongkhambenh"])) + "</p></td>";
                html += "    </tr>";
            }
            html += "<table>";
            Response.Write(html);
        }
    }

    //Load cac dich vu trong phong kham can lam sang
    private string LoadDichVu(int idphongkham)
    {
        string ssql = "SELECT * FROM banggiadichvu WHERE idphongkhambenh = " + idphongkham;
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt == null || dt.Rows.Count == 0) return "";
        string shtml = "<table width=\"100%\" align=\"left\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string schk = "";
            if (CheckExistValue(dt.Rows[i]["idbanggiadichvu"].ToString(), Session["noidungchidinh"].ToString()) != -1)
            {
                schk = "checked=\"checked\"";
            }
            shtml += "<tr><td style = \"padding-left:10px\">";
            shtml += "<input type = \"checkbox\" " + schk + " id = \"chkdtcls_" + dt.Rows[i]["idbanggiadichvu"] + "\" value = \"" + dt.Rows[i]["idbanggiadichvu"] + "\" onclick = \"SetVungChiDinhCLS(" + dt.Rows[i]["idbanggiadichvu"] + ", " + idphongkham + ")\" >&nbsp;" + dt.Rows[i]["tendichvu"].ToString();
            shtml += "</td></tr>";
        }
        shtml += "</table>";
        return shtml;
    }
    //Load thog tin dang ky cua benh nhan
    public void LoadThongTinBenhNhan()
    {
        int iIdbenhnhanphongkhambenh = StaticData.ParseInt(Session["idthambenh"]);
        string iIdbenhnhan = StaticData.GetValue( "benhnhan_phongkhambenh", "idbenhnhanphongkhambenh", iIdbenhnhanphongkhambenh, "idbenhnhan");
        string ssql = "SELECT * FROM benhnhan WHERE idbenhnhan = " + iIdbenhnhan;
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt != null)
        {
            string html = "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" width=\"100%\" bgcolor=\"#CCCCCC\">";
            html += "            <tr bgcolor=\"#B5CFF8\">";
            html += "                 <td width=\"18%\" valign=\"top\"><p class=\"ptext\"><b>Mã bệnh nhân</b></p></td>";
            html += "                 <td width=\"19%\" valign=\"top\"><p class=\"ptext\" ><b>Tên bệnh nhân</b></p></td>";
            html += "                 <td width=\"28%\"><p class=\"ptext\" ><b>Điện chỉ</b></p></td>";
            html += "                 <td width=\"18%\"><p class=\"ptext\" ><b>Điện thoại</b></p></td>";
            html += "                 <td width=\"17%\" valign=\"top\"><p class=\"ptext\" ><b>Chứng minh thư</b></p></td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\" >";
            html += "                 <td style = \"padding-bottom:10px; padding-top:10px\"><p class=\"ptext\">" + dt.Rows[0]["mabenhnhan"].ToString() + "</p></td>	";
            html += "                 <td><p class=\"ptext\">" + dt.Rows[0]["tenbenhnhan"].ToString() + "</p></td>";
            html += "                 <td><p class=\"ptext\">" + dt.Rows[0]["diachi"].ToString() + "</p></td>";
            html += "                 <td><p class=\"ptext\">" + dt.Rows[0]["dienthoai"].ToString() + "</p></td>	";
            html += "                 <td><p class=\"ptext\">" + dt.Rows[0]["chungminhthu"].ToString() + "</p></td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
            html += "                            <td width=\"17%\" nowrap = \"nowrap\"><p class=\"ptext\"><b>Tiền sử bệnh&nbsp;:&nbsp;</b></p></td>";
            html += "                            <td width=\"83%\"><p class=\"ptext\">" + dt.Rows[0]["tiensubenhnhan"].ToString() + "</p></td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
            html += "                            <td width=\"17%\"  nowrap = \"nowrap\"><p class=\"ptext\"><b>Tình trạng ban đầu&nbsp;:&nbsp;</b></p></td>";
            html += "                            <td width=\"83%\"><p class=\"ptext\">" + dt.Rows[0]["tinhtrangbandau"].ToString() + "</p></td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
            html += "                            <td width=\"17%\"  nowrap = \"nowrap\"><p class=\"ptext\"><b>Chức năng sống&nbsp;:&nbsp;</b></p></td>";
            html += "                            <td width=\"83%\">";
            html += "                                 <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                                    <tr>";
            html += "                                        <td width=\"25%\"  nowrap = \"nowrap\" align = \"right\"><p class=\"ptext\"><b>Chiều cao&nbsp;:&nbsp;</b></p></td>";
            html += "                                        <td width=\"25%\"><p class=\"ptext\">" + dt.Rows[0]["chieucao"].ToString() + " ( m)</p></td>";
            html += "                                        <td width=\"25%\" align = \"right\" nowrap = \"nowrap\"><p class=\"ptext\"><b>Huyết áp:&nbsp;</b></p></td>";
            html += "                                        <td width=\"25%\"><p class=\"ptext\">" + dt.Rows[0]["huyetap"].ToString() + " (lần)</p></td>";
            html += "                                    </tr>";
            html += "                                    <tr>";
            html += "                                        <td width=\"25%\" align = \"right\" nowrap = \"nowrap\"><p class=\"ptext\"><b>Cân nặng&nbsp;:&nbsp;</b></p></td>";
            html += "                                        <td width=\"25%\"><p class=\"ptext\">" + dt.Rows[0]["cannang"].ToString() + " (kg)</p></td>";
            html += "                                        <td width=\"25%\" align = \"right\" nowrap = \"nowrap\"><p class=\"ptext\"><b>Nhịp tim&nbsp;:&nbsp;</b></p></td>";
            html += "                                        <td width=\"25%\"><p class=\"ptext\">" + dt.Rows[0]["nhiptim"].ToString() + " (lần)</p></td>";
            html += "                                    </tr>";
            html += "                                </table>";
            html += "                            </td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            html += "         </table>";
            //thongtinbenhnhan.InnerHtml = html;       
            //Response.Write(html);
        }
    }

    #region Load thong tin ho so benh an
    public void LoadThongTinHSBABenhNhan()
    {
        int iIdbenhnhanphongkhambenh = StaticData.ParseInt(Session["idthambenh"]);
        string iIdbenhnhan = StaticData.GetValue( "benhnhan_phongkhambenh", "idbenhnhanphongkhambenh", iIdbenhnhanphongkhambenh.ToString(), "idbenhnhan");
        string ssql = "SELECT bnpk.ngaynhap, kb.chidinhbacsi, kb.ketluan, bs.tenbacsi ";
        ssql += "FROM benhnhan_phongkhambenh bnpk INNER JOIN khambenh kb ON bnpk.idbenhnhanphongkhambenh = kb.idbenhnhanphongkhambenh ";
        ssql += "INNER JOIN bacsi bs ON kb.idbacsi = bs.idbacsi ";
        ssql += "WHERE bnpk.idbenhnhan = " + iIdbenhnhan;
        ssql += " ORDER BY ngaynhap";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt != null && dt.Rows.Count > 0)
        {
            string html = "<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\" width=\"100%\" bgcolor=\"#FFFFFF\">";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "            <tr >";
                html += "                 <td width=\"20%\" valign=\"top\" bgcolor=\"#B5CFF8\"><p class=\"ptext\"><b>Ngày khám: </b></p></td>";
                html += "                 <td width=\"80%\" valign=\"top\"><p class=\"ptext\" >" + (dt.Rows[i]["ngaynhap"].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[i]["ngaynhap"]).ToString("dd/MM/yyyy")) + "</p></td>";
                html += "             </tr>";
                html += "            <tr >";
                html += "                 <td width=\"20%\" valign=\"top\" bgcolor=\"#B5CFF8\"><p class=\"ptext\"><b>Chỉ định bác sĩ: </b></p></td>";
                html += "                 <td width=\"80%\" valign=\"top\"><p class=\"ptext\" >" + dt.Rows[i]["chidinhbacsi"].ToString() + "</p></td>";
                html += "             </tr>";
                html += "            <tr >";
                html += "                 <td width=\"20%\" valign=\"top\" bgcolor=\"#B5CFF8\"><p class=\"ptext\"><b>Kết luận của bác sĩ: </b></p></td>";
                html += "                 <td width=\"80%\" valign=\"top\"><p class=\"ptext\" >" + dt.Rows[i]["ketluan"].ToString() + "</p></td>";
                html += "             </tr>";
                html += "            <tr >";
                html += "                 <td width=\"20%\" valign=\"top\" bgcolor=\"#B5CFF8\"><p class=\"ptext\"><b>Bác sĩ khám: </b></p></td>";
                html += "                 <td width=\"80%\" valign=\"top\"><p class=\"ptext\" >" + dt.Rows[i]["tenbacsi"].ToString() + "</p></td>";
                html += "             </tr>";
                html += "             <tr>";
                html += "                 <td colspan=\"2\" style = \"height:10px\">";
                html += "               </td>";
                html += "             </tr>";
            }
            html += "         </table>";
            //thongtinhosobenhan.InnerHtml = html;
            //Response.Write(html);
        }
    }
    #endregion
    #endregion
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {

    }

    public void noidungkcb(string idphong)
    {
        if (idphong == null) idphong = "0";
        string sql = "SELECT IDBANGGIADICHVU,TENDICHVU FROM BANGGIADICHVU WHERE IDPHONGKHAMBENH=" + idphong + "";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlnd, dt, "idbanggiadichvu", "tendichvu", "-- Chọn nội dung khám --");

    }

    public void phongkham(string iddichvu)
    {
        string sql = "SELECT Id,TenPhong FROM kb_phong WHERE DichVuKCB=" + iddichvu;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlphongkhamdo, dt, "id", "tenphong", "-- Chọn Phòng Khám --");
    }
    protected void ddlnd_SelectedIndexChanged(object sender, EventArgs e)
    {
        phongkham(ddlnd.SelectedValue);

    }


#region Khoe Thêm 0807
    protected void ddlPhongKhamBenh_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPhongKhamBenh.SelectedValue != "0")
        {
            noidungkcbChuyenDen(ddlPhongKhamBenh.SelectedValue);
        }
    }
    protected void ddlNdCD_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNdCD.SelectedValue != "0")
        {
            phongkhamChuyenDen(ddlNdCD.SelectedValue);
        }
    }

    public void noidungkcbChuyenDen(string idkhoa)
    {
        string sql = "SELECT IDBANGGIADICHVU,TENDICHVU FROM BANGGIADICHVU WHERE IDPHONGKHAMBENH=" + idkhoa + "";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlNdCD, dt, "idbanggiadichvu", "tendichvu", "-- Chọn nội dung khám --");
        if (dt.Rows.Count > 0) ddlnd.SelectedIndex = 1;
        if (ddlNdCD.SelectedValue != "0")
        {
            phongkhamChuyenDen(ddlNdCD.SelectedValue);
        }
    }
    public void phongkhamChuyenDen(string idnoidung)
    {
        string sql = "SELECT Id,TenPhong=ISNULL(MASO +'-','')+ TENPHONG  FROM kb_phong WHERE DichVuKCB=" + idnoidung;
        
        if (this.txtLoaiBN.Value != "0")
        {
            if (this.txtLoaiBN.Value != "2")
            {
                sql += " AND LOAIBN=1";
            }
            else
            {
                sql += " AND LOAIBN=0";
            }
        }

        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPKBCD, dt, "id", "tenphong", "-- Chọn Phòng Khám --");
        if (dt.Rows.Count > 0) ddlPKBCD.SelectedIndex = 1;
    }
    private void LoadPhongKhamBenh()
    {
        string sql = "SELECT * FROM phongkhambenh WHERE idphongkhambenh <> " + StaticData.ParseInt(Session["idphongkham"]) + " and loaiphong = 0";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPhongKhamBenh, dt, "idphongkhambenh", "tenphongkhambenh", "--Chọn Khoa chuyển đến--");
        StaticData.FillCombo(ddlKhoaNhapVien, dt, "idphongkhambenh", "tenphongkhambenh", "--Chọn Khoa nhập viện--");
        
    }
#endregion
}

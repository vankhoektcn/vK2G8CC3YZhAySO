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

public partial class HSBA : Page
{
    public static System.Web.UI.Page P = new Page();
    private string idbn = null;
    private string idkb = "0";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["idbn"] == null)
            {
                Response.Redirect("javascript:window.close();");
            }

            idbn = Request.QueryString["idbn"].ToString();
            if (Request.QueryString["idkb"] != null)
            {
                idkb = Request.QueryString["idkb"].ToString();
            }
            LoadThongtinKhamBenh(idbn, idkb);


        }

    }
    private DataTable loadTTBN(string idbenhnhan)
    {
        string sql = "select bn.*,bn.ngaysinh as tuoi,case when isnull(bn.gioitinh,0)=0 then 'Nam' else N'Nữ' end as gioitinhC from benhnhan bn where idbenhnhan=" + idbenhnhan + "";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        return dt;
    }
    private DataTable LoadThongTinSinhHieu(int idbenhnhan)
    {
        string strsql = "SELECT *, convert(nvarchar, ngaydo, 103) as ngaydo1 FROM sinhhieu WHERE idbenhnhan = " + idbenhnhan + " ORDER BY ngaydo";
        DataTable dt = DataAcess.Connect.GetTable(strsql);
        return dt;

    }
    #region "U Function"

    //Load thong tin kham benh truoc do
    private void LoadThongtinKhamBenh(string idbnKB, string idkb)
    {
        if (idkb != "0" && idkb !="")
        {
            string ssql = "SELECT bn.ngaysinh as tuoi, bn.*, kb.* , bs.tenbacsi ";
            ssql += "FROM khambenh kb ";
            ssql += "LEFT JOIN bacsi bs ON kb.idbacsi = bs.idbacsi ";
            ssql += "LEFT JOIN benhnhan bn ON kb.idbenhnhan = bn.idbenhnhan ";
            ssql += "WHERE kb.idkhambenh in (" + idkb + ") order by kb.idkhambenh asc";
            DataTable dtKB = DataAcess.Connect.GetTable(ssql);
            SetValue(dtKB);
        }
        else
        {
            string ssql = "SELECT bn.ngaysinh as tuoi, bn.*, kb.* , bs.tenbacsi ";
            ssql += "FROM khambenh kb ";
            ssql += "LEFT JOIN bacsi bs ON kb.idbacsi = bs.idbacsi ";
            ssql += "LEFT JOIN benhnhan bn ON kb.idbenhnhan = bn.idbenhnhan ";
            ssql += "WHERE kb.idbenhnhan = " + idbnKB + " order by kb.idkhambenh asc";
            DataTable dtKB = DataAcess.Connect.GetTable(ssql);
            if (dtKB.Rows.Count == 0)
            {
                string ssqlCLS = "SELECT bn.ngaysinh as tuoi, bn.*, kbcls.* , tenbacsi = kbcls.tenBSChiDinh, kb.*";
                ssqlCLS += " FROM khambenhcanlamsan kbcls ";
                ssqlCLS += "LEFT JOIN benhnhan bn ON kbcls.idbenhnhan = bn.idbenhnhan ";
                ssqlCLS += " LEFT JOIN khambenh kb ON kb.idkhambenh = kbcls.idkhambenh ";
                ssqlCLS += "WHERE kbcls.idbenhnhan = " + idbnKB + "";
                dtKB = DataAcess.Connect.GetTable(ssqlCLS);
                DataTable dt = dtKB;
                if (dt.Rows.Count == 0)
                {
                    Response.Write("\nBệnh nhân này không có dữ liệu hoặc không đăng ký khám bệnh");
                }
                else
                {
                    SetValueCLS(dt);
                }
            }
            else
            {
                DataTable dt = dtKB;
                SetValue(dt);
            }
        }

    }
    private DataTable loadTitle()
    {
        string ssql = "SELECT * ";
        ssql += "FROM TieuDeCTy kb ";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        return dt;
    }
    private void SetValue(DataTable dtsrc)
    {
        if (dtsrc != null && dtsrc.Rows.Count != 0)
        {
            string[] arr = new string[10] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
            string html = "";
            DataTable listTitle = loadTitle();
            DataTable dtBN = loadTTBN(idbn);
            string sdoituong = "";
            if (dtBN.Rows[0]["loai"].ToString() == "0")
                sdoituong = "Thu phí";
            else if (dtBN.Rows[0]["loai"].ToString() == "1")
                sdoituong = "Có bảo hiểm";
            else
                sdoituong = "Khác";
            string sloai = "";
            if (StaticData.ParseInt(dtBN.Rows[0]["loai"]) == 0)
                sloai = "Thu phí";
            else if (StaticData.ParseInt(dtBN.Rows[0]["tuoi"]) == 1)
                sloai = "Có bảo hiểm";
            else if (StaticData.ParseInt(dtBN.Rows[0]["tuoi"]) == 2)
                sloai = "Miễn phí";
            else if (StaticData.ParseInt(dtBN.Rows[0]["tuoi"]) == 3)
                sloai = "Khác";


            #region ma vach
            string mabenhnhan = dtBN.Rows[0]["mabenhnhan"].ToString();
            iTextSharp.text.pdf.Barcode128 barcode = new iTextSharp.text.pdf.Barcode128();
            barcode.ChecksumText = false;
            barcode.Code = mabenhnhan;
            System.Drawing.Image bmp = barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
            Byte[] arrByte = (Byte[])System.ComponentModel.TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
            string ImageFile = P.Server.MapPath("~/images/imagebn.bmp");//../App_Data/01.jpg
            try
            {
                if (System.IO.File.Exists(ImageFile))
                    System.IO.File.Delete(ImageFile);
                bmp.Save(ImageFile);
            }
            catch (Exception)
            {

            }
            //dtsrc.Columns.Add("mavach", arrByte.GetType());
            //dtsrc.Rows[0]["logo"] = arrByte;
            #endregion
            html += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            html += "  	</tr>";
            for (int iTitle = 0; iTitle < listTitle.Rows.Count; iTitle++)
            {

                html += "	<tr width = \"100%\">";
                html += "		<td VALIGN = \"top\" width = \"100px\" style=\"\" align = \"left\"><img id=\"img\" src='../images/" + listTitle.Rows[iTitle]["logo"].ToString() + "' style=\"height:100px;width:100px;border-width:0px;\"  /></td>";
                html += "<td VALIGN = \"top\" width = \"35%\" class=\"tieude\" style=\"padding-top:10px\" align = \"center\"><label style='text-align:center'><b>" + listTitle.Rows[iTitle]["Ten_Cty"].ToString().Replace("-", "\r\n") + "</b><BR>" + listTitle.Rows[iTitle]["DiaChi"].ToString() + "</label></td>";
                html += "		<td VALIGN = \"top\" width = \"65%\" class=\"tieude\" style=\"padding-top:10px;padding-left:70px\" align = \"center\"><b>CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR><div style=\"margin-right:0px\">Độc lập - Tự do - Hạnh phúc</b></div><BR><BR></td>";
                html += "  	</tr>";
                html += "  	<tr>";
                html += "  	<td colspan=\"3\">";
                html += "<table width=\"100%\" >";
                html += "<tr>";
                html += "		<td colspan=\"2\" style=\"padding-bottom:10px;width:65%\"  align = \"right\"><FONT face=\"Arial, Helvetica, sans-serif\" size=\"+3\" color=\"red\">HỒ SƠ BỆNH ÁN</FONT></td>";
                html += "</td>";
                html += "<td style=\"width:70%\" align=\"right\">";
                html += "<table width=\"100%\" >";
                html += "<tr>";//<asp:Image ID="Image1" runat="server" ImageUrl="~/App_Data/imagebn.JPG" />
                html += "<td style=\"width:100%\" align=\"right\"><img id=\"img\" src='../images/imagebn.bmp' style=\"height:35px;width:150px;border-width:0px;\"  />";
                html += "</td>";
                html += "</tr>";
                html += "<tr>";
                html += "<td style=\"width:100%\" align=\"right\"><b>" + dtBN.Rows[0]["mabenhnhan"].ToString() + "</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                html += "</td>";
                html += "</tr>";
                html += "</table>";
                html += "</td>";
                html += "</tr>";
                html += "</table>";

                html += "  	</td>";
                html += "  	</tr>";

            }
            html += "</table>";
            html += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            html += "  	<tr>";
            html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px\" bgcolor=\"#B5CFF8\">I. HÀNH CHÍNH</td>";
            html += "  	</tr>";

            html += "  	<tr>";
            html += "		<td colspan=\"2\" class=\"phpmaker\" style=\"padding-bottom:10px\">";
            html += "			<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"50%\">1.&nbsp;Tên BN : <b>" + dtBN.Rows[0]["tenbenhnhan"].ToString() + "</b></td>";

            html += "				<td width=\"50%\"></td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"50%\">2.&nbsp;Email :  " + dtBN.Rows[0]["email"].ToString() + "<label style='color:blue'><b>,</b></label> Điện thoại:&nbsp;" + dtBN.Rows[0]["dienthoai"].ToString() + "</td>";

            html += "				<td width=\"100%\" colspan=\"2\">3.&nbsp;Giới tính " + dtBN.Rows[0]["gioitinhC"].ToString() + "</td>";

            //-------------------
            html += "			  </tr>";
            html += "			 <tr style=\"padding-top:7px\">";
            html += "				<td width=\"50%\">4.&nbsp;Ngày sinh : " + dtBN.Rows[0]["ngaysinh"].ToString() + " , CMND:   " + dtBN.Rows[0]["chungminhthu"].ToString() + "</td>";
            html += "				<td width=\"50%\">5.&nbsp;Địa chỉ : <b>" + dtBN.Rows[0]["diachi"].ToString() + " </b></td>";

            html += "			  </tr>";

            html += "			 <tr style=\"padding-top:7px\">";
            html += "				<td width=\"50%\">6.&nbsp;Tên người liên hệ : <b>" + dtBN.Rows[0]["NguoiLH"].ToString() + " </b>, điện thoại LH: <b>" + dtBN.Rows[0]["DienThoaiLH"].ToString() + " </b></td>";
            if (StaticData.GetParameter("IsHaveMuc78910_InHSBA") == "1")
            {
                html += "				<td width=\"50%\">7.&nbsp;Địa chỉ liên hệ:  " + dtBN.Rows[0]["DiaChiLH"].ToString() + "</td>";

                html += "			  </tr>";

                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"50%\">8.&nbsp;Nơi giới thiệu: " + dtBN.Rows[0]["noigioithieu"].ToString() + "</td>";
                html += "				<td width=\"50%\">9.&nbsp;Lý do vào khám: " + dtBN.Rows[0]["chandoansobo"].ToString();
                html += "				</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"50%\">10.&nbsp;Hình thức tiếp nhận: " + sdoituong + "</td>";
                html += "				<td width=\"50%\">11.&nbsp;Ngày, giờ thực hiện : " + Convert.ToDateTime(dtBN.Rows[0]["ngaytiepnhan"].ToString()).ToString("dd/MM/yyyy HH:mm") + " ";
                html += "				</td>";
            }
            else
            {
                html += "				<td width=\"50%\">7.&nbsp;Ngày, giờ thực hiện : " + Convert.ToDateTime(dtBN.Rows[0]["ngaytiepnhan"].ToString()).ToString("dd/MM/yyyy HH:mm") + " ";
                html += "				</td>";
                html += "			  </tr>";

                //html += "			  <tr style=\"padding-top:7px\">";
                //html += "				<td width=\"50%\">8.&nbsp;Nơi giới thiệu: " + dtBN.Rows[0]["noigioithieu"].ToString() + "</td>";
                //html += "				<td width=\"50%\">9.&nbsp;Lý do vào khám: " + dtBN.Rows[0]["chandoansobo"].ToString();
                //html += "				</td>";
                //html += "			  </tr>";
                //html += "			  <tr style=\"padding-top:7px\">";
                //html += "				<td width=\"50%\">10.&nbsp;Hình thức tiếp nhận: " + sdoituong + "</td>";

            }

            html += "			  </tr>";

            DataTable dt = LoadThongTinSinhHieu(StaticData.ParseInt(dtBN.Rows[0]["idbenhnhan"]));
            if (dt != null && dt.Rows.Count > 0)
            {
                html += "  	<tr>";
                html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px\" bgcolor=\"#B5CFF8\">II. THÔNG TIN SINH HIỆU</td>";
                html += "  	</tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "  	<tr>";
                    html += "		<td colspan=\"2\"  style=\"padding-bottom:10px; padding-top:10px;font-size:12pt;font-weight:bold\" bgcolor=\"\">Ngày đo: " + dt.Rows[i]["ngaydo1"].ToString() + "</td>";
                    html += "  	</tr>";
                    html += "			   <tr style=\"padding-top:7px\">";
                    html += "				<td width=\"50%\">&nbsp;Mạch : " + dt.Rows[i]["mach"].ToString() + " lần/phút  ,  nhịp thở:   " + dt.Rows[i]["nhiptho"].ToString() + " lần/phút </td>";
                    html += "				<td width=\"50%\">&nbsp;Chiều cao :" + (dt.Rows[i]["chieucao"].ToString() == "" ? "" : dt.Rows[i]["chieucao"].ToString()) + " cm <label style='color:blue'><b>,</b></label> ";
                    html += "                 Trọng lượng : " + (dt.Rows[i]["cannang"].ToString() == ""? "" : dt.Rows[i]["cannang"].ToString()) + " kg <label style='color:blue'><b>,</b></label> Trị số BMI : " + dt.Rows[i]["BMI"] + " ";
                    html += "				</td>";
                    html += "			  </tr>";
                    html += "			  <tr style=\"padding-top:7px; padding-bottom:10px\">";
                    html += "				<td width=\"50%\" >&nbsp;Huyết áp : " + dt.Rows[i]["huyetap1"].ToString() + "/" + dt.Rows[i]["huyetap2"].ToString() + " lần/phút  ,Nhiệt độ:  " + dt.Rows[i]["nhietdo"].ToString() + " độ C    </td>";
                    html += "				<td width=\"50%\">Dị ứng thuốc:  " + dt.Rows[i]["diungthuoc"].ToString() + "    </td>";//&nbsp;Tiền sử bệnh: " + dt.Rows[i]["tiensubenh"].ToString() + " ,
                    html += "			  </tr>";
                }

            }
            else
            {
                html += "  	<tr>";
                html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px\" bgcolor=\"#B5CFF8\">II. THÔNG TIN SINH HIỆU</td>";
                html += "  	</tr>";
                html += "			   <tr style=\"padding-top:7px\">";
                html += "				<td width=\"50%\">13.&nbsp;Mạch, nhịp thở:  lần/phút  , lần/phút </td>";
                html += "				<td width=\"50%\">14.&nbsp;Chiều cao : cm<label style='color:blue'> <b>,</b></label> Trọng lượng : kg<label style='color:blue'><b>,</b></label> Trị số BMI:   ";
                html += "				</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px; padding-bottom:10px\">";
                html += "				<td width=\"50%\">15.&nbsp;Huyết áp : lần/phút <label style='color:blue'><b>,</b></label> Nhiệt độ: độ C</td>";
                html += "				<td width=\"50%\" >16.&nbsp;Tiền sử bệnh: ,Dị ứng thuốc:      </td>";
                html += "			  </tr>";

            }
            //html += "			  <tr style=\"padding-top:7px\">";
            //html += "				<td width=\"100%\" colspan=\"2\">11.&nbsp;Họ tên địa chỉ người nhà khi cần báo tin: " + dt.Rows[0]["thongtinbaotin"].ToString() + "</td>";

            //html += "			  </tr>";              			  
            html += "			</table>";
            html += "		</td>";
            html += "   </tr>";
            for (int i = 0; i < dtsrc.Rows.Count; i++)
            {
                html += "  	<tr>";
                if (dtsrc.Rows.Count > 1)
                {
                    html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px; padding-top:10px\" bgcolor=\"#B5CFF8\">" + arr[i + 2] + ".THÔNG TIN KHÁM BỆNH LẦN " + (i + 1) + "</td>";
                }
                if (dtsrc.Rows.Count <= 1)
                {
                    html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px; padding-top:10px\" bgcolor=\"#B5CFF8\"  >" + arr[i + 2] + ".THÔNG TIN KHÁM BỆNH</td>";
                }


                html += "  	</tr>";
                html += "  	<tr>";
                html += "		<td colspan=\"2\" class=\"phpmaker\" style=\"padding-bottom:10px\">";
                html += "			<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Ngày nhập khám: </td>";
                html += "				<td width=\"80%\">" + (dtsrc.Rows[i]["ngaykham"].ToString() == "" ? "" : Convert.ToDateTime(dtsrc.Rows[i]["ngaykham"]).ToString("dd/MM/yyyy")) + "</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Họ tên bác sĩ khám bệnh: </td>";
                if (dtsrc.Rows[i]["tenbacsi"].ToString() != "")
                {
                    html += "				<td width=\"80%\"><b>" + dtsrc.Rows[i]["tenbacsi"].ToString() + "</b></td>";
                }
                else
                {
                    html += "				<td width=\"80%\"><b>Bệnh nhân này tự đến</b></td>";
                }
                html += "			  </tr>";

                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Tiền sử: </td>";
                html += "				<td width=\"80%\">" + dtsrc.Rows[i]["tiensu"].ToString() + "</td>";
                html += "			  </tr>";

                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Bệnh sử: </td>";
                html += "				<td width=\"80%\">" + dtsrc.Rows[i]["trieuchung"].ToString() + "</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Thăm khám: </td>";
                html += "				<td width=\"80%\">" + dtsrc.Rows[i]["benhsu"].ToString() + "</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Chẩn đoán ban đầu: </td>";
                html += "				<td width=\"80%\">" + dtsrc.Rows[i]["chandoanbandau"].ToString() + "</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Chẩn đoán xác định: </td>";
                html += "				<td width=\"80%\">" + StaticData.GetValue("ChanDoanICD", "IDICD", StaticData.ParseInt(dtsrc.Rows[i]["ketluan"]), "MoTa") + "</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Chẩn đoán phân biệt 1: </td>";
                html += "				<td width=\"80%\">" + StaticData.GetValue("ChanDoanICD", "IDICD", StaticData.ParseInt(dtsrc.Rows[i]["ketluan1"]), "MoTa") + "</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Chẩn đoán phân biệt 2: </td>";
                html += "				<td width=\"80%\">" + StaticData.GetValue("ChanDoanICD", "IDICD", StaticData.ParseInt(dtsrc.Rows[i]["ketluan2"]), "MoTa") + "</td>";
                html += "			  </tr>";

                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">" + StaticData.GetParameter("TenHuongDieuTri") + ": </td>";
                html += "				<td width=\"80%\">" + GetHuongDieuTri(StaticData.ParseInt(dtsrc.Rows[i]["huongdieutri"])) + GetChiTietHuongDT(StaticData.ParseInt(dtsrc.Rows[i]["huongdieutri"]), StaticData.ParseInt(dtsrc.Rows[i]["phongkhamchuyenden"]), dtsrc.Rows[i]["idPhongChuyenDen"].ToString(), dtsrc.Rows[i]["idDVPhongChuyenDen"].ToString(), dtsrc.Rows[i]["ghichuhuongdieutri"].ToString()) + "</td>";
                html += "			  </tr>";


                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Chỉ định bác sĩ: </td>";
                html += "				<td width=\"80%\">" + dtsrc.Rows[i]["chidinhbacsi"].ToString() + "</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Dặn dò của bác sĩ: </td>";
                html += "				<td width=\"80%\">" + dtsrc.Rows[i]["dando"].ToString() + "</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Nội dung tái khám: </td>";
                html += "				<td width=\"80%\">" + dtsrc.Rows[i]["noidungtaikham"].ToString() + "</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"20%\">Ngày hẹn tái khám: </td>";
                html += "				<td width=\"80%\">" + (dtsrc.Rows[i]["ngayhentaikham"].ToString() == "" ? "" : Convert.ToDateTime(dtsrc.Rows[i]["ngayhentaikham"]).ToString("dd/MM/yyyy")) + "</td>";
                html += "			  </tr>";
                html += "			</table>";
                html += "		</td>";
                html += "   </tr>";





                html += "  	<tr>";

                html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px; padding-top:10px;font-size:10pt\" bgcolor=\"#B5CFF8\">- THÔNG TIN CẬN LÂM SÀNG</td>";



                html += "  	</tr>";

                //////// Van Khoe 0606
                string sqlCheckIDBN1 = "select * from khambenhcanlamsan where idbenhnhan =" + idbn + "";
                DataTable dtCheck1 = DataAcess.Connect.GetTable(sqlCheckIDBN1);
                if (dtCheck1 == null || dtCheck1.Rows.Count == 0)
                {
                    sqlCheckIDBN1 = "SELECT idkhambenhcanlamsan FROM dieutricanlamsan   WHERE idkhambenhcanlamsan = " + StaticData.ParseInt(dtsrc.Rows[i]["idkhambenh"]) + "";
                    dtCheck1 = DataAcess.Connect.GetTable(sqlCheckIDBN1);
                    if (dtCheck1 == null || dtCheck1.Rows.Count == 0)
                    {
                        html += "   <tr style=\"padding-top:7px\">";
                        html += "		<td colspan=\"2\" width=\"20%\" valign = \"top\">Chỉ định CLS: </td>";

                        html += "	</tr>";
                        html += "   <tr style=\"padding-top:7px;padding-left:20px\">";
                        //html += "	<td colspan=\"2\" align = \"left\" width=\"80%\">";
                        //html += " <table width=\"100%\">";
                        //html += " <tr >";
                        html += " <td colspan=\"2\" width=\"100%\">" + LoadChiDinhCanLamSang(StaticData.ParseInt(dtsrc.Rows[i]["idkhambenh"])) + "";
                        html += " </td >";
                        //html += " </tr >";
                        //html += " </table>";
                        //html += "</td>";
                        html += "	</tr>";
                    }
                    else
                    {
                        //html += "   <tr style=\"padding-top:7px\">";
                        //html += "		<td width=\"20%\" valign = \"top\">Kết quả CLS: </td>";
                        //html += "		<td  width = \"100%\" class=\"ptext\" style=\"padding-bottom:10px; padding-top:7px\">" + LoadKetQuaKhamCanLamSang(StaticData.ParseInt(dtsrc.Rows[i]["idkhambenh"])) + "</td>";
                        //html += "	</tr>";
                        html += "  	<tr style=\"padding-top:7px\">";
                        html += "		<td colspan=\"2\" width=\"20%\" valign = \"top\">Kết quả CLS: </td>";
                        html += "  	</tr>";
                        html += "  	<tr style=\"padding-top:7px;padding-left:0px\">";
                        html += "		<td colspan=\"2\"  width = \"100%\" class=\"ptext\" style=\"padding-bottom:10px; padding-top:7px\">" + LoadKetQuaKhamCanLamSang(StaticData.ParseInt(dtsrc.Rows[i]["idkhambenh"])) + "</td>";
                        html += "  	</tr>";
                    }
                }
                else
                {
                    sqlCheckIDBN1 = "SELECT idkhambenhcanlamsan FROM dieutricanlamsan  WHERE idbenhnhan = " + idbn + "";
                    dtCheck1 = DataAcess.Connect.GetTable(sqlCheckIDBN1);
                    if (dtCheck1 != null && dtCheck1.Rows.Count == 0)
                    {
                        html += "   <tr style=\"padding-top:7px\">";
                        html += "		<td colspan=\"2\" width=\"20%\" valign = \"top\">Chỉ định CLS: </td>";

                        html += "	</tr>";
                        html += "   <tr style=\"padding-top:7px;padding-left:20px\">";
                        html += " <td colspan=\"2\" width=\"100%\">" + LoadChiDinhCanLamSang(StaticData.ParseInt(dtsrc.Rows[i]["idkhambenh"])) + "";
                        html += " </td >";
                        html += "	</tr>";
                    }
                    else
                    {
                        html += "   <tr style=\"padding-top:7px\">";
                        html += "		<td colspan=\"2\" width=\"20%\" valign = \"top\">Kết quả CLS: </td>";
                        html += "	</tr>";
                        html += "	<tr style=\"padding-top:7px;padding-left:0px\">";
                        html += "		<td colspan=\"2\" width = \"100%\" class=\"ptext\" style=\"padding-bottom:10px; padding-top:7px\">" + LoadKetQuaKhamCanLamSang(StaticData.ParseInt(dtsrc.Rows[i]["idkhambenh"])) + "</td>";
                        html += "	</tr>";
                    }

                }

                ///////End Van Khoe 0606
                html += "  	<tr>";
                html += "  	<td colspan=\"2\">";
                html += "  	<td>";
                html += "  	</tr>";

                html += "  	<tr>";

                html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px; padding-top:10px;font-size:10pt\" bgcolor=\"#B5CFF8\">- TOA THUỐC</td>";


                html += "  	</tr>";
                html += "   <tr style=\"padding-top:7px\">";

                html += "		<td width=\"80%\" align = \"left\">" + loadChiTietQuaTrinhDieuTri(StaticData.ParseInt(dtsrc.Rows[i]["idkhambenh"])) + "</td>";
                html += "	</tr>";

            }

            //ThuanNH tam rem 27/04/2010
            //html += "  	<tr>";
            //html += "		<td colspan=\"2\" width = \"100%\" class=\"tieude\" style=\"padding-bottom:10px; padding-top:10px\" bgcolor=\"#B5CFF8\">IV. THÔNG TIN TOA THUỐC</td>";
            //html += "  	</tr>";

            //html += "  	<tr>";
            //html += "		<td colspan=\"2\" class=\"phpmaker\" style=\"padding-bottom:0px; padding-top:0px\">" + LoadChiTietThongTinToaThuocBenhNhan(dtsrc.Rows[i]["idkhambenh"].ToString()) + "<br></td>";
            //html += "  	</tr>";

            html += "</table>";

            divnoidung.InnerHtml = html;
        }
    }
    private void SetValueCLS(DataTable dtsrc)
    {
        if (dtsrc != null && dtsrc.Rows.Count != 0)
        {
            string[] arr = new string[10] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };

            string html = "";
            DataTable listTitle = loadTitle();
            DataTable dtBN = loadTTBN(idbn);
            string sdoituong = "";
            if (dtBN.Rows[0]["loai"].ToString() == "0")
                sdoituong = "Thu phí";
            else if (dtBN.Rows[0]["loai"].ToString() == "1")
                sdoituong = "Có bảo hiểm";
            else
                sdoituong = "Khác";
            //ThuanNH 26/04/2010
            string sloai = "";
            if (StaticData.ParseInt(dtBN.Rows[0]["loai"]) == 0)
                sloai = "Thu phí";
            else if (StaticData.ParseInt(dtBN.Rows[0]["tuoi"]) == 1)
                sloai = "Có bảo hiểm";
            else if (StaticData.ParseInt(dtBN.Rows[0]["tuoi"]) == 2)
                sloai = "Miễn phí";
            else if (StaticData.ParseInt(dtBN.Rows[0]["tuoi"]) == 3)
                sloai = "Khác";

            #region ma vach
            string mabenhnhan = dtBN.Rows[0]["mabenhnhan"].ToString();
            iTextSharp.text.pdf.Barcode128 barcode = new iTextSharp.text.pdf.Barcode128();
            barcode.ChecksumText = false;
            barcode.Code = mabenhnhan;
            System.Drawing.Image bmp = barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
            Byte[] arrByte = (Byte[])System.ComponentModel.TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
            string ImageFile = P.Server.MapPath("~/images/imagebn.bmp");//../App_Data/01.jpg
            //bmp.Save(ImageFile);
            //dtsrc.Columns.Add("mavach", arrByte.GetType());
            //dtsrc.Rows[0]["logo"] = arrByte;
            #endregion
            html += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            for (int iTitle = 0; iTitle < listTitle.Rows.Count; iTitle++)
            {

                html += "	<tr width = \"100%\">";
                html += "		<td VALIGN = \"top\" width = \"100px\" style=\"\" align = \"left\"><img id=\"img\" src='../images/" + listTitle.Rows[iTitle]["logo"].ToString() + "' style=\"height:100px;width:100px;border-width:0px;\"  /></td>";
                html += "<td VALIGN = \"top\"  class=\"tieude\" style=\"padding-top:10px\" align = \"center\"><label style='text-align:center'>" + listTitle.Rows[iTitle]["Ten_Cty"].ToString() + "</label></td>";
                html += "		<td VALIGN = \"top\" width = \"60%\" class=\"tieude\" style=\"padding-top:10px;padding-left:70px\" align = \"center\">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR><div style=\"margin-right:0px\">Độc lập - Tự do - Hạnh phúc</div><BR><BR></td>";
                html += "  	</tr>";
                html += "  	<tr>";
                html += "  	<td colspan=\"3\">";
                html += "<table width=\"100%\" >";
                html += "<tr>";
                html += "		<td colspan=\"2\" style=\"padding-bottom:10px;width:65%\"  align = \"right\"><FONT face=\"Arial, Helvetica, sans-serif\" size=\"+3\" color=\"red\">HỒ SƠ BỆNH ÁN</FONT></td>";
                html += "</td>";
                html += "<td style=\"width:70%\" align=\"right\">";
                html += "<table width=\"100%\" >";
                html += "<tr>";//<asp:Image ID="Image1" runat="server" ImageUrl="~/App_Data/imagebn.JPG" />
                html += "<td style=\"width:100%\" align=\"right\"><img id=\"img\" src='../images/imagebn.bmp' style=\"height:35px;width:150px;border-width:0px;\"  />";
                html += "</td>";
                html += "</tr>";
                html += "<tr>";
                html += "<td style=\"width:100%\" align=\"right\"><b>" + dtBN.Rows[0]["mabenhnhan"].ToString() + "</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                html += "</td>";
                html += "</tr>";
                html += "</table>";
                html += "</td>";
                html += "</tr>";
                html += "</table>";

                html += "  	</td>";
                html += "  	</tr>";

            }
            html += "</table>";
            html += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            html += "  	<tr>";
            html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px\" bgcolor=\"#B5CFF8\">I. HÀNH CHÍNH</td>";
            html += "  	</tr>";

            html += "  	<tr>";
            html += "		<td colspan=\"2\" class=\"phpmaker\" style=\"padding-bottom:10px\">";
            html += "			<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"50%\">1.&nbsp;Tên BN : <b>" + dtBN.Rows[0]["tenbenhnhan"].ToString() + "</b></td>";

            html += "				<td width=\"50%\"></td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"50%\">2.&nbsp;Email :  " + dtBN.Rows[0]["email"].ToString() + "<label style='color:blue'><b>,</b></label> Điện thoại:&nbsp;" + dtBN.Rows[0]["dienthoai"].ToString() + "</td>";

            html += "				<td width=\"100%\" colspan=\"2\">3.&nbsp;Giới tính " + dtBN.Rows[0]["gioitinhC"].ToString() + "</td>";

            //-------------------
            html += "			  </tr>";
            html += "			 <tr style=\"padding-top:7px\">";
            html += "				<td width=\"50%\">4.&nbsp;Ngày sinh : " + dtBN.Rows[0]["ngaysinh"].ToString() + " , CMND:   " + dtBN.Rows[0]["chungminhthu"].ToString() + "</td>";
            html += "				<td width=\"50%\">5.&nbsp;Địa chỉ : <b>" + dtBN.Rows[0]["diachi"].ToString() + " </b></td>";

            html += "			  </tr>";

            html += "			 <tr style=\"padding-top:7px\">";
            html += "				<td width=\"50%\">6.&nbsp;Tên người liên hệ : <b>" + dtBN.Rows[0]["NguoiLH"].ToString() + " </b>, điện thoại LH: <b>" + dtBN.Rows[0]["DienThoaiLH"].ToString() + " </b></td>";
            if (StaticData.GetParameter("IsHaveMuc78910_InHSBA") == "1")
            {
                html += "				<td width=\"50%\">7.&nbsp;Địa chỉ liên hệ:  " + dtBN.Rows[0]["DiaChiLH"].ToString() + "</td>";

                html += "			  </tr>";

                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"50%\">8.&nbsp;Nơi giới thiệu: " + dtBN.Rows[0]["noigioithieu"].ToString() + "</td>";
                html += "				<td width=\"50%\">9.&nbsp;Lý do vào khám: " + dtBN.Rows[0]["chandoansobo"].ToString();
                html += "				</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px\">";
                html += "				<td width=\"50%\">10.&nbsp;Hình thức tiếp nhận: " + sdoituong + "</td>";
                html += "				<td width=\"50%\">11.&nbsp;Ngày, giờ thực hiện : " + Convert.ToDateTime(dtBN.Rows[0]["ngaytiepnhan"].ToString()).ToString("dd/MM/yyyy HH:mm") + " ";
                html += "				</td>";
            }
            else
            {
                html += "				<td width=\"50%\">7.&nbsp;Ngày, giờ thực hiện : " + Convert.ToDateTime(dtBN.Rows[0]["ngaytiepnhan"].ToString()).ToString("dd/MM/yyyy HH:mm") + " ";
                html += "				</td>";
                html += "			  </tr>";

            }
            DataTable dt = LoadThongTinSinhHieu(StaticData.ParseInt(dtBN.Rows[0]["idbenhnhan"]));
            if (dt != null && dt.Rows.Count > 0)
            {

                html += "			   <tr style=\"padding-top:7px\">";
                html += "				<td width=\"50%\">12.&nbsp;Mạch : " + dt.Rows[0]["mach"].ToString() + " lần/phút  ,  nhịp thở:   " + dt.Rows[0]["nhiptho"].ToString() + " lần/phút </td>";
                html += "				<td width=\"50%\">13.&nbsp;Chiều cao :" + dt.Rows[0]["chieucao"].ToString() + " cm <label style='color:blue'><b>,</b></label> Trọng lượng : " + dt.Rows[0]["cannang"].ToString() + " kg <label style='color:blue'><b>,</b></label> Trị số BMI : " + Math.Round(Convert.ToDouble(dt.Rows[0]["BMI"]), 2) + " ";
                html += "				</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px; padding-bottom:10px\">";
                html += "				<td width=\"50%\" >14.&nbsp;Huyết áp : " + dt.Rows[0]["huyetap1"].ToString() + "/" + dt.Rows[0]["huyetap2"].ToString() + " lần/phút  ,Nhiệt độ:  " + dt.Rows[0]["nhietdo"].ToString() + " độ C    </td>";
                html += "				<td width=\"50%\">15.&nbsp;Tiền sử bệnh: " + dt.Rows[0]["tiensubenh"].ToString() + " ,Dị ứng thuốc:  " + dt.Rows[0]["diungthuoc"].ToString() + "    </td>";
                html += "			  </tr>";

            }
            else
            {
                html += "			   <tr style=\"padding-top:7px\">";
                html += "				<td width=\"50%\">14.&nbsp;Mạch, nhịp thở:  lần/phút  , lần/phút </td>";
                html += "				<td width=\"50%\">15.&nbsp;Chiều cao : cm<label style='color:blue'> <b>,</b></label> Trọng lượng : kg<label style='color:blue'><b>,</b></label> Trị số BMI:   ";
                html += "				</td>";
                html += "			  </tr>";
                html += "			  <tr style=\"padding-top:7px; padding-bottom:10px\">";
                html += "				<td width=\"50%\">16.&nbsp;Huyết áp : lần/phút <label style='color:blue'><b>,</b></label> Nhiệt độ: độ C</td>";
                html += "				<td width=\"50%\" >17.&nbsp;Tiền sử bệnh: ,Dị ứng thuốc:      </td>";
                html += "			  </tr>";

            }
            //html += "			  <tr style=\"padding-top:7px\">";
            //html += "				<td width=\"100%\" colspan=\"2\">11.&nbsp;Họ tên địa chỉ người nhà khi cần báo tin: " + dt.Rows[0]["thongtinbaotin"].ToString() + "</td>";

            //html += "			  </tr>";              			  
            html += "			</table>";
            html += "		</td>";
            html += "   </tr>";

            html += "  	<tr>";


            html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px; padding-top:10px\" bgcolor=\"#B5CFF8\"  >" + arr[1] + ".THÔNG TIN KHÁM BỆNH</td>";



            html += "  	</tr>";
            html += "  	<tr>";
            html += "		<td colspan=\"2\" class=\"phpmaker\" style=\"padding-bottom:10px\">";
            html += "			<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Ngày nhập khám: </td>";
            html += "				<td width=\"80%\">" + (dtsrc.Rows[0]["ngaykham"].ToString() == "" ? "" : Convert.ToDateTime(dtsrc.Rows[0]["ngaykham"]).ToString("dd/MM/yyyy")) + "</td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Họ tên bác sĩ khám bệnh: </td>";
            if (dtsrc.Rows[0]["tenbacsi"].ToString() != "")
            {
                html += "				<td width=\"80%\"><b>" + dtsrc.Rows[0]["tenbacsi"].ToString() + "</b></td>";
            }
            else
            {
                html += "				<td width=\"80%\"><b>Bệnh nhân này tự đến</b></td>";
            }
            html += "			  </tr>";

            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Tiền sử: </td>";
            html += "				<td width=\"80%\">" + dtsrc.Rows[0]["tiensu"].ToString() + "</td>";
            html += "			  </tr>";

            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Bệnh sử: </td>";
            html += "				<td width=\"80%\">" + dtsrc.Rows[0]["trieuchung"].ToString() + "</td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Thăm khám: </td>";
            html += "				<td width=\"80%\">" + dtsrc.Rows[0]["benhsu"].ToString() + "</td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Chẩn đoán ban đầu: </td>";
            html += "				<td width=\"80%\">" + dtsrc.Rows[0]["chandoanbandau"].ToString() + "</td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Chẩn đoán xác định: </td>";
            html += "				<td width=\"80%\">" + StaticData.GetValue("ChanDoanICD", "IDICD", StaticData.ParseInt(dtsrc.Rows[0]["ketluan"]), "MoTa") + "</td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Chẩn đoán phân biệt 1: </td>";
            html += "				<td width=\"80%\">" + StaticData.GetValue("ChanDoanICD", "IDICD", StaticData.ParseInt(dtsrc.Rows[0]["ketluan1"]), "MoTa") + "</td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Chẩn đoán phân biệt 2: </td>";
            html += "				<td width=\"80%\">" + StaticData.GetValue("ChanDoanICD", "IDICD", StaticData.ParseInt(dtsrc.Rows[0]["ketluan2"]), "MoTa") + "</td>";
            html += "			  </tr>";

            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">" + StaticData.GetParameter("TenHuongDieuTri") + ": </td>";
            html += "				<td width=\"80%\">" + GetHuongDieuTri(StaticData.ParseInt(dtsrc.Rows[0]["huongdieutri"])) + GetChiTietHuongDT(StaticData.ParseInt(dtsrc.Rows[0]["huongdieutri"]), StaticData.ParseInt(dtsrc.Rows[0]["phongkhamchuyenden"]), dtsrc.Rows[0]["idPhongChuyenDen"].ToString(), dtsrc.Rows[0]["idDVPhongChuyenDen"].ToString(), dtsrc.Rows[0]["ghichuhuongdieutri"].ToString()) + "</td>";
            html += "			  </tr>";


            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Chỉ định bác sĩ: </td>";
            html += "				<td width=\"80%\">" + dtsrc.Rows[0]["chidinhbacsi"].ToString() + "</td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Dặn dò của bác sĩ: </td>";
            html += "				<td width=\"80%\">" + dtsrc.Rows[0]["dando"].ToString() + "</td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Nội dung tái khám: </td>";
            html += "				<td width=\"80%\">" + dtsrc.Rows[0]["noidungtaikham"].ToString() + "</td>";
            html += "			  </tr>";
            html += "			  <tr style=\"padding-top:7px\">";
            html += "				<td width=\"20%\">Ngày hẹn tái khám: </td>";
            html += "				<td width=\"80%\">" + (dtsrc.Rows[0]["ngayhentaikham"].ToString() == "" ? "" : Convert.ToDateTime(dtsrc.Rows[0]["ngayhentaikham"]).ToString("dd/MM/yyyy")) + "</td>";
            html += "			  </tr>";
            html += "			</table>";
            html += "		</td>";
            html += "   </tr>";





            html += "  	<tr>";


            html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px; padding-top:10px;font-size:10pt\" bgcolor=\"#B5CFF8\">THÔNG TIN CẬN LÂM SÀNG</td>";


            html += "  	</tr>";
            //html += "   <tr style=\"padding-top:7px\">";
            //html += "		<td width=\"20%\" valign = \"top\">Chỉ định CLS: </td>";
            ////html += "		<td width=\"80%\" align = \"left\">" + LoadChiDinhCanLamSang(StaticData.ParseInt(dtsrc.Rows[0]["idkhambenh"])) + "</td>";
            //html += "	</tr>";

            //html += "  	<tr>";
            //html += "		<td colspan=\"2\" width = \"100%\" class=\"ptext\" style=\"padding-bottom:10px; padding-top:7px\">" + LoadKetQuaKhamCanLamSang(StaticData.ParseInt(dtsrc.Rows[0]["idkhambenh"])) + "</td>";
            //html += "  	</tr>";

            //////// Van Khoe 0606
            string sqlCheckIDBN1 = "select * from khambenhcanlamsan where idbenhnhan =" + idbn + "";
            DataTable dtCheck1 = DataAcess.Connect.GetTable(sqlCheckIDBN1);
            if (dtCheck1 == null || dtCheck1.Rows.Count == 0)
            {
                sqlCheckIDBN1 = "SELECT idkhambenhcanlamsan FROM dieutricanlamsan   WHERE idkhambenhcanlamsan =" + StaticData.ParseInt(dtsrc.Rows[0]["idkhambenh"]) + "";
                dtCheck1 = DataAcess.Connect.GetTable(sqlCheckIDBN1);
                if (dtCheck1 == null || dtCheck1.Rows.Count == 0)
                {
                    html += "   <tr style=\"padding-top:7px\">";
                    html += "		<td colspan=\"2\" width=\"20%\" valign = \"top\">Chỉ định CLS: </td>";

                    html += "	</tr>";
                    html += "   <tr colspan=\"2\" style=\"padding-top:7px;padding-left:20px\">";
                    //html += "	<td colspan=\"2\" align = \"left\" width=\"80%\">";
                    //html += " <table width=\"100%\">";
                    //html += " <tr >";
                    html += " <td  width=\"100%\">" + LoadChiDinhCanLamSang(StaticData.ParseInt(dtsrc.Rows[0]["idkhambenh"])) + "";
                    html += " </td >";
                    //html += " </tr >";
                    //html += " </table>";
                    //html += "</td>";
                    html += "	</tr>";
                }
                else
                {
                    //html += "   <tr style=\"padding-top:7px\">";
                    //html += "		<td width=\"20%\" valign = \"top\">Kết quả CLS: </td>";
                    //html += "		<td  colspan=\"1\" width = \"100%\" class=\"ptext\" style=\"padding-bottom:10px; padding-top:7px\">" + LoadKetQuaKhamCanLamSang(StaticData.ParseInt(dtsrc.Rows[0]["idkhambenh"])) + "</td>";
                    //html += "	</tr>";
                    html += "  	<tr style=\"padding-top:7px\">";
                    html += "		<td colspan=\"2\"  width=\"1000%\" valign = \"top\">Kết quả CLS: </td>";
                    html += "  	</tr>";
                    html += "  	<tr style=\"padding-top:7px;padding-left:0px\">";
                    html += "		<td colspan=\"2\" width = \"100%\" class=\"ptext\" style=\"padding-bottom:10px; padding-top:7px\">" + LoadKetQuaKhamCanLamSang(StaticData.ParseInt(dtsrc.Rows[0]["idkhambenh"])) + "</td>";
                    html += "  	</tr>";
                }
            }
            else
            {
                sqlCheckIDBN1 = "SELECT idkhambenhcanlamsan FROM dieutricanlamsan  WHERE idbenhnhan = " + idbn + "";
                dtCheck1 = DataAcess.Connect.GetTable(sqlCheckIDBN1);
                if (dtCheck1 != null && dtCheck1.Rows.Count == 0)
                {

                    html += "   <tr style=\"padding-top:7px\">";
                    html += "		<td colspan=\"2\" width=\"20%\" valign = \"top\">Chỉ định CLS: </td>";

                    html += "	</tr>";
                    html += "   <tr style=\"padding-top:7px;padding-left:20px\">";
                    html += " <td colspan=\"2\" width=\"100%\">" + LoadChiDinhCanLamSang(StaticData.ParseInt(dtsrc.Rows[0]["idkhambenh"])) + "";
                    html += " </td >";
                    html += "	</tr>";
                }
                else
                {
                    html += "   <tr style=\"padding-top:7px\">";
                    html += "		<td colspan=\"2\" width=\"20%\" valign = \"top\">Kết quả CLS: </td>";
                    html += "	</tr>";
                    html += "	<tr style=\"padding-top:7px;padding-left:0px\">";
                    html += "		<td colspan=\"2\" width = \"100%\" class=\"ptext\" style=\"padding-bottom:10px; padding-top:7px\">" + LoadKetQuaKhamCanLamSang(StaticData.ParseInt(dtsrc.Rows[0]["idkhambenh"])) + "</td>";
                    html += "	</tr>";
                }

            }

            ///////End Van Khoe 0606

            html += "  	<tr>";


            html += "		<td colspan=\"2\" class=\"tieude\" style=\"padding-bottom:10px; padding-top:10px;font-size:10pt\" bgcolor=\"#B5CFF8\">TOA THUỐC</td>";


            html += "  	</tr>";
            html += "   <tr style=\"padding-top:7px\">";

            html += "		<td width=\"80%\" align = \"left\">" + loadChiTietQuaTrinhDieuTri(StaticData.ParseInt(dtsrc.Rows[0]["idkhambenh"])) + "</td>";
            html += "	</tr>";


            //ThuanNH tam rem 27/04/2010
            //html += "  	<tr>";
            //html += "		<td colspan=\"2\" width = \"100%\" class=\"tieude\" style=\"padding-bottom:10px; padding-top:10px\" bgcolor=\"#B5CFF8\">IV. THÔNG TIN TOA THUỐC</td>";
            //html += "  	</tr>";

            //html += "  	<tr>";
            //html += "		<td colspan=\"2\" class=\"phpmaker\" style=\"padding-bottom:0px; padding-top:0px\">" + LoadChiTietThongTinToaThuocBenhNhan(dtsrc.Rows[i]["idkhambenh"].ToString()) + "<br></td>";
            //html += "  	</tr>";

            html += "</table>";

            divnoidung.InnerHtml = html;
        }
    }
    #endregion

    #region Load thong tin huong dieu tri
    private string GetHuongDieuTri(int ihuongdt)
    {
        string skq = "";
        switch (ihuongdt)
        {
            case 0: skq = ""; break;
            case 1: skq = "Chuyển phòng KTP"; break;
            case 2: skq = "Ra toa thuốc"; break;
            case 3: skq = "Cho về-Không thuốc"; break;
            case 4: skq = "Chuyển viện"; break;
            case 5: skq = "" + StaticData.GetParameter("TenHuongDieuTri") + " khác"; break;
            case 6: skq = "Chờ kết quả chỉ định cận lâm sàn"; break;
            case 7: skq = "Chuyển phòng thu phí"; break;
            case 8: skq = "Nhập viện"; break;
            case 9: skq = "Toa về - đề nghị khám thêm chuyên khoa khác"; break;
            case 10: skq = "Cho toa thuốc và chỉ định cận lâm sàng"; break;
        }
        return skq;
    }

    private string GetChiTietHuongDT(int huongdieutri, int khoachuyenden, string phongchuyenden, string dichvuDK, string ghichuhuongdieutri)
    {
        if (huongdieutri == 1 || huongdieutri == 7)//chuyển phòng
        {
            string chuyenden = "";//chi lay thông tin khoa,phòng chuyển đến


            DataTable dtPhong = DataAcess.Connect.GetTable("select * from kb_phong where id=" + phongchuyenden);
            if (dtPhong.Rows.Count > 0)
                chuyenden = ":                     đến Phòng \"" + dtPhong.Rows[0]["tenphong"].ToString() + "\"";
            chuyenden += ",Khoa: \"" + StaticData.GetValue("phongkhambenh", "idphongkhambenh", khoachuyenden, "tenphongkhambenh") + "\"";
            return chuyenden;
        }
        else if (huongdieutri == 4)//Chuyển viện
        {
            string BenhVien = "";
            DataTable BV = DataAcess.Connect.GetTable("select * from benhvien where idbenhvien='" + ghichuhuongdieutri +"'");
            if (BV.Rows.Count > 0)
                BenhVien = "  đến: " + BV.Rows[0]["tenbenhvien"].ToString() + ",   Mã Số Bệnh Viện:" + BV.Rows[0]["mabenhvien"].ToString();
            return BenhVien;
        }
        else if (huongdieutri == 8)//Nhập viện
        {
            return " :    nhập vào khoa \"" + StaticData.GetValue("phongkhambenh", "idphongkhambenh", khoachuyenden, "tenphongkhambenh") + "\"";
        }
        else return ghichuhuongdieutri;

    }
    #endregion
    #region Load thong tin chi tiet toa thuoc de show trong ho so benh an
    private string LoadChiTietThongTinToaThuocBenhNhan(string sIdBenhNhanPhongKhamBenh)
    {
        if (StaticData.ParseInt(sIdBenhNhanPhongKhamBenh) == 0)
        {
            return "";
        }
        string strSQL = "SELECT ct.soluongke, ct.ngayuong, ct.moilanuong, vt.tenthuoc, vt.donvitinh as tendvt, vt.congthuc as mathuoc, duongdung ";
        strSQL += "FROM benhnhantoathuoc tt INNER JOIN chitietbenhnhantoathuoc ct ON tt.idbenhnhantoathuoc = ct.idbenhnhantoathuoc ";
        strSQL += "INNER JOIN thuoc vt ON ct.idthuoc = vt.idthuoc ";
        strSQL += "WHERE idkhambenh = " + sIdBenhNhanPhongKhamBenh + " AND ct.bacsixoa = 0";
        strSQL += " ORDER BY tt.idbenhnhantoathuoc DESC";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        string shtml = "";
        if (dtCTPhieu != null && dtCTPhieu.Rows.Count > 0)
        {
            shtml += "<table cellPadding=\"0\" width=\"100%\" border=\"0\" id = \"user\" >";

            for (int i = 0; i < dtCTPhieu.Rows.Count; i++)
            {
                shtml += "<tr style =\"padding-top:10px;padding-bottom:4px;padding-left:15px\">";
                shtml += "<td width=\"100%\" align=\"left\" valign = \"top\" colspan = \"4\" nowrap = \"nowrap\"><span class = \"ptext\">" + (i + 1).ToString() + "   <b>" + dtCTPhieu.Rows[i]["tenthuoc"].ToString() + "</b><br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dtCTPhieu.Rows[i]["duongdung"] + ",&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ngày dùng " + dtCTPhieu.Rows[i]["ngayuong"].ToString() + " lần &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mỗi lần: " + dtCTPhieu.Rows[i]["moilanuong"].ToString() + " " + dtCTPhieu.Rows[0]["tendvt"] + "</span></td>";
                shtml += "<td width=\"100%\" align=\"right\" valign = \"top\" colspan = \"2\" nowrap = \"nowrap\"><span class = \"ptext\"><b>" + StaticData.ParseInt(dtCTPhieu.Rows[i]["soluongke"]) + " " + dtCTPhieu.Rows[0]["tendvt"] + "<br></span></td>";
                shtml += "<td width=\"100%\" align=\"right\" valign = \"top\" colspan = \"1\"><span class = \"ptext\"></span></td>";
                shtml += "</tr>";
            }

            shtml += "</table>";
            return shtml;
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region Load thong tin xet nghiem can lam sang neu co
    public string LoadCanLamSan(string iIdKhamBenh)
    {
        string strSQL = "SELECT pk.*, kbcls.chidinh, isnull(dtcls.Video, '') as Video, isnull(dtcls.ketqua, '') as ketqua, isnull(dtcls.ketluan, '') as ketluan, isnull(tenbacsi, '') as tenbacsi ";
        strSQL += "FROM khambenhcanlamsan kbcls INNER JOIN phongkhambenh pk ";
        strSQL += "ON kbcls.idcanlamsan = pk.idphongkhambenh ";
        strSQL += "LEFT JOIN dieutricanlamsan dtcls ON kbcls.idkhambenhcanlamsan = dtcls.idkhambenhcanlamsan ";
        strSQL += "LEFT JOIN bacsi bs ON dtcls.idbacsi = bs.idbacsi ";
        strSQL += "WHERE idkhambenh = " + iIdKhamBenh + " ORDER BY kbcls.idkhambenhcanlamsan";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        if (dt != null && dt.Rows.Count > 0)
        {
            string html = "";
            html = "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "    <tr>";
                html += "        <td width=\"20%\" valign=\"top\"></td>";
                html += "        <td width=\"80%\" valign=\"top\" align = \"left\"><p class=\"ptext\"><b>" + dt.Rows[i]["tenphongkhambenh"] + "</b></p></td>";
                html += "    </tr>";
                html += "    <tr style = \"padding-bottom:5px\">";
                html += "        <td width=\"20%\" valign=\"top\"><p class=\"ptext\">Vùng chỉ định:&nbsp;</p></td>";
                html += "        <td width=\"80%\" valign=\"top\" align = \"left\"><p class=\"ptext\">" + LoadVungChiDinh(dt.Rows[i]["chidinh"].ToString()) + "</p></td>";
                html += "    </tr>";
                html += "    <tr style = \"padding-bottom:5px\">";
                html += "        <td width=\"20%\" valign=\"top\"><p class=\"ptext\">Kết quả:&nbsp;</p></td>";
                html += "        <td width=\"80%\" valign=\"top\" align = \"left\"><p class=\"ptext\">" + dt.Rows[i]["ketqua"] + "</p></td>";
                html += "    </tr>";
                //if (dt.Rows[i]["Video"].ToString() != "")
                //{
                //    html += "    <tr style = \"padding-bottom:5px\">";
                //    html += "        <td width=\"16%\" valign=\"top\"><p class = \"ptext\"></p></td>";
                //    html += "        <td width=\"84%\" valign=\"top\" align = \"left\"><a target = \"_blank\" href = \"ShowVideo.aspx?file=" + dt.Rows[i]["Video"] + "\">Xem video kết quả: &nbsp;" + dt.Rows[i]["Video"] + "</a></td>";
                //    html += "    </tr>";
                //}
                html += "    <tr style = \"padding-bottom:5px\">";
                html += "        <td width=\"20%\" valign=\"top\"><p class=\"ptext\">Kết luận CLS:&nbsp;</p></td>";
                html += "        <td width=\"80%\" valign=\"top\" align = \"left\"><p class=\"ptext\">" + dt.Rows[i]["ketluan"] + "</p></td>";
                html += "    </tr>";
                html += "    <tr style = \"padding-bottom:10px\">";
                html += "        <td width=\"20%\" valign=\"top\"><p class=\"ptext\">Bác sĩ CLS:&nbsp;</p></td>";
                html += "        <td width=\"80%\" valign=\"top\" align = \"left\"><p class=\"ptext\">" + dt.Rows[i]["tenbacsi"] + "</p></td>";
                html += "    </tr>";
            }
            html += "<table>";
            return html;
        }
        else
        {
            return "";
        }
    }
    //Load danh sach chi dinh can lam san
    private string LoadChiDinhCanLamSang(int idkhambenh)
    {
        DataTable dt = new DataTable();
        string idb = idbn;
        string strkq = "";
        string sql = "";
        string sqlCheckIDBN, strlistid = "";
        sqlCheckIDBN = "select * from khambenhcanlamsan where idbenhnhan =" + idb + "";
        DataTable dtCheck = DataAcess.Connect.GetTable(sqlCheckIDBN);
        if (dtCheck == null || dtCheck.Rows.Count == 0)
        {

            sql = "SELECT kbcls.idkhambenhcanlamsan, tendichvu FROM khambenhcanlamsan kbcls INNER JOIN banggiadichvu bg ON kbcls.idcanlamsan = bg.idbanggiadichvu";
            sql += " WHERE kbcls.idkhambenh = " + idkhambenh;

        }
        else
        {

            sql += "SELECT kbcls.idkhambenhcanlamsan, tendichvu FROM khambenhcanlamsan kbcls INNER JOIN banggiadichvu bg ON kbcls.idcanlamsan = bg.idbanggiadichvu";
            sql += " WHERE kbcls.idbenhnhan = " + idbn;

        }
        dt = DataAcess.Connect.GetTable(sql);

        if (dt != null && dt.Rows.Count > 0)
        {
            strkq = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strlistid += dt.Rows[i]["idkhambenhcanlamsan"].ToString() + ",";
                strkq += "- " + dt.Rows[i]["tendichvu"].ToString() + "<br>";
            }
            if (strlistid != "" && strlistid != null) strlistid = strlistid.TrimEnd(',');
        }

        Session["listidchidinhcls"] = strlistid;
        return strkq;
    }
    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }
    // Load chi tiết tt quá trình điều trị
    private string loadChiTietQuaTrinhDieuTri(int idkhambenh)
    {
        if (idkhambenh == 0)
            return "";
        string html = "<table border=\"1\" cellspacing=\"1\" cellpadding=\"1\" width=\"900px\" bgcolor=\"#CCCCCC\">";
        html += "   <tr bgcolor=\"#B5CFF8\">";
        //html += "   <td width=\"3%\" valign=\"top\"><span class=\"phpmaker\" style=\"color: #000000;font-size:14pt\"> Stt </span></td>";
        //html += "   <td width=\"15%\" valign=\"top\"><span class=\"phpmaker\" style=\"color: #000000;font-size:14pt\"> Ngày điều trị </span></td>";
        //html += "   <td width=\"10%\" valign=\"top\"><span class=\"phpmaker\" style=\"color: #000000;font-size:14pt\"> Triệu chứng </span></td>";
        //html += "   <td width=\"100%\" style=\"text-align:center\"><span class=\"phpmaker\" style=\"color: #000000;font-size:14pt\">Toa thuốc</span></td>";
        ////html += "   <td width=\"12%\"><span class=\"phpmaker\" style=\"color: #000000;font-size:14pt\">Kết quả</span></td>";
        //html += "   <td width=\"14%\" valign=\"top\"><span class=\"phpmaker\" style=\"color: #000000;font-size:14pt\"> Hướng giải quyết </span></td>";

        //html += "   <td width=\"7%\" valign=\"top\"><span class=\"phpmaker\" style=\"color: #000000;font-size:14pt\"> Bác sĩ khám</span></td>";
        html += "    </tr>";
        string sql = "select kb.idkhambenh,kb.ngaykham,kb.trieuchung,cd.mota as ketluan,ghichuhuongdieutri=ISNULL(KB.IdBenhVienChuyen, kb.ghichuhuongdieutri)  ,bs.tenbacsi from khambenh kb inner join bacsi bs on bs.idbacsi = kb.idbacsi left join chandoanicd cd on cd.idicd = kb.ketluan  where kb.idkhambenh = " + idkhambenh + "";

        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sql1 = @"select t.tenthuoc,t.duongdung 
                                ,t.donvitinh,ct.soluongke
                                ,cachdung=dbo.HS_TENCACHDUNG (ct.idchitietbenhnhantoathuoc)
                                from chitietbenhnhantoathuoc ct  
                                LEFT join benhnhantoathuoc bnth on bnth.idbenhnhantoathuoc = ct.idbenhnhantoathuoc
                                LEFT join thuoc t on t.idthuoc=ct.idthuoc
                            where ct.idkhambenh = " + StaticData.ParseInt(dt.Rows[i]["idkhambenh"]) + "";
                DataTable dt1 = DataAcess.Connect.GetTable(sql1);
                html += "    <tr bgcolor=\"#F5F5F5\" style = \"padding-bottom:5px\">";
                //html += "        <td ><span class=\"phpmaker\">" + STT() + "</span></td>";
                //html += "        <td  ><span class=\"phpmaker\">" + DateTime.Parse(dt.Rows[i]["ngaykham"].ToString()).ToString("dd/MM/yyyy") + "</span></td>";
                //html += "        <td ><span class=\"phpmaker\">" + dt.Rows[i]["trieuchung"].ToString() + "</span></td>";
                html += " <td ><span class=\"phpmaker\">"
                    + "<table border=\"1\" width=\"900px\">"
                    + "<tr bgcolor=\"#B5CFF8\">"
                    + "<td>Tên thuốc</td>"
                    + "<td>Đơn vị</td>"
                    + "<td>Số lượng kê</td>"
                    + "<td>Cách Dùng</td>"
                    + "</tr>";
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        html += "<tr><td>" + dt1.Rows[j]["tenthuoc"].ToString() + "</td>"
                            + "<td>" + dt1.Rows[j]["donvitinh"].ToString() + "</td>"
                            + "<td>" + dt1.Rows[j]["soluongke"].ToString() + "</td>"
                            + "<td>" + dt1.Rows[j]["cachdung"].ToString() + "" + "</td>"
                           + "</tr>";

                    }
                }
                html += "</table></span></td>";
                //html += "        <td ><span class=\"phpmaker\">" + dt.Rows[i]["ketluan"].ToString() + "</span></td>";
                // html += "        <td ><span class=\"phpmaker\">" + dt.Rows[i]["ghichuhuongdieutri"].ToString() + "</span></td>";

                // html += "        <td ><span class=\"phpmaker\">" + dt.Rows[i]["tenbacsi"].ToString() + "</span></td>";
                html += "    </tr>";

            }
        }
        html += "<table>";
        return html;
    }
    //Load ket qua kham can lam san
    private string LoadKetQuaKhamCanLamSang(int idkhambenh)
    {
        string idb = idbn;
        string sql = "";
        string sqlCheckIDBN = "select * from khambenhcanlamsan where idbenhnhan =" + idb + "";
        DataTable dtCheck = DataAcess.Connect.GetTable(sqlCheckIDBN);
        if (dtCheck == null || dtCheck.Rows.Count == 0)
        {
            sql = "SELECT * FROM dieutricanlamsan dtcls INNER JOIN bacsi bs ON dtcls.idbacsi = bs.idbacsi ";
            sql += "WHERE dtcls.idkhambenhcanlamsan  = " + idkhambenh + " ";
        }
        else
        {
            sql = "SELECT * FROM dieutricanlamsan dtcls left JOIN bacsi bs ON dtcls.idbacsi = bs.idbacsi ";
            sql += "WHERE dtcls.idbenhnhan = " + idb + "";
        }

        string html = "<table style = \"padding-left:20px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class = \"khung\">";

        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "    <tr style = \"padding-bottom:5px\">";
                html += "        <td width=\"100%\" valign=\"top\"><span class=\"ptext\">" + dt.Rows[i]["ketqua"].ToString() + "</span></td>";
                //html += "<td>" + dt.Rows[i]["ketqua"].ToString()+ "</td>";
                html += "    </tr>";
                html += "    <tr style = \"padding-bottom:5px\">";
                html += "        <td width=\"100%\" valign=\"top\"><span class=\"ptext\">Kết luận CLS:&nbsp;" + dt.Rows[i]["ketluan"].ToString() + "</span></td>";
                html += "    </tr>";
                html += "    <tr style = \"padding-bottom:10px\">";
                html += "        <td width=\"100%\" valign=\"top\"><p class=\"ptext\">Bác sĩ CLS:&nbsp;" + dt.Rows[i]["tenbacsi"] + "</p></td>";
                html += "    </tr>";
            }
        }
        html += "<table>";
        return html;
    }
    private string LoadVungChiDinh(string sListidchidinh)
    {
        string ssql = "SELECT * FROM banggiadichvu WHERE idbanggiadichvu IN (" + sListidchidinh + ")";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt == null || dt.Rows.Count == 0)
            return "";
        string skq = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            skq += "- " + dt.Rows[i]["tendichvu"].ToString() + "<br>";
        }
        return skq;
    }
    #endregion

    #region "Load thong tin benh nhan va thong tin cac khoa can lam san"

    //Load cac khoa can lam san
    public void LoadCanLamSan()
    {
        int iIdbenhnhanphongkhambenh = StaticData.ParseInt(Session["idbenhnhanphongkham"]);
        string iIdKhamBenh = StaticData.GetValue("khambenh", "idbenhnhanphongkhambenh", iIdbenhnhanphongkhambenh, "idkhambenh");
        string strSQL = "SELECT pk.*, kbcls.chidinh, isnull(dtcls.ketqua, '') as ketqua, isnull(dtcls.ketluan, '') as ketluan, isnull(tenbacsi, '') as tenbacsi ";
        strSQL += "FROM khambenhcanlamsan kbcls INNER JOIN phongkhambenh pk ";
        strSQL += "ON kbcls.idcanlamsan = pk.idphongkhambenh ";
        strSQL += "LEFT JOIN dieutricanlamsan dtcls ON kbcls.idkhambenhcanlamsan = dtcls.idkhambenhcanlamsan ";
        strSQL += "LEFT JOIN bacsi bs ON dtcls.idbacsi = bs.idbacsi ";
        strSQL += "WHERE idkhambenh = " + iIdKhamBenh + " ORDER BY kbcls.idkhambenhcanlamsan";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        if (dt != null)
        {
            string html = "";
            html = "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "    <tr>";
                html += "        <td width=\"16%\" valign=\"top\"></td>";
                html += "        <td width=\"84%\" valign=\"top\" align = \"left\"><p class=\"ptext\"><b>" + dt.Rows[i]["tenphongkhambenh"] + "</b></p></td>";
                html += "    </tr>";
                html += "    <tr style = \"padding-bottom:5px\">";
                html += "        <td width=\"16%\" valign=\"top\"><p class=\"ptext\">Vùng chỉ định:&nbsp;</p></td>";
                html += "        <td width=\"84%\" valign=\"top\" align = \"left\"><p class=\"ptext\">" + dt.Rows[i]["chidinh"] + "</p></td>";
                html += "    </tr>";
                html += "    <tr style = \"padding-bottom:5px\">";
                html += "        <td width=\"16%\" valign=\"top\"><p class=\"ptext\">Kết quả:&nbsp;</p></td>";
                html += "        <td width=\"84%\" valign=\"top\" align = \"left\"><p class=\"ptext\">" + dt.Rows[i]["ketqua"] + "</p></td>";
                html += "    </tr>";
                html += "    <tr style = \"padding-bottom:5px\">";
                html += "        <td width=\"16%\" valign=\"top\"><p class=\"ptext\">Kết luận CLS:&nbsp;</p></td>";
                html += "        <td width=\"84%\" valign=\"top\" align = \"left\"><p class=\"ptext\">" + dt.Rows[i]["ketluan"] + "</p></td>";
                html += "    </tr>";
                html += "    <tr style = \"padding-bottom:10px\">";
                html += "        <td width=\"16%\" valign=\"top\"><p class=\"ptext\">Bác sĩ CLS:&nbsp;</p></td>";
                html += "        <td width=\"84%\" valign=\"top\" align = \"left\"><p class=\"ptext\">" + dt.Rows[i]["tenbacsi"] + "</p></td>";
                html += "    </tr>";
            }
            html += "<table>";
            Response.Write(html);
        }
    }
    //Load thog tin dang ky cua benh nhan
    public void LoadThongTinBenhNhan()
    {
        int iIdbenhnhanphongkhambenh = StaticData.ParseInt(Session["idbenhnhanphongkham"]);
        string iIdbenhnhan = StaticData.GetValue("benhnhan_phongkhambenh", "idbenhnhanphongkhambenh", iIdbenhnhanphongkhambenh.ToString(), "idbenhnhan");
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
            html += "                            <td width=\"18%\" nowrap = \"nowrap\"><p class=\"ptext\"><b>Tiền sử bệnh&nbsp;:&nbsp;</b></p></td>";
            html += "                            <td width=\"82%\"><p class=\"ptext\">" + dt.Rows[0]["tiensubenhnhan"].ToString() + "</p></td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            html += "             <tr bgcolor=\"#F5F5F5\">";
            html += "                 <td colspan=\"5\" style = \"padding-bottom:10px; padding-top:10px\">";
            html += "                     <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";
            html += "                         <tr>";
            html += "                            <td width=\"18%\"  nowrap = \"nowrap\"><p class=\"ptext\"><b>Tình trạng ban đầu&nbsp;:&nbsp;</b></p></td>";
            html += "                            <td width=\"82%\"><p class=\"ptext\">" + dt.Rows[0]["tinhtrangbandau"].ToString() + "</p></td>";
            html += "                         </tr>";
            html += "                     </table>";
            html += "               </td>";
            html += "             </tr>";
            html += "         </table>";
            Response.Write(html);
        }
    }
    #endregion
}

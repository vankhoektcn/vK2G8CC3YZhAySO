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

public partial class CapCuu_khambenh_ajax : Genaratepage
{
    
  
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string action = StaticData.escape(Request.QueryString["do"]);
        switch (action)
        {
            
            #region Khoe
            case "tamUng": tamUng(); break;
            case "luuTU": luuTU(); break;
            case "SuaTamUng": SuaTamUng(); break;
            case "ThuPhiTamUng": ThuPhiTamUng(); break;
            case "luuThuPhiTU": luuThuPhiTU(); break;
            #endregion
            case "LoadDanhSachBacSiChuyenKhoa": LoadDanhSachBacSiChuyenKhoa(); break;
        }
    }
	#region --- Nội dung tạm ứng
    private void luuTU()
    {
        try
        {
            string IdKhoaTU ="0";
            if (Request.QueryString["idkhoa"] != null)
                IdKhoaTU = Request.QueryString["idkhoa"];
            string iddangkykham = Request.QueryString["iddangkykham"];
            double sotien = double.Parse(Request.QueryString["sotien"]);
            string SoDangKy = Request.QueryString["SoDangKy"].ToString();
            string quyenso = Request.QueryString["quyenso"].ToString();
            string lydoTU = Request.QueryString["lydoTU"].ToString();
            string ngayUT = DataAcess.Connect.s_SystemDate();
            string sqlCheck = "select * from tamUng where iddangkykham=" + iddangkykham + "";
            DataTable dtCheck = DataAcess.Connect.GetTable(sqlCheck);
            ////////////
            string sqlbn = ""
                               + "  select c.tenbenhnhan,c.idbenhnhan from chitietdangkykham a" + "\r\n"
                               + "  left join dangkykham b on a.iddangkykham=b.iddangkykham" + "\r\n"
                               + " left join benhnhan c on c.idbenhnhan=b.idbenhnhan " + "\r\n"
                               + " where a.idchitietdangkykham=" + iddangkykham + "\r\n";
            DataTable dtht = DataAcess.Connect.GetTable(sqlbn);
            string HoTen = "";
            string idbenhnhan = "0";
            if (dtht != null && dtht.Rows.Count > 0)
            {
                HoTen = dtht.Rows[0]["tenbenhnhan"].ToString();
                idbenhnhan = dtht.Rows[0]["idbenhnhan"].ToString();
            }
            ///////////
            if (false)//dtCheck != null && dtCheck.Rows.Count != 0)
            {
                string NewSTT = "";
                if (Request.QueryString["SoCT"] != null)
                {
                    ////NewSTT = dtCheck.Rows[0]["SoCTTU"].ToString();
                    ////string UpdateSCT = " update sochungtu set SophieuCT='" + Request.QueryString["SoCT"].ToString() + "' ,QuyenSo='" + Request.QueryString["quyenso"] + "' where STT=" + NewSTT + "";
                    ////bool resSCT = DataAcess.Connect.ExecSQL(UpdateSCT);
                }

                string sqlInsert = "update tamUng set isdathu=1,LyDoTU=N'" + lydoTU + "',sotien=" + sotien + ",SoCTTU='" + NewSTT + "',QuyenSo='" + quyenso + "'  where IDTamUng=" + dtCheck.Rows[0]["IDTamUng"].ToString() + "";
                bool result = DataAcess.Connect.ExecSQL(sqlInsert);

                if (result == false)
                {
                    Response.Write("");
                }
                else
                {
                    Response.Write("1");
                }
            }
            else
            {
                string NewSTT = "";
                string idsct = "";
                NewSTT = Request.QueryString["SoCT"].ToString();
                string sctu = "select * from sochungtu where SophieuCT='" + NewSTT + "' and QuyenSo='" + quyenso + "'";
                DataTable dtSoCT = DataAcess.Connect.GetTable(sctu);
                if (dtSoCT != null && dtSoCT.Rows.Count > 0 && Request.QueryString["SoCT"].ToString() !="0")
                {
                    Response.Write("Số chứng từ này đã tồn tại");
                    return;
                }
                #region thêm số chứng từ vào bảng sochungtu
                //Tên Bệnh nhân 
                string TenBenhNhan = "";

                //End Tên BN
                string NgaySCT = (DateTime.Parse(DataAcess.Connect.s_SystemDate())).ToString("MM/dd/yyyy hh:ss");
                //NewSTT = StaticData.NewSoChungTuTamUng(NgaySCT, TenBenhNhan, "Tạm ứng khám bệnh", sotien.ToString(), Request.QueryString["SoCT"].ToString(), Request.QueryString["quyenso"].ToString());
                NewSTT = StaticData.NewSoChungTuGetID(NgaySCT, TenBenhNhan, "Tạm ứng khám bệnh", sotien.ToString());
                #endregion
                string NgayHoanU = null;
                string sqlInsert = @"insert into tamUng (iddangkykham,
                        sotien,
                        ngayTamung,
                        NgayHoanUng,
                        SoCTHU,
                        SoTienHU,
                        GhiChu,
                        SoCTTU,
                        dahoanung,
                        QuyenSo,
                        IsDaThu,
                        LyDoTU,
                        IsDaHuy,
                        idkhoaTU)
            values(" + iddangkykham + "," + sotien + ",'" + ngayUT + "','" + NgayHoanU + "',null,'',N'" + lydoTU + "','" + NewSTT + "',0,'" + quyenso + "',0,N'" + lydoTU + "',0,'"+IdKhoaTU+"')";
                bool result = DataAcess.Connect.ExecSQL(sqlInsert);
                if (result == false)
                {
                    Response.Write("");
                }
                else
                {
                    string sqlIdTamung = "select isnull(max(idtamung),0) from tamung";
                    DataTable dtIdTU = DataAcess.Connect.GetTable(sqlIdTamung);
                    if(dtIdTU.Rows.Count>0)
                        Response.Write(dtIdTU.Rows[0][0].ToString());
                    else
                    Response.Write("1");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("");
        }
    }

    private void SuaTamUng()
    {
        string idtamung = Request.QueryString["IdTamUng"].ToString();
        string SoTien = Request.QueryString["SoTien"].ToString();
        string lydoTU = Request.QueryString["lydoTU"].ToString();
        string sqlUDTU = "update tamung set sotien='" + SoTien + "',lydoTU=N'" + lydoTU+ "' where idtamung="+idtamung+"";
        bool kt = DataAcess.Connect.ExecSQL(sqlUDTU);
        if(!kt)
            Response.Write("0"); //Lỗi
        else
            Response.Write("1");
    }
    private void tamUng()
    {
        try
        {
            string IdKhoa = "0";
            if (Request.QueryString["idkhoa"] != null)
                IdKhoa=Request.QueryString["idkhoa"];
            string idbn = Request.QueryString["idbn"];
            string IsSua = "";
            string html = "";
            string SoDangKy = StaticData.SoDangKyMoiNhat();
            string QuyenSo = StaticData.QuyenSoMoiNhat();
            string sqlSoLan = @"select COUNT(distinct IDTamUng)+1
                from tamUng tu
                left join chitietdangkykham ct on ct.idchitietdangkykham =tu.iddangkykham
                left join dangkykham dk on dk.iddangkykham=ct.iddangkykham
                where dk.idbenhnhan=(select top 1 dk1.idbenhnhan
	                from chitietdangkykham ct1
	                left join dangkykham dk1 on dk1.iddangkykham=ct1.iddangkykham
	                where ct1.idchitietdangkykham='" + idbn + "')";
            DataTable SoLan = DataAcess.Connect.GetTable(sqlSoLan);
            string strSoLan = "1";
            if (SoLan.Rows.Count > 0)
                strSoLan = SoLan.Rows[0][0].ToString();
            else
                strSoLan = "1";
            if (Request.QueryString["IsSua"] != null)
            {
                IsSua = Request.QueryString["IsSua"].ToString();
                if (IsSua == "1")
                {
                    string idTamung = Request.QueryString["idtamung"].ToString();
                    string sqlTamUng = "select *,solan=isnull( (select count(*) from tamung where idtamung<=tu.idtamung and iddangkykham= tu.iddangkykham),0) from tamung tu where idtamung=" + idTamung;
                    DataTable dtTU = DataAcess.Connect.GetTable(sqlTamUng);
                    if (dtTU != null && dtTU.Rows.Count > 0)
                    {
                        html = "<div style=\"850px;overflow:auto;height:100px\">";
                        html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" >";
                        html += "<tr >";
                        html += "<td colspan=\"5\" class=\"ptext\" >Lần thứ: " + dtTU.Rows[0]["solan"] + "</td>";
                        html += "</tr>";
                        html += "<tr >";
                        //html += "<td class=\"ptext\" >Quyển Số: </td>";
                        //html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtQuyenSo\" value=\"" + QuyenSo + "\" />&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                        //html += "<td class=\"ptext\" >Số CT:</td>";
                        //html += "<td  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoCT\" value=\"\"/> &nbsp;&nbsp;&nbsp;&nbsp;</td>";
                        html += "<td class=\"ptext\" >Số tiền</td>";
                        html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoTien\" value=\"" + dtTU.Rows[0]["sotien"] + "\" /></td>";
                        html += "<td class=\"ptext\" >Lý do</td>";
                        html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 350px\" value=\"" + dtTU.Rows[0]["LydoTU"] + "\" id=\"txtLyDo\"/></td>";
                        html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Sửa TU\" onclick=\"luuTU(" + idbn + ","+idTamung+");\"/></td>";
                        html += "</tr>";
                        html += "</table>";
                        html += "</div>";
                    }
                }
                else
                {
                    html = "<div style=\"850px;overflow:auto;height:100px\">";
                    html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" >";

                    html += "<tr >";
                    html += "<td colspan=\"5\" class=\"ptext\" >Lần thứ: " + strSoLan + "</td>";
                    html += "</tr>";
                    html += "<tr >";
                    html += "<tr >";
                    //html += "<td class=\"ptext\" >Quyển Số: </td>";
                    //html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtQuyenSo\" value=\"" + QuyenSo + "\" />&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                    //html += "<td class=\"ptext\" >Số CT:</td>";
                    //html += "<td  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoCT\" value=\"\"/> &nbsp;&nbsp;&nbsp;&nbsp;</td>";
                    //Số tiền=
                    html += "<td class=\"ptext\" >Số tiền</td>";
                    if (IdKhoa == "15")
                        html += "<td  class=\"ptext\"  > <select id=\"txtSoTien\" style=\"width: 100px\">"
                              +"<option value=\"500000\">500,000</option>"
                              +"<option value=\"1000000\">1,000,000</option>"
                              +"<option value=\"2000000\">2,000,000</option>"
                              +"<option value=\"3000000\">3,000,000</option>"
                              + "<option value=\"4000000\">4,000,000</option>"
                            + "</select> </td>";
                        //html += "<td  class=\"ptext\"  ><input type=\"text\" value=\"500,000\" style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                    else
                        html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                    html += "<td class=\"ptext\" >Lý do</td>";
                    html += "<td  class=\"ptext\"  ><input type=\"text\" value=\"Chỉ định tạm ứng\" style=\"width: 350px\" id=\"txtLyDo\"/></td>";
                    html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Lưu TU\" onclick=\"luuTU(" + idbn + ");\"/></td>";
                    html += "</tr>";

                    html += "</table>";
                    html += "</div>";
                }
            }
            else
            {
                html = "<div style=\"850px;overflow:auto;height:100px\">";
                html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" >";

                html += "<tr >";
                html += "<td colspan=\"5\" class=\"ptext\" >Lần thứ: " + strSoLan + "</td>";
                html += "</tr>";
                html += "<tr >";
                //html += "<td class=\"ptext\" >Quyển Số: </td>";
                //html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtQuyenSo\" value=\"" + QuyenSo + "\" />&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                //html += "<td class=\"ptext\" >Số CT:</td>";
                //html += "<td  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoCT\" value=\"\"/> &nbsp;&nbsp;&nbsp;&nbsp;</td>";
                //Số tiền=
                html += "<td class=\"ptext\" >Số tiền</td>";
                if(IdKhoa=="15")
                    html += "<td  class=\"ptext\"  > <select id=\"txtSoTien\" style=\"width: 100px\">"
                              + "<option value=\"500000\">500,000</option>"
                              + "<option value=\"1000000\">1,000,000</option>"
                              + "<option value=\"2000000\">2,000,000</option>"
                              + "<option value=\"3000000\">3,000,000</option>"
                              + "<option value=\"4000000\">4,000,000</option>"
                            + "</select> </td>";
                //html += "<td  class=\"ptext\"  ><input type=\"text\" value=\"500,000\" style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                else
                    html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                html += "<td class=\"ptext\" >Lý do</td>";
                html += "<td  class=\"ptext\"  ><input type=\"text\" value=\"Chỉ định tạm ứng\" style=\"width: 350px\" id=\"txtLyDo\"/></td>";
                html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Lưu TU\" onclick=\"luuTU(" + idbn + ");\"/></td>";
                html += "</tr>";
                html += "</table>";
                html += "</div>";
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }

    private void ThuPhiTamUng()
    {
        try
        {
            string idbn = Request.QueryString["idbn"];
            string IsSua = "";
            string html = "";
            string SoDangKy = StaticData.SoDangKyMoiNhat();
            string QuyenSo = StaticData.QuyenSoMoiNhat();
            if (Request.QueryString["IsSua"] != null)
            {
                IsSua = Request.QueryString["IsSua"].ToString();
                if (IsSua == "1")
                {
                    string sqlTamUng = "select * from tamung where iddangkykham=" + idbn;
                    DataTable dtTU = DataAcess.Connect.GetTable(sqlTamUng);
                    if (dtTU != null && dtTU.Rows.Count > 0)
                    {
                        html = "<div style=\"850px;overflow:auto;height:200px\">";
                        html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" >";


                        html += "<tr >";
                        //Quyển Số
                        ////html += "<td class=\"ptext\" >Quyển Số</td>";
                        ////html += "<td  class=\"ptext\"  ><input type=\"text\" id=\"txtQuyenSo\" value=\""+dtTU.Rows[0]["QuyenSo"]+"\"/>&nbsp; &nbsp; &nbsp; &nbsp;</td>";
                        ////html += "<td class=\"ptext\" >Số CT</td>";
                        ////html += "<td  class=\"ptext\"  ><input type=\"text\" id=\"txtSoCT\" value=\"" + dtTU.Rows[0]["SoCTTU"] + "\"/>&nbsp; &nbsp; &nbsp; &nbsp;</td>";
                        //////Số tiền=
                        ////html += "<td class=\"ptext\" >Số tiền</td>";
                        ////html += "<td  class=\"ptext\"  ><input type=\"text\" id=\"txtSoTien\" value=\"" + dtTU.Rows[0]["sotien"] + "\" /></td>";
                        ////html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Sửa TU\" onclick=\"luuTU(" + idbn + ");\"/></td>";
                        //html += "<td class=\"ptext\" >Số đăng ký:</td>";
                        //html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoDangKy\" value=\"" + SoDangKy + "\" />&nbsp;&nbsp;</td>";
                        html += "<td class=\"ptext\" >Quyển Số: </td>";
                        html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtQuyenSo\" value=\"" + (QuyenSo == "0" ? "" : QuyenSo) + "\" />&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                        html += "<td class=\"ptext\" >Số CT:</td>";
                        html += "<td  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoCT\" value=\"\"/> &nbsp;&nbsp;&nbsp;&nbsp;</td>";
                        html += "<td class=\"ptext\" >Số tiền</td>";
                        html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoTien\" value=\"" + dtTU.Rows[0]["sotien"] + "\" /></td>";
                        html += "<td class=\"ptext\" >Lý do</td>";
                        html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 180px\" value=\"" + dtTU.Rows[0]["GhiChu"] + "\" id=\"txtLyDo\"/></td>";
                        html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Sửa TU\" onclick=\"luuTU(" + idbn + ");\"/></td>";
                        html += "</tr>";
                        html += "</tr>";
                        html += "</table>";
                        html += "</div>";
                    }
                }
                else
                {
                    html = "<div style=\"850px;overflow:auto;height:150px\">";
                    html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" >";


                    html += "<tr >";
                    //Quyển Số
                    //html += "<td class=\"ptext\" >Số đăng ký:</td>";
                    //html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoDangKy\" value=\"" + SoDangKy + "\" />&nbsp;&nbsp;</td>";
                    html += "<td class=\"ptext\" >Quyển Số: </td>";
                    html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtQuyenSo\" value=\"" + (QuyenSo=="0" ? "":QuyenSo) + "\" />&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                    html += "<td class=\"ptext\" >Số CT:</td>";
                    html += "<td  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoCT\" value=\"\"/> &nbsp;&nbsp;&nbsp;&nbsp;</td>";
                    //Số tiền=
                    html += "<td class=\"ptext\" >Số tiền</td>";
                    html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                    html += "<td class=\"ptext\" >Lý do</td>";
                    html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 180px\" id=\"txtLyDo\"/></td>";
                    html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Lưu TU\" onclick=\"luuTU(" + idbn + ");\"/></td>";
                    html += "</tr>";

                    //html += "<tr><td colspan=\"2\"><br/></td></tr>";

                    html += "</table>";
                    html += "</div>";
                }
            }
            else
            {
                html = "<div style=\"850px;overflow:auto;height:150px\">";
                html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" >";


                html += "<tr >";
                //Quyển Số
                //html += "<td class=\"ptext\" >Số đăng ký:</td>";
                //html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoDangKy\" value=\"" + SoDangKy + "\" />&nbsp;&nbsp;</td>";
                html += "<td class=\"ptext\" >Quyển Số: </td>";
                html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtQuyenSo\" value=\"" + (QuyenSo == "0" ? "" : QuyenSo) + "\" />&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                html += "<td class=\"ptext\" >Số CT:</td>";
                html += "<td  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoCT\" value=\"\"/> &nbsp;&nbsp;&nbsp;&nbsp;</td>";
                //Số tiền=
                html += "<td class=\"ptext\" >Số tiền</td>";
                html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 80px\" id=\"txtSoTien\"/></td>";
                html += "<td class=\"ptext\" >Lý do</td>";
                html += "<td  class=\"ptext\"  ><input type=\"text\" style=\"width: 180px\" id=\"txtLyDo\"/></td>";
                html += "<td  class=\"ptext\"  ><input type=\"button\" id=\"btnTU\" value=\"Lưu TU\" onclick=\"luuTU(" + idbn + ");\"/></td>";
                html += "</tr>";

                //html += "<tr><td colspan=\"2\"><br/></td></tr>";

                html += "</table>";
                html += "</div>";
            }
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private void luuThuPhiTU()
    {
        try
        {
            string hdIdTamUng = Request.QueryString["hdIdTamUng"];
            string iddangkykham = Request.QueryString["iddangkykham"];
            double sotien = double.Parse(Request.QueryString["sotien"]);
            string SoDangKy = Request.QueryString["SoDangKy"].ToString();
            string quyenso = Request.QueryString["quyenso"].ToString();
            string lydoTU = Request.QueryString["lydoTU"].ToString();
            string ngayUT = DataAcess.Connect.s_SystemDate();
            string sqlCheck = "select * from tamUng where idtamung=" + hdIdTamUng + "";
            DataTable dtCheck = DataAcess.Connect.GetTable(sqlCheck);
            ////////////
            string sqlbn = ""
                               + "  select c.tenbenhnhan,c.idbenhnhan from chitietdangkykham a" + "\r\n"
                               + "  left join dangkykham b on a.iddangkykham=b.iddangkykham" + "\r\n"
                               + " left join benhnhan c on c.idbenhnhan=b.idbenhnhan " + "\r\n"
                               + " where a.idchitietdangkykham=" + iddangkykham + "\r\n";
            DataTable dtht = DataAcess.Connect.GetTable(sqlbn);
            string HoTen = "";
            string idbenhnhan = "0";
            if (dtht != null && dtht.Rows.Count > 0)
            {
                HoTen = dtht.Rows[0]["tenbenhnhan"].ToString();
                idbenhnhan = dtht.Rows[0]["idbenhnhan"].ToString();
            }
            ///////////
            if (dtCheck != null && dtCheck.Rows.Count != 0)
            {
                //StaticData.NewSoChungTu_QuyenSO(ngayUT, HoTen, "Tạm Ứng", sotien.ToString(), quyenso);
                //string NewSTT = DataAcess.Connect.GetTable("select max(stt) from sochungtu").Rows[0][0].ToString();
                string NewSTT = "";
                if (Request.QueryString["SoCT"] != null)
                {
                    ////NewSTT = dtCheck.Rows[0]["SoCTTU"].ToString();
                    ////string UpdateSCT = " update sochungtu set SophieuCT='" + Request.QueryString["SoCT"].ToString() + "' ,QuyenSo='" + Request.QueryString["quyenso"] + "' where STT=" + NewSTT + "";
                    ////bool resSCT = DataAcess.Connect.ExecSQL(UpdateSCT);
                }
                string sqlInsert = "update tamUng set isdathu=1,LyDoTU=N'" + lydoTU + "',sotien=" + sotien + ",SoCTTU='" + NewSTT + "',QuyenSo='" + quyenso + "'  where IDTamUng=" + dtCheck.Rows[0]["IDTamUng"].ToString() + "";
                bool result = DataAcess.Connect.ExecSQL(sqlInsert);
                //string idChungTu = dtCheck.Rows[0]["SoCTTU"].ToString().Trim();
                //string sqlUpDateSCT = " update sochungtu set sotien=" + sotien + ", SoDangKy='" + SoDangKy + "',QuyenSo='" + quyenso + "',SoPhieuCT='" + NewSTT + "' where stt=" + idChungTu;
                //result = DataAcess.Connect.ExecSQL(sqlUpDateSCT);
                //Update soChungTu

                if (result == false)
                {
                    Response.Write("");
                }
                else
                {
                    Response.Write("1");
                }
            }
            else
            {

                //StaticData.NewSoChungTu_QuyenSO(ngayUT, HoTen, "Tạm Ứng", sotien.ToString(),quyenso);
                //string NewSTT= DataAcess.Connect.GetTable("select max(stt) from sochungtu").Rows[0][0].ToString();
                string NewSTT = "";
                string idsct = "";
                //if (Request.QueryString["SoCT"]!=null)
                //{
                NewSTT = Request.QueryString["SoCT"].ToString();
                //string sctu = "select * from tamung where SoCTTU='" + NewSTT + "' and Quyenso='" + quyenso + "'";
                string sctu = "select * from sochungtu where SophieuCT='" + NewSTT + "' and QuyenSo='" + quyenso + "'";
                DataTable dtSoCT = DataAcess.Connect.GetTable(sctu);
                if (dtSoCT != null && dtSoCT.Rows.Count > 0)
                {
                    Response.Write("Số chứng từ này đã tồn tại");
                    return;
                }
                //string sqlSave = "INSERT INTO SOCHUNGTU(NgayCT,SophieuCT,dahuy,HoTen,NoiDung,SoTien,QuyenSO,SoDangKy) VALUES('" + ngayUT + "','" + NewSTT + "',0,N'" + HoTen + "',N'Tạm Ứng'," + sotien.ToString() + ",'" + quyenso + "','" + SoDangKy+ "')";
                //idsct=StaticData.NewSoChungTu_QuyenSO(ngayUT,HoTen,"Tạm Ứng",sotien.ToString(),quyenso,NewSTT,SoDangKy,idbenhnhan);

                //}
                #region thêm số chứng từ vào bảng sochungtu
                //Tên Bệnh nhân 
                string TenBenhNhan = "";

                //End Tên BN
                string NgaySCT = (DateTime.Parse(DataAcess.Connect.s_SystemDate())).ToString("MM/dd/yyyy hh:ss");
                //NewSTT = StaticData.NewSoChungTuTamUng(NgaySCT, TenBenhNhan, "Tạm ứng khám bệnh", sotien.ToString(), Request.QueryString["SoCT"].ToString(), Request.QueryString["quyenso"].ToString());
                NewSTT = StaticData.NewSoChungTuGetID(NgaySCT, TenBenhNhan, "Tạm ứng khám bệnh", sotien.ToString());
                #endregion
                string NgayHoanU = null;
                string sqlInsert = "insert into tamUng values(" + iddangkykham + "," + sotien + ",'" + ngayUT + "',"+NgayHoanU+",'','',N'" + lydoTU + "','" + NewSTT + "',0,'" + quyenso + "',1,N'" + lydoTU + "',0)";
                bool result = DataAcess.Connect.ExecSQL(sqlInsert);
                if (result == false)
                {
                    Response.Write("");
                }
                else
                {
                    Response.Write("1");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("");
        }
    }
    #endregion

    private void LoadDanhSachBacSiChuyenKhoa()
    {
        string tenBacSi = Request.QueryString["q"].Trim(); ;

        string html = "";

        DateTime day = DateTime.Now;
        string ngayy = day.ToString("dd/MM/yyyy");

        string ngayHienTai = StaticData.CheckDate(ngayy);
        string sqlT = @"select id=bs.idbacsi,bs.tenbacsi,idphongban=bs.idphongkhambenh ,tenphong from bacsi bs left join kb_phong p on p.id=bs.idphongkhambenh where tenbacsi like N'%" + tenBacSi + @"%'
union all
select id=idnhanvien,tenbacsi=tennhanvien,nv.idphongban,tenphong=tenphongban from nhanvien nv left join phongban p on p.idphongban=nv.idphongban where  idchucvu=6
                    and tennhanvien like N'%" + tenBacSi + @"%'";
        DataTable arr = DataAcess.Connect.GetTable(sqlT);

        foreach (DataRow h in arr.Rows)
        {
            html += string.Format("{0}|{1}|{2}|{3}", "<div>"
            + "<div style=\"width:30%;float:left\" >" + h["tenbacsi"] + "</div>"
            + "<div style=\"width:30%;float:left\" >" + h["tenphong"] + "</div>"
           + "</div>", h["id"], h["tenbacsi"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
    }
    
}

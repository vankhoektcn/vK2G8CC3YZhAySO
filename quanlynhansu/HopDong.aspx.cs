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

public partial class NhanSu_HopDong : System.Web.UI.Page
{
    clsDanhSachHopDong dshd = null;
    string strSelect = " select ROW_NUMBER ( ) OVER(ORDER BY hd.idhopdong) AS STT,hd.idhopdong,lhd.tenloaihopdong,hd.idnhanvien,nv.tennhanvien,hd.idloaihopdong,hd.masohopdong,convert(varchar,hd.ngayky,103)as ngayky," + "\r\n"
        + " convert(varchar,hd.ngaybatdau,103)as ngaybatdau,convert(varchar,hd.ngayketthuc,103)as ngayketthuc ,hd.thoihanhopdong,hd.noiky,hd.chuyenmon,round(convert(real,hd.mucluongcoban),0) as mucluongcoban" + "\r\n"
        + " ,hd.giolam,hd.motacongviec,convert(varchar,hd.thuviectungay,103)as thuviectungay" + "\r\n"
        + " ,convert(varchar,hd.thuviecdenngay,103)as thuviecdenngay,hd.diadiemlamviec,hd.thoathuankhac,hd.dungculamviec" + "\r\n"
        + " ,case when nv.loaiNhanVien=0 then N'Thường xuyên' when nv.loaiNhanVien=1 then N'Không thường xuyên' end as Loai,hd.sohopdong,sohopdong1=hd.sohopdong+'/MĐ',hd.HeSoLCB,hd.luongCB,nv.LoaiNhanVien,nv.trinhdo"
        + " ,CoBaoHiem=(select isnull((select convert(int,iscoBaoHiem) from hopdong where status=1 and  idhopdong=hd.idhopdong),0)) ";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //txtHeSo.Text = StaticData.HeSoLuongCB.ToString();
            //txtMucLuongCoBan.Text = StaticData.LuongCoBan.ToString();
            bindLoaiHopDong();
            bindGrid();
            setAttribute();
        }
    }
    void bindLoaiHopDong()
    {
        string sql = "select idloaihopdong,tenloaihopdong from loaihopdong where status=1";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlLoaiHopDong, tb, "idloaihopdong", "tenloaihopdong", "Chọn loại hợp đồng");
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (ddlLoaiHopDong.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Chưa chọn hợp đồng');", true);
            return;
        }
        if (txtIdNhanVien.Value == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Chưa chọn nhân viên');", true);
            return;
        }
        //if (txtTongLCB.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Chưa nhập lương cơ bản !');", true);
        //    return;
        //}

        //////
        //////////
        /////////////////////
        //tạo nội dung hợp đồng
        #region tạo nội dung hợp đồng
        DataTable dtGiamDoc = DataAcess.Connect.GetTable("select nv.*,cv.tenchucvu from nhanvien nv inner join chucvu cv on nv.idchucvu=cv.idchucvu where machucvu='GD'");
        string tenGiamDoc = "";
        string ChucVuNDD = "";
        string DienThoaiNDD = "";
        string DiaChiNDD = "";
        string QuocTichNDD = "";
        if (dtGiamDoc.Rows.Count > 0)
        {
            tenGiamDoc = dtGiamDoc.Rows[0]["tennhanvien"].ToString();
            ChucVuNDD= dtGiamDoc.Rows[0]["tenchucvu"].ToString();
            DienThoaiNDD = dtGiamDoc.Rows[0]["dienthoai"].ToString().Trim();
            if(DienThoaiNDD=="")
                DienThoaiNDD = dtGiamDoc.Rows[0]["didong"].ToString().Trim();
            DiaChiNDD = dtGiamDoc.Rows[0]["diachitamtru"].ToString().Trim();
            if (DiaChiNDD == "")
                DiaChiNDD = dtGiamDoc.Rows[0]["diachithuongtru"].ToString().Trim();
            QuocTichNDD = dtGiamDoc.Rows[0]["quoctich"].ToString().Trim();
            if (QuocTichNDD == "")
                QuocTichNDD = "Việt Nam";
        }
        //Lấy thông tin nhân viên
        string sqlNhanVien = "select nv.*,convert(varchar,nv.ngaycapCMND,103) as ngaycapCMND1,convert(varchar,nv.ngaysinh,103) as ngaySinh1,cv.tenchucvu from nhanvien nv inner join chucvu cv on nv.idchucvu=cv.idchucvu where nv.idnhanvien=" + txtIdNhanVien.Value;
        DataTable dtNhanVien = DataAcess.Connect.GetTable(sqlNhanVien);
        string sqlHDNhanVien = ""
+ " select top 1 hd.*" + "\r\n"
+ " ,lhd.tenloaihopdong" + "\r\n"
+ " ,TuNgayDenNgay=N'Từ ngày '+convert(varchar,day(ngaybatdau)) +N' tháng '+convert(varchar,month(ngaybatdau))+N' năm '+convert(varchar,year(ngaybatdau))+N' đến ngày '+convert(varchar,day(ngayketthuc))+N' tháng '+convert(varchar,month(ngayketthuc))+N' năm '+convert(varchar,year(ngayketthuc))+''" + "\r\n"
+ " ,NgayHopDong=N'ngày '+convert(varchar,day(ngayky)) +N' tháng '+convert(varchar,month(ngayky))+N' năm '+convert(varchar,year(ngayky))+''" + "\r\n"
+ "  from hopdong hd left join LoaiHopDong lhd on hd.idloaihopdong=lhd.idloaihopdong" + "\r\n"
+ "  where idnhanvien="+txtIdNhanVien.Value+" order by idhopdong desc" + "\r\n";
        DataTable dtHopDong = DataAcess.Connect.GetTable(sqlHDNhanVien);
        string tenNhanVien = "";
        string LoaiNhanVien = "0";
        string ChucVuNhanVien = "";
        string DienThoaiNhanVien = "";
        string DiaChiTTNhanVien = "";
        string ngaySinhNhanVien="";
        string NoiSinhNhanVien = "";
        string NgheNghiepNhanVien = "";
        string CMNDNhanVien = "";
        string NgayCapCM = "";
        string NoiCapCM = "";
        string ThoiHanHopDong = "";
        string TuNgayDenNgay = "";
        string DiadiemLamViec = "";
        string TrinhDoChuyenMon = "";
        string MoTaCongViec = "";
        string PhuongTienDiLai = "Tự túc";
        string NgayHopDong = "";
        string QuocTichNhanVien = "";
        string SoHopDong = "";

        string HeSOLCB = "";
        if (dtNhanVien.Rows.Count > 0)
        {
            tenNhanVien = dtNhanVien.Rows[0]["tennhanvien"].ToString();
            ChucVuNhanVien = dtNhanVien.Rows[0]["tenchucvu"].ToString();
            DienThoaiNhanVien = dtNhanVien.Rows[0]["dienthoai"].ToString().Trim();
            if (DienThoaiNhanVien == "")
                DienThoaiNhanVien = dtNhanVien.Rows[0]["didong"].ToString().Trim();
            DiaChiTTNhanVien = dtNhanVien.Rows[0]["diachithuongtru"].ToString().Trim();
            if (DiaChiTTNhanVien == "")
                DiaChiTTNhanVien = dtNhanVien.Rows[0]["diachitamtru"].ToString().Trim();
            ngaySinhNhanVien= dtNhanVien.Rows[0]["ngaySinh1"].ToString().Trim();
            CMNDNhanVien = dtNhanVien.Rows[0]["cmnd"].ToString().Trim();
            NgayCapCM = dtNhanVien.Rows[0]["ngaycapCMND1"].ToString().Trim();
            NoiCapCM = dtNhanVien.Rows[0]["noicapCMND"].ToString().Trim();
            PhuongTienDiLai = dtNhanVien.Rows[0]["phuongtiendilai"].ToString().Trim();
            LoaiNhanVien = dtNhanVien.Rows[0]["LoaiNhanVien"].ToString().Trim();
            QuocTichNhanVien = dtNhanVien.Rows[0]["quoctich"].ToString().Trim();
            if (QuocTichNhanVien == "")
                QuocTichNhanVien = "Việt Nam";
        }
        if (dtHopDong.Rows.Count > 0)
        {
            ThoiHanHopDong = dtHopDong.Rows[0]["tenloaihopdong"].ToString().Trim();
            TuNgayDenNgay= dtHopDong.Rows[0]["TuNgayDenNgay"].ToString().Trim();
            if (TuNgayDenNgay=="")
                TuNgayDenNgay = " Không thời hạn";
            DiadiemLamViec = dtHopDong.Rows[0]["diadiemlamviec"].ToString().Trim();
            TrinhDoChuyenMon = dtHopDong.Rows[0]["chuyenmon"].ToString().Trim();
            MoTaCongViec = dtHopDong.Rows[0]["motacongviec"].ToString().Trim();
            NgayHopDong = dtHopDong.Rows[0]["NgayHopDong"].ToString().Trim();
            HeSOLCB = dtHopDong.Rows[0]["HeSoLCB"].ToString().Trim();
            if (HeSOLCB == "")
                HeSOLCB = "1.86";
        }
            SoHopDong = txtSoHopDong.Text.Trim();//dtHopDong.Rows[0]["SoHopDong"].ToString().Trim();
        //end lấy thông tin nhân viên.
        string NoiDungHopDong="";
        string FontSize =StaticData.FontSizeHopDong.ToString()+"";
        if (LoaiNhanVien == "1")
        {
            NoiDungHopDong = "<html dir=\"ltr\">"
              + " <head>"
              + "     <title></title>"
               + " </head>"
               + " <body>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\"><b><font size=\""+FontSize+"\">&nbsp;CỘNG HO&Agrave; X&Atilde; HỘI CHỦ NGHĨA VIỆT NAM</font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\"><b><font size=\""+FontSize+"\">Độc lập &ndash; Tự do &ndash; Hạnh ph&uacute;c</font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 14.2pt; line-height: 18pt\">&nbsp;</div>"
                   + " <br clear=\"all\" />"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 45pt; line-height: 18pt; text-align: center\"><b><font size=\"" + FontSize + "\">C&Ocirc;NG TY CỔ PHẦN&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 14.2pt; line-height: 18pt; text-align: center\"><b><font size=\""+FontSize+"\">KH&Aacute;M CHỮA BỆNH MINH ĐỨC</font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt 9pt; text-indent: -9pt; line-height: 18pt; text-align: center\"><font size=\"" + FontSize + "\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Số:&nbsp;" + SoHopDong + "/MĐ</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\" align=\"center\"><b>&nbsp;</b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\"><b><font size=\"" + FontSize + "\"><span style=\"\">HỢP ĐỒNG</span></font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\"><b><font size=\"" + FontSize + "\"><span style=\"\">L&Agrave;M VIỆC KH&Ocirc;NG THƯỜNG XUY&Ecirc;N</span></font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in -21.55pt 0pt 0in; line-height: 110%; text-align: left\" align=\"left\"><font size=\""+FontSize+"\">Ông(bà):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style=\"background-color: #ffffff\"><b>" + tenGiamDoc + "</b></span><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>Quốc tịch: " + QuocTichNDD + "</font></div>"
                   + " <div style=\"margin: 0in -21.55pt 0pt 0in; line-height: 110%; text-align: left\" align=\"left\"><font size=\""+FontSize+"\">Chức vụ:&nbsp;<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=\" line-height: 110%\">" + ChucVuNDD + " </span></font></div>"
                   + " <div style=\"margin: 0in -21.55pt 0pt 0in; line-height: 110%; text-align: left\" align=\"left\"><font size=\""+FontSize+"\">Đại diện cho:&nbsp;<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=\" line-height: 110%\">C&ocirc;ng ty cổ phần kh&aacute;m chữa bệnh Minh Đức</span></font></div>"
                   + " <div style=\"margin: 0in -21.55pt 0pt 0in; line-height: 110%; text-align: left\" align=\"left\"><font size=\""+FontSize+"\">Điện thoại: <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=\" line-height: 110%\">" + DienThoaiNDD + "</span></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 110%; text-align: justify\"><font size=\""+FontSize+"\">Địa chỉ:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style=\" line-height: 110%\">" + DiaChiNDD + "</span><i></font></i></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 110%\"><font size=\""+FontSize+"\">Sau đ&acirc;y gọi tắt l&agrave; b&ecirc;n A.</font></div>"
                   + " <table style=\"border-collapse: collapse\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">|"
                       + " <tbody>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 0pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 150.4pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"151\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Ông(bà):</font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 184.8pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"246\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><b><font size=\"" + FontSize + "\">" + tenNhanVien + "</font></b></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 152pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"203\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Quốc tịch: " + QuocTichNhanVien + "</font></div>"
                               + " </td>"
                           + " </tr>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 113.4pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"151\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Sinh&nbsp;ng&agrave;y: </font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 184.8pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"246\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">" + ngaySinhNhanVien + ".</font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 152pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"203\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Tại: " + NoiSinhNhanVien + "</font></div>"
                               + " </td>"
                           + " </tr>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 113.4pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"151\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Nghề nghiệp: </font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 184.8pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"246\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">" + NgheNghiepNhanVien + "</font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 152pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"203\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\">&nbsp;</div>"
                               + " </td>"
                           + " </tr>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 113.4pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"151\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Địa chỉ thường tr&uacute;:</font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 336.8pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"449\" colspan=\"2\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">" + DiaChiTTNhanVien + "</font></div>"
                               + " </td>"
                           + " </tr>"
                       + " </tbody>"
                   + " </table>"
                   + " <br/>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: justify\"><font size=\"" + FontSize + "\">Số CMTND: <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + CMNDNhanVien + ".&nbsp;&nbsp;&nbsp; cấp ng&agrave;y&nbsp;:&nbsp;.." + NgayCapCM + "..tại: .." + NoiCapCM + "..</span></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: justify\"><font size=\"" + FontSize + "\">Số điện thoại:<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + DienThoaiNhanVien + "</span></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: justify\"><font size=\"" + FontSize + "\">Sau đ&acirc;y gọi tắt l&agrave; b&ecirc;n B.</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><span style=\"letter-spacing: -0.2pt\"><font size=\""+FontSize+"\">C&ugrave;ng thoả thuận k&yacute; hợp đồng l&agrave;m việc kh&ocirc;ng thường xuy&ecirc;n (sau đ&acirc;y gọi l&agrave; hợp đồng) v&agrave; cam kết l&agrave;m đ&uacute;ng những điều khoản sau đ&acirc;y:</font></span></div>"
                   + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
                   + " <div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 1. C&Ocirc;NG VIỆC V&Agrave; THỜI HẠN HỢP ĐỒNG</span></font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Loại hợp đồng lao động: " + ThoiHanHopDong + "</font></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span style=\"font-size: 14pt\">-<span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><span style=\"font-size: 14pt\">  <font size=\""+FontSize+"\">" + TuNgayDenNgay + "<span style=\"color: blue\"></span></font></span></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span style=\"color: blue\"><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Địa điểm l&agrave;m việc:<span style=\"color: blue\"> " + DiadiemLamViec + "</span></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Tr&igrave;nh độ chuy&ecirc;n m&ocirc;n: " + TrinhDoChuyenMon + "</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">C&ocirc;ng việc phải l&agrave;m: " + MoTaCongViec + "</font></div>"
                   + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
                   + " <div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 2: CHẾ ĐỘ L&Agrave;M VIỆC</span></font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Thời giờ l&agrave;m việc: Ngo&agrave;i giờ theo thỏa thuận của hai b&ecirc;n (k&egrave;m theo phụ lục hợp đồng bổ sung sau).</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Được cung cấp những dụng cụ l&agrave;m việc cần thiết phục vụ c&ocirc;ng việc.</font></div>"
                   + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
                   + " <div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 3: NGHĨA VỤ V&Agrave; QUYỀN LỢI CỦA B&Ecirc;N B</span></font></b></div>"
                   + " <div style=\"margin: 6pt 0in; line-height: 18pt\"><b><font size=\""+FontSize+"\">3.1. Quyền lợi: </font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Phương tiện đi lại l&agrave;m việc: " + PhuongTienDiLai + "</b></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Tiền c&ocirc;ng gắn với tr&aacute;ch nhiệm c&ocirc;ng việc (k&egrave;m theo phụ lục hợp đồng bổ sung sau). </font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">H&igrave;nh thức trả lương: Qua thẻ ATM hoặc bằng tiền mặt.</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Được trả lương: 1 lần, trước ng&agrave;y 15 h&agrave;ng th&aacute;ng.</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span style=\"letter-spacing: -0.3pt\"><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><span style=\"letter-spacing: -0.3pt\"><font size=\""+FontSize+"\">Trang bị bảo hộ lao động: do b&ecirc;n B tự trang bị</font></span></div>"
                   + " <div style=\"margin: 6pt 0in; line-height: 18pt\"><b><font size=\""+FontSize+"\">3.2 Nghĩa vụ</font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Chấp h&agrave;nh nghi&ecirc;m những cam kết trong Hợp đồng.</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Chấp h&agrave;nh nội quy lao động, kỷ luật lao động, quy định về an to&agrave;n, vệ sinh lao động v&agrave; c&aacute;c quy định kh&aacute;c của b&ecirc;n A; chịu tr&aacute;ch nhiệm trong phạm vi c&ocirc;ng việc được ph&acirc;n c&ocirc;ng. </font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span style=\"letter-spacing: -0.3pt\"><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><span style=\"letter-spacing: -0.3pt\"><font size=\""+FontSize+"\">Kh&ocirc;ng g&acirc;y ảnh xấu đến c&ocirc;ng việc, uy t&iacute;n của b&ecirc;n A.</font></span></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 14.2pt; line-height: 18pt\"><b><u><font size=\""+FontSize+"\">Bồi thường vi phạm:</font></u></b></div>"
                   + " <div style=\"margin: 3pt 0in; line-height: 16pt\"><font size=\""+FontSize+"\">- Bồi thường thiệt hại nếu l&agrave;m hư hỏng, mất m&aacute;t t&agrave;i sản, thiết bị, c&ocirc;ng cụ, dụng cụ được giao nếu do lỗi của b&ecirc;n B theo quy định của ph&aacute;p luật lao động, nội quy lao động, quy chế, quy định của b&ecirc;n A.</font></div>"
                   + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
                   + " <div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 4: NGHĨA VỤ V&Agrave; QUYỀN HẠN CỦA B&Ecirc;N A</span></font></b></div>"
                   + " <div style=\"margin: 2pt 0in; line-height: 16pt\"><b><font size=\""+FontSize+"\">4.1. Nghĩa vụ</font></b></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Thực hiện đầy đủ những điều đ&atilde; cam kết trong Hợp đồng.</font></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Thanh to&aacute;n đầy đủ, đ&uacute;ng thời hạn c&aacute;c chế độ v&agrave; quyền lợi cho b&ecirc;n B theo hợp đồng.</font></div>"
                   + " <div style=\"margin: 2pt 0in; line-height: 16pt\"><b><font size=\""+FontSize+"\">4.2. Quyền hạn</font></b></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span style=\"letter-spacing: -0.4pt\"><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style=\"letter-spacing: -0.4pt\"><font size=\""+FontSize+"\">Điều h&agrave;nh b&ecirc;n B ho&agrave;n th&agrave;nh c&ocirc;ng việc theo hợp đồng (bố tr&iacute;, điều chỉnh, tạm ngừng việc&hellip;).</font></span></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Tạm ho&atilde;n, chấm dứt hợp đồng, kỷ luật b&ecirc;n B theo quy định của ph&aacute;p luật v&agrave; nội quy lao động của b&ecirc;n A.</font></div>"
                   + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
                   + " <div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 5. ĐIỀU KHOẢN THI H&Agrave;NH</span></font></b></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Những vấn đề về lao động kh&ocirc;ng ghi trong hợp đồng lao động n&agrave;y th&igrave; &aacute;p dụng theo quy định của luật lao động v&agrave; c&aacute;c văn bản ph&aacute;p luật lao động hiện h&agrave;nh kh&aacute;c.</font></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Hợp đồng được lập th&agrave;nh 02 bản, mỗi bản gồm 02 trang, c&oacute; gi&aacute; trị ngang nhau, mỗi b&ecirc;n giữ một bản v&agrave; c&oacute; hiệu lực từ ng&agrave;y k&yacute; hợp đồng. Khi hai b&ecirc;n k&yacute; kết phụ lục hợp đồng th&igrave; nội dung của phụ lục hợp đồng cũng c&oacute; gi&aacute; trị như c&aacute;c nội dung của bản hợp đồng n&agrave;y.</font></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Hợp đồng n&agrave;y được l&agrave;m tại Trụ sở của b&ecirc;n A, " + NgayHopDong + "</font></div>"
                   + " <table style=\"width: 964px; border-collapse: collapse; height: 82px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">"
                       + " <tbody>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 239.25pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"319\">"
                               + " <div style=\"margin: 6pt 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><b><font size=\""+FontSize+"\">B&Ecirc;N B</font></b></div>"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><font size=\""+FontSize+"\">(Người lao động)</font></div>"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><i><font size=\""+FontSize+"\">(K&yacute;, ghi r&otilde; họ v&agrave; t&ecirc;n)</font></i></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 239.3pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"319\">"
                               + " <div style=\"margin: 6pt 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><b><font size=\"" + FontSize + "\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B&Ecirc;N A</font></b></div>"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><font size=\"" + FontSize + "\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Người sử dụng lao động)</font></div>"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><font size=\"" + FontSize + "\"><b><i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(</i></b><i>K&yacute;, ghi r&otilde; họ t&ecirc;n, đ&oacute;ng dấu<b>)</b></i></font></div>"
                               + " </td>"
                           + " </tr>"
                       + " </tbody>"
                   + " </table>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
               + "  </body> "
           + " </html>";
        }
        else
        {
            NoiDungHopDong = "<html dir=\"ltr\">"
              + " <head>"
              + "     <title></title>"
               + " </head>"
               + " <body>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\"><b><font size=\""+FontSize+"\">&nbsp;CỘNG HO&Agrave; X&Atilde; HỘI CHỦ NGHĨA VIỆT NAM</font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\"><b><font size=\""+FontSize+"\">Độc lập &ndash; Tự do &ndash; Hạnh ph&uacute;c</font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 14.2pt; line-height: 18pt\">&nbsp;</div>"
                   + " <br clear=\"all\" />"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 45pt; line-height: 18pt; text-align: center\"><b><font size=\"" + FontSize + "\">C&Ocirc;NG TY CỔ PHẦN &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 14.2pt; line-height: 18pt; text-align: center\"><b><font size=\""+FontSize+"\">KH&Aacute;M CHỮA BỆNH MINH ĐỨC</font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt 9pt; text-indent: -9pt; line-height: 18pt; text-align: center\"><font size=\"" + FontSize + "\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Số:&nbsp;" + SoHopDong + "/MĐ</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\" align=\"center\"><b>&nbsp;</b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\"><b><font size=\"" + FontSize + "\"><span style=\"\">HỢP ĐỒNG LAO ĐỘNG</span></font></b></div>"
                   
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in -21.55pt 0pt 0in; line-height: 110%; text-align: left\" align=\"left\"><font size=\""+FontSize+"\">Ông(bà):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style=\"background-color: #ffffff\"><b>" + tenGiamDoc + "</b></span><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>Quốc tịch:"+QuocTichNDD+"</font></div>"
                   + " <div style=\"margin: 0in -21.55pt 0pt 0in; line-height: 110%; text-align: left\" align=\"left\"><font size=\""+FontSize+"\">Chức vụ:&nbsp;<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=\" line-height: 110%\">" + ChucVuNDD + " </span></font></div>"
                   + " <div style=\"margin: 0in -21.55pt 0pt 0in; line-height: 110%; text-align: left\" align=\"left\"><font size=\""+FontSize+"\">Đại diện cho:&nbsp;<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=\" line-height: 110%\">C&ocirc;ng ty cổ phần kh&aacute;m chữa bệnh Minh Đức</span></font></div>"
                   + " <div style=\"margin: 0in -21.55pt 0pt 0in; line-height: 110%; text-align: left\" align=\"left\"><font size=\""+FontSize+"\">Điện thoại: <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=\" line-height: 110%\">" + DienThoaiNDD + "</span></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 110%; text-align: justify\"><font size=\""+FontSize+"\">Địa chỉ:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style=\" line-height: 110%\">" + DiaChiNDD + "</span><i>.</font></i></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 110%\"><font size=\""+FontSize+"\">Sau đ&acirc;y gọi tắt l&agrave; b&ecirc;n A.</font></div>"
                   + " <table style=\"border-collapse: collapse\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">|"
                       + " <tbody>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 0pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 150.4pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"151\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">&Ocirc;ng(b&agrave;):</font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 184.8pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"246\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><b><font size=\"" + FontSize + "\">" + tenNhanVien + "</font></b></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 152pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"203\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Quốc tịch: " + QuocTichNhanVien + "</font></div>"
                               + " </td>"
                           + " </tr>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 113.4pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"151\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Sinh&nbsp;ng&agrave;y: </font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 184.8pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"246\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">" + ngaySinhNhanVien + ".</font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 152pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"203\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Tại: " + NoiSinhNhanVien + "</font></div>"
                               + " </td>"
                           + " </tr>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 113.4pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"151\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Nghề nghiệp: </font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 184.8pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"246\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">" + NgheNghiepNhanVien + "</font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 152pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"203\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\">&nbsp;</div>"
                               + " </td>"
                           + " </tr>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 113.4pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"151\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">Địa chỉ thường tr&uacute;:</font></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 336.8pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"449\" colspan=\"2\">"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><font size=\"" + FontSize + "\">" + DiaChiTTNhanVien + "</font></div>"
                               + " </td>"
                           + " </tr>"
                       + " </tbody>"
                   + " </table>"
                   + " <br/>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: justify\"><font size=\"" + FontSize + "\">Số CMTND: <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + CMNDNhanVien + ".&nbsp;&nbsp;&nbsp; cấp ng&agrave;y&nbsp;:&nbsp;.." + NgayCapCM + "..tại: .." + NoiCapCM + "..</span></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: justify\"><font size=\"" + FontSize + "\">Số điện thoại:<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; " + DienThoaiNhanVien + "</span></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: justify\"><font size=\"" + FontSize + "\">Sau đ&acirc;y gọi tắt l&agrave; b&ecirc;n B.</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><span style=\"letter-spacing: -0.2pt\"><font size=\""+FontSize+"\">C&ugrave;ng thoả thuận k&yacute; hợp đồng l&agrave;m việc kh&ocirc;ng thường xuy&ecirc;n (sau đ&acirc;y gọi l&agrave; hợp đồng) v&agrave; cam kết l&agrave;m đ&uacute;ng những điều khoản sau đ&acirc;y:</font></span></div>"
                   + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
                   + " <div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 1. C&Ocirc;NG VIỆC V&Agrave; THỜI HẠN HỢP ĐỒNG</span></font></b></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Loại hợp đồng lao động: " + ThoiHanHopDong + "</font></div>"
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span style=\"font-size: 14pt\">-<span style=\"font: " + FontSize + " Times New Roman\">&nbsp;&nbsp; </span></span><font size=\"" + FontSize + "\"><span style=\"\"> " + TuNgayDenNgay + "<span style=\"color: blue\"></span></span></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span style=\"color: blue\"><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Địa điểm l&agrave;m việc:<span style=\"color: blue\"> " + DiadiemLamViec + "</span></font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Chức danh công việc : " + TrinhDoChuyenMon + "</font></div>"
                   + " <div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">C&ocirc;ng việc phải l&agrave;m: " + MoTaCongViec + "</font></div>"
                   ////
                   + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
                   + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 2: CHẾ ĐỘ L&Agrave;M VIỆC</span></font></b></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Thời giờ l&agrave;m việc: Theo quy định của b&ecirc;n A nhưng kh&ocirc;ng qu&aacute; 48h/tuần.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Trong trường hợp cần thiết để ho&agrave;n th&agrave;nh nhiệm vụ b&ecirc;n A c&oacute; quyền y&ecirc;u cầu b&ecirc;n B l&agrave;m th&ecirc;m giờ theo sự thỏa thuận của hai b&ecirc;n v&agrave; theo quy định của ph&aacute;p luật lao động.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Được cấp ph&aacute;t những dụng cụ l&agrave;m việc cần thiết phục vụ c&ocirc;ng việc.</font></div>"
        + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
        + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 3: NGHĨA VỤ V&Agrave; QUYỀN LỢI CỦA B&Ecirc;N B</span></font></b></div>"
        + "<div style=\"margin: 6pt 0in; line-height: 18pt\"><b><font size=\""+FontSize+"\">3.1. Quyền lợi: </font></b></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Phương tiện đi lại l&agrave;m việc: <b>Tự t&uacute;c</b></font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Mức lương: Hệ số <span style=\"color: black\">" + HeSOLCB+ " theo quy định tại thang bảng lương nh&agrave; nước v&agrave; theo quy định của b&ecirc;n A.</span></font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Tiền thưởng theo quy chế, quy định &aacute;p dụng chung do b&ecirc;n A ban h&agrave;nh.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Phụ cấp theo quy chế, quy định&nbsp;chung do b&ecirc;n A ban h&agrave;nh.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; line-height: 18pt\"><span style=\"letter-spacing: -0.3pt\"><font size=\""+FontSize+"\">C&aacute;c khoản tiền tr&ecirc;n đ&atilde; bao gồm c&aacute;c khoản thuế v&agrave; khấu trừ theo quy định của Ph&aacute;p luật.</font></span></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">H&igrave;nh thức trả lương: Qua thẻ ATM.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Được trả lương: 1 lần, trước ng&agrave;y 15 của th&aacute;ng tiếp theo.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Chế độ n&acirc;ng lương: Thực hiện theo quy định của nh&agrave; nước v&agrave; theo quy chế, quy định của b&ecirc;n A.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Chế độ nghỉ ngơi (nghỉ h&agrave;ng tuần, ph&eacute;p năm, lễ tết&hellip;): Theo quy định do b&ecirc;n A ban h&agrave;nh v&agrave; quy định của Nh&agrave; nước.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Bảo hiểm x&atilde; hội v&agrave; bảo hiểm y tế: Được tham gia BHXH, BHYT, BHTN theo quy định của ph&aacute;p luật lao động.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Chế độ đ&agrave;o tạo: Được đ&agrave;o tạo c&aacute;c nghiệp vụ chuy&ecirc;n m&ocirc;n, n&acirc;ng cao theo y&ecirc;u cầu c&ocirc;ng việc v&agrave; Quy chế đ&agrave;o tạo chung của b&ecirc;n A.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Ngo&agrave;i những quyền lợi tr&ecirc;n, t&ugrave;y v&agrave;o năng lực c&aacute; nh&acirc;n v&agrave; t&igrave;nh h&igrave;nh thực tế, người lao động c&ograve;n được hưởng những quyền lợi sau:</font></div>"
        + "<div style=\"margin: 0in 0in 0pt 24pt; text-indent: -12pt; line-height: 16pt\"><span><font size=\""+FontSize+"\">&middot;</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Được x&eacute;t bổ nhiệm, giao nhiệm vụ v&agrave;o c&aacute;c vị tr&iacute; cao hơn trong qu&aacute; tr&igrave;nh c&ocirc;ng t&aacute;c.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt 24pt; text-indent: -12pt; line-height: 16pt\"><span><font size=\""+FontSize+"\">&middot;</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Được hưởng c&aacute;c chế độ ưu đ&atilde;i kh&aacute;c theo quy định của b&ecirc;n A.</font></div>"
        + "<div style=\"margin: 6pt 0in; line-height: 18pt\"><b><font size=\""+FontSize+"\">3.2 Nghĩa vụ:</font></b></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Chấp h&agrave;nh nghi&ecirc;m những cam kết trong Hợp đồng.</font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Chấp h&agrave;nh nội quy lao động, kỷ luật lao động, quy định về an to&agrave;n, vệ sinh lao động v&agrave; c&aacute;c quy định kh&aacute;c của b&ecirc;n A. </font></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span style=\"letter-spacing: -0.3pt\"><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><span style=\"letter-spacing: -0.3pt\"><font size=\""+FontSize+"\">Giữ b&iacute; mật th&ocirc;ng tin nội bộ theo quy định của ph&aacute;p luật v&agrave; của b&ecirc;n A.</font></span></div>"
        + "<div style=\"margin: 0in 0in 0pt; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Chịu sự điều h&agrave;nh, điều động, lu&acirc;n chuyển c&ocirc;ng t&aacute;c theo y&ecirc;u cầu c&ocirc;ng việc của b&ecirc;n A nhưng kh&ocirc;ng tr&aacute;i với quy định của ph&aacute;p luật lao động.</font></div>"
        + "<div style=\"margin: 3pt 0in; text-indent: 14.2pt; line-height: 18pt\"><b><u><font size=\""+FontSize+"\">Bồi thường vi phạm:</font></u></b></div>"
        + "<div style=\"margin: 3pt 0in; line-height: 16pt\"><font size=\""+FontSize+"\">- Bồi thường thiệt hại nếu l&agrave;m hư hỏng, mất m&aacute;t t&agrave;i sản, thiết bị, c&ocirc;ng cụ, dụng cụ được giao nếu do lỗi của b&ecirc;n B theo quy định của ph&aacute;p luật lao động, nội quy lao động, quy chế, quy định của b&ecirc;n A.</font></div>"
        + "<div style=\"margin: 3pt 0in; line-height: 16pt\"><font size=\""+FontSize+"\">- Trong trường hợp b&ecirc;n B vi phạm: đơn phương chấm dứt hợp đồng trước thời hạn; vi phạm Nội quy lao động, quy chế, quy định chung của đơn vị đến mức bị sa thải th&igrave; b&ecirc;n B phải bồi ho&agrave;n to&agrave;n bộ chi ph&iacute; đ&agrave;o tạo theo chuy&ecirc;n ng&agrave;nh cho b&ecirc;n A nếu được cử đi đ&agrave;o tạo.</font></div>"
        + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
        + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 4: NGHĨA VỤ V&Agrave; QUYỀN HẠN CỦA B&Ecirc;N A</span></font></b></div>"
        + "<div style=\"margin: 2pt 0in; line-height: 16pt\"><b><font size=\""+FontSize+"\">4.1. Nghĩa vụ</font></b></div>"
        + "<div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Thực hiện đầy đủ những điều đ&atilde; cam kết trong Hợp đồng.</font></div>"
        + "<div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Thanh to&aacute;n đầy đủ, đ&uacute;ng thời hạn c&aacute;c chế độ v&agrave; quyền lợi cho b&ecirc;n B theo hợp đồng v&agrave; thoả ước lao động tập thể (nếu c&oacute;).</font></div>"
        + "<div style=\"margin: 2pt 0in; line-height: 16pt\"><b><font size=\""+FontSize+"\">4.2. Quyền hạn</font></b></div>"
        + "<div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span style=\"letter-spacing: -0.4pt\"><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span style=\"letter-spacing: -0.4pt\"><font size=\""+FontSize+"\">Điều h&agrave;nh b&ecirc;n B ho&agrave;n th&agrave;nh c&ocirc;ng việc theo hợp đồng (bố tr&iacute;, điều chỉnh, tạm ngừng việc&hellip;).</font></span></div>"
        + "<div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Tạm ho&atilde;n, chấm dứt hợp đồng, kỷ luật b&ecirc;n B theo quy định của ph&aacute;p luật, thoả ước lao động tập thể (nếu c&oacute;) v&agrave; nội quy lao động của b&ecirc;n A.</font></div>"
        + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b>&nbsp;</b></div>"
        + "<div style=\"margin: 6pt 0in; line-height: 16pt; text-align: justify\"><b><font size=\"" + FontSize + "\"><span style=\"\">ĐIỀU 5. ĐIỀU KHOẢN THI H&Agrave;NH</span></font></b></div>"
        + "<div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Những vấn đề về lao động kh&ocirc;ng ghi trong hợp đồng lao động n&agrave;y th&igrave; &aacute;p dụng theo quy định của nội quy lao động, thoả ước lao động tập thể, v&agrave; quy định của ph&aacute;p luật lao động.</font></div>"
        + "<div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Hợp đồng được lập th&agrave;nh 02 bản, mỗi bản gồm 03 trang, c&oacute; gi&aacute; trị ngang nhau, mỗi b&ecirc;n giữ một bản v&agrave; c&oacute; hiệu lực từ ng&agrave;y bắt đầu tại Điều 1. Khi hai b&ecirc;n k&yacute; kết phụ lục hợp đồng th&igrave; nội dung của phụ lục hợp đồng cũng c&oacute; gi&aacute; trị như c&aacute;c nội dung của bản hợp đồng n&agrave;y.</font></div>"
                   ////
                   + " <div style=\"margin: 3pt 0in; text-indent: 0in; line-height: 18pt; text-align: justify\"><span><font size=\""+FontSize+"\">-</font><span style=\"font: 7pt Times New Roman\">&nbsp;&nbsp; </span></span><font size=\""+FontSize+"\">Hợp đồng n&agrave;y được l&agrave;m tại Trụ sở của b&ecirc;n A, " + NgayHopDong + "</font></div>"
                   + " <table style=\"width: 964px; border-collapse: collapse; height: 82px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">"
                       + " <tbody>"
                           + " <tr>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 239.25pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"319\">"
                               + " <div style=\"margin: 6pt 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><b><font size=\""+FontSize+"\">B&Ecirc;N B</font></b></div>"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><font size=\""+FontSize+"\">(Người lao động)</font></div>"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><i><font size=\""+FontSize+"\">(K&yacute;, ghi r&otilde; họ v&agrave; t&ecirc;n)</font></i></div>"
                               + " </td>"
                               + " <td style=\"border-right: #ece9d8; padding-right: 5.4pt; border-top: #ece9d8; padding-left: 5.4pt; padding-bottom: 0in; border-left: #ece9d8; width: 239.3pt; padding-top: 0in; border-bottom: #ece9d8; background-color: transparent\" valign=\"top\" width=\"319\">"
                               + " <div style=\"margin: 6pt 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><b><font size=\""+FontSize+"\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B&Ecirc;N A</font></b></div>"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><font size=\""+FontSize+"\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Người sử dụng lao động)</font></div>"
                               + " <div style=\"margin: 0in 0in 0pt; line-height: 18pt; text-align: center\" align=\"center\"><font size=\""+FontSize+"\"><b><i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(</i></b><i>K&yacute;, ghi r&otilde; họ t&ecirc;n, đ&oacute;ng dấu<b>)</b></i></font></div>"
                               + " </td>"
                           + " </tr>"
                       + " </tbody>"
                   + " </table>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
                   + " <div style=\"margin: 0in 0in 0pt\">&nbsp;</div>"
               + "  </body> "
           + " </html>";
        }
        #endregion
        //end Tạo nội dung hợp đồng
        /////////////////////
        /////////
        //////
        int TongLuongCB= StaticData.ParseInt(StaticData.ParseFloat(txtMucLuongCoBan.Text.Trim().Replace(",",""))* StaticData.ParseFloat(txtHeSo.Text.Trim()));
        string isCoBaoHiem = "0";
        if (cbCoBaoHiem.Checked)
            isCoBaoHiem = "1";
        if (txtidHopDong.Text == "")
        {
            string idPC = StaticData.MaxIdNhanSuTheoTable("hopdong","idhopdong");
           
            NhanSu_Process.HopDong clv = NhanSu_Process.HopDong.Insert_Object(idPC.ToString(),txtIdNhanVien.Value,ddlLoaiHopDong.SelectedValue
            ,txtMaHopDong.Text.Trim(),StaticData.CheckDate(txtNgayKy.Text.Trim()),StaticData.CheckDate(txtNgayBatDau.Text.Trim()),StaticData.CheckDate(txtNgayKetThuc.Text.Trim())
            ,"", txtNoiKy.Text.Trim(), txtChuyenMon.Text.Trim(), TongLuongCB.ToString(), txtGioLam.Text.Trim()
            ,txtMoTaCongViec.Text.Trim(),"1",txtThuViecTuNgay.Text.Trim(),txtThuViecDenNgay.Text.Trim(),txtDiaDiemLamViec.Text.Trim(),txtThoaThuanKhac.Text.Trim(),txtDungCu.Text.Trim()
            , txtMucLuongCoBan.Text.Trim(), txtHeSo.Text.Trim(), NoiDungHopDong,txtSoHopDong.Text.Trim(),isCoBaoHiem);
            if (clv == null)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
            else
            {
                txtidHopDong.Text = clv.idhopdong;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã lưu thành công');", true);
            }
        }
        else
        {
            NhanSu_Process.HopDong update = new NhanSu_Process.HopDong();
            update.idhopdong = txtidHopDong.Text.Trim();
            bool kq= update.Save_Object(txtidHopDong.Text.Trim(), txtIdNhanVien.Value, ddlLoaiHopDong.SelectedValue
            , txtMaHopDong.Text.Trim(), StaticData.CheckDate(txtNgayKy.Text.Trim()), StaticData.CheckDate(txtNgayBatDau.Text.Trim()), StaticData.CheckDate(txtNgayKetThuc.Text.Trim())
            , "", txtNoiKy.Text.Trim(), txtChuyenMon.Text.Trim(), TongLuongCB.ToString(), txtGioLam.Text.Trim()
            , txtMoTaCongViec.Text.Trim(), "1", txtThuViecTuNgay.Text.Trim(), txtThuViecDenNgay.Text.Trim(), txtDiaDiemLamViec.Text.Trim(), txtThoaThuanKhac.Text.Trim(), txtDungCu.Text.Trim()
            , txtMucLuongCoBan.Text.Trim(), txtHeSo.Text.Trim(), NoiDungHopDong, txtSoHopDong.Text.Trim(),isCoBaoHiem);
            if (!kq)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã lưu thành công');", true);
            }
        }
        bindGrid();
    }
    protected void bindGrid()
    {
        string sql = ""
        + strSelect
        + " from hopdong hd" + "\r\n"
        + " left join nhanvien nv on nv.idnhanvien=hd.idnhanvien" + "\r\n"
        + " left join loaihopdong lhd on lhd.idloaihopdong=hd.idloaihopdong" + "\r\n"
        + " where hd.status=1" + "\r\n"
        + " order by hd.idhopdong asc" + "\r\n";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        gidHopDong.DataSource = tb;
        gidHopDong.DataBind();
        if (gidHopDong.Rows.Count > 0)
            lbTongSoNV.Text = "Tìm thấy " + gidHopDong.Rows.Count + " Hợp Đồng trong danh sách";
        else
            lbTongSoNV.Text = "Không tìm thấy Hợp Đồng";
    }
    protected void setHopDong(DataTable dt)
    {
        if (dt.Rows.Count <= 0) return;
        txtidHopDong.Text = dt.Rows[0]["idhopdong"].ToString().Trim();
        txtChuyenMon.Text = dt.Rows[0]["chuyenmon"].ToString().Trim();
        ddlLoaiHopDong.SelectedValue = dt.Rows[0]["idloaihopdong"].ToString();
        txtGioLam.Text = dt.Rows[0]["giolam"].ToString();
        txtIdNhanVien.Value = dt.Rows[0]["idnhanvien"].ToString();
        txtMaHopDong.Text = dt.Rows[0]["masohopdong"].ToString();
        txtMoTaCongViec.Text = dt.Rows[0]["motacongviec"].ToString();
        txtMucLuongCoBan.Text = dt.Rows[0]["mucluongcoban"].ToString();
        txtNgayBatDau.Text = dt.Rows[0]["ngaybatdau"].ToString();
        txtNgayKetThuc.Text = dt.Rows[0]["ngayketthuc"].ToString();
        txtNgayKy.Text = dt.Rows[0]["ngayky"].ToString();
        txtNoiKy.Text = dt.Rows[0]["noiky"].ToString();        
        txtTenNhanVien.Value = dt.Rows[0]["tennhanvien"].ToString();        
        txtThuViecTuNgay.Text = dt.Rows[0]["ThuViecTuNgay"].ToString();
        txtThuViecDenNgay.Text = dt.Rows[0]["ThuViecDenNgay"].ToString();
        txtDiaDiemLamViec.Text = dt.Rows[0]["DiaDiemLamViec"].ToString();
        txtDungCu.Text = dt.Rows[0]["DungCuLamViec"].ToString();
        txtThoaThuanKhac.Text = dt.Rows[0]["ThoaThuanKhac"].ToString();
        txtSoHopDong.Text = dt.Rows[0]["SoHopDong"].ToString();
        txtHeSo.Text=dt.Rows[0]["HeSoLCB"].ToString(); 
        txtMucLuongCoBan.Text = dt.Rows[0]["luongCB"].ToString();

        if (dt.Rows[0]["CoBaoHiem"].ToString().Trim() == "1")
            cbCoBaoHiem.Checked = true;
        else
            cbCoBaoHiem.Checked = false;

        if (dt.Rows[0]["LoaiNhanVien"].ToString().Trim() != null && dt.Rows[0]["LoaiNhanVien"].ToString().Trim() != "")
            ddlLoaiNhanVien.SelectedValue = dt.Rows[0]["LoaiNhanVien"].ToString().Trim();
        txtTrinhDo.Text = dt.Rows[0]["trinhdo"].ToString(); 
        double TongLuongCoBan = StaticData.ParseFloat(dt.Rows[0]["HeSoLCB"]) * StaticData.ParseFloat(dt.Rows[0]["luongCB"]);
        TongLuongCoBan=Math.Round(TongLuongCoBan);
        txtTongLCB.Text = StaticData.FormatNumberOption(StaticData.ParseInt(TongLuongCoBan), ",", ".", false).ToString();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        txtidHopDong.Text = "";
        txtChuyenMon.Text = "";
        ddlLoaiHopDong.SelectedIndex= 0;
        ddlLoaiNhanVien.SelectedValue = "-1";
        txtGioLam.Text = "";
        txtIdNhanVien.Value = "";
        txtMaHopDong.Text = "";
        txtMoTaCongViec.Text = "";
        txtMucLuongCoBan.Text = "";
        txtNgayBatDau.Text = "";
        txtNgayKetThuc.Text = "";
        txtNgayKy.Text = "";
        txtNoiKy.Text = "";
        txtTenNhanVien.Value = "";
        txtThuViecTuNgay.Text = "";
        txtThuViecDenNgay.Text = "";
        txtDiaDiemLamViec.Text = "";
        txtDungCu.Text = "";
        txtThoaThuanKhac.Text = "";
        txtSoHopDong.Text = "";
        txtHeSo.Text ="";
        txtMucLuongCoBan.Text="";
        txtTrinhDo.Text = "";
        txtTongLCB.Text = "";
        cbCoBaoHiem.Checked = false;
    }
    protected void btnXoan_Click(object sender, EventArgs e)
    {
        NhanSu_Process.HopDong update = new NhanSu_Process.HopDong();
        update.idhopdong = txtidHopDong.Text.Trim();
        update.Update_status("0");
        bindGrid();
    }
    protected void bntTim_Click(object sender, EventArgs e)
    {
        string strS = ""
        + strSelect
        + " from hopdong hd" + "\r\n"
        + " left join nhanvien nv on nv.idnhanvien=hd.idnhanvien" + "\r\n"
        + " left join loaihopdong lhd on lhd.idloaihopdong=hd.idloaihopdong" + "\r\n"
        + " where hd.status=1" + "\r\n";
        if (ddlLoaiHopDong.SelectedIndex > 0) strS += " and hd.idloaihopdong = '" + ddlLoaiHopDong.SelectedValue + "'";
        if (ddlLoaiNhanVien.SelectedIndex > 0) strS += " and nv.loainhanvien = '" + ddlLoaiNhanVien.SelectedValue + "'";
        if (txtChuyenMon.Text.Trim() != "") strS += " and hd.chuyenmon=N'" + txtChuyenMon.Text.Trim() + "'";
        if (txtGioLam.Text.Trim() != "") strS += " and hd.giolam=N'" + txtGioLam.Text.Trim() + "'";
        if (txtMaHopDong.Text.Trim() != "") strS += " and hd.masohopdong='" + txtMaHopDong.Text.Trim() + "'";
        if (txtMoTaCongViec.Text.Trim() != "") strS += " and hd.motacongviec=N'" + txtMoTaCongViec.Text.Trim() + "'";
        if (txtMucLuongCoBan.Text.Trim() != "") strS += " and hd.luongcb=N'" + txtMucLuongCoBan.Text.Trim() + "'";
        if (txtNoiKy.Text.Trim() != "") strS += " and hd.noiky=N'" + txtNoiKy.Text.Trim() + "'";
        if (txtNgayBatDau.Text.Trim() != "") strS += " and hd.ngaybatdau ='" + StaticData.CheckDate(txtNgayBatDau.Text.Trim()) + "'";
        if (txtNgayKetThuc.Text.Trim() != "") strS += " and hd.ngayketthuc ='" + StaticData.CheckDate(txtNgayKetThuc.Text.Trim()) + "'";
        if (txtNgayKy.Text.Trim() != "") strS += " and hd.ngayky ='" + txtIdNhanVien.Value + "'";
        if (txtIdNhanVien.Value != "") strS += " and hd.idnhanvien ='" + StaticData.CheckDate(txtNgayKy.Text.Trim()) + "'";
        if (txtTrinhDo.Text.Trim() != "") strS += " and nv.trinhdo like N'" + txtTrinhDo.Text.Trim() + "'";
        if (txtSoHopDong.Text.Trim() != "") strS += " and hd.sohopdong like N'" + txtSoHopDong.Text.Trim() + "'";
        if (txtTenNhanVien.Value.Trim() != "") strS += " and nv.tennhanvien like N'" + txtTenNhanVien.Value.Trim() + "'";
        strS +=" order by hd.idhopdong desc" + "\r\n";
        DataTable tb = DataAcess.Connect.GetTable(strS);
        //if (tb.Rows.Count < 1) return;
        if (tb.Rows.Count == 1) 
        {
             gidHopDong.DataSource = tb; gidHopDong.DataBind(); 
        }
        else 
        {
            gidHopDong.DataSource = tb; gidHopDong.DataBind(); 
        }
        if (gidHopDong.Rows.Count > 0)
        {
            lbTongSoNV.Text = "Tìm thấy " + gidHopDong.Rows.Count + " Hợp Đồng trong danh sách";
            setHopDong(tb);
        }
        else
            lbTongSoNV.Text = "Không tìm thấy Hợp Đồng";
    }
    protected void gidHopDong_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = gidHopDong.DataKeys[e.NewSelectedIndex].Value.ToString();
        string strS = ""
       + strSelect
       + " from hopdong hd" + "\r\n"
       + " left join nhanvien nv on nv.idnhanvien=hd.idnhanvien" + "\r\n"
       + " left join loaihopdong lhd on lhd.idloaihopdong=hd.idloaihopdong" + "\r\n"
       + " where hd.status=1" + "\r\n";
        if (id!="") strS += " and hd.idhopdong = '" + id + "'";
        DataTable dt = DataAcess.Connect.GetTable(strS);        
        setHopDong(dt);
    }
    protected void gidHopDong_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NhanSu_Process.HopDong update = new NhanSu_Process.HopDong();
        update.idhopdong = gidHopDong.DataKeys[e.RowIndex].Value.ToString();
        update.Update_status("0");
        bindGrid();
    }
    protected void btnXemHopDong_Click(object sender, EventArgs e)
    {

        if (txtidHopDong.Text != "")
        {
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sdgnrt", "window.open('BanHopDong.aspx?idhopdong="+txtidHopDong.Text+");", true);
            string LinkName = "BanHopDong.aspx?idhopdong=" + txtidHopDong.Text;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "makhasdygygas", "window.open (\"" + LinkName + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
        }
        else
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InHopDon", "alert('Chưa chọn hợp đồng');", true);
    }
    protected void setAttribute()
    {
        txtNgayKy.Attributes.Add("onblur","kiemtrangay(this);");
        txtNgayBatDau.Attributes.Add("onblur", "kiemtrangay(this);");
        txtNgayKetThuc.Attributes.Add("onblur", "kiemtrangay(this);");
        txtThuViecTuNgay.Attributes.Add("onblur", "kiemtrangay(this);");
        txtThuViecDenNgay.Attributes.Add("onblur", "kiemtrangay(this);");
        txtGioLam.Attributes.Add("onblur", "isNumber(this);");
        txtMucLuongCoBan.Attributes.Add("onblur", "isNumber(this);TinhLuongCB();");
        txtHeSo.Attributes.Add("onblur", "isNumber(this);TinhLuongCB();");
        txtTongLCB.Attributes.Add("onblur", "isNumber(this);");
    }
    //TRUONGNHAT-PC
    //XUAT DU LIEU RA EXCEL
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string strS = ""
        + " select ROW_NUMBER ( ) OVER(ORDER BY hd.idhopdong) AS STT,hd.sohopdong,hd.masohopdong,lhd.tenloaihopdong,nv.tennhanvien ,case when nv.loaiNhanVien=0 then N'Thường xuyên' when nv.loaiNhanVien=1 then N'Không thường xuyên' end as Loai, "
        + " convert(varchar,hd.ngayky,103)as ngayky, "
        + " convert(varchar,hd.ngaybatdau,103)as ngaybatdau,convert(varchar,hd.ngayketthuc,103)as ngayketthuc ,hd.noiky,hd.chuyenmon,round(convert(real,hd.mucluongcoban),0) as mucluongcoban "
        + " ,hd.giolam,hd.motacongviec,pb.tenphongban , isnull(pb.tenphongban,'z')as sapxep "
        + " from hopdong hd" + "\r\n"
        + " left join nhanvien nv on nv.idnhanvien=hd.idnhanvien" + "\r\n"
        + " left join loaihopdong lhd on lhd.idloaihopdong=hd.idloaihopdong" + "\r\n"
        + " left join phongban pb on pb.idphongban=nv.idphongban " + "\r\n"
        + " where hd.status=1" + "\r\n";
        if (ddlLoaiHopDong.SelectedIndex > 0) strS += " and hd.idloaihopdong = '" + ddlLoaiHopDong.SelectedValue + "'";
        if (ddlLoaiNhanVien.SelectedIndex > 0) strS += " and nv.loainhanvien = '" + ddlLoaiNhanVien.SelectedValue + "'";
        if (txtChuyenMon.Text.Trim() != "") strS += " and hd.chuyenmon=N'" + txtChuyenMon.Text.Trim() + "'";
        if (txtGioLam.Text.Trim() != "") strS += " and hd.giolam=N'" + txtGioLam.Text.Trim() + "'";
        if (txtMaHopDong.Text.Trim() != "") strS += " and hd.masohopdong='" + txtMaHopDong.Text.Trim() + "'";
        if (txtMoTaCongViec.Text.Trim() != "") strS += " and hd.motacongviec=N'" + txtMoTaCongViec.Text.Trim() + "'";
        if (txtMucLuongCoBan.Text.Trim() != "") strS += " and hd.luongcb=N'" + txtMucLuongCoBan.Text.Trim() + "'";
        if (txtNoiKy.Text.Trim() != "") strS += " and hd.noiky=N'" + txtNoiKy.Text.Trim() + "'";
        if (txtNgayBatDau.Text.Trim() != "") strS += " and hd.ngaybatdau ='" + StaticData.CheckDate(txtNgayBatDau.Text.Trim()) + "'";
        if (txtNgayKetThuc.Text.Trim() != "") strS += " and hd.ngayketthuc ='" + StaticData.CheckDate(txtNgayKetThuc.Text.Trim()) + "'";
        if (txtNgayKy.Text.Trim() != "") strS += " and hd.ngayky ='" + txtIdNhanVien.Value + "'";
        if (txtIdNhanVien.Value != "") strS += " and hd.idnhanvien ='" + StaticData.CheckDate(txtNgayKy.Text.Trim()) + "'";
        if (txtTrinhDo.Text.Trim() != "") strS += " and nv.trinhdo like N'" + txtTrinhDo.Text.Trim() + "'";
        if (txtSoHopDong.Text.Trim() != "") strS += " and hd.sohopdong like N'" + txtSoHopDong.Text.Trim() + "'";
        if (txtTenNhanVien.Value.Trim() != "") strS += " and nv.tennhanvien like N'" + txtTenNhanVien.Value.Trim() + "'";
        strS += " order by sapxep asc" + "\r\n";
        dshd = new clsDanhSachHopDong();
        dshd.search = strS;
        dshd.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(DSHD_AfterExportToExcel);
        dshd.ExportToExcel();
    }
    void DSHD_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + dshd.OutputFileName + "\",'_blank')</script>");
    }
}

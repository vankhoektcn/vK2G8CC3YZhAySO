<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/layout.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.6.1.min.js" type="text/javascript"></script>

    <style type="text/css">
img{
    cursor: pointer;
}
</style>

    <script type="text/javascript">
        var  openWins = new Array();curWin = 0;
        $(document).ready(function() {
            $(document).keyup(function(event) {
                var key = event.keyCode || event.charCode || 0;
                if(1==1)
                {
                    if (key == 68) { 
                        window.location.href = $($('a[id$=lbLogin]')).attr("href");
                    }else if (key == 73) { 
                         $($('a[id$=lbnIndex]')).click();
                    }else if (key == 84) {           
                         $($('a[id$=lbnThuVienPhi]')).click();
                    }else if (key == 75) { 
                         $($('a[id$=lbnkhambenh]')).click();
                    }else if (key == 67) { 
                         $($('a[id$=lbnCLS]')).click();
                    }else if (key == 83) {            
                         $($('a[id$=lbnKhoaSan]')).click();
                    }else if (key == 85) {            
                         $($('a[id$=lbnCapCuu]')).click();
                    }else if (key == 82) { 
                         $($('a[id$=lbnNoiTru]')).click();
                    }else if (key == 65) { 
                         $($('a[id$=lbnKhoaPhauThuat]')).click();
                    }else if (key == 79) {
                         $($('a[id$=lbnKhoaDuoc]')).click();
                    }else if (key == 66) { 
                         $($('a[id$=lbnThuocBH]')).click();
                    }else if (key == 72) {
                         $($('a[id$=lbnHanhChinh]')).click();
                    }else if (key == 69) {
                         $($('a[id$=lbnKeToan]')).click();
                    }else if (key == 78) {
                         $($('a[id$=lbnNhanSu]')).click();
                    }else if (key == 71) {
                         $($('a[id$=lbnThongKe]')).click();
                    }else if (key == 77) {
                         $($('a[id$=GiamDinhBHYT]')).click();
                    }else if (key == 81) {
                         $($('a[id$=lbnQuanLyND]')).click();
                    }else if (key == 80) {
                         $($('a[id$=lbnChangePass]')).click();
                    }
                }
            });
                
        });
        function openlink(obj,link) {
                if($(obj).attr("disabled") == null && $(obj).attr("disabled") != false)
                    openWins[curWin++] = window.open(link,'_blank');
            }
        
        function openImgLink(objID,link) {
                if($("#"+objID).attr("disabled") == null && $("#"+objID).attr("disabled") != false)
                    openWins[curWin++] = window.open(link,'_blank');
            }
        function closeAll() {
            for(i=0; i<openWins.length; i++) if (openWins[i] && !openWins[i].closed)
            openWins[i].close();
        }   
    </script>

</head>
<body onunload="closeAll();">
    <form id="frmMain" runat="server">
    <div style="text-align:center;width:100%;">
    <div style="text-align:center;position:fixed;top:7%;left:0%;width:100%;color:Red;font-weight:bold;font-size:20px;" >
          <span style="text-align: center;color: #006600;font-weight: bold;font-size: 27px;font-family:Arial;">
                PHẦN MỀM QUẢN LÝ BỆNH VIỆN</span>  <br />
          <span style="text-align: center;color: red;font-weight: bold;font-size: 25px;font-family: cursive;">
                <%--<%= StaticData.TenCty %>--%></span> 
    </div>
    </div>
        <div id="divMain">
            <div id="art-l">
            </div>
            <div id="art-right">
            </div>
            <div id="art-main">
                <div class="menu middle">
                    <img id="imgLogin" runat="server" style="vertical-align: middle;" />
                    <a href="javascript:;" tabindex="0" id="lbLogin" runat="server"><u>Đ</u>ăng nhập</a>
                </div>
                <div class="clr menu">
                    <img src="images/receive.png" onclick="openImgLink('lbnIndex','TiepNhan/index.aspx');" />
                    <a href="javascript:;" tabindex="1" id="lbnIndex" onclick="openlink(this,'TiepNhan/index.aspx');">
                        T<u>i</u>ếp nhận</a>
                </div>
                <div class="menu">
                    <img src="images/money.png" onclick="openImgLink('lbnThuVienPhi','VienPhi_TH/index.aspx');" />
                    <a href="javascript:;" tabindex="2" id="lbnThuVienPhi" onclick="openlink(this,'VienPhi_TH/index.aspx');">
                        <u>T</u>hu phí</a>
                </div>
                <div class="menu">
                    <img src="images/doctor.png" onclick="openImgLink('lbnkhambenh','KhamBenh_TH/index.aspx');" />
                    <a href="javascript:;" tabindex="3" id="lbnkhambenh" onclick="openlink(this,'KhamBenh_TH/index.aspx');">
                        <u>K</u>hám bệnh</a>
                </div>
                <div class="menu">
                    <img src="images/test_tubes.png" onclick="openImgLink('lbnCLS','canlamsang/index.aspx');" />
                    <a href="javascript:;" tabindex="4" id="lbnCLS" onclick="openlink(this,'canlamsang/index.aspx');">
                        Xét nghiệm</a>
                </div>
                <div class=" clr menu">
                    <img src="images/khoasan.png" onclick="openImgLink('lbnKhoaSan','khoasan/PageHome_KhoaSan.aspx');" />
                    <a href="javascript:;" tabindex="5" id="lbnKhoaSan" onclick="openlink(this,'khoasan/PageHome_KhoaSan.aspx')">
                        Khoa <u>s</u>ản</a>
                </div>
                <div class="menu">
                    <img src="images/ambulance.png" onclick="openImgLink('lbnCapCuu','capcuu/index.aspx');" />
                    <a href="javascript:;" tabindex="6" id="lbnCapCuu" onclick="openlink(this,'capcuu/index.aspx')">
                        Cấp cứ<u>u</u></a>
                </div>
                <div class="menu">
                    <img src="images/pharmacy.png" onclick="openImgLink('lbnNoiTru','PageHome_NoiTru.aspx');" />
                    <a href="javascript:;" tabindex="7" id="lbnNoiTru" onclick="openlink(this,'PageHome_NoiTru.aspx')">
                        Khoa nội t<u>r</u>ú</a>
                </div>
                <div class="menu">
                    <img src="images/surgeon.png" onclick="openImgLink('lbnKhoaPhauThuat','KhoaPhauThuat/index.aspx');" />
                    <a href="javascript:;" tabindex="8" id="lbnKhoaPhauThuat" onclick="openlink(this,'KhoaPhauThuat/index.aspx')">
                        Kho<u>a</u> phẫu thuật</a>
                </div>
                <div class="menu">
                    <img src="images/medical_case.png" onclick="openImgLink('lbnKhoaDuoc','QLDUOC/Web/index.aspx?IsKhoaDuoc=1');" />
                    <a href="javascript:;" tabindex="9" id="lbnKhoaDuoc" onclick="openlink(this,'QLDUOC/Web/index.aspx?IsKhoaDuoc=1')">
                        Kh<u>o</u>a dược</a>
                </div>
                <div class="menu">
                    <img src="images/medical_pot_pills.png" onclick="openImgLink('lbnThuocBH','QLDUOC/Web/index.aspx?IsQPTBH=1');" />
                    <a href="javascript:;" tabindex="10" id="lbnThuocBH" onclick="openlink(this,'QLDUOC/Web/index.aspx?IsQPTBH=1')">
                        Quầy PT.<u>B</u>H.YT</a>
                </div>
                <div class="menu">
                    <img src="images/medical_pot_pills.png" onclick="openImgLink('lbnThuocDV','QLDUOC/Web/index.aspx?dkmenu=quayptdv&IsQPTDV=1');" />
                    <a href="javascript:;" tabindex="10" id="lbnThuocDV" onclick="openlink(this,'QLDUOC/Web/index.aspx?dkmenu=quayptdv&IsQPTDV=1')">
                        Quầy PT.<u>D</u>V</a>
                </div>
                <%--<div class="menu">
                    <img src="images/hanhchinh.png" onclick="openImgLink('lbnHanhChinh','KhoHCQT/index.aspx?dkmenu=KhoHCQT');" />
                    <a href="javascript:;" tabindex="11" id="lbnHanhChinh" onclick="openlink(this,'KhoHCQT/index.aspx?dkmenu=KhoHCQT')">
                        Kho <u>H</u>CQT</a>
                </div>
                <div class="menu">
                    <img src="images/accounting.png" onclick="openImgLink('lbnKeToan','<%=StaticData.KeToan_Link %>');" />
                    <a href="javascript:;" tabindex="12" id="lbnKeToan" onclick="openlink(this,'<%=StaticData.KeToan_Link %>')">
                        K<u>ế</u> toán</a>
                </div>
                <div class="menu">
                    <img src="images/users.png" onclick="openImgLink('lbnNhanSu','quanlynhansu/index.aspx');" />
                    <a href="javascript:;" tabindex="13" id="lbnNhanSu" onclick="openlink(this,'quanlynhansu/index.aspx')">
                        <u>N</u>hân sự</a>
                </div>--%>
                <div class="menu">
                    <img src="images/chart.png" onclick="openImgLink('lbnThongKe','ThongKe/index.aspx');" />
                    <a href="javascript:;" tabindex="14" id="lbnThongKe" onclick="openlink(this,'ThongKe/index.aspx')">
                        Thốn<u>g</u> kê</a>
                </div>
                <div class="menu">
                    <img src="images/giamdinh.png" onclick="openImgLink('GiamDinhBHYT','GiamDinhBHYT/index.aspx');" />
                    <a href="javascript:;" tabindex="15" id="GiamDinhBHYT" onclick="openlink(this,'GiamDinhBHYT/index.aspx')">
                        Giá<u>m</u> định BHYT</a>
                </div>
                <div class="menu">
                    <img src="images/user.png" onclick="openImgLink('lbnQuanLyND','danhmuc_json/index.aspx');" />
                    <a href="javascript:;" tabindex="16" id="lbnQuanLyND" onclick="openlink(this,'danhmuc_json/index.aspx')">
                        <u>Q</u>uản lý người dùng</a>
                </div>
                <div class="menu">
                    <img src="images/taikhoan.gif" onclick="openImgLink('lbSieuAm','SieuAm/index.aspx');" />
                    <a href="javascript:;" tabindex="18" id="lbSieuAm" onclick="openlink(this,'SieuAm/index.aspx')">
                        Siêu âm</a>
                </div>
                <div class="menu">
                    <img src="images/taikhoan.gif" onclick="openImgLink('lbXQuang','XQuang/index.aspx');" />
                    <a href="javascript:;" tabindex="18" id="lbXQuang" onclick="openlink(this,'XQuang/index.aspx')">
                        X Quang</a>
                </div>
                <div class="menu middle clr">
                    <img src="images/changepass.png" onclick="openImgLink('lbnChangePass','DanhMuc_Json/web/doimatkhau.aspx');" />
                    <a href="javascript:;" tabindex="17" id="lbnChangePass" onclick="openlink(this,'DanhMuc_Json/web/doimatkhau.aspx')">
                        Đổi mật khẩu</a>
                </div>
            </div>
            <div runat="Server" id="head">
            </div>
            <div id="copyright">
                <div id="copy-l">
                    <%= StaticData.TenPhanMem %>
                    -
                    <%= StaticData.TenCty %>
                    | Người dùng:
                    <%= (SysParameter.UserLogin.FullName(this)) %>
                </div>
                <div id="copy-r">
                    Phát triển bởi <a href="https://ketnoimoi.com/" target="_blank">Kết Nối Mới </a>
                    , Ltd.,Co
                </div>
            </div>
        </div>
    </form>
</body>
</html>

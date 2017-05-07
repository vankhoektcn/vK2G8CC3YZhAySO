<%@ Page Language="C#" MasterPageFile="~/VienPhi_TH/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmBangTheoDoiBN.aspx.cs" Inherits="VienPhi_TH_frmBangTheoDoiBN" Title="Bảng theo dõi công nợ bệnh nhân" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/bangtheodoibn.js"></script>

    <style type="text/css">
        .div-Out
        {
            width:270px!important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Bảng theo dõi công nợ bệnh nhân")%>
        </p>
        <div class="in-a">
            <input type="hidden" clearval="false" mkv="true" id="idchitietdangkykham" />
            <input type="hidden" clearval="false" mkv="true" id="idbenhnhan" />
            <input type="hidden" clearval="false" mkv="true" id="idkhambenh" />
            <input type="hidden" clearval="false" mkv="true" id="isnoitru" />
            <input type="hidden" clearval="false" mkv="true" id="isbhyt" />
            <h3>
                <span style="float: left;">1. Thông tin hành chính </span><span style="float: left;
                    padding-left: 200px;"><font color="#dd6666">Tìm kiếm theo họ tên, mã bệnh nhân , số
                        bhyt.</font></span>
            </h3>
            <div class="div-Out">
                <h4>
                    Mã bệnh nhân</h4>
                <p>
                    <input type="text" id="mabenhnhan" mkv="true" onfocus="chuyenphim(this);" /></p>
            </div>
            <div class="div-Out">
                <h4>
                    Tên bệnh nhân</h4>
                <p>
                    <input type="text" id="tenbenhnhan" mkv="true" onfocus="chuyenphim(this);" /></p>
            </div>
            <div class="div-Out">
                <h4>
                    Ngày sinh</h4>
                <p>
                    <input type="text" id="ngaysinh" mkv="true" onfocus="chuyenphim(this);$(this).validDate();" /></p>
            </div>
            <div class="div-Out">
                <h4>
                    Giới tính</h4>
                <p>
                    <select id="gioitinh" mkv="true">
                        <option value="0">Nam</option>
                        <option value="1">Nữ</option>
                    </select>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    Khám / Điều trị</h4>
                <p>
                    <input type="text" id="loaidieutri" mkv="true" onfocus="chuyenphim(this);" /></p>
            </div>
            <div class="div-Out">
                <h4>
                    Loại hình
                </h4>
                <p>
                    <input type="text" id="loaihinh" mkv="true" onfocus="chuyenphim(this);" /></p>
            </div>
            <div class="div-Out" style="width: 500px!important">
                <h4>
                    Số BHYT</h4>
                <p style="width: 78%">
                    <input mkv="true" id="sobhyt" type="text" onfocus="chuyenphim(this);" style="width: 200px;" />
                    <input type="button" id="Tim" value="Tìm kiếm" />
                    <input type="button" id="Moi" value="Làm mới" />
                </p>
            </div>
            <div style="clear: both;">
            </div>
            <h3>
                2. Danh sách phiếu thu - hoàn trả
            </h3>
            <div id="tableAjaxDsPhieuThuHoanTra">
            </div>
            <div class="div-set">
                <h3>
                    <a href="javascript:;" id="bangke01">3. Bảng kê 01 </a>
                </h3>
            </div>
            <div class="div-set">
                <h3>
                    <a href="javascript:;" id="bangke02">4. Bảng kê 02 </a>
                </h3>
            </div>
            <div class="div-set">
                <h3>
                    <a href="javascript:;" id="bangkedongchitra">5. Bảng kê đồng chi trả </a>
                </h3>
            </div>
            <div style="clear: both;">
            </div>
            <div class="div-box">
                <h3>
                    6. Phiếu chỉ định CLS
                </h3>
                <div id="tableAjaxPhieuChiDinhCLS">
                </div>
            </div>
            <div class="div-box">
                <h3>
                    7. Phiếu chỉ định DVKT
                </h3>
                <div id="tableAjaxPhieuChiDinhDVKT">
                </div>
            </div>
            <div class="div-box">
                <h3>
                    8. Toa thuốc
                </h3>
                <div id="tableAjaxToaThuoc">
                </div>
            </div>
            <h3>
                9. Chi tiết công nợ
            </h3>
            <div id="tableAjaxChitietCongNo">
            </div>
            
            
            
               <h3>
                <a href="javascript:;" id="chitietdangkykham">10. Chi tiết đăng ký khám </a>
            </h3>
            <h3>
                <a href="javascript:;" id="chitietphieuxuatkho">11. Chi tiết phiếu xuất kho</a>
            </h3>
              <h3>
                <a href="javascript:;" id="chitietcanlamsang">12. Chi tiết cận lâm sàng-dvkt</a>
            </h3>
              <h3>
                <a href="javascript:;" id="chitiettiengiuong">13. Chi tiết tiền giường</a>
            </h3>
            
             <h3>
                <a href="javascript:;" id="tinhlaitien">14. Tính lại tiền</a>
            </h3>
            
            
            
            <div style="clear: both;">
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="MasterPageBNNV.master" AutoEventWireup="true"
    CodeFile="frmDangKyCLS.aspx.cs" Inherits="TiepNhan_frmDangKyCLS" Title="DANG KY CLS - DICH VU KY THUAT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/dangkycls.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <div class="header-div">
            Đăng ký cận lâm sàng
        </div>
        <div class="in-a">
            <input mkv="true" clearval="false" type="hidden" id="maphieucls" />
            <input mkv="true" clearval="false" type="hidden" id="iddangkycls" />
            <input mkv="true" clearval="false" type="hidden" id="idbenhnhan" />
            <input mkv="true" clearval="false" type="hidden" id="IsDKK" />
            <fieldset>
                <legend>Thông tin bệnh nhân</legend>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên bệnh nhân")%>
                    </h4>
                    <p>
                        <input type="text" mkv="true" id="tenbenhnhan" disabled="disabled" />
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã bệnh nhân")%>
                    </h4>
                    <p>
                        <input type="text" mkv="true" id="mabenhnhan" disabled="disabled" />
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày sinh")%>
                    </h4>
                    <p>
                        <input type="text" mkv="true" id="ngaysinh" disabled="disabled" />
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Giới tính")%>
                    </h4>
                    <p>
                        <select id="gioitinh" mkv="true">
                            <option value="0">Nam </option>
                            <option value="1">Nữ</option>
                        </select>
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Địa chỉ")%>
                    </h4>
                    <p>
                        <input type="text" mkv="true" id="diachi" disabled="disabled" />
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Điện thoại")%>
                    </h4>
                    <p>
                        <input type="text" mkv="true" id="dienthoai" disabled="disabled" />
                    </p>
                </div>
            </fieldset>
            <fieldset id="thongtindangky">
                <legend>Thông tin đăng ký</legend>
               
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Người tiếp nhận")%>
                    </h4>
                    <p>
                        <select mkv="true" id="idnguoidung" style="width:95%">
                        </select>
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày đăng ký")%>
                    </h4>
                    <p>
                        <input type="text" mkv="true" id="ngaythu" style="width: 60%;" onfocus="chuyenphim(this);$(this).datepick();" />
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Chiết khấu")%>
                    </h4>
                    <p>
                        <input type="text" mkv="true" id="chietkhau" />
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Khoa đăng ký")%>
                    </h4>
                    <p>
                        <select id="idkhoadangky" mkv="true">
                        </select>
                    </p>
                </div>
                <div class="div-Out">
                    <h4>
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Bác sĩ đăng ký")%>
                    </h4>
                    <p>
                        <select id="idbacsi" mkv="true">
                        </select>
                    </p>
                </div>
            </fieldset>
            <div style="clear: both; padding: 5px;">
            </div>
            <fieldset>
                <legend>
                    <input type="button" value="Chọn cận lâm sàng" id="choncls" onclick="ChonCLS(this,null,null,'cls');" />
                    <input type="button" value="Cận lâm sàng thường quy" id="canlamsangthuongquy" onclick="ChoncanlamsangThuongquy(this);" />
                    </legend>
                <div id="tableAjax_khambenhcanlamsan" class="in-b">
                </div>
            </fieldset>
        </div>
    </div>
    <div class="body-div-button">
        <div class="in-a">
            <input type="button" value="Đăng ký" id="dangky" />
            <input type="button" value="Làm mới" id="moi" />
        </div>
    </div>
</asp:Content>

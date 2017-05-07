﻿<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="HS_BangGiaThuoc_Edit.aspx.cs" Inherits="HS_BangGiaThuoc_Edit" Title="HS_BangGiaThuoc_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/HS_BangGiaThuoc_Edit.js">
    </script>

    <style>
    .div-Out
    {
        width:290px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Cập nhật BẢNG GIÁ")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="tungay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="denngay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho")%>
                </h4>
                <p>
                    <input mkv="true" id="IDKHO_NHAP" type="hidden" />
                    ,
                    <input mkv="true" id="mkv_IDKHO_NHAP" type="text" onfocus="Find(this);chuyenphim(this);idkhoSearch(this);"
                        class="down_select" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="IdLoaiThuoc" type="hidden" />
                    <input mkv="true" id="mkv_IdLoaiThuoc" type="text" onfocus="Find(this);chuyenphim(this);IdLoaiThuocSearch(this);"
                        class="down_select" />
                </p>
            </div>
            <div class="div-Out" style="width:40%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TenThuoc")%>
                </h4>
                <p style="width:80.2%;">
                    <input mkv="true" id="IDTHUOC" type="hidden" />
                    <input mkv="true" id="mkv_IDTHUOC" type="text" onfocus="Find(this);chuyenphim(this);IDTHUOCSearch(this);" style="width:90%;"
                        class="down_select" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    (Định dạng ngày tháng: dd/MM/yyyy)
                </h4>
            </div>
        </div>
        <div class="body-div-button">
            <p class="in-a">
                <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
                <input id="timKiem" search="<%=StaticData.HavePermision(this, "chitietphieunhapkho_Search") %>"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                <input id="btnXuatExel" search="<%=StaticData.HavePermision(this, "thuoc_Search") %>"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Xuất Excel") %>" />
                <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
            </p>
            <div class="in-b" id="tableAjax_chitietphieunhapkho">
            </div>
        </div>
    </div>
</asp:Content>

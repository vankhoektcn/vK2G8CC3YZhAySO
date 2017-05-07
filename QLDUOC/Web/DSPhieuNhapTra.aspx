﻿<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="DSPhieuNhapTra.aspx.cs" Inherits="DSPhieuNhapTra" Title="DSPhieuNhapTra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/DSPhieuNhapTra.js">
    </script>

    <style>
    .div-Out
    {
        width:350px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH PHIẾU NHẬP TRẢ")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="TuNgay" type="text" onfocus="Find(this);chuyenphim(this);"
                        onblur="TestDate(this);"  />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaythang" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("maphieunhap")%>
                </h4>
                <p>
                    <input mkv="true" id="maphieunhap" type="text" onfocus="Find(this);chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SOPHIEUYC")%>
                </h4>
                <p>
                    <input mkv="true" id="SOPHIEUYC" type="text" onfocus="Find(this);chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out" id="divLoaiThuoc">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loaithuocid")%>
                </h4>
                <p>
                    <input mkv="false" id="loaithuocid" type="hidden" />
                    <input mkv="false" id="mkv_loaithuocid" type="text" onfocus="Find(this);chuyenphim(this);loaithuocidSearch(this);"
                        class="down_select" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <input id="timKiem" search="<%=StaticData.HavePermision(this, "phieunhapkho_Search") %>"
                        type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </h4>
                <p>
                    <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
                </p>
            </div>
        </div>
        <div class="in-b" id="tableAjax_phieunhapkho">
        </div>
    </div>
</asp:Content>

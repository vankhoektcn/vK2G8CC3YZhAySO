<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="phieuxuatkho_traNCC3.aspx.cs" Inherits="phieuxuatkho_traNCC3" Title="phieuxuatkho_traNCC3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/phieuxuatkho_traNCC3.js">
    </script>

    <style type="text/css">
        .div-Out
        {
            width: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PHIẾU XUẤT TRẢ NHÀ CUNG CẤP")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat")%>
                </h4>
                <p>
                    <input mkv="true" id="maphieuxuat" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaythang" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu")%>
                </h4>
                <p>
                    <input mkv="true" id="ghichu" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idnhacungcap")%>
                </h4>
                <p>
                    <input mkv="true" id="idnhacungcap" type="hidden" />
                    <input mkv="true" id="mkv_idnhacungcap" type="text" onfocus="Find(this);chuyenphim(this);idnhacungcapSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="IdLoaiThuoc" type="hidden" />
                    <input mkv="true" id="mkv_IdLoaiThuoc" type="text" onfocus="Find(this);chuyenphim(this);IdLoaiThuocSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nguoinhan")%>
                </h4>
                <p>
                    <input mkv="true" id="nguoinhan" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxchitietphieuxuatkho($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_chitietphieuxuatkho" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "phieuxuatkho_Edit") %>"
                add="<%=StaticData.HavePermision(this, "phieuxuatkho_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "phieuxuatkho_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "phieuxuatkho_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
            <input id="ViewDetail" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Detail") %>" />
            <input id="btnPrint" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Print") %>" />
            <input id="btnPrintBienBan" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("In biên bảng") %>" />
        </p>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="phieuxuatkho_HV1.aspx.cs" Inherits="phieuxuatkho_HV1" Title="phieuxuatkho_HV1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/phieuxuatkho_HV1.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH PHIẾU THANH LÝ")%>
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
            <div class="div-Out" style="width: 25%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p style="width: 51%;">
                    <input mkv="true" id="tungay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 80%" />
                </p>
            </div>
            <div class="div-Out" style="width: 25%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p style="width: 55%;">
                    <input mkv="true" id="denngay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 80%" />
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho")%>
                </h4>
                <p>
                    <input type="hidden" id="idkho" mkv="true" />
                    <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);idkhoSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
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
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_phieuxuatkho" style="top: 0px;">
        </div>
    </div>
</asp:Content>

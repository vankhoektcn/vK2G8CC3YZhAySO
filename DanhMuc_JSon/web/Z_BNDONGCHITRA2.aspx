<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="Z_BNDONGCHITRA2.aspx.cs" Inherits="Z_BNDONGCHITRA" Title="BẢNG KÊ CHI PHÍ THANH TOÁN RA VIỆN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/Z_BNDONGCHITRA2.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BẢNG KÊ CHI PHÍ THANH TOÁN RA VIỆN")%>
        </p>
        <div class="in-a">
            <div class="div-Out" style="width: 23%; padding: 0;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MABENHNHAN")%>
                </h4>
                <p style="width: 50%">
                    <input mkv="true" id="MABENHNHAN" type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 29%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENBENHNHAN")%>
                </h4>
                <p style="width: 60%">
                    <input mkv="true" id="TENBENHNHAN" type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 16%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
                </h4>
                <p style="width: 58%; border: none;">
                    <input mkv="true" id="tungay" type="text" style="width: 85%" onfocus="$(this).validDate();$(this).datepick();" />
                </p>
            </div>
            <div class="div-Out" style="width: 25%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
                </h4>
                <p style="width: 75%; border: none;">
                    <input mkv="true" id="denngay" type="text" style="width: 45%" onfocus="$(this).validDate();$(this).datepick();" />
                    <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button" style="margin: 0; padding: 0; width: 100%; border: 1px solid #999;
        border-top: none;">
        <div class="in-b" id="tableAjax_Z_BNDONGCHITRA" style="top: 0;">
        </div>
    </div>
</asp:Content>

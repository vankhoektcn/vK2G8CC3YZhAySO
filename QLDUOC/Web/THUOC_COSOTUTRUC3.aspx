<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="THUOC_COSOTUTRUC3.aspx.cs" Inherits="THUOC_COSOTUTRUC" Title="Danh mục vật tư và hóa chất" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/THUOC_COSOTUTRUC3.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH MỤC VẬT TƯ VÀ HÓA CHẤT")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKho")%>
                </h4>
                <p>
                    <select mkv="true" id="IdKho" style="width:90%;"></select>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID")%>
                </h4>
                <p>
                    <select mkv="true" id="LoaiThuocID" style="width:90%;"></select>
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxTHUOC_COSOTUTRUC_CHITIET($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_THUOC_COSOTUTRUC_CHITIET" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "THUOC_COSOTUTRUC_Edit") %>"
                add="<%=StaticData.HavePermision(this, "THUOC_COSOTUTRUC_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "THUOC_COSOTUTRUC_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "THUOC_COSOTUTRUC_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
    </div>
</asp:Content>

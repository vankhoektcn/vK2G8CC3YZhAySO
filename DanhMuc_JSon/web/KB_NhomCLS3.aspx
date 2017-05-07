<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="KB_NhomCLS3.aspx.cs" Inherits="KB_NhomCLS" Title="KB_NhomCLS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/KB_NhomCLS3.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("KB_NhomCLS")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TenNhom")%>
                </h4>
                <p>
                    <input mkv="true" id="TenNhom" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu")%>
                </h4>
                <p>
                    <input mkv="true" id="GhiChu" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
           
        </div>
        <a class="reload" onclick="loadTableAjaxKB_ChiTietNhomCLS($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_KB_ChiTietNhomCLS" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "KB_NhomCLS_Edit") %>"
                add="<%=StaticData.HavePermision(this, "KB_NhomCLS_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "KB_NhomCLS_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "KB_NhomCLS_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
    </div>
</asp:Content>

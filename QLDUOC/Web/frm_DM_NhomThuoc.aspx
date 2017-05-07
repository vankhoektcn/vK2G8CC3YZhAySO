<%@ Page Language="C#" MasterPageFile="../MasterPage_new.master" AutoEventWireup="true"
    CodeFile="frm_DM_NhomThuoc.aspx.cs" Inherits="frm_DM_NhomThuoc" Title="category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/frm_DM_NhomThuoc.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <p>
    </p>
    <div class="body-div">
        <div class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("category")%>
        </div>
        <div class="in-a">
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("catename")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="catename" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("des")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="des" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loaithuocid")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="loaithuocid" type="hidden" />
                    <input mkv="true" id="mkv_loaithuocid" type="text" onfocus="Find(this);chuyenphim(this);loaithuocidSearch(this);"
                        class="down_select" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoTT")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="SoTT" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);"
                        style="width: 90%" />
                </div>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <div class="in-a">
            <input id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </div>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_category">
        </div>
    </div>
</asp:Content>

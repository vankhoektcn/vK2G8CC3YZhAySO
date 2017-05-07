<%@ Page Language="C#" MasterPageFile="../MasterPage_new.master" AutoEventWireup="true"
    CodeFile="frm_DM_PhanNhom.aspx.cs" Inherits="nhomthuoc" Title="nhomthuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/frm_DM_PhanNhom1.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p>
        </p>
        <div class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nhomthuoc")%>
        </div>
        <div class="in-a">
            <div class="div-Out">
                <div class="div-Left">
                </div>
                <div class="div-Right">
                    <input mkv="true" id="loaithuocid" type="hidden" />
                    <input mkv="true" id="mkv_loaithuocid" type="text" onfocus="Find(this);chuyenphim(this);loaithuocidSearch(this);"
                        class="down_select" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cateid")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="cateid" type="hidden" />
                    <input mkv="true" id="mkv_cateid" type="text" onfocus="Find(this);chuyenphim(this);cateidSearch(this);"
                        class="down_select" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("manhom")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="manhom" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tennhom")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="tennhom" type="text" onfocus="Find(this);chuyenphim(this);"
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
        <div class="in-b" id="tableAjax_nhomthuoc">
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="../MasterPage_new.master" AutoEventWireup="true"
    CodeFile="frm_DM_CachDung.aspx.cs" Inherits="frm_DM_CachDung" Title="frm_CachDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/frm_DM_CachDung.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p>
        </p>
        <div class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thuoc_CachDung")%>
        </div>
        <div class="in-a">
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tencachdung")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="tencachdung" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </div>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <div class="in-a">
            <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
            <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </div>
        <p>
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_Thuoc_CachDung">
        </div>
        <div class="in-c">
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
        </div>
    </div>
</asp:Content>

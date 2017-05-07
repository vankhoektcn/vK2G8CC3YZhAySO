<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="nhacungcap2.aspx.cs" Inherits="nhacungcap" Title="nhacungcap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/nhacungcap2.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nhacungcap")%>
        </p>
        <div class="in-a">
            <div class="div-Out" style="width: 580px">
                <div>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tennhacungcap")%>
                    <input mkv="true" id="tennhacungcap" type="text" onfocus="Find(this);" style="width: 50%" />
                    <input id="timKiem" search="<%=true%>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                    <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
                </div>
            </div>
        </div>
        <div class="body-div-button">
            <p class="in-a">
                <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            </p>
        </div>
        <div class="in-b" id="tableAjax_nhacungcap">
        </div>
        <div align="center">
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
        </div>
    </div>
</asp:Content>

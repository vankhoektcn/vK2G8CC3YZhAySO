<%@ Page Language="C#" MasterPageFile="../MasterPage_new.master" AutoEventWireup="true"
    CodeFile="frm_DM_NuocSX.aspx.cs" Inherits="NuocSX" Title="NuocSX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/frm_DM_NuocSX2.js">
    </script>

    <style type="text/css">
    .div-Out
    {
        width:290px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <p>
    </p>
    <div class="body-div">
        <div class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NuocSX")%>
        </div>
        <div class="in-a">
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("maNuocSX")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="maNuocSX" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out" style="width: 550px;">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenNuocSX")%>
                </div>
                <div class="div-Right" style="width: 80%">
                    <input mkv="true" id="tenNuocSX" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 50%" />
                    <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
                    <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </div>
            </div>
        </div>
        <div style="position: absolute; right: 5%; bottom: 3.7%">
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
        </div>
        <div class="in-b" id="tableAjax_NuocSX">
        </div>
    </div>
</asp:Content>

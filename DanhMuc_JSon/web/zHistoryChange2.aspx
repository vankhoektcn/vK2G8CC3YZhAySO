<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="zHistoryChange2.aspx.cs" Inherits="zHistoryChange" Title="zHistoryChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/zHistoryChange2.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("zHistoryChange")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TableName")%>
                </h4>
                <p>
                    <input mkv="true" id="TableName" type="text" onfocus='Find(this);' style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SaveDate")%>
                </h4>
                <p>
                    <input mkv="true" id="SaveDate" type="text" onfocus='Find(this);' onblur="TestDate(this);"
                        style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "zHistoryChange_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_zHistoryChange">
        </div>
    </div>
</asp:Content>

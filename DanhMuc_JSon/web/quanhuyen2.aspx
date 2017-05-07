<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="quanhuyen2.aspx.cs" Inherits="quanhuyen" Title="quanhuyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/quanhuyen2.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("quanhuyen")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tinhid")%>
                </h4>
                <p>
                    <input mkv="true" id="tinhid" type="text" onfocus='Find(this);' onblur="TestSo(this,false,true);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("quanhuyenname")%>
                </h4>
                <p>
                    <input mkv="true" id="quanhuyenname" type="text" onfocus='Find(this);' style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MaQuanHuyen")%>
                </h4>
                <p>
                    <input mkv="true" id="MaQuanHuyen" type="text" onfocus='Find(this);' style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "quanhuyen_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_quanhuyen">
        </div>
        <p class="in-c">
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
        </p>
    </div>
</asp:Content>

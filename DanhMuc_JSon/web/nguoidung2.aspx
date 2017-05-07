<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="nguoidung2.aspx.cs" Inherits="nguoidung" Title="nguoidung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/nguoidung2.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nguoidung")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tennguoidung")%>
                </h4>
                <p>
                    <input mkv="true" id="tennguoidung" type="text" onfocus='Find(this);' style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("username")%>
                </h4>
                <p>
                    <input mkv="true" id="username" type="text" onfocus='Find(this);' style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nhomID")%>
                </h4>
                <p>
                    <input mkv="true" id="nhomID" type="hidden" />
                    <input mkv="true" id="mkv_nhomID" type="text" onfocus="Find(this);nhomIDSearch2(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luuTable_1" type="button" edit="<%=StaticData.HavePermision(this, "nguoidung_Edit") %>" add="<%=StaticData.HavePermision(this, "nguoidung_Add") %>" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "nguoidung_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_nguoidung">
        </div>
        <p class="in-c">
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' edit="<%=StaticData.HavePermision(this, "nguoidung_Edit") %>" add="<%=StaticData.HavePermision(this, "nguoidung_Add") %>" />
        </p>
    </div>
</asp:Content>

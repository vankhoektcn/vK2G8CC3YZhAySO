<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="thuoc2.aspx.cs" Inherits="thuoc" Title="thuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/thuoc2.js">
    </script>

    <style type="text/css">
        .div-Out
        {
            width:45%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phân bổ thuốc bảo hiểm")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CateID")%>
                </h4>
                <p>
                    <input mkv="true" id="CateID" type="hidden" />
                    <input mkv="true" id="mkv_CateID" type="text" onfocus="Find(this);chuyenphim(this);CateIDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idnhomthuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="idnhomthuoc" type="hidden" />
                    <input mkv="true" id="mkv_idnhomthuoc" type="text" onfocus="Find(this);chuyenphim(this);IDNHOMTHUOCSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="tenthuoc" type="text" onfocus='Find(this);TenThuocSearch(this);'
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("congthuc")%>
                </h4>
                <p>
                    <input mkv="true" id="congthuc" type="text" onfocus='Find(this);' style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="timKiem" search="<%=Userlogin_new.HavePermision(this, "thuoc_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
        </p>
        <div class="in-b" id="tableAjax_thuoc">
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="KB_Giuong2.aspx.cs" Inherits="KB_Giuong" Title="KB_Giuong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/KB_Giuong2.js">
    </script>

    <style type="text/css">
        .div-Out
        {
            border:none;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("KB_Giuong")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkhoa")%>
                </h4>
                <p>
                    <input mkv="true" id="IdKhoa" type="hidden" />
                    <input mkv="true" id="mkv_IdKhoa" type="text" onfocus="Find(this);IdKhoaSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idPhong")%>
                </h4>
                <p>
                    <input mkv="true" id="idPhong" type="hidden" />
                    <input mkv="true" id="mkv_idPhong" type="text" onfocus="Find(this);idPhongSearch1(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên giường")%>
                </h4>
                <p>
                    <input mkv="true" id="GiuongCode" type="text" onfocus="Find(this);" style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "KB_Giuong_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <div class="in-b" id="tableAjax_KB_Giuong">
        </div>
    </div>
</asp:Content>

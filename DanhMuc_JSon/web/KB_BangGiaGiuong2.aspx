<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="KB_BangGiaGiuong2.aspx.cs" Inherits="KB_BangGiaGiuong" Title="KB_BangGiaGiuong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/KB_BangGiaGiuong2.js">
    </script>

    <style type="text/css">
        .div-Out
        {
            width:270px;
            border:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("KB_BangGiaGiuong")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoa")%>
                </h4>
                <p>
                    <input mkv="true" id="IdKhoa" type="hidden" />
                    <input mkv="true" id="mkv_IdKhoa" type="text" onfocus="Find(this);IdKhoaSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="TuNgay" type="text" onfocus='Find(this);' onblur="TestDate(this);"
                        style="width: 80%" />
                </p>
            </div>
            <div class="div-Out" style="width: 500px;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LanThu")%>
                </h4>
                <p style="width: 80%;">
                    <select id="LANID" mkv="true">
                    </select>
                    &nbsp;&nbsp;
                    <input id="timKiem" value="Lấy DS" type="button" />
                    &nbsp;&nbsp;
                    <input id="COPY" type="button" value="Copy giá" />
                   
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_KB_BangGiaGiuong">
        </div>
        <p class="in-c">
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>' />
        </p>
    </div>
</asp:Content>

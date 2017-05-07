<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="THUOC_YEUCAUTRAHONGVO1.aspx.cs" Inherits="THUOC_YEUCAUTRAHONGVO" Title="THUOC_YEUCAUTRAHONGVO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/THUOC_YEUCAUTRAHONGVO1.js">
    </script>

    <style type="text/css">
        .div-Out
        {
            width: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Duyệt nhận yêu cầu hỏng vỡ")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày YC từ")%>
                </h4>
                <p>
                    <input mkv="true" id="tungay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến")%>
                </h4>
                <p>
                    <input mkv="true" id="denngay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoYeuCau")%>
                </h4>
                <p>
                    <input mkv="true" id="SoYeuCau" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoYeuCau")%>
                </h4>
                <p>
                    <input mkv="true" id="IdKhoYeuCau" type="hidden" />
                    <input mkv="true" id="mkv_IdKhoYeuCau" type="text" onfocus="Find(this);chuyenphim(this);IdKhoYeuCauSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoNhanTra")%>
                </h4>
                <p>
                    <input mkv="true" id="IdKhoNhanTra" type="hidden" />
                    <input mkv="true" id="mkv_IdKhoNhanTra" type="text" onfocus="Find(this);chuyenphim(this);IdKhoNhanTraSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày duyệt")%>
                </h4>
                <p>
                    <input mkv="true" id="ngayduyet" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    <input mkv="true" id="gioduyet" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        style="width: 10%" />
                    :
                    <input mkv="true" id="phutduyet" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        style="width: 10%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Edit") %>"
                add="<%=StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " style="display: none;" />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_THUOC_YEUCAUTRAHONGVO" style="top: 0px;">
        </div>
    </div>
</asp:Content>

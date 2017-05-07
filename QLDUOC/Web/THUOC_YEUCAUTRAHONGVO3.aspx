<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="THUOC_YEUCAUTRAHONGVO3.aspx.cs" Inherits="THUOC_YEUCAUTRAHONGVO" Title="THUOC_YEUCAUTRAHONGVO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/THUOC_YEUCAUTRAHONGVO3.js">
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
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("THUOC_YEUCAUTRAHONGVO")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayYeuCau")%>
                </h4>
                <p>
                    <input mkv="true" id="NgayYeuCau" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoYeuCau")%>
                </h4>
                <p>
                    <input mkv="true" id="SoYeuCau" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%;" />
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdNguoiYeuCau")%>
                </h4>
                <p>
                    <input mkv="true" id="IdNguoiYeuCau" type="hidden" />
                    <input mkv="true" id="mkv_IdNguoiYeuCau" type="text" onfocus="Find(this);chuyenphim(this);IdNguoiYeuCauSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" id="ngayduyet">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày duyệt YC")%>
                </h4>
                <p>
                    <input mkv="true" id="ngayduyetyc" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxTHUOC_YEUCAUTRAHONGVO_CHITIET($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_THUOC_YEUCAUTRAHONGVO_CHITIET" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Edit") %>"
                add="<%=StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "THUOC_YEUCAUTRAHONGVO_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
            <input id="printBienBan" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("In phiếu yêu cầu") %>"
                style="width: 10%;" />
            <input id="DUYETYC" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Duyệt nhận yêu cầu") %>"
                style="width: 15%;" />
        </p>
    </div>
</asp:Content>

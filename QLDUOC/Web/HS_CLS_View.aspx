<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="HS_CLS_View.aspx.cs" Inherits="HS_CLS_View" Title="HS_CLS_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/HS_CLS_View1.js">
    </script>
    <style type="text/css">
        .div-Out
        {
            width:44%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày, đến ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="TuNgay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 42%" />
                    ,
                    <input mkv="true" id="DenNgay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 42%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã BN, Số BHYT")%>
                </h4>
                <p>
                    <input mkv="true" id="MaBN" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 39%" />
                    ,
                    <input mkv="true" id="SoBHYT" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 49%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("HoTenBN")%>
                </h4>
                <p>
                    <input mkv="true" id="HoTenBN" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
                    <input id="timKiem" search="<%=StaticData.HavePermision(this, "HS_CLS_View_Search") %>"
                        type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Lấy DS") %>" />
                </h4>
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Định dạng ngày tháng: dd/mm/yyyy)
                </p>
            </div>
        </div>
    </div>
    <div class="in-b" id="tableAjax_HS_CLS_View">
    </div>
</asp:Content>

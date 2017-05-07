<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="HS_CLS_View3.aspx.cs" Inherits="HS_CLS_View" Title="HS_CLS_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/HS_CLS_View3.js">
    </script>

    <style type="text/css">
    .div-Out
    {
        width:30%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CHI TIẾT DỊCH VỤ BỆNH NHÂN")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayToa")%>
                </h4>
                <p>
                    <input mkv="true" id="NgayToa" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MaBN")%>
                </h4>
                <p>
                    <input mkv="true" id="MaBN" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 90%" />
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgaySinh")%>
                </h4>
                <p>
                    <input mkv="true" id="NgaySinh" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    <input mkv="true" id="GioiTinh" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 35%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoBHYT")%>
                </h4>
                <p>
                    <input mkv="true" id="SoBHYT" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 50%" />
                    Đúng tuyến ?<input mkv="true" id="DungTuyen" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BNTra")%>
                </h4>
                <p>
                    <input mkv="true" id="BNTra" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);"
                        style="width: 90%" />
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxHS_CLS_ViewDetail($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_HS_CLS_ViewDetail" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "HS_CLS_View_Delete") %>"
                type="button" style="display: none;width:130px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Bỏ Kiểm tra") %>" />
            <input id="PhatThuoc" search="<%=StaticData.HavePermision(this, "HS_CLS_View_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đồng ý") %>" />
            <input id="InBV01" search="<%=StaticData.HavePermision(this, "HS_CLS_View_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("In BV01") %>" />
        </p>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="HS_BANGGIATHUOC3.aspx.cs" Inherits="HS_BANGGIATHUOC" Title="HS_BANGGIATHUOC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/HS_BANGGIATHUOC3.js">
    </script>

    <style>
        .div-Out
        {
            width: 325px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("HS_BANGGIATHUOC")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="TuNgay" type="text" onfocus="Find(this);chuyenphim(this);$(this).validDate();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd/MM/yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="DenNgay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();$(this).validDate();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd/MM/yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LanThu")%>
                </h4>
                <p>
                    <input mkv="true" id="LanThu" type="text" onfocus="Find(this);chuyenphim(this);"
                        onblur="TestSo(this,false,true);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID")%>
                </h4>
                <p>
                    <input mkv="true" id="LoaiThuocID" type="hidden" />
                    <input mkv="true" id="mkv_LoaiThuocID" type="text" onfocus="Find(this);chuyenphim(this);LoaiThuocIDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sudungchobh")%>
                </h4>
                <p>
                    <input mkv="true" id="ISBHYT" type="checkbox" />
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxHS_BANGGIATHUOC_DETAIL($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_HS_BANGGIATHUOC_DETAIL" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_Edit") %>"
                add="<%=Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=Userlogin_new.HavePermision(this, "HS_BANGGIATHUOC_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
    </div>
</asp:Content>

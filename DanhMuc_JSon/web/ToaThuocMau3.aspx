<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="ToaThuocMau3.aspx.cs" Inherits="ToaThuocMau" Title="ToaThuocMau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/ToaThuocMau3.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ToaThuocMau")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TenToaThuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="TenToaThuoc" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdChanDoan")%>
                </h4>
                <p>
                    <input mkv="true" id="IdChanDoan" type="hidden" />
                    <input mkv="true" id="mkv_IdChanDoan" type="text" onfocus="Find(this);IdChanDoanSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Songay")%>
                </h4>
                <p>
                    <input mkv="true" id="Songay" type="text" onfocus='Find(this);' onblur="TestSo(this,false,true);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdNguoiDung")%>
                </h4>
                <p>
                    <input mkv="true" id="IdNguoiDung" type="hidden" />
                    <input mkv="true" id="mkv_IdNguoiDung" type="text" onfocus="Find(this);IdNguoiDungSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxToaThuocMauChiTiet($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_ToaThuocMauChiTiet" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "ToaThuocMau_Edit") %>"
                add="<%=StaticData.HavePermision(this, "ToaThuocMau_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "ToaThuocMau_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "ToaThuocMau_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
        </p>
    </div>
</asp:Content>

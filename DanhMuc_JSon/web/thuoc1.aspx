<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="thuoc1.aspx.cs" Inherits="thuoc" Title="thuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/thuoc1.js">
    </script>

    <style>
        .div-Out
        {
            width: 250px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH MỤC THUỐC NGOÀI BỆNH VIỆN")%>
        </p>
        <div class="in-a">
            <div class="div-Out" style="width: 92%!important;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CateID")%>
                </h4>
                <p style="width: 84%!important;">
                    <input mkv="true" id="CateID" type="hidden" />
                    <input mkv="true" id="mkv_CateID" type="text" onfocus="Find(this);chuyenphim(this);CateIDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 92%!important;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idnhomthuoc")%>
                </h4>
                <p style="width: 84%!important;">
                    <input mkv="true" id="idnhomthuoc" type="hidden" />
                    <input mkv="true" id="mkv_idnhomthuoc" type="text" onfocus="Find(this);chuyenphim(this);idnhomthuocSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 55%!important;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc")%>
                </h4>
                <p style="width: 73.25%!important;">
                    <input mkv="true" id="tenthuoc" type="text" onfocus="Find(this);chuyenphim(this);TenThuocSearch(this);"
                        style="width: 97%" class="down_select" />
                </p>
            </div>
            <div class="div-Out" style="width: 40%!important">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thuốc T.Thế")%>
                </h4>
                <p style="width: 75%!important;">
                    <input mkv="false" id="idthuoc_tt" type="hidden" />
                    <input mkv="false" id="mkv_idthuoc_tt" type="text" onfocus="Find(this);chuyenphim(this);TenThuocSearch2(this);"
                        style="width: 90%!important;" class="down_select" />
                </p>
            </div>
            <div class="div-Out" style="width: 50%!important;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("congthuc")%>
                </h4>
                <p style="width: 70.6%!important;">
                    <input mkv="true" id="congthuc" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 97%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ĐVT")%>
                </h4>
                <p>
                    <input mkv="true" id="iddvt" type="hidden" />
                    <input mkv="true" id="mkv_iddvt" type="text" onfocus="Find(this);chuyenphim(this);iddvtSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdCachDung")%>
                </h4>
                <p>
                    <input mkv="true" id="IdCachDung" type="hidden" />
                    <input mkv="true" id="mkv_IdCachDung" type="text" onfocus="Find(this);chuyenphim(this);IdCachDungSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
        </div>
        <div>
            *.Lưu ý: Tìm kiếm theo đối tượng , nhóm, P.nhóm, tên thuốc, hoạt chất</div>
        <div class="body-div-button">
            <p class="in-a">
                <input id="luu" edit="<%=StaticData.HavePermision(this, "thuoc_Edit") %>" add="<%=StaticData.HavePermision(this, "thuoc_Add") %>"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
                <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
                <input id="xoa" delete="<%=StaticData.HavePermision(this, "thuoc_Delete") %>" type="button"
                    style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
                <input id="timKiem" search="<%=StaticData.HavePermision(this, "thuoc_Search") %>"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                <input id="btnXuatExel" search="<%=StaticData.HavePermision(this, "thuoc_Search") %>"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Xuất Excel") %>" />
                <input id="btnThayThe" search="<%=StaticData.HavePermision(this, "ThayTheThuoc") %>"
                    type="button" value="Thay thế" />
            </p>
        </div>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_thuoc">
        </div>
    </div>
</asp:Content>

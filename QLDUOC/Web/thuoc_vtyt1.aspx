<%@ Page Language="C#" MasterPageFile="../MasterPage_new.master" AutoEventWireup="true"
    CodeFile="thuoc_vtyt1.aspx.cs" Inherits="thuoc_vtyt" Title="thuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/thuoc1.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH MỤC VẬT TƯ Y TẾ")%>
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên VTYT")%>
                </h4>
                <p>
                    <input mkv="true" id="tenthuoc" type="text" onfocus="Find(this);chuyenphim(this);TenThuocSearch(this);"
                        style="width: 90%" />
                </p>
            </div>
          <%--  <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("iddvt")%>
                </h4>
                <p>
                    <input mkv="true" id="iddvt" type="hidden" />
                    <input mkv="true" id="mkv_iddvt" type="text" onfocus="Find(this);chuyenphim(this);iddvtSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>--%>
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
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idnuocsanxuat")%>
                </h4>
                <p>
                    <input mkv="true" id="idnuocsanxuat" type="hidden" />
                    <input mkv="true" id="mkv_idnuocsanxuat" type="text" onfocus="Find(this);chuyenphim(this);idnuocsanxuatSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
             <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Quy cách")%>
                </h4>
                <p>
                     <input mkv="true" id="DVTChuan" type="hidden" />
                    <input mkv="true" id="mkv_DVTChuan" type="text" onfocus="Find(this);chuyenphim(this);DVTChuanSearch(this);"
                        class="down_select" style="width: 30%" />             
                    <input mkv="true" id="SLQuyDoi" type="text" onfocus="Find(this);chuyenphim(this);"
                        value="1"  style="width: 20%" />             
                    <input mkv="true" id="iddvt" type="hidden" />
                    <input mkv="true" id="mkv_iddvt" type="text" onfocus="Find(this);chuyenphim(this);iddvtSearch(this);"
                        class="down_select" style="width: 30%" />
                </p>
            </div>
            <%--<div class="div-Out">
                <h4>
                    <input mkv="true" id="SLQuyDoi" type="text" onfocus="Find(this);chuyenphim(this);"
                        value="1" style="width: 60%" />
                </h4>
                <p>
                    <input mkv="true" id="iddvt" type="hidden" />
                    <input mkv="true" id="mkv_iddvt" type="text" onfocus="Find(this);chuyenphim(this);iddvtSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>--%>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idhangsanxuat")%>
                </h4>
                <p>
                    <input mkv="true" id="idhangsanxuat" type="hidden" />
                    <input mkv="true" id="mkv_idhangsanxuat" type="text" onfocus="Find(this);chuyenphim(this);idhangsanxuatSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sudungchobh")%>
                </h4>
                <p>
                    <input mkv="true" id="sudungchobh" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                *.Lưu ý: Tìm kiếm theo nhóm, tên vtyt
            </div>
        </div>
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
            </p>
        </div>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_thuoc">
        </div>
    </div>
</asp:Content>

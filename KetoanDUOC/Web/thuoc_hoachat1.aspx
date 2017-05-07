<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="thuoc_hoachat1.aspx.cs" Inherits="thuoc_hoachat" Title="thuoc_hoachat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/thuoc1.js">
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH MỤC HOÁ CHẤT")%>
        </p>
        <div class="in-a">
            <%-- <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID")%>
     </h4>
     <p>
        <input mkv="true" id="LoaiThuocID" type="hidden" />
        <input mkv="true" id="mkv_LoaiThuocID" type="text" onfocus="Find(this);chuyenphim(this);LoaiThuocIDSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>--%>
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên hoá chất")%>
                </h4>
                <p>
                    <input mkv="true" id="tenthuoc" type="text" onfocus="Find(this);chuyenphim(this);TenThuocSearch(this);"
                        style="width: 90%" />
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
                    <input mkv="true" id="SLDVTChuan" type="text" onfocus="Find(this);chuyenphim(this);"
                        value="1" onblur="TestSo(this,false,true);" style="width: 30%" />
                    <input mkv="true" id="dvtchuan" type="hidden" />
                    <input mkv="true" id="mkv_dvtchuan" type="text" onfocus="Find(this);chuyenphim(this);dvtchuanSearch(this);"
                        class="down_select" style="width: 55%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <input mkv="true" id="SLQuyDoi" type="text" onfocus="Find(this);chuyenphim(this);"
                        value="1" onblur="TestSo(this,false,true);" style="width: 60%" />
                </h4>
                <p>
                    <input mkv="true" id="iddvt" type="hidden" />
                    <input mkv="true" id="mkv_iddvt" type="text" onfocus="Find(this);chuyenphim(this);iddvtSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
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
               <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tkkho")%>
                </h4>
                <p>
                    <input mkv="true" id="tkkho" type="hidden" />
                    <input mkv="true" id="mkv_tkkho" type="text" onfocus="Find(this);chuyenphim(this);tkkhoSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
             <div class="div-Out">
               <h4>
                    tk doanh thu
                </h4>
                <p>
                    <input mkv="true" id="tkdoanhthu" type="hidden" />
                    <input mkv="true" id="mkv_tkdoanhthu" type="text" onfocus="Find(this);chuyenphim(this);tkdoanhthuSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
               <h4>
                   TK giá vốn
                </h4>
                <p>
                    <input mkv="true" id="tkgiavon" type="hidden" />
                    <input mkv="true" id="mkv_tkgiavon" type="text" onfocus="Find(this);chuyenphim(this);tkgiavonSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                *.Lưu ý: Tìm kiếm theo nhóm, tên hoá chất
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
            </p>
        </div>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_thuoc">
        </div>
    </div>
</asp:Content>

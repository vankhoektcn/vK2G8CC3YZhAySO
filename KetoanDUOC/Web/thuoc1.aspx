<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="thuoc1.aspx.cs" Inherits="thuoc" Title="thuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/thuoc1.js">
    </script>
    <style>
    .div-Out
    {
        width:325px!important;
    }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("thuoc")%>
        </p>
        <div class="in-a">
            <div class="div-Out" style="width: 1095px!important;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CateID")%>
                </h4>
                <p style="width: 83.62%!important;">
                    <input mkv="true" id="CateID" type="hidden" />
                    <input mkv="true" id="mkv_CateID" type="text" onfocus="Find(this);chuyenphim(this);CateIDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 1095px!important;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idnhomthuoc")%>
                </h4>
                <p style="width: 83.62%!important;">
                    <input mkv="true" id="idnhomthuoc" type="hidden" />
                    <input mkv="true" id="mkv_idnhomthuoc" type="text" onfocus="Find(this);chuyenphim(this);idnhomthuocSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 671px!important;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc")%>
                </h4>
                <p style="width: 73.25%!important;">
                    <input mkv="true" id="tenthuoc" type="text" onfocus="Find(this);chuyenphim(this);TenThuocSearch(this);"
                        style="width: 97%" class="down_select" />
                </p>
            </div>
            
            <div class="div-Out" style="width: 671px!important;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("congthuc")%>
                </h4>
                <p style="width: 73.25%!important;">
                    <input mkv="true" id="congthuc" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 97%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sttindm05")%>
                </h4>
                <p>
                    <input mkv="true" id="sttindm05" type="text" onfocus="Find(this);chuyenphim(this);"
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Quy cách")%>
                </h4>
                <p>
                    <input mkv="true" id="SLDVTChuan" type="text" onfocus="Find(this);chuyenphim(this);"
                        value="1" onblur="TestSo(this,false,true);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DVTChuan")%>
                </h4>
                <p>
                    <input mkv="true" id="dvtchuan" type="hidden" />
                    <input mkv="true" id="mkv_dvtchuan" type="text" onfocus="Find(this);chuyenphim(this);dvtchuanSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <input mkv="true" id="SLQuyDoi" type="text" onfocus="Find(this);chuyenphim(this);"
                        value="1" onblur="TestSo(this,false,true);" style="width: 30%" />
                </h4>
                <p>
                    <input mkv="true" id="iddvt" type="hidden" />
                    <input mkv="true" id="mkv_iddvt" type="text" onfocus="Find(this);chuyenphim(this);iddvtSearch(this);"
                        class="down_select" style="width: 90%" />
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
        </div>
        *.Lưu ý: Tìm kiếm theo đối tượng , nhóm, P.nhóm, tên thuốc, hoạt chất
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

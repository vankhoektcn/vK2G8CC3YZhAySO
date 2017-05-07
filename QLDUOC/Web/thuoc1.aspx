<%@ Page Language="C#" MasterPageFile="../MasterPage_new.master" AutoEventWireup="true"
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
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TTHoatChat")%>
                </h4>
                <p>
                    <input mkv="true" id="TTHoatChat" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
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
            <%--<div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sttindm05")%>
                </h4>
                <p>
                    <input mkv="true" id="sttindm05" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>--%>
            <%--<div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("HamLuong")%>
                </h4>
                <p>
                    <input mkv="true" id="HamLuong" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IsTGN")%>
                </h4>
                <p>
                     Có
                    <input mkv="true" id="IsTGN" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                     Không
                    <input mkv="false" id="searchbyIsTGN" type="checkbox" onfocus="chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IsTHTT")%>
                </h4>
                <p>
                Có
                    <input mkv="true" id="IsTHTT" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                       Không
                    <input mkv="false" id="searchbyIsTHTT" type="checkbox" onfocus="chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ISTPX")%>
                </h4>
                <p>
                Có
                    <input mkv="true" id="ISTPX" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                Không
                    <input mkv="false" id="searchbyISTPX" type="checkbox" onfocus="chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ISTKS")%>
                </h4>
                <p>
                Có
                    <input mkv="true" id="ISTKS" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                    Không
                    <input mkv="false" id="searchbyISTKS" type="checkbox" onfocus="chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ISTDTL")%>
                </h4>
                <p>
                Có
                    <input mkv="true" id="ISTDTL" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                Không
                    <input mkv="false" id="searchbyISTDTL" type="checkbox" onfocus="chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ISTcorticoid")%>
                </h4>
                <p>
                Có
                    <input mkv="true" id="ISTcorticoid" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                  Không
                    <input mkv="false" id="searchbyISTcorticoid" type="checkbox" onfocus="chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IsDTUT")%>
                </h4>
                <p>
                Có
                    <input mkv="true" id="IsDTUT" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                  Không
                    <input mkv="false" id="searchbyIsDTUT" type="checkbox" onfocus="chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out" id="IsQPTBH">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sudungchobh")%>
                </h4>
                <p>
                    <input mkv="true" id="sudungchobh" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                    &nbsp;; Ngoại trú ?<input mkv="true" id="IsNgoaiTru" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
                </p>
            </div>
         
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DVTChuan")%>
                </h4>
                <p>
                    <input mkv="true" id="DVTChuan" type="hidden" />
                    <input mkv="true" id="mkv_DVTChuan" type="text" onfocus="Find(this);chuyenphim(this);DVTChuanSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <input mkv="true" id="SLQuyDoi" type="text" onfocus="Find(this);chuyenphim(this);"
                        value="1"  style="width: 30%" />
                </h4>
                <p>
                    <input mkv="true" id="iddvt" type="hidden" />
                    <input mkv="true" id="mkv_iddvt" type="text" onfocus="Find(this);chuyenphim(this);iddvtSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
        </div>
        *.Lưu ý: Tìm kiếm theo đối tượng , nhóm, P.nhóm, tên thuốc, hoạt chất
        <div class="body-div-button">
            <p class="in-a">
        
            
                <input id="luu" edit="<%=Userlogin_new.HavePermision(this, "thuoc_Edit") %>" add="<%=Userlogin_new.HavePermision(this, "thuoc_Add") %>"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
                <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
                <input id="xoa" delete="<%=Userlogin_new.HavePermision(this, "thuoc_Delete") %>" type="button"
                    style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
                <input id="timKiem" search="<%=Userlogin_new.HavePermision(this, "thuoc_Search") %>"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                    <input id="btnXuatExel" search="<%=Userlogin_new.HavePermision(this, "thuoc_Search") %>"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Xuất Excel") %>" />
                    
            </p>
        </div>
        <a class="reload" onclick="Find(this)"></a>
        <div class="in-b" id="tableAjax_thuoc">
        </div>
    </div>
</asp:Content>

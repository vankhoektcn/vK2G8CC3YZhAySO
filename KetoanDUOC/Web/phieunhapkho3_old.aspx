﻿<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="phieunhapkho3_old.aspx.cs" Inherits="phieunhapkho" Title="phieunhapkho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/phieunhapkho3.js">
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
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phieunhapkho")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("maphieunhap")%>
                </h4>
                <p>
                    <input mkv="true" id="maphieunhap" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaythang" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 40%" />
                    <input mkv="true" id="gio" type="text" style="width: 8%" onfocus="chuyenphim(this);" />:
                    <input mkv="true" id="phut" type="text" style="width: 8%" onfocus="chuyenphim(this);" />
                  
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho")%>
                </h4>
                <p>
                    <input mkv="true" id="idkho" type="hidden" />
                    <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);idkhoSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 672px!important">
                <h4 style="width: 150px;">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nhacungcapid")%>
                </h4>
                <p style="width: 83.1%!important;">
                    <input mkv="true" id="nhacungcapid" type="hidden" />
                    <input mkv="true" id="mkv_nhacungcapid" type="text" onfocus="Find(this);chuyenphim(this);nhacungcapidSearch(this);"
                        class="down_select" style="width: 96%!important" />
                </p>
            </div>
            <div class="div-Out" style="width: 323px!important">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tennguoigiao")%>
                </h4>
                <p>
                    <input mkv="true" id="tennguoigiao" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 284px">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sohoadon")%>
                </h4>
                <p>
                    <input mkv="true" id="sohoadon" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhoadon")%>
                </h4>
                <p>
                    <input mkv="true" id="ngayhoadon" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("vat")%>
                </h4>
                <p>
                    <input mkv="true" id="vat" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);"
                        style="width: 90%" />
                </p>
            </div>           
            
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tk có")%>
                </h4>
                <p>
                    <input mkv="true" id="tkco" type="hidden" />
                    <input mkv="true" id="mkv_tkco" type="text" onfocus="Find(this);chuyenphim(this);tkcoSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            
             <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tk vat")%>
                </h4>
                <p>
                    <input mkv="true" id="tkvat" type="hidden" />
                    <input mkv="true" id="mkv_tkvat" type="text" onfocus="Find(this);chuyenphim(this);tkvatSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            
            <div class="div-Out">
<%--            khai bao tai khoan chiet khau; field trong phieunhapkho: tkno
--%>                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tk ck")%>
                </h4>
                <p>
                    <input mkv="true" id="tkno" type="hidden" />
                    <input mkv="true" id="mkv_tkno" type="text" onfocus="Find(this);chuyenphim(this);tknoSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            
             <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idnguoinhap")%>
                </h4>
                <p>
                    <input mkv="true" id="idnguoinhap" type="hidden" />
                    <input mkv="true" id="mkv_idnguoinhap" type="text" onfocus="Find(this);chuyenphim(this);idnguoinhapSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu")%>
                </h4>
                <p>
                    <input mkv="true" id="ghichu" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            
            <div class="div-Out">
                <h4>
                    <input id="TimMoi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tìm mới") %>" />
                    <input id="timKiem" search="<%=StaticData.HavePermision(this, "phieunhapkho_Search") %>"
                        type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </h4>
            </div>
        </div>
        (*)Lưu ý: định dạng ngày tháng (dd/MM/yyyy) <a class="reload" onclick="loadTableAjaxchitietphieunhapkho($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_chitietphieunhapkho" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "phieunhapkho_Edit") %>"
                add="<%=StaticData.HavePermision(this, "phieunhapkho_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "phieunhapkho_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="print" onclick="InPhieuNhap()"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("print") %>" />
        </p>
    </div>
</asp:Content>

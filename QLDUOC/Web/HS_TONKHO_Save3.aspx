<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage.master" AutoEventWireup="true"
    CodeFile="HS_TONKHO_Save3.aspx.cs" Inherits="HS_TONKHO_Save" Title="HS_TONKHO_Save" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/HS_TONKHO_Save3.js">
    </script>
    <style type="text/css">
        .jtable input[disabled][type="text"],.jtable input[type="text"]
        {
            color:#06c;
            font-size:14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kiểm & Điều chỉnh kho")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKho")%>
                </h4>
                <p>
                    <input mkv="true" id="IdKho" type="hidden" />
                    <input mkv="true" id="mkv_IdKho" type="text" onfocus="chuyenphim(this);IdKhoSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="TuNgay" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="DenNgay" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 50%" />
                    (dd\MM\yyyy)
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID")%>
                </h4>
                <p>
                    <input mkv="true" id="LoaiThuocID" type="hidden" />
                    <input mkv="true" id="mkv_LoaiThuocID" type="text" onfocus="chuyenphim(this);LoaiThuocIDSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="IdThuoc" type="hidden" />
                    <input mkv="true" id="mkv_IdThuoc" type="text" onfocus="chuyenphim(this);IdThuocSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
        </div>
        <a class="reload" onclick="loadTableAjaxHS_TonKhoViewDetail($.mkv.queryString('idkhoachinh'))">
        </a>
        <div id="tableAjax_HS_TonKhoViewDetail" class="in-b">
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "HS_TONKHO_Save_Edit") %>"
                add="<%=StaticData.HavePermision(this, "HS_TONKHO_Save_Add") %>" type="button"
                value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" delete="<%=StaticData.HavePermision(this, "HS_TONKHO_Save_Delete") %>"
                type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" search="<%=StaticData.HavePermision(this, "HS_TONKHO_Save_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
            <input id="btnXuatExel" search="<%=StaticData.HavePermision(this, "thuoc_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Xuất Excel") %>" />
            <input id="btnDieuChinhKho" search="<%=StaticData.HavePermision(this, "thuoc_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Điều chỉnh kho") %>"
                style="width: 150px" />
            <input type="button" value="Hướng dẫn" id="help" />
        </p>
    </div>
</asp:Content>

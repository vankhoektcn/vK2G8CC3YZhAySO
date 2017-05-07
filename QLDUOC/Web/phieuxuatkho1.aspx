<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="phieuxuatkho1.aspx.cs" Inherits="phieuxuatkho" Title="phieuxuatkho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/phieuxuatkho1.js">
    </script>

    <style>
    .div-Out
    {
        width:365px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH PHIẾU XUẤT KHO ")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="tungay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="denngay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loaixuat")%>
                </h4>
                <p>
                    <input mkv="true" id="loaixuat" type="hidden" />
                    <input mkv="true" id="mkv_loaixuat" type="text" onfocus="Find(this);chuyenphim(this);loaixuatSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" id="divMaPhieu">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat")%>
                </h4>
                <p>
                    <input mkv="true" id="maphieuxuat" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" id="divGhichu">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu")%>
                </h4>
                <p>
                    <input mkv="true" id="ghichu" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" id="divKhoXuat">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho xuất")%>
                </h4>
                <p>
                    <input mkv="true" id="idkho" type="hidden" />
                    <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);idkhoSearch(this);"
                        class="down_select" style="width: 90%" disabled="disabled" />
                </p>
            </div>
            <div class="div-Out" id="divKhachHang">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IDKhachHang")%>
                </h4>
                <p>
                    <input mkv="true" id="IDKhachHang" type="hidden" />
                    <input mkv="true" id="mkv_IDKhachHang" type="text" onfocus="Find(this);chuyenphim(this);IDKhachHangSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" id="divNhaCC">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idnhacungcap")%>
                </h4>
                <p>
                    <input mkv="true" id="idnhacungcap" type="hidden" />
                    <input mkv="true" id="mkv_idnhacungcap" type="text" onfocus="Find(this);chuyenphim(this);idnhacungcapSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho2")%>
                </h4>
                <p>
                    <input mkv="true" id="idkho2" type="hidden" />
                    <input mkv="true" id="mkv_idkho2" type="text" onfocus="Find(this);chuyenphim(this);idkho2Search(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" id="divLoaiThuoc">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="IdLoaiThuoc" type="hidden" />
                    <input mkv="true" id="mkv_IdLoaiThuoc" type="text" onfocus="Find(this);chuyenphim(this);IdLoaiThuocSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" id="divThuoc">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="idthuoc" type="hidden" />
                    <input mkv="true" id="mkv_idthuoc" type="text" onfocus="Find(this);chuyenphim(this);idthuocSearch(this);"
                        class="down_select" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoPhieuYC")%>
                </h4>
                <p>
                    <input mkv="true" id="SOPHIEUYC" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </p>
            </div>
        </div>
        <div class="body-div-button">
            <p class="in-a">
                <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
                <input id="timKiem" search="<%=StaticData.HavePermision(this, "phieuxuatkho_Search") %>"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
            </p>
        </div>
        <div class="in-b" id="tableAjax_phieuxuatkho">
        </div>
    </div>
</asp:Content>

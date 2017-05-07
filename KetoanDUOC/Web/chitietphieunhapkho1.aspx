<%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true"
    CodeFile="chitietphieunhapkho1.aspx.cs" Inherits="chitietphieunhapkho" Title="chitietphieunhapkho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/chitietphieunhapkho1.js">
    </script>

    <style>
    .div-Out
    {
        width:320px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chitietphieunhapkho")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="tungay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="denngay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sohoadon")%>
                </h4>
                <p>
                    <input mkv="true" id="idphieunhap" type="hidden" />
                    <input mkv="true" id="mkv_idphieunhap" type="text" onfocus="Find(this);chuyenphim(this);idphieunhapSearch(this);"
                        class="down_select"  />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="IdLoaiThuoc" type="hidden" />
                    <input mkv="true" id="mkv_IdLoaiThuoc" type="text" onfocus="Find(this);chuyenphim(this);IdLoaiThuocSearch(this);"
                        class="down_select" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc")%>
                </h4>
                <p>
                    <input mkv="true" id="idthuoc" type="hidden" />
                    <input mkv="true" id="mkv_idthuoc" type="text" onfocus="Find(this);chuyenphim(this);idthuocSearch(this);"
                        class="down_select"  />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                </h4>
                <p>
                    <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
                    <input id="timKiem" search="<%=StaticData.HavePermision(this, "chitietphieunhapkho_Search") %>"
                        type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </p>
            </div>
        </div>
        *.Lưu ý: các định dạng ngày tháng (dd/MM/yyyy)
        <div class="in-b" id="tableAjax_chitietphieunhapkho">
        </div>
    </div>
</asp:Content>

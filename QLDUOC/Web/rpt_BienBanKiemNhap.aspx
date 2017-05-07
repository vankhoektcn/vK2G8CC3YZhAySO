<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage.master" AutoEventWireup="true"
    CodeFile="rpt_BienBanKiemNhap.aspx.cs" Inherits="QLDUOC_Web_rpt_BienBanKiemNhap"
    Title="Biên bản kiểm nhập" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
    .div-Out
    {
        width:30%;
        height:40px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Biên bản Kiểm nhập")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p>
                    <input type="text" id="txtTuNgay" onfocus="$(this).datepick();$(this).validDate()"
                        runat="server" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p>
                    <input type="text" id="txtDenNgay" onfocus="$(this).datepick();$(this).validDate()"
                        runat="server" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho nhập")%>
                </h4>
                <p>
                    <asp:DropDownList ID="ddl_khonhap" runat="server" Width="200px">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Loại thuốc")%>
                </h4>
                <p>
                    <asp:DropDownList ID="ddl_loaithuoc" runat="server" Width="100px">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <asp:Button ID="btnTim" runat="server" Text="Lấy Danh sách" OnClick="btnTim_Click"
                        Width="120px" />
                </h4>
            </div>
        </div>
    </div>
</asp:Content>

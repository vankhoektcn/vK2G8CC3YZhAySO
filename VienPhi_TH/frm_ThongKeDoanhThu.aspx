<%@ Page Language="C#" MasterPageFile="~/VienPhi_TH/MasterPage.master" AutoEventWireup="true"
    CodeFile="frm_ThongKeDoanhThu.aspx.cs" Inherits="VienPhi_TH_frm_ThongKeDoanhThu"
    Title="Thống kê doanh thu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style>
    .div-Out
    {
        width:220px!important;
    }
    .div-Out p
    {
        width:70%!important;
    }
    </style>

    <script type="text/javascript" src="js/ThongKeDoanhThu.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
    
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BÁO CÁO DOANH THU THEO NGƯỜI DÙNG")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p>
                    <input type="text" id="tungay" onfocus="chuyenphim(this);" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p>
                    <input type="text" id="denngay" onfocus="chuyenphim(this);$(this).datepick();" />
                </p>
            </div>
            <div class="div-Out" style="width: 320px!important">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Người dùng")%>
                </h4>
                <p>
                    <select id="nguoidung" onfocus="chuyenphim(this);" style="width: 220px">
                    </select>
                </p>
            </div>
            <div class="div-Out">
                <input type="button" id="btnLayDS" value="Lấy danh sách" /><input type="button" id="btnExport"
                    value="Xuất Excel" />
            </div>
        </div>
        <div id="tableAjax_ThongKeDoanhThu">
        </div>
    </div>
</asp:Content>

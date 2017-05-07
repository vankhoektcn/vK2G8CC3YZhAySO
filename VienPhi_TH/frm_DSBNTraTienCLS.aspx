<%@ Page Language="C#" MasterPageFile="~/VienPhi_TH/MasterPage.master" AutoEventWireup="true"
    CodeFile="frm_DSBNTraTienCLS.aspx.cs" Inherits="VienPhi_TH_frm_DSBNTraTienCLS"
    Title="Danh sách BN Trả tiền CLS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="javascript/DSBNTraTienCLS.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH BỆNH NHÂN TRẢ TIỀN CLS")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaybd" type="text" onfocus="chuyenphim(this);"
                        tabindex="2" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã bệnh nhân")%>
                </h4>
                <p>
                    <input mkv="true" id="mabenhnhan" type="text" onfocus="chuyenphim(this);" style="width: 90%"
                        tabindex="1" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên bệnh nhân")%>
                </h4>
                <p>
                    <input mkv="true" id="tenbenhnhan" type="text" onfocus="chuyenphim(this);" style="width: 90%" />
                </p>
            </div>
            <input type="button" value="Lấy danh sách" id="LayDS" />
        </div>
        <div id="tableDSBNCLS">
        </div>
    </div>
</asp:Content>

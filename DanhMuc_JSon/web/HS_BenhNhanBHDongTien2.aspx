<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/Page.master" AutoEventWireup="true"
    CodeFile="HS_BenhNhanBHDongTien2.aspx.cs" Inherits="HS_BenhNhanBHDongTien" Title="HS_BenhNhanBHDongTien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/HS_BenhNhanBHDongTien2.js">
    </script>

    <style type="text/css">
        .div-Out
        {
            width:23%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH BỆNH NHÂN")%>
        </p>
        <div class="in-a">
            <div class="div-Out" style="width: 25%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("HoTenBN")%>
                </h4>
                <p style="width: 68%">
                    <input mkv="true" id="HoTenBN" type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 28%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoBHYT")%>
                </h4>
                <p style="width: 62%">
                    <input mkv="true" id="SoBHYT" type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out" style="width: 20%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("V.viện từ")%>
                </h4>
                <p style="width: ">
                    <input mkv="true" id="TuNgay" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 80%" />
                </p>
            </div>
            <div class="div-Out" style="width: 20%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("đến")%>
                </h4>
                <p>
                    <input mkv="true" id="DenNgay" type="text" onfocus="chuyenphim(this);$(this).datepick();"
                        onblur="TestDate(this);" style="width: 80%" />
                </p>
            </div>
            <div class="div-Out" style="width: 17%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MASOHOSO")%>
                </h4>
                <p style="width: 53%;">
                    <input mkv="true" id="MASOHOSO" type="text" style="width: 80%" />
                </p>
            </div>
            <div class="div-Out" style="width: 17%">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SOVAOVIEN")%>
                </h4>
                <p style="width: 53%;">
                    <input mkv="true" id="SOVAOVIEN" type="text" style="width: 80%" />
                </p>
            </div>
            <div class="div-Out" style="width: 17.3%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Nội trú?")%>
                </h4>
                <p style="width: 53%">
                    <input mkv="true" id="IsNoiTru_Save" type="checkbox" />
                </p>
            </div>
            <div class="div-Out" style="width: 17%; padding-left: 5px;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("C.số v.viện?")%>
                </h4>
                <p style="width: 52%">
                    <input mkv="true" id="SoVaoVienNotEmply" type="checkbox" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số V.V. Max")%>
                </h4>
                <p style="width: 51%">
                    <input mkv="false" id="SoVaoVienMax" type="text" style="width: 90%" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <p class="in-a">
            <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="timKiem" search="<%=Userlogin_new.HavePermision(this, "HS_BenhNhanBHDongTien_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
            <input id="Config" search="<%=Userlogin_new.HavePermision(this, "HS_BenhNhanBHDongTien_Search") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Cấu hình") %>" />
        </p>
        <div class="in-b" id="tableAjax_HS_BenhNhanBHDongTien">
        </div>
    </div>
</asp:Content>

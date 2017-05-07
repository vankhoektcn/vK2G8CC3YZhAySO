<%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true"
    CodeFile="zDSChoCanLamSang1.aspx.cs" Inherits="zDSChoCanLamSang" Title="zDSChoCanLamSang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/zDSChoCanLamSang1.js">
    </script>
<style type="text/css">
    .div-Out {
        width: 350px;
        position: relative;
        height: 40px;
        border: 1px solid #ccc;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div" id="header">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH CHỜ XÉT NGHIỆM")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoa")%>
                </h4>
                <p>
                    <select mkv="true" id="IdKhoa" style="width:90%" ></select>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="TuNgay" type="text" onfocus='Find(this);' onblur="$.TestDate(this);"
                        style="width: 80px;" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
                </h4>
                <p>
                    <input mkv="true" id="DenNgay" type="text" onfocus='Find(this);' onblur="$.TestDate(this);"
                        style="width: 80px;" />
                </p>
            </div>
            <%--<div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MaCLS")%>
                </h4>
                <p>
                    <input mkv="true" id="MaCLS" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>--%>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MaBenhNhan")%>
                </h4>
                <p>
                    <input mkv="true" id="MaBenhNhan" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TenBenhNhan")%>
                </h4>
                <p>
                    <input mkv="true" id="TenBenhNhan" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
            <%--<div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoBHYT")%>
                </h4>
                <p>
                    <input mkv="true" id="SoBHYT" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BSChiDinh")%>
                </h4>
                <p>
                    <input mkv="true" id="BSChiDinh" onfocus='Find(this);' type="text" style="width: 90%" />
                </p>
            </div>--%>
            <div class="div-Out">
                <h4>
                </h4>
                <p>
                    <input id="timKiem"
                    type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </p>
            </div>
        </div>
    </div>
    <div class="body-div-button">
        <div class="in-b" id="tableAjax_zDSChoCanLamSang">
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmDSBNKTCD.aspx.cs" Inherits="frmDSBNKTCD" Title="Kiểm tra chỉ định thuốc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/frmDSBNKTCD.js">
    </script>

    <style type="text/css">
        .div-Out
        {
            width:22%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kiểm tra chỉ định thuốc")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="TuNgay" type="text" style="width: 90%" onfocus="$(this).datepick();" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p>
                    <input mkv="true" id="DenNgay" type="text" style="width: 90%" onfocus="$(this).datepick();" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Khoa")%>
                </h4>
                <p>
                    <select id="ddlKhoa" mkv="true">
                    </select>
                </p>
            </div>
              <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã BN")%>
                </h4>
               <p>
                    <input mkv="true" id="mabn" type="text" style="width: 90%"  />
                </p>
            </div>
              <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Họ tên BN")%>
                </h4>
                 <p>
                    <input mkv="true" id="tenbn" type="text" style="width: 90%"  />
                </p>
            </div>
              <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày sinh")%>
                </h4>
                 <p>
                    <input mkv="true" id="ngaysinh" type="text" style="width: 90%"  />
                </p>
            </div>
            <div class="div-Out" style="width: 32%;">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phòng")%>
                </h4>
                <p style="width: 76%;">
                    <select id="ddlPhong" mkv="true">
                    </select>
                    <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
                </p>
            </div>
        </div>
        <div class="in-b" id="tableAjax_DSTTNoiTru">
        </div>
         
    </div>
</asp:Content>

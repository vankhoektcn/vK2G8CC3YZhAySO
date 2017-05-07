<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmDSBNKTCDChitiet.aspx.cs" Inherits="frmDSBNKTCDChitiet" Title="Kiểm tra chỉ định thuốc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript" src="../javascript/frmDSBNKTCDChitiet.js">
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
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày TH")%>
                </h4>
                <p>
                    <input mkv="true" id="ngaykham" type="text" style="width: 90%"  disabled="disabled">
                </p>
            </div>
             
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phòng")%>
                </h4>
                <p>
                    <input mkv="true" id="PHONG" type="text" style="width: 90%"  disabled="disabled">
                </p>
            </div>
              <%--<div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã BN")%>
                </h4>
               <p>
                    <input mkv="true" id="mabn" type="text" style="width: 90%"  />
                </p>
            </div>--%>
              <div class="div-Out" style="width:600px">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Họ tên BN")%>
                </h4>
                 <p style="width:500px">
                    <input mkv="true" id="tenbn" type="text" style="width: 90%"  disabled="disabled"/>
                </p>
            </div>
              <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày sinh")%>
                </h4>
                 <p>
                    <input mkv="true" id="ngaysinh" type="text" style="width: 90%"  disabled="disabled"/>
                </p>
            </div>
              <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Giới tính")%>
                </h4>
                 <p>
                    <input mkv="true" id="gioitinh" type="text" style="width: 90%"  disabled="disabled"/>
                </p>
            </div>
            
            <div class="div-Out" style="width:600px">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên dịch vụ")%>
                </h4>
                 <p style="width:500px">
                    <input mkv="true" id="TENDICHVU" type="text" style="width: 90%" disabled="disabled" />
                </p>
            </div>
           <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("KT đúng")%>
                </h4>
                 <p>
                    <input mkv="true" id="IsCheckAllCD" type="checkbox" style="width: 90%"   />
                </p>
        </div>
            
         <div class="div-Out" style="width:800px">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ghi chú")%>
                </h4>
                 <p style="width:700px">
                    <input mkv="true" id="GHICHUCD" type="text" style="width: 90%"   />
                    <input mkv="true" id="perLuu" type="hidden" value="0" />
                </p>
            </div>    
            
        </div>
        <div class="in-b" id="tableAjax_DSTTNoiTru">
        </div>
        
        <div class="button_div">
                    <input id="save" type="button"   value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Lưu") %>"  onclick="SaveKTCD();"/>
                    <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Xem lại") %>" />
                    <input id="Exit" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thoát") %>" />
                    
        </div>
        
         
    </div>
</asp:Content>

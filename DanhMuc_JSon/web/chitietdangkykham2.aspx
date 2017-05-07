 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true" CodeFile="chitietdangkykham2.aspx.cs" Inherits="chitietdangkykham" Title="chitietdangkykham" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/chitietdangkykham2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chitietdangkykham")%>
           </p>
 <div class="in-a">
 

         </div></div>
 <div class="body-div-button">
         <div class="in-b" id="tableAjax_chitietdangkykham">
         </div>
 <p class="in-c">
                    <input  id="timKiem" type="button" value="Lấy chi tiết"  visible="false" />
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>

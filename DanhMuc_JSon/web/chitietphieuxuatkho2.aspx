 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true" CodeFile="chitietphieuxuatkho2.aspx.cs" Inherits="chitietphieuxuatkho" Title="chitietphieuxuatkho" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/chitietphieuxuatkho2.js">
     </script>
 



 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chitietphieuxuatkho")%>
           </p>
 <div class="in-a">
  
         </div></div>
 <div class="body-div-button">
 
          <div class="in-b" id="tableAjax_chitietphieuxuatkho">
         </div>
 <p class="in-c">
                    <input  id="timKiem" search="<%=Userlogin_new.HavePermision(this, "chitietphieuxuatkho_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Chi tiết") %>"                     />
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>

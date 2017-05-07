 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true" CodeFile="khambenhcanlamsan2.aspx.cs" Inherits="khambenhcanlamsan" Title="khambenhcanlamsan" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/khambenhcanlamsan2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CHI TIẾT CẬN LÂM SÀNG - DVKT")%>
           </p>
 <div class="in-a">
 
         </div></div>
 <div class="body-div-button">
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_khambenhcanlamsan">
         </div>
 <p class="in-c">
                    <input  id="timKiem" search="<%=Userlogin_new.HavePermision(this, "khambenhcanlamsan_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Detail") %>"                       />
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>

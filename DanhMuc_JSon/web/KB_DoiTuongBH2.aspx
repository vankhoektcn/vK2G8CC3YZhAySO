 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true" CodeFile="KB_DoiTuongBH2.aspx.cs" Inherits="KB_DoiTuongBH" Title="KB_DoiTuongBH" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/KB_DoiTuongBH2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("KB_DoiTuongBH")%>
           </p>
 <div class="in-a">
 
         </div></div>
 <div class="body-div-button">
 <p class="in-a">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" search="<%=Userlogin_new.HavePermision(this, "KB_DoiTuongBH_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </p>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_KB_DoiTuongBH">
         </div>
 <p class="in-c">
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>

 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true" CodeFile="KB_DONVITINH_DV2.aspx.cs" Inherits="KB_DONVITINH_DV" Title="KB_DONVITINH_DV" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/KB_DONVITINH_DV2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ĐƠN VỊ TÍNH DỊCH VỤ - CẬN LÂM SÀNG")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TenDVt")%>
     </h4>
     <p>
        <input mkv="true" id="TenDVt" type="text" onfocus='Find(this);' style="width:90%"/>
     </p>
 </div>
         </div></div>
 <div class="body-div-button">
 <p class="in-a">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" search="<%=Userlogin_new.HavePermision(this, "KB_DONVITINH_DV_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </p>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_KB_DONVITINH_DV">
         </div>
 <p class="in-c">
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>

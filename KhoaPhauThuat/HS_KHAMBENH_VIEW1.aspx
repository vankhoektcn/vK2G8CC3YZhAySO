 <%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="HS_KHAMBENH_VIEW1.aspx.cs" Inherits="HS_KHAMBENH_VIEW1" Title="HS_KHAMBENH_VIEW1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="javascript/HS_KHAMBENH_VIEW1.js">
     </script>
        
     <style>
    .div-Out
    {
        width:290px;
    }
</style>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                </p>
 <div class="in-a">
  <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
     </h4>
     <p>
        <input mkv="true" id="TuNgay" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestDate(this);" />
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
     </h4>
     <p>
        <input mkv="true" id="DenNgay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);" />
     </p>
 </div>
 
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số BHYT")%>
     </h4>
     <p>
        <input mkv="true" id="SoBHYT" type="text" onfocus="Find(this);chuyenphim(this);"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã BN")%>
     </h4>
     <p>
        <input mkv="true" id="MaBN" type="text" onfocus="Find(this);chuyenphim(this);"/>
     </p>
 </div>
 
 <div class="div-Out" style="width:596px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("HoTenBN")%>
     </h4>
     <p style="width: 494px;">
        <input mkv="true" id="HoTenBN" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 456px;"/>
     </p>
 </div>
 <div class="div-Out" >
     <h4>
         
     
     </h4>
     <p>
     
         <input  id="timKiem" search="<%=StaticData.HavePermision(this, "HS_KHAMBENH_VIEW_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Lấy DS") %>"/>  
         <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>"/>
     </p>
 </div>
 </div></div>
         <div  class="in-b" id="tableAjax_HS_KHAMBENH_VIEW">
         </div>
 </asp:Content>

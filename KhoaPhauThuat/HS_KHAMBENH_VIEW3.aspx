 <%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="HS_KHAMBENH_VIEW3.aspx.cs" Inherits="HS_KHAMBENH_VIEW3" Title="HS_KHAMBENH_VIEW3" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="javascript/HS_KHAMBENH_VIEW3.js">
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
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CHI TIẾT THÔNG TIN KHÁM/ĐIỀU TRỊ BỆNH")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày")%>
     </h4>
     <p>
        <input mkv="true" id="DenNgay" type="text"/>
     </p>
 </div>
 <div class="div-Out" style="width:600px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("HoTenBN")%>
     </h4>
     <p style="width: 498px;">
        <input mkv="true" id="HoTenBN" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 487px;" />
     </p>
 </div>
 
  
 
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MaBN")%>
     </h4>
     <p>
        <input mkv="true" id="MaBN" type="text" onfocus="Find(this);chuyenphim(this);"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoBHYT")%>
     </h4>
     <p>
        <input mkv="true" id="SoBHYT" type="text" onfocus="Find(this);chuyenphim(this);"/>
     </p>
 </div>
 
 
 
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgaySinh")%>
     </h4>
     <p>
        <input mkv="true" id="NgaySinh" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        <input mkv="true" id="GioiTinh" type="text" onfocus="Find(this);chuyenphim(this);" style="width:35%"/>
     </p>
 </div>
         <a class="reload" onclick="loadTableAjaxHS_KHAMBENH_VIEWDetail($.mkv.queryString('idkhoachinh'))"></a>
         <div id="tableAjax_HS_KHAMBENH_VIEWDetail"   class="in-b">
             
         </div>
         <div class="body-div-button">
        <p class="in-a">
         <input id="KhamBenhMoi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phiếu theo dõi mới") %>"  style="width:200px"/>
        </p>
    </div>
 </asp:Content>

 <%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="phieuxuatkho_XuatSD.aspx.cs" Inherits="phieuxuatkho_XuatSD" Title="phieuxuatkho_XuatSD" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/phieuxuatkho_XuatSD.js">
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
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PHIẾU XUẤT SỬ DỤNG")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("maphieuxuat")%>
     </h4>
     <p>
        <input mkv="true" id="maphieuxuat" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang")%>
     </h4>
     <p>
        <input mkv="true" id="ngaythang" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);" />
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu")%>
     </h4>
     <p>
        <input mkv="true" id="ghichu" type="text" onfocus="Find(this);chuyenphim(this);ghichuSearch(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho")%>
     </h4>
     <p>
        <input mkv="true" id="idkho" type="hidden" />
        <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);idkhoSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
  
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc")%>
     </h4>
     <p>
        <input mkv="true" id="IdLoaiThuoc" type="hidden" />
        <input mkv="true" id="mkv_IdLoaiThuoc" type="text" onfocus="Find(this);chuyenphim(this);IdLoaiThuocSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
         </div>
         <a class="reload" onclick="loadTableAjaxHS_OutPutDetail($.mkv.queryString('idkhoachinh'))"></a>
         <div id="tableAjax_HS_OutPutDetail"   class="in-b">
             
         </div>
         </div><div class="body-div-button">
             <p class="in-a">
                 <input  id="luu" edit="<%=StaticData.HavePermision(this, "phieuxuatkho_Edit") %>" add="<%=StaticData.HavePermision(this, "phieuxuatkho_Add") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> "
                      />
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>"/>
                 <input  id="xoa" delete="<%=StaticData.HavePermision(this, "phieuxuatkho_Delete") %>" type="button" style="display:none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                      />
                 <input  id="timKiem" search="<%=StaticData.HavePermision(this, "phieuxuatkho_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" 
                      />
                 <input  id="TimMoi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tìm mới") %>"/>
                 <input id="ViewDetail" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Detail") %>" />             
                 <input id="btnPrin" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("In phiếu") %>" />             

             </p>
         </div>
 </asp:Content>

 <%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="HS_ChiTietPhieuXuat.aspx.cs" Inherits="phieuxuatkho" Title="phieuxuatkho" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/HS_ChiTietPhieuXuat.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phieuxuatkho")%>
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
        <input mkv="true" id="ngaythang" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho")%>
     </h4>
     <p>
        <input mkv="true" id="idkho" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loaixuat")%>
     </h4>
     <p>
        <input mkv="true" id="loaixuat" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IDKhachHang")%>
     </h4>
     <p>
        <input mkv="true" id="IDKhachHang" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho2")%>
     </h4>
     <p>
        <input mkv="true" id="idkho2" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idnguoixuat")%>
     </h4>
     <p>
        <input mkv="true" id="idnguoixuat" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MaPhieu")%>
     </h4>
     <p>
        <input mkv="true" id="MaPhieu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
         </div>
         <a class="reload" onclick="loadTableAjaxchitietphieuxuatkho($.mkv.queryString('idkhoachinh'))"></a>
         <div id="tableAjax_chitietphieuxuatkho"   class="in-b">
             
         </div>
         </div><div class="body-div-button">
             <p class="in-a">
                 <%--<input  id="luu" edit="<%=StaticData.HavePermision(this, "phieuxuatkho_Edit") %>" add="<%=StaticData.HavePermision(this, "phieuxuatkho_Add") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> "
                      />
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                      />
                 <input  id="xoa" delete="<%=StaticData.HavePermision(this, "phieuxuatkho_Delete") %>" type="button" style="display:none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                      />
                 <input  id="timKiem" search="<%=StaticData.HavePermision(this, "phieuxuatkho_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" 
                      />--%>
             </p>
         </div>
 </asp:Content>

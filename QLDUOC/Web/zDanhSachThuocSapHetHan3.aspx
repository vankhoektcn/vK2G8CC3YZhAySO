 <%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="zDanhSachThuocSapHetHan3.aspx.cs" Inherits="zDanhSachThuocSapHetHan" Title="zDanhSachThuocSapHetHan" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/zDanhSachThuocSapHetHan3.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH THUỐC SẮP HẾT HẠN")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayXetHH")%>
     </h4>
     <p>
        <input mkv="true" id="NgayXetHH" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
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
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdKho")%>
     </h4>
     <p>
        <input mkv="true" id="IdKho" type="hidden" />
        <input mkv="true" id="mkv_IdKho" type="text" onfocus="Find(this);chuyenphim(this);IdKhoSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoNgay")%>
     </h4>
     <p>
        <input mkv="true" id="SoNgay" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoThang")%>
     </h4>
     <p>
        <input mkv="true" id="SoThang" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
         </div>
         <a class="reload" onclick="loadTableAjaxzDanhSachThuocSapHetHan_ChiTiet($.mkv.queryString('idkhoachinh'))"></a>
         <div id="tableAjax_zDanhSachThuocSapHetHan_ChiTiet"   class="in-b">
             
         </div>
         </div><div class="body-div-button">
             <p class="in-a">
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                      />
                 <input  id="timKiem" search="<%=StaticData.HavePermision(this, "zDanhSachThuocSapHetHan_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" 
                      />
             </p>
         </div>
 </asp:Content>

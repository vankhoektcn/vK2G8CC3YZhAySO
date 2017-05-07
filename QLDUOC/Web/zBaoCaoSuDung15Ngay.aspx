 <%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="zBaoCaoSuDung15Ngay.aspx.cs" Inherits="zBaoCaoSuDung15Ngay" Title="zBaoCaoSuDung15Ngay" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/zBaoCaoSuDung15Ngay.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BÁO CÁO 15 NGÀY SỬ DỤNG THUỐC/VTYT/HC")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NĂM")%>
     </h4>
     <p>
        <input mkv="true" id="nYear" type="text" onfocus="Find(this);chuyenphim(this);"  style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("THÁNG")%>
     </h4>
     <p>
        <input mkv="true" id="nMonth" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ĐẦU THÁNG")%>
     </h4>
     <p>
        <input mkv="true" id="IsDauThang" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
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
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc")%>
     </h4>
     <p>
        <input mkv="true" id="IdLoaiThuoc" type="hidden" />
        <input mkv="true" id="mkv_IdLoaiThuoc" type="text" onfocus="Find(this);chuyenphim(this);IdLoaiThuocSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
         </div></div>
         <div class="body-div-button">
             <p class="in-a">
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                  />
                 <input  id="xoa" type="button" style="display:none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                      />
                 <input  id="btnXuatExel" type="button" style="width:200px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Xuất Excel báo cáo") %>" 
                      />
             </p>
         </div>
 </asp:Content>

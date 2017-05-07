 <%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="HS_TONKHO_View3.aspx.cs" Inherits="HS_TONKHO_View" Title="HS_TONKHO_View" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/HS_TONKHO_View3.js">
     </script>
     <style>
        .jtable tr td input
        {
            color:#333!important;
            font-weight:bold;
            text-align:center;
        }
     </style>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BÁO CÁO NHẬP XUẤT TỒN")%>
           </p>
 <div class="in-a">
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
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
     </h4>
     <p>
        <input mkv="true" id="TuNgay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd/MM/yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
     </h4>
     <p>
        <input mkv="true" id="DenNgay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd/MM/yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiThuocID")%>
     </h4>
     <p>
        <input mkv="true" id="LoaiThuocID" type="hidden" />
        <input mkv="true" id="mkv_LoaiThuocID" type="text" onfocus="Find(this);chuyenphim(this);LoaiThuocIDSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IdThuoc")%>
     </h4>
     <p>
        <input mkv="true" id="IdThuoc" type="hidden" />
        <input mkv="true" id="TenThuoc" type="text" onfocus="Find(this);chuyenphim(this);IdThuocSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 
 <div class="div-Out" style="width:600px!important">
     <h4>
      Dạng báo biểu 
         
     </h4>
     <p style="width:75.5%!important">
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("S.Xếp ABC")%>
        <input mkv="true" id="IsOrderByName" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
         &nbsp; <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Có Đ.Giá")%>
        <input mkv="true" id="IsHaveDonGia" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
         &nbsp;  <%=hsLibrary.clDictionaryDB.sGetValueLanguage("IsSoLuong")%> <input mkv="true" id="IsSoLuong" type="checkbox" />  
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Rút gọn")%>  <input mkv="true" id="IsRutGon" type="checkbox"  />
     </p>
 </div>

          </div>
         <a class="reload" onclick="loadTableAjaxHS_TonKhoViewDetail($.mkv.queryString('idkhoachinh'))"></a>
         
         </div><div class="body-div-button">
             <p class="in-a">
                
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                      />
                 
                 <input  id="timKiem" search="<%=StaticData.HavePermision(this, "HS_TONKHO_View_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Lấy DS") %>"/>
                 <input  id="XUATEXCEL" search="<%=StaticData.HavePermision(this, "HS_TONKHO_View_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Xuất Excel") %>"/>
             </p>
         </div>
         <div id="tableAjax_HS_TonKhoViewDetail"   class="in-b">
         </div>
 </asp:Content>

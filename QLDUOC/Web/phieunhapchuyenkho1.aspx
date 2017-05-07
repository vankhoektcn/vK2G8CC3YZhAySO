 <%@ Page Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="phieunhapchuyenkho1.aspx.cs" Inherits="phieunhapchuyenkho1" Title="phieunhapchuyenkho1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/phieunhapchuyenkho1.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH PHIẾU NHẬP CHUYỂN KHO")%>
           </p>
 <div class="in-a">
 
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
     </h4>
     <p>
        <input mkv="true" id="TuNgay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 
 
 
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
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
        <input mkv="true" id="idkho" type="hidden" />
        <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);idkhoSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>

 
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc")%>
     </h4>
     <p>
        <input mkv="true" id="idthuoc" type="hidden" />
        <input mkv="true" id="mkv_idthuoc" type="text" onfocus="Find(this);chuyenphim(this);idthuocSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 
  <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số phiếu YC")%>
     </h4>
     <p>
        <input mkv="true" id="SOPHIEUYC" type="text" onfocus="Find(this);chuyenphim(this);"  style="width:90%"/>
     </p>
 </div>
 

         </div></div>
 <div class="body-div-button">
             <p class="in-a">
                 <input  id="luu" edit="<%=StaticData.HavePermision(this, "phieunhapkho_Edit") %>" add="<%=StaticData.HavePermision(this, "phieunhapkho_Add") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> "
                      />
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                      />
                 <input  id="xoa" delete="<%=StaticData.HavePermision(this, "phieunhapkho_Delete") %>" type="button" style="display:none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                      />
                 <input  id="timKiem" search="<%=StaticData.HavePermision(this, "phieunhapkho_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" 
                      />
             </p>
         <a class="reload" onclick="Find(this)"></a>
         <div  class="in-b" id="tableAjax_phieunhapkho">
         </div>
         </div>
 </asp:Content>

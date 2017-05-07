 <%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="DMNghiepVu.aspx.cs" Inherits="DMNghiepVu" Title="DMNghiepVu" %>

<%@ Register Src="Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_HeThongDanhMuc" TagPrefix="uc1" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../ketoan/javascript/DMNghiepVu.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<uc1:uscmenuKT_HeThongDanhMuc id="uscmenuKT_HeThongDanhMuc1" runat="server"></uc1:uscmenuKT_HeThongDanhMuc>
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TenNghiepVu")%>
                 
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiChungTu")%>
     </div>
     <div class="div-Right">
     <input type="hidden" id="quyenthem" value="<%=StaticData.HavePermision(this.Page, "KeToanDM_KTDM_DanhMucNghiepVu_Them")%>"/>
        <input mkv="true" id="MaNghiepVu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DienGiai")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TenNghiepVu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>
     </div>
     <div class="div-Right">
        <input mkv="true" id="LoaiChungTu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>
     </div>
     <div class="div-Right">
        <input mkv="true" id="DienGiai" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>

         </div></div>
 <div class="body-div-button">
 <div class="in-a">
            <a href = "KT_PhieuNhapKho.aspx"> <input id="<<" type="button" style="margin-right:10px" value="Quay Lại" /></a>
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </div>
       <a class="reload" onclick="Find(this)"></a>
         <div id="tableAjax_DMNghiepVu" style="overflow:auto"  class="in-b">
         </div>
 <div class="in-c">
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </div>
         </div>
 </asp:Content>

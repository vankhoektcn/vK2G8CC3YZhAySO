 <%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="KTDM_DanhMucNghiepVu.aspx.cs" Inherits="DMNghiepVu" Title="DMNghiepVu" %>

<%@ Register Src="Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_HeThongDanhMuc"
    TagPrefix="uc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="javascript/KTDM_DanhMucNgiepVu.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Danh Mục Nghiệp Vụ")%>
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã Nghiệp Vụ:")%>
     </div>
     <div class="div-Right">
         &nbsp;<uc1:uscmenuKT_HeThongDanhMuc ID="UscmenuKT_HeThongDanhMuc1" runat="server" />
         <input type="hidden" id="quyenthem" value="<%=StaticData.HavePermision(this.Page, "KeToanDM_KTDM_DanhMucNghiepVu_Them")%>"/>
         <input type="hidden" id="quyensua" value="<%=StaticData.HavePermision(this.Page, "KeToanDM_KTDM_DanhMucNghiepVu_Sua")%>"/>
        <input mkv="true" id="MaNghiepVu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên Nghiệp Vụ:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TenNghiepVu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Diễn Giải:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="DienGiai" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tiếp Đầu Ngữ:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TiepDauNgu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
        <input mkv="true" id="SoCT_hientai" type="hidden" onfocus="Find(this);chuyenphim(this);" onblur="testsoct1(this);" onfocusout='' style="width:90%"/>
     </div>
 </div>
 <%--<div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số CT Hiện Tại:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="SoCT_hientai" type="text" onfocus="Find(this);chuyenphim(this);" onblur="testsoct1(this);" onfocusout='' style="width:90%"/>
     </div>
 </div>--%>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK Nợ:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TKNo" type="text" onfocus="Find(this);chuyenphim(this);ShowTaiKhoan(this.id);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK Có:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TKCo" type="text" onfocus="Find(this);chuyenphim(this);ShowTaiKhoan(this.id);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK Thuế:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TKThue" type="text" onfocus="Find(this);chuyenphim(this);ShowTaiKhoan(this.id);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK Chiết Khấu:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="tkck" type="text" onfocus="Find(this);chuyenphim(this);ShowTaiKhoan(this.id);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("VAT:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="VAT" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </div>
 </div>
         </div></div>
 <div class="body-div-button">
 <div class="in-a">
             <%--<input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />--%>
             <input type="button" id="Save" disabled="<%=StaticData.HavePermision(this, "KeToanDM_KTDM_DanhMucNghiepVu_Them") %>" value="Lưu" onclick="SaveDMNV();" />
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </div>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_DMNghiepVu">
         </div>
 <div class="in-c">
                     <input id="luuTable_2" type="button" disabled="<%=StaticData.HavePermision(this, "KeToanDM_KTDM_DanhMucNghiepVu_Sua")%>" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Lưu") %>'/>
                     
                 </div>
         </div>
 </asp:Content>

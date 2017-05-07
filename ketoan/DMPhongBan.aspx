 <%@ Page Language="C#" MasterPageFile="~/MasterPage_NEW.master" AutoEventWireup="true" CodeFile="DMPhongBan.aspx.cs" Inherits="PhongBan" Title="PhongBan" %>

<%@ Register Src="Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_HeThongDanhMuc"
    TagPrefix="uc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../ketoan/javascript/PhongBan.js">
function maphongban_onclick() {

}

     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PhongBan")%>
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("maphongban")%>
     </div>
     <div class="div-Right">
         <uc1:uscmenukt_hethongdanhmuc id="UscmenuKT_HeThongDanhMuc1" runat="server"></uc1:uscmenukt_hethongdanhmuc>
         <br />
         <input type="hidden" id="quyenthem" value="<%=StaticData.HavePermision(this.Page, "KeToanDM_DMPhongBan_Them")%>"/>
        <input mkv="true" id="maphongban" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%" onclick="return maphongban_onclick()"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenphongban")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="tenphongban" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ghichu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("status")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="status" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
     </div>
 </div>
         </div></div>
 <div class="body-div-button">
 <div class="in-a">
             <a href = "index1.aspx"> <input id="<<" type="button" style="margin-right:10px" value="Quay Lại" /></a>
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </div>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_PhongBan">
         </div>
 <div class="in-c">
                     <input id="luuTable_2" disabled="<%=StaticData.HavePermision(this.Page, "KeToanDM_DMPhongBan_Them") %>" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </div>
         </div>
 </asp:Content>

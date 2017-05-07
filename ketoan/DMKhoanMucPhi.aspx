 <%@ Page Language="C#" MasterPageFile="~/MasterPage_NEW.master" AutoEventWireup="true" CodeFile="DMKhoanMucPhi.aspx.cs" Inherits="DMKhoanMucPhi" Title="DMKhoanMucPhi" %>

<%@ Register Src="Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_Duoc" TagPrefix="uc1" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../ketoan/javascript/DMKhoanMucPhi.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
 <uc1:uscmenukt_duoc id="UscmenuKT_Duoc1" runat="server"></uc1:uscmenukt_duoc>
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DMKhoanMucPhi")%>
                
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ma_phi")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ma_phi" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ten_phi")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ten_phi" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loai_tien")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="loai_tien" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ghi_chu")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ghi_chu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ten_phi2")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ten_phi2" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
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
         <div class="in-b" id="tableAjax_DMKhoanMucPhi">
         </div>
 <div class="in-c">
                     <input id="luuTable_2"  disabled="<%=StaticData.HavePermision(this.Page, "KeToanD_DMKhoanMucPhi_Them") %>" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                 </div>
         </div>
 </asp:Content>

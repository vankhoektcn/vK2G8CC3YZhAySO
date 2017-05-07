 <%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="DMNgoaiTe.aspx.cs" Inherits="DMNgoaiTe" Title="DMNgoaiTe" %>

<%@ Register Src="Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_HeThongDanhMuc" TagPrefix="uc2" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../ketoan/javascript/DMNgoaiTe.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Danh Mục Ngoại Tệ")%>
             </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã NT:")%>
     </div>
     <div class="div-Right">
         &nbsp;<uc2:uscmenukt_HeThongDanhMuc id="UscmenuKT_Duoc1" runat="server"></uc2:uscmenukt_HeThongDanhMuc><br />
         <input type="hidden" id="quyenthem" value="<%=StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Them")%>"/>
         <input type="hidden" id="quyensua" value="<%=StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Sua")%>"/>
        <input mkv="true" id="ma_nt" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ten NT:") %>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ten_nt" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày:") %>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ngay" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tỷ giá:") %>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ty_gia" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
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
         <div class="in-b" id="tableAjax_DMNgoaiTe">
         </div>
 <div class="in-c">
                     <input id="luuTable_2" type="button" disabled="<%=StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Them") %>" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </div>
         </div>
 </asp:Content>

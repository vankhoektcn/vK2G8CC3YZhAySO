 <%@ Page Language="C#" MasterPageFile="~/MasterPage_NEW.master" AutoEventWireup="true" CodeFile="DMCCDC-TSCD.aspx.cs" Inherits="DanhMucCCDC" Title="DanhMucCCDC" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../ketoan/javascript/DanhMucCCDC-TSCD.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DanhMucCCDC")%>
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ma_ccdc")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ma_ccdc" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ten_ccdc")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ten_ccdc" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hang_sx")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="hang_sx" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nam_sx")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="nam_sx" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nguyen_gia")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="nguyen_gia" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngay_nhap")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ngay_nhap" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngay_het_han")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ngay_het_han" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tk_ccdc")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="Tk_ccdc" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tk_doi_ung")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="Tk_doi_ung" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CCDC")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="CCDC" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TSCD")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TSCD" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ma_pb")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ma_pb" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ten_pb")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ten_pb" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
         </div></div>
 <div class="body-div-button">
 <div class="in-a">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </div>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_DanhMucCCDC">
         </div>
 <div class="in-c">
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </div>
         </div>
 </asp:Content>

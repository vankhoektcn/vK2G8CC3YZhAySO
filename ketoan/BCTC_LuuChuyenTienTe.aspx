 <%@ Page Language="C#" MasterPageFile="~/MasterPage_kt2.master" AutoEventWireup="true" CodeFile="BCTC_LuuChuyenTienTe.aspx.cs" Inherits="BCTC_LuuChuyenTienTe" Title="BCTC_LuuChuyenTienTe" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../ketoan/javascript/luuchuyentiente2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <div class="header-div">
               LƯU CHUYỂN TIỀN TỆ
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left">
         Chỉ tiêu
     </div>
     <div class="div-Right">
        <input mkv="true" id="chitieu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         Mã số
     </div>
     <div class="div-Right">
        <input mkv="true" id="maso" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         Thuyết minh
     </div>
     <div class="div-Right">
        <input mkv="true" id="thuyetminh" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         DSTK Nợ
     </div>
     <div class="div-Right">
        <input mkv="true" id="dstk_no" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         DSTK Có
     </div>
     <div class="div-Right">
        <input mkv="true" id="dstk_co" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         In đậm
     </div>
     <div class="div-Right">
        <input mkv="true" id="bold" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
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
         <div class="in-b" id="tableAjax_luuchuyentiente">
         </div>
 <div class="in-c">
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </div>
         </div>
 </asp:Content>

 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true" CodeFile="HS_DANHSACHTRAKQCLS2.aspx.cs" Inherits="HS_DANHSACHTRAKQCLS" Title="HS_DANHSACHTRAKQCLS" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/HS_DANHSACHTRAKQCLS2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH SÁCH BỆNH NHÂN TRẢ KQCLS")%>
           </p>
 <div class="in-a">
  
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYTHU")%>
     </h4>
     <p>
        <input mkv="true" id="NGAYTHU" type="text" onblur="TestDate(this);"  onfocus='Find(this);' style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MABENHNHAN")%>
     </h4>
     <p>
        <input mkv="true" id="MABENHNHAN" type="text" onfocus='Find(this);' style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TENBENHNHAN")%>
     </h4>
     <p>
        <input mkv="true" id="TENBENHNHAN" type="text" onfocus='Find(this);' style="width:90%"/>
     </p>
 </div>
   
         </div></div>
 <div class="body-div-button">
 <p class="in-a">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" search="<%=StaticData.HavePermision(this, "HS_DANHSACHTRAKQCLS_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </p>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_HS_DANHSACHTRAKQCLS">
         </div>
 <p class="in-c">
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>

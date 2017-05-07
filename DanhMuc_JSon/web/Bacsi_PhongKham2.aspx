 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true" CodeFile="Bacsi_PhongKham2.aspx.cs" Inherits="Bacsi_PhongKham" Title="Bacsi_PhongKham" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/Bacsi_PhongKham2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Bacsi_PhongKham")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idbacsi")%>
     </h4>
     <p>
        <input mkv="true" id="idbacsi" type="hidden" />
        <input mkv="true" id="mkv_idbacsi" type="text" onfocus="Find(this);idbacsiSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idphongkhambenh")%>
     </h4>
     <p>
        <input mkv="true" id="idphongkhambenh" type="hidden" />
        <input mkv="true" id="mkv_idphongkhambenh" type="text" onfocus="Find(this);idphongkhambenhSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
         </div></div>
 <div class="body-div-button">
 <p class="in-a">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" search="<%=Userlogin_new.HavePermision(this, "Bacsi_PhongKham_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </p>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_Bacsi_PhongKham">
         </div>
 <p class="in-c">
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>

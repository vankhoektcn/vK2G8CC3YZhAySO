 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true" CodeFile="KB_Phong2.aspx.cs" Inherits="KB_Phong" Title="KB_Phong" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/KB_Phong2.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DANH MỤC PHÒNG KHÁM")%>
           </p>
 <div class="in-a">
   <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Khoa ")%>
                </h4>
                <p>
                          <select id="IdKhoa" mkv="true" onfocus="chuyenphim(this);" style="width: 80%;">     </select>

                </p>
            </div>
            
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Chuyên khoa")%>
     </h4>
     <p>
        <input mkv="true" id="DichVuKCB" type="hidden" />
        <input mkv="true" id="mkv_DichVuKCB" type="text" onfocus="Find(this);DichVuKCBSearch(this);" class="down_select" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TenPhong")%>
     </h4>
     <p>
        <input mkv="true" id="TenPhong" type="text" onfocus='Find(this);' style="width:90%"/>
     </p>
 </div>
 
   
         </div></div>
 <div class="body-div-button">
 <p class="in-a">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" search="<%=StaticData.HavePermision(this, "KB_Phong_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </p>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_KB_Phong">
         </div>
 <p class="in-c">
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>

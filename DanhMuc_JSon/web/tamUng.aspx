 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage_nomenu.master" AutoEventWireup="true" CodeFile="tamUng.aspx.cs" Inherits="tamUng" Title="tamUng" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/tamUng.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tamUng")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sotien")%>
     </h4>
     <p>
        <input mkv="true" id="sotien" type="text" onfocus='Find(this);' onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngayTamung")%>
     </h4>
     <p>
        <input mkv="true" id="ngayTamung" type="text" onfocus='Find(this);' onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LyDoTU")%>
     </h4>
     <p>
        <input mkv="true" id="LyDoTU" onfocus='Find(this);' type="text" style="width:90%"/>
     </p>
 </div>
         </div></div>
         <div class="body-div-button">
             <p class="in-a">
                 <input  id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ");"
                      />
                 <input  id="xoa" type="button" style="display:none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                      />
                 <input  id="Print" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Print") %>" 
                      />
             </p>
         </div>
 </asp:Content>

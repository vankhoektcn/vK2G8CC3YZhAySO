 <%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="DSManHinh.aspx.cs" Inherits="DSManHinh" Title="DSManHinh" %>

<%@ Register Src="Menu_KT/uscmenuKT_HeThongDanhMuc.ascx" TagName="uscmenuKT_HeThongDanhMuc"
    TagPrefix="uc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../ketoan/javascript/DSManHinh.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Danh Sách Màn Hình") %>
           </div>
<br /><br />
<br /><br /><br />
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_DSManHinh" style ="overflow:auto">
         </div>

</div>
 <div class="body-div-button">
 <div class="in-a">
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
     <uc1:uscmenukt_hethongdanhmuc id="UscmenuKT_HeThongDanhMuc1" runat="server"></uc1:uscmenukt_hethongdanhmuc>
             <input  id="timKiem" type="button" value="Làm Mới"
                       />
             </div>
         </div>
 </asp:Content>

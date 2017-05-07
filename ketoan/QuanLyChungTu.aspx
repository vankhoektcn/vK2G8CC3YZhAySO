<%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="QuanLyChungTu.aspx.cs" Inherits="ketoan_QuanLyChungTu" Title="Untitled Page" %>

<%@ Register Src="Uc_Menu.ascx" TagName="Uc_Menu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">  
<table width = 100%>
<tr>
    <td align ="center" style="width: 867px">
        <br />
        <br />
        <uc1:uc_menu id="Uc_Menu1" runat="server"></uc1:uc_menu>
         <div class="body-div"> 
           <div class="header-div" style="left: -15px; top: 59px; height: 70px">             
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Danh Sách Chứng Từ")%>
           </div>
        <br />
        <br />
             <br />
             <br />
        <asp:GridView ID="GViewChungTu" runat="server" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        </div>
    </td>
</tr>
</table>
</asp:Content>


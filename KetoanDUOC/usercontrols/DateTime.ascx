<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateTime.ascx.cs" Inherits="usercontrols_DateTime" %>
<div id="divDefaultOut" runat="server" class="divDefaultOut">
    <div id="divInDefaultLeft" runat="server" class="divInDefaultLeft">
        <asp:Label ID="lbdefault" runat="server" Text="NotTitle"></asp:Label></div>
    <div id="divInDefaultRight" runat="server" class="divInDefaultRight">
        <asp:Label ID="lbBeforeText" runat="server"></asp:Label>
        <asp:TextBox runat="server" ID="txtDefault" ></asp:TextBox>
        <asp:Label ID="lbAfterText" runat="server"></asp:Label>
    </div>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckBox.ascx.cs" Inherits="usercontrols_CheckBox" %>
<div id="divDefaultOut" runat="server" class="divDefaultOut">
    <div id="divInDefaultLeft" runat="server" class="divInDefaultLeft">
        <asp:Label ID="lbdefault" runat="server" Text="NotTitle"></asp:Label></div>
    <div id="divInDefaultRight" runat="server" class="divInDefaultRight">
        <asp:Label ID="lbBeforeCheckBox" runat="server"></asp:Label>
        <input id="cbDefault" type="checkbox" runat="Server" />
        <asp:Label ID="lbAfterCheckBox" runat="server"></asp:Label>
    </div>
</div>
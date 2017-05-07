<%@ Control Language="C#" AutoEventWireup="true" CodeFile="droplist.ascx.cs" Inherits="usercontrols.Droplist" %>
<div id="divDefaultOut" runat="server" class="divDefaultOut">
    <div id="divInDefaultLeft" runat="server" class="divInDefaultLeft">
        <asp:Label ID="lbdefault" runat="server" Text="NotTitle"/></div>
    <div id="divInDefaultRight" runat="server" class="divInDefaultRight">
        <asp:Label ID="lbBeforeDroplist" runat="server"/>
        <asp:DropDownList ID="dlDefault" runat="server" OnSelectedIndexChanged="dlDefault_SelectedIndexChanged"/>
        <asp:Label ID="lbAfterDroplist" runat="server"/>
    </div>
</div>
<div id="divList" runat="server"/>

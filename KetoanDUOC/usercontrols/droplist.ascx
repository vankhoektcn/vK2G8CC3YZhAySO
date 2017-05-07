<%@ Control Language="C#" AutoEventWireup="true" CodeFile="droplist.ascx.cs" Inherits="droplist" %>
    <div style="float: left; padding: 10px 0px 10px 0px">
        <asp:Label ID="lbdefault" runat="server" Text=""></asp:Label>:</div>
    <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
        <select id="default" name="default" runat="server">
        </select>
    </div>
<div runat="server" id="divList" ></div>

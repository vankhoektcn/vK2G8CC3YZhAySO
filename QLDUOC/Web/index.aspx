<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file = "header.htm" -->
<form id="Form1" method="post" runat="server">
        <asp:PlaceHolder ID="pMain" runat="server"></asp:PlaceHolder>   
        <div id="divIndex" class="IndexTitle">HỆ THỐNG PHẦN MỀM QUẢN LÝ BỆNH VIỆN</div>
        <div id="divPhanHe" class="IndexTitle" runat="server" style="top:8%;color:Red;text-align:center;"></div>
</form>
<!--#include file = "footer.htm" -->

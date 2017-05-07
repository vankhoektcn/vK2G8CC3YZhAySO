<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inHopDong.aspx.cs" Inherits="quanlynhansu_inHopDong" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file = "header.htm" -->
<body>
<form id="form1" runat="server">
<div id="MyPage">
    <div id="Menu">
	    <uc1:uscmenu ID="Uscmenu1" runat="server" />
	</div>
	<div id="header">
		In hợp đồng
	</div>
	<div id="NoiDung">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" BackColor="white" runat="server" AutoDataBind="true" OnUnload="CrystalReportViewer1_Unload" />
	</div>
</div>
</form>
<!--#include file = "footer.htm" -->

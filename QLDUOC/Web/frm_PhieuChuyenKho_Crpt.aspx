<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_PhieuChuyenKho_Crpt.aspx.cs" Inherits="frm_PhieuChuyenKho_Crpt" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
 
<form id="Form1" runat = "server">
<table border="0" cellpadding="1" cellspacing="1" width="1000" id = "user" bgcolor = "#D3D0C9">
    <tr>
        <td align = "left" valign = "top" style="height: 34px" bgcolor = "#EAEBE6">
        </td>
    </tr>
    <tr>
        <td id="tabviewtop" width="100%" class = "header">
	        IN PHIẾU XUÂT THUỐC</td>
    </tr>
    <tr>
        <td align="center" width="100%">
            PHIẾU XUẤT THUỐC</td>
    </tr>
    <TR>
        <TD width="100%">
            <CR:CrystalReportViewer ID="CrystalReportViewer1"  runat="server" AutoDataBind="true" DisplayGroupTree="False" PrintMode="ActiveX"  />
            
        </TD>
    </TR>
    </table>
   </form>

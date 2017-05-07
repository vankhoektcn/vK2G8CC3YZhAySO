<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_rpt_DongChiTra.aspx.cs" Inherits="frm_rpt_InPhieuThuTH" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="~/VienPhi_TH/uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
 

<!--#include file ="header.htm"-->
<script language = "javascript">
</script>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" >
    <tr>
        <td width = "100%" align = "left" >
           
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" >
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px; width: 100%;">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px; height: 118px;">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style ="background-color: #4D67A2">
			                <span class="title" style ="color:#FFFFFF">IN PHIEU THU</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
					    </TD>
				    </TR>
			    </table>
                &nbsp;<br />
                <CR:CrystalReportViewer ID="crptView" runat="server" AutoDataBind="true" DisplayGroupTree="False" PrintMode="ActiveX" />
		    </td>
	    </tr>				
    </table>
        </td>
       </tr>
     </table>    
 </form>
<!--#include file ="footer.htm"-->

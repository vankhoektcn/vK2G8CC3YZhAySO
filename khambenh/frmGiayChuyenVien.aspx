<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmGiayChuyenVien.aspx.cs" Inherits="khambenh_frmGiayChuyenVien" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--#include file ="header.htm"-->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
	 
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
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style="background-color: #4D67A2; height: 21px;">
			                <span class="title" style ="color:#FFFFFF">GIẤY CHUYỂN VIỆN</span></td>
				    </tr>
				    <TR>
					    <TD width="100%" style="height: 21px">
					    </TD>
				    </TR>
			    </table>
              
                <CR:CrystalReportViewer OnUnload="crptView_Unload"  BackColor="WHITE" ID="R" runat="server" AutoDataBind="true" PrintMode="ActiveX" HasToggleGroupTreeButton="False" DisplayGroupTree="False"/>
              
		    </td>
	    </tr>				
    </table>
        </td>
       </tr>
     </table>    
 </form>
<!--#include file ="footer.htm"-->
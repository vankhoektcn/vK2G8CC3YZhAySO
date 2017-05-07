<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NVK_inchidinhLamsan_NoiTru.aspx.cs" Inherits="NVK_inchidinhLamsan_NoiTru" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="../khoanoi/uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>

<!--#include file ="../noitru/header.htm"-->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />

<script src="../js/jquery-1.6.1.min.js" type="text/javascript"> </script>
<script src="../js/jquery-ui.js" type="text/javascript"> </script>
<script src="../noitru/js/nvk_SessionPrint.js" type="text/javascript"> </script>
<script src="../js/myscript.jqr.js" type="text/javascript"> </script>
    
<script type="text/javascript">
window.onload = function () 
	{
	    StartPrint();
	}
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
				        <td class="title" align = "center" style ="background-color: #4D67A2">
			                <span class="title" style ="color:#FFFFFF">PHIẾU CHỈ ĐỊNH CẬN LÂM SÀNG</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
					    </TD>
				    </TR>
			    </table>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    DisplayGroupTree="False" PrintMode="ActiveX" Width="99%" OnUnload="CrystalReportViewer1_Unload" />
                <br />
                <CR:CrystalReportViewer ID="Ctrhuehongbs" runat="server" AutoDataBind="true" DisplayGroupTree="False"
                    PrintMode="ActiveX" Width="99%" OnUnload="Ctrhuehongbs_Unload" />
                <input type="image" id="nvk_print" name="CrystalReportViewer1$ctl02$ctl01" title="Print"
         src="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/print.gif"
          onmouseover="this.src='/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/print_over.gif'"
           onmouseout="this.src='/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/print.gif'"
            style="height:22px;width:22px;border-width:0px;" />
		    </td>
	    </tr>				
    </table>
        </td>
       </tr>
     </table>    
 </form>
<!--#include file ="../noitru/footer.htm"-->

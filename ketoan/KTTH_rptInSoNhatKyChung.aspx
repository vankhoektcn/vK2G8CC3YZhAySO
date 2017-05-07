<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTH_rptInSoNhatKyChung.aspx.cs" Inherits="ketoan_KTTH_rptInSoNhatKyChung" %>
<!--#include file = "header.htm" -->
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TongHop.ascx" TagName="uscmenuKT_TongHopSNKC" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<%@ Register Assembly="CrystalDecisions.Web,  Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />

<script language = "javascript" type="text/javascript">
    function TestDatePhieu(t)
	{
		if (t.value != "")
		{
			t.value=AddString(t.value);  
			if (isDate(t.value)==false)
			{
				t.value="";
				alert("Bạn nhập ngày tháng không hợp lệ ! ");
				t.focus();
			}
		}
		return;
	}
</script>


<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" >    
    <tr>
        <td width = "100%" align = "left" class="bg_menu">
            <uc1:uscmenuKT_TongHopSNKC ID="uscmenuKT_TongHopSNKC1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" >
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px; width: 100%;">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px" bgcolor="#FFFFFF">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style ="background-color: #4D67A2">
			                <span class="title" style ="color:#FFFFFF">IN SỔ NHẬT KÝ CHUNG</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
					    </TD>
				    </TR>
			    </table>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    DisplayGroupTree="False" PrintMode="ActiveX" Width="99%" OnUnload="CrystalReportViewer1_Unload" />
		    </td>
	    </tr>				
    </table>
        </td>
       </tr>
     </table>    
 </form>


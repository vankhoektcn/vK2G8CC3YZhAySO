<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscMenu.ascx.cs" Inherits="uscMenu" %>
<table width = "100%" cellpadding = "0" cellspacing = "0" border = "0">
    <tr>
        <td align = "left" valign = "top" style="height: 34px">
        <asp:PlaceHolder ID="menu" runat=server></asp:PlaceHolder>
            &nbsp;</td>
    </tr>
    <tr>
	    <td width="100%" align="center">
	        <span class="ajax" id="ajaxsodu" style="display:none;color:White;font-weight:bold;">
	            <img src="../images/processing.gif" alt="../images/processing.gif" border="0"/>&nbsp;&nbsp; 
	        </span>
	    </td>
	</tr>
</table>


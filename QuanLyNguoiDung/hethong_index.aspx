<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hethong_index.aspx.cs" Inherits="hethong_index" %>

<%@ Register Src="menu_HeThong.ascx" TagName="menu_HeThong" TagPrefix="uc2" %>
<!--#include file = "header_hethong.htm" -->
<form id="Form1" method="post" runat="server"> 
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
            <uc2:menu_HeThong ID="Menu_HeThong1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user" class = "khung">
                <tr>
		            <td class="title" align = "left" style ="background-color: #4D67A2">
	                    <span class="title" style ="color:#FFFFFF">PHÂN HỆ QUẢN LÝ NGƯỜI DÙNG</span>&nbsp;</td>
		        </tr>
                <tr>
                    <td id = "noidungnewfile" align = "center" valign = "middle">
                        <img src="../images/QLBV.jpg" />
                    </td>
                </tr>
            </table>
          </td>
     </tr>
</table>
</form>          
<!--#include file = "footer.htm" -->

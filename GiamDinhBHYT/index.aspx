<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file = "header.htm" -->
<form id="Form1" method="post" runat="server"> 
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td >
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
            
        </td>
    </tr>
   
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="1" cellpadding="1" cellspacing="1" width="100%" id="user" style="margin-top:18px; border:1px solid #ddd">
                <tr>
		            <td class="title" align = "left" style ="background-color: #4D67A2">
	                    <span class="title" style ="color:#FFFFFF"> PHÂN HỆ QUẢN LÝ NGƯỜI DÙNG</span>
                    </td>
		        </tr>
                <tr>
                    <td id = "noidungnewfile" align = "center" valign = "middle">
                        <img src="../images/QLBV.jpg" width="100%" height="95%"  />
                    </td>
                </tr>
            </table>
          </td>
     </tr>
</table>
</form>          
<!--#include file = "footer.htm" -->

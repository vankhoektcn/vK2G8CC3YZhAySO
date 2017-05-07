<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file = "header.htm" -->
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#FBF8F1; height: 19px;">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                    <td width = "100%" class = "header">PHÂN HỆ QUẢN LÝ NHÂN SỰ</td>
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

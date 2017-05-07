<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ketoanhoadondichvu.aspx.cs" Inherits="ketoan_ketoanhoadondichvu" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HoaDonDV.ascx" TagName="menu_hodondichvu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #007138">
    <tr>
        <td width = "100%" align = "left" class="bg_menu">
            <uc1:menu_hodondichvu ID="menu_hodondichvu" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" >&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" >
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                    <td width = "100%" class = "header"> QUẢN LÝ: KẾ TOÁN HÓA ĐƠN DỊCH VỤ</td>
                </tr>
                <tr>
                    <td id = "noidungnewfile" align = "center" valign = "middle">
                        <img src="../ketoan/images/pageindex_.png" />
                    </td>
                </tr>
            </table>
         </td>
        </tr>
      </table>
   </form> 
   </body>
</html>

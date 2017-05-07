<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ketoancongcudungcu.aspx.cs" Inherits="ketoan_ketoancongcudungcu" %>

<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_CCDC.ascx" TagName="uscmenuKT_CCDC" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<!--#include file ="header.htm"-->
<body>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #007138">
    <tr>
        <td width = "100%" align = "left" class="bg_menu">
            <uc1:uscmenuKT_CCDC ID="uscmenuKT_CCDC" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" >&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" >
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                    <td width = "100%" class = "header">PHẦN MỀM QUẢN LÝ: KẾ TOÁN DƯỢC </td>
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

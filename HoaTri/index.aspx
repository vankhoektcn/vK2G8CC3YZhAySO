<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="HoaTri_index" %>
<%@ Register Src="~/HoaTri/uscmenu_HoaTri.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file = "header.htm" -->
<%--#C0C0C0,#D4DDDD--%>
<form id="Form1" method="post" runat="server" style="background-color:Black">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: Black">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4DDDD">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                    <td width = "100%" class = "header" style ="background-color:#4D67A2"><span class="title" style ="color:#D4D0C8">PHÒNG HÓA TRỊ</span></td>
                </tr>
                <tr>
                    <td id = "noidungnewfile" align = "center" valign = "middle">
                        <img src="../images/HinhNenNoiTru.jpg" />
                    </td>
                </tr>
            </table>
         </td>
        </tr>
      </table>
   </form>         
<!--#include file = "footer.htm" -->

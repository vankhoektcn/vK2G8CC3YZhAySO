<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCaoTaiChinh.aspx.cs" Inherits="BaoCaoTaiChinh" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_BaoCaoTaiChinh.ascx" TagName="uscmenuKT_BaoCaoTaiChinh" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<!--#include file = "header.htm" -->
<%@ Register Src="menu_baocaotaichinh.ascx" TagName="menu_baocaotaichinh" TagPrefix="uc2" %>

<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:uscmenuKT_BaoCaoTaiChinh id="uscmenuKT_BaoCaoTaiChinh" runat="server">
            </uc1:uscmenuKT_BaoCaoTaiChinh>
            </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                    <td width = "100%" class = "header">PHẦN MỀM QUẢN LÝ: BÁO CÁO TÀI CHÍNH</td>
                </tr>
                <tr>
                    <td id = "noidungnewfile" align = "center" valign = "middle">
                        <img src="../images/pageindex_.png" />
                    </td>
                </tr>
            </table>
         </td>
        </tr>
      </table>
   </form>         
<!--#include file = "footer.htm" -->

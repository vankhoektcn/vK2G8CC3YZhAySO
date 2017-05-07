<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCaoVATDauVao.aspx.cs" Inherits="BaoCaoVATDauVao" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_BaoCaoThue.ascx" TagName="uscmenuKT_BaoCaoThue" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<!--#include file ="header.htm"-->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />

<%@ Register Assembly="CrystalDecisions.Web,  Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<script language = "javascript">
var dp_cal, dp_cals;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgay'));
	    dp_cals = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	     LoadTieuDe();
	};
	function LoadTieuDe()
    {
        var obj = document.getElementById("tieudepk");
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                obj.innerHTML = value;                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=LoadTieuDe&times="+Math.random(),true);
        xmlHttp.send(null);
    }
  
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
        <td align = "left" valign = "top" style="height: 34px" bgcolor = "#EAEBE6">
            <uc1:uscmenuKT_BaoCaoThue ID="uscmenuKT_BaoCaoThue" runat="server" />
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
			                <span class="title" style ="color:#FFFFFF">BÁO CÁO VAT ĐẦU VÀO</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
                            Tháng:&nbsp;
                            <asp:dropdownlist id="ddlTuThang" runat="server"><asp:ListItem Value="01">1</asp:ListItem>
<asp:ListItem Value="02">2</asp:ListItem>
<asp:ListItem Value="03">3</asp:ListItem>
<asp:ListItem Value="04">4</asp:ListItem>
<asp:ListItem Value="05">5</asp:ListItem>
<asp:ListItem Value="06">6</asp:ListItem>
<asp:ListItem Value="07">7</asp:ListItem>
<asp:ListItem Value="08">8</asp:ListItem>
<asp:ListItem Value="09">9</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
<asp:ListItem>11</asp:ListItem>
<asp:ListItem>12</asp:ListItem>
</asp:dropdownlist>
 
                            &nbsp; &nbsp;<asp:button id="btnXem" runat="server" onclick="btnXem_Click" text="Xem báo cáo" />&nbsp;                            
				    </TR>
			    </table>
		    </td>
	    </tr>				
    </table>
        </td>
       </tr>
     </table>    
 </form>
<!--#include file ="footer.htm"-->
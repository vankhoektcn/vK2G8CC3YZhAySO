﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoQuyTM.aspx.cs" Inherits="SoQuyTM" %>
<!--#include file ="header.htm"-->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />    
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>


<%@ Register Src="uscmenuKT_TienMat.ascx" TagName="uscmenuKT_TienMat" TagPrefix="uc2" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<script language = "javascript">
var dp_cal, dp_cals;      
	window.onload = function () 
	{
	     LoadTieuDe();
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgay'));
	    dp_cals = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
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
	function ShowTaiKhoan(Ctr)
{
    var obj = Ctr.id;
    var objsrc = document.getElementById(obj);
  
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);
                                                             //   document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,idText)
{
      if(idText!="")
      {
          var txtTaiKhoan=document.getElementById(idText);
          txtTaiKhoan.value=MaTaiKhoan;
          txtTaiKhoan.focus();
      }
}

function TestMaTaiKhoan(Ctr)
{
    var txtTaiKhoan = Ctr.id;
    var MaTaiKhoan = document.getElementById(txtTaiKhoan);
    if(MaTaiKhoan.value!="")
    {
        xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="1")
                      {  
                         alert("Tài khoản bạn chọn chưa có trong danh mục tài khoản. Vui lòng kiểm tra lại. Cảm ơn!");
                         MaTaiKhoan.value ="";
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TestMaTaiKhoan&Key="+MaTaiKhoan.value+"&times="+Math.random(),true);
            xmlHttp.send(null);
    }
}

</script>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" >
    <tr>
        <td align = "left" valign = "top" style="height: 34px" bgcolor = "#EAEBE6">
            <uc2:uscmenuKT_TienMat ID="uscmenuKT_TienMat1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left">&nbsp;</td>
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
			                <span class="title" style ="color:#FFFFFF">SỔ QUỸ TIỀN MẶT</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
                            Từ ngày:
                            <asp:textbox id="txtNgay" runat="server" height="20px" tabindex="2" width="149px"></asp:textbox>
                            đến ngày:
                            <asp:textbox id="txtDenNgay" runat="server" height="20px" tabindex="2" width="149px"></asp:textbox>
                            &nbsp;Tài khoản:
                            <asp:dropdownlist id="ddl_tk" runat="server" width="130"></asp:dropdownlist>
                            <asp:button id="btnXem" runat="server" onclick="btnXem_Click" text="Xem báo cáo" /></TD>
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
<!--#include file ="footer.htm"-->
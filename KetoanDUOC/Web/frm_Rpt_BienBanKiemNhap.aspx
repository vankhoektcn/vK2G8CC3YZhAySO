<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Rpt_BienBanKiemNhap.aspx.cs" Inherits="frm_Rpt_BienBanKiemNhap" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<!-- #include file="header.htm" -->
<%@ Register Src="uscMenu.ascx" TagName="uscMenu" TagPrefix="uc1" %>
<script language = "javascript">
   var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
	  dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal= new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	};
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
	function checkvalid()
	{
	    var ncc = document.getElementById("ddlncc");
	    var tungay = document.getElementById("txtTuNgay");
	    var denngay = document.getElementById("txtDenNgay");
	    if(ncc.value == "0" || ncc.value == "")
	    {
	        alert("Vui lòng chọn nhà cung cấp!");
	        ncc.focus();
	        return false;
	    }
	    if(tungay.value == "")
	    {
	        alert("Vui lòng chọn ngày!");
	        tungay.focus();
	        return false;
	    }
	    if(denngay.value == "")
	    {
	        alert("Vui lòng chọn ngày!");
	        denngay.focus();
	        return false;
	    }
	    return true;
	}
</script>
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
        <td width = "100%" align = "center" style ="background-color:#D4D0C8">
        <table cellspacing="1" cellpadding="1" width="98%" border="0" class = "khung">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px" align="center">
			    <table id="user" cellSpacing="0" cellPadding="0" width="100%" border="0">
				    <tr>
				        <td class="title" colspan = "2" align = "center" style="background-color: #4D67A2; height: 19px;">
					        <p class="title" style ="color:#FFFFFF">
                                <strong>
                                BIÊN BẢN KIỂM NHẬP</strong></p>
				        </td>
			        </tr>
				    <TR>
					    <TD width="100%" align="center">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%">
								    </TD>
							    </TR>
						    </TABLE>
                                                                &nbsp;Từ Ngày :<asp:textbox id="txtTuNgay" runat="server" tabindex="1" width="118px"></asp:textbox><input id="Button4" onclick="dp_cal1.toggle()" style="width: 25px" type="button"
                                                                    value="..." />Đến Ngày :
                                                           <asp:textbox id="txtDenNgay" runat="server" tabindex="1" width="118px"></asp:textbox><input id="Button1" onclick="dp_cal.toggle()" style="width: 25px" type="button"
                                                                    value="..." /></TD>
				    </TR>
	
			    </table>
                Kho nhập :<asp:dropdownlist id="ddl_khonhap" runat="server" width="200px"></asp:dropdownlist>Loại
                thuốc :
                <asp:dropdownlist id="ddl_loaithuoc" runat="server" width="200px"></asp:dropdownlist>
            </td>
	    </tr>				
            <tr>
                <td align="center" style="padding-left: 0px; padding-top: 0px" valign="top" width="100%">
                                                                <asp:button id="btnTim" runat="server" text="Lấy Danh sách"  OnClick="btnTim_Click"  />
                </td>
            </tr>
    </table>
    </td>
    </tr>
    </table>
    <CR:CrystalReportViewer ID="R" runat="server" AutoDataBind="true" DisplayGroupTree="False" />
 </form>
<!-- #include file="footer.htm" -->


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_BCSuDung.aspx.cs" Inherits="frm_BCSuDung" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<%@ Register Src="~/phukhoa/uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!-- #include file="../KhoaNoi/header.htm" -->
<script language = "javascript">
   var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
//	  dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
//	    dp_cal= new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
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
	    //var kho = document.getElementById("ddlkho");
	    var tungay = document.getElementById("txtTuNgay");
	    var denngay = document.getElementById("txtDenNgay");
//	    if(kho.value == "0" || kho.value == "")
//	    {
//	        alert("Vui lòng chọn kho trước khi load danh sách!");
//	        kho.focus();
//	        return false;
//	    }
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
<body>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#FBF8F1; height: 19px;">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "center" style="background-color:#D4D0C8; height: 276px;">
        <table cellspacing="1" cellpadding="1" width="98%" border="0" class = "khung">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px; height: 255px;">
			    <table id="user" cellSpacing="0" cellPadding="0" width="100%" border="0">
				    <tr>
				        <td class="title" colspan = "2" align = "center" style="background-color: #4D67A2; height: 19px;">
					        <p class="title" style ="color:#FFFFFF">
                                <strong>BÁO CÁO SỬ DỤNG</strong></p>
				        </td>
			        </tr>
				    <TR>
					    <TD width="100%" style="height: 177px">
						      
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" style="height: 20px"><span class="title">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: 126px">
                                        <table>
                                           
                                            <tr>
                                                <td style="width: 100px">
                                                    Đối tượng</td>
                                                <td style="width: 100px">
                                                    <asp:dropdownlist id="chbLoaiThuoc" runat="server" width="150px"></asp:dropdownlist>
                                                </td>
                                                <td style="width: 100px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    Từ Ngày :</td>
                                                <td style="width: 100px">
													     <asp:textbox id="txtTuNgay" runat="server" tabindex="1" width="145px"  onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" ></asp:textbox>
                                                </td>
                                                <td style="width: 100px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px; height: 26px">
                                                    &nbsp;Đến Ngày :</td>
                                                <td style="width: 100px; height: 26px">
                                                                      <asp:textbox id="txtDenNgay" runat="server" tabindex="1" width="142px"  onfocus="$(this).datepick();" onblur="nvk_testDate_this(this);" ></asp:textbox>
                                                </td>
                                                <td style="width: 100px; height: 26px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                </td>
                                                <td style="width: 100px">
                                                                <asp:button id="btnTim" runat="server" text="Lấy Danh sách" onClientClick="return checkvalid();" OnClick="btnTim_Click" Width="145px" />
                                                </td>
                                                <td style="width: 100px">
                                                </td>
                                            </tr>
                                        </table>
								    </TD>
							    </TR>
						    </TABLE>
						      
						    </span></TD>
							    </TR>
						    </TABLE>						   
					    </TD>
				    </TR>
				    <tr>
	                    <td style="width: 100%; height: 19px;">
	                        <div id  = "infospace" runat = "server"></div>
	                    </td>
	                </tr>	
			    </table>
		    </td>
	    </tr>				
    </table>
    </td>
    </tr>
    </table>
 </form>
 </body>
<!-- #include file="../KhoaNoi/footer.htm" -->

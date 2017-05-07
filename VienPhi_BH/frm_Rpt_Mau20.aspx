<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_Rpt_Mau20.aspx.cs" Inherits="frm_Rpt_Mau20" %>

<%@ Register Src="~/VienPhi_TH/uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<!--#include file = "header.htm" -->
<head>
    <title>Danh sách thanh toán</title>
    
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
        
        <link rel="stylesheet" type="text/css" href="js/epoch_styles.css" />
        <script type="text/javascript" src="js/epoch_classes.js"></script>   
        <script language="javascript" type="text/javascript">
    var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
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
    </script>     

    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#FBF8F1; height: 19px;">
        <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
        </td>
        </tr>
        </table>
        &nbsp;</div>
       <div>
       <table width="100%" rules="groups" style="height: 86px">
                            <tr>
                                <td  align="center" style="height: 22px;border:1px; background-color:Blue; background-repeat:repeat-x;color:Black">
                                    <asp:Label ID="txtTieuDe" Text=" THỐNG KÊ TỔNG HỢP THUỐC ĐIỀU TRỊ CHO BỆNH NHÂN BHYT KCB" runat="server" Font-Bold="True"
                                        ForeColor="White"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 51px">
                                   <table rules="groups" style="width:800px">
                                        <tr>
                                            <td colspan="2" style="height: 2px;">
                                            </td>
                                        </tr>
                                       <tr>
                                            <td style="height: 21px; width:257px;padding-left:50px">
                                                Từ ngày:
                                                <asp:TextBox ID="txtTuNgay" runat="server" Width="100px"></asp:TextBox>
                                                <input id="Button3" type="button" value="..." style="width: 24px" onclick="dp_cal.toggle()" />
                                            </td>
                                            <td style="height: 21px; width:auto;">
                                                Đến ngày:&nbsp;
                                                <asp:TextBox ID="txtDenNgay" runat="server" Width="100px"></asp:TextBox>
                                                <input id="Button4" type="button" value="..." style="width: 24px" onclick="dp_cal1.toggle()" />
                                                &nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chbIsNoiTru" runat="server" Text="Nội trú?" />
                                                &nbsp;&nbsp; &nbsp;<asp:Button ID="Button5" runat="server" Text="Lấy danh sách" OnClick="btnLayBaoCao_Click" Width="99px" /></td>
                                            
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 2px;">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </td>
                            </tr>
                            
                        </table>
       </div>
       <br />
    <div>
       
     
    </div>
    </form>
    <!--#include file = "footer.htm" -->
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frpt_ChiTietLuong_New.aspx.cs" Inherits="frpt_ChiTietLuong_New" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />

<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bảng lương chi tiết</title>
    <link rel="stylesheet" type="text/css" href="../js/epoch_styles.css" />
    <!--Epoch's styles-->

    <script type="text/javascript" src="../js/epoch_classes.js"></script>

    <!--Epoch's Code-->

    <script language="javascript">
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0"
                visible="false">
                <tr>
                    <td width="100%" align="left" style="background-color: #FBF8F1; height: 19px;">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" style="background-color: #D4D0C8; height: 26px;">
                        <table width="100%" rules="groups" style="height: 86px">
                            <tr>
                                <td align="center" style="height: 22px; background-color: #ccccff">
                                    <asp:Label ID="txtTieuDe" Text=" BẢNG CHI TIÊT LƯƠNG NHÂN VIÊN" runat="server"
                                        Font-Bold="True" ForeColor="Blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 51px">
                                    <table rules="groups" style="width: 70%">
                                        <tr>
                                            <td  style="height: 21px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 21px; width: 100%;padding-left:50px">
                                                Phòng &nbsp;
                                                <asp:dropdownlist id="ddlPhongBan" tabIndex=1 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPhongBan_SelectedIndexChanged" width="212px" CssClass="input"></asp:dropdownlist>
                                                &nbsp; Nhân Viên&nbsp; &nbsp;<asp:dropdownlist id="ddlNhanVien" tabIndex=1 runat="server" width="33%" CssClass="input"></asp:dropdownlist>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="height: 21px; width: 100%;padding-left:50px">
                                                Tháng &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:dropdownlist id="ddlThang" tabIndex=7 runat="server" width="7%">
 <asp:ListItem Value="1">1</asp:ListItem>
<asp:ListItem Value="2">2</asp:ListItem>
<asp:ListItem Value="3">3</asp:ListItem>
<asp:ListItem Value="4">4</asp:ListItem>
<asp:ListItem Value="5">5</asp:ListItem>
<asp:ListItem Value="6">6</asp:ListItem>
<asp:ListItem Value="7">7</asp:ListItem>
<asp:ListItem Value="8">8</asp:ListItem>
<asp:ListItem Value="9">9</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="11">11</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>
</asp:dropdownlist> &nbsp;&nbsp;&nbsp;&nbsp;Năm&nbsp;
 <asp:dropdownlist id="ddlNam" tabIndex=7 runat="server" width="9%"></asp:dropdownlist>
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <asp:Button ID="btnGetDanhSach" runat="server" CssClass="input" OnClick="btnLayBaoCao_Click"
                                                    Text="Lấy danh sách" Width="102px" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <CR:CrystalReportViewer ID="R" runat="server" AutoDataBind="true" PrintMode="ActiveX" OnUnload="R_Unload" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

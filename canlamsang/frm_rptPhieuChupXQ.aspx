<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_rptPhieuChupXQ.aspx.cs" Inherits="frm_rptPhieuChupXQ" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="~/canlamsang/uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
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
      <link type="text/css" rel="stylesheet" href="../css/sheet_index.css" />
     
        <script language = "javascript">
  
    
    function Thoat()
    {
        window.close();
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
</head>
<body>
    <form id="form1" runat="server">
     <table cellpadding = "0" cellspacing = "0" border = "0" width = "100%">
		        <tr>
		            <td width = "100%" align = "left"  style ="height:25px; background-color: #E7E4DF"><span class = "Tieude"><%= StaticData.TenCty %> Người dùng: <%=  SysParameter.UserLogin.FullName(this) %> <span onclick = "Thoat()" style="cursor:pointer">[Thoát]</span></td>
		        </tr>		        
		    </table>
    <table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
            <asp:placeholder ID="PlaceHolder1" runat="server"></asp:placeholder>
        </td>
    </tr>
    </table>
    <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr>
                   <td class="title" align = "center" style ="background-color: #4D67A2">
			                <span class="title" style ="color:#FFFFFF">PHIẾU HẸN KẾT QUẢ</span></td>
                    
                </tr>
                </table>
    
    <div>
        <CR:CrystalReportViewer ID="crptView"  runat="server" AutoDataBind="true" PrintMode="ActiveX" OnUnload="crptView_Unload" />
    
    </div>
    </form>
</body>
</html>

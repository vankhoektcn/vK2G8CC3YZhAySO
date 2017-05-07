<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPhieuBaoThuTamUng.aspx.cs" Inherits="frmPhieuBaoThuTamUng" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>BIÊN LAI THU TIỀN</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
    </div>
    <div>
        <CR:CrystalReportViewer ID="bienlaitamung" runat="server" AutoDataBind="true" DisplayGroupTree="False" HasCrystalLogo="False" HasDrillUpButton="False" HasGotoPageButton="False" HasPageNavigationButtons="False" HasRefreshButton="True" HasToggleGroupTreeButton="False" HasViewList="False" PrintMode="ActiveX" OnUnload="CrystalReportViewer1_Unload" />
    
    </div>
    </form>
</body>
</html>

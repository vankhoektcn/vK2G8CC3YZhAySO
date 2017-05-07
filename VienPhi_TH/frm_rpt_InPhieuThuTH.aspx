<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_rpt_InPhieuThuTH.aspx.cs" Inherits="frm_rpt_InPhieuThuTH" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Phiếu thu</title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
                <CR:CrystalReportViewer ID="crptView" runat="server" AutoDataBind="true" DisplayGroupTree="False" PrintMode="ActiveX" />
    
    </div>
    </form>
</body>
</html>
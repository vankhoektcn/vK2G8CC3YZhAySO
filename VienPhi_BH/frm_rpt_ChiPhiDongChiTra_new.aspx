﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_rpt_ChiPhiDongChiTra_new.aspx.cs" Inherits="frm_rpt_ChiPhiDongChiTra_new" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<CR:CrystalReportViewer ID="chiphikhambenh" runat="server" AutoDataBind="true" PrintMode="ActiveX" BestFitPage="True" OnUnload="CrystalReportViewer1_Unload" DisplayGroupTree="False" />
    </div>
    </form>
</body>
</html>

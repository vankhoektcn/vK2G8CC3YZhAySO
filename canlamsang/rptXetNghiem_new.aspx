<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptXetNghiem_new.aspx.cs" Inherits="rptXetNghiem_new" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>KẾT QUẢ ĐIỀU TRỊ XÉT NGHIỆM</title>
     <script type="text/javascript" src="../js/script.js"></script>
     <link type="text/css" rel="stylesheet" href="../css/default.css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" method="post" >
    <div>
        &nbsp;<cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
            printmode="ActiveX" runnat="server" DisplayGroupTree="False" hastogglegrouptreebutton="False"></cr:crystalreportviewer></div>
    </form>
</body>
</html>

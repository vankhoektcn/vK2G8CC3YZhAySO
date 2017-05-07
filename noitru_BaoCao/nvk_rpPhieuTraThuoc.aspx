<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_rpPhieuTraThuoc.aspx.cs" Inherits="noitru_BaoCao_nvk_rpPhieuTraThuoc" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Phiếu trả thuốc</title>
    <script src="../js/jquery-1.6.1.min.js" type="text/javascript"> </script>
    <script src="../js/jquery-ui.js" type="text/javascript"> </script>
        <script src="../js/jquery.autocomplete.new.js" type="text/javascript"> </script>    
        <script src="../js/jquery.validate.js" type="text/javascript"> </script>
        <script src="../js/myscriptvalid.js" type="text/javascript"> </script>
        <script src="../js/myscript.jqr.js" type="text/javascript"> </script>
	 
        <script src="../js/timepicker.js" type="text/javascript"> </script>
        <script src="../noitru/js/nvk_DateTime.js" type="text/javascript"> </script>
        <link type="text/css" href="~/css/timepicker.css" rel="Stylesheet"/>
	 
        <link type="text/css" rel="stylesheet" href="../css/default.css" />
        <link type="text/css" href="~/css/jquery-ui.css" rel="Stylesheet"/>
        <link type="text/css" href="../noitru/css/NVK_jtable.css" rel="Stylesheet"/>
        <link type="text/css" href="~/css/jquery.autocomplete.new.css" rel="Stylesheet"/>
    
    
    <script type="text/javascript" src="../js/libary.js"></script>
    <script type="text/javascript" src="../js/myscript.js"></script>
    <script type="text/javascript" src="../js/script.js"></script>
    <script type="text/javascript" src="../js/myjava.js"></script>
    
    <script src="../noitru/js/nvk_SessionPrint.js" type="text/javascript"> </script>
    
<script type="text/javascript">
window.onload = function () 
	{
	    StartPrint();
	}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="report" runat="server" AutoDataBind="true" DisplayGroupTree="False" PrintMode="ActiveX" OnUnload="report_Unload" />
        
        <input type="image" id="nvk_print" name="report$ctl02$ctl01" title="Print"
         src="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/print.gif"
          onmouseover="this.src='/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/print_over.gif'"
           onmouseout="this.src='/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/print.gif'"
            style="height:22px;width:22px;border-width:0px;" />
    </div>
    </form>
</body>
</html>

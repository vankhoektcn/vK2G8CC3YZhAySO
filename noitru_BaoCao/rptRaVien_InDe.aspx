
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptRaVien_InDe.aspx.cs" Inherits="rptRaVien_InDe" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Giấy Ra Viện</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
<script src="../js/jquery-1.6.1.min.js" type="text/javascript"> </script>
<script src="../js/jquery-ui.js" type="text/javascript"> </script>
<script src="../noitru/js/nvk_SessionPrint.js" type="text/javascript"> </script>
<script src="../js/myscript.jqr.js" type="text/javascript"> </script>
    
<script type="text/javascript">
window.onload = function () 
	{
	    StartPrint();
	}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;padding-left:80px" align="left">
        <table style="width:400px" rules="all">
            <tr>
                <td>
                    Số Lưu Trữ: <input type="text" style="width:100px" id="txtSoLuuTru" runat="server" />
                </td>
                <td>
                    <asp:Button runat="server" id="btnLayBaoCao" Text="Lấy Số Lưu Trữ" Width="120px" OnClick="btnLayBaoCao_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <CR:CrystalReportViewer ID="report" runat="server" AutoDataBind="true" DisplayGroupTree="False" PrintMode="ActiveX"  OnUnload="report_Unload" />
        <input type="image" id="nvk_print" name="report$ctl02$ctl01" title="Print"
         src="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/print.gif"
          onmouseover="this.src='/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/print_over.gif'"
           onmouseout="this.src='/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/print.gif'"
            style="height:22px;width:22px;border-width:0px;" />
    </div>
    </form>
</body>
</html>

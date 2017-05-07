<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TT_rptDanhsachhaophi.aspx.cs" Inherits="noitru_BaoCao_TT_rptDanhsachhaophi" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">

function ClosePage()
{
    alert("Bệnh nhân này không có Hao Phí");
    window.close();
}
</script>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            DisplayGroupTree="False" PrintMode="ActiveX" Width="99%"  AutoDataBind="true" onunload="CrystalReportViewer1_Unload" />
    </div>
    </form>
</body>
</html>

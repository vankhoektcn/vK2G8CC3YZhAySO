<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptPhieuYCXuat_new.aspx.cs" Inherits="rptPhieuYCXuat_new" %>



<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- #include file="header.htm" -->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
     <script type="text/javascript" src="../js/script.js"></script>
     <link type="text/css" rel="stylesheet" href="../css/default.css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
        
    <script src="../js/myscript.jqr.js" type="text/javascript"> </script>
    <script src="../noitru/js/nvk_SessionPrint.js" type="text/javascript"> </script>
    
<script type="text/javascript">
window.onload = function () 
	{
	    StartPrint();
	}
//   window.onload = function () 
//	{
//	    var IsPrint=$.mkv.queryString('isPrint');
//	    if (IsPrint=="1")
//	    {
//	    $.ajax({
//            type: "GET",
//		        cache: false,
//		        dataType:"text",
//		        url: "../ajax/nvk_frmTaoPhieuYCTheoToa_ajax.aspx?do=nvk_GetValuePrint",
//		        success: function(value) {
//		            var arr= value.split('~~');
//		            if(arr[1] =="1")
//		            { 
//		                nvk_DisablePrint(arr[0]);
//		            }
//		            else
//		            { 
//		                nvk_EnablePrint(arr[0]);
//		            }
//		        }
//            }); 
//         }
//         else
//         {
//		    nvk_EnablePrint("nvk_SessionPrint");
//            //alert("Xem Thôi");
//         }
//	};
//function nvk_EnablePrint(isSession)
//{
//    $.ajax({
//            type: "GET",
//		        cache: false,
//		        dataType:"text",
//		        url: "../ajax/nvk_frmTaoPhieuYCTheoToa_ajax.aspx?do=nvk_GetValuePrint&idsesiion="+isSession+"&EnablePrint=1",
//		        success: function(value) {
//		            var arr= value.split('~~');
//		            if(arr[1] =="1")
//		            {
//		                $.mkv.queryString('isPrint',"0"); 
//		            }
//		            else
//		            { alert("nvk_EnablePrint thất bại !");}
//		        }
//            });   
//}
//function nvk_DisablePrint(isSession)
//{
//    $.ajax({
//            type: "GET",
//		        cache: false,
//		        dataType:"text",
//		        url: "../ajax/nvk_frmTaoPhieuYCTheoToa_ajax.aspx?do=nvk_GetValuePrint&idsesiion="+isSession+"&EnablePrint=0",
//		        success: function(value) {
//		            var arr= value.split('~~');
//		            //alert(arr[1]);
//		            if(arr[1] =="0")
//		            {
//		                       document.getElementById("nvk_print").click();
//		            }
//		            else
//		            { alert("nvk_DisablePrint thất bại !");}
//		        }
//            });   
//}

</script>
</head>
<body >
    <form id="form1" runat="server">
    <div>
        <%--&nbsp;<uc2:uscMenu ID="UscMenu1" runat="server" />--%>
    </div>
    
    <div>
    
            <%--<br />--%>
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

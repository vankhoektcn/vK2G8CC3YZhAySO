<%@ Page Language="C#" AutoEventWireup="true" CodeFile="phieuKQFibroScan.aspx.cs" Inherits="phieuKQFibroScan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Fibroscan report</title>
   <script src="../js/jquery-1.6.1.min.js" type="text/javascript"> </script>
    <script src="js/jquery-ui.js" type="text/javascript"> </script>
    <link type="text/css" href="css/jquery-ui.css" rel="Stylesheet"/>
      <script type="text/javascript">
    function ClickToPrint()
     {
       window.print();
    }
      	var array = 0;
   	window.onload = function () {
     var positon = 0;
	    var val = document.getElementById('giatrichung').value;
	    if(eval(val) > 75)
	        val = 75;
       for(var i=0;i<array.length;i++)
       {
            if(val == array[i])
            {
                positon = i;
                break;
             }
       }
	    
	     $("#slider").slider("value", positon);
    }
	$(function() {
	   var sau = "[0,0.5,0.8,1,1.5,1.8,2,2.2,2.5,2.8,3,3.2,3.5,3.8,4,4.2,4.5,4.8,5,5.5,5.8" ;
     for(var i=6;i<23;i++)
     {
         for(var y=0;y<10;y++)
         {
             sau += "," + i + "." + y;
         }
     }
    array = eval(sau+",23,24,25,26,27,28,29,30,31,32,33,35,38,40,42,45,48,50,52,55,58,60,62,65,68,75]");
        $('#slider').slider({
            min:0, 
            max:array.length - 1, 
            slide: function(event,ui){
                $('#giatrichung').val(array[ui.value]); 
            }
        });
	 });
	 function setslider(obj)
	 {
	 	var positon = 0;
	    var val = obj.value;
	    if(eval(val) > 75)
	        val = 75;
       for(var i=0;i<array.length;i++)
       {
            if(val == array[i])
            {
                positon = i;
                break;
             }
       }
	    
	     $("#slider").slider("value", positon);
	 }
    </script>
    <style type="text/css">
                    @media print {
                    input.noPrint { display: none; }
                    }
                   .ui-slider .ui-slider-handle{height:270px;background:green;width:2px;}
                </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:980px">
        <div style="text-align:center;padding-top:2%;font-weight:bold;font-size:medium">
            FIBROSCAN® REPORT
        </div>
        <div style="width:100%;padding-left:5%">
            <div style="width:10%;float:left">
            <img alt="logo" src="../images/LogoMedilab.png" height="100px" width="100px"/>
            </div>
            <div style="float:left;padding-left:5%" runat="server" id="divBenhNhan">
            </div>
            <div style="width:100%;float:inherit;font-weight:bold;font-size:medium">
            <div style="width:100%;float:left;font-size:large"><asp:Label runat="server" ID="lblScore" ></asp:Label>
              <asp:Label Width="90px" Font-Size="Large" ID="lblGiaTriChung" runat="server" BorderColor="Black" BorderStyle="solid" BorderWidth="1px"></asp:Label></div>
             </div>
             <div>
                <span class="ptext" style="font-weight:bold">Fibroscan® Reference for Metavir in Diffirent Liver Disease Setting</span>
             </div>
             <div style="position:relative;margin:auto;width:950px;margin-top:10px;height:450px;">
             <img alt="bangthongso" src="images/bangthongso.jpg" />
<%--                <div id="slider" style="width:71.3%;border:none;position:absolute;top:16%;left:6%;background-color:Transparent"></div>
--%>            </div>
            <div style="padding-top:5%">
                <span style="font-weight:bold;font-size:medium" class="ptext">Fibroscan® Score Guide</span>
            </div>
            <div style="padding-top:auto;width:95%;" id="divKQ" runat="server">
            </div>
        </div>
    </div>
    <input type="hidden" name="giatrichung" id="giatrichung" runat="server" />
    <input type="button" class="noPrint" value="In Phiếu" runat="server" onclick="ClickToPrint();" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frpt_TongHopYLenh.aspx.cs"
    Inherits="frpt_TongHopYLenh" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!-- #include file="../noitru/header.htm" -->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../js/epoch_styles.css" />

<script type="text/javascript" src="../js/epoch_classes.js"></script>

<script language="javascript">
    var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	};
    function TestDatePhieu(t)
	{
		if (t.value != "")
		{
			t.value=AddString(t.value);
			if (isDate(t.value)==false)
			{
				t.value="";
				alert("Bạn nhập ngày tháng không hợp lệ ! ");
				t.focus();
			}
		}
		return;
	}
	function CloseDivGiuong()
	{
        document.getElementById('divChiTietGiuongNgay').style.display='none';
	}	
	function setCheckGiuong(objCheck)
	{
	    var ListIdGiuong=document.getElementById('hdListIdG').value;
	    var idGiuong=objCheck.id;
	    var tinhtrangCheck="1";
	    if(objCheck.checked==true)
	        tinhtrangCheck="1";
	    else
	        tinhtrangCheck="0";
	        
	   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var arrValue=value.split('@~@')
                document.getElementById('hdListIdG').value=arrValue[0];
	            document.getElementById('divGiuongDaChon').innerHTML=arrValue[1];
	        }
        }
        xmlHttp.open("GET","../ajax/khambenh_ajax3.aspx?do=ShowDanhSachGiuongChon&ListIdGiuong="+ListIdGiuong+"&idGiuong="+idGiuong+"&tinhtrangCheck="+tinhtrangCheck+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function Phong_click(obj)
	{
	    var ListIdGiuong=document.getElementById('hdListIdG').value;
	    var divGiuong=document.getElementById('divChiTietGiuongNgay');
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
	            document.getElementById('divChiTietGiuongNgay').innerHTML=value;
	            document.getElementById('divChiTietGiuongNgay').style.display='';
	            document.getElementById('btndongCTG').focus();
	        }
        }
        xmlHttp.open("GET","../ajax/khambenh_ajax3.aspx?do=getGiuongMotPhong&idphong="+obj.id+"&tenphong="+obj.value+"&ListIdGiuong="+ListIdGiuong+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function xoaGiuongTable(idGiuong)
	{
	    document.getElementById('divChiTietGiuongNgay').style.display='none';
	    var ListIdGiuong=document.getElementById('hdListIdG').value;
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var arrValue=value.split('@~@')
                document.getElementById('hdListIdG').value=arrValue[0];
	            document.getElementById('divGiuongDaChon').innerHTML=arrValue[1];
	        }
        }
        xmlHttp.open("GET","../ajax/khambenh_ajax3.aspx?do=ShowDanhSachGiuongChon&ListIdGiuong="+ListIdGiuong+"&idGiuong="+idGiuong+"&tinhtrangCheck=0&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function ClearDanhSachGiuong()
	{
	    document.getElementById('hdListIdG').value="";
	    document.getElementById('divChiTietGiuongNgay').style.display='none';
	    document.getElementById('divGiuongDaChon').innerHTML="CHƯA MỘT GIƯỜNG NÀO ĐƯỢC CHỌN !";
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
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<%--</head>--%>
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
<body>
    <form id="form1" runat="server"> 
    <asp:scriptmanager runat="server" id="script1">
                                    </asp:scriptmanager>
                                    <asp:updatepanel runat="server" id="script2">
                                        <contenttemplate>
        <div>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0"
                visible="false">
                <tr>
                    <td width="100%" align="left" style="background-color: #FBF8F1; height: 19px;">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="center" style="background-color: #D4D0C8; height: 26px;">
                        <table width="100%" rules="groups" style="height: 86px">
                            <tr>
                                <td align="center" style="height: 22px; background-color: #ccccff">
                                    BÁO CÁO TỔNG HỢP Y LỆNH</td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 52px">
                                    
                                    <table rules="groups" style="width: 60%">
                                        <tr>
                                            <td style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 21px;">
                                                Ngày:
                                                <asp:TextBox ID="txtTuNgay" runat="server" Width="80px"></asp:TextBox>
                                                (dd/mm/yyyy)
                                                <%--Đến ngày:&nbsp;--%>
                                                <asp:TextBox ID="txtDenNgay" Visible="false" runat="server" Width="127px"></asp:TextBox>
                                                <%--(dd/mm/yyyy)&nbsp;&nbsp;--%>                                                
                                                </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="height: auto;">
                                            <div id="divChonGiuong" runat="server">
                                            <%--<input type="checkbox" id="cbGiuong" value="Check vô mình đi !" onclick='LoadGiuong()' onchange="LoadGiuong()"/>--%>
                                            </div>
                                            <br />
                                            <div id="divChiTietGiuongNgay" style="display:none;background-color:white;z-index:1001;padding:5px 5px 5px 5px;border:10px solid black;"></div>
                                            <%--<br />--%>
                                            <div id="divGiuongDaChon" runat="server" style="background-color:white;z-index:1001;padding:5px 5px 5px 5px;border:10px solid blue;"> HÃY CHỌN GIƯỜNG !</div>
                                            <table style="width:100%" rules="all">
                                                <tr>
                                                    <td style="width:350px">
                                                    
                                                    </td>
                                                    <td  style="width:650px">
                                                    
                                                    </td>
                                                </tr>
                                            </table>                                            
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <asp:Button ID="btnLayBaoCao" runat="server" Text="Lấy danh sách" OnClick="btnLayBaoCao_Click"
                                        Width="99px" />
                                        <input id="hdListIdG" runat="server" type="hidden" />
                                </td>
                            </tr>
                        </table>
                        <cr:crystalreportviewer id="R" runat="server" autodatabind="true" printmode="ActiveX"
                            onunload="R_Unload" />
                    </td>
                </tr>
            </table>
        </div>
        </contenttemplate>
        </asp:updatepanel>
    </form>
</body>
<!-- #include file="../noitru/footer.htm" -->

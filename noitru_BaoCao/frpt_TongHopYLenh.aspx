<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frpt_TongHopYLenh.aspx.cs"
    Inherits="frpt_TongHopYLenh" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!-- #include file="../noitru/header.htm" -->

<style type="text/css">
.botton_Phong
{
    background-color:#CAE8EA!important;
    background-image:none!important;
    color:Blue!important;
}
.fieldset_1 
{
 padding-bottom:3px;
 padding-top:3px;
 border-color:Black;border: solid 1px black;
 }

.legend_1 {
 color:Blue;
    padding:2px;
    margin-left: 14px;
    font-weight:bold;
    font-size: 14px;
  }
.fieldset_2 
{
 padding-bottom:3px;
 padding-top:3px;
 border-color:Black;border: solid 3px #CAE8EA; 
 }

.legend_2 {
 color:Black;
    padding:2px;
    margin-left: 14px;
    font-weight:bold;
    font-size: 14px;
    font-style:italic
  }
  .verticaltext_Cot {
writing-mode: tb-rl;
filter: flipv fliph;
width:60px;font-weight:bold; color: Blue;
}
</style>
<script language="javascript">
    var dp_cal, dp_cal1;      
	window.onload = function () 
	{
	    setDate_Hour();
	};//
	function setDate_Hour()
	{
	    document.getElementById("txtTuNgay").value= nvk_CurentDate();
	    document.getElementById("txtDenNgay").value= nvk_CurentDate();
	    $("#txtTuGio").val("00:00");
	    $("#txtDenGio").val("23:59");
	}
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
    $("#divGiuongDaChon").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang Load Bệnh Nhân.....<img id='imgLoading' src='../images/processing.gif' /></span>");
	    var ListIdGiuong=document.getElementById('hdListIdG').value;
	    var ListIdBN=document.getElementById('hdListIdBenhNhan').value;
	    var idGiuong=objCheck.id;
	    var tinhtrangCheck="1";
	    if(objCheck.checked==true)
	        tinhtrangCheck="1";
	    else
	        tinhtrangCheck="0";
	    var cbHienBN= document.getElementById("cbHienBN");
	        //alert(cbHienBN.checked);
	    var IsHienBN= cbHienBN.checked;
	    //return;
	        var NgayYL = document.getElementById("txtTuNgay").value;
            var TuGio = $("#txtTuGio").val();
            var denNgayYL = document.getElementById("txtDenNgay").value;
            var DenGio = $("#txtDenGio").val();
	   xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var arrValue=value.split('@~@')
                if(arrValue[2]=="" || arrValue[2]=="0")
                {
                    document.getElementById('hdListIdG').value="";
	                document.getElementById('divGiuongDaChon').innerHTML=arrValue[1];
                    document.getElementById('hdListIdBenhNhan').value="";
                    if(tinhtrangCheck=="1")
                        alert("Giường vừa chọn không có y lệnh !");
                    return;
                }
                else
                {
                    document.getElementById('hdListIdG').value=arrValue[0];
                    document.getElementById('hdListIdBenhNhan').value=arrValue[2];
                }
	            document.getElementById('divGiuongDaChon').innerHTML=arrValue[1];
                //alert("List Benhnhan="+document.getElementById('hdListIdBenhNhan').value+"; list giương="+arrValue[0]);//nvk alert
	        }
        }
        var IdLoaiThuoc= document.getElementById("ddlLoaiThuoc").value;
        var IdKhoThuoc= document.getElementById("ddlKhoThuoc").value;
        var IdLoaiYLenh= document.getElementById("ddlLoaiYLenh").value;
        xmlHttp.open("GET","../ajax/nvk_TongHopYLenh_ajax.aspx?do=ShowDanhSachGiuongChon&IdLoaiYLenh="+IdLoaiYLenh+"&IdKhoThuoc="+IdKhoThuoc+"&IdLoaiThuoc="+IdLoaiThuoc+"&IsHienBN="+IsHienBN+"&ListIdBenhnhan="+ListIdBN+"&ListIdGiuong="+ListIdGiuong+"&idGiuong="+idGiuong+"&tinhtrangCheck="+tinhtrangCheck+"&NgayYL="+NgayYL+"&TuGio="+TuGio+"&DenNgayYL="+denNgayYL+"&DenGio="+DenGio+"&IdKhoa="+$.mkv.queryString("IdKhoa")+"&times="+Math.random(),true);
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
        xmlHttp.open("GET","../ajax/nvk_TongHopYLenh_ajax.aspx?do=getGiuongMotPhong&idphong="+obj.id+"&tenphong="+obj.value+"&ListIdGiuong="+ListIdGiuong+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function xoaGiuongTable(idGiuong)
	{
	    document.getElementById('divChiTietGiuongNgay').style.display='none';
	    var ListIdGiuong=document.getElementById('hdListIdG').value;
	    var ListIdBN=document.getElementById('hdListIdBenhNhan').value;	    
	    var cbHienBN= document.getElementById("cbHienBN");
	    var IsHienBN= cbHienBN.checked;
	    var NgayYL = document.getElementById("txtTuNgay").value;
        var TuGio = $("#txtTuGio").val();
        var denNgayYL = document.getElementById("txtDenNgay").value;
        var DenGio = $("#txtDenGio").val();
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var arrValue=value.split('@~@')
                document.getElementById('hdListIdG').value=arrValue[0];
	            document.getElementById('divGiuongDaChon').innerHTML=arrValue[1];
                document.getElementById('hdListIdBenhNhan').value=arrValue[2];
                //alert("Xóa ->List Benhnhan="+document.getElementById('hdListIdBenhNhan').value+"; list giương="+arrValue[0]);//nvk alert
	        }
        }
        var IdLoaiThuoc= document.getElementById("ddlLoaiThuoc").value;
        var IdKhoThuoc= document.getElementById("ddlKhoThuoc").value;
        var IdLoaiYLenh= document.getElementById("ddlLoaiYLenh").value;
        xmlHttp.open("GET","../ajax/nvk_TongHopYLenh_ajax.aspx?do=ShowDanhSachGiuongChon&IdLoaiYLenh="+IdLoaiYLenh+"&IdKhoThuoc="+IdKhoThuoc+"&IdLoaiThuoc="+IdLoaiThuoc+"&IsHienBN="+IsHienBN+"&ListIdBenhnhan="+ListIdBN+"&ListIdGiuong="+ListIdGiuong+"&idGiuong="+idGiuong+"&tinhtrangCheck=0&NgayYL="+NgayYL+"&TuGio="+TuGio+"&DenNgayYL="+denNgayYL+"&DenGio="+DenGio+"&IdKhoa="+$.mkv.queryString("IdKhoa")+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	
	function xoaBenhNhanTable(idBenhNhanXoa)
	{
	    var ListIdGiuong=document.getElementById('hdListIdG').value;
	    var ListIdBN=document.getElementById('hdListIdBenhNhan').value;	    
	    var cbHienBN= document.getElementById("cbHienBN");
	    var IsHienBN= cbHienBN.checked;
	    var NgayYL = document.getElementById("txtTuNgay").value;
        var TuGio = $("#txtTuGio").val();
        var denNgayYL = document.getElementById("txtDenNgay").value;
        var DenGio = $("#txtDenGio").val();
	    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                var arrValue=value.split('@~@')
                document.getElementById('hdListIdG').value=arrValue[0];
	            document.getElementById('divGiuongDaChon').innerHTML=arrValue[1];
                document.getElementById('hdListIdBenhNhan').value=arrValue[2];
                //alert("Xóa ->List Benhnhan="+document.getElementById('hdListIdBenhNhan').value+"; list giương="+arrValue[0]);//nvk alert
	        }
        }
        var IdLoaiThuoc= document.getElementById("ddlLoaiThuoc").value;
        xmlHttp.open("GET","../ajax/nvk_TongHopYLenh_ajax.aspx?do=ShowDanhSachXoaBenhNhan&IsHienBN="+IsHienBN+"&IdLoaiThuoc="+IdLoaiThuoc+"&ListIdBenhnhan="+ListIdBN+"&ListIdGiuong="+ListIdGiuong+"&idBenhNhanXoa="+idBenhNhanXoa+"&tinhtrangCheck=0&NgayYL="+NgayYL+"&TuGio="+TuGio+"&DenNgayYL="+denNgayYL+"&DenGio="+DenGio+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function ClearDanhSachGiuong()
	{
	    document.getElementById('hdListIdG').value="";
                document.getElementById('hdListIdBenhNhan').value="";
	    document.getElementById('divChiTietGiuongNgay').style.display='none';
	    document.getElementById('cbAllYLenh').checked=false;
	    document.getElementById('divGiuongDaChon').innerHTML="CHƯA MỘT GIƯỜNG NÀO ĐƯỢC CHỌN !";
	    DoneExcell();
	}
	function Excel_Click()
	{
	    $("#spDangXuatExcell").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang chạy xin chờ.....<img id='imgLoading' src='../images/processing.gif' /></span>");
	}
	function DoneExcell()
	{
	    $("#spDangXuatExcell").html("");
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
    <%--<asp:scriptmanager runat="server" id="script1">
                                    </asp:scriptmanager>
                                    <asp:updatepanel runat="server" id="script2">
                                        <contenttemplate>--%>
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
                                    
                                    <table rules="groups" border="2px" style="width: 80%">
                                        <tr>
                                            <td style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 21px;text-align:center;">
                                                <%--Đến ngày:&nbsp;--%>
                                                <%--(dd/mm/yyyy)&nbsp;&nbsp;--%>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Kho :&nbsp;
                                                <asp:dropdownlist id="ddlKhoThuoc" runat="server" width="130px" tabindex="2" onchange="ClearDanhSachGiuong();">
                                                </asp:dropdownlist>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loại :&nbsp;
                                                <asp:dropdownlist id="ddlLoaiThuoc" runat="server" width="130px" tabindex="2" onchange="ClearDanhSachGiuong();">
                                                </asp:dropdownlist>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ngày :
                                                <asp:TextBox ID="txtTuNgay" runat="server" Width="70px"  onfocus='$(this).datepick();ClearDanhSachGiuong();' onblur='nvk_testDate_this(this);' ></asp:TextBox>
                                                <input type="text" id="txtTuGio" style="width:40px" runat="server"/>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Đến ngày :
                                                <asp:TextBox ID="txtDenNgay" runat="server" Width="70px"  onfocus='$(this).datepick();ClearDanhSachGiuong();' onblur='nvk_testDate_this(this);' ></asp:TextBox>
                                                <input type="text" id="txtDenGio" style="width:40px" runat="server" />
                                                (dd/mm/yyyy HH:mm)
                                                
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <br />
                                                <br />
                                                <%--<span style="padding-right: 10px">Hoặc :</span>  --%>
                                                Loại y lệnh :
                                                <asp:dropdownlist id="ddlLoaiYLenh" runat="server" width="110px" tabindex="2" onchange="ClearDanhSachGiuong();">
                                                    <asp:ListItem Value="1" Text="Tất cả"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Bổ sung, dự trù"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Toa ra viện"></asp:ListItem>
                                                </asp:dropdownlist>                                            
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <input type="checkbox" id="cbHienBN" value="" runat="server" onclick='xoaGiuongTable(-1);' />
                                                <span style="padding-right: 10px;color:Blue">Hiện BN</span>  
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <%--<span style="padding-right: 10px">Hoặc :</span>  --%>                                              
                                                <input type="checkbox" id="cbAllYLenh" value="" runat="server" onclick='LoadAll_BN_YLenh(this)' />
                                                <span style="padding-right: 10px;color:Red">Tất cả Y Lệnh trong ngày</span>  
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <input type="radio" id="rd_OdABC" value="" runat="server" name="rdOrder"/>
                                                <span style="padding-right: 10px;color:Blue">Sắp xếp ABC</span>  
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <input type="radio" id="rd_OdLoai" value=""  checked="true" runat="server" name="rdOrder"/>
                                                <span style="padding-right: 10px;color:Blue">Sắp xếp theo phân loại</span>  
                                                </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="height: auto;">
                                            <fieldset class="fieldset_1" style=""><legend class="legend_1">Chọn Phòng</legend>
                                            <div id="divChonGiuong" runat="server" style="text-align: center;">
                                            <%--<input type="checkbox" id="cbGiuong" value="Check vô mình đi !" onclick='LoadGiuong()' onchange="LoadGiuong()"/>--%>
                                            </div>
                                            </fieldset>
                                            <fieldset class="fieldset_1"><legend class="legend_1">Chọn Giường</legend>
                                            <div id="divChiTietGiuongNgay" style="display:none;background-color:#D4D0C8;z-index:1001;padding:5px 5px 5px 5px;border:0px solid black;text-align: center;"></div>
                                            </fieldset>
                                            <%--<br />--%>
                                            <fieldset class="fieldset_2"><legend class="legend_2">DANH SÁCH GIƯỜNG ĐÃ CHỌN</legend>
                                            <div id="divGiuongDaChon" runat="server" style="background-color:white;z-index:1001;padding:5px 5px 5px 5px;border:0px solid blue;"> HÃY CHỌN GIƯỜNG !</div>
                                            </fieldset>
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
                                    
                                    <%--<asp:Button ID="btnLayBaoCao" runat="server" Text="Lấy danh sách" OnClick="btnLayBaoCao_Click" Width="99px" />--%>
                                    <asp:Button ID="btnXuatExcel" runat="server" Text="Xuất Excel" OnClientClick="Excel_Click();" OnClick="btnXuatExcel_Click" Width="99px" />
                                    <div runat="server" id="spDangXuatExcell" >
                                    </div>
                                        <input id="hdListIdG" runat="server" type="hidden" />
                                        <input id="hdListIdBenhNhan" runat="server" type="hidden" />
                                        
                                </td>
                            </tr>
                        </table>
                        <cr:crystalreportviewer id="R" runat="server" DisplayGroupTree="false" autodatabind="true" printmode="ActiveX"
                            onunload="R_Unload" />
                    </td>
                </tr>
            </table>
        </div>
        <%--</contenttemplate>
        </asp:updatepanel>--%>
    </form>
</body>
<script type="text/javascript">
function LoadAll_BN_YLenh(obj)
{
var IdKhoThuoc= document.getElementById("ddlKhoThuoc").value;
var IdLoaiThuoc= document.getElementById("ddlLoaiThuoc").value;
var NgayYL = document.getElementById("txtTuNgay").value;
var TuGio = $("#txtTuGio").val();
var denNgayYL = document.getElementById("txtDenNgay").value;
var DenGio = $("#txtDenGio").val();
var IdLoaiYLenh= document.getElementById("ddlLoaiYLenh").value;
//alert(IdLoaiThuoc+";"+NgayYL);return;
    if(obj.checked==true)
    {
    $("#divGiuongDaChon").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang Load Bệnh Nhân.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_TongHopYLenh_ajax.aspx?do=LoadAll_BN_YLenh&IdKhoa="+$.mkv.queryString("IdKhoa")+"&NoiYLenh="+$.mkv.queryString("dkmenu")+"&IdLoaiThuoc="+IdLoaiThuoc+"&IdKhoThuoc="+IdKhoThuoc+"&IdLoaiYLenh="+IdLoaiYLenh+"&NgayYL="+NgayYL+"&TuGio="+TuGio+"&DenNgayYL="+denNgayYL+"&DenGio="+DenGio+"";
	        $.ajax
	            ({
	                 async:false,
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                        if(value=="" || value=="0")
                        {
                            alert("Không có Y Lệnh trong ngày !");
                            document.getElementById('hdListIdG').value=value;                            
                            document.getElementById('hdListIdBenhNhan').value="";
                            xoaGiuongTable(-1);return;
                        }
                        else
                        {
                            var arrValue=value.split('@~@')
                            document.getElementById('hdListIdG').value=arrValue[1];
                            document.getElementById('hdListIdBenhNhan').value=arrValue[0];
                        }
                        //alert("All YLenh ->List Benhnhan="+document.getElementById('hdListIdBenhNhan').value+"; list giương="+arrValue[1]);//nvk alert
                        xoaGiuongTable(-1);
                        }
                });
    }
    else
    {
        document.getElementById('hdListIdG').value="";
        document.getElementById('hdListIdBenhNhan').value="";
        xoaGiuongTable(0);
    }
}
</script>
<!-- #include file="../noitru/footer.htm" -->

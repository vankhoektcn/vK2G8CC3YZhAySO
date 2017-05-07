<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_YLenhNgoaiTruTheoBN.aspx.cs"
    Inherits="nvk_YLenhNgoaiTruTheoBN" %>

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
 border-color:Black;border: solid 1px black;
 padding-bottom:3px;
 padding-top:3px;
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
 border:3px #CAE8EA;
 padding-bottom:3px;
 padding-top:3px;
 }

.legend_2 {
 color:Black;
    padding:2px;
    margin-left: 14px;
    font-weight:bold;
    font-size: 14px;
    font-style:italic
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
        xmlHttp.open("GET","../ajax/nvk_TongHopYLenh_ajax.aspx?do=ShowDanhSachGiuongChon&ListIdGiuong="+ListIdGiuong+"&idGiuong="+idGiuong+"&tinhtrangCheck="+tinhtrangCheck+"&times="+Math.random(),true);
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
        xmlHttp.open("GET","../ajax/nvk_TongHopYLenh_ajax.aspx?do=ShowDanhSachGiuongChon&ListIdGiuong="+ListIdGiuong+"&idGiuong="+idGiuong+"&tinhtrangCheck=0&times="+Math.random(),true);
        xmlHttp.send(null);
	}
	function ClearDanhSachGiuong()
	{
	    document.getElementById("cbAllYLenh").checked= false;
	    document.getElementById('hdListIdG').value="";
	    //document.getElementById('divChiTietGiuongNgay').style.display='none';
	    document.getElementById('divGiuongDaChon').innerHTML="CHƯA CÓ BỆNH NHÂN CHỌN !";
	}
	
	//      NVK FUNCTION NEW FOR Y LỆNH NGOẠI TRÚ
function btnXuatExcelJava_Click()
{
    $("#spDangLayDanhSach").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang xuất.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_TongHopYLenh_ajax.aspx?do=btnXuatExcel_Click";
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            $("#spDangLayDanhSach").html(value);
                            //alert(document.getElementById("btnAutoClick"));
                            document.getElementById("btnAutoClick").click();
                        }
                });
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
                                    
                                    <table rules="groups" border="2px"  style="width: 90%">
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
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Loại y lệnh :&nbsp;
                                                <asp:dropdownlist id="ddlLoaiYLenh" runat="server" width="110px" tabindex="2" onchange="ClearDanhSachGiuong();">
                                                    <asp:ListItem Value="1" Text="Tất cả"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Bổ sung, dự trù"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Toa ra viện"></asp:ListItem>
                                                </asp:dropdownlist>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ngày :
                                                <asp:TextBox ID="txtTuNgay" runat="server" Width="70px"  onfocus='$(this).datepick();ClearDanhSachGiuong();' onblur='nvk_testDate_this(this);' ></asp:TextBox>
                                                <input type="text" id="txtTuGio" style="width:40px" runat="server"/>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Đến ngày :
                                                <asp:TextBox ID="txtDenNgay" runat="server" Width="70px"  onfocus='$(this).datepick();ClearDanhSachGiuong();' onblur='nvk_testDate_this(this);' ></asp:TextBox>
                                                <input type="text" id="txtDenGio" style="width:50px" runat="server" />
                                                <%--(dd/mm/yyyy HH:mm)--%>
                                                </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="height: auto;">
                                            <fieldset class="fieldset_1"><legend class="legend_1">Chọn Bệnh Nhân</legend>
                                            <div id="divChonGiuong" runat="server">
                                                <span style="padding-right: 10px">Tên BN/ Mã BN :</span>
                                                <input id='nvk_idbenhnhan' type='hidden' value='' onblur='TestSo(this,false,false);'/>
                                                <input id='nvk_tenbenhnhan' type='text' onfocusout='chuyenformout(this)' onfocus="nvk_benhnhansearch(this)" value='' style='width:300px'/>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <span style="padding-right: 10px">Hoặc :</span>                                                
                                                <input type="checkbox" id="cbAllYLenh" value="" runat="server" onclick='LoadAll_BN_YLenh(this)' />
                                                <span style="padding-right: 10px;color:Red">Tất cả Y Lệnh trong ngày</span>                                                
                                            </div>
                                            </fieldset>
                                            <%--<fieldset class="fieldset_1"><legend class="legend_1">Chọn Giường</legend>
                                            <div id="divChiTietGiuongNgay" style="display:none;background-color:#D4D0C8;z-index:1001;padding:5px 5px 5px 5px;border:0px solid black;"></div>
                                            </fieldset>--%>
                                            <%--<br />--%>
                                            <fieldset class="fieldset_1"><legend class="legend_2">DANH SÁCH BỆNH NHÂN ĐÃ CHỌN</legend>
                                            <div id="divGiuongDaChon" runat="server" style="background-color:white;z-index:1001;padding:5px 5px 5px 5px;border:0px solid blue;"> HÃY CHỌN GIƯỜNG !</div>
                                            </fieldset>                                          
                                            </td>
                                        </tr>
                                    </table>
                                    <span id="spDangLayDanhSach" style="width:100%"></span>
                                    <%--<asp:Button ID="Button1" runat="server" Text="." AutoPostBack="false" Width="99px" />--%>
                                    <%--<input  type="button" id="btnXuatExcel" value="Xuất Excel"  onclick="btnXuatExcelJava_Click()" style="width:99px"/>--%>
                                    <%--<asp:Button ID="btnLayBaoCao" runat="server" Text="Lấy danh sách" OnClick="btnLayBaoCao_Click" Width="99px" />
                                    <asp:Button ID="btnXuatExcel" runat="server" Text="Xuất Excel" OnClick="btnXuatExcel_Click" Width="99px" />--%>
                                    
                                    <input  type="button" id="btnXuatExcel"  runat="server" value="Xuất Excel"  onserverclick="btnXuatExcel_Click" style="width:99px"/>
                                    <input type="button" id="btnAutoClick" runat="server" value="." style="width:0px" onserverclick="btnAutoClick_Click" />
                                        <input id="hdListIdG" runat="server" type="hidden" />
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
<script language="javascript" type="text/javascript">
function nvk_benhnhansearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/nvk_TongHopYLenh_ajax.aspx?do=nvk_benhnhansearch",{
             minChars:0,
             width:700,
             scroll:true,
             addRow:false,
             header:"Bệnh Nhân...",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                obj.value="";
                setBenhNhan(data[1],1);   // thêm bệnh nhân vào danh sách đã chọn           
                 setTimeout(function () {
                     obj.focus();
                 },100);
                 
             });
             
         }
function setBenhNhan(idbenhnhan,tinhtrangCheck)
	{
    $("#divGiuongDaChon").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang Load Bệnh Nhân.....<img id='imgLoading' src='../images/processing.gif' /></span>");
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
        xmlHttp.open("GET","../ajax/nvk_TongHopYLenh_ajax.aspx?do=ShowDanhSachBenhNhanChon&ListIdBN="+ListIdGiuong+"&idBN="+idbenhnhan+"&tinhtrangCheck="+tinhtrangCheck+"&times="+Math.random(),true);
        xmlHttp.send(null);
	}
function LoadAll_BN_YLenh(obj)
{
var IdKhoThuoc= document.getElementById("ddlKhoThuoc").value;
var IdLoaiThuoc= document.getElementById("ddlLoaiThuoc").value;
var NgayYL = document.getElementById("txtTuNgay").value;
var TuGio = $("#txtTuGio").val();
var denNgayYL = document.getElementById("txtDenNgay").value;
var DenGio = $("#txtDenGio").val();
var IdLoaiYLenh= document.getElementById("ddlLoaiYLenh").value;
//alert(TuGio+";"+DenGio);return;
    if(obj.checked==true)
    {
    $("#divGiuongDaChon").html("<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang Load Bệnh Nhân.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_TongHopYLenh_ajax.aspx?do=LoadAll_BN_YLenh&IdLoaiYLenh="+IdLoaiYLenh+"&IdKhoa="+$.mkv.queryString("IdKhoa")+"&NoiYLenh="+$.mkv.queryString("dkmenu")+"&IdLoaiThuoc="+IdLoaiThuoc+"&IdKhoThuoc="+IdKhoThuoc+"&NgayYL="+NgayYL+"&TuGio="+TuGio+"&DenNgayYL="+denNgayYL+"&DenGio="+DenGio+"";
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                        if(value=="" || value=="0")
                            alert("Không có Y Lệnh trong ngày !");
                        document.getElementById('hdListIdG').value=value;
                        setBenhNhan(0,1); 
                        }
                });
    }
    else
    {
        document.getElementById('hdListIdG').value="";
        setBenhNhan(0,1); 
    }
}
</script>
<!-- #include file="../noitru/footer.htm" -->

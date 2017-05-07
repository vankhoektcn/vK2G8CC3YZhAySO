<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTCN_NhaCungCap_CT_vanta.aspx.cs" Inherits="KTCN_NhaCungCap_CT" %>

<%@ Register Src="Menu_KT/uscmenuKT_CongNo.ascx" TagName="uscmenuKT_CongNo" TagPrefix="uc1" %>
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<!--#include file ="header.htm"-->
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>

<%@ Register Assembly="CrystalDecisions.Web,  Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<script language = "javascript" type="text/javascript"> 
var dp_cal, dp_cals;      
	window.onload = function () 
	{
	     //LoadTieuDe();
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgay'));
	    dp_cals = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
	};
	function LoadTieuDe()
    {
        var obj = document.getElementById("tieudepk");
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                obj.innerHTML = value;                
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=LoadTieuDe&times="+Math.random(),true);
        xmlHttp.send(null);
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
	var CheckType = "NhaCungCap";
	function ddlMaKhachHang_select()
	{
	    var index =  document.getElementById("ddl_MaKH").selectedIndex;
	    var select = document.getElementsByTagName("option")[index].value;
	    	    
//	    var index=document.getElementById("SelectMonth").selectedIndex;
//    var thang = document.getElementsByTagName("option")[index].value;
	
	    if(select == "0")
	    {
	        
	        CheckType = "NhaCungCap";
	    }
	    else
	    if(select=="1")
	    {
	        CheckType = "KhachHang";
	    }
	    else
	    if(select=="2")
	    {
	        CheckType = "BenhNhan";
	    }
	    document.getElementById('txtMa_kh').value = "";
	}
	function ShowKhachHang(obj)
    {
        if(CheckType =="BenhNhan")
        {
            var objsrc = document.getElementById(obj);
      
                $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachBenhNhan&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:700,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonBenhNhan(data[2],data[3],data[4]);
                                                                   // document.getElementById(obj).blur();
                                                                }
                                                            ); 
        }         
        else
        if(CheckType =="KhachHang")
        {
             var objsrc = document.getElementById(obj);
          
                $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachKhachHang&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                            {width:700,scroll:true,formatItem:function(data)
                                                                {return data[1];}
                                                            }
                                                        ).result(
                                                                    function(event,data)
                                                                    {
                                                                        setChonKhachHang(data[2],data[3]);
                                                                       // document.getElementById(obj).blur();
                                                                    }
                                                                ); 
        }
        else
         if(CheckType =="NhaCungCap")
        {
            var objsrc = document.getElementById(obj);
      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachNhaCungCap4&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:300,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonNCC(data[2],data[3],data[4]);
                                                                    document.getElementById(obj).blur();
                                                                }
                                                            ); 
        }
}
function setChonNCC(idNCC,MaNCC,TenNCC)
{      
      var txtMaKH=document.getElementById('txtMa_kh');
      //var txtTenKH=document.getElementById('txtTenKH');
      //var hd_IDBN = document.getElementById('hd_idNCC');
      txtMaKH.value=MaNCC;
//      txtTenKH.value = TenNCC;
//      hd_IDBN.value = idNCC;
      //alert(hd_IDBN.value);
}
function setChonBenhNhan(MaKH,TenKH,idBenhNhan)
{
      
      var txtMaKH=document.getElementById('txtMa_kh');
//      var txtTenKH=document.getElementById('txtTenKH');
//      var hd_IDBN = document.getElementById('hd_idBenhNhan');
      txtMaKH.value=MaKH;
//      txtTenKH.value = TenKH;
//      hd_IDBN.value = idBenhNhan;
      //alert(hd_IDBN.value);
}
function setChonKhachHang(MaKH,TenKH)
{
      
      var txtMaKH=document.getElementById('txtMa_kh');
//      var txtTenKH=document.getElementById('txtTenKH');
      txtMaKH.value=MaKH;
//      txtTenKH.value = TenKH;
      
      //alert(hd_IDBN.value);
}
	function ShowTaiKhoan(Ctr)
{
    var obj = Ctr.id;
    var objsrc = document.getElementById(obj);
  
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);
                                                             //   document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,idText)
{
      if(idText!="")
      {
          var txtTaiKhoan=document.getElementById(idText);
          txtTaiKhoan.value=MaTaiKhoan;
          txtTaiKhoan.focus();
      }
}

function TestMaTaiKhoan(Ctr)
{
    var txtTaiKhoan = Ctr.id;
    var MaTaiKhoan = document.getElementById(txtTaiKhoan);
    if(MaTaiKhoan.value!="")
    {
        xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="1")
                      {  
                         alert("Tài khoản bạn chọn chưa có trong danh mục tài khoản. Vui lòng kiểm tra lại. Cảm ơn!");
                         MaTaiKhoan.value ="";
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TestMaTaiKhoan&Key="+MaTaiKhoan.value+"&times="+Math.random(),true);
            xmlHttp.send(null);
    }
}	
</script>
<form id="Form1" method="post" runat="server">
    <uc1:uscmenuKT_CongNo ID="uscmenuKT_CongNo1" runat="server" />
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" >        
    <tr>
        <td width = "100%" align = "left" >
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px; width: 100%;">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px" bgcolor="#FFFFFF">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style ="background-color: #4D67A2">
			                <span class="title" style ="color:#FFFFFF">CÔNG NỢ NHÀ CUNG CẤP CHI TIẾT</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
                            Từ ngày:
                            <asp:textbox id="txtNgay" runat="server" height="20px" tabindex="2" width="149px"></asp:textbox>
                            đến ngày:
                            <asp:textbox id="txtDenNgay" runat="server" height="20px" tabindex="2" width="149px"></asp:textbox>
                            &nbsp;Tài khoản:
                            <asp:dropdownlist id="drltaikhoan" runat="server"> </asp:dropdownlist>                             
                            <%--<asp:textbox id="txtTaiKhoan" runat="server" height="20px" tabindex="2" width="104px" onfocus="ShowTaiKhoan(this);" ></asp:textbox>--%>
                            &nbsp;Mã KH:
                            <select id="ddl_MaKH" style="width:150px" onchange="ddlMaKhachHang_select()">
                                <option value="0">Nhà cung cấp</option>                                
                            </select> 
                            
                            <asp:textbox id="txtMa_kh" runat="server" height="20px" onfocus="ShowKhachHang('txtMa_kh')" tabindex="2" width="149px"></asp:textbox>                          
                            <asp:button id="btnXem" runat="server" onclick="btnXem_Click" text="Xem báo cáo" /></TD>
				    </TR>
			    </table>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    DisplayGroupTree="False" PrintMode="ActiveX" Width="99%" OnUnload="CrystalReportViewer1_Unload" />
		    </td>
	    </tr>				
    </table>
        </td>
       </tr>
     </table>    
 </form>
<!--#include file ="footer.htm"-->
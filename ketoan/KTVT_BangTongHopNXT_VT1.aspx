<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTVT_BangTongHopNXT_VT1.aspx.cs" Inherits="ketoan_KTVT_BangTongHopNXT_Vt" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_CCDC.ascx" TagName="uscmenuKT_CCDC" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

ư<!--#include file ="header.htm"-->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>    
<%@ Register Src="menu_baocaotaichinh.ascx" TagName="menu_baocaotaichinh" TagPrefix="uc1" %>

<%@ Register Assembly="CrystalDecisions.Web,  Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <script language="javascript" type="text/javascript">
    var dp_cals,dp_cal;      
	window.onload = function () 
	{
	    //Tu ngay - Den ngay (show popup lich)
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtdatestart'));
	    dp_cals = new Epoch('epoch_popup','popup',document.getElementById('txtdateend'));	
	    LoadTieuDe();   
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
  
	function Xem(check)
	{
	    var ngaybd=document.getElementById("ngaybd");
	    var iCount = checkItemChecked(check);
	    if(iCount != 0)
        {
            ngaybd.style.display="none";
        }
	    else
	    {
	        ngaybd.style.display="";
	    }
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
        </script>

        <form id="Form2" runat="server">
            <table id="user" border="0" cellpadding="1" cellspacing="1" width="100%">
             <tr>
                <td align = "left" valign = "top" style="height: 34px;background-color:#007138">
                    <uc1:uscmenuKT_CCDC ID="uscmenuKT_CCDC" runat="server" />
                </td>
            </tr>
               <tr>
                    <td class="title" style="padding-bottom: 10px; width: 945px">
                        <p class="title">
                            <img align="middle" border="0" src="../images/khuvuc.png" />
                            BẢNG TỔNG HỢP NHẬP XUẤT TỒN </p>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-bottom: 10px; width: 945px; height: 41px">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">                            
                          <TR>
					        <TD width="100%">
                            Từ ngày:
                            <asp:textbox id="txtdatestart" runat="server" height="20px" tabindex="2" width="149px"></asp:textbox>
                            đến ngày:
                            <asp:textbox id="txtdateend" runat="server" height="20px" tabindex="2" width="149px" ></asp:textbox>
                            &nbsp;Tài khoản kho:
                            <asp:textbox id="txtTaiKhoan" runat="server" height="20px" tabindex="2" width="104px" onfocus="ShowTaiKhoan(this);"></asp:textbox>
                            <asp:button id="btnXem" runat="server" onclick="btnXem_ServerClick" text="Xem báo cáo" /></TD>
				         </TR>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%" bgcolor="#FFFFFF">
                        <table border="0" cellpadding="0" width="100%">
                            <tr>
                                <td align="center" height="12" style="text-align: left" valign="top" width="100%">
                                    &nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </form>
        <!--#include file ="footer.htm"-->
    

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BCTC_BangCanDoi_TK2.aspx.cs" Inherits="ketoan_BCTC_BangCanDoi_TK" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_BaoCaoTaiChinh.ascx" TagName="uscmenuKT_BCDTK2" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<!--#include file ="header.htm"-->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />


<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <script language="javascript" type="text/javascript">
    var dp_cals,dp_cal;      
	window.onload = function () 
	{
	    //Tu ngay - Den ngay (show popup lich)
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtdatestart'));
	    dp_cals = new Epoch('epoch_popup','popup',document.getElementById('txtdateend'));	
	    //LoadTieuDe();   
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
        </script>

        <form id="Form2" runat="server">
            <table id="user" border="0" cellpadding="1" cellspacing="1" width="100%">
             <tr>
                <td align = "left" valign = "top" style="height: 34px;background-color:#007138">
                    <uc1:uscmenuKT_BCDTK2 ID="uscmenuKT_BCDTK21" runat="server" />
                </td>
            </tr>
               <tr>
                    <td class="title" style="padding-bottom: 10px; width: 945px">
                        <p class="title">
                            <img align="middle" border="0" src="../images/khuvuc.png" />
                            BẢNG CÂN ĐỐI TÀI KHOẢN</p>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-bottom: 10px; width: 945px; height: 41px">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left" colspan="5" style="height: 25px">
                                    <td id="ngaybd" style="width: 190px">
                                         <span class="ptext">
                                            <asp:Label id="Label1" runat="server" cssClass="ptext" Style="text-align: right" Text="Từ ngày:" Width="65px"></asp:Label>
                                            <asp:textbox id="txtdatestart" runat="server" width="80px">
                                            </asp:textbox>
                                            <input onclick="dp_cal.toggle()" type="button" value="..." id="tungay" />
                                         </span>
                                    </td>
                                    <td id="ngaykt" style="width: 197px">
                                            <span class="ptext">
                                                <asp:label id="Label2" runat="server" cssclass="ptext" style="text-align: right" text="Đến ngày:" width="72px"></asp:label>
                                                <asp:TextBox ID="txtdateend" runat="server" Width="80px"></asp:TextBox>&nbsp;
                                                <input onclick="dp_cals.toggle()" type="button" value="..." id="denngay" />
                                            </span>
                                    </td>
                                    <td style="width: 555px">
                                        &nbsp; &nbsp;&nbsp;&nbsp; <input id="btnXem" runat="server" onserverclick="btnXem_ServerClick" style="width: 76px"
                                            type="button" value="Xem" />
                                    </td>
                                </td>
                            </tr>
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
    

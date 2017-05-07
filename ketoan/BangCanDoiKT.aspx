<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangCanDoiKT.aspx.cs" Inherits="ketoan_BangCanDoiKT" %>
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_BaoCaoTaiChinh.ascx" TagName="uscmenuKT_BaoCaoTaiChinh" TagPrefix="uc1" %>

    <!--#include file ="header.htm"-->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />

<%@ Register Assembly="CrystalDecisions.Web,  Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <script language="javascript" type="text/javascript">
    var dp_cals,dp_cal,ms_cal;      
	window.onload = function () 
	{
	    //Tu ngay - Den ngay (show popup lich)	   
	    dp_cals = new Epoch('epoch_popup','popup',document.getElementById('txtdateend'));	 
	    dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtdatestart'));
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
     </script>

        <form id="Form2" runat="server">
            <table id="user" border="0" cellpadding="1" cellspacing="1" width="100%">
             <tr>
                <td align = "left" valign = "top" style="height: 34px;background-color:#007138">
                    <uc1:uscmenuKT_BaoCaoTaiChinh ID="uscmenuKT_BaoCaoTaiChinh" runat="server" />
                </td>
            </tr>
               <tr>
                    <td class="title" style="padding-bottom: 10px; width: 945px">
                        <p class="title">
                            <img align="middle" border="0" src="../images/khuvuc.png" />
                            BẢNG CÂN ĐỐI KẾ TOÁN</p>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-bottom: 10px; width: 945px; height: 41px">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left" colspan="5" style="height: 25px">                                    
                                    </span>                                    
                                             <span class="ptext"><asp:Label
                                                ID="Label1" runat="server" cssClass="ptext" Style="text-align: right" Text="Từ ngày:"
                                                Width="110px"></asp:Label></span><span class="ptext">
                                                <asp:TextBox ID="txtdatestart" runat="server" Width="80px"></asp:TextBox>&nbsp;
                                            </span>&nbsp;
                                            
                                            <span class="ptext"><asp:Label
                                                ID="Label2" runat="server" cssClass="ptext" Style="text-align: right" Text="Đến ngày:"
                                                Width="110px"></asp:Label></span><span class="ptext">
                                                <asp:TextBox ID="txtdateend" runat="server" Width="80px"></asp:TextBox>&nbsp;
                                            </span>&nbsp; &nbsp;&nbsp;
                                    <input id="btnXem" runat="server" onserverclick="btnXem_ServerClick" style="width: 76px"
                                        type="button" value="Xem" />
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
    

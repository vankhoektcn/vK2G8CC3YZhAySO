<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nvk_InToaXuatVien.aspx.cs"
    EnableViewState="true" Inherits="nvk_InToaXuatVien" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!--#include file ="../noitru/nvk_headerTongHop.htm"-->
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />

<script language="javascript">
    function TestDatePhieu(t)
	{
		if (t.value != "")
		{
			t.value=AddString(t.value);
			if (isDate(t.value)==false)
			{
				t.value="";
				alert("B?n nh?p ngày tháng không h?p l? ! ");
				t.focus();
			}
		}
		return;
	}
	
	 
</script>

<form id="Form1" method="post" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                    <tr>
                        <td class="title" align="center" style="background-color: #4D67A2; height: 21px;">
                            <span class="title" id="spTieuDeToaThuoc" runat="server" style="color: #FFFFFF">Chi
                                Tiết Toa Thuốc</span></td>
                    </tr>
                    <tr>
                        <td width="100%" style="height: 21px">
                        </td>
                    </tr>
                </table>
                <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
                    displaygrouptree="False" printmode="ActiveX" width="99%" onunload="CrystalReportViewer1_Unload" />
            </td>
        </tr>
    </table>
</form>
<!--#include file ="../noitru/footer.htm"-->

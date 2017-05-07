<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptnhanvienungluong.aspx.cs" Inherits="rptnhanvienungluong" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>

<!--#include file = "header.htm" -->
<form id="Form1" method="post" runat="server"> 
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#FBF8F1; height: 19px;">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user" class = "khung">
                <tr>
		            <td class="title" align = "left" style ="background-color: #4D67A2">
	                    <span class="title" style ="color:#FFFFFF">BỆNH VIỆN MEKONGVIET:: QUẢN LÝ NHÂN SỰ:: DANH SÁCH NHÂN VIÊN ỨNG LƯƠNG</span>
                    </td>
		        </tr>
		        <tr>
                                    <td align="center" style="width: 99%; height: 26px;" valign="top">
                                        <asp:Label ID="Label1" runat="server" CssClass="ptext" Text="Chọn tháng năm:"></asp:Label>
                                        &nbsp;
                                        <asp:DropDownList ID="ddlthang" runat="server" TabIndex="1">
                                            <asp:ListItem Value="1">Tháng 1</asp:ListItem>
                                            <asp:ListItem Value="2">Tháng 2</asp:ListItem>
                                            <asp:ListItem Value="3">Tháng 3</asp:ListItem>
                                            <asp:ListItem Value="4">Tháng 4</asp:ListItem>
                                            <asp:ListItem Value="5">Tháng 5</asp:ListItem>
                                            <asp:ListItem Value="6">Tháng 6</asp:ListItem>
                                            <asp:ListItem Value="7">Tháng 7</asp:ListItem>
                                            <asp:ListItem Value="8">Tháng 8</asp:ListItem>
                                            <asp:ListItem Value="9">Tháng 9</asp:ListItem>
                                            <asp:ListItem Value="10">Tháng 10</asp:ListItem>
                                            <asp:ListItem Value="11">Tháng 11</asp:ListItem>
                                            <asp:ListItem Value="12">Tháng 12</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlnam" runat="server" TabIndex="2">
                                            <asp:ListItem Value="2010">năm 2010</asp:ListItem>
                                            <asp:ListItem Value="2011">năm 2011</asp:ListItem>
                                            <asp:ListItem Value="2012">năm 2012</asp:ListItem>
                                            <asp:ListItem Value="2013">năm 2013</asp:ListItem>
                                            <asp:ListItem Value="2014">năm 2014</asp:ListItem>
                                            <asp:ListItem Value="2015">năm 2015</asp:ListItem>
                                            <asp:ListItem Value="2016">năm 2016</asp:ListItem>                                            
                                            <asp:ListItem Value="2017">năm 2017</asp:ListItem>
                                            <asp:ListItem Value="2018">năm 2018</asp:ListItem>
                                            <asp:ListItem Value="2019">năm 2019</asp:ListItem>
                                            <asp:ListItem Value="2020">năm 2020</asp:ListItem>
                                            <asp:ListItem Value="2021">năm 2021</asp:ListItem>
                                            <asp:ListItem Value="2022">năm 2022</asp:ListItem>
                                            <asp:ListItem Value="2023">năm 2023</asp:ListItem>                                            
                                            <asp:ListItem Value="2024">năm 2024</asp:ListItem>
                                            <asp:ListItem Value="2025">năm 2025</asp:ListItem>
                                            <asp:ListItem Value="2026">năm 2026</asp:ListItem>                                            
                                            <asp:ListItem Value="2027">năm 2027</asp:ListItem>
                                            <asp:ListItem Value="2028">năm 2028</asp:ListItem>
                                            <asp:ListItem Value="2029">năm 2029</asp:ListItem>
                                            <asp:ListItem Value="2030">năm 2030</asp:ListItem>
                                            <asp:ListItem Value="2031">năm 2031</asp:ListItem>
                                            <asp:ListItem Value="2032">năm 2032</asp:ListItem>
                                            <asp:ListItem Value="2033">năm 2033</asp:ListItem>                                            
                                            <asp:ListItem Value="2034">năm 2034</asp:ListItem>
                                            <asp:ListItem Value="2035">năm 2035</asp:ListItem>
                                            <asp:ListItem Value="2036">năm 2036</asp:ListItem>                                            
                                            <asp:ListItem Value="2037">năm 2037</asp:ListItem>
                                            <asp:ListItem Value="2038">năm 2038</asp:ListItem>
                                            <asp:ListItem Value="2039">năm 2039</asp:ListItem>
                                            <asp:ListItem Value="2040">năm 2040</asp:ListItem>
                                            <asp:ListItem Value="2005">năm 2041</asp:ListItem>
                                            <asp:ListItem Value="2006">năm 2042</asp:ListItem>
                                            <asp:ListItem Value="2007">năm 2043</asp:ListItem>
                                            <asp:ListItem Value="2008">năm 2044</asp:ListItem>
                                            <asp:ListItem Value="2009">năm 2045</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="bntxemluong"
                                            runat="server" OnClick="bntxemluong_Click" Text="Xem" Width="75px" TabIndex="4" /></td>
                                </tr>
                <tr>
                    <td id = "noidungnewfile" align = "left" valign = "middle">
                        <CR:CrystalReportViewer ID="CRV" runat="server" AutoDataBind="true" DisplayGroupTree="False"
                            PrintMode="ActiveX" OnUnload="CRV_Unload" />
                       
                    </td>
                </tr>
            </table>
          </td>
     </tr>
</table>
</form>          
<!--#include file = "footer.htm" -->

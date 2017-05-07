<%@ Page Language="C#" AutoEventWireup="true" CodeFile="listkhacklecanlamsan.aspx.cs"
    Inherits="listkhacklecanlamsan" %>

<link type="text/css" rel="stylesheet" href="..js/epoch_styles.css" />
<!--#include file ="header.htm"-->
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>

<script type="text/javascript" src="../js/epoch_classes.js"></script>

<script language="javascript">
   var dp_cal1; 
      var dp_cal; 
	window.onload = function () 
	{
	  dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));
	    dp_cal= new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));
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
</script>

<form id="Form1" method="post" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" style="background-color: #C0C0C0;
        width: 100%;">
        <tr>
            <td align="left" style="background-color: #D4D0C8; height: 10px; width: 100%;">
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
            </td>
        </tr>
        <tr>
            <td align="left" style="background-color: #D4D0C8; width: 95%;">
                <table cellspacing="1" cellpadding="1" width="98%" align="center" border="0" class="khung">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2">
                                        <p class="title" style="color: #FFFFFF">
                                            <strong>KẾT QUẢ CẬN LÂM SÀNG (BNĐK)</strong></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: 46px">
                                                    <table cellspacing="0" cellpadding="0" width="98%" border="0" style="height: 89px">
                                                        <tr style="padding-bottom: 5px; padding-top: 10px">
                                                            <td align="left" width="100%" style="height: 100px">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 138px; height: 21px">
                                                                            Khoa/phòng: &nbsp;</td>
                                                                        <td style="width: 90px; height: 21px">
                                                                            <asp:dropdownlist id="ddlPK" runat="server" autopostback="true" onselectedindexchanged="ddlPK_SelectedIndexChanged1"
                                                                                width="184px"></asp:dropdownlist>
                                                                        </td>
                                                                        <td colspan="2" style="height: 21px">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Loại khám
                                                                            :</td>
                                                                        <td style="width: 100px; height: 21px">
                                                                            <asp:dropdownlist id="cbLoaiBN" runat="server" autopostback="true" width="143px"></asp:dropdownlist>
                                                                        </td>
                                                                        <td colspan="2" style="height: 21px">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Bác sĩ :</td>
                                                                        <td style="width: 99px; height: 21px">
                                                                            <asp:dropdownlist id="ddlBS" runat="server" width="187px"></asp:dropdownlist>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 138px; height: 26px">
                                                                            Mã bệnh nhân:&nbsp;
                                                                        </td>
                                                                        <td style="width: 90px; height: 26px">
                                                                            <asp:textbox id="txtMaBenhNhan" runat="server" readonly="False" tabindex="1" width="181px"></asp:textbox>
                                                                        </td>
                                                                        <td colspan="2" style="height: 26px">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Mã
                                                                            CLS:</td>
                                                                        <td colspan="4" style="height: 26px">
                                                                            <asp:textbox id="txtMaCLS" runat="server" width="144px"></asp:textbox>
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Tên bệnh nhân:&nbsp;&nbsp;<asp:textbox id="txtTenBenhNhan"
                                                                                runat="server" tabindex="2" width="176px"></asp:textbox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 138px">
                                                                            Địa chỉ:&nbsp;
                                                                        </td>
                                                                        <td colspan="4">
                                                                            <asp:textbox id="txtDiaChi" runat="server" tabindex="4" width="502px"></asp:textbox>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Số BHYT:</td>
                                                                        <td style="width: 99px">
                                                                            <asp:textbox id="txtSoBHYT" runat="server" readonly="False" tabindex="1" width="177px"></asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 138px; height: 30px">
                                                                            Ngày ĐKCLS từ :
                                                                        </td>
                                                                        <td style="width: 90px; height: 30px">
                                                                            <asp:textbox id="txtTuNgay" runat="server" tabindex="1" width="179px"></asp:textbox>
                                                                        </td>
                                                                        <td style="width: 26px; height: 30px">
                                                                            <input id="Button4" onclick="dp_cal1.toggle()" style="width: 25px" type="button"
                                                                                value="..." /></td>
                                                                        <td style="width: 136px; height: 30px">
                                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Đến Ngày :</td>
                                                                        <td style="width: 100px; height: 30px">
                                                                            <asp:textbox id="txtDenNgay" runat="server" tabindex="1" width="140px"></asp:textbox>
                                                                        </td>
                                                                        <td style="width: 15px; height: 30px">
                                                                            <input id="Button2" onclick="dp_cal.toggle()" style="width: 25px" type="button" value="..." /></td>
                                                                        <td style="width: 100px; height: 30px">
                                                                            <asp:imagebutton id="ImageButton1" runat="server" imageurl="~/images/tim.png" onclick="ImageButton1_Click"
                                                                                tabindex="11"></asp:imagebutton>
                                                                        </td>
                                                                        <td style="width: 99px; height: 30px">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left" width="100%" style="height: 20px">
                                                    <asp:label forecolor="red" id="lblTotal" runat="server"></asp:label>
                                                </td>
                                            </tr>
                                        </table>
                                        <fieldset>
                                            <legend><strong style="color: Blue;">DANH SÁCH BỆNH NHÂN CHỜ CẬN LÂM SÀNG</strong></legend>
                                            <table cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top" align="center" width="100%" colspan="2" height="20">
                                                        <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                            autogeneratecolumns="False" datakeyfield="IDKhamBenhCanLamSan" borderwidth="1px"
                                                            bordercolor="Silver" onitemdatabound="dgr_ItemDataBound" cellpadding="2" ondeletecommand="DelBenhNhan"
                                                            oneditcommand="Edit" onpageindexchanged="PageIndexStyleChanged" pagesize="40">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" CommandName="Delete" runat="server" CssClass="alink3">CLS</asp:LinkButton>											    
</ItemTemplate>
<HeaderStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn Visible="False"><ItemTemplate>
<asp:Label ID="lblIdBN" Text='<%#Eval("idbenhnhan") %>' visible="false" runat="server"></asp:Label>
														    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Sửa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="6%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT"><ItemTemplate>
		<%=STT()%>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="ngaythu" DataFormatString="{0:dd/MM hh:mm}" HeaderText="Ng&#224;y ĐK">
<HeaderStyle Width="12%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="madangkycls" HeaderText="Mã CLS">
<HeaderStyle Wrap="False" Width="7%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="19%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TenGioiTinh" HeaderText="Giới t&#237;nh"></asp:BoundColumn>
<asp:BoundColumn DataField="ngaysinh" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ng&#224;y sinh">
<HeaderStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="12%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SoBHYT" HeaderText="Số BHYT"></asp:BoundColumn>
<asp:BoundColumn DataField="BSChiDinh" HeaderText="BS chỉ định">
<HeaderStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="11%"></HeaderStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader"></HeaderStyle>
</asp:datagrid>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;">
                            <div id="infospace" runat="server">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</form>
<!-- #include file="footer.htm" -->

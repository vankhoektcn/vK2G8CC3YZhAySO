<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDSBNChoTTVP.aspx.cs" Inherits="frmDSBNChoTTVP" %>

<!--#include file ="header.htm"-->

<script language="javascript" type="text/javascript">
    var dp_cal1; 
    var dp_cal2; 
	window.onload = function () 
	{	    
	    dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));	  
	    dp_cal2 = new Epoch('epoch_popup','popup',document.getElementById('txtDenNgay'));	   
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
    <table cellpadding="0" cellspacing="0" border="0" style="background-color: #C0C0C0">
        <tr>
            <td>
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" border="0" style="margin-top: 17px;"
                                class="khung">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2; height: 21px;">
                                        <span class="title" style="color: #FFFFFF"><strong>
                                            <asp:label id="lbHeader" runat="server" text="BẢNG KÊ CHI PHÍ ĐỒNG CHI TRẢ" width="744px"></asp:label>
                                        </strong></span></td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: 64px">
                                                    <table cellspacing="0" cellpadding="0" width="98%" border="0" style="height: 14px">
                                                        <tr style="padding-bottom: 5px; padding-top: 10px">
                                                            <td align="left" width="100%" style="height: 100px">
                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 1236px">
                                                                    <tr>
                                                                        <td style="padding-top: 2px; padding-left: 20px; height: 26px; width: 55px;" align="left">
                                                                            Mã BN</td>
                                                                        <td style="padding-top: 2px; height: 26px;" align="left">
                                                                            <span class="ptext">
                                                                                <asp:textbox id="txtMaBenhNhan" runat="server" width="100px" tabindex="4"></asp:textbox>
                                                                                &nbsp; &nbsp;Tên bệnh nhân
                                                                                <asp:textbox id="txtTenBenhNhan" runat="server" width="178px" tabindex="4"></asp:textbox>
                                                                                &nbsp; Từ ngày:
                                                                                <asp:textbox id="txtTuNgay" runat="server" tabindex="9" width="76px"></asp:textbox>
                                                                                <input style="width: 25px" id="Button4" onclick="dp_cal1.toggle()" type="button"
                                                                                    value="..." />
                                                                                Đến ngày :
                                                                                <asp:textbox id="txtDenNgay" runat="server" tabindex="9" width="81px"></asp:textbox>
                                                                                <input style="width: 25px" id="btnDenNgay" runat="server" onclick="dp_cal2.toggle()"
                                                                                    type="button" value="..." />
                                                                                <asp:imagebutton id="ImageButton1" runat="server" imageurl="../images/tim.png" tabindex="10"
                                                                                    onclick="ImageButton1_Click"></asp:imagebutton>
                                                                                <asp:imagebutton id="btnCancel" tabindex="11" onclick="btnCancel_Click" runat="server"
                                                                                    imageurl="../images/MOI.gif"></asp:imagebutton>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    <!--
                                                                    <tr>
                                                                        <td style="padding-top: 2px; width: 15%; padding-left: 20px; height: 26px;" align="left">
                                                                            <span class="ptext">Loại BHYT</span>&nbsp;</td>
                                                                        <td style="padding-top: 2px; width: 85%; height: 26px;" align="left">
                                                                            <span class="ptext">
                                                                                <asp:dropdownlist id="ddlLoaiBHYT" runat="server"><asp:ListItem Value="2">Chọn loại BHYT</asp:ListItem>
                                                                                <asp:ListItem Value="0">Dịch vụ</asp:ListItem>
                                                                                <asp:ListItem Value="1">C&#243; BH</asp:ListItem>
                                                                                </asp:dropdownlist>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    -->
                                                                </table>
                                                                &nbsp;
                                                                <asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                                    autogeneratecolumns="False" datakeyfield="Id" borderwidth="1px" bordercolor="#3366CC"
                                                                    cellpadding="4" onitemdatabound="dgr_ItemDataBound" onitemcommand="dgr_ItemCommand"
                                                                    backcolor="White" borderstyle="None" horizontalalign="Left">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="#99CCCC" Font-Names="Arial" Font-Size="Small" ForeColor="#003399"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="White" CssClass="dgrNoSelectItem" ForeColor="#003399"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lnkViewBV" runat="server" CommandName="ViewBV" Text='<%# Eval("TenBV") %>' __designer:wfdid="w3"></asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="4%"></HeaderStyle>
</asp:TemplateColumn>
<asp:ButtonColumn CommandName="ViewBangKe" Text="Đ.C.Trả">
<HeaderStyle Wrap="False" Width="4%"></HeaderStyle>
</asp:ButtonColumn>
<asp:BoundColumn DataField="STT" HeaderText="STT">
<HeaderStyle Width="1%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NgayTinhBH" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ng&#224;y ">
<HeaderStyle Width="8%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; BN">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaysinh" HeaderText="Ng&#224;y sinh">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="sobhyt" HeaderText="Số BHYT">
<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DungTuyen" HeaderText="Đ/TT">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TongSoTien" DataFormatString="{0:N0}" HeaderText="Tổng">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BHTRA" DataFormatString="{0:N0}" HeaderText="BH trả">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BNPhaiTra" DataFormatString="{0:N0}" HeaderText="BN trả">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="BNDaTraChenhLechBHYT" DataFormatString="{0:N0}" HeaderText="Đ&#227; trả">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="IsNoiTru" Visible="False"></asp:BoundColumn>
<asp:BoundColumn DataField="IDCHITIETDANGKYKHAM" Visible="False"></asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#003399" CssClass="dgrHeader" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>
</asp:datagrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left" width="100%" colspan="2" style="height: 20px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</form>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="benhnhanlist.aspx.cs" Inherits="benhnhanlist" %>

<!--#include file ="header.htm"-->
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
    <script type="text/javascript" src="../js/epoch_classes.js"></script>
        <link type="text/css" rel="stylesheet" href="../js/epoch_styles.css" />
<script language = "javascript">
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
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "center" style ="background-color:#D4D0C8">
        <table cellspacing="1" cellpadding="1" width="98%" border="0" class = "khung">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="0" cellPadding="0" width="100%" border="0">
				    <tr>
				        <td class="title" colspan = "2" align = "center" style="background-color: #4D67A2; height: 19px;">
					        <p class="title" style ="color:#FFFFFF">
                                <strong>KẾT QUẢ CẬN LÂM SÀNG (BSCĐ)</strong></p>
				        </td>
			        </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: 132px">
                                        <table>
                                            <tr>
                                                <td style="width: 138px; height: 21px">
                                                    Khoa/phòng: &nbsp;</td>
                                                <td style="width: 90px; height: 21px">
						                                        <asp:dropdownlist id="ddlPK" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlPK_SelectedIndexChanged1" Width="184px"></asp:dropdownlist>
                                                </td>
                                                <td colspan="2" style="height: 21px">
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; Loại khám :</td>
                                                <td style="width: 100px; height: 21px">
                                                    <asp:dropdownlist id="cbLoaiBN" runat="server" autopostback="true" width="143px"></asp:dropdownlist>
                                                </td>
                                                <td colspan="2" style="height: 21px">
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                    Bác sĩ :</td>
                                                <td style="width: 99px; height: 21px">
                                                            <asp:dropdownlist id="ddlBS"  runat="server" Width="176px" ></asp:dropdownlist>
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
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;Tên bệnh nhân:&nbsp;</td>
                                                <td colspan="4" style="height: 26px">
                                                    <asp:TextBox ID="txtTenBenhNhan" Runat="server" Width="424px" tabIndex="2"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 138px">
                                                                    Địa chỉ:&nbsp;
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtDiaChi" Runat="server" Width="487px" tabIndex="4"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    Số BHYT:</td>
                                                <td style="width: 99px">
                                                    <asp:textbox id="txtSoBHYT" runat="server" readonly="False" tabindex="1" width="170px"></asp:textbox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 138px; height: 30px;">
                                                    Ngày ĐKCLS từ :
                                                </td>
                                                <td style="width: 90px; height: 30px;">
													     <asp:textbox id="txtTuNgay" runat="server" tabindex="1" width="179px"></asp:textbox>
                                                                </td>
                                                <td style="width: 26px; height: 30px">
                                                                <input id="Button4" onclick="dp_cal1.toggle()" style="width: 25px" type="button"
                                                                    value="..." /></td>
                                                <td style="width: 126px; height: 30px;">
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    Đến Ngày :</td>
                                                <td style="width: 100px; height: 30px;">
                                                                      <asp:textbox id="txtDenNgay" runat="server" tabindex="1" width="140px"></asp:textbox></td>
                                                <td style="width: 15px; height: 30px">
                                                    <input id="Button2" onclick="dp_cal.toggle()" style="width: 25px" type="button"
                                                                    value="..." /></td>
                                                <td style="width: 100px; height: 30px;">
                                                    <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/images/tim.png" TabIndex="11" OnClick="ImageButton1_Click"></asp:ImageButton>
                                                </td>
                                                <td style="width: 99px; height: 30px;">
                                                </td>
                                            </tr>
                                        </table>
								    </TD>
							    </TR>
						    </TABLE>
						      <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" style="height: 20px"><asp:Label forecolor="red" ID="lblTotal" runat="server" ></asp:Label>
								    </TD>
							    </TR>
						    </TABLE>	
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" height="20"><span class="title">DANH SÁCH BỆNH NHÂN CHỜ CLS</span>
								    </TD>
							    </TR>
						    </TABLE>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
									    <asp:datagrid id="dgr" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
											    DataKeyField="IDKhamBenhCanLamSan" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2"   OnEditCommand="Edit"
											    OnPageIndexChanged="PageIndexStyleChanged" PageSize="50">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn Visible="False"><ItemTemplate>
														    <asp:LinkButton id="lbtnDel" CommandName="Delete" runat="server" CssClass="alink3">Hoàn tất</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="0%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
						<asp:Label ID="lblidkb" visible="false" text='<%#Eval("idkhambenh") %>' runat="server" ></asp:Label>							    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">CLS</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT"><ItemTemplate>
		<%=STT()%>
	
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="ngaythu" DataFormatString="{0:dd/MM HH:mm}" HeaderText="Ng&#224;y ĐK">
<HeaderStyle Width="7%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="18%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TenGioiTinh" HeaderText="Giới t&#237;nh"></asp:BoundColumn>
<asp:BoundColumn DataField="namsinh" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SoBHYT" HeaderText="Số BHYT">
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ChanDoanSoBo" HeaderText="Chẩn đo&#225;n sơ bộ">
<HeaderStyle Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="KhoaCD" HeaderText="Khoa kh&#225;m"></asp:BoundColumn>
<asp:BoundColumn DataField="BSCD" HeaderText="B&#225;c sĩ chỉ định"></asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader"></HeaderStyle>
</asp:datagrid>&nbsp;												
								    </TD>
							    </TR>
						    </TABLE>
					    </TD>
				    </TR>
				    <tr>
	                    <td style ="width: 100%;">
	                        <div id  = "infospace" runat = "server"></div>
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
<!--#include file ="footer.htm"-->
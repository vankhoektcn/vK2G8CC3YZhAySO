<%@ Page Language="C#" AutoEventWireup="true" CodeFile="listBNHenTraKQ.aspx.cs" Inherits="canlamsang_listBNHenTraKQ" %>
    
<!--#include file ="header.htm"-->
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<link type="text/css" rel="stylesheet" href="../epoch_styles.css" />
    <script type="text/javascript" src="../epoch_classes.js"></script>
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
                                <asp:label runat="server"  id="lblHeader"></asp:label>
                            </p>
				        </td>
			        </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="left" width="100%" style="height: 100px">
												    <TABLE style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
													   <tr>
					                                         <td  noWrap align="right" style="WIDTH: 200px; height: 24px;">
						   Chọn Phòng/Khoa: &nbsp;</td>
					    <td align="left" style="WIDTH: 84%; height: 24px;" colspan="3">
						    <asp:dropdownlist id="ddlPK" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlPK_SelectedIndexChanged1"></asp:dropdownlist>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Chọn Bác sĩ
                            &nbsp;&nbsp;
                        <asp:dropdownlist id="ddlBS"  runat="server" ></asp:dropdownlist>

                        </td>
                                                           
				                                        </tr>
													   
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 200px; height: 24px;">
															    <span class="ptext">Mã bệnh nhân:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 84%; height: 24px;" colspan="3">
															    <span class="ptext"><asp:TextBox ID="txtMaBenhNhan" Runat="server" Width="440px" tabIndex="1" ReadOnly="False"></asp:TextBox></span>
														    </TD>
													    </TR>
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 200px">
															    <span class="ptext">
                                                                    Tên bệnh nhân:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" width="430" height="4" style="WIDTH: 430px" colspan="3">
															    <span class="ptext"><asp:TextBox ID="txtTenBenhNhan" Runat="server" Width="440px" tabIndex="2"></asp:TextBox></span>
														    </TD>
													    </TR>
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 200px; height: 19px;">
															    <span class="ptext">
                                                                    Điện thoại:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 19px;" colspan="3">
															    <span class="ptext"><asp:TextBox ID="txtDienThoai" Runat="server" Width="440px" tabIndex="3"></asp:TextBox>
                                                                  </span>
                                                               </TD>
													    </TR>
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 200px; height: 24px;">
															    <span class="ptext">
                                                                    Địa chỉ:&nbsp;
															    </span>
														    </TD>
														    <TD vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 24px;" colspan="3">
															    <span class="ptext"><asp:TextBox ID="txtDiaChi" Runat="server" Width="440px" tabIndex="4"></asp:TextBox></span>															    
														    </TD>
													    </TR>
													    
													    <tr>
													    <td vAlign="top" noWrap align="right" style="WIDTH: 200px; height: 25px;">
													    Từ Ngày :
													    </td>
													    <td style="height: 25px">
													     <asp:textbox id="txtTuNgay" runat="server" tabindex="1" width="118px"></asp:textbox>
                                                                <input id="Button4" onclick="dp_cal1.toggle()" style="width: 25px" type="button"
                                                                    value="..." />&nbsp; 
                                                                    Đến Ngày :
                                                                      <asp:textbox id="txtDenNgay" runat="server" tabindex="1" width="118px"></asp:textbox>
                                                                <input id="Button1" onclick="dp_cal.toggle()" style="width: 25px" type="button"
                                                                    value="..." /> 
													    </td>
													    </tr>
													    <TR style="PADDING-TOP: 2px">
														    <TD vAlign="top" noWrap align="left" style="PADDING-LEFT: 100px; WIDTH: 200px; height: 19px;">
															    </TD>
														    <TD colspan="3" vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 19px; padding-left:100px"
															    nowrap><br><asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/images/tim.png" TabIndex="11" OnClick="ImageButton1_Click"></asp:ImageButton></TD>
													    </TR>
												    </TABLE>
                                                  </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
						    </TABLE>
						      <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" height="20"><asp:Label forecolor="red" ID="lblTotal" runat="server" ></asp:Label>
								    </TD>
							    </TR>
						    </TABLE>	
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" height="20"><span class="title">DANH SÁCH PHIẾU HẸN LẤY KQ CLS</span>
								    </TD>
							    </TR>
						    </TABLE>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
									    <asp:datagrid id="dgr" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
											    DataKeyField="IDPhieuHen" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand = "DelBenhNhan" OnEditCommand="Edit"
											    OnPageIndexChanged="PageIndexStyleChanged" PageSize="50" OnItemCommand="dgr_ItemCommand">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>

<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lnbtnStatus" Text='<%#Eval("TrangThai") %>' runat="server" Width="69px" CssClass="alink3" CommandName="Status" CommandArgument='<%# Eval("IDPhieuHen") %>'></asp:LinkButton> 
</ItemTemplate>
</asp:TemplateColumn>
<asp:ButtonColumn CommandName="in" ItemStyle-Width="8%" Text="In phiếu hẹn"></asp:ButtonColumn>
<asp:TemplateColumn HeaderText="STT"><ItemTemplate>
		<%=STT()%>
	
</ItemTemplate>
<HeaderStyle Wrap="False" Width="2%"></HeaderStyle>
</asp:TemplateColumn>



<asp:BoundColumn DataField="ngayhen" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ng&#224;y hẹn">
<HeaderStyle Wrap="False" Width="13%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbacsi" HeaderText="BS hẹn">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="18%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">
<HeaderStyle Wrap="False" Width="13%"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaysinh" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ng&#224;y sinh">
<HeaderStyle Width="12%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
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

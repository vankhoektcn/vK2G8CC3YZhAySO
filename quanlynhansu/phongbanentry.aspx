<%@ Page Language="C#" AutoEventWireup="true" CodeFile="phongbanentry.aspx.cs" Inherits="phongbanentry" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->
<script language = "javascript">
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
        <td width = "100%" align = "left" style="background-color:#FBF8F1; height: 19px;">
            <uc1:uscmenu ID="Uscmenu1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px; width: 100%;">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				    <td align="center" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                                    color: Red; font-weight: bold">
                                                    DANH SÁCH CÁC PHÒNG BAN
                                                </td>
				        
				    </tr>
				    <tr>
					    <td width="100%">
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
								    <td vAlign="top" align="center" width="100%">
									    <table cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <td align="left" width="100%" style="height: 100px">
												    <table style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
													    <tr>
														    <td vAlign="top" noWrap align="right">
															    <P class="ptext">Mã phòng khám :&nbsp;
															    </P>
														    </td>
														    <td vAlign="top" align="left" width="430" height="4" style="WIDTH: 430px" colspan="3">
															    <P class="ptext"><asp:TextBox ID="txtMaPhongKham" Runat="server" Width="440px" tabIndex="1" ReadOnly="False"></asp:TextBox></P>
														    </td>
													    </tr>
													    <tr>
														    <td vAlign="top" noWrap align="right" >
															    <P class="ptext">
                                                                    Tên phòng khám :&nbsp;
															    </P>
														    </td>
														    <td vAlign="top" align="left" width="430" height="4" style="WIDTH: 430px" colspan="3">
															    <P class="ptext"><asp:TextBox ID="txtTenPhongKham" Runat="server" Width="440px" tabIndex="2"></asp:TextBox></P>
														    </td>
													    </tr>
													    
													    <tr>
														    <td vAlign="top" noWrap align="right" style="HEIGHT: 67px">
															    <P class="ptext">
                                                                    Ghi chú :&nbsp;
															    </P>
														    </td>
														    <td vAlign="top" align="left" width="430" style="WIDTH: 430px; height: 67px;" colspan="3">
															    <P class="ptext"><asp:TextBox ID="txtGhiChu" Runat="server" Width="440px" tabIndex="4"></asp:TextBox></P>
															    <INPUT id="txtmaphieu" type="hidden" value='""' name="txtmaphieu" runat="server" style="WIDTH: 32px; HEIGHT: 22px"
																	    size="1">
														    </td>
													    </tr>
													    <TR style="PADDING-TOP: 2px">
														    <td vAlign="top" noWrap align="left" style="PADDING-LEFT: 100px; WIDTH: 30px; height: 19px;"></td>
														    <td colspan="3" vAlign="top" align="center" width="430" style="WIDTH: 430px; height: 19px;"
															    nowrap><asp:imagebutton id="btnAdd" onclick="btnAdd_Click" runat="server" imageurl="../images/nut_add.gif"
																    tabIndex="8"></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnEdit" onclick="btnEdit_Click" runat="server" imageurl="../images/sua.gif" tabIndex="9"></asp:imagebutton>&nbsp;
															    <asp:imagebutton id="btnCancel" onclick="btnCancel_Click" runat="server" imageurl="../images/cancel.gif"
																    tabIndex="10"></asp:imagebutton>&nbsp;
															    <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/tim.png" TabIndex="11" OnClick="ImageButton1_Click"></asp:ImageButton></td>
													    </tr>
												    </TABLE>
                                                  </td>
										    </tr>
									    </TABLE>
								    </td>
							    </tr>
						    </TABLE>
						    
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
							    <td align="left" style="width: 100%; background-color: #FBF8F1; height: 19px; background-image: url(../images/menu.jpg);
                                                                color: White; font-weight: bold">
                                                                DANH SÁCH PHÒNG BAN
                                                            </td>
								    <%--<td vAlign="top" align="left" width="100%" height="20"><P class="title">DANH SÁCH PHÒNG KHÁM BỆNH</P>
								    </td>--%>
							    </tr>
						    </TABLE>						   
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
								    <td vAlign="top" align="center" width="100%" colSpan="2" height="20">
									    <asp:datagrid id="dgr" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
											    DataKeyField="idphongban" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand = "DelPhongKham" OnEditCommand="Edit" AllowPaging="True"
											    OnPageIndexChanged="PageIndexStyleChanged" PageSize="30">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnDel" CommandName="Delete" runat="server" CssClass="alink3">Xóa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="4%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
														    <asp:LinkButton id="lbtnEdit" CommandName="Edit" runat="server" CssClass="alink3">Sửa</asp:LinkButton>
													    
</ItemTemplate>

<HeaderStyle Width="4%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="maphongban" HeaderText="M&#227; ph&#242;ng kh&#225;m" SortExpression="maphongkhambenh">
<ItemStyle Wrap="True"></ItemStyle>

<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenphongban" HeaderText="T&#234;n ph&#242;ng kh&#225;m">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Width="25%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ghichu" HeaderText="Ghi chú">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Width="25%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<%--<asp:BoundColumn DataField="loaiphong" HeaderText="Loại ph&#242;ng kh&#225;m" Visible="False">
<ItemStyle Wrap="False"></ItemStyle>

<HeaderStyle Width="20%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>--%>
<asp:BoundColumn DataField="idphongban" HeaderText="maphongban" Visible="False"></asp:BoundColumn>
</Columns>
</asp:datagrid>&nbsp;												
								    </td>
							    </tr>
						    </TABLE>
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
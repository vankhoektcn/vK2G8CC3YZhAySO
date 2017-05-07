<%@ Page Language="C#" AutoEventWireup="true" CodeFile="listPhieuCLS.aspx.cs" Inherits="canlamsang_listPhieuCLS" %>

<!--#include file ="header.htm"-->
<script language = "javascript" type="text/javascript">
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
	function showDetailDV(iddichvu)
	{
	alert(iddichvu);
	
	}
</script>
<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#D4D0C8; height: 10px;">
              <asp:placeholder ID="PlaceHolder1" runat="server"></asp:placeholder>
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td width="100%" valign="top" style="PADDING-LEFT:0px; PADDING-TOP:0px">
			    <table id="user" cellSpacing="1" cellPadding="1" width="100%" border="0" class = "khung">
				    <tr>
				        <td class="title" align = "center" style ="background-color: #4D67A2">
			                <span class="title" style ="color:#FFFFFF">DANH SÁCH BỆNH NHÂN ĐÃ ĐƯỢC CLS</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: 133px">
									    <TABLE cellSpacing="0" cellPadding="0" border="0" style="width: 97%; height: 40px">
										    
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="left" width="100%" style="height: 100px">
												    <TABLE style="HEIGHT: 17px; width: 1216px;" cellSpacing="0" cellPadding="0" border="0">
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 112px; height: 24px;">
															    <P class="ptext">Mã bệnh nhân:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 151px; height: 24px;" colspan="1">
															    <P class="ptext"><asp:TextBox ID="txtMaBenhNhan" Runat="server" Width="142px" tabIndex="1" ReadOnly="False"></asp:TextBox></P>
														    </TD>
														     <TD vAlign="top" noWrap align="left" style="WIDTH: 114px; height: 24px;">
															    <P class="ptext">
                                                                    Tên bệnh nhân:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left"  style=" WIDTH: 175px;height: 24px;">
															    <P class="ptext"><asp:TextBox ID="txtTenBenhNhan" Runat="server" Width="335px" tabIndex="2"></asp:TextBox></P>
														    </TD>
														      <TD vAlign="top" noWrap align="left" style=" WIDTH: 372px;">
															    <P class="ptext">
                                                                    &nbsp;Giới tính:&nbsp;&nbsp; &nbsp; &nbsp;
                                                                    <asp:dropdownlist id="ddlGioiTinh" runat="server" width="74px" TabIndex="5"><asp:ListItem Selected="True" Value="0">Nam</asp:ListItem>
<asp:ListItem Value="1">Nữ</asp:ListItem>
</asp:dropdownlist></P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 150px; height: 24px;">
															    <P class="ptext">
                                                                    &nbsp;&nbsp;</P>															    
														    </TD>
													    </TR>
													   
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 112px; height: 3px;">
															    <P class="ptext">
                                                                    Điện thoại:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 151px; height: 3px;" colspan="1">
															    <P class="ptext"><asp:TextBox ID="txtDienThoai" Runat="server" Width="141px" tabIndex="3"></asp:TextBox></P>
														    </TD>
														     <TD vAlign="top" noWrap align="left" style="WIDTH: 114px; height: 3px;">
															    <P class="ptext">
                                                                    Địa chỉ:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 175px; height: 3px;" >
															    <P class="ptext"><asp:TextBox ID="txtDiaChi" Runat="server" Width="334px" tabIndex="4"></asp:TextBox></P>															    
														    </TD>
                                                            <TD vAlign="top" align="left" >
															    <P class="ptext">
                                                                    Chọn Bác sĩ :
                                                                    <asp:dropdownlist id="ddlBS" runat="server"></asp:dropdownlist>
                                                                </P>															    
														    </TD>
														      <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >
															    <P class="ptext">
															   <asp:dropdownlist visible="false" id="ddlLoaiCLS" runat="server"><asp:ListItem Value="0">Bệnh nh&#226;n tự đến</asp:ListItem>
<asp:ListItem Value="1">BS chỉ định ở ngo&#224;i</asp:ListItem>
<asp:ListItem Value="2">Từ ph&#242;ng kh&#225;c chuyển sang</asp:ListItem>
</asp:dropdownlist>
														    
                                                                </P>															    
														    </TD>
														    
														    
													    </TR>
													  <tr>
													  <TD noWrap vAlign="top" align="right" style="WIDTH: 70px; height: 3px;" >
													Từ ngày :
                                                          </TD>
													  <TD vAlign="top" align="left" style="WIDTH: 151px; height: 3px;" colspan="1">
													   <asp:dropdownlist id="ddl_ngaybd" runat="server" height="24px" tabindex="1" width="47px"></asp:dropdownlist>/<asp:dropdownlist id="ddl_thangbd" runat="server" height="24px" tabindex="2" width="47px"><asp:ListItem>01</asp:ListItem>
                                                                                            <asp:ListItem>02</asp:ListItem>
                                                                                            <asp:ListItem>03</asp:ListItem>
                                                                                            <asp:ListItem>04</asp:ListItem>
                                                                                            <asp:ListItem>05</asp:ListItem>
                                                                                            <asp:ListItem>06</asp:ListItem>
                                                                                            <asp:ListItem>07</asp:ListItem>
                                                                                            <asp:ListItem>08</asp:ListItem>
                                                                                            <asp:ListItem>09</asp:ListItem>
                                                                                            <asp:ListItem>10</asp:ListItem>
                                                                                            <asp:ListItem>11</asp:ListItem>
                                                                                            <asp:ListItem>12</asp:ListItem>
                                                                                            </asp:dropdownlist> 
                                                    
													  </TD>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >
													  Đến ngày :</TD>
													   <TD vAlign="top" align="left" style="WIDTH: 250px; height: 3px;" >
													  <asp:dropdownlist id="ddl_ngaykt"
                                                        runat="server" height="24px" tabindex="1" width="47px"></asp:dropdownlist>/<asp:dropdownlist id="ddl_thangkt" runat="server" height="24px" tabindex="1" width="47px">
                                                                    <asp:ListItem>01</asp:ListItem>
                                                                    <asp:ListItem>02</asp:ListItem>
                                                                    <asp:ListItem>03</asp:ListItem>
                                                                    <asp:ListItem>04</asp:ListItem>
                                                                    <asp:ListItem>05</asp:ListItem>
                                                                    <asp:ListItem>06</asp:ListItem>
                                                                    <asp:ListItem>07</asp:ListItem>
                                                                    <asp:ListItem>08</asp:ListItem>
                                                                    <asp:ListItem>09</asp:ListItem>
                                                                    <asp:ListItem>10</asp:ListItem>
                                                                    <asp:ListItem>11</asp:ListItem>
                                                                    <asp:ListItem>12</asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                    &nbsp;
                                                          Năm :
                                                          &nbsp;
                                                          <asp:dropdownlist id="ddl_nam" runat="server"></asp:dropdownlist></TD>
													  <TD >
                                                          &nbsp;<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/tim.png" TabIndex="10" OnClick="ImageButton1_Click"></asp:ImageButton><asp:imagebutton id="btnCancel" tabIndex=11 onclick="btnCancel_Click" runat="server" imageurl="../images/MOI.gif"></asp:imagebutton></TD>
													<TD  align="left"  >	&nbsp;
                                                    </TD>    
													  </tr>
													   
													   
												    </TABLE>
                                                    &nbsp; </TD>
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
								    <TD vAlign="top" align="left" width="100%" height="20"><P class="title">DANH SÁCH BỆNH NHÂN</P>
								    </TD>
							    </TR>
						    </TABLE>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" style="height: 19px">
								   
									    <asp:datagrid id="dgr" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="false"
											    DataKeyField="iddieutri" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand = "DelBenhNhan" OnEditCommand = "Edit" 
											    OnPageIndexChanged="PageIndexStyleChanged" OnItemCommand="dgr_ItemCommand" AllowPaging="False">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" runat="server" CssClass="alink3"  >Xoá</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="2%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:Label id="lbnIdKB" Visible="false" runat="server" Text='<%#Eval("idkb") %>'></asp:Label> 
<asp:Label id="lbnIdBN" Visible="false" runat="server" Text='<%#Eval("idbenhnhan") %>'></asp:Label> 
<asp:Label id="lbnIdKBCLS" Visible="false" runat="server" Text='<%#Eval("idkbcls") %>'></asp:Label> 

<asp:LinkButton id="lbtnEdit" runat="server" CssClass="alink3" CommandName="Edit">Sửa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="2%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT"><ItemTemplate>
		<%=STT()%>
	
</ItemTemplate>

<HeaderStyle Width="2%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="ngaykham" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ng&#224;y CLS">
<HeaderStyle Width="12%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mp" HeaderText="Mã phiếu">
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>


<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="14%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">
<HeaderStyle HorizontalAlign="Center" Wrap="False" Width="10%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="gioitinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaysinh" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>

</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader"></HeaderStyle>
</asp:datagrid>&nbsp;	

<!--
  <asp:datagrid id="dgrBSCD" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="false"
											    DataKeyField="idbenhnhan" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand = "DelBenhNhan" OnEditCommand = "Edit" AllowPaging="True"
											    OnPageIndexChanged="PageIndexStyleChanged" OnItemCommand="dgr_ItemCommand">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>


<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" runat="server" CssClass="alink3" onclientclick="return confirm('Bạn có muốn xóa bệnh nhân này?');" CommandName="Delete">Xoá</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="2%" Wrap="False" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn ><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" CssClass="alink3" CommandName="Edit">Sửa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="2%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT">
	<ItemTemplate>
		<%=STT()%>
	</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<ItemStyle Wrap="True"></ItemStyle>

<HeaderStyle Width="9%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<ItemStyle Wrap="False" HorizontalAlign="center"></ItemStyle>

<HeaderStyle Width="14%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<ItemStyle Wrap="false" HorizontalAlign="center"></ItemStyle>

<HeaderStyle Width="20%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">

<HeaderStyle Width="13%" Wrap="False" HorizontalAlign="center"></HeaderStyle>
</asp:BoundColumn>
 
<asp:BoundColumn DataField="gioitinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="namsinh" HeaderText="Năm sinh">
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Ngaythu" HeaderText="Ngày Thu">
<HeaderStyle Width="12%"></HeaderStyle>
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>

<asp:BoundColumn DataField="tendichvu" HeaderText="Tên Dịch vụ">
<HeaderStyle Width="10%"></HeaderStyle>
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>

<asp:BoundColumn DataField="tenBSChiDinh" HeaderText="Tên BS chỉ định">
<HeaderStyle Width="10%"></HeaderStyle>
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>

<asp:ButtonColumn CommandName="Select" Text="Xem chi tiết"></asp:ButtonColumn>


</Columns>

</asp:datagrid>


  <asp:datagrid id="dgrKB" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="false"
											    DataKeyField="idbenhnhan" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand = "DelBenhNhan" OnEditCommand = "Edit" AllowPaging="True"
											    OnPageIndexChanged="PageIndexStyleChanged" OnItemCommand="dgr_ItemCommand">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>


<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" runat="server" CssClass="alink3" onclientclick="return confirm('Bạn có muốn xóa bệnh nhân này?');" CommandName="Delete">Xoá</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="2%" Wrap="False" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn ><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" CssClass="alink3" CommandName="Edit">Sửa</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="2%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT">
	<ItemTemplate>
		<%=STT()%>
	</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<ItemStyle Wrap="True"></ItemStyle>

<HeaderStyle Width="9%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<ItemStyle Wrap="False" HorizontalAlign="center"></ItemStyle>

<HeaderStyle Width="14%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<ItemStyle Wrap="false" HorizontalAlign="center"></ItemStyle>

<HeaderStyle Width="20%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">

<HeaderStyle Width="13%" Wrap="False" HorizontalAlign="center"></HeaderStyle>
</asp:BoundColumn>
 
<asp:BoundColumn DataField="gioitinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="namsinh" HeaderText="Năm sinh">
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaythu"  HeaderText="Ngày Tiếp Nhận">
<HeaderStyle Width="12%"></HeaderStyle>
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>

<asp:BoundColumn DataField="tendichvu" HeaderText="Tên Dịch vụ">
<HeaderStyle Width="10%"></HeaderStyle>
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbacsi" HeaderText="Bác sĩ chỉ định">
<HeaderStyle Width="10%"></HeaderStyle>
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>
<asp:ButtonColumn CommandName="Select" Text="Xem chi tiết"></asp:ButtonColumn>

</Columns>

</asp:datagrid>		
-->									
								    </TD>
							    </TR>
						    </TABLE>
					    </TD>
				    </TR>
			    </table>
		    </td>
	    </tr>				
    </table>
    </td>
   </tr>
  </table>  
 </form>
<!--#include file ="footer.htm"-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="benhnhanDaKhamCLS.aspx.cs" Inherits="nhanbenh_benhnhanDaKhamCLS" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<link rel="stylesheet" type="text/css" href="js/epoch_styles.css" />



<!--#include file ="header.htm"-->
    <script type="text/javascript" src="js/epoch_classes.js"></script>
<script type="text/javascript">
	     var dp_cal;      
       window.onload = function () {
	            dp_cal  = new Epoch('epoch_popup','popup',document.getElementById('txtNgayBD'));
	            dp_cal1  = new Epoch('epoch_popup','popup',document.getElementById('txtNgayKT'));

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
	function showDetailDV(iddichvu)
	{
	alert(iddichvu);
	
	}
</script>

<form id="Form1" method="post" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="background-color:#FBF8F1; height: 19px;">
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
			                <span class="title" style ="color:#FFFFFF">DANH SÁCH BỆNH NHÂN ĐÃ LÀM CLS</span></td>
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
														    <TD vAlign="top" align="left" style="WIDTH: 201px; height: 24px;" colspan="1">
															    <P class="ptext"><asp:TextBox ID="txtMaBenhNhan" Runat="server" Width="142px" tabIndex="1" ReadOnly="False"></asp:TextBox></P>
														    </TD>
														     <TD vAlign="top" noWrap align="left" style="WIDTH: 114px; height: 24px;">
															    <P class="ptext">
                                                                    Tên bệnh nhân:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left"  style=" WIDTH: 258px;height: 24px;">
															    <P class="ptext"><asp:TextBox ID="txtTenBenhNhan" Runat="server" Width="258px" tabIndex="2"></asp:TextBox></P>
														    </TD>
														      <TD vAlign="top" noWrap align="left" style="width: 192px" >
														       <P class="ptext">
														      &nbsp;Mã CLS:&nbsp;
														      <asp:textbox runat="server" id="txtMaCLS" width="119px"></asp:textbox>
                                                              </P>	
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 150px; height: 24px;">
															    	 <P class="ptext">
                                                                    Giới tính:&nbsp;
                                                                    <asp:dropdownlist id="ddlGioiTinh" runat="server" width="74px" TabIndex="5">
                                                                    <asp:ListItem Value="2" Selected="True">- Tất Cả -</asp:ListItem>
                                                                    <asp:ListItem  Value="0">Nam</asp:ListItem>
                                                                    <asp:ListItem Value="1">Nữ</asp:ListItem>
                                                                </asp:dropdownlist></P>													    
														    </TD>
													    </TR>
													   
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 112px; height: 3px;">
															    <P class="ptext">
                                                                    Điện thoại:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 201px; height: 3px;" colspan="1">
															    <P class="ptext"><asp:TextBox ID="txtDienThoai" Runat="server" Width="141px" tabIndex="3"></asp:TextBox></P>
														    </TD>
														     <TD vAlign="top" noWrap align="left" style="WIDTH: 114px; height: 3px;">
															    <P class="ptext">
                                                                    Địa chỉ:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 258px; height: 3px;" >
															    <P class="ptext"><asp:TextBox ID="txtDiaChi" Runat="server" Width="259px" tabIndex="4"></asp:TextBox></P>															    
														    </TD>
                                                            <TD vAlign="top" align="left" style="WIDTH: 192px; height: 3px;" >
															    <P class="ptext">
															   <asp:dropdownlist visible="false" id="ddlLoaiCLS" runat="server"><asp:ListItem Value="0">Bệnh nh&#226;n tự đến</asp:ListItem>
<asp:ListItem Value="1">BS chỉ định ở ngo&#224;i</asp:ListItem>
<asp:ListItem Value="2">Từ ph&#242;ng kh&#225;c chuyển sang</asp:ListItem>
</asp:dropdownlist></P>															    
														    </TD>
														      <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >
															    <P class="ptext">
                                                                    &nbsp;</P>															    
														    </TD>
														    
														    
													    </TR>
													  <tr>
													  <TD noWrap vAlign="top" align="right" style="WIDTH: 112px; height: 25px;" >
													Từ ngày :
                                                          </TD>
                                                          
													  <TD style="width: 201px; height: 25px;" >
													  
                                                    <asp:TextBox ID="txtNgayBD" Runat="server" Width="118px" tabIndex="1" ReadOnly="False" onblur = "TestDatePhieu(this)"></asp:TextBox><input id="Button1" type="button" value="..." style="width: 24px" onclick="dp_cal.toggle()" /> 
													  </TD>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: 25px;" >
													  Đến ngày :</TD>
													   <TD style="width: 258px; height: 25px;" >
													   <asp:TextBox ID="txtNgayKT" Runat="server" Width="118px" tabIndex="2" onblur = "TestDatePhieu(this)"></asp:TextBox>&nbsp;<input id="Button2" type="button" value="..." style="width: 24px" onclick="dp_cal1.toggle()"/>&nbsp;
                                                       </TD>
													  <td style="width: 192px; height: 25px;">
                                                          &nbsp;</td>
                                                          <tr>
                                                              <td align="right" nowrap="nowrap" style="width: 112px; height: 19px" valign="top">
                                                                  Phòng khám BV:</td>
                                                              <td style="width: 201px; height: 19px">
                                                                  <asp:dropdownlist id="ddlPKBV" runat="server" visible="true" width="179px"></asp:dropdownlist>
                                                              </td>
                                                              <td align="left" style="width: 100px; height: 19px" valign="top">
													        Khoa :</td>
                                                              <td style="height: 19px" colspan="2">
                                                                  <asp:dropdownlist id="ddlKhoa" width="146px" runat="server"></asp:dropdownlist>
                                                                 <%-- &nbsp; &nbsp; &nbsp;Bác sĩ :--%>
                                                                  <asp:dropdownlist id="ddlBacSi" runat="server" visible="false" width="220px"></asp:dropdownlist></td>
                                                          </tr>
													    <tr>
													  <TD  colspan="6">
                                                          &nbsp;<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/tim.png" TabIndex="10" OnClick="ImageButton1_Click"></asp:ImageButton>
                                                          <asp:imagebutton id="btnCancel" tabIndex=11 onclick="btnCancel_Click" runat="server" imageurl="../images/MOI.gif"></asp:imagebutton>
                                                          </asp:ImageButton><asp:imagebutton id="btnInChiDinh" tabIndex=12 runat="server" imageurl="../images/IN.gif"></asp:ImageButton>
                                                          </TD>
													<TD  align="center"  >	&nbsp;
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
								    <TD vAlign="top" align="left" width="100%" style="height: 20px"><asp:Label forecolor="red" ID="lblTotal" runat="server" ></asp:Label>
								    </TD>
							    </TR>
						    </TABLE>	
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" style="height: 20px"><P class="title">DANH SÁCH BỆNH NHÂN</P>
								    </TD>
							    </TR>
						    </TABLE>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" style="height: 19px">
                                        <asp:scriptmanager runat="server"></asp:scriptmanager>
                                        <asp:updatepanel runat="server"><ContentTemplate>
									    <asp:datagrid id="dgr" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="false"
											    DataKeyField="idbenhnhan" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand = "DelBenhNhan" OnEditCommand = "Edit" 
											    OnPageIndexChanged="PageIndexStyleChanged" OnItemCommand="dgr_ItemCommand" AllowPaging="False">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>

<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" CssClass="alink3" CommandName="Edit" CommandArgument='<%# Eval("iddieutricanlamsan") %>'>Chi tiết</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="4%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT"><ItemTemplate>
		<%=STT()%>
	
</ItemTemplate>

<HeaderStyle Width="2%"></HeaderStyle>
</asp:TemplateColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="9%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="madangkycls" HeaderText="Mã CLS">
<HeaderStyle Wrap="true" Width="8%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="13%"></HeaderStyle>

<ItemStyle HorizontalAlign="left" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">
<HeaderStyle HorizontalAlign="left" Wrap="False" Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="gioitinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaysinh" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaykham" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ng&#224;y CLS">
<HeaderStyle Width="9%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dichvukham" HeaderText="T&#234;n Dịch vụ">
<HeaderStyle Width="8%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbscls" HeaderText="T&#234;n B&#225;c sĩ CLS">
<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>

<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnDel" runat="server" CssClass="alink3" CommandName="Del"  >Xoá</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Wrap="False" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="2%"></HeaderStyle>
</asp:TemplateColumn>

</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader"></HeaderStyle>
</asp:datagrid>&nbsp;	
<asp:hiddenfield runat="server" id="name1"></asp:hiddenfield>
      <asp:hiddenfield runat="server" id="name2"></asp:hiddenfield>
      <asp:hiddenfield runat="server" id="name3"></asp:hiddenfield>
      <asp:hiddenfield runat="server" id="name4"></asp:hiddenfield>
</ContentTemplate></asp:updatepanel>

 <%-- <asp:datagrid id="dgrBSCD" tabIndex="12" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="false"
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

</asp:datagrid>		--%>
							
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
  <div style="display:none;position:fixed;top:35%;left:35%;background-color:White;z-index:1000;padding:10px 10px 10px 10px;border:10px solid #4D67A2" id="divlydo" runat="server">
       <asp:updatepanel runat="server"><ContentTemplate>
      <table>
          <tr>
              <td>
                 Người dùng 
              </td>
              <td>
                  <asp:textbox runat="server" id="nguoidung" enabled="false"></asp:textbox>
              </td>
          </tr>
          <tr>
              <td>
                 Ngày thực hiên 
              </td>
              <td>
              <asp:textbox runat="server" id="ngaythang" enabled="false"></asp:textbox>
              </td>
          </tr>
          <tr>
              <td>
                  Kiểu thao tác
              </td>
              <td>
              <asp:textbox runat="server" id="kieutt" enabled="false"></asp:textbox>
              </td>
          </tr>
          <tr>
              <td>
                  Lý do
              </td>
              <td>
              <asp:textbox runat="server" id="lydo"></asp:textbox>
              </td>
          </tr>
      </table>
      </ContentTemplate></asp:updatepanel>
      <input id="Button3" type="button" value="Huỷ" onclick="javascript:divlydo.style.display = 'none';"/>
      <asp:button runat="server" text="Lưu" id="btlydo" OnClick="btlydo_Click"/>
  </div>  
 </form>
<!--#include file ="footer.htm"-->

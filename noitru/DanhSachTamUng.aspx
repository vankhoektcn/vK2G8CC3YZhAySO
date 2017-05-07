<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachTamUng.aspx.cs" Inherits="CapCuu_DanhSachTamUng" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!--#include file ="header.htm"-->
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
	function MoTrangMoi(Link)
	{
	    window.open(Link,'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');
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
			                <span class="title" style ="color:#FFFFFF">DANH SÁCH BỆNH NHÂN TẠM ỨNG</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: auto">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
										   
				
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="center" width="100%" style="height: 100px">
												    <TABLE style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
												    <tr>
												        <td valign="top" nowrap align="right" style="WIDTH: 112px; height: 23px;">
												            <p class="ptext">Chọn khoa:</p>
												        </td>
												        <td valign="top" align="left" style="WIDTH: 161px; height: 23px;" colspan="1">
												            <p class="ptext"><asp:dropdownlist autopostback="false" id="ddlKhoa" runat="server" width="150px" OnSelectedIndexChanged="ddlKhoa_SelectedIndexChanged"></asp:dropdownlist></p>
												        </td>
												        <td valign="top" align="left" style="WIDTH: 161px; height: 23px;" colspan="1">
												            <p class="ptext"><%--Nội dung khám:--%></p>
												        </td>
												         <td valign="top" align="left" style="WIDTH: 480px; height: 23px;" colspan="3">
												            <p class="ptext"><asp:dropdownlist autopostback="true" id="ddlNoidung" visible="false" runat="server" width="191px" OnSelectedIndexChanged="ddlNoidung_SelectedIndexChanged"></asp:dropdownlist>
                                                                <%--&nbsp;Phòng khám:&nbsp;--%>
                                                                <asp:dropdownlist id="ddlPhong" autopostback="true" runat="server" visible="false" width="189px"></asp:dropdownlist></p>
												            
												        </td>
												        <%--<td valign="top" align="left" style="WIDTH: 161px; height: 24px;" colspan="1">
												            <p class="ptext">Phòng khám:</p>
												        </td>
												         <td valign="top" align="left" style="WIDTH: 161px; height: 24px;" colspan="1">
												            <p><asp:dropdownlist id="ddlPhong" autopostback="true" runat="server" width="200px"></asp:dropdownlist></p>
												        </td>--%>
												    </tr>
													    <TR>
													 
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 112px; height: 24px;">
															    <P class="ptext">Mã bệnh nhân:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 161px; height: 24px;" colspan="1">
															    <P class="ptext"><asp:TextBox ID="txtMaBenhNhan" Runat="server" Width="142px" tabIndex="1" ReadOnly="False"></asp:TextBox></P>
														    </TD>
														     <TD vAlign="top" noWrap align="left" style="WIDTH: 114px; height: 24px;">
															    <P class="ptext">
                                                                    Tên bệnh nhân:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left"  style=" WIDTH: 350px;height: 24px;">
															    <P class="ptext"><asp:TextBox ID="txtTenBenhNhan" Runat="server" Width="335px" tabIndex="2"></asp:TextBox></P>
														    </TD>
														      <TD vAlign="top" noWrap align="left" >
															    <P class="ptext">
                                                                    &nbsp;Giới tính:&nbsp;
                                                                    <asp:dropdownlist id="ddlGioiTinh" runat="server" width="74px" TabIndex="3"><asp:ListItem Selected="True" Value="-1">---</asp:ListItem>
<asp:ListItem Value="0">Nam</asp:ListItem>
<asp:ListItem Value="1">Nữ</asp:ListItem>
</asp:dropdownlist></P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 150px; height: 24px;">
															    <P class="ptext">
                                                                    &nbsp;</P>															    
														    </TD>
													    </TR>
													   
													    <TR>
														    <TD vAlign="top" noWrap align="right" style="WIDTH: 112px; height: 3px;">
															    <P class="ptext">
                                                                    Điện thoại:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 161px; height: 3px;" colspan="1">
															    <P class="ptext"><asp:TextBox ID="txtDienThoai" Runat="server" Width="141px" tabIndex="4"></asp:TextBox></P>
														    </TD>
														     <TD vAlign="top" noWrap align="left" style="WIDTH: 114px; height: 3px;">
															    <P class="ptext">
                                                                    Địa chỉ:&nbsp;
															    </P>
														    </TD>
														    <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >
															    <P class="ptext"><asp:TextBox ID="txtDiaChi" Runat="server" Width="334px" tabIndex="5"></asp:TextBox></P>															    
														    </TD>
														    
														    
														    
													    </TR>
													  <tr>
													  <TD noWrap vAlign="top" align="right" style="WIDTH: 70px; height: 3px;" >
													Từ ngày :
                                                          </TD>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" colspan="1">
													   <asp:textbox id="txtTuNgay" runat="server"
                                                              tabindex="6" width="80px" ></asp:textbox>
													  </TD>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >
													  Đến ngày :</TD>
													  <td vAlign="top" align="left" style="WIDTH: 250px; height: 3px;" >
													  <asp:textbox id="txtDenNgay" runat="server" 
                                                              tabindex="7" width="80px"></asp:textbox>
                                                      &nbsp; <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/tim.png" TabIndex="8" OnClick="ImageButton1_Click"></asp:ImageButton>
                                                          <asp:imagebutton id="btnCancel" tabIndex="9" onclick="btnCancel_Click" runat="server" imageurl="../images/MOI.gif"></asp:imagebutton>
                                                       </td>								  
													  <TD >
                                                      </TD>
													<TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >	&nbsp;</TD>    
													  </tr>
													   
													   
												    </TABLE>
                                                   </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
						    </TABLE>
						     <%--<TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" height="20"><asp:Label forecolor="red" ID="lblTotal" runat="server" ></asp:Label>
								    </TD>
							    </TR>
						    </TABLE>	
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" height="20"><P class="title">DANH SÁCH BỆNH NHÂN TẠM ỨNG</P>
								    </TD>
							    </TR>
						    </TABLE>	--%>					   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
                                        <asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
                                         <asp:updatepanel runat="server" id="script2"><ContentTemplate>
									    <asp:datagrid id="dgr" tabIndex="10" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="false"
											    DataKeyField="idbenhnhan" BorderWidth="1px" BorderColor="Silver" OnItemDataBound="dgr_ItemDataBound" CellPadding="2" OnDeleteCommand = "DelBenhNhan" OnEditCommand = "Edit" AllowPaging="True" PageSize="20"
											    OnPageIndexChanged="PageIndexStyleChanged">
<PagerStyle Mode="NumericPages" ForeColor="DarkBlue" Font-Size="Small" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle CssClass="dgrHeader" HorizontalAlign="Center"></HeaderStyle>
<Columns>
<asp:TemplateColumn ><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" CssClass="alink3"  width="40px" CommandName="Edit">Chi tiết</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT">
	<ItemTemplate>
		<%=STT()%>
	</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<ItemStyle Wrap="True"  HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="12%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="20%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<ItemStyle Wrap="false" HorizontalAlign="center"></ItemStyle>

<HeaderStyle Width="30%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>


 
<asp:BoundColumn DataField="Sex" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaysinh" HeaderText="Năm sinh">
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaykham" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ngày Khám">
<HeaderStyle Width="12%"></HeaderStyle>
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>
<asp:BoundColumn DataField="tenphongkham" HeaderText="Phòng điều trị">
<HeaderStyle Width="13%" Wrap="False" HorizontalAlign="center"></HeaderStyle>
</asp:BoundColumn>
<%--<asp:BoundColumn DataField="tenbacsi" HeaderText="Tên Bác sĩ">
<HeaderStyle Width="9%"></HeaderStyle>
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>
<asp:BoundColumn DataField="tendichvu" HeaderText="Tên Dịch vụ">
<HeaderStyle Width="10%"></HeaderStyle>
<ItemStyle HorizontalAlign="center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
    
</asp:BoundColumn>
--%>
</Columns>

</asp:datagrid>&nbsp;	
<asp:hiddenfield runat="server" id="name1"></asp:hiddenfield>
      <asp:hiddenfield runat="server" id="name2"></asp:hiddenfield>
      <asp:hiddenfield runat="server" id="name3"></asp:hiddenfield>
      <asp:hiddenfield runat="server" id="name4"></asp:hiddenfield>
</ContentTemplate></asp:updatepanel>											
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
       <asp:updatepanel runat="server" id="updatepanel1"><ContentTemplate>
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
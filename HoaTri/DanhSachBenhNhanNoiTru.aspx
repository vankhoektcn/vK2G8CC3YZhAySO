<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachBenhNhanNoiTru.aspx.cs" Inherits="CapCuu_DanhSachBenhNhanNoiTru" %>

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
			                <span class="title" style ="color:#FFFFFF">DANH SÁCH BỆNH NHÂN NỘI TRÚ</span></td>
				    </tr>
				    <TR>
					    <TD width="100%">
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="center" width="100%" style="height: 133px">
									    <TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
										   
				
										    <TR style="PADDING-BOTTOM: 5px; PADDING-TOP: 10px">
											    <TD align="center" width="100%" style="height: 100px">
												    <TABLE style="HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="100%" border="0">
												    <tr>
												        <td valign="top" nowrap align="right" style="WIDTH: 112px; height: 23px;">
												            <p class="ptext">Chọn khoa:</p>
												        </td>
												        <td valign="top" align="left" style="WIDTH: 161px; height: 23px;" colspan="1">
												            <p class="ptext"><asp:dropdownlist autopostback="true" id="ddlKhoa" runat="server" width="150px" OnSelectedIndexChanged="ddlKhoa_SelectedIndexChanged"></asp:dropdownlist></p>
												        </td>
												        <td valign="top" align="left" style="WIDTH: 161px; height: 23px;" colspan="1">
												            <p class="ptext">Nội dung khám:</p>
												        </td>
												         <td valign="top" align="left" style="WIDTH: 480px; height: 23px;" colspan="3">
												            <p class="ptext"><asp:dropdownlist autopostback="true" id="ddlNoidung" runat="server" width="191px" OnSelectedIndexChanged="ddlNoidung_SelectedIndexChanged"></asp:dropdownlist>
                                                                &nbsp;Phòng khám:&nbsp;
                                                                <asp:dropdownlist id="ddlPhong"  runat="server" width="189px"></asp:dropdownlist></p>
												            
												        </td>
												       
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
													<%--Từ ngày :--%>
                                                          </TD>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" colspan="1">
													   <asp:textbox id="txtTuNgay" runat="server" visible="false"
                                                              tabindex="6" width="105px" ></asp:textbox>
													  </TD>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >
													 <%-- Đến ngày :--%></TD>
													  <td vAlign="top" align="left" style="WIDTH: 250px; height: 3px;" >
													  <asp:textbox id="txtDenNgay" runat="server" visible="false"
                                                              tabindex="7" width="104px"></asp:textbox>
                                                              </td>								  
													  <TD >
                                                          &nbsp;&nbsp;
                                                      </TD>
													<TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >	&nbsp;</TD>    
													  </tr>
													   
													   
												    </TABLE>
                                                    &nbsp; <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/tim.png" TabIndex="8" OnClick="ImageButton1_Click"></asp:ImageButton>
                                                          <asp:imagebutton id="btnCancel" tabIndex="9" onclick="btnCancel_Click" runat="server" imageurl="../images/MOI.gif"></asp:imagebutton></TD>
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
								    <TD vAlign="top" align="left" width="100%" height="20"><P class="title">Danh sách Bệnh Nhân nội trú</P>
								    </TD>
							    </TR>
						    </TABLE>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR style="width:100%">
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
                                        <asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
                                         <asp:updatepanel runat="server" id="script2"><ContentTemplate>
<asp:datagrid id="dgr" tabIndex=10 runat="server" Width="100%" OnPageIndexChanged="PageIndexStyleChanged" AllowPaging="False" OnEditCommand="Edit" OnDeleteCommand="DelBenhNhan" CellPadding="2" OnItemDataBound="dgr_ItemDataBound" BorderColor="Silver" BorderWidth="1px" DataKeyField="idkhambenh" AutoGenerateColumns="false" AllowSorting="True">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" __designer:wfdid="w6" CommandName="Edit" CommandArgument='<%# Eval("idbenhnhan") %>' width="40px" CssClass="alink3">Chi tiết</asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="7%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="STT"><ItemTemplate>
		<%=STT()%>	
</ItemTemplate>
</asp:TemplateColumn>
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
<HeaderStyle HorizontalAlign="Center" Wrap="False" Width="13%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="gioitinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="namsinh" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaykham" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ng&#224;y Kh&#225;m">
<HeaderStyle Width="12%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbacsi" HeaderText="T&#234;n B&#225;c sĩ">
<HeaderStyle Width="9%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenphongnoitru" HeaderText="Phòng khám">
<HeaderStyle Width="20%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader"></HeaderStyle>
</asp:datagrid>&nbsp; <asp:hiddenfield id="name1" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name2" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name3" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name4" runat="server"></asp:hiddenfield> 
</ContentTemplate>
</asp:updatepanel>											
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
  <%--<div style="display:none;position:fixed;top:35%;left:35%;background-color:White;z-index:1000;padding:10px 10px 10px 10px;border:10px solid #4D67A2" id="divlydo" runat="server">
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
  </div>  --%>
 </form>
<!--#include file ="footer.htm"-->
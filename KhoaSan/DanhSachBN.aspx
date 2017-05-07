<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachBN.aspx.cs" Inherits="DanhSachBN" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!--#include file ="header.htm"-->
<style type="text/css">
		.black_overlay{
			display: none;
			position: absolute;
			top: 0%;
			left: 0%;
			width: 100%;
			height: 100%;
			background: url('../images/trongsuot.png');
			z-index:1001;
			-moz-opacity: 0.8;
			opacity:.80;
			filter: alpha;
		}
		.white_content {
			display: none;
			position:fixed;
			top: 25%;
			left: 25%;
			width: 20%;
			height: 15%;
			padding: 8px;
			border: 8px solid silver;
			background-color: white;
			z-index:1002;
			overflow: auto;
		}
		input[type="button"],input[type="submit"]{border:2px solid #cfcfcf;height:25px;background-color:#648ccc;color:white;font-weight:bold;}
        input[type="button"],input[type="submit"]:focus{border:1px solid #000;}
        input[type="button"],input[type="submit"]:hover{padding:1px 1px 1px 1px;background-color:#1d4b74;margin-bottom:-1px;cursor:pointer;}
	</style>
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
    function loadPopupTTBN1()
	{
            
            document.getElementById('light1').style.display='block';
	}
	 function Close()
	{
            
            document.getElementById('light1').style.display='none';
            document.getElementById('divlydo').style.display='block';
	}//CloseChild
	 function CloseChild()
	{
            document.getElementById('divlydo').style.display='none';
	}
	 function CloseThuoc()
	{
            document.getElementById('divToaThuoc').style.display='none';
            document.getElementById('divlydo').style.display='block';
	}//divToaThuoc
	
	function OpenLinkKhamBenhCapCuu(dkmenu,idkhambenh)
	{
            window.open("../CapCuu/KhamTiepNhanCapCuu.aspx?dkmenu=Khong#idkhoachinh=" + idkhambenh + "");
            document.getElementById('divlydo').style.display='block';
	}
	function OpenLinkKhamBenhKhoaSan(dkmenu,idkhambenh)
	{
            window.open("../KhoaSan/KhamTiepNhanKhoaSan.aspx?dkmenu=Khong#idkhoachinh=" + idkhambenh + "");
            document.getElementById('divlydo').style.display='block';
	}
	function OpenLinkChiDinh(link)
	{
            window.open(link);
            document.getElementById('divlydo').style.display='block';
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
			                <span class="title" style ="color:#FFFFFF">KIỂM TRA VIỆN PHÍ - CHỈ ĐỊNH XUẤT KHOA</span></td>
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
												    <tr id="trKhoa" runat="server">
												        <td valign="top" nowrap align="right" style="WIDTH: 112px; height: 23px;">
												            <p class="ptext" id="spChonKhoa" runat="server">Chọn khoa:</p>
												        </td>
												        <td valign="top" align="left" style="WIDTH: 161px; height: 23px;" colspan="1">
												            <p class="ptext"><asp:dropdownlist autopostback="true" id="ddlKhoa" runat="server" width="150px" OnSelectedIndexChanged="ddlKhoa_SelectedIndexChanged"></asp:dropdownlist></p>
												        </td>
												        <td valign="top" align="left" style="WIDTH: 161px; height: 23px;" colspan="1">
												            <%--<p class="ptext">Nội dung khám:</p>--%>
												        </td>
												         <td valign="top" align="left" style="WIDTH: 480px; height: 23px;" colspan="3">
												            <p class="ptext"><asp:dropdownlist autopostback="true" id="ddlNoidung" visible="false" runat="server" width="191px" OnSelectedIndexChanged="ddlNoidung_SelectedIndexChanged"></asp:dropdownlist>
                                                                <%--&nbsp;Phòng khám:&nbsp;--%>
                                                                <asp:dropdownlist id="ddlPhong" visible="false" runat="server" width="189px"></asp:dropdownlist></p>
												            
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
														    <td align="left">
														    <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../images/tim.png" TabIndex="8" OnClick="ImageButton1_Click"></asp:ImageButton>
                                                          <asp:imagebutton id="btnCancel" tabIndex="9" onclick="btnCancel_Click" runat="server" imageurl="../images/MOI.gif"></asp:imagebutton>
														    </td>
														    
														    
													    </TR>
													  <%--<tr>
													  <td   align="right"  >
													<P class="ptext">
                                                                    Từ ngày :&nbsp;
															    </P>
                                                          </td>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" colspan="1">
													   <asp:textbox id="txtTuNgay"  visible="true" runat="server"
                                                              tabindex="6" width="105px" ></asp:textbox>
													  </TD>
													  <TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >
													  <P class="ptext">
                                                                    Đến ngày:&nbsp;
															    </P></TD>
													  <td vAlign="top" align="left" style="WIDTH: 250px; height: 3px;" >
													  <asp:textbox id="txtDenNgay" visible="true" runat="server" 
                                                              tabindex="7" width="104px"></asp:textbox>
                                                              </td>								  
													  <TD >
                                                          &nbsp;&nbsp;
                                                      </TD>
													<TD vAlign="top" align="left" style="WIDTH: 100px; height: 3px;" >	&nbsp;</TD>    
													  </tr>--%>
													   
													   
												    </TABLE>
                                                    </TD>
										    </TR>
									    </TABLE>
								    </TD>
							    </TR>
						    </TABLE>
						   <%--  <TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" height="20"><asp:Label forecolor="red" ID="lblTotal" runat="server" ></asp:Label>
								    </TD>
							    </TR>
						    </TABLE>	--%>
						    <%--<TABLE cellPadding="0" width="100%" border="0">
							    <TR>
								    <TD vAlign="top" align="left" width="100%" height="20"><P class="title">Danh sách Bệnh Nhân</P>
								    </TD>
							    </TR>
						    </TABLE>--%>						   
						    <TABLE cellPadding="0" width="100%" border="0">
							    <TR style="width:100%">
								    <TD vAlign="top" align="center" width="100%" colSpan="2" height="20">
                                        <asp:scriptmanager runat="server" id="script1"></asp:scriptmanager>
                                         <asp:updatepanel runat="server" id="script2"><ContentTemplate>
<asp:datagrid id="dgr" tabIndex=10 runat="server" Width="100%" OnPageIndexChanged="PageIndexStyleChanged" AllowPaging="True" onitemcommand="dgr_ItemCommand" OnDeleteCommand="DelBenhNhan" CellPadding="2" OnItemDataBound="dgr_ItemDataBound" BorderColor="Silver" BorderWidth="1px" DataKeyField="idkhambenh" AutoGenerateColumns="false" AllowSorting="True" PageSize="30">
<PagerStyle Mode="NumericPages" HorizontalAlign="Right" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="DarkBlue"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrNoSelectItem"></ItemStyle>
<Columns>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnEdit" runat="server" __designer:wfdid="w6" CommandName="Edit" CommandArgument='<%# Eval("idbenhnhan") %>' width="40px" Text='<%# Eval("TinhTrang") %>' CssClass="alink3"></asp:LinkButton> 
</ItemTemplate>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnMau01" runat="server" CommandName="ViewTTBN" CommandArgument='<%# Eval("idbenhnhan") %>' width="90px" >Bảng kê chi phí</asp:LinkButton> 
</ItemTemplate>
<HeaderStyle Width="9%"></HeaderStyle>

</asp:TemplateColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lbtnMauTH" runat="server" CommandName="ViewMauTH" CommandArgument='<%# Eval("idchitietdangkykham") %>' width="50px" >Mẫu TH</asp:LinkButton> 
</ItemTemplate>
<HeaderStyle Width="5%"></HeaderStyle>
</asp:TemplateColumn>
<%--<asp:ButtonColumn CommandName="ViewTTBN"  Text="Mẫu 01">
<HeaderStyle Wrap="False" Width="7%"></HeaderStyle>
</asp:ButtonColumn>--%>
<asp:TemplateColumn HeaderText="STT"><ItemTemplate>
		<%=STT()%>	
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="12%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="14%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="diachi" HeaderText="Địa chỉ">
<HeaderStyle Wrap="False" Width="20%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<%--<asp:BoundColumn DataField="dienthoai" HeaderText="Điện thoại">
<HeaderStyle HorizontalAlign="Center" Wrap="False" Width="13%"></HeaderStyle>
</asp:BoundColumn>--%>
<asp:BoundColumn DataField="gioitinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="namsinh" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaykham" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ngày nhập khám">
<HeaderStyle Width="12%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
<%--<asp:BoundColumn DataField="tenbacsi" HeaderText="T&#234;n B&#225;c sĩ">
<HeaderStyle Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>--%>
<asp:BoundColumn DataField="tenphongnoitru" HeaderText="Phòng khám">
<HeaderStyle Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="dgrHeader"></HeaderStyle>
</asp:datagrid>&nbsp; <asp:hiddenfield id="name1" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name2" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name3" runat="server"></asp:hiddenfield> <asp:hiddenfield id="name4" runat="server"></asp:hiddenfield> 

        <div style="LEFT: 20%; WIDTH:60%; TOP: 25%; HEIGHT: 50%" runat="server" id="light1" class="white_content" >        
        <span class="title">Thông tin CLS</span>
        <%--<asp:datagrid runat="server" visible="false" id="dgrChiTiet" OnEditCommand="EditListPopup" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
        allowsorting="True" autogeneratecolumns="False" datakeyfield="idkhambenh">--%>
        <asp:datagrid id="dgrChiTiet" visible="false" tabIndex="11" runat="server" Width="100%" OnPageIndexChanged="PageIndexStyleChanged" AllowPaging="False"  CellPadding="2"
          BorderColor="Silver" BorderWidth="1px" DataKeyField="idkhambenh" AutoGenerateColumns="false" AllowSorting="True">
              <Columns> 
<%--                <asp:TemplateColumn><ItemTemplate>
                <asp:LinkButton id="lbtnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("idkhambenh") %>' width="40px" CssClass="alink3">Chi tiết</asp:LinkButton> 
                </ItemTemplate>

                <HeaderStyle Width="7%"></HeaderStyle>
                </asp:TemplateColumn>--%>
            <asp:BoundColumn DataField="TenDichVu" HeaderText="Tên dịch vụ">
            <HeaderStyle Width="10%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
             <asp:BoundColumn DataField="SoLuong" HeaderText="Số Lượng">
            <HeaderStyle Width="2%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedItemStyle>

            <PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

            <ItemStyle ForeColor="#000066"></ItemStyle>

            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
    </asp:datagrid>
     <input type="button" value="Đóng"  onclick="Close();"/>
    </div>
   
    <div style="LEFT:20%; WIDTH:60%; TOP: 25%; HEIGHT: 50%" runat="server" id="divToaThuoc" class="white_content" >        
        <span class="title">Thông tin toa thuốc</span>
        <%--<asp:datagrid runat="server" visible="false" id="dgrChiTiet" OnEditCommand="EditListPopup" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
        allowsorting="True" autogeneratecolumns="False" datakeyfield="idkhambenh">--%>
        <asp:datagrid id="dgrToaThuoc" visible="false" tabIndex="11" runat="server" Width="100%" OnPageIndexChanged="PageIndexStyleChanged" AllowPaging="False"  CellPadding="2"
          BorderColor="Silver" BorderWidth="1px" DataKeyField="idkhambenh" AutoGenerateColumns="false" AllowSorting="True">
              <Columns> 
            <asp:BoundColumn DataField="TenThuoc" HeaderText="Tên Thuốc">
            <HeaderStyle Width="10%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
             <asp:BoundColumn DataField="SoLuongKe" HeaderText="Số Lượng">
            <HeaderStyle Width="2%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedItemStyle>

            <PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

            <ItemStyle ForeColor="#000066"></ItemStyle>

            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
    </asp:datagrid>
     <input type="button" value="Đóng"  onclick="CloseThuoc();"/>
    </div> 
     

<div style="display:none;position:fixed;top:15%;bottom:10%;left:10%;width:80%;background-color:White;z-index:1000;padding:10px 10px 10px 10px;border:10px solid #4D67A2;overflow-y:scroll;" id="divlydo" runat="server">
        <table style="text-align:left;" border="1" cellpadding="3" cellspacing="0"  bordercolor="black">
            <tr>
                <td width="100px">Mã bệnh nhân</td>
                <td width="200px"><asp:Label forecolor="blue" ID="lbMaBN" runat="server" ></asp:Label></td>
                <td width="100px">Tên bệnh nhân</td>
                <td width="200px"><asp:Label forecolor="blue" ID="lbTenBenhNhan" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>Địa chỉ</td>
                <td colspan="3"><asp:Label forecolor="blue" ID="lbDiaChi" runat="server" ></asp:Label></td>
            </tr>
        </table>
        
        <span class="title">Thông tin chi tiết điều trị</span>         
        <table>
            <tr>
                <td><asp:label runat="server" id="lblTenBN"></asp:label></td>
                <%--<td style="padding-left:20%"><asp:label runat="server" id="lblDC"></asp:label></td>--%>
            </tr>
        </table>
        <%--<asp:datagrid runat="server" visible="false" id="dgrChiTiet" OnEditCommand="EditListPopup" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
        allowsorting="True" autogeneratecolumns="False" datakeyfield="idkhambenh">--%>
        <asp:datagrid  id="dgrChiTietChild" visible="false" tabIndex="11" runat="server" Width="100%" OnPageIndexChanged="PageIndexStyleChanged" AllowPaging="False" OnItemCommand="dgrChiTietChild_ItemCommand" CellPadding="2"
          BorderColor="Silver" BorderWidth="1px" DataKeyField="idkhambenh" AutoGenerateColumns="false" AllowSorting="True">
              <Columns> 
                <asp:TemplateColumn><ItemTemplate>
                <asp:LinkButton id="lbtnEdit1" runat="server" CommandName="Edit" CommandArgument='<%# Eval("idbenhnhantoathuoc") %>' width="40px" CssClass="alink3">Chi tiết</asp:LinkButton> 
                </ItemTemplate>
                <HeaderStyle Width="10%"></HeaderStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn><ItemTemplate>
                <asp:LinkButton id="lbtnEditKB" runat="server" CommandName="EditPhieuKham" CommandArgument='<%# Eval("idkhambenh") %>' width="30px" CssClass="alink3">Sửa</asp:LinkButton> 
                </ItemTemplate>
                <HeaderStyle Width="10%"></HeaderStyle>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Lan" HeaderText="Số lần chỉ đinh">
            <HeaderStyle Width="30%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="NgayThang" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ngày tháng">
            <HeaderStyle Width="30%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
                         
             <asp:BoundColumn DataField="KhoaChiDinh" HeaderText="Khoa Chỉ định">
            <HeaderStyle Width="30%"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
            </asp:BoundColumn>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedItemStyle>

            <PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

            <ItemStyle ForeColor="#000066"></ItemStyle>

            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
    </asp:datagrid><br />
    <%--<span class="title">Thông tin toa thuốc</span>--%>
    <br />
    <asp:Button ID="btnLuuRaVien" runat="server" Text="Chỉ định xuất khoa" onclick="btnLuuRaVien_click" />
    <input type="button" value="Đóng"  onclick="CloseChild();"/>
</div>
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
    <asp:updatepanel id="updatepanelHidden" runat="server">	
        <ContentTemplate>        
            <input id="hdIdKhamBenh" type="hidden" runat="server" />
         </ContentTemplate>
    </asp:updatepanel>	
    </td>
   </tr>
  </table>  
 
 </form>
<!--#include file ="footer.htm"-->
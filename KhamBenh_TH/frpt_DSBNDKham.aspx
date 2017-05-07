<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frpt_DSBNDKham.aspx.cs" Inherits="frpt_DSBNDKham" %>

<!--#include file ="header.htm"-->
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
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-color: #C0C0C0">
        <tr>
            <td style="background-color:#fff;">
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
            
            </td>
        </tr>
      
        <tr>
            <td width="100%" align="left" style="background-color: #D4D0C8">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="100%" valign="top" style="padding-left: 0px; padding-top: 0px">
                            <table id="user" cellspacing="1" cellpadding="1" width="100%" border="0" class="khung">
                                <tr>
                                    <td class="title" align="center" style="background-color: #4D67A2; height: 25px;">
                                        <strong><span class="title" style="color: #FFFFFF">DANH SÁCH BỆNH NHÂN </span>&nbsp;<asp:radiobuttonlist
                                            id="rdochon" runat="server" forecolor="Yellow" repeatdirection="Horizontal" repeatlayout="Flow">
                                 
                            </asp:radiobuttonlist>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" style="height: 133px">
                                                    Số BHYT:<asp:textbox id="txtSoBHT" runat="server" readonly="False" tabindex="1" width="129px"></asp:textbox>&nbsp;
                                                    Mã BN:&nbsp;
                                                    <asp:textbox id="txtMaBenhNhan" runat="server" readonly="False" tabindex="1" width="93px"></asp:textbox>
                                                    &nbsp;&nbsp; Tên bệnh nhân:&nbsp;
                                                    <asp:textbox id="txtTenBenhNhan" runat="server" width="274px" tabindex="2"></asp:textbox>
                                                    &nbsp;&nbsp;<br />
                                                    Địa chỉ:&nbsp;
                                                    <asp:textbox id="txtDiaChi" runat="server" width="200px" tabindex="4"></asp:textbox>
                                                    Điện thoại:&nbsp;
                                                    <asp:textbox id="txtDienThoai" runat="server" width="100px" tabindex="3"></asp:textbox>
                                                    &nbsp;Từ ngày :
                                                    <asp:textbox id="txtTuNgay" runat="server" tabindex="1" width="77px"></asp:textbox>
                                                    &nbsp; Đến ngày: &nbsp;<asp:textbox id="txtDenNgay" runat="server" tabindex="1" width="73px"></asp:textbox>
                                                    &nbsp; &nbsp; &nbsp; Loại BN:&nbsp;
                                                    <asp:dropdownlist id="cbLoaiBN" runat="server" width="139px"></asp:dropdownlist>
                                                    &nbsp;
                                                    <br />
                                                    Bác sĩ:&nbsp;<asp:dropdownlist id="ddlBS" runat="server" width="200px"></asp:dropdownlist>
                                                    &nbsp; Phòng số:
                                                    <asp:dropdownlist id="ddPhongSo" runat="server" width="216px" visible="True"></asp:dropdownlist>
                                                    <asp:button id="btnGetList" runat="server" onclick="btnGetList_Click" text="Lấy danh sách"
                                                        width="112px" />
                                                    <asp:button id="btnNew" runat="server" onclick="btnNew_Click" text="Tìm mới" width="66px" />
                                                    <br />
                                                    <strong>
                                                        <br />
                                                        Kết quả tìm kiếm: </strong>
                                                    <br />
                                                    <table border="true">
                                                        <tr>
                                                            <td rowspan="3" style="width: 100px">
                                                                <asp:label id="Label1" runat="server" text="Tổng số bệnh nhân: " width="138px"></asp:label>
                                                            </td>
                                                            <td rowspan="3" style="width: 47px">
                                                                <asp:textbox id="txtSLBN" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td rowspan="2" style="width: 73px">
                                                                <asp:label id="Label2" runat="server" text="Bảo hiểm"></asp:label>
                                                            </td>
                                                            <td rowspan="2" style="width: 48px">
                                                                <asp:textbox id="txtSLKBH" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td style="width: 21px; height: 26px">
                                                            </td>
                                                            <td rowspan="2" style="width: 95px">
                                                                <asp:label id="Label3" runat="server" text="Miễn phí khám"></asp:label>
                                                            </td>
                                                            <td rowspan="2" style="width: 45px">
                                                                <asp:textbox id="txtSLKT" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td style="width: 9px; height: 26px">
                                                            </td>
                                                            <td rowspan="2" style="width: 57px">
                                                                <asp:label id="Label4" runat="server" text="Dịch vụ"></asp:label>
                                                            </td>
                                                            <td rowspan="2" style="width: 48px">
                                                                <asp:textbox id="txtSLKDV" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 21px">
                                                            </td>
                                                            <td style="width: 9px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 73px">
                                                                <asp:label id="Label6" runat="server" text="Khám bệnh"></asp:label>
                                                            </td>
                                                            <td style="width: 48px">
                                                                <asp:textbox id="txtSLDKK" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td style="width: 21px">
                                                            </td>
                                                            <td style="width: 95px">
                                                                <asp:label id="Label5" runat="server" text="Đăng ký CLS"></asp:label>
                                                            </td>
                                                            <td style="width: 45px">
                                                                <asp:textbox id="txtSLCLS" runat="server" width="48px"></asp:textbox>
                                                            </td>
                                                            <td style="width: 9px">
                                                            </td>
                                                            <td style="width: 57px">
                                                            </td>
                                                            <td style="width: 48px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="left" width="100%" height="20" class="title" style="color: #FFFFFF;
                                                    background-color: #4D67A2">
                                                    DANH SÁCH BỆNH NHÂN ĐÃ KHÁM
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td valign="top" align="center" width="100%" colspan="2" height="20">
                                                    <div align="left">
                                                        <asp:button id="btnxuatexcel" runat="server" text="Xuất excel" onclick="btnxuatexcel_Click" />
                                                    </div>
                                                    <asp:panel runat="server" id="inan" runat="server">
									    <asp:GridView ID="dsbntn" runat="server" BackColor="White" 
                                            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                            Width="100%" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="STT" HeaderText="STT" ItemStyle-Width="4%" 
                                                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NgayKham" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày khám" 
                                                    ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="tenbenhnhan" HeaderText="Tên bệnh nhân" 
                                                    ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="namsinh" HeaderText="Năm sinh" ItemStyle-Width="5%" 
                                                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="diachi" HeaderText="Địa chỉ"  
                                                    ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Gioitinh" HeaderText="Giới tính" 
                                                    ItemStyle-Width="5%" ItemStyle-HorizontalAlign="center" >
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MoTa" HeaderText="Chẩn đoán" 
                                                    ItemStyle-Width="15%" ItemStyle-HorizontalAlign="center" >
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TenHuongDieuTri" HeaderText="Hướng điều trị" 
                                                    ItemStyle-Width="15%" ItemStyle-HorizontalAlign="center" >
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GhiChu" HeaderText="Ghi chú" ItemStyle-Width="15%" 
                                                    ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                
                                            </Columns>
                                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="#DCDCDC" />
                                            
                                        </asp:GridView></asp:panel>
                                                    &nbsp;<asp:datagrid id="dgr" tabindex="12" runat="server" width="100%" allowsorting="True"
                                                        autogeneratecolumns="False" datakeyfield="idkhambenh" borderwidth="1px" bordercolor="#3366CC"
                                                        cellpadding="4" onitemcommand="dgr_ItemCommand" backcolor="White" borderstyle="None">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" HorizontalAlign="Left" BackColor="#99CCCC" Font-Names="Arial" Font-Size="Small" ForeColor="#003399"></PagerStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="White" CssClass="dgrNoSelectItem" ForeColor="#003399"></ItemStyle>
<Columns>
<asp:BoundColumn DataField="STT" HeaderText="STT"></asp:BoundColumn>
<asp:ButtonColumn CommandName="ViewTTBN" Text="Xem chi tiết" HeaderText="Xem chi tiết"></asp:ButtonColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>

<ItemStyle Wrap="True"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<HeaderStyle Wrap="False" Width="15%" ></HeaderStyle>

<ItemStyle HorizontalAlign="Left"  Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NamSinh" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>


<asp:BoundColumn DataField="GioiTinh" HeaderText="Giới tính">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TenPhong" HeaderText="Phòng">
<HeaderStyle Wrap="False" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LoaiBN" HeaderText="Loại BN">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NgayKham" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Ngày khám">
<HeaderStyle Width="12%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>




<asp:BoundColumn DataField="HuongDieuTri" HeaderText="Hướng điều trị">
<HeaderStyle Width="5%"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="TenBacSi"  HeaderText="Bác sĩ">
<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>

<asp:BoundColumn DataField="ChanDoan" HeaderText="Chẩn đoán">
<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ItemStyle>
</asp:BoundColumn>



<asp:BoundColumn DataField="IsBNMoi" HeaderText="BN Mới?"></asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" BackColor="#003399" CssClass="dgrHeader" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>
</asp:datagrid>&nbsp;
                                                    <br />
                                                    <asp:panel id="pnlDV" runat="server" width="100%"><BR /></asp:panel>
                                                    <br />
                                                    <asp:panel id="pnlKB" runat="server" width="100%"></asp:panel>
                                                    <asp:panel id="pnlCLS" runat="server" width="100%"></asp:panel>
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
<!--#include file ="footer.htm"-->

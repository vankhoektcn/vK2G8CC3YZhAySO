<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frpt_DSBNDKCLS.aspx.cs" Inherits="frpt_DSBNDKCLS" %>

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
    <table border="0" cellpadding="0" cellspacing="0" style="background-color: #c0c0c0"
        width="100%">
        <tr>
            <td>
                <asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
            </td>
        </tr>
        <tr>
            <td align="left" style="background-color: #d4d0c8" width="100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="background-color: #d4d0c8" width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="padding-left: 0px; padding-top: 0px" valign="top" width="100%">
                            <table id="user" border="0" cellpadding="1" cellspacing="1" class="khung" width="100%">
                                <tr>
                                    <td align="center" class="title" style="height: 25px; background-color: #4d67a2">
                                        <strong><span class="title" style="color: #000000">DANH SÁCH BỆNH NHÂN CẬN LÂM SÀNG
                                        </span>&nbsp;</strong><strong> </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <table border="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td align="left"  valign="top" width="100%">
                                                    <fieldset>
                                                        <legend>Thông tin bệnh nhân: </legend>Số BHYT:<asp:textbox id="txtSoBHT" runat="server"
                                                            readonly="False" tabindex="1" width="129px"></asp:textbox>&nbsp; Mã BN:&nbsp;
                                                        <asp:textbox id="txtMaBenhNhan" runat="server" readonly="False" tabindex="1" width="93px"></asp:textbox>
                                                        &nbsp;&nbsp; Tên bệnh nhân:&nbsp;
                                                        <asp:textbox id="txtTenBenhNhan" runat="server" tabindex="2" width="274px"></asp:textbox>
                                                        &nbsp;&nbsp;<br />
                                                        Địa chỉ:&nbsp;
                                                        <asp:textbox id="txtDiaChi" runat="server" tabindex="4" width="200px"></asp:textbox>
                                                        Điện thoại:&nbsp;
                                                        <asp:textbox id="txtDienThoai" runat="server" tabindex="3" width="100px"></asp:textbox>
                                                        &nbsp;Từ ngày :
                                                        <asp:textbox id="txtTuNgay" runat="server" tabindex="1" width="77px"></asp:textbox>
                                                        &nbsp; Đến ngày: &nbsp;<asp:textbox id="txtDenNgay" runat="server" tabindex="1" width="73px"></asp:textbox>
                                                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                                        <asp:checkbox id="chbIsTuDen" runat="server" text="Tự ĐK"></asp:checkbox>
                                                        &nbsp; &nbsp;
                                                        <asp:checkbox id="chbIsCD" runat="server" text="Chỉ định"></asp:checkbox>
                                                        <asp:checkbox id="chbIsTuDen_KK" runat="server" text="Tự ĐK không khám"></asp:checkbox>
                                                        &nbsp; &nbsp; &nbsp; &nbsp;<asp:button id="btnGetList" runat="server" onclick="btnGetList_Click"
                                                            text="Lấy danh sách" width="112px" />
                                                        <asp:button id="btnNew" runat="server" onclick="btnNew_Click" text="Tìm mới" width="66px" />
                                                        <br />
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
                                        <fieldset>
                                            <legend>Danh sách bệnh nhân</legend>
                                            <table border="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td align="center" colspan="2" height="20" valign="top" width="100%">
                                                        <div align="left">
                                                            <asp:button id="btnxuatexcel" runat="server" onclick="btnxuatexcel_Click" text="Xuất excel" />
                                                        </div>
                                                        <asp:panel id="inan" runat="server"><asp:GridView id="dsbntn" runat="server" Width="100%" BorderStyle="None" BackColor="White" CellPadding="3" BorderColor="#999999" BorderWidth="1px" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="STT" HeaderText="STT" ItemStyle-Width="4%" 
                                                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ngaytiepnhan" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày ĐK" 
                                                    ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="mabenhnhan" HeaderText="Mã BN" 
                                                    ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="tenbenhnhan" HeaderText="Tên bệnh nhân" 
                                                    ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="namsinh" HeaderText="Năm sinh" ItemStyle-Width="5%" 
                                                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Left" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Gioitinh" HeaderText="Giới tính" 
                                                    ItemStyle-Width="5%" ItemStyle-HorizontalAlign="center" >
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SoBHYT" HeaderText="Số BHYT" ItemStyle-Width="15%" 
                                                    ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="diachi" HeaderText="Địa chỉ"  
                                                    ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="tendichvu" HeaderText="Phòng" 
                                                    ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Left" >
                                                
<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                </asp:BoundField>
                                                
                                            </Columns>
                                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="#DCDCDC" />
                                            
                                        </asp:GridView></asp:panel>
                                                        &nbsp;<asp:datagrid id="dgr" runat="server" allowsorting="True" autogeneratecolumns="False"
                                                            backcolor="White" bordercolor="#3366CC" borderstyle="None" borderwidth="1px"
                                                            cellpadding="4" datakeyfield="idbenhnhan" onitemcommand="dgr_ItemCommand" tabindex="12"
                                                            width="100%">
<FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

<SelectedItemStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True"></SelectedItemStyle>

<PagerStyle Mode="NumericPages" BackColor="#99CCCC" ForeColor="#003399" Font-Size="Small" Font-Names="Arial" HorizontalAlign="Left"></PagerStyle>

<AlternatingItemStyle CssClass="dgrSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></AlternatingItemStyle>

<ItemStyle BackColor="White" ForeColor="#003399" CssClass="dgrNoSelectItem" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>

<HeaderStyle BackColor="#003399" ForeColor="#CCCCFF" CssClass="dgrHeader" HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
<Columns>
<asp:BoundColumn DataField="STT" HeaderText="STT"></asp:BoundColumn>
<asp:BoundColumn DataField="mabenhnhan" HeaderText="M&#227; bệnh nh&#226;n">
<ItemStyle Wrap="True"></ItemStyle>

<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="tenbenhnhan" HeaderText="T&#234;n bệnh nh&#226;n">
<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="15%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NamSinh" HeaderText="Năm sinh">
<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="GioiTinh" HeaderText="Giới t&#237;nh">
<HeaderStyle Width="3%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SOBHYT" HeaderText="Số BHYT"></asp:BoundColumn>
<asp:BoundColumn DataField="TenDichVu" HeaderText="Bác sĩ chỉ định">
<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="15%" Wrap="False"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LoaiBN" HeaderText="Loại BN">
<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ngaytiepnhan" HeaderText="Ng&#224;y ĐK" DataFormatString="{0:dd/MM/yyyy HH:mm}">
<ItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="12%"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DaThuView" HeaderText="T.Trạng">
<ItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

<HeaderStyle Width="5%"></HeaderStyle>
</asp:BoundColumn>
<asp:TemplateColumn><ItemTemplate>
<asp:LinkButton id="lnkChiTiet" runat="server" __designer:wfdid="w3" CommandArgument='<%# Eval("IdDangKyCls") %>' CommandName="Detail">Chi tiết</asp:LinkButton> 
</ItemTemplate>
<ItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

</asp:TemplateColumn>
</Columns>
</asp:datagrid>&nbsp;
                                                        <br />
                                                        <asp:panel id="pnlDV" runat="server" width="100%"><BR /></asp:panel>
                                                        <br />
                                                        <asp:panel id="pnlKB" runat="server" width="100%"></asp:panel>
                                                        <asp:panel id="pnlCLS" runat="server" width="100%"></asp:panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
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

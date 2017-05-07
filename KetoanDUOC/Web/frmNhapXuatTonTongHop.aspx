<%@ Page Language="C#" MasterPageFile="../MasterPage_new.master" AutoEventWireup="true"
    CodeFile="frmNhapXuatTonTongHop.aspx.cs" Inherits="QLDUOC_Web_frmNhapXuatTonTongHop"
    Title="Bảng nhập xuất tổng hợp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">

    <script type="text/javascript">
    function ChonSanPham(obj){
        $(obj).unautocomplete().autocomplete("../ajax/frm_PhieuNhapKho_ajax.aspx?do=ChonSanPham&LoaiThuocID="+document.getElementById('ctl00_body_cbLoaiThuoc').value,
        {formatItem: function(data) {
                return data[0];
            },width:300,scroll:true}
        );
        
        }
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
	
	function checkvalid()
	{
	    var tungay = document.getElementById("txtTuNgay");
	    var denngay = document.getElementById("txtDenNgay");
	    var kho = document.getElementById("ddlkho");
	    var thuoc = document.getElementById("ddlthuoc");
	    if(tungay.value == "")
	    {
	        alert("Vui lòng chọn ngày!");
	        tungay.focus();
	        return false;
	    }
	    if(denngay.value == "")
	    {
	        alert("Vui lòng chọn ngày!");
	        denngay.focus();
	        return false;
	    }
	 
	    return true;
	}
    </script>

    <style>
        .div-Out
        {
            width:320px;
        }
        .div-Out p, .div-Out .div-Right {
            width: 60%;
            float: right;
            border-left: 1px solid #EFEFEF;
            padding: 0px 0px 10px 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BẢNG NHẬP XUẤT TỔNG HỢP")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay")%>
                </h4>
                <p>
                    <asp:TextBox ID="txtTuNgay" runat="server" TabIndex="1" Width="118px" onfocus="chuyenphim(this);$(this).datepick();"></asp:TextBox>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay")%>
                </h4>
                <p>
                    <asp:TextBox ID="txtDenNgay" runat="server" TabIndex="1" Width="118px" onfocus="chuyenphim(this);$(this).datepick();"></asp:TextBox>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho")%>
                </h4>
                <p>
                    <asp:DropDownList ID="ddlkho" runat="server" Width="200px">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LoaithuocID")%>
                </h4>
                <p>
                    <asp:DropDownList ID="cbLoaiThuoc" runat="server" Width="130px">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên")%>
                </h4>
                <p>
                    <asp:TextBox ID="txtTenThuoc" runat="server" onfocus="ChonSanPham(this);"></asp:TextBox>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <asp:Button ID="btnLayDanhSach" runat="server" Text="Lấy danh sách" Width="127px"
                        OnClick="btnLayDanhSach_Click" /></h4>
            </div>
        </div>
        <div style="">
            <asp:DataGrid ID="dgr" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                CssClass="jtable" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" PageSize="50"
                TabIndex="12" Width="100%" BackColor="#DEBA84" BorderStyle="None" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"></SelectedItemStyle>
                <PagerStyle Mode="NumericPages" HorizontalAlign="Center" Font-Names="Arial" Font-Size="Small"
                    ForeColor="#8C4510"></PagerStyle>
                <AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem">
                </AlternatingItemStyle>
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="#FFF7E7" CssClass="dgrNoSelectItem"
                    ForeColor="#8C4510"></ItemStyle>
                <Columns>
                    <asp:BoundColumn DataField="STT" HeaderText="STT">
                        <HeaderStyle Width="2%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                            Font-Strikeout="False" Font-Underline="False"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="LoaiNX" HeaderText="Loại NX"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Tenthuoc" HeaderText="T&#234;n sp,hh">
                        <HeaderStyle Width="15%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                            Font-Strikeout="False" Font-Underline="False"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TenDVT" HeaderText="ĐVT"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NgayThang" HeaderText="Ng&#224;y th&#225;ng" DataFormatString="{0:dd/MM/yy hh:mm}">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SoPhieu" HeaderText="Số phiếu"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DoiTuong" HeaderText="Đối tượng"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SoLuong" HeaderText="SL"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DonGia" DataFormatString="{0:N0}" HeaderText="Đơn gi&#225;">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ThanhTien" DataFormatString="{0:N0}" HeaderText="Th&#224;nh tiền">
                    </asp:BoundColumn>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" CssClass="header" Font-Bold="True" ForeColor="White">
                </HeaderStyle>
            </asp:DataGrid>
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThietLapCa.aspx.cs" Inherits="NhanSu_ThietLapCa" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--#include file ="header.htm"-->

<body>
    <form id="form1" runat="server">
    <div id="Menu" style="background-color:White;text-align:left">
	    <uc1:uscmenu ID="Uscmenu1" runat="server" />
	</div>
<div id="MyPage">
    
	<div id="header">
		Thiết lập ca
	</div>
	<div id="NoiDung" style="background-color:White;width:95%">
		<div id="tableBig" >			
			<div class="tableBig-row" >
			    <div style="width:80px;float:left">Phòng ban</div>
			    <div style="width:240px;float:left;">
                    <asp:DropDownList ID="ddlPhongBan" CssClass="input" runat="server" Width="130px">
                    </asp:DropDownList></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:80px;float:left">Ngày thứ</div>
			   <div style="width:200px;float:left;display:block;" ><asp:textbox runat="server" id="txtNgayThu" CssClass="input" ></asp:textbox></div>
			</div>
			
			<div class="tableBig-row">
			   <div style="width:80px;float:left">Từ ngày</div>
			   <div style="width:200px;float:left;" ><asp:textbox runat="server" id="txtTuNgay" CssClass="input"></asp:textbox></div>
			</div>
			<br />
			<div class="tableBig-row">
			   <div style="width:80px;float:left">Đến ngày</div>
			   <div style="width:240px;float:left;" ><asp:textbox runat="server" id="txtDenNgay" CssClass="input"></asp:textbox>dd/MM/yyyy</div>
			</div>
			<div class="tableBig-row">
			   <div style="width:80px;float:left">Ca làm việc</div>
			   <div style="width:200px;float:left;" >
			        <asp:DropDownList ID="ddlCaLamViec" runat="server" Width="123px" CssClass="input">
                    </asp:DropDownList>
                   </div>
			</div>
			<div class="tableBig-row">
			   <div style="width:80px;float:left">Số nhân viên</div>
			   <div style="width:100px;float:left;" >
			        <asp:textbox runat="server" id="txtSoNhanVien" Width="90px" CssClass="input"></asp:textbox>
                   </div>
			</div>				
			<div  class="tableBig-row" style="clear:both;text-align:center;">
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnLuu" Width="50px" runat="server" Text="Lưu" OnClick="btnLuu_Click"  />
                </div>
                <div style="width:60px;float:left">
                    <asp:Button ID="btnMoi" Width="50px" runat="server" Text="Mới" OnClick="btnMoi_Click"   />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnXoan" Width="50px" runat="server" Text="Xóa" OnClick="btnXoan_Click"   />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="bntTim" Width="50px" runat="server" Text="Tìm" OnClick="bntTim_Click" />
			    </div>	
			      <div style="width:100px;float:left">
                    <asp:Button ID="btnExcel" Width="96px" runat="server" Text="Xuất Excel" OnClick="btnExcel_Click" />
			    </div>	
			    <div><asp:textbox runat="server" id="txtidThietLapCa" Width="10px" Visible="false"></asp:textbox></div>		    
			</div>
		</div>
		<br />
		<div style="background-image:url(../images/menu.jpg);font-weight:bold;color:White;text-align:left;padding-left:10px">
		DANH SÁCH CA ĐÃ THIẾT LẬP
	</div>
		<br />
		<div style="clear:both;margin:0 auto;display:table;">
		    <asp:GridView ID="gidThietLapCa" runat="server" Width="993px" DataKeyNames="idthietlapca" AutoGenerateColumns="False" OnRowDeleting="gidThietLapCa_RowDeleting" OnSelectedIndexChanging="gidThietLapCa_SelectedIndexChanging"               
            HeaderStyle-CssClass="HeaderStyle" CssClass="GridViewStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle">              
                <Columns>
                    <asp:CommandField SelectText="Xem" ShowSelectButton="True" />
                    <asp:CommandField DeleteText="X&#243;a" ShowDeleteButton="True" />
                    <asp:BoundField DataField="tenphongban" HeaderText="Ph&#242;ng ban" />
                    <asp:BoundField DataField="ngaythu" HeaderText="Ng&#224;y thứ" />
                    <asp:BoundField DataField="tungay" HeaderText="Từ ng&#224;y" />
                    <asp:BoundField DataField="denngay" HeaderText="Đến ng&#224;y" />
                    <asp:BoundField DataField="tencalamviec" HeaderText="Ca l&#224;m việc" />
                    <asp:BoundField DataField="sonhanvien" HeaderText="Số nh&#226;n vi&#234;n" />
                </Columns>
                               
            </asp:GridView>            
		</div>
		
	</div>
</div>
    </form>
<!--#include file = "footer.htm" -->

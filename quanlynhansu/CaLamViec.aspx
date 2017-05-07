<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CaLamViec.aspx.cs" Inherits="CaLamViec" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->
<form id="Form1" method="post" runat="server">
<div id="MyPage">
     <div id="Menu">
	    <uc1:uscmenu ID="Uscmenu1" runat="server" />
	</div>
	<div id="header">
		Danh mục ca làm việc
	</div>
	<div id="NoiDung">
		<div id="table">			
			<div style="display:table;">
			    <div style="width:100px;float:left">Tên Ca làm việc</div>
			    <div style="display:table-cell;text-align:left"><asp:textbox runat="server" id="txttenCaLamviec"></asp:textbox>&nbsp;</div>
			</div>
			<div  style="display:table;">
			   <div style="width:100px;float:left">Ngày thứ </div>
			   <div style="display:table-cell" ><asp:textbox runat="server" id="txtngauThu"></asp:textbox></div>
			</div>
			<div  style="display:table;">
			    <div style="width:100px;float:left">Từ giờ<asp:textbox runat="server" id="txtidCaLamviec" Width="10px" Visible="false"></asp:textbox> </div>
			    <div style="display:table-cell" ><asp:textbox runat="server" id="txttuGio" Width="73px"></asp:textbox>HH:SS</div>
			</div>
			<div  style="display:table;">
			    <div style="width:100px;float:left">Đến giờ</div>
			    <div style="display:table-cell"><asp:textbox runat="server" id="txtdenGio" Width="73px"></asp:textbox>HH:SS</div>
			</div>			
			<div  style="display:table;margin:0">
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnLuu" Width="50px" runat="server" Text="Lưu" OnClick="btnLuu_Click" />
                </div>
                <div style="width:60px;float:left">
                    <asp:Button ID="btnMoi" Width="50px" runat="server" Text="Mới" OnClick="btnMoi_Click" />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnXoan" Width="50px" runat="server" Text="Xóa" OnClick="btnXoan_Click" />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="bntTim" Width="50px" runat="server" Text="Tìm" OnClick="bntTim_Click" />
			    </div>			    
			</div>
		</div>
		<div >
            <asp:GridView ID="gidCaLamViec" runat="server" Width="993px" DataKeyNames="Mã" OnRowDeleting="gidCaLamViec_RowDeleting" OnSelectedIndexChanging="gidCaLamViec_SelectedIndexChanging">
                <Columns>
                    <asp:CommandField SelectText="Sửa" ShowSelectButton="True" />
                    <asp:CommandField DeleteText="X&#243;a" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
		</div>
	</div>
</div>
 
 </form>
<!--#include file ="footer.htm"-->
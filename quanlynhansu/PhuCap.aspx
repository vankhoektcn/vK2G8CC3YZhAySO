<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhuCap.aspx.cs" Inherits="NhanSu_PhuCap" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>
<!--#include file ="header.htm"-->
<body>
    <form id="form1" runat="server">
<div id="MyPage">
    <div id="Menu">
	    <uc1:uscmenu ID="Uscmenu1" runat="server" />
	</div>
	<div id="header">
		Phụ cấp
	</div>
	<div id="NoiDung">
		<div id="tableBig">			
			<div class="tableBig-row">
			    <div style="width:80px;float:left">Tên phụ cấp</div>
			    <div style="width:350px;float:left;"><asp:textbox  Width="350px" runat="server" id="txtTenPC"></asp:textbox></div>
			</div>		
				
			<div  class="tableBig-row" style="clear:both;text-align:center;">
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnLuu" CssClass="btn" Width="50px" runat="server" Text="Lưu" OnClick="btnLuu_Click"   />
                </div>
                <div style="width:60px;float:left">
                    <asp:Button ID="btnMoi" CssClass="btn" Width="50px" runat="server" Text="Mới" OnClick="btnMoi_Click"  />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnXoan" CssClass="btn" Width="50px" runat="server" Text="Xóa" OnClick="btnXoan_Click"   />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="bntTim" CssClass="btn" Width="50px" runat="server" Text="Tìm" OnClick="bntTim_Click"  />
			    </div>	
			    <div><asp:textbox runat="server" id="txtidPhuCap" Width="10px" Visible="false"></asp:textbox></div>		    
			</div>
		</div>
		<div style="clear:both;margin:10px auto;display:table;">
		    <asp:GridView ID="gidPhuCap" runat="server" Width="993px" DataKeyNames="idphucap" AutoGenerateColumns="False" OnSelectedIndexChanging="gidPhuCap_SelectedIndexChanging" OnRowDeleting="gidPhuCap_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None"  >                
                <Columns>
                    <asp:CommandField SelectText="Sửa" ShowSelectButton="True" />
                    <asp:CommandField DeleteText="X&#243;a" ShowDeleteButton="True" />
                    <asp:BoundField DataField="tenphucap" HeaderText="T&#234;n phụ cấp" />
                    
                </Columns>
                <RowStyle BackColor="#E3EAEB" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <AlternatingRowStyle BackColor="White" />
                
            </asp:GridView>            
		</div>
		
	</div>
</div>
    </form>
<!--#include file ="footer.htm"-->
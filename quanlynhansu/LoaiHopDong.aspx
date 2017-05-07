<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoaiHopDong.aspx.cs" Inherits="NhanSu_LoaiHopDong" %>
<%@ Register Src="uscmenu.ascx" TagName="uscmenu" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--#include file ="header.htm"-->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Loại hợp đồng</title>   
</head>
<body>
<form id="form1" runat="server">
<div id="MyPage" >
    <div id="Menu" style="background-color:White;text-align:left">
	    <uc1:uscmenu ID="Uscmenu1" runat="server" />
	</div>
	<div id="header">
		Loại hợp đồng
	</div>
	<div id="NoiDung" style="background-color:White;width:95%">
		<div id="tableBig">			
			<div class="tableBig-row">
			    <div style="width:150px;float:left;text-align:right">Tên loại hợp đồng: </div>
			    <div style="width:200px;float:left;display:block;"><asp:textbox CssClass="input" runat="server" id="txtTenLoaiHD"></asp:textbox></div>
			</div>
			<div class="tableBig-row">
			   <div style="width:50px;float:left">Ghi chú: </div>
			   <div style="width:300px;float:left;display:block;" ><asp:textbox runat="server" CssClass="input" id="txtGhiChu" Width="289px"></asp:textbox></div>
			</div>			
			<div  class="tableBig-row" style="clear:both;text-align:center;">
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnLuu" Width="50px" runat="server" Text="Lưu" OnClick="btnLuu_Click"  />
                </div>
                <div style="width:60px;float:left">
                    <asp:Button ID="btnMoi" Width="50px" runat="server" Text="Mới" OnClick="btnMoi_Click"  />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="btnXoan" Width="50px" runat="server" Text="Xóa" OnClick="btnXoan_Click"  />
			    </div>
			    <div style="width:60px;float:left">
                    <asp:Button ID="bntTim" Width="50px" runat="server" Text="Tìm" OnClick="bntTim_Click" />
			    </div>	
			    <div><asp:textbox runat="server" id="txtidLoaiHD" Width="10px" Visible="false"></asp:textbox></div>		    
			</div>
		</div>
		<br />
		<div style="background-image:url(../images/menu.jpg);font-weight:bold;color:White;text-align:left;padding-left:10px">
		DANH SÁCH LOẠI HỢP ĐỒNG
	</div>
	<br />
		<div style="clear:both;margin:0 auto;display:table;">
		    <asp:GridView ID="gidLoaiHD" runat="server" Width="993px" DataKeyNames="idloaihopdong" AutoGenerateColumns="False" OnRowCommand="gidLoaiHD_RowCommand" OnRowDeleting="gidLoaiHD_RowDeleting" OnSelectedIndexChanging="gidLoaiHD_SelectedIndexChanging" 
		    		    HeaderStyle-CssClass="HeaderStyle" CssClass="GridViewStyle" PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle">                           
                <Columns>
                    <asp:CommandField SelectText="Sửa" ShowSelectButton="True" />
                    <asp:CommandField DeleteText="X&#243;a" SelectText="Sửa" ShowDeleteButton="True" />
                    <asp:BoundField DataField="tenloaihopdong" HeaderText="T&#234;n loại đồng" />
                    <asp:BoundField DataField="ghichu" HeaderText="Ghi ch&#250;" />
                </Columns>
            </asp:GridView>
		</div>
		
	</div>
</div>
    </form>
</body>
</html>
<!--#include file ="footer.htm"-->
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_ketoanhoadondichvu.ascx.cs" Inherits="menu_ketoanhoadondichvu" %>

<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="White">
<Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="Đăng nhập"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/HDDV_XuatHoaDon.aspx" Text="&#160;&#160;Xuất hóa đơn" Value="XuatHoaDon"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/HDDV_DanhSachHoaDon.aspx" Text="&#160;&#160;Danh sách hóa đơn" Value="DanhSachHoaDon"></asp:MenuItem>
        
    </Items>
     <StaticMenuStyle HorizontalPadding="6px" VerticalPadding="1px" />
    <StaticHoverStyle BackColor="transparent" ForeColor="Red" />
    <LevelSubMenuStyles>
        <asp:SubMenuStyle Font-Underline="True"  ForeColor="Blue" />
    </LevelSubMenuStyles>
    <DynamicMenuItemStyle ItemSpacing="1px" BackColor="transparent" ForeColor="#006666" VerticalPadding="0px" />
    <DynamicItemTemplate>
        <%# Eval("Text") %>
    </DynamicItemTemplate>
    <StaticItemTemplate>
        <%# Eval("Text") %>
    </StaticItemTemplate>
    <DynamicHoverStyle BackColor="White" ForeColor="Red" />
</asp:Menu>

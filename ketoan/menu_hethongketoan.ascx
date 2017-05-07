<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_hethongketoan.ascx.cs" Inherits="menu_hethongketoan" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="White">
    <Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="m_login"></asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="m_01"></asp:MenuItem>
        <asp:MenuItem  Text="Khai báo tham số hệ thống" Value="m_thuchihd">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg"  NavigateUrl="~/ketoan/KTHT_CongNoDauKy.aspx" Text="&#160;&#160;Danh sách tham số tùy chọn" Value=""></asp:MenuItem>
        
        </asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="m_02"></asp:MenuItem>
        <asp:MenuItem  Text="Ngày bắt đầu sử dụng hệ thống" Value="m_thuchikh">
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="m_03"></asp:MenuItem>
        <asp:MenuItem  Text="Cập nhật số dư đầu kỳ" Value="m_baocao">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTHT_SoDuDauKyTaiKhoan.aspx" Text="&#160;&#160;Số dư đầu kỳ tài khoản" Value=""></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTHT_CongNoDauKy.aspx" Text="&#160;&#160;Công nợ đầu kỳ" Value=""></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTHT_CongNoDauKy.aspx" Text="&#160;&#160;Tồn kho đầu kỳ" Value=""></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTHT_CongNoDauKy.aspx" Text="&#160;&#160;Chuyển số dư" Value=""></asp:MenuItem>
        </asp:MenuItem>
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

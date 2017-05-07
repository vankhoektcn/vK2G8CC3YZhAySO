<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_baocaotaichinh.ascx.cs" Inherits="menu_baocaotaichinh" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="White">
    <Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="Đăng nhập"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BangCanDoiTK.aspx" Text="Bảng cân đối tài khoản" Value="Bảng cân đối tài khoản"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BangCanDoiKT.aspx" Text="Bảng cân đối kế toán" Value="Bảng cân đối kế toán"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KQHoatDongKD.aspx" Text="Kết quả hoạt động kinh doanh" Value="Kết quả hoạt động kinh doanh"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/LuuChuyenTienTe.aspx" Text="Báo cáo lưu chuyển tiền tệ" Value="Báo cáo lưu chuyển tiền tệ "></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/ThuyetMinhBCTC.aspx" Text="Thuyết minh báo cáo tài chính" Value="Thuyết minh báo cáo tài chính"></asp:MenuItem>
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

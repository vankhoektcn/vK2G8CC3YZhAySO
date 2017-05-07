<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hethongdanhmuc.ascx.cs" Inherits="hethongdanhmuc_uscmenu" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="White">
    <Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="Đăng nhập"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Số dư đầu kỳ" Value="Số dư đầu kỳ">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/daukytaikhoan.aspx" Text="&#160;&#160;Số dư tài khoản&#160;&#160;" Value="Số dư tài khoản"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Hệ thống danh mục" Value="Hệ thống danh mục">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/danhmuctaikhoan.aspx" Text="&#160;&#160;Danh mục tài khoản&#160;&#160;" Value="Danh mục tài khoản"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="../ketoan/danhmuckho.aspx" Text="&#160;&#160;Danh mục kho&#160;&#160;" Value="New Item 1" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/ketoan/nhacungcap.aspx" Text="&#160;&#160;Danh mục nh&#224; cung cấp&#160;&#160;" Value="Danh mục nh&#224; cung cấp" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/ketoan/danhmuckho.aspx" Text="&#160;&#160;Danh mục kho" Value="Danh mục kho" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
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

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_baocaothue.ascx.cs" Inherits="menu_baocaothue" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="White">
    <Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="Đăng nhập"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BaoCaoVATDauVao.aspx" Text="&#160;&#160;Báo cáo VAT đầu vào&#160;&#160;" Value="Báo cáo VAT đầu vào"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BaoCaoVATDauRa.aspx" Text="&#160;&#160;Báo cáo VAT đầu ra&#160;&#160;" Value="Báo cáo VAT đầu ra"></asp:MenuItem>
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

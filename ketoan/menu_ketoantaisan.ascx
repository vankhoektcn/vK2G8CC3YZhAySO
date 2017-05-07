<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_ketoantaisan.ascx.cs" Inherits="menu_ketoantaisan" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="White">
    <Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="Đăng nhập"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" Text="&#160;&#160;Danh mục TSCD/CCDC" Value="Danh muc">
             <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_DanhMucTaiSan.aspx" Text="&#160;&#160;Danh mục tài sản cố định" Value="Danh mục tài sản cố định"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_DanhMucCongCuDungCu.aspx" Text="&#160;&#160;Danh mục công cụ dụng cụ" Value="Danh mục tài sản cố định"></asp:MenuItem>

        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" Text="&#160;&#160;Khấu hao TSCD/CCDC" Value="Khấu hao">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_Khauhaotaisan.aspx" Text="&#160;&#160;Khấu hao tài sản cố định" Value="Khấu hao tài sản cố định"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_KhauHaoCCDC.aspx" Text="&#160;&#160;Khấu hao công cụ dụng cụ" Value="Khấu hao công cụ dụng cụ"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" Text="&#160;&#160;Tăng giảm TSCĐ" Value="Tăng giảm tài sản cố định">
            
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_TangGiamTaiSan.aspx?" Text="&#160;&#160;Phiếu tăng/giảm TSCĐ" Value="Tăng giảm tài sản cố định"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_DanhSachTangGiamTaiSan.aspx?" Text="&#160;&#160;Danh sách phiếu tăng/giảm" Value="Báo cáo thanh lý nhượng bán TSCĐ"></asp:MenuItem>
        
        </asp:MenuItem>
        
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" Text="&#160;&#160;Phân bổ TSCD/CCDC" Value="Phân bổ">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_PhanBoTSCD.aspx" Text="&#160;&#160;Phân bổ tài sản cố định" Value="Phân bổ TSCD"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_PhanBoCCDC.aspx" Text="&#160;&#160;Phân bổ công cụ dụng cụ" Value="Phân bổ CCDC"></asp:MenuItem>
        </asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  Text="&#160;&#160;Báo cáo tài sản" Value="Báo cáo tài sản">
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BCTangGiamTSCD.aspx" Text="&#160;&#160;Báo cáo tăng giảm TSCĐ" Value="Báo cáo tăng giảm TSCĐ"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BCTangGiamTSCD.aspx" Text="&#160;&#160;Báo cáo thanh lý nhượng bán TSCĐ" Value="Báo cáo thanh lý nhượng bán TSCĐ"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BCKhauHaoTSCD.aspx" Text="&#160;&#160;Báo cáo khấu hao TSCĐ" Value="Báo cáo khấu hao TSCĐ"></asp:MenuItem>
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

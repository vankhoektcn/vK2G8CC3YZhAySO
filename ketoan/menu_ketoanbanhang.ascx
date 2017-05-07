<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_ketoanbanhang.ascx.cs" Inherits="menu_ketoanbanhang" %>

<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="White">
<Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="Đăng nhập"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BangGiaSP.aspx" Text="&#160;&#160;Bảng giá sản phẩm" Value="Bảng giá sản phẩm"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <%--<asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BangGiaVTYT.aspx" Text="&#160;&#160;Bảng giá VTYT" Value="Bảng giá VTYT"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/ChietKhauThuoc_VTYT.aspx" Text="&#160;&#160;Chiết khấu Thuốc - VTYT" Value="Chiết khấu Thuốc - VTYT"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/ChietKhauBSiDDuong.aspx" Text="&#160;&#160;Chiết khấu theo bác sĩ/điều dưỡng" Value="Chiết khấu theo bác sĩ/điều dưỡng"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>--%>
        <%-- <asp:MenuItem  Text="Bán thuốc" Value="Bán thuốc"> --%>
        <%--    <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/toathuocentry.aspx" Text="&#160;&#160;Bán thuốc lẻ" Value="Bán thuốc lẻ"></asp:MenuItem> --%>
        <%--    <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/listtoathuocbenhnhan.aspx" Text="&#160;&#160;Bán thuốc theo toa" Value="Bán thuốc theo toa"></asp:MenuItem> --%>
        <%-- </asp:MenuItem> --%>
        <%-- <asp:MenuItem Text="|" Value="|"></asp:MenuItem> --%>
        <%--    <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BanVTYT.aspx" Text="&#160;&#160;Bán VTYT" Value="Bán VTYT"></asp:MenuItem> --%>
        <%-- <asp:MenuItem Text="|" Value="|"></asp:MenuItem> --%>
        <asp:MenuItem  Text="Hóa đơn bán hàng" Value="Hóa đơn bán hàng">
            <asp:MenuItem NavigateUrl="danhmuctoasanpham.aspx" Text="&#160;&#160;Xuất hóa đơn&#160;&#160;" Value="New Item 2" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>                        
            <asp:MenuItem NavigateUrl="hoadonthuoc.aspx" Text="&#160;&#160;Xuất hóa đơn thuốc&#160;&#160;" Value="New Item 2" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>                        
            <asp:MenuItem NavigateUrl="hoadonphongkham.aspx" Text="&#160;&#160;Xuất hóa đơn PK&#160;&#160;" Value="New Item 2" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>                        
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  Text="Báo cáo bán hàng" Value="Báo cáo bán hàng">
        <asp:MenuItem NavigateUrl="doanhthubansanpham_kenh.aspx" Text="&#160;&#160;Thống k&#234; doanh thu sữa-TPCN theo kênh&#160;&#160;" Value="New Item 2" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>                        
            <asp:MenuItem NavigateUrl="doanhthubansanpham.aspx" Text="&#160;&#160;Thống k&#234; doanh thu sữa-TPCN&#160;&#160;" Value="New Item 2" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>                        
            <asp:MenuItem NavigateUrl="doanhthubanthuoc.aspx" Text="&#160;&#160;Thống k&#234; doanh thu thuốc&#160;&#160;" Value="New Item 2" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>                        
            <%--<asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BanHangGroupTheoKH.aspx" Text="&#160;&#160;Báo cáo bán hàng theo khách hàng" Value="Báo cáo bán hàng theo khách hàng"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BanHangGroupTheoMH.aspx" Text="&#160;&#160;Báo cáo bán hàng theo mặt hàng" Value="Báo cáo bán hàng theo mặt hàng"></asp:MenuItem>--%>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BanHangGroupTheoHoaDon.aspx" Text="&#160;&#160;Báo cáo DT sữa-TPCN theo hóa đơn" Value="Báo cáo bán hàng theo hóa đơn"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BanThuocGroupTheoHoaDon.aspx" Text="&#160;&#160;Báo cáo DT thuốc theo hóa đơn" Value="Báo cáo bán thuốc theo hóa đơn"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DoanhThuPKGroupTheoHoaDon.aspx" Text="&#160;&#160;Báo cáo doanh thu PK theo hóa đơn" Value="Báo cáo bán thuốc theo hóa đơn"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/TongHopDoanhThu.aspx" Text="&#160;&#160;Báo cáo tổng hợp doanh thu" Value="Báo cáo bán thuốc theo hóa đơn"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/TongHopGiaVon.aspx" Text="&#160;&#160;Báo cáo tổng hợp giá vốn" Value="Báo cáo bán thuốc theo hóa đơn"></asp:MenuItem>
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

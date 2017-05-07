<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_ketoanduoc.ascx.cs" Inherits="ketoan_menu_ketoanduoc" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="White">
    <Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="m_login"></asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="m_01"></asp:MenuItem>
        <asp:MenuItem  Text="Nhập/Xuất Kho" Value="m_thuchihd">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg"  NavigateUrl="~/ketoan/KT_PhieuNhapKho.aspx" Text="Phiếu Nhập Kho" Value="Thu chi hóa đơn"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg"  NavigateUrl="~/ketoan/phieuxuatkho3.aspx" Text="Phiếu Xuất Kho" Value="Thu chi hóa đơn"></asp:MenuItem>
            
            
        </asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="m_02"></asp:MenuItem>
        <asp:MenuItem  Text="Thu/chi khác" Value="m_thuchikh">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTM_ThuKhac.aspx" Text="&#160;&#160;Phiếu thu khác&#160;&#160;" Value="Thu/chi khác"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTM_PhieuChiKhac.aspx" Text="&#160;&#160;Phiếu chi khác&#160;&#160;" Value="Thu/chi khác"></asp:MenuItem>
            
        </asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="m_02"></asp:MenuItem>
        <asp:MenuItem  Text="Danh Mục" Value="m_thuchikh">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DMNghiepVu.aspx" Text="Danh Mục Nghiệp Vụ" Value="Thu/chi khác"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DMKhoanMucPhi.aspx" Text="Danh Mục Phí" Value="Thu/chi khác"></asp:MenuItem>
            
        </asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="m_03"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTM_DanhSachPhieuChi.aspx" Text="&#160;&#160;Danh sách phiếu chi&#160;&#160;" Value="Danh sách phiếu chi"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="m_03"></asp:MenuItem>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTM_DanhSachPhieuThuHoaDon.aspx" Text="&#160;&#160;Danh sách phiếu thu&#160;&#160;" Value="Danh sách phiếu thu "></asp:MenuItem>
        <asp:MenuItem Text="|" Value="m_03"></asp:MenuItem>
        <asp:MenuItem  Text="Báo cáo tiền mặt" Value="m_baocao">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTM_BaoCaoDoanhThu.aspx" Text="&#160;&#160;Báo cáo doanh thu" Value="BaoCaoDoanhThu"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/SoQuyTM.aspx" Text="&#160;&#160;Sổ quỹ tiền mặt" Value="Sổ quỹ tiền mặt"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/SoChiTietTK.aspx" Text="&#160;&#160;Sổ chi tiết tài khoản" Value="Sổ chi tiết tài khoản"></asp:MenuItem>
            <%-- <asp:MenuItem  ImageUrl="~/nhanbenh/i mages/nut.jpg" NavigateUrl="~/ketoan/SoCaiTH.aspx" Text="&#160;&#160;Sổ cái tổng hợp" Value="Sổ cái tổng hợp"></asp:MenuItem> --%>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/rptNhatKyThuTien.aspx" Text="&#160;&#160;Nhật ký thu tiền" Value="Nhật ký thu tiền"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/rptNhatKyChiTien.aspx" Text="&#160;&#160;Nhật ký chi tiền" Value="Nhật ký chi tiền"></asp:MenuItem>
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
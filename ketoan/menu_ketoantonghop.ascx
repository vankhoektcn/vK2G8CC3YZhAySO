<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_ketoantonghop.ascx.cs" Inherits="menu_ketoantonghop" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="#007138">
    <Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="m_login"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="m_01"></asp:MenuItem>
        <asp:MenuItem  Text="Chứng từ phát sinh" Value="m_phatsinh">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/ChungTuPhatSinh.aspx" Text="&#160;&#160;Chứng từ tổng hợp&#160;&#160;" Value="Chứng từ tổng hợp"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DanhSachChungTu.aspx" Text="&#160;&#160;Danh sách chứng từ&#160;&#160;" Value="Danh sách chứng từ"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="m_02"></asp:MenuItem>
        <asp:MenuItem  Text="Kết chuyển" Value="m_ketchuyen">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KCSoDuDauNam.aspx" Text="&#160;&#160;KC số dư đầu năm&#160;&#160;" Value="m_ketchuyen"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/CongThucKC.aspx" Text="&#160;&#160;Định nghĩa công thức KC&#160;&#160;" Value="m_ketchuyen"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DanhSachKC.aspx" Text="&#160;&#160;Danh sách KC&#160;&#160;" Value="m_ketchuyen"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="m_03"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DongBoSoLieu.aspx" Text="&#160;&#160;Đồng bộ số liệu&#160;&#160;" Value="m_dongbo"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="m_04"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/CanDoiKeToan.aspx" Text="&#160;&#160;Cân đối kế toán&#160;&#160;" Value="m_candoikt"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="m_06"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KetQuaKD.aspx" Text="&#160;&#160;KQ Hoạt động KD&#160;&#160;" Value="m_kqhdkd"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="m_05"></asp:MenuItem>
        <asp:MenuItem  Text="Báo cáo tổng hợp" Value="m_baocao">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/NhatKyChung.aspx" Text="&#160;&#160;Sổ nhật ký chung&#160;&#160;" Value="Sổ nhật ký chung"></asp:MenuItem>
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

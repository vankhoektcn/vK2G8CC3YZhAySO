<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_ketoannganhang.ascx.cs" Inherits="menu_ketoannganhang" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" ForeColor="White">
    <Items>
        <asp:MenuItem NavigateUrl="../ketoan/DanhMucTKNH.aspx" Text="Danh mục tài khoản NH" Value="Danh mục tài khoản NH"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  Text="Ủy nhiệm chi" Value="Ủy nhiệm chi">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTNH_UyNhiemChi.aspx" Text="&#160;&#160;Lập ủy nhiệm chi&#160;&#160;" Value="Lập ủy nhiệm chi"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTNH_DanhSachUyNhiemChi.aspx" Text="&#160;&#160;Danh sách ủy nhiệm chi&#160;&#160;" Value="Danh sách UNC"></asp:MenuItem>
        </asp:MenuItem>    
        <%--<asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  Text="Thu/chi hóa đơn" Value="Thu/chi hóa đơn">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/ThuChiHoaDonNH.aspx" Text="&#160;&#160;Thu chi có hóa đơn&#160;&#160;" Value="Thu chi có hóa đơn NH"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DanhSachThuChiNH.aspx" Text="&#160;&#160;Danh sách thu chi&#160;&#160;" Value="Danh sách thu chi"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  Text="Thu/chi khác" Value="Thu/chi khác">
            <%-- <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/thuphidichvuentryNH.aspx" Text="&#160;&#160;Thu/chi dịch vụ&#160;&#160;" Value="Thu/chi dịch vụ"></asp:MenuItem> --%>
            <%--<asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/tiepnhandoanhthuentryNH.aspx" Text="&#160;&#160;Thu/chi khác&#160;&#160;" Value="Thu/chi khác"></asp:MenuItem>
        </asp:MenuItem>--%>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  Text="Báo cáo ngân hàng" Value="Báo cáo ngân hàng">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/rptSoChiTietTKNH.aspx" Text="&#160;&#160;Sổ chi tiết tài khoản&#160;&#160;" Value="Sổ chi tiết tài khoản"></asp:MenuItem>
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

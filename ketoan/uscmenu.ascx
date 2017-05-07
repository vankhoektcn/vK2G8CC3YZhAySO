<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="nhanbenh_uscmenu" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False">
    <Items>
        <asp:MenuItem NavigateUrl="../login.aspx" Text="Đăng nhập" Value="Đăng nhập"></asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Hệ thống danh mục" Value="Hệ thống danh mục">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/dmtaikhoanketoan.aspx" Text="&#160;&#160;Danh mục tài khoản" Value="Danh mục tài khoản"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/ketoan/danhmuckho.aspx" Text=" Danh mục kho" Value="New Item 1" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/ketoan/nhacungcap.aspx" Text=" Danh mục nh&#224; cung cấp" Value="Danh mục nh&#224; cung cấp" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/ketoan/danhmuchangsanxuat.aspx" Text=" Danh mục h&#227;ng sản xuất" Value="Danh mục h&#227;ng sản xuất" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/ketoan/danhmucgroupthuoc.aspx" Text=" Danh mục loại thuốc" Value="New Item 1" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/ketoan/danhmucnhomthuoc.aspx" Text=" Danh mục nh&#243;m thuốc" Value="New Item 2" ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/ketoan/thuocadd.aspx" Text=" Danh mục t&#234;n thuốc" Value="New Item 1" ImageUrl="~/images/arrow2.gif" ></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Kế toán thu chi" Value="Kế toán thu chi">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/tiepnhandoanhthuentry.aspx"
                Text="&#160;&#160;Thu tiền dịch vụ" Value="Thu tiền dịch vụ">
            </asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/cackhoanchientry.aspx"
                Text="&#160;&#160;Quản l&#253; c&#225;c khoản chi ph&#237;&#160;&#160;" Value="Quản l&#253; c&#225;c khoản chi ph&#237;">
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Kế toán tài sản" Value="Kế toán tài sản">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/Danhmuctaisan.aspx" Text="&#160;&#160;Danh mục tài sản" Value="Danh mục tài sản"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/Khauhaotaisan.aspx" Text="&#160;&#160;Tính khấu hao tài sản" Value="Tính khấu hao tài sản">
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Kế toán xử lý" Value="Kế toán xử lý">
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/ketquadoanhthu.aspx" Text="&#160;&#160;Kết quả kinh doanh" Value="Kết quả kinh doanh">
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Kế toán quản trị" Value="Kế toán quản trị">
            <asp:MenuItem Text="&#160;&#160;Tổng hợp doanh thu theo phòng khoa" Value="Tiếp nhận" NavigateUrl="~/ketoan/thongketonghop.aspx"></asp:MenuItem>
            <asp:MenuItem Text="&#160;&#160;Chi tiết doanh thu theo phòng khoa" Value="Thu ph&#237; dịch vụ" NavigateUrl="~/ketoan/thongketonghopchitiet.aspx"></asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DoanhThuBH.aspx" Text="&#160;&#160;Báo cáo chi tiết tiền thu chi tại quỹ & chuyển khoản" Value="Báo cáo chi tiết tiền thu chi tại quỹ & chuyển khoản"></asp:MenuItem>            
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DoanhThuBH.aspx" Text="&#160;&#160;Báo cáo doanh thu bán hàng" Value="Báo cáo doanh thu bán hàng"></asp:MenuItem>            
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/Doanhthudoanhso.aspx" Text="&#160;&#160;Hệ thống biểu đồ biểu diễn doanh số bán & doanh thu" Value="Hệ thống biểu đồ biểu diễn doanh số bán & doanh thu"></asp:MenuItem>            
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BaoCaoDT_GV.aspx" Text="&#160;&#160;Báo cáo doanh thu bán hàng so với giá vốn" Value="Báo cáo doanh thu bán hàng so với giá vốn"></asp:MenuItem>            
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BaocaoTHdoanhthu.aspx" Text="&#160;&#160;Thống kê tổng hợp doanh thu" Value="Thống kê tổng hợp doanh thu"></asp:MenuItem>            
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BaocaoTHgiavon.aspx" Text="&#160;&#160;Thống kê tổng hợp giá vốn" Value="Thống kê tổng hợp giá vốn"></asp:MenuItem>            
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BaocaoTHchiphi.aspx" Text="&#160;&#160;Thống kê tổng hợp chi phí" Value="Thống kê tổng hợp chi phí"></asp:MenuItem>            
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Báo cáo tài chính" Value="Báo cáo tài chính">
           <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BangCanDoiKT.aspx" Text="&#160;&#160;Bảng cân đối kế toán" Value="Bảng cân đối kế toán"></asp:MenuItem>
           <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/LuuChuyenTienTe.aspx" Text="&#160;&#160;Báo cáo lưu chuyển tiền tệ đơn vị" Value="Báo cáo lưu chuyển tiền tệ đơn vị"></asp:MenuItem>
           <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/ThuyetMinhBCTC.aspx" Text="&#160;&#160;Thuyết minh báo cáo tài chính" Value="Thuyết minh báo cáo tài chính"></asp:MenuItem>
        </asp:MenuItem>
    </Items>
    <StaticMenuStyle HorizontalPadding="6px" VerticalPadding="1px" />
    <StaticHoverStyle BackColor="Control" />
    <LevelSubMenuStyles>
        <asp:SubMenuStyle Font-Underline="False" />
    </LevelSubMenuStyles>
    <DynamicMenuItemStyle ItemSpacing="1px" VerticalPadding="0px" />
    <DynamicItemTemplate>
        <%# Eval("Text") %>
    </DynamicItemTemplate>
    <StaticItemTemplate>
        <%# Eval("Text") %>
    </StaticItemTemplate>
</asp:Menu>

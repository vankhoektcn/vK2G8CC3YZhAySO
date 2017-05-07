<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_TaiSan.ascx.cs"
    Inherits="uscmenuKT_TaiSan" %>
<div class="sola">
    <div style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 22px; background-color: #FBF8F1;
        left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server"  Orientation="Horizontal">
            <Items>
                <asp:MenuItem Text="Quản Lý " Value="Quản Lý">
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_PhieuNhapVT3.aspx?dkmenu=kttscd"
                        Text="Phiếu Nhập Tài Sản" Value="nhaptaisan"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_PhieuXuatVT3.aspx?dkmenu=kttscd"
                        Text="Phiếu Xuất Tài Sản" Value="xuattaisan"></asp:MenuItem>
                    <%--<asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_TangGiamTaiSan.aspx?" Text="Phiếu tăng/giảm TSCĐ" Value="Tăng giảm tài sản cố định"></asp:MenuItem>--%>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_Khauhaotaisan.aspx"
                        Text="Khấu hao tài sản cố định" Value="Khấu hao tài sản cố định"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" Text="Phân Bổ TSCD " NavigateUrl="~/ketoan/KTTSCD_PhanBoTSCD.aspx"
                        Value="Phân bổ"></asp:MenuItem>
                </asp:MenuItem>
                <%--<asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" Text="Danh mục TSCD" NavigateUrl="~/ketoan/KTTSCD_DanhMucTSCD.aspx"
                    Value="Danh muc">                   
                </asp:MenuItem>--%>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <%--baocao--%>
                <asp:MenuItem Text="Báo Cáo-Danh Sách" Value="Bao cao">
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTVT_BaoCaoKhauHaoTSCD.aspx"
                        Text="Báo Cáo Khấu Hao TSCĐ" Value="BaoCaoKhauHaoTSCD"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTVT_BangTongHopNXT_VT.aspx"
                        Text="Tổng hợp nhập xuất tồn" Value="BangTongHopNXVT"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_rptDanhSachTSCD.aspx"
                        Text="Danh sách TSCĐ" Value="BangTongHopNXVT"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_rptMucTrichKHTSCD.aspx"
                        Text="Bảng đăng ký mức trích KHTSCĐ" Value="BangTongHopNXVT"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong">
                    <asp:MenuItem Text="Thay Đổi Mật Khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Trang Chủ Kế Toán" Value="trangchukt" NavigateUrl="~/ketoan/index1.aspx">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle Font-Bold="True" />
            <LevelSubMenuStyles>
                <asp:SubMenuStyle Font-Underline="False" Font-Size="12px" />
            </LevelSubMenuStyles>
            <DynamicItemTemplate>
                <%# Eval("Text") %>
            </DynamicItemTemplate>
            <StaticItemTemplate>
                <%# Eval("Text") %>
            </StaticItemTemplate>
            <DynamicMenuItemStyle CssClass="hovermenu" />
            <StaticMenuItemStyle CssClass="shovermenu" />
            <DynamicMenuStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" CssClass="hover" />
            <DynamicHoverStyle BorderColor="#666666" BackColor="#FBF8F1" BorderStyle="Solid"
                BorderWidth="1px" />
        </asp:Menu>
    </div>
</div>


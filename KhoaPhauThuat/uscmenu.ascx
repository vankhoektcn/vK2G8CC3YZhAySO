<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="khambenh_uscmenu" %>
<div class="sola">
    <div style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 22px; background-color: #FBF8F1;
        left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True"
            Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal"
            Height="21px" StaticEnableDefaultPopOutImage="False">
            <Items>
                <asp:MenuItem Text="Quản l&#253;" Value="Quan ly">
                    <asp:MenuItem NavigateUrl="~/KhoaPhauThuat/DanhSachBNDKKham.aspx?dkMenu=khoaphauthuat&IdKhoa=22"
                        Text="DSBN Nhập khoa" Value="DanhSachBNDKKham"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/KhoaPhauThuat/DanhSachBNDKKham.aspx?dkMenu=khoaphauthuat&IsHauPhau=1&IdKhoa=22"
                        Text="DSBN Đang theo d&#245;i" Value="DanhSachBNDieuTri"></asp:MenuItem>
                    <asp:MenuItem Text="Quản l&#253; tồn kho" Value="Quản l&#253; tồn kho">
                        <asp:MenuItem Text=" Khai báo số dư cuối kỳ" NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=khoaphauthuat&&idkhoa=22&idloainhap=3"
                            Value="soducuoiky"></asp:MenuItem>
                        <asp:MenuItem Text=" Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=khoaphauthuat&&idkhoa=22"
                            Value="kiemkho"></asp:MenuItem>
                        <asp:MenuItem Text=" Bảng giá thuốc/VTYT/HC " NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3.aspx?dkmenu=khoaphauthuat&idkhoa=22"
                            Value="kiemkho"></asp:MenuItem>
                        <asp:MenuItem Text="B&#225;o c&#225;o nhập xuất tồn" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_View3.aspx?dkmenu=khoaphauthuat&idkhoa=22"
                            Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                        <asp:MenuItem Text="Lập phiếu yêu cầu lãnh"  NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=khoaphauthuat&IdKhoa=22" ></asp:MenuItem>
                        <asp:MenuItem Text="Lập phiếu yêu cầu trả dư sử dụng"       NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoaphauthuat&IdKhoa=22">     </asp:MenuItem>
                        <asp:MenuItem Text="Lập phiếu yêu cầu trả do hỏng vỡ"       NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoaphauthuat&IdKhoa=22&IsHongVo=1">     </asp:MenuItem>
                        <asp:MenuItem Text="Phiếu xuất kho" Value="PHIEUXUATKHO" NavigateUrl="~/QLDUOC/Web/phieuxuatkho_XuatSD.aspx?dkmenu=khoaphauthuat&IdKhoa=22">
                        </asp:MenuItem>
                        <%--<asp:MenuItem Text="Tổng hợp y lệnh" Value="tonghopylenhphauthuat">--%>
                        <asp:MenuItem Text="Tổng hợp y lệnh" NavigateUrl="~/noitru_BaoCao/nvk_YLenhNgoaiTruTheoBN.aspx?dkmenu=khoaphauthuat&IdKhoa=22"
                            Value="YLenhPhauThuatTheoGiuong"></asp:MenuItem>
                        <%--<asp:MenuItem Text="Theo Giường" NavigateUrl="~/noitru_BaoCao/frpt_TongHopYLenh.aspx?dkmenu=khoaphauthuat&IdKhoa=22" Value="YLenhPhauThuatTheoBenhNhan">
                                    </asp:MenuItem>
                        </asp:MenuItem>--%>
                       
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Danh mục" Value="Danh mục">
                    <asp:MenuItem Text="Cận lâm sàng thường quy" NavigateUrl="~/DanhMuc_JSon/web/KB_NhomCLS3.aspx?dkMenu=khoaphauthuat"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    <asp:MenuItem Text="Toa thuốc mẫu" NavigateUrl="~/DanhMuc_JSon/web/ToaThuocMau3.aspx?dkMenu=khoaphauthuat"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    <asp:MenuItem Text="Cơ số tủ trực" Value="cosotutruc" NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?dkmenu=khoaphauthuat&IdKhoa=22">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="B&#225;o c&#225;o" Value="Bao cao">
                    <asp:MenuItem Text="Báo cáo 15 ngày sử dụng" Value="bc15" NavigateUrl="~/noitru_BaoCao/nvk_baoCaoSuDung15Ngay_new.aspx?dkmenu=khoaphauthuat&idkhoa=22">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong">
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx?dkMenu=kb">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="javascript:window.close();">
                    </asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <StaticMenuStyle HorizontalPadding="6px" VerticalPadding="1px" />
            <StaticMenuItemStyle CssClass="shovermenu" />
            <LevelSubMenuStyles>
                <asp:SubMenuStyle Font-Underline="False" />
            </LevelSubMenuStyles>
            <DynamicMenuItemStyle ItemSpacing="1px" VerticalPadding="0px" CssClass="hovermenu" />
            <DynamicItemTemplate>
                <%# Eval("Text") %>
            </DynamicItemTemplate>
            <StaticItemTemplate>
                <%# Eval("Text") %>
            </StaticItemTemplate>
            <DynamicMenuStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" CssClass="hover" />
            <DynamicHoverStyle BorderColor="#666666" BackColor="#FBF8F1" BorderStyle="Solid"
                BorderWidth="1px" />
        </asp:Menu>
    </div>
</div>

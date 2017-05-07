<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="khambenh_uscmenu" %>
<style type="text/css">
.hover
{
	z-index:1;
}
</style>
<div class="sola">
    <div style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 22px; background-color: #FBF8F1;
        left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True"
            Font-Names="Arial" Font-Size="Small" ItemWrap="True" Orientation="Horizontal"
            Height="21px" StaticEnableDefaultPopOutImage="False">
            <Items>
                <asp:MenuItem Text="Quản l&#253;" Value="Quan ly" Selectable="false">
                    <asp:MenuItem NavigateUrl="~/KhamBenh_TH/DanhSachBNDKKham.aspx?dkMenu=KhamBenh_TH"
                        Text="DSBN Chờ khám" Value="DanhSachBNDKKham"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/KhamBenh_TH/DanhSachBNDaKham.aspx?dkMenu=KhamBenh_TH"
                        Text="DSBN đ&#227; kh&#225;m" Value="DanhSachBNDaKham"></asp:MenuItem>
                    <asp:MenuItem Text="Quản l&#253; tồn kho" Value="Quản l&#253; tồn kho">
                        <asp:MenuItem Text="Khai báo số dư cuối kỳ" NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=KhamBenh_TH&IdKho=31&idloainhap=3"
                            Value="soducuoiky"></asp:MenuItem>
                        <asp:MenuItem Text="Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3.aspx?dkmenu=KhamBenh_TH&IdKho=31"
                            Value="kiemkho"></asp:MenuItem>
                        <asp:MenuItem Text="Phiếu xuất kho" Value="PHIEUXUATKHO" NavigateUrl="~/QLDUOC/Web/phieuxuatkho_XuatSD.aspx?dkmenu=KhamBenh_TH&IdKho=31&IsHangTuan=1">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Lập phiếu yêu cầu lãnh"  NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=KhamBenh_TH&IdKhoa=1"> </asp:MenuItem>
                        <asp:MenuItem Text="Lập phiếu yêu cầu trả dư sử dụng"       NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=KhamBenh_TH&IdKhoa=1">     </asp:MenuItem>
                        <asp:MenuItem Text="Lập phiếu yêu cầu trả do hỏng vỡ"       NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=KhamBenh_TH&IdKhoa=1&IsHongVo=1">     </asp:MenuItem>
                        <asp:MenuItem Text="B&#225;o c&#225;o nhập xuất tồn" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_View3.aspx?dkmenu=KhamBenh_TH&IdKho=31"
                            Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Khám đoàn" Value="khamdoan" Selectable="false">
                    <asp:MenuItem NavigateUrl="~/KhamBenhDoan/frm_DienThongTinKhamBenh.aspx?dkMenu=KhamBenh_TH"
                        Text="Phiếu khám sức khoẻ" Value="phieukhamsuckhoe"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/KhamBenhDoan/frmPhieuSo1.aspx?dkMenu=KhamBenh_TH"
                        Text="In phiếu khám đoàn" Value="inphieukhamdoan"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Danh mục" Value="Danh mục">
                    <asp:MenuItem Text="Cận lâm sàng thường quy" NavigateUrl="~/DanhMuc_JSon/web/KB_NhomCLS3.aspx?dkMenu=KhamBenh_TH"
                        Value="clsthuongquy"></asp:MenuItem>
                    <asp:MenuItem Text="Toa thuốc mẫu" NavigateUrl="~/DanhMuc_JSon/web/ToaThuocMau3.aspx?dkMenu=KhamBenh_TH"
                        Value="toathuocmau"></asp:MenuItem>
                    <asp:MenuItem Text="DM Thuốc ngoài BV" NavigateUrl="~/DanhMuc_JSon/web/Thuoc1.aspx?dkMenu=KhamBenh_TH&LoaiThuocID=1"
                        Value="thuocngoaibv"></asp:MenuItem>
                    <asp:MenuItem Text="Cơ số tủ trực" Value="cosotutruc" NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?dkmenu=KhamBenh_TH&IdKhoa=31">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="B&#225;o c&#225;o" Value="Bao cao">
                    <asp:MenuItem Text="Thống kê bệnh nhân đã khám" Value="change" NavigateUrl="~/KhamBenh_TH/frpt_DSBNDKham.aspx?dkMenu=KhamBenh_TH">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Báo cáo 15 ngày sử dụng" Value="bc15" NavigateUrl="~/QLDUOC/Web/zBaoCaoSuDung15Ngay.aspx?dkmenu=KhamBenh_TH&IdKhoa=1">
                    </asp:MenuItem>
                    <asp:MenuItem   NavigateUrl="~/KhamBenhDoan/frTongHopKQKhamSucKhoeTheoCty.aspx?dkMenu=KhamBenh_TH"
                        Text="Tổng hợp kết quả khám sức khoẻ" Value="ThongKe_DSBNTK" ></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
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

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu" %>
<style type="text/css">
    .hover
    {
        z-index:1;
    
    }
</style>
<div class="sola">
    <div style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 26px; background-color: #FBF8F1;
        left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto;">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false"
            Orientation="Horizontal" DynamicVerticalOffset="2" StaticEnableDefaultPopOutImage="False"
            OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem NavigateUrl="~/KhoaSan/nvk_NhapKhoaSan.aspx?dkmenu=khoasan&IdKhoa=3"
                    Text="&#160;&#160;Nhập khoa sản" Value="NhapKhoaSan"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru/nvk_KhamNoiTruTongHop.aspx?dkmenu=khoasan&IdKhoa=3"
                    Text="&#160;&#160;Khám nội trú sản" Value="khamtonghop" ImageUrl="../images/arrow2.gif">
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/frpt_TongHopYLenh.aspx?dkmenu=khoasan&IdKhoa=3"
                    Text="&#160;&#160;Tổng hợp y lệnh" Value="TọngHopYLenh"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=khoasan&IdKhoa=3&isTongHop=1"
                    Text="&#160;&#160;Tổng hợp BN trả thuốc" Value="TongHopTrathuocKhoaNoi"></asp:MenuItem>
                <%--<asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/noitru/nvk_KhamThuongQuyDienBien.aspx?dkmenu=khoasan&IdKhoa=3" Text="&#160;&#160;Bác sĩ khám bệnh" Value="CongKhamKhoaSan"></asp:MenuItem>--%>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Lập phiếu" Value="lapPhieu">
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=khoasan&IdKhoa=3"
                        Text="&#160;&#160;Lập phiếu YC lĩnh theo toa" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoasan&IdKhoa=3"
                        Text="&#160;&#160;Lập phiếu BN trả thuốc(thuốc, VTYT)" Value="rm_PhieuChuyenKho"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=khoasan&IdKhoa=3"
                        Text="&#160;&#160;Lập phiếu YC vật tư " Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoasan&IdKhoa=3&LoaiTra=2"
                        Text="&#160;&#160;Lập phiếu trả sử dụng thừa" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoasan&IdKhoa=3&LoaiTra=3"
                        Text="&#160;&#160;Lập phiếu yêu cầu chuyển trả" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Phiếu xuất kho" Value="PHIEUXUATKHO" NavigateUrl="~/QLDUOC/Web/phieuxuatkho_XuatSD.aspx?dkmenu=khoasan&IdKhoa=3">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Phiếu yêu cầu trả hỏng vỡ" Value="PHIEUXUATTRAHONGVO"
                        NavigateUrl="~/QLDUOC/Web/THUOC_YEUCAUTRAHONGVO3.aspx?dkmenu=khoasan&IdKhoa=3#isduyet=0">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Cơ số tủ trực" Value="cosotutruc" NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?dkmenu=khoasan&IdKhoa=3">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Danh mục" Value="Danh mục">
                    <asp:MenuItem Text=" Khai báo số dư cuối kỳ" NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=khoasan&IdKho=37&idloainhap=3"
                        Value="soducuoiky"></asp:MenuItem>
                    <asp:MenuItem Text=" Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=khoasan&IdKho=37"
                        Value="kiemkho"></asp:MenuItem>
                    <asp:MenuItem Text=" Bảng giá thuốc/VTYT/HC " NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=khoasan&IDKHO_NHAP=37"
                        Value="kiemkho"></asp:MenuItem>
                    <%--<asp:MenuItem NavigateUrl="~/noitru/frm_rpt_BangKeVienPhiTheoKhoa.aspx?idchitietdangkykham=64521" Text="&#160;&#160;Bảng kê theo khoa" Value="Danh mục địa chỉ"></asp:MenuItem>--%>
                    <asp:MenuItem Text="Cận lâm sàng thường quy" NavigateUrl="~/DanhMuc_JSon/web/KB_NhomCLS3.aspx?dkMenu=khoasan"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    <asp:MenuItem Text="Toa thuốc mẫu" NavigateUrl="~/DanhMuc_JSon/web/ToaThuocMau3.aspx?dkMenu=khoasan"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="B&#225;o c&#225;o" Value="Bao cao">
                    <asp:MenuItem Text="&#160;&#160;Báo cáo nhập xuất tồn" Value="NHAPXUATTON" NavigateUrl="../QLDUOC/Web/HS_TONKHO_View3.aspx?dkmenu=khoasan&idkhoa=3">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Bảng giá thuốc/VTYT/HC" Value="BANGGIATHUOC" NavigateUrl="../QLDUOC/Web/HS_BangGiaThuoc_View.aspx?dkmenu=khoasan&idkhoa=3">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoSuDung15Ngay_new.aspx?dkmenu=khoasan&idkhoa=3"
                        Text="&#160;&#160;Báo cáo 15 ngày thuốc, VTYT" Value="Phieu15NgayThuocVTYT" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=khoasan&IdKhoa=3"
                        Text="&#160;&#160;Báo cáo BN trả thuốc" Value="baocaoTrathuoccapCuu"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru/frmListKhamBenh_XuatKhoa.aspx?dkmenu=khoasan&idkhoa=3"
                        Text="&#160;&#160;Danh sách BN xuất khoa" Value="Danh sách "></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_giayChungNhanThuongTich.aspx?dkmenu=khoasan&IdKhoa=3"
                        Text="&#160;&#160;Giấy chứng nhận thương tích" Value="PhieuTraThuoc" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/KiemTraChiDinhThuoc.aspx?dkmenu=khoasan&idphongkhambenh=3"
                        Text="&#160;&#160;Kiểm chỉ định thuốc,vtyt." Value="kiemChiDinh" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <%--<asp:MenuItem NavigateUrl="~/noitru/frmListKhamBenh_NoiTru.aspx?dkmenu=khoasan&idkhoa=3" Text="&#160;&#160;Danh sách phiếu khám bệnh" Value="Danh sách phiếu khám bệnh"></asp:MenuItem>
                <asp:MenuItem Text="&#160;&#160;Bệnh án khoa sản" Value="KB" NavigateUrl="~/KhoaSan/danhSachBenhNhanNoiTru.aspx?dkmenu=khoasan&madichvu=12&idkhoa=3"> </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru/frm_rptBaoCaoKhamBenh.aspx?dkmenu=khoasan&idkhoa=3" Text="&#160;&#160;Báo cáo khám bệnh khoa sản" Value="BaoCao"></asp:MenuItem>     --%>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong">
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
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
            <StaticMenuItemStyle CssClass="hovermenu" />
            <DynamicMenuStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" CssClass="hover" />
            <DynamicHoverStyle BorderColor="#666666" BackColor="#FBF8F1" BorderStyle="Solid"
                BorderWidth="1px" />
        </asp:Menu>
    </div>
</div>

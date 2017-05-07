<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu_NgoaiSan.ascx.cs"
    Inherits="uscmenu_NgoaiSan" %>
<style type="text/css">
    .hover
    {
        z-index:1;
    
    }
</style>
<div class="sola" id="sola_nvk">
    <div id="nvkMenu" style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 26px;
        background-color: #FBF8F1; left: 0; border-bottom: 1px solid #666666;">
    </div>
    <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false"
        Orientation="Horizontal" DynamicVerticalOffset="2" StaticEnableDefaultPopOutImage="False"
        OnMenuItemClick="Menu1_MenuItemClick">
        <Items>
            <asp:MenuItem Text="Tiếp nhận" Value="TN" NavigateUrl="~/TiepNhan/TiepNhanBN.aspx?dkmenu=phongsanh&idkhoa=3">
            </asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem Text="Khám bệnh" Value="|">
                <asp:MenuItem NavigateUrl="~/KhamBenh_TH/DanhSachBNDKKham.aspx?dkMenu=uscmenu_NgoaiSan&IdKhoa=3"
                    Text="&#160;&#160;Bệnh nhân chờ khám" Value="Bệnh nhân chờ khám"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/KhamBenh_TH/DanhSachBNDaKham.aspx?dkMenu=uscmenu_NgoaiSan&IdKhoa=3"
                    Text="&#160;&#160;Bệnh nhân đã khám" Value="Bệnh nhân đã khám"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/KhoaSan/nvk_NhapKhoaSan.aspx?dkmenu=phongsanh&IdKhoa=3"
                Text="&#160;&#160;Nhập khoa sản" Value="Nhập khoa sản"></asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/noitru/DanhSachCongNoBenhNhan.aspx?dkmenu=phongsanh&idkhoa=3"
                Text="&#160;&#160;Tạm ứng" Value="Tạm ứng"></asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/KhoaSan/nvk_BenhNhanChoSanh.aspx?dkmenu=phongsanh&IdKhoa=3"
                Text="&#160;&#160;BN chờ sanh" Value="BN chờ sanh"></asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_YLenhNgoaiTruTheoBN.aspx?dkmenu=phongsanh&IdKhoa=3"
                Text="&#160;&#160;Tổng hợp y lệnh" Value="Tổng hợp y lệnh"></asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=phongsanh&IdKhoa=3"
                Text="&#160;&#160;Báo cáo BN trả thuốc" Value="baocaoTrathuoccapCuu"></asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem Text="Lập phiếu" Value="|">
                <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=phongsanh&IdKhoa=3"
                    Text="&#160;&#160;Lập phiếu YC lĩnh theo toa" Value="Lập phiếu YC lĩnh theo toa">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=phongsanh&IdKhoa=3"
                    Text="&#160;&#160;Lập phiếu BN trả thuốc(thuốc, VTYT)" Value="rm_PhieuChuyenKho"
                    ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=phongsanh&IdKhoa=3"
                    Text="&#160;&#160;Lập phiếu YC vật tư" Value="Lập phiếu YC vật tư"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=phongsanh&IdKhoa=3&LoaiTra=2"
                    Text="&#160;&#160;Lập phiếu trả sử dụng thừa" Value="Lập phiếu trả sử dụng thừa">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=phongsanh&IdKhoa=3&LoaiTra=3"
                    Text="&#160;&#160;Lập phiếu yêu cầu chuyển trả" Value="Lập phiếu yêu cầu chuyển trả">
                </asp:MenuItem>
                <asp:MenuItem Text="Phiếu xuất kho" Value="PHIEUXUATKHO" NavigateUrl="~/QLDUOC/Web/phieuxuatkho_XuatSD.aspx?dkmenu=phongsanh&IdKhoa=3">
                </asp:MenuItem>
                <asp:MenuItem Text="&#160;&#160;Phiếu yêu cầu trả hỏng vỡ" Value="PHIEUXUATTRAHONGVO"
                    NavigateUrl="~/QLDUOC/Web/THUOC_YEUCAUTRAHONGVO3.aspx?dkmenu=phongsanh&IdKhoa=3#isduyet=0">
                </asp:MenuItem>
                <asp:MenuItem Text="&#160;&#160;Cơ số tủ trực" Value="cosotutruc" NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?dkmenu=phongsanh&IdKhoa=3">
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem Text="Danh mục" Value="|">
                <asp:MenuItem NavigateUrl="~/KhoaSan/nvk_TienGiuongPhongSanh.aspx?dkmenu=phongsanh&IdKhoa=3"
                    Text="&#160;&#160;Tiền giường" Value="Tiền giường"></asp:MenuItem>
                <asp:MenuItem Text=" Khai báo số dư cuối kỳ" NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=phongsanh&IdKho=21&idloainhap=3"
                    Value="soducuoiky"></asp:MenuItem>
                <asp:MenuItem Text=" Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=phongsanh&IdKho=21"
                    Value="kiemkho"></asp:MenuItem>
                <asp:MenuItem Text="Cận lâm sàng thường quy" NavigateUrl="~/DanhMuc_JSon/web/KB_NhomCLS3.aspx?dkMenu=phongsanh"
                    Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                <asp:MenuItem Text="Toa thuốc mẫu" NavigateUrl="~/DanhMuc_JSon/web/ToaThuocMau3.aspx?dkMenu=phongsanh"
                    Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem Text="Báo cáo" Value="|">
                <asp:MenuItem Text="&#160;&#160;Báo cáo nhập xuất tồn" Value="NHAPXUATTON" NavigateUrl="../QLDUOC/Web/HS_TONKHO_View3.aspx?dkmenu=phongsanh&idkhoa=3">
                </asp:MenuItem>
                <asp:MenuItem Text="&#160;&#160;Bảng giá thuốc/VTYT/HC" Value="BANGGIATHUOC" NavigateUrl="../QLDUOC/Web/HS_BangGiaThuoc_View.aspx?dkmenu=phongsanh&idkhoa=3">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoSuDung15Ngay_new.aspx?dkmenu=phongsanh&idkhoa=3"
                    Text="&#160;&#160;Báo cáo 15 ngày thuốc, VTYT" Value="Phieu15NgayThuocVTYT" ImageUrl="../images/arrow2.gif">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru/frmListKhamBenh_XuatKhoa.aspx?dkmenu=phongsanh&idkhoa=3"
                    Text="&#160;&#160;Danh sách BN xuất khoa" Value="Danh sách BN xuất khoa"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_giayChungNhanThuongTich.aspx?dkmenu=phongsanh&IdKhoa=3"
                    Text="&#160;&#160;Giấy chứng nhận thương tích" Value="PhieuTraThuoc" ImageUrl="../images/arrow2.gif">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/KiemTraChiDinhThuoc.aspx?dkmenu=phongsanh&idphongkhambenh=3"
                    Text="&#160;&#160;Kiểm chỉ định thuốc,vtyt." Value="kiemChiDinh" ImageUrl="../images/arrow2.gif">
                </asp:MenuItem>
                <%--<asp:MenuItem NavigateUrl="~/KhoaSan/danhSachBenhNhanNoiTru.aspx?dkmenu=phongsanh&madichvu=12&idkhoa=3" Text="&#160;&#160;Danh sách phiếu khám bệnh" Value="Danh sách phiếu khám bệnh"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/KhoaSan/danhSachBenhNhanNoiTru.aspx?dkmenu=phongsanh&madichvu=12&idkhoa=3" Text="&#160;&#160;Bệnh án khoa sản" Value="Bệnh án khoa sản"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/noitru/frm_rptBaoCaoKhamBenh.aspx?dkmenu=phongsanh&idkhoa=3" Text="&#160;&#160;Báo cáo khám bệnh khoa sản" Value="Báo cáo khám bệnh khoa sản"></asp:MenuItem>--%>
            </asp:MenuItem>
            <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem Text="Hệ thống" Value="|">
                <asp:MenuItem NavigateUrl="~/QuanLyNguoiDung/changepass.aspx" Text="&#160;&#160;Thay đổi mật khẩu"
                    Value="Thay đổi mật khẩu"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/CloseTab.aspx" Text="&#160;&#160;Thoát" Value="Thoát"></asp:MenuItem>
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
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="CapCuu_uscmenu_NhanBenh" %>
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
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false"
            Orientation="Horizontal" DynamicVerticalOffset="2" StaticEnableDefaultPopOutImage="False"
            OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem NavigateUrl="~/KhoaSan/nvk_NhapKhoaSan.aspx?dkmenu=khoanoi&IdKhoa=4"
                    Text="&#160;&#160;Nhập khoa nội" Value="NhapKhoaSan"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru/nvk_KhamNoiTruTongHop.aspx?dkmenu=khoanoi&IdKhoa=4"
                    Text="&#160;&#160;Khám nội trú" Value="khamtonghop" ImageUrl="../images/arrow2.gif">
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/frpt_TongHopYLenh.aspx?dkmenu=khoanoi&IdKhoa=4"
                    Text="&#160;&#160;Tổng hợp y lệnh" Value="TọngHopYLenh"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <%--<asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_TongHopYLenh_Tra.aspx?dkmenu=khoanoi&IdKhoa=4" Text="&#160;&#160;Tổng hợp BN trả thuốc" Value="baocaoTrathuoccapCuu"> </asp:MenuItem>    --%>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=khoanoi&IdKhoa=4&isTongHop=1"
                    Text="&#160;&#160;Tổng hợp BN trả thuốc" Value="TongHopTrathuocKhoaNoi"></asp:MenuItem>
                <%--<asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/noitru/nvk_KhamThuongQuyDienBien.aspx?dkmenu=khoanoi&IdKhoa=4" Text="&#160;&#160;Công khám" Value="CongKhamKhoaNoi"></asp:MenuItem>--%>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Lập phiếu" Value="lapPhieu">
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=khoanoi&IdKhoa=4"
                        Text="&#160;&#160;Lập phiếu YC lĩnh theo toa" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoanoi&IdKhoa=4"
                        Text="&#160;&#160;Lập phiếu BN trả thuốc(thuốc, VTYT)" Value="rm_PhieuChuyenKho"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=khoanoi&IdKhoa=4"
                        Text="&#160;&#160;Lập phiếu YC vật tư " Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoanoi&IdKhoa=4&LoaiTra=2"
                        Text="&#160;&#160;Lập phiếu trả sử dụng thừa" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoanoi&IdKhoa=4&LoaiTra=3"
                        Text="&#160;&#160;Lập phiếu yêu cầu chuyển trả" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Phiếu xuất kho" Value="PHIEUXUATKHO" NavigateUrl="~/QLDUOC/Web/phieuxuatkho_XuatSD.aspx?dkmenu=khoanoi&IdKhoa=4">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Phiếu yêu cầu trả hỏng vỡ" Value="PHIEUXUATTRAHONGVO"
                        NavigateUrl="~/QLDUOC/Web/THUOC_YEUCAUTRAHONGVO3.aspx?dkmenu=khoanoi&IdKhoa=4#isduyet=0">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Danh mục" Value="Danh mục">
                    <asp:MenuItem NavigateUrl="~/QuanLyNguoiDung/dmGiuong.aspx?dkmenu=khoanoi&idkhoa=4"
                        Text="Danh mục giường" Value="Danh mục Giường"></asp:MenuItem>
                    <asp:MenuItem Text=" Khai báo số dư cuối kỳ" NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=khoanoi&IdKho=39&idloainhap=3"
                        Value="soducuoiky"></asp:MenuItem>
                    <asp:MenuItem Text=" Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=khoanoi&IdKho=39"
                        Value="kiemkho"></asp:MenuItem>
                    <asp:MenuItem Text=" Bảng giá thuốc/VTYT/HC " NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=khoanoi&IDKHO_NHAP=39"
                        Value="kiemkho"></asp:MenuItem>
                    <asp:MenuItem Text="Cận lâm sàng thường quy" NavigateUrl="~/DanhMuc_JSon/web/KB_NhomCLS3.aspx?dkMenu=khoanoi"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    <asp:MenuItem Text="Toa thuốc mẫu" NavigateUrl="~/DanhMuc_JSon/web/ToaThuocMau3.aspx?dkMenu=khoanoi"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    <asp:MenuItem Text="Cơ số tủ trực" Value="cosotutruc" NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?dkmenu=khoanoi&IdKhoa=4">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="B&#225;o c&#225;o" Value="Bao cao">
                    <asp:MenuItem Text="&#160;&#160;Báo cáo nhập xuất tồn" Value="NHAPXUATTON" NavigateUrl="../QLDUOC/Web/HS_TONKHO_View3.aspx?dkmenu=khoanoi&idkhoa=4">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Bảng giá thuốc/VTYT/HC" Value="BANGGIATHUOC" NavigateUrl="../QLDUOC/Web/HS_BangGiaThuoc_View.aspx?dkmenu=khoanoi&idkhoa=4">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoSuDung15Ngay_new.aspx?dkmenu=khoanoi&idkhoa=4"
                        Text="&#160;&#160;Báo cáo 15 ngày thuốc, VTYT" Value="Phieu15NgayThuocVTYT" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=khoanoi&IdKhoa=4"
                        Text="&#160;&#160;Báo cáo BN trả thuốc" Value="baocaoTrathuoccapCuu"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru/frmListKhamBenh_XuatKhoa.aspx?dkmenu=khoanoi&idkhoa=4"
                        Text="&#160;&#160;Danh sách BN xuất khoa" Value="Danh sách "></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_giayChungNhanThuongTich.aspx?dkmenu=khoanoi&IdKhoa=4"
                        Text="&#160;&#160;Giấy chứng nhận thương tích" Value="PhieuTraThuoc" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/KiemTraChiDinhThuoc.aspx?dkmenu=khoanoi&idphongkhambenh=4"
                        Text="&#160;&#160;Kiểm chỉ định thuốc,vtyt." Value="kiemChiDinh" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/zBaoCaoBNDieuTriNoitru1.aspx?dkmenu=khoanoi&IdKhoa=4"
                        Text="&#160;&#160;Báo cáo bệnh điều trị nội trú" Value="baocaobenhdieutrinoitru">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/zBaoCaoBNRaVienChuyenVien1.aspx?dkmenu=khoanoi&IdKhoa=4"
                        Text="&#160;&#160;Báo cáo ra viện - chuyển viện" Value="baocaoravienchuyenvien">
                    </asp:MenuItem>
                    <%-- <asp:MenuItem Text="&#160;&#160;Bệnh án khoa nội" Value="KB" NavigateUrl="~/khoanoi/danhSachBenhNhanNoiTru.aspx?dkmenu=khoanoi&idkhoa=4"> </asp:MenuItem>             
             <asp:MenuItem NavigateUrl="~/noitru/frm_rptBaoCaoKhamBenh.aspx?dkmenu=khoanoi&idkhoa=4" Text="&#160;&#160;Báo cáo nội trú" Value="BaoCao"></asp:MenuItem>     
             <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_PhieuDaYCTra.aspx?dkmenu=khoanoi" Text="&#160;&#160;DS phiếu y/c trả thuốc(thuốc, VTYT)" Value="PhieuTraThuoc" ImageUrl="../images/arrow2.gif"></asp:MenuItem>--%>
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

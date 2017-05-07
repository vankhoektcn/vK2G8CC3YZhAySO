<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="khoangoai_uscmenu_NhanBenh" %>
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
                <asp:MenuItem NavigateUrl="~/KhoaSan/nvk_NhapKhoaSan.aspx?dkmenu=khoangoai&IdKhoa=2"
                    Text="&#160;&#160;Nhập khoa ngoại" Value="NhapKhoaSan"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru/nvk_KhamNoiTruTongHop.aspx?dkmenu=khoangoai&IdKhoa=2"
                    Text="&#160;&#160;Khám nội trú" Value="khamtonghop" ImageUrl="../images/arrow2.gif">
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/frpt_TongHopYLenh.aspx?dkmenu=khoangoai&IdKhoa=2"
                    Text="&#160;&#160;Tổng hợp y lệnh" Value="TọngHopYLenh"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=khoangoai&IdKhoa=2&isTongHop=1"
                    Text="&#160;&#160;Tổng hợp BN trả thuốc" Value="TongHopTrathuocKhoaNoi"></asp:MenuItem>
                <%--<asp:MenuItem Text="|" Value="|"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/noitru/nvk_KhamThuongQuyDienBien.aspx?dkmenu=khoangoai&IdKhoa=2" Text="&#160;&#160;Công khám" Value="CongKhamKhoaNgoai"></asp:MenuItem>--%>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Lập phiếu" Value="lapPhieu">
                    <asp:MenuItem Text="Lập phiếu yêu cầu lãnh" NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=khoangoai&IdKhoa=2">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Lập phiếu yêu cầu trả dư sử dụng" NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoangoai&IdKhoa=2">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Lập phiếu yêu cầu trả do hỏng vỡ" NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoangoai&IdKhoa=2&IsHongVo=1">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Danh mục" Value="Danh mục">
                    <asp:MenuItem NavigateUrl="~/QuanLyNguoiDung/dmGiuong.aspx?dkmenu=khoangoai&idkhoa=2"
                        Text="&#160;&#160;Danh mục giường&#160;&#160;" Value="Danh mục Giường"></asp:MenuItem>
                    <asp:MenuItem Text=" Khai báo số dư cuối kỳ" NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=khoangoai&IdKho=38&idloainhap=3"
                        Value="soducuoiky"></asp:MenuItem>
                    <asp:MenuItem Text=" Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=khoangoai&IdKho=38"
                        Value="kiemkho"></asp:MenuItem>
                    <asp:MenuItem Text=" Bảng giá thuốc/VTYT/HC " NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=khoangoai&IDKHO_NHAP=4&IdLoaiThuoc=1"
                        Value="kiemkho"></asp:MenuItem>
                    <%--<asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_DM_Thuoc.aspx?dkmenu=khoangoai" Text="&#160;&#160;Danh mục thuốc" Value="Danh mục thuốc"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_DM_VTYT.aspx?dkmenu=khoangoai" Text="&#160;&#160;Danh mục VTYT" Value="Danh mục VTYT"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_DM_HoaChat.aspx?dkmenu=khoangoai" Text="&#160;&#160;Danh mục h&#243;a chất" Value="Danh mục h&#243;a chất"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="danhmucPKham.aspx" Text="&#160;&#160;Danh mục ph&#242;ng" Value="&#160;&#160;Danh mục ph&#242;ng"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="bacsientry.aspx" Text="&#160;&#160;Danh mục b&#225;c sĩ" Value="&#160;&#160;Danh mục b&#225;c sĩ"></asp:MenuItem>--%>
                    <asp:MenuItem Text="Cận lâm sàng thường quy" NavigateUrl="~/DanhMuc_JSon/web/KB_NhomCLS3.aspx?dkMenu=khoangoai"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    <asp:MenuItem Text="Toa thuốc mẫu" NavigateUrl="~/DanhMuc_JSon/web/ToaThuocMau3.aspx?dkMenu=khoangoai"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    <asp:MenuItem Text="Cơ số tủ trực" Value="cosotutruc" NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?dkmenu=khoangoai&IdKhoa=2">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="B&#225;o c&#225;o" Value="Bao cao">
                    <asp:MenuItem Text="&#160;&#160;Báo cáo nhập xuất tồn" Value="NHAPXUATTON" NavigateUrl="../QLDUOC/Web/HS_TONKHO_View3.aspx?dkmenu=khoangoai&idkhoa=2">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Bảng giá thuốc/VTYT/HC" Value="BANGGIATHUOC" NavigateUrl="../QLDUOC/Web/HS_BangGiaThuoc_View.aspx?dkmenu=khoangoai&idkhoa=2">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoSuDung15Ngay_new.aspx?dkmenu=khoangoai&idkhoa=2"
                        Text="&#160;&#160;Báo cáo 15 ngày thuốc, VTYT" Value="Phieu15NgayThuocVTYT" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=khoangoai&IdKhoa=2"
                        Text="&#160;&#160;Báo cáo BN trả thuốc" Value="baocaoTrathuoccapCuu"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru/frmListKhamBenh_XuatKhoa.aspx?dkmenu=khoangoai&idkhoa=2"
                        Text="&#160;&#160;Danh sách BN xuất khoa" Value="Danh sách "></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_giayChungNhanThuongTich.aspx?dkmenu=khoangoai&IdKhoa=2"
                        Text="&#160;&#160;Giấy chứng nhận thương tích" Value="PhieuTraThuoc" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/KiemTraChiDinhThuoc.aspx?dkmenu=khoangoai&idphongkhambenh=2"
                        Text="&#160;&#160;Kiểm chỉ định thuốc,vtyt." Value="kiemChiDinh" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/zBaoCaoBNDieuTriNoitru1.aspx?dkmenu=khoangoai&IdKhoa=2"
                        Text="&#160;&#160;Báo cáo bệnh điều trị nội trú" Value="baocaobenhdieutrinoitru">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/zBaoCaoBNRaVienChuyenVien1.aspx?dkmenu=khoangoai&IdKhoa=2"
                        Text="&#160;&#160;Báo cáo ra viện - chuyển viện" Value="baocaoravienchuyenvien">
                    </asp:MenuItem>
                    <%--<asp:MenuItem Text="&#160;&#160;Bệnh án khoa ngoại" Value="KB" NavigateUrl="~/khoanoi/danhSachBenhNhanNoiTru.aspx?dkmenu=khoangoai&idkhoa=2"> </asp:MenuItem>             
            <asp:MenuItem NavigateUrl="~/noitru/frm_rptBaoCaoKhamBenh.aspx?dkmenu=khoangoai&idkhoa=2" Text="&#160;&#160;Báo cáo nội trú" Value="BaoCao"></asp:MenuItem>     
             <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_PhieuDaYCTra.aspx?dkmenu=khoangoai" Text="&#160;&#160;DS phiếu y/c trả thuốc(thuốc, VTYT)" Value="PhieuTraThuoc" ImageUrl="../images/arrow2.gif"></asp:MenuItem>--%>
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

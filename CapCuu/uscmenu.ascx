<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="CapCuu_uscmenu_NhanBenh" %>
<div class="sola">
    <div style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 26px; background-color: #FBF8F1;
        left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false"
            Orientation="Horizontal" DynamicVerticalOffset="2" StaticEnableDefaultPopOutImage="False"
            OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem Text="&#160;&#160;Tiếp nhận" Value="TN" NavigateUrl="~/TiepNhan/TiepNhanBN.aspx?dkMenu=capcuu&idkhoa=15">
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/KhoaSan/nvk_NhapKhoaSan.aspx?dkmenu=capcuu&IdKhoa=15"
                    Text="&#160;&#160;Nhập chuyển cấp cứu" Value="NhapKhoaSan"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru/nvk_KhamNoiTruTongHop.aspx?dkmenu=capcuu&IdKhoa=15"
                    Text="&#160;&#160;Khám Cấp Cứu" Value="khamtonghop"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_YLenhNgoaiTruTheoBN.aspx?dkmenu=capcuu&IdKhoa=15"
                    Text="&#160;&#160;Báo cáo sử dụng thuốc" Value="baocaothuoccapCuu"></asp:MenuItem>
                <%--<asp:MenuItem Text="|" Value="|"></asp:MenuItem> <asp:MenuItem NavigateUrl="~/noitru/nvk_KhamThuongQuyDienBien.aspx?dkmenu=capcuu&IdKhoa=15" Text="&#160;&#160;Công khám" Value="CongKhamCapCuu"></asp:MenuItem>--%>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=capcuu&IdKhoa=15&isTongHop=1"
                    Text="&#160;&#160;Tổng hợp BN trả thuốc" Value="TongHopTrathuocKhoaNoi"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Lập phiếu" Value="lapPhieu">
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=capcuu&IdKhoa=15"
                        Text="Lập phiếu yêu cầu lãnh" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=capcuu&IdKhoa=15"
                        Text="Lập phiếu yêu cầu trả dư sử dụng" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=capcuu&IdKhoa=15&IsHongVo=1"
                        Text="Lập phiếu yêu cầu trả do hỏng vỡ" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Danh mục" Value="Danh mục">
                    <asp:MenuItem Text=" Khai báo số dư cuối kỳ" NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=capcuu&idkhoa=15&idloainhap=3"
                        Value="soducuoiky"></asp:MenuItem>
                    <asp:MenuItem Text=" Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=capcuu&idkhoa=15"
                        Value="kiemkho"></asp:MenuItem>
                    <asp:MenuItem Text="Cận lâm sàng thường quy" NavigateUrl="~/DanhMuc_JSon/web/KB_NhomCLS3.aspx?dkMenu=capcuu"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    <asp:MenuItem Text="Toa thuốc mẫu" NavigateUrl="~/DanhMuc_JSon/web/ToaThuocMau3.aspx?dkMenu=capcuu"
                        Value="B&#225;o c&#225;o nhập xuất tồn"></asp:MenuItem>
                    <asp:MenuItem Text="Cơ số tủ trực" Value="cosotutruc" NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?dkmenu=capcuu&IdKhoa=15">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="B&#225;o c&#225;o" Value="Bao cao">
                    <asp:MenuItem Text="&#160;&#160;Báo cáo nhập xuất tồn" Value="NHAPXUATTON" NavigateUrl="../QLDUOC/Web/HS_TONKHO_View3.aspx?dkmenu=capcuu&idkhoa=15">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Bảng giá thuốc/VTYT/HC" Value="BANGGIATHUOC" NavigateUrl="../QLDUOC/Web/HS_BangGiaThuoc_View.aspx?dkmenu=capcuu&idkhoa=15">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoSuDung15Ngay_new.aspx?dkmenu=capcuu&idkhoa=15"
                        Text="&#160;&#160;Báo cáo 15 ngày thuốc, VTYT" Value="Phieu15NgayThuocVTYT" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=capcuu&IdKhoa=15"
                        Text="&#160;&#160;Báo cáo BN trả thuốc" Value="baocaoTrathuoccapCuu"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru/frmListKhamBenh_XuatKhoa.aspx?dkmenu=capcuu&idkhoa=15"
                        Text="&#160;&#160;Danh sách BN xuất khoa" Value="Danh sách "></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/KiemTraChiDinhThuoc.aspx?dkmenu=capcuu&idphongkhambenh=15"
                        Text="&#160;&#160;Kiểm chỉ định thuốc,vtyt." Value="kiemChiDinh" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/HS_BenhNhanBHDongTien2.aspx?dkmenu=capcuu&idphongkhambenh=15"
                        Text="&#160;&#160;Danh sách bệnh nhân" Value="DSBNALL" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/zBaoCaoBNDieuTriNoitru1.aspx?dkmenu=capcuu&IdKhoa=15"
                        Text="&#160;&#160;Báo cáo bệnh điều trị cấp cứu" Value="baocaobenhdieutrinoitru">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/zBaoCaoBNRaVienChuyenVien1.aspx?capcuu=khoanoi&IdKhoa=15"
                        Text="&#160;&#160;Báo cáo ra viện - chuyển viện" Value="baocaoravienchuyenvien">
                    </asp:MenuItem>
                    <%--<asp:MenuItem NavigateUrl="~/noitru/frmListKhamBenh_NoiTru.aspx?dkmenu=capcuu&idkhoa=15"
                        Text="&#160;&#160;Danh sách phiếu khám bệnh" Value="Danh sách phiếu khám bệnh"></asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Bệnh án ngoại khoa&#160;&#160;" Value="KB" NavigateUrl="~/CapCuu/DanhSachBenhNhanNgoaiTru.aspx?dkmenu=capcuu&idkhoa=15">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Bệnh án nội khoa" Value="KB" NavigateUrl="~/CapCuu/danhSachBenhNhanNoiTru.aspx?dkmenu=capcuu&idkhoa=15">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru/frm_rptBaoCaoKhamBenh.aspx?dkmenu=capcuu&idkhoa=15"
                        Text="&#160;&#160;Báo cáo bệnh nhân khoa cấp cứu " Value="BaoCao"></asp:MenuItem>--%>
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

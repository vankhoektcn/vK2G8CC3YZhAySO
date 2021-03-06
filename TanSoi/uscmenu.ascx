﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="khoangoai_uscmenu_NhanBenh" %>
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
                <asp:MenuItem Text="Tiếp nhận" Value="TiepNhan">
                    <asp:MenuItem Text="&#160;&#160;Tiếp nhận" Value="TN" NavigateUrl="~/TiepNhan/TiepNhanBN.aspx?dkMenu=tansoi&idkhoa=25">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/KhoaSan/nvk_NhapKhoaSan.aspx?dkmenu=tansoi&IdKhoa=25"
                        Text="&#160;&#160;Nhập tán sỏi" Value="NhapTanSoi"></asp:MenuItem>
                    <%--<asp:MenuItem NavigateUrl="~/TanSoi/NVK_dsChoTaiKham.aspx?dkmenu=tansoi&idkhoa=25&MaKhoa=02&idphongban=43"
                        Text="&#160;&#160Bệnh nhân chờ tái khám" Value="NhapTanSoi"></asp:MenuItem>--%>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru/nvk_KhamNoiTruTongHop.aspx?dkmenu=tansoi&IdKhoa=25"
                    Text="&#160;&#160;Khám bệnh tán sỏi" Value="khamtonghop" ImageUrl="../images/arrow2.gif">
                </asp:MenuItem>
                <%--<asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru/NVK_HenTaiKham.aspx?dkmenu=tansoi&IdKhoa=25"
                    Text="&#160;&#160;Hẹn tái khám" Value="HenTaiKham"></asp:MenuItem>--%>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_YLenhNgoaiTruTheoBN.aspx?dkmenu=tansoi&IdKhoa=25"
                    Text="&#160;&#160;Tổng hợp y lệnh" Value="baocaothuocTanSoi"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=tansoi&IdKhoa=25&isTongHop=1"
                    Text="&#160;&#160;Tổng hợp BN trả thuốc" Value="TongHopTrathuocKhoaNoi"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Lập phiếu" Value="lapPhieu">
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=tansoi&IdKhoa=25"
                        Text="&#160;&#160;Lập phiếu YC lĩnh theo toa" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=tansoi&IdKhoa=25"
                        Text="&#160;&#160;Lập phiếu BN trả thuốc(thuốc, VTYT)" Value="rm_PhieuChuyenKho"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=tansoi&IdKhoa=25"
                        Text="&#160;&#160;Lập phiếu YC vật tư " Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=tansoi&IdKhoa=25&LoaiTra=2"
                        Text="&#160;&#160;Lập phiếu trả sử dụng thừa" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=tansoi&IdKhoa=25&LoaiTra=3"
                        Text="&#160;&#160;Lập phiếu yêu cầu chuyển trả" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Phiếu xuất kho" Value="PHIEUXUATKHO" NavigateUrl="~/QLDUOC/Web/phieuxuatkho_XuatSD.aspx?dkmenu=tansoi&IdKhoa=25">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="B&#225;o c&#225;o" Value="Bao cao">
                    <asp:MenuItem Text="&#160;&#160;Báo cáo nhập xuất tồn" Value="NHAPXUATTON" NavigateUrl="../QLDUOC/Web/HS_TONKHO_View3.aspx?dkmenu=tansoi&idkhoa=25">
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Bệnh nhân tán sỏi" Value="KB" NavigateUrl="~/khoanoi/danhSachBenhNhanNoiTru.aspx?dkmenu=tansoi&idkhoa=25">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoSuDung15Ngay_new.aspx?dkmenu=tansoi&idkhoa=25"
                        Text="&#160;&#160;Báo cáo 15 ngày thuốc, VTYT" Value="Phieu15NgayThuocVTYT" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/nvk_baoCaoTraThuoc.aspx?dkmenu=tansoi&IdKhoa=25"
                        Text="&#160;&#160;Báo cáo BN trả thuốc" Value="baocaoTrathuoccapCuu"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru/frmListKhamBenh_XuatKhoa.aspx?dkmenu=tansoi&idkhoa=25"
                        Text="&#160;&#160;Danh sách tán sỏi đã xuất" Value="Danh sách "></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru/frm_rptBaoCaoKhamBenh.aspx?dkmenu=tansoi&idkhoa=25"
                        Text="&#160;&#160;Báo cáo tán sỏi" Value="BaoCao"></asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;Bảng giá thuốc/VTYT/HC" Value="BANGGIATHUOC" NavigateUrl="../QLDUOC/Web/HS_BangGiaThuoc_View.aspx?dkmenu=tansoi&idkhoa=25">
                    </asp:MenuItem>
                    <asp:MenuItem Text=" Khai báo số dư cuối kỳ" NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=tansoi&IdKho=48&idloainhap=3"
                        Value="soducuoiky"></asp:MenuItem>
                    <asp:MenuItem Text=" Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=tansoi&IdKho=48"
                        Value="kiemkho"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/zBaoCaoBNDieuTriNoitru1.aspx?dkmenu=tansoi&IdKhoa=25"
                        Text="&#160;&#160;Báo cáo bệnh điều trị tán sỏi" Value="baocaobenhdieutrinoitru">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/zBaoCaoBNRaVienChuyenVien1.aspx?capcuu=tansoi&IdKhoa=25"
                        Text="&#160;&#160;Báo cáo ra viện - chuyển viện" Value="baocaoravienchuyenvien">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/KiemTraChiDinhThuoc.aspx?dkmenu=tansoi&idphongkhambenh=25"
                        Text="&#160;&#160;Kiểm chỉ định thuốc,vtyt." Value="kiemChiDinh" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
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

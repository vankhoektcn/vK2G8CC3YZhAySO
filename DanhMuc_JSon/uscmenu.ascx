<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu" %>
<div class="sola">
    <div style="position: absolute; z-index: -1000; top: 0; width: 100%; height: 26px;
        background-color: #FBF8F1; left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text="Người dùng" Value="NGUOIDUNG">
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/nguoidung2.aspx" Text="Người d&#249;ng"
                        Value="nguoidung" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/Permision2.aspx" Text="Danh mục chức năng"
                        Value="permission" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/PhanQuyen.aspx" Text="Phân quyền người dùng"
                        Value="systemright" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/DoiMatKhau.aspx" Text="Đổi mật khẩu"
                        Value="changepass" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text="Bác sĩ" Value="DMBACSI">
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/DanhMuc_Json/web/bacsi2.aspx"
                        Text="B&#225;c sĩ" Value="BACSI"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/DanhMuc_Json/web/Bacsi_PhongKham2.aspx"
                        Text="Phân khoa" Value="phankhoa"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/DanhMuc_Json/web/kb_phongkham2.aspx"
                        Text="Phân phòng" Value="phanphong"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text="Khoa / Phòng/ Bảng giá" Value="DMKHOAPHONG">
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/DMKhoa.aspx" Text="Khoa" Value="Khoa"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/DMNhomDVKT.aspx" Text="Nh&#243;m DVKT-CLS"
                        Value="nhomdvkt" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_Phong2.aspx" Text="Phòng khám" Value="phongkham"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/banggiadichvu_CK.aspx" Text="Bảng giá chuyên khoa"
                        Value="banggia" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/banggiadichvu_CLS.aspx" Text="Bảng giá dịch vụ cận lâm sàng"
                        Value="banggia" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/banggiadichvu_dvkt.aspx" Text="Bảng giá dịch vụ dịch vụ kĩ thuật"
                        Value="banggia" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/banggiadichvu_VC.aspx" Text="Bảng giá dịch vụ vận chuyển"
                        Value="banggia" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/banggiadichvu_KTC.aspx" Text="Bảng giá dịch vụ kĩ thuật cao"
                        Value="banggia" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/banggiadichvu2.aspx" Text="Bảng giá viện phí chung"
                        Value="banggia" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/HS_LOAIGiuong2.aspx" Text="Danh mục loại giường"
                        Value="giuong" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_Giuong2.aspx" Text="Danh mục giường"
                        Value="giuong" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/HS_BANGGIAGIUONG_LAN3.aspx" Text="Bảng giá giường"
                        Value="banggiagiuong" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/HS_BANGGIATHUOC3.aspx?dkmenu=DanhMuc_JSon" Text="Bảng gi&#225; thuốc &VTYT"
                        Value="BANGGIATHUOC"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text="Danh mục khác" Value="DMKHAC">
                <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_DOITUONGBH2.aspx" Text="Mức hưởng bảo hiểm"
                        Value="noidangkykcb" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_NOIDANGKYKB2.aspx" Text="Nơi đăng ký KCB"
                        Value="noidangkykcb" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/BenhVien2.aspx" Text="Bệnh viện" Value="benhvien"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/ChuongICD2.aspx" Text="Chương ICD"
                        Value="chuongicd" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/NhomICD2.aspx" Text="Nhóm ICD" Value="nhomicd"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/ChanDoanICD2.aspx" Text="Chẩn đoán ICD"
                        Value="chandoanicd" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/DMMayCLS2.aspx" Text="Máy CLS" Value="maycls"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_HuongDieuTri2.aspx" Text="Hướng điều trị"
                        Value="huongdieutri" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_LoaiBN2.aspx" Text="Loại bệnh nhân"
                        Value="loaibn" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_LoaiUutien2.aspx" Text="Loại ưu tiên"
                        Value="loaiuutien" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/dantoc2.aspx" Text="Dân tộc" Value="dantoc"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/NgheNghiep2.aspx" Text="Nghề nghiệp"
                        Value="nghenghiep" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/phuongxa2.aspx" Text="Phường /xã" Value="phuongxa"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/quanhuyen2.aspx" Text="Quận /huyện"
                        Value="quanhuyen" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/tinh2.aspx" Text="Tỉnh" Value="tinh"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/quoctich2.aspx" Text="Quốc tịch" Value="quoctich"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/ToaThuocMau3.aspx" Text="Toa thuốc mẫu"
                        Value="toathuocmau" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_NhomCLS3.aspx" Text="Nhóm CLS" Value="nhomcls"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_TinhTrangXuatKhoa2.aspx" Text="Tình trạng xuất khoa"
                        Value="xuatkhoa" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/KB_NHOMPHAUTHUAT3.aspx" Text="Phân nhóm phẫu thuật"
                        Value="nhomphauthuat" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/DMLoaiPhi2.aspx" Text="Loại phí" Value="loaiphi"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/KB_DONVITINH_DV2.aspx" Text="Đơn vị tính CLS-DV" Value="dvtdvkt"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Nhật ký hệ thống" Value="history" ImageUrl="../images/arrow2.gif">
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/KiemTraChiDinhThuoc.aspx?editHaoPhi=1" Value="edithaophi"
                        Text="Điều chỉnh hao phí, tính BH?" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/noitru_BaoCao/DieuChinhTreoThuoc.aspx" Value="edithaophi"
                        Text="Điều chỉnh treo YC" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_Json/web/zHistoryChange2.aspx" Value="benhnhan"
                        Text="Thay đổi bệnh nhân" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                   <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/HS_BenhNhanBHDongTien2.aspx" Value="HS_BENHNHANBHDONGTIEN"
                        Text="Danh sách bệnh nhân nội trú-ngoại trú" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong" Selectable="false">
                    <asp:MenuItem Text="Thông tin đơn vị" Value="thongtindonvi" NavigateUrl="~/DanhMuc_JSon/web/TieuDeCty.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Thoát" Value="thoat" NavigateUrl="javascript:window.close();"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
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
            <DynamicMenuStyle BorderStyle="Solid" BorderWidth="1px" CssClass="hover" />
            <DynamicHoverStyle BorderStyle="Solid" BorderWidth="1px" />
        </asp:Menu>
    </div>
</div>

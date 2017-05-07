<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_HeThong.ascx.cs"
    Inherits="menu_HeThong1" %>
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
        <asp:Menu ID="Menu1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="False"
            Orientation="Horizontal" StaticEnableDefaultPopOutImage="False" OnMenuItemDataBound="Menu1_MenuItemDataBound">
            <Items>
                <asp:MenuItem Text="Danh mục" Value="ND">
                    <asp:MenuItem NavigateUrl="~/DanhMuc/web/quoctich1.aspx?dkmenu=quanlyND" Text="Danh mục quốc tịch"
                        Value="quoctich"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc/web/dantoc1.aspx?dkmenu=quanlynd" Text="Danh mục dân tộc"
                        Value="dantoc"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc/web/nghenghiep1.aspx?dkmenu=quanlyND" Text="Danh mục nghề nghiệp"
                        Value="nghenghiep"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/nvkDanhMuc/web/BenhVien2.aspx?dkmenu=quanlyND" Text="Danh mục phí chuyển viện"
                        Value="nghenghiep"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc/web/ChanDoanICD1.aspx?dkmenu=quanlyND" Text="Danh mục chẩn đoán ICD"
                        Value="nghenghiep"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Khai b&#225;o người d&#249;ng" Value="ND">
                    <asp:MenuItem NavigateUrl="dm_nguoidung.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục người d&#249;ng&#160;&#160;"
                        Value="Danh mục người d&#249;ng"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="PhanQuyen.aspx?dkmenu=quanlyND" Text="&#160;&#160;Ph&#226;n quyền người d&#249;ng "
                        Value="Ph&#226;n quyền người d&#249;ng"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Khai b&#225;o b&#225;c sĩ" Value="BS">
                    <asp:MenuItem NavigateUrl="~\nhanbenh\phongkhambenhentry.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục khoa"
                        Value="DM phong kham"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~\nhanbenh\bacsientry.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục b&#225;c sĩ&#160;&#160;"
                        Value="DM bacsi"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/quanlynguoidung/PhongKham-BacSi.aspx?dkmenu=quanlyND"
                        Text="&#160;&#160;Ph&#226;n khoa kh&#225;m" Value="BSPK"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="danhmucPKham.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục ph&#242;ng kh&#225;m&#160;&#160;"
                        Value="danh muc KB_QuyenBaoHiem"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/quanlynguoidung/danhmucPhongKham.aspx?dkmenu=quanlyND"
                        Text="&#160;&#160;Ph&#226;n ph&#242;ng kh&#225;m" Value="  Ph&#226;n ph&#242;ng kh&#225;m">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QuanLyNguoiDung/DanhSachBNTrungTen.aspx?dkmenu=quanlyND"
                        Text="&#160;&#160;Bệnh nhân trùng tên,năm sinh..." Value="  Ph&#226;n ph&#242;ng kh&#225;m">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Khai b&#225;o hệ thống" Value="HT">
                    <asp:MenuItem NavigateUrl="~/nhanbenh/banggiadichvu2.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục dịch vụ&#160;&#160;"
                        Value="Danh mục người d&#249;ng"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QuanLyNguoiDung/dmGiuong.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục Giường&#160;&#160;"
                        Value="Danh mục Giường"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="NhomCLS.aspx?dkmenu=quanlyND" Text="&#160;&#160;Ph&#226;n bổ DV CLS v&#224;o nh&#243;m&#160;&#160;"
                        Value="Danh mục người d&#249;ng"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/nhanbenh/chandoanicd.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục chẩn đo&#225;n ICD10 &#160;&#160;"
                        Value="Chan doan"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/khambenh/thuoclist.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục thuốc&#160;&#160;"
                        Value="DM phong kham"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~\canlamsang\frm_thongsoXN.aspx?dkmenu=quanlyND" Text="&#160;&#160;Th&#244;ng số dịch vụ&#160;&#160; "
                        Value="DM triso"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="danhmucDTBH.aspx?dkmenu=quanlyND" Text="&#160;&#160;Đối tượng Bảo Hiểm&#160;&#160;"
                        Value="danh muc KB_QuyenBaoHiem"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="danhmucNDKBH.aspx?dkmenu=quanlyND" Text="&#160;&#160;Nơi đăng k&#253; Bảo Hiểm&#160;&#160;"
                        Value="danh muc KB_QuyenBaoHiem"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/nhanbenh/frmLoaiCLS.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục loại DV CLS&#160;&#160;"
                        Value="danh muc KB_QuyenBaoHiem"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/nhanbenh/diachi2.aspx?dkmenu=quanlyND" Text="&#160;&#160;Danh mục địa chỉ&#160;&#160;"
                        Value="danh muc diachi"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QuanLyNguoiDung/NguoiDung_Kho.aspx" Text="&#160;&#160;Danh mục người d&#249;ng v&#224; kho"
                        Value="&#160;&#160;Danh mục người d&#249;ng v&#224; kho"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QuanLyNguoiDung/NTH_NhomDichVu.aspx?dkmenu=quanlyND"
                        Text="Danh mục nhóm dịch vụ BHYT" Value="&#160;&#160;Danh mục người d&#249;ng v&#224; kho">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QuanLyNguoiDung/NTH_ChiTietNhomDichVu.aspx?dkmenu=quanlyND"
                        Text="Danh mục dịch vụ theo nhóm BHYT" Value="&#160;&#160;Danh mục người d&#249;ng v&#224; kho">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/nhanbenh/setphichuyenvien.aspx?dkmenu=quanlyND" Text="Danh mục Phí chuyển viện"
                        Value="Danh mục Phí chuyển viện"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong">
                    <asp:MenuItem NavigateUrl="NhapThongTinCty.aspx" Text="Th&#244;ng tin đơn vị&#160;&#160;"
                        Value="BSPK"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/KB_Parameter2.aspx?dkmenu=quanlyND" Text="Tham số hệ thống"
                        Value="Parameter"></asp:MenuItem>
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx?dkmenu=quanlyND">
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

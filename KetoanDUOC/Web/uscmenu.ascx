<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu" %>
<div class="sola">
    <div style="position: absolute; z-index: -1000; top: 0; width: 100%; height: 26px;
        background-color: #FBF8F1; left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false"
            Orientation="Horizontal" DynamicVerticalOffset="2" StaticEnableDefaultPopOutImage="False">
            <Items>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text=" Quản l&#253;" Value="QUANLY">
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/HS_TOATHUOC_View1.aspx" Text="Phiếu xuất theo toa"
                        Value="PHIEUXUATTHEOTOA" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieunhapkho3.aspx" Text=" Phiếu nhập mua" Value="PHIEUNHAPKHO"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieuxuatkho_XuatLe.aspx" Text=" Phiếu xuất kho ( Xuất cho KH lẻ )"
                        Value="PHIEUXUATLE" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieuxuatkho3.aspx" Text=" Phiếu xuất chuyển kho (Xuất cho c&#225;c khoa,P.P.T )"
                        Value="PHIEUXUATCHUYEN" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieuxuatkho_traNCC3.aspx?idkho=4&loaixuat=3" Text=" Phiếu xuất trả nh&#224; cung cấp"
                        Value="PHIEUXUATTRANHACUNGCAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text="Duyệt yêu cầu " Value="DUYETYEUCAU">
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="nvk_frmDuyetPhatTongHop.aspx"
                        Text=" Phát thuốc" Value="DUYETPHIEULINH"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="frm_DS_PhieuYCTra.aspx"
                        Text=" Danh sách phiếu yêu cầu trả(BN)" Value="DSPHIEUYEUCAUTRA_BN"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="nvk_frmNhanDu_TT.aspx"
                        Text=" Danh sách phiếu trả dư sử dụng" Value="DSPHIEUYEUCAUTRA_DU"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="nvk_frmDuyetYCChuyenKho_TT.aspx"
                        Text=" Danh sách phiếu Yêu cầu chuyển trả" Value="DSPHIEUYEUCAUTRA_TUTRUC"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/folder_documents.png" Text="Danh mục" Value="DANHMUC">
                    <asp:MenuItem NavigateUrl="frm_DM_Kho.aspx" Text=" Danh mục kho" Value="DMKHO" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="nhacungcap2.aspx" Text=" Danh mục nh&#224; cung cấp" Value="DMNHACUNGCAP"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="thuoc1.aspx?LoaiThuocID=1" Text=" Danh mục thuốc" Value="DMTHUOC"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="thuoc_hoachat1.aspx?LoaiThuocID=2" Text="Danh mục h&#243;a chất"
                        Value="DMHOACHAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="thuoc_vtyt1.aspx?LoaiThuocID=4" Text="Danh mục vật tư y tế"
                        Value="DMVATTUYTE" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/HS_BangGiaThuoc_Edit.aspx?dkmenu=ketoanduoc"
                        Text=" Cập nhật bảng giá" Value="suabanggia"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem ImageUrl="../images/chungtu.gif" Text=" B&#225;o c&#225;o" Value="BAOCAO">
                    <asp:MenuItem Text="B&#225;o c&#225;o nhập xuất tồn" Value="NHAPXUATTON">
                        <asp:MenuItem NavigateUrl="hS_TONKHO_View3.aspx" Text="B&#225;o c&#225;o tổng hợp xuất nhập tồn"
                            Value="TONGHOPNHAPXUATTON" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="frmTheKho.aspx" Text="B&#225;o c&#225;o chi tiết xuất nhập tồn(thẻ kho)"
                            Value="CHITIETNHAPXUATTON" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="frm_Rpt_BienBanKiemKe.aspx" Text="Bi&#234;n bản ki&#234;m k&#234;"
                            Value="BIENBANKIEMKE" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="frm_Rpt_BienBanKiemNhap.aspx" Text="Bi&#234;n bản kiểm nhập"
                            Value="BIENBANKIEMNHAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Danh s&#225;ch" Value="DANHSACH">
                        <asp:MenuItem NavigateUrl="phieunhapchuyenkho1.aspx" Text="Danh s&#225;ch phiếu nhập chuyển"
                            Value="DANHSACHPHIEUNHAPCHUYENKHO" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="phieunhapkho1.aspx?idkho=4&idloaithuoc=1" Text="Danh s&#225;ch phiếu nhập mua"
                            Value="DANHSACHPHIEUNHAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="chitietphieunhapkho1.aspx" Text="Chi tiết phiếu nhập"
                            Value="DANHSACHCHITIETPHIEUNHAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="phieuxuatkho1.aspx?idkho=4" Text="Danh s&#225;ch phiếu xuất"
                            Value="DANHSACHPHIEUXUAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="phieuxuatkho1_2.aspx?idkho2=4&idkho=5&loaixuat=4&IdLoaiThuoc=1"
                            Text="Danh s&#225;ch phiếu xuất trả khoa dược" Value="DANHSACHPHIEUTRAKHOADUOC">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="frmNhapXuatTonTongHop.aspx" Text="Danh s&#225;ch nhập xuất tổng hợp 2"
                            Value="DANHSACHPHIEUNHAPXUAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="hS_BangGiaThuoc_View.aspx?IDKHO_NHAP=4&IdLoaiThuoc=1"
                            Text="Bảng giá thuốc" Value="BANGGIATHUOC" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="hS_BangGiaThuoc_View.aspx?IDKHO_NHAP=5&IdLoaiThuoc=1"
                            Text="Bảng giá thuốc" Value="BANGGIATHUOC_BH" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="hS_TONKHO_Save3.aspx" Text="Kiểm & Điều chỉnh kho" Value="NHAPXUATTON2"
                            ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong">
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="CHANGEPASS" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Tho&#225;t" Value="EXIT" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
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

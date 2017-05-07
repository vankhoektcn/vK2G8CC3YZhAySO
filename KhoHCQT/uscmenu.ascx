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
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieunhapkho3.aspx?idloainhap=1&amp;IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                        Text=" Phiếu nhập mua" Value="PHIEUNHAPKHO" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieuxuatkho_XuatLe.aspx?IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                        Text=" Phiếu xuất kho ( Xuất cho KH lẻ )" Value="PHIEUXUATLE" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieuxuatkho3.aspx?IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                        Text=" Phiếu xuất chuyển kho (Xuất cho c&#225;c khoa,P.P.T )" Value="PHIEUXUATCHUYEN"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieuxuatkho_traNCC3.aspx?IdKho=40&amp;loaixuat=3&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                        Text=" Phiếu xuất trả nh&#224; cung cấp" Value="PHIEUXUATTRANHACUNGCAP" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="DUYETYEUCAU_"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text="Duyệt y&#234;u cầu " Value="DUYETYEUCAU">
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?IdKho=40&LoaiThuocID=3&dkmenu=KhoHCQT&idKhoDuyet=40"
                        Text="Duyệt yêu cầu lĩnh" Value="DUYETPHIEULINH"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=KhoHCQT&IdKho=40&LoaiThuocID=3"
                        Text="Duyệt nhận (khoa trả lại)" Value="DSPHIEUYEUCAUTRA_DU"></asp:MenuItem>
                    <%--<<asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/nvk_frmDuyetYCChuyenKho_TT.aspx?IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                        Text=" Danh s&#225;ch phiếu Y&#234;u cầu chuyển trả" Value="DSPHIEUYEUCAUTRA_TUTRUC">
                    </asp:MenuItem>--%>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/folder_documents.png" Text="Danh mục" Value="DANHMUC">
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/nhacungcap2.aspx?dkmenu=KhoHCQT" Text=" Danh mục nh&#224; cung cấp"
                        Value="DMNHACUNGCAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/frm_DM_NuocSX.aspx?dkmenu=KhoHCQT" Text=" Danh mục H&#227;ng SX"
                        Value="DMHANGSANXUAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/frm_DM_NuocSX.aspx?dkmenu=KhoHCQT" Text=" Danh mục Nước SX"
                        Value="DMNUOCSANXUAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/frm_DM_NhomThuoc.aspx?dkmenu=KhoHCQT" Text=" Danh mục nh&#243;m"
                        Value="DMNHOMTHUOC" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/thuoc_vtyt1.aspx?LoaiThuocID=3&dkmenu=KhoHCQT"
                        Text="Danh mục vật tư y tế" Value="DMVATTUYTE" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/frm_DM_DonViTinh.aspx?dkmenu=KhoHCQT"
                        Text="Danh mục đơn vị t&#237;nh" Value="DMDONVITINH"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?IdKho=40&LoaiThuocID=3&idloainhap=3&amp;dkmenu=KhoHCQT"
                        Text="Khai b&#225;o số dư cuối kỳ" Value="SODUCUOIKY" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem Text=" Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?IdKho=40&LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                        Value="kiemkho"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/frm_DM_DinhMucTonKho.aspx?IdKho=40&amp;dkmenu=KhoHCQT"
                        Text="Định mức tồn kho" Value="DINHMUCTONKHO"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem ImageUrl="../images/chungtu.gif" Text=" B&#225;o c&#225;o" Value="BAOCAO">
                    <asp:MenuItem Text="B&#225;o c&#225;o nhập xuất tồn" Value="NHAPXUATTON">
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/hS_TONKHO_View3.aspx?IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                            Text="B&#225;o c&#225;o tổng hợp xuất nhập tồn" Value="TONGHOPNHAPXUATTON" ImageUrl="../images/arrow2.gif">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/frmTheKho.aspx?IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                            Text="B&#225;o c&#225;o chi tiết xuất nhập tồn(thẻ kho)" Value="CHITIETNHAPXUATTON"
                            ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <%--<asp:MenuItem NavigateUrl="~/QLDUOC/Web/frm_Rpt_BienBanKiemKe.aspx?IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT" Text="Bi&#234;n bản ki&#234;m k&#234;"
                            Value="BIENBANKIEMKE" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/frm_Rpt_BienBanKiemNhap.aspx?IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT" Text="Bi&#234;n bản kiểm nhập"
                            Value="BIENBANKIEMNHAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>--%>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Danh s&#225;ch" Value="DANHSACH">
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieunhapkho1.aspx?IdKho=40&amp;idloaithuoc=4&amp;dkmenu=KhoHCQT"
                            Text="Danh s&#225;ch phiếu nhập mua" Value="DANHSACHPHIEUNHAP" ImageUrl="../images/arrow2.gif">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/chitietphieunhapkho1.aspx?IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                            Text="Chi tiết phiếu nhập" Value="DANHSACHCHITIETPHIEUNHAP" ImageUrl="../images/arrow2.gif">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieuxuatkho1.aspx?IdKho=40&amp;LoaiThuocID=3&dkmenu=KhoHCQT"
                            Text="Danh s&#225;ch phiếu xuất" Value="DANHSACHPHIEUXUAT" ImageUrl="../images/arrow2.gif">
                        </asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/phieuxuatkho1_2.aspx?IdKho2=40&amp;IdKho=25&amp;loaixuat=4&amp;LoaiThuocID=3&dkmenu=KhoHCQT"
                            Text="Danh s&#225;ch phiếu xuất trả" Value="DANHSACHPHIEUTRAKHOADUOC"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/frmNhapXuatTonTongHop.aspx?IdKho=40&amp;LoaiThuocID=3&amp;dkmenu=KhoHCQT"
                            Text="Danh s&#225;ch nhập xuất tổng hợp 2" Value="DANHSACHPHIEUNHAPXUAT" ImageUrl="../images/arrow2.gif">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/hS_BangGiaThuoc_View.aspx?IdKho_NHAP=40&amp;IdLoaiThuoc=4&amp;dkmenu=KhoHCQT"
                            Text="Bảng gi&#225;" Value="BANGGIATHUOC" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
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

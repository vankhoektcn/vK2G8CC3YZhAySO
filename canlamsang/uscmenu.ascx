<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="canlamsang_uscmenu" %>
<div class="sola">
    <div style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 22px; background-color: #FBF8F1;
        left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="False"
            Orientation="Horizontal" Height="21px" StaticEnableDefaultPopOutImage="False">
            <Items>
                <asp:MenuItem Text="Quản lý kết quả Xét Nghiệm" Value="QuanLyKetQuaXetNghiem" Selectable="false">
                    <asp:MenuItem Text="DSBN chờ Xét Nghiệm" NavigateUrl="~/DanhMuc_JSon/web/zDSChoCanLamSang1.aspx?dkmenu=cls&IdKhoa=31"
                        Value="dschoxetnghiem"> </asp:MenuItem>
                    <asp:MenuItem Text="DS kết quả Xét Nghiệm" NavigateUrl="~/DanhMuc_JSon/web/zDSChoCanLamSang1.aspx?dkmenu=cls&IdKhoa=31&isDaCLS=1"
                        Value="dsketquaxetnghiem"> </asp:MenuItem>
                    <%--<asp:MenuItem NavigateUrl="~/canlamsang/benhnhanDaKhamCLS.aspx?dkmenu=cls" Text="DS kết quả Xét Nghiệm"
                        Value="dsketquaxetnghiem"></asp:MenuItem>--%>
                    <asp:MenuItem Text="DS phiếu hẹn" NavigateUrl="~/canlamsang/listBNHenTraKQ.aspx?dkmenu=cls"
                        Value="dsphieuhen"></asp:MenuItem>
                    <asp:MenuItem Text="Báo cáo tổng hợp xét nghiệm" NavigateUrl="~/canlamsang/BaoCaoTongHopXetNghiem.aspx?dkmenu=cls"
                         Value="baocaotonghopxetnghiem"></asp:MenuItem>
                    <asp:MenuItem Text="Báo cáo tổng hợp chẩn đoán hình ảnh" NavigateUrl="~/canlamsang/BaoCaoTongHopCDHA.aspx?dkmenu=cls"  
                        Value="baocaotonghopchandoanhinhanh"> </asp:MenuItem>
                        <asp:MenuItem Text="Báo cáo 15 ngày sử dụng" Value="15ngaysudung_XN" NavigateUrl="~/QLDUOC/Web/zBaoCaoSuDung15Ngay.aspx?dkmenu=cls&IdKhoa=31">
                        </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Quản lý tồn kho" Value="QuanLyTonKho" Selectable="false">
                        <asp:MenuItem Text="Phiếu yêu cầu lãnh" Value="Yeucaulanh"  NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=cls">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Phiếu yêu cầu trả" Value="YeuCauTra"  NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=cls">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Phiếu xuất kho" Value="PHIEUXUATKHO" NavigateUrl="~/QLDUOC/Web/phieuxuatkho_XuatSD.aspx?dkmenu=cls&IsHangTuan=1">
                        </asp:MenuItem>
                        <asp:MenuItem Text="DS phiếu xuất" Value="DSPhieuXuat" NavigateUrl="~/QLDUOC/Web/phieuxuatkho1.aspx?dkmenu=cls&IdKho=6">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Báo cáo tổng hợp nhập xuất tồn" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_View3.aspx?dkmenu=cls"
                            Value="baocaonxt"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDuoc/web/frmNhapXuatTonTongHop.aspx?dkmenu=cls" Text="Chi tiết nhập xuất tồn "
                            Value="DANHSACHPHIEUNHAPXUAT" ></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?dkmenu=cls&IdKhoa=3" Text="Cơ số tủ trực" Value="SoSoTuTruc">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Khai báo số dư cuối kỳ" NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=cls"
                            Value="soducuoiky"></asp:MenuItem>
                        <asp:MenuItem Text="Kiểm & Điều chỉnh kho" NavigateUrl="~/QLDUOC/Web/HS_TONKHO_Save3_new.aspx?dkmenu=cls"
                            Value="kiemkho"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/thuoc_hoachat1.aspx?dkmenu=cls&LoaiThuocID=2"
                        Text="Danh mục hóa chất" Value="DMHOACHAT" > </asp:MenuItem>
                        <%--<asp:MenuItem Text="Báo cáo hao phí" NavigateUrl="~/QLDUOC/Web/frmThuocHaoPhi.aspx?dkmenu=cls"
                            Value="baocaohaophi"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDuoc/web/frmBaoCaoChiDinhThuoc.aspx?dkmenu=cls" Text="Báo cáo chỉ định thuốc"
                            Value="BAOCAOCHIDINHTHUOC" ></asp:MenuItem>--%>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong" Selectable="false">
                    <asp:MenuItem Text="Đổi mật khẩu" Value="DoiMatKhau" NavigateUrl="~/DanhMuc_JSon/web/DoiMatKhau.aspx?dkmenu=cls">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="javascript:window.close();">
                    </asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle Font-Bold="true" />
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
            <DynamicMenuStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
            <DynamicHoverStyle BorderColor="#666666" BackColor="#FBF8F1" BorderStyle="Solid"
                BorderWidth="1px" />
        </asp:Menu>
    </div>
</div>

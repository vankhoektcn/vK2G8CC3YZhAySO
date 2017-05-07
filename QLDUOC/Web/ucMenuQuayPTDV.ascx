<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMenuQuayPTDV.ascx.cs" Inherits="ucMenuQuayPTDV" %>
<div class="sola">
    <div style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 22px; background-color: #FBF8F1;
        left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false"
            Orientation="Horizontal" DynamicVerticalOffset="2" StaticEnableDefaultPopOutImage="False">
            <Items>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text=" Quản lý" Value="QUANLY" Selectable="false" >
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/HS_TOATHUOC_View1.aspx?dkmenu=quayptdv&IdKho=6" Text="BN có thuốc - chờ phát"
                        Value="PHIEUXUATTHEOTOA" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieunhapkho3_dieuchinh.aspx?dkmenu=quayptdv&idloainhap=5" Text=" Phiếu nhập điều chỉnh"
                        Value="PHIEUNHAPKHO" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieuxuatkho_HV3.aspx?dkmenu=quayptdv" Text=" Phiếu thanh lý hỏng vỡ"
                        Value="PHIEUTHANHLYHONGVO"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=quayptdv&IdKhoa=101"
                        Text=" Phiếu yêu cầu lãnh thuốc" Value="PHIEUYCLANH"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=quayptdv&IdKhoa=101&LoaiTra=3"
                        Text=" Phiếu yêu cầu trả thuốc" Value="PHIEUYCTRA"></asp:MenuItem>
                    <asp:MenuItem Text=" Phiếu nhập hỏng vỡ" Value="PHIEUNHAPHONGVO" NavigateUrl="~/QLDUOC/Web/phieuxuatkho3.aspx?dkmenu=quayptdv&IdKho2=51">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/folder_documents.png" Text="Danh mục" Value="DANHMUC" Selectable="false">
                    <asp:MenuItem NavigateUrl="thuoc1.aspx?dkmenu=quayptdv&LoaiThuocID=1&IsQPTDV=1" Text=" Danh mục thuốc"
                        Value="DMTHUOC_QPTBH" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?dkmenu=quayptdv&idloainhap=3" Text="Khai báo số dư cuối kỳ"
                        Value="SODUCUOIKY" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/hS_TONKHO_Save3_new.aspx?dkmenu=quayptdv" Text="Kiểm & điều chỉnh kho"
                        Value="NHAPXUATTON2" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="frm_DM_DinhMucTonKho.aspx?dkmenu=quayptdv"
                        Text="Định mức tồn kho" Value="DINHMUCTONKHO"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?dkmenu=quayptdv&idkho=6" Text=" Cơ số tủ trực"
                        Value="COSOTUTRUC"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/HS_THUOCNHOM2.aspx?dkmenu=quayptdv"
                        Text=" Phân bổ nhóm thuốc" Value="THUOC_PHANNHOM"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem ImageUrl="../images/chungtu.gif" Text=" Báo cáo" Value="BAOCAO" Selectable="false">
                    <asp:MenuItem Text="Báo cáo nhập xuất tồn" Value="NHAPXUATTON" Selectable="false">
                        <asp:MenuItem NavigateUrl="hS_TONKHO_View3.aspx?dkmenu=quayptdv" Text="Báo cáo nhập xuất tồn tổng hợp"
                            Value="TONGHOPNHAPXUATTON" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="frmTheKho.aspx?dkmenu=quayptdv&IdKho=6" Text="Báo cáo chi tiết nhập xuất tồn (thẻ kho)"
                            Value="CHITIETNHAPXUATTON_QPT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/zDanhSachThuocSapHetHan3.aspx?dkmenu=quayptdv"
                            Text="Danh sách thuốc sắp hết hạn" Value="DANHSACHTHUOCSAPHETHAN"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Danh sách" Value="DANHSACH" Selectable="false">
                        <asp:MenuItem NavigateUrl="phieunhapchuyenkho1.aspx?dkmenu=quayptdv" Text="Danh sách phiếu nhập chuyển"
                            Value="DANHSACHPHIEUNHAPCHUYENKHO" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="phieuxuatkho1_2.aspx?dkmenu=quayptdv&idkho2=4&idkho=6&loaixuat=4&IdLoaiThuoc=1"
                            Text="Danh sách phiếu xuất trả khoa Dược" Value="DANHSACHPHIEUTRAKHOADUOC">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="HS_TOATHUOC_View1.aspx?dkmenu=quayptdv&IsDaXuat=1&IdKho=6" Text="BN có thuốc - đã phát"
                            Value="DANHSACHTOATHUOCDACAPPHAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem Text="Danh sách phiếu nhập hỏng vỡ" Value="DSPHIEUNHAPHONGVO"
                            NavigateUrl="~/QLDUOC/Web/phieuxuatkho1.aspx?dkmenu=quayptdv&IdKho2=51"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieuxuatkho_HV1.aspx?dkmenu=quayptdv" Text="Danh sách phiếu thanh lý hỏng vỡ"
                            Value="DSPHIEUTHANHLYHONGVO"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Hệ thống" Value="hethong" Selectable="false">
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="CHANGEPASS" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx?dkmenu=quayptdv">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Thoát" Value="EXIT" NavigateUrl="javascript:window.close();"></asp:MenuItem>
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

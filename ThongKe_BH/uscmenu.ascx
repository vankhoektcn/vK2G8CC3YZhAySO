<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="nhanbenh_uscmenu" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="90%" ItemWrap="True" Orientation="Horizontal"  Height = "21px" StaticEnableDefaultPopOutImage="False" Width="100%">
    <Items>
        <asp:MenuItem Text="Ph&#242;ng T&#224;i Ch&#237;nh Kế To&#225;n" Value="|">
            <asp:MenuItem Text="Sổ nhật k&#253; thu ph&#237; v&#224; lệ ph&#237;" Value="Sổ nhật k&#253; thu ph&#237; v&#224; lệ ph&#237;" NavigateUrl="~/thongke/thongke/rpt_ThuPhi_LePhi.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/rpt_ThuPhi_LePhi_DichVu.aspx" Text="Sổ nhật k&#253; thu ph&#237; dịch vụ"
                Value="Sổ nhật k&#253; thu ph&#237; dịch vụ"></asp:MenuItem>
            <asp:MenuItem Text="Bảng tổng hợp h&#243;a đơn thu tiền dịch vụ" Value="Bảng tổng hợp h&#243;a đơn thu tiền dịch vụ" NavigateUrl="~/thongke/thongke/rpt_TongHopHDThuTienDV.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Bảng tổng hợp bi&#234;n lai thu ph&#237; v&#224; lệ ph&#237;"
                Value="Bảng tổng hợp bi&#234;n lai thu ph&#237; v&#224; lệ ph&#237;" NavigateUrl="~/thongke/thongke/rpt_TongHopBienLaiThuPhi_LePhi.aspx?dkMenu=thongke"></asp:MenuItem>
            <asp:MenuItem Text="Bảng k&#234; chi tiết phiếu thu tạm ứng viện ph&#237;" Value="Bảng k&#234; chi tiết phiếu thu tạm ứng viện ph&#237;" NavigateUrl="~/thongke/thongke/rpt_PhieuThuTamUng.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Bảng k&#234; chi tiết ho&#224;n trả tạm ứng viện ph&#237;" Value="Bảng k&#234; chi tiết ho&#224;n trả tạm ứng viện ph&#237;" NavigateUrl="~/thongke/thongke/rpt_ChiTietHoanTraTamUng.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/frmRPT_TH_BHYT.aspx?dkMenu=thongke" Text="Danh s&#225;ch đề nghị thanh to&#225;n BHYT"
                Value="Danh s&#225;ch đề nghị thanh to&#225;n BHYT"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/rpt_TongHopBHYTNgoaiTru.aspx?dkMenu=thongke" Text="Tổng hợp thanh to&#225;n chữa bệnh BHYT ngoại tr&#250;"
                Value="Tổng hợp thanh to&#225;n chữa bệnh BHYT ngoại tr&#250;"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/rpt_TongHopKCBNoiiTru.aspx?dkMenu=thongke" Text="Tổng hợp thanh to&#225;n chữa bệnh BHYT nội tr&#250;"
                Value="Tổng hợp thanh to&#225;n chữa bệnh BHYT nội tr&#250;"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/Crpt_BaoCaoThatThu.aspx?dkMenu=thongke" Text="Tổng hợp danh s&#225;ch thất thu"
                Value="Tổng hợp thanh to&#225;n chữa bệnh BHYT nội tr&#250;"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Ph&#242;ng Thu Viện Ph&#237; " Value="Phong Thu Viện Ph&#237; ">
            <asp:MenuItem Text="Danh s&#225;ch bệnh nh&#226;n ngoại tr&#250;" Value="Danh s&#225;ch bệnh nh&#226;n ngoại tr&#250;" NavigateUrl="~/thongke/thongke/DSbenhnhanngoaitru.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Danh s&#225;ch bệnh nh&#226;n nội tr&#250;" Value="Danh s&#225;ch bệnh nh&#226;n nội tr&#250;" NavigateUrl="~/thongke/thongke/DSBNnamvien.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Danh s&#225;ch bệnh CLS" Value="Danh s&#225;ch bệnh CLS" NavigateUrl="~/thongke/thongke/DSbenhnhanCLS.aspx?dkMenu=thongke"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/DSbenhnhanBH.aspx?dkMenu=thongke" Text="Danh s&#225;ch bệnh nh&#226;n c&#243; BHYT"
                Value="Danh s&#225;ch bệnh nh&#226;n c&#243; BHYT"></asp:MenuItem>
            <asp:MenuItem Text="Tờ khai chi tiết bi&#234;n lai thu tiền ph&#237;,lệ ph&#237;"
                Value="Tờ khai chi tiết bi&#234;n lai thu tiền ph&#237;,lệ ph&#237;" NavigateUrl="~/thongke/thongke/rpt_ChiTietBienLaiThuPhi.aspx?dkMenu=thongke"></asp:MenuItem>
            <%--<asp:MenuItem Text="Tờ khai chi tiết phiếu thu dịch vụ" Value="Tờ khai chi tiết phiếu thu dịch vụ" NavigateUrl="~/thongke/thongke/rpt_ChiTietThuDichVu.aspx?dkMenu=thongke">
            </asp:MenuItem>--%>
            <asp:MenuItem Text="Bảng k&#234; chi tiết phiếu thu tạm ứng viện ph&#237;"
                Value="Bảng k&#234; chi tiết ho&#224;n trả chi tiết phiếu thu tạm ứng viện ph&#237;" NavigateUrl="~/thongke/thongke/rpt_PhieuThuTamUng.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Bảng k&#234; chi tiết ho&#224;n trả tạm ứng" Value="Bảng k&#234; chi tiết ho&#224;n trả tạm ứng" NavigateUrl="~/thongke/thongke/rpt_ChiTietHoanTraTamUng.aspx?dkMenu=thongke">
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Ph&#242;ng Thu Dịch Vụ" Value="Ph&#242;ng Thu Dịch Vụ">
            <asp:MenuItem Text="Danh s&#225;ch bệnh nh&#226;n ngoại tr&#250;" Value="Danh s&#225;ch bệnh nh&#226;n ngoại tr&#250;" NavigateUrl="~/thongke/thongke/DSbenhnhanngoaitru.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Danh s&#225;ch bệnh nh&#226;n nội tr&#250;" Value="Danh s&#225;ch bệnh nh&#226;n nội tr&#250;" NavigateUrl="~/thongke/thongke/DSBNnamvien.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Danh s&#225;ch bệnh CLS" Value="Danh s&#225;ch bệnh CLS" NavigateUrl="~/thongke/thongke/DSbenhnhanCLS.aspx?dkMenu=thongke"></asp:MenuItem>
            <asp:MenuItem Text="Tờ khai chi tiết bi&#234;n lai thu tiền ph&#237;,lệ ph&#237;"
                Value="Tờ khai chi tiết bi&#234;n lai thu tiền ph&#237;,lệ ph&#237;" NavigateUrl="~/thongke/thongke/rpt_ChiTietBienLaiThuPhi.aspx?dkMenu=thongke"></asp:MenuItem>
            <asp:MenuItem Text="Tờ khai chi tiết phiếu thu dịch vụ" Value="Tờ khai chi tiết phiếu thu dịch vụ" NavigateUrl="~/thongke/thongke/rpt_ChiTietThuDichVu.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Bảng k&#234; chi tiết phiếu thu tạm ứng viện ph&#237;"
                Value="Bảng k&#234; chi tiết ho&#224;n trả chi tiết phiếu thu tạm ứng viện ph&#237;" NavigateUrl="~/thongke/thongke/rpt_PhieuThuTamUng.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Bảng k&#234; chi tiết ho&#224;n trả tạm ứng" Value="Bảng k&#234; chi tiết ho&#224;n trả tạm ứng" NavigateUrl="~/thongke/thongke/rpt_ChiTietHoanTraTamUng.aspx?dkMenu=thongke">
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Thống k&#234; tổng hợp" Value="Tiếp nhận">
            <asp:MenuItem Text="Danh s&#225;ch bệnh nh&#226;n" Value="Danh s&#225;ch bệnh nh&#226;n" NavigateUrl="~/nhanbenh/thongTinBnList.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Danh s&#225;ch bệnh nh&#226;n ngoại tr&#250;" Value="Danh s&#225;ch bệnh nh&#226;n ngoại tr&#250;" NavigateUrl="~/thongke/thongke/DSbenhnhanngoaitru.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Danh s&#225;ch bệnh nh&#226;n nội tr&#250;" Value="Danh s&#225;ch bệnh nh&#226;n nội tr&#250;" NavigateUrl="~/thongke/thongke/DSBNnamvien.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Danh s&#225;ch bệnh nh&#226;n CLS" Value="Danh s&#225;ch bệnh nh&#226;n CLS" NavigateUrl="~/thongke/thongke/DSbenhnhanCLS.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/DSbenhnhanBH.aspx?dkMenu=thongke" Text="Danh s&#225;ch bệnh nh&#226;n c&#243; BHYT"
                Value="Danh s&#225;ch bệnh nh&#226;n c&#243; BHYT"></asp:MenuItem>
            <asp:MenuItem Text="Thống k&#234; bệnh nh&#226;n theo bệnh l&#253;" Value="Thống k&#234; bệnh nh&#226;n theo bệnh l&#253;" NavigateUrl="~/thongke/TKBENHLY/frm_Rpt_BaoCaoBenhLy.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Thống k&#234; lượt đăng k&#253; kh&#225;m chữa bệnh" Value="Thống k&#234; lượt đăng k&#253; kh&#225;m chữa bệnh" NavigateUrl="~/thongke/TKLuotKCB/baocaoluotKCB.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/rpt_XuatBNBHYTNgoaiTru.aspx?dkMenu=thongke" Text="Bảng tổng hợp BN BHYT ngoại tr&#250;"
                Value="Bảng tổng hợp BN BHYT ngoại tr&#250;"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/rpt_HDTaiChinhThu.aspx?dkMenu=thongke" Text="Hoạt động t&#224;i ch&#237;nh"
                Value="Hoạt động t&#224;i ch&#237;nh"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/rpt_HDKhamBenh.aspx?dkMenu=thongke" Text="Hoạt động kh&#225;m bệnh"
                Value="Hoạt động kh&#225;m bệnh"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/rpt_HDDieuTri.aspx?dkMenu=thongke" Text="Hoạt động điều trị"
                Value="Hoạt động điều trị"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Khoa Dược" Value="Khoa Dược">
            <asp:MenuItem Text="Bảng gi&#225; thuốc" Value="Bảng gi&#225; thuốc" NavigateUrl="~/QuanLyNhaThuoc/BangGiaThuoc/frmViewGiaBan.aspx?dkMenu=thongke"></asp:MenuItem>
            
            <asp:MenuItem Text="Bảng kiểm k&#234; " Value="B&#225;o c&#225;o chi tiết nhập xuất tồn thuốc" NavigateUrl="~/QuanLyNhaThuoc/BangKiemKeThuoc/bangkiemkekhoathuoc.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="B&#225;o c&#225;o tổng hợp xuất nhập thuốc" Value="B&#225;o c&#225;o tổng hợp xuất nhập thuốc" NavigateUrl="~/QuanLyNhaThuoc/BangTongHopNhapXuatKho/baocaonhapxuatkhothuocchan.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="B&#225;o c&#225;o chi tiết xuất nhập tồn thuốc 2" Value="New Item" NavigateUrl="~/QuanLyNhaThuoc/BaoCaoChiTietNhapXuatKho2/frmTongHopNXXuat.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Bảng tổng hợp tiền thuốc(BN c&#243; BH)" Value="Bảng tổng hợp tiền thuốc(BN c&#243; BH)" NavigateUrl="~/QuanLyNhaThuoc/BangTongHopTienThuoc/rpt_BangTHTienThuoc.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/thongke/thongke/rpt_XuatBNBHYTNgoaiTru.aspx?dkMenu=thongke" Text="Bảng tổng hợp xuất BN BHYT ngoại tr&#250;"
                Value="Bảng tổng hợp xuất BN BHYT ngoại tr&#250;"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/BangTongHopThuocQuyBHYT/rpt_BangTongHopThuocQuyBHYT.aspx?dkMenu=thongke"
                Text="Bảng tổng hợp thuốc điều trị BHYT KCB Nội/Ngoại" Value="Bảng tổng hợp thuốc điều trị BHYT KCB Nội/Ngoại">
            </asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Ph&#242;ng Ph&#225;t Thuốc" Value="Ph&#242;ng Ph&#225;t Thuốc">
            <asp:MenuItem Text="Bảng gi&#225; thuốc" Value="Bảng gi&#225; thuốc" NavigateUrl="~/QuanLyNhaThuoc/BangGiaThuoc/frmViewGiaBan.aspx?dkMenu=thongke"></asp:MenuItem>
            <asp:MenuItem Text="Bảng tổng hợp xuất BN BHYT ngoại tr&#250;" Value="Bảng tổng hợp xuất BN BHYT ngoại tr&#250;" NavigateUrl="~/thongke/thongke/rpt_XuatBNBHYTNgoaiTru.aspx?dkMenu=thongke">
            </asp:MenuItem>
            <asp:MenuItem Text="Bảng tổng hợp tiền thuốc" Value="Bảng tổng hợp tiền thuốc" NavigateUrl="~/thongke/thongke/rpt_BangTHTienThuoc.aspx?dkMenu=thongke"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Hệ Thống" Value="Hệ Thống">
            <asp:MenuItem NavigateUrl="javascript:window.close();" Text="Tho&#225;t" Value="Tho&#225;t"></asp:MenuItem>
        </asp:MenuItem>
    </Items>
    <StaticMenuStyle HorizontalPadding="6px" VerticalPadding="1px" />
    <StaticHoverStyle BackColor="Control" />
    <LevelSubMenuStyles>
        <asp:SubMenuStyle Font-Underline="False" />
    </LevelSubMenuStyles>
    <DynamicMenuItemStyle ItemSpacing="1px" VerticalPadding="0px" />
    <DynamicItemTemplate>
        <%# Eval("Text") %>
    </DynamicItemTemplate>
    <StaticItemTemplate>
        <%# Eval("Text") %>
    </StaticItemTemplate>
</asp:Menu>

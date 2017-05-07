<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu_NhanBenh" %>
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
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false"
            Orientation="Horizontal" DynamicVerticalOffset="2" StaticEnableDefaultPopOutImage="False">
            <Items>
               <%-- <asp:MenuItem Text="Quản L&#253;" Value="TiepNhan0">
                    <asp:MenuItem Text="Tiếp nhận BN.DV" Value="TN" NavigateUrl="benhnhan.aspx?dkmenu=TiepNhan&loaibn=0">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Tiếp nhận BN.BH" Value="TN" NavigateUrl="benhnhan.aspx?dkmenu=TiepNhan&loaibn=1">
                    </asp:MenuItem>
                </asp:MenuItem>--%>
                <asp:MenuItem Text="Tiếp nhận" Value="tiepnhanfull" NavigateUrl="TiepNhanBN.aspx?dkMenu=TiepNhan">
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Danh mục" Value="Danh mục" Selectable="false" NavigateUrl="">
                    
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="B&#225;o c&#225;o" Value="Bao cao" Selectable="false">
                    <asp:MenuItem Text="T&#236;m kiếm Bệnh nh&#226;n &#160;&#160;" Value="change" NavigateUrl="~/TiepNhan/benhnhan1.aspx?dkMenu=TiepNhan"
                        ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem Text="Tổng hợp số ca kh&#225;m bệnh theo bác sĩ" Value="Tổng hợp số ca kh&#225;m bệnh theo bác sĩ"
                        NavigateUrl="~/TiepNhan/frp_ThongKeCaKCB.aspx?dkMenu=TiepNhan"></asp:MenuItem>
                    <asp:MenuItem Text="Tổng hợp số ca kh&#225;m bệnh theo phòng" Value="Tổng hợp số ca kh&#225;m bệnh"
                        NavigateUrl="~/TiepNhan/frp_ThongKeCaKCB_TH.aspx?dkMenu=TiepNhan"></asp:MenuItem>
                    <asp:MenuItem Text="Thống kê bệnh nhân đăng ký khám" Value="change" NavigateUrl="~/TiepNhan/frpt_DSBNDKKham.aspx?dkMenu=TiepNhan"
                        ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem Text="Thống kê bệnh nhân đăng ký cận lâm sàng" Value="change" NavigateUrl="~/TiepNhan/frpt_DSBNDKCLS.aspx?dkMenu=TiepNhan"
                        ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem Text="Danh sách bệnh nhân trả kết quả cận lâm sàng" Value="trakqcls" NavigateUrl="~/DanhMuc_JSon/web/HS_DANHSACHTRAKQCLS2.aspx?dkMenu=TiepNhan"
                        ImageUrl="~/images/arrow2.gif"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong" Selectable="false">
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
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

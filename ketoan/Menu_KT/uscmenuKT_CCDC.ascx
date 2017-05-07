<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_CCDC.ascx.cs" Inherits="uscmenuKT_CCDC" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" DynamicVerticalOffset="2"  StaticEnableDefaultPopOutImage="False">
    <Items>

        <asp:MenuItem Text="Quản Lý " Value="Quản Lý">
                <asp:MenuItem  NavigateUrl="~/ketoan/KTTSCD_PhieuNhapCCDC3.aspx?dkmenu=ktccdc"
                Text="Phiếu Nhập CCDC" Value="phieunhapccdc"></asp:MenuItem>
                <asp:MenuItem  NavigateUrl="~/ketoan/KTTSCD_PhieuXuatCCDC3.aspx?dkmenu=ktccdc"
                Text="Phiếu Xuất CCDC" Value="phieuxuatccdc"></asp:MenuItem> 
                <asp:MenuItem  NavigateUrl="~/ketoan/KTTSCD_KhauHaoCCDC.aspx?dkmenu=ktccdc"
                Text="Phân bổ CCDC" Value="khauhaoccdc"></asp:MenuItem>
                <asp:MenuItem  NavigateUrl="~/ketoan/KTTSCD_PhanBoCCDC.aspx?dkmenu=ktccdc"
                Text="Tập hợp phân bổ CCDC" Value="phanboccdc"></asp:MenuItem>                                                  
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       
       <%--danh muc--%>
        
        <%--<asp:MenuItem Text="Danh mục" Value="Danh mục">
                 <asp:MenuItem  NavigateUrl="~/ketoan/KTCCDC_DanhMucCCDC.aspx?dkmenu=ktccdc"
                Text="Danh Mục CCDC" Value="danhmucccdc"></asp:MenuItem>
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTVT_BangTongHopNXT_VT1.aspx?dkmenu=ktccdc" Text="Tổng Hợp Nhập Xuất Vật Tư " Value="Danh mục tài sản cố định"></asp:MenuItem>                
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>--%>
        
<%--        <asp:MenuItem Text="Báo Cáo-Danh Sách" Value="Bao cao">
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTVT_BaoCaoKhauHaoTSCD.aspx"
                        Text="Báo Cáo Khấu Hao TSCĐ" Value="BaoCaoKhauHaoTSCD"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTVT_BangTongHopNXT_VT.aspx"
                        Text="Tổng hợp nhập xuất tồn" Value="BangTongHopNXVT"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_rptDanhSachTSCD.aspx"
                        Text="Danh sách TSCĐ" Value="BangTongHopNXVT"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_rptMucTrichKHTSCD.aspx"
                        Text="Bảng đăng ký mức trích KHTSCĐ" Value="BangTongHopNXVT"></asp:MenuItem>
                </asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem--%>
        
         <asp:MenuItem Text="Hệ Thống" Value="hethong">
           
           <asp:MenuItem Text="Thay đổi mật khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx"></asp:MenuItem>
           
            <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
       </asp:MenuItem>   
       <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
           <asp:MenuItem Text="Trang chủ kế toán" Value="trangchukt" NavigateUrl="~/ketoan/index1.aspx"></asp:MenuItem>
       
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
    <DynamicMenuItemStyle CssClass="hovermenu"/>
    <StaticMenuItemStyle CssClass="shovermenu" />
    <DynamicMenuStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"/>
    <DynamicHoverStyle BorderColor="#666666" BackColor="#FBF8F1" BorderStyle="Solid" BorderWidth="1px" />
</asp:Menu>
</div>
</div>
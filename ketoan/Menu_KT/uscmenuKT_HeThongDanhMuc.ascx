<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_HeThongDanhMuc.ascx.cs" Inherits="uscmenuKT_HeThongDanhMuc" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:18px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" DynamicVerticalOffset="2"  StaticEnableDefaultPopOutImage="False">
    <Items>         
        <asp:MenuItem Text=" Hệ Thống Danh mục" Value="Danh mục">
                <%--<asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/DSManHinh.aspx" Text="Danh Sách Màn Hình" Value="dsmanhinh"></asp:MenuItem>--%>
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTDM_DanhMucNghiepVu.aspx" Text="Danh Mục Nghiệp Vụ " Value="danhmucnghiepvu"></asp:MenuItem>       
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/danhmuctaikhoan.aspx" Text="Danh Mục Tài Khoản " Value="danhmuctaikhoan"></asp:MenuItem>       
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/danhmuckho.aspx" Text="Danh Mục Kho" Value="danhmuckho"></asp:MenuItem>
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/danhmucnhacungcap.aspx" Text="Danh Mục Nhà Cung Cấp" Value="danhmucnhacungcap"></asp:MenuItem>                                      
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/danhmuckhachhang.aspx" Text="Danh Mục Khách hàng" Value="danhmuckhachhang"></asp:MenuItem>
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTVT_DM_Vat_Tu.aspx" Text="Danh sách tài sản" Value="danhsachtscd"></asp:MenuItem>                
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTVT_DM_Vat_Tu_ccdc.aspx" Text="Danh sách CCDC" Value="danhsachccdc"></asp:MenuItem>                
                <asp:MenuItem  NavigateUrl="~/ketoan/KTDM_DanhMucKhoa.aspx" Text="Danh mục khoa" Value="danhmuckhoa"></asp:MenuItem>
        </asp:MenuItem>        
        <%--baocao--%>                        
       <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
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
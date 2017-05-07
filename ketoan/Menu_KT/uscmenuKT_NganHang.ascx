<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_NganHang.ascx.cs" Inherits="uscmenuKT_NganHang" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" DynamicVerticalOffset="2"  StaticEnableDefaultPopOutImage="False">
    <Items>

        <asp:MenuItem Text="Quản Lý " Value="Quản Lý">
            <asp:MenuItem  NavigateUrl="~/ketoan/KTNH_UyNhiemChi.aspx?dkmenu=ktnganhang" Text="Lập Giấy Báo Nợ" Value="uynhiemchi"></asp:MenuItem> 
            <asp:MenuItem  NavigateUrl="~/ketoan/KTNH_UyNhiemThu.aspx?dkmenu=ktnganhang" Text="Lập Giấy Báo Có" Value="uynhiemchi"></asp:MenuItem> 
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       
       <%--danh muc--%>
        
        <asp:MenuItem Text="Danh Mục" Value="Danh mục">
                 <%--<asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/nhanbenh/bacsientry.aspx?dkmenu=tiepnhan"
                Text="Danh mục b&#225;c sĩ&#160;&#160;" Value="&#160;&#160;Danh mục b&#225;c sĩ&#160;&#160;"></asp:MenuItem>
                --%>
                <asp:MenuItem  NavigateUrl="~/ketoan/DanhMucTKNH.aspx?dkmenu=ktnganhang"
                Text="Danh Mục Tài Khoản NH" Value="taikhoanNH"></asp:MenuItem>
                
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <%--baocao--%>
         <asp:MenuItem Text="Báo cáo-Danh sách" Value="Bao cao"> 
              <asp:MenuItem  NavigateUrl="~/ketoan/KTNH_SoTienGoiNganHang.aspx?dkmenu=ktnganhang" Text="Sổ Chi Tiết Tài Khoản NH " Value="phieuthukhac"></asp:MenuItem>              
              <asp:MenuItem  NavigateUrl="~/ketoan/KTNH_DanhSachUyNhiemChi.aspx?dkmenu=ktnganhang" Text="Danh Sách Giấy Báo Nợ " Value="DSgiaybaono"></asp:MenuItem>
              <asp:MenuItem  NavigateUrl="~/ketoan/KTNH_DanhSachGiayBaoCo.aspx?dkmenu=ktnganhang" Text="Danh Sách Giấy Báo Có" Value="DSgiaybaoco"></asp:MenuItem> 
                
                
        
        </asp:MenuItem>
        
       
       <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
         <asp:MenuItem Text="Hệ Thống" Value="hethong">
           
           <asp:MenuItem Text="Thay Đổi Mật Khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx"></asp:MenuItem>
           
            <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
       </asp:MenuItem>   
       <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       <asp:MenuItem Text="Trang Chủ Kế Toán" Value="trangchukt" NavigateUrl="~/ketoan/index1.aspx"></asp:MenuItem>
       
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
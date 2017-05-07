<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_ToanTaiSan.ascx.cs" Inherits="uscmenuKT_ToanTaiSan" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" DynamicVerticalOffset="2"  StaticEnableDefaultPopOutImage="False">
    <Items>
        <asp:MenuItem Text="Quản Lý " Value="Quản Lý">
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" Text="Khấu hao TSCD/CCDC" Value="Khấu hao">
                    <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_Khauhaotaisan.aspx" Text="Khấu hao tài sản cố định" Value="Khấu hao tài sản cố định"></asp:MenuItem>
                    </asp:MenuItem> 
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" Text="Nhập Xuất Vật Tư" Value="nhapxuatvatru">
                    <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTVT_PHIEU_NHAP_VT.aspx?" Text="Phiếu Nhập Vật Tư" Value="nhapvattu"></asp:MenuItem>
                    <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/PhieuXuatVT.aspx?" Text="Phiếu Xuất Vật Tư" Value="xuatvattu"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" Text="Tăng giảm TSCĐ" Value="Tăng giảm tài sản cố định">
                    <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_TangGiamTaiSan.aspx?" Text="Phiếu tăng/giảm TSCĐ" Value="Tăng giảm tài sản cố định"></asp:MenuItem>
                    <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_DanhSachTangGiamTaiSan.aspx?" Text="Danh sách phiếu tăng/giảm" Value="Báo cáo thanh lý nhượng bán TSCĐ"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" Text="Phân bổ TSCD/CCDC" Value="Phân bổ">
                    <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_PhanBoTSCD.aspx" Text="&#160;&#160;Phân bổ tài sản cố định" Value="Phân bổ TSCD"></asp:MenuItem>
                    
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       
       <%--danh muc--%>
        <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" Text="Danh mục TSCD/CCDC" Value="Danh muc">
             <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTTSCD_DanhMucTaiSan.aspx" Text="Danh mục tài sản cố định" Value="Danh mục tài sản cố định"></asp:MenuItem>
            
        </asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <%--baocao--%>
         <asp:MenuItem Text="Báo cáo-Danh sách" Value="Bao cao">       
        
        </asp:MenuItem>
        
       
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
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_HeThong.ascx.cs" Inherits="uscmenuKT_HeThong" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" DynamicVerticalOffset="2"  StaticEnableDefaultPopOutImage="False">
    <Items>

        <asp:MenuItem Text="Khai Báo Tham Số Hệ Thống " Value="khaibaothamsohethong">
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="" Text="Danh Sách Tham Số Tùy Chọn" Value="dsthamsotuychon"></asp:MenuItem>
        
                               
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       
       <%--danh muc--%>
        
                 
                
                
        
        
        <%--baocao--%>
         <asp:MenuItem Text="Cập Nhật Số Dư Dầu Kỳ" Value="Bao cao"> 
              
              
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTHT_SoDuDauKyTaiKhoan.aspx" Text="Số Dư Đầu Kỳ Tài Khoản " Value="sodudaukytaikhoan"></asp:MenuItem>
        
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/KTHT_CongNoDauKy.aspx" Text="Công Nợ Đầu Kỳ" Value="congnodauky"></asp:MenuItem>
                
        
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
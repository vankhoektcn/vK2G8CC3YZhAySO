
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_TienMat.ascx.cs" Inherits="uscmenuKT_TienMat" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu2" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" DynamicVerticalOffset="2"  StaticEnableDefaultPopOutImage="False">
    <Items>

        <asp:MenuItem Text="Qu&#7843;n L&#253; " Value="Quản Lý">
                <asp:MenuItem  NavigateUrl="~/ketoan/KTTM_PhieuThuHoaDon.aspx?dkmenu=kttienmat"
                Text="Phi&#7871;u thu h&#243;a &#273;&#417;n" Value="phieuthuhoadon"></asp:MenuItem>
                <asp:MenuItem  NavigateUrl="~/ketoan/KTTM_PhieuChiHoaDon.aspx?dkmenu=kttienmat"
                Text="Phi&#7871;u Thu Chi Ti&#7871;t H&#243;a &#272;&#417;n" Value="phieuchihoadon"></asp:MenuItem> 
                <asp:MenuItem  NavigateUrl="~/ketoan/KTTM_ThuKhac.aspx?dkmenu=kttienmat"
                Text="Phi&#7871;u Thu Kh&#225;c" Value="phieuthukhac"></asp:MenuItem> 
                <asp:MenuItem  NavigateUrl="~/ketoan/KTTM_PhieuChiKhac.aspx?dkmenu=kttienmat"
                Text="Phi&#7871;u Chi Kh&#225;c" Value="phieuchikhac"></asp:MenuItem> 
                
                    
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
       
       <%--danh muc--%>
        
        <asp:MenuItem Text="Danh M&#7909;c" Value="Danh mục">
                 <asp:MenuItem  NavigateUrl="~/ketoan/DMNgoaiTe.aspx?dkmenu=kttienmat"
                Text="DM Ngo&#7841;i T&#7879;" Value="danhmucngoaite"></asp:MenuItem>
              <asp:MenuItem  NavigateUrl="~/ketoan/DMPhongBan.aspx?dkmenu=kttienmat"
                Text="DM Ph&#242;ng Ban" Value="danhmucphongban"></asp:MenuItem>
              
                
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <%--baocao--%>
         <asp:MenuItem Text="B&#225;o C&#225;o-Danh S&#225;ch" Value="Bao cao"> 
              <asp:MenuItem  NavigateUrl="~/ketoan/KTTM_BaoCaoDoanhThu.aspx?dkmenu=kttienmat"
                Text="B&#225;o C&#225;o Doanh Thu" Value="baocaodoanhthu"></asp:MenuItem>
              <asp:MenuItem  NavigateUrl="~/ketoan/SoQuyTM.aspx?dkmenu=kttienmat"
                Text="S&#7893; Qu&#253; Ti&#7873;n M&#7863;t" Value="soquytienmat"></asp:MenuItem>
              <asp:MenuItem  NavigateUrl="~/ketoan/KTTM_DanhSachPhieuChi.aspx?dkmenu=kttienmat"
              Text="Danh S&#225;ch Phi&#7871;u Chi Kh&#225;c" Value="danhsachphieuthukhac"></asp:MenuItem> 
                <asp:MenuItem  NavigateUrl="~/ketoan/KTTM_DanhSachPhieuThuHoaDon.aspx?dkmenu=kttienmat"
                Text="Danh S&#225;ch Phi&#7871;u Thu Kh&#225;c" Value="danhsachphieuchikhac"></asp:MenuItem> 
                  
        </asp:MenuItem>
        
       
       <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
         <asp:MenuItem Text="H&#7879; Th&#7889;ng" Value="hethong">
           
           <asp:MenuItem Text="Thay &#272;&#7893;i M&#7853;t Kh&#7849;u" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx"></asp:MenuItem>
           
            <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
       </asp:MenuItem>   
       <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
           <asp:MenuItem Text="Trang Ch&#7911; K&#7871; To&#225;n" Value="trangchukt" NavigateUrl="~/ketoan/index1.aspx"></asp:MenuItem>
       
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


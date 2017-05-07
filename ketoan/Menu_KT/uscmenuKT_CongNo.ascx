<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_CongNo.ascx.cs" Inherits="uscmenuKT_CongNo" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:30px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" Height = "21px"  Font-Underline="False"  StaticEnableDefaultPopOutImage="False">
<%--<asp:Menu ID="Menu1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="False" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" Font-Underline="False" OnDataBound="Menu1_DataBound">
--%>
    <Items>                        
        <%--baocao--%>
         <asp:MenuItem Text="Báo cáo-Danh sách" Value="Bao cao"> 
             <asp:MenuItem Text="Công Nợ Khách Hàng" Value="công nợ khách hàng">  
                <asp:MenuItem  NavigateUrl="~/ketoan/KTCN_Khach_Hang_TH.aspx?dkmenu=ktcongno"
                Text="Tổng Hợp Công Nợ Khách Hàng " Value="tonghopcongnokhachhang"></asp:MenuItem>
                <asp:MenuItem  NavigateUrl="~/ketoan/KTCN_Khach_Hang_CT.aspx?dkmenu=ktcongno"
                Text="Công Nợ Khách Hàng Chi Tiết" Value="chitietcongnokhachhang"></asp:MenuItem> 
            </asp:MenuItem>
            <asp:MenuItem Text="Công Nợ Nhà Cung Cấp" Value="công nợ nhà cung cấp">  
                <asp:MenuItem  NavigateUrl="~/ketoan/KTCN_NhaCungCap_TH.aspx?dkmenu=ktcongno"
                Text="Tổng Hợp Công Nợ NCC " Value="tonghopcongnoNCC"></asp:MenuItem>
                <asp:MenuItem  NavigateUrl="~/ketoan/KTCN_NhaCungCap_CT.aspx?dkmenu=ktcongno"
                Text="Công Nợ NCC Chi Tiết" Value="chitietcongnoNCC"></asp:MenuItem> 
            </asp:MenuItem>
            <asp:MenuItem  NavigateUrl="~/ketoan/KTTM_DanhSachCongNo.aspx?dkmenu=ktcongno"
                Text="Danh Sách Công Nợ" Value="danhsachcongno">
            </asp:MenuItem> 
            
            <asp:MenuItem  NavigateUrl="~/ketoan/DanhSachBNDKKham.aspx"
                Text="Chi tiết công nợ bệnh nhân" Value="danhsachcongno">
            </asp:MenuItem> 
            
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
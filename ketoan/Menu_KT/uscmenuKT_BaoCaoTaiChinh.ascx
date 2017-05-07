<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_BaoCaoTaiChinh.ascx.cs" Inherits="uscmenuKT_BaoCaoTaiChinh" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" DynamicVerticalOffset="2"  StaticEnableDefaultPopOutImage="False">
    <Items>                     
        <asp:MenuItem Text="Báo cáo tài chính" Value="danhsachthongke">
            <asp:MenuItem Text=" Bảng Cân Đối Tài Khoản " Value="baocaotaichinhCDTK" NavigateUrl="~/ketoan/BCTC_BangCanDoi_TK.aspx"></asp:MenuItem>
            <asp:MenuItem Text=" Bảng Cân Đối Tài Khoản Cấp Cha " Value="baocaotaichinhCDTK" NavigateUrl="~/ketoan/BCTC_BangCanDoi_TK2.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Bảng Cân Đối Kế Toán" Value="Bao cao" NavigateUrl="~/ketoan/BangCanDoiKT.aspx"> </asp:MenuItem>
            <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BCTC_KetQuaHoatDongKD.aspx" Text="Kết quả hoạt động kinh doanh" Value="Kết quả hoạt động kinh doanh"></asp:MenuItem>
            <asp:MenuItem Text="Báo cáo lưu chuyển tiền tệ">
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BCTC_LuuChuyenTienTe.aspx?dkmenu=ktbctc" Text="Khai Báo Tham Số" Value="Báo cáo lưu chuyển tiền tệ"></asp:MenuItem>           
                <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ketoan/BCTC_rptLuuChuyenTienTe.aspx?dkmenu=ktbctc" Text="Báo cáo lưu chuyển tiền tệ" Value="Báo cáo lưu chuyển tiền tệ"></asp:MenuItem>           
            </asp:MenuItem>            
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"> </asp:MenuItem>
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
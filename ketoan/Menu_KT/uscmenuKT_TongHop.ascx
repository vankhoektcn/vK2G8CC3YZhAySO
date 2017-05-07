<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_TongHop.ascx.cs" Inherits="uscmenuKT_BaoCaoTaiChinh" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" DynamicVerticalOffset="2"  StaticEnableDefaultPopOutImage="False">
    <Items>              
       <%--danh muc--%>        
        <asp:MenuItem Text="Chứng Từ Tổng Hợp" Value="chungtutonghop">
            <asp:MenuItem Text="Phiếu Kế Toán" Value="phieuketoan" NavigateUrl="~/ketoan/KTTH_PhieuTongHop.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Danh Sách Phiếu Kế Toán" Value="danhsachphieuketoan" NavigateUrl="~/ketoan/KTTH_DanhSachPhieuTongHop.aspx"></asp:MenuItem>
        </asp:MenuItem>
                        
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Định Nghĩa CTKC" Value="DNcongthucketchuyen" NavigateUrl="~/ketoan/KTTH_CongThucKC.aspx"> 
                
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Sổ KT Theo Hình Thức NKC" Value="hinhthucnhatkychung">
            <asp:MenuItem Text="Sổ Nhật ký Chung" Value="sonhatkychung" NavigateUrl="~/ketoan/KTTH_SoNhatKiChung.aspx"></asp:MenuItem>
           <asp:MenuItem Text="Sổ Chi Tiết Tài Khoản" Value="sochitiettaikhoan" NavigateUrl="~/ketoan/KTTH_SoChiTietTK.aspx"></asp:MenuItem>
           <asp:MenuItem Text="Sổ NK Thu Tiền" Value="sonhatkythutien" NavigateUrl="~/ketoan/KTTH_NhatKyThuTien.aspx"></asp:MenuItem>
           <asp:MenuItem Text="Sổ NK Chi Tiền" Value="sonhatkychitien" NavigateUrl="~/ketoan/KTTH_NhatKyChiTien.aspx"></asp:MenuItem>
           <asp:MenuItem Text="Chứng Từ Ghi Sổ" Value="chungtughiso" NavigateUrl="~/ketoan/KTTH_ChungTuGhiSo.aspx"></asp:MenuItem>           
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
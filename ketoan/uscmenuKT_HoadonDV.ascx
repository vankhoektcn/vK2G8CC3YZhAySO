<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenuKT_HoadonDV.ascx.cs" Inherits="uscmenuKT_HoadonDV" %>

<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:30px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="False" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" Font-Underline="False" OnDataBound="Menu1_DataBound">
    <Items>
       
                
            <asp:MenuItem Text="Quản Lý " Value="quanly" >
                    <asp:MenuItem NavigateUrl="~/ketoan/HDDV_XuatHoaDon.aspx?dkmenu=kthddv" ImageUrl=""
                                 Text="Xuất Hóa Đơn"  Value="xuathoadon"></asp:MenuItem>
                      <asp:MenuItem NavigateUrl="~/ketoan/HDBH_XuatHoaDon.aspx?dkmenu=kthddv" ImageUrl=""
                                 Text="Xuất Hóa Đơn Bán Thuốc"  Value="xuathoadon"></asp:MenuItem>                                              
                                 <asp:MenuItem NavigateUrl="~/ketoan/HDDV_DanhSachHoaDon.aspx?dkmenu=kthddv" ImageUrl=""
                                 Text="Danh Sách Hóa Đơn"  Value="danhsachHD"></asp:MenuItem>
            </asp:MenuItem>
            
            <asp:MenuItem Text="|" Value="|" Enabled="false"></asp:MenuItem>
            <%--<asp:MenuItem  Text="Danh mục" Value="Danh mục"></asp:MenuItem>--%>
        
       
         <asp:MenuItem Text="Danh Sách Báo Cáo" Value="danhsachbaocao">
                           <asp:MenuItem Text="BC Doanh Thu Chi Tiết" Value="BCdoanhthuchitiet" NavigateUrl="~/ketoan/HDDV_rptDoanhThuChiTiet.aspx?dkmenu=kthddv"></asp:MenuItem>
                           <asp:MenuItem NavigateUrl="~/ketoan/HDDV_rptDoanhThuTongHop.aspx?dkmenu=kthddv" Text="BC Doanh Thu Tổng Hợp Theo Ngày"
                            Value="BCDTtheongay"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/ketoan/HDDV_rptDoanhThuTongHop2.aspx?dkmenu=kthddv" ImageUrl=""
                                 Text="BC Doanh Thu Tổng Hợp"  Value="BCdoanhthutonghop"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/ketoan/HDDV_rptDTTheoNguoiDung.aspx?dkmenu=kthddv" ImageUrl=""
                                 Text="BCDT Theo Người Dùng"  Value="BCDTtheonguoidung"></asp:MenuItem>     
          </asp:MenuItem>                  
         <asp:MenuItem Text="|" Value="|" Enabled="False"></asp:MenuItem>
         <asp:MenuItem Text="Hệ Thống" Value="hethong" Enabled="true">
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="thaydoimatkhau" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Thoát" Value="thoat" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
    
         </asp:MenuItem>
         <asp:MenuItem Text="|" Value="|" Enabled="false"></asp:MenuItem>  
         <asp:MenuItem Text="Trang chủ kế toán" Value="trangchukt" NavigateUrl="~/ketoan/index1.aspx"></asp:MenuItem>
    
           
    
    </Items>
    <StaticHoverStyle Font-Bold="true" />
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
    <StaticMenuItemStyle CssClass="hovermenu"/>
    <DynamicMenuStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"/>
    <DynamicHoverStyle BorderColor="#666666" BackColor="#FBF8F1" BorderStyle="Solid" BorderWidth="1px" />
</asp:Menu>
</div>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="CapCuu_uscmenu_NhanBenh" %>

<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false" Orientation="Horizontal" DynamicVerticalOffset="2"  StaticEnableDefaultPopOutImage="False" OnMenuItemClick="Menu1_MenuItemClick" >
    <Items>

        <asp:MenuItem Text="Phụ khoa" Value="Tiếp nhận">
        <asp:MenuItem Text="&#160;&#160;&lt;u&gt;T&lt;/u&gt;iếp nhận bệnh nh&#226;n&#160;&#160;&#160;&#160;&#160;&#160;" Value="TN" NavigateUrl="~/KhoaSan/benhnhannew.aspx?dkmenu=phukhoa&madichvu=13&idkhoa=3"> </asp:MenuItem>
        
        <asp:MenuItem NavigateUrl="~/noitru/ChonCLSBenhVien.aspx?dkmenu=phukhoa" Text="&#160;&#160;Chỉ định dịch vụ nội trú" Value="Tra cứu viện phí"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/noitru/ChonThuoc.aspx?dkmenu=phukhoa" Text="&#160;&#160;Chỉ đinh thuốc,VTYT" Value="Tra cứu viện phí"></asp:MenuItem>

        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_PhieuChuyenKho.aspx?dkmenu=phukhoa" Text="&#160;&#160;Lập phiếu xuất trả kho dược" Value="rm_PhieuChuyenKho" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_PhieuYCXuat.aspx?dkmenu=phukhoa" Text="&#160;&#160;Lập phiếu y/c lĩnh thuốc(thuốc, BTYT)" Value="Lập phiếu y/c lĩnh thuốc(thuốc, BTYT)" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
         
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>   
        
        <asp:MenuItem Text="Danh mục" Value="Danh mục">
                 <%--<asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_DM_Thuoc.aspx?dkmenu=phukhoa" Text="&#160;&#160;Danh mục thuốc" Value="Danh mục thuốc"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_DM_VTYT.aspx?dkmenu=phukhoa" Text="&#160;&#160;Danh mục VTYT" Value="Danh mục VTYT"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_DM_HoaChat.aspx?dkmenu=phukhoa" Text="&#160;&#160;Danh mục hóa chất" Value="Danh mục hóa chất"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/thuoc1.aspx?dkmenu=phukhoa" Text="Danh mục dụng cụ" Value="Danh mục dụng cụ"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="danhmucPKham.aspx" Text="&#160;&#160;Danh mục phòng" Value="&#160;&#160;Danh mục phòng"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="bacsientry.aspx" Text="&#160;&#160;Danh mục bác sĩ" Value="&#160;&#160;Danh mục bác sĩ"></asp:MenuItem>--%>
                      <asp:MenuItem NavigateUrl="~/nhanbenh/DiaChi2.aspx?dkmenu=phukhoa" Text="&#160;&#160;Danh mục địa chỉ"
                Value="Danh mục địa chỉ"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>        
         <asp:MenuItem Text="B&#225;o c&#225;o" Value="Bao cao">
             <asp:MenuItem NavigateUrl="~/KhoaSan/DanhSachCongNoBenhNhan.aspx?dkmenu=phukhoa&madichvu=13&idkhoa=3" Text="&#160;&#160;Theo dõi công nợ bệnh nhân"
                    Value="Tra cứu viện phí"></asp:MenuItem>
             <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_TongHopNhapXuatTon.aspx?dkmenu=phukhoa" Text="&#160;&#160;B&#225;o c&#225;o tổng hợp xuất nhập tồn"
                                Value="B&#225;o c&#225;o tổng hợp xuất nhập tồn" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
             <%--<asp:MenuItem NavigateUrl="~/KhoaSan/DanhSachBNNgoaiTru.aspx?dkmenu=phukhoa" Text="&#160;&#160;Danh sách bệnh án ngoại trú" Value="Danh sách BN ngoại trú"></asp:MenuItem>--%>
             <%--<asp:MenuItem NavigateUrl="#" Text="Danh sách BN ngoại trú" Value="Danh sách BN ngoại trú"></asp:MenuItem>
             <asp:MenuItem NavigateUrl="#" Text="Danh sách BN nội trú" Value="Danh sách BN nội trú"></asp:MenuItem>--%>
             <asp:MenuItem NavigateUrl="~/KhoaSan/frmListKhamBenh_KhoaSan.aspx?dkmenu=phukhoa&madichvu=13&idkhoa=3" Text="&#160;&#160;Danh sách phiếu khám bệnh" Value="Danh sách phiếu khám bệnh"></asp:MenuItem>
             <%--<asp:MenuItem Text="&#160;&#160;Danh sách BN ngoại trú&#160;&#160;" Value="KB" NavigateUrl="~/KhoaSan/DanhSachBenhNhanNgoaiTru.aspx?dkmenu=phukhoa"> </asp:MenuItem>--%>
        <asp:MenuItem Text="&#160;&#160;Danh sách BN nội trú" Value="KB" NavigateUrl="~/KhoaSan/danhSachBenhNhanNoiTru.aspx?dkmenu=phukhoa&madichvu=13&idkhoa=3"> </asp:MenuItem>             
        </asp:MenuItem>
        
       
       <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
      <asp:MenuItem Text="Hệ Thống" Value="hethong">
           
           <asp:MenuItem Text="Thay đổi mật khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx"></asp:MenuItem>
           
            <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
     </asp:MenuItem>   
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
    <StaticMenuItemStyle CssClass="hovermenu" />
    <DynamicMenuStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"/>
    <DynamicHoverStyle BorderColor="#666666" BackColor="#FBF8F1" BorderStyle="Solid" BorderWidth="1px" />
</asp:Menu>
</div>
</div>
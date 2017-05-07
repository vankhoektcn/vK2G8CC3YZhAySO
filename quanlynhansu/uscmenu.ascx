<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="nhanbenh_uscmenu" %>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:#FBF8F1;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Orientation="Horizontal" StaticEnableDefaultPopOutImage="False" >
    <Items>
        <asp:MenuItem Text="  Quản l&#253;  " Value="Quản l&#253;">
            <asp:MenuItem NavigateUrl="~/quanlynhansu/nhanvienentry.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Hồ sơ nh&#226;n vi&#234;n&#160;&#160;" Value="Hồ sơ nh&#226;n vi&#234;n"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/HopDong.aspx"
                Text="&#160;&#160;Hợp đồng lao động&#160;&#160;" Value="Hợp đồng lao động"></asp:MenuItem>    
            <asp:MenuItem NavigateUrl="~/quanlynhansu/xetPhuCapNhanVien.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;X&#233;t phụ cấp Nh&#226;n Vi&#234;n&#160;&#160;" Value="Chấm c&#244;ng tăng ca  &amp;160;&amp;160;"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/quanlynhansu/BangChamCongTheoNgay2.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Chấm c&#244;ng theo ng&#224;y&#160;&#160;" Value="cctn"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/CaPhauThuat3.aspx" Text="&#160;&#160;Chấm c&#244;ng theo ca &#160;phẩu thuật"
                Value="cccpt"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/quanlynhansu/DanhSachNhanVienChiLuong.aspx" Text="&#160;&#160;Chi lương"
                Value="Chi lương"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/KhoaDaoTaoEntry.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Chương tr&#236;nh đ&#224;o tạo&#160;&#160;" Value="Chương tr&#236;nh đ&#224;o tạo"></asp:MenuItem>    
            <asp:MenuItem NavigateUrl="~/quanlynhansu/DangKyKhoaDaoTao.aspx" Text="&#160;&#160;Đăng ký đào tạo&#160;&#160;"
                Value="Đăng ký đào tạo&#160;&#160;"></asp:MenuItem>
       </asp:MenuItem>
        
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="  B&#225;o c&#225;o  " Value="B&#225;o c&#225;o">
            <asp:MenuItem NavigateUrl="~/quanlynhansu/PhuCapDocHai.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Phụ cấp độc hại&#160;&#160;" Value="Phụ cấp độc hại &amp;160;&amp;160;"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/phuCapTrachNhiem.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Phụ cấp Tr&#225;ch nhiệm&#160;&#160;" Value="Phụ cấp Tr&#225;ch nhiệm"></asp:MenuItem>                
            <asp:MenuItem NavigateUrl="~/quanlynhansu/phuCapHienVat.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Phụ cấp hiện vật&#160;&#160;" Value="Chấm c&#244;ng tăng ca  &amp;160;&amp;160;"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/phuCapTienTruc.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Phụ cấp tiền trực&#160;&#160;" Value="phu cap tien truc"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/phuCapBoiDuong.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Bồi dưỡng theo sản phẩm&#160;&#160;" Value="phu cap boi duong"></asp:MenuItem>
            <asp:MenuItem Text="&#160;&#160;Tổng hợp tiền lương&#160;&#160;" Value="Tổng hợp tiền lương" NavigateUrl="~/quanlynhansu/DanhSachLuongThang_New.aspx?dkMenu=tiepnhan"></asp:MenuItem>
            <asp:MenuItem Text="&#160;&#160;Chi tiết lương Nh&#226;n Vi&#234;n&#160;&#160;" Value="Chi tiết lương Nh&#226;n Vi&#234;n " NavigateUrl="~/quanlynhansu/frpt_ChiTietLuong_New.aspx?dkMenu=tiepnhan"></asp:MenuItem>   
            <asp:MenuItem Text="&#160;&#160;Tổng hợp ng&#224;y c&#244;ng&#160;" Value="CCTH" NavigateUrl="~/quanlynhansu/THNgayCong.aspx?dkMenu=tiepnhan"></asp:MenuItem>   
            <asp:MenuItem Text="&#160;&#160;Bảng tổng hợp bệnh nh&#226;n phẩu thuật" Value="THBNPT" NavigateUrl="~/quanlynhansu/THBNPhauThuat.aspx">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/BangTongHopNgayLuong.aspx" Text="&#160;&#160;Chi tiết bảng tổng hợp tiền lương"
                Value="&#160;&#160;Bảng lương"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/BaoCaoTienTHCaKipKoTX.aspx" Text="&#160;&#160;Tổng hợp tiền lương CK BS ko thường xuy&#234;n"
                Value="PTKoTX"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/BaoCaoTienTHCaKipTX.aspx" Text="&#160;&#160;Tổng hợp tiền lương CK BS thường xuy&#234;n"
                Value="PTTX"></asp:MenuItem>
        </asp:MenuItem> 
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text=" Danh mục " Value="Quản l&#253; nh&#226;n vi&#234;n, t&#224;i sản">
            
                <asp:MenuItem NavigateUrl="~/quanlynhansu/phongbanentry.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Danh mục ph&#242;ng ban&#160;&#160;"  Value="Danh mục người d&#249;ng"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="~/quanlynhansu/chucvuentry.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Danh mục chức vụ&#160;&#160;" Value="DM phong kham"></asp:MenuItem> 
                <asp:MenuItem NavigateUrl="~/quanlynhansu/HeSoBaoHiemEntry.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Hệ số Bảo Hiểm &#160;&#160;"  Value="he so bao hiem"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/quanlynhansu/ThueTNCNEntry.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Hệ số thuế TNCN&#160;&#160;"  Value="he so thue tncn"></asp:MenuItem>
                
                 <asp:MenuItem NavigateUrl="~/quanlynhansu/PhuCap.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Danh mục phụ cấp&#160;&#160;" Value="DM phong kham"></asp:MenuItem> 
                 <asp:MenuItem NavigateUrl="~/quanlynhansu/LoaiHopDong.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Danh mục loại hợp đồng&#160;&#160;" Value="DM phong kham"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/quanlynhansu/loainghiphep1.aspx" Text="&#160;&#160;Danh mục loại nghỉ ph&#233;p"
                Value="lnn"></asp:MenuItem>
            <asp:MenuItem Text="&#160;&#160;Danh mục ca trực" Value="&#160;&#160;Danh mục ca trực" NavigateUrl="~/quanlynhansu/catruc2.aspx">
            </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/quanlynhansu/EkipCaMo2.aspx"
                Text="&#160;&#160;Ekip ca mổ&#160;&#160;" Value="EkipCaMo"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/quanlynhansu/LoaiPhauThuat2.aspx"
                Text="&#160;&#160;Loại phẫu thuật&#160;&#160;" Value="LoaiPhauThuat"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/quanlynhansu/GoiPhauThuat2.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;G&#243;i phẫu thuật&#160;&#160;" Value="GoiPhauThuat"></asp:MenuItem>
                                
                <asp:MenuItem NavigateUrl="~/quanlynhansu/ChiTietCLSGoiPhauThuat1.aspx"
                Text="&#160;&#160;Chi tiết CLS phẫu thuật&#160;&#160;" Value="GoiPhauThuat"></asp:MenuItem>                
                <asp:MenuItem NavigateUrl="~/quanlynhansu/VaiTroBSPhauThuat1.aspx?dkMenu=tiepnhan"
                Text="&#160;&#160;Vai tr&#242; phẫu thuật&#160;&#160;" Value="VaiTroPhauThuat"></asp:MenuItem>                
                <asp:MenuItem NavigateUrl="~/quanlynhansu/ChiTietPhuCapBacSiPhauThuat1.aspx"
                Text="&#160;&#160;Chi tiết vai tr&#242; phẫu thuật&#160;&#160;" Value="CLSPhauThuat"></asp:MenuItem>
                
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text=" Hệ thống" Value=" Hệ thống">
            <asp:MenuItem NavigateUrl="~/quanlynhansu/Changepass.aspx" Text=" Thay đổi mật khẩu"
                Value=" Thay đổi mật khẩu"></asp:MenuItem>
            <asp:MenuItem Text=" Tho&#225;t" Value="thoat" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
        </asp:MenuItem>
    </Items>
    <StaticMenuStyle HorizontalPadding="3px" VerticalPadding="1px" />
    <StaticHoverStyle BackColor="Control" />
    <LevelSubMenuStyles>
        <asp:SubMenuStyle Font-Underline="False" />
    </LevelSubMenuStyles>
    <DynamicMenuItemStyle ItemSpacing="1px" VerticalPadding="0px" />
    <DynamicItemTemplate>
        <%# Eval("Text") %>
    </DynamicItemTemplate>
    <StaticItemTemplate>
        <%# Eval("Text") %>
    </StaticItemTemplate>
    <DynamicHoverStyle BackColor="LightBlue" Font-Underline="False" />
</asp:Menu>
</div>
</div>
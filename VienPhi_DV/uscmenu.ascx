<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" >
    <Items>
       
     
        <asp:MenuItem Text="  Quản L&#253;" Value="Quản L&#253;">
            <asp:MenuItem Text=" &gt;&gt; Menu Cũ" Value=" &gt;&gt; Menu Cũ">
                <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/ThuVienPhi/tamungdichvu.aspx?loaiBN=2&amp;dkMenu=thuphi"
                    Text="&#160;&#160;Tạm ứng" Value="&#160;&#160;Tạm Ứng"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ThuVienPhi/hoanung.aspx?loaiBN=2&amp;dkMenu=thuphi"
                    Text="&#160;&#160;Ho&#224;n ứng" Value="&gt;&gt;Ho&#224;n ứng"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/nhanbenh/listdangkydichvu.aspx?dkMenu=thuphi"
                    Text="&#160;&#160;Thu ph&#237; kh&#225;m bệnh" Value="thu phi"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/nhanbenh/listthutiencanlamsandichvu.aspx?dkMenu=thuphi"
                    Text="&#160;&#160;Thu Ph&#237; CLS Theo BS Chỉ Định" Value="Hu? d?ch v?"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/nhanbenh/thuphiCLS_BNTuDenDichVu.aspx?dkMenu=thuphi"
                    Text="&#160;&#160;Thu ph&#237; CLS cho BN đăng k&#253;" Value="Hu? d?ch v?"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/khambenh/danhsachchophieuthanhtoanDV.aspx?dkMenu=thuphi"
                    Text="&#160;&#160;Lập phiếu thanh to&#225;n" Value="   Lập phiếu thanh to&#225;n">
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text=" &gt;&gt; Menu mới" Value=" &gt;&gt; Menu mới">
                <asp:MenuItem NavigateUrl="~/VienPhi_TH/frm_ThuVienPhiTH.aspx?dkMenu=VienPhi_DV&amp;IsBNDV=1"
                    Text="Thu viện ph&#237;" Value="TPKB"></asp:MenuItem>
            </asp:MenuItem>
          
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Danh Mục" Value="Danh m?c">
        
           <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/nhanbenh/bacsientry.aspx?dkMenu=thuphi"
                Text="&#160;&#160;Danh Mục B&#225;c Sỹ&#160;&#160;" Value="&#160;&#160;Danh m?c b&#225;c s?&#160;&#160;"></asp:MenuItem>
              <asp:MenuItem NavigateUrl="~/nhanbenh/banggiadichvuentry.aspx?dkMenu=thuphi"
                Text="&#160;&#160;Danh Mục Dịch Vụ&#160;&#160;"  Value="Danh m?c ng??i d&#249;ng"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="~/nhanbenh/phongkhambenhentry.aspx?dkMenu=thuphi"
                Text="&#160;&#160;Danh Mục Khoa" Value="DM phong kham"></asp:MenuItem>   
                
                
                
                
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  Text="B&#225;o c&#225;o" Value="B&#225;o c&#225;o">
        
         <asp:MenuItem Text=" &#160;&#160;T&#236;m Kiến Bệnh Nh&#226;n" Value="change" NavigateUrl="~/nhanbenh/thongTinBnListdichvu.aspx?dkMenu=thuphi"></asp:MenuItem>
        
        </asp:MenuItem>
      
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
         <asp:MenuItem Text="Hệ Thống" Value="hethong">
         <asp:MenuItem Text="Thay Đổi Mật Khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx?dkMenu=thuphi"></asp:MenuItem>
          <asp:MenuItem Text="Tho&#225;t" Value="thoat" NavigateUrl="javascript:window.close();"></asp:MenuItem>
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
    <DynamicHoverStyle BackColor="LightBlue" />
</asp:Menu>

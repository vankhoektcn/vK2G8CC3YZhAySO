<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu" %>
<asp:Menu ID="Menu1" runat="server" DynamicEnableDefaultPopOutImage="False" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" >
    <Items>
       
     
        <asp:MenuItem Text="Quản l&#253;" Value="Quản l&#253;">
                    <asp:MenuItem NavigateUrl="~/VienPhi_TH/frm_ThuVienPhiTH.aspx?IsBNBH=1&amp;dkMenu=VienPhi_BH"
                        Text="Thu viện ph&#237;" Value="Thu viện ph&#237;"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/VienPhi_BH/frmDSBNChoTTVP.aspx?dkMenu=VienPhi_BH"
                        Text="In mẫu BV01" Value="InMau01"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/VienPhi_BH/frm_DS_ToaThuoc.aspx?dkMenu=VienPhi_BH"
                        Text="DSBN chờ phát thuốc" Value="InMau01"></asp:MenuItem>
        
              
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem Text="Danh mục" Value="Danh mục">
        
           <asp:MenuItem  ImageUrl="~/nhanbenh/images/nut.jpg" NavigateUrl="~/nhanbenh/bacsientry.aspx?dkMenu=thuphiBH"
                Text="&#160;&#160;Danh mục b&#225;c sĩ&#160;&#160;" Value="&#160;&#160;Danh mục b&#225;c sĩ&#160;&#160;"></asp:MenuItem>
              <asp:MenuItem NavigateUrl="~\nhanbenh\banggiadichvuentry.aspx?dkMenu=thuphiBH"
                Text="&#160;&#160;Bảng gi&#225; thu tiền viện ph&#237;&#160;&#160;"  Value="Danh mục người d&#249;ng"></asp:MenuItem>
                 <asp:MenuItem NavigateUrl="~\nhanbenh\phongkhambenhentry.aspx?dkMenu=thuphiBH"
                Text="&#160;&#160;Danh mục khoa" Value="DM phong kham"></asp:MenuItem>   
                
        </asp:MenuItem>
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
        <asp:MenuItem  Text="B&#225;o c&#225;o" Value="B&#225;o c&#225;o">
        
         <asp:MenuItem Text=" &#160;&#160;T&#236;m kiếm Bệnh nh&#226;n &#160;&#160;" Value="change" NavigateUrl="~/nhanbenh/thongTinBnListthuong.aspx?dkMenu=thuphiBH"></asp:MenuItem>
        </asp:MenuItem>
      
        <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
         <asp:MenuItem Text="Hệ Thống" Value="hethong">
         <asp:MenuItem Text="Thay đổi mật khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx?dkMenu=thuphiBH"></asp:MenuItem>
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

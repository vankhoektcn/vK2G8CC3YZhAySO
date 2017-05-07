<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="khambenh_uscmenu" %>
<div class="sola">
<div style="position:fixed;z-index:-1000;top:0;width:100%;height:22px;background-color:white;left:0;border-bottom:1px solid #666666;"></div>
<div style="overflow:auto">
<asp:Menu ID="Menu1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="False" Orientation="Horizontal" Height = "21px" StaticEnableDefaultPopOutImage="False" Font-Underline="False">
    <Items>
        <asp:MenuItem Text="Hệ Thống" Value="Hệ Thống"  ImageUrl="../images/preferences_desktop_user_password.png" >
            <asp:MenuItem Text="Đăng nhập" Value="Đăng nhập" NavigateUrl="~/Login.aspx" ImageUrl="../images/preferences_desktop_user_password.png"></asp:MenuItem>
            <asp:MenuItem Text="Đăng xuất" Value="Đăng xuất" ImageUrl="../images/preferences_desktop_user_password.png" NavigateUrl="~/Login.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Th&#244;ng tin đăng nhập" Value="Th&#244;ng tin đăng nhập" ImageUrl="../images/preferences_desktop_user_password.png"></asp:MenuItem>
            <asp:MenuItem Text="Thay đổi mật khẩu" Value="Thay đổi mật khẩu" ImageUrl="../images/preferences_desktop_user_password.png"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Quản L&#253;" Value="Quản L&#253;" ImageUrl="../images/list.png">
            <asp:MenuItem Text="Phiếu Nhập" Value="Xuất kho">
                <asp:MenuItem Text="Phiếu nhập mua" Value="Phiếu nhập mua" NavigateUrl="~/Quanly/Input3.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Phiếu nhập th&#224;nh phẩm" Value="Phiếu nhập th&#224;nh phẩm" NavigateUrl="~/Quanly/Phieunhapthanhpham.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Phiếu nhập trả h&#224;ng" Value="Phiếu nhập trả h&#224;ng" NavigateUrl="~/Quanly/Phieunhaptrahang.aspx"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Phiếu Xuất" Value="Nhập kho">
                <asp:MenuItem Text="Phiếu xuất b&#225;n" Value="Phiếu xuất b&#225;n" NavigateUrl="~/Quanly/Output3.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Phiếu chuyển kho" Value="Phiếu chuyển kho" NavigateUrl="~/Quanly/Phieuchuyenkho.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Phiếu xuất trả h&#224;ng" Value="Phiếu xuất trả h&#224;ng" NavigateUrl="~/Quanly/Phieuxuattrahang.aspx"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Phiếu Thu" Value="Phiếu Thu">
                <asp:MenuItem NavigateUrl="~/Quanly/Receip3.aspx" Text="Phiếu thu" Value="Phiếu thu tiền mặt">
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="Phiếu Chi" Value="Phiếu Chi">
                <asp:MenuItem NavigateUrl="~/Quanly/Payment3.aspx" Text="Phiếu chi" Value="Phiếu chi tiền mặt">
                </asp:MenuItem>
                <asp:MenuItem Text="Phiếu chi nội bộ" Value="Ủy nhiệm chi" NavigateUrl="~/Quanly/Phieuchinoibo.aspx"></asp:MenuItem>
            </asp:MenuItem>
        </asp:MenuItem>
         
        <asp:MenuItem  Text="Danh Mục" Value="Quan ly" ImageUrl="../images/folder_documents.png">
            <asp:MenuItem Text=" Kh&#225;ch h&#224;ng" Value="Kh&#225;ch h&#224;ng" NavigateUrl="~/Danhmuc/Customer2.aspx" ImageUrl="../images/folder_documents.png"></asp:MenuItem>
            <asp:MenuItem Text=" Nhà Cung Cấp" Value="Kh&#225;ch h&#224;ng" NavigateUrl="~/Danhmuc/NhaCC.aspx" ImageUrl="../images/folder_documents.png"></asp:MenuItem>
            
            <asp:MenuItem Text=" Sản phẩm" Value="Sản phẩm" NavigateUrl="../Danhmuc/Product2.aspx" ImageUrl="../images/folder_documents.png"></asp:MenuItem>
            <asp:MenuItem Text=" Loại sản phẩm" Value="Loại sản phẩm" NavigateUrl="~/Danhmuc/KindProduct2.aspx" ImageUrl="../images/folder_documents.png"></asp:MenuItem>
            <asp:MenuItem Text=" Nh&#243;m sản phẩm" Value="Nh&#243;m sản phẩm" NavigateUrl="~/Danhmuc/GroupProduct2.aspx" ImageUrl="../images/folder_documents.png"></asp:MenuItem>
            <asp:MenuItem Text=" K&#237;ch thước" Value="K&#237;ch thước" NavigateUrl="~/Danhmuc/Size2.aspx" ImageUrl="../images/folder_documents.png"></asp:MenuItem>
            <asp:MenuItem Text=" M&#224;u sắc" Value="M&#224;u sắc" NavigateUrl="~/Danhmuc/Color2.aspx" ImageUrl="../images/folder_documents.png"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Danhmuc/Spense2.aspx" Text="Khoản nhập thu chi"
                Value="Khoản nhập thu chi"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Danhmuc/Unit2.aspx" Text="Đơn vị t&#237;nh" Value="đơn vị t&#237;nh" ImageUrl="../images/folder_documents.png">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Danhmuc/Branch2.aspx" Text=" Chi nh&#225;nh" Value="Chi nh&#225;nh" ImageUrl="../images/folder_documents.png">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Danhmuc/Stock2.aspx" Text=" Kho" Value="Kho" ImageUrl="../images/folder_documents.png"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Danhmuc/Bank2.aspx" Text=" Ng&#226;n h&#224;ng" Value="Ng&#226;n h&#224;ng" ImageUrl="../images/folder_documents.png">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Danhmuc/BankAccount2.aspx" Text=" T&#224;i khoản ng&#226;n h&#224;ng"
                Value="T&#224;i khoản ng&#226;n h&#224;ng" ImageUrl="../images/folder_documents.png"></asp:MenuItem>
        </asp:MenuItem>
         
        <asp:MenuItem Text="B&#225;o c&#225;o" Value="B&#225;o c&#225;o" ImageUrl="../images/keditbookmarks.png">
            <asp:MenuItem Text="B&#225;o c&#225;o c&#244;ng nợ" Value="B&#225;o c&#225;o c&#244;ng nợ" ImageUrl="../images/keditbookmarks.png">
            </asp:MenuItem>
            <asp:MenuItem Text="B&#225;o c&#225;o doanh thu" Value="B&#225;o c&#225;o doanh thu" ImageUrl="../images/keditbookmarks.png">
            </asp:MenuItem>
            <asp:MenuItem Text="B&#225;o c&#225;o lợi nhuận" Value="B&#225;o c&#225;o lợi nhuận" ImageUrl="../images/keditbookmarks.png">
            </asp:MenuItem>
            <asp:MenuItem Text="B&#225;o c&#225;o doanh số" Value="B&#225;o c&#225;o doanh số" ImageUrl="../images/keditbookmarks.png"></asp:MenuItem>
            <asp:MenuItem Text="B&#225;o c&#225;o tồn kho" Value="B&#225;o c&#225;o tồn kho" ImageUrl="../images/keditbookmarks.png"></asp:MenuItem>
            <asp:MenuItem Text="Danh s&#225;ch t&#236;m kiếm" Value="Danh s&#225;ch t&#236;m kiếm" ImageUrl="../images/keditbookmarks.png">
                <asp:MenuItem Text="Danh s&#225;ch phiếu nhập" NavigateUrl="~/BaoCao/rpt_Input1.aspx" Value="Danh s&#225;ch phiếu nhập" ImageUrl="../images/keditbookmarks.png"></asp:MenuItem>
                <asp:MenuItem Text="Danh s&#225;ch phiếu xuất" NavigateUrl="~/BaoCao/rpt_Output1.aspx" Value="Danh s&#225;ch phiếu xuất" ImageUrl="../images/keditbookmarks.png"></asp:MenuItem>
                <asp:MenuItem Text="Danh s&#225;ch phiếu thu" NavigateUrl="~/BaoCao/rpt_Receip1.aspx" Value="Danh s&#225;ch phiếu thu" ImageUrl="../images/keditbookmarks.png"></asp:MenuItem>
                <asp:MenuItem Text="Danh s&#225;ch phiếu chi" NavigateUrl="~/BaoCao/rpt_Payment1.aspx" Value="Danh s&#225;ch phiếu chi" ImageUrl="../images/keditbookmarks.png"></asp:MenuItem>
            </asp:MenuItem>
        </asp:MenuItem>
        
        <asp:MenuItem Text="Trợ gi&#250;p" Value="Trợ gi&#250;p" ImageUrl="../images/help_contents.png"></asp:MenuItem>
         
        <asp:MenuItem Text="Trở về trang ch&#237;nh" NavigateUrl="~/Hethong/Default.aspx" ImageUrl="../images/folder_home.png" Value="Trở về trang ch&#237;nh"></asp:MenuItem>
    </Items>
    <StaticHoverStyle Font-Bold="True" ForeColor="Blue"/>
    <LevelSubMenuStyles>
        <asp:SubMenuStyle Font-Underline="False" Font-Size="12px" />
    </LevelSubMenuStyles>
    <DynamicItemTemplate>
        <%#Eval("Text")%>
    </DynamicItemTemplate>
    <StaticItemTemplate>
       <img src="<%#Eval("ImageUrl")%>" alt="" style="border:0;position:absolute;top:0;width:20px;height:20px"/> <p style="margin-left:30px"><%#Eval("Text")%></p>
    </StaticItemTemplate>
    <DynamicMenuItemStyle CssClass="hovermenu" HorizontalPadding="5px" ItemSpacing="2px" />
    <StaticMenuItemStyle CssClass="hovermenu" HorizontalPadding="15px"/>
    <DynamicMenuStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
    <DynamicHoverStyle BorderColor="#666666" BackColor="#0066FF" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
</asp:Menu>
</div>

</div>
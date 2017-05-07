<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu" %>

<div class="sola">
    <div style="position: absolute; z-index: -1000; top: 0; width: 100%; height: 26px; background-color: #FBF8F1;
        left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false"
            Orientation="Horizontal" DynamicVerticalOffset="2" StaticEnableDefaultPopOutImage="False">
            
            
            <Items>
                 <asp:MenuItem ImageUrl="~/images/hoso.gif" Text="B&#225;o c&#225;o bệnh l&#253;" Value="QUANLY">
                        <asp:MenuItem NavigateUrl="~/BaoCaoQuanTri/Web/frm_Rpt_BaoCaoSo1.aspx" Text= "B&#225;o c&#225;o số 1"
                            Value="BaoCaoSo1" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                     <asp:MenuItem Text="B&#225;o c&#225;o số 2" Value="B&#225;o c&#225;o số 2"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="|" Value="DUYETYEUCAU_"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/images/hoso.gif" Text="Nh&#243;m b&#225;o c&#225;o 2" Value="DUYETYEUCAU">
                        <asp:MenuItem Text="B&#225;o c&#225;o số 2.1" Value="B&#225;o c&#225;o số 2.1"></asp:MenuItem>
                    </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
               <asp:MenuItem ImageUrl="~/images/folder_documents.png" Text="Nh&#243;m b&#225;o c&#225;o 3" Value="DANHMUC">
                    </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem ImageUrl="../images/chungtu.gif" Text="Nh&#243;m b&#225;o c&#225;o 3" Value="BAOCAO">
                      
                    </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong">
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="CHANGEPASS" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Tho&#225;t" Value="EXIT" NavigateUrl="~/CloseTab.aspx"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <LevelSubMenuStyles>
                <asp:SubMenuStyle Font-Underline="False" Font-Size="12px" />
            </LevelSubMenuStyles>
            <DynamicItemTemplate>
                <%# Eval("Text") %>
            </DynamicItemTemplate>
            <StaticItemTemplate>
                <%# Eval("Text") %>
            </StaticItemTemplate>
            <DynamicMenuItemStyle CssClass="hovermenu" />
            <StaticMenuItemStyle CssClass="shovermenu" />
            <DynamicMenuStyle BorderStyle="Solid" BorderWidth="1px" CssClass="hover" />
            <DynamicHoverStyle BorderStyle="Solid" BorderWidth="1px" />
        </asp:Menu>
    </div>
</div>

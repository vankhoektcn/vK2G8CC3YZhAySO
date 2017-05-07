<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu" %>
<div class="sola">
    <div style="position: absolute; z-index: -1000; top: 0; width: 100%; height: 26px;
        background-color: #FBF8F1; left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem Text="Bảng gi&#225; viện ph&#237;" Value="BANGGIAVIENPHI">
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/banggiadichvu_CK.aspx?dkmenu=GiamDinhBHYT" Text="Bảng gi&#225; dịch vụ chuy&#234;n khoa"
                        Value="Bảng gi&#225; dịch vụ chuy&#234;n khoa"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/banggiadichvu_CLS.aspx?dkmenu=GiamDinhBHYT" Text="Bảng gi&#225; cận l&#226;m s&#224;ng"
                        Value="BANGGIACLS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/banggiadichvu_dvkt.aspx?dkmenu=GiamDinhBHYT" Text="Bảng gi&#225; dịch vụ kĩ thuật"
                        Value="BANGGIADVKT"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/banggiadichvu_VC.aspx?dkmenu=GiamDinhBHYT" Text="Bảng gi&#225; vận chuyển"
                        Value="Bảng gi&#225; vận chuyển"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/banggiadichvu_KTC.aspx?dkmenu=GiamDinhBHYT" Text="Bảng gi&#225; dịch vụ kĩ thuật cao"
                        Value="Bảng gi&#225; dịch vụ kĩ thuật cao"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/HS_BANGGIAGIUONG_LAN3.aspx?dkmenu=GiamDinhBHYT" Text="Bảng gi&#225; giường"
                        Value="BANGGIAGIUONG"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/HS_BANGGIATHUOC3.aspx?dkmenu=GiamDinhBHYT&LoaiThuocID=1" Text="Bảng gi&#225; thuốc"
                        Value="BANGGIATHUOC"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/HS_BANGGIATHUOC3.aspx?dkmenu=GiamDinhBHYT&LoaiThuocID=4" Text="Bảng gi&#225; VTYT"
                        Value="BANGGIAVTYT"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Danh mục tham khảo" Value="DANHMUCTHAMKHAO">
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|"></asp:MenuItem>
                <asp:MenuItem Text="Hệ thống" Value="HETHONG">
                    
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

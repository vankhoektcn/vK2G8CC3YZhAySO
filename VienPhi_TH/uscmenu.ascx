<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu" %>
<style type="text/css">
.hover
{
	z-index:1;
}
</style>
<div class="sola">
    <div style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 22px; background: #ccc url(../images/footer.png) repeat-x center;
        left: 0; border-bottom: 1px solid #CCC;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="False"
            Orientation="Horizontal" Height="21px" StaticEnableDefaultPopOutImage="False">
            <Items>
                <asp:MenuItem Text="Quản l&#253;" Value="Quản l&#253;" Selectable="false">
                    <asp:MenuItem Text="&#160;&#160;BN Kh&#225;m dịch vụ" Value="BN Kh&#225;m dịch vụ" Selectable="false">
                        <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_BNTHUPHI2.aspx?dkMenu=VienPhi_TH&amp;IsBNDV=1&IsPhiKham_CLS_TuDK=1"
                            Text="Phí khám & CLS tự ĐK" Value="PHIKHAM_CLS_DV"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_BNTHUPHI2.aspx?dkMenu=VienPhi_TH&amp;IsBNDV=1&IsCLS=1"
                            Text="Phí CLS-DVKT" Value="PHICLSDVKT_DV"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_BNTHUPHI2.aspx?dkMenu=VienPhi_TH&amp;IsBNDV=1&IsTamUng=1"
                            Text="Phí tạm ứng" Value="TAMUNG_DV"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_BNTHUPHI2.aspx?dkMenu=VienPhi_TH&amp;IsBNDV=1"
                            Text="Viện ph&#237; chung" Value="Viện ph&#237; chung"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_BNTHUPHI2.aspx?HaveVPNT=1&IsBNDV=1&dkMenu=VienPhi_TH"
                            Text="Thanh to&#225;n ra viện" Value="Thanh to&#225;n ra viện"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_BNDONGCHITRA2.aspx?dkMenu=VienPhi_TH&IsBNDV=1"
                            Text="BV02-BV01" Value="In mẫu BV"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="&#160;&#160;BN kh&#225;m dịch vụ BHYT" Value="BHYT" Selectable="false">
                        <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_BNTHUPHI2.aspx?dkMenu=VienPhi_TH&amp;IsBNBH=1"
                            Text="Viện ph&#237; " Value="Viện ph&#237; "></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_BNTHUPHI2.aspx?HaveVPNT=1&IsBNBH=1&dkMenu=VienPhi_TH"
                            Text="Thanh to&#225;n ra viện" Value="Thanh to&#225;n ra viện"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_BNDONGCHITRA2.aspx?dkMenu=VienPhi_TH&IsBNBH=1"
                            Text="BV02-BV01" Value="In mẫu BV"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Danh mục" Value="Danh mục" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="B&#225;o c&#225;o" Value="B&#225;o c&#225;o" Selectable="false">
                    <asp:MenuItem Text="B&#225;o c&#225;o tiền kh&#225;m &amp; tiền sổ" Value="B&#225;o c&#225;o tiền kh&#225;m &amp; tiền sổ;"
                        NavigateUrl="~/VienPhi_TH/frp_ThongKeTienKham.aspx?dkMenu=VienPhi_TH"></asp:MenuItem>
                    <asp:MenuItem Text="B&#225;o c&#225;o tiền CLS" Value="B&#225;o c&#225;o tiền CLS;"
                        NavigateUrl="~/VienPhi_TH/frp_ThongKeTienCLS.aspx?dkMenu=VienPhi_TH"></asp:MenuItem>
                    <asp:MenuItem Text="B&#225;o c&#225;o doanh thu người d&#249;ng " Value="B&#225;o c&#225;o tiền CLS;"
                        NavigateUrl="~/VienPhi_TH/frm_ThongKeDoanhThu.aspx?dkMenu=VienPhi_TH"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Z_DSPHIEUTHU_VIEW2.aspx?dkMenu=VienPhi_TH"
                        Text="Danh s&#225;ch đ&#227; thu" Value="Danh s&#225;ch đ&#227; thu"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/VienPhi_TH/frm_DSBNTraTienCLS.aspx?dkMenu=VienPhi_TH"
                        Text="Danh s&#225;ch bệnh nh&#226;n trả lại tiền CLS" Value="Danh s&#225;ch bệnh nh&#226;n trả lại tiền CLS">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/VienPhi_TH/frm_DSBNTraTienPhiKham.aspx?dkMenu=VienPhi_TH"
                        Text="Danh s&#225;ch bệnh nh&#226;n trả lại tiền Ph&#237; kh&#225;m" Value="Danh s&#225;ch bệnh nh&#226;n trả lại tiền Ph&#237; kh&#225;m">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/VienPhi_TH/frmBNBHDongTien.aspx?dkMenu=VienPhi_TH" Text="Bảng theo dõi công nợ bệnh nhân"
                        Value="Bảng theo dõi công nợ bệnh nhân"></asp:MenuItem>
                    <asp:MenuItem Text="Bảo hiểm y tế" Value="bhyt" Selectable="false">
                        <asp:MenuItem NavigateUrl="~/VienPhi_BH/frm_Rpt_MauC79A.aspx?dkMenu=VienPhi_TH" Text="Biểu mẫu C79A"
                            Value="Biểu mẫu 25A-CT"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/VienPhi_BH/frm_Rpt_Mau25B.aspx?dkMenu=VienPhi_TH" Text="Biểu mẫu 25A-TH"
                            Value="Biểu mẫu 25A-TH"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/VienPhi_BH/frm_Rpt_Mau20.aspx?dkMenu=VienPhi_TH" Text="Biểu mẫu 20"
                            Value="Biểu mẫu 20"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/VienPhi_BH/frm_Rpt_Mau21.aspx?dkMenu=VienPhi_TH" Text="Biểu mẫu 21"
                            Value="Biểu mẫu 21"></asp:MenuItem>
                            
                        <asp:MenuItem NavigateUrl="~/VienPhi_BH/frm_Rpt_MauC79A.aspx?dkMenu=VienPhi_TH" Text="Biểu mẫu C80A"
                            Value="Biểu mẫu 26A-CT"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/VienPhi_BH/frm_Rpt_Mau26B.aspx?dkMenu=VienPhi_TH" Text="Biểu mẫu 26A-TH"
                            Value="Biểu mẫu 26A-TH"></asp:MenuItem>


                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong" Selectable="false">
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="change" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx?dkmenu=VienPhi_TH">
                    </asp:MenuItem>
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
            <DynamicMenuItemStyle CssClass="hovermenu" />
            <StaticMenuItemStyle CssClass="shovermenu" />
            <DynamicMenuStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" CssClass="hover" />
            <DynamicHoverStyle BorderColor="#666666" BackColor="#FBF8F1" BorderStyle="Solid"
                BorderWidth="1px" />
        </asp:Menu>
    </div>
</div>

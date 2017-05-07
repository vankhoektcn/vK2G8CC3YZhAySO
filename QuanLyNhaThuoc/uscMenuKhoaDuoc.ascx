<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscMenuKhoaDuoc.ascx.cs" Inherits="uscMenuKhoaDuoc" %>
<table width = "100%" cellpadding = "0" cellspacing = "0" border = "0">
    <tr>
        <td align = "left" valign = "top" style="height: 34px">
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
                    Width="120px" Font-Bold="True" Font-Names="Tahoma" ForeColor="Gray" StaticEnableDefaultPopOutImage="False" Font-Size="Small" StaticDisplayLevels="1" OnMenuItemClick="Menu1_MenuItemClick" >
                <LevelMenuItemStyles>
                    <asp:MenuItemStyle Font-Underline="False" />
                </LevelMenuItemStyles>
                <Items>
                    <asp:MenuItem ImageUrl = "../images/hoso.gif" Text=" Quản l&#253; danh mục" Value="1">
                        <asp:MenuItem NavigateUrl="danhmuckho.aspx" Text=" Danh mục kho" Value="New Item 1" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="danhmucnhacungcap.aspx" Text=" Danh mục nh&#224; cung cấp" Value="Danh mục nh&#224; cung cấp" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="danhmuchangsanxuat2.aspx" Text=" Danh mục H&#227;ng SX" Value="Danh mục H&#227;ng SX" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="danhmuchangsanxuat.aspx" Text=" Danh mục Nước SX" Value="Danh mục Nước SX" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="danhmucloaithuoc.aspx" Text=" Danh mục nh&#243;m" Value="New Item 1" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/nhomthuoc1.aspx" Text=" Danh mục ph&#226;n nh&#243;m" Value="New Item 2" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/thuoc1.aspx" Text=" Danh mục thuốc" Value="New Item 1" ImageUrl="../images/arrow2.gif" ></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/thuoc1_HC.aspx" Text="Danh mục h&#243;a chất"
                            Value="Danh mục h&#243;a chất" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/thuoc1_VTYT.aspx" Text="Danh mục vật tư y tế"
                            Value="Danh mục vật tư y tế" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/phieunhapkho3.aspx" Text="Khai b&#225;o số dư đầu kỳ"
                            Value="Khai b&#225;o số dư đầu kỳ" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        
                    </asp:MenuItem>
                    <asp:MenuItem Text="|" Value="1"></asp:MenuItem>
                    <asp:MenuItem ImageUrl = "../images/pagespen.gif" Text=" Quản l&#253;" Value="QUẢN L&#221; NHẬP XUẤT THUỐC">
                        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/phieunhapkho_new.aspx" Text=" Phiếu nhập mua" Value="Nhập mua" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_PhieuXuatLe.aspx" Text=" Phiếu xuất kho ( Xuất cho KH lẻ )" Value="New Item 2" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_PhieuChuyenKho.aspx" Text=" Phiếu xuất chuyển kho (Xuất cho c&#225;c khoa,P.P.T )" Value="New Item 2" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="XuatTraNhaCungCap.aspx" Text=" Phiếu xuất trả nh&#224; cung cấp" Value="New Item 2" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QuanLyNhaThuoc/DSPhieuYCXuatKho.aspx"
                            Text=" Danh s&#225;ch phiếu y&#234;u cầu xuất kho( phiếu lĩnh)" Value=" Danh s&#225;ch phiếu y&#234;u cầu xuất kho( phiếu lĩnh)">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    
                    <asp:MenuItem Text="|" Value="1"></asp:MenuItem>
                    <asp:MenuItem ImageUrl = "../images/chungtu.gif" Text=" B&#225;o c&#225;o - Thống k&#234;" Value="B&#193;O C&#193;O THỐNG K&#202;">
                        <asp:MenuItem Text="B&#225;o c&#225;o nhập xuất tồn" Value="B&#225;o c&#225;o nhập xuất tồn">
                            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_SoDuDauKy.aspx" Text="B&#225;o c&#225;o tồn đầu kỳ"
                                Value="B&#225;o c&#225;o tồn đầu kỳ" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_TongHopNhapXuatTon.aspx" Text="B&#225;o c&#225;o tổng hợp xuất nhập tồn"
                                Value="B&#225;o c&#225;o tổng hợp xuất nhập tồn" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/TheKho.aspx" Text="B&#225;o c&#225;o chi tiết xuất nhập tồn(thẻ kho)"
                                Value="B&#225;o c&#225;o chi tiết xuất nhập tồn(thẻ kho)" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/bangkiemkekhoathuoc.aspx" Text="Bi&#234;n bản ki&#234;m k&#234;"
                                Value="Bi&#234;n bản ki&#234;m k&#234;" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/BienBangKiemNhap.aspx" Text="Bi&#234;n bản kiểm nhập"
                                Value="Bi&#234;n bản kiểm nhập" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_DuTruThuocYEAR.aspx"
                                Text="Dự tr&#249; thuốc theo năm" Value="Dự tr&#249; thuốc"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" Text="Dự tr&#249; thuốc theo th&#225;ng"
                                Value="Dự tr&#249; thuốc theo th&#225;ng" NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_DuTruThuocMONTH.aspx"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_TinhHinhSuDungThuoc2.aspx"
                                Text="B.C.S.D thuốc" Value="B&#225;o c&#225;o sử dụng thuốc"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_SDThuocGN.aspx"
                                Text="B.C.S.D thuốc g&#226;y nghiện" Value="T&#236;nh h&#236;nh sử dụng thuốc"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" Text="B.C.S.D thuốc hướng t&#226;m thần"
                                Value="B.C.S.D thuốc hướng t&#226;m thần" NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_SDThuocHTT.aspx"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" Text="B.C.S.D thuốc kh&#225;ng sinh"
                                Value="B.C.S.D thuốc kh&#225;ng sinh" NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_SDThuocKS.aspx"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_TinhHinhSuDungVTYT.aspx"
                                Text="B.C.S.D VTYT" Value="B.C.S.D VTYT"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_TinhHinhSuDungHoaChat.aspx"
                                Text="B.C.S.D H&#243;a chất" Value="B.C.S.D H&#243;a chất"></asp:MenuItem>
                            
                        </asp:MenuItem>
                        <asp:MenuItem Text="Danh s&#225;ch" Value="Danh s&#225;ch">
                            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/danhmucphieunhap.aspx" Text="Danh s&#225;ch phiếu nhập"
                                Value="Danh s&#225;ch phiếu nhập" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="danhmucphieuxuat.aspx" Text="Danh s&#225;ch phiếu xuất"
                                Value="Danh s&#225;ch phiếu xuất" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="BaocaoNhapXuatTon-theoThuoc.aspx" Text="Danh s&#225;ch nhập xuất tổng hợp 1"
                                Value="Danh s&#225;ch nhập xuất tổng hợp 1" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="frmTongHopNXXuat.aspx" Text="Danh s&#225;ch nhập xuất tổng hợp 2"
                                Value="Danh s&#225;ch nhập xuất tổng hợp 2" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_DanhMucThuoc.aspx" Text="Danh s&#225;ch thuốc"
                                Value="Danh s&#225;ch thuốc" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_DanhMucHoaChat.aspx" Text="Danh s&#225;ch h&#243;a chất"
                                Value="Danh s&#225;ch h&#243;a chất" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/QuanLyNhaThuoc/frm_Rpt_DanhMucVTYT.aspx" Text="Danh s&#225;ch Vật tư y tế"
                                Value="Danh s&#225;ch Vật tư y tế" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        </asp:MenuItem>
                      
                    </asp:MenuItem>
                    <asp:MenuItem Text="|" Value="1"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/images/exit.gif" Text="Tho&#225;t" Value="exit" ></asp:MenuItem>
                </Items>
                <StaticMenuStyle HorizontalPadding="2px" VerticalPadding="0px" />
                <StaticMenuItemStyle ItemSpacing="2px" VerticalPadding="5px" />
                <DynamicHoverStyle BackColor="#EAEBE6" BorderStyle="Solid" BorderWidth="1px" />
                <StaticHoverStyle BackColor="#EAEBE6" Font-Names="Tahoma" ForeColor="Red"/>
            </asp:Menu>
        </td>
    </tr>
    <tr>
	    <td width="100%" align="center">
	        <span class="ajax" id="ajaxsodu" style="display:none;color:White;font-weight:bold;">
	            <img src="../images/processing.gif" alt="../images/processing.gif" border="0"/>&nbsp;&nbsp;đang kết chuyển số dư ...
	        </span>
	    </td>
	</tr>
</table>


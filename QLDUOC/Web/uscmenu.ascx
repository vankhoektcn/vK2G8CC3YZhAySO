<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscmenu.ascx.cs" Inherits="uscmenu" %>
<div class="sola">
    <div style="position: fixed; z-index: -1000; top: 0; width: 100%; height: 22px; background-color: #FBF8F1;
        left: 0; border-bottom: 1px solid #666666;">
    </div>
    <div style="overflow: auto">
        <asp:Menu ID="Menu1" BackColor="#FBF8F1" AccessKey="M" runat="server" DynamicEnableDefaultPopOutImage="false"
            Orientation="Horizontal" DynamicVerticalOffset="2" StaticEnableDefaultPopOutImage="False">
            <Items>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text=" Quản l&#253;" Value="QUANLY" Selectable="false" >
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/HS_TOATHUOC_View1.aspx" Text="BN có thuốc - chờ phát"
                        Value="PHIEUXUATTHEOTOA" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/HS_CLS_View.aspx" Text="BN không thuốc - chờ kiểm tra"
                        Value="KIEMTRADICHVU" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieunhapkho3.aspx?idloainhap=1&amp;IdKho=4" Text=" Phiếu nhập mua"
                        Value="PHIEUNHAPKHO" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieuxuatkho_XuatLe.aspx" Text=" Phiếu xuất kho ( Xuất cho KH lẻ )"
                        Value="PHIEUXUATLE" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieuxuatkho3.aspx" Text=" Phiếu xuất chuyển kho (Xuất cho c&#225;c khoa,P.P.T )"
                        Value="PHIEUXUATCHUYEN" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieuxuatkho_traNCC3.aspx?idkho=4&amp;loaixuat=3" Text=" Phiếu xuất trả nh&#224; cung cấp"
                        Value="PHIEUXUATTRANHACUNGCAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="phieunhapkho3_dieuchinh.aspx?idloainhap=5" Text=" Phiếu nhập điều chỉnh"
                        Value="PHIEUNHAPKHO" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieuxuatkho_HV3.aspx" Text=" Phiếu thanh l&#253; hỏng vở"
                        Value="PHIEUTHANHLYHONGVO"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=khoaduoc&IdKhoa=100"
                        Text=" Phiếu yêu cầu lãnh thuốc" Value="PHIEUYCLANH"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoaduoc&IdKhoa=100&LoaiTra=3"
                        Text=" Phiếu yêu cầu trả thuốc" Value="PHIEUYCTRA"></asp:MenuItem>
                    <asp:MenuItem Text=" Phiếu nhập hỏng vở" Value="PHIEUNHAPHONGVO" NavigateUrl="~/QLDUOC/Web/phieuxuatkho3.aspx?IdKho2=51">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="DUYETYEUCAU_" Selectable="false"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/hoso.gif" Text="Duyệt y&#234;u cầu " Value="DUYETYEUCAU" Selectable="false">
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCXuat1.aspx?dkmenu=khoaduoc"
                        Text=" Duyệt yêu cầu lãnh" Value="DUYETPHIEULINH"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoaduoc"
                        Text=" Duyệt yêu cầu trả dư sử dụng" Value="DSPHIEUYEUCAUTRA_DU"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/Yc_PhieuYCTra1.aspx?dkmenu=khoaduoc&IsHongVo=1" Text="Duyệt yêu cầu trả do hư hỏng vỡ"
                        Value="PHIEUYEUCAUNHAPHONGVO"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/noitru_BaoCao/KiemTraDuTru.aspx?dkmenu=khoaduoc"
                        Text="Chi tiết dự trù" Value="KIEMTRADUTRU"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/images/folder_documents.png" Text="Danh mục" Value="DANHMUC" Selectable="false">
                    <asp:MenuItem NavigateUrl="frm_DM_Kho.aspx" Text=" Danh mục kho" Value="DMKHO" ImageUrl="../images/arrow2.gif">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="nhacungcap2.aspx" Text=" Danh mục nh&#224; cung cấp" Value="DMNHACUNGCAP"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="frm_DM_HangSX.aspx" Text=" Danh mục H&#227;ng SX" Value="DMHANGSANXUAT"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="frm_DM_NuocSX.aspx" Text=" Danh mục Nước SX" Value="DMNUOCSANXUAT"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="frm_DM_NhomThuoc.aspx" Text=" Danh mục nh&#243;m" Value="DMNHOMTHUOC"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="frm_DM_PhanNhom.aspx" Text=" Danh mục ph&#226;n nh&#243;m"
                        Value="DMPHANNHOM" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="thuoc1.aspx?LoaiThuocID=1" Text=" Danh mục thuốc" Value="DMTHUOC"
                        ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="thuoc1.aspx?LoaiThuocID=1&IsQPTBH=1" Text=" Danh mục thuốc"
                        Value="DMTHUOC_QPTBH" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="thuoc_hoachat1.aspx?LoaiThuocID=2" Text="Danh mục h&#243;a chất"
                        Value="DMHOACHAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="thuoc_vtyt1.aspx?LoaiThuocID=4" Text="Danh mục vật tư y tế"
                        Value="DMVATTUYTE" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="frm_DM_DonViTinh.aspx"
                        Text="Danh mục đơn vị t&#237;nh" Value="DMDONVITINH"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="frm_DM_CachDung.aspx"
                        Text="Danh mục c&#225;ch d&#249;ng" Value="DMCACHDUNG"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="frm_DM_DoiTuong.aspx"
                        Text="Danh mục đối tượng quản l&#253;" Value="DMDOITUONG"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieunhapkho3_dauky.aspx?idloainhap=3" Text="Khai b&#225;o số dư cuối kỳ"
                        Value="SODUCUOIKY" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/hS_TONKHO_Save3_new.aspx" Text="Kiểm &amp; Điều chỉnh kho"
                        Value="NHAPXUATTON2" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="KB_Parameter2.aspx" Text="Tham số hệ thống"
                        Value="THAMSOHETHONG"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="frm_DM_DinhMucTonKho.aspx"
                        Text="Định mức tồn kho" Value="DINHMUCTONKHO"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/QLDUOC/Web/THUOC_COSOTUTRUC3.aspx?idkho=5" Text=" Cơ số tủ trực"
                        Value="COSOTUTRUC"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/thuoc2.aspx?loaithuocid=1&dkmenu=khoaduoc"
                        Text=" Phân bổ thuốc bảo hiểm" Value="phanbothuoc"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/thuoc2.aspx?loaithuocid=2&dkmenu=khoaduoc"
                        Text=" Phân bổ hóa chất bảo hiểm" Value="phanbohoachat"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/thuoc2.aspx?loaithuocid=3&dkmenu=khoaduoc"
                        Text=" Phân bổ dụng cụ bảo hiểm" Value="phanbodungcu"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/thuoc2.aspx?loaithuocid=4&dkmenu=khoaduoc"
                        Text=" Phân bổ vtyt bảo hiểm" Value="phanbovtyt"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="hS_BangGiaThuoc_View.aspx?IDKHO_NHAP=4"
                        Text=" Cập nhật bảng giá" Value="suabanggia"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/DanhMuc_JSon/web/HS_THUOCNHOM2.aspx?dkmenu=khoaduoc"
                        Text=" Phân bổ nhóm thuốc" Value="THUOC_PHANNHOM"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem ImageUrl="../images/chungtu.gif" Text=" B&#225;o c&#225;o" Value="BAOCAO" Selectable="false">
                    <asp:MenuItem Text="B&#225;o c&#225;o nhập xuất tồn" Value="NHAPXUATTON" Selectable="false">
                        <asp:MenuItem NavigateUrl="hS_TONKHO_View3.aspx" Text="B&#225;o c&#225;o tổng hợp xuất nhập tồn"
                            Value="TONGHOPNHAPXUATTON" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="frmTheKho.aspx" Text="B&#225;o c&#225;o chi tiết xuất nhập tồn(thẻ kho)"
                            Value="CHITIETNHAPXUATTON_KD" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="frmTheKho.aspx?IdKho=5" Text="B&#225;o c&#225;o chi tiết xuất nhập tồn(thẻ kho)"
                            Value="CHITIETNHAPXUATTON_QPT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="Rpt_BienBanKiemNhap.aspx" Text="Bi&#234;n bản kiểm nhập"
                            Value="BIENBANKIEMNHAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="Rpt_DuTruThuocYEAR.aspx"
                            Text="Dự tr&#249; thuốc theo năm" Value="DUTRUTHUOCTHEONAM"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" Text="Dự tr&#249; thuốc theo th&#225;ng"
                            Value="DUTRUTHUOCTHEOTHANG" NavigateUrl="Rpt_DuTruThuocMONTH.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="rpt_TinhHinhSuDungThuoc.aspx"
                            Text="B.C.S.D thuốc" Value="BAOCAOSUDUNGTHUOC"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="rpt_SuDungThuocGN.aspx"
                            Text="B.C.S.D thuốc g&#226;y nghiện" Value="BAOCAOSUDUNGTHUOCGAYNGHIEN"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" Text="B.C.S.D thuốc hướng t&#226;m thần"
                            Value="BAOCAOSUDUNGTHUOCHUONGTAMTHAN" NavigateUrl="rpt_SuDungThuocHTT.aspx">
                        </asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" Text="B.C.S.D thuốc kh&#225;ng sinh"
                            Value="BAOCAOSUDUNGTHUOCKHANGSINH" NavigateUrl="rpt_SuDungThuocKS.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="rpt_SuDungVTYT.aspx" Text="B.C.S.D VTYT"
                            Value="BAOCAOSUDUNGVATTUYTE"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/rpt_SuDungHoaChat.aspx"
                            Text="B.C.S.D H&#243;a chất" Value="BAOCAOSUDUNGHOACHAT"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/zDanhSachThuocSapHetHan3.aspx"
                            Text="Danh s&#225;ch thuốc sắp hết hạn" Value="DANHSACHTHUOCSAPHETHAN"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" Text="B&#225;o c&#225;o sử dụng thuốc nội tr&#250;"
                            Value="BAOCAOSUDUNGTHUOCNOITRU" Selectable="false">
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/rpt_TongXuat.aspx"
                                Text="Tổng xuất" Value="TONGXUAT"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/rpt_KhoaTra.aspx"
                                Text="Khoa trả" Value="KHOATRA"></asp:MenuItem>
                            <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="~/QLDUOC/Web/rpt_KhoaTra.aspx?XuatTheoKhoa=1"
                                Text="Xuất theo khoa" Value="XUATTHEOKHOA"></asp:MenuItem>
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Danh s&#225;ch" Value="DANHSACH" Selectable="false">
                        <asp:MenuItem NavigateUrl="phieunhapchuyenkho1.aspx" Text="Danh s&#225;ch phiếu nhập chuyển"
                            Value="DANHSACHPHIEUNHAPCHUYENKHO" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="phieunhapkho1.aspx?idkho=4&amp;idloaithuoc=1" Text="Danh s&#225;ch phiếu nhập mua"
                            Value="DANHSACHPHIEUNHAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="chitietphieunhapkho1.aspx" Text="Chi tiết phiếu nhập"
                            Value="DANHSACHCHITIETPHIEUNHAP" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="phieuxuatkho1.aspx?IdKho=4" Text="Danh s&#225;ch phiếu xuất"
                            Value="DANHSACHPHIEUXUAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="../images/arrow2.gif" NavigateUrl="phieuxuatkho1_2.aspx?idkho2=4&amp;idkho=5&amp;loaixuat=4&amp;IdLoaiThuoc=1"
                            Text="Danh s&#225;ch phiếu xuất trả khoa dược" Value="DANHSACHPHIEUTRAKHOADUOC">
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="frmNhapXuatTonTongHop.aspx" Text="Danh s&#225;ch nhập xuất tổng hợp 2"
                            Value="DANHSACHPHIEUNHAPXUAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        
                         
                         
                        <asp:MenuItem NavigateUrl="HS_TOATHUOC_View1.aspx?IsDaXuat=1" Text="BN có thuốc - đã phát"
                            Value="DANHSACHTOATHUOCDACAPPHAT" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/HS_CLS_View.aspx?IsDaXuat=1" Text="BN không thuốc - đã kiểm tra"
                        Value="DANHSACHBNDAKIEMTRA" ImageUrl="../images/arrow2.gif"></asp:MenuItem>
                        <asp:MenuItem Text="Danh s&#225;ch phiếu nhập hỏng vở" Value="DSPHIEUNHAPHONGVO"
                            NavigateUrl="~/QLDUOC/Web/phieuxuatkho1.aspx?IdKho2=51"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/phieuxuatkho_HV1.aspx" Text="Danh s&#225;ch phiếu thanh l&#253; hỏng vỡ"
                            Value="DSPHIEUTHANHLYHONGVO"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/QLDUOC/Web/zKiemDuyet1.aspx" Text="Danh sách so sánh duyệt phát thiếu"
                            Value="DANHSATCHKIEMDUYETTHIEU"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Bảo hiểm y tế" Value="bhyt" Selectable="false">
                           <asp:MenuItem NavigateUrl="~/VienPhi_BH/frm_Rpt_Mau20.aspx?dkMenu=khoaduoc" Text="Biểu mẫu 20"
                            Value="Biểu mẫu 20"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="|" Value="|" Selectable="false"></asp:MenuItem>
                <asp:MenuItem Text="Hệ Thống" Value="hethong" Selectable="false">
                    <asp:MenuItem Text="Thay đổi mật khẩu" Value="CHANGEPASS" NavigateUrl="~/QuanLyNguoiDung/changepass.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Tho&#225;t" Value="EXIT" NavigateUrl="javascript:window.close();"></asp:MenuItem>
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

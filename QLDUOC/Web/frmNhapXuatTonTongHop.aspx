<%@ Page Language="C#" MasterPageFile="~/QLDUOC/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmNhapXuatTonTongHop.aspx.cs" Inherits="rpt_NhapXuatTon2" Title="Báo cáo nhập xuất tồn tổng hợp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
        .div-Out
        {
            width: 30%;
            height: 40px;
        }
    </style>
    <script type="text/javascript">
    $(document).ready(function () {
                                          if($.mkv.queryString("idKhoa")!=null && $.mkv.queryString("idKhoa")!="" && $.mkv.queryString("idKhoa")!="4")
                                                    $("#div_KhoNhap").css("display", "none");
                                  });
        function ChonSanPham(obj) {
            $(obj).unautocomplete().autocomplete("../ajax/frm_PhieuNhapKho_ajax.aspx?do=ChonSanPham&LoaiThuocID=" + document.getElementById('ctl00_body_ddl_loaithuoc').value,
                { formatItem: function (data) {
                    return data[0];
                        }, width: 300, scroll: true
                }
             );

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="body-div">
        <p class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Báo cáo nhập xuất tồn tổng hợp")%>
        </p>
        <div class="in-a">
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Từ ngày")%>
                </h4>
                <p>
                    <input type="text" id="txtTuNgay" onfocus="$(this).datepick();$(this).validDate()"
                        runat="server" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đến ngày")%>
                </h4>
                <p>
                    <input type="text" id="txtDenNgay" onfocus="$(this).datepick();$(this).validDate()"
                        runat="server" />
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho xuất")%>
                </h4>
                <p>
                    <asp:DropDownList ID="ddl_khoxuat" runat="server" Width="200px">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out" id="div_KhoNhap">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho nhập")%>
                </h4>
                <p>
                    <asp:DropDownList ID="ddl_khonhap" runat="server" Width="200px">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Loại thuốc")%>
                </h4>
                <p>
                    <asp:DropDownList ID="ddl_loaithuoc" runat="server" Width="100px">
                    </asp:DropDownList>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên thuốc")%>
                </h4>
                <p>
                    <asp:TextBox runat="server" ID="txtTenThuoc" onfocus="ChonSanPham(this);"></asp:TextBox>
                </p>
            </div>
            <div class="div-Out">
                <h4>
                    <asp:Button ID="btnTim" runat="server" Text="Lấy Danh sách" OnClick="btnTim_Click"
                        Width="120px" />
                    <asp:Button ID="btnXuatExcel" runat="server" Text="Xuất Excel" OnClick="btnXuatExcel_Click"
                        Width="120px" />
                </h4>
            </div>
        </div>
        <div style="clear:both">
               <asp:DataGrid ID="dgr" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                CssClass="jtable" BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" PageSize="50"
                TabIndex="12" Width="100%" BackColor="#DEBA84" BorderStyle="None" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"></SelectedItemStyle>
                <PagerStyle Mode="NumericPages" HorizontalAlign="Center" Font-Names="Arial" Font-Size="Small"
                    ForeColor="#8C4510"></PagerStyle>
                <AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="dgrSelectItem">
                </AlternatingItemStyle>
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="#FFF7E7" CssClass="dgrNoSelectItem"
                    ForeColor="#8C4510"></ItemStyle>
                <Columns>
                    <asp:BoundColumn DataField="STT" HeaderText="STT">
                        <HeaderStyle Width="2%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                            Font-Strikeout="False" Font-Underline="False"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="LoaiNX" HeaderText="Loại NX"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Tenthuoc" HeaderText="T&#234;n sp,hh">
                        <HeaderStyle Width="15%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                            Font-Strikeout="False" Font-Underline="False"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TenDVT" HeaderText="ĐVT"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NgayThang" HeaderText="Ng&#224;y th&#225;ng" DataFormatString="{0:dd/MM/yy HH:mm}">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SoPhieu" HeaderText="Số phiếu"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DoiTuong" HeaderText="Đối tượng"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SoLuong" HeaderText="SL"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DonGia" DataFormatString="{0:N0}" HeaderText="Đơn gi&#225;">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ThanhTien" DataFormatString="{0:N0}" HeaderText="Th&#224;nh tiền">
                    </asp:BoundColumn>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" CssClass="header" Font-Bold="True" ForeColor="White">
                </HeaderStyle>
            </asp:DataGrid>
        </div>
    </div>
</asp:Content>

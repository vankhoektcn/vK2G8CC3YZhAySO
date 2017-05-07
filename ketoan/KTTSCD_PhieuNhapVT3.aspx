<%@ Page Language="C#" MasterPageFile="~/ketoan/MasterPage_KT.master" AutoEventWireup="true"
    CodeFile="KTTSCD_PhieuNhapVT3.aspx.cs" Inherits="PHIEU_NHAP_VT" Title="PHIEU_NHAP_VT" %>

<%@ Register Src="Menu_KT/uscmenuKT_TaiSan.ascx" TagName="uscmenuKT_TaiSan" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <script type="text/javascript" src="javascript/KTTSCD_PhieuNhapVT3.js">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
<uc1:uscmenuKT_TaiSan ID="UscmenuKT_TaiSan1" runat="server" />
    <div class="body-div">
        <div class="header-div">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phiếu Nhập Tài Sản")%>
        </div>
        <div class="in-a">
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số Phiếu:")%>
                </div>
                <div class="div-Right">                    
                    <input mkv="true" id="so_phieu" disabled="disabled" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Nhập:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="ngay_nhap" type="text" onfocus="Find(this);chuyenphim(this);$(this).validDate()"
                         style="width: 50%" />
                    (dd\MM\yyyy)
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Loại Nghiệp Vụ:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="manghiepvu" type="hidden" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                    <input mkv="true" id="mkv_manghiepvu" type="text" onfocus="Find(this);chuyenphim(this);loainghiepvuSearch(this);"
                        style="width: 90%" class="down_select" />
                </div>
            </div>
           
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên NCC:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="ten_ncc" type="text" onfocus="Find(this);chuyenphim(this);nhacungcapSearch1(this);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Địa Chỉ NCC:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="diachi_ncc" disabled type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </div>
            </div>
            
             <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên người giao")%>
                </div>
                <div class="div-Right">
                     <input mkv="true" id="ten_nguoi_giao" type="text" 
                        style="width: 90%" />
                    <input mkv="true" id="ma_ncc" type="hidden" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                    <input mkv="true" id="mkv_ma_ncc" type="hidden" onfocus="Find(this);chuyenphim(this);nhacungcapSearch(this);"
                        style="width: 90%" />
                </div>
            </div>
            
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số Hóa Đơn:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="so_hd" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Lập HĐ:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="ngay_lap_hd" type="text" onfocus="Find(this);chuyenphim(this);$(this).validDate()"
                         style="width: 50%" />
                    (dd\MM\yyyy)
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Hạn thanh toán:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="hanthanhtoan" type="text" onfocus="Find(this);chuyenphim(this); $(this).validDate()"
                         style="width: 50%" />
                    (dd\MM\yyyy)
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số Seri:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="so_seri" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="idkho" type="hidden" onfocus="Find(this);chuyenphim(this);" />
                    <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);khoSearch(this.id);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK Có:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="tk_co" type="text" onfocus="Find(this);chuyenphim(this);ShowTaiKhoan(this.id);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK Chiết Khấu:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="tkchietkhau" type="text" onfocus="Find(this);chuyenphim(this);ShowTaiKhoan(this.id);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK VAT:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="tkvat" type="text" onfocus="Find(this);chuyenphim(this);ShowTaiKhoan(this.id);"
                        style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("VAT(%):")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="vat" type="text" onfocus="Find(this);chuyenphim(this);" style="width: 90%" />
                </div>
            </div>
            <%--<div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngoại Tệ:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="loai_nt" type="hidden" onfocus="Find(this);chuyenphim(this);"/>
        <input mkv="true" id="mkv_loai_nt" type="text" onfocus="Find(this);chuyenphim(this);ngoaiteSearch(this);" onblur="" style="width:90%" class="down_select"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tỷ Giá:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ty_gia" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </div>
 </div>--%>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Loại Phí:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="id_loaiphi" type="hidden" value='2004' onfocus="Find(this);chuyenphim(this);" />
                    <input mkv="true" id="mkv_id_loaiphi" type="text" value='Trị' onfocus="Find(this);chuyenphim(this);loaiphiSearch(this);"
                        onblur="" style="width: 90%" class="down_select" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tổng Phí:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="tongphi" type="text" onfocus="Find(this);chuyenphim(this);"
                        onblur="TestSo(this,false,true);tinhphi();" style="width: 90%" />
                </div>
            </div>
            <div class="div-Out">
                <div class="div-Left">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Diễn Giải:")%>
                </div>
                <div class="div-Right">
                    <input mkv="true" id="dien_giai" type="text" onfocus="Find(this);chuyenphim(this);"
                        style="width: 90%" />
                </div>
            </div>
        </div>
        <div class="reload" onclick="loadTableAjaxPHIEU_NHAP_VT_CT($.mkv.queryString('idkhoachinh'))">
        </div>
        <div id="tableAjax_PHIEU_NHAP_VT_CT" class="in-b" style="overflow: auto">
        </div>
        <div align="right">
            <table>
                <tr>
                    <td>
                        <b>Tổng tiền trước thuế:</b><input type="text" style="text-align:right;" id="txttongtientruocthue" readonly="readonly" /></td>
                    <td>
                    </td>
                    <td>
                        <b>Tổng Chiết khấu:</b><input type="text" id="txtchietkhau" style="text-align:right;" onblur='' readonly="readonly" /></td>
                    <td>
                    </td>
                    <td>
                        <b>Tổng Tiền thuế:</b><input type="text" id="txttienthue" style="text-align:right" onblur='tinhtien(this);'
                            readonly="readonly" /></td>
                    <td>
                    </td>
                    <td>
                        <b>Tổng tiền:</b><input id="txtthanhtien" type="text" style="text-align:right;" onfocus="Find(this);chuyenphim(this);"
                            readonly="readonly" /></td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="body-div-button">
        <div class="in-a">
            <input id="luu" edit="<%=StaticData.HavePermision(this, "KeToanTSCD_KTTSCD_PhieuNhapVT3_Sua") %>"
                add="<%=StaticData.HavePermision(this, "KeToanTSCD_KTTSCD_PhieuNhapVT3_Them") %>"
                type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " />
            <input id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" />
            <input id="xoa" type="button" style="display: none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" />
            <input id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" />
            <input id="print" type="button" onclick="inphieunhap();" value="In PN" />
            <input id="Button2" type="button" onclick="laphieuchi();" value="Chi tiền phí" />
        </div>
    </div>
   
</asp:Content>

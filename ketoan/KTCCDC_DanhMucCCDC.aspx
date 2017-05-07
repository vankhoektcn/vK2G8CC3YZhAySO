<%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="KTCCDC_DanhMucCCDC.aspx.cs" Inherits="ketoan_KTCCDC_DanhMucCCDC" %>

<%@ Register Src="Menu_KT/uscmenuKT_CCDC.ascx" TagName="uscmenuKT_CCDC" TagPrefix="uc1" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="javascript/KTCCDC_DanhMucCCDC.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Danh Mục Công Cụ Dụng Cụ")%>
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã CCDC:")%>
     </div>
     <div class="div-Right">
         <uc1:uscmenuKT_CCDC ID="UscmenuKT_CCDC1" runat="server" />
         <input type="hidden" id="quyenthem" value="<%=StaticData.HavePermision(this.Page, "KeToanCCDC_KTCCDC_DanhMucCCDC_Them")%>"/>
        <input mkv="true" id="MaTS" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên CCDC:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TenTaiSan" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Nguyên Giá:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="NguyenGia" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Khấu Hao LK:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="KhauHaoLK" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Nhập:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="NgayNhap" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Khấu Hao:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="NgayKhauHao" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK Nguyên Giá:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TKNguyenGia" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK Khấu Hao:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TKKhauHao" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TK Chi Phí:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="TKChiPhi" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Giá Trị Còn Lại:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="GiaTriConLai" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="idkho" type="hidden" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
        <input mkv="true" id="mkv_idkho" type="text" onfocus="Find(this);chuyenphim(this);khoSearch1(this);" onblur="" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số Lượng Hiện Có:")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="soluong_hienco" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </div>
 </div>
         </div></div>
 <div class="body-div-button">
 <div class="in-a">
             <%--<input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />--%>
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </div>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="tableAjax_DanhMucTaiSan">
         </div>
 <div class="in-c">
                     <input id="luuTable_2" type="button" disabled="<%=StaticData.HavePermision(this, "KeToanCCDC_KTCCDC_DanhMucCCDC_Sua") %>" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </div>
         </div>
 </asp:Content>


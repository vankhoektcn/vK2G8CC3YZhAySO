 <%@ Page Language="C#" MasterPageFile="~/ketoan/MasterPage_KT.master" AutoEventWireup="true" CodeFile="KTTSCD_PhieuXuatVT3.aspx.cs" Inherits="PHIEU_XUAT_VT" Title="PHIEU_XUAT_VT" %>

<%@ Register Src="Menu_KT/uscmenuKT_TaiSan.ascx" TagName="uscmenuKT_TaiSan" TagPrefix="uc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="javascript/KTTSCD_PhieuXuatVT3.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
 <uc1:uscmenuKT_TaiSan ID="UscmenuKT_TaiSan1" runat="server" />
     <div class="body-div">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Phiếu Xuất Tài Sản")%>
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Số Phiếu")%>
     </div>
     <div class="div-Right">         
        <input mkv="true" id="so_phieu" disabled="disabled" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Xuất")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ngay_xuat" type="text" onfocus="Find(this);chuyenphim(this);$(this).validDate();"  style="width:50%"/>
        (dd\MM\yyyy)
     </div>
 </div>
<%-- <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Mã Phòng")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ma_phong" type="text" onfocus="Find(this);chuyenphim(this);phongSearch(this);" style="width:90%"/>
     </div>
 </div>--%>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Tên Khoa")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ten_phong" type="text" onfocus="Find(this);chuyenphim(this);phongSearch1(this);" style="width:90%"/>
     </div>
 </div>
 
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Người nhận")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="ma_phong" type="hidden" />
        <input mkv="true" id="ten_nguoi_nhan" type="text"style="width:90%"/>
     </div>
 </div>
 
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Diễn Giải")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="dien_giai" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
         </div>
         <div class="reload" onclick="loadTableAjaxPHIEU_XUAT_VT_CT($.mkv.queryString('idkhoachinh'))"></div>
         <div id="tableAjax_PHIEU_XUAT_VT_CT"   class="in-b" style="overflow:auto">
             
         </div>
         <div align="right">
            <table>
                <tr>
                    <td><b>Tổng tiền:</b><input id="txttongtien" type="text" onfocus="Find(this);chuyenphim(this);" readonly="readonly" /></td>
                    <td></td>
                </tr>
            </table>
         </div>
         </div><div class="body-div-button">
             <div class="in-a">
                 <input  id="luu" type="button"  edit="<%=StaticData.HavePermision(this, "KeToanTSCD_KTTSCD_PhieuXuatVT3_Sua") %>" add="<%=StaticData.HavePermision(this, "KeToanTSCD_KTTSCD_PhieuXuatVT3_Them") %>" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> "
                      />
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                      />
                 <input  id="xoa" type="button" style="display:none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                      />
                 <input  id="in" type="button"  onclick="inphieuxuat();" value="In PX"
                      />
                 <input  id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" 
                      />
                   
             </div>
         </div>
 </asp:Content>

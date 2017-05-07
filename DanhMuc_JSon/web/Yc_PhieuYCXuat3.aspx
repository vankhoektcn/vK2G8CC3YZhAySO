 <%@ Page Language="C#" MasterPageFile="~/DanhMuc_JSon/MasterPage.master" AutoEventWireup="true" CodeFile="Yc_PhieuYCXuat3.aspx.cs" Inherits="Yc_PhieuYCXuat" Title="Yc_PhieuYCXuat" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/Yc_PhieuYCXuat3.js">
     </script>
     <style type="text/css">
     .div-Out{
        width: 325px;
     }
     </style>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PHIẾU YÊU CẦU LÃNH")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoPhieuYc")%>
     </h4>
     <p>
        <input mkv="true" id="SoPhieuYc" onfocus='Find(this);' type="text" style="width:90%"/>
     </p>
 </div>
 
 
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày YC")%>
     </h4>
     <p>
        <input mkv="true" id="NgayYc" isGet="true" type="text" style="width:80px;" onfocus='Find(this);' onblur="$.TestDate(this);" />
        <input mkv="true" id="GioYc"  type="text" style="width:20px;" />:
        <input mkv="true" id="PhutYC"  type="text" style="width:20px;" />
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho yêu cầu")%>
     </h4>
     <p>
           <select id="IdKhoYc" mkv="true" onfocus="chuyenphim(this);" style="width: 90%;">
        </select>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Kho duyệt")%>
     </h4>
     <p>
            <select id="IdKhoDuyet" mkv="true" onfocus="chuyenphim(this);" style="width: 90%;">
        </select>
     </p>
 </div>
  
 
 <div class="div-Out" >
      <h4>
        Duyệt in 
         <input mkv="true" id="IsDuyetIn" disabled="disabled" type="checkbox" onclick="checkDuyetAllTable(this,'gridTable','IsDuyetIn');" /> 
     </h4>
     <p>
     Duyệt phát
       <input mkv="true" id="IsDuyetPhat" disabled="disabled" type="checkbox" />
       Dự trù
       <input mkv="true" id="IsDuTru"  type="checkbox" />
      
 </div>
 
  
 <div class="div-Out" >
      <h4>
         Phiếu xuất
     </h4>
     <p>
        <input mkv="true" id="maphieuxuat" onfocus='Find(this);' type="text" style="width:90%"/>
     </p>
 </div>

 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Đối tượng")%>
     </h4>
     <p>
     
       <select id="LoaiThuocID" mkv="true" onfocus="chuyenphim(this);" style="width: 90%;">     </select>
        
        
     </p>
 </div>
 <div class="div-Out" style="width: 650px;" id="div_LayDS">
     <p style="width: 650px;">
        Từ ngày :
        <input mkv="true" id="TuNgay" isGet="true" type="text" style="width:80px;margin-left: 25px;" onfocus='Find(this);' onblur="$.TestDate(this);" />
        <input mkv="true" id="TuGio"  type="text" style="width:20px;" />:
        <input mkv="true" id="TuPhut"  type="text" style="width:20px;" />
        Đến ngày :
        <input mkv="true" id="DenNgay" isGet="true" type="text" style="width:80px;" onfocus='Find(this);' onblur="$.TestDate(this);" />
        <input mkv="true" id="DenGio"  type="text" style="width:20px;" />:
        <input mkv="true" id="DenPhut"  type="text" style="width:20px;" />
        <input mkv="true" id="btngetList" value="Lấy Danh Sách" type="button" style="width: 110px;margin-left:10px;"/>
     </p>
        
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Duyệt")%>
     </h4>
     <p>
        <input mkv="true" id="NgayDuyet" isGet="true" type="text" style="width:80px;" onfocus='Find(this);' onblur="$.TestDate(this);" />
        <input mkv="true" id="GioDuyet"  type="text" style="width:20px;" />:
        <input mkv="true" id="PhutDuyet"  type="text" style="width:20px;" />
        <input mkv="true" id="IsTheoCD"  type="hidden" value="0" style="width:20px;" />
        <input mkv="true" id="perDuyetIn" type="hidden" value="0" />
        <input mkv="true" id="isviewIn" type="hidden" value="0" />
        <input mkv="true" id="perDuyetPhat" type="hidden" value="0" />
        <input mkv="true" id="isDaPhat" type="hidden" value="0" />
        <input mkv="true" id="IsKhoBN" type="hidden" value="0" />
     </p>
 </div>
 
         </div>
         <a id="reload" class="reload" onclick="loadTableAjaxYc_PhieuYcXuatChiTiet($.mkv.queryString('idkhoachinh'))"></a>
         <br />
         <div id="tableAjax_Yc_PhieuYcXuatChiTiet"   class="in-b">
             
         </div>
         </div><div class="body-div-button">
             <p class="in-a">
                 <input  id="luu" edit="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Edit") %>" add="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Add") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> "
                      style="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Add")?"":"display:none" %>"/>
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                      />
                 <input  id="xoa" delete="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Delete") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                      style="<%=Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_delete")?"":"display:none" %>"/>
                 <input  id="btnprint" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("print") %>" 
                      style="display:none"/>
                 <input  id="bntduyetIn" type="button" value="Duyệt In" 
                      style="<%=Userlogin_new.HavePermision(this, "xetduyet1")?"":"display:none" %>"/>
                 <input  id="btnDuyetPhat" type="button" value="Duyệt Phát" 
                      style="<%=Userlogin_new.HavePermision(this, "xetduyet1")?"":"display:none" %>"/>
                 <input  id="btnHuyDuyetPhat"  type="button" value="Hủy Duyệt phát" 
                      style="width: 110px;<%=Userlogin_new.HavePermision(this, "xetduyet1")?"":"display:none" %>"/>
                      
                 <input  id="Thoat" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("Thoát") %>"                   />
             </p>
         </div>
 </asp:Content>

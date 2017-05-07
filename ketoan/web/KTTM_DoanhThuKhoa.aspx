 <%@ Page Language="C#" MasterPageFile="~/MasterPage_New.master" AutoEventWireup="true" CodeFile="KTTM_DoanhThuKhoa.aspx.cs" Inherits="doanhthu_khoa_kt" Title="doanhthu_khoa_kt" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
     <script type="text/javascript" src="../javascript/KTTM_DoanhThuKhoa.js">
     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("doanhthu_khoa_kt")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sophieu")%>
     </h4>
     <p>
        <input mkv="true" id="sophieu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaylap")%>
     </h4>
     <p>
        <input mkv="true" id="ngaylap" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkhoa")%>
     </h4>
     <p>
        <input mkv="true" id="idkhoa" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nguoilienhe")%>
     </h4>
     <p>
        <input mkv="true" id="nguoilienhe" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tkno")%>
     </h4>
     <p>
        <input mkv="true" id="tkno" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tkco")%>
     </h4>
     <p>
        <input mkv="true" id="tkco" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tkvat")%>
     </h4>
     <p>
        <input mkv="true" id="tkvat" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tkck")%>
     </h4>
     <p>
        <input mkv="true" id="tkck" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("vat")%>
     </h4>
     <p>
        <input mkv="true" id="vat" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("doanhthu")%>
     </h4>
     <p>
        <input mkv="true" id="doanhthu" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tienthue")%>
     </h4>
     <p>
        <input mkv="true" id="tienthue" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tienchietkhau")%>
     </h4>
     <p>
        <input mkv="true" id="tienchietkhau" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tongtien")%>
     </h4>
     <p>
        <input mkv="true" id="tongtien" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("diengiai")%>
     </h4>
     <p>
        <input mkv="true" id="diengiai" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%;padding:1px"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythu1")%>
     </h4>
     <p>
        <input mkv="true" id="ngaythu1" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythu2")%>
     </h4>
     <p>
        <input mkv="true" id="ngaythu2" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 <div class="div-Out" style="display:none">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loaitien")%>
     </h4>
     <p>
        <input mkv="true" id="loaitien" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out" style="display:none">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("doanhthu_nt")%>
     </h4>
     <p>
        <input mkv="true" id="doanhthu_nt" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out" style="display:none">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tong_tien_nt")%>
     </h4>
     <p>
        <input mkv="true" id="tong_tien_nt" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
         </div>
         <a class="reload" onclick="loadTableAjaxdoanhthu_khoa_kt_ct($.mkv.queryString('idkhoachinh'))"></a>
         <div id="tableAjax_doanhthu_khoa_kt_ct"   class="in-b" style="overflow:auto">             
         </div> 
         </div><div class="body-div-button">
             <p class="in-a">
                 <input  id="luu" edit="<%=Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_Edit") %>" add="<%=Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_Add") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> "
                      />
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                      />
                 <input  id="xoa" delete="<%=Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_Delete") %>" type="button" style="display:none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                      />
                 <input  id="timKiem" search="<%=Profess.Userlogin.HavePermision(this, "doanhthu_khoa_kt_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>" 
                      />
             </p>
         </div>
 
 </asp:Content>

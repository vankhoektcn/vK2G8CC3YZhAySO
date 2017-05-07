 <%@ Page Language="C#" MasterPageFile="~/ketoan/MasterPage_KT.master"AutoEventWireup="true" CodeFile="KTTSCD_Danhsachtaisan.aspx.cs" Inherits="DanhMucTaiSan" Title="DanhMucTaiSan" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
 
    <script type="text/javascript" src="javascript/KTTSCD_Danhsachtaisan.js" ></script> 
         
     <script type="text/javascript" src="masterpage_js/jquery-1.6.1.min.js"></script>
   
    <script src="masterpage_js/jquery-ui.js" type="text/javascript"> </script>

    <script src="masterpage_js/jquery.autocomplete.new.js" type="text/javascript"> </script>

    <script src="masterpage_js/jquery.validate.js" type="text/javascript"> </script>

    <script src="masterpage_js/myscriptvalid.js" type="text/javascript"> </script>

    <script src="masterpage_js/timepicker.js" type="text/javascript"> </script>

    <script src="masterpage_js/myscript.jqr.js" type="text/javascript"> </script>

<%--    <script src="masterpage_js/myscript.js" type="text/javascript"> </script>
--%>
    <link type="text/css" href="masterpage_css/default.css" rel="Stylesheet" />   
    <link type="text/css" href="masterpage_css/timepicker.css" rel="Stylesheet" />
    <link type="text/css" href="masterpage_css/jquery-ui.css" rel="Stylesheet" />
    <link type="text/css" href="masterpage_css/jquery.autocomplete.new.css" rel="Stylesheet" />
    <link type="text/css" href="masterpage_css/DefaultBV.css" rel="Stylesheet" />
    <link type="text/css" href="masterpage_css/nvk_jtable.css" rel="Stylesheet" />        
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div class="body-div">
             <p class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("DanhMucTaiSan")%>
           </p>
 <div class="in-a">
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("MaTS")%>
     </h4>
     <p>
        <input mkv="true" id="MaTS" type="text" onfocus="Find(this);chuyenphim(this);" style="width:50%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TenTaiSan")%>
     </h4>
     <p>
        <input mkv="true" id="TenTaiSan" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NguyenGia")%>
     </h4>
     <p>
        <input mkv="true" id="NguyenGia" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("KhauHaoLK")%>
     </h4>
     <p>
        <input mkv="true" id="KhauHaoLK" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayNhap")%>
     </h4>
     <p>
        <input mkv="true" id="NgayNhap" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayKhauHao")%>
     </h4>
     <p>
        <input mkv="true" id="NgayKhauHao" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoNamKH")%>
     </h4>
     <p>
        <input mkv="true" id="SoNamKH" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TKNguyenGia")%>
     </h4>
     <p>
        <input mkv="true" id="TKNguyenGia" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("TKKhauHao")%>
     </h4>
     <p>
        <input mkv="true" id="TKKhauHao" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("SoHoaDonNhap")%>
     </h4>
     <p>
        <input mkv="true" id="SoHoaDonNhap" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayLapHoaDon")%>
     </h4>
     <p>
        <input mkv="true" id="NgayLapHoaDon" type="text" onfocus="Find(this);chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("GiaTriConLai")%>
     </h4>
     <p>
        <input mkv="true" id="GiaTriConLai" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idkho")%>
     </h4>
     <p>
        <input mkv="true" id="idkho" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("soluong_hienco")%>
     </h4>
     <p>
        <input mkv="true" id="soluong_hienco" type="text" onfocus="Find(this);chuyenphim(this);" onblur="TestSo(this,false,true);" style="width:90%"/>
     </p>
 </div>
         </div></div>
 <div class="body-div-button">
 <p class="in-a">
             <input id="luuTable_1" type="button" style="margin-right:10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>" />
                 <asp:Button UseSubmitBehavior="false" ID="Button2" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>' />
             <input  id="timKiem" search="<%=Profess.Userlogin.HavePermision(this, "DanhMucTaiSan_Search") %>" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                       />
             </p>
 <a class="reload" onclick="Find(this)"></a>
         <div class="in-b" id="gridTable">
         </div>
 <p class="in-c">
                     <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'/>
                     
                 </p>
         </div>
 </asp:Content>

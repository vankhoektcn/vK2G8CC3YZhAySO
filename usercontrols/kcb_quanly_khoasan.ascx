<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_quanly_khoasan.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
 <script type="text/javascript" src="../javascript/kcb_khoasan.js">
     </script>
<style type="text/css">
    .body-out
    {
        width:985px
    }
</style>
 <div class="body-div" style="margin-top:-98px;border-top:none;">
             <div class="header-div">
                II. <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_quanly_khoangoai")%>
           </div>
 <div class="in-a">
 <div style="border-bottom:1px solid #cfcfcf;border-right:1px solid #cfcfcf;position:relative;display:table;float:left">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngayvaovien")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="giovaovien" type="text"  style="width:10%"/>
        <input mkv="true" id="phutvaovien" type="text"  style="width:10%"/>
        <input mkv="true" id="ngayvaovien" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:40%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out" style="clear:left">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tructiepvao")%>
     </div>
     <div class="div-Right">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("vaocapcuu")%>
        <input mkv="true" id="tructiepvaocapcuu" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("vaoKKB")%>
        <input mkv="true" id="tructiepvaoKKB" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("vaokhoa")%>
        <input mkv="true" id="tructiepvaokhoa" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 </div>
 <div style="border-bottom:1px solid #cfcfcf;border-right:1px solid #cfcfcf;position:relative;display:table;float:left">
  <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("noigioithieu")%>
     </div>
     <div class="div-Right">
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("coquan")%>
        <input mkv="true" id="coquangioithieu" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tuden")%>
        <input mkv="true" id="tuden" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("khac")%>
        <input mkv="true" id="khac" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:300px;clear:left">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("vaovienlan")%>
     </div>
     <div class="div-Right" style="width:54%">
        <input mkv="true" id="vaovienlan" type="text" onfocus="chuyenphim(this);" style="width:70%"/>
     </div>
 </div>
 </div>
 <div style="border-bottom:1px solid #cfcfcf;width:481px;border-right:1px solid #cfcfcf;position:relative;display:table;float:left;">
 <div style="clear:both;background-color:#f2f6f8;border-bottom:1px solid #efefef;padding:20px 0 10px 0;height:10px;color:green;">
    <div style="text-align:right;width:170px;float:left">
        Khoa
    </div>
    <div style="text-align:right;width:80px;float:left">
        Giờ
    </div>
    <div style="text-align:right;width:40px;float:left">
        Phút
    </div>
    <div style="text-align:right;width:90px;float:left">
        Ngày Tháng
    </div>
    <div style="text-align:right;width:90px;float:left">
        Số ngày ĐT
    </div>
 </div>
 <div class="div-Out" style="width:190px;">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("vao")%>
     </div>
     <div class="div-Right" style="width:50%;">
        <input mkv="true" id="vaokhoa" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:170px;padding-left:0;padding-right:20px">
     <div class="div-Right" style="width:100%;float:left;padding-left:20px">
        <input mkv="true" id="giovaokhoa" type="text"  style="width:10%"/>
        <input mkv="true" id="phutvaokhoa" type="text"  style="width:10%"/>
        <input mkv="true" id="thoigianvaokhoa" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
     </div>
 </div>
 <div class="div-Out" style="width:57px;padding-left:0;padding-right:20px">
     <div class="div-Right" style="width:100%;float:left;padding-left:20px">
        <input mkv="true" id="songaydieutri" type="text" onfocus="chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
 <div style="clear:both">
 </div>
 <div class="div-Out" style="width:190px;">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chuyentu")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="chuyentukhoa" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:170px;padding-left:0;padding-right:20px">
     <div class="div-Right" style="width:100%;float:left;padding-left:20px">
     <input mkv="true" id="giochuyentukhoa" type="text"  style="width:10%"/>
        <input mkv="true" id="phutchuyentukhoa" type="text"  style="width:10%"/>
        <input mkv="true" id="thoigianchuyentukhoa" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
     </div>
 </div>
  <div class="div-Out" style="width:57px;padding-left:0;padding-right:20px">
     <div class="div-Right" style="width:100%;float:left;padding-left:20px">
        <input mkv="true" id="songaydieutritukhoa" type="text" onfocus="chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
 <div class="div-Out" style="width:190px;clear:left">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("den")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="denkhoathunhat" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:170px;padding-left:0;padding-right:20px">
     <div class="div-Right"  style="width:100%;float:left;padding-left:20px">
     <input mkv="true" id="giochuyentukhoathunhat" type="text"  style="width:10%"/>
        <input mkv="true" id="phutchuyentukhoathunhat" type="text"  style="width:10%"/>
        <input mkv="true" id="thoigianchuyentukhoathunhat" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
     </div>
 </div>
   <div class="div-Out" style="width:57px;padding-left:0;padding-right:20px">
     <div class="div-Right" style="width:100%;float:left;padding-left:20px">
        <input mkv="true" id="songaydieutrikhoathunhat" type="text" onfocus="chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
 <div class="div-Out" style="width:190px;clear:left;">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("den")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="denkhoathuhai" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:170px;padding-left:0;padding-right:20px">
     <div class="div-Right"  style="width:100%;float:left;padding-left:20px">
     <input mkv="true" id="giochuyentukhoathuhai" type="text"  style="width:10%"/>
        <input mkv="true" id="phutchuyentukhoathuhai" type="text"  style="width:10%"/>
        <input mkv="true" id="thoigianchuyentukhoathuhai" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:50%"/>
     </div>
 </div>
 <div class="div-Out" style="width:57px;padding-left:0;padding-right:20px">
     <div class="div-Right" style="width:100%;float:left;padding-left:20px">
        <input mkv="true" id="songaydieutrikhoathuhai" type="text" onfocus="chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
  </div>
   <div style="border-bottom:1px solid #cfcfcf;border-right:1px solid #cfcfcf;position:relative;display:table;width:481px;float:left;">
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chuyenvien")%>
     </div>
     <div class="div-Right" style="width:70%">
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tuyentren")%>
        <input mkv="true" id="chuyenvientuyentren" type="checkbox" onfocus="chuyenphim(this);" />
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tuyenduoi")%>
        <input mkv="true" id="chuyenvientuyenduoi" type="checkbox" onfocus="chuyenphim(this);" />
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CK")%>
         <input mkv="true" id="chuyenvienCK" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chuyenvienden")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="chuyenvienden" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngayravien")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="gioravien" type="text"  style="width:10%"/>
        <input mkv="true" id="phutravien" type="text"  style="width:10%"/>
        <input mkv="true" id="ngayravien" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:30%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out" style="width:100px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ravien")%>
     </div>
     <div class="div-Right" style="width:30%">
        <input mkv="true" id="ravien" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:100px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("xinve")%>
     </div>
     <div class="div-Right" style="width:30%">
        <input mkv="true" id="xinve" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:100px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("bove")%>
     </div>
     <div class="div-Right" style="width:30%">
        <input mkv="true" id="bove" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:95px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("duave")%>
     </div>
     <div class="div-Right" style="width:30%">
        <input mkv="true" id="duave" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:459px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tongsongaydieutri")%>
     </div>
     <div class="div-Right" style="width:65%">
        <input mkv="true" id="tongsongaydieutri" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 </div>
         </div></div>
         <div class="body-div-button">
             <div class="in-a">
                 <input  id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ");"
                      />
                 <input  id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" 
                      />
                 <input  id="xoa" type="button" style="display:none" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                      />
             </div>
         </div>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_tinhtrang_khoangoai.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
<script type="text/javascript" src="../javascript/kcb_khoangoai.js">
     </script>
<div class="body-div"  style="margin-top:-98px;border-top:none">
             <div class="header-div">
                 IV.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_tinhtrang_khoangoai")%>
           </div>
 <div class="in-a">
  <div style="border-bottom:1px solid #cfcfcf;border-right:1px solid #cfcfcf;position:relative;display:table;float:left;width:380px;height:306px">
    <div style="clear:both;background-color:#f2f6f8;border-bottom:1px solid #efefef;padding:10px 0 10px 0;height:10px;color:green;">
    <div style="float:left;padding-left:10px">
        Kết quả điều trị
    </div>
 </div>
 <div class="div-Out" style="width:170px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_khoi")%>
     </div>
     <div class="div-Right" style="width:30%">
        <input mkv="true" id="tt_khoi" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
  <div class="div-Out"  style="width:167px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_nanghon")%>
     </div>
     <div class="div-Right"  style="width:30%">
        <input mkv="true" id="tt_nanghon" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:170px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_giam")%>
     </div>
     <div class="div-Right" style="width:30%">
        <input mkv="true" id="tt_giam" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
  <div class="div-Out" style="width:167px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_tuvong")%>
     </div>
     <div class="div-Right" style="width:30%">
        <input mkv="true" id="tt_tuvong" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:170px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_khongthaydoi")%>
     </div>
     <div class="div-Right" style="width:30%">
        <input mkv="true" id="tt_khongthaydoi" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div style="clear:both;background-color:#f2f6f8;border-bottom:1px solid #efefef;padding:10px 0 10px 0;height:10px;color:green;">
    <div style="float:left;padding-left:10px">
        Giải phẫu bệnh (khi có sinh thiết)
    </div>
 </div>
 <div class="div-Out" style="padding-left:0;padding-right:10px;width:357px">
     <div class="div-Right" style="width:100%;padding-right:10px;padding-left:10px;float:left">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_lanhtinh")%>
        <input mkv="true" id="tt_lanhtinh" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_nghingo")%>
        <input mkv="true" id="tt_nghingo" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_actinh")%>
        <input mkv="true" id="tt_actinh" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 </div>
  <div style="border-bottom:1px solid #cfcfcf;border-right:1px solid #cfcfcf;position:relative;display:table;float:left;width:580px">
 <div class="div-Out" style="width:552px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_thoigiantuvong")%>
     </div>
     <div class="div-Right" style="width:75.5%">
        <input mkv="true" id="tt_giotuvong" type="text"  style="width:10%"/>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("giờ")%>
        <input mkv="true" id="tt_phuttuvong" type="text"  style="width:10%"/>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phút")%>
        <input mkv="true" id="tt_thoigiantuvong" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:30%"/>
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("(dd/mm/yyyy)")%>
     </div>
 </div>
 <div class="div-Out" style="width:170px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_tuvongdobenh")%>
     </div>
     <div class="div-Right" style="width:20%">
        <input mkv="true" id="tt_tuvongdobenh" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:170px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_tuvongdotaibien")%>
     </div>
     <div class="div-Right" style="width:20%">
        <input mkv="true" id="tt_tuvongdotaibien" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:170px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_tuvongkhac")%>
     </div>
     <div class="div-Right" style="width:20%">
        <input mkv="true" id="tt_tuvongkhac" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:170px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_tuvongtrong24h")%>
     </div>
     <div class="div-Right" style="width:20%">
        <input mkv="true" id="tt_tuvongtrong24h" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:170px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_tuvongtrong48h")%>
     </div>
     <div class="div-Right" style="width:20%">
        <input mkv="true" id="tt_tuvongtrong48h" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:170px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_tuvongtrong72h")%>
     </div>
     <div class="div-Right" style="width:20%">
        <input mkv="true" id="tt_tuvongtrong72h" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:480px;padding-bottom:30px">
     <div class="div-Left" style="padding-bottom:30px">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_nguyennhantuvong")%>
     </div>
     <div class="div-Right" style="width:71.5%;padding-bottom:30px">
        <textarea mkv="true" id="tt_nguyennhantuvong" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px;padding-bottom:30px">
     <div class="div-Right" style="width:100%;padding-right:10px;padding-left:10px;float:left;padding-bottom:30px">
        <input mkv="true" id="tt_manguyennhantuvong" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:553px">
     
     <div class="div-Right" style="width:9.5%;float:right">
        <input mkv="true" id="tt_khamtuthi" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
     <div class="div-Left" style="float:right;padding-right:10px">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_khamtuthi")%>
     </div>
 </div>
 <div class="div-Out" style="width:480px;padding-bottom:30px">
     <div class="div-Left" style="padding-bottom:30px">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tt_chandoangiaiphaututhi")%>
     </div>
     <div class="div-Right" style="width:71.5%;padding-bottom:30px">
        <textarea mkv="true" id="tt_chandoangiaiphaututhi" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px;padding-bottom:30px">
     <div class="div-Right" style="width:100%;padding-right:10px;padding-left:10px;float:left;padding-bottom:30px">
        <input mkv="true" id="tt_magiaiphaututhi" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
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
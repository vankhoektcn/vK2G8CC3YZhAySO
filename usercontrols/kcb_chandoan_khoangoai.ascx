<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_chandoan_khoangoai.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
<script type="text/javascript" src="../javascript/kcb_khoangoai.js">
     </script>
<style type="text/css">
        .div-Out
        {
        	padding-bottom:30px;
        }
    .body-out
    {
        width:985px
    }
     </style>

<div class="body-div"  style="margin-top:-98px;border-top:none">
             <p class="header-div">
                 III.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_chandoan_khoangoai")%>
           </p>
 <div class="in-a">
 <div style="border-bottom:1px solid #cfcfcf;border-right:1px solid #cfcfcf;position:relative;display:table;float:left;width:483px">
  <div style="clear:both;background-color:#f2f6f8;border-bottom:1px solid #efefef;padding:10px 0 10px 0;height:10px;color:green;">
    <p style="text-align:right;float:left;width:450px">
        Mã
    </p>
 </div>
 <div class="div-Out" style="width:389px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_noichuyenden")%>
     </h4>
     <p style="width:70%">
        <textarea mkv="true" id="cd_noichuyenden" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </p>
 </div>
 <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <p style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_manoichuyenden" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </p>
 </div>
 <div class="div-Out" style="width:389px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_noiKKBCapCuu")%>
     </h4>
     <p style="width:70%">
        <textarea mkv="true" id="cd_noiKKBCapCuu" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </p>
 </div>

  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <p style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_manoiKKBCapCuu" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </p>
 </div>
 <div class="div-Out" style="width:389px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_khivaokhoadieutri")%>
     </h4>
     <p style="width:70%">
        <textarea mkv="true" id="cd_khivaokhoadieutri" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </p>
 </div>
  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <p style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_makhoadieutri" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </p>
 </div>
 <div class="div-Out" style="padding-left:0;padding-right:20px;width:460px;padding-bottom:0">
     <p style="width:100%;float:left;padding-left:20px;padding-bottom:0">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_taibien")%>
        <input mkv="true" id="cd_taibien" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_bienchung")%>
        <input mkv="true" id="cd_bienchung" type="checkbox" onfocus="chuyenphim(this);" />
     </p>
 </div>
 <div class="div-Out" style="padding-left:0;padding-right:20px;width:460px;padding-bottom:0">
     <p style="width:100%;float:left;padding-left:20px;padding-bottom:0">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_dophauthuat")%>
        <input mkv="true" id="cd_dophauthuat" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_dogayme")%>
        <input mkv="true" id="cd_dogayme" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_donhiemkhuan")%>
        <input mkv="true" id="cd_donhiemkhuan" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_khac")%>
        <input mkv="true" id="cd_khac" type="checkbox" onfocus="chuyenphim(this);" />
     </p>
 </div>

 <div class="div-Out" style="padding-bottom:0">
     <h4 style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_tongsongaydieutrisauphauthuat")%>
     </h4>
     <p style="width:30%;padding-bottom:0">
        <input mkv="true" id="cd_tongsongaydieutrisauphauthuat" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </p>
 </div>
 <div class="div-Out" style="padding-bottom:0">
     <h4 style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_tongsolanphauthuat")%>
     </h4>
     <p style="width:30%;padding-bottom:0">
        <input mkv="true" id="cd_tongsolanphauthuat" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </p>
 </div>
 </div>
 <div style="border-bottom:1px solid #cfcfcf;border-right:1px solid #cfcfcf;position:relative;display:table;float:left;width:480px;height:408px">
  <div style="clear:both;background-color:#f2f6f8;border-bottom:1px solid #efefef;padding:10px 0 10px 0;height:10px;color:green;">
    <p style="text-align:right;float:left;width:60px">
        Ra Viện :
    </p>
    <p style="text-align:right;float:left;width:390px">
        Mã
    </p>
 </div>
 <div class="div-Out" style="width:385px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_benhchinh")%>
     </h4>
     <p style="width:70%">
        <textarea mkv="true" id="cd_benhchinh" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </p>
 </div>
 <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <p style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_mabenhchinh" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
 <div class="div-Out" style="width:385px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_nguyennhanbenhchinh")%>
     </h4>
     <p style="width:70%">
        <textarea mkv="true" id="cd_nguyennhanbenhchinh" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </p>
 </div>

  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <p style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_manguyennhanbenhchinh" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
  <div class="div-Out" style="width:385px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_benhkemtheo")%>
     </h4>
     <p style="width:70%">
        <textarea mkv="true" id="cd_benhkemtheo" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </p>
 </div>

  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <p style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_mabenhkemtheo" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
   <div class="div-Out" style="width:385px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_chandoantruocphauthuat")%>
     </h4>
     <p style="width:70%">
        <textarea mkv="true" id="cd_chandoantruocphauthuat" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </p>
 </div>

  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <p style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_machandoantruocphauthuat" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </p>
 </div>
    <div class="div-Out" style="width:385px">
     <h4>
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_chandoansauphauthuat")%>
     </h4>
     <p style="width:70%">
        <textarea mkv="true" id="cd_chandoansauphauthuat" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </p>
 </div>

  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <p style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_machandoansauphauthuat" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </p>
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
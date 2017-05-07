<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_chandoan_khoasan.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
<script type="text/javascript" src="../javascript/kcb_khoasan.js">
     </script>
<style type="text/css">
        .div-Out
        {
        	padding-bottom:30px;
        }
        .div-Right
        {
        	padding-bottom:30px
        }
        .div-Left
        {
        	padding-bottom:30px
        }
    .body-out
    {
        width:985px
    }
     </style>

<div class="body-div"  style="margin-top:-98px;border-top:none">
             <div class="header-div">
                 III.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_chandoan_khoangoai")%>
           </div>
 <div class="in-a">
 <div style="border-bottom:1px solid #cfcfcf;border-right:1px solid #cfcfcf;position:relative;display:table;float:left;width:483px;padding-bottom:7px">
  <div style="clear:both;background-color:#f2f6f8;border-bottom:1px solid #efefef;padding:10px 0 10px 0;height:10px;color:green;">
    <div style="text-align:right;float:left;width:450px">
        Mã
    </div>
 </div>
 <div class="div-Out" style="width:389px;padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_noichuyenden")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
        <input mkv="true" id="cd_noichuyenden" type="text" onfocus="chuyenphim(this);" style="width:90%;" />
     </div>
 </div>
 <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px;padding-bottom:0">
     <div class="div-Right" style="width:100%;padding-right:10px;padding-left:10px;float:left;padding-bottom:0">
        <input mkv="true" id="cd_manoichuyenden" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:389px;padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_noiKKBCapCuu")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
        <input mkv="true" id="cd_noiKKBCapCuu" type="text" onfocus="chuyenphim(this);" style="width:90%;"></input>
     </div>
 </div>

  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px;padding-bottom:0">
     <div class="div-Right" style="width:100%;padding-right:10px;padding-left:10px;float:left;padding-bottom:0">
        <input mkv="true" id="cd_manoiKKBCapCuu" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:389px;padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_lucnaode")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
        <input mkv="true" id="cd_lucnaode" type="text" onfocus="chuyenphim(this);" style="width:90%;"></input>
     </div>
 </div>
  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px;padding-bottom:0">
     <div class="div-Right" style="width:100%;padding-right:10px;padding-left:10px;float:left;padding-bottom:0">
        <input mkv="true" id="cd_malucde" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
  <div class="div-Out" style="padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_ngayde")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
        <input mkv="true" id="cd_ngayde" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
   <div class="div-Out" style="padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_ngoithai")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
        <input mkv="true" id="cd_ngoithai" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
   <div class="div-Out" style="padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_cachthucde")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
        <input mkv="true" id="cd_cachthucde" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_kiemsoattucung")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
        <input mkv="true" id="cd_kiemsoattucung" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
        <input mkv="true" id="cd_iskiemsoattucung" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="padding-left:0;padding-right:20px;width:460px;padding-bottom:0">
     <div class="div-Right" style="width:100%;float:left;padding-left:20px;padding-bottom:0">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_taibien")%>
        <input mkv="true" id="cd_taibien" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_bienchung")%>
        <input mkv="true" id="cd_bienchung" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="padding-left:0;padding-right:20px;width:460px;padding-bottom:0">
     <div class="div-Right" style="width:100%;float:left;padding-left:20px;padding-bottom:0">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_dophauthuat")%>
        <input mkv="true" id="cd_dophauthuat" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_dogayme")%>
        <input mkv="true" id="cd_dogayme" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_donhiemkhuan")%>
        <input mkv="true" id="cd_donhiemkhuan" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_khac")%>
        <input mkv="true" id="cd_khac" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="padding-bottom:0;">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_tongsongaydieutrisauphauthuat")%>
     </div>
     <div class="div-Right" style="width:30%;padding-bottom:0">
        <input mkv="true" id="cd_songaydieutrisauphauthuat" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 </div>
 <div style="border-bottom:1px solid #cfcfcf;border-right:1px solid #cfcfcf;position:relative;display:table;float:left;width:480px;height:405px">
  <div style="clear:both;background-color:#f2f6f8;border-bottom:1px solid #efefef;padding:10px 0 10px 0;height:10px;color:green;">
    <div style="text-align:right;float:left;width:95%">
        Mã
    </div>
 </div>
  <div class="div-Out" style="width:389px;padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tinhhinhphauthuat")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_capcuu")%>
        <input mkv="true" id="cd_capcuu" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_chudong")%>
        <input mkv="true" id="cd_chudong" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
   <div class="div-Out" style="width:385px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_chandoantruocphauthuat")%>
     </div>
     <div class="div-Right" style="width:70%">
        <textarea mkv="true" id="cd_chandoantruocphauthuat" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </div>
 </div>

  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <div class="div-Right" style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_machandoantruocphauthuat" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
    <div class="div-Out" style="width:385px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_chandoansauphauthuat")%>
     </div>
     <div class="div-Right" style="width:70%">
        <textarea mkv="true" id="cd_chandoansauphauthuat" type="text" onfocus="chuyenphim(this);" style="width:90%;height:40px"></textarea>
     </div>
 </div>

  <div class="div-Out" style="width:50px;padding-left:0;padding-right:10px">
     <div class="div-Right" style="width:100%;padding-right:10px;padding-left:10px;float:left">
        <input mkv="true" id="cd_machandoansauphauthuat" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
   <div class="div-Out" style="padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_phuongphapphauthuat")%>
     </div>
     <div class="div-Right" style="width:60%;padding-bottom:0">
        <input mkv="true" id="cd_phuongphapphauthuat" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
  <div class="div-Out" style="width:389px;">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tresosinh")%>
     </div>
     <div class="div-Right" style="width:70%">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_donthai")%>
        <input mkv="true" id="cd_donthai" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_dathai")%>
        <input mkv="true" id="cd_dathai" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_trai")%>
        <input mkv="true" id="cd_trai" type="checkbox" onfocus="chuyenphim(this);" /><br /><br />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_gai")%>
        <input mkv="true" id="cd_gai" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_song")%>
        <input mkv="true" id="cd_song" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_chet")%>
        <input mkv="true" id="cd_chet" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
  <div class="div-Out" style="padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_divat")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
        <input mkv="true" id="cd_divat" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
  <div class="div-Out" style="padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_cannang")%>
     </div>
     <div class="div-Right" style="width:70%;padding-bottom:0">
        <input mkv="true" id="cd_cannang" type="text" onfocus="chuyenphim(this);" style="width:70%"/> gram
     </div>
 </div>
  <div class="div-Out" style="padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cd_tongsolanphauthuat")%>
     </div>
     <div class="div-Right" style="width:30%;padding-bottom:0">
        <input mkv="true" id="cd_solanphauthuat" type="text" onfocus="chuyenphim(this);" style="width:80%"/>
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
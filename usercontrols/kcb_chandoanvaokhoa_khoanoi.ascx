<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_chandoanvaokhoa_khoangoai.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>

     <script type="text/javascript" src="../javascript/kcb_khoanoi.js">
     </script>
     <style type="text/css">
        .div-Out
        {
	        float: none;
	        padding: 10px 0px 0px 10px;
	        width: 940px;
	        height: 140px;
	        background-color: #ece9d8;
	        border-bottom: 1px solid #cfcfcf;
	        border-left: 1px solid #ece9d8;
	        clear: both
        }

        .div-Left
        {
	        float: none;
	        padding: 10px 0px 10px 0px;
	        width:100%;
	        border-bottom: 1px solid #ece9d8;
	        height:20px;
        }

        .div-Right
        {
	        width: 99%;
	        background-color: #ece9d8;
	        float: right;
	        padding: 10px 0px 0px 10px;
	        display:table;
	        height:80px
        }
        .body-div .in-a textarea
        {
	        height:60px;
	        padding: 4px 4px;
        }
     </style>
     <div class="body-div" style="margin-top:-98px;border-top:none">
             <div class="header-div">
                 A.IV,V,VI.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_chandoanvaokhoa_khoangoai")%>
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         IV.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("chandoankhivaokhoa")%>
     </div>
     <div class="div-Right">
        <textarea  mkv="true" id="chandoankhivaokhoa" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("benhchinh")%>
     </div>
     <div class="div-Right">
        <textarea  mkv="true" id="benhchinh" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("benhkemtheo")%>
     </div>
     <div class="div-Right">
        <textarea  mkv="true" id="benhkemtheo" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phanbiet")%>
     </div>
     <div class="div-Right">
        <textarea  mkv="true" id="phanbiet" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
  <div class="div-Out">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         V.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("tienluong")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="tienluong" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
  <div class="div-Out">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         VI.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("huongdieutri")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="huongdieutri" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
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

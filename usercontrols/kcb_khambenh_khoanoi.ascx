<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_khambenh_khoangoai.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
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
        .div-Right table tr td
        {
        	border-right: 1px solid #cfcfcf;
            border-bottom: 1px solid #cfcfcf;
        }
     </style>
     <div class="body-div" style="margin-top:-98px;border-top:none">
             <div class="header-div">
                 III.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_khambenh_khoangoai")%>
           </div>
 <div class="in-a">
 <div class="div-Out">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_toanthan")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_toanthan" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
  <div class="div-Out" style="width:940px;padding-bottom:0;height:30px">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         Các cơ quan:
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tuanhoan")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_tuanhoan" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_hohap")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_hohap" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tieuhoa")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_tieuhoa" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_thantietnieusinhduc")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_thantietnieusinhduc" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_thankinh")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_thankinh" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_cosuongkhop")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_cosuongkhop" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_taimuihong")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_taimuihong" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_ranghammat")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_ranghammat" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_mat")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_mat" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_noitietdinhduong")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_noitietdinhduong" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_canlamsan")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_canlamsan" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_benhan")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="kb_benhan" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
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

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="capcuu_benhan.ascx.cs" Inherits="usercontrols_capcuu_benhan" %>
     <script type="text/javascript" src="../javascript/KCB_CapCuu.js">
     </script>
     <style type="text/css">
        .div-Out
        {
        	padding-bottom:50px;
        }
        .div-Right
        {
        	padding-bottom:50px
        }
        .div-Left
        {
        	padding-bottom:50px
        }
        .body-div .in-a textarea
        {
	        height:50px;
	        padding: 4px 4px;
	        border-color: #D9D9D9 #EAEAEA #fff;
        }
     </style>
     <div class="body-div" style="margin-top:-85px;border-top:none">
             <div class="header-div">
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("capcuu_benhan")%>
           </div>
 <div class="in-a">
 <div class="div-Out" style="width:940px;padding-bottom:0">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         I.HỎI BỆNH:
     </div>
 </div>
  <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("benhly")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="benhly" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tiensubanthan")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="tiensubanthan" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tiensugiadinh")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="tiensugiadinh" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
  <div class="div-Out" style="width:940px;padding-bottom:0">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         II.KHÁM BỆNH:
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("khambenhtoanthan")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="khambenhtoanthan" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("khambenhcacbophan")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="khambenhcacbophan" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
  <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ketquacanlamsan")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="ketquacanlamsan" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chandoanbandau")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="chandoanbandau" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("xuly")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="xuly" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chandoanravien")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="chandoanravien" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>

 <div class="div-Out" style="display:block;padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaybatdaudieutri")%>
     </div>
     <div class="div-Right" style="padding-bottom:0;width:50%">
        <input mkv="true" id="ngaybatdaudieutri" type="text" onfocus="$(this).datepick();chuyenphim(this);" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out" style="display:block;padding-bottom:0">
     <div class="div-Left" style="padding-bottom:0">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngayketthucdieutri")%>
     </div>
     <div class="div-Right" style="padding-bottom:0;width:50%">
        <input mkv="true" id="ngayketthucdieutri" type="text" onfocus="$(this).datepick();chuyenphim(this);" onblur="TestDate(this);"  style="width:50%"/>
        (dd\MM\yyyy)
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
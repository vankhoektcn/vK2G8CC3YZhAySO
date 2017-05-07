<%@ Control Language="C#" AutoEventWireup="true" CodeFile="capcuu_benhantongket.ascx.cs" Inherits="usercontrols_capcuu_benhantongket" %>
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
                 <%=hsLibrary.clDictionaryDB.sGetValueLanguage("capcuu_benhantongket")%>
           </div>
 <div class="in-a">
  <div class="div-Out" style="width:940px;padding-bottom:0">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
    III.TỔNG KẾT BỆNH ÁN       
     </div>
 </div>
  <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("benhlyvadienbien")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="benhlyvadienbien" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ketquacanlamsancogiatri")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="ketquacanlamsancogiatri" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chandoanravienchinh")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="chandoanravienchinh" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chandoanravienkemtheo")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="chandoanravienkemtheo" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phuongphapdieutri")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="phuongphapdieutri" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tinhtrangravien")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="tinhtrangravien" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("huongdieutritieptheo")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="huongdieutritieptheo" onfocus="chuyenphim(this);" style="width:90%"></textarea>
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
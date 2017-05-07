<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_khambenh_phukhoa.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
     <script type="text/javascript" src="../javascript/kcb_phukhoa.js">
     </script>
     <style type="text/css">
        .div-Out
        {
            width:940px
        }
        .div-Right
        {
            width:80%
        }
        .div-Out-a
        {
	        float: none;
	        padding: 10px 0px 0px 10px;
	        width: 950px;
	        height: 140px;
	        background-color: #ece9d8;
	        border-bottom: 1px solid #cfcfcf;
	        border-left: 1px solid #ece9d8;
	        clear: both
        }

        .div-Left-a
        {
	        float: none;
	        padding: 10px 0px 10px 0px;
	        width:100%;
	        border-bottom: 1px solid #ece9d8;
	        height:20px;
        }

        .div-Right-a
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
  <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div style="font-weight:bold;font-size:15px">
         1.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("toanthan")%> :
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_daniemmac")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_daniemmac" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_hach")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_hach" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_vu")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_vu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
  <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div style="font-weight:bold;font-size:15px">
         2.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("caccoquan")%> :
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tuanhoan")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_tuanhoan" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_hohap")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_hohap" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tieuhoa")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_tieuhoa" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_thankinh")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_thankinh" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_cosuongkhop")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_cosuongkhop" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_thantietnieu")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_thantietnieu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_khac")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_khac" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div class="div-Left;" style="font-weight:bold;font-size:15px">
         3.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("khamchuyekhoa")%> :
     </div>
 </div>
 <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div style="font-weight:bold;font-size:12px">
         &nbsp; &nbsp; &nbsp;&nbsp;
         a.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("khamngoai")%> :
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_dauhieusinhducthunhat")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_dauhieusinhducthunhat" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_moilon")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_moilon" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_moibe")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_moibe" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_amvat")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_amvat" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_amho")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_amho" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_mangtrinh")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_mangtrinh" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tangsinhmon")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_tangsinhmon" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div style="font-weight:bold;font-size:12px">
         &nbsp; &nbsp; &nbsp; &nbsp;
         b.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("khamtrong")%> :
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_amdao")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_amdao" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_cotucung")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_cotucung" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_thantucung")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_thantucung" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_phanphu")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_phanphu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_cactuicung")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_cactuicung" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 
 <div class="div-Out-a">
     <div class="div-Left-a" style="font-weight:bold;font-size:13px">
         4.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_xetnghiemcanlamsang")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_xetnghiemcanlamsang" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a" style="font-weight:bold;font-size:13px">
         5.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tomtatbenhan")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_tomtatbenhan" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
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

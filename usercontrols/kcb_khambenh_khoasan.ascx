<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_khambenh_khoasan.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
     <script type="text/javascript" src="../javascript/kcb_khoasan.js">
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
	        height: 110px;
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
        }

        .div-Right-a
        {
	        width: 99%;
	        background-color: #ece9d8;
	        float: right;
	        padding: 10px 0px 0px 10px;
	        display:table;
	        height:60px
        }
        .body-div .in-a textarea
        {
	        height:40px;
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
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_toantrang")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_toantrang" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
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
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tietnieu")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_tietnieu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
   <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_cacbophankhac")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_cacbophankhac" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div class="div-Left;" style="font-weight:bold;font-size:15px">
         2.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("khamngoai")%> :
     </div>
 </div>
 <div class="div-Out" style="width:200px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_bungcoseocu")%>
     </div>
     <div class="div-Right" style="width:20%">
        <input mkv="true" id="kb_bungcoseocu" type="checkbox" onfocus="Find(this);chuyenphim(this);"/>
     </div>
 </div>
 <div class="div-Out" style="width:400px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_hinhdangTC")%>
     </div>
     <div class="div-Right" style="width:70%">
        <input mkv="true" id="kb_hinhdangTC" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:200px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tuthe")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="kb_tuthe" type="text" onfocus="Find(this);chuyenphim(this);" style="width:70%"/>
     </div>
 </div>
 <div class="div-Out" style="width:240px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_chieucao")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="kb_chieucao" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/> cm,
     </div>
 </div>
  <div class="div-Out" style="width:240px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_vongbung")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="kb_vongbung" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/> cm,
     </div>
 </div>
 <div class="div-Out" style="width:340px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_concoTC")%>
     </div>
     <div class="div-Right" style="width:70%">
        <input mkv="true" id="kb_concoTC" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:440px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_timthai")%>
     </div>
     <div class="div-Right" style="width:80%">
        <input mkv="true" id="kb_timthai" type="text" onfocus="Find(this);chuyenphim(this);" style="width:30%"/> lần/phút
     </div>
 </div>
 <div class="div-Out" style="width:440px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_vu")%>
     </div>
     <div class="div-Right" style="width:80%">
        <input mkv="true" id="kb_vu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
<div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div class="div-Left;" style="font-weight:bold;font-size:15px">
         3.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("khamtrong")%> :
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_chisobishop")%>
     </div>
     <div class="div-Right" style="width:85%">
        <input mkv="true" id="kb_chisobishop" type="text" onfocus="Find(this);chuyenphim(this);" style="width:10%;border-color:blue"/> điểm
     </div>
 </div>
 <div class="div-Out" style="width:240px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_amho")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="kb_amho" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
  <div class="div-Out" style="width:240px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_amdao")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="kb_amdao" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
 <div class="div-Out" style="width:400px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tangsinhmon")%>
     </div>
     <div class="div-Right" style="width:70%">
        <input mkv="true" id="kb_tangsinhmon" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:240px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_cotucung")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="kb_cotucung" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
  <div class="div-Out" style="width:240px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_phanphu")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="kb_phanphu" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
 <div class="div-Out" style="width:400px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tinhtrangoi")%>
     </div>
     <div class="div-Right" style="width:70%">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_oiphong")%>
        <input mkv="true" id="kb_oiphong" type="checkbox" onfocus="Find(this);chuyenphim(this);"/>
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_oidet")%>
        <input mkv="true" id="kb_oidet" type="checkbox" onfocus="Find(this);chuyenphim(this);"/>
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_oiquale")%>
        <input mkv="true" id="kb_oiquale" type="checkbox" onfocus="Find(this);chuyenphim(this);"/>
     </div>
 </div>
  <div class="div-Out" style="width:440px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_thoigianoivo")%>
     </div>
     <div class="div-Right" style="width:70%">
        <input mkv="true" id="giooivo" type="text"  style="width:10%"/>
        <input mkv="true" id="phutoivo" type="text"  style="width:10%"/>
        <input mkv="true" id="kb_thoigianoivo" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:40%"/>
        (dd\MM\yyyy)
     </div>
 </div>
  <div class="div-Out" style="width:440px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("oivo")%>
     </div>
     <div class="div-Right" style="width:80%">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_oivotunhien")%>
        <input mkv="true" id="kb_oivotunhien" type="checkbox" onfocus="chuyenphim(this)" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_bamoi")%>
        <input mkv="true" id="kb_bamoi" type="checkbox" onfocus="chuyenphim(this)" />
     </div>
 </div>
 <div class="div-Out" style="width:443px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_mausacnuocoi")%>
     </div>
     <div class="div-Right" style="width:70%">
        <input mkv="true" id="kb_mausacnuocoi" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:443px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_luongnuocoi")%>
     </div>
     <div class="div-Right" style="width:70%">
        <input mkv="true" id="kb_luongnuocoi" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:300px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_ngoi")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_ngoi" type="text" onfocus="Find(this);chuyenphim(this);" style="width:80%" />
     </div>
 </div>
  <div class="div-Out" style="width:250px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_the")%>
     </div>
     <div class="div-Right" style="width:70%">
        <input mkv="true" id="kb_the" type="text" onfocus="Find(this);chuyenphim(this);" style="width:80%" />
     </div>
 </div>
 <div class="div-Out" style="width:300px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_kieuthe")%>
     </div>
     <div class="div-Right" style="width:70%">
        <input mkv="true" id="kb_kieuthe" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%" />
     </div>
 </div>
 <div class="div-Out" style="width:440px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("dolot")%>
     </div>
     <div class="div-Right" style="width:80%">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("cao")%>
        <input mkv="true" id="kb_dolotcao" type="checkbox" onfocus="Find(this);chuyenphim(this);"  />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chuc")%>
        <input mkv="true" id="kb_dolotchuc" type="checkbox" onfocus="Find(this);chuyenphim(this);"  />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("chat")%>
        <input mkv="true" id="kb_dolotchat" type="checkbox" onfocus="Find(this);chuyenphim(this);"  />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("lot")%>
        <input mkv="true" id="kb_dolotlot" type="checkbox" onfocus="Find(this);chuyenphim(this);"  />
     </div>
 </div>
 <div class="div-Out" style="width:450px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_duongkinhhave")%>
     </div>
     <div class="div-Right" style="width:70%">
        <input mkv="true" id="kb_duongkinhhave" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%" />
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
 <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div class="div-Left;" style="font-weight:bold;font-size:15px">
         5.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("chandoan")%> :
     </div>
 </div>
  <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_chandoankhivaokhoa")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_chandoankhivaokhoa" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%" />
     </div>
 </div>
 <div class="div-Out" >
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_phanbiet")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_phanbiet" type="text" onfocus="Find(this);chuyenphim(this);" style="width:90%" />
     </div>
 </div>
  <div class="div-Out-a">
     <div class="div-Left-a" style="font-weight:bold;font-size:17px">
         6.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("tienluong")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="tienluong" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
  <div class="div-Out">
     <div class="div-Left" style="font-weight:bold;font-size:17px">
         7.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("huongdieutri")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="huongdieutri" type="text" onfocus="chuyenphim(this);" style="width:90%" />
     </div>
 </div>
  <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_phuongphapchinh")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_phuongphapchinh" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
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

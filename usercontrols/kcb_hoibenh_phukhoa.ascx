<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_hoibenh_phukhoa.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
     <script type="text/javascript" src="../javascript/kcb_phukhoa.js">
     </script>
     <style type="text/css">
        .div-Out-abc
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

        .div-Left-abc
        {
	        float: none;
	        padding: 10px 0px 10px 0px;
	        width:100%;
	        border-bottom: 1px solid #ece9d8;
	        height:20px;
        }

        .div-Right-abc
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
                 II.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_hoibenh_khoangoai")%>
           </div>
 <div class="in-a">
 <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div class="div-Left;" style="font-weight:bold;font-size:15px">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("lydovaovien")%> :
         <span mkv="true" id="lydovaovien" style="width:90%;font-weight:bold;font-size:15px"></span>
     </div>
 </div>
 <div class="div-Out-abc">
     <div class="div-Left-abc" style="font-weight:bolder;font-size:13px">
         1.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_quatrinhbenhly")%>
     </div>
     <div class="div-Right-abc">
        <textarea mkv="true" id="hb_quatrinhbenhly" type="text" onfocus="chuyenphim(this);" style="width:95%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div class="div-Left;" style="font-weight:bold;font-size:15px">
         2.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("tiensubenh")%> :
         <span mkv="true" id="Span3" style="width:90%;font-weight:bold;font-size:15px"></span>
     </div>
 </div>
 <div class="div-Out-abc">
     <div class="div-Left-abc">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("banthan")%>
     </div>
     <div class="div-Right-abc">
        <textarea mkv="true" id="hb_tiensubenhbanthan" type="text" onfocus="chuyenphim(this);" style="width:95%"></textarea>
     </div>
 </div>
 
 <div class="div-Out-abc">
     <div class="div-Left-abc">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("giadinh")%>
     </div>
     <div class="div-Right-abc">
        <textarea mkv="true" id="hb_tiensubenhgiadinh" type="text" onfocus="chuyenphim(this);" style="width:95%"></textarea>
     </div>
 </div>
  <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div class="div-Left;" style="font-weight:bold;font-size:15px">
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tiensusanphukhoa")%> :
         <span mkv="true" id="Span2" style="width:90%;font-weight:bold;font-size:15px"></span>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_batdauthaykinhnam")%>
     </div>
     <div class="div-Right" style="width:67.5%">
        <input mkv="true" id="hb_batdauthaykinhnam" type="text" onfocus="Find(this);chuyenphim(this);" style="width:50%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_batdauthaykinhotuoi")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="hb_batdauthaykinhotuoi" type="text" onfocus="Find(this);chuyenphim(this);" style="width:50%"/>
     </div>
 </div>
 <div class="div-Out" style="width:300px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_tinhchatkinhnguyet")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="hb_tinhchatkinhnguyet" type="text" onfocus="Find(this);chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:200px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_chukykinhnguyet")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="hb_chukykinhnguyet" type="text" onfocus="Find(this);chuyenphim(this);" style="width:50%"/> ngày
     </div>
 </div>
 <div class="div-Out" style="width:200px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_songaythaykinh")%>
     </div>
     <div class="div-Right" style="width:40%">
        <input mkv="true" id="hb_songaythaykinh" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
 <div class="div-Out" style="width:178px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_luongkinh")%>
     </div>
     <div class="div-Right" style="width:40%">
        <input mkv="true" id="hb_luongkinh" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
 <div class="div-Out" style="width:300px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_kinhlancuoingay")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="hb_kinhlancuoingay" type="text" onfocus="Find(this);chuyenphim(this);" style="width:70%"/>
     </div>
 </div>
 <div class="div-Out" style="width:150px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_daubung")%>
     </div>
     <div class="div-Right" style="width:30%">
        <input mkv="true" id="hb_daubung" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
     </div>
 </div>
<div class="div-Out" style="width:85px">
     <div class="div-Left" >
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("thoigian")%> :
     </div>
 </div>
 <div class="div-Out" style="width:100px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("truoc")%>
     </div>
     <div class="div-Right" style="width:40%">
        <input mkv="true" id="hb_daubungtruoc" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:100px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("trong")%>
     </div>
     <div class="div-Right" style="width:40%">
        <input mkv="true" id="hb_daubungtrong" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:100px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("sau")%>
     </div>
     <div class="div-Right" style="width:40%">
        <input mkv="true" id="hb_daubungsau" type="checkbox" onfocus="Find(this);chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:300px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_laychongnam")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="hb_laychongnam" type="text" onfocus="Find(this);chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:150px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tuoi")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="hb_tuoilaychong" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
 <div class="div-Out" style="width:278px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_hetkinhnam")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="hb_hetkinhnam" type="text" onfocus="Find(this);chuyenphim(this);" style="width:80%"/>
     </div>
 </div>
 <div class="div-Out" style="width:150px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tuoi")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="hb_hetkinhtuoi" type="text" onfocus="Find(this);chuyenphim(this);" style="width:60%"/>
     </div>
 </div>
 <div class="div-Out-abc">
     <div class="div-Left-abc">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_benhphukhoadieutrikhac")%>
     </div>
     <div class="div-Right-abc">
        <textarea mkv="true" id="hb_benhphukhoadieutrikhac" type="text" onfocus="Find(this);chuyenphim(this);" style="width:95%"></textarea>
     </div>
 </div>
  <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div class="div-Left;" style="font-weight:bold;font-size:15px">
         4.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("tiensusankhoa")%> :
         <span mkv="true" id="Span1" style="width:90%;font-weight:bold;font-size:15px"></span>
     </div>
 </div>
 <div class="div-Out" style="width:940px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_tienthaiduthang")%>
     </div>
     <div class="div-Right" style="width:80%">
         
        <input mkv="true" id="hb_tienthaiduthang" type="checkbox" onfocus="Find(this);chuyenphim(this);" /> 
        <input mkv="true" id="hb_tienthaisom" type="checkbox" onfocus="Find(this);chuyenphim(this);" /> 
        <input mkv="true" id="hb_tienthaisay" type="checkbox" onfocus="Find(this);chuyenphim(this);" /> 
        <input mkv="true" id="hb_tienthaisong" type="checkbox" onfocus="Find(this);chuyenphim(this);" />  
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_tienthaisinhsomsaysong")%>
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

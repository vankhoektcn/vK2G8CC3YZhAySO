<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_khambenh_phukhoa.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
     <script type="text/javascript" src="../javascript/kcb_sosinh.js">
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
        .div-Right-a table tr td
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
 <div class="div-Out" style="width:900px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_hotennguoichuyen")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_hotennguoichuyen" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left" style="font-weight:bold">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("toanthan")%>
     </div>
     <div class="div-Right">
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_ditatbamsinh")%>
        <input mkv="true" id="kb_ditatbamsinh" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_cohaumon")%>
        <input mkv="true" id="kb_cohaumon" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:900px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_cutheditat")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_cutheditat" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out-a" style="width:600px;float:left;clear:none">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tinhhinhvaokhoa")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_tinhhinhvaokhoa" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 
 <div class="div-Out-a" style="width:300px;float:left;clear:none;">
 <div class="div-Left-a"></div>
     <div class="div-Right-a">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_th_can")%>
        <input mkv="true" id="kb_th_can" type="text" onfocus="chuyenphim(this);" style="width:50%"/>gr
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_th_chieudai")%>
         <input mkv="true" id="kb_th_chieudai" type="text" onfocus="chuyenphim(this);" style="width:50%"/>cm
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_th_vongdau")%>
         <input mkv="true" id="kb_th_vongdau" type="text" onfocus="chuyenphim(this);" style="width:50%"/>cm
     </div>
 </div>
 <div class="div-Out-a" style="width:600px;float:left;clear:none">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tinhtrangtoanthan")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_tinhtrangtoanthan" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a" style="width:300px;float:left;clear:none">
     <div class="div-Left-a">
         
     </div>
     <div class="div-Right-a">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tt_nhietdo")%>
        <input mkv="true" id="kb_tt_nhietdo" type="text" onfocus="chuyenphim(this);" style="width:50%"/>độ C
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tt_nhiptho")%>
        <input mkv="true" id="kb_tt_nhiptho" type="text" onfocus="chuyenphim(this);" style="width:50%"/>lần/phút
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("mausacda")%> :
     </div>
     <div class="div-Right">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_sd_honghao")%>
        <input mkv="true" id="kb_sd_honghao" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_sd_xanhtai")%>
        <input mkv="true" id="kb_sd_xanhtai" type="checkbox" onfocus="chuyenphim(this);" />
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_sd_vang")%>
         <input mkv="true" id="kb_sd_vang" type="checkbox" onfocus="chuyenphim(this);" />
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_sd_tim")%>
         <input mkv="true" id="kb_sd_tim" type="checkbox" onfocus="chuyenphim(this);" />
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_sd_khac")%>
         <input mkv="true" id="kb_sd_khac" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
   <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div style="font-weight:bold;font-size:15px">
         2.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("caccoquankhac")%> :
     </div>
 </div>
 <div class="div-Out" style="width:400px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_hh_nhiptho")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="kb_hh_nhiptho" type="text" onfocus="chuyenphim(this);" style="width:60%"/> lần/phút
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_hh_nghephoi")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_hh_nghephoi" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:400px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_hh_sosilverman")%>
     </div>
     <div class="div-Right" style="width:60%">
        <input mkv="true" id="kb_hh_sosilverman" type="text" onfocus="chuyenphim(this);" style="width:60%"/> điểm
     </div>
 </div>
 <div class="div-Out-a" style="height:100px">
     <div class="div-Right-a" style="height:auto;float:right;height:80px;width:100%">
         <table style="width: 100%;">
             <tr>
                 <td>
                     Điểm
                 </td>
                 <td>
                     Sự dãn nở lồng ngực
                 </td>
                 <td>
                     Co kéo cơ liên sườn
                 </td>
                 <td>
                     Co kéo mũ ức
                 </td>
                 <td>
                     Đập cánh mũi
                 </td>
                 <td>
                     Rên rỉ
                 </td>
             </tr>
             <tr>
                 <td>
                     1
                 </td>
                 <td>
                     Điều hoà
                 </td>
                 <td>
                     Không
                 </td>
                 <td>
                     Không
                 </td>
                 <td>
                     Không
                 </td>
                 <td>
                     Không
                 </td>
             </tr>
             <tr>
                 <td>
                     2
                 </td>
                 <td>
                     Xê dịch nhịp thở với di động bụng
                 </td>
                 <td>
                     Có ít
                 </td>
                 <td>
                     Có ít
                 </td>
                 <td>
                     Nhẹ
                 </td>
                 <td>
                     Nghe bằng ống nghe
                 </td>
             </tr>
             <tr>
                 <td>
                     3
                 </td>
                 <td>
                     Không di động ngực bụng
                 </td>
                 <td>
                     Thấy rõ
                 </td>
                 <td>
                     Thấy rõ
                 </td>
                 <td>
                     Rõ
                 </td>
                 <td>
                     Tai thường nghe rõ
                 </td>
             </tr>
         </table>
        </div>
     </div>
 <div class="div-Out" style="width:600px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tm_nhiptim")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_tm_nhiptim" type="text" onfocus="chuyenphim(this);" style="width:30%"/> lần/phút
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_bung")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="kb_bung" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_sinhducngoai")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_sinhducngoai" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_xuongkhop")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_xuongkhop" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div style="font-weight:bold;font-size:15px">
        Thần kinh :
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tk_phanxa")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_tk_phanxa" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tk_truongcoluc")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_tk_truongcoluc" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a" style="font-weight:bold;font-size:13px">
         3.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_xetnghiemcls")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_xetnghiemcls" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a" style="font-weight:bold;font-size:13px">
         4.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_tomtatbenhan")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_tomtatbenhan" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out-a">
     <div class="div-Left-a" style="font-weight:bold;font-size:13px">
         5.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kb_chidinhtheodoi")%>
     </div>
     <div class="div-Right-a">
        <textarea mkv="true" id="kb_chidinhtheodoi" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
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

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_hoibenh_sosinh.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
     <script type="text/javascript" src="../javascript/kcb_sosinh.js">
     </script>
     <style type="text/css">

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
<div class="div-Out" style="width:940px;height:140px">
     <div class="div-Left" style="width:100%;height:20px">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_dienbienbenh")%>
     </div>
     <div class="div-Right" style="width:100%;float: right;height:80px">
        <textarea mkv="true" id="hb_dienbienbenh" type="text" onfocus="chuyenphim(this);" style="width:90%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="width:350px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_oivo")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="hb_giooivo" type="text" onfocus="chuyenphim(this);"  style="width:10%"/>
        <input mkv="true" id="hb_phutoivo" type="text" onfocus="chuyenphim(this);"  style="width:10%"/>
        <input mkv="true" id="hb_ngayoivo" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:30%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out" style="width:500px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_mausac")%>
     </div>
     <div class="div-Right" style="width:75%">
        <input mkv="true" id="hb_mausac" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:370px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_cachde")%>
     </div>
     <div class="div-Right">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_dethuong")%>
        <input mkv="true" id="hb_dethuong" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_canthiep")%>
        <input mkv="true" id="hb_canthiep" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_ngayde")%>
     </div>
     <div class="div-Right">
     <input mkv="true" id="hb_giode" type="text" onfocus="chuyenphim(this);"  style="width:10%"/>
     <input mkv="true" id="hb_phutde" type="text" onfocus="chuyenphim(this);"  style="width:10%"/>
        <input mkv="true" id="hb_ngayde" type="text" onfocus="chuyenphim(this);$(this).datepick();" onblur="TestDate(this);"  style="width:40%"/>
        (dd\MM\yyyy)
     </div>
 </div>
 <div class="div-Out" style="width:900px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_lydocanthiep")%>
     </div>
     <div class="div-Right" style="width:80%">
        <input mkv="true" id="hb_lydocanthiep" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:900px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_tinhtrangsosinhkhiradoi")%>
     </div>
     <div class="div-Right" style="width:75%">
     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_ttradoi_khocngay")%>
        <input mkv="true" id="hb_ttradoi_khocngay" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_ttradoi_ngat")%>
        <input mkv="true" id="hb_ttradoi_ngat" type="checkbox" onfocus="chuyenphim(this);" />
        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_ttradoi_khac")%>
        <input mkv="true" id="hb_ttradoi_khac" type="checkbox" onfocus="chuyenphim(this);" />
     </div>
 </div>
 <div class="div-Out" style="width:900px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_hotennguoidobenh")%>
     </div>
     <div class="div-Right">
        <input mkv="true" id="hb_hotennguoidobenh" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:200px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_apgar1phut")%>
     </div>
     <div class="div-Right" style="width:40%">
        <input mkv="true" id="hb_apgar1phut" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:200px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_apgar5phut")%>
     </div>
     <div class="div-Right" style="width:40%">
        <input mkv="true" id="hb_apgar5phut" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:200px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_apgar10phut")%>
     </div>
     <div class="div-Right" style="width:40%">
        <input mkv="true" id="hb_apgar10phut" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="width:200px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_cannang")%>
     </div>
     <div class="div-Right" style="width:50%">
        <input mkv="true" id="hb_cannang" type="text" onfocus="chuyenphim(this);" style="width:70%"/> (g)
     </div>
 </div>
 <div class="div-Out" style="width:900px">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_ttdinhduongsausinh")%>
     </div>
     <div class="div-Right" style="width:80%">
        <input mkv="true" id="hb_ttdinhduongsausinh" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
     </div>
 </div>
 <div class="div-Out" style="height:150px">
     <div class="div-Left" style="float:none;height:10px">
         Đặc điểm liên quan bệnh:
     </div>
     <div class="div-Right" style="height:auto;float:right;height:80px;width:100%">
         <table style="width: 100%;">
             <tr>
                 <td>
                     TT
                 </td>
                 <td>
                     Phương pháp
                 </td>
                 <td>
                     TT
                 </td>
                 <td>
                     Phương pháp
                 </td>
             </tr>
             <tr>
                 <td>
                     01
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_hs_hutdich")%>
                     <input mkv="true" id="hb_hs_hutdich" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
                 <td>
                     04
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_hs_noikhiquan")%>
                     <input mkv="true" id="hb_hs_noikhiquan" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
             </tr>
             <tr>
                 <td>
                     02
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_hs_xoaboptim")%>
                     <input mkv="true" id="hb_hs_xoaboptim" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
                 <td>
                     05
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_hs_bapbangoxy")%>
                     <input mkv="true" id="hb_hs_bapbangoxy" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
             </tr>
             <tr>
                 <td>
                     03
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_hs_theoxy")%>
                     <input mkv="true" id="hb_hs_theoxy" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
                 <td>
                     06
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_hs_khac")%>
                     <input mkv="true" id="hb_hs_khac" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
             </tr>
         </table>
        
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

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kcb_hoibenh_khoangoai.ascx.cs" Inherits="kcb_chandoan_khoangoai" %>
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
                 II.<%=hsLibrary.clDictionaryDB.sGetValueLanguage("kcb_hoibenh_khoangoai")%>
           </div>
 <div class="in-a">
  <div class="div-Out" style="width:940px;padding-bottom:0px;padding-top:10px;height:30px">
     <div class="div-Left;" style="font-weight:bold;font-size:15px;">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("lydovaovien")%> :
         <span mkv="true" id="lydovaovien" style="width:90%;font-weight:bold;font-size:15px"></span>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_quatrinhbenhly")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="hb_quatrinhbenhly" type="text" onfocus="chuyenphim(this);" style="width:95%"></textarea>
     </div>
 </div>
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_tiensubenhbanthan")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="hb_tiensubenhbanthan" type="text" onfocus="chuyenphim(this);" style="width:95%"></textarea>
     </div>
 </div>
 <div class="div-Out" style="height:200px">
     <div class="div-Left">
         Đặc điểm liên quan bệnh:
     </div>
     <div class="div-Right" style="height:auto">
         <table style="width: 100%;">
             <tr>
                 <td>
                     TT
                 </td>
                 <td>
                     Ký hiệu
                 </td>
                 <td>
                     Thời gian (tính theo tháng)
                 </td>
                 <td>
                     TT
                 </td>
                 <td>
                     Ký hiệu
                 </td>
                 <td>
                     Thời gian (tính theo tháng)
                 </td>
             </tr>
             <tr>
                 <td>
                     01
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_diung")%>
                     <input mkv="true" id="hb_diung" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
                 <td>
                     <input mkv="true" id="hb_thoigiandiung" type="text" onfocus="chuyenphim(this);" style="width:90%" />
                 </td>
                 <td>
                     04
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_nghienthuocla")%>
                     <input mkv="true" id="hb_nghienthuocla" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
                 <td>
                     <input mkv="true" id="hb_thoigiannghienthuocla" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
                 </td>
             </tr>
             <tr>
                 <td>
                     02
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_nghienmatuy")%>
                     <input mkv="true" id="hb_nghienmatuy" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
                 <td>
                     <input mkv="true" id="hb_thoigiannghienmatuy" type="text" onfocus="chuyenphim(this);" style="width:90%" />
                 </td>
                 <td>
                     05
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_nghienthuoclao")%>
                     <input mkv="true" id="hb_nghienthuoclao" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
                 <td>
                     <input mkv="true" id="hb_thoigiannghienthuoclao" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
                 </td>
             </tr>
             <tr>
                 <td>
                     03
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_nghienruoubia")%>
                     <input mkv="true" id="hb_nghienruoubia" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
                 <td>
                     <input mkv="true" id="hb_thoigiannghienruoubia" type="text" onfocus="chuyenphim(this);" style="width:90%" />
                 </td>
                 <td>
                     06
                 </td>
                 <td>
                     <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_lydokhac")%>
                     <input mkv="true" id="hb_lydokhac" type="checkbox" onfocus="chuyenphim(this);" style="float:right"/>
                 </td>
                 <td>
                     <input mkv="true" id="hb_thoigianlydokhac" type="text" onfocus="chuyenphim(this);" style="width:90%"/>
                 </td>
             </tr>
         </table>
        
     </div>
 </div>
 
 <div class="div-Out">
     <div class="div-Left">
         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("hb_tiensubenhgiadinh")%>
     </div>
     <div class="div-Right">
        <textarea mkv="true" id="hb_tiensubenhgiadinh" type="text" onfocus="chuyenphim(this);" style="width:95%"></textarea>
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

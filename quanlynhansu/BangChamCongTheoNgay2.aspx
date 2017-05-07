<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true"
    CodeFile="BangChamCongTheoNgay2.aspx.cs" Inherits="BangChamCongTheoNgay" Title="BangChamCongTheoNgay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
         tr#background:hover
         {
             background-color: #f6ebcd;
             z-index: 1000;
             color: green;
         }
     </style>

    <script src="js/epoch_classes.js" type="text/javascript" language="javascript"></script>

    <link href="css/epoch_styles.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript">
              var flagtemp;
               var dp_cal1;       
	    window.onload = function () 
	    {	       
	        dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById("<%=NgayCong.ClientID %>"));  	       
	        //dp_cal1.calCellonmouseout=function(){alert('sfsf');};
//	        dp_cal1.addEventHandler(document.getElementById("<%=NgayCong.ClientID %>"),'click','alert(\"dfd\"');
	    };   
         $(document).ready(function() {
              tablegrid = "<%=gridTable.ClientID %>";
       khoachinhcapnhatdulieu = "idkhoachinh";
//       for (var i = 0; i < document.forms[0].elements.length; i++) {
//         if (document.forms[0].elements[i].type == "text")
//         {
//             if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
//                { setTimeout("document.forms[0].elements["+i+"].focus()",100);
//             return false;}
//         }
//      }
         });
         function functionSelected(idkhoachinh)
         {
 
         }
 function xoaontable(idkhoachinh,control){
             if(idkhoachinh.length > 0){
             var hoi = confirm("Xác nhận !");
             if(hoi){
                 var xmlHttp = GetMSXmlHttp();
                 xmlHttp.onreadystatechange = function() {
                     if (xmlHttp.readyState == 4) {
                         if (xmlHttp.responseText.length > 0) {
                             myalert('Xoá thành công !',2000);
                             if(document.getElementById("<%=gridTable.ClientID %>").rows.length > 3)
                             {
                                document.getElementById("<%=gridTable.ClientID %>").deleteRow(control.parentNode.parentNode.rowIndex);
                             }
                             else{
                                  for(var i=0;i<document.getElementById("<%=gridTable.ClientID %>").rows[1].cells.length;i++)
                                  {
                                    try{
                                      if(document.getElementById("<%=gridTable.ClientID %>").rows[1].cells[i].getElementsByTagName("input")[0] != null)
                                      {
                                            document.getElementById("<%=gridTable.ClientID %>").rows[1].cells[i].getElementsByTagName("input")[0].value = "";
                                      }
                                      }catch(ex){}
                                  }                                              
                             }
                         }
                         else {
                             alert('Xoá không thành công !');
                         }
                     }
                 }
                 xmlHttp.open("GET", "../ajax/BangChamCongTheoNgay_ajax2.aspx?do=xoa&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{
             if(document.getElementById("<%=gridTable.ClientID %>").rows.length > 3){
             document.getElementById("<%=gridTable.ClientID %>").deleteRow(control.parentNode.parentNode.rowIndex);
             }
             else{
                                  for(var i=0;i<document.getElementById("<%=gridTable.ClientID %>").rows[1].cells.length;i++)
                                  {
                                  try{
                                      if(document.getElementById("<%=gridTable.ClientID %>").rows[1].cells[i].getElementsByTagName("input")[0] != null)
                                      {
                                            document.getElementById("<%=gridTable.ClientID %>").rows[1].cells[i].getElementsByTagName("input")[0].value = "";
                                      }
                                      }catch(ex){}
                                  }                                              
                           }
             }
              
         }
         function xoaontablehoanghiep(idkhoachinh,control){
             if(idkhoachinh.length > 0){
             var hoi = confirm("Xác nhận !");
             if(hoi){
                 var xmlHttp = GetMSXmlHttp();
                 xmlHttp.onreadystatechange = function() {
                     if (xmlHttp.readyState == 4) {
                         if (xmlHttp.responseText.length > 0) {
                             myalert('Xoá thành công !',2000);
                             if(document.getElementById("hoanghiep").rows.length > 1)
                             {
                                document.getElementById("hoanghiep").deleteRow(control.parentNode.parentNode.rowIndex);
                             }
                             else{
                                  for(var i=0;i<document.getElementById("hoanghiep").rows[0].cells.length;i++)
                                  {
                                  try{
                                      if(document.getElementById("hoanghiep").rows[0].cells[i].getElementsByTagName("input")[0] != null)
                                      {
                                            document.getElementById("hoanghiep").rows[0].cells[i].getElementsByTagName("input")[0].value = "";
                                      }
                                      }catch(ex){}
                                  }                                              
                             }
                         }
                         else {
                             alert('Xoá không thành công !');
                         }
                     }
                 }
                 xmlHttp.open("GET", "../ajax/BangChamCongTheoNgay_ajax2.aspx?do=xoa&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{
             if(document.getElementById("hoanghiep").rows.length > 1){
             document.getElementById("hoanghiep").deleteRow(control.parentNode.parentNode.rowIndex);
             }
             else{
                                  for(var i=0;i<document.getElementById("hoanghiep").rows[0].cells.length;i++)
                                  {
                                  try{
                                      if(document.getElementById("hoanghiep").rows[0].cells[i].getElementsByTagName("input")[0] != null)
                                      {
                                            document.getElementById("hoanghiep").rows[0].cells[i].getElementsByTagName("input")[0].value = "";
                                      }
                                      }catch(ex){}
                                  }                                              
                             }
             }
              
         }
         function xoaontable2(idkhoachinh,control){
             if(idkhoachinh.length > 0){
             var hoi = confirm("Xác nhận !");
             if(hoi){
                 var xmlHttp = GetMSXmlHttp();
                 xmlHttp.onreadystatechange = function() {
                     if (xmlHttp.readyState == 4) {
                         if (xmlHttp.responseText.length > 0) {
                             myalert('Xoá thành công !',2000);
                             if(document.getElementById(tablegrid).rows.length > 3)
                             {
                                document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);
                             }
                             else{
                                  for(var i=0;i<document.getElementById(tablegrid).rows[1].cells.length;i++)
                                  {
                                  try{
                                      if(document.getElementById(tablegrid).rows[1].cells[i].getElementsByTagName("input")[0] != null)
                                      {
                                            document.getElementById(tablegrid).rows[1].cells[i].getElementsByTagName("input")[0].value = "";
                                            document.getElementById(tablegrid).rows[1].cells[i].getElementsByTagName("input")[1].value = "";                                            
                                      }
                                      }catch(ex){}
                                  }                                              
                             }
                         }
                         else {
                             alert('Xoá không thành công !');
                         }
                     }
                 }
                 xmlHttp.open("GET", "../ajax/BangChamCongTheoNgay_ajax2.aspx?do=xoagiolamthem&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{
             if(document.getElementById(tablegrid).rows.length > 3){
             document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);
             }
             else{
                                  for(var i=0;i<document.getElementById(tablegrid).rows[1].cells.length;i++)
                                  {
                                  try{
                                      if(document.getElementById(tablegrid).rows[1].cells[i].getElementsByTagName("input")[0] != null)
                                      {
                                            document.getElementById(tablegrid).rows[1].cells[i].getElementsByTagName("input")[0].value = "";
                                            document.getElementById(tablegrid).rows[1].cells[i].getElementsByTagName("input")[1].value = "";                                            
                                            
                                      }
                                      }catch(ex){}
                                  }                                              
                             }
             }
              
         }
        var controlTableLuuKhac ;
        function btLuuTable(control,functionlistcontroluutable)
         {
            flagthemgio = false;
             controlTableLuuKhac = control;
             tablegrid = "<%=gridTable.ClientID %>";
             if(document.getElementById(tablegrid) != null){
              if(control.id.indexOf("luuTable") != -1)
             {
                for(var i=1;i<3;i++){
                 document.getElementById("luuTable_"+i).value = "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("stop") %> ";
                 document.getElementById("luuTable_"+i).id = "huyTable_"+i;
                 }
                 flagtemp = true;
                 LuuTable('','luuphongkhac',row1,control,functionlistcontroluutable);
             }
             else{
             flagthemgio = true;
             for(var i=1;i<3;i++){
                 document.getElementById("huyTable_"+i).value = "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ";
                 document.getElementById("huyTable_"+i).id= "luuTable_"+i;
                 }
                 flagtemp = false;
             }
           }
             
         }
         function ListControlLuuTable(i)
         {
           
             var NgayCong = document.getElementById("<%=NgayCong.ClientID %>").value;
             var idNhanVien = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value;
             var NgayThuong = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].checked;
             var NgayTruc = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("select")[0].value;
             var PhepKhongLuong = document.getElementById(tablegrid).rows[i].cells[5].getElementsByTagName("select")[0].value;
             var PhepCoLuong = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("select")[0].value;
             var LamThemNuaNgay = document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("input")[0].checked;
             var LamThemMotNgay = document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].checked;
             var NghiOm = document.getElementById(tablegrid).rows[i].cells[9].getElementsByTagName("input")[0].checked;
             var VoKyLuat = document.getElementById(tablegrid).rows[i].cells[10].getElementsByTagName("input")[0].checked;
             var NghiBu = document.getElementById(tablegrid).rows[i].cells[11].getElementsByTagName("input")[0].checked;
             var NghiLe = document.getElementById(tablegrid).rows[i].cells[12].getElementsByTagName("input")[0].checked;
             var idtablegiolamthem = document.getElementById(tablegrid).rows[i].cells[13].getElementsByTagName("table")[0].id;
             var giolamthem = "";
             for(var ii=1;ii<document.getElementById(idtablegiolamthem).rows.length - 1;ii++)
             {
                giolamthem+= document.getElementById(idtablegiolamthem).rows[ii].cells[2].getElementsByTagName("input")[0].value + "|"+document.getElementById(idtablegiolamthem).rows[ii].cells[2].getElementsByTagName("input")[1].value+"|"+document.getElementById(idtablegiolamthem).rows[ii].cells[1].getElementsByTagName("a")[0].id+"@";
             }
             
             var idNguoiDung = "";
             return "../ajax/BangChamCongTheoNgay_ajax2.aspx?do=luuTable&NgayCong=" + encodeURIComponent(NgayCong) + "&idNhanVien=" + encodeURIComponent(idNhanVien) + "&NgayThuong=" + encodeURIComponent(NgayThuong) + "&NgayTruc=" + encodeURIComponent(NgayTruc) + "&PhepKhongLuong=" + encodeURIComponent(PhepKhongLuong) + "&PhepCoLuong=" + encodeURIComponent(PhepCoLuong) + "&LamThemNuaNgay=" + encodeURIComponent(LamThemNuaNgay) + "&LamThemMotNgay=" + encodeURIComponent(LamThemMotNgay) + "&NghiOm=" + encodeURIComponent(NghiOm) + "&VoKyLuat=" + encodeURIComponent(VoKyLuat) + "&NghiBu=" + encodeURIComponent(NghiBu) + "&NghiLe=" + encodeURIComponent(NghiLe) + "&idNguoiDung=" + encodeURIComponent(idNguoiDung) + "&Giolamthem=" + encodeURIComponent(giolamthem);
         }
         function luuphongkhac()
         {
             flagthemgio = false;
             tablegrid = "hoanghiep";
             if(document.getElementById(tablegrid) != null){
              if(controlTableLuuKhac.id.indexOf("luuTable") != -1)
             {
                for(var i=1;i<3;i++){
                 document.getElementById("luuTable_"+i).value = "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("stop") %> ";
                 document.getElementById("luuTable_"+i).id = "huyTable_"+i;
                 }
                 flagtemp = true;
                 row1=0;
                 LuuTable('','flagthemgio = true;row1=1',row1,controlTableLuuKhac,'ListControlLuuTablePhongKhac');
             }
             else{
             flagthemgio = true;
             for(var i=1;i<3;i++){
                 document.getElementById("huyTable_"+i).value = "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ";
                 document.getElementById("huyTable_"+i).id= "luuTable_"+i;
                 }
                 flagtemp = false;
             }
           }
            
         }
         function ListControlLuuTablePhongKhac(i)
         {
            var NgayCong = document.getElementById("<%=NgayCong.ClientID %>").value;
             var idNhanVien = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[1].value;
             var NgayThuong = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].checked;
             var NgayTruc = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("select")[0].value;
             var PhepKhongLuong = document.getElementById(tablegrid).rows[i].cells[5].getElementsByTagName("select")[0].value;
             var PhepCoLuong = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("select")[0].value;
             var LamThemNuaNgay = document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("input")[0].checked;
             var LamThemMotNgay = document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].checked;
             var NghiOm = document.getElementById(tablegrid).rows[i].cells[9].getElementsByTagName("input")[0].checked;
             var VoKyLuat = document.getElementById(tablegrid).rows[i].cells[10].getElementsByTagName("input")[0].checked;
             var NghiBu = document.getElementById(tablegrid).rows[i].cells[11].getElementsByTagName("input")[0].checked;
             var NghiLe = document.getElementById(tablegrid).rows[i].cells[12].getElementsByTagName("input")[0].checked;
             var idtablegiolamthem = document.getElementById(tablegrid).rows[i].cells[13].getElementsByTagName("table")[0].id;
             var giolamthem = "";
             for(var ii=1;ii<document.getElementById(idtablegiolamthem).rows.length - 1;ii++)
             {
                giolamthem+= document.getElementById(idtablegiolamthem).rows[ii].cells[2].getElementsByTagName("input")[0].value + "|"+document.getElementById(idtablegiolamthem).rows[ii].cells[2].getElementsByTagName("input")[1].value+"|"+document.getElementById(idtablegiolamthem).rows[ii].cells[1].getElementsByTagName("a")[0].id+"@";
             }
             
             var idNguoiDung = "";
             return "../ajax/BangChamCongTheoNgay_ajax2.aspx?do=luuTable2&NgayCong=" + encodeURIComponent(NgayCong) + "&idNhanVien=" + encodeURIComponent(idNhanVien) + "&NgayThuong=" + encodeURIComponent(NgayThuong) + "&NgayTruc=" + encodeURIComponent(NgayTruc) + "&PhepKhongLuong=" + encodeURIComponent(PhepKhongLuong) + "&PhepCoLuong=" + encodeURIComponent(PhepCoLuong) + "&LamThemNuaNgay=" + encodeURIComponent(LamThemNuaNgay) + "&LamThemMotNgay=" + encodeURIComponent(LamThemMotNgay) + "&NghiOm=" + encodeURIComponent(NghiOm) + "&VoKyLuat=" + encodeURIComponent(VoKyLuat) + "&NghiBu=" + encodeURIComponent(NghiBu) + "&NghiLe=" + encodeURIComponent(NghiLe) + "&idNguoiDung=" + encodeURIComponent(idNguoiDung) + "&Giolamthem=" + encodeURIComponent(giolamthem);
         }
         function loaddroplist2()
         {
             laydanhsachTodroplist('-- Select one --','','',"../ajax/BangChamCongTheoNgay_ajax2.aspx?do=droplist_idNhanVien", 'ctl00_body_droplistidNhanVien_idNhanVien');
         }
         function chuyendong(control){
        if(event.keyCode == 40){
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null)
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();
        }
        if(event.keyCode == 38){
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null )
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();  
                
                    
        }
        
}
function chuyendong2(control){
    try{
        if(event.keyCode == 40){
                  if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[1].getElementsByTagName("a")[0] == null && document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] == null){
                    themDongTable(tablegrid); 
                }
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null)
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();
        }
        if(event.keyCode == 38){
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null )
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();  
                
                    var flagrow = false;
                    for(var i = 0;i<document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells.length ;i++)
                    {
                        if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0] != null){
                        if( document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].type == "text"){
                            if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].value.length > 0 && document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].value != '0'){
                            flagrow = true;
                            return;
                          }
                         }
                       }
                    }
                if(flagrow == false && document.getElementById(tablegrid).rows.length > 3 && (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells.length - 1].getElementsByTagName('input')[0].value.length < 1 ))
                    document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);
        }
        if(event.keyCode == 27){
            if(control.type == 'text' || document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] != null)
                chuyenformout(control);
        }
        if(event.keyCode == 13){
            if(control.type == 'text' || document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] != null)
            {
                if(control.style.position=='')
                    chuyenform(control);
                else
                    chuyenformout(control);
            }
       }
    }catch(ex){}
}
var flagthemgio = true;
  var tiente = false;
function displaylamthemgio(control)
{
    if(flagthemgio)
    {
        tablegrid = document.getElementById("<%=gridTable.ClientID %>").rows[control.parentNode.parentNode.rowIndex].cells[13].getElementsByTagName("table")[0].id;
        var divs = document.getElementById("<%=gridTable.ClientID %>").rows[control.parentNode.parentNode.rowIndex].cells[13].getElementsByTagName("div")[0];
      
            $(divs).slideToggle("slow");        
        if(tiente == false)
        {
           document.getElementById("<%=gridTable.ClientID %>").rows[control.parentNode.parentNode.rowIndex].cells[13].style.backgroundColor= 'yellow'; 
           tiente = true;
        }
        else{
            document.getElementById("<%=gridTable.ClientID %>").rows[control.parentNode.parentNode.rowIndex].cells[13].style.backgroundColor= 'white'; 
            tiente = false;
        }
        if(document.getElementById(tablegrid).rows[1].cells[2].getElementsByTagName("input")[0].value.length > 0 || document.getElementById(tablegrid).rows[1].cells[2].getElementsByTagName("input")[1].value.length > 0)
        {
            control.style.backgroundColor= "blue";
        }
    }
}
function laylaichuyendong(obj)
    {
        tablegrid = "hoanghiep";
        $(obj).unautocomplete().autocomplete("../ajax/BangChamCongTheoNgay_ajax2.aspx?do=getnhanvien&ngaythang="+document.getElementById("<%=NgayCong.ClientID %>").value+"&sodong="+obj.parentNode.parentNode.rowIndex,
        {formatItem: function(data) {
                 return data[1];
            },width:900,scroll:true}
        )
        
        .result(function(event, data){
            themdongtable2(obj);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[0].value = data[1];
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[1].value = data[0];
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[3].getElementsByTagName("input")[0].checked = kieuso(data[2]);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[4].innerHTML = data[14];
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[5].innerHTML = data[4];
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[6].innerHTML = data[5];
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[7].getElementsByTagName("input")[0].checked = kieuso(data[6]);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[8].getElementsByTagName("input")[0].checked = kieuso(data[7]);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[9].getElementsByTagName("input")[0].checked = kieuso(data[8]);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[10].getElementsByTagName("input")[0].checked = kieuso(data[9]);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[11].getElementsByTagName("input")[0].checked = kieuso(data[10]);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[12].getElementsByTagName("input")[0].checked = kieuso(data[11]);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[13].innerHTML = data[12];
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[14].getElementsByTagName("input")[0].value = data[13];
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[1].getElementsByTagName("a")[0].name = data[13];	           
	           obj.blur();
	           obj.focus(); 
        });
    }
    function kieuso(chuoi)
    {
        if(chuoi == "true")
            return 1;
        else
            return 0;    
    }
    
    function themdongtable2(obj)
    {
        if(document.getElementById("hoanghiep").rows[obj.parentNode.parentNode.rowIndex + 1] == null){
        $("#hoanghiep").append("<tr onmouseover=\"if(this.style.backgroundColor != 'red'){this.style.backgroundColor='#F6EBCD',this.style.cursor = 'pointer'}\" onmouseout=\"if(this.style.backgroundColor != 'red'){this.style.backgroundColor='White'}\" style=\"color:#003399;background-color:White;\">"
            +"<td style='width:14px'>"
            +"</td><td style='width:35px'>"
            +"<a onkeydown=\"chuyendong(this);\" style='text-decoration: none; cursor: pointer;"
            +"margin-right: 10px; color: green;' onclick=\"xoaontablehoanghiep(this.name,this);\" name=\"\">"
            +"<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
            +"</a>"
            +"</td><td style='width:202px'>"
            +"<input name=\"ctl00$body$gridTable$ctl08$Text1\" type=\"text\" id=\"ctl00_body_gridTable_ctl08_Text1\" style=\"width:190px\" onfocus=\"laylaichuyendong(this);\" value=\"\" />"
            +"<input type=\"hidden\" name=\"ctl00$body$gridTable$ctl08$idnv\" id=\"ctl00_body_gridTable_ctl08_idnv\" value=\"108\" />"
            +"</td><td style='width:39px'>"
            +"<input name=\"ctl00$body$gridTable$ctl08$ctl00\" type=\"checkbox\" onkeydown=\"chuyendong(this);\" style=\"width: 15px; border: none\" />"
            +"</td><td style='width:95px'>"
            
            +"</td><td style='width:95px'>"
            
            +"</td><td style='width:95px'>"
            
            +"</td><td style='width:28px'>"
            +"<input name=\"ctl00$body$gridTable$ctl08$ctl04\" type=\"checkbox\" onkeydown=\"chuyendong(this);\" style=\"width: 15px; border: none\" />"
            +"</td><td style='width:27px'>"
            +"<input name=\"ctl00$body$gridTable$ctl08$ctl05\" type=\"checkbox\" onkeydown=\"chuyendong(this);\" style=\"width: 15px; border: none\" />"
            +"</td><td style='width:27px'>"
            +"<input name=\"ctl00$body$gridTable$ctl08$ctl06\" type=\"checkbox\" onkeydown=\"chuyendong(this);\" style=\"width: 15px; border: none\" />"
            +"</td><td style='width:19px'>"
            +"<input name=\"ctl00$body$gridTable$ctl08$ctl07\" type=\"checkbox\" onkeydown=\"chuyendong(this);\" style=\"width: 15px; border: none\" />"
            +"</td><td style='width:27px'>"
            +"<input name=\"ctl00$body$gridTable$ctl08$ctl08\" type=\"checkbox\" onkeydown=\"chuyendong(this);\" style=\"width: 15px; border: none\" />"
            +"</td><td style='width:28px'>"
            +"<input name=\"ctl00$body$gridTable$ctl08$ctl09\" type=\"checkbox\" onkeydown=\"chuyendong(this);\" style=\"width: 15px; border: none\" />"
            +"</td><td style=\"width:100px;\">"
            +"</td><td style='width:35px'>"
            +"<input type=\"hidden\" value='' />"
            +"</td>"
            +"</tr>");
            }
    }
    function chuyendong(control){
    try{
        if(event.keyCode == 40){
                
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null)
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();
        }
        if(event.keyCode == 38){
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null )
                     document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
                if(document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null)
                    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();  
                
        }
        
    }catch(ex){}
}
var flagthemgio2 = true;
  var tiente2 = false;
function displaylamthemgio2(control)
{
    if(flagthemgio2)
    {
        tablegrid = document.getElementById("hoanghiep").rows[control.parentNode.parentNode.rowIndex].cells[13].getElementsByTagName("table")[0].id;
        var divs = document.getElementById("hoanghiep").rows[control.parentNode.parentNode.rowIndex].cells[13].getElementsByTagName("div")[0];
      
            $(divs).slideToggle("slow");        
        if(tiente2 == false)
        {
           document.getElementById("hoanghiep").rows[control.parentNode.parentNode.rowIndex].cells[13].style.backgroundColor= 'yellow'; 
           tiente2 = true;
        }
        else{
            document.getElementById("hoanghiep").rows[control.parentNode.parentNode.rowIndex].cells[13].style.backgroundColor= 'white'; 
            tiente2 = false;
        }
        if(document.getElementById(tablegrid).rows[1].cells[2].getElementsByTagName("input")[0].value.length > 0 || document.getElementById(tablegrid).rows[1].cells[2].getElementsByTagName("input")[1].value.length > 0)
        {
            control.style.backgroundColor= "blue";
        }
    }
}

function checkchon(control)
{
    tablegrid = "<%=gridTable.ClientID %>"    
    if(control.checked == true)
    {
        for(var i=1;i<document.getElementById(tablegrid).rows.length - 1;i++)
        {
            try{
                if(control.value == "ngaythuong")
                {
                    document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].checked = true;
                }
                else if(control.value == "lamthemnuangay")
                {
                    document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("input")[0].checked = true;
                }
                else if(control.value == "lamthemmotngay")
                {
                    document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].checked = true;
                }
                else if(control.value == "nghiom")
                {
                    document.getElementById(tablegrid).rows[i].cells[9].getElementsByTagName("input")[0].checked = true;
                }
                else if(control.value == "vokyluat")
                {
                    document.getElementById(tablegrid).rows[i].cells[10].getElementsByTagName("input")[0].checked = true;
                }
                else if(control.value == "nghibu")
                {
                    document.getElementById(tablegrid).rows[i].cells[11].getElementsByTagName("input")[0].checked = true;
                }
                else if(control.value == "nghile")
                {
                    document.getElementById(tablegrid).rows[i].cells[12].getElementsByTagName("input")[0].checked = true;
                }
            }catch(ex){}
        }
    }else{
        for(var i=1;i<document.getElementById(tablegrid).rows.length - 1;i++)
        {
            try{
                if(control.value == "ngaythuong")
                {
                    document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].checked = false;
                }
                else if(control.value == "lamthemnuangay")
                {
                    document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("input")[0].checked = false;
                }
                else if(control.value == "lamthemmotngay")
                {
                    document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].checked = false;
                }
                else if(control.value == "nghiom")
                {
                    document.getElementById(tablegrid).rows[i].cells[9].getElementsByTagName("input")[0].checked = false;
                }
                else if(control.value == "vokyluat")
                {
                    document.getElementById(tablegrid).rows[i].cells[10].getElementsByTagName("input")[0].checked = false;
                }
                else if(control.value == "nghibu")
                {
                    document.getElementById(tablegrid).rows[i].cells[11].getElementsByTagName("input")[0].checked = false;
                }
                else if(control.value == "nghile")
                {
                    document.getElementById(tablegrid).rows[i].cells[12].getElementsByTagName("input")[0].checked = false;
                }
            }catch(ex){}
        }
    }
}

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;
        background: white">
        <div style="padding: 2px 0px 2px 0px; background-color: #4473ca; border: 1px solid #cfcfcf;
            text-align: center; color: White; font-size: 25px; font-weight: bold">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("BangChamCongTheoNgay")%>
        </div>
        <div style="display: table-row; padding-bottom: 50px">
            <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; height: 40px;
                border-right: 1px solid #cfcfcf; border-bottom: 1px solid #cfcfcf;">
                <div style="float: left; padding: 10px 0px 10px 0px">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayCong") %>
                    :                   
                    </div>
                <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                    <input runat="server" id="NgayCong" type="text" onblur="TestDate(this);"  onkeyup="chuyenphim(this)" />dd/MM/yyyy
                     
                    </div>
            </div>
            <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; height: 40px;
                border-right: 1px solid #cfcfcf; border-bottom: 1px solid #cfcfcf;">
                <div style="float: left; padding: 10px 0px 10px 0px">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loainhanvien")%>
                    :</div>
                <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                    <asp:DropDownList ID="ddlLoaiNhanVien" runat="server">
                         <asp:ListItem Value="1">Thuong xuyen</asp:ListItem>
                         <asp:ListItem Value="2">Ko thuong xuyen</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; height: 40px;
                border-right: 1px solid #cfcfcf; border-bottom: 1px solid #cfcfcf;">
                <div style="float: left; padding: 10px 0px 10px 0px">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("phongban") %>
                    :</div>
                <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                    <asp:DropDownList ID="ddlPhongBan" TabIndex="1" runat="server" CssClass="input" Width="100%"
                        OnSelectedIndexChanged="ddlPhongBan_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; height: 40px;
                border-right: 1px solid #cfcfcf; border-bottom: 1px solid #cfcfcf;">
                <div style="float: left; padding: 10px 0px 10px 0px">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idnhanvien") %>
                    :</div>
                <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                    <input runat="server" style="width: 250px" id="idNguoiDung" type="text" onkeyup="chuyenphim(this)" /></div>
            </div>
            
        </div>
    </div>
    
    <div style="border: 1px solid #cfcfcf; background: white; text-align: center; padding: 5px 5px 5px 5px;
        border-top: none;">
        
        <div style="padding: 10px 0 10px 0;">
            <input id="luuTable_1" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>"
                onclick="btLuuTable(this,'ListControlLuuTable');" />
            <asp:Button UseSubmitBehavior="false" ID="Button1" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("timkiem") %>'
                OnClick="Button1_Click" />
        </div>
        <div style="overflow: auto">
            <asp:GridView Width="100%" ID="gridTable" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="idChamCongTheoNgay" BackColor="White" PageSize="100" OnPageIndexChanging="gridTable_PageIndexChanging"
                OnRowDataBound="gridTable_RowDataBound" BorderColor="#3366CC" BorderStyle="None"
                BorderWidth="1px" CellPadding="4" AllowSorting="True" ShowFooter="true">
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                        <ItemTemplate>
                            <%#Eval("STT") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a onkeydown="chuyendong(this);" style='text-decoration: none; cursor: pointer;
                                margin-right: 10px; color: green;' onclick="xoaontable(this.name,this);" name="<%#Eval("idChamCongTheoNgay") %>">
                                <%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="idNhanVien">
                    <HeaderTemplate>
                            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idNhanVien")%>                        
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="idnv" runat="server" Value='<%#Eval("idnhanvien") %>' />
                            <asp:Label ID="Label1" runat="server" Width="200px" Text='<%#Eval("tennhanvien") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NgayThuong" >
                    <HeaderTemplate>
                        <div style="height:60px">
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayThuong")%>                        
                        </div>
                        <input type="checkbox" onclick="checkchon(this)" value="ngaythuong"/>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <input id="Checkbox1" type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none"
                                checked='<%#checks(Eval("NgayThuong")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NgayTruc">
                        <HeaderTemplate>
                            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayTruc")%>                        
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" Width="90px">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PhepKhongLuong">
                    <HeaderTemplate>
                            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PhepKhongLuong")%>                        
                        </HeaderTemplate>
                        <ItemTemplate>
                             <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" Width="90px">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PhepCoLuong">
                    <HeaderTemplate>
                            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("PhepCoLuong")%>                        
                        </HeaderTemplate>
                        <ItemTemplate>
                             <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="True" Width="90px">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LamThemNuaNgay">
                    <HeaderTemplate>
                    <div style="height:60px">
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LamThemNuaNgay")%>
                        </div>
                        <input type="checkbox" onclick="checkchon(this)" value="lamthemnuangay"/>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <input id="Checkbox2" type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none"
                                checked='<%#checks(Eval("LamThemNuaNgay")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LamThemMotNgay">
                    <HeaderTemplate>
                    <div style="height:60px">
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("LamThemMotNgay")%>
                        </div>
                        <input type="checkbox" onclick="checkchon(this)" value="lamthemmotngay"/>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <input id="Checkbox3" type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none"
                                checked='<%#checks(Eval("LamThemMotNgay")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NghiOm">
                    <HeaderTemplate>
                    <div style="height:60px">
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NghiOm")%>
                        </div>
                        <input type="checkbox" onclick="checkchon(this)" value="nghiom"/>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <input id="Checkbox4" type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none"
                                checked='<%#checks(Eval("NghiOm")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VoKyLuat">
                    <HeaderTemplate>
                    <div style="height:60px">
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("VoKyLuat")%>
                        </div>
                        <input type="checkbox" onclick="checkchon(this)" value="vokyluat"/>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <input id="Checkbox5" type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none"
                                checked='<%#checks(Eval("VoKyLuat")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NghiBu">
                    <HeaderTemplate>
                    <div style="height:60px">
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NghiBu")%>
                        </div>
                        <input type="checkbox" onclick="checkchon(this)" value="nghibu"/>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <input id="Checkbox6" type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none"
                                checked='<%#checks(Eval("NghiBu")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NghiLe">
                    <HeaderTemplate>
                    <div style="height:60px">
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NghiLe")%>
                        </div>
                        <input type="checkbox" onclick="checkchon(this)" value="nghile"/>
                    </HeaderTemplate>
                        <ItemTemplate>
                            <input id="Checkbox7" type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none"
                                checked='<%#checks(Eval("NghiLe")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GioLamThem">
                    <HeaderTemplate>
                            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("GioLamThem")%>                        
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input type="button" value="..." onclick="displaylamthemgio(this);" id="displaygio"
                                runat="server" />
                            <div style="display: none; position: absolute; margin-left: -100px; margin-top: 20px">
                                <asp:GridView Width="200px" ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    ShowFooter="True" BackColor="White" BorderColor="#CC9966" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField HeaderText="stt">
                                            <ItemTemplate>
                                                <%#Eval("STT") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a onkeydown="chuyendong(this);" style='text-decoration: none; cursor: pointer;
                                                    margin-right: 10px; color: green;' onclick="xoaontable2(this.name,this);" name="<%#Eval("idlamthemgio") %>">
                                                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GioLamThem">
                                            <ItemTemplate>
                                                <input id="Text1" type="text" onkeydown="chuyendong2(this);" style="width: 50px; border: none"
                                                    runat="server" value='<%#Eval("giobatdau") %>' title='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("Startime") %>'
                                                    onblur="checkTimes(this);" />
                                                <input id="Text2" type="text" onkeydown="chuyendong2(this);" style="width: 50px; border: none"
                                                    runat="server" value='<%#Eval("gioketthuc") %>' title='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("Endtime") %>'
                                                    onblur="checkTimes(this);" />
                                            </ItemTemplate>
                                            <ItemStyle Width="250px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                </asp:GridView>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="250px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="dongluu" Visible="False">
                        <ItemTemplate>
                            <input onclick="checkluu(this)" type="checkbox" onkeydown="chuyendong(this);" style="border: none" />
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <input type="hidden" value='<%#Eval("idChamCongTheoNgay") %>' />
                        </ItemTemplate>
                        <HeaderStyle Width="150px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle BackColor="White" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <HeaderStyle BackColor="#4473ca" Font-Bold="True" ForeColor="#CCCCFF" />
                <FooterStyle BackColor="#4473ca" ForeColor="#003399" />
            </asp:GridView>
        </div>
        <table id="hoanghiep" cellspacing="0" cellpadding="4" rules="all" style="background-color:#990000 ;border-color: #CC9966; border-width: 1px;
         border-style: None;width:100%; border-collapse: collapse;">
            <tr onmouseover="if(this.style.backgroundColor != 'red'){this.style.backgroundColor='#F6EBCD',this.style.cursor = 'pointer'}"
                onmouseout="if(this.style.backgroundColor != 'red'){this.style.backgroundColor='White'}"
                style="color: #003399; background-color: White;">
                <td style="width:14px">
                </td>
                <td style="width:35px">
                    <a onkeydown="chuyendong(this);" style='text-decoration: none; cursor: pointer;
                        margin-right: 10px; color: green;' onclick="xoaontablehoanghiep(this.name,this);" name="">
                        <%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %> </a>
                </td>
                <td style="width:202px">
                    <input name="ctl00$body$gridTable$ctl09$Text1" type="text" id="ctl00_body_gridTable_ctl09_Text1"
                        style="width: 190px" onfocus="laylaichuyendong(this);" />
                    <input type="hidden" name="ctl00$body$gridTable$ctl09$idnv" id="ctl00_body_gridTable_ctl09_idnv" />
                </td>
                <td style="width:39px">
                    <input type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none" />
                </td>
                <td style="width:95px">
                    
                </td>
                <td style="width:95px">
                </td>
                <td style="width:95px">
                </td>
                <td style="width:28px">
                    <input type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none" />
                </td>
                <td style="width:27px">
                    <input type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none" />
                </td>
                <td style="width:27px">
                    <input type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none" />
                </td>
                <td style="width:19px">
                    <input type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none" />
                </td>
                <td style="width:27px">
                    <input type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none" />
                </td>
                <td style="width:28px">
                    <input type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none" />
                </td>
                <td style="width:100px">
                    
                </td>
                <td style="width:35px">
                    <input type="hidden" />
                </td>
            </tr>
        </table>
        <div style="padding: 10px 0 10px 0;">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />                
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'
                onclick="btLuuTable(this,'ListControlLuuTable');" />
        </div>
    </div>
</asp:Content>

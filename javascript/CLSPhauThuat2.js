              var flagtemp;
         $(document).ready(function() {
                tablegrid="ctl00_body_gridTable";
       khoachinhcapnhatdulieu = "idkhoachinh";
       for (var i = 0; i < document.forms[0].elements.length; i++) {
         if (document.forms[0].elements[i].type == "text")
         {
             if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
                { setTimeout("document.forms[0].elements["+i+"].focus()",100);
             return false;}
         }
      }
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
                             document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);
                         }
                         else {
                             alert('Xoá không thành công !');
                         }
                     }
                 }
                 xmlHttp.open("GET", "../ajax/CLSPhauThuat_ajax2.aspx?do=xoa&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);}
              
         }
         //ham tim kiem du lieu theo danh sach ham functionlistcontroltimkiem
         function Find(control, functionlistcontroltimkiem) {
 if(event.keyCode == 113){
             document.getElementById("ctl00_body_HiddenField1").value = eval(functionlistcontroltimkiem)(control);
             $("#ctl00_body_Button1").click();
             }
         }
         //tim kiem du lieu voi phim F2,Enter cua cac control
         function ListControlTimKiemidchitietCLSPhauThuat(control) {
             return " idchitietCLSPhauThuat = '"+control.value+"'";
         }
         function ListControlTimKiemidcaphauthuat(control) {
             return " idcaphauthuat = '"+control.value+"'";
         }
  function btLuuTable(control,functionlistcontroluutable)
          {
              if(document.getElementById(tablegrid) != null){
               if(control.id.indexOf("luuTable") != -1)
              {
                 for(var i=1;i<3;i++){
                  document.getElementById("luuTable_"+i).value = "Dừng ";
                  document.getElementById("luuTable_"+i).id = "huyTable_"+i;
                  }
                  flagtemp = true;
                  LuuTable('','',row1,control,functionlistcontroluutable);
              }
              else{
              for(var i=1;i<3;i++){
                  document.getElementById("huyTable_"+i).value = "Dừng";
                  document.getElementById("huyTable_"+i).id= "luuTable_"+i;
                  }
                  flagtemp = false;
              }
            }
              
          }
         function ListControlLuuTable(i)
         {
             var idchitietCLSPhauThuat = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[1].value;
             var idcaphauthuat = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("select")[0].value;
             return "../ajax/CLSPhauThuat_ajax2.aspx?do=luuTable&idchitietCLSPhauThuat=" + encodeURIComponent(idchitietCLSPhauThuat) + "&idcaphauthuat=" + encodeURIComponent(idcaphauthuat) + "";
         }
        function timkiemCLS(control){
            $(control).unautocomplete().autocomplete("../ajax/CLSPhauThuat_ajax2.aspx?do=timkiemCLS",{
	            scroll: true,width:600,formatItem: function(data) {
                checkchuyenphim=false;;return data[0];
            }
	            }).result(function(event, data){
	                document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[1].value  = data[1];
	            });
         }
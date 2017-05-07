              var flagtemp,idthuoc,sttindm05,tenthuoc,congthuc,idhangsanxuat,idnuocsx,idnhomthuoc,sudungchobh,iddvt,LoaiThuocID,idcachdung,TTHoatChat,cateid;
         $(document).ready(function() {
             sttindm05 = document.getElementById("ctl00_body_sttindm05_sttindm05");
             tenthuoc = document.getElementById("ctl00_body_tenthuoc_tenthuoc");
             congthuc = document.getElementById("ctl00_body_congthuc_congthuc");
             idnuocsx = document.getElementById("ctl00_body_idnuocsx_idnuocsx");
             idhangsanxuat = document.getElementById("ctl00_body_idhangsanxuat_idhangsanxuat");
             idnhomthuoc= document.getElementById("ctl00_body_idnhomthuoc_idnhomthuoc");
             sudungchobh = document.getElementById("ctl00_body_sudungchobh_sudungchobh");
             iddvt = document.getElementById("ctl00_body_iddvt_iddvt");
             LoaiThuocID = document.getElementById("ctl00_body_LoaiThuocID_LoaiThuocID");
             idcachdung = document.getElementById("ctl00_body_idcachdung_idcachdung");
             TTHoatChat = document.getElementById("ctl00_body_TTHoatChat_TTHoatChat");
             cateid = document.getElementById("ctl00_body_cateid_cateid");        
                  
              tablegrid="ctl00_body_gridTable";
              valueButtonSaveGrid = "Cập nhật danh sách";
 for (var i = 0; i < document.forms[0].elements.length; i++) {
         if (document.forms[0].elements[i].type == "text")
         {
             if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
                { setTimeout("document.forms[0].elements["+i+"].focus()",100);
             return false;}
         }
      }
         });
         //ham nay bat buoc phai co de Xoa,Sua,Timkiem du lieu
         // ham set du lieu cho cac control khi lua chon du lieu tim kiem
         function setControlFind(idkhoatimkiem,valueControlSua) {
                 
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                     var value = xmlHttp.responseText.split("@");
                     
         tenthuoc.value = value[2];
          idhangsanxuat.value = value[4];
         if(value[6] == 'True')
                                 sudungchobh.checked = true;
                             else
                                 sudungchobh.checked = false;
          iddvt.value = value[7];
                loadDropDownListcategory(value[8]);
          
          idcachdung.value = value[9];
         cateid.value = value[11];    
          idnuocsx.value = value[12];
              
                    setTimeout("setf()",100);
                     //set khoa chinh len querystring va hien nut xoa,sua
                     XoaControlAfterFind(value[0],valueControlSua);
                     if(currentRow != null){currentRow=0}
                 }
             }
             xmlHttp.open("GET", "../ajax/frm_DM_Thuoc_ajax.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem + "&times=" + Math.random(), true);
             xmlHttp.send(null);
         }
         //ham tim kiem du lieu theo danh sach ham functionlistcontroltimkiem
        
         //tim kiem du lieu voi phim F2,Enter cua cac control
         function ListControlTimKiemsttindm05(control) {
             return " sttindm05 like N'%"+control.value+"%'";
         }
         function ListControlTimKiemtenthuoc(control) {
             return " tenthuoc like N'%"+control.value+"%'";
         }
         function ListControlTimKiemcongthuc(control) {
             return " congthuc like N'%"+control.value+"%'";
         }
         function ListControlTimKiemidhangsanxuat(control) {
             return " idhangsanxuat = '"+control.value+"'";
         }
         function ListControlTimKiemidnhomthuoc(control) {
             return " idnhomthuoc = '"+control.value+"'";
         }
         function ListControlTimKiemsudungchobh(control) {
             return " sudungchobh like N'%"+control.checked+"%'";
         }
         function ListControlTimKiemiddvt(control) {
             return " iddvt = '"+control.value+"'";
         }
         function ListControlTimKiemLoaiThuocID(control) {
             return " LoaiThuocID = '"+control.value+"'";
         }
         function ListControlTimKiemidcachdung(control) {
             return " IdCachDung = '"+control.value+"'";
         }
         function ListControlTimKiemTTHoatChat(control) {
             return " TTHoatChat like N'%"+control.value+"%'";
         }
         //ham lay control de insert du lieu
         function ListControlThem() {
             return "../ajax/frm_DM_Thuoc_ajax.aspx?do=Them"
             +"&tenthuoc="+ encodeURIComponent(tenthuoc.value)
             +"&idhangsanxuat="+ encodeURIComponent(idhangsanxuat.value)
             +"&cateid="+ cateid.value
             +"&sudungchobh=" + sudungchobh.checked
             +"&iddvt="+ encodeURIComponent(iddvt.value)
             +"&LoaiThuocID=2"
             +"&idcachdung="+ encodeURIComponent(idcachdung.value)
             +"&idnuocsx="+ encodeURIComponent(idnuocsx.value);
             
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../ajax/frm_DM_Thuoc_ajax.aspx?do=Sua"
            +"&tenthuoc="+ encodeURIComponent(tenthuoc.value)
             +"&idhangsanxuat="+ encodeURIComponent(idhangsanxuat.value)
             +"&cateid="+ cateid.value
             +"&sudungchobh=" + sudungchobh.checked
             +"&iddvt="+ encodeURIComponent(iddvt.value)
             +"&LoaiThuocID=2"
             +"&idcachdung="+ encodeURIComponent(idcachdung.value)
             +"&idnuocsx="+ encodeURIComponent(idnuocsx.value)
             + "&idkhoachinh=" + idkhoachinh;
         }
          var controlluuphieunhap = "";
         function FunctionLuu(control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua)
         {
             controlluuphieunhap = control;
            Luu('','',control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua);
         }
         // ham xoa du lieu voi querystring khoa chinh
         function Xoa(control,valueControlLuu) {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             //xoa du lieu voi idkhoachinh va hien nut luu,an nut xoa,sua
              var hoi = confirm("Xác nhận !");                  if(hoi){
                $.ajax({
                    type:"GET",
                    cache:false,
                    url:"../ajax/frm_DM_Thuoc_ajax.aspx?do=ktrathuoc&idkhoachinh=" + idkhoachinh,
                    success:function (data) {
                        if(data != ""){
                            alert(data);
                        }
                        else{
                          Xoakhoachinh('','',"../ajax/frm_DM_Thuoc_ajax.aspx?do=xoa&idkhoachinh=" + idkhoachinh,valueControlLuu);  
                        }
                    }
                    
                
                }); 
                          
         }}
         
         function laydanhsachTodroplist(defaultvalue,functionScriptBefore,functionScriptAfter,ajax, iddroplist) {
    if(functionScriptBefore != "")
        var before = eval(functionScriptBefore)();
    var xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function() {
        if (xmlHttp.readyState == 4) {
                if (document.getElementById(iddroplist) != null) {
                    var droplist = document.getElementById(iddroplist);
                    droplist.options.length = 0;
                    droplist.options[droplist.options.length] = new Option(defaultvalue,"");
                    var mangValue = xmlHttp.responseText.split("@");
                    for (var i = 1; i < mangValue.length; i++) {
                        var mangText = mangValue[i].split("^");
                        droplist.options[droplist.options.length] = new Option(mangText[1], mangText[0]);
                    }
                }
                else {
                    alert("Control DropList không tồn tại !");
                }
                if(functionScriptAfter != "")
                        var after = eval(functionScriptAfter)(xmlHttp.responseText);
        }
    }
    xmlHttp.open("GET", ajax + "&times=" + Math.random(), false);
    xmlHttp.send(null);
}

         function LamMoi(valueControlLuu) {
             // an nut sua,xoa,hien nut luu
             Moi(valueControlLuu);
         }
         
         function Find(control, functionlistcontroltimkiem) {
    if(event.keyCode == 113){
             document.getElementById("<%=HiddenField1.ClientID %>").value = eval(functionlistcontroltimkiem)(control);
             $("#<%=Button1.ClientID %>").click();
             }
         }
        function idnhomthuocchange(control) {

            document.getElementById("ctl00_body_HiddenField4").value = control.value;
            
         }
         function cateidchange(control) {
            document.getElementById("ctl00_body_HiddenField4").value = "";
            document.getElementById("ctl00_body_HiddenField3").value = control.value;         
         }
          function loadDropDownListidnhomthuoc(values)
         {
             laydanhsachTodroplist('-- Select one --','','',"../ajax/frm_DM_Thuoc_ajax.aspx?do=DropDownList_idnhomthuoc&cateid="+values, "ctl00_body_idnhomthuoc_idnhomthuoc");
         }
          function loadDropDownListcategory(values)
         {
            if(values == 1){
                 
            }else{
                 
            }
             laydanhsachTodroplist('-- Select one --','','',"../ajax/frm_DM_Thuoc_ajax.aspx?do=DropDownList_category&loai=2", "ctl00_body_cateid_cateid");
            document.getElementById("ctl00_body_HiddenField3").value = "";
         }
         function xoaontable(idkhoachinh,control){
             if(idkhoachinh.length > 0){
             var hoi = confirm("Xác nhận !");
             if(hoi){
                $.ajax({
                    type:"GET",
                    cache:false,
                    url:"../ajax/frm_DM_Thuoc_ajax.aspx?do=ktrathuoc&idkhoachinh=" + idkhoachinh,
                    success:function (data) {
                        if(data != ""){
                            alert(data);
                        }
                        else{
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
                         xmlHttp.open("GET", "../ajax/frm_DM_Thuoc_ajax.aspx?do=xoa&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                         xmlHttp.send(null);
                 }
                    }
                    
                
                }); 
             }
             }
             else{document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);}
              
         }
         
         function btLuuTable(control,functionlistcontroluutable)
          {
              if(document.getElementById(tablegrid) != null){
               if(control.id.indexOf("luuTable") != -1)
              {
                 for(var i=1;i<3;i++){
                  document.getElementById("luuTable_"+i).value = "Dừng";
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
             var tenthuoc = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].value;
             var IdCachDung = document.getElementById(tablegrid).rows[i].cells[5].getElementsByTagName("select")[0].value;
             var iddvt = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("select")[0].value;             
             var idhangsanxuat = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("select")[0].value;
             var idnuocsanxuat = document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("select")[0].value;
             var sudungchobh = document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].checked;
             return "../ajax/frm_DM_Thuoc_ajax.aspx?do=luuTable"
             + "&tenthuoc=" + encodeURIComponent(tenthuoc) 
             + "&IdCachDung=" + encodeURIComponent(IdCachDung) 
             + "&idhangsanxuat=" + encodeURIComponent(idhangsanxuat)
             + "&idnuocsanxuat=" + encodeURIComponent(idnuocsanxuat) 
             + "&sudungchobh=" + encodeURIComponent(sudungchobh)
              + "&iddvt=" + encodeURIComponent(iddvt) 
              + "&LoaiThuocID=2"
              + "&cateid=" + encodeURIComponent(cateid.value) ;
         }
         function ExtendtionLuu(flag) {
    if (flag == true) {
        tenthuoc.disabled = true;
        idhangsanxuat.disabled = true;
        idnuocsx.disabled = true;
        sudungchobh.disabled  = true;
        iddvt.disabled = true;
        idcachdung.disabled = true;
        cateid.disabled = true;
    }
    else {
        tenthuoc.disabled = false;
        idnuocsx.disabled = false;
        idhangsanxuat.disabled = false;
        sudungchobh.disabled  = false;
        iddvt.disabled = false;
        idcachdung.disabled = false;
        cateid.disabled = false;
    }
}

function Moi(valueControlLuu) {
    if (location.hash.match(khoachinhcapnhatdulieu)) {
        location.hash = location.hash.replace(khoachinhcapnhatdulieu + "=" + queryString(khoachinhcapnhatdulieu), "");
    }
    if (document.getElementById(controlXoa) != null) {
        document.getElementById(controlXoa).style.display = "none";
    }

    if (document.getElementById(controlLuu) != null) {
        document.getElementById(controlLuu).id = controlLuu;
        document.getElementById(controlLuu).value = valueControlLuu;
    }
    if (document.getElementById(controlSua) != null) {
        document.getElementById(controlSua).id = controlLuu;
        document.getElementById(controlLuu).value = valueControlLuu;
    }
        tenthuoc.value = "";
        idhangsanxuat.selectedIndex = 0;
        idnuocsx.selectedIndex = 0;
        sudungchobh.value  = "";
        iddvt.value = "";
        idcachdung.selectedIndex = 0;
        cateid.selectedIndex = "";
    
    ExtendtionLuu(false);
}
         

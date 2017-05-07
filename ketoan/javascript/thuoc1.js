              var flagtemp,idthuoc,sttindm05,tenthuoc,congthuc,idhangsanxuat,idnuocsx,idnhomthuoc,sudungchobh,iddvt,LoaiThuocID,idcachdung,TTHoatChat,cateid
              ,ISTPX
            ,ISTKS
            ,ISTDTL
            ,ISTcorticoid;            
         $(document).ready(function() {
             getcontrol();
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
         function getcontrol() {
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
             IsTGN= document.getElementById("ctl00_body_IsTGN_IsTGN");
             IsTHTT = document.getElementById("ctl00_body_IsTHTT_IsTHTT");
             ISTPX = document.getElementById("ctl00_body_ISTPX_ISTPX");
             ISTKS = document.getElementById("ctl00_body_ISTKS_ISTKS");
             ISTDTL = document.getElementById("ctl00_body_ISTDTL_ISTDTL");
             ISTcorticoid = document.getElementById("ctl00_body_ISTcorticoid_ISTcorticoid");
         }
         //ham nay bat buoc phai co de Xoa,Sua,Timkiem du lieu
         // ham set du lieu cho cac control khi lua chon du lieu tim kiem
         function setControlFind(idkhoatimkiem,valueControlSua) {
                 getcontrol();
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                     var value = xmlHttp.responseText.split("@");
         sttindm05.value = value[1];
          tenthuoc.value = value[2];
         congthuc.value = value[3];
          idhangsanxuat.value = value[4];
         if(value[6] == 'True')
                 sudungchobh.checked = true;
             else
                 sudungchobh.checked = false;
          iddvt.value = value[7];
          LoaiThuocID.value = value[8];
                loadDropDownListcategory(value[8]);
          
          idcachdung.value = value[9];
         TTHoatChat.value = value[10]; 
         cateid.value = value[11];    
                loadDropDownListidnhomthuoc(value[11]);     
         
          idnhomthuoc.value = value[5];
          idnuocsx.value = value[12];
          
         ISTPX.checked=(value[13] == 'True'? true:false);
         ISTKS.checked=(value[14] == 'True'? true:false);
         ISTDTL.checked=(value[15] == 'True'? true:false);
         ISTcorticoid.checked=(value[16] == 'True'? true:false);
                                
                    setTimeout("setf()",100);
                     //set khoa chinh len querystring va hien nut xoa,sua
                     XoaControlAfterFind(value[0],valueControlSua);
                     if(currentRow != null){currentRow=0}
                 }
             }
             xmlHttp.open("GET", "../KeToan/ajax/thuoc_ajax1.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem + "&times=" + Math.random(), true);
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
             return "../KeToan/ajax/thuoc_ajax1.aspx?do=Them&sttindm05="+ encodeURIComponent(sttindm05.value)
             +"&tenthuoc="+ encodeURIComponent(tenthuoc.value)
             +"&congthuc="+ encodeURIComponent(congthuc.value)
             +"&idhangsanxuat="+ encodeURIComponent(idhangsanxuat.value)
             +"&idnhomthuoc="+ idnhomthuoc.value
             +"&cateid="+ cateid.value
             +"&sudungchobh=" + sudungchobh.checked
             +"&iddvt="+ encodeURIComponent(iddvt.value)
             +"&LoaiThuocID="+ encodeURIComponent(LoaiThuocID.value)
             +"&idcachdung="+ encodeURIComponent(idcachdung.value)
             +"&idnuocsx="+ encodeURIComponent(idnuocsx.value)
             + "&IsTGN=" +  IsTGN.checked
              + "&IsTHTT=" +  IsTHTT.checked
               + "&ISTPX=" +  ISTPX.checked
               + "&ISTKS=" +  ISTKS.checked
               + "&ISTDTL=" +  ISTDTL.checked
               + "&ISTcorticoid=" +  ISTcorticoid.checked
              
             +"&TTHoatChat="+ encodeURIComponent(TTHoatChat.value);
             
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../KeToan/ajax/thuoc_ajax1.aspx?do=Sua&sttindm05=" + encodeURIComponent(sttindm05.value) 
            +"&tenthuoc="+ encodeURIComponent(tenthuoc.value)
             +"&congthuc="+ encodeURIComponent(congthuc.value)
             +"&idhangsanxuat="+ encodeURIComponent(idhangsanxuat.value)
             +"&idnhomthuoc="+ idnhomthuoc.value
             +"&cateid="+ cateid.value
             +"&sudungchobh=" + sudungchobh.checked
             +"&iddvt="+ encodeURIComponent(iddvt.value)
             +"&LoaiThuocID="+ encodeURIComponent(LoaiThuocID.value)
             +"&idcachdung="+ encodeURIComponent(idcachdung.value)
             + "&TTHoatChat=" + encodeURIComponent(TTHoatChat.value) 
             +"&idnuocsx="+ encodeURIComponent(idnuocsx.value)
              + "&IsTGN=" + IsTGN.checked
              + "&IsTHTT=" + IsTHTT.checked
              + "&ISTPX=" +  ISTPX.checked
               + "&ISTKS=" +  ISTKS.checked
               + "&ISTDTL=" +  ISTDTL.checked
               + "&ISTcorticoid=" +  ISTcorticoid.checked
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
                    url:"../KeToan/ajax/thuoc_ajax1.aspx?do=ktrathuoc&idkhoachinh=" + idkhoachinh,
                    success:function (data) {
                        if(data != ""){
                            alert(data);
                        }
                        else{
                          Xoakhoachinh('','',"../KeToan/ajax/thuoc_ajax1.aspx?do=xoa&idkhoachinh=" + idkhoachinh,valueControlLuu);  
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
             document.getElementById("ctl00_body_HiddenField1").value = eval(functionlistcontroltimkiem)(control);
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
             laydanhsachTodroplist('-- Select one --','','',"../KeToan/ajax/thuoc_ajax1.aspx?do=DropDownList_idnhomthuoc&cateid="+values, "ctl00_body_idnhomthuoc_idnhomthuoc");
         }
          function loadDropDownListcategory(values)
         {
            if(values == 1){
                sttindm05.disabled = false;
                congthuc.disabled = false;
                TTHoatChat.disabled = false;
            }else{
                sttindm05.disabled = true;
                congthuc.disabled = true;
                TTHoatChat.disabled = true;

            }
            if(document.getElementById(tablegrid) != null)
                document.getElementById(tablegrid).rows[0].cells[3].innerText = LoaiThuocID.options[LoaiThuocID.selectedIndex].text;
             laydanhsachTodroplist('-- Select one --','','',"../KeToan/ajax/thuoc_ajax1.aspx?do=DropDownList_category&loai="+values, "ctl00_body_cateid_cateid");
             document.getElementById("ctl00_body_HiddenField4").value = "";
            document.getElementById("ctl00_body_HiddenField3").value = "";
         }
         function xoaontable(idkhoachinh,control){
             if(idkhoachinh.length > 0){
             var hoi = confirm("Xác nhận !");
             if(hoi){
                $.ajax({
                    type:"GET",
                    cache:false,
                    url:"../KeToan/ajax/thuoc_ajax1.aspx?do=ktrathuoc&idkhoachinh=" + idkhoachinh,
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
                         xmlHttp.open("GET", "../KeToan/ajax/thuoc_ajax1.aspx?do=xoa&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
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
            getcontrol();
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
             var tkkho = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("input")[0].value;             
             var tkdoanhthu = document.getElementById(tablegrid).rows[i].cells[5].getElementsByTagName("input")[0].value;             
             var tkgiavon = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("input")[0].value;
             var IdCachDung = document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("select")[0].value;
             var iddvt = document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("select")[0].value;             
             var idhangsanxuat = document.getElementById(tablegrid).rows[i].cells[9].getElementsByTagName("select")[0].value;
             var idnuocsanxuat = document.getElementById(tablegrid).rows[i].cells[10].getElementsByTagName("select")[0].value;
             var sudungchobh = document.getElementById(tablegrid).rows[i].cells[11].getElementsByTagName("input")[0].checked;
             return "../KeToan/ajax/thuoc_ajax1.aspx?do=luuTable&tkkho=" + encodeURIComponent(tkkho) 
             + "&tenthuoc=" + encodeURIComponent(tenthuoc) 
             + "&tkgiavon=" + encodeURIComponent(tkgiavon) 
             + "&IdCachDung=" + encodeURIComponent(IdCachDung) 
             + "&idhangsanxuat=" + encodeURIComponent(idhangsanxuat)
             + "&idnuocsanxuat=" + encodeURIComponent(idnuocsanxuat) 
             + "&sudungchobh=" + encodeURIComponent(sudungchobh)
              + "&iddvt=" + encodeURIComponent(iddvt) 
              + "&LoaiThuocID=" + encodeURIComponent(LoaiThuocID.value) 
              + "&idnhomthuoc=" + encodeURIComponent(idnhomthuoc.value) 
              + "&tkdoanhthu=" + encodeURIComponent(tkdoanhthu)
              + "&cateid=" + encodeURIComponent(cateid.value)
              + "&IsTGN=" + encodeURIComponent(IsTGN.checked)
              + "&IsTHTT=" + encodeURIComponent(IsTHTT.checked)
              + "&ISTPX=" +  ISTPX.checked
               + "&ISTKS=" +  ISTKS.checked
               + "&ISTDTL=" +  ISTDTL.checked
               + "&ISTcorticoid=" +  ISTcorticoid.checked
              ;
         }
         function ExtendtionLuu(flag) {
    
        tenthuoc.disabled = flag;
        idnhomthuoc.disabled = flag;
        sudungchobh.disabled  = flag;
        iddvt.disabled = flag;
        LoaiThuocID.disabled = flag;
        cateid.disabled = flag;
        IsTGN.disabled = flag;
        IsTHTT.disabled = flag;
        
         ISTPX.disabled = flag;
        ISTKS.disabled = flag;
         ISTDTL.disabled = flag;
        ISTcorticoid.disabled = flag;
}
function Moi(valueControlLuu) {
getcontrol();
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
        idnhomthuoc.selectedIndex = 0;
        iddvt.value = "";
        LoaiThuocID.selectedIndex = 0;
        cateid.selectedIndex = "";
        IsTGN.checked  = false;
        IsTHTT.checked  = false;
        
        ISTPX.checked  = false;
        ISTKS.checked  = false;
        ISTDTL.checked  = false;
        ISTcorticoid.checked  = false;
    
    ExtendtionLuu(false);
}
function ShowTaiKhoanKho(obj)
{
    $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            document.getElementById(tablegrid).rows[$(obj).parent().parent().index()].cells[4].getElementsByTagName("input")[0].value = data[2];
                        }
                        );           
}
function ShowTaiKhoanDoanhThu(obj)
{
    $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            //alert($(obj).parent().parent().index());
                            document.getElementById(tablegrid).rows[$(obj).parent().parent().index()].cells[5].getElementsByTagName("input")[0].value = data[2];
                        }
                        );           
}
function ShowTaiKhoanGiaVon(obj)
{
    $(obj).unautocomplete().autocomplete("ajax/phieuxuatkho_ajax3.aspx?do=DanhSachTaiKhoan_Jquery&Key="+obj.value+"&obj="+obj.id,
                                                        {width:350,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                        function(event,data)
                        {
                            //alert($(obj).parent().parent().index());
                            document.getElementById(tablegrid).rows[$(obj).parent().parent().index()].cells[6].getElementsByTagName("input")[0].value = data[2];
                            //return;
                            //alert($(obj).parent().parent().index());
                        }
                        );           
}
function setChonTaiKhoan(MaTaiKhoan,obj)
{
   var txtTaiKhoan=document.getElementById(obj);
   txtTaiKhoan.value=MaTaiKhoan;
 
}         

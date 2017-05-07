var currentRow = 0,tablenamefind = "",tablegrid = "",flagtemp=true,khoachinhcapnhatdulieu = "idkhoachinh",row1=1,row2 = "";
var controlXoa = 'xoa',controlSua = 'sua',controlLuu = 'luu',controlMoi = 'moi';
window.onload=function(){
            var w = screen.availWidth;
    var h = screen.availHeight;
    window.moveTo(0,0);
    window.resizeTo(w,h);
}
function idkhoachinhSua(idkhoachinh) {
    if (location.hash.match(khoachinhcapnhatdulieu))
        location.hash = location.hash.replace(queryString(khoachinhcapnhatdulieu), idkhoachinh);
    else{
            if(location.hash.indexOf("#") != -1){
            if(location.hash.split("#")[1].length > 0)
            {
                location.hash = location.hash +"&"+ khoachinhcapnhatdulieu + "=" + idkhoachinh;
            }
            else{
                location.hash = location.hash + khoachinhcapnhatdulieu + "=" + idkhoachinh;
            }
            }
            else{
                location.hash = location.hash + khoachinhcapnhatdulieu + "=" + idkhoachinh;
            }
        }
}
function GetMSXmlHttp() {
    var xmlHttp2 = null;
    if (!window.XMLHttpRequest) {
        var s = "";
        var clsids = ["Msxml2.XMLHTTP.6.0", "Msxml2.XMLHTTP.5.0",
						        "Msxml2.XMLHTTP.4.0", "Msxml2.XMLHTTP.3.0",
						        "Msxml2.XMLHTTP.2.6", "Microsoft.XMLHTTP.1.0",
						        "Microsoft.XMLHTTP.1", "Microsoft.XMLHTTP"];
        for (var i = 0; i < clsids.length && xmlHttp2 == null; i++) {
            xmlHttp2 = new ActiveXObject(clsid);
        }
    }
    else {
        xmlHttp2 = new XMLHttpRequest();
    }
    return xmlHttp2;
}
function CreateXmlHttp(clsid) {
    var xmlHttp1 = null;
    try {
        xmlHttp1 = new ActiveXObject(clsid);
        return xmlHttp1;
    }
    catch (e) { }
}
function Them(functionScriptBefore,functionScriptAfter,ajaxThem, ajaxSua, control, valueControl) {
    if(functionScriptBefore != "")
        var before = eval(functionScriptBefore)();
        if(before != false){
    control.disabled = true;
    if (location.hash.match(khoachinhcapnhatdulieu)) {
        var ajaxUpdate = eval(ajaxSua)();
        if (ajaxUpdate != false) {
            var xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function() {
            if (xmlHttp.readyState == 1) {
                $("#loadingAjax").html('<p style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');                                      
            }
            else if (xmlHttp.readyState == 4) {
                    if (xmlHttp.responseText.length > 0) {
                        myalert('Cập nhật thành công !',2000);
                        idkhoachinhSua(xmlHttp.responseText);
                        control.id = controlSua;
                        control.value = valueControl;
                        document.getElementById(controlXoa).style.display = "";
                        ExtendtionLuu(true);
                        try{setTimeout("document.getElementById(\""+controlMoi+"\").focus()",100);}
                        catch(ex){}
                        finally{setTimeout("document.getElementById(\""+controlMoi+"\").focus()",100);}
                    }
                    else {
                        $("#loadingAjax").html("");
                        alert('Cập nhật không thành công !');
                        control.disabled = false;
                         for (var i = 0; i < document.forms[0].elements.length; i++) {
                            if (document.forms[0].elements[i].type == "text")
                            {
                                if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
                                   { setTimeout("document.forms[0].elements["+i+"].focus()",100);
                                    return false;}
                            }
                         }
                    }
                    $("#loadingAjax").html("");
                    if(functionScriptAfter != "")
                        var after = eval(functionScriptAfter)(xmlHttp.responseText);
                       control.disabled = false;
                }
            }
            xmlHttp.open("GET", ajaxUpdate + "&times=" + Math.random(), true);
            xmlHttp.send();
        }
    }
    else {
        var ajaxInsert = eval(ajaxThem)();
        if (ajaxInsert != false) {
            var xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function() {
            if (xmlHttp.readyState == 1) {
                $("#loadingAjax").html('<p style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');                                      
            }
             else if (xmlHttp.readyState == 4) {
                    if (xmlHttp.responseText.length > 0) {
                        myalert('Thêm mới thành công !',2000);
                        idkhoachinhSua(xmlHttp.responseText);
                        control.id = controlSua;
                        control.value = valueControl;
                        document.getElementById(controlXoa).style.display = "";
                        ExtendtionLuu(true);
                        try{setTimeout("document.getElementById(\""+controlMoi+"\").focus()",100);}
                        catch(ex){}
                        finally{setTimeout("document.getElementById(\""+controlMoi+"\").focus()",100);}
                    }
                    else {
                    $("#loadingAjax").html("");
                        alert('Thêm mới không thành công !');
                        control.disabled = false;
                         for (var i = 0; i < document.forms[0].elements.length; i++) {
                            if (document.forms[0].elements[i].type == "text")
                            {
                                if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
                                   { setTimeout("document.forms[0].elements["+i+"].focus()",100);
                                return false;}
                            }
                         }
                    }
                    $("#loadingAjax").html("");
                    if(functionScriptAfter != "")
                        var after = eval(functionScriptAfter)(xmlHttp.responseText);
                    control.disabled = false;
                }
            }
            xmlHttp.open("GET", ajaxInsert + "&times=" + Math.random(), true);
            xmlHttp.send(null);
        }

    }
    }
}


function CapNhat(control, valueControl) {
    control.id = controlLuu;
    control.value = valueControl;
    ExtendtionLuu(false);

}
function LoadTimKiem(functionScriptBefore,functionScriptAfter,control, functionlistcontroltimkiem, width, height, tenpopup) {
    if (event.keyCode === 113) {
        TimKiem(functionScriptBefore,functionScriptAfter,control, eval(functionlistcontroltimkiem)(control), width, height, tenpopup);
        return false;
    }
    if (control.type === "button") {
        TimKiem(functionScriptBefore,functionScriptAfter,control, eval(functionlistcontroltimkiem)(control), width, height, tenpopup);
        return false;
    }
    if(event.keyCode === 27)
    {
        if (document.getElementById("divTimKiem") != null) {
            dongtimkiem(control.id);
        }
        return false;
    }
    if(event.keyCode != 38){
        if(event.keyCode !=37){
            if(event.keyCode !=39){
                if(event.keyCode != 40){
                    if(document.getElementById("divTimKiem") != null){
                    if(document.getElementById("divTimKiem").style.display != "none")
                    {TimKiem(functionScriptBefore,functionScriptAfter,control, eval(functionlistcontroltimkiem)(control), width, height, tenpopup);}
                    }
                }
            }
        }
     }
}
function dongtimkiem(controlTimKiem) {
    document.getElementById(controlTimKiem).focus();
    document.getElementById("divParent").innerHTML = "";
    if(currentRow != null){currentRow=0}
}
function eventesc(control, controlTimKiem) {
    if (event.keyCode === 27) {
        document.getElementById("divParent").innerHTML  = "";
        document.getElementById(controlTimKiem).focus();
        
        if(currentRow != null){currentRow=0}
    }
}
function scrollyactive(control){
        document.getElementById(control).focus();
}
function TimKiem(functionScriptBefore,functionScriptAfter,control, listcontroltimkiem, widthdiv, heightdiv, tendiv) {
    if(functionScriptBefore != "")
        var before = eval(functionScriptBefore)();
    if(currentRow != null){currentRow=0}
    if (document.getElementById("divTimKiem") == null) {
        document.getElementById("divParent").innerHTML = "<div onmove=\"scrollyactive('"+control.id+"')\" onkeyup=\"eventesc(this,'" + control.id + "');\" id=\"divTimKiem\" style=\"cursor:move;background-color:#0066ff;width:" + widthdiv + "px;max-height:" + heightdiv + "px;min-height:200px;margin:auto;display:none;position:fixed;top:20%;left:15%;background:url('../images/header.gif') repeat-x;\"><p style=\"color:white;padding-left:20px;float:left;margin-Top:0px\">" + tendiv + "</p><p style=\"color:white;float:right;cursor:pointer;margin-Top:3px;margin-Right:3px\" onclick=\"dongtimkiem('" + control.id + "');\"><img src=\"../images/close.gif\" /></p><div onscroll =\"scrollyactive('"+control.id+"')\" id=\"divSetTimKiem\" style=\"background-color:white;width:" + widthdiv + "px;max-height:" + (eval(heightdiv) - 30) + "px;min-height:200px;overflow:scroll;position:absolute;top:25px;left:0;text-align:center;border:1px solid #2b7af7;\">Đang tìm dữ liệu ...</div></div>";
    }
    document.getElementById("divTimKiem").style.display = "block";
    document.getElementById("divSetTimKiem").innerHTML = "Đang tìm dữ liệu ...";
    $("#divTimKiem").draggable();
    var xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function() {
        if (xmlHttp.readyState == 4) {
            if (xmlHttp.responseText.length > 0) {
                document.getElementById("divSetTimKiem").innerHTML = xmlHttp.responseText;
                if(document.getElementById(tablenamefind) != null)
                {
                    if(document.getElementById(tablenamefind).rows.length < 3)
                    {
                        document.getElementById(tablenamefind).rows[1].click();
                    }
                }
            }
            else {
             document.getElementById("divTimKiem").style.display ="none";
             myalert("Không tìm thấy dữ liệu !",2000);
            }
            if(functionScriptAfter != "")
                        var after = eval(functionScriptAfter)(xmlHttp.responseText);
        }
    }
    xmlHttp.open("GET", listcontroltimkiem + "&times=" + Math.random(), true);
    xmlHttp.send(null);
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
    var sel = document.getElementsByTagName("select");
    for (var i = 0; i < document.forms[0].elements.length; i++) {
        if (document.forms[0].elements[i].type == "text")
            document.forms[0].elements[i].value = "";
        if (document.forms[0].elements[i].type == "textarea")
            document.forms[0].elements[i].value = "";
        if (document.forms[0].elements[i].type == "checkbox")
            document.forms[0].elements[i].checked = false;
        if (sel[i] != null) {
            sel[i].selectedIndex = 0;
        }
    }
    
    ExtendtionLuu(false);
}
function queryString(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&#]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return results[1];
}
function Xoakhoachinh(functionScriptBefore,functionScriptAfter,ajax, valueControlLuu) {
    if(functionScriptBefore != "")
        var before = eval(functionScriptBefore)();
    document.getElementById(controlXoa).disabled = true;
    var xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function() {
    if (xmlHttp.readyState == 1) {
                $("#loadingAjax").html('<p style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>');                                      
            }
        else if (xmlHttp.readyState == 4) {
            if (xmlHttp.responseText.length > 0) {
                myalert('Xoá thành công !',2000);
                Moi(valueControlLuu);
            }
            else {
            $("#loadingAjax").html("");
                alert('Xoá không thành công !');
                document.getElementById(controlXoa).disabled = false;
                try{
                document.getElementById(controlXoa).focus();
                }
                catch(ex){}
                return false;
            }
            document.getElementById(controlXoa).disabled = false;
            $("#loadingAjax").html("");
            if(functionScriptAfter != "")
                        var after = eval(functionScriptAfter)(xmlHttp.responseText);
        }
    }
    xmlHttp.open("GET", ajax + "&times=" + Math.random(), true);
    xmlHttp.send(null);
}
        function setf(){
            try {
                document.getElementById(controlLuu).focus();
            }
            catch (ex)
            { document.getElementById(controlSua).focus();}
        }

function XoaControlAfterFind(idkhoachinhsua, valueControlSua) {
    idkhoachinhSua(idkhoachinhsua);
    if (document.getElementById(controlLuu) != null) {
        document.getElementById(controlLuu).id = controlSua;
        document.getElementById(controlSua).value = valueControlSua;
    }
    if (document.getElementById(controlSua) != null) {
        document.getElementById(controlSua).id = controlSua;
        document.getElementById(controlSua).value = valueControlSua;
    }
    try{
        document.getElementById(controlXoa).style.display = "";
        document.getElementById("divParent").innerHTML = "";
        if(currentRow != null){currentRow=0}
    }
    catch(ex){}
    ExtendtionLuu(true);

}
function Luu(finctionScriptBefore,functionScriptAfter,control, valueControlLuu, valueControlSua, ajaxThem, ajaxSua) {
    if (control.id == controlLuu) {
        if($("#aspnetForm").valid()){   
        Them(finctionScriptBefore,functionScriptAfter,ajaxThem,ajaxSua, control, valueControlSua);
        }
    }
    if (control.id == controlSua) {
        CapNhat(control,valueControlLuu);
    }
    
}
function ExtendtionLuu(flag) {
    if (flag == true) {
        var sel = document.getElementsByTagName("select");
        for (var i = 0; i < document.forms[0].elements.length; i++) {
            if (document.forms[0].elements[i].type == "text")
                document.forms[0].elements[i].disabled = true;
            if (document.forms[0].elements[i].type == "hidden")
                document.forms[0].elements[i].disabled = true;
            if (document.forms[0].elements[i].type == "textarea")
                document.forms[0].elements[i].disabled = true;
            if (document.forms[0].elements[i].type == "checkbox")
                document.forms[0].elements[i].disabled = true;
            if (document.forms[0].elements[i].type == "radio")
                document.forms[0].elements[i].disabled = true;
            if (sel[i] != null) {
                sel[i].disabled = true;
            }
        }
    }
    else {
        var sel = document.getElementsByTagName("select");
        for (var i = 0; i < document.forms[0].elements.length; i++) {
            if (document.forms[0].elements[i].type == "text")
                document.forms[0].elements[i].disabled = false;
            if (document.forms[0].elements[i].type == "hidden")
                document.forms[0].elements[i].disabled = false;
            if (document.forms[0].elements[i].type == "textarea")
                document.forms[0].elements[i].disabled = false;
            if (document.forms[0].elements[i].type == "checkbox")
                document.forms[0].elements[i].disabled = false;
            if (document.forms[0].elements[i].type == "radio")
                document.forms[0].elements[i].disabled = false;
            if (sel[i] != null) {
                sel[i].disabled = false;
            }
        }
        for (var i = 0; i < document.forms[0].elements.length; i++) {
        if (document.forms[0].elements[i].type == "text")
        {
            if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
               { setTimeout("document.forms[0].elements["+i+"].focus()",100);
            return false;}
        }
     }
    }
}
function laydanhsachTodroplist(defaultvalue,functionScriptBefore,functionScriptAfter,ajax, iddroplist) {
    if(functionScriptBefore != "")
        var before = eval(functionScriptBefore)();
        
    var droplist = document.getElementById(iddroplist);        
    droplist.options[droplist.options.length] = new Option("loading...","");
    var xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function() {
        if (xmlHttp.readyState == 4) {
                if (document.getElementById(iddroplist) != null) {
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
    xmlHttp.open("GET", ajax + "&times=" + Math.random(), true);
    xmlHttp.send(null);
}
function chuyenphim(control) {
    if (event.keyCode === 13) {
        for (var i = 0; i < document.forms[0].elements.length; i++) {

            if (document.forms[0].elements[i] == control) {
                try {
                    document.forms[0].elements[i + 1].focus();
                }
                catch (ex) { }
            }
        }
    }
	if($.trim(control.value).length < 1)
    {
        control.name = "";
    }
}
function moveUpandDown(idtable){
    tablenamefind = idtable;
    var offset = 0;
 $(document).keydown(function() {
    if(document.getElementById(idtable) != null){
     var tr = document.getElementById(idtable).rows;
    if (currentRow != 0) {
        tr[currentRow].style.backgroundColor = "";
        tr[currentRow].style.color = "gray";
    }
    else {
        tr[currentRow].style.backgroundColor = "#0066ff";
        tr[currentRow].style.color = "white";
        offset = 0;
    }
    if (event.keyCode == 38) {
        currentRow = currentRow - 1;
        try{tr[currentRow].style.backgroundColor = "#f6ebcd";tr[currentRow].style.color = "green";
        offset -= tr[currentRow].clientHeight;
        if(offset <= eval(document.getElementById("divSetTimKiem").clientHeight - eval(tr[currentRow].clientHeight)*2.5 ))
        {
            $("#divSetTimKiem").scrollTop($("#divSetTimKiem").scrollTop() - tr[currentRow].clientHeight);;
            offset += tr[currentRow].clientHeight;
        }
        }
        catch(ex){offset = 0;$("#divSetTimKiem").scrollTop(0);currentRow = currentRow + 1;tr[currentRow].style.backgroundColor = "#f6ebcd";tr[currentRow].style.color = "green";}
        
    }
    if (event.keyCode == 40) {
        currentRow = currentRow + 1;
        try{tr[currentRow].style.backgroundColor = "#f6ebcd";tr[currentRow].style.color = "green";
        offset += tr[currentRow].clientHeight;
        if(offset >= eval(document.getElementById("divSetTimKiem").clientHeight - eval(tr[currentRow].clientHeight)*2.5))
        {
            $("#divSetTimKiem").scrollTop($("#divSetTimKiem").scrollTop() + tr[currentRow].clientHeight);
            offset -= tr[currentRow].clientHeight;
        }
        }
        catch(ex){
        offset=eval(document.getElementById("divSetTimKiem").clientHeight);
        $("#divSetTimKiem").scrollTop(document.getElementById(idtable).clientHeight);
        currentRow = currentRow - 1;tr[currentRow].style.backgroundColor = "#f6ebcd";tr[currentRow].style.color = "green";}
    }
    if(event.keyCode == 13)
    {
        tr[currentRow].click();
    }}
});
}

function myalert(message,time){
      if (document.getElementById("divalert") == null) {
      document.getElementById("divParent").innerHTML ="<div id=\"divalert\" style=\"z-index:10000;background-color:white;position:fixed;top:40%;left:40%;display:table;padding:20px 50px 20px 50px;border:5px solid #0066ff;text-align:center\">"+message+"</div>";
      }
      else{
          document.getElementById("divalert").innerHTML += "<div>"+message+"</div>";
      }
      if(document.getElementById("divParent").innerHTML != ''){
      setTimeout("document.getElementById(\"divParent\").innerHTML='';",time);
      }
}
 var tempWidth; 
 var checkchuyenphim = true;
function chuyendong(control) {
    if(checkchuyenphim){
    try {
        if (event.keyCode == 40) {
            if (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[1].getElementsByTagName("a")[0] == null && document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("select")[0] == null) {
                themDongTable(tablegrid);
            }
            if (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null) document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
            if (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null) document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex + 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();
        }
        if (event.keyCode == 38) {
            if (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0] != null) document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].focus();
            if (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0] != null) document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex - 1].cells[control.parentNode.cellIndex].getElementsByTagName("a")[0].focus();
 
            var flagrow = false;
            for (var i = 0; i < document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells.length; i++) {
                if (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0] != null) {
                    if (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].type == "text") {
                        if (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].value.length > 0 && document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[i].getElementsByTagName('input')[0].value != '0') {
                            flagrow = true;
                            return;
                        }
                    }
                }
            }
            if (flagrow == false && control.parentNode.parentNode.rowIndex > 1 && (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells.length - 1].getElementsByTagName('input')[0].value.length < 1)) document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);
        }
        if (event.keyCode == 27) {
            if (control.type == 'text') chuyenformout(control);
        }
        if (event.keyCode == 13) {
            if (control.type == 'text') {
                if (control.style.position == '') {
                 tempWidth= control.style.width;                                            
                    $(control).css({
                        'position':'absolute',
                        'margin-top':'-10px',
                        'margin-left':'-20px',
                        'width':'100%'
                    });
                    chuyenform(control);
                }
                else{
                    chuyenformout(control);
                }
            }
        }
    } catch (ex) {}
    }
}
function themDongTable(TableName){
var TableNames = document.getElementById(TableName).rows.length;  

var money =   $("#"+TableName+" tr:eq(1)").clone().find('input,select,a').each(function() {
    $(this).attr({
      'id': function(_,id) { var ids;try{ids=id.split('_')[0]+"_"+(eval($("#"+TableName +" tr:eq("+(TableNames - 2)+") td:eq(0)").html())+1)}catch(ex){}finally{if(ids=="_NaN"){ids=""};return ids} },
      'name': function(_,name) { return ''},
      'value': function(_,value) { if(value == 0) {return value}else{return ''}  },
      'checked':function(_,check) { return false }           
    });
  }).end();
if($.trim(document.getElementById(TableName).rows[TableNames - 1].cells[0].innerText).length < 1){
      $("#"+TableName +" tr:eq("+(TableNames - 2)+")").after(money);
      TableNames = document.getElementById(TableName).rows.length;
      $("#"+TableName +" tr:eq("+(TableNames - 2)+") td:eq(0)").html(eval($("#"+TableName +" tr:eq("+(TableNames - 3)+") td:eq(0)").html())+1);
      if($("#"+TableName +" tr:eq("+(TableNames - 2)+") td:eq(0)").html() == "NaN")
      {
          $("#"+TableName +" tr:eq("+(TableNames - 3)+") td:eq(0)").html(1);
          $("#"+TableName +" tr:eq("+(TableNames - 2)+") td:eq(0)").html(2);
      }
  }else{
      $("#"+TableName +" tr:eq("+(TableNames - 3)+")").after(money);
      TableNames = document.getElementById(TableName).rows.length;
      $("#"+TableName +" tr:eq("+(TableNames - 3)+") td:eq(0)").html(eval($("#"+TableName +" tr:eq("+(TableNames - 4)+") td:eq(0)").html())+1);
  }
}
function chuyenform(control){
try{
    document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[control.parentNode.cellIndex].getElementsByTagName("input")[0].select();
    }catch(ex){}
    $(control).css({'backgroundColor':'#ffff99'});
}
function chuyenformout(control) {
    $(control).css({
        'position':'',
        'margin-top':'0',
        'margin-left':'0',
        'width':tempWidth,
        'backgroundColor': ''
    });
}
function LuuTable(functionScriptBefore,functionScriptAfter,i,control,functionlistcontroluutable){
if(functionScriptBefore != "")
        var before = eval(functionScriptBefore)();
try{
var idkhoachinh = document.getElementById(tablegrid).rows[i].cells[document.getElementById(tablegrid).rows[i].cells.length - 1].getElementsByTagName("input")[0].value; 
var xmlHttp = GetMSXmlHttp();
    xmlHttp.onreadystatechange = function() {
        if (xmlHttp.readyState == 4) {
             if(xmlHttp.responseText.length > 0){
             document.getElementById(tablegrid).rows[i].style.backgroundColor = '';
             document.getElementById(tablegrid).rows[i].cells[document.getElementById(tablegrid).rows[i].cells.length - 1].getElementsByTagName('input')[0].value = xmlHttp.responseText;
             if(document.getElementById(tablegrid).rows[i].cells[1].getElementsByTagName('a')[0] != null){
                document.getElementById(tablegrid).rows[i].cells[1].getElementsByTagName('a')[0].name = xmlHttp.responseText;
             }
             try{ 
             document.getElementById(tablegrid).rows[i+1].style.backgroundColor = '#0066ff';
             document.getElementById(tablegrid).rows[i].style.backgroundColor = '';
             }catch(ex){}
             }else{document.getElementById(tablegrid).rows[i].style.backgroundColor = 'yellow';} //da tung la red
             if(row2 != "")
             {
                if(i<row2 && flagtemp == true){
                LuuTable(functionScriptBefore,functionScriptAfter,(eval(i)+1),control,functionlistcontroluutable);
                }
                else{
                if(control != "" && control.id.indexOf("huyTable") != -1 ){
                    for(var ii=1;ii<3;ii++){
                    document.getElementById("huyTable_"+ii).value = 'Lưu';
                    document.getElementById("huyTable_"+ii).id = "luuTable_"+ii;
                    }}
                    myalert('Đã Hoàn thành !',2000);
                    if(functionScriptAfter != "")
                             setTimeout('eval('+functionScriptAfter+')()',0);
                    try{
                    document.getElementById(tablegrid).rows[i+1].style.backgroundColor = '';
                    }catch(ex){}
                }
             }else{
             if(i<document.getElementById(tablegrid).rows.length && flagtemp == true){
                LuuTable(functionScriptBefore,functionScriptAfter,(eval(i)+1),control,functionlistcontroluutable);
                }
                else{
                if(control.id.indexOf("huyTable") != -1){
                    for(var ii=1;ii<3;ii++){
                    document.getElementById("huyTable_"+ii).value = 'Lưu';
                    document.getElementById("huyTable_"+ii).id = "luuTable_"+ii;
                    }}
                    myalert('Đã Hoàn thành !',2000);
                    if(functionScriptAfter != "")
                                    setTimeout('eval('+functionScriptAfter+')()',0);
                    try{
                    document.getElementById(tablegrid).rows[i+1].style.backgroundColor = '';
                    }catch(ex){}
                }
             }
        }
    }
    
    xmlHttp.open("GET", eval(functionlistcontroluutable)(i)+"&idkhoachinh=" + idkhoachinh +"&times=" + Math.random(), true);
    xmlHttp.send(null);
  }catch(ex){
  if(control != "" && control.id.indexOf("huyTable") != -1){
    for(var ii=1;ii<3;ii++){
                    document.getElementById("huyTable_"+ii).value = 'Lưu';
                    document.getElementById("huyTable_"+ii).id = "luuTable_"+ii;
                    }}
    myalert('Đã Hoàn thành !',2000);
    if(functionScriptAfter != "")
            setTimeout('eval('+functionScriptAfter+')()',0);
    document.getElementById(tablegrid).rows[i].style.backgroundColor = '';
  }
}

function checkluu(control){
if(control.checked == true){
    if(row1 == 1)
        row1 = control.parentNode.parentNode.rowIndex;
    else
    {
        if(row2 == document.getElementById(tablegrid).rows.length || row2 == ""){
            row2 = control.parentNode.parentNode.rowIndex;
        }
        else{
            control.checked = false;
            alert("Bạn đã chọn từ dòng "+row1+" --> "+row2+" !");
        }
    }
}
else{
    if(row1 == control.parentNode.parentNode.rowIndex)
    {
        row1 = 1;
    }
    else{
        row2 = document.getElementById(tablegrid).rows.length;
    }
}
if(row1 > row2 && row2 != "")
{
    var tam1 = row2;
    row2 = row1;
    row1 = tam1;
}
}

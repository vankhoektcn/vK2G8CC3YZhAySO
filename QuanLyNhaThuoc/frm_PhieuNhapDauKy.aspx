 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_PhieuNhapDauKy.aspx.cs" Inherits="nvk_PhieuNhapDauKy" Title="KHAI BÁO SỐ DƯ ĐẦU KỲ" %>

<%@ Register Src="../usercontrols/div.ascx" TagName="div" TagPrefix="uc2" %>
 <%@ Register Src="~/usercontrols/droplist.ascx" TagName="droplist" TagPrefix="uc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="header" Runat="Server">
 <style type="text/css">
         tr#background:hover
         {
             background-color: #f6ebcd;
             z-index: 1000;
             color: green;
         }
     </style>
     <script type="text/javascript">
              var idphieunhap,maphieunhap,idloaithuoc,tenthuoc,ngaythang,idkho,nhacungcapid,tennguoigiao,kyhieuhoadon,sohoadon,ngayhoadon,tkno,tkco,tkvat,nhapcho,ghichu,vat,thanhtien,idkhachhang,idnguoinhap,idloainhap,IsBHYT,tienhang,tienvat,tongtien,ptn,TrangThai;
         $(document).ready(function() {
         controlSua = 'luu';
             ngaythang = document.getElementById("<%=ngaythang.ClientID%>");
             idkho = document.getElementById(("ctl00_body_droplistidkho_idkho"));
             idloaithuoc = document.getElementById(("ctl00_body_droplistloaithuoc_loaithuoc"));    
             tenthuoc =  document.getElementById("txttenthuoc"); 
            moveUpandDown("tablefind");
               khoachinhcapnhatdulieu = "idkhoachinh";
               loadTableAjaxchitietphieunhapkho('','');
               tablegrid="gridTables";
 for (var i = 0; i < document.forms[0].elements.length; i++) {
         if (document.forms[0].elements[i].type == "text")
         {
             if(document.forms[0].elements[i].visible == true || document.forms[0].elements[i].disabled == false)
                { setTimeout("document.forms[0].elements["+i+"].focus()",100);
             return false;}
         }
      }
         });
         // ham set du lieu cho cac control khi lua chon du lieu tim kiem
         function setControlFind(control,functiontimkiem) {
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                 if (xmlHttp.responseText.length > 0) {
                     var value = xmlHttp.responseText.split("@");
         ngaythang.value = value[1];
  idkho.value = value[2];
                    setTimeout("setf()",100);
                    
              loadTableAjaxchitietphieunhapkho("",value[0]);
                     //set khoa chinh len querystring va hien nut xoa,sua
                     XoaControlAfterFind(value[0],"<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>");
                     if(currentRow != null){currentRow=0}
                     }
                     else {
                     loadTableAjaxchitietphieunhapkho("","");
                     if (location.hash.match(khoachinhcapnhatdulieu)) {
        location.hash = location.hash.replace(khoachinhcapnhatdulieu + "=" + queryString(khoachinhcapnhatdulieu), "");
    }
             myalert("Không tìm thấy dữ liệu !",2000);
            }
                 }
             }
             xmlHttp.open("GET",  eval(functiontimkiem)(control) + "&times=" + Math.random(), true);
             xmlHttp.send(null);
         }
         //ham tim kiem du lieu theo danh sach ham functionlistcontroltimkiem
         function Find(control, functionlistcontroltimkiem) {
             LoadTimKiem('','',control, functionlistcontroltimkiem, 700, 400, "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("namelabelfind") %> !");
         }
         //tim kiem du lieu voi phim F2,Enter cua cac control
         //ham lay control de insert du lieu
         function ListControlThem() {
             if (document.getElementById("ctl00_body_droplistidkho_idkho").selectedIndex == 0) {
                 alert("Danh mục tên chưa chọn !");
                 return false;
             }
             return "../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=Them&ngaythang="+ encodeURIComponent(ngaythang.value)+"&idkho="+ encodeURIComponent(idkho.value);
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             if (document.getElementById("ctl00_body_droplistidkho_idkho").selectedIndex == 0) {
                 alert("Danh mục tên chưa chọn !");
                 return false;
             }
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=Sua&ngaythang=" + encodeURIComponent(ngaythang.value) + "&idkho=" + encodeURIComponent(idkho.value) +"&idkhoachinh=" + idkhoachinh;
         }
         function FunctionLuu(control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua)
         {
            Luu('','luugridtable',control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua);
            control.disabled = false;
         }
 function luugridtable()
         {
            LuuTable("","",row1,"",'ListControlLuuTablechitietphieunhapkho');
         }
         // ham xoa du lieu voi querystring khoa chinh
         function Xoa(control,valueControlLuu) {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             //xoa du lieu voi idkhoachinh va hien nut luu,an nut xoa,sua
              var hoi = confirm("Xác nhận !");                  if(hoi){             Xoakhoachinh('','loadTableAjaxchitietphieunhapkho',"../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=xoa&idkhoachinh=" + idkhoachinh,valueControlLuu);
         }}
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
                 xmlHttp.open("GET", "../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=xoachitietphieunhapkho&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);}
              
         }
         function LamMoi(valueControlLuu) {
             // an nut sua,xoa,hien nut luu
             loadTableAjaxchitietphieunhapkho('','');
             Moi(valueControlLuu);
          loaddroplist3();
          loaddroplist4();
         }
 function loadTableAjaxchitietphieunhapkho(response,idkhoa)
         {
            document.getElementById("tableAjax_chitietphieunhapkho").innerHTML="<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang chạy xin chờ .....<img id='imgLoading' src='../images/processing.gif' /></span>";         
             if(idkhoa == null)
                 idkhoa = "";
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         document.getElementById("tableAjax_chitietphieunhapkho").innerHTML=xmlHttp.responseText;
                    }
             }
             xmlHttp.open("GET", "../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=loadTablechitietphieunhapkho&idkhoachinh="+idkhoa+"&idloaithuoc="+encodeURIComponent(idloaithuoc.value)+"&tenthuoc="+encodeURIComponent(tenthuoc.value)+"&random=" + Math.random(), true);
             xmlHttp.send(null);
         }
         function laybaocao()
         {
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         window.open(xmlHttp.responseText,"_blank");
                    }
             }
             xmlHttp.open("GET", "../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=laybaocao&idkho="+idkho.value+"&idloaithuoc="+encodeURIComponent(idloaithuoc.value)+"&ngaythang="+ngaythang.value+"&random=" + Math.random(), true);
             xmlHttp.send(null);
         }
         function loaddroplist3()
         {
             laydanhsachTodroplist('-- Select one --','','chonduynhat',"../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=droplist_idkho&idkhoa="+queryString('idkhoa')+"", 'ctl00_body_droplistidkho_idkho');
         }
         function chonduynhat(response)
         {
            //idkho.disabled = true;
            idkho.value = "4";
         }
         function loaddroplist4()
         {
             laydanhsachTodroplist('-- Select one --','','',"../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=droplist_idloaithuoc", 'ctl00_body_droplistloaithuoc_loaithuoc');
         }
         function ListControlLuuTablechitietphieunhapkho(i)
         {
             var idthuoc = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value;
             var soluong = document.getElementById(tablegrid).rows[i].cells[7].getElementsByTagName("input")[0].value;
             var ngayhethan = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("input")[0].value;
             var losanxuat = document.getElementById(tablegrid).rows[i].cells[5].getElementsByTagName("input")[0].value;
             var dvt = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("select")[0].value;
             var dongia = document.getElementById(tablegrid).rows[i].cells[8].getElementsByTagName("input")[0].value;
             var thanhtien = document.getElementById(tablegrid).rows[i].cells[9].getElementsByTagName("input")[0].value;
             return "../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=luuTablechitietphieunhapkho&idthuoc=" + encodeURIComponent(idthuoc) + "&soluong=" + encodeURIComponent(soluong) + "&ngayhethan=" + encodeURIComponent(ngayhethan) + "&losanxuat=" + encodeURIComponent(losanxuat) + "&thanhtien=" + encodeURIComponent(thanhtien) + "&dvt=" + dvt + "&dongia=" + dongia + "&idphieunhap=" + queryString("idkhoachinh") + "";
         }
          function ListControlTimKiemEnter(control) {
            //alert(idloaithuoc.value);
            //document.getElementById("tableAjax_chitietphieunhapkho").innerHTML="<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang load .....<img id='imgLoading' src='../images/processing.gif' /></span>";
             return "../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=setTimKiem&idkho="+ encodeURIComponent(idkho.value)+"&idloaithuoc="+idloaithuoc.value+"";
         }
         function tinhthanhtien(obj) {
            var sl = document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[7].getElementsByTagName("input")[0].value;
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[9].getElementsByTagName("input")[0].value = eval(eval(sl.replace(/\$|\,/g,''))*eval(obj.value.replace(/\$|\,/g,'')));
         }
          function tinhdongia(obj) {
            var sl = document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[7].getElementsByTagName("input")[0].value;
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[8].getElementsByTagName("input")[0].value = eval(eval(obj.value.replace(/\$|\,/g,''))/eval(sl.replace(/\$|\,/g,'')));
         }
         function ExtendtionLuu(flag) {
       
}
var checkchuyenphim = true;
function setf(){
}
function timkiemthuoc(obj){ 
 $(obj).unautocomplete().autocomplete("../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=getthuoc&idkho="+idkho.value+"&idloaithuoc="+idloaithuoc.value,
        {formatItem: function(data) {
               checkchuyenphim = false; return data[0];
            },width:900,scroll:true}
        )
        
        .result(function(event, data){
               document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[0].value = data[1];
               document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[4].getElementsByTagName("select")[0].value = data[2];
               document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[8].getElementsByTagName("input")[0].value = data[3];
	           checkchuyenphim = false; 
	           obj.blur();
	           obj.focus(); 
        });
        }
        function phantrang(i,idkhoa)
        {
            if(idkhoa == null)
                 idkhoa = "";
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         document.getElementById("tableAjax_chitietphieunhapkho").innerHTML=xmlHttp.responseText;
                    }
             }
             xmlHttp.open("GET", "../ajax/nvk_PhieuNhapDauKy_ajax.aspx?do=loadTablechitietphieunhapkho&idkhoachinh="+idkhoa+"&idloaithuoc="+encodeURIComponent(idloaithuoc.value)+"&sotrang="+i+"&random=" + Math.random(), true);
             xmlHttp.send(null);
        }
        function chuyendong(control){
        if(checkchuyenphim == true){
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
}
function loadchitietphieunhap_new(control){
    if(queryString("idkhoachinh") != "")
        loadTableAjaxchitietphieunhapkho("",queryString("idkhoachinh"));
        
            if(control.value != "")
        document.getElementById(tablegrid).rows[0].cells[3].innerText = control.options[control.selectedIndex].text;
}

     </script>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <div style="margin-top: 10px; padding: 5px 5px 5px 5px;background: #e9e9e9">
             <div style="padding: 2px 0px 2px 0px; background-color: #4D67A2; border: 1px solid #cfcfcf;
                 text-align: center; color: White; font-size: 20px">
                 KHAI BÁO SỐ DƯ ĐẦU KỲ</div>
             <div style="display: table-row; padding-bottom: 50px">
                 
                 <div style="float: left;;height:40px; padding: 0px 20px 0px 20px; width: 443px;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                     <div style="float: left; padding: 10px 0px 10px 0px">
                         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ngaythang") %>  :</div>
                     <div style="width: 70% ;float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                         <input id="ngaythang" type="text" runat="server" onblur="TestDate(this)" onkeyup="chuyenphim(this)" />dd/MM/yyyy</div>
                 </div>
 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px;;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                 <uc1:droplist id="droplistidkho" runat="server" id_="idkho"  FindFunction="" onload="loaddroplist3()" title="idkho" disabled="false" >
                 </uc1:droplist>
                 </div>
                 <div style="float: left; padding: 0px 20px 0px 20px;;height:40px; width: 443px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                 <uc1:droplist id="droplistloaithuoc" runat="server" id_="loaithuoc" onchange="loadchitietphieunhap_new(this);" FindFunction="" onload="loaddroplist4()" title="loaithuoc">
                 </uc1:droplist>
                 </div>
                 <div style="float: left;;height:40px; padding: 0px 20px 0px 20px; width: 443px;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                     <div style="float: left; padding: 10px 0px 10px 0px">
                         <%=hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc") %>  :</div>
                     <div style="width: 70% ;float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                         <input id="txttenthuoc" type="text" onkeyup="chuyenphim(this)" style="width:250px" /></div>
                 </div>
                 <div style="float: left; padding: 0px 20px 0px 20px; width: 443px;height:40px; border-right: 1px solid #cfcfcf;
                     border-bottom: 1px solid #cfcfcf;">
                     
                     <div style="width: 70%; float: right; padding: 10px 0px 10px 20px">
                        <input style="border:1px solid;width:200px" id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("laysoduthang0") %>" onclick="setControlFind(this,'ListControlTimKiemEnter');"
                      />&nbsp;
                      
                 </div>
                 </div>
         </div>
 <div id="tableAjax_chitietphieunhapkho">
             
         </div>
         </div><div style=" background: #e9e9e9; text-align: center;
             padding: 5px 5px 5px 5px;border-Top:none;">
             <!-- voi cac 'xoa','luu','sua' khi onclick la id cua control -->
             <!-- voi cac ListControlThem,ListControlSua,ListControlTimKiemEnter la cac function -->
             <div style=" padding: 10px 0 10px 0;background-color:#cfcfcf;border:1px solid #cfcfcf;">
                 <input style="border:1px solid " id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> " onclick="FunctionLuu(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ','<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>','ListControlThem','ListControlSua');"
                      />
                 <input style="border:1px solid " id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>" onclick="LamMoi('<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 <input style="border:1px solid;display: none " id="xoa" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>" onclick="Xoa(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');"
                      />
                 
                 
             </div>
         </div>
 </asp:Content>

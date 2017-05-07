<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CaPhauThuat3.aspx.cs" Inherits="CaPhauThuat" Title="CaPhauThuat" %>

<%@ Register Src="~/usercontrols/DropDownList.ascx" TagName="DropDownList" TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/TextBox.ascx" TagName="TextBox" TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/CheckBox.ascx" TagName="CheckBox" TagPrefix="uc3" %>
<%@ Register Src="~/usercontrols/DateTime.ascx" TagName="DateTime" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="Server">
    <style type="text/css">
         tr#background:hover
         {
             background-color: #f6ebcd;
             z-index: 1000;
             color: green;
         }
     </style>

    <script type="text/javascript">
              var idCaPhauThuat,idBenhNhan,idPhongPhauThuat,NgayPhauThuat,sovaovien,idGoiPhauThuat,trongoi,BinhThuong,ChiChu,tenBenhNhan;
            var flagtable = true;                           
         $(document).ready(function() {
             idBenhNhan = document.getElementById("ctl00_body_idBenhNhan_idBenhNhan");
             tenBenhNhan = document.getElementById("ctl00_body_tenBenhNhan_tenBenhNhan");             
             idGoiPhauThuat = document.getElementById("ctl00_body_idgoiphauthuat_idgoiphauthuat");             
             idPhongPhauThuat = document.getElementById("ctl00_body_idPhongPhauThuat_idPhongPhauThuat");
             NgayPhauThuat = document.getElementById("ctl00_body_NgayPhauThuat_NgayPhauThuat");
             trongoi = document.getElementById("ctl00_body_trongoi_trongoi");
             BinhThuong = document.getElementById("ctl00_body_BinhThuong_BinhThuong");
             ChiChu = document.getElementById("ctl00_body_ChiChu_ChiChu");
             sovaovien = document.getElementById("ctl00_body_sovaovien_sovaovien");
            moveUpandDown("tablefind");
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
         
         // Thêm dòng table      
         
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
              if(TableName == "gridBSPhauthuat")
              {
                var chonlua=document.getElementById(TableName).rows[TableNames-2].cells[4].getElementsByTagName("select")[0];
                if(chonlua.options.length-1 == document.getElementById(TableName).rows[TableNames-3].cells[4].getElementsByTagName("select")[0].selectedIndex)
                {
                    chonlua.selectedIndex = 0;
                  }else{
                  chonlua.selectedIndex = eval(document.getElementById(TableName).rows[TableNames-3].cells[4].getElementsByTagName("select")[0].selectedIndex) + 1;                   
                  }
              }
            }
         
         
         // ham set du lieu cho cac control khi lua chon du lieu tim kiem
         function setControlFind(idkhoatimkiem,valueControlSua) {
         if(idkhoatimkiem != ""){
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                     var value = xmlHttp.responseText.split("@");
             idBenhNhan.value = value[1];
             tenBenhNhan.value = value[2];
             idGoiPhauThuat.value = value[3];
              idPhongPhauThuat.value = value[4];
              NgayPhauThuat.value = value[5];
             if(value[6] == 'True')
                     trongoi.checked = true;
                 else
                     trongoi.checked = false;
             if(value[7] == 'True')
                         BinhThuong.checked = true;
                     else
                         BinhThuong.checked = false;
            ChiChu.value = value[8];
            sovaovien.value = value[9];
                    setTimeout("setf()",100);
              loadTableAjaxBSPhauThuat("",value[0]);
              loadTableAjaxThuoc("",value[0]);
              loadTableAjaxCLS("",value[0]);
              loadTableAjaxThuocKho2("",value[0]);
                     //set khoa chinh len querystring va hien nut xoa,sua
                     XoaControlAfterFind(value[0],valueControlSua);
                     if(currentRow != null){currentRow=0}
                 }
             }
             xmlHttp.open("GET", "../ajax/CaPhauThuat_ajax3.aspx?do=setTimKiem&idkhoachinh=" + idkhoatimkiem + "&times=" + Math.random(), true);
             xmlHttp.send(null);
             }
             else{
              loadTableAjaxBSPhauThuat("","");
              loadTableAjaxThuoc("","");  
              loadTableAjaxCLS("","");    
              loadTableAjaxThuocKho2("","");
                                   
             }
         }
         //ham tim kiem du lieu theo danh sach ham functionlistcontroltimkiem
         function Find(control, functionlistcontroltimkiem) {
             LoadTimKiem('','',control, functionlistcontroltimkiem, 830, 400, "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("namelabelfind") %> !");
         }
         //tim kiem du lieu voi phim F2,Enter cua cac control
         function ListControlTimKiemidBenhNhan(control) {
             return "../ajax/CaPhauThuat_ajax3.aspx?do=TimKiem&idBenhNhan=" + encodeURIComponent(control.value) + "";
         }
         function ListControlTimKiemidPhongPhauThuat(control) {
             return "../ajax/CaPhauThuat_ajax3.aspx?do=TimKiem&idPhongPhauThuat=" + encodeURIComponent(control.value) + "";
         }
         function ListControlTimKiemNgayPhauThuat(control) {
             return "../ajax/CaPhauThuat_ajax3.aspx?do=TimKiem&NgayPhauThuat=" + encodeURIComponent(control.value) + "";
         }
         function ListControlTimKiemtrongoi(control) {
             return "../ajax/CaPhauThuat_ajax3.aspx?do=TimKiem&trongoi=" + control.checked + "";
         }
         function ListControlTimKiemBinhThuong(control) {
             return "../ajax/CaPhauThuat_ajax3.aspx?do=TimKiem&BinhThuong=" + control.checked + "";
         }
         function ListControlTimKiemsovaovien(control) {
             return "../ajax/CaPhauThuat_ajax3.aspx?do=TimKiem&sovaovien=" + control.value + "";
         }
         function ListControlTimKiemChiChu(control) {
             return "../ajax/CaPhauThuat_ajax3.aspx?do=TimKiem&ChiChu=" + encodeURIComponent(control.value) + "";
         }
         //tim kiem du lieu cac control khi onclick hoac enter button
         function ListControlTimKiemEnter(control) {
             return "../ajax/CaPhauThuat_ajax3.aspx?do=TimKiem&idBenhNhan="+ encodeURIComponent(idBenhNhan.value)+"&NgayPhauThuat="+ encodeURIComponent(NgayPhauThuat.value)+"&trongoi="+trongoi.checked+"&BinhThuong="+BinhThuong.checked
             +"&ChiChu="+ encodeURIComponent(ChiChu.value)
             +"&sovaovien="+ encodeURIComponent(sovaovien.value) ;
         }
         //ham lay control de insert du lieu
         function ListControlThem() {
             return "../ajax/CaPhauThuat_ajax3.aspx?do=Them&idBenhNhan="+ encodeURIComponent(idBenhNhan.value)
             +"&idPhongPhauThuat="+ encodeURIComponent(idPhongPhauThuat.value)
             +"&NgayPhauThuat="+ encodeURIComponent(NgayPhauThuat.value)
             +"&trongoi=" + trongoi.checked
             +"&BinhThuong=" + BinhThuong.checked
             +"&ChiChu="+ encodeURIComponent(ChiChu.value)
             +"&sovaovien="+ encodeURIComponent(sovaovien.value)
             +"&idgoiphauthuat="+ encodeURIComponent(idGoiPhauThuat.value)+""   ;
         }
         //ham lay control de update du lieu
         function ListControlSua() {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             return "../ajax/CaPhauThuat_ajax3.aspx?do=Sua&idBenhNhan=" + encodeURIComponent(idBenhNhan.value) 
             + "&idPhongPhauThuat=" + encodeURIComponent(idPhongPhauThuat.value) 
             + "&NgayPhauThuat=" + encodeURIComponent(NgayPhauThuat.value) 
             + "&trongoi=" + trongoi.checked
             +"&BinhThuong=" + BinhThuong.checked
             +"&ChiChu=" + encodeURIComponent(ChiChu.value)
             +"&idgoiphauthuat="+ encodeURIComponent(idGoiPhauThuat.value) 
             +"&sovaovien="+ encodeURIComponent(sovaovien.value)             
             + "&idkhoachinh=" + idkhoachinh;
         }
          var controlluuphieunhap = "";
         function FunctionLuu(control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua)
         {    
                 controlluuphieunhap = control;
                Luu('','luugridtable',control,valueControlLuu, valueControlSua, ajaxThem, ajaxSua);
         }
        function luugridtable()
         {
            flagtable = false;         
            tablegrid="gridBSPhauthuat";
            LuuTable("","luuTableThuoc",row1,"",'ListControlLuuTableBSPhauThuat');
         }
         function luuTableThuoc()
         {
            tablegrid="gridLoaithuoc";
            LuuTable("","luuTableThuocKho2",row1,"",'ListControlLuuTableLoaiThuoc');
         }
         
         function luuTableThuocKho2()
         {
            tablegrid="gridLoaithuocKho2";
            LuuTable("","luuTableCLS",row1,"",'ListControlLuuTableLoaiThuocKho2');
         }

         
         function luuTableCLS()
         {
            tablegrid="gridCLS";
            LuuTable("","settablegrid",row1,"",'ListControlLuuTableCLS');
         }
         function settablegrid() {
            flagtable = true;
         }
         // ham xoa du lieu voi querystring khoa chinh
         function Xoa(control,valueControlLuu) {
             var idkhoachinh = queryString(khoachinhcapnhatdulieu);
             //xoa du lieu voi idkhoachinh va hien nut luu,an nut xoa,sua
              var hoi = confirm("Xác nhận !");                  if(hoi){             Xoakhoachinh('','loadTableAjaxBSPhauThuat',"../ajax/CaPhauThuat_ajax3.aspx?do=xoa&idkhoachinh=" + idkhoachinh,valueControlLuu);
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
                 xmlHttp.open("GET", "../ajax/CaPhauThuat_ajax3.aspx?do=xoaBSPhauThuat&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);}
              
         }
         function xoaontableThuoc(idkhoachinh,control){
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
                 xmlHttp.open("GET", "../ajax/CaPhauThuat_ajax3.aspx?do=xoaThuoc&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);}
              
         }
         
         function xoaontableCLS(idkhoachinh,control){
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
                 xmlHttp.open("GET", "../ajax/CaPhauThuat_ajax3.aspx?do=xoaCLS&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{document.getElementById(tablegrid).deleteRow(control.parentNode.parentNode.rowIndex);}
              
         }
         function LamMoi(valueControlLuu) {
             // an nut sua,xoa,hien nut luu
             loadTableAjaxBSPhauThuat('','');
             Moi(valueControlLuu);
             trongoi.checked = true;
          loadDropDownListidPhongPhauThuat();
          var NgayHienTai= document.getElementById(('<%=NgayHienTai.ClientID %>')).value;
          NgayPhauThuat.value=NgayHienTai;
          
         }
        function loadTableAjaxBSPhauThuat(response,idkhoa)
         {
             if(idkhoa == null)
                 idkhoa = "";
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         document.getElementById("tableAjax_BSPhauThuat").innerHTML=xmlHttp.responseText;
                    }
             }
             xmlHttp.open("GET", "../ajax/CaPhauThuat_ajax3.aspx?do=loadTableBSPhauThuat&idkhoachinh="+idkhoa+"&random=" + Math.random(), true);
             xmlHttp.send(null);
         }
         function loadTableAjaxThuoc(response,idkhoa)
         {
             if(idkhoa == null)
                 idkhoa = "";
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         document.getElementById("tableAjax_Thuoc").innerHTML=xmlHttp.responseText;
                    }
             }
             xmlHttp.open("GET", "../ajax/CaPhauThuat_ajax3.aspx?do=loadTableThuoc&idkhoachinh="+idkhoa+"&random=" + Math.random(), true);
             xmlHttp.send(null);
         }
         function loadTableAjaxThuocKho2(response,idkhoa)
         {
             if(idkhoa == null)
                 idkhoa = "";
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         document.getElementById("tableAjax_ThuocKho2").innerHTML=xmlHttp.responseText;
                    }
             }
             xmlHttp.open("GET", "../ajax/CaPhauThuat_ajax3.aspx?do=loadTableThuocKho2&idkhoachinh="+idkhoa+"&random=" + Math.random(), true);
             xmlHttp.send(null);
         }
         function loadTableAjaxCLS(response,idkhoa)
         {
                
             if(idkhoa == null)
                 idkhoa = "";
             var xmlHttp = GetMSXmlHttp();
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                         document.getElementById("tableAjax_CLS").innerHTML=xmlHttp.responseText;
                    }
             }
             xmlHttp.open("GET", "../ajax/CaPhauThuat_ajax3.aspx?do=loadTableCLS&idkhoachinh="+idkhoa+"&random=" + Math.random(), true);
             xmlHttp.send(null);
         }
         function loadDropDownListidPhongPhauThuat()
         {
             laydanhsachTodroplist('-- Select one --','','chaysauphauthuat',"../ajax/CaPhauThuat_ajax3.aspx?do=DropDownList_idPhongPhauThuat", 'ctl00_body_idPhongPhauThuat_idPhongPhauThuat');
         }
         
         function chaysauphauthuat(response){
            setControlFind(queryString("idkhoachinh"),"<%=hsLibrary.clDictionaryDB.sGetValueLanguage("update") %>");
         }
         function ListControlLuuTableBSPhauThuat(i)
         {
             var idNhanVien = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[0].value;         
             var idVaiTroBSPThuat = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("select")[0].value;
             var idLoaiPhauThuat= document.getElementById("gridCLS").rows[1].cells[4].getElementsByTagName("select")[0].value;
             //alert("idLoaiPhauThuat="+idLoaiPhauThuat);//alert khoe
             return "../ajax/CaPhauThuat_ajax3.aspx?do=luuTableBSPhauThuat&idLoaiPhauThuat="+idLoaiPhauThuat+"&idNhanVien=" + encodeURIComponent(idNhanVien) + "&idCaPhauThuat=" + queryString("idkhoachinh") + "&idVaiTroBSPThuat=" + idVaiTroBSPThuat + "";
         }
         
         function ListControlLuuTableLoaiThuoc(i)
         {
             var tenthuoc = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].value;         
             var soluong = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("input")[0].value;         
             var cachdung = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("input")[0].value;
             return "../ajax/CaPhauThuat_ajax3.aspx?do=luuTableLoaithuoc&tenthuoc=" + encodeURIComponent(tenthuoc) + "&idCaPhauThuat=" + queryString("idkhoachinh") + "&soluong=" + soluong + "&cachdung="+encodeURIComponent(cachdung);
         }
         
         function ListControlLuuTableLoaiThuocKho2(i)
         {
             var tenthuoc = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].value;         
             var soluong = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("input")[0].value;         
             var cachdung = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("input")[0].value;
             return "../ajax/CaPhauThuat_ajax3.aspx?do=luuTableLoaithuocKho2&tenthuoc=" + encodeURIComponent(tenthuoc) + "&idCaPhauThuat=" + queryString("idkhoachinh") + "&soluong=" + soluong + "&cachdung="+encodeURIComponent(cachdung);
         }
         
          function ListControlLuuTableCLS(i)
         {
             var tencls = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].value;         
             var idLoaiPhauThuat= document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("select")[0].value;
             return "../ajax/CaPhauThuat_ajax3.aspx?do=luuTableCLS&idLoaiPhauThuat="+idLoaiPhauThuat+"&tencls=" + encodeURIComponent(tencls) + "&idCaPhauThuat=" + queryString("idkhoachinh") ;
         }
         
         function timkiembn(control){
            var loaitimkiem = "";
            if(control.id == idBenhNhan.id){
                loaitimkiem = "mabenhnhan";
            }
            else{
                loaitimkiem = "tenbenhnhan";            
            }
            $(control).unautocomplete().autocomplete("../ajax/CaPhauThuat_ajax3.aspx?do=timkiemBN&loai="+loaitimkiem,{
	            scroll: true,width:690
	            	}).result(function(event, data){
	                document.getElementById("ctl00_body_tenBenhNhan_tenBenhNhan").value = data[2];
	                idBenhNhan.value = data[1];
	            });
            
	    }
	    function timkiemgoiphauthuat(control){
	        $(control).unautocomplete().autocomplete("../ajax/CaPhauThuat_ajax3.aspx?do=timkiemgoiphauthuat",{
	            scroll: true,width:600
	            	});
	    }
	    function timkiemNV(control,kieutiemkiem){
//	    var idLoaiPhauThuat= document.getElementById("gridCLS").rows[1].cells[4].getElementsByTagName("select")[0].value;
//             alert("idLoaiPhauThuat="+idLoaiPhauThuat);//alert khoe
            $(control).unautocomplete().autocomplete("../ajax/CaPhauThuat_ajax3.aspx?do=timkiemNV&loai="+kieutiemkiem,{
	            scroll: true,width:600,formatItem: function(data) {
                flagchuyendong = true;return data[0];
            }
	            }).result(function(event, data){
	                document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[0].value = data[1];
	                document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[3].getElementsByTagName("input")[0].value = data[2];
	                flagchuyendong = false;
	                themDongTable(tablegrid);
	            });
         }
         function timkiemThuoc(control) {
            var loaithuoc = document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("select")[0].value;
            $(control).unautocomplete().autocomplete("../ajax/CaPhauThuat_ajax3.aspx?do=timkiemThuoc&loaithuoc="+loaithuoc,{
	            scroll: true,width:600,formatItem: function(data) {
                flagchuyendong = true;return data[0];
            }
	            }).result(function(event, data){
	                document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[4].getElementsByTagName("input")[0].value = 1;
	                document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[5].getElementsByTagName("select")[0].value = data[1];
	                document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[6].getElementsByTagName("input")[0].value = data[2];
	                
	                flagchuyendong = false;
	                themDongTable(tablegrid);
	            });
         }
         function timkiemCLS(control) {
            var idgoipt = idGoiPhauThuat.value;
            if($.trim(idgoipt).length > 0 )
            {
            $(control).unautocomplete().autocomplete("../ajax/CaPhauThuat_ajax3.aspx?do=timkiemCLS&idgoiphauthuat="+encodeURIComponent(idgoipt),{
	            scroll: true,width:600,formatItem: function(data) {
                flagchuyendong = true;return data[0];
            }
	            }).result(function(event, data){
	                document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[0].value = data[1];
	                document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[3].getElementsByTagName("input")[0].value = data[0];
	                document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[4].getElementsByTagName("select")[0].value = data[2];
	                
	                
	                flagchuyendong = false;
	                themDongTable(tablegrid);
	            });
	        }
         }
          function timkiemPhuongPhapVoCam(control){
	        $(control).unautocomplete().autocomplete("../ajax/CaPhauThuat_ajax3.aspx?do=timkiemPhuongPhapVoCam",{
	            scroll: true,width:600
	            	});
	    }
	    
         var flagchuyendong = false;
         function chuyendong(control){
         if(!flagchuyendong){
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
                if(flagrow == false && control.parentNode.parentNode.rowIndex > 1 && (document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells[document.getElementById(tablegrid).rows[control.parentNode.parentNode.rowIndex].cells.length - 1].getElementsByTagName('input')[0].value.length < 1 ))
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
function checkchon(control) {
    if(!control.checked){
        control.checked = true;
    }
   if(control.id == trongoi.id && trongoi.checked){
            BinhThuong.checked = false;
   }
   if(control.id == BinhThuong.id && BinhThuong.checked){
            trongoi.checked = false;
   }

}
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
 <div class="shadow" style="padding: 15px 0px 10px 0px; background-color: #4473ca; border: 2px solid #5a7f97;
            text-align: center; color: White; font-size: 25px; font-weight: bold;position:absolute;width:100%;left:0;right:0">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CaPhauThuat")%>
        </div>
    <div style="margin-top: 65px; padding: 5px 5px 5px 9px; border: 1px solid #cfcfcf;
        background-color:white;">
       
        <div style="display: table-row; padding-bottom: 30px;">
            <uc2:TextBox ID="idBenhNhan" runat="server" IDTextBox="idBenhNhan" onkeyup="Find(this,'ListControlTimKiemidBenhNhan');"
                styleTextBox="width:90%" Title="maBenhNhan" onfocus="timkiembn(this);" requiredField="true" >
            </uc2:TextBox>
            <uc2:TextBox ID="tenBenhNhan" runat="server" IDTextBox="tenBenhNhan" onkeyup="Find(this,'ListControlTimKiemtenBenhNhan');"
                styleTextBox="width:90%" Title="tenBenhNhan" onfocus="timkiembn(this);"></uc2:TextBox>
                 <uc2:TextBox ID="idgoiphauthuat" runat="server" IDTextBox="idgoiphauthuat"
                styleTextBox="width:90%" Title="goiphauthuat" onfocus="timkiemgoiphauthuat(this);" requiredField="true"></uc2:TextBox>
            <uc1:DropDownList ID="idPhongPhauThuat" runat="server" ID_DropDownList="idPhongPhauThuat"
                onload="loadDropDownListidPhongPhauThuat()" FindFunction="Find(this,'ListControlTimKiemidPhongPhauThuat')"
                Title="idPhongPhauThuat" requiredField="true" styleTextBox="width:90%"></uc1:DropDownList>
            <uc2:TextBox ID="ChiChu" runat="server" IDTextBox="ChiChu" onkeyup="Find(this,'ListControlTimKiemChiChu');" TextMode="SingleLine"
                styleTextBox="width:90%" onfocus="timkiemPhuongPhapVoCam(this);" Title="ppvc" ></uc2:TextBox>
            <uc4:DateTime ID="NgayPhauThuat" runat="server" IDTextBox="NgayPhauThuat" onkeyup="Find(this,'ListControlTimKiemNgayPhauThuat');"
                Title="NgayPhauThuat" Text_AfterTextBox="(dd/MM/yyyy)" requiredField="true"></uc4:DateTime>
            
            <uc3:CheckBox ID="trongoi" runat="server" Checked="true" IDCheckBox="trongoi" Title="trongoi" styleDivOut="width:200px"
                styleDivInRight="width:31%" onclick="checkchon(this)"></uc3:CheckBox>
            <uc3:CheckBox ID="BinhThuong" runat="server" IDCheckBox="BinhThuong" Title="BinhThuong"
                styleDivOut="width:240px" styleDivInRight="width:40%" onclick="checkchon(this)">
            </uc3:CheckBox>
            <uc2:TextBox ID="sovaovien" runat="server" onkeyup="Find(this,'ListControlTimKiemsovaovien');" IDTextBox="sovaovien"
                styleTextBox="width:130px" Title="sovaovien" ></uc2:TextBox>
                
            <fieldset style="padding:10px 0px 10px 0">
                <legend>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("CLS")%>
                </legend>
                <div id="tableAjax_CLS" style="overflow: auto;">
                </div>
            </fieldset>
            <fieldset style="padding:10px 0px 10px 0;clear:both">
                <legend>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("ekip")%>
                </legend>
                <div id="tableAjax_BSPhauThuat" style="overflow: auto;" >
                </div>
            </fieldset>
            <fieldset style="padding:10px 0px 10px 0">
                <legend>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("thuoc/vtyt(kho1)")%>
                </legend>
                <div id="tableAjax_Thuoc" style="overflow: auto;">
                </div>
            </fieldset>
            <fieldset style="padding:10px 0px 10px 0">
                <legend>
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("dungcu(kho2)")%>
                </legend>
                <div id="tableAjax_ThuocKho2" style="overflow: auto;">
                </div>
            </fieldset>
            
        </div>
        
    </div>
    <div style="border: 1px solid #cfcfcf; background: white; text-align: center; padding: 5px 5px 5px 5px;
        border-top: none;">
        <!-- voi cac 'xoa','luu','sua' khi onclick la id cua control -->
        <!-- voi cac ListControlThem,ListControlSua,ListControlTimKiemEnter la cac function -->
        <div style="padding: 10px 0 10px 0; background-color: #fafafa; border-top: 1px solid #cfcfcf;">
            <input id="luu" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> "
                onclick="FunctionLuu(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %> ','<%=hsLibrary.clDictionaryDB.sGetValueLanguage("update") %>','ListControlThem','ListControlSua');" />
            <input style="border: 1px solid" id="moi" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>"
                onclick="LamMoi('<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');" />
            <input style="border: 1px solid; display: none" id="xoa" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
                onclick="Xoa(this,'<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>');" />
            <input style="border: 1px solid" id="timKiem" type="button" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("find") %>"
                onclick="Find(this,'ListControlTimKiemEnter');" />
            <input id="NgayHienTai" type="hidden" runat="server" />
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="nvk_KhamThuongQuyDienBien.aspx.cs" Inherits="nvk_KhamThuongQuyDienBien"
    Title="Khai báo khám bệnh" %>

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
              var flagtemp;
               var dp_cal1;       
	    window.onload = function () 
	    {	       
	        dp_cal1 = new Epoch('epoch_popup','popup',document.getElementById("<%=NgayCong.ClientID %>")); 
	    };   
         $(document).ready(function() {
       khoachinhcapnhatdulieu = "idkhoachinh";
         });
         function functionSelected(idkhoachinh)
         {
 
         }
// xóa công khám
         function xoaontabletableBacSiKhamBenh(idkhoachinh,control){
             if(idkhoachinh.length > 0){
             var hoi = confirm("Xác nhận !");
             if(hoi){
                 var xmlHttp = GetMSXmlHttp();
                 xmlHttp.onreadystatechange = function() {
                     if (xmlHttp.readyState == 4) {
                         if (xmlHttp.responseText.length > 0) {
                             myalert('Xoá thành công !',2000);
                             if(document.getElementById("tableBacSiKhamBenh").rows.length > 1)
                             {
                                document.getElementById("tableBacSiKhamBenh").deleteRow(control.parentNode.parentNode.rowIndex);
                             }
                             else{
                                  for(var i=0;i<document.getElementById("tableBacSiKhamBenh").rows[0].cells.length;i++)
                                  {
                                  try{
                                      if(document.getElementById("tableBacSiKhamBenh").rows[0].cells[i].getElementsByTagName("input")[0] != null)
                                      {
                                            document.getElementById("tableBacSiKhamBenh").rows[0].cells[i].getElementsByTagName("input")[0].value = "";
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
                 xmlHttp.open("GET", "../ajax/nvk_KhamThuongQuyDienBien_ajax.aspx?do=xoaCongKhamBacSi&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
                 xmlHttp.send(null);
             }
             }
             else{
             if(document.getElementById("tableBacSiKhamBenh").rows.length > 1){
             document.getElementById("tableBacSiKhamBenh").deleteRow(control.parentNode.parentNode.rowIndex);
             }
             else{
                                  for(var i=0;i<document.getElementById("tableBacSiKhamBenh").rows[0].cells.length;i++)
                                  {
                                  try{
                                      if(document.getElementById("tableBacSiKhamBenh").rows[0].cells[i].getElementsByTagName("input")[0] != null)
                                      {
                                            document.getElementById("tableBacSiKhamBenh").rows[0].cells[i].getElementsByTagName("input")[0].value = "";
                                      }
                                      }catch(ex){}
                                  }                                              
                             }
             }
              
         }
// Xóa Diễn biến
         function xoaontableDienBien(idkhoachinh,control){
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
                 xmlHttp.open("GET", "../ajax/nvk_KhamThuongQuyDienBien_ajax.aspx?do=xoaKhamDienBien&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
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
//end Xóa Diễn biến
         function xoaontableDichVuKhac(idkhoachinh,control){
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
                 xmlHttp.open("GET", "../ajax/nvk_KhamThuongQuyDienBien_ajax.aspx?do=xoaKhamDichVuKhac&idkhoachinh=" + idkhoachinh + "&times=" + Math.random(), false);
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
         //End xóa dịch vụ
        var controlTableLuuKhac ;
//nvk function
function nvk_TimKiemBacSiKhamBenh()
{
    var NgayCong = document.getElementById("<%=NgayCong.ClientID %>").value;
    var phongBan = document.getElementById("<%=ddlPhongBan.ClientID %>").value;
    var LoaiBacSi = document.getElementById("<%=ddlLoaiNhanVien.ClientID %>").value;
    var TenBacSi = document.getElementById("<%=idNguoiDung.ClientID %>").value;
    var QueRy="&NgayCong="+NgayCong+"&phongBan="+phongBan+"&LoaiBacSi="+LoaiBacSi+"&TenBacSi="+encodeURIComponent(TenBacSi)+"&IdKhoa="+queryString("IdKhoa")+"";
    
    $("#divNoiDung").html("<span style='height: auto; width: 100%;text-align:center; color: Blue; font-weight: bold;font-style:italic' class='Tieude'> Đang tìm kiếm công khám.....<img id='imgLoading' src='../images/processing.gif' /></span>");
        var PathUrl="../ajax/nvk_KhamThuongQuyDienBien_ajax.aspx?do=TimKiemBacSiKhamBenh"+QueRy+"";	            
	        $.ajax
	            ({
                     type:"GET",
                     cache:false,
                     url:PathUrl,
                      success: function (value)
                        {
                            document.getElementById('divNoiDung').innerHTML=value;
                        }
                });
}
function nvk_laylaichuyendong(obj)
    {
        tablegrid = "tableBacSiKhamBenh";
        $(obj).unautocomplete().autocomplete("../ajax/nvk_KhamThuongQuyDienBien_ajax.aspx?do=getBacSiKhamBenh&IdKhoa="+queryString("IdKhoa")+"&ngaythang="+document.getElementById("<%=NgayCong.ClientID %>").value+"&sodong="+obj.parentNode.parentNode.rowIndex,
        {formatItem: function(data) {
                 return data[1];
            },width:900,scroll:true}
        )
        
        .result(function(event, data){
            nvk_themdongtable2(obj);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[0].value = data[1];//idbacsi
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[1].value = data[0];//Tên  bác sĩ
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[3].getElementsByTagName("input")[0].checked = kieuso(data[2]);//thường quy
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[4].innerHTML = data[3];//Diễn biến
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[5].innerHTML = data[4];// các dịch vụ khác
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[1].getElementsByTagName("a")[0].name = data[5];//id dòng
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[6].getElementsByTagName("input")[0].value = data[5];//id dòng
               obj.blur();
	           obj.focus(); 
        });
    }
function nvk_searchBNDB(obj)
    {
        $(obj).unautocomplete().autocomplete("../ajax/nvk_KhamThuongQuyDienBien_ajax.aspx?do=getBenhNhanDienBien&ngaythang="+document.getElementById("<%=NgayCong.ClientID %>").value+"&sodong="+obj.parentNode.parentNode.rowIndex,
        {formatItem: function(data) {
                 return data[0];
            },width:900,scroll:true}
        )
        
        .result(function(event, data){
            chuyendong2(obj,true);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[1].value = data[1];//idBenhNhan
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[0].value = data[2];//Tên  Bệnh Nhân
            //obj.value=data[2];
            //alert(document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[1].value);
               obj.blur();
	           obj.focus(); 
        });
    }
function nvk_searchDichVuKhac(obj)
    {
        $(obj).unautocomplete().autocomplete("../ajax/nvk_KhamThuongQuyDienBien_ajax.aspx?do=getDichVuKhac&ngaythang="+document.getElementById("<%=NgayCong.ClientID %>").value+"&sodong="+obj.parentNode.parentNode.rowIndex,
        {formatItem: function(data) {
                 return data[1];
            },width:900,scroll:true}
        )
        
        .result(function(event, data){
            chuyendong2(obj,true);
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[0].value = data[1];//idBenhNhan
            document.getElementById(tablegrid).rows[obj.parentNode.parentNode.rowIndex].cells[2].getElementsByTagName("input")[1].value = data[0];//Tên  Bệnh Nhân
               obj.blur();
	           obj.focus(); 
        });
    }
function nvk_themdongtable2(obj)
    {
        if(document.getElementById("tableBacSiKhamBenh").rows[obj.parentNode.parentNode.rowIndex + 1] == null){
        $("#tableBacSiKhamBenh").append("<tr onmouseover=\"if(this.style.backgroundColor != 'red'){this.style.backgroundColor='#F6EBCD',this.style.cursor = 'pointer'}\" onmouseout=\"if(this.style.backgroundColor != 'red'){this.style.backgroundColor='White'}\" style=\"color:#003399;background-color:White;\">"
            +"<td >"+(obj.parentNode.parentNode.rowIndex + 1)
            +"</td><td >"
            +"<a onkeydown=\"chuyendong(this);\" style='text-decoration: none; cursor: pointer;"
            +"margin-right: 10px; color: green;' onclick=\"xoaontabletableBacSiKhamBenh(this.name,this);\" name=\"\">"
            +"<%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>"
            +"</a>"
            +"</td><td >"
            +"<input name=\"ctl00$body$gridTable$ctl08$Text1\" type=\"text\" id=\"ctl00_body_gridTable_ctl08_Text1\" style=\"width:202px\" onfocus=\"nvk_laylaichuyendong(this);\" value=\"\" />"
            +"<input type=\"hidden\" name=\"ctl00$body$gridTable$ctl08$idnv\" id=\"ctl00_body_gridTable_ctl08_idnv\" value=\"108\" />"
            +"</td><td >"
            +"<input name=\"ctl00$body$gridTable$ctl08$ctl00\" type=\"checkbox\" onkeydown=\"chuyendong(this);\" style=\"width: 15px; border: none\" />"
            +"</td><td >"
            
            +"</td><td >"
            
            +"</td><td >"
            +"<input type=\"hidden\" value='' />"
            +"</td>"
            +"</tr>");
            }
    }
function nvk_displayBNDienBien(control)
{
    if(flagthemgio2)
    {
        tablegrid = document.getElementById("tableBacSiKhamBenh").rows[control.parentNode.parentNode.rowIndex].cells[4].getElementsByTagName("table")[0].id;
        //alert(tablegrid);
        var divs = document.getElementById("tableBacSiKhamBenh").rows[control.parentNode.parentNode.rowIndex].cells[4].getElementsByTagName("div")[0];
      
            $(divs).slideToggle("slow");        
        if(tiente2 == false)
        {
           document.getElementById("tableBacSiKhamBenh").rows[control.parentNode.parentNode.rowIndex].cells[4].style.backgroundColor= 'yellow'; 
           tiente2 = true;
        }
        else{
            document.getElementById("tableBacSiKhamBenh").rows[control.parentNode.parentNode.rowIndex].cells[4].style.backgroundColor= 'white'; 
            tiente2 = false;
        }
        if(document.getElementById(tablegrid).rows[1].cells[2].getElementsByTagName("input")[0].value.length > 0 || document.getElementById(tablegrid).rows[1].cells[2].getElementsByTagName("input")[1].value.length > 0)
        {
            control.style.backgroundColor= "blue";
        }
    }
}
function nvk_displayKhamDichVuKhac(control)
{
    if(flagthemgio2)
    {
        tablegrid = document.getElementById("tableBacSiKhamBenh").rows[control.parentNode.parentNode.rowIndex].cells[5].getElementsByTagName("table")[0].id;
        //alert(tablegrid);
        var divs = document.getElementById("tableBacSiKhamBenh").rows[control.parentNode.parentNode.rowIndex].cells[5].getElementsByTagName("div")[0];
      
            $(divs).slideToggle("slow");        
        if(tiente2 == false)
        {
           document.getElementById("tableBacSiKhamBenh").rows[control.parentNode.parentNode.rowIndex].cells[5].style.backgroundColor= 'yellow'; 
           tiente2 = true;
        }
        else{
            document.getElementById("tableBacSiKhamBenh").rows[control.parentNode.parentNode.rowIndex].cells[5].style.backgroundColor= 'white'; 
            tiente2 = false;
        }
        if(document.getElementById(tablegrid).rows[1].cells[2].getElementsByTagName("input")[0].value.length > 0 || document.getElementById(tablegrid).rows[1].cells[2].getElementsByTagName("input")[1].value.length > 0)
        {
            control.style.backgroundColor= "Green";
        }
    }
}
function nvk_ListControlLuuTable(i)
         {
            var NgayCong = document.getElementById("<%=NgayCong.ClientID %>").value;
             var idBacSi = document.getElementById(tablegrid).rows[i].cells[2].getElementsByTagName("input")[1].value;
             var ThuongQuy = document.getElementById(tablegrid).rows[i].cells[3].getElementsByTagName("input")[0].checked;
             var idtableDienBien = document.getElementById(tablegrid).rows[i].cells[4].getElementsByTagName("table")[0].id;
             var DienBien = "";
             for(var ii=1;ii<document.getElementById(idtableDienBien).rows.length - 1;ii++)
             {
                if(ii==document.getElementById(idtableDienBien).rows.length - 2)
                {
                    if(document.getElementById(idtableDienBien).rows[ii].cells[2].getElementsByTagName("input")[1].value=="")
                        break;
                }
                DienBien+= document.getElementById(idtableDienBien).rows[ii].cells[2].getElementsByTagName("input")[1].value + "|"+document.getElementById(idtableDienBien).rows[ii].cells[3].getElementsByTagName("input")[0].value+"|"+document.getElementById(idtableDienBien).rows[ii].cells[1].getElementsByTagName("a")[0].name+"@";
//                alert("dong"+ii+";benhnhan="+document.getElementById(idtableDienBien).rows[ii].cells[2].getElementsByTagName("input")[1].value);
//                alert("ghi chu="+document.getElementById(idtableDienBien).rows[ii].cells[3].getElementsByTagName("input")[0].value);
//                alert("id dong="+document.getElementById(idtableDienBien).rows[ii].cells[1].getElementsByTagName("a")[0].name);
//                alert("DienBien="+DienBien);
             }
             var idtableDichVuKhac = document.getElementById(tablegrid).rows[i].cells[5].getElementsByTagName("table")[0].id;
             var DichVuKhac = "";
             for(var ii=1;ii<document.getElementById(idtableDichVuKhac).rows.length - 1;ii++)
             {
                if(ii==document.getElementById(idtableDichVuKhac).rows.length - 2)
                {
                    if(document.getElementById(idtableDichVuKhac).rows[ii].cells[2].getElementsByTagName("input")[1].value=="")
                        break;
                }
                DichVuKhac+= document.getElementById(idtableDichVuKhac).rows[ii].cells[2].getElementsByTagName("input")[1].value + "|"+document.getElementById(idtableDichVuKhac).rows[ii].cells[3].getElementsByTagName("input")[0].value+"|"+document.getElementById(idtableDichVuKhac).rows[ii].cells[1].getElementsByTagName("a")[0].name+"@";
             }
             var idBacSiKhamBenh = document.getElementById(tablegrid).rows[i].cells[6].getElementsByTagName("input")[0].value;
             var idCuoi=document.getElementById(tablegrid).rows[i].cells[document.getElementById(tablegrid).rows[i].cells.length - 1].getElementsByTagName('input')[0].value;
             //alert("idBacSiKhamBenh="+idBacSiKhamBenh+";idCuoi="+idCuoi+"");
             var ListQueRy="&ngaykham=" + encodeURIComponent(NgayCong) + "&idbacsi="+idBacSi+"&KhamThuongQuy="+ThuongQuy+"&DienBien="+encodeURIComponent(DienBien)+"&DichVuKhac="+encodeURIComponent(DichVuKhac)+"";
             ListQueRy +="&idBacSiKhamBenh="+idBacSiKhamBenh+"&IdKhoa="+queryString("IdKhoa")+"";
             //alert(ListQueRy);
             return "../ajax/nvk_KhamThuongQuyDienBien_ajax.aspx?do=LuuTableBacSiKhamBenh"+ListQueRy+"";
             //&NgayCong=" + encodeURIComponent(NgayCong) + "&idNhanVien=" + encodeURIComponent(idNhanVien) + "&NgayThuong=" + encodeURIComponent(NgayThuong) + "&NgayTruc=" + encodeURIComponent(NgayTruc) + "&PhepKhongLuong=" + encodeURIComponent(PhepKhongLuong) + "&PhepCoLuong=" + encodeURIComponent(PhepCoLuong) + "&LamThemNuaNgay=" + encodeURIComponent(LamThemNuaNgay) + "&LamThemMotNgay=" + encodeURIComponent(LamThemMotNgay) + "&NghiOm=" + encodeURIComponent(NghiOm) + "&VoKyLuat=" + encodeURIComponent(VoKyLuat) + "&NghiBu=" + encodeURIComponent(NghiBu) + "&NghiLe=" + encodeURIComponent(NghiLe) + "&idNguoiDung=" + encodeURIComponent(idNguoiDung) + "&Giolamthem=" + encodeURIComponent(giolamthem);
         }
function nvk_LuuTableBacSiKhamBenh(control,functionlistcontroluutable)
{
    flagthemgio = false;
     tablegrid = "tableBacSiKhamBenh";
     if(document.getElementById(tablegrid) != null)
     {
      if(control.id.indexOf("luuTable") != -1)
         {
            for(var i=1;i<3;i++){
             document.getElementById("luuTable_"+i).value = "<%=hsLibrary.clDictionaryDB.sGetValueLanguage("stop") %> ";
             document.getElementById("luuTable_"+i).id = "huyTable_"+i;
             }
             flagtemp = true;
             row1=1;
             LuuTable('','flagthemgio = true;row1=1',row1,control,functionlistcontroluutable);
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
function nvk_btnMoi_click(obj)
{
    window.location.href="nvk_KhamThuongQuyDienBien.aspx?dkmenu="+queryString("dkmenu")+"&IdKhoa="+queryString("IdKhoa")+"";
}
//end nvk function
         function loaddroplist2()
         {
             laydanhsachTodroplist('-- Select one --','','',"../ajax/nvk_KhamThuongQuyDienBien_ajax.aspx?do=droplist_idNhanVien", 'ctl00_body_droplistidNhanVien_idNhanVien');
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
function chuyendong2(control,isAuTo){
//alert(event.keyCode+","+isAuTo);
    try{
        if(event.keyCode == 40 || (isAuTo != null && isAuTo==true)){
        //alert(tablegrid+":40 -> xuống");
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

    function kieuso(chuoi)
    {
        if(chuoi == "true")
            return 1;
        else
            return 0;    
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

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div style="margin-top: 10px; padding: 5px 5px 5px 5px; border: 1px solid #cfcfcf;
        background: white">
        <div style="padding: 2px 0px 2px 0px; background-color: #4473ca; border: 1px solid #cfcfcf;
            text-align: center; color: White; font-size: 25px; font-weight: bold">
            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("nvk_BacSiKhamBenh")%>
        </div>
        <div style="display: table-row; padding-bottom: 50px">
            <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; height: 40px;
                border-right: 1px solid #cfcfcf; border-bottom: 1px solid #cfcfcf;">
                <div style="float: left; padding: 10px 0px 10px 0px">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("NgayCong") %>
                    :
                </div>
                <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                    <input runat="server" id="NgayCong" type="text" onblur="TestDate(this);" onkeyup="chuyenphim(this)" />dd/MM/yyyy
                </div>
            </div>
            <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; height: 40px;
                border-right: 1px solid #cfcfcf; border-bottom: 1px solid #cfcfcf;">
                <div style="float: left; padding: 10px 0px 10px 0px">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("loaibacsi")%>
                    :</div>
                <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                    <asp:DropDownList ID="ddlLoaiNhanVien" runat="server">
                        <asp:ListItem Value="-1">---Tất cả---</asp:ListItem>
                        <asp:ListItem Value="0">Bênh viện</asp:ListItem>
                        <asp:ListItem Value="1">Ngoài Bệnh Viện</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; height: 40px;
                border-right: 1px solid #cfcfcf; border-bottom: 1px solid #cfcfcf;">
                <div style="float: left; padding: 10px 0px 10px 0px">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("khoa") %>
                    :</div>
                <div style="width: 70%; float: right; border-left: 1px solid #cfcfcf; padding: 10px 0px 10px 20px">
                    <asp:DropDownList ID="ddlPhongBan" TabIndex="1" runat="server" CssClass="input" Width="100%"
                         AutoPostBack="false">
                    </asp:DropDownList>
                </div>
            </div>
            <div style="float: left; padding: 0px 20px 0px 20px; width: 443px; height: 40px;
                border-right: 1px solid #cfcfcf; border-bottom: 1px solid #cfcfcf;">
                <div style="float: left; padding: 10px 0px 10px 0px">
                    <%=hsLibrary.clDictionaryDB.sGetValueLanguage("idbacsi") %>
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
                onclick="nvk_LuuTableBacSiKhamBenh(this,'nvk_ListControlLuuTable');" />
            <input id="Button2" type="button" style="margin-right: 10px" value="<%=hsLibrary.clDictionaryDB.sGetValueLanguage("timkiem") %>"
                onclick="nvk_TimKiemBacSiKhamBenh();" />
            <%--<asp:Button UseSubmitBehavior="false" ID="Button1" runat="server" Text='<%#hsLibrary.clDictionaryDB.sGetValueLanguage("timkiem") %>'
                OnClick="Button1_Click" />--%>
        </div>
        <div id="divNoiDung">
            <table class='jtable' id="tableBacSiKhamBenh" cellspacing="0" cellpadding="4" rules="all" style="background-color: #990000;
                border-color: #CC9966; border-width: 1px; border-style: None; width: 100%; border-collapse: collapse;">
                <tr style="background-color: #4473ca; font-weight: bold; color: #CCCCFF">
                    <th>Stt
                    </th>
                    <th>
                        Xóa</th>
                    <th>
                        Bác Sĩ</th>
                    <th>
                        Khám thường quy</th>
                    <th>
                        Khám diễn biến</th>
                    <th>
                        Khám dịch vụ khác</th>
                    <th>
                    </th>
                </tr>
                <tr onmouseover="if(this.style.backgroundColor != 'red'){this.style.backgroundColor='#F6EBCD',this.style.cursor = 'pointer'}"
                    onmouseout="if(this.style.backgroundColor != 'red'){this.style.backgroundColor='White'}"
                    style="color: #003399; background-color: White;">
                    <td >1
                    </td>
                    <td >
                        <a onkeydown="chuyendong(this);" style='text-decoration: none; cursor: pointer; margin-right: 10px;
                            color: green;' onclick="xoaontabletableBacSiKhamBenh(this.name,this);" name="">
                            <%=hsLibrary.clDictionaryDB.sGetValueLanguage("delete") %>
                        </a>
                    </td>
                    <td >
                        <input name="ctl00$body$gridTable$ctl09$Text1" type="text" id="ctl00_body_gridTable_ctl09_Text1"
                            style="width: 202px" onfocus="nvk_laylaichuyendong(this);" />
                        <input type="hidden" name="ctl00$body$gridTable$ctl09$idnv" id="ctl00_body_gridTable_ctl09_idnv" />
                    </td>
                    <td >
                        <input type="checkbox" onkeydown="chuyendong(this);" style="width: 15px; border: none" />
                    </td>
                    <td >
                    </td>
                    <td >
                    </td>
                    <td >
                        <input type="hidden" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding: 10px 0 10px 0;">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <input id="luuTable_2" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("save") %>'
                onclick="nvk_LuuTableBacSiKhamBenh(this,'nvk_ListControlLuuTable');" />
            <input id="Button1" type="button" value='<%=hsLibrary.clDictionaryDB.sGetValueLanguage("new") %>'
                onclick="nvk_btnMoi_click(this);" />
        </div>
    </div>
</asp:Content>

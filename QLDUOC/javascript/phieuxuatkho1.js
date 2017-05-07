$(document).ready(function() {
       setControlFind($.mkv.queryString("idkhoachinh"));
       $("#luu").click(function () {
           $(this).Luu({
              ajax:"../ajax/phieuxuatkho_ajax1.aspx?do=Luu"
              },null,function () {
                 $("#timKiem").click();
           });
        });
        $("#moi").click(function () {
             $(this).Moi();  
             setIdKho();
        });
        $("#xoa").click(function () {
            $(this).Xoa({
                ajax:'../ajax/phieuxuatkho_ajax1.aspx?do=xoa'
            },null,function () {
                 $("#timKiem").click();
            });
        });
        $("#timKiem").click(function () {
            Find(this);
        });
        setIdKho();
        //$("#timKiem").click();
 });
function setIdKho()
 {
   if(($.mkv.queryString("IdKho2")!=null || $.mkv.queryString("IdKho2")!="") && (($.mkv.queryString("IdKho")==null || $.mkv.queryString("IdKho")==""))){
            $("#divMaPhieu").css("display","none");
            $("#divGhichu").css("display","none");
            $("#divKhachHang").css("display","none");
            $("#divNhaCC").css("display","none");
            $("#divLoaiThuoc").css("display","none");
            $("#divThuoc").css("display","none");
            $("#mkv_idkho2").attr("disabled",true);
            $("#mkv_idkho").attr("disabled",false);
            $("#mkv_loaixuat").attr("disabled",true);
         }
    if($.mkv.queryString("idkho")=="5")
    {
        $(".header-div").html("DANH SÁCH PHIẾU XUẤT TRẢ");
    }
    $.BindFind({
        ajax:"../ajax/phieuxuatkho_ajax1.aspx?do=setIdKho"
        +"&idkhoa="+$.mkv.queryString("idkhoa")
        +"&IdKho="+$.mkv.queryString("IdKho")
        +"&IdKho2="+$.mkv.queryString("IdKho2")
        +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID"),useEnabled:false
    });
 }
  function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         //$.BindFind({ajax:"../ajax/phieuxuatkho_ajax1.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});
         var loaixuat=$.mkv.queryString("loaixuat");
         if(loaixuat==null || loaixuat=="")
            loaixuat=$("#loaixuat").val();
         if(loaixuat=="4")
            window.open("phieuxuatkho3.aspx#idkhoachinh="+idkhoatimkiem );
            if(loaixuat=="1")
               window.open("phieuxuatkho_XuatLe.aspx#idkhoachinh="+idkhoatimkiem );
             if(loaixuat=="3")
               window.open("phieuxuatkho_traNCC3.aspx#idkhoachinh="+idkhoatimkiem );
             
             if(loaixuat=="5")
               window.open("HS_ChiTietPhieuXuat.aspx#idkhoachinh="+idkhoatimkiem );
         
      }      
  }
   function Find(control,page) {
   
   
   var idkho2=$.mkv.queryString("idkho2");
   var loaixuat=$.mkv.queryString("loaixuat");
   var idkho2_clause="";
   if(idkho2!=null && idkho2!="")
        idkho2_clause="&idkho2="+idkho2;
        
   var loaixuat_clause="";
   if(loaixuat!=null && loaixuat!="")
        loaixuat_clause="&loaixuat="+loaixuat;
        
        
   if(page == null) page = "1";
      $(control).TimKiem({
             ajax:"../ajax/phieuxuatkho_ajax1.aspx?do=TimKiem&page="+page+idkho2_clause+loaixuat_clause,showPopup:false
       },function () {
         $("#tableAjax_phieuxuatkho").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
         return true;
     }, function (data) {
             $("#tableAjax_phieuxuatkho").html(data);
             $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
       });
      
  }
function idkhoSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax1.aspx?do=idkhoSearch",{
     minChars:0,
     width:250,
     scroll:true,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
function loaixuatSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax1.aspx?do=loaixuatSearch",{
     minChars:0,
     width:240,
     scroll:true,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
function IDKhachHangSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax1.aspx?do=IDKhachHangSearch",{
     minChars:0,
     width:350,
     scroll:true,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
function idnhacungcapSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax1.aspx?do=idnhacungcapSearch",{
     minChars:0,
     width:350,
     scroll:true,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
function idkho2Search(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax1.aspx?do=idkho2Search",{
     minChars:0,
     width:250,
     scroll:true,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
function IdLoaiThuocSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax1.aspx?do=IdLoaiThuocSearch",{
     minChars:0,
     width:250,
     scroll:true,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
  function idthuocSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_ajax1.aspx?do=idthuocSearch&LoaiThuocID="+$("#IdLoaiThuoc").val(),{
     minChars:0,
     width:350,
     scroll:true,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }

function nvk_timKiemPhieuNhapTra(control,page) 
{
var idkho2=$.mkv.queryString("idkho2");
var loaixuat=$.mkv.queryString("loaixuat");
var idkho2_clause="";
if(idkho2!=null && idkho2!="")
idkho2_clause="&idkho2="+idkho2;

var loaixuat_clause="";
if(loaixuat!=null && loaixuat!="")
loaixuat_clause="&loaixuat="+loaixuat;


if(page == null) page = "1";
$(control).TimKiem({
     ajax:"../ajax/phieuxuatkho_ajax1.aspx?do=nvk_TimKiemPhieuNhapTra&page="+page+idkho2_clause+loaixuat_clause,showPopup:false
},function () {
 $("#tableAjax_phieuxuatkho").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
 return true;
},function (data) {
     $("#tableAjax_phieuxuatkho").html(data);
     $("table.jtable tr:nth-child(odd)").addClass("odd");
         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
});
}
var today=new Date();
var dd=today.getDate();
var MM=today.getMonth() + 1;
var yyyy=today.getFullYear();
if(dd<10) dd='0' + dd;
if(MM<10) MM='0' + MM;
$(document).ready(function() {
     $.mkv.moveUpandDown("#tablefind");
   setControlFind($.mkv.queryString("idkhoachinh"));
     $("#luu").click(function () {
       $(this).Luu({
             ajax:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=Luu"
          },null,function () {
               $.LuuTable({
                     ajax:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=luuTablechitietphieuxuatkho&idphieuxuat=" + $.mkv.queryString("idkhoachinh"),
                     tablename:"gridTable"
               });
          });
    });
    $("#moi").click(function () {
              setIdKho();           
         $(this).Moi();                    
         loadTableAjaxchitietphieuxuatkho('');
    });
    $("#xoa").click(function () {
       $(this).Xoa({
             ajax:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=xoa"
        },null,function () {
             loadTableAjaxchitietphieuxuatkho('');
         });
    });
    $("#timKiem").click(function () {
        Find($(this)); 
     });
    $("#printBienBan").click(function(){
       var idphieuxuat=$.mkv.queryString("idkhoachinh");
        if(idphieuxuat==null ||idphieuxuat=="") return false;
              $.ajax({
                type:"POST",
                url:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=PrintBienBan"
                         +"&idphieuxuat=" + idphieuxuat,
                dataType:"text",
                success:function(data){
                    window.open(data,"_blank");
                }
         });
    });
       setIdKho();
});
 function setIdKho()
 {
    $.BindFind({
        ajax:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=setIdKho",useEnabled:false
    },null,function(){
        $("#mkv_idkho").attr("disabled",true);
        $("#ngaythang").val(dd + "/" + MM + "/"  + yyyy);
     });
 }

function setControlFind(idkhoatimkiem) {
  if(idkhoatimkiem != "" && idkhoatimkiem != null){
     $.BindFind({ajax:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem},null,function () {
         loadTableAjaxchitietphieuxuatkho($.mkv.queryString("idkhoachinh"));                    
     });
  }else{loadTableAjaxchitietphieuxuatkho();}         
}
function Find(control,page) {
  if(page == null)page = "1";
  $(control).TimKiem({
         ajax:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=TimKiem&page="+page
   });
}
function xoaontable(control,bool){
if(bool || bool == null)
  $(control).XoaRow({
     ajax:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=xoachitietphieuxuatkho"
  });
}
function loadTableAjaxchitietphieuxuatkho(idkhoa,page)
{
 if(idkhoa == null) idkhoa = "";
     if(page == null) page = "1";
     $("#tableAjax_chitietphieuxuatkho").html('<img src="../images/loading-bar.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
      $.ajax({
     type:"GET",
     cache:false,
     url:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=loadTablechitietphieuxuatkho&idphieuxuat="+idkhoa+"&page="+page,
      success: function (value){
             $("#tableAjax_chitietphieuxuatkho").html(value);
        }
 });
}
function IdLoaiThuocSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax3.aspx?do=IdLoaiThuocSearch",{
 minChars:0,
 width:250,
 scroll:true,
 header:false,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idthuoc").focus();
     },100);
 });
}
function idthuocSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_HV_ajax3.aspx?do=idthuocSearch&idkho="+$("#idkho").val() +"&LoaiThuocID="+$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdLoaiThuoc").val(),{
    minChars:0,
    width:850,
    addRow:true,
     scroll:true,
     header:  "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
            + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
            + "<div style=\"width:38%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;padding-left:5px;\" >Tên thuốc/VTYT/HC</div>"
            + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
            + "<div style=\"width:19%;height:30px;color:#000;font-weight:bold;float:left; text-align:left;\" >Hoạt chất</div>"
            + "<div style=\"width:11%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
            + "<div style=\"width:6%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
            + "</div>",
     formatItem:function (data) {
          return data[0];
     }}).result(function(event,data){
         if($(obj).parents("#gridTable").attr("id") != null){
                 $(obj).val(data[4]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dvt").val(data[9]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_dvt").val(data[10]);
                 $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON").val(data[6]);
                 if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                    $.mkv.themDongTable("#gridTable");
         }
     setTimeout(function () {
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#LOSANXUAT_XUAT").focus();
     },100);
 });
}
function dvtSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_HV_ajax3.aspx?do=dvtSearch",{
 minChars:0,
 scroll:true,
 header:false,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         obj.focus();
     },100);
 });
}
function IdNuocSX_XSearch(obj)
{
 $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_HV_ajax3.aspx?do=IdNuocSX_XSearch",{
 minChars:0,
 scroll:true,
 header:false,
 formatItem:function (data) {
      return data[0];
 }}).result(function(event,data){
     if($(obj).parents("#gridTable").attr("id") != null){
         $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
         if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
             $.mkv.themDongTable("gridTable");
     }
     setTimeout(function () {
         obj.focus();
     },100);
 });
}
function idkhoSearch(obj)
{
    $(obj).unautocomplete().autocomplete("../ajax/phieuxuatkho_HV_ajax3.aspx?do=idkhoSearch"
        +"&idkhoa="+$.mkv.queryString("idkhoa")
        +"&IdKho="+$.mkv.queryString("IdKho")
        ,{
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
function tinhtien(obj)
{
   var sl=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val().replace(/\./g,'').replace(/\,/g,'.'));
   var dongia=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val().replace(/\./g,'').replace(/\,/g,'.'));
   var tt=sl*dongia;
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#thanhtien").val(formatCurrency(tt));
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val(formatCurrency1(sl));
   $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(formatCurrency(dongia));
}
function setNuocSX(obj)
{
    var idthuoc=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#idthuoc").val();
    if(idthuoc==null || idthuoc=="")return;
    $.ajax({
        async:false,
        url:"../ajax/phieuxuatkho_HV_ajax3.aspx?do=setNuocSX&idthuoc="+ idthuoc,
        success:function(data){
            if(data!=""){
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#IdNuocSX_X").val(data.split("|")[0]);
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_IdNuocSX_X").val(data.split("|")[1]);
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#dongia").val(formatCurrency(data.split("|")[2]));
            }
        },
        errror:function(msg)
        {
            $.mkv.myerror(msg);
        }
    });
}
function checkSLTON(obj)
{
    var SLTON=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#SLTON").val().replace(/\./g,'').replace(/\,/g,'.'));
    var SL=eval($("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluong").val().replace(/\./g,'').replace(/\,/g,'.'));
    if(SL>SLTON)
    {
        $.mkv.myerror("Số lượng không lớn hơn > " + SLTON );
        $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#soluong").focus();
        $("#luu").attr("disabled",true);
        return false;
    }
    else
    {
        $("#luu").attr("disabled",false);
    }
}
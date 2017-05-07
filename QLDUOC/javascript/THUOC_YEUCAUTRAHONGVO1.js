var today = new Date();
var dd = today.getDate();
var MM = today.getMonth() + 1; //January is 0!
var yyyy = today.getFullYear();
var hh = today.getHours();
var mm = today.getMinutes();
if (dd < 10) { dd = '0' + dd }
if (MM < 10) { MM = '0' + MM }
 $(document).ready(function() {
         $("#ngayduyet").val(dd + "/" + MM + "/" + yyyy);
         $("#gioduyet").val(hh);
         $("#phutduyet").val(mm);
       setControlFind($.mkv.queryString("idkhoachinh"));
       $("#luu").click(function () {
           $(this).Luu({
              ajax:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax1.aspx?do=Luu"
              },null,function () {
                 $("#timKiem").click();
           });
        });
        $("#moi").click(function () {
             $(this).Moi();
             $("#ngayduyet").val(dd + "/" + MM + "/" + yyyy);
             $("#gioduyet").val(hh);
             $("#phutduyet").val(mm);  
        });
        $("#xoa").click(function () {
            $(this).Xoa({
                ajax:'../ajax/THUOC_YEUCAUTRAHONGVO_ajax1.aspx?do=xoa'
            },null,function () {
                 $("#timKiem").click();
            });
        });
        $("#timKiem").click(function () {
            Find(this);
        });
 });
  function setControlFind(idkhoatimkiem,isdaduyet) {
    if($("#ngayduyet").val()=="" || $("#gioduyet").val()=="" || $("#phutduyet").val()=="")
    {
        $.mkv.myerror("Vui lòng chọn ngày duyệt");
        return;
    }
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax1.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem },null,function(){
             $("#ngayduyet").val(dd + "/" + MM + "/" + yyyy);
             $("#gioduyet").val(hh);
             $("#phutduyet").val(mm);   
         });
            window.open("THUOC_YEUCAUTRAHONGVO3.aspx#idkhoachinh=" + idkhoatimkiem + "&ngayduyet=" + $("#ngayduyet").val() + " " + $("#gioduyet").val() + ":" + $("#phutduyet").val() + "#isduyet=1" + "&isdaduyet="  + isdaduyet,"_blank");
      }
           
  }
   function Find(control,page) {
   if(page == null) page = "1";
      $(control).TimKiem({
             ajax:"../ajax/THUOC_YEUCAUTRAHONGVO_ajax1.aspx?do=TimKiem&page="+page,showPopup:false
       },function () {
         $("#tableAjax_THUOC_YEUCAUTRAHONGVO").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
         return true;
      },function (data) {
             $("#tableAjax_THUOC_YEUCAUTRAHONGVO").html(data);
       });
      
  }
function IdKhoYeuCauSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/THUOC_YEUCAUTRAHONGVO_ajax1.aspx?do=IdKhoYeuCauSearch",{
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
function IdKhoNhanTraSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/THUOC_YEUCAUTRAHONGVO_ajax1.aspx?do=IdKhoNhanTraSearch",{
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

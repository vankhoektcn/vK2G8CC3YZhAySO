 $(document).ready(function() {
       setControlFind($.mkv.queryString("idkhoachinh"));
       $("#luu").click(function () {
           $(this).Luu({
              ajax:"../ajax/phieunhapkho_ajax1.aspx?do=Luu"
              },null,function () {
                 $("#timKiem").click();
           });
        });
        $("#moi").click(function () {
             $(this).Moi();  
        });
        $("#xoa").click(function () {
            $(this).Xoa({
                ajax:'../ajax/phieunhapkho_ajax1.aspx?do=xoa'
            },null,function () {
                 $("#timKiem").click();
            });
        });
        $("#timKiem").click(function () {
            Find(this);
        });
        $("#TuNgay").bind("focus",function(){
            $(this).datepick();
        });
        if($.mkv.queryString("idloaithuoc")!=""){
            $("#divLoaiThuoc").css("display","");
        }else{
            $("#divLoaiThuoc").css("display","none");
        }
 });
  function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/phieunhapkho_ajax1.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});
         window.open("phieunhapkho3.aspx?idkhoachinh="+idkhoatimkiem +"&idloainhap=1");
      }      
  }
   function Find(control,page) {
   var loaithuocid=$("#loaithuocid").val();
   if(page == null) page = "1";
      $(control).TimKiem({
             ajax:"../ajax/phieunhapkho_ajax1.aspx?do=TimKiem&TuNgay="+$("#TuNgay").val()
                +"&idkhoa="+$.mkv.queryString("idkhoa")
                +"&IdKho="+$.mkv.queryString("IdKho")
                +"&LoaiThuocID="+ loaithuocid +"&page="+page,showPopup:false
       },function () {
         $("#tableAjax_phieunhapkho").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
         return true;
      },function (data) {
             $("#tableAjax_phieunhapkho").html(data);
             $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
       });
      
  }
function idkhoSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax1.aspx?do=idkhoSearch",{
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
function nhacungcapidSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax1.aspx?do=nhacungcapidSearch",{
     minChars:0,
     width:550,
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
function idthuocSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax1.aspx?do=idthuocSearch",{
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
function loaithuocidSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/phieunhapkho_ajax1.aspx?do=loaithuocidSearch",{
     minChars:0,
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

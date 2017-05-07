 $(document).ready(function() {
       SetDefaultValue();  
       setControlFind($.mkv.queryString("idkhoachinh"));
       $("#luu").click(function () {
       
       
            var LoaiThuocID=$.mkv.queryString("LoaiThuocID");
            
           var LoaiThuocID_clause="";
           if(LoaiThuocID!=null && LoaiThuocID!="")
                LoaiThuocID_clause="&LoaiThuocID="+LoaiThuocID;
       
           $(this).Luu({
              ajax:"../ajax/thuoc_ajax1.aspx?do=Luu"+LoaiThuocID_clause + "&IsQPTBH=" + $.mkv.queryString("IsQPTBH")
              },null,function () {
                 $("#timKiem").click();
           });
        });
        $("#moi").click(function () {
             $(this).Moi();  
             SetDefaultValue();
        });
        $("#xoa").click(function () {
            $(this).Xoa({
                ajax:'../ajax/thuoc_ajax1.aspx?do=xoa'
            },null,function () {
                 $("#timKiem").click();
            });
        });
        $("#timKiem").click(function () {
            Find(this);
        });
        $("#timKiem").click();
        //───────────────────────────────────────────────────────────────────────────────────────
        $("#btnXuatExel").click(function(){
                 var LoaiThuocID = $.mkv.queryString("LoaiThuocID");
                 var CateID = $("#CateID").val();
                 var sudungchobh = $("#sudungchobh").is(':checked');
                  var  NhomThuocID = "";
                  var  IsTHTT = "";
                  var  IsTGN = "";
                  var ISTDTL = "";
                  var  ISTPX = "";
                  var  ISTcorticoid  = "";
                  var  ISTKS  = "";
                  var  IsDTUT  = "";
                  
                 if(LoaiThuocID=="1")
                 {
                    NhomThuocID = $("#idnhomthuoc").val();
                    IsTHTT = $("#IsTHTT").is(':checked');
                    IsTGN = $("#IsTGN").is(':checked');
                    ISTDTL = $("#ISTDTL").is(':checked');
                    ISTPX = $("#ISTPX").is(':checked');
                    ISTcorticoid = $("#ISTcorticoid").is(':checked');
                    ISTKS = $("#ISTKS").is(':checked');
                    IsDTUT = $("#IsDTUT").is(':checked');
                 
                 }
                 $.mkv.loading();
                      $.ajax({
                        type:"POST",
                        url:"../ajax/thuoc_ajax1.aspx?do=XuatExcel"
                                 +"&LoaiThuocID="+LoaiThuocID
                                 +"&CateID="+CateID
                                 +"&NhomThuocID="+NhomThuocID
                                 +"&IsTHTT="+IsTHTT
                                 +"&IsTGN="+IsTGN
                                 +"&ISTDTL="+ISTDTL
                                 +"&ISTPX="+ISTPX
                                 +"&ISTcorticoid="+ISTcorticoid
                                 +"&ISTKS="+ISTKS
                                 +"&IsDTUT="+IsDTUT
                                 +"&sudungchobh="+sudungchobh
                                 +"&IsQPTBH=" + $.mkv.queryString("IsQPTBH")
                                 ,
                        dataType:"text",
                        success:function(data){
                             $("#loadingAjax").remove();
                            window.open(data,"_blank");
                        }
                    });
                });     
            //───────────────────────────────────────────────────────────────────────────────────────
 });
    
     function setControlFind(idkhoatimkiem) {
      if(idkhoatimkiem != "" && idkhoatimkiem != null){
         $.BindFind({ajax:"../ajax/thuoc_ajax1.aspx?do=setTimKiem&idkhoachinh="+idkhoatimkiem});
      }      
  }
   function Find(control,page) {
   if(page == null) page = "1";
      $(control).TimKiem({
                 ajax:"../ajax/thuoc_ajax1.aspx?do=TimKiem"
                 +"&LoaiThuocID="+$.mkv.queryString("LoaiThuocID")
                 +"&searchbyIsTGN="+$("#searchbyIsTGN").is(":checked")
                 +"&searchbyIsTHTT="+$("#searchbyIsTHTT").is(":checked")
                 +"&searchbyISTPX="+$("#searchbyISTPX").is(":checked")
                 +"&searchbyISTKS="+$("#searchbyISTKS").is(":checked")
                 +"&searchbyISTDTL="+$("#searchbyISTDTL").is(":checked")
                 +"&searchbyISTcorticoid="+$("#searchbyISTcorticoid").is(":checked")
                 +"&searchbyIsDTUT="+$("#searchbyIsDTUT").is(":checked")
                 + "&IsQPTBH=" +$.mkv.queryString("IsQPTBH")
                 +"&page="+page,showPopup:false,async:false
           },function () {
             $("#tableAjax_thuoc").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
          },function (data) {
                 $("#tableAjax_thuoc").html(data);
                 $("table.jtable tr:nth-child(odd)").addClass("odd");
                     $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                     $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
           });
      
  }
function idnuocsanxuatSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=idnuocsanxuatSearch",{
     minChars:0,
     width:150,
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
function idnhomthuocSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=idnhomthuocSearch&CateID="+$("#CateID").val(),{
     minChars:0,
     width:850,
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
function iddvtSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=iddvtSearch",{
     minChars:0,
     width:140,
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
 
 function DVTChuanSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=iddvtSearch",{
     minChars:0,
     width:140,
     scroll:true,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         $("#"+obj.id.replace("mkv_","")).val(data[1]);
         
         $("#iddvt").val(data[1]);
         $("#mkv_iddvt").val(data[0]);
         
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
function LoaiThuocIDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=LoaiThuocIDSearch",{
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
function idhangsanxuatSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=idhangsanxuatSearch",{
     minChars:0,
     width:150,
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
function CateIDSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=CateIDSearch&loaithuocid="+$.mkv.queryString("LoaiThuocID"),{
     minChars:0,
     width:850,
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
function IdCachDungSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=IdCachDungSearch&loaithuocid="+$.mkv.queryString("LoaiThuocID"),{
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
function TenThuocSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=TenThuocSearch&loaithuocid="+$.mkv.queryString("LoaiThuocID"),{
     minChars:0,
     width:490,
     scroll:true,
     header:false,
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 
 function SetDefaultValue()
 {
    $("#SLDVTChuan").val("1");
    $("#SLQuyDoi").val("1");
    if($.mkv.queryString("IsQPTBH")=="1"){
        $("#IsQPTBH").css("display","none");
    }
 }
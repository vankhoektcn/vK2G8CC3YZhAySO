 $(document).ready(function() {
       SetDefaultValue();  
       setControlFind($.mkv.queryString("idkhoachinh"));
       $("#luu").click(function () {
       
       
            var LoaiThuocID=$.mkv.queryString("LoaiThuocID");
            
           var LoaiThuocID_clause="";
           if(LoaiThuocID!=null && LoaiThuocID!="")
                LoaiThuocID_clause="&LoaiThuocID="+LoaiThuocID;
       
           $(this).Luu({
              ajax:"../ajax/thuoc_ajax1.aspx?do=Luu"+LoaiThuocID_clause
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
             +"&page="+page,showPopup:false
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
 function tkkhoSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=tkkhoSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >TK</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Ten tk</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function tkdoanhthuSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=tkkhoSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Tài khoản</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Tên tài khoản</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
         setTimeout(function () {
             obj.focus();
         },100);
     });
 }
 function tkgiavonSearch(obj)
 {
     $(obj).unautocomplete().autocomplete("../ajax/thuoc_ajax1.aspx?do=tkkhoSearch",{
     minChars:0,
     width:390,
     scroll:true,
     header: "<div style =\"width:100%;height:30px\">"
                    + "<div style=\"width:10%;color:white;float:left; font-size:12px;text-algin:left;\" >Tài khoản</div>"
                      + "<div style=\"width:80%;color:white;float:left;font-size:12px;\" >Tên tài khoản</div>"
                  + "</div>",
     formatItem:function (data) {
         return data[0];
     }}).result(function(event,data){
             $("#"+obj.id.replace("mkv_","")).val(data[1]);
                $(this).val(data[1]);
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
 
 function dvtchuanSearch(obj)
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
 
 }
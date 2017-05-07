
         $(document).ready(function() {
          Find("#timKiem");
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/DiaChi_ajax2.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
             
         });
         function xoa(control){
              $(control).XoaRow({ajax:'../ajax/DiaChi_ajax2.aspx?do=xoa'});
         }
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/DiaChi_ajax2.aspx?do=TimKiem&page="+page,showPopup:false
               },function () {
                     $("#tableAjax_DiaChi").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                         $("#tableAjax_DiaChi").html(data);
               });
              
         }
         /////////////////////////////////////////////
         function idXaSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/DiaChi_ajax2.aspx?do=idXaSearch&quanhuyenid="+$("#quanhuyenid").val(),{
             minChars:0,
             width:350,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function idXaSearchLuoi(obj)
         {//quanhuyenid
             var quanhuyenid=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#quanhuyenid").val();
             $(obj).unautocomplete().autocomplete("../ajax/DiaChi_ajax2.aspx?do=idXaSearch&quanhuyenid="+quanhuyenid,{
             minChars:0,
             width:350,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function MaDiaChiSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/DiaChi_ajax2.aspx?do=MaDiaChiSearch",{
             minChars:0,
             width:350,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
          
         function idQuanHuyenSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/DiaChi_ajax2.aspx?do=idQuanHuyenSearch&tinhid="+$('#tinhid').val(),{
             minChars:0,
             width:350,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         } 
          function idQuanHuyenSearchLuoi(obj)
         {//tinhid
             var tinhid=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#tinhid").val();
             $(obj).unautocomplete().autocomplete("../ajax/DiaChi_ajax2.aspx?do=idQuanHuyenSearch&tinhid="+tinhid,{
             minChars:0,
             width:350,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         } 
         function tinhidSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/DiaChi_ajax2.aspx?do=tinhidSearch",{
             minChars:0,
             width:350,
             
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                     if ($("#gridTable").find("tr").eq($(obj).parent().parent().index() + 1).find("td:eq(1)").find("a:first").length == 0)
                         $.mkv.themDongTable("gridTable");
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }  
         function GhepDiaChi(obj)
         {
             var tinh=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_tinhid").val();
              var quanhuyen=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_quanhuyenid").val();
              var xa=$("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#mkv_idXa").val();
              $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id).val(xa+', '+quanhuyen+', '+tinh);
         }



         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/banggiadichvu_ajax2.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
           $("#xuatexecl").click(function () 
          {
	        $(this).TimKiem({
                     ajax:"../ajax/banggiadichvu_ajax2.aspx?do=xuatexecl"
               },function (data) {
                        window.open("../ReportOutput/"+data);
                        
               });
              
             });
         });
         
         function xoa(control){
              $(control).XoaRow({ajax:'../ajax/banggiadichvu_ajax2.aspx?do=xoa'});
         }
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/banggiadichvu_ajax2.aspx?do=TimKiem&page="+page
               },function (data) {
                         $("#tableAjax_banggiadichvu").html(data);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               },function () {
                     $("#tableAjax_banggiadichvu").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               });
              
         }
         function idphongkhambenhSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/banggiadichvu_ajax2.aspx?do=idphongkhambenhSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
         function IDLoaiCLSSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/banggiadichvu_ajax2.aspx?do=IDLoaiCLSSearch",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }

         function IDLoaiDVS(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/banggiadichvu_ajax2.aspx?do=IDLoaiDV",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
          function timNhom(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/banggiadichvu_ajax2.aspx?do=TimNhomCLS",{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                 if($(obj).parents("#gridTable").attr("id") != null){
                     $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("mkv_","")).val(data[1]);
                 }else{
                     $("#"+obj.id.replace("mkv_","")).val(data[1]);                    
                 }
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }

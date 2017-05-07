
         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/khambenh_ajax2.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
             
         });
         function nhapvien(control,idkhambenh){
           
              $(control).TimKiem({ajax:'../ajax/khambenh_ajax2.aspx?do=xoa&idkhambenh='+idkhambenh
              });
         }
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/khambenh_ajax2.aspx?do=TimKiem&page="+page
               },function (data) {
                         $("#tableAjax_khambenh").html(data);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               },function () {
                     $("#tableAjax_khambenh").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               });
              
         }
        function IdbacsiSearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax2.aspx?do=IdbacsiSearch",{
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
         function idkhoasearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/khambenh_ajax2.aspx?do=idkhoasearch",{
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
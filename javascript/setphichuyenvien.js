
         $(document).ready(function() {
        
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/setphichuyenvien_ajax.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
             
         });
        
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/setphichuyenvien_ajax.aspx?do=TimKiem&page="+page
               },function (data) {
                         $("#tableAjax_setphichuyenvien").html(data);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               },function () {
                     $("#tableAjax_setphichuyenvien").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               });
              
         }
         /////////////////////////////////////////////
         function dichvusearch(obj)
         {
             $(obj).unautocomplete().autocomplete("../ajax/setphichuyenvien_ajax.aspx?do=dichvusearch",{
             minChars:0,
             width:350,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[0];
             }}).result(function(event,data){
                       $("#gridTable").find("tr").eq($(obj).parent().parent().index()).find("#"+obj.id.replace("dv","iddv")).val(data[1]);
                 
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
         }
        
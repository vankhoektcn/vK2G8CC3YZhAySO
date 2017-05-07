
         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ketoan/ajax/DSManHinh_ajax.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
             Find($("#timKiem"));
         });
         function xoa(control){
              $(control).XoaRow({ajax:'../ketoan/ajax/DSManHinh_ajax.aspx?do=xoa'});
         }
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ketoan/ajax/DSManHinh_ajax.aspx?do=TimKiem&page="+page
               },function (data) {
                         $("#tableAjax_DSManHinh").html(data);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               },function () {
                     $("#tableAjax_DSManHinh").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               });
              
         }

         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"ajax/KTTSCD_Danhsachtaisan_ajax.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
         });
         function xoa(control,bool){
            if(bool || bool == null)
              $(control).XoaRow({ajax:'ajax/KTTSCD_Danhsachtaisan_ajax.aspx?do=xoa'});
         }
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"ajax/KTTSCD_Danhsachtaisan_ajax.aspx?do=TimKiem&page="+page,showPopup:false
               },function () {
                     $("#tableAjax_DanhMucTaiSan").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                         $("#tableAjax_DanhMucTaiSan").html(data);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               });              
         }
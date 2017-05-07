
         $(document).ready(function() {
             $('input[id^=luuTable]').click(function () {
                $(this).LuuTable({ajax:"../ajax/CongNo_DauKi_ajax2.aspx?do=luuTable",tablename:"gridTable"});
             });
             $("#timKiem").click(function () {
                    Find(this);
             });
         });
         function xoa(control,bool){
            if(bool || bool == null)
              $(control).XoaRow({ajax:'../ajax/CongNo_DauKi_ajax2.aspx?do=xoa'});
         }
          function Find(control,page) {
           if(page == null) page = "1";
              $(control).TimKiem({
                     ajax:"../ajax/CongNo_DauKi_ajax2.aspx?do=TimKiem&page="+page,showPopup:false
               },function () {
                     $("#tableAjax_CongNo_DauKi").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
                     return true;
               },function (data) {
                         $("#tableAjax_CongNo_DauKi").html(data);
                         $("table.jtable tr:nth-child(odd)").addClass("odd");
                         $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                         $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
               });
              
         }
         
          function doituong(obj)
        {
             $(obj).unautocomplete().autocomplete("ajax/CongNo_DauKi_ajax2.aspx?do=doituongsearch&mancc="+$("#mkv_ma_ncc").val(),{
             minChars:0,
             width:350,
             scroll:true,
             header:"DANH SÁCH",
             formatItem:function (data) {
                  return data[1];
             }}).result(function(event,data){
                 $("#ma_ncc").val(data[1]);
                 $("#mkv_ma_ncc").val(data[1]);
                 $("#ten_ncc").val(data[2]);
                 $("#diachi_ncc").val(data[3]);
                 setTimeout(function () {
                     obj.focus();
                 },100);
             });
        }

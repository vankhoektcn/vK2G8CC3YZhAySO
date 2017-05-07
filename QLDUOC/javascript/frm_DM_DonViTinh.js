 $(document).ready(function() {
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({ajax:"../ajax/frm_DM_DonViTinh_ajax.aspx?do=luuTable",tablename:"gridTable"});
     });
     $("#timKiem").click(function () {
            Find(this);
     });
      $("#timKiem").click();
 });
 function xoa(control){
      $(control).XoaRow({ajax:'../ajax/frm_DM_DonViTinh_ajax.aspx?do=xoa'});
 }
  function Find(control,page) {
   if(page == null) page = "1";
      $(control).TimKiem({
             ajax:"../ajax/frm_DM_DonViTinh_ajax.aspx?do=TimKiem&page="+page,showPopup:false
       },function () {
             $("#tableAjax_Thuoc_DonViTinh").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
                 $("#tableAjax_Thuoc_DonViTinh").html(data);
                 $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
       });
      
 }

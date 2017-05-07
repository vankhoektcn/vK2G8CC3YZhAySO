var today = new Date();
var dd = today.getDate();
var mm = today.getMonth() + 1; //January is 0!
var yyyy = today.getFullYear();
if (dd < 10) { dd = '0' + dd }
if (mm < 10) { mm = '0' + mm }
 $(document).ready(function() {
     $("#TuNgay,#DenNgay").val(dd + "/" + mm + "/" + yyyy);
     $('input[id^=luuTable]').click(function () {
        $(this).LuuTable({
            ajax:"../ajax/HS_BenhNhanBHDongTien_ajax2.aspx?do=luuTable",
            tablename:"gridTable"
       });
     });
     $("#timKiem").click(function () {
            Find(this);
     });
     //───────────────────────────────────────────────────────────────────────────────────────
        $("#Config").click(function () {
                  if($("#DenNgay").val()==null || $("#DenNgay").val()==""){
                        $.mkv.myerror("Phải chọn đến ngày");
                        $("#DenNgay").focus();
                        return false;
                  }
                   if($("#SoVaoVienMax").val()==null || $("#SoVaoVienMax").val()==""){
                        $.mkv.myerror("Vui lòng chọn số vào viện tối đa");
                        $("#SoVaoVienMax").focus();
                        return false;
                  }
                  jConfirm("Bạn có thực sự muốn thực hiện chức năng này ? ","Xác nhận",function(r){
                     if(r){
                            $.ajax({
                            async:false,
                            cache:true,
                            dataType:"text",
                           url:"../ajax/HS_BenhNhanBHDongTien_ajax2.aspx?do=Config"
                                    +"&DenNgay="+$("#DenNgay").val()
                                    +"&SoVaoVienMax="+$("#SoVaoVienMax").val()
                                    +"&IsNoiTru_Save="+$("#IsNoiTru_Save").is(":checked"),
                            success:function(value){
                              if(value!=""){
                                  alert("Cấu hình thành công");
                              }
                            },
                            error:function(data){
                                alert("Cấu hình không thành công");
                            }
                        }); 
                     }
                   });
           });
        $("#moi").click(function(){
            $(this).Moi();
             $("#TuNgay,#DenNgay").val(dd + "/" + mm + "/" + yyyy);
        });
 });
 function xoa(control,bool){
    if(bool || bool == null)
      $(control).XoaRow({ajax:'../ajax/HS_BenhNhanBHDongTien_ajax2.aspx?do=xoa'});
 }
     
        //───────────────────────────────────────────────────────────────────────────────────────      
  function Find(control,page) {
   if(page == null) page = "1";
      $(control).TimKiem({
             ajax:"../ajax/HS_BenhNhanBHDongTien_ajax2.aspx?do=TimKiem&page="+page,showPopup:false
       },function () {
             $("#tableAjax_HS_BenhNhanBHDongTien").html('<img src="../images/loading.gif" style="margin:0 41%;padding:10px 0 10px 0"/>'); 
             return true;
       },function (data) {
                 $("#tableAjax_HS_BenhNhanBHDongTien").html(data);
                 $("table.jtable tr:nth-child(odd)").addClass("odd");
                 $("table.jtable tr:nth-child(even) td:first-child").addClass("even-first");
                 $("table.jtable tr:nth-child(odd) td:first-child").addClass("odd-first");
       });
      
 }
